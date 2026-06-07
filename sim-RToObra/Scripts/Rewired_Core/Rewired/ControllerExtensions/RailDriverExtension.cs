using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	public sealed class RailDriverExtension : Controller.Extension
	{
		private class SlJPcCuLUCcmgEyyEqybkrCLqFnn : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver rLHrbkzJrdcRLAiOSFvKCmkcJdEM;

			public SlJPcCuLUCcmgEyyEqybkrCLqFnn(IDriver_RailDriver driver)
			{
				rLHrbkzJrdcRLAiOSFvKCmkcJdEM = driver;
			}
		}

		private SlJPcCuLUCcmgEyyEqybkrCLqFnn WVeuvvGVKxuwIVofyhIJOpLcDjb;

		private Joystick joystick
		{
			get
			{
				return GetController<Joystick>();
			}
		}

		public bool speakerEnabled
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					goto IL_000d;
				}
				int num;
				if (WVeuvvGVKxuwIVofyhIJOpLcDjb.rLHrbkzJrdcRLAiOSFvKCmkcJdEM == null)
				{
					num = 1509509407;
					goto IL_0012;
				}
				return WVeuvvGVKxuwIVofyhIJOpLcDjb.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.SpeakerEnabled;
				IL_000d:
				num = 1509509404;
				goto IL_0012;
				IL_0012:
				switch (num ^ 0x59F9491D)
				{
				case 0:
					break;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					return false;
				default:
					return false;
				}
				goto IL_000d;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (WVeuvvGVKxuwIVofyhIJOpLcDjb.rLHrbkzJrdcRLAiOSFvKCmkcJdEM == null)
					{
						num = 123756120;
						num2 = num;
					}
					else
					{
						num = 123756121;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x7605E5B)
						{
						case 0:
							goto IL_001a;
						case 1:
							break;
						case 3:
							return;
						default:
							WVeuvvGVKxuwIVofyhIJOpLcDjb.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.SpeakerEnabled = value;
							return;
						}
						break;
						IL_001a:
						num = 123756122;
					}
				}
			}
		}

		internal RailDriverExtension(IDriver_RailDriver driver)
			: base(new SlJPcCuLUCcmgEyyEqybkrCLqFnn(driver))
		{
		}

		private RailDriverExtension(RailDriverExtension source)
			: base(source)
		{
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (WVeuvvGVKxuwIVofyhIJOpLcDjb.rLHrbkzJrdcRLAiOSFvKCmkcJdEM != null)
			{
				int num;
				int num2;
				if (!base.enabled)
				{
					num = -458782637;
					num2 = num;
				}
				else
				{
					num = -458782638;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -458782637)
					{
					case 2:
						goto IL_001a;
					case 3:
						break;
					case 0:
						return;
					default:
						WVeuvvGVKxuwIVofyhIJOpLcDjb.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.SetLEDDisplay(digitIndex, digitBitValues);
						return;
					}
					break;
					IL_001a:
					num = -458782640;
				}
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_004a;
			IL_000d:
			int num = 119144603;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x71A0098)
				{
				case 2:
					break;
				case 3:
					ReInput.CheckInitialized(_reInputId);
					num = 119144600;
					continue;
				case 5:
					goto IL_004a;
				case 0:
					return;
				case 1:
					return;
				default:
					WVeuvvGVKxuwIVofyhIJOpLcDjb.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
					return;
				}
				break;
			}
			goto IL_000d;
			IL_004a:
			if (WVeuvvGVKxuwIVofyhIJOpLcDjb.rLHrbkzJrdcRLAiOSFvKCmkcJdEM != null)
			{
				int num2;
				if (!base.enabled)
				{
					num = 119144601;
					num2 = num;
				}
				else
				{
					num = 119144604;
					num2 = num;
				}
				goto IL_0012;
			}
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource P_0)
		{
			WVeuvvGVKxuwIVofyhIJOpLcDjb = P_0 as SlJPcCuLUCcmgEyyEqybkrCLqFnn;
		}

		internal override Controller.Extension Clone()
		{
			return new RailDriverExtension(this);
		}
	}
}
