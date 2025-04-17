using Riok.Mapperly.Abstractions;
using TestforMappers.DTOs;
using TestforMappers.Model;

namespace TestforMappers.Mapping_Profiles
{
    [Mapper]
    public partial class MapperlyPatientMapper
    {
        public partial PatientDto ToDto(Patient patient);
        public partial Patient ToEntity(PatientCreateDto dto);

        [MapProperty(nameof(Patient.FirstName), "FullName")]
        private string MapFullName(Patient p) => $"{p.FirstName} {p.LastName}";
    }
}