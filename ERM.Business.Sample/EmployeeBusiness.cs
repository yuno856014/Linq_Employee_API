using ERM.Common;
using ERM.Common.Http;
using ERM.Common.Services;
using ERM.Model.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.Business.Sample
{
    public class EmployeeBusiness : BusinessBase
    {
        public async Task GetListAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
        {
            var empId = requestReader.ReadString();
            var sp = await GetListLogicAsync(empId);
            responseWriter.WriteObject(sp);
        }
        private async Task<object> GetListLogicAsync(string empId)
        {
            //Get list
            var data = await Repository.Get<Employees>().AsAsync().ToListAsync();


            //Parse to json
            var json = LVJsonHelper.Serializer(data);
            return data;
        }
        public async Task GetListDepIdAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
        {
            var deps = await GetListDepIdLogicAsync();
            responseWriter.WriteObject(deps);
        }
        private async Task<object> GetListDepIdLogicAsync()
        {
            //Get list
            var emp = Repository.Get<Employees>().ToList();
            var dep = Repository.Get<Department>().ToList();
            
            //Parse to json
            var data = from d in dep
                       join e in emp
                       on d.Id equals e.DepartmentId into g
                       select new
                       {
                           Id = d.Id,
                           DepartmentName = d.DepartmentName,
                           ParentId = d.ParentId,
                           emloyees = g.DefaultIfEmpty()
                       };
                       
            return data;
        }
        //Add
        public async Task AddAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
        {
            var data = requestReader.ReadObject<Employees>();
            var oSave = await AddAsyncLogic(data);
            UnitOfWork.SaveChanges();
            responseWriter.WriteObject(oSave);
        }

        private async Task<bool> AddAsyncLogic(Employees data)
        {
            if (data.Id != "0" && data != null)
            {
                Repository.Add(data);
            }
            else
            {
                return false;
            }
            return true;
        }

        //Edit
        public async Task EditAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
        {
            var data = requestReader.ReadObject<Employees>();
            var oSave = await EditAsyncLogic(data);
            UnitOfWork.SaveChanges();
            responseWriter.WriteObject(oSave);
        }

        private async Task<bool> EditAsyncLogic(Employees data)
        {

            if (data.Id != "0" && data != null)
            {
                Repository.Update(data);
            }
            else
            {
                return false;
            }
            return true;
        }

        //Remove
        public async Task DeleteAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
        {
            var data = requestReader.ReadObject<Employees>();
            var oSave = await DeleteAsyncLogic(data);
            UnitOfWork.SaveChanges();
            responseWriter.WriteObject(oSave);
        }

        private async Task<bool> DeleteAsyncLogic(Employees data)
        {
            if (data.Id != "0" && data != null)
            {
                Repository.Delete(data);
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
