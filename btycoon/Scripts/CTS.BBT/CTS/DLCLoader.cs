using CTS.Core;
using UnityEngine.AddressableAssets;

namespace CTS
{
	public class DLCLoader : CTSBehaviour
	{
		protected override void OnAwake()
		{
			base.OnAwake();
			foreach (DLCDefinition item in Addressables.LoadAssetsAsync<DLCDefinition>("DLCDefinition").WaitForCompletion())
			{
				if (CTSSingleton<GamePlatform>.Instance.Library.TryAuthenticateGame() && CTSSingleton<GamePlatform>.Instance.Library.IsDLCInstalled(item.DLCKey))
				{
					item.OnLoaded();
				}
			}
		}
	}
}
