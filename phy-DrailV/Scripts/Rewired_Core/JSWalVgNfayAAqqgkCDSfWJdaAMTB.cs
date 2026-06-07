using System;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Data;

internal abstract class JSWalVgNfayAAqqgkCDSfWJdaAMTB : JdcCLFiaJuoUfXzTzdwUYtOkZosQ
{
	public class VZJfXHOjRTAusnMJVNTJYnlTPElR
	{
		public readonly AxisDirection? CFZgLeSNFyCLpaVLVUHQRDinORMQA;

		public VZJfXHOjRTAusnMJVNTJYnlTPElR(AxisDirection? P_0)
		{
			CFZgLeSNFyCLpaVLVUHQRDinORMQA = P_0;
		}
	}

	public class exlqDuEbMnCkpHMuXAQdzpkhfUUr
	{
		private readonly AList<VZJfXHOjRTAusnMJVNTJYnlTPElR> JlCnxdjSAFgokjnBJvAQVZXHNacj;

		public readonly int psjRAApvubFvKrvItiJJlxpacaQl;

		public exlqDuEbMnCkpHMuXAQdzpkhfUUr(AList<VZJfXHOjRTAusnMJVNTJYnlTPElR> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			for (int i = 0; i < P_0._count; i++)
			{
				if (P_0._items[i] == null)
				{
					throw new ArgumentNullException();
				}
			}
			JlCnxdjSAFgokjnBJvAQVZXHNacj = P_0;
			psjRAApvubFvKrvItiJJlxpacaQl = JlCnxdjSAFgokjnBJvAQVZXHNacj._count;
		}

		public VZJfXHOjRTAusnMJVNTJYnlTPElR TIxnSRhPSalQFvQOFZaLLiQtwMIC(int P_0)
		{
			return JlCnxdjSAFgokjnBJvAQVZXHNacj._items[P_0];
		}

		public int PujFpIgnaejxCcbCzrcoRIpZaecab(AxisDirection P_0)
		{
			for (int i = 0; i < JlCnxdjSAFgokjnBJvAQVZXHNacj._count; i++)
			{
				if (JlCnxdjSAFgokjnBJvAQVZXHNacj[i].CFZgLeSNFyCLpaVLVUHQRDinORMQA.HasValue && JlCnxdjSAFgokjnBJvAQVZXHNacj[i].CFZgLeSNFyCLpaVLVUHQRDinORMQA.Value == P_0)
				{
					return i;
				}
			}
			return -1;
		}
	}

	public enum VEYElUHTAVQERqFafltfcwjOaUMyA
	{
		None = 0,
		Names = 1,
		Keys = 2,
		All = -1
	}

	public enum MbnhNztvlYEMfnRNZAzRFTGcWsDiA
	{
		None = 0,
		DescriptiveName = 1,
		PositiveDescriptiveName = 2,
		NegativeDescriptiveName = 4,
		PositiveKey = 8,
		NegativeKey = 16,
		SpecialDescrptiveName0 = 16384,
		SpecialDescrptiveName1 = 32768,
		SpecialDescrptiveName2 = 65536,
		SpecialDescrptiveName3 = 131072,
		SpecialDescrptiveName4 = 262144,
		SpecialDescrptiveName5 = 524288,
		SpecialDescrptiveName6 = 1048576,
		SpecialDescrptiveName7 = 2097152,
		SpecialDescrptiveName8 = 4194304,
		SpecialKey0 = 8388608,
		SpecialKey1 = 16777216,
		SpecialKey2 = 33554432,
		SpecialKey3 = 67108864,
		SpecialKey4 = 134217728,
		SpecialKey5 = 268435456,
		SpecialKey6 = 536870912,
		SpecialKey7 = 1073741824,
		SpecialKey8 = int.MinValue,
		All = -1
	}

	public enum VwAEfXIfCgCiohhuMMznDzgWRhLp
	{
		Axis = 0,
		Button = 1,
		CompoundElement = 100,
		Unknown = int.MaxValue
	}

	public enum bETiEQbYCrQRqCLRvbSAcJMPkrdD
	{
		None = 0,
		Axis2D = 1,
		Hat = 2,
		ThumbStick = 3,
		DPad = 4,
		Stick = 5,
		Stick6D = 6,
		Unknown = int.MaxValue
	}

