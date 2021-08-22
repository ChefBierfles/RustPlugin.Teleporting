using System;
using System.Collections.Generic;
using System.Linq;

namespace Oxide.Plugins
{
    [Info("TeleportingCore", "Puddi Puddin", "0.1.0")]
    [Description("Dependency with hooks for handling teleporting")]
    public class TeleportingCore : RustPlugin
    {
        public class TeleportingManager
        {
            private List<TeleportRequest> TeleportRequests = new List<TeleportRequest>();

            public void RequestTeleport(TeleportRequest teleportRequest)
            {
                TeleportRequests.Add(teleportRequest);
            }

            public bool CancelTeleportRequest(string requesterId)
            {
                if (HasRequestedTeleport(requesterId)) { }
                return TeleportRequests.Remove(TeleportRequests.SingleOrDefault(t => t.RequesterId == requesterId));
            }

            public bool HasRequestedTeleport(string requesterId)
            {
                return TeleportRequests.Any(t => t.RequesterId == requesterId);
            }
        }

        public abstract class TeleportRequest
        {
            public event EventHandler RequestCreated;
            public event EventHandler RequestCompleted;

            public string RequesterId { get; }

            public TeleportRequest(string requesterId)
            {
                RequesterId = requesterId;
            }

            protected virtual void OnTeleportRequestCreated(EventArgs e)
            {
                RequestCreated?.Invoke(this, e);
            }

            protected virtual void OnTeleportRequestCompleted(EventArgs e)
            {
                RequestCompleted?.Invoke(this, e);
            }
        }

        public class PlayerTeleportRequest : TeleportRequest
        {
            public string ReceiverId { get; set; }

            public PlayerTeleportRequest(string teleportRequesterId, string receiverId) : base(teleportRequesterId)
            {
                ReceiverId = receiverId;
            }


        }
    }
}