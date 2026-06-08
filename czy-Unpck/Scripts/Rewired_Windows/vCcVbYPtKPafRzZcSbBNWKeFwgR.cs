using System;
using System.Runtime.InteropServices;

internal class vCcVbYPtKPafRzZcSbBNWKeFwgR : IDisposable
{
	public struct VOudmPoUckWnPqObqfixOPoKnZM
	{
		private byte ebFaZqcdPlKUwDxyHgfeeAHaVrGQ;

		private uint cPKSWbBECAGWhaAkVffJOUukZWrQ;

		private int tZUnOAwcHyObLXQsSrSXeWYWQaD;

		private static VOudmPoUckWnPqObqfixOPoKnZM eTHAwSpWTWxRGtDJImdyHSmQQNI;

		public byte pass => ebFaZqcdPlKUwDxyHgfeeAHaVrGQ;

		public uint offset => cPKSWbBECAGWhaAkVffJOUukZWrQ;

		public int length => tZUnOAwcHyObLXQsSrSXeWYWQaD;

		public static VOudmPoUckWnPqObqfixOPoKnZM Invalid => eTHAwSpWTWxRGtDJImdyHSmQQNI;

		public VOudmPoUckWnPqObqfixOPoKnZM(byte pass, uint offset, int length)
		{
			ebFaZqcdPlKUwDxyHgfeeAHaVrGQ = pass;
			cPKSWbBECAGWhaAkVffJOUukZWrQ = offset;
			tZUnOAwcHyObLXQsSrSXeWYWQaD = length;
			if (tZUnOAwcHyObLXQsSrSXeWYWQaD < 0)
			{
				tZUnOAwcHyObLXQsSrSXeWYWQaD = 0;
			}
		}
	}

	private const byte wPXurNdJAlFkJDFFfyQhIcOmjFbi = 254;

	private uint QKfMLKGhMIFKQQbNWIUdeBYkctCN;

	private int IDaaDPtlfdwgEHSPiaoMeHlZYNdP;

	private unsafe byte* nUBCdLJVgmxcrAIrSzTEcHLeSDWf;

	private byte ebFaZqcdPlKUwDxyHgfeeAHaVrGQ;

	private bool wJbPTRoBRVSOAlHQyySGXztIvyU;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	public int size => IDaaDPtlfdwgEHSPiaoMeHlZYNdP;

