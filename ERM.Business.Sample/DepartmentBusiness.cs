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
    public class DepartmentBusiness : BusinessBase
    {
        public async Task GetListAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
        {
            var str = requestReader.ReadString();
            var sp = await GetListLogicAsync(str);
            responseWriter.WriteObject(sp);

        }
        private async Task<object> GetListLogicAsync(string depid)
        {

            //Get list
            var data = await Repository.Get<Department>().AsAsync().ToListAsync();
            var json = LVJsonHelper.Serializer(data);

            return data;
        }
        //Add
        public async Task AddAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
        {
            var data = requestReader.ReadObject<Department>();
            var oSave = await AddAsyncLogic(data);
            UnitOfWork.SaveChanges();
            responseWriter.WriteObject(oSave);
        }

        private async Task<bool> AddAsyncLogic(Department data)
        {
            if(data.Id != 0)
            {
            Repository.Add(data);
            }else
            {
                return false;
            }    
            return true;
        }

        //Edit
        public async Task EditAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
        {
            var data = requestReader.ReadObject<Department>();
            var oSave = await EditAsyncLogic(data);
            UnitOfWork.SaveChanges();
            responseWriter.WriteObject(oSave);
        }

        private async Task<bool> EditAsyncLogic(Department data)
        {
            if (data.Id != 0)
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
            var data = requestReader.ReadObject<Department>();
            var oSave = await DeleteAsyncLogic(data);
            UnitOfWork.SaveChanges();
            responseWriter.WriteObject(oSave);
        }

        private async Task<bool> DeleteAsyncLogic(Department data)
        {
            if (data.Id != 0)
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
