using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class RcSeSPqNxZpeyVpTsiApgswOCre
{
	public class urJZtuzvpYiFTOvUJGjRAfTIzeN
	{
		public readonly Action<InputActionEventData> HzZFsJBNhBsTgfILUpiOFxjNBIZC;

		public readonly UpdateLoopType cmiDdQAFcgEckBbjnNTFEbMKLqrn;

		public readonly InputActionEventType bYryFveaMHbdEpGAizfbOdkGnDs;

		public readonly int ACjpllpkcaGYOMYTzhdQxIrphnx;

		public readonly bool extFJbBZhjfQRoqyqvbqnmZTxro;

		public float[] JgRxyhkfPPKBXzEhFhFlmrHsgLu;

		public urJZtuzvpYiFTOvUJGjRAfTIzeN(Action<InputActionEventData> @delegate, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			cmiDdQAFcgEckBbjnNTFEbMKLqrn = updateLoop;
			bYryFveaMHbdEpGAizfbOdkGnDs = eventType;
			ACjpllpkcaGYOMYTzhdQxIrphnx = actionId;
			HzZFsJBNhBsTgfILUpiOFxjNBIZC = @delegate;
			fIWWXnJceMxEPlvFfSBxzRqYTYd(arguments);
			switch (eventType)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				extFJbBZhjfQRoqyqvbqnmZTxro = true;
				break;
			}
		}

		public bool HHnPZysvgRbDZcckgGKgBLLhiYb(int P_0, out float P_1)
		{
			if (JgRxyhkfPPKBXzEhFhFlmrHsgLu != null)
			{
				if (JgRxyhkfPPKBXzEhFhFlmrHsgLu.Length > P_0)
				{
					P_1 = JgRxyhkfPPKBXzEhFhFlmrHsgLu[P_0];
					return true;
				}
				goto IL_0013;
			}
			goto IL_0031;
			IL_0018:
			int num;
			switch (num ^ -1591221895)
			{
			case 2:
				break;
			case 1:
				goto IL_0031;
			default:
				return false;
			}
			goto IL_0013;
			IL_0031:
			P_1 = 0f;
			num = -1591221895;
			goto IL_0018;
			IL_0013:
			num = -1591221896;
			goto IL_0018;
		}

		private void fIWWXnJceMxEPlvFfSBxzRqYTYd(object[] P_0)
		{
			InputActionEventType inputActionEventType = bYryFveaMHbdEpGAizfbOdkGnDs;
			if (inputActionEventType <= InputActionEventType.NegativeButtonPressedForTimeJustReleased)
			{
				switch (inputActionEventType)
				{
				case InputActionEventType.ButtonPressedForTime:
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				case InputActionEventType.NegativeButtonPressedForTime:
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
					goto IL_019d;
				case InputActionEventType.ButtonDoublePressed:
				case InputActionEventType.ButtonJustDoublePressed:
				case InputActionEventType.NegativeButtonDoublePressed:
				case InputActionEventType.NegativeButtonJustDoublePressed:
					goto IL_01f1;
				case InputActionEventType.ButtonJustPressedForTime:
				case InputActionEventType.NegativeButtonJustPressedForTime:
					goto IL_026d;
				}
				goto IL_0048;
			}
			goto IL_029e;
			IL_026d:
			int num;
			int num2;
			if (P_0 == null)
			{
				num = 800137647;
				num2 = num;
			}
			else
			{
				num = 800137649;
				num2 = num;
			}
			goto IL_004d;
			IL_0048:
			num = 800137638;
			goto IL_004d;
			IL_004d:
			while (true)
			{
				switch (num ^ 0x2FB121BA)
				{
				case 19:
					break;
				default:
					return;
				case 5:
					if (P_0[0] is int)
					{
						JgRxyhkfPPKBXzEhFhFlmrHsgLu[0] = (int)P_0[0];
						return;
					}
					goto case 1;
				case 1:
					throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", bYryFveaMHbdEpGAizfbOdkGnDs, "\". Argument 0 (optional): time [float]"));
				case 23:
					throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", bYryFveaMHbdEpGAizfbOdkGnDs, "\". Argument 1 (optional): expireIn [float]"));
				case 21:
					throw new Exception(string.Concat("Wrong number of arguments passed for Input event type \"", bYryFveaMHbdEpGAizfbOdkGnDs, "\". Requires 1 argument: time [float]"));
				case 25:
					if (P_0[0] is int)
					{
						JgRxyhkfPPKBXzEhFhFlmrHsgLu[0] = (int)P_0[0];
						num = 800137640;
						continue;
					}
					goto case 0;
				case 2:
					goto IL_019d;
				case 12:
					JgRxyhkfPPKBXzEhFhFlmrHsgLu = new float[1];
					if (P_0[0] is float)
					{
						JgRxyhkfPPKBXzEhFhFlmrHsgLu[0] = (float)P_0[0];
						return;
					}
					goto case 5;
				case 22:
					goto IL_01f1;
				case 26:
					JgRxyhkfPPKBXzEhFhFlmrHsgLu = new float[1];
					num = 800137660;
					continue;
				case 14:
					return;
				case 15:
					JgRxyhkfPPKBXzEhFhFlmrHsgLu = new float[2];
					if (P_0[0] is float)
					{
						JgRxyhkfPPKBXzEhFhFlmrHsgLu[0] = (float)P_0[0];
						num = 800137633;
						continue;
					}
					goto case 25;
				case 28:
					return;
				case 4:
					goto IL_026d;
				case 11:
					goto IL_0284;
				case 17:
					goto IL_029e;
				case 20:
					return;
				case 3:
					return;
				case 18:
					if (P_0.Length > 1)
					{
						if (P_0[1] is float)
						{
							JgRxyhkfPPKBXzEhFhFlmrHsgLu[1] = (float)P_0[1];
							num = 800137657;
							continue;
						}
						goto case 10;
					}
					return;
				case 13:
					if (inputActionEventType != InputActionEventType.NegativeButtonDoublePressJustReleased)
					{
						return;
					}
					goto IL_01f1;
				case 27:
					num = 800137640;
					continue;
				case 16:
					throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", bYryFveaMHbdEpGAizfbOdkGnDs, "\". Argument 0: time [float]"));
				case 0:
					throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", bYryFveaMHbdEpGAizfbOdkGnDs, "\". Argument 0: time [float]"));
				case 6:
					goto IL_0371;
				case 8:
					goto IL_038f;
				case 9:
					if (P_0[0] is int)
					{
						JgRxyhkfPPKBXzEhFhFlmrHsgLu[0] = (int)P_0[0];
						num = 800137646;
						continue;
					}
					goto case 16;
				case 10:
					if (P_0[1] is int)
					{
						JgRxyhkfPPKBXzEhFhFlmrHsgLu[1] = (int)P_0[1];
						return;
					}
					goto case 23;
				case 24:
					JgRxyhkfPPKBXzEhFhFlmrHsgLu[0] = (float)P_0[0];
					return;
				case 7:
					return;
				}
				break;
				IL_0371:
				int num3;
				if (P_0[0] is float)
				{
					num = 800137634;
					num3 = num;
				}
				else
				{
					num = 800137651;
					num3 = num;
				}
				continue;
				IL_0284:
				int num4;
				if (P_0.Length >= 1)
				{
					num = 800137632;
					num4 = num;
				}
				else
				{
					num = 800137647;
					num4 = num;
				}
			}
			goto IL_0048;
			IL_019d:
			if (P_0 != null)
			{
				int num5;
				if (P_0.Length < 1)
				{
					num = 800137650;
					num5 = num;
				}
				else
				{
					num = 800137653;
					num5 = num;
				}
				goto IL_004d;
			}
			goto IL_038f;
			IL_038f:
			throw new Exception(string.Concat("Wrong number of arguments passed for Input event type \"", bYryFveaMHbdEpGAizfbOdkGnDs, "\". 1 required argument: time [float], 1 optional argument: expireIn [float]"));
			IL_029e:
			int num6;
			if (inputActionEventType == InputActionEventType.ButtonDoublePressJustReleased)
			{
				num = 800137644;
				num6 = num;
			}
			else
			{
				num = 800137655;
				num6 = num;
			}
			goto IL_004d;
			IL_01f1:
			if (P_0 != null)
			{
				int num7;
				if (P_0.Length < 1)
				{
					num = 800137652;
					num7 = num;
				}
				else
				{
					num = 800137654;
					num7 = num;
				}
				goto IL_004d;
			}
		}
	}

	private sealed class OAJKkfUzulehcabsbbVTBlsSujUd
	{
		public Action<InputActionEventData> HzZFsJBNhBsTgfILUpiOFxjNBIZC;

		public bool DqFRrsqiKuLpFLQFGFFEXACsCur(urJZtuzvpYiFTOvUJGjRAfTIzeN P_0)
		{
			return P_0.HzZFsJBNhBsTgfILUpiOFxjNBIZC == HzZFsJBNhBsTgfILUpiOFxjNBIZC;
		}
	}

	private sealed class vysKkNcMYDyppUFtpGGsUQJPdqx
	{
		public Action<InputActionEventData> HzZFsJBNhBsTgfILUpiOFxjNBIZC;

		public int ACjpllpkcaGYOMYTzhdQxIrphnx;

		public bool rExFhViEJkDXksjmEPKwiKLxmTWd(urJZtuzvpYiFTOvUJGjRAfTIzeN P_0)
		{
			if (P_0.HzZFsJBNhBsTgfILUpiOFxjNBIZC == HzZFsJBNhBsTgfILUpiOFxjNBIZC)
			{
				return P_0.ACjpllpkcaGYOMYTzhdQxIrphnx == ACjpllpkcaGYOMYTzhdQxIrphnx;
			}
			return false;
		}
	}

	private sealed class XBBxWpVDoqLZcGBMUbJkHfjirdZN
	{
		public Action<InputActionEventData> HzZFsJBNhBsTgfILUpiOFxjNBIZC;

		public UpdateLoopType cmiDdQAFcgEckBbjnNTFEbMKLqrn;

		public bool dfFFMrCDATBfhykpiowEkpSOGeZw(urJZtuzvpYiFTOvUJGjRAfTIzeN P_0)
		{
			if (P_0.HzZFsJBNhBsTgfILUpiOFxjNBIZC == HzZFsJBNhBsTgfILUpiOFxjNBIZC)
			{
				return P_0.cmiDdQAFcgEckBbjnNTFEbMKLqrn == cmiDdQAFcgEckBbjnNTFEbMKLqrn;
			}
			return false;
		}
	}

	private sealed class GxyWKzuEFtdngFBUcHQdbJQvvVX
	{
		public Action<InputActionEventData> HzZFsJBNhBsTgfILUpiOFxjNBIZC;

		public InputActionEventType bYryFveaMHbdEpGAizfbOdkGnDs;

		public bool eUCVDEowDGlfoEdOrDihsZPlNEM(urJZtuzvpYiFTOvUJGjRAfTIzeN P_0)
		{
			if (P_0.HzZFsJBNhBsTgfILUpiOFxjNBIZC == HzZFsJBNhBsTgfILUpiOFxjNBIZC)
			{
				return P_0.bYryFveaMHbdEpGAizfbOdkGnDs == bYryFveaMHbdEpGAizfbOdkGnDs;
			}
			return false;
		}
	}

	private sealed class NyDtzEiudvwEvfpUpkURzYXyVrU
	{
		public Action<InputActionEventData> HzZFsJBNhBsTgfILUpiOFxjNBIZC;

		public UpdateLoopType cmiDdQAFcgEckBbjnNTFEbMKLqrn;

		public int ACjpllpkcaGYOMYTzhdQxIrphnx;

		public bool qiOTAoIvOyuEtEQTNlVcWZwOpPx(urJZtuzvpYiFTOvUJGjRAfTIzeN P_0)
		{
			if (P_0.HzZFsJBNhBsTgfILUpiOFxjNBIZC == HzZFsJBNhBsTgfILUpiOFxjNBIZC && P_0.cmiDdQAFcgEckBbjnNTFEbMKLqrn == cmiDdQAFcgEckBbjnNTFEbMKLqrn)
			{
				return P_0.ACjpllpkcaGYOMYTzhdQxIrphnx == ACjpllpkcaGYOMYTzhdQxIrphnx;
			}
			return false;
		}
	}

	private sealed class gEUkfpOhNWKJMEaEWVXVXoeKIBF
	{
		public Action<InputActionEventData> HzZFsJBNhBsTgfILUpiOFxjNBIZC;

		public UpdateLoopType cmiDdQAFcgEckBbjnNTFEbMKLqrn;

		public InputActionEventType bYryFveaMHbdEpGAizfbOdkGnDs;

		public int ACjpllpkcaGYOMYTzhdQxIrphnx;

		public bool ZnzlQaqeElYgQCfGuwqXGNPDPVv(urJZtuzvpYiFTOvUJGjRAfTIzeN P_0)
		{
			if (P_0.HzZFsJBNhBsTgfILUpiOFxjNBIZC == HzZFsJBNhBsTgfILUpiOFxjNBIZC && P_0.cmiDdQAFcgEckBbjnNTFEbMKLqrn == cmiDdQAFcgEckBbjnNTFEbMKLqrn && P_0.ACjpllpkcaGYOMYTzhdQxIrphnx == ACjpllpkcaGYOMYTzhdQxIrphnx)
			{
				return P_0.bYryFveaMHbdEpGAizfbOdkGnDs == bYryFveaMHbdEpGAizfbOdkGnDs;
			}
			return false;
		}
	}

	private sealed class pUYwvloeffqSOPDUDRadlkEhgtmc
	{
		public Action<InputActionEventData> HzZFsJBNhBsTgfILUpiOFxjNBIZC;

		public UpdateLoopType cmiDdQAFcgEckBbjnNTFEbMKLqrn;

		public InputActionEventType bYryFveaMHbdEpGAizfbOdkGnDs;

		public bool YiGeLGkBCLQoAVDohgPXEvyBuJAl(urJZtuzvpYiFTOvUJGjRAfTIzeN P_0)
		{
			if (P_0.HzZFsJBNhBsTgfILUpiOFxjNBIZC == HzZFsJBNhBsTgfILUpiOFxjNBIZC && P_0.cmiDdQAFcgEckBbjnNTFEbMKLqrn == cmiDdQAFcgEckBbjnNTFEbMKLqrn)
			{
				return P_0.bYryFveaMHbdEpGAizfbOdkGnDs == bYryFveaMHbdEpGAizfbOdkGnDs;
			}
			return false;
		}
	}

	private sealed class ezTCowxEmTYbtkmfJWihupBygSX
	{
		public Action<InputActionEventData> HzZFsJBNhBsTgfILUpiOFxjNBIZC;

		public InputActionEventType bYryFveaMHbdEpGAizfbOdkGnDs;

		public int ACjpllpkcaGYOMYTzhdQxIrphnx;

		public bool UpCfsDdoyxehYeffibyhMCGqVLLK(urJZtuzvpYiFTOvUJGjRAfTIzeN P_0)
		{
			if (P_0.HzZFsJBNhBsTgfILUpiOFxjNBIZC == HzZFsJBNhBsTgfILUpiOFxjNBIZC && P_0.ACjpllpkcaGYOMYTzhdQxIrphnx == ACjpllpkcaGYOMYTzhdQxIrphnx)
			{
				return P_0.bYryFveaMHbdEpGAizfbOdkGnDs == bYryFveaMHbdEpGAizfbOdkGnDs;
			}
			return false;
		}
	}

	private static urJZtuzvpYiFTOvUJGjRAfTIzeN[] pxbqvstlohWlAOBtcrjeeGnLcaA;

	private bool UUnypIIfQihusKKsRGbhsEYxCLL;

	private AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[] TQLpIfZTRhgRGbpbDgZkBWWJfNa;

	private int[] ImFGdOXMInuxfpSVahYMsCSRKtC;

	private int wuSeOYhawkWvOhibVCNpWJYbqcJ;

	public int uvLjcnQqosrrPsERyMWJozjFDBK;

	[CompilerGenerated]
	private static Func<AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>> TblfxMGFSPowbRLCNkMeDtWBtrTm;

	static RcSeSPqNxZpeyVpTsiApgswOCre()
	{
		pxbqvstlohWlAOBtcrjeeGnLcaA = new urJZtuzvpYiFTOvUJGjRAfTIzeN[100];
	}

	private void SdmfoteCDVoXNaSlWEvRMBbwmDy()
	{
		if (UUnypIIfQihusKKsRGbhsEYxCLL)
		{
			return;
		}
		int num3 = default(int);
		int num4 = default(int);
		while (true)
		{
			IList<InputAction> actions = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.Actions;
			int num;
			if (actions == null)
			{
				num = -1566134030;
				goto IL_0011;
			}
			int num2 = actions.Count;
			goto IL_00e2;
			IL_0011:
			while (true)
			{
				switch (num ^ -1566134030)
				{
				case 5:
					num = -1566134031;
					continue;
				case 4:
					ImFGdOXMInuxfpSVahYMsCSRKtC = new int[ReInput.lUCgcEIquFfuykgBneGrfARQlcR.maxActionId + 1];
					ArrayTools.Populate(TQLpIfZTRhgRGbpbDgZkBWWJfNa, 0, TQLpIfZTRhgRGbpbDgZkBWWJfNa.Length, () => new AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>());
					num3 = 0;
					num = -1566134029;
					continue;
				case 1:
					num = -1566134027;
					continue;
				case 3:
					break;
				case 6:
					ImFGdOXMInuxfpSVahYMsCSRKtC[actions[num3].id] = num3;
					num3++;
					num = -1566134027;
					continue;
				case 0:
					goto IL_00d9;
				case 7:
					if (num3 >= num4)
					{
						wuSeOYhawkWvOhibVCNpWJYbqcJ = num4;
						num = -1566134032;
						continue;
					}
					goto case 6;
				default:
					UUnypIIfQihusKKsRGbhsEYxCLL = true;
					return;
				}
				break;
			}
			continue;
			IL_00d9:
			num2 = 0;
			goto IL_00e2;
			IL_00e2:
			num4 = num2;
			TQLpIfZTRhgRGbpbDgZkBWWJfNa = new AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[num4 + 1];
			num = -1566134026;
			goto IL_0011;
		}
	}

	public void VRoGSIfXLonnVCkEUMpLUDgeolgZ(juUkCOtINcePpkOEZitZVEIfgiwq P_0, UpdateLoopType P_1)
	{
		AList<urJZtuzvpYiFTOvUJGjRAfTIzeN> aList = TQLpIfZTRhgRGbpbDgZkBWWJfNa[ImFGdOXMInuxfpSVahYMsCSRKtC[P_0.qxoYaUQyNIsvDIFklnqXHPrHJLd]];
		int num = 0;
		urJZtuzvpYiFTOvUJGjRAfTIzeN urJZtuzvpYiFTOvUJGjRAfTIzeN2 = default(urJZtuzvpYiFTOvUJGjRAfTIzeN);
		bool flag = default(bool);
		InputActionEventType bYryFveaMHbdEpGAizfbOdkGnDs = default(InputActionEventType);
		float num6 = default(float);
		float num13 = default(float);
		int count = default(int);
		int num7 = default(int);
		float num5 = default(float);
		float num9 = default(float);
		float num4 = default(float);
		while (true)
		{
			int num2 = 139465807;
			while (true)
			{
				int num11;
				float num12;
				float num14;
				float num15;
				float num16;
				float num20;
				float num22;
				float num23;
				switch (num2 ^ 0x850147D)
				{
				case 80:
					break;
				case 74:
					if (urJZtuzvpYiFTOvUJGjRAfTIzeN2 != null)
					{
						num2 = 139465824;
						continue;
					}
					goto IL_0c14;
				case 16:
					if (P_0.cGPAZhRoZybdYmPyydBfiaWgoJDG())
					{
						num2 = 139465802;
						continue;
					}
					goto case 12;
				case 54:
					goto IL_01e6;
				case 13:
					if (P_0.WfZeMfhNAoMJIXMavAKrtJsNDWbF())
					{
						flag = true;
					}
					goto case 12;
				case 93:
					flag = true;
					goto case 12;
				case 57:
					goto IL_0250;
				case 0:
					goto IL_0268;
				case 25:
					goto IL_027d;
				case 94:
					goto IL_029a;
				case 8:
					flag = true;
					goto case 12;
				case 91:
					flag = true;
					num2 = 139465816;
					continue;
				case 66:
					flag = true;
					goto case 12;
				case 20:
					goto IL_031c;
				case 86:
					goto IL_0331;
				case 51:
					goto IL_034b;
				case 68:
					goto IL_0386;
				case 2:
					goto IL_0393;
				case 23:
					goto IL_03b0;
				case 70:
					bYryFveaMHbdEpGAizfbOdkGnDs = urJZtuzvpYiFTOvUJGjRAfTIzeN2.bYryFveaMHbdEpGAizfbOdkGnDs;
					num2 = 139465784;
					continue;
				case 35:
					if (P_0.ucXHXUUqxlkhvzJNWDPYfuRMgyD(num6))
					{
						num2 = 139465801;
						continue;
					}
					goto case 12;
				case 76:
					flag = true;
					goto case 12;
				case 96:
					if (P_0.OEdSYxLPfkelucpBeITTaFuMcTK(num13))
					{
						flag = true;
					}
					goto case 12;
				case 34:
					flag = true;
					goto case 12;
				case 64:
					goto IL_0456;
				case 81:
					goto IL_0473;
				case 31:
					if (urJZtuzvpYiFTOvUJGjRAfTIzeN2.cmiDdQAFcgEckBbjnNTFEbMKLqrn == P_1)
					{
						int num10;
						if (urJZtuzvpYiFTOvUJGjRAfTIzeN2.ACjpllpkcaGYOMYTzhdQxIrphnx < 0)
						{
							num2 = 139465759;
							num10 = num2;
						}
						else
						{
							num2 = 139465812;
							num10 = num2;
						}
						continue;
					}
					goto IL_0c14;
				case 1:
					goto IL_04bb;
				case 41:
					if (urJZtuzvpYiFTOvUJGjRAfTIzeN2.ACjpllpkcaGYOMYTzhdQxIrphnx == P_0.qxoYaUQyNIsvDIFklnqXHPrHJLd)
					{
						num2 = 139465759;
						continue;
					}
					goto IL_0c14;
				case 28:
					aList = TQLpIfZTRhgRGbpbDgZkBWWJfNa[wuSeOYhawkWvOhibVCNpWJYbqcJ];
					num2 = 139465779;
					continue;
				case 43:
					goto IL_050c;
				case 5:
					goto IL_0529;
				case 99:
					goto IL_0546;
				case 56:
					goto IL_0574;
				case 79:
					goto IL_0599;
				case 67:
					goto IL_05bd;
				case 75:
					goto IL_05d6;
				case 46:
					goto IL_05ee;
				case 87:
					goto IL_0603;
				case 71:
					goto IL_0618;
				case 77:
					goto IL_0635;
				case 39:
					flag = true;
					goto case 12;
				case 83:
					goto IL_0680;
				case 32:
					flag = true;
					num2 = 139465769;
					continue;
				case 10:
					goto IL_06af;
				case 78:
				{
					count = aList._count;
					int num18;
					if (pxbqvstlohWlAOBtcrjeeGnLcaA.Length < count)
					{
						num2 = 139465775;
						num18 = num2;
					}
					else
					{
						num2 = 139465810;
						num18 = num2;
					}
					continue;
				}
				case 29:
					if (P_0.iAgWGEzWxcyhtWsopRkEhQeyLjM)
					{
						goto case 31;
					}
					if (urJZtuzvpYiFTOvUJGjRAfTIzeN2.extFJbBZhjfQRoqyqvbqnmZTxro)
					{
						num2 = 139465826;
						continue;
					}
					goto IL_0c14;
				case 7:
					goto IL_070a;
				case 6:
					flag = true;
					num2 = 139465813;
					continue;
				case 42:
					flag = true;
					goto case 12;
				case 98:
					flag = false;
					num2 = 139465787;
					continue;
				case 65:
					goto IL_0767;
				case 11:
					urJZtuzvpYiFTOvUJGjRAfTIzeN2 = pxbqvstlohWlAOBtcrjeeGnLcaA[num7];
					num2 = 139465783;
					continue;
				case 26:
					goto IL_0797;
				case 48:
				{
					int num19;
					if (num == 1)
					{
						num2 = 139465825;
						num19 = num2;
					}
					else
					{
						num2 = 139465779;
						num19 = num2;
					}
					continue;
				}
				case 52:
					flag = true;
					goto case 12;
				case 82:
					pxbqvstlohWlAOBtcrjeeGnLcaA = new urJZtuzvpYiFTOvUJGjRAfTIzeN[count + 50];
					num2 = 139465810;
					continue;
				case 63:
					switch (bYryFveaMHbdEpGAizfbOdkGnDs)
					{
					case InputActionEventType.NegativeButtonSinglePressed:
						break;
					case InputActionEventType.ButtonSinglePressJustReleased:
						goto IL_027d;
					case InputActionEventType.NegativeButtonDoublePressJustReleased:
						goto IL_029a;
					case InputActionEventType.ButtonJustSinglePressed:
						goto IL_0529;
					default:
						goto IL_0850;
					case InputActionEventType.NegativeButtonSinglePressJustReleased:
						goto IL_0899;
					case InputActionEventType.NegativeButtonJustSinglePressed:
						goto IL_09b8;
					case InputActionEventType.ButtonDoublePressJustReleased:
						goto IL_0a0d;
					case InputActionEventType.ButtonSinglePressed:
						goto IL_0bbe;
					}
					goto case 13;
				case 9:
					goto IL_085a;
				case 59:
					num2 = 139465849;
					continue;
				case 73:
					goto IL_087c;
				case 36:
					goto IL_0899;
				case 89:
					goto IL_08b6;
				case 62:
					goto IL_08cf;
				case 72:
					goto IL_08f3;
				case 30:
					flag = true;
					goto case 12;
				case 18:
					goto IL_0922;
				case 17:
					goto IL_094e;
				case 100:
					if (P_0.CDyaTaJIXcGhBvDctqVqeSYmNsx(num5))
					{
						flag = true;
						num2 = 139465830;
						continue;
					}
					goto case 12;
				case 24:
				{
					urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(1, out var num8);
					if (P_0.jmNRPvoFbexhblUyuiMQvmLaNaK(num9, num8))
					{
						flag = true;
					}
					goto case 12;
				}
				case 90:
					goto IL_09b8;
				case 95:
					num7 = 0;
					goto IL_0c3a;
				case 45:
					goto IL_09e6;
				case 44:
					flag = true;
					goto case 12;
				case 19:
					goto IL_0a0d;
				case 69:
					switch (bYryFveaMHbdEpGAizfbOdkGnDs)
					{
					case InputActionEventType.NegativeButtonJustShortPressed:
						break;
					case InputActionEventType.ButtonPressedForTime:
						goto IL_01e6;
					case InputActionEventType.NegativeButtonJustLongPressed:
						goto IL_0250;
					case InputActionEventType.ButtonJustReleased:
						goto IL_0268;
					case InputActionEventType.ButtonJustLongPressed:
						goto IL_031c;
					case InputActionEventType.AxisInactive:
						goto IL_0331;
					case InputActionEventType.NegativeButtonPressedForTime:
						goto IL_034b;
					case InputActionEventType.Update:
						goto IL_0386;
					case InputActionEventType.NegativeButtonJustPressed:
						goto IL_0393;
					case InputActionEventType.AxisRawActiveOrJustInactive:
						goto IL_03b0;
					case InputActionEventType.NegativeButtonShortPressed:
						goto IL_0456;
					case InputActionEventType.AxisRawActive:
						goto IL_0473;
					case InputActionEventType.ButtonRepeating:
						goto IL_04bb;
					case InputActionEventType.AxisRawInactive:
						goto IL_050c;
					case InputActionEventType.ButtonJustPressedForTime:
						goto IL_0546;
					case InputActionEventType.NegativeButtonJustDoublePressed:
						goto IL_0574;
					case InputActionEventType.NegativeButtonDoublePressed:
						goto IL_0599;
					case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
						goto IL_05bd;
					case InputActionEventType.ButtonJustShortPressed:
						goto IL_05d6;
					case InputActionEventType.NegativeButtonJustReleased:
						goto IL_05ee;
					case InputActionEventType.NegativeButtonShortPressJustReleased:
						goto IL_0603;
					case InputActionEventType.ButtonShortPressed:
						goto IL_0618;
					case InputActionEventType.AxisActiveOrJustInactive:
						goto IL_0635;
					case InputActionEventType.AxisActive:
						goto IL_0680;
					case InputActionEventType.ButtonJustPressed:
						goto IL_06af;
					case InputActionEventType.ButtonJustDoublePressed:
						goto IL_070a;
					case InputActionEventType.NegativeButtonPressed:
						goto IL_0767;
					case InputActionEventType.ButtonDoublePressed:
						goto IL_0797;
					case InputActionEventType.ButtonPressed:
						goto IL_085a;
					case InputActionEventType.ButtonLongPressJustReleased:
						goto IL_087c;
					case InputActionEventType.ButtonPressedForTimeJustReleased:
						goto IL_08b6;
					case InputActionEventType.ButtonShortPressJustReleased:
						goto IL_08cf;
					case InputActionEventType.NegativeButtonUnpressed:
						goto IL_08f3;
					case InputActionEventType.ButtonLongPressed:
						goto IL_0922;
					case InputActionEventType.NegativeButtonLongPressed:
						goto IL_094e;
					case InputActionEventType.ButtonUnpressed:
						goto IL_09e6;
					default:
						goto IL_0ad2;
					case InputActionEventType.NegativeButtonLongPressJustReleased:
						goto IL_0b1f;
					case InputActionEventType.NegativeButtonRepeating:
						goto IL_0b3c;
					case InputActionEventType.NegativeButtonJustPressedForTime:
						goto IL_0b9c;
					}
					goto case 16;
				case 97:
					flag = true;
					goto case 12;
				case 92:
					flag = true;
					goto case 12;
				case 38:
					flag = true;
					num2 = 139465842;
					continue;
				case 55:
					flag = true;
					goto case 12;
				case 22:
					goto IL_0b1f;
				case 61:
					goto IL_0b3c;
				case 47:
					if (count > 0)
					{
						Array.Copy(aList._items, pxbqvstlohWlAOBtcrjeeGnLcaA, count);
						num2 = 139465762;
						continue;
					}
					goto case 95;
				case 88:
				{
					urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(1, out var num3);
					if (P_0.DXkcQgzDXDwqfjqKEWeeiIsjEkL(num4, num3))
					{
						num2 = 139465809;
						continue;
					}
					goto case 12;
				}
				case 3:
					goto IL_0b9c;
				case 49:
					goto IL_0bbe;
				default:
					throw new NotImplementedException();
				case 12:
				case 14:
				case 15:
				case 21:
				case 27:
				case 33:
				case 37:
				case 40:
				case 53:
				case 58:
				case 60:
				case 84:
				case 85:
					try
					{
						if (flag)
						{
							InputActionEventData obj = P_0.FpPQbxOMrhEGzNLvreAPpBwxuzz(P_1);
							obj.eventType = urJZtuzvpYiFTOvUJGjRAfTIzeN2.bYryFveaMHbdEpGAizfbOdkGnDs;
							urJZtuzvpYiFTOvUJGjRAfTIzeN2.HzZFsJBNhBsTgfILUpiOFxjNBIZC(obj);
						}
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("Player input event callback", exception);
					}
					goto IL_0c14;
				case 50:
					goto IL_0c53;
					IL_050c:
					if (MathTools.ApproximatelyZero(P_0.jyWAvEiMviYlVTYdFOaVHgfjpXc()))
					{
						flag = true;
						num2 = 139465820;
						continue;
					}
					goto case 12;
					IL_0b9c:
					if (urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(0, out num5))
					{
						num2 = 139465753;
						continue;
					}
					goto IL_0c14;
					IL_029a:
					urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(0, out num6);
					num2 = 139465822;
					continue;
					IL_0b3c:
					if (P_0.ZxiIuRYtBDEJCMjqsaKVbuOFqEda())
					{
						flag = true;
					}
					goto case 12;
					IL_0b1f:
					if (P_0.jGCWDEuaegGYCmImHJEiHDpRWGB())
					{
						flag = true;
					}
					goto case 12;
					IL_0ad2:
					num2 = 139465794;
					continue;
					IL_09e6:
					if (!P_0.jFcZHuafkqlzijBvuFElJkopdfY())
					{
						num2 = 139465756;
						continue;
					}
					goto case 12;
					IL_027d:
					if (P_0.ksFbLuWovwSusHlHjefsFuJGTK())
					{
						flag = true;
					}
					goto case 12;
					IL_04bb:
					if (P_0.XOsefyWDHwZOXjmpVlXGYKJafdt())
					{
						flag = true;
					}
					goto case 12;
					IL_094e:
					if (P_0.oMxTTcjOLMYEoYDddFPmgSxilnH())
					{
						num2 = 139465777;
						continue;
					}
					goto case 12;
					IL_0922:
					if (P_0.npfgXZtKMFFklVbTJfFAvKLyliC())
					{
						flag = true;
					}
					goto case 12;
					IL_0268:
					if (P_0.QNRTkSkGFuwIIacWXFtSgclWddbW())
					{
						num2 = 139465760;
						continue;
					}
					goto case 12;
					IL_08f3:
					if (!P_0.GjQmURQfLsUJtlDpxsliLlcucXv())
					{
						flag = true;
					}
					goto case 12;
					IL_0c14:
					num7++;
					goto IL_0c18;
					IL_08cf:
					if (P_0.SWCZiMymsQdLThvSsmwiALEkBbK())
					{
						num2 = 139465851;
						continue;
					}
					goto case 12;
					IL_0250:
					if (P_0.rcVJaTxSByOtwqWKUaiYAkfAyxL())
					{
						flag = true;
						num2 = 139465800;
						continue;
					}
					goto case 12;
					IL_08b6:
					if (urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(0, out num9))
					{
						num2 = 139465829;
						continue;
					}
					goto IL_0c14;
					IL_0473:
					if (!MathTools.ApproximatelyZero(P_0.jyWAvEiMviYlVTYdFOaVHgfjpXc()))
					{
						flag = true;
						num2 = 139465841;
						continue;
					}
					goto case 12;
					IL_087c:
					if (P_0.saoXXohfyQyJUwjpBiSVZjfdbXy())
					{
						flag = true;
					}
					goto case 12;
					IL_0c18:
					num11 = 139465852;
					goto IL_0c1d;
					IL_085a:
					if (P_0.jFcZHuafkqlzijBvuFElJkopdfY())
					{
						flag = true;
						num2 = 139465832;
						continue;
					}
					goto case 12;
					IL_0456:
					if (P_0.PjVCYxGaFYdJXhjLQSraPNYqlkv())
					{
						flag = true;
					}
					goto case 12;
					IL_0bbe:
					if (P_0.qTwZgHDTVAWJghKpsdDNNalKTRt())
					{
						flag = true;
						num2 = 139465799;
						continue;
					}
					goto case 12;
					IL_0a0d:
					urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(0, out num12);
					if (P_0.ZMCGeiorCsJPKHuHAAUEkrZDYOT(num12))
					{
						num2 = 139465766;
						continue;
					}
					goto case 12;
					IL_09b8:
					if (P_0.RNCfZoiaVVeQzBKphLchHPwpEZqI())
					{
						flag = true;
					}
					goto case 12;
					IL_0899:
					if (P_0.zXrIaGSPAdFttfFXmjrycWpcxZhm())
					{
						flag = true;
					}
					goto case 12;
					IL_0850:
					num2 = 139465798;
					continue;
					IL_0797:
					urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(0, out num14);
					if (P_0.iTwfkmbsmuNlVtrJSWahfnhaZvd(num14))
					{
						num2 = 139465761;
						continue;
					}
					goto case 12;
					IL_0767:
					if (P_0.GjQmURQfLsUJtlDpxsliLlcucXv())
					{
						flag = true;
					}
					goto case 12;
					IL_0c1d:
					while (true)
					{
						switch (num11 ^ 0x850147D)
						{
						case 3:
							break;
						case 1:
							goto IL_0c3a;
						case 2:
							num++;
							num11 = 139465853;
							continue;
						default:
							goto IL_0c53;
						}
						break;
					}
					goto IL_0c18;
					IL_070a:
					urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(0, out num15);
					if (P_0.WECszamZhCGBaugBWVuoFSBDSIn(num15))
					{
						num2 = 139465815;
						continue;
					}
					goto case 12;
					IL_03b0:
					if (!MathTools.ApproximatelyZero(P_0.jyWAvEiMviYlVTYdFOaVHgfjpXc()))
					{
						goto case 34;
					}
					if (!MathTools.ApproximatelyZero(P_0.oGbFPxyeivBtXNjbFKjlfCTbxSU()))
					{
						num2 = 139465823;
						continue;
					}
					goto case 12;
					IL_01e6:
					if (urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(0, out num16))
					{
						urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(1, out var num17);
						if (P_0.wjcGKQZuBmrbfwBXXwRdXiTLDuF(num16, num17))
						{
							flag = true;
						}
						goto case 12;
					}
					goto IL_0c14;
					IL_0c53:
					if (num >= 2)
					{
						return;
					}
					goto case 48;
					IL_06af:
					if (P_0.onTOiISwdiwnVPNqdGBZbNYGehbR())
					{
						num2 = 139465821;
						continue;
					}
					goto case 12;
					IL_0393:
					if (P_0.GispJZAEfezEtdemUKdarjXvYVi())
					{
						flag = true;
					}
					goto case 12;
					IL_0680:
					if (!MathTools.ApproximatelyZero(P_0.yVcOttFFFEXExGWTsiXvWxyyabi()))
					{
						flag = true;
					}
					goto case 12;
					IL_0635:
					if (!MathTools.ApproximatelyZero(P_0.yVcOttFFFEXExGWTsiXvWxyyabi()))
					{
						goto case 38;
					}
					if (!MathTools.ApproximatelyZero(P_0.AjecSoCdxZoJeYzNvEDytVvgsEaJ()))
					{
						num2 = 139465819;
						continue;
					}
					goto case 12;
					IL_0386:
					flag = true;
					num2 = 139465843;
					continue;
					IL_034b:
					if (urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(0, out num20))
					{
						urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(1, out var num21);
						if (P_0.hgFujwoGsFfsjeIjlnOMWpEhXwA(num20, num21))
						{
							flag = true;
						}
						goto case 12;
					}
					goto IL_0c14;
					IL_0618:
					if (P_0.rcyyMPULmrKbLHvLwAnFfUFVPPR())
					{
						flag = true;
					}
					goto case 12;
					IL_0603:
					if (P_0.ddscAWCaYKgqaGgjOFzIJWfzTjkO())
					{
						num2 = 139465818;
						continue;
					}
					goto case 12;
					IL_0c3a:
					if (num7 < count)
					{
						goto case 11;
					}
					num11 = 139465855;
					goto IL_0c1d;
					IL_05ee:
					if (P_0.ZrNBCoHGXMCmZyMECcLNhxpdYovR())
					{
						num2 = 139465827;
						continue;
					}
					goto case 12;
					IL_0331:
					if (MathTools.ApproximatelyZero(P_0.yVcOttFFFEXExGWTsiXvWxyyabi()))
					{
						num2 = 139465791;
						continue;
					}
					goto case 12;
					IL_05d6:
					if (P_0.gYeTCyhGKkaVGgZezuemqGJatLX())
					{
						flag = true;
						num2 = 139465768;
						continue;
					}
					goto case 12;
					IL_05bd:
					if (urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(0, out num4))
					{
						num2 = 139465765;
						continue;
					}
					goto IL_0c14;
					IL_031c:
					if (P_0.uFlaryDYfyMDhMCsXKNCoPyChog())
					{
						num2 = 139465845;
						continue;
					}
					goto case 12;
					IL_0599:
					urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(0, out num13);
					num2 = 139465757;
					continue;
					IL_0574:
					urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(0, out num22);
					if (P_0.WvMfdYEiKbIIpujENcBAnywGvUbe(num22))
					{
						flag = true;
						num2 = 139465793;
						continue;
					}
					goto case 12;
					IL_0546:
					if (urJZtuzvpYiFTOvUJGjRAfTIzeN2.HHnPZysvgRbDZcckgGKgBLLhiYb(0, out num23))
					{
						if (P_0.miEXqrPenrbMiQxgAmdPATywugk(num23))
						{
							flag = true;
						}
						goto case 12;
					}
					goto IL_0c14;
					IL_0529:
					if (P_0.rWGwOgpOlZtlVSGUSNQagovTRCe())
					{
						flag = true;
					}
					goto case 12;
				}
				break;
			}
		}
	}

	public void molwHYloiMfWCHJFERCRuvnmrARS(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!UUnypIIfQihusKKsRGbhsEYxCLL)
		{
			SdmfoteCDVoXNaSlWEvRMBbwmDy();
		}
		urJZtuzvpYiFTOvUJGjRAfTIzeN item;
		try
		{
			if (P_3 > ReInput.lUCgcEIquFfuykgBneGrfARQlcR.maxActionId)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new urJZtuzvpYiFTOvUJGjRAfTIzeN(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			TQLpIfZTRhgRGbpbDgZkBWWJfNa[wuSeOYhawkWvOhibVCNpWJYbqcJ].Add(item);
			goto IL_0073;
		}
		goto IL_00a6;
		IL_0073:
		int num = -460968826;
		goto IL_0078;
		IL_00a6:
		TQLpIfZTRhgRGbpbDgZkBWWJfNa[ImFGdOXMInuxfpSVahYMsCSRKtC[P_3]].Add(item);
		num = -460968825;
		goto IL_0078;
		IL_0078:
		while (true)
		{
			switch (num ^ -460968825)
			{
			case 4:
				break;
			default:
				return;
			case 0:
				hGWOAzzdPgqArxWOUGyBKOfYjJZ();
				num = -460968828;
				continue;
			case 2:
				goto IL_00a6;
			case 1:
				num = -460968825;
				continue;
			case 3:
				return;
			}
			break;
		}
		goto IL_0073;
	}

	public void molwHYloiMfWCHJFERCRuvnmrARS(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!UUnypIIfQihusKKsRGbhsEYxCLL)
		{
			SdmfoteCDVoXNaSlWEvRMBbwmDy();
		}
		urJZtuzvpYiFTOvUJGjRAfTIzeN item;
		try
		{
			item = new urJZtuzvpYiFTOvUJGjRAfTIzeN(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		TQLpIfZTRhgRGbpbDgZkBWWJfNa[wuSeOYhawkWvOhibVCNpWJYbqcJ].Add(item);
		hGWOAzzdPgqArxWOUGyBKOfYjJZ();
	}

	public void TsDqYOIbChtRedvmCnjKwRJSExZ(Action<InputActionEventData> P_0)
	{
		OAJKkfUzulehcabsbbVTBlsSujUd oAJKkfUzulehcabsbbVTBlsSujUd = new OAJKkfUzulehcabsbbVTBlsSujUd();
		oAJKkfUzulehcabsbbVTBlsSujUd.HzZFsJBNhBsTgfILUpiOFxjNBIZC = P_0;
		if (!UUnypIIfQihusKKsRGbhsEYxCLL)
		{
			goto IL_0017;
		}
		goto IL_0061;
		IL_0017:
		int num = 1329752951;
		goto IL_001c;
		IL_001c:
		AList<urJZtuzvpYiFTOvUJGjRAfTIzeN> aList = default(AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>);
		int num2 = default(int);
		AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[] tQLpIfZTRhgRGbpbDgZkBWWJfNa = default(AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[]);
		while (true)
		{
			switch (num ^ 0x4F426B76)
			{
			case 9:
				break;
			default:
				return;
			case 2:
				hGWOAzzdPgqArxWOUGyBKOfYjJZ();
				num = 1329752950;
				continue;
			case 3:
				goto IL_0061;
			case 4:
				aList.RemoveAll(oAJKkfUzulehcabsbbVTBlsSujUd.DqFRrsqiKuLpFLQFGFFEXACsCur);
				num2++;
				num = 1329752944;
				continue;
			case 6:
				goto IL_0094;
			case 5:
				num = 1329752944;
				continue;
			case 8:
				num2 = 0;
				num = 1329752947;
				continue;
			case 7:
				aList = tQLpIfZTRhgRGbpbDgZkBWWJfNa[num2];
				num = 1329752946;
				continue;
			case 1:
				return;
			case 0:
				return;
			}
			break;
			IL_0094:
			int num3;
			if (num2 < tQLpIfZTRhgRGbpbDgZkBWWJfNa.Length)
			{
				num = 1329752945;
				num3 = num;
			}
			else
			{
				num = 1329752948;
				num3 = num;
			}
		}
		goto IL_0017;
		IL_0061:
		tQLpIfZTRhgRGbpbDgZkBWWJfNa = TQLpIfZTRhgRGbpbDgZkBWWJfNa;
		num = 1329752958;
		goto IL_001c;
	}

	public void TsDqYOIbChtRedvmCnjKwRJSExZ(Action<InputActionEventData> P_0, int P_1)
	{
		vysKkNcMYDyppUFtpGGsUQJPdqx vysKkNcMYDyppUFtpGGsUQJPdqx2 = new vysKkNcMYDyppUFtpGGsUQJPdqx();
		AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[] tQLpIfZTRhgRGbpbDgZkBWWJfNa = default(AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[]);
		int num2 = default(int);
		while (true)
		{
			int num = 1471907175;
			while (true)
			{
				switch (num ^ 0x57BB8564)
				{
				case 6:
					break;
				case 3:
					vysKkNcMYDyppUFtpGGsUQJPdqx2.HzZFsJBNhBsTgfILUpiOFxjNBIZC = P_0;
					num = 1471907173;
					continue;
				case 5:
				{
					AList<urJZtuzvpYiFTOvUJGjRAfTIzeN> aList = tQLpIfZTRhgRGbpbDgZkBWWJfNa[num2];
					aList.RemoveAll(vysKkNcMYDyppUFtpGGsUQJPdqx2.rExFhViEJkDXksjmEPKwiKLxmTWd);
					num2++;
					num = 1471907171;
					continue;
				}
				case 4:
				{
					int num3;
					if (vysKkNcMYDyppUFtpGGsUQJPdqx2.ACjpllpkcaGYOMYTzhdQxIrphnx > ReInput.lUCgcEIquFfuykgBneGrfARQlcR.maxActionId)
					{
						num = 1471907174;
						num3 = num;
					}
					else
					{
						num = 1471907172;
						num3 = num;
					}
					continue;
				}
				case 1:
				{
					vysKkNcMYDyppUFtpGGsUQJPdqx2.ACjpllpkcaGYOMYTzhdQxIrphnx = P_1;
					int num4;
					if (!UUnypIIfQihusKKsRGbhsEYxCLL)
					{
						num = 1471907180;
						num4 = num;
					}
					else
					{
						num = 1471907168;
						num4 = num;
					}
					continue;
				}
				case 8:
					return;
				case 0:
					tQLpIfZTRhgRGbpbDgZkBWWJfNa = TQLpIfZTRhgRGbpbDgZkBWWJfNa;
					num2 = 0;
					num = 1471907171;
					continue;
				case 2:
					return;
				default:
					if (num2 >= tQLpIfZTRhgRGbpbDgZkBWWJfNa.Length)
					{
						hGWOAzzdPgqArxWOUGyBKOfYjJZ();
						return;
					}
					goto case 5;
				}
				break;
			}
		}
	}

	public void TsDqYOIbChtRedvmCnjKwRJSExZ(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		XBBxWpVDoqLZcGBMUbJkHfjirdZN xBBxWpVDoqLZcGBMUbJkHfjirdZN = new XBBxWpVDoqLZcGBMUbJkHfjirdZN();
		xBBxWpVDoqLZcGBMUbJkHfjirdZN.HzZFsJBNhBsTgfILUpiOFxjNBIZC = P_0;
		xBBxWpVDoqLZcGBMUbJkHfjirdZN.cmiDdQAFcgEckBbjnNTFEbMKLqrn = P_1;
		AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[] tQLpIfZTRhgRGbpbDgZkBWWJfNa = default(AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[]);
		int num2 = default(int);
		while (true)
		{
			int num = -1239913913;
			while (true)
			{
				switch (num ^ -1239913914)
				{
				case 0:
					break;
				case 1:
					if (!UUnypIIfQihusKKsRGbhsEYxCLL)
					{
						return;
					}
					goto case 2;
				case 2:
					tQLpIfZTRhgRGbpbDgZkBWWJfNa = TQLpIfZTRhgRGbpbDgZkBWWJfNa;
					num2 = 0;
					num = -1239913918;
					continue;
				case 3:
				{
					AList<urJZtuzvpYiFTOvUJGjRAfTIzeN> aList = tQLpIfZTRhgRGbpbDgZkBWWJfNa[num2];
					aList.RemoveAll(xBBxWpVDoqLZcGBMUbJkHfjirdZN.dfFFMrCDATBfhykpiowEkpSOGeZw);
					num = -1239913917;
					continue;
				}
				case 5:
					num2++;
					num = -1239913918;
					continue;
				default:
					if (num2 >= tQLpIfZTRhgRGbpbDgZkBWWJfNa.Length)
					{
						hGWOAzzdPgqArxWOUGyBKOfYjJZ();
						return;
					}
					goto case 3;
				}
				break;
			}
		}
	}

	public void TsDqYOIbChtRedvmCnjKwRJSExZ(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		GxyWKzuEFtdngFBUcHQdbJQvvVX gxyWKzuEFtdngFBUcHQdbJQvvVX = new GxyWKzuEFtdngFBUcHQdbJQvvVX();
		gxyWKzuEFtdngFBUcHQdbJQvvVX.HzZFsJBNhBsTgfILUpiOFxjNBIZC = P_0;
		gxyWKzuEFtdngFBUcHQdbJQvvVX.bYryFveaMHbdEpGAizfbOdkGnDs = P_1;
		int num2 = default(int);
		AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[] tQLpIfZTRhgRGbpbDgZkBWWJfNa = default(AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[]);
		AList<urJZtuzvpYiFTOvUJGjRAfTIzeN> aList = default(AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>);
		while (true)
		{
			int num = -56577570;
			while (true)
			{
				switch (num ^ -56577571)
				{
				case 4:
					break;
				default:
					return;
				case 0:
					if (num2 >= tQLpIfZTRhgRGbpbDgZkBWWJfNa.Length)
					{
						hGWOAzzdPgqArxWOUGyBKOfYjJZ();
						num = -56577573;
						continue;
					}
					goto case 1;
				case 7:
					aList.RemoveAll(gxyWKzuEFtdngFBUcHQdbJQvvVX.eUCVDEowDGlfoEdOrDihsZPlNEM);
					num = -56577576;
					continue;
				case 5:
					num2++;
					num = -56577571;
					continue;
				case 2:
					tQLpIfZTRhgRGbpbDgZkBWWJfNa = TQLpIfZTRhgRGbpbDgZkBWWJfNa;
					num2 = 0;
					num = -56577571;
					continue;
				case 3:
					if (!UUnypIIfQihusKKsRGbhsEYxCLL)
					{
						return;
					}
					goto case 2;
				case 1:
					aList = tQLpIfZTRhgRGbpbDgZkBWWJfNa[num2];
					num = -56577574;
					continue;
				case 6:
					return;
				}
				break;
			}
		}
	}

	public void TsDqYOIbChtRedvmCnjKwRJSExZ(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		NyDtzEiudvwEvfpUpkURzYXyVrU nyDtzEiudvwEvfpUpkURzYXyVrU = default(NyDtzEiudvwEvfpUpkURzYXyVrU);
		AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[] tQLpIfZTRhgRGbpbDgZkBWWJfNa = default(AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[]);
		int num2 = default(int);
		while (true)
		{
			int num = -1616181241;
			while (true)
			{
				switch (num ^ -1616181245)
				{
				case 7:
					break;
				case 4:
					nyDtzEiudvwEvfpUpkURzYXyVrU = new NyDtzEiudvwEvfpUpkURzYXyVrU();
					num = -1616181237;
					continue;
				case 6:
					tQLpIfZTRhgRGbpbDgZkBWWJfNa = TQLpIfZTRhgRGbpbDgZkBWWJfNa;
					num = -1616181238;
					continue;
				case 5:
				{
					int num3;
					if (nyDtzEiudvwEvfpUpkURzYXyVrU.ACjpllpkcaGYOMYTzhdQxIrphnx <= ReInput.lUCgcEIquFfuykgBneGrfARQlcR.maxActionId)
					{
						num = -1616181243;
						num3 = num;
					}
					else
					{
						num = -1616181246;
						num3 = num;
					}
					continue;
				}
				case 9:
					num2 = 0;
					num = -1616181248;
					continue;
				case 0:
				{
					AList<urJZtuzvpYiFTOvUJGjRAfTIzeN> aList = tQLpIfZTRhgRGbpbDgZkBWWJfNa[num2];
					aList.RemoveAll(nyDtzEiudvwEvfpUpkURzYXyVrU.qiOTAoIvOyuEtEQTNlVcWZwOpPx);
					num2++;
					num = -1616181247;
					continue;
				}
				case 8:
					nyDtzEiudvwEvfpUpkURzYXyVrU.HzZFsJBNhBsTgfILUpiOFxjNBIZC = P_0;
					nyDtzEiudvwEvfpUpkURzYXyVrU.cmiDdQAFcgEckBbjnNTFEbMKLqrn = P_1;
					nyDtzEiudvwEvfpUpkURzYXyVrU.ACjpllpkcaGYOMYTzhdQxIrphnx = P_2;
					if (!UUnypIIfQihusKKsRGbhsEYxCLL)
					{
						return;
					}
					goto case 5;
				case 3:
					num = -1616181247;
					continue;
				case 1:
					return;
				default:
					if (num2 >= tQLpIfZTRhgRGbpbDgZkBWWJfNa.Length)
					{
						hGWOAzzdPgqArxWOUGyBKOfYjJZ();
						return;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	public void TsDqYOIbChtRedvmCnjKwRJSExZ(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		gEUkfpOhNWKJMEaEWVXVXoeKIBF gEUkfpOhNWKJMEaEWVXVXoeKIBF2 = new gEUkfpOhNWKJMEaEWVXVXoeKIBF();
		int num2 = default(int);
		AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[] tQLpIfZTRhgRGbpbDgZkBWWJfNa = default(AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[]);
		while (true)
		{
			int num = -1137695071;
			while (true)
			{
				switch (num ^ -1137695067)
				{
				case 7:
					break;
				case 4:
					gEUkfpOhNWKJMEaEWVXVXoeKIBF2.HzZFsJBNhBsTgfILUpiOFxjNBIZC = P_0;
					gEUkfpOhNWKJMEaEWVXVXoeKIBF2.cmiDdQAFcgEckBbjnNTFEbMKLqrn = P_1;
					gEUkfpOhNWKJMEaEWVXVXoeKIBF2.bYryFveaMHbdEpGAizfbOdkGnDs = P_2;
					gEUkfpOhNWKJMEaEWVXVXoeKIBF2.ACjpllpkcaGYOMYTzhdQxIrphnx = P_3;
					if (!UUnypIIfQihusKKsRGbhsEYxCLL)
					{
						return;
					}
					goto case 6;
				case 6:
					if (gEUkfpOhNWKJMEaEWVXVXoeKIBF2.ACjpllpkcaGYOMYTzhdQxIrphnx > ReInput.lUCgcEIquFfuykgBneGrfARQlcR.maxActionId)
					{
						return;
					}
					goto case 2;
				case 0:
					num2++;
					num = -1137695066;
					continue;
				case 3:
				{
					int num3;
					if (num2 < tQLpIfZTRhgRGbpbDgZkBWWJfNa.Length)
					{
						num = -1137695068;
						num3 = num;
					}
					else
					{
						num = -1137695072;
						num3 = num;
					}
					continue;
				}
				case 1:
				{
					AList<urJZtuzvpYiFTOvUJGjRAfTIzeN> aList = tQLpIfZTRhgRGbpbDgZkBWWJfNa[num2];
					aList.RemoveAll(gEUkfpOhNWKJMEaEWVXVXoeKIBF2.ZnzlQaqeElYgQCfGuwqXGNPDPVv);
					num = -1137695067;
					continue;
				}
				case 2:
					tQLpIfZTRhgRGbpbDgZkBWWJfNa = TQLpIfZTRhgRGbpbDgZkBWWJfNa;
					num2 = 0;
					num = -1137695066;
					continue;
				default:
					hGWOAzzdPgqArxWOUGyBKOfYjJZ();
					return;
				}
				break;
			}
		}
	}

	public void TsDqYOIbChtRedvmCnjKwRJSExZ(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		pUYwvloeffqSOPDUDRadlkEhgtmc pUYwvloeffqSOPDUDRadlkEhgtmc2 = new pUYwvloeffqSOPDUDRadlkEhgtmc();
		pUYwvloeffqSOPDUDRadlkEhgtmc2.HzZFsJBNhBsTgfILUpiOFxjNBIZC = P_0;
		AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[] tQLpIfZTRhgRGbpbDgZkBWWJfNa = default(AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[]);
		int num2 = default(int);
		AList<urJZtuzvpYiFTOvUJGjRAfTIzeN> aList = default(AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>);
		while (true)
		{
			int num = 459466102;
			while (true)
			{
				switch (num ^ 0x1B62E570)
				{
				case 3:
					break;
				default:
					return;
				case 6:
					pUYwvloeffqSOPDUDRadlkEhgtmc2.cmiDdQAFcgEckBbjnNTFEbMKLqrn = P_1;
					num = 459466103;
					continue;
				case 7:
					pUYwvloeffqSOPDUDRadlkEhgtmc2.bYryFveaMHbdEpGAizfbOdkGnDs = P_2;
					if (!UUnypIIfQihusKKsRGbhsEYxCLL)
					{
						return;
					}
					goto case 0;
				case 0:
					tQLpIfZTRhgRGbpbDgZkBWWJfNa = TQLpIfZTRhgRGbpbDgZkBWWJfNa;
					num2 = 0;
					num = 459466104;
					continue;
				case 1:
					if (num2 >= tQLpIfZTRhgRGbpbDgZkBWWJfNa.Length)
					{
						hGWOAzzdPgqArxWOUGyBKOfYjJZ();
						num = 459466101;
						continue;
					}
					goto case 4;
				case 8:
					num = 459466097;
					continue;
				case 2:
					aList.RemoveAll(pUYwvloeffqSOPDUDRadlkEhgtmc2.YiGeLGkBCLQoAVDohgPXEvyBuJAl);
					num2++;
					num = 459466097;
					continue;
				case 4:
					aList = tQLpIfZTRhgRGbpbDgZkBWWJfNa[num2];
					num = 459466098;
					continue;
				case 5:
					return;
				}
				break;
			}
		}
	}

	public void TsDqYOIbChtRedvmCnjKwRJSExZ(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		ezTCowxEmTYbtkmfJWihupBygSX ezTCowxEmTYbtkmfJWihupBygSX2 = new ezTCowxEmTYbtkmfJWihupBygSX();
		ezTCowxEmTYbtkmfJWihupBygSX2.HzZFsJBNhBsTgfILUpiOFxjNBIZC = P_0;
		ezTCowxEmTYbtkmfJWihupBygSX2.bYryFveaMHbdEpGAizfbOdkGnDs = P_1;
		ezTCowxEmTYbtkmfJWihupBygSX2.ACjpllpkcaGYOMYTzhdQxIrphnx = P_2;
		if (!UUnypIIfQihusKKsRGbhsEYxCLL)
		{
			return;
		}
		AList<urJZtuzvpYiFTOvUJGjRAfTIzeN> aList = default(AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>);
		int num2 = default(int);
		while (ezTCowxEmTYbtkmfJWihupBygSX2.ACjpllpkcaGYOMYTzhdQxIrphnx <= ReInput.lUCgcEIquFfuykgBneGrfARQlcR.maxActionId)
		{
			while (true)
			{
				IL_00a6:
				AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[] tQLpIfZTRhgRGbpbDgZkBWWJfNa = TQLpIfZTRhgRGbpbDgZkBWWJfNa;
				int num = 938111838;
				while (true)
				{
					switch (num ^ 0x37EA7358)
					{
					case 3:
						num = 938111834;
						continue;
					default:
						return;
					case 2:
						break;
					case 1:
						aList = tQLpIfZTRhgRGbpbDgZkBWWJfNa[num2];
						num = 938111836;
						continue;
					case 4:
						aList.RemoveAll(ezTCowxEmTYbtkmfJWihupBygSX2.UpCfsDdoyxehYeffibyhMCGqVLLK);
						num2++;
						num = 938111839;
						continue;
					case 5:
						goto IL_00a6;
					case 7:
						if (num2 >= tQLpIfZTRhgRGbpbDgZkBWWJfNa.Length)
						{
							hGWOAzzdPgqArxWOUGyBKOfYjJZ();
							num = 938111832;
							continue;
						}
						goto case 1;
					case 6:
						num2 = 0;
						num = 938111839;
						continue;
					case 0:
						return;
					}
					break;
				}
				break;
			}
		}
	}

	public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
	{
		if (!UUnypIIfQihusKKsRGbhsEYxCLL)
		{
			return;
		}
		int num2 = default(int);
		while (true)
		{
			AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>[] tQLpIfZTRhgRGbpbDgZkBWWJfNa = TQLpIfZTRhgRGbpbDgZkBWWJfNa;
			int num = 754689892;
			while (true)
			{
				switch (num ^ 0x2CFBA761)
				{
				case 6:
					num = 754689890;
					continue;
				default:
					return;
				case 3:
					break;
				case 5:
					num2 = 0;
					num = 754689891;
					continue;
				case 0:
					num2++;
					num = 754689891;
					continue;
				case 2:
					if (num2 >= tQLpIfZTRhgRGbpbDgZkBWWJfNa.Length)
					{
						hGWOAzzdPgqArxWOUGyBKOfYjJZ();
						num = 754689893;
						continue;
					}
					goto case 1;
				case 1:
				{
					AList<urJZtuzvpYiFTOvUJGjRAfTIzeN> aList = tQLpIfZTRhgRGbpbDgZkBWWJfNa[num2];
					aList.Clear();
					num = 754689889;
					continue;
				}
				case 4:
					return;
				}
				break;
			}
		}
	}

	private void hGWOAzzdPgqArxWOUGyBKOfYjJZ()
	{
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int num3;
			int num4;
			if (num2 >= TQLpIfZTRhgRGbpbDgZkBWWJfNa.Length)
			{
				num3 = -57934756;
				num4 = num3;
			}
			else
			{
				num3 = -57934753;
				num4 = num3;
			}
			while (true)
			{
				switch (num3 ^ -57934754)
				{
				case 3:
					num3 = -57934753;
					continue;
				case 1:
					num += TQLpIfZTRhgRGbpbDgZkBWWJfNa[num2]._count;
					num2++;
					num3 = -57934754;
					continue;
				case 0:
					break;
				default:
					uvLjcnQqosrrPsERyMWJozjFDBK = num;
					return;
				}
				break;
			}
		}
	}

	[CompilerGenerated]
	private static AList<urJZtuzvpYiFTOvUJGjRAfTIzeN> VkVEnvqvnnrwQZvVBVOgVDAFTJl()
	{
		return new AList<urJZtuzvpYiFTOvUJGjRAfTIzeN>();
	}
}
