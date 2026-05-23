using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class nVoiynOsjugkJuOeheypUhVfWan
{
	private class cTYeMeZCBLDLfqbToBaskZPEXxDL
	{
		private class aTpVWNATCUOoyGvlIYNKpDYRkDT
		{
			private int iPJHmnBZwZyyrKapRxnHtBsSkn;

			private zxvELNFjcQtjwOgblGBPSavWWyfd[] USQZpFcFQqBJUckpyitMKctsvSza;

			private APQoyRnNhpWivbwQeIQWXnrthAi[] HFStzJyQGytgUBWpFJOoXXXwNYX;

			public aTpVWNATCUOoyGvlIYNKpDYRkDT(int index)
			{
				iPJHmnBZwZyyrKapRxnHtBsSkn = index;
				USQZpFcFQqBJUckpyitMKctsvSza = new zxvELNFjcQtjwOgblGBPSavWWyfd[20];
				for (int i = 0; i < USQZpFcFQqBJUckpyitMKctsvSza.Length; i++)
				{
					USQZpFcFQqBJUckpyitMKctsvSza[i] = new zxvELNFjcQtjwOgblGBPSavWWyfd();
				}
				HFStzJyQGytgUBWpFJOoXXXwNYX = new APQoyRnNhpWivbwQeIQWXnrthAi[29];
				for (int j = 0; j < HFStzJyQGytgUBWpFJOoXXXwNYX.Length; j++)
				{
					HFStzJyQGytgUBWpFJOoXXXwNYX[j] = new APQoyRnNhpWivbwQeIQWXnrthAi(j);
				}
			}

			public void BJTLXEjtRzwGSeFtYEySLofTbdi()
			{
				int num = 0;
				int num3 = default(int);
				while (true)
				{
					int num2 = -764530884;
					while (true)
					{
						switch (num2 ^ -764530888)
						{
						case 0:
							break;
						default:
							return;
						case 8:
							num3 = 0;
							num2 = -764530883;
							continue;
						case 1:
						{
							bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(iPJHmnBZwZyyrKapRxnHtBsSkn, num);
							USQZpFcFQqBJUckpyitMKctsvSza[num].BJTLXEjtRzwGSeFtYEySLofTbdi(joystickButtonValueByJoystickIndex);
							num++;
							num2 = -764530881;
							continue;
						}
						case 4:
							num2 = -764530881;
							continue;
						case 6:
							num3++;
							num2 = -764530883;
							continue;
						case 5:
						{
							int num5;
							if (num3 >= HFStzJyQGytgUBWpFJOoXXXwNYX.Length)
							{
								num2 = -764530885;
								num5 = num2;
							}
							else
							{
								num2 = -764530886;
								num5 = num2;
							}
							continue;
						}
						case 7:
						{
							int num4;
							if (num < USQZpFcFQqBJUckpyitMKctsvSza.Length)
							{
								num2 = -764530887;
								num4 = num2;
							}
							else
							{
								num2 = -764530896;
								num4 = num2;
							}
							continue;
						}
						case 2:
						{
							float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(iPJHmnBZwZyyrKapRxnHtBsSkn, num3);
							HFStzJyQGytgUBWpFJOoXXXwNYX[num3].BJTLXEjtRzwGSeFtYEySLofTbdi(joystickAxisRawValueByJoystickIndex);
							num2 = -764530882;
							continue;
						}
						case 3:
							return;
						}
						break;
					}
				}
			}

			public void UZSQFwoMfSAzsmmSKmseCCiJWWD()
			{
				int num = 0;
				int num2 = default(int);
				while (true)
				{
					IL_008b:
					int num3;
					if (num >= USQZpFcFQqBJUckpyitMKctsvSza.Length)
					{
						num2 = 0;
						num3 = 1052484548;
						goto IL_000c;
					}
					goto IL_0039;
					IL_000c:
					while (true)
					{
						switch (num3 ^ 0x3EBBA3C4)
						{
						case 6:
							num3 = 1052484545;
							continue;
						case 5:
							break;
						case 0:
							num3 = 1052484549;
							continue;
						case 4:
							num2++;
							num3 = 1052484549;
							continue;
						case 7:
							HFStzJyQGytgUBWpFJOoXXXwNYX[num2].value = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(iPJHmnBZwZyyrKapRxnHtBsSkn, num2);
							num3 = 1052484544;
							continue;
						case 2:
							goto IL_008b;
						case 3:
							num++;
							num3 = 1052484550;
							continue;
						default:
							if (num2 >= HFStzJyQGytgUBWpFJOoXXXwNYX.Length)
							{
								return;
							}
							goto case 7;
						}
						break;
					}
					goto IL_0039;
					IL_0039:
					USQZpFcFQqBJUckpyitMKctsvSza[num].value = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(iPJHmnBZwZyyrKapRxnHtBsSkn, num);
					num3 = 1052484551;
					goto IL_000c;
				}
			}

			public bool lvyTpewEByrJQaPpHiuasLSeNzw(int P_0)
			{
				if (P_0 < 0 || P_0 >= USQZpFcFQqBJUckpyitMKctsvSza.Length)
				{
					return false;
				}
				return USQZpFcFQqBJUckpyitMKctsvSza[P_0].value;
			}

			public bool kmPAfEKnCyTirEYSWkaOedaLedN(int P_0)
			{
				if (P_0 < 0 || P_0 >= USQZpFcFQqBJUckpyitMKctsvSza.Length)
				{
					return false;
				}
				return USQZpFcFQqBJUckpyitMKctsvSza[P_0].justPressed;
			}

			public bool OyXGTSwiLyydixsXoAkXTFGBrMP(int P_0)
			{
				if (P_0 < 0 || P_0 >= USQZpFcFQqBJUckpyitMKctsvSza.Length)
				{
					return false;
				}
				return USQZpFcFQqBJUckpyitMKctsvSza[P_0].justReleased;
			}

			public float gsiPWtFMoYarPDgrBaZqlwGphcI(int P_0)
			{
				if (P_0 >= 0)
				{
					while (true)
					{
						int num = 161691927;
						while (true)
						{
							switch (num ^ 0x9A33916)
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
							if (P_0 >= HFStzJyQGytgUBWpFJOoXXXwNYX.Length)
							{
								num = 161691926;
								continue;
							}
							return HFStzJyQGytgUBWpFJOoXXXwNYX[P_0].value;
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				return 0f;
			}

			public bool RindZdcFlQqOyjGHznZEajnJguuv(int P_0, bool P_1)
			{
				if (P_0 < 0 || P_0 >= HFStzJyQGytgUBWpFJOoXXXwNYX.Length)
				{
					return false;
				}
				return HFStzJyQGytgUBWpFJOoXXXwNYX[P_0].SBgnrGSWQJPmvUEiFCHjpHrwaRCi(P_1);
			}

			public void nympziBLtYDUiPlWNRoEGqbSPfa()
			{
				int num = 0;
				int num3 = default(int);
				while (true)
				{
					int num2 = -2104672225;
					while (true)
					{
						switch (num2 ^ -2104672230)
						{
						case 2:
							break;
						case 3:
							HFStzJyQGytgUBWpFJOoXXXwNYX[num3].nympziBLtYDUiPlWNRoEGqbSPfa();
							num3++;
							num2 = -2104672226;
							continue;
						case 0:
							USQZpFcFQqBJUckpyitMKctsvSza[num].nympziBLtYDUiPlWNRoEGqbSPfa();
							num++;
							num2 = -2104672229;
							continue;
						case 1:
							if (num >= USQZpFcFQqBJUckpyitMKctsvSza.Length)
							{
								num3 = 0;
								num2 = -2104672226;
								continue;
							}
							goto case 0;
						case 5:
							num2 = -2104672229;
							continue;
						default:
							if (num3 >= HFStzJyQGytgUBWpFJOoXXXwNYX.Length)
							{
								return;
							}
							goto case 3;
						}
						break;
					}
				}
			}
		}

		private class pDNTRRrQMfkHkehuwojeBWxwrDQ
		{
			private zxvELNFjcQtjwOgblGBPSavWWyfd[] USQZpFcFQqBJUckpyitMKctsvSza;

			public pDNTRRrQMfkHkehuwojeBWxwrDQ()
			{
				USQZpFcFQqBJUckpyitMKctsvSza = new zxvELNFjcQtjwOgblGBPSavWWyfd[7];
				for (int i = 0; i < USQZpFcFQqBJUckpyitMKctsvSza.Length; i++)
				{
					USQZpFcFQqBJUckpyitMKctsvSza[i] = new zxvELNFjcQtjwOgblGBPSavWWyfd();
				}
			}

			public void UZSQFwoMfSAzsmmSKmseCCiJWWD()
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= USQZpFcFQqBJUckpyitMKctsvSza.Length)
					{
						num2 = 986222175;
						num3 = num2;
					}
					else
					{
						num2 = 986222172;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x3AC88E5D)
						{
						case 3:
							num2 = 986222172;
							continue;
						default:
							return;
						case 1:
							USQZpFcFQqBJUckpyitMKctsvSza[num].value = Input.GetButton("MouseButton" + num);
							num++;
							num2 = 986222173;
							continue;
						case 0:
							break;
						case 2:
							return;
						}
						break;
					}
				}
			}

			public bool lvyTpewEByrJQaPpHiuasLSeNzw(int P_0)
			{
				if (P_0 < 0 || P_0 >= USQZpFcFQqBJUckpyitMKctsvSza.Length)
				{
					return false;
				}
				return USQZpFcFQqBJUckpyitMKctsvSza[P_0].value;
			}

			public bool kmPAfEKnCyTirEYSWkaOedaLedN(int P_0)
			{
				if (P_0 < 0 || P_0 >= USQZpFcFQqBJUckpyitMKctsvSza.Length)
				{
					return false;
				}
				return USQZpFcFQqBJUckpyitMKctsvSza[P_0].justPressed;
			}

			public bool OyXGTSwiLyydixsXoAkXTFGBrMP(int P_0)
			{
				if (P_0 >= 0)
				{
					while (true)
					{
						int num = -2099220280;
						while (true)
						{
							switch (num ^ -2099220279)
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
							if (P_0 >= USQZpFcFQqBJUckpyitMKctsvSza.Length)
							{
								num = -2099220279;
								continue;
							}
							return USQZpFcFQqBJUckpyitMKctsvSza[P_0].justReleased;
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				return false;
			}

			public void nympziBLtYDUiPlWNRoEGqbSPfa()
			{
				int num = 0;
				while (true)
				{
					int num2 = 1243492672;
					while (true)
					{
						switch (num2 ^ 0x4A1E3142)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							num2 = 1243492678;
							continue;
						case 4:
						{
							int num3;
							if (num >= USQZpFcFQqBJUckpyitMKctsvSza.Length)
							{
								num2 = 1243492673;
								num3 = num2;
							}
							else
							{
								num2 = 1243492675;
								num3 = num2;
							}
							continue;
						}
						case 1:
							USQZpFcFQqBJUckpyitMKctsvSza[num].nympziBLtYDUiPlWNRoEGqbSPfa();
							num++;
							num2 = 1243492678;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}
		}

		private class zxvELNFjcQtjwOgblGBPSavWWyfd
		{
			private bool FAoORBrTWqKCGNyMiKXRtudTOgk;

			private bool wDrfXkNCqrEtoEKmmPteHqVobDUa;

			public bool value
			{
				get
				{
					return FAoORBrTWqKCGNyMiKXRtudTOgk;
				}
				set
				{
					wDrfXkNCqrEtoEKmmPteHqVobDUa = FAoORBrTWqKCGNyMiKXRtudTOgk;
					FAoORBrTWqKCGNyMiKXRtudTOgk = value;
				}
			}

			public bool justPressed
			{
				get
				{
					if (FAoORBrTWqKCGNyMiKXRtudTOgk)
					{
						return !wDrfXkNCqrEtoEKmmPteHqVobDUa;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (wDrfXkNCqrEtoEKmmPteHqVobDUa)
					{
						return !FAoORBrTWqKCGNyMiKXRtudTOgk;
					}
					return false;
				}
			}

			public void BJTLXEjtRzwGSeFtYEySLofTbdi(bool P_0)
			{
				FAoORBrTWqKCGNyMiKXRtudTOgk = P_0;
				wDrfXkNCqrEtoEKmmPteHqVobDUa = P_0;
			}

			public void nympziBLtYDUiPlWNRoEGqbSPfa()
			{
				FAoORBrTWqKCGNyMiKXRtudTOgk = false;
				wDrfXkNCqrEtoEKmmPteHqVobDUa = false;
			}
		}

		private class APQoyRnNhpWivbwQeIQWXnrthAi
		{
			private int LToeCtAjsdqxWBbYcyjSvtNpEMFL;

			private float FAoORBrTWqKCGNyMiKXRtudTOgk;

			private float kJwZuGcuYoDCTcYoqtaRxiOatid;

			public float value
			{
				get
				{
					return FAoORBrTWqKCGNyMiKXRtudTOgk;
				}
				set
				{
					FAoORBrTWqKCGNyMiKXRtudTOgk = value;
				}
			}

			public APQoyRnNhpWivbwQeIQWXnrthAi(int axisIndex)
			{
				LToeCtAjsdqxWBbYcyjSvtNpEMFL = axisIndex;
			}

			public void BJTLXEjtRzwGSeFtYEySLofTbdi(float P_0)
			{
				kJwZuGcuYoDCTcYoqtaRxiOatid = P_0;
				FAoORBrTWqKCGNyMiKXRtudTOgk = P_0;
			}

			public bool SBgnrGSWQJPmvUEiFCHjpHrwaRCi(bool P_0)
			{
				float num = FAoORBrTWqKCGNyMiKXRtudTOgk - kJwZuGcuYoDCTcYoqtaRxiOatid;
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

			public void nympziBLtYDUiPlWNRoEGqbSPfa()
			{
				FAoORBrTWqKCGNyMiKXRtudTOgk = 0f;
				kJwZuGcuYoDCTcYoqtaRxiOatid = 0f;
			}
		}

		private aTpVWNATCUOoyGvlIYNKpDYRkDT[] AVRtfMRpOzQlHvmKXxpZoBGaQUn;

		private pDNTRRrQMfkHkehuwojeBWxwrDQ QuOyRGrgPJAIWhsKWmyPcWlaLYok;

		public cTYeMeZCBLDLfqbToBaskZPEXxDL()
		{
			AVRtfMRpOzQlHvmKXxpZoBGaQUn = new aTpVWNATCUOoyGvlIYNKpDYRkDT[11];
			for (int i = 0; i < AVRtfMRpOzQlHvmKXxpZoBGaQUn.Length; i++)
			{
				AVRtfMRpOzQlHvmKXxpZoBGaQUn[i] = new aTpVWNATCUOoyGvlIYNKpDYRkDT(i);
			}
			QuOyRGrgPJAIWhsKWmyPcWlaLYok = new pDNTRRrQMfkHkehuwojeBWxwrDQ();
		}

		public void BJTLXEjtRzwGSeFtYEySLofTbdi()
		{
			int num = 0;
			while (num < AVRtfMRpOzQlHvmKXxpZoBGaQUn.Length)
			{
				while (true)
				{
					AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].BJTLXEjtRzwGSeFtYEySLofTbdi();
					num++;
					int num2 = -590123574;
					while (true)
					{
						switch (num2 ^ -590123576)
						{
						case 0:
							num2 = -590123575;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
		}

		public void UZSQFwoMfSAzsmmSKmseCCiJWWD()
		{
			int num = 0;
			while (true)
			{
				int num2 = 1765873802;
				while (true)
				{
					switch (num2 ^ 0x69411888)
					{
					case 0:
						break;
					case 2:
						num2 = 1765873801;
						continue;
					case 3:
						AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].UZSQFwoMfSAzsmmSKmseCCiJWWD();
						num++;
						num2 = 1765873801;
						continue;
					default:
						if (num >= AVRtfMRpOzQlHvmKXxpZoBGaQUn.Length)
						{
							QuOyRGrgPJAIWhsKWmyPcWlaLYok.UZSQFwoMfSAzsmmSKmseCCiJWWD();
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public bool lZVzVMrCNmZctJzRzVMkbVkKdeP(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= AVRtfMRpOzQlHvmKXxpZoBGaQUn.Length)
			{
				return false;
			}
			return AVRtfMRpOzQlHvmKXxpZoBGaQUn[P_0].lvyTpewEByrJQaPpHiuasLSeNzw(P_1);
		}

		public bool KEKeyChVYbJkKjubvuWAAkuhHbFx(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= AVRtfMRpOzQlHvmKXxpZoBGaQUn.Length)
			{
				return false;
			}
			return AVRtfMRpOzQlHvmKXxpZoBGaQUn[P_0].kmPAfEKnCyTirEYSWkaOedaLedN(P_1);
		}

		public bool flOiAJiCbMazDfXIfehOLqTPenNC(int P_0, int P_1)
		{
			if (P_0 >= 0)
			{
				while (true)
				{
					int num = -1077332316;
					while (true)
					{
						switch (num ^ -1077332315)
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
						if (P_0 >= AVRtfMRpOzQlHvmKXxpZoBGaQUn.Length)
						{
							num = -1077332315;
							continue;
						}
						return AVRtfMRpOzQlHvmKXxpZoBGaQUn[P_0].OyXGTSwiLyydixsXoAkXTFGBrMP(P_1);
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return false;
		}

		public bool qsyAmKaLYrBwwwdDBRIIiufnMhy(int P_0, int P_1, bool P_2)
		{
			if (P_0 < 0 || P_0 >= AVRtfMRpOzQlHvmKXxpZoBGaQUn.Length)
			{
				return false;
			}
			return AVRtfMRpOzQlHvmKXxpZoBGaQUn[P_0].RindZdcFlQqOyjGHznZEajnJguuv(P_1, P_2);
		}

		public bool sNzKiAGzPLbtffOXohDGyNYNmcB(int P_0)
		{
			return QuOyRGrgPJAIWhsKWmyPcWlaLYok.lvyTpewEByrJQaPpHiuasLSeNzw(P_0);
		}

		public bool rdjrIQflDQKmKteizzCSGumELWm(int P_0)
		{
			return QuOyRGrgPJAIWhsKWmyPcWlaLYok.kmPAfEKnCyTirEYSWkaOedaLedN(P_0);
		}

		public bool uZmaJQwuBgMEuWcLwHQdpZfGKgB(int P_0)
		{
			return QuOyRGrgPJAIWhsKWmyPcWlaLYok.OyXGTSwiLyydixsXoAkXTFGBrMP(P_0);
		}

		public void nympziBLtYDUiPlWNRoEGqbSPfa()
		{
			int num = 0;
			while (num < AVRtfMRpOzQlHvmKXxpZoBGaQUn.Length)
			{
				while (true)
				{
					AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].nympziBLtYDUiPlWNRoEGqbSPfa();
					num++;
					int num2 = -334801444;
					while (true)
					{
						switch (num2 ^ -334801443)
						{
						case 0:
							num2 = -334801441;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
			QuOyRGrgPJAIWhsKWmyPcWlaLYok.nympziBLtYDUiPlWNRoEGqbSPfa();
		}
	}

	private UpdateLoopType xFKjhyBYBeaXHwQfmSuqSKfAFpj;

	private cTYeMeZCBLDLfqbToBaskZPEXxDL qefaHVIuCPEHtdJAcsRJjzuvfNYs;

	private IndexedDictionary<int, cTYeMeZCBLDLfqbToBaskZPEXxDL> eYGHEvjfglVQjGXNohHnkDIesNr;

	public nVoiynOsjugkJuOeheypUhVfWan(UpdateLoopSetting updateLoopSetting)
	{
		eYGHEvjfglVQjGXNohHnkDIesNr = new IndexedDictionary<int, cTYeMeZCBLDLfqbToBaskZPEXxDL>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				eYGHEvjfglVQjGXNohHnkDIesNr.Add((int)list[i], new cTYeMeZCBLDLfqbToBaskZPEXxDL());
			}
		}
		xFKjhyBYBeaXHwQfmSuqSKfAFpj = UpdateLoopType.Update;
		qefaHVIuCPEHtdJAcsRJjzuvfNYs = eYGHEvjfglVQjGXNohHnkDIesNr.GetValue(0);
	}

	public void BJTLXEjtRzwGSeFtYEySLofTbdi()
	{
		dxUcHJdheYlUgAMITmIaHroMdNXi(ReInput.currentUpdateLoop);
		qefaHVIuCPEHtdJAcsRJjzuvfNYs.BJTLXEjtRzwGSeFtYEySLofTbdi();
	}

	public void UZSQFwoMfSAzsmmSKmseCCiJWWD(UpdateLoopType P_0)
	{
		dxUcHJdheYlUgAMITmIaHroMdNXi(P_0);
		qefaHVIuCPEHtdJAcsRJjzuvfNYs.UZSQFwoMfSAzsmmSKmseCCiJWWD();
	}

	public bool lZVzVMrCNmZctJzRzVMkbVkKdeP(int P_0, int P_1)
	{
		return qefaHVIuCPEHtdJAcsRJjzuvfNYs.lZVzVMrCNmZctJzRzVMkbVkKdeP(P_0, P_1);
	}

	public bool KEKeyChVYbJkKjubvuWAAkuhHbFx(int P_0, int P_1)
	{
		return qefaHVIuCPEHtdJAcsRJjzuvfNYs.KEKeyChVYbJkKjubvuWAAkuhHbFx(P_0, P_1);
	}

	public bool flOiAJiCbMazDfXIfehOLqTPenNC(int P_0, int P_1)
	{
		return qefaHVIuCPEHtdJAcsRJjzuvfNYs.flOiAJiCbMazDfXIfehOLqTPenNC(P_0, P_1);
	}

	public bool qsyAmKaLYrBwwwdDBRIIiufnMhy(int P_0, int P_1, bool P_2)
	{
		return qefaHVIuCPEHtdJAcsRJjzuvfNYs.qsyAmKaLYrBwwwdDBRIIiufnMhy(P_0, P_1, P_2);
	}

	public bool sNzKiAGzPLbtffOXohDGyNYNmcB(int P_0)
	{
		return qefaHVIuCPEHtdJAcsRJjzuvfNYs.sNzKiAGzPLbtffOXohDGyNYNmcB(P_0);
	}

	public bool rdjrIQflDQKmKteizzCSGumELWm(int P_0)
	{
		return qefaHVIuCPEHtdJAcsRJjzuvfNYs.rdjrIQflDQKmKteizzCSGumELWm(P_0);
	}

	public bool uZmaJQwuBgMEuWcLwHQdpZfGKgB(int P_0)
	{
		return qefaHVIuCPEHtdJAcsRJjzuvfNYs.uZmaJQwuBgMEuWcLwHQdpZfGKgB(P_0);
	}

	public void nympziBLtYDUiPlWNRoEGqbSPfa()
	{
		int num = 0;
		while (num < eYGHEvjfglVQjGXNohHnkDIesNr.Count)
		{
			while (true)
			{
				eYGHEvjfglVQjGXNohHnkDIesNr[num].nympziBLtYDUiPlWNRoEGqbSPfa();
				num++;
				int num2 = 1470312556;
				while (true)
				{
					switch (num2 ^ 0x57A3306C)
					{
					case 2:
						num2 = 1470312557;
						continue;
					case 1:
						break;
					default:
						goto end_IL_0022;
					}
					break;
				}
				continue;
				end_IL_0022:
				break;
			}
		}
	}

	private void dxUcHJdheYlUgAMITmIaHroMdNXi(UpdateLoopType P_0)
	{
		if (xFKjhyBYBeaXHwQfmSuqSKfAFpj != P_0)
		{
			xFKjhyBYBeaXHwQfmSuqSKfAFpj = P_0;
			qefaHVIuCPEHtdJAcsRJjzuvfNYs = eYGHEvjfglVQjGXNohHnkDIesNr.GetValue((int)P_0);
		}
	}
}