	private static readonly ADictionary<int, exlqDuEbMnCkpHMuXAQdzpkhfUUr> fnpThNhNdBfvqUMNhUZajTkiIyNQ = new ADictionary<int, exlqDuEbMnCkpHMuXAQdzpkhfUUr>
	{
		{
			4,
			new exlqDuEbMnCkpHMuXAQdzpkhfUUr(new AList<VZJfXHOjRTAusnMJVNTJYnlTPElR>
			{
				new VZJfXHOjRTAusnMJVNTJYnlTPElR(AxisDirection.Horizontal),
				new VZJfXHOjRTAusnMJVNTJYnlTPElR(AxisDirection.Vertical)
			})
		},
		{
			1,
			new exlqDuEbMnCkpHMuXAQdzpkhfUUr(new AList<VZJfXHOjRTAusnMJVNTJYnlTPElR>
			{
				new VZJfXHOjRTAusnMJVNTJYnlTPElR(AxisDirection.Horizontal),
				new VZJfXHOjRTAusnMJVNTJYnlTPElR(AxisDirection.Vertical)
			})
		},
		{
			5,
			new exlqDuEbMnCkpHMuXAQdzpkhfUUr(new AList<VZJfXHOjRTAusnMJVNTJYnlTPElR>
			{
				new VZJfXHOjRTAusnMJVNTJYnlTPElR(AxisDirection.Horizontal),
				new VZJfXHOjRTAusnMJVNTJYnlTPElR(AxisDirection.Vertical)
			})
		},
		{
			3,
			new exlqDuEbMnCkpHMuXAQdzpkhfUUr(new AList<VZJfXHOjRTAusnMJVNTJYnlTPElR>
			{
				new VZJfXHOjRTAusnMJVNTJYnlTPElR(AxisDirection.Horizontal),
				new VZJfXHOjRTAusnMJVNTJYnlTPElR(AxisDirection.Vertical)
			})
		}
	};

	private VwAEfXIfCgCiohhuMMznDzgWRhLp jRBPSVtNKcYysODJtvbPjIhQUBZJ;

	private bETiEQbYCrQRqCLRvbSAcJMPkrdD CceXvTKOTZatvKMCtZufkALrVhjvA;

	public VwAEfXIfCgCiohhuMMznDzgWRhLp ugEcvEUjcYzrLriOHSDCiapaTNEm
	{
		get
		{
			return jRBPSVtNKcYysODJtvbPjIhQUBZJ;
		}
		set
		{
			if (vwAEfXIfCgCiohhuMMznDzgWRhLp != jRBPSVtNKcYysODJtvbPjIhQUBZJ)
			{
				jRBPSVtNKcYysODJtvbPjIhQUBZJ = vwAEfXIfCgCiohhuMMznDzgWRhLp;
				if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
				{
					TlzckGoQDITHcUYaslQXPQBOhTwq();
				}
			}
		}
	}

	public bETiEQbYCrQRqCLRvbSAcJMPkrdD iDKoVNKBUFFkBevicPLoKjjnDSZL
	{
		get
		{
			return CceXvTKOTZatvKMCtZufkALrVhjvA;
		}
		set
		{
			if (bETiEQbYCrQRqCLRvbSAcJMPkrdD2 != CceXvTKOTZatvKMCtZufkALrVhjvA)
			{
				CceXvTKOTZatvKMCtZufkALrVhjvA = bETiEQbYCrQRqCLRvbSAcJMPkrdD2;
				if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
				{
					TlzckGoQDITHcUYaslQXPQBOhTwq();
				}
			}
		}
	}

	public static bool HiplrqmAxSeQEXpdvOXYKTZEASQi(bETiEQbYCrQRqCLRvbSAcJMPkrdD P_0, out exlqDuEbMnCkpHMuXAQdzpkhfUUr P_1)
	{
		return fnpThNhNdBfvqUMNhUZajTkiIyNQ.TryGetValue((int)P_0, out P_1);
	}

