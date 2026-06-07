using System;

namespace LocoSim.Definitions
{
	[Serializable]
	public class FuseDefinition
	{
		public string id;

		public bool initialState;

		public float offValue;

		public FuseDefinition(string id, bool initialState, float offValue = 0f)
		{
			this.id = id;
			this.initialState = initialState;
			this.offValue = offValue;
		}
	}
}
