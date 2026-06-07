using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Events
{
	[AddComponentMenu("Malbers/Events/On [Enable-Disable] Event")]
	public class EnableDisableEvent : MonoBehaviour
	{
		public UnityEvent OnActive;

		public UnityEvent OnDeactive;

		public string Description = "";

		[HideInInspector]
		public bool ShowDescription;

		public void OnEnable()
		{
			OnActive.Invoke();
		}

		public void OnDisable()
		{
			OnDeactive.Invoke();
		}

		[ContextMenu("Show Description")]
		internal void EditDescription()
		{
			ShowDescription = !ShowDescription;
		}
	}
}