	public static int hMtVUAEviNnyqkiTSEVFSjpeZUfm(VwAEfXIfCgCiohhuMMznDzgWRhLp P_0, bETiEQbYCrQRqCLRvbSAcJMPkrdD P_1)
	{
		if (P_0 != VwAEfXIfCgCiohhuMMznDzgWRhLp.CompoundElement)
		{
			return 0;
		}
		if (!fnpThNhNdBfvqUMNhUZajTkiIyNQ.TryGetValue((int)P_1, out var value))
		{
			return 0;
		}
		return value.psjRAApvubFvKrvItiJJlxpacaQl;
	}

	protected JSWalVgNfayAAqqgkCDSfWJdaAMTB(VwAEfXIfCgCiohhuMMznDzgWRhLp P_0, bETiEQbYCrQRqCLRvbSAcJMPkrdD P_1)
	{
		jRBPSVtNKcYysODJtvbPjIhQUBZJ = P_0;
		CceXvTKOTZatvKMCtZufkALrVhjvA = P_1;
	}

	protected JSWalVgNfayAAqqgkCDSfWJdaAMTB(jtAeQMwqfCHdCmeHvhaRCqwDmBxb P_0, VwAEfXIfCgCiohhuMMznDzgWRhLp P_1, bETiEQbYCrQRqCLRvbSAcJMPkrdD P_2)
		: base(P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		jRBPSVtNKcYysODJtvbPjIhQUBZJ = P_1;
		CceXvTKOTZatvKMCtZufkALrVhjvA = P_2;
	}

	protected override void izqgVCmGioijeoXrjYwAEVccIJMK()
	{
		base.izqgVCmGioijeoXrjYwAEVccIJMK();
		PWkFKbOvHOZIUAfzpEAIGeluRTIK();
	}

	public override void ijtdeCdNfQFeopbwLHgQcRDjMsVz()
	{
		base.ijtdeCdNfQFeopbwLHgQcRDjMsVz();
		PWkFKbOvHOZIUAfzpEAIGeluRTIK(VEYElUHTAVQERqFafltfcwjOaUMyA.Names);
	}

	public override void OXcBXtPnTqYHpiucqKbwxkVzPkjf()
	{
		base.OXcBXtPnTqYHpiucqKbwxkVzPkjf();
		PWkFKbOvHOZIUAfzpEAIGeluRTIK(VEYElUHTAVQERqFafltfcwjOaUMyA.Keys);
	}

	public override void dsySnzlaDCdVTBdBHhqcOjWsSalGA()
	{
		base.dsySnzlaDCdVTBdBHhqcOjWsSalGA();
		PWkFKbOvHOZIUAfzpEAIGeluRTIK(VEYElUHTAVQERqFafltfcwjOaUMyA.Names);
	}

	public override bool TUibHCXgdJpNwgxVPYRazOMZLYAI(JdcCLFiaJuoUfXzTzdwUYtOkZosQ P_0, bool P_1)
	{
		JSWalVgNfayAAqqgkCDSfWJdaAMTB jSWalVgNfayAAqqgkCDSfWJdaAMTB = P_0 as JSWalVgNfayAAqqgkCDSfWJdaAMTB;
		if (jSWalVgNfayAAqqgkCDSfWJdaAMTB != null)
		{
			return false;
		}
		if (!base.TUibHCXgdJpNwgxVPYRazOMZLYAI(P_0, P_1))
		{
			return false;
		}
		return jRBPSVtNKcYysODJtvbPjIhQUBZJ == jSWalVgNfayAAqqgkCDSfWJdaAMTB.ugEcvEUjcYzrLriOHSDCiapaTNEm;
	}

	protected override void wJjPIIRJfHhEbGedUconecGfiwzgB()
	{
		base.wJjPIIRJfHhEbGedUconecGfiwzgB();
		LiXAHjDsSjcjuheRSvInddHJDOVCA(MbnhNztvlYEMfnRNZAzRFTGcWsDiA.All);
	}

	protected virtual void PWkFKbOvHOZIUAfzpEAIGeluRTIK(VEYElUHTAVQERqFafltfcwjOaUMyA P_0 = VEYElUHTAVQERqFafltfcwjOaUMyA.None)
	{
		if (P_0 != VEYElUHTAVQERqFafltfcwjOaUMyA.None)
		{
			LiXAHjDsSjcjuheRSvInddHJDOVCA(P_0);
		}
		jtAeQMwqfCHdCmeHvhaRCqwDmBxb jtAeQMwqfCHdCmeHvhaRCqwDmBxb2 = jfPgAiHCXDOsCqPqzSwgbROIKKdw();
		if (jtAeQMwqfCHdCmeHvhaRCqwDmBxb2 != null && (jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.autoGeneratedValueFlags & 1) == 0 && string.IsNullOrEmpty(jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.nonLocalizedDescriptiveName) && !string.IsNullOrEmpty(jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.scriptingName))
		{
			jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.nonLocalizedDescriptiveName = jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.scriptingName;
			jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.autoGeneratedValueFlags |= 1;
			UADvwlynuwapiHLmAmTBEEeQFLafA(1);
		}
	}

