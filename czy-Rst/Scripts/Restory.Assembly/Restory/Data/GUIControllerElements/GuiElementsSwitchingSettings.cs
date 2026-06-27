using DG.Tweening;
using UnityEngine;

namespace Restory.Data.GUIControllerElements
{
	[CreateAssetMenu(menuName = "Restory/GUI/GUI Elements Switching Settings", fileName = "GuiElementsSwitchingSettings", order = 5)]
	public class GuiElementsSwitchingSettings : ScriptableObject
	{
		[SerializeField]
		private float fadeDuration = 0.5f;

		[SerializeField]
		private Ease fadeInEase = Ease.Linear;

		[SerializeField]
		private Ease fadeOutEase = Ease.Linear;

		public float FadeDuration => fadeDuration;

		public Ease FadeOutEase => fadeOutEase;

		public Ease FadeInEase => fadeInEase;
	}
}
