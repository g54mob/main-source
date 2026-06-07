using System.Threading.Tasks;
using BrewGame.SaveSystem.Core;

namespace BrewGame.SaveSystem.Storage
{
	public interface ISaveStorageProvider
	{
		string ProviderName { get; }

		bool IsAvailable { get; }

		Task<bool> SaveAsync(string profileId, int slotIndex, byte[] data);

		Task<byte[]> LoadAsync(string profileId, int slotIndex);

		Task<bool> DeleteAsync(string profileId, int slotIndex);

		Task<SaveSlotMetadata[]> GetAllSlotsMetadataAsync(string profileId);

		bool SlotExists(string profileId, int slotIndex);

		long GetSlotTimestamp(string profileId, int slotIndex);
	}
}
