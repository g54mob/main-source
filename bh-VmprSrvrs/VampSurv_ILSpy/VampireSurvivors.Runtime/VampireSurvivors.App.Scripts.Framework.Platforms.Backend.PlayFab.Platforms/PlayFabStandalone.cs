using System;
using System.Threading.Tasks;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Core;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms;

public class PlayFabStandalone : IPlatform, IPlatformAuthentication
{
	public PlatformType GetPlatformName()
	{
		return PlatformType.STANDALONE;
	}

	public Task<ILoginResult> LoginOrRegister()
	{
		NotSupportedException ex = new NotSupportedException("Standalone platform does not support 'platform' authentication, only 'core' authentication.");
		throw ex;
	}

	public Task<ILoginResult> Login()
	{
		NotSupportedException ex = new NotSupportedException("Standalone platform does not support 'platform' authentication, only 'core' authentication.");
		throw ex;
	}

	public Task<ILinkResult> LinkAccount(bool force)
	{
		NotSupportedException ex = new NotSupportedException("Standalone platform does not support 'platform' authentication, only 'core' authentication.");
		throw ex;
	}

	public Task<bool> UnlinkAccount()
	{
		NotSupportedException ex = new NotSupportedException("Standalone platform does not support 'platform' authentication, only 'core' authentication.");
		throw ex;
	}
}
