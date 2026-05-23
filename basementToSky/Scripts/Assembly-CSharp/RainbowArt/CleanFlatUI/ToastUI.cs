using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ToastUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private Toast toast;

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
