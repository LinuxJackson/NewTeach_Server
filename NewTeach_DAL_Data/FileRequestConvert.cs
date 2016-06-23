using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace NewTeach_DAL_Data
{
    static public class FileRequestConvert
    {
        static public FileRequest ConvertToClass_SendDelete(string jData)
        {
            FileRequest r = new FileRequest();

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
                    case "fileinfo.filename":
                        r.File_name = reader.ReadAsString();
                        break;
                    case "fileinfo.filekey":
                        r.FileKey = reader.ReadAsString();
                        break;
                }
            }
            sr.Close();
            return r;
        }

        static public FileRequest ConvertToClass_SendDelete(byte[] data)
        {
            return ConvertToClass_SendDelete(JsonBytesConvert.ToJson(data));
            /*
            FileRequest fileRequest = new FileRequest();
            fileRequest.Uid = BitConverter.ToInt32(data, 2);
            fileRequest.User_id = BitConverter.ToInt32(data, 6);

            string temp = Encoding.Default.GetString(data, 10, 255);
            foreach (char c in temp)
            {
                if (c == '\0')
                    break;
                fileRequest.FileName += c;
            }

            fileRequest.FileKey = Encoding.Default.GetString(data, 265, 16);
            return fileRequest;
            */
        }

        static public ReceiveFileRequest ConvertToClass_Receive(string jData)
        {
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
<<<<<<< HEAD
        }

        static public ReceiveFileRequest ConvertToClass_Receive(string jData)
        {
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
=======
>>>>>>> f6ceabe8aaabd7644130bdf8985438cb6d751287
        }

        static public ReceiveFileRequest ConvertToClass_Receive(byte[] data)
        {
            return ConvertToClass_Receive(JsonBytesConvert.ToJson(data));
            /*
            ReceiveFileRequest receiveFile = new ReceiveFileRequest();
            receiveFile.Uid = BitConverter.ToInt32(data, 2);
            receiveFile.User_id = BitConverter.ToInt32(data, 6);
            receiveFile.File_length = BitConverter.ToInt16(data, 10);
            receiveFile.File_name_length = BitConverter.ToInt16(data, 14);
            receiveFile.File_name = Encoding.Default.GetString(data, 16, receiveFile.File_name_length);
            return receiveFile;
            */
        }

        static public string ConvertToJson_Response(FileRequestResponse frr)
        {
            var sw = new StringWriter();
            var writer = new JsonTextWriter(sw);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("filerequest");
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

        static public byte[] ConvertToBytes_Response(FileRequestResponse frr)
        {
<<<<<<< HEAD
            return JsonBytesConvert.ToBytes(ConvertToJson_Response(frr), 2)
=======
            return JsonBytesConvert.ToBytes(ConvertToJson_Response(frr),2);
>>>>>>> f6ceabe8aaabd7644130bdf8985438cb6d751287
            //byte[] data = new byte[6];

            //BitConverter.GetBytes(frr.Uid).CopyTo(data, 0);
            //BitConverter.GetBytes(frr.Op_code).CopyTo(data, 4);

            //return data;
        }
    }
}
