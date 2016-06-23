using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Teach;
using Newtonsoft.Json;
using System.IO;

namespace NewTeach_DAL_Data.Teach
{
    static public class FollowTeacherInfoConvert
    {
        static public FollowTeacherInfo_mod ConvertToClass(string jData) {
            var r = new FollowTeacherInfo_mod();

            var sr = new StringReader(jData);
            var reader = new JsonTextReader(sr);

            while (reader.Read()) {
                switch (reader.Path) {
                    case "followteacherinfo.uid":
                        r.Uid = reader.ReadAsInt32().Value;
                        break;
                    case "followteacherinfo.state":
                        r.State = (short)reader.ReadAsInt32().Value;
                        break;
                    case "followteacherinfo.teacherid":
                        r.Teacher_id = reader.ReadAsInt32().Value;
                        break;
                    case "followteacherinfo.studentid":
                        r.Student_id = reader.ReadAsInt32().Value;
                        break;
                }
            }
            sr.Close();
            return r;
        }

        static public FollowTeacherInfo_mod ConvertToClass(byte[] data)
        {
            return ConvertToClass(JsonBytesConvert.ToJson(data));
            //FollowTeacherInfo_mod fti = new FollowTeacherInfo_mod();

            //fti.Uid = BitConverter.ToInt32(data, 2);
            //fti.State = BitConverter.ToInt16(data, 6);
            //fti.Teacher_id = BitConverter.ToInt32(data, 8);
            //fti.Student_id = BitConverter.ToInt32(data, 12);

            //return fti;
        }

        static public string ConvertToJson(FollowTeacherInfo_mod data) {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("followteacherinfo");
            writer.WriteStartObject();
            writer.WritePropertyName("uid");
            writer.WriteValue(data.Uid);
            writer.WritePropertyName("state");
            writer.WriteValue(data.State);
            writer.WritePropertyName("teacherid");
            writer.WriteValue(data.Teacher_id);
            writer.WritePropertyName("studentid");
            writer.WriteValue(data.Student_id);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }

        static public byte[] ConvertToBytes(FollowTeacherInfo_mod data)
        {
<<<<<<< HEAD
            return JsonBytesConvert.ToBytes(ConvertToJson(data), 2)
=======
            return JsonBytesConvert.ToBytes(ConvertToJson(data),2);
>>>>>>> f6ceabe8aaabd7644130bdf8985438cb6d751287
            //byte[] bResult = new byte[14];

            //BitConverter.GetBytes(data.Uid).CopyTo(bResult, 0);
            //BitConverter.GetBytes(data.State).CopyTo(bResult, 4);
            //BitConverter.GetBytes(data.Teacher_id).CopyTo(bResult, 6);
            //BitConverter.GetBytes(data.Student_id).CopyTo(bResult, 10);

            //return bResult;
        }
    }
}
