using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace RCSP.Models
{
    public class LabData
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte GroupIndex { get; set; }
        public string GroupPrefix { get; set; }
        public short CurrentCourse {get; set;}
        public short AverageMark { get; set;}
    }
}