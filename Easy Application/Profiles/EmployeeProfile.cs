using Easy_Application.Models;
using AutoMapper;
using Easy_Application.DTOs;


namespace Easy_Application.Profiles;

public class EmployeeProfile : Profile
{

    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>();
    } 

}