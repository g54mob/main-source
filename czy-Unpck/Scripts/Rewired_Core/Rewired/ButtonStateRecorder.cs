using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	internal class ButtonStateRecorder
	{
		private class EmyLeOGLoCFzEMcEvEMqbQXUnZI
		{
			public bool nuUsaiDejZRDtBfHlGgxzzfWtr;

			public double CSSejXCuztgiDHCfCQsxjZsGPQNg;

			public void FMjbXwujmHnZzQbodRBJzieOPHZ(EmyLeOGLoCFzEMcEvEMqbQXUnZI P_0)
			{
				nuUsaiDejZRDtBfHlGgxzzfWtr = P_0.nuUsaiDejZRDtBfHlGgxzzfWtr;
				CSSejXCuztgiDHCfCQsxjZsGPQNg = P_0.CSSejXCuztgiDHCfCQsxjZsGPQNg;
			}

			public void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
			{
				nuUsaiDejZRDtBfHlGgxzzfWtr = false;
				while (true)
				{
					int num = -260261419;
					while (true)
					{
						switch (num ^ -260261420)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0025;
						case 2:
							return;
						}
						break;
						IL_0025:
						CSSejXCuztgiDHCfCQsxjZsGPQNg = 0.0;
						num = -260261418;
					}
				}
			}
		}

		private const int ZqcIFQktMSrpseMCjiMgmOouqoU = 3;

		private EmyLeOGLoCFzEMcEvEMqbQXUnZI[] pYylSnaZhhHPlmcssGUseHaIflO;

		private EmyLeOGLoCFzEMcEvEMqbQXUnZI[] kqcaSrFzqPRkoqjZoPyrKnPjxME;

		private int OhJkGcDECQCkifMfZHkmLTKAivW;

		private int bElCNoeuQhESLqkQFMDyphncLDb;

		private uint agwKtMNPxHvvRKVESMnlstIkgPV;

		public double timePressed
		{
			get
			{
				if (!pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].nuUsaiDejZRDtBfHlGgxzzfWtr)
				{
					return 0.0;
				}
				return ReInput.unscaledTime - pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].CSSejXCuztgiDHCfCQsxjZsGPQNg;
			}
		}

		public double timeUnpressed
		{
			get
			{
				if (pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].nuUsaiDejZRDtBfHlGgxzzfWtr)
				{
					return 0.0;
				}
				return ReInput.unscaledTime - pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].CSSejXCuztgiDHCfCQsxjZsGPQNg;
			}
		}

		public double lastTimePressed
		{
			get
			{
				if (pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].nuUsaiDejZRDtBfHlGgxzzfWtr)
				{
					return ReInput.unscaledTime;
				}
				return pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].CSSejXCuztgiDHCfCQsxjZsGPQNg;
			}
		}

		public double lastTimeUnpressed
		{
			get
			{
				if (!pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].nuUsaiDejZRDtBfHlGgxzzfWtr)
				{
					return ReInput.unscaledTime;
				}
				return pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].CSSejXCuztgiDHCfCQsxjZsGPQNg;
			}
		}

		public double lastTimeStateChangedToPressed
		{
			get
			{
				if (pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].nuUsaiDejZRDtBfHlGgxzzfWtr)
				{
					return pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].CSSejXCuztgiDHCfCQsxjZsGPQNg;
				}
				return pYylSnaZhhHPlmcssGUseHaIflO[VsIFwrLqQSNExJbgWuQlRNsuwCF(OhJkGcDECQCkifMfZHkmLTKAivW, 1)].CSSejXCuztgiDHCfCQsxjZsGPQNg;
			}
		}

		public double lastTimeStateChangedToUnpressed
		{
			get
			{
				if (!pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].nuUsaiDejZRDtBfHlGgxzzfWtr)
				{
					return pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].CSSejXCuztgiDHCfCQsxjZsGPQNg;
				}
				return pYylSnaZhhHPlmcssGUseHaIflO[VsIFwrLqQSNExJbgWuQlRNsuwCF(OhJkGcDECQCkifMfZHkmLTKAivW, 1)].CSSejXCuztgiDHCfCQsxjZsGPQNg;
			}
		}

		public double lastTimeStateChanged => pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].CSSejXCuztgiDHCfCQsxjZsGPQNg;

		public ButtonStateRecorder()
		{
			pYylSnaZhhHPlmcssGUseHaIflO = new EmyLeOGLoCFzEMcEvEMqbQXUnZI[3];
			kqcaSrFzqPRkoqjZoPyrKnPjxME = new EmyLeOGLoCFzEMcEvEMqbQXUnZI[3];
			for (int i = 0; i < 3; i++)
			{
				pYylSnaZhhHPlmcssGUseHaIflO[i] = new EmyLeOGLoCFzEMcEvEMqbQXUnZI();
				kqcaSrFzqPRkoqjZoPyrKnPjxME[i] = new EmyLeOGLoCFzEMcEvEMqbQXUnZI();
			}
			OhJkGcDECQCkifMfZHkmLTKAivW = 0;
			bElCNoeuQhESLqkQFMDyphncLDb = 0;
		}

		public void GzCliicOSMFLMvKajLgvnmGSSrh(bool P_0, bool P_1, double P_2)
		{
			bool flag = ((!pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].nuUsaiDejZRDtBfHlGgxzzfWtr) ? P_0 : P_1);
			if (pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].nuUsaiDejZRDtBfHlGgxzzfWtr == flag)
			{
				if (ReInput.currentFrame == MiscTools.Tick(agwKtMNPxHvvRKVESMnlstIkgPV))
				{
					utpxbprwNqPosWrGmfTGMnXGFxz();
					goto IL_0046;
				}
				return;
			}
			goto IL_0070;
			IL_0046:
			int num = 1057981113;
			goto IL_004b;
			IL_0070:
			utpxbprwNqPosWrGmfTGMnXGFxz();
			num = 1057981114;
			goto IL_004b;
			IL_004b:
			switch (num ^ 0x3F0F82B8)
			{
			case 0:
				break;
			case 1:
				return;
			case 3:
				goto IL_0070;
			default:
				agwKtMNPxHvvRKVESMnlstIkgPV = ReInput.currentFrame;
				OhJkGcDECQCkifMfZHkmLTKAivW = kvdfrouRebNJLBlkNIrtWKtdfpU(OhJkGcDECQCkifMfZHkmLTKAivW, 1);
				pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].nuUsaiDejZRDtBfHlGgxzzfWtr = flag;
				pYylSnaZhhHPlmcssGUseHaIflO[OhJkGcDECQCkifMfZHkmLTKAivW].CSSejXCuztgiDHCfCQsxjZsGPQNg = P_2;
				return;
			}
			goto IL_0046;
		}

		public bool EpDukhFQGxRGHEYYKBbTcdhlpvF(float P_0)
		{
			return EpDukhFQGxRGHEYYKBbTcdhlpvF(pYylSnaZhhHPlmcssGUseHaIflO, OhJkGcDECQCkifMfZHkmLTKAivW, P_0);
		}

		public bool YFcwYsGHWUqJGAKCDAwJBuWCCNiR(float P_0)
		{
			return EpDukhFQGxRGHEYYKBbTcdhlpvF(kqcaSrFzqPRkoqjZoPyrKnPjxME, bElCNoeuQhESLqkQFMDyphncLDb, P_0);
		}

		private static bool EpDukhFQGxRGHEYYKBbTcdhlpvF(EmyLeOGLoCFzEMcEvEMqbQXUnZI[] P_0, int P_1, float P_2)
		{
			if (P_2 <= 0f)
			{
				return false;
			}
			if (!P_0[P_1].nuUsaiDejZRDtBfHlGgxzzfWtr)
			{
				goto IL_0014;
			}
			int num = VsIFwrLqQSNExJbgWuQlRNsuwCF(P_1, 2);
			if (!P_0[num].nuUsaiDejZRDtBfHlGgxzzfWtr)
			{
				return false;
			}
			int num2;
			if (P_0[P_1].CSSejXCuztgiDHCfCQsxjZsGPQNg - P_0[num].CSSejXCuztgiDHCfCQsxjZsGPQNg <= (double)P_2)
			{
				num2 = -389551151;
				goto IL_0019;
			}
			return false;
			IL_0014:
			num2 = -389551150;
			goto IL_0019;
			IL_0019:
			switch (num2 ^ -389551149)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				return true;
			}
			goto IL_0014;
		}

		private void utpxbprwNqPosWrGmfTGMnXGFxz()
		{
			if (bElCNoeuQhESLqkQFMDyphncLDb != OhJkGcDECQCkifMfZHkmLTKAivW)
			{
				bElCNoeuQhESLqkQFMDyphncLDb = OhJkGcDECQCkifMfZHkmLTKAivW;
				goto IL_001a;
			}
			goto IL_0040;
			IL_0040:
			int num = 0;
			int num2 = 976840819;
			goto IL_001f;
			IL_001a:
			num2 = 976840816;
			goto IL_001f;
			IL_001f:
			while (true)
			{
				switch (num2 ^ 0x3A396872)
				{
				case 3:
					break;
				case 2:
					goto IL_0040;
				case 1:
					num2 = 976840822;
					continue;
				case 0:
					kqcaSrFzqPRkoqjZoPyrKnPjxME[num].FMjbXwujmHnZzQbodRBJzieOPHZ(pYylSnaZhhHPlmcssGUseHaIflO[num]);
					num++;
					num2 = 976840822;
					continue;
				default:
					if (num >= 3)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
			goto IL_001a;
		}

		public void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
		{
			OhJkGcDECQCkifMfZHkmLTKAivW = 0;
			bElCNoeuQhESLqkQFMDyphncLDb = 0;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < 3)
				{
					num2 = 2077268232;
					num3 = num2;
				}
				else
				{
					num2 = 2077268239;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x7BD0990C)
					{
					case 0:
						num2 = 2077268232;
						continue;
					case 2:
						break;
					case 1:
						kqcaSrFzqPRkoqjZoPyrKnPjxME[num].CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
						num++;
						num2 = 2077268238;
						continue;
					case 4:
						pYylSnaZhhHPlmcssGUseHaIflO[num].CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
						num2 = 2077268237;
						continue;
					default:
						agwKtMNPxHvvRKVESMnlstIkgPV = 0u;
						return;
					}
					break;
				}
			}
		}

		public void EobBEOKOMxGhZjszeEmLccSbrTvA(double P_0)
		{
			GzCliicOSMFLMvKajLgvnmGSSrh(false, false, P_0);
		}

		private static int kvdfrouRebNJLBlkNIrtWKtdfpU(int P_0, int P_1)
		{
			if (P_1 < 0)
			{
				P_1 = 0;
				goto IL_0007;
			}
			goto IL_0055;
			IL_0055:
			int num;
			if (P_1 > 3)
			{
				P_1 = 3;
				num = -1330419418;
				goto IL_000c;
			}
			goto IL_003c;
			IL_0007:
			num = -1330419419;
			goto IL_000c;
			IL_000c:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1330419417)
				{
				case 0:
					break;
				case 5:
					num2 -= 3;
					num = -1330419420;
					continue;
				case 1:
					goto IL_003c;
				case 4:
					goto IL_0055;
				case 2:
					num = -1330419418;
					continue;
				default:
					return num2;
				}
				break;
			}
			goto IL_0007;
			IL_003c:
			num2 = P_0 + P_1;
			int num3;
			if (num2 < 3)
			{
				num = -1330419420;
				num3 = num;
			}
			else
			{
				num = -1330419422;
				num3 = num;
			}
			goto IL_000c;
		}

		private static int VsIFwrLqQSNExJbgWuQlRNsuwCF(int P_0, int P_1)
		{
			if (P_1 >= 0)
			{
				goto IL_002f;
			}
			P_1 = 0;
			goto IL_004e;
			IL_0061:
			int num = default(int);
			return num;
			IL_004e:
			num = P_0 - P_1;
			int num2;
			if (num < 0)
			{
				num += 3;
				num2 = -970712499;
				goto IL_000e;
			}
			goto IL_0061;
			IL_002f:
			int num3;
			if (P_1 <= 3)
			{
				num2 = -970712500;
				num3 = num2;
			}
			else
			{
				num2 = -970712498;
				num3 = num2;
			}
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num2 ^ -970712500)
				{
				case 3:
					num2 = -970712504;
					continue;
				case 4:
					break;
				case 2:
					P_1 = 3;
					num2 = -970712500;
					continue;
				case 0:
					goto IL_004e;
				default:
					goto IL_0061;
				}
				break;
			}
			goto IL_002f;
		}
	}
}
