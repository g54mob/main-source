namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal abstract class LowLevelEvent
	{
		public uint id;

		public float timestamp;

		private static uint HKjFGdTOPNuvUDFlCBESLrKDETt;

		protected static uint GetNextId()
		{
			if (HKjFGdTOPNuvUDFlCBESLrKDETt == uint.MaxValue)
			{
				HKjFGdTOPNuvUDFlCBESLrKDETt = 0u;
				return uint.MaxValue;
			}
			return ++HKjFGdTOPNuvUDFlCBESLrKDETt;
		}
	}
}
