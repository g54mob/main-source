using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UI_NewGameButton : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CTSButton _button;

		[InjectScope(EGetScope.Singleton)]
		[Inject(false)]
		private UI_ProfileManager _profileManager;

		protected override void OnAwake()
		{
			base.OnAwake();
			_button.onClick.AddListener(OnButtonClicked);
		}

		private void OnButtonClicked()
		{
			_profileManager.PlayOrShowProfiles();
		}
	}
}
