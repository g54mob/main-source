using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class PCItYZcmQVbRIIUnLbZiPkYVRSE
{
	public class VwSqzlFJAmDyHwxqJedQqGvDZcc
	{
		public readonly Action<InputActionEventData> RERAhLRQKJhiOXbllLXxmBeUAhn;

		public readonly UpdateLoopType uZqPISCyPgGPOetNKiFUKtuJqjV;

		public readonly InputActionEventType zKveCvyuxNpTsuNgJMSufHIXiLC;

		public readonly int CcfTFbvLTcqsiXVrUOCJWGLeCzX;

		public readonly bool uhxrmtBAEhcojnyWHjOtEsxASfS;

		public float[] LVZtFhyRCVTwzcHHmpSmLJjrVkS;

		public VwSqzlFJAmDyHwxqJedQqGvDZcc(Action<InputActionEventData> @delegate, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			uZqPISCyPgGPOetNKiFUKtuJqjV = updateLoop;
			zKveCvyuxNpTsuNgJMSufHIXiLC = eventType;
			CcfTFbvLTcqsiXVrUOCJWGLeCzX = actionId;
			RERAhLRQKJhiOXbllLXxmBeUAhn = @delegate;
			rPAlupNHEMoGlmgnGyWmSpSBEDH(arguments);
			switch (eventType)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				uhxrmtBAEhcojnyWHjOtEsxASfS = true;
				break;
			}
		}

		public bool NytltcmICJVTxrcIZcxjCevcRwP(int P_0, out float P_1)
		{
			if (LVZtFhyRCVTwzcHHmpSmLJjrVkS != null)
			{
				while (true)
				{
					int num = 852861960;
					while (true)
					{
						switch (num ^ 0x32D5A40A)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0026:
						if (LVZtFhyRCVTwzcHHmpSmLJjrVkS.Length <= P_0)
						{
							num = 852861963;
							continue;
						}
						P_1 = LVZtFhyRCVTwzcHHmpSmLJjrVkS[P_0];
						return true;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			P_1 = 0f;
			return false;
		}

		private void rPAlupNHEMoGlmgnGyWmSpSBEDH(object[] P_0)
		{
			InputActionEventType inputActionEventType = zKveCvyuxNpTsuNgJMSufHIXiLC;
			if (inputActionEventType > InputActionEventType.NegativeButtonPressedForTimeJustReleased)
			{
				goto IL_015d;
			}
			switch (inputActionEventType)
			{
			default:
				return;
			case InputActionEventType.ButtonDoublePressed:
			case InputActionEventType.ButtonJustDoublePressed:
			case InputActionEventType.NegativeButtonDoublePressed:
			case InputActionEventType.NegativeButtonJustDoublePressed:
				break;
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				goto IL_02e8;
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				goto IL_038b;
			}
			goto IL_01a8;
			IL_00fe:
			throw new Exception(string.Concat("Wrong number of arguments passed for Input event type \"", zKveCvyuxNpTsuNgJMSufHIXiLC, "\". Requires 1 argument: time [float]"));
			IL_038b:
			int num;
			if (P_0 != null)
			{
				int num2;
				if (P_0.Length < 1)
				{
					num = 252636369;
					num2 = num;
				}
				else
				{
					num = 252636365;
					num2 = num;
				}
				goto IL_004e;
			}
			goto IL_01e7;
			IL_02e8:
			if (P_0 != null)
			{
				int num3;
				if (P_0.Length < 1)
				{
					num = 252636356;
					num3 = num;
				}
				else
				{
					num = 252636360;
					num3 = num;
				}
				goto IL_004e;
			}
			goto IL_00fe;
			IL_01e7:
			throw new Exception(string.Concat("Wrong number of arguments passed for Input event type \"", zKveCvyuxNpTsuNgJMSufHIXiLC, "\". 1 required argument: time [float], 1 optional argument: expireIn [float]"));
			IL_01a8:
			int num4;
			if (P_0 != null)
			{
				num = 252636361;
				num4 = num;
			}
			else
			{
				num = 252636357;
				num4 = num;
			}
			goto IL_004e;
			IL_004e:
			while (true)
			{
				switch (num ^ 0xF0EECCB)
				{
				case 4:
					num = 252636352;
					continue;
				default:
					return;
				case 25:
					num = 252636362;
					continue;
				case 5:
					throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", zKveCvyuxNpTsuNgJMSufHIXiLC, "\". Argument 1 (optional): expireIn [float]"));
				case 15:
					break;
				case 10:
					throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", zKveCvyuxNpTsuNgJMSufHIXiLC, "\". Argument 0: time [float]"));
				case 14:
					return;
				case 11:
					goto IL_015d;
				case 6:
					LVZtFhyRCVTwzcHHmpSmLJjrVkS = new float[2];
					if (P_0[0] is float)
					{
						LVZtFhyRCVTwzcHHmpSmLJjrVkS[0] = (float)P_0[0];
						num = 252636378;
						continue;
					}
					goto case 13;
				case 18:
					goto IL_01a8;
				case 0:
					if (P_0[1] is float)
					{
						LVZtFhyRCVTwzcHHmpSmLJjrVkS[1] = (float)P_0[1];
						return;
					}
					goto case 21;
				case 26:
					goto IL_01e7;
				case 2:
					goto IL_0211;
				case 19:
					LVZtFhyRCVTwzcHHmpSmLJjrVkS = new float[1];
					if (P_0[0] is float)
					{
						LVZtFhyRCVTwzcHHmpSmLJjrVkS[0] = (float)P_0[0];
						return;
					}
					goto case 8;
				case 1:
					goto IL_025f;
				case 21:
					if (P_0[1] is int)
					{
						LVZtFhyRCVTwzcHHmpSmLJjrVkS[1] = (int)P_0[1];
						return;
					}
					goto case 5;
				case 24:
					LVZtFhyRCVTwzcHHmpSmLJjrVkS[0] = (int)P_0[0];
					return;
				case 23:
					throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", zKveCvyuxNpTsuNgJMSufHIXiLC, "\". Argument 0: time [float]"));
				case 12:
					goto IL_02e8;
				case 16:
					throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", zKveCvyuxNpTsuNgJMSufHIXiLC, "\". Argument 0 (optional): time [float]"));
				case 3:
					LVZtFhyRCVTwzcHHmpSmLJjrVkS = new float[1];
					if (P_0[0] is float)
					{
						LVZtFhyRCVTwzcHHmpSmLJjrVkS[0] = (float)P_0[0];
						return;
					}
					goto IL_03e8;
				case 8:
					if (P_0[0] is int)
					{
						LVZtFhyRCVTwzcHHmpSmLJjrVkS[0] = (int)P_0[0];
						num = 252636381;
						continue;
					}
					goto case 16;
				case 7:
					goto IL_038b;
				case 17:
					num = 252636362;
					continue;
				case 22:
					return;
				case 13:
					if (P_0[0] is int)
					{
						LVZtFhyRCVTwzcHHmpSmLJjrVkS[0] = (int)P_0[0];
						num = 252636370;
						continue;
					}
					goto case 10;
				case 9:
					goto IL_03e8;
				case 20:
					return;
				}
				break;
				IL_03e8:
				int num5;
				if (P_0[0] is int)
				{
					num = 252636371;
					num5 = num;
				}
				else
				{
					num = 252636380;
					num5 = num;
				}
				continue;
				IL_025f:
				int num6;
				if (P_0.Length <= 1)
				{
					num = 252636383;
					num6 = num;
				}
				else
				{
					num = 252636363;
					num6 = num;
				}
				continue;
				IL_0211:
				int num7;
				if (P_0.Length >= 1)
				{
					num = 252636376;
					num7 = num;
				}
				else
				{
					num = 252636357;
					num7 = num;
				}
			}
			goto IL_00fe;
			IL_015d:
			if (inputActionEventType != InputActionEventType.ButtonDoublePressJustReleased && inputActionEventType != InputActionEventType.NegativeButtonDoublePressJustReleased)
			{
				return;
			}
			goto IL_01a8;
		}
	}

	private sealed class rGyIlbwbQSsrlOLTDWLehHBJAlGi
	{
		public Action<InputActionEventData> RERAhLRQKJhiOXbllLXxmBeUAhn;

		public bool XvFxpeyvlahvhGsxfrmZsPujgkDj(VwSqzlFJAmDyHwxqJedQqGvDZcc P_0)
		{
			return P_0.RERAhLRQKJhiOXbllLXxmBeUAhn == RERAhLRQKJhiOXbllLXxmBeUAhn;
		}
	}

	private sealed class emRSHRSnyxafgFFPgfxyAPBTsDW
	{
		public Action<InputActionEventData> RERAhLRQKJhiOXbllLXxmBeUAhn;

		public int CcfTFbvLTcqsiXVrUOCJWGLeCzX;

		public bool vXpPHFIiLkrjAieYrlHbzpzgPNe(VwSqzlFJAmDyHwxqJedQqGvDZcc P_0)
		{
			if (P_0.RERAhLRQKJhiOXbllLXxmBeUAhn == RERAhLRQKJhiOXbllLXxmBeUAhn)
			{
				return P_0.CcfTFbvLTcqsiXVrUOCJWGLeCzX == CcfTFbvLTcqsiXVrUOCJWGLeCzX;
			}
			return false;
		}
	}

	private sealed class UvyfuWzybKgDdIYElHBccsgkWpq
	{
		public Action<InputActionEventData> RERAhLRQKJhiOXbllLXxmBeUAhn;

		public UpdateLoopType uZqPISCyPgGPOetNKiFUKtuJqjV;

		public bool rXTaxWLxdRPGDlPPZRVJEusXwCr(VwSqzlFJAmDyHwxqJedQqGvDZcc P_0)
		{
			if (P_0.RERAhLRQKJhiOXbllLXxmBeUAhn == RERAhLRQKJhiOXbllLXxmBeUAhn)
			{
				return P_0.uZqPISCyPgGPOetNKiFUKtuJqjV == uZqPISCyPgGPOetNKiFUKtuJqjV;
			}
			return false;
		}
	}

	private sealed class ptYnhHbtfvnkOXHkcwhyklbqrGO
	{
		public Action<InputActionEventData> RERAhLRQKJhiOXbllLXxmBeUAhn;

		public InputActionEventType zKveCvyuxNpTsuNgJMSufHIXiLC;

		public bool mKKftYsXBOiDIFNgCSicxPpomBi(VwSqzlFJAmDyHwxqJedQqGvDZcc P_0)
		{
			if (P_0.RERAhLRQKJhiOXbllLXxmBeUAhn == RERAhLRQKJhiOXbllLXxmBeUAhn)
			{
				return P_0.zKveCvyuxNpTsuNgJMSufHIXiLC == zKveCvyuxNpTsuNgJMSufHIXiLC;
			}
			return false;
		}
	}

	private sealed class oewZTOLXspRuokzGUBpMLTFgPq
	{
		public Action<InputActionEventData> RERAhLRQKJhiOXbllLXxmBeUAhn;

		public UpdateLoopType uZqPISCyPgGPOetNKiFUKtuJqjV;

		public int CcfTFbvLTcqsiXVrUOCJWGLeCzX;

		public bool cDSmgiCzXkqXRRvwqgCxvYjDHkF(VwSqzlFJAmDyHwxqJedQqGvDZcc P_0)
		{
			if (P_0.RERAhLRQKJhiOXbllLXxmBeUAhn == RERAhLRQKJhiOXbllLXxmBeUAhn && P_0.uZqPISCyPgGPOetNKiFUKtuJqjV == uZqPISCyPgGPOetNKiFUKtuJqjV)
			{
				return P_0.CcfTFbvLTcqsiXVrUOCJWGLeCzX == CcfTFbvLTcqsiXVrUOCJWGLeCzX;
			}
			return false;
		}
	}

	private sealed class UjHCPXDOhgoPnHYkjEtVhlMNpQOR
	{
		public Action<InputActionEventData> RERAhLRQKJhiOXbllLXxmBeUAhn;

		public UpdateLoopType uZqPISCyPgGPOetNKiFUKtuJqjV;

		public InputActionEventType zKveCvyuxNpTsuNgJMSufHIXiLC;

		public int CcfTFbvLTcqsiXVrUOCJWGLeCzX;

		public bool PZtmawkSplGmkRdgLTqYtUvEFGL(VwSqzlFJAmDyHwxqJedQqGvDZcc P_0)
		{
			if (P_0.RERAhLRQKJhiOXbllLXxmBeUAhn == RERAhLRQKJhiOXbllLXxmBeUAhn && P_0.uZqPISCyPgGPOetNKiFUKtuJqjV == uZqPISCyPgGPOetNKiFUKtuJqjV && P_0.CcfTFbvLTcqsiXVrUOCJWGLeCzX == CcfTFbvLTcqsiXVrUOCJWGLeCzX)
			{
				return P_0.zKveCvyuxNpTsuNgJMSufHIXiLC == zKveCvyuxNpTsuNgJMSufHIXiLC;
			}
			return false;
		}
	}

	private sealed class rMYZvqkofqHpKhFDzZkZPRWTlZJM
	{
		public Action<InputActionEventData> RERAhLRQKJhiOXbllLXxmBeUAhn;

		public UpdateLoopType uZqPISCyPgGPOetNKiFUKtuJqjV;

		public InputActionEventType zKveCvyuxNpTsuNgJMSufHIXiLC;

		public bool GWxlIRClTfIgKdUGWaKKaOhfXo(VwSqzlFJAmDyHwxqJedQqGvDZcc P_0)
		{
			if (P_0.RERAhLRQKJhiOXbllLXxmBeUAhn == RERAhLRQKJhiOXbllLXxmBeUAhn && P_0.uZqPISCyPgGPOetNKiFUKtuJqjV == uZqPISCyPgGPOetNKiFUKtuJqjV)
			{
				return P_0.zKveCvyuxNpTsuNgJMSufHIXiLC == zKveCvyuxNpTsuNgJMSufHIXiLC;
			}
			return false;
		}
	}

	private sealed class iyNMOvaAjOyrCZQFqbwTIHdlxkC
	{
		public Action<InputActionEventData> RERAhLRQKJhiOXbllLXxmBeUAhn;

		public InputActionEventType zKveCvyuxNpTsuNgJMSufHIXiLC;

		public int CcfTFbvLTcqsiXVrUOCJWGLeCzX;

		public bool OUWODAyDSvJyCmFjETAaxyjEZvf(VwSqzlFJAmDyHwxqJedQqGvDZcc P_0)
		{
			if (P_0.RERAhLRQKJhiOXbllLXxmBeUAhn == RERAhLRQKJhiOXbllLXxmBeUAhn && P_0.CcfTFbvLTcqsiXVrUOCJWGLeCzX == CcfTFbvLTcqsiXVrUOCJWGLeCzX)
			{
				return P_0.zKveCvyuxNpTsuNgJMSufHIXiLC == zKveCvyuxNpTsuNgJMSufHIXiLC;
			}
			return false;
		}
	}

	private bool WktzUSAcjulBYRNUcifkLEmijRhD;

	private AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[] NsBrJlDcgrsSiyRBgUDzwjyYqlW;

	private int[] MnPVkCPBjjDHReJpBSzLBxwSdhu;

	private int gkIHQEdmDabosyxVoMmwdKqqxkn;

	public int agHbGfItBitHhxopNafYNRHURry;

	[CompilerGenerated]
	private static Func<AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>> PkdHFYJlZLMiTCimwpAnCiFWpZz;

	private void YJaAHaimrHWIfKrgfWxeihnqrcza()
	{
		if (WktzUSAcjulBYRNUcifkLEmijRhD)
		{
			return;
		}
		int num3 = default(int);
		while (true)
		{
			IList<InputAction> actions = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.Actions;
			int num = ((actions != null) ? actions.Count : 0);
			NsBrJlDcgrsSiyRBgUDzwjyYqlW = new AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[num + 1];
			MnPVkCPBjjDHReJpBSzLBxwSdhu = new int[ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.maxActionId + 1];
			int num2 = 755168782;
			while (true)
			{
				switch (num2 ^ 0x2D02F60B)
				{
				case 3:
					num2 = 755168778;
					continue;
				case 1:
					break;
				case 5:
					ArrayTools.Populate(NsBrJlDcgrsSiyRBgUDzwjyYqlW, 0, NsBrJlDcgrsSiyRBgUDzwjyYqlW.Length, () => new AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>());
					num3 = 0;
					num2 = 755168783;
					continue;
				case 0:
					MnPVkCPBjjDHReJpBSzLBxwSdhu[actions[num3].id] = num3;
					num3++;
					num2 = 755168783;
					continue;
				case 4:
				{
					int num4;
					if (num3 < num)
					{
						num2 = 755168779;
						num4 = num2;
					}
					else
					{
						num2 = 755168777;
						num4 = num2;
					}
					continue;
				}
				default:
					gkIHQEdmDabosyxVoMmwdKqqxkn = num;
					WktzUSAcjulBYRNUcifkLEmijRhD = true;
					return;
				}
				break;
			}
		}
	}

	public void XnekMAFkyeDvwzoGtUMNgUUhjSf(pEQcyInzaqspNDwmuMYGrewsNaQ P_0, UpdateLoopType P_1)
	{
		AList<VwSqzlFJAmDyHwxqJedQqGvDZcc> aList = NsBrJlDcgrsSiyRBgUDzwjyYqlW[MnPVkCPBjjDHReJpBSzLBxwSdhu[P_0.mecAvOSCkKTUzDMSKLpGqHuOJBZ]];
		int num = 0;
		bool flag = default(bool);
		float num6 = default(float);
		float num7 = default(float);
		float num13 = default(float);
		InputActionEventType zKveCvyuxNpTsuNgJMSufHIXiLC = default(InputActionEventType);
		VwSqzlFJAmDyHwxqJedQqGvDZcc vwSqzlFJAmDyHwxqJedQqGvDZcc = default(VwSqzlFJAmDyHwxqJedQqGvDZcc);
		float num9 = default(float);
		int num11 = default(int);
		float num5 = default(float);
		float num3 = default(float);
		InputActionEventData obj = default(InputActionEventData);
		int count = default(int);
		while (num < 2)
		{
			while (true)
			{
				int num2;
				if (num == 1)
				{
					aList = NsBrJlDcgrsSiyRBgUDzwjyYqlW[gkIHQEdmDabosyxVoMmwdKqqxkn];
					num2 = -1947817220;
					goto IL_0021;
				}
				goto IL_07f4;
				IL_0021:
				while (true)
				{
					int num4;
					float num10;
					float num12;
					float num14;
					float num15;
					float num16;
					float num18;
					float num21;
					switch (num2 ^ -1947817271)
					{
					case 31:
						num2 = -1947817280;
						continue;
					case 71:
						if (P_0.QCBwuzrcxibRyGfWCxMmKFAWaMD())
						{
							flag = true;
						}
						goto case 7;
					case 36:
						flag = false;
						num2 = -1947817333;
						continue;
					case 9:
						break;
					case 10:
						flag = true;
						goto case 7;
					case 69:
						flag = true;
						goto case 7;
					case 2:
						if (!MathTools.ApproximatelyZero(P_0.pAQaeYoVtoBapeKmsZlYocRkDjMw()))
						{
							goto case 20;
						}
						if (!MathTools.ApproximatelyZero(P_0.qgrhzzkMBnrVfACVsTCkWkpyeIoh()))
						{
							num2 = -1947817251;
							continue;
						}
						goto case 7;
					case 65:
						goto IL_0217;
					case 0:
						goto IL_023b;
					case 28:
						goto IL_0254;
					case 74:
						goto IL_0276;
					case 33:
						goto IL_02a2;
					case 27:
						flag = true;
						goto case 7;
					case 60:
						if (P_0.wxklcERvuaELJtrzqLHaclhYEDjd(num6, num7))
						{
							flag = true;
						}
						goto case 7;
					case 47:
						goto IL_02f7;
					case 26:
						goto IL_0314;
					case 1:
						if (P_0.ydVhKMKFAjcRDuehjQcVWBjVngj(num13))
						{
							flag = true;
						}
						goto case 7;
					case 25:
						flag = true;
						goto case 7;
					case 57:
						goto IL_0362;
					case 3:
						goto IL_0377;
					case 66:
						zKveCvyuxNpTsuNgJMSufHIXiLC = vwSqzlFJAmDyHwxqJedQqGvDZcc.zKveCvyuxNpTsuNgJMSufHIXiLC;
						switch (zKveCvyuxNpTsuNgJMSufHIXiLC)
						{
						case InputActionEventType.AxisRawActiveOrJustInactive:
							break;
						case InputActionEventType.ButtonPressedForTime:
							goto IL_0217;
						case InputActionEventType.ButtonPressedForTimeJustReleased:
							goto IL_023b;
						case InputActionEventType.AxisRawInactive:
							goto IL_0254;
						case InputActionEventType.AxisRawActive:
							goto IL_02a2;
						case InputActionEventType.NegativeButtonPressed:
							goto IL_02f7;
						case InputActionEventType.NegativeButtonLongPressed:
							goto IL_0314;
						case InputActionEventType.NegativeButtonDoublePressed:
							goto IL_0362;
						case InputActionEventType.NegativeButtonJustDoublePressed:
							goto IL_0377;
						default:
							goto IL_0445;
						case InputActionEventType.NegativeButtonRepeating:
							goto IL_04bc;
						case InputActionEventType.NegativeButtonUnpressed:
							goto IL_04d9;
						case InputActionEventType.ButtonRepeating:
							goto IL_0503;
						case InputActionEventType.ButtonJustPressed:
							goto IL_0520;
						case InputActionEventType.ButtonJustDoublePressed:
							goto IL_054f;
						case InputActionEventType.ButtonJustReleased:
							goto IL_0579;
						case InputActionEventType.NegativeButtonJustLongPressed:
							goto IL_0596;
						case InputActionEventType.ButtonJustPressedForTime:
							goto IL_05cd;
						case InputActionEventType.NegativeButtonShortPressJustReleased:
							goto IL_05fb;
						case InputActionEventType.NegativeButtonJustShortPressed:
							goto IL_0618;
						case InputActionEventType.NegativeButtonShortPressed:
							goto IL_064e;
						case InputActionEventType.NegativeButtonLongPressJustReleased:
							goto IL_06a8;
						case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
							goto IL_06c5;
						case InputActionEventType.AxisActive:
							goto IL_06f8;
						case InputActionEventType.ButtonPressed:
							goto IL_0715;
						case InputActionEventType.AxisInactive:
							goto IL_0732;
						case InputActionEventType.AxisActiveOrJustInactive:
							goto IL_077b;
						case InputActionEventType.NegativeButtonPressedForTime:
							goto IL_07b9;
						case InputActionEventType.ButtonLongPressed:
							goto IL_0807;
						case InputActionEventType.NegativeButtonJustReleased:
							goto IL_0855;
						case InputActionEventType.ButtonShortPressed:
							goto IL_0872;
						case InputActionEventType.ButtonLongPressJustReleased:
							goto IL_088f;
						case InputActionEventType.ButtonShortPressJustReleased:
							goto IL_08a4;
						case InputActionEventType.Update:
							goto IL_08b9;
						case InputActionEventType.ButtonDoublePressed:
							goto IL_08cb;
						case InputActionEventType.NegativeButtonJustPressed:
							goto IL_090a;
						case InputActionEventType.NegativeButtonJustPressedForTime:
							goto IL_0965;
						case InputActionEventType.ButtonJustShortPressed:
							goto IL_097e;
						case InputActionEventType.ButtonUnpressed:
							goto IL_09d7;
						case InputActionEventType.ButtonJustLongPressed:
							goto IL_0a36;
						}
						goto case 2;
					case 34:
						switch (zKveCvyuxNpTsuNgJMSufHIXiLC)
						{
						case InputActionEventType.NegativeButtonSinglePressed:
							break;
						case InputActionEventType.ButtonSinglePressed:
							goto IL_0276;
						default:
							goto IL_0495;
						case InputActionEventType.ButtonSinglePressJustReleased:
							goto IL_049f;
						case InputActionEventType.ButtonJustSinglePressed:
							goto IL_079c;
						case InputActionEventType.NegativeButtonSinglePressJustReleased:
							goto IL_0838;
						case InputActionEventType.NegativeButtonDoublePressJustReleased:
							goto IL_08f5;
						case InputActionEventType.NegativeButtonJustSinglePressed:
							goto IL_0948;
						case InputActionEventType.ButtonDoublePressJustReleased:
							goto IL_0a17;
						}
						goto case 71;
					case 48:
						goto IL_049f;
					case 58:
						goto IL_04bc;
					case 11:
						goto IL_04d9;
					case 63:
						flag = true;
						goto case 7;
					case 73:
						goto IL_0503;
					case 64:
						goto IL_0520;
					case 35:
						flag = true;
						goto case 7;
					case 51:
						goto IL_054f;
					case 6:
						goto IL_0579;
					case 16:
						goto IL_0596;
					case 41:
						if (!MathTools.ApproximatelyZero(P_0.OBiksylQWJjQjwhzYenDgZXxIGF()))
						{
							num2 = -1947817262;
							continue;
						}
						goto case 7;
					case 77:
						goto IL_05cd;
					case 5:
						goto IL_05fb;
					case 78:
						goto IL_0618;
					case 76:
						flag = true;
						goto case 7;
					case 21:
						goto IL_064e;
					case 44:
						flag = true;
						goto case 7;
					case 12:
						if (vwSqzlFJAmDyHwxqJedQqGvDZcc.uZqPISCyPgGPOetNKiFUKtuJqjV == P_1)
						{
							goto IL_068a;
						}
						goto IL_0ae7;
					case 43:
						goto IL_06a8;
					case 29:
						goto IL_06c5;
					case 39:
						goto IL_06f8;
					case 23:
						goto IL_0715;
					case 72:
						goto IL_0732;
					case 18:
					{
						float num8;
						vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(1, out num8);
						if (P_0.dVFrovmlIiHHPqBCNJnHYplrEkef(num9, num8))
						{
							flag = true;
							num2 = -1947817244;
							continue;
						}
						goto case 7;
					}
					case 40:
						goto IL_077b;
					case 62:
						goto IL_079c;
					case 54:
						goto IL_07b9;
					case 53:
						goto IL_07f4;
					case 70:
						goto IL_0807;
					case 75:
						if (vwSqzlFJAmDyHwxqJedQqGvDZcc.CcfTFbvLTcqsiXVrUOCJWGLeCzX == P_0.mecAvOSCkKTUzDMSKLpGqHuOJBZ)
						{
							num2 = -1947817235;
							continue;
						}
						goto IL_0ae7;
					case 67:
						goto IL_0838;
					case 37:
						goto IL_0855;
					case 22:
						goto IL_0872;
					case 42:
						goto IL_088f;
					case 32:
						goto IL_08a4;
					case 59:
						goto IL_08b9;
					case 4:
						goto IL_08cb;
					case 19:
						goto IL_08f5;
					case 56:
						goto IL_090a;
					case 17:
						flag = true;
						goto case 7;
					case 50:
						goto IL_0948;
					case 38:
						goto IL_0965;
					case 49:
						goto IL_097e;
					case 79:
						vwSqzlFJAmDyHwxqJedQqGvDZcc = aList._items[num11];
						if (vwSqzlFJAmDyHwxqJedQqGvDZcc != null)
						{
							if (P_0.mFczoEbROoNOTHHEQCmVfUMtAPcv)
							{
								goto case 12;
							}
							if (vwSqzlFJAmDyHwxqJedQqGvDZcc.uhxrmtBAEhcojnyWHjOtEsxASfS)
							{
								num2 = -1947817275;
								continue;
							}
						}
						goto IL_0ae7;
					case 52:
						goto IL_09d7;
					case 14:
						if (P_0.KZjyNrTKNgHQOrbmJvBAPWMRDOy(num5))
						{
							flag = true;
						}
						goto case 7;
					case 20:
						flag = true;
						goto case 7;
					case 68:
						goto IL_0a17;
					case 8:
						goto IL_0a36;
					case 15:
						if (P_0.SFiwEaJijuQchcXlQFVdLdqbCFZ(num3))
						{
							num2 = -1947817226;
							continue;
						}
						goto case 7;
					default:
						throw new NotImplementedException();
					case 7:
					case 24:
					case 45:
					case 46:
					case 55:
					case 61:
						try
						{
							if (flag)
							{
								while (true)
								{
									IL_0a75:
									int num20 = -1947817270;
									while (true)
									{
										switch (num20 ^ -1947817271)
										{
										case 4:
											break;
										default:
											goto end_IL_0a7a;
										case 1:
											vwSqzlFJAmDyHwxqJedQqGvDZcc.RERAhLRQKJhiOXbllLXxmBeUAhn(obj);
											num20 = -1947817269;
											continue;
										case 0:
											obj.eventType = vwSqzlFJAmDyHwxqJedQqGvDZcc.zKveCvyuxNpTsuNgJMSufHIXiLC;
											num20 = -1947817272;
											continue;
										case 3:
											obj = P_0.VrHXatCSddrmDMPxCSZACUOmCqR(P_1);
											num20 = -1947817271;
											continue;
										case 2:
											goto end_IL_0a7a;
										}
										goto IL_0a75;
										continue;
										end_IL_0a7a:
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
						goto IL_0ae7;
					case 30:
						goto IL_0b09;
						IL_0af0:
						switch (num4 ^ -1947817271)
						{
						case 0:
							break;
						case 2:
							goto IL_0b09;
						default:
							goto end_IL_019b;
						}
						goto IL_0aeb;
						IL_0579:
						if (P_0.OyXGTSwiLyydixsXoAkXTFGBrMP())
						{
							flag = true;
						}
						goto case 7;
						IL_0217:
						if (vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(0, out num6))
						{
							vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(1, out num7);
							num2 = -1947817227;
							continue;
						}
						goto IL_0ae7;
						IL_054f:
						vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(0, out num10);
						if (P_0.KVYBArGysOtyKpvWvichEouJUIXn(num10))
						{
							flag = true;
						}
						goto case 7;
						IL_0b09:
						if (num11 < count)
						{
							goto case 79;
						}
						num++;
						num4 = -1947817272;
						goto IL_0af0;
						IL_0a17:
						vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(0, out num12);
						if (P_0.FTMCwioxGgIbwHAYvDlTcFPHSAlC(num12))
						{
							num2 = -1947817332;
							continue;
						}
						goto case 7;
						IL_0520:
						if (P_0.kmPAfEKnCyTirEYSWkaOedaLedN())
						{
							flag = true;
						}
						goto case 7;
						IL_0948:
						if (P_0.HuWvifqevXgZvJHwwFePyKBJRSJ())
						{
							flag = true;
						}
						goto case 7;
						IL_08f5:
						vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(0, out num13);
						num2 = -1947817272;
						continue;
						IL_0838:
						if (P_0.fIhcEUGPpnDDBjOfPoKpwrBwGZXP())
						{
							flag = true;
						}
						goto case 7;
						IL_0503:
						if (P_0.XMuJsoWGwkdqfiGJyXqPtcfjmlP())
						{
							flag = true;
						}
						goto case 7;
						IL_079c:
						if (P_0.xlSsEefXfNsXbZyirAyfPSKMcTW())
						{
							flag = true;
						}
						goto case 7;
						IL_049f:
						if (P_0.iHwerJAqVfEQSCtTfkIyzFItSBcF())
						{
							flag = true;
						}
						goto case 7;
						IL_04d9:
						if (!P_0.WvSmeLExuitBNiAVEhCleOWlTFR())
						{
							flag = true;
							num2 = -1947817228;
							continue;
						}
						goto case 7;
						IL_0495:
						num2 = -1947817276;
						continue;
						IL_0a36:
						if (P_0.ssrFVmHAOuxfRJhWgmeRXJABOcY())
						{
							flag = true;
							num2 = -1947817218;
							continue;
						}
						goto case 7;
						IL_09d7:
						if (!P_0.lvyTpewEByrJQaPpHiuasLSeNzw())
						{
							flag = true;
							num2 = -1947817263;
							continue;
						}
						goto case 7;
						IL_04bc:
						if (P_0.PHyBYFIwgNChoJCUNazGaNwOIWH())
						{
							flag = true;
						}
						goto case 7;
						IL_097e:
						if (P_0.oCihxYaxpocUbbxviEHrhZuUjztL())
						{
							flag = true;
							num2 = -1947817241;
							continue;
						}
						goto case 7;
						IL_0965:
						if (vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(0, out num3))
						{
							num2 = -1947817274;
							continue;
						}
						goto IL_0ae7;
						IL_0445:
						num2 = -1947817237;
						continue;
						IL_090a:
						if (P_0.EYuDJVDMraHBZVsAfWxxjYhezKIh())
						{
							flag = true;
						}
						goto case 7;
						IL_0377:
						vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(0, out num14);
						if (P_0.OrCBIqmjbhyTOgyyigLkLYAFQHD(num14))
						{
							num2 = -1947817243;
							continue;
						}
						goto case 7;
						IL_08cb:
						vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(0, out num15);
						if (P_0.khySxihXVeHHtgPjnBNkOYPffuJ(num15))
						{
							flag = true;
						}
						goto case 7;
						IL_08b9:
						flag = true;
						goto case 7;
						IL_08a4:
						if (P_0.SkODxaakXeCDpheFdlLpOtdzPNBu())
						{
							num2 = -1947817339;
							continue;
						}
						goto case 7;
						IL_0362:
						vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(0, out num5);
						num2 = -1947817273;
						continue;
						IL_088f:
						if (P_0.sMcCvPBnIygOxQxPIOLBFgBkKtzz())
						{
							num2 = -1947817264;
							continue;
						}
						goto case 7;
						IL_0872:
						if (P_0.dJmBEWIMgftsPBEHqbpmuIkQYJxk())
						{
							flag = true;
						}
						goto case 7;
						IL_0855:
						if (P_0.RvVOlcFiiUoCnzwclOyOUWFywkR())
						{
							flag = true;
						}
						goto case 7;
						IL_0807:
						if (P_0.lTpGWRDldJqfUaMTglYKLAkbshOG())
						{
							num2 = -1947817238;
							continue;
						}
						goto case 7;
						IL_0314:
						if (P_0.sZjovgfYuOueYRjHKfaxPMBhEtfH())
						{
							flag = true;
						}
						goto case 7;
						IL_07b9:
						if (vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(0, out num16))
						{
							float num17;
							vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(1, out num17);
							if (P_0.rZebOrKydgpDEirkUXGZClPDYFE(num16, num17))
							{
								flag = true;
							}
							goto case 7;
						}
						goto IL_0ae7;
						IL_02f7:
						if (P_0.WvSmeLExuitBNiAVEhCleOWlTFR())
						{
							flag = true;
						}
						goto case 7;
						IL_0732:
						if (MathTools.ApproximatelyZero(P_0.gsiPWtFMoYarPDgrBaZqlwGphcI()))
						{
							flag = true;
						}
						goto case 7;
						IL_0715:
						if (P_0.lvyTpewEByrJQaPpHiuasLSeNzw())
						{
							flag = true;
						}
						goto case 7;
						IL_06f8:
						if (!MathTools.ApproximatelyZero(P_0.gsiPWtFMoYarPDgrBaZqlwGphcI()))
						{
							flag = true;
							num2 = -1947817266;
							continue;
						}
						goto case 7;
						IL_06c5:
						if (vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(0, out num18))
						{
							float num19;
							vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(1, out num19);
							if (P_0.HCqzYczWwBrILaUmphxfNZWkmkt(num18, num19))
							{
								num2 = -1947817277;
								continue;
							}
							goto case 7;
						}
						goto IL_0ae7;
						IL_02a2:
						if (!MathTools.ApproximatelyZero(P_0.pAQaeYoVtoBapeKmsZlYocRkDjMw()))
						{
							flag = true;
						}
						goto case 7;
						IL_06a8:
						if (P_0.zAIHmYaXXkGasjpkiIupayFWwSbZ())
						{
							flag = true;
						}
						goto case 7;
						IL_064e:
						if (P_0.TyRKchCmgGezpurjlGIlwHyhCqPF())
						{
							flag = true;
						}
						goto case 7;
						IL_0276:
						if (P_0.oumQrJVceWMuKcaHRTCQmoJRcBFg())
						{
							flag = true;
						}
						goto case 7;
						IL_0618:
						if (P_0.atJfdtVakiPTsxMWLswiHzqhnXh())
						{
							num2 = -1947817256;
							continue;
						}
						goto case 7;
						IL_0ae7:
						num11++;
						goto IL_0aeb;
						IL_05fb:
						if (P_0.pcuMeEWadAiOMfhHbUSXCfHyYbGq())
						{
							flag = true;
						}
						goto case 7;
						IL_0254:
						if (MathTools.ApproximatelyZero(P_0.pAQaeYoVtoBapeKmsZlYocRkDjMw()))
						{
							flag = true;
						}
						goto case 7;
						IL_05cd:
						if (vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(0, out num21))
						{
							if (P_0.gXOEjzDoUrBmGKJUrFSCuhWtwuYK(num21))
							{
								flag = true;
							}
							goto case 7;
						}
						goto IL_0ae7;
						IL_0aeb:
						num4 = -1947817269;
						goto IL_0af0;
						IL_023b:
						if (vwSqzlFJAmDyHwxqJedQqGvDZcc.NytltcmICJVTxrcIZcxjCevcRwP(0, out num9))
						{
							num2 = -1947817253;
							continue;
						}
						goto IL_0ae7;
						IL_0596:
						if (P_0.hWPFdJhnxwiqIMvmzcJTtrGXBwxy())
						{
							flag = true;
						}
						goto case 7;
					}
					break;
					IL_077b:
					int num22;
					if (!MathTools.ApproximatelyZero(P_0.gsiPWtFMoYarPDgrBaZqlwGphcI()))
					{
						num2 = -1947817262;
						num22 = num2;
					}
					else
					{
						num2 = -1947817248;
						num22 = num2;
					}
					continue;
					IL_068a:
					int num23;
					if (vwSqzlFJAmDyHwxqJedQqGvDZcc.CcfTFbvLTcqsiXVrUOCJWGLeCzX >= 0)
					{
						num2 = -1947817342;
						num23 = num2;
					}
					else
					{
						num2 = -1947817235;
						num23 = num2;
					}
				}
				continue;
				IL_07f4:
				count = aList._count;
				num11 = 0;
				num2 = -1947817257;
				goto IL_0021;
				continue;
				end_IL_019b:
				break;
			}
		}
	}

	public void qlbbxAfDiGgDoAbvzdeYICHvGcx(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!WktzUSAcjulBYRNUcifkLEmijRhD)
		{
			YJaAHaimrHWIfKrgfWxeihnqrcza();
		}
		VwSqzlFJAmDyHwxqJedQqGvDZcc item;
		try
		{
			if (P_3 > ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.maxActionId)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			while (true)
			{
				IL_0051:
				item = new VwSqzlFJAmDyHwxqJedQqGvDZcc(P_0, P_1, P_2, P_3, P_4);
				int num = 1356631536;
				while (true)
				{
					switch (num ^ 0x50DC8DF1)
					{
					case 0:
						goto IL_0033;
					default:
						goto end_IL_0038;
					case 2:
						break;
					case 1:
						goto end_IL_0038;
					}
					goto IL_0051;
					IL_0033:
					num = 1356631539;
					continue;
					end_IL_0038:
					break;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			goto IL_0084;
		}
		goto IL_00b7;
		IL_0089:
		int num2;
		while (true)
		{
			switch (num2 ^ 0x50DC8DF1)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				xAOiihInWikCVtmcfXvKmtoXGlhc();
				num2 = 1356631541;
				continue;
			case 0:
				goto IL_00b7;
			case 3:
				NsBrJlDcgrsSiyRBgUDzwjyYqlW[gkIHQEdmDabosyxVoMmwdKqqxkn].Add(item);
				num2 = 1356631536;
				continue;
			case 4:
				return;
			}
			break;
		}
		goto IL_0084;
		IL_0084:
		num2 = 1356631538;
		goto IL_0089;
		IL_00b7:
		NsBrJlDcgrsSiyRBgUDzwjyYqlW[MnPVkCPBjjDHReJpBSzLBxwSdhu[P_3]].Add(item);
		num2 = 1356631536;
		goto IL_0089;
	}

	public void qlbbxAfDiGgDoAbvzdeYICHvGcx(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!WktzUSAcjulBYRNUcifkLEmijRhD)
		{
			YJaAHaimrHWIfKrgfWxeihnqrcza();
		}
		VwSqzlFJAmDyHwxqJedQqGvDZcc item;
		try
		{
			item = new VwSqzlFJAmDyHwxqJedQqGvDZcc(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		NsBrJlDcgrsSiyRBgUDzwjyYqlW[gkIHQEdmDabosyxVoMmwdKqqxkn].Add(item);
		xAOiihInWikCVtmcfXvKmtoXGlhc();
	}

	public void FJHNCYGYhfbNGgXMnQKRPLpDCwz(Action<InputActionEventData> P_0)
	{
		rGyIlbwbQSsrlOLTDWLehHBJAlGi rGyIlbwbQSsrlOLTDWLehHBJAlGi2 = new rGyIlbwbQSsrlOLTDWLehHBJAlGi();
		rGyIlbwbQSsrlOLTDWLehHBJAlGi2.RERAhLRQKJhiOXbllLXxmBeUAhn = P_0;
		if (!WktzUSAcjulBYRNUcifkLEmijRhD)
		{
			return;
		}
		while (true)
		{
			AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[] nsBrJlDcgrsSiyRBgUDzwjyYqlW = NsBrJlDcgrsSiyRBgUDzwjyYqlW;
			int num = 0;
			int num2 = 903895597;
			while (true)
			{
				switch (num2 ^ 0x35E05A2E)
				{
				case 0:
					num2 = 903895594;
					continue;
				default:
					return;
				case 4:
					break;
				case 2:
					xAOiihInWikCVtmcfXvKmtoXGlhc();
					num2 = 903895595;
					continue;
				case 1:
				{
					AList<VwSqzlFJAmDyHwxqJedQqGvDZcc> aList = nsBrJlDcgrsSiyRBgUDzwjyYqlW[num];
					aList.RemoveAll(rGyIlbwbQSsrlOLTDWLehHBJAlGi2.XvFxpeyvlahvhGsxfrmZsPujgkDj);
					num++;
					num2 = 903895597;
					continue;
				}
				case 3:
				{
					int num3;
					if (num >= nsBrJlDcgrsSiyRBgUDzwjyYqlW.Length)
					{
						num2 = 903895596;
						num3 = num2;
					}
					else
					{
						num2 = 903895599;
						num3 = num2;
					}
					continue;
				}
				case 5:
					return;
				}
				break;
			}
		}
	}

	public void FJHNCYGYhfbNGgXMnQKRPLpDCwz(Action<InputActionEventData> P_0, int P_1)
	{
		AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[] nsBrJlDcgrsSiyRBgUDzwjyYqlW = default(AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[]);
		emRSHRSnyxafgFFPgfxyAPBTsDW emRSHRSnyxafgFFPgfxyAPBTsDW2 = default(emRSHRSnyxafgFFPgfxyAPBTsDW);
		AList<VwSqzlFJAmDyHwxqJedQqGvDZcc> aList = default(AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>);
		int num2 = default(int);
		while (true)
		{
			int num = -923252846;
			while (true)
			{
				switch (num ^ -923252837)
				{
				case 6:
					break;
				case 8:
					nsBrJlDcgrsSiyRBgUDzwjyYqlW = NsBrJlDcgrsSiyRBgUDzwjyYqlW;
					num = -923252836;
					continue;
				case 4:
					if (!WktzUSAcjulBYRNUcifkLEmijRhD)
					{
						return;
					}
					goto case 1;
				case 1:
					if (emRSHRSnyxafgFFPgfxyAPBTsDW2.CcfTFbvLTcqsiXVrUOCJWGLeCzX > ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.maxActionId)
					{
						return;
					}
					goto case 8;
				case 5:
					aList = nsBrJlDcgrsSiyRBgUDzwjyYqlW[num2];
					num = -923252837;
					continue;
				case 0:
					aList.RemoveAll(emRSHRSnyxafgFFPgfxyAPBTsDW2.vXpPHFIiLkrjAieYrlHbzpzgPNe);
					num2++;
					num = -923252840;
					continue;
				case 7:
					num2 = 0;
					num = -923252840;
					continue;
				case 9:
					emRSHRSnyxafgFFPgfxyAPBTsDW2 = new emRSHRSnyxafgFFPgfxyAPBTsDW();
					emRSHRSnyxafgFFPgfxyAPBTsDW2.RERAhLRQKJhiOXbllLXxmBeUAhn = P_0;
					emRSHRSnyxafgFFPgfxyAPBTsDW2.CcfTFbvLTcqsiXVrUOCJWGLeCzX = P_1;
					num = -923252833;
					continue;
				case 3:
				{
					int num3;
					if (num2 < nsBrJlDcgrsSiyRBgUDzwjyYqlW.Length)
					{
						num = -923252834;
						num3 = num;
					}
					else
					{
						num = -923252839;
						num3 = num;
					}
					continue;
				}
				default:
					xAOiihInWikCVtmcfXvKmtoXGlhc();
					return;
				}
				break;
			}
		}
	}

	public void FJHNCYGYhfbNGgXMnQKRPLpDCwz(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		UvyfuWzybKgDdIYElHBccsgkWpq uvyfuWzybKgDdIYElHBccsgkWpq = default(UvyfuWzybKgDdIYElHBccsgkWpq);
		AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[] nsBrJlDcgrsSiyRBgUDzwjyYqlW = default(AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[]);
		int num2 = default(int);
		while (true)
		{
			int num = -866445157;
			while (true)
			{
				switch (num ^ -866445158)
				{
				case 3:
					break;
				case 1:
					uvyfuWzybKgDdIYElHBccsgkWpq = new UvyfuWzybKgDdIYElHBccsgkWpq();
					uvyfuWzybKgDdIYElHBccsgkWpq.RERAhLRQKJhiOXbllLXxmBeUAhn = P_0;
					num = -866445153;
					continue;
				case 2:
				{
					AList<VwSqzlFJAmDyHwxqJedQqGvDZcc> aList = nsBrJlDcgrsSiyRBgUDzwjyYqlW[num2];
					aList.RemoveAll(uvyfuWzybKgDdIYElHBccsgkWpq.rXTaxWLxdRPGDlPPZRVJEusXwCr);
					num2++;
					num = -866445158;
					continue;
				}
				case 5:
					uvyfuWzybKgDdIYElHBccsgkWpq.uZqPISCyPgGPOetNKiFUKtuJqjV = P_1;
					if (!WktzUSAcjulBYRNUcifkLEmijRhD)
					{
						return;
					}
					goto case 4;
				case 4:
					nsBrJlDcgrsSiyRBgUDzwjyYqlW = NsBrJlDcgrsSiyRBgUDzwjyYqlW;
					num2 = 0;
					num = -866445158;
					continue;
				default:
					if (num2 >= nsBrJlDcgrsSiyRBgUDzwjyYqlW.Length)
					{
						xAOiihInWikCVtmcfXvKmtoXGlhc();
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	public void FJHNCYGYhfbNGgXMnQKRPLpDCwz(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		ptYnhHbtfvnkOXHkcwhyklbqrGO ptYnhHbtfvnkOXHkcwhyklbqrGO2 = new ptYnhHbtfvnkOXHkcwhyklbqrGO();
		ptYnhHbtfvnkOXHkcwhyklbqrGO2.RERAhLRQKJhiOXbllLXxmBeUAhn = P_0;
		ptYnhHbtfvnkOXHkcwhyklbqrGO2.zKveCvyuxNpTsuNgJMSufHIXiLC = P_1;
		if (!WktzUSAcjulBYRNUcifkLEmijRhD)
		{
			goto IL_001e;
		}
		goto IL_005c;
		IL_001e:
		int num = -1936009983;
		goto IL_0023;
		IL_0023:
		AList<VwSqzlFJAmDyHwxqJedQqGvDZcc> aList = default(AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>);
		AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[] nsBrJlDcgrsSiyRBgUDzwjyYqlW = default(AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[]);
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -1936009979)
			{
			case 0:
				break;
			case 4:
				return;
			case 5:
				aList = nsBrJlDcgrsSiyRBgUDzwjyYqlW[num2];
				num = -1936009978;
				continue;
			case 2:
				goto IL_005c;
			case 3:
				aList.RemoveAll(ptYnhHbtfvnkOXHkcwhyklbqrGO2.mKKftYsXBOiDIFNgCSicxPpomBi);
				num2++;
				num = -1936009980;
				continue;
			default:
				if (num2 >= nsBrJlDcgrsSiyRBgUDzwjyYqlW.Length)
				{
					xAOiihInWikCVtmcfXvKmtoXGlhc();
					return;
				}
				goto case 5;
			}
			break;
		}
		goto IL_001e;
		IL_005c:
		nsBrJlDcgrsSiyRBgUDzwjyYqlW = NsBrJlDcgrsSiyRBgUDzwjyYqlW;
		num2 = 0;
		num = -1936009980;
		goto IL_0023;
	}

	public void FJHNCYGYhfbNGgXMnQKRPLpDCwz(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		oewZTOLXspRuokzGUBpMLTFgPq oewZTOLXspRuokzGUBpMLTFgPq2 = new oewZTOLXspRuokzGUBpMLTFgPq();
		oewZTOLXspRuokzGUBpMLTFgPq2.RERAhLRQKJhiOXbllLXxmBeUAhn = P_0;
		int num3 = default(int);
		AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[] nsBrJlDcgrsSiyRBgUDzwjyYqlW = default(AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[]);
		while (true)
		{
			int num = -994782325;
			while (true)
			{
				switch (num ^ -994782321)
				{
				case 3:
					break;
				case 7:
					return;
				case 8:
					num3++;
					num = -994782321;
					continue;
				case 0:
				{
					int num4;
					if (num3 >= nsBrJlDcgrsSiyRBgUDzwjyYqlW.Length)
					{
						num = -994782326;
						num4 = num;
					}
					else
					{
						num = -994782327;
						num4 = num;
					}
					continue;
				}
				case 1:
					nsBrJlDcgrsSiyRBgUDzwjyYqlW = NsBrJlDcgrsSiyRBgUDzwjyYqlW;
					num3 = 0;
					num = -994782321;
					continue;
				case 6:
				{
					AList<VwSqzlFJAmDyHwxqJedQqGvDZcc> aList = nsBrJlDcgrsSiyRBgUDzwjyYqlW[num3];
					aList.RemoveAll(oewZTOLXspRuokzGUBpMLTFgPq2.cDSmgiCzXkqXRRvwqgCxvYjDHkF);
					num = -994782329;
					continue;
				}
				case 2:
				{
					int num2;
					if (oewZTOLXspRuokzGUBpMLTFgPq2.CcfTFbvLTcqsiXVrUOCJWGLeCzX > ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.maxActionId)
					{
						num = -994782328;
						num2 = num;
					}
					else
					{
						num = -994782322;
						num2 = num;
					}
					continue;
				}
				case 4:
					oewZTOLXspRuokzGUBpMLTFgPq2.uZqPISCyPgGPOetNKiFUKtuJqjV = P_1;
					oewZTOLXspRuokzGUBpMLTFgPq2.CcfTFbvLTcqsiXVrUOCJWGLeCzX = P_2;
					if (!WktzUSAcjulBYRNUcifkLEmijRhD)
					{
						return;
					}
					goto case 2;
				default:
					xAOiihInWikCVtmcfXvKmtoXGlhc();
					return;
				}
				break;
			}
		}
	}

	public void FJHNCYGYhfbNGgXMnQKRPLpDCwz(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		UjHCPXDOhgoPnHYkjEtVhlMNpQOR ujHCPXDOhgoPnHYkjEtVhlMNpQOR = default(UjHCPXDOhgoPnHYkjEtVhlMNpQOR);
		int num2 = default(int);
		AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[] nsBrJlDcgrsSiyRBgUDzwjyYqlW = default(AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[]);
		while (true)
		{
			int num = 1514846752;
			while (true)
			{
				switch (num ^ 0x5A4ABA25)
				{
				case 2:
					break;
				case 8:
					if (ujHCPXDOhgoPnHYkjEtVhlMNpQOR.CcfTFbvLTcqsiXVrUOCJWGLeCzX > ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.maxActionId)
					{
						return;
					}
					goto case 0;
				case 4:
					num2++;
					num = 1514846758;
					continue;
				case 5:
					ujHCPXDOhgoPnHYkjEtVhlMNpQOR = new UjHCPXDOhgoPnHYkjEtVhlMNpQOR();
					num = 1514846755;
					continue;
				case 9:
					ujHCPXDOhgoPnHYkjEtVhlMNpQOR.zKveCvyuxNpTsuNgJMSufHIXiLC = P_2;
					num = 1514846767;
					continue;
				case 6:
					ujHCPXDOhgoPnHYkjEtVhlMNpQOR.RERAhLRQKJhiOXbllLXxmBeUAhn = P_0;
					ujHCPXDOhgoPnHYkjEtVhlMNpQOR.uZqPISCyPgGPOetNKiFUKtuJqjV = P_1;
					num = 1514846764;
					continue;
				case 10:
					ujHCPXDOhgoPnHYkjEtVhlMNpQOR.CcfTFbvLTcqsiXVrUOCJWGLeCzX = P_3;
					num = 1514846756;
					continue;
				case 7:
				{
					AList<VwSqzlFJAmDyHwxqJedQqGvDZcc> aList = nsBrJlDcgrsSiyRBgUDzwjyYqlW[num2];
					aList.RemoveAll(ujHCPXDOhgoPnHYkjEtVhlMNpQOR.PZtmawkSplGmkRdgLTqYtUvEFGL);
					num = 1514846753;
					continue;
				}
				case 1:
					if (!WktzUSAcjulBYRNUcifkLEmijRhD)
					{
						return;
					}
					goto case 8;
				case 0:
					nsBrJlDcgrsSiyRBgUDzwjyYqlW = NsBrJlDcgrsSiyRBgUDzwjyYqlW;
					num2 = 0;
					num = 1514846758;
					continue;
				default:
					if (num2 >= nsBrJlDcgrsSiyRBgUDzwjyYqlW.Length)
					{
						xAOiihInWikCVtmcfXvKmtoXGlhc();
						return;
					}
					goto case 7;
				}
				break;
			}
		}
	}

	public void FJHNCYGYhfbNGgXMnQKRPLpDCwz(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		rMYZvqkofqHpKhFDzZkZPRWTlZJM rMYZvqkofqHpKhFDzZkZPRWTlZJM2 = default(rMYZvqkofqHpKhFDzZkZPRWTlZJM);
		AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[] nsBrJlDcgrsSiyRBgUDzwjyYqlW = default(AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[]);
		int num2 = default(int);
		while (true)
		{
			int num = -70122944;
			while (true)
			{
				switch (num ^ -70122943)
				{
				case 0:
					break;
				case 1:
					rMYZvqkofqHpKhFDzZkZPRWTlZJM2 = new rMYZvqkofqHpKhFDzZkZPRWTlZJM();
					rMYZvqkofqHpKhFDzZkZPRWTlZJM2.RERAhLRQKJhiOXbllLXxmBeUAhn = P_0;
					rMYZvqkofqHpKhFDzZkZPRWTlZJM2.uZqPISCyPgGPOetNKiFUKtuJqjV = P_1;
					rMYZvqkofqHpKhFDzZkZPRWTlZJM2.zKveCvyuxNpTsuNgJMSufHIXiLC = P_2;
					num = -70122940;
					continue;
				case 6:
					nsBrJlDcgrsSiyRBgUDzwjyYqlW = NsBrJlDcgrsSiyRBgUDzwjyYqlW;
					num2 = 0;
					num = -70122941;
					continue;
				case 5:
					if (!WktzUSAcjulBYRNUcifkLEmijRhD)
					{
						return;
					}
					goto case 6;
				case 4:
					num2++;
					num = -70122941;
					continue;
				case 3:
				{
					AList<VwSqzlFJAmDyHwxqJedQqGvDZcc> aList = nsBrJlDcgrsSiyRBgUDzwjyYqlW[num2];
					aList.RemoveAll(rMYZvqkofqHpKhFDzZkZPRWTlZJM2.GWxlIRClTfIgKdUGWaKKaOhfXo);
					num = -70122939;
					continue;
				}
				case 2:
				{
					int num3;
					if (num2 >= nsBrJlDcgrsSiyRBgUDzwjyYqlW.Length)
					{
						num = -70122938;
						num3 = num;
					}
					else
					{
						num = -70122942;
						num3 = num;
					}
					continue;
				}
				default:
					xAOiihInWikCVtmcfXvKmtoXGlhc();
					return;
				}
				break;
			}
		}
	}

	public void FJHNCYGYhfbNGgXMnQKRPLpDCwz(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		iyNMOvaAjOyrCZQFqbwTIHdlxkC iyNMOvaAjOyrCZQFqbwTIHdlxkC2 = new iyNMOvaAjOyrCZQFqbwTIHdlxkC();
		iyNMOvaAjOyrCZQFqbwTIHdlxkC2.RERAhLRQKJhiOXbllLXxmBeUAhn = P_0;
		AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[] nsBrJlDcgrsSiyRBgUDzwjyYqlW = default(AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[]);
		int num2 = default(int);
		while (true)
		{
			int num = -246618153;
			while (true)
			{
				switch (num ^ -246618159)
				{
				case 5:
					break;
				default:
					return;
				case 9:
					num = -246618151;
					continue;
				case 3:
				{
					int num3;
					if (iyNMOvaAjOyrCZQFqbwTIHdlxkC2.CcfTFbvLTcqsiXVrUOCJWGLeCzX <= ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.maxActionId)
					{
						num = -246618157;
						num3 = num;
					}
					else
					{
						num = -246618154;
						num3 = num;
					}
					continue;
				}
				case 4:
				{
					AList<VwSqzlFJAmDyHwxqJedQqGvDZcc> aList = nsBrJlDcgrsSiyRBgUDzwjyYqlW[num2];
					aList.RemoveAll(iyNMOvaAjOyrCZQFqbwTIHdlxkC2.OUWODAyDSvJyCmFjETAaxyjEZvf);
					num = -246618160;
					continue;
				}
				case 6:
					iyNMOvaAjOyrCZQFqbwTIHdlxkC2.zKveCvyuxNpTsuNgJMSufHIXiLC = P_1;
					iyNMOvaAjOyrCZQFqbwTIHdlxkC2.CcfTFbvLTcqsiXVrUOCJWGLeCzX = P_2;
					if (!WktzUSAcjulBYRNUcifkLEmijRhD)
					{
						return;
					}
					goto case 3;
				case 8:
					if (num2 >= nsBrJlDcgrsSiyRBgUDzwjyYqlW.Length)
					{
						xAOiihInWikCVtmcfXvKmtoXGlhc();
						num = -246618159;
						continue;
					}
					goto case 4;
				case 1:
					num2++;
					num = -246618151;
					continue;
				case 7:
					return;
				case 2:
					nsBrJlDcgrsSiyRBgUDzwjyYqlW = NsBrJlDcgrsSiyRBgUDzwjyYqlW;
					num2 = 0;
					num = -246618152;
					continue;
				case 0:
					return;
				}
				break;
			}
		}
	}

	public void nympziBLtYDUiPlWNRoEGqbSPfa()
	{
		if (!WktzUSAcjulBYRNUcifkLEmijRhD)
		{
			return;
		}
		int num2 = default(int);
		while (true)
		{
			AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>[] nsBrJlDcgrsSiyRBgUDzwjyYqlW = NsBrJlDcgrsSiyRBgUDzwjyYqlW;
			int num = -818799378;
			while (true)
			{
				switch (num ^ -818799380)
				{
				case 5:
					num = -818799382;
					continue;
				default:
					return;
				case 1:
					if (num2 >= nsBrJlDcgrsSiyRBgUDzwjyYqlW.Length)
					{
						xAOiihInWikCVtmcfXvKmtoXGlhc();
						num = -818799384;
						continue;
					}
					goto case 7;
				case 3:
					num2++;
					num = -818799379;
					continue;
				case 2:
					num2 = 0;
					num = -818799380;
					continue;
				case 7:
				{
					AList<VwSqzlFJAmDyHwxqJedQqGvDZcc> aList = nsBrJlDcgrsSiyRBgUDzwjyYqlW[num2];
					aList.Clear();
					num = -818799377;
					continue;
				}
				case 0:
					num = -818799379;
					continue;
				case 6:
					break;
				case 4:
					return;
				}
				break;
			}
		}
	}

	private void xAOiihInWikCVtmcfXvKmtoXGlhc()
	{
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int num3 = -1117814452;
			while (true)
			{
				switch (num3 ^ -1117814451)
				{
				case 3:
					break;
				case 1:
					num3 = -1117814451;
					continue;
				case 2:
					num += NsBrJlDcgrsSiyRBgUDzwjyYqlW[num2]._count;
					num2++;
					num3 = -1117814451;
					continue;
				default:
					if (num2 >= NsBrJlDcgrsSiyRBgUDzwjyYqlW.Length)
					{
						agHbGfItBitHhxopNafYNRHURry = num;
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	[CompilerGenerated]
	private static AList<VwSqzlFJAmDyHwxqJedQqGvDZcc> VaXiwdqiGpsPuUKnwKghwdoUPBN()
	{
		return new AList<VwSqzlFJAmDyHwxqJedQqGvDZcc>();
	}
}
