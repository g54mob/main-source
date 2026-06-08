using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
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

internal class kPcCNnzXGURfWeRfxqXeAVfOFYx : PlatformInputManager, pBqgKWLeCLFlqaXbtEoODTfhYyUL
{
	private class MUlnPVcZgGLeXkhLihgLQlrmnHb : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int EXConJjMyypIPGpmnoMnbRhdgLW;

		private int JuzBXDTMFrDVUhqtKRLmdorveybr;

		public Guid UfFFvwXyyVSVFqRBlSrwmIuVpoX;

		public string AAVbVyNqUOuvZbdAweQkkZTDvgMS;

		public readonly IPQPLNMoyLRdmrBDMONOOacSFFX bBSBxriglpnOAawkfBpKCJgyYmdh;

		public wgrxsaianMUzjNMhgoWaIreVzBL pBDqZeaDGlqHjIwWxDonvqdrIAY;

		public oqTDYwuZOTBrxUXrMkuLhLRueIm rrfmJyUDkKMJIxIelilHFVjRKUAM;

		public string vhbvSIyRvLTNKIdHyehnSxBQFBz;

		public string DVaqHcutoHoUrPluDMMcnunKAGA;

		public int sEJsjYepUiBfnYUEFbfTIGbRtAM;

		public Guid duuMMyqFfJAeBAlnwwCpaWGlBUgO;

		public Guid jswiKSoBCTxrqereFiOojDxDRmw;

		public Guid LFrLHWCZQzUjUEpwygbljLuHiCF;

		public int zuIOHHSFjUvtYoHqYbOkIVnjKLJ;

		public bool MVCWNUJrDWfwziBxuAuBAzgJAhiF;

		public string OWynlsqwgASivUcmwQTMqEbSEpd;

		public string vhYYOxGmghVJJPAGQjILaUdlbckp;

		public int bxgcDFqOQApgYslsUNoAyTPhJYH;

		public int opznTvXijlFgLFSdvYEAiweymVQ;

		public int qhBaQiBUaifpRBvldoZTqTDFPFqY;

		public int lenAIRsoOFqjBdbpibHDlBXGVmR;

		public int QQactFjAyaivYJCKROwerenGIZRE;

		public bool XWJGdtiTCNTQbkDNDyOHMuyHxoJn;

		private float[] UeCdPcJARqFdGACIKPtkWZxawHVX;

		private bool[] mCgSEFdyltyHHshVpCgaWFFUiOPJ;

		private HardwareJoystickMap_InputManager UDBtEeitridwJAiaUtqcfFDaFaI;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> qnewRYFCzYevHqfqyatlbQmZFOFg;

		private bool zzVdHXNFUtEpnTWJnqCoLRkJxcS;

		private bool YhPoJfQiAmHSpianQZbJomoJUOB;

