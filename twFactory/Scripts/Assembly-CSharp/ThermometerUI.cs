using System;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThermometerUI : MonoBehaviour
{
	[Serializable]
	private struct FThermometerLevel
	{
		public int level;

		public float fillAmount;

		public Color bottomColor;

		public Color topColor;

		public Color numberColor;
	}

	[SerializeField]
	private Image thermometerImage;

	[SerializeField]
	private FThermometerLevel[] thermometerLevels;

	[SerializeField]
	private TextMeshProUGUI totalSnowfallText;

	private Tween fillTween;

	private Tween bottomColorTween;

	private Tween topColorTween;

	private Tween textTween;

	private bool isInitialized;

	public void SetLevel(int level)
	{
		FThermometerLevel? fThermometerLevel = thermometerLevels.First((FThermometerLevel x) => x.level == level);
		if (fThermometerLevel.HasValue)
		{
			float duration = (isInitialized ? 1f : 0f);
			isInitialized = true;
			if (fillTween != null)
			{
				fillTween.Kill();
			}
			if (bottomColorTween != null)
			{
				bottomColorTween.Kill();
			}
			if (topColorTween != null)
			{
				topColorTween.Kill();
			}
			if (textTween != null)
			{
				textTween.Kill();
			}
			fillTween = thermometerImage.DOFillAmount(fThermometerLevel.Value.fillAmount, duration).SetEase(Ease.OutCubic);
			bottomColorTween = thermometerImage.material.DOColor(fThermometerLevel.Value.bottomColor, "_ColorA", duration).SetEase(Ease.InOutCubic);
			topColorTween = thermometerImage.material.DOColor(fThermometerLevel.Value.topColor, "_ColorB", duration).SetEase(Ease.InOutCubic);
			textTween = totalSnowfallText.DOColor(fThermometerLevel.Value.numberColor, duration).SetEase(Ease.InOutCubic);
		}
	}
}
