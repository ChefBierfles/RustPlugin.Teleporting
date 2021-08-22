namespace Oxide.Plugins
{
    [Info("TeleportingCore", "Puddi Puddin", "0.1.0")]
    [Description("Dependency with hooks for handling teleporting")]
    public class TeleportingCore : RustPlugin
    {
        public class TeleporterManager
        {
            private List<TeleportRequest> TeleportRequests = new List<TeleportRequest>();

            public void RequestTeleport(TeleportRequest teleportRequest)
            {
                TeleportRequests.Add(teleportRequest);
            }

            public bool CancelTeleport(string teleportRequesterId)
            {
                if (HasRequestedTeleport) { }
                return TeleportRequests.Remove(TeleportRequests.SingleOrDefault(t => t.TeleportRequesterId == teleportRequesterId));
            }

            public bool HasRequestedTeleport(string teleportRequesterId)
            {
                return TeleportRequests.Any(t => t.TeleportRequesterId == teleportRequesterId);
            }
        }

        public class TeleportRequest
        {
            public event EventHandler TeleportRequestCreated;
            public event EventHandler TeleportRequestCompleted;

            public string TeleportRequesterId { get; }

            public TeleportRequest(string teleportRequesterId)
            {
                TeleportRequesterId = teleportRequesterId;
            }

            protected virtual void OnTeleportRequestCreated(EventArgs e)
            {
                TeleportRequestCreated?.Invoke(this, e);
            }

            protected virtual void OnTeleportRequestCompleted(EventArgs e)
            {
                TeleportRequestCompleted?.Invoke(this, e);
            }
        }
    }
}