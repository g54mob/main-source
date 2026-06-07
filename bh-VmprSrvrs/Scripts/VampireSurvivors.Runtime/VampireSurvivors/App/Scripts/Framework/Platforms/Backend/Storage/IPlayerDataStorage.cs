using System.Threading.Tasks;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage
{
	public interface IPlayerDataStorage
	{
		Task<bool> SetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys key, string value);

		Task<string> GetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys key);
	}
}
