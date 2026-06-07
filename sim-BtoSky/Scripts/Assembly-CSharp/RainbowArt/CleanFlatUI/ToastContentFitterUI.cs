using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ToastContentFitterUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private ToastContentFitter toast;

		private void Start()
		{
			toast.gameObject.SetActive(value: false);
			button.onClick.AddListener(OnButtonClick);
		}

		public void OnButtonClick()
		{
			toast.ShowToast();
		}
	}
}
