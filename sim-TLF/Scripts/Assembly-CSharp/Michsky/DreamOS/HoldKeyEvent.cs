using UnityEngine;
using UnityEngine.Events;

namespace Michsky.DreamOS
{
	[AddComponentMenu("DreamOS/Events/Hold Key Event")]
	public class HoldKeyEvent : MonoBehaviour
	{
		public KeyCode hotkey;

		public UnityEvent holdAction;

		public UnityEvent releaseAction;

		[HideInInspector]
		public bool isOn;

		[HideInInspector]
		public bool isHolding;

		private void Update()
		{
			if (Input.GetKey(hotkey))
			{
				isHolding = true;
				isOn = false;
			}
			else
			{
				isHolding = false;
				isOn = true;
			}
			if (isOn && !isHolding)
			{
				releaseAction.Invoke();
				isHolding = false;
				isOn = false;
			}
			else if (!isOn && isHolding)
			{
				holdAction.Invoke();
				isHolding = true;
			}
		}
	}
}
