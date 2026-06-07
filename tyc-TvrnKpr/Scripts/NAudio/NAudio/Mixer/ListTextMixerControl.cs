using System;

namespace NAudio.Mixer
{
	public class ListTextMixerControl : MixerControl
	{
		internal ListTextMixerControl(MixerInterop.MIXERCONTROL mixerControl, IntPtr mixerHandle, MixerFlags mixerHandleType, int nChannels)
		{
		}

		protected override void GetDetails(IntPtr pDetails)
		{
		}
	}
}
