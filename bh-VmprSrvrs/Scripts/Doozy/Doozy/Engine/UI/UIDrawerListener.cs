using UnityEngine;

namespace Doozy.Engine.UI
{
	[AddComponentMenu("Doozy/Listeners/UIDrawer Listener", 13)]
	[DefaultExecutionOrder(-100)]
	public class UIDrawerListener : MonoBehaviour
	{
		public bool DebugMode;

		public string DrawerName;

		public bool CustomDrawerName;

		public UIDrawerEvent Event;

		public bool ListenForAllUIDrawers;

		public UIDrawerBehaviorType TriggerAction;

		private void Reset()
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

		private void OnMessage(UIDrawerMessage message)
		{
		}

		private void InvokeEvent(UIDrawerMessage message)
		{
		}

		private static UIDrawerListener AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}

		private static UIDrawerListener AddToScene(GameObject parent, bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
