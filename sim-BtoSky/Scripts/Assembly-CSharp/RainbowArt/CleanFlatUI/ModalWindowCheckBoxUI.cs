using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ModalWindowCheckBoxUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private ModalWindowCheckBox modalWindow;

		public void Start()
		{
			modalWindow.gameObject.SetActive(value: false);
			button.onClick.AddListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			modalWindow.OnConfirm.RemoveAllListeners();
			modalWindow.OnConfirm.AddListener(ModalWindowConfirm);
			modalWindow.OnCancel.RemoveAllListeners();
			modalWindow.OnCancel.AddListener(ModalWindowCancel);
			modalWindow.ShowModalWindow();
		}

		private void ModalWindowConfirm(int[] selectedIndexes)
		{
			Debug.Log("Confirm Button Clicked, index: ");
			foreach (int num in selectedIndexes)
			{
				Debug.Log(num + ",");
			}
		}

		private void ModalWindowCancel(int[] selectedIndexes)
		{
			Debug.Log("Cancel Button Clicked");
		}
	}
}
