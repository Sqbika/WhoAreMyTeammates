using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exiled.API.Features;

namespace WhoAreMyTeammates
{
    public class WhoAreMyTeammatesPlugin : Plugin<WAMTConfig>
    {
        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted += OnNewRound;
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnNewRound;
        }

        public override void OnReloaded()
        {
            OnEnabled();
            OnDisabled();
        }

        private void OnNewRound()
        {
            List<Player> scps = Player.List.Where(player => player.Team == Team.SCP).ToList();
            StringBuilder builder = new StringBuilder();
            builder.Append("SCP Team:");
            foreach (Player player in scps)
            {
                builder.Append(", ").Append(player.Role);
                if (Config.IncludeNames)
                {
                    builder.Append("(").Append(player.Nickname).Append(")");
                }
            }
            String result = builder.ToString();
            foreach (Player player in scps)
            {
                player.ClearBroadcasts();
                player.Broadcast(15, result);
            }
        }
    }
}