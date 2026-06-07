using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ModalWindowProgressBarLoopUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private ModalWindowProgressBarLoop modalWindow;

		private IEnumerator updateCoroutine;

		public void Start()
		{
			modalWindow.gameObject.SetActive(value: false);
			button.onClick.AddListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			modalWindow.OnFinish.RemoveAllListeners();
			modalWindow.OnFinish.AddListener(ModalWindowFinish);
			modalWindow.ShowModalWindow();
			UpdateProgress();
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
			yield return new WaitForSeconds(2.5f);
			modalWindow.FinishProgress();
		}
	}
}
