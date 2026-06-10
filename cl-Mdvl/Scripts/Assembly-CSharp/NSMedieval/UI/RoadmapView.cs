using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class RoadmapView : ClosableUIView
	{
		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private TMP_Text text;

		private void Start()
		{
			closeButton.onClick.AddListener(CloseSelf);
		}

		public override void Show()
		{
			base.Show();
			text.SetText(MonoSingleton<LocalizationController>.Instance.GetText("early_acces_note"));
		}
	}
}
