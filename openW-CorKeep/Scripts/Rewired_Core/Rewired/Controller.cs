using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class Controller
	{
		public abstract class Element
		{
			internal abstract class qqXRLoVtgcRoeoNiSJGKihhnzGWi
			{
				public abstract class hpWyEOsyUBevzBDMSfSKCYBNKrDfA
				{
					public abstract void RuaOZiEugbiwKHPlZEoXeEtstRg();
				}

				protected readonly int XHXQkCDNbvZVdXZqojgcTDgRUJTN;

				protected readonly int[] GGIzKgKkZsvOaurAdfTjdSshaOUHb;

				protected hpWyEOsyUBevzBDMSfSKCYBNKrDfA[] JIxtwIMmRDGYjrbaehsgSrHyRddd;

				public hpWyEOsyUBevzBDMSfSKCYBNKrDfA DvrMnzmivppXkQIJbPRnwloCOzOv;

				private int zAmDicRPNHjqLVKBIGPYDrAoTNecA;

				public int uJePmjkNCKUheCRoJmiTXljvPPKN = -1;

				protected ReadOnlyCollection<hpWyEOsyUBevzBDMSfSKCYBNKrDfA> qZfecVEqBHvFHoejUmFeEiiDPgepA;

				public IList<hpWyEOsyUBevzBDMSfSKCYBNKrDfA> hXmFqqUcbyURCBLWzfLrWpaqVzc => qZfecVEqBHvFHoejUmFeEiiDPgepA;

				public UpdateLoopType wKPazGtXcJidbhhvYzSOjIiNKgYCA
				{
					set
					{
						if (uJePmjkNCKUheCRoJmiTXljvPPKN != (int)updateLoopType)
						{
							uJePmjkNCKUheCRoJmiTXljvPPKN = (int)updateLoopType;
							zAmDicRPNHjqLVKBIGPYDrAoTNecA = GGIzKgKkZsvOaurAdfTjdSshaOUHb[(int)updateLoopType];
							DvrMnzmivppXkQIJbPRnwloCOzOv = JIxtwIMmRDGYjrbaehsgSrHyRddd[zAmDicRPNHjqLVKBIGPYDrAoTNecA];
						}
					}
				}

				public qqXRLoVtgcRoeoNiSJGKihhnzGWi(UpdateLoopSetting P_0)
				{
					GGIzKgKkZsvOaurAdfTjdSshaOUHb = new int[3];
					XHXQkCDNbvZVdXZqojgcTDgRUJTN = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(P_0, list);
						for (int i = 0; i < list.Count; i++)
						{
							GGIzKgKkZsvOaurAdfTjdSshaOUHb[(int)list[i]] = XHXQkCDNbvZVdXZqojgcTDgRUJTN;
							XHXQkCDNbvZVdXZqojgcTDgRUJTN++;
						}
					}
					JIxtwIMmRDGYjrbaehsgSrHyRddd = new hpWyEOsyUBevzBDMSfSKCYBNKrDfA[XHXQkCDNbvZVdXZqojgcTDgRUJTN];
					qZfecVEqBHvFHoejUmFeEiiDPgepA = new ReadOnlyCollection<hpWyEOsyUBevzBDMSfSKCYBNKrDfA>(JIxtwIMmRDGYjrbaehsgSrHyRddd);
				}

				public void HKbhaMHGcWpqwtijWDxZbNWHJGxXA()
				{
					for (int i = 0; i < XHXQkCDNbvZVdXZqojgcTDgRUJTN; i++)
					{
						JIxtwIMmRDGYjrbaehsgSrHyRddd[i].RuaOZiEugbiwKHPlZEoXeEtstRg();
					}
				}

				public hpWyEOsyUBevzBDMSfSKCYBNKrDfA KWbcTdPbQUtLilmhhTRVLplIZlbk(UpdateLoopType P_0)
				{
					return JIxtwIMmRDGYjrbaehsgSrHyRddd[GGIzKgKkZsvOaurAdfTjdSshaOUHb[(int)P_0]];
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal qqXRLoVtgcRoeoNiSJGKihhnzGWi ssmnmYuoyqoDXsayoQPZkxOrBGDH;

			internal int mtgepFFkBbbfzOBezhkfkZRJhmJm;

			internal Controller EgUglMdQPxeOPRBRobiAurmBPQhJ;

			internal readonly int nwEpkxquWpKWNoklzPTreittQBEt;

			private CompoundElement QWxOCDIcKbJRPDTrGAamZLpOMxeo;

			private bool iaAJTSYqSBSUvsgCslPouCdJFoZY;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = EgUglMdQPxeOPRBRobiAurmBPQhJ.GetElementIdentifierById(id);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			public virtual bool excludeFromPolling
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return false;
					}
					return iaAJTSYqSBSUvsgCslPouCdJFoZY;
				}
				set
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
					}
					else
					{
						iaAJTSYqSBSUvsgCslPouCdJFoZY = value;
					}
				}
			}

			public bool isMemberElement
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return false;
					}
					return mtgepFFkBbbfzOBezhkfkZRJhmJm > 0;
				}
			}

			public CompoundElement compoundElement => QWxOCDIcKbJRPDTrGAamZLpOMxeo;

			internal Element(Controller P_0, int P_1, string P_2, ControllerElementType P_3)
			{
				EgUglMdQPxeOPRBRobiAurmBPQhJ = P_0;
				id = P_1;
				name = P_2;
				type = P_3;
				nwEpkxquWpKWNoklzPTreittQBEt = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
				{
					ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
				}
				else if (ssmnmYuoyqoDXsayoQPZkxOrBGDH != null)
				{
					ssmnmYuoyqoDXsayoQPZkxOrBGDH.HKbhaMHGcWpqwtijWDxZbNWHJGxXA();
				}
			}

			internal void nkQJswJcKkgKmPckxKjWURopGUAE(CompoundElement P_0)
			{
				if (mtgepFFkBbbfzOBezhkfkZRJhmJm > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				mtgepFFkBbbfzOBezhkfkZRJhmJm++;
				if (QWxOCDIcKbJRPDTrGAamZLpOMxeo == null)
				{
					QWxOCDIcKbJRPDTrGAamZLpOMxeo = P_0;
				}
			}

			internal void ckzpDMRLbekLjwGcJWInRUssmUHn(CompoundElement P_0)
			{
				if (mtgepFFkBbbfzOBezhkfkZRJhmJm == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					mtgepFFkBbbfzOBezhkfkZRJhmJm = 0;
					return;
				}
				mtgepFFkBbbfzOBezhkfkZRJhmJm--;
				if (QWxOCDIcKbJRPDTrGAamZLpOMxeo == P_0)
				{
					QWxOCDIcKbJRPDTrGAamZLpOMxeo = null;
				}
			}
		}

		public sealed class Axis : Element
		{
			internal class hWVKRrLIkuteosFcsEnvvQBLOTnu : qqXRLoVtgcRoeoNiSJGKihhnzGWi
			{
				public class aLSJZClgQphnxWerjgUDoxtyOrv : hpWyEOsyUBevzBDMSfSKCYBNKrDfA
				{
					private const float sOYpzpfPdVjMMJkMHWfpUEJubmlJA = 0.001f;

					public float kVpKSsyCkQciPodjXaOYdYuZesYv;

					public float MoPijSaVDdtphIjqgmnZlXBrRgzF;

					public float lJoARzHTjeIlodWfBBKoDgoeUEgg;

					public float UdUMcsDuPigmELBMYOaxdPNdTWIm;

					public float HpxmPWtnCYwizmnBlBwybiIychoXA;

					public float qHktINFMsQDaoHIzWjTfKniwCkeZ;

					public double MoRhVtXkvrXPXQPuzkWwAmTrNdhI;

					public double gLcrLGzxegbtMsaLTBkicgMLmoPl;

					public double tHMBrHzYJxRZTvQxtTHmRjIjIMjdA;

					public double JjWhKSchcBGNtgohVrxJwcCwdHZo;

					public double NzZSfsPeXpciQniydMwZhAJHZmdp;

					public double aQMCtlwyntmrPZbRqclmCKuVuAygA;

					public double HFADtlQYTrGQQZoGxOCzpRHrSRjs
					{
						get
						{
							if ((double)kVpKSsyCkQciPodjXaOYdYuZesYv == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - tHMBrHzYJxRZTvQxtTHmRjIjIMjdA;
						}
					}

					public double SEMjkJuUMAZcamBFwVMHugJdODux
					{
						get
						{
							if ((double)lJoARzHTjeIlodWfBBKoDgoeUEgg == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - JjWhKSchcBGNtgohVrxJwcCwdHZo;
						}
					}

					public double lZPajYxYvDhwtvkwggaPhdfMgmQA
					{
						get
						{
							if (kVpKSsyCkQciPodjXaOYdYuZesYv != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - MoRhVtXkvrXPXQPuzkWwAmTrNdhI;
						}
					}

					public double HFVMzVNbXtDBACfFQZsErrnGCXwY
					{
						get
						{
							if ((double)lJoARzHTjeIlodWfBBKoDgoeUEgg != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - gLcrLGzxegbtMsaLTBkicgMLmoPl;
						}
					}

					public void TCKWTbTuqCWSEelkhASlZCzKcwDJ(bool P_0)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (!MathTools.Approximately(HpxmPWtnCYwizmnBlBwybiIychoXA, 0f))
							{
								MoRhVtXkvrXPXQPuzkWwAmTrNdhI = unscaledTime;
							}
							else
							{
								tHMBrHzYJxRZTvQxtTHmRjIjIMjdA = unscaledTime;
							}
							if (!MathTools.IsNear(HpxmPWtnCYwizmnBlBwybiIychoXA, qHktINFMsQDaoHIzWjTfKniwCkeZ, 0.001f))
							{
								NzZSfsPeXpciQniydMwZhAJHZmdp = unscaledTime;
							}
						}
						else
						{
							if (!MathTools.Approximately(kVpKSsyCkQciPodjXaOYdYuZesYv, 0f))
							{
								MoRhVtXkvrXPXQPuzkWwAmTrNdhI = unscaledTime;
							}
							else
							{
								tHMBrHzYJxRZTvQxtTHmRjIjIMjdA = unscaledTime;
							}
							if (!MathTools.IsNear(kVpKSsyCkQciPodjXaOYdYuZesYv, MoPijSaVDdtphIjqgmnZlXBrRgzF, 0.001f))
							{
								NzZSfsPeXpciQniydMwZhAJHZmdp = unscaledTime;
							}
						}
						if (!MathTools.Approximately(lJoARzHTjeIlodWfBBKoDgoeUEgg, 0f))
						{
							gLcrLGzxegbtMsaLTBkicgMLmoPl = unscaledTime;
						}
						else
						{
							JjWhKSchcBGNtgohVrxJwcCwdHZo = unscaledTime;
						}
						if (!MathTools.IsNear(lJoARzHTjeIlodWfBBKoDgoeUEgg, UdUMcsDuPigmELBMYOaxdPNdTWIm, 0.001f))
						{
							aQMCtlwyntmrPZbRqclmCKuVuAygA = unscaledTime;
						}
					}

					public void raIaCoWwinxRrQjmQJzZFuduUGIv(float P_0)
					{
						if (UdUMcsDuPigmELBMYOaxdPNdTWIm != lJoARzHTjeIlodWfBBKoDgoeUEgg)
						{
							UdUMcsDuPigmELBMYOaxdPNdTWIm = lJoARzHTjeIlodWfBBKoDgoeUEgg;
						}
						if (lJoARzHTjeIlodWfBBKoDgoeUEgg != P_0)
						{
							lJoARzHTjeIlodWfBBKoDgoeUEgg = P_0;
						}
					}

					public virtual void wLWTbvwqooiVxbyQyCXrEnFTReYtA()
					{
						kVpKSsyCkQciPodjXaOYdYuZesYv = 0f;
						MoPijSaVDdtphIjqgmnZlXBrRgzF = 0f;
						lJoARzHTjeIlodWfBBKoDgoeUEgg = 0f;
						UdUMcsDuPigmELBMYOaxdPNdTWIm = 0f;
						MoRhVtXkvrXPXQPuzkWwAmTrNdhI = 0.0;
						gLcrLGzxegbtMsaLTBkicgMLmoPl = 0.0;
						tHMBrHzYJxRZTvQxtTHmRjIjIMjdA = 0.0;
						JjWhKSchcBGNtgohVrxJwcCwdHZo = 0.0;
						NzZSfsPeXpciQniydMwZhAJHZmdp = 0.0;
						aQMCtlwyntmrPZbRqclmCKuVuAygA = 0.0;
					}
				}

				public hWVKRrLIkuteosFcsEnvvQBLOTnu(UpdateLoopSetting P_0)
					: base(P_0)
				{
					for (int i = 0; i < XHXQkCDNbvZVdXZqojgcTDgRUJTN; i++)
					{
						JIxtwIMmRDGYjrbaehsgSrHyRddd[i] = new aLSJZClgQphnxWerjgUDoxtyOrv();
					}
					DvrMnzmivppXkQIJbPRnwloCOzOv = JIxtwIMmRDGYjrbaehsgSrHyRddd[0];
				}
			}

			internal readonly AxisRange vQVWQODTtYDJhMAOompwwfAYOfOW;

			internal readonly HardwareAxisInfo ebyrXyRCdWERLtGljixMusqSBzocA;

			public float value
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).HpxmPWtnCYwizmnBlBwybiIychoXA;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).kVpKSsyCkQciPodjXaOYdYuZesYv;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).qHktINFMsQDaoHIzWjTfKniwCkeZ;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).MoPijSaVDdtphIjqgmnZlXBrRgzF;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0f;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).lJoARzHTjeIlodWfBBKoDgoeUEgg;
				}
				internal set
				{
					((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).raIaCoWwinxRrQjmQJzZFuduUGIv(num);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0f;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).UdUMcsDuPigmELBMYOaxdPNdTWIm;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0f;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).lJoARzHTjeIlodWfBBKoDgoeUEgg - ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).UdUMcsDuPigmELBMYOaxdPNdTWIm;
				}
			}

			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).MoRhVtXkvrXPXQPuzkWwAmTrNdhI;
				}
			}

			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).gLcrLGzxegbtMsaLTBkicgMLmoPl;
				}
			}

			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).tHMBrHzYJxRZTvQxtTHmRjIjIMjdA;
				}
			}

			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).JjWhKSchcBGNtgohVrxJwcCwdHZo;
				}
			}

			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).NzZSfsPeXpciQniydMwZhAJHZmdp;
				}
			}

			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).aQMCtlwyntmrPZbRqclmCKuVuAygA;
				}
			}

			public double timeActive
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).HFADtlQYTrGQQZoGxOCzpRHrSRjs;
				}
			}

			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).HFADtlQYTrGQQZoGxOCzpRHrSRjs;
				}
			}

			public double timeInactive
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).lZPajYxYvDhwtvkwggaPhdfMgmQA;
				}
			}

			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).HFVMzVNbXtDBACfFQZsErrnGCXwY;
				}
			}

			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0f;
					}
					if (ebyrXyRCdWERLtGljixMusqSBzocA == null)
					{
						return -1f;
					}
					return ebyrXyRCdWERLtGljixMusqSBzocA._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return;
					}
					if (value < 0f)
					{
						value = -1f;
					}
					if (ebyrXyRCdWERLtGljixMusqSBzocA != null)
					{
						ebyrXyRCdWERLtGljixMusqSBzocA._pollingDeadZone = value;
					}
				}
			}

			public AxisCoordinateMode axisCoordinateMode
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return AxisCoordinateMode.Absolute;
					}
					if (ebyrXyRCdWERLtGljixMusqSBzocA == null)
					{
						return AxisCoordinateMode.Absolute;
					}
					return ebyrXyRCdWERLtGljixMusqSBzocA.dataFormat;
				}
			}

			bool Element.excludeFromPolling
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return false;
					}
					if (ebyrXyRCdWERLtGljixMusqSBzocA == null)
					{
						return base.excludeFromPolling;
					}
					return ebyrXyRCdWERLtGljixMusqSBzocA._excludeFromPolling;
				}
				set
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return;
					}
					if (ebyrXyRCdWERLtGljixMusqSBzocA != null)
					{
						ebyrXyRCdWERLtGljixMusqSBzocA._excludeFromPolling = value;
					}
					base.excludeFromPolling = value;
				}
			}

			internal float GvJcmFjsInZElrmTXwwrrEiFCBSs => ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).kVpKSsyCkQciPodjXaOYdYuZesYv;

			internal float HVgYMawPQbEioKWVGbwzHUPNiOSA => ((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).MoPijSaVDdtphIjqgmnZlXBrRgzF;

			internal float SmvTuJjdsvGiWKjCocbBJtqzCOoGb
			{
				get
				{
					if (ebyrXyRCdWERLtGljixMusqSBzocA == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (ebyrXyRCdWERLtGljixMusqSBzocA._pollingDeadZone >= 0f)
					{
						return ebyrXyRCdWERLtGljixMusqSBzocA._pollingDeadZone;
					}
					return ebyrXyRCdWERLtGljixMusqSBzocA._dataFormat switch
					{
						AxisCoordinateMode.Absolute => ReInput.configuration.defaultAbsoluteAxisPollingDeadZone, 
						AxisCoordinateMode.Relative => ReInput.configuration.defaultRelativeAxisPollingDeadZone, 
						_ => throw new NotImplementedException(), 
					};
				}
			}

			internal void HnxcKLIzwFRQRPCrBvmodpXcDjafA(float P_0)
			{
				hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv obj = (hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv;
				obj.qHktINFMsQDaoHIzWjTfKniwCkeZ = obj.HpxmPWtnCYwizmnBlBwybiIychoXA;
				obj.HpxmPWtnCYwizmnBlBwybiIychoXA = P_0;
			}

			internal Axis(Controller P_0, int P_1, string P_2, AxisRange P_3, HardwareAxisInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Axis)
			{
				ssmnmYuoyqoDXsayoQPZkxOrBGDH = new hWVKRrLIkuteosFcsEnvvQBLOTnu(ReInput.configVars.updateLoop);
				vQVWQODTtYDJhMAOompwwfAYOfOW = P_3;
				ebyrXyRCdWERLtGljixMusqSBzocA = P_4;
				if (P_4 != null)
				{
					base.excludeFromPolling = P_4._excludeFromPolling;
				}
			}

			internal void wPsCzZJFDWpCmNuMISEngmqiBGZT(UpdateLoopType P_0)
			{
				if (ssmnmYuoyqoDXsayoQPZkxOrBGDH != null && ssmnmYuoyqoDXsayoQPZkxOrBGDH.uJePmjkNCKUheCRoJmiTXljvPPKN != (int)P_0)
				{
					ssmnmYuoyqoDXsayoQPZkxOrBGDH.wKPazGtXcJidbhhvYzSOjIiNKgYCA = P_0;
				}
			}

			internal void WiuIRREiNdjLluouzVONaTtkKWRc(AxisCalibration P_0)
			{
				hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv aLSJZClgQphnxWerjgUDoxtyOrv = (hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv;
				aLSJZClgQphnxWerjgUDoxtyOrv.MoPijSaVDdtphIjqgmnZlXBrRgzF = aLSJZClgQphnxWerjgUDoxtyOrv.kVpKSsyCkQciPodjXaOYdYuZesYv;
				float kVpKSsyCkQciPodjXaOYdYuZesYv = P_0.GetCalibratedValue(aLSJZClgQphnxWerjgUDoxtyOrv.lJoARzHTjeIlodWfBBKoDgoeUEgg, vQVWQODTtYDJhMAOompwwfAYOfOW);
				if (P_0.applyRangeCalibration)
				{
					kVpKSsyCkQciPodjXaOYdYuZesYv = MathTools.Clamp(kVpKSsyCkQciPodjXaOYdYuZesYv, -1f, 1f);
				}
				aLSJZClgQphnxWerjgUDoxtyOrv.kVpKSsyCkQciPodjXaOYdYuZesYv = kVpKSsyCkQciPodjXaOYdYuZesYv;
			}

			internal void DhAxZRUSVKOYdBFkCGkUGAEAxrbO()
			{
				hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv obj = (hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv;
				obj.MoPijSaVDdtphIjqgmnZlXBrRgzF = obj.kVpKSsyCkQciPodjXaOYdYuZesYv;
				obj.kVpKSsyCkQciPodjXaOYdYuZesYv = obj.lJoARzHTjeIlodWfBBKoDgoeUEgg;
			}

			internal void RiSdiqsoaiDGNHSwAaDhIdqgAhWOc()
			{
				hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv obj = (hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv;
				obj.MoPijSaVDdtphIjqgmnZlXBrRgzF = obj.kVpKSsyCkQciPodjXaOYdYuZesYv;
				obj.kVpKSsyCkQciPodjXaOYdYuZesYv = 0f;
			}

			internal void erykXwnhCjHGcCSHwCPpvElCcdRl()
			{
				((hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).TCKWTbTuqCWSEelkhASlZCzKcwDJ(base.isMemberElement);
			}

			internal void DhhRKMjyPctPqALtBrNpxkWLqkYf(float P_0)
			{
				for (int i = 0; i < ssmnmYuoyqoDXsayoQPZkxOrBGDH.hXmFqqUcbyURCBLWzfLrWpaqVzc.Count; i++)
				{
					if (ssmnmYuoyqoDXsayoQPZkxOrBGDH.hXmFqqUcbyURCBLWzfLrWpaqVzc[i] is hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv aLSJZClgQphnxWerjgUDoxtyOrv)
					{
						aLSJZClgQphnxWerjgUDoxtyOrv.raIaCoWwinxRrQjmQJzZFuduUGIv(P_0);
						aLSJZClgQphnxWerjgUDoxtyOrv.MoPijSaVDdtphIjqgmnZlXBrRgzF = aLSJZClgQphnxWerjgUDoxtyOrv.kVpKSsyCkQciPodjXaOYdYuZesYv;
						aLSJZClgQphnxWerjgUDoxtyOrv.kVpKSsyCkQciPodjXaOYdYuZesYv = 0f;
						aLSJZClgQphnxWerjgUDoxtyOrv.TCKWTbTuqCWSEelkhASlZCzKcwDJ(base.isMemberElement);
					}
				}
			}

			internal float NVhFHgICrpXZGlgedhWyyrseplHVA(UpdateLoopType P_0, AxisCalibration P_1)
			{
				hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv aLSJZClgQphnxWerjgUDoxtyOrv = (hWVKRrLIkuteosFcsEnvvQBLOTnu.aLSJZClgQphnxWerjgUDoxtyOrv)ssmnmYuoyqoDXsayoQPZkxOrBGDH.KWbcTdPbQUtLilmhhTRVLplIZlbk(P_0);
				float result = P_1.GetCalibratedValue(aLSJZClgQphnxWerjgUDoxtyOrv.lJoARzHTjeIlodWfBBKoDgoeUEgg, vQVWQODTtYDJhMAOompwwfAYOfOW, P_1.deadZone, applySensitivity: false, applyInversion: true);
				if (P_1.applyRangeCalibration)
				{
					result = MathTools.Clamp(result, -1f, 1f);
				}
				return result;
			}
		}

		public sealed class Button : Element
		{
			internal class oAILDhzHsiGjFkKuMwnZSvGAejjEb : qqXRLoVtgcRoeoNiSJGKihhnzGWi
			{
				public class GCuVMYSfiKsQxdQVnjXyTifTIynu : hpWyEOsyUBevzBDMSfSKCYBNKrDfA
				{
					public bool dnINCqbYIyNvkNGscfXUOxLbHTHs;

					public bool qIURxrDqNbvJBVnJEVMCOlVBsdNi;

					public ButtonStateRecorder DoSZeJCJnnwsOhfiffbrGOYMnguc;

					public fwgpkkVYoNAFmlbuEbPeeOUPnFXHb qUCobUyxfvbiOIZsURUBLIfvnFfN;

					public GCuVMYSfiKsQxdQVnjXyTifTIynu()
					{
						DoSZeJCJnnwsOhfiffbrGOYMnguc = new ButtonStateRecorder();
						qUCobUyxfvbiOIZsURUBLIfvnFfN = new fwgpkkVYoNAFmlbuEbPeeOUPnFXHb(0.3f);
					}

					public void CZhOGDskHjWpUTHsLiOKNiXiPoVX(bool P_0)
					{
						if (qIURxrDqNbvJBVnJEVMCOlVBsdNi != dnINCqbYIyNvkNGscfXUOxLbHTHs)
						{
							qIURxrDqNbvJBVnJEVMCOlVBsdNi = dnINCqbYIyNvkNGscfXUOxLbHTHs;
						}
						if (dnINCqbYIyNvkNGscfXUOxLbHTHs != P_0)
						{
							dnINCqbYIyNvkNGscfXUOxLbHTHs = P_0;
						}
						DoSZeJCJnnwsOhfiffbrGOYMnguc.TQVHXZTTnVnCrXKqBGihJnmuALTr(P_0 && !qIURxrDqNbvJBVnJEVMCOlVBsdNi, P_0, ReInput.unscaledTime);
						qUCobUyxfvbiOIZsURUBLIfvnFfN.rNmbHjFHRlGogPKUDcZPBipUcGhXA(0.3f, P_0 && !qIURxrDqNbvJBVnJEVMCOlVBsdNi, P_0);
					}

					public virtual void DCXWMGsqCxgmCjkDjkoYQJtyWRWL()
					{
						dnINCqbYIyNvkNGscfXUOxLbHTHs = false;
						qIURxrDqNbvJBVnJEVMCOlVBsdNi = false;
						DoSZeJCJnnwsOhfiffbrGOYMnguc.nXfmKYxLIxVpOYBBHUzZskkDeadL();
						qUCobUyxfvbiOIZsURUBLIfvnFfN.EmqEpYjtRDpFlZvsoamAAiiRHhVj();
					}
				}

				public class RXlFBcbObyrmcqzuMgTHOSHQfjEyA : GCuVMYSfiKsQxdQVnjXyTifTIynu
				{
					public float LncThhNXfHCusJfuGGXAHRBIgAzEA;

					public float fxBWvhVQfAfgePxJfoChiucJoTLe;

					public void ZiZdoFUDLFVsNGHBDyfTTiqdAWFX(float P_0)
					{
						if (fxBWvhVQfAfgePxJfoChiucJoTLe != LncThhNXfHCusJfuGGXAHRBIgAzEA)
						{
							fxBWvhVQfAfgePxJfoChiucJoTLe = LncThhNXfHCusJfuGGXAHRBIgAzEA;
						}
						if (LncThhNXfHCusJfuGGXAHRBIgAzEA != P_0)
						{
							LncThhNXfHCusJfuGGXAHRBIgAzEA = ((P_0 > 0.001f) ? P_0 : 0f);
						}
						CZhOGDskHjWpUTHsLiOKNiXiPoVX(LncThhNXfHCusJfuGGXAHRBIgAzEA > 0f);
					}

					public virtual void FabqPtCIBQhmzfaFDjAEQVlkqbpy()
					{
						DCXWMGsqCxgmCjkDjkoYQJtyWRWL();
						LncThhNXfHCusJfuGGXAHRBIgAzEA = 0f;
						fxBWvhVQfAfgePxJfoChiucJoTLe = 0f;
					}
				}

				public oAILDhzHsiGjFkKuMwnZSvGAejjEb(UpdateLoopSetting P_0, bool P_1)
					: base(P_0)
				{
					for (int i = 0; i < XHXQkCDNbvZVdXZqojgcTDgRUJTN; i++)
					{
						if (P_1)
						{
							JIxtwIMmRDGYjrbaehsgSrHyRddd[i] = new RXlFBcbObyrmcqzuMgTHOSHQfjEyA();
						}
						else
						{
							JIxtwIMmRDGYjrbaehsgSrHyRddd[i] = new GCuVMYSfiKsQxdQVnjXyTifTIynu();
						}
					}
					DvrMnzmivppXkQIJbPRnwloCOzOv = JIxtwIMmRDGYjrbaehsgSrHyRddd[0];
				}

				public void QIzxokAAswFPTySJsGmYyWpnTEHr(float P_0)
				{
					for (int i = 0; i < JIxtwIMmRDGYjrbaehsgSrHyRddd.Length; i++)
					{
						((GCuVMYSfiKsQxdQVnjXyTifTIynu)JIxtwIMmRDGYjrbaehsgSrHyRddd[i]).qUCobUyxfvbiOIZsURUBLIfvnFfN.ZWtXVZgMVMqGbRwUXeFWsbSQuzp(P_0);
					}
				}

				public void zXbmVYegGStNKPAaIgOtYqBcurBb()
				{
					for (int i = 0; i < JIxtwIMmRDGYjrbaehsgSrHyRddd.Length; i++)
					{
						((GCuVMYSfiKsQxdQVnjXyTifTIynu)JIxtwIMmRDGYjrbaehsgSrHyRddd[i]).qUCobUyxfvbiOIZsURUBLIfvnFfN.ZWtXVZgMVMqGbRwUXeFWsbSQuzp(0.3f);
					}
				}
			}

			internal readonly bool vznhzgUaUgIIXzJXsvveSoXuPUAv;

			internal readonly HardwareButtonInfo qChIJtMmxeHxmgKkaWmKUQWKYHgb;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return false;
					}
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).qIURxrDqNbvJBVnJEVMCOlVBsdNi;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return false;
					}
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).dnINCqbYIyNvkNGscfXUOxLbHTHs;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0f;
					}
					if (!vznhzgUaUgIIXzJXsvveSoXuPUAv)
					{
						if (!((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).dnINCqbYIyNvkNGscfXUOxLbHTHs)
						{
							return 0f;
						}
						return 1f;
					}
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.RXlFBcbObyrmcqzuMgTHOSHQfjEyA)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).LncThhNXfHCusJfuGGXAHRBIgAzEA;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0f;
					}
					if (!vznhzgUaUgIIXzJXsvveSoXuPUAv)
					{
						if (!((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).qIURxrDqNbvJBVnJEVMCOlVBsdNi)
						{
							return 0f;
						}
						return 1f;
					}
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.RXlFBcbObyrmcqzuMgTHOSHQfjEyA)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).fxBWvhVQfAfgePxJfoChiucJoTLe;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return false;
					}
					return vznhzgUaUgIIXzJXsvveSoXuPUAv;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return false;
					}
					if (!((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).qIURxrDqNbvJBVnJEVMCOlVBsdNi && ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).dnINCqbYIyNvkNGscfXUOxLbHTHs)
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
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return false;
					}
					if (((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).qIURxrDqNbvJBVnJEVMCOlVBsdNi && !((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).dnINCqbYIyNvkNGscfXUOxLbHTHs)
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
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return false;
					}
					if (((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).qIURxrDqNbvJBVnJEVMCOlVBsdNi != ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).dnINCqbYIyNvkNGscfXUOxLbHTHs)
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
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return false;
					}
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).qUCobUyxfvbiOIZsURUBLIfvnFfN.wUDNPwwPaWEMjkBsGfBsCoHKiHedA;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).qUCobUyxfvbiOIZsURUBLIfvnFfN.wUDNPwwPaWEMjkBsGfBsCoHKiHedA;
				}
			}

			public double timePressed
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).DoSZeJCJnnwsOhfiffbrGOYMnguc.lcPOejofHUKkHmNVOzIWdluiEZuE;
				}
			}

			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).DoSZeJCJnnwsOhfiffbrGOYMnguc.PVRFcEDbsULYKIiMnTjQrlaxGwFuA;
				}
			}

			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).DoSZeJCJnnwsOhfiffbrGOYMnguc.DBdhwlFbclgPfDiqdcoERiCYHMDF;
				}
			}

			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).DoSZeJCJnnwsOhfiffbrGOYMnguc.DlkBdNFxkymQCHBhxpaTHVOcRdAwA;
				}
			}

			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
					{
						ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
						return 0.0;
					}
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).DoSZeJCJnnwsOhfiffbrGOYMnguc.JmzHnxQfIFUERjDeBBBrOsaCVcix;
				}
			}

			internal ButtonStateFlags UwdGDNaetQViXUQjTpQvSRaOGAoGA
			{
				get
				{
					oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu gCuVMYSfiKsQxdQVnjXyTifTIynu = (oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
					if (gCuVMYSfiKsQxdQVnjXyTifTIynu.dnINCqbYIyNvkNGscfXUOxLbHTHs)
					{
						buttonStateFlags |= ButtonStateFlags.On;
						if (!gCuVMYSfiKsQxdQVnjXyTifTIynu.qIURxrDqNbvJBVnJEVMCOlVBsdNi)
						{
							buttonStateFlags |= ButtonStateFlags.Down;
						}
					}
					else if (gCuVMYSfiKsQxdQVnjXyTifTIynu.qIURxrDqNbvJBVnJEVMCOlVBsdNi)
					{
						buttonStateFlags |= ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
			}

			internal Button(Controller P_0, int P_1, string P_2, HardwareButtonInfo P_3)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				qChIJtMmxeHxmgKkaWmKUQWKYHgb = P_3;
				ssmnmYuoyqoDXsayoQPZkxOrBGDH = new oAILDhzHsiGjFkKuMwnZSvGAejjEb(ReInput.configVars.updateLoop, false);
			}

			internal Button(Controller P_0, int P_1, string P_2, bool P_3, HardwareButtonInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				qChIJtMmxeHxmgKkaWmKUQWKYHgb = P_4;
				vznhzgUaUgIIXzJXsvveSoXuPUAv = P_3;
				ssmnmYuoyqoDXsayoQPZkxOrBGDH = new oAILDhzHsiGjFkKuMwnZSvGAejjEb(ReInput.configVars.updateLoop, P_3);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
				{
					ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
					return false;
				}
				if (speed <= 0f)
				{
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).qUCobUyxfvbiOIZsURUBLIfvnFfN.wUDNPwwPaWEMjkBsGfBsCoHKiHedA;
				}
				return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).DoSZeJCJnnwsOhfiffbrGOYMnguc.gCHbTTCcKaawrHXwnkzztSsIGebQA(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != nwEpkxquWpKWNoklzPTreittQBEt)
				{
					ReInput.CheckInitialized(nwEpkxquWpKWNoklzPTreittQBEt);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).qUCobUyxfvbiOIZsURUBLIfvnFfN.wUDNPwwPaWEMjkBsGfBsCoHKiHedA;
				}
				return ((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).DoSZeJCJnnwsOhfiffbrGOYMnguc.gCHbTTCcKaawrHXwnkzztSsIGebQA(speed);
			}

			internal void hiFDVqoPUcCLJOQmioHlwCylqVKr(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (ssmnmYuoyqoDXsayoQPZkxOrBGDH != null && ssmnmYuoyqoDXsayoQPZkxOrBGDH.uJePmjkNCKUheCRoJmiTXljvPPKN != (int)P_0)
				{
					ssmnmYuoyqoDXsayoQPZkxOrBGDH.wKPazGtXcJidbhhvYzSOjIiNKgYCA = P_0;
				}
				if (vznhzgUaUgIIXzJXsvveSoXuPUAv)
				{
					((oAILDhzHsiGjFkKuMwnZSvGAejjEb.RXlFBcbObyrmcqzuMgTHOSHQfjEyA)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).ZiZdoFUDLFVsNGHBDyfTTiqdAWFX(P_2.buttonPressureValues[P_1]);
				}
				else
				{
					((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).CZhOGDskHjWpUTHsLiOKNiXiPoVX(P_2.buttonValues[P_1]);
				}
			}

			internal void FmHfHOwwwaZKocMXJUnCcrUsuPtL(UpdateLoopType P_0)
			{
				if (ssmnmYuoyqoDXsayoQPZkxOrBGDH != null && ssmnmYuoyqoDXsayoQPZkxOrBGDH.uJePmjkNCKUheCRoJmiTXljvPPKN != (int)P_0)
				{
					ssmnmYuoyqoDXsayoQPZkxOrBGDH.wKPazGtXcJidbhhvYzSOjIiNKgYCA = P_0;
				}
				if (vznhzgUaUgIIXzJXsvveSoXuPUAv)
				{
					((oAILDhzHsiGjFkKuMwnZSvGAejjEb.RXlFBcbObyrmcqzuMgTHOSHQfjEyA)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).ZiZdoFUDLFVsNGHBDyfTTiqdAWFX(0f);
				}
				else
				{
					((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)ssmnmYuoyqoDXsayoQPZkxOrBGDH.DvrMnzmivppXkQIJbPRnwloCOzOv).CZhOGDskHjWpUTHsLiOKNiXiPoVX(false);
				}
			}

			internal void VdCYwTkTQAzNCrxshuFfUjBySjJK()
			{
				for (int i = 0; i < ssmnmYuoyqoDXsayoQPZkxOrBGDH.hXmFqqUcbyURCBLWzfLrWpaqVzc.Count; i++)
				{
					qqXRLoVtgcRoeoNiSJGKihhnzGWi.hpWyEOsyUBevzBDMSfSKCYBNKrDfA hpWyEOsyUBevzBDMSfSKCYBNKrDfA = ssmnmYuoyqoDXsayoQPZkxOrBGDH.hXmFqqUcbyURCBLWzfLrWpaqVzc[i];
					if (hpWyEOsyUBevzBDMSfSKCYBNKrDfA != null)
					{
						if (vznhzgUaUgIIXzJXsvveSoXuPUAv)
						{
							((oAILDhzHsiGjFkKuMwnZSvGAejjEb.RXlFBcbObyrmcqzuMgTHOSHQfjEyA)hpWyEOsyUBevzBDMSfSKCYBNKrDfA).ZiZdoFUDLFVsNGHBDyfTTiqdAWFX(0f);
						}
						else
						{
							((oAILDhzHsiGjFkKuMwnZSvGAejjEb.GCuVMYSfiKsQxdQVnjXyTifTIynu)hpWyEOsyUBevzBDMSfSKCYBNKrDfA).CZhOGDskHjWpUTHsLiOKNiXiPoVX(false);
						}
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class hftHctoDxVDKGBdVaMpCfeDzZqhqA
			{
				public readonly Element xCOjRjQooYBKyiOrBoRDRhNOdkvV;

				public readonly int EwuycWiIirHEvFwEYJivcVjsOyoFA;

				public hftHctoDxVDKGBdVaMpCfeDzZqhqA(Element P_0, int P_1)
				{
					xCOjRjQooYBKyiOrBoRDRhNOdkvV = P_0;
					EwuycWiIirHEvFwEYJivcVjsOyoFA = P_1;
				}
			}

			private int lMIghEfagWKChgIdqKOAHLhUIEfl;

			private string ngVjYNfftJsIzDEUQYlpEGVmoDbw;

			private CompoundControllerElementType dbiQRkYKdCxJNiwcGdGuWyuiqfGn;

			private int seyPQKiMnxaGFDVCuLiVxhtbauAU;

			private hftHctoDxVDKGBdVaMpCfeDzZqhqA[] UTAXIcyKFRAKPgDOCKNchApfUzfLA;

			private Controller WlMcSKDaMMBOsMZPXkQzHUClJGTMA;

			internal readonly int utMmYvnwcLkXbWcelRypqgAiXenL;

			public int id
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return -1;
					}
					return lMIghEfagWKChgIdqKOAHLhUIEfl;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return string.Empty;
					}
					return ngVjYNfftJsIzDEUQYlpEGVmoDbw;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return CompoundControllerElementType.Axis2D;
					}
					return dbiQRkYKdCxJNiwcGdGuWyuiqfGn;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return false;
					}
					return seyPQKiMnxaGFDVCuLiVxhtbauAU > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return 0;
					}
					return seyPQKiMnxaGFDVCuLiVxhtbauAU;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = WlMcSKDaMMBOsMZPXkQzHUClJGTMA.GetElementIdentifierById(lMIghEfagWKChgIdqKOAHLhUIEfl);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			internal CompoundElement(Controller P_0, int P_1, string P_2, CompoundControllerElementType P_3)
			{
				WlMcSKDaMMBOsMZPXkQzHUClJGTMA = P_0;
				lMIghEfagWKChgIdqKOAHLhUIEfl = P_1;
				ngVjYNfftJsIzDEUQYlpEGVmoDbw = P_2;
				dbiQRkYKdCxJNiwcGdGuWyuiqfGn = P_3;
				UTAXIcyKFRAKPgDOCKNchApfUzfLA = new hftHctoDxVDKGBdVaMpCfeDzZqhqA[elementCapacity];
				utMmYvnwcLkXbWcelRypqgAiXenL = ReInput.id;
			}

			internal Element uRZCIHJZZVtdWsrOJUTdkfCwwbwQ(int P_0)
			{
				if (P_0 < 0 || P_0 >= UTAXIcyKFRAKPgDOCKNchApfUzfLA.Length)
				{
					return null;
				}
				if (UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_0] == null)
				{
					return null;
				}
				return UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_0].xCOjRjQooYBKyiOrBoRDRhNOdkvV;
			}

			internal _0001 uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<_0001>(int P_0) where _0001 : Element
			{
				if (P_0 < 0 || P_0 >= UTAXIcyKFRAKPgDOCKNchApfUzfLA.Length)
				{
					return null;
				}
				if (UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_0] == null)
				{
					return null;
				}
				return UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_0].xCOjRjQooYBKyiOrBoRDRhNOdkvV as _0001;
			}

			internal _0001 nWeQyzzRFiIsncvCKmUnrOvInbgW<_0001>(int P_0, out int P_1) where _0001 : Element
			{
				P_1 = -1;
				if (P_0 < 0 || P_0 >= UTAXIcyKFRAKPgDOCKNchApfUzfLA.Length)
				{
					return null;
				}
				if (UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_0] == null)
				{
					return null;
				}
				P_1 = UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_0].EwuycWiIirHEvFwEYJivcVjsOyoFA;
				return UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_0].xCOjRjQooYBKyiOrBoRDRhNOdkvV as _0001;
			}

			internal bool NvBvNuSatPypeBAlRaimhZQgLheN(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (seyPQKiMnxaGFDVCuLiVxhtbauAU >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (jVnsysFUDGdvluFJvjnNaKyLCspD(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = LHEfspmIkcTElnAoQRRiuDXXRLBo();
				if (num < 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				return ubhemBDGimadtwIUYzCLVSeNIvdAb(P_0, P_1, num);
			}

			internal bool HwapGEoYutYdFPrLiDfElYAbLDNI(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (seyPQKiMnxaGFDVCuLiVxhtbauAU == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = jVnsysFUDGdvluFJvjnNaKyLCspD(P_0);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return UopMKrHcMVobUlBiWMUJYtVxaQKp(num);
			}

			internal void emZdlTcMkFhKAjxNWkuhwHdaPWuHA()
			{
				for (int i = 0; i < UTAXIcyKFRAKPgDOCKNchApfUzfLA.Length; i++)
				{
					UopMKrHcMVobUlBiWMUJYtVxaQKp(i);
				}
				seyPQKiMnxaGFDVCuLiVxhtbauAU = 0;
			}

			private int jVnsysFUDGdvluFJvjnNaKyLCspD(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				for (int i = 0; i < UTAXIcyKFRAKPgDOCKNchApfUzfLA.Length; i++)
				{
					if (UTAXIcyKFRAKPgDOCKNchApfUzfLA[i] != null && UTAXIcyKFRAKPgDOCKNchApfUzfLA[i].xCOjRjQooYBKyiOrBoRDRhNOdkvV == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private bool ubhemBDGimadtwIUYzCLVSeNIvdAb(Element P_0, int P_1, int P_2)
			{
				if (P_2 < 0 || P_2 >= UTAXIcyKFRAKPgDOCKNchApfUzfLA.Length)
				{
					return false;
				}
				if (UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_2] != null)
				{
					return false;
				}
				UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_2] = new hftHctoDxVDKGBdVaMpCfeDzZqhqA(P_0, P_1);
				P_0.nkQJswJcKkgKmPckxKjWURopGUAE(this);
				seyPQKiMnxaGFDVCuLiVxhtbauAU++;
				return true;
			}

			private bool UopMKrHcMVobUlBiWMUJYtVxaQKp(int P_0)
			{
				if (P_0 < 0 || P_0 >= UTAXIcyKFRAKPgDOCKNchApfUzfLA.Length)
				{
					return false;
				}
				if (UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_0] == null)
				{
					return false;
				}
				if (UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_0].xCOjRjQooYBKyiOrBoRDRhNOdkvV != null)
				{
					UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_0].xCOjRjQooYBKyiOrBoRDRhNOdkvV.ckzpDMRLbekLjwGcJWInRUssmUHn(this);
				}
				UTAXIcyKFRAKPgDOCKNchApfUzfLA[P_0] = null;
				seyPQKiMnxaGFDVCuLiVxhtbauAU--;
				return true;
			}

			private int LHEfspmIkcTElnAoQRRiuDXXRLBo()
			{
				for (int i = 0; i < UTAXIcyKFRAKPgDOCKNchApfUzfLA.Length; i++)
				{
					if (UTAXIcyKFRAKPgDOCKNchApfUzfLA[i] == null)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int ybeWsIWCeUkapclyDCLlItbQyfWmA = 2;

			private CalibrationMap fBaXHCUrlVJJklWgpZVArRbzeOvf;

			int CompoundElement.elementCapacity => 2;

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return Vector2.zero;
					}
					return vSPBYsgWpbSyohSjzcpNBSirQHvjb();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return Vector2.zero;
					}
					return OvnzAeonzTrytnmjfXurnErhUDnA();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller P_0, int P_1, string P_2, Axis P_3, Axis P_4, int P_5, int P_6, CalibrationMap P_7)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Axis2D)
			{
				NvBvNuSatPypeBAlRaimhZQgLheN(P_3, P_5);
				NvBvNuSatPypeBAlRaimhZQgLheN(P_4, P_6);
				fBaXHCUrlVJJklWgpZVArRbzeOvf = P_7;
			}

			internal void eUCoDNkXPCigzYPoWlCwthsUhPrF()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.HnxcKLIzwFRQRPCrBvmodpXcDjafA(vector.x);
				}
				if (yAxis != null)
				{
					yAxis.HnxcKLIzwFRQRPCrBvmodpXcDjafA(vector.y);
				}
			}

			private Vector2 vSPBYsgWpbSyohSjzcpNBSirQHvjb()
			{
				if (fBaXHCUrlVJJklWgpZVArRbzeOvf == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = nWeQyzzRFiIsncvCKmUnrOvInbgW<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = nWeQyzzRFiIsncvCKmUnrOvInbgW<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRaw ?? 0f;
				float valueRawY = axis2?.valueRaw ?? 0f;
				return fBaXHCUrlVJJklWgpZVArRbzeOvf.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}

			private Vector2 OvnzAeonzTrytnmjfXurnErhUDnA()
			{
				if (fBaXHCUrlVJJklWgpZVArRbzeOvf == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = nWeQyzzRFiIsncvCKmUnrOvInbgW<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = nWeQyzzRFiIsncvCKmUnrOvInbgW<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRawPrev ?? 0f;
				float valueRawY = axis2?.valueRawPrev ?? 0f;
				return fBaXHCUrlVJJklWgpZVArRbzeOvf.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int DKbCcNeXZJzoEqYpavWQutdLyNQy = 8;

			private const int ItoWRkPGlrrhwpbMZVDCFeZHVazu = 0;

			private const int jqRMXHpWislibGsUwXIjOVJNNiyW = 1;

			private const int RFJlDCghSEBKwKGLTOJKSujygjhW = 2;

			private const int zJVGxyUrTffsFHgEnnYWwVMYlQn = 3;

			private const int EHjsUTyOldjsVHOzFJAfbildkthLB = 4;

			private const int OjtVfemJhfekUuyCIJBAIoHnfHUi = 5;

			private const int JJSMVoqHNZHPUJNvqnkhrHCSNsfz = 6;

			private const int hCqQYpxqFyDvvTlDcgtckQwSWcRmA = 7;

			private readonly int MqWPONUPVUMRfAssYEVlCQnsFJjXA;

			private readonly Button[] uomvhUKvRwAfeyHeorXVsMOfjmDQ;

			private readonly ReadOnlyCollection<Button> RQXkyHHQOhqXWDUDYiUwWlHkczoB;

			private readonly int[] RwUEQhHNJPYFIQqcbeGRJRAKyFTaA;

			private bool XfGoLaVopCemLrFQVpBTeQotKZjO;

			int CompoundElement.elementCapacity => 8;

			public bool force4Way
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return false;
					}
					return XfGoLaVopCemLrFQVpBTeQotKZjO;
				}
				set
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
					}
					else
					{
						XfGoLaVopCemLrFQVpBTeQotKZjO = value;
					}
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return 0;
					}
					return MqWPONUPVUMRfAssYEVlCQnsFJjXA;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return RQXkyHHQOhqXWDUDYiUwWlHkczoB;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Button>(7);
				}
			}

			internal Hat(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Hat)
			{
				int num = ((P_3 != null) ? P_3.Length : 0);
				if (num != ((P_4 != null) ? P_4.Length : 0))
				{
					throw new ArgumentException("buttons.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4 && num != 8)
				{
					throw new ArgumentException("buttons.Length must be 0, 4, or 8! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					NvBvNuSatPypeBAlRaimhZQgLheN(P_3[i], P_4[i]);
				}
				uomvhUKvRwAfeyHeorXVsMOfjmDQ = P_3;
				RwUEQhHNJPYFIQqcbeGRJRAKyFTaA = P_4;
				MqWPONUPVUMRfAssYEVlCQnsFJjXA = num;
				RQXkyHHQOhqXWDUDYiUwWlHkczoB = new ReadOnlyCollection<Button>(P_3);
			}

			internal void UgddLAdEAQEziMqjonbAtbqlnGmIb(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (MqWPONUPVUMRfAssYEVlCQnsFJjXA == 0)
				{
					return;
				}
				if (MqWPONUPVUMRfAssYEVlCQnsFJjXA == 8 && (XfGoLaVopCemLrFQVpBTeQotKZjO || ReInput.configVars.force4WayHats))
				{
					YNfyZfjgySJrxrMGtGhVLzLupnUs(uomvhUKvRwAfeyHeorXVsMOfjmDQ[0], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[0], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[7], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[1], P_0, P_1);
					YNfyZfjgySJrxrMGtGhVLzLupnUs(uomvhUKvRwAfeyHeorXVsMOfjmDQ[2], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[2], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[1], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[3], P_0, P_1);
					YNfyZfjgySJrxrMGtGhVLzLupnUs(uomvhUKvRwAfeyHeorXVsMOfjmDQ[4], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[4], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[5], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[3], P_0, P_1);
					YNfyZfjgySJrxrMGtGhVLzLupnUs(uomvhUKvRwAfeyHeorXVsMOfjmDQ[6], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[6], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[5], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[7], P_0, P_1);
					rxuJbtehcsrrkTONrdbyiLkgiSlf(uomvhUKvRwAfeyHeorXVsMOfjmDQ[1], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[1], P_0, P_1);
					rxuJbtehcsrrkTONrdbyiLkgiSlf(uomvhUKvRwAfeyHeorXVsMOfjmDQ[3], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[3], P_0, P_1);
					rxuJbtehcsrrkTONrdbyiLkgiSlf(uomvhUKvRwAfeyHeorXVsMOfjmDQ[5], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[5], P_0, P_1);
					rxuJbtehcsrrkTONrdbyiLkgiSlf(uomvhUKvRwAfeyHeorXVsMOfjmDQ[7], RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[7], P_0, P_1);
					return;
				}
				for (int i = 0; i < uomvhUKvRwAfeyHeorXVsMOfjmDQ.Length; i++)
				{
					if (uomvhUKvRwAfeyHeorXVsMOfjmDQ[i] != null)
					{
						uomvhUKvRwAfeyHeorXVsMOfjmDQ[i].hiFDVqoPUcCLJOQmioHlwCylqVKr(P_0, RwUEQhHNJPYFIQqcbeGRJRAKyFTaA[i], P_1);
					}
				}
			}

			private void YNfyZfjgySJrxrMGtGhVLzLupnUs(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
			{
				if (P_0 == null || P_1 < 0 || P_1 >= P_5.buttonCount)
				{
					return;
				}
				if (!P_0.isPressureSensitive)
				{
					if (P_2 >= 0 && P_2 < P_5.buttonCount)
					{
						ref bool reference = ref P_5.buttonValues[P_1];
						reference |= P_5.buttonValues[P_2];
					}
					if (P_3 >= 0 && P_3 < P_5.buttonCount)
					{
						ref bool reference2 = ref P_5.buttonValues[P_1];
						reference2 |= P_5.buttonValues[P_3];
					}
				}
				else
				{
					P_5.buttonPressureValues[P_1] = MathTools.MaxMagnitude(P_5.buttonPressureValues[P_1], MathTools.MaxMagnitude((P_2 >= 0 && P_2 < P_5.buttonCount) ? P_5.buttonPressureValues[P_2] : 0f, (P_3 >= 0 && P_3 < P_5.buttonCount) ? P_5.buttonPressureValues[P_3] : 0f));
				}
				P_0.hiFDVqoPUcCLJOQmioHlwCylqVKr(P_4, P_1, P_5);
			}

			private void rxuJbtehcsrrkTONrdbyiLkgiSlf(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
			{
				if (P_0 != null && P_1 >= 0 && P_1 < P_3.buttonCount)
				{
					if (!P_0.isPressureSensitive)
					{
						P_3.buttonValues[P_1] = false;
					}
					else
					{
						P_3.buttonPressureValues[P_1] = 0f;
					}
					P_0.hiFDVqoPUcCLJOQmioHlwCylqVKr(P_2, P_1, P_3);
				}
			}
		}

		public sealed class DirectionalPad : CompoundElement
		{
			private const int cxMuFcNSpCHAVNHwbJLhINrUhujF = 4;

			private const int WqZOcPxEJcHOHZrVvJoovSEXNdNB = 0;

			private const int ZNJJZOKJPYNOeWqlZmizsajcyUMf = 1;

			private const int xihfndfqXxYbnoKxcoCRsWrXoULi = 2;

			private const int MkWLwzLTNCRYunfqifdwfgxVeMhIA = 3;

			private readonly int aDFVANzulWQZKNBZNiBRCSKKlICk;

			private readonly Button[] ODwyuYjAngpsVHmCJSmRWlbGVAwK;

			private readonly ReadOnlyCollection<Button> mRtrlTMbAaLwtxKQZYeqjocVQKBb;

			private readonly int[] DGbUUerCDqpOFHVpUDBekcUHCZtu;

			int CompoundElement.elementCapacity => 4;

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return mRtrlTMbAaLwtxKQZYeqjocVQKBb;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Button>(1);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Button>(2);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != utMmYvnwcLkXbWcelRypqgAiXenL)
					{
						ReInput.CheckInitialized(utMmYvnwcLkXbWcelRypqgAiXenL);
						return null;
					}
					return uRZCIHJZZVtdWsrOJUTdkfCwwbwQ<Button>(3);
				}
			}

			internal DirectionalPad(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
				: base(P_0, P_1, P_2, CompoundControllerElementType.DPad)
			{
				int num = ((P_3 != null) ? P_3.Length : 0);
				if (num != ((P_4 != null) ? P_4.Length : 0))
				{
					throw new ArgumentException("buttons.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4)
				{
					throw new ArgumentException("buttons.Length must be 0 or 4! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					NvBvNuSatPypeBAlRaimhZQgLheN(P_3[i], P_4[i]);
				}
				ODwyuYjAngpsVHmCJSmRWlbGVAwK = P_3;
				DGbUUerCDqpOFHVpUDBekcUHCZtu = P_4;
				aDFVANzulWQZKNBZNiBRCSKKlICk = num;
				mRtrlTMbAaLwtxKQZYeqjocVQKBb = new ReadOnlyCollection<Button>(P_3);
			}

			internal void yuJSFlCtrohfJQsZVSpSHQkfnHWN(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (aDFVANzulWQZKNBZNiBRCSKKlICk == 0)
				{
					return;
				}
				for (int i = 0; i < ODwyuYjAngpsVHmCJSmRWlbGVAwK.Length; i++)
				{
					if (ODwyuYjAngpsVHmCJSmRWlbGVAwK[i] != null)
					{
						ODwyuYjAngpsVHmCJSmRWlbGVAwK[i].hiFDVqoPUcCLJOQmioHlwCylqVKr(P_0, DGbUUerCDqpOFHVpUDBekcUHCZtu[i], P_1);
					}
				}
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller dtVdxRVYcijRftWOjaUJbmuBJAdU;

			private IControllerExtensionSource bqytszAHPrtCbCrrAIRDokpNaHPI;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (dtVdxRVYcijRftWOjaUJbmuBJAdU == null)
					{
						return false;
					}
					return dtVdxRVYcijRftWOjaUJbmuBJAdU._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (dtVdxRVYcijRftWOjaUJbmuBJAdU == null)
					{
						return false;
					}
					return dtVdxRVYcijRftWOjaUJbmuBJAdU.enabled;
				}
			}

			public Controller controller => dtVdxRVYcijRftWOjaUJbmuBJAdU;

			internal Extension(IControllerExtensionSource P_0)
			{
				_reInputId = ReInput.id;
				JVhNEFqpCtpgVDPQobWnlsbjVHHV(P_0);
			}

			internal Extension(Extension P_0)
				: this(P_0.bqytszAHPrtCbCrrAIRDokpNaHPI)
			{
				dtVdxRVYcijRftWOjaUJbmuBJAdU = P_0.dtVdxRVYcijRftWOjaUJbmuBJAdU;
			}

			internal T GetController<T>() where T : Controller
			{
				if (dtVdxRVYcijRftWOjaUJbmuBJAdU == null)
				{
					return null;
				}
				return dtVdxRVYcijRftWOjaUJbmuBJAdU as T;
			}

			internal void SetController(Controller controller)
			{
				dtVdxRVYcijRftWOjaUJbmuBJAdU = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return bqytszAHPrtCbCrrAIRDokpNaHPI;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					JVhNEFqpCtpgVDPQobWnlsbjVHHV(null);
				}
				else
				{
					JVhNEFqpCtpgVDPQobWnlsbjVHHV(extension.bqytszAHPrtCbCrrAIRDokpNaHPI);
				}
			}

			private void JVhNEFqpCtpgVDPQobWnlsbjVHHV(IControllerExtensionSource P_0)
			{
				bqytszAHPrtCbCrrAIRDokpNaHPI = P_0;
				SourceUpdated(bqytszAHPrtCbCrrAIRDokpNaHPI);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		[Serializable]
		private sealed class ENqOdWeWHERswSblkppecAEtqNTy
		{
			public static readonly ENqOdWeWHERswSblkppecAEtqNTy _003C_003E9 = new ENqOdWeWHERswSblkppecAEtqNTy();

			public static Func<Controller, Guid, bool> _003C_003E9__166_0;

			public static Func<Controller, Type, bool> _003C_003E9__169_0;

			internal bool RvEnCiDHCZekRKfDSpMtseqIhdfs(Controller P_0, Guid P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}

			internal bool aszEtaBXhGpyhGlTjdiEfUDXwvFH(Controller P_0, Type P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}
		}

		private sealed class BzPdiPWuAwKoxbHsdyykihTdRXFi : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int AmiFISFIqqzzVcFPqHhzpolXCkPlA;

			private ControllerPollingInfo KAuTRNMDxpTSYjMPKVkDDKCQFUSd;

			private int AOPcNVCYKrAHGhBITvGfNgJowBtf;

			public Controller YmHbWkvNrBbLoXQAzjadkugbojbe;

			private int wXyJJRwjOmIFSDHcWwMJAkNBLpHoA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return KAuTRNMDxpTSYjMPKVkDDKCQFUSd;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return KAuTRNMDxpTSYjMPKVkDDKCQFUSd;
				}
			}

			[DebuggerHidden]
			public BzPdiPWuAwKoxbHsdyykihTdRXFi(int P_0)
			{
				AmiFISFIqqzzVcFPqHhzpolXCkPlA = P_0;
				AOPcNVCYKrAHGhBITvGfNgJowBtf = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				AmiFISFIqqzzVcFPqHhzpolXCkPlA = -2;
			}

			private bool MoveNext()
			{
				int amiFISFIqqzzVcFPqHhzpolXCkPlA = AmiFISFIqqzzVcFPqHhzpolXCkPlA;
				Controller ymHbWkvNrBbLoXQAzjadkugbojbe = YmHbWkvNrBbLoXQAzjadkugbojbe;
				if (amiFISFIqqzzVcFPqHhzpolXCkPlA != 0)
				{
					if (amiFISFIqqzzVcFPqHhzpolXCkPlA != 1)
					{
						return false;
					}
					AmiFISFIqqzzVcFPqHhzpolXCkPlA = -1;
					goto IL_00a0;
				}
				AmiFISFIqqzzVcFPqHhzpolXCkPlA = -1;
				if (ReInput._id != ymHbWkvNrBbLoXQAzjadkugbojbe.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ymHbWkvNrBbLoXQAzjadkugbojbe.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return false;
				}
				ymHbWkvNrBbLoXQAzjadkugbojbe.UpdatePollingFrameTracking();
				wXyJJRwjOmIFSDHcWwMJAkNBLpHoA = 0;
				goto IL_00b0;
				IL_00b0:
				if (wXyJJRwjOmIFSDHcWwMJAkNBLpHoA < ymHbWkvNrBbLoXQAzjadkugbojbe._buttonCount)
				{
					if (ymHbWkvNrBbLoXQAzjadkugbojbe.mEhicSGrhgClctxRDsDCnmDphafV(wXyJJRwjOmIFSDHcWwMJAkNBLpHoA, out var num))
					{
						KAuTRNMDxpTSYjMPKVkDDKCQFUSd = new ControllerPollingInfo(true, -1, ymHbWkvNrBbLoXQAzjadkugbojbe.id, ymHbWkvNrBbLoXQAzjadkugbojbe._name, ymHbWkvNrBbLoXQAzjadkugbojbe._type, ControllerElementType.Button, wXyJJRwjOmIFSDHcWwMJAkNBLpHoA, Pole.Positive, ymHbWkvNrBbLoXQAzjadkugbojbe.LJmpCFrENABMhmUxmGaTconkDyoGA.GetElementIdentifierName(num), num, KeyCode.None);
						AmiFISFIqqzzVcFPqHhzpolXCkPlA = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				wXyJJRwjOmIFSDHcWwMJAkNBLpHoA++;
				goto IL_00b0;
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

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				BzPdiPWuAwKoxbHsdyykihTdRXFi bzPdiPWuAwKoxbHsdyykihTdRXFi;
				if (AmiFISFIqqzzVcFPqHhzpolXCkPlA == -2 && AOPcNVCYKrAHGhBITvGfNgJowBtf == Environment.CurrentManagedThreadId)
				{
					AmiFISFIqqzzVcFPqHhzpolXCkPlA = 0;
					bzPdiPWuAwKoxbHsdyykihTdRXFi = this;
				}
				else
				{
					bzPdiPWuAwKoxbHsdyykihTdRXFi = new BzPdiPWuAwKoxbHsdyykihTdRXFi(0);
					bzPdiPWuAwKoxbHsdyykihTdRXFi.YmHbWkvNrBbLoXQAzjadkugbojbe = YmHbWkvNrBbLoXQAzjadkugbojbe;
				}
				return bzPdiPWuAwKoxbHsdyykihTdRXFi;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class NUmNhaWOVXQzZSrffkPDMuQNwGaR : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int YpEdqZMGHtcUGxrjrxxygXaDJeKR;

			private ControllerPollingInfo DpbPTGpKEEmTVXJNcbSKAUgtALHcA;

			private int LYgiQfUoPXfWzaVPTRVzGoogFAYL;

			public Controller DHhngkmvZhCzlPmzTiUpvikUKcIH;

			private int xfcMWicMchciPcOnGTQtWushqxYf;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return DpbPTGpKEEmTVXJNcbSKAUgtALHcA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DpbPTGpKEEmTVXJNcbSKAUgtALHcA;
				}
			}

			[DebuggerHidden]
			public NUmNhaWOVXQzZSrffkPDMuQNwGaR(int P_0)
			{
				YpEdqZMGHtcUGxrjrxxygXaDJeKR = P_0;
				LYgiQfUoPXfWzaVPTRVzGoogFAYL = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				YpEdqZMGHtcUGxrjrxxygXaDJeKR = -2;
			}

			private bool MoveNext()
			{
				int ypEdqZMGHtcUGxrjrxxygXaDJeKR = YpEdqZMGHtcUGxrjrxxygXaDJeKR;
				Controller dHhngkmvZhCzlPmzTiUpvikUKcIH = DHhngkmvZhCzlPmzTiUpvikUKcIH;
				if (ypEdqZMGHtcUGxrjrxxygXaDJeKR != 0)
				{
					if (ypEdqZMGHtcUGxrjrxxygXaDJeKR != 1)
					{
						return false;
					}
					YpEdqZMGHtcUGxrjrxxygXaDJeKR = -1;
					goto IL_00a0;
				}
				YpEdqZMGHtcUGxrjrxxygXaDJeKR = -1;
				if (ReInput._id != dHhngkmvZhCzlPmzTiUpvikUKcIH.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(dHhngkmvZhCzlPmzTiUpvikUKcIH.ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return false;
				}
				dHhngkmvZhCzlPmzTiUpvikUKcIH.UpdatePollingFrameTracking();
				xfcMWicMchciPcOnGTQtWushqxYf = 0;
				goto IL_00b0;
				IL_00b0:
				if (xfcMWicMchciPcOnGTQtWushqxYf < dHhngkmvZhCzlPmzTiUpvikUKcIH._buttonCount)
				{
					if (dHhngkmvZhCzlPmzTiUpvikUKcIH.YuEcuuWQkCAHlDRbqAaGBZzKsCSLA(xfcMWicMchciPcOnGTQtWushqxYf, out var num))
					{
						DpbPTGpKEEmTVXJNcbSKAUgtALHcA = new ControllerPollingInfo(true, -1, dHhngkmvZhCzlPmzTiUpvikUKcIH.id, dHhngkmvZhCzlPmzTiUpvikUKcIH._name, dHhngkmvZhCzlPmzTiUpvikUKcIH._type, ControllerElementType.Button, xfcMWicMchciPcOnGTQtWushqxYf, Pole.Positive, dHhngkmvZhCzlPmzTiUpvikUKcIH.LJmpCFrENABMhmUxmGaTconkDyoGA.GetElementIdentifierName(num), num, KeyCode.None);
						YpEdqZMGHtcUGxrjrxxygXaDJeKR = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				xfcMWicMchciPcOnGTQtWushqxYf++;
				goto IL_00b0;
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

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				NUmNhaWOVXQzZSrffkPDMuQNwGaR nUmNhaWOVXQzZSrffkPDMuQNwGaR;
				if (YpEdqZMGHtcUGxrjrxxygXaDJeKR == -2 && LYgiQfUoPXfWzaVPTRVzGoogFAYL == Environment.CurrentManagedThreadId)
				{
					YpEdqZMGHtcUGxrjrxxygXaDJeKR = 0;
					nUmNhaWOVXQzZSrffkPDMuQNwGaR = this;
				}
				else
				{
					nUmNhaWOVXQzZSrffkPDMuQNwGaR = new NUmNhaWOVXQzZSrffkPDMuQNwGaR(0);
					nUmNhaWOVXQzZSrffkPDMuQNwGaR.DHhngkmvZhCzlPmzTiUpvikUKcIH = DHhngkmvZhCzlPmzTiUpvikUKcIH;
				}
				return nUmNhaWOVXQzZSrffkPDMuQNwGaR;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		public readonly int id;

		protected string _tag;

		protected string _name;

		private readonly DeviceLocalizationInfo lnSSmvghWhgBGduRCUgmuvuqLIcR;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid savDJAJJykdFgIDmPSBdENeZaLumA;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension xfTOtGXnPjccLfmajBZneeyjKCmdb;

		private bool VgGDhiCahEDwVEFxeVUTANGrnOkNb;

		private ControllerIdentifier tMqtMpSNHfUiGaKHMhnSIaCoCXsj;

		internal int ZnRkLjoJZaBEcsqDJEgTJYVKjsWl;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> vydslZNlwFgQqKdtdePqhlBOppHsA;

		private readonly ReadOnlyCollection<Element> zXwJijGNGxLYWSfXsOAGACUbDEPJ;

		private readonly IList<CompoundElement> QIjcgKjyInQNPhToZRHAjmrEjEVib;

		private readonly ReadOnlyCollection<CompoundElement> cxOVvLLCCWOaUIOdINaIsXeyFdUW;

		[CustomObfuscation(rename = false)]
		internal readonly InputSource inputSource;

		internal readonly ControllerDataUpdater zfVdfqKDuqZKjafBdqgdinjRQNeGb;

		internal readonly HardwareControllerMap_Game LJmpCFrENABMhmUxmGaTconkDyoGA;

		internal uint DXjiZuzjDrBcOipWkembjJvVpKl;

		private uint aSLdvyuOUprjQTTRtwHTuinOYhrs;

		private uint KFSDRjcdFmeKtRuMIBFxbakEQeEGb;

		private ITryGetLocalizedName FVAYVCRprbashwFMHsOsXIjUldRG;

		private readonly LocalizedString jQhKYIjNbdWnRQFdwKPagPpdwDFA;

		private readonly gjMBNBgPUgnpVrmJwQZQrVmLNmagb HAetKXDaxQAhHDxKHfoZLQmYkcYr;

		private Action<bool> NaejNKMZZNPakaAvqcDycgFeGdPzA;

		private IControllerTemplate[] UIdaMBbhoaPpDkxYzBQNrzBGMYkp;

		private ReadOnlyCollection<IControllerTemplate> gqBBvaapSenOnMRhqWThaJvkzlIz;

		private static Func<Controller, Guid, bool> JPjSeFlRXhuUgnDgfefTfPhujglkA;

		private static Func<Controller, Type, bool> nJmoBZWCAikEgZnxkKGaGFLHAHIR;

		internal bool YIQmWgzAndolImZiEMJthwGYkyEM => aSLdvyuOUprjQTTRtwHTuinOYhrs == ReInput.previousFrame;

		public bool enabled
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return false;
				}
				return VgGDhiCahEDwVEFxeVUTANGrnOkNb;
			}
			set
			{
				XExEgWAUoYDZHOcZKsQgKkhupxolA(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return _name;
				}
				if (JjQEFVsgxnuheoCTguBsKAhENLgh != null && JjQEFVsgxnuheoCTguBsKAhENLgh.TryGetLocalizedName(out var value))
				{
					return value;
				}
				if (_type == ControllerType.Joystick && savDJAJJykdFgIDmPSBdENeZaLumA == Consts.joystickGuid_unknownController)
				{
					return _name;
				}
				if (lnSSmvghWhgBGduRCUgmuvuqLIcR == null || lnSSmvghWhgBGduRCUgmuvuqLIcR.parentKeys == null)
				{
					return _name;
				}
				LocalizationManager.GetAndUpdateLocalizedString(jQhKYIjNbdWnRQFdwKPagPpdwDFA, (lnSSmvghWhgBGduRCUgmuvuqLIcR != null) ? lnSSmvghWhgBGduRCUgmuvuqLIcR.parentKeys : null, iiskKgDbWxOwEGnzrXYHgovqbhjF.YDJKkZYOITbTDBfdpBFljPYENlXkc(_type), _name, out value);
				return value;
			}
			internal set
			{
				_name = text;
			}
		}

		public string tag
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return Guid.Empty;
				}
				return savDJAJJykdFgIDmPSBdENeZaLumA;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => tMqtMpSNHfUiGaKHMhnSIaCoCXsj;

		public bool isConnected
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				}
				else if (!flag)
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
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return 0;
				}
				return vydslZNlwFgQqKdtdePqhlBOppHsA.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return zXwJijGNGxLYWSfXsOAGACUbDEPJ;
			}
		}

		public IList<CompoundElement> CompoundElements
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return EmptyObjects<CompoundElement>.EmptyReadOnlyIListT;
				}
				return cxOVvLLCCWOaUIOdINaIsXeyFdUW;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return null;
				}
				return xfTOtGXnPjccLfmajBZneeyjKCmdb;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return LJmpCFrENABMhmUxmGaTconkDyoGA.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return LJmpCFrENABMhmUxmGaTconkDyoGA.buttonElementIdentifiers_readOnly;
			}
		}

		internal ITryGetLocalizedName JjQEFVsgxnuheoCTguBsKAhENLgh
		{
			get
			{
				return FVAYVCRprbashwFMHsOsXIjUldRG;
			}
			set
			{
				FVAYVCRprbashwFMHsOsXIjUldRG = fVAYVCRprbashwFMHsOsXIjUldRG;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return gqBBvaapSenOnMRhqWThaJvkzlIz;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return 0;
				}
				return UIdaMBbhoaPpDkxYzBQNrzBGMYkp.Length;
			}
		}

		internal static Func<Controller, Guid, bool> CldhkNCkjGevYQnznnzdOruwoLwfA => ENqOdWeWHERswSblkppecAEtqNTy._003C_003E9.RvEnCiDHCZekRKfDSpMtseqIhdfs;

		internal static Func<Controller, Type, bool> vfxisWBzPytHQHawYsXJOealniZIb => ENqOdWeWHERswSblkppecAEtqNTy._003C_003E9.aszEtaBXhGpyhGlTjdiEfUDXwvFH;

		internal event Action<bool> TyrbvYABhmDwrDzwCNMrxYWfCIFLc
		{
			add
			{
				NaejNKMZZNPakaAvqcDycgFeGdPzA = (Action<bool>)Delegate.Combine(NaejNKMZZNPakaAvqcDycgFeGdPzA, b);
			}
			remove
			{
				NaejNKMZZNPakaAvqcDycgFeGdPzA = (Action<bool>)Delegate.Remove(NaejNKMZZNPakaAvqcDycgFeGdPzA, value2);
			}
		}

		internal Controller(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, bool[] P_8, HardwareButtonInfo[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
		{
			id = P_0;
			inputSource = P_1;
			_type = P_5;
			savDJAJJykdFgIDmPSBdENeZaLumA = P_6;
			_buttonCount = P_7;
			_name = P_2;
			_hardwareName = P_3;
			_hardwareIdentifier = P_4;
			zfVdfqKDuqZKjafBdqgdinjRQNeGb = P_12;
			LJmpCFrENABMhmUxmGaTconkDyoGA = P_10;
			lnSSmvghWhgBGduRCUgmuvuqLIcR = P_10.deviceLocalizationInfo;
			VgGDhiCahEDwVEFxeVUTANGrnOkNb = true;
			ZnRkLjoJZaBEcsqDJEgTJYVKjsWl = ReInput.id;
			jQhKYIjNbdWnRQFdwKPagPpdwDFA = new LocalizedString();
			HAetKXDaxQAhHDxKHfoZLQmYkcYr = new gjMBNBgPUgnpVrmJwQZQrVmLNmagb(delegate
			{
				_ = name;
			});
			DZmGiQIHoiKqUDJAaBfHOkGkWHHvB(P_11);
			vydslZNlwFgQqKdtdePqhlBOppHsA = new List<Element>(P_7);
			zXwJijGNGxLYWSfXsOAGACUbDEPJ = new ReadOnlyCollection<Element>(vydslZNlwFgQqKdtdePqhlBOppHsA);
			QIjcgKjyInQNPhToZRHAjmrEjEVib = new List<CompoundElement>();
			cxOVvLLCCWOaUIOdINaIsXeyFdUW = new ReadOnlyCollection<CompoundElement>(QIjcgKjyInQNPhToZRHAjmrEjEVib);
			buttons = new Button[P_7];
			if (P_8 == null || P_8.Length < P_7)
			{
				for (int num = 0; num < P_7; num++)
				{
					buttons[num] = new Button(this, P_10.buttonElementIdentifierIds[num], "Button " + num, false, (P_9 != null) ? P_9[num] : new HardwareButtonInfo());
					CModZicjRGTPMTvJlQVppzsGqidWA(buttons[num]);
				}
			}
			else
			{
				for (int num2 = 0; num2 < P_7; num2++)
				{
					buttons[num2] = new Button(this, P_10.buttonElementIdentifierIds[num2], "Button " + num2, P_8[num2], (P_9 != null) ? P_9[num2] : new HardwareButtonInfo());
					CModZicjRGTPMTvJlQVppzsGqidWA(buttons[num2]);
				}
			}
			buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
			UIdaMBbhoaPpDkxYzBQNrzBGMYkp = EmptyObjects<IControllerTemplate>.array;
			gqBBvaapSenOnMRhqWThaJvkzlIz = new ReadOnlyCollection<IControllerTemplate>(UIdaMBbhoaPpDkxYzBQNrzBGMYkp);
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((nYVWMTKfnKjTqnJzQqfdswXfeTcY)HAetKXDaxQAhHDxKHfoZLQmYkcYr).Localize();
			}
			Connected();
		}

		internal virtual void vXguOrVHQgZdRgenIvihyjDDIBEO()
		{
			tMqtMpSNHfUiGaKHMhnSIaCoCXsj = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return null;
			}
			if (LJmpCFrENABMhmUxmGaTconkDyoGA == null)
			{
				return null;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return buttons[buttonIndex];
		}

		public virtual CompoundElement GetCompoundElementById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return null;
			}
			int count = QIjcgKjyInQNPhToZRHAjmrEjEVib.Count;
			for (int i = 0; i < count; i++)
			{
				if (QIjcgKjyInQNPhToZRHAjmrEjEVib[i] != null && QIjcgKjyInQNPhToZRHAjmrEjEVib[i].id == elementIdentifierId)
				{
					return QIjcgKjyInQNPhToZRHAjmrEjEVib[i];
				}
			}
			return null;
		}

		[Obsolete("This method is deprecated. Use GetCompoundElementById instead.", false)]
		public virtual CompoundElement GetCompundElementById(int elementIdentifierId)
		{
			return GetCompoundElementById(elementIdentifierId);
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return -1;
			}
			return LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return null;
			}
			return LJmpCFrENABMhmUxmGaTconkDyoGA.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].value;
		}

		public virtual bool GetButtonDown(int index)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDown(int index)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].JustDoublePressed(speed);
		}

		public virtual double GetButtonTimePressed(int index)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].timePressed;
		}

		public virtual double GetButtonTimeUnpressed(int index)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressed(int index)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressed(int index)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].value)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonDown()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justPressed)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonUp()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justReleased)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonPrev()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].valuePrev)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonChanged()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justChangedState)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetButtonById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].value;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justReleased;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].JustDoublePressed(speed);
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].valuePrev;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			int buttonIndex = LJmpCFrENABMhmUxmGaTconkDyoGA.GetButtonIndex(elementIdentifierId);
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (mEhicSGrhgClctxRDsDCnmDphafV(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, LJmpCFrENABMhmUxmGaTconkDyoGA.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (YuEcuuWQkCAHlDRbqAaGBZzKsCSLA(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, LJmpCFrENABMhmUxmGaTconkDyoGA.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return PollForAllButtons();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return PollForAllButtonsDown();
		}

		[IteratorStateMachine(typeof(BzPdiPWuAwKoxbHsdyykihTdRXFi))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return new BzPdiPWuAwKoxbHsdyykihTdRXFi(-2)
			{
				YmHbWkvNrBbLoXQAzjadkugbojbe = this
			};
		}

		[IteratorStateMachine(typeof(NUmNhaWOVXQzZSrffkPDMuQNwGaR))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return new NUmNhaWOVXQzZSrffkPDMuQNwGaR(-2)
			{
				DHhngkmvZhCzlPmzTiUpvikUKcIH = this
			};
		}

		private bool mEhicSGrhgClctxRDsDCnmDphafV(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].qChIJtMmxeHxmgKkaWmKUQWKYHgb._excludeFromPolling)
			{
				return false;
			}
			P_1 = LJmpCFrENABMhmUxmGaTconkDyoGA.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool YuEcuuWQkCAHlDRbqAaGBZzKsCSLA(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].qChIJtMmxeHxmgKkaWmKUQWKYHgb._excludeFromPolling)
			{
				return false;
			}
			P_1 = LJmpCFrENABMhmUxmGaTconkDyoGA.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (KFSDRjcdFmeKtRuMIBFxbakEQeEGb == ReInput.currentFrame)
			{
				return;
			}
			aSLdvyuOUprjQTTRtwHTuinOYhrs = KFSDRjcdFmeKtRuMIBFxbakEQeEGb;
			KFSDRjcdFmeKtRuMIBFxbakEQeEGb = ReInput.currentFrame;
			if (!YIQmWgzAndolImZiEMJthwGYkyEM)
			{
				if (DXjiZuzjDrBcOipWkembjJvVpKl == uint.MaxValue)
				{
					DXjiZuzjDrBcOipWkembjJvVpKl = 0u;
				}
				else
				{
					DXjiZuzjDrBcOipWkembjJvVpKl++;
				}
			}
		}

		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			if (buttons == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < buttons.Length; i++)
			{
				double lastTimePressed = buttons[i].lastTimePressed;
				if (lastTimePressed > num)
				{
					num = lastTimePressed;
				}
			}
			return num;
		}

		public double GetLastTimeAnyButtonChanged()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0.0;
			}
			if (buttons == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < buttons.Length; i++)
			{
				double lastTimeStateChanged = buttons[i].lastTimeStateChanged;
				if (lastTimeStateChanged > num)
				{
					num = lastTimeStateChanged;
				}
			}
			return num;
		}

		public T GetExtension<T>() where T : class
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return null;
			}
			return xfTOtGXnPjccLfmajBZneeyjKCmdb as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return null;
			}
			for (int i = 0; i < UIdaMBbhoaPpDkxYzBQNrzBGMYkp.Length; i++)
			{
				if (UIdaMBbhoaPpDkxYzBQNrzBGMYkp[i].typeGuid == typeGuid)
				{
					return UIdaMBbhoaPpDkxYzBQNrzBGMYkp[i];
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return null;
			}
			for (int i = 0; i < UIdaMBbhoaPpDkxYzBQNrzBGMYkp.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(UIdaMBbhoaPpDkxYzBQNrzBGMYkp[i].GetType(), type))
				{
					return UIdaMBbhoaPpDkxYzBQNrzBGMYkp[i];
				}
			}
			return null;
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return null;
			}
			for (int i = 0; i < UIdaMBbhoaPpDkxYzBQNrzBGMYkp.Length; i++)
			{
				if (UIdaMBbhoaPpDkxYzBQNrzBGMYkp[i] as T != null)
				{
					return UIdaMBbhoaPpDkxYzBQNrzBGMYkp[i] as T;
				}
			}
			return null;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			for (int i = 0; i < UIdaMBbhoaPpDkxYzBQNrzBGMYkp.Length; i++)
			{
				if (UIdaMBbhoaPpDkxYzBQNrzBGMYkp[i].typeGuid == typeGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			for (int i = 0; i < UIdaMBbhoaPpDkxYzBQNrzBGMYkp.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(UIdaMBbhoaPpDkxYzBQNrzBGMYkp[i].GetType(), type))
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate<T>() where T : class
		{
			return ImplementsTemplate(typeof(T));
		}

		internal void RzHJhWabHbaSteSMOQrRDwKIMbbdA(IControllerTemplate[] P_0)
		{
			if (P_0 != null)
			{
				UIdaMBbhoaPpDkxYzBQNrzBGMYkp = P_0;
				gqBBvaapSenOnMRhqWThaJvkzlIz = new ReadOnlyCollection<IControllerTemplate>(UIdaMBbhoaPpDkxYzBQNrzBGMYkp);
			}
		}

		internal virtual void KvONimPsnvghlMkZzyXoBEjvJCHX(UpdateLoopType P_0)
		{
			bool num = ReInput.IsInputAllowed(_type);
			int num2 = _buttonCount;
			if (num)
			{
				for (int i = 0; i < num2; i++)
				{
					if (buttons[i].mtgepFFkBbbfzOBezhkfkZRJhmJm <= 0)
					{
						buttons[i].hiFDVqoPUcCLJOQmioHlwCylqVKr(P_0, i, zfVdfqKDuqZKjafBdqgdinjRQNeGb);
					}
				}
			}
			else
			{
				for (int j = 0; j < num2; j++)
				{
					if (buttons[j].mtgepFFkBbbfzOBezhkfkZRJhmJm <= 0)
					{
						buttons[j].FmHfHOwwwaZKocMXJUnCcrUsuPtL(P_0);
					}
				}
			}
			if (xfTOtGXnPjccLfmajBZneeyjKCmdb != null)
			{
				xfTOtGXnPjccLfmajBZneeyjKCmdb.UpdateData(P_0);
			}
		}

		internal virtual ButtonStateFlags cftCGKJlmpllERfsqWsBolAIXTuz(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.Off;
			}
			return buttons[P_0].UwdGDNaetQViXUQjTpQvSRaOGAoGA;
		}

		internal void DZmGiQIHoiKqUDJAaBfHOkGkWHHvB(Extension P_0)
		{
			if (P_0 == null)
			{
				xfTOtGXnPjccLfmajBZneeyjKCmdb = null;
				return;
			}
			if (xfTOtGXnPjccLfmajBZneeyjKCmdb != null)
			{
				PyspqJSprRuFBGASUIFHApFkWWbA(P_0);
				return;
			}
			P_0.SetController(this);
			xfTOtGXnPjccLfmajBZneeyjKCmdb = P_0.Clone();
		}

		internal void PyspqJSprRuFBGASUIFHApFkWWbA(Extension P_0)
		{
			if (xfTOtGXnPjccLfmajBZneeyjKCmdb != null)
			{
				xfTOtGXnPjccLfmajBZneeyjKCmdb.SetSource(P_0);
				xfTOtGXnPjccLfmajBZneeyjKCmdb.SetController(this);
				P_0?.SetController(this);
			}
			else
			{
				DZmGiQIHoiKqUDJAaBfHOkGkWHHvB(P_0);
			}
		}

		internal virtual void scCwpLEHFiuvitLgzEfOOpCTYgPj()
		{
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i] != null)
				{
					buttons[i].Reset();
				}
			}
			if (zfVdfqKDuqZKjafBdqgdinjRQNeGb != null)
			{
				zfVdfqKDuqZKjafBdqgdinjRQNeGb.ClearData();
			}
			if (xfTOtGXnPjccLfmajBZneeyjKCmdb != null)
			{
				xfTOtGXnPjccLfmajBZneeyjKCmdb.Clear();
			}
		}

		internal virtual bool XExEgWAUoYDZHOcZKsQgKkhupxolA(bool P_0)
		{
			if (VgGDhiCahEDwVEFxeVUTANGrnOkNb == P_0)
			{
				return false;
			}
			if (!P_0)
			{
				scCwpLEHFiuvitLgzEfOOpCTYgPj();
			}
			VgGDhiCahEDwVEFxeVUTANGrnOkNb = P_0;
			if (NaejNKMZZNPakaAvqcDycgFeGdPzA != null)
			{
				NaejNKMZZNPakaAvqcDycgFeGdPzA(P_0);
			}
			return true;
		}

		internal virtual void YdxptuxNGpUaQtWkYqBlEXOcgbkk(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			try
			{
				ControllerMap.QXFruTPDQsWAkpbQTcKsnAHJFyR();
				P_0.controllerId = id;
				IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
				for (int i = 0; i < buttonMaps.Count; i++)
				{
					MLdcpPOYjvtoDJPENGusyemNCWAq(P_0, buttonMaps[i]);
				}
				for (int num = buttonMaps.Count - 1; num >= 0; num--)
				{
					if (buttonMaps[num].elementIndex < 0)
					{
						P_0.DeleteElementMap(buttonMaps[num].oETQtUYpoAHvrDdxockLYpfjFkywA);
					}
				}
			}
			finally
			{
				ControllerMap.rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
			}
		}

		internal virtual void MLdcpPOYjvtoDJPENGusyemNCWAq(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null && P_1._elementType == ControllerElementType.Button)
			{
				P_1.PKuPVtkPJEWiXrQtJpzVObMiLTlx(P_0);
			}
		}

		internal bool WLGHtVFmzwndbXVJgbeTrXDgZPEK(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int xrZnVueTRmSKYHvJBgyRGORsqtGX = P_0.xrZnVueTRmSKYHvJBgyRGORsqtGX;
			if (xrZnVueTRmSKYHvJBgyRGORsqtGX < 0 || xrZnVueTRmSKYHvJBgyRGORsqtGX >= _buttonCount)
			{
				return false;
			}
			P_3 = buttons[xrZnVueTRmSKYHvJBgyRGORsqtGX].vznhzgUaUgIIXzJXsvveSoXuPUAv;
			float num = ((!P_3) ? (buttons[xrZnVueTRmSKYHvJBgyRGORsqtGX].value ? 1f : 0f) : buttons[xrZnVueTRmSKYHvJBgyRGORsqtGX].pressure);
			if (num > 0f)
			{
				if (P_0._elementType == ControllerElementType.Button)
				{
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (P_0._elementType == ControllerElementType.Axis)
				{
					if (P_0._axisRange == AxisRange.Full)
					{
						if (P_0._invert)
						{
							num *= -1f;
						}
					}
					else if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
			}
			P_2 = num;
			return true;
		}

		internal bool oCcQScUEXrJhndBIOknbTkDOlquu(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
		{
			P_3 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			float num = (P_2 ? 1f : 0f);
			if (num > 0f)
			{
				if (P_0._elementType == ControllerElementType.Button)
				{
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (P_0._elementType == ControllerElementType.Axis)
				{
					if (P_0._axisRange == AxisRange.Full)
					{
						if (P_0._invert)
						{
							num *= -1f;
						}
					}
					else if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
			}
			P_3 = num;
			return true;
		}

		internal void CModZicjRGTPMTvJlQVppzsGqidWA(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(vydslZNlwFgQqKdtdePqhlBOppHsA, P_0);
			}
		}

		internal void byDDQTFCPCzrcWthyknzdKcxrYzZ(CompoundElement P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(QIjcgKjyInQNPhToZRHAjmrEjEVib, P_0);
			}
		}

		internal virtual Guid lxHeMvjOHWEPOJWmUNkKrPHZHkjCA()
		{
			return Guid.Empty;
		}

		internal virtual void crbQLMpBgFCTkCHGXdkEoAiefEsyA(bool P_0)
		{
			if (!P_0 && !ReInput.IsInputAllowed(_type) && xfTOtGXnPjccLfmajBZneeyjKCmdb != null)
			{
				xfTOtGXnPjccLfmajBZneeyjKCmdb.Clear();
			}
		}

		protected virtual void Connected()
		{
			_isConnected = true;
		}

		protected virtual void Disconnected()
		{
			_isConnected = false;
			if (zfVdfqKDuqZKjafBdqgdinjRQNeGb != null)
			{
				zfVdfqKDuqZKjafBdqgdinjRQNeGb.ClearData();
			}
		}

		[CompilerGenerated]
		private void SmagEUdYNkeYagqyCleRIeJqSYrpb()
		{
			_ = name;
		}
	}
}
