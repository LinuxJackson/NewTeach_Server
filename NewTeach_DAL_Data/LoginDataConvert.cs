using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Newtonsoft.Json;
using System.IO;

namespace NewTeach_DAL_Data
{
    static public class LoginDataConvert {

        static public string ConvertToJson(bool boolean, int uid) {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("logindata");
            writer.WriteStartObject();
            writer.WritePropertyName("uid");
            writer.WriteValue(uid);
            writer.WritePropertyName("ifsuccessed");
            writer.WriteValue(boolean);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }

        static public byte[] ConvertToBytes(bool boolean, int uid)
        {
<<<<<<< HEAD
            return JsonBytesConvert.ToBytes(ConvertToJson(boolean, uid), 2)
=======
            return JsonBytesConvert.ToBytes(ConvertToJson(boolean, uid),2);
>>>>>>> f6ceabe8aaabd7644130bdf8985438cb6d751287
            //byte[] bResult = new byte[8];
            //BitConverter.GetBytes((short)2).CopyTo(bResult, 0);
            //BitConverter.GetBytes(uid).CopyTo(bResult, 2);
            //BitConverter.GetBytes(boolean).CopyTo(bResult, 6);

            //return bResult;
        }

        static public LoginData_mod ConvertToClass(string jData) {
            LoginData_mod r = new LoginData_mod();

            var sr = new StringReader(jData);
            var reader = new JsonTextReader(sr);

            while (reader.Read()) {
                switch (reader.Path) {
                    case "logindata.uid":
                        r.Uid = reader.ReadAsInt32().Value;
                        break;
                    case "logindata.userid":
                        r.User_id = reader.ReadAsInt32().Value;
                        break;
                    case "logindata.password":
                        r.User_password = reader.ReadAsString();
                        break;
                }
            }
            sr.Close();
            return r;
        }

        static public LoginData_mod ConvertToClass(byte[] data)
        {
            return ConvertToClass(JsonBytesConvert.ToJson(data));
            //LoginData_mod dataResult = new LoginData_mod();
            //dataResult.Uid = BitConverter.ToInt32(data, 2);
            //dataResult.User_id = BitConverter.ToInt32(data, 6);

            //string pwd = Encoding.Default.GetString(data, 10, 16);
            //int i = 0;
            //while (pwd[i] != '\0')
            //{
            //    dataResult.User_password += pwd[i];
            //    i++;
            //}

            //return dataResult;
        }
    }

    static public class AccountRequestConvert {
        static public LoginData_mod ConvertToClass(string jData) {
            LoginData_mod r = new LoginData_mod();

            var sr = new StringReader(jData);
            var reader = new JsonTextReader(sr);

            while (reader.Read()) {
                switch (reader.Path) {
                    case "logindata.uid":
                        r.Uid = reader.ReadAsInt32().Value;
                        break;
                    case "logindata.type":
                        r.Type = (short)reader.ReadAsInt32().Value;
                        break;
                    case "logindata.password":
                        r.User_password = reader.ReadAsString();
                        break;
                }
            }
            sr.Close();
            return r;
        }

        static public LoginData_mod ConvertToClass(byte[] data)
        {
            return ConvertToClass(JsonBytesConvert.ToJson(data));
            //LoginData_mod dataResult = new LoginData_mod();
            //dataResult.Uid = BitConverter.ToInt32(data, 2);
            //dataResult.Type = BitConverter.ToInt16(data, 6);
            //string sTemp = Encoding.Default.GetString(data, 8, 16);
            //foreach (char c in sTemp)
            //{
            //    if (c == '\0')
            //        break;
            //    dataResult.User_password += c;
            //}
            //return dataResult;
        }

        static public string ConvertToJson(LoginData_mod data) {
            // Type: 2
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("logindata");
            writer.WriteStartObject();
            writer.WritePropertyName("uid");
            writer.WriteValue(data.Uid);
            writer.WritePropertyName("userid");
            writer.WriteValue(data.User_id);
            writer.WritePropertyName("type");
            writer.WriteValue(data.Type);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }

        static public byte[] ConvertToBytes(LoginData_mod data)
        {
            return JsonBytesConvert.ToBytes(ConvertToJson(data), 2);
            //byte[] bResult = new byte[12];

            //BitConverter.GetBytes((short)2).CopyTo(bResult, 0);
            //BitConverter.GetBytes(data.Uid).CopyTo(bResult, 2);
            //BitConverter.GetBytes(data.User_id).CopyTo(bResult, 6);
            //BitConverter.GetBytes(data.Type).CopyTo(bResult, 10);

            //return bResult;
        }
    }
}
