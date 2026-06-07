using System;
using System.Runtime.InteropServices;

namespace NAudio.Mixer
{
	internal class MixerInterop
	{
		[StructLayout((LayoutKind)0, CharSet = CharSet.Auto, Pack = 1, Size = 32)]
		public struct MIXERCONTROLDETAILS
		{
			public int cbStruct;

			public int dwControlID;

			public int cChannels;

			public IntPtr hwndOwner;

			public int cbDetails;

			public IntPtr paDetails;
		}

		[StructLayout((LayoutKind)0, Pack = 1, Size = 48)]
		public struct MIXERCAPS
		{
			public ushort wMid;

			public ushort wPid;

			public uint vDriverVersion;

			public string szPname;

			public uint fdwSupport;

			public uint cDestinations;
		}

		[StructLayout((LayoutKind)0, Pack = 1, Size = 28)]
		public struct MIXERLINECONTROLS
		{
			public int cbStruct;

			public int dwLineID;

			public int dwControlID;

			public int cControls;

			public int cbmxctrl;

			public IntPtr pamxctrl;
		}

		[Flags]
		public enum MIXERLINE_LINEF
		{
			MIXERLINE_LINEF_ACTIVE = 1,
			MIXERLINE_LINEF_DISCONNECTED = 0x8000,
			MIXERLINE_LINEF_SOURCE = -2147483648
		}

		[StructLayout((LayoutKind)0, Pack = 1, Size = 172)]
		public struct MIXERLINE
		{
			public int cbStruct;

			public int dwDestination;

			public int dwSource;

			public int dwLineID;

			public MIXERLINE_LINEF fdwLine;

			public IntPtr dwUser;

			public MixerLineComponentType dwComponentType;

			public int cChannels;

			public int cConnections;

			public int cControls;

			public string szShortName;

			public string szName;

			public uint dwType;

			public uint dwDeviceID;

			public ushort wMid;

			public ushort wPid;

			public uint vDriverVersion;

			public string szPname;
		}

		[StructLayout((LayoutKind)0, Pack = 1, Size = 24)]
		public struct Bounds
		{
			public int minimum;

			public int maximum;

			public int reserved2;

			public int reserved3;

			public int reserved4;

			public int reserved5;
		}

		[StructLayout((LayoutKind)0, Pack = 1, Size = 24)]
		public struct Metrics
		{
			public int step;

			public int customData;

			public int reserved2;

			public int reserved3;

			public int reserved4;

			public int reserved5;
		}

		[StructLayout((LayoutKind)0, Pack = 1, Size = 148)]
		public struct MIXERCONTROL
		{
			public uint cbStruct;

			public int dwControlID;

			public MixerControlType dwControlType;

			public uint fdwControl;

			public uint cMultipleItems;

			public string szShortName;

			public string szName;

			public Bounds Bounds;

			public Metrics Metrics;
		}

		public struct MIXERCONTROLDETAILS_BOOLEAN
		{
			public int fValue;
		}

		public struct MIXERCONTROLDETAILS_SIGNED
		{
			public int lValue;
		}

		[StructLayout((LayoutKind)0, Pack = 1, Size = 72)]
		public struct MIXERCONTROLDETAILS_LISTTEXT
		{
			public uint dwParam1;

			public uint dwParam2;

			public string szName;
		}

		public struct MIXERCONTROLDETAILS_UNSIGNED
		{
			public uint dwValue;
		}

		public const uint MIXERCONTROL_CONTROLF_UNIFORM = 1u;

		public const uint MIXERCONTROL_CONTROLF_MULTIPLE = 2u;

		public const uint MIXERCONTROL_CONTROLF_DISABLED = 2147483648u;

		public const int MAXPNAMELEN = 32;

		public const int MIXER_SHORT_NAME_CHARS = 16;

		public const int MIXER_LONG_NAME_CHARS = 64;

		[PreserveSig]
		public static extern int mixerGetNumDevs();

		[PreserveSig]
		public static extern MmResult mixerOpen(out IntPtr hMixer, int uMxId, IntPtr dwCallback, IntPtr dwInstance, MixerFlags dwOpenFlags);

		[PreserveSig]
		public static extern MmResult mixerClose(IntPtr hMixer);

		[PreserveSig]
		public static extern MmResult mixerGetControlDetails(IntPtr hMixer, ref MIXERCONTROLDETAILS mixerControlDetails, MixerFlags dwDetailsFlags);

		[PreserveSig]
		public static extern MmResult mixerGetDevCaps(IntPtr nMixerID, ref MIXERCAPS mixerCaps, int mixerCapsSize);

		[PreserveSig]
		public static extern MmResult mixerGetID(IntPtr hMixer, out int mixerID, MixerFlags dwMixerIDFlags);

		[PreserveSig]
		public static extern MmResult mixerGetLineControls(IntPtr hMixer, ref MIXERLINECONTROLS mixerLineControls, MixerFlags dwControlFlags);

		[PreserveSig]
		public static extern MmResult mixerGetLineInfo(IntPtr hMixer, ref MIXERLINE mixerLine, MixerFlags dwInfoFlags);

		[PreserveSig]
		public static extern MmResult mixerMessage(IntPtr hMixer, uint nMessage, IntPtr dwParam1, IntPtr dwParam2);

		[PreserveSig]
		public static extern MmResult mixerSetControlDetails(IntPtr hMixer, ref MIXERCONTROLDETAILS mixerControlDetails, MixerFlags dwDetailsFlags);
	}
}
