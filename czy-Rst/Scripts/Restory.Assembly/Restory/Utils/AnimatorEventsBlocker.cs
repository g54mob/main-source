using UnityEngine;

namespace Restory.Utils
{
	public class AnimatorEventsBlocker : MonoBehaviour
	{
		private void Start()
		{
			if (TryGetComponent<Animator>(out var component))
			{
				component.fireEvents = false;
			}
		}
	}
}
