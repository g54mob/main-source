using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ModalWindowMultiButtonUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private ModalWindowMultiButton modalWindow;

		public void Start()
		{
			modalWindow.gameObject.SetActive(value: false);
			button.onClick.AddListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			modalWindow.OnFirst.RemoveAllListeners();
			modalWindow.OnFirst.AddListener(ModalWindowFirst);
			modalWindow.OnSecond.RemoveAllListeners();
			modalWindow.OnSecond.AddListener(ModalWindowSecond);
			modalWindow.OnThird.RemoveAllListeners();
			modalWindow.OnThird.AddListener(ModalWindowThird);
			modalWindow.OnCancel.RemoveAllListeners();
			modalWindow.OnCancel.AddListener(ModalWindowCancel);
			modalWindow.ShowModalWindow();
		}

		private void ModalWindowFirst()
		{
			Debug.Log("First Button Clicked");
		}

		private void ModalWindowSecond()
		{
			Debug.Log("Second Button Clicked");
		}

		private void ModalWindowThird()
		{
			Debug.Log("Third Button Clicked");
		}

		private void ModalWindowCancel()
		{
			Debug.Log("Cancel Button Clicked");
		}
	}
}
