using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ModalWindowContentFitterUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private ModalWindowContentFitter modalWindow;

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

		private void ModalWindowConfirm()
		{
			Debug.Log("Confirm Button Clicked");
		}

		private void ModalWindowCancel()
		{
			Debug.Log("Cancel Button Clicked");
		}
	}
}
