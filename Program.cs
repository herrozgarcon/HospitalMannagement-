using Hospital_Mannagement_System.Models;
using Hospital_Mannagement_System.repositories;
using Hospital_Mannagement_System.Services;
using Microsoft.Data.SqlClient;

string connectionString =
    "Server=localhost,1433;Database=HMS;User Id=sa;Password=Hrithik21$;TrustServerCertificate=True;";


var doctorrep = new doctorrepos(connectionString);
var docservice = new doctorServices(doctorrep);
var patrepo = new patientrepos(connectionString);
var patservice = new patientService(patrepo);

while (true)
{
    Console.WriteLine("\n===== HOSPITAL MANAGEMENT SYSTEM =====");
    Console.WriteLine("1. Add Doctor");
    Console.WriteLine("2. Add  Patient");
    Console.WriteLine("3. Search Doctor");
    Console.WriteLine("4. Update Doctor");
    Console.WriteLine("5. Delete Doctor");
    Console.WriteLine("6. Exit");

    Console.Write("Enter your choice: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid input! Please enter a number.");
        continue;
    }

    switch (choice)
    {
        case 1:
            Console.WriteLine("\n--- Add Doctor ---");

            Console.Write("Enter the doctor ID: ");
            string? docid = Console.ReadLine();

            Console.Write("Enter doctor name: ");
            string docName = Console.ReadLine() ?? "";

            Console.Write("Enter doctor specialization: ");
            string docspecilization = Console.ReadLine() ?? "";

            Console.Write("Enter doctor fees: ");

            if (!int.TryParse(Console.ReadLine(), out int docFees))
            {
                Console.WriteLine("Invalid fee amount!");
                break;
            }

            await docservice.AdddoctorsAsync(new doctors
            {
                Doctor_id = docid,
                Doctor_name = docName,
                Specilization = docspecilization,
                ConsultationFee = docFees
            });

            Console.WriteLine("Doctor added successfully!");
            break;

        case 2:
            Console.WriteLine("\n--- Add patient ---");

            Console.Write("Enter the patient ID: ");
            string? patid = Console.ReadLine();

            Console.Write("Enter doctor name: ");
            string patname = Console.ReadLine() ?? "";
            
            Console.Write("Enter patient age: ");

            if (!int.TryParse(Console.ReadLine(), out int patage))
            {
                Console.WriteLine("Invalid age !");
                break;
            }
            Console.WriteLine("enter patient phone number: ");
            if (!int.TryParse(Console.ReadLine(), out int patphno))
            {
                Console.WriteLine("Invalid phone number! !");
                break;
            }  
            await patservice.AddpatientAsync(new patients
            {
                PatientId = patid,
                PatientName = patname,
                PatientAge = patage,
                PatientPhno = patphno
            });

            Console.WriteLine("patient added successfully!");
            break;
        

        case 3:
            Console.WriteLine("Search Doctor functionality will be added here.");
            break;

        case 4:
            Console.WriteLine("Update Doctor functionality will be added here.");
            break;

        case 5:
            Console.WriteLine("Delete Doctor functionality will be added here.");
            break;

        case 6:
            Console.WriteLine("Exiting Hospital Management System...");
            return;

        default:
            Console.WriteLine("Invalid choice! Please select an option between 1 and 6.");
            break;
    }
}
