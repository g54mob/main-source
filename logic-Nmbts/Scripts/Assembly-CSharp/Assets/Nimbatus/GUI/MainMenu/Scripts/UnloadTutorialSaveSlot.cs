using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class UnloadTutorialSaveSlot : MonoBehaviour
	{
		public void OnClick()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.Menu)
			{
				if (Object.FindObjectOfType<MainMenuNavigator>() != null)
				{
					Invoke("OnTweenFinished", 0.5f);
				}
				else
				{
					OnTweenFinished();
				}
			}
			else
			{
				OnTweenFinished();
			}
		}

		public void OnTweenFinished()
		{
			SaveManager.Reset();
		}
	}
}
