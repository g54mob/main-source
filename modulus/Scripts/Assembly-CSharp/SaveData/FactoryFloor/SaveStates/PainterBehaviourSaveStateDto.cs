using System;
using Data.FactoryFloor;
using Data.FactoryFloor.Resources;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class PainterBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public InputBufferSaveData InputBufferSaveData;

		public bool HasPaintedShape;

		public ResourceDto CurrentPaintedShape;
	}
}
