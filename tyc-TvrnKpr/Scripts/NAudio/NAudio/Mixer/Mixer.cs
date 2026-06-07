using System;
using System.Collections.Generic;

namespace NAudio.Mixer
{
	public class Mixer
	{
		private MixerInterop.MIXERCAPS caps;

		private IntPtr mixerHandle;

		private MixerFlags mixerHandleType;

		public static int NumberOfDevices => 0;

		public int DestinationCount => 0;

		public string Name => null;

		public Manufacturers Manufacturer => default(Manufacturers);

		public int ProductID => 0;

		public IEnumerable<MixerLine> Destinations => null;

		public static IEnumerable<Mixer> Mixers => null;

		public Mixer(int mixerIndex)
		{
		}

		public MixerLine GetDestination(int destinationIndex)
		{
			return null;
		}
	}
}
