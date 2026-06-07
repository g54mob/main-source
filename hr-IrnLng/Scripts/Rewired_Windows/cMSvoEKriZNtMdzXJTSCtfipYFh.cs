using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct cMSvoEKriZNtMdzXJTSCtfipYFh
{
	[FieldOffset(0)]
	private int yaCvtuEtQLRAFEeKpKbwXkYKXBN;

	[FieldOffset(0)]
	private long zIsCOhjRpOMBMdRIzEmpRqUXWvlB;

	[FieldOffset(0)]
	private IntPtr liyFxFisQZBQNxxTQkRysusdIDxP;

	private static readonly bool GupIFSTVSLnhDwDGCsKLmLgUDLU;

	public static readonly int iiCeZsFqsCMgMBWpCvqNRTNxrPf;

	static cMSvoEKriZNtMdzXJTSCtfipYFh()
	{
		iiCeZsFqsCMgMBWpCvqNRTNxrPf = IntPtr.Size;
		GupIFSTVSLnhDwDGCsKLmLgUDLU = iiCeZsFqsCMgMBWpCvqNRTNxrPf == 8;
	}

	public static cMSvoEKriZNtMdzXJTSCtfipYFh IFUvyfjjlmiTRXvpbkTSGARqaVO(byte[] P_0, int P_1)
	{
		cMSvoEKriZNtMdzXJTSCtfipYFh result = default(cMSvoEKriZNtMdzXJTSCtfipYFh);
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			result.zIsCOhjRpOMBMdRIzEmpRqUXWvlB = BitConverter.ToInt64(P_0, P_1);
			result.liyFxFisQZBQNxxTQkRysusdIDxP = new IntPtr(result.zIsCOhjRpOMBMdRIzEmpRqUXWvlB);
		}
		else
		{
			result.yaCvtuEtQLRAFEeKpKbwXkYKXBN = BitConverter.ToInt32(P_0, P_1);
			result.liyFxFisQZBQNxxTQkRysusdIDxP = new IntPtr(result.yaCvtuEtQLRAFEeKpKbwXkYKXBN);
		}
		return result;
	}

	public static implicit operator cMSvoEKriZNtMdzXJTSCtfipYFh(IntPtr obj)
	{
		cMSvoEKriZNtMdzXJTSCtfipYFh result = new cMSvoEKriZNtMdzXJTSCtfipYFh
		{
			liyFxFisQZBQNxxTQkRysusdIDxP = obj
		};
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			result.zIsCOhjRpOMBMdRIzEmpRqUXWvlB = obj.ToInt64();
		}
		else
		{
			result.yaCvtuEtQLRAFEeKpKbwXkYKXBN = obj.ToInt32();
		}
		return result;
	}

	public static implicit operator IntPtr(cMSvoEKriZNtMdzXJTSCtfipYFh obj)
	{
		return obj.liyFxFisQZBQNxxTQkRysusdIDxP;
	}

	public override string ToString()
	{
		if (GupIFSTVSLnhDwDGCsKLmLgUDLU)
		{
			return zIsCOhjRpOMBMdRIzEmpRqUXWvlB.ToString();
		}
		return yaCvtuEtQLRAFEeKpKbwXkYKXBN.ToString();
	}
}
