﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AutoPiWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAutoPiService
    {
        [OperationContract]
        [WebGet]
        Dictionary<int, bool> GetLights();

        [OperationContract]
        [WebGet(UriTemplate = "Light/{id}")]
        KeyValuePair<int, bool> GetLightById(string id);

        [OperationContract]
        Person GetData(string id);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "AddBook/{name}")]
        //void AddBook(string name);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "UpdateBook/{id}/{name}")]
        //void UpdateBook(string id, string name);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "DeleteBook/{id}")]
        //void DeleteBook(string id);

        //[OperationContract]
        //[WebGet(ResponseFormat = WebMessageFormat.Json)]
        //List<string> GetBooksNames();

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
