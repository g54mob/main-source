using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu
{
	public class ExitGame : MonoBehaviour
	{
		public void OnClick()
		{
			Application.Quit();
		}
	}
}
