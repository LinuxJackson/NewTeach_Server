using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Teach;
using Newtonsoft.Json;
using System.IO;

namespace NewTeach_DAL_Data.Teach
{
    public static class FollowTeacherInfoConvert_Re
    {
        static public string ConvertToJson_Query(FollowTeacherInfo_Re_mod data)
        {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("followteacherinfo");
            writer.WriteStartObject();
            writer.WritePropertyName("uid");
            writer.WriteValue(data.Uid);
            writer.WritePropertyName("issucceed");
            writer.WriteValue(data.IsSucceed);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }

        static public byte[] ConvertToBytes_Query(FollowTeacherInfo_Re_mod data)
        {
<<<<<<< HEAD
            return JsonBytesConvert.ToBytes(ConvertToJson_Query(data), 2)
=======
            return JsonBytesConvert.ToBytes(ConvertToJson_Query(data),2);
>>>>>>> f6ceabe8aaabd7644130bdf8985438cb6d751287
            //byte[] bResult = new byte[6];

            //BitConverter.GetBytes(data.Uid).CopyTo(bResult, 0);
            //BitConverter.GetBytes(data.IsSucceed).CopyTo(bResult, 4);

            //return bResult;
        }


        static public string ConvertToJson_Sel(int uid)
        {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("followteacherinfo");
            writer.WriteStartObject();
            writer.WritePropertyName("uid");
            writer.WriteValue(uid);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }

        static public byte[] ConvertToBytes_Sel(int uid)
        {
            return JsonBytesConvert.ToBytes(ConvertToJson_Query(data), 2);
            //byte[] bResult = new byte[8];

            //BitConverter.GetBytes((short)2).CopyTo(bResult, 0);
            //BitConverter.GetBytes(uid).CopyTo(bResult, 2);

            //return bResult;
        }
    }
}
