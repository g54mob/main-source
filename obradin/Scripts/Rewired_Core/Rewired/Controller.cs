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
			internal abstract class yOeRxsEVwDQrznDqivHTAGFIhIKi
			{
				public abstract class GzQFDjITTZzuJjzlwnZURJKfaTxW
				{
					public abstract void Reset();
				}

				protected readonly int WpAeooJslwObDnzcpAZAXnTbzXMk;

				protected readonly int[] CHoRXFaiXpGXafiYeDBMIipZWCo;

				protected GzQFDjITTZzuJjzlwnZURJKfaTxW[] gRSZlsGnOMePzdfqhIobycvdjXwm;

				public GzQFDjITTZzuJjzlwnZURJKfaTxW xbRrcEKKIAKiQkVzQCekOswVHrJ;

				private int RMmuzLwPyyqjZzFkavzjXDLDVyZ;

				public int ZMZbecCGBpEGMhMVXcfFEAvXLKW = -1;

				protected ReadOnlyCollection<GzQFDjITTZzuJjzlwnZURJKfaTxW> OQRxKYktpyefzhhnCyUgIPGjMMn;

				public IList<GzQFDjITTZzuJjzlwnZURJKfaTxW> Data
				{
					get
					{
						return OQRxKYktpyefzhhnCyUgIPGjMMn;
					}
				}

				public UpdateLoopType updateLoop
				{
					set
					{
						if (ZMZbecCGBpEGMhMVXcfFEAvXLKW != (int)value)
						{
							ZMZbecCGBpEGMhMVXcfFEAvXLKW = (int)value;
							RMmuzLwPyyqjZzFkavzjXDLDVyZ = CHoRXFaiXpGXafiYeDBMIipZWCo[(int)value];
							xbRrcEKKIAKiQkVzQCekOswVHrJ = gRSZlsGnOMePzdfqhIobycvdjXwm[RMmuzLwPyyqjZzFkavzjXDLDVyZ];
						}
					}
				}

				public yOeRxsEVwDQrznDqivHTAGFIhIKi(UpdateLoopSetting updateLoopSetting)
				{
					CHoRXFaiXpGXafiYeDBMIipZWCo = new int[3];
					WpAeooJslwObDnzcpAZAXnTbzXMk = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
						for (int i = 0; i < list.Count; i++)
						{
							CHoRXFaiXpGXafiYeDBMIipZWCo[(int)list[i]] = WpAeooJslwObDnzcpAZAXnTbzXMk;
							WpAeooJslwObDnzcpAZAXnTbzXMk++;
						}
					}
					gRSZlsGnOMePzdfqhIobycvdjXwm = new GzQFDjITTZzuJjzlwnZURJKfaTxW[WpAeooJslwObDnzcpAZAXnTbzXMk];
					OQRxKYktpyefzhhnCyUgIPGjMMn = new ReadOnlyCollection<GzQFDjITTZzuJjzlwnZURJKfaTxW>(gRSZlsGnOMePzdfqhIobycvdjXwm);
				}

				public void EEGiMNPSMElaPgKQdmScoWLedfb()
				{
					int num = 0;
					while (num < WpAeooJslwObDnzcpAZAXnTbzXMk)
					{
						while (true)
						{
							gRSZlsGnOMePzdfqhIobycvdjXwm[num].Reset();
							num++;
							int num2 = 1849696612;
							while (true)
							{
								switch (num2 ^ 0x6E402164)
								{
								case 2:
									num2 = 1849696613;
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

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal yOeRxsEVwDQrznDqivHTAGFIhIKi RZMvlrDreIsgIkkLWnqvppfvSXS;

			internal int axHEQbAmdnNnSAAeBbHMhcbvfuTu;

			internal Controller HUdfNKdOgxfoxjMZAKUlkQYPszXh;

			internal readonly int znFtIaPrJLvdjPGCwXFaaAeLKcr;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = HUdfNKdOgxfoxjMZAKUlkQYPszXh.GetElementIdentifierById(id);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			public bool isMemberElement
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					return axHEQbAmdnNnSAAeBbHMhcbvfuTu > 0;
				}
			}

			internal Element(Controller controller, int elementIdentifierId, string name, ControllerElementType type)
			{
				HUdfNKdOgxfoxjMZAKUlkQYPszXh = controller;
				id = elementIdentifierId;
				this.name = name;
				this.type = type;
				znFtIaPrJLvdjPGCwXFaaAeLKcr = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (RZMvlrDreIsgIkkLWnqvppfvSXS == null)
					{
						num = -1957223460;
						num2 = num;
					}
					else
					{
						num = -1957223458;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1957223459)
						{
						case 0:
							num = -1957223457;
							continue;
						default:
							return;
						case 2:
							break;
						case 3:
							RZMvlrDreIsgIkkLWnqvppfvSXS.EEGiMNPSMElaPgKQdmScoWLedfb();
							num = -1957223460;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}

			internal void RgsMWPoTvBToOeodGAJsakxJpBT()
			{
				if (axHEQbAmdnNnSAAeBbHMhcbvfuTu > 0)
				{
					while (true)
					{
						int num = 237996147;
						while (true)
						{
							switch (num ^ 0xE2F8871)
							{
							case 0:
								break;
							case 2:
								Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
								num = 237996144;
								continue;
							default:
								goto end_IL_0009;
							}
							break;
						}
						continue;
						end_IL_0009:
						break;
					}
				}
				axHEQbAmdnNnSAAeBbHMhcbvfuTu++;
			}

			internal void uXIrpYwgClkRJhyyXlWpVSebfhC()
			{
				if (axHEQbAmdnNnSAAeBbHMhcbvfuTu == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					goto IL_0012;
				}
				goto IL_0038;
				IL_0038:
				axHEQbAmdnNnSAAeBbHMhcbvfuTu--;
				int num = -1140830874;
				goto IL_0017;
				IL_0012:
				num = -1140830877;
				goto IL_0017;
				IL_0017:
				while (true)
				{
					switch (num ^ -1140830873)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						goto IL_0038;
					case 2:
						return;
					case 4:
						axHEQbAmdnNnSAAeBbHMhcbvfuTu = 0;
						num = -1140830875;
						continue;
					case 1:
						return;
					}
					break;
				}
				goto IL_0012;
			}
		}

		public sealed class Axis : Element
		{
			internal class jImLqlIVbHlDfdiDAmjwHUvcTqt : yOeRxsEVwDQrznDqivHTAGFIhIKi
			{
				public class ZczptBVwSKbyiWpvXbYeBmDzhcD : GzQFDjITTZzuJjzlwnZURJKfaTxW
				{
					private const float ENQcjkcdpBEPUGaGETgvvlLrgox = 0.001f;

					public float JHgsNLxiAQVnmyfVeWejfTJocIu;

					public float NckTuqeNamazETPgRISbxBNlOkT;

					public float DSUWIZhLGdAGFywJbXfvRFVTiKZ;

					public float cJLvXtACONCPFglEwCWxbHqdeE;

					public float sorsfJzEsCsMfauCVygigBCKqOQ;

					public float FbCBMtFFQVcRgNXOHRusLFeBSEDi;

					public float aPoeXomShorTvZjdXQtRuGVVtPw;

					public float KoQZReOknbBHwfCaBXDlGZmaFWQa;

					public float DJiDfjiFQgxNhsvLZYAQfdDkDrm;

					public float LRpVSpNPLWRGcutWqjzZZwcuVOj;

					public float eNlfaOWiskAoBeDZqhqqUAabphnq;

					public float gbdAwShoXxIelgOSWgWwtrwBExL;

					public float timeActive
					{
						get
						{
							if (JHgsNLxiAQVnmyfVeWejfTJocIu == 0f)
							{
								return 0f;
							}
							return ReInput.unscaledTime - DJiDfjiFQgxNhsvLZYAQfdDkDrm;
						}
					}

					public float timeActiveRaw
					{
						get
						{
							if (DSUWIZhLGdAGFywJbXfvRFVTiKZ == 0f)
							{
								return 0f;
							}
							return ReInput.unscaledTime - LRpVSpNPLWRGcutWqjzZZwcuVOj;
						}
					}

					public float timeInactive
					{
						get
						{
							if (JHgsNLxiAQVnmyfVeWejfTJocIu != 0f)
							{
								return 0f;
							}
							return ReInput.unscaledTime - aPoeXomShorTvZjdXQtRuGVVtPw;
						}
					}

					public float timeInactiveRaw
					{
						get
						{
							if (DSUWIZhLGdAGFywJbXfvRFVTiKZ != 0f)
							{
								return 0f;
							}
							return ReInput.unscaledTime - KoQZReOknbBHwfCaBXDlGZmaFWQa;
						}
					}

					public void UZSQFwoMfSAzsmmSKmseCCiJWWD(bool P_0)
					{
						float unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							goto IL_000c;
						}
						goto IL_00be;
						IL_000c:
						int num = 333301179;
						goto IL_0011;
						IL_0011:
						while (true)
						{
							switch (num ^ 0x13DDC5BA)
							{
							case 13:
								break;
							default:
								return;
							case 7:
								num = 333301174;
								continue;
							case 2:
								if (!MathTools.IsNear(JHgsNLxiAQVnmyfVeWejfTJocIu, NckTuqeNamazETPgRISbxBNlOkT, 0.001f))
								{
									eNlfaOWiskAoBeDZqhqqUAabphnq = unscaledTime;
									num = 333301174;
									continue;
								}
								goto case 12;
							case 12:
								if (!MathTools.Approximately(DSUWIZhLGdAGFywJbXfvRFVTiKZ, 0f))
								{
									KoQZReOknbBHwfCaBXDlGZmaFWQa = unscaledTime;
									num = 333301168;
									continue;
								}
								goto case 9;
							case 8:
								goto IL_00ad;
							case 3:
								goto IL_00be;
							case 10:
								num = 333301180;
								continue;
							case 14:
								if (!MathTools.IsNear(sorsfJzEsCsMfauCVygigBCKqOQ, FbCBMtFFQVcRgNXOHRusLFeBSEDi, 0.001f))
								{
									eNlfaOWiskAoBeDZqhqqUAabphnq = unscaledTime;
									num = 333301181;
									continue;
								}
								goto case 12;
							case 9:
								LRpVSpNPLWRGcutWqjzZZwcuVOj = unscaledTime;
								num = 333301180;
								continue;
							case 5:
								num = 333301176;
								continue;
							case 1:
								goto IL_012f;
							case 0:
								DJiDfjiFQgxNhsvLZYAQfdDkDrm = unscaledTime;
								num = 333301172;
								continue;
							case 6:
								if (!MathTools.IsNear(DSUWIZhLGdAGFywJbXfvRFVTiKZ, cJLvXtACONCPFglEwCWxbHqdeE, 0.001f))
								{
									gbdAwShoXxIelgOSWgWwtrwBExL = unscaledTime;
									num = 333301169;
									continue;
								}
								return;
							case 4:
								aPoeXomShorTvZjdXQtRuGVVtPw = unscaledTime;
								num = 333301172;
								continue;
							case 11:
								return;
							}
							break;
							IL_012f:
							int num2;
							if (MathTools.Approximately(sorsfJzEsCsMfauCVygigBCKqOQ, 0f))
							{
								num = 333301178;
								num2 = num;
							}
							else
							{
								num = 333301182;
								num2 = num;
							}
						}
						goto IL_000c;
						IL_00be:
						if (!MathTools.Approximately(JHgsNLxiAQVnmyfVeWejfTJocIu, 0f))
						{
							aPoeXomShorTvZjdXQtRuGVVtPw = unscaledTime;
							num = 333301183;
							goto IL_0011;
						}
						goto IL_00ad;
						IL_00ad:
						DJiDfjiFQgxNhsvLZYAQfdDkDrm = unscaledTime;
						num = 333301176;
						goto IL_0011;
					}

					public void iDuFvOcgOBRwUXteGwXQgTGoKUL(float P_0)
					{
						if (cJLvXtACONCPFglEwCWxbHqdeE != DSUWIZhLGdAGFywJbXfvRFVTiKZ)
						{
							cJLvXtACONCPFglEwCWxbHqdeE = DSUWIZhLGdAGFywJbXfvRFVTiKZ;
							goto IL_001a;
						}
						goto IL_0038;
						IL_0038:
						int num;
						if (DSUWIZhLGdAGFywJbXfvRFVTiKZ != P_0)
						{
							DSUWIZhLGdAGFywJbXfvRFVTiKZ = P_0;
							num = 1855430146;
							goto IL_001f;
						}
						return;
						IL_001a:
						num = 1855430147;
						goto IL_001f;
						IL_001f:
						switch (num ^ 0x6E979E02)
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

					public override void Reset()
					{
						JHgsNLxiAQVnmyfVeWejfTJocIu = 0f;
						while (true)
						{
							int num = -904242711;
							while (true)
							{
								switch (num ^ -904242710)
								{
								case 4:
									break;
								case 5:
									DJiDfjiFQgxNhsvLZYAQfdDkDrm = 0f;
									num = -904242712;
									continue;
								case 0:
									DSUWIZhLGdAGFywJbXfvRFVTiKZ = 0f;
									cJLvXtACONCPFglEwCWxbHqdeE = 0f;
									num = -904242709;
									continue;
								case 3:
									NckTuqeNamazETPgRISbxBNlOkT = 0f;
									num = -904242710;
									continue;
								case 1:
									aPoeXomShorTvZjdXQtRuGVVtPw = 0f;
									KoQZReOknbBHwfCaBXDlGZmaFWQa = 0f;
									num = -904242705;
									continue;
								default:
									LRpVSpNPLWRGcutWqjzZZwcuVOj = 0f;
									eNlfaOWiskAoBeDZqhqqUAabphnq = 0f;
									gbdAwShoXxIelgOSWgWwtrwBExL = 0f;
									return;
								}
								break;
							}
						}
					}
				}

				public jImLqlIVbHlDfdiDAmjwHUvcTqt(UpdateLoopSetting updateCycle)
					: base(updateCycle)
				{
					for (int i = 0; i < WpAeooJslwObDnzcpAZAXnTbzXMk; i++)
					{
						gRSZlsGnOMePzdfqhIobycvdjXwm[i] = new ZczptBVwSKbyiWpvXbYeBmDzhcD();
					}
					xbRrcEKKIAKiQkVzQCekOswVHrJ = gRSZlsGnOMePzdfqhIobycvdjXwm[0];
				}
			}

			internal readonly AxisRange GsnVEUNrADoUdYdWxqJZnmbrmhn;

			internal readonly HardwareAxisInfo flIXmRKXOUURLlZiHjZlJLbgGru;

			public float value
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).sorsfJzEsCsMfauCVygigBCKqOQ;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).JHgsNLxiAQVnmyfVeWejfTJocIu;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).FbCBMtFFQVcRgNXOHRusLFeBSEDi;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).NckTuqeNamazETPgRISbxBNlOkT;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						while (true)
						{
							int num = 1545847732;
							while (true)
							{
								switch (num ^ 0x5C23C3B5)
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
								ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num = 1545847733;
							}
						}
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).DSUWIZhLGdAGFywJbXfvRFVTiKZ;
				}
				internal set
				{
					((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).iDuFvOcgOBRwUXteGwXQgTGoKUL(value);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).cJLvXtACONCPFglEwCWxbHqdeE;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).DSUWIZhLGdAGFywJbXfvRFVTiKZ - ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).cJLvXtACONCPFglEwCWxbHqdeE;
				}
			}

			public float lastTimeActive
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).aPoeXomShorTvZjdXQtRuGVVtPw;
				}
			}

			public float lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						while (true)
						{
							int num = -1053797190;
							while (true)
							{
								switch (num ^ -1053797189)
								{
								case 0:
									break;
								case 1:
									goto IL_002b;
								default:
									return 0f;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num = -1053797191;
							}
						}
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).KoQZReOknbBHwfCaBXDlGZmaFWQa;
				}
			}

			public float lastTimeInactive
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).DJiDfjiFQgxNhsvLZYAQfdDkDrm;
				}
			}

			public float lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).LRpVSpNPLWRGcutWqjzZZwcuVOj;
				}
			}

			public float lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).eNlfaOWiskAoBeDZqhqqUAabphnq;
				}
			}

			public float lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).gbdAwShoXxIelgOSWgWwtrwBExL;
				}
			}

			public float timeActive
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).timeActive;
				}
			}

			public float timeActiveRaw
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).timeActive;
				}
			}

			public float timeInactive
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).timeInactive;
				}
			}

			public float timeInactiveRaw
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).timeInactiveRaw;
				}
			}

			internal float selfValue
			{
				get
				{
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).JHgsNLxiAQVnmyfVeWejfTJocIu;
				}
			}

			internal float selfValuePrev
			{
				get
				{
					return ((jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).NckTuqeNamazETPgRISbxBNlOkT;
				}
			}

			internal void SRMdBdXlvvGwaVElVdmvHLQdODs(float P_0)
			{
				jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD zczptBVwSKbyiWpvXbYeBmDzhcD = (jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ;
				while (true)
				{
					int num = 1755632454;
					while (true)
					{
						switch (num ^ 0x68A4D347)
						{
						case 2:
							break;
						case 1:
							goto IL_002f;
						default:
							zczptBVwSKbyiWpvXbYeBmDzhcD.sorsfJzEsCsMfauCVygigBCKqOQ = P_0;
							return;
						}
						break;
						IL_002f:
						zczptBVwSKbyiWpvXbYeBmDzhcD.FbCBMtFFQVcRgNXOHRusLFeBSEDi = zczptBVwSKbyiWpvXbYeBmDzhcD.sorsfJzEsCsMfauCVygigBCKqOQ;
						num = 1755632455;
					}
				}
			}

			internal Axis(Controller controller, int elementIdentifierId, string name, AxisRange axisRange, HardwareAxisInfo axisInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Axis)
			{
				while (true)
				{
					int num = -404131349;
					while (true)
					{
						switch (num ^ -404131350)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0028;
						case 2:
							return;
						}
						break;
						IL_0028:
						RZMvlrDreIsgIkkLWnqvppfvSXS = new jImLqlIVbHlDfdiDAmjwHUvcTqt(ReInput.configVars.updateLoop);
						GsnVEUNrADoUdYdWxqJZnmbrmhn = axisRange;
						flIXmRKXOUURLlZiHjZlJLbgGru = axisInfo;
						num = -404131352;
					}
				}
			}

			internal void hFZfconneSNSSDboIpZxIrDbEKL(UpdateLoopType P_0)
			{
				if (RZMvlrDreIsgIkkLWnqvppfvSXS == null || RZMvlrDreIsgIkkLWnqvppfvSXS.ZMZbecCGBpEGMhMVXcfFEAvXLKW == (int)P_0)
				{
					return;
				}
				while (true)
				{
					int num = -2131631352;
					while (true)
					{
						switch (num ^ -2131631351)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0034;
						case 0:
							return;
						}
						break;
						IL_0034:
						RZMvlrDreIsgIkkLWnqvppfvSXS.updateLoop = P_0;
						num = -2131631351;
					}
				}
			}

			internal void KZaWnSfEanREcjXdiSEBKrZinBA(AxisCalibration P_0)
			{
				jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD zczptBVwSKbyiWpvXbYeBmDzhcD = (jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ;
				zczptBVwSKbyiWpvXbYeBmDzhcD.NckTuqeNamazETPgRISbxBNlOkT = zczptBVwSKbyiWpvXbYeBmDzhcD.JHgsNLxiAQVnmyfVeWejfTJocIu;
				float jHgsNLxiAQVnmyfVeWejfTJocIu = default(float);
				while (true)
				{
					int num = 703391392;
					while (true)
					{
						switch (num ^ 0x29ECE6A1)
						{
						case 3:
							break;
						case 1:
						{
							jHgsNLxiAQVnmyfVeWejfTJocIu = P_0.GetCalibratedValue(zczptBVwSKbyiWpvXbYeBmDzhcD.DSUWIZhLGdAGFywJbXfvRFVTiKZ, GsnVEUNrADoUdYdWxqJZnmbrmhn);
							int num2;
							if (!P_0.applyRangeCalibration)
							{
								num = 703391393;
								num2 = num;
							}
							else
							{
								num = 703391395;
								num2 = num;
							}
							continue;
						}
						case 2:
							jHgsNLxiAQVnmyfVeWejfTJocIu = MathTools.Clamp(jHgsNLxiAQVnmyfVeWejfTJocIu, -1f, 1f);
							num = 703391393;
							continue;
						default:
							zczptBVwSKbyiWpvXbYeBmDzhcD.JHgsNLxiAQVnmyfVeWejfTJocIu = jHgsNLxiAQVnmyfVeWejfTJocIu;
							return;
						}
						break;
					}
				}
			}

			internal void KZaWnSfEanREcjXdiSEBKrZinBA()
			{
				jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD zczptBVwSKbyiWpvXbYeBmDzhcD = (jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ;
				zczptBVwSKbyiWpvXbYeBmDzhcD.NckTuqeNamazETPgRISbxBNlOkT = zczptBVwSKbyiWpvXbYeBmDzhcD.JHgsNLxiAQVnmyfVeWejfTJocIu;
				zczptBVwSKbyiWpvXbYeBmDzhcD.JHgsNLxiAQVnmyfVeWejfTJocIu = zczptBVwSKbyiWpvXbYeBmDzhcD.DSUWIZhLGdAGFywJbXfvRFVTiKZ;
			}

			internal void xqneffBvtliTsIbgjcfZhJdKvLbg()
			{
				jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD zczptBVwSKbyiWpvXbYeBmDzhcD = (jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ;
				zczptBVwSKbyiWpvXbYeBmDzhcD.NckTuqeNamazETPgRISbxBNlOkT = zczptBVwSKbyiWpvXbYeBmDzhcD.JHgsNLxiAQVnmyfVeWejfTJocIu;
				zczptBVwSKbyiWpvXbYeBmDzhcD.JHgsNLxiAQVnmyfVeWejfTJocIu = 0f;
			}

			internal void fcTFDEZsXDBrgfytqUGSCWrjjSq()
			{
				jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD zczptBVwSKbyiWpvXbYeBmDzhcD = (jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ;
				zczptBVwSKbyiWpvXbYeBmDzhcD.UZSQFwoMfSAzsmmSKmseCCiJWWD(base.isMemberElement);
			}

			internal void FEnVGRMpSMquPIgzVlYURiCsvwe(float P_0)
			{
				int num = 0;
				jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD zczptBVwSKbyiWpvXbYeBmDzhcD = default(jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD);
				while (true)
				{
					int num2;
					int num3;
					if (num < RZMvlrDreIsgIkkLWnqvppfvSXS.Data.Count)
					{
						num2 = 120844994;
						num3 = num2;
					}
					else
					{
						num2 = 120844999;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x733F2C3)
						{
						case 3:
							num2 = 120844994;
							continue;
						default:
							return;
						case 1:
							zczptBVwSKbyiWpvXbYeBmDzhcD = RZMvlrDreIsgIkkLWnqvppfvSXS.Data[num] as jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD;
							if (zczptBVwSKbyiWpvXbYeBmDzhcD != null)
							{
								zczptBVwSKbyiWpvXbYeBmDzhcD.iDuFvOcgOBRwUXteGwXQgTGoKUL(P_0);
								zczptBVwSKbyiWpvXbYeBmDzhcD.NckTuqeNamazETPgRISbxBNlOkT = zczptBVwSKbyiWpvXbYeBmDzhcD.JHgsNLxiAQVnmyfVeWejfTJocIu;
								num2 = 120844993;
								continue;
							}
							goto case 5;
						case 0:
							break;
						case 2:
							zczptBVwSKbyiWpvXbYeBmDzhcD.JHgsNLxiAQVnmyfVeWejfTJocIu = 0f;
							zczptBVwSKbyiWpvXbYeBmDzhcD.UZSQFwoMfSAzsmmSKmseCCiJWWD(base.isMemberElement);
							num2 = 120844998;
							continue;
						case 5:
							num++;
							num2 = 120844995;
							continue;
						case 4:
							return;
						}
						break;
					}
				}
			}

			internal float EiHIbOkFnjiOtBqrPpxWNhaRfUYA(UpdateLoopType P_0, AxisCalibration P_1)
			{
				jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD zczptBVwSKbyiWpvXbYeBmDzhcD = (jImLqlIVbHlDfdiDAmjwHUvcTqt.ZczptBVwSKbyiWpvXbYeBmDzhcD)RZMvlrDreIsgIkkLWnqvppfvSXS.Data[(int)P_0];
				float result = P_1.GetCalibratedValue(zczptBVwSKbyiWpvXbYeBmDzhcD.DSUWIZhLGdAGFywJbXfvRFVTiKZ, GsnVEUNrADoUdYdWxqJZnmbrmhn, P_1.deadZone, false, true);
				if (P_1.applyRangeCalibration)
				{
					while (true)
					{
						int num = 1529385893;
						while (true)
						{
							switch (num ^ 0x5B2893A4)
							{
							case 0:
								break;
							case 1:
								result = MathTools.Clamp(result, -1f, 1f);
								num = 1529385894;
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
			internal class yjhRtkIzVXSQVfVwvLIPjqbChn : yOeRxsEVwDQrznDqivHTAGFIhIKi
			{
				public class RrGVlGygLARrWGUtVGJMxebrZHM : GzQFDjITTZzuJjzlwnZURJKfaTxW
				{
					public bool JHgsNLxiAQVnmyfVeWejfTJocIu;

					public bool NckTuqeNamazETPgRISbxBNlOkT;

					public ButtonStateRecorder RckdEjtDroWEnGIzFfcLMuRYwMw;

					public tjVSzgCpYulTxiHPuJpvoyKcuuZ WZaxCprIxlokEfqunzmAuhgUFym;

					public RrGVlGygLARrWGUtVGJMxebrZHM()
					{
						while (true)
						{
							int num = 92476157;
							while (true)
							{
								switch (num ^ 0x58312FF)
								{
								case 0:
									break;
								case 2:
									goto IL_0024;
								default:
									WZaxCprIxlokEfqunzmAuhgUFym = new tjVSzgCpYulTxiHPuJpvoyKcuuZ(0.3f);
									return;
								}
								break;
								IL_0024:
								RckdEjtDroWEnGIzFfcLMuRYwMw = new ButtonStateRecorder();
								num = 92476158;
							}
						}
					}

					public void MPPQJfVkqEnvckKDMacDSmlvhjwB(bool P_0)
					{
						if (NckTuqeNamazETPgRISbxBNlOkT != JHgsNLxiAQVnmyfVeWejfTJocIu)
						{
							NckTuqeNamazETPgRISbxBNlOkT = JHgsNLxiAQVnmyfVeWejfTJocIu;
							goto IL_001a;
						}
						goto IL_0044;
						IL_0044:
						int num;
						int num2;
						if (JHgsNLxiAQVnmyfVeWejfTJocIu != P_0)
						{
							num = 2024744357;
							num2 = num;
						}
						else
						{
							num = 2024744359;
							num2 = num;
						}
						goto IL_001f;
						IL_001a:
						num = 2024744358;
						goto IL_001f;
						IL_001f:
						while (true)
						{
							switch (num ^ 0x78AF25A4)
							{
							case 5:
								break;
							default:
								return;
							case 2:
								goto IL_0044;
							case 0:
								WZaxCprIxlokEfqunzmAuhgUFym.UZSQFwoMfSAzsmmSKmseCCiJWWD(0.3f, P_0 && !NckTuqeNamazETPgRISbxBNlOkT, P_0);
								num = 2024744352;
								continue;
							case 3:
								RckdEjtDroWEnGIzFfcLMuRYwMw.UZSQFwoMfSAzsmmSKmseCCiJWWD(P_0 && !NckTuqeNamazETPgRISbxBNlOkT, P_0, ReInput.unscaledTime);
								num = 2024744356;
								continue;
							case 1:
								JHgsNLxiAQVnmyfVeWejfTJocIu = P_0;
								num = 2024744359;
								continue;
							case 4:
								return;
							}
							break;
						}
						goto IL_001a;
					}

					public override void Reset()
					{
						JHgsNLxiAQVnmyfVeWejfTJocIu = false;
						NckTuqeNamazETPgRISbxBNlOkT = false;
						RckdEjtDroWEnGIzFfcLMuRYwMw.EEGiMNPSMElaPgKQdmScoWLedfb();
						WZaxCprIxlokEfqunzmAuhgUFym.EEGiMNPSMElaPgKQdmScoWLedfb();
					}
				}

				public class ADQauUEAuNSWJKGRcZVfdnHdgeKJ : RrGVlGygLARrWGUtVGJMxebrZHM
				{
					public float kBUagekNtysluoUQKtUuHIlTPLF;

					public float LXHwmFBzbUAeMBVkPkSEWXhQJuz;

					public void MPPQJfVkqEnvckKDMacDSmlvhjwB(float P_0)
					{
						if (LXHwmFBzbUAeMBVkPkSEWXhQJuz != kBUagekNtysluoUQKtUuHIlTPLF)
						{
							LXHwmFBzbUAeMBVkPkSEWXhQJuz = kBUagekNtysluoUQKtUuHIlTPLF;
							goto IL_001a;
						}
						goto IL_0038;
						IL_005e:
						MPPQJfVkqEnvckKDMacDSmlvhjwB((kBUagekNtysluoUQKtUuHIlTPLF > 0f) ? true : false);
						return;
						IL_001a:
						int num = 53089916;
						goto IL_001f;
						IL_001f:
						switch (num ^ 0x32A167D)
						{
						case 2:
							break;
						case 1:
							goto IL_0038;
						default:
							goto IL_005e;
						}
						goto IL_001a;
						IL_0038:
						if (kBUagekNtysluoUQKtUuHIlTPLF != P_0)
						{
							kBUagekNtysluoUQKtUuHIlTPLF = ((P_0 > 0.001f) ? P_0 : 0f);
							num = 53089917;
							goto IL_001f;
						}
						goto IL_005e;
					}

					public override void Reset()
					{
						base.Reset();
						kBUagekNtysluoUQKtUuHIlTPLF = 0f;
						LXHwmFBzbUAeMBVkPkSEWXhQJuz = 0f;
					}
				}

				public yjhRtkIzVXSQVfVwvLIPjqbChn(UpdateLoopSetting updateCycle, bool isPressureSensitive)
					: base(updateCycle)
				{
					for (int i = 0; i < WpAeooJslwObDnzcpAZAXnTbzXMk; i++)
					{
						if (isPressureSensitive)
						{
							gRSZlsGnOMePzdfqhIobycvdjXwm[i] = new ADQauUEAuNSWJKGRcZVfdnHdgeKJ();
						}
						else
						{
							gRSZlsGnOMePzdfqhIobycvdjXwm[i] = new RrGVlGygLARrWGUtVGJMxebrZHM();
						}
					}
					xbRrcEKKIAKiQkVzQCekOswVHrJ = gRSZlsGnOMePzdfqhIobycvdjXwm[0];
				}

				public void wfMQBnVSJDbXRnDqtCTavKKkoPg(float P_0)
				{
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num < gRSZlsGnOMePzdfqhIobycvdjXwm.Length)
						{
							num2 = -1007150971;
							num3 = num2;
						}
						else
						{
							num2 = -1007150970;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -1007150972)
							{
							case 0:
								num2 = -1007150971;
								continue;
							default:
								return;
							case 1:
								((RrGVlGygLARrWGUtVGJMxebrZHM)gRSZlsGnOMePzdfqhIobycvdjXwm[num]).WZaxCprIxlokEfqunzmAuhgUFym.nlCsUivRHoIHYnJkJSKjelDGEISh(P_0);
								num++;
								num2 = -1007150969;
								continue;
							case 3:
								break;
							case 2:
								return;
							}
							break;
						}
					}
				}

				public void YhJOXHhUzugiDwuIizRukHasgHn()
				{
					int num = 0;
					while (num < gRSZlsGnOMePzdfqhIobycvdjXwm.Length)
					{
						while (true)
						{
							((RrGVlGygLARrWGUtVGJMxebrZHM)gRSZlsGnOMePzdfqhIobycvdjXwm[num]).WZaxCprIxlokEfqunzmAuhgUFym.nlCsUivRHoIHYnJkJSKjelDGEISh(0.3f);
							int num2 = 2029089678;
							while (true)
							{
								switch (num2 ^ 0x78F1738E)
								{
								case 3:
									num2 = 2029089679;
									continue;
								case 1:
									break;
								case 0:
									num++;
									num2 = 2029089676;
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
			}

			internal readonly bool EOEuEHUjrfDrsgyreIyiycBWacU;

			internal readonly HardwareButtonInfo HeWnhSDeUwBpzVKMyfPgtPmfjjx;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).NckTuqeNamazETPgRISbxBNlOkT;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).JHgsNLxiAQVnmyfVeWejfTJocIu;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					if (!EOEuEHUjrfDrsgyreIyiycBWacU)
					{
						if (!((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).JHgsNLxiAQVnmyfVeWejfTJocIu)
						{
							return 0f;
						}
						return 1f;
					}
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.ADQauUEAuNSWJKGRcZVfdnHdgeKJ)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).kBUagekNtysluoUQKtUuHIlTPLF;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					if (!EOEuEHUjrfDrsgyreIyiycBWacU)
					{
						if (!((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).NckTuqeNamazETPgRISbxBNlOkT)
						{
							return 0f;
						}
						return 1f;
					}
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.ADQauUEAuNSWJKGRcZVfdnHdgeKJ)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).LXHwmFBzbUAeMBVkPkSEWXhQJuz;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						while (true)
						{
							int num = 1175826792;
							while (true)
							{
								switch (num ^ 0x4615B169)
								{
								case 2:
									break;
								case 1:
									goto IL_002b;
								default:
									return false;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num = 1175826793;
							}
						}
					}
					return EOEuEHUjrfDrsgyreIyiycBWacU;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					if (!((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).NckTuqeNamazETPgRISbxBNlOkT && ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).JHgsNLxiAQVnmyfVeWejfTJocIu)
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
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					if (((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).NckTuqeNamazETPgRISbxBNlOkT && !((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).JHgsNLxiAQVnmyfVeWejfTJocIu)
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
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					if (((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).NckTuqeNamazETPgRISbxBNlOkT != ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).JHgsNLxiAQVnmyfVeWejfTJocIu)
					{
						return true;
					}
					return false;
				}
			}

			public bool doublePressedAndHeld
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).WZaxCprIxlokEfqunzmAuhgUFym.doublePressHold;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).WZaxCprIxlokEfqunzmAuhgUFym.doublePressHold;
				}
			}

			public float timePressed
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).RckdEjtDroWEnGIzFfcLMuRYwMw.timePressed;
				}
			}

			public float timeUnpressed
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).RckdEjtDroWEnGIzFfcLMuRYwMw.timeUnpressed;
				}
			}

			public float lastTimePressed
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).RckdEjtDroWEnGIzFfcLMuRYwMw.lastTimePressed;
				}
			}

			public float lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).RckdEjtDroWEnGIzFfcLMuRYwMw.lastTimeUnpressed;
				}
			}

			public float lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).RckdEjtDroWEnGIzFfcLMuRYwMw.lastTimeStateChanged;
				}
			}

			internal ButtonStateFlags state
			{
				get
				{
					yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM rrGVlGygLARrWGUtVGJMxebrZHM = (yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE;
					if (!rrGVlGygLARrWGUtVGJMxebrZHM.JHgsNLxiAQVnmyfVeWejfTJocIu)
					{
						goto IL_0056;
					}
					buttonStateFlags |= ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf;
					if (!rrGVlGygLARrWGUtVGJMxebrZHM.NckTuqeNamazETPgRISbxBNlOkT)
					{
						buttonStateFlags |= ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH;
						goto IL_002d;
					}
					goto IL_0069;
					IL_0069:
					return buttonStateFlags;
					IL_0056:
					int num;
					if (rrGVlGygLARrWGUtVGJMxebrZHM.NckTuqeNamazETPgRISbxBNlOkT)
					{
						buttonStateFlags |= ButtonStateFlags.wqjwiZOyPZUdbNDdvBGdKmBHhRs;
						num = -697915628;
						goto IL_0032;
					}
					goto IL_0069;
					IL_002d:
					num = -697915625;
					goto IL_0032;
					IL_0032:
					while (true)
					{
						switch (num ^ -697915627)
						{
						case 0:
							break;
						case 2:
							num = -697915628;
							continue;
						case 3:
							goto IL_0056;
						default:
							goto IL_0069;
						}
						break;
					}
					goto IL_002d;
				}
			}

			internal Button(Controller controller, int elementIdentifierId, string name, HardwareButtonInfo buttonInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Button)
			{
				HeWnhSDeUwBpzVKMyfPgtPmfjjx = buttonInfo;
				RZMvlrDreIsgIkkLWnqvppfvSXS = new yjhRtkIzVXSQVfVwvLIPjqbChn(ReInput.configVars.updateLoop, false);
			}

			internal Button(Controller controller, int elementIdentifierId, string name, bool isPressureSensitive, HardwareButtonInfo buttonInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Button)
			{
				HeWnhSDeUwBpzVKMyfPgtPmfjjx = buttonInfo;
				EOEuEHUjrfDrsgyreIyiycBWacU = isPressureSensitive;
				RZMvlrDreIsgIkkLWnqvppfvSXS = new yjhRtkIzVXSQVfVwvLIPjqbChn(ReInput.configVars.updateLoop, isPressureSensitive);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				}
				if (speed <= 0f)
				{
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).WZaxCprIxlokEfqunzmAuhgUFym.doublePressHold;
				}
				return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).RckdEjtDroWEnGIzFfcLMuRYwMw.IqTQGnJMxdgjdCDmjEaKjTBjuvfn(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).WZaxCprIxlokEfqunzmAuhgUFym.doublePressHold;
				}
				return ((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).RckdEjtDroWEnGIzFfcLMuRYwMw.IqTQGnJMxdgjdCDmjEaKjTBjuvfn(speed);
			}

			internal void MPPQJfVkqEnvckKDMacDSmlvhjwB(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (RZMvlrDreIsgIkkLWnqvppfvSXS != null && RZMvlrDreIsgIkkLWnqvppfvSXS.ZMZbecCGBpEGMhMVXcfFEAvXLKW != (int)P_0)
				{
					RZMvlrDreIsgIkkLWnqvppfvSXS.updateLoop = P_0;
					goto IL_0022;
				}
				goto IL_0044;
				IL_0027:
				int num;
				switch (num ^ -192514381)
				{
				case 0:
					break;
				case 3:
					goto IL_0044;
				case 2:
					((yjhRtkIzVXSQVfVwvLIPjqbChn.ADQauUEAuNSWJKGRcZVfdnHdgeKJ)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).MPPQJfVkqEnvckKDMacDSmlvhjwB(P_2.buttonPressureValues[P_1]);
					return;
				default:
					((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).MPPQJfVkqEnvckKDMacDSmlvhjwB(P_2.buttonValues[P_1]);
					return;
				}
				goto IL_0022;
				IL_0044:
				int num2;
				if (!EOEuEHUjrfDrsgyreIyiycBWacU)
				{
					num = -192514382;
					num2 = num;
				}
				else
				{
					num = -192514383;
					num2 = num;
				}
				goto IL_0027;
				IL_0022:
				num = -192514384;
				goto IL_0027;
			}

			internal void TyrDDJAfnnLNoDKHAjBmQpKiHMBc(UpdateLoopType P_0)
			{
				if (RZMvlrDreIsgIkkLWnqvppfvSXS != null)
				{
					while (true)
					{
						int num = 1934206896;
						while (true)
						{
							switch (num ^ 0x7349A7B1)
							{
							case 3:
								break;
							case 1:
								if (RZMvlrDreIsgIkkLWnqvppfvSXS.ZMZbecCGBpEGMhMVXcfFEAvXLKW != (int)P_0)
								{
									RZMvlrDreIsgIkkLWnqvppfvSXS.updateLoop = P_0;
									num = 1934206897;
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
				if (EOEuEHUjrfDrsgyreIyiycBWacU)
				{
					((yjhRtkIzVXSQVfVwvLIPjqbChn.ADQauUEAuNSWJKGRcZVfdnHdgeKJ)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).MPPQJfVkqEnvckKDMacDSmlvhjwB(0f);
					return;
				}
				goto IL_0075;
				IL_0075:
				((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)RZMvlrDreIsgIkkLWnqvppfvSXS.xbRrcEKKIAKiQkVzQCekOswVHrJ).MPPQJfVkqEnvckKDMacDSmlvhjwB(false);
			}

			internal void FEnVGRMpSMquPIgzVlYURiCsvwe()
			{
				int num = 0;
				while (num < RZMvlrDreIsgIkkLWnqvppfvSXS.Data.Count)
				{
					while (true)
					{
						yOeRxsEVwDQrznDqivHTAGFIhIKi.GzQFDjITTZzuJjzlwnZURJKfaTxW gzQFDjITTZzuJjzlwnZURJKfaTxW = RZMvlrDreIsgIkkLWnqvppfvSXS.Data[num];
						int num2 = 1640990963;
						while (true)
						{
							switch (num2 ^ 0x61CF88F3)
							{
							case 2:
								num2 = 1640990965;
								continue;
							case 6:
								break;
							case 4:
								((yjhRtkIzVXSQVfVwvLIPjqbChn.RrGVlGygLARrWGUtVGJMxebrZHM)gzQFDjITTZzuJjzlwnZURJKfaTxW).MPPQJfVkqEnvckKDMacDSmlvhjwB(false);
								num2 = 1640990960;
								continue;
							case 1:
								if (EOEuEHUjrfDrsgyreIyiycBWacU)
								{
									((yjhRtkIzVXSQVfVwvLIPjqbChn.ADQauUEAuNSWJKGRcZVfdnHdgeKJ)gzQFDjITTZzuJjzlwnZURJKfaTxW).MPPQJfVkqEnvckKDMacDSmlvhjwB(0f);
									num2 = 1640990964;
									continue;
								}
								goto case 4;
							case 0:
								goto IL_0084;
							case 3:
								num++;
								num2 = 1640990966;
								continue;
							case 7:
								num2 = 1640990960;
								continue;
							default:
								goto end_IL_0039;
							}
							break;
							IL_0084:
							int num3;
							if (gzQFDjITTZzuJjzlwnZURJKfaTxW != null)
							{
								num2 = 1640990962;
								num3 = num2;
							}
							else
							{
								num2 = 1640990960;
								num3 = num2;
							}
						}
						continue;
						end_IL_0039:
						break;
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class hYKOpwfgGmkXWecqWzTZUllYVvP
			{
				public readonly Element nsrJcOgpcFdFnRaSgBMVkSZUgdlg;

				public readonly int GFxMtMQcTztHIzUiZNyflMJzBUL;

				public hYKOpwfgGmkXWecqWzTZUllYVvP(Element element, int elementIndex)
				{
					nsrJcOgpcFdFnRaSgBMVkSZUgdlg = element;
					GFxMtMQcTztHIzUiZNyflMJzBUL = elementIndex;
				}
			}

			private int wyOUtAQIXRMHfdYotPsXMPVUbwu;

			private string EqppaAHmTQvmVSSZadzlNpPBbHM;

			private CompoundControllerElementType iaFziOmGetWMviBsUmpNhLnTJKt;

			private int MyNJRXLJmKCNcpkEAMoRJKKLEAYf;

			private hYKOpwfgGmkXWecqWzTZUllYVvP[] PvbfvGDQstrrExqmLGQWIcGWljDB;

			private Controller HUdfNKdOgxfoxjMZAKUlkQYPszXh;

			internal readonly int znFtIaPrJLvdjPGCwXFaaAeLKcr;

			public int id
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return -1;
					}
					return wyOUtAQIXRMHfdYotPsXMPVUbwu;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return string.Empty;
					}
					return EqppaAHmTQvmVSSZadzlNpPBbHM;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return CompoundControllerElementType.Axis2D;
					}
					return iaFziOmGetWMviBsUmpNhLnTJKt;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					return MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0;
					}
					return MyNJRXLJmKCNcpkEAMoRJKKLEAYf;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = HUdfNKdOgxfoxjMZAKUlkQYPszXh.GetElementIdentifierById(wyOUtAQIXRMHfdYotPsXMPVUbwu);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			internal CompoundElement(Controller controller, int elementIdentifierId, string name, CompoundControllerElementType type)
			{
				HUdfNKdOgxfoxjMZAKUlkQYPszXh = controller;
				wyOUtAQIXRMHfdYotPsXMPVUbwu = elementIdentifierId;
				EqppaAHmTQvmVSSZadzlNpPBbHM = name;
				iaFziOmGetWMviBsUmpNhLnTJKt = type;
				PvbfvGDQstrrExqmLGQWIcGWljDB = new hYKOpwfgGmkXWecqWzTZUllYVvP[elementCapacity];
				znFtIaPrJLvdjPGCwXFaaAeLKcr = ReInput.id;
			}

			internal Element KQaqMptOrhHmGWOCKcwibHIHaLV(int P_0)
			{
				if (P_0 < 0 || P_0 >= PvbfvGDQstrrExqmLGQWIcGWljDB.Length)
				{
					return null;
				}
				if (PvbfvGDQstrrExqmLGQWIcGWljDB[P_0] == null)
				{
					return null;
				}
				return PvbfvGDQstrrExqmLGQWIcGWljDB[P_0].nsrJcOgpcFdFnRaSgBMVkSZUgdlg;
			}

			internal T KQaqMptOrhHmGWOCKcwibHIHaLV<T>(int P_0) where T : Element
			{
				if (P_0 >= 0)
				{
					if (P_0 < PvbfvGDQstrrExqmLGQWIcGWljDB.Length)
					{
						if (PvbfvGDQstrrExqmLGQWIcGWljDB[P_0] == null)
						{
							return null;
						}
						return PvbfvGDQstrrExqmLGQWIcGWljDB[P_0].nsrJcOgpcFdFnRaSgBMVkSZUgdlg as T;
					}
					goto IL_000f;
				}
				goto IL_002d;
				IL_0014:
				int num;
				T result = default(T);
				switch (num ^ -451453424)
				{
				case 0:
					break;
				case 1:
					goto IL_002d;
				default:
					return result;
				}
				goto IL_000f;
				IL_000f:
				num = -451453423;
				goto IL_0014;
				IL_002d:
				result = null;
				num = -451453422;
				goto IL_0014;
			}

			internal T YpssoAuWXtTjMJWSPmeVOHKAbIS<T>(int P_0, out int P_1) where T : Element
			{
				P_1 = -1;
				if (P_0 < 0 || P_0 >= PvbfvGDQstrrExqmLGQWIcGWljDB.Length)
				{
					return null;
				}
				if (PvbfvGDQstrrExqmLGQWIcGWljDB[P_0] == null)
				{
					return null;
				}
				P_1 = PvbfvGDQstrrExqmLGQWIcGWljDB[P_0].GFxMtMQcTztHIzUiZNyflMJzBUL;
				return PvbfvGDQstrrExqmLGQWIcGWljDB[P_0].nsrJcOgpcFdFnRaSgBMVkSZUgdlg as T;
			}

			internal bool uiIyqEcLjeCLLGNLkqHYomAmAGZF(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					goto IL_0003;
				}
				if (MyNJRXLJmKCNcpkEAMoRJKKLEAYf >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (PPScODKITNkJhuhwQPXehuNrLBk(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = zKyiZnmWaZByvHQigwwWtDsrVTu();
				int num2;
				if (num < 0)
				{
					num2 = -915834645;
					goto IL_0008;
				}
				return RFtOjArFZkPeFKLQKcDShGpkeyC(P_0, P_1, num);
				IL_0003:
				num2 = -915834646;
				goto IL_0008;
				IL_0008:
				switch (num2 ^ -915834645)
				{
				case 2:
					break;
				case 1:
					return false;
				default:
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				goto IL_0003;
			}

			internal bool IkGsWuHbWvapUbXvZWSBoNqejYsF(Element P_0)
			{
				if (P_0 == null)
				{
					goto IL_0003;
				}
				int num;
				if (MyNJRXLJmKCNcpkEAMoRJKKLEAYf == 0)
				{
					num = -1872121627;
				}
				else
				{
					int num2 = PPScODKITNkJhuhwQPXehuNrLBk(P_0);
					if (num2 >= 0)
					{
						return gzPPHFGEzMKFyrBIyYNwjjBLvQm(num2);
					}
					num = -1872121625;
				}
				goto IL_0008;
				IL_0008:
				switch (num ^ -1872121625)
				{
				case 3:
					break;
				case 1:
					return false;
				case 2:
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				default:
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				goto IL_0003;
				IL_0003:
				num = -1872121626;
				goto IL_0008;
			}

			internal void OeTCppGUqDQBxHdGHWUrHOUFCEYG()
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= PvbfvGDQstrrExqmLGQWIcGWljDB.Length)
					{
						num2 = 1268626627;
						num3 = num2;
					}
					else
					{
						num2 = 1268626625;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x4B9DB4C0)
						{
						case 2:
							num2 = 1268626625;
							continue;
						default:
							return;
						case 1:
							gzPPHFGEzMKFyrBIyYNwjjBLvQm(num);
							num++;
							num2 = 1268626624;
							continue;
						case 0:
							break;
						case 3:
							MyNJRXLJmKCNcpkEAMoRJKKLEAYf = 0;
							num2 = 1268626628;
							continue;
						case 4:
							return;
						}
						break;
					}
				}
			}

			private int PPScODKITNkJhuhwQPXehuNrLBk(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < PvbfvGDQstrrExqmLGQWIcGWljDB.Length)
					{
						num2 = -788516863;
						num3 = num2;
					}
					else
					{
						num2 = -788516864;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -788516862)
						{
						case 0:
							num2 = -788516863;
							continue;
						case 3:
							if (PvbfvGDQstrrExqmLGQWIcGWljDB[num] != null && PvbfvGDQstrrExqmLGQWIcGWljDB[num].nsrJcOgpcFdFnRaSgBMVkSZUgdlg == P_0)
							{
								return num;
							}
							num++;
							num2 = -788516861;
							continue;
						case 1:
							break;
						default:
							return -1;
						}
						break;
					}
				}
			}

			private bool RFtOjArFZkPeFKLQKcDShGpkeyC(Element P_0, int P_1, int P_2)
			{
				if (P_2 < 0 || P_2 >= PvbfvGDQstrrExqmLGQWIcGWljDB.Length)
				{
					return false;
				}
				if (PvbfvGDQstrrExqmLGQWIcGWljDB[P_2] != null)
				{
					return false;
				}
				PvbfvGDQstrrExqmLGQWIcGWljDB[P_2] = new hYKOpwfgGmkXWecqWzTZUllYVvP(P_0, P_1);
				P_0.RgsMWPoTvBToOeodGAJsakxJpBT();
				MyNJRXLJmKCNcpkEAMoRJKKLEAYf++;
				return true;
			}

			private bool gzPPHFGEzMKFyrBIyYNwjjBLvQm(int P_0)
			{
				if (P_0 < 0)
				{
					goto IL_002d;
				}
				if (P_0 >= PvbfvGDQstrrExqmLGQWIcGWljDB.Length)
				{
					goto IL_000f;
				}
				if (PvbfvGDQstrrExqmLGQWIcGWljDB[P_0] == null)
				{
					return false;
				}
				int num;
				if (PvbfvGDQstrrExqmLGQWIcGWljDB[P_0].nsrJcOgpcFdFnRaSgBMVkSZUgdlg != null)
				{
					PvbfvGDQstrrExqmLGQWIcGWljDB[P_0].nsrJcOgpcFdFnRaSgBMVkSZUgdlg.uXIrpYwgClkRJhyyXlWpVSebfhC();
					num = 1764004047;
					goto IL_0014;
				}
				goto IL_0063;
				IL_0014:
				switch (num ^ 0x692490CE)
				{
				case 0:
					break;
				case 2:
					goto IL_002d;
				default:
					goto IL_0063;
				}
				goto IL_000f;
				IL_000f:
				num = 1764004044;
				goto IL_0014;
				IL_002d:
				return false;
				IL_0063:
				PvbfvGDQstrrExqmLGQWIcGWljDB[P_0] = null;
				MyNJRXLJmKCNcpkEAMoRJKKLEAYf--;
				return true;
			}

			private int zKyiZnmWaZByvHQigwwWtDsrVTu()
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= PvbfvGDQstrrExqmLGQWIcGWljDB.Length)
					{
						num2 = -865138510;
						num3 = num2;
					}
					else
					{
						num2 = -865138511;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -865138512)
						{
						case 0:
							num2 = -865138511;
							continue;
						case 1:
							if (PvbfvGDQstrrExqmLGQWIcGWljDB[num] == null)
							{
								return num;
							}
							num++;
							num2 = -865138509;
							continue;
						case 3:
							break;
						default:
							return -1;
						}
						break;
					}
				}
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int AnuAPEGHwjlThBSXexpecstXnIxJ = 2;

			private CalibrationMap pDUFIxrVjvLRhJUpupZLHCRAZAw;

			public override int elementCapacity
			{
				get
				{
					return 2;
				}
			}

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						while (true)
						{
							int num = 1146468625;
							while (true)
							{
								switch (num ^ 0x4455B913)
								{
								case 0:
									break;
								case 2:
									goto IL_002b;
								default:
									return null;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num = 1146468626;
							}
						}
					}
					return KQaqMptOrhHmGWOCKcwibHIHaLV<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return KQaqMptOrhHmGWOCKcwibHIHaLV<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return Vector2.zero;
					}
					return wehVXwIAssIoIGOesrwSJhimQTA();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return Vector2.zero;
					}
					return gSKdiTKsIEehgyIifLUwctXcohh();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller controller, int elementIdentifierId, string name, Axis xAxis, Axis yAxis, int xAxisIndex, int yAxisIndex, CalibrationMap calibratonMap)
				: base(controller, elementIdentifierId, name, CompoundControllerElementType.Axis2D)
			{
				uiIyqEcLjeCLLGNLkqHYomAmAGZF(xAxis, xAxisIndex);
				uiIyqEcLjeCLLGNLkqHYomAmAGZF(yAxis, yAxisIndex);
				pDUFIxrVjvLRhJUpupZLHCRAZAw = calibratonMap;
			}

			internal void dvtavmcwhNkMVmvvKqcPhKMHyKbP()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.SRMdBdXlvvGwaVElVdmvHLQdODs(vector.x);
					goto IL_0021;
				}
				goto IL_003f;
				IL_003f:
				int num;
				if (yAxis != null)
				{
					yAxis.SRMdBdXlvvGwaVElVdmvHLQdODs(vector.y);
					num = 405993773;
					goto IL_0026;
				}
				return;
				IL_0021:
				num = 405993774;
				goto IL_0026;
				IL_0026:
				switch (num ^ 0x1832F92F)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					goto IL_003f;
				case 2:
					return;
				}
				goto IL_0021;
			}

			private Vector2 wehVXwIAssIoIGOesrwSJhimQTA()
			{
				if (pDUFIxrVjvLRhJUpupZLHCRAZAw == null)
				{
					goto IL_0008;
				}
				int xAxisIndex = default(int);
				Axis axis = YpssoAuWXtTjMJWSPmeVOHKAbIS<Axis>(0, out xAxisIndex);
				int yAxisIndex = default(int);
				Axis axis2 = YpssoAuWXtTjMJWSPmeVOHKAbIS<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float num;
				if (axis != null)
				{
					num = axis.valueRaw;
					goto IL_004a;
				}
				int num2 = -1051805533;
				goto IL_000d;
				IL_003d:
				num = 0f;
				goto IL_004a;
				IL_009f:
				float num3;
				float valueRawY = num3;
				float valueRawX = default(float);
				return pDUFIxrVjvLRhJUpupZLHCRAZAw.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
				IL_004a:
				valueRawX = num;
				if (axis2 == null)
				{
					num2 = -1051805534;
					goto IL_000d;
				}
				num3 = axis2.valueRaw;
				goto IL_009f;
				IL_0008:
				num2 = -1051805535;
				goto IL_000d;
				IL_000d:
				Vector2 result = default(Vector2);
				while (true)
				{
					switch (num2 ^ -1051805536)
					{
					case 0:
						break;
					case 1:
						result = default(Vector2);
						num2 = -1051805532;
						continue;
					case 3:
						goto IL_003d;
					case 4:
						return result;
					default:
						goto IL_0092;
					}
					break;
				}
				goto IL_0008;
				IL_0092:
				num3 = 0f;
				goto IL_009f;
			}

			private Vector2 gSKdiTKsIEehgyIifLUwctXcohh()
			{
				if (pDUFIxrVjvLRhJUpupZLHCRAZAw == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = YpssoAuWXtTjMJWSPmeVOHKAbIS<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = YpssoAuWXtTjMJWSPmeVOHKAbIS<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = ((axis != null) ? axis.valueRawPrev : 0f);
				float valueRawY = ((axis2 != null) ? axis2.valueRawPrev : 0f);
				return pDUFIxrVjvLRhJUpupZLHCRAZAw.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int AnuAPEGHwjlThBSXexpecstXnIxJ = 8;

			private const int vVskJthRmqBKAuXrgeQpIMzypRA = 0;

			private const int AYmqAOYhoKakXulFWzKerteGUqf = 1;

			private const int vLdCWtaeXLEAAwQliybjIIuNlzjG = 2;

			private const int INbatWaACfEmGDDKeMTDoOupuCV = 3;

			private const int reLEiMYznOWsfjhwaNgVcOgsnIv = 4;

			private const int zlVSDhidmfdsRDJmZjoIAxMheEp = 5;

			private const int btbxfMygkbJkhBfpSGZOZLELTbRq = 6;

			private const int YzNteTtGAPlbtHncrLPzCPAISax = 7;

			private readonly int jWRCMWQrEgSaEEOkwnKCQeiQjUVe;

			private readonly Button[] lgAkyeKCNYSjxkICDjzKgIcrtWEL;

			private readonly ReadOnlyCollection<Button> WqMuliDVbBodofWEcnJDpNauibo;

			private readonly int[] DDlECKKfaAmhmrNTFAvDdmrAUQU;

			private bool lOufpFCMmWjtVefrHLjOAFxPJGvz;

			public override int elementCapacity
			{
				get
				{
					return 8;
				}
			}

			public bool force4Way
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					return lOufpFCMmWjtVefrHLjOAFxPJGvz;
				}
				set
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						while (true)
						{
							int num = -110514744;
							while (true)
							{
								switch (num ^ -110514743)
								{
								case 2:
									break;
								case 1:
									ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
									num = -110514743;
									continue;
								case 0:
									return;
								default:
									goto end_IL_000d;
								}
								break;
							}
							continue;
							end_IL_000d:
							break;
						}
					}
					lOufpFCMmWjtVefrHLjOAFxPJGvz = value;
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0;
					}
					return jWRCMWQrEgSaEEOkwnKCQeiQjUVe;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return WqMuliDVbBodofWEcnJDpNauibo;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return KQaqMptOrhHmGWOCKcwibHIHaLV<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return KQaqMptOrhHmGWOCKcwibHIHaLV<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						while (true)
						{
							int num = -1776890160;
							while (true)
							{
								switch (num ^ -1776890159)
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
								ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num = -1776890159;
							}
						}
					}
					return KQaqMptOrhHmGWOCKcwibHIHaLV<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return KQaqMptOrhHmGWOCKcwibHIHaLV<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return KQaqMptOrhHmGWOCKcwibHIHaLV<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return KQaqMptOrhHmGWOCKcwibHIHaLV<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return KQaqMptOrhHmGWOCKcwibHIHaLV<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return KQaqMptOrhHmGWOCKcwibHIHaLV<Button>(7);
				}
			}

			internal Hat(Controller controller, int elementIdentifierId, string name, Button[] buttons, int[] buttonIndices)
				: base(controller, elementIdentifierId, name, CompoundControllerElementType.Hat)
			{
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = -474705706;
					while (true)
					{
						int num4;
						int num6;
						switch (num ^ -474705707)
						{
						case 7:
							break;
						case 1:
							num2 = 0;
							num = -474705707;
							continue;
						case 4:
							if (buttonIndices == null)
							{
								num = -474705709;
								continue;
							}
							num4 = buttonIndices.Length;
							goto IL_0079;
						case 2:
							uiIyqEcLjeCLLGNLkqHYomAmAGZF(buttons[num2], buttonIndices[num2]);
							num2++;
							num = -474705707;
							continue;
						case 6:
							num4 = 0;
							goto IL_0079;
						case 8:
							throw new ArgumentException("button.Length must be 0, 4, or 8! Length: " + num3);
						case 3:
							num3 = ((buttons != null) ? buttons.Length : 0);
							num = -474705711;
							continue;
						case 5:
						{
							int num5;
							switch (num3)
							{
							case 0:
							case 4:
								break;
							case 8:
								num = -474705708;
								num5 = num;
								continue;
							default:
								num = -474705699;
								num5 = num;
								continue;
							}
							goto case 1;
						}
						default:
							{
								if (num2 >= num3)
								{
									lgAkyeKCNYSjxkICDjzKgIcrtWEL = buttons;
									DDlECKKfaAmhmrNTFAvDdmrAUQU = buttonIndices;
									jWRCMWQrEgSaEEOkwnKCQeiQjUVe = num3;
									WqMuliDVbBodofWEcnJDpNauibo = new ReadOnlyCollection<Button>(buttons);
									return;
								}
								goto case 2;
							}
							IL_0079:
							num6 = num4;
							if (num3 != num6)
							{
								throw new ArgumentException("button.Length must equal buttonIndices.Length!");
							}
							goto case 5;
						}
						break;
					}
				}
			}

			internal void dvtavmcwhNkMVmvvKqcPhKMHyKbP(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (jWRCMWQrEgSaEEOkwnKCQeiQjUVe == 0)
				{
					goto IL_0008;
				}
				goto IL_0050;
				IL_0008:
				int num = -1719558037;
				goto IL_000d;
				IL_000d:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -1719558038)
					{
					case 7:
						break;
					case 6:
						num2++;
						num = -1719558033;
						continue;
					case 2:
						goto IL_0050;
					case 3:
						goto IL_0081;
					case 0:
						IqwHADcrSWkZANagIvQfueChdEF(lgAkyeKCNYSjxkICDjzKgIcrtWEL[4], DDlECKKfaAmhmrNTFAvDdmrAUQU[4], DDlECKKfaAmhmrNTFAvDdmrAUQU[5], DDlECKKfaAmhmrNTFAvDdmrAUQU[3], P_0, P_1);
						IqwHADcrSWkZANagIvQfueChdEF(lgAkyeKCNYSjxkICDjzKgIcrtWEL[6], DDlECKKfaAmhmrNTFAvDdmrAUQU[6], DDlECKKfaAmhmrNTFAvDdmrAUQU[5], DDlECKKfaAmhmrNTFAvDdmrAUQU[7], P_0, P_1);
						num = -1719558034;
						continue;
					case 9:
						if (lgAkyeKCNYSjxkICDjzKgIcrtWEL[num2] != null)
						{
							lgAkyeKCNYSjxkICDjzKgIcrtWEL[num2].MPPQJfVkqEnvckKDMacDSmlvhjwB(P_0, DDlECKKfaAmhmrNTFAvDdmrAUQU[num2], P_1);
							num = -1719558036;
							continue;
						}
						goto case 6;
					case 1:
						return;
					case 8:
						goto IL_016e;
					case 4:
						RdgbRTCoKbHOBpzYqnfNLaGHfyuP(lgAkyeKCNYSjxkICDjzKgIcrtWEL[1], DDlECKKfaAmhmrNTFAvDdmrAUQU[1], P_0, P_1);
						RdgbRTCoKbHOBpzYqnfNLaGHfyuP(lgAkyeKCNYSjxkICDjzKgIcrtWEL[3], DDlECKKfaAmhmrNTFAvDdmrAUQU[3], P_0, P_1);
						RdgbRTCoKbHOBpzYqnfNLaGHfyuP(lgAkyeKCNYSjxkICDjzKgIcrtWEL[5], DDlECKKfaAmhmrNTFAvDdmrAUQU[5], P_0, P_1);
						RdgbRTCoKbHOBpzYqnfNLaGHfyuP(lgAkyeKCNYSjxkICDjzKgIcrtWEL[7], DDlECKKfaAmhmrNTFAvDdmrAUQU[7], P_0, P_1);
						return;
					default:
						if (num2 >= lgAkyeKCNYSjxkICDjzKgIcrtWEL.Length)
						{
							return;
						}
						goto case 9;
					}
					break;
				}
				goto IL_0008;
				IL_016e:
				num2 = 0;
				num = -1719558033;
				goto IL_000d;
				IL_0050:
				if (jWRCMWQrEgSaEEOkwnKCQeiQjUVe == 8)
				{
					if (!lOufpFCMmWjtVefrHLjOAFxPJGvz)
					{
						int num3;
						if (ReInput.configVars.force4WayHats)
						{
							num = -1719558039;
							num3 = num;
						}
						else
						{
							num = -1719558046;
							num3 = num;
						}
						goto IL_000d;
					}
					goto IL_0081;
				}
				goto IL_016e;
				IL_0081:
				IqwHADcrSWkZANagIvQfueChdEF(lgAkyeKCNYSjxkICDjzKgIcrtWEL[0], DDlECKKfaAmhmrNTFAvDdmrAUQU[0], DDlECKKfaAmhmrNTFAvDdmrAUQU[7], DDlECKKfaAmhmrNTFAvDdmrAUQU[1], P_0, P_1);
				IqwHADcrSWkZANagIvQfueChdEF(lgAkyeKCNYSjxkICDjzKgIcrtWEL[2], DDlECKKfaAmhmrNTFAvDdmrAUQU[2], DDlECKKfaAmhmrNTFAvDdmrAUQU[1], DDlECKKfaAmhmrNTFAvDdmrAUQU[3], P_0, P_1);
				num = -1719558038;
				goto IL_000d;
			}

			private void IqwHADcrSWkZANagIvQfueChdEF(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
			{
				if (P_0 == null)
				{
					return;
				}
				while (true)
				{
					int num = 1227708808;
					while (true)
					{
						switch (num ^ 0x492D598B)
						{
						case 5:
							break;
						case 1:
							P_5.buttonPressureValues[P_1] = MathTools.MaxMagnitude(P_5.buttonPressureValues[P_1], MathTools.MaxMagnitude((P_2 >= 0 && P_2 < P_5.buttonCount) ? P_5.buttonPressureValues[P_2] : 0f, (P_3 >= 0 && P_3 < P_5.buttonCount) ? P_5.buttonPressureValues[P_3] : 0f));
							num = 1227708811;
							continue;
						case 6:
							return;
						case 4:
							if (P_3 >= 0 && P_3 < P_5.buttonCount)
							{
								bool[] buttonValues2 = P_5.buttonValues;
								int num4 = P_1;
								buttonValues2[num4] |= P_5.buttonValues[P_3];
								num = 1227708811;
								continue;
							}
							goto default;
						case 2:
							if (P_0.isPressureSensitive)
							{
								goto case 1;
							}
							if (P_2 >= 0)
							{
								int num5;
								if (P_2 >= P_5.buttonCount)
								{
									num = 1227708815;
									num5 = num;
								}
								else
								{
									num = 1227708812;
									num5 = num;
								}
								continue;
							}
							goto case 4;
						case 3:
						{
							if (P_1 < 0)
							{
								return;
							}
							int num3;
							if (P_1 < P_5.buttonCount)
							{
								num = 1227708809;
								num3 = num;
							}
							else
							{
								num = 1227708813;
								num3 = num;
							}
							continue;
						}
						case 7:
						{
							bool[] buttonValues = P_5.buttonValues;
							int num2 = P_1;
							buttonValues[num2] |= P_5.buttonValues[P_2];
							num = 1227708815;
							continue;
						}
						default:
							P_0.MPPQJfVkqEnvckKDMacDSmlvhjwB(P_4, P_1, P_5);
							return;
						}
						break;
					}
				}
			}

			private void RdgbRTCoKbHOBpzYqnfNLaGHfyuP(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
			{
				if (P_0 != null && P_1 >= 0)
				{
					if (P_1 >= P_3.buttonCount)
					{
						goto IL_0011;
					}
					goto IL_0047;
				}
				return;
				IL_0016:
				int num;
				while (true)
				{
					switch (num ^ -119795041)
					{
					case 6:
						break;
					case 1:
						return;
					case 2:
						goto IL_0047;
					case 3:
						P_3.buttonValues[P_1] = false;
						num = -119795046;
						continue;
					case 5:
						num = -119795041;
						continue;
					case 4:
						P_3.buttonPressureValues[P_1] = 0f;
						num = -119795041;
						continue;
					default:
						P_0.MPPQJfVkqEnvckKDMacDSmlvhjwB(P_2, P_1, P_3);
						return;
					}
					break;
				}
				goto IL_0011;
				IL_0047:
				int num2;
				if (!P_0.isPressureSensitive)
				{
					num = -119795044;
					num2 = num;
				}
				else
				{
					num = -119795045;
					num2 = num;
				}
				goto IL_0016;
				IL_0011:
				num = -119795042;
				goto IL_0016;
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller HUdfNKdOgxfoxjMZAKUlkQYPszXh;

			private IControllerExtensionSource PESlCqcuFEdCgwfIyyIoKbUwani;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (HUdfNKdOgxfoxjMZAKUlkQYPszXh == null)
					{
						return false;
					}
					return HUdfNKdOgxfoxjMZAKUlkQYPszXh._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (HUdfNKdOgxfoxjMZAKUlkQYPszXh == null)
					{
						return false;
					}
					return HUdfNKdOgxfoxjMZAKUlkQYPszXh.enabled;
				}
			}

			internal Controller controller
			{
				get
				{
					return HUdfNKdOgxfoxjMZAKUlkQYPszXh;
				}
			}

			internal Extension(IControllerExtensionSource source)
			{
				while (true)
				{
					int num = 2141805757;
					while (true)
					{
						switch (num ^ 0x7FA95CBC)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0024;
						case 2:
							return;
						}
						break;
						IL_0024:
						_reInputId = ReInput.id;
						xxivCgrJRpzIZUrpFPBIsrhTFQR(source);
						num = 2141805758;
					}
				}
			}

			internal Extension(Extension source)
				: this(source.PESlCqcuFEdCgwfIyyIoKbUwani)
			{
				HUdfNKdOgxfoxjMZAKUlkQYPszXh = source.HUdfNKdOgxfoxjMZAKUlkQYPszXh;
			}

			internal T GetController<T>() where T : Controller
			{
				if (HUdfNKdOgxfoxjMZAKUlkQYPszXh == null)
				{
					return null;
				}
				return HUdfNKdOgxfoxjMZAKUlkQYPszXh as T;
			}

			internal void SetController(Controller controller)
			{
				HUdfNKdOgxfoxjMZAKUlkQYPszXh = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return PESlCqcuFEdCgwfIyyIoKbUwani;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					while (true)
					{
						switch (-1417473158 ^ -1417473157)
						{
						case 2:
							continue;
						case 1:
							xxivCgrJRpzIZUrpFPBIsrhTFQR(null);
							return;
						}
						break;
					}
				}
				xxivCgrJRpzIZUrpFPBIsrhTFQR(extension.PESlCqcuFEdCgwfIyyIoKbUwani);
			}

			private void xxivCgrJRpzIZUrpFPBIsrhTFQR(IControllerExtensionSource P_0)
			{
				PESlCqcuFEdCgwfIyyIoKbUwani = P_0;
				SourceUpdated(PESlCqcuFEdCgwfIyyIoKbUwani);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		private sealed class ueHPgUwcwGKxqEediNYeDgURtsn : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public Controller iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int JgkqHoXbaGSqSpATxoAvQPPuCvQ;

			public int YGuraXzUJoGdBibzTEHhYqijNkZ;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				ueHPgUwcwGKxqEediNYeDgURtsn ueHPgUwcwGKxqEediNYeDgURtsn2;
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					ueHPgUwcwGKxqEediNYeDgURtsn2 = this;
				}
				else
				{
					while (true)
					{
						ueHPgUwcwGKxqEediNYeDgURtsn2 = new ueHPgUwcwGKxqEediNYeDgURtsn(0);
						int num = -954276038;
						while (true)
						{
							switch (num ^ -954276040)
							{
							case 0:
								num = -954276039;
								continue;
							case 1:
								break;
							case 2:
								ueHPgUwcwGKxqEediNYeDgURtsn2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = -954276037;
								continue;
							default:
								goto end_IL_0049;
							}
							break;
						}
						continue;
						end_IL_0049:
						break;
					}
				}
				return ueHPgUwcwGKxqEediNYeDgURtsn2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = -670468098;
					while (true)
					{
						switch (num2 ^ -670468099)
						{
						case 9:
							break;
						case 4:
							iKQXbXnVtIaMZEJNeigQJWAHqUx.UpdatePollingFrameTracking();
							num2 = -670468107;
							continue;
						case 11:
							JgkqHoXbaGSqSpATxoAvQPPuCvQ++;
							num2 = -670468104;
							continue;
						case 10:
							num2 = -670468099;
							continue;
						case 2:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
							{
								ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num2 = -670468105;
								continue;
							}
							goto case 4;
						case 1:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.XJFeckwuSgaMGZjXezGEbsRjgYr(JgkqHoXbaGSqSpATxoAvQPPuCvQ, out YGuraXzUJoGdBibzTEHhYqijNkZ))
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = new ControllerPollingInfo(true, -1, iKQXbXnVtIaMZEJNeigQJWAHqUx.id, iKQXbXnVtIaMZEJNeigQJWAHqUx._name, iKQXbXnVtIaMZEJNeigQJWAHqUx._type, ControllerElementType.Button, JgkqHoXbaGSqSpATxoAvQPPuCvQ, Pole.Positive, iKQXbXnVtIaMZEJNeigQJWAHqUx.RCNejcvnZtMAmgendVbiwgNYmdD.GetElementIdentifierName(YGuraXzUJoGdBibzTEHhYqijNkZ), YGuraXzUJoGdBibzTEHhYqijNkZ, KeyCode.None);
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							}
							goto case 11;
						case 7:
							num2 = -670468099;
							continue;
						case 8:
							JgkqHoXbaGSqSpATxoAvQPPuCvQ = 0;
							num2 = -670468101;
							continue;
						case 5:
						{
							int num3;
							if (JgkqHoXbaGSqSpATxoAvQPPuCvQ >= iKQXbXnVtIaMZEJNeigQJWAHqUx._buttonCount)
							{
								num2 = -670468099;
								num3 = num2;
							}
							else
							{
								num2 = -670468100;
								num3 = num2;
							}
							continue;
						}
						case 6:
							num2 = -670468104;
							continue;
						case 3:
							switch (num)
							{
							case 0:
								break;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = -670468106;
								continue;
							default:
								num2 = -670468102;
								continue;
							}
							goto case 2;
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
			public ueHPgUwcwGKxqEediNYeDgURtsn(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class npZmRiumRsvkrMgQVvkOrehZHUj : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public Controller iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int HcbPyIbFMMehbIIUADVhqFxiXIf;

			public int nTQsewwfKhrcsjdLVfgdcpaihuZM;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_0064;
				IL_0012:
				int num = 346682326;
				goto IL_0017;
				IL_0017:
				npZmRiumRsvkrMgQVvkOrehZHUj npZmRiumRsvkrMgQVvkOrehZHUj2 = default(npZmRiumRsvkrMgQVvkOrehZHUj);
				while (true)
				{
					switch (num ^ 0x14A9F3D5)
					{
					case 2:
						break;
					case 5:
						num = 346682321;
						continue;
					case 0:
						npZmRiumRsvkrMgQVvkOrehZHUj2 = this;
						num = 346682320;
						continue;
					case 3:
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							num = 346682325;
							continue;
						}
						goto IL_0064;
					case 1:
						goto IL_0064;
					default:
						return npZmRiumRsvkrMgQVvkOrehZHUj2;
					}
					break;
				}
				goto IL_0012;
				IL_0064:
				npZmRiumRsvkrMgQVvkOrehZHUj2 = new npZmRiumRsvkrMgQVvkOrehZHUj(0);
				npZmRiumRsvkrMgQVvkOrehZHUj2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
				num = 346682321;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 1:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					num = -1686042607;
					goto IL_001f;
				case 0:
					goto IL_00fe;
					IL_001f:
					while (true)
					{
						switch (num ^ -1686042602)
						{
						case 3:
							num = -1686042604;
							continue;
						case 6:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.VkYPMFlzGbqTcwGAGUFPygZuyLN(HcbPyIbFMMehbIIUADVhqFxiXIf, out nTQsewwfKhrcsjdLVfgdcpaihuZM))
							{
								aimBzjfQfPyaeQqysAQJISCBhELB = new ControllerPollingInfo(true, -1, iKQXbXnVtIaMZEJNeigQJWAHqUx.id, iKQXbXnVtIaMZEJNeigQJWAHqUx._name, iKQXbXnVtIaMZEJNeigQJWAHqUx._type, ControllerElementType.Button, HcbPyIbFMMehbIIUADVhqFxiXIf, Pole.Positive, iKQXbXnVtIaMZEJNeigQJWAHqUx.RCNejcvnZtMAmgendVbiwgNYmdD.GetElementIdentifierName(nTQsewwfKhrcsjdLVfgdcpaihuZM), nTQsewwfKhrcsjdLVfgdcpaihuZM, KeyCode.None);
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
								return true;
							}
							goto case 7;
						case 5:
							HcbPyIbFMMehbIIUADVhqFxiXIf = 0;
							num = -1686042601;
							continue;
						case 4:
							break;
						case 2:
							goto IL_00fe;
						case 1:
							goto IL_0132;
						case 7:
							HcbPyIbFMMehbIIUADVhqFxiXIf++;
							num = -1686042601;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0132:
						int num2;
						if (HcbPyIbFMMehbIIUADVhqFxiXIf >= iKQXbXnVtIaMZEJNeigQJWAHqUx._buttonCount)
						{
							num = -1686042602;
							num2 = num;
						}
						else
						{
							num = -1686042608;
							num2 = num;
						}
					}
					goto IL_00e9;
					IL_00fe:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					if (ReInput._id != iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(iKQXbXnVtIaMZEJNeigQJWAHqUx.znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = -1686042602;
						goto IL_001f;
					}
					goto IL_00e9;
					IL_00e9:
					iKQXbXnVtIaMZEJNeigQJWAHqUx.UpdatePollingFrameTracking();
					num = -1686042605;
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
			public npZmRiumRsvkrMgQVvkOrehZHUj(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		public readonly int id;

		protected string _tag;

		protected string _name;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid OtVFjwsBdyyNFQHLWfYqCKpUyfa;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension RlhCPmWdFbcKPPhKmYBnLApskyE;

		private bool PAfqntGWZaNgzmZFIOyQPuJGOCq;

		private ControllerIdentifier aDwkabFLbtXZmwugTIBtMgVSqlG;

		internal int znFtIaPrJLvdjPGCwXFaaAeLKcr;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> SERTGFptqMjtvIPNWFYznVbzAwf;

		private readonly ReadOnlyCollection<Element> uYCZQbMkrLLRfaHNIaSBlhhdXMi;

		internal readonly InputSource CpNbHtCijSICCnUFhUdnSnuZaCd;

		internal readonly ControllerDataUpdater ybiZyKuVmvsrOHqZzdmfwidXkdm;

		internal readonly HardwareControllerMap_Game RCNejcvnZtMAmgendVbiwgNYmdD;

		internal uint ZiBWJqHGYvQSltkdFfMKoNywXJD;

		private uint FWDlwTNZgemXOaqiatNLXlgYHcV;

		private uint GjRDtXznCCAhvyIdBylboNNJdWR;

		private Action<bool> TEEhmdIRbRbrcoqQUkwTruKySqN;

		private IControllerTemplate[] ubsIBKLQBnosVvePVOQElRJzKU;

		private ReadOnlyCollection<IControllerTemplate> czlfGCECIdSwszuDQfcKYYwvrIv;

		private static Func<Controller, Guid, bool> BgKUxSWlNcnOePyUgthSnZxKpuE;

		private static Func<Controller, Type, bool> IHgEnxXOAFKpWdCnGWIIqJUAKTj;

		[CompilerGenerated]
		private static Func<Controller, Guid, bool> OaciNJiksQpXpqpsqstbBUbOMJaC;

		[CompilerGenerated]
		private static Func<Controller, Type, bool> TODKqlbTiotlvzHBygnoMXgfGhn;

		internal bool wasPollingPrev
		{
			get
			{
				return FWDlwTNZgemXOaqiatNLXlgYHcV == ReInput.previousFrame;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				}
				return PAfqntGWZaNgzmZFIOyQPuJGOCq;
			}
			set
			{
				SetEnabled(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
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
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
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
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Guid.Empty;
				}
				return OtVFjwsBdyyNFQHLWfYqCKpUyfa;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier
		{
			get
			{
				return aDwkabFLbtXZmwugTIBtMgVSqlG;
			}
		}

		public bool isConnected
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				}
				else if (!value)
				{
					Disconnected();
				}
				else
				{
					Connected();
				}
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return string.Empty;
				}
				return _hardwareIdentifier;
			}
		}

		public string mapTypeString
		{
			get
			{
				return _type.ToString() + "Map";
			}
		}

		public int elementCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0;
				}
				return SERTGFptqMjtvIPNWFYznVbzAwf.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					while (true)
					{
						int num = 227883385;
						while (true)
						{
							switch (num ^ 0xD953978)
							{
							case 2:
								break;
							case 1:
								goto IL_002b;
							default:
								return 0;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = 227883384;
						}
					}
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return uYCZQbMkrLLRfaHNIaSBlhhdXMi;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					while (true)
					{
						int num = -1924464455;
						while (true)
						{
							switch (num ^ -1924464453)
							{
							case 0:
								break;
							case 2:
								goto IL_002b;
							default:
								return null;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = -1924464454;
						}
					}
				}
				return RlhCPmWdFbcKPPhKmYBnLApskyE;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return RCNejcvnZtMAmgendVbiwgNYmdD.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					while (true)
					{
						int num = -1475975540;
						while (true)
						{
							switch (num ^ -1475975538)
							{
							case 0:
								break;
							case 2:
								goto IL_002b;
							default:
								return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = -1475975537;
						}
					}
				}
				return RCNejcvnZtMAmgendVbiwgNYmdD.buttonElementIdentifiers_readOnly;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					while (true)
					{
						int num = 1707162068;
						while (true)
						{
							switch (num ^ 0x65C139D5)
							{
							case 2:
								break;
							case 1:
								goto IL_002b;
							default:
								return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = 1707162069;
						}
					}
				}
				return czlfGCECIdSwszuDQfcKYYwvrIv;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					while (true)
					{
						int num = -1347991798;
						while (true)
						{
							switch (num ^ -1347991800)
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
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = -1347991799;
						}
					}
				}
				return ubsIBKLQBnosVvePVOQElRJzKU.Length;
			}
		}

		internal static Func<Controller, Guid, bool> implementsTemplateDelegate_Guid
		{
			get
			{
				return (Controller P_0, Guid P_1) => P_0.ImplementsTemplate(P_1);
			}
		}

		internal static Func<Controller, Type, bool> implementsTemplateDelegate_Type
		{
			get
			{
				Func<Controller, Type, bool> func = IHgEnxXOAFKpWdCnGWIIqJUAKTj;
				if (func == null)
				{
					while (true)
					{
						int num = 1790106294;
						while (true)
						{
							switch (num ^ 0x6AB2DAB4)
							{
							case 0:
								break;
							case 2:
								if (TODKqlbTiotlvzHBygnoMXgfGhn == null)
								{
									TODKqlbTiotlvzHBygnoMXgfGhn = (Controller P_0, Type P_1) => P_0.ImplementsTemplate(P_1);
									num = 1790106293;
									continue;
								}
								goto end_IL_0009;
							default:
								goto end_IL_0009;
							}
							break;
						}
						continue;
						end_IL_0009:
						break;
					}
					func = (IHgEnxXOAFKpWdCnGWIIqJUAKTj = TODKqlbTiotlvzHBygnoMXgfGhn);
				}
				return func;
			}
		}

		internal event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				TEEhmdIRbRbrcoqQUkwTruKySqN = (Action<bool>)Delegate.Combine(TEEhmdIRbRbrcoqQUkwTruKySqN, value);
			}
			remove
			{
				TEEhmdIRbRbrcoqQUkwTruKySqN = (Action<bool>)Delegate.Remove(TEEhmdIRbRbrcoqQUkwTruKySqN, value);
			}
		}

		internal Controller(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, ControllerType type, Guid hardwareTypeGuid, int buttonCount, bool[] isButtonPressureSensitive, HardwareButtonInfo[] hwButtonInfo, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
		{
			id = controllerId;
			CpNbHtCijSICCnUFhUdnSnuZaCd = inputSource;
			_type = type;
			OtVFjwsBdyyNFQHLWfYqCKpUyfa = hardwareTypeGuid;
			_buttonCount = buttonCount;
			_name = name;
			_hardwareName = hardwareName;
			_hardwareIdentifier = hardwareIdentifier;
			ybiZyKuVmvsrOHqZzdmfwidXkdm = dataUpdater;
			RCNejcvnZtMAmgendVbiwgNYmdD = hardwareMap;
			PAfqntGWZaNgzmZFIOyQPuJGOCq = true;
			znFtIaPrJLvdjPGCwXFaaAeLKcr = ReInput.id;
			qVYVNupolNeIsaFeJRsbUHVXuxRg(extension);
			SERTGFptqMjtvIPNWFYznVbzAwf = new List<Element>(buttonCount);
			uYCZQbMkrLLRfaHNIaSBlhhdXMi = new ReadOnlyCollection<Element>(SERTGFptqMjtvIPNWFYznVbzAwf);
			buttons = new Button[buttonCount];
			if (isButtonPressureSensitive == null || isButtonPressureSensitive.Length < buttonCount)
			{
				for (int i = 0; i < buttonCount; i++)
				{
					buttons[i] = new Button(this, hardwareMap.buttonElementIdentifierIds[i], "Button " + i, false, (hwButtonInfo != null) ? hwButtonInfo[i] : new HardwareButtonInfo());
					uiIyqEcLjeCLLGNLkqHYomAmAGZF(buttons[i]);
				}
			}
			else
			{
				for (int j = 0; j < buttonCount; j++)
				{
					buttons[j] = new Button(this, hardwareMap.buttonElementIdentifierIds[j], "Button " + j, isButtonPressureSensitive[j], (hwButtonInfo != null) ? hwButtonInfo[j] : new HardwareButtonInfo());
					uiIyqEcLjeCLLGNLkqHYomAmAGZF(buttons[j]);
				}
			}
			buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
			ubsIBKLQBnosVvePVOQElRJzKU = EmptyObjects<IControllerTemplate>.array;
			czlfGCECIdSwszuDQfcKYYwvrIv = new ReadOnlyCollection<IControllerTemplate>(ubsIBKLQBnosVvePVOQElRJzKU);
			Connected();
		}

		internal virtual void snpHjGkGVogejiySyWIFjoJWDLTS()
		{
			aDwkabFLbtXZmwugTIBtMgVSqlG = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			if (RCNejcvnZtMAmgendVbiwgNYmdD == null)
			{
				return null;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return buttons[buttonIndex];
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return -1;
			}
			return RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					int num = -151672423;
					while (true)
					{
						switch (num ^ -151672421)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return null;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = -151672422;
					}
				}
			}
			return RCNejcvnZtMAmgendVbiwgNYmdD.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = 2095131671;
					goto IL_0012;
				}
				return buttons[index].value;
			}
			goto IL_004d;
			IL_0012:
			switch (num ^ 0x7CE12C15)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			default:
				goto IL_004d;
			}
			goto IL_000d;
			IL_000d:
			num = 2095131668;
			goto IL_0012;
			IL_004d:
			return false;
		}

		public virtual bool GetButtonDown(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num;
			int num2;
			if (index < 0)
			{
				num = 1564493845;
				num2 = num;
			}
			else
			{
				num = 1564493844;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = 1564493847;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x5D404814)
				{
				case 2:
					break;
				case 3:
					return false;
				case 0:
					if (index >= _buttonCount)
					{
						goto IL_005b;
					}
					return buttons[index].justPressed;
				default:
					return false;
				}
				break;
				IL_005b:
				num = 1564493845;
			}
			goto IL_0019;
		}

		public virtual bool GetButtonUp(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].value != buttons[index].valuePrev;
		}

		public virtual bool GetButtonPrev(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].valuePrev;
		}

		public virtual bool GetButtonDoublePressHold(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = 485233932;
					goto IL_001e;
				}
				return buttons[index].DoublePressedAndHeld(speed);
			}
			goto IL_004d;
			IL_001e:
			switch (num ^ 0x1CEC150D)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				goto IL_004d;
			}
			goto IL_0019;
			IL_0019:
			num = 485233935;
			goto IL_001e;
			IL_004d:
			return false;
		}

		public virtual bool GetButtonDoublePressDown(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].JustDoublePressed(speed);
		}

		public virtual float GetButtonTimePressed(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0f;
			}
			return buttons[index].timePressed;
		}

		public virtual float GetButtonTimeUnpressed(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = -852600575;
					goto IL_0012;
				}
				return buttons[index].timeUnpressed;
			}
			goto IL_0051;
			IL_0012:
			switch (num ^ -852600573)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			default:
				goto IL_0051;
			}
			goto IL_000d;
			IL_000d:
			num = -852600574;
			goto IL_0012;
			IL_0051:
			return 0f;
		}

		public virtual float GetButtonLastTimePressed(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			if (index >= 0)
			{
				while (true)
				{
					int num = 1601009139;
					while (true)
					{
						switch (num ^ 0x5F6D75F1)
						{
						case 0:
							break;
						case 2:
							goto IL_0041;
						default:
							goto end_IL_0023;
						}
						break;
						IL_0041:
						if (index >= _buttonCount)
						{
							num = 1601009136;
							continue;
						}
						return buttons[index].lastTimePressed;
					}
					continue;
					end_IL_0023:
					break;
				}
			}
			return 0f;
		}

		public virtual float GetButtonLastTimeUnpressed(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = -895675168;
					goto IL_0012;
				}
				return buttons[index].lastTimeUnpressed;
			}
			goto IL_005c;
			IL_0012:
			while (true)
			{
				switch (num ^ -895675165)
				{
				case 0:
					break;
				case 1:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = -895675167;
					continue;
				case 2:
					return 0f;
				default:
					goto IL_005c;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = -895675166;
			goto IL_0012;
			IL_005c:
			return 0f;
		}

		public virtual bool GetAnyButton()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num = 0;
			int num2 = -108739004;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num2 ^ -108739003)
				{
				case 2:
					break;
				case 4:
					return true;
				case 0:
					if (!buttons[num].value)
					{
						num++;
						num2 = -108739004;
					}
					else
					{
						num2 = -108739007;
					}
					continue;
				case 3:
					return false;
				default:
					if (num >= _buttonCount)
					{
						return false;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num2 = -108739002;
			goto IL_001e;
		}

		public virtual bool GetAnyButtonDown()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num = 0;
			int num2 = 37883468;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num2 ^ 0x2420E48)
				{
				case 0:
					break;
				case 4:
				{
					int num3;
					if (num >= _buttonCount)
					{
						num2 = 37883467;
						num3 = num2;
					}
					else
					{
						num2 = 37883465;
						num3 = num2;
					}
					continue;
				}
				case 1:
					if (buttons[num].justPressed)
					{
						return true;
					}
					num++;
					num2 = 37883468;
					continue;
				case 2:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				default:
					return false;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num2 = 37883466;
			goto IL_0012;
		}

		public virtual bool GetAnyButtonUp()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			int num = 0;
			while (num < _buttonCount)
			{
				while (true)
				{
					if (buttons[num].justReleased)
					{
						return true;
					}
					num++;
					int num2 = 387291803;
					while (true)
					{
						switch (num2 ^ 0x17159A9A)
						{
						case 0:
							num2 = 387291800;
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
			return false;
		}

		public virtual bool GetAnyButtonPrev()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num = 0;
			int num2 = -1360241737;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num2 ^ -1360241737)
				{
				case 3:
					break;
				case 1:
					return false;
				case 2:
					if (buttons[num].valuePrev)
					{
						return true;
					}
					num++;
					num2 = -1360241741;
					continue;
				case 4:
				{
					int num3;
					if (num >= _buttonCount)
					{
						num2 = -1360241742;
						num3 = num2;
					}
					else
					{
						num2 = -1360241739;
						num3 = num2;
					}
					continue;
				}
				case 0:
					num2 = -1360241741;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num2 = -1360241738;
			goto IL_001e;
		}

		public virtual bool GetAnyButtonChanged()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = 472313309;
				while (true)
				{
					switch (num2 ^ 0x1C26EDDF)
					{
					case 3:
						break;
					case 2:
						num2 = 472313311;
						continue;
					case 1:
						if (buttons[num].justChangedState)
						{
							return true;
						}
						num++;
						num2 = 472313311;
						continue;
					default:
						if (num >= _buttonCount)
						{
							return false;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public virtual bool GetButtonById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			int num;
			if (buttonIndex >= 0)
			{
				if (buttonIndex >= _buttonCount)
				{
					num = 899812133;
					goto IL_0012;
				}
				return buttons[buttonIndex].value;
			}
			goto IL_005a;
			IL_0012:
			switch (num ^ 0x35A20B24)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			default:
				goto IL_005a;
			}
			goto IL_000d;
			IL_000d:
			num = 899812134;
			goto IL_0012;
			IL_005a:
			return false;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			int num;
			if (buttonIndex >= 0)
			{
				if (buttonIndex >= _buttonCount)
				{
					num = -1257854741;
					goto IL_0012;
				}
				return buttons[buttonIndex].justReleased;
			}
			goto IL_005a;
			IL_0012:
			switch (num ^ -1257854742)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			default:
				goto IL_005a;
			}
			goto IL_000d;
			IL_000d:
			num = -1257854744;
			goto IL_0012;
			IL_005a:
			return false;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			int num;
			if (buttonIndex >= 0)
			{
				if (buttonIndex >= _buttonCount)
				{
					num = -2077172548;
					goto IL_0012;
				}
				return buttons[buttonIndex].DoublePressedAndHeld(speed);
			}
			goto IL_0065;
			IL_0012:
			while (true)
			{
				switch (num ^ -2077172545)
				{
				case 0:
					break;
				case 1:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = -2077172547;
					continue;
				case 2:
					return false;
				default:
					goto IL_0065;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = -2077172546;
			goto IL_0012;
			IL_0065:
			return false;
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			while (true)
			{
				int num = -1095505834;
				while (true)
				{
					switch (num ^ -1095505833)
					{
					case 0:
						break;
					case 1:
					{
						int num2;
						if (buttonIndex < 0)
						{
							num = -1095505835;
							num2 = num;
						}
						else
						{
							num = -1095505836;
							num2 = num;
						}
						continue;
					}
					case 3:
						if (buttonIndex >= _buttonCount)
						{
							num = -1095505835;
							continue;
						}
						return buttons[buttonIndex].JustDoublePressed(speed);
					default:
						return false;
					}
					break;
				}
			}
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			int num;
			int num2;
			if (buttonIndex < 0)
			{
				num = 39706315;
				num2 = num;
			}
			else
			{
				num = 39706312;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 39706313;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x25DDEC8)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				case 0:
					if (buttonIndex >= _buttonCount)
					{
						goto IL_0068;
					}
					return buttons[buttonIndex].valuePrev;
				default:
					return false;
				}
				break;
				IL_0068:
				num = 39706315;
			}
			goto IL_000d;
		}

		public virtual float GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0f;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual float GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			int num;
			if (buttonIndex >= 0)
			{
				if (buttonIndex >= _buttonCount)
				{
					num = -563362798;
					goto IL_001e;
				}
				return buttons[buttonIndex].timeUnpressed;
			}
			goto IL_005e;
			IL_001e:
			switch (num ^ -563362797)
			{
			case 0:
				break;
			case 2:
				return 0f;
			default:
				goto IL_005e;
			}
			goto IL_0019;
			IL_0019:
			num = -563362799;
			goto IL_001e;
			IL_005e:
			return 0f;
		}

		public virtual float GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0f;
			}
			return buttons[buttonIndex].lastTimePressed;
		}

		public virtual float GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			int buttonIndex = RCNejcvnZtMAmgendVbiwgNYmdD.GetButtonIndex(elementIdentifierId);
			while (true)
			{
				int num = 555639020;
				while (true)
				{
					switch (num ^ 0x211E60ED)
					{
					case 2:
						break;
					case 1:
						if (buttonIndex >= 0)
						{
							if (buttonIndex >= _buttonCount)
							{
								goto IL_0057;
							}
							return buttons[buttonIndex].lastTimeUnpressed;
						}
						goto default;
					default:
						return 0f;
					}
					break;
					IL_0057:
					num = 555639021;
				}
			}
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			UpdatePollingFrameTracking();
			int num = 0;
			int num2 = -194317412;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num2 ^ -194317410)
				{
				case 0:
					break;
				case 3:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				case 1:
				{
					int elementIdentifierId;
					if (XJFeckwuSgaMGZjXezGEbsRjgYr(num, out elementIdentifierId))
					{
						return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, num, Pole.Positive, RCNejcvnZtMAmgendVbiwgNYmdD.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
					}
					num++;
					num2 = -194317414;
					continue;
				}
				case 2:
					num2 = -194317414;
					continue;
				default:
					if (num >= _buttonCount)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					goto case 1;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num2 = -194317411;
			goto IL_0012;
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			UpdatePollingFrameTracking();
			int num = 729986920;
			goto IL_001e;
			IL_001e:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x2B82B76A)
				{
				case 4:
					break;
				case 1:
					return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
				case 2:
					num2 = 0;
					num = 729986922;
					continue;
				case 3:
				{
					int elementIdentifierId;
					if (VkYPMFlzGbqTcwGAGUFPygZuyLN(num2, out elementIdentifierId))
					{
						return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, num2, Pole.Positive, RCNejcvnZtMAmgendVbiwgNYmdD.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
					}
					num2++;
					num = 729986922;
					continue;
				}
				default:
					if (num2 >= _buttonCount)
					{
						return ControllerPollingInfo.sjiLkgmIqUkLcvoxqoqlLNNXMgF();
					}
					goto case 3;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num = 729986923;
			goto IL_001e;
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
			ueHPgUwcwGKxqEediNYeDgURtsn ueHPgUwcwGKxqEediNYeDgURtsn2 = new ueHPgUwcwGKxqEediNYeDgURtsn(-2);
			ueHPgUwcwGKxqEediNYeDgURtsn2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			return ueHPgUwcwGKxqEediNYeDgURtsn2;
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			npZmRiumRsvkrMgQVvkOrehZHUj npZmRiumRsvkrMgQVvkOrehZHUj2 = new npZmRiumRsvkrMgQVvkOrehZHUj(-2);
			while (true)
			{
				int num = 39505736;
				while (true)
				{
					switch (num ^ 0x25ACF4A)
					{
					case 0:
						break;
					case 2:
						goto IL_0026;
					default:
						return npZmRiumRsvkrMgQVvkOrehZHUj2;
					}
					break;
					IL_0026:
					npZmRiumRsvkrMgQVvkOrehZHUj2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					num = 39505739;
				}
			}
		}

		private bool XJFeckwuSgaMGZjXezGEbsRjgYr(int P_0, out int P_1)
		{
			P_1 = -1;
			bool flag = default(bool);
			while (true)
			{
				int num = 589876930;
				while (true)
				{
					switch (num ^ 0x2328CEC1)
					{
					case 5:
						break;
					case 0:
						if (P_1 < 0)
						{
							num = 589876931;
							continue;
						}
						return true;
					case 1:
						return false;
					case 4:
						if (flag)
						{
							P_1 = RCNejcvnZtMAmgendVbiwgNYmdD.buttonElementIdentifierIds[P_0];
							num = 589876929;
						}
						else
						{
							num = 589876928;
						}
						continue;
					case 3:
						flag = buttons[P_0].value && !buttons[P_0].HeWnhSDeUwBpzVKMyfPgtPmfjjx._excludeFromPolling;
						num = 589876933;
						continue;
					default:
						return false;
					}
					break;
				}
			}
		}

		private bool VkYPMFlzGbqTcwGAGUFPygZuyLN(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].HeWnhSDeUwBpzVKMyfPgtPmfjjx._excludeFromPolling)
			{
				return false;
			}
			P_1 = RCNejcvnZtMAmgendVbiwgNYmdD.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (GjRDtXznCCAhvyIdBylboNNJdWR == ReInput.currentFrame)
			{
				goto IL_000d;
			}
			goto IL_004f;
			IL_000d:
			int num = 1918357350;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x7257CF67)
				{
				case 5:
					break;
				default:
					return;
				case 4:
					if (ZiBWJqHGYvQSltkdFfMKoNywXJD == uint.MaxValue)
					{
						ZiBWJqHGYvQSltkdFfMKoNywXJD = 0u;
						return;
					}
					goto case 2;
				case 0:
					goto IL_004f;
				case 1:
					return;
				case 2:
					ZiBWJqHGYvQSltkdFfMKoNywXJD++;
					num = 1918357348;
					continue;
				case 3:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_004f:
			FWDlwTNZgemXOaqiatNLXlgYHcV = GjRDtXznCCAhvyIdBylboNNJdWR;
			GjRDtXznCCAhvyIdBylboNNJdWR = ReInput.currentFrame;
			int num2;
			if (wasPollingPrev)
			{
				num = 1918357348;
				num2 = num;
			}
			else
			{
				num = 1918357347;
				num2 = num;
			}
			goto IL_0012;
		}

		public virtual float GetLastTimeActive()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			return GetLastTimeActive(false);
		}

		public virtual float GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual float GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			return GetLastTimeAnyElementChanged(false);
		}

		public virtual float GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public float GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			float num = default(float);
			int num2 = default(int);
			int num3;
			if (buttons != null)
			{
				num = 0f;
				num2 = 0;
				num3 = 955199058;
			}
			else
			{
				num3 = 955199063;
			}
			goto IL_0012;
			IL_000d:
			num3 = 955199062;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num3 ^ 0x38EF2E52)
				{
				case 3:
					break;
				case 5:
					return 0f;
				case 2:
				{
					float lastTimePressed = buttons[num2].lastTimePressed;
					if (lastTimePressed > num)
					{
						num = lastTimePressed;
						num3 = 955199060;
						continue;
					}
					goto case 6;
				}
				case 6:
					num2++;
					num3 = 955199058;
					continue;
				case 1:
					return 0f;
				case 4:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num3 = 955199059;
					continue;
				default:
					if (num2 >= buttons.Length)
					{
						return num;
					}
					goto case 2;
				}
				break;
			}
			goto IL_000d;
		}

		public float GetLastTimeAnyButtonChanged()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			if (buttons == null)
			{
				return 0f;
			}
			float num = 0f;
			int num2 = 408245108;
			goto IL_0012;
			IL_000d:
			num2 = 408245105;
			goto IL_0012;
			IL_0012:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x18555370)
				{
				case 5:
					break;
				case 6:
				{
					float lastTimeStateChanged = buttons[num3].lastTimeStateChanged;
					if (lastTimeStateChanged > num)
					{
						num = lastTimeStateChanged;
						num2 = 408245107;
						continue;
					}
					goto case 3;
				}
				case 3:
					num3++;
					num2 = 408245104;
					continue;
				case 1:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0f;
				case 2:
					num2 = 408245104;
					continue;
				case 4:
					num3 = 0;
					num2 = 408245106;
					continue;
				default:
					if (num3 >= buttons.Length)
					{
						return num;
					}
					goto case 6;
				}
				break;
			}
			goto IL_000d;
		}

		public T GetExtension<T>() where T : class
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			return RlhCPmWdFbcKPPhKmYBnLApskyE as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num = 0;
			int num2 = 144489175;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num2 ^ 0x89CBAD6)
				{
				case 2:
					break;
				case 3:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				case 0:
					if (!(ubsIBKLQBnosVvePVOQElRJzKU[num].typeGuid == typeGuid))
					{
						goto IL_0064;
					}
					return ubsIBKLQBnosVvePVOQElRJzKU[num];
				default:
					if (num >= ubsIBKLQBnosVvePVOQElRJzKU.Length)
					{
						return null;
					}
					goto case 0;
				}
				break;
				IL_0064:
				num++;
				num2 = 144489175;
			}
			goto IL_000d;
			IL_000d:
			num2 = 144489173;
			goto IL_0012;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2 = 1382873707;
				while (true)
				{
					switch (num2 ^ 0x526CFA68)
					{
					case 0:
						break;
					case 3:
						num2 = 1382873708;
						continue;
					case 1:
						if (ReflectionTools.DoesTypeImplement(ubsIBKLQBnosVvePVOQElRJzKU[num].GetType(), type))
						{
							num2 = 1382873706;
							continue;
						}
						num++;
						num2 = 1382873708;
						continue;
					case 2:
						return ubsIBKLQBnosVvePVOQElRJzKU[num];
					default:
						if (num >= ubsIBKLQBnosVvePVOQElRJzKU.Length)
						{
							return null;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			int num = 0;
			int num2 = 1714691239;
			goto IL_0012;
			IL_0012:
			T result = default(T);
			while (true)
			{
				switch (num2 ^ 0x66341CA3)
				{
				case 3:
					break;
				case 1:
					if (ubsIBKLQBnosVvePVOQElRJzKU[num] as T != null)
					{
						num2 = 1714691237;
						continue;
					}
					num++;
					num2 = 1714691239;
					continue;
				case 0:
					result = null;
					num2 = 1714691233;
					continue;
				case 5:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num2 = 1714691235;
					continue;
				case 2:
					return result;
				case 6:
					return ubsIBKLQBnosVvePVOQElRJzKU[num] as T;
				default:
					if (num >= ubsIBKLQBnosVvePVOQElRJzKU.Length)
					{
						return null;
					}
					goto case 1;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num2 = 1714691238;
			goto IL_0012;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1705650968;
				while (true)
				{
					switch (num2 ^ -1705650966)
					{
					case 0:
						break;
					case 2:
						num2 = -1705650967;
						continue;
					case 1:
						if (ubsIBKLQBnosVvePVOQElRJzKU[num].typeGuid == typeGuid)
						{
							return true;
						}
						num++;
						num2 = -1705650967;
						continue;
					default:
						if (num >= ubsIBKLQBnosVvePVOQElRJzKU.Length)
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			goto IL_0056;
			IL_0012:
			int num;
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x7EB72F93)
				{
				case 3:
					break;
				case 2:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				case 1:
					goto IL_0056;
				case 4:
					goto IL_005f;
				default:
					if (num2 >= ubsIBKLQBnosVvePVOQElRJzKU.Length)
					{
						return false;
					}
					goto IL_005f;
				}
				break;
				IL_005f:
				if (ReflectionTools.DoesTypeImplement(ubsIBKLQBnosVvePVOQElRJzKU[num2].GetType(), type))
				{
					return true;
				}
				num2++;
				num = 2125934483;
			}
			goto IL_000d;
			IL_0056:
			num2 = 0;
			num = 2125934483;
			goto IL_0012;
			IL_000d:
			num = 2125934481;
			goto IL_0012;
		}

		public bool ImplementsTemplate<T>() where T : class
		{
			return ImplementsTemplate(typeof(T));
		}

		internal void vRVgKtnyYDgVtYmVZcPHYjYJKvu(IControllerTemplate[] P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				ubsIBKLQBnosVvePVOQElRJzKU = P_0;
				int num = -1393663741;
				while (true)
				{
					switch (num ^ -1393663744)
					{
					case 2:
						num = -1393663743;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						czlfGCECIdSwszuDQfcKYYwvrIv = new ReadOnlyCollection<IControllerTemplate>(ubsIBKLQBnosVvePVOQElRJzKU);
						num = -1393663744;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		internal virtual void UpdateData(UpdateLoopType P_0)
		{
			bool flag = ReInput.IsInputAllowed(_type);
			int num = _buttonCount;
			if (flag)
			{
				goto IL_0016;
			}
			goto IL_008b;
			IL_0016:
			int num2 = -1796269047;
			goto IL_001b;
			IL_001b:
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -1796269056)
				{
				case 4:
					break;
				default:
					return;
				case 5:
					if (buttons[num3].axHEQbAmdnNnSAAeBbHMhcbvfuTu <= 0)
					{
						buttons[num3].TyrDDJAfnnLNoDKHAjBmQpKiHMBc(P_0);
						num2 = -1796269049;
						continue;
					}
					goto case 7;
				case 6:
					num4++;
					num2 = -1796269046;
					continue;
				case 0:
					goto IL_008b;
				case 11:
					goto IL_0094;
				case 9:
					num4 = 0;
					num2 = -1796269046;
					continue;
				case 8:
					buttons[num4].MPPQJfVkqEnvckKDMacDSmlvhjwB(P_0, num4, ybiZyKuVmvsrOHqZzdmfwidXkdm);
					num2 = -1796269050;
					continue;
				case 7:
					num3++;
					num2 = -1796269045;
					continue;
				case 10:
					if (num4 >= num)
					{
						num2 = -1796269055;
						continue;
					}
					goto IL_0111;
				case 1:
					if (RlhCPmWdFbcKPPhKmYBnLApskyE != null)
					{
						RlhCPmWdFbcKPPhKmYBnLApskyE.UpdateData(P_0);
						num2 = -1796269053;
						continue;
					}
					return;
				case 2:
					goto IL_0111;
				case 3:
					return;
				}
				break;
				IL_0111:
				int num5;
				if (buttons[num4].axHEQbAmdnNnSAAeBbHMhcbvfuTu <= 0)
				{
					num2 = -1796269048;
					num5 = num2;
				}
				else
				{
					num2 = -1796269050;
					num5 = num2;
				}
				continue;
				IL_0094:
				int num6;
				if (num3 < num)
				{
					num2 = -1796269051;
					num6 = num2;
				}
				else
				{
					num2 = -1796269055;
					num6 = num2;
				}
			}
			goto IL_0016;
			IL_008b:
			num3 = 0;
			num2 = -1796269045;
			goto IL_001b;
		}

		internal virtual ButtonStateFlags wJMDqzalTAkbVUNADdKHbMgQhGiP(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE;
			}
			return buttons[P_0].state;
		}

		internal void qVYVNupolNeIsaFeJRsbUHVXuxRg(Extension P_0)
		{
			if (P_0 == null)
			{
				RlhCPmWdFbcKPPhKmYBnLApskyE = null;
				goto IL_000a;
			}
			goto IL_004e;
			IL_004e:
			int num;
			int num2;
			if (RlhCPmWdFbcKPPhKmYBnLApskyE == null)
			{
				num = 471465547;
				num2 = num;
			}
			else
			{
				num = 471465550;
				num2 = num;
			}
			goto IL_000f;
			IL_000a:
			num = 471465545;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num ^ 0x1C19FE4A)
				{
				case 2:
					break;
				case 5:
					return;
				case 1:
					P_0.SetController(this);
					num = 471465546;
					continue;
				case 6:
					goto IL_004e;
				case 3:
					return;
				case 4:
					wFNxILHosqnCwEOlbeICtkHZvYR(P_0);
					num = 471465551;
					continue;
				default:
					RlhCPmWdFbcKPPhKmYBnLApskyE = P_0.Clone();
					return;
				}
				break;
			}
			goto IL_000a;
		}

		internal void wFNxILHosqnCwEOlbeICtkHZvYR(Extension P_0)
		{
			if (RlhCPmWdFbcKPPhKmYBnLApskyE != null)
			{
				RlhCPmWdFbcKPPhKmYBnLApskyE.SetSource(P_0);
				RlhCPmWdFbcKPPhKmYBnLApskyE.SetController(this);
				if (P_0 == null)
				{
					return;
				}
				goto IL_0023;
			}
			goto IL_0054;
			IL_0054:
			qVYVNupolNeIsaFeJRsbUHVXuxRg(P_0);
			int num = 1228309671;
			goto IL_0028;
			IL_0023:
			num = 1228309670;
			goto IL_0028;
			IL_0028:
			switch (num ^ 0x493684A7)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				P_0.SetController(this);
				return;
			case 2:
				goto IL_0054;
			case 0:
				return;
			}
			goto IL_0023;
		}

		internal virtual void Clear()
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= _buttonCount)
				{
					num2 = -335250221;
					num3 = num2;
				}
				else
				{
					num2 = -335250218;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -335250222)
					{
					case 3:
						num2 = -335250218;
						continue;
					default:
						return;
					case 4:
						if (buttons[num] != null)
						{
							buttons[num].Reset();
							num2 = -335250224;
							continue;
						}
						goto case 2;
					case 5:
						if (RlhCPmWdFbcKPPhKmYBnLApskyE != null)
						{
							RlhCPmWdFbcKPPhKmYBnLApskyE.Clear();
							num2 = -335250220;
							continue;
						}
						return;
					case 0:
						break;
					case 1:
						if (ybiZyKuVmvsrOHqZzdmfwidXkdm != null)
						{
							ybiZyKuVmvsrOHqZzdmfwidXkdm.ClearData();
							num2 = -335250217;
							continue;
						}
						goto case 5;
					case 2:
						num++;
						num2 = -335250222;
						continue;
					case 6:
						return;
					}
					break;
				}
			}
		}

		internal virtual bool SetEnabled(bool P_0)
		{
			if (PAfqntGWZaNgzmZFIOyQPuJGOCq == P_0)
			{
				return false;
			}
			if (!P_0)
			{
				Clear();
				goto IL_0014;
			}
			goto IL_0036;
			IL_0019:
			int num;
			while (true)
			{
				switch (num ^ 0x24BF9BB1)
				{
				case 0:
					break;
				case 3:
					goto IL_0036;
				case 1:
					TEEhmdIRbRbrcoqQUkwTruKySqN(P_0);
					num = 616537011;
					continue;
				default:
					return true;
				}
				break;
			}
			goto IL_0014;
			IL_0036:
			PAfqntGWZaNgzmZFIOyQPuJGOCq = P_0;
			int num2;
			if (TEEhmdIRbRbrcoqQUkwTruKySqN == null)
			{
				num = 616537011;
				num2 = num;
			}
			else
			{
				num = 616537008;
				num2 = num;
			}
			goto IL_0019;
			IL_0014:
			num = 616537010;
			goto IL_0019;
		}

		internal virtual void BakeMap(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num2 = default(int);
			IList<ActionElementMap> buttonMaps = default(IList<ActionElementMap>);
			while (true)
			{
				P_0.controllerId = id;
				int num = 303534170;
				while (true)
				{
					switch (num ^ 0x1217905E)
					{
					case 5:
						num = 303534175;
						continue;
					case 2:
						num2 = 0;
						num = 303534174;
						continue;
					case 4:
						P_0.controllerType = _type;
						buttonMaps = P_0.ButtonMaps;
						num = 303534172;
						continue;
					case 3:
						BakeActionElementMap(P_0, buttonMaps[num2]);
						num2++;
						num = 303534174;
						continue;
					case 1:
						break;
					default:
						if (num2 >= buttonMaps.Count)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		internal virtual void BakeActionElementMap(ControllerMap P_0, ActionElementMap P_1)
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
					P_1.IKsKsQjqHpGcmPftZSVTCEpXtFB(P_0);
					int num = 568647513;
					while (true)
					{
						switch (num ^ 0x21E4DF5A)
						{
						case 0:
							num = 568647515;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							goto IL_0037;
						case 3:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		internal bool zipcKsFwwhgorhescWUPdkTTOFi(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int mMyVYAPDqUrVlKvCuSgnRJfZwdm = P_0.mMyVYAPDqUrVlKvCuSgnRJfZwdm;
			int num;
			if (mMyVYAPDqUrVlKvCuSgnRJfZwdm >= 0)
			{
				if (mMyVYAPDqUrVlKvCuSgnRJfZwdm >= _buttonCount)
				{
					goto IL_0030;
				}
				P_3 = buttons[mMyVYAPDqUrVlKvCuSgnRJfZwdm].EOEuEHUjrfDrsgyreIyiycBWacU;
				int num2;
				if (!P_3)
				{
					num = -440025760;
					num2 = num;
				}
				else
				{
					num = -440025746;
					num2 = num;
				}
				goto IL_0035;
			}
			goto IL_00ce;
			IL_00ce:
			return false;
			IL_0030:
			num = -440025756;
			goto IL_0035;
			IL_0035:
			float num3 = default(float);
			while (true)
			{
				switch (num ^ -440025753)
				{
				case 10:
					break;
				case 5:
					num = -440025759;
					continue;
				case 9:
					num3 = buttons[mMyVYAPDqUrVlKvCuSgnRJfZwdm].pressure;
					num = -440025757;
					continue;
				case 7:
					num3 = (buttons[mMyVYAPDqUrVlKvCuSgnRJfZwdm].value ? 1f : 0f);
					num = -440025754;
					continue;
				case 2:
					if (P_0._axisContribution == Pole.Negative)
					{
						num3 *= -1f;
						num = -440025759;
						continue;
					}
					goto default;
				case 3:
					goto IL_00ce;
				case 0:
					if (P_0._elementType != ControllerElementType.Button)
					{
						goto case 8;
					}
					if (P_0._axisContribution == Pole.Negative)
					{
						num3 *= -1f;
						num = -440025758;
						continue;
					}
					goto default;
				case 4:
					num = -440025754;
					continue;
				case 8:
					if (P_0._elementType == ControllerElementType.Axis)
					{
						if (P_0._axisRange != AxisRange.Full)
						{
							goto case 2;
						}
						if (P_0._invert)
						{
							num3 *= -1f;
							num = -440025759;
							continue;
						}
					}
					goto default;
				case 1:
					goto IL_0154;
				default:
					P_2 = num3;
					return true;
				}
				break;
				IL_0154:
				int num4;
				if (num3 <= 0f)
				{
					num = -440025759;
					num4 = num;
				}
				else
				{
					num = -440025753;
					num4 = num;
				}
			}
			goto IL_0030;
		}

		internal bool zipcKsFwwhgorhescWUPdkTTOFi(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
		{
			P_3 = 0f;
			if (P_1 != P_0._actionId)
			{
				goto IL_0014;
			}
			float num = (P_2 ? 1f : 0f);
			int num2 = -1188356672;
			goto IL_0019;
			IL_0014:
			num2 = -1188356670;
			goto IL_0019;
			IL_0019:
			while (true)
			{
				switch (num2 ^ -1188356669)
				{
				case 7:
					break;
				case 0:
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
						num2 = -1188356665;
						continue;
					}
					goto default;
				case 6:
					num *= -1f;
					num2 = -1188356665;
					continue;
				case 2:
					if (P_0._elementType == ControllerElementType.Axis)
					{
						if (P_0._axisRange != AxisRange.Full)
						{
							goto case 0;
						}
						if (P_0._invert)
						{
							num *= -1f;
							num2 = -1188356665;
							continue;
						}
					}
					goto default;
				case 5:
				{
					int num4;
					if (P_0._axisContribution != Pole.Negative)
					{
						num2 = -1188356665;
						num4 = num2;
					}
					else
					{
						num2 = -1188356667;
						num4 = num2;
					}
					continue;
				}
				case 3:
					if (num > 0f)
					{
						int num3;
						if (P_0._elementType == ControllerElementType.Button)
						{
							num2 = -1188356666;
							num3 = num2;
						}
						else
						{
							num2 = -1188356671;
							num3 = num2;
						}
						continue;
					}
					goto default;
				case 1:
					return false;
				default:
					P_3 = num;
					return true;
				}
				break;
			}
			goto IL_0014;
		}

		internal void uiIyqEcLjeCLLGNLkqHYomAmAGZF(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(SERTGFptqMjtvIPNWFYznVbzAwf, P_0);
			}
		}

		internal virtual Guid AAvuGtuPdpBOSepTHGUgGJNXNXth()
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
			if (ybiZyKuVmvsrOHqZzdmfwidXkdm == null)
			{
				return;
			}
			while (true)
			{
				int num = 1059916630;
				while (true)
				{
					switch (num ^ 0x3F2D0B57)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_002d;
					case 2:
						return;
					}
					break;
					IL_002d:
					ybiZyKuVmvsrOHqZzdmfwidXkdm.ClearData();
					num = 1059916629;
				}
			}
		}

		[CompilerGenerated]
		private static bool vTEaojIvVbbehSZRYJdcJBAySJgV(Controller P_0, Guid P_1)
		{
			return P_0.ImplementsTemplate(P_1);
		}

		[CompilerGenerated]
		private static bool ZmizNWTffRVtBSvXZaHqaQWivWw(Controller P_0, Type P_1)
		{
			return P_0.ImplementsTemplate(P_1);
		}
	}
}
