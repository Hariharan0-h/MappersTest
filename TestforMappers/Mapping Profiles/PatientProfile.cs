using static System.Runtime.InteropServices.JavaScript.JSType;
using TestforMappers.DTOs;
using TestforMappers.Model;
using AutoMapper;

namespace TestforMappers.Mapping_Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<PatientCreateDto, Patient>();
        }
    }
}
