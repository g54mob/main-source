using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RailDriverExtension : Controller.Extension, IHIDControllerExtension
	{
		private class UQiIgLXonnQDXEdntfvVWDgZLpxo : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver rGMaeyjagBBHnmIMRpYgkfVJjxPhA;

			public UQiIgLXonnQDXEdntfvVWDgZLpxo(IDriver_RailDriver P_0)
			{
				rGMaeyjagBBHnmIMRpYgkfVJjxPhA = P_0;
			}
		}

		private UQiIgLXonnQDXEdntfvVWDgZLpxo BdYmzbSejAyOEabxxfRiGuwriYeQA;

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
				if (BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA == null)
				{
					return false;
				}
				return BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA != null)
				{
					BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA.SpeakerEnabled = value;
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
				return BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA.vendorId;
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
				return BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA.productId;
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
				return BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA.productName;
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
				return BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA.manufacturer;
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
				return BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA.usagePage;
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
				return BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA.usage;
			}
		}

		internal RailDriverExtension(IDriver_RailDriver P_0)
			: base(new UQiIgLXonnQDXEdntfvVWDgZLpxo(P_0))
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
			else if (BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA != null && base.enabled)
			{
				BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA.SetLEDDisplay(digitIndex, digitBitValues);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA != null && base.enabled)
			{
				BdYmzbSejAyOEabxxfRiGuwriYeQA.rGMaeyjagBBHnmIMRpYgkfVJjxPhA.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			BdYmzbSejAyOEabxxfRiGuwriYeQA = source as UQiIgLXonnQDXEdntfvVWDgZLpxo;
		}

		internal override Controller.Extension Clone()
		{
			return new RailDriverExtension(this);
		}
	}
}
