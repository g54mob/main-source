using Doozy.Engine.Events;
using UnityEngine;

namespace Doozy.Engine
{
	[AddComponentMenu("Doozy/Listeners/Game Event Listener", 13)]
	[DefaultExecutionOrder(-100)]
	public class GameEventListener : MonoBehaviour
	{
		public bool DebugMode;

		public StringEvent Event;

		public string GameEvent;

		public bool ListenForAllGameEvents;

		private bool DebugComponent => false;

		private void Reset()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void RegisterListener()
		{
		}

		private void UnregisterListener()
		{
		}

		private void OnMessage(GameEventMessage message)
		{
		}

		private void InvokeEvent(GameEventMessage message)
		{
		}

		private static GameEventListener AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}

		private static GameEventListener AddToScene(GameObject parent, bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
