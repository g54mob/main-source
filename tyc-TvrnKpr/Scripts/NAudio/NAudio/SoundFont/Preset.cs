namespace NAudio.SoundFont
{
	public class Preset
	{
		private string name;

		private ushort patchNumber;

		private ushort bank;

		internal ushort startPresetZoneIndex;

		internal ushort endPresetZoneIndex;

		internal uint library;

		internal uint genre;

		internal uint morphology;

		private Zone[] zones;

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ushort PatchNumber
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ushort Bank
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Zone[] Zones
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override string ToString()
		{
			return null;
		}
	}
}
