using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Newtonsoft.Json;
using System.IO;

namespace NewTeach_DAL_Data
{
    static public class AccountInfoConvert {
        static public string ConvertToJson(AccountInfo_mod data) {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
                writer.WritePropertyName("accountinfo");
                writer.WriteStartObject();
                    writer.WritePropertyName("uid");
                    writer.WriteValue(data.Uid);
                    writer.WritePropertyName("userid");
                    writer.WriteValue(data.User_id);
                    writer.WritePropertyName("sex");
                    writer.WriteValue(data.Sex);
                    writer.WritePropertyName("birthday");
                    writer.WriteValue(data.Birthday.Ticks);
                    writer.WritePropertyName("phone");
                    writer.WriteValue(data.Phone);
                writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }
        
        static public byte[] ConvertToBytes(AccountInfo_mod data)
        {
            return JsonBytesConvert.ToBytes(ConvertToJson(data),2);
            /*
            //4+2+4+24
            byte[] bResult = new byte[48];

            BitConverter.GetBytes((short)2).CopyTo(bResult, 0);
            BitConverter.GetBytes(data.Uid).CopyTo(bResult, 2);
            BitConverter.GetBytes(data.User_id).CopyTo(bResult, 6);
            BitConverter.GetBytes(data.Sex).CopyTo(bResult, 10);
            BitConverter.GetBytes(data.Birthday.Ticks).CopyTo(bResult, 12);
            Encoding.Default.GetBytes(data.Phone).CopyTo(bResult, 20);

            return bResult;
            */
        }
        
        static public AccountInfo_mod ConvertToClass(string jData) {
            AccountInfo_mod r = new AccountInfo_mod();

            var sr = new StringReader(jData);
            var reader = new JsonTextReader(sr);

            while (reader.Read()) {
                switch (reader.Path) {
                    case "accountinfo.uid":
                        r.Uid = reader.ReadAsInt32().Value;
                        break;
                    case "accountinfo.userid":
                        r.User_id = reader.ReadAsInt32().Value;
                        break;
                    case "accountinfo.sex":
                        r.Sex = (short)reader.ReadAsInt32().Value;
                        break;
                    case "accountinfo.birthday":
                        r.Birthday = new DateTime(reader.ReadAsInt32().Value);
                        break;
                    case "accountinfo.phone":
                        r.Phone = reader.ReadAsString();
                        break;
                }
            }
            sr.Close();
            return r;
        }

        static public AccountInfo_mod ConvertToClass(byte[] data)
        {
            var json = Encoding.Default.GetString(data);
            return ConvertToClass(data);
            /*
            AccountInfo_mod dataResult = new AccountInfo_mod();

            dataResult.User_id = BitConverter.ToInt32(data, 2);
            dataResult.Sex = BitConverter.ToInt16(data, 6);
            dataResult.Birthday = new DateTime(BitConverter.ToInt64(data, 12));
            string tempPhone = Encoding.Default.GetString(data, 20, 24);

            foreach (char c in tempPhone)
            {
                if (c == '\0')
                    break;
                dataResult.Phone += c;
            }

            return dataResult;
            */
        }

        static public string ConvertToJson_Re(bool boolean, Int32 uid) {
            // Type: 2
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
                writer.WritePropertyName("repely");
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

        static public byte[] ConvertToBytes_Re(bool boolean, Int32 uid)
        {
            var json = ConvertToJson_Re(boolean, uid);
            var jBytes = Encoding.Default.GetBytes(json);
            var r = new Byte[jBytes.Length + 2];
            BitConverter.GetBytes((short)2).CopyTo(r, 0);
            jBytes.CopyTo(r, 2);

            return r;

            /*
            byte[] bResult = new byte[8];

            BitConverter.GetBytes((short)2).CopyTo(bResult, 0);
            BitConverter.GetBytes(uid).CopyTo(bResult, 2);
            BitConverter.GetBytes(boolean).CopyTo(bResult, 6);

            return bResult;
            */
        }
    }
}
