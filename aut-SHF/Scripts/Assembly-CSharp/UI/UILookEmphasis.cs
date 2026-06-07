using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	[RequireComponent(typeof(SimpleAnimation))]
	public class UILookEmphasis : MonoBehaviour
	{
		[SerializeField]
		private SimpleAnimation _sAnimator;

		[SerializeField]
		private Image _animationImage;

		public void PlayAnimation(float eulerAngleZ = 0f)
		{
		}

		public void StopAnimation()
		{
		}
	}
}
