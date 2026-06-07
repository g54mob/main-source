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
			internal abstract class LWgHqlaWkDRUSPCbYTLNtoXMEFNb
			{
				public abstract class AkJWPtezDxoVOETxbmPBqsqmXup
				{
					public abstract void Reset();
				}

				protected readonly int nsWutdErdifWgaZvHrHEdIZzXOLj;

				protected readonly int[] pumYaSKRNdhQZVERULkMvjtJiLd;

				protected AkJWPtezDxoVOETxbmPBqsqmXup[] FRUUibiOIWEsSCBxDuohaLtzlQrt;

				public AkJWPtezDxoVOETxbmPBqsqmXup CLjmYleEuCraJMMUJEFwtuAaGlg;

				private int makeqSfOesOCmoTnKnppZmDJCnQg;

				public int sWXAmbipLtAbjKNEztzXOrpNGHPi = -1;

				protected ReadOnlyCollection<AkJWPtezDxoVOETxbmPBqsqmXup> rVTcHBaKtmcEYURuwYUwPvCziDib;

				public IList<AkJWPtezDxoVOETxbmPBqsqmXup> Data
				{
					get
					{
						return rVTcHBaKtmcEYURuwYUwPvCziDib;
					}
				}

				public UpdateLoopType updateLoop
				{
					set
					{
						while (true)
						{
							int num = 884999028;
							while (true)
							{
								switch (num ^ 0x34C00377)
								{
								case 0:
									break;
								case 3:
								{
									int num2;
									if (sWXAmbipLtAbjKNEztzXOrpNGHPi != (int)value)
									{
										num = 884999027;
										num2 = num;
									}
									else
									{
										num = 884999030;
										num2 = num;
									}
									continue;
								}
								case 4:
									sWXAmbipLtAbjKNEztzXOrpNGHPi = (int)value;
									makeqSfOesOCmoTnKnppZmDJCnQg = pumYaSKRNdhQZVERULkMvjtJiLd[(int)value];
									num = 884999029;
									continue;
								case 1:
									return;
								default:
									CLjmYleEuCraJMMUJEFwtuAaGlg = FRUUibiOIWEsSCBxDuohaLtzlQrt[makeqSfOesOCmoTnKnppZmDJCnQg];
									return;
								}
								break;
							}
						}
					}
				}

				public LWgHqlaWkDRUSPCbYTLNtoXMEFNb(UpdateLoopSetting updateLoopSetting)
				{
					pumYaSKRNdhQZVERULkMvjtJiLd = new int[3];
					nsWutdErdifWgaZvHrHEdIZzXOLj = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
						for (int i = 0; i < list.Count; i++)
						{
							pumYaSKRNdhQZVERULkMvjtJiLd[(int)list[i]] = nsWutdErdifWgaZvHrHEdIZzXOLj;
							nsWutdErdifWgaZvHrHEdIZzXOLj++;
						}
					}
					FRUUibiOIWEsSCBxDuohaLtzlQrt = new AkJWPtezDxoVOETxbmPBqsqmXup[nsWutdErdifWgaZvHrHEdIZzXOLj];
					rVTcHBaKtmcEYURuwYUwPvCziDib = new ReadOnlyCollection<AkJWPtezDxoVOETxbmPBqsqmXup>(FRUUibiOIWEsSCBxDuohaLtzlQrt);
				}

				public void xaGVjRxEvIdELjjBskoGFDUNmrm()
				{
					int num = 0;
					while (true)
					{
						int num2 = -2102264220;
						while (true)
						{
							switch (num2 ^ -2102264219)
							{
							case 0:
								break;
							case 1:
								num2 = -2102264217;
								continue;
							case 3:
								FRUUibiOIWEsSCBxDuohaLtzlQrt[num].Reset();
								num++;
								num2 = -2102264217;
								continue;
							default:
								if (num >= nsWutdErdifWgaZvHrHEdIZzXOLj)
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

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal LWgHqlaWkDRUSPCbYTLNtoXMEFNb ymCfoifdeUyDhcWQqikzeIdbpAXc;

			internal int LkBXRcIRlxgWrwXtVCVKVjnvYjI;

			internal Controller ktnvQXcbwjTTWobUkcIrbxSoyaKH;

			internal readonly int SsPwhbdijXONOlkRKHOkXryZrDq;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = ktnvQXcbwjTTWobUkcIrbxSoyaKH.GetElementIdentifierById(id);
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
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						while (true)
						{
							int num = 885893700;
							while (true)
							{
								switch (num ^ 0x34CDAA45)
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
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = 885893701;
							}
						}
					}
					return LkBXRcIRlxgWrwXtVCVKVjnvYjI > 0;
				}
			}

			internal Element(Controller controller, int elementIdentifierId, string name, ControllerElementType type)
			{
				while (true)
				{
					int num = 1311015451;
					while (true)
					{
						switch (num ^ 0x4E24821A)
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
						ktnvQXcbwjTTWobUkcIrbxSoyaKH = controller;
						id = elementIdentifierId;
						this.name = name;
						this.type = type;
						SsPwhbdijXONOlkRKHOkXryZrDq = ReInput.id;
						num = 1311015448;
					}
				}
			}

			public void Reset()
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					goto IL_000d;
				}
				goto IL_0043;
				IL_000d:
				int num = -26222735;
				goto IL_0012;
				IL_0012:
				switch (num ^ -26222736)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return;
				case 2:
					goto IL_0043;
				case 3:
					return;
				}
				goto IL_000d;
				IL_0043:
				if (ymCfoifdeUyDhcWQqikzeIdbpAXc != null)
				{
					ymCfoifdeUyDhcWQqikzeIdbpAXc.xaGVjRxEvIdELjjBskoGFDUNmrm();
					num = -26222733;
					goto IL_0012;
				}
			}

			internal void gcciRSIxpDwLjGkouBFeDNpLpQY()
			{
				if (LkBXRcIRlxgWrwXtVCVKVjnvYjI > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
					goto IL_0013;
				}
				goto IL_0031;
				IL_0031:
				LkBXRcIRlxgWrwXtVCVKVjnvYjI++;
				int num = 909788548;
				goto IL_0018;
				IL_0013:
				num = 909788551;
				goto IL_0018;
				IL_0018:
				switch (num ^ 0x363A4585)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_0031;
				case 1:
					return;
				}
				goto IL_0013;
			}

			internal void JlMseDESQvijkLYzzQbvcjipwAB()
			{
				if (LkBXRcIRlxgWrwXtVCVKVjnvYjI == 0)
				{
					while (true)
					{
						int num = 1321210528;
						while (true)
						{
							switch (num ^ 0x4EC012A2)
							{
							case 0:
								break;
							case 2:
								Logger.LogWarning("This element is not a member of a compound element!");
								LkBXRcIRlxgWrwXtVCVKVjnvYjI = 0;
								num = 1321210529;
								continue;
							case 3:
								return;
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
				LkBXRcIRlxgWrwXtVCVKVjnvYjI--;
			}
		}

		public sealed class Axis : Element
		{
			internal class ODkGxseWnLnaAFrEwdnwezdcwby : LWgHqlaWkDRUSPCbYTLNtoXMEFNb
			{
				public class uNTGNBtDuIsMmWMeEYBCvGpxKkk : AkJWPtezDxoVOETxbmPBqsqmXup
				{
					private const float noEpMrKxdLwateyHicEjCHNvDzw = 0.001f;

					public float kXoKOSZJMKwATOiGMaylYIDqdDnb;

					public float qYsbSrCgieDFdjjrfHIxGCNHzNWl;

					public float mDMVGKJXAnvguYnERHrPkHjRjIY;

					public float LdJUhMHGAOiKghsgowHIOfFqFjV;

					public float LSltDORHOCLVIQjbdmagPREOxbR;

					public float ggMGLoEhYBkkDAhPEtsaXseARXUt;

					public float HMioQtKzbsteMdtqpnxHVQDVVYf;

					public float faWUSrogztaeTccvjhVxdmqKqJVD;

					public float yNqQNgIBKiYDgKgOdKgIWbwgMDe;

					public float krrAXgflNKZbFpEBMMzRToqasJgc;

					public float PPfpdHuGygYLotyGQNqejPefGaiF;

					public float DErjEZPuVnXrWSiZsGNcCngHaXU;

					public float timeActive
					{
						get
						{
							if (kXoKOSZJMKwATOiGMaylYIDqdDnb == 0f)
							{
								return 0f;
							}
							return ReInput.unscaledTime - yNqQNgIBKiYDgKgOdKgIWbwgMDe;
						}
					}

					public float timeActiveRaw
					{
						get
						{
							if (mDMVGKJXAnvguYnERHrPkHjRjIY == 0f)
							{
								return 0f;
							}
							return ReInput.unscaledTime - krrAXgflNKZbFpEBMMzRToqasJgc;
						}
					}

					public float timeInactive
					{
						get
						{
							if (kXoKOSZJMKwATOiGMaylYIDqdDnb != 0f)
							{
								return 0f;
							}
							return ReInput.unscaledTime - HMioQtKzbsteMdtqpnxHVQDVVYf;
						}
					}

					public float timeInactiveRaw
					{
						get
						{
							if (mDMVGKJXAnvguYnERHrPkHjRjIY != 0f)
							{
								return 0f;
							}
							return ReInput.unscaledTime - faWUSrogztaeTccvjhVxdmqKqJVD;
						}
					}

					public void rdEJYvExbWYUXSDuseVgzyXPBhA(bool P_0)
					{
						float unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (!MathTools.Approximately(LSltDORHOCLVIQjbdmagPREOxbR, 0f))
							{
								goto IL_001e;
							}
							goto IL_0067;
						}
						goto IL_0141;
						IL_0141:
						int num;
						if (!MathTools.Approximately(kXoKOSZJMKwATOiGMaylYIDqdDnb, 0f))
						{
							HMioQtKzbsteMdtqpnxHVQDVVYf = unscaledTime;
							num = -1780465240;
							goto IL_0023;
						}
						goto IL_0075;
						IL_001e:
						num = -1780465233;
						goto IL_0023;
						IL_0023:
						while (true)
						{
							switch (num ^ -1780465236)
							{
							case 9:
								break;
							default:
								return;
							case 6:
								goto IL_0067;
							case 10:
								goto IL_0075;
							case 4:
								if (!MathTools.IsNear(kXoKOSZJMKwATOiGMaylYIDqdDnb, qYsbSrCgieDFdjjrfHIxGCNHzNWl, 0.001f))
								{
									PPfpdHuGygYLotyGQNqejPefGaiF = unscaledTime;
									num = -1780465234;
									continue;
								}
								goto IL_0167;
							case 0:
								if (!MathTools.IsNear(LSltDORHOCLVIQjbdmagPREOxbR, ggMGLoEhYBkkDAhPEtsaXseARXUt, 0.001f))
								{
									PPfpdHuGygYLotyGQNqejPefGaiF = unscaledTime;
									num = -1780465234;
									continue;
								}
								goto IL_0167;
							case 8:
								faWUSrogztaeTccvjhVxdmqKqJVD = unscaledTime;
								num = -1780465248;
								continue;
							case 7:
								num = -1780465236;
								continue;
							case 12:
								if (!MathTools.IsNear(mDMVGKJXAnvguYnERHrPkHjRjIY, LdJUhMHGAOiKghsgowHIOfFqFjV, 0.001f))
								{
									DErjEZPuVnXrWSiZsGNcCngHaXU = unscaledTime;
									num = -1780465239;
									continue;
								}
								return;
							case 11:
								krrAXgflNKZbFpEBMMzRToqasJgc = unscaledTime;
								num = -1780465248;
								continue;
							case 3:
								HMioQtKzbsteMdtqpnxHVQDVVYf = unscaledTime;
								num = -1780465237;
								continue;
							case 1:
								goto IL_0141;
							case 2:
								goto IL_0167;
							case 5:
								return;
							}
							break;
							IL_0167:
							int num2;
							if (MathTools.Approximately(mDMVGKJXAnvguYnERHrPkHjRjIY, 0f))
							{
								num = -1780465241;
								num2 = num;
							}
							else
							{
								num = -1780465244;
								num2 = num;
							}
						}
						goto IL_001e;
						IL_0067:
						yNqQNgIBKiYDgKgOdKgIWbwgMDe = unscaledTime;
						num = -1780465236;
						goto IL_0023;
						IL_0075:
						yNqQNgIBKiYDgKgOdKgIWbwgMDe = unscaledTime;
						num = -1780465240;
						goto IL_0023;
					}

					public void FfgPwTULIHtRztHdkEZAdLKaQZMw(float P_0)
					{
						if (LdJUhMHGAOiKghsgowHIOfFqFjV != mDMVGKJXAnvguYnERHrPkHjRjIY)
						{
							LdJUhMHGAOiKghsgowHIOfFqFjV = mDMVGKJXAnvguYnERHrPkHjRjIY;
							goto IL_001a;
						}
						goto IL_0038;
						IL_0038:
						int num;
						if (mDMVGKJXAnvguYnERHrPkHjRjIY != P_0)
						{
							mDMVGKJXAnvguYnERHrPkHjRjIY = P_0;
							num = -1627876159;
							goto IL_001f;
						}
						return;
						IL_001a:
						num = -1627876160;
						goto IL_001f;
						IL_001f:
						switch (num ^ -1627876159)
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
						kXoKOSZJMKwATOiGMaylYIDqdDnb = 0f;
						qYsbSrCgieDFdjjrfHIxGCNHzNWl = 0f;
						mDMVGKJXAnvguYnERHrPkHjRjIY = 0f;
						LdJUhMHGAOiKghsgowHIOfFqFjV = 0f;
						HMioQtKzbsteMdtqpnxHVQDVVYf = 0f;
						faWUSrogztaeTccvjhVxdmqKqJVD = 0f;
						yNqQNgIBKiYDgKgOdKgIWbwgMDe = 0f;
						krrAXgflNKZbFpEBMMzRToqasJgc = 0f;
						PPfpdHuGygYLotyGQNqejPefGaiF = 0f;
						DErjEZPuVnXrWSiZsGNcCngHaXU = 0f;
					}
				}

				public ODkGxseWnLnaAFrEwdnwezdcwby(UpdateLoopSetting updateCycle)
					: base(updateCycle)
				{
					for (int i = 0; i < nsWutdErdifWgaZvHrHEdIZzXOLj; i++)
					{
						FRUUibiOIWEsSCBxDuohaLtzlQrt[i] = new uNTGNBtDuIsMmWMeEYBCvGpxKkk();
					}
					CLjmYleEuCraJMMUJEFwtuAaGlg = FRUUibiOIWEsSCBxDuohaLtzlQrt[0];
				}
			}

			internal readonly AxisRange lJhAAZrcOVxFKosTPucBYftpxhk;

			internal readonly HardwareAxisInfo UelUYluZSYxsmPMMGpbRwJNlVXq;

			public float value
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).LSltDORHOCLVIQjbdmagPREOxbR;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).kXoKOSZJMKwATOiGMaylYIDqdDnb;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).ggMGLoEhYBkkDAhPEtsaXseARXUt;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qYsbSrCgieDFdjjrfHIxGCNHzNWl;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).mDMVGKJXAnvguYnERHrPkHjRjIY;
				}
				internal set
				{
					((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).FfgPwTULIHtRztHdkEZAdLKaQZMw(value);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).LdJUhMHGAOiKghsgowHIOfFqFjV;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).mDMVGKJXAnvguYnERHrPkHjRjIY - ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).LdJUhMHGAOiKghsgowHIOfFqFjV;
				}
			}

			public float lastTimeActive
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).HMioQtKzbsteMdtqpnxHVQDVVYf;
				}
			}

			public float lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).faWUSrogztaeTccvjhVxdmqKqJVD;
				}
			}

			public float lastTimeInactive
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).yNqQNgIBKiYDgKgOdKgIWbwgMDe;
				}
			}

			public float lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).krrAXgflNKZbFpEBMMzRToqasJgc;
				}
			}

			public float lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).PPfpdHuGygYLotyGQNqejPefGaiF;
				}
			}

			public float lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).DErjEZPuVnXrWSiZsGNcCngHaXU;
				}
			}

			public float timeActive
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).timeActive;
				}
			}

			public float timeActiveRaw
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).timeActive;
				}
			}

			public float timeInactive
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).timeInactive;
				}
			}

			public float timeInactiveRaw
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).timeInactiveRaw;
				}
			}

			internal float selfValue
			{
				get
				{
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).kXoKOSZJMKwATOiGMaylYIDqdDnb;
				}
			}

			internal float selfValuePrev
			{
				get
				{
					return ((ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qYsbSrCgieDFdjjrfHIxGCNHzNWl;
				}
			}

			internal void jJUwwohbhtCrPdKyxizhoTKjWBh(float P_0)
			{
				ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk uNTGNBtDuIsMmWMeEYBCvGpxKkk = (ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg;
				uNTGNBtDuIsMmWMeEYBCvGpxKkk.ggMGLoEhYBkkDAhPEtsaXseARXUt = uNTGNBtDuIsMmWMeEYBCvGpxKkk.LSltDORHOCLVIQjbdmagPREOxbR;
				uNTGNBtDuIsMmWMeEYBCvGpxKkk.LSltDORHOCLVIQjbdmagPREOxbR = P_0;
			}

			internal Axis(Controller controller, int elementIdentifierId, string name, AxisRange axisRange, HardwareAxisInfo axisInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Axis)
			{
				ymCfoifdeUyDhcWQqikzeIdbpAXc = new ODkGxseWnLnaAFrEwdnwezdcwby(ReInput.configVars.updateLoop);
				lJhAAZrcOVxFKosTPucBYftpxhk = axisRange;
				UelUYluZSYxsmPMMGpbRwJNlVXq = axisInfo;
			}

			internal void QCXpjnNrqQpxzhFzcjDxhVFbcDO(UpdateLoopType P_0)
			{
				if (ymCfoifdeUyDhcWQqikzeIdbpAXc == null)
				{
					return;
				}
				while (true)
				{
					int num = 1815032178;
					while (true)
					{
						switch (num ^ 0x6C2F3170)
						{
						case 3:
							break;
						default:
							return;
						case 2:
						{
							int num2;
							if (ymCfoifdeUyDhcWQqikzeIdbpAXc.sWXAmbipLtAbjKNEztzXOrpNGHPi != (int)P_0)
							{
								num = 1815032177;
								num2 = num;
							}
							else
							{
								num = 1815032176;
								num2 = num;
							}
							continue;
						}
						case 1:
							ymCfoifdeUyDhcWQqikzeIdbpAXc.updateLoop = P_0;
							num = 1815032176;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
			}

			internal void pyoNZCTmUpoHfPgFCGCNvPXqorL(AxisCalibration P_0)
			{
				ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk uNTGNBtDuIsMmWMeEYBCvGpxKkk = (ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg;
				uNTGNBtDuIsMmWMeEYBCvGpxKkk.qYsbSrCgieDFdjjrfHIxGCNHzNWl = uNTGNBtDuIsMmWMeEYBCvGpxKkk.kXoKOSZJMKwATOiGMaylYIDqdDnb;
				float kXoKOSZJMKwATOiGMaylYIDqdDnb = default(float);
				while (true)
				{
					int num = -829474802;
					while (true)
					{
						switch (num ^ -829474803)
						{
						case 0:
							break;
						case 3:
							kXoKOSZJMKwATOiGMaylYIDqdDnb = P_0.GetCalibratedValue(uNTGNBtDuIsMmWMeEYBCvGpxKkk.mDMVGKJXAnvguYnERHrPkHjRjIY, lJhAAZrcOVxFKosTPucBYftpxhk);
							num = -829474801;
							continue;
						case 2:
							if (P_0.applyRangeCalibration)
							{
								kXoKOSZJMKwATOiGMaylYIDqdDnb = MathTools.Clamp(kXoKOSZJMKwATOiGMaylYIDqdDnb, -1f, 1f);
								num = -829474804;
								continue;
							}
							goto default;
						default:
							uNTGNBtDuIsMmWMeEYBCvGpxKkk.kXoKOSZJMKwATOiGMaylYIDqdDnb = kXoKOSZJMKwATOiGMaylYIDqdDnb;
							return;
						}
						break;
					}
				}
			}

			internal void pyoNZCTmUpoHfPgFCGCNvPXqorL()
			{
				ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk uNTGNBtDuIsMmWMeEYBCvGpxKkk = (ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg;
				while (true)
				{
					int num = 181203731;
					while (true)
					{
						switch (num ^ 0xACCF311)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_002f;
						case 1:
							return;
						}
						break;
						IL_002f:
						uNTGNBtDuIsMmWMeEYBCvGpxKkk.qYsbSrCgieDFdjjrfHIxGCNHzNWl = uNTGNBtDuIsMmWMeEYBCvGpxKkk.kXoKOSZJMKwATOiGMaylYIDqdDnb;
						uNTGNBtDuIsMmWMeEYBCvGpxKkk.kXoKOSZJMKwATOiGMaylYIDqdDnb = uNTGNBtDuIsMmWMeEYBCvGpxKkk.mDMVGKJXAnvguYnERHrPkHjRjIY;
						num = 181203728;
					}
				}
			}

			internal void OOluiwLxtzwxTTaxHfhTuqhQzWo()
			{
				ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk uNTGNBtDuIsMmWMeEYBCvGpxKkk = (ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg;
				uNTGNBtDuIsMmWMeEYBCvGpxKkk.qYsbSrCgieDFdjjrfHIxGCNHzNWl = uNTGNBtDuIsMmWMeEYBCvGpxKkk.kXoKOSZJMKwATOiGMaylYIDqdDnb;
				uNTGNBtDuIsMmWMeEYBCvGpxKkk.kXoKOSZJMKwATOiGMaylYIDqdDnb = 0f;
			}

			internal void IYHCOBrIiBubJZntUIWQrBQzmNt()
			{
				ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk uNTGNBtDuIsMmWMeEYBCvGpxKkk = (ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg;
				uNTGNBtDuIsMmWMeEYBCvGpxKkk.rdEJYvExbWYUXSDuseVgzyXPBhA(base.isMemberElement);
			}

			internal void ujtADEFeYOCDySaizKOYdeYkatrw(float P_0)
			{
				int num = 0;
				ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk uNTGNBtDuIsMmWMeEYBCvGpxKkk = default(ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk);
				while (true)
				{
					int num2;
					int num3;
					if (num >= ymCfoifdeUyDhcWQqikzeIdbpAXc.Data.Count)
					{
						num2 = 1836246824;
						num3 = num2;
					}
					else
					{
						num2 = 1836246828;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x6D72E729)
						{
						case 0:
							num2 = 1836246828;
							continue;
						default:
							return;
						case 2:
							num++;
							num2 = 1836246829;
							continue;
						case 3:
							uNTGNBtDuIsMmWMeEYBCvGpxKkk.FfgPwTULIHtRztHdkEZAdLKaQZMw(P_0);
							uNTGNBtDuIsMmWMeEYBCvGpxKkk.qYsbSrCgieDFdjjrfHIxGCNHzNWl = uNTGNBtDuIsMmWMeEYBCvGpxKkk.kXoKOSZJMKwATOiGMaylYIDqdDnb;
							uNTGNBtDuIsMmWMeEYBCvGpxKkk.kXoKOSZJMKwATOiGMaylYIDqdDnb = 0f;
							uNTGNBtDuIsMmWMeEYBCvGpxKkk.rdEJYvExbWYUXSDuseVgzyXPBhA(base.isMemberElement);
							num2 = 1836246827;
							continue;
						case 5:
						{
							uNTGNBtDuIsMmWMeEYBCvGpxKkk = ymCfoifdeUyDhcWQqikzeIdbpAXc.Data[num] as ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk;
							int num4;
							if (uNTGNBtDuIsMmWMeEYBCvGpxKkk == null)
							{
								num2 = 1836246827;
								num4 = num2;
							}
							else
							{
								num2 = 1836246826;
								num4 = num2;
							}
							continue;
						}
						case 4:
							break;
						case 1:
							return;
						}
						break;
					}
				}
			}

			internal float rUZPcTKJtxFtMbYehGtMPSgPeVXQ(UpdateLoopType P_0, AxisCalibration P_1)
			{
				ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk uNTGNBtDuIsMmWMeEYBCvGpxKkk = (ODkGxseWnLnaAFrEwdnwezdcwby.uNTGNBtDuIsMmWMeEYBCvGpxKkk)ymCfoifdeUyDhcWQqikzeIdbpAXc.Data[(int)P_0];
				float result = P_1.GetCalibratedValue(uNTGNBtDuIsMmWMeEYBCvGpxKkk.mDMVGKJXAnvguYnERHrPkHjRjIY, lJhAAZrcOVxFKosTPucBYftpxhk, P_1.deadZone, false, true);
				if (P_1.applyRangeCalibration)
				{
					while (true)
					{
						int num = -857937836;
						while (true)
						{
							switch (num ^ -857937835)
							{
							case 2:
								break;
							case 1:
								result = MathTools.Clamp(result, -1f, 1f);
								num = -857937835;
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
			internal class HZbwvqArPLinzdGVOnUQuyplJJg : LWgHqlaWkDRUSPCbYTLNtoXMEFNb
			{
				public class ybWiJMuSrLBuWEmcaZMfvLflFvBT : AkJWPtezDxoVOETxbmPBqsqmXup
				{
					public bool kXoKOSZJMKwATOiGMaylYIDqdDnb;

					public bool qYsbSrCgieDFdjjrfHIxGCNHzNWl;

					public ButtonStateRecorder qsooKLtuRdGRggdgcPulPISDtf;

					public GVJXhisvcOYMeSAQXDzfXmDefQU bAsoomBpOrBUdLtGFrvYLwzEQbb;

					public ybWiJMuSrLBuWEmcaZMfvLflFvBT()
					{
						while (true)
						{
							int num = -1387110506;
							while (true)
							{
								switch (num ^ -1387110505)
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
								qsooKLtuRdGRggdgcPulPISDtf = new ButtonStateRecorder();
								bAsoomBpOrBUdLtGFrvYLwzEQbb = new GVJXhisvcOYMeSAQXDzfXmDefQU(0.3f);
								num = -1387110507;
							}
						}
					}

					public void zxLhCcrlwKIIJANOaByFjYpjSot(bool P_0)
					{
						if (qYsbSrCgieDFdjjrfHIxGCNHzNWl != kXoKOSZJMKwATOiGMaylYIDqdDnb)
						{
							qYsbSrCgieDFdjjrfHIxGCNHzNWl = kXoKOSZJMKwATOiGMaylYIDqdDnb;
							goto IL_001a;
						}
						goto IL_003c;
						IL_0053:
						qsooKLtuRdGRggdgcPulPISDtf.rdEJYvExbWYUXSDuseVgzyXPBhA(P_0 && !qYsbSrCgieDFdjjrfHIxGCNHzNWl, P_0, ReInput.unscaledTime);
						int num = -639063395;
						goto IL_001f;
						IL_001a:
						num = -639063393;
						goto IL_001f;
						IL_001f:
						switch (num ^ -639063394)
						{
						case 2:
							break;
						case 1:
							goto IL_003c;
						case 0:
							goto IL_0053;
						default:
							bAsoomBpOrBUdLtGFrvYLwzEQbb.rdEJYvExbWYUXSDuseVgzyXPBhA(0.3f, P_0 && !qYsbSrCgieDFdjjrfHIxGCNHzNWl, P_0);
							return;
						}
						goto IL_001a;
						IL_003c:
						if (kXoKOSZJMKwATOiGMaylYIDqdDnb != P_0)
						{
							kXoKOSZJMKwATOiGMaylYIDqdDnb = P_0;
							num = -639063394;
							goto IL_001f;
						}
						goto IL_0053;
					}

					public override void Reset()
					{
						kXoKOSZJMKwATOiGMaylYIDqdDnb = false;
						qYsbSrCgieDFdjjrfHIxGCNHzNWl = false;
						while (true)
						{
							int num = -1937262214;
							while (true)
							{
								switch (num ^ -1937262213)
								{
								case 2:
									break;
								case 1:
									goto IL_002c;
								default:
									bAsoomBpOrBUdLtGFrvYLwzEQbb.xaGVjRxEvIdELjjBskoGFDUNmrm();
									return;
								}
								break;
								IL_002c:
								qsooKLtuRdGRggdgcPulPISDtf.xaGVjRxEvIdELjjBskoGFDUNmrm();
								num = -1937262213;
							}
						}
					}
				}

				public class peeglHKOFnoirHjPDjGApIuUoyPH : ybWiJMuSrLBuWEmcaZMfvLflFvBT
				{
					public float HgOnEvYyzoHzDEPVwvnsyujPMyC;

					public float gqBgrWblzAETdzbdpDKIPttMszka;

					public void zxLhCcrlwKIIJANOaByFjYpjSot(float P_0)
					{
						if (gqBgrWblzAETdzbdpDKIPttMszka != HgOnEvYyzoHzDEPVwvnsyujPMyC)
						{
							gqBgrWblzAETdzbdpDKIPttMszka = HgOnEvYyzoHzDEPVwvnsyujPMyC;
							goto IL_001a;
						}
						goto IL_0038;
						IL_005e:
						zxLhCcrlwKIIJANOaByFjYpjSot((HgOnEvYyzoHzDEPVwvnsyujPMyC > 0f) ? true : false);
						return;
						IL_001a:
						int num = 1195209835;
						goto IL_001f;
						IL_001f:
						switch (num ^ 0x473D7469)
						{
						case 0:
							break;
						case 2:
							goto IL_0038;
						default:
							goto IL_005e;
						}
						goto IL_001a;
						IL_0038:
						if (HgOnEvYyzoHzDEPVwvnsyujPMyC != P_0)
						{
							HgOnEvYyzoHzDEPVwvnsyujPMyC = ((P_0 > 0.001f) ? P_0 : 0f);
							num = 1195209832;
							goto IL_001f;
						}
						goto IL_005e;
					}

					public override void Reset()
					{
						base.Reset();
						while (true)
						{
							int num = 390017658;
							while (true)
							{
								switch (num ^ 0x173F327B)
								{
								case 0:
									break;
								case 1:
									goto IL_0024;
								default:
									gqBgrWblzAETdzbdpDKIPttMszka = 0f;
									return;
								}
								break;
								IL_0024:
								HgOnEvYyzoHzDEPVwvnsyujPMyC = 0f;
								num = 390017657;
							}
						}
					}
				}

				public HZbwvqArPLinzdGVOnUQuyplJJg(UpdateLoopSetting updateCycle, bool isPressureSensitive)
					: base(updateCycle)
				{
					for (int i = 0; i < nsWutdErdifWgaZvHrHEdIZzXOLj; i++)
					{
						if (isPressureSensitive)
						{
							FRUUibiOIWEsSCBxDuohaLtzlQrt[i] = new peeglHKOFnoirHjPDjGApIuUoyPH();
						}
						else
						{
							FRUUibiOIWEsSCBxDuohaLtzlQrt[i] = new ybWiJMuSrLBuWEmcaZMfvLflFvBT();
						}
					}
					CLjmYleEuCraJMMUJEFwtuAaGlg = FRUUibiOIWEsSCBxDuohaLtzlQrt[0];
				}

				public void JbCLCezRVFaQmPOxTvXmSpSioYn(float P_0)
				{
					int num = 0;
					while (true)
					{
						int num2 = 1932777409;
						while (true)
						{
							switch (num2 ^ 0x7333D7C0)
							{
							case 0:
								break;
							case 1:
								num2 = 1932777410;
								continue;
							case 3:
								((ybWiJMuSrLBuWEmcaZMfvLflFvBT)FRUUibiOIWEsSCBxDuohaLtzlQrt[num]).bAsoomBpOrBUdLtGFrvYLwzEQbb.YXUiPbRSVeievBujbkGnJmFKcFNc(P_0);
								num++;
								num2 = 1932777410;
								continue;
							default:
								if (num >= FRUUibiOIWEsSCBxDuohaLtzlQrt.Length)
								{
									return;
								}
								goto case 3;
							}
							break;
						}
					}
				}

				public void rUNcPIBehcUTyUcZUXxoBugkjfq()
				{
					int num = 0;
					while (true)
					{
						int num2 = 1255211114;
						while (true)
						{
							switch (num2 ^ 0x4AD1006E)
							{
							case 2:
								break;
							default:
								return;
							case 0:
							{
								int num3;
								if (num < FRUUibiOIWEsSCBxDuohaLtzlQrt.Length)
								{
									num2 = 1255211117;
									num3 = num2;
								}
								else
								{
									num2 = 1255211119;
									num3 = num2;
								}
								continue;
							}
							case 3:
								((ybWiJMuSrLBuWEmcaZMfvLflFvBT)FRUUibiOIWEsSCBxDuohaLtzlQrt[num]).bAsoomBpOrBUdLtGFrvYLwzEQbb.YXUiPbRSVeievBujbkGnJmFKcFNc(0.3f);
								num++;
								num2 = 1255211118;
								continue;
							case 4:
								num2 = 1255211118;
								continue;
							case 1:
								return;
							}
							break;
						}
					}
				}
			}

			internal readonly bool pSQAxQmplxiUZUyeQhcyDLZUatX;

			internal readonly HardwareButtonInfo iuEuRSpYDgudIbTXYlbkEqHpalu;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qYsbSrCgieDFdjjrfHIxGCNHzNWl;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).kXoKOSZJMKwATOiGMaylYIDqdDnb;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					if (!pSQAxQmplxiUZUyeQhcyDLZUatX)
					{
						if (!((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).kXoKOSZJMKwATOiGMaylYIDqdDnb)
						{
							return 0f;
						}
						return 1f;
					}
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.peeglHKOFnoirHjPDjGApIuUoyPH)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).HgOnEvYyzoHzDEPVwvnsyujPMyC;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					if (!pSQAxQmplxiUZUyeQhcyDLZUatX)
					{
						if (!((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qYsbSrCgieDFdjjrfHIxGCNHzNWl)
						{
							return 0f;
						}
						return 1f;
					}
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.peeglHKOFnoirHjPDjGApIuUoyPH)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).gqBgrWblzAETdzbdpDKIPttMszka;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					return pSQAxQmplxiUZUyeQhcyDLZUatX;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					if (!((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qYsbSrCgieDFdjjrfHIxGCNHzNWl && ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).kXoKOSZJMKwATOiGMaylYIDqdDnb)
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
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						goto IL_000d;
					}
					int num;
					if (((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qYsbSrCgieDFdjjrfHIxGCNHzNWl && !((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).kXoKOSZJMKwATOiGMaylYIDqdDnb)
					{
						num = -529554743;
						goto IL_0012;
					}
					return false;
					IL_0012:
					switch (num ^ -529554744)
					{
					case 0:
						break;
					case 2:
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					default:
						return true;
					}
					goto IL_000d;
					IL_000d:
					num = -529554742;
					goto IL_0012;
				}
			}

			public bool justChangedState
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						goto IL_0019;
					}
					int num;
					if (((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qYsbSrCgieDFdjjrfHIxGCNHzNWl != ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).kXoKOSZJMKwATOiGMaylYIDqdDnb)
					{
						num = 994110216;
						goto IL_001e;
					}
					return false;
					IL_0019:
					num = 994110219;
					goto IL_001e;
					IL_001e:
					switch (num ^ 0x3B40EB0A)
					{
					case 0:
						break;
					case 1:
						return false;
					default:
						return true;
					}
					goto IL_0019;
				}
			}

			public bool doublePressedAndHeld
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).bAsoomBpOrBUdLtGFrvYLwzEQbb.doublePressHold;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).bAsoomBpOrBUdLtGFrvYLwzEQbb.doublePressHold;
				}
			}

			public float timePressed
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qsooKLtuRdGRggdgcPulPISDtf.timePressed;
				}
			}

			public float timeUnpressed
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qsooKLtuRdGRggdgcPulPISDtf.timeUnpressed;
				}
			}

			public float lastTimePressed
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qsooKLtuRdGRggdgcPulPISDtf.lastTimePressed;
				}
			}

			public float lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qsooKLtuRdGRggdgcPulPISDtf.lastTimeUnpressed;
				}
			}

			public float lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qsooKLtuRdGRggdgcPulPISDtf.lastTimeStateChanged;
				}
			}

			internal ButtonStateFlags state
			{
				get
				{
					HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT ybWiJMuSrLBuWEmcaZMfvLflFvBT = (HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr;
					if (ybWiJMuSrLBuWEmcaZMfvLflFvBT.kXoKOSZJMKwATOiGMaylYIDqdDnb)
					{
						goto IL_001d;
					}
					goto IL_006f;
					IL_001d:
					int num = 456733639;
					goto IL_0022;
					IL_0022:
					while (true)
					{
						switch (num ^ 0x1B3933C6)
						{
						case 4:
							break;
						case 1:
							goto IL_0047;
						case 0:
							buttonStateFlags |= ButtonStateFlags.VlhlJSuMVXjhWdLiRItrzCZLEub;
							num = 456733637;
							continue;
						case 5:
							goto IL_006f;
						case 2:
							buttonStateFlags |= ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY;
							num = 456733637;
							continue;
						default:
							return buttonStateFlags;
						}
						break;
						IL_0047:
						buttonStateFlags |= ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy;
						int num2;
						if (!ybWiJMuSrLBuWEmcaZMfvLflFvBT.qYsbSrCgieDFdjjrfHIxGCNHzNWl)
						{
							num = 456733636;
							num2 = num;
						}
						else
						{
							num = 456733637;
							num2 = num;
						}
					}
					goto IL_001d;
					IL_006f:
					int num3;
					if (!ybWiJMuSrLBuWEmcaZMfvLflFvBT.qYsbSrCgieDFdjjrfHIxGCNHzNWl)
					{
						num = 456733637;
						num3 = num;
					}
					else
					{
						num = 456733638;
						num3 = num;
					}
					goto IL_0022;
				}
			}

			internal Button(Controller controller, int elementIdentifierId, string name, HardwareButtonInfo buttonInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Button)
			{
				iuEuRSpYDgudIbTXYlbkEqHpalu = buttonInfo;
				ymCfoifdeUyDhcWQqikzeIdbpAXc = new HZbwvqArPLinzdGVOnUQuyplJJg(ReInput.configVars.updateLoop, false);
			}

			internal Button(Controller controller, int elementIdentifierId, string name, bool isPressureSensitive, HardwareButtonInfo buttonInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Button)
			{
				iuEuRSpYDgudIbTXYlbkEqHpalu = buttonInfo;
				pSQAxQmplxiUZUyeQhcyDLZUatX = isPressureSensitive;
				ymCfoifdeUyDhcWQqikzeIdbpAXc = new HZbwvqArPLinzdGVOnUQuyplJJg(ReInput.configVars.updateLoop, isPressureSensitive);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return false;
				}
				if (speed <= 0f)
				{
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).bAsoomBpOrBUdLtGFrvYLwzEQbb.doublePressHold;
				}
				return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qsooKLtuRdGRggdgcPulPISDtf.dtHhNkdqjhiCGFdjTZiGIeVyhiqE(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).bAsoomBpOrBUdLtGFrvYLwzEQbb.doublePressHold;
				}
				return ((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).qsooKLtuRdGRggdgcPulPISDtf.dtHhNkdqjhiCGFdjTZiGIeVyhiqE(speed);
			}

			internal void zxLhCcrlwKIIJANOaByFjYpjSot(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (ymCfoifdeUyDhcWQqikzeIdbpAXc != null)
				{
					while (true)
					{
						int num = -561058753;
						while (true)
						{
							switch (num ^ -561058754)
							{
							case 2:
								break;
							case 1:
								goto IL_002e;
							case 4:
								ymCfoifdeUyDhcWQqikzeIdbpAXc.updateLoop = P_0;
								num = -561058755;
								continue;
							case 3:
								goto end_IL_0008;
							default:
								goto IL_008d;
							}
							break;
							IL_002e:
							int num2;
							if (ymCfoifdeUyDhcWQqikzeIdbpAXc.sWXAmbipLtAbjKNEztzXOrpNGHPi != (int)P_0)
							{
								num = -561058758;
								num2 = num;
							}
							else
							{
								num = -561058755;
								num2 = num;
							}
						}
						continue;
						end_IL_0008:
						break;
					}
				}
				if (pSQAxQmplxiUZUyeQhcyDLZUatX)
				{
					((HZbwvqArPLinzdGVOnUQuyplJJg.peeglHKOFnoirHjPDjGApIuUoyPH)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).zxLhCcrlwKIIJANOaByFjYpjSot(P_2.buttonPressureValues[P_1]);
					return;
				}
				goto IL_008d;
				IL_008d:
				((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).zxLhCcrlwKIIJANOaByFjYpjSot(P_2.buttonValues[P_1]);
			}

			internal void ipxYYWTdpzFeXmeGFdTqkEYPkJxg(UpdateLoopType P_0)
			{
				if (ymCfoifdeUyDhcWQqikzeIdbpAXc != null && ymCfoifdeUyDhcWQqikzeIdbpAXc.sWXAmbipLtAbjKNEztzXOrpNGHPi != (int)P_0)
				{
					while (true)
					{
						int num = -908301789;
						while (true)
						{
							switch (num ^ -908301791)
							{
							case 0:
								break;
							case 2:
								ymCfoifdeUyDhcWQqikzeIdbpAXc.updateLoop = P_0;
								num = -908301790;
								continue;
							case 3:
								goto end_IL_0016;
							default:
								goto IL_0075;
							}
							break;
						}
						continue;
						end_IL_0016:
						break;
					}
				}
				if (pSQAxQmplxiUZUyeQhcyDLZUatX)
				{
					((HZbwvqArPLinzdGVOnUQuyplJJg.peeglHKOFnoirHjPDjGApIuUoyPH)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).zxLhCcrlwKIIJANOaByFjYpjSot(0f);
					return;
				}
				goto IL_0075;
				IL_0075:
				((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)ymCfoifdeUyDhcWQqikzeIdbpAXc.CLjmYleEuCraJMMUJEFwtuAaGlg).zxLhCcrlwKIIJANOaByFjYpjSot(false);
			}

			internal void ujtADEFeYOCDySaizKOYdeYkatrw()
			{
				int num = 0;
				while (num < ymCfoifdeUyDhcWQqikzeIdbpAXc.Data.Count)
				{
					while (true)
					{
						LWgHqlaWkDRUSPCbYTLNtoXMEFNb.AkJWPtezDxoVOETxbmPBqsqmXup akJWPtezDxoVOETxbmPBqsqmXup = ymCfoifdeUyDhcWQqikzeIdbpAXc.Data[num];
						int num2;
						int num3;
						if (akJWPtezDxoVOETxbmPBqsqmXup == null)
						{
							num2 = 130162341;
							num3 = num2;
						}
						else
						{
							num2 = 130162338;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x7C21EA6)
							{
							case 5:
								num2 = 130162343;
								continue;
							case 3:
								num++;
								num2 = 130162336;
								continue;
							case 4:
								break;
							case 0:
								((HZbwvqArPLinzdGVOnUQuyplJJg.peeglHKOFnoirHjPDjGApIuUoyPH)akJWPtezDxoVOETxbmPBqsqmXup).zxLhCcrlwKIIJANOaByFjYpjSot(0f);
								num2 = 130162341;
								continue;
							case 1:
								goto end_IL_000c;
							case 2:
								((HZbwvqArPLinzdGVOnUQuyplJJg.ybWiJMuSrLBuWEmcaZMfvLflFvBT)akJWPtezDxoVOETxbmPBqsqmXup).zxLhCcrlwKIIJANOaByFjYpjSot(false);
								num2 = 130162341;
								continue;
							default:
								goto end_IL_0070;
							}
							int num4;
							if (pSQAxQmplxiUZUyeQhcyDLZUatX)
							{
								num2 = 130162342;
								num4 = num2;
							}
							else
							{
								num2 = 130162340;
								num4 = num2;
							}
							continue;
							end_IL_000c:
							break;
						}
						continue;
						end_IL_0070:
						break;
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class UACTYqLbyuHWcCCfydXTtkvOSks
			{
				public readonly Element KspObDEVwZbsUrQZILSLveBSzec;

				public readonly int jAvNNxyuqvKzUHXitHlYMMTfSEE;

				public UACTYqLbyuHWcCCfydXTtkvOSks(Element element, int elementIndex)
				{
					while (true)
					{
						int num = -755837757;
						while (true)
						{
							switch (num ^ -755837758)
							{
							case 2:
								break;
							case 1:
								goto IL_0024;
							default:
								jAvNNxyuqvKzUHXitHlYMMTfSEE = elementIndex;
								return;
							}
							break;
							IL_0024:
							KspObDEVwZbsUrQZILSLveBSzec = element;
							num = -755837758;
						}
					}
				}
			}

			private int TZSPqisJATrQkFfRXLKedgRIcwv;

			private string jMnuxDpeLQhKgkpKQOlnqChJgyRd;

			private CompoundControllerElementType JNNGbJEWijctWBKzGmlLLQzaVVsi;

			private int xhRrSOnlgQeoHZxBkNsViMILhJHe;

			private UACTYqLbyuHWcCCfydXTtkvOSks[] eijOwZbpeptWbZzpnQOEBtAEzoE;

			private Controller ktnvQXcbwjTTWobUkcIrbxSoyaKH;

			internal readonly int SsPwhbdijXONOlkRKHOkXryZrDq;

			public int id
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return -1;
					}
					return TZSPqisJATrQkFfRXLKedgRIcwv;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return string.Empty;
					}
					return jMnuxDpeLQhKgkpKQOlnqChJgyRd;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return CompoundControllerElementType.Axis2D;
					}
					return JNNGbJEWijctWBKzGmlLLQzaVVsi;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					return xhRrSOnlgQeoHZxBkNsViMILhJHe > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0;
					}
					return xhRrSOnlgQeoHZxBkNsViMILhJHe;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						goto IL_0019;
					}
					ControllerElementIdentifier elementIdentifierById = ktnvQXcbwjTTWobUkcIrbxSoyaKH.GetElementIdentifierById(TZSPqisJATrQkFfRXLKedgRIcwv);
					int num;
					if (elementIdentifierById == null)
					{
						num = -374521217;
						goto IL_001e;
					}
					return elementIdentifierById;
					IL_0019:
					num = -374521218;
					goto IL_001e;
					IL_001e:
					switch (num ^ -374521217)
					{
					case 2:
						break;
					case 1:
						return null;
					default:
						return ControllerElementIdentifier.BlankReadOnly;
					}
					goto IL_0019;
				}
			}

			internal CompoundElement(Controller controller, int elementIdentifierId, string name, CompoundControllerElementType type)
			{
				ktnvQXcbwjTTWobUkcIrbxSoyaKH = controller;
				TZSPqisJATrQkFfRXLKedgRIcwv = elementIdentifierId;
				jMnuxDpeLQhKgkpKQOlnqChJgyRd = name;
				JNNGbJEWijctWBKzGmlLLQzaVVsi = type;
				eijOwZbpeptWbZzpnQOEBtAEzoE = new UACTYqLbyuHWcCCfydXTtkvOSks[elementCapacity];
				SsPwhbdijXONOlkRKHOkXryZrDq = ReInput.id;
			}

			internal Element duggHcLUlnjRnySPwdcsYXQFaCE(int P_0)
			{
				if (P_0 < 0 || P_0 >= eijOwZbpeptWbZzpnQOEBtAEzoE.Length)
				{
					return null;
				}
				if (eijOwZbpeptWbZzpnQOEBtAEzoE[P_0] == null)
				{
					return null;
				}
				return eijOwZbpeptWbZzpnQOEBtAEzoE[P_0].KspObDEVwZbsUrQZILSLveBSzec;
			}

			internal T duggHcLUlnjRnySPwdcsYXQFaCE<T>(int P_0) where T : Element
			{
				if (P_0 < 0 || P_0 >= eijOwZbpeptWbZzpnQOEBtAEzoE.Length)
				{
					return null;
				}
				if (eijOwZbpeptWbZzpnQOEBtAEzoE[P_0] == null)
				{
					return null;
				}
				return eijOwZbpeptWbZzpnQOEBtAEzoE[P_0].KspObDEVwZbsUrQZILSLveBSzec as T;
			}

			internal T zQuchPGSLdGKbrzRpZaLlSSCbNZ<T>(int P_0, out int P_1) where T : Element
			{
				P_1 = -1;
				T result = default(T);
				while (true)
				{
					int num = -871010591;
					while (true)
					{
						switch (num ^ -871010589)
						{
						case 4:
							break;
						case 2:
						{
							int num2;
							if (P_0 < 0)
							{
								num = -871010592;
								num2 = num;
							}
							else
							{
								num = -871010590;
								num2 = num;
							}
							continue;
						}
						case 1:
							if (P_0 >= eijOwZbpeptWbZzpnQOEBtAEzoE.Length)
							{
								num = -871010592;
								continue;
							}
							if (eijOwZbpeptWbZzpnQOEBtAEzoE[P_0] == null)
							{
								return null;
							}
							P_1 = eijOwZbpeptWbZzpnQOEBtAEzoE[P_0].jAvNNxyuqvKzUHXitHlYMMTfSEE;
							return eijOwZbpeptWbZzpnQOEBtAEzoE[P_0].KspObDEVwZbsUrQZILSLveBSzec as T;
						case 3:
							result = null;
							num = -871010589;
							continue;
						default:
							return result;
						}
						break;
					}
				}
			}

			internal bool DaOirHIMrqCgwPvMGCDKpJCcEFCO(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (xhRrSOnlgQeoHZxBkNsViMILhJHe >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (eNOnITiRsBDEjYjbmNjiYFjzMrb(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					goto IL_0047;
				}
				int num = OJSnQGYKhmyWDtNHEebuMTnkQgO();
				int num2;
				if (num < 0)
				{
					num2 = 1828673750;
					goto IL_004c;
				}
				return wQjTAZFRauwuTeDgmsCMGtlcvdH(P_0, P_1, num);
				IL_004c:
				while (true)
				{
					switch (num2 ^ 0x6CFF58D7)
					{
					case 0:
						break;
					case 2:
						return false;
					case 1:
						goto IL_007d;
					default:
						return false;
					}
					break;
					IL_007d:
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					num2 = 1828673748;
				}
				goto IL_0047;
				IL_0047:
				num2 = 1828673749;
				goto IL_004c;
			}

			internal bool bVOKRddcKvbSbctkpKYXcmgqIHnZ(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (xhRrSOnlgQeoHZxBkNsViMILhJHe == 0)
				{
					goto IL_000d;
				}
				int num = eNOnITiRsBDEjYjbmNjiYFjzMrb(P_0);
				int num2;
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					num2 = -1245224089;
					goto IL_0012;
				}
				return VkJKIMkDlGlsHNsBQqJiQrZNuSz(num);
				IL_0012:
				while (true)
				{
					switch (num2 ^ -1245224091)
					{
					case 0:
						break;
					case 1:
						goto IL_002f;
					case 3:
						return false;
					default:
						return false;
					}
					break;
					IL_002f:
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					num2 = -1245224090;
				}
				goto IL_000d;
				IL_000d:
				num2 = -1245224092;
				goto IL_0012;
			}

			internal void dHHtwaqVgHSyCJpZxpSpjXWBtHP()
			{
				int num = 0;
				while (true)
				{
					IL_0039:
					int num2;
					if (num >= eijOwZbpeptWbZzpnQOEBtAEzoE.Length)
					{
						xhRrSOnlgQeoHZxBkNsViMILhJHe = 0;
						num2 = 562423942;
						goto IL_0009;
					}
					goto IL_0026;
					IL_0009:
					while (true)
					{
						switch (num2 ^ 0x2185E884)
						{
						case 0:
							num2 = 562423943;
							continue;
						default:
							return;
						case 3:
							break;
						case 1:
							goto IL_0039;
						case 2:
							return;
						}
						break;
					}
					goto IL_0026;
					IL_0026:
					VkJKIMkDlGlsHNsBQqJiQrZNuSz(num);
					num++;
					num2 = 562423941;
					goto IL_0009;
				}
			}

			private int eNOnITiRsBDEjYjbmNjiYFjzMrb(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				int num = 0;
				while (num < eijOwZbpeptWbZzpnQOEBtAEzoE.Length)
				{
					while (true)
					{
						int num2;
						if (eijOwZbpeptWbZzpnQOEBtAEzoE[num] != null && eijOwZbpeptWbZzpnQOEBtAEzoE[num].KspObDEVwZbsUrQZILSLveBSzec == P_0)
						{
							num2 = -2035476579;
						}
						else
						{
							num++;
							num2 = -2035476578;
						}
						while (true)
						{
							switch (num2 ^ -2035476580)
							{
							case 0:
								num2 = -2035476577;
								continue;
							case 3:
								break;
							case 1:
								return num;
							default:
								goto end_IL_002b;
							}
							break;
						}
						continue;
						end_IL_002b:
						break;
					}
				}
				return -1;
			}

			private bool wQjTAZFRauwuTeDgmsCMGtlcvdH(Element P_0, int P_1, int P_2)
			{
				if (P_2 >= 0)
				{
					while (true)
					{
						int num = 798513356;
						while (true)
						{
							switch (num ^ 0x2F9858CD)
							{
							case 3:
								break;
							case 1:
								goto IL_0026;
							case 2:
								goto end_IL_0004;
							default:
								P_0.gcciRSIxpDwLjGkouBFeDNpLpQY();
								xhRrSOnlgQeoHZxBkNsViMILhJHe++;
								return true;
							}
							break;
							IL_0026:
							if (P_2 >= eijOwZbpeptWbZzpnQOEBtAEzoE.Length)
							{
								num = 798513359;
								continue;
							}
							if (eijOwZbpeptWbZzpnQOEBtAEzoE[P_2] != null)
							{
								return false;
							}
							eijOwZbpeptWbZzpnQOEBtAEzoE[P_2] = new UACTYqLbyuHWcCCfydXTtkvOSks(P_0, P_1);
							num = 798513357;
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				return false;
			}

			private bool VkJKIMkDlGlsHNsBQqJiQrZNuSz(int P_0)
			{
				if (P_0 < 0)
				{
					goto IL_002d;
				}
				if (P_0 >= eijOwZbpeptWbZzpnQOEBtAEzoE.Length)
				{
					goto IL_000f;
				}
				if (eijOwZbpeptWbZzpnQOEBtAEzoE[P_0] == null)
				{
					return false;
				}
				int num;
				if (eijOwZbpeptWbZzpnQOEBtAEzoE[P_0].KspObDEVwZbsUrQZILSLveBSzec != null)
				{
					eijOwZbpeptWbZzpnQOEBtAEzoE[P_0].KspObDEVwZbsUrQZILSLveBSzec.JlMseDESQvijkLYzzQbvcjipwAB();
					num = 1392993675;
					goto IL_0014;
				}
				goto IL_0063;
				IL_0014:
				switch (num ^ 0x5307658B)
				{
				case 2:
					break;
				case 1:
					goto IL_002d;
				default:
					goto IL_0063;
				}
				goto IL_000f;
				IL_000f:
				num = 1392993674;
				goto IL_0014;
				IL_002d:
				return false;
				IL_0063:
				eijOwZbpeptWbZzpnQOEBtAEzoE[P_0] = null;
				xhRrSOnlgQeoHZxBkNsViMILhJHe--;
				return true;
			}

			private int OJSnQGYKhmyWDtNHEebuMTnkQgO()
			{
				int num = 0;
				while (true)
				{
					int num2 = 477861518;
					while (true)
					{
						switch (num2 ^ 0x1C7B968F)
						{
						case 5:
							break;
						case 4:
						{
							int num3;
							if (num < eijOwZbpeptWbZzpnQOEBtAEzoE.Length)
							{
								num2 = 477861517;
								num3 = num2;
							}
							else
							{
								num2 = 477861519;
								num3 = num2;
							}
							continue;
						}
						case 2:
							if (eijOwZbpeptWbZzpnQOEBtAEzoE[num] == null)
							{
								num2 = 477861516;
								continue;
							}
							num++;
							num2 = 477861515;
							continue;
						case 1:
							num2 = 477861515;
							continue;
						case 3:
							return num;
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
			private const int rYmtWXfvcpSmEsBYJjzmNDxxADkj = 2;

			private CalibrationMap ASEOqTBXJrceilkNUjGByoKQGOL;

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
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return duggHcLUlnjRnySPwdcsYXQFaCE<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return duggHcLUlnjRnySPwdcsYXQFaCE<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector2.zero;
					}
					return JcvKAvskaiTPvofrSasKgFisGCR();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector2.zero;
					}
					return VGUcQMafoQTEXIehHkHcTlNqdpu();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						while (true)
						{
							int num = 1408664627;
							while (true)
							{
								switch (num ^ 0x53F68432)
								{
								case 0:
									break;
								case 1:
									goto IL_002b;
								default:
									return Vector2.zero;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = 1408664624;
							}
						}
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						while (true)
						{
							int num = 820486096;
							while (true)
							{
								switch (num ^ 0x30E79FD1)
								{
								case 2:
									break;
								case 1:
									goto IL_002b;
								default:
									return Vector2.zero;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = 820486097;
							}
						}
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller controller, int elementIdentifierId, string name, Axis xAxis, Axis yAxis, int xAxisIndex, int yAxisIndex, CalibrationMap calibratonMap)
				: base(controller, elementIdentifierId, name, CompoundControllerElementType.Axis2D)
			{
				DaOirHIMrqCgwPvMGCDKpJCcEFCO(xAxis, xAxisIndex);
				DaOirHIMrqCgwPvMGCDKpJCcEFCO(yAxis, yAxisIndex);
				ASEOqTBXJrceilkNUjGByoKQGOL = calibratonMap;
			}

			internal void KLhVytWTxZfEwTEmoGmNtOGgDXib()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.jJUwwohbhtCrPdKyxizhoTKjWBh(vector.x);
					goto IL_0021;
				}
				goto IL_003f;
				IL_003f:
				int num;
				if (yAxis != null)
				{
					yAxis.jJUwwohbhtCrPdKyxizhoTKjWBh(vector.y);
					num = 1539733054;
					goto IL_0026;
				}
				return;
				IL_0021:
				num = 1539733055;
				goto IL_0026;
				IL_0026:
				switch (num ^ 0x5BC6763E)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					goto IL_003f;
				case 0:
					return;
				}
				goto IL_0021;
			}

			private Vector2 JcvKAvskaiTPvofrSasKgFisGCR()
			{
				if (ASEOqTBXJrceilkNUjGByoKQGOL == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = zQuchPGSLdGKbrzRpZaLlSSCbNZ<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = zQuchPGSLdGKbrzRpZaLlSSCbNZ<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = default(float);
				float valueRawY = default(float);
				while (true)
				{
					int num = -64391266;
					while (true)
					{
						float num2;
						switch (num ^ -64391265)
						{
						case 3:
							break;
						case 1:
							if (axis == null)
							{
								num = -64391267;
								continue;
							}
							num2 = axis.valueRaw;
							goto IL_0078;
						case 2:
							num2 = 0f;
							goto IL_0078;
						default:
							{
								return ASEOqTBXJrceilkNUjGByoKQGOL.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
							}
							IL_0078:
							valueRawX = num2;
							valueRawY = ((axis2 != null) ? axis2.valueRaw : 0f);
							num = -64391265;
							continue;
						}
						break;
					}
				}
			}

			private Vector2 VGUcQMafoQTEXIehHkHcTlNqdpu()
			{
				if (ASEOqTBXJrceilkNUjGByoKQGOL == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = zQuchPGSLdGKbrzRpZaLlSSCbNZ<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = zQuchPGSLdGKbrzRpZaLlSSCbNZ<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = ((axis != null) ? axis.valueRawPrev : 0f);
				float valueRawY = ((axis2 != null) ? axis2.valueRawPrev : 0f);
				return ASEOqTBXJrceilkNUjGByoKQGOL.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int rYmtWXfvcpSmEsBYJjzmNDxxADkj = 8;

			private const int KKwRKuLQgofffEloEuMpxnbaPIZ = 0;

			private const int tCuCxFuoaQLZeUBEgAMeeGyYMfar = 1;

			private const int GTrSBiUfRNtjbyPaOdxfijoDgkwY = 2;

			private const int xQhnBCQAadzgdzPfYKpPJanbpwW = 3;

			private const int EGTopLydzAfVOCJpYjyRoZimyLmH = 4;

			private const int IUBbFaCScdCFmnXxxeqOdpAfqRqv = 5;

			private const int AUzGwJhEupdVCOBymUHWfcGPriMR = 6;

			private const int rYXsXhLWDXSqMryNHTKxzBaGVXa = 7;

			private readonly int UeRLAPucUgFPnuevKJOMpWmEUZW;

			private readonly Button[] WXIRxjkGHEWEQMEDrfdCKrevQRBu;

			private readonly ReadOnlyCollection<Button> zsKekhGzlLYUDrBVKWLTMwoeEobJ;

			private readonly int[] wsnRVTchQMZbRLKGfUjJSfiGEZJ;

			private bool ObyXoCwgmIPCqFaebjvAFqpVJTmP;

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
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					return ObyXoCwgmIPCqFaebjvAFqpVJTmP;
				}
				set
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						while (true)
						{
							switch (0x465ED27A ^ 0x465ED27B)
							{
							case 0:
								continue;
							case 1:
								return;
							}
							break;
						}
					}
					ObyXoCwgmIPCqFaebjvAFqpVJTmP = value;
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0;
					}
					return UeRLAPucUgFPnuevKJOMpWmEUZW;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						while (true)
						{
							int num = -1071523829;
							while (true)
							{
								switch (num ^ -1071523830)
								{
								case 0:
									break;
								case 1:
									goto IL_002b;
								default:
									return EmptyObjects<Button>.EmptyReadOnlyIListT;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = -1071523832;
							}
						}
					}
					return zsKekhGzlLYUDrBVKWLTMwoeEobJ;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return duggHcLUlnjRnySPwdcsYXQFaCE<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return duggHcLUlnjRnySPwdcsYXQFaCE<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return duggHcLUlnjRnySPwdcsYXQFaCE<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return duggHcLUlnjRnySPwdcsYXQFaCE<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return duggHcLUlnjRnySPwdcsYXQFaCE<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return duggHcLUlnjRnySPwdcsYXQFaCE<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return duggHcLUlnjRnySPwdcsYXQFaCE<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return duggHcLUlnjRnySPwdcsYXQFaCE<Button>(7);
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
					DaOirHIMrqCgwPvMGCDKpJCcEFCO(buttons[i], buttonIndices[i]);
				}
				WXIRxjkGHEWEQMEDrfdCKrevQRBu = buttons;
				wsnRVTchQMZbRLKGfUjJSfiGEZJ = buttonIndices;
				UeRLAPucUgFPnuevKJOMpWmEUZW = num;
				zsKekhGzlLYUDrBVKWLTMwoeEobJ = new ReadOnlyCollection<Button>(buttons);
			}

			internal void KLhVytWTxZfEwTEmoGmNtOGgDXib(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (UeRLAPucUgFPnuevKJOMpWmEUZW == 0)
				{
					return;
				}
				int num3 = default(int);
				while (true)
				{
					IL_01f4:
					int num;
					if (UeRLAPucUgFPnuevKJOMpWmEUZW == 8)
					{
						int num2;
						if (!ObyXoCwgmIPCqFaebjvAFqpVJTmP)
						{
							num = 494946398;
							num2 = num;
						}
						else
						{
							num = 494946395;
							num2 = num;
						}
						goto IL_0011;
					}
					goto IL_0084;
					IL_0011:
					while (true)
					{
						switch (num ^ 0x1D80485B)
						{
						case 10:
							num = 494946394;
							continue;
						case 2:
							jPyMDKESYAGarbVdqcjdNmAdFVM(WXIRxjkGHEWEQMEDrfdCKrevQRBu[4], wsnRVTchQMZbRLKGfUjJSfiGEZJ[4], wsnRVTchQMZbRLKGfUjJSfiGEZJ[5], wsnRVTchQMZbRLKGfUjJSfiGEZJ[3], P_0, P_1);
							num = 494946384;
							continue;
						case 9:
							break;
						case 3:
							return;
						case 12:
							num3++;
							num = 494946399;
							continue;
						case 8:
							num = 494946399;
							continue;
						case 5:
							goto IL_00b0;
						case 0:
							jPyMDKESYAGarbVdqcjdNmAdFVM(WXIRxjkGHEWEQMEDrfdCKrevQRBu[0], wsnRVTchQMZbRLKGfUjJSfiGEZJ[0], wsnRVTchQMZbRLKGfUjJSfiGEZJ[7], wsnRVTchQMZbRLKGfUjJSfiGEZJ[1], P_0, P_1);
							jPyMDKESYAGarbVdqcjdNmAdFVM(WXIRxjkGHEWEQMEDrfdCKrevQRBu[2], wsnRVTchQMZbRLKGfUjJSfiGEZJ[2], wsnRVTchQMZbRLKGfUjJSfiGEZJ[1], wsnRVTchQMZbRLKGfUjJSfiGEZJ[3], P_0, P_1);
							num = 494946393;
							continue;
						case 11:
							jPyMDKESYAGarbVdqcjdNmAdFVM(WXIRxjkGHEWEQMEDrfdCKrevQRBu[6], wsnRVTchQMZbRLKGfUjJSfiGEZJ[6], wsnRVTchQMZbRLKGfUjJSfiGEZJ[5], wsnRVTchQMZbRLKGfUjJSfiGEZJ[7], P_0, P_1);
							iCwFKAdQKrOrwBFLFYbHJRGURbnz(WXIRxjkGHEWEQMEDrfdCKrevQRBu[1], wsnRVTchQMZbRLKGfUjJSfiGEZJ[1], P_0, P_1);
							num = 494946397;
							continue;
						case 7:
							if (WXIRxjkGHEWEQMEDrfdCKrevQRBu[num3] != null)
							{
								WXIRxjkGHEWEQMEDrfdCKrevQRBu[num3].zxLhCcrlwKIIJANOaByFjYpjSot(P_0, wsnRVTchQMZbRLKGfUjJSfiGEZJ[num3], P_1);
								num = 494946391;
								continue;
							}
							goto case 12;
						case 6:
							iCwFKAdQKrOrwBFLFYbHJRGURbnz(WXIRxjkGHEWEQMEDrfdCKrevQRBu[3], wsnRVTchQMZbRLKGfUjJSfiGEZJ[3], P_0, P_1);
							iCwFKAdQKrOrwBFLFYbHJRGURbnz(WXIRxjkGHEWEQMEDrfdCKrevQRBu[5], wsnRVTchQMZbRLKGfUjJSfiGEZJ[5], P_0, P_1);
							iCwFKAdQKrOrwBFLFYbHJRGURbnz(WXIRxjkGHEWEQMEDrfdCKrevQRBu[7], wsnRVTchQMZbRLKGfUjJSfiGEZJ[7], P_0, P_1);
							num = 494946392;
							continue;
						case 1:
							goto IL_01f4;
						default:
							if (num3 >= WXIRxjkGHEWEQMEDrfdCKrevQRBu.Length)
							{
								return;
							}
							goto case 7;
						}
						break;
						IL_00b0:
						int num4;
						if (ReInput.configVars.force4WayHats)
						{
							num = 494946395;
							num4 = num;
						}
						else
						{
							num = 494946386;
							num4 = num;
						}
					}
					goto IL_0084;
					IL_0084:
					num3 = 0;
					num = 494946387;
					goto IL_0011;
				}
			}

			private void jPyMDKESYAGarbVdqcjdNmAdFVM(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
			{
				if (P_0 != null && P_1 >= 0)
				{
					if (P_1 >= P_5.buttonCount)
					{
						goto IL_001a;
					}
					goto IL_009a;
				}
				return;
				IL_0141:
				P_0.zxLhCcrlwKIIJANOaByFjYpjSot(P_4, P_1, P_5);
				return;
				IL_00dc:
				P_5.buttonPressureValues[P_1] = MathTools.MaxMagnitude(P_5.buttonPressureValues[P_1], MathTools.MaxMagnitude((P_2 >= 0 && P_2 < P_5.buttonCount) ? P_5.buttonPressureValues[P_2] : 0f, (P_3 >= 0 && P_3 < P_5.buttonCount) ? P_5.buttonPressureValues[P_3] : 0f));
				int num = -1206797470;
				goto IL_001f;
				IL_001a:
				num = -1206797466;
				goto IL_001f;
				IL_001f:
				while (true)
				{
					switch (num ^ -1206797469)
					{
					case 2:
						break;
					case 3:
						goto IL_004b;
					case 4:
						num = -1206797470;
						continue;
					case 5:
						return;
					case 0:
						goto IL_009a;
					case 6:
						goto IL_00dc;
					default:
						goto IL_0141;
					}
					break;
				}
				goto IL_001a;
				IL_009a:
				if (!P_0.isPressureSensitive)
				{
					if (P_2 >= 0 && P_2 < P_5.buttonCount)
					{
						bool[] buttonValues = P_5.buttonValues;
						int num2 = P_1;
						buttonValues[num2] |= P_5.buttonValues[P_2];
						num = -1206797472;
						goto IL_001f;
					}
					goto IL_004b;
				}
				goto IL_00dc;
				IL_004b:
				if (P_3 >= 0 && P_3 < P_5.buttonCount)
				{
					bool[] buttonValues2 = P_5.buttonValues;
					int num3 = P_1;
					buttonValues2[num3] |= P_5.buttonValues[P_3];
					num = -1206797465;
					goto IL_001f;
				}
				goto IL_0141;
			}

			private void iCwFKAdQKrOrwBFLFYbHJRGURbnz(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
			{
				if (P_0 == null || P_1 < 0)
				{
					return;
				}
				while (true)
				{
					int num = 240909081;
					while (true)
					{
						switch (num ^ 0xE5BFB1B)
						{
						case 0:
							break;
						case 3:
							if (!P_0.isPressureSensitive)
							{
								P_3.buttonValues[P_1] = false;
								num = 240909087;
								continue;
							}
							goto case 5;
						case 5:
							P_3.buttonPressureValues[P_1] = 0f;
							num = 240909087;
							continue;
						case 2:
						{
							int num2;
							if (P_1 >= P_3.buttonCount)
							{
								num = 240909082;
								num2 = num;
							}
							else
							{
								num = 240909080;
								num2 = num;
							}
							continue;
						}
						case 1:
							return;
						default:
							P_0.zxLhCcrlwKIIJANOaByFjYpjSot(P_2, P_1, P_3);
							return;
						}
						break;
					}
				}
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller ktnvQXcbwjTTWobUkcIrbxSoyaKH;

			private IControllerExtensionSource osAcqhQGqUOKZMlJKgeajFWwmnz;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (ktnvQXcbwjTTWobUkcIrbxSoyaKH == null)
					{
						return false;
					}
					return ktnvQXcbwjTTWobUkcIrbxSoyaKH._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (ktnvQXcbwjTTWobUkcIrbxSoyaKH == null)
					{
						return false;
					}
					return ktnvQXcbwjTTWobUkcIrbxSoyaKH.enabled;
				}
			}

			internal Controller controller
			{
				get
				{
					return ktnvQXcbwjTTWobUkcIrbxSoyaKH;
				}
			}

			internal Extension(IControllerExtensionSource source)
			{
				_reInputId = ReInput.id;
				IpgfZlgZZhgdapqubiDMNSfDcZA(source);
			}

			internal Extension(Extension source)
				: this(source.osAcqhQGqUOKZMlJKgeajFWwmnz)
			{
				ktnvQXcbwjTTWobUkcIrbxSoyaKH = source.ktnvQXcbwjTTWobUkcIrbxSoyaKH;
			}

			internal T GetController<T>() where T : Controller
			{
				if (ktnvQXcbwjTTWobUkcIrbxSoyaKH == null)
				{
					return null;
				}
				return ktnvQXcbwjTTWobUkcIrbxSoyaKH as T;
			}

			internal void SetController(Controller controller)
			{
				ktnvQXcbwjTTWobUkcIrbxSoyaKH = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return osAcqhQGqUOKZMlJKgeajFWwmnz;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					goto IL_0003;
				}
				goto IL_0034;
				IL_0003:
				int num = -1808764086;
				goto IL_0008;
				IL_0008:
				switch (num ^ -1808764085)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					IpgfZlgZZhgdapqubiDMNSfDcZA(null);
					return;
				case 3:
					goto IL_0034;
				case 2:
					return;
				}
				goto IL_0003;
				IL_0034:
				IpgfZlgZZhgdapqubiDMNSfDcZA(extension.osAcqhQGqUOKZMlJKgeajFWwmnz);
				num = -1808764087;
				goto IL_0008;
			}

			private void IpgfZlgZZhgdapqubiDMNSfDcZA(IControllerExtensionSource P_0)
			{
				osAcqhQGqUOKZMlJKgeajFWwmnz = P_0;
				SourceUpdated(osAcqhQGqUOKZMlJKgeajFWwmnz);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		private sealed class FNJWDqUcGojBieiQlLiyqCLQuog : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public Controller ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int cxajIdvHgWRVzXfSJnEbjHXsCoJi;

			public int vumCaUTmTiqpmKtmvUDrfhqhNlA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				FNJWDqUcGojBieiQlLiyqCLQuog fNJWDqUcGojBieiQlLiyqCLQuog;
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					fNJWDqUcGojBieiQlLiyqCLQuog = this;
				}
				else
				{
					while (true)
					{
						fNJWDqUcGojBieiQlLiyqCLQuog = new FNJWDqUcGojBieiQlLiyqCLQuog(0);
						int num = 1656233147;
						while (true)
						{
							switch (num ^ 0x62B81CB9)
							{
							case 3:
								num = 1656233144;
								continue;
							case 1:
								break;
							case 2:
								fNJWDqUcGojBieiQlLiyqCLQuog.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
								num = 1656233145;
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
				return fNJWDqUcGojBieiQlLiyqCLQuog;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				default:
					num = 581926606;
					goto IL_001a;
				case 1:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					num = 581926600;
					goto IL_001a;
				case 0:
					goto IL_0133;
					IL_001a:
					while (true)
					{
						switch (num ^ 0x22AF7ECB)
						{
						case 2:
							break;
						case 5:
							num = 581926602;
							continue;
						case 8:
							goto IL_0059;
						case 9:
							goto IL_007d;
						case 6:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.kcNNbhWqYgplljZYWEwCOERtTfg(cxajIdvHgWRVzXfSJnEbjHXsCoJi, out vumCaUTmTiqpmKtmvUDrfhqhNlA))
							{
								RDkWcsTpvDaNZojjIZONnoEBXPC = new ControllerPollingInfo(true, -1, ZzSaCQHlhEgTijsOQGwUlyKTOzqG.id, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._name, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._type, ControllerElementType.Button, cxajIdvHgWRVzXfSJnEbjHXsCoJi, Pole.Positive, ZzSaCQHlhEgTijsOQGwUlyKTOzqG.kABaypBwJpdJPQfaNrcsDzJUopW.GetElementIdentifierName(vumCaUTmTiqpmKtmvUDrfhqhNlA), vumCaUTmTiqpmKtmvUDrfhqhNlA, KeyCode.None);
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							}
							goto case 3;
						case 4:
							num = 581926595;
							continue;
						case 7:
							cxajIdvHgWRVzXfSJnEbjHXsCoJi = 0;
							num = 581926607;
							continue;
						case 0:
							goto IL_0133;
						case 3:
							cxajIdvHgWRVzXfSJnEbjHXsCoJi++;
							num = 581926595;
							continue;
						default:
							return false;
						}
						break;
						IL_0059:
						int num2;
						if (cxajIdvHgWRVzXfSJnEbjHXsCoJi < ZzSaCQHlhEgTijsOQGwUlyKTOzqG._buttonCount)
						{
							num = 581926605;
							num2 = num;
						}
						else
						{
							num = 581926602;
							num2 = num;
						}
					}
					goto default;
					IL_0133:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
						num = 581926602;
						goto IL_001a;
					}
					goto IL_007d;
					IL_007d:
					ZzSaCQHlhEgTijsOQGwUlyKTOzqG.UpdatePollingFrameTracking();
					num = 581926604;
					goto IL_001a;
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
			public FNJWDqUcGojBieiQlLiyqCLQuog(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class WkNhrCAsdyYGqsfXnfKqOqwFIgF : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public Controller ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int cDjWSJHiQUHLSepVoVxrPyfkVKe;

			public int YlWcjzcGQzBVVrBIhpabpCosdnWE;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					goto IL_0023;
				}
				goto IL_0052;
				IL_0028:
				int num;
				WkNhrCAsdyYGqsfXnfKqOqwFIgF wkNhrCAsdyYGqsfXnfKqOqwFIgF = default(WkNhrCAsdyYGqsfXnfKqOqwFIgF);
				while (true)
				{
					switch (num ^ 0x50327EE6)
					{
					case 0:
						break;
					case 3:
						wkNhrCAsdyYGqsfXnfKqOqwFIgF = this;
						num = 1345486564;
						continue;
					case 4:
						goto IL_0052;
					case 1:
						wkNhrCAsdyYGqsfXnfKqOqwFIgF.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = 1345486564;
						continue;
					default:
						return wkNhrCAsdyYGqsfXnfKqOqwFIgF;
					}
					break;
				}
				goto IL_0023;
				IL_0052:
				wkNhrCAsdyYGqsfXnfKqOqwFIgF = new WkNhrCAsdyYGqsfXnfKqOqwFIgF(0);
				num = 1345486567;
				goto IL_0028;
				IL_0023:
				num = 1345486565;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
				while (true)
				{
					int num = -2013051521;
					while (true)
					{
						switch (num ^ -2013051524)
						{
						case 7:
							break;
						case 4:
							if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
							{
								ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
								num = -2013051527;
								continue;
							}
							goto case 6;
						case 8:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.opIQMBDpkpPdeIFNoKxDXcIsxmK(cDjWSJHiQUHLSepVoVxrPyfkVKe, out YlWcjzcGQzBVVrBIhpabpCosdnWE))
							{
								RDkWcsTpvDaNZojjIZONnoEBXPC = new ControllerPollingInfo(true, -1, ZzSaCQHlhEgTijsOQGwUlyKTOzqG.id, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._name, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._type, ControllerElementType.Button, cDjWSJHiQUHLSepVoVxrPyfkVKe, Pole.Positive, ZzSaCQHlhEgTijsOQGwUlyKTOzqG.kABaypBwJpdJPQfaNrcsDzJUopW.GetElementIdentifierName(YlWcjzcGQzBVVrBIhpabpCosdnWE), YlWcjzcGQzBVVrBIhpabpCosdnWE, KeyCode.None);
								num = -2013051524;
								continue;
							}
							goto case 1;
						case 10:
						{
							int num2;
							if (cDjWSJHiQUHLSepVoVxrPyfkVKe >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG._buttonCount)
							{
								num = -2013051527;
								num2 = num;
							}
							else
							{
								num = -2013051532;
								num2 = num;
							}
							continue;
						}
						case 1:
							cDjWSJHiQUHLSepVoVxrPyfkVKe++;
							num = -2013051530;
							continue;
						case 6:
							ZzSaCQHlhEgTijsOQGwUlyKTOzqG.UpdatePollingFrameTracking();
							num = -2013051529;
							continue;
						case 0:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						case 11:
							cDjWSJHiQUHLSepVoVxrPyfkVKe = 0;
							num = -2013051530;
							continue;
						case 9:
							num = -2013051527;
							continue;
						case 2:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = -2013051528;
							continue;
						case 3:
							switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 1:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = -2013051523;
								continue;
							case 0:
								break;
							default:
								num = -2013051531;
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
			public WkNhrCAsdyYGqsfXnfKqOqwFIgF(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		public readonly int id;

		protected string _tag;

		protected string _name;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid hLHPojWAxuyakcKOieCsahbSjqfw;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension iKrPwKwbznPAureDUGtpiCKudaT;

		private bool gmbIkkevNmPVGSTIwKcAwoPYANrc;

		private ControllerIdentifier LVkjlwzgVhunDKUrbUTxlKXSrxH;

		internal int SsPwhbdijXONOlkRKHOkXryZrDq;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> zGVdLCAPoSECGnwSmQQzpAttLxeB;

		private readonly ReadOnlyCollection<Element> DnCGAXuCydczsGMHdwaSQnTzKxR;

		internal readonly InputSource rsTYFamRrKtdrFcGFJzbrFwDZOs;

		internal readonly ControllerDataUpdater ROoGdHjYclVKlAjCTYtzRRhBjqvj;

		internal readonly HardwareControllerMap_Game kABaypBwJpdJPQfaNrcsDzJUopW;

		internal uint mWRbAlErCrAbMyJarUEQVTumMOEf;

		private uint mnVgXGbMmqHovIUtQxHLskeYOoM;

		private uint rxPCRGTYIAnlCEdqtkRpHFPNcIQ;

		private Action<bool> keQiiwcvhFUxZCAVksrVOIIyXdA;

		private IControllerTemplate[] JbtxvIcGuXUlFtfbnJMGrZPRmBP;

		private ReadOnlyCollection<IControllerTemplate> FnhMJHyFObsTZPxMkmUWbCqhfJe;

		private static Func<Controller, Guid, bool> oiSesFDqPiEhXcxTcYpQaUbFKhiL;

		private static Func<Controller, Type, bool> rkoHohdAPUhndDDGuQCxHTgGHmY;

		[CompilerGenerated]
		private static Func<Controller, Guid, bool> ziuyIEKZgAqwOBMhCqzxtdlWtGn;

		[CompilerGenerated]
		private static Func<Controller, Type, bool> cyPpxoBXosrOAPNMKkrilggvqke;

		internal bool wasPollingPrev
		{
			get
			{
				return mnVgXGbMmqHovIUtQxHLskeYOoM == ReInput.previousFrame;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return false;
				}
				return gmbIkkevNmPVGSTIwKcAwoPYANrc;
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						switch (-1812243167 ^ -1812243168)
						{
						case 2:
							continue;
						case 1:
							ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
							return;
						}
						break;
					}
				}
				_tag = value;
			}
		}

		public string hardwareName
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return Guid.Empty;
				}
				return hLHPojWAxuyakcKOieCsahbSjqfw;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier
		{
			get
			{
				return LVkjlwzgVhunDKUrbUTxlKXSrxH;
			}
		}

		public bool isConnected
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						switch (0x30AA8EC1 ^ 0x30AA8EC0)
						{
						case 0:
							break;
						case 1:
							ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
							return;
						case 3:
							goto end_IL_000d;
						default:
							goto IL_0054;
						}
						continue;
						end_IL_000d:
						break;
					}
				}
				if (!value)
				{
					Disconnected();
					return;
				}
				goto IL_0054;
				IL_0054:
				Connected();
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				}
				return zGVdLCAPoSECGnwSmQQzpAttLxeB.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return DnCGAXuCydczsGMHdwaSQnTzKxR;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				return iKrPwKwbznPAureDUGtpiCKudaT;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						int num = -1626597335;
						while (true)
						{
							switch (num ^ -1626597333)
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
							ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
							num = -1626597334;
						}
					}
				}
				return kABaypBwJpdJPQfaNrcsDzJUopW.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return kABaypBwJpdJPQfaNrcsDzJUopW.buttonElementIdentifiers_readOnly;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return FnhMJHyFObsTZPxMkmUWbCqhfJe;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				}
				return JbtxvIcGuXUlFtfbnJMGrZPRmBP.Length;
			}
		}

		internal static Func<Controller, Guid, bool> implementsTemplateDelegate_Guid
		{
			get
			{
				Func<Controller, Guid, bool> func = oiSesFDqPiEhXcxTcYpQaUbFKhiL;
				if (func == null)
				{
					if (ziuyIEKZgAqwOBMhCqzxtdlWtGn == null)
					{
						while (true)
						{
							int num = 1077093091;
							while (true)
							{
								switch (num ^ 0x403322E1)
								{
								case 0:
									break;
								case 2:
									ziuyIEKZgAqwOBMhCqzxtdlWtGn = (Controller P_0, Guid P_1) => P_0.ImplementsTemplate(P_1);
									num = 1077093088;
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
					func = (oiSesFDqPiEhXcxTcYpQaUbFKhiL = ziuyIEKZgAqwOBMhCqzxtdlWtGn);
				}
				return func;
			}
		}

		internal static Func<Controller, Type, bool> implementsTemplateDelegate_Type
		{
			get
			{
				return (Controller P_0, Type P_1) => P_0.ImplementsTemplate(P_1);
			}
		}

		internal event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				keQiiwcvhFUxZCAVksrVOIIyXdA = (Action<bool>)Delegate.Combine(keQiiwcvhFUxZCAVksrVOIIyXdA, value);
			}
			remove
			{
				keQiiwcvhFUxZCAVksrVOIIyXdA = (Action<bool>)Delegate.Remove(keQiiwcvhFUxZCAVksrVOIIyXdA, value);
			}
		}

		internal Controller(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, ControllerType type, Guid hardwareTypeGuid, int buttonCount, bool[] isButtonPressureSensitive, HardwareButtonInfo[] hwButtonInfo, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
		{
			int num4 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = 483454965;
				while (true)
				{
					switch (num ^ 0x1CD0EFFF)
					{
					case 8:
						break;
					case 14:
						if (num4 >= buttonCount)
						{
							num = 483454966;
							continue;
						}
						goto case 7;
					case 11:
						zGVdLCAPoSECGnwSmQQzpAttLxeB = new List<Element>(buttonCount);
						DnCGAXuCydczsGMHdwaSQnTzKxR = new ReadOnlyCollection<Element>(zGVdLCAPoSECGnwSmQQzpAttLxeB);
						num = 483454971;
						continue;
					case 10:
						id = controllerId;
						rsTYFamRrKtdrFcGFJzbrFwDZOs = inputSource;
						_type = type;
						hLHPojWAxuyakcKOieCsahbSjqfw = hardwareTypeGuid;
						_buttonCount = buttonCount;
						num = 483454958;
						continue;
					case 17:
						_name = name;
						_hardwareName = hardwareName;
						_hardwareIdentifier = hardwareIdentifier;
						ROoGdHjYclVKlAjCTYtzRRhBjqvj = dataUpdater;
						kABaypBwJpdJPQfaNrcsDzJUopW = hardwareMap;
						gmbIkkevNmPVGSTIwKcAwoPYANrc = true;
						SsPwhbdijXONOlkRKHOkXryZrDq = ReInput.id;
						num = 483454970;
						continue;
					case 2:
						num = 483454960;
						continue;
					case 3:
						JbtxvIcGuXUlFtfbnJMGrZPRmBP = EmptyObjects<IControllerTemplate>.array;
						num = 483454962;
						continue;
					case 9:
						buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
						num = 483454972;
						continue;
					case 4:
						buttons = new Button[buttonCount];
						if (isButtonPressureSensitive != null)
						{
							int num5;
							if (isButtonPressureSensitive.Length >= buttonCount)
							{
								num = 483454969;
								num5 = num;
							}
							else
							{
								num = 483454974;
								num5 = num;
							}
							continue;
						}
						goto case 1;
					case 12:
						DaOirHIMrqCgwPvMGCDKpJCcEFCO(buttons[num4]);
						num4++;
						num = 483454961;
						continue;
					case 6:
						num2 = 0;
						num = 483454973;
						continue;
					case 15:
					{
						int num3;
						if (num2 >= buttonCount)
						{
							num = 483454966;
							num3 = num;
						}
						else
						{
							num = 483454959;
							num3 = num;
						}
						continue;
					}
					case 16:
						buttons[num2] = new Button(this, hardwareMap.buttonElementIdentifierIds[num2], "Button " + num2, isButtonPressureSensitive[num2], (hwButtonInfo != null) ? hwButtonInfo[num2] : new HardwareButtonInfo());
						DaOirHIMrqCgwPvMGCDKpJCcEFCO(buttons[num2]);
						num2++;
						num = 483454960;
						continue;
					case 5:
						XSCFExJHpLZlPntjxNolSkPZvkYM(extension);
						num = 483454964;
						continue;
					case 1:
						num4 = 0;
						num = 483454975;
						continue;
					case 7:
						buttons[num4] = new Button(this, hardwareMap.buttonElementIdentifierIds[num4], "Button " + num4, false, (hwButtonInfo != null) ? hwButtonInfo[num4] : new HardwareButtonInfo());
						num = 483454963;
						continue;
					case 0:
						num = 483454961;
						continue;
					default:
						FnhMJHyFObsTZPxMkmUWbCqhfJe = new ReadOnlyCollection<IControllerTemplate>(JbtxvIcGuXUlFtfbnJMGrZPRmBP);
						Connected();
						return;
					}
					break;
				}
			}
		}

		internal virtual void DRbMoDMaPuHTEfQNWMCHwDDCfEIB()
		{
			LVkjlwzgVhunDKUrbUTxlKXSrxH = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			if (kABaypBwJpdJPQfaNrcsDzJUopW == null)
			{
				return null;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			while (true)
			{
				int num = 1480536176;
				while (true)
				{
					switch (num ^ 0x583F3071)
					{
					case 0:
						break;
					case 1:
						if (buttonIndex < 0)
						{
							goto IL_0054;
						}
						return buttons[buttonIndex];
					default:
						return null;
					}
					break;
					IL_0054:
					num = 1480536179;
				}
			}
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return -1;
			}
			return kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			return kABaypBwJpdJPQfaNrcsDzJUopW.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if (index >= 0)
			{
				while (true)
				{
					int num = -591889217;
					while (true)
					{
						switch (num ^ -591889218)
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
							num = -591889218;
							continue;
						}
						return buttons[index].value;
					}
					continue;
					end_IL_001f:
					break;
				}
			}
			return false;
		}

		public virtual bool GetButtonDown(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].justPressed;
		}

		public virtual bool GetButtonUp(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if (index >= 0)
			{
				while (true)
				{
					int num = 841092056;
					while (true)
					{
						switch (num ^ 0x32220BD9)
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
							num = 841092057;
							continue;
						}
						return buttons[index].justReleased;
					}
					continue;
					end_IL_001f:
					break;
				}
			}
			return false;
		}

		public virtual bool GetButtonChanged(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = 1322143805;
					goto IL_001e;
				}
				return buttons[index].value != buttons[index].valuePrev;
			}
			goto IL_004d;
			IL_001e:
			switch (num ^ 0x4ECE503F)
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
			num = 1322143806;
			goto IL_001e;
			IL_004d:
			return false;
		}

		public virtual bool GetButtonPrev(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = -348477839;
					goto IL_0012;
				}
				return buttons[index].valuePrev;
			}
			goto IL_004d;
			IL_0012:
			switch (num ^ -348477840)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			default:
				goto IL_004d;
			}
			goto IL_000d;
			IL_000d:
			num = -348477838;
			goto IL_0012;
			IL_004d:
			return false;
		}

		public virtual bool GetButtonDoublePressHold(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				while (true)
				{
					int num = -149041769;
					while (true)
					{
						switch (num ^ -149041771)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return false;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						num = -149041772;
					}
				}
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = 1848934259;
					goto IL_0012;
				}
				return buttons[index].DoublePressedAndHeld(speed);
			}
			goto IL_004d;
			IL_0012:
			switch (num ^ 0x6E347F72)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			default:
				goto IL_004d;
			}
			goto IL_000d;
			IL_000d:
			num = 1848934256;
			goto IL_0012;
			IL_004d:
			return false;
		}

		public virtual bool GetButtonDoublePressDown(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = -167990255;
					goto IL_0012;
				}
				return buttons[index].JustDoublePressed(speed);
			}
			goto IL_004d;
			IL_0012:
			switch (num ^ -167990256)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			default:
				goto IL_004d;
			}
			goto IL_000d;
			IL_000d:
			num = -167990254;
			goto IL_0012;
			IL_004d:
			return false;
		}

		public virtual float GetButtonTimePressed(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _buttonCount)
				{
					num = 1976878529;
					goto IL_0012;
				}
				return buttons[index].timePressed;
			}
			goto IL_0051;
			IL_0012:
			switch (num ^ 0x75D4C5C1)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			default:
				goto IL_0051;
			}
			goto IL_000d;
			IL_000d:
			num = 1976878528;
			goto IL_0012;
			IL_0051:
			return 0f;
		}

		public virtual float GetButtonTimeUnpressed(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = 3352640;
				num2 = num;
			}
			else
			{
				num = 3352642;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = 3352641;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x332843)
				{
				case 0:
					break;
				case 2:
					return 0f;
				case 3:
					if (index >= _buttonCount)
					{
						goto IL_005f;
					}
					return buttons[index].timeUnpressed;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = 3352642;
			}
			goto IL_0019;
		}

		public virtual float GetButtonLastTimePressed(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0f;
			}
			return buttons[index].lastTimePressed;
		}

		public virtual float GetButtonLastTimeUnpressed(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (index < 0)
			{
				num = 989574332;
				num2 = num;
			}
			else
			{
				num = 989574335;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 989574333;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x3AFBB4BC)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0f;
				case 3:
					if (index >= _buttonCount)
					{
						goto IL_005f;
					}
					return buttons[index].lastTimeUnpressed;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = 989574332;
			}
			goto IL_000d;
		}

		public virtual bool GetAnyButton()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= _buttonCount)
				{
					num2 = 479590177;
					num3 = num2;
				}
				else
				{
					num2 = 479590183;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x1C95F723)
					{
					case 3:
						num2 = 479590183;
						continue;
					case 4:
						if (buttons[num].value)
						{
							num2 = 479590178;
							continue;
						}
						num++;
						num2 = 479590179;
						continue;
					case 0:
						break;
					case 1:
						return true;
					default:
						return false;
					}
					break;
				}
			}
		}

		public virtual bool GetAnyButtonDown()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = 1750182638;
				while (true)
				{
					switch (num2 ^ 0x6851AAED)
					{
					case 2:
						break;
					case 3:
						num2 = 1750182637;
						continue;
					case 4:
						if (buttons[num].justPressed)
						{
							num2 = 1750182636;
							continue;
						}
						num++;
						num2 = 1750182637;
						continue;
					case 1:
						return true;
					default:
						if (num >= _buttonCount)
						{
							return false;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public virtual bool GetAnyButtonUp()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num = 0;
			int num2 = 1629447879;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num2 ^ 0x611F66C7)
				{
				case 3:
					break;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					num2 = 1629447877;
					continue;
				case 4:
					if (buttons[num].justReleased)
					{
						return true;
					}
					num++;
					num2 = 1629447879;
					continue;
				case 2:
					return false;
				default:
					if (num >= _buttonCount)
					{
						return false;
					}
					goto case 4;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num2 = 1629447878;
			goto IL_0012;
		}

		public virtual bool GetAnyButtonPrev()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num = 0;
			int num2 = 1574647422;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num2 ^ 0x5DDB367C)
				{
				case 0:
					break;
				case 3:
					if (buttons[num].valuePrev)
					{
						return true;
					}
					num++;
					num2 = 1574647416;
					continue;
				case 2:
					num2 = 1574647416;
					continue;
				case 1:
					return false;
				default:
					if (num >= _buttonCount)
					{
						return false;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num2 = 1574647421;
			goto IL_001e;
		}

		public virtual bool GetAnyButtonChanged()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num = 0;
			int num2 = -680454746;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num2 ^ -680454748)
				{
				case 0:
					break;
				case 1:
					return false;
				case 3:
					if (!buttons[num].justChangedState)
					{
						goto IL_0057;
					}
					return true;
				default:
					if (num >= _buttonCount)
					{
						return false;
					}
					goto case 3;
				}
				break;
				IL_0057:
				num++;
				num2 = -680454746;
			}
			goto IL_0019;
			IL_0019:
			num2 = -680454747;
			goto IL_001e;
		}

		public virtual bool GetButtonById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			int num = -675858702;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -675858698)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					num = -675858698;
					continue;
				case 4:
					if (buttonIndex >= 0)
					{
						if (buttonIndex >= _buttonCount)
						{
							num = -675858699;
							continue;
						}
						return buttons[buttonIndex].value;
					}
					goto default;
				case 0:
					return false;
				default:
					return false;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = -675858697;
			goto IL_0012;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			int num;
			if (buttonIndex >= 0)
			{
				if (buttonIndex >= _buttonCount)
				{
					num = -133310888;
					goto IL_001e;
				}
				return buttons[buttonIndex].justReleased;
			}
			goto IL_005a;
			IL_001e:
			switch (num ^ -133310888)
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
			num = -133310887;
			goto IL_001e;
			IL_005a:
			return false;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			int num;
			if (buttonIndex >= 0)
			{
				if (buttonIndex >= _buttonCount)
				{
					num = -734021378;
					goto IL_0012;
				}
				return buttons[buttonIndex].DoublePressedAndHeld(speed);
			}
			goto IL_0065;
			IL_0012:
			while (true)
			{
				switch (num ^ -734021379)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					num = -734021380;
					continue;
				case 1:
					return false;
				default:
					goto IL_0065;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = -734021377;
			goto IL_0012;
			IL_0065:
			return false;
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].JustDoublePressed(speed);
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			while (true)
			{
				int num = 13451733;
				while (true)
				{
					switch (num ^ 0xCD41D7)
					{
					case 0:
						break;
					case 2:
						if (buttonIndex >= 0)
						{
							if (buttonIndex >= _buttonCount)
							{
								goto IL_0053;
							}
							return buttons[buttonIndex].valuePrev;
						}
						goto default;
					default:
						return false;
					}
					break;
					IL_0053:
					num = 13451734;
				}
			}
		}

		public virtual float GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0f;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual float GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0f;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual float GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			int num;
			if (buttonIndex >= 0)
			{
				if (buttonIndex >= _buttonCount)
				{
					num = -433344321;
					goto IL_0012;
				}
				return buttons[buttonIndex].lastTimePressed;
			}
			goto IL_005e;
			IL_0012:
			switch (num ^ -433344322)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			default:
				goto IL_005e;
			}
			goto IL_000d;
			IL_000d:
			num = -433344324;
			goto IL_0012;
			IL_005e:
			return 0f;
		}

		public virtual float GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			int buttonIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetButtonIndex(elementIdentifierId);
			if (buttonIndex >= 0)
			{
				while (true)
				{
					int num = -870980396;
					while (true)
					{
						switch (num ^ -870980394)
						{
						case 0:
							break;
						case 2:
							goto IL_004e;
						default:
							goto end_IL_0030;
						}
						break;
						IL_004e:
						if (buttonIndex >= _buttonCount)
						{
							num = -870980393;
							continue;
						}
						return buttons[buttonIndex].lastTimeUnpressed;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return 0f;
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
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
			}
			UpdatePollingFrameTracking();
			int num = 0;
			while (true)
			{
				int num2 = -652730396;
				while (true)
				{
					switch (num2 ^ -652730395)
					{
					case 3:
						break;
					case 1:
						num2 = -652730393;
						continue;
					case 0:
					{
						int elementIdentifierId;
						if (kcNNbhWqYgplljZYWEwCOERtTfg(num, out elementIdentifierId))
						{
							return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, num, Pole.Positive, kABaypBwJpdJPQfaNrcsDzJUopW.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
						}
						num++;
						num2 = -652730393;
						continue;
					}
					default:
						if (num >= _buttonCount)
						{
							return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			UpdatePollingFrameTracking();
			int num = 0;
			int num2 = 62818725;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num2 ^ 0x3BE89A5)
				{
				case 4:
					break;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
				case 0:
					num2 = 62818727;
					continue;
				case 3:
				{
					int elementIdentifierId;
					if (opIQMBDpkpPdeIFNoKxDXcIsxmK(num, out elementIdentifierId))
					{
						return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, num, Pole.Positive, kABaypBwJpdJPQfaNrcsDzJUopW.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
					}
					num++;
					num2 = 62818727;
					continue;
				}
				default:
					if (num >= _buttonCount)
					{
						return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
					}
					goto case 3;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num2 = 62818724;
			goto IL_0012;
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
			FNJWDqUcGojBieiQlLiyqCLQuog fNJWDqUcGojBieiQlLiyqCLQuog = new FNJWDqUcGojBieiQlLiyqCLQuog(-2);
			fNJWDqUcGojBieiQlLiyqCLQuog.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			return fNJWDqUcGojBieiQlLiyqCLQuog;
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			WkNhrCAsdyYGqsfXnfKqOqwFIgF wkNhrCAsdyYGqsfXnfKqOqwFIgF = new WkNhrCAsdyYGqsfXnfKqOqwFIgF(-2);
			wkNhrCAsdyYGqsfXnfKqOqwFIgF.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			return wkNhrCAsdyYGqsfXnfKqOqwFIgF;
		}

		private bool kcNNbhWqYgplljZYWEwCOERtTfg(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].iuEuRSpYDgudIbTXYlbkEqHpalu._excludeFromPolling)
			{
				return false;
			}
			P_1 = kABaypBwJpdJPQfaNrcsDzJUopW.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool opIQMBDpkpPdeIFNoKxDXcIsxmK(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].iuEuRSpYDgudIbTXYlbkEqHpalu._excludeFromPolling)
			{
				return false;
			}
			P_1 = kABaypBwJpdJPQfaNrcsDzJUopW.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (rxPCRGTYIAnlCEdqtkRpHFPNcIQ == ReInput.currentFrame)
			{
				return;
			}
			while (true)
			{
				mnVgXGbMmqHovIUtQxHLskeYOoM = rxPCRGTYIAnlCEdqtkRpHFPNcIQ;
				rxPCRGTYIAnlCEdqtkRpHFPNcIQ = ReInput.currentFrame;
				int num;
				if (!wasPollingPrev)
				{
					if (mWRbAlErCrAbMyJarUEQVTumMOEf == uint.MaxValue)
					{
						mWRbAlErCrAbMyJarUEQVTumMOEf = 0u;
						num = 200599835;
						goto IL_0013;
					}
					goto IL_0072;
				}
				break;
				IL_0072:
				mWRbAlErCrAbMyJarUEQVTumMOEf++;
				num = 200599836;
				goto IL_0013;
				IL_0013:
				while (true)
				{
					switch (num ^ 0xBF4E91F)
					{
					case 0:
						num = 200599837;
						continue;
					default:
						return;
					case 2:
						break;
					case 4:
						return;
					case 1:
						goto IL_0072;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public virtual float GetLastTimeActive()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			return GetLastTimeActive(false);
		}

		public virtual float GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual float GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			return GetLastTimeAnyElementChanged(false);
		}

		public virtual float GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public float GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			if (buttons == null)
			{
				return 0f;
			}
			float num = 0f;
			int num2 = 0;
			while (num2 < buttons.Length)
			{
				while (true)
				{
					float lastTimePressed = buttons[num2].lastTimePressed;
					int num3;
					int num4;
					if (lastTimePressed > num)
					{
						num3 = 850126348;
						num4 = num3;
					}
					else
					{
						num3 = 850126350;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ 0x32ABE60F)
						{
						case 0:
							num3 = 850126349;
							continue;
						case 1:
							num2++;
							num3 = 850126347;
							continue;
						case 3:
							num = lastTimePressed;
							num3 = 850126350;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0071;
						}
						break;
					}
					continue;
					end_IL_0071:
					break;
				}
			}
			return num;
		}

		public float GetLastTimeAnyButtonChanged()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			float num2 = default(float);
			if (buttons == null)
			{
				num = -1857064457;
			}
			else
			{
				num2 = 0f;
				num = -1857064464;
			}
			goto IL_001e;
			IL_0019:
			num = -1857064463;
			goto IL_001e;
			IL_001e:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1857064464)
				{
				case 3:
					break;
				case 0:
					num3 = 0;
					num = -1857064462;
					continue;
				case 6:
					num3++;
					num = -1857064459;
					continue;
				case 1:
					return 0f;
				case 4:
				{
					float lastTimeStateChanged = buttons[num3].lastTimeStateChanged;
					if (lastTimeStateChanged > num2)
					{
						num2 = lastTimeStateChanged;
						num = -1857064458;
						continue;
					}
					goto case 6;
				}
				case 2:
					num = -1857064459;
					continue;
				case 7:
					return 0f;
				default:
					if (num3 >= buttons.Length)
					{
						return num2;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0019;
		}

		public T GetExtension<T>() where T : class
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			return iKrPwKwbznPAureDUGtpiCKudaT as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num = 0;
			int num2 = 1663807957;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num2 ^ 0x632BB1D6)
				{
				case 0:
					break;
				case 5:
					return null;
				case 3:
				{
					int num3;
					if (num < JbtxvIcGuXUlFtfbnJMGrZPRmBP.Length)
					{
						num2 = 1663807956;
						num3 = num2;
					}
					else
					{
						num2 = 1663807954;
						num3 = num2;
					}
					continue;
				}
				case 1:
					return JbtxvIcGuXUlFtfbnJMGrZPRmBP[num];
				case 2:
					if (!(JbtxvIcGuXUlFtfbnJMGrZPRmBP[num].typeGuid == typeGuid))
					{
						num++;
						num2 = 1663807957;
					}
					else
					{
						num2 = 1663807959;
					}
					continue;
				default:
					return null;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num2 = 1663807955;
			goto IL_001e;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			int num = 0;
			while (num < JbtxvIcGuXUlFtfbnJMGrZPRmBP.Length)
			{
				while (true)
				{
					if (ReflectionTools.DoesTypeImplement(JbtxvIcGuXUlFtfbnJMGrZPRmBP[num].GetType(), type))
					{
						return JbtxvIcGuXUlFtfbnJMGrZPRmBP[num];
					}
					num++;
					int num2 = 2140018026;
					while (true)
					{
						switch (num2 ^ 0x7F8E1568)
						{
						case 0:
							num2 = 2140018025;
							continue;
						case 1:
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

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1976233982;
				while (true)
				{
					switch (num2 ^ -1976233983)
					{
					case 0:
						break;
					case 3:
						num2 = -1976233984;
						continue;
					case 2:
						if (JbtxvIcGuXUlFtfbnJMGrZPRmBP[num] as T != null)
						{
							return JbtxvIcGuXUlFtfbnJMGrZPRmBP[num] as T;
						}
						num++;
						num2 = -1976233984;
						continue;
					default:
						if (num >= JbtxvIcGuXUlFtfbnJMGrZPRmBP.Length)
						{
							return null;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < JbtxvIcGuXUlFtfbnJMGrZPRmBP.Length)
				{
					num2 = 1612785254;
					num3 = num2;
				}
				else
				{
					num2 = 1612785253;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x60212664)
					{
					case 3:
						num2 = 1612785254;
						continue;
					case 0:
						break;
					case 4:
						return true;
					case 2:
						if (!(JbtxvIcGuXUlFtfbnJMGrZPRmBP[num].typeGuid == typeGuid))
						{
							num++;
							num2 = 1612785252;
						}
						else
						{
							num2 = 1612785248;
						}
						continue;
					default:
						return false;
					}
					break;
				}
			}
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_001c;
			}
			int num;
			int num2;
			if ((object)type == null)
			{
				num = -935790284;
				num2 = num;
			}
			else
			{
				num = -935790288;
				num2 = num;
			}
			goto IL_0021;
			IL_001c:
			num = -935790287;
			goto IL_0021;
			IL_0021:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -935790288)
				{
				case 7:
					break;
				case 0:
					num3 = 0;
					num = -935790286;
					continue;
				case 4:
					throw new ArgumentNullException("type");
				case 5:
					return true;
				case 2:
					num = -935790282;
					continue;
				case 3:
					if (!ReflectionTools.DoesTypeImplement(JbtxvIcGuXUlFtfbnJMGrZPRmBP[num3].GetType(), type))
					{
						num3++;
						num = -935790282;
					}
					else
					{
						num = -935790283;
					}
					continue;
				case 1:
					return false;
				default:
					if (num3 >= JbtxvIcGuXUlFtfbnJMGrZPRmBP.Length)
					{
						return false;
					}
					goto case 3;
				}
				break;
			}
			goto IL_001c;
		}

		public bool ImplementsTemplate<T>() where T : class
		{
			return ImplementsTemplate(typeof(T));
		}

		internal void EuTqFaJzSVKiMeLUrTRDniYPAwh(IControllerTemplate[] P_0)
		{
			if (P_0 != null)
			{
				JbtxvIcGuXUlFtfbnJMGrZPRmBP = P_0;
				FnhMJHyFObsTZPxMkmUWbCqhfJe = new ReadOnlyCollection<IControllerTemplate>(JbtxvIcGuXUlFtfbnJMGrZPRmBP);
			}
		}

		internal virtual void UpdateData(UpdateLoopType P_0)
		{
			bool flag = ReInput.IsInputAllowed(_type);
			int num = _buttonCount;
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num2 = -271006099;
				while (true)
				{
					switch (num2 ^ -271006111)
					{
					case 4:
						break;
					default:
						return;
					case 5:
						iKrPwKwbznPAureDUGtpiCKudaT.UpdateData(P_0);
						num2 = -271006102;
						continue;
					case 3:
						num3 = 0;
						num2 = -271006111;
						continue;
					case 8:
					{
						int num7;
						if (buttons[num3].LkBXRcIRlxgWrwXtVCVKVjnvYjI > 0)
						{
							num2 = -271006104;
							num7 = num2;
						}
						else
						{
							num2 = -271006101;
							num7 = num2;
						}
						continue;
					}
					case 1:
						num4++;
						num2 = -271006106;
						continue;
					case 0:
					{
						int num5;
						if (num3 < num)
						{
							num2 = -271006103;
							num5 = num2;
						}
						else
						{
							num2 = -271006109;
							num5 = num2;
						}
						continue;
					}
					case 2:
					{
						int num6;
						if (iKrPwKwbznPAureDUGtpiCKudaT == null)
						{
							num2 = -271006102;
							num6 = num2;
						}
						else
						{
							num2 = -271006108;
							num6 = num2;
						}
						continue;
					}
					case 7:
						if (num4 >= num)
						{
							num2 = -271006109;
							continue;
						}
						goto case 6;
					case 9:
						num3++;
						num2 = -271006111;
						continue;
					case 6:
						if (buttons[num4].LkBXRcIRlxgWrwXtVCVKVjnvYjI <= 0)
						{
							buttons[num4].zxLhCcrlwKIIJANOaByFjYpjSot(P_0, num4, ROoGdHjYclVKlAjCTYtzRRhBjqvj);
							num2 = -271006112;
							continue;
						}
						goto case 1;
					case 12:
						if (flag)
						{
							num4 = 0;
							num2 = -271006106;
							continue;
						}
						goto case 3;
					case 10:
						buttons[num3].ipxYYWTdpzFeXmeGFdTqkEYPkJxg(P_0);
						num2 = -271006104;
						continue;
					case 11:
						return;
					}
					break;
				}
			}
		}

		internal virtual ButtonStateFlags LcYntqEkZSGMagQPrzQLpEoYTPx(int P_0)
		{
			if (P_0 >= 0)
			{
				while (true)
				{
					int num = -1287631942;
					while (true)
					{
						switch (num ^ -1287631944)
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
						if (P_0 >= _buttonCount)
						{
							num = -1287631943;
							continue;
						}
						return buttons[P_0].state;
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr;
		}

		internal void XSCFExJHpLZlPntjxNolSkPZvkYM(Extension P_0)
		{
			if (P_0 == null)
			{
				iKrPwKwbznPAureDUGtpiCKudaT = null;
				goto IL_000a;
			}
			goto IL_004f;
			IL_004f:
			int num;
			int num2;
			if (iKrPwKwbznPAureDUGtpiCKudaT != null)
			{
				num = 92664101;
				num2 = num;
			}
			else
			{
				num = 92664103;
				num2 = num;
			}
			goto IL_000f;
			IL_000a:
			num = 92664096;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num ^ 0x585F121)
				{
				case 5:
					break;
				default:
					return;
				case 1:
					return;
				case 4:
					PtFyTWtbcoQAXecFTjaAQlkNBsW(P_0);
					return;
				case 3:
					goto IL_004f;
				case 0:
					iKrPwKwbznPAureDUGtpiCKudaT = P_0.Clone();
					num = 92664099;
					continue;
				case 6:
					P_0.SetController(this);
					num = 92664097;
					continue;
				case 2:
					return;
				}
				break;
			}
			goto IL_000a;
		}

		internal void PtFyTWtbcoQAXecFTjaAQlkNBsW(Extension P_0)
		{
			if (iKrPwKwbznPAureDUGtpiCKudaT != null)
			{
				iKrPwKwbznPAureDUGtpiCKudaT.SetSource(P_0);
				iKrPwKwbznPAureDUGtpiCKudaT.SetController(this);
				if (P_0 != null)
				{
					P_0.SetController(this);
				}
				return;
			}
			while (true)
			{
				XSCFExJHpLZlPntjxNolSkPZvkYM(P_0);
				int num = -1299442103;
				while (true)
				{
					switch (num ^ -1299442101)
					{
					case 0:
						goto IL_002b;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_002b:
					num = -1299442102;
				}
			}
		}

		internal virtual void Clear()
		{
			int num = 0;
			while (true)
			{
				IL_008a:
				int num2;
				if (num >= _buttonCount)
				{
					int num3;
					if (ROoGdHjYclVKlAjCTYtzRRhBjqvj == null)
					{
						num2 = 1389512365;
						num3 = num2;
					}
					else
					{
						num2 = 1389512366;
						num3 = num2;
					}
					goto IL_000c;
				}
				goto IL_0061;
				IL_0061:
				if (buttons[num] != null)
				{
					buttons[num].Reset();
					num2 = 1389512363;
					goto IL_000c;
				}
				goto IL_007f;
				IL_000c:
				while (true)
				{
					switch (num2 ^ 0x52D246AD)
					{
					case 4:
						num2 = 1389512364;
						continue;
					default:
						return;
					case 0:
						if (iKrPwKwbznPAureDUGtpiCKudaT != null)
						{
							iKrPwKwbznPAureDUGtpiCKudaT.Clear();
							num2 = 1389512360;
							continue;
						}
						return;
					case 3:
						ROoGdHjYclVKlAjCTYtzRRhBjqvj.ClearData();
						num2 = 1389512365;
						continue;
					case 1:
						break;
					case 6:
						goto IL_007f;
					case 2:
						goto IL_008a;
					case 5:
						return;
					}
					break;
				}
				goto IL_0061;
				IL_007f:
				num++;
				num2 = 1389512367;
				goto IL_000c;
			}
		}

		internal virtual bool SetEnabled(bool P_0)
		{
			if (gmbIkkevNmPVGSTIwKcAwoPYANrc == P_0)
			{
				goto IL_0009;
			}
			int num;
			if (!P_0)
			{
				Clear();
				num = -1122736978;
				goto IL_000e;
			}
			goto IL_0041;
			IL_000e:
			while (true)
			{
				switch (num ^ -1122736977)
				{
				case 0:
					break;
				case 3:
					return false;
				case 1:
					goto IL_0041;
				case 4:
					if (keQiiwcvhFUxZCAVksrVOIIyXdA != null)
					{
						keQiiwcvhFUxZCAVksrVOIIyXdA(P_0);
						num = -1122736979;
						continue;
					}
					goto default;
				default:
					return true;
				}
				break;
			}
			goto IL_0009;
			IL_0041:
			gmbIkkevNmPVGSTIwKcAwoPYANrc = P_0;
			num = -1122736981;
			goto IL_000e;
			IL_0009:
			num = -1122736980;
			goto IL_000e;
		}

		internal virtual void BakeMap(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				P_0.controllerId = id;
				P_0.controllerType = _type;
				IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
				int num = 0;
				int num2 = -181182838;
				while (true)
				{
					switch (num2 ^ -181182840)
					{
					case 4:
						num2 = -181182839;
						continue;
					default:
						return;
					case 0:
						BakeActionElementMap(P_0, buttonMaps[num]);
						num++;
						num2 = -181182835;
						continue;
					case 5:
					{
						int num3;
						if (num >= buttonMaps.Count)
						{
							num2 = -181182837;
							num3 = num2;
						}
						else
						{
							num2 = -181182840;
							num3 = num2;
						}
						continue;
					}
					case 1:
						break;
					case 2:
						num2 = -181182835;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		internal virtual void BakeActionElementMap(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null && P_1._elementType == ControllerElementType.Button)
			{
				P_1.rlmHPtRaQxhZqxiQpUHlvKLFmAK(P_0);
			}
		}

		internal bool QThDXhjpsbVRSNcnIBYFASLVOMr(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			int zwgAVZCxcUqkUVeFEgwfcqhdLwxy = default(int);
			float num2 = default(float);
			while (true)
			{
				int num = 112464471;
				while (true)
				{
					switch (num ^ 0x6B41255)
					{
					case 3:
						break;
					case 10:
					{
						int num6;
						if (P_0._elementType != ControllerElementType.Axis)
						{
							num = 112464472;
							num6 = num;
						}
						else
						{
							num = 112464466;
							num6 = num;
						}
						continue;
					}
					case 7:
						if (P_0._axisRange == AxisRange.Full)
						{
							int num4;
							if (!P_0._invert)
							{
								num = 112464472;
								num4 = num;
							}
							else
							{
								num = 112464475;
								num4 = num;
							}
							continue;
						}
						goto case 4;
					case 9:
						if (P_1 != P_0._actionId)
						{
							return false;
						}
						zwgAVZCxcUqkUVeFEgwfcqhdLwxy = P_0.ZwgAVZCxcUqkUVeFEgwfcqhdLwxy;
						num = 112464464;
						continue;
					case 8:
						return false;
					case 4:
						if (P_0._axisContribution == Pole.Negative)
						{
							num2 *= -1f;
							num = 112464472;
							continue;
						}
						goto default;
					case 2:
						P_2 = 0f;
						num = 112464476;
						continue;
					case 11:
						if (num2 > 0f)
						{
							if (P_0._elementType != ControllerElementType.Button)
							{
								goto case 10;
							}
							if (P_0._axisContribution == Pole.Negative)
							{
								num2 *= -1f;
								num = 112464472;
								continue;
							}
						}
						goto default;
					case 0:
						num2 = buttons[zwgAVZCxcUqkUVeFEgwfcqhdLwxy].pressure;
						num = 112464468;
						continue;
					case 12:
						if (zwgAVZCxcUqkUVeFEgwfcqhdLwxy < _buttonCount)
						{
							P_3 = buttons[zwgAVZCxcUqkUVeFEgwfcqhdLwxy].pSQAxQmplxiUZUyeQhcyDLZUatX;
							int num5;
							if (P_3)
							{
								num = 112464469;
								num5 = num;
							}
							else
							{
								num = 112464467;
								num5 = num;
							}
						}
						else
						{
							num = 112464477;
						}
						continue;
					case 14:
						num2 *= -1f;
						num = 112464472;
						continue;
					case 5:
					{
						int num3;
						if (zwgAVZCxcUqkUVeFEgwfcqhdLwxy >= 0)
						{
							num = 112464473;
							num3 = num;
						}
						else
						{
							num = 112464477;
							num3 = num;
						}
						continue;
					}
					case 1:
						num = 112464478;
						continue;
					case 6:
						num2 = (buttons[zwgAVZCxcUqkUVeFEgwfcqhdLwxy].value ? 1f : 0f);
						num = 112464478;
						continue;
					default:
						P_2 = num2;
						return true;
					}
					break;
				}
			}
		}

		internal bool QThDXhjpsbVRSNcnIBYFASLVOMr(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
		{
			P_3 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			float num = (P_2 ? 1f : 0f);
			while (true)
			{
				int num2 = 510964909;
				while (true)
				{
					switch (num2 ^ 0x1E74B4A9)
					{
					case 6:
						break;
					case 4:
						if (num > 0f)
						{
							int num5;
							if (P_0._elementType != ControllerElementType.Button)
							{
								num2 = 510964905;
								num5 = num2;
							}
							else
							{
								num2 = 510964904;
								num5 = num2;
							}
							continue;
						}
						goto default;
					case 7:
						if (P_0._axisContribution == Pole.Negative)
						{
							num *= -1f;
							num2 = 510964906;
							continue;
						}
						goto default;
					case 0:
					{
						int num3;
						if (P_0._elementType == ControllerElementType.Axis)
						{
							num2 = 510964908;
							num3 = num2;
						}
						else
						{
							num2 = 510964906;
							num3 = num2;
						}
						continue;
					}
					case 5:
						if (P_0._axisRange == AxisRange.Full)
						{
							int num4;
							if (P_0._invert)
							{
								num2 = 510964907;
								num4 = num2;
							}
							else
							{
								num2 = 510964906;
								num4 = num2;
							}
							continue;
						}
						goto case 7;
					case 2:
						num *= -1f;
						num2 = 510964906;
						continue;
					case 1:
						if (P_0._axisContribution == Pole.Negative)
						{
							num *= -1f;
							num2 = 510964906;
							continue;
						}
						goto default;
					default:
						P_3 = num;
						return true;
					}
					break;
				}
			}
		}

		internal void DaOirHIMrqCgwPvMGCDKpJCcEFCO(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(zGVdLCAPoSECGnwSmQQzpAttLxeB, P_0);
			}
		}

		internal virtual Guid xDtkNqWrxpCvpIAGzCQshiXNIIuy()
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
			if (ROoGdHjYclVKlAjCTYtzRRhBjqvj != null)
			{
				ROoGdHjYclVKlAjCTYtzRRhBjqvj.ClearData();
			}
		}

		[CompilerGenerated]
		private static bool ApOvtgFlFreNYezGcYxguySyqIfM(Controller P_0, Guid P_1)
		{
			return P_0.ImplementsTemplate(P_1);
		}

		[CompilerGenerated]
		private static bool knkmDwfpFXainakJnkkcHEVmwHN(Controller P_0, Type P_1)
		{
			return P_0.ImplementsTemplate(P_1);
		}
	}
}
