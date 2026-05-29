using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class YnisbciDvsRZeAbvRfcznxTbzne
{
	private class xkUACIFOeTBlmnYAEupfJHmWZkC
	{
		private class jRctSraocKxpELuxSkkhmsQDcFz
		{
			private int RDBCHpRATqkKDTZrBXQzswJqBKy;

			private hAaGvQipDKFkmDdAilyzrwiPGTtg[] xIIOtOIuEykpnAueUtuKVMbkTfu;

			private eCqYhmkAuLwdpPLjJmJEzBEIPgd[] suEsVcYOaqKlbfPKrZFuofLgCiX;

			public jRctSraocKxpELuxSkkhmsQDcFz(int index)
			{
				RDBCHpRATqkKDTZrBXQzswJqBKy = index;
				xIIOtOIuEykpnAueUtuKVMbkTfu = new hAaGvQipDKFkmDdAilyzrwiPGTtg[20];
				for (int i = 0; i < xIIOtOIuEykpnAueUtuKVMbkTfu.Length; i++)
				{
					xIIOtOIuEykpnAueUtuKVMbkTfu[i] = new hAaGvQipDKFkmDdAilyzrwiPGTtg();
				}
				suEsVcYOaqKlbfPKrZFuofLgCiX = new eCqYhmkAuLwdpPLjJmJEzBEIPgd[29];
				for (int j = 0; j < suEsVcYOaqKlbfPKrZFuofLgCiX.Length; j++)
				{
					suEsVcYOaqKlbfPKrZFuofLgCiX[j] = new eCqYhmkAuLwdpPLjJmJEzBEIPgd(j);
				}
			}

			public void iwZOgPPbdtgVnQcmicAIfcjFBilD()
			{
				int num = 0;
				bool joystickButtonValueByJoystickIndex = default(bool);
				int num3 = default(int);
				while (true)
				{
					int num2 = 421141193;
					while (true)
					{
						switch (num2 ^ 0x191A1ACC)
						{
						case 4:
							break;
						case 7:
							xIIOtOIuEykpnAueUtuKVMbkTfu[num].iwZOgPPbdtgVnQcmicAIfcjFBilD(joystickButtonValueByJoystickIndex);
							num++;
							num2 = 421141196;
							continue;
						case 0:
						{
							int num4;
							if (num >= xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
							{
								num2 = 421141197;
								num4 = num2;
							}
							else
							{
								num2 = 421141194;
								num4 = num2;
							}
							continue;
						}
						case 5:
							num2 = 421141196;
							continue;
						case 3:
						{
							float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(RDBCHpRATqkKDTZrBXQzswJqBKy, num3);
							suEsVcYOaqKlbfPKrZFuofLgCiX[num3].iwZOgPPbdtgVnQcmicAIfcjFBilD(joystickAxisRawValueByJoystickIndex);
							num3++;
							num2 = 421141198;
							continue;
						}
						case 6:
							joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(RDBCHpRATqkKDTZrBXQzswJqBKy, num);
							num2 = 421141195;
							continue;
						case 1:
							num3 = 0;
							num2 = 421141198;
							continue;
						default:
							if (num3 >= suEsVcYOaqKlbfPKrZFuofLgCiX.Length)
							{
								return;
							}
							goto case 3;
						}
						break;
					}
				}
			}

			public void rdEJYvExbWYUXSDuseVgzyXPBhA()
			{
				int num = 0;
				int num2 = default(int);
				while (true)
				{
					int num3;
					if (num >= xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
					{
						num2 = 0;
						num3 = -1081436982;
						goto IL_0009;
					}
					goto IL_0051;
					IL_0009:
					while (true)
					{
						switch (num3 ^ -1081436983)
						{
						case 6:
							num3 = -1081436984;
							continue;
						case 4:
							break;
						case 5:
							num++;
							num3 = -1081436979;
							continue;
						case 1:
							goto IL_0051;
						case 2:
							num2++;
							num3 = -1081436982;
							continue;
						case 0:
							suEsVcYOaqKlbfPKrZFuofLgCiX[num2].value = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(RDBCHpRATqkKDTZrBXQzswJqBKy, num2);
							num3 = -1081436981;
							continue;
						default:
							if (num2 >= suEsVcYOaqKlbfPKrZFuofLgCiX.Length)
							{
								return;
							}
							goto case 0;
						}
						break;
					}
					continue;
					IL_0051:
					xIIOtOIuEykpnAueUtuKVMbkTfu[num].value = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(RDBCHpRATqkKDTZrBXQzswJqBKy, num);
					num3 = -1081436980;
					goto IL_0009;
				}
			}

			public bool OMsDoddGLoMsnAOixNusrDCoKsdq(int P_0)
			{
				if (P_0 < 0 || P_0 >= xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
				{
					return false;
				}
				return xIIOtOIuEykpnAueUtuKVMbkTfu[P_0].value;
			}

			public bool VoFALJiXKwwyQgLPqqsGLZcLBoM(int P_0)
			{
				if (P_0 < 0 || P_0 >= xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
				{
					return false;
				}
				return xIIOtOIuEykpnAueUtuKVMbkTfu[P_0].justPressed;
			}

			public bool zZfNFOMmkwRPDTjWQEBszXZnyS(int P_0)
			{
				if (P_0 >= 0)
				{
					while (true)
					{
						int num = 863975463;
						while (true)
						{
							switch (num ^ 0x337F3826)
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
							if (P_0 >= xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
							{
								num = 863975462;
								continue;
							}
							return xIIOtOIuEykpnAueUtuKVMbkTfu[P_0].justReleased;
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				return false;
			}

			public float BscAVytxcCBkilFutmFsULYtqRF(int P_0)
			{
				if (P_0 >= 0)
				{
					while (true)
					{
						int num = 55490298;
						while (true)
						{
							switch (num ^ 0x34EB6FB)
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
							if (P_0 >= suEsVcYOaqKlbfPKrZFuofLgCiX.Length)
							{
								num = 55490297;
								continue;
							}
							return suEsVcYOaqKlbfPKrZFuofLgCiX[P_0].value;
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				return 0f;
			}

			public bool uGttUydvlCGxFaUSVSJWOPhwTnh(int P_0, bool P_1)
			{
				if (P_0 < 0 || P_0 >= suEsVcYOaqKlbfPKrZFuofLgCiX.Length)
				{
					return false;
				}
				return suEsVcYOaqKlbfPKrZFuofLgCiX[P_0].pgmyPRqdCXjaMsQjtTSnCInoBYH(P_1);
			}

			public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
			{
				int num = 0;
				int num3 = default(int);
				while (true)
				{
					int num2 = 2045376380;
					while (true)
					{
						switch (num2 ^ 0x79E9F778)
						{
						case 7:
							break;
						case 4:
							num2 = 2045376379;
							continue;
						case 5:
							num++;
							num2 = 2045376379;
							continue;
						case 0:
							xIIOtOIuEykpnAueUtuKVMbkTfu[num].QYwkAfdRMMgAPnyPzHFUdcsKUPp();
							num2 = 2045376381;
							continue;
						case 2:
							suEsVcYOaqKlbfPKrZFuofLgCiX[num3].QYwkAfdRMMgAPnyPzHFUdcsKUPp();
							num3++;
							num2 = 2045376382;
							continue;
						case 1:
							num2 = 2045376382;
							continue;
						case 3:
							if (num >= xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
							{
								num3 = 0;
								num2 = 2045376377;
								continue;
							}
							goto case 0;
						default:
							if (num3 >= suEsVcYOaqKlbfPKrZFuofLgCiX.Length)
							{
								return;
							}
							goto case 2;
						}
						break;
					}
				}
			}
		}

		private class KaFHsJFLpEEfIQIjajOJAIsVYcad
		{
			private hAaGvQipDKFkmDdAilyzrwiPGTtg[] xIIOtOIuEykpnAueUtuKVMbkTfu;

			public KaFHsJFLpEEfIQIjajOJAIsVYcad()
			{
				int num2 = default(int);
				while (true)
				{
					int num = -408543954;
					while (true)
					{
						switch (num ^ -408543956)
						{
						case 3:
							break;
						case 0:
							xIIOtOIuEykpnAueUtuKVMbkTfu[num2] = new hAaGvQipDKFkmDdAilyzrwiPGTtg();
							num2++;
							num = -408543955;
							continue;
						case 4:
							num = -408543955;
							continue;
						case 2:
							xIIOtOIuEykpnAueUtuKVMbkTfu = new hAaGvQipDKFkmDdAilyzrwiPGTtg[7];
							num2 = 0;
							num = -408543960;
							continue;
						default:
							if (num2 >= xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
							{
								return;
							}
							goto case 0;
						}
						break;
					}
				}
			}

			public void rdEJYvExbWYUXSDuseVgzyXPBhA()
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
					{
						num2 = 2135700289;
						num3 = num2;
					}
					else
					{
						num2 = 2135700291;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x7F4C3340)
						{
						case 4:
							num2 = 2135700289;
							continue;
						default:
							return;
						case 0:
							break;
						case 2:
							num++;
							num2 = 2135700288;
							continue;
						case 1:
							xIIOtOIuEykpnAueUtuKVMbkTfu[num].value = Input.GetButton("MouseButton" + num);
							num2 = 2135700290;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}

			public bool OMsDoddGLoMsnAOixNusrDCoKsdq(int P_0)
			{
				if (P_0 < 0 || P_0 >= xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
				{
					return false;
				}
				return xIIOtOIuEykpnAueUtuKVMbkTfu[P_0].value;
			}

			public bool VoFALJiXKwwyQgLPqqsGLZcLBoM(int P_0)
			{
				if (P_0 < 0 || P_0 >= xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
				{
					return false;
				}
				return xIIOtOIuEykpnAueUtuKVMbkTfu[P_0].justPressed;
			}

			public bool zZfNFOMmkwRPDTjWQEBszXZnyS(int P_0)
			{
				if (P_0 < 0 || P_0 >= xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
				{
					return false;
				}
				return xIIOtOIuEykpnAueUtuKVMbkTfu[P_0].justReleased;
			}

			public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
			{
				int num = 0;
				while (num < xIIOtOIuEykpnAueUtuKVMbkTfu.Length)
				{
					while (true)
					{
						xIIOtOIuEykpnAueUtuKVMbkTfu[num].QYwkAfdRMMgAPnyPzHFUdcsKUPp();
						num++;
						int num2 = -1145803028;
						while (true)
						{
							switch (num2 ^ -1145803026)
							{
							case 0:
								num2 = -1145803025;
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
		}

		private class hAaGvQipDKFkmDdAilyzrwiPGTtg
		{
			private bool oEeTqWLfGqIvjjZLGKQRMTdJbXv;

			private bool NBluarpwmvCYDeqfUroymJHuEEJ;

			public bool value
			{
				get
				{
					return oEeTqWLfGqIvjjZLGKQRMTdJbXv;
				}
				set
				{
					NBluarpwmvCYDeqfUroymJHuEEJ = oEeTqWLfGqIvjjZLGKQRMTdJbXv;
					oEeTqWLfGqIvjjZLGKQRMTdJbXv = value;
				}
			}

			public bool justPressed
			{
				get
				{
					if (oEeTqWLfGqIvjjZLGKQRMTdJbXv)
					{
						return !NBluarpwmvCYDeqfUroymJHuEEJ;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (NBluarpwmvCYDeqfUroymJHuEEJ)
					{
						return !oEeTqWLfGqIvjjZLGKQRMTdJbXv;
					}
					return false;
				}
			}

			public void iwZOgPPbdtgVnQcmicAIfcjFBilD(bool P_0)
			{
				oEeTqWLfGqIvjjZLGKQRMTdJbXv = P_0;
				while (true)
				{
					int num = -1469231660;
					while (true)
					{
						switch (num ^ -1469231659)
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
						NBluarpwmvCYDeqfUroymJHuEEJ = P_0;
						num = -1469231657;
					}
				}
			}

			public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
			{
				oEeTqWLfGqIvjjZLGKQRMTdJbXv = false;
				NBluarpwmvCYDeqfUroymJHuEEJ = false;
			}
		}

		private class eCqYhmkAuLwdpPLjJmJEzBEIPgd
		{
			private int qTezZqRCufGIvTCPGtbIKcLSUFY;

			private float oEeTqWLfGqIvjjZLGKQRMTdJbXv;

			private float DqbGFHMiIamuaQBAErHBCuVgeJs;

			public float value
			{
				get
				{
					return oEeTqWLfGqIvjjZLGKQRMTdJbXv;
				}
				set
				{
					oEeTqWLfGqIvjjZLGKQRMTdJbXv = value;
				}
			}

			public eCqYhmkAuLwdpPLjJmJEzBEIPgd(int axisIndex)
			{
				qTezZqRCufGIvTCPGtbIKcLSUFY = axisIndex;
			}

			public void iwZOgPPbdtgVnQcmicAIfcjFBilD(float P_0)
			{
				DqbGFHMiIamuaQBAErHBCuVgeJs = P_0;
				oEeTqWLfGqIvjjZLGKQRMTdJbXv = P_0;
			}

			public bool pgmyPRqdCXjaMsQjtTSnCInoBYH(bool P_0)
			{
				float num = oEeTqWLfGqIvjjZLGKQRMTdJbXv - DqbGFHMiIamuaQBAErHBCuVgeJs;
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

			public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
			{
				oEeTqWLfGqIvjjZLGKQRMTdJbXv = 0f;
				DqbGFHMiIamuaQBAErHBCuVgeJs = 0f;
			}
		}

		private jRctSraocKxpELuxSkkhmsQDcFz[] jkFiqNnyAtbymFOLlvWZRfYeLku;

		private KaFHsJFLpEEfIQIjajOJAIsVYcad xuMdUThDXJJnvRMJqvyVfthJBBhD;

		public xkUACIFOeTBlmnYAEupfJHmWZkC()
		{
			jkFiqNnyAtbymFOLlvWZRfYeLku = new jRctSraocKxpELuxSkkhmsQDcFz[16];
			for (int i = 0; i < jkFiqNnyAtbymFOLlvWZRfYeLku.Length; i++)
			{
				jkFiqNnyAtbymFOLlvWZRfYeLku[i] = new jRctSraocKxpELuxSkkhmsQDcFz(i);
			}
			xuMdUThDXJJnvRMJqvyVfthJBBhD = new KaFHsJFLpEEfIQIjajOJAIsVYcad();
		}

		public void iwZOgPPbdtgVnQcmicAIfcjFBilD()
		{
			int num = 0;
			while (true)
			{
				int num2 = 1458223006;
				while (true)
				{
					switch (num2 ^ 0x56EAB79F)
					{
					case 3:
						break;
					case 1:
						num2 = 1458223007;
						continue;
					case 2:
						jkFiqNnyAtbymFOLlvWZRfYeLku[num].iwZOgPPbdtgVnQcmicAIfcjFBilD();
						num++;
						num2 = 1458223007;
						continue;
					default:
						if (num >= jkFiqNnyAtbymFOLlvWZRfYeLku.Length)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public void rdEJYvExbWYUXSDuseVgzyXPBhA()
		{
			int num = 0;
			while (num < jkFiqNnyAtbymFOLlvWZRfYeLku.Length)
			{
				while (true)
				{
					jkFiqNnyAtbymFOLlvWZRfYeLku[num].rdEJYvExbWYUXSDuseVgzyXPBhA();
					num++;
					int num2 = -768509042;
					while (true)
					{
						switch (num2 ^ -768509042)
						{
						case 2:
							num2 = -768509041;
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
			xuMdUThDXJJnvRMJqvyVfthJBBhD.rdEJYvExbWYUXSDuseVgzyXPBhA();
		}

		public bool CjDhQFHTRszVUqfWTQGgAToOBpAD(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= jkFiqNnyAtbymFOLlvWZRfYeLku.Length)
			{
				return false;
			}
			return jkFiqNnyAtbymFOLlvWZRfYeLku[P_0].OMsDoddGLoMsnAOixNusrDCoKsdq(P_1);
		}

		public bool diMudXjFUpxBpMgcVGAIbDchkqYK(int P_0, int P_1)
		{
			if (P_0 >= 0)
			{
				while (true)
				{
					int num = -52064002;
					while (true)
					{
						switch (num ^ -52064001)
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
						if (P_0 >= jkFiqNnyAtbymFOLlvWZRfYeLku.Length)
						{
							num = -52064001;
							continue;
						}
						return jkFiqNnyAtbymFOLlvWZRfYeLku[P_0].VoFALJiXKwwyQgLPqqsGLZcLBoM(P_1);
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return false;
		}

		public bool CvMnHAKevCBUiFlHLpdSmXRRtsAd(int P_0, int P_1)
		{
			if (P_0 >= 0)
			{
				while (true)
				{
					int num = -1209747094;
					while (true)
					{
						switch (num ^ -1209747093)
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
						if (P_0 >= jkFiqNnyAtbymFOLlvWZRfYeLku.Length)
						{
							num = -1209747095;
							continue;
						}
						return jkFiqNnyAtbymFOLlvWZRfYeLku[P_0].zZfNFOMmkwRPDTjWQEBszXZnyS(P_1);
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return false;
		}

		public bool LhcTklIkJnkZFArodDzATauhLFp(int P_0, int P_1, bool P_2)
		{
			if (P_0 >= 0)
			{
				while (true)
				{
					int num = 971939559;
					while (true)
					{
						switch (num ^ 0x39EE9EE5)
						{
						case 0:
							break;
						case 2:
							goto IL_0022;
						default:
							goto end_IL_0004;
						}
						break;
						IL_0022:
						if (P_0 >= jkFiqNnyAtbymFOLlvWZRfYeLku.Length)
						{
							num = 971939556;
							continue;
						}
						return jkFiqNnyAtbymFOLlvWZRfYeLku[P_0].uGttUydvlCGxFaUSVSJWOPhwTnh(P_1, P_2);
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return false;
		}

		public bool VSpTGLefVBOAWDJPWpUOFTnJlOO(int P_0)
		{
			return xuMdUThDXJJnvRMJqvyVfthJBBhD.OMsDoddGLoMsnAOixNusrDCoKsdq(P_0);
		}

		public bool ICzsJVRfqAxUDLlxNpbQvoPWUfL(int P_0)
		{
			return xuMdUThDXJJnvRMJqvyVfthJBBhD.VoFALJiXKwwyQgLPqqsGLZcLBoM(P_0);
		}

		public bool ZbwDlBMQLuPjZqtKKjMpOBvAUhY(int P_0)
		{
			return xuMdUThDXJJnvRMJqvyVfthJBBhD.zZfNFOMmkwRPDTjWQEBszXZnyS(P_0);
		}

		public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
		{
			int num = 0;
			while (true)
			{
				IL_003e:
				int num2;
				if (num >= jkFiqNnyAtbymFOLlvWZRfYeLku.Length)
				{
					xuMdUThDXJJnvRMJqvyVfthJBBhD.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
					num2 = -741624620;
					goto IL_0009;
				}
				goto IL_0026;
				IL_0009:
				while (true)
				{
					switch (num2 ^ -741624620)
					{
					case 3:
						num2 = -741624618;
						continue;
					default:
						return;
					case 2:
						break;
					case 1:
						goto IL_003e;
					case 0:
						return;
					}
					break;
				}
				goto IL_0026;
				IL_0026:
				jkFiqNnyAtbymFOLlvWZRfYeLku[num].QYwkAfdRMMgAPnyPzHFUdcsKUPp();
				num++;
				num2 = -741624619;
				goto IL_0009;
			}
		}
	}

	private UpdateLoopType KyGQivhvNcexgOdgEkqkdUhAdys;

	private xkUACIFOeTBlmnYAEupfJHmWZkC XehfISjYUJfkUSfLIVHVNUmvKKZI;

	private IndexedDictionary<int, xkUACIFOeTBlmnYAEupfJHmWZkC> TLERLwPBmpTvOkzIYiLpNvIoiAa;

	public YnisbciDvsRZeAbvRfcznxTbzne(UpdateLoopSetting updateLoopSetting)
	{
		TLERLwPBmpTvOkzIYiLpNvIoiAa = new IndexedDictionary<int, xkUACIFOeTBlmnYAEupfJHmWZkC>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				TLERLwPBmpTvOkzIYiLpNvIoiAa.Add((int)list[i], new xkUACIFOeTBlmnYAEupfJHmWZkC());
			}
		}
		KyGQivhvNcexgOdgEkqkdUhAdys = UpdateLoopType.Update;
		XehfISjYUJfkUSfLIVHVNUmvKKZI = TLERLwPBmpTvOkzIYiLpNvIoiAa.GetValue(0);
	}

	public void iwZOgPPbdtgVnQcmicAIfcjFBilD()
	{
		AsOxGUZcuUldLsQDjaOyWUgKwCY(ReInput.currentUpdateLoop);
		XehfISjYUJfkUSfLIVHVNUmvKKZI.iwZOgPPbdtgVnQcmicAIfcjFBilD();
	}

	public void rdEJYvExbWYUXSDuseVgzyXPBhA(UpdateLoopType P_0)
	{
		AsOxGUZcuUldLsQDjaOyWUgKwCY(P_0);
		XehfISjYUJfkUSfLIVHVNUmvKKZI.rdEJYvExbWYUXSDuseVgzyXPBhA();
	}

	public bool CjDhQFHTRszVUqfWTQGgAToOBpAD(int P_0, int P_1)
	{
		return XehfISjYUJfkUSfLIVHVNUmvKKZI.CjDhQFHTRszVUqfWTQGgAToOBpAD(P_0, P_1);
	}

	public bool diMudXjFUpxBpMgcVGAIbDchkqYK(int P_0, int P_1)
	{
		return XehfISjYUJfkUSfLIVHVNUmvKKZI.diMudXjFUpxBpMgcVGAIbDchkqYK(P_0, P_1);
	}

	public bool CvMnHAKevCBUiFlHLpdSmXRRtsAd(int P_0, int P_1)
	{
		return XehfISjYUJfkUSfLIVHVNUmvKKZI.CvMnHAKevCBUiFlHLpdSmXRRtsAd(P_0, P_1);
	}

	public bool LhcTklIkJnkZFArodDzATauhLFp(int P_0, int P_1, bool P_2)
	{
		return XehfISjYUJfkUSfLIVHVNUmvKKZI.LhcTklIkJnkZFArodDzATauhLFp(P_0, P_1, P_2);
	}

	public bool VSpTGLefVBOAWDJPWpUOFTnJlOO(int P_0)
	{
		return XehfISjYUJfkUSfLIVHVNUmvKKZI.VSpTGLefVBOAWDJPWpUOFTnJlOO(P_0);
	}

	public bool ICzsJVRfqAxUDLlxNpbQvoPWUfL(int P_0)
	{
		return XehfISjYUJfkUSfLIVHVNUmvKKZI.ICzsJVRfqAxUDLlxNpbQvoPWUfL(P_0);
	}

	public bool ZbwDlBMQLuPjZqtKKjMpOBvAUhY(int P_0)
	{
		return XehfISjYUJfkUSfLIVHVNUmvKKZI.ZbwDlBMQLuPjZqtKKjMpOBvAUhY(P_0);
	}

	public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
	{
		int num = 0;
		while (true)
		{
			int num2 = -1202080641;
			while (true)
			{
				switch (num2 ^ -1202080642)
				{
				case 3:
					break;
				case 1:
					num2 = -1202080642;
					continue;
				case 2:
					TLERLwPBmpTvOkzIYiLpNvIoiAa[num].QYwkAfdRMMgAPnyPzHFUdcsKUPp();
					num++;
					num2 = -1202080642;
					continue;
				default:
					if (num >= TLERLwPBmpTvOkzIYiLpNvIoiAa.Count)
					{
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	private void AsOxGUZcuUldLsQDjaOyWUgKwCY(UpdateLoopType P_0)
	{
		if (KyGQivhvNcexgOdgEkqkdUhAdys == P_0)
		{
			return;
		}
		KyGQivhvNcexgOdgEkqkdUhAdys = P_0;
		while (true)
		{
			int num = -708452836;
			while (true)
			{
				switch (num ^ -708452834)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_002e;
				case 1:
					return;
				}
				break;
				IL_002e:
				XehfISjYUJfkUSfLIVHVNUmvKKZI = TLERLwPBmpTvOkzIYiLpNvIoiAa.GetValue((int)P_0);
				num = -708452833;
			}
		}
	}
}
