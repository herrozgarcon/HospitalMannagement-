using Hospital_Mannagement_System.Models;
using Hospital_Mannagement_System.repositories;
using Hospital_Mannagement_System.Services;
using Microsoft.Data.SqlClient;

string connectionString =
    "Server=localhost,1433;Database=HMS;User Id=sa;Password=Hrithik21$;TrustServerCertificate=True;";


var doctorrep = new doctorrepos(connectionString);
var docservice = new doctorServices(doctorrep);

Console.WriteLine("enter the dicid to create a doctor");
string? docid = Console.ReadLine();
Console.WriteLine("Enter doctor name:");
string docName = Console.ReadLine() ?? "";

Console.WriteLine("Enter doctor specialization:");
string docspecilization = Console.ReadLine() ?? "";

Console.WriteLine("Enter doctor fees:");

int.TryParse(Console.ReadLine(), out int docFees);

await docservice.AdddoctorsAsync(new doctors{
    Doctor_id = docid,
    Doctor_name=docName,
    Specilization = docspecilization,
    ConsultationFee = docFees
});
Console.WriteLine("added doctor succesfully");
