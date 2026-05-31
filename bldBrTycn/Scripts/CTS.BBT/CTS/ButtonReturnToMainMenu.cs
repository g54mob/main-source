using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class ButtonReturnToMainMenu : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Button _button;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_button.onClick.AddListener(OnButtonClick);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_button.onClick.RemoveListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			if (MonoSingleton<MenusManager>.TryGetInstance(out var outInstance))
			{
				outInstance.ShowMainMenu();
			}
		}
	}
}
