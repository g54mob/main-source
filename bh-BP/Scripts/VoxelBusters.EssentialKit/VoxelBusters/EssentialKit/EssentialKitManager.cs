using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class EssentialKitManager : PrivateSingletonBehaviour<EssentialKitManager>
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnLoad()
		{
		}

		protected override void OnSingletonAwake()
		{
		}
	}
}
