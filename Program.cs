using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyManagement
{
    public class StaffMember
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public decimal MonthlySalary { get; set; }

        public override string ToString()
        {
            return $"Employee ID: {EmployeeId}, Name: {FullName}, Title: {JobTitle}, Salary: {MonthlySalary:C}";
        }
    }

    public class StaffManagementSystem
    {
        private List<StaffMember> _staffMembers = new List<StaffMember>();

        public void AddStaff(StaffMember staff)
        {
            if (_staffMembers.Any(s => s.EmployeeId == staff.EmployeeId))
            {
                Console.WriteLine("Error: An employee with this ID already exists in the system.");
                return;
            }
            _staffMembers.Add(staff);
            Console.WriteLine("Staff member added successfully.");
        }

        public void DisplayAllStaff()
        {
            if (_staffMembers.Count == 0)
            {
                Console.WriteLine("No staff members available.");
                return;
            }
            Console.WriteLine("\nList of Staff Members:");
            _staffMembers.ForEach(s => Console.WriteLine(s));
        }

        public void SearchStaffById(int employeeId)
        {
            var staff = _staffMembers.FirstOrDefault(s => s.EmployeeId == employeeId);
            if (staff == null)
            {
                Console.WriteLine("No staff member found with the given ID.");
                return;
            }
            Console.WriteLine($"\nStaff Member Found: {staff}");
        }

        public void ModifyStaffDetails(int employeeId, string fullName, string jobTitle, decimal monthlySalary)
        {
            var staff = _staffMembers.FirstOrDefault(s => s.EmployeeId == employeeId);
            if (staff == null)
            {
                Console.WriteLine("Error: Staff member not found.");
                return;
            }
            staff.FullName = fullName;
            staff.JobTitle = jobTitle;
            staff.MonthlySalary = monthlySalary;
            Console.WriteLine("Staff member details updated successfully.");
        }

        public void RemoveStaff(int employeeId)
        {
            var staff = _staffMembers.FirstOrDefault(s => s.EmployeeId == employeeId);
            if (staff == null)
            {
                Console.WriteLine("Error: Staff member not found.");
                return;
            }
            _staffMembers.Remove(staff);
            Console.WriteLine("Staff member removed successfully.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var managementSystem = new StaffManagementSystem();
            while (true)
            {
                Console.WriteLine("\nStaff Management System Menu:");
                Console.WriteLine("1. Add Staff Member");
                Console.WriteLine("2. View All Staff Members");
                Console.WriteLine("3. Search Staff by ID");
                Console.WriteLine("4. Update Staff Details");
                Console.WriteLine("5. Remove Staff Member");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your choice: ");

                int choice = int.Parse(Console.ReadLine() ?? "6");
                if (choice == 6) break;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Staff ID: ");
                        int employeeId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Full Name: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Enter Job Title: ");
                        string jobTitle = Console.ReadLine();
                        Console.Write("Enter Monthly Salary: ");
                        decimal monthlySalary = decimal.Parse(Console.ReadLine());
                        managementSystem.AddStaff(new StaffMember { EmployeeId = employeeId, FullName = fullName, JobTitle = jobTitle, MonthlySalary = monthlySalary });
                        break;

                    case 2:
                        managementSystem.DisplayAllStaff();
                        break;

                    case 3:
                        Console.Write("Enter Staff ID to Search: ");
                        employeeId = int.Parse(Console.ReadLine());
                        managementSystem.SearchStaffById(employeeId);
                        break;

                    case 4:
                        Console.Write("Enter Staff ID to Update: ");
                        employeeId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Updated Full Name: ");
                        fullName = Console.ReadLine();
                        Console.Write("Enter Updated Job Title: ");
                        jobTitle = Console.ReadLine();
                        Console.Write("Enter Updated Monthly Salary: ");
                        monthlySalary = decimal.Parse(Console.ReadLine());
                        managementSystem.ModifyStaffDetails(employeeId, fullName, jobTitle, monthlySalary);
                        break;

                    case 5:
                        Console.Write("Enter Staff ID to Remove: ");
                        employeeId = int.Parse(Console.ReadLine());
                        managementSystem.RemoveStaff(employeeId);
                        break;

                    default:
                        Console.WriteLine("Invalid option selected. Please try again.");
                        break;
                }
            }
        }
    }
}