using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.DreamOS
{
	public class BSODManager : MonoBehaviour
	{
		[Serializable]
		public class StepItem
		{
			[Range(0f, 100f)]
			public int progress;

			[Range(0f, 10f)]
			public int duration;

			public UnityEvent onStepChanged;
		}

		[SerializeField]
		private List<StepItem> steps = new List<StepItem>();

		[SerializeField]
		private GameObject BSODScreen;

		[SerializeField]
		private Canvas targetCanvas;

		public UnityEvent onCrashStart;

		public UnityEvent onCrashEnd;

		public string progressText = "% complete";

		private BSODScreen generatedScreen;

		private int currentStep;

		private int currentProgress;

		public void CreateBSOD(string errorID)
		{
			if (!(generatedScreen != null))
			{
				if (targetCanvas == null)
				{
					targetCanvas = base.gameObject.GetComponentInParent<Canvas>();
				}
				onCrashStart.Invoke();
				GameObject gameObject = UnityEngine.Object.Instantiate(BSODScreen, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(targetCanvas.transform, worldPositionStays: false);
				gameObject.transform.SetAsLastSibling();
				generatedScreen = gameObject.GetComponent<BSODScreen>();
				if (generatedScreen.errorText != null)
				{
					generatedScreen.errorText.text = errorID;
				}
				generatedScreen.progressText.text = $"{currentProgress}{progressText}";
				StartCoroutine(StoryTellerHelper(steps[0].duration));
			}
		}

		private IEnumerator StoryTellerHelper(float timer)
		{
			yield return new WaitForSeconds(timer);
			if (currentStep <= steps.Count - 1)
			{
				generatedScreen.progressText.text = $"{steps[currentStep].progress}{progressText}";
				StartCoroutine(StoryTellerHelper(steps[currentStep].duration));
				currentStep++;
			}
			else
			{
				currentStep = 0;
				targetCanvas.gameObject.SetActive(value: false);
				targetCanvas.gameObject.SetActive(value: true);
				UnityEngine.Object.Destroy(generatedScreen.gameObject);
				onCrashEnd.Invoke();
			}
		}
	}
}
