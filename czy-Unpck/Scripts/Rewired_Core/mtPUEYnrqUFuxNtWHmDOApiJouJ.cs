using System;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal class mtPUEYnrqUFuxNtWHmDOApiJouJ : nRSKZZMQWDSRligQqIWpJMZAIrL, IDisposable, HhpxzhCmKzBlrkWbuqAWjmXFzKv, pErdarFuDrLltFruMSsYCDRyarSk
{
	public readonly int SeOhWaCQLSUYyhdokorrnPTrNGB;

	public readonly int RGhWgMAfPjfICjXGWTZxnPoNdWD;

	public readonly int ugqqWfYBExHDZxWuxQgGapMNCCx;

	public readonly int wFXkhUcSxbniabfCluhOAikybNB;

	public readonly short[] rWBBunBLObAdqekGuvGsclEmxwY;

	private readonly ButtonLoopSet NbyZIKUqKTZFoBnTMZEZONiiWRV;

	public readonly short[] CxxqulMdnLFhXdpWRHwyMafYVtdd;

	public readonly short[] PGDObVtSxDhdAmXsCVOMFTMdTyv;

	private bool BjLRIbHSNziZuePSCMYMTKKmtVyj;

	public bool[] ButtonValues
	{
		get
		{
			if (NbyZIKUqKTZFoBnTMZEZONiiWRV.Current == null)
			{
				return null;
			}
			return NbyZIKUqKTZFoBnTMZEZONiiWRV.Current.effectiveValue;
		}
	}

	public int JoystickId => PRWgMlsJkOezTiVjiIDwjjnINBJ;

	public int ButtonCount => SeOhWaCQLSUYyhdokorrnPTrNGB;

	public int AxisCount => RGhWgMAfPjfICjXGWTZxnPoNdWD;

	public int HatCount => ugqqWfYBExHDZxWuxQgGapMNCCx;

	public int BallCount => wFXkhUcSxbniabfCluhOAikybNB;

	public bool HasElements
	{
		get
		{
			if (SeOhWaCQLSUYyhdokorrnPTrNGB <= 0 && RGhWgMAfPjfICjXGWTZxnPoNdWD <= 0 && ugqqWfYBExHDZxWuxQgGapMNCCx <= 0)
			{
				return wFXkhUcSxbniabfCluhOAikybNB > 0;
			}
			return true;
		}
	}

	public InputSource InputSource => InputSource.SDL2;

	public bool HasEverReceivedInput => BjLRIbHSNziZuePSCMYMTKKmtVyj;

	public mtPUEYnrqUFuxNtWHmDOApiJouJ(tsYaeJHPqrgHucWqidFogCgNPrkI nativeJoystick, PGcImbCrfaDBqNKhXzQpJjoCymX joystickInfo)
		: this(nativeJoystick, joystickInfo, RMSOLzlysTJsQkLnldiiCKTCEYY.etApNsmaydFifFQZNkCXGYFhvYDz)
	{
	}

	protected mtPUEYnrqUFuxNtWHmDOApiJouJ(tsYaeJHPqrgHucWqidFogCgNPrkI nativeJoystick, PGcImbCrfaDBqNKhXzQpJjoCymX joystickInfo, RMSOLzlysTJsQkLnldiiCKTCEYY type)
		: this(nativeJoystick, joystickInfo, type, joystickInfo.SeOhWaCQLSUYyhdokorrnPTrNGB, joystickInfo.RGhWgMAfPjfICjXGWTZxnPoNdWD, joystickInfo.ugqqWfYBExHDZxWuxQgGapMNCCx, joystickInfo.wFXkhUcSxbniabfCluhOAikybNB)
	{
	}

	protected mtPUEYnrqUFuxNtWHmDOApiJouJ(rPsCITgrJrIWweVTDfJAVeNBFuKB nativeDevice, PGcImbCrfaDBqNKhXzQpJjoCymX joystickInfo, RMSOLzlysTJsQkLnldiiCKTCEYY type, int buttonCount, int axisCount, int hatCount, int ballCount)
		: base(nativeDevice, joystickInfo, type)
	{
		SeOhWaCQLSUYyhdokorrnPTrNGB = buttonCount;
		RGhWgMAfPjfICjXGWTZxnPoNdWD = axisCount;
		ugqqWfYBExHDZxWuxQgGapMNCCx = hatCount;
		wFXkhUcSxbniabfCluhOAikybNB = ballCount;
		if (axisCount > 0)
		{
			rWBBunBLObAdqekGuvGsclEmxwY = new short[axisCount];
		}
		NbyZIKUqKTZFoBnTMZEZONiiWRV = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, buttonCount);
		if (hatCount > 0)
		{
			CxxqulMdnLFhXdpWRHwyMafYVtdd = new short[hatCount];
		}
		if (ballCount > 0)
		{
			PGDObVtSxDhdAmXsCVOMFTMdTyv = new short[ballCount * 2];
		}
	}

	public void KyHpjvRkJIBKWzDbtHSSnZwunyW(zlBtsxIKzBtKROSONkChkqMshrC P_0, byte P_1, short P_2, double P_3)
	{
		BjLRIbHSNziZuePSCMYMTKKmtVyj = true;
		int num;
		int num2;
		int num3;
		switch (P_0)
		{
		default:
			num = 122355156;
			goto IL_0024;
		case zlBtsxIKzBtKROSONkChkqMshrC.GjbYMEzdvPEgvfibmESwCeHANBSm:
			goto IL_0082;
		case zlBtsxIKzBtKROSONkChkqMshrC.zPglMLzCsADFJkYCqzSqAjySqTv:
			goto IL_00c2;
		case zlBtsxIKzBtKROSONkChkqMshrC.LpcrQwCnqOADJDLpyeZRCfTGKCVL:
			goto IL_00f5;
		case zlBtsxIKzBtKROSONkChkqMshrC.HWviyjlAfXAnVpajejfPFvepLPrG:
			goto IL_011d;
			IL_0024:
			while (true)
			{
				switch (num ^ 0x74AFDD0)
				{
				case 3:
					break;
				case 0:
					goto IL_0068;
				case 9:
					goto IL_0082;
				case 4:
					num = 122355162;
					continue;
				case 7:
					CxxqulMdnLFhXdpWRHwyMafYVtdd[P_1] = P_2;
					return;
				case 2:
					PGDObVtSxDhdAmXsCVOMFTMdTyv[P_1] = P_2;
					return;
				case 8:
					goto IL_00c2;
				case 1:
					return;
				case 5:
					return;
				case 11:
					goto IL_00f5;
				case 12:
					goto end_IL_000a;
				case 6:
					goto IL_011d;
				default:
					throw new NotImplementedException();
				}
				break;
			}
			goto default;
			IL_011d:
			if (P_1 < wFXkhUcSxbniabfCluhOAikybNB)
			{
				num = 122355154;
				num2 = num;
			}
			else
			{
				num = 122355157;
				num2 = num;
			}
			goto IL_0024;
			IL_0082:
			if (P_1 >= SeOhWaCQLSUYyhdokorrnPTrNGB)
			{
				return;
			}
			goto IL_0068;
			IL_0068:
			NbyZIKUqKTZFoBnTMZEZONiiWRV.SetValue(P_1, P_2 > 0, P_3);
			return;
			IL_00f5:
			if (P_1 >= RGhWgMAfPjfICjXGWTZxnPoNdWD)
			{
				return;
			}
			break;
			IL_00c2:
			if (P_1 >= ugqqWfYBExHDZxWuxQgGapMNCCx)
			{
				num = 122355153;
				num3 = num;
			}
			else
			{
				num = 122355159;
				num3 = num;
			}
			goto IL_0024;
			end_IL_000a:
			break;
		}
		rWBBunBLObAdqekGuvGsclEmxwY[P_1] = P_2;
	}

	public override void GzCliicOSMFLMvKajLgvnmGSSrh(UpdateLoopType P_0)
	{
		NbyZIKUqKTZFoBnTMZEZONiiWRV.SetUpdateLoop(P_0);
	}

	void HhpxzhCmKzBlrkWbuqAWjmXFzKv.GzCliicOSMFLMvKajLgvnmGSSrh(UpdateLoopType P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GzCliicOSMFLMvKajLgvnmGSSrh
		this.GzCliicOSMFLMvKajLgvnmGSSrh(P_0);
	}

	public override void yMpzPEgRxuylucHrikwaTLDBNvx()
	{
		NbyZIKUqKTZFoBnTMZEZONiiWRV.Current.ClearWasTrueThisFrame();
	}

	void HhpxzhCmKzBlrkWbuqAWjmXFzKv.yMpzPEgRxuylucHrikwaTLDBNvx()
	{
		//ILSpy generated this explicit interface implementation from .override directive in yMpzPEgRxuylucHrikwaTLDBNvx
		this.yMpzPEgRxuylucHrikwaTLDBNvx();
	}

	public float QEVsojLqDtQsxnvxgHocZSixiJS(int P_0)
	{
		if (P_0 < 0 || P_0 >= RGhWgMAfPjfICjXGWTZxnPoNdWD)
		{
			return 0f;
		}
		return VHCBrPWQwgPyMbxYWwKLEeaFhjH(rWBBunBLObAdqekGuvGsclEmxwY[P_0]);
	}

	float pErdarFuDrLltFruMSsYCDRyarSk.QEVsojLqDtQsxnvxgHocZSixiJS(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in QEVsojLqDtQsxnvxgHocZSixiJS
		return this.QEVsojLqDtQsxnvxgHocZSixiJS(P_0);
	}

	public int kNtRwYvqSSVZzptuFXYAPYEMnzi(int P_0)
	{
		if (P_0 >= 0)
		{
			while (true)
			{
				int num = 1170018134;
				while (true)
				{
					switch (num ^ 0x45BD0F57)
					{
					case 2:
						break;
					case 1:
						goto IL_0022;
					default:
						goto end_IL_0004;
					}
					break;
					IL_0022:
					if (P_0 >= RGhWgMAfPjfICjXGWTZxnPoNdWD)
					{
						num = 1170018135;
						continue;
					}
					return rWBBunBLObAdqekGuvGsclEmxwY[P_0];
				}
				continue;
				end_IL_0004:
				break;
			}
		}
		return 0;
	}

	int pErdarFuDrLltFruMSsYCDRyarSk.kNtRwYvqSSVZzptuFXYAPYEMnzi(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in kNtRwYvqSSVZzptuFXYAPYEMnzi
		return this.kNtRwYvqSSVZzptuFXYAPYEMnzi(P_0);
	}

	public bool oKAKkOrHJCSQdjvqMprroEgDqcJ(int P_0)
	{
		if (P_0 >= 0)
		{
			while (true)
			{
				int num = 1400582417;
				while (true)
				{
					switch (num ^ 0x537B3110)
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
					if (P_0 >= SeOhWaCQLSUYyhdokorrnPTrNGB)
					{
						num = 1400582418;
						continue;
					}
					return NbyZIKUqKTZFoBnTMZEZONiiWRV.Current.effectiveValue[P_0];
				}
				continue;
				end_IL_0004:
				break;
			}
		}
		return false;
	}

	bool pErdarFuDrLltFruMSsYCDRyarSk.oKAKkOrHJCSQdjvqMprroEgDqcJ(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in oKAKkOrHJCSQdjvqMprroEgDqcJ
		return this.oKAKkOrHJCSQdjvqMprroEgDqcJ(P_0);
	}

	public int FSxgkyMKKKphcbSZaWyIXvowzkQ(int P_0)
	{
		if (P_0 >= 0)
		{
			while (true)
			{
				int num = -1224476535;
				while (true)
				{
					switch (num ^ -1224476536)
					{
					case 2:
						break;
					case 1:
						goto IL_0022;
					default:
						goto end_IL_0004;
					}
					break;
					IL_0022:
					if (P_0 >= ugqqWfYBExHDZxWuxQgGapMNCCx)
					{
						num = -1224476536;
						continue;
					}
					return DshERcebYIBftdtjiJUMbFqIlEBk(CxxqulMdnLFhXdpWRHwyMafYVtdd[P_0]);
				}
				continue;
				end_IL_0004:
				break;
			}
		}
		return -1;
	}

	int pErdarFuDrLltFruMSsYCDRyarSk.FSxgkyMKKKphcbSZaWyIXvowzkQ(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in FSxgkyMKKKphcbSZaWyIXvowzkQ
		return this.FSxgkyMKKKphcbSZaWyIXvowzkQ(P_0);
	}

	public Vector2 mlBvfTVhECOEPvGlWDIQQLcDVpv(int P_0)
	{
		return Vector2.zero;
	}

	Vector2 pErdarFuDrLltFruMSsYCDRyarSk.mlBvfTVhECOEPvGlWDIQQLcDVpv(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in mlBvfTVhECOEPvGlWDIQQLcDVpv
		return this.mlBvfTVhECOEPvGlWDIQQLcDVpv(P_0);
	}

	protected void OtGEqrPSjtfQDhPTCRZiTHlVNDJP(tsYaeJHPqrgHucWqidFogCgNPrkI P_0)
	{
		if (!base.IsValid)
		{
			goto IL_000b;
		}
		goto IL_009c;
		IL_000b:
		int num = 1717846809;
		goto IL_0010;
		IL_0010:
		IntPtr intPtr = default(IntPtr);
		while (true)
		{
			switch (num ^ 0x6664431E)
			{
			case 4:
				break;
			default:
				return;
			case 7:
				return;
			case 10:
			{
				YTZbiTbHzixpwXCVihgCoWkfLsF = new erTEgSxzQgpygvdwAZkzdOHFbIM(intPtr);
				gzTLmUilmSybHlDGZCYUHVOFdhGT = true;
				lBFWHWDHXCFOJbqYVTnqGTXwnPHK = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.MLHswXYkLmKhbzHgMGSjgoVtHnP(YTZbiTbHzixpwXCVihgCoWkfLsF) > 0;
				int num2;
				if (lBFWHWDHXCFOJbqYVTnqGTXwnPHK)
				{
					num = 1717846815;
					num2 = num;
				}
				else
				{
					num = 1717846814;
					num2 = num;
				}
				continue;
			}
			case 9:
				goto IL_009c;
			case 6:
				if (RlJPuDpfhAyzcNeaFBQNBYkzwNAS.gnLhgznBtAzsXcQaDsWiARASmKc(intPtr) != 0)
				{
					RlJPuDpfhAyzcNeaFBQNBYkzwNAS.soQwbJYzHdFQbtTuRhDjvHbzyNA(intPtr);
					num = 1717846812;
					continue;
				}
				goto case 10;
			case 5:
				intPtr = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.FofTztNcFTQhWAvLUvtPwkqIYPN(P_0);
				if (intPtr == IntPtr.Zero)
				{
					return;
				}
				goto case 6;
			case 1:
				hSqMknHvfLaCaSKUtNrDJWiYQVX = 2;
				num = 1717846814;
				continue;
			case 0:
				kUWBxOygiBytBqMXwTMkojzMJCO = new float[hSqMknHvfLaCaSKUtNrDJWiYQVX];
				num = 1717846813;
				continue;
			case 2:
				return;
			case 8:
				return;
			case 3:
				return;
			}
			break;
		}
		goto IL_000b;
		IL_009c:
		int num3;
		if (RlJPuDpfhAyzcNeaFBQNBYkzwNAS.isQUtFsiqbsVDFsIHDlDhdRMgBqA(P_0) <= 0)
		{
			num = 1717846806;
			num3 = num;
		}
		else
		{
			num = 1717846811;
			num3 = num;
		}
		goto IL_0010;
	}

	protected override void IqYbJALSSodtZZuvbsHNmhevhvhh()
	{
		OtGEqrPSjtfQDhPTCRZiTHlVNDJP(FLfpJGepKSQwDnGvauSNaYfNcHt as tsYaeJHPqrgHucWqidFogCgNPrkI);
	}

	protected override void LPDFYTYuHOtWTkgaTGQSiasEGit()
	{
		if (FLfpJGepKSQwDnGvauSNaYfNcHt == null)
		{
			return;
		}
		while (true)
		{
			int num = 1919774212;
			while (true)
			{
				switch (num ^ 0x726D6E05)
				{
				case 5:
					break;
				case 1:
				{
					int num2;
					if (!FLfpJGepKSQwDnGvauSNaYfNcHt.IsValid)
					{
						num = 1919774214;
						num2 = num;
					}
					else
					{
						num = 1919774209;
						num2 = num;
					}
					continue;
				}
				case 4:
					if (!pMCjfzlbSSSXwErueQwoZACHCXn())
					{
						FLfpJGepKSQwDnGvauSNaYfNcHt.Clear();
						return;
					}
					goto case 0;
				case 3:
					return;
				case 0:
					RlJPuDpfhAyzcNeaFBQNBYkzwNAS.LcvXldjOVqLzESRkvGOJOLKxIYo(FLfpJGepKSQwDnGvauSNaYfNcHt);
					num = 1919774215;
					continue;
				default:
					FLfpJGepKSQwDnGvauSNaYfNcHt.Clear();
					return;
				}
				break;
			}
		}
	}

	private float VHCBrPWQwgPyMbxYWwKLEeaFhjH(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange(P_0, -32767f, 32768f, -1f, 1f);
	}

	private int DshERcebYIBftdtjiJUMbFqIlEBk(short P_0)
	{
		switch (P_0)
		{
		default:
			while (true)
			{
				switch (0x30F98350 ^ 0x30F98351)
				{
				case 0:
					break;
				default:
					goto end_IL_003c;
				case 1:
					goto end_IL_0003;
				}
				continue;
				end_IL_003c:
				break;
			}
			goto case 0;
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
		case 5:
		case 7:
		case 10:
		case 11:
			break;
			end_IL_0003:
			break;
		}
		return -1;
	}
}
