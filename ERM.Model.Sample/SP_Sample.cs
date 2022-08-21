using ERM.Common;
using ERM.Common.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERM.Model.Sample
{
    [LVMessagePack, Serializable]
    [Table("BS_Banks")]
    public class SP_Sample : BaseEntity, IDataEntity
    {
        public SP_Sample()
        {
            this.CreatedOn = DateTime.Now;
            this.Assign = true;
            this.Delete = true;
            this.Write = true;
            this.Share = true;
        }

        [Key]
        [Column(Order = 1)]
        [LVRequired]
        [LVMaxLength(20)]
        public string SampleID { get; set; }


        [LVRequired]
        [LVMaxLength(300)]
        public string SampleName { get; set; }


        [LVRequired]
        [LVDateRange]
        public DateTime CreatedOn { get; set; }


        [LVRequired]
        [LVMaxLength(20)]
        public string CreatedBy { get; set; }

        public object GetFieldValue(string name)
        {
            return name switch
            {
                "SampleID" => SampleID,
                "SampleName" => SampleName,
                "CreatedOn" => CreatedOn,
                "CreatedBy" => CreatedBy,
                _ => null
            };
        }

        public void SetFieldValue(string name, dynamic value)
        {
            switch (name)
            {
                case "SampleID":
                    SampleID = value;
                    break;
                case "SampleName":
                    SampleName = value;
                    break;
                case "CreatedOn":
                    CreatedOn = value;
                    break;
                case "CreatedBy":
                    CreatedBy = value;
                    break;
            }
        }
    }
}
