using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ModalWindowInputFieldUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private ModalWindowInputField modalWindow;

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

		private void ModalWindowConfirm(string inputText)
		{
			Debug.Log("Confirm Button Clicked, text:" + inputText);
		}

		private void ModalWindowCancel(string inputText)
		{
			Debug.Log("Cancel Button Clicked");
		}
	}
}
