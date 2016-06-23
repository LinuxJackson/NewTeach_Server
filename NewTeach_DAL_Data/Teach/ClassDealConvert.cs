using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Teach;
using Newtonsoft.Json;
using System.IO;


namespace NewTeach_DAL_Data.Teach
{
    static public class ClassDealConvert
    {
        static public ClassDealList_mod ConvertToClass(string jData) {
            var r = new ClassDealList_mod();

            var sr = new StringReader(jData);
            var reader = new JsonTextReader(sr);

            while (reader.Read()) {
                switch (reader.Path) {
                    case "classdeal.uid":
                        r.Uid = reader.ReadAsInt32().Value;
                        break;
                    case "classdeal.classid":
                        r.Class_id = reader.ReadAsInt32().Value;
                        break;
                    case "classdeal.studentid":
                        r.Student_id = reader.ReadAsInt32().Value;
                        break;
                    case "classdeal.dealstate":
                        r.Deal_state = (short)reader.ReadAsInt32().Value;
                        break;
                    case "classdeal.dealprice":
                        r.Deal_price = reader.ReadAsInt32().Value;
                        break;
                    case "classdeal.reveiw":
                        r.Review = reader.ReadAsString();
                        break;
                }
            }
            sr.Close();
            return r;

        }

        static public ClassDealList_mod ConvertToClass(byte[] data)
        {
            return ConvertToClass(JsonBytesConvert.ToJson(data));
            //ClassDealList_mod cdl = new ClassDealList_mod();

            //cdl.Uid = BitConverter.ToInt32(data, 2);
            //cdl.Class_id = BitConverter.ToInt32(data, 6);
            //cdl.Student_id = BitConverter.ToInt32(data, 10);
            //cdl.Deal_state = BitConverter.ToInt16(data, 14);
            //cdl.Deal_price = BitConverter.ToInt32(data, 16);
            //cdl.Review = Encoding.Default.GetString(data, 20, 500);

            //return cdl;
        }

        static public string ConvertToJson(ClassDealList_mod data) {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("classdeal");
            writer.WriteStartObject();
            writer.WritePropertyName("uid");
            writer.WriteValue(data.Uid);
            writer.WritePropertyName("studentid");
            writer.WriteValue(data.Student_id);
            writer.WritePropertyName("dealstate");
            writer.WriteValue(data.Deal_state);
            writer.WritePropertyName("dealprice");
            writer.WriteValue(data.Deal_price);
            writer.WritePropertyName("review");
            writer.WriteValue(data.Review);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }

        static public byte[] ConvertToBytes(ClassDealList_mod data)
        {
<<<<<<< HEAD
            return JsonBytesConvert.ToBytes(ConvertToJson(data), 2)
=======
            return JsonBytesConvert.ToBytes(ConvertToJson(data),2);
>>>>>>> f6ceabe8aaabd7644130bdf8985438cb6d751287
            //byte[] bResult = new byte[518];

            //BitConverter.GetBytes(data.Uid).CopyTo(bResult, 0);
            //BitConverter.GetBytes(data.Class_id).CopyTo(bResult, 4);
            //BitConverter.GetBytes(data.Student_id).CopyTo(bResult, 8);
            //BitConverter.GetBytes(data.Deal_state).CopyTo(bResult, 12);
            //BitConverter.GetBytes(data.Deal_price).CopyTo(bResult, 14);
            //Encoding.Default.GetBytes(data.Review).CopyTo(bResult, 18);

            //return bResult;
        }
    }
}
