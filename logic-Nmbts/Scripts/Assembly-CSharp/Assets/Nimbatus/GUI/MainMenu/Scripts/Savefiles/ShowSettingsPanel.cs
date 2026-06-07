using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles
{
	public class ShowSettingsPanel : MonoBehaviour
	{
		public StartGameUI StartGameUi;

		private void OnClick()
		{
			StartGameUi.ShowSettings();
		}
	}
}
