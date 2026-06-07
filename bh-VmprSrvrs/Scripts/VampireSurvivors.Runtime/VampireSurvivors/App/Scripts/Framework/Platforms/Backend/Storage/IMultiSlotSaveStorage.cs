using System.Threading.Tasks;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage
{
	public interface IMultiSlotSaveStorage
	{
		Task<bool> SetSlotData(int slot, PlayerOptionsData value);

		Task<PlayerOptionsData> GetSlotData(int slot);

		Task<PlayerOptionsData> GetMergeConflictSlotData();
	}
}
