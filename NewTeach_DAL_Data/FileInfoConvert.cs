using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Newtonsoft.Json;
using System.IO;

namespace NewTeach_DAL_Data
{
    static public class FileInfoConvert {
        static public FileInfo_mod ConvertToClass_Transport(string jData) {
            FileInfo_mod r = new FileInfo_mod();

            var sr = new StringReader(jData);
            var reader = new JsonTextReader(sr);

            while (reader.Read()) {
                switch (reader.Path) {
                    case "fileinfo.uid":
                        r.Uid = reader.ReadAsInt32().Value;
                        break;
                    case "fileinfo.userid":
                        r.User_id = reader.ReadAsInt32().Value;
                        break;
                    case "fileinfo.filetype":
                        r.File_type = (short)reader.ReadAsInt32().Value;
                        break;
                    case "fileinfo.filelength":
                        r.File_length = reader.ReadAsInt32().Value;
                        break;
                    case "fileinfo.filename":
                        r.FileName = reader.ReadAsString();
                        break;
                    case "fileinfo.FileKey":
                        r.FileKey = reader.ReadAsString();
                        break;
                }
            }
            sr.Close();
            return r;
        }

        static public FileInfo_mod ConvertToClass_Transport(byte[] data)
        {
            return ConvertToClass_Transport(JsonBytesConvert.ToJson(data));
            /*
            FileInfo_mod fileRequest = new FileInfo_mod();
            fileRequest.Uid = BitConverter.ToInt32(data, 2);
            fileRequest.User_id = BitConverter.ToInt32(data, 6);
            fileRequest.File_type = BitConverter.ToInt16(data, 10);
            fileRequest.File_length = BitConverter.ToInt32(data, 12);

            string temp = Encoding.Default.GetString(data, 16, 255);
            foreach (char c in temp)
            {
                if (c == '\0')
                    break;
                fileRequest.FileName += c;
            }

            fileRequest.FileKey = Encoding.Default.GetString(data, 271, 16);
            return fileRequest;
            */
        }

        static public UploadFileRequest_mod ConvertToClass_FileUpLoad(string jData) {
            UploadFileRequest_mod r = new UploadFileRequest_mod();

            var sr = new StringReader(jData);
            var reader = new JsonTextReader(sr);

            while (reader.Read()) {
                switch (reader.Path) {
                    case "fileinfo.uid":
                        r.Uid = reader.ReadAsInt32().Value;
                        break;
                    case "fileinfo.userid":
                        r.User_id = reader.ReadAsInt32().Value;
                        break;
                    case "fileinfo.filetype":
                        r.File_type = (short)reader.ReadAsInt32().Value;
                        break;
                    case "fileinfo.filelength":
                        r.File_length = reader.ReadAsInt32().Value;
                        break;
                    case "fileinfo.filename":
                        r.File_name = reader.ReadAsString();
                        r.File_name_length = (short)r.File_name.Length;
                        break;
                }
            }
            sr.Close();
            return r;
        }

        static public UploadFileRequest_mod ConvertToClass_FileUpLoad(byte[] data)
        {
            return ConvertToClass_FileUpLoad(JsonBytesConvert.ToJson(data));
            /*
            UploadFileRequest_mod receiveFile = new UploadFileRequest_mod();
            receiveFile.Uid = BitConverter.ToInt32(data, 2);
            receiveFile.User_id = BitConverter.ToInt32(data, 6);
            receiveFile.File_type = BitConverter.ToInt16(data, 10);       
            receiveFile.File_length = BitConverter.ToInt16(data, 12);
            receiveFile.File_name_length = BitConverter.ToInt16(data, 16);
            receiveFile.File_name = Encoding.Default.GetString(data, 18, receiveFile.File_name_length);
            return receiveFile;
            */
        }

        static public string ConvertToJson_FileInfo(FileInfo_mod data) {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("fileinfo");
            writer.WriteStartObject();
            writer.WritePropertyName("uid");
            writer.WriteValue(data.Uid);
            writer.WritePropertyName("userid");
            writer.WriteValue(data.User_id);
            writer.WritePropertyName("filetype");
            writer.WriteValue(data.File_type);
            writer.WritePropertyName("filelength");
            writer.WriteValue(data.File_length);
            writer.WritePropertyName("filename");
            writer.WriteValue(data.FileName);
            writer.WritePropertyName("filekey");
            writer.WriteValue(data.FileKey);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }

        static public byte[] ConvertToBytes_FileInfo(FileInfo_mod data)
        {
<<<<<<< HEAD
            return JsonBytesConvert.ToBytes(ConvertToJson_FileInfo(data), 2)
=======
            return JsonBytesConvert.ToBytes(ConvertToJson_FileInfo(data),2);
>>>>>>> f6ceabe8aaabd7644130bdf8985438cb6d751287
            /*
            byte[] bResult = new byte[285];
            BitConverter.GetBytes(data.Uid).CopyTo(bResult, 0);
            BitConverter.GetBytes(data.User_id).CopyTo(bResult, 4);
            BitConverter.GetBytes(data.File_type).CopyTo(bResult, 8);
            BitConverter.GetBytes(data.File_length).CopyTo(bResult, 10);
            Encoding.Default.GetBytes(data.FileName).CopyTo(bResult, 14);
            Encoding.Default.GetBytes(data.FileKey).CopyTo(bResult, 269);

            return bResult;
            */
        }

        static public string ConvertToJson_Response(FileRequestResponse_mod frr) {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("fileinfo");
            writer.WriteStartObject();
            writer.WritePropertyName("uid");
            writer.WriteValue(frr.Uid);
            writer.WritePropertyName("opcode");
            writer.WriteValue(frr.Op_code);
            writer.WriteEndObject();
            writer.WriteEndObject();

            writer.Flush();
            var str = sw.ToString();
            sw.Close();

            return str;
        }

        static public byte[] ConvertToBytes_Response(FileRequestResponse_mod frr)
        {
            return JsonBytesConvert.ToBytes(ConvertToJson_Response(frr), 2)
            /*
            byte[] data = new byte[6];

            BitConverter.GetBytes(frr.Uid).CopyTo(data, 0);
            BitConverter.GetBytes(frr.Op_code).CopyTo(data, 4);

            return data;
            */
        }
    }
}
