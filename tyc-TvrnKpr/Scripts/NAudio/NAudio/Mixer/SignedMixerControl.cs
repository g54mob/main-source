using System;

namespace NAudio.Mixer
{
	public class SignedMixerControl : MixerControl
	{
		private MixerInterop.MIXERCONTROLDETAILS_SIGNED signedDetails;

		public int Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int MinValue => 0;

		public int MaxValue => 0;

		public double Percent
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		internal SignedMixerControl(MixerInterop.MIXERCONTROL mixerControl, IntPtr mixerHandle, MixerFlags mixerHandleType, int nChannels)
		{
		}

		protected override void GetDetails(IntPtr pDetails)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
