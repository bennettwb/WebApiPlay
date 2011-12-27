using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR;
using SignalR.Hubs;

namespace WebApi.Hubs
{
    public class AssetEndpoint : PersistentConnection
    {

        protected override System.Threading.Tasks.Task OnReceivedAsync(string clientId, string data)
        {
            
            return Connection.Broadcast(EventConduit.Process(data));
        }
      

    }
}