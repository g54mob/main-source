using System;
using System.Collections.Generic;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.StorageUniversal;

namespace NSMedieval
{
	internal interface IStorageBuilding : IStorage, IGameDisposable, IDisposable, IGoapTargetable
	{
		List<UniversalStorage> AllStorage { get; }

		HashSet<Vec3Int> ReachablePositions { get; }
	}
}