		private bool inweGjIgYacXYohFlYRlpMFkgKMi;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return EXConJjMyypIPGpmnoMnbRhdgLW;
			}
			set
			{
				EXConJjMyypIPGpmnoMnbRhdgLW = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return JuzBXDTMFrDVUhqtKRLmdorveybr;
			}
			set
			{
				JuzBXDTMFrDVUhqtKRLmdorveybr = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (AAVbVyNqUOuvZbdAweQkkZTDvgMS != "Unknown Controller")
				{
					goto IL_0012;
				}
				int num;
				if (MVCWNUJrDWfwziBxuAuBAzgJAhiF && !string.IsNullOrEmpty(OWynlsqwgASivUcmwQTMqEbSEpd))
				{
					num = 1734526956;
					goto IL_0017;
				}
				return DVaqHcutoHoUrPluDMMcnunKAGA;
				IL_0017:
				switch (num ^ 0x6762C7EE)
				{
				case 0:
					break;
				case 1:
					return AAVbVyNqUOuvZbdAweQkkZTDvgMS;
				default:
					return OWynlsqwgASivUcmwQTMqEbSEpd;
				}
				goto IL_0012;
				IL_0012:
				num = 1734526959;
				goto IL_0017;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (JuzBXDTMFrDVUhqtKRLmdorveybr < 0)
				{
					return null;
				}
				return JuzBXDTMFrDVUhqtKRLmdorveybr;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension => null;

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => duuMMyqFfJAeBAlnwwCpaWGlBUgO;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public MUlnPVcZgGLeXkhLihgLQlrmnHb(IPQPLNMoyLRdmrBDMONOOacSFFX sourceJoystick, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			bBSBxriglpnOAawkfBpKCJgyYmdh = sourceJoystick;
			qnewRYFCzYevHqfqyatlbQmZFOFg = getHardwareJoystickMap_InputManager;
			JuzBXDTMFrDVUhqtKRLmdorveybr = -1;
			EXConJjMyypIPGpmnoMnbRhdgLW = -1;
		}

		public void jDkVEgygiHHntkZXtjEwiSihtux()
		{
			LFrLHWCZQzUjUEpwygbljLuHiCF = MiscTools.CreateGuidHashSHA1(DVaqHcutoHoUrPluDMMcnunKAGA + jswiKSoBCTxrqereFiOojDxDRmw);
			bxgcDFqOQApgYslsUNoAyTPhJYH = qhBaQiBUaifpRBvldoZTqTDFPFqY;
			opznTvXijlFgLFSdvYEAiweymVQ = lenAIRsoOFqjBdbpibHDlBXGVmR + QQactFjAyaivYJCKROwerenGIZRE * 8;
			UVFtCXlXPJBKXqaKnfwDHhlUFOJ();
			UfFFvwXyyVSVFqRBlSrwmIuVpoX = UDBtEeitridwJAiaUtqcfFDaFaI.hardwareMapIdentifier.guid;
			AAVbVyNqUOuvZbdAweQkkZTDvgMS = UDBtEeitridwJAiaUtqcfFDaFaI.controllerName;
			zzVdHXNFUtEpnTWJnqCoLRkJxcS = ((UfFFvwXyyVSVFqRBlSrwmIuVpoX == Guid.Empty) ? true : false);
			UeCdPcJARqFdGACIKPtkWZxawHVX = new float[bxgcDFqOQApgYslsUNoAyTPhJYH];
			mCgSEFdyltyHHshVpCgaWFFUiOPJ = new bool[opznTvXijlFgLFSdvYEAiweymVQ];
			bBSBxriglpnOAawkfBpKCJgyYmdh.ZLkRominQCKUBwwrVSwFZLKUpyk();
			Update();
		}

		public void laWNKiWcrSexnZtRRPyPhNqRVNc(MUlnPVcZgGLeXkhLihgLQlrmnHb P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				JuzBXDTMFrDVUhqtKRLmdorveybr = P_0.JuzBXDTMFrDVUhqtKRLmdorveybr;
				EXConJjMyypIPGpmnoMnbRhdgLW = P_0.EXConJjMyypIPGpmnoMnbRhdgLW;
				int num = 0;
				int num2 = 1241120198;
				while (true)
				{
					switch (num2 ^ 0x49F9FDC2)
					{
					case 0:
						num2 = 1241120197;
						continue;
					default:
						return;
					case 5:
						UeCdPcJARqFdGACIKPtkWZxawHVX[num3] = P_0.UeCdPcJARqFdGACIKPtkWZxawHVX[num3];
						num3++;
						num2 = 1241120195;
						continue;
					case 4:
						num2 = 1241120192;
						continue;
					case 3:
						mCgSEFdyltyHHshVpCgaWFFUiOPJ[num] = P_0.mCgSEFdyltyHHshVpCgaWFFUiOPJ[num];
						num++;
						num2 = 1241120192;
						continue;
					case 1:
						if (num3 >= MathTools.Min(UeCdPcJARqFdGACIKPtkWZxawHVX.Length, P_0.UeCdPcJARqFdGACIKPtkWZxawHVX.Length))
						{
							YhPoJfQiAmHSpianQZbJomoJUOB = P_0.YhPoJfQiAmHSpianQZbJomoJUOB;
							bBSBxriglpnOAawkfBpKCJgyYmdh.laWNKiWcrSexnZtRRPyPhNqRVNc(P_0.bBSBxriglpnOAawkfBpKCJgyYmdh);
							num2 = 1241120196;
							continue;
						}
						goto case 5;
					case 7:
						break;
					case 2:
						if (num >= MathTools.Min(mCgSEFdyltyHHshVpCgaWFFUiOPJ.Length, P_0.mCgSEFdyltyHHshVpCgaWFFUiOPJ.Length))
						{
							num3 = 0;
							num2 = 1241120195;
							continue;
						}
						goto case 3;
					case 6:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			bBSBxriglpnOAawkfBpKCJgyYmdh.FHAWEJygpGBmQamZGcnJraVJkRh();
			bool[] currentButtonValues = default(bool[]);
			while (true)
			{
				int num = 619440555;
				while (true)
				{
					switch (num ^ 0x24EBE9A9)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						currentButtonValues = bBSBxriglpnOAawkfBpKCJgyYmdh.CurrentButtonValues;
						num = 619440552;
						continue;
					case 1:
					{
						int[] xqptHUWwYgqMYJETCHvCcscGRUQ = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.xqptHUWwYgqMYJETCHvCcscGRUQ;
						TcQALxknWBDsjjDgfcKnpyWUiBqK(currentButtonValues, xqptHUWwYgqMYJETCHvCcscGRUQ);
						aGwDgiXyNNqhCEqcVEYQleQFBPn(currentButtonValues, xqptHUWwYgqMYJETCHvCcscGRUQ);
						bBSBxriglpnOAawkfBpKCJgyYmdh.fHvlAyzcxwcbEJYkeBnphlWsGSD();
						num = 619440554;
						continue;
					}
					case 3:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (bxgcDFqOQApgYslsUNoAyTPhJYH == dataUpdater.axisCount)
			{
				if (opznTvXijlFgLFSdvYEAiweymVQ != dataUpdater.buttonCount)
				{
					goto IL_001c;
				}
				goto IL_006b;
			}
			goto IL_008b;
			IL_008b:
			throw new Exception("This controller signature does not match the data object!");
			IL_001c:
			int num = 1623415441;
			goto IL_0021;
			IL_0021:
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x60C35A94)
				{
				case 0:
					break;
				default:
					return;
				case 7:
					dataUpdater.hasReceivedInput = true;
					num = 1623415447;
					continue;
				case 8:
					goto IL_006b;
				case 1:
					dataUpdater.axisValues[num3] = UeCdPcJARqFdGACIKPtkWZxawHVX[num3];
					num = 1623415454;
					continue;
				case 5:
					goto IL_008b;
				case 10:
					num3++;
					num = 1623415453;
					continue;
				case 6:
					dataUpdater.buttonValues[num2] = mCgSEFdyltyHHshVpCgaWFFUiOPJ[num2];
					num2++;
					num = 1623415446;
					continue;
				case 9:
					if (num3 >= bxgcDFqOQApgYslsUNoAyTPhJYH)
					{
						num2 = 0;
						num = 1623415440;
						continue;
					}
					goto case 1;
				case 2:
					if (num2 < opznTvXijlFgLFSdvYEAiweymVQ)
					{
						goto case 6;
					}
					goto IL_00e7;
				case 4:
					num = 1623415446;
					continue;
				case 3:
					return;
				}
				break;
				IL_00e7:
				if (YhPoJfQiAmHSpianQZbJomoJUOB)
				{
					int num4;
					if (dataUpdater.hasReceivedInput)
					{
						num = 1623415447;
						num4 = num;
					}
					else
					{
						num = 1623415443;
						num4 = num;
					}
					continue;
				}
				return;
			}
			goto IL_001c;
			IL_006b:
			num3 = 0;
			num = 1623415453;
			goto IL_0021;
		}

		public int FcvkUyKypZmJCfGSpczJhAaNNjEx(MUlnPVcZgGLeXkhLihgLQlrmnHb P_0)
		{
			if (P_0.EXConJjMyypIPGpmnoMnbRhdgLW == EXConJjMyypIPGpmnoMnbRhdgLW)
			{
				return 2;
			}
			if (qhBaQiBUaifpRBvldoZTqTDFPFqY != P_0.qhBaQiBUaifpRBvldoZTqTDFPFqY)
			{
				return 0;
			}
			if (lenAIRsoOFqjBdbpibHDlBXGVmR != P_0.lenAIRsoOFqjBdbpibHDlBXGVmR)
			{
				return 0;
			}
			if (QQactFjAyaivYJCKROwerenGIZRE != P_0.QQactFjAyaivYJCKROwerenGIZRE)
			{
				return 0;
			}
			if (P_0.instanceGuid == instanceGuid)
			{
				return 2;
			}
			if (P_0.LFrLHWCZQzUjUEpwygbljLuHiCF == LFrLHWCZQzUjUEpwygbljLuHiCF)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo GcYjAXCLyrkmacLFLclUoLjdDBr()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			dGqnYVYWgCeqfZEbphqNBhbNleek(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			dGqnYVYWgCeqfZEbphqNBhbNleek(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(EXConJjMyypIPGpmnoMnbRhdgLW);
		}

		public bool BooOvjDDXJCPvNBIKejrMetJcRQF()
		{
			try
			{
				bBSBxriglpnOAawkfBpKCJgyYmdh.LMofllDVwkfLxnRkZcSVHJPEQcuP.sExLEGkyJhPcbgBaSuUvVofcAhFK();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void HyqAXbAgFcqWiYfxZzBDTyqsqlp()
		{
			try
			{
				if (bBSBxriglpnOAawkfBpKCJgyYmdh.LMofllDVwkfLxnRkZcSVHJPEQcuP != null)
				{
					bBSBxriglpnOAawkfBpKCJgyYmdh.LMofllDVwkfLxnRkZcSVHJPEQcuP.HyqAXbAgFcqWiYfxZzBDTyqsqlp();
				}
			}
			catch
			{
			}
		}

		public void UWOOMlZOWZtWbNikUvqswMufgfx()
		{
			try
			{
				if (bBSBxriglpnOAawkfBpKCJgyYmdh.LMofllDVwkfLxnRkZcSVHJPEQcuP == null)
				{
					return;
				}
				while (true)
				{
					int num = -334808219;
					while (true)
					{
						switch (num ^ -334808220)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_002b;
						case 2:
							return;
						}
						break;
						IL_002b:
						bBSBxriglpnOAawkfBpKCJgyYmdh.LMofllDVwkfLxnRkZcSVHJPEQcuP.UWOOMlZOWZtWbNikUvqswMufgfx();
						num = -334808218;
					}
				}
			}
			catch
			{
			}
		}

		private void TcQALxknWBDsjjDgfcKnpyWUiBqK(bool[] P_0, int[] P_1)
		{
			if (bxgcDFqOQApgYslsUNoAyTPhJYH <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig = default(HardwareJoystickMap.Platform_RawInput_Base.Axis[]);
			int num2 = default(int);
			int num3 = default(int);
			HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig2 = default(HardwareJoystickMap.Platform_DirectInput_Base.Axis[]);
			while (true)
			{
				InputPlatform platform = UDBtEeitridwJAiaUtqcfFDaFaI.map.platform;
				int num;
				if (platform == InputPlatform.TxthorEPmOLBHYyZxIReALnmNeM)
				{
					HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map;
					axes_orig = platform_RawInput_Base.Axes_orig;
					num = 133494244;
					goto IL_000f;
				}
				goto IL_00c3;
				IL_000f:
				while (true)
				{
					switch (num ^ 0x7F4F5E6)
					{
					case 9:
						num = 133494253;
						continue;
					default:
						return;
					case 11:
						break;
					case 0:
						num2 = 0;
						num = 133494245;
						continue;
					case 6:
						MESJAHDhCuoZzFfOnSstZllUyWn(axes_orig[num3], num3, P_0, P_1);
						num3++;
						num = 133494252;
						continue;
					case 2:
						if (axes_orig == null)
						{
							return;
						}
						goto case 8;
					case 4:
						return;
					case 5:
						goto IL_00c3;
					case 3:
						goto IL_00fd;
					case 10:
						if (num3 >= axes_orig.Length)
						{
							return;
						}
						goto case 6;
					case 8:
						num3 = 0;
						num = 133494252;
						continue;
					case 7:
						MESJAHDhCuoZzFfOnSstZllUyWn(axes_orig2[num2], num2, P_0, P_1);
						num2++;
						num = 133494245;
						continue;
					case 1:
						return;
					}
					break;
					IL_00fd:
					int num4;
					if (num2 >= axes_orig2.Length)
					{
						num = 133494247;
						num4 = num;
					}
					else
					{
						num = 133494241;
						num4 = num;
					}
				}
				continue;
				IL_00c3:
				if (platform == InputPlatform.nxzcJmevYVMAWQJHQoCKKweYMfMv)
				{
					HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map;
					axes_orig2 = platform_DirectInput_Base.Axes_orig;
					int num5;
					if (axes_orig2 != null)
					{
						num = 133494246;
						num5 = num;
					}
					else
					{
						num = 133494242;
						num5 = num;
					}
					goto IL_000f;
				}
				break;
			}
		}

		private void aGwDgiXyNNqhCEqcVEYQleQFBPn(bool[] P_0, int[] P_1)
		{
			if (opznTvXijlFgLFSdvYEAiweymVQ <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = default(HardwareJoystickMap.Platform_RawInput_Base);
			int num2 = default(int);
			HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig = default(HardwareJoystickMap.Platform_RawInput_Base.Button[]);
			HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = default(HardwareJoystickMap.Platform_DirectInput_Base.Button[]);
			int num3 = default(int);
			HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = default(HardwareJoystickMap.Platform_DirectInput_Base);
			while (true)
			{
				InputPlatform platform = UDBtEeitridwJAiaUtqcfFDaFaI.map.platform;
				int num;
				if (platform == InputPlatform.TxthorEPmOLBHYyZxIReALnmNeM)
				{
					platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map;
					num = -497259174;
					goto IL_000f;
				}
				goto IL_00e4;
				IL_000f:
				while (true)
				{
					switch (num ^ -497259181)
					{
					case 14:
						num = -497259184;
						continue;
					default:
						return;
					case 3:
						break;
					case 7:
						if (num2 >= buttons_orig.Length)
						{
							return;
						}
						goto case 1;
					case 6:
						SPXGYihGXHFuAFquACCBaZiSvIdu(buttons_orig2[num3], num3, P_0, P_1);
						num3++;
						num = -497259177;
						continue;
					case 4:
						goto IL_00bb;
					case 5:
						num3 = 0;
						num = -497259177;
						continue;
					case 2:
						goto IL_00e4;
					case 9:
						buttons_orig = platform_RawInput_Base.Buttons_orig;
						num = -497259170;
						continue;
					case 10:
						num2++;
						num = -497259180;
						continue;
					case 8:
						buttons_orig2 = platform_DirectInput_Base.Buttons_orig;
						if (buttons_orig2 == null)
						{
							return;
						}
						goto case 5;
					case 1:
						SPXGYihGXHFuAFquACCBaZiSvIdu(buttons_orig[num2], num2, P_0, P_1);
						num = -497259175;
						continue;
					case 11:
						num2 = 0;
						num = -497259169;
						continue;
					case 12:
						num = -497259180;
						continue;
					case 13:
						if (buttons_orig == null)
						{
							return;
						}
						goto case 11;
					case 0:
						return;
					}
					break;
					IL_00bb:
					int num4;
					if (num3 >= buttons_orig2.Length)
					{
						num = -497259181;
						num4 = num;
					}
					else
					{
						num = -497259179;
						num4 = num;
					}
				}
				continue;
				IL_00e4:
				if (platform == InputPlatform.nxzcJmevYVMAWQJHQoCKKweYMfMv)
				{
					platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map;
					num = -497259173;
					goto IL_000f;
				}
				break;
			}
		}

		private void MESJAHDhCuoZzFfOnSstZllUyWn(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= bxgcDFqOQApgYslsUNoAyTPhJYH)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			while (true)
			{
				UeCdPcJARqFdGACIKPtkWZxawHVX[P_1] = LaNWitWQqyZMqUSPioBpzBMOpwf(P_0, P_2, P_3);
				int num;
				int num2;
				if (YhPoJfQiAmHSpianQZbJomoJUOB)
				{
					num = 1187134468;
					num2 = num;
				}
				else
				{
					num = 1187134471;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x46C23C04)
					{
					case 2:
						num = 1187134469;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						if (UeCdPcJARqFdGACIKPtkWZxawHVX[P_1] != 0f)
						{
							YhPoJfQiAmHSpianQZbJomoJUOB = true;
							num = 1187134468;
							continue;
						}
						return;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void SPXGYihGXHFuAFquACCBaZiSvIdu(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= opznTvXijlFgLFSdvYEAiweymVQ)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			while (true)
			{
				mCgSEFdyltyHHshVpCgaWFFUiOPJ[P_1] = fjKDuIFmYPFHshMFIEKwpUOEovgL(P_0, P_2, P_3);
				if (YhPoJfQiAmHSpianQZbJomoJUOB || !mCgSEFdyltyHHshVpCgaWFFUiOPJ[P_1])
				{
					break;
				}
				YhPoJfQiAmHSpianQZbJomoJUOB = true;
				int num = 850749845;
				while (true)
				{
					switch (num ^ 0x32B56995)
					{
					case 2:
						goto IL_0014;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0014:
					num = 850749844;
				}
			}
		}

		private float LaNWitWQqyZMqUSPioBpzBMOpwf(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis > 0)
				{
					if (P_0.sourceAxis < 32)
					{
						return LaNWitWQqyZMqUSPioBpzBMOpwf((DirectInputAxis)P_0.sourceAxis);
					}
					goto IL_0025;
				}
				goto IL_01b5;
			}
			int sourceButton = default(int);
			int num;
			CustomCalculation customCalculation = default(CustomCalculation);
			HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[]);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				sourceButton = P_0.sourceButton;
				int num2;
				if (sourceButton < 0)
				{
					num = 1970873841;
					num2 = num;
				}
				else
				{
					num = 1970873845;
					num2 = num;
				}
			}
			else if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
				{
					return 0f;
				}
				customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				customCalculationSourceData = P_0.customCalculationSourceData;
				num = 1970873842;
			}
			else
			{
				num = 1970873843;
			}
			goto IL_002a;
			IL_0025:
			num = 1970873854;
			goto IL_002a;
			IL_01b5:
			return 0f;
			IL_002a:
			HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
			int num5 = default(int);
			float num3 = default(float);
			float item = default(float);
			int num4 = default(int);
			float result = default(float);
			while (true)
			{
				int sourceHat;
				switch (num ^ 0x757925FA)
				{
				case 20:
					break;
				case 7:
					sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[num5].sourceType;
					num = 1970873848;
					continue;
				case 8:
					goto IL_00a1;
				case 13:
					goto IL_00b8;
				case 11:
					return 0f;
				case 14:
					num3 *= -1f;
					num = 1970873852;
					continue;
				case 19:
					customCalculation.AddData(item);
					num = 1970873832;
					continue;
				case 6:
					return num3;
				case 9:
					sourceHat = P_0.sourceHat;
					if (sourceHat >= 0 && sourceHat < QQactFjAyaivYJCKROwerenGIZRE)
					{
						goto IL_0182;
					}
					goto case 0;
				case 15:
					if (sourceButton >= lenAIRsoOFqjBdbpibHDlBXGVmR)
					{
						goto case 11;
					}
					goto IL_01a0;
				case 4:
					goto IL_01b5;
				case 18:
					num5++;
					num = 1970873840;
					continue;
				case 1:
					num3 = cTBJQWNJnVBISfYRgepYNiZKpVs(num4, AxisDirection.Horizontal);
					num = 1970873835;
					continue;
				case 0:
					return 0f;
				case 17:
					goto IL_0243;
				case 2:
				{
					HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat = sourceType;
					if (hardwareElementSourceTypeWithHat != HardwareElementSourceTypeWithHat.Axis)
					{
						goto case 18;
					}
					goto IL_02cb;
				}
				case 16:
					return result;
				case 5:
					goto IL_0306;
				case 3:
					return 0f;
				case 10:
					goto IL_0343;
				default:
					return 0f;
				}
				break;
				IL_0343:
				if (num5 >= customCalculationSourceData.Length)
				{
					if (!customCalculation.Process())
					{
						return 0f;
					}
					if (customCalculation.Result.type != TypeWrapper.DataType.Single)
					{
						num = 1970873846;
						continue;
					}
					return customCalculation.Result;
				}
				goto IL_0306;
				IL_02cb:
				int num6;
				if (BdEWXKXXzeZJqVCqxkREiNpHGeq(customCalculationSourceData[num5], out item))
				{
					num = 1970873833;
					num6 = num;
				}
				else
				{
					num = 1970873832;
					num6 = num;
				}
				continue;
				IL_0243:
				if (P_0.sourceHatRange != AxisRange.Full)
				{
					if (P_0.sourceHatRange == AxisRange.Positive)
					{
						if (num3 < 0f)
						{
							return 0f;
						}
					}
					else if (num3 > 0f)
					{
						return 0f;
					}
				}
				goto IL_0327;
				IL_00a1:
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				num5 = 0;
				num = 1970873840;
				continue;
				IL_0182:
				if (sourceHat >= 4)
				{
					num = 1970873850;
					continue;
				}
				num4 = P_2[sourceHat];
				if (num4 < 0)
				{
					return 0f;
				}
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num = 1970873851;
					continue;
				}
				num3 = cTBJQWNJnVBISfYRgepYNiZKpVs(num4, AxisDirection.Vertical);
				if (P_0.sourceHatRange != AxisRange.Full)
				{
					if (P_0.sourceHatRange == AxisRange.Positive)
					{
						if (num3 < 0f)
						{
							return 0f;
						}
					}
					else if (num3 > 0f)
					{
						num = 1970873849;
						continue;
					}
				}
				goto IL_0327;
				IL_00b8:
				result = -1f;
				num = 1970873834;
				continue;
				IL_0306:
				int num7;
				if (customCalculationSourceData[num5] != null)
				{
					num = 1970873853;
					num7 = num;
				}
				else
				{
					num = 1970873832;
					num7 = num;
				}
				continue;
				IL_0327:
				int num8;
				if (!P_0.invert)
				{
					num = 1970873852;
					num8 = num;
				}
				else
				{
					num = 1970873844;
					num8 = num;
				}
				continue;
				IL_01a0:
				if (sourceButton < 128)
				{
					if (!P_1[sourceButton])
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						result = 1f;
						num = 1970873834;
						continue;
					}
					goto IL_00b8;
				}
				num = 1970873841;
			}
			goto IL_0025;
		}

		private float LaNWitWQqyZMqUSPioBpzBMOpwf(DirectInputAxis P_0)
		{
			float result = default(float);
			while (true)
			{
				int num = 758195103;
				while (true)
				{
					switch (num ^ 0x2D312381)
					{
					case 18:
						break;
					case 40:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.RGmIEoeddqcJOYupmkQmBYgIbvb;
						goto case 10;
					case 32:
						goto IL_00df;
					case 38:
						goto IL_00ff;
					case 13:
						goto IL_011f;
					case 14:
						goto IL_0141;
					case 41:
						goto IL_0161;
					case 9:
						goto IL_0181;
					case 11:
						goto IL_01a3;
					case 30:
						switch (P_0)
						{
						case DirectInputAxis.AngularVelocityY:
							break;
						case DirectInputAxis.RotationZ:
							goto IL_00df;
						case DirectInputAxis.VelocityX:
							goto IL_00ff;
						case DirectInputAxis.VelocitySlider0:
							goto IL_011f;
						case DirectInputAxis.VelocityZ:
							goto IL_0141;
						case DirectInputAxis.AngularVelocityX:
							goto IL_0161;
						case DirectInputAxis.ForceSlider0:
							goto IL_0181;
						case DirectInputAxis.RotationX:
							goto IL_01a3;
						default:
							goto IL_024b;
						case DirectInputAxis.AccelerationSlider0:
							goto IL_0255;
						case DirectInputAxis.TorqueX:
							goto IL_0272;
						case DirectInputAxis.ForceX:
							goto IL_02b0;
						case DirectInputAxis.AngularAccelerationZ:
							goto IL_02d0;
						case DirectInputAxis.VelocitySlider1:
							goto IL_02f0;
						case DirectInputAxis.Y:
							goto IL_0312;
						case DirectInputAxis.AccelerationY:
							goto IL_0332;
						case DirectInputAxis.AngularAccelerationX:
							goto IL_0352;
						case DirectInputAxis.ForceSlider1:
							goto IL_0372;
						case DirectInputAxis.X:
							goto IL_0394;
						case DirectInputAxis.TorqueZ:
							goto IL_03af;
						case DirectInputAxis.AccelerationSlider1:
							goto IL_03cf;
						case DirectInputAxis.RotationY:
							goto IL_03ec;
						case DirectInputAxis.Slider0:
							goto IL_040c;
						case DirectInputAxis.Slider1:
							goto IL_042e;
						case DirectInputAxis.AccelerationZ:
							goto IL_045a;
						case DirectInputAxis.AccelerationX:
							goto IL_047a;
						case DirectInputAxis.ForceY:
							goto IL_04a4;
						case DirectInputAxis.ForceZ:
							goto IL_04c4;
						case DirectInputAxis.AngularVelocityZ:
							goto IL_04e4;
						case DirectInputAxis.VelocityY:
							goto IL_0504;
						case DirectInputAxis.AngularAccelerationY:
							goto IL_051f;
						case DirectInputAxis.Z:
							goto IL_053c;
						case DirectInputAxis.TorqueY:
							goto IL_0559;
						}
						goto case 40;
					case 22:
						goto IL_0255;
					case 3:
						goto IL_0272;
					case 15:
						goto IL_02b0;
					case 19:
						goto IL_02d0;
					case 21:
						goto IL_02f0;
					case 25:
						goto IL_0312;
					case 35:
						goto IL_0332;
					case 31:
						goto IL_0352;
					case 2:
						goto IL_0372;
					case 28:
						goto IL_0394;
					case 7:
						goto IL_03af;
					case 24:
						goto IL_03cf;
					case 5:
						goto IL_03ec;
					case 8:
						goto IL_040c;
					case 39:
						goto IL_042e;
					case 17:
						goto IL_045a;
					case 29:
						goto IL_047a;
					case 4:
						goto IL_04a4;
					case 12:
						goto IL_04c4;
					case 20:
						goto IL_04e4;
					case 0:
						goto IL_0504;
					case 16:
						goto IL_051f;
					case 23:
						goto IL_053c;
					case 1:
						goto IL_0559;
					default:
						return 0f;
					case 10:
					case 26:
					case 27:
					case 33:
					case 34:
					case 36:
					case 37:
						{
							return result;
						}
						IL_0559:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.SPJCQoPQMungMHlusshQGGsESRb;
						num = 758195109;
						continue;
						IL_053c:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.EexeVaafwjvMkVEaSmPrguqfFdfH;
						goto case 10;
						IL_051f:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.pvnWuPolUKGTUWwbSvHUegTgAwu;
						goto case 10;
						IL_0504:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.yXFpZYtYDtENypoFuobaryWMzuQ;
						num = 758195104;
						continue;
						IL_04e4:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.oOArRdHfyxSXGCmDGlEiIELLzew;
						goto case 10;
						IL_04c4:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.HDKJwvwsNtYqqCnYgQObrRdIovA;
						goto case 10;
						IL_04a4:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.IhaPZwYsAChGyWBlwnhIiNWdRxR;
						goto case 10;
						IL_047a:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.DOBvaYfnGinqNpiGWgqPBjXgDRzC;
						num = 758195107;
						continue;
						IL_045a:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.OOAcoScQekELVYzQiMSMJABbmqtD;
						goto case 10;
						IL_042e:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.zSsFhuBflWqbpAacvobUXhGulKy[1];
						num = 758195083;
						continue;
						IL_040c:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.zSsFhuBflWqbpAacvobUXhGulKy[0];
						goto case 10;
						IL_03ec:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.KIbnGxOXnQmMCGBZGFHKAZcXIWU;
						goto case 10;
						IL_03cf:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.YrDhHaiaCWlwxeKeaNUlXCFewNRW[1];
						num = 758195108;
						continue;
						IL_03af:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.nzDGrfJlVclebxymwNBHdEsPobia;
						goto case 10;
						IL_0394:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.wrxROzSuvTCIlUkzpetQcPCiLlim;
						num = 758195099;
						continue;
						IL_0372:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.QGQsIeeCGwpqSYdcLafOoaeuqf[1];
						goto case 10;
						IL_0352:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.PsEEjsRJnDISmfRcnLKVKBCBfPv;
						goto case 10;
						IL_0332:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.zbWutNzARjHMIOWUrJwPZMGZeEm;
						goto case 10;
						IL_0312:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.OmnFwaftRtPzAJrBzVkXEvVueKV;
						goto case 10;
						IL_02f0:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.WauhTAHIOnhfanxlDBcvXcGeTEMe[1];
						goto case 10;
						IL_02d0:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.AtiSUBOFeKycaMORXcvLCCFgWXVn;
						goto case 10;
						IL_02b0:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.YxJDFsZphNKedHWTuiVlXiiiwjU;
						goto case 10;
						IL_0272:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.QuetVGdmHvTkuMIPtLdAVVmTect;
						goto case 10;
						IL_0255:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.YrDhHaiaCWlwxeKeaNUlXCFewNRW[0];
						num = 758195098;
						continue;
						IL_024b:
						num = 758195079;
						continue;
						IL_01a3:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.HEsyMyrnRDxGjHUzXrSUtNNgndr;
						goto case 10;
						IL_0181:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.QGQsIeeCGwpqSYdcLafOoaeuqf[0];
						goto case 10;
						IL_0161:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.ndKRRMCnFMAxgtQZIwRqlRxHDpA;
						goto case 10;
						IL_0141:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.PxMaVxatQrDiFbNPhhloLcprfddK;
						goto case 10;
						IL_011f:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.WauhTAHIOnhfanxlDBcvXcGeTEMe[0];
						goto case 10;
						IL_00ff:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.jonEaUzKGoYTXIplUHaaEqfaphgn;
						goto case 10;
						IL_00df:
						result = bBSBxriglpnOAawkfBpKCJgyYmdh.joystickState.BdwUFeNoYDRXkADuwfYbMkBicTp;
						goto case 10;
					}
					break;
				}
			}
		}

		private bool fjKDuIFmYPFHshMFIEKwpUOEovgL(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				goto IL_000b;
			}
			int num2;
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0)
				{
					goto IL_03f6;
				}
				if (P_0.sourceAxis <= 32)
				{
					float num = LaNWitWQqyZMqUSPioBpzBMOpwf((DirectInputAxis)P_0.sourceAxis);
					if (MathTools.Abs(num) <= P_0.axisDeadZone)
					{
						return false;
					}
					if (P_0.sourceAxisPole == Pole.Positive)
					{
						if (num < 0f)
						{
							return false;
						}
					}
					else if (num > 0f)
					{
						return false;
					}
					return true;
				}
				num2 = -416025248;
			}
			else if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
				{
					goto IL_04ba;
				}
				num2 = -416025240;
			}
			else
			{
				num2 = -416025228;
			}
			goto IL_0010;
			IL_000b:
			num2 = -416025218;
			goto IL_0010;
			IL_0490:
			CustomCalculation customCalculation = default(CustomCalculation);
			if (customCalculation.Result.type != TypeWrapper.DataType.Single)
			{
				return false;
			}
			return (float)customCalculation.Result != 0f;
			IL_04ba:
			return false;
			IL_021f:
			int sourceHat = default(int);
			return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 0, P_0.sourceHatType);
			IL_0322:
			HatDirection sourceHatDirection = default(HatDirection);
			switch (sourceHatDirection)
			{
			case HatDirection.Up:
				break;
			case HatDirection.UpRight:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 1, P_0.sourceHatType);
			case HatDirection.Right:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 2, P_0.sourceHatType);
			case HatDirection.DownRight:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 3, P_0.sourceHatType);
			case HatDirection.Down:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 4, P_0.sourceHatType);
			case HatDirection.DownLeft:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 5, P_0.sourceHatType);
			case HatDirection.Left:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 6, P_0.sourceHatType);
			case HatDirection.UpLeft:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 7, P_0.sourceHatType);
			default:
				goto IL_04ba;
			}
			goto IL_021f;
			IL_00f9:
			bool flag = default(bool);
			if (flag)
			{
				return true;
			}
			return false;
			IL_0010:
			HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
			int num3 = default(int);
			int num6 = default(int);
			HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[]);
			bool flag3 = default(bool);
			int num5 = default(int);
			bool flag2 = default(bool);
			while (true)
			{
				float num4;
				switch (num2 ^ -416025219)
				{
				case 12:
					break;
				case 19:
					goto IL_0098;
				case 0:
					num2 = -416025236;
					continue;
				case 18:
					return false;
				case 16:
					goto IL_00eb;
				case 7:
					goto IL_0129;
				case 24:
					goto IL_0147;
				case 2:
					goto IL_016b;
				case 8:
					switch (sourceType)
					{
					case HardwareElementSourceTypeWithHat.Button:
						break;
					default:
						goto IL_0190;
					case HardwareElementSourceTypeWithHat.Axis:
						goto IL_01b9;
					}
					goto IL_0147;
				case 26:
					goto IL_019a;
				case 5:
					goto IL_01b9;
				case 25:
					num3++;
					num2 = -416025236;
					continue;
				case 9:
					goto IL_01fe;
				case 15:
					goto IL_021f;
				case 21:
					goto IL_02c6;
				case 20:
					num2 = -416025235;
					continue;
				case 22:
					num2 = -416025241;
					continue;
				case 27:
					num6 = 0;
					num2 = -416025239;
					continue;
				case 10:
					goto IL_0322;
				case 17:
					if (num3 >= customCalculationSourceData.Length)
					{
						flag3 = customCalculation.Process();
						num2 = -416025238;
						continue;
					}
					goto case 11;
				case 1:
					goto IL_0376;
				case 23:
					goto IL_038d;
				case 3:
					if (P_0.ignoreIfButtonsActive)
					{
						num5 = 0;
						num2 = -416025237;
						continue;
					}
					goto IL_0376;
				case 28:
					goto IL_03b2;
				case 14:
					goto IL_03d0;
				case 6:
					num2 = -416025244;
					continue;
				case 29:
					goto IL_03f6;
				case 4:
					customCalculation.AddData(flag2 ? 1f : 0f);
					num2 = -416025244;
					continue;
				case 11:
					if (customCalculationSourceData[num3] != null)
					{
						sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[num3].sourceType;
						num2 = -416025227;
						continue;
					}
					goto case 25;
				default:
					{
						return false;
					}
					IL_01b9:
					if (BdEWXKXXzeZJqVCqxkREiNpHGeq(customCalculationSourceData[num3], out num4))
					{
						customCalculation.AddData((num4 != 0f) ? 1f : 0f);
						num2 = -416025244;
						continue;
					}
					goto case 25;
					IL_0190:
					num2 = -416025221;
					continue;
				}
				break;
				IL_03d0:
				if (P_1[P_0.ignoreIfButtonsActiveButtons[num5]])
				{
					return false;
				}
				num5++;
				num2 = -416025241;
				continue;
				IL_02c6:
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
				num2 = -416025219;
				continue;
				IL_0147:
				int num7;
				if (!eKDLpJuQWMVUcppIKLCJIoZTxZP(customCalculationSourceData[num3], P_1, out flag2))
				{
					num2 = -416025244;
					num7 = num2;
				}
				else
				{
					num2 = -416025223;
					num7 = num2;
				}
				continue;
				IL_038d:
				if (!flag3)
				{
					num2 = -416025232;
					continue;
				}
				goto IL_0490;
				IL_019a:
				int num8;
				if (num5 < P_0.ignoreIfButtonsActiveButtons.Length)
				{
					num2 = -416025229;
					num8 = num2;
				}
				else
				{
					num2 = -416025220;
					num8 = num2;
				}
				continue;
				IL_0376:
				if (!P_0.requireMultipleButtons)
				{
					int sourceButton = P_0.sourceButton;
					if (sourceButton >= 0 && sourceButton < lenAIRsoOFqjBdbpibHDlBXGVmR)
					{
						if (sourceButton < 128)
						{
							return P_1[sourceButton];
						}
						num2 = -416025234;
						continue;
					}
					goto IL_0098;
				}
				flag = false;
				num2 = -416025242;
				continue;
				IL_0098:
				return false;
				IL_00eb:
				if (num6 >= P_0.requiredButtons.Length)
				{
					goto IL_00f9;
				}
				goto IL_03b2;
				IL_016b:
				if (sourceHat < 4)
				{
					sourceHatDirection = P_0.sourceHatDirection;
					num2 = -416025225;
				}
				else
				{
					num2 = -416025233;
				}
				continue;
				IL_0129:
				int num9;
				if (sourceHat >= QQactFjAyaivYJCKROwerenGIZRE)
				{
					num2 = -416025233;
					num9 = num2;
				}
				else
				{
					num2 = -416025217;
					num9 = num2;
				}
				continue;
				IL_01fe:
				sourceHat = P_0.sourceHat;
				int num10;
				if (sourceHat >= 0)
				{
					num2 = -416025222;
					num10 = num2;
				}
				else
				{
					num2 = -416025233;
					num10 = num2;
				}
				continue;
				IL_03b2:
				if (!P_1[P_0.requiredButtons[num6]])
				{
					return false;
				}
				flag = true;
				num6++;
				num2 = -416025235;
			}
			goto IL_000b;
			IL_03f6:
			return false;
		}

		private bool rtBKMWyfBZOyTgZEbLolEBtLHfb(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (UDBtEeitridwJAiaUtqcfFDaFaI.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return false;
			}
			int num = 4500;
			int num2 = num * P_1;
			int num5 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num3 = -1618304977;
				while (true)
				{
					switch (num3 ^ -1618304981)
					{
					case 2:
						break;
					case 4:
						if (P_2 == HatType.EightWay && P_0 != num2)
						{
							num3 = -1618304984;
							continue;
						}
						if (P_2 == HatType.EightWay)
						{
							num5 = 31500;
							num3 = -1618304981;
							continue;
						}
						goto case 6;
					case 5:
						if (P_1 == 0 && P_0 > num5)
						{
							P_0 -= 36000;
							num3 = -1618304982;
							continue;
						}
						goto default;
					case 0:
						num4 = 4500;
						num3 = -1618304978;
						continue;
					case 6:
						num5 = 27000;
						num4 = 9000;
						num3 = -1618304978;
						continue;
					case 3:
						return false;
					default:
						if (P_0 < num2 + num4 && P_0 > num2 - num4)
						{
							return true;
						}
						return false;
					}
					break;
				}
			}
		}

		private float cTBJQWNJnVBISfYRgepYNiZKpVs(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 <= 27000)
				{
					if (P_0 >= 9000)
					{
						if (P_0 < 27000 && P_0 > 9000)
						{
							return -1f;
						}
						return 0f;
					}
					goto IL_001d;
				}
				goto IL_003f;
			}
			int num;
			if (P_0 > 0)
			{
				num = 2129212478;
				goto IL_0022;
			}
			goto IL_007a;
			IL_007a:
			if (P_0 > 18000)
			{
				num = 2129212476;
				goto IL_0022;
			}
			return 0f;
			IL_003f:
			return 1f;
			IL_0022:
			switch (num ^ 0x7EE9343E)
			{
			case 3:
				break;
			case 1:
				goto IL_003f;
			case 0:
				goto IL_006c;
			default:
				return -1f;
			}
			goto IL_001d;
			IL_006c:
			if (P_0 < 18000)
			{
				return 1f;
			}
			goto IL_007a;
			IL_001d:
			num = 2129212479;
			goto IL_0022;
		}

		private bool eKDLpJuQWMVUcppIKLCJIoZTxZP(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton >= 0)
			{
				while (true)
				{
					int num = 330586511;
					while (true)
					{
						switch (num ^ 0x13B4598E)
						{
						case 2:
							break;
						case 1:
							goto IL_0036;
						default:
							goto end_IL_0018;
						}
						break;
						IL_0036:
						if (sourceButton >= lenAIRsoOFqjBdbpibHDlBXGVmR)
						{
							goto end_IL_0018;
						}
						if (sourceButton >= 128)
						{
							num = 330586510;
							continue;
						}
						P_2 = P_1[sourceButton];
						return true;
					}
					continue;
					end_IL_0018:
					break;
				}
			}
			return false;
		}

		private bool BdEWXKXXzeZJqVCqxkREiNpHGeq(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			while (true)
			{
				int num = 367122917;
				while (true)
				{
					switch (num ^ 0x15E1D9E6)
					{
					case 10:
						break;
					case 6:
					{
						int num2;
						if (P_0.axisCalibrationType != AxisCalibrationType.Custom)
						{
							num = 367122915;
							num2 = num;
						}
						else
						{
							num = 367122918;
							num2 = num;
						}
						continue;
					}
					case 0:
						P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
						num = 367122927;
						continue;
					case 2:
						P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
						num = 367122927;
						continue;
					case 4:
						if (P_1 < 0f)
						{
							P_1 = 0f;
							num = 367122913;
							continue;
						}
						goto case 7;
					case 8:
						return false;
					case 3:
						if (P_0.sourceType != 1)
						{
							return false;
						}
						if (P_0.sourceAxis > 0)
						{
							if (P_0.sourceAxis < 32)
							{
								P_1 = LaNWitWQqyZMqUSPioBpzBMOpwf((DirectInputAxis)P_0.sourceAxis);
								switch (P_0.sourceAxisRange)
								{
								case AxisRange.Positive:
									break;
								default:
									goto IL_0116;
								case AxisRange.Negative:
									goto IL_0148;
								}
								goto case 4;
							}
							num = 367122926;
							continue;
						}
						goto case 8;
					case 1:
						goto IL_0148;
					case 5:
						if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated && P_0.axisDeadZone > 0f && MathTools.Abs(P_1) <= P_0.axisDeadZone)
						{
							P_1 = 0f;
							num = 367122927;
							continue;
						}
						goto default;
					case 7:
					{
						int num3;
						if (P_0.axisCalibrationType != AxisCalibrationType.Default)
						{
							num = 367122912;
							num3 = num;
						}
						else
						{
							num = 367122916;
							num3 = num;
						}
						continue;
					}
					default:
						{
							return true;
						}
						IL_0148:
						if (P_1 > 0f)
						{
							P_1 = 0f;
							num = 367122913;
							continue;
						}
						goto case 7;
						IL_0116:
						num = 367122913;
						continue;
					}
					break;
				}
			}
		}

		private ControlDeviceType misSawbpFBictNnWszzWgeyinIa(oqTDYwuZOTBrxUXrMkuLhLRueIm P_0)
		{
			switch (P_0)
			{
			case oqTDYwuZOTBrxUXrMkuLhLRueIm.otHBHGZfzdEKPVeyweIkhCMmKxf:
				return ControlDeviceType.rCRUfGMYcabNQcwJmpNrFXaJmFK;
			case oqTDYwuZOTBrxUXrMkuLhLRueIm.pQWpfclEjkejclhuRDzKogfWgBcH:
				return ControlDeviceType.etApNsmaydFifFQZNkCXGYFhvYDz;
			case oqTDYwuZOTBrxUXrMkuLhLRueIm.egXeNSeaFVcDEGVdGFwVPDfpVJP:
				return ControlDeviceType.rlDBEAevYUudHNlWSHcStzDSfSse;
			case oqTDYwuZOTBrxUXrMkuLhLRueIm.ViWzCydCNFcFRKBZTpduMcxrfKx:
				return ControlDeviceType.ONOENoDqLOAvQwxgTsKnLgJYNZAF;
			case oqTDYwuZOTBrxUXrMkuLhLRueIm.MhHhUbWXLuJwFAbqgGXhslvNEzA:
				return ControlDeviceType.BmDiDvFwErGbEftNwaKuKgRibod;
			case oqTDYwuZOTBrxUXrMkuLhLRueIm.aoGoUyaiHMwfuxRbqbGkOklUoAm:
				return ControlDeviceType.FjInKYGswFJSXCjagkVXDzAILzP;
			default:
				return ControlDeviceType.mWddvsAGGdWECRlxCOhehpBItyh;
			}
		}

		private void UVFtCXlXPJBKXqaKnfwDHhlUFOJ()
		{
			UDBtEeitridwJAiaUtqcfFDaFaI = qnewRYFCzYevHqfqyatlbQmZFOFg(GcYjAXCLyrkmacLFLclUoLjdDBr());
			while (true)
			{
				int num = -82891154;
				while (true)
				{
					switch (num ^ -82891153)
					{
					case 0:
						break;
					case 1:
						if (UDBtEeitridwJAiaUtqcfFDaFaI == null)
						{
							goto IL_0041;
						}
						goto default;
					case 2:
						return;
					default:
						bxgcDFqOQApgYslsUNoAyTPhJYH = UDBtEeitridwJAiaUtqcfFDaFaI.axisCount;
						opznTvXijlFgLFSdvYEAiweymVQ = UDBtEeitridwJAiaUtqcfFDaFaI.buttonCount;
						return;
					}
					break;
					IL_0041:
					Logger.LogError("Default hardware map not found!");
					num = -82891155;
				}
			}
		}

		private void ziMIstQvDsTiipWkiKzjvoeelUN()
		{
		}

		private string WeIhfcdTiLaXWQGMKArnaqQuiMb()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.DirectInput}{((MVCWNUJrDWfwziBxuAuBAzgJAhiF && !string.IsNullOrEmpty(OWynlsqwgASivUcmwQTMqEbSEpd)) ? OWynlsqwgASivUcmwQTMqEbSEpd : DVaqHcutoHoUrPluDMMcnunKAGA)}{sEJsjYepUiBfnYUEFbfTIGbRtAM}{jswiKSoBCTxrqereFiOojDxDRmw}");
		}

		private void dGqnYVYWgCeqfZEbphqNBhbNleek(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = misSawbpFBictNnWszzWgeyinIa(rrfmJyUDkKMJIxIelilHFVjRKUAM);
			P_0.hardwareIdentifier = WeIhfcdTiLaXWQGMKArnaqQuiMb();
			P_0.hardwareAxisCount = qhBaQiBUaifpRBvldoZTqTDFPFqY;
			P_0.hardwareButtonCount = lenAIRsoOFqjBdbpibHDlBXGVmR;
			P_0.hardwareHatCount = QQactFjAyaivYJCKROwerenGIZRE;
			while (true)
			{
				int num = 871759349;
				while (true)
				{
					switch (num ^ 0x33F5FDF6)
					{
					case 0:
						break;
					case 3:
						P_0.hw_productName = DVaqHcutoHoUrPluDMMcnunKAGA;
						P_0.hw_deviceGuid = instanceGuid;
						P_0.hw_productId = sEJsjYepUiBfnYUEFbfTIGbRtAM;
						P_0.hw_pidVid = new PidVid(jswiKSoBCTxrqereFiOojDxDRmw);
						num = 871759348;
						continue;
					case 2:
						P_0.hw_isBluetoothDevice = MVCWNUJrDWfwziBxuAuBAzgJAhiF;
						num = 871759351;
						continue;
					default:
						P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(OWynlsqwgASivUcmwQTMqEbSEpd)) ? OWynlsqwgASivUcmwQTMqEbSEpd : string.Empty);
						P_0.definitionMatchTag = vhYYOxGmghVJJPAGQjILaUdlbckp;
						return;
					}
					break;
				}
			}
		}

		private void dGqnYVYWgCeqfZEbphqNBhbNleek(BridgedController P_0)
		{
			dGqnYVYWgCeqfZEbphqNBhbNleek((BridgedControllerHWInfo)P_0);
			while (true)
			{
				int num = -2074986610;
				while (true)
				{
					switch (num ^ -2074986612)
					{
					case 4:
						break;
					case 0:
						P_0.isXInputDevice = XWJGdtiTCNTQbkDNDyOHMuyHxoJn;
						num = -2074986611;
						continue;
					case 3:
						P_0.productName = DVaqHcutoHoUrPluDMMcnunKAGA;
						num = -2074986612;
						continue;
					case 1:
						P_0.axisCount = bxgcDFqOQApgYslsUNoAyTPhJYH;
						P_0.buttonCount = opznTvXijlFgLFSdvYEAiweymVQ;
						P_0.unknownControllerHats = OcUHrymqzKTvssBZgPXgfXPVImG();
						P_0.controllerTypeGuid = UfFFvwXyyVSVFqRBlSrwmIuVpoX;
						num = -2074986614;
						continue;
					case 2:
						P_0.sourceJoystick = this;
						P_0.gameHardwareMap = UDBtEeitridwJAiaUtqcfFDaFaI.ToGameHardwareControllerMap();
						num = -2074986615;
						continue;
					case 5:
						P_0.instanceName = vhbvSIyRvLTNKIdHyehnSxBQFBz;
						num = -2074986609;
						continue;
					default:
						P_0.controllerExtension = extension;
						return;
					}
					break;
				}
			}
		}

		private void ZUufxygzLDLqreSdRfjQUkyhpRth()
		{
			int num = 0;
			int num2 = default(int);
			while (true)
			{
				IL_003e:
				int num3;
				if (num >= opznTvXijlFgLFSdvYEAiweymVQ)
				{
					num2 = 0;
					num3 = -494175040;
					goto IL_0009;
				}
				goto IL_002a;
				IL_0009:
				while (true)
				{
					switch (num3 ^ -494175038)
					{
					case 3:
						num3 = -494175037;
						continue;
					case 1:
						break;
					case 4:
						goto IL_003e;
					case 0:
						UeCdPcJARqFdGACIKPtkWZxawHVX[num2] = 0f;
						num2++;
						num3 = -494175040;
						continue;
					default:
						if (num2 >= bxgcDFqOQApgYslsUNoAyTPhJYH)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
				goto IL_002a;
				IL_002a:
				mCgSEFdyltyHHshVpCgaWFFUiOPJ[num] = false;
				num++;
				num3 = -494175034;
				goto IL_0009;
			}
		}

		private UnknownControllerHat[] OcUHrymqzKTvssBZgPXgfXPVImG()
		{
			if (!zzVdHXNFUtEpnTWJnqCoLRkJxcS)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			int[] array2 = default(int[]);
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = 776241227;
				while (true)
				{
					switch (num ^ 0x2E44804E)
					{
					case 8:
						break;
					case 7:
						array2[4] = num3 + 4;
						num = 776241229;
						continue;
					case 2:
						array2[6] = num3 + 6;
						num = 776241230;
						continue;
					case 4:
						num = 776241224;
						continue;
					case 3:
						array2[5] = num3 + 5;
						num = 776241228;
						continue;
					case 0:
					{
						array2[7] = num3 + 7;
						UnknownControllerHat.HatButtons buttons = new UnknownControllerHat.HatButtons(array2);
						array[num2] = new UnknownControllerHat(buttons);
						num2++;
						num = 776241224;
						continue;
					}
					case 1:
						num3 = 128 + num2 * 8;
						array2 = new int[8]
						{
							num3,
							num3 + 1,
							num3 + 2,
							num3 + 3,
							0,
							0,
							0,
							0
						};
						num = 776241225;
						continue;
					case 5:
						num2 = 0;
						num = 776241226;
						continue;
					default:
						if (num2 >= 2)
						{
							return array;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public void WYoEhOBxiSjIYKwbsCHdGOUBXDbi()
		{
			WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
			GC.SuppressFinalize(this);
		}

		~MUlnPVcZgGLeXkhLihgLQlrmnHb()
		{
			WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
		}

		protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
		{
			if (inweGjIgYacXYohFlYRlpMFkgKMi)
			{
				return;
			}
			while (P_0 && bBSBxriglpnOAawkfBpKCJgyYmdh != null)
			{
				bBSBxriglpnOAawkfBpKCJgyYmdh.Dispose();
				int num = -902298499;
				while (true)
				{
					switch (num ^ -902298499)
					{
					case 2:
						num = -902298500;
						continue;
					case 1:
						break;
					default:
						goto end_IL_0027;
					}
					break;
				}
				continue;
				end_IL_0027:
				break;
			}
			inweGjIgYacXYohFlYRlpMFkgKMi = true;
		}

		public static int hAhbefRdJZmHXDjWxMDZzJoyxdd(MUlnPVcZgGLeXkhLihgLQlrmnHb P_0, MUlnPVcZgGLeXkhLihgLQlrmnHb P_1)
		{
			if (P_0.JuzBXDTMFrDVUhqtKRLmdorveybr < P_1.JuzBXDTMFrDVUhqtKRLmdorveybr)
			{
				goto IL_000e;
			}
			int num;
			if (P_0.JuzBXDTMFrDVUhqtKRLmdorveybr > P_1.JuzBXDTMFrDVUhqtKRLmdorveybr)
			{
				num = 1528292252;
				goto IL_0013;
			}
			return 0;
			IL_000e:
			num = 1528292255;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x5B17E39D)
			{
			case 0:
				break;
			case 2:
				return -1;
			default:
				return 1;
			}
			goto IL_000e;
		}

		public static int WqhqgptTseHqhChjsCbwEEjWkdx(MUlnPVcZgGLeXkhLihgLQlrmnHb P_0, MUlnPVcZgGLeXkhLihgLQlrmnHb P_1)
		{
			if (P_0.zuIOHHSFjUvtYoHqYbOkIVnjKLJ < P_1.zuIOHHSFjUvtYoHqYbOkIVnjKLJ)
			{
				return -1;
			}
			if (P_0.zuIOHHSFjUvtYoHqYbOkIVnjKLJ > P_1.zuIOHHSFjUvtYoHqYbOkIVnjKLJ)
			{
				return 1;
			}
			return 0;
		}
	}

	private class IPQPLNMoyLRdmrBDMONOOacSFFX : IDisposable
	{
		public class nAERUaBFQqjlLwmXYXAQmrdRYth
		{
			public float wrxROzSuvTCIlUkzpetQcPCiLlim;

			public float OmnFwaftRtPzAJrBzVkXEvVueKV;

			public float EexeVaafwjvMkVEaSmPrguqfFdfH;

			public float HEsyMyrnRDxGjHUzXrSUtNNgndr;

			public float KIbnGxOXnQmMCGBZGFHKAZcXIWU;

			public float BdwUFeNoYDRXkADuwfYbMkBicTp;

			public float[] zSsFhuBflWqbpAacvobUXhGulKy;

			public readonly int[] xqptHUWwYgqMYJETCHvCcscGRUQ;

			public readonly bool[] BbQZXfVAmQcAGiAipTBZtTMzfgS;

			public float jonEaUzKGoYTXIplUHaaEqfaphgn;

			public float yXFpZYtYDtENypoFuobaryWMzuQ;

			public float PxMaVxatQrDiFbNPhhloLcprfddK;

			public float ndKRRMCnFMAxgtQZIwRqlRxHDpA;

			public float RGmIEoeddqcJOYupmkQmBYgIbvb;

			public float oOArRdHfyxSXGCmDGlEiIELLzew;

			public readonly float[] WauhTAHIOnhfanxlDBcvXcGeTEMe;

			public float DOBvaYfnGinqNpiGWgqPBjXgDRzC;

			public float zbWutNzARjHMIOWUrJwPZMGZeEm;

			public float OOAcoScQekELVYzQiMSMJABbmqtD;

			public float PsEEjsRJnDISmfRcnLKVKBCBfPv;

			public float pvnWuPolUKGTUWwbSvHUegTgAwu;

			public float AtiSUBOFeKycaMORXcvLCCFgWXVn;

			public readonly float[] YrDhHaiaCWlwxeKeaNUlXCFewNRW;

			public float YxJDFsZphNKedHWTuiVlXiiiwjU;

			public float IhaPZwYsAChGyWBlwnhIiNWdRxR;

			public float HDKJwvwsNtYqqCnYgQObrRdIovA;

			public float QuetVGdmHvTkuMIPtLdAVVmTect;

			public float SPJCQoPQMungMHlusshQGGsESRb;

			public float nzDGrfJlVclebxymwNBHdEsPobia;

			public readonly float[] QGQsIeeCGwpqSYdcLafOoaeuqf;

			public nAERUaBFQqjlLwmXYXAQmrdRYth()
			{
				while (true)
				{
					int num = 1193975990;
					while (true)
					{
						switch (num ^ 0x472AA0B7)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0024;
						case 2:
							return;
						}
						break;
						IL_0024:
						zSsFhuBflWqbpAacvobUXhGulKy = new float[2];
						xqptHUWwYgqMYJETCHvCcscGRUQ = new int[4];
						BbQZXfVAmQcAGiAipTBZtTMzfgS = new bool[128];
						WauhTAHIOnhfanxlDBcvXcGeTEMe = new float[2];
						YrDhHaiaCWlwxeKeaNUlXCFewNRW = new float[2];
						QGQsIeeCGwpqSYdcLafOoaeuqf = new float[2];
						num = 1193975989;
					}
				}
			}

			public void ibajyEOvcZaAVvqbaVIEPkwcIqx()
			{
				wrxROzSuvTCIlUkzpetQcPCiLlim = 0f;
				OmnFwaftRtPzAJrBzVkXEvVueKV = 0f;
				EexeVaafwjvMkVEaSmPrguqfFdfH = 0f;
				HEsyMyrnRDxGjHUzXrSUtNNgndr = 0f;
				int num5 = default(int);
				int num7 = default(int);
				int num2 = default(int);
				int num6 = default(int);
				int num3 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num = 858111410;
					while (true)
					{
						switch (num ^ 0x3325BDBF)
						{
						case 19:
							break;
						case 2:
						{
							int num8;
							if (num5 >= WauhTAHIOnhfanxlDBcvXcGeTEMe.Length)
							{
								num = 858111408;
								num8 = num;
							}
							else
							{
								num = 858111400;
								num8 = num;
							}
							continue;
						}
						case 5:
							num5 = 0;
							num = 858111421;
							continue;
						case 10:
							num5++;
							num = 858111421;
							continue;
						case 23:
							WauhTAHIOnhfanxlDBcvXcGeTEMe[num5] = 0f;
							num = 858111413;
							continue;
						case 21:
							PsEEjsRJnDISmfRcnLKVKBCBfPv = 0f;
							pvnWuPolUKGTUWwbSvHUegTgAwu = 0f;
							AtiSUBOFeKycaMORXcvLCCFgWXVn = 0f;
							num7 = 0;
							num = 858111415;
							continue;
						case 11:
							QGQsIeeCGwpqSYdcLafOoaeuqf[num2] = 0f;
							num2++;
							num = 858111417;
							continue;
						case 7:
							HDKJwvwsNtYqqCnYgQObrRdIovA = 0f;
							num = 858111401;
							continue;
						case 1:
							num6++;
							num = 858111403;
							continue;
						case 22:
							QuetVGdmHvTkuMIPtLdAVVmTect = 0f;
							num = 858111414;
							continue;
						case 8:
							num = 858111405;
							continue;
						case 14:
							if (num3 >= zSsFhuBflWqbpAacvobUXhGulKy.Length)
							{
								num6 = 0;
								num = 858111406;
								continue;
							}
							goto case 16;
						case 18:
							if (num7 >= YrDhHaiaCWlwxeKeaNUlXCFewNRW.Length)
							{
								YxJDFsZphNKedHWTuiVlXiiiwjU = 0f;
								IhaPZwYsAChGyWBlwnhIiNWdRxR = 0f;
								num = 858111416;
								continue;
							}
							goto case 0;
						case 20:
							if (num6 >= xqptHUWwYgqMYJETCHvCcscGRUQ.Length)
							{
								num4 = 0;
								num = 858111411;
								continue;
							}
							goto case 24;
						case 12:
							if (num4 >= BbQZXfVAmQcAGiAipTBZtTMzfgS.Length)
							{
								jonEaUzKGoYTXIplUHaaEqfaphgn = 0f;
								yXFpZYtYDtENypoFuobaryWMzuQ = 0f;
								PxMaVxatQrDiFbNPhhloLcprfddK = 0f;
								ndKRRMCnFMAxgtQZIwRqlRxHDpA = 0f;
								RGmIEoeddqcJOYupmkQmBYgIbvb = 0f;
								oOArRdHfyxSXGCmDGlEiIELLzew = 0f;
								num = 858111418;
								continue;
							}
							goto case 3;
						case 3:
							BbQZXfVAmQcAGiAipTBZtTMzfgS[num4] = false;
							num4++;
							num = 858111411;
							continue;
						case 16:
							zSsFhuBflWqbpAacvobUXhGulKy[num3] = 0f;
							num3++;
							num = 858111409;
							continue;
						case 0:
							YrDhHaiaCWlwxeKeaNUlXCFewNRW[num7] = 0f;
							num7++;
							num = 858111405;
							continue;
						case 24:
							xqptHUWwYgqMYJETCHvCcscGRUQ[num6] = 0;
							num = 858111422;
							continue;
						case 9:
							SPJCQoPQMungMHlusshQGGsESRb = 0f;
							nzDGrfJlVclebxymwNBHdEsPobia = 0f;
							num2 = 0;
							num = 858111417;
							continue;
						case 13:
							KIbnGxOXnQmMCGBZGFHKAZcXIWU = 0f;
							BdwUFeNoYDRXkADuwfYbMkBicTp = 0f;
							num = 858111419;
							continue;
						case 17:
							num = 858111403;
							continue;
						case 4:
							num3 = 0;
							num = 858111409;
							continue;
						case 15:
							DOBvaYfnGinqNpiGWgqPBjXgDRzC = 0f;
							zbWutNzARjHMIOWUrJwPZMGZeEm = 0f;
							OOAcoScQekELVYzQiMSMJABbmqtD = 0f;
							num = 858111402;
							continue;
						default:
							if (num2 >= QGQsIeeCGwpqSYdcLafOoaeuqf.Length)
							{
								return;
							}
							goto case 11;
						}
						break;
					}
				}
			}

			public void WilpheradKREcjoLhhcMLOKbDOaC(nAERUaBFQqjlLwmXYXAQmrdRYth P_0)
			{
				wrxROzSuvTCIlUkzpetQcPCiLlim = P_0.wrxROzSuvTCIlUkzpetQcPCiLlim;
				OmnFwaftRtPzAJrBzVkXEvVueKV = P_0.OmnFwaftRtPzAJrBzVkXEvVueKV;
				EexeVaafwjvMkVEaSmPrguqfFdfH = P_0.EexeVaafwjvMkVEaSmPrguqfFdfH;
				HEsyMyrnRDxGjHUzXrSUtNNgndr = P_0.HEsyMyrnRDxGjHUzXrSUtNNgndr;
				int num6 = default(int);
				int num4 = default(int);
				int num2 = default(int);
				int num3 = default(int);
				int num7 = default(int);
				int num5 = default(int);
				while (true)
				{
					int num = -794026177;
					while (true)
					{
						switch (num ^ -794026198)
						{
						case 14:
							break;
						case 4:
							if (num6 >= xqptHUWwYgqMYJETCHvCcscGRUQ.Length)
							{
								num4 = 0;
								num = -794026184;
								continue;
							}
							goto case 1;
						case 2:
							SPJCQoPQMungMHlusshQGGsESRb = P_0.SPJCQoPQMungMHlusshQGGsESRb;
							nzDGrfJlVclebxymwNBHdEsPobia = P_0.nzDGrfJlVclebxymwNBHdEsPobia;
							num2 = 0;
							num = -794026207;
							continue;
						case 1:
							xqptHUWwYgqMYJETCHvCcscGRUQ[num6] = P_0.xqptHUWwYgqMYJETCHvCcscGRUQ[num6];
							num = -794026195;
							continue;
						case 16:
							BbQZXfVAmQcAGiAipTBZtTMzfgS[num4] = P_0.BbQZXfVAmQcAGiAipTBZtTMzfgS[num4];
							num = -794026198;
							continue;
						case 7:
							num6++;
							num = -794026194;
							continue;
						case 18:
							if (num4 >= BbQZXfVAmQcAGiAipTBZtTMzfgS.Length)
							{
								jonEaUzKGoYTXIplUHaaEqfaphgn = P_0.jonEaUzKGoYTXIplUHaaEqfaphgn;
								yXFpZYtYDtENypoFuobaryWMzuQ = P_0.yXFpZYtYDtENypoFuobaryWMzuQ;
								PxMaVxatQrDiFbNPhhloLcprfddK = P_0.PxMaVxatQrDiFbNPhhloLcprfddK;
								ndKRRMCnFMAxgtQZIwRqlRxHDpA = P_0.ndKRRMCnFMAxgtQZIwRqlRxHDpA;
								RGmIEoeddqcJOYupmkQmBYgIbvb = P_0.RGmIEoeddqcJOYupmkQmBYgIbvb;
								oOArRdHfyxSXGCmDGlEiIELLzew = P_0.oOArRdHfyxSXGCmDGlEiIELLzew;
								num3 = 0;
								num = -794026206;
								continue;
							}
							goto case 16;
						case 8:
							num = -794026181;
							continue;
						case 10:
							AtiSUBOFeKycaMORXcvLCCFgWXVn = P_0.AtiSUBOFeKycaMORXcvLCCFgWXVn;
							num7 = 0;
							num = -794026201;
							continue;
						case 21:
							KIbnGxOXnQmMCGBZGFHKAZcXIWU = P_0.KIbnGxOXnQmMCGBZGFHKAZcXIWU;
							num = -794026196;
							continue;
						case 6:
							BdwUFeNoYDRXkADuwfYbMkBicTp = P_0.BdwUFeNoYDRXkADuwfYbMkBicTp;
							num5 = 0;
							num = -794026205;
							continue;
						case 15:
							QGQsIeeCGwpqSYdcLafOoaeuqf[num2] = P_0.QGQsIeeCGwpqSYdcLafOoaeuqf[num2];
							num2++;
							num = -794026193;
							continue;
						case 13:
							if (num7 >= YrDhHaiaCWlwxeKeaNUlXCFewNRW.Length)
							{
								YxJDFsZphNKedHWTuiVlXiiiwjU = P_0.YxJDFsZphNKedHWTuiVlXiiiwjU;
								IhaPZwYsAChGyWBlwnhIiNWdRxR = P_0.IhaPZwYsAChGyWBlwnhIiNWdRxR;
								HDKJwvwsNtYqqCnYgQObrRdIovA = P_0.HDKJwvwsNtYqqCnYgQObrRdIovA;
								QuetVGdmHvTkuMIPtLdAVVmTect = P_0.QuetVGdmHvTkuMIPtLdAVVmTect;
								num = -794026200;
								continue;
							}
							goto case 12;
						case 0:
							num4++;
							num = -794026184;
							continue;
						case 12:
							YrDhHaiaCWlwxeKeaNUlXCFewNRW[num7] = P_0.YrDhHaiaCWlwxeKeaNUlXCFewNRW[num7];
							num7++;
							num = -794026201;
							continue;
						case 19:
							WauhTAHIOnhfanxlDBcvXcGeTEMe[num3] = P_0.WauhTAHIOnhfanxlDBcvXcGeTEMe[num3];
							num3++;
							num = -794026181;
							continue;
						case 20:
							zSsFhuBflWqbpAacvobUXhGulKy[num5] = P_0.zSsFhuBflWqbpAacvobUXhGulKy[num5];
							num5++;
							num = -794026205;
							continue;
						case 11:
							num = -794026193;
							continue;
						case 9:
							if (num5 >= zSsFhuBflWqbpAacvobUXhGulKy.Length)
							{
								num6 = 0;
								num = -794026194;
								continue;
							}
							goto case 20;
						case 3:
							pvnWuPolUKGTUWwbSvHUegTgAwu = P_0.pvnWuPolUKGTUWwbSvHUegTgAwu;
							num = -794026208;
							continue;
						case 17:
							if (num3 >= WauhTAHIOnhfanxlDBcvXcGeTEMe.Length)
							{
								DOBvaYfnGinqNpiGWgqPBjXgDRzC = P_0.DOBvaYfnGinqNpiGWgqPBjXgDRzC;
								zbWutNzARjHMIOWUrJwPZMGZeEm = P_0.zbWutNzARjHMIOWUrJwPZMGZeEm;
								OOAcoScQekELVYzQiMSMJABbmqtD = P_0.OOAcoScQekELVYzQiMSMJABbmqtD;
								PsEEjsRJnDISmfRcnLKVKBCBfPv = P_0.PsEEjsRJnDISmfRcnLKVKBCBfPv;
								num = -794026199;
								continue;
							}
							goto case 19;
						default:
							if (num2 >= QGQsIeeCGwpqSYdcLafOoaeuqf.Length)
							{
								return;
							}
							goto case 15;
						}
						break;
					}
				}
			}

			public unsafe void WilpheradKREcjoLhhcMLOKbDOaC(ref LowLevelInputEvent P_0)
			{
				int num = 0;
				int num2 = default(int);
				int num4 = default(int);
				int* ptr2 = default(int*);
				int num7 = default(int);
				int num6 = default(int);
				int num9 = default(int);
				int num8 = default(int);
				int num5 = default(int);
				float* ptr = default(float*);
				while (true)
				{
					IL_0361:
					int num3;
					if (num >= 4)
					{
						ptr = (float*)((byte*)(void*)P_0._buffer + P_0.byteIndex_axesStart);
						num2 = 0;
						num3 = 2134406846;
						goto IL_000c;
					}
					goto IL_0239;
					IL_000c:
					while (true)
					{
						switch (num3 ^ 0x7F3876AF)
						{
						case 12:
							num3 = 2134406824;
							continue;
						case 19:
							xqptHUWwYgqMYJETCHvCcscGRUQ[num4] = *ptr2;
							ptr2++;
							num4++;
							num3 = 2134406839;
							continue;
						case 22:
							num7++;
							num3 = 2134406823;
							continue;
						case 8:
							if (num7 >= 2)
							{
								jonEaUzKGoYTXIplUHaaEqfaphgn = *ptr;
								ptr++;
								yXFpZYtYDtENypoFuobaryWMzuQ = *ptr;
								ptr++;
								PxMaVxatQrDiFbNPhhloLcprfddK = *ptr;
								ptr++;
								wrxROzSuvTCIlUkzpetQcPCiLlim = *ptr;
								ptr++;
								OmnFwaftRtPzAJrBzVkXEvVueKV = *ptr;
								num3 = 2134406837;
								continue;
							}
							goto case 11;
						case 5:
							BbQZXfVAmQcAGiAipTBZtTMzfgS[num * 32 + num6] = (num9 & (1 << num6)) != 0;
							num6++;
							num3 = 2134406840;
							continue;
						case 6:
							KIbnGxOXnQmMCGBZGFHKAZcXIWU = *ptr;
							ptr++;
							num3 = 2134406830;
							continue;
						case 11:
							WauhTAHIOnhfanxlDBcvXcGeTEMe[num7] = *ptr;
							num3 = 2134406843;
							continue;
						case 3:
							RGmIEoeddqcJOYupmkQmBYgIbvb = *ptr;
							ptr++;
							oOArRdHfyxSXGCmDGlEiIELLzew = *ptr;
							ptr++;
							num8 = 0;
							num3 = 2134406838;
							continue;
						case 0:
							HDKJwvwsNtYqqCnYgQObrRdIovA = *ptr;
							ptr++;
							HEsyMyrnRDxGjHUzXrSUtNNgndr = *ptr;
							ptr++;
							num3 = 2134406825;
							continue;
						case 2:
							QGQsIeeCGwpqSYdcLafOoaeuqf[num8] = *ptr;
							ptr++;
							num8++;
							num3 = 2134406838;
							continue;
						case 9:
							num5++;
							num3 = 2134406836;
							continue;
						case 26:
							ptr++;
							EexeVaafwjvMkVEaSmPrguqfFdfH = *ptr;
							ptr++;
							ptr2 = (int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_hatsStart);
							num4 = 0;
							num3 = 2134406839;
							continue;
						case 25:
							if (num8 >= 2)
							{
								YxJDFsZphNKedHWTuiVlXiiiwjU = *ptr;
								ptr++;
								IhaPZwYsAChGyWBlwnhIiNWdRxR = *ptr;
								ptr++;
								num3 = 2134406831;
								continue;
							}
							goto case 2;
						case 7:
							break;
						case 20:
							ptr++;
							num3 = 2134406841;
							continue;
						case 14:
							num3 = 2134406836;
							continue;
						case 18:
							ptr++;
							num7 = 0;
							num3 = 2134406823;
							continue;
						case 1:
							BdwUFeNoYDRXkADuwfYbMkBicTp = *ptr;
							ptr++;
							num5 = 0;
							num3 = 2134406817;
							continue;
						case 17:
							if (num2 >= 2)
							{
								DOBvaYfnGinqNpiGWgqPBjXgDRzC = *ptr;
								ptr++;
								num3 = 2134406827;
								continue;
							}
							goto case 21;
						case 13:
							ptr++;
							num3 = 2134406828;
							continue;
						case 10:
							ptr++;
							PsEEjsRJnDISmfRcnLKVKBCBfPv = *ptr;
							ptr++;
							pvnWuPolUKGTUWwbSvHUegTgAwu = *ptr;
							ptr++;
							AtiSUBOFeKycaMORXcvLCCFgWXVn = *ptr;
							ptr++;
							ndKRRMCnFMAxgtQZIwRqlRxHDpA = *ptr;
							num3 = 2134406818;
							continue;
						case 21:
							YrDhHaiaCWlwxeKeaNUlXCFewNRW[num2] = *ptr;
							ptr++;
							num2++;
							num3 = 2134406846;
							continue;
						case 23:
							if (num6 >= 32)
							{
								num++;
								num3 = 2134406847;
								continue;
							}
							goto case 5;
						case 4:
							zbWutNzARjHMIOWUrJwPZMGZeEm = *ptr;
							ptr++;
							OOAcoScQekELVYzQiMSMJABbmqtD = *ptr;
							num3 = 2134406821;
							continue;
						case 16:
							goto IL_0361;
						case 15:
							zSsFhuBflWqbpAacvobUXhGulKy[num5] = *ptr;
							ptr++;
							num3 = 2134406822;
							continue;
						case 27:
							if (num5 >= 2)
							{
								QuetVGdmHvTkuMIPtLdAVVmTect = *ptr;
								ptr++;
								SPJCQoPQMungMHlusshQGGsESRb = *ptr;
								ptr++;
								nzDGrfJlVclebxymwNBHdEsPobia = *ptr;
								num3 = 2134406845;
								continue;
							}
							goto case 15;
						default:
							if (num4 >= 2)
							{
								return;
							}
							goto case 19;
						}
						break;
					}
					goto IL_0239;
					IL_0239:
					num9 = ((int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_buttonsStart))[num];
					num6 = 0;
					num3 = 2134406840;
					goto IL_000c;
				}
			}

			public unsafe static void pRjYNlQQpYlPrhDAWsvlgmgLMvl(SkGbNCWHoQzwqvkkxZjAhCbrAHF P_0, double P_1, LowLevelInputEvent P_2)
			{
				int[] pointOfViewControllers = P_0.PointOfViewControllers;
				int[] accelerationSliders = P_0.AccelerationSliders;
				int[] forceSliders = P_0.ForceSliders;
				int[] sliders = P_0.Sliders;
				int[] velocitySliders = P_0.VelocitySliders;
				*(double*)((byte*)(void*)P_2._buffer + 4) = P_1;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 128; i++)
				{
					if (P_0.Buttons[i])
					{
						num |= 1 << num3;
					}
					num3++;
					if (num3 == 32)
					{
						((int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_buttonsStart))[num2] = num;
						num3 = 0;
						num = 0;
						num2++;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_2._buffer + P_2.byteIndex_axesStart);
				for (int j = 0; j < 2; j++)
				{
					*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(accelerationSliders[j]);
					ptr++;
				}
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.AccelerationX);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.AccelerationY);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.AccelerationZ);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.AngularAccelerationX);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.AngularAccelerationY);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.AngularAccelerationZ);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.AngularVelocityX);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.AngularVelocityY);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.AngularVelocityZ);
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(forceSliders[k]);
					ptr++;
				}
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.ForceX);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.ForceY);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.ForceZ);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.RotationX);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.RotationY);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.RotationZ);
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(sliders[l]);
					ptr++;
				}
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.TorqueX);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.TorqueY);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.TorqueZ);
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(velocitySliders[m]);
					ptr++;
				}
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.VelocityX);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.VelocityY);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.VelocityZ);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.X);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.Y);
				ptr++;
				*ptr = oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.Z);
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = pointOfViewControllers[n];
					ptr2++;
				}
			}
		}

		private const int XiJKDDGXWAqNcXcduiBTPlznill = 2;

		private const int dqjgIADaIaQTYTZxlScWlMElPpB = 2;

		private const int SJhPFaFDaGWrtsKNGtZeILkIrnZ = 128;

		private const int tlnOrIxBZqBjHHsNbHkpCMjgoRni = 32;

		private const int HliUXrvGLWarSreutvCfICOytEo = 0;

		private const int xcJqNlcWxdDAEMltXKAwHiIvcpD = 264;

		private const int RNmSAnaqxTeVEKaKvdRzYmrdvDd = 272;

		private readonly int eHZGWCRkabPOlmhdTfYEHDwgrZW;

		private readonly ButtonLoopSet kxhgtldiZvXtvpQoAQRmEtvWcQG;

		private readonly DualThreadLowLevelInputEventQueue qBsNOlJaQtsdnZAlQWMSpzDbRSm;

		private sCsiVmqRgHvljAcnIRaumySfCFh uwkxBtpdyXYHUhMTbmiGcoRwVcf;

		private readonly SkGbNCWHoQzwqvkkxZjAhCbrAHF FkOZLdUtQgJRZnYbeAAyngQvSuZ;

		private readonly SkGbNCWHoQzwqvkkxZjAhCbrAHF OzRKYUwWBpaXzOAVNLiKgxPNsms;

		private readonly object qIQlBFFGDiShOcCyrfZvJAVTChJ;

		private bool aMKqqzErhtNXhyxSwjqcdYmpEMF;

		public readonly uRfjJqYedjnyNKOatXmscLaMEod LMofllDVwkfLxnRkZcSVHJPEQcuP;

		private readonly nAERUaBFQqjlLwmXYXAQmrdRYth CMjluvrRaCraCeKHTYWBCAtVwSN;

		private bool inweGjIgYacXYohFlYRlpMFkgKMi;

		public bool[] CurrentButtonValues => kxhgtldiZvXtvpQoAQRmEtvWcQG.Current.effectiveValue;

		public nAERUaBFQqjlLwmXYXAQmrdRYth joystickState => CMjluvrRaCraCeKHTYWBCAtVwSN;

		public IPQPLNMoyLRdmrBDMONOOacSFFX(uRfjJqYedjnyNKOatXmscLaMEod source, UpdateLoopSetting updateLoops)
		{
			LMofllDVwkfLxnRkZcSVHJPEQcuP = source;
			eHZGWCRkabPOlmhdTfYEHDwgrZW = source.Capabilities.iwqiuNdLxBKiEAtVaetmnxLuWYk;
			kxhgtldiZvXtvpQoAQRmEtvWcQG = new ButtonLoopSet(updateLoops, eHZGWCRkabPOlmhdTfYEHDwgrZW);
			qBsNOlJaQtsdnZAlQWMSpzDbRSm = new DualThreadLowLevelInputEventQueue((int)((float)kpfkMpAFolETeEcXIDaJMkIYftRp.joystickRefreshRate * 0.25f), 128, 32, 2);
			CMjluvrRaCraCeKHTYWBCAtVwSN = new nAERUaBFQqjlLwmXYXAQmrdRYth();
			FkOZLdUtQgJRZnYbeAAyngQvSuZ = new SkGbNCWHoQzwqvkkxZjAhCbrAHF();
			OzRKYUwWBpaXzOAVNLiKgxPNsms = new SkGbNCWHoQzwqvkkxZjAhCbrAHF();
			qIQlBFFGDiShOcCyrfZvJAVTChJ = new object();
			if (kpfkMpAFolETeEcXIDaJMkIYftRp.joystickInputThread != null)
			{
				kpfkMpAFolETeEcXIDaJMkIYftRp.joystickInputThread.ThreadUpdateEvent += OCYauBCLbvZTkaILZmGLmnynwEf;
			}
		}

		public void FHAWEJygpGBmQamZGcnJraVJkRh()
		{
			kxhgtldiZvXtvpQoAQRmEtvWcQG.SetUpdateLoop(ReInput.currentUpdateLoop);
			AIJrFJkuFrnshjjAWCkQgZXuBhpa();
		}

		public void fHvlAyzcxwcbEJYkeBnphlWsGSD()
		{
			kxhgtldiZvXtvpQoAQRmEtvWcQG.Current.ClearWasTrueThisFrame();
		}

		public void ZLkRominQCKUBwwrVSwFZLKUpyk()
		{
			RFDPexajhTcXvizzpCmOkHbzMGox();
			aMKqqzErhtNXhyxSwjqcdYmpEMF = true;
		}

		public void qhdlbmvVPGSkmbKUCbanVffQNKm()
		{
			aMKqqzErhtNXhyxSwjqcdYmpEMF = false;
			RFDPexajhTcXvizzpCmOkHbzMGox();
		}

		public void laWNKiWcrSexnZtRRPyPhNqRVNc(IPQPLNMoyLRdmrBDMONOOacSFFX P_0)
		{
			if (P_0 == null)
			{
				while (true)
				{
					switch (0x71156B3C ^ 0x71156B38)
					{
					case 3:
						break;
					case 4:
						return;
					case 1:
						goto end_IL_0003;
					case 0:
						goto IL_003d;
					default:
						goto IL_0053;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			if (P_0 == this)
			{
				return;
			}
			goto IL_003d;
			IL_0053:
			_ = ReInput.realTime;
			lock (qIQlBFFGDiShOcCyrfZvJAVTChJ)
			{
				lock (P_0.qIQlBFFGDiShOcCyrfZvJAVTChJ)
				{
					kxhgtldiZvXtvpQoAQRmEtvWcQG.Import(P_0.kxhgtldiZvXtvpQoAQRmEtvWcQG);
					CMjluvrRaCraCeKHTYWBCAtVwSN.WilpheradKREcjoLhhcMLOKbDOaC(P_0.CMjluvrRaCraCeKHTYWBCAtVwSN);
					FkOZLdUtQgJRZnYbeAAyngQvSuZ.WilpheradKREcjoLhhcMLOKbDOaC(P_0.FkOZLdUtQgJRZnYbeAAyngQvSuZ);
					OzRKYUwWBpaXzOAVNLiKgxPNsms.WilpheradKREcjoLhhcMLOKbDOaC(P_0.OzRKYUwWBpaXzOAVNLiKgxPNsms);
					qBsNOlJaQtsdnZAlQWMSpzDbRSm.ImportAll(P_0.qBsNOlJaQtsdnZAlQWMSpzDbRSm);
					uwkxBtpdyXYHUhMTbmiGcoRwVcf = sCsiVmqRgHvljAcnIRaumySfCFh.MJrUrFkVEmQSXxyzlCNgTEmSvVh(P_0.uwkxBtpdyXYHUhMTbmiGcoRwVcf, FkOZLdUtQgJRZnYbeAAyngQvSuZ);
					aMKqqzErhtNXhyxSwjqcdYmpEMF = P_0.aMKqqzErhtNXhyxSwjqcdYmpEMF;
					return;
				}
			}
			IL_003d:
			if (P_0.eHZGWCRkabPOlmhdTfYEHDwgrZW != eHZGWCRkabPOlmhdTfYEHDwgrZW)
			{
				return;
			}
			goto IL_0053;
		}

		public void UQOCMATWiDVinKWymBwUECQZzsL(int P_0, int P_1, int P_2, float P_3)
		{
			lock (qIQlBFFGDiShOcCyrfZvJAVTChJ)
			{
				uwkxBtpdyXYHUhMTbmiGcoRwVcf = new sCsiVmqRgHvljAcnIRaumySfCFh(FkOZLdUtQgJRZnYbeAAyngQvSuZ, P_0, P_1, P_2, P_3);
			}
		}

		private void OCYauBCLbvZTkaILZmGLmnynwEf()
		{
			if (!aMKqqzErhtNXhyxSwjqcdYmpEMF)
			{
				return;
			}
			double realTime;
			try
			{
				LMofllDVwkfLxnRkZcSVHJPEQcuP.zWBKFnkRdYQHNgNlrfRthQWDABBS(FkOZLdUtQgJRZnYbeAAyngQvSuZ);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			lock (qIQlBFFGDiShOcCyrfZvJAVTChJ)
			{
				if (uwkxBtpdyXYHUhMTbmiGcoRwVcf != null)
				{
					uwkxBtpdyXYHUhMTbmiGcoRwVcf.FFYEDujhZPZIRSsDbLkeXQkxTZI(realTime);
				}
				if (!FkOZLdUtQgJRZnYbeAAyngQvSuZ.dYOaLlRHcJVwHLmfUkuMqErJqjy(OzRKYUwWBpaXzOAVNLiKgxPNsms))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = qBsNOlJaQtsdnZAlQWMSpzDbRSm.T_CreateEvent())
					{
						nAERUaBFQqjlLwmXYXAQmrdRYth.pRjYNlQQpYlPrhDAWsvlgmgLMvl(FkOZLdUtQgJRZnYbeAAyngQvSuZ, realTime, newEventWrapper.Event);
					}
					OzRKYUwWBpaXzOAVNLiKgxPNsms.WilpheradKREcjoLhhcMLOKbDOaC(FkOZLdUtQgJRZnYbeAAyngQvSuZ);
				}
			}
		}

		private void AIJrFJkuFrnshjjAWCkQgZXuBhpa()
		{
			while (qBsNOlJaQtsdnZAlQWMSpzDbRSm.ProcessNewEvents())
			{
				while (true)
				{
					CMjluvrRaCraCeKHTYWBCAtVwSN.WilpheradKREcjoLhhcMLOKbDOaC(ref qBsNOlJaQtsdnZAlQWMSpzDbRSm.currentEvent);
					int num = 0;
					int num2 = -1952815643;
					while (true)
					{
						switch (num2 ^ -1952815641)
						{
						case 3:
							num2 = -1952815642;
							continue;
						case 1:
							break;
						case 2:
							goto IL_004a;
						case 4:
							kxhgtldiZvXtvpQoAQRmEtvWcQG.SetValue(num, CMjluvrRaCraCeKHTYWBCAtVwSN.BbQZXfVAmQcAGiAipTBZtTMzfgS[num], qBsNOlJaQtsdnZAlQWMSpzDbRSm.currentEvent.GetTimestamp());
							num++;
							num2 = -1952815643;
							continue;
						default:
							goto end_IL_002b;
						}
						break;
						IL_004a:
						int num3;
						if (num < eHZGWCRkabPOlmhdTfYEHDwgrZW)
						{
							num2 = -1952815645;
							num3 = num2;
						}
						else
						{
							num2 = -1952815641;
							num3 = num2;
						}
					}
					continue;
					end_IL_002b:
					break;
				}
			}
		}

		private void RFDPexajhTcXvizzpCmOkHbzMGox()
		{
			CMjluvrRaCraCeKHTYWBCAtVwSN.ibajyEOvcZaAVvqbaVIEPkwcIqx();
			lock (qIQlBFFGDiShOcCyrfZvJAVTChJ)
			{
				FkOZLdUtQgJRZnYbeAAyngQvSuZ.ibajyEOvcZaAVvqbaVIEPkwcIqx();
				OzRKYUwWBpaXzOAVNLiKgxPNsms.ibajyEOvcZaAVvqbaVIEPkwcIqx();
				qBsNOlJaQtsdnZAlQWMSpzDbRSm.Clear();
			}
			kxhgtldiZvXtvpQoAQRmEtvWcQG.Clear();
		}

		public void Dispose()
		{
			WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
			GC.SuppressFinalize(this);
		}

		~IPQPLNMoyLRdmrBDMONOOacSFFX()
		{
			WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
		}

		protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
		{
			if (inweGjIgYacXYohFlYRlpMFkgKMi)
			{
				return;
			}
			while (true)
			{
				int num;
				if (P_0)
				{
					qhdlbmvVPGSkmbKUCbanVffQNKm();
					qBsNOlJaQtsdnZAlQWMSpzDbRSm.Dispose();
					num = 461603;
					goto IL_000e;
				}
				goto IL_0046;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x70B20)
					{
					case 0:
						num = 461601;
						continue;
					case 1:
						break;
					case 3:
						goto IL_0046;
					default:
						goto end_IL_002b;
					}
					break;
				}
				continue;
				IL_0046:
				if (kpfkMpAFolETeEcXIDaJMkIYftRp.joystickInputThread == null)
				{
					break;
				}
				kpfkMpAFolETeEcXIDaJMkIYftRp.joystickInputThread.ThreadUpdateEvent -= OCYauBCLbvZTkaILZmGLmnynwEf;
				num = 461602;
				goto IL_000e;
				continue;
				end_IL_002b:
				break;
			}
			inweGjIgYacXYohFlYRlpMFkgKMi = true;
		}

		private static float oMNnXrBObsqXntKHDHpZyOhNBhe(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}
	}

	private class sCsiVmqRgHvljAcnIRaumySfCFh
	{
		private SkGbNCWHoQzwqvkkxZjAhCbrAHF TRNSnAaQWBUoQGgmNtjUyPmCDCT;

		private suwjaIBpIOrslANykByybWsCqFrW zlcpIRoqHVhvXkXCyglcoSxplBr;

		private int ZkFDcyLkLeJiWaWBkFrECJUhNBu;

		private int UOAFUwFQOtmAgxNJbAIaGjzNbcM;

		private int UxFjbxmMydSOBNzgOqcHlXGrvKn;

		private float SDeietiPNdUiNsymbrrUechfjFqf;

		public SkGbNCWHoQzwqvkkxZjAhCbrAHF state => TRNSnAaQWBUoQGgmNtjUyPmCDCT;

		public static sCsiVmqRgHvljAcnIRaumySfCFh MJrUrFkVEmQSXxyzlCNgTEmSvVh(sCsiVmqRgHvljAcnIRaumySfCFh P_0, SkGbNCWHoQzwqvkkxZjAhCbrAHF P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new sCsiVmqRgHvljAcnIRaumySfCFh(P_0, P_1);
		}

		public sCsiVmqRgHvljAcnIRaumySfCFh(SkGbNCWHoQzwqvkkxZjAhCbrAHF state, int axisMin, int axisMax, int axisZero, float eventTimeout)
			: this(axisMin, axisMax, axisZero, eventTimeout)
		{
			zlcpIRoqHVhvXkXCyglcoSxplBr = new suwjaIBpIOrslANykByybWsCqFrW(state);
			TRNSnAaQWBUoQGgmNtjUyPmCDCT = new SkGbNCWHoQzwqvkkxZjAhCbrAHF();
		}

		private sCsiVmqRgHvljAcnIRaumySfCFh(sCsiVmqRgHvljAcnIRaumySfCFh source, SkGbNCWHoQzwqvkkxZjAhCbrAHF state)
			: this(state, source.ZkFDcyLkLeJiWaWBkFrECJUhNBu, source.UOAFUwFQOtmAgxNJbAIaGjzNbcM, source.UxFjbxmMydSOBNzgOqcHlXGrvKn, source.SDeietiPNdUiNsymbrrUechfjFqf)
		{
			WilpheradKREcjoLhhcMLOKbDOaC(source);
		}

		private sCsiVmqRgHvljAcnIRaumySfCFh(int axisMin, int axisMax, int axisZero, float axisTimeout)
		{
			ZkFDcyLkLeJiWaWBkFrECJUhNBu = axisMin;
			UOAFUwFQOtmAgxNJbAIaGjzNbcM = axisMax;
			UxFjbxmMydSOBNzgOqcHlXGrvKn = axisZero;
			SDeietiPNdUiNsymbrrUechfjFqf = axisTimeout;
		}

		public void FFYEDujhZPZIRSsDbLkeXQkxTZI(double P_0)
		{
			zlcpIRoqHVhvXkXCyglcoSxplBr.FFYEDujhZPZIRSsDbLkeXQkxTZI(P_0);
			if (!zlcpIRoqHVhvXkXCyglcoSxplBr.valueChanged)
			{
				goto IL_001c;
			}
			goto IL_037d;
			IL_001c:
			int num = -791904646;
			goto IL_0021;
			IL_0021:
			int num2 = default(int);
			SkGbNCWHoQzwqvkkxZjAhCbrAHF changedState = default(SkGbNCWHoQzwqvkkxZjAhCbrAHF);
			int num4 = default(int);
			int num5 = default(int);
			int num7 = default(int);
			int num6 = default(int);
			SkGbNCWHoQzwqvkkxZjAhCbrAHF sourceState = default(SkGbNCWHoQzwqvkkxZjAhCbrAHF);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -791904647)
				{
				case 4:
					break;
				default:
					return;
				case 20:
					num2++;
					num = -791904650;
					continue;
				case 10:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.AngularVelocityX = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.AngularVelocityX);
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.AngularVelocityY = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.AngularVelocityY);
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.AngularVelocityZ = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.AngularVelocityZ);
					num = -791904651;
					continue;
				case 21:
					if (num4 >= TRNSnAaQWBUoQGgmNtjUyPmCDCT.VelocitySliders.Length)
					{
						TRNSnAaQWBUoQGgmNtjUyPmCDCT.AccelerationX = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.AccelerationX);
						TRNSnAaQWBUoQGgmNtjUyPmCDCT.AccelerationY = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.AccelerationY);
						num = -791904667;
						continue;
					}
					goto case 8;
				case 3:
					if (P_0 >= zlcpIRoqHVhvXkXCyglcoSxplBr.lastChangedTimestamp + (double)SDeietiPNdUiNsymbrrUechfjFqf)
					{
						TRNSnAaQWBUoQGgmNtjUyPmCDCT.ibajyEOvcZaAVvqbaVIEPkwcIqx();
						num = -791904664;
						continue;
					}
					return;
				case 11:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.ForceSliders[num5] = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.ForceSliders[num5]);
					num = -791904656;
					continue;
				case 5:
					if (num7 >= TRNSnAaQWBUoQGgmNtjUyPmCDCT.PointOfViewControllers.Length)
					{
						num6 = 0;
						num = -791904661;
						continue;
					}
					goto case 1;
				case 15:
					if (num2 >= TRNSnAaQWBUoQGgmNtjUyPmCDCT.Sliders.Length)
					{
						num7 = 0;
						num = -791904644;
						continue;
					}
					goto case 24;
				case 24:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.Sliders[num2] = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.Sliders[num2]);
					num = -791904659;
					continue;
				case 19:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.Buttons[num6] = sourceState.Buttons[num6];
					num6++;
					num = -791904661;
					continue;
				case 23:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.AccelerationSliders[num3] = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.AccelerationSliders[num3]);
					num3++;
					num = -791904670;
					continue;
				case 2:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.TorqueX = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.TorqueX);
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.TorqueY = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.TorqueY);
					num = -791904647;
					continue;
				case 0:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.TorqueZ = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.TorqueZ);
					num5 = 0;
					num = -791904641;
					continue;
				case 14:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.AngularAccelerationY = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.AngularAccelerationY);
					num = -791904663;
					continue;
				case 18:
					if (num6 >= TRNSnAaQWBUoQGgmNtjUyPmCDCT.Buttons.Length)
					{
						TRNSnAaQWBUoQGgmNtjUyPmCDCT.VelocityX = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.VelocityX);
						TRNSnAaQWBUoQGgmNtjUyPmCDCT.VelocityY = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.VelocityY);
						TRNSnAaQWBUoQGgmNtjUyPmCDCT.VelocityZ = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.VelocityZ);
						num = -791904653;
						continue;
					}
					goto case 19;
				case 9:
					num5++;
					num = -791904641;
					continue;
				case 12:
					num4 = 0;
					num = -791904660;
					continue;
				case 16:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.AngularAccelerationZ = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.AngularAccelerationZ);
					num3 = 0;
					num = -791904670;
					continue;
				case 7:
					goto IL_037d;
				case 27:
					if (num3 >= TRNSnAaQWBUoQGgmNtjUyPmCDCT.AccelerationSliders.Length)
					{
						TRNSnAaQWBUoQGgmNtjUyPmCDCT.ForceX = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.ForceX);
						TRNSnAaQWBUoQGgmNtjUyPmCDCT.ForceY = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.ForceY);
						num = -791904669;
						continue;
					}
					goto case 23;
				case 1:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.PointOfViewControllers[num7] = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.PointOfViewControllers[num7]);
					num7++;
					num = -791904644;
					continue;
				case 25:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.RotationZ = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.RotationZ);
					num = -791904657;
					continue;
				case 26:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.ForceZ = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.ForceZ);
					num = -791904645;
					continue;
				case 6:
					goto IL_04c9;
				case 22:
					num2 = 0;
					num = -791904650;
					continue;
				case 13:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.AngularAccelerationX = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.AngularAccelerationX);
					num = -791904649;
					continue;
				case 28:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.AccelerationZ = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.AccelerationZ);
					num = -791904652;
					continue;
				case 8:
					TRNSnAaQWBUoQGgmNtjUyPmCDCT.VelocitySliders[num4] = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.VelocitySliders[num4]);
					num4++;
					num = -791904660;
					continue;
				case 17:
					return;
				case 29:
					return;
				}
				break;
				IL_04c9:
				int num8;
				if (num5 < TRNSnAaQWBUoQGgmNtjUyPmCDCT.ForceSliders.Length)
				{
					num = -791904654;
					num8 = num;
				}
				else
				{
					num = -791904668;
					num8 = num;
				}
			}
			goto IL_001c;
			IL_037d:
			changedState = zlcpIRoqHVhvXkXCyglcoSxplBr.changedState;
			sourceState = zlcpIRoqHVhvXkXCyglcoSxplBr.sourceState;
			TRNSnAaQWBUoQGgmNtjUyPmCDCT.X = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.X);
			TRNSnAaQWBUoQGgmNtjUyPmCDCT.Y = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.Y);
			TRNSnAaQWBUoQGgmNtjUyPmCDCT.Z = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.Z);
			TRNSnAaQWBUoQGgmNtjUyPmCDCT.RotationX = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.RotationX);
			TRNSnAaQWBUoQGgmNtjUyPmCDCT.RotationY = QTFLLpVyfQPteDzvZLlMnnNjUvP(changedState.RotationY);
			num = -791904672;
			goto IL_0021;
		}

		public void WilpheradKREcjoLhhcMLOKbDOaC(sCsiVmqRgHvljAcnIRaumySfCFh P_0)
		{
			TRNSnAaQWBUoQGgmNtjUyPmCDCT.WilpheradKREcjoLhhcMLOKbDOaC(P_0.TRNSnAaQWBUoQGgmNtjUyPmCDCT);
			zlcpIRoqHVhvXkXCyglcoSxplBr.WilpheradKREcjoLhhcMLOKbDOaC(P_0.zlcpIRoqHVhvXkXCyglcoSxplBr);
			ZkFDcyLkLeJiWaWBkFrECJUhNBu = P_0.ZkFDcyLkLeJiWaWBkFrECJUhNBu;
			while (true)
			{
				int num = 1808827935;
				while (true)
				{
					switch (num ^ 0x6BD0861E)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						UOAFUwFQOtmAgxNJbAIaGjzNbcM = P_0.UOAFUwFQOtmAgxNJbAIaGjzNbcM;
						num = 1808827932;
						continue;
					case 2:
						UxFjbxmMydSOBNzgOqcHlXGrvKn = P_0.UxFjbxmMydSOBNzgOqcHlXGrvKn;
						SDeietiPNdUiNsymbrrUechfjFqf = P_0.SDeietiPNdUiNsymbrrUechfjFqf;
						num = 1808827933;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private int QTFLLpVyfQPteDzvZLlMnnNjUvP(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, ZkFDcyLkLeJiWaWBkFrECJUhNBu, UOAFUwFQOtmAgxNJbAIaGjzNbcM, -65535, 65535);
		}
	}

	private class suwjaIBpIOrslANykByybWsCqFrW
	{
		private double zIwszrjtNAzDefefNPMypcOsgPt;

		private SkGbNCWHoQzwqvkkxZjAhCbrAHF UTwPMeictNWlVVBioxymjrDhwnj;

		private SkGbNCWHoQzwqvkkxZjAhCbrAHF ZuyGxZdcYauuwCfejNIoinluXFDg;

		private SkGbNCWHoQzwqvkkxZjAhCbrAHF DBKLDIgGSJcasEmyQlBQblrijrpk;

		private bool qOFlGqZHiwFToldbPmrHPMXYgJV;

		private double kDOCCeAvuFjJZbzBarMEJxVQYpjm;

		public SkGbNCWHoQzwqvkkxZjAhCbrAHF sourceState => UTwPMeictNWlVVBioxymjrDhwnj;

		public SkGbNCWHoQzwqvkkxZjAhCbrAHF changedState => DBKLDIgGSJcasEmyQlBQblrijrpk;

		public bool valueChanged => qOFlGqZHiwFToldbPmrHPMXYgJV;

		public double lastChangedTimestamp => kDOCCeAvuFjJZbzBarMEJxVQYpjm;

		public suwjaIBpIOrslANykByybWsCqFrW(SkGbNCWHoQzwqvkkxZjAhCbrAHF sourceState)
		{
			UTwPMeictNWlVVBioxymjrDhwnj = sourceState;
			ZuyGxZdcYauuwCfejNIoinluXFDg = new SkGbNCWHoQzwqvkkxZjAhCbrAHF();
			DBKLDIgGSJcasEmyQlBQblrijrpk = new SkGbNCWHoQzwqvkkxZjAhCbrAHF();
		}

		public void FFYEDujhZPZIRSsDbLkeXQkxTZI(double P_0)
		{
			zIwszrjtNAzDefefNPMypcOsgPt = P_0;
			int num5 = default(int);
			int num4 = default(int);
			int num7 = default(int);
			int num11 = default(int);
			int num6 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = 857927606;
				while (true)
				{
					switch (num ^ 0x3322EFAC)
					{
					case 0:
						break;
					default:
						return;
					case 14:
						DBKLDIgGSJcasEmyQlBQblrijrpk.PointOfViewControllers[num5] = UTwPMeictNWlVVBioxymjrDhwnj.PointOfViewControllers[num5] - ZuyGxZdcYauuwCfejNIoinluXFDg.PointOfViewControllers[num5];
						num = 857927600;
						continue;
					case 28:
						num5++;
						num = 857927608;
						continue;
					case 21:
						DBKLDIgGSJcasEmyQlBQblrijrpk.AccelerationSliders[num4] = UTwPMeictNWlVVBioxymjrDhwnj.AccelerationSliders[num4] - ZuyGxZdcYauuwCfejNIoinluXFDg.AccelerationSliders[num4];
						num = 857927598;
						continue;
					case 29:
						DBKLDIgGSJcasEmyQlBQblrijrpk.Z = UTwPMeictNWlVVBioxymjrDhwnj.Z - ZuyGxZdcYauuwCfejNIoinluXFDg.Z;
						num = 857927585;
						continue;
					case 24:
						DBKLDIgGSJcasEmyQlBQblrijrpk.AngularVelocityY = UTwPMeictNWlVVBioxymjrDhwnj.AngularVelocityY - ZuyGxZdcYauuwCfejNIoinluXFDg.AngularVelocityY;
						DBKLDIgGSJcasEmyQlBQblrijrpk.AngularVelocityZ = UTwPMeictNWlVVBioxymjrDhwnj.AngularVelocityZ - ZuyGxZdcYauuwCfejNIoinluXFDg.AngularVelocityZ;
						num = 857927593;
						continue;
					case 5:
						num7 = 0;
						num = 857927597;
						continue;
					case 26:
						DBKLDIgGSJcasEmyQlBQblrijrpk.X = UTwPMeictNWlVVBioxymjrDhwnj.X - ZuyGxZdcYauuwCfejNIoinluXFDg.X;
						DBKLDIgGSJcasEmyQlBQblrijrpk.Y = UTwPMeictNWlVVBioxymjrDhwnj.Y - ZuyGxZdcYauuwCfejNIoinluXFDg.Y;
						num = 857927601;
						continue;
					case 1:
					{
						int num8;
						if (num7 < UTwPMeictNWlVVBioxymjrDhwnj.VelocitySliders.Length)
						{
							num = 857927610;
							num8 = num;
						}
						else
						{
							num = 857927599;
							num8 = num;
						}
						continue;
					}
					case 18:
						DBKLDIgGSJcasEmyQlBQblrijrpk.TorqueX = UTwPMeictNWlVVBioxymjrDhwnj.TorqueX - ZuyGxZdcYauuwCfejNIoinluXFDg.TorqueX;
						DBKLDIgGSJcasEmyQlBQblrijrpk.TorqueY = UTwPMeictNWlVVBioxymjrDhwnj.TorqueY - ZuyGxZdcYauuwCfejNIoinluXFDg.TorqueY;
						num = 857927605;
						continue;
					case 17:
						num4 = 0;
						num = 857927589;
						continue;
					case 7:
						DBKLDIgGSJcasEmyQlBQblrijrpk.ForceX = UTwPMeictNWlVVBioxymjrDhwnj.ForceX - ZuyGxZdcYauuwCfejNIoinluXFDg.ForceX;
						DBKLDIgGSJcasEmyQlBQblrijrpk.ForceY = UTwPMeictNWlVVBioxymjrDhwnj.ForceY - ZuyGxZdcYauuwCfejNIoinluXFDg.ForceY;
						DBKLDIgGSJcasEmyQlBQblrijrpk.ForceZ = UTwPMeictNWlVVBioxymjrDhwnj.ForceZ - ZuyGxZdcYauuwCfejNIoinluXFDg.ForceZ;
						num = 857927614;
						continue;
					case 19:
					{
						int num12;
						if (num11 >= UTwPMeictNWlVVBioxymjrDhwnj.ForceSliders.Length)
						{
							num = 857927591;
							num12 = num;
						}
						else
						{
							num = 857927594;
							num12 = num;
						}
						continue;
					}
					case 6:
						DBKLDIgGSJcasEmyQlBQblrijrpk.ForceSliders[num11] = UTwPMeictNWlVVBioxymjrDhwnj.ForceSliders[num11] - ZuyGxZdcYauuwCfejNIoinluXFDg.ForceSliders[num11];
						num11++;
						num = 857927615;
						continue;
					case 4:
						DBKLDIgGSJcasEmyQlBQblrijrpk.Buttons[num6] = UTwPMeictNWlVVBioxymjrDhwnj.Buttons[num6] != ZuyGxZdcYauuwCfejNIoinluXFDg.Buttons[num6];
						num6++;
						num = 857927588;
						continue;
					case 25:
						DBKLDIgGSJcasEmyQlBQblrijrpk.TorqueZ = UTwPMeictNWlVVBioxymjrDhwnj.TorqueZ - ZuyGxZdcYauuwCfejNIoinluXFDg.TorqueZ;
						num11 = 0;
						num = 857927615;
						continue;
					case 16:
						num7++;
						num = 857927597;
						continue;
					case 9:
					{
						int num10;
						if (num4 >= UTwPMeictNWlVVBioxymjrDhwnj.AccelerationSliders.Length)
						{
							num = 857927595;
							num10 = num;
						}
						else
						{
							num = 857927609;
							num10 = num;
						}
						continue;
					}
					case 2:
						num4++;
						num = 857927589;
						continue;
					case 20:
						if (num5 >= UTwPMeictNWlVVBioxymjrDhwnj.PointOfViewControllers.Length)
						{
							num6 = 0;
							num = 857927588;
							continue;
						}
						goto case 14;
					case 3:
						DBKLDIgGSJcasEmyQlBQblrijrpk.AccelerationX = UTwPMeictNWlVVBioxymjrDhwnj.AccelerationX - ZuyGxZdcYauuwCfejNIoinluXFDg.AccelerationX;
						DBKLDIgGSJcasEmyQlBQblrijrpk.AccelerationY = UTwPMeictNWlVVBioxymjrDhwnj.AccelerationY - ZuyGxZdcYauuwCfejNIoinluXFDg.AccelerationY;
						DBKLDIgGSJcasEmyQlBQblrijrpk.AccelerationZ = UTwPMeictNWlVVBioxymjrDhwnj.AccelerationZ - ZuyGxZdcYauuwCfejNIoinluXFDg.AccelerationZ;
						DBKLDIgGSJcasEmyQlBQblrijrpk.AngularAccelerationX = UTwPMeictNWlVVBioxymjrDhwnj.AngularAccelerationX - ZuyGxZdcYauuwCfejNIoinluXFDg.AngularAccelerationX;
						DBKLDIgGSJcasEmyQlBQblrijrpk.AngularAccelerationY = UTwPMeictNWlVVBioxymjrDhwnj.AngularAccelerationY - ZuyGxZdcYauuwCfejNIoinluXFDg.AngularAccelerationY;
						DBKLDIgGSJcasEmyQlBQblrijrpk.AngularAccelerationZ = UTwPMeictNWlVVBioxymjrDhwnj.AngularAccelerationZ - ZuyGxZdcYauuwCfejNIoinluXFDg.AngularAccelerationZ;
						num = 857927613;
						continue;
					case 30:
					{
						int num9;
						if (qOFlGqZHiwFToldbPmrHPMXYgJV)
						{
							num = 857927611;
							num9 = num;
						}
						else
						{
							num = 857927584;
							num9 = num;
						}
						continue;
					}
					case 23:
						kDOCCeAvuFjJZbzBarMEJxVQYpjm = P_0;
						ZuyGxZdcYauuwCfejNIoinluXFDg.WilpheradKREcjoLhhcMLOKbDOaC(UTwPMeictNWlVVBioxymjrDhwnj);
						num = 857927584;
						continue;
					case 13:
						DBKLDIgGSJcasEmyQlBQblrijrpk.RotationX = UTwPMeictNWlVVBioxymjrDhwnj.RotationX - ZuyGxZdcYauuwCfejNIoinluXFDg.RotationX;
						num = 857927603;
						continue;
					case 22:
						DBKLDIgGSJcasEmyQlBQblrijrpk.VelocitySliders[num7] = UTwPMeictNWlVVBioxymjrDhwnj.VelocitySliders[num7] - ZuyGxZdcYauuwCfejNIoinluXFDg.VelocitySliders[num7];
						num = 857927612;
						continue;
					case 8:
						if (num6 >= UTwPMeictNWlVVBioxymjrDhwnj.Buttons.Length)
						{
							DBKLDIgGSJcasEmyQlBQblrijrpk.VelocityX = UTwPMeictNWlVVBioxymjrDhwnj.VelocityX - ZuyGxZdcYauuwCfejNIoinluXFDg.VelocityX;
							DBKLDIgGSJcasEmyQlBQblrijrpk.VelocityY = UTwPMeictNWlVVBioxymjrDhwnj.VelocityY - ZuyGxZdcYauuwCfejNIoinluXFDg.VelocityY;
							DBKLDIgGSJcasEmyQlBQblrijrpk.VelocityZ = UTwPMeictNWlVVBioxymjrDhwnj.VelocityZ - ZuyGxZdcYauuwCfejNIoinluXFDg.VelocityZ;
							DBKLDIgGSJcasEmyQlBQblrijrpk.AngularVelocityX = UTwPMeictNWlVVBioxymjrDhwnj.AngularVelocityX - ZuyGxZdcYauuwCfejNIoinluXFDg.AngularVelocityX;
							num = 857927604;
							continue;
						}
						goto case 4;
					case 15:
						num5 = 0;
						num = 857927608;
						continue;
					case 11:
						qOFlGqZHiwFToldbPmrHPMXYgJV = GoxnVvUQRQIlUOayYMMWwNKYqrZ();
						num = 857927602;
						continue;
					case 27:
					{
						int num3;
						if (num2 >= UTwPMeictNWlVVBioxymjrDhwnj.Sliders.Length)
						{
							num = 857927587;
							num3 = num;
						}
						else
						{
							num = 857927590;
							num3 = num;
						}
						continue;
					}
					case 31:
						DBKLDIgGSJcasEmyQlBQblrijrpk.RotationY = UTwPMeictNWlVVBioxymjrDhwnj.RotationY - ZuyGxZdcYauuwCfejNIoinluXFDg.RotationY;
						DBKLDIgGSJcasEmyQlBQblrijrpk.RotationZ = UTwPMeictNWlVVBioxymjrDhwnj.RotationZ - ZuyGxZdcYauuwCfejNIoinluXFDg.RotationZ;
						num2 = 0;
						num = 857927607;
						continue;
					case 10:
						DBKLDIgGSJcasEmyQlBQblrijrpk.Sliders[num2] = UTwPMeictNWlVVBioxymjrDhwnj.Sliders[num2] - ZuyGxZdcYauuwCfejNIoinluXFDg.Sliders[num2];
						num2++;
						num = 857927607;
						continue;
					case 12:
						return;
					}
					break;
				}
			}
		}

		public void WilpheradKREcjoLhhcMLOKbDOaC(suwjaIBpIOrslANykByybWsCqFrW P_0)
		{
			zIwszrjtNAzDefefNPMypcOsgPt = P_0.zIwszrjtNAzDefefNPMypcOsgPt;
			while (true)
			{
				int num = -1148238775;
				while (true)
				{
					switch (num ^ -1148238776)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_002a;
					case 0:
						return;
					}
					break;
					IL_002a:
					ZuyGxZdcYauuwCfejNIoinluXFDg.WilpheradKREcjoLhhcMLOKbDOaC(P_0.ZuyGxZdcYauuwCfejNIoinluXFDg);
					DBKLDIgGSJcasEmyQlBQblrijrpk.WilpheradKREcjoLhhcMLOKbDOaC(P_0.DBKLDIgGSJcasEmyQlBQblrijrpk);
					num = -1148238776;
				}
			}
		}

		private bool GoxnVvUQRQIlUOayYMMWwNKYqrZ()
		{
			if (DBKLDIgGSJcasEmyQlBQblrijrpk.Y != 0)
			{
				return true;
			}
			if (DBKLDIgGSJcasEmyQlBQblrijrpk.Z != 0)
			{
				return true;
			}
			if (DBKLDIgGSJcasEmyQlBQblrijrpk.RotationX != 0)
			{
				return true;
			}
			if (DBKLDIgGSJcasEmyQlBQblrijrpk.RotationY != 0)
			{
				goto IL_003d;
			}
			int num;
			int num2 = default(int);
			if (DBKLDIgGSJcasEmyQlBQblrijrpk.RotationZ != 0)
			{
				num = 1752161167;
			}
			else
			{
				num2 = 0;
				num = 1752161158;
			}
			goto IL_0042;
			IL_0042:
			int num6 = default(int);
			int num3 = default(int);
			int num7 = default(int);
			int num5 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num ^ 0x686FDB81)
				{
				case 19:
					break;
				case 5:
				{
					int num8;
					if (num6 < UTwPMeictNWlVVBioxymjrDhwnj.ForceSliders.Length)
					{
						num = 1752161168;
						num8 = num;
					}
					else
					{
						num = 1752161152;
						num8 = num;
					}
					continue;
				}
				case 16:
					return true;
				case 2:
					num3 = 0;
					num = 1752161172;
					continue;
				case 15:
					if (DBKLDIgGSJcasEmyQlBQblrijrpk.PointOfViewControllers[num7] != 0)
					{
						return true;
					}
					num7++;
					num = 1752161161;
					continue;
				case 6:
					return true;
				case 9:
					num = 1752161154;
					continue;
				case 11:
					if (DBKLDIgGSJcasEmyQlBQblrijrpk.Buttons[num3])
					{
						return true;
					}
					num3++;
					num = 1752161172;
					continue;
				case 10:
					return true;
				case 20:
					return true;
				case 4:
					return true;
				case 7:
					if (num2 >= UTwPMeictNWlVVBioxymjrDhwnj.Sliders.Length)
					{
						num7 = 0;
						num = 1752161161;
						continue;
					}
					goto case 12;
				case 3:
					if (num5 >= UTwPMeictNWlVVBioxymjrDhwnj.AccelerationSliders.Length)
					{
						if (DBKLDIgGSJcasEmyQlBQblrijrpk.ForceX != 0)
						{
							return true;
						}
						if (DBKLDIgGSJcasEmyQlBQblrijrpk.ForceY != 0)
						{
							return true;
						}
						if (DBKLDIgGSJcasEmyQlBQblrijrpk.ForceZ != 0)
						{
							return true;
						}
						if (DBKLDIgGSJcasEmyQlBQblrijrpk.TorqueX == 0)
						{
							if (DBKLDIgGSJcasEmyQlBQblrijrpk.TorqueY != 0)
							{
								return true;
							}
							if (DBKLDIgGSJcasEmyQlBQblrijrpk.TorqueZ != 0)
							{
								return true;
							}
							num6 = 0;
							num = 1752161156;
						}
						else
						{
							num = 1752161157;
						}
						continue;
					}
					goto case 18;
				case 12:
					if (DBKLDIgGSJcasEmyQlBQblrijrpk.Sliders[num2] != 0)
					{
						return true;
					}
					num2++;
					num = 1752161158;
					continue;
				case 22:
					if (num4 >= UTwPMeictNWlVVBioxymjrDhwnj.VelocitySliders.Length)
					{
						if (DBKLDIgGSJcasEmyQlBQblrijrpk.AccelerationX == 0)
						{
							if (DBKLDIgGSJcasEmyQlBQblrijrpk.AccelerationY != 0)
							{
								return true;
							}
							if (DBKLDIgGSJcasEmyQlBQblrijrpk.AccelerationZ != 0)
							{
								return true;
							}
							if (DBKLDIgGSJcasEmyQlBQblrijrpk.AngularAccelerationX != 0)
							{
								return true;
							}
							if (DBKLDIgGSJcasEmyQlBQblrijrpk.AngularAccelerationY == 0)
							{
								if (DBKLDIgGSJcasEmyQlBQblrijrpk.AngularAccelerationZ != 0)
								{
									return true;
								}
								num5 = 0;
								num = 1752161160;
							}
							else
							{
								num = 1752161169;
							}
						}
						else
						{
							num = 1752161163;
						}
						continue;
					}
					goto case 13;
				case 8:
				{
					int num9;
					if (num7 >= UTwPMeictNWlVVBioxymjrDhwnj.PointOfViewControllers.Length)
					{
						num = 1752161155;
						num9 = num;
					}
					else
					{
						num = 1752161166;
						num9 = num;
					}
					continue;
				}
				case 18:
					DBKLDIgGSJcasEmyQlBQblrijrpk.AccelerationSliders[num5] = UTwPMeictNWlVVBioxymjrDhwnj.AccelerationSliders[num5] - ZuyGxZdcYauuwCfejNIoinluXFDg.AccelerationSliders[num5];
					num5++;
					num = 1752161154;
					continue;
				case 13:
					if (DBKLDIgGSJcasEmyQlBQblrijrpk.VelocitySliders[num4] != 0)
					{
						num = 1752161153;
						continue;
					}
					num4++;
					num = 1752161175;
					continue;
				case 23:
					return true;
				case 14:
					return true;
				case 17:
					if (DBKLDIgGSJcasEmyQlBQblrijrpk.ForceSliders[num6] != 0)
					{
						return true;
					}
					num6++;
					num = 1752161156;
					continue;
				case 0:
					return true;
				case 21:
					if (num3 >= UTwPMeictNWlVVBioxymjrDhwnj.Buttons.Length)
					{
						if (DBKLDIgGSJcasEmyQlBQblrijrpk.VelocityX != 0)
						{
							return true;
						}
						if (DBKLDIgGSJcasEmyQlBQblrijrpk.VelocityY != 0)
						{
							return true;
						}
						if (DBKLDIgGSJcasEmyQlBQblrijrpk.VelocityZ == 0)
						{
							if (DBKLDIgGSJcasEmyQlBQblrijrpk.AngularVelocityX == 0)
							{
								if (DBKLDIgGSJcasEmyQlBQblrijrpk.AngularVelocityY != 0)
								{
									return true;
								}
								if (DBKLDIgGSJcasEmyQlBQblrijrpk.AngularVelocityZ != 0)
								{
									return true;
								}
								num4 = 0;
								num = 1752161175;
							}
							else
							{
								num = 1752161159;
							}
						}
						else
						{
							num = 1752161174;
						}
						continue;
					}
					goto case 11;
				default:
					return false;
				}
				break;
			}
			goto IL_003d;
			IL_003d:
			num = 1752161173;
			goto IL_0042;
		}
	}

	private class BLYKrQIleVekFbPYioNUeiFKybSN
	{
		public enum cBKHAZGZFmCVFrxIEiUKPNqKoqKX
		{
			afFbgEzNXvGvvGsLKuJIIflFbruT = 0,
			UFRAQlMKzdfISVPlAcYSIMiPnrq = 1
		}

		public class VGiukJbsdARxicCNzWoewCuHLIV
		{
			public int VGSrrWYLNAwIbrYoUwvzVCxXdRzc;

			public Guid XycawPIOvCyONuaycBLuYSafxNd;

			public Guid LFrLHWCZQzUjUEpwygbljLuHiCF;

			public int RgyPfpfFQwdoJNiBIXrQsaliAnP;

			public int qhBaQiBUaifpRBvldoZTqTDFPFqY;

			public int lenAIRsoOFqjBdbpibHDlBXGVmR;

			public int QQactFjAyaivYJCKROwerenGIZRE;

			public bool FcvkUyKypZmJCfGSpczJhAaNNjEx(MUlnPVcZgGLeXkhLihgLQlrmnHb P_0, cBKHAZGZFmCVFrxIEiUKPNqKoqKX P_1)
			{
				if (P_0.rewiredId == VGSrrWYLNAwIbrYoUwvzVCxXdRzc)
				{
					return true;
				}
				if (qhBaQiBUaifpRBvldoZTqTDFPFqY != P_0.qhBaQiBUaifpRBvldoZTqTDFPFqY)
				{
					goto IL_001e;
				}
				int num;
				if (lenAIRsoOFqjBdbpibHDlBXGVmR != P_0.lenAIRsoOFqjBdbpibHDlBXGVmR)
				{
					num = 1181973029;
				}
				else
				{
					if (QQactFjAyaivYJCKROwerenGIZRE != P_0.QQactFjAyaivYJCKROwerenGIZRE)
					{
						return false;
					}
					if (P_1 != cBKHAZGZFmCVFrxIEiUKPNqKoqKX.afFbgEzNXvGvvGsLKuJIIflFbruT)
					{
						if (P_1 != cBKHAZGZFmCVFrxIEiUKPNqKoqKX.UFRAQlMKzdfISVPlAcYSIMiPnrq)
						{
							throw new NotImplementedException();
						}
						num = 1181973027;
					}
					else
					{
						num = 1181973031;
					}
				}
				goto IL_0023;
				IL_0023:
				switch (num ^ 0x46737A27)
				{
				case 3:
					break;
				case 1:
					return false;
				case 0:
					return XycawPIOvCyONuaycBLuYSafxNd == P_0.instanceGuid;
				case 2:
					return false;
				default:
					return LFrLHWCZQzUjUEpwygbljLuHiCF == P_0.LFrLHWCZQzUjUEpwygbljLuHiCF;
				}
				goto IL_001e;
				IL_001e:
				num = 1181973030;
				goto IL_0023;
			}

			public override string ToString()
			{
				string text = "";
				object[] array4 = default(object[]);
				object obj4 = default(object);
				object[] array2 = default(object[]);
				object obj5 = default(object);
				object[] array3 = default(object[]);
				object obj2 = default(object);
				object obj = default(object);
				object obj3 = default(object);
				object[] array = default(object[]);
				while (true)
				{
					int num = -348598639;
					while (true)
					{
						switch (num ^ -348598631)
						{
						case 7:
							break;
						case 4:
							array4 = new object[4] { obj4, "hardwareAxisCount = ", qhBaQiBUaifpRBvldoZTqTDFPFqY, null };
							num = -348598630;
							continue;
						case 9:
							array2[0] = obj5;
							num = -348598628;
							continue;
						case 13:
							array3 = new object[4] { obj2, null, null, null };
							num = -348598629;
							continue;
						case 2:
							array3[1] = "lastInputManagerId = ";
							array3[2] = RgyPfpfFQwdoJNiBIXrQsaliAnP;
							num = -348598632;
							continue;
						case 6:
						{
							array2[3] = "\n";
							text = string.Concat(array2);
							object obj7 = text;
							text = string.Concat(obj7, "instanceGuid = ", XycawPIOvCyONuaycBLuYSafxNd, "\n");
							obj = text;
							num = -348598637;
							continue;
						}
						case 3:
						{
							array4[3] = "\n";
							text = string.Concat(array4);
							object obj6 = text;
							text = string.Concat(obj6, "hardwareButtonCount = ", lenAIRsoOFqjBdbpibHDlBXGVmR, "\n");
							obj3 = text;
							num = -348598638;
							continue;
						}
						case 8:
							obj5 = text;
							array2 = new object[4];
							num = -348598640;
							continue;
						case 0:
							array[3] = "\n";
							text = string.Concat(array);
							num = -348598635;
							continue;
						case 1:
							array3[3] = "\n";
							text = string.Concat(array3);
							obj4 = text;
							num = -348598627;
							continue;
						case 5:
							array2[1] = "rewiredId = ";
							array2[2] = VGSrrWYLNAwIbrYoUwvzVCxXdRzc;
							num = -348598625;
							continue;
						case 11:
							array = new object[4] { obj3, "hardwareHatCount = ", QQactFjAyaivYJCKROwerenGIZRE, null };
							num = -348598631;
							continue;
						case 10:
							text = string.Concat(obj, "typeIdentifierGuid = ", LFrLHWCZQzUjUEpwygbljLuHiCF, "\n");
							obj2 = text;
							num = -348598636;
							continue;
						default:
							return text;
						}
						break;
					}
				}
			}
		}

		private sealed class GplnHUzMtyveGeIjBYAzzheJXdm : IEnumerable<VGiukJbsdARxicCNzWoewCuHLIV>, IEnumerator<VGiukJbsdARxicCNzWoewCuHLIV>, IDisposable, IEnumerable, IEnumerator
		{
			private VGiukJbsdARxicCNzWoewCuHLIV zaeaxnimXYLPZwadZmMRLZSdyFWN;

			private int lBwCMCgvzsvBnpNnmYUoDOyCSvR;

			private int GAtDJGRHxGPYGsKYTZZuVqCmfac;

			public BLYKrQIleVekFbPYioNUeiFKybSN xvYPGRaXRVZlwecANemUYNIlHnq;

			public MUlnPVcZgGLeXkhLihgLQlrmnHb DIEZrMuylamgGcHdpTXXqfwtldf;

			public MUlnPVcZgGLeXkhLihgLQlrmnHb jsKqKJUJoxOmFqcsArDvuHUjkPy;

			public cBKHAZGZFmCVFrxIEiUKPNqKoqKX aCFerNKXEctsXPGMtFXeGIuKZyd;

			public cBKHAZGZFmCVFrxIEiUKPNqKoqKX OmMCHaaoqZqFnjPmdZNpWKskvkVC;

			public int dxfKglEysOPggFjvdJYkIXRGivS;

			public int SXVCudBkHceLEkQOVGJSnWsMZPY;

			VGiukJbsdARxicCNzWoewCuHLIV IEnumerator<VGiukJbsdARxicCNzWoewCuHLIV>.Current
			{
				[DebuggerHidden]
				get
				{
					return zaeaxnimXYLPZwadZmMRLZSdyFWN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return zaeaxnimXYLPZwadZmMRLZSdyFWN;
				}
			}

			[DebuggerHidden]
			IEnumerator<VGiukJbsdARxicCNzWoewCuHLIV> IEnumerable<VGiukJbsdARxicCNzWoewCuHLIV>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == GAtDJGRHxGPYGsKYTZZuVqCmfac && lBwCMCgvzsvBnpNnmYUoDOyCSvR == -2)
				{
					goto IL_001c;
				}
				goto IL_0054;
				IL_0054:
				GplnHUzMtyveGeIjBYAzzheJXdm gplnHUzMtyveGeIjBYAzzheJXdm = new GplnHUzMtyveGeIjBYAzzheJXdm(0);
				int num = 1955572228;
				goto IL_0021;
				IL_001c:
				num = 1955572224;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x748FAA01)
					{
					case 3:
						break;
					case 1:
						lBwCMCgvzsvBnpNnmYUoDOyCSvR = 0;
						num = 1955572227;
						continue;
					case 4:
						goto IL_0054;
					case 2:
						gplnHUzMtyveGeIjBYAzzheJXdm = this;
						num = 1955572225;
						continue;
					case 5:
						gplnHUzMtyveGeIjBYAzzheJXdm.xvYPGRaXRVZlwecANemUYNIlHnq = xvYPGRaXRVZlwecANemUYNIlHnq;
						num = 1955572225;
						continue;
					default:
						gplnHUzMtyveGeIjBYAzzheJXdm.DIEZrMuylamgGcHdpTXXqfwtldf = jsKqKJUJoxOmFqcsArDvuHUjkPy;
						gplnHUzMtyveGeIjBYAzzheJXdm.aCFerNKXEctsXPGMtFXeGIuKZyd = OmMCHaaoqZqFnjPmdZNpWKskvkVC;
						return gplnHUzMtyveGeIjBYAzzheJXdm;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<VGiukJbsdARxicCNzWoewCuHLIV>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (lBwCMCgvzsvBnpNnmYUoDOyCSvR)
				{
				case 1:
					lBwCMCgvzsvBnpNnmYUoDOyCSvR = -1;
					num = -11499596;
					goto IL_001f;
				case 0:
					{
						lBwCMCgvzsvBnpNnmYUoDOyCSvR = -1;
						dxfKglEysOPggFjvdJYkIXRGivS = xvYPGRaXRVZlwecANemUYNIlHnq.yyiFPljnUsCKsCDVIczjlInczmly.Count;
						SXVCudBkHceLEkQOVGJSnWsMZPY = 0;
						num = -11499598;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -11499594)
						{
						case 0:
							num = -11499595;
							continue;
						case 4:
							break;
						case 2:
							SXVCudBkHceLEkQOVGJSnWsMZPY++;
							num = -11499598;
							continue;
						case 5:
							if (xvYPGRaXRVZlwecANemUYNIlHnq.yyiFPljnUsCKsCDVIczjlInczmly[SXVCudBkHceLEkQOVGJSnWsMZPY].FcvkUyKypZmJCfGSpczJhAaNNjEx(DIEZrMuylamgGcHdpTXXqfwtldf, aCFerNKXEctsXPGMtFXeGIuKZyd))
							{
								zaeaxnimXYLPZwadZmMRLZSdyFWN = xvYPGRaXRVZlwecANemUYNIlHnq.yyiFPljnUsCKsCDVIczjlInczmly[SXVCudBkHceLEkQOVGJSnWsMZPY];
								lBwCMCgvzsvBnpNnmYUoDOyCSvR = 1;
								return true;
							}
							goto case 2;
						case 3:
							goto end_IL_001f;
						default:
							goto end_IL_0008;
						}
						int num2;
						if (SXVCudBkHceLEkQOVGJSnWsMZPY >= dxfKglEysOPggFjvdJYkIXRGivS)
						{
							num = -11499593;
							num2 = num;
						}
						else
						{
							num = -11499597;
							num2 = num;
						}
						continue;
						end_IL_001f:
						break;
					}
					goto case 0;
					end_IL_0008:
					break;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public GplnHUzMtyveGeIjBYAzzheJXdm(int _003C_003E1__state)
			{
				lBwCMCgvzsvBnpNnmYUoDOyCSvR = _003C_003E1__state;
				GAtDJGRHxGPYGsKYTZZuVqCmfac = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private List<VGiukJbsdARxicCNzWoewCuHLIV> yyiFPljnUsCKsCDVIczjlInczmly;

		public BLYKrQIleVekFbPYioNUeiFKybSN()
		{
			yyiFPljnUsCKsCDVIczjlInczmly = new List<VGiukJbsdARxicCNzWoewCuHLIV>();
		}

		public void kVadApUnAEuOWsMMZXVNAURVCZW(MUlnPVcZgGLeXkhLihgLQlrmnHb P_0)
		{
			if (P_0 == null)
			{
				goto IL_0006;
			}
			goto IL_0130;
			IL_0006:
			int num = 1927134202;
			goto IL_000b;
			IL_000b:
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				switch (num ^ 0x72DDBBF0)
				{
				case 5:
					break;
				default:
					return;
				case 1:
					yyiFPljnUsCKsCDVIczjlInczmly.Add(new VGiukJbsdARxicCNzWoewCuHLIV
					{
						VGSrrWYLNAwIbrYoUwvzVCxXdRzc = P_0.rewiredId,
						XycawPIOvCyONuaycBLuYSafxNd = P_0.instanceGuid,
						LFrLHWCZQzUjUEpwygbljLuHiCF = P_0.LFrLHWCZQzUjUEpwygbljLuHiCF,
						RgyPfpfFQwdoJNiBIXrQsaliAnP = P_0.inputManagerId,
						qhBaQiBUaifpRBvldoZTqTDFPFqY = P_0.qhBaQiBUaifpRBvldoZTqTDFPFqY,
						lenAIRsoOFqjBdbpibHDlBXGVmR = P_0.lenAIRsoOFqjBdbpibHDlBXGVmR,
						QQactFjAyaivYJCKROwerenGIZRE = P_0.QQactFjAyaivYJCKROwerenGIZRE
					});
					YxaByKiVVfVaZoBlAARoSYRdsvs(P_0.rewiredId, P_0.instanceGuid, yyiFPljnUsCKsCDVIczjlInczmly.Count - 1);
					num = 1927134194;
					continue;
				case 9:
					yyiFPljnUsCKsCDVIczjlInczmly[num2].QQactFjAyaivYJCKROwerenGIZRE = P_0.QQactFjAyaivYJCKROwerenGIZRE;
					YxaByKiVVfVaZoBlAARoSYRdsvs(P_0.rewiredId, P_0.instanceGuid, num2);
					return;
				case 7:
					yyiFPljnUsCKsCDVIczjlInczmly[num2].lenAIRsoOFqjBdbpibHDlBXGVmR = P_0.lenAIRsoOFqjBdbpibHDlBXGVmR;
					num = 1927134201;
					continue;
				case 4:
					goto IL_0130;
				case 3:
					yyiFPljnUsCKsCDVIczjlInczmly[num2].LFrLHWCZQzUjUEpwygbljLuHiCF = P_0.LFrLHWCZQzUjUEpwygbljLuHiCF;
					yyiFPljnUsCKsCDVIczjlInczmly[num2].RgyPfpfFQwdoJNiBIXrQsaliAnP = P_0.inputManagerId;
					num = 1927134203;
					continue;
				case 6:
					num2++;
					num = 1927134200;
					continue;
				case 8:
					goto IL_018e;
				case 0:
					if (yyiFPljnUsCKsCDVIczjlInczmly[num2].FcvkUyKypZmJCfGSpczJhAaNNjEx(P_0, cBKHAZGZFmCVFrxIEiUKPNqKoqKX.afFbgEzNXvGvvGsLKuJIIflFbruT))
					{
						yyiFPljnUsCKsCDVIczjlInczmly[num2].VGSrrWYLNAwIbrYoUwvzVCxXdRzc = P_0.rewiredId;
						yyiFPljnUsCKsCDVIczjlInczmly[num2].XycawPIOvCyONuaycBLuYSafxNd = P_0.instanceGuid;
						num = 1927134195;
						continue;
					}
					goto case 6;
				case 11:
					yyiFPljnUsCKsCDVIczjlInczmly[num2].qhBaQiBUaifpRBvldoZTqTDFPFqY = P_0.qhBaQiBUaifpRBvldoZTqTDFPFqY;
					num = 1927134199;
					continue;
				case 10:
					return;
				case 2:
					return;
				}
				break;
				IL_018e:
				int num3;
				if (num2 >= count)
				{
					num = 1927134193;
					num3 = num;
				}
				else
				{
					num = 1927134192;
					num3 = num;
				}
			}
			goto IL_0006;
			IL_0130:
			count = yyiFPljnUsCKsCDVIczjlInczmly.Count;
			num2 = 0;
			num = 1927134200;
			goto IL_000b;
		}

		public bool RYjoxuvBIQdFpgfUrGqIfrkODTT(MUlnPVcZgGLeXkhLihgLQlrmnHb P_0, cBKHAZGZFmCVFrxIEiUKPNqKoqKX P_1)
		{
			int count = yyiFPljnUsCKsCDVIczjlInczmly.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= count)
				{
					num2 = 814307916;
					num3 = num2;
				}
				else
				{
					num2 = 814307917;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x30895A4E)
					{
					case 0:
						num2 = 814307917;
						continue;
					case 3:
						if (yyiFPljnUsCKsCDVIczjlInczmly[num].FcvkUyKypZmJCfGSpczJhAaNNjEx(P_0, P_1))
						{
							return true;
						}
						num++;
						num2 = 814307919;
						continue;
					case 1:
						break;
					default:
						return false;
					}
					break;
				}
			}
		}

		public IEnumerable<VGiukJbsdARxicCNzWoewCuHLIV> joccDsvMkbNqtLkAGboThijYbVO(MUlnPVcZgGLeXkhLihgLQlrmnHb P_0, cBKHAZGZFmCVFrxIEiUKPNqKoqKX P_1)
		{
			GplnHUzMtyveGeIjBYAzzheJXdm gplnHUzMtyveGeIjBYAzzheJXdm = new GplnHUzMtyveGeIjBYAzzheJXdm(-2);
			gplnHUzMtyveGeIjBYAzzheJXdm.xvYPGRaXRVZlwecANemUYNIlHnq = this;
			gplnHUzMtyveGeIjBYAzzheJXdm.jsKqKJUJoxOmFqcsArDvuHUjkPy = P_0;
			gplnHUzMtyveGeIjBYAzzheJXdm.OmMCHaaoqZqFnjPmdZNpWKskvkVC = P_1;
			return gplnHUzMtyveGeIjBYAzzheJXdm;
		}

		private void YxaByKiVVfVaZoBlAARoSYRdsvs(int P_0, Guid P_1, int P_2)
		{
			int num = yyiFPljnUsCKsCDVIczjlInczmly.Count - 1;
			while (true)
			{
				int num2 = 1854389115;
				while (true)
				{
					switch (num2 ^ 0x6E87BB7D)
					{
					case 5:
						break;
					default:
						return;
					case 0:
						yyiFPljnUsCKsCDVIczjlInczmly.RemoveAt(num);
						num2 = 1854389116;
						continue;
					case 2:
						if (num != P_2)
						{
							if (yyiFPljnUsCKsCDVIczjlInczmly[num].VGSrrWYLNAwIbrYoUwvzVCxXdRzc != P_0)
							{
								int num4;
								if (yyiFPljnUsCKsCDVIczjlInczmly[num].XycawPIOvCyONuaycBLuYSafxNd == P_1)
								{
									num2 = 1854389117;
									num4 = num2;
								}
								else
								{
									num2 = 1854389116;
									num4 = num2;
								}
								continue;
							}
							goto case 0;
						}
						goto case 1;
					case 3:
					{
						int num3;
						if (num >= 0)
						{
							num2 = 1854389119;
							num3 = num2;
						}
						else
						{
							num2 = 1854389113;
							num3 = num2;
						}
						continue;
					}
					case 6:
						num2 = 1854389118;
						continue;
					case 1:
						num--;
						num2 = 1854389118;
						continue;
					case 4:
						return;
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
			object[] array2 = default(object[]);
			while (true)
			{
				int num = -1430524718;
				while (true)
				{
					switch (num ^ -1430524716)
					{
					case 0:
						break;
					case 6:
						array[0] = obj;
						array[1] = "Joystick records: ";
						array[2] = yyiFPljnUsCKsCDVIczjlInczmly.Count;
						array[3] = "\n";
						text = string.Concat(array);
						num2 = 0;
						num = -1430524714;
						continue;
					case 4:
					{
						object obj2 = text;
						array2 = new object[4] { obj2, "Record ", num2, null };
						num = -1430524715;
						continue;
					}
					case 1:
						array2[3] = ":\n";
						text = string.Concat(array2);
						text = text + yyiFPljnUsCKsCDVIczjlInczmly[num2].ToString() + "\n\n";
						num = -1430524713;
						continue;
					case 3:
						num2++;
						num = -1430524714;
						continue;
					case 2:
					{
						int num3;
						if (num2 < yyiFPljnUsCKsCDVIczjlInczmly.Count)
						{
							num = -1430524720;
							num3 = num;
						}
						else
						{
							num = -1430524719;
							num3 = num;
						}
						continue;
					}
					default:
						return text;
					}
					break;
				}
			}
		}
	}

	private class MTODzdeeDWSBhpmBzjfrttsYwvJ
	{
		public MUlnPVcZgGLeXkhLihgLQlrmnHb AUIdfqdotGKPVLbiMbUhWyorbHfX;

		public wgrxsaianMUzjNMhgoWaIreVzBL pBDqZeaDGlqHjIwWxDonvqdrIAY;

		public bool IsValid
		{
			get
			{
				if (AUIdfqdotGKPVLbiMbUhWyorbHfX != null)
				{
					return pBDqZeaDGlqHjIwWxDonvqdrIAY != null;
				}
				return false;
			}
		}

		public MTODzdeeDWSBhpmBzjfrttsYwvJ(MUlnPVcZgGLeXkhLihgLQlrmnHb joystick, wgrxsaianMUzjNMhgoWaIreVzBL deviceInstance)
		{
			AUIdfqdotGKPVLbiMbUhWyorbHfX = joystick;
			pBDqZeaDGlqHjIwWxDonvqdrIAY = deviceInstance;
		}

		public static List<wgrxsaianMUzjNMhgoWaIreVzBL> HidJxImGvXQqyvpukZQivzqoHpD(List<MTODzdeeDWSBhpmBzjfrttsYwvJ> P_0)
		{
			if (P_0 == null)
			{
				return new List<wgrxsaianMUzjNMhgoWaIreVzBL>();
			}
			List<wgrxsaianMUzjNMhgoWaIreVzBL> list = new List<wgrxsaianMUzjNMhgoWaIreVzBL>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].IsValid)
				{
					list.Add(P_0[i].pBDqZeaDGlqHjIwWxDonvqdrIAY);
				}
			}
			return list;
		}
	}

	private class GpdFFvnRIxYpNXIUItrXtvfojO
	{
		public uRfjJqYedjnyNKOatXmscLaMEod hRfGdYBFJcCnJHKjbddhmAKdrjFP;

		public GpdFFvnRIxYpNXIUItrXtvfojO(uRfjJqYedjnyNKOatXmscLaMEod sdxJoystick)
		{
			hRfGdYBFJcCnJHKjbddhmAKdrjFP = sdxJoystick;
		}
	}

	private class mSHayxXplcOvqbZUOGKLXuYftph
	{
		private VqSFccEqDGfGMgdwzjgzGopfoSNj.BzpkqAlNnjifsUzvebxAiHHmeIi zQXeTvkzaeIpJIvsRefwjcjxlIL;

		private VqSFccEqDGfGMgdwzjgzGopfoSNj.DDdvrlpyFzimmHfZzxNowIasOxF bXmgMtiNsVBDsPGypVENWYGmWXE;

		private NativeBuffer HVzscHnlKSBBOPfXtLtOtahXtLN;

		private int MCcAWzyMIbbOjcGJhHzQQrTRAJae;

		public mSHayxXplcOvqbZUOGKLXuYftph()
		{
			zQXeTvkzaeIpJIvsRefwjcjxlIL = new VqSFccEqDGfGMgdwzjgzGopfoSNj.BzpkqAlNnjifsUzvebxAiHHmeIi
			{
				ZlwsNMmOwDtgQDskVCVzbvPohFF = (uint)Marshal.SizeOf(typeof(VqSFccEqDGfGMgdwzjgzGopfoSNj.BzpkqAlNnjifsUzvebxAiHHmeIi)),
				VdsBvUMNQkKoXKbokltaMqpxEew = true,
				AQxWTkCCzQknGcWWqrVRNXtILFh = true,
				yCrBsLUIbJGRTOOBndhvEwWRzZo = false,
				FyvtZIWfDgPZdQzAJeIeEIGcGAo = true,
				lbNblCPSPMZZkdYlduYWnqBVgqX = IntPtr.Zero
			};
			bXmgMtiNsVBDsPGypVENWYGmWXE = VqSFccEqDGfGMgdwzjgzGopfoSNj.DDdvrlpyFzimmHfZzxNowIasOxF.ZyDMIRfUdtdyWWZsNvkwCISqzBR();
			HVzscHnlKSBBOPfXtLtOtahXtLN = new NativeBuffer((int)bXmgMtiNsVBDsPGypVENWYGmWXE.ZlwsNMmOwDtgQDskVCVzbvPohFF);
			HVzscHnlKSBBOPfXtLtOtahXtLN.Write(bXmgMtiNsVBDsPGypVENWYGmWXE.ZlwsNMmOwDtgQDskVCVzbvPohFF, 0);
		}

		public bool BwFREbzdfgKduQeaCgaQHxjvyaO()
		{
			int num = VALpBlQZpCIluQnRYtVKkCgseExH();
			while (true)
			{
				int num2 = -1189658386;
				while (true)
				{
					switch (num2 ^ -1189658385)
					{
					case 0:
						break;
					case 1:
						if (num != MCcAWzyMIbbOjcGJhHzQQrTRAJae)
						{
							goto IL_0030;
						}
						return false;
					default:
						return true;
					}
					break;
					IL_0030:
					MCcAWzyMIbbOjcGJhHzQQrTRAJae = num;
					num2 = -1189658387;
				}
			}
		}

		public void xABdZUGeWdPbevGWLJZynCsVutbf(int P_0)
		{
			MCcAWzyMIbbOjcGJhHzQQrTRAJae = P_0;
		}

		private int VALpBlQZpCIluQnRYtVKkCgseExH()
		{
			try
			{
				return xJrcpabxFNJEeLKxzDoQfzegzEjy.IEXPmNlUXBsTuJqdeOElowtTGYY(ref zQXeTvkzaeIpJIvsRefwjcjxlIL, HVzscHnlKSBBOPfXtLtOtahXtLN);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum oqTDYwuZOTBrxUXrMkuLhLRueIm
	{
		UdOaQKIUzemBrlkcmDTMEJLHkeko = 17,
		ViWzCydCNFcFRKBZTpduMcxrfKx = 18,
		otHBHGZfzdEKPVeyweIkhCMmKxf = 19,
		pQWpfclEjkejclhuRDzKogfWgBcH = 20,
		egXeNSeaFVcDEGVdGFwVPDfpVJP = 21,
		aoGoUyaiHMwfuxRbqbGkOklUoAm = 22,
		MhHhUbWXLuJwFAbqgGXhslvNEzA = 23,
		kjOKXtUFpXEdIcIXoFsNGcNcKEpy = 24,
		JpabVLktmsjnNCilejKjbNFRquSX = 25,
		bqxBzjlNiMiRYWiJbFcDdddOPmTX = 26,
		MabqbKuWevMoVyORdldkrKPXWYr = 27,
		pyvdpuXityQyqgdgHicoldiXpOE = 28
	}

	private const IskHyHopihCGsdgjIPsutxCiveF meJCmTFsoANLuLZZHmvoVhaugAr = IskHyHopihCGsdgjIPsutxCiveF.TNdrxZxbRoPkNWPPGxlXjgafQDq;

	private const evIrXdYCByIHJkTsSgfSGumEcIq zJRJbxbZVCnDzZuepECawiFMPaL = evIrXdYCByIHJkTsSgfSGumEcIq.vEqNFZMOPsNUyDSXlJYQtKcHwKe;

	private IntPtr tgscWlofBLLBkdMeipMoaRDEnIt;

	private DirectInput cNHxqGeyXwmkWjUEDshlEWUZKRl;

	private List<MUlnPVcZgGLeXkhLihgLQlrmnHb> DhZbdMKNkujxkBYZovsLjyUUFhq;

	private int ySAWzXMlBDpuUMZJSTZdpLsLntr;

	private BLYKrQIleVekFbPYioNUeiFKybSN UMsKdJAzyaBSALboFULhgKARVjb;

	private bool MzMuQxRWFTqgMvAfuhFnZCjUPMq;

	private bool pyimnvsUyirvCGgwqkCsOmauCTw;

	private UpdateLoopSetting YkyQxaisDsFuOyVqgIcMTqgqosj;

	private Action<int, ControllerDataUpdater> NvqaCuAwnRtIQraiMLVUyKxjukSM;

	private PlatformInputManager PQcgLBxnvdIehjQoFUyCgOAdLDX;

	private TimerRealTime QyTJbpIQxqdJHCNiKQcoFeqrkmT;

	private global::ETrJCGYDLNaYoirFtJFXTwjRwgvl<bool> APFYhbxyKiosMFmWCfvqFsqArjE;

	private mSHayxXplcOvqbZUOGKLXuYftph dosBwdrnFtlAkXGomrkXReaFTMv;

	private int XDTvrHuNvhDCKopuzhbTaKeNvKz;

	private int ZlwwnjDXKpoFAgQHNxGSsItAJez;

	private global::ETrJCGYDLNaYoirFtJFXTwjRwgvl<List<MTODzdeeDWSBhpmBzjfrttsYwvJ>> bGpaBMieDdHAVIdvKMObQFtPsiSb;

	private readonly object VscpWqBWzuDusblaKBCJNvlmplv = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> qnewRYFCzYevHqfqyatlbQmZFOFg;

	private Func<int> faTqYhfgwuuVCbrIpddTkYZQAdf;

	public bool useXInput
	{
		set
		{
			pyimnvsUyirvCGgwqkCsOmauCTw = value;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount => ySAWzXMlBDpuUMZJSTZdpLsLntr;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => PQcgLBxnvdIehjQoFUyCgOAdLDX;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => new InputSourceWrapper<DirectInput>(cNHxqGeyXwmkWjUEDshlEWUZKRl);

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.DirectInput;

	public kPcCNnzXGURfWeRfxqXeAVfOFYx(UpdateLoopSetting updateLoopSetting, bool useXInput, IntPtr windowHandle, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		try
		{
			YkyQxaisDsFuOyVqgIcMTqgqosj = updateLoopSetting;
			pyimnvsUyirvCGgwqkCsOmauCTw = useXInput;
			tgscWlofBLLBkdMeipMoaRDEnIt = windowHandle;
			qnewRYFCzYevHqfqyatlbQmZFOFg = getHardwareJoystickMap_InputManager;
			faTqYhfgwuuVCbrIpddTkYZQAdf = getNewJoystickId;
			PQcgLBxnvdIehjQoFUyCgOAdLDX = this;
			cNHxqGeyXwmkWjUEDshlEWUZKRl = new DirectInput();
			NvqaCuAwnRtIQraiMLVUyKxjukSM = UpdateControllerData;
			dosBwdrnFtlAkXGomrkXReaFTMv = new mSHayxXplcOvqbZUOGKLXuYftph();
			APFYhbxyKiosMFmWCfvqFsqArjE = new global::ETrJCGYDLNaYoirFtJFXTwjRwgvl<bool>(useSharedThread: true, QdjFbhivHyWOJIdqVKGlvWgkVXXl);
			bGpaBMieDdHAVIdvKMObQFtPsiSb = new global::ETrJCGYDLNaYoirFtJFXTwjRwgvl<List<MTODzdeeDWSBhpmBzjfrttsYwvJ>>(useSharedThread: true, () => lRCtyzuYUBwHQVRCjrpoOmDXOdM());
			sxQxgCaJOgfjVojnunfaRwUvZWW();
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
		UMsKdJAzyaBSALboFULhgKARVjb = new BLYKrQIleVekFbPYioNUeiFKybSN();
		while (true)
		{
			int num = -2022297240;
			while (true)
			{
				switch (num ^ -2022297238)
				{
				case 0:
					break;
				case 2:
					goto IL_0029;
				default:
					QyTJbpIQxqdJHCNiKQcoFeqrkmT.Start();
					rvJbCjhLEVFbGnbXQDmddvVImia();
					return;
				}
				break;
				IL_0029:
				QyTJbpIQxqdJHCNiKQcoFeqrkmT = new TimerRealTime(1.0);
				num = -2022297237;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		JWvEXNrpTUEiGwLjrRCrZpfrsHV();
		mdMggEGjjzmtQQVNrFFxxhYpDZIA();
		mrpXieuHWEMeqScxLKfMAzfufkq();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (bGpaBMieDdHAVIdvKMObQFtPsiSb != null)
		{
			goto IL_0008;
		}
		goto IL_003c;
		IL_0008:
		int num = -681199906;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -681199905)
			{
			case 3:
				break;
			case 1:
				bGpaBMieDdHAVIdvKMObQFtPsiSb.WYoEhOBxiSjIYKwbsCHdGOUBXDbi();
				num = -681199905;
				continue;
			case 0:
				goto IL_003c;
			default:
				goto IL_0056;
			}
			break;
		}
		goto IL_0008;
		IL_003c:
		if (APFYhbxyKiosMFmWCfvqFsqArjE != null)
		{
			APFYhbxyKiosMFmWCfvqFsqArjE.WYoEhOBxiSjIYKwbsCHdGOUBXDbi();
			num = -681199907;
			goto IL_000d;
		}
		goto IL_0056;
		IL_0056:
		if (DhZbdMKNkujxkBYZovsLjyUUFhq == null)
		{
			return;
		}
		lock (VscpWqBWzuDusblaKBCJNvlmplv)
		{
			int num2 = 0;
			while (num2 < DhZbdMKNkujxkBYZovsLjyUUFhq.Count)
			{
				while (true)
				{
					int num3;
					if (DhZbdMKNkujxkBYZovsLjyUUFhq[num2] != null)
					{
						DhZbdMKNkujxkBYZovsLjyUUFhq[num2].UWOOMlZOWZtWbNikUvqswMufgfx();
						DhZbdMKNkujxkBYZovsLjyUUFhq[num2].WYoEhOBxiSjIYKwbsCHdGOUBXDbi();
						num3 = -681199906;
						goto IL_0077;
					}
					goto IL_00cb;
					IL_0077:
					while (true)
					{
						switch (num3 ^ -681199905)
						{
						case 3:
							num3 = -681199907;
							continue;
						case 2:
							break;
						case 1:
							goto IL_00cb;
						default:
							goto end_IL_0094;
						}
						break;
					}
					continue;
					IL_00cb:
					num2++;
					num3 = -681199905;
					goto IL_0077;
					continue;
					end_IL_0094:
					break;
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return NvqaCuAwnRtIQraiMLVUyKxjukSM;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (VscpWqBWzuDusblaKBCJNvlmplv)
		{
			int num = 0;
			while (true)
			{
				IL_000f:
				int num2 = 1479925028;
				while (true)
				{
					switch (num2 ^ 0x5835DD25)
					{
					case 0:
						break;
					case 1:
						num2 = 1479925030;
						continue;
					case 4:
						if (DhZbdMKNkujxkBYZovsLjyUUFhq[num].inputManagerId == inputManagerId)
						{
							DhZbdMKNkujxkBYZovsLjyUUFhq[num].FillData(data);
							return;
						}
						goto case 2;
					case 2:
						num++;
						num2 = 1479925030;
						continue;
					default:
						if (num >= ySAWzXMlBDpuUMZJSTZdpLsLntr)
						{
							goto end_IL_0014;
						}
						goto case 4;
					}
					goto IL_000f;
					continue;
					end_IL_0014:
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
		MzMuQxRWFTqgMvAfuhFnZCjUPMq = true;
		QyTJbpIQxqdJHCNiKQcoFeqrkmT.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		MzMuQxRWFTqgMvAfuhFnZCjUPMq = true;
		QyTJbpIQxqdJHCNiKQcoFeqrkmT.Start();
		while (true)
		{
			int num = -897044356;
			while (true)
			{
				switch (num ^ -897044355)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					if (_SystemDeviceDisconnectedEvent != null)
					{
						goto IL_0038;
					}
					return;
				case 0:
					return;
				}
				break;
				IL_0038:
				_SystemDeviceDisconnectedEvent();
				num = -897044355;
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

	private void JWvEXNrpTUEiGwLjrRCrZpfrsHV()
	{
		if (APFYhbxyKiosMFmWCfvqFsqArjE.isRunning)
		{
			if (!APFYhbxyKiosMFmWCfvqFsqArjE.uIPQYCOyPijpbHfLzGABZERoRaI())
			{
				return;
			}
			goto IL_005b;
		}
		goto IL_00d5;
		IL_00d5:
		int num;
		int num2;
		if (QyTJbpIQxqdJHCNiKQcoFeqrkmT.running)
		{
			num = 1049717949;
			num2 = num;
		}
		else
		{
			num = 1049717941;
			num2 = num;
		}
		goto IL_0023;
		IL_005b:
		if (!QyTJbpIQxqdJHCNiKQcoFeqrkmT.running)
		{
			int num3;
			if (bGpaBMieDdHAVIdvKMObQFtPsiSb.isRunning)
			{
				num = 1049717942;
				num3 = num;
			}
			else
			{
				num = 1049717943;
				num3 = num;
			}
			goto IL_0023;
		}
		return;
		IL_0023:
		while (true)
		{
			switch (num ^ 0x3E916CB4)
			{
			case 0:
				num = 1049717936;
				continue;
			default:
				return;
			case 4:
				break;
			case 7:
				return;
			case 9:
				if (QyTJbpIQxqdJHCNiKQcoFeqrkmT.Update())
				{
					APFYhbxyKiosMFmWCfvqFsqArjE.LgoJHLCBitFthTodNHJlYroGYaX();
					num = 1049717937;
					continue;
				}
				return;
			case 1:
				QyTJbpIQxqdJHCNiKQcoFeqrkmT.Start();
				return;
			case 2:
				return;
			case 6:
				goto IL_00d5;
			case 8:
				QyTJbpIQxqdJHCNiKQcoFeqrkmT.Start();
				num = 1049717939;
				continue;
			case 3:
				if (APFYhbxyKiosMFmWCfvqFsqArjE.result)
				{
					MzMuQxRWFTqgMvAfuhFnZCjUPMq = true;
					num = 1049717948;
					continue;
				}
				goto case 8;
			case 5:
				return;
			}
			break;
		}
		goto IL_005b;
	}

	private List<MTODzdeeDWSBhpmBzjfrttsYwvJ> lRCtyzuYUBwHQVRCjrpoOmDXOdM()
	{
		List<MTODzdeeDWSBhpmBzjfrttsYwvJ> list = new List<MTODzdeeDWSBhpmBzjfrttsYwvJ>();
		IList<wgrxsaianMUzjNMhgoWaIreVzBL> list2 = yDpaMbQMyacaoBayRlPRINTxosz();
		int count = list2.Count;
		int num2 = default(int);
		uRfjJqYedjnyNKOatXmscLaMEod uRfjJqYedjnyNKOatXmscLaMEod2 = default(uRfjJqYedjnyNKOatXmscLaMEod);
		LeCJloFoXFUHUhnitcWeFbdZJuMQ properties = default(LeCJloFoXFUHUhnitcWeFbdZJuMQ);
		bool flag2 = default(bool);
		Guid guid = default(Guid);
		int num5 = default(int);
		gtEJIADROaPpaMOJFZJWugVDQEh capabilities = default(gtEJIADROaPpaMOJFZJWugVDQEh);
		int num10 = default(int);
		while (true)
		{
			int num = 1490769372;
			while (true)
			{
				int num13;
				switch (num ^ 0x58DB55DD)
				{
				case 2:
					break;
				case 1:
					goto IL_0036;
				default:
					if (list2[num2] != null)
					{
						try
						{
							wgrxsaianMUzjNMhgoWaIreVzBL wgrxsaianMUzjNMhgoWaIreVzBL2 = list2[num2];
							Guid fLbAPKhMEOqiRPUIcmPSMKfdoXFf = wgrxsaianMUzjNMhgoWaIreVzBL2.fLbAPKhMEOqiRPUIcmPSMKfdoXFf;
							while (true)
							{
								IL_0069:
								int num3 = 1490769374;
								while (true)
								{
									switch (num3 ^ 0x58DB55DD)
									{
									case 2:
										break;
									case 3:
										uRfjJqYedjnyNKOatXmscLaMEod2 = new uRfjJqYedjnyNKOatXmscLaMEod(cNHxqGeyXwmkWjUEDshlEWUZKRl, fLbAPKhMEOqiRPUIcmPSMKfdoXFf);
										properties = uRfjJqYedjnyNKOatXmscLaMEod2.Properties;
										num3 = 1490769373;
										continue;
									case 0:
										flag2 = false;
										if (pyimnvsUyirvCGgwqkCsOmauCTw)
										{
											flag2 = zzOqSwMfghlPxHdUtRXPrOVahKl.MaQsCwUpHxzwhotZWnHQMwdFcRm(properties.InterfacePath, StringTools.SanitizeDeviceString(wgrxsaianMUzjNMhgoWaIreVzBL2.RYOaUKbYPbbwfMvGNTmVLpcYUKiJ), string.Empty, wgrxsaianMUzjNMhgoWaIreVzBL2.aLPdymjdjgZVToEjdiKgEjmkAGsd);
											if (flag2)
											{
												goto end_IL_006e;
											}
										}
										goto case 4;
									case 4:
										guid = ((!string.IsNullOrEmpty(properties.InterfacePath)) ? MiscTools.CreateGuidHashSHA256(properties.InterfacePath) : wgrxsaianMUzjNMhgoWaIreVzBL2.fLbAPKhMEOqiRPUIcmPSMKfdoXFf);
										num3 = 1490769372;
										continue;
									default:
									{
										bool flag = false;
										lock (VscpWqBWzuDusblaKBCJNvlmplv)
										{
											if (DhZbdMKNkujxkBYZovsLjyUUFhq != null)
											{
												while (true)
												{
													IL_0140:
													int num4 = 1490769374;
													while (true)
													{
														switch (num4 ^ 0x58DB55DD)
														{
														case 2:
															break;
														default:
															goto end_IL_0145;
														case 0:
														{
															int num6;
															if (num5 < DhZbdMKNkujxkBYZovsLjyUUFhq.Count)
															{
																num4 = 1490769368;
																num6 = num4;
															}
															else
															{
																num4 = 1490769369;
																num6 = num4;
															}
															continue;
														}
														case 5:
															if (DhZbdMKNkujxkBYZovsLjyUUFhq[num5] != null && DhZbdMKNkujxkBYZovsLjyUUFhq[num5].duuMMyqFfJAeBAlnwwCpaWGlBUgO == guid)
															{
																uRfjJqYedjnyNKOatXmscLaMEod2 = DhZbdMKNkujxkBYZovsLjyUUFhq[num5].bBSBxriglpnOAawkfBpKCJgyYmdh.LMofllDVwkfLxnRkZcSVHJPEQcuP;
																flag = true;
																num4 = 1490769369;
																continue;
															}
															goto case 1;
														case 1:
															num5++;
															num4 = 1490769373;
															continue;
														case 3:
															num5 = 0;
															num4 = 1490769373;
															continue;
														case 4:
															goto end_IL_0145;
														}
														goto IL_0140;
														continue;
														end_IL_0145:
														break;
													}
													break;
												}
											}
										}
										MUlnPVcZgGLeXkhLihgLQlrmnHb mUlnPVcZgGLeXkhLihgLQlrmnHb = new MUlnPVcZgGLeXkhLihgLQlrmnHb(new IPQPLNMoyLRdmrBDMONOOacSFFX(uRfjJqYedjnyNKOatXmscLaMEod2, YkyQxaisDsFuOyVqgIcMTqgqosj), qnewRYFCzYevHqfqyatlbQmZFOFg);
										while (true)
										{
											IL_021e:
											int num7 = 1490769369;
											while (true)
											{
												switch (num7 ^ 0x58DB55DD)
												{
												case 3:
													break;
												case 4:
													mUlnPVcZgGLeXkhLihgLQlrmnHb.pBDqZeaDGlqHjIwWxDonvqdrIAY = wgrxsaianMUzjNMhgoWaIreVzBL2;
													mUlnPVcZgGLeXkhLihgLQlrmnHb.vhbvSIyRvLTNKIdHyehnSxBQFBz = wgrxsaianMUzjNMhgoWaIreVzBL2.DKTIiZLwFgIcnpxQUbmslAavAke;
													mUlnPVcZgGLeXkhLihgLQlrmnHb.duuMMyqFfJAeBAlnwwCpaWGlBUgO = guid;
													mUlnPVcZgGLeXkhLihgLQlrmnHb.DVaqHcutoHoUrPluDMMcnunKAGA = StringTools.SanitizeDeviceString(wgrxsaianMUzjNMhgoWaIreVzBL2.RYOaUKbYPbbwfMvGNTmVLpcYUKiJ);
													mUlnPVcZgGLeXkhLihgLQlrmnHb.jswiKSoBCTxrqereFiOojDxDRmw = wgrxsaianMUzjNMhgoWaIreVzBL2.aLPdymjdjgZVToEjdiKgEjmkAGsd;
													num7 = 1490769373;
													continue;
												case 2:
													capabilities = uRfjJqYedjnyNKOatXmscLaMEod2.Capabilities;
													num7 = 1490769372;
													continue;
												case 0:
													mUlnPVcZgGLeXkhLihgLQlrmnHb.rrfmJyUDkKMJIxIelilHFVjRKUAM = (oqTDYwuZOTBrxUXrMkuLhLRueIm)wgrxsaianMUzjNMhgoWaIreVzBL2.Type;
													num7 = 1490769375;
													continue;
												default:
													mUlnPVcZgGLeXkhLihgLQlrmnHb.sEJsjYepUiBfnYUEFbfTIGbRtAM = properties.ProductId;
													mUlnPVcZgGLeXkhLihgLQlrmnHb.XWJGdtiTCNTQbkDNDyOHMuyHxoJn = flag2;
													try
													{
														mUlnPVcZgGLeXkhLihgLQlrmnHb.zuIOHHSFjUvtYoHqYbOkIVnjKLJ = properties.JoystickId;
													}
													catch (Exception)
													{
														mUlnPVcZgGLeXkhLihgLQlrmnHb.zuIOHHSFjUvtYoHqYbOkIVnjKLJ = 0;
													}
													mUlnPVcZgGLeXkhLihgLQlrmnHb.qhBaQiBUaifpRBvldoZTqTDFPFqY = capabilities.eHqVTTnoWONLuTmQhFlYaaGJPWQ;
													while (true)
													{
														IL_02f4:
														int num8 = 1490769372;
														while (true)
														{
															IList<JgrAyYzRNsNStAtAQACKYutyEqZ> list3;
															int num9;
															switch (num8 ^ 0x58DB55DD)
															{
															case 2:
																break;
															case 1:
																goto IL_0312;
															default:
																{
																	mUlnPVcZgGLeXkhLihgLQlrmnHb.QQactFjAyaivYJCKROwerenGIZRE = capabilities.RjoZHcePaCPaCPeeaIUkayftKuuE;
																	zRraAnqlOuzhDwGYLqzXNdGDhoV(mUlnPVcZgGLeXkhLihgLQlrmnHb, properties, out mUlnPVcZgGLeXkhLihgLQlrmnHb.vhYYOxGmghVJJPAGQjILaUdlbckp);
																	try
																	{
																		string productName;
																		try
																		{
																			productName = properties.ProductName;
																		}
																		catch
																		{
																			productName = mUlnPVcZgGLeXkhLihgLQlrmnHb.DVaqHcutoHoUrPluDMMcnunKAGA;
																		}
																		if (SpecialDevices.RequiresRelativeToAbsoluteAxisConversion((ushort)properties.VendorId, (ushort)properties.ProductId, productName) && SpecialDevices.GetRelativeAxisRanges((ushort)properties.VendorId, (ushort)properties.ProductId, productName, out var min, out var max, out var zero))
																		{
																			mUlnPVcZgGLeXkhLihgLQlrmnHb.bBSBxriglpnOAawkfBpKCJgyYmdh.UQOCMATWiDVinKWymBwUECQZzsL(min, max, zero, SpecialDevices.GetRelativeToAbsoluteAxisEventTimeout((ushort)properties.VendorId, (ushort)properties.ProductId, productName));
																		}
																	}
																	catch (Exception)
																	{
																	}
																	if (!flag)
																	{
																		list3 = uRfjJqYedjnyNKOatXmscLaMEod2.QLLjThQGZuidgqwQMaTRkuNILyc();
																		if (list3 != null)
																		{
																			goto IL_03d7;
																		}
																		goto IL_0419;
																	}
																	goto IL_04bc;
																}
																IL_03d7:
																num9 = 1490769369;
																goto IL_03dc;
																IL_04bc:
																list.Add(new MTODzdeeDWSBhpmBzjfrttsYwvJ(mUlnPVcZgGLeXkhLihgLQlrmnHb, wgrxsaianMUzjNMhgoWaIreVzBL2));
																goto end_IL_02f9;
																IL_0419:
																uRfjJqYedjnyNKOatXmscLaMEod2.Properties.AxisMode = YYlSxTyGRYkLUcclICPyLGIvAgWg.RwBYIjhNoZaJHvhVqbilEFbJRgeG;
																uRfjJqYedjnyNKOatXmscLaMEod2.aDoaFXAJWDDeKAHAUpxIoHCvkFuh(tgscWlofBLLBkdMeipMoaRDEnIt, tNvnfAcFPXLRdDiGtmkVucUKOAm.UgQwSOPHMaJHwOVYMIENyJfUWvz | tNvnfAcFPXLRdDiGtmkVucUKOAm.DWHhTXTMVtczyJQWnuIqvicMmkl);
																uRfjJqYedjnyNKOatXmscLaMEod2.HyqAXbAgFcqWiYfxZzBDTyqsqlp();
																num9 = 1490769375;
																goto IL_03dc;
																IL_03dc:
																while (true)
																{
																	switch (num9 ^ 0x58DB55DD)
																	{
																	case 3:
																		break;
																	case 6:
																		num10++;
																		num9 = 1490769368;
																		continue;
																	case 1:
																		goto IL_0419;
																	case 4:
																		num10 = 0;
																		num9 = 1490769368;
																		continue;
																	case 0:
																		uRfjJqYedjnyNKOatXmscLaMEod2.Properties.Range = new ELudhPQnpNtNEUxylcvRblXOZYj(-65535, 65535);
																		num9 = 1490769371;
																		continue;
																	case 7:
																		goto IL_0472;
																	case 5:
																		goto IL_049d;
																	default:
																		goto IL_04bc;
																	}
																	break;
																	IL_049d:
																	int num11;
																	if (num10 < list3.Count)
																	{
																		num9 = 1490769370;
																		num11 = num9;
																	}
																	else
																	{
																		num9 = 1490769372;
																		num11 = num9;
																	}
																	continue;
																	IL_0472:
																	int num12;
																	if ((list3[num10].YObdiQomXCqOUjUXYVwDlWGQSVZ.Flags & lXAXFkMOntMikfBMvxfdIESZBAu.ShcAsuFQzXMtIcHOiAmAJSxdfJk) == 0)
																	{
																		num9 = 1490769371;
																		num12 = num9;
																	}
																	else
																	{
																		num9 = 1490769373;
																		num12 = num9;
																	}
																}
																goto IL_03d7;
															}
															goto IL_02f4;
															IL_0312:
															mUlnPVcZgGLeXkhLihgLQlrmnHb.lenAIRsoOFqjBdbpibHDlBXGVmR = capabilities.iwqiuNdLxBKiEAtVaetmnxLuWYk;
															num8 = 1490769373;
															continue;
															end_IL_02f9:
															break;
														}
														break;
													}
													goto end_IL_0223;
												}
												goto IL_021e;
												continue;
												end_IL_0223:
												break;
											}
											break;
										}
										goto end_IL_006e;
									}
									}
									goto IL_0069;
									continue;
									end_IL_006e:
									break;
								}
								break;
							}
						}
						catch (Exception)
						{
						}
					}
					num2++;
					goto IL_04d4;
				case 0:
					goto IL_04f2;
					IL_04f2:
					if (num2 < count)
					{
						goto default;
					}
					num13 = 1490769375;
					goto IL_04d9;
					IL_04d9:
					switch (num13 ^ 0x58DB55DD)
					{
					case 0:
						break;
					case 1:
						goto IL_04f2;
					default:
						return list;
					}
					goto IL_04d4;
					IL_04d4:
					num13 = 1490769372;
					goto IL_04d9;
				}
				break;
				IL_0036:
				num2 = 0;
				num = 1490769373;
			}
		}
	}

	private void rvJbCjhLEVFbGnbXQDmddvVImia()
	{
		EnYCyLqREbfTHjoVSJqRAAPFngib(lRCtyzuYUBwHQVRCjrpoOmDXOdM());
	}

	private void EnYCyLqREbfTHjoVSJqRAAPFngib(List<MTODzdeeDWSBhpmBzjfrttsYwvJ> P_0)
	{
		List<MUlnPVcZgGLeXkhLihgLQlrmnHb> list = new List<MUlnPVcZgGLeXkhLihgLQlrmnHb>();
		XDTvrHuNvhDCKopuzhbTaKeNvKz = 0;
		int num = P_0?.Count ?? 0;
		int num2 = 0;
		int num7 = default(int);
		int count = default(int);
		while (true)
		{
			if (num2 < num)
			{
				if (P_0[num2] != null && P_0[num2].IsValid)
				{
					try
					{
						MUlnPVcZgGLeXkhLihgLQlrmnHb aUIdfqdotGKPVLbiMbUhWyorbHfX = P_0[num2].AUIdfqdotGKPVLbiMbUhWyorbHfX;
						aUIdfqdotGKPVLbiMbUhWyorbHfX.jDkVEgygiHHntkZXtjEwiSihtux();
						while (true)
						{
							IL_004b:
							int num3 = 1834729253;
							while (true)
							{
								switch (num3 ^ 0x6D5BBF24)
								{
								case 2:
									break;
								case 1:
								{
									int num4;
									if (!aUIdfqdotGKPVLbiMbUhWyorbHfX.MVCWNUJrDWfwziBxuAuBAzgJAhiF)
									{
										num3 = 1834729252;
										num4 = num3;
									}
									else
									{
										num3 = 1834729255;
										num4 = num3;
									}
									continue;
								}
								case 3:
									XDTvrHuNvhDCKopuzhbTaKeNvKz++;
									num3 = 1834729252;
									continue;
								default:
									list.Add(aUIdfqdotGKPVLbiMbUhWyorbHfX);
									goto end_IL_0050;
								}
								goto IL_004b;
								continue;
								end_IL_0050:
								break;
							}
							break;
						}
					}
					catch (Exception)
					{
					}
				}
				num2++;
				goto IL_00ab;
			}
			dosBwdrnFtlAkXGomrkXReaFTMv.xABdZUGeWdPbevGWLJZynCsVutbf(XDTvrHuNvhDCKopuzhbTaKeNvKz);
			int num5 = 1834729254;
			goto IL_00b0;
			IL_00ab:
			num5 = 1834729253;
			goto IL_00b0;
			IL_00b0:
			switch (num5 ^ 0x6D5BBF24)
			{
			case 0:
				break;
			case 1:
				continue;
			default:
				lock (VscpWqBWzuDusblaKBCJNvlmplv)
				{
					List<MUlnPVcZgGLeXkhLihgLQlrmnHb> dhZbdMKNkujxkBYZovsLjyUUFhq = DhZbdMKNkujxkBYZovsLjyUUFhq;
					while (true)
					{
						int num6 = 1834729253;
						while (true)
						{
							switch (num6 ^ 0x6D5BBF24)
							{
							case 0:
								break;
							case 3:
								num7++;
								num6 = 1834729254;
								continue;
							case 4:
								if (_UpdateControllerInfoEvent != null)
								{
									_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[num7]));
									num6 = 1834729255;
									continue;
								}
								goto case 3;
							case 1:
							{
								int num8 = ySAWzXMlBDpuUMZJSTZdpLsLntr;
								count = list.Count;
								ViJmTrtaYTomRaMXivkMijSGBsTd(num8, count, dhZbdMKNkujxkBYZovsLjyUUFhq, list);
								num7 = 0;
								num6 = 1834729254;
								continue;
							}
							default:
								if (num7 >= count)
								{
									QNAqfgEMQhqzfWLjYkRwnnHWNmc(dhZbdMKNkujxkBYZovsLjyUUFhq, list, false);
									QNAqfgEMQhqzfWLjYkRwnnHWNmc(list, dhZbdMKNkujxkBYZovsLjyUUFhq, true);
									SnNgYIpPZAfKEtqYSwjVKshNUGn(list, dhZbdMKNkujxkBYZovsLjyUUFhq);
									DhZbdMKNkujxkBYZovsLjyUUFhq = list;
									ySAWzXMlBDpuUMZJSTZdpLsLntr = list.Count;
									return;
								}
								goto case 4;
							}
							break;
						}
					}
				}
			}
			goto IL_00ab;
		}
	}

	private void zRraAnqlOuzhDwGYLqzXNdGDhoV(MUlnPVcZgGLeXkhLihgLQlrmnHb P_0, LeCJloFoXFUHUhnitcWeFbdZJuMQ P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = fTvFFMKHyahmXrAOzQxsmenVpjI.bAsiNcmvQWMiTuiNtHATkYhgXzTP(P_1.InterfacePath);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			awBDVVAQrVojolizTQZQDabqRnX awBDVVAQrVojolizTQZQDabqRnX2 = xJrcpabxFNJEeLKxzDoQfzegzEjy.BgZQongBWtTKfmsnbdiKVLLtyaY(text.ToLower(CultureInfo.InvariantCulture));
			if (awBDVVAQrVojolizTQZQDabqRnX2 != null)
			{
				P_0.MVCWNUJrDWfwziBxuAuBAzgJAhiF = awBDVVAQrVojolizTQZQDabqRnX2.IsBluetoothDevice;
				P_0.OWynlsqwgASivUcmwQTMqEbSEpd = awBDVVAQrVojolizTQZQDabqRnX2.BluetoothDeviceName;
				P_2 = YdyMnIcwNBPdrenZBGWhZdOBHpZh.BBWmVDZLrNTNlSFMsavKfXDvmGqa(awBDVVAQrVojolizTQZQDabqRnX2, P_0.jswiKSoBCTxrqereFiOojDxDRmw, P_0.DVaqHcutoHoUrPluDMMcnunKAGA, P_0.OWynlsqwgASivUcmwQTMqEbSEpd);
				awBDVVAQrVojolizTQZQDabqRnX2.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void mrpXieuHWEMeqScxLKfMAzfufkq()
	{
		lock (VscpWqBWzuDusblaKBCJNvlmplv)
		{
			for (int i = 0; i < ySAWzXMlBDpuUMZJSTZdpLsLntr; i++)
			{
				try
				{
					MUlnPVcZgGLeXkhLihgLQlrmnHb mUlnPVcZgGLeXkhLihgLQlrmnHb = DhZbdMKNkujxkBYZovsLjyUUFhq[i];
					while (true)
					{
						IL_0021:
						int num = -101487637;
						while (true)
						{
							switch (num ^ -101487638)
							{
							case 2:
								break;
							case 1:
								if (mUlnPVcZgGLeXkhLihgLQlrmnHb == null)
								{
									goto end_IL_0026;
								}
								goto case 4;
							case 0:
								if (mUlnPVcZgGLeXkhLihgLQlrmnHb.XWJGdtiTCNTQbkDNDyOHMuyHxoJn)
								{
									goto end_IL_0026;
								}
								goto default;
							case 5:
							{
								int num2;
								if (pyimnvsUyirvCGgwqkCsOmauCTw)
								{
									num = -101487638;
									num2 = num;
								}
								else
								{
									num = -101487639;
									num2 = num;
								}
								continue;
							}
							case 4:
								if (!mUlnPVcZgGLeXkhLihgLQlrmnHb.BooOvjDDXJCPvNBIKejrMetJcRQF())
								{
									goto end_IL_0026;
								}
								goto case 5;
							default:
								mUlnPVcZgGLeXkhLihgLQlrmnHb.Update();
								goto end_IL_0026;
							}
							goto IL_0021;
							continue;
							end_IL_0026:
							break;
						}
						break;
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<wgrxsaianMUzjNMhgoWaIreVzBL> yDpaMbQMyacaoBayRlPRINTxosz()
	{
		try
		{
			IList<wgrxsaianMUzjNMhgoWaIreVzBL> devices = cNHxqGeyXwmkWjUEDshlEWUZKRl.GetDevices(IskHyHopihCGsdgjIPsutxCiveF.TNdrxZxbRoPkNWPPGxlXjgafQDq, evIrXdYCByIHJkTsSgfSGumEcIq.vEqNFZMOPsNUyDSXlJYQtKcHwKe);
			ZlwwnjDXKpoFAgQHNxGSsItAJez = devices?.Count ?? 0;
			return devices;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			ZlwwnjDXKpoFAgQHNxGSsItAJez = 0;
			return EmptyObjects<wgrxsaianMUzjNMhgoWaIreVzBL>.EmptyReadOnlyIListT;
		}
	}

	private void sxQxgCaJOgfjVojnunfaRwUvZWW()
	{
		cNHxqGeyXwmkWjUEDshlEWUZKRl.GetDevices();
	}

	private void ViJmTrtaYTomRaMXivkMijSGBsTd(int P_0, int P_1, List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_2, List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(MUlnPVcZgGLeXkhLihgLQlrmnHb.WqhqgptTseHqhChjsCbwEEjWkdx);
			goto IL_001a;
		}
		goto IL_00ab;
		IL_00ab:
		bool flag = P_0 > 0 && P_1 > 0;
		int num = -349379339;
		goto IL_001f;
		IL_001a:
		num = -349379334;
		goto IL_001f;
		IL_001f:
		MUlnPVcZgGLeXkhLihgLQlrmnHb mUlnPVcZgGLeXkhLihgLQlrmnHb = default(MUlnPVcZgGLeXkhLihgLQlrmnHb);
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -349379342)
			{
			case 0:
				break;
			default:
				return;
			case 9:
				HUXcFuUWtJIwxJKGbYwyPfpEvbr(P_1, P_3, P_0, P_2, BLYKrQIleVekFbPYioNUeiFKybSN.cBKHAZGZFmCVFrxIEiUKPNqKoqKX.afFbgEzNXvGvvGsLKuJIIflFbruT);
				num = -349379340;
				continue;
			case 7:
				goto IL_006e;
			case 10:
				UMsKdJAzyaBSALboFULhgKARVjb.kVadApUnAEuOWsMMZXVNAURVCZW(mUlnPVcZgGLeXkhLihgLQlrmnHb);
				num = -349379341;
				continue;
			case 6:
				FqLDQLawGkiWwPbgSVXafbrXgsoF(P_1, P_3, BLYKrQIleVekFbPYioNUeiFKybSN.cBKHAZGZFmCVFrxIEiUKPNqKoqKX.afFbgEzNXvGvvGsLKuJIIflFbruT);
				num2 = 0;
				num = -349379344;
				continue;
			case 8:
				goto IL_00ab;
			case 2:
				if (num2 >= P_1)
				{
					P_3.Sort(MUlnPVcZgGLeXkhLihgLQlrmnHb.hAhbefRdJZmHXDjWxMDZzJoyxdd);
					num = -349379338;
					continue;
				}
				goto case 3;
			case 3:
				mUlnPVcZgGLeXkhLihgLQlrmnHb = P_3[num2];
				if (mUlnPVcZgGLeXkhLihgLQlrmnHb != null && mUlnPVcZgGLeXkhLihgLQlrmnHb.inputManagerId < 0)
				{
					mUlnPVcZgGLeXkhLihgLQlrmnHb.inputManagerId = kljZIvnOWqRsmwSbuwsBhIvvLbR(P_3);
					num = -349379337;
					continue;
				}
				goto case 1;
			case 1:
				num2++;
				num = -349379344;
				continue;
			case 5:
				mUlnPVcZgGLeXkhLihgLQlrmnHb.rewiredId = faTqYhfgwuuVCbrIpddTkYZQAdf();
				num = -349379336;
				continue;
			case 4:
				return;
			}
			break;
			IL_006e:
			int num3;
			if (!flag)
			{
				num = -349379340;
				num3 = num;
			}
			else
			{
				num = -349379333;
				num3 = num;
			}
		}
		goto IL_001a;
	}

	private void gxkqtQMMgQbzFEECEFPoGZzcjBLy(List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2 = 325730924;
			while (true)
			{
				switch (num2 ^ 0x136A426F)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					num2 = 325730923;
					continue;
				case 4:
				{
					int num3;
					if (num < count)
					{
						num2 = 325730922;
						num3 = num2;
					}
					else
					{
						num2 = 325730927;
						num3 = num2;
					}
					continue;
				}
				case 5:
					if (num != P_1 && P_0[num] != null && P_0[num].inputManagerId == P_2)
					{
						P_0[num].inputManagerId = -1;
						num2 = 325730926;
						continue;
					}
					goto case 1;
				case 1:
					num++;
					num2 = 325730923;
					continue;
				case 0:
					return;
				}
				break;
			}
		}
	}

	private bool gwFYeeaoDMFEdccEhpkZULzuLlR(List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_0, int P_1)
	{
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2 = -1286602595;
			while (true)
			{
				switch (num2 ^ -1286602593)
				{
				case 0:
					break;
				case 2:
					num2 = -1286602597;
					continue;
				case 1:
					if (P_0[num].inputManagerId == P_1)
					{
						num2 = -1286602598;
						continue;
					}
					goto IL_0062;
				case 3:
					if (P_0[num] != null)
					{
						num2 = -1286602594;
						continue;
					}
					goto IL_0062;
				case 5:
					return false;
				default:
					{
						if (num >= count)
						{
							return true;
						}
						goto case 3;
					}
					IL_0062:
					num++;
					num2 = -1286602597;
					continue;
				}
				break;
			}
		}
	}

	private int kljZIvnOWqRsmwSbuwsBhIvvLbR(List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_0)
	{
		int num = 0;
		bool flag = default(bool);
		int count = default(int);
		int num3 = default(int);
		while (true)
		{
			int num2 = 1519514728;
			while (true)
			{
				switch (num2 ^ 0x5A91F46C)
				{
				case 7:
					break;
				case 4:
					flag = false;
					count = P_0.Count;
					num3 = 0;
					num2 = 1519514734;
					continue;
				case 0:
					if (P_0[num3].inputManagerId == num)
					{
						flag = true;
						num2 = 1519514735;
						continue;
					}
					goto case 1;
				case 6:
				{
					int num5;
					if (P_0[num3] != null)
					{
						num2 = 1519514732;
						num5 = num2;
					}
					else
					{
						num2 = 1519514733;
						num5 = num2;
					}
					continue;
				}
				case 3:
					if (!flag)
					{
						num2 = 1519514729;
						continue;
					}
					num++;
					goto case 4;
				case 2:
				{
					int num4;
					if (num3 < count)
					{
						num2 = 1519514730;
						num4 = num2;
					}
					else
					{
						num2 = 1519514735;
						num4 = num2;
					}
					continue;
				}
				case 1:
					num3++;
					num2 = 1519514734;
					continue;
				default:
					return num;
				}
				break;
			}
		}
	}

	private bool oEQKpQzPwfllmCXbyvwZIGacQVo(List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			int num2 = 1753102114;
			while (true)
			{
				switch (num2 ^ 0x687E3721)
				{
				case 2:
					break;
				case 3:
					num2 = 1753102112;
					continue;
				case 0:
					if (P_0[num].rewiredId == P_1)
					{
						return true;
					}
					num++;
					num2 = 1753102112;
					continue;
				default:
					if (num >= P_0.Count)
					{
						return false;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	private void HUXcFuUWtJIwxJKGbYwyPfpEvbr(int P_0, List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_1, int P_2, List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_3, BLYKrQIleVekFbPYioNUeiFKybSN.cBKHAZGZFmCVFrxIEiUKPNqKoqKX P_4)
	{
		int num = ((P_4 != BLYKrQIleVekFbPYioNUeiFKybSN.cBKHAZGZFmCVFrxIEiUKPNqKoqKX.afFbgEzNXvGvvGsLKuJIIflFbruT) ? 1 : 2);
		int num2 = 0;
		MUlnPVcZgGLeXkhLihgLQlrmnHb mUlnPVcZgGLeXkhLihgLQlrmnHb2 = default(MUlnPVcZgGLeXkhLihgLQlrmnHb);
		MUlnPVcZgGLeXkhLihgLQlrmnHb mUlnPVcZgGLeXkhLihgLQlrmnHb = default(MUlnPVcZgGLeXkhLihgLQlrmnHb);
		int num5 = default(int);
		while (true)
		{
			int num3;
			int num4;
			if (num2 < P_0)
			{
				num3 = 1586828428;
				num4 = num3;
			}
			else
			{
				num3 = 1586828431;
				num4 = num3;
			}
			while (true)
			{
				switch (num3 ^ 0x5E95148D)
				{
				case 0:
					num3 = 1586828428;
					continue;
				default:
					return;
				case 9:
					break;
				case 3:
					if (mUlnPVcZgGLeXkhLihgLQlrmnHb2 != null && !oEQKpQzPwfllmCXbyvwZIGacQVo(P_1, mUlnPVcZgGLeXkhLihgLQlrmnHb2.rewiredId))
					{
						int num7;
						if (mUlnPVcZgGLeXkhLihgLQlrmnHb.FcvkUyKypZmJCfGSpczJhAaNNjEx(mUlnPVcZgGLeXkhLihgLQlrmnHb2) >= num)
						{
							num3 = 1586828427;
							num7 = num3;
						}
						else
						{
							num3 = 1586828422;
							num7 = num3;
						}
						continue;
					}
					goto case 11;
				case 7:
				{
					int num8;
					if (num5 >= P_2)
					{
						num3 = 1586828423;
						num8 = num3;
					}
					else
					{
						num3 = 1586828424;
						num8 = num3;
					}
					continue;
				}
				case 8:
					if (mUlnPVcZgGLeXkhLihgLQlrmnHb != null)
					{
						int num6;
						if (mUlnPVcZgGLeXkhLihgLQlrmnHb.inputManagerId >= 0)
						{
							num3 = 1586828423;
							num6 = num3;
						}
						else
						{
							num3 = 1586828425;
							num6 = num3;
						}
						continue;
					}
					goto case 10;
				case 4:
					num5 = 0;
					num3 = 1586828426;
					continue;
				case 1:
					mUlnPVcZgGLeXkhLihgLQlrmnHb = P_1[num2];
					num3 = 1586828421;
					continue;
				case 10:
					num2++;
					num3 = 1586828420;
					continue;
				case 5:
					mUlnPVcZgGLeXkhLihgLQlrmnHb2 = P_3[num5];
					num3 = 1586828430;
					continue;
				case 6:
					mUlnPVcZgGLeXkhLihgLQlrmnHb.laWNKiWcrSexnZtRRPyPhNqRVNc(mUlnPVcZgGLeXkhLihgLQlrmnHb2);
					UMsKdJAzyaBSALboFULhgKARVjb.kVadApUnAEuOWsMMZXVNAURVCZW(mUlnPVcZgGLeXkhLihgLQlrmnHb);
					num3 = 1586828422;
					continue;
				case 11:
					num5++;
					num3 = 1586828426;
					continue;
				case 2:
					return;
				}
				break;
			}
		}
	}

	private void FqLDQLawGkiWwPbgSVXafbrXgsoF(int P_0, List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_1, BLYKrQIleVekFbPYioNUeiFKybSN.cBKHAZGZFmCVFrxIEiUKPNqKoqKX P_2)
	{
		int num = 0;
		BLYKrQIleVekFbPYioNUeiFKybSN.VGiukJbsdARxicCNzWoewCuHLIV vGiukJbsdARxicCNzWoewCuHLIV = default(BLYKrQIleVekFbPYioNUeiFKybSN.VGiukJbsdARxicCNzWoewCuHLIV);
		BLYKrQIleVekFbPYioNUeiFKybSN.VGiukJbsdARxicCNzWoewCuHLIV current = default(BLYKrQIleVekFbPYioNUeiFKybSN.VGiukJbsdARxicCNzWoewCuHLIV);
		int num5 = default(int);
		while (num < P_0)
		{
			MUlnPVcZgGLeXkhLihgLQlrmnHb mUlnPVcZgGLeXkhLihgLQlrmnHb = P_1[num];
			if (mUlnPVcZgGLeXkhLihgLQlrmnHb != null && mUlnPVcZgGLeXkhLihgLQlrmnHb.inputManagerId < 0)
			{
				vGiukJbsdARxicCNzWoewCuHLIV = null;
				using (IEnumerator<BLYKrQIleVekFbPYioNUeiFKybSN.VGiukJbsdARxicCNzWoewCuHLIV> enumerator = UMsKdJAzyaBSALboFULhgKARVjb.joccDsvMkbNqtLkAGboThijYbVO(mUlnPVcZgGLeXkhLihgLQlrmnHb, P_2).GetEnumerator())
				{
					while (true)
					{
						IL_0063:
						int num2;
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = 578187681;
							num3 = num2;
						}
						else
						{
							num2 = 578187685;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x227671A4)
							{
							case 3:
								num2 = 578187685;
								continue;
							default:
								goto end_IL_003e;
							case 0:
								break;
							case 2:
								if (current.RgyPfpfFQwdoJNiBIXrQsaliAnP >= 0)
								{
									vGiukJbsdARxicCNzWoewCuHLIV = current;
									num2 = 578187681;
									continue;
								}
								break;
							case 4:
							{
								int num4;
								if (oEQKpQzPwfllmCXbyvwZIGacQVo(P_1, current.VGSrrWYLNAwIbrYoUwvzVCxXdRzc))
								{
									num2 = 578187684;
									num4 = num2;
								}
								else
								{
									num2 = 578187686;
									num4 = num2;
								}
								continue;
							}
							case 1:
								current = enumerator.Current;
								num2 = 578187680;
								continue;
							case 5:
								goto end_IL_003e;
							}
							goto IL_0063;
							continue;
							end_IL_003e:
							break;
						}
						break;
					}
				}
				if (vGiukJbsdARxicCNzWoewCuHLIV != null)
				{
					num5 = vGiukJbsdARxicCNzWoewCuHLIV.RgyPfpfFQwdoJNiBIXrQsaliAnP;
					if (!gwFYeeaoDMFEdccEhpkZULzuLlR(P_1, num5))
					{
						num5 = (vGiukJbsdARxicCNzWoewCuHLIV.RgyPfpfFQwdoJNiBIXrQsaliAnP = kljZIvnOWqRsmwSbuwsBhIvvLbR(P_1));
						goto IL_00f3;
					}
					goto IL_0115;
				}
			}
			goto IL_013c;
			IL_0115:
			mUlnPVcZgGLeXkhLihgLQlrmnHb.inputManagerId = num5;
			mUlnPVcZgGLeXkhLihgLQlrmnHb.rewiredId = vGiukJbsdARxicCNzWoewCuHLIV.VGSrrWYLNAwIbrYoUwvzVCxXdRzc;
			UMsKdJAzyaBSALboFULhgKARVjb.kVadApUnAEuOWsMMZXVNAURVCZW(mUlnPVcZgGLeXkhLihgLQlrmnHb);
			int num6 = 578187684;
			goto IL_00f8;
			IL_00f3:
			num6 = 578187685;
			goto IL_00f8;
			IL_013c:
			num++;
			num6 = 578187687;
			goto IL_00f8;
			IL_00f8:
			switch (num6 ^ 0x227671A4)
			{
			case 2:
				break;
			case 1:
				goto IL_0115;
			case 0:
				goto IL_013c;
			default:
				continue;
			}
			goto IL_00f3;
		}
	}

	private void mdMggEGjjzmtQQVNrFFxxhYpDZIA()
	{
		if (MzMuQxRWFTqgMvAfuhFnZCjUPMq)
		{
			CxmVMvQkajwTqrDzartmooWUzWu();
			goto IL_000e;
		}
		goto IL_002c;
		IL_002c:
		int num;
		if (bGpaBMieDdHAVIdvKMObQFtPsiSb.isRunning && bGpaBMieDdHAVIdvKMObQFtPsiSb.uIPQYCOyPijpbHfLzGABZERoRaI())
		{
			DMCTVklVuaMMWNhSreqsObOptgT(bGpaBMieDdHAVIdvKMObQFtPsiSb.result);
			num = 2052293763;
			goto IL_0013;
		}
		return;
		IL_000e:
		num = 2052293762;
		goto IL_0013;
		IL_0013:
		switch (num ^ 0x7A538483)
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

	private void CxmVMvQkajwTqrDzartmooWUzWu()
	{
		MzMuQxRWFTqgMvAfuhFnZCjUPMq = false;
		if (bGpaBMieDdHAVIdvKMObQFtPsiSb.isRunning)
		{
			goto IL_0014;
		}
		goto IL_003e;
		IL_0014:
		int num = -554121801;
		goto IL_0019;
		IL_0019:
		switch (num ^ -554121804)
		{
		case 0:
			break;
		default:
			return;
		case 3:
			return;
		case 2:
			goto IL_003e;
		case 1:
			return;
		}
		goto IL_0014;
		IL_003e:
		bGpaBMieDdHAVIdvKMObQFtPsiSb.LgoJHLCBitFthTodNHJlYroGYaX();
		num = -554121803;
		goto IL_0019;
	}

	private void DMCTVklVuaMMWNhSreqsObOptgT(List<MTODzdeeDWSBhpmBzjfrttsYwvJ> P_0)
	{
		if (!uiZVLTRAQmHuNjHshitfwEPawrk(MTODzdeeDWSBhpmBzjfrttsYwvJ.HidJxImGvXQqyvpukZQivzqoHpD(P_0)))
		{
			return;
		}
		while (true)
		{
			int num = -888602941;
			while (true)
			{
				switch (num ^ -888602943)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_002c;
				case 1:
					return;
				}
				break;
				IL_002c:
				EnYCyLqREbfTHjoVSJqRAAPFngib(P_0);
				num = -888602944;
			}
		}
	}

	private bool uiZVLTRAQmHuNjHshitfwEPawrk(IList<wgrxsaianMUzjNMhgoWaIreVzBL> P_0)
	{
		lock (VscpWqBWzuDusblaKBCJNvlmplv)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !nbmciSAlDSdytTnfmLWpviEBliTd(P_0[i].fLbAPKhMEOqiRPUIcmPSMKfdoXFf))
				{
					return true;
				}
			}
			int count2 = DhZbdMKNkujxkBYZovsLjyUUFhq.Count;
			for (int j = 0; j < count2; j++)
			{
				if (DhZbdMKNkujxkBYZovsLjyUUFhq[j] != null && !WIuHAzptWodiXNDYRqDNuIenjew(P_0, DhZbdMKNkujxkBYZovsLjyUUFhq[j].instanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool nbmciSAlDSdytTnfmLWpviEBliTd(Guid P_0)
	{
		lock (VscpWqBWzuDusblaKBCJNvlmplv)
		{
			int count = DhZbdMKNkujxkBYZovsLjyUUFhq.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					if (DhZbdMKNkujxkBYZovsLjyUUFhq[num] != null && DhZbdMKNkujxkBYZovsLjyUUFhq[num].instanceGuid == P_0)
					{
						return true;
					}
					while (true)
					{
						IL_0071:
						num++;
						int num2 = 1030572058;
						while (true)
						{
							switch (num2 ^ 0x3D6D481A)
							{
							case 2:
								num2 = 1030572059;
								continue;
							case 1:
								break;
							case 3:
								goto IL_0071;
							default:
								goto end_IL_003f;
							}
							break;
						}
						break;
					}
					continue;
					end_IL_003f:
					break;
				}
			}
		}
		return false;
	}

	private bool WIuHAzptWodiXNDYRqDNuIenjew(IList<wgrxsaianMUzjNMhgoWaIreVzBL> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].fLbAPKhMEOqiRPUIcmPSMKfdoXFf == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void QNAqfgEMQhqzfWLjYkRwnnHWNmc(List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_0, List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num3 = default(int);
		int num5 = default(int);
		MUlnPVcZgGLeXkhLihgLQlrmnHb mUlnPVcZgGLeXkhLihgLQlrmnHb2 = default(MUlnPVcZgGLeXkhLihgLQlrmnHb);
		MUlnPVcZgGLeXkhLihgLQlrmnHb mUlnPVcZgGLeXkhLihgLQlrmnHb = default(MUlnPVcZgGLeXkhLihgLQlrmnHb);
		bool flag = default(bool);
		int num7 = default(int);
		int num6 = default(int);
		while (true)
		{
			IL_013c:
			int num;
			if (P_0 == null)
			{
				num = 1250106349;
				goto IL_000c;
			}
			int num2 = P_0.Count;
			goto IL_0162;
			IL_0159:
			num2 = 0;
			goto IL_0162;
			IL_0101:
			int num4;
			num3 = num4;
			num = 1250106345;
			goto IL_000c;
			IL_0162:
			num5 = num2;
			if (P_1 != null)
			{
				num4 = P_1.Count;
				goto IL_0101;
			}
			num = 1250106343;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ 0x4A831BEE)
				{
				case 14:
					num = 1250106366;
					continue;
				default:
					return;
				case 5:
					if (mUlnPVcZgGLeXkhLihgLQlrmnHb2.instanceGuid == mUlnPVcZgGLeXkhLihgLQlrmnHb.instanceGuid)
					{
						flag = true;
						num = 1250106367;
						continue;
					}
					goto case 1;
				case 15:
					if (P_1 != null)
					{
						num7 = 0;
						num = 1250106350;
						continue;
					}
					goto IL_010c;
				case 10:
					break;
				case 12:
					mUlnPVcZgGLeXkhLihgLQlrmnHb2 = P_0[num6];
					if (mUlnPVcZgGLeXkhLihgLQlrmnHb2 != null)
					{
						flag = false;
						num = 1250106337;
						continue;
					}
					goto case 6;
				case 2:
					goto IL_00cc;
				case 4:
					mUlnPVcZgGLeXkhLihgLQlrmnHb = P_1[num7];
					num = 1250106341;
					continue;
				case 9:
					goto end_IL_000c;
				case 17:
					goto IL_010c;
				case 11:
					goto IL_0124;
				case 16:
					goto IL_013c;
				case 1:
					num7++;
					num = 1250106340;
					continue;
				case 3:
					goto IL_0159;
				case 0:
					num = 1250106340;
					continue;
				case 7:
					num6 = 0;
					num = 1250106348;
					continue;
				case 6:
					num6++;
					num = 1250106348;
					continue;
				case 13:
					wHkejOBKyruymhvApBBfcXZjNmgH(P_0[num6], P_2);
					num = 1250106344;
					continue;
				case 8:
					return;
				}
				int num8;
				if (num7 < num3)
				{
					num = 1250106346;
					num8 = num;
				}
				else
				{
					num = 1250106367;
					num8 = num;
				}
				continue;
				IL_0124:
				int num9;
				if (mUlnPVcZgGLeXkhLihgLQlrmnHb == null)
				{
					num = 1250106351;
					num9 = num;
				}
				else
				{
					num = 1250106347;
					num9 = num;
				}
				continue;
				IL_00cc:
				int num10;
				if (num6 < num5)
				{
					num = 1250106338;
					num10 = num;
				}
				else
				{
					num = 1250106342;
					num10 = num;
				}
				continue;
				IL_010c:
				int num11;
				if (flag)
				{
					num = 1250106344;
					num11 = num;
				}
				else
				{
					num = 1250106339;
					num11 = num;
				}
				continue;
				end_IL_000c:
				break;
			}
			num4 = 0;
			goto IL_0101;
		}
	}

	private void wHkejOBKyruymhvApBBfcXZjNmgH(MUlnPVcZgGLeXkhLihgLQlrmnHb P_0, bool P_1)
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
			num = 1924181217;
			goto IL_0010;
		}
		return;
		IL_000b:
		num = 1924181220;
		goto IL_0010;
		IL_0010:
		while (true)
		{
			switch (num ^ 0x72B0ACE5)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				_DeviceConnectedEvent(P_0.ToBridgedController());
				num = 1924181222;
				continue;
			case 3:
				return;
			case 0:
				goto IL_0051;
			case 4:
				return;
			}
			break;
		}
		goto IL_000b;
	}

	private bool QdjFbhivHyWOJIdqVKGlvWgkVXXl()
	{
		int num = cNHxqGeyXwmkWjUEDshlEWUZKRl.GetDeviceCount(IskHyHopihCGsdgjIPsutxCiveF.TNdrxZxbRoPkNWPPGxlXjgafQDq, evIrXdYCByIHJkTsSgfSGumEcIq.vEqNFZMOPsNUyDSXlJYQtKcHwKe);
		while (true)
		{
			int num2 = -621484249;
			while (true)
			{
				switch (num2 ^ -621484251)
				{
				case 0:
					break;
				case 2:
					if (ZlwwnjDXKpoFAgQHNxGSsItAJez != num)
					{
						num2 = -621484250;
						continue;
					}
					if (XDTvrHuNvhDCKopuzhbTaKeNvKz > 0 && dosBwdrnFtlAkXGomrkXReaFTMv.BwFREbzdfgKduQeaCgaQHxjvyaO())
					{
						num2 = -621484252;
						continue;
					}
					return false;
				case 3:
					ZlwwnjDXKpoFAgQHNxGSsItAJez = num;
					return true;
				default:
					return true;
				}
				break;
			}
		}
	}

	private void SnNgYIpPZAfKEtqYSwjVKshNUGn(List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_0, List<MUlnPVcZgGLeXkhLihgLQlrmnHb> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = 791227835;
			while (true)
			{
				switch (num2 ^ 0x2F292DBD)
				{
				case 5:
					num2 = 791227833;
					continue;
				default:
					return;
				case 4:
					break;
				case 8:
					num++;
					num2 = 791227839;
					continue;
				case 1:
					if (P_1[num] != null)
					{
						int num4;
						if (P_0 != null)
						{
							num2 = 791227838;
							num4 = num2;
						}
						else
						{
							num2 = 791227834;
							num4 = num2;
						}
						continue;
					}
					goto case 8;
				case 3:
				{
					int num5;
					if (P_0.Contains(P_1[num]))
					{
						num2 = 791227829;
						num5 = num2;
					}
					else
					{
						num2 = 791227834;
						num5 = num2;
					}
					continue;
				}
				case 7:
					P_1[num].WYoEhOBxiSjIYKwbsCHdGOUBXDbi();
					num2 = 791227829;
					continue;
				case 2:
				{
					int num3;
					if (num >= P_1.Count)
					{
						num2 = 791227837;
						num3 = num2;
					}
					else
					{
						num2 = 791227836;
						num3 = num2;
					}
					continue;
				}
				case 6:
					num2 = 791227839;
					continue;
				case 0:
					return;
				}
				break;
			}
		}
	}

	[Conditional("DEBUGTHIS")]
	private void GNdfrTAopLHigBkrmDIuQQdtIMHd(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<MTODzdeeDWSBhpmBzjfrttsYwvJ> cyjRCVaFXwEvVZDyrfgKBTUahuSP()
	{
		return lRCtyzuYUBwHQVRCjrpoOmDXOdM();
	}
}