	public unsafe vCcVbYPtKPafRzZcSbBNWKeFwgR(int size)
	{
		if (size <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		IDaaDPtlfdwgEHSPiaoMeHlZYNdP = size;
		QKfMLKGhMIFKQQbNWIUdeBYkctCN = 0u;
		nUBCdLJVgmxcrAIrSzTEcHLeSDWf = (byte*)(void*)Marshal.AllocHGlobal(size);
	}

	public unsafe bool pqcPIshdVNrBiKWuGFpklSuavkZ(IntPtr P_0, int P_1, out VOudmPoUckWnPqObqfixOPoKnZM P_2)
	{
		if (nUBCdLJVgmxcrAIrSzTEcHLeSDWf != null)
		{
			while (true)
			{
				int num = 239620678;
				while (true)
				{
					switch (num ^ 0xE485240)
					{
					case 4:
						break;
					case 0:
						wJbPTRoBRVSOAlHQyySGXztIvyU = true;
						num = 239620673;
						continue;
					case 8:
						goto IL_0054;
					case 1:
						num = 239620677;
						continue;
					case 6:
						goto IL_007d;
					case 2:
						ebFaZqcdPlKUwDxyHgfeeAHaVrGQ++;
						num = 239620677;
						continue;
					case 7:
						goto end_IL_000d;
					case 3:
						if (ebFaZqcdPlKUwDxyHgfeeAHaVrGQ == 254)
						{
							ebFaZqcdPlKUwDxyHgfeeAHaVrGQ = 0;
							num = 239620672;
							continue;
						}
						goto case 2;
					default:
						goto IL_00e6;
					}
					break;
					IL_007d:
					if (P_1 <= 0)
					{
						num = 239620679;
						continue;
					}
					if (P_1 > IDaaDPtlfdwgEHSPiaoMeHlZYNdP)
					{
						throw new Exception("Length is larger than the buffer.");
					}
					goto IL_0054;
					IL_00e6:
					YksGHYKteMuhDXToEsEFZvCVfCJ.wpdDDqwWboCcIamTPCgZePPtlGNv(nUBCdLJVgmxcrAIrSzTEcHLeSDWf + (int)QKfMLKGhMIFKQQbNWIUdeBYkctCN, (void*)P_0, new UIntPtr((uint)P_1));
					P_2 = new VOudmPoUckWnPqObqfixOPoKnZM(ebFaZqcdPlKUwDxyHgfeeAHaVrGQ, QKfMLKGhMIFKQQbNWIUdeBYkctCN, P_1);
					QKfMLKGhMIFKQQbNWIUdeBYkctCN += (uint)P_1;
					return true;
					IL_0054:
					uint num2 = QKfMLKGhMIFKQQbNWIUdeBYkctCN + (uint)P_1;
					if (num2 >= IDaaDPtlfdwgEHSPiaoMeHlZYNdP)
					{
						QKfMLKGhMIFKQQbNWIUdeBYkctCN = 0u;
						num = 239620675;
						continue;
					}
					goto IL_00e6;
				}
				continue;
				end_IL_000d:
				break;
			}
		}
		P_2 = default(VOudmPoUckWnPqObqfixOPoKnZM);
		return false;
	}

	public int AFeHJojxqfbjmBllWvAWerjcLiqH(VOudmPoUckWnPqObqfixOPoKnZM P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			goto IL_0003;
		}
		goto IL_003f;
		IL_0003:
		int num = -790771986;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num ^ -790771989)
			{
			case 0:
				break;
			case 4:
				throw new Exception("Buffer is not large enough to hold the data.");
			case 1:
				goto IL_003f;
			case 2:
				goto IL_005c;
			case 5:
				throw new ArgumentNullException("buffer");
			default:
				return P_0.length;
			}
			break;
			IL_005c:
			if (!HirCGVrqaEEZgFdtqCTpdFWKDvOh(ref P_0))
			{
				return -1;
			}
			Marshal.Copy(sHPeiUxxxfUfPcneOivbLFFJQEE(P_0), P_1, 0, P_0.length);
			num = -790771992;
		}
		goto IL_0003;
		IL_003f:
		int num2;
		if (P_1.Length < P_0.length)
		{
			num = -790771985;
			num2 = num;
		}
		else
		{
			num = -790771991;
			num2 = num;
		}
		goto IL_0008;
	}

	public unsafe int AFeHJojxqfbjmBllWvAWerjcLiqH(VOudmPoUckWnPqObqfixOPoKnZM P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		while (P_2 > 0)
		{
			int num;
			int num2;
			if (P_2 < P_0.length)
			{
				num = 862568733;
				num2 = num;
			}
			else
			{
				num = 862568735;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ 0x3369C11E)
				{
				case 0:
					goto IL_0018;
				case 2:
					break;
				case 3:
					throw new Exception("Buffer is not large enough to hold the data.");
				default:
					if (!HirCGVrqaEEZgFdtqCTpdFWKDvOh(ref P_0))
					{
						return -1;
					}
					YksGHYKteMuhDXToEsEFZvCVfCJ.wpdDDqwWboCcIamTPCgZePPtlGNv((void*)P_1, nUBCdLJVgmxcrAIrSzTEcHLeSDWf, new UIntPtr((uint)P_0.length));
					return P_0.length;
				}
				break;
				IL_0018:
				num = 862568732;
			}
		}
		return -1;
	}

	public unsafe IntPtr sHPeiUxxxfUfPcneOivbLFFJQEE(VOudmPoUckWnPqObqfixOPoKnZM P_0)
	{
		if (nUBCdLJVgmxcrAIrSzTEcHLeSDWf == null || !HirCGVrqaEEZgFdtqCTpdFWKDvOh(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(nUBCdLJVgmxcrAIrSzTEcHLeSDWf + (int)P_0.offset);
	}

	public unsafe bool yNnHgjicrRLIVPdjMUjHpfnxoJV(VOudmPoUckWnPqObqfixOPoKnZM P_0, out IntPtr P_1)
	{
		if (nUBCdLJVgmxcrAIrSzTEcHLeSDWf == null || !HirCGVrqaEEZgFdtqCTpdFWKDvOh(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(nUBCdLJVgmxcrAIrSzTEcHLeSDWf + (int)P_0.offset);
		return true;
	}

	private bool HirCGVrqaEEZgFdtqCTpdFWKDvOh(ref VOudmPoUckWnPqObqfixOPoKnZM P_0)
	{
		int length = P_0.length;
		uint pass = default(uint);
		while (true)
		{
			int num = -1919228550;
			while (true)
			{
				switch (num ^ -1919228552)
				{
				case 3:
					break;
				case 5:
					if (ebFaZqcdPlKUwDxyHgfeeAHaVrGQ != 0)
					{
						goto case 4;
					}
					if (pass != 254)
					{
						num = -1919228548;
						continue;
					}
					goto IL_0081;
				case 1:
					return false;
				case 2:
					if (length > 0)
					{
						pass = P_0.pass;
						if (pass > 254)
						{
							num = -1919228552;
							continue;
						}
						if (pass != ebFaZqcdPlKUwDxyHgfeeAHaVrGQ)
						{
							if (!wJbPTRoBRVSOAlHQyySGXztIvyU)
							{
								if (pass + 1 != ebFaZqcdPlKUwDxyHgfeeAHaVrGQ)
								{
									return false;
								}
							}
							else
							{
								if (pass > ebFaZqcdPlKUwDxyHgfeeAHaVrGQ)
								{
									num = -1919228547;
									continue;
								}
								if (pass + 1 != ebFaZqcdPlKUwDxyHgfeeAHaVrGQ)
								{
									return false;
								}
							}
							goto IL_0081;
						}
						if (P_0.offset + length > QKfMLKGhMIFKQQbNWIUdeBYkctCN)
						{
							return false;
						}
						goto IL_00e3;
					}
					num = -1919228551;
					continue;
				case 4:
					return false;
				case 0:
					return false;
				default:
					{
						return false;
					}
					IL_00e3:
					if (P_0.offset + length > IDaaDPtlfdwgEHSPiaoMeHlZYNdP)
					{
						return false;
					}
					return true;
					IL_0081:
					if (P_0.offset < QKfMLKGhMIFKQQbNWIUdeBYkctCN)
					{
						num = -1919228546;
						continue;
					}
					goto IL_00e3;
				}
				break;
			}
		}
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~vCcVbYPtKPafRzZcSbBNWKeFwgR()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected unsafe virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			return;
		}
		while (nUBCdLJVgmxcrAIrSzTEcHLeSDWf != null)
		{
			Marshal.FreeHGlobal((IntPtr)nUBCdLJVgmxcrAIrSzTEcHLeSDWf);
			int num = 691169007;
			while (true)
			{
				switch (num ^ 0x293266EF)
				{
				case 2:
					num = 691169006;
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
}
