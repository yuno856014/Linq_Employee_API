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
    [Table("Employee")]
    public class Employees : BaseEntity, IDataEntity
    {
        [Key]
        [LVRequired]
        [LVMaxLength(250)]

        public string Id { get; set; }
        [LVRequired]
        [LVMaxLength(250)]
        public string EmpLastName { get; set; }
        [LVRequired]
        [LVMaxLength(250)]
        public string EmpName { get; set; }
        [LVRequired]
        [LVMaxLength(250)]
        public string Position { get; set; }
        [LVRequired]
        [LVMaxLength(250)]
        public string Avatar { get; set; }
        [LVRequired]
        [LVMaxLength(250)]
        public string Title { get; set; }
        [LVRequired]
        public int DepartmentId { get; set; }

        public object GetFieldValue(string name)
        {
            return name switch
            {
                "Id" => Id,
                "EmpLastName" => EmpLastName,
                "EmpName" => EmpName,
                "Avatar" => Avatar,
                "Position" => Position,
                "Title" => Title,
                "DepartmentId" => DepartmentId,
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
                case "EmpLastName":
                    EmpLastName = value;
                    break;
                case "EmpName":
                    EmpName = value;
                    break;
                case "Avatar":
                    Avatar = value;
                    break;
                case "Title":
                    Title = value;
                    break;
                case "DepartmentId":
                    DepartmentId = value;
                    break;
                case "Position":
                    Position = value;
                    break;
            }
        }
    }
}
