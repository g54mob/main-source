using System;

namespace Brewery.Minigames
{
	[Serializable]
	public struct ControlDefinition
	{
		public string name;

		public string id;

		public ControlType type;

		public float minValue;

		public float maxValue;

		public float defaultValue;

		public float inertia;

		public float toggleCooldown;

		public float buttonLockout;

		public int detents;

		public float maxTurns;

		public float[] clunkPositions;

		public ControlEffect[] effects;

		public string hint;

		public bool isPrimary;
	}
}
