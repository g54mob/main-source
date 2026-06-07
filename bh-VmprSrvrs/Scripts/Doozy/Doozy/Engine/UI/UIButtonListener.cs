using UnityEngine;

namespace Doozy.Engine.UI
{
	[AddComponentMenu("Doozy/Listeners/UIButton Listener", 13)]
	[DefaultExecutionOrder(-100)]
	public class UIButtonListener : MonoBehaviour
	{
		public string ButtonCategory;

		public string ButtonName;

		public bool DebugMode;

		public UIButtonEvent Event;

		public bool ListenForAllUIButtons;

		public UIButtonBehaviorType TriggerAction;

		private bool m_listeningForBackButton;

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

		private void OnMessage(UIButtonMessage message)
		{
		}

		private void InvokeEvent(UIButtonMessage message)
		{
		}

		private static UIButtonListener AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}

		private static UIButtonListener AddToScene(GameObject parent, bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
