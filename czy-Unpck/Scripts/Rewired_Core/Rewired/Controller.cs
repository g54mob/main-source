using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class Controller
	{
		public abstract class Element
		{
			internal abstract class mXiVTqOoXFNnRqoQZeiYlehLDSq
			{
				public abstract class hdNXHPcynTbHRqMARRQdePRmAba
				{
					public abstract void CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
				}

				protected readonly int OYdSgkmMwzDnomASpoZmObsTLsl;

				protected readonly int[] EtaejHsOyfWsKklaZtaHxOZADOO;

				protected hdNXHPcynTbHRqMARRQdePRmAba[] ukQXiEKzTMzPimOeOTmWBVpgDWV;

				public hdNXHPcynTbHRqMARRQdePRmAba fSpdVoeWhOYoAilpUehbSxUxANDS;

				private int VXgPrLiRFgJCxmeSHMjaqdvOBgr;

				public int ZAXrLeSNctacqgyxupEGAzXGQYu = -1;

				protected ReadOnlyCollection<hdNXHPcynTbHRqMARRQdePRmAba> YoZuxSeEDwFDXehPlzLfhequEOP;

				public IList<hdNXHPcynTbHRqMARRQdePRmAba> Data => YoZuxSeEDwFDXehPlzLfhequEOP;

				public UpdateLoopType updateLoop
				{
					set
					{
						if (ZAXrLeSNctacqgyxupEGAzXGQYu == (int)value)
						{
							return;
						}
						while (true)
						{
							ZAXrLeSNctacqgyxupEGAzXGQYu = (int)value;
							VXgPrLiRFgJCxmeSHMjaqdvOBgr = EtaejHsOyfWsKklaZtaHxOZADOO[(int)value];
							fSpdVoeWhOYoAilpUehbSxUxANDS = ukQXiEKzTMzPimOeOTmWBVpgDWV[VXgPrLiRFgJCxmeSHMjaqdvOBgr];
							int num = -1781978797;
							while (true)
							{
								switch (num ^ -1781978798)
								{
								case 0:
									goto IL_000c;
								default:
									return;
								case 2:
									break;
								case 1:
									return;
								}
								break;
								IL_000c:
								num = -1781978800;
							}
						}
					}
				}

				public mXiVTqOoXFNnRqoQZeiYlehLDSq(UpdateLoopSetting updateLoopSetting)
				{
					EtaejHsOyfWsKklaZtaHxOZADOO = new int[3];
					OYdSgkmMwzDnomASpoZmObsTLsl = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
						for (int i = 0; i < list.Count; i++)
						{
							EtaejHsOyfWsKklaZtaHxOZADOO[(int)list[i]] = OYdSgkmMwzDnomASpoZmObsTLsl;
							OYdSgkmMwzDnomASpoZmObsTLsl++;
						}
					}
					ukQXiEKzTMzPimOeOTmWBVpgDWV = new hdNXHPcynTbHRqMARRQdePRmAba[OYdSgkmMwzDnomASpoZmObsTLsl];
					YoZuxSeEDwFDXehPlzLfhequEOP = new ReadOnlyCollection<hdNXHPcynTbHRqMARRQdePRmAba>(ukQXiEKzTMzPimOeOTmWBVpgDWV);
				}

				public void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
				{
					int num = 0;
					while (true)
					{
						int num2 = 459083062;
						while (true)
						{
							switch (num2 ^ 0x1B5D0D35)
							{
							case 0:
								break;
							default:
								return;
							case 3:
								num2 = 459083057;
								continue;
							case 4:
							{
								int num3;
								if (num >= OYdSgkmMwzDnomASpoZmObsTLsl)
								{
									num2 = 459083056;
									num3 = num2;
								}
								else
								{
									num2 = 459083060;
									num3 = num2;
								}
								continue;
							}
							case 2:
								num++;
								num2 = 459083057;
								continue;
							case 1:
								ukQXiEKzTMzPimOeOTmWBVpgDWV[num].CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
								num2 = 459083063;
								continue;
							case 5:
								return;
							}
							break;
						}
					}
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal mXiVTqOoXFNnRqoQZeiYlehLDSq FKYRntLkHOQwcnhtxBAcYMRiPLk;

			internal int qdHubhcOPbXxuJQJAkbLHARwcNr;

			internal Controller PQxjKAQNRjWZaZhctvIytmcdtVz;

			internal readonly int vuPDNwATQFuTZgAqTRoviXUGAgFM;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						goto IL_0019;
					}
					ControllerElementIdentifier elementIdentifierById = PQxjKAQNRjWZaZhctvIytmcdtVz.GetElementIdentifierById(id);
					int num = -1752395061;
					goto IL_001e;
					IL_001e:
					while (true)
					{
						switch (num ^ -1752395063)
						{
						case 0:
							break;
						case 3:
							return null;
						case 2:
							if (elementIdentifierById == null)
							{
								goto IL_0059;
							}
							return elementIdentifierById;
						default:
							return ControllerElementIdentifier.BlankReadOnly;
						}
						break;
						IL_0059:
						num = -1752395064;
					}
					goto IL_0019;
					IL_0019:
					num = -1752395062;
					goto IL_001e;
				}
			}

			public bool isMemberElement
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					return qdHubhcOPbXxuJQJAkbLHARwcNr > 0;
				}
			}

			internal Element(Controller controller, int elementIdentifierId, string name, ControllerElementType type)
			{
				PQxjKAQNRjWZaZhctvIytmcdtVz = controller;
				id = elementIdentifierId;
				this.name = name;
				this.type = type;
				vuPDNwATQFuTZgAqTRoviXUGAgFM = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					goto IL_000d;
				}
				goto IL_0043;
				IL_000d:
				int num = 1338355850;
				goto IL_0012;
				IL_0012:
				switch (num ^ 0x4FC5B088)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return;
				case 1:
					goto IL_0043;
				case 3:
					return;
				}
				goto IL_000d;
				IL_0043:
				if (FKYRntLkHOQwcnhtxBAcYMRiPLk != null)
				{
					FKYRntLkHOQwcnhtxBAcYMRiPLk.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
					num = 1338355851;
					goto IL_0012;
				}
			}

			internal void FdyaMRqmKXKMaxiZruLpVjRAkPv()
			{
				if (qdHubhcOPbXxuJQJAkbLHARwcNr > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				qdHubhcOPbXxuJQJAkbLHARwcNr++;
			}

			internal void skAfDGwtftVpvwPUgLrsmAIawta()
			{
				if (qdHubhcOPbXxuJQJAkbLHARwcNr == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					qdHubhcOPbXxuJQJAkbLHARwcNr = 0;
				}
				else
				{
					qdHubhcOPbXxuJQJAkbLHARwcNr--;
				}
			}
		}

		public sealed class Axis : Element
		{
			internal class bEaEkdMLYRdsDeflxIjnoIHnoCN : mXiVTqOoXFNnRqoQZeiYlehLDSq
			{
				public class FNMUKvfJqgqybyCJwlKDuCeVZqW : hdNXHPcynTbHRqMARRQdePRmAba
				{
					private const float GnGgIoqMEJglwALyfoBudMvIaqDV = 0.001f;

					public float ZTonADnXjOPnKfCdZaXyKwbxjUQ;

					public float BdatvqshRoDQwFOAaXdkJYxoTQdk;

					public float LKYvaHnxebJidnnKClgqscxUBofg;

					public float ufNDpTAvvKXbbQSFbfHVMMttRsiN;

					public float iUneIXhzpELIZDlGsKZzeBqALgen;

					public float FzIudzBhxPblUQRemFMzuGWKdWb;

					public double qNibSokyMydWNWuDsEiGDthOTaC;

					public double MSmpmHECchnOIVCNyckeqAyhWmT;

					public double TPkarpmUyaBRxbxRazrBhILncZNN;

					public double FplumpNyiGkXEhiPNKMMqOpvIbD;

					public double uLrAEGAKHsbQnHQzHjTrftWuvbRH;

					public double wdpESEnNypnGZduopGrlEYAQpXp;

					public double timeActive
					{
						get
						{
							if ((double)ZTonADnXjOPnKfCdZaXyKwbxjUQ == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - TPkarpmUyaBRxbxRazrBhILncZNN;
						}
					}

					public double timeActiveRaw
					{
						get
						{
							if ((double)LKYvaHnxebJidnnKClgqscxUBofg == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - FplumpNyiGkXEhiPNKMMqOpvIbD;
						}
					}

					public double timeInactive
					{
						get
						{
							if (ZTonADnXjOPnKfCdZaXyKwbxjUQ != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - qNibSokyMydWNWuDsEiGDthOTaC;
						}
					}

					public double timeInactiveRaw
					{
						get
						{
							if ((double)LKYvaHnxebJidnnKClgqscxUBofg != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - MSmpmHECchnOIVCNyckeqAyhWmT;
						}
					}

					public void GzCliicOSMFLMvKajLgvnmGSSrh(bool P_0)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (MathTools.Approximately(iUneIXhzpELIZDlGsKZzeBqALgen, 0f))
							{
								goto IL_0068;
							}
							qNibSokyMydWNWuDsEiGDthOTaC = unscaledTime;
							goto IL_0076;
						}
						goto IL_00d6;
						IL_010a:
						int num;
						if (!MathTools.Approximately(LKYvaHnxebJidnnKClgqscxUBofg, 0f))
						{
							MSmpmHECchnOIVCNyckeqAyhWmT = unscaledTime;
							num = 1368963534;
							goto IL_002c;
						}
						goto IL_00c5;
						IL_00c5:
						FplumpNyiGkXEhiPNKMMqOpvIbD = unscaledTime;
						num = 1368963534;
						goto IL_002c;
						IL_0076:
						if (!MathTools.IsNear(iUneIXhzpELIZDlGsKZzeBqALgen, FzIudzBhxPblUQRemFMzuGWKdWb, 0.001f))
						{
							uLrAEGAKHsbQnHQzHjTrftWuvbRH = unscaledTime;
							num = 1368963529;
							goto IL_002c;
						}
						goto IL_010a;
						IL_0068:
						TPkarpmUyaBRxbxRazrBhILncZNN = unscaledTime;
						num = 1368963525;
						goto IL_002c;
						IL_002c:
						while (true)
						{
							switch (num ^ 0x5198B9CC)
							{
							case 6:
								num = 1368963528;
								continue;
							default:
								return;
							case 4:
								break;
							case 9:
								goto IL_0076;
							case 3:
								if (!MathTools.IsNear(ZTonADnXjOPnKfCdZaXyKwbxjUQ, BdatvqshRoDQwFOAaXdkJYxoTQdk, 0.001f))
								{
									uLrAEGAKHsbQnHQzHjTrftWuvbRH = unscaledTime;
									num = 1368963531;
									continue;
								}
								goto IL_010a;
							case 1:
								goto IL_00c5;
							case 8:
								goto IL_00d6;
							case 0:
								goto IL_00f9;
							case 7:
								goto IL_010a;
							case 2:
								if (!MathTools.IsNear(LKYvaHnxebJidnnKClgqscxUBofg, ufNDpTAvvKXbbQSFbfHVMMttRsiN, 0.001f))
								{
									wdpESEnNypnGZduopGrlEYAQpXp = unscaledTime;
									num = 1368963526;
									continue;
								}
								return;
							case 5:
								num = 1368963531;
								continue;
							case 10:
								return;
							}
							break;
						}
						goto IL_0068;
						IL_00f9:
						TPkarpmUyaBRxbxRazrBhILncZNN = unscaledTime;
						num = 1368963535;
						goto IL_002c;
						IL_00d6:
						if (!MathTools.Approximately(ZTonADnXjOPnKfCdZaXyKwbxjUQ, 0f))
						{
							qNibSokyMydWNWuDsEiGDthOTaC = unscaledTime;
							num = 1368963535;
							goto IL_002c;
						}
						goto IL_00f9;
					}

					public void cbwaZCoibRtMgWOIfxeFRrapFCd(float P_0)
					{
						if (ufNDpTAvvKXbbQSFbfHVMMttRsiN != LKYvaHnxebJidnnKClgqscxUBofg)
						{
							ufNDpTAvvKXbbQSFbfHVMMttRsiN = LKYvaHnxebJidnnKClgqscxUBofg;
							goto IL_001a;
						}
						goto IL_0038;
						IL_0038:
						int num;
						if (LKYvaHnxebJidnnKClgqscxUBofg != P_0)
						{
							LKYvaHnxebJidnnKClgqscxUBofg = P_0;
							num = -1549779688;
							goto IL_001f;
						}
						return;
						IL_001a:
						num = -1549779687;
						goto IL_001f;
						IL_001f:
						switch (num ^ -1549779688)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0038;
						case 0:
							return;
						}
						goto IL_001a;
					}

					public override void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
					{
						ZTonADnXjOPnKfCdZaXyKwbxjUQ = 0f;
						BdatvqshRoDQwFOAaXdkJYxoTQdk = 0f;
						while (true)
						{
							int num = -453979878;
							while (true)
							{
								switch (num ^ -453979877)
								{
								case 3:
									break;
								default:
									return;
								case 1:
									LKYvaHnxebJidnnKClgqscxUBofg = 0f;
									num = -453979877;
									continue;
								case 2:
									qNibSokyMydWNWuDsEiGDthOTaC = 0.0;
									MSmpmHECchnOIVCNyckeqAyhWmT = 0.0;
									TPkarpmUyaBRxbxRazrBhILncZNN = 0.0;
									FplumpNyiGkXEhiPNKMMqOpvIbD = 0.0;
									uLrAEGAKHsbQnHQzHjTrftWuvbRH = 0.0;
									wdpESEnNypnGZduopGrlEYAQpXp = 0.0;
									num = -453979873;
									continue;
								case 0:
									ufNDpTAvvKXbbQSFbfHVMMttRsiN = 0f;
									num = -453979879;
									continue;
								case 4:
									return;
								}
								break;
							}
						}
					}
				}

				public bEaEkdMLYRdsDeflxIjnoIHnoCN(UpdateLoopSetting updateCycle)
					: base(updateCycle)
				{
					for (int i = 0; i < OYdSgkmMwzDnomASpoZmObsTLsl; i++)
					{
						ukQXiEKzTMzPimOeOTmWBVpgDWV[i] = new FNMUKvfJqgqybyCJwlKDuCeVZqW();
					}
					fSpdVoeWhOYoAilpUehbSxUxANDS = ukQXiEKzTMzPimOeOTmWBVpgDWV[0];
				}
			}

			internal readonly AxisRange MIjOdYJbxJXCDRPmICRMhMFgZuVL;

			internal readonly HardwareAxisInfo fLnddiiYsQMexRarBgYYAedEaIXb;

			public float value
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).iUneIXhzpELIZDlGsKZzeBqALgen;
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).ZTonADnXjOPnKfCdZaXyKwbxjUQ;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).FzIudzBhxPblUQRemFMzuGWKdWb;
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).BdatvqshRoDQwFOAaXdkJYxoTQdk;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						while (true)
						{
							int num = 1693439696;
							while (true)
							{
								switch (num ^ 0x64EFD6D1)
								{
								case 2:
									break;
								case 1:
									goto IL_002b;
								default:
									return 0f;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
								num = 1693439697;
							}
						}
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).LKYvaHnxebJidnnKClgqscxUBofg;
				}
				internal set
				{
					((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).cbwaZCoibRtMgWOIfxeFRrapFCd(value);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).ufNDpTAvvKXbbQSFbfHVMMttRsiN;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).LKYvaHnxebJidnnKClgqscxUBofg - ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).ufNDpTAvvKXbbQSFbfHVMMttRsiN;
				}
			}

			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						while (true)
						{
							int num = -561222296;
							while (true)
							{
								switch (num ^ -561222295)
								{
								case 2:
									break;
								case 1:
									goto IL_002b;
								default:
									return 0.0;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
								num = -561222295;
							}
						}
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).qNibSokyMydWNWuDsEiGDthOTaC;
				}
			}

			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).MSmpmHECchnOIVCNyckeqAyhWmT;
				}
			}

			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).TPkarpmUyaBRxbxRazrBhILncZNN;
				}
			}

			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).FplumpNyiGkXEhiPNKMMqOpvIbD;
				}
			}

			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						while (true)
						{
							int num = 1501847745;
							while (true)
							{
								switch (num ^ 0x598460C0)
								{
								case 2:
									break;
								case 1:
									goto IL_002b;
								default:
									return 0.0;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
								num = 1501847744;
							}
						}
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).uLrAEGAKHsbQnHQzHjTrftWuvbRH;
				}
			}

			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).wdpESEnNypnGZduopGrlEYAQpXp;
				}
			}

			public double timeActive
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).timeActive;
				}
			}

			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).timeActive;
				}
			}

			public double timeInactive
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).timeInactive;
				}
			}

			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).timeInactiveRaw;
				}
			}

			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					if (fLnddiiYsQMexRarBgYYAedEaIXb == null)
					{
						return -1f;
					}
					return fLnddiiYsQMexRarBgYYAedEaIXb._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						goto IL_000d;
					}
					goto IL_0063;
					IL_000d:
					int num = -811120508;
					goto IL_0012;
					IL_0012:
					while (true)
					{
						switch (num ^ -811120507)
						{
						case 5:
							break;
						default:
							return;
						case 0:
							fLnddiiYsQMexRarBgYYAedEaIXb._pollingDeadZone = value;
							num = -811120511;
							continue;
						case 2:
							goto IL_004a;
						case 3:
							goto IL_0063;
						case 1:
							ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
							return;
						case 4:
							return;
						}
						break;
					}
					goto IL_000d;
					IL_004a:
					int num2;
					if (fLnddiiYsQMexRarBgYYAedEaIXb != null)
					{
						num = -811120507;
						num2 = num;
					}
					else
					{
						num = -811120511;
						num2 = num;
					}
					goto IL_0012;
					IL_0063:
					if (value < 0f)
					{
						value = -1f;
						num = -811120505;
						goto IL_0012;
					}
					goto IL_004a;
				}
			}

			internal float selfValue => ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).ZTonADnXjOPnKfCdZaXyKwbxjUQ;

			internal float selfValuePrev => ((bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).BdatvqshRoDQwFOAaXdkJYxoTQdk;

			internal float effectivePollingDeadZone
			{
				get
				{
					if (fLnddiiYsQMexRarBgYYAedEaIXb == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (fLnddiiYsQMexRarBgYYAedEaIXb._pollingDeadZone >= 0f)
					{
						return fLnddiiYsQMexRarBgYYAedEaIXb._pollingDeadZone;
					}
					switch (fLnddiiYsQMexRarBgYYAedEaIXb._dataFormat)
					{
					case AxisCoordinateMode.Absolute:
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					case AxisCoordinateMode.Relative:
						return ReInput.configuration.defaultRelativeAxisPollingDeadZone;
					default:
						throw new NotImplementedException();
					}
				}
			}

			internal void OIUpRpHwOtcoGOHLuPUyukioBKUJ(float P_0)
			{
				bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW fNMUKvfJqgqybyCJwlKDuCeVZqW = (bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS;
				fNMUKvfJqgqybyCJwlKDuCeVZqW.FzIudzBhxPblUQRemFMzuGWKdWb = fNMUKvfJqgqybyCJwlKDuCeVZqW.iUneIXhzpELIZDlGsKZzeBqALgen;
				fNMUKvfJqgqybyCJwlKDuCeVZqW.iUneIXhzpELIZDlGsKZzeBqALgen = P_0;
			}

			internal Axis(Controller controller, int elementIdentifierId, string name, AxisRange axisRange, HardwareAxisInfo axisInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Axis)
			{
				FKYRntLkHOQwcnhtxBAcYMRiPLk = new bEaEkdMLYRdsDeflxIjnoIHnoCN(ReInput.configVars.updateLoop);
				MIjOdYJbxJXCDRPmICRMhMFgZuVL = axisRange;
				fLnddiiYsQMexRarBgYYAedEaIXb = axisInfo;
			}

			internal void xDTKWglCBUFigMkMzCsklYfiJCd(UpdateLoopType P_0)
			{
				if (FKYRntLkHOQwcnhtxBAcYMRiPLk != null && FKYRntLkHOQwcnhtxBAcYMRiPLk.ZAXrLeSNctacqgyxupEGAzXGQYu != (int)P_0)
				{
					FKYRntLkHOQwcnhtxBAcYMRiPLk.updateLoop = P_0;
				}
			}

			internal void UfmxyWnNJnWjGmoVLMrGjDpvidgd(AxisCalibration P_0)
			{
				bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW fNMUKvfJqgqybyCJwlKDuCeVZqW = (bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS;
				float zTonADnXjOPnKfCdZaXyKwbxjUQ = default(float);
				while (true)
				{
					int num = 704762554;
					while (true)
					{
						switch (num ^ 0x2A01D2BB)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							fNMUKvfJqgqybyCJwlKDuCeVZqW.BdatvqshRoDQwFOAaXdkJYxoTQdk = fNMUKvfJqgqybyCJwlKDuCeVZqW.ZTonADnXjOPnKfCdZaXyKwbxjUQ;
							zTonADnXjOPnKfCdZaXyKwbxjUQ = P_0.GetCalibratedValue(fNMUKvfJqgqybyCJwlKDuCeVZqW.LKYvaHnxebJidnnKClgqscxUBofg, MIjOdYJbxJXCDRPmICRMhMFgZuVL);
							if (P_0.applyRangeCalibration)
							{
								zTonADnXjOPnKfCdZaXyKwbxjUQ = MathTools.Clamp(zTonADnXjOPnKfCdZaXyKwbxjUQ, -1f, 1f);
								num = 704762555;
								continue;
							}
							goto case 0;
						case 0:
							fNMUKvfJqgqybyCJwlKDuCeVZqW.ZTonADnXjOPnKfCdZaXyKwbxjUQ = zTonADnXjOPnKfCdZaXyKwbxjUQ;
							num = 704762552;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}

			internal void UfmxyWnNJnWjGmoVLMrGjDpvidgd()
			{
				bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW fNMUKvfJqgqybyCJwlKDuCeVZqW = (bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS;
				fNMUKvfJqgqybyCJwlKDuCeVZqW.BdatvqshRoDQwFOAaXdkJYxoTQdk = fNMUKvfJqgqybyCJwlKDuCeVZqW.ZTonADnXjOPnKfCdZaXyKwbxjUQ;
				fNMUKvfJqgqybyCJwlKDuCeVZqW.ZTonADnXjOPnKfCdZaXyKwbxjUQ = fNMUKvfJqgqybyCJwlKDuCeVZqW.LKYvaHnxebJidnnKClgqscxUBofg;
			}

			internal void vxKJnbbUnljIHqACpEEDqVaTVVB()
			{
				bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW fNMUKvfJqgqybyCJwlKDuCeVZqW = (bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS;
				fNMUKvfJqgqybyCJwlKDuCeVZqW.BdatvqshRoDQwFOAaXdkJYxoTQdk = fNMUKvfJqgqybyCJwlKDuCeVZqW.ZTonADnXjOPnKfCdZaXyKwbxjUQ;
				while (true)
				{
					int num = -281582573;
					while (true)
					{
						switch (num ^ -281582574)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_003b;
						case 0:
							return;
						}
						break;
						IL_003b:
						fNMUKvfJqgqybyCJwlKDuCeVZqW.ZTonADnXjOPnKfCdZaXyKwbxjUQ = 0f;
						num = -281582574;
					}
				}
			}

			internal void hFLjdYLxLBBvCamKPTvTlraimvOj()
			{
				bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW fNMUKvfJqgqybyCJwlKDuCeVZqW = (bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS;
				fNMUKvfJqgqybyCJwlKDuCeVZqW.GzCliicOSMFLMvKajLgvnmGSSrh(base.isMemberElement);
			}

			internal void FCramLIfrIUWlLHlgnPTywflyzM(float P_0)
			{
				int num = 0;
				while (num < FKYRntLkHOQwcnhtxBAcYMRiPLk.Data.Count)
				{
					while (true)
					{
						int num2;
						if (FKYRntLkHOQwcnhtxBAcYMRiPLk.Data[num] is bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW fNMUKvfJqgqybyCJwlKDuCeVZqW)
						{
							fNMUKvfJqgqybyCJwlKDuCeVZqW.cbwaZCoibRtMgWOIfxeFRrapFCd(P_0);
							fNMUKvfJqgqybyCJwlKDuCeVZqW.BdatvqshRoDQwFOAaXdkJYxoTQdk = fNMUKvfJqgqybyCJwlKDuCeVZqW.ZTonADnXjOPnKfCdZaXyKwbxjUQ;
							fNMUKvfJqgqybyCJwlKDuCeVZqW.ZTonADnXjOPnKfCdZaXyKwbxjUQ = 0f;
							fNMUKvfJqgqybyCJwlKDuCeVZqW.GzCliicOSMFLMvKajLgvnmGSSrh(base.isMemberElement);
							num2 = 2000689281;
							goto IL_0009;
						}
						goto IL_0071;
						IL_0009:
						while (true)
						{
							switch (num2 ^ 0x77401881)
							{
							case 2:
								num2 = 2000689280;
								continue;
							case 1:
								break;
							case 0:
								goto IL_0071;
							default:
								goto end_IL_0026;
							}
							break;
						}
						continue;
						IL_0071:
						num++;
						num2 = 2000689282;
						goto IL_0009;
						continue;
						end_IL_0026:
						break;
					}
				}
			}

			internal float WVXBFCcIKtgeJAdRinUDwYKKLEcN(UpdateLoopType P_0, AxisCalibration P_1)
			{
				bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW fNMUKvfJqgqybyCJwlKDuCeVZqW = (bEaEkdMLYRdsDeflxIjnoIHnoCN.FNMUKvfJqgqybyCJwlKDuCeVZqW)FKYRntLkHOQwcnhtxBAcYMRiPLk.Data[(int)P_0];
				float result = P_1.GetCalibratedValue(fNMUKvfJqgqybyCJwlKDuCeVZqW.LKYvaHnxebJidnnKClgqscxUBofg, MIjOdYJbxJXCDRPmICRMhMFgZuVL, P_1.deadZone, applySensitivity: false, applyInversion: true);
				if (P_1.applyRangeCalibration)
				{
					while (true)
					{
						int num = -471888910;
						while (true)
						{
							switch (num ^ -471888909)
							{
							case 0:
								break;
							case 1:
								result = MathTools.Clamp(result, -1f, 1f);
								num = -471888911;
								continue;
							default:
								goto end_IL_003a;
							}
							break;
						}
						continue;
						end_IL_003a:
						break;
					}
				}
				return result;
			}
		}

		public sealed class Button : Element
		{
			internal class aGzdDjdwWThvmDUfNIUJQwMcFADS : mXiVTqOoXFNnRqoQZeiYlehLDSq
			{
				public class UAAthzOfYevLboPLxMyFrgbAXer : hdNXHPcynTbHRqMARRQdePRmAba
				{
					public bool ZTonADnXjOPnKfCdZaXyKwbxjUQ;

					public bool BdatvqshRoDQwFOAaXdkJYxoTQdk;

					public ButtonStateRecorder FhkuPnpLQcGaRVXZoeVQHdjTKUOe;

					public dpVtayQkMohBNIznVFukSTYbCqxv SCiaPfdfSrQSwFkGGwORbBKLCRYg;

					public UAAthzOfYevLboPLxMyFrgbAXer()
					{
						FhkuPnpLQcGaRVXZoeVQHdjTKUOe = new ButtonStateRecorder();
						SCiaPfdfSrQSwFkGGwORbBKLCRYg = new dpVtayQkMohBNIznVFukSTYbCqxv(0.3f);
					}

					public void KyHpjvRkJIBKWzDbtHSSnZwunyW(bool P_0)
					{
						if (BdatvqshRoDQwFOAaXdkJYxoTQdk != ZTonADnXjOPnKfCdZaXyKwbxjUQ)
						{
							goto IL_000e;
						}
						goto IL_0046;
						IL_000e:
						int num = 329296902;
						goto IL_0013;
						IL_0013:
						while (true)
						{
							switch (num ^ 0x13A0AC03)
							{
							case 2:
								break;
							case 4:
								ZTonADnXjOPnKfCdZaXyKwbxjUQ = P_0;
								num = 329296898;
								continue;
							case 0:
								goto IL_0046;
							case 1:
								FhkuPnpLQcGaRVXZoeVQHdjTKUOe.GzCliicOSMFLMvKajLgvnmGSSrh(P_0 && !BdatvqshRoDQwFOAaXdkJYxoTQdk, P_0, ReInput.unscaledTime);
								num = 329296896;
								continue;
							case 5:
								BdatvqshRoDQwFOAaXdkJYxoTQdk = ZTonADnXjOPnKfCdZaXyKwbxjUQ;
								num = 329296899;
								continue;
							default:
								SCiaPfdfSrQSwFkGGwORbBKLCRYg.GzCliicOSMFLMvKajLgvnmGSSrh(0.3f, P_0 && !BdatvqshRoDQwFOAaXdkJYxoTQdk, P_0);
								return;
							}
							break;
						}
						goto IL_000e;
						IL_0046:
						int num2;
						if (ZTonADnXjOPnKfCdZaXyKwbxjUQ == P_0)
						{
							num = 329296898;
							num2 = num;
						}
						else
						{
							num = 329296903;
							num2 = num;
						}
						goto IL_0013;
					}

					public override void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
					{
						ZTonADnXjOPnKfCdZaXyKwbxjUQ = false;
						BdatvqshRoDQwFOAaXdkJYxoTQdk = false;
						while (true)
						{
							int num = 1476692971;
							while (true)
							{
								switch (num ^ 0x58048BEA)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									goto IL_002c;
								case 2:
									return;
								}
								break;
								IL_002c:
								FhkuPnpLQcGaRVXZoeVQHdjTKUOe.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
								SCiaPfdfSrQSwFkGGwORbBKLCRYg.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
								num = 1476692968;
							}
						}
					}
				}

				public class FslachfSDhFTYRDjVmtcgQKWNvqY : UAAthzOfYevLboPLxMyFrgbAXer
				{
					public float mfOLSsemOmGUYxlqbtEfcDFYLTt;

					public float PILORBZeWKKkeSEIajOTveBZEmD;

					public void KyHpjvRkJIBKWzDbtHSSnZwunyW(float P_0)
					{
						if (PILORBZeWKKkeSEIajOTveBZEmD != mfOLSsemOmGUYxlqbtEfcDFYLTt)
						{
							goto IL_000e;
						}
						goto IL_0065;
						IL_000e:
						int num = 689656204;
						goto IL_0013;
						IL_0013:
						while (true)
						{
							switch (num ^ 0x291B518D)
							{
							case 4:
								break;
							default:
								return;
							case 1:
								PILORBZeWKKkeSEIajOTveBZEmD = mfOLSsemOmGUYxlqbtEfcDFYLTt;
								num = 689656205;
								continue;
							case 3:
								goto IL_0047;
							case 0:
								goto IL_0065;
							case 2:
								return;
							}
							break;
						}
						goto IL_000e;
						IL_0065:
						if (mfOLSsemOmGUYxlqbtEfcDFYLTt != P_0)
						{
							mfOLSsemOmGUYxlqbtEfcDFYLTt = ((P_0 > 0.001f) ? P_0 : 0f);
							num = 689656206;
							goto IL_0013;
						}
						goto IL_0047;
						IL_0047:
						KyHpjvRkJIBKWzDbtHSSnZwunyW((mfOLSsemOmGUYxlqbtEfcDFYLTt > 0f) ? true : false);
						num = 689656207;
						goto IL_0013;
					}

					public override void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
					{
						base.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
						mfOLSsemOmGUYxlqbtEfcDFYLTt = 0f;
						PILORBZeWKKkeSEIajOTveBZEmD = 0f;
					}
				}

				public aGzdDjdwWThvmDUfNIUJQwMcFADS(UpdateLoopSetting updateCycle, bool isPressureSensitive)
					: base(updateCycle)
				{
					for (int i = 0; i < OYdSgkmMwzDnomASpoZmObsTLsl; i++)
					{
						if (isPressureSensitive)
						{
							ukQXiEKzTMzPimOeOTmWBVpgDWV[i] = new FslachfSDhFTYRDjVmtcgQKWNvqY();
						}
						else
						{
							ukQXiEKzTMzPimOeOTmWBVpgDWV[i] = new UAAthzOfYevLboPLxMyFrgbAXer();
						}
					}
					fSpdVoeWhOYoAilpUehbSxUxANDS = ukQXiEKzTMzPimOeOTmWBVpgDWV[0];
				}

				public void kcSxehPjmLaNbykKOpsxEOktfZA(float P_0)
				{
					int num = 0;
					while (num < ukQXiEKzTMzPimOeOTmWBVpgDWV.Length)
					{
						while (true)
						{
							((UAAthzOfYevLboPLxMyFrgbAXer)ukQXiEKzTMzPimOeOTmWBVpgDWV[num]).SCiaPfdfSrQSwFkGGwORbBKLCRYg.buUwnebVeshOowGIsGloTRnJlSy(P_0);
							num++;
							int num2 = -945571265;
							while (true)
							{
								switch (num2 ^ -945571266)
								{
								case 0:
									num2 = -945571268;
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

				public void AzPqmJtCYuRKfpViNMAvNnCtBiD()
				{
					int num = 0;
					while (true)
					{
						int num2 = -611391026;
						while (true)
						{
							switch (num2 ^ -611391025)
							{
							case 2:
								break;
							default:
								return;
							case 4:
							{
								int num3;
								if (num >= ukQXiEKzTMzPimOeOTmWBVpgDWV.Length)
								{
									num2 = -611391028;
									num3 = num2;
								}
								else
								{
									num2 = -611391025;
									num3 = num2;
								}
								continue;
							}
							case 0:
								((UAAthzOfYevLboPLxMyFrgbAXer)ukQXiEKzTMzPimOeOTmWBVpgDWV[num]).SCiaPfdfSrQSwFkGGwORbBKLCRYg.buUwnebVeshOowGIsGloTRnJlSy(0.3f);
								num++;
								num2 = -611391029;
								continue;
							case 1:
								num2 = -611391029;
								continue;
							case 3:
								return;
							}
							break;
						}
					}
				}
			}

			internal readonly bool GsEpYNAtCtHHElSNDJZpBwxHfua;

			internal readonly HardwareButtonInfo PwUXLALrfghlFKOmPrArGICsqfV;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).BdatvqshRoDQwFOAaXdkJYxoTQdk;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).ZTonADnXjOPnKfCdZaXyKwbxjUQ;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					if (!GsEpYNAtCtHHElSNDJZpBwxHfua)
					{
						if (!((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).ZTonADnXjOPnKfCdZaXyKwbxjUQ)
						{
							return 0f;
						}
						return 1f;
					}
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.FslachfSDhFTYRDjVmtcgQKWNvqY)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).mfOLSsemOmGUYxlqbtEfcDFYLTt;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					if (!GsEpYNAtCtHHElSNDJZpBwxHfua)
					{
						if (!((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).BdatvqshRoDQwFOAaXdkJYxoTQdk)
						{
							return 0f;
						}
						return 1f;
					}
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.FslachfSDhFTYRDjVmtcgQKWNvqY)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).PILORBZeWKKkeSEIajOTveBZEmD;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					return GsEpYNAtCtHHElSNDJZpBwxHfua;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					if (!((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).BdatvqshRoDQwFOAaXdkJYxoTQdk && ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).ZTonADnXjOPnKfCdZaXyKwbxjUQ)
					{
						return true;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					if (((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).BdatvqshRoDQwFOAaXdkJYxoTQdk && !((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).ZTonADnXjOPnKfCdZaXyKwbxjUQ)
					{
						return true;
					}
					return false;
				}
			}

			public bool justChangedState
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						goto IL_000d;
					}
					int num;
					if (((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).BdatvqshRoDQwFOAaXdkJYxoTQdk != ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).ZTonADnXjOPnKfCdZaXyKwbxjUQ)
					{
						num = -1867026652;
						goto IL_0012;
					}
					return false;
					IL_000d:
					num = -1867026649;
					goto IL_0012;
					IL_0012:
					switch (num ^ -1867026650)
					{
					case 0:
						break;
					case 1:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					default:
						return true;
					}
					goto IL_000d;
				}
			}

			public bool doublePressedAndHeld
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).SCiaPfdfSrQSwFkGGwORbBKLCRYg.doublePressHold;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).SCiaPfdfSrQSwFkGGwORbBKLCRYg.doublePressHold;
				}
			}

			public double timePressed
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).FhkuPnpLQcGaRVXZoeVQHdjTKUOe.timePressed;
				}
			}

			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).FhkuPnpLQcGaRVXZoeVQHdjTKUOe.timeUnpressed;
				}
			}

			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).FhkuPnpLQcGaRVXZoeVQHdjTKUOe.lastTimePressed;
				}
			}

			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).FhkuPnpLQcGaRVXZoeVQHdjTKUOe.lastTimeUnpressed;
				}
			}

			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0.0;
					}
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).FhkuPnpLQcGaRVXZoeVQHdjTKUOe.lastTimeStateChanged;
				}
			}

			internal ButtonStateFlags state
			{
				get
				{
					aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer uAAthzOfYevLboPLxMyFrgbAXer = (aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO;
					if (uAAthzOfYevLboPLxMyFrgbAXer.ZTonADnXjOPnKfCdZaXyKwbxjUQ)
					{
						buttonStateFlags |= ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR;
						if (!uAAthzOfYevLboPLxMyFrgbAXer.BdatvqshRoDQwFOAaXdkJYxoTQdk)
						{
							buttonStateFlags |= ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL;
						}
					}
					else
					{
						while (uAAthzOfYevLboPLxMyFrgbAXer.BdatvqshRoDQwFOAaXdkJYxoTQdk)
						{
							buttonStateFlags |= ButtonStateFlags.splhCJEXiNqkFWSDEanyDbxOmDQ;
							int num = 1444770085;
							while (true)
							{
								switch (num ^ 0x561D7127)
								{
								case 0:
									num = 1444770086;
									continue;
								case 1:
									break;
								default:
									goto end_IL_004d;
								}
								break;
							}
							continue;
							end_IL_004d:
							break;
						}
					}
					return buttonStateFlags;
				}
			}

			internal Button(Controller controller, int elementIdentifierId, string name, HardwareButtonInfo buttonInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Button)
			{
				PwUXLALrfghlFKOmPrArGICsqfV = buttonInfo;
				FKYRntLkHOQwcnhtxBAcYMRiPLk = new aGzdDjdwWThvmDUfNIUJQwMcFADS(ReInput.configVars.updateLoop, isPressureSensitive: false);
			}

			internal Button(Controller controller, int elementIdentifierId, string name, bool isPressureSensitive, HardwareButtonInfo buttonInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Button)
			{
				PwUXLALrfghlFKOmPrArGICsqfV = buttonInfo;
				GsEpYNAtCtHHElSNDJZpBwxHfua = isPressureSensitive;
				FKYRntLkHOQwcnhtxBAcYMRiPLk = new aGzdDjdwWThvmDUfNIUJQwMcFADS(ReInput.configVars.updateLoop, isPressureSensitive);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				}
				if (speed <= 0f)
				{
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).SCiaPfdfSrQSwFkGGwORbBKLCRYg.doublePressHold;
				}
				return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).FhkuPnpLQcGaRVXZoeVQHdjTKUOe.EpDukhFQGxRGHEYYKBbTcdhlpvF(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					goto IL_000d;
				}
				int num;
				if (!justPressed)
				{
					num = -642087247;
					goto IL_0012;
				}
				if (speed <= 0f)
				{
					return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).SCiaPfdfSrQSwFkGGwORbBKLCRYg.doublePressHold;
				}
				return ((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).FhkuPnpLQcGaRVXZoeVQHdjTKUOe.EpDukhFQGxRGHEYYKBbTcdhlpvF(speed);
				IL_0012:
				switch (num ^ -642087247)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				default:
					return false;
				}
				goto IL_000d;
				IL_000d:
				num = -642087248;
				goto IL_0012;
			}

			internal void KyHpjvRkJIBKWzDbtHSSnZwunyW(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (FKYRntLkHOQwcnhtxBAcYMRiPLk != null && FKYRntLkHOQwcnhtxBAcYMRiPLk.ZAXrLeSNctacqgyxupEGAzXGQYu != (int)P_0)
				{
					FKYRntLkHOQwcnhtxBAcYMRiPLk.updateLoop = P_0;
					goto IL_0022;
				}
				goto IL_0048;
				IL_0027:
				int num;
				while (true)
				{
					switch (num ^ -329190498)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0048;
					case 4:
						((aGzdDjdwWThvmDUfNIUJQwMcFADS.FslachfSDhFTYRDjVmtcgQKWNvqY)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).KyHpjvRkJIBKWzDbtHSSnZwunyW(P_2.buttonPressureValues[P_1]);
						return;
					case 1:
						((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).KyHpjvRkJIBKWzDbtHSSnZwunyW(P_2.buttonValues[P_1]);
						num = -329190499;
						continue;
					case 3:
						return;
					}
					break;
				}
				goto IL_0022;
				IL_0048:
				int num2;
				if (!GsEpYNAtCtHHElSNDJZpBwxHfua)
				{
					num = -329190497;
					num2 = num;
				}
				else
				{
					num = -329190502;
					num2 = num;
				}
				goto IL_0027;
				IL_0022:
				num = -329190500;
				goto IL_0027;
			}

			internal void LihbIPbGsllGSRjvQiDhYHgWKHE(UpdateLoopType P_0)
			{
				if (FKYRntLkHOQwcnhtxBAcYMRiPLk != null)
				{
					while (true)
					{
						int num = 1604590768;
						while (true)
						{
							switch (num ^ 0x5FA41CB1)
							{
							case 2:
								break;
							case 1:
								if (FKYRntLkHOQwcnhtxBAcYMRiPLk.ZAXrLeSNctacqgyxupEGAzXGQYu != (int)P_0)
								{
									FKYRntLkHOQwcnhtxBAcYMRiPLk.updateLoop = P_0;
									num = 1604590769;
									continue;
								}
								goto end_IL_0008;
							case 0:
								goto end_IL_0008;
							default:
								goto IL_0075;
							}
							break;
						}
						continue;
						end_IL_0008:
						break;
					}
				}
				if (GsEpYNAtCtHHElSNDJZpBwxHfua)
				{
					((aGzdDjdwWThvmDUfNIUJQwMcFADS.FslachfSDhFTYRDjVmtcgQKWNvqY)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).KyHpjvRkJIBKWzDbtHSSnZwunyW(0f);
					return;
				}
				goto IL_0075;
				IL_0075:
				((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)FKYRntLkHOQwcnhtxBAcYMRiPLk.fSpdVoeWhOYoAilpUehbSxUxANDS).KyHpjvRkJIBKWzDbtHSSnZwunyW(false);
			}

			internal void FCramLIfrIUWlLHlgnPTywflyzM()
			{
				int num = 0;
				while (num < FKYRntLkHOQwcnhtxBAcYMRiPLk.Data.Count)
				{
					while (true)
					{
						mXiVTqOoXFNnRqoQZeiYlehLDSq.hdNXHPcynTbHRqMARRQdePRmAba hdNXHPcynTbHRqMARRQdePRmAba = FKYRntLkHOQwcnhtxBAcYMRiPLk.Data[num];
						int num2 = -488556358;
						while (true)
						{
							switch (num2 ^ -488556359)
							{
							case 0:
								num2 = -488556356;
								continue;
							case 5:
								break;
							case 1:
								((aGzdDjdwWThvmDUfNIUJQwMcFADS.UAAthzOfYevLboPLxMyFrgbAXer)hdNXHPcynTbHRqMARRQdePRmAba).KyHpjvRkJIBKWzDbtHSSnZwunyW(false);
								num2 = -488556355;
								continue;
							case 3:
								if (hdNXHPcynTbHRqMARRQdePRmAba != null)
								{
									if (GsEpYNAtCtHHElSNDJZpBwxHfua)
									{
										((aGzdDjdwWThvmDUfNIUJQwMcFADS.FslachfSDhFTYRDjVmtcgQKWNvqY)hdNXHPcynTbHRqMARRQdePRmAba).KyHpjvRkJIBKWzDbtHSSnZwunyW(0f);
										num2 = -488556355;
										continue;
									}
									goto case 1;
								}
								goto case 4;
							case 4:
								num++;
								num2 = -488556357;
								continue;
							default:
								goto end_IL_0031;
							}
							break;
						}
						continue;
						end_IL_0031:
						break;
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class pCGhajbnVqLKlmtEnlWShbHVOJDD
			{
				public readonly Element rtbAYIiFFNDhBOhoXbvIEvxNbpHC;

				public readonly int GHpwyUMYRpXRokZaoyuqQswiPSh;

				public pCGhajbnVqLKlmtEnlWShbHVOJDD(Element element, int elementIndex)
				{
					rtbAYIiFFNDhBOhoXbvIEvxNbpHC = element;
					GHpwyUMYRpXRokZaoyuqQswiPSh = elementIndex;
				}
			}

			private int yBWjkrHKbDlkjegyONinAthRElAh;

			private string SQlNTEPvaCuPzRHxRVAmonHCzna;

			private CompoundControllerElementType mlHEPMoLvhyxVvGHhIjSYBQKMrF;

			private int MiDdvPDMZGcxOkAgrzXGgrkCNOi;

			private pCGhajbnVqLKlmtEnlWShbHVOJDD[] HjhAZUJqXlQPwmwSuTtFHNgXuzt;

			private Controller PQxjKAQNRjWZaZhctvIytmcdtVz;

			internal readonly int vuPDNwATQFuTZgAqTRoviXUGAgFM;

			public int id
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return -1;
					}
					return yBWjkrHKbDlkjegyONinAthRElAh;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return string.Empty;
					}
					return SQlNTEPvaCuPzRHxRVAmonHCzna;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return CompoundControllerElementType.Axis2D;
					}
					return mlHEPMoLvhyxVvGHhIjSYBQKMrF;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					return MiDdvPDMZGcxOkAgrzXGgrkCNOi > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0;
					}
					return MiDdvPDMZGcxOkAgrzXGgrkCNOi;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = PQxjKAQNRjWZaZhctvIytmcdtVz.GetElementIdentifierById(yBWjkrHKbDlkjegyONinAthRElAh);
					while (true)
					{
						int num = -824123729;
						while (true)
						{
							switch (num ^ -824123730)
							{
							case 2:
								break;
							case 1:
								if (elementIdentifierById == null)
								{
									goto IL_004e;
								}
								return elementIdentifierById;
							default:
								return ControllerElementIdentifier.BlankReadOnly;
							}
							break;
							IL_004e:
							num = -824123730;
						}
					}
				}
			}

			internal CompoundElement(Controller controller, int elementIdentifierId, string name, CompoundControllerElementType type)
			{
				PQxjKAQNRjWZaZhctvIytmcdtVz = controller;
				yBWjkrHKbDlkjegyONinAthRElAh = elementIdentifierId;
				SQlNTEPvaCuPzRHxRVAmonHCzna = name;
				mlHEPMoLvhyxVvGHhIjSYBQKMrF = type;
				HjhAZUJqXlQPwmwSuTtFHNgXuzt = new pCGhajbnVqLKlmtEnlWShbHVOJDD[elementCapacity];
				vuPDNwATQFuTZgAqTRoviXUGAgFM = ReInput.id;
			}

			internal Element WPeqKlrsUlCkyNVaxZHjSbqAJOj(int P_0)
			{
				if (P_0 < 0 || P_0 >= HjhAZUJqXlQPwmwSuTtFHNgXuzt.Length)
				{
					return null;
				}
				if (HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_0] == null)
				{
					return null;
				}
				return HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_0].rtbAYIiFFNDhBOhoXbvIEvxNbpHC;
			}

			internal T WPeqKlrsUlCkyNVaxZHjSbqAJOj<T>(int P_0) where T : Element
			{
				int num;
				if (P_0 >= 0)
				{
					if (P_0 >= HjhAZUJqXlQPwmwSuTtFHNgXuzt.Length)
					{
						goto IL_000f;
					}
					if (HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_0] == null)
					{
						num = 660245199;
						goto IL_0014;
					}
					return HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_0].rtbAYIiFFNDhBOhoXbvIEvxNbpHC as T;
				}
				goto IL_0031;
				IL_0014:
				T result = default(T);
				switch (num ^ 0x275A8ACC)
				{
				case 0:
					break;
				case 2:
					goto IL_0031;
				case 1:
					return result;
				default:
					return null;
				}
				goto IL_000f;
				IL_000f:
				num = 660245198;
				goto IL_0014;
				IL_0031:
				result = null;
				num = 660245197;
				goto IL_0014;
			}

			internal T EkeWbYkwqrFcmKHaeJGGztoVEQe<T>(int P_0, out int P_1) where T : Element
			{
				P_1 = -1;
				T result = default(T);
				int num;
				if (P_0 >= 0)
				{
					if (P_0 >= HjhAZUJqXlQPwmwSuTtFHNgXuzt.Length)
					{
						goto IL_0012;
					}
					if (HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_0] == null)
					{
						result = null;
						num = 1624779584;
						goto IL_0017;
					}
					P_1 = HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_0].GHpwyUMYRpXRokZaoyuqQswiPSh;
					return HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_0].rtbAYIiFFNDhBOhoXbvIEvxNbpHC as T;
				}
				goto IL_0034;
				IL_0017:
				T result2 = default(T);
				switch (num ^ 0x60D82B41)
				{
				case 2:
					break;
				case 3:
					goto IL_0034;
				case 0:
					return result2;
				default:
					return result;
				}
				goto IL_0012;
				IL_0012:
				num = 1624779586;
				goto IL_0017;
				IL_0034:
				result2 = null;
				num = 1624779585;
				goto IL_0017;
			}

			internal bool itKYLEidIwjerGGrDGqPNskdaYz(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (MiDdvPDMZGcxOkAgrzXGgrkCNOi >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (DUAxYNCHeTAQPnXQfgwxWiroHHG(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					goto IL_0047;
				}
				int num = dmIBOBBsfaprQRKwRTRpoAfdwNvv();
				int num2 = 107498131;
				goto IL_004c;
				IL_004c:
				while (true)
				{
					switch (num2 ^ 0x6684A91)
					{
					case 0:
						break;
					case 1:
						return false;
					case 2:
						if (num < 0)
						{
							goto IL_007d;
						}
						return PyzXmYjIgqZrlBOsjHDLUlFhyqu(P_0, P_1, num);
					default:
						return false;
					}
					break;
					IL_007d:
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					num2 = 107498130;
				}
				goto IL_0047;
				IL_0047:
				num2 = 107498128;
				goto IL_004c;
			}

			internal bool IwOoboJDhxcHuWPDkEfMqTSzfMK(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (MiDdvPDMZGcxOkAgrzXGgrkCNOi == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = DUAxYNCHeTAQPnXQfgwxWiroHHG(P_0);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return glVhaRWDUAnvWsYsNcshMizUngQ(num);
			}

			internal void PGPnFYNZLhRHwaBuvyopgEOIkB()
			{
				int num = 0;
				while (true)
				{
					int num2 = -1963546763;
					while (true)
					{
						switch (num2 ^ -1963546768)
						{
						case 0:
							break;
						default:
							return;
						case 5:
							num2 = -1963546764;
							continue;
						case 3:
							glVhaRWDUAnvWsYsNcshMizUngQ(num);
							num++;
							num2 = -1963546764;
							continue;
						case 2:
							MiDdvPDMZGcxOkAgrzXGgrkCNOi = 0;
							num2 = -1963546767;
							continue;
						case 4:
						{
							int num3;
							if (num >= HjhAZUJqXlQPwmwSuTtFHNgXuzt.Length)
							{
								num2 = -1963546766;
								num3 = num2;
							}
							else
							{
								num2 = -1963546765;
								num3 = num2;
							}
							continue;
						}
						case 1:
							return;
						}
						break;
					}
				}
			}

			private int DUAxYNCHeTAQPnXQfgwxWiroHHG(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				int num = 0;
				while (num < HjhAZUJqXlQPwmwSuTtFHNgXuzt.Length)
				{
					while (true)
					{
						if (HjhAZUJqXlQPwmwSuTtFHNgXuzt[num] != null && HjhAZUJqXlQPwmwSuTtFHNgXuzt[num].rtbAYIiFFNDhBOhoXbvIEvxNbpHC == P_0)
						{
							return num;
						}
						num++;
						int num2 = 725283683;
						while (true)
						{
							switch (num2 ^ 0x2B3AF362)
							{
							case 0:
								num2 = 725283680;
								continue;
							case 2:
								break;
							default:
								goto end_IL_0027;
							}
							break;
						}
						continue;
						end_IL_0027:
						break;
					}
				}
				return -1;
			}

			private bool PyzXmYjIgqZrlBOsjHDLUlFhyqu(Element P_0, int P_1, int P_2)
			{
				int num;
				if (P_2 >= 0)
				{
					if (P_2 >= HjhAZUJqXlQPwmwSuTtFHNgXuzt.Length)
					{
						goto IL_000f;
					}
					if (HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_2] != null)
					{
						return false;
					}
					HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_2] = new pCGhajbnVqLKlmtEnlWShbHVOJDD(P_0, P_1);
					P_0.FdyaMRqmKXKMaxiZruLpVjRAkPv();
					num = -597285198;
					goto IL_0014;
				}
				goto IL_0031;
				IL_0014:
				while (true)
				{
					switch (num ^ -597285200)
					{
					case 3:
						break;
					case 1:
						goto IL_0031;
					case 2:
						MiDdvPDMZGcxOkAgrzXGgrkCNOi++;
						num = -597285200;
						continue;
					default:
						return true;
					}
					break;
				}
				goto IL_000f;
				IL_000f:
				num = -597285199;
				goto IL_0014;
				IL_0031:
				return false;
			}

			private bool glVhaRWDUAnvWsYsNcshMizUngQ(int P_0)
			{
				if (P_0 >= 0)
				{
					while (true)
					{
						int num = 985384099;
						while (true)
						{
							switch (num ^ 0x3ABBC4A2)
							{
							case 4:
								break;
							case 2:
								MiDdvPDMZGcxOkAgrzXGgrkCNOi--;
								num = 985384103;
								continue;
							case 0:
								goto end_IL_0004;
							case 3:
								goto IL_0079;
							case 1:
								goto IL_0089;
							default:
								return true;
							}
							break;
							IL_0089:
							if (P_0 < HjhAZUJqXlQPwmwSuTtFHNgXuzt.Length)
							{
								if (HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_0] == null)
								{
									return false;
								}
								if (HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_0].rtbAYIiFFNDhBOhoXbvIEvxNbpHC != null)
								{
									HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_0].rtbAYIiFFNDhBOhoXbvIEvxNbpHC.skAfDGwtftVpvwPUgLrsmAIawta();
									num = 985384097;
									continue;
								}
								goto IL_0079;
							}
							num = 985384098;
							continue;
							IL_0079:
							HjhAZUJqXlQPwmwSuTtFHNgXuzt[P_0] = null;
							num = 985384096;
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				return false;
			}

			private int dmIBOBBsfaprQRKwRTRpoAfdwNvv()
			{
				int num = 0;
				while (true)
				{
					int num2 = -1476822350;
					while (true)
					{
						switch (num2 ^ -1476822352)
						{
						case 0:
							break;
						case 2:
							num2 = -1476822349;
							continue;
						case 1:
							if (HjhAZUJqXlQPwmwSuTtFHNgXuzt[num] == null)
							{
								return num;
							}
							num++;
							num2 = -1476822349;
							continue;
						default:
							if (num >= HjhAZUJqXlQPwmwSuTtFHNgXuzt.Length)
							{
								return -1;
							}
							goto case 1;
						}
						break;
					}
				}
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int CohpSETRHfhPkPrGIUzAVRWyQHg = 2;

			private CalibrationMap dUEarOazcbYhnSAuJtYGyikBzFm;

			public override int elementCapacity => 2;

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						while (true)
						{
							int num = 2001338765;
							while (true)
							{
								switch (num ^ 0x774A018C)
								{
								case 2:
									break;
								case 1:
									goto IL_002b;
								default:
									return null;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
								num = 2001338764;
							}
						}
					}
					return WPeqKlrsUlCkyNVaxZHjSbqAJOj<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return WPeqKlrsUlCkyNVaxZHjSbqAJOj<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector2.zero;
					}
					return wgtDvyAHNuGOigROVlJPIcIghVwE();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector2.zero;
					}
					return oIWGDFKGZSrGAcvCCeyvoJdtugJq();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller controller, int elementIdentifierId, string name, Axis xAxis, Axis yAxis, int xAxisIndex, int yAxisIndex, CalibrationMap calibratonMap)
				: base(controller, elementIdentifierId, name, CompoundControllerElementType.Axis2D)
			{
				itKYLEidIwjerGGrDGqPNskdaYz(xAxis, xAxisIndex);
				itKYLEidIwjerGGrDGqPNskdaYz(yAxis, yAxisIndex);
				dUEarOazcbYhnSAuJtYGyikBzFm = calibratonMap;
			}

			internal void fEfTuMgIgNspmcJifDAbjyclSfZ()
			{
				Vector2 vector = value;
				while (true)
				{
					int num = 1096540552;
					while (true)
					{
						switch (num ^ 0x415BE189)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (xAxis != null)
							{
								xAxis.OIUpRpHwOtcoGOHLuPUyukioBKUJ(vector.x);
								num = 1096540553;
								continue;
							}
							goto case 0;
						case 0:
							if (yAxis != null)
							{
								yAxis.OIUpRpHwOtcoGOHLuPUyukioBKUJ(vector.y);
								num = 1096540554;
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

			private Vector2 wgtDvyAHNuGOigROVlJPIcIghVwE()
			{
				if (dUEarOazcbYhnSAuJtYGyikBzFm == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = EkeWbYkwqrFcmKHaeJGGztoVEQe<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = EkeWbYkwqrFcmKHaeJGGztoVEQe<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRaw ?? 0f;
				float valueRawY = axis2?.valueRaw ?? 0f;
				return dUEarOazcbYhnSAuJtYGyikBzFm.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}

			private Vector2 oIWGDFKGZSrGAcvCCeyvoJdtugJq()
			{
				if (dUEarOazcbYhnSAuJtYGyikBzFm == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = EkeWbYkwqrFcmKHaeJGGztoVEQe<Axis>(0, out xAxisIndex);
				Axis axis2 = default(Axis);
				int yAxisIndex = default(int);
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = default(AxisSensitivity2DType);
				float valueRawX = default(float);
				float valueRawY = default(float);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = default(DeadZone2DType);
				while (true)
				{
					int num = 1183794470;
					while (true)
					{
						switch (num ^ 0x468F4524)
						{
						case 3:
							break;
						case 2:
							axis2 = EkeWbYkwqrFcmKHaeJGGztoVEQe<Axis>(1, out yAxisIndex);
							num = 1183794469;
							continue;
						case 0:
							defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
							valueRawX = axis?.valueRawPrev ?? 0f;
							valueRawY = axis2?.valueRawPrev ?? 0f;
							num = 1183794464;
							continue;
						case 1:
							defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
							num = 1183794468;
							continue;
						default:
							return dUEarOazcbYhnSAuJtYGyikBzFm.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
						}
						break;
					}
				}
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int CohpSETRHfhPkPrGIUzAVRWyQHg = 8;

			private const int rGwcnhruZucaqlPVJejitqDxIDih = 0;

			private const int MBesYQCPJSLAlnTdvmltCIKZzeX = 1;

			private const int phGyrmysHequPFJVKGgHrWEqnZk = 2;

			private const int CtjxYSouttmeiAGkJrfCJsMcBgnC = 3;

			private const int hCFSUGYcUKgIXyNUJcHYLIOnFAP = 4;

			private const int tYDpclqmVvZUzEBOyUDLzbiolSJ = 5;

			private const int hNtBQScAXnKULgTJveYJkHuUdBz = 6;

			private const int OFHFFmbfhRZFJdCDYLqyDfnFZMPc = 7;

			private readonly int bIVKqEWQlcsQuBjQNcfTnhQBcMzH;

			private readonly Button[] duQdUwWCoAwHNtdgoIMHHlMkZKgA;

			private readonly ReadOnlyCollection<Button> ILEZDgZMuHXeKqhmTiPMOJWznrC;

			private readonly int[] HUnbwMCCUGGQUSqfkEzSpQELjEun;

			private bool vukFPNQLGYNvCmRIuAbPwZVAAuV;

			public override int elementCapacity => 8;

			public bool force4Way
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					return vukFPNQLGYNvCmRIuAbPwZVAAuV;
				}
				set
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						while (true)
						{
							switch (0x6D7C3C26 ^ 0x6D7C3C24)
							{
							case 0:
								continue;
							case 2:
								ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
								return;
							}
							break;
						}
					}
					vukFPNQLGYNvCmRIuAbPwZVAAuV = value;
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0;
					}
					return bIVKqEWQlcsQuBjQNcfTnhQBcMzH;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return ILEZDgZMuHXeKqhmTiPMOJWznrC;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return WPeqKlrsUlCkyNVaxZHjSbqAJOj<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return WPeqKlrsUlCkyNVaxZHjSbqAJOj<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return WPeqKlrsUlCkyNVaxZHjSbqAJOj<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return WPeqKlrsUlCkyNVaxZHjSbqAJOj<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return WPeqKlrsUlCkyNVaxZHjSbqAJOj<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return WPeqKlrsUlCkyNVaxZHjSbqAJOj<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return WPeqKlrsUlCkyNVaxZHjSbqAJOj<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return WPeqKlrsUlCkyNVaxZHjSbqAJOj<Button>(7);
				}
			}

			internal Hat(Controller controller, int elementIdentifierId, string name, Button[] buttons, int[] buttonIndices)
				: base(controller, elementIdentifierId, name, CompoundControllerElementType.Hat)
			{
				int num = ((buttons != null) ? buttons.Length : 0);
				if (num != ((buttonIndices != null) ? buttonIndices.Length : 0))
				{
					throw new ArgumentException("button.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4 && num != 8)
				{
					throw new ArgumentException("button.Length must be 0, 4, or 8! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					itKYLEidIwjerGGrDGqPNskdaYz(buttons[i], buttonIndices[i]);
				}
				duQdUwWCoAwHNtdgoIMHHlMkZKgA = buttons;
				HUnbwMCCUGGQUSqfkEzSpQELjEun = buttonIndices;
				bIVKqEWQlcsQuBjQNcfTnhQBcMzH = num;
				ILEZDgZMuHXeKqhmTiPMOJWznrC = new ReadOnlyCollection<Button>(buttons);
			}

			internal void fEfTuMgIgNspmcJifDAbjyclSfZ(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (bIVKqEWQlcsQuBjQNcfTnhQBcMzH == 0)
				{
					return;
				}
				int num3 = default(int);
				while (true)
				{
					int num;
					int num2;
					if (bIVKqEWQlcsQuBjQNcfTnhQBcMzH == 8)
					{
						num = -750428118;
						num2 = num;
					}
					else
					{
						num = -750428113;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -750428118)
						{
						case 10:
							num = -750428127;
							continue;
						case 1:
							GQusjNaCrEgjgOeIfmEqNkwouSb(duQdUwWCoAwHNtdgoIMHHlMkZKgA[0], HUnbwMCCUGGQUSqfkEzSpQELjEun[0], HUnbwMCCUGGQUSqfkEzSpQELjEun[7], HUnbwMCCUGGQUSqfkEzSpQELjEun[1], P_0, P_1);
							GQusjNaCrEgjgOeIfmEqNkwouSb(duQdUwWCoAwHNtdgoIMHHlMkZKgA[2], HUnbwMCCUGGQUSqfkEzSpQELjEun[2], HUnbwMCCUGGQUSqfkEzSpQELjEun[1], HUnbwMCCUGGQUSqfkEzSpQELjEun[3], P_0, P_1);
							num = -750428119;
							continue;
						case 5:
							num3 = 0;
							num = -750428125;
							continue;
						case 8:
							duQdUwWCoAwHNtdgoIMHHlMkZKgA[num3].KyHpjvRkJIBKWzDbtHSSnZwunyW(P_0, HUnbwMCCUGGQUSqfkEzSpQELjEun[num3], P_1);
							num = -750428115;
							continue;
						case 0:
							if (!vukFPNQLGYNvCmRIuAbPwZVAAuV)
							{
								int num5;
								if (!ReInput.configVars.force4WayHats)
								{
									num = -750428113;
									num5 = num;
								}
								else
								{
									num = -750428117;
									num5 = num;
								}
								continue;
							}
							goto case 1;
						case 7:
							num3++;
							num = -750428125;
							continue;
						case 6:
							LAwnRXmEttgxrsMoJGyGTUoUyeO(duQdUwWCoAwHNtdgoIMHHlMkZKgA[1], HUnbwMCCUGGQUSqfkEzSpQELjEun[1], P_0, P_1);
							LAwnRXmEttgxrsMoJGyGTUoUyeO(duQdUwWCoAwHNtdgoIMHHlMkZKgA[3], HUnbwMCCUGGQUSqfkEzSpQELjEun[3], P_0, P_1);
							LAwnRXmEttgxrsMoJGyGTUoUyeO(duQdUwWCoAwHNtdgoIMHHlMkZKgA[5], HUnbwMCCUGGQUSqfkEzSpQELjEun[5], P_0, P_1);
							LAwnRXmEttgxrsMoJGyGTUoUyeO(duQdUwWCoAwHNtdgoIMHHlMkZKgA[7], HUnbwMCCUGGQUSqfkEzSpQELjEun[7], P_0, P_1);
							return;
						case 3:
							GQusjNaCrEgjgOeIfmEqNkwouSb(duQdUwWCoAwHNtdgoIMHHlMkZKgA[4], HUnbwMCCUGGQUSqfkEzSpQELjEun[4], HUnbwMCCUGGQUSqfkEzSpQELjEun[5], HUnbwMCCUGGQUSqfkEzSpQELjEun[3], P_0, P_1);
							num = -750428120;
							continue;
						case 2:
							GQusjNaCrEgjgOeIfmEqNkwouSb(duQdUwWCoAwHNtdgoIMHHlMkZKgA[6], HUnbwMCCUGGQUSqfkEzSpQELjEun[6], HUnbwMCCUGGQUSqfkEzSpQELjEun[5], HUnbwMCCUGGQUSqfkEzSpQELjEun[7], P_0, P_1);
							num = -750428116;
							continue;
						case 11:
							break;
						case 4:
						{
							int num4;
							if (duQdUwWCoAwHNtdgoIMHHlMkZKgA[num3] != null)
							{
								num = -750428126;
								num4 = num;
							}
							else
							{
								num = -750428115;
								num4 = num;
							}
							continue;
						}
						default:
							if (num3 >= duQdUwWCoAwHNtdgoIMHHlMkZKgA.Length)
							{
								return;
							}
							goto case 4;
						}
						break;
					}
				}
			}

			private void GQusjNaCrEgjgOeIfmEqNkwouSb(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
			{
				if (P_0 != null && P_1 >= 0)
				{
					if (P_1 >= P_5.buttonCount)
					{
						goto IL_0014;
					}
					goto IL_00b2;
				}
				return;
				IL_004d:
				P_5.buttonPressureValues[P_1] = MathTools.MaxMagnitude(P_5.buttonPressureValues[P_1], MathTools.MaxMagnitude((P_2 >= 0 && P_2 < P_5.buttonCount) ? P_5.buttonPressureValues[P_2] : 0f, (P_3 >= 0 && P_3 < P_5.buttonCount) ? P_5.buttonPressureValues[P_3] : 0f));
				int num = -1013929916;
				goto IL_0019;
				IL_00dc:
				if (P_3 >= 0 && P_3 < P_5.buttonCount)
				{
					ref bool reference = ref P_5.buttonValues[P_1];
					reference |= P_5.buttonValues[P_3];
					num = -1013929916;
					goto IL_0019;
				}
				goto IL_0145;
				IL_0014:
				num = -1013929919;
				goto IL_0019;
				IL_0019:
				while (true)
				{
					switch (num ^ -1013929920)
					{
					case 0:
						break;
					case 1:
						return;
					case 2:
						goto IL_004d;
					case 5:
						goto IL_00b2;
					case 6:
						goto IL_00dc;
					case 3:
					{
						ref bool reference2 = ref P_5.buttonValues[P_1];
						reference2 |= P_5.buttonValues[P_2];
						num = -1013929914;
						continue;
					}
					default:
						goto IL_0145;
					}
					break;
				}
				goto IL_0014;
				IL_0145:
				P_0.KyHpjvRkJIBKWzDbtHSSnZwunyW(P_4, P_1, P_5);
				return;
				IL_00b2:
				if (P_0.isPressureSensitive)
				{
					goto IL_004d;
				}
				if (P_2 >= 0)
				{
					int num2;
					if (P_2 < P_5.buttonCount)
					{
						num = -1013929917;
						num2 = num;
					}
					else
					{
						num = -1013929914;
						num2 = num;
					}
					goto IL_0019;
				}
				goto IL_00dc;
			}

			private void LAwnRXmEttgxrsMoJGyGTUoUyeO(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
			{
				if (P_0 != null && P_1 >= 0)
				{
					if (P_1 >= P_3.buttonCount)
					{
						goto IL_0011;
					}
					goto IL_0054;
				}
				return;
				IL_0054:
				int num;
				if (!P_0.isPressureSensitive)
				{
					P_3.buttonValues[P_1] = false;
					num = 1678080090;
					goto IL_0016;
				}
				goto IL_003f;
				IL_003f:
				P_3.buttonPressureValues[P_1] = 0f;
				num = 1678080090;
				goto IL_0016;
				IL_0011:
				num = 1678080091;
				goto IL_0016;
				IL_0016:
				switch (num ^ 0x6405785A)
				{
				case 2:
					break;
				case 1:
					return;
				case 4:
					goto IL_003f;
				case 3:
					goto IL_0054;
				default:
					P_0.KyHpjvRkJIBKWzDbtHSSnZwunyW(P_2, P_1, P_3);
					return;
				}
				goto IL_0011;
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller PQxjKAQNRjWZaZhctvIytmcdtVz;

			private IControllerExtensionSource FzAfZmFeJSmPEcrqFTJfQfeHdrSY;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (PQxjKAQNRjWZaZhctvIytmcdtVz == null)
					{
						return false;
					}
					return PQxjKAQNRjWZaZhctvIytmcdtVz._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (PQxjKAQNRjWZaZhctvIytmcdtVz == null)
					{
						return false;
					}
					return PQxjKAQNRjWZaZhctvIytmcdtVz.enabled;
				}
			}

			internal Controller controller => PQxjKAQNRjWZaZhctvIytmcdtVz;

			internal Extension(IControllerExtensionSource source)
			{
				_reInputId = ReInput.id;
				vHmaocpbczeHzBCPmqBFHqLUIqv(source);
			}

			internal Extension(Extension source)
				: this(source.FzAfZmFeJSmPEcrqFTJfQfeHdrSY)
			{
				PQxjKAQNRjWZaZhctvIytmcdtVz = source.PQxjKAQNRjWZaZhctvIytmcdtVz;
			}

			internal T GetController<T>() where T : Controller
			{
				if (PQxjKAQNRjWZaZhctvIytmcdtVz == null)
				{
					return null;
				}
				return PQxjKAQNRjWZaZhctvIytmcdtVz as T;
			}

			internal void SetController(Controller controller)
			{
				PQxjKAQNRjWZaZhctvIytmcdtVz = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					vHmaocpbczeHzBCPmqBFHqLUIqv(null);
				}
				else
				{
					vHmaocpbczeHzBCPmqBFHqLUIqv(extension.FzAfZmFeJSmPEcrqFTJfQfeHdrSY);
				}
			}

			private void vHmaocpbczeHzBCPmqBFHqLUIqv(IControllerExtensionSource P_0)
			{
				FzAfZmFeJSmPEcrqFTJfQfeHdrSY = P_0;
				SourceUpdated(FzAfZmFeJSmPEcrqFTJfQfeHdrSY);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		private sealed class wTHUdQcwPCPsUDtVNlgxuTqObzR : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public Controller syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int PSmjXiTtTWKPkmLbUbHkvOzjvZk;

			public int KymsZLxwmqDwdrDZaEeorwMiEatd;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				wTHUdQcwPCPsUDtVNlgxuTqObzR wTHUdQcwPCPsUDtVNlgxuTqObzR2;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					wTHUdQcwPCPsUDtVNlgxuTqObzR2 = this;
					goto IL_0025;
				}
				goto IL_0065;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ -748768834)
					{
					case 3:
						break;
					case 1:
						num = -748768838;
						continue;
					case 0:
						wTHUdQcwPCPsUDtVNlgxuTqObzR2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -748768838;
						continue;
					case 2:
						goto IL_0065;
					default:
						return wTHUdQcwPCPsUDtVNlgxuTqObzR2;
					}
					break;
				}
				goto IL_0025;
				IL_0065:
				wTHUdQcwPCPsUDtVNlgxuTqObzR2 = new wTHUdQcwPCPsUDtVNlgxuTqObzR(0);
				num = -748768834;
				goto IL_002a;
				IL_0025:
				num = -748768833;
				goto IL_002a;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = 1128337737;
					while (true)
					{
						switch (num2 ^ 0x4341114F)
						{
						case 8:
							break;
						case 6:
							switch (num)
							{
							default:
								num2 = 1128337743;
								continue;
							case 0:
								break;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = 1128337738;
								continue;
							}
							goto case 3;
						case 3:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							if (ReInput._id != syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM)
							{
								ReInput.CheckInitialized(syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM);
								num2 = 1128337743;
								continue;
							}
							goto case 4;
						case 1:
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.VyNMjyofhyiUaQHxXahPQgjynMV(PSmjXiTtTWKPkmLbUbHkvOzjvZk, out KymsZLxwmqDwdrDZaEeorwMiEatd))
							{
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = new ControllerPollingInfo(success: true, -1, syCPfFbHYMDOvEPjTnPLBqiOhsPv.id, syCPfFbHYMDOvEPjTnPLBqiOhsPv._name, syCPfFbHYMDOvEPjTnPLBqiOhsPv._type, ControllerElementType.Button, PSmjXiTtTWKPkmLbUbHkvOzjvZk, Pole.Positive, syCPfFbHYMDOvEPjTnPLBqiOhsPv.REZiFujnwfIcWniRKvMxDxhPHlx.GetElementIdentifierName(KymsZLxwmqDwdrDZaEeorwMiEatd), KymsZLxwmqDwdrDZaEeorwMiEatd, KeyCode.None);
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							}
							goto case 5;
						case 5:
							PSmjXiTtTWKPkmLbUbHkvOzjvZk++;
							num2 = 1128337741;
							continue;
						case 2:
						{
							int num3;
							if (PSmjXiTtTWKPkmLbUbHkvOzjvZk < syCPfFbHYMDOvEPjTnPLBqiOhsPv._buttonCount)
							{
								num2 = 1128337742;
								num3 = num2;
							}
							else
							{
								num2 = 1128337743;
								num3 = num2;
							}
							continue;
						}
						case 4:
							syCPfFbHYMDOvEPjTnPLBqiOhsPv.UpdatePollingFrameTracking();
							num2 = 1128337736;
							continue;
						case 7:
							PSmjXiTtTWKPkmLbUbHkvOzjvZk = 0;
							num2 = 1128337741;
							continue;
						default:
							return false;
						}
						break;
					}
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public wTHUdQcwPCPsUDtVNlgxuTqObzR(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class dRDxWioWXwNLRZGCcrALAvWQkBV : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public Controller syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int FCjorMvNvAhWDcPkzkuoCFHHzINm;

			public int bECUaqyHjrMWSaPvgPUyOtIzoKb;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				dRDxWioWXwNLRZGCcrALAvWQkBV dRDxWioWXwNLRZGCcrALAvWQkBV2;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					dRDxWioWXwNLRZGCcrALAvWQkBV2 = this;
				}
				else
				{
					while (true)
					{
						dRDxWioWXwNLRZGCcrALAvWQkBV2 = new dRDxWioWXwNLRZGCcrALAvWQkBV(0);
						dRDxWioWXwNLRZGCcrALAvWQkBV2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						int num = -362881897;
						while (true)
						{
							switch (num ^ -362881899)
							{
							case 0:
								num = -362881900;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0045;
							}
							break;
						}
						continue;
						end_IL_0045:
						break;
					}
				}
				return dRDxWioWXwNLRZGCcrALAvWQkBV2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					num = -499600031;
					goto IL_001f;
				case 0:
					goto IL_0145;
					IL_001f:
					while (true)
					{
						switch (num ^ -499600023)
						{
						case 4:
							num = -499600018;
							continue;
						case 6:
							break;
						case 0:
							goto IL_007b;
						case 3:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = new ControllerPollingInfo(success: true, -1, syCPfFbHYMDOvEPjTnPLBqiOhsPv.id, syCPfFbHYMDOvEPjTnPLBqiOhsPv._name, syCPfFbHYMDOvEPjTnPLBqiOhsPv._type, ControllerElementType.Button, FCjorMvNvAhWDcPkzkuoCFHHzINm, Pole.Positive, syCPfFbHYMDOvEPjTnPLBqiOhsPv.REZiFujnwfIcWniRKvMxDxhPHlx.GetElementIdentifierName(bECUaqyHjrMWSaPvgPUyOtIzoKb), bECUaqyHjrMWSaPvgPUyOtIzoKb, KeyCode.None);
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							num = -499600021;
							continue;
						case 1:
							goto end_IL_001f;
						case 9:
							FCjorMvNvAhWDcPkzkuoCFHHzINm = 0;
							num = -499600017;
							continue;
						case 2:
							return true;
						case 7:
							goto IL_0145;
						case 8:
							FCjorMvNvAhWDcPkzkuoCFHHzINm++;
							num = -499600017;
							continue;
						default:
							goto end_IL_0008;
						}
						int num2;
						if (FCjorMvNvAhWDcPkzkuoCFHHzINm >= syCPfFbHYMDOvEPjTnPLBqiOhsPv._buttonCount)
						{
							num = -499600020;
							num2 = num;
						}
						else
						{
							num = -499600023;
							num2 = num;
						}
						continue;
						IL_007b:
						int num3;
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.HRUapOGtGfLQdRrqbmxCDPEbNerN(FCjorMvNvAhWDcPkzkuoCFHHzINm, out bECUaqyHjrMWSaPvgPUyOtIzoKb))
						{
							num = -499600022;
							num3 = num;
						}
						else
						{
							num = -499600031;
							num3 = num;
						}
						continue;
						end_IL_001f:
						break;
					}
					goto IL_010c;
					IL_0145:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					if (ReInput._id != syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM);
						num = -499600020;
						goto IL_001f;
					}
					goto IL_010c;
					IL_010c:
					syCPfFbHYMDOvEPjTnPLBqiOhsPv.UpdatePollingFrameTracking();
					num = -499600032;
					goto IL_001f;
					end_IL_0008:
					break;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public dRDxWioWXwNLRZGCcrALAvWQkBV(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		public readonly int id;

		protected string _tag;

		protected string _name;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid WhXaNimcOuXdrXZrlSbhrrJNttC;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension XRrbuPDOAbJMnDUNcTrqkgwkvwmk;

		private bool FnzJwrQpikWfZbmfjZhFwutJGAA;

		private ControllerIdentifier gyqFEphNyfYjUojOwdzyQtrZMsoJ;

		internal int vuPDNwATQFuTZgAqTRoviXUGAgFM;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> OZXcSZtVrQPQPLpKldDeETdguIN;

		private readonly ReadOnlyCollection<Element> mpWcvIBYZzhvfGlpsJRRLOVkPPkn;

		internal readonly InputSource IRTGlhOkWOimkumhYFSkdpOYbETD;

		internal readonly ControllerDataUpdater cMcAtEwaThLpgGZfIIRmVCJQjDU;

		internal readonly HardwareControllerMap_Game REZiFujnwfIcWniRKvMxDxhPHlx;

		internal uint LPRvVuBbNdwGHkLtadwNDWvlXBr;

		private uint FMTILBNYTafMalkCXFAOqAUXTFn;

		private uint KwDoxZjwzCgIHfdFyDXmHTtAbVl;

		private Action<bool> ViElVhCmKJNZGzfohfDCJGshGWjB;

		private IControllerTemplate[] cizCCZbGlFPBIOIAeQyVhpdKKxk;

		private ReadOnlyCollection<IControllerTemplate> sjtuOUEDjjFUIqOhxfXNdeSazWX;

		private static Func<Controller, Guid, bool> XACBgKOcmcuLACKcDIIBWxTNoLo;

		private static Func<Controller, Type, bool> MAcVkpDivFYquwLqjbpLbDzRmGXu;

		[CompilerGenerated]
		private static Func<Controller, Guid, bool> OgstaTqPAOzzFqCzJSUslPPVDpI;

		[CompilerGenerated]
		private static Func<Controller, Type, bool> JzBaUdlwHurNHsAdDtAfhdMolvT;

		internal bool wasPollingPrev => FMTILBNYTafMalkCXFAOqAUXTFn == ReInput.previousFrame;

		public bool enabled
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				}
				return FnzJwrQpikWfZbmfjZhFwutJGAA;
			}
			set
			{
				wytyBiLPSMGfQbbdKPNlzybFrlR(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return string.Empty;
				}
				return _name;
			}
			internal set
			{
				_name = value;
			}
		}

		public string tag
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				}
				else
				{
					_tag = value;
				}
			}
		}

		public string hardwareName
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Guid.Empty;
				}
				return WhXaNimcOuXdrXZrlSbhrrJNttC;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => gyqFEphNyfYjUojOwdzyQtrZMsoJ;

		public bool isConnected
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return;
				}
				while (!value)
				{
					Disconnected();
					int num = -419397803;
					while (true)
					{
						switch (num ^ -419397804)
						{
						case 3:
							num = -419397802;
							continue;
						case 2:
							break;
						case 1:
							return;
						default:
							goto end_IL_003c;
						}
						break;
					}
					continue;
					end_IL_003c:
					break;
				}
				Connected();
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return string.Empty;
				}
				return _hardwareIdentifier;
			}
		}

		public string mapTypeString => _type.ToString() + "Map";

		public int elementCount
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0;
				}
				return OZXcSZtVrQPQPLpKldDeETdguIN.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return mpWcvIBYZzhvfGlpsJRRLOVkPPkn;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return XRrbuPDOAbJMnDUNcTrqkgwkvwmk;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return REZiFujnwfIcWniRKvMxDxhPHlx.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return REZiFujnwfIcWniRKvMxDxhPHlx.buttonElementIdentifiers_readOnly;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return sjtuOUEDjjFUIqOhxfXNdeSazWX;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					while (true)
					{
						int num = -1111918282;
						while (true)
						{
							switch (num ^ -1111918284)
							{
							case 0:
								break;
							case 2:
								goto IL_002b;
							default:
								return 0;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num = -1111918283;
						}
					}
				}
				return cizCCZbGlFPBIOIAeQyVhpdKKxk.Length;
			}
		}

		internal static Func<Controller, Guid, bool> implementsTemplateDelegate_Guid => (Controller P_0, Guid P_1) => P_0.ImplementsTemplate(P_1);

		internal static Func<Controller, Type, bool> implementsTemplateDelegate_Type
		{
			get
			{
				Func<Controller, Type, bool> func = MAcVkpDivFYquwLqjbpLbDzRmGXu;
				if (func == null)
				{
					if (JzBaUdlwHurNHsAdDtAfhdMolvT == null)
					{
						while (true)
						{
							int num = 1073814217;
							while (true)
							{
								switch (num ^ 0x40011AC8)
								{
								case 2:
									break;
								case 1:
									JzBaUdlwHurNHsAdDtAfhdMolvT = (Controller P_0, Type P_1) => P_0.ImplementsTemplate(P_1);
									num = 1073814216;
									continue;
								default:
									goto end_IL_0010;
								}
								break;
							}
							continue;
							end_IL_0010:
							break;
						}
					}
					func = (MAcVkpDivFYquwLqjbpLbDzRmGXu = JzBaUdlwHurNHsAdDtAfhdMolvT);
				}
				return func;
			}
		}

		internal event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				ViElVhCmKJNZGzfohfDCJGshGWjB = (Action<bool>)Delegate.Combine(ViElVhCmKJNZGzfohfDCJGshGWjB, value);
			}
			remove
			{
				ViElVhCmKJNZGzfohfDCJGshGWjB = (Action<bool>)Delegate.Remove(ViElVhCmKJNZGzfohfDCJGshGWjB, value);
			}
		}

		internal Controller(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, ControllerType type, Guid hardwareTypeGuid, int buttonCount, bool[] isButtonPressureSensitive, HardwareButtonInfo[] hwButtonInfo, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
		{
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = 1381632651;
				while (true)
				{
					switch (num ^ 0x525A0A8A)
					{
					case 5:
						break;
					default:
						return;
					case 10:
						_name = name;
						_hardwareName = hardwareName;
						_hardwareIdentifier = hardwareIdentifier;
						cMcAtEwaThLpgGZfIIRmVCJQjDU = dataUpdater;
						REZiFujnwfIcWniRKvMxDxhPHlx = hardwareMap;
						FnzJwrQpikWfZbmfjZhFwutJGAA = true;
						num = 1381632650;
						continue;
					case 9:
						if (num3 >= buttonCount)
						{
							num = 1381632648;
							continue;
						}
						goto case 18;
					case 8:
						num2 = 0;
						num = 1381632645;
						continue;
					case 13:
						cizCCZbGlFPBIOIAeQyVhpdKKxk = EmptyObjects<IControllerTemplate>.array;
						sjtuOUEDjjFUIqOhxfXNdeSazWX = new ReadOnlyCollection<IControllerTemplate>(cizCCZbGlFPBIOIAeQyVhpdKKxk);
						num = 1381632654;
						continue;
					case 7:
						IRTGlhOkWOimkumhYFSkdpOYbETD = inputSource;
						_type = type;
						WhXaNimcOuXdrXZrlSbhrrJNttC = hardwareTypeGuid;
						num = 1381632666;
						continue;
					case 15:
					{
						int num5;
						if (num2 < buttonCount)
						{
							num = 1381632641;
							num5 = num;
						}
						else
						{
							num = 1381632648;
							num5 = num;
						}
						continue;
					}
					case 2:
						buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
						num = 1381632647;
						continue;
					case 18:
						buttons[num3] = new Button(this, hardwareMap.buttonElementIdentifierIds[num3], "Button " + num3, isPressureSensitive: false, (hwButtonInfo != null) ? hwButtonInfo[num3] : new HardwareButtonInfo());
						itKYLEidIwjerGGrDGqPNskdaYz(buttons[num3]);
						num3++;
						num = 1381632643;
						continue;
					case 14:
						OZXcSZtVrQPQPLpKldDeETdguIN = new List<Element>(buttonCount);
						mpWcvIBYZzhvfGlpsJRRLOVkPPkn = new ReadOnlyCollection<Element>(OZXcSZtVrQPQPLpKldDeETdguIN);
						buttons = new Button[buttonCount];
						if (isButtonPressureSensitive != null)
						{
							int num4;
							if (isButtonPressureSensitive.Length < buttonCount)
							{
								num = 1381632649;
								num4 = num;
							}
							else
							{
								num = 1381632642;
								num4 = num;
							}
							continue;
						}
						goto case 3;
					case 0:
						vuPDNwATQFuTZgAqTRoviXUGAgFM = ReInput.id;
						crQnLutgKZoSSMlUmZAkqAvIErv(extension);
						num = 1381632644;
						continue;
					case 11:
						buttons[num2] = new Button(this, hardwareMap.buttonElementIdentifierIds[num2], "Button " + num2, isButtonPressureSensitive[num2], (hwButtonInfo != null) ? hwButtonInfo[num2] : new HardwareButtonInfo());
						num = 1381632646;
						continue;
					case 1:
						id = controllerId;
						num = 1381632653;
						continue;
					case 6:
						num = 1381632643;
						continue;
					case 4:
						Connected();
						num = 1381632667;
						continue;
					case 16:
						_buttonCount = buttonCount;
						num = 1381632640;
						continue;
					case 12:
						itKYLEidIwjerGGrDGqPNskdaYz(buttons[num2]);
						num2++;
						num = 1381632645;
						continue;
					case 3:
						num3 = 0;
						num = 1381632652;
						continue;
					case 17:
						return;
					}
					break;
				}
			}
		}

		internal virtual void aNzXPWgGkyjIHrJsRxlIZSjJoXv()
		{
			gyqFEphNyfYjUojOwdzyQtrZMsoJ = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num;
			int buttonIndex = default(int);
			if (REZiFujnwfIcWniRKvMxDxhPHlx == null)
			{
				num = -225804071;
			}
			else
			{
				buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
				num = -225804072;
			}
			goto IL_0012;
			IL_000d:
			num = -225804070;
			goto IL_0012;
			IL_0012:
			switch (num ^ -225804071)
			{
			case 2:
				break;
			case 3:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			case 0:
				return null;
			default:
				if (buttonIndex < 0)
				{
					return null;
				}
				return buttons[buttonIndex];
			}
			goto IL_000d;
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return -1;
			}
			return REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			return REZiFujnwfIcWniRKvMxDxhPHlx.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = 612633281;
					goto IL_0012;
				}
				return buttons[index].value;
			}
			goto IL_004d;
			IL_0012:
			switch (num ^ 0x24840AC1)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			default:
				goto IL_004d;
			}
			goto IL_000d;
			IL_000d:
			num = 612633280;
			goto IL_0012;
			IL_004d:
			return false;
		}

		public virtual bool GetButtonDown(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (index < 0)
			{
				num = -2146195103;
				num2 = num;
			}
			else
			{
				num = -2146195100;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = -2146195098;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -2146195099)
				{
				case 0:
					break;
				case 3:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					num = -2146195097;
					continue;
				case 1:
					if (index >= _buttonCount)
					{
						num = -2146195103;
						continue;
					}
					return buttons[index].justPressed;
				case 2:
					return false;
				default:
					return false;
				}
				break;
			}
			goto IL_000d;
		}

		public virtual bool GetButtonUp(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].justReleased;
		}

		public virtual bool GetButtonChanged(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if (index >= 0)
			{
				while (true)
				{
					int num = -1518231649;
					while (true)
					{
						switch (num ^ -1518231650)
						{
						case 2:
							break;
						case 1:
							goto IL_003d;
						default:
							goto end_IL_001f;
						}
						break;
						IL_003d:
						if (index >= _buttonCount)
						{
							num = -1518231650;
							continue;
						}
						return buttons[index].value != buttons[index].valuePrev;
					}
					continue;
					end_IL_001f:
					break;
				}
			}
			return false;
		}

		public virtual bool GetButtonPrev(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = 1804566033;
					goto IL_0012;
				}
				return buttons[index].valuePrev;
			}
			goto IL_004d;
			IL_0012:
			switch (num ^ 0x6B8F7E11)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			default:
				goto IL_004d;
			}
			goto IL_000d;
			IL_000d:
			num = 1804566032;
			goto IL_0012;
			IL_004d:
			return false;
		}

		public virtual bool GetButtonDoublePressHold(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = 457217830;
				num2 = num;
			}
			else
			{
				num = 457217828;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 457217831;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x1B409725)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				case 3:
					if (index >= _buttonCount)
					{
						goto IL_005b;
					}
					return buttons[index].DoublePressedAndHeld(speed);
				default:
					return false;
				}
				break;
				IL_005b:
				num = 457217828;
			}
			goto IL_000d;
		}

		public virtual bool GetButtonDoublePressDown(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = 420800319;
					goto IL_001e;
				}
				return buttons[index].JustDoublePressed(speed);
			}
			goto IL_004d;
			IL_001e:
			switch (num ^ 0x1914E73D)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				goto IL_004d;
			}
			goto IL_0019;
			IL_0019:
			num = 420800316;
			goto IL_001e;
			IL_004d:
			return false;
		}

		public virtual double GetButtonTimePressed(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = -945720421;
					goto IL_001e;
				}
				return buttons[index].timePressed;
			}
			goto IL_0055;
			IL_001e:
			switch (num ^ -945720423)
			{
			case 0:
				break;
			case 1:
				return 0.0;
			default:
				goto IL_0055;
			}
			goto IL_0019;
			IL_0019:
			num = -945720424;
			goto IL_001e;
			IL_0055:
			return 0.0;
		}

		public virtual double GetButtonTimeUnpressed(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = 1313342621;
					goto IL_0012;
				}
				return buttons[index].timeUnpressed;
			}
			goto IL_0060;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x4E48049E)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					num = 1313342623;
					continue;
				case 1:
					return 0.0;
				default:
					goto IL_0060;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = 1313342620;
			goto IL_0012;
			IL_0060:
			return 0.0;
		}

		public virtual double GetButtonLastTimePressed(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = 1189548428;
					goto IL_0012;
				}
				return buttons[index].lastTimePressed;
			}
			goto IL_0055;
			IL_0012:
			switch (num ^ 0x46E7118E)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			default:
				goto IL_0055;
			}
			goto IL_000d;
			IL_000d:
			num = 1189548431;
			goto IL_0012;
			IL_0055:
			return 0.0;
		}

		public virtual double GetButtonLastTimeUnpressed(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].lastTimeUnpressed;
		}

		public virtual bool GetAnyButton()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num = 0;
			int num2 = -1282387783;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num2 ^ -1282387784)
				{
				case 2:
					break;
				case 1:
				{
					int num3;
					if (num >= _buttonCount)
					{
						num2 = -1282387780;
						num3 = num2;
					}
					else
					{
						num2 = -1282387784;
						num3 = num2;
					}
					continue;
				}
				case 0:
					if (buttons[num].value)
					{
						return true;
					}
					num++;
					num2 = -1282387783;
					continue;
				case 3:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				default:
					return false;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num2 = -1282387781;
			goto IL_0012;
		}

		public virtual bool GetAnyButtonDown()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < _buttonCount)
				{
					num2 = -1860753376;
					num3 = num2;
				}
				else
				{
					num2 = -1860753374;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1860753374)
					{
					case 3:
						num2 = -1860753376;
						continue;
					case 2:
						if (buttons[num].justPressed)
						{
							return true;
						}
						num++;
						num2 = -1860753373;
						continue;
					case 1:
						break;
					default:
						return false;
					}
					break;
				}
			}
		}

		public virtual bool GetAnyButtonUp()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= _buttonCount)
				{
					num2 = 1112842979;
					num3 = num2;
				}
				else
				{
					num2 = 1112842977;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x4254A2E3)
					{
					case 3:
						num2 = 1112842977;
						continue;
					case 2:
						if (buttons[num].justReleased)
						{
							return true;
						}
						num++;
						num2 = 1112842978;
						continue;
					case 1:
						break;
					default:
						return false;
					}
					break;
				}
			}
		}

		public virtual bool GetAnyButtonPrev()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < _buttonCount)
				{
					num2 = 1905757402;
					num3 = num2;
				}
				else
				{
					num2 = 1905757405;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x71978CDE)
					{
					case 0:
						num2 = 1905757402;
						continue;
					case 4:
						if (buttons[num].valuePrev)
						{
							num2 = 1905757404;
							continue;
						}
						num++;
						num2 = 1905757407;
						continue;
					case 1:
						break;
					case 2:
						return true;
					default:
						return false;
					}
					break;
				}
			}
		}

		public virtual bool GetAnyButtonChanged()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = -2052641738;
				while (true)
				{
					switch (num2 ^ -2052641737)
					{
					case 0:
						break;
					case 1:
						num2 = -2052641740;
						continue;
					case 2:
						if (buttons[num].justChangedState)
						{
							return true;
						}
						num++;
						num2 = -2052641740;
						continue;
					default:
						if (num >= _buttonCount)
						{
							return false;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public virtual bool GetButtonById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].value;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
			int num = -1507931916;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1507931913)
				{
				case 0:
					break;
				case 3:
					if (buttonIndex >= 0)
					{
						if (buttonIndex >= _buttonCount)
						{
							num = -1507931914;
							continue;
						}
						return buttons[buttonIndex].justPressed;
					}
					goto default;
				case 2:
					return false;
				case 4:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					num = -1507931915;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = -1507931917;
			goto IL_0012;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
			int num;
			if (buttonIndex >= 0)
			{
				if (buttonIndex >= _buttonCount)
				{
					num = -129333957;
					goto IL_001e;
				}
				return buttons[buttonIndex].justReleased;
			}
			goto IL_005a;
			IL_001e:
			switch (num ^ -129333957)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				goto IL_005a;
			}
			goto IL_0019;
			IL_0019:
			num = -129333958;
			goto IL_001e;
			IL_005a:
			return false;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
			int num;
			if (buttonIndex >= 0)
			{
				if (buttonIndex >= _buttonCount)
				{
					num = 1554477755;
					goto IL_0012;
				}
				return buttons[buttonIndex].JustDoublePressed(speed);
			}
			goto IL_005a;
			IL_0012:
			switch (num ^ 0x5CA772B9)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			default:
				goto IL_005a;
			}
			goto IL_000d;
			IL_000d:
			num = 1554477752;
			goto IL_0012;
			IL_005a:
			return false;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].valuePrev;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
			int num = -197462788;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -197462792)
				{
				case 0:
					break;
				case 3:
					return 0.0;
				case 4:
				{
					int num2;
					if (buttonIndex >= 0)
					{
						num = -197462791;
						num2 = num;
					}
					else
					{
						num = -197462790;
						num2 = num;
					}
					continue;
				}
				case 1:
					if (buttonIndex >= _buttonCount)
					{
						num = -197462790;
						continue;
					}
					return buttons[buttonIndex].timePressed;
				default:
					return 0.0;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num = -197462789;
			goto IL_001e;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
			int num = 1575819286;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x5DED1812)
				{
				case 0:
					break;
				case 1:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					num = 1575819280;
					continue;
				case 2:
					return 0.0;
				case 3:
					if (buttonIndex >= _buttonCount)
					{
						num = 1575819287;
						continue;
					}
					return buttons[buttonIndex].lastTimePressed;
				case 4:
				{
					int num2;
					if (buttonIndex < 0)
					{
						num = 1575819287;
						num2 = num;
					}
					else
					{
						num = 1575819281;
						num2 = num;
					}
					continue;
				}
				default:
					return 0.0;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = 1575819283;
			goto IL_0012;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			int buttonIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimeUnpressed;
		}

		public virtual ControllerPollingInfo PollForFirstElement()
		{
			return PollForFirstButton();
		}

		public virtual ControllerPollingInfo PollForFirstElementDown()
		{
			return PollForFirstButtonDown();
		}

		public virtual ControllerPollingInfo PollForFirstButton()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_001c;
			}
			UpdatePollingFrameTracking();
			int num = 0;
			int num2 = -717296428;
			goto IL_0021;
			IL_0021:
			while (true)
			{
				switch (num2 ^ -717296425)
				{
				case 0:
					break;
				case 3:
				{
					int num3;
					if (num < _buttonCount)
					{
						num2 = -717296429;
						num3 = num2;
					}
					else
					{
						num2 = -717296427;
						num3 = num2;
					}
					continue;
				}
				case 4:
				{
					if (VyNMjyofhyiUaQHxXahPQgjynMV(num, out var elementIdentifierId))
					{
						return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Button, num, Pole.Positive, REZiFujnwfIcWniRKvMxDxhPHlx.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
					}
					num++;
					num2 = -717296428;
					continue;
				}
				case 1:
					return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				default:
					return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
				}
				break;
			}
			goto IL_001c;
			IL_001c:
			num2 = -717296426;
			goto IL_0021;
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
			}
			UpdatePollingFrameTracking();
			int num = 0;
			int elementIdentifierId = default(int);
			while (true)
			{
				int num2 = 1277266600;
				while (true)
				{
					switch (num2 ^ 0x4C218AA9)
					{
					case 0:
						break;
					case 1:
						num2 = 1277266605;
						continue;
					case 2:
						if (HRUapOGtGfLQdRrqbmxCDPEbNerN(num, out elementIdentifierId))
						{
							num2 = 1277266602;
							continue;
						}
						num++;
						num2 = 1277266605;
						continue;
					case 3:
						return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Button, num, Pole.Positive, REZiFujnwfIcWniRKvMxDxhPHlx.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
					default:
						if (num >= _buttonCount)
						{
							return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return PollForAllButtons();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return PollForAllButtonsDown();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			wTHUdQcwPCPsUDtVNlgxuTqObzR wTHUdQcwPCPsUDtVNlgxuTqObzR2 = new wTHUdQcwPCPsUDtVNlgxuTqObzR(-2);
			wTHUdQcwPCPsUDtVNlgxuTqObzR2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			return wTHUdQcwPCPsUDtVNlgxuTqObzR2;
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			dRDxWioWXwNLRZGCcrALAvWQkBV dRDxWioWXwNLRZGCcrALAvWQkBV2 = new dRDxWioWXwNLRZGCcrALAvWQkBV(-2);
			dRDxWioWXwNLRZGCcrALAvWQkBV2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			return dRDxWioWXwNLRZGCcrALAvWQkBV2;
		}

		private bool VyNMjyofhyiUaQHxXahPQgjynMV(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].PwUXLALrfghlFKOmPrArGICsqfV._excludeFromPolling)
			{
				return false;
			}
			P_1 = REZiFujnwfIcWniRKvMxDxhPHlx.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool HRUapOGtGfLQdRrqbmxCDPEbNerN(int P_0, out int P_1)
		{
			P_1 = -1;
			while (true)
			{
				int num = 1540601719;
				while (true)
				{
					switch (num ^ 0x5BD3B776)
					{
					case 2:
						break;
					case 1:
						if (!buttons[P_0].justPressed || buttons[P_0].PwUXLALrfghlFKOmPrArGICsqfV._excludeFromPolling)
						{
							goto IL_004c;
						}
						P_1 = REZiFujnwfIcWniRKvMxDxhPHlx.buttonElementIdentifierIds[P_0];
						if (P_1 < 0)
						{
							return false;
						}
						return true;
					default:
						return false;
					}
					break;
					IL_004c:
					num = 1540601718;
				}
			}
		}

		protected void UpdatePollingFrameTracking()
		{
			if (KwDoxZjwzCgIHfdFyDXmHTtAbVl == ReInput.currentFrame)
			{
				goto IL_000d;
			}
			goto IL_003f;
			IL_000d:
			int num = -1375093753;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1375093757)
				{
				case 0:
					break;
				default:
					return;
				case 4:
					return;
				case 3:
					goto IL_003f;
				case 1:
					if (!wasPollingPrev)
					{
						if (LPRvVuBbNdwGHkLtadwNDWvlXBr == uint.MaxValue)
						{
							LPRvVuBbNdwGHkLtadwNDWvlXBr = 0u;
							return;
						}
						goto case 2;
					}
					return;
				case 2:
					LPRvVuBbNdwGHkLtadwNDWvlXBr++;
					num = -1375093754;
					continue;
				case 5:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_003f:
			FMTILBNYTafMalkCXFAOqAUXTFn = KwDoxZjwzCgIHfdFyDXmHTtAbVl;
			KwDoxZjwzCgIHfdFyDXmHTtAbVl = ReInput.currentFrame;
			num = -1375093758;
			goto IL_0012;
		}

		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			if (buttons == null)
			{
				goto IL_002b;
			}
			double num = 0.0;
			int num2 = 1932088975;
			goto IL_0030;
			IL_0030:
			double lastTimePressed = default(double);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x73295689)
				{
				case 2:
					break;
				case 0:
					num = lastTimePressed;
					num2 = 1932088970;
					continue;
				case 6:
					num3 = 0;
					num2 = 1932088972;
					continue;
				case 4:
				{
					lastTimePressed = buttons[num3].lastTimePressed;
					int num4;
					if (lastTimePressed <= num)
					{
						num2 = 1932088970;
						num4 = num2;
					}
					else
					{
						num2 = 1932088969;
						num4 = num2;
					}
					continue;
				}
				case 1:
					return 0.0;
				case 3:
					num3++;
					num2 = 1932088972;
					continue;
				default:
					if (num3 >= buttons.Length)
					{
						return num;
					}
					goto case 4;
				}
				break;
			}
			goto IL_002b;
			IL_002b:
			num2 = 1932088968;
			goto IL_0030;
		}

		public double GetLastTimeAnyButtonChanged()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_001c;
			}
			int num;
			double num2 = default(double);
			if (buttons == null)
			{
				num = -988610013;
			}
			else
			{
				num2 = 0.0;
				num = -988610015;
			}
			goto IL_0021;
			IL_001c:
			num = -988610009;
			goto IL_0021;
			IL_0021:
			double lastTimeStateChanged = default(double);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -988610010)
				{
				case 6:
					break;
				case 0:
					num2 = lastTimeStateChanged;
					num = -988610002;
					continue;
				case 7:
					num3 = 0;
					num = -988610011;
					continue;
				case 4:
				{
					lastTimeStateChanged = buttons[num3].lastTimeStateChanged;
					int num4;
					if (lastTimeStateChanged > num2)
					{
						num = -988610010;
						num4 = num;
					}
					else
					{
						num = -988610002;
						num4 = num;
					}
					continue;
				}
				case 1:
					return 0.0;
				case 8:
					num3++;
					num = -988610012;
					continue;
				case 3:
					num = -988610012;
					continue;
				case 5:
					return 0.0;
				default:
					if (num3 >= buttons.Length)
					{
						return num2;
					}
					goto case 4;
				}
				break;
			}
			goto IL_001c;
		}

		public T GetExtension<T>() where T : class
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				T result = default(T);
				while (true)
				{
					int num = 2010383500;
					while (true)
					{
						switch (num ^ 0x77D4048D)
						{
						case 0:
							break;
						case 1:
							goto IL_0037;
						default:
							return result;
						}
						break;
						IL_0037:
						result = null;
						num = 2010383503;
					}
				}
			}
			return XRrbuPDOAbJMnDUNcTrqkgwkvwmk as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			int num = 0;
			while (num < cizCCZbGlFPBIOIAeQyVhpdKKxk.Length)
			{
				while (true)
				{
					if (cizCCZbGlFPBIOIAeQyVhpdKKxk[num].typeGuid == typeGuid)
					{
						return cizCCZbGlFPBIOIAeQyVhpdKKxk[num];
					}
					num++;
					int num2 = 975051540;
					while (true)
					{
						switch (num2 ^ 0x3A1E1B15)
						{
						case 0:
							num2 = 975051543;
							continue;
						case 2:
							break;
						default:
							goto end_IL_003d;
						}
						break;
					}
					continue;
					end_IL_003d:
					break;
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num = 0;
			int num2 = 1718737736;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num2 ^ 0x6671DB48)
				{
				case 3:
					break;
				case 1:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				case 2:
					if (!ReflectionTools.DoesTypeImplement(cizCCZbGlFPBIOIAeQyVhpdKKxk[num].GetType(), type))
					{
						goto IL_0064;
					}
					return cizCCZbGlFPBIOIAeQyVhpdKKxk[num];
				default:
					if (num >= cizCCZbGlFPBIOIAeQyVhpdKKxk.Length)
					{
						return null;
					}
					goto case 2;
				}
				break;
				IL_0064:
				num++;
				num2 = 1718737736;
			}
			goto IL_000d;
			IL_000d:
			num2 = 1718737737;
			goto IL_0012;
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num = 0;
			int num2 = -1176703181;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num2 ^ -1176703183)
				{
				case 0:
					break;
				case 5:
					if (cizCCZbGlFPBIOIAeQyVhpdKKxk[num] as T != null)
					{
						return cizCCZbGlFPBIOIAeQyVhpdKKxk[num] as T;
					}
					num++;
					num2 = -1176703181;
					continue;
				case 3:
					return null;
				case 2:
				{
					int num3;
					if (num >= cizCCZbGlFPBIOIAeQyVhpdKKxk.Length)
					{
						num2 = -1176703179;
						num3 = num2;
					}
					else
					{
						num2 = -1176703180;
						num3 = num2;
					}
					continue;
				}
				case 1:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					num2 = -1176703182;
					continue;
				default:
					return null;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num2 = -1176703184;
			goto IL_0012;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = -412514766;
				while (true)
				{
					switch (num2 ^ -412514767)
					{
					case 0:
						break;
					case 3:
						num2 = -412514765;
						continue;
					case 1:
						if (cizCCZbGlFPBIOIAeQyVhpdKKxk[num].typeGuid == typeGuid)
						{
							return true;
						}
						num++;
						num2 = -412514765;
						continue;
					default:
						if (num >= cizCCZbGlFPBIOIAeQyVhpdKKxk.Length)
						{
							return false;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			goto IL_0055;
			IL_0012:
			int num;
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x23B7165E)
				{
				case 3:
					break;
				case 0:
					goto IL_0033;
				case 1:
					goto IL_0055;
				case 2:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				default:
					if (num2 >= cizCCZbGlFPBIOIAeQyVhpdKKxk.Length)
					{
						return false;
					}
					goto IL_0033;
				}
				break;
				IL_0033:
				if (ReflectionTools.DoesTypeImplement(cizCCZbGlFPBIOIAeQyVhpdKKxk[num2].GetType(), type))
				{
					return true;
				}
				num2++;
				num = 599201370;
			}
			goto IL_000d;
			IL_0055:
			num2 = 0;
			num = 599201370;
			goto IL_0012;
			IL_000d:
			num = 599201372;
			goto IL_0012;
		}

		public bool ImplementsTemplate<T>() where T : class
		{
			return ImplementsTemplate(typeof(T));
		}

		internal void vPBcgbtXlRkxBJGxiPgEznsEEhOi(IControllerTemplate[] P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				cizCCZbGlFPBIOIAeQyVhpdKKxk = P_0;
				sjtuOUEDjjFUIqOhxfXNdeSazWX = new ReadOnlyCollection<IControllerTemplate>(cizCCZbGlFPBIOIAeQyVhpdKKxk);
				int num = 342422997;
				while (true)
				{
					switch (num ^ 0x1468F5D5)
					{
					case 2:
						goto IL_0004;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0004:
					num = 342422996;
				}
			}
		}

		internal virtual void kckuoUXEwQcigNbCseRHnXueOkT(UpdateLoopType P_0)
		{
			bool flag = ReInput.IsInputAllowed(_type);
			int num = _buttonCount;
			int num3 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num2 = 1910316509;
				while (true)
				{
					switch (num2 ^ 0x71DD1DD0)
					{
					case 0:
						break;
					default:
						return;
					case 10:
						buttons[num3].KyHpjvRkJIBKWzDbtHSSnZwunyW(P_0, num3, cMcAtEwaThLpgGZfIIRmVCJQjDU);
						num2 = 1910316505;
						continue;
					case 4:
						if (buttons[num5].qdHubhcOPbXxuJQJAkbLHARwcNr <= 0)
						{
							buttons[num5].LihbIPbGsllGSRjvQiDhYHgWKHE(P_0);
							num2 = 1910316501;
							continue;
						}
						goto case 5;
					case 12:
					{
						int num6;
						if (num5 < num)
						{
							num2 = 1910316500;
							num6 = num2;
						}
						else
						{
							num2 = 1910316499;
							num6 = num2;
						}
						continue;
					}
					case 2:
						num2 = 1910316508;
						continue;
					case 9:
						num3++;
						num2 = 1910316502;
						continue;
					case 11:
						num3 = 0;
						num2 = 1910316502;
						continue;
					case 1:
						num5 = 0;
						num2 = 1910316498;
						continue;
					case 13:
					{
						int num7;
						if (flag)
						{
							num2 = 1910316507;
							num7 = num2;
						}
						else
						{
							num2 = 1910316497;
							num7 = num2;
						}
						continue;
					}
					case 3:
						if (XRrbuPDOAbJMnDUNcTrqkgwkvwmk != null)
						{
							XRrbuPDOAbJMnDUNcTrqkgwkvwmk.UpdateData(P_0);
							num2 = 1910316503;
							continue;
						}
						return;
					case 5:
						num5++;
						num2 = 1910316508;
						continue;
					case 8:
					{
						int num4;
						if (buttons[num3].qdHubhcOPbXxuJQJAkbLHARwcNr > 0)
						{
							num2 = 1910316505;
							num4 = num2;
						}
						else
						{
							num2 = 1910316506;
							num4 = num2;
						}
						continue;
					}
					case 6:
						if (num3 >= num)
						{
							num2 = 1910316499;
							continue;
						}
						goto case 8;
					case 7:
						return;
					}
					break;
				}
			}
		}

		internal virtual ButtonStateFlags uyCIJpubqYGZlTJykNbCjeQFpYW(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO;
			}
			return buttons[P_0].state;
		}

		internal void crQnLutgKZoSSMlUmZAkqAvIErv(Extension P_0)
		{
			if (P_0 == null)
			{
				XRrbuPDOAbJMnDUNcTrqkgwkvwmk = null;
				return;
			}
			while (XRrbuPDOAbJMnDUNcTrqkgwkvwmk == null)
			{
				while (true)
				{
					IL_0044:
					P_0.SetController(this);
					int num = -376843076;
					while (true)
					{
						switch (num ^ -376843076)
						{
						case 3:
							num = -376843075;
							continue;
						case 1:
							break;
						case 2:
							goto IL_0044;
						default:
							XRrbuPDOAbJMnDUNcTrqkgwkvwmk = P_0.Clone();
							return;
						}
						break;
					}
					break;
				}
			}
			cATIZLBUFegHKkJeQETToGESSlfq(P_0);
		}

		internal void cATIZLBUFegHKkJeQETToGESSlfq(Extension P_0)
		{
			if (XRrbuPDOAbJMnDUNcTrqkgwkvwmk != null)
			{
				XRrbuPDOAbJMnDUNcTrqkgwkvwmk.SetSource(P_0);
				XRrbuPDOAbJMnDUNcTrqkgwkvwmk.SetController(this);
				if (P_0 == null)
				{
					return;
				}
				goto IL_0023;
			}
			goto IL_005f;
			IL_005f:
			crQnLutgKZoSSMlUmZAkqAvIErv(P_0);
			int num = 2081368049;
			goto IL_0028;
			IL_0023:
			num = 2081368052;
			goto IL_0028;
			IL_0028:
			while (true)
			{
				switch (num ^ 0x7C0F27F0)
				{
				case 3:
					break;
				default:
					return;
				case 4:
					P_0.SetController(this);
					num = 2081368048;
					continue;
				case 0:
					return;
				case 2:
					goto IL_005f;
				case 1:
					return;
				}
				break;
			}
			goto IL_0023;
		}

		internal virtual void tAgADqjTsMUxSqYXeDyJIdETYRAp()
		{
			int num = 0;
			while (true)
			{
				int num2 = -120819583;
				while (true)
				{
					switch (num2 ^ -120819581)
					{
					case 3:
						break;
					default:
						return;
					case 2:
						num2 = -120819581;
						continue;
					case 0:
						if (num >= _buttonCount)
						{
							int num3;
							if (cMcAtEwaThLpgGZfIIRmVCJQjDU == null)
							{
								num2 = -120819582;
								num3 = num2;
							}
							else
							{
								num2 = -120819580;
								num3 = num2;
							}
							continue;
						}
						goto case 6;
					case 4:
						num++;
						num2 = -120819581;
						continue;
					case 6:
						if (buttons[num] != null)
						{
							buttons[num].Reset();
							num2 = -120819577;
							continue;
						}
						goto case 4;
					case 7:
						cMcAtEwaThLpgGZfIIRmVCJQjDU.ClearData();
						num2 = -120819582;
						continue;
					case 1:
						if (XRrbuPDOAbJMnDUNcTrqkgwkvwmk != null)
						{
							XRrbuPDOAbJMnDUNcTrqkgwkvwmk.Clear();
							num2 = -120819578;
							continue;
						}
						return;
					case 5:
						return;
					}
					break;
				}
			}
		}

		internal virtual bool wytyBiLPSMGfQbbdKPNlzybFrlR(bool P_0)
		{
			if (FnzJwrQpikWfZbmfjZhFwutJGAA == P_0)
			{
				goto IL_0009;
			}
			int num;
			if (!P_0)
			{
				tAgADqjTsMUxSqYXeDyJIdETYRAp();
				num = -1290100920;
				goto IL_000e;
			}
			goto IL_003d;
			IL_003d:
			FnzJwrQpikWfZbmfjZhFwutJGAA = P_0;
			if (ViElVhCmKJNZGzfohfDCJGshGWjB != null)
			{
				ViElVhCmKJNZGzfohfDCJGshGWjB(P_0);
				num = -1290100917;
				goto IL_000e;
			}
			goto IL_005f;
			IL_005f:
			return true;
			IL_0009:
			num = -1290100918;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1290100919)
			{
			case 0:
				break;
			case 3:
				return false;
			case 1:
				goto IL_003d;
			default:
				goto IL_005f;
			}
			goto IL_0009;
		}

		internal virtual void UdqTiJdOOubbIffCkHAnQYFKEiz(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			IList<ActionElementMap> buttonMaps = default(IList<ActionElementMap>);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				P_0.controllerId = id;
				P_0.controllerType = _type;
				int num = -2109665286;
				while (true)
				{
					switch (num ^ -2109665296)
					{
					case 4:
						num = -2109665295;
						continue;
					case 0:
						P_0.DeleteElementMap(buttonMaps[num2].tqPurZpByiUWRrPJKwHxxaZZua);
						num = -2109665290;
						continue;
					case 5:
					{
						int num5;
						if (buttonMaps[num2].elementIndex < 0)
						{
							num = -2109665296;
							num5 = num;
						}
						else
						{
							num = -2109665290;
							num5 = num;
						}
						continue;
					}
					case 9:
					{
						int num4;
						if (num3 >= buttonMaps.Count)
						{
							num = -2109665293;
							num4 = num;
						}
						else
						{
							num = -2109665288;
							num4 = num;
						}
						continue;
					}
					case 8:
						kHBFOpXfsCHmoMIFXGRFYWyjgTV(P_0, buttonMaps[num3]);
						num3++;
						num = -2109665287;
						continue;
					case 7:
						num = -2109665287;
						continue;
					case 1:
						break;
					case 10:
						buttonMaps = P_0.ButtonMaps;
						num3 = 0;
						num = -2109665289;
						continue;
					case 3:
						num2 = buttonMaps.Count - 1;
						num = -2109665294;
						continue;
					case 6:
						num2--;
						num = -2109665294;
						continue;
					default:
						if (num2 < 0)
						{
							return;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		internal virtual void kHBFOpXfsCHmoMIFXGRFYWyjgTV(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 == null)
			{
				return;
			}
			while (P_1._elementType == ControllerElementType.Button)
			{
				while (true)
				{
					IL_0037:
					P_1.ENoWuIxoJpbiEHGViijOxvkWIbli(P_0);
					int num = -1753023200;
					while (true)
					{
						switch (num ^ -1753023199)
						{
						case 0:
							num = -1753023197;
							continue;
						default:
							return;
						case 2:
							break;
						case 3:
							goto IL_0037;
						case 1:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		internal bool tXzIgaRwJvkQBalWJWvWELjQiLSC(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int ouusLSVThShOJXeTBDNomJoAhtU = P_0.ouusLSVThShOJXeTBDNomJoAhtU;
			if (ouusLSVThShOJXeTBDNomJoAhtU < 0)
			{
				goto IL_00dd;
			}
			if (ouusLSVThShOJXeTBDNomJoAhtU >= _buttonCount)
			{
				goto IL_0030;
			}
			P_3 = buttons[ouusLSVThShOJXeTBDNomJoAhtU].GsEpYNAtCtHHElSNDJZpBwxHfua;
			float num = default(float);
			int num2;
			if (P_3)
			{
				num = buttons[ouusLSVThShOJXeTBDNomJoAhtU].pressure;
				num2 = 1374696559;
				goto IL_0035;
			}
			goto IL_0148;
			IL_0127:
			float num3 = 0f;
			goto IL_0133;
			IL_0148:
			if (buttons[ouusLSVThShOJXeTBDNomJoAhtU].value)
			{
				num3 = 1f;
				goto IL_0133;
			}
			num2 = 1374696558;
			goto IL_0035;
			IL_00dd:
			return false;
			IL_0133:
			num = num3;
			num2 = 1374696552;
			goto IL_0035;
			IL_0030:
			num2 = 1374696547;
			goto IL_0035;
			IL_0035:
			while (true)
			{
				switch (num2 ^ 0x51F0346B)
				{
				case 9:
					break;
				case 2:
					if (P_0._elementType == ControllerElementType.Axis)
					{
						goto IL_0078;
					}
					goto default;
				case 0:
					if (P_0._invert)
					{
						num *= -1f;
						num2 = 1374696557;
						continue;
					}
					goto default;
				case 3:
					if (num > 0f)
					{
						if (P_0._elementType != ControllerElementType.Button)
						{
							goto case 2;
						}
						if (P_0._axisContribution == Pole.Negative)
						{
							num *= -1f;
							num2 = 1374696557;
							continue;
						}
					}
					goto default;
				case 8:
					goto IL_00dd;
				case 1:
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
						num2 = 1374696557;
						continue;
					}
					goto default;
				case 5:
					goto IL_0127;
				case 4:
					num2 = 1374696552;
					continue;
				case 7:
					goto IL_0148;
				default:
					P_2 = num;
					return true;
				}
				break;
				IL_0078:
				int num4;
				if (P_0._axisRange == AxisRange.Full)
				{
					num2 = 1374696555;
					num4 = num2;
				}
				else
				{
					num2 = 1374696554;
					num4 = num2;
				}
			}
			goto IL_0030;
		}

		internal bool tXzIgaRwJvkQBalWJWvWELjQiLSC(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
		{
			P_3 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			float num = (P_2 ? 1f : 0f);
			while (true)
			{
				int num2 = 1224046987;
				while (true)
				{
					switch (num2 ^ 0x48F5798F)
					{
					case 0:
						break;
					case 4:
						if (num > 0f)
						{
							if (P_0._elementType != ControllerElementType.Button)
							{
								goto case 2;
							}
							if (P_0._axisContribution == Pole.Negative)
							{
								num *= -1f;
								num2 = 1224046985;
								continue;
							}
						}
						goto case 6;
					case 1:
					{
						int num3;
						if (P_0._axisContribution != Pole.Negative)
						{
							num2 = 1224046985;
							num3 = num2;
						}
						else
						{
							num2 = 1224046986;
							num3 = num2;
						}
						continue;
					}
					case 2:
						if (P_0._elementType == ControllerElementType.Axis)
						{
							if (P_0._axisRange != AxisRange.Full)
							{
								goto case 1;
							}
							if (P_0._invert)
							{
								num *= -1f;
								num2 = 1224046988;
								continue;
							}
						}
						goto case 6;
					case 6:
						P_3 = num;
						num2 = 1224046984;
						continue;
					case 5:
						num *= -1f;
						num2 = 1224046985;
						continue;
					case 3:
						num2 = 1224046985;
						continue;
					default:
						return true;
					}
					break;
				}
			}
		}

		internal void itKYLEidIwjerGGrDGqPNskdaYz(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(OZXcSZtVrQPQPLpKldDeETdguIN, P_0);
			}
		}

		internal virtual Guid MZhqnjiRGfsOqvNdqpnpwhpYkRV()
		{
			return Guid.Empty;
		}

		protected virtual void Connected()
		{
			_isConnected = true;
		}

		protected virtual void Disconnected()
		{
			_isConnected = false;
			while (true)
			{
				int num = 660612764;
				while (true)
				{
					switch (num ^ 0x2760269F)
					{
					case 2:
						break;
					default:
						return;
					case 3:
					{
						int num2;
						if (cMcAtEwaThLpgGZfIIRmVCJQjDU == null)
						{
							num = 660612766;
							num2 = num;
						}
						else
						{
							num = 660612767;
							num2 = num;
						}
						continue;
					}
					case 0:
						cMcAtEwaThLpgGZfIIRmVCJQjDU.ClearData();
						num = 660612766;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static bool zMUKjgfoOfCLsOpalQCxeeyfPRW(Controller P_0, Guid P_1)
		{
			return P_0.ImplementsTemplate(P_1);
		}

		[CompilerGenerated]
		private static bool VpavZWTLQFIbfNeBuwRtDOifhzyf(Controller P_0, Type P_1)
		{
			return P_0.ImplementsTemplate(P_1);
		}
	}
}
