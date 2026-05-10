using UnityEngine;
using UnityEngine.Events;

namespace CTS
{
	public class DemoModifier : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent DemoEvents;

		[SerializeField]
		private UnityEvent FullReleaseEvents;

		private void Start()
		{
			FullReleaseEvents.Invoke();
		}
	}
}
