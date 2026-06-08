using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class sYGArRodgBwPmjtbrSXkcLAheAe : PlatformInputManager, INativePlatformHelper
{
	private class SIlXjjDDnZEDjhFtWDuKHMMICuY
	{
		private class pXQObVitdKrvkFTwcysZNHsZDbM
		{
			public int VykOoYENAAVycnKptyohgAtorFA;

			public int jwtKTNmXDNczkwosndKDKQSNLbM;

			public int yZbfwbcOfEQXIIRxMOccfcRcgViT;

			public InputSource LMofllDVwkfLxnRkZcSVHJPEQcuP;

			public pXQObVitdKrvkFTwcysZNHsZDbM(int mapperId, int managerId, int id, InputSource source)
			{
				VykOoYENAAVycnKptyohgAtorFA = mapperId;
				jwtKTNmXDNczkwosndKDKQSNLbM = managerId;
				yZbfwbcOfEQXIIRxMOccfcRcgViT = id;
				LMofllDVwkfLxnRkZcSVHJPEQcuP = source;
			}

			public void FFYEDujhZPZIRSsDbLkeXQkxTZI(int P_0)
			{
				jwtKTNmXDNczkwosndKDKQSNLbM = P_0;
			}

			public gcJEzhNjqVxipTvmEIoICIDfPNr BaBpEBAqcmoNeySgHAPRXPulVoo()
			{
				return new gcJEzhNjqVxipTvmEIoICIDfPNr(VykOoYENAAVycnKptyohgAtorFA, jwtKTNmXDNczkwosndKDKQSNLbM, LMofllDVwkfLxnRkZcSVHJPEQcuP);
			}

			public static int hAwBLcLYCGKRLtQSbQoPeLrJpvT(pXQObVitdKrvkFTwcysZNHsZDbM P_0, pXQObVitdKrvkFTwcysZNHsZDbM P_1)
			{
				if (P_0.VykOoYENAAVycnKptyohgAtorFA < P_1.VykOoYENAAVycnKptyohgAtorFA)
				{
					return -1;
				}
				if (P_0.VykOoYENAAVycnKptyohgAtorFA > P_1.VykOoYENAAVycnKptyohgAtorFA)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct gcJEzhNjqVxipTvmEIoICIDfPNr
		{
			public int VykOoYENAAVycnKptyohgAtorFA;

			public int jwtKTNmXDNczkwosndKDKQSNLbM;

			public InputSource LMofllDVwkfLxnRkZcSVHJPEQcuP;

			public gcJEzhNjqVxipTvmEIoICIDfPNr(int mapperId, int managerId, InputSource source)
			{
				VykOoYENAAVycnKptyohgAtorFA = mapperId;
				jwtKTNmXDNczkwosndKDKQSNLbM = managerId;
				LMofllDVwkfLxnRkZcSVHJPEQcuP = source;
			}
		}

		public enum TbaDHFJPbFybdlSowNbrQsACJTwB
		{
			ZLkRominQCKUBwwrVSwFZLKUpyk = 0,
			qhdlbmvVPGSkmbKUCbanVffQNKm = 1
		}

		private List<pXQObVitdKrvkFTwcysZNHsZDbM> ZsJwmmnyhzMypUnEhnDEeGWiNEc;

		private List<pXQObVitdKrvkFTwcysZNHsZDbM> hqfKvIlYBoSnKeJAlDwvdApVFZRQ;

		public int deviceCount => hqfKvIlYBoSnKeJAlDwvdApVFZRQ.Count;

		public SIlXjjDDnZEDjhFtWDuKHMMICuY()
		{
			hqfKvIlYBoSnKeJAlDwvdApVFZRQ = new List<pXQObVitdKrvkFTwcysZNHsZDbM>();
			ZsJwmmnyhzMypUnEhnDEeGWiNEc = new List<pXQObVitdKrvkFTwcysZNHsZDbM>();
		}

		public void CkkGhQIeIZDBuzNDuaEbtdiidPQF(BridgedController P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num3 = default(int);
			IInputManagerJoystickPublic sourceJoystick = default(IInputManagerJoystickPublic);
			pXQObVitdKrvkFTwcysZNHsZDbM pXQObVitdKrvkFTwcysZNHsZDbM2 = default(pXQObVitdKrvkFTwcysZNHsZDbM);
			while (true)
			{
				int num = -1338357047;
				while (true)
				{
					switch (num ^ -1338357045)
					{
					case 0:
						break;
					case 10:
						if (num3 >= 0)
						{
							pXQObVitdKrvkFTwcysZNHsZDbM2 = ZsJwmmnyhzMypUnEhnDEeGWiNEc[num3];
							ZsJwmmnyhzMypUnEhnDEeGWiNEc.RemoveAt(num3);
							int vykOoYENAAVycnKptyohgAtorFA = SCpnBACyPaMEZzDOuTHpIMjDLmL(pXQObVitdKrvkFTwcysZNHsZDbM2.VykOoYENAAVycnKptyohgAtorFA);
							pXQObVitdKrvkFTwcysZNHsZDbM2.VykOoYENAAVycnKptyohgAtorFA = vykOoYENAAVycnKptyohgAtorFA;
							num = -1338357054;
							continue;
						}
						goto case 3;
					case 11:
						return;
					case 9:
						P_0.sourceJoystick = new GbYDRZJxOYBLNwxlBAhGhqYBwmIC(sourceJoystick, pXQObVitdKrvkFTwcysZNHsZDbM2.VykOoYENAAVycnKptyohgAtorFA);
						num = -1338357053;
						continue;
					case 3:
						pXQObVitdKrvkFTwcysZNHsZDbM2 = new pXQObVitdKrvkFTwcysZNHsZDbM(SCpnBACyPaMEZzDOuTHpIMjDLmL(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
						num = -1338357054;
						continue;
					case 6:
						num3 = LdeYUipgUiPUwsTmDLLPrLKDSEy(sourceJoystick.rewiredId, TbaDHFJPbFybdlSowNbrQsACJTwB.qhdlbmvVPGSkmbKUCbanVffQNKm);
						num = -1338357055;
						continue;
					case 8:
						hqfKvIlYBoSnKeJAlDwvdApVFZRQ.Add(pXQObVitdKrvkFTwcysZNHsZDbM2);
						num = -1338357044;
						continue;
					case 5:
						num3 = LdeYUipgUiPUwsTmDLLPrLKDSEy(sourceJoystick.rewiredId, TbaDHFJPbFybdlSowNbrQsACJTwB.ZLkRominQCKUBwwrVSwFZLKUpyk);
						num = -1338357046;
						continue;
					case 4:
						sourceJoystick = P_0.sourceJoystick;
						num = -1338357042;
						continue;
					case 1:
						if (num3 >= 0)
						{
							pXQObVitdKrvkFTwcysZNHsZDbM2 = hqfKvIlYBoSnKeJAlDwvdApVFZRQ[num3];
							pXQObVitdKrvkFTwcysZNHsZDbM2.FFYEDujhZPZIRSsDbLkeXQkxTZI(sourceJoystick.inputManagerId);
							P_0.sourceJoystick = new GbYDRZJxOYBLNwxlBAhGhqYBwmIC(sourceJoystick, pXQObVitdKrvkFTwcysZNHsZDbM2.VykOoYENAAVycnKptyohgAtorFA);
							return;
						}
						goto case 6;
					case 2:
					{
						int num2;
						if (P_0.sourceJoystick == null)
						{
							num = -1338357056;
							num2 = num;
						}
						else
						{
							num = -1338357041;
							num2 = num;
						}
						continue;
					}
					default:
						hqfKvIlYBoSnKeJAlDwvdApVFZRQ.Sort(pXQObVitdKrvkFTwcysZNHsZDbM.hAwBLcLYCGKRLtQSbQoPeLrJpvT);
						return;
					}
					break;
				}
			}
		}

		public void vAnDChAOoomGtjTRhiWRhyxrvoZo(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = LdeYUipgUiPUwsTmDLLPrLKDSEy(P_0.rewiredId, TbaDHFJPbFybdlSowNbrQsACJTwB.ZLkRominQCKUBwwrVSwFZLKUpyk);
				int num2 = 1501621042;
				while (true)
				{
					switch (num2 ^ 0x5980EB30)
					{
					case 4:
						num2 = 1501621041;
						continue;
					default:
						return;
					case 0:
						Logger.LogError("Device was not in connected list! Cannot remove!");
						return;
					case 2:
					{
						int num3;
						if (num >= 0)
						{
							num2 = 1501621045;
							num3 = num2;
						}
						else
						{
							num2 = 1501621040;
							num3 = num2;
						}
						continue;
					}
					case 1:
						break;
					case 5:
					{
						pXQObVitdKrvkFTwcysZNHsZDbM item = hqfKvIlYBoSnKeJAlDwvdApVFZRQ[num];
						hqfKvIlYBoSnKeJAlDwvdApVFZRQ.RemoveAt(num);
						ZsJwmmnyhzMypUnEhnDEeGWiNEc.Add(item);
						num2 = 1501621043;
						continue;
					}
					case 3:
						return;
					}
					break;
				}
			}
		}

		public void HNQBfUDlCKtTIaiIwGKBfubiIzSu(int P_0, int P_1)
		{
			int num = LdeYUipgUiPUwsTmDLLPrLKDSEy(P_0, TbaDHFJPbFybdlSowNbrQsACJTwB.ZLkRominQCKUBwwrVSwFZLKUpyk);
			while (true)
			{
				int num2 = 1424463058;
				while (true)
				{
					switch (num2 ^ 0x54E794D3)
					{
					case 4:
						break;
					default:
						return;
					case 1:
						if (num >= 0)
						{
							pXQObVitdKrvkFTwcysZNHsZDbM pXQObVitdKrvkFTwcysZNHsZDbM2 = hqfKvIlYBoSnKeJAlDwvdApVFZRQ[num];
							pXQObVitdKrvkFTwcysZNHsZDbM2.FFYEDujhZPZIRSsDbLkeXQkxTZI(P_1);
							return;
						}
						goto case 5;
					case 2:
					{
						int num3;
						if (num >= 0)
						{
							num2 = 1424463056;
							num3 = num2;
						}
						else
						{
							num2 = 1424463059;
							num3 = num2;
						}
						continue;
					}
					case 3:
					{
						pXQObVitdKrvkFTwcysZNHsZDbM pXQObVitdKrvkFTwcysZNHsZDbM2 = ZsJwmmnyhzMypUnEhnDEeGWiNEc[num];
						pXQObVitdKrvkFTwcysZNHsZDbM2.FFYEDujhZPZIRSsDbLkeXQkxTZI(P_1);
						num2 = 1424463059;
						continue;
					}
					case 5:
						num = LdeYUipgUiPUwsTmDLLPrLKDSEy(P_0, TbaDHFJPbFybdlSowNbrQsACJTwB.qhdlbmvVPGSkmbKUCbanVffQNKm);
						num2 = 1424463057;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		public bool RYjoxuvBIQdFpgfUrGqIfrkODTT(int P_0, TbaDHFJPbFybdlSowNbrQsACJTwB P_1)
		{
			if (LdeYUipgUiPUwsTmDLLPrLKDSEy(P_0, P_1) < 0)
			{
				return false;
			}
			return true;
		}

		public int LdeYUipgUiPUwsTmDLLPrLKDSEy(int P_0, TbaDHFJPbFybdlSowNbrQsACJTwB P_1)
		{
			if (P_1 == TbaDHFJPbFybdlSowNbrQsACJTwB.ZLkRominQCKUBwwrVSwFZLKUpyk)
			{
				goto IL_0003;
			}
			goto IL_0079;
			IL_0003:
			int num = 50050541;
			goto IL_0008;
			IL_0008:
			int count = default(int);
			int num2 = default(int);
			int num3 = default(int);
			int count2 = default(int);
			while (true)
			{
				switch (num ^ 0x2FBB5EC)
				{
				case 6:
					break;
				case 1:
					count = hqfKvIlYBoSnKeJAlDwvdApVFZRQ.Count;
					num2 = 0;
					num = 50050537;
					continue;
				case 5:
					if (num2 >= count)
					{
						num = 50050543;
						continue;
					}
					goto IL_0058;
				case 7:
					goto IL_0058;
				case 0:
					goto IL_0079;
				case 2:
					goto IL_0095;
				case 4:
					goto IL_00b9;
				default:
					goto IL_00d1;
				}
				break;
				IL_00b9:
				int num4;
				if (num3 < count2)
				{
					num = 50050542;
					num4 = num;
				}
				else
				{
					num = 50050543;
					num4 = num;
				}
				continue;
				IL_0095:
				if (ZsJwmmnyhzMypUnEhnDEeGWiNEc[num3].yZbfwbcOfEQXIIRxMOccfcRcgViT == P_0)
				{
					return num3;
				}
				num3++;
				num = 50050536;
				continue;
				IL_0058:
				if (hqfKvIlYBoSnKeJAlDwvdApVFZRQ[num2].yZbfwbcOfEQXIIRxMOccfcRcgViT == P_0)
				{
					return num2;
				}
				num2++;
				num = 50050537;
			}
			goto IL_0003;
			IL_0079:
			if (P_1 == TbaDHFJPbFybdlSowNbrQsACJTwB.qhdlbmvVPGSkmbKUCbanVffQNKm)
			{
				count2 = ZsJwmmnyhzMypUnEhnDEeGWiNEc.Count;
				num3 = 0;
				num = 50050536;
				goto IL_0008;
			}
			goto IL_00d1;
			IL_00d1:
			return -1;
		}

		public int LdeYUipgUiPUwsTmDLLPrLKDSEy(int P_0, InputSource P_1, TbaDHFJPbFybdlSowNbrQsACJTwB P_2)
		{
			int count = default(int);
			if (P_2 == TbaDHFJPbFybdlSowNbrQsACJTwB.ZLkRominQCKUBwwrVSwFZLKUpyk)
			{
				count = hqfKvIlYBoSnKeJAlDwvdApVFZRQ.Count;
				goto IL_000f;
			}
			goto IL_0079;
			IL_013a:
			return -1;
			IL_000f:
			int num = -1998736730;
			goto IL_0014;
			IL_0014:
			int num2 = default(int);
			int num3 = default(int);
			int count2 = default(int);
			while (true)
			{
				switch (num ^ -1998736729)
				{
				case 8:
					break;
				case 11:
					num = -1998736732;
					continue;
				case 5:
					goto IL_005b;
				case 0:
					goto IL_0079;
				case 2:
					if (num2 >= count)
					{
						num = -1998736722;
						continue;
					}
					goto IL_005b;
				case 4:
					return num3;
				case 10:
					goto IL_00b6;
				case 7:
					goto IL_00e8;
				case 3:
					goto IL_0106;
				case 6:
					return num2;
				case 1:
					num2 = 0;
					num = -1998736731;
					continue;
				default:
					goto IL_013a;
				}
				break;
				IL_0106:
				int num4;
				if (num3 >= count2)
				{
					num = -1998736722;
					num4 = num;
				}
				else
				{
					num = -1998736723;
					num4 = num;
				}
				continue;
				IL_00b6:
				if (ZsJwmmnyhzMypUnEhnDEeGWiNEc[num3].VykOoYENAAVycnKptyohgAtorFA != P_0 || ZsJwmmnyhzMypUnEhnDEeGWiNEc[num3].LMofllDVwkfLxnRkZcSVHJPEQcuP != P_1)
				{
					num3++;
					num = -1998736732;
				}
				else
				{
					num = -1998736733;
				}
				continue;
				IL_005b:
				if (hqfKvIlYBoSnKeJAlDwvdApVFZRQ[num2].VykOoYENAAVycnKptyohgAtorFA == P_0)
				{
					num = -1998736736;
					continue;
				}
				goto IL_0120;
				IL_00e8:
				if (hqfKvIlYBoSnKeJAlDwvdApVFZRQ[num2].LMofllDVwkfLxnRkZcSVHJPEQcuP == P_1)
				{
					num = -1998736735;
					continue;
				}
				goto IL_0120;
				IL_0120:
				num2++;
				num = -1998736731;
			}
			goto IL_000f;
			IL_0079:
			if (P_2 == TbaDHFJPbFybdlSowNbrQsACJTwB.qhdlbmvVPGSkmbKUCbanVffQNKm)
			{
				count2 = ZsJwmmnyhzMypUnEhnDEeGWiNEc.Count;
				num3 = 0;
				num = -1998736724;
				goto IL_0014;
			}
			goto IL_013a;
		}

		public gcJEzhNjqVxipTvmEIoICIDfPNr BaBpEBAqcmoNeySgHAPRXPulVoo(int P_0, TbaDHFJPbFybdlSowNbrQsACJTwB P_1)
		{
			if (P_1 == TbaDHFJPbFybdlSowNbrQsACJTwB.ZLkRominQCKUBwwrVSwFZLKUpyk)
			{
				goto IL_0003;
			}
			int num;
			if (P_0 >= 0)
			{
				int num2;
				if (P_0 < ZsJwmmnyhzMypUnEhnDEeGWiNEc.Count)
				{
					num = -1789828533;
					num2 = num;
				}
				else
				{
					num = -1789828529;
					num2 = num;
				}
				goto IL_0008;
			}
			goto IL_0095;
			IL_0008:
			while (true)
			{
				switch (num ^ -1789828529)
				{
				case 5:
					break;
				case 2:
					return hqfKvIlYBoSnKeJAlDwvdApVFZRQ[P_0].BaBpEBAqcmoNeySgHAPRXPulVoo();
				case 3:
					throw new ArgumentOutOfRangeException();
				case 1:
					if (P_0 < 0)
					{
						goto case 3;
					}
					goto IL_0073;
				case 0:
					goto IL_0095;
				default:
					return ZsJwmmnyhzMypUnEhnDEeGWiNEc[P_0].BaBpEBAqcmoNeySgHAPRXPulVoo();
				}
				break;
				IL_0073:
				int num3;
				if (P_0 < hqfKvIlYBoSnKeJAlDwvdApVFZRQ.Count)
				{
					num = -1789828531;
					num3 = num;
				}
				else
				{
					num = -1789828532;
					num3 = num;
				}
			}
			goto IL_0003;
			IL_0003:
			num = -1789828530;
			goto IL_0008;
			IL_0095:
			throw new ArgumentOutOfRangeException();
		}

		public int swfGqWYjosOZspSQopxMMEMsoPv(int P_0, InputSource P_1, TbaDHFJPbFybdlSowNbrQsACJTwB P_2)
		{
			int num = LdeYUipgUiPUwsTmDLLPrLKDSEy(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			switch (P_2)
			{
			case TbaDHFJPbFybdlSowNbrQsACJTwB.ZLkRominQCKUBwwrVSwFZLKUpyk:
				return hqfKvIlYBoSnKeJAlDwvdApVFZRQ[num].jwtKTNmXDNczkwosndKDKQSNLbM;
			case TbaDHFJPbFybdlSowNbrQsACJTwB.qhdlbmvVPGSkmbKUCbanVffQNKm:
				return ZsJwmmnyhzMypUnEhnDEeGWiNEc[num].jwtKTNmXDNczkwosndKDKQSNLbM;
			default:
				return -1;
			}
		}

		private int SCpnBACyPaMEZzDOuTHpIMjDLmL(int P_0)
		{
			int count = hqfKvIlYBoSnKeJAlDwvdApVFZRQ.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					int num2;
					if (hqfKvIlYBoSnKeJAlDwvdApVFZRQ[num].VykOoYENAAVycnKptyohgAtorFA == P_0)
					{
						num2 = 1980868444;
					}
					else
					{
						num++;
						num2 = 1980868445;
					}
					while (true)
					{
						switch (num2 ^ 0x7611A75C)
						{
						case 2:
							num2 = 1980868447;
							continue;
						case 3:
							break;
						case 0:
							return SCpnBACyPaMEZzDOuTHpIMjDLmL();
						default:
							goto end_IL_0032;
						}
						break;
					}
					continue;
					end_IL_0032:
					break;
				}
			}
			return P_0;
		}

		private int SCpnBACyPaMEZzDOuTHpIMjDLmL()
		{
			int count = hqfKvIlYBoSnKeJAlDwvdApVFZRQ.Count;
			int num = 0;
			int num3 = default(int);
			bool flag = default(bool);
			while (true)
			{
				int num2 = -2113436692;
				while (true)
				{
					switch (num2 ^ -2113436694)
					{
					case 4:
						break;
					case 7:
					{
						int num5;
						if (num3 >= count)
						{
							num2 = -2113436695;
							num5 = num2;
						}
						else
						{
							num2 = -2113436696;
							num5 = num2;
						}
						continue;
					}
					case 2:
					{
						int num4;
						if (hqfKvIlYBoSnKeJAlDwvdApVFZRQ[num3].VykOoYENAAVycnKptyohgAtorFA != num)
						{
							num2 = -2113436689;
							num4 = num2;
						}
						else
						{
							num2 = -2113436693;
							num4 = num2;
						}
						continue;
					}
					case 1:
						flag = true;
						num2 = -2113436694;
						continue;
					case 6:
						flag = false;
						num3 = 0;
						num2 = -2113436691;
						continue;
					case 5:
						num3++;
						num2 = -2113436691;
						continue;
					case 0:
						num2 = -2113436695;
						continue;
					default:
						if (!flag)
						{
							return num;
						}
						num++;
						goto case 6;
					}
					break;
				}
			}
		}
	}

	private class GbYDRZJxOYBLNwxlBAhGhqYBwmIC : IInputManagerJoystickPublic
	{
		private IInputManagerJoystickPublic bBSBxriglpnOAawkfBpKCJgyYmdh;

		private int vZOtqRXMwWAPeGEwZAMHlibtjHuN;

		public int rewiredId => bBSBxriglpnOAawkfBpKCJgyYmdh.rewiredId;

		public int inputManagerId => vZOtqRXMwWAPeGEwZAMHlibtjHuN;

		public string name => bBSBxriglpnOAawkfBpKCJgyYmdh.name;

		public long? systemId => bBSBxriglpnOAawkfBpKCJgyYmdh.systemId;

		public int unityId => bBSBxriglpnOAawkfBpKCJgyYmdh.unityId;

		public Guid instanceGuid => bBSBxriglpnOAawkfBpKCJgyYmdh.instanceGuid;

		public Guid persistentGuid => instanceGuid;

		public Controller.Extension extension => bBSBxriglpnOAawkfBpKCJgyYmdh.extension;

		public GbYDRZJxOYBLNwxlBAhGhqYBwmIC(IInputManagerJoystickPublic sourceJoystick, int bridgeJoystickId)
		{
			bBSBxriglpnOAawkfBpKCJgyYmdh = sourceJoystick;
			vZOtqRXMwWAPeGEwZAMHlibtjHuN = bridgeJoystickId;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			bBSBxriglpnOAawkfBpKCJgyYmdh.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			bBSBxriglpnOAawkfBpKCJgyYmdh.StopVibration();
		}
	}

	private sealed class ymyrTDDJpyEIvGhyWOXbdhjPyzbO
	{
		public int XZPCSfwdMWYhFdBcAnWAbWLNeEC;

		public int uQkANqFeoRBgDgIyMSFXjiYCzdge()
		{
			return XZPCSfwdMWYhFdBcAnWAbWLNeEC++;
		}
	}

	private const bool owSherELlFgjRpgnJahCUEjJEvia = false;

	private const bool cvahZkAhGZLBpTThEPbRJFMNTOXP = false;

	private const bool joiCbdELraFhRUbVGgSSgtBFHsUX = false;

	private const bool jBdWYmDxcMQwTgVbWkhLQqREDOLh = false;

	private const bool znzbhjakAyCPIItvhSsfqEiauxdb = false;

	private bool HazcIAHTRnlmnxxFXuxuOGyUDSkF;

	private object ZebHOTefeYfwayxMFceSxGqoJqmd;

	private IndexedDictionary<int, PlatformInputManager> dsLTarvPQvULTpBCmsFZZcvvGknk;

	private SIlXjjDDnZEDjhFtWDuKHMMICuY PgkpyuulqjEjpsUYtOFNEeUbjTF;

	private Action<int, ControllerDataUpdater> NvqaCuAwnRtIQraiMLVUyKxjukSM;

	private WindowsStandalonePrimaryInputSource YwqFTEudJRFCEHtnzmnVMUBroGTh;

	private bool cMjYVbiiXrBAmFldsNsUEuybSPgo;

	private PlatformInputManager PQcgLBxnvdIehjQoFUyCgOAdLDX;

	private bool BTUgMKJQNhPSmvoHPpdbWkpMTKX;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> qnewRYFCzYevHqfqyatlbQmZFOFg;

	private Func<int> faTqYhfgwuuVCbrIpddTkYZQAdf;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = YksGHYKteMuhDXToEsEFZvCVfCJ.TOSovleqisnhzPjJGwkjkPYeAEs();
			IntPtr intPtr2 = YksGHYKteMuhDXToEsEFZvCVfCJ.AUFWjjIkwWerQKSUjdsylUuMVyM();
			return intPtr2 != IntPtr.Zero && intPtr == intPtr2;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount => PgkpyuulqjEjpsUYtOFNEeUbjTF.deviceCount;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => PQcgLBxnvdIehjQoFUyCgOAdLDX;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => PQcgLBxnvdIehjQoFUyCgOAdLDX.inputSource;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			if (PQcgLBxnvdIehjQoFUyCgOAdLDX == null)
			{
				return InputSource.None;
			}
			return PQcgLBxnvdIehjQoFUyCgOAdLDX.inputSourceType;
		}
	}

	public sYGArRodgBwPmjtbrSXkcLAheAe(ConfigVars configVars, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		YwqFTEudJRFCEHtnzmnVMUBroGTh = configVars.windowsStandalonePrimaryInputSource;
		cMjYVbiiXrBAmFldsNsUEuybSPgo = configVars.useXInput;
		qnewRYFCzYevHqfqyatlbQmZFOFg = getHardwareJoystickMap_InputManager;
		faTqYhfgwuuVCbrIpddTkYZQAdf = getNewJoystickId;
		bool flag = false;
		dsLTarvPQvULTpBCmsFZZcvvGknk = new IndexedDictionary<int, PlatformInputManager>();
		if (UnityTools.platform != Platform.WindowsAppStore)
		{
			try
			{
				kpfkMpAFolETeEcXIDaJMkIYftRp.XcqbVqdtLKNrEHBlIGziwanWbzsI();
				pdummRpNhhHcNABVOjSMuAZyhxoE pdummRpNhhHcNABVOjSMuAZyhxoE2 = (pdummRpNhhHcNABVOjSMuAZyhxoE)(ZebHOTefeYfwayxMFceSxGqoJqmd = new pdummRpNhhHcNABVOjSMuAZyhxoE());
				bool flag2 = false;
				if (YwqFTEudJRFCEHtnzmnVMUBroGTh == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag2 = efWHKUIPGZbNsjYrbqTVpcmcqGJX(configVars, pdummRpNhhHcNABVOjSMuAZyhxoE2);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag2 = GxxvpOGdkQAsxVaawpeZQpRKpGz(configVars, pdummRpNhhHcNABVOjSMuAZyhxoE2);
						if (flag2)
						{
							configVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							YwqFTEudJRFCEHtnzmnVMUBroGTh = configVars.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized!");
						}
					}
				}
				else if (YwqFTEudJRFCEHtnzmnVMUBroGTh == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag2 = GxxvpOGdkQAsxVaawpeZQpRKpGz(configVars, pdummRpNhhHcNABVOjSMuAZyhxoE2);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag2 = efWHKUIPGZbNsjYrbqTVpcmcqGJX(configVars, pdummRpNhhHcNABVOjSMuAZyhxoE2);
						if (flag2)
						{
							configVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							YwqFTEudJRFCEHtnzmnVMUBroGTh = configVars.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized!");
						}
					}
				}
				else if (YwqFTEudJRFCEHtnzmnVMUBroGTh == WindowsStandalonePrimaryInputSource.XInput)
				{
					flag2 = CAcNlmtcJXLxepdJHWXneiBbNqM(configVars, false);
					if (flag2)
					{
						NeuEksErMxQIwJSXoUiUTHErOere(configVars, pdummRpNhhHcNABVOjSMuAZyhxoE2);
					}
					flag = flag2;
				}
				if (!flag2)
				{
					throw new Exception();
				}
				pdummRpNhhHcNABVOjSMuAZyhxoE2.DeviceConnectedEvent += GgXfMaoObWdERRtWXCcIyPUMeLYj;
				pdummRpNhhHcNABVOjSMuAZyhxoE2.DeviceDisconnectedEvent += MlyVJCoPnJrJhhhyzXpmlLbwNCT;
				for (int i = 0; i < dsLTarvPQvULTpBCmsFZZcvvGknk.Count; i++)
				{
					PlatformInputManager platformInputManager = dsLTarvPQvULTpBCmsFZZcvvGknk[i];
					platformInputManager.DeviceConnectedEvent += OaEjwDVgDalUXiYllPhmBmfuTUy;
					platformInputManager.DeviceDisconnectedEvent += zTViQmMfmoGXhCukleRtjVGVUlr;
					platformInputManager.UpdateControllerInfoEvent += tZMdUQGPzxVMGOFsUUdFIcTiywI;
				}
			}
			catch (Exception ex)
			{
				OnDestroy();
				Logger.LogWarning("Unable to initialize input source!\n" + ex.Message);
				throw;
			}
		}
		if (!flag)
		{
			CAcNlmtcJXLxepdJHWXneiBbNqM(configVars, true);
		}
		NvqaCuAwnRtIQraiMLVUyKxjukSM = UpdateControllerData;
	}

	private bool efWHKUIPGZbNsjYrbqTVpcmcqGJX(ConfigVars P_0, pdummRpNhhHcNABVOjSMuAZyhxoE P_1)
	{
		KQMPeTwPTsLuGhkUNxqXEROjtXA kQMPeTwPTsLuGhkUNxqXEROjtXA = null;
		kPcCNnzXGURfWeRfxqXeAVfOFYx kPcCNnzXGURfWeRfxqXeAVfOFYx2 = null;
		try
		{
			kQMPeTwPTsLuGhkUNxqXEROjtXA = new KQMPeTwPTsLuGhkUNxqXEROjtXA(P_0, useXInput: false, null, null, handleJoysticks: false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			while (true)
			{
				int num = -1418231196;
				while (true)
				{
					switch (num ^ -1418231195)
					{
					case 0:
						break;
					case 1:
						goto IL_003f;
					default:
						dsLTarvPQvULTpBCmsFZZcvvGknk.Add(1, PQcgLBxnvdIehjQoFUyCgOAdLDX);
						P_1.WindowFocusEvent += kQMPeTwPTsLuGhkUNxqXEROjtXA.MdnhOzkfliRLqCXkAeVecbVgXle;
						return true;
					}
					break;
					IL_003f:
					kPcCNnzXGURfWeRfxqXeAVfOFYx2 = (kPcCNnzXGURfWeRfxqXeAVfOFYx)(PQcgLBxnvdIehjQoFUyCgOAdLDX = new kPcCNnzXGURfWeRfxqXeAVfOFYx(P_0.updateLoop, cMjYVbiiXrBAmFldsNsUEuybSPgo, ((pdummRpNhhHcNABVOjSMuAZyhxoE)ZebHOTefeYfwayxMFceSxGqoJqmd).windowHandle, qnewRYFCzYevHqfqyatlbQmZFOFg, faTqYhfgwuuVCbrIpddTkYZQAdf));
					dsLTarvPQvULTpBCmsFZZcvvGknk.Add(5, kQMPeTwPTsLuGhkUNxqXEROjtXA);
					num = -1418231193;
				}
			}
		}
		catch (Exception)
		{
			if (kPcCNnzXGURfWeRfxqXeAVfOFYx2 != null)
			{
				kPcCNnzXGURfWeRfxqXeAVfOFYx2.OnDestroy();
				goto IL_00ba;
			}
			goto IL_00dc;
			IL_00dc:
			int num2;
			int num3;
			if (kQMPeTwPTsLuGhkUNxqXEROjtXA != null)
			{
				num2 = -1418231194;
				num3 = num2;
			}
			else
			{
				num2 = -1418231193;
				num3 = num2;
			}
			goto IL_00bf;
			IL_00ba:
			num2 = -1418231196;
			goto IL_00bf;
			IL_00bf:
			while (true)
			{
				switch (num2 ^ -1418231195)
				{
				case 0:
					break;
				case 1:
					goto IL_00dc;
				case 3:
					kQMPeTwPTsLuGhkUNxqXEROjtXA.OnDestroy();
					num2 = -1418231193;
					continue;
				default:
					Logger.LogWarning("Unable to initialize Direct Input! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
					goto end_IL_00b0;
				}
				break;
			}
			goto IL_00ba;
			end_IL_00b0:;
		}
		return false;
	}

	private bool GxxvpOGdkQAsxVaawpeZQpRKpGz(ConfigVars P_0, pdummRpNhhHcNABVOjSMuAZyhxoE P_1)
	{
		KQMPeTwPTsLuGhkUNxqXEROjtXA kQMPeTwPTsLuGhkUNxqXEROjtXA = null;
		try
		{
			kQMPeTwPTsLuGhkUNxqXEROjtXA = new KQMPeTwPTsLuGhkUNxqXEROjtXA(P_0, P_0.useXInput, qnewRYFCzYevHqfqyatlbQmZFOFg, faTqYhfgwuuVCbrIpddTkYZQAdf, handleJoysticks: true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			dsLTarvPQvULTpBCmsFZZcvvGknk.Add(5, kQMPeTwPTsLuGhkUNxqXEROjtXA);
			P_1.WindowFocusEvent += kQMPeTwPTsLuGhkUNxqXEROjtXA.MdnhOzkfliRLqCXkAeVecbVgXle;
			PQcgLBxnvdIehjQoFUyCgOAdLDX = kQMPeTwPTsLuGhkUNxqXEROjtXA;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			if (kQMPeTwPTsLuGhkUNxqXEROjtXA != null)
			{
				while (true)
				{
					IL_0066:
					int num = -1857016563;
					while (true)
					{
						switch (num ^ -1857016561)
						{
						case 0:
							break;
						default:
							goto end_IL_006b;
						case 2:
							goto IL_0084;
						case 1:
							goto end_IL_006b;
						}
						goto IL_0066;
						IL_0084:
						kQMPeTwPTsLuGhkUNxqXEROjtXA.OnDestroy();
						num = -1857016562;
						continue;
						end_IL_006b:
						break;
					}
					break;
				}
			}
		}
		return false;
	}

	private bool NeuEksErMxQIwJSXoUiUTHErOere(ConfigVars P_0, pdummRpNhhHcNABVOjSMuAZyhxoE P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = default(bool);
		bool result = default(bool);
		while (true)
		{
			int num = 649915321;
			while (true)
			{
				switch (num ^ 0x26BCEBBA)
				{
				case 0:
					break;
				case 3:
					platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
					num = 649915320;
					continue;
				case 2:
				{
					if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
					{
						num = 649915323;
						continue;
					}
					KQMPeTwPTsLuGhkUNxqXEROjtXA kQMPeTwPTsLuGhkUNxqXEROjtXA = null;
					try
					{
						kQMPeTwPTsLuGhkUNxqXEROjtXA = new KQMPeTwPTsLuGhkUNxqXEROjtXA(P_0, useXInput: false, null, null, handleJoysticks: false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
						while (true)
						{
							IL_005b:
							int num2 = 649915323;
							while (true)
							{
								switch (num2 ^ 0x26BCEBBA)
								{
								case 2:
									break;
								case 1:
									goto IL_0079;
								default:
									dsLTarvPQvULTpBCmsFZZcvvGknk.Add(5, kQMPeTwPTsLuGhkUNxqXEROjtXA);
									result = true;
									goto end_IL_0060;
								}
								goto IL_005b;
								IL_0079:
								P_1.WindowFocusEvent += kQMPeTwPTsLuGhkUNxqXEROjtXA.MdnhOzkfliRLqCXkAeVecbVgXle;
								num2 = 649915322;
								continue;
								end_IL_0060:
								break;
							}
							break;
						}
					}
					catch
					{
						Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
						if (kQMPeTwPTsLuGhkUNxqXEROjtXA != null)
						{
							goto IL_00b1;
						}
						goto IL_00e0;
						IL_00b1:
						int num3 = 649915320;
						goto IL_00b6;
						IL_00b6:
						while (true)
						{
							switch (num3 ^ 0x26BCEBBA)
							{
							case 0:
								break;
							default:
								goto end_IL_00a3;
							case 2:
								kQMPeTwPTsLuGhkUNxqXEROjtXA.OnDestroy();
								num3 = 649915321;
								continue;
							case 3:
								goto IL_00e0;
							case 1:
								goto end_IL_00a3;
							}
							break;
						}
						goto IL_00b1;
						IL_00e0:
						kQMPeTwPTsLuGhkUNxqXEROjtXA = null;
						result = false;
						num3 = 649915323;
						goto IL_00b6;
						end_IL_00a3:;
					}
					return result;
				}
				default:
					return false;
				}
				break;
			}
		}
	}

	private bool CAcNlmtcJXLxepdJHWXneiBbNqM(ConfigVars P_0, bool P_1)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool useXInput = P_0.useXInput;
		bool flag = PQcgLBxnvdIehjQoFUyCgOAdLDX == null;
		bool flag2 = default(bool);
		bool flag3 = default(bool);
		zzOqSwMfghlPxHdUtRXPrOVahKl zzOqSwMfghlPxHdUtRXPrOVahKl2 = default(zzOqSwMfghlPxHdUtRXPrOVahKl);
		bool result = default(bool);
		int num4 = default(int);
		while (true)
		{
			int num = 1408963315;
			while (true)
			{
				bool num5;
				switch (num ^ 0x53FB12F2)
				{
				case 2:
					break;
				case 1:
					num5 = useXInput || flag || ReInput.currentPlatform == Platform.WindowsAppStore;
					goto IL_0047;
				default:
					if (!flag2)
					{
						return false;
					}
					try
					{
						if (flag3)
						{
							goto IL_005e;
						}
						goto IL_00d0;
						IL_005e:
						int num2 = 1408963315;
						goto IL_0063;
						IL_0063:
						while (true)
						{
							switch (num2 ^ 0x53FB12F2)
							{
							case 3:
								break;
							default:
								goto end_IL_005a;
							case 1:
							{
								ymyrTDDJpyEIvGhyWOXbdhjPyzbO ymyrTDDJpyEIvGhyWOXbdhjPyzbO2 = new ymyrTDDJpyEIvGhyWOXbdhjPyzbO();
								ymyrTDDJpyEIvGhyWOXbdhjPyzbO2.XZPCSfwdMWYhFdBcAnWAbWLNeEC = 0;
								zzOqSwMfghlPxHdUtRXPrOVahKl value = new zzOqSwMfghlPxHdUtRXPrOVahKl(flag3, updateLoop, qnewRYFCzYevHqfqyatlbQmZFOFg, ymyrTDDJpyEIvGhyWOXbdhjPyzbO2.uQkANqFeoRBgDgIyMSFXjiYCzdge);
								dsLTarvPQvULTpBCmsFZZcvvGknk.Add(2, value);
								num2 = 1408963318;
								continue;
							}
							case 0:
								goto IL_00d0;
							case 6:
								zzOqSwMfghlPxHdUtRXPrOVahKl2.DeviceDisconnectedEvent += zTViQmMfmoGXhCukleRtjVGVUlr;
								zzOqSwMfghlPxHdUtRXPrOVahKl2.UpdateControllerInfoEvent += tZMdUQGPzxVMGOFsUUdFIcTiywI;
								num2 = 1408963318;
								continue;
							case 5:
								goto IL_012b;
							case 4:
								goto IL_0159;
							case 2:
								goto end_IL_005a;
							}
							break;
						}
						goto IL_005e;
						IL_00d0:
						zzOqSwMfghlPxHdUtRXPrOVahKl2 = new zzOqSwMfghlPxHdUtRXPrOVahKl(flag3, updateLoop, qnewRYFCzYevHqfqyatlbQmZFOFg, faTqYhfgwuuVCbrIpddTkYZQAdf);
						if (flag)
						{
							PQcgLBxnvdIehjQoFUyCgOAdLDX = zzOqSwMfghlPxHdUtRXPrOVahKl2;
							num2 = 1408963319;
							goto IL_0063;
						}
						goto IL_012b;
						IL_012b:
						dsLTarvPQvULTpBCmsFZZcvvGknk.Add(2, zzOqSwMfghlPxHdUtRXPrOVahKl2);
						if (P_1)
						{
							zzOqSwMfghlPxHdUtRXPrOVahKl2.DeviceConnectedEvent += OaEjwDVgDalUXiYllPhmBmfuTUy;
							num2 = 1408963316;
							goto IL_0063;
						}
						goto IL_0159;
						IL_0159:
						result = true;
						num2 = 1408963312;
						goto IL_0063;
						end_IL_005a:;
					}
					catch (Exception)
					{
						while (true)
						{
							IL_016c:
							int num3 = 1408963315;
							while (true)
							{
								switch (num3 ^ 0x53FB12F2)
								{
								case 0:
									break;
								case 7:
									num3 = 1408963318;
									continue;
								case 8:
									num4 = 0;
									num3 = 1408963317;
									continue;
								case 5:
									if (!flag3)
									{
										Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + YwqFTEudJRFCEHtnzmnVMUBroGTh.ToString() + " instead. The L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
										P_0.useXInput = false;
										num3 = 1408963322;
										continue;
									}
									goto default;
								case 1:
									if (flag)
									{
										OnDestroy();
										Logger.LogWarning("Unable to initialize XInput!");
										throw;
									}
									goto case 5;
								case 3:
									num4++;
									num3 = 1408963318;
									continue;
								case 4:
									if (num4 >= dsLTarvPQvULTpBCmsFZZcvvGknk.Count)
									{
										Logger.LogWarning("Unable to initialize XInput! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
										num3 = 1408963312;
										continue;
									}
									goto case 6;
								case 6:
									if (dsLTarvPQvULTpBCmsFZZcvvGknk[num4] != null && dsLTarvPQvULTpBCmsFZZcvvGknk[num4] is pBqgKWLeCLFlqaXbtEoODTfhYyUL pBqgKWLeCLFlqaXbtEoODTfhYyUL2)
									{
										pBqgKWLeCLFlqaXbtEoODTfhYyUL2.useXInput = false;
										num3 = 1408963313;
										continue;
									}
									goto case 3;
								default:
									result = false;
									goto end_IL_0171;
								}
								goto IL_016c;
								continue;
								end_IL_0171:
								break;
							}
							break;
						}
					}
					return result;
				}
				break;
				IL_0047:
				flag2 = num5;
				flag3 = false;
				num = 1408963314;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		HazcIAHTRnlmnxxFXuxuOGyUDSkF = true;
		int num2 = default(int);
		while (true)
		{
			int num = -2046459320;
			while (true)
			{
				switch (num ^ -2046459318)
				{
				case 3:
					break;
				case 2:
					PgkpyuulqjEjpsUYtOFNEeUbjTF = new SIlXjjDDnZEDjhFtWDuKHMMICuY();
					num = -2046459314;
					continue;
				case 5:
					dsLTarvPQvULTpBCmsFZZcvvGknk[num2].Initialize();
					num = -2046459317;
					continue;
				case 4:
					num2 = 0;
					num = -2046459318;
					continue;
				case 1:
					num2++;
					num = -2046459318;
					continue;
				default:
					if (num2 >= dsLTarvPQvULTpBCmsFZZcvvGknk.Count)
					{
						return;
					}
					goto case 5;
				}
				break;
			}
		}
	}

	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		int num = 0;
		while (num < dsLTarvPQvULTpBCmsFZZcvvGknk.Count)
		{
			while (true)
			{
				dsLTarvPQvULTpBCmsFZZcvvGknk[num].Update(currentUpdateLoop);
				num++;
				int num2 = -1103481511;
				while (true)
				{
					switch (num2 ^ -1103481511)
					{
					case 2:
						num2 = -1103481512;
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

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		int num = dsLTarvPQvULTpBCmsFZZcvvGknk.Count - 1;
		while (true)
		{
			IL_004e:
			int num2;
			if (num < 0)
			{
				if (ZebHOTefeYfwayxMFceSxGqoJqmd == null)
				{
					break;
				}
				((pdummRpNhhHcNABVOjSMuAZyhxoE)ZebHOTefeYfwayxMFceSxGqoJqmd).jywbDvKREmxpuklJqfPGdyOxlFzI();
				ZebHOTefeYfwayxMFceSxGqoJqmd = null;
				num2 = 177736635;
				goto IL_0015;
			}
			goto IL_0032;
			IL_0032:
			dsLTarvPQvULTpBCmsFZZcvvGknk[num].OnDestroy();
			num--;
			num2 = 177736632;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0xA980BBB)
				{
				case 2:
					num2 = 177736634;
					continue;
				case 1:
					break;
				case 3:
					goto IL_004e;
				default:
					goto end_IL_004e;
				}
				break;
			}
			goto IL_0032;
			continue;
			end_IL_004e:
			break;
		}
		kpfkMpAFolETeEcXIDaJMkIYftRp.WYoEhOBxiSjIYKwbsCHdGOUBXDbi();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return NvqaCuAwnRtIQraiMLVUyKxjukSM;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		dsLTarvPQvULTpBCmsFZZcvvGknk.GetValue((int)data.source).UpdateControllerData(PgkpyuulqjEjpsUYtOFNEeUbjTF.swfGqWYjosOZspSQopxMMEMsoPv(controllerId, data.source, SIlXjjDDnZEDjhFtWDuKHMMICuY.TbaDHFJPbFybdlSowNbrQsACJTwB.ZLkRominQCKUBwwrVSwFZLKUpyk), data);
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
		while (num < dsLTarvPQvULTpBCmsFZZcvvGknk.Count)
		{
			while (true)
			{
				IUnifiedMouseSource unifiedMouseSource = dsLTarvPQvULTpBCmsFZZcvvGknk[num].GetUnifiedMouseSource();
				int num2 = 1661501387;
				while (true)
				{
					switch (num2 ^ 0x63087FCB)
					{
					case 2:
						num2 = 1661501386;
						continue;
					case 1:
						break;
					case 0:
						goto IL_0043;
					case 3:
						return unifiedMouseSource;
					default:
						goto end_IL_002a;
					}
					break;
					IL_0043:
					if (unifiedMouseSource != null)
					{
						num2 = 1661501384;
						continue;
					}
					num++;
					num2 = 1661501391;
				}
				continue;
				end_IL_002a:
				break;
			}
		}
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		int num = 0;
		IUnifiedKeyboardSource unifiedKeyboardSource = default(IUnifiedKeyboardSource);
		while (true)
		{
			int num2 = 1564939919;
			while (true)
			{
				switch (num2 ^ 0x5D47168A)
				{
				case 2:
					break;
				case 5:
					num2 = 1564939915;
					continue;
				case 1:
				{
					int num3;
					if (num >= dsLTarvPQvULTpBCmsFZZcvvGknk.Count)
					{
						num2 = 1564939918;
						num3 = num2;
					}
					else
					{
						num2 = 1564939914;
						num3 = num2;
					}
					continue;
				}
				case 3:
					return unifiedKeyboardSource;
				case 0:
					unifiedKeyboardSource = dsLTarvPQvULTpBCmsFZZcvvGknk[num].GetUnifiedKeyboardSource();
					if (unifiedKeyboardSource == null)
					{
						num++;
						num2 = 1564939915;
					}
					else
					{
						num2 = 1564939913;
					}
					continue;
				default:
					return null;
				}
				break;
			}
		}
	}

	private void OaEjwDVgDalUXiYllPhmBmfuTUy(BridgedController P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_004c;
		IL_0003:
		int num = 1170095935;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num ^ 0x45BE3F3C)
			{
			case 4:
				break;
			default:
				return;
			case 3:
				return;
			case 1:
				if (_DeviceConnectedEvent != null)
				{
					_DeviceConnectedEvent(P_0);
					num = 1170095934;
					continue;
				}
				return;
			case 0:
				goto IL_004c;
			case 2:
				return;
			}
			break;
		}
		goto IL_0003;
		IL_004c:
		PgkpyuulqjEjpsUYtOFNEeUbjTF.CkkGhQIeIZDBuzNDuaEbtdiidPQF(P_0);
		num = 1170095933;
		goto IL_0008;
	}

	private void zTViQmMfmoGXhCukleRtjVGVUlr(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		while (true)
		{
			PgkpyuulqjEjpsUYtOFNEeUbjTF.vAnDChAOoomGtjTRhiWRhyxrvoZo(P_0);
			if (_DeviceDisconnectedEvent == null)
			{
				break;
			}
			_DeviceDisconnectedEvent(P_0);
			int num = 2143800123;
			while (true)
			{
				switch (num ^ 0x7FC7CB3A)
				{
				case 0:
					goto IL_0004;
				default:
					return;
				case 2:
					break;
				case 1:
					return;
				}
				break;
				IL_0004:
				num = 2143800120;
			}
		}
	}

	private void GgXfMaoObWdERRtWXCcIyPUMeLYj(EventArgs P_0)
	{
		if (!HazcIAHTRnlmnxxFXuxuOGyUDSkF)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = -476565330;
			while (true)
			{
				switch (num2 ^ -476565330)
				{
				case 3:
					num2 = -476565329;
					continue;
				case 1:
					break;
				case 2:
					dsLTarvPQvULTpBCmsFZZcvvGknk[num].SystemDeviceConnected();
					num++;
					num2 = -476565330;
					continue;
				default:
					if (num >= dsLTarvPQvULTpBCmsFZZcvvGknk.Count)
					{
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	private void MlyVJCoPnJrJhhhyzXpmlLbwNCT(EventArgs P_0)
	{
		if (!HazcIAHTRnlmnxxFXuxuOGyUDSkF)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = -568278111;
			while (true)
			{
				switch (num2 ^ -568278110)
				{
				case 5:
					num2 = -568278106;
					continue;
				default:
					return;
				case 4:
					break;
				case 2:
				{
					int num3;
					if (num >= dsLTarvPQvULTpBCmsFZZcvvGknk.Count)
					{
						num2 = -568278110;
						num3 = num2;
					}
					else
					{
						num2 = -568278109;
						num3 = num2;
					}
					continue;
				}
				case 1:
					dsLTarvPQvULTpBCmsFZZcvvGknk[num].SystemDeviceDisconnected();
					num++;
					num2 = -568278112;
					continue;
				case 3:
					num2 = -568278112;
					continue;
				case 0:
					return;
				}
				break;
			}
		}
	}

	private void tZMdUQGPzxVMGOFsUUdFIcTiywI(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null)
		{
			if (P_0.sourceJoystick == null)
			{
				goto IL_0011;
			}
			goto IL_00a2;
		}
		return;
		IL_0042:
		int num = default(int);
		SIlXjjDDnZEDjhFtWDuKHMMICuY.TbaDHFJPbFybdlSowNbrQsACJTwB tbaDHFJPbFybdlSowNbrQsACJTwB = default(SIlXjjDDnZEDjhFtWDuKHMMICuY.TbaDHFJPbFybdlSowNbrQsACJTwB);
		SIlXjjDDnZEDjhFtWDuKHMMICuY.gcJEzhNjqVxipTvmEIoICIDfPNr gcJEzhNjqVxipTvmEIoICIDfPNr = PgkpyuulqjEjpsUYtOFNEeUbjTF.BaBpEBAqcmoNeySgHAPRXPulVoo(num, tbaDHFJPbFybdlSowNbrQsACJTwB);
		int num2 = -932115238;
		goto IL_0016;
		IL_0011:
		num2 = -932115235;
		goto IL_0016;
		IL_0016:
		while (true)
		{
			switch (num2 ^ -932115236)
			{
			case 3:
				break;
			default:
				return;
			case 2:
				goto IL_0042;
			case 6:
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new GbYDRZJxOYBLNwxlBAhGhqYBwmIC(P_0.sourceJoystick, gcJEzhNjqVxipTvmEIoICIDfPNr.VykOoYENAAVycnKptyohgAtorFA)));
					num2 = -932115240;
					continue;
				}
				return;
			case 1:
				return;
			case 0:
				goto IL_0093;
			case 5:
				goto IL_00a2;
			case 4:
				return;
			}
			break;
		}
		goto IL_0011;
		IL_00a2:
		PgkpyuulqjEjpsUYtOFNEeUbjTF.HNQBfUDlCKtTIaiIwGKBfubiIzSu(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		tbaDHFJPbFybdlSowNbrQsACJTwB = SIlXjjDDnZEDjhFtWDuKHMMICuY.TbaDHFJPbFybdlSowNbrQsACJTwB.ZLkRominQCKUBwwrVSwFZLKUpyk;
		num = PgkpyuulqjEjpsUYtOFNEeUbjTF.LdeYUipgUiPUwsTmDLLPrLKDSEy(P_0.sourceJoystick.rewiredId, tbaDHFJPbFybdlSowNbrQsACJTwB);
		if (num < 0)
		{
			tbaDHFJPbFybdlSowNbrQsACJTwB = SIlXjjDDnZEDjhFtWDuKHMMICuY.TbaDHFJPbFybdlSowNbrQsACJTwB.qhdlbmvVPGSkmbKUCbanVffQNKm;
			num = PgkpyuulqjEjpsUYtOFNEeUbjTF.LdeYUipgUiPUwsTmDLLPrLKDSEy(P_0.sourceJoystick.rewiredId, tbaDHFJPbFybdlSowNbrQsACJTwB);
			num2 = -932115236;
			goto IL_0016;
		}
		goto IL_0093;
		IL_0093:
		if (num < 0)
		{
			return;
		}
		goto IL_0042;
	}
}
