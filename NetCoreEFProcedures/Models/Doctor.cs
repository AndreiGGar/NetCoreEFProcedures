﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreEFProcedures.Models
{
    [Table("DOCTOR")]
    public class Doctor
    {
        [Key]
        [Column("HOSPITAL_COD")]
        public int HOSPITAL_COD { get; set; }
        [Column("DOCTOR_NO")]
        public int DOCTOR_NO { get; set; }
        [Column("APELLIDO")]
        public string APELLIDO { get; set; }
        [Column("ESPECIALIDAD")]
        public string ESPECIALIDAD { get; set; }
        [Column("SALARIO")]
        public int SALARIO { get; set; }
    }
}
