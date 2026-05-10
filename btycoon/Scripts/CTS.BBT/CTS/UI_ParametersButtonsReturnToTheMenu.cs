using System;
using CTS.Core;
using UnityEngine.UI;

namespace CTS
{
	public class UI_ParametersButtonsReturnToTheMenu : InterfaceButton
	{
		private Button _thisButton;

		public static event Action ReturnToMainMenu;

		protected override void Awake()
		{
			base.Awake();
			_thisButton = GetComponent<Button>();
			_thisButton.onClick.AddListener(delegate
			{
				ReturnToTheMenu();
			});
		}

		private void ReturnToTheMenu()
		{
			MonoSingleton<UI_PauseMenu>.Instance.BackToMainMenu();
			UI_ParametersButtonsReturnToTheMenu.ReturnToMainMenu?.Invoke();
		}
	}
}
