using System;

namespace NAudio.Mixer
{
	public class CustomMixerControl : MixerControl
	{
		internal CustomMixerControl(MixerInterop.MIXERCONTROL mixerControl, IntPtr mixerHandle, MixerFlags mixerHandleType, int nChannels)
		{
		}

		protected override void GetDetails(IntPtr pDetails)
		{
		}
	}
}
