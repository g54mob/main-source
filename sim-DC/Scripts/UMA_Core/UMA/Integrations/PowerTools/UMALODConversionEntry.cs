using System;

namespace UMA.Integrations.PowerTools
{
	[Serializable]
	public class UMALODConversionEntry
	{
		public enum ConversionGroup
		{
			SlotData = 0,
			OverlayData = 1,
			RaceData = 2
		}

		public string SourcePieceName;

		public string DestinationPieceName;

		public int LODLevel;

		public int groupInt;

		public ConversionGroup group
		{
			get
			{
				return default(ConversionGroup);
			}
			set
			{
			}
		}
	}
}
