using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class nUJgYArIGyJREiRpVnTschssHiew
{
	private class mRyKAsvILgagPiengrihRbSeUmfMA
	{
		private class wigedByGrjeSUecsLqZmJPUOKDHL
		{
			private int MTiEXxUEHuZcaaAutgRPdoQYFXJSA;

			private kEkzcEodlTrwBYRNxlXZLWomlqLe[] xZMbnHeIbPmvTipyxhlotwyWgBJV;

			private tbtNNcqZoEMYvjOwaQJHbZmAaPhi[] cineTvljUGXFyQJnIZZrkjAmOcPJ;

			public wigedByGrjeSUecsLqZmJPUOKDHL(int P_0)
			{
				MTiEXxUEHuZcaaAutgRPdoQYFXJSA = P_0;
				xZMbnHeIbPmvTipyxhlotwyWgBJV = new kEkzcEodlTrwBYRNxlXZLWomlqLe[20];
				for (int i = 0; i < xZMbnHeIbPmvTipyxhlotwyWgBJV.Length; i++)
				{
					xZMbnHeIbPmvTipyxhlotwyWgBJV[i] = new kEkzcEodlTrwBYRNxlXZLWomlqLe();
				}
				cineTvljUGXFyQJnIZZrkjAmOcPJ = new tbtNNcqZoEMYvjOwaQJHbZmAaPhi[29];
				for (int j = 0; j < cineTvljUGXFyQJnIZZrkjAmOcPJ.Length; j++)
				{
					cineTvljUGXFyQJnIZZrkjAmOcPJ[j] = new tbtNNcqZoEMYvjOwaQJHbZmAaPhi(j);
				}
			}

			public void CTaFxMPlJRtEmDYVcQJTKleygWCG()
			{
				for (int i = 0; i < xZMbnHeIbPmvTipyxhlotwyWgBJV.Length; i++)
				{
					bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(MTiEXxUEHuZcaaAutgRPdoQYFXJSA, i);
					xZMbnHeIbPmvTipyxhlotwyWgBJV[i].MCgIPHNfYCAinehxzPkwILTGxHlxB(joystickButtonValueByJoystickIndex);
				}
				for (int j = 0; j < cineTvljUGXFyQJnIZZrkjAmOcPJ.Length; j++)
				{
					float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(MTiEXxUEHuZcaaAutgRPdoQYFXJSA, j);
					cineTvljUGXFyQJnIZZrkjAmOcPJ[j].qdsKoRyVygqQJCrLhJHcWAcZWJJe(joystickAxisRawValueByJoystickIndex);
				}
			}

			public void abjOWsAxKDVFnVbhDiNEJigFInlPA()
			{
				for (int i = 0; i < xZMbnHeIbPmvTipyxhlotwyWgBJV.Length; i++)
				{
					xZMbnHeIbPmvTipyxhlotwyWgBJV[i].OAHgnTgZKCcVobXVpCmVlcydfbsZA = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(MTiEXxUEHuZcaaAutgRPdoQYFXJSA, i);
				}
				for (int j = 0; j < cineTvljUGXFyQJnIZZrkjAmOcPJ.Length; j++)
				{
					cineTvljUGXFyQJnIZZrkjAmOcPJ[j].CGnBFdeXjQfcxZdTsEDvwNyQndd = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(MTiEXxUEHuZcaaAutgRPdoQYFXJSA, j);
				}
			}

			public bool ucwJdwUgoMQZbKfIQVTeFvxzHliV(int P_0)
			{
				if (P_0 < 0 || P_0 >= xZMbnHeIbPmvTipyxhlotwyWgBJV.Length)
				{
					return false;
				}
				return xZMbnHeIbPmvTipyxhlotwyWgBJV[P_0].OAHgnTgZKCcVobXVpCmVlcydfbsZA;
			}

			public bool VQLYUOkpPDAoYCzFUMQDHSoielrsA(int P_0)
			{
				if (P_0 < 0 || P_0 >= xZMbnHeIbPmvTipyxhlotwyWgBJV.Length)
				{
					return false;
				}
				return xZMbnHeIbPmvTipyxhlotwyWgBJV[P_0].VstpODNsgRGKQkCzwfjBiiCDaKFOB;
			}

			public bool dpmCjDEDHpwuMBStZjqjBSIjovSe(int P_0)
			{
				if (P_0 < 0 || P_0 >= xZMbnHeIbPmvTipyxhlotwyWgBJV.Length)
				{
					return false;
				}
				return xZMbnHeIbPmvTipyxhlotwyWgBJV[P_0].cuAKwrpCsUVFIXeGkRciMXIpLIIB;
			}

			public float KqGHBAHGBgTqVUNQANInRXFeulPl(int P_0)
			{
				if (P_0 < 0 || P_0 >= cineTvljUGXFyQJnIZZrkjAmOcPJ.Length)
				{
					return 0f;
				}
				return cineTvljUGXFyQJnIZZrkjAmOcPJ[P_0].CGnBFdeXjQfcxZdTsEDvwNyQndd;
			}

			public bool htpakiJiwadcqgClHWYogcVXkQGD(int P_0, bool P_1)
			{
				if (P_0 < 0 || P_0 >= cineTvljUGXFyQJnIZZrkjAmOcPJ.Length)
				{
					return false;
				}
				return cineTvljUGXFyQJnIZZrkjAmOcPJ[P_0].wtXuFufXnWbyjeqKUpioWKonhIYE(P_1);
			}

			public void pPSIficoPFHTWHRktkqhojOONqWv()
			{
				for (int i = 0; i < xZMbnHeIbPmvTipyxhlotwyWgBJV.Length; i++)
				{
					xZMbnHeIbPmvTipyxhlotwyWgBJV[i].dEuCBYFgisyanrlcIzsknnKkzLZf();
				}
				for (int j = 0; j < cineTvljUGXFyQJnIZZrkjAmOcPJ.Length; j++)
				{
					cineTvljUGXFyQJnIZZrkjAmOcPJ[j].gKruJPdWKubYpXAVYWIBdjzUrFRQ();
				}
			}
		}

		private class tJIldzaKKJftYiextJtxDBvtHpTmA
		{
			private kEkzcEodlTrwBYRNxlXZLWomlqLe[] GIoaAGfLTtjVHhzvLfMHmRBFnOfH;

			public tJIldzaKKJftYiextJtxDBvtHpTmA()
			{
				GIoaAGfLTtjVHhzvLfMHmRBFnOfH = new kEkzcEodlTrwBYRNxlXZLWomlqLe[7];
				for (int i = 0; i < GIoaAGfLTtjVHhzvLfMHmRBFnOfH.Length; i++)
				{
					GIoaAGfLTtjVHhzvLfMHmRBFnOfH[i] = new kEkzcEodlTrwBYRNxlXZLWomlqLe();
				}
			}

			public void cSUxJaClNTPfWMplpfrZGCOgrfOK()
			{
				for (int i = 0; i < GIoaAGfLTtjVHhzvLfMHmRBFnOfH.Length; i++)
				{
					GIoaAGfLTtjVHhzvLfMHmRBFnOfH[i].OAHgnTgZKCcVobXVpCmVlcydfbsZA = Input.GetButton("MouseButton" + i);
				}
			}

			public bool yDEURQkcQkdtFAXmxNvHNyqhmWJM(int P_0)
			{
				if (P_0 < 0 || P_0 >= GIoaAGfLTtjVHhzvLfMHmRBFnOfH.Length)
				{
					return false;
				}
				return GIoaAGfLTtjVHhzvLfMHmRBFnOfH[P_0].OAHgnTgZKCcVobXVpCmVlcydfbsZA;
			}

			public bool AIGnldlZPzejfAOCqOWmDTiXPKvA(int P_0)
			{
				if (P_0 < 0 || P_0 >= GIoaAGfLTtjVHhzvLfMHmRBFnOfH.Length)
				{
					return false;
				}
				return GIoaAGfLTtjVHhzvLfMHmRBFnOfH[P_0].VstpODNsgRGKQkCzwfjBiiCDaKFOB;
			}

			public bool fsPArmBzLJCrrMRxxMIYmhYfiGAJ(int P_0)
			{
				if (P_0 < 0 || P_0 >= GIoaAGfLTtjVHhzvLfMHmRBFnOfH.Length)
				{
					return false;
				}
				return GIoaAGfLTtjVHhzvLfMHmRBFnOfH[P_0].cuAKwrpCsUVFIXeGkRciMXIpLIIB;
			}

			public void umNgLpuobdKAOJMbKFSuecCzhWUZ()
			{
				for (int i = 0; i < GIoaAGfLTtjVHhzvLfMHmRBFnOfH.Length; i++)
				{
					GIoaAGfLTtjVHhzvLfMHmRBFnOfH[i].dEuCBYFgisyanrlcIzsknnKkzLZf();
				}
			}
		}

		private class kEkzcEodlTrwBYRNxlXZLWomlqLe
		{
			private bool NKbciToJFpzFtDmlPIkBdJyYDTXj;

			private bool fnAJGlQwbOdXWEOLnodYDiIfdWjhA;

			public bool OAHgnTgZKCcVobXVpCmVlcydfbsZA
			{
				get
				{
					return NKbciToJFpzFtDmlPIkBdJyYDTXj;
				}
				set
				{
					fnAJGlQwbOdXWEOLnodYDiIfdWjhA = NKbciToJFpzFtDmlPIkBdJyYDTXj;
					NKbciToJFpzFtDmlPIkBdJyYDTXj = nKbciToJFpzFtDmlPIkBdJyYDTXj;
				}
			}

			public bool VstpODNsgRGKQkCzwfjBiiCDaKFOB
			{
				get
				{
					if (NKbciToJFpzFtDmlPIkBdJyYDTXj)
					{
						return !fnAJGlQwbOdXWEOLnodYDiIfdWjhA;
					}
					return false;
				}
			}

			public bool cuAKwrpCsUVFIXeGkRciMXIpLIIB
			{
				get
				{
					if (fnAJGlQwbOdXWEOLnodYDiIfdWjhA)
					{
						return !NKbciToJFpzFtDmlPIkBdJyYDTXj;
					}
					return false;
				}
			}

			public void MCgIPHNfYCAinehxzPkwILTGxHlxB(bool P_0)
			{
				NKbciToJFpzFtDmlPIkBdJyYDTXj = P_0;
				fnAJGlQwbOdXWEOLnodYDiIfdWjhA = P_0;
			}

			public void dEuCBYFgisyanrlcIzsknnKkzLZf()
			{
				NKbciToJFpzFtDmlPIkBdJyYDTXj = false;
				fnAJGlQwbOdXWEOLnodYDiIfdWjhA = false;
			}
		}

		private class tbtNNcqZoEMYvjOwaQJHbZmAaPhi
		{
			private int iyFipmJnRfCmSTWsamGbNNfSEhrAA;

			private float dulrvijQMtBOBhIYUAirhRGRcsQ;

			private float RVCDYwmhFKPwZsmrEfXxOiaoIYmJ;

			public float CGnBFdeXjQfcxZdTsEDvwNyQndd
			{
				get
				{
					return dulrvijQMtBOBhIYUAirhRGRcsQ;
				}
				set
				{
					dulrvijQMtBOBhIYUAirhRGRcsQ = num;
				}
			}

			public tbtNNcqZoEMYvjOwaQJHbZmAaPhi(int P_0)
			{
				iyFipmJnRfCmSTWsamGbNNfSEhrAA = P_0;
			}

			public void qdsKoRyVygqQJCrLhJHcWAcZWJJe(float P_0)
			{
				RVCDYwmhFKPwZsmrEfXxOiaoIYmJ = P_0;
				dulrvijQMtBOBhIYUAirhRGRcsQ = P_0;
			}

			public bool wtXuFufXnWbyjeqKUpioWKonhIYE(bool P_0)
			{
				float num = dulrvijQMtBOBhIYUAirhRGRcsQ - RVCDYwmhFKPwZsmrEfXxOiaoIYmJ;
				if (P_0 && num < 0f)
				{
					return false;
				}
				if (MathTools.Abs(num) > 0.7f)
				{
					return true;
				}
				return false;
			}

			public void gKruJPdWKubYpXAVYWIBdjzUrFRQ()
			{
				dulrvijQMtBOBhIYUAirhRGRcsQ = 0f;
				RVCDYwmhFKPwZsmrEfXxOiaoIYmJ = 0f;
			}
		}

		private wigedByGrjeSUecsLqZmJPUOKDHL[] SRxaXNbBRvfKNepSZslNomMhtezHA;

		private tJIldzaKKJftYiextJtxDBvtHpTmA iGPdyAaOPeNDBfNEFdjbVpNvJupKA;

		public mRyKAsvILgagPiengrihRbSeUmfMA()
		{
			SRxaXNbBRvfKNepSZslNomMhtezHA = new wigedByGrjeSUecsLqZmJPUOKDHL[16];
			for (int i = 0; i < SRxaXNbBRvfKNepSZslNomMhtezHA.Length; i++)
			{
				SRxaXNbBRvfKNepSZslNomMhtezHA[i] = new wigedByGrjeSUecsLqZmJPUOKDHL(i);
			}
			iGPdyAaOPeNDBfNEFdjbVpNvJupKA = new tJIldzaKKJftYiextJtxDBvtHpTmA();
		}

		public void iUfdfpdFwMZppvGWohKgTBrJlQzEb()
		{
			for (int i = 0; i < SRxaXNbBRvfKNepSZslNomMhtezHA.Length; i++)
			{
				SRxaXNbBRvfKNepSZslNomMhtezHA[i].CTaFxMPlJRtEmDYVcQJTKleygWCG();
			}
		}

		public void ZTDnEcCVxAUHEpyozGugEwwIZbXH()
		{
			for (int i = 0; i < SRxaXNbBRvfKNepSZslNomMhtezHA.Length; i++)
			{
				SRxaXNbBRvfKNepSZslNomMhtezHA[i].abjOWsAxKDVFnVbhDiNEJigFInlPA();
			}
			iGPdyAaOPeNDBfNEFdjbVpNvJupKA.cSUxJaClNTPfWMplpfrZGCOgrfOK();
		}

		public bool pvgRGVQtSLZnFoVSvmabfIXcdOnl(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= SRxaXNbBRvfKNepSZslNomMhtezHA.Length)
			{
				return false;
			}
			return SRxaXNbBRvfKNepSZslNomMhtezHA[P_0].ucwJdwUgoMQZbKfIQVTeFvxzHliV(P_1);
		}

		public bool hEQPfuCtiNKdYhrByvOSORlTHfAN(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= SRxaXNbBRvfKNepSZslNomMhtezHA.Length)
			{
				return false;
			}
			return SRxaXNbBRvfKNepSZslNomMhtezHA[P_0].VQLYUOkpPDAoYCzFUMQDHSoielrsA(P_1);
		}

		public bool uORaqvxlEjGRFMOMkdSjhIzgFWhjA(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= SRxaXNbBRvfKNepSZslNomMhtezHA.Length)
			{
				return false;
			}
			return SRxaXNbBRvfKNepSZslNomMhtezHA[P_0].dpmCjDEDHpwuMBStZjqjBSIjovSe(P_1);
		}

		public bool eyPKxJFJCSQqwyMVyzUORIeYPLLF(int P_0, int P_1, bool P_2)
		{
			if (P_0 < 0 || P_0 >= SRxaXNbBRvfKNepSZslNomMhtezHA.Length)
			{
				return false;
			}
			return SRxaXNbBRvfKNepSZslNomMhtezHA[P_0].htpakiJiwadcqgClHWYogcVXkQGD(P_1, P_2);
		}

		public bool FwPXqoSSDelTxfsRKejxWZswxBTE(int P_0)
		{
			return iGPdyAaOPeNDBfNEFdjbVpNvJupKA.yDEURQkcQkdtFAXmxNvHNyqhmWJM(P_0);
		}

		public bool wBPpOUAFNDSTpYsTVEOMZcIlasyH(int P_0)
		{
			return iGPdyAaOPeNDBfNEFdjbVpNvJupKA.AIGnldlZPzejfAOCqOWmDTiXPKvA(P_0);
		}

		public bool KmBrzznCqcbNRgexYNDKheamcgEdb(int P_0)
		{
			return iGPdyAaOPeNDBfNEFdjbVpNvJupKA.fsPArmBzLJCrrMRxxMIYmhYfiGAJ(P_0);
		}

		public void PEBrafbbavsEzrhKmsgdfDsDptNp()
		{
			for (int i = 0; i < SRxaXNbBRvfKNepSZslNomMhtezHA.Length; i++)
			{
				SRxaXNbBRvfKNepSZslNomMhtezHA[i].pPSIficoPFHTWHRktkqhojOONqWv();
			}
			iGPdyAaOPeNDBfNEFdjbVpNvJupKA.umNgLpuobdKAOJMbKFSuecCzhWUZ();
		}
	}

	private UpdateLoopType DZDztHVItZvBSYVrrELFJmfBVhnH;

	private mRyKAsvILgagPiengrihRbSeUmfMA wDNjTspGeFoRyLLtmYxNFZNEPkpl;

	private IndexedDictionary<int, mRyKAsvILgagPiengrihRbSeUmfMA> WThInsRNxKAhvTMhRBTmaAgaoMtY;

	public nUJgYArIGyJREiRpVnTschssHiew(UpdateLoopSetting P_0)
	{
		WThInsRNxKAhvTMhRBTmaAgaoMtY = new IndexedDictionary<int, mRyKAsvILgagPiengrihRbSeUmfMA>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				WThInsRNxKAhvTMhRBTmaAgaoMtY.Add((int)list[i], new mRyKAsvILgagPiengrihRbSeUmfMA());
			}
		}
		DZDztHVItZvBSYVrrELFJmfBVhnH = UpdateLoopType.Update;
		wDNjTspGeFoRyLLtmYxNFZNEPkpl = WThInsRNxKAhvTMhRBTmaAgaoMtY.GetValue(0);
	}

	public void GvoEQNSBCwbqzCbkNArnnMgVHbKKA()
	{
		trEHgUrxrqiIEwrEbKXjWypffMjc(ReInput.currentUpdateLoop);
		wDNjTspGeFoRyLLtmYxNFZNEPkpl.iUfdfpdFwMZppvGWohKgTBrJlQzEb();
	}

	public void kwTOBjSQWOYXFNzOfKKuhldbbXYf(UpdateLoopType P_0)
	{
		trEHgUrxrqiIEwrEbKXjWypffMjc(P_0);
		wDNjTspGeFoRyLLtmYxNFZNEPkpl.ZTDnEcCVxAUHEpyozGugEwwIZbXH();
	}

	public bool brIvlnmCzmfCDFIujQwJkzumOjsD(int P_0, int P_1)
	{
		return wDNjTspGeFoRyLLtmYxNFZNEPkpl.pvgRGVQtSLZnFoVSvmabfIXcdOnl(P_0, P_1);
	}

	public bool hbPLVVmrYZvTFcFqkCCgODLTCQzJ(int P_0, int P_1)
	{
		return wDNjTspGeFoRyLLtmYxNFZNEPkpl.hEQPfuCtiNKdYhrByvOSORlTHfAN(P_0, P_1);
	}

	public bool KxBYoEJDQArSzacAcMkzgCFtftNF(int P_0, int P_1)
	{
		return wDNjTspGeFoRyLLtmYxNFZNEPkpl.uORaqvxlEjGRFMOMkdSjhIzgFWhjA(P_0, P_1);
	}

	public bool NWyZCWuyDfHqZMYbAbZVOazZkeeI(int P_0, int P_1, bool P_2)
	{
		return wDNjTspGeFoRyLLtmYxNFZNEPkpl.eyPKxJFJCSQqwyMVyzUORIeYPLLF(P_0, P_1, P_2);
	}

	public bool egtJjEIJTFVwotaTYTOyzaOkHAaA(int P_0)
	{
		return wDNjTspGeFoRyLLtmYxNFZNEPkpl.FwPXqoSSDelTxfsRKejxWZswxBTE(P_0);
	}

	public bool ytUYhswqttasXRWnWLizXXJSEsPX(int P_0)
	{
		return wDNjTspGeFoRyLLtmYxNFZNEPkpl.wBPpOUAFNDSTpYsTVEOMZcIlasyH(P_0);
	}

	public bool dRHviriYAyjXHIRcCrpJHPSpwFuy(int P_0)
	{
		return wDNjTspGeFoRyLLtmYxNFZNEPkpl.KmBrzznCqcbNRgexYNDKheamcgEdb(P_0);
	}

	public void eEXmEuiMvYBNMbfEtQmyPXlpRgRu()
	{
		for (int i = 0; i < WThInsRNxKAhvTMhRBTmaAgaoMtY.Count; i++)
		{
			WThInsRNxKAhvTMhRBTmaAgaoMtY[i].PEBrafbbavsEzrhKmsgdfDsDptNp();
		}
	}

	private void trEHgUrxrqiIEwrEbKXjWypffMjc(UpdateLoopType P_0)
	{
		if (DZDztHVItZvBSYVrrELFJmfBVhnH != P_0)
		{
			DZDztHVItZvBSYVrrELFJmfBVhnH = P_0;
			wDNjTspGeFoRyLLtmYxNFZNEPkpl = WThInsRNxKAhvTMhRBTmaAgaoMtY.GetValue((int)P_0);
		}
	}
}
