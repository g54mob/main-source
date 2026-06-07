using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Data
{
	[Serializable]
	public struct CatalystPlayerStats : INetworkSerializable
	{
		public int totalBrewsCreated;

		public float totalValueGenerated;

		public int totalLegendariesAchieved;

		public int beerBrewsCreated;

		public int wineBrewsCreated;

		public int spiritsBrewsCreated;

		public FixedString32Bytes mostUsedCatalyst1Id;

		public int mostUsedCatalyst1Count;

		public FixedString32Bytes mostUsedCatalyst2Id;

		public int mostUsedCatalyst2Count;

		public FixedString32Bytes mostUsedCatalyst3Id;

		public int mostUsedCatalyst3Count;

		public FixedString32Bytes mostUsedCatalyst4Id;

		public int mostUsedCatalyst4Count;

		public FixedString32Bytes mostUsedCatalyst5Id;

		public int mostUsedCatalyst5Count;

		public int mostCreatedBrewDiscoveryId;

		public int mostCreatedBrewCount;

		public FixedString128Bytes mostCreatedBrewName;

		public int soldToCorporate;

		public int soldToWorkingClass;

		public int soldToPriests;

		public int soldToBikers;

		public int soldToPartyScene;

		public int totalDiscoveriesUnlocked;

		public int totalPossibleDiscoveries;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public float GetDiscoveryPercentage()
		{
			return 0f;
		}
	}
}
