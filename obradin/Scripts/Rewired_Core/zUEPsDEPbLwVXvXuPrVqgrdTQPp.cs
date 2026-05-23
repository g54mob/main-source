using System;
using Rewired;
using Rewired.Utils;

internal abstract class zUEPsDEPbLwVXvXuPrVqgrdTQPp : IDisposable, VRdFMbYDznLdPhuJVzJXYifOWcT
{
	public readonly hsqimHyTwjiuMjqxkFcVqhhSacgd DujrGGkUjSQZvwNDHjOWZEXWGTD;

	public readonly XlOvDxbPTBSXeduTQZBtlQzXSZe HdaJmHCefHXcxpAZsILnwqxwADsE;

	public readonly int FqCcixihNQhPjnqFZjkjMuVDgPd;

	private XYitobKpIgOpWUmHymAwqjSLOet YrINEQzKlfFBbUSiOJDTprrZsWe;

	private bool WktzUSAcjulBYRNUcifkLEmijRhD;

	protected bool uHJCyAiiHAJtjaCqgzJDgQcCpUk;

	protected ehVGiSzTrcPLIwdMfduaFIdOgvwk UIFyZDxhAgLVEQUxTcGJZaEcsLr;

	protected bool xINbxEVoMYaqrtyFeWpluzglJed;

	protected int dFeMnzRTSNcMYNGuAWZUeFGTLNj;

	protected float[] gDAPUsqDSVRfRfxuBxbPBLbXOEk;

	private bool vsurYtRlepcrpAzAENwjqjJEZPT;

	public bool IsValid
	{
		get
		{
			if (DujrGGkUjSQZvwNDHjOWZEXWGTD == null)
			{
				return false;
			}
			return DujrGGkUjSQZvwNDHjOWZEXWGTD.IsValid;
		}
	}

	public dmKUPPBTIjpWsLWFEmbcbKrKfGk NativeJoystick
	{
		get
		{
			return DujrGGkUjSQZvwNDHjOWZEXWGTD as dmKUPPBTIjpWsLWFEmbcbKrKfGk;
		}
	}

	public string SystemName
	{
		get
		{
			return YrINEQzKlfFBbUSiOJDTprrZsWe.wmbEVxLvcdfrsmoyOrwQnKujFgS;
		}
	}

	public string FriendlyName
	{
		get
		{
			return YrINEQzKlfFBbUSiOJDTprrZsWe.MbrQwRnmlvxaToztrCqZEslEYAm;
		}
	}

	public int VendorId
	{
		get
		{
			return YrINEQzKlfFBbUSiOJDTprrZsWe.NdbvKbBBJrSYqhcLkswavvMBjSd;
		}
	}

	public int ProductId
	{
		get
		{
			return YrINEQzKlfFBbUSiOJDTprrZsWe.dUFmmEnRQtqCUuTnapnLPxMpqTR;
		}
	}

	public PidVid PidVid
	{
		get
		{
			return YrINEQzKlfFBbUSiOJDTprrZsWe.PwAPPePhJPAsncuOIyMlQuCrJGKc;
		}
	}

	public Guid InstanceGuid
	{
		get
		{
			return YrINEQzKlfFBbUSiOJDTprrZsWe.GmccNuFyvwHynCnhZFJRHUjCwoC;
		}
	}

	public virtual XqPQWVQCzoiUVqNxOwUOrPFfeBF DeviceType
	{
		get
		{
			return XqPQWVQCzoiUVqNxOwUOrPFfeBF.sPSdDimdHdkUZBwhcqdUzIdejYne;
		}
	}

	public bool IsBluetoothDevice
	{
		get
		{
			return false;
		}
	}

	public Controller.Extension ControllerExtension
	{
		get
		{
			return null;
		}
	}

	public bool SupportsVibration
	{
		get
		{
			return xINbxEVoMYaqrtyFeWpluzglJed;
		}
	}

	public int VibrationMotorCount
	{
		get
		{
			return dFeMnzRTSNcMYNGuAWZUeFGTLNj;
		}
	}

	protected zUEPsDEPbLwVXvXuPrVqgrdTQPp(hsqimHyTwjiuMjqxkFcVqhhSacgd nativeDevice, XYitobKpIgOpWUmHymAwqjSLOet info, XlOvDxbPTBSXeduTQZBtlQzXSZe type)
	{
		while (true)
		{
			int num = 408413582;
			while (true)
			{
				switch (num ^ 0x1857E58F)
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
				DujrGGkUjSQZvwNDHjOWZEXWGTD = nativeDevice;
				HdaJmHCefHXcxpAZsILnwqxwADsE = type;
				YrINEQzKlfFBbUSiOJDTprrZsWe = info;
				YrINEQzKlfFBbUSiOJDTprrZsWe.sbcTSexDWKGUOKrMGnEajLgRvts();
				FqCcixihNQhPjnqFZjkjMuVDgPd = info.WevTdQwnzmzGusLgYZijrubkIwX;
				num = 408413581;
			}
		}
	}

	public virtual void YJaAHaimrHWIfKrgfWxeihnqrcza()
	{
		InitializeHaptic();
		WktzUSAcjulBYRNUcifkLEmijRhD = true;
	}

	public virtual void xcaJhTEntwJovIWWzEiTSzKkHUZn()
	{
		eLvKJvHjHwiTldtXhjNGgNjYWKv();
		CloseDevice();
	}

