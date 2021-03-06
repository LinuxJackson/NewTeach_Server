﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Threading;
using System.Collections;
using NewTeach_BLL_Server.Account;
using NewTeach_BLL_Server.File;
using NewTeach_BLL_Server.Message;
using NewTeach_BLL_Server.Following;
using Model.Sockets;

namespace NewTeach_BLL_Server
{
    public class Data_BLL
    {
        public bool isLogined = false;
        public int logined_ID = 0;
        public short account_Type;

        public void Analysis(DataPackage data)
        {
            short type = BitConverter.ToInt16(data.Data, 0);

            if (type == 0)
                Thread.CurrentThread.Abort();

            //性能待优化
            Thread tdAnalysis = new Thread(delegate () {
                if (isLogined)
                {
                    switch (type)
                    {
                        case 1:            //信息[测试成功]
                            Message.Message message = new Message.Message(data.Data, logined_ID);
                            message.Send();
                            break;
                        case 4:        //获取账户信息[未测试]
                            ReadUserInfo readUserInfo = new ReadUserInfo(data);
                            readUserInfo.Response();
                            break;
                        case 5:        //修改账户信息[未测试]
                            EditAccountInfo editUserInfo = new EditAccountInfo(data, logined_ID);
                            editUserInfo.Response();
                            break;
                        case 6:        //请求文件[未测试] --机制待修改[重要]
                            SendFile sendFile = new SendFile(data);
                            sendFile.Send();
                            break;
                        case 7:        //接收文件[未测试] --机制待修改[重要]
                            //开辟新线程[待修改]
                            NewTeach_BLL_Server.File.UploadFile receFile = new File.UploadFile(data, logined_ID);
                            receFile.Receive();
                            break;
                        case 8:         //用户头像查看申请[未测试]
                            SelUserImage sendUserImage = new SelUserImage(data);
                            sendUserImage.Send();
                            break;
                        case 9:         //消息刷新申请[未测试]
                            MessageFresh msgFresh = new MessageFresh(data, logined_ID);
                            msgFresh.Response();
                            break;
                        case 10:        //搜索用户
                            SearchAccount searchAccount = new SearchAccount(data);
                            searchAccount.Response();
                            break;
                        case 11:        //添加关注
                            AddFollowing addFollowing = new AddFollowing(data, logined_ID);
                            addFollowing.Response();
                            break;
                        case 12:        //撤销关注
                            RemoveFollowing removeFollowing = new RemoveFollowing(data, logined_ID);
                            removeFollowing.Response();
                            break;
                        case 13:        //屏蔽
                            break;
                        case 14:        //图片消息[待定]
                            break;
                        case 15:        //获取关注列表
                            break;
                        case 16:        //上传头像
                            UploadUserImage uploadUserImage = new UploadUserImage(data, logined_ID);
                            uploadUserImage.Receive();
                            break;
                        case 17:        ///删除文件
                            DeleteFile deleteFile = new DeleteFile(data, logined_ID);
                            deleteFile.Response();
                            break;
                    }
                    if (account_Type == 1)    //学生
                    {
                        switch (type)
                        {
                            case 18:        //申请跟随
                                break;
                        }
                    }
                    if (account_Type == 2)      //老师
                    {
                        switch (type)
                        {

                        }
                    }
                }
                else
                {
                    switch (type)
                    {
                        case 2:            //登陆[测试成功]
                            AccountLogin accountLogin = new AccountLogin(data);
                            if (accountLogin.Login())
                            {
                                accountLogin.AddToOnlineUserList();
                                accountLogin.Respect();
                                isLogined = true;
                                logined_ID = accountLogin.loginData.User_id;
                            }
                            break;
                        case 3:         //账号申请[未测试]
                            AccountRequest accountRequest = new AccountRequest(data);
                            accountRequest.Response();
                            break;
                        case 6:        //请求文件[未测试]
                            SendFile sendFile = new SendFile(data);
                            sendFile.Send();
                            break;
                        case 8:         //用户头像查看申请[未测试]
                            SelUserImage sendUserImage = new SelUserImage(data);
                            sendUserImage.Send();
                            break;
                        case 10:        //搜索用户
                            SearchAccount searchAccount = new SearchAccount(data);
                            searchAccount.Response();
                            break;
                    }
                }
            });
            tdAnalysis.Start();
        }
    }
}
