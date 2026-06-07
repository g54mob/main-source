using System;
using Brewery.Items;
using Brewery.Systems;
using Brewery.Systems.Processing;

namespace Brewery.Stations.Components.Interfaces
{
	public interface IMetadataProvider
	{
		ProcessMetadata<TStep> GetProcessMetadata<TStep>(ulong stationId, string key) where TStep : struct, Enum;

		bool TryGetProcessMetadata<TStep>(ulong stationId, string key, out ProcessMetadata<TStep> metadata) where TStep : struct, Enum;

		void SaveProcessMetadata<TStep>(ulong stationId, string key, ProcessMetadata<TStep> metadata) where TStep : struct, Enum;

		bool TryGetBarrelMetadata(ulong ownerId, int slotIndex, InventoryType type, out BarrelMetadata metadata);

		void SetBarrelMetadata(ulong ownerId, int slotIndex, InventoryType type, BarrelMetadata metadata);

		void RemoveBarrelMetadata(ulong ownerId, int slotIndex, InventoryType type);
	}
}
