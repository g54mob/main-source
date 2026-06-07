using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class ShowVersionNumber : MonoBehaviour
	{
		public UILabel Label;

		public void Update()
		{
			Label.text = LocalizationManager.GetTranslation("MainMenu/Version") + SaveManager.CurrentGameVersion;
		}
	}
}
