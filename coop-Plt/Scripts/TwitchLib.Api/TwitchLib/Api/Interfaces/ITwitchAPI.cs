using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Core.Undocumented;
using TwitchLib.Api.Helix;
using TwitchLib.Api.ThirdParty;
using TwitchLib.Api.V5;

namespace TwitchLib.Api.Interfaces
{
	public interface ITwitchAPI
	{
		IApiSettings Settings { get; }

		TwitchLib.Api.V5.V5 V5 { get; }

		TwitchLib.Api.Helix.Helix Helix { get; }

		TwitchLib.Api.ThirdParty.ThirdParty ThirdParty { get; }

		Undocumented Undocumented { get; }
	}
}
