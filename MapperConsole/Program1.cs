//// See https://aka.ms/new-console-template for more information
//// Initialize the MApper

//using AutoMapper;

//var config= new MapperConfiguration(cfg=>cfg.CreateMap<Employee,EmployeeDTO>()
//.ForMember(dest=> dest.fullName,act=> act.MapFrom(src=>src.Name))
//.ForMember(des=>des.dep, act=> act.MapFrom(src=>src.Department)));

////Creating the source object
//Employee emp = new Employee
//{
//    Name = "James",
//    Salary = 20000,
//    Address = "London",
//    Department = "IT"
//};

////Using automapper
//var mapper = new Mapper(config);
//var empDTO = mapper.Map<EmployeeDTO>(emp);


//Console.WriteLine("Name:" + empDTO.fullName + ", Salary:" + empDTO.Salary + ", Address:" + empDTO.Address + ", Department:" + empDTO.dep);
//Console.ReadLine();

//public class Employee
//{
//    public string Name { get; set; }
//    public int Salary { get; set; }
//    public string Address { get; set; }
//    public string Department { get; set; }
//}
//public class EmployeeDTO
//{
//    public string fullName { get; set; }
//    public int Salary { get; set; }
//    public string Address { get; set; }
//    public string dep { get; set; }
//}