	protected override void LiXAHjDsSjcjuheRSvInddHJDOVCA(int P_0)
	{
		base.LiXAHjDsSjcjuheRSvInddHJDOVCA(P_0);
		LiXAHjDsSjcjuheRSvInddHJDOVCA((MbnhNztvlYEMfnRNZAzRFTGcWsDiA)P_0);
	}

	protected virtual void LiXAHjDsSjcjuheRSvInddHJDOVCA(MbnhNztvlYEMfnRNZAzRFTGcWsDiA P_0)
	{
		jtAeQMwqfCHdCmeHvhaRCqwDmBxb jtAeQMwqfCHdCmeHvhaRCqwDmBxb2 = jfPgAiHCXDOsCqPqzSwgbROIKKdw();
		if (jtAeQMwqfCHdCmeHvhaRCqwDmBxb2 != null && ((uint)jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.autoGeneratedValueFlags & (uint)P_0) != 0 && (P_0 & MbnhNztvlYEMfnRNZAzRFTGcWsDiA.DescriptiveName) != MbnhNztvlYEMfnRNZAzRFTGcWsDiA.None && (jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.autoGeneratedValueFlags & 1) != 0)
		{
			if (jfPgAiHCXDOsCqPqzSwgbROIKKdw() != null)
			{
				jfPgAiHCXDOsCqPqzSwgbROIKKdw().nonLocalizedDescriptiveName = null;
			}
			UADvwlynuwapiHLmAmTBEEeQFLafA(1);
			jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.autoGeneratedValueFlags &= -2;
		}
	}

	private void LiXAHjDsSjcjuheRSvInddHJDOVCA(VEYElUHTAVQERqFafltfcwjOaUMyA P_0)
	{
		MbnhNztvlYEMfnRNZAzRFTGcWsDiA mbnhNztvlYEMfnRNZAzRFTGcWsDiA = cfJjiFeTHaaDjDguihuHBEeWpOdD(P_0);
		if (mbnhNztvlYEMfnRNZAzRFTGcWsDiA != MbnhNztvlYEMfnRNZAzRFTGcWsDiA.None)
		{
			LiXAHjDsSjcjuheRSvInddHJDOVCA(mbnhNztvlYEMfnRNZAzRFTGcWsDiA);
		}
	}

	protected virtual MbnhNztvlYEMfnRNZAzRFTGcWsDiA cfJjiFeTHaaDjDguihuHBEeWpOdD(VEYElUHTAVQERqFafltfcwjOaUMyA P_0)
	{
		MbnhNztvlYEMfnRNZAzRFTGcWsDiA mbnhNztvlYEMfnRNZAzRFTGcWsDiA = MbnhNztvlYEMfnRNZAzRFTGcWsDiA.None;
		if ((P_0 & VEYElUHTAVQERqFafltfcwjOaUMyA.Names) != VEYElUHTAVQERqFafltfcwjOaUMyA.None)
		{
			mbnhNztvlYEMfnRNZAzRFTGcWsDiA |= MbnhNztvlYEMfnRNZAzRFTGcWsDiA.DescriptiveName;
		}
		return mbnhNztvlYEMfnRNZAzRFTGcWsDiA;
	}

	protected override void IOIteHoWYMIdXUPYMcUTgwJmPXpoA()
	{
		base.IOIteHoWYMIdXUPYMcUTgwJmPXpoA();
		hdKvZSMBobFalOMlTkDjSeXHEDLKA(1, new WkflcJKKhlDFbBrbgxTHkqcdvDwd
		{
			LTGLdhEbjhgPoerZJGmVXTZoYKUIA = pBHGSdiKqWIcVIxiLTzkoXwKRJelA
		});
	}
}
