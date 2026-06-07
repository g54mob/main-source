using CTS.BBT;
using CTS.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS
{
	[CreateAssetMenu(fileName = "DialogueMainMenu", menuName = "BBT/DialogueMainMenu")]
	public class DialogueMainMenu : ScriptableObject
	{
		public void ReturnToMainMenu()
		{
			if (MonoSingleton<TimeController>.TryGetInstance(out var outInstance))
			{
				outInstance.TimeMode = ETimeModes.Pause;
			}
			if (!MonoSingleton<MenusManager>.Instance)
			{
				SceneManager.LoadScene(0);
			}
			else
			{
				MonoSingleton<MenusManager>.Instance.ShowMainMenu();
			}
		}
	}
}
