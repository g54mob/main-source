using UnityEngine;
using UnityEngine.Events;

namespace MateoRyhr
{
	public class OnStart : MonoBehaviour
	{
		public UnityEvent OnStartEvent;

		private void Start()
		{
			OnStartEvent?.Invoke();
		}
	}
}
