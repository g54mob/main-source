using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class LoadTutorialSave : MonoBehaviour
	{
		public void OnClick()
		{
			SaveManager.StartEmptyGame(EGameMode.Tutorial);
		}
	}
}
