using System.Threading.Tasks;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab
{
	public class PlayFabPlayerData : IPlayerDataStorage
	{
		public enum AllowedPlayerDataKeys
		{
			PASSED_DOB_GATE = 0,
			MERGE_CONFLICT_DATA = 1,
			SAVE_DATA_SLOT_1 = 2,
			LINK_ACCOUNT_VERIFICATION_TOKEN = 3,
			LINKED_CUSTOM_IDS = 4
		}

		public Task<bool> SetPlayerData(AllowedPlayerDataKeys key, string value)
		{
			return null;
		}

		public Task<string> GetPlayerData(AllowedPlayerDataKeys key)
		{
			return null;
		}
	}
}
