using System;
using System.Collections.Generic;
using NSMedieval.Components;
using NSMedieval.Enums;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Construction
{
	public interface IConstructable : IGameDisposable, IDisposable, IReservable, IForbidable
	{
		Vec3Int GridDataPosition { get; }

		List<Vec3Int> Positions { get; }

		Vec3Int Size { get; }

		float RemainingTime { get; }

		ConstructionPhase ConstructionPhase { get; }

		bool IsMoveBlueprint { get; }

		bool MarkedForUninstall { get; }

		bool MarkedForMoving { get; }

		BuildingType BuildingType { get; }

		Storage Storage { get; }

		bool MarkedForDestruction { get; }

		bool Reachable { get; set; }

		bool ResourcesAvailable { get; set; }

		bool SkilledConstructionWorkerExists { get; set; }

		float RotateMeshVariation { get; }

		StatsInstance Stats { get; }

		BuildingOwnershipInfo BuildingOwnershipInfo { get; }

		event Action<float> TimeRemainingEvent;

		Vector3 GetPosition();

		void SetMarkedForDestruction(bool value);

		void CancelUninstall();

		float GetAngle();
	}
}
