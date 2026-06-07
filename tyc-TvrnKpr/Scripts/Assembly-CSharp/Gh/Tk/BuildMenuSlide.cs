using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(AnimationEventObserver))]
	public class BuildMenuSlide : MonoBehaviour
	{
		private List<Transform> _slotTransforms;

		private void Start()
		{
		}

		private void OnAnimationEvent(object sender, AnimationEventArgs e)
		{
		}
	}
}
