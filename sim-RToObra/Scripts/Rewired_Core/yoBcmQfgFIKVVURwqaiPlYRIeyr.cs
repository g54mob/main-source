using System;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal class yoBcmQfgFIKVVURwqaiPlYRIeyr : zUEPsDEPbLwVXvXuPrVqgrdTQPp, IDisposable, VRdFMbYDznLdPhuJVzJXYifOWcT, jubkEfPWovmVDOzYftHZlVlzvfw
{
	public readonly int SgYwVaEgtCZiUkgVDcTwJWbyDTtb;

	public readonly int TwhUkSEboxGPsJgqbpmupSCMcvva;

	public readonly int wRceQnAMrzPnjgfOOcFDeDiISSJA;

	public readonly int cAPiWvgwtlyLKeOLGzTJlhAlArba;

	public readonly short[] tiXjQvPjlhJrGhgeDjpfVQmfqou;

	private readonly ButtonLoopSet XYiyBMQkvRjEQCnvxfYApKWzHEj;

	public readonly short[] QFrOYnCWUVLLxqBkiaNpVyJLghH;

	public readonly short[] LXVMcHtFMRUXgraQbEyLhkgevFZS;

	private bool BvBiBtBhorGlOOqcvDhVgnidONSn;

	public bool[] ButtonValues
	{
		get
		{
			if (XYiyBMQkvRjEQCnvxfYApKWzHEj.Current == null)
			{
				return null;
			}
			return XYiyBMQkvRjEQCnvxfYApKWzHEj.Current.effectiveValue;
		}
	}

	public int JoystickId
	{
		get
		{
			return FqCcixihNQhPjnqFZjkjMuVDgPd;
		}
	}

	public int ButtonCount
	{
		get
		{
			return SgYwVaEgtCZiUkgVDcTwJWbyDTtb;
		}
	}

	public int AxisCount
	{
		get
		{
			return TwhUkSEboxGPsJgqbpmupSCMcvva;
		}
	}

	public int HatCount
	{
		get
		{
			return wRceQnAMrzPnjgfOOcFDeDiISSJA;
		}
	}

	public int BallCount
	{
		get
		{
			return cAPiWvgwtlyLKeOLGzTJlhAlArba;
		}
	}

	public bool HasElements
	{
		get
		{
			if (SgYwVaEgtCZiUkgVDcTwJWbyDTtb <= 0 && TwhUkSEboxGPsJgqbpmupSCMcvva <= 0 && wRceQnAMrzPnjgfOOcFDeDiISSJA <= 0)
			{
				return cAPiWvgwtlyLKeOLGzTJlhAlArba > 0;
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
			return BvBiBtBhorGlOOqcvDhVgnidONSn;
		}
	}

	public yoBcmQfgFIKVVURwqaiPlYRIeyr(dmKUPPBTIjpWsLWFEmbcbKrKfGk nativeJoystick, XYitobKpIgOpWUmHymAwqjSLOet joystickInfo)
		: this(nativeJoystick, joystickInfo, XlOvDxbPTBSXeduTQZBtlQzXSZe.sPSdDimdHdkUZBwhcqdUzIdejYne)
	{
	}

	protected yoBcmQfgFIKVVURwqaiPlYRIeyr(dmKUPPBTIjpWsLWFEmbcbKrKfGk nativeJoystick, XYitobKpIgOpWUmHymAwqjSLOet joystickInfo, XlOvDxbPTBSXeduTQZBtlQzXSZe type)
		: this(nativeJoystick, joystickInfo, type, joystickInfo.SgYwVaEgtCZiUkgVDcTwJWbyDTtb, joystickInfo.TwhUkSEboxGPsJgqbpmupSCMcvva, joystickInfo.wRceQnAMrzPnjgfOOcFDeDiISSJA, joystickInfo.cAPiWvgwtlyLKeOLGzTJlhAlArba)
	{
	}

	protected yoBcmQfgFIKVVURwqaiPlYRIeyr(hsqimHyTwjiuMjqxkFcVqhhSacgd nativeDevice, XYitobKpIgOpWUmHymAwqjSLOet joystickInfo, XlOvDxbPTBSXeduTQZBtlQzXSZe type, int buttonCount, int axisCount, int hatCount, int ballCount)
		: base(nativeDevice, joystickInfo, type)
	{
		SgYwVaEgtCZiUkgVDcTwJWbyDTtb = buttonCount;
		TwhUkSEboxGPsJgqbpmupSCMcvva = axisCount;
		wRceQnAMrzPnjgfOOcFDeDiISSJA = hatCount;
		cAPiWvgwtlyLKeOLGzTJlhAlArba = ballCount;
		if (axisCount > 0)
		{
			tiXjQvPjlhJrGhgeDjpfVQmfqou = new short[axisCount];
		}
		XYiyBMQkvRjEQCnvxfYApKWzHEj = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, buttonCount);
		if (hatCount > 0)
		{
			QFrOYnCWUVLLxqBkiaNpVyJLghH = new short[hatCount];
		}
		if (ballCount > 0)
		{
			LXVMcHtFMRUXgraQbEyLhkgevFZS = new short[ballCount * 2];
		}
	}

	public void MPPQJfVkqEnvckKDMacDSmlvhjwB(rpBMVhALAXhNbPzqodBoJUcrMls P_0, byte P_1, short P_2, float P_3)
	{
		BvBiBtBhorGlOOqcvDhVgnidONSn = true;
		switch (P_0)
		{
		case rpBMVhALAXhNbPzqodBoJUcrMls.hmgqmNjVDUfwvNLmVfpnviGBwXP:
			while (true)
			{
				int num;
				int num2;
				if (P_1 >= wRceQnAMrzPnjgfOOcFDeDiISSJA)
				{
					num = 695252637;
					num2 = num;
				}
				else
				{
					num = 695252634;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x2970B699)
					{
					case 9:
						num = 695252632;
						continue;
					case 10:
						break;
					case 2:
						goto end_IL_0065;
					case 6:
						goto IL_0090;
					case 5:
						goto IL_00a1;
					case 1:
						goto IL_00b5;
					case 4:
						return;
					case 8:
						goto IL_00d4;
					case 3:
						QFrOYnCWUVLLxqBkiaNpVyJLghH[P_1] = P_2;
						return;
					case 7:
						goto IL_0105;
					default:
						goto end_IL_000a;
					}
					break;
				}
				continue;
				end_IL_0065:
				break;
			}
			goto case rpBMVhALAXhNbPzqodBoJUcrMls.FlpCCvhMQHVvtqxTRSLIYZOcLuN;
		case rpBMVhALAXhNbPzqodBoJUcrMls.FlpCCvhMQHVvtqxTRSLIYZOcLuN:
			if (P_1 >= cAPiWvgwtlyLKeOLGzTJlhAlArba)
			{
				return;
			}
			goto IL_0105;
		case rpBMVhALAXhNbPzqodBoJUcrMls.JXmeKuWrTArDlIRBTsNQYJxBCgf:
			goto IL_0090;
		case rpBMVhALAXhNbPzqodBoJUcrMls.ETpgSElJMLIOBvBRNjrxZobCcDai:
			goto IL_00b5;
			IL_00b5:
			if (P_1 >= SgYwVaEgtCZiUkgVDcTwJWbyDTtb)
			{
				return;
			}
			goto IL_00d4;
			IL_00d4:
			XYiyBMQkvRjEQCnvxfYApKWzHEj.SetValue(P_1, P_2 > 0, P_3);
			return;
			IL_0090:
			if (P_1 >= TwhUkSEboxGPsJgqbpmupSCMcvva)
			{
				return;
			}
			goto IL_00a1;
			IL_00a1:
			tiXjQvPjlhJrGhgeDjpfVQmfqou[P_1] = P_2;
			return;
			IL_0105:
			LXVMcHtFMRUXgraQbEyLhkgevFZS[P_1] = P_2;
			return;
			end_IL_000a:
			break;
		}
		throw new NotImplementedException();
	}

	public override void Update(UpdateLoopType P_0)
	{
		XYiyBMQkvRjEQCnvxfYApKWzHEj.SetUpdateLoop(P_0);
	}

	public override void UpdateFinished()
	{
		XYiyBMQkvRjEQCnvxfYApKWzHEj.Current.ClearWasTrueThisFrame();
	}

	public float GetAxisValue(int P_0)
	{
		if (P_0 < 0 || P_0 >= TwhUkSEboxGPsJgqbpmupSCMcvva)
		{
			return 0f;
		}
		return XxKxzTQwzsfDwcSJzRaLbTOEnfh(tiXjQvPjlhJrGhgeDjpfVQmfqou[P_0]);
	}

	public int GetAxisRawValue(int P_0)
	{
		if (P_0 >= 0)
		{
			while (true)
			{
				int num = 2129203941;
				while (true)
				{
					switch (num ^ 0x7EE912E4)
					{
					case 0:
						break;
					case 1:
						goto IL_0022;
					default:
						goto end_IL_0004;
					}
					break;
					IL_0022:
					if (P_0 >= TwhUkSEboxGPsJgqbpmupSCMcvva)
					{
						num = 2129203942;
						continue;
					}
					return tiXjQvPjlhJrGhgeDjpfVQmfqou[P_0];
				}
				continue;
				end_IL_0004:
				break;
			}
		}
		return 0;
	}

	public bool GetButtonValue(int P_0)
	{
		if (P_0 < 0 || P_0 >= SgYwVaEgtCZiUkgVDcTwJWbyDTtb)
		{
			return false;
		}
		return XYiyBMQkvRjEQCnvxfYApKWzHEj.Current.effectiveValue[P_0];
	}

	public int GetHatValue(int P_0)
	{
		if (P_0 < 0 || P_0 >= wRceQnAMrzPnjgfOOcFDeDiISSJA)
		{
			return -1;
		}
		return BOjnwAlfrSNRtwPFwpDdwWEgMbC(QFrOYnCWUVLLxqBkiaNpVyJLghH[P_0]);
	}

	public Vector2 GetBallValue(int P_0)
	{
		return Vector2.zero;
	}

	protected void MPIErwTOhperpArWhutZeBNKLzz(dmKUPPBTIjpWsLWFEmbcbKrKfGk P_0)
	{
		if (!base.IsValid)
		{
			return;
		}
		while (VuTGCVdtQMXPEMCKcnDOxWAgDee.enCZnXmXillyxMsKcIFIYxNFNSC(P_0) > 0)
		{
			while (true)
			{
				IL_00ce:
				IntPtr intPtr = VuTGCVdtQMXPEMCKcnDOxWAgDee.JztNtlXmNDBUuNrzzQmUXCwNVPz(P_0);
				if (intPtr == IntPtr.Zero)
				{
					return;
				}
				while (true)
				{
					IL_00b6:
					int num;
					if (VuTGCVdtQMXPEMCKcnDOxWAgDee.aSHTVxljAKSHfxiAitTpjJoJqqS(intPtr) != 0)
					{
						VuTGCVdtQMXPEMCKcnDOxWAgDee.smGNvHAolfyLVmKamywoUXjsPRk(intPtr);
						num = -818011729;
						goto IL_000e;
					}
					goto IL_0058;
					IL_000e:
					while (true)
					{
						switch (num ^ -818011737)
						{
						case 6:
							num = -818011741;
							continue;
						case 4:
							break;
						case 2:
							goto IL_0058;
						case 8:
							return;
						case 0:
							xINbxEVoMYaqrtyFeWpluzglJed = VuTGCVdtQMXPEMCKcnDOxWAgDee.MZToWBSWukUwNuyKzgfyBFnypfj(UIFyZDxhAgLVEQUxTcGJZaEcsLr) > 0;
							num = -818011744;
							continue;
						case 7:
							if (xINbxEVoMYaqrtyFeWpluzglJed)
							{
								dFeMnzRTSNcMYNGuAWZUeFGTLNj = 2;
								num = -818011738;
								continue;
							}
							goto default;
						case 3:
							goto IL_00b6;
						case 5:
							goto IL_00ce;
						default:
							gDAPUsqDSVRfRfxuBxbPBLbXOEk = new float[dFeMnzRTSNcMYNGuAWZUeFGTLNj];
							return;
						}
						break;
					}
					break;
					IL_0058:
					UIFyZDxhAgLVEQUxTcGJZaEcsLr = new ehVGiSzTrcPLIwdMfduaFIdOgvwk(intPtr);
					uHJCyAiiHAJtjaCqgzJDgQcCpUk = true;
					num = -818011737;
					goto IL_000e;
				}
				break;
			}
		}
	}

	protected override void InitializeHaptic()
	{
		MPIErwTOhperpArWhutZeBNKLzz(DujrGGkUjSQZvwNDHjOWZEXWGTD as dmKUPPBTIjpWsLWFEmbcbKrKfGk);
	}

	protected override void CloseDevice()
	{
		if (DujrGGkUjSQZvwNDHjOWZEXWGTD == null)
		{
			return;
		}
		while (true)
		{
			int num = -420513986;
			while (true)
			{
				switch (num ^ -420513990)
				{
				case 5:
					break;
				case 3:
					DujrGGkUjSQZvwNDHjOWZEXWGTD.Clear();
					return;
				case 2:
					return;
				case 1:
				{
					int num3;
					if (IsAttached())
					{
						num = -420513990;
						num3 = num;
					}
					else
					{
						num = -420513991;
						num3 = num;
					}
					continue;
				}
				case 4:
				{
					int num2;
					if (DujrGGkUjSQZvwNDHjOWZEXWGTD.IsValid)
					{
						num = -420513989;
						num2 = num;
					}
					else
					{
						num = -420513992;
						num2 = num;
					}
					continue;
				}
				default:
					VuTGCVdtQMXPEMCKcnDOxWAgDee.RWxViftheoJPaFBIAjvSxRggAIO(DujrGGkUjSQZvwNDHjOWZEXWGTD);
					DujrGGkUjSQZvwNDHjOWZEXWGTD.Clear();
					return;
				}
				break;
			}
		}
	}

	private float XxKxzTQwzsfDwcSJzRaLbTOEnfh(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange(P_0, -32767f, 32768f, -1f, 1f);
	}

	private int BOjnwAlfrSNRtwPFwpDdwWEgMbC(short P_0)
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
