using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class jXnpEMkJCbjCUjrZVTHyNrvpMaSB : PlatformInputManager, INativePlatformHelper
{
	private class MHskauzvoncDVsnkbArGgTkupIN
	{
		private class DhWCmLHGPLQxmyPWVOSKsQTgisq
		{
			public int WsRlOJISdsLrMfPqXptvzvrqEdy;

			public int qOMDSncdndJStuKdNXRcJfmTrwf;

			public int nsWuUeEARsbpuBNDuYrazAaqNZU;

			public InputSource EAHBveZYCGolVbLQhYJNUosGdcUg;

			public DhWCmLHGPLQxmyPWVOSKsQTgisq(int mapperId, int managerId, int id, InputSource source)
			{
				WsRlOJISdsLrMfPqXptvzvrqEdy = mapperId;
				qOMDSncdndJStuKdNXRcJfmTrwf = managerId;
				nsWuUeEARsbpuBNDuYrazAaqNZU = id;
				EAHBveZYCGolVbLQhYJNUosGdcUg = source;
			}

			public void EhlPnfprjfkehAbDLrDcQKRlXmc(int P_0)
			{
				qOMDSncdndJStuKdNXRcJfmTrwf = P_0;
			}

			public dptoUdeHtFoXlqJWYAtWyKYogQD QYqpfEAMICxOSguOhSZBWaRbARM()
			{
				return new dptoUdeHtFoXlqJWYAtWyKYogQD(WsRlOJISdsLrMfPqXptvzvrqEdy, qOMDSncdndJStuKdNXRcJfmTrwf, EAHBveZYCGolVbLQhYJNUosGdcUg);
			}

			public static int aMZEVnEVoiibldfyZSxNdxCZiply(DhWCmLHGPLQxmyPWVOSKsQTgisq P_0, DhWCmLHGPLQxmyPWVOSKsQTgisq P_1)
			{
				if (P_0.WsRlOJISdsLrMfPqXptvzvrqEdy < P_1.WsRlOJISdsLrMfPqXptvzvrqEdy)
				{
					return -1;
				}
				if (P_0.WsRlOJISdsLrMfPqXptvzvrqEdy > P_1.WsRlOJISdsLrMfPqXptvzvrqEdy)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct dptoUdeHtFoXlqJWYAtWyKYogQD
		{
			public int WsRlOJISdsLrMfPqXptvzvrqEdy;

			public int qOMDSncdndJStuKdNXRcJfmTrwf;

			public InputSource EAHBveZYCGolVbLQhYJNUosGdcUg;

			public dptoUdeHtFoXlqJWYAtWyKYogQD(int mapperId, int managerId, InputSource source)
			{
				WsRlOJISdsLrMfPqXptvzvrqEdy = mapperId;
				qOMDSncdndJStuKdNXRcJfmTrwf = managerId;
				EAHBveZYCGolVbLQhYJNUosGdcUg = source;
			}
		}

		public enum kPOdZCCVexwrShFGuJqyYnczwJzE
		{
			MyJyGjmCwusbhiQFfrODGPnUwSK = 0,
			zHIDjadCrmciEDxyqlukcUUEQZwZ = 1
		}

		private List<DhWCmLHGPLQxmyPWVOSKsQTgisq> EFqoihzfWPSyBSLPTqoSlFxiMFY;

		private List<DhWCmLHGPLQxmyPWVOSKsQTgisq> ucYrDJrrYCRbwamDBvXnNCfHTyj;

		public int deviceCount
		{
			get
			{
				return ucYrDJrrYCRbwamDBvXnNCfHTyj.Count;
			}
		}

		public MHskauzvoncDVsnkbArGgTkupIN()
		{
			ucYrDJrrYCRbwamDBvXnNCfHTyj = new List<DhWCmLHGPLQxmyPWVOSKsQTgisq>();
			EFqoihzfWPSyBSLPTqoSlFxiMFY = new List<DhWCmLHGPLQxmyPWVOSKsQTgisq>();
		}

		public void TRJCxVoiknCjOLIhEiXteqZiyHkL(BridgedController P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num2 = default(int);
			IInputManagerJoystickPublic sourceJoystick = default(IInputManagerJoystickPublic);
			DhWCmLHGPLQxmyPWVOSKsQTgisq dhWCmLHGPLQxmyPWVOSKsQTgisq = default(DhWCmLHGPLQxmyPWVOSKsQTgisq);
			int wsRlOJISdsLrMfPqXptvzvrqEdy = default(int);
			while (true)
			{
				int num = 263707131;
				while (true)
				{
					switch (num ^ 0xFB7D9FA)
					{
					case 9:
						break;
					case 1:
					{
						int num3;
						if (P_0.sourceJoystick == null)
						{
							num = 263707132;
							num3 = num;
						}
						else
						{
							num = 263707128;
							num3 = num;
						}
						continue;
					}
					case 0:
						if (num2 >= 0)
						{
							dhWCmLHGPLQxmyPWVOSKsQTgisq = ucYrDJrrYCRbwamDBvXnNCfHTyj[num2];
							dhWCmLHGPLQxmyPWVOSKsQTgisq.EhlPnfprjfkehAbDLrDcQKRlXmc(sourceJoystick.inputManagerId);
							P_0.sourceJoystick = new ZvuwUOrXXrMvwrWffUtgIopumQS(sourceJoystick, dhWCmLHGPLQxmyPWVOSKsQTgisq.WsRlOJISdsLrMfPqXptvzvrqEdy);
							return;
						}
						goto case 4;
					case 8:
						dhWCmLHGPLQxmyPWVOSKsQTgisq = new DhWCmLHGPLQxmyPWVOSKsQTgisq(DxOTPLWfRAutmvoFGWjuDWfHiBt(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
						num = 263707135;
						continue;
					case 7:
						dhWCmLHGPLQxmyPWVOSKsQTgisq.WsRlOJISdsLrMfPqXptvzvrqEdy = wsRlOJISdsLrMfPqXptvzvrqEdy;
						num = 263707135;
						continue;
					case 4:
					{
						num2 = KITOQlhBKIDpAjmntFCXekgANGKd(sourceJoystick.rewiredId, kPOdZCCVexwrShFGuJqyYnczwJzE.zHIDjadCrmciEDxyqlukcUUEQZwZ);
						int num4;
						if (num2 >= 0)
						{
							num = 263707120;
							num4 = num;
						}
						else
						{
							num = 263707122;
							num4 = num;
						}
						continue;
					}
					case 5:
						P_0.sourceJoystick = new ZvuwUOrXXrMvwrWffUtgIopumQS(sourceJoystick, dhWCmLHGPLQxmyPWVOSKsQTgisq.WsRlOJISdsLrMfPqXptvzvrqEdy);
						num = 263707129;
						continue;
					case 3:
						ucYrDJrrYCRbwamDBvXnNCfHTyj.Add(dhWCmLHGPLQxmyPWVOSKsQTgisq);
						num = 263707121;
						continue;
					case 2:
						sourceJoystick = P_0.sourceJoystick;
						num2 = KITOQlhBKIDpAjmntFCXekgANGKd(sourceJoystick.rewiredId, kPOdZCCVexwrShFGuJqyYnczwJzE.MyJyGjmCwusbhiQFfrODGPnUwSK);
						num = 263707130;
						continue;
					case 6:
						return;
					case 10:
						dhWCmLHGPLQxmyPWVOSKsQTgisq = EFqoihzfWPSyBSLPTqoSlFxiMFY[num2];
						EFqoihzfWPSyBSLPTqoSlFxiMFY.RemoveAt(num2);
						wsRlOJISdsLrMfPqXptvzvrqEdy = DxOTPLWfRAutmvoFGWjuDWfHiBt(dhWCmLHGPLQxmyPWVOSKsQTgisq.WsRlOJISdsLrMfPqXptvzvrqEdy);
						num = 263707133;
						continue;
					default:
						ucYrDJrrYCRbwamDBvXnNCfHTyj.Sort(DhWCmLHGPLQxmyPWVOSKsQTgisq.aMZEVnEVoiibldfyZSxNdxCZiply);
						return;
					}
					break;
				}
			}
		}

		public void eoMMqoWhWSqtFZaxEABBffIpwcd(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num = KITOQlhBKIDpAjmntFCXekgANGKd(P_0.rewiredId, kPOdZCCVexwrShFGuJqyYnczwJzE.MyJyGjmCwusbhiQFfrODGPnUwSK);
				int num2;
				int num3;
				if (num < 0)
				{
					num2 = -660484812;
					num3 = num2;
				}
				else
				{
					num2 = -660484816;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -660484815)
					{
					case 2:
						num2 = -660484814;
						continue;
					default:
						return;
					case 3:
						break;
					case 5:
						Logger.LogError("Device was not in connected list! Cannot remove!");
						num2 = -660484811;
						continue;
					case 4:
						return;
					case 1:
					{
						DhWCmLHGPLQxmyPWVOSKsQTgisq item = ucYrDJrrYCRbwamDBvXnNCfHTyj[num];
						ucYrDJrrYCRbwamDBvXnNCfHTyj.RemoveAt(num);
						EFqoihzfWPSyBSLPTqoSlFxiMFY.Add(item);
						num2 = -660484815;
						continue;
					}
					case 0:
						return;
					}
					break;
				}
			}
		}

		public void INjahPzTowmdiaFiKDLZIfIAanqf(int P_0, int P_1)
		{
			int num = KITOQlhBKIDpAjmntFCXekgANGKd(P_0, kPOdZCCVexwrShFGuJqyYnczwJzE.MyJyGjmCwusbhiQFfrODGPnUwSK);
			DhWCmLHGPLQxmyPWVOSKsQTgisq dhWCmLHGPLQxmyPWVOSKsQTgisq;
			if (num >= 0)
			{
				dhWCmLHGPLQxmyPWVOSKsQTgisq = ucYrDJrrYCRbwamDBvXnNCfHTyj[num];
				goto IL_001a;
			}
			goto IL_004b;
			IL_004b:
			num = KITOQlhBKIDpAjmntFCXekgANGKd(P_0, kPOdZCCVexwrShFGuJqyYnczwJzE.zHIDjadCrmciEDxyqlukcUUEQZwZ);
			int num2;
			if (num >= 0)
			{
				dhWCmLHGPLQxmyPWVOSKsQTgisq = EFqoihzfWPSyBSLPTqoSlFxiMFY[num];
				dhWCmLHGPLQxmyPWVOSKsQTgisq.EhlPnfprjfkehAbDLrDcQKRlXmc(P_1);
				num2 = -1971760537;
				goto IL_001f;
			}
			return;
			IL_001a:
			num2 = -1971760540;
			goto IL_001f;
			IL_001f:
			switch (num2 ^ -1971760538)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				dhWCmLHGPLQxmyPWVOSKsQTgisq.EhlPnfprjfkehAbDLrDcQKRlXmc(P_1);
				return;
			case 3:
				goto IL_004b;
			case 1:
				return;
			}
			goto IL_001a;
		}

		public bool WQGtezfxeyeFNomyFPdWcsNQBHr(int P_0, kPOdZCCVexwrShFGuJqyYnczwJzE P_1)
		{
			if (KITOQlhBKIDpAjmntFCXekgANGKd(P_0, P_1) < 0)
			{
				return false;
			}
			return true;
		}

		public int KITOQlhBKIDpAjmntFCXekgANGKd(int P_0, kPOdZCCVexwrShFGuJqyYnczwJzE P_1)
		{
			int count = default(int);
			int num = default(int);
			if (P_1 == kPOdZCCVexwrShFGuJqyYnczwJzE.MyJyGjmCwusbhiQFfrODGPnUwSK)
			{
				count = ucYrDJrrYCRbwamDBvXnNCfHTyj.Count;
				num = 0;
				goto IL_0011;
			}
			goto IL_0057;
			IL_0057:
			int count2 = default(int);
			int num2 = default(int);
			int num3;
			if (P_1 == kPOdZCCVexwrShFGuJqyYnczwJzE.zHIDjadCrmciEDxyqlukcUUEQZwZ)
			{
				count2 = EFqoihzfWPSyBSLPTqoSlFxiMFY.Count;
				num2 = 0;
				num3 = -68688103;
				goto IL_0016;
			}
			goto IL_00e2;
			IL_0011:
			num3 = -68688099;
			goto IL_0016;
			IL_0016:
			while (true)
			{
				switch (num3 ^ -68688097)
				{
				case 5:
					break;
				case 7:
					return num2;
				case 3:
					goto IL_0057;
				case 8:
					goto IL_0073;
				case 4:
					goto IL_0094;
				case 0:
					if (num >= count)
					{
						num3 = -68688098;
						continue;
					}
					goto IL_0073;
				case 2:
					num3 = -68688097;
					continue;
				case 6:
					goto IL_00ca;
				default:
					goto IL_00e2;
				}
				break;
				IL_00ca:
				int num4;
				if (num2 >= count2)
				{
					num3 = -68688098;
					num4 = num3;
				}
				else
				{
					num3 = -68688101;
					num4 = num3;
				}
				continue;
				IL_0094:
				if (EFqoihzfWPSyBSLPTqoSlFxiMFY[num2].nsWuUeEARsbpuBNDuYrazAaqNZU != P_0)
				{
					num2++;
					num3 = -68688103;
				}
				else
				{
					num3 = -68688104;
				}
				continue;
				IL_0073:
				if (ucYrDJrrYCRbwamDBvXnNCfHTyj[num].nsWuUeEARsbpuBNDuYrazAaqNZU == P_0)
				{
					return num;
				}
				num++;
				num3 = -68688097;
			}
			goto IL_0011;
			IL_00e2:
			return -1;
		}

		public int KITOQlhBKIDpAjmntFCXekgANGKd(int P_0, InputSource P_1, kPOdZCCVexwrShFGuJqyYnczwJzE P_2)
		{
			if (P_2 != kPOdZCCVexwrShFGuJqyYnczwJzE.MyJyGjmCwusbhiQFfrODGPnUwSK)
			{
				goto IL_0098;
			}
			int count = ucYrDJrrYCRbwamDBvXnNCfHTyj.Count;
			int num = 0;
			goto IL_00b4;
			IL_001e:
			int num2;
			int num3 = default(int);
			int count2 = default(int);
			while (true)
			{
				switch (num2 ^ 0x40C2D783)
				{
				case 6:
					num2 = 1086510978;
					continue;
				case 2:
					break;
				case 7:
					goto IL_0063;
				case 0:
					goto end_IL_001e;
				case 3:
					goto IL_00b4;
				case 4:
					num2 = 1086510982;
					continue;
				case 1:
					goto IL_00d6;
				default:
					goto IL_010e;
				}
				int num4;
				if (num3 < count2)
				{
					num2 = 1086510980;
					num4 = num2;
				}
				else
				{
					num2 = 1086510982;
					num4 = num2;
				}
				continue;
				IL_00d6:
				if (ucYrDJrrYCRbwamDBvXnNCfHTyj[num].WsRlOJISdsLrMfPqXptvzvrqEdy == P_0 && ucYrDJrrYCRbwamDBvXnNCfHTyj[num].EAHBveZYCGolVbLQhYJNUosGdcUg == P_1)
				{
					return num;
				}
				num++;
				num2 = 1086510976;
				continue;
				IL_0063:
				if (EFqoihzfWPSyBSLPTqoSlFxiMFY[num3].WsRlOJISdsLrMfPqXptvzvrqEdy == P_0 && EFqoihzfWPSyBSLPTqoSlFxiMFY[num3].EAHBveZYCGolVbLQhYJNUosGdcUg == P_1)
				{
					return num3;
				}
				num3++;
				num2 = 1086510977;
				continue;
				end_IL_001e:
				break;
			}
			goto IL_0098;
			IL_00b4:
			int num5;
			if (num >= count)
			{
				num2 = 1086510983;
				num5 = num2;
			}
			else
			{
				num2 = 1086510978;
				num5 = num2;
			}
			goto IL_001e;
			IL_010e:
			return -1;
			IL_0098:
			if (P_2 == kPOdZCCVexwrShFGuJqyYnczwJzE.zHIDjadCrmciEDxyqlukcUUEQZwZ)
			{
				count2 = EFqoihzfWPSyBSLPTqoSlFxiMFY.Count;
				num3 = 0;
				num2 = 1086510977;
				goto IL_001e;
			}
			goto IL_010e;
		}

		public dptoUdeHtFoXlqJWYAtWyKYogQD QYqpfEAMICxOSguOhSZBWaRbARM(int P_0, kPOdZCCVexwrShFGuJqyYnczwJzE P_1)
		{
			if (P_1 == kPOdZCCVexwrShFGuJqyYnczwJzE.MyJyGjmCwusbhiQFfrODGPnUwSK)
			{
				goto IL_0003;
			}
			int num;
			if (P_0 >= 0)
			{
				int num2;
				if (P_0 >= EFqoihzfWPSyBSLPTqoSlFxiMFY.Count)
				{
					num = 1399319737;
					num2 = num;
				}
				else
				{
					num = 1399319739;
					num2 = num;
				}
				goto IL_0008;
			}
			goto IL_0069;
			IL_0008:
			while (true)
			{
				switch (num ^ 0x5367ECB8)
				{
				case 2:
					break;
				case 4:
					return ucYrDJrrYCRbwamDBvXnNCfHTyj[P_0].QYqpfEAMICxOSguOhSZBWaRbARM();
				case 1:
					goto IL_0069;
				case 0:
					throw new ArgumentOutOfRangeException();
				case 5:
					goto IL_0083;
				case 6:
					goto IL_009b;
				default:
					return EFqoihzfWPSyBSLPTqoSlFxiMFY[P_0].QYqpfEAMICxOSguOhSZBWaRbARM();
				}
				break;
				IL_009b:
				int num3;
				if (P_0 < ucYrDJrrYCRbwamDBvXnNCfHTyj.Count)
				{
					num = 1399319740;
					num3 = num;
				}
				else
				{
					num = 1399319736;
					num3 = num;
				}
				continue;
				IL_0083:
				int num4;
				if (P_0 >= 0)
				{
					num = 1399319742;
					num4 = num;
				}
				else
				{
					num = 1399319736;
					num4 = num;
				}
			}
			goto IL_0003;
			IL_0003:
			num = 1399319741;
			goto IL_0008;
			IL_0069:
			throw new ArgumentOutOfRangeException();
		}

		public int bwCwBXIIaGhvIhyDYuaWVihsRoF(int P_0, InputSource P_1, kPOdZCCVexwrShFGuJqyYnczwJzE P_2)
		{
			int num = KITOQlhBKIDpAjmntFCXekgANGKd(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			switch (P_2)
			{
			case kPOdZCCVexwrShFGuJqyYnczwJzE.MyJyGjmCwusbhiQFfrODGPnUwSK:
				return ucYrDJrrYCRbwamDBvXnNCfHTyj[num].qOMDSncdndJStuKdNXRcJfmTrwf;
			case kPOdZCCVexwrShFGuJqyYnczwJzE.zHIDjadCrmciEDxyqlukcUUEQZwZ:
				return EFqoihzfWPSyBSLPTqoSlFxiMFY[num].qOMDSncdndJStuKdNXRcJfmTrwf;
			default:
				return -1;
			}
		}

		private int DxOTPLWfRAutmvoFGWjuDWfHiBt(int P_0)
		{
			int count = ucYrDJrrYCRbwamDBvXnNCfHTyj.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					if (ucYrDJrrYCRbwamDBvXnNCfHTyj[num].WsRlOJISdsLrMfPqXptvzvrqEdy == P_0)
					{
						return DxOTPLWfRAutmvoFGWjuDWfHiBt();
					}
					num++;
					int num2 = 267969491;
					while (true)
					{
						switch (num2 ^ 0xFF8E3D3)
						{
						case 2:
							num2 = 267969490;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002e;
						}
						break;
					}
					continue;
					end_IL_002e:
					break;
				}
			}
			return P_0;
		}

		private int DxOTPLWfRAutmvoFGWjuDWfHiBt()
		{
			int count = ucYrDJrrYCRbwamDBvXnNCfHTyj.Count;
			int num = 0;
			int num3 = default(int);
			bool flag = default(bool);
			while (true)
			{
				int num2 = -155407489;
				while (true)
				{
					switch (num2 ^ -155407492)
					{
					case 5:
						break;
					case 2:
						if (ucYrDJrrYCRbwamDBvXnNCfHTyj[num3].WsRlOJISdsLrMfPqXptvzvrqEdy == num)
						{
							flag = true;
							num2 = -155407494;
							continue;
						}
						goto case 0;
					case 8:
						num3 = 0;
						num2 = -155407496;
						continue;
					case 1:
					{
						int num4;
						if (num3 >= count)
						{
							num2 = -155407494;
							num4 = num2;
						}
						else
						{
							num2 = -155407490;
							num4 = num2;
						}
						continue;
					}
					case 3:
						flag = false;
						num2 = -155407500;
						continue;
					case 4:
						num2 = -155407491;
						continue;
					case 0:
						num3++;
						num2 = -155407491;
						continue;
					case 6:
						if (!flag)
						{
							num2 = -155407493;
							continue;
						}
						num++;
						goto case 3;
					default:
						return num;
					}
					break;
				}
			}
		}
	}

	private class ZvuwUOrXXrMvwrWffUtgIopumQS : IInputManagerJoystickPublic
	{
		private IInputManagerJoystickPublic eunhnaovDRiEguPGzwjEMBJUohX;

		private int unbiwITeMyjOSMeElaDVrhMlcZY;

		public int rewiredId
		{
			get
			{
				return eunhnaovDRiEguPGzwjEMBJUohX.rewiredId;
			}
		}

		public int inputManagerId
		{
			get
			{
				return unbiwITeMyjOSMeElaDVrhMlcZY;
			}
		}

		public string name
		{
			get
			{
				return eunhnaovDRiEguPGzwjEMBJUohX.name;
			}
		}

		public long? systemId
		{
			get
			{
				return eunhnaovDRiEguPGzwjEMBJUohX.systemId;
			}
		}

		public int unityId
		{
			get
			{
				return eunhnaovDRiEguPGzwjEMBJUohX.unityId;
			}
		}

		public Guid instanceGuid
		{
			get
			{
				return eunhnaovDRiEguPGzwjEMBJUohX.instanceGuid;
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
				return eunhnaovDRiEguPGzwjEMBJUohX.extension;
			}
		}

		public ZvuwUOrXXrMvwrWffUtgIopumQS(IInputManagerJoystickPublic sourceJoystick, int bridgeJoystickId)
		{
			eunhnaovDRiEguPGzwjEMBJUohX = sourceJoystick;
			unbiwITeMyjOSMeElaDVrhMlcZY = bridgeJoystickId;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			eunhnaovDRiEguPGzwjEMBJUohX.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			eunhnaovDRiEguPGzwjEMBJUohX.StopVibration();
		}
	}

	private sealed class NLFDvEVQjLuiQKHoGJGjQHryduz
	{
		public int IZgeEsAcywOFlSvSuaDMZooDRAeH;

		public int fyTLflqFYzOwtYyWoAMHjvrjhLY()
		{
			return IZgeEsAcywOFlSvSuaDMZooDRAeH++;
		}
	}

	private const bool lOvTpmEhBnQYvlaXlDkYVqMVUhA = false;

	private const bool bhTcNbpskdhrHBJLswmJwWxPwAnN = false;

	private const bool ciTtiaJbHECNvlpbggVOaogNDckG = false;

	private const bool moIOdbZpIeIizmdVocwHHdsGgEv = false;

	private const bool qNAArcqaiOxdstHTqbvvBfFeErX = false;

	private bool UmCIkDDfhBkELrnhrBsuDuBUIECd;

	private object WxUWTAtdUibUAhfsrbxONRDqcoAF;

	private IndexedDictionary<int, PlatformInputManager> kXcyhmfxuZfaxpKsUMVLGvYxgqR;

	private MHskauzvoncDVsnkbArGgTkupIN CGZflfyhHDgaBdgsRsNNqBNrNtzF;

	private Action<int, ControllerDataUpdater> YALIvlsEVxFcouIKiMIOBoKrdos;

	private WindowsStandalonePrimaryInputSource BCTVXHajqfkcmbJADqLHFuntEpK;

	private bool lzYXPygjnRyMAxANCJnEdbJpaPYe;

	private PlatformInputManager YLxisMThRDTgIbPaYfJsjfpWQRp;

	private bool EunSBHLfNRgdAnbppgktFwQMEOt;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lzXAqTcTNwGXhyoMQqetZTTNJGjM;

	private Func<int> sbyIXavKIUtCermoZwGVxaaQFdB;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = JBXHRSYUePslTBUiRmNOkdLSed.SjhdLgwUpKBDLNKnstwrnFdgWQM();
			IntPtr intPtr2 = JBXHRSYUePslTBUiRmNOkdLSed.BwcrcaWbYgaFuQmgRzzaiBJGcym();
			return intPtr2 != IntPtr.Zero && intPtr == intPtr2;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return CGZflfyhHDgaBdgsRsNNqBNrNtzF.deviceCount;
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return YLxisMThRDTgIbPaYfJsjfpWQRp;
		}
	}

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return YLxisMThRDTgIbPaYfJsjfpWQRp.inputSource;
		}
	}

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			if (YLxisMThRDTgIbPaYfJsjfpWQRp == null)
			{
				return InputSource.None;
			}
			return YLxisMThRDTgIbPaYfJsjfpWQRp.inputSourceType;
		}
	}

	public jXnpEMkJCbjCUjrZVTHyNrvpMaSB(ConfigVars configVars, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		BCTVXHajqfkcmbJADqLHFuntEpK = configVars.windowsStandalonePrimaryInputSource;
		lzYXPygjnRyMAxANCJnEdbJpaPYe = configVars.useXInput;
		lzXAqTcTNwGXhyoMQqetZTTNJGjM = getHardwareJoystickMap_InputManager;
		sbyIXavKIUtCermoZwGVxaaQFdB = getNewJoystickId;
		bool flag = false;
		kXcyhmfxuZfaxpKsUMVLGvYxgqR = new IndexedDictionary<int, PlatformInputManager>();
		if (UnityTools.platform != Platform.WindowsAppStore)
		{
			try
			{
				rdYCGoWOpFzeWopaszcDvgrUprf.GVPNrpnUrcRcuBVNsoUmnQYWdWW();
				ywJkAizTVJIvGNjxsTUDDuEcjbC ywJkAizTVJIvGNjxsTUDDuEcjbC2 = (ywJkAizTVJIvGNjxsTUDDuEcjbC)(WxUWTAtdUibUAhfsrbxONRDqcoAF = new ywJkAizTVJIvGNjxsTUDDuEcjbC());
				bool flag2 = false;
				if (BCTVXHajqfkcmbJADqLHFuntEpK == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag2 = pzzIrTPVcxfOIWdDGMADbCVcAIh(configVars, ywJkAizTVJIvGNjxsTUDDuEcjbC2);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag2 = NpEbnTCIWsyAVuFKIGnBpRgUJSBM(configVars, ywJkAizTVJIvGNjxsTUDDuEcjbC2);
						if (flag2)
						{
							configVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							BCTVXHajqfkcmbJADqLHFuntEpK = configVars.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized!");
						}
					}
				}
				else if (BCTVXHajqfkcmbJADqLHFuntEpK == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag2 = NpEbnTCIWsyAVuFKIGnBpRgUJSBM(configVars, ywJkAizTVJIvGNjxsTUDDuEcjbC2);
					if (!flag2)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag2 = pzzIrTPVcxfOIWdDGMADbCVcAIh(configVars, ywJkAizTVJIvGNjxsTUDDuEcjbC2);
						if (flag2)
						{
							configVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							BCTVXHajqfkcmbJADqLHFuntEpK = configVars.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized!");
						}
					}
				}
				else if (BCTVXHajqfkcmbJADqLHFuntEpK == WindowsStandalonePrimaryInputSource.XInput)
				{
					flag2 = RNXtOlpjyhRmMrnpbOfnrcOzaei(configVars, false);
					if (flag2)
					{
						ALBcmtfdkZomSWknSJvAQQhfQmN(configVars, ywJkAizTVJIvGNjxsTUDDuEcjbC2);
					}
					flag = flag2;
				}
				if (!flag2)
				{
					throw new Exception();
				}
				ywJkAizTVJIvGNjxsTUDDuEcjbC2.DeviceConnectedEvent += LGmGhCkHIkwFdJiMznPWpfeSLfe;
				ywJkAizTVJIvGNjxsTUDDuEcjbC2.DeviceDisconnectedEvent += BEPBvRaFHldTRtfUFksyuZCoGLr;
				for (int i = 0; i < kXcyhmfxuZfaxpKsUMVLGvYxgqR.Count; i++)
				{
					PlatformInputManager platformInputManager = kXcyhmfxuZfaxpKsUMVLGvYxgqR[i];
					platformInputManager.DeviceConnectedEvent += HTxZvMHopKQTpuALBVOoSiCuvTY;
					platformInputManager.DeviceDisconnectedEvent += kAaiwniUCYipFtEKHjGxHijaBrTQ;
					platformInputManager.UpdateControllerInfoEvent += eZjDQFAKJTAgooYIwgmHFHyqzgqB;
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
			RNXtOlpjyhRmMrnpbOfnrcOzaei(configVars, true);
		}
		YALIvlsEVxFcouIKiMIOBoKrdos = UpdateControllerData;
	}

	private bool pzzIrTPVcxfOIWdDGMADbCVcAIh(ConfigVars P_0, ywJkAizTVJIvGNjxsTUDDuEcjbC P_1)
	{
		ZJlurOepsAQxsfgddlEPRgblxKu zJlurOepsAQxsfgddlEPRgblxKu = null;
		fBXeGifswogtgcrDLXdgVsYUjXH fBXeGifswogtgcrDLXdgVsYUjXH2 = null;
		try
		{
			zJlurOepsAQxsfgddlEPRgblxKu = new ZJlurOepsAQxsfgddlEPRgblxKu(P_0, false, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.useEnhancedDeviceSupport);
			fBXeGifswogtgcrDLXdgVsYUjXH2 = (fBXeGifswogtgcrDLXdgVsYUjXH)(YLxisMThRDTgIbPaYfJsjfpWQRp = new fBXeGifswogtgcrDLXdgVsYUjXH(P_0.updateLoop, lzYXPygjnRyMAxANCJnEdbJpaPYe, ((ywJkAizTVJIvGNjxsTUDDuEcjbC)WxUWTAtdUibUAhfsrbxONRDqcoAF).windowHandle, lzXAqTcTNwGXhyoMQqetZTTNJGjM, sbyIXavKIUtCermoZwGVxaaQFdB));
			kXcyhmfxuZfaxpKsUMVLGvYxgqR.Add(5, zJlurOepsAQxsfgddlEPRgblxKu);
			kXcyhmfxuZfaxpKsUMVLGvYxgqR.Add(1, YLxisMThRDTgIbPaYfJsjfpWQRp);
			P_1.WindowFocusEvent += zJlurOepsAQxsfgddlEPRgblxKu.RIFGoRkBALlYhSSoKGqJvomxrIu;
			return true;
		}
		catch (Exception)
		{
			while (true)
			{
				IL_008f:
				int num = -2030070764;
				while (true)
				{
					switch (num ^ -2030070768)
					{
					case 5:
						break;
					default:
						goto end_IL_0094;
					case 0:
					{
						int num3;
						if (zJlurOepsAQxsfgddlEPRgblxKu != null)
						{
							num = -2030070767;
							num3 = num;
						}
						else
						{
							num = -2030070762;
							num3 = num;
						}
						continue;
					}
					case 6:
						Logger.LogWarning("Unable to initialize Direct Input! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
						num = -2030070765;
						continue;
					case 1:
						zJlurOepsAQxsfgddlEPRgblxKu.OnDestroy();
						num = -2030070762;
						continue;
					case 4:
					{
						int num2;
						if (fBXeGifswogtgcrDLXdgVsYUjXH2 == null)
						{
							num = -2030070768;
							num2 = num;
						}
						else
						{
							num = -2030070766;
							num2 = num;
						}
						continue;
					}
					case 2:
						fBXeGifswogtgcrDLXdgVsYUjXH2.OnDestroy();
						num = -2030070768;
						continue;
					case 3:
						goto end_IL_0094;
					}
					goto IL_008f;
					continue;
					end_IL_0094:
					break;
				}
				break;
			}
		}
		return false;
	}

	private bool NpEbnTCIWsyAVuFKIGnBpRgUJSBM(ConfigVars P_0, ywJkAizTVJIvGNjxsTUDDuEcjbC P_1)
	{
		ZJlurOepsAQxsfgddlEPRgblxKu zJlurOepsAQxsfgddlEPRgblxKu = null;
		try
		{
			zJlurOepsAQxsfgddlEPRgblxKu = new ZJlurOepsAQxsfgddlEPRgblxKu(P_0, P_0.useXInput, lzXAqTcTNwGXhyoMQqetZTTNJGjM, sbyIXavKIUtCermoZwGVxaaQFdB, true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.useEnhancedDeviceSupport);
			kXcyhmfxuZfaxpKsUMVLGvYxgqR.Add(5, zJlurOepsAQxsfgddlEPRgblxKu);
			P_1.WindowFocusEvent += zJlurOepsAQxsfgddlEPRgblxKu.RIFGoRkBALlYhSSoKGqJvomxrIu;
			YLxisMThRDTgIbPaYfJsjfpWQRp = zJlurOepsAQxsfgddlEPRgblxKu;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			while (true)
			{
				IL_0063:
				int num = -129130490;
				while (true)
				{
					switch (num ^ -129130489)
					{
					case 0:
						break;
					default:
						goto end_IL_0068;
					case 1:
						if (zJlurOepsAQxsfgddlEPRgblxKu != null)
						{
							goto IL_0084;
						}
						goto end_IL_0068;
					case 2:
						goto end_IL_0068;
					}
					goto IL_0063;
					IL_0084:
					zJlurOepsAQxsfgddlEPRgblxKu.OnDestroy();
					num = -129130491;
					continue;
					end_IL_0068:
					break;
				}
				break;
			}
		}
		return false;
	}

	private bool ALBcmtfdkZomSWknSJvAQQhfQmN(ConfigVars P_0, ywJkAizTVJIvGNjxsTUDDuEcjbC P_1)
	{
		if (!P_0.GetPlatformVar_useNativeMouse())
		{
			while (true)
			{
				int num = 1064236974;
				while (true)
				{
					switch (num ^ 0x3F6EF7AF)
					{
					case 0:
						break;
					case 1:
						goto IL_0026;
					default:
						return false;
					}
					break;
					IL_0026:
					if (P_0.GetPlatformVar_useNativeKeyboard())
					{
						goto end_IL_0008;
					}
					num = 1064236973;
				}
				continue;
				end_IL_0008:
				break;
			}
		}
		ZJlurOepsAQxsfgddlEPRgblxKu zJlurOepsAQxsfgddlEPRgblxKu = null;
		try
		{
			zJlurOepsAQxsfgddlEPRgblxKu = new ZJlurOepsAQxsfgddlEPRgblxKu(P_0, false, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.useEnhancedDeviceSupport);
			P_1.WindowFocusEvent += zJlurOepsAQxsfgddlEPRgblxKu.RIFGoRkBALlYhSSoKGqJvomxrIu;
			kXcyhmfxuZfaxpKsUMVLGvYxgqR.Add(5, zJlurOepsAQxsfgddlEPRgblxKu);
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			if (zJlurOepsAQxsfgddlEPRgblxKu != null)
			{
				zJlurOepsAQxsfgddlEPRgblxKu.OnDestroy();
				goto IL_008d;
			}
			goto IL_00ab;
			IL_00ab:
			zJlurOepsAQxsfgddlEPRgblxKu = null;
			int num2 = 1064236973;
			goto IL_0092;
			IL_008d:
			num2 = 1064236974;
			goto IL_0092;
			IL_0092:
			switch (num2 ^ 0x3F6EF7AF)
			{
			case 0:
				break;
			case 1:
				goto IL_00ab;
			default:
				return false;
			}
			goto IL_008d;
		}
	}

	private bool RNXtOlpjyhRmMrnpbOfnrcOzaei(ConfigVars P_0, bool P_1)
	{
		bool flag = YLxisMThRDTgIbPaYfJsjfpWQRp == null;
		NLFDvEVQjLuiQKHoGJGjQHryduz nLFDvEVQjLuiQKHoGJGjQHryduz = default(NLFDvEVQjLuiQKHoGJGjQHryduz);
		gshAbvCgMLjmBZLoNOmLiemiCMZ gshAbvCgMLjmBZLoNOmLiemiCMZ2 = default(gshAbvCgMLjmBZLoNOmLiemiCMZ);
		bool result = default(bool);
		int num4 = default(int);
		while (true)
		{
			int num = 413927290;
			while (true)
			{
				int num2;
				bool flag2;
				bool flag3;
				switch (num ^ 0x18AC077B)
				{
				case 3:
					break;
				case 1:
					if (!P_0.useXInput && !flag)
					{
						num = 413927289;
						continue;
					}
					num2 = 1;
					goto IL_0049;
				case 2:
					num2 = ((ReInput.currentPlatform == Platform.WindowsAppStore) ? 1 : 0);
					goto IL_0049;
				default:
					{
						return false;
					}
					IL_0049:
					flag2 = (byte)num2 != 0;
					flag3 = false;
					if (!flag2)
					{
						num = 413927291;
						continue;
					}
					try
					{
						if (flag3)
						{
							nLFDvEVQjLuiQKHoGJGjQHryduz = new NLFDvEVQjLuiQKHoGJGjQHryduz();
							goto IL_0067;
						}
						goto IL_0147;
						IL_0147:
						gshAbvCgMLjmBZLoNOmLiemiCMZ2 = new gshAbvCgMLjmBZLoNOmLiemiCMZ(flag3, P_0.updateLoop, lzXAqTcTNwGXhyoMQqetZTTNJGjM, sbyIXavKIUtCermoZwGVxaaQFdB);
						int num3 = 413927295;
						goto IL_006c;
						IL_0067:
						num3 = 413927290;
						goto IL_006c;
						IL_006c:
						while (true)
						{
							switch (num3 ^ 0x18AC077B)
							{
							case 5:
								break;
							case 4:
								if (flag)
								{
									YLxisMThRDTgIbPaYfJsjfpWQRp = gshAbvCgMLjmBZLoNOmLiemiCMZ2;
									num3 = 413927289;
									continue;
								}
								goto case 2;
							case 2:
								kXcyhmfxuZfaxpKsUMVLGvYxgqR.Add(2, gshAbvCgMLjmBZLoNOmLiemiCMZ2);
								if (P_1)
								{
									gshAbvCgMLjmBZLoNOmLiemiCMZ2.DeviceConnectedEvent += HTxZvMHopKQTpuALBVOoSiCuvTY;
									num3 = 413927291;
									continue;
								}
								goto default;
							case 1:
							{
								nLFDvEVQjLuiQKHoGJGjQHryduz.IZgeEsAcywOFlSvSuaDMZooDRAeH = 0;
								gshAbvCgMLjmBZLoNOmLiemiCMZ value = new gshAbvCgMLjmBZLoNOmLiemiCMZ(flag3, P_0.updateLoop, lzXAqTcTNwGXhyoMQqetZTTNJGjM, nLFDvEVQjLuiQKHoGJGjQHryduz.fyTLflqFYzOwtYyWoAMHjvrjhLY);
								kXcyhmfxuZfaxpKsUMVLGvYxgqR.Add(2, value);
								num3 = 413927293;
								continue;
							}
							case 0:
								gshAbvCgMLjmBZLoNOmLiemiCMZ2.DeviceDisconnectedEvent += kAaiwniUCYipFtEKHjGxHijaBrTQ;
								gshAbvCgMLjmBZLoNOmLiemiCMZ2.UpdateControllerInfoEvent += eZjDQFAKJTAgooYIwgmHFHyqzgqB;
								num3 = 413927293;
								continue;
							case 3:
								goto IL_0147;
							default:
								result = true;
								goto end_IL_005a;
							}
							break;
						}
						goto IL_0067;
						end_IL_005a:;
					}
					catch (Exception)
					{
						if (flag)
						{
							OnDestroy();
							Logger.LogWarning("Unable to initialize XInput!");
							goto IL_018a;
						}
						goto IL_0238;
						IL_0238:
						int num5;
						if (!flag3)
						{
							Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + BCTVXHajqfkcmbJADqLHFuntEpK.ToString() + " instead. The L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
							P_0.useXInput = false;
							num4 = 0;
							num5 = 413927289;
							goto IL_018f;
						}
						goto IL_01df;
						IL_018a:
						num5 = 413927288;
						goto IL_018f;
						IL_018f:
						while (true)
						{
							switch (num5 ^ 0x18AC077B)
							{
							case 7:
								break;
							default:
								goto end_IL_0173;
							case 2:
								if (num4 >= kXcyhmfxuZfaxpKsUMVLGvYxgqR.Count)
								{
									Logger.LogWarning("Unable to initialize XInput! Please see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
									num5 = 413927293;
									continue;
								}
								goto case 1;
							case 6:
								goto IL_01df;
							case 3:
								throw;
							case 4:
								num4++;
								num5 = 413927289;
								continue;
							case 1:
								if (kXcyhmfxuZfaxpKsUMVLGvYxgqR[num4] != null)
								{
									yLzSZCPmdJJGIPBHZlMHGMUViap yLzSZCPmdJJGIPBHZlMHGMUViap2 = kXcyhmfxuZfaxpKsUMVLGvYxgqR[num4] as yLzSZCPmdJJGIPBHZlMHGMUViap;
									if (yLzSZCPmdJJGIPBHZlMHGMUViap2 != null)
									{
										yLzSZCPmdJJGIPBHZlMHGMUViap2.useXInput = false;
										num5 = 413927295;
										continue;
									}
								}
								goto case 4;
							case 5:
								goto IL_0238;
							case 0:
								goto end_IL_0173;
							}
							break;
						}
						goto IL_018a;
						IL_01df:
						result = false;
						num5 = 413927291;
						goto IL_018f;
						end_IL_0173:;
					}
					return result;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		UmCIkDDfhBkELrnhrBsuDuBUIECd = true;
		int num2 = default(int);
		while (true)
		{
			int num = 121077975;
			while (true)
			{
				switch (num ^ 0x73780D4)
				{
				case 4:
					break;
				default:
					return;
				case 1:
					num2++;
					num = 121077974;
					continue;
				case 2:
				{
					int num3;
					if (num2 >= kXcyhmfxuZfaxpKsUMVLGvYxgqR.Count)
					{
						num = 121077969;
						num3 = num;
					}
					else
					{
						num = 121077972;
						num3 = num;
					}
					continue;
				}
				case 3:
					CGZflfyhHDgaBdgsRsNNqBNrNtzF = new MHskauzvoncDVsnkbArGgTkupIN();
					num2 = 0;
					num = 121077974;
					continue;
				case 0:
					kXcyhmfxuZfaxpKsUMVLGvYxgqR[num2].Initialize();
					num = 121077973;
					continue;
				case 5:
					return;
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
			int num2;
			int num3;
			if (num < kXcyhmfxuZfaxpKsUMVLGvYxgqR.Count)
			{
				num2 = 664603075;
				num3 = num2;
			}
			else
			{
				num2 = 664603074;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x279D09C2)
				{
				case 2:
					num2 = 664603075;
					continue;
				default:
					return;
				case 1:
					kXcyhmfxuZfaxpKsUMVLGvYxgqR[num].Update(currentUpdateLoop);
					num++;
					num2 = 664603073;
					continue;
				case 3:
					break;
				case 0:
					return;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		int num = kXcyhmfxuZfaxpKsUMVLGvYxgqR.Count - 1;
		while (true)
		{
			IL_0052:
			int num2;
			if (num < 0)
			{
				if (WxUWTAtdUibUAhfsrbxONRDqcoAF == null)
				{
					break;
				}
				((ywJkAizTVJIvGNjxsTUDDuEcjbC)WxUWTAtdUibUAhfsrbxONRDqcoAF).OnDestroy();
				num2 = 1181995741;
				goto IL_0015;
			}
			goto IL_0036;
			IL_0036:
			kXcyhmfxuZfaxpKsUMVLGvYxgqR[num].OnDestroy();
			num--;
			num2 = 1181995742;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0x4673D2DF)
				{
				case 0:
					num2 = 1181995740;
					continue;
				case 3:
					break;
				case 1:
					goto IL_0052;
				case 2:
					WxUWTAtdUibUAhfsrbxONRDqcoAF = null;
					num2 = 1181995739;
					continue;
				default:
					goto end_IL_0052;
				}
				break;
			}
			goto IL_0036;
			continue;
			end_IL_0052:
			break;
		}
		rdYCGoWOpFzeWopaszcDvgrUprf.HtJdxRxaGggkmaMTSWUpHqjZLDV();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return YALIvlsEVxFcouIKiMIOBoKrdos;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		kXcyhmfxuZfaxpKsUMVLGvYxgqR.GetValue((int)data.source).UpdateControllerData(CGZflfyhHDgaBdgsRsNNqBNrNtzF.bwCwBXIIaGhvIhyDYuaWVihsRoF(controllerId, data.source, MHskauzvoncDVsnkbArGgTkupIN.kPOdZCCVexwrShFGuJqyYnczwJzE.MyJyGjmCwusbhiQFfrODGPnUwSK), data);
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
		while (num < kXcyhmfxuZfaxpKsUMVLGvYxgqR.Count)
		{
			while (true)
			{
				IUnifiedMouseSource unifiedMouseSource = kXcyhmfxuZfaxpKsUMVLGvYxgqR[num].GetUnifiedMouseSource();
				int num2 = -348844136;
				while (true)
				{
					switch (num2 ^ -348844134)
					{
					case 3:
						num2 = -348844130;
						continue;
					case 0:
						return unifiedMouseSource;
					case 2:
						break;
					case 4:
						goto end_IL_0009;
					default:
						goto end_IL_0041;
					}
					if (unifiedMouseSource == null)
					{
						num++;
						num2 = -348844133;
					}
					else
					{
						num2 = -348844134;
					}
					continue;
					end_IL_0009:
					break;
				}
				continue;
				end_IL_0041:
				break;
			}
		}
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		int num = 0;
		while (num < kXcyhmfxuZfaxpKsUMVLGvYxgqR.Count)
		{
			while (true)
			{
				IUnifiedKeyboardSource unifiedKeyboardSource = kXcyhmfxuZfaxpKsUMVLGvYxgqR[num].GetUnifiedKeyboardSource();
				int num2 = 549490098;
				while (true)
				{
					switch (num2 ^ 0x20C08DB2)
					{
					case 2:
						num2 = 549490099;
						continue;
					case 1:
						break;
					case 0:
						goto IL_0043;
					case 3:
						return unifiedKeyboardSource;
					default:
						goto end_IL_002a;
					}
					break;
					IL_0043:
					if (unifiedKeyboardSource != null)
					{
						num2 = 549490097;
						continue;
					}
					num++;
					num2 = 549490102;
				}
				continue;
				end_IL_002a:
				break;
			}
		}
		return null;
	}

	private void HTxZvMHopKQTpuALBVOoSiCuvTY(BridgedController P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_0044;
		IL_0003:
		int num = -949075657;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num ^ -949075660)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				return;
			case 2:
				_DeviceConnectedEvent(P_0);
				num = -949075664;
				continue;
			case 1:
				goto IL_0044;
			case 4:
				return;
			}
			break;
		}
		goto IL_0003;
		IL_0044:
		CGZflfyhHDgaBdgsRsNNqBNrNtzF.TRJCxVoiknCjOLIhEiXteqZiyHkL(P_0);
		int num2;
		if (_DeviceConnectedEvent != null)
		{
			num = -949075658;
			num2 = num;
		}
		else
		{
			num = -949075664;
			num2 = num;
		}
		goto IL_0008;
	}

	private void kAaiwniUCYipFtEKHjGxHijaBrTQ(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_0044;
		IL_0003:
		int num = 2131926366;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num ^ 0x7F129D5D)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				return;
			case 4:
				_DeviceDisconnectedEvent(P_0);
				num = 2131926364;
				continue;
			case 2:
				goto IL_0044;
			case 1:
				return;
			}
			break;
		}
		goto IL_0003;
		IL_0044:
		CGZflfyhHDgaBdgsRsNNqBNrNtzF.eoMMqoWhWSqtFZaxEABBffIpwcd(P_0);
		int num2;
		if (_DeviceDisconnectedEvent == null)
		{
			num = 2131926364;
			num2 = num;
		}
		else
		{
			num = 2131926361;
			num2 = num;
		}
		goto IL_0008;
	}

	private void LGmGhCkHIkwFdJiMznPWpfeSLfe(EventArgs P_0)
	{
		if (!UmCIkDDfhBkELrnhrBsuDuBUIECd)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = -1495778232;
			while (true)
			{
				switch (num2 ^ -1495778232)
				{
				case 2:
					num2 = -1495778231;
					continue;
				case 1:
					break;
				case 3:
					kXcyhmfxuZfaxpKsUMVLGvYxgqR[num].SystemDeviceConnected();
					num++;
					num2 = -1495778232;
					continue;
				default:
					if (num >= kXcyhmfxuZfaxpKsUMVLGvYxgqR.Count)
					{
						return;
					}
					goto case 3;
				}
				break;
			}
		}
	}

	private void BEPBvRaFHldTRtfUFksyuZCoGLr(EventArgs P_0)
	{
		if (!UmCIkDDfhBkELrnhrBsuDuBUIECd)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = 113095835;
			while (true)
			{
				switch (num2 ^ 0x6BDB49E)
				{
				case 0:
					num2 = 113095836;
					continue;
				default:
					return;
				case 2:
					break;
				case 5:
				{
					int num3;
					if (num < kXcyhmfxuZfaxpKsUMVLGvYxgqR.Count)
					{
						num2 = 113095837;
						num3 = num2;
					}
					else
					{
						num2 = 113095834;
						num3 = num2;
					}
					continue;
				}
				case 1:
					num++;
					num2 = 113095835;
					continue;
				case 3:
					kXcyhmfxuZfaxpKsUMVLGvYxgqR[num].SystemDeviceDisconnected();
					num2 = 113095839;
					continue;
				case 4:
					return;
				}
				break;
			}
		}
	}

	private void eZjDQFAKJTAgooYIwgmHFHyqzgqB(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null)
		{
			if (P_0.sourceJoystick == null)
			{
				goto IL_000e;
			}
			goto IL_00a1;
		}
		return;
		IL_0047:
		int num = default(int);
		int num2;
		int num3;
		if (num >= 0)
		{
			num2 = -889254352;
			num3 = num2;
		}
		else
		{
			num2 = -889254348;
			num3 = num2;
		}
		goto IL_0013;
		IL_000e:
		num2 = -889254347;
		goto IL_0013;
		IL_0013:
		MHskauzvoncDVsnkbArGgTkupIN.kPOdZCCVexwrShFGuJqyYnczwJzE kPOdZCCVexwrShFGuJqyYnczwJzE = default(MHskauzvoncDVsnkbArGgTkupIN.kPOdZCCVexwrShFGuJqyYnczwJzE);
		while (true)
		{
			switch (num2 ^ -889254348)
			{
			case 6:
				break;
			default:
				return;
			case 1:
				return;
			case 5:
				goto IL_0047;
			case 4:
			{
				MHskauzvoncDVsnkbArGgTkupIN.dptoUdeHtFoXlqJWYAtWyKYogQD dptoUdeHtFoXlqJWYAtWyKYogQD = CGZflfyhHDgaBdgsRsNNqBNrNtzF.QYqpfEAMICxOSguOhSZBWaRbARM(num, kPOdZCCVexwrShFGuJqyYnczwJzE);
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new ZvuwUOrXXrMvwrWffUtgIopumQS(P_0.sourceJoystick, dptoUdeHtFoXlqJWYAtWyKYogQD.WsRlOJISdsLrMfPqXptvzvrqEdy)));
					num2 = -889254346;
					continue;
				}
				return;
			}
			case 3:
				goto IL_00a1;
			case 0:
				return;
			case 2:
				return;
			}
			break;
		}
		goto IL_000e;
		IL_00a1:
		CGZflfyhHDgaBdgsRsNNqBNrNtzF.INjahPzTowmdiaFiKDLZIfIAanqf(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		kPOdZCCVexwrShFGuJqyYnczwJzE = MHskauzvoncDVsnkbArGgTkupIN.kPOdZCCVexwrShFGuJqyYnczwJzE.MyJyGjmCwusbhiQFfrODGPnUwSK;
		num = CGZflfyhHDgaBdgsRsNNqBNrNtzF.KITOQlhBKIDpAjmntFCXekgANGKd(P_0.sourceJoystick.rewiredId, kPOdZCCVexwrShFGuJqyYnczwJzE);
		if (num < 0)
		{
			kPOdZCCVexwrShFGuJqyYnczwJzE = MHskauzvoncDVsnkbArGgTkupIN.kPOdZCCVexwrShFGuJqyYnczwJzE.zHIDjadCrmciEDxyqlukcUUEQZwZ;
			num = CGZflfyhHDgaBdgsRsNNqBNrNtzF.KITOQlhBKIDpAjmntFCXekgANGKd(P_0.sourceJoystick.rewiredId, kPOdZCCVexwrShFGuJqyYnczwJzE);
			num2 = -889254351;
			goto IL_0013;
		}
		goto IL_0047;
	}
}
