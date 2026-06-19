using UnityEngine;
using UnityEngine.Events;

namespace MateoRyhr
{
	public class EnableAndDisable : MonoBehaviour
	{
		public UnityEvent OnEnableEvent;

		public UnityEvent OnDisableEvent;

		private void OnEnable()
		{
			OnEnableEvent.Invoke();
		}

		private void OnDisable()
		{
			OnDisableEvent.Invoke();
		}
	}
}
