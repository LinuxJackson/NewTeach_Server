using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Newtonsoft.Json;
using System.IO;

namespace NewTeach_DAL_Data
{
    static public class SelUserImageConvert {
        static public UserImage_mod ConvertToClass(string jData) {
            UserImage_mod r = new UserImage_mod();

            var sr = new StringReader(jData);
            var reader = new JsonTextReader(sr);

            while (reader.Read()) {
                switch (reader.Path) {
                    case "seluserimage.uid":
                        r.Uid = reader.ReadAsInt32().Value;
                        break;
                    case "seluserimage.userid":
                        r.User_id = reader.ReadAsInt32().Value;
                        break;
                    case "seluserimage.filelength":
                        r.File_length = reader.ReadAsInt32().Value;
                        break;
                }
            }
            sr.Close();
            return r;
        }

        static public UserImage_mod ConvertToClass(byte[] data)
        {
            return ConvertToClass(JsonBytesConvert.ToJson(data),2);
            /*
            UserImage_mod userImage = new UserImage_mod();

            userImage.Uid = BitConverter.ToInt32(data, 2);
            userImage.User_id = BitConverter.ToInt32(data, 6);
            userImage.File_length = BitConverter.ToInt32(data, 10);

            return userImage;
            */
        }

        static public string ConvertToJson(UserImage_mod data) {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("seluserimage");
            writer.WriteStartObject();
            writer.WritePropertyName("uid");
            writer.WriteValue(data.Uid);
            writer.WritePropertyName("userid");
            writer.WriteValue(data.User_id);
            writer.WritePropertyName("filelength");
            writer.WriteValue(data.File_length);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }

        static public byte[] ConvertToBytes(UserImage_mod data)
        {
<<<<<<< HEAD
            return JsonBytesConvert.ToBytes(ConvertToJson(data), 2)
=======
            return JsonBytesConvert.ToBytes(ConvertToJson(data),2);
>>>>>>> f6ceabe8aaabd7644130bdf8985438cb6d751287
            /*
            byte[] bResult = new byte[12];

            BitConverter.GetBytes(data.Uid).CopyTo(bResult, 0);
            BitConverter.GetBytes(data.User_id).CopyTo(bResult, 4);
            BitConverter.GetBytes(data.File_length).CopyTo(bResult, 8);

            return bResult;
            */
        }
    }
}
