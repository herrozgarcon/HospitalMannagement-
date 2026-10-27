using Hospital_Mannagement_System.Models;
using Hospital_Mannagement_System.repositories;

namespace Hospital_Mannagement_System.Services;

public class patientService
{
    private readonly patientrepos _repository;
    public patientService(patientrepos repository)
    {
        _repository = repository;
    }
    
    public async Task AddpatientAsync(patients patient)
    {
        if (string.IsNullOrEmpty(patient.PatientId))
            throw new ArgumentException("doctor  id  to be  created.");
        
        if (string.IsNullOrWhiteSpace(patient.PatientName))
            throw new ArgumentException("doctor  name is required.");
        
        if (patient.PatientAge <= 0)
            throw new ArgumentException("age must be greater than zero.");
        if(patient.PatientPhno <=0)
            throw new ArgumentException("doctor  phone number is required.");
 
        await _repository.addPatientasync(patient);
    }
}