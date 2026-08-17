using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.Framework.Platforms;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;

public class PlayFabLinkAborted : ILinkResult
{
	public TokenAbortReason TokenAbortReason;
}
