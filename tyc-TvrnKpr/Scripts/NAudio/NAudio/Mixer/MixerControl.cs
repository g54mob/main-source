using System;
using System.Collections.Generic;

namespace NAudio.Mixer
{
	public abstract class MixerControl
	{
		internal MixerInterop.MIXERCONTROL mixerControl;

		internal MixerInterop.MIXERCONTROLDETAILS mixerControlDetails;

		protected IntPtr mixerHandle;

		protected int nChannels;

		protected MixerFlags mixerHandleType;

		public string Name => null;

		public MixerControlType ControlType => default(MixerControlType);

		public bool IsBoolean => false;

		public bool IsListText => false;

		public bool IsSigned => false;

		public bool IsUnsigned => false;

		public bool IsCustom => false;

		public static IList<MixerControl> GetMixerControls(IntPtr mixerHandle, MixerLine mixerLine, MixerFlags mixerHandleType)
		{
			return null;
		}

		public static MixerControl GetMixerControl(IntPtr mixerHandle, int nLineID, int controlId, int nChannels, MixerFlags mixerFlags)
		{
			return null;
		}

		protected void GetControlDetails()
		{
		}

		protected abstract void GetDetails(IntPtr pDetails);

		private static bool IsControlBoolean(MixerControlType controlType)
		{
			return false;
		}

		private static bool IsControlListText(MixerControlType controlType)
		{
			return false;
		}

		private static bool IsControlSigned(MixerControlType controlType)
		{
			return false;
		}

		private static bool IsControlUnsigned(MixerControlType controlType)
		{
			return false;
		}

		private static bool IsControlCustom(MixerControlType controlType)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
