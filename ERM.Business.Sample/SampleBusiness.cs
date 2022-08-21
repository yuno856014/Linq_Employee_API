using ERM.Common;
using ERM.Common.Http;
using ERM.Common.Services;
using ERM.Model.Sample;
using ERM.Model.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERM.Business.Sample
{
    public class SampleBusiness : BusinessBase
    {
        #region Default
        public async Task GetAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
        {
            string sSampleID = requestReader.ReadString();
            SP_Sample oAlerts = await GetAsyncLogic(sSampleID);
            responseWriter.WriteObject(oAlerts);
            
        }

        private Task<SP_Sample> GetAsyncLogic(string sampleID)
        {
            if (string.IsNullOrEmpty(sampleID)) return null;
            
            return Repository.GetOneAsync<SP_Sample>(x => x.SampleID == sampleID);
        }
        #endregion
        public async Task GetListAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
        {

            /* Đọc các kiểu dữ liệu từ request. */
            //Read string
            var str = requestReader.ReadString();
            //Read boolen
            var boolean = requestReader.ReadBoolean();
            //Get Int
            var inT = requestReader.ReadInt16();
            //Get float
            var flt = requestReader.ReadDouble();
            //Get object truyền loại object muốn Deserializer vào <>;
            var obj = requestReader.ReadObject<SP_Sample>();
            var sp = await GetListLogicAsync(str);

            //Trả dữ liệu về cho client;
            responseWriter.WriteObject(sp);
        }

        private async Task<object> GetListLogicAsync(string str)
        {
            //Get list
            var data = await Repository.Get<SP_Sample>().AsAsync().ToListAsync();

            //Get one row
            var rows = await Repository.GetOneAsync<SP_Sample>(x => x.SampleID == str);

            ////Joins 
            //var tb1 = Repository.Get<AD_UserConnections>();
            //var join = data.Join(tb1, x => x.SampleID, y => y.ConnectionID, (x, y) => new
            //{
            //    Field1 = x.SampleID,
            //    Field2 = y.ConnectionID,
            //    Field3 = x.SampleName,
            //    /*Fieldxxxx....*/
            //}).ToList();

            //Parse to json
            var json = LVJsonHelper.Serializer(data);

            // giải mã json sang đối tượng SP_Sample
            LVJsonHelper.Deserializer<List<SP_Sample>>(str);

            return data;
        }


        //Add
        public async Task AddAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
       {
            var data = requestReader.ReadString();
            var oSave = await AddAsyncLogic(data);
            UnitOfWork.SaveChanges();
            responseWriter.WriteObject(oSave);
        }

        private async Task<bool> AddAsyncLogic(string data)
        {
            var model = new Department();
            if (!string.IsNullOrEmpty(data))
                model = LVJsonHelper.Deserializer<Department>(data);
            Repository.Add(model);
            return true;
        }

        //Edit
        public async Task EditAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
        {
            var data = requestReader.ReadObject<SP_Sample>();
            var oSave = await EditAsyncLogic(data);
            UnitOfWork.SaveChanges();
            responseWriter.WriteObject(oSave);
        }

        private async Task<bool> EditAsyncLogic(SP_Sample data)
        {
            Repository.Update(data);
            return true;
        }

        //Remove
        public async Task DeleteAsync(LVStreamReader requestReader, LVStreamWriter responseWriter)
        {
            var data = requestReader.ReadObject<SP_Sample>();
            var oSave = await DeleteAsyncLogic(data);
            UnitOfWork.SaveChanges();
            responseWriter.WriteObject(oSave);
        }

        private async Task<bool> DeleteAsyncLogic(SP_Sample data)
        {
            Repository.Delete(data);
            return true;
        }
    }
}
