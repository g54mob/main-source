using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ModalWindowProgressBarUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private ModalWindowProgressBar modalWindow;

		private IEnumerator updateCoroutine;

		public void Start()
		{
			modalWindow.gameObject.SetActive(value: false);
			button.onClick.AddListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			modalWindow.OnCancel.RemoveAllListeners();
			modalWindow.OnCancel.AddListener(ModalWindowCancel);
			modalWindow.OnFinish.RemoveAllListeners();
			modalWindow.OnFinish.AddListener(ModalWindowFinish);
			modalWindow.ShowModalWindow();
			UpdateProgress();
		}

		private void ModalWindowCancel()
		{
			if (updateCoroutine != null)
			{
				StopCoroutine(updateCoroutine);
				updateCoroutine = null;
			}
			Debug.Log("Cancel");
		}

		private void ModalWindowFinish()
		{
			Debug.Log("Finish");
		}

		private void UpdateProgress()
		{
			if (updateCoroutine != null)
			{
				StopCoroutine(updateCoroutine);
				updateCoroutine = null;
			}
			updateCoroutine = UpdateTransition();
			StartCoroutine(updateCoroutine);
		}

		private IEnumerator UpdateTransition()
		{
			float curProgress = 0f;
			float maxProgress = 100f;
			while (curProgress <= maxProgress)
			{
				modalWindow.SetProgress(curProgress);
				curProgress += 1f;
				yield return new WaitForSeconds(0.1f);
			}
			modalWindow.FinishProgress();
		}
	}
}
