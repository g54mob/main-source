using System;

namespace Services.Save.Assemble
{
	[Serializable]
	public struct PartSaveData
	{
		public bool Placed;

		public bool Tightened;

		public float Progress;
	}
}
