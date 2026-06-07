using UnityEngine;

namespace DV.UserManagement.Integration
{
	public abstract class AGameModeProvider : ScriptableObject
	{
		public abstract string[] GetGameModes();

		public abstract string GetLocalizationKey(string gameMode);
	}
}
