using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	public interface IWorldRegion : IRegion
	{
		WorldTile WorldTile { get; }

		IReadOnlyList<IWorldRegion> Neighbors { get; }

		IReadOnlyList<LandmarkSpawner> Landmarks { get; }

		WorldRegionBorderSegment[] Border { get; }

		IRegion DataRegion { get; }

		WorldRegionFlags Flags { get; }

		WorldRegionTypeFlags TypeFlags { get; }

		void SetWorldTile(WorldTile worldTile);

		void PopulateDisabledLandmarkSpawners(List<LandmarkSpawner> disabledSpawners, ScoutingState maximumScoutingState);

		bool TryAddLandmarkSpawner(LandmarkSpawner landmarkSpawner);

		bool RemoveLandmarkSpawner(LandmarkSpawner landmarkSpawner);

		void Enter();

		void Scout(Agent agent, bool scoutNeighbors = true);

		bool StartQuest(AgentDescriptor interactor = null);

		void Restore(WorldRegionFlags flags);

		bool ReturnContainsPosition3D(Vector3 position);

		bool TryReturnDistanceToBorder(out float distance, Vector2 position, float margin = 0f);

		bool TryReturnScoutingLandmark(out LandmarkSpawner scoutingLandmark);

		IReadOnlyList<LandmarkSpawner> GetScoutingLandmarks(List<LandmarkSpawner> listToPopulate = null);

		bool IsFirstWithFlags(WorldRegionFlags flags);

		bool IsGeneratedFromDataRegion(IRegion region);

		bool HasUnscoutedDisabledLandmarks();
	}
}
