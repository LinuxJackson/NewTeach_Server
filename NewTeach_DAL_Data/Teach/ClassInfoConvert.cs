using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Teach;
using Newtonsoft.Json;
using System.IO;

namespace NewTeach_DAL_Data.Teach
{
    public static class ClassInfoConvert
    {
        public static ClassInfo_mod ConvertToClass_Info(string jData) {
            var r = new ClassInfo_mod();

            var sr = new StringReader(jData);
            var reader = new JsonTextReader(sr);

            while (reader.Read()) {
                switch (reader.Path) {
                    case "classinfo.uid":
                        r.Uid = reader.ReadAsInt32().Value;
                        break;
                    case "classinfo.teacherid":
                        r.Teacher_id = reader.ReadAsInt32().Value;
                        break;
                    case "classinfo.subject":
                        r.Subject = (short)reader.ReadAsInt32().Value;
                        break;
                    case "classinfo.starttime":
                        r.Start_time = new DateTime(reader.ReadAsInt32().Value);
                        break;
                    case "classinfo.endtime":
                        r.End_time = new DateTime(reader.ReadAsInt32().Value);
                        break;
                    case "classinfo.classid":
                        r.Class_id = reader.ReadAsInt32().Value;
                        break;
                    case "classinfo.classstate":
                        r.Class_state = (short)reader.ReadAsInt32().Value;
                        break;
                    case "classinfo.studentcount":
                        r.Student_count = reader.ReadAsInt32().Value;
                        break;
                    case "classinfo.classintroduction":
                        r.Class_introduction = reader.ReadAsString();
                        break;
                }
            }
            sr.Close();
            return r;
        }

        public static ClassInfo_mod ConvertToClass_Info(byte[] data)
        {
            return ConvertToClass_Info(JsonBytesConvert.ToJson(data));
            //ClassInfo_mod ci = new ClassInfo_mod();

            //ci.Uid = BitConverter.ToInt32(data, 2);
            //ci.Teacher_id = BitConverter.ToInt32(data, 6);
            //ci.Subject = BitConverter.ToInt16(data, 10);
            //long tick = BitConverter.ToInt64(data, 12);
            //ci.Start_time = new DateTime(tick);
            //tick = BitConverter.ToInt64(data, 20);
            //ci.End_time = new DateTime(tick);
            //ci.Class_id = BitConverter.ToInt32(data, 28);
            //ci.Class_state = BitConverter.ToInt16(data, 32);
            //ci.Student_count = BitConverter.ToInt32(data, 34);
            //ci.Class_introduction = Encoding.Default.GetString(data, 38, 200);

            //return ci;
        }

        public static string ConvertToJson_Info(ClassInfo_mod data) {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("classinfo");
            writer.WriteStartObject();
            writer.WritePropertyName("uid");
            writer.WriteValue(data.Uid);
            writer.WritePropertyName("teacherid");
            writer.WriteValue(data.Teacher_id);
            writer.WritePropertyName("subject");
            writer.WriteValue(data.Subject);
            writer.WritePropertyName("starttime");
            writer.WriteValue(data.Start_time.Ticks);
            writer.WritePropertyName("endtime");
            writer.WriteValue(data.End_time.Ticks);
            writer.WritePropertyName("classid");
            writer.WriteValue(data.Class_id);
            writer.WritePropertyName("classstate");
            writer.WriteValue(data.Class_state);
            writer.WritePropertyName("studentcount");
            writer.WriteValue(data.Student_count);
            writer.WritePropertyName("classintroduction");
            writer.WriteValue(data.Class_introduction);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }

        public static byte[] ConvertToBytes_Info(ClassInfo_mod data)
        {
<<<<<<< HEAD
            return JsonBytesConvert.ToBytes(ConvertToJson_Info(data), 2)
=======
            return JsonBytesConvert.ToBytes(ConvertToJson_Info(data),2);
>>>>>>> f6ceabe8aaabd7644130bdf8985438cb6d751287
            //byte[] bResult = new byte[236];

            //BitConverter.GetBytes(data.Uid).CopyTo(bResult, 0);
            //BitConverter.GetBytes(data.Teacher_id).CopyTo(bResult, 4);
            //BitConverter.GetBytes(data.Subject).CopyTo(bResult, 8);
            //BitConverter.GetBytes(data.Start_time.Ticks).CopyTo(bResult, 10);
            //BitConverter.GetBytes(data.End_time.Ticks).CopyTo(bResult, 18);
            //BitConverter.GetBytes(data.Class_id).CopyTo(bResult, 26);
            //BitConverter.GetBytes(data.Class_state).CopyTo(bResult, 30);
            //BitConverter.GetBytes(data.Student_count).CopyTo(bResult, 32);
            //Encoding.Default.GetBytes(data.Class_introduction).CopyTo(bResult, 36);

            //return bResult;
        }

        public static ClassStudentInfo_mod ConvertToClass_Student(string jData) {
            var r = new ClassStudentInfo_mod();

            var sr = new StringReader(jData);
            var reader = new JsonTextReader(sr);

            while (reader.Read()) {
                switch (reader.Path) {
                    case "classonfostudent.uid":
                        r.Uid = reader.ReadAsInt32().Value;
                        break;
                    case "classonfostudent.studentid":
                        r.Student_id = reader.ReadAsInt32().Value;
                        break;
                    case "classonfostudent.classid":
                        r.Class_id = reader.ReadAsInt32().Value;
                        break;
                }
            }
            sr.Close();
            return r;
        }

        public static ClassStudentInfo_mod ConvertToClass_Student(byte[] data)
        {
            return ConvertToClass_Student(JsonBytesConvert.ToJson(data));
            //ClassStudentInfo_mod csi = new ClassStudentInfo_mod();

            //csi.Uid = BitConverter.ToInt32(data, 2);
            //csi.Student_id = BitConverter.ToInt32(data, 6);
            //csi.Class_id = BitConverter.ToInt32(data, 10);

            //return csi;
        }

        public static string ConvertToJson_Student(ClassStudentInfo_mod data) {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("classinfostudent");
            writer.WriteStartObject();
            writer.WritePropertyName("uid");
            writer.WriteValue(data.Uid);
            writer.WritePropertyName("studentid");
            writer.WriteValue(data.Student_id);
            writer.WritePropertyName("classid");
            writer.WriteValue(data.Class_id);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }

        public static byte[] ConvertToBytes_Student(ClassStudentInfo_mod data)
        {
<<<<<<< HEAD
            return JsonBytesConvert.ToBytes(ConvertToJson_Info(data), 2)
=======
            return JsonBytesConvert.ToBytes(ConvertToJson_Info(data),2);
>>>>>>> f6ceabe8aaabd7644130bdf8985438cb6d751287
            //byte[] bResult = new byte[12];

            //BitConverter.GetBytes(data.Uid).CopyTo(bResult, 0);
            //BitConverter.GetBytes(data.Student_id).CopyTo(bResult, 4);
            //BitConverter.GetBytes(data.Class_id).CopyTo(bResult, 8);

            //return bResult; 
        }
    }
}
