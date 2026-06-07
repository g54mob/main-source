using UnityEngine;

namespace DV
{
	public static class ErrorSoundLogHandlerInit
	{
		private static string PREFAB_NAME = "[error_sound]";

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void Init()
		{
			InstantiateGameobject();
		}

		private static void InstantiateGameobject()
		{
			GameObject gameObject = Object.Instantiate(Resources.Load(PREFAB_NAME) as GameObject);
			gameObject.name = PREFAB_NAME;
			gameObject.transform.SetSiblingIndex(0);
		}
	}
}
