using DG.Tweening;
using UnityEngine;

namespace Extensions
{
	public static class OutlineExtensions
	{
		public static void HideOutline(this Outline outline, float time, Ease ease = Ease.Unset)
		{
			DOTween.To(endValue: new Color(outline.OutlineColor.r, outline.OutlineColor.g, outline.OutlineColor.b, 0f), getter: () => outline.OutlineColor, setter: delegate(Color x)
			{
				outline.OutlineColor = x;
			}, duration: time).SetEase(ease);
		}

		public static void ShowOutline(this Outline outline, float time, Ease ease = Ease.Unset)
		{
			DOTween.To(endValue: new Color(outline.OutlineColor.r, outline.OutlineColor.g, outline.OutlineColor.b, 1f), getter: () => outline.OutlineColor, setter: delegate(Color x)
			{
				outline.OutlineColor = x;
			}, duration: time).SetEase(ease);
		}
	}
}
