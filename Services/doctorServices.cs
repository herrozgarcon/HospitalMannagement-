using System.Text.Json;
using Hospital_Mannagement_System.Models;
using Hospital_Mannagement_System.repositories;

namespace Hospital_Mannagement_System.Services;

public class doctorServices
{
    private readonly doctorrepos _repository;
    public doctorServices(doctorrepos repository)
    {
        _repository = repository;
    }
    
    public async Task AdddoctorsAsync(doctors doctor)
    {
        if (string.IsNullOrEmpty(doctor.Doctor_id))
            throw new ArgumentException("doctor  id  to be  created.");
        
        if (string.IsNullOrWhiteSpace(doctor.Doctor_name))
            throw new ArgumentException("doctor  name is required.");
 
        if (string.IsNullOrWhiteSpace(doctor.Specilization))
            throw new ArgumentException("doctor  specilization is required.");
        if (doctor.ConsultationFee <= 0)
            throw new ArgumentException("fees must be greater than zero.");
        
 
        await _repository.addDoctorasync(doctor);
    }
    
}