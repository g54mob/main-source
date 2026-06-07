using System;

namespace NAudio.Mixer
{
	public class UnsignedMixerControl : MixerControl
	{
		private MixerInterop.MIXERCONTROLDETAILS_UNSIGNED[] unsignedDetails;

		public uint Value
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint MinValue => 0u;

		public uint MaxValue => 0u;

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

		internal UnsignedMixerControl(MixerInterop.MIXERCONTROL mixerControl, IntPtr mixerHandle, MixerFlags mixerHandleType, int nChannels)
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
