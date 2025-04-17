using Mapster;
using TestforMappers.DTOs;
using TestforMappers.Model;

namespace TestforMappers.Mapping_Profiles
{
    public static class MapsterPatientMapper
    {
        static MapsterPatientMapper()
        {
            TypeAdapterConfig<Patient, PatientDto>
                .NewConfig()
                .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");
        }

        public static PatientDto ToDto(Patient patient) => patient.Adapt<PatientDto>();
        public static Patient ToEntity(PatientCreateDto dto) => dto.Adapt<Patient>();
    }
}
