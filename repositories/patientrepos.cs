using Hospital_Mannagement_System.Models;
using Microsoft.Data.SqlClient;

namespace Hospital_Mannagement_System.repositories;

public class patientrepos
{
    private readonly string _connectionString;

    public patientrepos(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task addPatientasync(patients patient)
    {
        const string query = """
                             INSERT INTO Patients (PatientId, PatientName, PatientAge,PatientPhno)
                             VALUES (@PatientId, @PatientName, @PatientAge,@PatientPhno)
                             """;
        
        await using var connection = new SqlConnection(_connectionString);
        await using var command = new SqlCommand(query, connection);
        
        command.Parameters.AddWithValue("@PatientId", patient.PatientId);
        command.Parameters.AddWithValue("@PatientName", patient.PatientName);
        command.Parameters.AddWithValue("@PatientAge", patient.PatientAge);
        command.Parameters.AddWithValue("@PatientPhno", patient.PatientPhno);
        
        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }


}