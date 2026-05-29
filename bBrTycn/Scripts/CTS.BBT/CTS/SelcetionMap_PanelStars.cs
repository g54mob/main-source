using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public class SelcetionMap_PanelStars : MonoBehaviour
	{
		[SerializeField]
		private Animator _layoutStarsAnimator;

		[field: SerializeField]
		public AnimationClip ShowingStarsAnim { get; private set; }

		[field: SerializeField]
		public List<SelectionMap_AnimatedStars> ListStars { get; private set; }

		[field: SerializeField]
		public GameObject LayoutstarsPanel { get; private set; }

		public void LaunchAnim()
		{
			_layoutStarsAnimator.SetTrigger("Start");
		}

		public void FinishAnim()
		{
			_layoutStarsAnimator.SetTrigger("Finish");
		}

		public void ResetAnimator()
		{
			_layoutStarsAnimator.ResetTrigger("Start");
			_layoutStarsAnimator.ResetTrigger("Finish");
		}
	}
}
