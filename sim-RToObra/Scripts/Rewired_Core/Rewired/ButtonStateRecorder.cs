using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	internal class ButtonStateRecorder
	{
		private class KYgUVGWALULSwTjcCputKotVZeo
		{
			public bool pskeOsiRTjphpRADazjneWPcqjBH;

			public float UESFPdaUzeGtgHDarRazwKPWEjH;

			public void DzhGtommJNlpRFKUAFaKGOCHKTz(KYgUVGWALULSwTjcCputKotVZeo P_0)
			{
				pskeOsiRTjphpRADazjneWPcqjBH = P_0.pskeOsiRTjphpRADazjneWPcqjBH;
				UESFPdaUzeGtgHDarRazwKPWEjH = P_0.UESFPdaUzeGtgHDarRazwKPWEjH;
			}

			public void EEGiMNPSMElaPgKQdmScoWLedfb()
			{
				pskeOsiRTjphpRADazjneWPcqjBH = false;
				UESFPdaUzeGtgHDarRazwKPWEjH = 0f;
			}
		}

		private const int NrmhUMcylCXXGpVaKjBpNYAheJw = 3;

		private KYgUVGWALULSwTjcCputKotVZeo[] rokTPxsNitEbJnvAHMxvBQpZKze;

		private KYgUVGWALULSwTjcCputKotVZeo[] wpkHWvNuJPnlUhmbFIicrNhuybo;

		private int OxNeOaNlbMdKKdyTycZbogmZlbuI;

		private int bUhKrgoWdnHcvxnkmzkvUPHtGVD;

		private uint yyqToOXbiTlDxXsbnGxqNjBbVwz;

		public float timePressed
		{
			get
			{
				if (!rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].pskeOsiRTjphpRADazjneWPcqjBH)
				{
					return 0f;
				}
				return ReInput.unscaledTime - rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].UESFPdaUzeGtgHDarRazwKPWEjH;
			}
		}

		public float timeUnpressed
		{
			get
			{
				if (rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].pskeOsiRTjphpRADazjneWPcqjBH)
				{
					return 0f;
				}
				return ReInput.unscaledTime - rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].UESFPdaUzeGtgHDarRazwKPWEjH;
			}
		}

		public float lastTimePressed
		{
			get
			{
				if (rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].pskeOsiRTjphpRADazjneWPcqjBH)
				{
					return ReInput.unscaledTime;
				}
				return rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].UESFPdaUzeGtgHDarRazwKPWEjH;
			}
		}

		public float lastTimeUnpressed
		{
			get
			{
				if (!rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].pskeOsiRTjphpRADazjneWPcqjBH)
				{
					return ReInput.unscaledTime;
				}
				return rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].UESFPdaUzeGtgHDarRazwKPWEjH;
			}
		}

		public float lastTimeStateChangedToPressed
		{
			get
			{
				if (rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].pskeOsiRTjphpRADazjneWPcqjBH)
				{
					return rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].UESFPdaUzeGtgHDarRazwKPWEjH;
				}
				return rokTPxsNitEbJnvAHMxvBQpZKze[HJQohxVhTQprHYHAbfJuwoGhcmpc(OxNeOaNlbMdKKdyTycZbogmZlbuI, 1)].UESFPdaUzeGtgHDarRazwKPWEjH;
			}
		}

		public float lastTimeStateChangedToUnpressed
		{
			get
			{
				if (!rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].pskeOsiRTjphpRADazjneWPcqjBH)
				{
					return rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].UESFPdaUzeGtgHDarRazwKPWEjH;
				}
				return rokTPxsNitEbJnvAHMxvBQpZKze[HJQohxVhTQprHYHAbfJuwoGhcmpc(OxNeOaNlbMdKKdyTycZbogmZlbuI, 1)].UESFPdaUzeGtgHDarRazwKPWEjH;
			}
		}

		public float lastTimeStateChanged
		{
			get
			{
				return rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].UESFPdaUzeGtgHDarRazwKPWEjH;
			}
		}

		public ButtonStateRecorder()
		{
			int num2 = default(int);
			while (true)
			{
				int num = -1779520378;
				while (true)
				{
					switch (num ^ -1779520382)
					{
					case 2:
						break;
					case 1:
						wpkHWvNuJPnlUhmbFIicrNhuybo[num2] = new KYgUVGWALULSwTjcCputKotVZeo();
						num2++;
						num = -1779520380;
						continue;
					case 0:
						num2 = 0;
						num = -1779520377;
						continue;
					case 5:
						num = -1779520380;
						continue;
					case 4:
						rokTPxsNitEbJnvAHMxvBQpZKze = new KYgUVGWALULSwTjcCputKotVZeo[3];
						wpkHWvNuJPnlUhmbFIicrNhuybo = new KYgUVGWALULSwTjcCputKotVZeo[3];
						num = -1779520382;
						continue;
					case 3:
						rokTPxsNitEbJnvAHMxvBQpZKze[num2] = new KYgUVGWALULSwTjcCputKotVZeo();
						num = -1779520381;
						continue;
					default:
						if (num2 >= 3)
						{
							OxNeOaNlbMdKKdyTycZbogmZlbuI = 0;
							bUhKrgoWdnHcvxnkmzkvUPHtGVD = 0;
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public void UZSQFwoMfSAzsmmSKmseCCiJWWD(bool P_0, bool P_1, float P_2)
		{
			bool flag = ((!rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].pskeOsiRTjphpRADazjneWPcqjBH) ? P_0 : P_1);
			while (true)
			{
				int num = -728990820;
				while (true)
				{
					switch (num ^ -728990819)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						if (rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].pskeOsiRTjphpRADazjneWPcqjBH == flag)
						{
							if (ReInput.currentFrame == MiscTools.Tick(yyqToOXbiTlDxXsbnGxqNjBbVwz))
							{
								ykpETparJkmfGlFZHaIXUtHDFXZS();
								num = -728990823;
								continue;
							}
							return;
						}
						goto case 5;
					case 4:
						return;
					case 0:
						yyqToOXbiTlDxXsbnGxqNjBbVwz = ReInput.currentFrame;
						OxNeOaNlbMdKKdyTycZbogmZlbuI = kpbgPbGoqrPttsIVcFdwVtcoutuF(OxNeOaNlbMdKKdyTycZbogmZlbuI, 1);
						rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].pskeOsiRTjphpRADazjneWPcqjBH = flag;
						num = -728990817;
						continue;
					case 2:
						rokTPxsNitEbJnvAHMxvBQpZKze[OxNeOaNlbMdKKdyTycZbogmZlbuI].UESFPdaUzeGtgHDarRazwKPWEjH = P_2;
						num = -728990821;
						continue;
					case 5:
						ykpETparJkmfGlFZHaIXUtHDFXZS();
						num = -728990819;
						continue;
					case 6:
						return;
					}
					break;
				}
			}
		}

		public bool IqTQGnJMxdgjdCDmjEaKjTBjuvfn(float P_0)
		{
			return IqTQGnJMxdgjdCDmjEaKjTBjuvfn(rokTPxsNitEbJnvAHMxvBQpZKze, OxNeOaNlbMdKKdyTycZbogmZlbuI, P_0);
		}

		public bool IDsmTsYvsShkgJoOkNxKBilXZrS(float P_0)
		{
			return IqTQGnJMxdgjdCDmjEaKjTBjuvfn(wpkHWvNuJPnlUhmbFIicrNhuybo, bUhKrgoWdnHcvxnkmzkvUPHtGVD, P_0);
		}

		private static bool IqTQGnJMxdgjdCDmjEaKjTBjuvfn(KYgUVGWALULSwTjcCputKotVZeo[] P_0, int P_1, float P_2)
		{
			if (P_2 <= 0f)
			{
				goto IL_0008;
			}
			int num;
			if (!P_0[P_1].pskeOsiRTjphpRADazjneWPcqjBH)
			{
				num = 1598286679;
				goto IL_000d;
			}
			int num2 = HJQohxVhTQprHYHAbfJuwoGhcmpc(P_1, 2);
			if (!P_0[num2].pskeOsiRTjphpRADazjneWPcqjBH)
			{
				return false;
			}
			if (P_0[P_1].UESFPdaUzeGtgHDarRazwKPWEjH - P_0[num2].UESFPdaUzeGtgHDarRazwKPWEjH <= P_2)
			{
				return true;
			}
			return false;
			IL_000d:
			switch (num ^ 0x5F43EB55)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				return false;
			}
			goto IL_0008;
			IL_0008:
			num = 1598286676;
			goto IL_000d;
		}

		private void ykpETparJkmfGlFZHaIXUtHDFXZS()
		{
			if (bUhKrgoWdnHcvxnkmzkvUPHtGVD != OxNeOaNlbMdKKdyTycZbogmZlbuI)
			{
				bUhKrgoWdnHcvxnkmzkvUPHtGVD = OxNeOaNlbMdKKdyTycZbogmZlbuI;
				goto IL_001a;
			}
			goto IL_0040;
			IL_0040:
			int num = 0;
			int num2 = 521799604;
			goto IL_001f;
			IL_001a:
			num2 = 521799606;
			goto IL_001f;
			IL_001f:
			while (true)
			{
				switch (num2 ^ 0x1F1A07B7)
				{
				case 0:
					break;
				case 1:
					goto IL_0040;
				case 4:
					wpkHWvNuJPnlUhmbFIicrNhuybo[num].DzhGtommJNlpRFKUAFaKGOCHKTz(rokTPxsNitEbJnvAHMxvBQpZKze[num]);
					num++;
					num2 = 521799605;
					continue;
				case 3:
					num2 = 521799605;
					continue;
				default:
					if (num >= 3)
					{
						return;
					}
					goto case 4;
				}
				break;
			}
			goto IL_001a;
		}

		public void EEGiMNPSMElaPgKQdmScoWLedfb()
		{
			OxNeOaNlbMdKKdyTycZbogmZlbuI = 0;
			bUhKrgoWdnHcvxnkmzkvUPHtGVD = 0;
			int num = 0;
			while (num < 3)
			{
				while (true)
				{
					rokTPxsNitEbJnvAHMxvBQpZKze[num].EEGiMNPSMElaPgKQdmScoWLedfb();
					int num2 = 691327271;
					while (true)
					{
						switch (num2 ^ 0x2934D124)
						{
						case 2:
							num2 = 691327269;
							continue;
						case 1:
							break;
						case 3:
							wpkHWvNuJPnlUhmbFIicrNhuybo[num].EEGiMNPSMElaPgKQdmScoWLedfb();
							num2 = 691327268;
							continue;
						case 0:
							num++;
							num2 = 691327264;
							continue;
						default:
							goto end_IL_0038;
						}
						break;
					}
					continue;
					end_IL_0038:
					break;
				}
			}
			yyqToOXbiTlDxXsbnGxqNjBbVwz = 0u;
		}

		public void WZzGaCOQpfHRhCqLXMXIzBuawBP(float P_0)
		{
			UZSQFwoMfSAzsmmSKmseCCiJWWD(false, false, P_0);
		}

		private static int kpbgPbGoqrPttsIVcFdwVtcoutuF(int P_0, int P_1)
		{
			if (P_1 < 0)
			{
				goto IL_0004;
			}
			goto IL_003d;
			IL_0004:
			int num = 1555778793;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x5CBB4CEB)
				{
				case 3:
					break;
				case 4:
					goto IL_002a;
				case 1:
					goto IL_003d;
				case 2:
					P_1 = 0;
					num = 1555778799;
					continue;
				default:
					goto IL_0055;
				}
				break;
			}
			goto IL_0004;
			IL_003d:
			if (P_1 > 3)
			{
				P_1 = 3;
				num = 1555778799;
				goto IL_0009;
			}
			goto IL_002a;
			IL_002a:
			int num2 = P_0 + P_1;
			if (num2 >= 3)
			{
				num2 -= 3;
				num = 1555778795;
				goto IL_0009;
			}
			goto IL_0055;
			IL_0055:
			return num2;
		}

		private static int HJQohxVhTQprHYHAbfJuwoGhcmpc(int P_0, int P_1)
		{
			if (P_1 >= 0)
			{
				goto IL_0033;
			}
			P_1 = 0;
			goto IL_0053;
			IL_000e:
			int num;
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x3CA7DBAB)
				{
				case 4:
					num = 1017633704;
					continue;
				case 3:
					break;
				case 0:
					num2 += 3;
					num = 1017633710;
					continue;
				case 1:
					goto IL_0053;
				case 2:
					P_1 = 3;
					num = 1017633706;
					continue;
				default:
					return num2;
				}
				break;
			}
			goto IL_0033;
			IL_0053:
			num2 = P_0 - P_1;
			int num3;
			if (num2 >= 0)
			{
				num = 1017633710;
				num3 = num;
			}
			else
			{
				num = 1017633707;
				num3 = num;
			}
			goto IL_000e;
			IL_0033:
			int num4;
			if (P_1 <= 3)
			{
				num = 1017633706;
				num4 = num;
			}
			else
			{
				num = 1017633705;
				num4 = num;
			}
			goto IL_000e;
		}
	}
}
