using UnityEngine;

namespace VoxelBusters.CoreLibrary.Helpers
{
	public class DefaultJsonServiceProvider : IJsonServiceProvider
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnLoad()
		{
		}

		public string ToJson(object obj)
		{
			return null;
		}

		public object FromJson(string jsonString)
		{
			return null;
		}
	}
}
