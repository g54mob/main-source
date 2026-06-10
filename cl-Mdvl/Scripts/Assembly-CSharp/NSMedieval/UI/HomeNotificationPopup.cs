using NSEipix.View.UI;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class HomeNotificationPopup : ClosableUIView
	{
		private static bool shown;

		[SerializeField]
		private bool showNotificationOnStart;

		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private SoundButton confirmButton;

		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private TMP_Text description;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			shown = false;
		}

		public override void Show()
		{
			if (!shown && showNotificationOnStart)
			{
				shown = true;
				closeButton.onClick.AddListener(delegate
				{
					OnButtonClose();
				});
				confirmButton.onClick.AddListener(delegate
				{
					OnButtonClose();
				});
				base.Show();
			}
		}

		private void OnButtonClose()
		{
			Hide();
		}
	}
}
