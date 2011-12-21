using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WebApi.Api
{
    [ServiceContract]
    public class ContactsApi
    {
        [WebGet(UriTemplate = "")]
        public IEnumerable<Contact> Get()
        {
            var contacts = new List<Contact>()
                               {
                                   new Contact() {ContactId = 1, Name = "Ron Grontowski"},
                                   new Contact() {ContactId = 1, Name = "Tom Brady"},

                               };
            return contacts;
        } 
    }
}