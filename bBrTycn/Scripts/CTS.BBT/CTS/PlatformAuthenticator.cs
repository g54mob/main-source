using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class PlatformAuthenticator : CTSBehaviour
	{
		protected override void OnAwake()
		{
			base.OnAwake();
			if (!CTSSingleton<GamePlatform>.InstanceExists() || !CTSSingleton<GamePlatform>.Instance.Library.TryAuthenticateGame())
			{
				Application.Quit();
			}
		}
	}
}
