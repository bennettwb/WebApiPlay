using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SignalR;
using SignalR.Hubs;

namespace WebApi.Hubs
{
    public class AssetEndpoint : PersistentConnection
    {

        protected override System.Threading.Tasks.Task OnReceivedAsync(string clientId, string data)
        {

            return Task.Factory.StartNew(() =>
                                             {
                                                 System.Threading.Thread.Sleep(5000);
                                                 return Connection.Broadcast(EventConduit.Process(data));
                                             }
                ); 
        }
      

    }
}