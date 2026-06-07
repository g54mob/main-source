using System;

namespace Brewery.Minigames
{
	[Serializable]
	public struct ControlPanelEventDef
	{
		public ControlPanelEventType type;

		public float duration;

		public int targetControlIndex;

		public float[] meterInstantDeltas;

		public float[] meterDriftMultipliers;

		public string displayName;
	}
}
