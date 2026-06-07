using System;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal class TrPtHvDNhUzaBqlyMmTMOEWQxyO : KQSKrGwvnXLVcLDxrfneNLxBMJm, IDisposable, iflCBykpCtyCmFAlnduVbpFYFGW, CjjRDclXuvjouyeLLeBBHCfpqqbM
{
	public readonly int vgSbQnhkfGJDrjOShKPojdhsCSkQ;

	public readonly int ijxelHigybruBiYdNSiiNzGQTwsf;

	public readonly int LkoNLyiGljUAOYiLwFBXFsySPZWE;

	public readonly int LiJyBgKhjxmyhQbWqaNTKEOpkweF;

	public readonly short[] OVBrTyjMxbbynNijpHltuGkfSlx;

	private readonly ButtonLoopSet czgndLirlREMboiIRzUSAEaxWGk;

	public readonly short[] byfcXyixWDtaMUwhWbRtidJBqkS;

	public readonly short[] clDFxEJqCVKqLXpRLFcJkHcaWCOC;

	private bool qEBChkdMenIWbHajRwlLiEqfOWVs;

	public bool[] ButtonValues
	{
		get
		{
			if (czgndLirlREMboiIRzUSAEaxWGk.Current == null)
			{
				return null;
			}
			return czgndLirlREMboiIRzUSAEaxWGk.Current.effectiveValue;
		}
	}

	public int JoystickId
	{
		get
		{
			return qSUtKeYrVQsKSLtKzacvtYVJQgg;
		}
	}

	public int ButtonCount
	{
		get
		{
			return vgSbQnhkfGJDrjOShKPojdhsCSkQ;
		}
	}

	public int AxisCount
	{
		get
		{
			return ijxelHigybruBiYdNSiiNzGQTwsf;
		}
	}

	public int HatCount
	{
		get
		{
			return LkoNLyiGljUAOYiLwFBXFsySPZWE;
		}
	}

	public int BallCount
	{
		get
		{
			return LiJyBgKhjxmyhQbWqaNTKEOpkweF;
		}
	}

	public bool HasElements
	{
		get
		{
			if (vgSbQnhkfGJDrjOShKPojdhsCSkQ <= 0 && ijxelHigybruBiYdNSiiNzGQTwsf <= 0 && LkoNLyiGljUAOYiLwFBXFsySPZWE <= 0)
			{
				return LiJyBgKhjxmyhQbWqaNTKEOpkweF > 0;
			}
			return true;
		}
	}

	public InputSource InputSource
	{
		get
		{
			return InputSource.SDL2;
		}
	}

	public bool HasEverReceivedInput
	{
		get
		{
			return qEBChkdMenIWbHajRwlLiEqfOWVs;
		}
	}

	public TrPtHvDNhUzaBqlyMmTMOEWQxyO(YlWFkSrNjhWjdvjHemdfYAMOisT nativeJoystick, qNsaluFiUoLEvSsAIYUscPCZLjmQ joystickInfo)
		: this(nativeJoystick, joystickInfo, gNEAicDxLHkrFZgYqIFdMmtDmHv.PuCbofQgRbFngIhqGEvCTItySLuC)
	{
	}

	protected TrPtHvDNhUzaBqlyMmTMOEWQxyO(YlWFkSrNjhWjdvjHemdfYAMOisT nativeJoystick, qNsaluFiUoLEvSsAIYUscPCZLjmQ joystickInfo, gNEAicDxLHkrFZgYqIFdMmtDmHv type)
		: this(nativeJoystick, joystickInfo, type, joystickInfo.vgSbQnhkfGJDrjOShKPojdhsCSkQ, joystickInfo.ijxelHigybruBiYdNSiiNzGQTwsf, joystickInfo.LkoNLyiGljUAOYiLwFBXFsySPZWE, joystickInfo.LiJyBgKhjxmyhQbWqaNTKEOpkweF)
	{
	}

	protected TrPtHvDNhUzaBqlyMmTMOEWQxyO(CTgshCYPqlIJtNRsYGyXTYrAojb nativeDevice, qNsaluFiUoLEvSsAIYUscPCZLjmQ joystickInfo, gNEAicDxLHkrFZgYqIFdMmtDmHv type, int buttonCount, int axisCount, int hatCount, int ballCount)
		: base(nativeDevice, joystickInfo, type)
	{
		vgSbQnhkfGJDrjOShKPojdhsCSkQ = buttonCount;
		ijxelHigybruBiYdNSiiNzGQTwsf = axisCount;
		LkoNLyiGljUAOYiLwFBXFsySPZWE = hatCount;
		LiJyBgKhjxmyhQbWqaNTKEOpkweF = ballCount;
		if (axisCount > 0)
		{
			OVBrTyjMxbbynNijpHltuGkfSlx = new short[axisCount];
		}
		czgndLirlREMboiIRzUSAEaxWGk = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, buttonCount);
		if (hatCount > 0)
		{
			byfcXyixWDtaMUwhWbRtidJBqkS = new short[hatCount];
		}
		if (ballCount > 0)
		{
			clDFxEJqCVKqLXpRLFcJkHcaWCOC = new short[ballCount * 2];
		}
	}

	public void zxLhCcrlwKIIJANOaByFjYpjSot(OpPHOecnOFEyUhUbCJxiojmzacz P_0, byte P_1, short P_2, float P_3)
	{
		qEBChkdMenIWbHajRwlLiEqfOWVs = true;
		switch (P_0)
		{
		case OpPHOecnOFEyUhUbCJxiojmzacz.wKybpxkoZWaYEapGxBsAGbjTuDaO:
			goto IL_0076;
		case OpPHOecnOFEyUhUbCJxiojmzacz.WQofIGFEPMfSSrmflNjtUyWRexS:
			while (true)
			{
				IL_00a0:
				if (P_1 >= LkoNLyiGljUAOYiLwFBXFsySPZWE)
				{
					return;
				}
				while (true)
				{
					IL_00f9:
					byfcXyixWDtaMUwhWbRtidJBqkS[P_1] = P_2;
					int num = -1674068158;
					while (true)
					{
						switch (num ^ -1674068158)
						{
						case 3:
							num = -1674068160;
							continue;
						case 9:
							break;
						case 6:
							goto IL_0076;
						case 0:
							return;
						case 7:
							goto IL_008f;
						case 10:
							goto IL_00a0;
						case 5:
							goto IL_00b4;
						case 1:
							goto IL_00c8;
						case 2:
							goto IL_00e5;
						case 4:
							goto IL_00f9;
						default:
							goto end_IL_000a;
						}
						break;
					}
					break;
				}
				break;
			}
			goto IL_0065;
		case OpPHOecnOFEyUhUbCJxiojmzacz.qXvHnuHKYRcGCQFGfKUShsMcAES:
			goto IL_00b4;
		case OpPHOecnOFEyUhUbCJxiojmzacz.tGxrHTDCkRdlaRMIzxipqdsMQjr:
			goto IL_00e5;
			IL_00e5:
			if (P_1 >= vgSbQnhkfGJDrjOShKPojdhsCSkQ)
			{
				return;
			}
			goto IL_00c8;
			IL_00c8:
			czgndLirlREMboiIRzUSAEaxWGk.SetValue(P_1, P_2 > 0, P_3);
			return;
			IL_00b4:
			if (P_1 >= LiJyBgKhjxmyhQbWqaNTKEOpkweF)
			{
				return;
			}
			goto IL_008f;
			IL_008f:
			clDFxEJqCVKqLXpRLFcJkHcaWCOC[P_1] = P_2;
			return;
			IL_0076:
			if (P_1 >= ijxelHigybruBiYdNSiiNzGQTwsf)
			{
				return;
			}
			goto IL_0065;
			IL_0065:
			OVBrTyjMxbbynNijpHltuGkfSlx[P_1] = P_2;
			return;
			end_IL_000a:
			break;
		}
		throw new NotImplementedException();
	}

	public override void Update(UpdateLoopType P_0)
	{
		czgndLirlREMboiIRzUSAEaxWGk.SetUpdateLoop(P_0);
	}

	public override void UpdateFinished()
	{
		czgndLirlREMboiIRzUSAEaxWGk.Current.ClearWasTrueThisFrame();
	}

	public float GetAxisValue(int P_0)
	{
		if (P_0 >= 0)
		{
			while (true)
			{
				int num = -1000090323;
				while (true)
				{
					switch (num ^ -1000090321)
					{
					case 0:
						break;
					case 2:
						goto IL_0022;
					default:
						goto end_IL_0004;
					}
					break;
					IL_0022:
					if (P_0 >= ijxelHigybruBiYdNSiiNzGQTwsf)
					{
						num = -1000090322;
						continue;
					}
					return ipOGcKcVzcXMNUQKBbDNEKKEEqgE(OVBrTyjMxbbynNijpHltuGkfSlx[P_0]);
				}
				continue;
				end_IL_0004:
				break;
			}
		}
		return 0f;
	}

	public int GetAxisRawValue(int P_0)
	{
		if (P_0 < 0 || P_0 >= ijxelHigybruBiYdNSiiNzGQTwsf)
		{
			return 0;
		}
		return OVBrTyjMxbbynNijpHltuGkfSlx[P_0];
	}

	public bool GetButtonValue(int P_0)
	{
		if (P_0 < 0 || P_0 >= vgSbQnhkfGJDrjOShKPojdhsCSkQ)
		{
			return false;
		}
		return czgndLirlREMboiIRzUSAEaxWGk.Current.effectiveValue[P_0];
	}

	public int GetHatValue(int P_0)
	{
		if (P_0 >= 0)
		{
			while (true)
			{
				int num = 958285744;
				while (true)
				{
					switch (num ^ 0x391E47B2)
					{
					case 0:
						break;
					case 2:
						goto IL_0022;
					default:
						goto end_IL_0004;
					}
					break;
					IL_0022:
					if (P_0 >= LkoNLyiGljUAOYiLwFBXFsySPZWE)
					{
						num = 958285747;
						continue;
					}
					return eqhwntZbfKiegOFMKGzVPZCiLHF(byfcXyixWDtaMUwhWbRtidJBqkS[P_0]);
				}
				continue;
				end_IL_0004:
				break;
			}
		}
		return -1;
	}

	public Vector2 GetBallValue(int P_0)
	{
		return Vector2.zero;
	}

	protected void rrGXmcfcGpJYAsSkHwJrDWDYMxo(YlWFkSrNjhWjdvjHemdfYAMOisT P_0)
	{
		if (!base.IsValid)
		{
			return;
		}
		IntPtr intPtr = default(IntPtr);
		while (true)
		{
			int num;
			int num2;
			if (ghVaXMJBYQVankSHALdOAwQaFIx.ZPMKSBUHrfCQkonGMAKItzvHWuN(P_0) > 0)
			{
				num = 1004365638;
				num2 = num;
			}
			else
			{
				num = 1004365635;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ 0x3BDD6744)
				{
				case 0:
					num = 1004365634;
					continue;
				case 2:
					intPtr = ghVaXMJBYQVankSHALdOAwQaFIx.qbiAcjswLoeZdKaVgUEDoGLAKeI(P_0);
					if (intPtr == IntPtr.Zero)
					{
						return;
					}
					goto case 1;
				case 4:
					ghVaXMJBYQVankSHALdOAwQaFIx.VmQMSGigilPjoCTPAqfgbZEuUqn(intPtr);
					return;
				case 6:
					break;
				case 1:
				{
					int num3;
					if (ghVaXMJBYQVankSHALdOAwQaFIx.JpFDUeeXWWYaSoTFMSRbEYgCRxVq(intPtr) != 0)
					{
						num = 1004365632;
						num3 = num;
					}
					else
					{
						num = 1004365639;
						num3 = num;
					}
					continue;
				}
				case 7:
					return;
				case 3:
					fbNHUECJImlgpacqjiGPOgCioAyD = new TvDLpHZXfgNqfKNPBUsmzhbQvol(intPtr);
					NaHRvVMfZQevYSVdQxnFJgyUAub = true;
					UJzeRUdeCpNKzLtMIYzEJzkpCuj = ghVaXMJBYQVankSHALdOAwQaFIx.blHJRYqvooUTgGyLLkjigwxkdmi(fbNHUECJImlgpacqjiGPOgCioAyD) > 0;
					if (UJzeRUdeCpNKzLtMIYzEJzkpCuj)
					{
						QTcZLynCWHLLppDxcAAAPxKXLEc = 2;
						num = 1004365633;
						continue;
					}
					goto default;
				default:
					TsKSsROPYZmdUDwLjfPfaVETXQn = new float[QTcZLynCWHLLppDxcAAAPxKXLEc];
					return;
				}
				break;
			}
		}
	}

	protected override void InitializeHaptic()
	{
		rrGXmcfcGpJYAsSkHwJrDWDYMxo(yhrAgHUqtIQjKILOnedYwvFWjYQ as YlWFkSrNjhWjdvjHemdfYAMOisT);
	}

	protected override void CloseDevice()
	{
		if (yhrAgHUqtIQjKILOnedYwvFWjYQ == null)
		{
			return;
		}
		while (true)
		{
			int num = -433410886;
			while (true)
			{
				switch (num ^ -433410885)
				{
				case 5:
					break;
				case 0:
					if (!IsAttached())
					{
						yhrAgHUqtIQjKILOnedYwvFWjYQ.Clear();
						num = -433410881;
						continue;
					}
					goto case 3;
				case 6:
					return;
				case 3:
					ghVaXMJBYQVankSHALdOAwQaFIx.mafUiXPeXuwDxxLicrOvOgLuTDS(yhrAgHUqtIQjKILOnedYwvFWjYQ);
					num = -433410887;
					continue;
				case 4:
					return;
				case 1:
				{
					int num2;
					if (!yhrAgHUqtIQjKILOnedYwvFWjYQ.IsValid)
					{
						num = -433410883;
						num2 = num;
					}
					else
					{
						num = -433410885;
						num2 = num;
					}
					continue;
				}
				default:
					yhrAgHUqtIQjKILOnedYwvFWjYQ.Clear();
					return;
				}
				break;
			}
		}
	}

	private float ipOGcKcVzcXMNUQKBbDNEKKEEqgE(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange(P_0, -32767f, 32768f, -1f, 1f);
	}

	private int eqhwntZbfKiegOFMKGzVPZCiLHF(short P_0)
	{
		switch (P_0)
		{
		case 0:
			return -1;
		case 1:
			return 0;
		case 3:
			return 4500;
		case 2:
			return 9000;
		case 6:
			return 13500;
		case 4:
			return 18000;
		case 12:
			return 22500;
		case 8:
			return 27000;
		case 9:
			return 31500;
		default:
			return -1;
		}
	}
}
