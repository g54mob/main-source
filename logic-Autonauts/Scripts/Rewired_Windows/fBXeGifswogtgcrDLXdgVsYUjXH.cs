using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.HID;
using Rewired.Interfaces;
using Rewired.Libraries.SharpDX.DirectInput;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class fBXeGifswogtgcrDLXdgVsYUjXH : PlatformInputManager, yLzSZCPmdJJGIPBHZlMHGMUViap
{
	private class cyCsYcIQvugVJDWuUYpaIfgIudW : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int XKdkawtumCxPyKPVBrWIuFkhbmb;

		private int CcAaBYTnhTzbmiXXmdIizsUxQeD;

		public Guid REezjTFCollnzcnDXouNnLNDkjk;

		public string HMaFDzCZyyJZjLhcCpVmgIggZoam;

		public readonly pWuCkUBcnuhLuBWirlcUCWkKvpMO eunhnaovDRiEguPGzwjEMBJUohX;

		public vgUDhfmgAmAsRjRuQJnGENONMljC wiqRNryfmHlNNQfoPfOnkfUjYJq;

		public VSpIeAcJhSiZXYShilsTwSooeUR cxWZJvEKbopEslEOJsEPGUSFMLm;

		public string mHIfxFeuzrrprIjNQQttDcAWoJX;

		public string AOVTbdgjQpuvVXuOzJgmsvYOWec;

		public int fSuJoZmgBMnbZWJgvPaTNrIBkjq;

		public Guid cBDIfdqFvdWzxrFEMJqjLvTvIpG;

		public Guid qSJYeLiyjfTRCcMnvDOwuKWJouA;

		public Guid CgIVyXGyqTDPaUYRIwDzeLsZOit;

		public int ySxHACCmrqwNquIhkRqoFdufNKj;

		public bool NxfPDLDjjkkAByWVYHnViSDRJzU;

		public string ZODLrlcqYgYcHKPIQwZOreOIaYF;

		public string cohMCgUaCXDhrXVkwBZFZQUtguG;

		public int wqHuqGsJmegTaHkGmUKGpvcrfRfB;

		public int pIAPquXHYXQpPJRbLVGwvBFcXgk;

		public int jHaYXdTXWAJNlfIRTMsRGaqNBpK;

		public int qOBHYZBCAkYYTJoRDdsZoTyTELA;

		public int ByBfmUYbKOERmAjkpxrmtOAORFt;

		public bool KqmajqZRajQeRJHxvHBZhqVPgsd;

		private float[] ZRzHEnKZrARTmYSqzudcOoQkFLn;

		private bool[] vqZyMIbiZNaMpemrDPhgsXmGAKrY;

		private HardwareJoystickMap_InputManager VjkWjnwoPItHtAfScAsiHywgzcu;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lzXAqTcTNwGXhyoMQqetZTTNJGjM;

		private bool yRialUFBmVuFTOVrRxRadMBTRymj;

		private bool VOmckskOqMXuJcSBuIcPcvDRBIhH;

		private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return XKdkawtumCxPyKPVBrWIuFkhbmb;
			}
			set
			{
				XKdkawtumCxPyKPVBrWIuFkhbmb = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return CcAaBYTnhTzbmiXXmdIizsUxQeD;
			}
			set
			{
				CcAaBYTnhTzbmiXXmdIizsUxQeD = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (HMaFDzCZyyJZjLhcCpVmgIggZoam != "Unknown Controller")
				{
					return HMaFDzCZyyJZjLhcCpVmgIggZoam;
				}
				if (NxfPDLDjjkkAByWVYHnViSDRJzU && !string.IsNullOrEmpty(ZODLrlcqYgYcHKPIQwZOreOIaYF))
				{
					return ZODLrlcqYgYcHKPIQwZOreOIaYF;
				}
				return AOVTbdgjQpuvVXuOzJgmsvYOWec;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (CcAaBYTnhTzbmiXXmdIizsUxQeD < 0)
				{
					return null;
				}
				return CcAaBYTnhTzbmiXXmdIizsUxQeD;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return 0;
			}
		}

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			get
			{
				return null;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				return cBDIfdqFvdWzxrFEMJqjLvTvIpG;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid
		{
			get
			{
				return instanceGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public cyCsYcIQvugVJDWuUYpaIfgIudW(pWuCkUBcnuhLuBWirlcUCWkKvpMO sourceJoystick, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			eunhnaovDRiEguPGzwjEMBJUohX = sourceJoystick;
			lzXAqTcTNwGXhyoMQqetZTTNJGjM = getHardwareJoystickMap_InputManager;
			CcAaBYTnhTzbmiXXmdIizsUxQeD = -1;
			XKdkawtumCxPyKPVBrWIuFkhbmb = -1;
		}

		public void qlRdJvJiKhLJLbmzJBHkcnXAtwPX()
		{
			CgIVyXGyqTDPaUYRIwDzeLsZOit = MiscTools.CreateGuidHashSHA1(AOVTbdgjQpuvVXuOzJgmsvYOWec + qSJYeLiyjfTRCcMnvDOwuKWJouA);
			while (true)
			{
				int num = -1542611833;
				while (true)
				{
					switch (num ^ -1542611835)
					{
					case 0:
						break;
					case 2:
						wqHuqGsJmegTaHkGmUKGpvcrfRfB = jHaYXdTXWAJNlfIRTMsRGaqNBpK;
						pIAPquXHYXQpPJRbLVGwvBFcXgk = qOBHYZBCAkYYTJoRDdsZoTyTELA + ByBfmUYbKOERmAjkpxrmtOAORFt * 8;
						HUcWpSluxhNdngRwNRiLQuUWiQb();
						num = -1542611836;
						continue;
					case 1:
						REezjTFCollnzcnDXouNnLNDkjk = VjkWjnwoPItHtAfScAsiHywgzcu.hardwareMapIdentifier.guid;
						num = -1542611834;
						continue;
					default:
						HMaFDzCZyyJZjLhcCpVmgIggZoam = VjkWjnwoPItHtAfScAsiHywgzcu.controllerName;
						yRialUFBmVuFTOVrRxRadMBTRymj = ((REezjTFCollnzcnDXouNnLNDkjk == Guid.Empty) ? true : false);
						ZRzHEnKZrARTmYSqzudcOoQkFLn = new float[wqHuqGsJmegTaHkGmUKGpvcrfRfB];
						vqZyMIbiZNaMpemrDPhgsXmGAKrY = new bool[pIAPquXHYXQpPJRbLVGwvBFcXgk];
						eunhnaovDRiEguPGzwjEMBJUohX.MyJyGjmCwusbhiQFfrODGPnUwSK();
						Update();
						return;
					}
					break;
				}
			}
		}

		public void qmxqFhOXPynIFVlddeYJeiHLrJIQ(cyCsYcIQvugVJDWuUYpaIfgIudW P_0)
		{
			if (P_0 == null)
			{
				goto IL_0006;
			}
			goto IL_00fd;
			IL_0006:
			int num = -1571223277;
			goto IL_000b;
			IL_000b:
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1571223276)
				{
				case 3:
					break;
				default:
					return;
				case 7:
					return;
				case 9:
					if (num3 >= MathTools.Min(ZRzHEnKZrARTmYSqzudcOoQkFLn.Length, P_0.ZRzHEnKZrARTmYSqzudcOoQkFLn.Length))
					{
						VOmckskOqMXuJcSBuIcPcvDRBIhH = P_0.VOmckskOqMXuJcSBuIcPcvDRBIhH;
						num = -1571223279;
						continue;
					}
					goto case 8;
				case 0:
					if (num2 >= MathTools.Min(vqZyMIbiZNaMpemrDPhgsXmGAKrY.Length, P_0.vqZyMIbiZNaMpemrDPhgsXmGAKrY.Length))
					{
						num3 = 0;
						num = -1571223267;
						continue;
					}
					goto case 2;
				case 2:
					vqZyMIbiZNaMpemrDPhgsXmGAKrY[num2] = P_0.vqZyMIbiZNaMpemrDPhgsXmGAKrY[num2];
					num2++;
					num = -1571223276;
					continue;
				case 8:
					ZRzHEnKZrARTmYSqzudcOoQkFLn[num3] = P_0.ZRzHEnKZrARTmYSqzudcOoQkFLn[num3];
					num3++;
					num = -1571223267;
					continue;
				case 6:
					num2 = 0;
					num = -1571223276;
					continue;
				case 5:
					eunhnaovDRiEguPGzwjEMBJUohX.qmxqFhOXPynIFVlddeYJeiHLrJIQ(P_0.eunhnaovDRiEguPGzwjEMBJUohX);
					num = -1571223280;
					continue;
				case 1:
					goto IL_00fd;
				case 4:
					return;
				}
				break;
			}
			goto IL_0006;
			IL_00fd:
			CcAaBYTnhTzbmiXXmdIizsUxQeD = P_0.CcAaBYTnhTzbmiXXmdIizsUxQeD;
			XKdkawtumCxPyKPVBrWIuFkhbmb = P_0.XKdkawtumCxPyKPVBrWIuFkhbmb;
			num = -1571223278;
			goto IL_000b;
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			eunhnaovDRiEguPGzwjEMBJUohX.MvfYUGonPatKegPtmGgJekuNwNXV();
			bool[] currentButtonValues = default(bool[]);
			while (true)
			{
				int num = 384976220;
				while (true)
				{
					switch (num ^ 0x16F2455F)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						currentButtonValues = eunhnaovDRiEguPGzwjEMBJUohX.CurrentButtonValues;
						num = 384976222;
						continue;
					case 1:
					{
						int[] pointOfViewControllers = eunhnaovDRiEguPGzwjEMBJUohX.joystickState.PointOfViewControllers;
						QwjbBaCiqpyATADIBvDzRnxExBKA(currentButtonValues, pointOfViewControllers);
						ntHkZnBwItpIoEGMjrBEabLTXFJ(currentButtonValues, pointOfViewControllers);
						eunhnaovDRiEguPGzwjEMBJUohX.cHQDtHxqOBHMTeDoAMAnUqYwlCyL();
						num = 384976221;
						continue;
					}
					case 2:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (wqHuqGsJmegTaHkGmUKGpvcrfRfB != dataUpdater.axisCount)
			{
				goto IL_00b0;
			}
			if (pIAPquXHYXQpPJRbLVGwvBFcXgk != dataUpdater.buttonCount)
			{
				goto IL_0022;
			}
			goto IL_00e6;
			IL_00b0:
			throw new Exception("This controller signature does not match the data object!");
			IL_0022:
			int num = -208316108;
			goto IL_0027;
			IL_0027:
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -208316106)
				{
				case 6:
					break;
				default:
					return;
				case 4:
					num = -208316105;
					continue;
				case 9:
					dataUpdater.buttonValues[num3] = vqZyMIbiZNaMpemrDPhgsXmGAKrY[num3];
					num3++;
					num = -208316109;
					continue;
				case 1:
					if (num2 >= wqHuqGsJmegTaHkGmUKGpvcrfRfB)
					{
						num3 = 0;
						num = -208316109;
						continue;
					}
					goto case 0;
				case 5:
					goto IL_0093;
				case 2:
					goto IL_00b0;
				case 8:
					if (VOmckskOqMXuJcSBuIcPcvDRBIhH && !dataUpdater.hasReceivedInput)
					{
						dataUpdater.hasReceivedInput = true;
						num = -208316107;
						continue;
					}
					return;
				case 7:
					goto IL_00e6;
				case 0:
					dataUpdater.axisValues[num2] = ZRzHEnKZrARTmYSqzudcOoQkFLn[num2];
					num2++;
					num = -208316105;
					continue;
				case 3:
					return;
				}
				break;
				IL_0093:
				int num4;
				if (num3 >= pIAPquXHYXQpPJRbLVGwvBFcXgk)
				{
					num = -208316098;
					num4 = num;
				}
				else
				{
					num = -208316097;
					num4 = num;
				}
			}
			goto IL_0022;
			IL_00e6:
			num2 = 0;
			num = -208316110;
			goto IL_0027;
		}

		public int CjIOgfYLwvzSovgYNuiXTTvJjBe(cyCsYcIQvugVJDWuUYpaIfgIudW P_0)
		{
			if (P_0.XKdkawtumCxPyKPVBrWIuFkhbmb == XKdkawtumCxPyKPVBrWIuFkhbmb)
			{
				goto IL_000e;
			}
			if (jHaYXdTXWAJNlfIRTMsRGaqNBpK != P_0.jHaYXdTXWAJNlfIRTMsRGaqNBpK)
			{
				return 0;
			}
			int num;
			if (qOBHYZBCAkYYTJoRDdsZoTyTELA != P_0.qOBHYZBCAkYYTJoRDdsZoTyTELA)
			{
				num = 1573589275;
				goto IL_0013;
			}
			if (ByBfmUYbKOERmAjkpxrmtOAORFt != P_0.ByBfmUYbKOERmAjkpxrmtOAORFt)
			{
				return 0;
			}
			if (P_0.instanceGuid == instanceGuid)
			{
				return 2;
			}
			if (P_0.CgIVyXGyqTDPaUYRIwDzeLsZOit == CgIVyXGyqTDPaUYRIwDzeLsZOit)
			{
				return 1;
			}
			return 0;
			IL_000e:
			num = 1573589272;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x5DCB111A)
			{
			case 0:
				break;
			case 2:
				return 2;
			default:
				return 0;
			}
			goto IL_000e;
		}

		private BridgedControllerHWInfo XNhjnTKDnPIWYdspfSxvjnotCFBk()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			qHHYDYGCGqOhLRBRJCdFmLOJpwE(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			qHHYDYGCGqOhLRBRJCdFmLOJpwE(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(XKdkawtumCxPyKPVBrWIuFkhbmb);
		}

		public bool GnNaUkaHprcsTpLskywvfZOHPBmp()
		{
			try
			{
				eunhnaovDRiEguPGzwjEMBJUohX.EAHBveZYCGolVbLQhYJNUosGdcUg.fECWyLcpaTORPiGruFdrSOjglan();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void GFLPSeyIjIAqKSNFbdOLeOPmOvDX()
		{
			try
			{
				if (eunhnaovDRiEguPGzwjEMBJUohX.EAHBveZYCGolVbLQhYJNUosGdcUg == null)
				{
					return;
				}
				while (true)
				{
					int num = -1205836541;
					while (true)
					{
						switch (num ^ -1205836542)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_002b;
						case 0:
							return;
						}
						break;
						IL_002b:
						eunhnaovDRiEguPGzwjEMBJUohX.EAHBveZYCGolVbLQhYJNUosGdcUg.GFLPSeyIjIAqKSNFbdOLeOPmOvDX();
						num = -1205836542;
					}
				}
			}
			catch
			{
			}
		}

		public void JxfIuiJgitwuNVhKepFyxnNnrFN()
		{
			try
			{
				if (eunhnaovDRiEguPGzwjEMBJUohX.EAHBveZYCGolVbLQhYJNUosGdcUg != null)
				{
					eunhnaovDRiEguPGzwjEMBJUohX.EAHBveZYCGolVbLQhYJNUosGdcUg.JxfIuiJgitwuNVhKepFyxnNnrFN();
				}
			}
			catch
			{
			}
		}

		private void QwjbBaCiqpyATADIBvDzRnxExBKA(bool[] P_0, int[] P_1)
		{
			if (wqHuqGsJmegTaHkGmUKGpvcrfRfB <= 0)
			{
				return;
			}
			int num3 = default(int);
			HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig = default(HardwareJoystickMap.Platform_RawInput_Base.Axis[]);
			HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig2 = default(HardwareJoystickMap.Platform_DirectInput_Base.Axis[]);
			int num5 = default(int);
			while (true)
			{
				InputPlatform platform = VjkWjnwoPItHtAfScAsiHywgzcu.map.platform;
				int num;
				int num2;
				if (platform != InputPlatform.cZjaGiccoOfQMydNsMdhkKrlxCba)
				{
					num = 1713508655;
					num2 = num;
				}
				else
				{
					num = 1713508651;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x66221126)
					{
					case 4:
						num = 1713508653;
						continue;
					default:
						return;
					case 8:
						num3 = 0;
						num = 1713508645;
						continue;
					case 2:
					{
						int num4;
						if (axes_orig == null)
						{
							num = 1713508652;
							num4 = num;
						}
						else
						{
							num = 1713508654;
							num4 = num;
						}
						continue;
					}
					case 10:
						return;
					case 13:
					{
						HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map;
						axes_orig = platform_RawInput_Base.Axes_orig;
						num = 1713508644;
						continue;
					}
					case 1:
						RllMKCBqlEnYHHyzXfDrYOpOkeB(axes_orig2[num5], num5, P_0, P_1);
						num5++;
						num = 1713508641;
						continue;
					case 12:
						if (axes_orig2 == null)
						{
							return;
						}
						goto case 5;
					case 0:
						RllMKCBqlEnYHHyzXfDrYOpOkeB(axes_orig[num3], num3, P_0, P_1);
						num3++;
						num = 1713508645;
						continue;
					case 5:
						num5 = 0;
						num = 1713508641;
						continue;
					case 11:
						break;
					case 7:
					{
						int num6;
						if (num5 >= axes_orig2.Length)
						{
							num = 1713508640;
							num6 = num;
						}
						else
						{
							num = 1713508647;
							num6 = num;
						}
						continue;
					}
					case 9:
						if (platform == InputPlatform.GqzyAlVbsTJEJeHcVvIVueUVgOh)
						{
							HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map;
							axes_orig2 = platform_DirectInput_Base.Axes_orig;
							num = 1713508650;
							continue;
						}
						return;
					case 3:
						if (num3 >= axes_orig.Length)
						{
							return;
						}
						goto case 0;
					case 6:
						return;
					}
					break;
				}
			}
		}

		private void ntHkZnBwItpIoEGMjrBEabLTXFJ(bool[] P_0, int[] P_1)
		{
			if (pIAPquXHYXQpPJRbLVGwvBFcXgk <= 0)
			{
				return;
			}
			int num4 = default(int);
			HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = default(HardwareJoystickMap.Platform_DirectInput_Base.Button[]);
			int num2 = default(int);
			HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig = default(HardwareJoystickMap.Platform_RawInput_Base.Button[]);
			while (true)
			{
				InputPlatform platform = VjkWjnwoPItHtAfScAsiHywgzcu.map.platform;
				int num = -1347722890;
				while (true)
				{
					switch (num ^ -1347722896)
					{
					case 2:
						num = -1347722888;
						continue;
					default:
						return;
					case 5:
						num4++;
						num = -1347722896;
						continue;
					case 1:
						if (platform == InputPlatform.GqzyAlVbsTJEJeHcVvIVueUVgOh)
						{
							HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map;
							buttons_orig2 = platform_DirectInput_Base.Buttons_orig;
							if (buttons_orig2 == null)
							{
								return;
							}
							goto case 7;
						}
						return;
					case 8:
						break;
					case 14:
					{
						int num6;
						if (num2 < buttons_orig.Length)
						{
							num = -1347722886;
							num6 = num;
						}
						else
						{
							num = -1347722881;
							num6 = num;
						}
						continue;
					}
					case 3:
					{
						HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map;
						buttons_orig = platform_RawInput_Base.Buttons_orig;
						num = -1347722892;
						continue;
					}
					case 15:
						return;
					case 10:
						LcwcYjKajxFOmevKwcJVUOXnNQR(buttons_orig[num2], num2, P_0, P_1);
						num2++;
						num = -1347722882;
						continue;
					case 0:
					{
						int num5;
						if (num4 >= buttons_orig2.Length)
						{
							num = -1347722887;
							num5 = num;
						}
						else
						{
							num = -1347722883;
							num5 = num;
						}
						continue;
					}
					case 13:
						LcwcYjKajxFOmevKwcJVUOXnNQR(buttons_orig2[num4], num4, P_0, P_1);
						num = -1347722891;
						continue;
					case 6:
					{
						int num3;
						if (platform == InputPlatform.cZjaGiccoOfQMydNsMdhkKrlxCba)
						{
							num = -1347722893;
							num3 = num;
						}
						else
						{
							num = -1347722895;
							num3 = num;
						}
						continue;
					}
					case 4:
						if (buttons_orig == null)
						{
							return;
						}
						goto case 12;
					case 7:
						num4 = 0;
						num = -1347722885;
						continue;
					case 12:
						num2 = 0;
						num = -1347722882;
						continue;
					case 11:
						num = -1347722896;
						continue;
					case 9:
						return;
					}
					break;
				}
			}
		}

		private void RllMKCBqlEnYHHyzXfDrYOpOkeB(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= wqHuqGsJmegTaHkGmUKGpvcrfRfB)
			{
				goto IL_0009;
			}
			goto IL_003d;
			IL_0009:
			int num = 1866580332;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x6F41C16D)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			case 3:
				goto IL_003d;
			case 0:
				return;
			}
			goto IL_0009;
			IL_003d:
			ZRzHEnKZrARTmYSqzudcOoQkFLn[P_1] = MnqkSgUruMGpGEncQArrqhjEHzFC(P_0, P_2, P_3);
			if (!VOmckskOqMXuJcSBuIcPcvDRBIhH && ZRzHEnKZrARTmYSqzudcOoQkFLn[P_1] != 0f)
			{
				VOmckskOqMXuJcSBuIcPcvDRBIhH = true;
				num = 1866580333;
				goto IL_000e;
			}
		}

		private void LcwcYjKajxFOmevKwcJVUOXnNQR(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= pIAPquXHYXQpPJRbLVGwvBFcXgk)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			while (true)
			{
				vqZyMIbiZNaMpemrDPhgsXmGAKrY[P_1] = odpuOJgHmnilGWRhqHPsTzrkUnQ(P_0, P_2, P_3);
				int num;
				int num2;
				if (VOmckskOqMXuJcSBuIcPcvDRBIhH)
				{
					num = -2117757175;
					num2 = num;
				}
				else
				{
					num = -2117757174;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -2117757173)
					{
					case 0:
						num = -2117757176;
						continue;
					default:
						return;
					case 3:
						break;
					case 1:
						if (vqZyMIbiZNaMpemrDPhgsXmGAKrY[P_1])
						{
							VOmckskOqMXuJcSBuIcPcvDRBIhH = true;
							num = -2117757175;
							continue;
						}
						return;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private float MnqkSgUruMGpGEncQArrqhjEHzFC(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis > 0)
				{
					if (P_0.sourceAxis < 32)
					{
						return MnqkSgUruMGpGEncQArrqhjEHzFC((DirectInputAxis)P_0.sourceAxis);
					}
					goto IL_001f;
				}
				goto IL_0094;
			}
			int num;
			int sourceHat = default(int);
			CustomCalculation customCalculation = default(CustomCalculation);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				num = -481890111;
			}
			else if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				sourceHat = P_0.sourceHat;
				num = -481890104;
			}
			else
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
				{
					return 0f;
				}
				customCalculation = P_0.customCalculation;
				num = -481890100;
			}
			goto IL_0024;
			IL_001f:
			num = -481890081;
			goto IL_0024;
			IL_0362:
			if (!customCalculation.Process())
			{
				return 0f;
			}
			if (customCalculation.Result.type != TypeWrapper.DataType.Single)
			{
				return 0f;
			}
			return customCalculation.Result;
			IL_0024:
			int num2 = default(int);
			int sourceButton = default(int);
			float result = default(float);
			HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat = default(HardwareElementSourceTypeWithHat);
			HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
			HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[]);
			float num4 = default(float);
			int num5 = default(int);
			while (true)
			{
				switch (num ^ -481890102)
				{
				case 14:
					break;
				case 21:
					goto IL_0094;
				case 8:
					return 0f;
				case 4:
					num2++;
					num = -481890085;
					continue;
				case 23:
					return 0f;
				case 2:
					goto IL_010f;
				case 16:
					if (sourceHat >= ByBfmUYbKOERmAjkpxrmtOAORFt)
					{
						goto case 8;
					}
					goto IL_0132;
				case 7:
					goto IL_0141;
				case 12:
					goto IL_0161;
				case 13:
					if (sourceButton < 0)
					{
						goto case 23;
					}
					goto IL_0178;
				case 5:
					goto IL_0195;
				case 1:
					return 0f;
				case 9:
					return result;
				case 0:
					num = -481890109;
					continue;
				case 10:
					hardwareElementSourceTypeWithHat = sourceType;
					num = -481890088;
					continue;
				case 20:
					goto IL_0266;
				case 15:
					goto IL_027c;
				case 19:
					goto IL_029d;
				case 6:
					goto IL_02bf;
				case 11:
					sourceButton = P_0.sourceButton;
					num = -481890105;
					continue;
				case 3:
					if (customCalculationSourceData[num2] != null)
					{
						sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[num2].sourceType;
						num = -481890112;
						continue;
					}
					goto case 4;
				case 18:
				{
					float item;
					if (hardwareElementSourceTypeWithHat == HardwareElementSourceTypeWithHat.Axis && SphXEVFIXUzhWZMGZUyIbdOXoiY(customCalculationSourceData[num2], out item))
					{
						customCalculation.AddData(item);
						num = -481890098;
						continue;
					}
					goto case 4;
				}
				case 22:
					goto IL_0345;
				default:
					if (num2 < customCalculationSourceData.Length)
					{
						goto case 3;
					}
					goto IL_0362;
				}
				break;
				IL_0345:
				if (sourceButton < 128)
				{
					if (!P_1[sourceButton])
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						result = 1f;
						num = -481890102;
						continue;
					}
					goto IL_0161;
				}
				num = -481890083;
				continue;
				IL_0178:
				int num3;
				if (sourceButton < qOBHYZBCAkYYTJoRDdsZoTyTELA)
				{
					num = -481890084;
					num3 = num;
				}
				else
				{
					num = -481890083;
					num3 = num;
				}
				continue;
				IL_0195:
				if (num4 < 0f)
				{
					return 0f;
				}
				goto IL_01ed;
				IL_0132:
				if (sourceHat < 4)
				{
					num5 = P_2[sourceHat];
					num = -481890107;
				}
				else
				{
					num = -481890110;
				}
				continue;
				IL_0161:
				result = -1f;
				num = -481890109;
				continue;
				IL_027c:
				if (num5 < 0)
				{
					return 0f;
				}
				if (P_0.sourceHatDirection != AxisDirection.Horizontal)
				{
					num4 = zGynLZPNrxQpghHyIZzAUIHYsnd(num5, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num4 < 0f)
							{
								return 0f;
							}
						}
						else if (num4 > 0f)
						{
							return 0f;
						}
					}
					goto IL_01ed;
				}
				num = -481890099;
				continue;
				IL_02bf:
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType == TypeWrapper.DataType.Single)
				{
					customCalculationSourceData = P_0.customCalculationSourceData;
					if (customCalculationSourceData == null)
					{
						return 0f;
					}
					num2 = 0;
					num = -481890085;
				}
				else
				{
					num = -481890101;
				}
				continue;
				IL_0141:
				num4 = zGynLZPNrxQpghHyIZzAUIHYsnd(num5, AxisDirection.Horizontal);
				if (P_0.sourceHatRange != AxisRange.Full)
				{
					num = -481890082;
					continue;
				}
				goto IL_01ed;
				IL_01ed:
				if (P_0.invert)
				{
					num4 *= -1f;
					num = -481890087;
					continue;
				}
				goto IL_029d;
				IL_0266:
				if (P_0.sourceHatRange != AxisRange.Positive)
				{
					if (num4 > 0f)
					{
						return 0f;
					}
					goto IL_01ed;
				}
				num = -481890097;
				continue;
				IL_010f:
				int num6;
				if (sourceHat < 0)
				{
					num = -481890110;
					num6 = num;
				}
				else
				{
					num = -481890086;
					num6 = num;
				}
				continue;
				IL_029d:
				return num4;
			}
			goto IL_001f;
			IL_0094:
			return 0f;
		}

		private float MnqkSgUruMGpGEncQArrqhjEHzFC(DirectInputAxis P_0)
		{
			float result;
			int num;
			switch (P_0)
			{
			case DirectInputAxis.VelocitySlider1:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.VelocitySliders[1]);
				break;
			case DirectInputAxis.TorqueX:
				goto IL_017c;
			case DirectInputAxis.ForceX:
				goto IL_01ac;
			case DirectInputAxis.RotationZ:
				goto IL_01d2;
			case DirectInputAxis.AngularVelocityX:
				goto IL_01f8;
			case DirectInputAxis.AngularAccelerationZ:
				goto IL_0219;
			case DirectInputAxis.Slider0:
				goto IL_023f;
			case DirectInputAxis.ForceSlider0:
				goto IL_0267;
			case DirectInputAxis.ForceZ:
				goto IL_028f;
			case DirectInputAxis.Z:
				goto IL_02bf;
			case DirectInputAxis.AccelerationX:
				goto IL_02e0;
			case DirectInputAxis.AccelerationY:
				goto IL_0315;
			case DirectInputAxis.VelocitySlider0:
				goto IL_0359;
			case DirectInputAxis.TorqueZ:
				goto IL_037c;
			case DirectInputAxis.AngularVelocityZ:
				goto IL_03b1;
			case DirectInputAxis.VelocityZ:
				goto IL_03d2;
			case DirectInputAxis.VelocityY:
				goto IL_0407;
			case DirectInputAxis.TorqueY:
				goto IL_042d;
			case DirectInputAxis.Y:
				goto IL_0453;
			case DirectInputAxis.X:
				goto IL_0483;
			case DirectInputAxis.RotationX:
				goto IL_04a9;
			case DirectInputAxis.RotationY:
				goto IL_04cf;
			case DirectInputAxis.AngularAccelerationX:
				goto IL_0504;
			case DirectInputAxis.AccelerationSlider1:
				goto IL_052a;
			case DirectInputAxis.AccelerationZ:
				goto IL_054d;
			case DirectInputAxis.ForceSlider1:
				goto IL_0573;
			case DirectInputAxis.AngularAccelerationY:
				goto IL_0596;
			case DirectInputAxis.Slider1:
				goto IL_05cb;
			case DirectInputAxis.AccelerationSlider0:
				goto IL_05f3;
			case DirectInputAxis.AngularVelocityY:
				goto IL_0616;
			case DirectInputAxis.ForceY:
				goto IL_0639;
			case DirectInputAxis.VelocityX:
				goto IL_065c;
			default:
				goto IL_067f;
				IL_017c:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.TorqueX);
				num = -622267373;
				goto IL_0094;
				IL_0094:
				while (true)
				{
					switch (num ^ -622267366)
					{
					case 30:
						num = -622267330;
						continue;
					case 4:
						break;
					case 6:
						goto IL_017c;
					case 34:
						goto IL_01ac;
					case 13:
						goto IL_01d2;
					case 5:
						goto IL_01f8;
					case 22:
						goto IL_0219;
					case 7:
						goto IL_023f;
					case 11:
						goto IL_0267;
					case 38:
						goto IL_028f;
					case 41:
						goto IL_02bf;
					case 10:
						goto IL_02e0;
					case 23:
						goto IL_0315;
					case 3:
						goto IL_0359;
					case 31:
						goto IL_037c;
					case 35:
						goto IL_03b1;
					case 15:
						goto IL_03d2;
					case 16:
						goto IL_0407;
					case 20:
						goto IL_042d;
					case 33:
						goto IL_0453;
					case 36:
						goto IL_0483;
					case 32:
						goto IL_04a9;
					case 25:
						goto IL_04cf;
					case 2:
						goto IL_0504;
					case 29:
						goto IL_052a;
					case 19:
						goto IL_054d;
					case 21:
						goto IL_0573;
					case 43:
						goto IL_0596;
					case 18:
						goto IL_05cb;
					case 37:
						goto IL_05f3;
					case 12:
						goto IL_0616;
					case 26:
						goto IL_0639;
					case 39:
						goto IL_065c;
					default:
						goto IL_067f;
					case 0:
					case 1:
					case 8:
					case 9:
					case 14:
					case 17:
					case 24:
					case 27:
					case 40:
					case 42:
						goto end_IL_0005;
					}
					break;
				}
				goto case DirectInputAxis.VelocitySlider1;
				IL_067f:
				return 0f;
				IL_065c:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.VelocityX);
				break;
				IL_0639:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.ForceY);
				break;
				IL_0616:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.AngularVelocityY);
				break;
				IL_05f3:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.AccelerationSliders[0]);
				num = -622267372;
				goto IL_0094;
				IL_05cb:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.Sliders[1]);
				break;
				IL_0596:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.AngularAccelerationY);
				break;
				IL_0573:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.ForceSliders[1]);
				num = -622267344;
				goto IL_0094;
				IL_054d:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.AccelerationZ);
				break;
				IL_052a:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.AccelerationSliders[1]);
				num = -622267381;
				goto IL_0094;
				IL_0504:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.AngularAccelerationX);
				break;
				IL_04cf:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.RotationY);
				break;
				IL_04a9:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.RotationX);
				break;
				IL_0483:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.X);
				break;
				IL_0453:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.Y);
				num = -622267342;
				goto IL_0094;
				IL_042d:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.TorqueY);
				break;
				IL_0407:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.VelocityY);
				break;
				IL_03d2:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.VelocityZ);
				break;
				IL_03b1:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.AngularVelocityZ);
				num = -622267391;
				goto IL_0094;
				IL_037c:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.TorqueZ);
				break;
				IL_0359:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.VelocitySliders[0]);
				num = -622267365;
				goto IL_0094;
				IL_0315:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.AccelerationY);
				break;
				IL_02e0:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.AccelerationX);
				break;
				IL_02bf:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.Z);
				num = -622267374;
				goto IL_0094;
				IL_028f:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.ForceZ);
				num = -622267390;
				goto IL_0094;
				IL_0267:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.ForceSliders[0]);
				break;
				IL_023f:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.Sliders[0]);
				break;
				IL_0219:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.AngularAccelerationZ);
				break;
				IL_01f8:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.AngularVelocityX);
				num = -622267366;
				goto IL_0094;
				IL_01d2:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.RotationZ);
				break;
				IL_01ac:
				result = lmyenCPLmUeYnxIapmEbpOtJtXT(eunhnaovDRiEguPGzwjEMBJUohX.joystickState.ForceX);
				break;
				end_IL_0005:
				break;
			}
			return result;
		}

		private bool odpuOJgHmnilGWRhqHPsTzrkUnQ(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			int num = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (!P_0.ignoreIfButtonsActive)
				{
					goto IL_0184;
				}
				num = 0;
				goto IL_019d;
			}
			int num2;
			CustomCalculation customCalculation = default(CustomCalculation);
			HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[]);
			int num3 = default(int);
			int sourceHat = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				num2 = -2094444452;
			}
			else if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
				{
					goto IL_0481;
				}
				customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return false;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return false;
				}
				customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return false;
				}
				num3 = 0;
				num2 = -2094444449;
			}
			else
			{
				sourceHat = P_0.sourceHat;
				int num4;
				if (sourceHat < 0)
				{
					num2 = -2094444455;
					num4 = num2;
				}
				else
				{
					num2 = -2094444478;
					num4 = num2;
				}
			}
			goto IL_0022;
			IL_0448:
			if (!customCalculation.Process())
			{
				return false;
			}
			if (customCalculation.Result.type != TypeWrapper.DataType.Single)
			{
				return false;
			}
			return (float)customCalculation.Result != 0f;
			IL_0315:
			bool flag = default(bool);
			if (flag)
			{
				return true;
			}
			return false;
			IL_019d:
			int num5;
			if (num >= P_0.ignoreIfButtonsActiveButtons.Length)
			{
				num2 = -2094444476;
				num5 = num2;
			}
			else
			{
				num2 = -2094444474;
				num5 = num2;
			}
			goto IL_0022;
			IL_0481:
			return false;
			IL_0184:
			int num6 = default(int);
			int sourceButton = default(int);
			if (P_0.requireMultipleButtons)
			{
				flag = false;
				num6 = 0;
				num2 = -2094444477;
			}
			else
			{
				sourceButton = P_0.sourceButton;
				int num7;
				if (sourceButton >= 0)
				{
					num2 = -2094444458;
					num7 = num2;
				}
				else
				{
					num2 = -2094444480;
					num7 = num2;
				}
			}
			goto IL_0022;
			IL_0022:
			float num8 = default(float);
			while (true)
			{
				switch (num2 ^ -2094444459)
				{
				case 7:
					num2 = -2094444474;
					continue;
				case 16:
					customCalculation.AddData((num8 != 0f) ? 1f : 0f);
					num2 = -2094444479;
					continue;
				case 6:
				{
					bool flag2;
					if (nkiUDWmqkoBdSdpkwhGLjZgLKfrF(customCalculationSourceData[num3], P_1, out flag2))
					{
						customCalculation.AddData(flag2 ? 1f : 0f);
						num2 = -2094444479;
						continue;
					}
					goto case 20;
				}
				case 18:
					return false;
				case 3:
					break;
				case 23:
					if (sourceHat < ByBfmUYbKOERmAjkpxrmtOAORFt)
					{
						goto IL_0172;
					}
					goto case 12;
				case 17:
					goto end_IL_0022;
				case 0:
					goto IL_019d;
				case 21:
					return false;
				case 13:
					goto IL_01d8;
				case 9:
					if (P_0.sourceAxis <= 0)
					{
						goto case 18;
					}
					goto IL_02bd;
				case 8:
					if (customCalculationSourceData[num3] != null)
					{
						switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[num3].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Button:
							break;
						default:
							goto IL_02fd;
						case HardwareElementSourceTypeWithHat.Axis:
							goto IL_03ec;
						}
						goto case 6;
					}
					goto case 20;
				case 22:
					goto IL_0307;
				case 12:
					return false;
				case 2:
					return false;
				case 10:
					num2 = -2094444454;
					continue;
				case 14:
					goto IL_03b1;
				case 20:
					num3++;
					num2 = -2094444454;
					continue;
				case 5:
					goto IL_03d7;
				case 11:
					goto IL_03ec;
				case 1:
					return false;
				case 19:
					goto IL_0421;
				default:
					if (num3 < customCalculationSourceData.Length)
					{
						goto case 8;
					}
					goto IL_0448;
				case 4:
					goto IL_0481;
					IL_02fd:
					num2 = -2094444479;
					continue;
				}
				int num9;
				if (sourceButton >= qOBHYZBCAkYYTJoRDdsZoTyTELA)
				{
					num2 = -2094444480;
					num9 = num2;
				}
				else
				{
					num2 = -2094444464;
					num9 = num2;
				}
				continue;
				IL_0421:
				if (P_1[P_0.ignoreIfButtonsActiveButtons[num]])
				{
					return false;
				}
				num++;
				num2 = -2094444459;
				continue;
				IL_02bd:
				if (P_0.sourceAxis <= 32)
				{
					float num10 = MnqkSgUruMGpGEncQArrqhjEHzFC((DirectInputAxis)P_0.sourceAxis);
					if (MathTools.Abs(num10) <= P_0.axisDeadZone)
					{
						return false;
					}
					if (P_0.sourceAxisPole == Pole.Positive)
					{
						if (num10 < 0f)
						{
							return false;
						}
					}
					else if (num10 > 0f)
					{
						num2 = -2094444457;
						continue;
					}
					return true;
				}
				num2 = -2094444473;
				continue;
				IL_0172:
				if (sourceHat >= 4)
				{
					num2 = -2094444455;
					continue;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					break;
				case HatDirection.UpRight:
					return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 7, P_0.sourceHatType);
				default:
					num2 = -2094444463;
					continue;
				}
				goto IL_01d8;
				IL_03d7:
				if (sourceButton < 128)
				{
					return P_1[sourceButton];
				}
				num2 = -2094444480;
				continue;
				IL_01d8:
				return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 0, P_0.sourceHatType);
				IL_03ec:
				int num11;
				if (SphXEVFIXUzhWZMGZUyIbdOXoiY(customCalculationSourceData[num3], out num8))
				{
					num2 = -2094444475;
					num11 = num2;
				}
				else
				{
					num2 = -2094444479;
					num11 = num2;
				}
				continue;
				IL_0307:
				if (num6 >= P_0.requiredButtons.Length)
				{
					goto IL_0315;
				}
				goto IL_03b1;
				IL_03b1:
				if (!P_1[P_0.requiredButtons[num6]])
				{
					num2 = -2094444460;
					continue;
				}
				flag = true;
				num6++;
				num2 = -2094444477;
				continue;
				end_IL_0022:
				break;
			}
			goto IL_0184;
		}

		private float lmyenCPLmUeYnxIapmEbpOtJtXT(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private bool eGcOhXofWxIUvicLZONhRAcJxsD(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (VjkWjnwoPItHtAfScAsiHywgzcu.isUnknownController)
			{
				goto IL_0013;
			}
			goto IL_0072;
			IL_0072:
			int num = 4500;
			int num2 = num * P_1;
			int num3;
			if (P_2 == HatType.EightWay)
			{
				num3 = 260405597;
				goto IL_0018;
			}
			goto IL_00b7;
			IL_0013:
			num3 = 260405598;
			goto IL_0018;
			IL_0018:
			int num4 = default(int);
			while (true)
			{
				switch (num3 ^ 0xF85795F)
				{
				case 6:
					break;
				case 5:
					goto IL_0048;
				case 2:
					goto IL_005b;
				case 1:
					goto IL_0066;
				case 0:
					goto IL_0087;
				case 3:
					P_0 -= 36000;
					num3 = 260405595;
					continue;
				case 7:
					return false;
				default:
					goto IL_00d1;
				}
				break;
				IL_0087:
				if (P_1 == 0)
				{
					int num5;
					if (P_0 <= num4)
					{
						num3 = 260405595;
						num5 = num3;
					}
					else
					{
						num3 = 260405596;
						num5 = num3;
					}
					continue;
				}
				goto IL_00d1;
				IL_005b:
				if (P_0 != num2)
				{
					num3 = 260405592;
					continue;
				}
				goto IL_00b7;
			}
			goto IL_0013;
			IL_0048:
			num4 = 27000;
			int num6 = 9000;
			num3 = 260405599;
			goto IL_0018;
			IL_00b7:
			if (P_2 == HatType.EightWay)
			{
				num4 = 31500;
				num6 = 4500;
				num3 = 260405599;
				goto IL_0018;
			}
			goto IL_0048;
			IL_0066:
			if (!InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return false;
			}
			goto IL_0072;
			IL_00d1:
			if (P_0 < num2 + num6 && P_0 > num2 - num6)
			{
				return true;
			}
			return false;
		}

		private float zGynLZPNrxQpghHyIZzAUIHYsnd(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				goto IL_0007;
			}
			int num;
			if (P_1 != AxisDirection.Vertical)
			{
				if (P_0 > 0 && P_0 < 18000)
				{
					return 1f;
				}
				if (P_0 <= 18000)
				{
					return 0f;
				}
				num = -806046993;
			}
			else
			{
				num = -806046996;
			}
			goto IL_000c;
			IL_0007:
			num = -806046997;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -806046993)
				{
				case 6:
					break;
				case 5:
					return -1f;
				case 7:
					if (P_0 > 9000)
					{
						num = -806046998;
						continue;
					}
					goto IL_0042;
				case 1:
					if (P_0 < 9000)
					{
						num = -806046995;
						continue;
					}
					if (P_0 < 27000)
					{
						num = -806047000;
						continue;
					}
					goto IL_0042;
				case 3:
				{
					int num2;
					if (P_0 > 27000)
					{
						num = -806046995;
						num2 = num;
					}
					else
					{
						num = -806046994;
						num2 = num;
					}
					continue;
				}
				case 2:
					return 1f;
				case 4:
					return 0f;
				default:
					{
						return -1f;
					}
					IL_0042:
					return 0f;
				}
				break;
			}
			goto IL_0007;
		}

		private bool nkiUDWmqkoBdSdpkwhGLjZgLKfrF(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			int sourceButton = default(int);
			while (true)
			{
				int num = -2015323082;
				while (true)
				{
					switch (num ^ -2015323084)
					{
					case 4:
						break;
					case 3:
						return false;
					case 1:
						if (sourceButton < qOBHYZBCAkYYTJoRDdsZoTyTELA)
						{
							if (sourceButton < 128)
							{
								P_2 = P_1[sourceButton];
								num = -2015323084;
							}
							else
							{
								num = -2015323081;
							}
							continue;
						}
						goto case 3;
					case 2:
					{
						if (P_0.sourceType != 0)
						{
							return false;
						}
						sourceButton = P_0.sourceButton;
						int num2;
						if (sourceButton < 0)
						{
							num = -2015323081;
							num2 = num;
						}
						else
						{
							num = -2015323083;
							num2 = num;
						}
						continue;
					}
					default:
						return true;
					}
					break;
				}
			}
		}

		private bool SphXEVFIXUzhWZMGZUyIbdOXoiY(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			if (P_0.sourceAxis > 0)
			{
				AxisRange sourceAxisRange = default(AxisRange);
				while (true)
				{
					int num = 526468688;
					while (true)
					{
						switch (num ^ 0x1F614655)
						{
						case 4:
							break;
						case 12:
							switch (sourceAxisRange)
							{
							case AxisRange.Negative:
								goto IL_0111;
							case AxisRange.Positive:
								goto IL_01d1;
							}
							num = 526468696;
							continue;
						case 6:
							if (P_0.axisCalibrationType == AxisCalibrationType.Default)
							{
								P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.invert, false, AxisSensitivityType.Multiplier, 1f, null);
								num = 526468690;
								continue;
							}
							goto case 14;
						case 7:
							num = 526468702;
							continue;
						case 14:
							if (P_0.axisCalibrationType == AxisCalibrationType.Custom)
							{
								P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.invert, false, AxisSensitivityType.Multiplier, 1f, null);
								num = 526468693;
								continue;
							}
							goto case 3;
						case 10:
							goto IL_0111;
						case 3:
							if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated && P_0.axisDeadZone > 0f && MathTools.Abs(P_1) <= P_0.axisDeadZone)
							{
								P_1 = 0f;
								num = 526468702;
								continue;
							}
							goto default;
						case 8:
							P_1 = 0f;
							num = 526468695;
							continue;
						case 0:
							num = 526468702;
							continue;
						case 9:
							goto end_IL_001e;
						case 2:
							num = 526468691;
							continue;
						case 5:
							goto IL_01b3;
						case 13:
							num = 526468691;
							continue;
						case 1:
							goto IL_01d1;
						default:
							{
								return true;
							}
							IL_01d1:
							if (P_1 < 0f)
							{
								P_1 = 0f;
								num = 526468691;
								continue;
							}
							goto case 6;
						}
						break;
						IL_01b3:
						if (P_0.sourceAxis < 32)
						{
							P_1 = MnqkSgUruMGpGEncQArrqhjEHzFC((DirectInputAxis)P_0.sourceAxis);
							sourceAxisRange = P_0.sourceAxisRange;
							num = 526468697;
						}
						else
						{
							num = 526468700;
						}
						continue;
						IL_0111:
						int num2;
						if (P_1 > 0f)
						{
							num = 526468701;
							num2 = num;
						}
						else
						{
							num = 526468691;
							num2 = num;
						}
					}
					continue;
					end_IL_001e:
					break;
				}
			}
			return false;
		}

		private ControlDeviceType jHVikjhsxtUOFJquUgaKhHLshwI(VSpIeAcJhSiZXYShilsTwSooeUR P_0)
		{
			if (P_0 == VSpIeAcJhSiZXYShilsTwSooeUR.lRyHJPXZVJHsfNLQMHpqapjyFUH)
			{
				goto IL_0005;
			}
			int num;
			if (P_0 == VSpIeAcJhSiZXYShilsTwSooeUR.yCfdhbHfXQEBCYlYpsoIlfGCgZCb)
			{
				num = 1860577453;
			}
			else
			{
				if (P_0 == VSpIeAcJhSiZXYShilsTwSooeUR.vSwPcNwgbxwAqGIFeDWVMWWlXXr)
				{
					return ControlDeviceType.OjRdrXVzVQaGEGzhFLzNjhrLLBZ;
				}
				if (P_0 == VSpIeAcJhSiZXYShilsTwSooeUR.WibnlhrIoppUjEuxjomaVCUrgKFC)
				{
					return ControlDeviceType.nLYuKjOBqUkoTONDQzckmzvJOpb;
				}
				if (P_0 == VSpIeAcJhSiZXYShilsTwSooeUR.BcCwrCtUXfvGEOSXGrXdIPptwV)
				{
					num = 1860577454;
				}
				else
				{
					if (P_0 != VSpIeAcJhSiZXYShilsTwSooeUR.larOafohUcEUGzVzUAioKDEUsyCz)
					{
						return ControlDeviceType.XYhwUwaOlrfFTKoMRqftWpJVYyOD;
					}
					num = 1860577449;
				}
			}
			goto IL_000a;
			IL_0005:
			num = 1860577452;
			goto IL_000a;
			IL_000a:
			switch (num ^ 0x6EE628AD)
			{
			case 2:
				break;
			case 1:
				return ControlDeviceType.GHCARZcZuTQFTJwhHaaINSEOYrk;
			case 0:
				return ControlDeviceType.PuCbofQgRbFngIhqGEvCTItySLuC;
			case 3:
				return ControlDeviceType.slVJNyzujvOPVYaebTJnIMnphpQ;
			default:
				return ControlDeviceType.okYvnDyAHRXTOrFLteeAFEyXCygH;
			}
			goto IL_0005;
		}

		private void HUcWpSluxhNdngRwNRiLQuUWiQb()
		{
			VjkWjnwoPItHtAfScAsiHywgzcu = lzXAqTcTNwGXhyoMQqetZTTNJGjM(XNhjnTKDnPIWYdspfSxvjnotCFBk());
			while (true)
			{
				int num = 1036001229;
				while (true)
				{
					switch (num ^ 0x3DC01FCC)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						if (VjkWjnwoPItHtAfScAsiHywgzcu == null)
						{
							Logger.LogError("Default hardware map not found!");
							num = 1036001230;
							continue;
						}
						goto case 4;
					case 4:
						wqHuqGsJmegTaHkGmUKGpvcrfRfB = VjkWjnwoPItHtAfScAsiHywgzcu.axisCount;
						pIAPquXHYXQpPJRbLVGwvBFcXgk = VjkWjnwoPItHtAfScAsiHywgzcu.buttonCount;
						num = 1036001228;
						continue;
					case 2:
						return;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void qOtmbyGnbUGuOhOSKgNhoHBwfmb()
		{
		}

		private string NjKzlutYxWWemImeoypJtdkBSRZ()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), InputSource.DirectInput, (NxfPDLDjjkkAByWVYHnViSDRJzU && !string.IsNullOrEmpty(ZODLrlcqYgYcHKPIQwZOreOIaYF)) ? ZODLrlcqYgYcHKPIQwZOreOIaYF : AOVTbdgjQpuvVXuOzJgmsvYOWec, fSuJoZmgBMnbZWJgvPaTNrIBkjq, qSJYeLiyjfTRCcMnvDOwuKWJouA));
		}

		private void qHHYDYGCGqOhLRBRJCdFmLOJpwE(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			while (true)
			{
				int num = 2054571650;
				while (true)
				{
					switch (num ^ 0x7A764680)
					{
					case 0:
						break;
					case 2:
						P_0.inputSource = P_0.inputManagerSource;
						P_0.deviceType = jHVikjhsxtUOFJquUgaKhHLshwI(cxWZJvEKbopEslEOJsEPGUSFMLm);
						P_0.hardwareIdentifier = NjKzlutYxWWemImeoypJtdkBSRZ();
						num = 2054571649;
						continue;
					case 1:
						P_0.hardwareAxisCount = jHaYXdTXWAJNlfIRTMsRGaqNBpK;
						num = 2054571651;
						continue;
					case 3:
						P_0.hardwareButtonCount = qOBHYZBCAkYYTJoRDdsZoTyTELA;
						P_0.hardwareHatCount = ByBfmUYbKOERmAjkpxrmtOAORFt;
						P_0.hw_productName = AOVTbdgjQpuvVXuOzJgmsvYOWec;
						P_0.hw_deviceGuid = instanceGuid;
						P_0.hw_productId = fSuJoZmgBMnbZWJgvPaTNrIBkjq;
						P_0.hw_pidVid = new PidVid(qSJYeLiyjfTRCcMnvDOwuKWJouA);
						P_0.hw_isBluetoothDevice = NxfPDLDjjkkAByWVYHnViSDRJzU;
						P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(ZODLrlcqYgYcHKPIQwZOreOIaYF)) ? ZODLrlcqYgYcHKPIQwZOreOIaYF : string.Empty);
						num = 2054571652;
						continue;
					default:
						P_0.definitionMatchTag = cohMCgUaCXDhrXVkwBZFZQUtguG;
						return;
					}
					break;
				}
			}
		}

		private void qHHYDYGCGqOhLRBRJCdFmLOJpwE(BridgedController P_0)
		{
			qHHYDYGCGqOhLRBRJCdFmLOJpwE((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			while (true)
			{
				int num = 2009974425;
				while (true)
				{
					switch (num ^ 0x77CDC69A)
					{
					case 0:
						break;
					default:
						return;
					case 4:
						P_0.controllerTypeGuid = REezjTFCollnzcnDXouNnLNDkjk;
						P_0.controllerExtension = extension;
						num = 2009974427;
						continue;
					case 2:
						P_0.instanceName = mHIfxFeuzrrprIjNQQttDcAWoJX;
						P_0.productName = AOVTbdgjQpuvVXuOzJgmsvYOWec;
						P_0.isXInputDevice = KqmajqZRajQeRJHxvHBZhqVPgsd;
						P_0.axisCount = wqHuqGsJmegTaHkGmUKGpvcrfRfB;
						P_0.buttonCount = pIAPquXHYXQpPJRbLVGwvBFcXgk;
						P_0.unknownControllerHats = BvrTDdaPBgTbGiflYTIoeNsJBMs();
						num = 2009974430;
						continue;
					case 3:
						P_0.gameHardwareMap = VjkWjnwoPItHtAfScAsiHywgzcu.ToGameHardwareControllerMap();
						num = 2009974424;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void WGBBbflLjdHWFEHXzjqWltFbVJT()
		{
			int num = 0;
			int num2 = default(int);
			while (true)
			{
				IL_0056:
				int num3;
				if (num >= pIAPquXHYXQpPJRbLVGwvBFcXgk)
				{
					num2 = 0;
					num3 = -2110742955;
					goto IL_0009;
				}
				goto IL_002e;
				IL_0009:
				while (true)
				{
					switch (num3 ^ -2110742953)
					{
					case 4:
						num3 = -2110742956;
						continue;
					case 3:
						break;
					case 0:
						ZRzHEnKZrARTmYSqzudcOoQkFLn[num2] = 0f;
						num2++;
						num3 = -2110742955;
						continue;
					case 1:
						goto IL_0056;
					case 5:
						num++;
						num3 = -2110742954;
						continue;
					default:
						if (num2 >= wqHuqGsJmegTaHkGmUKGpvcrfRfB)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
				goto IL_002e;
				IL_002e:
				vqZyMIbiZNaMpemrDPhgsXmGAKrY[num] = false;
				num3 = -2110742958;
				goto IL_0009;
			}
		}

		private UnknownControllerHat[] BvrTDdaPBgTbGiflYTIoeNsJBMs()
		{
			if (!yRialUFBmVuFTOVrRxRadMBTRymj)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			int num = 0;
			int num4 = default(int);
			int[] array2 = default(int[]);
			while (true)
			{
				int num2;
				int num3;
				if (num >= 2)
				{
					num2 = 1271445479;
					num3 = num2;
				}
				else
				{
					num2 = 1271445472;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x4BC8B7E3)
					{
					case 0:
						num2 = 1271445472;
						continue;
					case 3:
						num4 = 128 + num * 8;
						num2 = 1271445476;
						continue;
					case 6:
						array2[0] = num4;
						array2[1] = num4 + 1;
						array2[2] = num4 + 2;
						array2[3] = num4 + 3;
						array2[4] = num4 + 4;
						num2 = 1271445474;
						continue;
					case 1:
						array2[5] = num4 + 5;
						num2 = 1271445478;
						continue;
					case 7:
						array2 = new int[8];
						num2 = 1271445477;
						continue;
					case 2:
						break;
					case 5:
					{
						array2[6] = num4 + 6;
						array2[7] = num4 + 7;
						UnknownControllerHat.HatButtons buttons = new UnknownControllerHat.HatButtons(array2);
						array[num] = new UnknownControllerHat(buttons);
						num++;
						num2 = 1271445473;
						continue;
					}
					default:
						return array;
					}
					break;
				}
			}
		}

		public void HtJdxRxaGggkmaMTSWUpHqjZLDV()
		{
			HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
			GC.SuppressFinalize(this);
		}

		~cyCsYcIQvugVJDWuUYpaIfgIudW()
		{
			HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
		}

		protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
		{
			if (nNxUslIcGUpqKgpPZYhuimcvWyC)
			{
				goto IL_0008;
			}
			goto IL_003c;
			IL_0008:
			int num = -1975694749;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1975694745)
			{
			case 2:
				break;
			default:
				return;
			case 3:
				goto IL_002e;
			case 0:
				goto IL_003c;
			case 4:
				return;
			case 1:
				return;
			}
			goto IL_0008;
			IL_003c:
			if (P_0 && eunhnaovDRiEguPGzwjEMBJUohX != null)
			{
				eunhnaovDRiEguPGzwjEMBJUohX.Dispose();
				num = -1975694748;
				goto IL_000d;
			}
			goto IL_002e;
			IL_002e:
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
			num = -1975694746;
			goto IL_000d;
		}

		public static int aMOFswEFvnllveRohVGHhoVLgfBv(cyCsYcIQvugVJDWuUYpaIfgIudW P_0, cyCsYcIQvugVJDWuUYpaIfgIudW P_1)
		{
			if (P_0.CcAaBYTnhTzbmiXXmdIizsUxQeD < P_1.CcAaBYTnhTzbmiXXmdIizsUxQeD)
			{
				return -1;
			}
			if (P_0.CcAaBYTnhTzbmiXXmdIizsUxQeD > P_1.CcAaBYTnhTzbmiXXmdIizsUxQeD)
			{
				return 1;
			}
			return 0;
		}

		public static int VeEwuyjQGIUrXMVDUTRgFgYWfdL(cyCsYcIQvugVJDWuUYpaIfgIudW P_0, cyCsYcIQvugVJDWuUYpaIfgIudW P_1)
		{
			if (P_0.ySxHACCmrqwNquIhkRqoFdufNKj < P_1.ySxHACCmrqwNquIhkRqoFdufNKj)
			{
				return -1;
			}
			if (P_0.ySxHACCmrqwNquIhkRqoFdufNKj > P_1.ySxHACCmrqwNquIhkRqoFdufNKj)
			{
				return 1;
			}
			return 0;
		}
	}

	private class pWuCkUBcnuhLuBWirlcUCWkKvpMO : IDisposable
	{
		private const int ApuPFWSaNsSIEXXjCEaPGAKxcYB = 2;

		private const int iyZEqFVfCcXspXSvNLVuiPvKCPL = 2;

		private const int RaghPUHnxCamDAuczDeFURiGSlFu = 128;

		private const int UlDDYCdVymiKJjuYXyqUJCvkvUk = 0;

		private const int mkkPnwiLLXibqCKRxZncAlbdnPt = 264;

		private const int UoBGMiwtFbGGgMIkFjAlZAErEZXE = 268;

		private readonly int fnovMDLsEFplBmyRxsHQABHgwLo;

		private readonly ButtonLoopSet pXAzDifhoXFJwfIXqMsgHECKSEm;

		private readonly DualRingReportBuffer qvuNgTOqQqzmDTdOGQncQRLIaXZ;

		public readonly jsQodzWnVXxJhIsULuSibIHUoCH EAHBveZYCGolVbLQhYJNUosGdcUg;

		private readonly HEnqjDCbQatLClXKVNYOqMCtdXr gXKkREVAhzYhcKWqZWZAIHiGowp;

		private xNjzZKZsYixpNcZEiPzXmWzQyML fCJSdapYWhyjodCtParErmmkFLF;

		private readonly HEnqjDCbQatLClXKVNYOqMCtdXr EQloNeWxFMnjrjCwAkLuyKVrzAd;

		private readonly object jcpIvANnmImkcgQUNGcxgIqVBMvA;

		private byte[] lvyljsZgCBtZevhOgnmgCOEgXrB;

		private byte[] skskEOIStmEVWAKpJbMnFOIehkPH;

		private bool bajsMqGhZRtVJqqeQtegeORbUav;

		private HEnqjDCbQatLClXKVNYOqMCtdXr aDDiRKkPMINvmZnNPkdVjTAuTMNN;

		private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

		public bool[] CurrentButtonValues
		{
			get
			{
				return pXAzDifhoXFJwfIXqMsgHECKSEm.Current.effectiveValue;
			}
		}

		public HEnqjDCbQatLClXKVNYOqMCtdXr joystickState
		{
			get
			{
				return aDDiRKkPMINvmZnNPkdVjTAuTMNN;
			}
		}

		public pWuCkUBcnuhLuBWirlcUCWkKvpMO(jsQodzWnVXxJhIsULuSibIHUoCH source, UpdateLoopSetting updateLoops)
		{
			EAHBveZYCGolVbLQhYJNUosGdcUg = source;
			fnovMDLsEFplBmyRxsHQABHgwLo = source.Capabilities.lwPieGbLEzAskWvJIoFcuwJwQsU;
			qvuNgTOqQqzmDTdOGQncQRLIaXZ = new DualRingReportBuffer(268, 25);
			pXAzDifhoXFJwfIXqMsgHECKSEm = new ButtonLoopSet(updateLoops, fnovMDLsEFplBmyRxsHQABHgwLo);
			lvyljsZgCBtZevhOgnmgCOEgXrB = qvuNgTOqQqzmDTdOGQncQRLIaXZ.ReadBuffer;
			skskEOIStmEVWAKpJbMnFOIehkPH = new byte[268];
			gXKkREVAhzYhcKWqZWZAIHiGowp = new HEnqjDCbQatLClXKVNYOqMCtdXr();
			aDDiRKkPMINvmZnNPkdVjTAuTMNN = gXKkREVAhzYhcKWqZWZAIHiGowp;
			bVJfbjSJHtCUhxVYYaQYFCJuPMDE(gXKkREVAhzYhcKWqZWZAIHiGowp);
			EQloNeWxFMnjrjCwAkLuyKVrzAd = new HEnqjDCbQatLClXKVNYOqMCtdXr();
			bVJfbjSJHtCUhxVYYaQYFCJuPMDE(EQloNeWxFMnjrjCwAkLuyKVrzAd);
			jcpIvANnmImkcgQUNGcxgIqVBMvA = new object();
			if (rdYCGoWOpFzeWopaszcDvgrUprf.joystickInputThread != null)
			{
				rdYCGoWOpFzeWopaszcDvgrUprf.joystickInputThread.ThreadUpdateEvent += VVbBqMUVXFFvYcoldZTHutTtVAZV;
			}
		}

		public void MvfYUGonPatKegPtmGgJekuNwNXV()
		{
			pXAzDifhoXFJwfIXqMsgHECKSEm.SetUpdateLoop(ReInput.currentUpdateLoop);
			RqiXUWygpDKnPpQsspdWYYaqntD(gXKkREVAhzYhcKWqZWZAIHiGowp);
			if (fCJSdapYWhyjodCtParErmmkFLF == null)
			{
				return;
			}
			while (true)
			{
				int num = -23159313;
				while (true)
				{
					switch (num ^ -23159314)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0042;
					case 0:
						return;
					}
					break;
					IL_0042:
					fCJSdapYWhyjodCtParErmmkFLF.EhlPnfprjfkehAbDLrDcQKRlXmc(ReInput.realTime);
					num = -23159314;
				}
			}
		}

		public void cHQDtHxqOBHMTeDoAMAnUqYwlCyL()
		{
			pXAzDifhoXFJwfIXqMsgHECKSEm.Current.ClearWasTrueThisFrame();
		}

		public void MyJyGjmCwusbhiQFfrODGPnUwSK()
		{
			bajsMqGhZRtVJqqeQtegeORbUav = true;
		}

		public void zHIDjadCrmciEDxyqlukcUUEQZwZ()
		{
			bajsMqGhZRtVJqqeQtegeORbUav = false;
			UsuwPiqVitnNRnZALvWAYQYnQRS();
		}

		public void qmxqFhOXPynIFVlddeYJeiHLrJIQ(pWuCkUBcnuhLuBWirlcUCWkKvpMO P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_004c;
			IL_0003:
			int num = -1115309508;
			goto IL_0008;
			IL_0008:
			switch (num ^ -1115309512)
			{
			case 2:
				break;
			case 5:
				goto IL_002d;
			case 0:
				goto IL_004c;
			case 4:
				return;
			case 3:
				return;
			default:
			{
				float realTime = ReInput.realTime;
				lock (jcpIvANnmImkcgQUNGcxgIqVBMvA)
				{
					lock (P_0.jcpIvANnmImkcgQUNGcxgIqVBMvA)
					{
						pXAzDifhoXFJwfIXqMsgHECKSEm.Import(P_0.pXAzDifhoXFJwfIXqMsgHECKSEm);
						nGyCVbRHPbAhkFRHkVyhlLMdlpe(P_0.gXKkREVAhzYhcKWqZWZAIHiGowp, realTime, skskEOIStmEVWAKpJbMnFOIehkPH);
						while (true)
						{
							int num2 = -1115309511;
							while (true)
							{
								switch (num2 ^ -1115309512)
								{
								case 3:
									break;
								case 1:
									tQlksdDGlwRJJNfJUgHxDuIxPW(skskEOIStmEVWAKpJbMnFOIehkPH, gXKkREVAhzYhcKWqZWZAIHiGowp);
									nGyCVbRHPbAhkFRHkVyhlLMdlpe(P_0.EQloNeWxFMnjrjCwAkLuyKVrzAd, realTime, skskEOIStmEVWAKpJbMnFOIehkPH);
									num2 = -1115309507;
									continue;
								case 4:
								{
									fCJSdapYWhyjodCtParErmmkFLF = xNjzZKZsYixpNcZEiPzXmWzQyML.DDWbYYywIOsYdfLNFWyeGZPSJXL(P_0.fCJSdapYWhyjodCtParErmmkFLF, gXKkREVAhzYhcKWqZWZAIHiGowp);
									int num3;
									if (fCJSdapYWhyjodCtParErmmkFLF == null)
									{
										num2 = -1115309512;
										num3 = num2;
									}
									else
									{
										num2 = -1115309510;
										num3 = num2;
									}
									continue;
								}
								case 2:
									aDDiRKkPMINvmZnNPkdVjTAuTMNN = fCJSdapYWhyjodCtParErmmkFLF.state;
									num2 = -1115309512;
									continue;
								case 5:
									tQlksdDGlwRJJNfJUgHxDuIxPW(skskEOIStmEVWAKpJbMnFOIehkPH, EQloNeWxFMnjrjCwAkLuyKVrzAd);
									num2 = -1115309508;
									continue;
								default:
									bajsMqGhZRtVJqqeQtegeORbUav = P_0.bajsMqGhZRtVJqqeQtegeORbUav;
									return;
								}
								break;
							}
						}
					}
				}
			}
			}
			goto IL_0003;
			IL_004c:
			if (P_0 == this)
			{
				return;
			}
			goto IL_002d;
			IL_002d:
			int num4;
			if (P_0.fnovMDLsEFplBmyRxsHQABHgwLo == fnovMDLsEFplBmyRxsHQABHgwLo)
			{
				num = -1115309511;
				num4 = num;
			}
			else
			{
				num = -1115309509;
				num4 = num;
			}
			goto IL_0008;
		}

		public void VQfeYTXiqbpfQIXoEgEmPJxNliY(int P_0, int P_1, int P_2, float P_3)
		{
			fCJSdapYWhyjodCtParErmmkFLF = new xNjzZKZsYixpNcZEiPzXmWzQyML(gXKkREVAhzYhcKWqZWZAIHiGowp, P_0, P_1, P_2, P_3);
			aDDiRKkPMINvmZnNPkdVjTAuTMNN = fCJSdapYWhyjodCtParErmmkFLF.state;
		}

		private void VVbBqMUVXFFvYcoldZTHutTtVAZV()
		{
			if (!bajsMqGhZRtVJqqeQtegeORbUav)
			{
				while (true)
				{
					switch (0x3451562C ^ 0x3451562D)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			lock (jcpIvANnmImkcgQUNGcxgIqVBMvA)
			{
				float realTime;
				try
				{
					EAHBveZYCGolVbLQhYJNUosGdcUg.yqeNqBsXzabfJkPcTUdPXlXHRpJ(EQloNeWxFMnjrjCwAkLuyKVrzAd);
					realTime = ReInput.realTime;
				}
				catch
				{
					return;
				}
				nGyCVbRHPbAhkFRHkVyhlLMdlpe(EQloNeWxFMnjrjCwAkLuyKVrzAd, realTime, skskEOIStmEVWAKpJbMnFOIehkPH);
				qvuNgTOqQqzmDTdOGQncQRLIaXZ.Write(skskEOIStmEVWAKpJbMnFOIehkPH, 268);
			}
		}

		private unsafe void RqiXUWygpDKnPpQsspdWYYaqntD(HEnqjDCbQatLClXKVNYOqMCtdXr P_0)
		{
			int num = qvuNgTOqQqzmDTdOGQncQRLIaXZ.StartRead() / 268;
			if (num == 0)
			{
				return;
			}
			bool[] buttons = P_0.Buttons;
			while (qvuNgTOqQqzmDTdOGQncQRLIaXZ.Read() > 0)
			{
				if (num > 1)
				{
					for (int i = 0; i < fnovMDLsEFplBmyRxsHQABHgwLo; i++)
					{
						buttons[i] = lvyljsZgCBtZevhOgnmgCOEgXrB[i] != 0;
					}
				}
				else
				{
					tQlksdDGlwRJJNfJUgHxDuIxPW(lvyljsZgCBtZevhOgnmgCOEgXrB, P_0);
				}
				float timestamp;
				fixed (byte* ptr = lvyljsZgCBtZevhOgnmgCOEgXrB)
				{
					timestamp = ((float*)ptr)[66];
				}
				for (int j = 0; j < fnovMDLsEFplBmyRxsHQABHgwLo; j++)
				{
					pXAzDifhoXFJwfIXqMsgHECKSEm.SetValue(j, buttons[j], timestamp);
				}
				num--;
			}
		}

		private unsafe void tQlksdDGlwRJJNfJUgHxDuIxPW(byte[] P_0, HEnqjDCbQatLClXKVNYOqMCtdXr P_1)
		{
			fixed (byte* ptr = P_0)
			{
				int* ptr2 = (int*)ptr;
				int[] pointOfViewControllers = P_1.PointOfViewControllers;
				int[] accelerationSliders = P_1.AccelerationSliders;
				int[] forceSliders = P_1.ForceSliders;
				int[] sliders = P_1.Sliders;
				int[] velocitySliders = P_1.VelocitySliders;
				fixed (bool* buttons = P_1.Buttons)
				{
					Marshal.Copy(P_0, 0, (IntPtr)buttons, 128);
				}
				ptr2 += 32;
				for (int i = 0; i < 2; i++)
				{
					accelerationSliders[i] = *ptr2;
					ptr2++;
				}
				P_1.AccelerationX = *ptr2;
				ptr2++;
				P_1.AccelerationY = *ptr2;
				ptr2++;
				P_1.AccelerationZ = *ptr2;
				ptr2++;
				P_1.AngularAccelerationX = *ptr2;
				ptr2++;
				P_1.AngularAccelerationY = *ptr2;
				ptr2++;
				P_1.AngularAccelerationZ = *ptr2;
				ptr2++;
				P_1.AngularVelocityX = *ptr2;
				ptr2++;
				P_1.AngularVelocityY = *ptr2;
				ptr2++;
				P_1.AngularVelocityZ = *ptr2;
				ptr2++;
				for (int j = 0; j < 2; j++)
				{
					forceSliders[j] = *ptr2;
					ptr2++;
				}
				P_1.ForceX = *ptr2;
				ptr2++;
				P_1.ForceY = *ptr2;
				ptr2++;
				P_1.ForceZ = *ptr2;
				ptr2++;
				for (int k = 0; k < 2; k++)
				{
					pointOfViewControllers[k] = *ptr2;
					ptr2++;
				}
				P_1.RotationX = *ptr2;
				ptr2++;
				P_1.RotationY = *ptr2;
				ptr2++;
				P_1.RotationZ = *ptr2;
				ptr2++;
				for (int l = 0; l < 2; l++)
				{
					sliders[l] = *ptr2;
					ptr2++;
				}
				P_1.TorqueX = *ptr2;
				ptr2++;
				P_1.TorqueY = *ptr2;
				ptr2++;
				P_1.TorqueZ = *ptr2;
				ptr2++;
				for (int m = 0; m < 2; m++)
				{
					velocitySliders[m] = *ptr2;
					ptr2++;
				}
				P_1.VelocityX = *ptr2;
				ptr2++;
				P_1.VelocityY = *ptr2;
				ptr2++;
				P_1.VelocityZ = *ptr2;
				ptr2++;
				P_1.X = *ptr2;
				ptr2++;
				P_1.Y = *ptr2;
				ptr2++;
				P_1.Z = *ptr2;
				ptr2++;
			}
		}

		private unsafe void nGyCVbRHPbAhkFRHkVyhlLMdlpe(HEnqjDCbQatLClXKVNYOqMCtdXr P_0, float P_1, byte[] P_2)
		{
			fixed (byte* ptr = P_2)
			{
				int* ptr2 = (int*)ptr;
				int[] pointOfViewControllers = P_0.PointOfViewControllers;
				int[] accelerationSliders = P_0.AccelerationSliders;
				int[] forceSliders = P_0.ForceSliders;
				int[] sliders = P_0.Sliders;
				int[] velocitySliders = P_0.VelocitySliders;
				fixed (bool* buttons = P_0.Buttons)
				{
					Marshal.Copy((IntPtr)buttons, P_2, 0, 128);
				}
				ptr2 += 32;
				for (int i = 0; i < 2; i++)
				{
					*ptr2 = accelerationSliders[i];
					ptr2++;
				}
				*ptr2 = P_0.AccelerationX;
				ptr2++;
				*ptr2 = P_0.AccelerationY;
				ptr2++;
				*ptr2 = P_0.AccelerationZ;
				ptr2++;
				*ptr2 = P_0.AngularAccelerationX;
				ptr2++;
				*ptr2 = P_0.AngularAccelerationY;
				ptr2++;
				*ptr2 = P_0.AngularAccelerationZ;
				ptr2++;
				*ptr2 = P_0.AngularVelocityX;
				ptr2++;
				*ptr2 = P_0.AngularVelocityY;
				ptr2++;
				*ptr2 = P_0.AngularVelocityZ;
				ptr2++;
				for (int j = 0; j < 2; j++)
				{
					*ptr2 = forceSliders[j];
					ptr2++;
				}
				*ptr2 = P_0.ForceX;
				ptr2++;
				*ptr2 = P_0.ForceY;
				ptr2++;
				*ptr2 = P_0.ForceZ;
				ptr2++;
				for (int k = 0; k < 2; k++)
				{
					*ptr2 = pointOfViewControllers[k];
					ptr2++;
				}
				*ptr2 = P_0.RotationX;
				ptr2++;
				*ptr2 = P_0.RotationY;
				ptr2++;
				*ptr2 = P_0.RotationZ;
				ptr2++;
				for (int l = 0; l < 2; l++)
				{
					*ptr2 = sliders[l];
					ptr2++;
				}
				*ptr2 = P_0.TorqueX;
				ptr2++;
				*ptr2 = P_0.TorqueY;
				ptr2++;
				*ptr2 = P_0.TorqueZ;
				ptr2++;
				for (int m = 0; m < 2; m++)
				{
					*ptr2 = velocitySliders[m];
					ptr2++;
				}
				*ptr2 = P_0.VelocityX;
				ptr2++;
				*ptr2 = P_0.VelocityY;
				ptr2++;
				*ptr2 = P_0.VelocityZ;
				ptr2++;
				*ptr2 = P_0.X;
				ptr2++;
				*ptr2 = P_0.Y;
				ptr2++;
				*ptr2 = P_0.Z;
				ptr2++;
				*(float*)ptr2 = P_1;
				ptr2++;
			}
		}

		private void UsuwPiqVitnNRnZALvWAYQYnQRS()
		{
			lock (jcpIvANnmImkcgQUNGcxgIqVBMvA)
			{
				qvuNgTOqQqzmDTdOGQncQRLIaXZ.Clear();
				bVJfbjSJHtCUhxVYYaQYFCJuPMDE(EQloNeWxFMnjrjCwAkLuyKVrzAd);
				bVJfbjSJHtCUhxVYYaQYFCJuPMDE(gXKkREVAhzYhcKWqZWZAIHiGowp);
			}
		}

		private void bVJfbjSJHtCUhxVYYaQYFCJuPMDE(HEnqjDCbQatLClXKVNYOqMCtdXr P_0)
		{
			if (P_0 != null)
			{
				Array.Clear(P_0.Buttons, 0, 128);
				Array.Clear(P_0.AccelerationSliders, 0, 2);
				P_0.AccelerationX = 0;
				P_0.AccelerationY = 0;
				P_0.AccelerationZ = 0;
				P_0.AngularAccelerationX = 0;
				P_0.AngularAccelerationY = 0;
				P_0.AngularAccelerationZ = 0;
				P_0.AngularVelocityX = 0;
				P_0.AngularVelocityY = 0;
				P_0.AngularVelocityZ = 0;
				Array.Clear(P_0.ForceSliders, 0, 2);
				P_0.ForceX = 0;
				P_0.ForceY = 0;
				P_0.ForceZ = 0;
				for (int i = 0; i < 2; i++)
				{
					P_0.PointOfViewControllers[i] = -1;
				}
				P_0.RotationX = 0;
				P_0.RotationY = 0;
				P_0.RotationZ = 0;
				Array.Clear(P_0.Sliders, 0, 2);
				P_0.TorqueX = 0;
				P_0.TorqueY = 0;
				P_0.TorqueZ = 0;
				Array.Clear(P_0.VelocitySliders, 0, 2);
				P_0.VelocityX = 0;
				P_0.VelocityY = 0;
				P_0.VelocityZ = 0;
				P_0.X = 0;
				P_0.Y = 0;
				P_0.Z = 0;
			}
		}

		public void Dispose()
		{
			HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
			GC.SuppressFinalize(this);
		}

		~pWuCkUBcnuhLuBWirlcUCWkKvpMO()
		{
			HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
		}

		protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
		{
			if (nNxUslIcGUpqKgpPZYhuimcvWyC)
			{
				return;
			}
			while (true)
			{
				int num;
				if (P_0)
				{
					zHIDjadCrmciEDxyqlukcUUEQZwZ();
					num = -964809358;
					goto IL_000e;
				}
				goto IL_003b;
				IL_000e:
				while (true)
				{
					switch (num ^ -964809359)
					{
					case 0:
						num = -964809360;
						continue;
					case 1:
						break;
					case 3:
						goto IL_003b;
					default:
						goto end_IL_002b;
					}
					break;
				}
				continue;
				IL_003b:
				if (rdYCGoWOpFzeWopaszcDvgrUprf.joystickInputThread == null)
				{
					break;
				}
				rdYCGoWOpFzeWopaszcDvgrUprf.joystickInputThread.ThreadUpdateEvent -= VVbBqMUVXFFvYcoldZTHutTtVAZV;
				num = -964809357;
				goto IL_000e;
				continue;
				end_IL_002b:
				break;
			}
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
		}
	}

	private class xNjzZKZsYixpNcZEiPzXmWzQyML
	{
		private HEnqjDCbQatLClXKVNYOqMCtdXr MDmoSJqQwdByaCpExScUhRaYQTx;

		private dMsbFMJyGaNzEGFkrikbckxkzSFi eEBkrMePIliXvHelSnzwvrvvfrHF;

		private int CmgsdQPxQAGgtcxkMqQbNfvhTEr;

		private int ZfbYjzNwFBiWjljCFJeqPWqFqkC;

		private int DqcdaeyGjZylyXIBydPouzmxENm;

		private float DyRoRwHFbJhCfomAHRoSpwCnsXM;

		public HEnqjDCbQatLClXKVNYOqMCtdXr state
		{
			get
			{
				return MDmoSJqQwdByaCpExScUhRaYQTx;
			}
		}

		public static xNjzZKZsYixpNcZEiPzXmWzQyML DDWbYYywIOsYdfLNFWyeGZPSJXL(xNjzZKZsYixpNcZEiPzXmWzQyML P_0, HEnqjDCbQatLClXKVNYOqMCtdXr P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new xNjzZKZsYixpNcZEiPzXmWzQyML(P_0, P_1);
		}

		public xNjzZKZsYixpNcZEiPzXmWzQyML(HEnqjDCbQatLClXKVNYOqMCtdXr state, int axisMin, int axisMax, int axisZero, float eventTimeout)
			: this(axisMin, axisMax, axisZero, eventTimeout)
		{
			eEBkrMePIliXvHelSnzwvrvvfrHF = new dMsbFMJyGaNzEGFkrikbckxkzSFi(state);
			MDmoSJqQwdByaCpExScUhRaYQTx = new HEnqjDCbQatLClXKVNYOqMCtdXr();
		}

		private xNjzZKZsYixpNcZEiPzXmWzQyML(xNjzZKZsYixpNcZEiPzXmWzQyML source, HEnqjDCbQatLClXKVNYOqMCtdXr state)
			: this(state, source.CmgsdQPxQAGgtcxkMqQbNfvhTEr, source.ZfbYjzNwFBiWjljCFJeqPWqFqkC, source.DqcdaeyGjZylyXIBydPouzmxENm, source.DyRoRwHFbJhCfomAHRoSpwCnsXM)
		{
			BbMlThpVHekUMrpjNzGQUGtzMyI(source);
		}

		private xNjzZKZsYixpNcZEiPzXmWzQyML(int axisMin, int axisMax, int axisZero, float axisTimeout)
		{
			CmgsdQPxQAGgtcxkMqQbNfvhTEr = axisMin;
			ZfbYjzNwFBiWjljCFJeqPWqFqkC = axisMax;
			DqcdaeyGjZylyXIBydPouzmxENm = axisZero;
			DyRoRwHFbJhCfomAHRoSpwCnsXM = axisTimeout;
		}

		public void EhlPnfprjfkehAbDLrDcQKRlXmc(float P_0)
		{
			eEBkrMePIliXvHelSnzwvrvvfrHF.EhlPnfprjfkehAbDLrDcQKRlXmc(P_0);
			if (!eEBkrMePIliXvHelSnzwvrvvfrHF.valueChanged)
			{
				if (P_0 >= eEBkrMePIliXvHelSnzwvrvvfrHF.lastChangedTimestamp + DyRoRwHFbJhCfomAHRoSpwCnsXM)
				{
					MDmoSJqQwdByaCpExScUhRaYQTx.bVJfbjSJHtCUhxVYYaQYFCJuPMDE();
				}
				return;
			}
			int num10 = default(int);
			int num3 = default(int);
			int num2 = default(int);
			int num5 = default(int);
			int num7 = default(int);
			int num4 = default(int);
			while (true)
			{
				HEnqjDCbQatLClXKVNYOqMCtdXr changedState = eEBkrMePIliXvHelSnzwvrvvfrHF.changedState;
				HEnqjDCbQatLClXKVNYOqMCtdXr sourceState = eEBkrMePIliXvHelSnzwvrvvfrHF.sourceState;
				MDmoSJqQwdByaCpExScUhRaYQTx.X = ZzwTLsBTamRqURFizogIiEojxuj(changedState.X);
				MDmoSJqQwdByaCpExScUhRaYQTx.Y = ZzwTLsBTamRqURFizogIiEojxuj(changedState.Y);
				int num = 395385807;
				while (true)
				{
					switch (num ^ 0x17911BCC)
					{
					case 24:
						num = 395385822;
						continue;
					default:
						return;
					case 17:
						MDmoSJqQwdByaCpExScUhRaYQTx.AccelerationSliders[num10] = ZzwTLsBTamRqURFizogIiEojxuj(changedState.AccelerationSliders[num10]);
						num10++;
						num = 395385802;
						continue;
					case 7:
						if (num3 >= MDmoSJqQwdByaCpExScUhRaYQTx.Buttons.Length)
						{
							MDmoSJqQwdByaCpExScUhRaYQTx.VelocityX = ZzwTLsBTamRqURFizogIiEojxuj(changedState.VelocityX);
							MDmoSJqQwdByaCpExScUhRaYQTx.VelocityY = ZzwTLsBTamRqURFizogIiEojxuj(changedState.VelocityY);
							MDmoSJqQwdByaCpExScUhRaYQTx.VelocityZ = ZzwTLsBTamRqURFizogIiEojxuj(changedState.VelocityZ);
							num = 395385805;
							continue;
						}
						goto case 28;
					case 10:
						MDmoSJqQwdByaCpExScUhRaYQTx.Sliders[num2] = ZzwTLsBTamRqURFizogIiEojxuj(changedState.Sliders[num2]);
						num = 395385804;
						continue;
					case 26:
						MDmoSJqQwdByaCpExScUhRaYQTx.AngularAccelerationY = ZzwTLsBTamRqURFizogIiEojxuj(changedState.AngularAccelerationY);
						num = 395385817;
						continue;
					case 18:
						break;
					case 22:
						MDmoSJqQwdByaCpExScUhRaYQTx.PointOfViewControllers[num5] = ZzwTLsBTamRqURFizogIiEojxuj(changedState.PointOfViewControllers[num5]);
						num5++;
						num = 395385813;
						continue;
					case 27:
						MDmoSJqQwdByaCpExScUhRaYQTx.ForceSliders[num7] = ZzwTLsBTamRqURFizogIiEojxuj(changedState.ForceSliders[num7]);
						num = 395385820;
						continue;
					case 21:
						MDmoSJqQwdByaCpExScUhRaYQTx.AngularAccelerationZ = ZzwTLsBTamRqURFizogIiEojxuj(changedState.AngularAccelerationZ);
						num10 = 0;
						num = 395385802;
						continue;
					case 20:
						MDmoSJqQwdByaCpExScUhRaYQTx.TorqueX = ZzwTLsBTamRqURFizogIiEojxuj(changedState.TorqueX);
						MDmoSJqQwdByaCpExScUhRaYQTx.TorqueY = ZzwTLsBTamRqURFizogIiEojxuj(changedState.TorqueY);
						MDmoSJqQwdByaCpExScUhRaYQTx.TorqueZ = ZzwTLsBTamRqURFizogIiEojxuj(changedState.TorqueZ);
						num7 = 0;
						num = 395385795;
						continue;
					case 1:
						MDmoSJqQwdByaCpExScUhRaYQTx.AngularVelocityX = ZzwTLsBTamRqURFizogIiEojxuj(changedState.AngularVelocityX);
						MDmoSJqQwdByaCpExScUhRaYQTx.AngularVelocityY = ZzwTLsBTamRqURFizogIiEojxuj(changedState.AngularVelocityY);
						MDmoSJqQwdByaCpExScUhRaYQTx.AngularVelocityZ = ZzwTLsBTamRqURFizogIiEojxuj(changedState.AngularVelocityZ);
						num4 = 0;
						num = 395385800;
						continue;
					case 6:
						if (num10 >= MDmoSJqQwdByaCpExScUhRaYQTx.AccelerationSliders.Length)
						{
							MDmoSJqQwdByaCpExScUhRaYQTx.ForceX = ZzwTLsBTamRqURFizogIiEojxuj(changedState.ForceX);
							MDmoSJqQwdByaCpExScUhRaYQTx.ForceY = ZzwTLsBTamRqURFizogIiEojxuj(changedState.ForceY);
							num = 395385797;
							continue;
						}
						goto case 17;
					case 16:
						num7++;
						num = 395385795;
						continue;
					case 3:
						MDmoSJqQwdByaCpExScUhRaYQTx.Z = ZzwTLsBTamRqURFizogIiEojxuj(changedState.Z);
						num = 395385796;
						continue;
					case 28:
						MDmoSJqQwdByaCpExScUhRaYQTx.Buttons[num3] = sourceState.Buttons[num3];
						num3++;
						num = 395385803;
						continue;
					case 9:
						MDmoSJqQwdByaCpExScUhRaYQTx.ForceZ = ZzwTLsBTamRqURFizogIiEojxuj(changedState.ForceZ);
						num = 395385816;
						continue;
					case 4:
					{
						int num9;
						if (num4 >= MDmoSJqQwdByaCpExScUhRaYQTx.VelocitySliders.Length)
						{
							num = 395385792;
							num9 = num;
						}
						else
						{
							num = 395385823;
							num9 = num;
						}
						continue;
					}
					case 15:
					{
						int num8;
						if (num7 >= MDmoSJqQwdByaCpExScUhRaYQTx.ForceSliders.Length)
						{
							num = 395385793;
							num8 = num;
						}
						else
						{
							num = 395385815;
							num8 = num;
						}
						continue;
					}
					case 8:
						MDmoSJqQwdByaCpExScUhRaYQTx.RotationX = ZzwTLsBTamRqURFizogIiEojxuj(changedState.RotationX);
						MDmoSJqQwdByaCpExScUhRaYQTx.RotationY = ZzwTLsBTamRqURFizogIiEojxuj(changedState.RotationY);
						MDmoSJqQwdByaCpExScUhRaYQTx.RotationZ = ZzwTLsBTamRqURFizogIiEojxuj(changedState.RotationZ);
						num2 = 0;
						num = 395385799;
						continue;
					case 23:
						num = 395385803;
						continue;
					case 14:
						MDmoSJqQwdByaCpExScUhRaYQTx.AccelerationY = ZzwTLsBTamRqURFizogIiEojxuj(changedState.AccelerationY);
						MDmoSJqQwdByaCpExScUhRaYQTx.AccelerationZ = ZzwTLsBTamRqURFizogIiEojxuj(changedState.AccelerationZ);
						MDmoSJqQwdByaCpExScUhRaYQTx.AngularAccelerationX = ZzwTLsBTamRqURFizogIiEojxuj(changedState.AngularAccelerationX);
						num = 395385814;
						continue;
					case 5:
						if (num2 >= MDmoSJqQwdByaCpExScUhRaYQTx.Sliders.Length)
						{
							num5 = 0;
							num = 395385813;
							continue;
						}
						goto case 10;
					case 25:
					{
						int num6;
						if (num5 < MDmoSJqQwdByaCpExScUhRaYQTx.PointOfViewControllers.Length)
						{
							num = 395385818;
							num6 = num;
						}
						else
						{
							num = 395385806;
							num6 = num;
						}
						continue;
					}
					case 11:
						num = 395385801;
						continue;
					case 12:
						MDmoSJqQwdByaCpExScUhRaYQTx.AccelerationX = ZzwTLsBTamRqURFizogIiEojxuj(changedState.AccelerationX);
						num = 395385794;
						continue;
					case 19:
						MDmoSJqQwdByaCpExScUhRaYQTx.VelocitySliders[num4] = ZzwTLsBTamRqURFizogIiEojxuj(changedState.VelocitySliders[num4]);
						num4++;
						num = 395385800;
						continue;
					case 2:
						num3 = 0;
						num = 395385819;
						continue;
					case 0:
						num2++;
						num = 395385801;
						continue;
					case 13:
						return;
					}
					break;
				}
			}
		}

		public void BbMlThpVHekUMrpjNzGQUGtzMyI(xNjzZKZsYixpNcZEiPzXmWzQyML P_0)
		{
			MDmoSJqQwdByaCpExScUhRaYQTx.BbMlThpVHekUMrpjNzGQUGtzMyI(P_0.MDmoSJqQwdByaCpExScUhRaYQTx);
			eEBkrMePIliXvHelSnzwvrvvfrHF.BbMlThpVHekUMrpjNzGQUGtzMyI(P_0.eEBkrMePIliXvHelSnzwvrvvfrHF);
			while (true)
			{
				int num = -1706334597;
				while (true)
				{
					switch (num ^ -1706334598)
					{
					case 3:
						break;
					case 1:
						CmgsdQPxQAGgtcxkMqQbNfvhTEr = P_0.CmgsdQPxQAGgtcxkMqQbNfvhTEr;
						num = -1706334598;
						continue;
					case 0:
						ZfbYjzNwFBiWjljCFJeqPWqFqkC = P_0.ZfbYjzNwFBiWjljCFJeqPWqFqkC;
						DqcdaeyGjZylyXIBydPouzmxENm = P_0.DqcdaeyGjZylyXIBydPouzmxENm;
						num = -1706334600;
						continue;
					default:
						DyRoRwHFbJhCfomAHRoSpwCnsXM = P_0.DyRoRwHFbJhCfomAHRoSpwCnsXM;
						return;
					}
					break;
				}
			}
		}

		private int ZzwTLsBTamRqURFizogIiEojxuj(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, CmgsdQPxQAGgtcxkMqQbNfvhTEr, ZfbYjzNwFBiWjljCFJeqPWqFqkC, -65535, 65535);
		}
	}

	private class dMsbFMJyGaNzEGFkrikbckxkzSFi
	{
		private float kHDLcuxiRebDQbOCfDKkJsLuCuPx;

		private HEnqjDCbQatLClXKVNYOqMCtdXr HSZnNnkmHltwlVSCYaieiBulYqH;

		private HEnqjDCbQatLClXKVNYOqMCtdXr WhVcpMeeiGCQYehIDxDujgQoyVtC;

		private HEnqjDCbQatLClXKVNYOqMCtdXr MVvXBHoglRGCCcCeyOCaaCWnbRu;

		private bool nvoRfdHTYWGhCprTfFxFDCkACchc;

		private float dqnSIbzjSffnbdbzCWFIsKsKztR;

		public HEnqjDCbQatLClXKVNYOqMCtdXr sourceState
		{
			get
			{
				return HSZnNnkmHltwlVSCYaieiBulYqH;
			}
		}

		public HEnqjDCbQatLClXKVNYOqMCtdXr changedState
		{
			get
			{
				return MVvXBHoglRGCCcCeyOCaaCWnbRu;
			}
		}

		public bool valueChanged
		{
			get
			{
				return nvoRfdHTYWGhCprTfFxFDCkACchc;
			}
		}

		public float lastChangedTimestamp
		{
			get
			{
				return dqnSIbzjSffnbdbzCWFIsKsKztR;
			}
		}

		public dMsbFMJyGaNzEGFkrikbckxkzSFi(HEnqjDCbQatLClXKVNYOqMCtdXr sourceState)
		{
			HSZnNnkmHltwlVSCYaieiBulYqH = sourceState;
			WhVcpMeeiGCQYehIDxDujgQoyVtC = new HEnqjDCbQatLClXKVNYOqMCtdXr();
			MVvXBHoglRGCCcCeyOCaaCWnbRu = new HEnqjDCbQatLClXKVNYOqMCtdXr();
		}

		public void EhlPnfprjfkehAbDLrDcQKRlXmc(float P_0)
		{
			kHDLcuxiRebDQbOCfDKkJsLuCuPx = P_0;
			int num5 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			int num8 = default(int);
			int num7 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = 1390486496;
				while (true)
				{
					switch (num ^ 0x52E123EC)
					{
					case 25:
						break;
					default:
						return;
					case 2:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.AccelerationX = HSZnNnkmHltwlVSCYaieiBulYqH.AccelerationX - WhVcpMeeiGCQYehIDxDujgQoyVtC.AccelerationX;
						MVvXBHoglRGCCcCeyOCaaCWnbRu.AccelerationY = HSZnNnkmHltwlVSCYaieiBulYqH.AccelerationY - WhVcpMeeiGCQYehIDxDujgQoyVtC.AccelerationY;
						num = 1390486502;
						continue;
					case 15:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.AngularAccelerationX = HSZnNnkmHltwlVSCYaieiBulYqH.AngularAccelerationX - WhVcpMeeiGCQYehIDxDujgQoyVtC.AngularAccelerationX;
						num = 1390486523;
						continue;
					case 4:
						num5++;
						num = 1390486513;
						continue;
					case 17:
						if (nvoRfdHTYWGhCprTfFxFDCkACchc)
						{
							dqnSIbzjSffnbdbzCWFIsKsKztR = P_0;
							WhVcpMeeiGCQYehIDxDujgQoyVtC.BbMlThpVHekUMrpjNzGQUGtzMyI(HSZnNnkmHltwlVSCYaieiBulYqH);
							num = 1390486522;
							continue;
						}
						return;
					case 11:
						num = 1390486526;
						continue;
					case 12:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.X = HSZnNnkmHltwlVSCYaieiBulYqH.X - WhVcpMeeiGCQYehIDxDujgQoyVtC.X;
						MVvXBHoglRGCCcCeyOCaaCWnbRu.Y = HSZnNnkmHltwlVSCYaieiBulYqH.Y - WhVcpMeeiGCQYehIDxDujgQoyVtC.Y;
						MVvXBHoglRGCCcCeyOCaaCWnbRu.Z = HSZnNnkmHltwlVSCYaieiBulYqH.Z - WhVcpMeeiGCQYehIDxDujgQoyVtC.Z;
						MVvXBHoglRGCCcCeyOCaaCWnbRu.RotationX = HSZnNnkmHltwlVSCYaieiBulYqH.RotationX - WhVcpMeeiGCQYehIDxDujgQoyVtC.RotationX;
						MVvXBHoglRGCCcCeyOCaaCWnbRu.RotationY = HSZnNnkmHltwlVSCYaieiBulYqH.RotationY - WhVcpMeeiGCQYehIDxDujgQoyVtC.RotationY;
						num = 1390486506;
						continue;
					case 3:
						num = 1390486498;
						continue;
					case 5:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.ForceSliders[num3] = HSZnNnkmHltwlVSCYaieiBulYqH.ForceSliders[num3] - WhVcpMeeiGCQYehIDxDujgQoyVtC.ForceSliders[num3];
						num = 1390486518;
						continue;
					case 26:
						num3++;
						num = 1390486498;
						continue;
					case 6:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.RotationZ = HSZnNnkmHltwlVSCYaieiBulYqH.RotationZ - WhVcpMeeiGCQYehIDxDujgQoyVtC.RotationZ;
						num = 1390486500;
						continue;
					case 21:
					{
						int num9;
						if (num4 >= HSZnNnkmHltwlVSCYaieiBulYqH.VelocitySliders.Length)
						{
							num = 1390486510;
							num9 = num;
						}
						else
						{
							num = 1390486524;
							num9 = num;
						}
						continue;
					}
					case 0:
						num4++;
						num = 1390486521;
						continue;
					case 27:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.VelocityX = HSZnNnkmHltwlVSCYaieiBulYqH.VelocityX - WhVcpMeeiGCQYehIDxDujgQoyVtC.VelocityX;
						MVvXBHoglRGCCcCeyOCaaCWnbRu.VelocityY = HSZnNnkmHltwlVSCYaieiBulYqH.VelocityY - WhVcpMeeiGCQYehIDxDujgQoyVtC.VelocityY;
						MVvXBHoglRGCCcCeyOCaaCWnbRu.VelocityZ = HSZnNnkmHltwlVSCYaieiBulYqH.VelocityZ - WhVcpMeeiGCQYehIDxDujgQoyVtC.VelocityZ;
						MVvXBHoglRGCCcCeyOCaaCWnbRu.AngularVelocityX = HSZnNnkmHltwlVSCYaieiBulYqH.AngularVelocityX - WhVcpMeeiGCQYehIDxDujgQoyVtC.AngularVelocityX;
						MVvXBHoglRGCCcCeyOCaaCWnbRu.AngularVelocityY = HSZnNnkmHltwlVSCYaieiBulYqH.AngularVelocityY - WhVcpMeeiGCQYehIDxDujgQoyVtC.AngularVelocityY;
						MVvXBHoglRGCCcCeyOCaaCWnbRu.AngularVelocityZ = HSZnNnkmHltwlVSCYaieiBulYqH.AngularVelocityZ - WhVcpMeeiGCQYehIDxDujgQoyVtC.AngularVelocityZ;
						num = 1390486507;
						continue;
					case 8:
						num8 = 0;
						num = 1390486527;
						continue;
					case 9:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.Sliders[num8] = HSZnNnkmHltwlVSCYaieiBulYqH.Sliders[num8] - WhVcpMeeiGCQYehIDxDujgQoyVtC.Sliders[num8];
						num8++;
						num = 1390486527;
						continue;
					case 14:
						if (num3 >= HSZnNnkmHltwlVSCYaieiBulYqH.ForceSliders.Length)
						{
							nvoRfdHTYWGhCprTfFxFDCkACchc = HHCNsoGhjkJpaYAiqRbEfGrUpVt();
							num = 1390486525;
							continue;
						}
						goto case 5;
					case 19:
						if (num8 >= HSZnNnkmHltwlVSCYaieiBulYqH.Sliders.Length)
						{
							num7 = 0;
							num = 1390486503;
							continue;
						}
						goto case 9;
					case 10:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.AccelerationZ = HSZnNnkmHltwlVSCYaieiBulYqH.AccelerationZ - WhVcpMeeiGCQYehIDxDujgQoyVtC.AccelerationZ;
						num = 1390486499;
						continue;
					case 18:
						if (num7 >= HSZnNnkmHltwlVSCYaieiBulYqH.PointOfViewControllers.Length)
						{
							num5 = 0;
							num = 1390486513;
							continue;
						}
						goto case 28;
					case 20:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.AccelerationSliders[num2] = HSZnNnkmHltwlVSCYaieiBulYqH.AccelerationSliders[num2] - WhVcpMeeiGCQYehIDxDujgQoyVtC.AccelerationSliders[num2];
						num2++;
						num = 1390486516;
						continue;
					case 29:
					{
						int num6;
						if (num5 < HSZnNnkmHltwlVSCYaieiBulYqH.Buttons.Length)
						{
							num = 1390486509;
							num6 = num;
						}
						else
						{
							num = 1390486519;
							num6 = num;
						}
						continue;
					}
					case 1:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.Buttons[num5] = HSZnNnkmHltwlVSCYaieiBulYqH.Buttons[num5] != WhVcpMeeiGCQYehIDxDujgQoyVtC.Buttons[num5];
						num = 1390486504;
						continue;
					case 13:
						num2 = 0;
						num = 1390486516;
						continue;
					case 16:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.VelocitySliders[num4] = HSZnNnkmHltwlVSCYaieiBulYqH.VelocitySliders[num4] - WhVcpMeeiGCQYehIDxDujgQoyVtC.VelocitySliders[num4];
						num = 1390486508;
						continue;
					case 7:
						num4 = 0;
						num = 1390486521;
						continue;
					case 24:
						if (num2 >= HSZnNnkmHltwlVSCYaieiBulYqH.AccelerationSliders.Length)
						{
							MVvXBHoglRGCCcCeyOCaaCWnbRu.ForceX = HSZnNnkmHltwlVSCYaieiBulYqH.ForceX - WhVcpMeeiGCQYehIDxDujgQoyVtC.ForceX;
							MVvXBHoglRGCCcCeyOCaaCWnbRu.ForceY = HSZnNnkmHltwlVSCYaieiBulYqH.ForceY - WhVcpMeeiGCQYehIDxDujgQoyVtC.ForceY;
							MVvXBHoglRGCCcCeyOCaaCWnbRu.ForceZ = HSZnNnkmHltwlVSCYaieiBulYqH.ForceZ - WhVcpMeeiGCQYehIDxDujgQoyVtC.ForceZ;
							MVvXBHoglRGCCcCeyOCaaCWnbRu.TorqueX = HSZnNnkmHltwlVSCYaieiBulYqH.TorqueX - WhVcpMeeiGCQYehIDxDujgQoyVtC.TorqueX;
							MVvXBHoglRGCCcCeyOCaaCWnbRu.TorqueY = HSZnNnkmHltwlVSCYaieiBulYqH.TorqueY - WhVcpMeeiGCQYehIDxDujgQoyVtC.TorqueY;
							MVvXBHoglRGCCcCeyOCaaCWnbRu.TorqueZ = HSZnNnkmHltwlVSCYaieiBulYqH.TorqueZ - WhVcpMeeiGCQYehIDxDujgQoyVtC.TorqueZ;
							num3 = 0;
							num = 1390486511;
							continue;
						}
						goto case 20;
					case 28:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.PointOfViewControllers[num7] = HSZnNnkmHltwlVSCYaieiBulYqH.PointOfViewControllers[num7] - WhVcpMeeiGCQYehIDxDujgQoyVtC.PointOfViewControllers[num7];
						num7++;
						num = 1390486526;
						continue;
					case 23:
						MVvXBHoglRGCCcCeyOCaaCWnbRu.AngularAccelerationY = HSZnNnkmHltwlVSCYaieiBulYqH.AngularAccelerationY - WhVcpMeeiGCQYehIDxDujgQoyVtC.AngularAccelerationY;
						MVvXBHoglRGCCcCeyOCaaCWnbRu.AngularAccelerationZ = HSZnNnkmHltwlVSCYaieiBulYqH.AngularAccelerationZ - WhVcpMeeiGCQYehIDxDujgQoyVtC.AngularAccelerationZ;
						num = 1390486497;
						continue;
					case 22:
						return;
					}
					break;
				}
			}
		}

		public void BbMlThpVHekUMrpjNzGQUGtzMyI(dMsbFMJyGaNzEGFkrikbckxkzSFi P_0)
		{
			kHDLcuxiRebDQbOCfDKkJsLuCuPx = P_0.kHDLcuxiRebDQbOCfDKkJsLuCuPx;
			WhVcpMeeiGCQYehIDxDujgQoyVtC.BbMlThpVHekUMrpjNzGQUGtzMyI(P_0.WhVcpMeeiGCQYehIDxDujgQoyVtC);
			MVvXBHoglRGCCcCeyOCaaCWnbRu.BbMlThpVHekUMrpjNzGQUGtzMyI(P_0.MVvXBHoglRGCCcCeyOCaaCWnbRu);
		}

		private bool HHCNsoGhjkJpaYAiqRbEfGrUpVt()
		{
			if (MVvXBHoglRGCCcCeyOCaaCWnbRu.Y != 0)
			{
				return true;
			}
			if (MVvXBHoglRGCCcCeyOCaaCWnbRu.Z != 0)
			{
				return true;
			}
			if (MVvXBHoglRGCCcCeyOCaaCWnbRu.RotationX != 0)
			{
				return true;
			}
			if (MVvXBHoglRGCCcCeyOCaaCWnbRu.RotationY != 0)
			{
				goto IL_003d;
			}
			int num;
			int num2 = default(int);
			if (MVvXBHoglRGCCcCeyOCaaCWnbRu.RotationZ != 0)
			{
				num = 370155751;
			}
			else
			{
				num2 = 0;
				num = 370155767;
			}
			goto IL_0042;
			IL_0042:
			int num4 = default(int);
			int num7 = default(int);
			int num5 = default(int);
			int num6 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x161020F7)
				{
				case 17:
					break;
				case 11:
					if (num4 >= HSZnNnkmHltwlVSCYaieiBulYqH.Buttons.Length)
					{
						if (MVvXBHoglRGCCcCeyOCaaCWnbRu.VelocityX != 0)
						{
							return true;
						}
						if (MVvXBHoglRGCCcCeyOCaaCWnbRu.VelocityY != 0)
						{
							return true;
						}
						if (MVvXBHoglRGCCcCeyOCaaCWnbRu.VelocityZ != 0)
						{
							num = 370155765;
							continue;
						}
						if (MVvXBHoglRGCCcCeyOCaaCWnbRu.AngularVelocityX != 0)
						{
							return true;
						}
						if (MVvXBHoglRGCCcCeyOCaaCWnbRu.AngularVelocityY == 0)
						{
							if (MVvXBHoglRGCCcCeyOCaaCWnbRu.AngularVelocityZ != 0)
							{
								return true;
							}
							num7 = 0;
							num = 370155768;
						}
						else
						{
							num = 370155774;
						}
						continue;
					}
					goto case 22;
				case 0:
					if (num2 >= HSZnNnkmHltwlVSCYaieiBulYqH.Sliders.Length)
					{
						num5 = 0;
						num = 370155771;
						continue;
					}
					goto case 13;
				case 3:
					MVvXBHoglRGCCcCeyOCaaCWnbRu.AccelerationSliders[num6] = HSZnNnkmHltwlVSCYaieiBulYqH.AccelerationSliders[num6] - WhVcpMeeiGCQYehIDxDujgQoyVtC.AccelerationSliders[num6];
					num6++;
					num = 370155762;
					continue;
				case 8:
					if (MVvXBHoglRGCCcCeyOCaaCWnbRu.ForceSliders[num3] != 0)
					{
						return true;
					}
					num3++;
					num = 370155746;
					continue;
				case 18:
					return true;
				case 20:
					return true;
				case 15:
					if (num7 >= HSZnNnkmHltwlVSCYaieiBulYqH.VelocitySliders.Length)
					{
						if (MVvXBHoglRGCCcCeyOCaaCWnbRu.AccelerationX != 0)
						{
							num = 370155760;
							continue;
						}
						if (MVvXBHoglRGCCcCeyOCaaCWnbRu.AccelerationY != 0)
						{
							return true;
						}
						if (MVvXBHoglRGCCcCeyOCaaCWnbRu.AccelerationZ == 0)
						{
							if (MVvXBHoglRGCCcCeyOCaaCWnbRu.AngularAccelerationX != 0)
							{
								return true;
							}
							if (MVvXBHoglRGCCcCeyOCaaCWnbRu.AngularAccelerationY != 0)
							{
								return true;
							}
							if (MVvXBHoglRGCCcCeyOCaaCWnbRu.AngularAccelerationZ == 0)
							{
								num6 = 0;
								num = 370155762;
							}
							else
							{
								num = 370155747;
							}
						}
						else
						{
							num = 370155766;
						}
						continue;
					}
					goto case 14;
				case 19:
					return true;
				case 1:
					return true;
				case 10:
					if (MVvXBHoglRGCCcCeyOCaaCWnbRu.PointOfViewControllers[num5] != 0)
					{
						return true;
					}
					num5++;
					num = 370155763;
					continue;
				case 13:
					if (MVvXBHoglRGCCcCeyOCaaCWnbRu.Sliders[num2] != 0)
					{
						return true;
					}
					num2++;
					num = 370155767;
					continue;
				case 9:
					return true;
				case 5:
					if (num6 >= HSZnNnkmHltwlVSCYaieiBulYqH.AccelerationSliders.Length)
					{
						if (MVvXBHoglRGCCcCeyOCaaCWnbRu.ForceX != 0)
						{
							return true;
						}
						if (MVvXBHoglRGCCcCeyOCaaCWnbRu.ForceY != 0)
						{
							return true;
						}
						if (MVvXBHoglRGCCcCeyOCaaCWnbRu.ForceZ == 0)
						{
							if (MVvXBHoglRGCCcCeyOCaaCWnbRu.TorqueX != 0)
							{
								return true;
							}
							if (MVvXBHoglRGCCcCeyOCaaCWnbRu.TorqueY != 0)
							{
								return true;
							}
							if (MVvXBHoglRGCCcCeyOCaaCWnbRu.TorqueZ != 0)
							{
								return true;
							}
							num3 = 0;
							num = 370155746;
						}
						else
						{
							num = 370155748;
						}
						continue;
					}
					goto case 3;
				case 6:
					return true;
				case 12:
					num = 370155763;
					continue;
				case 14:
					if (MVvXBHoglRGCCcCeyOCaaCWnbRu.VelocitySliders[num7] != 0)
					{
						return true;
					}
					num7++;
					num = 370155768;
					continue;
				case 2:
					return true;
				case 22:
					if (!MVvXBHoglRGCCcCeyOCaaCWnbRu.Buttons[num4])
					{
						num4++;
						num = 370155772;
					}
					else
					{
						num = 370155749;
					}
					continue;
				case 16:
					return true;
				case 4:
					if (num5 >= HSZnNnkmHltwlVSCYaieiBulYqH.PointOfViewControllers.Length)
					{
						num4 = 0;
						num = 370155772;
						continue;
					}
					goto case 10;
				case 7:
					return true;
				default:
					if (num3 >= HSZnNnkmHltwlVSCYaieiBulYqH.ForceSliders.Length)
					{
						return false;
					}
					goto case 8;
				}
				break;
			}
			goto IL_003d;
			IL_003d:
			num = 370155761;
			goto IL_0042;
		}
	}

	private class KMVVRABsNsdeaxZHCCUyhdAPsqS
	{
		public enum uXqtyKXqEZOCQJjmqbpiBAwbhVOI
		{
			hsqFwVabxTxZDbitiWOUsqWRrjW = 0,
			XSasYkIfXXTIuNYDajUSHAZXtRK = 1
		}

		public class MdRsFIBgSyIcSokQyFSNhZTIfhLq
		{
			public int InzpRLWBzesgNjVGacynCIMBDnJ;

			public Guid ODZHadYVuHkMcypYWKMRBQtiqnj;

			public Guid CgIVyXGyqTDPaUYRIwDzeLsZOit;

			public int WfZmTofniSsPbHKlehKQdLSahSv;

			public int jHaYXdTXWAJNlfIRTMsRGaqNBpK;

			public int qOBHYZBCAkYYTJoRDdsZoTyTELA;

			public int ByBfmUYbKOERmAjkpxrmtOAORFt;

			public bool CjIOgfYLwvzSovgYNuiXTTvJjBe(cyCsYcIQvugVJDWuUYpaIfgIudW P_0, uXqtyKXqEZOCQJjmqbpiBAwbhVOI P_1)
			{
				if (P_0.rewiredId == InzpRLWBzesgNjVGacynCIMBDnJ)
				{
					return true;
				}
				if (jHaYXdTXWAJNlfIRTMsRGaqNBpK != P_0.jHaYXdTXWAJNlfIRTMsRGaqNBpK)
				{
					return false;
				}
				if (qOBHYZBCAkYYTJoRDdsZoTyTELA != P_0.qOBHYZBCAkYYTJoRDdsZoTyTELA)
				{
					return false;
				}
				if (ByBfmUYbKOERmAjkpxrmtOAORFt != P_0.ByBfmUYbKOERmAjkpxrmtOAORFt)
				{
					return false;
				}
				switch (P_1)
				{
				case uXqtyKXqEZOCQJjmqbpiBAwbhVOI.hsqFwVabxTxZDbitiWOUsqWRrjW:
					return ODZHadYVuHkMcypYWKMRBQtiqnj == P_0.instanceGuid;
				case uXqtyKXqEZOCQJjmqbpiBAwbhVOI.XSasYkIfXXTIuNYDajUSHAZXtRK:
					return CgIVyXGyqTDPaUYRIwDzeLsZOit == P_0.CgIVyXGyqTDPaUYRIwDzeLsZOit;
				default:
					throw new NotImplementedException();
				}
			}

			public override string ToString()
			{
				string text = "";
				object[] array7 = default(object[]);
				object obj5 = default(object);
				object[] array3 = default(object[]);
				object[] array5 = default(object[]);
				object obj = default(object);
				object obj7 = default(object);
				object[] array4 = default(object[]);
				object[] array6 = default(object[]);
				object obj6 = default(object);
				object[] array2 = default(object[]);
				object obj4 = default(object);
				object obj2 = default(object);
				object[] array = default(object[]);
				while (true)
				{
					int num = 1326923538;
					while (true)
					{
						switch (num ^ 0x4F173F1C)
						{
						case 0:
							break;
						case 16:
							array7[0] = obj5;
							num = 1326923535;
							continue;
						case 19:
							array7[1] = "lastInputManagerId = ";
							num = 1326923539;
							continue;
						case 18:
							array3[1] = "instanceGuid = ";
							num = 1326923540;
							continue;
						case 1:
							array5 = new object[4] { obj, "hardwareButtonCount = ", qOBHYZBCAkYYTJoRDdsZoTyTELA, "\n" };
							num = 1326923543;
							continue;
						case 15:
							array7[2] = WfZmTofniSsPbHKlehKQdLSahSv;
							array7[3] = "\n";
							text = string.Concat(array7);
							obj7 = text;
							num = 1326923536;
							continue;
						case 12:
							array4 = new object[4] { obj7, "hardwareAxisCount = ", jHaYXdTXWAJNlfIRTMsRGaqNBpK, null };
							num = 1326923541;
							continue;
						case 4:
							array6 = new object[4] { obj6, "typeIdentifierGuid = ", CgIVyXGyqTDPaUYRIwDzeLsZOit, "\n" };
							num = 1326923545;
							continue;
						case 17:
							array2 = new object[4] { obj4, null, null, null };
							num = 1326923546;
							continue;
						case 10:
							obj6 = text;
							num = 1326923544;
							continue;
						case 20:
							array3 = new object[4] { obj2, null, null, null };
							num = 1326923534;
							continue;
						case 5:
							text = string.Concat(array6);
							obj5 = text;
							array7 = new object[4];
							num = 1326923532;
							continue;
						case 14:
							obj4 = text;
							num = 1326923533;
							continue;
						case 11:
						{
							text = string.Concat(array5);
							object obj3 = text;
							array = new object[4] { obj3, "hardwareHatCount = ", null, null };
							num = 1326923551;
							continue;
						}
						case 13:
							obj2 = text;
							num = 1326923528;
							continue;
						case 9:
							array4[3] = "\n";
							text = string.Concat(array4);
							num = 1326923550;
							continue;
						case 2:
							obj = text;
							num = 1326923549;
							continue;
						case 7:
							text = string.Concat(array3);
							num = 1326923542;
							continue;
						case 8:
							array3[2] = ODZHadYVuHkMcypYWKMRBQtiqnj;
							array3[3] = "\n";
							num = 1326923547;
							continue;
						case 6:
							array2[1] = "rewiredId = ";
							array2[2] = InzpRLWBzesgNjVGacynCIMBDnJ;
							array2[3] = "\n";
							text = string.Concat(array2);
							num = 1326923537;
							continue;
						default:
							array[2] = ByBfmUYbKOERmAjkpxrmtOAORFt;
							array[3] = "\n";
							return string.Concat(array);
						}
						break;
					}
				}
			}
		}

		private List<MdRsFIBgSyIcSokQyFSNhZTIfhLq> hrPXQonAeODgYLqpGRybHDStLgN;

		public KMVVRABsNsdeaxZHCCUyhdAPsqS()
		{
			hrPXQonAeODgYLqpGRybHDStLgN = new List<MdRsFIBgSyIcSokQyFSNhZTIfhLq>();
		}

		public void twVDKshQikIuavgehoSXWHaPlJad(cyCsYcIQvugVJDWuUYpaIfgIudW P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				int count = hrPXQonAeODgYLqpGRybHDStLgN.Count;
				int num = -1918469842;
				while (true)
				{
					switch (num ^ -1918469841)
					{
					case 4:
						num = -1918469849;
						continue;
					case 0:
					{
						int num3;
						if (num2 >= count)
						{
							num = -1918469844;
							num3 = num;
						}
						else
						{
							num = -1918469846;
							num3 = num;
						}
						continue;
					}
					case 2:
						num2++;
						num = -1918469841;
						continue;
					case 1:
						num2 = 0;
						num = -1918469841;
						continue;
					case 5:
						if (hrPXQonAeODgYLqpGRybHDStLgN[num2].CjIOgfYLwvzSovgYNuiXTTvJjBe(P_0, uXqtyKXqEZOCQJjmqbpiBAwbhVOI.hsqFwVabxTxZDbitiWOUsqWRrjW))
						{
							hrPXQonAeODgYLqpGRybHDStLgN[num2].InzpRLWBzesgNjVGacynCIMBDnJ = P_0.rewiredId;
							hrPXQonAeODgYLqpGRybHDStLgN[num2].ODZHadYVuHkMcypYWKMRBQtiqnj = P_0.instanceGuid;
							hrPXQonAeODgYLqpGRybHDStLgN[num2].CgIVyXGyqTDPaUYRIwDzeLsZOit = P_0.CgIVyXGyqTDPaUYRIwDzeLsZOit;
							hrPXQonAeODgYLqpGRybHDStLgN[num2].WfZmTofniSsPbHKlehKQdLSahSv = P_0.inputManagerId;
							num = -1918469848;
							continue;
						}
						goto case 2;
					case 6:
						hrPXQonAeODgYLqpGRybHDStLgN[num2].ByBfmUYbKOERmAjkpxrmtOAORFt = P_0.ByBfmUYbKOERmAjkpxrmtOAORFt;
						HyJvDRidjTBxfFeRuBIqVHqhepWi(P_0.rewiredId, P_0.instanceGuid, num2);
						return;
					case 7:
						hrPXQonAeODgYLqpGRybHDStLgN[num2].jHaYXdTXWAJNlfIRTMsRGaqNBpK = P_0.jHaYXdTXWAJNlfIRTMsRGaqNBpK;
						hrPXQonAeODgYLqpGRybHDStLgN[num2].qOBHYZBCAkYYTJoRDdsZoTyTELA = P_0.qOBHYZBCAkYYTJoRDdsZoTyTELA;
						num = -1918469847;
						continue;
					case 8:
						break;
					default:
						hrPXQonAeODgYLqpGRybHDStLgN.Add(new MdRsFIBgSyIcSokQyFSNhZTIfhLq
						{
							InzpRLWBzesgNjVGacynCIMBDnJ = P_0.rewiredId,
							ODZHadYVuHkMcypYWKMRBQtiqnj = P_0.instanceGuid,
							CgIVyXGyqTDPaUYRIwDzeLsZOit = P_0.CgIVyXGyqTDPaUYRIwDzeLsZOit,
							WfZmTofniSsPbHKlehKQdLSahSv = P_0.inputManagerId,
							jHaYXdTXWAJNlfIRTMsRGaqNBpK = P_0.jHaYXdTXWAJNlfIRTMsRGaqNBpK,
							qOBHYZBCAkYYTJoRDdsZoTyTELA = P_0.qOBHYZBCAkYYTJoRDdsZoTyTELA,
							ByBfmUYbKOERmAjkpxrmtOAORFt = P_0.ByBfmUYbKOERmAjkpxrmtOAORFt
						});
						HyJvDRidjTBxfFeRuBIqVHqhepWi(P_0.rewiredId, P_0.instanceGuid, hrPXQonAeODgYLqpGRybHDStLgN.Count - 1);
						return;
					}
					break;
				}
			}
		}

		public bool WQGtezfxeyeFNomyFPdWcsNQBHr(cyCsYcIQvugVJDWuUYpaIfgIudW P_0, uXqtyKXqEZOCQJjmqbpiBAwbhVOI P_1)
		{
			int count = hrPXQonAeODgYLqpGRybHDStLgN.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -1304521903;
				while (true)
				{
					switch (num ^ -1304521901)
					{
					case 3:
						break;
					case 2:
						num2 = 0;
						num = -1304521897;
						continue;
					case 4:
					{
						int num3;
						if (num2 < count)
						{
							num = -1304521902;
							num3 = num;
						}
						else
						{
							num = -1304521901;
							num3 = num;
						}
						continue;
					}
					case 1:
						if (hrPXQonAeODgYLqpGRybHDStLgN[num2].CjIOgfYLwvzSovgYNuiXTTvJjBe(P_0, P_1))
						{
							return true;
						}
						num2++;
						num = -1304521897;
						continue;
					default:
						return false;
					}
					break;
				}
			}
		}

		public MdRsFIBgSyIcSokQyFSNhZTIfhLq SNyQPMtxIqmpckDGNaILQiYNCbXF(cyCsYcIQvugVJDWuUYpaIfgIudW P_0, uXqtyKXqEZOCQJjmqbpiBAwbhVOI P_1)
		{
			int count = hrPXQonAeODgYLqpGRybHDStLgN.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -1295850390;
				while (true)
				{
					switch (num ^ -1295850389)
					{
					case 3:
						break;
					case 1:
						num2 = 0;
						num = -1295850389;
						continue;
					case 0:
						num = -1295850385;
						continue;
					case 2:
						if (hrPXQonAeODgYLqpGRybHDStLgN[num2].CjIOgfYLwvzSovgYNuiXTTvJjBe(P_0, P_1))
						{
							return hrPXQonAeODgYLqpGRybHDStLgN[num2];
						}
						num2++;
						num = -1295850385;
						continue;
					default:
						if (num2 >= count)
						{
							return null;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		private void HyJvDRidjTBxfFeRuBIqVHqhepWi(int P_0, Guid P_1, int P_2)
		{
			int num = hrPXQonAeODgYLqpGRybHDStLgN.Count - 1;
			while (true)
			{
				int num2 = -1064389167;
				while (true)
				{
					switch (num2 ^ -1064389168)
					{
					case 6:
						break;
					case 0:
						num--;
						num2 = -1064389166;
						continue;
					case 5:
					{
						int num4;
						if (hrPXQonAeODgYLqpGRybHDStLgN[num].ODZHadYVuHkMcypYWKMRBQtiqnj == P_1)
						{
							num2 = -1064389164;
							num4 = num2;
						}
						else
						{
							num2 = -1064389168;
							num4 = num2;
						}
						continue;
					}
					case 3:
						if (num != P_2)
						{
							int num3;
							if (hrPXQonAeODgYLqpGRybHDStLgN[num].InzpRLWBzesgNjVGacynCIMBDnJ == P_0)
							{
								num2 = -1064389164;
								num3 = num2;
							}
							else
							{
								num2 = -1064389163;
								num3 = num2;
							}
							continue;
						}
						goto case 0;
					case 4:
						hrPXQonAeODgYLqpGRybHDStLgN.RemoveAt(num);
						num2 = -1064389168;
						continue;
					case 1:
						num2 = -1064389166;
						continue;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public override string ToString()
		{
			string text = "";
			object obj = text;
			object[] array = new object[4];
			int num2 = default(int);
			object obj2 = default(object);
			object[] array2 = default(object[]);
			while (true)
			{
				int num = 92833950;
				while (true)
				{
					switch (num ^ 0x588889F)
					{
					case 5:
						break;
					case 1:
						array[0] = obj;
						array[1] = "Joystick records: ";
						array[2] = hrPXQonAeODgYLqpGRybHDStLgN.Count;
						array[3] = "\n";
						text = string.Concat(array);
						num2 = 0;
						num = 92833949;
						continue;
					case 3:
						obj2 = text;
						num = 92833951;
						continue;
					case 0:
						array2 = new object[4];
						num = 92833947;
						continue;
					case 4:
						array2[0] = obj2;
						array2[1] = "Record ";
						array2[2] = num2;
						array2[3] = ":\n";
						text = string.Concat(array2);
						text = text + hrPXQonAeODgYLqpGRybHDStLgN[num2].ToString() + "\n\n";
						num2++;
						num = 92833949;
						continue;
					default:
						if (num2 >= hrPXQonAeODgYLqpGRybHDStLgN.Count)
						{
							return text;
						}
						goto case 3;
					}
					break;
				}
			}
		}
	}

	private class YAjKnZfpTdaPnJGYGKFAREGNSenm
	{
		public cyCsYcIQvugVJDWuUYpaIfgIudW FvpbthwqHsVfdlOKqyTxjSLrkXP;

		public vgUDhfmgAmAsRjRuQJnGENONMljC wiqRNryfmHlNNQfoPfOnkfUjYJq;

		public bool IsValid
		{
			get
			{
				if (FvpbthwqHsVfdlOKqyTxjSLrkXP != null)
				{
					return wiqRNryfmHlNNQfoPfOnkfUjYJq != null;
				}
				return false;
			}
		}

		public YAjKnZfpTdaPnJGYGKFAREGNSenm(cyCsYcIQvugVJDWuUYpaIfgIudW joystick, vgUDhfmgAmAsRjRuQJnGENONMljC deviceInstance)
		{
			FvpbthwqHsVfdlOKqyTxjSLrkXP = joystick;
			wiqRNryfmHlNNQfoPfOnkfUjYJq = deviceInstance;
		}

		public static List<vgUDhfmgAmAsRjRuQJnGENONMljC> QpCraBwLLtOUMbSXGHheyNUgrgl(List<YAjKnZfpTdaPnJGYGKFAREGNSenm> P_0)
		{
			if (P_0 == null)
			{
				return new List<vgUDhfmgAmAsRjRuQJnGENONMljC>();
			}
			List<vgUDhfmgAmAsRjRuQJnGENONMljC> list = new List<vgUDhfmgAmAsRjRuQJnGENONMljC>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].IsValid)
				{
					list.Add(P_0[i].wiqRNryfmHlNNQfoPfOnkfUjYJq);
				}
			}
			return list;
		}
	}

	private class ruwpsMqZjzirNpBDccSiLbFHxXf
	{
		public jsQodzWnVXxJhIsULuSibIHUoCH aFOCvRRLjWNFrUqJPHuxNutrEll;

		public ruwpsMqZjzirNpBDccSiLbFHxXf(jsQodzWnVXxJhIsULuSibIHUoCH sdxJoystick)
		{
			aFOCvRRLjWNFrUqJPHuxNutrEll = sdxJoystick;
		}
	}

	private class RyebThHyLqwmHgUuGOlXcKCajqnV
	{
		private WjFybxMnkkesCfQZxtpFlEatAdf.rcpdAtthbgpUiTgtMOHNxoLoDjp ikcFmchjGQFZjAaIbywszXWtpUf;

		private WjFybxMnkkesCfQZxtpFlEatAdf.FRMKwblNelYkUXtMZFDktdIAaAc yxVAdewMAntlKHUnXVFBPfbeFDw;

		private NativeBuffer IBOmMAvLwaxwyHonNgQAcRUTBkf;

		private int RvFKkogQuFyFTMGfNcoUkmePwRC;

		public RyebThHyLqwmHgUuGOlXcKCajqnV()
		{
			ikcFmchjGQFZjAaIbywszXWtpUf = new WjFybxMnkkesCfQZxtpFlEatAdf.rcpdAtthbgpUiTgtMOHNxoLoDjp
			{
				QLRVlFytItCyaRFAlVUdgmmmtSp = (uint)Marshal.SizeOf(typeof(WjFybxMnkkesCfQZxtpFlEatAdf.rcpdAtthbgpUiTgtMOHNxoLoDjp)),
				GxHmXZWzdGvanYuBUUcyBiDtmKS = true,
				FjOFcjStVwRNmyqmKMLXCBGUPiD = true,
				lVKAFIdYRtwxrSInZgyfaTvRaJMU = false,
				GeSBHHMvdGdoFMfwtcteVupmvCE = true,
				cOiFbHdZnaUpCAxRHhJSaewZoihe = IntPtr.Zero
			};
			yxVAdewMAntlKHUnXVFBPfbeFDw = WjFybxMnkkesCfQZxtpFlEatAdf.FRMKwblNelYkUXtMZFDktdIAaAc.AMeJMNvnyBBLKGPtCVsgJOjWefz();
			IBOmMAvLwaxwyHonNgQAcRUTBkf = new NativeBuffer((int)yxVAdewMAntlKHUnXVFBPfbeFDw.QLRVlFytItCyaRFAlVUdgmmmtSp);
			IBOmMAvLwaxwyHonNgQAcRUTBkf.Write(yxVAdewMAntlKHUnXVFBPfbeFDw.QLRVlFytItCyaRFAlVUdgmmmtSp, 0);
		}

		public bool AUcwHyjHDCDTUaWUcgnSLQKbywcu()
		{
			int num = YnmFUkYTWeJEECfPsKiWpXwiYVJ();
			while (true)
			{
				int num2 = -241365851;
				while (true)
				{
					switch (num2 ^ -241365852)
					{
					case 2:
						break;
					case 1:
						if (num == RvFKkogQuFyFTMGfNcoUkmePwRC)
						{
							num2 = -241365852;
							continue;
						}
						RvFKkogQuFyFTMGfNcoUkmePwRC = num;
						num2 = -241365849;
						continue;
					case 0:
						return false;
					default:
						return true;
					}
					break;
				}
			}
		}

		public void uNaPGXmbeHETCGQohISyNuDBchB(int P_0)
		{
			RvFKkogQuFyFTMGfNcoUkmePwRC = P_0;
		}

		private int YnmFUkYTWeJEECfPsKiWpXwiYVJ()
		{
			try
			{
				return eCKdLvtfldigSEOJNAhOjiRdUQDt.RkwcnGfAdjnBAZpTGLprxXKBGMi(ref ikcFmchjGQFZjAaIbywszXWtpUf, IBOmMAvLwaxwyHonNgQAcRUTBkf);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum VSpIeAcJhSiZXYShilsTwSooeUR
	{
		ZWtEIVCLNCpVNyDISCnCWMsygkK = 17,
		WibnlhrIoppUjEuxjomaVCUrgKFC = 18,
		lRyHJPXZVJHsfNLQMHpqapjyFUH = 19,
		yCfdhbHfXQEBCYlYpsoIlfGCgZCb = 20,
		vSwPcNwgbxwAqGIFeDWVMWWlXXr = 21,
		larOafohUcEUGzVzUAioKDEUsyCz = 22,
		BcCwrCtUXfvGEOSXGrXdIPptwV = 23,
		ninZYmIuFpAVmoOvAdjXfIuyyUR = 24,
		EOZARKKaQMYJhaMBWMHnDOyTMgqV = 25,
		wjYEfeJxIqxxaGrtDxbNsrMUrsl = 26,
		LbQxzJaUuJQFdaxWJaFegEiXSBH = 27,
		sYADrfcVNCsMQvuOtfbyywZRHKgn = 28
	}

	private const RSViiCwWYViTGbHemxBsoBfasVd xqkGyIBFAspzUxNxvYuktQBevAXj = RSViiCwWYViTGbHemxBsoBfasVd.GbQpIWxEvYSkxUbfmBgPqSZfLDE;

	private const zGfVlsImnYjabwVEyjlINqRCfqKj wPmfJwrjrcnuLXMDRHyybicSkKz = zGfVlsImnYjabwVEyjlINqRCfqKj.sQJXOWUzmAyNONjbRXYAwNmJORI;

	private IntPtr etBhGkiynzcvWfnGOFBmufcIzSBq;

	private DirectInput pbsDzFwuvQvUwdnstjlbFubXWWZ;

	private List<cyCsYcIQvugVJDWuUYpaIfgIudW> AvwfdLjWSYyRUfRbGOqVqadERNGK;

	private int hShdCGGbdfKCwKvzqAgdyZHXxRH;

	private KMVVRABsNsdeaxZHCCUyhdAPsqS VkhgikRmZCRpwCsFCAHFtklICJTg;

	private bool NLvIuZNNslOQGzDqMqqhEmdQXHU;

	private bool ilRrVwkMgOLwkAAfYNNcVNLgBSS;

	private UpdateLoopSetting RQVpjxselUIKoeDEGCtMKDXyjeB;

	private Action<int, ControllerDataUpdater> YALIvlsEVxFcouIKiMIOBoKrdos;

	private PlatformInputManager YLxisMThRDTgIbPaYfJsjfpWQRp;

	private TimerRealTime XruuVyWMVAVXdAhAsLNgGqHxHyp;

	private global::JgMCJJMlgdaaIpbxNKhHxTGJyrJ<bool> HDazfatCsQgEaDPiiXiqSfZKFtgb;

	private int UQujyEkDBZwoueACHoIPpOHNWvF;

	private int WePpeeROuHtUksObvZZGdnKIcxP;

	private global::JgMCJJMlgdaaIpbxNKhHxTGJyrJ<List<YAjKnZfpTdaPnJGYGKFAREGNSenm>> sFMJuNkEjRgiflkDeBTrYjCaAcmb;

	private RyebThHyLqwmHgUuGOlXcKCajqnV mQDFHrdaBBdDsJXeAJislCVaATuE;

	private readonly object QRRGShBaDEUaStPKcRtRWlMmzrR = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lzXAqTcTNwGXhyoMQqetZTTNJGjM;

	private Func<int> sbyIXavKIUtCermoZwGVxaaQFdB;

	public bool useXInput
	{
		set
		{
			ilRrVwkMgOLwkAAfYNNcVNLgBSS = value;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return hShdCGGbdfKCwKvzqAgdyZHXxRH;
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return YLxisMThRDTgIbPaYfJsjfpWQRp;
		}
	}

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return new InputSourceWrapper<DirectInput>(pbsDzFwuvQvUwdnstjlbFubXWWZ);
		}
	}

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			return InputSource.DirectInput;
		}
	}

	public fBXeGifswogtgcrDLXdgVsYUjXH(UpdateLoopSetting updateLoopSetting, bool useXInput, IntPtr windowHandle, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		try
		{
			RQVpjxselUIKoeDEGCtMKDXyjeB = updateLoopSetting;
			ilRrVwkMgOLwkAAfYNNcVNLgBSS = useXInput;
			etBhGkiynzcvWfnGOFBmufcIzSBq = windowHandle;
			lzXAqTcTNwGXhyoMQqetZTTNJGjM = getHardwareJoystickMap_InputManager;
			sbyIXavKIUtCermoZwGVxaaQFdB = getNewJoystickId;
			YLxisMThRDTgIbPaYfJsjfpWQRp = this;
			pbsDzFwuvQvUwdnstjlbFubXWWZ = new DirectInput();
			YALIvlsEVxFcouIKiMIOBoKrdos = UpdateControllerData;
			mQDFHrdaBBdDsJXeAJislCVaATuE = new RyebThHyLqwmHgUuGOlXcKCajqnV();
			HDazfatCsQgEaDPiiXiqSfZKFtgb = new global::JgMCJJMlgdaaIpbxNKhHxTGJyrJ<bool>(true, ZJMbdcnTjSsyftGUjHTjFwTkOLv);
			sFMJuNkEjRgiflkDeBTrYjCaAcmb = new global::JgMCJJMlgdaaIpbxNKhHxTGJyrJ<List<YAjKnZfpTdaPnJGYGKFAREGNSenm>>(true, () => oxtQbscWwzMCiJgvDPikBNLRDAgi());
			hXpHtBuijEDJvGwJAKyobUHfOXu();
		}
		catch (Exception ex)
		{
			OnDestroy();
			throw ex;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		VkhgikRmZCRpwCsFCAHFtklICJTg = new KMVVRABsNsdeaxZHCCUyhdAPsqS();
		while (true)
		{
			int num = -333087168;
			while (true)
			{
				switch (num ^ -333087167)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					goto IL_0029;
				case 2:
					return;
				}
				break;
				IL_0029:
				XruuVyWMVAVXdAhAsLNgGqHxHyp = new TimerRealTime(1f);
				XruuVyWMVAVXdAhAsLNgGqHxHyp.Start();
				aPEezZdShnkfZnlZoFUawjYCLkY();
				num = -333087165;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		QwOUSSvKbsLeemtPHIStClApZkv();
		rlecVsIXXYBuTWpNWMljozzsJsK();
		nXErRbwAigpeSUKNnHDMPkYiLlQ();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (sFMJuNkEjRgiflkDeBTrYjCaAcmb != null)
		{
			sFMJuNkEjRgiflkDeBTrYjCaAcmb.HtJdxRxaGggkmaMTSWUpHqjZLDV();
			goto IL_0013;
		}
		goto IL_0031;
		IL_004b:
		if (AvwfdLjWSYyRUfRbGOqVqadERNGK == null)
		{
			return;
		}
		lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
		{
			int num = 0;
			while (num < AvwfdLjWSYyRUfRbGOqVqadERNGK.Count)
			{
				while (true)
				{
					int num2;
					if (AvwfdLjWSYyRUfRbGOqVqadERNGK[num] != null)
					{
						AvwfdLjWSYyRUfRbGOqVqadERNGK[num].JxfIuiJgitwuNVhKepFyxnNnrFN();
						num2 = -2031309460;
						goto IL_006c;
					}
					goto IL_00cb;
					IL_006c:
					while (true)
					{
						switch (num2 ^ -2031309464)
						{
						case 0:
							num2 = -2031309462;
							continue;
						case 2:
							break;
						case 4:
							AvwfdLjWSYyRUfRbGOqVqadERNGK[num].HtJdxRxaGggkmaMTSWUpHqjZLDV();
							num2 = -2031309461;
							continue;
						case 3:
							goto IL_00cb;
						default:
							goto end_IL_008d;
						}
						break;
					}
					continue;
					IL_00cb:
					num++;
					num2 = -2031309463;
					goto IL_006c;
					continue;
					end_IL_008d:
					break;
				}
			}
			return;
		}
		IL_0013:
		int num3 = -2031309463;
		goto IL_0018;
		IL_0018:
		switch (num3 ^ -2031309464)
		{
		case 2:
			break;
		case 1:
			goto IL_0031;
		default:
			goto IL_004b;
		}
		goto IL_0013;
		IL_0031:
		if (HDazfatCsQgEaDPiiXiqSfZKFtgb != null)
		{
			HDazfatCsQgEaDPiiXiqSfZKFtgb.HtJdxRxaGggkmaMTSWUpHqjZLDV();
			num3 = -2031309464;
			goto IL_0018;
		}
		goto IL_004b;
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return YALIvlsEVxFcouIKiMIOBoKrdos;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
		{
			int num = 0;
			while (true)
			{
				IL_0086:
				int num2;
				int num3;
				if (num < hShdCGGbdfKCwKvzqAgdyZHXxRH)
				{
					num2 = 185299011;
					num3 = num2;
				}
				else
				{
					num2 = 185299010;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0xB0B7046)
					{
					case 3:
						num2 = 185299011;
						continue;
					default:
						goto end_IL_0016;
					case 5:
					{
						int num4;
						if (AvwfdLjWSYyRUfRbGOqVqadERNGK[num].inputManagerId == inputManagerId)
						{
							num2 = 185299012;
							num4 = num2;
						}
						else
						{
							num2 = 185299014;
							num4 = num2;
						}
						continue;
					}
					case 2:
						AvwfdLjWSYyRUfRbGOqVqadERNGK[num].FillData(data);
						return;
					case 0:
						num++;
						num2 = 185299015;
						continue;
					case 1:
						break;
					case 4:
						goto end_IL_0016;
					}
					goto IL_0086;
					continue;
					end_IL_0016:
					break;
				}
				break;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		NLvIuZNNslOQGzDqMqqhEmdQXHU = true;
		while (true)
		{
			int num = -1350692401;
			while (true)
			{
				switch (num ^ -1350692403)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					XruuVyWMVAVXdAhAsLNgGqHxHyp.Start();
					if (_SystemDeviceConnectedEvent != null)
					{
						goto IL_0038;
					}
					return;
				case 1:
					return;
				}
				break;
				IL_0038:
				_SystemDeviceConnectedEvent();
				num = -1350692404;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		NLvIuZNNslOQGzDqMqqhEmdQXHU = true;
		XruuVyWMVAVXdAhAsLNgGqHxHyp.Start();
		if (_SystemDeviceDisconnectedEvent == null)
		{
			return;
		}
		while (true)
		{
			int num = 1521522879;
			while (true)
			{
				switch (num ^ 0x5AB098BE)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					goto IL_0038;
				case 0:
					return;
				}
				break;
				IL_0038:
				_SystemDeviceDisconnectedEvent();
				num = 1521522878;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	private void QwOUSSvKbsLeemtPHIStClApZkv()
	{
		if (!HDazfatCsQgEaDPiiXiqSfZKFtgb.isRunning)
		{
			goto IL_006b;
		}
		if (!HDazfatCsQgEaDPiiXiqSfZKFtgb.xHkLCHGKEGSLVNAFPpLRGAkaRJs())
		{
			return;
		}
		goto IL_0091;
		IL_0020:
		int num;
		while (true)
		{
			switch (num ^ 0x52E41508)
			{
			case 9:
				num = 1390679307;
				continue;
			default:
				return;
			case 7:
				XruuVyWMVAVXdAhAsLNgGqHxHyp.Start();
				return;
			case 0:
				break;
			case 6:
				return;
			case 3:
				goto IL_0091;
			case 5:
				XruuVyWMVAVXdAhAsLNgGqHxHyp.Start();
				num = 1390679296;
				continue;
			case 8:
				return;
			case 4:
				if (XruuVyWMVAVXdAhAsLNgGqHxHyp.Update())
				{
					HDazfatCsQgEaDPiiXiqSfZKFtgb.CNNCNIEIEPKDJVWLdcWrLrRIbyb();
					num = 1390679306;
					continue;
				}
				return;
			case 1:
				if (HDazfatCsQgEaDPiiXiqSfZKFtgb.result)
				{
					NLvIuZNNslOQGzDqMqqhEmdQXHU = true;
					num = 1390679311;
					continue;
				}
				goto case 7;
			case 2:
				return;
			}
			break;
		}
		goto IL_006b;
		IL_0091:
		if (XruuVyWMVAVXdAhAsLNgGqHxHyp.running)
		{
			return;
		}
		int num2;
		if (!sFMJuNkEjRgiflkDeBTrYjCaAcmb.isRunning)
		{
			num = 1390679305;
			num2 = num;
		}
		else
		{
			num = 1390679310;
			num2 = num;
		}
		goto IL_0020;
		IL_006b:
		int num3;
		if (!XruuVyWMVAVXdAhAsLNgGqHxHyp.running)
		{
			num = 1390679309;
			num3 = num;
		}
		else
		{
			num = 1390679308;
			num3 = num;
		}
		goto IL_0020;
	}

	private List<YAjKnZfpTdaPnJGYGKFAREGNSenm> oxtQbscWwzMCiJgvDPikBNLRDAgi()
	{
		List<YAjKnZfpTdaPnJGYGKFAREGNSenm> list = new List<YAjKnZfpTdaPnJGYGKFAREGNSenm>();
		IList<vgUDhfmgAmAsRjRuQJnGENONMljC> list2 = vkKocwYHsCOUCRXUbieDJnolIsP();
		int count = default(int);
		int num = default(int);
		jsQodzWnVXxJhIsULuSibIHUoCH jsQodzWnVXxJhIsULuSibIHUoCH2 = default(jsQodzWnVXxJhIsULuSibIHUoCH);
		KLdxxuJrfxnDixEHBLHuoAtHctc properties = default(KLdxxuJrfxnDixEHBLHuoAtHctc);
		bool flag2 = default(bool);
		Guid guid = default(Guid);
		int num10 = default(int);
		while (true)
		{
			int num2;
			switch (-774562031 ^ -774562032)
			{
			case 2:
				break;
			case 1:
				count = list2.Count;
				num = 0;
				goto IL_04f5;
			default:
				{
					if (list2[num] != null)
					{
						try
						{
							vgUDhfmgAmAsRjRuQJnGENONMljC vgUDhfmgAmAsRjRuQJnGENONMljC2 = list2[num];
							Guid enAPtHYaqiBCfCxaGvASHsInALh = vgUDhfmgAmAsRjRuQJnGENONMljC2.enAPtHYaqiBCfCxaGvASHsInALh;
							while (true)
							{
								IL_005e:
								int num3 = -774562025;
								while (true)
								{
									Guid guid2;
									switch (num3 ^ -774562032)
									{
									case 2:
										break;
									case 7:
										jsQodzWnVXxJhIsULuSibIHUoCH2 = new jsQodzWnVXxJhIsULuSibIHUoCH(pbsDzFwuvQvUwdnstjlbFubXWWZ, enAPtHYaqiBCfCxaGvASHsInALh);
										properties = jsQodzWnVXxJhIsULuSibIHUoCH2.Properties;
										flag2 = false;
										num3 = -774562026;
										continue;
									case 1:
										if (string.IsNullOrEmpty(properties.InterfacePath))
										{
											num3 = -774562032;
											continue;
										}
										guid2 = MiscTools.CreateGuidHashSHA256(properties.InterfacePath);
										goto IL_010f;
									case 4:
										flag2 = gshAbvCgMLjmBZLoNOmLiemiCMZ.NYbPexEJvLXtDiZpusQEVKSFkTK(properties.InterfacePath, StringTools.SanitizeDeviceString(vgUDhfmgAmAsRjRuQJnGENONMljC2.OEnOUJCzzTIBDnorvtUHuLJCUSM), string.Empty, vgUDhfmgAmAsRjRuQJnGENONMljC2.neegydbRJWFbtaeXBWBstaVupIYa);
										num3 = -774562029;
										continue;
									case 0:
										guid2 = vgUDhfmgAmAsRjRuQJnGENONMljC2.enAPtHYaqiBCfCxaGvASHsInALh;
										goto IL_010f;
									case 6:
									{
										int num12;
										if (!ilRrVwkMgOLwkAAfYNNcVNLgBSS)
										{
											num3 = -774562031;
											num12 = num3;
										}
										else
										{
											num3 = -774562028;
											num12 = num3;
										}
										continue;
									}
									case 3:
										if (flag2)
										{
											goto end_IL_0063;
										}
										goto case 1;
									default:
										{
											bool flag = false;
											lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
											{
												if (AvwfdLjWSYyRUfRbGOqVqadERNGK != null)
												{
													int num4 = 0;
													while (true)
													{
														IL_01a8:
														int num5;
														int num6;
														if (num4 >= AvwfdLjWSYyRUfRbGOqVqadERNGK.Count)
														{
															num5 = -774562032;
															num6 = num5;
														}
														else
														{
															num5 = -774562031;
															num6 = num5;
														}
														while (true)
														{
															switch (num5 ^ -774562032)
															{
															case 5:
																num5 = -774562031;
																continue;
															default:
																goto end_IL_0173;
															case 3:
																num4++;
																num5 = -774562028;
																continue;
															case 4:
																break;
															case 1:
																if (AvwfdLjWSYyRUfRbGOqVqadERNGK[num4] != null)
																{
																	int num7;
																	if (!(AvwfdLjWSYyRUfRbGOqVqadERNGK[num4].cBDIfdqFvdWzxrFEMJqjLvTvIpG == guid))
																	{
																		num5 = -774562029;
																		num7 = num5;
																	}
																	else
																	{
																		num5 = -774562030;
																		num7 = num5;
																	}
																	continue;
																}
																goto case 3;
															case 2:
																jsQodzWnVXxJhIsULuSibIHUoCH2 = AvwfdLjWSYyRUfRbGOqVqadERNGK[num4].eunhnaovDRiEguPGzwjEMBJUohX.EAHBveZYCGolVbLQhYJNUosGdcUg;
																flag = true;
																num5 = -774562032;
																continue;
															case 0:
																goto end_IL_0173;
															}
															goto IL_01a8;
															continue;
															end_IL_0173:
															break;
														}
														break;
													}
												}
											}
											cyCsYcIQvugVJDWuUYpaIfgIudW cyCsYcIQvugVJDWuUYpaIfgIudW2 = new cyCsYcIQvugVJDWuUYpaIfgIudW(new pWuCkUBcnuhLuBWirlcUCWkKvpMO(jsQodzWnVXxJhIsULuSibIHUoCH2, RQVpjxselUIKoeDEGCtMKDXyjeB), lzXAqTcTNwGXhyoMQqetZTTNJGjM);
											cyCsYcIQvugVJDWuUYpaIfgIudW2.wiqRNryfmHlNNQfoPfOnkfUjYJq = vgUDhfmgAmAsRjRuQJnGENONMljC2;
											while (true)
											{
												IL_0259:
												int num8 = -774562031;
												while (true)
												{
													switch (num8 ^ -774562032)
													{
													case 3:
														break;
													case 1:
														cyCsYcIQvugVJDWuUYpaIfgIudW2.mHIfxFeuzrrprIjNQQttDcAWoJX = vgUDhfmgAmAsRjRuQJnGENONMljC2.MQiCEUbFpGXyRhzkwOquloXzUCEV;
														num8 = -774562032;
														continue;
													case 0:
														cyCsYcIQvugVJDWuUYpaIfgIudW2.cBDIfdqFvdWzxrFEMJqjLvTvIpG = guid;
														cyCsYcIQvugVJDWuUYpaIfgIudW2.AOVTbdgjQpuvVXuOzJgmsvYOWec = StringTools.SanitizeDeviceString(vgUDhfmgAmAsRjRuQJnGENONMljC2.OEnOUJCzzTIBDnorvtUHuLJCUSM);
														num8 = -774562030;
														continue;
													default:
													{
														cyCsYcIQvugVJDWuUYpaIfgIudW2.qSJYeLiyjfTRCcMnvDOwuKWJouA = vgUDhfmgAmAsRjRuQJnGENONMljC2.neegydbRJWFbtaeXBWBstaVupIYa;
														cyCsYcIQvugVJDWuUYpaIfgIudW2.cxWZJvEKbopEslEOJsEPGUSFMLm = (VSpIeAcJhSiZXYShilsTwSooeUR)vgUDhfmgAmAsRjRuQJnGENONMljC2.Type;
														tRbHRRTvpUlxUKqapGISxXXDrOP capabilities = jsQodzWnVXxJhIsULuSibIHUoCH2.Capabilities;
														cyCsYcIQvugVJDWuUYpaIfgIudW2.fSuJoZmgBMnbZWJgvPaTNrIBkjq = properties.ProductId;
														cyCsYcIQvugVJDWuUYpaIfgIudW2.KqmajqZRajQeRJHxvHBZhqVPgsd = flag2;
														try
														{
															cyCsYcIQvugVJDWuUYpaIfgIudW2.ySxHACCmrqwNquIhkRqoFdufNKj = properties.JoystickId;
														}
														catch (Exception)
														{
															cyCsYcIQvugVJDWuUYpaIfgIudW2.ySxHACCmrqwNquIhkRqoFdufNKj = 0;
														}
														cyCsYcIQvugVJDWuUYpaIfgIudW2.jHaYXdTXWAJNlfIRTMsRGaqNBpK = capabilities.dHTfRYjcEiBnhjZAXjEderVDyXok;
														cyCsYcIQvugVJDWuUYpaIfgIudW2.qOBHYZBCAkYYTJoRDdsZoTyTELA = capabilities.lwPieGbLEzAskWvJIoFcuwJwQsU;
														cyCsYcIQvugVJDWuUYpaIfgIudW2.ByBfmUYbKOERmAjkpxrmtOAORFt = capabilities.EKNLxnieCsJOkPzMWbNelRMrciQ;
														oXEGWcsjcAgHnGkczKsVaIlTumpa(cyCsYcIQvugVJDWuUYpaIfgIudW2, properties, out cyCsYcIQvugVJDWuUYpaIfgIudW2.cohMCgUaCXDhrXVkwBZFZQUtguG);
														try
														{
															string productName;
															try
															{
																productName = properties.ProductName;
															}
															catch
															{
																productName = cyCsYcIQvugVJDWuUYpaIfgIudW2.AOVTbdgjQpuvVXuOzJgmsvYOWec;
															}
															int min;
															int max;
															int zero;
															if (SpecialDevices.RequiresRelativeToAbsoluteAxisConversion((ushort)properties.VendorId, (ushort)properties.ProductId, productName) && SpecialDevices.GetRelativeAxisRanges((ushort)properties.VendorId, (ushort)properties.ProductId, productName, out min, out max, out zero))
															{
																cyCsYcIQvugVJDWuUYpaIfgIudW2.eunhnaovDRiEguPGzwjEMBJUohX.VQfeYTXiqbpfQIXoEgEmPJxNliY(min, max, zero, SpecialDevices.GetRelativeToAbsoluteAxisEventTimeout((ushort)properties.VendorId, (ushort)properties.ProductId, productName));
															}
														}
														catch (Exception)
														{
														}
														if (!flag)
														{
															IList<KuQxCBzznSLnNWYiaqXOToEkUKh> list3 = jsQodzWnVXxJhIsULuSibIHUoCH2.DKqajuJWbQnTOheggZGXUloOluMu();
															while (true)
															{
																int num9 = -774562029;
																while (true)
																{
																	switch (num9 ^ -774562032)
																	{
																	case 5:
																		break;
																	case 6:
																		num10++;
																		num9 = -774562028;
																		continue;
																	case 8:
																		num9 = -774562028;
																		continue;
																	case 7:
																		jsQodzWnVXxJhIsULuSibIHUoCH2.Properties.AxisMode = NtEtIYwEvspQgkpHohCcjYbpjqun.OpgSTadrMvdZpxRzWjTtIpOJwXC;
																		jsQodzWnVXxJhIsULuSibIHUoCH2.pXLBBMaUmhWEwVHkuhyYXMxpGXCl(etBhGkiynzcvWfnGOFBmufcIzSBq, mHEprXevJhfMLRuZPdPxrxEIOFG.FSbRaFXuaSefQKBimFRVAtQOOEZE | mHEprXevJhfMLRuZPdPxrxEIOFG.YVahpQVDmRIEBgFmBLpOusVSWuPp);
																		num9 = -774562032;
																		continue;
																	case 1:
																		if ((list3[num10].PAKwpRwHzcMrwnAbkFIFosdOHCzB.Flags & gxhgVrOliVamAhmjXjgnPKfDmZY.HHXbspJDVrOgmjeiSarUYYMpdPSa) != gxhgVrOliVamAhmjXjgnPKfDmZY.vvyijmZOzRFtTdippDQZhtsZhGJC)
																		{
																			jsQodzWnVXxJhIsULuSibIHUoCH2.Properties.Range = new BeZFfShWDfxzerAOHfuPtekOGSBW(-65535, 65535);
																			num9 = -774562026;
																			continue;
																		}
																		goto case 6;
																	case 3:
																		if (list3 != null)
																		{
																			num10 = 0;
																			num9 = -774562024;
																			continue;
																		}
																		goto case 7;
																	case 4:
																		goto IL_048f;
																	case 0:
																		jsQodzWnVXxJhIsULuSibIHUoCH2.GFLPSeyIjIAqKSNFbdOLeOPmOvDX();
																		num9 = -774562030;
																		continue;
																	default:
																		goto end_IL_03d2;
																	}
																	break;
																	IL_048f:
																	int num11;
																	if (num10 < list3.Count)
																	{
																		num9 = -774562031;
																		num11 = num9;
																	}
																	else
																	{
																		num9 = -774562025;
																		num11 = num9;
																	}
																}
																continue;
																end_IL_03d2:
																break;
															}
														}
														list.Add(new YAjKnZfpTdaPnJGYGKFAREGNSenm(cyCsYcIQvugVJDWuUYpaIfgIudW2, vgUDhfmgAmAsRjRuQJnGENONMljC2));
														goto end_IL_025e;
													}
													}
													goto IL_0259;
													continue;
													end_IL_025e:
													break;
												}
												break;
											}
											goto end_IL_0063;
										}
										IL_010f:
										guid = guid2;
										num3 = -774562027;
										continue;
									}
									goto IL_005e;
									continue;
									end_IL_0063:
									break;
								}
								break;
							}
						}
						catch (Exception)
						{
						}
					}
					num++;
					goto IL_04d7;
				}
				IL_04f5:
				if (num < count)
				{
					goto default;
				}
				num2 = -774562031;
				goto IL_04dc;
				IL_04d7:
				num2 = -774562030;
				goto IL_04dc;
				IL_04dc:
				switch (num2 ^ -774562032)
				{
				case 0:
					break;
				case 2:
					goto IL_04f5;
				default:
					return list;
				}
				goto IL_04d7;
			}
		}
	}

	private void aPEezZdShnkfZnlZoFUawjYCLkY()
	{
		JGdcjKsYsJfmhyjdevgVFNadqXW(oxtQbscWwzMCiJgvDPikBNLRDAgi());
	}

	private void JGdcjKsYsJfmhyjdevgVFNadqXW(List<YAjKnZfpTdaPnJGYGKFAREGNSenm> P_0)
	{
		List<cyCsYcIQvugVJDWuUYpaIfgIudW> list = new List<cyCsYcIQvugVJDWuUYpaIfgIudW>();
		UQujyEkDBZwoueACHoIPpOHNWvF = 0;
		int num = ((P_0 != null) ? P_0.Count : 0);
		int num2 = default(int);
		int num5 = default(int);
		int count = default(int);
		while (true)
		{
			int num3;
			switch (-1437998604 ^ -1437998602)
			{
			case 0:
				break;
			case 2:
				num2 = 0;
				goto IL_010c;
			default:
				{
					if (P_0[num2] != null && P_0[num2].IsValid)
					{
						try
						{
							cyCsYcIQvugVJDWuUYpaIfgIudW fvpbthwqHsVfdlOKqyTxjSLrkXP = P_0[num2].FvpbthwqHsVfdlOKqyTxjSLrkXP;
							fvpbthwqHsVfdlOKqyTxjSLrkXP.qlRdJvJiKhLJLbmzJBHkcnXAtwPX();
							if (fvpbthwqHsVfdlOKqyTxjSLrkXP.NxfPDLDjjkkAByWVYHnViSDRJzU)
							{
								UQujyEkDBZwoueACHoIPpOHNWvF++;
								goto IL_0086;
							}
							goto IL_00a4;
							IL_00a4:
							list.Add(fvpbthwqHsVfdlOKqyTxjSLrkXP);
							int num8 = -1437998601;
							goto IL_008b;
							IL_0086:
							num8 = -1437998604;
							goto IL_008b;
							IL_008b:
							switch (num8 ^ -1437998602)
							{
							case 0:
								break;
							default:
								goto end_IL_005d;
							case 2:
								goto IL_00a4;
							case 1:
								goto end_IL_005d;
							}
							goto IL_0086;
							end_IL_005d:;
						}
						catch (Exception)
						{
						}
					}
					num2++;
					goto IL_00bb;
				}
				IL_010c:
				if (num2 < num)
				{
					goto default;
				}
				num3 = -1437998603;
				goto IL_00c0;
				IL_00c0:
				while (true)
				{
					switch (num3 ^ -1437998602)
					{
					case 0:
						break;
					case 1:
						HDazfatCsQgEaDPiiXiqSfZKFtgb.bVJfbjSJHtCUhxVYYaQYFCJuPMDE();
						num3 = -1437998604;
						continue;
					case 3:
						goto IL_00f3;
					case 4:
						goto IL_010c;
					default:
						mQDFHrdaBBdDsJXeAJislCVaATuE.uNaPGXmbeHETCGQohISyNuDBchB(UQujyEkDBZwoueACHoIPpOHNWvF);
						lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
						{
							List<cyCsYcIQvugVJDWuUYpaIfgIudW> avwfdLjWSYyRUfRbGOqVqadERNGK = AvwfdLjWSYyRUfRbGOqVqadERNGK;
							while (true)
							{
								int num4 = -1437998604;
								while (true)
								{
									switch (num4 ^ -1437998602)
									{
									case 3:
										break;
									case 5:
										num5++;
										num4 = -1437998606;
										continue;
									case 1:
										num4 = -1437998606;
										continue;
									case 2:
									{
										int num6 = hShdCGGbdfKCwKvzqAgdyZHXxRH;
										count = list.Count;
										WioVicfbmtCEzmWlIpbInYpIgSp(num6, count, avwfdLjWSYyRUfRbGOqVqadERNGK, list);
										num5 = 0;
										num4 = -1437998601;
										continue;
									}
									case 0:
										if (_UpdateControllerInfoEvent != null)
										{
											_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[num5]));
											num4 = -1437998605;
											continue;
										}
										goto case 5;
									default:
										if (num5 >= count)
										{
											HZnuerKKqNbEDMtPsGxcuVmEOVA(avwfdLjWSYyRUfRbGOqVqadERNGK, list, false);
											HZnuerKKqNbEDMtPsGxcuVmEOVA(list, avwfdLjWSYyRUfRbGOqVqadERNGK, true);
											TyGGLfMxyzmqlngkgyRPGQHxWJ(list, avwfdLjWSYyRUfRbGOqVqadERNGK);
											AvwfdLjWSYyRUfRbGOqVqadERNGK = list;
											hShdCGGbdfKCwKvzqAgdyZHXxRH = list.Count;
											return;
										}
										goto case 0;
									}
									break;
								}
							}
						}
					}
					break;
					IL_00f3:
					int num7;
					if (UQujyEkDBZwoueACHoIPpOHNWvF != 0)
					{
						num3 = -1437998604;
						num7 = num3;
					}
					else
					{
						num3 = -1437998601;
						num7 = num3;
					}
				}
				goto IL_00bb;
				IL_00bb:
				num3 = -1437998606;
				goto IL_00c0;
			}
		}
	}

	private void oXEGWcsjcAgHnGkczKsVaIlTumpa(cyCsYcIQvugVJDWuUYpaIfgIudW P_0, KLdxxuJrfxnDixEHBLHuoAtHctc P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = cHGdLHdUWUiYzPziDkeopfYJjxqa.gLUZjbmwgOCjnwzLLPDKLEevbpq(P_1.InterfacePath);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			bUiVDUOAHpFECnWVzgHAGOUkHLxZ bUiVDUOAHpFECnWVzgHAGOUkHLxZ2 = eCKdLvtfldigSEOJNAhOjiRdUQDt.UNuqiishiPaFHelLRjlIKFypcai(text.ToLower(CultureInfo.InvariantCulture));
			if (bUiVDUOAHpFECnWVzgHAGOUkHLxZ2 != null)
			{
				P_0.NxfPDLDjjkkAByWVYHnViSDRJzU = bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.IsBluetoothDevice;
				P_0.ZODLrlcqYgYcHKPIQwZOreOIaYF = bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.BluetoothDeviceName;
				P_2 = XwFnLxypphHNgefilLFbGvPLvxl.WVhPWHLBAhlIDMgWMaWIAyWlQMY(bUiVDUOAHpFECnWVzgHAGOUkHLxZ2, P_0.qSJYeLiyjfTRCcMnvDOwuKWJouA, P_0.AOVTbdgjQpuvVXuOzJgmsvYOWec, P_0.ZODLrlcqYgYcHKPIQwZOreOIaYF);
				bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void nXErRbwAigpeSUKNnHDMPkYiLlQ()
	{
		lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
		{
			for (int i = 0; i < hShdCGGbdfKCwKvzqAgdyZHXxRH; i++)
			{
				try
				{
					cyCsYcIQvugVJDWuUYpaIfgIudW cyCsYcIQvugVJDWuUYpaIfgIudW2 = AvwfdLjWSYyRUfRbGOqVqadERNGK[i];
					if (cyCsYcIQvugVJDWuUYpaIfgIudW2 != null && cyCsYcIQvugVJDWuUYpaIfgIudW2.GnNaUkaHprcsTpLskywvfZOHPBmp() && (!ilRrVwkMgOLwkAAfYNNcVNLgBSS || !cyCsYcIQvugVJDWuUYpaIfgIudW2.KqmajqZRajQeRJHxvHBZhqVPgsd))
					{
						cyCsYcIQvugVJDWuUYpaIfgIudW2.Update();
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<vgUDhfmgAmAsRjRuQJnGENONMljC> vkKocwYHsCOUCRXUbieDJnolIsP()
	{
		try
		{
			IList<vgUDhfmgAmAsRjRuQJnGENONMljC> devices = pbsDzFwuvQvUwdnstjlbFubXWWZ.GetDevices(RSViiCwWYViTGbHemxBsoBfasVd.GbQpIWxEvYSkxUbfmBgPqSZfLDE, zGfVlsImnYjabwVEyjlINqRCfqKj.sQJXOWUzmAyNONjbRXYAwNmJORI);
			WePpeeROuHtUksObvZZGdnKIcxP = ((devices != null) ? devices.Count : 0);
			return devices;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			WePpeeROuHtUksObvZZGdnKIcxP = 0;
			return EmptyObjects<vgUDhfmgAmAsRjRuQJnGENONMljC>.EmptyReadOnlyIListT;
		}
	}

	private void hXpHtBuijEDJvGwJAKyobUHfOXu()
	{
		pbsDzFwuvQvUwdnstjlbFubXWWZ.GetDevices();
	}

	private void WioVicfbmtCEzmWlIpbInYpIgSp(int P_0, int P_1, List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_2, List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_3)
	{
		if (P_1 > 0)
		{
			goto IL_0007;
		}
		goto IL_00e5;
		IL_0007:
		int num = -1365770598;
		goto IL_000c;
		IL_000c:
		int num2 = default(int);
		cyCsYcIQvugVJDWuUYpaIfgIudW cyCsYcIQvugVJDWuUYpaIfgIudW2 = default(cyCsYcIQvugVJDWuUYpaIfgIudW);
		int num4;
		while (true)
		{
			switch (num ^ -1365770594)
			{
			case 7:
				break;
			case 5:
				num2 = 0;
				num = -1365770594;
				continue;
			case 9:
				cyCsYcIQvugVJDWuUYpaIfgIudW2.rewiredId = sbyIXavKIUtCermoZwGVxaaQFdB();
				VkhgikRmZCRpwCsFCAHFtklICJTg.twVDKshQikIuavgehoSXWHaPlJad(cyCsYcIQvugVJDWuUYpaIfgIudW2);
				num = -1365770604;
				continue;
			case 4:
				P_3.Sort(cyCsYcIQvugVJDWuUYpaIfgIudW.VeEwuyjQGIUrXMVDUTRgFgYWfdL);
				num = -1365770603;
				continue;
			case 2:
				goto IL_0096;
			case 10:
				num2++;
				num = -1365770594;
				continue;
			case 6:
				AGedmzbCJhMeJCJgHTXgNMEGvrXn(P_1, P_3, P_0, P_2, KMVVRABsNsdeaxZHCCUyhdAPsqS.uXqtyKXqEZOCQJjmqbpiBAwbhVOI.hsqFwVabxTxZDbitiWOUsqWRrjW);
				AGedmzbCJhMeJCJgHTXgNMEGvrXn(P_1, P_3, P_0, P_2, KMVVRABsNsdeaxZHCCUyhdAPsqS.uXqtyKXqEZOCQJjmqbpiBAwbhVOI.XSasYkIfXXTIuNYDajUSHAZXtRK);
				num = -1365770593;
				continue;
			case 11:
				goto IL_00e5;
			case 3:
				goto IL_00f3;
			case 1:
				MIoEQIuCiGhoUrcScRIygYMXpyI(P_1, P_3, KMVVRABsNsdeaxZHCCUyhdAPsqS.uXqtyKXqEZOCQJjmqbpiBAwbhVOI.hsqFwVabxTxZDbitiWOUsqWRrjW);
				MIoEQIuCiGhoUrcScRIygYMXpyI(P_1, P_3, KMVVRABsNsdeaxZHCCUyhdAPsqS.uXqtyKXqEZOCQJjmqbpiBAwbhVOI.XSasYkIfXXTIuNYDajUSHAZXtRK);
				num = -1365770597;
				continue;
			case 8:
				if (cyCsYcIQvugVJDWuUYpaIfgIudW2.inputManagerId < 0)
				{
					cyCsYcIQvugVJDWuUYpaIfgIudW2.inputManagerId = hJEtLubjiEObEqlHGFhLgmjnBHlp(P_3);
					num = -1365770601;
					continue;
				}
				goto case 10;
			default:
				if (num2 >= P_1)
				{
					P_3.Sort(cyCsYcIQvugVJDWuUYpaIfgIudW.aMOFswEFvnllveRohVGHhoVLgfBv);
					return;
				}
				goto IL_00f3;
			}
			break;
			IL_00f3:
			cyCsYcIQvugVJDWuUYpaIfgIudW2 = P_3[num2];
			int num3;
			if (cyCsYcIQvugVJDWuUYpaIfgIudW2 != null)
			{
				num = -1365770602;
				num3 = num;
			}
			else
			{
				num = -1365770604;
				num3 = num;
			}
			continue;
			IL_0096:
			if (P_1 > 0)
			{
				num = -1365770600;
				num4 = num;
				continue;
			}
			goto IL_00a9;
		}
		goto IL_0007;
		IL_00a9:
		num = -1365770593;
		num4 = num;
		goto IL_000c;
		IL_00e5:
		if (P_0 > 0)
		{
			num = -1365770596;
			goto IL_000c;
		}
		goto IL_00a9;
	}

	private void vpLhaJQfWoJCrEfgeBIeKQWnfTfi(List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				IL_0050:
				int num2;
				if (num != P_1 && P_0[num] != null)
				{
					int num3;
					if (P_0[num].inputManagerId == P_2)
					{
						num2 = -1285385490;
						num3 = num2;
					}
					else
					{
						num2 = -1285385489;
						num3 = num2;
					}
					goto IL_0010;
				}
				goto IL_0031;
				IL_0031:
				num++;
				num2 = -1285385493;
				goto IL_0010;
				IL_0010:
				while (true)
				{
					switch (num2 ^ -1285385489)
					{
					case 3:
						num2 = -1285385491;
						continue;
					case 0:
						break;
					case 1:
						P_0[num].inputManagerId = -1;
						num2 = -1285385489;
						continue;
					case 2:
						goto IL_0050;
					default:
						goto end_IL_0050;
					}
					break;
				}
				goto IL_0031;
				continue;
				end_IL_0050:
				break;
			}
		}
	}

	private bool vwcgKzwXKcPdZstsZhoZReCiCHfD(List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_0, int P_1)
	{
		int count = P_0.Count;
		int num2 = default(int);
		while (true)
		{
			int num = -1591709299;
			while (true)
			{
				switch (num ^ -1591709300)
				{
				case 0:
					break;
				case 1:
					num2 = 0;
					num = -1591709297;
					continue;
				case 4:
					if (P_0[num2] != null && P_0[num2].inputManagerId == P_1)
					{
						return false;
					}
					num2++;
					num = -1591709298;
					continue;
				case 3:
					num = -1591709298;
					continue;
				default:
					if (num2 >= count)
					{
						return true;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	private int hJEtLubjiEObEqlHGFhLgmjnBHlp(List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_0)
	{
		int num = 0;
		int num3 = default(int);
		bool flag = default(bool);
		int count = default(int);
		while (true)
		{
			int num2 = -1175098340;
			while (true)
			{
				switch (num2 ^ -1175098343)
				{
				case 6:
					break;
				case 0:
					if (P_0[num3] != null && P_0[num3].inputManagerId == num)
					{
						flag = true;
						num2 = -1175098339;
						continue;
					}
					goto case 7;
				case 7:
					num3++;
					num2 = -1175098342;
					continue;
				case 4:
					num2 = -1175098341;
					continue;
				case 5:
					flag = false;
					num2 = -1175098344;
					continue;
				case 3:
				{
					int num4;
					if (num3 >= count)
					{
						num2 = -1175098341;
						num4 = num2;
					}
					else
					{
						num2 = -1175098343;
						num4 = num2;
					}
					continue;
				}
				case 1:
					count = P_0.Count;
					num3 = 0;
					num2 = -1175098342;
					continue;
				default:
					if (!flag)
					{
						return num;
					}
					num++;
					goto case 5;
				}
				break;
			}
		}
	}

	private bool hlnxeRdKsPZbQWDLOeVNBuFoOaU(List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_0, int P_1)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		int num = 0;
		int num2 = -67719813;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num2 ^ -67719816)
			{
			case 4:
				break;
			case 5:
				return false;
			case 3:
				num2 = -67719814;
				continue;
			case 0:
				if (P_0[num].rewiredId == P_1)
				{
					return true;
				}
				num++;
				num2 = -67719814;
				continue;
			case 2:
			{
				int num3;
				if (num < P_0.Count)
				{
					num2 = -67719816;
					num3 = num2;
				}
				else
				{
					num2 = -67719815;
					num3 = num2;
				}
				continue;
			}
			default:
				return false;
			}
			break;
		}
		goto IL_0003;
		IL_0003:
		num2 = -67719811;
		goto IL_0008;
	}

	private void AGedmzbCJhMeJCJgHTXgNMEGvrXn(int P_0, List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_1, int P_2, List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_3, KMVVRABsNsdeaxZHCCUyhdAPsqS.uXqtyKXqEZOCQJjmqbpiBAwbhVOI P_4)
	{
		int num = ((P_4 != KMVVRABsNsdeaxZHCCUyhdAPsqS.uXqtyKXqEZOCQJjmqbpiBAwbhVOI.hsqFwVabxTxZDbitiWOUsqWRrjW) ? 1 : 2);
		int num2 = 0;
		cyCsYcIQvugVJDWuUYpaIfgIudW cyCsYcIQvugVJDWuUYpaIfgIudW2 = default(cyCsYcIQvugVJDWuUYpaIfgIudW);
		int num5 = default(int);
		while (true)
		{
			int num3 = -1084179071;
			while (true)
			{
				switch (num3 ^ -1084179069)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					num3 = -1084179065;
					continue;
				case 3:
					cyCsYcIQvugVJDWuUYpaIfgIudW2 = P_1[num2];
					num3 = -1084179066;
					continue;
				case 7:
				{
					int num6;
					if (num5 >= P_2)
					{
						num3 = -1084179062;
						num6 = num3;
					}
					else
					{
						num3 = -1084179067;
						num6 = num3;
					}
					continue;
				}
				case 6:
				{
					cyCsYcIQvugVJDWuUYpaIfgIudW cyCsYcIQvugVJDWuUYpaIfgIudW3 = P_3[num5];
					if (cyCsYcIQvugVJDWuUYpaIfgIudW3 != null && !hlnxeRdKsPZbQWDLOeVNBuFoOaU(P_1, cyCsYcIQvugVJDWuUYpaIfgIudW3.rewiredId) && cyCsYcIQvugVJDWuUYpaIfgIudW2.CjIOgfYLwvzSovgYNuiXTTvJjBe(cyCsYcIQvugVJDWuUYpaIfgIudW3) >= num)
					{
						cyCsYcIQvugVJDWuUYpaIfgIudW2.qmxqFhOXPynIFVlddeYJeiHLrJIQ(cyCsYcIQvugVJDWuUYpaIfgIudW3);
						VkhgikRmZCRpwCsFCAHFtklICJTg.twVDKshQikIuavgehoSXWHaPlJad(cyCsYcIQvugVJDWuUYpaIfgIudW2);
						num3 = -1084179070;
						continue;
					}
					goto case 1;
				}
				case 5:
					if (cyCsYcIQvugVJDWuUYpaIfgIudW2 != null && cyCsYcIQvugVJDWuUYpaIfgIudW2.inputManagerId < 0)
					{
						num5 = 0;
						num3 = -1084179068;
						continue;
					}
					goto case 9;
				case 4:
				{
					int num4;
					if (num2 >= P_0)
					{
						num3 = -1084179061;
						num4 = num3;
					}
					else
					{
						num3 = -1084179072;
						num4 = num3;
					}
					continue;
				}
				case 9:
					num2++;
					num3 = -1084179065;
					continue;
				case 1:
					num5++;
					num3 = -1084179068;
					continue;
				case 8:
					return;
				}
				break;
			}
		}
	}

	private void MIoEQIuCiGhoUrcScRIygYMXpyI(int P_0, List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_1, KMVVRABsNsdeaxZHCCUyhdAPsqS.uXqtyKXqEZOCQJjmqbpiBAwbhVOI P_2)
	{
		int num = 0;
		cyCsYcIQvugVJDWuUYpaIfgIudW cyCsYcIQvugVJDWuUYpaIfgIudW2 = default(cyCsYcIQvugVJDWuUYpaIfgIudW);
		int num4 = default(int);
		KMVVRABsNsdeaxZHCCUyhdAPsqS.MdRsFIBgSyIcSokQyFSNhZTIfhLq mdRsFIBgSyIcSokQyFSNhZTIfhLq = default(KMVVRABsNsdeaxZHCCUyhdAPsqS.MdRsFIBgSyIcSokQyFSNhZTIfhLq);
		while (true)
		{
			int num2 = -1275839897;
			while (true)
			{
				switch (num2 ^ -1275839902)
				{
				case 3:
					break;
				default:
					return;
				case 8:
					cyCsYcIQvugVJDWuUYpaIfgIudW2.inputManagerId = num4;
					num2 = -1275839904;
					continue;
				case 0:
				{
					int num5;
					if (mdRsFIBgSyIcSokQyFSNhZTIfhLq == null)
					{
						num2 = -1275839898;
						num5 = num2;
					}
					else
					{
						num2 = -1275839901;
						num5 = num2;
					}
					continue;
				}
				case 7:
					cyCsYcIQvugVJDWuUYpaIfgIudW2 = P_1[num];
					if (cyCsYcIQvugVJDWuUYpaIfgIudW2 != null && cyCsYcIQvugVJDWuUYpaIfgIudW2.inputManagerId < 0)
					{
						mdRsFIBgSyIcSokQyFSNhZTIfhLq = VkhgikRmZCRpwCsFCAHFtklICJTg.SNyQPMtxIqmpckDGNaILQiYNCbXF(cyCsYcIQvugVJDWuUYpaIfgIudW2, P_2);
						num2 = -1275839902;
						continue;
					}
					goto case 4;
				case 2:
					cyCsYcIQvugVJDWuUYpaIfgIudW2.rewiredId = mdRsFIBgSyIcSokQyFSNhZTIfhLq.InzpRLWBzesgNjVGacynCIMBDnJ;
					VkhgikRmZCRpwCsFCAHFtklICJTg.twVDKshQikIuavgehoSXWHaPlJad(cyCsYcIQvugVJDWuUYpaIfgIudW2);
					num2 = -1275839898;
					continue;
				case 4:
					num++;
					num2 = -1275839900;
					continue;
				case 10:
					mdRsFIBgSyIcSokQyFSNhZTIfhLq.WfZmTofniSsPbHKlehKQdLSahSv = num4;
					num2 = -1275839894;
					continue;
				case 1:
					if (!hlnxeRdKsPZbQWDLOeVNBuFoOaU(P_1, mdRsFIBgSyIcSokQyFSNhZTIfhLq.InzpRLWBzesgNjVGacynCIMBDnJ))
					{
						num4 = mdRsFIBgSyIcSokQyFSNhZTIfhLq.WfZmTofniSsPbHKlehKQdLSahSv;
						if (num4 >= 0)
						{
							if (!vwcgKzwXKcPdZstsZhoZReCiCHfD(P_1, num4))
							{
								num4 = hJEtLubjiEObEqlHGFhLgmjnBHlp(P_1);
								num2 = -1275839896;
								continue;
							}
							goto case 8;
						}
					}
					goto case 4;
				case 6:
				{
					int num3;
					if (num < P_0)
					{
						num2 = -1275839899;
						num3 = num2;
					}
					else
					{
						num2 = -1275839893;
						num3 = num2;
					}
					continue;
				}
				case 5:
					num2 = -1275839900;
					continue;
				case 9:
					return;
				}
				break;
			}
		}
	}

	private void rlecVsIXXYBuTWpNWMljozzsJsK()
	{
		if (NLvIuZNNslOQGzDqMqqhEmdQXHU)
		{
			DYXOSuUNEXtEAxrLMyQgtEjEnNO();
			goto IL_000e;
		}
		goto IL_002c;
		IL_002c:
		int num;
		if (sFMJuNkEjRgiflkDeBTrYjCaAcmb.isRunning && sFMJuNkEjRgiflkDeBTrYjCaAcmb.xHkLCHGKEGSLVNAFPpLRGAkaRJs())
		{
			SzxmDjxbrUAggcZJTsvgnNMpYtvn(sFMJuNkEjRgiflkDeBTrYjCaAcmb.result);
			num = 627288681;
			goto IL_0013;
		}
		return;
		IL_000e:
		num = 627288680;
		goto IL_0013;
		IL_0013:
		switch (num ^ 0x2563AA69)
		{
		case 2:
			break;
		default:
			return;
		case 1:
			goto IL_002c;
		case 0:
			return;
		}
		goto IL_000e;
	}

	private void DYXOSuUNEXtEAxrLMyQgtEjEnNO()
	{
		NLvIuZNNslOQGzDqMqqhEmdQXHU = false;
		if (sFMJuNkEjRgiflkDeBTrYjCaAcmb.isRunning)
		{
			while (true)
			{
				switch (-376514378 ^ -376514377)
				{
				case 2:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		sFMJuNkEjRgiflkDeBTrYjCaAcmb.CNNCNIEIEPKDJVWLdcWrLrRIbyb();
	}

	private void SzxmDjxbrUAggcZJTsvgnNMpYtvn(List<YAjKnZfpTdaPnJGYGKFAREGNSenm> P_0)
	{
		if (!rBuqPQDHkShnzbSQZPtjpzuipiG(YAjKnZfpTdaPnJGYGKFAREGNSenm.QpCraBwLLtOUMbSXGHheyNUgrgl(P_0)))
		{
			return;
		}
		while (true)
		{
			int num = 206997041;
			while (true)
			{
				switch (num ^ 0xC568630)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					goto IL_002c;
				case 2:
					return;
				}
				break;
				IL_002c:
				JGdcjKsYsJfmhyjdevgVFNadqXW(P_0);
				num = 206997042;
			}
		}
	}

	private bool rBuqPQDHkShnzbSQZPtjpzuipiG(IList<vgUDhfmgAmAsRjRuQJnGENONMljC> P_0)
	{
		lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !eNPklNfgpqYVTvVTCPrrltwNiDp(P_0[i].enAPtHYaqiBCfCxaGvASHsInALh))
				{
					return true;
				}
			}
			int count2 = AvwfdLjWSYyRUfRbGOqVqadERNGK.Count;
			for (int j = 0; j < count2; j++)
			{
				if (AvwfdLjWSYyRUfRbGOqVqadERNGK[j] != null && !NHFlLujTFOmTrBJwxohTnqZbdaWH(P_0, AvwfdLjWSYyRUfRbGOqVqadERNGK[j].instanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool eNPklNfgpqYVTvVTCPrrltwNiDp(Guid P_0)
	{
		lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
		{
			int count = AvwfdLjWSYyRUfRbGOqVqadERNGK.Count;
			int num = 0;
			bool result = default(bool);
			while (num < count)
			{
				while (true)
				{
					int num2;
					if (AvwfdLjWSYyRUfRbGOqVqadERNGK[num] != null && AvwfdLjWSYyRUfRbGOqVqadERNGK[num].instanceGuid == P_0)
					{
						result = true;
						num2 = -1334688590;
						goto IL_0022;
					}
					goto IL_0073;
					IL_0073:
					num++;
					num2 = -1334688587;
					goto IL_0022;
					IL_0022:
					while (true)
					{
						switch (num2 ^ -1334688591)
						{
						case 0:
							num2 = -1334688589;
							continue;
						case 2:
							break;
						case 1:
							goto IL_0073;
						default:
							goto end_IL_0043;
						case 3:
							return result;
						}
						break;
					}
					continue;
					end_IL_0043:
					break;
				}
			}
		}
		return false;
	}

	private bool NHFlLujTFOmTrBJwxohTnqZbdaWH(IList<vgUDhfmgAmAsRjRuQJnGENONMljC> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].enAPtHYaqiBCfCxaGvASHsInALh == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void HZnuerKKqNbEDMtPsGxcuVmEOVA(List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_0, List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num6 = default(int);
		int num3 = default(int);
		cyCsYcIQvugVJDWuUYpaIfgIudW cyCsYcIQvugVJDWuUYpaIfgIudW2 = default(cyCsYcIQvugVJDWuUYpaIfgIudW);
		bool flag = default(bool);
		int num4 = default(int);
		while (true)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			int num2 = -484855392;
			while (true)
			{
				switch (num2 ^ -484855387)
				{
				case 0:
					num2 = -484855385;
					continue;
				default:
					return;
				case 11:
				{
					int num9;
					if (num6 >= num)
					{
						num2 = -484855377;
						num9 = num2;
					}
					else
					{
						num2 = -484855384;
						num9 = num2;
					}
					continue;
				}
				case 6:
					rVPjnRIbMLDOGrkwREudCiotksA(P_0[num6], P_2);
					num2 = -484855388;
					continue;
				case 4:
					num3++;
					num2 = -484855380;
					continue;
				case 1:
					num6++;
					num2 = -484855378;
					continue;
				case 2:
					break;
				case 8:
				{
					cyCsYcIQvugVJDWuUYpaIfgIudW cyCsYcIQvugVJDWuUYpaIfgIudW3 = P_1[num3];
					if (cyCsYcIQvugVJDWuUYpaIfgIudW3 != null && cyCsYcIQvugVJDWuUYpaIfgIudW2.instanceGuid == cyCsYcIQvugVJDWuUYpaIfgIudW3.instanceGuid)
					{
						flag = true;
						num2 = -484855386;
						continue;
					}
					goto case 4;
				}
				case 5:
					num4 = ((P_1 != null) ? P_1.Count : 0);
					num6 = 0;
					num2 = -484855378;
					continue;
				case 12:
					flag = false;
					if (P_1 != null)
					{
						num3 = 0;
						num2 = -484855390;
						continue;
					}
					goto case 3;
				case 7:
					num2 = -484855380;
					continue;
				case 13:
				{
					cyCsYcIQvugVJDWuUYpaIfgIudW2 = P_0[num6];
					int num7;
					if (cyCsYcIQvugVJDWuUYpaIfgIudW2 == null)
					{
						num2 = -484855388;
						num7 = num2;
					}
					else
					{
						num2 = -484855383;
						num7 = num2;
					}
					continue;
				}
				case 9:
				{
					int num5;
					if (num3 < num4)
					{
						num2 = -484855379;
						num5 = num2;
					}
					else
					{
						num2 = -484855386;
						num5 = num2;
					}
					continue;
				}
				case 3:
				{
					int num8;
					if (!flag)
					{
						num2 = -484855389;
						num8 = num2;
					}
					else
					{
						num2 = -484855388;
						num8 = num2;
					}
					continue;
				}
				case 10:
					return;
				}
				break;
			}
		}
	}

	private void rVPjnRIbMLDOGrkwREudCiotksA(cyCsYcIQvugVJDWuUYpaIfgIudW P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent == null)
			{
				return;
			}
			goto IL_000b;
		}
		goto IL_0051;
		IL_0051:
		int num;
		if (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
			num = -1881354269;
			goto IL_0010;
		}
		return;
		IL_000b:
		num = -1881354267;
		goto IL_0010;
		IL_0010:
		while (true)
		{
			switch (num ^ -1881354271)
			{
			case 0:
				break;
			default:
				return;
			case 4:
				_DeviceConnectedEvent(P_0.ToBridgedController());
				num = -1881354270;
				continue;
			case 3:
				return;
			case 1:
				goto IL_0051;
			case 2:
				return;
			}
			break;
		}
		goto IL_000b;
	}

	private bool ZJMbdcnTjSsyftGUjHTjFwTkOLv()
	{
		int num = pbsDzFwuvQvUwdnstjlbFubXWWZ.GetDeviceCount(RSViiCwWYViTGbHemxBsoBfasVd.GbQpIWxEvYSkxUbfmBgPqSZfLDE, zGfVlsImnYjabwVEyjlINqRCfqKj.sQJXOWUzmAyNONjbRXYAwNmJORI);
		if (WePpeeROuHtUksObvZZGdnKIcxP != num)
		{
			WePpeeROuHtUksObvZZGdnKIcxP = num;
			return true;
		}
		if (UQujyEkDBZwoueACHoIPpOHNWvF > 0 && mQDFHrdaBBdDsJXeAJislCVaATuE.AUcwHyjHDCDTUaWUcgnSLQKbywcu())
		{
			return true;
		}
		return false;
	}

	private void TyGGLfMxyzmqlngkgyRPGQHxWJ(List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_0, List<cyCsYcIQvugVJDWuUYpaIfgIudW> P_1)
	{
		if (P_1 == null)
		{
			goto IL_0003;
		}
		goto IL_0048;
		IL_0003:
		int num = -1165217053;
		goto IL_0008;
		IL_0008:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -1165217054)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				return;
			case 4:
				num2++;
				num = -1165217052;
				continue;
			case 3:
				goto IL_0048;
			case 2:
				P_1[num2].HtJdxRxaGggkmaMTSWUpHqjZLDV();
				num = -1165217050;
				continue;
			case 7:
				if (P_1[num2] == null)
				{
					goto case 4;
				}
				if (P_0 == null)
				{
					goto case 2;
				}
				goto IL_0070;
			case 6:
				goto IL_0093;
			case 5:
				return;
			}
			break;
			IL_0093:
			int num3;
			if (num2 >= P_1.Count)
			{
				num = -1165217049;
				num3 = num;
			}
			else
			{
				num = -1165217051;
				num3 = num;
			}
			continue;
			IL_0070:
			int num4;
			if (!P_0.Contains(P_1[num2]))
			{
				num = -1165217056;
				num4 = num;
			}
			else
			{
				num = -1165217050;
				num4 = num;
			}
		}
		goto IL_0003;
		IL_0048:
		num2 = 0;
		num = -1165217052;
		goto IL_0008;
	}

	[Conditional("DEBUGTHIS")]
	private void PGWlUvALtNEAAVDIUVwKDUpOIns(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<YAjKnZfpTdaPnJGYGKFAREGNSenm> vxYwJEgFtWWDxBWSZdxIIAngOkk()
	{
		return oxtQbscWwzMCiJgvDPikBNLRDAgi();
	}
}
