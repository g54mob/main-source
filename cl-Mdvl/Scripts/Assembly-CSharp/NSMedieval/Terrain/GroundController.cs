using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.State;

namespace NSMedieval.Terrain
{
	public class GroundController : MonoSingleton<GroundController>
	{
		public event Action<Vec3Int> OnGroundDestroyedSingleEvent;

		public event Action<List<Vec3Int>> OnGroundDestroyedEvent;

		public event Action<BaseBuildingInstance> VoxelAddedEvent;

		public event Action<BaseBuildingInstance> NewVoxelSavedEvent;

		public event Action<Vec3Int> OnPlayStabilityZeroGroundParticlesEvent;

		public event Action<DigMarkerResourceInstance> OnPlayDugHoleGroundParticles;

		private GroundController()
		{
		}

		public void GroundDestroyed(Vec3Int position)
		{
			this.OnGroundDestroyedSingleEvent?.Invoke(position);
		}

		public void GroundDestroyed(List<Vec3Int> positions)
		{
			this.OnGroundDestroyedEvent?.Invoke(positions);
		}

		public void PlayStabilityZeroGroundParticles(Vec3Int position)
		{
			this.OnPlayStabilityZeroGroundParticlesEvent?.Invoke(position);
		}

		public void PlayDugHoleGroundParticles(DigMarkerResourceInstance digMarkerResourceInstance)
		{
			this.OnPlayDugHoleGroundParticles?.Invoke(digMarkerResourceInstance);
		}

		public void AddVoxel(BaseBuildingInstance voxelInstance)
		{
			this.VoxelAddedEvent?.Invoke(voxelInstance);
		}

		public void NewVoxelSaved(BaseBuildingInstance voxelInstance)
		{
			this.NewVoxelSavedEvent?.Invoke(voxelInstance);
		}
	}
}
