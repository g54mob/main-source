using UnityEngine;

namespace VoxelBusters.CoreLibrary.Helpers
{
	public class DefaultLocalisationServiceProvider : ILocalisationServiceProvider
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnLoad()
		{
		}

		public string GetLocalisedString(string key, string defaultValue)
		{
			return null;
		}
	}
}
