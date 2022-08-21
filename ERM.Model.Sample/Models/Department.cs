using ERM.Common;
using ERM.Common.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.Model.Sample.Models
{
    [LVMessagePack, Serializable]
    [Table("Departments")]
    public class Department : BaseEntity, IDataEntity
    {
        [Key]
        [LVRequired]
        public int Id { get; set; }
        [LVRequired]
        [LVMaxLength(250)]
        public string DepartmentName { get; set; }
        [LVRequired]
        public int ParentId { get; set; }

        public object GetFieldValue(string name)
        {
            return name switch
            {
                "Id" => Id,
                "DepartmentName" => DepartmentName,
                "ParentId" => ParentId,
                _ => null
            };
        }

        public void SetFieldValue(string name, dynamic value)
        {
            switch (name)
            {
                case "Id":
                    Id = value;
                    break;
                case "DepartmentName":
                    DepartmentName = value;
                    break;
                case "ParentId":
                    ParentId = value;
                    break;
            }
        }
    }
}
