using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Newtonsoft.Json;
using System.IO;

namespace NewTeach_DAL_Data
{
    static public class FollowingConvert {
        static public FollowingData_mod ConvertToClass(byte[] data) {
            return ConvertToClass(JsonBytesConvert.ToJson(data));

            //FollowingData_mod followingData = new FollowingData_mod();
            //followingData.Uid = BitConverter.ToInt32(data, 2);
            //followingData.User_id = BitConverter.ToInt32(data, 6);
            //followingData.Following_id = BitConverter.ToInt32(data, 10);

            //return followingData;
        }
        static public FollowingData_mod ConvertToClass(string jData) {
            FollowingData_mod r = new FollowingData_mod();

            var sr = new StringReader(jData);
            var reader = new JsonTextReader(sr);

            while (reader.Read()) {
                switch (reader.Path) {
                    case "following.uid":
                        r.Uid = reader.ReadAsInt32().Value;
                        break;
                    case "following.userid":
                        r.User_id = reader.ReadAsInt32().Value;
                        break;
                }
            }
            sr.Close();
            return r;
        }

        static public string ConvertToJson(int uid, bool ifSucceed) {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("following");
            writer.WriteStartObject();
            writer.WritePropertyName("uid");
            writer.WriteValue(uid);
            writer.WriteValue(ifSucceed);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }

        static public byte[] ConvertToBytes(int uid, bool isSucceed)
        {
<<<<<<< HEAD
            return JsonBytesConvert.ToBytes(ConvertToJson(uid, isSucceed), 2)
=======
            return JsonBytesConvert.ToBytes(ConvertToJson(uid, isSucceed),2);
>>>>>>> f6ceabe8aaabd7644130bdf8985438cb6d751287
            //byte[] bResult = new byte[6];

            //BitConverter.GetBytes(uid).CopyTo(bResult, 0);
            //BitConverter.GetBytes(isSucceed).CopyTo(bResult, 4);

            //return bResult;
        }
    }
}
