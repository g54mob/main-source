using System;

namespace NAudio.Mixer
{
	public class BooleanMixerControl : MixerControl
	{
		private MixerInterop.MIXERCONTROLDETAILS_BOOLEAN boolDetails;

		public bool Value
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal BooleanMixerControl(MixerInterop.MIXERCONTROL mixerControl, IntPtr mixerHandle, MixerFlags mixerHandleType, int nChannels)
		{
		}

		protected override void GetDetails(IntPtr pDetails)
		{
		}
	}
}
