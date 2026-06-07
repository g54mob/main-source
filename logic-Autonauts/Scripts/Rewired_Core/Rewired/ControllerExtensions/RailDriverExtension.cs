using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	public sealed class RailDriverExtension : Controller.Extension
	{
		private class dTTFbRUPAQZJJGVlguyvUAOJeIk : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver WYZhcjTnddfwsuXVuPbKNLuuJgB;

			public dTTFbRUPAQZJJGVlguyvUAOJeIk(IDriver_RailDriver driver)
			{
				WYZhcjTnddfwsuXVuPbKNLuuJgB = driver;
			}
		}

		private dTTFbRUPAQZJJGVlguyvUAOJeIk pjmDqcGcEdmXbvnkITKNjUFiEooD;

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
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (pjmDqcGcEdmXbvnkITKNjUFiEooD.WYZhcjTnddfwsuXVuPbKNLuuJgB == null)
				{
					return false;
				}
				return pjmDqcGcEdmXbvnkITKNjUFiEooD.WYZhcjTnddfwsuXVuPbKNLuuJgB.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					while (true)
					{
						switch (-1991474757 ^ -1991474758)
						{
						case 2:
							break;
						case 1:
							return;
						case 0:
							goto end_IL_0019;
						default:
							goto IL_0058;
						}
						continue;
						end_IL_0019:
						break;
					}
				}
				if (pjmDqcGcEdmXbvnkITKNjUFiEooD.WYZhcjTnddfwsuXVuPbKNLuuJgB == null)
				{
					return;
				}
				goto IL_0058;
				IL_0058:
				pjmDqcGcEdmXbvnkITKNjUFiEooD.WYZhcjTnddfwsuXVuPbKNLuuJgB.SpeakerEnabled = value;
			}
		}

		internal RailDriverExtension(IDriver_RailDriver driver)
			: base(new dTTFbRUPAQZJJGVlguyvUAOJeIk(driver))
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
				goto IL_0019;
			}
			goto IL_0047;
			IL_0047:
			int num;
			if (pjmDqcGcEdmXbvnkITKNjUFiEooD.WYZhcjTnddfwsuXVuPbKNLuuJgB != null)
			{
				int num2;
				if (base.enabled)
				{
					num = -225836418;
					num2 = num;
				}
				else
				{
					num = -225836417;
					num2 = num;
				}
				goto IL_001e;
			}
			return;
			IL_0019:
			num = -225836420;
			goto IL_001e;
			IL_001e:
			switch (num ^ -225836419)
			{
			case 0:
				break;
			case 1:
				return;
			case 4:
				goto IL_0047;
			case 2:
				return;
			default:
				pjmDqcGcEdmXbvnkITKNjUFiEooD.WYZhcjTnddfwsuXVuPbKNLuuJgB.SetLEDDisplay(digitIndex, digitBitValues);
				return;
			}
			goto IL_0019;
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (pjmDqcGcEdmXbvnkITKNjUFiEooD.WYZhcjTnddfwsuXVuPbKNLuuJgB != null)
			{
				int num;
				int num2;
				if (base.enabled)
				{
					num = -98763390;
					num2 = num;
				}
				else
				{
					num = -98763386;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -98763390)
					{
					case 3:
						num = -98763392;
						continue;
					default:
						return;
					case 0:
						pjmDqcGcEdmXbvnkITKNjUFiEooD.WYZhcjTnddfwsuXVuPbKNLuuJgB.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
						num = -98763389;
						continue;
					case 4:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
				}
			}
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource P_0)
		{
			pjmDqcGcEdmXbvnkITKNjUFiEooD = P_0 as dTTFbRUPAQZJJGVlguyvUAOJeIk;
		}

		internal override Controller.Extension Clone()
		{
			return new RailDriverExtension(this);
		}
	}
}
