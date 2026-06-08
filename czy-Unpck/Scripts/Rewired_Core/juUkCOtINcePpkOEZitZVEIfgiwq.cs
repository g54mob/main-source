using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class juUkCOtINcePpkOEZitZVEIfgiwq
{
	internal enum iIesQmHJYNaOjZySNFbyVCRRARUD
	{
		ZFyaNNcZvxZQpandMiHfdzHrUtb = 0,
		rltKKHXEwzFMSJClACISKvHcbDw = 1,
		gQycyAxmUbprXJvfcdLMRodEACx = 2
	}

	private class dYRIeKPTuahZpRFNFjLvIjmtuLF
	{
		internal class LWeWeaWQnNRVbNGFAMkXDlgHvBD
		{
			internal double GrsVvLtzYHtodPjjOUgixnplUkO;

			private InputBehavior LflDuUhkdWkUJqTTfvjviPFwfEt;

			internal float ISgWeYGbWKoagTPpdEHHGPrxuYRR;

			internal float dQzJVUgnJcRcYMJUkgvewqvuEKY;

			internal AxisCoordinateMode zGQxodzogwFhSdbMgELkcWlbngKQ;

			internal AxisCoordinateMode cwFUgmCqjNPyQuCTJiUUDfoThWW;

			internal ButtonStateFlags xIxmveJFHALIQlAbQKeZFlFXGNXb;

			internal ButtonStateFlags KJGcneJobXMEjwwXCKbwRANsQBA;

			internal ButtonStateFlags TCkDheBvUNZXHuPBukvmMYToJYZo;

			internal ButtonStateFlags SfnTRaInXWDlkfNuIwVoUrDdUUv;

			internal float IZGHexaYkySLlWceVEvUjanxguf;

			internal float YpjRQEgxAOijiUlOxRAkFwEablZ;

			internal float maGkRMGuBZIYxDSgIqpaczpxMSZ;

			internal float tMTpKfYTojxsaqdtvhLjTdeKudk;

			private double vyJnqRUOleHCjoPbDCehHikdxxm;

			private double SwDnbuSVmmhjLVgeSGDaYXpVFmz;

			internal dpVtayQkMohBNIznVFukSTYbCqxv CaEXgkdxHSkoCebMwiwqGNiYqDc;

			internal dpVtayQkMohBNIznVFukSTYbCqxv CdhmhOUjvKXhIEXEysSACjjWToy;

			internal ButtonStateRecorder oWKfobWWMrkqUtJRcFyyKGvSNSl;

			internal ButtonStateRecorder lvJMejPlUXLwNkPpqfvlFFjBbgZb;

			internal yRzGaencLCmJeIjDViAlrLCTqzk CHqsPXWgXsfififFoJsmIrqNaPc;

			internal yRzGaencLCmJeIjDViAlrLCTqzk EfFAJaMxUzYEJGdeOWOuqMBcPMz;

			internal TimerAbs iwjBIJKCpojdFHZNErKamSiLdkpw;

			internal TimerAbs TPYDESrsYTdFzxMpWNTOjljNQkD;

			internal readonly pAbmAVcsPcjQUSUHsDdzTqGMLSN jSBEaifIKToDkCppGmLcJGMnBkD = new pAbmAVcsPcjQUSUHsDdzTqGMLSN();

			internal double vButtonTimePressed => oWKfobWWMrkqUtJRcFyyKGvSNSl.timePressed;

			internal double vButtonTimeUnpressed => oWKfobWWMrkqUtJRcFyyKGvSNSl.timeUnpressed;

			internal double negativeVButtonTimePressed => lvJMejPlUXLwNkPpqfvlFFjBbgZb.timePressed;

			internal double negativeVButtonTimeUnpressed => lvJMejPlUXLwNkPpqfvlFFjBbgZb.timeUnpressed;

			internal double vAxisTimeActive
			{
				get
				{
					if (ISgWeYGbWKoagTPpdEHHGPrxuYRR == 0f)
					{
						goto IL_000d;
					}
					goto IL_004a;
					IL_000d:
					int num = -1573038723;
					goto IL_0012;
					IL_0012:
					double num2 = default(double);
					while (true)
					{
						switch (num ^ -1573038724)
						{
						case 4:
							break;
						case 1:
							goto IL_0033;
						case 0:
							goto IL_005e;
						case 3:
							num2 = 0.0;
							num = -1573038722;
							continue;
						default:
							return num2;
						}
						break;
						IL_005e:
						int num3;
						if (num2 >= 0.0)
						{
							num = -1573038722;
							num3 = num;
						}
						else
						{
							num = -1573038721;
							num3 = num;
						}
					}
					goto IL_000d;
					IL_004a:
					num2 = kPcECEntishmGKJfubVhUXmQHws - vyJnqRUOleHCjoPbDCehHikdxxm;
					num = -1573038724;
					goto IL_0012;
					IL_0033:
					if (IZGHexaYkySLlWceVEvUjanxguf == 0f)
					{
						return 0.0;
					}
					goto IL_004a;
				}
			}

			internal double vAxisTimeInactive
			{
				get
				{
					double num = default(double);
					int num2;
					if (ISgWeYGbWKoagTPpdEHHGPrxuYRR == 0f)
					{
						if (IZGHexaYkySLlWceVEvUjanxguf != 0f)
						{
							goto IL_001a;
						}
						num = kPcECEntishmGKJfubVhUXmQHws - vyJnqRUOleHCjoPbDCehHikdxxm;
						num2 = -1711784495;
						goto IL_001f;
					}
					goto IL_003c;
					IL_001f:
					while (true)
					{
						switch (num2 ^ -1711784496)
						{
						case 0:
							break;
						case 3:
							goto IL_003c;
						case 1:
							if (num < 0.0)
							{
								num = 0.0;
								num2 = -1711784494;
								continue;
							}
							goto default;
						default:
							return num;
						}
						break;
					}
					goto IL_001a;
					IL_003c:
					return 0.0;
					IL_001a:
					num2 = -1711784493;
					goto IL_001f;
				}
			}

			internal double vAxisRawTimeActive
			{
				get
				{
					if (ISgWeYGbWKoagTPpdEHHGPrxuYRR == 0f && maGkRMGuBZIYxDSgIqpaczpxMSZ == 0f)
					{
						return 0.0;
					}
					double num = kPcECEntishmGKJfubVhUXmQHws - SwDnbuSVmmhjLVgeSGDaYXpVFmz;
					while (true)
					{
						int num2 = -591028208;
						while (true)
						{
							switch (num2 ^ -591028206)
							{
							case 0:
								break;
							case 2:
								if (num < 0.0)
								{
									goto IL_005b;
								}
								goto default;
							default:
								return num;
							}
							break;
							IL_005b:
							num = 0.0;
							num2 = -591028205;
						}
					}
				}
			}

			internal double vAxisRawTimeInactive
			{
				get
				{
					if (ISgWeYGbWKoagTPpdEHHGPrxuYRR != 0f)
					{
						goto IL_0038;
					}
					if (maGkRMGuBZIYxDSgIqpaczpxMSZ != 0f)
					{
						goto IL_001a;
					}
					double num = kPcECEntishmGKJfubVhUXmQHws - SwDnbuSVmmhjLVgeSGDaYXpVFmz;
					int num2;
					if (num < 0.0)
					{
						num = 0.0;
						num2 = -1546737262;
						goto IL_001f;
					}
					goto IL_006c;
					IL_001f:
					switch (num2 ^ -1546737262)
					{
					case 2:
						break;
					case 1:
						goto IL_0038;
					default:
						goto IL_006c;
					}
					goto IL_001a;
					IL_0038:
					return 0.0;
					IL_006c:
					return num;
					IL_001a:
					num2 = -1546737261;
					goto IL_001f;
				}
			}

			internal LWeWeaWQnNRVbNGFAMkXDlgHvBD(InputBehavior inputBehavior)
			{
				LflDuUhkdWkUJqTTfvjviPFwfEt = inputBehavior;
				if (inputBehavior.buttonDownBuffer > 0f)
				{
					iwjBIJKCpojdFHZNErKamSiLdkpw = new TimerAbs(inputBehavior.buttonDownBuffer);
					TPYDESrsYTdFzxMpWNTOjljNQkD = new TimerAbs(inputBehavior.buttonDownBuffer);
				}
				oWKfobWWMrkqUtJRcFyyKGvSNSl = new ButtonStateRecorder();
				lvJMejPlUXLwNkPpqfvlFFjBbgZb = new ButtonStateRecorder();
				CaEXgkdxHSkoCebMwiwqGNiYqDc = new dpVtayQkMohBNIznVFukSTYbCqxv(inputBehavior.buttonDoublePressSpeed);
				CdhmhOUjvKXhIEXEysSACjjWToy = new dpVtayQkMohBNIznVFukSTYbCqxv(inputBehavior.buttonDoublePressSpeed);
				CHqsPXWgXsfififFoJsmIrqNaPc = new yRzGaencLCmJeIjDViAlrLCTqzk(inputBehavior.buttonRepeatDelay, inputBehavior.buttonRepeatRate);
				EfFAJaMxUzYEJGdeOWOuqMBcPMz = new yRzGaencLCmJeIjDViAlrLCTqzk(inputBehavior.buttonRepeatDelay, inputBehavior.buttonRepeatRate);
				PitBJBhMfenRQxPSPxWkOXWIkNq();
			}

			internal void qztkUWsNKhLJHziDHiYYwDkwQxc(double P_0)
			{
				if (ISgWeYGbWKoagTPpdEHHGPrxuYRR == 0f)
				{
					if (IZGHexaYkySLlWceVEvUjanxguf != 0f)
					{
						goto IL_001d;
					}
					goto IL_006c;
				}
				goto IL_013e;
				IL_0097:
				if (dQzJVUgnJcRcYMJUkgvewqvuEKY == 0f && tMTpKfYTojxsaqdtvhLjTdeKudk == 0f)
				{
					SwDnbuSVmmhjLVgeSGDaYXpVFmz = kPcECEntishmGKJfubVhUXmQHws;
				}
				return;
				IL_001d:
				int num = -452375238;
				goto IL_0022;
				IL_0022:
				while (true)
				{
					switch (num ^ -452375233)
					{
					case 3:
						break;
					default:
						return;
					case 8:
						goto IL_005a;
					case 9:
						goto IL_006c;
					case 0:
						goto IL_0097;
					case 7:
						goto IL_00cd;
					case 1:
						if (dQzJVUgnJcRcYMJUkgvewqvuEKY == 0f)
						{
							goto IL_0108;
						}
						goto case 4;
					case 6:
						vyJnqRUOleHCjoPbDCehHikdxxm = kPcECEntishmGKJfubVhUXmQHws;
						num = -452375240;
						continue;
					case 5:
						goto IL_013e;
					case 4:
						SwDnbuSVmmhjLVgeSGDaYXpVFmz = kPcECEntishmGKJfubVhUXmQHws;
						num = -452375235;
						continue;
					case 2:
						return;
					}
					break;
					IL_0108:
					int num2;
					if (tMTpKfYTojxsaqdtvhLjTdeKudk == 0f)
					{
						num = -452375235;
						num2 = num;
					}
					else
					{
						num = -452375237;
						num2 = num;
					}
				}
				goto IL_001d;
				IL_00cd:
				if (ISgWeYGbWKoagTPpdEHHGPrxuYRR == 0f)
				{
					int num3;
					if (maGkRMGuBZIYxDSgIqpaczpxMSZ == 0f)
					{
						num = -452375234;
						num3 = num;
					}
					else
					{
						num = -452375233;
						num3 = num;
					}
					goto IL_0022;
				}
				goto IL_0097;
				IL_005a:
				vyJnqRUOleHCjoPbDCehHikdxxm = kPcECEntishmGKJfubVhUXmQHws;
				num = -452375240;
				goto IL_0022;
				IL_013e:
				if (dQzJVUgnJcRcYMJUkgvewqvuEKY == 0f)
				{
					int num4;
					if (YpjRQEgxAOijiUlOxRAkFwEablZ != 0f)
					{
						num = -452375240;
						num4 = num;
					}
					else
					{
						num = -452375239;
						num4 = num;
					}
					goto IL_0022;
				}
				goto IL_00cd;
				IL_006c:
				if (dQzJVUgnJcRcYMJUkgvewqvuEKY == 0f)
				{
					int num5;
					if (YpjRQEgxAOijiUlOxRAkFwEablZ == 0f)
					{
						num = -452375240;
						num5 = num;
					}
					else
					{
						num = -452375241;
						num5 = num;
					}
					goto IL_0022;
				}
				goto IL_005a;
			}

			internal void qdxkBCfUDeShMzZIdjMyBiiNmMl()
			{
				if (dQzJVUgnJcRcYMJUkgvewqvuEKY != ISgWeYGbWKoagTPpdEHHGPrxuYRR)
				{
					dQzJVUgnJcRcYMJUkgvewqvuEKY = ISgWeYGbWKoagTPpdEHHGPrxuYRR;
					goto IL_001a;
				}
				goto IL_0053;
				IL_0053:
				int num;
				if (KJGcneJobXMEjwwXCKbwRANsQBA != xIxmveJFHALIQlAbQKeZFlFXGNXb)
				{
					KJGcneJobXMEjwwXCKbwRANsQBA = xIxmveJFHALIQlAbQKeZFlFXGNXb;
					num = 259537355;
					goto IL_001f;
				}
				goto IL_00a9;
				IL_001a:
				num = 259537354;
				goto IL_001f;
				IL_001f:
				while (true)
				{
					switch (num ^ 0xF7839C8)
					{
					case 5:
						break;
					default:
						return;
					case 2:
						goto IL_0053;
					case 8:
						YpjRQEgxAOijiUlOxRAkFwEablZ = IZGHexaYkySLlWceVEvUjanxguf;
						num = 259537352;
						continue;
					case 1:
						goto IL_0087;
					case 3:
						goto IL_00a9;
					case 7:
						if (zGQxodzogwFhSdbMgELkcWlbngKQ != AxisCoordinateMode.Absolute)
						{
							zGQxodzogwFhSdbMgELkcWlbngKQ = AxisCoordinateMode.Absolute;
							num = 259537356;
							continue;
						}
						return;
					case 0:
						if (tMTpKfYTojxsaqdtvhLjTdeKudk != maGkRMGuBZIYxDSgIqpaczpxMSZ)
						{
							tMTpKfYTojxsaqdtvhLjTdeKudk = maGkRMGuBZIYxDSgIqpaczpxMSZ;
							num = 259537358;
							continue;
						}
						goto case 6;
					case 6:
						if (cwFUgmCqjNPyQuCTJiUUDfoThWW != zGQxodzogwFhSdbMgELkcWlbngKQ)
						{
							cwFUgmCqjNPyQuCTJiUUDfoThWW = zGQxodzogwFhSdbMgELkcWlbngKQ;
							num = 259537359;
							continue;
						}
						goto case 7;
					case 4:
						return;
					}
					break;
				}
				goto IL_001a;
				IL_0087:
				int num2;
				if (YpjRQEgxAOijiUlOxRAkFwEablZ != IZGHexaYkySLlWceVEvUjanxguf)
				{
					num = 259537344;
					num2 = num;
				}
				else
				{
					num = 259537352;
					num2 = num;
				}
				goto IL_001f;
				IL_00a9:
				if (SfnTRaInXWDlkfNuIwVoUrDdUUv != TCkDheBvUNZXHuPBukvmMYToJYZo)
				{
					SfnTRaInXWDlkfNuIwVoUrDdUUv = TCkDheBvUNZXHuPBukvmMYToJYZo;
					num = 259537353;
					goto IL_001f;
				}
				goto IL_0087;
			}

			internal void botagrwEfKETicBBcbAEcGhqPIJ()
			{
				if (iwjBIJKCpojdFHZNErKamSiLdkpw == null)
				{
					return;
				}
				iwjBIJKCpojdFHZNErKamSiLdkpw.Update();
				while (true)
				{
					int num = 1994744898;
					while (true)
					{
						switch (num ^ 0x76E56443)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0032;
						case 2:
							return;
						}
						break;
						IL_0032:
						TPYDESrsYTdFzxMpWNTOjljNQkD.Update();
						num = 1994744897;
					}
				}
			}

			internal void bhawNHEfnlGmlCzdQKAGkCudDoqY(bool P_0, bool P_1, bool P_2, bool P_3)
			{
				oWKfobWWMrkqUtJRcFyyKGvSNSl.GzCliicOSMFLMvKajLgvnmGSSrh(P_0, P_1, kPcECEntishmGKJfubVhUXmQHws);
				lvJMejPlUXLwNkPpqfvlFFjBbgZb.GzCliicOSMFLMvKajLgvnmGSSrh(P_2, P_3, kPcECEntishmGKJfubVhUXmQHws);
				float buttonDoublePressSpeed = LflDuUhkdWkUJqTTfvjviPFwfEt.buttonDoublePressSpeed;
				CaEXgkdxHSkoCebMwiwqGNiYqDc.GzCliicOSMFLMvKajLgvnmGSSrh(buttonDoublePressSpeed, P_0, P_1);
				CdhmhOUjvKXhIEXEysSACjjWToy.GzCliicOSMFLMvKajLgvnmGSSrh(buttonDoublePressSpeed, P_2, P_3);
				float buttonRepeatDelay = LflDuUhkdWkUJqTTfvjviPFwfEt.buttonRepeatDelay;
				float buttonRepeatRate = LflDuUhkdWkUJqTTfvjviPFwfEt.buttonRepeatRate;
				CHqsPXWgXsfififFoJsmIrqNaPc.GzCliicOSMFLMvKajLgvnmGSSrh(P_0, P_1, buttonRepeatDelay, buttonRepeatRate, kPcECEntishmGKJfubVhUXmQHws);
				EfFAJaMxUzYEJGdeOWOuqMBcPMz.GzCliicOSMFLMvKajLgvnmGSSrh(P_2, P_3, buttonRepeatDelay, buttonRepeatRate, kPcECEntishmGKJfubVhUXmQHws);
			}

			internal bool MPCsQwPpPDVyKfKRKjkcHfbpjck()
			{
				if (kPcECEntishmGKJfubVhUXmQHws < GrsVvLtzYHtodPjjOUgixnplUkO + (double)LflDuUhkdWkUJqTTfvjviPFwfEt.buttonDoublePressSpeed + 2.0 * (double)RsvJXtZKfDCUPOixtNBmDnRVdUu)
				{
					goto IL_002e;
				}
				if (ISgWeYGbWKoagTPpdEHHGPrxuYRR != 0f)
				{
					return false;
				}
				if (dQzJVUgnJcRcYMJUkgvewqvuEKY != 0f)
				{
					return false;
				}
				if (xIxmveJFHALIQlAbQKeZFlFXGNXb == ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
				{
					return false;
				}
				int num;
				if (KJGcneJobXMEjwwXCKbwRANsQBA != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
				{
					if (TCkDheBvUNZXHuPBukvmMYToJYZo == ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
					{
						return false;
					}
					if (SfnTRaInXWDlkfNuIwVoUrDdUUv == ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
					{
						return false;
					}
					if (IZGHexaYkySLlWceVEvUjanxguf != 0f)
					{
						return false;
					}
					if (YpjRQEgxAOijiUlOxRAkFwEablZ == 0f)
					{
						if (maGkRMGuBZIYxDSgIqpaczpxMSZ != 0f)
						{
							return false;
						}
						if (tMTpKfYTojxsaqdtvhLjTdeKudk != 0f)
						{
							return false;
						}
						if (iwjBIJKCpojdFHZNErKamSiLdkpw == null)
						{
							goto IL_0110;
						}
						num = -1623067147;
					}
					else
					{
						num = -1623067150;
					}
				}
				else
				{
					num = -1623067151;
				}
				goto IL_0033;
				IL_0033:
				switch (num ^ -1623067151)
				{
				case 2:
					break;
				case 3:
					return false;
				case 0:
					return false;
				case 1:
					return false;
				default:
					goto IL_0101;
				}
				goto IL_002e;
				IL_002e:
				num = -1623067152;
				goto IL_0033;
				IL_0101:
				if (iwjBIJKCpojdFHZNErKamSiLdkpw.running)
				{
					return false;
				}
				goto IL_0110;
				IL_0110:
				if (TPYDESrsYTdFzxMpWNTOjljNQkD != null && TPYDESrsYTdFzxMpWNTOjljNQkD.running)
				{
					return false;
				}
				return true;
			}

			internal void UwKaGawaRAIpOHPkRndmiaegboT()
			{
				xIxmveJFHALIQlAbQKeZFlFXGNXb &= ~ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL;
			}

			internal void EobBEOKOMxGhZjszeEmLccSbrTvA()
			{
				if (ISgWeYGbWKoagTPpdEHHGPrxuYRR != 0f)
				{
					goto IL_00ad;
				}
				if (IZGHexaYkySLlWceVEvUjanxguf != 0f)
				{
					goto IL_0020;
				}
				goto IL_0158;
				IL_00ad:
				vyJnqRUOleHCjoPbDCehHikdxxm = kPcECEntishmGKJfubVhUXmQHws;
				int num = -1787172222;
				goto IL_0025;
				IL_0020:
				num = -1787172219;
				goto IL_0025;
				IL_0025:
				while (true)
				{
					switch (num ^ -1787172221)
					{
					case 8:
						break;
					case 10:
						oWKfobWWMrkqUtJRcFyyKGvSNSl.EobBEOKOMxGhZjszeEmLccSbrTvA(kPcECEntishmGKJfubVhUXmQHws);
						num = -1787172218;
						continue;
					case 7:
						KJGcneJobXMEjwwXCKbwRANsQBA = ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO;
						TCkDheBvUNZXHuPBukvmMYToJYZo = ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO;
						SfnTRaInXWDlkfNuIwVoUrDdUUv = ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO;
						IZGHexaYkySLlWceVEvUjanxguf = 0f;
						YpjRQEgxAOijiUlOxRAkFwEablZ = 0f;
						num = -1787172214;
						continue;
					case 6:
						goto IL_00ad;
					case 0:
						ISgWeYGbWKoagTPpdEHHGPrxuYRR = 0f;
						dQzJVUgnJcRcYMJUkgvewqvuEKY = 0f;
						zGQxodzogwFhSdbMgELkcWlbngKQ = AxisCoordinateMode.Absolute;
						xIxmveJFHALIQlAbQKeZFlFXGNXb = ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO;
						num = -1787172220;
						continue;
					case 2:
						tMTpKfYTojxsaqdtvhLjTdeKudk = 0f;
						if (iwjBIJKCpojdFHZNErKamSiLdkpw != null)
						{
							iwjBIJKCpojdFHZNErKamSiLdkpw.Clear();
							TPYDESrsYTdFzxMpWNTOjljNQkD.Clear();
							num = -1787172224;
							continue;
						}
						goto case 3;
					case 4:
						goto IL_0123;
					case 3:
						CaEXgkdxHSkoCebMwiwqGNiYqDc.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
						CdhmhOUjvKXhIEXEysSACjjWToy.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
						num = -1787172215;
						continue;
					case 1:
						goto IL_0158;
					case 9:
						maGkRMGuBZIYxDSgIqpaczpxMSZ = 0f;
						num = -1787172223;
						continue;
					default:
						lvJMejPlUXLwNkPpqfvlFFjBbgZb.EobBEOKOMxGhZjszeEmLccSbrTvA(kPcECEntishmGKJfubVhUXmQHws);
						CHqsPXWgXsfififFoJsmIrqNaPc.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
						EfFAJaMxUzYEJGdeOWOuqMBcPMz.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
						jSBEaifIKToDkCppGmLcJGMnBkD.tAgADqjTsMUxSqYXeDyJIdETYRAp();
						return;
					}
					break;
				}
				goto IL_0020;
				IL_0123:
				SwDnbuSVmmhjLVgeSGDaYXpVFmz = kPcECEntishmGKJfubVhUXmQHws;
				num = -1787172221;
				goto IL_0025;
				IL_0158:
				if (ISgWeYGbWKoagTPpdEHHGPrxuYRR == 0f)
				{
					int num2;
					if (maGkRMGuBZIYxDSgIqpaczpxMSZ == 0f)
					{
						num = -1787172221;
						num2 = num;
					}
					else
					{
						num = -1787172217;
						num2 = num;
					}
					goto IL_0025;
				}
				goto IL_0123;
			}

			internal void PitBJBhMfenRQxPSPxWkOXWIkNq()
			{
				EobBEOKOMxGhZjszeEmLccSbrTvA();
				while (true)
				{
					int num = -493247759;
					while (true)
					{
						switch (num ^ -493247757)
						{
						case 3:
							break;
						default:
							return;
						case 2:
							oWKfobWWMrkqUtJRcFyyKGvSNSl.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
							num = -493247758;
							continue;
						case 4:
							vyJnqRUOleHCjoPbDCehHikdxxm = kPcECEntishmGKJfubVhUXmQHws;
							SwDnbuSVmmhjLVgeSGDaYXpVFmz = kPcECEntishmGKJfubVhUXmQHws;
							num = -493247757;
							continue;
						case 1:
							lvJMejPlUXLwNkPpqfvlFFjBbgZb.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
							num = -493247753;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
			}
		}

		public LWeWeaWQnNRVbNGFAMkXDlgHvBD[] ukQXiEKzTMzPimOeOTmWBVpgDWV;

		private readonly int[] EtaejHsOyfWsKklaZtaHxOZADOO;

		private int VXgPrLiRFgJCxmeSHMjaqdvOBgr;

		internal LWeWeaWQnNRVbNGFAMkXDlgHvBD fSpdVoeWhOYoAilpUehbSxUxANDS;

		internal UpdateLoopType updateLoop
		{
			set
			{
				VXgPrLiRFgJCxmeSHMjaqdvOBgr = EtaejHsOyfWsKklaZtaHxOZADOO[(int)value];
				fSpdVoeWhOYoAilpUehbSxUxANDS = ukQXiEKzTMzPimOeOTmWBVpgDWV[VXgPrLiRFgJCxmeSHMjaqdvOBgr];
			}
		}

		internal dYRIeKPTuahZpRFNFjLvIjmtuLF(UpdateLoopSetting updateLoopSetting, InputBehavior inputBehavior)
		{
			EtaejHsOyfWsKklaZtaHxOZADOO = new int[3];
			ArrayTools.Fill(EtaejHsOyfWsKklaZtaHxOZADOO, -1);
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
				for (int i = 0; i < list.Count; i++)
				{
					EtaejHsOyfWsKklaZtaHxOZADOO[(int)list[i]] = num;
					num++;
				}
			}
			ukQXiEKzTMzPimOeOTmWBVpgDWV = new LWeWeaWQnNRVbNGFAMkXDlgHvBD[num];
			for (int j = 0; j < num; j++)
			{
				ukQXiEKzTMzPimOeOTmWBVpgDWV[j] = new LWeWeaWQnNRVbNGFAMkXDlgHvBD(inputBehavior);
			}
			fSpdVoeWhOYoAilpUehbSxUxANDS = ukQXiEKzTMzPimOeOTmWBVpgDWV[0];
		}

		internal bool MPCsQwPpPDVyKfKRKjkcHfbpjck()
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < 3)
				{
					num2 = 2144250254;
					num3 = num2;
				}
				else
				{
					num2 = 2144250255;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x7FCEA98F)
					{
					case 2:
						num2 = 2144250254;
						continue;
					case 1:
						if (EtaejHsOyfWsKklaZtaHxOZADOO[num] >= 0 && !ukQXiEKzTMzPimOeOTmWBVpgDWV[EtaejHsOyfWsKklaZtaHxOZADOO[num]].MPCsQwPpPDVyKfKRKjkcHfbpjck())
						{
							return false;
						}
						num++;
						num2 = 2144250252;
						continue;
					case 3:
						break;
					default:
						return true;
					}
					break;
				}
			}
		}

		internal void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
		{
			int num = 0;
			while (num < ukQXiEKzTMzPimOeOTmWBVpgDWV.Length)
			{
				while (true)
				{
					ukQXiEKzTMzPimOeOTmWBVpgDWV[num].PitBJBhMfenRQxPSPxWkOXWIkNq();
					int num2 = 757414883;
					while (true)
					{
						switch (num2 ^ 0x2D253BE2)
						{
						case 3:
							num2 = 757414880;
							continue;
						case 2:
							break;
						case 1:
							num++;
							num2 = 757414882;
							continue;
						default:
							goto end_IL_0026;
						}
						break;
					}
					continue;
					end_IL_0026:
					break;
				}
			}
		}

		internal void EobBEOKOMxGhZjszeEmLccSbrTvA()
		{
			int num = 0;
			while (num < ukQXiEKzTMzPimOeOTmWBVpgDWV.Length)
			{
				while (true)
				{
					ukQXiEKzTMzPimOeOTmWBVpgDWV[num].EobBEOKOMxGhZjszeEmLccSbrTvA();
					num++;
					int num2 = 1012233886;
					while (true)
					{
						switch (num2 ^ 0x3C55769F)
						{
						case 0:
							num2 = 1012233885;
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
		}
	}

	private class FCucOowrcWfgOwGNQhyTZLzdFvh
	{
		internal class JtqAIgZhGjPzORYwwtNrXlUyEng
		{
			internal Vector3 ouTPUepYEYHBxkmvFaHIfVuYbjOC;

			internal Vector3 mbSIBffwJpWXzmglfJvgLysBrtn;

			internal Vector3 HXQxUgKMihfGBKrlKsbOPnBQdyXI;

			internal void EvrwmdTSgkOFExjtIagaHHwdohiO()
			{
				ouTPUepYEYHBxkmvFaHIfVuYbjOC = ReInput.controllers.Mouse.screenPosition;
				HXQxUgKMihfGBKrlKsbOPnBQdyXI = ouTPUepYEYHBxkmvFaHIfVuYbjOC - mbSIBffwJpWXzmglfJvgLysBrtn;
			}

			internal void ZmxLuKhkZRMpUUxGyTAlZOyuelo()
			{
				mbSIBffwJpWXzmglfJvgLysBrtn.x = ouTPUepYEYHBxkmvFaHIfVuYbjOC.x;
				mbSIBffwJpWXzmglfJvgLysBrtn.y = ouTPUepYEYHBxkmvFaHIfVuYbjOC.y;
				mbSIBffwJpWXzmglfJvgLysBrtn.z = ouTPUepYEYHBxkmvFaHIfVuYbjOC.z;
			}
		}

		private ADictionary<int, JtqAIgZhGjPzORYwwtNrXlUyEng> cnMdijtHVvTgZNQjViuuBmexAFT;

		private JtqAIgZhGjPzORYwwtNrXlUyEng sgoefDxIyIRTvDjfPLNzgItITOR;

		private UpdateLoopType xJelxxARcpUqLbOKEfSvpSFNBVn;

		internal JtqAIgZhGjPzORYwwtNrXlUyEng current => sgoefDxIyIRTvDjfPLNzgItITOR;

		internal FCucOowrcWfgOwGNQhyTZLzdFvh(UpdateLoopSetting updateLoopSetting)
		{
			sgoefDxIyIRTvDjfPLNzgItITOR = null;
			cnMdijtHVvTgZNQjViuuBmexAFT = new ADictionary<int, JtqAIgZhGjPzORYwwtNrXlUyEng>();
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
				for (int i = 0; i < list.Count; i++)
				{
					JtqAIgZhGjPzORYwwtNrXlUyEng value = new JtqAIgZhGjPzORYwwtNrXlUyEng();
					cnMdijtHVvTgZNQjViuuBmexAFT.Add((int)list[i], value);
					if (sgoefDxIyIRTvDjfPLNzgItITOR == null)
					{
						sgoefDxIyIRTvDjfPLNzgItITOR = value;
					}
				}
			}
		}

		internal void EvrwmdTSgkOFExjtIagaHHwdohiO(UpdateLoopType P_0)
		{
			if (xJelxxARcpUqLbOKEfSvpSFNBVn != P_0)
			{
				goto IL_0009;
			}
			goto IL_0039;
			IL_0009:
			int num = 857820928;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x33214F01)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					xJelxxARcpUqLbOKEfSvpSFNBVn = P_0;
					num = 857820931;
					continue;
				case 2:
					goto IL_0039;
				case 0:
					return;
				}
				break;
			}
			goto IL_0009;
			IL_0039:
			sgoefDxIyIRTvDjfPLNzgItITOR = cnMdijtHVvTgZNQjViuuBmexAFT[(int)P_0];
			sgoefDxIyIRTvDjfPLNzgItITOR.EvrwmdTSgkOFExjtIagaHHwdohiO();
			num = 857820929;
			goto IL_000e;
		}

		internal void ZmxLuKhkZRMpUUxGyTAlZOyuelo()
		{
			sgoefDxIyIRTvDjfPLNzgItITOR.ZmxLuKhkZRMpUUxGyTAlZOyuelo();
		}
	}

	private const int yBRloPTQIiViJpGaizdHURBSKgd = 4;

	internal readonly string SQlNTEPvaCuPzRHxRVAmonHCzna;

	internal readonly int qxoYaUQyNIsvDIFklnqXHPrHJLd;

	internal readonly int cNcLkMBaCDcdcMeoQVAxVFVuHEv;

	private readonly int vuPDNwATQFuTZgAqTRoviXUGAgFM;

	private InputBehavior LflDuUhkdWkUJqTTfvjviPFwfEt;

	private dYRIeKPTuahZpRFNFjLvIjmtuLF cDthJAVgLSQoYKgKKbsijgxWPfPA;

	private static ConfigVars voLkponRBHpiQNHOfOdnrjJJatj;

	private static FCucOowrcWfgOwGNQhyTZLzdFvh tEZCbniWaFpqLbUqNNexgfmFGXUA;

	private static UpdateLoopType VesEEfGzljjgDkIPFVAOckifeaEO;

	private static double kPcECEntishmGKJfubVhUXmQHws;

	private static float RsvJXtZKfDCUPOixtNBmDnRVdUu;

	private static uint xIGfpqgWCweHPAdLzHgdWJlegxo;

	private float XzFvVccgxrRvVLVEsJsuiEzGckL;

	private float lGgKZtedwWZTeeRokjmlFjkKmac;

	private float PQIPLPomQpZcuHEisekdJQysEOHI;

	private float UQjOcyYODIwWQbQkhEnyomuhskk;

	private ButtonStateFlags qswlCffYfyhmwWPzuwjhEuGltZD;

	private ButtonStateFlags PjLJMXIKapkOORmRqiCDVeYZXON;

	private float rjZHDGEvejAzURgCpWJDHmczHobi;

	private bool izyzedVSfTbnnSpIjbaBLvtAqyf;

	private AxisCoordinateMode ORqghGsnIOzpWTjzWWOIBlFpjDc;

	private AxisCoordinateMode AKFnwQcqzIoiisPliXCPoffYBoV;

	private readonly pAbmAVcsPcjQUSUHsDdzTqGMLSN antQtESuXatVyiyPDTOYncyTcREI = new pAbmAVcsPcjQUSUHsDdzTqGMLSN();

	private uint xnIjJWjcKSmgvhmmqLIbdNVFprh;

	private uint DWtikjUsIcMygopEQCtsKOPGzOj;

	private bool DLHGCUwxrnqaSbPQXXmMcOxJaIt;

	private iIesQmHJYNaOjZySNFbyVCRRARUD yDbFGPOVwCcnOQRCFobOPrEoUhR;

	private int QuyolAEqbygmLbXHpafNEdszcaId;

	private pAbmAVcsPcjQUSUHsDdzTqGMLSN[] vjPvUdKJEuOpgjbTbfbqjNFfTGr;

	private List<InputActionSourceData> WVajCNyhOJSrDIhBKaeeHIvyXccw;

	private ReadOnlyCollection<InputActionSourceData> dWoFBZFCUCrJKjLGoGmpzBrosCPb;

	private bool pPudpEAbRTjSpfJnIIIXufNwTYY;

	internal bool iAgWGEzWxcyhtWsopRkEhQeyLjM;

	internal iIesQmHJYNaOjZySNFbyVCRRARUD LFjEkChFNlIHcQOEePsxvVBzeeq = iIesQmHJYNaOjZySNFbyVCRRARUD.gQycyAxmUbprXJvfcdLMRodEACx;

	internal static readonly ICHfJOokhzcuDNRrJJjxFiRoOez uLnGATJxtCMMwIomAUpvQoOiqrAB;

	static juUkCOtINcePpkOEZitZVEIfgiwq()
	{
		uLnGATJxtCMMwIomAUpvQoOiqrAB = new ICHfJOokhzcuDNRrJJjxFiRoOez();
	}

	internal juUkCOtINcePpkOEZitZVEIfgiwq(int playerId, InputAction action, InputBehavior inputBehavior, ConfigVars configVars)
	{
		vuPDNwATQFuTZgAqTRoviXUGAgFM = ReInput._id;
		voLkponRBHpiQNHOfOdnrjJJatj = configVars;
		cNcLkMBaCDcdcMeoQVAxVFVuHEv = playerId;
		qxoYaUQyNIsvDIFklnqXHPrHJLd = action.id;
		SQlNTEPvaCuPzRHxRVAmonHCzna = action.name;
		LflDuUhkdWkUJqTTfvjviPFwfEt = inputBehavior;
		cDthJAVgLSQoYKgKKbsijgxWPfPA = new dYRIeKPTuahZpRFNFjLvIjmtuLF(configVars.updateLoop, inputBehavior);
		vjPvUdKJEuOpgjbTbfbqjNFfTGr = new pAbmAVcsPcjQUSUHsDdzTqGMLSN[4];
		ArrayTools.Populate(vjPvUdKJEuOpgjbTbfbqjNFfTGr);
		WVajCNyhOJSrDIhBKaeeHIvyXccw = new List<InputActionSourceData>();
		dWoFBZFCUCrJKjLGoGmpzBrosCPb = new ReadOnlyCollection<InputActionSourceData>(WVajCNyhOJSrDIhBKaeeHIvyXccw);
	}

	internal static void ziLMcIXSpSwrwJNOpROVKIUOpOZ(ConfigVars P_0)
	{
		tEZCbniWaFpqLbUqNNexgfmFGXUA = new FCucOowrcWfgOwGNQhyTZLzdFvh(P_0.updateLoop);
	}

	internal static void iHiXgKQPKkdDwIvWNGiRuAvewAW(UpdateLoopType P_0)
	{
		VesEEfGzljjgDkIPFVAOckifeaEO = P_0;
		kPcECEntishmGKJfubVhUXmQHws = ReInput.unscaledTime;
		RsvJXtZKfDCUPOixtNBmDnRVdUu = (float)ReInput.unscaledDeltaTime;
		xIGfpqgWCweHPAdLzHgdWJlegxo = ReInput.absFrame;
		tEZCbniWaFpqLbUqNNexgfmFGXUA.EvrwmdTSgkOFExjtIagaHHwdohiO(P_0);
	}

	internal static void pLPulFDYtrqfGsPqpfOAGAjfzaoL()
	{
		tEZCbniWaFpqLbUqNNexgfmFGXUA.ZmxLuKhkZRMpUUxGyTAlZOyuelo();
	}

	private void ItpkyJFceFDcyqWdivzqwxwYDOd()
	{
		cDthJAVgLSQoYKgKKbsijgxWPfPA.updateLoop = VesEEfGzljjgDkIPFVAOckifeaEO;
		cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.qdxkBCfUDeShMzZIdjMyBiiNmMl();
		while (true)
		{
			int num = 1457252052;
			while (true)
			{
				switch (num ^ 0x56DBE6DC)
				{
				case 4:
					break;
				default:
					return;
				case 8:
					cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.botagrwEfKETicBBcbAEcGhqPIJ();
					if (XzFvVccgxrRvVLVEsJsuiEzGckL != 0f)
					{
						XzFvVccgxrRvVLVEsJsuiEzGckL = 0f;
						num = 1457252051;
						continue;
					}
					goto case 15;
				case 18:
					ORqghGsnIOzpWTjzWWOIBlFpjDc = AxisCoordinateMode.Absolute;
					num = 1457252063;
					continue;
				case 0:
					rjZHDGEvejAzURgCpWJDHmczHobi = 0f;
					num = 1457252062;
					continue;
				case 7:
					if (PjLJMXIKapkOORmRqiCDVeYZXON != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
					{
						PjLJMXIKapkOORmRqiCDVeYZXON = ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO;
						num = 1457252061;
						continue;
					}
					goto case 1;
				case 19:
					AKFnwQcqzIoiisPliXCPoffYBoV = AxisCoordinateMode.Absolute;
					num = 1457252049;
					continue;
				case 14:
					PQIPLPomQpZcuHEisekdJQysEOHI = 0f;
					num = 1457252044;
					continue;
				case 13:
					if (QuyolAEqbygmLbXHpafNEdszcaId > 0)
					{
						YrqPRccNueVzWAYHwFFsBXcXtYg();
						num = 1457252054;
						continue;
					}
					goto case 10;
				case 16:
				{
					int num6;
					if (UQjOcyYODIwWQbQkhEnyomuhskk == 0f)
					{
						num = 1457252058;
						num6 = num;
					}
					else
					{
						num = 1457252053;
						num6 = num;
					}
					continue;
				}
				case 5:
				{
					int num5;
					if (PQIPLPomQpZcuHEisekdJQysEOHI != 0f)
					{
						num = 1457252050;
						num5 = num;
					}
					else
					{
						num = 1457252044;
						num5 = num;
					}
					continue;
				}
				case 6:
				{
					int num4;
					if (ORqghGsnIOzpWTjzWWOIBlFpjDc != AxisCoordinateMode.Absolute)
					{
						num = 1457252046;
						num4 = num;
					}
					else
					{
						num = 1457252063;
						num4 = num;
					}
					continue;
				}
				case 12:
					antQtESuXatVyiyPDTOYncyTcREI.tAgADqjTsMUxSqYXeDyJIdETYRAp();
					num = 1457252045;
					continue;
				case 1:
				{
					int num7;
					if (rjZHDGEvejAzURgCpWJDHmczHobi != 0f)
					{
						num = 1457252060;
						num7 = num;
					}
					else
					{
						num = 1457252062;
						num7 = num;
					}
					continue;
				}
				case 2:
					if (izyzedVSfTbnnSpIjbaBLvtAqyf)
					{
						izyzedVSfTbnnSpIjbaBLvtAqyf = false;
						num = 1457252057;
						continue;
					}
					goto case 5;
				case 11:
					if (qswlCffYfyhmwWPzuwjhEuGltZD != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
					{
						qswlCffYfyhmwWPzuwjhEuGltZD = ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO;
						num = 1457252059;
						continue;
					}
					goto case 7;
				case 10:
				{
					int num3;
					if (antQtESuXatVyiyPDTOYncyTcREI.lTkuXDpBpsLxRBVaGMtdDZauGbI)
					{
						num = 1457252048;
						num3 = num;
					}
					else
					{
						num = 1457252045;
						num3 = num;
					}
					continue;
				}
				case 9:
					UQjOcyYODIwWQbQkhEnyomuhskk = 0f;
					num = 1457252058;
					continue;
				case 15:
					if (lGgKZtedwWZTeeRokjmlFjkKmac != 0f)
					{
						lGgKZtedwWZTeeRokjmlFjkKmac = 0f;
						num = 1457252055;
						continue;
					}
					goto case 11;
				case 3:
				{
					int num2;
					if (AKFnwQcqzIoiisPliXCPoffYBoV != AxisCoordinateMode.Absolute)
					{
						num = 1457252047;
						num2 = num;
					}
					else
					{
						num = 1457252049;
						num2 = num;
					}
					continue;
				}
				case 17:
					return;
				}
				break;
			}
		}
	}

	internal void ySbgAzYkAyfjIJZnfyAuXolwUwb(bool P_0)
	{
		if (xnIjJWjcKSmgvhmmqLIbdNVFprh == xIGfpqgWCweHPAdLzHgdWJlegxo)
		{
			goto IL_0177;
		}
		xnIjJWjcKSmgvhmmqLIbdNVFprh = xIGfpqgWCweHPAdLzHgdWJlegxo;
		if (yDbFGPOVwCcnOQRCFobOPrEoUhR != LFjEkChFNlIHcQOEePsxvVBzeeq)
		{
			yDbFGPOVwCcnOQRCFobOPrEoUhR = LFjEkChFNlIHcQOEePsxvVBzeeq;
			goto IL_0038;
		}
		goto IL_0300;
		IL_054a:
		ICHfJOokhzcuDNRrJJjxFiRoOez iCHfJOokhzcuDNRrJJjxFiRoOez = default(ICHfJOokhzcuDNRrJJjxFiRoOez);
		int num;
		if (iCHfJOokhzcuDNRrJJjxFiRoOez.fGOEgVenBQpynjDLaZtrcIyVGYbg._axisContribution == Pole.Positive)
		{
			YxGcqLJUUXPyrdhtgaNwEKQsryz(ref qswlCffYfyhmwWPzuwjhEuGltZD, iCHfJOokhzcuDNRrJJjxFiRoOez.xIxmveJFHALIQlAbQKeZFlFXGNXb);
			num = -1041768162;
			goto IL_003d;
		}
		goto IL_03a1;
		IL_04bc:
		cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.GrsVvLtzYHtodPjjOUgixnplUkO = kPcECEntishmGKJfubVhUXmQHws;
		num = -1041768166;
		goto IL_003d;
		IL_0038:
		num = -1041768158;
		goto IL_003d;
		IL_003d:
		int ouusLSVThShOJXeTBDNomJoAhtU = default(int);
		FCucOowrcWfgOwGNQhyTZLzdFvh.JtqAIgZhGjPzORYwwtNrXlUyEng current = default(FCucOowrcWfgOwGNQhyTZLzdFvh.JtqAIgZhGjPzORYwwtNrXlUyEng);
		float num4 = default(float);
		float num2 = default(float);
		float num5 = default(float);
		float y = default(float);
		float num3 = default(float);
		while (true)
		{
			switch (num ^ -1041768133)
			{
			case 17:
				break;
			default:
				return;
			case 0:
				if (LflDuUhkdWkUJqTTfvjviPFwfEt.mouseOtherAxisMode == MouseOtherAxisMode.MouseAxis)
				{
					PQIPLPomQpZcuHEisekdJQysEOHI += iCHfJOokhzcuDNRrJJjxFiRoOez.ZTonADnXjOPnKfCdZaXyKwbxjUQ * LflDuUhkdWkUJqTTfvjviPFwfEt.mouseOtherAxisSensitivity;
					num = -1041768154;
					continue;
				}
				goto case 29;
			case 38:
				if (ouusLSVThShOJXeTBDNomJoAhtU >= 2)
				{
					goto case 0;
				}
				if (LflDuUhkdWkUJqTTfvjviPFwfEt.mouseXYAxisMode == MouseXYAxisMode.MouseAxis)
				{
					PQIPLPomQpZcuHEisekdJQysEOHI += iCHfJOokhzcuDNRrJJjxFiRoOez.ZTonADnXjOPnKfCdZaXyKwbxjUQ * LflDuUhkdWkUJqTTfvjviPFwfEt.mouseXYAxisSensitivity;
					num = -1041768154;
					continue;
				}
				goto IL_026c;
			case 43:
				goto IL_0177;
			case 23:
			{
				current = tEZCbniWaFpqLbUqNNexgfmFGXUA.current;
				if (ouusLSVThShOJXeTBDNomJoAhtU != 0)
				{
					goto case 8;
				}
				float x = current.HXQxUgKMihfGBKrlKsbOPnBQdyXI.x;
				if (x != 0f)
				{
					num4 = x / num2;
					num = -1041768151;
					continue;
				}
				goto case 29;
			}
			case 33:
				goto IL_01c5;
			case 36:
				if (LflDuUhkdWkUJqTTfvjviPFwfEt.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.ScreenHeight)
				{
					num5 = Screen.height;
					num2 = num5;
					num = -1041768148;
					continue;
				}
				goto case 34;
			case 14:
				num2 = Screen.width;
				num5 = Screen.height;
				num = -1041768142;
				continue;
			case 24:
				goto IL_026c;
			case 21:
				if (y != 0f)
				{
					num3 = y / num5;
					if (LflDuUhkdWkUJqTTfvjviPFwfEt.mouseXYAxisMode == MouseXYAxisMode.Speed)
					{
						num3 /= RsvJXtZKfDCUPOixtNBmDnRVdUu;
						num = -1041768144;
						continue;
					}
					goto case 11;
				}
				goto case 29;
			case 19:
				return;
			case 10:
				goto IL_02df;
			case 25:
				goto IL_0300;
			case 4:
				if ((iCHfJOokhzcuDNRrJJjxFiRoOez.xIxmveJFHALIQlAbQKeZFlFXGNXb & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
				{
					izyzedVSfTbnnSpIjbaBLvtAqyf = true;
				}
				return;
			case 15:
				goto IL_033b;
			case 16:
				ItpkyJFceFDcyqWdivzqwxwYDOd();
				num = -1041768176;
				continue;
			case 27:
				throw new NotImplementedException();
			case 11:
				PQIPLPomQpZcuHEisekdJQysEOHI += num3;
				num = -1041768154;
				continue;
			case 6:
				return;
			case 26:
				goto IL_03a1;
			case 28:
				switch (iCHfJOokhzcuDNRrJJjxFiRoOez.IVrKIGlCGmByehFYpFNecVYihNyE)
				{
				case ControllerType.Mouse:
					goto IL_04a0;
				case ControllerType.Joystick:
					goto IL_0512;
				case ControllerType.Custom:
					goto IL_0682;
				}
				num = -1041768135;
				continue;
			case 22:
				YxGcqLJUUXPyrdhtgaNwEKQsryz(ref PjLJMXIKapkOORmRqiCDVeYZXON, iCHfJOokhzcuDNRrJJjxFiRoOez.xIxmveJFHALIQlAbQKeZFlFXGNXb);
				num = -1041768169;
				continue;
			case 1:
				num5 = num2;
				num = -1041768148;
				continue;
			case 18:
				if (LflDuUhkdWkUJqTTfvjviPFwfEt.mouseXYAxisMode == MouseXYAxisMode.Speed)
				{
					num4 /= RsvJXtZKfDCUPOixtNBmDnRVdUu;
					num = -1041768174;
					continue;
				}
				goto case 41;
			case 9:
				num = -1041768148;
				continue;
			case 34:
				throw new NotImplementedException();
			case 39:
				if (iCHfJOokhzcuDNRrJJjxFiRoOez.ZTonADnXjOPnKfCdZaXyKwbxjUQ != 0f)
				{
					rjZHDGEvejAzURgCpWJDHmczHobi += (int)(1f * MathTools.Sign(iCHfJOokhzcuDNRrJJjxFiRoOez.ZTonADnXjOPnKfCdZaXyKwbxjUQ));
					antQtESuXatVyiyPDTOYncyTcREI.dhodbseVbYqPVvdUgNSOeWdaMYFi(iCHfJOokhzcuDNRrJJjxFiRoOez);
					num = -1041768129;
					continue;
				}
				goto case 4;
			case 37:
				num = -1041768164;
				continue;
			case 31:
				goto IL_04a0;
			case 40:
				goto IL_04bc;
			case 13:
				if (ouusLSVThShOJXeTBDNomJoAhtU <= 1 || LflDuUhkdWkUJqTTfvjviPFwfEt.mouseOtherAxisMode != MouseOtherAxisMode.DigitalAxis)
				{
					goto case 38;
				}
				goto IL_04fa;
			case 7:
				goto IL_0512;
			case 20:
				goto IL_052e;
			case 5:
				goto IL_054a;
			case 41:
				PQIPLPomQpZcuHEisekdJQysEOHI += num4;
				num = -1041768154;
				continue;
			case 12:
				goto IL_058e;
			case 44:
				if (ORqghGsnIOzpWTjzWWOIBlFpjDc == AxisCoordinateMode.Absolute)
				{
					XzFvVccgxrRvVLVEsJsuiEzGckL += iCHfJOokhzcuDNRrJJjxFiRoOez.ZTonADnXjOPnKfCdZaXyKwbxjUQ;
					num = -1041768152;
					continue;
				}
				return;
			case 42:
				if (LFjEkChFNlIHcQOEePsxvVBzeeq == iIesQmHJYNaOjZySNFbyVCRRARUD.gQycyAxmUbprXJvfcdLMRodEACx)
				{
					LFjEkChFNlIHcQOEePsxvVBzeeq = iIesQmHJYNaOjZySNFbyVCRRARUD.rltKKHXEwzFMSJClACISKvHcbDw;
					num = -1041768176;
					continue;
				}
				goto IL_0177;
			case 8:
				y = current.HXQxUgKMihfGBKrlKsbOPnBQdyXI.y;
				num = -1041768146;
				continue;
			case 29:
				ghCfcofoArKxaOqHJrpsAIsXJtEf(iCHfJOokhzcuDNRrJJjxFiRoOez, LflDuUhkdWkUJqTTfvjviPFwfEt.buttonDeadZone, false);
				return;
			case 32:
				YxGcqLJUUXPyrdhtgaNwEKQsryz(ref qswlCffYfyhmwWPzuwjhEuGltZD, iCHfJOokhzcuDNRrJJjxFiRoOez.xIxmveJFHALIQlAbQKeZFlFXGNXb);
				num = -1041768169;
				continue;
			case 3:
				num2 = Screen.width;
				num = -1041768134;
				continue;
			case 2:
				throw new NotImplementedException();
			case 35:
				goto IL_0682;
			case 30:
				return;
				IL_0682:
				kKnDIMCUMfujlOLhmtdUwOeANpgB(iCHfJOokhzcuDNRrJJjxFiRoOez, LflDuUhkdWkUJqTTfvjviPFwfEt.customControllerAxisSensitivity);
				return;
				IL_0512:
				kKnDIMCUMfujlOLhmtdUwOeANpgB(iCHfJOokhzcuDNRrJJjxFiRoOez, LflDuUhkdWkUJqTTfvjviPFwfEt.joystickAxisSensitivity);
				num = -1041768131;
				continue;
				IL_04a0:
				if (ouusLSVThShOJXeTBDNomJoAhtU >= 2)
				{
					goto case 13;
				}
				if (LflDuUhkdWkUJqTTfvjviPFwfEt.mouseXYAxisMode != MouseXYAxisMode.DigitalAxis)
				{
					num = -1041768138;
					continue;
				}
				goto IL_04fa;
				IL_04fa:
				ghCfcofoArKxaOqHJrpsAIsXJtEf(iCHfJOokhzcuDNRrJJjxFiRoOez, 0f, true);
				return;
			}
			break;
			IL_033b:
			int num6;
			if (LflDuUhkdWkUJqTTfvjviPFwfEt.mouseXYAxisDeltaCalc != MouseXYAxisDeltaCalc.ScreenWidth)
			{
				num = -1041768161;
				num6 = num;
			}
			else
			{
				num = -1041768136;
				num6 = num;
			}
			continue;
			IL_026c:
			if (LflDuUhkdWkUJqTTfvjviPFwfEt.mouseXYAxisMode != MouseXYAxisMode.ScreenPositionDelta)
			{
				int num7;
				if (LflDuUhkdWkUJqTTfvjviPFwfEt.mouseXYAxisMode == MouseXYAxisMode.Speed)
				{
					num = -1041768143;
					num7 = num;
				}
				else
				{
					num = -1041768154;
					num7 = num;
				}
				continue;
			}
			goto IL_02df;
			IL_02df:
			int num8;
			if (LflDuUhkdWkUJqTTfvjviPFwfEt.mouseXYAxisDeltaCalc != MouseXYAxisDeltaCalc.Normal)
			{
				num = -1041768140;
				num8 = num;
			}
			else
			{
				num = -1041768139;
				num8 = num;
			}
		}
		goto IL_0038;
		IL_0300:
		int num9;
		if (iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			num = -1041768149;
			num9 = num;
		}
		else
		{
			num = -1041768175;
			num9 = num;
		}
		goto IL_003d;
		IL_052e:
		int num10;
		if (iCHfJOokhzcuDNRrJJjxFiRoOez.vsNzKyIocFQEgFvIpUOofhdTyKf == ControllerElementType.Axis)
		{
			num = -1041768153;
			num10 = num;
		}
		else
		{
			num = -1041768160;
			num10 = num;
		}
		goto IL_003d;
		IL_0177:
		if (!P_0)
		{
			return;
		}
		goto IL_058e;
		IL_03a1:
		YxGcqLJUUXPyrdhtgaNwEKQsryz(ref PjLJMXIKapkOORmRqiCDVeYZXON, iCHfJOokhzcuDNRrJJjxFiRoOez.xIxmveJFHALIQlAbQKeZFlFXGNXb);
		num = -1041768164;
		goto IL_003d;
		IL_058e:
		if (DWtikjUsIcMygopEQCtsKOPGzOj == xIGfpqgWCweHPAdLzHgdWJlegxo)
		{
			goto IL_01c5;
		}
		DWtikjUsIcMygopEQCtsKOPGzOj = xIGfpqgWCweHPAdLzHgdWJlegxo;
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			BvNFsFOgLyFWJQOUfAIznwfyrOx();
			ItpkyJFceFDcyqWdivzqwxwYDOd();
			num = -1041768173;
			goto IL_003d;
		}
		goto IL_04bc;
		IL_01c5:
		iCHfJOokhzcuDNRrJJjxFiRoOez = uLnGATJxtCMMwIomAUpvQoOiqrAB;
		ouusLSVThShOJXeTBDNomJoAhtU = iCHfJOokhzcuDNRrJJjxFiRoOez.fGOEgVenBQpynjDLaZtrcIyVGYbg.ouusLSVThShOJXeTBDNomJoAhtU;
		VxfxWwojnjsTKgBwHEZwcsjHkOL(iCHfJOokhzcuDNRrJJjxFiRoOez.djSTCtuXfIOUkuKgYhEAmyFNWUJ, iCHfJOokhzcuDNRrJJjxFiRoOez.PVhoJNjtQFhTjmwRsuJhvQWcbfU, iCHfJOokhzcuDNRrJJjxFiRoOez.fGOEgVenBQpynjDLaZtrcIyVGYbg);
		if (iCHfJOokhzcuDNRrJJjxFiRoOez.vsNzKyIocFQEgFvIpUOofhdTyKf != ControllerElementType.Button)
		{
			goto IL_052e;
		}
		if (iCHfJOokhzcuDNRrJJjxFiRoOez.cUQIKmCWCTtljuBzlMLzsXdMITP)
		{
			int num11;
			if (iCHfJOokhzcuDNRrJJjxFiRoOez.fGOEgVenBQpynjDLaZtrcIyVGYbg._axisContribution != Pole.Positive)
			{
				num = -1041768147;
				num11 = num;
			}
			else
			{
				num = -1041768165;
				num11 = num;
			}
			goto IL_003d;
		}
		goto IL_054a;
	}

	private void kKnDIMCUMfujlOLhmtdUwOeANpgB(ICHfJOokhzcuDNRrJJjxFiRoOez P_0, float P_1)
	{
		float num = P_0.ZTonADnXjOPnKfCdZaXyKwbxjUQ * P_1;
		if (!P_0.RdKSAPkXdqZfjulywPLEyeTNmOd)
		{
			goto IL_00d2;
		}
		if (P_0.zGQxodzogwFhSdbMgELkcWlbngKQ != AxisCoordinateMode.Absolute)
		{
			goto IL_00ee;
		}
		if (ORqghGsnIOzpWTjzWWOIBlFpjDc == AxisCoordinateMode.Absolute)
		{
			XzFvVccgxrRvVLVEsJsuiEzGckL += num;
		}
		goto IL_0129;
		IL_00ee:
		if (P_0.zGQxodzogwFhSdbMgELkcWlbngKQ != AxisCoordinateMode.Relative)
		{
			goto IL_0129;
		}
		int num2;
		if (ORqghGsnIOzpWTjzWWOIBlFpjDc != AxisCoordinateMode.Relative)
		{
			XzFvVccgxrRvVLVEsJsuiEzGckL = num;
			ORqghGsnIOzpWTjzWWOIBlFpjDc = AxisCoordinateMode.Relative;
			num2 = -1221385858;
			goto IL_0042;
		}
		goto IL_0146;
		IL_0146:
		XzFvVccgxrRvVLVEsJsuiEzGckL = MathTools.MaxMagnitude(XzFvVccgxrRvVLVEsJsuiEzGckL, num);
		num2 = -1221385858;
		goto IL_0042;
		IL_00d2:
		int num3;
		if (P_0.zGQxodzogwFhSdbMgELkcWlbngKQ != AxisCoordinateMode.Absolute)
		{
			num2 = -1221385859;
			num3 = num2;
		}
		else
		{
			num2 = -1221385857;
			num3 = num2;
		}
		goto IL_0042;
		IL_0129:
		ghCfcofoArKxaOqHJrpsAIsXJtEf(P_0, LflDuUhkdWkUJqTTfvjviPFwfEt.buttonDeadZone, false);
		num2 = -1221385868;
		goto IL_0042;
		IL_0042:
		while (true)
		{
			switch (num2 ^ -1221385868)
			{
			case 2:
				num2 = -1221385867;
				continue;
			default:
				return;
			case 3:
				if (AKFnwQcqzIoiisPliXCPoffYBoV != AxisCoordinateMode.Relative)
				{
					lGgKZtedwWZTeeRokjmlFjkKmac = num;
					AKFnwQcqzIoiisPliXCPoffYBoV = AxisCoordinateMode.Relative;
					num2 = -1221385864;
					continue;
				}
				goto IL_018e;
			case 12:
				num2 = -1221385858;
				continue;
			case 4:
				num2 = -1221385858;
				continue;
			case 9:
				break;
			case 5:
				goto end_IL_0042;
			case 1:
				goto IL_00ee;
			case 7:
				lGgKZtedwWZTeeRokjmlFjkKmac = num;
				num2 = -1221385858;
				continue;
			case 10:
				goto IL_0129;
			case 8:
				goto IL_0146;
			case 11:
				if (AKFnwQcqzIoiisPliXCPoffYBoV == AxisCoordinateMode.Absolute && MathTools.Abs(num) > MathTools.Abs(lGgKZtedwWZTeeRokjmlFjkKmac))
				{
					lGgKZtedwWZTeeRokjmlFjkKmac = num;
					num2 = -1221385872;
					continue;
				}
				goto IL_0129;
			case 6:
				goto IL_018e;
			case 0:
				return;
			}
			int num4;
			if (P_0.zGQxodzogwFhSdbMgELkcWlbngKQ == AxisCoordinateMode.Relative)
			{
				num2 = -1221385865;
				num4 = num2;
			}
			else
			{
				num2 = -1221385858;
				num4 = num2;
			}
			continue;
			IL_018e:
			int num5;
			if (MathTools.Abs(num) > MathTools.Abs(lGgKZtedwWZTeeRokjmlFjkKmac))
			{
				num2 = -1221385869;
				num5 = num2;
			}
			else
			{
				num2 = -1221385858;
				num5 = num2;
			}
			continue;
			end_IL_0042:
			break;
		}
		goto IL_00d2;
	}

	private void ghCfcofoArKxaOqHJrpsAIsXJtEf(ICHfJOokhzcuDNRrJJjxFiRoOez P_0, float P_1, bool P_2)
	{
		TPMFcoEHIkgRwgYCZiOxPisuuhx tPMFcoEHIkgRwgYCZiOxPisuuhx = TPMFcoEHIkgRwgYCZiOxPisuuhx.RZsMjSvFIWRybHqIPQFzJqYOXMP(P_0.fGOEgVenBQpynjDLaZtrcIyVGYbg.tqPurZpByiUWRrPJKwHxxaZZua);
		if (P_0.fGOEgVenBQpynjDLaZtrcIyVGYbg._axisRange == AxisRange.Full)
		{
			if (MathTools.Abs(P_0.ZTonADnXjOPnKfCdZaXyKwbxjUQ) > P_1)
			{
				goto IL_0032;
			}
			goto IL_0224;
		}
		goto IL_023e;
		IL_00bc:
		int num;
		if (MathTools.Abs(P_0.ZTonADnXjOPnKfCdZaXyKwbxjUQ) > P_1)
		{
			tPMFcoEHIkgRwgYCZiOxPisuuhx.oZUPvLyHwMFVphBRObxGwbDQxka(VesEEfGzljjgDkIPFVAOckifeaEO, false);
			num = -1983397231;
			goto IL_0037;
		}
		goto IL_0183;
		IL_0032:
		num = -1983397230;
		goto IL_0037;
		IL_0037:
		ButtonStateFlags buttonStateFlags3 = default(ButtonStateFlags);
		ButtonStateFlags buttonStateFlags2 = default(ButtonStateFlags);
		ButtonStateFlags buttonStateFlags = default(ButtonStateFlags);
		while (true)
		{
			switch (num ^ -1983397229)
			{
			case 11:
				break;
			default:
				return;
			case 1:
				tPMFcoEHIkgRwgYCZiOxPisuuhx.oZUPvLyHwMFVphBRObxGwbDQxka(VesEEfGzljjgDkIPFVAOckifeaEO, P_0.ZTonADnXjOPnKfCdZaXyKwbxjUQ > 0f);
				num = -1983397226;
				continue;
			case 13:
				tPMFcoEHIkgRwgYCZiOxPisuuhx.oZUPvLyHwMFVphBRObxGwbDQxka(VesEEfGzljjgDkIPFVAOckifeaEO, true);
				num = -1983397229;
				continue;
			case 3:
				goto IL_00bc;
			case 10:
				if (P_0.ZTonADnXjOPnKfCdZaXyKwbxjUQ != 0f)
				{
					rjZHDGEvejAzURgCpWJDHmczHobi += (int)(1f * MathTools.Sign(P_0.ZTonADnXjOPnKfCdZaXyKwbxjUQ));
					antQtESuXatVyiyPDTOYncyTcREI.dhodbseVbYqPVvdUgNSOeWdaMYFi(P_0);
					num = -1983397228;
					continue;
				}
				goto case 7;
			case 14:
				goto IL_0129;
			case 15:
				YxGcqLJUUXPyrdhtgaNwEKQsryz(ref PjLJMXIKapkOORmRqiCDVeYZXON, buttonStateFlags3);
				if (P_2)
				{
					if ((buttonStateFlags2 & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
					{
						goto case 10;
					}
					goto IL_016a;
				}
				return;
			case 2:
				goto IL_0183;
			case 8:
				YxGcqLJUUXPyrdhtgaNwEKQsryz(ref qswlCffYfyhmwWPzuwjhEuGltZD, buttonStateFlags2);
				num = -1983397220;
				continue;
			case 4:
				if ((buttonStateFlags & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
				{
					izyzedVSfTbnnSpIjbaBLvtAqyf = true;
					num = -1983397227;
					continue;
				}
				return;
			case 12:
				rjZHDGEvejAzURgCpWJDHmczHobi += (int)(1f * MathTools.Sign(P_0.ZTonADnXjOPnKfCdZaXyKwbxjUQ));
				antQtESuXatVyiyPDTOYncyTcREI.dhodbseVbYqPVvdUgNSOeWdaMYFi(P_0);
				num = -1983397225;
				continue;
			case 0:
				buttonStateFlags = tPMFcoEHIkgRwgYCZiOxPisuuhx.qArttHbHjNjbQjzvgyzPrIWrMYrJ(true);
				YxGcqLJUUXPyrdhtgaNwEKQsryz(ref qswlCffYfyhmwWPzuwjhEuGltZD, buttonStateFlags);
				num = -1983397219;
				continue;
			case 5:
				goto IL_0224;
			case 9:
				goto IL_023e;
			case 7:
				izyzedVSfTbnnSpIjbaBLvtAqyf = true;
				return;
			case 6:
				return;
			}
			break;
			IL_016a:
			int num2;
			if ((buttonStateFlags3 & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
			{
				num = -1983397223;
				num2 = num;
			}
			else
			{
				num = -1983397227;
				num2 = num;
			}
			continue;
			IL_0129:
			if (P_2)
			{
				int num3;
				if (P_0.ZTonADnXjOPnKfCdZaXyKwbxjUQ == 0f)
				{
					num = -1983397225;
					num3 = num;
				}
				else
				{
					num = -1983397217;
					num3 = num;
				}
				continue;
			}
			return;
		}
		goto IL_0032;
		IL_0183:
		buttonStateFlags = tPMFcoEHIkgRwgYCZiOxPisuuhx.qArttHbHjNjbQjzvgyzPrIWrMYrJ(false);
		YxGcqLJUUXPyrdhtgaNwEKQsryz(ref PjLJMXIKapkOORmRqiCDVeYZXON, buttonStateFlags);
		num = -1983397219;
		goto IL_0037;
		IL_023e:
		if (P_0.fGOEgVenBQpynjDLaZtrcIyVGYbg._axisContribution == Pole.Positive)
		{
			int num4;
			if (P_0.ZTonADnXjOPnKfCdZaXyKwbxjUQ > P_1)
			{
				num = -1983397218;
				num4 = num;
			}
			else
			{
				num = -1983397229;
				num4 = num;
			}
			goto IL_0037;
		}
		goto IL_00bc;
		IL_0224:
		buttonStateFlags2 = tPMFcoEHIkgRwgYCZiOxPisuuhx.qArttHbHjNjbQjzvgyzPrIWrMYrJ(true);
		buttonStateFlags3 = tPMFcoEHIkgRwgYCZiOxPisuuhx.qArttHbHjNjbQjzvgyzPrIWrMYrJ(false);
		num = -1983397221;
		goto IL_0037;
	}

	internal void tIzIDvReItXvpclLGxghMMTtfSbf()
	{
		if (xnIjJWjcKSmgvhmmqLIbdNVFprh != xIGfpqgWCweHPAdLzHgdWJlegxo)
		{
			EobBEOKOMxGhZjszeEmLccSbrTvA(false);
			goto IL_0017;
		}
		goto IL_00cb;
		IL_00cb:
		if (LFjEkChFNlIHcQOEePsxvVBzeeq == iIesQmHJYNaOjZySNFbyVCRRARUD.rltKKHXEwzFMSJClACISKvHcbDw)
		{
			return;
		}
		goto IL_01ee;
		IL_0017:
		int num = -1456838819;
		goto IL_001c;
		IL_001c:
		dYRIeKPTuahZpRFNFjLvIjmtuLF.LWeWeaWQnNRVbNGFAMkXDlgHvBD fSpdVoeWhOYoAilpUehbSxUxANDS = default(dYRIeKPTuahZpRFNFjLvIjmtuLF.LWeWeaWQnNRVbNGFAMkXDlgHvBD);
		bool flag = default(bool);
		while (true)
		{
			switch (num ^ -1456838820)
			{
			case 12:
				break;
			default:
				return;
			case 3:
				goto IL_0074;
			case 8:
				fSpdVoeWhOYoAilpUehbSxUxANDS.ISgWeYGbWKoagTPpdEHHGPrxuYRR = PQIPLPomQpZcuHEisekdJQysEOHI;
				fSpdVoeWhOYoAilpUehbSxUxANDS.zGQxodzogwFhSdbMgELkcWlbngKQ = AxisCoordinateMode.Relative;
				num = -1456838829;
				continue;
			case 16:
				goto IL_00cb;
			case 11:
				zGHtBzMNGjQhtlMjOIJgJLWhOKUe();
				num = -1456838835;
				continue;
			case 6:
				QNbBHFyvdyeNcyUBVVkEPYHmQBa();
				fSpdVoeWhOYoAilpUehbSxUxANDS.qztkUWsNKhLJHziDHiYYwDkwQxc(kPcECEntishmGKJfubVhUXmQHws);
				if (fSpdVoeWhOYoAilpUehbSxUxANDS.iwjBIJKCpojdFHZNErKamSiLdkpw != null)
				{
					flag = oZGkdirXpZzYmKFNsuTRsuXrwby();
					num = -1456838827;
					continue;
				}
				goto IL_0074;
			case 13:
				fSpdVoeWhOYoAilpUehbSxUxANDS.zGQxodzogwFhSdbMgELkcWlbngKQ = AKFnwQcqzIoiisPliXCPoffYBoV;
				num = -1456838829;
				continue;
			case 4:
				if (lGgKZtedwWZTeeRokjmlFjkKmac != 0f)
				{
					fSpdVoeWhOYoAilpUehbSxUxANDS.ISgWeYGbWKoagTPpdEHHGPrxuYRR = lGgKZtedwWZTeeRokjmlFjkKmac;
					num = -1456838831;
					continue;
				}
				goto case 0;
			case 9:
				if (flag)
				{
					fSpdVoeWhOYoAilpUehbSxUxANDS.iwjBIJKCpojdFHZNErKamSiLdkpw.Start(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonDownBuffer);
					num = -1456838818;
					continue;
				}
				goto case 2;
			case 1:
				return;
			case 17:
				goto IL_018a;
			case 0:
			{
				float iSgWeYGbWKoagTPpdEHHGPrxuYRR = MathTools.Clamp(XzFvVccgxrRvVLVEsJsuiEzGckL, -1f, 1f);
				fSpdVoeWhOYoAilpUehbSxUxANDS.ISgWeYGbWKoagTPpdEHHGPrxuYRR = iSgWeYGbWKoagTPpdEHHGPrxuYRR;
				fSpdVoeWhOYoAilpUehbSxUxANDS.zGQxodzogwFhSdbMgELkcWlbngKQ = ORqghGsnIOzpWTjzWWOIBlFpjDc;
				num = -1456838829;
				continue;
			}
			case 5:
				goto IL_01ee;
			case 15:
				if (DLHGCUwxrnqaSbPQXXmMcOxJaIt)
				{
					fSpdVoeWhOYoAilpUehbSxUxANDS.UwKaGawaRAIpOHPkRndmiaegboT();
					DLHGCUwxrnqaSbPQXXmMcOxJaIt = false;
					num = -1456838822;
					continue;
				}
				goto case 6;
			case 2:
				if (dMkHkQVQEzARCwhxyNIMqzlcVei())
				{
					fSpdVoeWhOYoAilpUehbSxUxANDS.TPYDESrsYTdFzxMpWNTOjljNQkD.Start(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonDownBuffer);
					num = -1456838817;
					continue;
				}
				goto IL_0074;
			case 7:
				EobBEOKOMxGhZjszeEmLccSbrTvA(true);
				num = -1456838830;
				continue;
			case 10:
				goto IL_0271;
			case 14:
				return;
			}
			break;
			IL_0271:
			fSpdVoeWhOYoAilpUehbSxUxANDS.TCkDheBvUNZXHuPBukvmMYToJYZo = PjLJMXIKapkOORmRqiCDVeYZXON;
			int num2;
			if (PQIPLPomQpZcuHEisekdJQysEOHI == 0f)
			{
				num = -1456838824;
				num2 = num;
			}
			else
			{
				num = -1456838828;
				num2 = num;
			}
			continue;
			IL_018a:
			if (DWtikjUsIcMygopEQCtsKOPGzOj != xIGfpqgWCweHPAdLzHgdWJlegxo)
			{
				int num3;
				if (!cDthJAVgLSQoYKgKKbsijgxWPfPA.MPCsQwPpPDVyKfKRKjkcHfbpjck())
				{
					num = -1456838830;
					num3 = num;
				}
				else
				{
					num = -1456838821;
					num3 = num;
				}
				continue;
			}
			return;
			IL_0074:
			fSpdVoeWhOYoAilpUehbSxUxANDS.bhawNHEfnlGmlCzdQKAGkCudDoqY(onTOiISwdiwnVPNqdGBZbNYGehbR(), jFcZHuafkqlzijBvuFElJkopdfY(), GispJZAEfezEtdemUKdarjXvYVi(), GjQmURQfLsUJtlDpxsliLlcucXv());
			int num4;
			if (pPudpEAbRTjSpfJnIIIXufNwTYY)
			{
				num = -1456838825;
				num4 = num;
			}
			else
			{
				num = -1456838835;
				num4 = num;
			}
		}
		goto IL_0017;
		IL_01ee:
		fSpdVoeWhOYoAilpUehbSxUxANDS = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS;
		fSpdVoeWhOYoAilpUehbSxUxANDS.xIxmveJFHALIQlAbQKeZFlFXGNXb = qswlCffYfyhmwWPzuwjhEuGltZD;
		num = -1456838826;
		goto IL_001c;
	}

	internal void QNbBHFyvdyeNcyUBVVkEPYHmQBa()
	{
		if (antQtESuXatVyiyPDTOYncyTcREI.lTkuXDpBpsLxRBVaGMtdDZauGbI)
		{
			cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.jSBEaifIKToDkCppGmLcJGMnBkD.dhodbseVbYqPVvdUgNSOeWdaMYFi(antQtESuXatVyiyPDTOYncyTcREI);
			goto IL_002b;
		}
		goto IL_040b;
		IL_040b:
		cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.maGkRMGuBZIYxDSgIqpaczpxMSZ = MathTools.Clamp(rjZHDGEvejAzURgCpWJDHmczHobi, -1f, 1f);
		int num;
		int num2;
		if (!LflDuUhkdWkUJqTTfvjviPFwfEt.digitalAxisSimulation)
		{
			num = 1575385072;
			num2 = num;
		}
		else
		{
			num = 1575385063;
			num2 = num;
		}
		goto IL_0030;
		IL_002b:
		num = 1575385056;
		goto IL_0030;
		IL_0030:
		float num4 = default(float);
		float num7 = default(float);
		float num9 = default(float);
		float digitalAxisGravity = default(float);
		float num6 = default(float);
		float digitalAxisSensitivity = default(float);
		while (true)
		{
			float num8;
			float num3;
			switch (num ^ 0x5DE677F5)
			{
			case 6:
				break;
			default:
				return;
			case 16:
				num4 += cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf;
				num = 1575385057;
				continue;
			case 10:
				if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf == 0f)
				{
					goto case 16;
				}
				goto IL_00ce;
			case 11:
				if (num7 == num9)
				{
					num = 1575385082;
					continue;
				}
				goto IL_030d;
			case 14:
				if (digitalAxisGravity != 0f)
				{
					num6 = LflDuUhkdWkUJqTTfvjviPFwfEt.digitalAxisGravity * RsvJXtZKfDCUPOixtNBmDnRVdUu;
					if (MathTools.Abs(num6) >= MathTools.Abs(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf))
					{
						cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf = 0f;
						num = 1575385062;
						continue;
					}
					goto case 12;
				}
				return;
			case 9:
				if (digitalAxisSensitivity > 0f)
				{
					num4 *= digitalAxisSensitivity * RsvJXtZKfDCUPOixtNBmDnRVdUu;
					num = 1575385087;
					continue;
				}
				goto case 10;
			case 12:
			{
				float num5 = ((cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf > 0f) ? (-1f) : 1f);
				cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf = MathTools.Clamp(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf + num5 * num6, -1f, 1f);
				pAbmAVcsPcjQUSUHsDdzTqGMLSN jSBEaifIKToDkCppGmLcJGMnBkD = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.jSBEaifIKToDkCppGmLcJGMnBkD;
				VxfxWwojnjsTKgBwHEZwcsjHkOL(jSBEaifIKToDkCppGmLcJGMnBkD.djSTCtuXfIOUkuKgYhEAmyFNWUJ, jSBEaifIKToDkCppGmLcJGMnBkD.PVhoJNjtQFhTjmwRsuJhvQWcbfU, jSBEaifIKToDkCppGmLcJGMnBkD.fGOEgVenBQpynjDLaZtrcIyVGYbg);
				num = 1575385060;
				continue;
			}
			case 2:
				return;
			case 7:
				if (!LflDuUhkdWkUJqTTfvjviPFwfEt.digitalAxisSnap)
				{
					num4 += cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf;
					num = 1575385057;
					continue;
				}
				goto case 20;
			case 0:
				num8 = 0f;
				goto IL_025a;
			case 4:
				cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.jSBEaifIKToDkCppGmLcJGMnBkD.tAgADqjTsMUxSqYXeDyJIdETYRAp();
				num = 1575385079;
				continue;
			case 18:
				if (!izyzedVSfTbnnSpIjbaBLvtAqyf)
				{
					if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf != 0f)
					{
						digitalAxisGravity = LflDuUhkdWkUJqTTfvjviPFwfEt.digitalAxisGravity;
						num = 1575385083;
						continue;
					}
					return;
				}
				goto case 8;
			case 8:
				num4 = MathTools.Clamp(rjZHDGEvejAzURgCpWJDHmczHobi, -1f, 1f);
				if (num4 == 0f)
				{
					num = 1575385076;
					continue;
				}
				num3 = MathTools.Sign(num4);
				goto IL_03e5;
			case 17:
				return;
			case 15:
				if (false)
				{
					goto IL_030d;
				}
				goto case 13;
			case 20:
				cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf = MathTools.Clamp(num4, -1f, 1f);
				num = 1575385078;
				continue;
			case 5:
				goto IL_036d;
			case 13:
				num4 += cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf;
				num = 1575385057;
				continue;
			case 1:
				num3 = 0f;
				goto IL_03e5;
			case 21:
				goto IL_040b;
			case 19:
				cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.jSBEaifIKToDkCppGmLcJGMnBkD.tAgADqjTsMUxSqYXeDyJIdETYRAp();
				return;
			case 3:
				return;
				IL_030d:
				if (LflDuUhkdWkUJqTTfvjviPFwfEt.digitalAxisInstantReverse)
				{
					num4 += -1f * cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf;
					num = 1575385057;
					continue;
				}
				goto case 7;
				IL_03e5:
				num7 = num3;
				if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf != 0f)
				{
					num8 = MathTools.Sign(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf);
					goto IL_025a;
				}
				num = 1575385077;
				continue;
				IL_025a:
				num9 = num8;
				digitalAxisSensitivity = LflDuUhkdWkUJqTTfvjviPFwfEt.digitalAxisSensitivity;
				num = 1575385084;
				continue;
			}
			break;
			IL_036d:
			cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.maGkRMGuBZIYxDSgIqpaczpxMSZ;
			int num10;
			if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.jSBEaifIKToDkCppGmLcJGMnBkD.lTkuXDpBpsLxRBVaGMtdDZauGbI)
			{
				num = 1575385073;
				num10 = num;
			}
			else
			{
				num = 1575385079;
				num10 = num;
			}
			continue;
			IL_00ce:
			int num11;
			if (num4 == 0f)
			{
				num = 1575385082;
				num11 = num;
			}
			else
			{
				num = 1575385086;
				num11 = num;
			}
		}
		goto IL_002b;
	}

	public float yVcOttFFFEXExGWTsiXvWxyyabi()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return 0f;
		}
		if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.zGQxodzogwFhSdbMgELkcWlbngKQ == AxisCoordinateMode.Relative)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.ISgWeYGbWKoagTPpdEHHGPrxuYRR;
		}
		return MathTools.MaxMagnitude(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.ISgWeYGbWKoagTPpdEHHGPrxuYRR, cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf);
	}

	public float AjecSoCdxZoJeYzNvEDytVvgsEaJ()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return 0f;
		}
		if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.cwFUgmCqjNPyQuCTJiUUDfoThWW == AxisCoordinateMode.Relative)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.dQzJVUgnJcRcYMJUkgvewqvuEKY;
		}
		return MathTools.MaxMagnitude(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.dQzJVUgnJcRcYMJUkgvewqvuEKY, cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.YpjRQEgxAOijiUlOxRAkFwEablZ);
	}

	public float oYgeGHftjGZemfpNfwEWJCsRGMwE()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return 0f;
		}
		return yVcOttFFFEXExGWTsiXvWxyyabi() - AjecSoCdxZoJeYzNvEDytVvgsEaJ();
	}

	public double pnsYwPcqyvIXnAxIQsTGkFUBcPve()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return 0.0;
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.vAxisTimeActive;
	}

	public double xoCMbnnjEoKFVDEPaFkHfuognYAb()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			xUAywlemzqjidyuSIeROMZQVjdl();
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.vAxisTimeInactive;
	}

	public AxisCoordinateMode aSYVmNRIYhecyIAPVoNUAKmGqzS()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.ISgWeYGbWKoagTPpdEHHGPrxuYRR) >= MathTools.Abs(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.IZGHexaYkySLlWceVEvUjanxguf))
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.zGQxodzogwFhSdbMgELkcWlbngKQ;
		}
		return AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode YwUFRVveorVzccyqCSTNhByjoIZ()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			goto IL_0008;
		}
		int num;
		if (MathTools.Abs(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.dQzJVUgnJcRcYMJUkgvewqvuEKY) >= MathTools.Abs(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.YpjRQEgxAOijiUlOxRAkFwEablZ))
		{
			num = 1172407795;
			goto IL_000d;
		}
		return AxisCoordinateMode.Absolute;
		IL_0008:
		num = 1172407792;
		goto IL_000d;
		IL_000d:
		switch (num ^ 0x45E185F1)
		{
		case 0:
			break;
		case 1:
			return AxisCoordinateMode.Absolute;
		default:
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.cwFUgmCqjNPyQuCTJiUUDfoThWW;
		}
		goto IL_0008;
	}

	public float jyWAvEiMviYlVTYdFOaVHgfjpXc()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return 0f;
		}
		if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.zGQxodzogwFhSdbMgELkcWlbngKQ == AxisCoordinateMode.Relative)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.ISgWeYGbWKoagTPpdEHHGPrxuYRR;
		}
		return MathTools.MaxMagnitude(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.ISgWeYGbWKoagTPpdEHHGPrxuYRR, cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.maGkRMGuBZIYxDSgIqpaczpxMSZ);
	}

	public float oGbFPxyeivBtXNjbFKjlfCTbxSU()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return 0f;
		}
		if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.cwFUgmCqjNPyQuCTJiUUDfoThWW == AxisCoordinateMode.Relative)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.dQzJVUgnJcRcYMJUkgvewqvuEKY;
		}
		return MathTools.MaxMagnitude(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.dQzJVUgnJcRcYMJUkgvewqvuEKY, cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.tMTpKfYTojxsaqdtvhLjTdeKudk);
	}

	public float VobczBXzqxfTuADGjnIpEbruYfh()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return 0f;
		}
		return jyWAvEiMviYlVTYdFOaVHgfjpXc() - oGbFPxyeivBtXNjbFKjlfCTbxSU();
	}

	public double crMWdnRmMtgSwRxUgJWcAGKBEoDe()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return 0.0;
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.vAxisRawTimeActive;
	}

	public double asasiuXJlxkXcFOVeQKYEktBLEv()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			while (true)
			{
				int num = -213816960;
				while (true)
				{
					switch (num ^ -213816958)
					{
					case 0:
						break;
					case 2:
						xUAywlemzqjidyuSIeROMZQVjdl();
						num = -213816957;
						continue;
					default:
						goto end_IL_0008;
					}
					break;
				}
				continue;
				end_IL_0008:
				break;
			}
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.vAxisRawTimeInactive;
	}

	public AxisCoordinateMode TnmqhZHaNDxwUFmndmEcharqzNo()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.ISgWeYGbWKoagTPpdEHHGPrxuYRR) >= MathTools.Abs(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.maGkRMGuBZIYxDSgIqpaczpxMSZ))
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.zGQxodzogwFhSdbMgELkcWlbngKQ;
		}
		return AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode oGslYUNDIYdgjPfthVOmLGjYINl()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.dQzJVUgnJcRcYMJUkgvewqvuEKY) >= MathTools.Abs(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.tMTpKfYTojxsaqdtvhLjTdeKudk))
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.cwFUgmCqjNPyQuCTJiUUDfoThWW;
		}
		return AxisCoordinateMode.Absolute;
	}

	public bool jFcZHuafkqlzijBvuFElJkopdfY()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			return (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.xIxmveJFHALIQlAbQKeZFlFXGNXb & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != 0;
		}
		if ((cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.xIxmveJFHALIQlAbQKeZFlFXGNXb & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) == 0)
		{
			return GjQmURQfLsUJtlDpxsliLlcucXv();
		}
		return true;
	}

	public bool onTOiISwdiwnVPNqdGBZbNYGehbR()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.iwjBIJKCpojdFHZNErKamSiLdkpw == null)
		{
			return oZGkdirXpZzYmKFNsuTRsuXrwby();
		}
		if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.iwjBIJKCpojdFHZNErKamSiLdkpw.running)
		{
			return true;
		}
		if (voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue && cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.TPYDESrsYTdFzxMpWNTOjljNQkD.running)
		{
			return true;
		}
		return false;
	}

	public bool QNRTkSkGFuwIIacWXFtSgclWddbW()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			goto IL_0016;
		}
		if ((cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.xIxmveJFHALIQlAbQKeZFlFXGNXb & ButtonStateFlags.splhCJEXiNqkFWSDEanyDbxOmDQ) == 0 && (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.TCkDheBvUNZXHuPBukvmMYToJYZo & ButtonStateFlags.splhCJEXiNqkFWSDEanyDbxOmDQ) == 0)
		{
			return false;
		}
		int num;
		if ((cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.xIxmveJFHALIQlAbQKeZFlFXGNXb & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
		{
			num = -1087164997;
		}
		else
		{
			if ((cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.TCkDheBvUNZXHuPBukvmMYToJYZo & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) == 0)
			{
				return true;
			}
			num = -1087164998;
		}
		goto IL_001b;
		IL_001b:
		switch (num ^ -1087164998)
		{
		case 3:
			break;
		case 2:
			return (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.xIxmveJFHALIQlAbQKeZFlFXGNXb & ButtonStateFlags.splhCJEXiNqkFWSDEanyDbxOmDQ) != 0;
		case 1:
			return false;
		default:
			return false;
		}
		goto IL_0016;
		IL_0016:
		num = -1087165000;
		goto IL_001b;
	}

	public bool qTwZgHDTVAWJghKpsdDNNalKTRt()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			goto IL_0016;
		}
		int num;
		if (!cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.singlePressHold)
		{
			num = 1368762727;
			goto IL_001b;
		}
		return true;
		IL_001b:
		switch (num ^ 0x5195A965)
		{
		case 0:
			break;
		case 1:
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.singlePressHold;
		default:
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.singlePressHold;
		}
		goto IL_0016;
		IL_0016:
		num = 1368762724;
		goto IL_001b;
	}

	public bool rWGwOgpOlZtlVSGUSNQagovTRCe()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			goto IL_0008;
		}
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.singlePressDown;
		}
		bool singlePressDown = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.singlePressDown;
		bool singlePressDown2 = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.singlePressDown;
		int num = 1136350603;
		goto IL_000d;
		IL_0008:
		num = 1136350604;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x43BB5588)
			{
			case 0:
				break;
			case 1:
				if (!singlePressDown2)
				{
					return false;
				}
				goto IL_0036;
			case 3:
				if (!singlePressDown)
				{
					num = 1136350601;
					continue;
				}
				goto IL_0036;
			case 4:
				return false;
			default:
				{
					if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.singlePressHold)
					{
						return false;
					}
					goto IL_00dc;
				}
				IL_00dc:
				return true;
				IL_0036:
				if (!singlePressDown && cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.singlePressHold)
				{
					return false;
				}
				if (!singlePressDown2)
				{
					num = 1136350602;
					continue;
				}
				goto IL_00dc;
			}
			break;
		}
		goto IL_0008;
	}

	public bool ksFbLuWovwSusHlHjefsFuJGTK()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			goto IL_0016;
		}
		bool singlePressUp = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.singlePressUp;
		int num = 203797482;
		goto IL_001b;
		IL_001b:
		bool singlePressUp2 = default(bool);
		while (true)
		{
			switch (num ^ 0xC25B3EA)
			{
			case 3:
				break;
			case 1:
				return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.singlePressUp;
			case 0:
				singlePressUp2 = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.singlePressUp;
				num = 203797486;
				continue;
			case 4:
				if (!singlePressUp)
				{
					num = 203797480;
					continue;
				}
				goto IL_009b;
			default:
				{
					if (!singlePressUp2)
					{
						return false;
					}
					goto IL_009b;
				}
				IL_009b:
				if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.singlePressHold)
				{
					return false;
				}
				if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.singlePressHold)
				{
					return false;
				}
				return true;
			}
			break;
		}
		goto IL_0016;
		IL_0016:
		num = 203797483;
		goto IL_001b;
	}

	public bool iTwfkmbsmuNlVtrJSWahfnhaZvd()
	{
		return iTwfkmbsmuNlVtrJSWahfnhaZvd(0f);
	}

	public bool iTwfkmbsmuNlVtrJSWahfnhaZvd(float P_0)
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (P_0 > 0f)
		{
			if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
			{
				return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.oWKfobWWMrkqUtJRcFyyKGvSNSl.EpDukhFQGxRGHEYYKBbTcdhlpvF(P_0);
			}
			if (!cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.oWKfobWWMrkqUtJRcFyyKGvSNSl.EpDukhFQGxRGHEYYKBbTcdhlpvF(P_0))
			{
				return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.lvJMejPlUXLwNkPpqfvlFFjBbgZb.EpDukhFQGxRGHEYYKBbTcdhlpvF(P_0);
			}
			return true;
		}
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.doublePressHold;
		}
		if (!cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.doublePressHold)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.doublePressHold;
		}
		return true;
	}

	public bool WECszamZhCGBaugBWVuoFSBDSIn()
	{
		return WECszamZhCGBaugBWVuoFSBDSIn(0f);
	}

	public bool WECszamZhCGBaugBWVuoFSBDSIn(float P_0)
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (!onTOiISwdiwnVPNqdGBZbNYGehbR())
		{
			return false;
		}
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			if (P_0 > 0f)
			{
				return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.oWKfobWWMrkqUtJRcFyyKGvSNSl.EpDukhFQGxRGHEYYKBbTcdhlpvF(P_0);
			}
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.doublePressHold;
		}
		if (P_0 > 0f)
		{
			goto IL_005d;
		}
		int num;
		if (!cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.doublePressHold)
		{
			num = -777846219;
			goto IL_0062;
		}
		return true;
		IL_0062:
		while (true)
		{
			switch (num ^ -777846218)
			{
			case 0:
				break;
			case 2:
				if (!cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.oWKfobWWMrkqUtJRcFyyKGvSNSl.EpDukhFQGxRGHEYYKBbTcdhlpvF(P_0))
				{
					goto IL_0097;
				}
				return true;
			case 1:
				return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.lvJMejPlUXLwNkPpqfvlFFjBbgZb.EpDukhFQGxRGHEYYKBbTcdhlpvF(P_0);
			default:
				return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.doublePressHold;
			}
			break;
			IL_0097:
			num = -777846217;
		}
		goto IL_005d;
		IL_005d:
		num = -777846220;
		goto IL_0062;
	}

	public bool ZMCGeiorCsJPKHuHAAUEkrZDYOT()
	{
		return ZMCGeiorCsJPKHuHAAUEkrZDYOT(0f);
	}

	public bool ZMCGeiorCsJPKHuHAAUEkrZDYOT(float P_0)
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (!QNRTkSkGFuwIIacWXFtSgclWddbW())
		{
			return false;
		}
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			if (P_0 > 0f)
			{
				return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.oWKfobWWMrkqUtJRcFyyKGvSNSl.YFcwYsGHWUqJGAKCDAwJBuWCCNiR(P_0);
			}
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.doublePressUp;
		}
		if (P_0 > 0f)
		{
			if (!cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.oWKfobWWMrkqUtJRcFyyKGvSNSl.YFcwYsGHWUqJGAKCDAwJBuWCCNiR(P_0))
			{
				return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.lvJMejPlUXLwNkPpqfvlFFjBbgZb.YFcwYsGHWUqJGAKCDAwJBuWCCNiR(P_0);
			}
			return true;
		}
		if (!cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CaEXgkdxHSkoCebMwiwqGNiYqDc.doublePressUp)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.doublePressUp;
		}
		return true;
	}

	public bool wjcGKQZuBmrbfwBXXwRdXiTLDuF(float P_0)
	{
		return wjcGKQZuBmrbfwBXXwRdXiTLDuF(P_0, 0f);
	}

	public bool wjcGKQZuBmrbfwBXXwRdXiTLDuF(float P_0, float P_1)
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
			goto IL_0019;
		}
		goto IL_003f;
		IL_0084:
		double num = default(double);
		int num2;
		if (num < (double)P_0)
		{
			num2 = 673099292;
		}
		else
		{
			if (!(P_1 > 0f) || !(num >= (double)(P_0 + P_1)))
			{
				return true;
			}
			num2 = 673099289;
		}
		goto IL_001e;
		IL_003f:
		if (!jFcZHuafkqlzijBvuFElJkopdfY())
		{
			return false;
		}
		num = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.vButtonTimePressed;
		if (voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			num = MathTools.Max(num, cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.negativeVButtonTimePressed);
			num2 = 673099291;
			goto IL_001e;
		}
		goto IL_0084;
		IL_0019:
		num2 = 673099290;
		goto IL_001e;
		IL_001e:
		switch (num2 ^ 0x281EAE18)
		{
		case 0:
			break;
		case 2:
			goto IL_003f;
		case 3:
			goto IL_0084;
		case 4:
			return false;
		default:
			return false;
		}
		goto IL_0019;
	}

	public bool miEXqrPenrbMiQxgAmdPATywugk(float P_0)
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			goto IL_0008;
		}
		int num;
		ButtonStateRecorder oWKfobWWMrkqUtJRcFyyKGvSNSl = default(ButtonStateRecorder);
		ButtonStateRecorder lvJMejPlUXLwNkPpqfvlFFjBbgZb = default(ButtonStateRecorder);
		if (P_0 <= 0f)
		{
			num = -919502416;
		}
		else
		{
			if (!jFcZHuafkqlzijBvuFElJkopdfY())
			{
				return false;
			}
			if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
			{
				num = -919502410;
			}
			else
			{
				oWKfobWWMrkqUtJRcFyyKGvSNSl = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.oWKfobWWMrkqUtJRcFyyKGvSNSl;
				lvJMejPlUXLwNkPpqfvlFFjBbgZb = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.lvJMejPlUXLwNkPpqfvlFFjBbgZb;
				num = -919502412;
			}
		}
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -919502411)
			{
			case 4:
				break;
			case 2:
				return false;
			case 3:
			{
				ButtonStateRecorder oWKfobWWMrkqUtJRcFyyKGvSNSl2 = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.oWKfobWWMrkqUtJRcFyyKGvSNSl;
				if (oWKfobWWMrkqUtJRcFyyKGvSNSl2.timePressed < (double)P_0)
				{
					num = -919502414;
					continue;
				}
				if (ReInput.unscaledTimePrev - oWKfobWWMrkqUtJRcFyyKGvSNSl2.lastTimeUnpressed >= (double)P_0)
				{
					return false;
				}
				return true;
			}
			case 5:
				return oZGkdirXpZzYmKFNsuTRsuXrwby();
			case 7:
				return false;
			case 1:
				if (oWKfobWWMrkqUtJRcFyyKGvSNSl.timePressed < (double)P_0)
				{
					num = -919502411;
					continue;
				}
				goto IL_00f9;
			case 0:
				if (lvJMejPlUXLwNkPpqfvlFFjBbgZb.timePressed < (double)P_0)
				{
					return false;
				}
				goto IL_00f9;
			default:
				{
					return false;
				}
				IL_00f9:
				if (!(ReInput.unscaledTimePrev - oWKfobWWMrkqUtJRcFyyKGvSNSl.lastTimeUnpressed >= (double)P_0))
				{
					if (ReInput.unscaledTimePrev - lvJMejPlUXLwNkPpqfvlFFjBbgZb.lastTimeUnpressed >= (double)P_0)
					{
						num = -919502413;
						continue;
					}
					return true;
				}
				goto default;
			}
			break;
		}
		goto IL_0008;
		IL_0008:
		num = -919502409;
		goto IL_000d;
	}

	public bool jmNRPvoFbexhblUyuiMQvmLaNaK(float P_0)
	{
		return jmNRPvoFbexhblUyuiMQvmLaNaK(P_0, 0f);
	}

	public bool jmNRPvoFbexhblUyuiMQvmLaNaK(float P_0, float P_1)
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			goto IL_0012;
		}
		goto IL_006e;
		IL_006e:
		if (!QNRTkSkGFuwIIacWXFtSgclWddbW())
		{
			return false;
		}
		int num;
		double num2 = default(double);
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			num = -788239818;
		}
		else
		{
			num2 = ReInput.unscaledTime - MathTools.Max(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.oWKfobWWMrkqUtJRcFyyKGvSNSl.lastTimeStateChangedToPressed, cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.lvJMejPlUXLwNkPpqfvlFFjBbgZb.lastTimeStateChangedToPressed);
			num = -788239817;
		}
		goto IL_0017;
		IL_0012:
		num = -788239823;
		goto IL_0017;
		IL_0017:
		double num3 = default(double);
		while (true)
		{
			switch (num ^ -788239821)
			{
			case 8:
				break;
			case 4:
				goto IL_004b;
			case 6:
				goto IL_006e;
			case 1:
				return false;
			case 0:
				return false;
			case 7:
				goto IL_00ea;
			case 2:
				P_0 = 0f;
				num = -788239819;
				continue;
			case 5:
				num3 = ReInput.unscaledTime - cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.oWKfobWWMrkqUtJRcFyyKGvSNSl.lastTimeStateChangedToPressed;
				num = -788239820;
				continue;
			default:
				return false;
			}
			break;
			IL_00ea:
			if (!(num3 < (double)P_0))
			{
				if (!(P_1 > 0f) || !(num3 >= (double)(P_0 + P_1)))
				{
					return true;
				}
				num = -788239822;
			}
			else
			{
				num = -788239821;
			}
			continue;
			IL_004b:
			if (num2 < (double)P_0)
			{
				return false;
			}
			if (P_1 > 0f && num2 >= (double)(P_0 + P_1))
			{
				num = -788239824;
				continue;
			}
			return true;
		}
		goto IL_0012;
	}

	public bool rcyyMPULmrKbLHvLwAnFfUFVPPR()
	{
		return wjcGKQZuBmrbfwBXXwRdXiTLDuF(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonShortPressTime, LflDuUhkdWkUJqTTfvjviPFwfEt.buttonShortPressExpiresIn);
	}

	public bool gYeTCyhGKkaVGgZezuemqGJatLX()
	{
		return miEXqrPenrbMiQxgAmdPATywugk(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonShortPressTime);
	}

	public bool SWCZiMymsQdLThvSsmwiALEkBbK()
	{
		return jmNRPvoFbexhblUyuiMQvmLaNaK(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonShortPressTime, LflDuUhkdWkUJqTTfvjviPFwfEt.buttonShortPressExpiresIn);
	}

	public bool npfgXZtKMFFklVbTJfFAvKLyliC()
	{
		return wjcGKQZuBmrbfwBXXwRdXiTLDuF(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonLongPressTime, LflDuUhkdWkUJqTTfvjviPFwfEt.buttonLongPressExpiresIn);
	}

	public bool uFlaryDYfyMDhMCsXKNCoPyChog()
	{
		return miEXqrPenrbMiQxgAmdPATywugk(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonLongPressTime);
	}

	public bool saoXXohfyQyJUwjpBiSVZjfdbXy()
	{
		return jmNRPvoFbexhblUyuiMQvmLaNaK(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonLongPressTime, LflDuUhkdWkUJqTTfvjviPFwfEt.buttonLongPressExpiresIn);
	}

	public bool XOsefyWDHwZOXjmpVlXGYKJafdt()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CHqsPXWgXsfififFoJsmIrqNaPc.state;
		}
		if (!cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CHqsPXWgXsfififFoJsmIrqNaPc.state)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.EfFAJaMxUzYEJGdeOWOuqMBcPMz.state;
		}
		return true;
	}

	public bool zzfmTHlfPMxAtELqZGBGFqlGwNnV()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			goto IL_0008;
		}
		int num;
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			num = 1960463190;
		}
		else
		{
			if ((cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.KJGcneJobXMEjwwXCKbwRANsQBA & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
			{
				return true;
			}
			num = 1960463191;
		}
		goto IL_000d;
		IL_000d:
		switch (num ^ 0x74DA4B56)
		{
		case 2:
			break;
		case 3:
			return false;
		case 0:
			return (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.KJGcneJobXMEjwwXCKbwRANsQBA & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != 0;
		default:
			return FyoNDogMdbcLjbRknabaNMHMibXI();
		}
		goto IL_0008;
		IL_0008:
		num = 1960463189;
		goto IL_000d;
	}

	public double GlbGvItEcsropotExwhQogMKCTc()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return 0.0;
		}
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.vButtonTimePressed;
		}
		return MathTools.Max(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.vButtonTimePressed, cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.negativeVButtonTimePressed);
	}

	public double ahmYllXzqpwHbQCxSzCLwkosRBZ()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			xUAywlemzqjidyuSIeROMZQVjdl();
		}
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.vButtonTimeUnpressed;
		}
		return MathTools.Min(cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.vButtonTimeUnpressed, cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.negativeVButtonTimeUnpressed);
	}

	private bool oZGkdirXpZzYmKFNsuTRsuXrwby()
	{
		if (!voLkponRBHpiQNHOfOdnrjJJatj.activateActionButtonsOnNegativeValue)
		{
			goto IL_000c;
		}
		if ((cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.xIxmveJFHALIQlAbQKeZFlFXGNXb & ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL) == 0 && (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.TCkDheBvUNZXHuPBukvmMYToJYZo & ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL) == 0)
		{
			return false;
		}
		int num;
		if ((cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.xIxmveJFHALIQlAbQKeZFlFXGNXb & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
		{
			num = 894771695;
			goto IL_0011;
		}
		goto IL_009e;
		IL_009e:
		if ((cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.TCkDheBvUNZXHuPBukvmMYToJYZo & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO && (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.TCkDheBvUNZXHuPBukvmMYToJYZo & ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL) == 0)
		{
			return false;
		}
		return true;
		IL_0011:
		switch (num ^ 0x355521EF)
		{
		case 2:
			break;
		case 1:
			return (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.xIxmveJFHALIQlAbQKeZFlFXGNXb & ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL) != 0;
		default:
			goto IL_0088;
		}
		goto IL_000c;
		IL_000c:
		num = 894771694;
		goto IL_0011;
		IL_0088:
		if ((cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.xIxmveJFHALIQlAbQKeZFlFXGNXb & ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL) == 0)
		{
			return false;
		}
		goto IL_009e;
	}

	public bool GjQmURQfLsUJtlDpxsliLlcucXv()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		return (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.TCkDheBvUNZXHuPBukvmMYToJYZo & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != 0;
	}

	public bool GispJZAEfezEtdemUKdarjXvYVi()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.TPYDESrsYTdFzxMpWNTOjljNQkD == null)
		{
			return dMkHkQVQEzARCwhxyNIMqzlcVei();
		}
		if (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.TPYDESrsYTdFzxMpWNTOjljNQkD.running)
		{
			return true;
		}
		return false;
	}

	public bool ZrNBCoHGXMCmZyMECcLNhxpdYovR()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		return (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.TCkDheBvUNZXHuPBukvmMYToJYZo & ButtonStateFlags.splhCJEXiNqkFWSDEanyDbxOmDQ) != 0;
	}

	public bool WfZeMfhNAoMJIXMavAKrtJsNDWbF()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.singlePressHold;
	}

	public bool RNCfZoiaVVeQzBKphLchHPwpEZqI()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.singlePressDown;
	}

	public bool zXrIaGSPAdFttfFXmjrycWpcxZhm()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.singlePressUp;
	}

	public bool OEdSYxLPfkelucpBeITTaFuMcTK()
	{
		return OEdSYxLPfkelucpBeITTaFuMcTK(0f);
	}

	public bool OEdSYxLPfkelucpBeITTaFuMcTK(float P_0)
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.lvJMejPlUXLwNkPpqfvlFFjBbgZb.EpDukhFQGxRGHEYYKBbTcdhlpvF(P_0);
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.doublePressHold;
	}

	public bool WvMfdYEiKbIIpujENcBAnywGvUbe()
	{
		return WvMfdYEiKbIIpujENcBAnywGvUbe(0f);
	}

	public bool WvMfdYEiKbIIpujENcBAnywGvUbe(float P_0)
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (!GispJZAEfezEtdemUKdarjXvYVi())
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.lvJMejPlUXLwNkPpqfvlFFjBbgZb.EpDukhFQGxRGHEYYKBbTcdhlpvF(P_0);
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.doublePressHold;
	}

	public bool ucXHXUUqxlkhvzJNWDPYfuRMgyD()
	{
		return ucXHXUUqxlkhvzJNWDPYfuRMgyD(0f);
	}

	public bool ucXHXUUqxlkhvzJNWDPYfuRMgyD(float P_0)
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (!ZrNBCoHGXMCmZyMECcLNhxpdYovR())
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.lvJMejPlUXLwNkPpqfvlFFjBbgZb.YFcwYsGHWUqJGAKCDAwJBuWCCNiR(P_0);
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.CdhmhOUjvKXhIEXEysSACjjWToy.doublePressUp;
	}

	public bool hgFujwoGsFfsjeIjlnOMWpEhXwA(float P_0)
	{
		return hgFujwoGsFfsjeIjlnOMWpEhXwA(P_0, 0f);
	}

	public bool hgFujwoGsFfsjeIjlnOMWpEhXwA(float P_0, float P_1)
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			goto IL_0008;
		}
		int num;
		if (P_0 < 0f)
		{
			P_0 = 0f;
			num = -688830453;
			goto IL_000d;
		}
		goto IL_0056;
		IL_000d:
		double negativeVButtonTimePressed = default(double);
		while (true)
		{
			switch (num ^ -688830449)
			{
			case 3:
				break;
			case 2:
				return false;
			case 0:
				goto IL_004a;
			case 4:
				goto IL_0056;
			case 5:
				return false;
			default:
				return false;
			}
			break;
			IL_004a:
			if (!(negativeVButtonTimePressed < (double)P_0))
			{
				if (!(P_1 > 0f) || !(negativeVButtonTimePressed >= (double)(P_0 + P_1)))
				{
					return true;
				}
				num = -688830450;
			}
			else
			{
				num = -688830451;
			}
		}
		goto IL_0008;
		IL_0056:
		if (!GjQmURQfLsUJtlDpxsliLlcucXv())
		{
			return false;
		}
		negativeVButtonTimePressed = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.negativeVButtonTimePressed;
		num = -688830449;
		goto IL_000d;
		IL_0008:
		num = -688830454;
		goto IL_000d;
	}

	public bool CDyaTaJIXcGhBvDctqVqeSYmNsx(float P_0)
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (P_0 <= 0f)
		{
			goto IL_0012;
		}
		if (!GjQmURQfLsUJtlDpxsliLlcucXv())
		{
			return false;
		}
		ButtonStateRecorder lvJMejPlUXLwNkPpqfvlFFjBbgZb = cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.lvJMejPlUXLwNkPpqfvlFFjBbgZb;
		int num = 1000155694;
		goto IL_0017;
		IL_0017:
		switch (num ^ 0x3B9D2A2E)
		{
		case 2:
			break;
		case 1:
			return dMkHkQVQEzARCwhxyNIMqzlcVei();
		default:
			if (lvJMejPlUXLwNkPpqfvlFFjBbgZb.timePressed < (double)P_0)
			{
				return false;
			}
			if (ReInput.unscaledTimePrev - lvJMejPlUXLwNkPpqfvlFFjBbgZb.lastTimeUnpressed >= (double)P_0)
			{
				return false;
			}
			return true;
		}
		goto IL_0012;
		IL_0012:
		num = 1000155695;
		goto IL_0017;
	}

	public bool DXkcQgzDXDwqfjqKEWeeiIsjEkL(float P_0)
	{
		return DXkcQgzDXDwqfjqKEWeeiIsjEkL(P_0, 0f);
	}

	public bool DXkcQgzDXDwqfjqKEWeeiIsjEkL(float P_0, float P_1)
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!ZrNBCoHGXMCmZyMECcLNhxpdYovR())
		{
			return false;
		}
		double num = ReInput.unscaledTime - cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.lvJMejPlUXLwNkPpqfvlFFjBbgZb.lastTimeStateChangedToPressed;
		if (num < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && num >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool PjVCYxGaFYdJXhjLQSraPNYqlkv()
	{
		return hgFujwoGsFfsjeIjlnOMWpEhXwA(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonShortPressTime, LflDuUhkdWkUJqTTfvjviPFwfEt.buttonShortPressExpiresIn);
	}

	public bool cGPAZhRoZybdYmPyydBfiaWgoJDG()
	{
		return CDyaTaJIXcGhBvDctqVqeSYmNsx(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonShortPressTime);
	}

	public bool ddscAWCaYKgqaGgjOFzIJWfzTjkO()
	{
		return DXkcQgzDXDwqfjqKEWeeiIsjEkL(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonShortPressTime, LflDuUhkdWkUJqTTfvjviPFwfEt.buttonShortPressExpiresIn);
	}

	public bool oMxTTcjOLMYEoYDddFPmgSxilnH()
	{
		return hgFujwoGsFfsjeIjlnOMWpEhXwA(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonLongPressTime, LflDuUhkdWkUJqTTfvjviPFwfEt.buttonLongPressExpiresIn);
	}

	public bool rcVJaTxSByOtwqWKUaiYAkfAyxL()
	{
		return CDyaTaJIXcGhBvDctqVqeSYmNsx(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonLongPressTime);
	}

	public bool jGCWDEuaegGYCmImHJEiHDpRWGB()
	{
		return DXkcQgzDXDwqfjqKEWeeiIsjEkL(LflDuUhkdWkUJqTTfvjviPFwfEt.buttonLongPressTime, LflDuUhkdWkUJqTTfvjviPFwfEt.buttonLongPressExpiresIn);
	}

	public bool ZxiIuRYtBDEJCMjqsaKVbuOFqEda()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.EfFAJaMxUzYEJGdeOWOuqMBcPMz.state;
	}

	public bool FyoNDogMdbcLjbRknabaNMHMibXI()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return false;
		}
		return (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.SfnTRaInXWDlkfNuIwVoUrDdUUv & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != 0;
	}

	public double dxkXhZgtdvRCHZnoEEZfzgZJXB()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			return 0.0;
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.negativeVButtonTimePressed;
	}

	public double bwACWmRNWMEBWqsttspcoPFcGyG()
	{
		if (!iAgWGEzWxcyhtWsopRkEhQeyLjM)
		{
			xUAywlemzqjidyuSIeROMZQVjdl();
		}
		return cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.negativeVButtonTimeUnpressed;
	}

	private bool dMkHkQVQEzARCwhxyNIMqzlcVei()
	{
		return (cDthJAVgLSQoYKgKKbsijgxWPfPA.fSpdVoeWhOYoAilpUehbSxUxANDS.TCkDheBvUNZXHuPBukvmMYToJYZo & ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL) != 0;
	}

	public void twrGhvMiEQBZXGGBxqjSCoiAcDyS()
	{
		int num = 0;
		while (true)
		{
			int num2 = -873827617;
			while (true)
			{
				switch (num2 ^ -873827618)
				{
				case 3:
					break;
				case 1:
					num2 = -873827620;
					continue;
				case 0:
					cDthJAVgLSQoYKgKKbsijgxWPfPA.ukQXiEKzTMzPimOeOTmWBVpgDWV[num].iwjBIJKCpojdFHZNErKamSiLdkpw.Clear();
					cDthJAVgLSQoYKgKKbsijgxWPfPA.ukQXiEKzTMzPimOeOTmWBVpgDWV[num].TPYDESrsYTdFzxMpWNTOjljNQkD.Clear();
					num++;
					num2 = -873827620;
					continue;
				default:
					if (num >= cDthJAVgLSQoYKgKKbsijgxWPfPA.ukQXiEKzTMzPimOeOTmWBVpgDWV.Length)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	internal InputActionEventData FpPQbxOMrhEGzNLvreAPpBwxuzz(UpdateLoopType P_0)
	{
		return new InputActionEventData(this, cNcLkMBaCDcdcMeoQVAxVFVuHEv, qxoYaUQyNIsvDIFklnqXHPrHJLd, P_0);
	}

	public IList<InputActionSourceData> IuoAwCWdCAjYeLqfbcSvMLYTuGV()
	{
		if (!pPudpEAbRTjSpfJnIIIXufNwTYY)
		{
			zGHtBzMNGjQhtlMjOIJgJLWhOKUe();
		}
		return dWoFBZFCUCrJKjLGoGmpzBrosCPb;
	}

	public bool adBGAlpCrTxrtgKicbPRkjxIekDn(ControllerType P_0)
	{
		if (!pPudpEAbRTjSpfJnIIIXufNwTYY)
		{
			IuoAwCWdCAjYeLqfbcSvMLYTuGV();
			goto IL_000f;
		}
		goto IL_0039;
		IL_0039:
		int num = 0;
		int num2 = 1678467914;
		goto IL_0014;
		IL_000f:
		num2 = 1678467912;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ 0x640B6349)
			{
			case 5:
				break;
			case 1:
				goto IL_0039;
			case 3:
				goto IL_0042;
			case 2:
				goto IL_005c;
			case 4:
				return true;
			default:
				return false;
			}
			break;
			IL_005c:
			if (vjPvUdKJEuOpgjbTbfbqjNFfTGr[num].djSTCtuXfIOUkuKgYhEAmyFNWUJ.type == P_0)
			{
				num2 = 1678467917;
				continue;
			}
			num++;
			num2 = 1678467914;
			continue;
			IL_0042:
			int num3;
			if (num < QuyolAEqbygmLbXHpafNEdszcaId)
			{
				num2 = 1678467915;
				num3 = num2;
			}
			else
			{
				num2 = 1678467913;
				num3 = num2;
			}
		}
		goto IL_000f;
	}

	public bool adBGAlpCrTxrtgKicbPRkjxIekDn(ControllerType P_0, int P_1)
	{
		if (!pPudpEAbRTjSpfJnIIIXufNwTYY)
		{
			IuoAwCWdCAjYeLqfbcSvMLYTuGV();
			goto IL_000f;
		}
		goto IL_0069;
		IL_0069:
		int num = 0;
		int num2 = 670061565;
		goto IL_0014;
		IL_000f:
		num2 = 670061566;
		goto IL_0014;
		IL_0014:
		Controller djSTCtuXfIOUkuKgYhEAmyFNWUJ = default(Controller);
		while (true)
		{
			switch (num2 ^ 0x27F053FD)
			{
			case 4:
				break;
			case 1:
				goto IL_0035;
			case 2:
				djSTCtuXfIOUkuKgYhEAmyFNWUJ = vjPvUdKJEuOpgjbTbfbqjNFfTGr[num].djSTCtuXfIOUkuKgYhEAmyFNWUJ;
				num2 = 670061564;
				continue;
			case 3:
				goto IL_0069;
			default:
				if (num >= QuyolAEqbygmLbXHpafNEdszcaId)
				{
					return false;
				}
				goto case 2;
			}
			break;
			IL_0035:
			if (djSTCtuXfIOUkuKgYhEAmyFNWUJ.type == P_0 && djSTCtuXfIOUkuKgYhEAmyFNWUJ.id == P_1)
			{
				return true;
			}
			num++;
			num2 = 670061565;
		}
		goto IL_000f;
	}

	public bool adBGAlpCrTxrtgKicbPRkjxIekDn(Controller P_0)
	{
		if (!pPudpEAbRTjSpfJnIIIXufNwTYY)
		{
			IuoAwCWdCAjYeLqfbcSvMLYTuGV();
			goto IL_000f;
		}
		goto IL_0059;
		IL_0059:
		int num = 0;
		int num2 = -1723767882;
		goto IL_0014;
		IL_000f:
		num2 = -1723767881;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ -1723767883)
			{
			case 4:
				break;
			case 0:
				return true;
			case 1:
				goto IL_0042;
			case 2:
				goto IL_0059;
			default:
				if (num >= QuyolAEqbygmLbXHpafNEdszcaId)
				{
					return false;
				}
				goto IL_0042;
			}
			break;
			IL_0042:
			if (vjPvUdKJEuOpgjbTbfbqjNFfTGr[num].djSTCtuXfIOUkuKgYhEAmyFNWUJ != P_0)
			{
				num++;
				num2 = -1723767882;
			}
			else
			{
				num2 = -1723767883;
			}
		}
		goto IL_000f;
	}

	internal void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
	{
		cDthJAVgLSQoYKgKKbsijgxWPfPA.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
	}

	private void BvNFsFOgLyFWJQOUfAIznwfyrOx()
	{
		if (yDbFGPOVwCcnOQRCFobOPrEoUhR == iIesQmHJYNaOjZySNFbyVCRRARUD.gQycyAxmUbprXJvfcdLMRodEACx)
		{
			goto IL_0009;
		}
		goto IL_0039;
		IL_0009:
		int num = 176594899;
		goto IL_000e;
		IL_000e:
		while (true)
		{
			switch (num ^ 0xA869FD1)
			{
			case 0:
				break;
			case 2:
				DLHGCUwxrnqaSbPQXXmMcOxJaIt = true;
				num = 176594898;
				continue;
			case 3:
				goto IL_0039;
			default:
				iAgWGEzWxcyhtWsopRkEhQeyLjM = true;
				return;
			}
			break;
		}
		goto IL_0009;
		IL_0039:
		LFjEkChFNlIHcQOEePsxvVBzeeq = iIesQmHJYNaOjZySNFbyVCRRARUD.ZFyaNNcZvxZQpandMiHfdzHrUtb;
		num = 176594896;
		goto IL_000e;
	}

	private void EobBEOKOMxGhZjszeEmLccSbrTvA(bool P_0)
	{
		cDthJAVgLSQoYKgKKbsijgxWPfPA.EobBEOKOMxGhZjszeEmLccSbrTvA();
		while (true)
		{
			int num = -822277264;
			while (true)
			{
				switch (num ^ -822277263)
				{
				case 0:
					break;
				case 1:
					if (QuyolAEqbygmLbXHpafNEdszcaId > 0)
					{
						goto IL_0032;
					}
					goto default;
				default:
					LFjEkChFNlIHcQOEePsxvVBzeeq = (P_0 ? iIesQmHJYNaOjZySNFbyVCRRARUD.rltKKHXEwzFMSJClACISKvHcbDw : iIesQmHJYNaOjZySNFbyVCRRARUD.gQycyAxmUbprXJvfcdLMRodEACx);
					iAgWGEzWxcyhtWsopRkEhQeyLjM = false;
					return;
				}
				break;
				IL_0032:
				YrqPRccNueVzWAYHwFFsBXcXtYg();
				num = -822277261;
			}
		}
	}

	private void xUAywlemzqjidyuSIeROMZQVjdl()
	{
		cDthJAVgLSQoYKgKKbsijgxWPfPA.updateLoop = VesEEfGzljjgDkIPFVAOckifeaEO;
	}

	private void YrqPRccNueVzWAYHwFFsBXcXtYg()
	{
		QuyolAEqbygmLbXHpafNEdszcaId = 0;
		if (pPudpEAbRTjSpfJnIIIXufNwTYY)
		{
			WVajCNyhOJSrDIhBKaeeHIvyXccw.Clear();
		}
	}

	private void VxfxWwojnjsTKgBwHEZwcsjHkOL(Controller P_0, ControllerMap P_1, ActionElementMap P_2)
	{
		if (QuyolAEqbygmLbXHpafNEdszcaId + 1 > vjPvUdKJEuOpgjbTbfbqjNFfTGr.Length)
		{
			WUjBuaEnLxsDtTxphsLxjlkSXno();
			goto IL_0018;
		}
		goto IL_0036;
		IL_0036:
		pAbmAVcsPcjQUSUHsDdzTqGMLSN pAbmAVcsPcjQUSUHsDdzTqGMLSN2 = vjPvUdKJEuOpgjbTbfbqjNFfTGr[QuyolAEqbygmLbXHpafNEdszcaId];
		int num = 1640232220;
		goto IL_001d;
		IL_0018:
		num = 1640232221;
		goto IL_001d;
		IL_001d:
		switch (num ^ 0x61C3F51C)
		{
		case 2:
			break;
		case 1:
			goto IL_0036;
		default:
			pAbmAVcsPcjQUSUHsDdzTqGMLSN2.lTkuXDpBpsLxRBVaGMtdDZauGbI = true;
			pAbmAVcsPcjQUSUHsDdzTqGMLSN2.djSTCtuXfIOUkuKgYhEAmyFNWUJ = P_0;
			pAbmAVcsPcjQUSUHsDdzTqGMLSN2.PVhoJNjtQFhTjmwRsuJhvQWcbfU = P_1;
			pAbmAVcsPcjQUSUHsDdzTqGMLSN2.fGOEgVenBQpynjDLaZtrcIyVGYbg = P_2;
			QuyolAEqbygmLbXHpafNEdszcaId++;
			return;
		}
		goto IL_0018;
	}

	private void WUjBuaEnLxsDtTxphsLxjlkSXno()
	{
		ArrayTools.Expand(ref vjPvUdKJEuOpgjbTbfbqjNFfTGr, 4);
		int num3 = default(int);
		int num2 = default(int);
		while (true)
		{
			int num = 1250939097;
			while (true)
			{
				switch (num ^ 0x4A8FD0D8)
				{
				case 3:
					break;
				case 1:
					num3 = QuyolAEqbygmLbXHpafNEdszcaId + 4;
					num2 = QuyolAEqbygmLbXHpafNEdszcaId;
					num = 1250939096;
					continue;
				case 2:
					vjPvUdKJEuOpgjbTbfbqjNFfTGr[num2] = new pAbmAVcsPcjQUSUHsDdzTqGMLSN();
					num2++;
					num = 1250939096;
					continue;
				default:
					if (num2 >= num3)
					{
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	private void zGHtBzMNGjQhtlMjOIJgJLWhOKUe()
	{
		if (!pPudpEAbRTjSpfJnIIIXufNwTYY)
		{
			pPudpEAbRTjSpfJnIIIXufNwTYY = true;
			goto IL_000f;
		}
		goto IL_0031;
		IL_0031:
		int num = 0;
		int num2 = -2141172936;
		goto IL_0014;
		IL_000f:
		num2 = -2141172933;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ -2141172934)
			{
			case 0:
				break;
			case 1:
				goto IL_0031;
			case 3:
				WVajCNyhOJSrDIhBKaeeHIvyXccw.Add(new InputActionSourceData(vjPvUdKJEuOpgjbTbfbqjNFfTGr[num]));
				num++;
				num2 = -2141172936;
				continue;
			default:
				if (num >= QuyolAEqbygmLbXHpafNEdszcaId)
				{
					return;
				}
				goto case 3;
			}
			break;
		}
		goto IL_000f;
	}

	private static void YxGcqLJUUXPyrdhtgaNwEKQsryz(ref ButtonStateFlags P_0, ButtonStateFlags P_1)
	{
		if (P_0 == ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
		{
			P_0 = P_1;
			return;
		}
		while (true)
		{
			IL_0054:
			if ((P_1 & ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL) == 0)
			{
				goto IL_0032;
			}
			int num;
			if ((P_0 & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
			{
				int num2;
				if ((P_0 & ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL) == 0)
				{
					num = 203044673;
					num2 = num;
				}
				else
				{
					num = 203044675;
					num2 = num;
				}
				goto IL_000d;
			}
			goto IL_0049;
			IL_000d:
			while (true)
			{
				switch (num ^ 0xC1A3742)
				{
				case 5:
					num = 203044672;
					continue;
				default:
					return;
				case 0:
					break;
				case 3:
					return;
				case 1:
					goto IL_0049;
				case 2:
					goto IL_0054;
				case 4:
					return;
				}
				break;
			}
			goto IL_0032;
			IL_0032:
			if ((P_1 & ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR) != ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO)
			{
				P_0 = ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR;
				num = 203044678;
				goto IL_000d;
			}
			break;
			IL_0049:
			P_0 = ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR | ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL;
			break;
		}
	}
}
