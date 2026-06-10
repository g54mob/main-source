using System.Collections;
using NSEipix.View.UI;
using NSMedieval.Tutorial;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class TutorialTaskView : LayoutGroupItemView
	{
		[SerializeField]
		private CustomToggle toggle;

		[SerializeField]
		private TMP_Text label;

		[SerializeField]
		private Slider slider;

		[SerializeField]
		private Image backgroundImage;

		private TutorialStepTask tutorialStepTask;

		public void SetData(TutorialStepTask task)
		{
			tutorialStepTask = task;
			UpdateLabel();
			slider.value = 0f;
			toggle.SetIsOnWithoutNotify(value: false);
			tutorialStepTask.PercentCompleteChangeEvent += OnPercentCompleteChange;
			tutorialStepTask.TaskCompleteEvent += OnTaskComplete;
			tutorialStepTask.TaskSetActiveChangeEvent += UpdateLabel;
		}

		private void UpdateLabel()
		{
			string text = (tutorialStepTask.IsActive ? "Normal" : "DarkGray");
			label.SetText("<style=" + text + ">" + tutorialStepTask.GetName() + "</style>");
		}

		private void OnTaskComplete()
		{
			slider.value = 1f;
			toggle.SetIsOnWithoutNotify(value: true);
			StartCoroutine(OnTaskCompleteCoroutine());
			tutorialStepTask.PercentCompleteChangeEvent -= OnPercentCompleteChange;
			tutorialStepTask.TaskCompleteEvent -= OnTaskComplete;
		}

		private void OnPercentCompleteChange(float value)
		{
			slider.value = value;
		}

		private IEnumerator OnTaskCompleteCoroutine()
		{
			float fadeInDuration = 0.05f;
			float fadeOutDuration = 0.4f;
			float targetAlpha = 1f;
			float startAlpha = backgroundImage.color.a;
			float time = 0f;
			while (time < fadeInDuration)
			{
				time += Time.unscaledDeltaTime;
				float a = Mathf.Lerp(startAlpha, targetAlpha, time / fadeInDuration);
				backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, a);
				yield return null;
			}
			time = 0f;
			while (time < fadeOutDuration)
			{
				time += Time.unscaledDeltaTime;
				float a2 = Mathf.Lerp(targetAlpha, startAlpha, time / fadeOutDuration);
				backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, a2);
				yield return null;
			}
			backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, startAlpha);
		}
	}
}
