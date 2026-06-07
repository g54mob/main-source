using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Jundroo.Common.Extensions;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menu.LevelMenuVR
{
	public class TooltipScript : MonoBehaviour
	{
		private bool _dismissed;

		private TweenerCore<float, float, FloatOptions> _showTween;

		public static TooltipScript Create(ShowTooltipScript source, string text, float delay = 0.5f)
		{
			GameObject gameObject = Object.Instantiate(Resources.Load("Menu/VR/Tooltip")) as GameObject;
			gameObject.SetActive(value: true);
			gameObject.transform.SetParent(source.transform, worldPositionStays: false);
			gameObject.GetComponent<RectTransform>().anchoredPosition3D = source.Offset;
			gameObject.GetComponentInChildren<TextMeshProUGUI>().text = text;
			Canvas canvas = gameObject.AddMissingComponent<Canvas>();
			canvas.overrideSorting = true;
			canvas.sortingOrder = 10;
			TooltipScript tooltipScript = gameObject.AddComponent<TooltipScript>();
			CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
			canvasGroup.alpha = 0f;
			tooltipScript._showTween = DOTween.To(() => canvasGroup.alpha, delegate(float x)
			{
				canvasGroup.alpha = x;
			}, 1f, 0.25f).SetDelay(delay);
			return tooltipScript;
		}

		public void Dismiss()
		{
			if (!_dismissed)
			{
				_showTween.Kill();
				_dismissed = true;
				CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
				float num = 0.25f;
				DOTween.To(() => canvasGroup.alpha, delegate(float x)
				{
					canvasGroup.alpha = x;
				}, 0f, num);
				Object.Destroy(base.gameObject, num);
			}
		}
	}
}
