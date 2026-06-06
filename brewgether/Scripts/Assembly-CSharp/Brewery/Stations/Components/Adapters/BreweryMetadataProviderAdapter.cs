using System;
using Brewery.Items;
using Brewery.Stations.Components.Interfaces;
using Brewery.Systems;
using Brewery.Systems.Processing;

namespace Brewery.Stations.Components.Adapters
{
	public sealed class BreweryMetadataProviderAdapter : IMetadataProvider
	{
		private readonly BreweryMetadataManager metadataManager;

		public BreweryMetadataProviderAdapter(BreweryMetadataManager metadataManager)
		{
		}

		public BreweryMetadataProviderAdapter()
		{
		}

		public ProcessMetadata<TStep> GetProcessMetadata<TStep>(ulong stationId, string key) where TStep : struct, Enum
		{
			return default(ProcessMetadata<TStep>);
		}

		public bool TryGetProcessMetadata<TStep>(ulong stationId, string key, out ProcessMetadata<TStep> metadata) where TStep : struct, Enum
		{
			metadata = default(ProcessMetadata<TStep>);
			return false;
		}

		public void SaveProcessMetadata<TStep>(ulong stationId, string key, ProcessMetadata<TStep> metadata) where TStep : struct, Enum
		{
		}

		public bool TryGetBarrelMetadata(ulong ownerId, int slotIndex, InventoryType type, out BarrelMetadata metadata)
		{
			metadata = default(BarrelMetadata);
			return false;
		}

		public void SetBarrelMetadata(ulong ownerId, int slotIndex, InventoryType type, BarrelMetadata metadata)
		{
		}

		public void RemoveBarrelMetadata(ulong ownerId, int slotIndex, InventoryType type)
		{
		}
	}
}
