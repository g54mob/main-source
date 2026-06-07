using System.Collections.Generic;
using UnityEngine;

namespace Lean.Touch
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanTouchEvents")]
	[AddComponentMenu("Lean/Touch/Lean Touch Events")]
	public class LeanTouchEvents : MonoBehaviour
	{
		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		public void HandleFingerDown(LeanFinger finger)
		{
		}

		public void HandleFingerUpdate(LeanFinger finger)
		{
		}

		public void HandleFingerUp(LeanFinger finger)
		{
		}

		public void HandleFingerTap(LeanFinger finger)
		{
		}

		public void HandleFingerSwipe(LeanFinger finger)
		{
		}

		public void HandleGesture(List<LeanFinger> fingers)
		{
		}
	}
}
