namespace Brewery.Minigames
{
	public struct ControlState
	{
		public float value;

		public bool isOn;

		public bool isLockedOut;

		public bool isActive;

		public float cooldownRemaining;

		public float lockoutRemaining;

		public float velocity;

		public bool[] fusePattern;

		public int[] patchConnections;

		public float[] patchExpiryTimers;

		public float cumulativeTurns;

		public bool isArmed;

		public static ControlState CreateDefault(ControlDefinition def)
		{
			return default(ControlState);
		}
	}
}
