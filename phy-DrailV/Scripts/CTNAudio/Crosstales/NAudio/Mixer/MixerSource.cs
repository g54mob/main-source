using System;
using System.Runtime.InteropServices;

namespace Crosstales.NAudio.Mixer
{
	public class MixerSource
	{
		private MixerInterop.MIXERLINE mixerLine;

		private IntPtr mixerHandle;

		public string Name => mixerLine.szName;

		public string ShortName => mixerLine.szShortName;

		public int ControlsCount => mixerLine.cControls;

		public int Channels => mixerLine.cChannels;

		public string TypeDescription
		{
			get
			{
				_ = mixerLine;
				return "Invalid";
			}
		}

		public MixerSource(IntPtr mixerHandle, int nDestination, int nSource)
		{
			mixerLine = default(MixerInterop.MIXERLINE);
			mixerLine.cbStruct = Marshal.SizeOf((object)mixerLine);
			mixerLine.dwDestination = nDestination;
			mixerLine.dwSource = nSource;
			this.mixerHandle = mixerHandle;
		}

		public MixerControl GetControl(int nControl)
		{
			if (nControl < 0 || nControl >= ControlsCount)
			{
				throw new ArgumentOutOfRangeException("nControl");
			}
			return MixerControl.GetMixerControl(mixerHandle, mixerLine.dwLineID, nControl, Channels, MixerFlags.Mixer);
		}
	}
}
