using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestforMappers.Data;
using TestforMappers.DTOs;
using TestforMappers.Mapping_Profiles;
using TestforMappers.Model;

namespace TestforMappers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly MapperlyPatientMapper _mapperly;

        public PatientsController(AppDBContext context, IMapper mapper, MapperlyPatientMapper mapperly)
        {
            _context = context;
            _mapper = mapper;
            _mapperly = mapperly;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            return Ok(_mapper.Map<List<PatientDto>>(patients));
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return _mapper.Map<PatientDto>(patient);
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientDto>> PostPatient(PatientCreateDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<PatientDto>(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = result.Id }, result);
        }

        [HttpPost("mapster")]
        public async Task<ActionResult<PatientDto>> PostWithMapster(PatientCreateDto dto)
        {
            var patient = MapsterPatientMapper.ToEntity(dto);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return MapsterPatientMapper.ToDto(patient);
        }

        [HttpPost("mapperly")]
        public async Task<ActionResult<PatientDto>> PostWithMapperly(PatientCreateDto dto)
        {
            var patient = _mapperly.ToEntity(dto);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return _mapperly.ToDto(patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
