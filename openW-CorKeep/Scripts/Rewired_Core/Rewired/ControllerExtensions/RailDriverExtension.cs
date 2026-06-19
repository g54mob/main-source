using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RailDriverExtension : Controller.Extension, IHIDControllerExtension
	{
		private class EuoUaQjcPhKTfhPRegqaFlucsmfg : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver jcAkwjYKKNtXNjAsOrPZgzBydaZw;

			public EuoUaQjcPhKTfhPRegqaFlucsmfg(IDriver_RailDriver P_0)
			{
				jcAkwjYKKNtXNjAsOrPZgzBydaZw = P_0;
			}
		}

		private EuoUaQjcPhKTfhPRegqaFlucsmfg VIKCduikZOiOkhPXqrUZExuUxXesA;

		private Joystick joystick => GetController<Joystick>();

		public bool speakerEnabled
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw == null)
				{
					return false;
				}
				return VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw != null)
				{
					VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw.SpeakerEnabled = value;
				}
			}
		}

		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw.vendorId;
			}
		}

		ushort IHIDControllerExtension.productId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw.productId;
			}
		}

		string IHIDControllerExtension.productName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				return VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw.productName;
			}
		}

		string IHIDControllerExtension.manufacturer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				return VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw.manufacturer;
			}
		}

		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw.usagePage;
			}
		}

		ushort IHIDControllerExtension.usage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw.usage;
			}
		}

		internal RailDriverExtension(IDriver_RailDriver P_0)
			: base(new EuoUaQjcPhKTfhPRegqaFlucsmfg(P_0))
		{
		}

		private RailDriverExtension(RailDriverExtension P_0)
			: base(P_0)
		{
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw != null && base.enabled)
			{
				VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw.SetLEDDisplay(digitIndex, digitBitValues);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw != null && base.enabled)
			{
				VIKCduikZOiOkhPXqrUZExuUxXesA.jcAkwjYKKNtXNjAsOrPZgzBydaZw.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			VIKCduikZOiOkhPXqrUZExuUxXesA = source as EuoUaQjcPhKTfhPRegqaFlucsmfg;
		}

		internal override Controller.Extension Clone()
		{
			return new RailDriverExtension(this);
		}
	}
}
