using System;
using System.Collections.Generic;
using Data.FactoryFloor.Resources;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class TunnelBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public ResourceDto OutputResource;

		public List<ResourceDto> Resources;

		public List<uint> ExitOnUpdates;

		public uint CurrentUpdate;
	}
}
