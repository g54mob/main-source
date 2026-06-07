using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class nWJFPaVEAnZVBaejiLScyIzPghU : PlatformInputManager, INativePlatformHelper
{
	private class ARRucpJRKUKoSdGATgCNJjOfktn
	{
		private class OfWFqNGnpgKllEUZyCakcMZEYDQB
		{
			public int KbfeRbzvruWiJePSeNvnucdAIpaa;

			public int uDkwQcXcrzYWBtuasJBXMAbjLxg;

			public int bhcorCpMDigwrANbPyxcozuALLI;

			public InputSource GopNkYanAGUkOmQwUJuTJxkowKA;

			public OfWFqNGnpgKllEUZyCakcMZEYDQB(int mapperId, int managerId, int id, InputSource source)
			{
				KbfeRbzvruWiJePSeNvnucdAIpaa = mapperId;
				uDkwQcXcrzYWBtuasJBXMAbjLxg = managerId;
				bhcorCpMDigwrANbPyxcozuALLI = id;
				GopNkYanAGUkOmQwUJuTJxkowKA = source;
			}

			public void OKHZGFMfxtklwLbZuCziRQFTDNac(int P_0)
			{
				uDkwQcXcrzYWBtuasJBXMAbjLxg = P_0;
			}

			public hugBQjWsvPGLoXyvlxWTxnhoGCB SaKAccbdUMjLTbVoIiHDJZFPDTI()
			{
				return new hugBQjWsvPGLoXyvlxWTxnhoGCB(KbfeRbzvruWiJePSeNvnucdAIpaa, uDkwQcXcrzYWBtuasJBXMAbjLxg, GopNkYanAGUkOmQwUJuTJxkowKA);
			}

			public static int mHvWMBkaDocYeuAguvlFsMCvjCf(OfWFqNGnpgKllEUZyCakcMZEYDQB P_0, OfWFqNGnpgKllEUZyCakcMZEYDQB P_1)
			{
				if (P_0.KbfeRbzvruWiJePSeNvnucdAIpaa < P_1.KbfeRbzvruWiJePSeNvnucdAIpaa)
				{
					return -1;
				}
				if (P_0.KbfeRbzvruWiJePSeNvnucdAIpaa > P_1.KbfeRbzvruWiJePSeNvnucdAIpaa)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct hugBQjWsvPGLoXyvlxWTxnhoGCB
		{
			public int KbfeRbzvruWiJePSeNvnucdAIpaa;

			public int uDkwQcXcrzYWBtuasJBXMAbjLxg;

			public InputSource GopNkYanAGUkOmQwUJuTJxkowKA;

			public hugBQjWsvPGLoXyvlxWTxnhoGCB(int mapperId, int managerId, InputSource source)
			{
				KbfeRbzvruWiJePSeNvnucdAIpaa = mapperId;
				uDkwQcXcrzYWBtuasJBXMAbjLxg = managerId;
				GopNkYanAGUkOmQwUJuTJxkowKA = source;
			}
		}

		public enum RNjCJjtqhaADDEkPlZxyCjIZPqW
		{
			OPrDnVhLcontoTptCznHaDrwNsAh = 0,
			xqyuuQSofyjoJulEXgAcFSYaDtu = 1
		}

		private List<OfWFqNGnpgKllEUZyCakcMZEYDQB> ETKdVHGzAHrBEHOveosWyulSJCY;

		private List<OfWFqNGnpgKllEUZyCakcMZEYDQB> ekywolUbzMUKlzPKgGxbGKKvGVjB;

		public int deviceCount
		{
			get
			{
				return ekywolUbzMUKlzPKgGxbGKKvGVjB.Count;
			}
		}

		public ARRucpJRKUKoSdGATgCNJjOfktn()
		{
			ekywolUbzMUKlzPKgGxbGKKvGVjB = new List<OfWFqNGnpgKllEUZyCakcMZEYDQB>();
			ETKdVHGzAHrBEHOveosWyulSJCY = new List<OfWFqNGnpgKllEUZyCakcMZEYDQB>();
		}

		public void THjMgpRqkzsiJWNJfkDjpONSJZu(BridgedController P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = default(IInputManagerJoystickPublic);
			OfWFqNGnpgKllEUZyCakcMZEYDQB ofWFqNGnpgKllEUZyCakcMZEYDQB = default(OfWFqNGnpgKllEUZyCakcMZEYDQB);
			int num2 = default(int);
			while (true)
			{
				int num = -1025565448;
				while (true)
				{
					switch (num ^ -1025565444)
					{
					case 11:
						break;
					case 9:
						sourceJoystick = P_0.sourceJoystick;
						num = -1025565441;
						continue;
					case 5:
						P_0.sourceJoystick = new MVRGhtGnRlGvAeigHxrfgjCVzMAh(sourceJoystick, ofWFqNGnpgKllEUZyCakcMZEYDQB.KbfeRbzvruWiJePSeNvnucdAIpaa);
						num = -1025565456;
						continue;
					case 3:
						num2 = QfvcPTCkQKNaHrLDCOXTjZcrUbW(sourceJoystick.rewiredId, RNjCJjtqhaADDEkPlZxyCjIZPqW.OPrDnVhLcontoTptCznHaDrwNsAh);
						num = -1025565442;
						continue;
					case 4:
					{
						int num3;
						if (P_0.sourceJoystick == null)
						{
							num = -1025565452;
							num3 = num;
						}
						else
						{
							num = -1025565451;
							num3 = num;
						}
						continue;
					}
					case 6:
						num2 = QfvcPTCkQKNaHrLDCOXTjZcrUbW(sourceJoystick.rewiredId, RNjCJjtqhaADDEkPlZxyCjIZPqW.xqyuuQSofyjoJulEXgAcFSYaDtu);
						num = -1025565443;
						continue;
					case 7:
						ofWFqNGnpgKllEUZyCakcMZEYDQB = new OfWFqNGnpgKllEUZyCakcMZEYDQB(TbmwCthcnUohisaEvRQrIaIfyqz(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
						num = -1025565447;
						continue;
					case 2:
						if (num2 >= 0)
						{
							ofWFqNGnpgKllEUZyCakcMZEYDQB = ekywolUbzMUKlzPKgGxbGKKvGVjB[num2];
							num = -1025565450;
							continue;
						}
						goto case 6;
					case 1:
						if (num2 >= 0)
						{
							ofWFqNGnpgKllEUZyCakcMZEYDQB = ETKdVHGzAHrBEHOveosWyulSJCY[num2];
							ETKdVHGzAHrBEHOveosWyulSJCY.RemoveAt(num2);
							int kbfeRbzvruWiJePSeNvnucdAIpaa = TbmwCthcnUohisaEvRQrIaIfyqz(ofWFqNGnpgKllEUZyCakcMZEYDQB.KbfeRbzvruWiJePSeNvnucdAIpaa);
							ofWFqNGnpgKllEUZyCakcMZEYDQB.KbfeRbzvruWiJePSeNvnucdAIpaa = kbfeRbzvruWiJePSeNvnucdAIpaa;
							num = -1025565447;
							continue;
						}
						goto case 7;
					case 10:
						ofWFqNGnpgKllEUZyCakcMZEYDQB.OKHZGFMfxtklwLbZuCziRQFTDNac(sourceJoystick.inputManagerId);
						P_0.sourceJoystick = new MVRGhtGnRlGvAeigHxrfgjCVzMAh(sourceJoystick, ofWFqNGnpgKllEUZyCakcMZEYDQB.KbfeRbzvruWiJePSeNvnucdAIpaa);
						return;
					case 12:
						ekywolUbzMUKlzPKgGxbGKKvGVjB.Add(ofWFqNGnpgKllEUZyCakcMZEYDQB);
						num = -1025565444;
						continue;
					case 8:
						return;
					default:
						ekywolUbzMUKlzPKgGxbGKKvGVjB.Sort(OfWFqNGnpgKllEUZyCakcMZEYDQB.mHvWMBkaDocYeuAguvlFsMCvjCf);
						return;
					}
					break;
				}
			}
		}

		public void wZoRTCniYGUlYCHRtxHNmxSLryr(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num;
			while (true)
			{
				num = QfvcPTCkQKNaHrLDCOXTjZcrUbW(P_0.rewiredId, RNjCJjtqhaADDEkPlZxyCjIZPqW.OPrDnVhLcontoTptCznHaDrwNsAh);
				if (num >= 0)
				{
					break;
				}
				Logger.LogError("Device was not in connected list! Cannot remove!");
				int num2 = -73318465;
				while (true)
				{
					switch (num2 ^ -73318467)
					{
					case 0:
						num2 = -73318468;
						continue;
					case 1:
						break;
					case 2:
						return;
					default:
						goto end_IL_0026;
					}
					break;
				}
				continue;
				end_IL_0026:
				break;
			}
			OfWFqNGnpgKllEUZyCakcMZEYDQB item = ekywolUbzMUKlzPKgGxbGKKvGVjB[num];
			ekywolUbzMUKlzPKgGxbGKKvGVjB.RemoveAt(num);
			ETKdVHGzAHrBEHOveosWyulSJCY.Add(item);
		}

		public void YFDRilQqmwEqtrRKfdFRFiCygbmW(int P_0, int P_1)
		{
			int num = QfvcPTCkQKNaHrLDCOXTjZcrUbW(P_0, RNjCJjtqhaADDEkPlZxyCjIZPqW.OPrDnVhLcontoTptCznHaDrwNsAh);
			if (num >= 0)
			{
				goto IL_000d;
			}
			goto IL_0041;
			IL_000d:
			int num2 = 1624558908;
			goto IL_0012;
			IL_0012:
			OfWFqNGnpgKllEUZyCakcMZEYDQB ofWFqNGnpgKllEUZyCakcMZEYDQB = default(OfWFqNGnpgKllEUZyCakcMZEYDQB);
			while (true)
			{
				switch (num2 ^ 0x60D4CD3D)
				{
				case 2:
					break;
				default:
					return;
				case 4:
					ofWFqNGnpgKllEUZyCakcMZEYDQB.OKHZGFMfxtklwLbZuCziRQFTDNac(P_1);
					num2 = 1624558910;
					continue;
				case 0:
					goto IL_0041;
				case 1:
					ofWFqNGnpgKllEUZyCakcMZEYDQB = ekywolUbzMUKlzPKgGxbGKKvGVjB[num];
					ofWFqNGnpgKllEUZyCakcMZEYDQB.OKHZGFMfxtklwLbZuCziRQFTDNac(P_1);
					return;
				case 3:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_0041:
			num = QfvcPTCkQKNaHrLDCOXTjZcrUbW(P_0, RNjCJjtqhaADDEkPlZxyCjIZPqW.xqyuuQSofyjoJulEXgAcFSYaDtu);
			if (num >= 0)
			{
				ofWFqNGnpgKllEUZyCakcMZEYDQB = ETKdVHGzAHrBEHOveosWyulSJCY[num];
				num2 = 1624558905;
				goto IL_0012;
			}
		}

		public bool QacznVUaOaCwCvKomxmAnPOqZdr(int P_0, RNjCJjtqhaADDEkPlZxyCjIZPqW P_1)
		{
			if (QfvcPTCkQKNaHrLDCOXTjZcrUbW(P_0, P_1) < 0)
			{
				return false;
			}
			return true;
		}

		public int QfvcPTCkQKNaHrLDCOXTjZcrUbW(int P_0, RNjCJjtqhaADDEkPlZxyCjIZPqW P_1)
		{
			if (P_1 == RNjCJjtqhaADDEkPlZxyCjIZPqW.OPrDnVhLcontoTptCznHaDrwNsAh)
			{
				goto IL_0003;
			}
			goto IL_005f;
			IL_0003:
			int num = 1859587848;
			goto IL_0008;
			IL_0008:
			int num3 = default(int);
			int count = default(int);
			int num2 = default(int);
			int count2 = default(int);
			while (true)
			{
				switch (num ^ 0x6ED70F0B)
				{
				case 4:
					break;
				case 1:
					goto IL_0044;
				case 10:
					goto IL_005f;
				case 5:
					return num3;
				case 2:
					goto IL_0088;
				case 7:
					num3 = 0;
					num = 1859587853;
					continue;
				case 6:
					if (num3 >= count)
					{
						num = 1859587843;
						continue;
					}
					goto IL_0044;
				case 3:
					count = ekywolUbzMUKlzPKgGxbGKKvGVjB.Count;
					num = 1859587852;
					continue;
				case 0:
					return num2;
				case 9:
					goto IL_00e6;
				default:
					goto IL_00fe;
				}
				break;
				IL_00e6:
				int num4;
				if (num2 >= count2)
				{
					num = 1859587843;
					num4 = num;
				}
				else
				{
					num = 1859587849;
					num4 = num;
				}
				continue;
				IL_0088:
				if (ETKdVHGzAHrBEHOveosWyulSJCY[num2].bhcorCpMDigwrANbPyxcozuALLI == P_0)
				{
					num = 1859587851;
					continue;
				}
				num2++;
				num = 1859587842;
				continue;
				IL_0044:
				if (ekywolUbzMUKlzPKgGxbGKKvGVjB[num3].bhcorCpMDigwrANbPyxcozuALLI == P_0)
				{
					num = 1859587854;
					continue;
				}
				num3++;
				num = 1859587853;
			}
			goto IL_0003;
			IL_00fe:
			return -1;
			IL_005f:
			if (P_1 == RNjCJjtqhaADDEkPlZxyCjIZPqW.xqyuuQSofyjoJulEXgAcFSYaDtu)
			{
				count2 = ETKdVHGzAHrBEHOveosWyulSJCY.Count;
				num2 = 0;
				num = 1859587842;
				goto IL_0008;
			}
			goto IL_00fe;
		}

		public int QfvcPTCkQKNaHrLDCOXTjZcrUbW(int P_0, InputSource P_1, RNjCJjtqhaADDEkPlZxyCjIZPqW P_2)
		{
			if (P_2 != RNjCJjtqhaADDEkPlZxyCjIZPqW.OPrDnVhLcontoTptCznHaDrwNsAh)
			{
				goto IL_00a4;
			}
			int count = ekywolUbzMUKlzPKgGxbGKKvGVjB.Count;
			int num = 0;
			goto IL_00be;
			IL_00a4:
			int count2 = default(int);
			int num2;
			if (P_2 == RNjCJjtqhaADDEkPlZxyCjIZPqW.xqyuuQSofyjoJulEXgAcFSYaDtu)
			{
				count2 = ETKdVHGzAHrBEHOveosWyulSJCY.Count;
				num2 = -1239246739;
				goto IL_001e;
			}
			goto IL_0104;
			IL_00be:
			if (num >= count)
			{
				num2 = -1239246738;
				goto IL_001e;
			}
			goto IL_004e;
			IL_004e:
			if (ekywolUbzMUKlzPKgGxbGKKvGVjB[num].KbfeRbzvruWiJePSeNvnucdAIpaa == P_0 && ekywolUbzMUKlzPKgGxbGKKvGVjB[num].GopNkYanAGUkOmQwUJuTJxkowKA == P_1)
			{
				return num;
			}
			num++;
			num2 = -1239246743;
			goto IL_001e;
			IL_001e:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -1239246744)
				{
				case 4:
					num2 = -1239246737;
					continue;
				case 7:
					break;
				case 2:
					goto IL_0083;
				case 5:
					num3 = 0;
					num2 = -1239246742;
					continue;
				case 3:
					goto IL_00a4;
				case 1:
					goto IL_00be;
				case 0:
					goto IL_00cc;
				default:
					goto IL_0104;
				}
				break;
				IL_00cc:
				if (ETKdVHGzAHrBEHOveosWyulSJCY[num3].KbfeRbzvruWiJePSeNvnucdAIpaa == P_0 && ETKdVHGzAHrBEHOveosWyulSJCY[num3].GopNkYanAGUkOmQwUJuTJxkowKA == P_1)
				{
					return num3;
				}
				num3++;
				num2 = -1239246742;
				continue;
				IL_0083:
				int num4;
				if (num3 < count2)
				{
					num2 = -1239246744;
					num4 = num2;
				}
				else
				{
					num2 = -1239246738;
					num4 = num2;
				}
			}
			goto IL_004e;
			IL_0104:
			return -1;
		}

		public hugBQjWsvPGLoXyvlxWTxnhoGCB SaKAccbdUMjLTbVoIiHDJZFPDTI(int P_0, RNjCJjtqhaADDEkPlZxyCjIZPqW P_1)
		{
			if (P_1 == RNjCJjtqhaADDEkPlZxyCjIZPqW.OPrDnVhLcontoTptCznHaDrwNsAh)
			{
				if (P_0 < 0)
				{
					goto IL_003f;
				}
				if (P_0 >= ekywolUbzMUKlzPKgGxbGKKvGVjB.Count)
				{
					goto IL_0015;
				}
				goto IL_006b;
			}
			int num;
			int num2;
			if (P_0 < 0)
			{
				num = 1126382422;
				num2 = num;
			}
			else
			{
				num = 1126382421;
				num2 = num;
			}
			goto IL_001a;
			IL_0015:
			num = 1126382420;
			goto IL_001a;
			IL_003f:
			throw new ArgumentOutOfRangeException();
			IL_006b:
			return ekywolUbzMUKlzPKgGxbGKKvGVjB[P_0].SaKAccbdUMjLTbVoIiHDJZFPDTI();
			IL_001a:
			while (true)
			{
				switch (num ^ 0x43233B55)
				{
				case 5:
					break;
				case 1:
					goto IL_003f;
				case 0:
					goto IL_004c;
				case 4:
					goto IL_006b;
				case 3:
					throw new ArgumentOutOfRangeException();
				default:
					return ETKdVHGzAHrBEHOveosWyulSJCY[P_0].SaKAccbdUMjLTbVoIiHDJZFPDTI();
				}
				break;
				IL_004c:
				int num3;
				if (P_0 >= ETKdVHGzAHrBEHOveosWyulSJCY.Count)
				{
					num = 1126382422;
					num3 = num;
				}
				else
				{
					num = 1126382423;
					num3 = num;
				}
			}
			goto IL_0015;
		}

		public int rqethfbsSWgvZeeAlkeMCErUAJVJ(int P_0, InputSource P_1, RNjCJjtqhaADDEkPlZxyCjIZPqW P_2)
		{
			int num = QfvcPTCkQKNaHrLDCOXTjZcrUbW(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			switch (P_2)
			{
			case RNjCJjtqhaADDEkPlZxyCjIZPqW.OPrDnVhLcontoTptCznHaDrwNsAh:
				return ekywolUbzMUKlzPKgGxbGKKvGVjB[num].uDkwQcXcrzYWBtuasJBXMAbjLxg;
			case RNjCJjtqhaADDEkPlZxyCjIZPqW.xqyuuQSofyjoJulEXgAcFSYaDtu:
				return ETKdVHGzAHrBEHOveosWyulSJCY[num].uDkwQcXcrzYWBtuasJBXMAbjLxg;
			default:
				return -1;
			}
		}

		private int TbmwCthcnUohisaEvRQrIaIfyqz(int P_0)
		{
			int count = ekywolUbzMUKlzPKgGxbGKKvGVjB.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -106724204;
				while (true)
				{
					switch (num ^ -106724202)
					{
					case 0:
						break;
					case 2:
						num2 = 0;
						num = -106724203;
						continue;
					case 1:
						if (ekywolUbzMUKlzPKgGxbGKKvGVjB[num2].KbfeRbzvruWiJePSeNvnucdAIpaa == P_0)
						{
							return TbmwCthcnUohisaEvRQrIaIfyqz();
						}
						num2++;
						num = -106724203;
						continue;
					default:
						if (num2 >= count)
						{
							return P_0;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		private int TbmwCthcnUohisaEvRQrIaIfyqz()
		{
			int count = ekywolUbzMUKlzPKgGxbGKKvGVjB.Count;
			int num = 0;
			bool flag = default(bool);
			int num3 = default(int);
			while (true)
			{
				int num2 = 321174364;
				while (true)
				{
					switch (num2 ^ 0x1324BB59)
					{
					case 0:
						break;
					default:
						flag = false;
						num3 = 0;
						num2 = 321174362;
						continue;
					case 4:
						num3++;
						num2 = 321174362;
						continue;
					case 3:
					{
						int num4;
						if (num3 >= count)
						{
							num2 = 321174363;
							num4 = num2;
						}
						else
						{
							num2 = 321174360;
							num4 = num2;
						}
						continue;
					}
					case 1:
						if (ekywolUbzMUKlzPKgGxbGKKvGVjB[num3].KbfeRbzvruWiJePSeNvnucdAIpaa == num)
						{
							flag = true;
							num2 = 321174363;
							continue;
						}
						goto case 4;
					case 7:
						return num;
					case 2:
						if (flag)
						{
							num++;
							num2 = 321174367;
						}
						else
						{
							num2 = 321174366;
						}
						continue;
					}
					break;
				}
			}
		}
	}

	private class MVRGhtGnRlGvAeigHxrfgjCVzMAh : IInputManagerJoystickPublic
	{
		private IInputManagerJoystickPublic kYVEkOHTXBhxnrAeWMuOTcRgNeH;

		private int wYDIziyzWuiIHNegEDxTahMFRWS;

		public int rewiredId
		{
			get
			{
				return kYVEkOHTXBhxnrAeWMuOTcRgNeH.rewiredId;
			}
		}

		public int inputManagerId
		{
			get
			{
				return wYDIziyzWuiIHNegEDxTahMFRWS;
			}
		}

		public string name
		{
			get
			{
				return kYVEkOHTXBhxnrAeWMuOTcRgNeH.name;
			}
		}

		public long? systemId
		{
			get
			{
				return kYVEkOHTXBhxnrAeWMuOTcRgNeH.systemId;
			}
		}

		public int unityId
		{
			get
			{
				return kYVEkOHTXBhxnrAeWMuOTcRgNeH.unityId;
			}
		}

		public Guid instanceGuid
		{
			get
			{
				return kYVEkOHTXBhxnrAeWMuOTcRgNeH.instanceGuid;
			}
		}

		public Guid persistentGuid
		{
			get
			{
				return instanceGuid;
			}
		}

		public Controller.Extension extension
		{
			get
			{
				return kYVEkOHTXBhxnrAeWMuOTcRgNeH.extension;
			}
		}

		public MVRGhtGnRlGvAeigHxrfgjCVzMAh(IInputManagerJoystickPublic sourceJoystick, int bridgeJoystickId)
		{
			kYVEkOHTXBhxnrAeWMuOTcRgNeH = sourceJoystick;
			wYDIziyzWuiIHNegEDxTahMFRWS = bridgeJoystickId;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			kYVEkOHTXBhxnrAeWMuOTcRgNeH.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			kYVEkOHTXBhxnrAeWMuOTcRgNeH.StopVibration();
		}
	}

	private sealed class tZhGZCcJjQlbLrEPrxzBHgspFfh
	{
		public int MUAHVYLsMgIewmcSDHiEbwPhABm;

		public int nwxnIFRkYzgPgLVuBRMNoXrDJdE()
		{
			return MUAHVYLsMgIewmcSDHiEbwPhABm++;
		}
	}

	private const bool pXJsHEzJnbVjccexMmPSKMKbdKY = false;

	private const bool xLrOCFKVqdLgAIwtZKuZPwzpaQr = false;

	private const bool kmlQmGwnXYcKokkRNCVYohghvgyH = false;

	private const bool oDyMLPgdYsJVytBrLpqXSuashCt = false;

	private const bool qFuRoATlsEusxefnDYtvQvDQhwN = false;

	private bool GBctTtambVDrGmgNSbmaIAPqDQOB;

	private object ScaoHuMpMofBBaGWUobGOdXOUuW;

	private IndexedDictionary<int, PlatformInputManager> sZWipCUIkBegsboAzpAHXTWLekVx;

	private ARRucpJRKUKoSdGATgCNJjOfktn ORpudJDiNZbxKbDCuzLHUTXZHvp;

	private Action<int, ControllerDataUpdater> OtrNTBJIBbQldvImDmKCAqMRnke;

	private WindowsStandalonePrimaryInputSource HvbwQpLWvlHhzesvauyRQhaFsGf;

	private bool zNuiUQNevHIfHsLnzwvAmMNDBUC;

	private PlatformInputManager KbZxDysFPLnvPkdChDFikEdaiLpJ;

	private bool QxZSLvuKrZdsLuxRUgNxGFQqJMx;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lvntcpgdZsSbabccpIcfMpTzYYr;

	private Func<int> osCAPAIYOEZodlsEwtiFRgmwudTL;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = FTnXWfjUOcgIwWIoVmLFTvfzpAl.EQLEaKXUUIaGUFMZLjvtCylSgIKD();
			IntPtr intPtr2 = FTnXWfjUOcgIwWIoVmLFTvfzpAl.TVCFgKdOWgSUzFpIsdssfCZqoVc();
			bool result = default(bool);
			while (true)
			{
				int num = 960176810;
				while (true)
				{
					bool num2;
					switch (num ^ 0x393B22A8)
					{
					case 0:
						break;
					case 2:
						num2 = intPtr2 != IntPtr.Zero && intPtr == intPtr2;
						goto IL_0041;
					default:
						return result;
					}
					break;
					IL_0041:
					result = num2;
					num = 960176809;
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return ORpudJDiNZbxKbDCuzLHUTXZHvp.deviceCount;
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return KbZxDysFPLnvPkdChDFikEdaiLpJ;
		}
	}

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return KbZxDysFPLnvPkdChDFikEdaiLpJ.inputSource;
		}
	}

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			if (KbZxDysFPLnvPkdChDFikEdaiLpJ == null)
			{
				return InputSource.None;
			}
			return KbZxDysFPLnvPkdChDFikEdaiLpJ.inputSourceType;
		}
	}

	public nWJFPaVEAnZVBaejiLScyIzPghU(ConfigVars configVars, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		bool flag2 = default(bool);
		while (true)
		{
			int num = -512222792;
			while (true)
			{
				switch (num ^ -512222791)
				{
				case 2:
					break;
				case 1:
					goto IL_0024;
				default:
					sZWipCUIkBegsboAzpAHXTWLekVx = new IndexedDictionary<int, PlatformInputManager>();
					if (UnityTools.platform != Platform.WindowsAppStore)
					{
						try
						{
							pJiWDIptILusPhrNPolPsYpexhh.OXxfSVQgpwyQzMSlFTkamYYmQrW();
							kBhxdgWKVLsDoSoTBIFSYguIohE kBhxdgWKVLsDoSoTBIFSYguIohE2 = (kBhxdgWKVLsDoSoTBIFSYguIohE)(ScaoHuMpMofBBaGWUobGOdXOUuW = new kBhxdgWKVLsDoSoTBIFSYguIohE());
							bool flag = false;
							if (HvbwQpLWvlHhzesvauyRQhaFsGf == WindowsStandalonePrimaryInputSource.DirectInput)
							{
								flag = bAVNDtkqezUuZHjvzCILasTCWAbU(configVars, kBhxdgWKVLsDoSoTBIFSYguIohE2);
								if (!flag)
								{
									Logger.Log("Attempting to fallback to Raw Input...");
									flag = HYcmOvfCAgBjMWSsnjNXMAqiCSH(configVars, kBhxdgWKVLsDoSoTBIFSYguIohE2);
									if (flag)
									{
										configVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
										HvbwQpLWvlHhzesvauyRQhaFsGf = configVars.windowsStandalonePrimaryInputSource;
										Logger.Log("Raw Input initialized!");
									}
								}
							}
							else if (HvbwQpLWvlHhzesvauyRQhaFsGf == WindowsStandalonePrimaryInputSource.RawInput)
							{
								flag = HYcmOvfCAgBjMWSsnjNXMAqiCSH(configVars, kBhxdgWKVLsDoSoTBIFSYguIohE2);
								if (!flag)
								{
									Logger.Log("Attempting to fallback to Direct Input...");
									flag = bAVNDtkqezUuZHjvzCILasTCWAbU(configVars, kBhxdgWKVLsDoSoTBIFSYguIohE2);
									if (flag)
									{
										configVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
										HvbwQpLWvlHhzesvauyRQhaFsGf = configVars.windowsStandalonePrimaryInputSource;
										Logger.Log("Direct Input initialized!");
									}
								}
							}
							else if (HvbwQpLWvlHhzesvauyRQhaFsGf == WindowsStandalonePrimaryInputSource.XInput)
							{
								flag = LfpiwBhSrvZSHbyDQmKrMiwRKycl(configVars, false);
								if (flag)
								{
									UIbmlZGokZHnZLfLtHxELklZHgPB(configVars, kBhxdgWKVLsDoSoTBIFSYguIohE2);
								}
								flag2 = flag;
							}
							if (!flag)
							{
								throw new Exception();
							}
							kBhxdgWKVLsDoSoTBIFSYguIohE2.DeviceConnectedEvent += LKSYLFJpHwNdqWMWKHvYwTxufRi;
							kBhxdgWKVLsDoSoTBIFSYguIohE2.DeviceDisconnectedEvent += NThIGvXIPnHeOJoeuEquYrSCJKpg;
							for (int i = 0; i < sZWipCUIkBegsboAzpAHXTWLekVx.Count; i++)
							{
								PlatformInputManager platformInputManager = sZWipCUIkBegsboAzpAHXTWLekVx[i];
								platformInputManager.DeviceConnectedEvent += RzVkjckBjWKrizPraYLaXjSQeHO;
								platformInputManager.DeviceDisconnectedEvent += msYtOZfUSWceIVqDuEmlhduflmJ;
								platformInputManager.UpdateControllerInfoEvent += iUNPQhnLnJrHhPivHqDZWmcEqeu;
							}
						}
						catch (Exception ex)
						{
							OnDestroy();
							Logger.LogWarning("Unable to initialize input source!\n" + ex.Message);
							throw;
						}
					}
					if (!flag2)
					{
						LfpiwBhSrvZSHbyDQmKrMiwRKycl(configVars, true);
					}
					OtrNTBJIBbQldvImDmKCAqMRnke = UpdateControllerData;
					return;
				}
				break;
				IL_0024:
				HvbwQpLWvlHhzesvauyRQhaFsGf = configVars.windowsStandalonePrimaryInputSource;
				zNuiUQNevHIfHsLnzwvAmMNDBUC = configVars.useXInput;
				lvntcpgdZsSbabccpIcfMpTzYYr = getHardwareJoystickMap_InputManager;
				osCAPAIYOEZodlsEwtiFRgmwudTL = getNewJoystickId;
				flag2 = false;
				num = -512222791;
			}
		}
	}

	private bool bAVNDtkqezUuZHjvzCILasTCWAbU(ConfigVars P_0, kBhxdgWKVLsDoSoTBIFSYguIohE P_1)
	{
		ZPFgjuIZrGwPvWsWAyvFqQxHtxkn zPFgjuIZrGwPvWsWAyvFqQxHtxkn = null;
		fXpZHAKkyykjjdntipjmCAIqJMD fXpZHAKkyykjjdntipjmCAIqJMD2 = null;
		try
		{
			zPFgjuIZrGwPvWsWAyvFqQxHtxkn = new ZPFgjuIZrGwPvWsWAyvFqQxHtxkn(P_0, false, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.useEnhancedDeviceSupport);
			fXpZHAKkyykjjdntipjmCAIqJMD2 = new fXpZHAKkyykjjdntipjmCAIqJMD(P_0.updateLoop, zNuiUQNevHIfHsLnzwvAmMNDBUC, ((kBhxdgWKVLsDoSoTBIFSYguIohE)ScaoHuMpMofBBaGWUobGOdXOUuW).windowHandle, lvntcpgdZsSbabccpIcfMpTzYYr, osCAPAIYOEZodlsEwtiFRgmwudTL);
			while (true)
			{
				int num = 236245219;
				while (true)
				{
					switch (num ^ 0xE14D0E2)
					{
					case 0:
						break;
					case 1:
						goto IL_006d;
					default:
						P_1.WindowFocusEvent += zPFgjuIZrGwPvWsWAyvFqQxHtxkn.FVaZVUBSPSViBJbyDLCcalwWIzS;
						return true;
					}
					break;
					IL_006d:
					KbZxDysFPLnvPkdChDFikEdaiLpJ = fXpZHAKkyykjjdntipjmCAIqJMD2;
					sZWipCUIkBegsboAzpAHXTWLekVx.Add(5, zPFgjuIZrGwPvWsWAyvFqQxHtxkn);
					sZWipCUIkBegsboAzpAHXTWLekVx.Add(1, KbZxDysFPLnvPkdChDFikEdaiLpJ);
					num = 236245216;
				}
			}
		}
		catch (Exception)
		{
			if (fXpZHAKkyykjjdntipjmCAIqJMD2 != null)
			{
				fXpZHAKkyykjjdntipjmCAIqJMD2.OnDestroy();
				goto IL_00ba;
			}
			goto IL_00dc;
			IL_00ec:
			Logger.LogWarning("Unable to initialize Direct Input! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
			int num2 = 236245219;
			goto IL_00bf;
			IL_00ba:
			num2 = 236245216;
			goto IL_00bf;
			IL_00bf:
			switch (num2 ^ 0xE14D0E2)
			{
			case 0:
				break;
			default:
				goto end_IL_00b0;
			case 2:
				goto IL_00dc;
			case 3:
				goto IL_00ec;
			case 1:
				goto end_IL_00b0;
			}
			goto IL_00ba;
			IL_00dc:
			if (zPFgjuIZrGwPvWsWAyvFqQxHtxkn != null)
			{
				zPFgjuIZrGwPvWsWAyvFqQxHtxkn.OnDestroy();
				num2 = 236245217;
				goto IL_00bf;
			}
			goto IL_00ec;
			end_IL_00b0:;
		}
		return false;
	}

	private bool HYcmOvfCAgBjMWSsnjNXMAqiCSH(ConfigVars P_0, kBhxdgWKVLsDoSoTBIFSYguIohE P_1)
	{
		ZPFgjuIZrGwPvWsWAyvFqQxHtxkn zPFgjuIZrGwPvWsWAyvFqQxHtxkn = null;
		try
		{
			zPFgjuIZrGwPvWsWAyvFqQxHtxkn = new ZPFgjuIZrGwPvWsWAyvFqQxHtxkn(P_0, P_0.useXInput, lvntcpgdZsSbabccpIcfMpTzYYr, osCAPAIYOEZodlsEwtiFRgmwudTL, true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.useEnhancedDeviceSupport);
			sZWipCUIkBegsboAzpAHXTWLekVx.Add(5, zPFgjuIZrGwPvWsWAyvFqQxHtxkn);
			P_1.WindowFocusEvent += zPFgjuIZrGwPvWsWAyvFqQxHtxkn.FVaZVUBSPSViBJbyDLCcalwWIzS;
			KbZxDysFPLnvPkdChDFikEdaiLpJ = zPFgjuIZrGwPvWsWAyvFqQxHtxkn;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			while (true)
			{
				IL_0063:
				int num = -372483185;
				while (true)
				{
					switch (num ^ -372483186)
					{
					case 2:
						break;
					default:
						goto end_IL_0068;
					case 1:
						if (zPFgjuIZrGwPvWsWAyvFqQxHtxkn != null)
						{
							goto IL_0084;
						}
						goto end_IL_0068;
					case 0:
						goto end_IL_0068;
					}
					goto IL_0063;
					IL_0084:
					zPFgjuIZrGwPvWsWAyvFqQxHtxkn.OnDestroy();
					num = -372483186;
					continue;
					end_IL_0068:
					break;
				}
				break;
			}
		}
		return false;
	}

	private bool UIbmlZGokZHnZLfLtHxELklZHgPB(ConfigVars P_0, kBhxdgWKVLsDoSoTBIFSYguIohE P_1)
	{
		if (!P_0.GetPlatformVar_useNativeMouse() && !P_0.GetPlatformVar_useNativeKeyboard())
		{
			return false;
		}
		ZPFgjuIZrGwPvWsWAyvFqQxHtxkn zPFgjuIZrGwPvWsWAyvFqQxHtxkn = null;
		bool result = default(bool);
		try
		{
			zPFgjuIZrGwPvWsWAyvFqQxHtxkn = new ZPFgjuIZrGwPvWsWAyvFqQxHtxkn(P_0, false, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.useEnhancedDeviceSupport);
			while (true)
			{
				IL_0031:
				int num = -1634698481;
				while (true)
				{
					switch (num ^ -1634698482)
					{
					case 0:
						break;
					default:
						goto end_IL_0036;
					case 1:
						goto IL_004f;
					case 2:
						goto end_IL_0036;
					}
					goto IL_0031;
					IL_004f:
					P_1.WindowFocusEvent += zPFgjuIZrGwPvWsWAyvFqQxHtxkn.FVaZVUBSPSViBJbyDLCcalwWIzS;
					sZWipCUIkBegsboAzpAHXTWLekVx.Add(5, zPFgjuIZrGwPvWsWAyvFqQxHtxkn);
					result = true;
					num = -1634698484;
					continue;
					end_IL_0036:
					break;
				}
				break;
			}
		}
		catch
		{
			while (true)
			{
				IL_007a:
				int num2 = -1634698484;
				while (true)
				{
					switch (num2 ^ -1634698482)
					{
					case 0:
						break;
					case 2:
						Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
						if (zPFgjuIZrGwPvWsWAyvFqQxHtxkn != null)
						{
							goto IL_00a5;
						}
						goto default;
					default:
						zPFgjuIZrGwPvWsWAyvFqQxHtxkn = null;
						result = false;
						goto end_IL_007f;
					}
					goto IL_007a;
					IL_00a5:
					zPFgjuIZrGwPvWsWAyvFqQxHtxkn.OnDestroy();
					num2 = -1634698481;
					continue;
					end_IL_007f:
					break;
				}
				break;
			}
		}
		return result;
	}

	private bool LfpiwBhSrvZSHbyDQmKrMiwRKycl(ConfigVars P_0, bool P_1)
	{
		bool flag = KbZxDysFPLnvPkdChDFikEdaiLpJ == null;
		if (!P_0.useXInput && !flag)
		{
			goto IL_0015;
		}
		int num = 1;
		goto IL_0042;
		IL_0042:
		bool flag2 = (byte)num != 0;
		bool flag3 = false;
		int num2 = -1284315821;
		goto IL_001a;
		IL_0037:
		num = ((ReInput.currentPlatform == Platform.WindowsAppStore) ? 1 : 0);
		goto IL_0042;
		IL_0015:
		num2 = -1284315822;
		goto IL_001a;
		IL_001a:
		khPCPJgtQFokObAEkJKNQbaUfSZG value = default(khPCPJgtQFokObAEkJKNQbaUfSZG);
		tZhGZCcJjQlbLrEPrxzBHgspFfh tZhGZCcJjQlbLrEPrxzBHgspFfh2 = default(tZhGZCcJjQlbLrEPrxzBHgspFfh);
		khPCPJgtQFokObAEkJKNQbaUfSZG khPCPJgtQFokObAEkJKNQbaUfSZG2 = default(khPCPJgtQFokObAEkJKNQbaUfSZG);
		kxzXTdiJorHKVUHhoBvSNMIscik kxzXTdiJorHKVUHhoBvSNMIscik2 = default(kxzXTdiJorHKVUHhoBvSNMIscik);
		int num6 = default(int);
		while (true)
		{
			switch (num2 ^ -1284315821)
			{
			case 3:
				break;
			case 1:
				goto IL_0037;
			case 0:
				goto IL_004e;
			default:
				return false;
			}
			break;
			IL_004e:
			if (!flag2)
			{
				num2 = -1284315823;
				continue;
			}
			try
			{
				if (flag3)
				{
					goto IL_005d;
				}
				goto IL_0092;
				IL_005d:
				int num3 = -1284315817;
				goto IL_0062;
				IL_0062:
				while (true)
				{
					switch (num3 ^ -1284315821)
					{
					case 0:
						break;
					case 1:
						goto IL_0092;
					case 5:
						value = new khPCPJgtQFokObAEkJKNQbaUfSZG(flag3, P_0.updateLoop, lvntcpgdZsSbabccpIcfMpTzYYr, tZhGZCcJjQlbLrEPrxzBHgspFfh2.nwxnIFRkYzgPgLVuBRMNoXrDJdE);
						num3 = -1284315823;
						continue;
					case 4:
						tZhGZCcJjQlbLrEPrxzBHgspFfh2 = new tZhGZCcJjQlbLrEPrxzBHgspFfh();
						tZhGZCcJjQlbLrEPrxzBHgspFfh2.MUAHVYLsMgIewmcSDHiEbwPhABm = 0;
						num3 = -1284315818;
						continue;
					case 6:
						goto IL_0101;
					case 3:
						num3 = -1284315820;
						continue;
					case 2:
						sZWipCUIkBegsboAzpAHXTWLekVx.Add(2, value);
						num3 = -1284315824;
						continue;
					default:
						goto IL_0176;
					}
					break;
				}
				goto IL_005d;
				IL_0092:
				khPCPJgtQFokObAEkJKNQbaUfSZG2 = new khPCPJgtQFokObAEkJKNQbaUfSZG(flag3, P_0.updateLoop, lvntcpgdZsSbabccpIcfMpTzYYr, osCAPAIYOEZodlsEwtiFRgmwudTL);
				if (flag)
				{
					KbZxDysFPLnvPkdChDFikEdaiLpJ = khPCPJgtQFokObAEkJKNQbaUfSZG2;
					num3 = -1284315819;
					goto IL_0062;
				}
				goto IL_0101;
				IL_0101:
				sZWipCUIkBegsboAzpAHXTWLekVx.Add(2, khPCPJgtQFokObAEkJKNQbaUfSZG2);
				if (P_1)
				{
					khPCPJgtQFokObAEkJKNQbaUfSZG2.DeviceConnectedEvent += RzVkjckBjWKrizPraYLaXjSQeHO;
					khPCPJgtQFokObAEkJKNQbaUfSZG2.DeviceDisconnectedEvent += msYtOZfUSWceIVqDuEmlhduflmJ;
					khPCPJgtQFokObAEkJKNQbaUfSZG2.UpdateControllerInfoEvent += iUNPQhnLnJrHhPivHqDZWmcEqeu;
					num3 = -1284315820;
					goto IL_0062;
				}
				goto IL_0176;
				IL_0176:
				return true;
			}
			catch (Exception)
			{
				if (flag)
				{
					OnDestroy();
					Logger.LogWarning("Unable to initialize XInput!");
					goto IL_0195;
				}
				goto IL_022f;
				IL_022f:
				int num4;
				int num5;
				if (!flag3)
				{
					num4 = -1284315819;
					num5 = num4;
				}
				else
				{
					num4 = -1284315824;
					num5 = num4;
				}
				goto IL_019a;
				IL_0195:
				num4 = -1284315822;
				goto IL_019a;
				IL_019a:
				while (true)
				{
					switch (num4 ^ -1284315821)
					{
					case 2:
						break;
					case 1:
						throw;
					case 9:
						kxzXTdiJorHKVUHhoBvSNMIscik2.useXInput = false;
						num4 = -1284315818;
						continue;
					case 4:
						if (sZWipCUIkBegsboAzpAHXTWLekVx[num6] != null)
						{
							goto IL_01f9;
						}
						goto case 5;
					case 8:
						num4 = -1284315820;
						continue;
					case 0:
						goto IL_022f;
					case 7:
						if (num6 >= sZWipCUIkBegsboAzpAHXTWLekVx.Count)
						{
							Logger.LogWarning("Unable to initialize XInput! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
							num4 = -1284315824;
							continue;
						}
						goto case 4;
					case 5:
						num6++;
						num4 = -1284315820;
						continue;
					case 6:
						Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + HvbwQpLWvlHhzesvauyRQhaFsGf.ToString() + " instead. The L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
						P_0.useXInput = false;
						num6 = 0;
						num4 = -1284315813;
						continue;
					default:
						return false;
					}
					break;
					IL_01f9:
					kxzXTdiJorHKVUHhoBvSNMIscik2 = sZWipCUIkBegsboAzpAHXTWLekVx[num6] as kxzXTdiJorHKVUHhoBvSNMIscik;
					int num7;
					if (kxzXTdiJorHKVUHhoBvSNMIscik2 != null)
					{
						num4 = -1284315814;
						num7 = num4;
					}
					else
					{
						num4 = -1284315818;
						num7 = num4;
					}
				}
				goto IL_0195;
			}
		}
		goto IL_0015;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		GBctTtambVDrGmgNSbmaIAPqDQOB = true;
		int num2 = default(int);
		while (true)
		{
			int num = 46078865;
			while (true)
			{
				switch (num ^ 0x2BF1B92)
				{
				case 0:
					break;
				case 4:
					sZWipCUIkBegsboAzpAHXTWLekVx[num2].Initialize();
					num2++;
					num = 46078867;
					continue;
				case 2:
					num = 46078867;
					continue;
				case 3:
					ORpudJDiNZbxKbDCuzLHUTXZHvp = new ARRucpJRKUKoSdGATgCNJjOfktn();
					num2 = 0;
					num = 46078864;
					continue;
				default:
					if (num2 >= sZWipCUIkBegsboAzpAHXTWLekVx.Count)
					{
						return;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		int num = 0;
		while (true)
		{
			int num2 = 2119896211;
			while (true)
			{
				switch (num2 ^ 0x7E5B0C90)
				{
				case 0:
					break;
				case 3:
					num2 = 2119896210;
					continue;
				case 1:
					sZWipCUIkBegsboAzpAHXTWLekVx[num].Update(currentUpdateLoop);
					num++;
					num2 = 2119896210;
					continue;
				default:
					if (num >= sZWipCUIkBegsboAzpAHXTWLekVx.Count)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		int num = sZWipCUIkBegsboAzpAHXTWLekVx.Count - 1;
		while (true)
		{
			int num2 = 2125590452;
			while (true)
			{
				switch (num2 ^ 0x7EB1EFB0)
				{
				case 3:
					break;
				case 4:
					num2 = 2125590448;
					continue;
				case 0:
					if (num >= 0)
					{
						goto case 2;
					}
					if (ScaoHuMpMofBBaGWUobGOdXOUuW != null)
					{
						((kBhxdgWKVLsDoSoTBIFSYguIohE)ScaoHuMpMofBBaGWUobGOdXOUuW).OnDestroy();
						ScaoHuMpMofBBaGWUobGOdXOUuW = null;
						num2 = 2125590449;
						continue;
					}
					goto default;
				case 2:
					sZWipCUIkBegsboAzpAHXTWLekVx[num].OnDestroy();
					num--;
					num2 = 2125590448;
					continue;
				default:
					pJiWDIptILusPhrNPolPsYpexhh.JGfOaxGMMubjxaprhTWpWgtvAPZ();
					return;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return OtrNTBJIBbQldvImDmKCAqMRnke;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		sZWipCUIkBegsboAzpAHXTWLekVx.GetValue((int)data.source).UpdateControllerData(ORpudJDiNZbxKbDCuzLHUTXZHvp.rqethfbsSWgvZeeAlkeMCErUAJVJ(controllerId, data.source, ARRucpJRKUKoSdGATgCNJjOfktn.RNjCJjtqhaADDEkPlZxyCjIZPqW.OPrDnVhLcontoTptCznHaDrwNsAh), data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		int num = 0;
		while (true)
		{
			int num2 = 54065215;
			while (true)
			{
				switch (num2 ^ 0x338F83C)
				{
				case 0:
					break;
				case 3:
					num2 = 54065214;
					continue;
				case 1:
				{
					IUnifiedMouseSource unifiedMouseSource = sZWipCUIkBegsboAzpAHXTWLekVx[num].GetUnifiedMouseSource();
					if (unifiedMouseSource != null)
					{
						return unifiedMouseSource;
					}
					num++;
					num2 = 54065214;
					continue;
				}
				default:
					if (num >= sZWipCUIkBegsboAzpAHXTWLekVx.Count)
					{
						return null;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		int num = 0;
		while (num < sZWipCUIkBegsboAzpAHXTWLekVx.Count)
		{
			while (true)
			{
				IUnifiedKeyboardSource unifiedKeyboardSource = sZWipCUIkBegsboAzpAHXTWLekVx[num].GetUnifiedKeyboardSource();
				int num2 = -507524999;
				while (true)
				{
					switch (num2 ^ -507524998)
					{
					case 2:
						num2 = -507524997;
						continue;
					case 1:
						break;
					case 4:
						return unifiedKeyboardSource;
					case 3:
						goto IL_0050;
					default:
						goto end_IL_002a;
					}
					break;
					IL_0050:
					if (unifiedKeyboardSource == null)
					{
						num++;
						num2 = -507524998;
					}
					else
					{
						num2 = -507524994;
					}
				}
				continue;
				end_IL_002a:
				break;
			}
		}
		return null;
	}

	private void RzVkjckBjWKrizPraYLaXjSQeHO(BridgedController P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		while (true)
		{
			ORpudJDiNZbxKbDCuzLHUTXZHvp.THjMgpRqkzsiJWNJfkDjpONSJZu(P_0);
			int num = -1566015981;
			while (true)
			{
				switch (num ^ -1566015983)
				{
				case 0:
					num = -1566015984;
					continue;
				default:
					return;
				case 1:
					break;
				case 2:
					if (_DeviceConnectedEvent != null)
					{
						_DeviceConnectedEvent(P_0);
						num = -1566015982;
						continue;
					}
					return;
				case 3:
					return;
				}
				break;
			}
		}
	}

	private void msYtOZfUSWceIVqDuEmlhduflmJ(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		while (true)
		{
			ORpudJDiNZbxKbDCuzLHUTXZHvp.wZoRTCniYGUlYCHRtxHNmxSLryr(P_0);
			int num = -1124920260;
			while (true)
			{
				switch (num ^ -1124920258)
				{
				case 0:
					num = -1124920257;
					continue;
				default:
					return;
				case 1:
					break;
				case 2:
					if (_DeviceDisconnectedEvent != null)
					{
						_DeviceDisconnectedEvent(P_0);
						num = -1124920259;
						continue;
					}
					return;
				case 3:
					return;
				}
				break;
			}
		}
	}

	private void LKSYLFJpHwNdqWMWKHvYwTxufRi(EventArgs P_0)
	{
		if (!GBctTtambVDrGmgNSbmaIAPqDQOB)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = -722048556;
			while (true)
			{
				switch (num2 ^ -722048556)
				{
				case 4:
					num2 = -722048555;
					continue;
				case 1:
					break;
				case 2:
					sZWipCUIkBegsboAzpAHXTWLekVx[num].SystemDeviceConnected();
					num++;
					num2 = -722048553;
					continue;
				case 0:
					num2 = -722048553;
					continue;
				default:
					if (num >= sZWipCUIkBegsboAzpAHXTWLekVx.Count)
					{
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	private void NThIGvXIPnHeOJoeuEquYrSCJKpg(EventArgs P_0)
	{
		if (!GBctTtambVDrGmgNSbmaIAPqDQOB)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = -1424389596;
			while (true)
			{
				switch (num2 ^ -1424389594)
				{
				case 0:
					num2 = -1424389595;
					continue;
				case 3:
					break;
				case 1:
					sZWipCUIkBegsboAzpAHXTWLekVx[num].SystemDeviceDisconnected();
					num++;
					num2 = -1424389596;
					continue;
				default:
					if (num >= sZWipCUIkBegsboAzpAHXTWLekVx.Count)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	private void iUNPQhnLnJrHhPivHqDZWmcEqeu(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null)
		{
			if (P_0.sourceJoystick == null)
			{
				goto IL_000e;
			}
			goto IL_0098;
		}
		return;
		IL_0098:
		ORpudJDiNZbxKbDCuzLHUTXZHvp.YFDRilQqmwEqtrRKfdFRFiCygbmW(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		ARRucpJRKUKoSdGATgCNJjOfktn.RNjCJjtqhaADDEkPlZxyCjIZPqW rNjCJjtqhaADDEkPlZxyCjIZPqW = ARRucpJRKUKoSdGATgCNJjOfktn.RNjCJjtqhaADDEkPlZxyCjIZPqW.OPrDnVhLcontoTptCznHaDrwNsAh;
		int num = -1178490494;
		goto IL_0013;
		IL_000e:
		num = -1178490491;
		goto IL_0013;
		IL_0013:
		ARRucpJRKUKoSdGATgCNJjOfktn.hugBQjWsvPGLoXyvlxWTxnhoGCB hugBQjWsvPGLoXyvlxWTxnhoGCB = default(ARRucpJRKUKoSdGATgCNJjOfktn.hugBQjWsvPGLoXyvlxWTxnhoGCB);
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -1178490490)
			{
			case 5:
				break;
			default:
				return;
			case 3:
				return;
			case 1:
				hugBQjWsvPGLoXyvlxWTxnhoGCB = ORpudJDiNZbxKbDCuzLHUTXZHvp.SaKAccbdUMjLTbVoIiHDJZFPDTI(num2, rNjCJjtqhaADDEkPlZxyCjIZPqW);
				num = -1178490490;
				continue;
			case 6:
				if (num2 < 0)
				{
					rNjCJjtqhaADDEkPlZxyCjIZPqW = ARRucpJRKUKoSdGATgCNJjOfktn.RNjCJjtqhaADDEkPlZxyCjIZPqW.xqyuuQSofyjoJulEXgAcFSYaDtu;
					num2 = ORpudJDiNZbxKbDCuzLHUTXZHvp.QfvcPTCkQKNaHrLDCOXTjZcrUbW(P_0.sourceJoystick.rewiredId, rNjCJjtqhaADDEkPlZxyCjIZPqW);
					num = -1178490495;
					continue;
				}
				goto case 7;
			case 7:
				if (num2 < 0)
				{
					return;
				}
				goto case 1;
			case 8:
				goto IL_0098;
			case 4:
				num2 = ORpudJDiNZbxKbDCuzLHUTXZHvp.QfvcPTCkQKNaHrLDCOXTjZcrUbW(P_0.sourceJoystick.rewiredId, rNjCJjtqhaADDEkPlZxyCjIZPqW);
				num = -1178490496;
				continue;
			case 0:
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new MVRGhtGnRlGvAeigHxrfgjCVzMAh(P_0.sourceJoystick, hugBQjWsvPGLoXyvlxWTxnhoGCB.KbfeRbzvruWiJePSeNvnucdAIpaa)));
					num = -1178490492;
					continue;
				}
				return;
			case 2:
				return;
			}
			break;
		}
		goto IL_000e;
	}
}
