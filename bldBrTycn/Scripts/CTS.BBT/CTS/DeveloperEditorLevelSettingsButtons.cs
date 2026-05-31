using CTS.BBT;
using CTS.Core;
using CTS.DevConsole;
using CTS.DevConsole.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class DeveloperEditorLevelSettingsButtons : MonoBehaviour
	{
		private int _indexToUnlockLevel;

		public void SetIndexUnlockLevel(int indexToUnlockLevel)
		{
			_indexToUnlockLevel = indexToUnlockLevel;
		}

		public void UnlockLevel()
		{
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is CareerProfile)
			{
				DeveloperConsole.ExecuteCommand<CommandUnlockLevel>(new string[1] { $"Level_{_indexToUnlockLevel + 1:D2}" });
			}
		}

		public void CleanUpJunks()
		{
			DeveloperConsole.ExecuteCommand<CommandClearJunk>(new string[1] { "all" });
		}

		public void PlaceAnywhere(Toggle value)
		{
			DeveloperConsole.ExecuteCommand<CommandPlaceAnywhere>(new string[1] { value.isOn ? "true" : "false" });
		}

		public void CustomersAutoLeave(Toggle value)
		{
			DeveloperConsole.ExecuteCommand<CommandAutoLeave>(new string[1] { value.isOn ? "true" : "false" });
		}

		public void EnableInvestigatorSpawn(Toggle value)
		{
			CTSSingleton<HostileCharacterSpawner>.Instance.enabled = value.isOn;
		}

		public void EnableVampireSpawn(Toggle value)
		{
			CTSSingleton<CustomerSpawner>.Instance.SpawnsVampires = value.isOn;
		}
	}
}
