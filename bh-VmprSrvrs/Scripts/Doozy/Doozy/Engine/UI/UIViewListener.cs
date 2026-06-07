using UnityEngine;

namespace Doozy.Engine.UI
{
	[AddComponentMenu("Doozy/Listeners/UIView Listener", 13)]
	[DefaultExecutionOrder(-100)]
	public class UIViewListener : MonoBehaviour
	{
		public bool DebugMode;

		public UIViewEvent Event;

		public bool ListenForAllUIViews;

		public UIViewBehaviorType TriggerAction;

		public string ViewCategory;

		public string ViewName;

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

		private void OnMessage(UIViewMessage message)
		{
		}

		private void InvokeEvent(UIViewMessage message)
		{
		}

		private static UIViewListener AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}

		private static UIViewListener AddToScene(GameObject parent, bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
