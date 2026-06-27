using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerTemplate : IControllerTemplate, IControllerTemplate_Internal, leeNpeIpkRWAaDYnewmtyKpQcRpw
	{
		internal abstract class NLKTKONGPKzcMDBBBSopKqtlrhMj : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate krpjQovFRLYfgkpjixeTeGFPhtsz;

			private readonly int zRCLoWTKLdfVbkAcUwnXKgFREsFf;

			private readonly ControllerTemplateElementType dWtTacViPdtfatEojdhhzNcneroL;

			protected readonly int uzvBoteyxDuGcjhWcCvCryaSjbvOA;

			protected readonly ZtWDGFywnarTKNuYsScniCpUdPO fLtOinTkzyCZhZtZezHOmIueZhqq;

			int IControllerTemplateElement.id
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return -1;
					}
					return zRCLoWTKLdfVbkAcUwnXKgFREsFf;
				}
			}

			string IControllerTemplateElement.descriptiveName
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return fLtOinTkzyCZhZtZezHOmIueZhqq.lhqYvBnTykeMuKCzFAtyigejBsLQ;
				}
			}

			internal string nAPlWBDWpVfOhdkBajKkgUwEgSoGA => fLtOinTkzyCZhZtZezHOmIueZhqq.nonLocalizedDescriptiveName;

			ControllerTemplateElementType IControllerTemplateElement.type
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return ControllerTemplateElementType.Axis;
					}
					return dWtTacViPdtfatEojdhhzNcneroL;
				}
			}

			IControllerTemplate IControllerTemplateElement_Internal.parent => krpjQovFRLYfgkpjixeTeGFPhtsz;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected NLKTKONGPKzcMDBBBSopKqtlrhMj(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, ZtWDGFywnarTKNuYsScniCpUdPO P_3)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_3 == null)
				{
					throw new ArgumentNullException("localizedElement");
				}
				krpjQovFRLYfgkpjixeTeGFPhtsz = P_0;
				zRCLoWTKLdfVbkAcUwnXKgFREsFf = P_1;
				dWtTacViPdtfatEojdhhzNcneroL = P_2;
				uzvBoteyxDuGcjhWcCvCryaSjbvOA = ReInput.id;
				fLtOinTkzyCZhZtZezHOmIueZhqq = P_3;
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);

			protected static ZtWDGFywnarTKNuYsScniCpUdPO fftLUgIMpbksXKYeQKhiYDWMhlNu(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3)
			{
				return tDUNusKnwjJTgUVvFEgBJSRSVvFo.RlyxGLyIXWEmRCQOumKTeWwjPakp(new ZtWDGFywnarTKNuYsScniCpUdPO(nauOEbbkmNtlfLrDTZFhKRtjHETd.eudimHqpxFKkKYIUirKomrDrUONc(eXRjOdORfaNOqMSguWnRpnOIZGBy.ControllerTemplate, RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Unknown, RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3));
			}
		}

		internal abstract class NpBuaZDfxvGFUsjZWqobcGASiJPjA : NLKTKONGPKzcMDBBBSopKqtlrhMj
		{
			protected readonly int sXJAmWYUZdnLjnyhibpCOgsVgYZN;

			protected readonly crOlyXsngArIbrggzbgTinTdpaRD[] LpbHmOqgziOxWEnqFNAUrbqqdXWCA;

			bool NLKTKONGPKzcMDBBBSopKqtlrhMj.exists
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return false;
					}
					if (LpbHmOqgziOxWEnqFNAUrbqqdXWCA == null)
					{
						return false;
					}
					for (int i = 0; i < LpbHmOqgziOxWEnqFNAUrbqqdXWCA.Length; i++)
					{
						if (LpbHmOqgziOxWEnqFNAUrbqqdXWCA[i].pPLsaxMkPrEPOHtzjbwFjFnUzFMQ != null)
						{
							return true;
						}
					}
					return false;
				}
			}

			protected NpBuaZDfxvGFUsjZWqobcGASiJPjA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, IList<crOlyXsngArIbrggzbgTinTdpaRD> P_3, ZtWDGFywnarTKNuYsScniCpUdPO P_4)
				: base(P_0, P_1, P_2, P_4)
			{
				LpbHmOqgziOxWEnqFNAUrbqqdXWCA = ((P_3 != null) ? ListTools.ToArray(P_3) : null);
				sXJAmWYUZdnLjnyhibpCOgsVgYZN = ((LpbHmOqgziOxWEnqFNAUrbqqdXWCA != null) ? LpbHmOqgziOxWEnqFNAUrbqqdXWCA.Length : 0);
			}
		}

		internal abstract class NyRAZHYHHpcMMrAnpMRemLtHktrd : NpBuaZDfxvGFUsjZWqobcGASiJPjA, IControllerTemplateAxis, IControllerTemplateElement, IControllerTemplateButton
		{
			private vgyLkSessULxWIPilRPgXWnpbfGE VMJekasybjwMjHCtzrnmUbcFpodH;

			public float DtOHNfRGKZfYmMdBfMdzqWiuubdJ
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return 0f;
					}
					if (sXJAmWYUZdnLjnyhibpCOgsVgYZN == 1)
					{
						return LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].oZLxrLapzxsOfgVBjBXWciRiQukJ;
					}
					if (sXJAmWYUZdnLjnyhibpCOgsVgYZN == 2)
					{
						float num = LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].oZLxrLapzxsOfgVBjBXWciRiQukJ;
						float num2 = LpbHmOqgziOxWEnqFNAUrbqqdXWCA[1].oZLxrLapzxsOfgVBjBXWciRiQukJ;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public float LuWcvwRmPVlobeFRRqMELIJRjxEP
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return 0f;
					}
					if (sXJAmWYUZdnLjnyhibpCOgsVgYZN == 1)
					{
						return LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].OWXXOoSPxDSFRNrSaaJNwjovMWKT;
					}
					if (sXJAmWYUZdnLjnyhibpCOgsVgYZN == 2)
					{
						float num = LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].OWXXOoSPxDSFRNrSaaJNwjovMWKT;
						float num2 = LpbHmOqgziOxWEnqFNAUrbqqdXWCA[1].OWXXOoSPxDSFRNrSaaJNwjovMWKT;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool zJLbxUiQfUwZqjDYdxLyrgeVcgnhb
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return false;
					}
					if (sXJAmWYUZdnLjnyhibpCOgsVgYZN == 1)
					{
						return LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].altxESjUSoklbmiVvquimgIkhwMX;
					}
					if (sXJAmWYUZdnLjnyhibpCOgsVgYZN == 2)
					{
						if (!LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].altxESjUSoklbmiVvquimgIkhwMX)
						{
							return LpbHmOqgziOxWEnqFNAUrbqqdXWCA[1].altxESjUSoklbmiVvquimgIkhwMX;
						}
						return true;
					}
					return false;
				}
			}

			public bool WPaVWvFBnBKcSAKiiKcNPzSSmXFB
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return false;
					}
					if (sXJAmWYUZdnLjnyhibpCOgsVgYZN == 1)
					{
						return LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].kNMADZFSKIoITVmzVZcAaTVYupQy;
					}
					if (sXJAmWYUZdnLjnyhibpCOgsVgYZN == 2)
					{
						if (!LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].kNMADZFSKIoITVmzVZcAaTVYupQy)
						{
							return LpbHmOqgziOxWEnqFNAUrbqqdXWCA[1].kNMADZFSKIoITVmzVZcAaTVYupQy;
						}
						return true;
					}
					return false;
				}
			}

			string IControllerTemplateAxis.positiveDescriptiveName
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return jsMftknUxLWTgQQDpEWdSpEEAkaV.VDnidYSrVzfmMAhEuoBAChaeIKFBb;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return jsMftknUxLWTgQQDpEWdSpEEAkaV.lONPQlINmkffynpHZhFLktmdPFRnA;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return 0f;
					}
					return DtOHNfRGKZfYmMdBfMdzqWiuubdJ;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return 0f;
					}
					return LuWcvwRmPVlobeFRRqMELIJRjxEP;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return VMJekasybjwMjHCtzrnmUbcFpodH;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return false;
					}
					return zJLbxUiQfUwZqjDYdxLyrgeVcgnhb;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return false;
					}
					return WPaVWvFBnBKcSAKiiKcNPzSSmXFB;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return false;
					}
					if (sXJAmWYUZdnLjnyhibpCOgsVgYZN == 1)
					{
						return LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].DujPcWPvxJNReJRxmAazGZLzvCYMA;
					}
					if (sXJAmWYUZdnLjnyhibpCOgsVgYZN == 2)
					{
						if (!LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].DujPcWPvxJNReJRxmAazGZLzvCYMA || LpbHmOqgziOxWEnqFNAUrbqqdXWCA[1].kNMADZFSKIoITVmzVZcAaTVYupQy)
						{
							if (LpbHmOqgziOxWEnqFNAUrbqqdXWCA[1].DujPcWPvxJNReJRxmAazGZLzvCYMA)
							{
								return !LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].kNMADZFSKIoITVmzVZcAaTVYupQy;
							}
							return false;
						}
						return true;
					}
					return false;
				}
			}

			bool IControllerTemplateButton.justReleased
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return false;
					}
					if (sXJAmWYUZdnLjnyhibpCOgsVgYZN == 1)
					{
						return LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].ycgyvAfdIaKWsNCXfgXQkoAlOIvr;
					}
					if (sXJAmWYUZdnLjnyhibpCOgsVgYZN == 2)
					{
						if (!LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].ycgyvAfdIaKWsNCXfgXQkoAlOIvr || LpbHmOqgziOxWEnqFNAUrbqqdXWCA[1].altxESjUSoklbmiVvquimgIkhwMX)
						{
							if (LpbHmOqgziOxWEnqFNAUrbqqdXWCA[1].ycgyvAfdIaKWsNCXfgXQkoAlOIvr)
							{
								return !LpbHmOqgziOxWEnqFNAUrbqqdXWCA[0].altxESjUSoklbmiVvquimgIkhwMX;
							}
							return false;
						}
						return true;
					}
					return false;
				}
			}

			bool IControllerTemplateButton.justChangedState
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return false;
					}
					return zJLbxUiQfUwZqjDYdxLyrgeVcgnhb != WPaVWvFBnBKcSAKiiKcNPzSSmXFB;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return 0f;
					}
					return DtOHNfRGKZfYmMdBfMdzqWiuubdJ;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return 0f;
					}
					return LuWcvwRmPVlobeFRRqMELIJRjxEP;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return VMJekasybjwMjHCtzrnmUbcFpodH;
				}
			}

			IControllerTemplateElementSource NLKTKONGPKzcMDBBBSopKqtlrhMj.source
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return VMJekasybjwMjHCtzrnmUbcFpodH;
				}
			}

			int NLKTKONGPKzcMDBBBSopKqtlrhMj.elementCount => 0;

			IControllerTemplateAxis IControllerTemplateButton.AsAxis
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return this;
				}
			}

			IControllerTemplateButton IControllerTemplateAxis.AsButton
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return this;
				}
			}

			protected LbTGHcrczWJcImuIJAFZOrdLiHsS jsMftknUxLWTgQQDpEWdSpEEAkaV => (LbTGHcrczWJcImuIJAFZOrdLiHsS)fLtOinTkzyCZhZtZezHOmIueZhqq;

			protected NyRAZHYHHpcMMrAnpMRemLtHktrd(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, vgyLkSessULxWIPilRPgXWnpbfGE P_3, IList<crOlyXsngArIbrggzbgTinTdpaRD> P_4, LbTGHcrczWJcImuIJAFZOrdLiHsS P_5)
				: base(P_0, P_1, P_2, P_4, P_5)
			{
				if (P_4 != null && P_4.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
				if (P_3 == null)
				{
					throw new ArgumentNullException("target");
				}
				VMJekasybjwMjHCtzrnmUbcFpodH = P_3;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange axisRange)
			{
				if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
				{
					ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
					return null;
				}
				return axisRange switch
				{
					AxisRange.Full => base.Rewired_002EIControllerTemplateElement_002EdescriptiveName, 
					AxisRange.Positive => ((IControllerTemplateAxis)this).positiveDescriptiveName, 
					AxisRange.Negative => ((IControllerTemplateAxis)this).negativeDescriptiveName, 
					_ => throw new NotImplementedException(), 
				};
			}

			public override IControllerTemplateElement GetElement(int index)
			{
				return null;
			}

			public override int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list)
			{
				if (find.elementIdentifierId < 0)
				{
					return 0;
				}
				int num = 0;
				switch (base.Rewired_002EIControllerTemplateElement_002Etype)
				{
				case ControllerTemplateElementType.Axis:
				{
					IControllerTemplateAxisSource vMJekasybjwMjHCtzrnmUbcFpodH = VMJekasybjwMjHCtzrnmUbcFpodH;
					if (vMJekasybjwMjHCtzrnmUbcFpodH.splitAxis)
					{
						if (UTMSsfNXhTuNvXzBvfUsrMTDgAucA(find, vMJekasybjwMjHCtzrnmUbcFpodH.positiveTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
							num++;
						}
						if (UTMSsfNXhTuNvXzBvfUsrMTDgAucA(find, vMJekasybjwMjHCtzrnmUbcFpodH.negativeTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
							num++;
						}
					}
					else if (UTMSsfNXhTuNvXzBvfUsrMTDgAucA(find, vMJekasybjwMjHCtzrnmUbcFpodH.fullTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
						num++;
					}
					break;
				}
				case ControllerTemplateElementType.Button:
					if (UTMSsfNXhTuNvXzBvfUsrMTDgAucA(find, ((IControllerTemplateButtonSource)VMJekasybjwMjHCtzrnmUbcFpodH).target))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Full));
						num++;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				return num;
			}

			private static bool UTMSsfNXhTuNvXzBvfUsrMTDgAucA(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				if (P_1.elementIdentifierId != P_0.elementIdentifierId)
				{
					return false;
				}
				switch (P_1.elementType)
				{
				case ControllerElementType.Axis:
				{
					AxisRange axisRange = P_1.axisRange;
					if (axisRange == AxisRange.Full)
					{
						return true;
					}
					if (axisRange == P_0.axisRange)
					{
						return true;
					}
					return false;
				}
				case ControllerElementType.Button:
					return true;
				default:
					throw new NotImplementedException();
				}
			}
		}

		internal sealed class aCNOImdowXeuOeDSOlRxmDdKjEeTA : NyRAZHYHHpcMMrAnpMRemLtHktrd
		{
			public aCNOImdowXeuOeDSOlRxmDdKjEeTA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, vgyLkSessULxWIPilRPgXWnpbfGE P_8, IList<crOlyXsngArIbrggzbgTinTdpaRD> P_9)
				: base(P_0, P_1, ControllerTemplateElementType.Axis, P_8, P_9, (LbTGHcrczWJcImuIJAFZOrdLiHsS)tDUNusKnwjJTgUVvFEgBJSRSVvFo.RlyxGLyIXWEmRCQOumKTeWwjPakp(new LbTGHcrczWJcImuIJAFZOrdLiHsS(fdpfgJnMxjBVlnubvZxxSwBKSBwH.OZbBdRHsAXndfzjevGuknadrKPNAA(eXRjOdORfaNOqMSguWnRpnOIZGBy.ControllerTemplate, RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Axis, RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
			{
				if (P_9 != null && P_9.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static aCNOImdowXeuOeDSOlRxmDdKjEeTA zJsofxLWijpfiznlAeRzCQMDZUtaA(IControllerTemplate_Internal P_0)
			{
				return new aCNOImdowXeuOeDSOlRxmDdKjEeTA(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, vgyLkSessULxWIPilRPgXWnpbfGE.apVaRSCStYlLRACQjFZtmwVgcaPhb(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class JidWVpaKPLETXBSGHuHXIwrPNjdtA : NyRAZHYHHpcMMrAnpMRemLtHktrd
		{
			public JidWVpaKPLETXBSGHuHXIwrPNjdtA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, vgyLkSessULxWIPilRPgXWnpbfGE P_8, IList<crOlyXsngArIbrggzbgTinTdpaRD> P_9)
				: base(P_0, P_1, ControllerTemplateElementType.Button, P_8, P_9, (LbTGHcrczWJcImuIJAFZOrdLiHsS)tDUNusKnwjJTgUVvFEgBJSRSVvFo.RlyxGLyIXWEmRCQOumKTeWwjPakp(new LbTGHcrczWJcImuIJAFZOrdLiHsS(fdpfgJnMxjBVlnubvZxxSwBKSBwH.OZbBdRHsAXndfzjevGuknadrKPNAA(eXRjOdORfaNOqMSguWnRpnOIZGBy.ControllerTemplate, RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Button, RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
			{
				if (P_9 != null && P_9.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static JidWVpaKPLETXBSGHuHXIwrPNjdtA CZSnJBbqLMRyBbudHFaWdHYzBJEi(IControllerTemplate_Internal P_0)
			{
				return new JidWVpaKPLETXBSGHuHXIwrPNjdtA(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, vgyLkSessULxWIPilRPgXWnpbfGE.apVaRSCStYlLRACQjFZtmwVgcaPhb(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class jlfxTaYYYmaQGQQaVgCKYatTdmtJ : NLKTKONGPKzcMDBBBSopKqtlrhMj
		{
			protected readonly int MLlXedZCjekzERHyMPnYhshAGrZ;

			protected readonly NLKTKONGPKzcMDBBBSopKqtlrhMj[] YkEtPSHWfPCvxQbDONSnyGBtNlKG;

			bool NLKTKONGPKzcMDBBBSopKqtlrhMj.exists
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return false;
					}
					for (int i = 0; i < MLlXedZCjekzERHyMPnYhshAGrZ; i++)
					{
						if (YkEtPSHWfPCvxQbDONSnyGBtNlKG[i].exists)
						{
							return true;
						}
					}
					return false;
				}
			}

			IControllerTemplateElementSource NLKTKONGPKzcMDBBBSopKqtlrhMj.source
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return null;
				}
			}

			int NLKTKONGPKzcMDBBBSopKqtlrhMj.elementCount => MLlXedZCjekzERHyMPnYhshAGrZ;

			protected jlfxTaYYYmaQGQQaVgCKYatTdmtJ(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, NLKTKONGPKzcMDBBBSopKqtlrhMj[] P_3, ZtWDGFywnarTKNuYsScniCpUdPO P_4)
				: base(P_0, P_1, P_2, P_4)
			{
				if (P_3 == null)
				{
					throw new ArgumentNullException("elements");
				}
				if (P_3.Length == 0)
				{
					throw new ArgumentException("elements.Length is zero.");
				}
				for (int i = 0; i < P_3.Length; i++)
				{
					if (P_3[i] == null)
					{
						throw new ArgumentNullException("elements contains a null entry.");
					}
				}
				YkEtPSHWfPCvxQbDONSnyGBtNlKG = P_3;
				MLlXedZCjekzERHyMPnYhshAGrZ = P_3.Length;
			}

			public virtual IControllerTemplateElement SWnLjvNzgbupcFbxgDqMxHGXoDNl(int P_0)
			{
				return YkEtPSHWfPCvxQbDONSnyGBtNlKG[P_0];
			}

			public virtual int wKkWWxAANWnMzJZZgkjfAPzwyZGi(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				for (int i = 0; i < YkEtPSHWfPCvxQbDONSnyGBtNlKG.Length; i++)
				{
					num += YkEtPSHWfPCvxQbDONSnyGBtNlKG[i].GetElementTargets(P_0, ref P_1);
				}
				return num;
			}
		}

		internal abstract class HIIPnMZdwZbyfyCgzexIwmlosSNj : jlfxTaYYYmaQGQQaVgCKYatTdmtJ, IControllerTemplateAxis2D, IControllerTemplateElement
		{
			protected const int VpKMrNnUoeiWNkaEBcDxTPQKOjVF = 0;

			protected const int iOsIUZWhmGkvIeLtQBKhXrYrMsxH = 1;

			protected const int ZdduDRZvvKMsshpsvgfXdmzKGDrx = 2;

			Vector2 IControllerTemplateAxis2D.value
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return Vector2.zero;
					}
					return new Vector2((MLlXedZCjekzERHyMPnYhshAGrZ > 0) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 1) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ : 0f);
				}
			}

			Vector2 IControllerTemplateAxis2D.valuePrev
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return Vector2.zero;
					}
					return new Vector2((MLlXedZCjekzERHyMPnYhshAGrZ > 0) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0]).LuWcvwRmPVlobeFRRqMELIJRjxEP : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 1) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1]).LuWcvwRmPVlobeFRRqMELIJRjxEP : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.horizontal
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.vertical
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1];
				}
			}

			protected HIIPnMZdwZbyfyCgzexIwmlosSNj(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, NLKTKONGPKzcMDBBBSopKqtlrhMj[] P_3, ZtWDGFywnarTKNuYsScniCpUdPO P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class NRKoYzxpLfMwORsfzWthefVzuPix : jlfxTaYYYmaQGQQaVgCKYatTdmtJ, IControllerTemplateAxis3D, IControllerTemplateElement
		{
			protected const int CdXdtguVCJOmlaFzXulNNfgKKNLH = 0;

			protected const int elDyGDzBBqzTDQTldRRuSRAcQqkA = 1;

			protected const int QJyOzPxHASAfysCFmxHCuqrNyXxJ = 2;

			protected const int DojvFHNatGEawtsPTdhzXblLMzCU = 3;

			Vector3 IControllerTemplateAxis3D.value
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return Vector3.zero;
					}
					return new Vector3((MLlXedZCjekzERHyMPnYhshAGrZ > 0) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 1) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 2) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ : 0f);
				}
			}

			Vector3 IControllerTemplateAxis3D.valuePrev
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return Vector3.zero;
					}
					return new Vector3((MLlXedZCjekzERHyMPnYhshAGrZ > 0) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0]).LuWcvwRmPVlobeFRRqMELIJRjxEP : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 1) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1]).LuWcvwRmPVlobeFRRqMELIJRjxEP : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 2) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2]).LuWcvwRmPVlobeFRRqMELIJRjxEP : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.horizontal
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.vertical
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.depth
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2];
				}
			}

			protected NRKoYzxpLfMwORsfzWthefVzuPix(IControllerTemplate_Internal P_0, int P_1, ControllerTemplateElementType P_2, NLKTKONGPKzcMDBBBSopKqtlrhMj[] P_3, ZtWDGFywnarTKNuYsScniCpUdPO P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class zQcNitMAIXyCQUadGGhQqQCTIysf : jlfxTaYYYmaQGQQaVgCKYatTdmtJ, IControllerTemplateAxis6D, IControllerTemplateElement
		{
			protected const int qozMvTWREjxKOmOTWpBkTEpNbRdt = 0;

			protected const int FWpbWgFmTckhzeFycZjjWqZoiYCXb = 1;

			protected const int nHqLxRIIBuBscDiUQThcfMjgaQRr = 2;

			protected const int QrizoBZrxPLfkfNqGqLohqCxRzPq = 3;

			protected const int VRiTowcjlQOduNXhdXlYvOwvfzoG = 4;

			protected const int QdNncibxsjcXHIJkNUsCNMfxBsWJ = 5;

			protected const int gwegzBBmlHAmMlCtZnDXLFSNsOtRA = 6;

			Vector3 IControllerTemplateAxis6D.position
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return Vector3.zero;
					}
					return new Vector3((MLlXedZCjekzERHyMPnYhshAGrZ > 0) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 1) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 2) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.positionPrev
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return Vector3.zero;
					}
					return new Vector3((MLlXedZCjekzERHyMPnYhshAGrZ > 0) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0]).LuWcvwRmPVlobeFRRqMELIJRjxEP : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 1) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1]).LuWcvwRmPVlobeFRRqMELIJRjxEP : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 2) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2]).LuWcvwRmPVlobeFRRqMELIJRjxEP : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotation
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return Vector3.zero;
					}
					return new Vector3((MLlXedZCjekzERHyMPnYhshAGrZ > 3) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[3]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 4) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[4]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 5) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[5]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotationPrev
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return Vector3.zero;
					}
					return new Vector3((MLlXedZCjekzERHyMPnYhshAGrZ > 3) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[3]).LuWcvwRmPVlobeFRRqMELIJRjxEP : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 4) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[4]).LuWcvwRmPVlobeFRRqMELIJRjxEP : 0f, (MLlXedZCjekzERHyMPnYhshAGrZ > 5) ? ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[5]).LuWcvwRmPVlobeFRRqMELIJRjxEP : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionX
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionY
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionZ
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationX
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[3];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationY
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[4];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationZ
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[5];
				}
			}

			protected zQcNitMAIXyCQUadGGhQqQCTIysf(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, NLKTKONGPKzcMDBBBSopKqtlrhMj[] P_3, ZtWDGFywnarTKNuYsScniCpUdPO P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal sealed class fkkfajGazdStCbXGmCxMPjnImxzq : NRKoYzxpLfMwORsfzWthefVzuPix, IControllerTemplateStick, IControllerTemplateElement
		{
			private const int EinkPWOQvUpRLheXbMleBkyLXIik = 3;

			IControllerTemplateAxis IControllerTemplateStick.rotation
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2];
				}
			}

			private fkkfajGazdStCbXGmCxMPjnImxzq(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NLKTKONGPKzcMDBBBSopKqtlrhMj[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Stick, P_4, NLKTKONGPKzcMDBBBSopKqtlrhMj.fftLUgIMpbksXKYeQKhiYDWMhlNu(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			public fkkfajGazdStCbXGmCxMPjnImxzq(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NyRAZHYHHpcMMrAnpMRemLtHktrd P_4, NyRAZHYHHpcMMrAnpMRemLtHktrd P_5, NyRAZHYHHpcMMrAnpMRemLtHktrd P_6)
				: this(P_0, P_1, P_2, P_3, new NLKTKONGPKzcMDBBBSopKqtlrhMj[3] { P_4, P_5, P_6 })
			{
			}
		}

		internal sealed class mDNJRXwSGSHugEjFhABIMEhRmAaB : HIIPnMZdwZbyfyCgzexIwmlosSNj, IControllerTemplateThumbStick, IControllerTemplateElement
		{
			private const int XxaiQDbuMmKtNzSpAcjhFxrubOum = 2;

			private const int JuSUUwXDiLXpVxiZLcKDWkVaxEDb = 3;

			IControllerTemplateButton IControllerTemplateThumbStick.press
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2];
				}
			}

			private mDNJRXwSGSHugEjFhABIMEhRmAaB(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NLKTKONGPKzcMDBBBSopKqtlrhMj[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.ThumbStick, P_4, NLKTKONGPKzcMDBBBSopKqtlrhMj.fftLUgIMpbksXKYeQKhiYDWMhlNu(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal mDNJRXwSGSHugEjFhABIMEhRmAaB(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NyRAZHYHHpcMMrAnpMRemLtHktrd P_4, NyRAZHYHHpcMMrAnpMRemLtHktrd P_5, NyRAZHYHHpcMMrAnpMRemLtHktrd P_6)
				: this(P_0, P_1, P_2, P_3, new NLKTKONGPKzcMDBBBSopKqtlrhMj[3] { P_4, P_5, P_6 })
			{
			}
		}

		internal sealed class WNmHuKBjAHAoPSKJdfySJEwwUsGd : jlfxTaYYYmaQGQQaVgCKYatTdmtJ, IControllerTemplateDPad, IControllerTemplateElement
		{
			private const int pgICfWhPoZlZoFCgzMaUBnUyyZOEA = 0;

			private const int pEjbUiJLRiACguWAvjdmCZrbWhvhA = 1;

			private const int HShcNqSGUqZVrbPpGamSfAbVOkNwA = 2;

			private const int GTGmwJoflMBIpkiBnCGkUYesQizx = 3;

			private const int nRZMhEKoXzlwIaeJZXAUsRdyuzHC = 4;

			private const int gKNPKLZlrBALbJHaTMFYSaKIVhiRA = 5;

			Vector2 IControllerTemplateDPad.value
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ + ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ * -1f, -1f, 1f), MathTools.Clamp(((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[3]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ * -1f + ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ, -1f, 1f));
				}
			}

			Vector2 IControllerTemplateDPad.valuePrev
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0]).LuWcvwRmPVlobeFRRqMELIJRjxEP + ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2]).LuWcvwRmPVlobeFRRqMELIJRjxEP * -1f, -1f, 1f), MathTools.Clamp(((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[3]).LuWcvwRmPVlobeFRRqMELIJRjxEP * -1f + ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1]).LuWcvwRmPVlobeFRRqMELIJRjxEP, -1f, 1f));
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.up
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.right
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.down
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.left
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[3];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.press
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[4];
				}
			}

			private WNmHuKBjAHAoPSKJdfySJEwwUsGd(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NLKTKONGPKzcMDBBBSopKqtlrhMj[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.DPad, P_4, NLKTKONGPKzcMDBBBSopKqtlrhMj.fftLUgIMpbksXKYeQKhiYDWMhlNu(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal WNmHuKBjAHAoPSKJdfySJEwwUsGd(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NyRAZHYHHpcMMrAnpMRemLtHktrd P_4, NyRAZHYHHpcMMrAnpMRemLtHktrd P_5, NyRAZHYHHpcMMrAnpMRemLtHktrd P_6, NyRAZHYHHpcMMrAnpMRemLtHktrd P_7, NyRAZHYHHpcMMrAnpMRemLtHktrd P_8)
				: this(P_0, P_1, P_2, P_3, new NLKTKONGPKzcMDBBBSopKqtlrhMj[5] { P_4, P_5, P_6, P_7, P_8 })
			{
			}
		}

		internal sealed class DtCoGyWjDHWvawQaLePRdQNmbvqoA : jlfxTaYYYmaQGQQaVgCKYatTdmtJ, IControllerTemplateThrottle, IControllerTemplateElement
		{
			private const int lsZQgtWNIRZEuzhYSMjiXrjwgzIj = 0;

			private const int tkgUXNnlsODaNsHACxVDMWDNxVRg = 1;

			private const int jRafvgTfAtBhLnusonHvtHLzhuTBA = 2;

			float IControllerTemplateThrottle.value
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return 0f;
					}
					return ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ;
				}
			}

			float IControllerTemplateThrottle.valuePrev
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return 0f;
					}
					return ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0]).LuWcvwRmPVlobeFRRqMELIJRjxEP;
				}
			}

			IControllerTemplateAxis IControllerTemplateThrottle.throttle
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0];
				}
			}

			IControllerTemplateButton IControllerTemplateThrottle.minDetent
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1];
				}
			}

			private DtCoGyWjDHWvawQaLePRdQNmbvqoA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NLKTKONGPKzcMDBBBSopKqtlrhMj[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Throttle, P_4, NLKTKONGPKzcMDBBBSopKqtlrhMj.fftLUgIMpbksXKYeQKhiYDWMhlNu(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 2)
				{
					throw new ArgumentException("elements.Length must be " + 2);
				}
			}

			internal DtCoGyWjDHWvawQaLePRdQNmbvqoA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NyRAZHYHHpcMMrAnpMRemLtHktrd P_4, NyRAZHYHHpcMMrAnpMRemLtHktrd P_5)
				: this(P_0, P_1, P_2, P_3, new NLKTKONGPKzcMDBBBSopKqtlrhMj[2] { P_4, P_5 })
			{
			}
		}

		internal sealed class kSquUktYZlLofLBCSwuuiHJbgRAhA : jlfxTaYYYmaQGQQaVgCKYatTdmtJ, IControllerTemplateHat, IControllerTemplateElement
		{
			private const int yQXbZsQceNbozeeFJJdAaXqUoPoDb = 0;

			private const int CDqCtdVvQeIysQAPaaudOOjcaqMBA = 1;

			private const int ECuENzJDySMuKCerprKlUYykPYTL = 2;

			private const int BKCiOLxILkzHbEPRaZiixENRfmMd = 3;

			private const int tDTnskKltNQYcOHSExvConmbHsCA = 4;

			private const int VmKaBIMoqOVyMmalaMsgHyTRqzOf = 5;

			private const int XObbMzrFaGhUJhojOGPIULAuFZBq = 6;

			private const int aNGAHVVKYtveiKSNpzamMfzQmzR = 7;

			private const int TQRVywmhdWDAOegrgpwXmzfiaKKn = 8;

			Vector2 IControllerTemplateHat.value
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ;
					result.x += ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ;
					result.y -= ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[4]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ;
					result.x -= ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[6]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ;
					float num = ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ;
					float num2 = ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[3]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ;
					float num3 = ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[5]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ;
					float num4 = ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[7]).DtOHNfRGKZfYmMdBfMdzqWiuubdJ;
					result.x += num + num2 - num3 - num4;
					result.y += num + num4 - num2 - num3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			Vector2 IControllerTemplateHat.valuePrev
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0]).LuWcvwRmPVlobeFRRqMELIJRjxEP;
					result.x += ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2]).LuWcvwRmPVlobeFRRqMELIJRjxEP;
					result.y -= ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[4]).LuWcvwRmPVlobeFRRqMELIJRjxEP;
					result.x -= ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[6]).LuWcvwRmPVlobeFRRqMELIJRjxEP;
					float num = ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1]).LuWcvwRmPVlobeFRRqMELIJRjxEP;
					float num2 = ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[3]).LuWcvwRmPVlobeFRRqMELIJRjxEP;
					float num3 = ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[5]).LuWcvwRmPVlobeFRRqMELIJRjxEP;
					float num4 = ((NyRAZHYHHpcMMrAnpMRemLtHktrd)YkEtPSHWfPCvxQbDONSnyGBtNlKG[7]).LuWcvwRmPVlobeFRRqMELIJRjxEP;
					result.x += num + num2 - num3 - num4;
					result.y += num + num4 - num2 - num3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			IControllerTemplateButton IControllerTemplateHat.up
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upRight
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.right
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[2];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downRight
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[3];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.down
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[4];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downLeft
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[5];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.left
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[6];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upLeft
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateButton)YkEtPSHWfPCvxQbDONSnyGBtNlKG[7];
				}
			}

			private kSquUktYZlLofLBCSwuuiHJbgRAhA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NLKTKONGPKzcMDBBBSopKqtlrhMj[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Hat, P_4, NLKTKONGPKzcMDBBBSopKqtlrhMj.fftLUgIMpbksXKYeQKhiYDWMhlNu(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 8)
				{
					throw new ArgumentException("elements.Length must be " + 8);
				}
			}

			internal kSquUktYZlLofLBCSwuuiHJbgRAhA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NyRAZHYHHpcMMrAnpMRemLtHktrd P_4, NyRAZHYHHpcMMrAnpMRemLtHktrd P_5, NyRAZHYHHpcMMrAnpMRemLtHktrd P_6, NyRAZHYHHpcMMrAnpMRemLtHktrd P_7, NyRAZHYHHpcMMrAnpMRemLtHktrd P_8, NyRAZHYHHpcMMrAnpMRemLtHktrd P_9, NyRAZHYHHpcMMrAnpMRemLtHktrd P_10, NyRAZHYHHpcMMrAnpMRemLtHktrd P_11)
				: this(P_0, P_1, P_2, P_3, new NLKTKONGPKzcMDBBBSopKqtlrhMj[8] { P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11 })
			{
			}
		}

		internal sealed class aXpLwVbOeerfezWYpFuqOwUtTXti : HIIPnMZdwZbyfyCgzexIwmlosSNj, IControllerTemplateYoke, IControllerTemplateElement
		{
			private const int lzyeEateQCSnHFIaAhEzSlclUXbf = 2;

			IControllerTemplateAxis IControllerTemplateYoke.rotation
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateYoke.pushPull
			{
				get
				{
					if (ReInput._id != uzvBoteyxDuGcjhWcCvCryaSjbvOA)
					{
						ReInput.CheckInitialized(uzvBoteyxDuGcjhWcCvCryaSjbvOA);
						return null;
					}
					return (IControllerTemplateAxis)YkEtPSHWfPCvxQbDONSnyGBtNlKG[1];
				}
			}

			private aXpLwVbOeerfezWYpFuqOwUtTXti(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NLKTKONGPKzcMDBBBSopKqtlrhMj[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Yoke, P_4, NLKTKONGPKzcMDBBBSopKqtlrhMj.fftLUgIMpbksXKYeQKhiYDWMhlNu(P_0, P_1, P_2, P_3))
			{
			}

			internal aXpLwVbOeerfezWYpFuqOwUtTXti(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NyRAZHYHHpcMMrAnpMRemLtHktrd P_4, NyRAZHYHHpcMMrAnpMRemLtHktrd P_5)
				: this(P_0, P_1, P_2, P_3, new NLKTKONGPKzcMDBBBSopKqtlrhMj[2] { P_4, P_5 })
			{
			}
		}

		internal sealed class OysZdSZOhNmMscshfcGrSVsFdomq : zQcNitMAIXyCQUadGGhQqQCTIysf, IControllerTemplateStick6D, IControllerTemplateElement
		{
			private const int FBUmqSWknLwYRjmbZGHgJPaFcNKM = 6;

			private OysZdSZOhNmMscshfcGrSVsFdomq(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NLKTKONGPKzcMDBBBSopKqtlrhMj[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Stick6D, P_4, NLKTKONGPKzcMDBBBSopKqtlrhMj.fftLUgIMpbksXKYeQKhiYDWMhlNu(P_0, P_1, P_2, P_3))
			{
			}

			internal OysZdSZOhNmMscshfcGrSVsFdomq(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NyRAZHYHHpcMMrAnpMRemLtHktrd P_4, NyRAZHYHHpcMMrAnpMRemLtHktrd P_5, NyRAZHYHHpcMMrAnpMRemLtHktrd P_6, NyRAZHYHHpcMMrAnpMRemLtHktrd P_7, NyRAZHYHHpcMMrAnpMRemLtHktrd P_8, NyRAZHYHHpcMMrAnpMRemLtHktrd P_9)
				: this(P_0, P_1, P_2, P_3, new NLKTKONGPKzcMDBBBSopKqtlrhMj[6] { P_4, P_5, P_6, P_7, P_8, P_9 })
			{
			}
		}

		internal class crOlyXsngArIbrggzbgTinTdpaRD
		{
			public readonly Controller.Element pPLsaxMkPrEPOHtzjbwFjFnUzFMQ;

			public readonly IControllerElementTarget edubYhDMrNIxwOACnAUzeooXaqZiA;

			public bool altxESjUSoklbmiVvquimgIkhwMX
			{
				get
				{
					if (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ == null)
					{
						return false;
					}
					switch (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ.type)
					{
					case ControllerElementType.Button:
						return (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ as Controller.Button).value;
					case ControllerElementType.Axis:
					{
						float value = (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ as Controller.Axis).value;
						switch (edubYhDMrNIxwOACnAUzeooXaqZiA.axisRange)
						{
						case AxisRange.Full:
							if (value > 0.01f)
							{
								return true;
							}
							if (value < -0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Positive:
							if (value > 0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Negative:
							if (value < -0.01f)
							{
								return true;
							}
							break;
						}
						break;
					}
					}
					return false;
				}
			}

			public bool kNMADZFSKIoITVmzVZcAaTVYupQy
			{
				get
				{
					if (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ == null)
					{
						return false;
					}
					switch (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ.type)
					{
					case ControllerElementType.Button:
						return (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ as Controller.Button).valuePrev;
					case ControllerElementType.Axis:
					{
						float valuePrev = (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ as Controller.Axis).valuePrev;
						switch (edubYhDMrNIxwOACnAUzeooXaqZiA.axisRange)
						{
						case AxisRange.Full:
							if (valuePrev > 0.01f)
							{
								return true;
							}
							if (valuePrev < -0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Positive:
							if (valuePrev > 0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Negative:
							if (valuePrev < -0.01f)
							{
								return true;
							}
							break;
						}
						break;
					}
					}
					return false;
				}
			}

			public bool DujPcWPvxJNReJRxmAazGZLzvCYMA
			{
				get
				{
					if (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ == null)
					{
						return false;
					}
					switch (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ.type)
					{
					case ControllerElementType.Button:
						return (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ as Controller.Button).justPressed;
					case ControllerElementType.Axis:
						if (MathTools.Abs(oZLxrLapzxsOfgVBjBXWciRiQukJ) > 0.01f && MathTools.Abs(OWXXOoSPxDSFRNrSaaJNwjovMWKT) <= 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public bool ycgyvAfdIaKWsNCXfgXQkoAlOIvr
			{
				get
				{
					if (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ == null)
					{
						return false;
					}
					switch (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ.type)
					{
					case ControllerElementType.Button:
						return (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ as Controller.Button).justReleased;
					case ControllerElementType.Axis:
						if (MathTools.Abs(oZLxrLapzxsOfgVBjBXWciRiQukJ) <= 0.01f && MathTools.Abs(OWXXOoSPxDSFRNrSaaJNwjovMWKT) > 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public float oZLxrLapzxsOfgVBjBXWciRiQukJ
			{
				get
				{
					if (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ == null)
					{
						return 0f;
					}
					switch (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ.type)
					{
					case ControllerElementType.Button:
						if (!(pPLsaxMkPrEPOHtzjbwFjFnUzFMQ as Controller.Button).value)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float value = (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ as Controller.Axis).value;
						switch (edubYhDMrNIxwOACnAUzeooXaqZiA.axisRange)
						{
						case AxisRange.Full:
							return value;
						case AxisRange.Positive:
							if (value > 0f)
							{
								return value;
							}
							break;
						case AxisRange.Negative:
							if (value < 0f)
							{
								return value;
							}
							break;
						}
						break;
					}
					}
					return 0f;
				}
			}

			public float OWXXOoSPxDSFRNrSaaJNwjovMWKT
			{
				get
				{
					if (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ == null)
					{
						return 0f;
					}
					switch (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ.type)
					{
					case ControllerElementType.Button:
						if (!(pPLsaxMkPrEPOHtzjbwFjFnUzFMQ as Controller.Button).valuePrev)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float valuePrev = (pPLsaxMkPrEPOHtzjbwFjFnUzFMQ as Controller.Axis).valuePrev;
						switch (edubYhDMrNIxwOACnAUzeooXaqZiA.axisRange)
						{
						case AxisRange.Full:
							return valuePrev;
						case AxisRange.Positive:
							if (valuePrev > 0f)
							{
								return valuePrev;
							}
							break;
						case AxisRange.Negative:
							if (valuePrev < 0f)
							{
								return valuePrev;
							}
							break;
						}
						break;
					}
					}
					return 0f;
				}
			}

			public crOlyXsngArIbrggzbgTinTdpaRD(IControllerElementTarget P_0, Controller.Element P_1)
			{
				pPLsaxMkPrEPOHtzjbwFjFnUzFMQ = P_1;
				edubYhDMrNIxwOACnAUzeooXaqZiA = P_0;
			}

			public static crOlyXsngArIbrggzbgTinTdpaRD XWrSMDXcKOuzGdmBGyRJMDSOmQrc()
			{
				return new crOlyXsngArIbrggzbgTinTdpaRD(QpmNXOwiqgDcvsLLtrkLzeVpLiAW.CxCLqVWbkPcebbGqlizpSUHShkpGb(), null);
			}
		}

		internal class GUKOveDlcFMNwdJUlVOLoRWDnPND
		{
			public readonly Controller EiOPSgQqwsrbJqZKCPgwZZqMXro;

			public readonly IHardwareControllerTemplateMap_Internal bUPcTUdRqjgVugtSQcOdifCIJzrjc;

			public GUKOveDlcFMNwdJUlVOLoRWDnPND(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				EiOPSgQqwsrbJqZKCPgwZZqMXro = P_0;
				bUPcTUdRqjgVugtSQcOdifCIJzrjc = P_1;
			}
		}

		private sealed class tDUNusKnwjJTgUVvFEgBJSRSVvFo
		{
			[Serializable]
			private sealed class xuavONyiAkffdQvledSmormLBCnDA
			{
				public static readonly xuavONyiAkffdQvledSmormLBCnDA _003C_003E9 = new xuavONyiAkffdQvledSmormLBCnDA();

				public static Func<ZtWDGFywnarTKNuYsScniCpUdPO, ZtWDGFywnarTKNuYsScniCpUdPO, bool> _003C_003E9__4_0;

				internal bool RObTDyQFHUNZpvPYmLxCPNoXGjUH(ZtWDGFywnarTKNuYsScniCpUdPO P_0, ZtWDGFywnarTKNuYsScniCpUdPO P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					return P_0.FsaHjueLSoGTYHNWMdIbeIIhKnaQB(P_1, false);
				}
			}

			private static tDUNusKnwjJTgUVvFEgBJSRSVvFo bddNdLbeSIdiZeFmFLsnbutXkrRL;

			private readonly global::NijeqNRuOtTHOXfLLAdncronsTLUA<ZtWDGFywnarTKNuYsScniCpUdPO> mGSaDojddDLxTcmhrPpUEeMiWcGAc;

			private static tDUNusKnwjJTgUVvFEgBJSRSVvFo dszzuLefMqbrOARBkAeEfAXmOAGk
			{
				get
				{
					if (bddNdLbeSIdiZeFmFLsnbutXkrRL != null)
					{
						return bddNdLbeSIdiZeFmFLsnbutXkrRL;
					}
					bddNdLbeSIdiZeFmFLsnbutXkrRL = new tDUNusKnwjJTgUVvFEgBJSRSVvFo();
					bddNdLbeSIdiZeFmFLsnbutXkrRL.EEFEjScHgHnBUAQhjwXVtLWULqaHB();
					return bddNdLbeSIdiZeFmFLsnbutXkrRL;
				}
			}

			private tDUNusKnwjJTgUVvFEgBJSRSVvFo()
			{
				mGSaDojddDLxTcmhrPpUEeMiWcGAc = new global::NijeqNRuOtTHOXfLLAdncronsTLUA<ZtWDGFywnarTKNuYsScniCpUdPO>(xuavONyiAkffdQvledSmormLBCnDA._003C_003E9.RObTDyQFHUNZpvPYmLxCPNoXGjUH);
			}

			private void EEFEjScHgHnBUAQhjwXVtLWULqaHB()
			{
				ReInput.ShutDownEvent += bddNdLbeSIdiZeFmFLsnbutXkrRL.rIQAlgLKDZFWqCHkUeJOOKXHVAAQA;
			}

			private void rIQAlgLKDZFWqCHkUeJOOKXHVAAQA()
			{
				if (bddNdLbeSIdiZeFmFLsnbutXkrRL == this)
				{
					bddNdLbeSIdiZeFmFLsnbutXkrRL = null;
				}
				ReInput.ShutDownEvent -= rIQAlgLKDZFWqCHkUeJOOKXHVAAQA;
			}

			public static ZtWDGFywnarTKNuYsScniCpUdPO RlyxGLyIXWEmRCQOumKTeWwjPakp(ZtWDGFywnarTKNuYsScniCpUdPO P_0)
			{
				Bytes20 bytes = ((P_0.OwidrtApKhdsnydceogfdMzkEpHdA is mLWfXGxSHXhBRKjBmTwzIMZNgintA mLWfXGxSHXhBRKjBmTwzIMZNgintA2) ? mLWfXGxSHXhBRKjBmTwzIMZNgintA2.BJJiWIgvfzbTCwpyIykMBMItFqvv.hash : default(Bytes20));
				return dszzuLefMqbrOARBkAeEfAXmOAGk.mGSaDojddDLxTcmhrPpUEeMiWcGAc.wxUbEGFQBfjePUsdQYoNnyHInQFpA(bytes, P_0);
			}

			public static bool XPmmzRYziiQrxRalWBLGeqMgfvNZA(ZtWDGFywnarTKNuYsScniCpUdPO P_0, out ZtWDGFywnarTKNuYsScniCpUdPO P_1)
			{
				Bytes20 bytes = ((P_0.OwidrtApKhdsnydceogfdMzkEpHdA is mLWfXGxSHXhBRKjBmTwzIMZNgintA mLWfXGxSHXhBRKjBmTwzIMZNgintA2) ? mLWfXGxSHXhBRKjBmTwzIMZNgintA2.BJJiWIgvfzbTCwpyIykMBMItFqvv.hash : default(Bytes20));
				return dszzuLefMqbrOARBkAeEfAXmOAGk.mGSaDojddDLxTcmhrPpUEeMiWcGAc.SYZFKzfaOuaZyGqwgDHDIzPBmdSrA(bytes, P_0, out P_1);
			}

			public static void rkjxEfhQNnMiHQgmowGOWwgCJmy(ZtWDGFywnarTKNuYsScniCpUdPO P_0)
			{
				Bytes20 bytes = ((P_0.OwidrtApKhdsnydceogfdMzkEpHdA is mLWfXGxSHXhBRKjBmTwzIMZNgintA mLWfXGxSHXhBRKjBmTwzIMZNgintA2) ? mLWfXGxSHXhBRKjBmTwzIMZNgintA2.BJJiWIgvfzbTCwpyIykMBMItFqvv.hash : default(Bytes20));
				dszzuLefMqbrOARBkAeEfAXmOAGk.mGSaDojddDLxTcmhrPpUEeMiWcGAc.tsZmAlwqEXvBYjcnUbtXfqwZjrMo(bytes, P_0);
			}
		}

		private const string oQNDgoamEdzROhydnjXHxtxSoJuA = "controller/template";

		private string MEQwjAxAjGhJvFBuNmfvsiucOIAEA;

		private string MavEmcFJaCXDizTUhXQRggyEGxty;

		private int zdTWOSpKIfefgzqtTNmmSJRNNhwy;

		private readonly Guid wneisUgTTFOXJFoHDMRKzhyMTMBA;

		private readonly DeviceLocalizationInfo fdQKbSOLjJdGhSfNlNLNcgmVFvHr;

		private readonly Controller gattQwSpzODGKfkCklpyDrkipfdGA;

		private readonly ADictionary<int, IControllerTemplateElement> YuMXtYLwiTpciKlNuhakWeqMeebf;

		private readonly ADictionary<string, IControllerTemplateElement> rglTeCAtedyYbwTPfGhFoSdBeBAU;

		private IControllerTemplateElement[] uizMdetbNuNDcNZNnspcDVLFTYvN;

		private ReadOnlyCollection<IControllerTemplateElement> UzvBVADWHXRrueeOXIOzodYJnwyKA;

		private readonly oEEgoKqIygbHTIQCNsneyiTKzIXQA GTAIWRmckNzZLocVSfdaZmciEExA;

		private readonly int HDnUssFFWHykuBBoVNTdsnZhbRTc;

		internal DeviceLocalizationInfo TwSmZPWTfwgHtrRfCfBwZLooGtrR => fdQKbSOLjJdGhSfNlNLNcgmVFvHr;

		DeviceLocalizationInfo IControllerTemplate_Internal.deviceLocalizationInfo => fdQKbSOLjJdGhSfNlNLNcgmVFvHr;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != HDnUssFFWHykuBBoVNTdsnZhbRTc)
				{
					ReInput.CheckInitialized(HDnUssFFWHykuBBoVNTdsnZhbRTc);
					return null;
				}
				return gattQwSpzODGKfkCklpyDrkipfdGA;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != HDnUssFFWHykuBBoVNTdsnZhbRTc)
				{
					ReInput.CheckInitialized(HDnUssFFWHykuBBoVNTdsnZhbRTc);
					return null;
				}
				if (!LocalizationManager.isEnabled)
				{
					return MEQwjAxAjGhJvFBuNmfvsiucOIAEA;
				}
				return GTAIWRmckNzZLocVSfdaZmciEExA.YYpaixksduwqUQfFFmPUzWfHjhDu;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != HDnUssFFWHykuBBoVNTdsnZhbRTc)
				{
					ReInput.CheckInitialized(HDnUssFFWHykuBBoVNTdsnZhbRTc);
					return Guid.Empty;
				}
				return wneisUgTTFOXJFoHDMRKzhyMTMBA;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != HDnUssFFWHykuBBoVNTdsnZhbRTc)
				{
					ReInput.CheckInitialized(HDnUssFFWHykuBBoVNTdsnZhbRTc);
					return null;
				}
				return UzvBVADWHXRrueeOXIOzodYJnwyKA;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != HDnUssFFWHykuBBoVNTdsnZhbRTc)
				{
					ReInput.CheckInitialized(HDnUssFFWHykuBBoVNTdsnZhbRTc);
					return 0;
				}
				return uizMdetbNuNDcNZNnspcDVLFTYvN.Length;
			}
		}

		string leeNpeIpkRWAaDYnewmtyKpQcRpw.keyCategory => "controller/template";

		string leeNpeIpkRWAaDYnewmtyKpQcRpw.scriptingName => string.Empty;

		string leeNpeIpkRWAaDYnewmtyKpQcRpw.nonLocalizedDescriptiveName
		{
			get
			{
				return MEQwjAxAjGhJvFBuNmfvsiucOIAEA;
			}
			set
			{
				MEQwjAxAjGhJvFBuNmfvsiucOIAEA = value;
			}
		}

		string leeNpeIpkRWAaDYnewmtyKpQcRpw.key => MavEmcFJaCXDizTUhXQRggyEGxty;

		int leeNpeIpkRWAaDYnewmtyKpQcRpw.autoGeneratedValueFlags
		{
			get
			{
				return zdTWOSpKIfefgzqtTNmmSJRNNhwy;
			}
			set
			{
				zdTWOSpKIfefgzqtTNmmSJRNNhwy = value;
			}
		}

		protected ControllerTemplate(object P_0)
			: this((GUKOveDlcFMNwdJUlVOLoRWDnPND)P_0)
		{
		}

		private ControllerTemplate(GUKOveDlcFMNwdJUlVOLoRWDnPND P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (P_0.EiOPSgQqwsrbJqZKCPgwZZqMXro == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (P_0.bUPcTUdRqjgVugtSQcOdifCIJzrjc == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			HDnUssFFWHykuBBoVNTdsnZhbRTc = ReInput.id;
			gattQwSpzODGKfkCklpyDrkipfdGA = P_0.EiOPSgQqwsrbJqZKCPgwZZqMXro;
			IHardwareControllerTemplateMap_Internal bUPcTUdRqjgVugtSQcOdifCIJzrjc = P_0.bUPcTUdRqjgVugtSQcOdifCIJzrjc;
			MEQwjAxAjGhJvFBuNmfvsiucOIAEA = bUPcTUdRqjgVugtSQcOdifCIJzrjc.name;
			MavEmcFJaCXDizTUhXQRggyEGxty = bUPcTUdRqjgVugtSQcOdifCIJzrjc.typeKey;
			wneisUgTTFOXJFoHDMRKzhyMTMBA = bUPcTUdRqjgVugtSQcOdifCIJzrjc.typeGuid;
			fdQKbSOLjJdGhSfNlNLNcgmVFvHr = new DeviceLocalizationInfo(gattQwSpzODGKfkCklpyDrkipfdGA.type, true, wneisUgTTFOXJFoHDMRKzhyMTMBA, new List<string> { bUPcTUdRqjgVugtSQcOdifCIJzrjc.typeKey }, null);
			fdQKbSOLjJdGhSfNlNLNcgmVFvHr.FinishRuntimeSetup();
			GTAIWRmckNzZLocVSfdaZmciEExA = oEEgoKqIygbHTIQCNsneyiTKzIXQA.CXYVDSKouccTTATbQGDZttKGiskv(this);
			int elementIdentifierCount = bUPcTUdRqjgVugtSQcOdifCIJzrjc.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = bUPcTUdRqjgVugtSQcOdifCIJzrjc.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						vgyLkSessULxWIPilRPgXWnpbfGE vgyLkSessULxWIPilRPgXWnpbfGE3 = bUPcTUdRqjgVugtSQcOdifCIJzrjc.GetAxisTarget(gattQwSpzODGKfkCklpyDrkipfdGA, templateElementIdentifier.id) ?? vgyLkSessULxWIPilRPgXWnpbfGE.apVaRSCStYlLRACQjFZtmwVgcaPhb(ControllerTemplateElementType.Axis);
						aCNOImdowXeuOeDSOlRxmDdKjEeTA item2 = new aCNOImdowXeuOeDSOlRxmDdKjEeTA(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, vgyLkSessULxWIPilRPgXWnpbfGE3, IZKScPFONdwutIBUEcVfaPKgSBgbA(gattQwSpzODGKfkCklpyDrkipfdGA, vgyLkSessULxWIPilRPgXWnpbfGE3));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						vgyLkSessULxWIPilRPgXWnpbfGE vgyLkSessULxWIPilRPgXWnpbfGE2 = bUPcTUdRqjgVugtSQcOdifCIJzrjc.GetButtonTarget(gattQwSpzODGKfkCklpyDrkipfdGA, templateElementIdentifier.id) ?? vgyLkSessULxWIPilRPgXWnpbfGE.apVaRSCStYlLRACQjFZtmwVgcaPhb(ControllerTemplateElementType.Button);
						JidWVpaKPLETXBSGHuHXIwrPNjdtA item = new JidWVpaKPLETXBSGHuHXIwrPNjdtA(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, vgyLkSessULxWIPilRPgXWnpbfGE2, HOOrtebzMgmUwMaclmyWIrhbjtuJ(gattQwSpzODGKfkCklpyDrkipfdGA, vgyLkSessULxWIPilRPgXWnpbfGE2));
						list3.Add(item);
						break;
					}
					default:
						throw new NotImplementedException();
					}
				}
			}
			for (int j = 0; j < list2.Count; j++)
			{
				list.Add(list2[j]);
			}
			for (int k = 0; k < list3.Count; k++)
			{
				list.Add(list3[k]);
			}
			for (int l = 0; l < list.Count; l++)
			{
				aDictionary.Add(list[l].id, list[l]);
			}
			for (int m = 0; m < elementIdentifierCount; m++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier2 = bUPcTUdRqjgVugtSQcOdifCIJzrjc.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = bUPcTUdRqjgVugtSQcOdifCIJzrjc.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				NLKTKONGPKzcMDBBBSopKqtlrhMj nLKTKONGPKzcMDBBBSopKqtlrhMj;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					nLKTKONGPKzcMDBBBSopKqtlrhMj = new mDNJRXwSGSHugEjFhABIMEhRmAaB(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping5 != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping5.eid_axisX) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this), (mapping5 != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping5.eid_axisY) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this), (mapping5 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping5.eid_button) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					nLKTKONGPKzcMDBBBSopKqtlrhMj = new WNmHuKBjAHAoPSKJdfySJEwwUsGd(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping3 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping3.eid_up) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this), (mapping3 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping3.eid_right) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this), (mapping3 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping3.eid_down) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this), (mapping3 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping3.eid_left) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this), (mapping3 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping3.eid_press) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					nLKTKONGPKzcMDBBBSopKqtlrhMj = new fkkfajGazdStCbXGmCxMPjnImxzq(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping2 != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping2.eid_axisX) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this), (mapping2 != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping2.eid_axisY) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this), (mapping2 != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping2.eid_axisZ) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					nLKTKONGPKzcMDBBBSopKqtlrhMj = new DtCoGyWjDHWvawQaLePRdQNmbvqoA(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping6 != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping6.eid_axis) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this), (mapping6 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping6.eid_minDetent) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					nLKTKONGPKzcMDBBBSopKqtlrhMj = new kSquUktYZlLofLBCSwuuiHJbgRAhA(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping7 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping7.eid_up) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this), (mapping7 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping7.eid_upRight) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this), (mapping7 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping7.eid_right) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this), (mapping7 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping7.eid_downRight) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this), (mapping7 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping7.eid_down) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this), (mapping7 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping7.eid_downLeft) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this), (mapping7 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping7.eid_left) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this), (mapping7 != null) ? TFIIblBJRSVnhjIFjHyWsDkgSArk(this, aDictionary, mapping7.eid_upLeft) : JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					nLKTKONGPKzcMDBBBSopKqtlrhMj = new aXpLwVbOeerfezWYpFuqOwUtTXti(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping4 != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping4.eid_axisX) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this), (mapping4 != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping4.eid_axisZ) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					nLKTKONGPKzcMDBBBSopKqtlrhMj = new OysZdSZOhNmMscshfcGrSVsFdomq(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping.eid_positionX) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this), (mapping != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping.eid_positionY) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this), (mapping != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping.eid_positionZ) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this), (mapping != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping.eid_rotationX) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this), (mapping != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping.eid_rotationY) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this), (mapping != null) ? zJmDNBFrxolKxgfRfdwhpuTWUfMcA(this, aDictionary, mapping.eid_rotationZ) : aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (nLKTKONGPKzcMDBBBSopKqtlrhMj != null)
				{
					list4.Add(nLKTKONGPKzcMDBBBSopKqtlrhMj);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			uizMdetbNuNDcNZNnspcDVLFTYvN = list.ToArray();
			YuMXtYLwiTpciKlNuhakWeqMeebf = aDictionary;
			rglTeCAtedyYbwTPfGhFoSdBeBAU = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < uizMdetbNuNDcNZNnspcDVLFTYvN.Length; num++)
			{
				if (!(bUPcTUdRqjgVugtSQcOdifCIJzrjc.GetTemplateElementIdentifierById(uizMdetbNuNDcNZNnspcDVLFTYvN[num].id) is IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor))
				{
					continue;
				}
				for (int num2 = 0; num2 < 2; num2++)
				{
					string text = ((num2 != 0) ? controllerTemplateElementIdentifier_Editor.alternateScriptingName : controllerTemplateElementIdentifier_Editor.scriptingName);
					if (!string.IsNullOrEmpty(text))
					{
						try
						{
							rglTeCAtedyYbwTPfGhFoSdBeBAU.Add(text, uizMdetbNuNDcNZNnspcDVLFTYvN[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + MEQwjAxAjGhJvFBuNmfvsiucOIAEA + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			UzvBVADWHXRrueeOXIOzodYJnwyKA = new ReadOnlyCollection<IControllerTemplateElement>(uizMdetbNuNDcNZNnspcDVLFTYvN);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			if (!YuMXtYLwiTpciKlNuhakWeqMeebf.TryGetValue(id, out var value))
			{
				Logger.LogWarning("There is no element with the id \"" + id + "\" in the " + GetType().ToString() + ".");
			}
			return value;
		}

		protected T GetElement<T>(int id) where T : class, IControllerTemplateElement
		{
			return GetElement(id) as T;
		}

		IControllerTemplateElement IControllerTemplate.GetElement(int id)
		{
			if (ReInput._id != HDnUssFFWHykuBBoVNTdsnZhbRTc)
			{
				ReInput.CheckInitialized(HDnUssFFWHykuBBoVNTdsnZhbRTc);
				return null;
			}
			return GetElement(id);
		}

		T IControllerTemplate.GetElement<T>(int id)
		{
			if (ReInput._id != HDnUssFFWHykuBBoVNTdsnZhbRTc)
			{
				ReInput.CheckInitialized(HDnUssFFWHykuBBoVNTdsnZhbRTc);
				return null;
			}
			return GetElement<T>(id);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget find, IList<ControllerTemplateElementTarget> results)
		{
			if (ReInput._id != HDnUssFFWHykuBBoVNTdsnZhbRTc)
			{
				ReInput.CheckInitialized(HDnUssFFWHykuBBoVNTdsnZhbRTc);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			return GetElementTargets(find, ref results);
		}

		private int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> results)
		{
			if (results != null)
			{
				results.Clear();
			}
			int num = 0;
			for (int i = 0; i < uizMdetbNuNDcNZNnspcDVLFTYvN.Length; i++)
			{
				if (InputTools.IsMappableType(uizMdetbNuNDcNZNnspcDVLFTYvN[i].type))
				{
					num += (uizMdetbNuNDcNZNnspcDVLFTYvN[i] as IControllerTemplateElement_Internal).GetElementTargets(find, ref results);
				}
			}
			return num;
		}

		[CustomObfuscation(rename = false)]
		internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
		{
			return elementType switch
			{
				ControllerTemplateElementType.Axis => typeof(IControllerTemplateAxis), 
				ControllerTemplateElementType.Button => typeof(IControllerTemplateButton), 
				ControllerTemplateElementType.ThumbStick => typeof(IControllerTemplateThumbStick), 
				ControllerTemplateElementType.DPad => typeof(IControllerTemplateDPad), 
				ControllerTemplateElementType.Stick => typeof(IControllerTemplateStick), 
				ControllerTemplateElementType.Throttle => typeof(IControllerTemplateThrottle), 
				ControllerTemplateElementType.Hat => typeof(IControllerTemplateHat), 
				ControllerTemplateElementType.Yoke => typeof(IControllerTemplateYoke), 
				ControllerTemplateElementType.Stick6D => typeof(IControllerTemplateStick6D), 
				_ => throw new NotImplementedException(), 
			};
		}

		private static IList<crOlyXsngArIbrggzbgTinTdpaRD> IZKScPFONdwutIBUEcVfaPKgSBgbA(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			if (P_1.splitAxis)
			{
				IList<crOlyXsngArIbrggzbgTinTdpaRD> list = null;
				bool flag = false;
				if (P_1.positiveTarget != null)
				{
					Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					if (elementById != null)
					{
						ListTools.AddAndCreateList(ref list, new crOlyXsngArIbrggzbgTinTdpaRD(P_1.positiveTarget, elementById));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, crOlyXsngArIbrggzbgTinTdpaRD.XWrSMDXcKOuzGdmBGyRJMDSOmQrc());
				}
				flag = false;
				if (P_1.negativeTarget != null)
				{
					Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
					if (elementById2 != null)
					{
						ListTools.AddAndCreateList(ref list, new crOlyXsngArIbrggzbgTinTdpaRD(P_1.negativeTarget, elementById2));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, crOlyXsngArIbrggzbgTinTdpaRD.XWrSMDXcKOuzGdmBGyRJMDSOmQrc());
				}
				return list;
			}
			return uSpymBejHAPtwKXehfjzdBUvbxTdA(P_0, P_1.fullTarget);
		}

		private static IList<crOlyXsngArIbrggzbgTinTdpaRD> HOOrtebzMgmUwMaclmyWIrhbjtuJ(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return uSpymBejHAPtwKXehfjzdBUvbxTdA(P_0, P_1.target);
		}

		private static IList<crOlyXsngArIbrggzbgTinTdpaRD> uSpymBejHAPtwKXehfjzdBUvbxTdA(Controller P_0, IControllerElementTarget P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			Controller.Element elementById = P_0.GetElementById(P_1.elementIdentifierId);
			if (elementById == null)
			{
				return null;
			}
			return new List<crOlyXsngArIbrggzbgTinTdpaRD>
			{
				new crOlyXsngArIbrggzbgTinTdpaRD(P_1, elementById)
			};
		}

		private static IControllerTemplateElement HYMItmuHcEdqxomRtvwrqkZoTQas(List<IControllerTemplateElement> P_0, int P_1)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i].id == P_1)
				{
					return P_0[i];
				}
			}
			return null;
		}

		private static NyRAZHYHHpcMMrAnpMRemLtHktrd zJmDNBFrxolKxgfRfdwhpuTWUfMcA(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is NyRAZHYHHpcMMrAnpMRemLtHktrd result))
			{
				return aCNOImdowXeuOeDSOlRxmDdKjEeTA.zJsofxLWijpfiznlAeRzCQMDZUtaA(P_0);
			}
			return result;
		}

		private static NyRAZHYHHpcMMrAnpMRemLtHktrd TFIIblBJRSVnhjIFjHyWsDkgSArk(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is NyRAZHYHHpcMMrAnpMRemLtHktrd result))
			{
				return JidWVpaKPLETXBSGHuHXIwrPNjdtA.CZSnJBbqLMRyBbudHFaWdHYzBJEi(P_0);
			}
			return result;
		}
	}
}
