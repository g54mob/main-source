using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class sbGjBSYUCHFmdsRwzJKaaHSDFDN
{
	public class XcptJhlTgQIGzCasSfEIjpeEciij
	{
		public readonly Action<InputActionEventData> msVVRWbCGXIWrzOwJDAXLVPEHPw;

		public readonly UpdateLoopType NigWaDmPBoxUjERAcsoKpawNrzS;

		public readonly InputActionEventType OXfLFmAwdXNeXCDfjaMaASYRzGDW;

		public readonly int hDvAMaTqLegLZzPsyeYTryTcCaC;

		public readonly bool PytaBgpnAjToMZLNhYEbjxjQifL;

		public float[] aNHdEofSCJBXKQQCKkUwFmvnelNU;

		public XcptJhlTgQIGzCasSfEIjpeEciij(Action<InputActionEventData> @delegate, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			NigWaDmPBoxUjERAcsoKpawNrzS = updateLoop;
			OXfLFmAwdXNeXCDfjaMaASYRzGDW = eventType;
			hDvAMaTqLegLZzPsyeYTryTcCaC = actionId;
			msVVRWbCGXIWrzOwJDAXLVPEHPw = @delegate;
			YgKgedzNcAJdSEuSckhsheAXHpI(arguments);
			switch (eventType)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				PytaBgpnAjToMZLNhYEbjxjQifL = true;
				break;
			}
		}

		public bool wlbeybGmQVTuONNZlgtfcVvqOjYH(int P_0, out float P_1)
		{
			if (aNHdEofSCJBXKQQCKkUwFmvnelNU == null || aNHdEofSCJBXKQQCKkUwFmvnelNU.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = aNHdEofSCJBXKQQCKkUwFmvnelNU[P_0];
			return true;
		}

		private void YgKgedzNcAJdSEuSckhsheAXHpI(object[] P_0)
		{
			InputActionEventType oXfLFmAwdXNeXCDfjaMaASYRzGDW = OXfLFmAwdXNeXCDfjaMaASYRzGDW;
			if (oXfLFmAwdXNeXCDfjaMaASYRzGDW <= InputActionEventType.NegativeButtonPressedForTimeJustReleased)
			{
				goto IL_000f;
			}
			goto IL_019e;
			IL_000f:
			int num = 1420261689;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num ^ 0x54A77923)
				{
				case 23:
					break;
				default:
					return;
				case 8:
					throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", OXfLFmAwdXNeXCDfjaMaASYRzGDW, "\". Argument 0 (optional): time [float]"));
				case 6:
					goto IL_00be;
				case 9:
					throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", OXfLFmAwdXNeXCDfjaMaASYRzGDW, "\". Argument 0: time [float]"));
				case 21:
					throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", OXfLFmAwdXNeXCDfjaMaASYRzGDW, "\". Argument 1 (optional): expireIn [float]"));
				case 2:
					if (P_0[0] is int)
					{
						aNHdEofSCJBXKQQCKkUwFmvnelNU[0] = (int)P_0[0];
						return;
					}
					goto case 8;
				case 4:
					goto IL_0159;
				case 20:
					goto IL_0180;
				case 5:
					goto IL_019e;
				case 0:
					throw new Exception(string.Concat("Wrong number of arguments passed for Input event type \"", OXfLFmAwdXNeXCDfjaMaASYRzGDW, "\". 1 required argument: time [float], 1 optional argument: expireIn [float]"));
				case 12:
					if (P_0 == null)
					{
						goto case 0;
					}
					goto IL_01ef;
				case 3:
					aNHdEofSCJBXKQQCKkUwFmvnelNU = new float[1];
					if (P_0[0] is float)
					{
						aNHdEofSCJBXKQQCKkUwFmvnelNU[0] = (float)P_0[0];
						num = 1420261678;
						continue;
					}
					goto case 2;
				case 24:
					throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", OXfLFmAwdXNeXCDfjaMaASYRzGDW, "\". Argument 0: time [float]"));
				case 15:
					return;
				case 1:
					goto IL_0271;
				case 26:
					switch (oXfLFmAwdXNeXCDfjaMaASYRzGDW)
					{
					case InputActionEventType.ButtonPressedForTime:
					case InputActionEventType.ButtonPressedForTimeJustReleased:
					case InputActionEventType.NegativeButtonPressedForTime:
					case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
						break;
					default:
						return;
					case InputActionEventType.ButtonDoublePressed:
					case InputActionEventType.ButtonJustDoublePressed:
					case InputActionEventType.NegativeButtonDoublePressed:
					case InputActionEventType.NegativeButtonJustDoublePressed:
						goto IL_03cc;
					case InputActionEventType.ButtonJustPressedForTime:
					case InputActionEventType.NegativeButtonJustPressedForTime:
						goto IL_0408;
					}
					goto case 12;
				case 27:
					return;
				case 19:
					aNHdEofSCJBXKQQCKkUwFmvnelNU = new float[2];
					if (P_0[0] is float)
					{
						aNHdEofSCJBXKQQCKkUwFmvnelNU[0] = (float)P_0[0];
						num = 1420261671;
						continue;
					}
					goto IL_0271;
				case 13:
					return;
				case 25:
					aNHdEofSCJBXKQQCKkUwFmvnelNU[0] = (int)P_0[0];
					return;
				case 10:
					aNHdEofSCJBXKQQCKkUwFmvnelNU = new float[1];
					if (P_0[0] is float)
					{
						aNHdEofSCJBXKQQCKkUwFmvnelNU[0] = (float)P_0[0];
						return;
					}
					goto IL_00be;
				case 17:
					aNHdEofSCJBXKQQCKkUwFmvnelNU[0] = (int)P_0[0];
					num = 1420261671;
					continue;
				case 16:
					throw new Exception(string.Concat("Wrong number of arguments passed for Input event type \"", OXfLFmAwdXNeXCDfjaMaASYRzGDW, "\". Requires 1 argument: time [float]"));
				case 22:
					aNHdEofSCJBXKQQCKkUwFmvnelNU[1] = (float)P_0[1];
					return;
				case 14:
					goto IL_03cc;
				case 11:
					aNHdEofSCJBXKQQCKkUwFmvnelNU[1] = (int)P_0[1];
					return;
				case 7:
					goto IL_0408;
				case 18:
					return;
					IL_0408:
					if (P_0 == null)
					{
						goto case 16;
					}
					goto IL_040e;
				}
				break;
				IL_040e:
				int num2;
				if (P_0.Length >= 1)
				{
					num = 1420261673;
					num2 = num;
				}
				else
				{
					num = 1420261683;
					num2 = num;
				}
				continue;
				IL_01ef:
				int num3;
				if (P_0.Length >= 1)
				{
					num = 1420261680;
					num3 = num;
				}
				else
				{
					num = 1420261667;
					num3 = num;
				}
				continue;
				IL_0180:
				int num4;
				if (!(P_0[1] is int))
				{
					num = 1420261686;
					num4 = num;
				}
				else
				{
					num = 1420261672;
					num4 = num;
				}
				continue;
				IL_0271:
				int num5;
				if (P_0[0] is int)
				{
					num = 1420261682;
					num5 = num;
				}
				else
				{
					num = 1420261674;
					num5 = num;
				}
				continue;
				IL_0159:
				if (P_0.Length > 1)
				{
					int num6;
					if (!(P_0[1] is float))
					{
						num = 1420261687;
						num6 = num;
					}
					else
					{
						num = 1420261685;
						num6 = num;
					}
					continue;
				}
				return;
				IL_00be:
				int num7;
				if (!(P_0[0] is int))
				{
					num = 1420261691;
					num7 = num;
				}
				else
				{
					num = 1420261690;
					num7 = num;
				}
			}
			goto IL_000f;
			IL_019e:
			if (oXfLFmAwdXNeXCDfjaMaASYRzGDW != InputActionEventType.ButtonDoublePressJustReleased)
			{
				int num8;
				if (oXfLFmAwdXNeXCDfjaMaASYRzGDW != InputActionEventType.NegativeButtonDoublePressJustReleased)
				{
					num = 1420261688;
					num8 = num;
				}
				else
				{
					num = 1420261677;
					num8 = num;
				}
				goto IL_0014;
			}
			goto IL_03cc;
			IL_03cc:
			if (P_0 == null)
			{
				return;
			}
			int num9;
			if (P_0.Length < 1)
			{
				num = 1420261676;
				num9 = num;
			}
			else
			{
				num = 1420261664;
				num9 = num;
			}
			goto IL_0014;
		}
	}

	private sealed class MQDboqAtCWIWMhBKOwZZikFXhAIY
	{
		public Action<InputActionEventData> msVVRWbCGXIWrzOwJDAXLVPEHPw;

		public bool esVGshaGhyoCEukaJQcJHDoddzWT(XcptJhlTgQIGzCasSfEIjpeEciij P_0)
		{
			return P_0.msVVRWbCGXIWrzOwJDAXLVPEHPw == msVVRWbCGXIWrzOwJDAXLVPEHPw;
		}
	}

	private sealed class PhRxOfKQWBZVygPTmapgRXKLqOT
	{
		public Action<InputActionEventData> msVVRWbCGXIWrzOwJDAXLVPEHPw;

		public int hDvAMaTqLegLZzPsyeYTryTcCaC;

		public bool SCxISEwHaoQgrQYVDzblCCzwYhd(XcptJhlTgQIGzCasSfEIjpeEciij P_0)
		{
			if (P_0.msVVRWbCGXIWrzOwJDAXLVPEHPw == msVVRWbCGXIWrzOwJDAXLVPEHPw)
			{
				return P_0.hDvAMaTqLegLZzPsyeYTryTcCaC == hDvAMaTqLegLZzPsyeYTryTcCaC;
			}
			return false;
		}
	}

	private sealed class NdncbyBTqpIlocYgEDqjMCQZLhE
	{
		public Action<InputActionEventData> msVVRWbCGXIWrzOwJDAXLVPEHPw;

		public UpdateLoopType NigWaDmPBoxUjERAcsoKpawNrzS;

		public bool GCPrkevIhPyvsRqUzLkXrfcDhxq(XcptJhlTgQIGzCasSfEIjpeEciij P_0)
		{
			if (P_0.msVVRWbCGXIWrzOwJDAXLVPEHPw == msVVRWbCGXIWrzOwJDAXLVPEHPw)
			{
				return P_0.NigWaDmPBoxUjERAcsoKpawNrzS == NigWaDmPBoxUjERAcsoKpawNrzS;
			}
			return false;
		}
	}

	private sealed class RpLCMjclLfXWvEVRMOLpIuykYPCa
	{
		public Action<InputActionEventData> msVVRWbCGXIWrzOwJDAXLVPEHPw;

		public InputActionEventType OXfLFmAwdXNeXCDfjaMaASYRzGDW;

		public bool ZwCXoNIuTOhkplBdguiyqgjwZSz(XcptJhlTgQIGzCasSfEIjpeEciij P_0)
		{
			if (P_0.msVVRWbCGXIWrzOwJDAXLVPEHPw == msVVRWbCGXIWrzOwJDAXLVPEHPw)
			{
				return P_0.OXfLFmAwdXNeXCDfjaMaASYRzGDW == OXfLFmAwdXNeXCDfjaMaASYRzGDW;
			}
			return false;
		}
	}

	private sealed class OUUCGiuCBWiNFevjKDhFWmqKEaCf
	{
		public Action<InputActionEventData> msVVRWbCGXIWrzOwJDAXLVPEHPw;

		public UpdateLoopType NigWaDmPBoxUjERAcsoKpawNrzS;

		public int hDvAMaTqLegLZzPsyeYTryTcCaC;

		public bool BSvTzgpfaRUkxyRAekvCCSXAFQ(XcptJhlTgQIGzCasSfEIjpeEciij P_0)
		{
			if (P_0.msVVRWbCGXIWrzOwJDAXLVPEHPw == msVVRWbCGXIWrzOwJDAXLVPEHPw && P_0.NigWaDmPBoxUjERAcsoKpawNrzS == NigWaDmPBoxUjERAcsoKpawNrzS)
			{
				return P_0.hDvAMaTqLegLZzPsyeYTryTcCaC == hDvAMaTqLegLZzPsyeYTryTcCaC;
			}
			return false;
		}
	}

	private sealed class ppydnYiXDvXxRJXlOparSYpqVQJ
	{
		public Action<InputActionEventData> msVVRWbCGXIWrzOwJDAXLVPEHPw;

		public UpdateLoopType NigWaDmPBoxUjERAcsoKpawNrzS;

		public InputActionEventType OXfLFmAwdXNeXCDfjaMaASYRzGDW;

		public int hDvAMaTqLegLZzPsyeYTryTcCaC;

		public bool eJlhlxYdblazZlhjpGNACQnAJKGA(XcptJhlTgQIGzCasSfEIjpeEciij P_0)
		{
			if (P_0.msVVRWbCGXIWrzOwJDAXLVPEHPw == msVVRWbCGXIWrzOwJDAXLVPEHPw && P_0.NigWaDmPBoxUjERAcsoKpawNrzS == NigWaDmPBoxUjERAcsoKpawNrzS)
			{
				while (true)
				{
					int num = -1791464243;
					while (true)
					{
						switch (num ^ -1791464241)
						{
						case 0:
							break;
						case 2:
							goto IL_003f;
						default:
							return P_0.OXfLFmAwdXNeXCDfjaMaASYRzGDW == OXfLFmAwdXNeXCDfjaMaASYRzGDW;
						}
						break;
						IL_003f:
						if (P_0.hDvAMaTqLegLZzPsyeYTryTcCaC != hDvAMaTqLegLZzPsyeYTryTcCaC)
						{
							goto end_IL_0021;
						}
						num = -1791464242;
					}
					continue;
					end_IL_0021:
					break;
				}
			}
			return false;
		}
	}

	private sealed class xImSPJjdQeeUJHgiKgrADuxcpAs
	{
		public Action<InputActionEventData> msVVRWbCGXIWrzOwJDAXLVPEHPw;

		public UpdateLoopType NigWaDmPBoxUjERAcsoKpawNrzS;

		public InputActionEventType OXfLFmAwdXNeXCDfjaMaASYRzGDW;

		public bool tbQueRjKhTpVLsQNwyxKjCShEjn(XcptJhlTgQIGzCasSfEIjpeEciij P_0)
		{
			if (P_0.msVVRWbCGXIWrzOwJDAXLVPEHPw == msVVRWbCGXIWrzOwJDAXLVPEHPw && P_0.NigWaDmPBoxUjERAcsoKpawNrzS == NigWaDmPBoxUjERAcsoKpawNrzS)
			{
				return P_0.OXfLFmAwdXNeXCDfjaMaASYRzGDW == OXfLFmAwdXNeXCDfjaMaASYRzGDW;
			}
			return false;
		}
	}

	private sealed class YBMdQyEDKNNmrcWegEpneJwkQMAY
	{
		public Action<InputActionEventData> msVVRWbCGXIWrzOwJDAXLVPEHPw;

		public InputActionEventType OXfLFmAwdXNeXCDfjaMaASYRzGDW;

		public int hDvAMaTqLegLZzPsyeYTryTcCaC;

		public bool piYZMUKEXpuLXUURoReyQfmSGDm(XcptJhlTgQIGzCasSfEIjpeEciij P_0)
		{
			if (P_0.msVVRWbCGXIWrzOwJDAXLVPEHPw == msVVRWbCGXIWrzOwJDAXLVPEHPw && P_0.hDvAMaTqLegLZzPsyeYTryTcCaC == hDvAMaTqLegLZzPsyeYTryTcCaC)
			{
				return P_0.OXfLFmAwdXNeXCDfjaMaASYRzGDW == OXfLFmAwdXNeXCDfjaMaASYRzGDW;
			}
			return false;
		}
	}

	private bool fxzgZHdorylahBrNCBxmuceoqOgc;

	private AList<XcptJhlTgQIGzCasSfEIjpeEciij>[] yUZGGyfDunsfBGZQUVHzNLqAQcV;

	private int[] tnNMLXfmfdwEcMdqxEvXcEmGPgf;

	private int NtGMTHHlPgVRVSzUWcygMcyybxc;

	public int PwXHtiwRLoynEJlcjliQaMRCQlr;

	[CompilerGenerated]
	private static Func<AList<XcptJhlTgQIGzCasSfEIjpeEciij>> autMBJdbnRzwuaphYbdbvPoQqzm;

	private void dFyvOnKBbTYzKLbxHBbiIGdcrpeH()
	{
		if (fxzgZHdorylahBrNCBxmuceoqOgc)
		{
			return;
		}
		int num2 = default(int);
		int num3 = default(int);
		while (true)
		{
			IList<InputAction> actions = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.Actions;
			int num = -973412067;
			while (true)
			{
				int num4;
				switch (num ^ -973412066)
				{
				case 9:
					num = -973412065;
					continue;
				default:
					return;
				case 6:
					tnNMLXfmfdwEcMdqxEvXcEmGPgf[actions[num2].id] = num2;
					num = -973412069;
					continue;
				case 0:
					num = -973412074;
					continue;
				case 10:
					yUZGGyfDunsfBGZQUVHzNLqAQcV = new AList<XcptJhlTgQIGzCasSfEIjpeEciij>[num3 + 1];
					tnNMLXfmfdwEcMdqxEvXcEmGPgf = new int[ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.maxActionId + 1];
					ArrayTools.Populate(yUZGGyfDunsfBGZQUVHzNLqAQcV, 0, yUZGGyfDunsfBGZQUVHzNLqAQcV.Length, () => new AList<XcptJhlTgQIGzCasSfEIjpeEciij>());
					num2 = 0;
					num = -973412066;
					continue;
				case 3:
					if (actions == null)
					{
						num = -973412070;
						continue;
					}
					num4 = actions.Count;
					goto IL_00e7;
				case 4:
					num4 = 0;
					goto IL_00e7;
				case 7:
					fxzgZHdorylahBrNCBxmuceoqOgc = true;
					num = -973412068;
					continue;
				case 1:
					break;
				case 5:
					num2++;
					num = -973412074;
					continue;
				case 8:
					if (num2 >= num3)
					{
						NtGMTHHlPgVRVSzUWcygMcyybxc = num3;
						num = -973412071;
						continue;
					}
					goto case 6;
				case 2:
					return;
					IL_00e7:
					num3 = num4;
					num = -973412076;
					continue;
				}
				break;
			}
		}
	}

	public void gPcrsTnkkceDCRqbBGlMPDCzcFT(CvKbBDBykgOtczqdWEjAImsohWR P_0, UpdateLoopType P_1)
	{
		AList<XcptJhlTgQIGzCasSfEIjpeEciij> aList = yUZGGyfDunsfBGZQUVHzNLqAQcV[tnNMLXfmfdwEcMdqxEvXcEmGPgf[P_0.ZUoDkTcclUigIzTjeFLCXFMQOaU]];
		int num = 0;
		bool flag = default(bool);
		XcptJhlTgQIGzCasSfEIjpeEciij xcptJhlTgQIGzCasSfEIjpeEciij = default(XcptJhlTgQIGzCasSfEIjpeEciij);
		float num8 = default(float);
		float num9 = default(float);
		int num5 = default(int);
		InputActionEventType oXfLFmAwdXNeXCDfjaMaASYRzGDW = default(InputActionEventType);
		float num6 = default(float);
		float num3 = default(float);
		int count = default(int);
		while (num < 2)
		{
			while (true)
			{
				IL_0acd:
				int num2;
				if (num == 1)
				{
					aList = yUZGGyfDunsfBGZQUVHzNLqAQcV[NtGMTHHlPgVRVSzUWcygMcyybxc];
					num2 = -1361704089;
					goto IL_0021;
				}
				goto IL_05c6;
				IL_0021:
				while (true)
				{
					float num4;
					float num7;
					float num11;
					float num13;
					float num14;
					float num16;
					int num17;
					float num18;
					float num19;
					float num20;
					switch (num2 ^ -1361704105)
					{
					case 40:
						num2 = -1361704190;
						continue;
					case 54:
						if (P_0.hXCuaxWdNcueYQiGLdDrJSdNZAIM())
						{
							num2 = -1361704127;
							continue;
						}
						goto case 0;
					case 7:
						goto IL_01b9;
					case 18:
						goto IL_01d6;
					case 64:
						goto IL_01f3;
					case 49:
						goto IL_022c;
					case 13:
						goto IL_024e;
					case 63:
						flag = true;
						goto case 0;
					case 81:
						goto IL_027d;
					case 57:
						goto IL_02a7;
					case 70:
						goto IL_02bc;
					case 46:
						goto IL_02d4;
					case 9:
						goto IL_02f1;
					case 27:
						goto IL_030e;
					case 79:
						goto IL_0338;
					case 84:
						if (xcptJhlTgQIGzCasSfEIjpeEciij.hDvAMaTqLegLZzPsyeYTryTcCaC < 0)
						{
							goto case 33;
						}
						if (xcptJhlTgQIGzCasSfEIjpeEciij.hDvAMaTqLegLZzPsyeYTryTcCaC == P_0.ZUoDkTcclUigIzTjeFLCXFMQOaU)
						{
							num2 = -1361704074;
							continue;
						}
						goto IL_0b52;
					case 16:
						goto IL_038d;
					case 82:
						goto IL_03b9;
					case 43:
						flag = true;
						num2 = -1361704103;
						continue;
					case 59:
						goto IL_0430;
					case 30:
						goto IL_045c;
					case 71:
						if (xcptJhlTgQIGzCasSfEIjpeEciij.NigWaDmPBoxUjERAcsoKpawNrzS == P_1)
						{
							num2 = -1361704189;
							continue;
						}
						goto IL_0b52;
					case 80:
						flag = true;
						goto case 0;
					case 51:
						goto IL_04a2;
					case 83:
						goto IL_04b7;
					case 52:
						goto IL_04e1;
					case 29:
						goto IL_051c;
					case 68:
						goto IL_0531;
					case 74:
						goto IL_054e;
					case 36:
						if (P_0.WMiTTwIKzyDqbfPtkXAZnODLxCJw(num8, num9))
						{
							num2 = -1361704115;
							continue;
						}
						goto case 0;
					case 21:
						num5 = 0;
						num2 = -1361704080;
						continue;
					case 45:
						goto IL_0588;
					case 67:
						goto IL_059d;
					case 48:
						break;
					case 87:
						oXfLFmAwdXNeXCDfjaMaASYRzGDW = xcptJhlTgQIGzCasSfEIjpeEciij.OXfLFmAwdXNeXCDfjaMaASYRzGDW;
						num2 = -1361704083;
						continue;
					case 35:
						goto IL_05f9;
					case 86:
						goto IL_0616;
					case 11:
						flag = true;
						num2 = -1361704086;
						continue;
					case 6:
						goto IL_0645;
					case 50:
						flag = true;
						goto case 0;
					case 73:
						goto IL_0664;
					case 66:
						flag = true;
						num2 = -1361704104;
						continue;
					case 20:
						goto IL_0686;
					case 75:
						flag = true;
						goto case 0;
					case 42:
						xcptJhlTgQIGzCasSfEIjpeEciij = aList._items[num5];
						if (xcptJhlTgQIGzCasSfEIjpeEciij != null)
						{
							goto IL_06be;
						}
						goto IL_0b52;
					case 37:
						goto IL_06e9;
					case 62:
						goto IL_06fe;
					case 53:
						if (P_0.XdNeOHquIhupqYJaJiORbbtHbhq(num6))
						{
							flag = true;
						}
						goto case 0;
					case 77:
						goto IL_0732;
					case 24:
						goto IL_075c;
					case 78:
						goto IL_077e;
					case 76:
						goto IL_07b9;
					case 3:
						if (xcptJhlTgQIGzCasSfEIjpeEciij.PytaBgpnAjToMZLNhYEbjxjQifL)
						{
							num2 = -1361704176;
							continue;
						}
						goto IL_0b52;
					case 58:
						switch (oXfLFmAwdXNeXCDfjaMaASYRzGDW)
						{
						case InputActionEventType.ButtonShortPressJustReleased:
							break;
						case InputActionEventType.NegativeButtonLongPressed:
							goto IL_01b9;
						case InputActionEventType.NegativeButtonLongPressJustReleased:
							goto IL_01d6;
						case InputActionEventType.ButtonJustDoublePressed:
							goto IL_01f3;
						case InputActionEventType.AxisActive:
							goto IL_022c;
						case InputActionEventType.ButtonJustPressed:
							goto IL_024e;
						case InputActionEventType.ButtonDoublePressed:
							goto IL_027d;
						case InputActionEventType.ButtonSinglePressed:
							goto IL_02a7;
						case InputActionEventType.ButtonJustShortPressed:
							goto IL_02bc;
						case InputActionEventType.NegativeButtonJustPressed:
							goto IL_02d4;
						case InputActionEventType.ButtonRepeating:
							goto IL_02f1;
						case InputActionEventType.AxisActiveOrJustInactive:
							goto IL_030e;
						case InputActionEventType.ButtonLongPressed:
							goto IL_0338;
						case InputActionEventType.ButtonShortPressed:
							goto IL_038d;
						case InputActionEventType.ButtonJustPressedForTime:
							goto IL_03b9;
						case InputActionEventType.ButtonPressed:
							goto IL_0430;
						case InputActionEventType.ButtonUnpressed:
							goto IL_045c;
						case InputActionEventType.NegativeButtonDoublePressJustReleased:
							goto IL_04a2;
						case InputActionEventType.ButtonDoublePressJustReleased:
							goto IL_04b7;
						case InputActionEventType.ButtonPressedForTime:
							goto IL_04e1;
						case InputActionEventType.NegativeButtonJustDoublePressed:
							goto IL_051c;
						case InputActionEventType.NegativeButtonJustLongPressed:
							goto IL_0531;
						case InputActionEventType.NegativeButtonShortPressJustReleased:
							goto IL_054e;
						case InputActionEventType.ButtonJustReleased:
							goto IL_0588;
						case InputActionEventType.NegativeButtonJustPressedForTime:
							goto IL_059d;
						case InputActionEventType.AxisRawActive:
							goto IL_05f9;
						case InputActionEventType.AxisRawInactive:
							goto IL_0616;
						case InputActionEventType.Update:
							goto IL_0645;
						case InputActionEventType.NegativeButtonPressed:
							goto IL_0664;
						case InputActionEventType.NegativeButtonRepeating:
							goto IL_0686;
						case InputActionEventType.NegativeButtonSinglePressed:
							goto IL_06e9;
						case InputActionEventType.NegativeButtonJustReleased:
							goto IL_06fe;
						case InputActionEventType.NegativeButtonDoublePressed:
							goto IL_0732;
						case InputActionEventType.AxisInactive:
							goto IL_075c;
						case InputActionEventType.ButtonPressedForTimeJustReleased:
							goto IL_077e;
						case InputActionEventType.ButtonLongPressJustReleased:
							goto IL_07b9;
						default:
							goto IL_08c6;
						case InputActionEventType.AxisRawActiveOrJustInactive:
							goto IL_08d0;
						case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
							goto IL_090b;
						case InputActionEventType.ButtonJustLongPressed:
							goto IL_0962;
						case InputActionEventType.NegativeButtonUnpressed:
							goto IL_097f;
						case InputActionEventType.NegativeButtonPressedForTime:
							goto IL_09b6;
						case InputActionEventType.NegativeButtonJustSinglePressed:
							goto IL_09e7;
						case InputActionEventType.ButtonSinglePressJustReleased:
							goto IL_0a11;
						case InputActionEventType.NegativeButtonJustShortPressed:
							goto IL_0a2e;
						case InputActionEventType.ButtonJustSinglePressed:
							goto IL_0a8a;
						case InputActionEventType.NegativeButtonShortPressed:
							goto IL_0a9f;
						case InputActionEventType.NegativeButtonSinglePressJustReleased:
							goto IL_0ab6;
						}
						goto case 54;
					case 12:
						goto IL_08d0;
					case 41:
						if (!MathTools.ApproximatelyZero(P_0.RFtmscItPvoqKaeIKqYmnAxaEFjc()))
						{
							num2 = -1361704122;
							continue;
						}
						goto case 0;
					case 60:
						goto IL_090b;
					case 22:
						flag = true;
						goto case 0;
					case 32:
						goto IL_0962;
					case 65:
						goto IL_097f;
					case 26:
						flag = true;
						num2 = -1361704099;
						continue;
					case 4:
						flag = true;
						goto case 0;
					case 34:
						goto IL_09b6;
					case 33:
						flag = false;
						num2 = -1361704192;
						continue;
					case 88:
						goto IL_09e7;
					case 55:
						flag = true;
						goto case 0;
					case 44:
						goto IL_0a11;
					case 56:
						goto IL_0a2e;
					case 8:
						if (P_0.dOAGKPSipdZlaAbbEokZoDIHHLC(num3))
						{
							num2 = -1361704096;
							continue;
						}
						goto case 0;
					case 17:
						flag = true;
						goto case 0;
					case 19:
						goto IL_0a8a;
					case 25:
						goto IL_0a9f;
					case 1:
						goto IL_0ab6;
					case 85:
						goto IL_0acd;
					default:
						throw new NotImplementedException();
					case 0:
					case 2:
					case 5:
					case 10:
					case 14:
					case 15:
					case 23:
					case 28:
					case 31:
					case 38:
					case 47:
					case 61:
					case 69:
						try
						{
							if (flag)
							{
								InputActionEventData obj = P_0.wwJCfwGwbvLLmUoumKXGXpMmmxQt(P_1);
								while (true)
								{
									IL_0aff:
									int num10 = -1361704106;
									while (true)
									{
										switch (num10 ^ -1361704105)
										{
										case 2:
											break;
										default:
											goto end_IL_0b04;
										case 1:
											goto IL_0b1d;
										case 0:
											goto end_IL_0b04;
										}
										goto IL_0aff;
										IL_0b1d:
										obj.eventType = xcptJhlTgQIGzCasSfEIjpeEciij.OXfLFmAwdXNeXCDfjaMaASYRzGDW;
										xcptJhlTgQIGzCasSfEIjpeEciij.msVVRWbCGXIWrzOwJDAXLVPEHPw(obj);
										num10 = -1361704105;
										continue;
										end_IL_0b04:
										break;
									}
									break;
								}
							}
						}
						catch (Exception exception)
						{
							ReInput.HandleCallbackException("Player input event callback", exception);
						}
						goto IL_0b52;
					case 39:
						goto IL_0b78;
						IL_02a7:
						if (P_0.HSgGoWrdyQlRfGWElIYGTWJBSOK())
						{
							num2 = -1361704100;
							continue;
						}
						goto case 0;
						IL_0ab6:
						if (P_0.KTpXYTuqpfgzcuQcdAthQbBmJOK())
						{
							flag = true;
						}
						goto case 0;
						IL_04b7:
						xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(0, out num4);
						if (P_0.muCXbdCwQsGYDmNJFtnRwqLKQDq(num4))
						{
							flag = true;
						}
						goto case 0;
						IL_0a9f:
						if (P_0.miFsbiglmYCEIAQeXkMbXRqjCtSb())
						{
							flag = true;
						}
						goto case 0;
						IL_0a8a:
						if (P_0.ODUcBxgJzPGmQZrvLHwtywMKnSVC())
						{
							flag = true;
							num2 = -1361704107;
							continue;
						}
						goto case 0;
						IL_04a2:
						xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(0, out num6);
						num2 = -1361704094;
						continue;
						IL_0a2e:
						if (P_0.JKHpwqnigmDeLJUNtVsqeZifnYu())
						{
							flag = true;
							num2 = -1361704120;
							continue;
						}
						goto case 0;
						IL_0a11:
						if (P_0.VfgUqUOpVrAbpFtGMvSgiqUMoGr())
						{
							flag = true;
						}
						goto case 0;
						IL_027d:
						xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(0, out num7);
						if (P_0.RuiZcjLOJskVOMqsJZYkxDIjyhA(num7))
						{
							flag = true;
						}
						goto case 0;
						IL_09e7:
						if (P_0.kLYaolUGcRNJqlKSEZFkBHCVEHX())
						{
							flag = true;
							num2 = -1361704110;
							continue;
						}
						goto case 0;
						IL_045c:
						if (!P_0.OMsDoddGLoMsnAOixNusrDCoKsdq())
						{
							flag = true;
						}
						goto case 0;
						IL_09b6:
						if (xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(0, out num8))
						{
							xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(1, out num9);
							num2 = -1361704077;
							continue;
						}
						goto IL_0b52;
						IL_097f:
						if (!P_0.nkChpEwCeyIAcExUuFGdJLElwIA())
						{
							flag = true;
							num2 = -1361704117;
							continue;
						}
						goto case 0;
						IL_0430:
						if (P_0.OMsDoddGLoMsnAOixNusrDCoKsdq())
						{
							flag = true;
						}
						goto case 0;
						IL_0962:
						if (P_0.FklPSljcUaxKydxZYdiDkSYZolB())
						{
							flag = true;
						}
						goto case 0;
						IL_090b:
						if (xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(0, out num11))
						{
							float num12;
							xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(1, out num12);
							if (P_0.uEyIDtIDaHApazSzDPxtOwMsWvuF(num11, num12))
							{
								flag = true;
								num2 = -1361704072;
								continue;
							}
							goto case 0;
						}
						goto IL_0b52;
						IL_03b9:
						if (xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(0, out num13))
						{
							if (P_0.TmWmkgzOAdaTdHxVZjOYtSYjapHU(num13))
							{
								flag = true;
							}
							goto case 0;
						}
						goto IL_0b52;
						IL_08c6:
						num2 = -1361704161;
						continue;
						IL_024e:
						if (P_0.VoFALJiXKwwyQgLPqqsGLZcLBoM())
						{
							flag = true;
						}
						goto case 0;
						IL_07b9:
						if (P_0.HvqSyQJyWgHfIBWSkTRNTFVuOsy())
						{
							flag = true;
						}
						goto case 0;
						IL_0b52:
						num5++;
						goto IL_0b56;
						IL_077e:
						if (xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(0, out num14))
						{
							float num15;
							xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(1, out num15);
							if (P_0.SnZcquUjSouueUwNdDjJzfjnhdte(num14, num15))
							{
								flag = true;
							}
							goto case 0;
						}
						goto IL_0b52;
						IL_038d:
						if (P_0.MEkWNPeIovcPibcOIDriEloGWCek())
						{
							flag = true;
						}
						goto case 0;
						IL_022c:
						if (!MathTools.ApproximatelyZero(P_0.BscAVytxcCBkilFutmFsULYtqRF()))
						{
							flag = true;
						}
						goto case 0;
						IL_075c:
						if (MathTools.ApproximatelyZero(P_0.BscAVytxcCBkilFutmFsULYtqRF()))
						{
							flag = true;
						}
						goto case 0;
						IL_0732:
						xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(0, out num16);
						if (P_0.fdzmsdIYwqztXcolheWsrQJMyv(num16))
						{
							flag = true;
						}
						goto case 0;
						IL_0b56:
						num17 = -1361704106;
						goto IL_0b5b;
						IL_01f3:
						xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(0, out num18);
						if (P_0.zLExFcCVwGmJlXFXVImjVBwCEZKB(num18))
						{
							flag = true;
						}
						goto case 0;
						IL_06fe:
						if (P_0.sqLJephBcMrzUHldDlcYpoVsgfQC())
						{
							num2 = -1361704164;
							continue;
						}
						goto case 0;
						IL_06e9:
						if (P_0.ngPfxaJknmSuXcFPylUatEwGRfE())
						{
							num2 = -1361704068;
							continue;
						}
						goto case 0;
						IL_0338:
						if (P_0.EWlxTOVmbBtSlquMQaYQrQofJeT())
						{
							flag = true;
						}
						goto case 0;
						IL_0686:
						if (P_0.eTqXvIgOuFMZVnfBflDIiPcAHfM())
						{
							num2 = -1361704091;
							continue;
						}
						goto case 0;
						IL_0b5b:
						while (true)
						{
							switch (num17 ^ -1361704105)
							{
							case 0:
								break;
							case 1:
								goto IL_0b78;
							case 2:
								num++;
								num17 = -1361704108;
								continue;
							default:
								goto end_IL_0acd;
							}
							break;
						}
						goto IL_0b56;
						IL_0664:
						if (P_0.nkChpEwCeyIAcExUuFGdJLElwIA())
						{
							num2 = -1361704171;
							continue;
						}
						goto case 0;
						IL_030e:
						if (!MathTools.ApproximatelyZero(P_0.BscAVytxcCBkilFutmFsULYtqRF()))
						{
							goto case 80;
						}
						if (!MathTools.ApproximatelyZero(P_0.nBcptjXKjHAyjSgEkspdFFUtFBF()))
						{
							num2 = -1361704185;
							continue;
						}
						goto case 0;
						IL_0645:
						flag = true;
						num2 = -1361704174;
						continue;
						IL_0616:
						if (MathTools.ApproximatelyZero(P_0.KfAFlDbMroUFANmhWhpKpXVscgPy()))
						{
							flag = true;
						}
						goto case 0;
						IL_01d6:
						if (P_0.KICXvNWuNoIHXBEvQauvdVBOXPcS())
						{
							flag = true;
						}
						goto case 0;
						IL_05f9:
						if (!MathTools.ApproximatelyZero(P_0.KfAFlDbMroUFANmhWhpKpXVscgPy()))
						{
							flag = true;
							num2 = -1361704079;
							continue;
						}
						goto case 0;
						IL_0b78:
						if (num5 < count)
						{
							goto case 42;
						}
						num17 = -1361704107;
						goto IL_0b5b;
						IL_059d:
						if (xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(0, out num19))
						{
							if (P_0.zFcbFfEbtqAVMVOymyDrayobmQYK(num19))
							{
								flag = true;
								num2 = -1361704128;
								continue;
							}
							goto case 0;
						}
						goto IL_0b52;
						IL_02f1:
						if (P_0.qPoCvloGegNyKIgEIqqJKorfkQQ())
						{
							flag = true;
						}
						goto case 0;
						IL_0588:
						if (P_0.zZfNFOMmkwRPDTjWQEBszXZnyS())
						{
							num2 = -1361704109;
							continue;
						}
						goto case 0;
						IL_01b9:
						if (P_0.RLljstHsoOvZfhmQakvzwAXfDac())
						{
							flag = true;
						}
						goto case 0;
						IL_02d4:
						if (P_0.npsYQCyKleLimEhZDAdnaxnwlFNO())
						{
							flag = true;
						}
						goto case 0;
						IL_054e:
						if (P_0.IcsRdTqDrEgjriRMBoSRZQDqaiFs())
						{
							num2 = -1361704088;
							continue;
						}
						goto case 0;
						IL_0531:
						if (P_0.SjLycOTsrePJjJUvBGJNSZOVUxa())
						{
							flag = true;
						}
						goto case 0;
						IL_02bc:
						if (P_0.JFwxaZRBlqWpKNDcitBhgiyflkm())
						{
							flag = true;
							num2 = -1361704105;
							continue;
						}
						goto case 0;
						IL_051c:
						xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(0, out num3);
						num2 = -1361704097;
						continue;
						IL_04e1:
						if (xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(0, out num20))
						{
							float num21;
							xcptJhlTgQIGzCasSfEIjpeEciij.wlbeybGmQVTuONNZlgtfcVvqOjYH(1, out num21);
							if (P_0.LIagbRzpgaHmaNasOBJuJLfEbEmS(num20, num21))
							{
								flag = true;
							}
							goto case 0;
						}
						goto IL_0b52;
					}
					break;
					IL_08d0:
					int num22;
					if (MathTools.ApproximatelyZero(P_0.KfAFlDbMroUFANmhWhpKpXVscgPy()))
					{
						num2 = -1361704066;
						num22 = num2;
					}
					else
					{
						num2 = -1361704122;
						num22 = num2;
					}
					continue;
					IL_06be:
					int num23;
					if (!P_0.BdgIlNfBSgMruspNkDePcrIffUrj)
					{
						num2 = -1361704108;
						num23 = num2;
					}
					else
					{
						num2 = -1361704176;
						num23 = num2;
					}
				}
				goto IL_05c6;
				IL_05c6:
				count = aList._count;
				num2 = -1361704126;
				goto IL_0021;
				continue;
				end_IL_0acd:
				break;
			}
		}
	}

	public void VLruXdLRDGFfXmmERvMAbDydBTo(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!fxzgZHdorylahBrNCBxmuceoqOgc)
		{
			dFyvOnKBbTYzKLbxHBbiIGdcrpeH();
		}
		XcptJhlTgQIGzCasSfEIjpeEciij item;
		try
		{
			if (P_3 > ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.maxActionId)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new XcptJhlTgQIGzCasSfEIjpeEciij(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 >= 0)
		{
			goto IL_0097;
		}
		yUZGGyfDunsfBGZQUVHzNLqAQcV[NtGMTHHlPgVRVSzUWcygMcyybxc].Add(item);
		goto IL_00b5;
		IL_00b5:
		MIIyjeFJOeataeSvNvbOBCuLmceg();
		int num = 1043444107;
		goto IL_007a;
		IL_0097:
		yUZGGyfDunsfBGZQUVHzNLqAQcV[tnNMLXfmfdwEcMdqxEvXcEmGPgf[P_3]].Add(item);
		num = 1043444106;
		goto IL_007a;
		IL_007a:
		while (true)
		{
			switch (num ^ 0x3E31B189)
			{
			case 0:
				num = 1043444104;
				continue;
			default:
				return;
			case 1:
				break;
			case 3:
				goto IL_00b5;
			case 2:
				return;
			}
			break;
		}
		goto IL_0097;
	}

	public void VLruXdLRDGFfXmmERvMAbDydBTo(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!fxzgZHdorylahBrNCBxmuceoqOgc)
		{
			dFyvOnKBbTYzKLbxHBbiIGdcrpeH();
		}
		XcptJhlTgQIGzCasSfEIjpeEciij item;
		try
		{
			item = new XcptJhlTgQIGzCasSfEIjpeEciij(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		yUZGGyfDunsfBGZQUVHzNLqAQcV[NtGMTHHlPgVRVSzUWcygMcyybxc].Add(item);
		MIIyjeFJOeataeSvNvbOBCuLmceg();
	}

	public void mwFDXXqitzdkdQJZVuGLgThFXxm(Action<InputActionEventData> P_0)
	{
		MQDboqAtCWIWMhBKOwZZikFXhAIY mQDboqAtCWIWMhBKOwZZikFXhAIY = new MQDboqAtCWIWMhBKOwZZikFXhAIY();
		mQDboqAtCWIWMhBKOwZZikFXhAIY.msVVRWbCGXIWrzOwJDAXLVPEHPw = P_0;
		if (!fxzgZHdorylahBrNCBxmuceoqOgc)
		{
			return;
		}
		int num2 = default(int);
		while (true)
		{
			AList<XcptJhlTgQIGzCasSfEIjpeEciij>[] array = yUZGGyfDunsfBGZQUVHzNLqAQcV;
			int num = 1659955749;
			while (true)
			{
				switch (num ^ 0x62F0EA21)
				{
				case 0:
					num = 1659955751;
					continue;
				case 2:
					num2++;
					num = 1659955744;
					continue;
				case 4:
					num2 = 0;
					num = 1659955744;
					continue;
				case 1:
				{
					int num3;
					if (num2 < array.Length)
					{
						num = 1659955746;
						num3 = num;
					}
					else
					{
						num = 1659955748;
						num3 = num;
					}
					continue;
				}
				case 6:
					break;
				case 3:
				{
					AList<XcptJhlTgQIGzCasSfEIjpeEciij> aList = array[num2];
					aList.RemoveAll(mQDboqAtCWIWMhBKOwZZikFXhAIY.esVGshaGhyoCEukaJQcJHDoddzWT);
					num = 1659955747;
					continue;
				}
				default:
					MIIyjeFJOeataeSvNvbOBCuLmceg();
					return;
				}
				break;
			}
		}
	}

	public void mwFDXXqitzdkdQJZVuGLgThFXxm(Action<InputActionEventData> P_0, int P_1)
	{
		PhRxOfKQWBZVygPTmapgRXKLqOT phRxOfKQWBZVygPTmapgRXKLqOT = new PhRxOfKQWBZVygPTmapgRXKLqOT();
		phRxOfKQWBZVygPTmapgRXKLqOT.msVVRWbCGXIWrzOwJDAXLVPEHPw = P_0;
		phRxOfKQWBZVygPTmapgRXKLqOT.hDvAMaTqLegLZzPsyeYTryTcCaC = P_1;
		if (!fxzgZHdorylahBrNCBxmuceoqOgc)
		{
			return;
		}
		while (phRxOfKQWBZVygPTmapgRXKLqOT.hDvAMaTqLegLZzPsyeYTryTcCaC <= ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.maxActionId)
		{
			while (true)
			{
				IL_0063:
				AList<XcptJhlTgQIGzCasSfEIjpeEciij>[] array = yUZGGyfDunsfBGZQUVHzNLqAQcV;
				int num = 0;
				int num2 = 363242075;
				while (true)
				{
					switch (num2 ^ 0x15A6A259)
					{
					case 5:
						num2 = 363242072;
						continue;
					case 1:
						break;
					case 0:
						goto IL_0063;
					case 4:
					{
						AList<XcptJhlTgQIGzCasSfEIjpeEciij> aList = array[num];
						aList.RemoveAll(phRxOfKQWBZVygPTmapgRXKLqOT.SCxISEwHaoQgrQYVDzblCCzwYhd);
						num2 = 363242074;
						continue;
					}
					case 3:
						num++;
						num2 = 363242075;
						continue;
					default:
						if (num >= array.Length)
						{
							MIIyjeFJOeataeSvNvbOBCuLmceg();
							return;
						}
						goto case 4;
					}
					break;
				}
				break;
			}
		}
	}

	public void mwFDXXqitzdkdQJZVuGLgThFXxm(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		NdncbyBTqpIlocYgEDqjMCQZLhE ndncbyBTqpIlocYgEDqjMCQZLhE = new NdncbyBTqpIlocYgEDqjMCQZLhE();
		int num2 = default(int);
		AList<XcptJhlTgQIGzCasSfEIjpeEciij> aList = default(AList<XcptJhlTgQIGzCasSfEIjpeEciij>);
		AList<XcptJhlTgQIGzCasSfEIjpeEciij>[] array = default(AList<XcptJhlTgQIGzCasSfEIjpeEciij>[]);
		while (true)
		{
			int num = -2107315326;
			while (true)
			{
				switch (num ^ -2107315327)
				{
				case 6:
					break;
				case 7:
					num2++;
					num = -2107315327;
					continue;
				case 2:
					aList.RemoveAll(ndncbyBTqpIlocYgEDqjMCQZLhE.GCPrkevIhPyvsRqUzLkXrfcDhxq);
					num = -2107315322;
					continue;
				case 8:
					aList = array[num2];
					num = -2107315325;
					continue;
				case 1:
					num2 = 0;
					num = -2107315327;
					continue;
				case 4:
					array = yUZGGyfDunsfBGZQUVHzNLqAQcV;
					num = -2107315328;
					continue;
				case 5:
					if (!fxzgZHdorylahBrNCBxmuceoqOgc)
					{
						return;
					}
					goto case 4;
				case 3:
					ndncbyBTqpIlocYgEDqjMCQZLhE.msVVRWbCGXIWrzOwJDAXLVPEHPw = P_0;
					ndncbyBTqpIlocYgEDqjMCQZLhE.NigWaDmPBoxUjERAcsoKpawNrzS = P_1;
					num = -2107315324;
					continue;
				default:
					if (num2 >= array.Length)
					{
						MIIyjeFJOeataeSvNvbOBCuLmceg();
						return;
					}
					goto case 8;
				}
				break;
			}
		}
	}

	public void mwFDXXqitzdkdQJZVuGLgThFXxm(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		RpLCMjclLfXWvEVRMOLpIuykYPCa rpLCMjclLfXWvEVRMOLpIuykYPCa = new RpLCMjclLfXWvEVRMOLpIuykYPCa();
		rpLCMjclLfXWvEVRMOLpIuykYPCa.msVVRWbCGXIWrzOwJDAXLVPEHPw = P_0;
		rpLCMjclLfXWvEVRMOLpIuykYPCa.OXfLFmAwdXNeXCDfjaMaASYRzGDW = P_1;
		AList<XcptJhlTgQIGzCasSfEIjpeEciij>[] array = default(AList<XcptJhlTgQIGzCasSfEIjpeEciij>[]);
		int num2 = default(int);
		while (true)
		{
			int num = -804671592;
			while (true)
			{
				switch (num ^ -804671591)
				{
				case 2:
					break;
				case 6:
				{
					AList<XcptJhlTgQIGzCasSfEIjpeEciij> aList = array[num2];
					aList.RemoveAll(rpLCMjclLfXWvEVRMOLpIuykYPCa.ZwCXoNIuTOhkplBdguiyqgjwZSz);
					num2++;
					num = -804671590;
					continue;
				}
				case 5:
					return;
				case 0:
					array = yUZGGyfDunsfBGZQUVHzNLqAQcV;
					num2 = 0;
					num = -804671590;
					continue;
				case 1:
				{
					int num4;
					if (!fxzgZHdorylahBrNCBxmuceoqOgc)
					{
						num = -804671588;
						num4 = num;
					}
					else
					{
						num = -804671591;
						num4 = num;
					}
					continue;
				}
				case 3:
				{
					int num3;
					if (num2 >= array.Length)
					{
						num = -804671587;
						num3 = num;
					}
					else
					{
						num = -804671585;
						num3 = num;
					}
					continue;
				}
				default:
					MIIyjeFJOeataeSvNvbOBCuLmceg();
					return;
				}
				break;
			}
		}
	}

	public void mwFDXXqitzdkdQJZVuGLgThFXxm(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		int num2 = default(int);
		AList<XcptJhlTgQIGzCasSfEIjpeEciij>[] array = default(AList<XcptJhlTgQIGzCasSfEIjpeEciij>[]);
		AList<XcptJhlTgQIGzCasSfEIjpeEciij> aList = default(AList<XcptJhlTgQIGzCasSfEIjpeEciij>);
		OUUCGiuCBWiNFevjKDhFWmqKEaCf oUUCGiuCBWiNFevjKDhFWmqKEaCf = default(OUUCGiuCBWiNFevjKDhFWmqKEaCf);
		while (true)
		{
			int num = 892136361;
			while (true)
			{
				switch (num ^ 0x352CEBAE)
				{
				case 0:
					break;
				case 9:
					num2++;
					num = 892136362;
					continue;
				case 10:
					array = yUZGGyfDunsfBGZQUVHzNLqAQcV;
					num2 = 0;
					num = 892136362;
					continue;
				case 11:
					aList.RemoveAll(oUUCGiuCBWiNFevjKDhFWmqKEaCf.BSvTzgpfaRUkxyRAekvCCSXAFQ);
					num = 892136359;
					continue;
				case 2:
				{
					int num4;
					if (fxzgZHdorylahBrNCBxmuceoqOgc)
					{
						num = 892136354;
						num4 = num;
					}
					else
					{
						num = 892136358;
						num4 = num;
					}
					continue;
				}
				case 5:
					oUUCGiuCBWiNFevjKDhFWmqKEaCf.msVVRWbCGXIWrzOwJDAXLVPEHPw = P_0;
					oUUCGiuCBWiNFevjKDhFWmqKEaCf.NigWaDmPBoxUjERAcsoKpawNrzS = P_1;
					num = 892136365;
					continue;
				case 3:
					oUUCGiuCBWiNFevjKDhFWmqKEaCf.hDvAMaTqLegLZzPsyeYTryTcCaC = P_2;
					num = 892136364;
					continue;
				case 6:
					aList = array[num2];
					num = 892136357;
					continue;
				case 12:
					if (oUUCGiuCBWiNFevjKDhFWmqKEaCf.hDvAMaTqLegLZzPsyeYTryTcCaC > ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.maxActionId)
					{
						return;
					}
					goto case 10;
				case 8:
					return;
				case 4:
				{
					int num3;
					if (num2 >= array.Length)
					{
						num = 892136367;
						num3 = num;
					}
					else
					{
						num = 892136360;
						num3 = num;
					}
					continue;
				}
				case 7:
					oUUCGiuCBWiNFevjKDhFWmqKEaCf = new OUUCGiuCBWiNFevjKDhFWmqKEaCf();
					num = 892136363;
					continue;
				default:
					MIIyjeFJOeataeSvNvbOBCuLmceg();
					return;
				}
				break;
			}
		}
	}

	public void mwFDXXqitzdkdQJZVuGLgThFXxm(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		ppydnYiXDvXxRJXlOparSYpqVQJ ppydnYiXDvXxRJXlOparSYpqVQJ2 = new ppydnYiXDvXxRJXlOparSYpqVQJ();
		ppydnYiXDvXxRJXlOparSYpqVQJ2.msVVRWbCGXIWrzOwJDAXLVPEHPw = P_0;
		ppydnYiXDvXxRJXlOparSYpqVQJ2.NigWaDmPBoxUjERAcsoKpawNrzS = P_1;
		ppydnYiXDvXxRJXlOparSYpqVQJ2.OXfLFmAwdXNeXCDfjaMaASYRzGDW = P_2;
		ppydnYiXDvXxRJXlOparSYpqVQJ2.hDvAMaTqLegLZzPsyeYTryTcCaC = P_3;
		if (!fxzgZHdorylahBrNCBxmuceoqOgc)
		{
			return;
		}
		AList<XcptJhlTgQIGzCasSfEIjpeEciij> aList = default(AList<XcptJhlTgQIGzCasSfEIjpeEciij>);
		int num2 = default(int);
		while (ppydnYiXDvXxRJXlOparSYpqVQJ2.hDvAMaTqLegLZzPsyeYTryTcCaC <= ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.maxActionId)
		{
			while (true)
			{
				IL_00b3:
				AList<XcptJhlTgQIGzCasSfEIjpeEciij>[] array = yUZGGyfDunsfBGZQUVHzNLqAQcV;
				int num = -2137757647;
				while (true)
				{
					switch (num ^ -2137757645)
					{
					case 0:
						num = -2137757642;
						continue;
					case 1:
						aList.RemoveAll(ppydnYiXDvXxRJXlOparSYpqVQJ2.eJlhlxYdblazZlhjpGNACQnAJKGA);
						num = -2137757648;
						continue;
					case 8:
						aList = array[num2];
						num = -2137757646;
						continue;
					case 2:
						num2 = 0;
						num = -2137757644;
						continue;
					case 5:
						break;
					case 4:
						goto IL_00b3;
					case 7:
						num = -2137757643;
						continue;
					case 3:
						num2++;
						num = -2137757643;
						continue;
					default:
						if (num2 >= array.Length)
						{
							MIIyjeFJOeataeSvNvbOBCuLmceg();
							return;
						}
						goto case 8;
					}
					break;
				}
				break;
			}
		}
	}

	public void mwFDXXqitzdkdQJZVuGLgThFXxm(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		xImSPJjdQeeUJHgiKgrADuxcpAs xImSPJjdQeeUJHgiKgrADuxcpAs2 = new xImSPJjdQeeUJHgiKgrADuxcpAs();
		xImSPJjdQeeUJHgiKgrADuxcpAs2.msVVRWbCGXIWrzOwJDAXLVPEHPw = P_0;
		xImSPJjdQeeUJHgiKgrADuxcpAs2.NigWaDmPBoxUjERAcsoKpawNrzS = P_1;
		xImSPJjdQeeUJHgiKgrADuxcpAs2.OXfLFmAwdXNeXCDfjaMaASYRzGDW = P_2;
		int num2 = default(int);
		AList<XcptJhlTgQIGzCasSfEIjpeEciij>[] array = default(AList<XcptJhlTgQIGzCasSfEIjpeEciij>[]);
		while (true)
		{
			int num = 1124447463;
			while (true)
			{
				switch (num ^ 0x4305B4E3)
				{
				case 2:
					break;
				case 3:
					num2 = 0;
					num = 1124447459;
					continue;
				case 1:
				{
					AList<XcptJhlTgQIGzCasSfEIjpeEciij> aList = array[num2];
					aList.RemoveAll(xImSPJjdQeeUJHgiKgrADuxcpAs2.tbQueRjKhTpVLsQNwyxKjCShEjn);
					num2++;
					num = 1124447459;
					continue;
				}
				case 4:
				{
					int num3;
					if (!fxzgZHdorylahBrNCBxmuceoqOgc)
					{
						num = 1124447461;
						num3 = num;
					}
					else
					{
						num = 1124447462;
						num3 = num;
					}
					continue;
				}
				case 5:
					array = yUZGGyfDunsfBGZQUVHzNLqAQcV;
					num = 1124447456;
					continue;
				case 6:
					return;
				default:
					if (num2 >= array.Length)
					{
						MIIyjeFJOeataeSvNvbOBCuLmceg();
						return;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	public void mwFDXXqitzdkdQJZVuGLgThFXxm(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		YBMdQyEDKNNmrcWegEpneJwkQMAY yBMdQyEDKNNmrcWegEpneJwkQMAY = default(YBMdQyEDKNNmrcWegEpneJwkQMAY);
		int num2 = default(int);
		AList<XcptJhlTgQIGzCasSfEIjpeEciij>[] array = default(AList<XcptJhlTgQIGzCasSfEIjpeEciij>[]);
		while (true)
		{
			int num = -1322387224;
			while (true)
			{
				switch (num ^ -1322387218)
				{
				case 4:
					break;
				case 6:
					yBMdQyEDKNNmrcWegEpneJwkQMAY = new YBMdQyEDKNNmrcWegEpneJwkQMAY();
					yBMdQyEDKNNmrcWegEpneJwkQMAY.msVVRWbCGXIWrzOwJDAXLVPEHPw = P_0;
					yBMdQyEDKNNmrcWegEpneJwkQMAY.OXfLFmAwdXNeXCDfjaMaASYRzGDW = P_1;
					num = -1322387220;
					continue;
				case 1:
				{
					int num3;
					if (num2 < array.Length)
					{
						num = -1322387219;
						num3 = num;
					}
					else
					{
						num = -1322387218;
						num3 = num;
					}
					continue;
				}
				case 7:
					array = yUZGGyfDunsfBGZQUVHzNLqAQcV;
					num2 = 0;
					num = -1322387217;
					continue;
				case 2:
					yBMdQyEDKNNmrcWegEpneJwkQMAY.hDvAMaTqLegLZzPsyeYTryTcCaC = P_2;
					if (!fxzgZHdorylahBrNCBxmuceoqOgc)
					{
						return;
					}
					goto case 5;
				case 3:
				{
					AList<XcptJhlTgQIGzCasSfEIjpeEciij> aList = array[num2];
					aList.RemoveAll(yBMdQyEDKNNmrcWegEpneJwkQMAY.piYZMUKEXpuLXUURoReyQfmSGDm);
					num2++;
					num = -1322387217;
					continue;
				}
				case 5:
					if (yBMdQyEDKNNmrcWegEpneJwkQMAY.hDvAMaTqLegLZzPsyeYTryTcCaC > ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.maxActionId)
					{
						return;
					}
					goto case 7;
				default:
					MIIyjeFJOeataeSvNvbOBCuLmceg();
					return;
				}
				break;
			}
		}
	}

	public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
	{
		if (!fxzgZHdorylahBrNCBxmuceoqOgc)
		{
			return;
		}
		while (true)
		{
			AList<XcptJhlTgQIGzCasSfEIjpeEciij>[] array = yUZGGyfDunsfBGZQUVHzNLqAQcV;
			int num = 0;
			int num2 = -927335438;
			while (true)
			{
				switch (num2 ^ -927335438)
				{
				case 5:
					num2 = -927335437;
					continue;
				default:
					return;
				case 4:
					num++;
					num2 = -927335440;
					continue;
				case 0:
					num2 = -927335440;
					continue;
				case 2:
					if (num >= array.Length)
					{
						MIIyjeFJOeataeSvNvbOBCuLmceg();
						num2 = -927335436;
						continue;
					}
					goto case 3;
				case 3:
				{
					AList<XcptJhlTgQIGzCasSfEIjpeEciij> aList = array[num];
					aList.Clear();
					num2 = -927335434;
					continue;
				}
				case 1:
					break;
				case 6:
					return;
				}
				break;
			}
		}
	}

	private void MIIyjeFJOeataeSvNvbOBCuLmceg()
	{
		int num = 0;
		int num3 = default(int);
		while (true)
		{
			int num2 = 585726804;
			while (true)
			{
				switch (num2 ^ 0x22E97B57)
				{
				case 0:
					break;
				case 3:
					num3 = 0;
					num2 = 585726806;
					continue;
				case 2:
					num += yUZGGyfDunsfBGZQUVHzNLqAQcV[num3]._count;
					num3++;
					num2 = 585726806;
					continue;
				default:
					if (num3 >= yUZGGyfDunsfBGZQUVHzNLqAQcV.Length)
					{
						PwXHtiwRLoynEJlcjliQaMRCQlr = num;
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	[CompilerGenerated]
	private static AList<XcptJhlTgQIGzCasSfEIjpeEciij> eJFnvaQmAtsiNsWyIOkvFVyCDQM()
	{
		return new AList<XcptJhlTgQIGzCasSfEIjpeEciij>();
	}
}
