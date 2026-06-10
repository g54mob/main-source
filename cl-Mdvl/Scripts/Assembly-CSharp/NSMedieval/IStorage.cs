using System;
using System.Collections.Generic;
using NSEipix.Model;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Stockpiles;

namespace NSMedieval
{
	public interface IStorage : IGameDisposable, IDisposable, IGoapTargetable
	{
		string StorageName { get; }

		ResourcesFilter ResourcesFilter { get; }

		string ObjectId { get; }

		List<ResourceGroups> DefaultResourceGroups { get; }

		float RefillPercentageThreshold { get; }

		ZonePriority Priority { get; }

		bool AnimalFeeder { get; }

		bool PrisonFeeder { get; }

		bool Underwater { get; }

		bool IsOnFire { get; }

		bool IsPlayerOwned { get; }

		bool CanBeUsedInProduction { get; }

		void AllowResource(Resource resource, bool allowed);

		void SetHitPointsPercent(IntRange range);

		void SetQuality(IntRange range);

		void SetCanBeUsedInProduction(bool allowed);

		void SetName(string name);

		bool IsBlueprintAllowed(Resource blueprint);

		void SetPriority(ZonePriority priority);

		List<ResourcePileInstance> GetStoredPiles();

		bool CanStore(ResourceInstance resource, CreatureBase creatureBase = null);

		void PasteStorageSettings(IStorage original);

		bool ContainsPile(ResourcePileInstance pile);

		bool ReserveStorage(ResourceInstance resource, CreatureBase agent, out SimpleResourceCount storedAmount, out Vec3Int position);

		void ReleaseReservations(CreatureBase agent);
	}
}