	private void eLvKJvHjHwiTldtXhjNGgNjYWKv()
	{
		if (!uHJCyAiiHAJtjaCqgzJDgQcCpUk)
		{
			return;
		}
		if (!UIFyZDxhAgLVEQUxTcGJZaEcsLr.IsValid)
		{
			while (true)
			{
				switch (-1730486514 ^ -1730486513)
				{
				case 2:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		VuTGCVdtQMXPEMCKcnDOxWAgDee.smGNvHAolfyLVmKamywoUXjsPRk(UIFyZDxhAgLVEQUxTcGJZaEcsLr);
	}

	public abstract void Update(UpdateLoopType P_0);

	public abstract void UpdateFinished();

	public void Acquire()
	{
	}

	public void Unacquire()
	{
	}

	public virtual bool IsAttached()
	{
		if (DujrGGkUjSQZvwNDHjOWZEXWGTD != null)
		{
			while (true)
			{
				int num = -1332873497;
				while (true)
				{
					switch (num ^ -1332873499)
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
					if (!DujrGGkUjSQZvwNDHjOWZEXWGTD.IsValid)
					{
						num = -1332873500;
						continue;
					}
					return VuTGCVdtQMXPEMCKcnDOxWAgDee.dnWFBDCtSSSpHnYchmcQipSUcTsM(DujrGGkUjSQZvwNDHjOWZEXWGTD);
				}
				continue;
				end_IL_0008:
				break;
			}
		}
		return false;
	}

	public bool Matches(VRdFMbYDznLdPhuJVzJXYifOWcT P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return InstanceGuid == P_0.InstanceGuid;
	}

	public void SetVibration(int P_0, float P_1, bool P_2)
	{
		if (uHJCyAiiHAJtjaCqgzJDgQcCpUk)
		{
			if (!IsValid)
			{
				goto IL_0013;
			}
			goto IL_005c;
		}
		return;
		IL_005c:
		if (P_0 < 0)
		{
			return;
		}
		int num;
		int num2;
		if (P_0 >= dFeMnzRTSNcMYNGuAWZUeFGTLNj)
		{
			num = -176828343;
			num2 = num;
		}
		else
		{
			num = -176828351;
			num2 = num;
		}
		goto IL_0018;
		IL_0013:
		num = -176828352;
		goto IL_0018;
		IL_0018:
		int num3 = default(int);
		while (true)
		{
			switch (num ^ -176828351)
			{
			case 5:
				break;
			case 8:
				return;
			case 9:
				goto IL_005c;
			case 0:
				if (!xINbxEVoMYaqrtyFeWpluzglJed)
				{
					return;
				}
				goto case 3;
			case 7:
				P_1 = MathTools.Max(gDAPUsqDSVRfRfxuBxbPBLbXOEk[num3], P_1);
				num3++;
				num = -176828347;
				continue;
			case 1:
				return;
			case 4:
				if (num3 < dFeMnzRTSNcMYNGuAWZUeFGTLNj)
				{
					goto case 7;
				}
				P_1 = MathTools.Clamp01(P_1);
				if (P_1 == 0f)
				{
					StopVibration();
					return;
				}
				goto default;
			case 10:
				num = -176828347;
				continue;
			case 3:
				if (P_2)
				{
					Array.Clear(gDAPUsqDSVRfRfxuBxbPBLbXOEk, 0, dFeMnzRTSNcMYNGuAWZUeFGTLNj);
					num = -176828345;
					continue;
				}
				goto case 6;
			case 6:
				gDAPUsqDSVRfRfxuBxbPBLbXOEk[P_0] = P_1;
				num3 = 0;
				num = -176828341;
				continue;
			default:
				VuTGCVdtQMXPEMCKcnDOxWAgDee.vKiVfhhcuoVcEkLcQIvkbQBuDeEq(UIFyZDxhAgLVEQUxTcGJZaEcsLr, P_1, 0u);
				return;
			}
			break;
		}
		goto IL_0013;
	}

	public void StopVibration()
	{
		if (uHJCyAiiHAJtjaCqgzJDgQcCpUk)
		{
			if (!IsValid)
			{
				goto IL_0010;
			}
			goto IL_003a;
		}
		return;
		IL_003a:
		Array.Clear(gDAPUsqDSVRfRfxuBxbPBLbXOEk, 0, dFeMnzRTSNcMYNGuAWZUeFGTLNj);
		int num = -582720780;
		goto IL_0015;
		IL_0010:
		num = -582720779;
		goto IL_0015;
		IL_0015:
		switch (num ^ -582720778)
		{
		case 0:
			break;
		case 3:
			return;
		case 1:
			goto IL_003a;
		default:
			VuTGCVdtQMXPEMCKcnDOxWAgDee.nflIZGOcsNElaCxyVUYDsvEfkRLZ(UIFyZDxhAgLVEQUxTcGJZaEcsLr);
			return;
		}
		goto IL_0010;
	}

	public void Dispose()
	{
		DJeUzQoMEVOxbEpwDFXbTBWdIKu(true);
		GC.SuppressFinalize(this);
	}

	~zUEPsDEPbLwVXvXuPrVqgrdTQPp()
	{
		DJeUzQoMEVOxbEpwDFXbTBWdIKu(false);
	}

	protected virtual void DJeUzQoMEVOxbEpwDFXbTBWdIKu(bool P_0)
	{
		if (vsurYtRlepcrpAzAENwjqjJEZPT)
		{
			return;
		}
		while (true)
		{
			int num = -1747297125;
			while (true)
			{
				switch (num ^ -1747297127)
				{
				case 0:
					goto IL_0009;
				case 1:
					break;
				default:
					vsurYtRlepcrpAzAENwjqjJEZPT = true;
					return;
				}
				break;
				IL_0009:
				num = -1747297128;
			}
		}
	}

	protected abstract void InitializeHaptic();

	protected abstract void CloseDevice();
}
