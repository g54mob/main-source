using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Static Behaviours/Back To Main Menu")]
	public class BackToMenuButton : ScriptableObject
	{
		public void ReturnToMainMenu()
		{
			if (MonoSingleton<MenusManager>.TryGetInstance(out var outInstance))
			{
				outInstance.ShowMainMenu();
			}
		}
	}
}
