using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.XInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XInputControllerExtension : Controller.Extension
	{
		private class RQYfguEYCpVlYVLUIDpXODUhETBtA : IControllerExtensionSource
		{
			private TVocCDfxMinGIOCkmldqehsxNAxhb.AlKsZxctHXLfYYkzfFYPZTTBpoGg rdzWQYwoosTQQnDRtarszTrsydFv;

			public TVocCDfxMinGIOCkmldqehsxNAxhb.AlKsZxctHXLfYYkzfFYPZTTBpoGg otIWUkGDOcCVnQiJAHbnFOYgtkPe => rdzWQYwoosTQQnDRtarszTrsydFv;

			public RQYfguEYCpVlYVLUIDpXODUhETBtA(TVocCDfxMinGIOCkmldqehsxNAxhb.AlKsZxctHXLfYYkzfFYPZTTBpoGg P_0)
			{
				rdzWQYwoosTQQnDRtarszTrsydFv = P_0;
			}
		}

		private RQYfguEYCpVlYVLUIDpXODUhETBtA UBJTiRzKsUmUTOrsDFNJnJhTGDjk;

		private bool eWQDTTfjNzlVwBXWplQkvTLvsSHH;

		private Joystick joystick => GetController<Joystick>();

		public int userIndex
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!eWQDTTfjNzlVwBXWplQkvTLvsSHH || !base.enabled)
				{
					return 0;
				}
				if (UBJTiRzKsUmUTOrsDFNJnJhTGDjk.otIWUkGDOcCVnQiJAHbnFOYgtkPe == null)
				{
					return 0;
				}
				return (int)UBJTiRzKsUmUTOrsDFNJnJhTGDjk.otIWUkGDOcCVnQiJAHbnFOYgtkPe.gUnAUFkHjFaDMbiGpFTHoDuxMnPpA.RSwcbAFHvHueOfKKKYcDWOWlvfLtA;
			}
		}

		public CapabilityFlags capabilityFlags
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return CapabilityFlags.None;
				}
				if (!eWQDTTfjNzlVwBXWplQkvTLvsSHH || !base.enabled)
				{
					return CapabilityFlags.None;
				}
				if (UBJTiRzKsUmUTOrsDFNJnJhTGDjk.otIWUkGDOcCVnQiJAHbnFOYgtkPe == null)
				{
					return CapabilityFlags.None;
				}
				UBJTiRzKsUmUTOrsDFNJnJhTGDjk.otIWUkGDOcCVnQiJAHbnFOYgtkPe.gUnAUFkHjFaDMbiGpFTHoDuxMnPpA.JzzMYzctFOaBGghlXslDWIFJisIE(JymHAvrnPSxZRGvgWOgLWQQayzhF.Any, out var ahTDkqWAlkFHaatFgCIQfUIUlUbYA2);
				return (CapabilityFlags)ahTDkqWAlkFHaatFgCIQfUIUlUbYA2.nEqSZFzvrvWAZpqjTBXluOzxSGAL;
			}
		}

		public DeviceType deviceType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return (DeviceType)0;
				}
				if (!eWQDTTfjNzlVwBXWplQkvTLvsSHH || !base.enabled)
				{
					return (DeviceType)0;
				}
				if (UBJTiRzKsUmUTOrsDFNJnJhTGDjk.otIWUkGDOcCVnQiJAHbnFOYgtkPe == null)
				{
					return (DeviceType)0;
				}
				UBJTiRzKsUmUTOrsDFNJnJhTGDjk.otIWUkGDOcCVnQiJAHbnFOYgtkPe.gUnAUFkHjFaDMbiGpFTHoDuxMnPpA.JzzMYzctFOaBGghlXslDWIFJisIE(JymHAvrnPSxZRGvgWOgLWQQayzhF.Any, out var ahTDkqWAlkFHaatFgCIQfUIUlUbYA2);
				return (DeviceType)ahTDkqWAlkFHaatFgCIQfUIUlUbYA2.LDAirpgglklrdDKijDWXnMnRlyZUA;
			}
		}

		public DeviceSubType deviceSubType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return (DeviceSubType)0;
				}
				if (!eWQDTTfjNzlVwBXWplQkvTLvsSHH || !base.enabled)
				{
					return (DeviceSubType)0;
				}
				if (UBJTiRzKsUmUTOrsDFNJnJhTGDjk.otIWUkGDOcCVnQiJAHbnFOYgtkPe == null)
				{
					return (DeviceSubType)0;
				}
				UBJTiRzKsUmUTOrsDFNJnJhTGDjk.otIWUkGDOcCVnQiJAHbnFOYgtkPe.gUnAUFkHjFaDMbiGpFTHoDuxMnPpA.JzzMYzctFOaBGghlXslDWIFJisIE(JymHAvrnPSxZRGvgWOgLWQQayzhF.Any, out var ahTDkqWAlkFHaatFgCIQfUIUlUbYA2);
				return (DeviceSubType)ahTDkqWAlkFHaatFgCIQfUIUlUbYA2.eHjvaVQoNDafjqdtwigHVDddFkSo;
			}
		}

		internal XInputControllerExtension(TVocCDfxMinGIOCkmldqehsxNAxhb.AlKsZxctHXLfYYkzfFYPZTTBpoGg P_0)
			: base(new RQYfguEYCpVlYVLUIDpXODUhETBtA(P_0))
		{
		}

		private XInputControllerExtension(XInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (eWQDTTfjNzlVwBXWplQkvTLvsSHH)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			UBJTiRzKsUmUTOrsDFNJnJhTGDjk = source as RQYfguEYCpVlYVLUIDpXODUhETBtA;
			eWQDTTfjNzlVwBXWplQkvTLvsSHH = UBJTiRzKsUmUTOrsDFNJnJhTGDjk != null;
		}

		internal override Controller.Extension Clone()
		{
			return new XInputControllerExtension(this);
		}
	}
}
