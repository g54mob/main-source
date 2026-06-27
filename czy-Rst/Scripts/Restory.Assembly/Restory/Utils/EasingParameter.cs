using DG.Tweening;
using UnityEngine;

namespace Restory.Utils
{
	[CreateAssetMenu(menuName = "Restory/EasingParameter", fileName = "EasingParameter")]
	public class EasingParameter : ScriptableObject
	{
		[SerializeField]
		private bool useAnimationCurve;

		[SerializeField]
		private Ease ease;

		[SerializeField]
		private AnimationCurve animationCurve;

		public void SetEase(Tween tween)
		{
			if (useAnimationCurve)
			{
				tween.SetEase(animationCurve);
			}
			else
			{
				tween.SetEase(ease);
			}
		}
	}
}
