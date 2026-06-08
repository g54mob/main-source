using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	public sealed class RailDriverExtension : Controller.Extension
	{
		private class WuTOCGuSpMKXOvkGrLHgCzsKZmV : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver vULJPazKWrfClTuqhWeDZYCbvZw;

			public WuTOCGuSpMKXOvkGrLHgCzsKZmV(IDriver_RailDriver driver)
			{
				vULJPazKWrfClTuqhWeDZYCbvZw = driver;
			}
		}

		private WuTOCGuSpMKXOvkGrLHgCzsKZmV QhiXIzSBnzSGaWwDVddQlyhdvkF;

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
				if (QhiXIzSBnzSGaWwDVddQlyhdvkF.vULJPazKWrfClTuqhWeDZYCbvZw == null)
				{
					return false;
				}
				return QhiXIzSBnzSGaWwDVddQlyhdvkF.vULJPazKWrfClTuqhWeDZYCbvZw.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return;
				}
				while (QhiXIzSBnzSGaWwDVddQlyhdvkF.vULJPazKWrfClTuqhWeDZYCbvZw != null)
				{
					while (true)
					{
						IL_0051:
						QhiXIzSBnzSGaWwDVddQlyhdvkF.vULJPazKWrfClTuqhWeDZYCbvZw.SpeakerEnabled = value;
						int num = 769634228;
						while (true)
						{
							switch (num ^ 0x2DDFAFB4)
							{
							case 3:
								num = 769634230;
								continue;
							default:
								return;
							case 2:
								break;
							case 1:
								goto IL_0051;
							case 0:
								return;
							}
							break;
						}
						break;
					}
				}
			}
		}

		internal RailDriverExtension(IDriver_RailDriver driver)
			: base(new WuTOCGuSpMKXOvkGrLHgCzsKZmV(driver))
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
				goto IL_000d;
			}
			goto IL_004b;
			IL_000d:
			int num = -476668539;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -476668540)
				{
				case 4:
					break;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 2:
					goto IL_004b;
				case 3:
					return;
				case 0:
					goto IL_0071;
				default:
					QhiXIzSBnzSGaWwDVddQlyhdvkF.vULJPazKWrfClTuqhWeDZYCbvZw.SetLEDDisplay(digitIndex, digitBitValues);
					return;
				}
				break;
				IL_0071:
				int num2;
				if (!base.enabled)
				{
					num = -476668537;
					num2 = num;
				}
				else
				{
					num = -476668543;
					num2 = num;
				}
			}
			goto IL_000d;
			IL_004b:
			int num3;
			if (QhiXIzSBnzSGaWwDVddQlyhdvkF.vULJPazKWrfClTuqhWeDZYCbvZw != null)
			{
				num = -476668540;
				num3 = num;
			}
			else
			{
				num = -476668537;
				num3 = num;
			}
			goto IL_0012;
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
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
				if (QhiXIzSBnzSGaWwDVddQlyhdvkF.vULJPazKWrfClTuqhWeDZYCbvZw == null)
				{
					num = 1302902236;
					num2 = num;
				}
				else
				{
					num = 1302902233;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x4DA8B5DD)
					{
					case 0:
						num = 1302902239;
						continue;
					case 1:
						return;
					case 4:
					{
						int num3;
						if (!base.enabled)
						{
							num = 1302902236;
							num3 = num;
						}
						else
						{
							num = 1302902238;
							num3 = num;
						}
						continue;
					}
					case 2:
						break;
					default:
						QhiXIzSBnzSGaWwDVddQlyhdvkF.vULJPazKWrfClTuqhWeDZYCbvZw.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
						return;
					}
					break;
				}
			}
		}

		internal void kckuoUXEwQcigNbCseRHnXueOkT(UpdateLoopType P_0)
		{
		}

		internal void fIBaXcnjmllWSuIUKZjDotVxWIx(IControllerExtensionSource P_0)
		{
			QhiXIzSBnzSGaWwDVddQlyhdvkF = P_0 as WuTOCGuSpMKXOvkGrLHgCzsKZmV;
		}

		internal Controller.Extension EilcbgeeBHODbenDzVGhaquGLZK()
		{
			return new RailDriverExtension(this);
		}
	}
}
