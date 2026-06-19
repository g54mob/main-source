using System.Collections;
using FMODUnity;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Aggro.Core
{
	public sealed class AggroSettingGeneralUI : MonoBehaviour
	{
		public TextMeshProUGUI labelText;

		public CanvasGroup canvasGroup;

		public Selectable selectable;

		[Space]
		public EventReference sfxShow;

		private AggroSettingBase _setting;

		internal void Set(AggroSettingBase setting)
		{
			_setting = setting;
			Refresh();
		}

		internal void Refresh()
		{
			if (AggroSettings.isLocalizing)
			{
				labelText.text = LocalizedText.GetText(_setting.label, printDebug: false);
			}
			else
			{
				labelText.text = _setting.label;
			}
		}

		public void PrepareForShow()
		{
			canvasGroup.alpha = 0f;
			StopAllCoroutines();
		}

		internal void Show(float duration, EasingFunction.Ease ease)
		{
			StartCoroutine(ShowCo(duration, ease));
		}

		private IEnumerator ShowCo(float duration, EasingFunction.Ease ease)
		{
			AggroUtil.PlaySfxIfValid(sfxShow);
			float time = 0f;
			while (time < duration)
			{
				yield return null;
				time += Time.unscaledDeltaTime;
				canvasGroup.alpha = EasingFunction.Evaluate(ease, 0f, 1f, math.saturate(time / duration));
			}
		}
	}
}
