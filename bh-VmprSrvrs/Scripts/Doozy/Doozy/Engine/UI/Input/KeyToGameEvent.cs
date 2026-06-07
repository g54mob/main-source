using UnityEngine;

namespace Doozy.Engine.UI.Input
{
	[AddComponentMenu("Doozy/Input/Key To Game Event", 13)]
	[DefaultExecutionOrder(-100)]
	public class KeyToGameEvent : MonoBehaviour
	{
		public bool DebugMode;

		public InputData InputData;

		public string GameEvent;

		public bool HasGameEvent => false;

		private bool DebugComponent => false;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void Execute()
		{
		}

		private static KeyToGameEvent AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
