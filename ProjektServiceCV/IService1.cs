using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProjektServiceCV
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet]
        List<Item> GetItemsList();

        [OperationContract]
        [WebGet(UriTemplate = "Book/{id}")]
        Item GetItemById(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "AddBook/{name}")]
        void AddItem(string name);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateBook/{id}/{name}")]
        void UpdateItem(string id, string name);

        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteBook/{id}")]
        void DeleteItem(string id);

        // TODO: Add your service operations here
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
