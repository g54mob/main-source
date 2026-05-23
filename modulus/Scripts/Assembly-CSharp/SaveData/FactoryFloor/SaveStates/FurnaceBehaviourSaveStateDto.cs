using System;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class FurnaceBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public bool HasCube;

		public int VoxelCount;

		public int PolyRockCount;
	}
}
