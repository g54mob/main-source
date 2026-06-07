using System;
using System.Collections.Generic;

namespace NAudio.Mixer
{
	public class MixerLine
	{
		private MixerInterop.MIXERLINE mixerLine;

		private IntPtr mixerHandle;

		private MixerFlags mixerHandleType;

		public string Name => null;

		public string ShortName => null;

		public int LineId => 0;

		public MixerLineComponentType ComponentType => default(MixerLineComponentType);

		public string TypeDescription => null;

		public int Channels => 0;

		public int SourceCount => 0;

		public int ControlsCount => 0;

		public bool IsActive => false;

		public bool IsDisconnected => false;

		public bool IsSource => false;

		public IEnumerable<MixerControl> Controls => null;

		public IEnumerable<MixerLine> Sources => null;

		public string TargetName => null;

		public MixerLine(IntPtr mixerHandle, int destinationIndex, MixerFlags mixerHandleType)
		{
		}

		public MixerLine(IntPtr mixerHandle, int destinationIndex, int sourceIndex, MixerFlags mixerHandleType)
		{
		}

		public static int GetMixerIdForWaveIn(int waveInDevice)
		{
			return 0;
		}

		public MixerLine GetSource(int sourceIndex)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
