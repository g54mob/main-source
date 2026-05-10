using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UIGifsHelpingButton : MonoBehaviour
	{
		[SerializeField]
		private UIGifsListSO _gifsWantedToShow;

		private CTSButton _button;

		private void Awake()
		{
			_button = GetComponent<CTSButton>();
			_button.onClick.AddListener(ShowingGifs);
		}

		public void ShowingGifs()
		{
			CTSSingleton<UIHelpingGifs>.Instance.ChooseHelpList(_gifsWantedToShow);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveAllListeners();
		}
	}
}
