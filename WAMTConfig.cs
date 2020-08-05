using Exiled.API.Interfaces;

namespace WhoAreMyTeammates
{
    public class WAMTConfig : IConfig
    {
        public bool IsEnabled { get; set; }

        public bool IncludeNames { get; set; } = false;
    }
}