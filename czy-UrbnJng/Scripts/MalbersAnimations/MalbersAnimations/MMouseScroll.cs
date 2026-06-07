using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Input/Mouse Scroll")]
	public class MMouseScroll : MonoBehaviour
	{
		public UnityEvent OnScrollUp = new UnityEvent();

		public UnityEvent OnScrollDown = new UnityEvent();

		private float mousedelta;

		private void Update()
		{
			float y = Input.mouseScrollDelta.y;
			if (y != mousedelta)
			{
				mousedelta = y;
				if (mousedelta < 0f)
				{
					OnScrollDown.Invoke();
				}
				else if (mousedelta > 0f)
				{
					OnScrollUp.Invoke();
				}
			}
		}
	}
}
