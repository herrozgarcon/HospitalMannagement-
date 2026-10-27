using Hospital_Mannagement_System.Models;
using Microsoft.Data.SqlClient;

namespace Hospital_Mannagement_System.repositories;

public class doctorrepos
{
    private readonly string _connectionString;

    public doctorrepos(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task addDoctorasync(doctors doctor)
    {
        const string query = """
                             INSERT INTO doctors (docid, docname, specilization,fees)
                             VALUES (@docid, @docname, @specilization,@fees)
                             """;
        
        await using var connection = new SqlConnection(_connectionString);
        await using var command = new SqlCommand(query, connection);
        
        command.Parameters.AddWithValue("@docid", doctor.Doctor_id);
        command.Parameters.AddWithValue("@docname", doctor.Doctor_name);
        command.Parameters.AddWithValue("@specilization", doctor.Specilization);
        command.Parameters.AddWithValue("@fees", doctor.ConsultationFee);
        
        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }
    
    
}