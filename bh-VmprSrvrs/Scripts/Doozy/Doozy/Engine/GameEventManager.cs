using UnityEngine;

namespace Doozy.Engine
{
	[AddComponentMenu("Doozy/Managers/Game Event Manager", 13)]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-200)]
	public class GameEventManager : MonoBehaviour
	{
		private static GameEventManager s_instance;

		public static GameEventManager Instance => null;

		private static bool ApplicationIsQuitting { get; set; }

		private bool DebugComponent => false;

		protected GameEventManager()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RunOnStart()
		{
		}

		private void Awake()
		{
		}

		private void OnApplicationQuit()
		{
		}

		public static GameEventManager AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}

		public static void ProcessGameEvent(GameEventMessage message, bool debug = false)
		{
		}
	}
}
