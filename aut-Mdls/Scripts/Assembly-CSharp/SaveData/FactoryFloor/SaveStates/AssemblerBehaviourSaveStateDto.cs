using System;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Resources;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class AssemblerBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public const int CurrentVersion = 1;

		public InputBufferSaveData InputBufferSaveData;

		public bool HasAssembledShape;

		public ResourceDto AssembledShape;

		public Dictionary<int, int> ConfiguredShapeToInputBuffer;

		public bool NewColoredInputShapes;

		public AssemblerBehaviourSaveStateDto()
			: base(1)
		{
		}
	}
}
