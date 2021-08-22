// Requires: TeleportingCore

using Oxide.Core.Libraries.Covalence;

namespace Oxide.Plugins
{

    [Info("Player Teleporting", "Puddi Puddin", "0.1.0")]
    [Description("Allows players to teleport")]
    public class PlayerTeleprting : RustPlugin
    {
        private TeleportingCore teleportingCore;

        private void Loaded()
        {
            teleportingCore = (TeleportingCore)Manager.GetPlugin("TeleportingCore");
        }

        public class PlayerCommands
        {
            [Command("tpr")]
            private void OnTeleportRequest(IPlayer sender, string command, string[] args)
            {

            }

            [Command("tpa")]
            private void OnTeleportRequestAccept(IPlayer sender, string command, string[] args)
            {

            }

            [Command("tpc")]
            private void OnTeleportRequestCancel(IPlayer sender, string command, string[] args)
            {

            }
        }

        public class TeleportRequest : TeleportingCore.TeleportRequest
        {

        }
    }
}