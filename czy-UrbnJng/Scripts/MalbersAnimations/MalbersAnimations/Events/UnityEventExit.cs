using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Events
{
	[AddComponentMenu("Malbers/Events/Unity Event Exit")]
	public class UnityEventExit : MonoBehaviour
	{
		public UnityEvent OnDisableEvent;

		public string Description = "";

		[HideInInspector]
		public bool ShowDescription;

		public void OnDisable()
		{
			OnDisableEvent.Invoke();
		}

		[ContextMenu("Show Description")]
		internal void EditDescription()
		{
			ShowDescription = !ShowDescription;
		}
	}
}
