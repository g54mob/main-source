using System;
using Data.FactoryFloor;
using Data.FactoryFloor.Resources;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class MonotonerBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public InputBufferSaveData InputBufferSaveData;

		public bool HasPaintedShape;

		public ResourceDto PaintedShapeDto;
	}
}
