using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ModalWindowRadioButtonUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private ModalWindowRadioButton modalWindow;

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

		private void ModalWindowConfirm(int index)
		{
			Debug.Log("Confirm Button Clicked, index:" + index);
		}

		private void ModalWindowCancel(int index)
		{
			Debug.Log("Cancel Button Clicked");
		}
	}
}
