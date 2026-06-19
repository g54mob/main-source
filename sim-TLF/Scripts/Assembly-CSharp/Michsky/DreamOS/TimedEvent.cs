using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.DreamOS
{
	[AddComponentMenu("DreamOS/Events/Timed Event")]
	public class TimedEvent : MonoBehaviour
	{
		public float timer = 4f;

		public bool enableAtStart;

		public UnityEvent timerAction;

		private void Start()
		{
			if (enableAtStart)
			{
				StartCoroutine("ProcessTimedEvent");
			}
		}

		private IEnumerator ProcessTimedEvent()
		{
			yield return new WaitForSeconds(timer);
			timerAction.Invoke();
			StopCoroutine("ProcessTimedEvent");
		}

		public void StartIEnumerator()
		{
			StartCoroutine("ProcessTimedEvent");
		}

		public void StopIEnumerator()
		{
			StopCoroutine("ProcessTimedEvent");
		}
	}
}
