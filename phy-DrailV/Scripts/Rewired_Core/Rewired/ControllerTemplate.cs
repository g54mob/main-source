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
	public abstract class ControllerTemplate : IControllerTemplate, IControllerTemplate_Internal, jtAeQMwqfCHdCmeHvhaRCqwDmBxb
	{
		internal abstract class VfJsWclfGaSaLuJACCTmezagGAyS : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate WEvCOBjpQhIRpHaUkrxNLGKtAKdt;

			private readonly int kqvbpTxWGdGtrNRdxLepeZkwTJDn;

			private readonly ControllerTemplateElementType pAOXgcmMCoVFqTMkLWvqHBZrtkmI;

			protected readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

			protected readonly XXqMAmtzgVleMjCfPcHhdJZaHOvVA kUUhoFhlYUDjQHQOSiMUEnlfLzqr;

			public int id
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return -1;
					}
					return kqvbpTxWGdGtrNRdxLepeZkwTJDn;
				}
			}

			public string descriptiveName
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return kUUhoFhlYUDjQHQOSiMUEnlfLzqr.jXwgbYbEpdqHGeBdCbXEcskUaWaFA;
				}
			}

			internal string BiJSyFBqfBFCPEEkvmkuKZWUhqE => kUUhoFhlYUDjQHQOSiMUEnlfLzqr.nonLocalizedDescriptiveName;

			public ControllerTemplateElementType type
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return ControllerTemplateElementType.Axis;
					}
					return pAOXgcmMCoVFqTMkLWvqHBZrtkmI;
				}
			}

			public IControllerTemplate parent => WEvCOBjpQhIRpHaUkrxNLGKtAKdt;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected VfJsWclfGaSaLuJACCTmezagGAyS(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, XXqMAmtzgVleMjCfPcHhdJZaHOvVA P_3)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_3 == null)
				{
					throw new ArgumentNullException("localizedElement");
				}
				WEvCOBjpQhIRpHaUkrxNLGKtAKdt = P_0;
				kqvbpTxWGdGtrNRdxLepeZkwTJDn = P_1;
				pAOXgcmMCoVFqTMkLWvqHBZrtkmI = P_2;
				oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
				kUUhoFhlYUDjQHQOSiMUEnlfLzqr = P_3;
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);

			protected static XXqMAmtzgVleMjCfPcHhdJZaHOvVA vYvkwFszGegnqYFbNEypdKsFIKehA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3)
			{
				return bHDzGKkkNLEvehmAszODxSDjIxkA.RGGJWIgQTGFjrbkplAhDgRPBiCkT(new XXqMAmtzgVleMjCfPcHhdJZaHOvVA(zThmZsXZeruxkumuYEJcoIWmaInk.VxSNvmooWfTkIVcICGUZnqoUJPDW(urAVZRefROHDbvendscKLBZHGrdo.ControllerTemplate, JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Unknown, JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3));
			}
		}

		internal abstract class ZICgpvJblFHIXNZGBgtwnYZNgqnlA : VfJsWclfGaSaLuJACCTmezagGAyS
		{
			protected readonly int IxAsCJypShDdtgctmYTqecGfACngA;

			protected readonly eyDQiGABtoXqHGRtmucOUpyqgWzdA[] GoNFWsXnFDufNXkeweJaJkrvNJmE;

			bool VfJsWclfGaSaLuJACCTmezagGAyS.exists
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (GoNFWsXnFDufNXkeweJaJkrvNJmE == null)
					{
						return false;
					}
					for (int i = 0; i < GoNFWsXnFDufNXkeweJaJkrvNJmE.Length; i++)
					{
						if (GoNFWsXnFDufNXkeweJaJkrvNJmE[i].ooBBgkcWWsMagjYtYbeirjkcGey != null)
						{
							return true;
						}
					}
					return false;
				}
			}

			protected ZICgpvJblFHIXNZGBgtwnYZNgqnlA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, IList<eyDQiGABtoXqHGRtmucOUpyqgWzdA> P_3, XXqMAmtzgVleMjCfPcHhdJZaHOvVA P_4)
				: base(P_0, P_1, P_2, P_4)
			{
				GoNFWsXnFDufNXkeweJaJkrvNJmE = ((P_3 != null) ? ListTools.ToArray(P_3) : null);
				IxAsCJypShDdtgctmYTqecGfACngA = ((GoNFWsXnFDufNXkeweJaJkrvNJmE != null) ? GoNFWsXnFDufNXkeweJaJkrvNJmE.Length : 0);
			}
		}

		internal abstract class NKUIDloiFZwrHYSBiTNlEnKGDXJR : ZICgpvJblFHIXNZGBgtwnYZNgqnlA, IControllerTemplateElement, IControllerTemplateButton, IControllerTemplateAxis
		{
			private fMlgSaItucfCTlOMuaOrAzViaQaCA mVGfEDJkBUWwIPTCEuHOmMoilJMqA;

			public float NlgGoNcTUgcDNoMxANdsnzcJhVDT
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					if (IxAsCJypShDdtgctmYTqecGfACngA == 1)
					{
						return GoNFWsXnFDufNXkeweJaJkrvNJmE[0].NlgGoNcTUgcDNoMxANdsnzcJhVDT;
					}
					if (IxAsCJypShDdtgctmYTqecGfACngA == 2)
					{
						float num = GoNFWsXnFDufNXkeweJaJkrvNJmE[0].NlgGoNcTUgcDNoMxANdsnzcJhVDT;
						float num2 = GoNFWsXnFDufNXkeweJaJkrvNJmE[1].NlgGoNcTUgcDNoMxANdsnzcJhVDT;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public float TvWwOEewzrIcVGvAEteJVoCjIdIP
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					if (IxAsCJypShDdtgctmYTqecGfACngA == 1)
					{
						return GoNFWsXnFDufNXkeweJaJkrvNJmE[0].TvWwOEewzrIcVGvAEteJVoCjIdIP;
					}
					if (IxAsCJypShDdtgctmYTqecGfACngA == 2)
					{
						float num = GoNFWsXnFDufNXkeweJaJkrvNJmE[0].TvWwOEewzrIcVGvAEteJVoCjIdIP;
						float num2 = GoNFWsXnFDufNXkeweJaJkrvNJmE[1].TvWwOEewzrIcVGvAEteJVoCjIdIP;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool PgYBwtVmbzeQthtCjcmnjFTgEEyYb
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (IxAsCJypShDdtgctmYTqecGfACngA == 1)
					{
						return GoNFWsXnFDufNXkeweJaJkrvNJmE[0].PgYBwtVmbzeQthtCjcmnjFTgEEyYb;
					}
					if (IxAsCJypShDdtgctmYTqecGfACngA == 2)
					{
						if (!GoNFWsXnFDufNXkeweJaJkrvNJmE[0].PgYBwtVmbzeQthtCjcmnjFTgEEyYb)
						{
							return GoNFWsXnFDufNXkeweJaJkrvNJmE[1].PgYBwtVmbzeQthtCjcmnjFTgEEyYb;
						}
						return true;
					}
					return false;
				}
			}

			public bool HgqVejMPHsrEyhwdKaFeszHtJXqQ
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (IxAsCJypShDdtgctmYTqecGfACngA == 1)
					{
						return GoNFWsXnFDufNXkeweJaJkrvNJmE[0].HgqVejMPHsrEyhwdKaFeszHtJXqQ;
					}
					if (IxAsCJypShDdtgctmYTqecGfACngA == 2)
					{
						if (!GoNFWsXnFDufNXkeweJaJkrvNJmE[0].HgqVejMPHsrEyhwdKaFeszHtJXqQ)
						{
							return GoNFWsXnFDufNXkeweJaJkrvNJmE[1].HgqVejMPHsrEyhwdKaFeszHtJXqQ;
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return jkzIDcVqTGWBQoXEdSPcuHoUWgHM.nkieIDGTvoQOzfhnwqrRbpIBgcrw;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return jkzIDcVqTGWBQoXEdSPcuHoUWgHM.CWdJorNsJxtHBeABWaFvcIChQSiaA;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					return NlgGoNcTUgcDNoMxANdsnzcJhVDT;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					return TvWwOEewzrIcVGvAEteJVoCjIdIP;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return mVGfEDJkBUWwIPTCEuHOmMoilJMqA;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return PgYBwtVmbzeQthtCjcmnjFTgEEyYb;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return HgqVejMPHsrEyhwdKaFeszHtJXqQ;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (IxAsCJypShDdtgctmYTqecGfACngA == 1)
					{
						return GoNFWsXnFDufNXkeweJaJkrvNJmE[0].DaDKnRGgOMjNvbIxxlTQfhqTYBWu;
					}
					if (IxAsCJypShDdtgctmYTqecGfACngA == 2)
					{
						if (!GoNFWsXnFDufNXkeweJaJkrvNJmE[0].DaDKnRGgOMjNvbIxxlTQfhqTYBWu || GoNFWsXnFDufNXkeweJaJkrvNJmE[1].HgqVejMPHsrEyhwdKaFeszHtJXqQ)
						{
							if (GoNFWsXnFDufNXkeweJaJkrvNJmE[1].DaDKnRGgOMjNvbIxxlTQfhqTYBWu)
							{
								return !GoNFWsXnFDufNXkeweJaJkrvNJmE[0].HgqVejMPHsrEyhwdKaFeszHtJXqQ;
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (IxAsCJypShDdtgctmYTqecGfACngA == 1)
					{
						return GoNFWsXnFDufNXkeweJaJkrvNJmE[0].CVtlCkydoxhirdTrieslqaaJclYmA;
					}
					if (IxAsCJypShDdtgctmYTqecGfACngA == 2)
					{
						if (!GoNFWsXnFDufNXkeweJaJkrvNJmE[0].CVtlCkydoxhirdTrieslqaaJclYmA || GoNFWsXnFDufNXkeweJaJkrvNJmE[1].PgYBwtVmbzeQthtCjcmnjFTgEEyYb)
						{
							if (GoNFWsXnFDufNXkeweJaJkrvNJmE[1].CVtlCkydoxhirdTrieslqaaJclYmA)
							{
								return !GoNFWsXnFDufNXkeweJaJkrvNJmE[0].PgYBwtVmbzeQthtCjcmnjFTgEEyYb;
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return PgYBwtVmbzeQthtCjcmnjFTgEEyYb != HgqVejMPHsrEyhwdKaFeszHtJXqQ;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					return NlgGoNcTUgcDNoMxANdsnzcJhVDT;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					return TvWwOEewzrIcVGvAEteJVoCjIdIP;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return mVGfEDJkBUWwIPTCEuHOmMoilJMqA;
				}
			}

			public override IControllerTemplateElementSource source
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return mVGfEDJkBUWwIPTCEuHOmMoilJMqA;
				}
			}

			public override int elementCount => 0;

			public IControllerTemplateAxis AsAxis
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return this;
				}
			}

			public IControllerTemplateButton AsButton
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return this;
				}
			}

			protected RpCYpWXnZuvIPZTIQSuIeoMOuCEE jkzIDcVqTGWBQoXEdSPcuHoUWgHM => (RpCYpWXnZuvIPZTIQSuIeoMOuCEE)kUUhoFhlYUDjQHQOSiMUEnlfLzqr;

			protected NKUIDloiFZwrHYSBiTNlEnKGDXJR(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, fMlgSaItucfCTlOMuaOrAzViaQaCA P_3, IList<eyDQiGABtoXqHGRtmucOUpyqgWzdA> P_4, RpCYpWXnZuvIPZTIQSuIeoMOuCEE P_5)
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
				mVGfEDJkBUWwIPTCEuHOmMoilJMqA = P_3;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange axisRange)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				switch (axisRange)
				{
				case AxisRange.Full:
					return base.descriptiveName;
				case AxisRange.Positive:
					return ((IControllerTemplateAxis)this).positiveDescriptiveName;
				case AxisRange.Negative:
					return ((IControllerTemplateAxis)this).negativeDescriptiveName;
				default:
					throw new NotImplementedException();
				}
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
				switch (base.type)
				{
				case ControllerTemplateElementType.Axis:
				{
					IControllerTemplateAxisSource controllerTemplateAxisSource = mVGfEDJkBUWwIPTCEuHOmMoilJMqA;
					if (controllerTemplateAxisSource.splitAxis)
					{
						if (ftdJATbrZERzARkPIhJtjpKGcKdb(find, controllerTemplateAxisSource.positiveTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
							num++;
						}
						if (ftdJATbrZERzARkPIhJtjpKGcKdb(find, controllerTemplateAxisSource.negativeTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
							num++;
						}
					}
					else if (ftdJATbrZERzARkPIhJtjpKGcKdb(find, controllerTemplateAxisSource.fullTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
						num++;
					}
					break;
				}
				case ControllerTemplateElementType.Button:
					if (ftdJATbrZERzARkPIhJtjpKGcKdb(find, ((IControllerTemplateButtonSource)mVGfEDJkBUWwIPTCEuHOmMoilJMqA).target))
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

			private static bool ftdJATbrZERzARkPIhJtjpKGcKdb(ControllerElementTarget P_0, IControllerElementTarget P_1)
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

		internal sealed class eMxFQFHytkjFfuXbRGkGxcKZrMzB : NKUIDloiFZwrHYSBiTNlEnKGDXJR
		{
			public eMxFQFHytkjFfuXbRGkGxcKZrMzB(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, fMlgSaItucfCTlOMuaOrAzViaQaCA P_8, IList<eyDQiGABtoXqHGRtmucOUpyqgWzdA> P_9)
				: base(P_0, P_1, ControllerTemplateElementType.Axis, P_8, P_9, (RpCYpWXnZuvIPZTIQSuIeoMOuCEE)bHDzGKkkNLEvehmAszODxSDjIxkA.RGGJWIgQTGFjrbkplAhDgRPBiCkT(new RpCYpWXnZuvIPZTIQSuIeoMOuCEE(jEybDfZnTXMckOeqmWAqoWQFlwGi.VxSNvmooWfTkIVcICGUZnqoUJPDW(urAVZRefROHDbvendscKLBZHGrdo.ControllerTemplate, JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Axis, JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
			{
				if (P_9 != null && P_9.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static eMxFQFHytkjFfuXbRGkGxcKZrMzB ZthtDKCPytXmopXrdcSWOpqCJOGs(IControllerTemplate_Internal P_0)
			{
				return new eMxFQFHytkjFfuXbRGkGxcKZrMzB(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, fMlgSaItucfCTlOMuaOrAzViaQaCA.ZthtDKCPytXmopXrdcSWOpqCJOGs(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class JCmGMXGYJdSmKrXBYCvOEUsGUGXH : NKUIDloiFZwrHYSBiTNlEnKGDXJR
		{
			public JCmGMXGYJdSmKrXBYCvOEUsGUGXH(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, fMlgSaItucfCTlOMuaOrAzViaQaCA P_8, IList<eyDQiGABtoXqHGRtmucOUpyqgWzdA> P_9)
				: base(P_0, P_1, ControllerTemplateElementType.Button, P_8, P_9, (RpCYpWXnZuvIPZTIQSuIeoMOuCEE)bHDzGKkkNLEvehmAszODxSDjIxkA.RGGJWIgQTGFjrbkplAhDgRPBiCkT(new RpCYpWXnZuvIPZTIQSuIeoMOuCEE(jEybDfZnTXMckOeqmWAqoWQFlwGi.VxSNvmooWfTkIVcICGUZnqoUJPDW(urAVZRefROHDbvendscKLBZHGrdo.ControllerTemplate, JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Button, JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
			{
				if (P_9 != null && P_9.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static JCmGMXGYJdSmKrXBYCvOEUsGUGXH ZthtDKCPytXmopXrdcSWOpqCJOGs(IControllerTemplate_Internal P_0)
			{
				return new JCmGMXGYJdSmKrXBYCvOEUsGUGXH(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, fMlgSaItucfCTlOMuaOrAzViaQaCA.ZthtDKCPytXmopXrdcSWOpqCJOGs(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class dxkfyCoUQIIvPdfTMMlVuPsUUGPx : VfJsWclfGaSaLuJACCTmezagGAyS
		{
			protected readonly int ZOCgxXUKNFOfHISNXZmxfalgnLaA;

			protected readonly VfJsWclfGaSaLuJACCTmezagGAyS[] JlCnxdjSAFgokjnBJvAQVZXHNacj;

			bool VfJsWclfGaSaLuJACCTmezagGAyS.exists
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					for (int i = 0; i < ZOCgxXUKNFOfHISNXZmxfalgnLaA; i++)
					{
						if (JlCnxdjSAFgokjnBJvAQVZXHNacj[i].exists)
						{
							return true;
						}
					}
					return false;
				}
			}

			IControllerTemplateElementSource VfJsWclfGaSaLuJACCTmezagGAyS.source
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return null;
				}
			}

			int VfJsWclfGaSaLuJACCTmezagGAyS.elementCount => ZOCgxXUKNFOfHISNXZmxfalgnLaA;

			protected dxkfyCoUQIIvPdfTMMlVuPsUUGPx(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, VfJsWclfGaSaLuJACCTmezagGAyS[] P_3, XXqMAmtzgVleMjCfPcHhdJZaHOvVA P_4)
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
				JlCnxdjSAFgokjnBJvAQVZXHNacj = P_3;
				ZOCgxXUKNFOfHISNXZmxfalgnLaA = P_3.Length;
			}

			public virtual IControllerTemplateElement TIxnSRhPSalQFvQOFZaLLiQtwMIC(int P_0)
			{
				return JlCnxdjSAFgokjnBJvAQVZXHNacj[P_0];
			}

			public virtual int HkdJtEdybqsPgblChpBjubhxAIBF(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				for (int i = 0; i < JlCnxdjSAFgokjnBJvAQVZXHNacj.Length; i++)
				{
					num += JlCnxdjSAFgokjnBJvAQVZXHNacj[i].GetElementTargets(P_0, ref P_1);
				}
				return num;
			}
		}

		internal abstract class XbHjKerLgfdsmZwrmwvXEeexbXpfA : dxkfyCoUQIIvPdfTMMlVuPsUUGPx, IControllerTemplateElement, IControllerTemplateAxis2D
		{
			protected const int lLdYwleixlZVwdhaUzybKBxSNcFB = 0;

			protected const int ANilMJhOgOSAURSmDQcOgJTeCgOQ = 1;

			protected const int hNXBRVFSCiNmWwcNDBTnrAivOzzi = 2;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector2.zero;
					}
					return new Vector2((ZOCgxXUKNFOfHISNXZmxfalgnLaA > 0) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[0]).NlgGoNcTUgcDNoMxANdsnzcJhVDT : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 1) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[1]).NlgGoNcTUgcDNoMxANdsnzcJhVDT : 0f);
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector2.zero;
					}
					return new Vector2((ZOCgxXUKNFOfHISNXZmxfalgnLaA > 0) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[0]).TvWwOEewzrIcVGvAEteJVoCjIdIP : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 1) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[1]).TvWwOEewzrIcVGvAEteJVoCjIdIP : 0f);
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[1];
				}
			}

			protected XbHjKerLgfdsmZwrmwvXEeexbXpfA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, VfJsWclfGaSaLuJACCTmezagGAyS[] P_3, XXqMAmtzgVleMjCfPcHhdJZaHOvVA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class FrHFbVRPoTzzFmuJocwyCQrqeBMC : dxkfyCoUQIIvPdfTMMlVuPsUUGPx, IControllerTemplateElement, IControllerTemplateAxis3D
		{
			protected const int lLdYwleixlZVwdhaUzybKBxSNcFB = 0;

			protected const int ANilMJhOgOSAURSmDQcOgJTeCgOQ = 1;

			protected const int SZZtbdRDCrFYtQSrOOjBqNmzPgCY = 2;

			protected const int hNXBRVFSCiNmWwcNDBTnrAivOzzi = 3;

			public Vector3 value
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector3.zero;
					}
					return new Vector3((ZOCgxXUKNFOfHISNXZmxfalgnLaA > 0) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[0]).NlgGoNcTUgcDNoMxANdsnzcJhVDT : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 1) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[1]).NlgGoNcTUgcDNoMxANdsnzcJhVDT : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 2) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[2]).NlgGoNcTUgcDNoMxANdsnzcJhVDT : 0f);
				}
			}

			public Vector3 valuePrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector3.zero;
					}
					return new Vector3((ZOCgxXUKNFOfHISNXZmxfalgnLaA > 0) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[0]).TvWwOEewzrIcVGvAEteJVoCjIdIP : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 1) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[1]).TvWwOEewzrIcVGvAEteJVoCjIdIP : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 2) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[2]).TvWwOEewzrIcVGvAEteJVoCjIdIP : 0f);
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[1];
				}
			}

			public IControllerTemplateAxis depth
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[2];
				}
			}

			protected FrHFbVRPoTzzFmuJocwyCQrqeBMC(IControllerTemplate_Internal P_0, int P_1, ControllerTemplateElementType P_2, VfJsWclfGaSaLuJACCTmezagGAyS[] P_3, XXqMAmtzgVleMjCfPcHhdJZaHOvVA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class dRhpEXynSxqdDpmwHPLLYyRMhzIn : dxkfyCoUQIIvPdfTMMlVuPsUUGPx, IControllerTemplateElement, IControllerTemplateAxis6D
		{
			protected const int RENgdJsXgMGtJcXEtkUmBXPjPLWJA = 0;

			protected const int GwEQhTBIBuUYckcYVoiVQnqKAREw = 1;

			protected const int baqdvZVUAdIIwgBZNMwzNCLZLscCb = 2;

			protected const int MnkagibKQAQaYPyqCwBuAGsRaCYiA = 3;

			protected const int vPBHBuqZGtctxfWwGbMQwQHKgUPR = 4;

			protected const int heeSPPDLeZtfXYTqCSdEsvLLYOAc = 5;

			protected const int hNXBRVFSCiNmWwcNDBTnrAivOzzi = 6;

			public Vector3 position
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector3.zero;
					}
					return new Vector3((ZOCgxXUKNFOfHISNXZmxfalgnLaA > 0) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[0]).NlgGoNcTUgcDNoMxANdsnzcJhVDT : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 1) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[1]).NlgGoNcTUgcDNoMxANdsnzcJhVDT : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 2) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[2]).NlgGoNcTUgcDNoMxANdsnzcJhVDT : 0f);
				}
			}

			public Vector3 positionPrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector3.zero;
					}
					return new Vector3((ZOCgxXUKNFOfHISNXZmxfalgnLaA > 0) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[0]).TvWwOEewzrIcVGvAEteJVoCjIdIP : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 1) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[1]).TvWwOEewzrIcVGvAEteJVoCjIdIP : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 2) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[2]).TvWwOEewzrIcVGvAEteJVoCjIdIP : 0f);
				}
			}

			public Vector3 rotation
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector3.zero;
					}
					return new Vector3((ZOCgxXUKNFOfHISNXZmxfalgnLaA > 3) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[3]).NlgGoNcTUgcDNoMxANdsnzcJhVDT : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 4) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[4]).NlgGoNcTUgcDNoMxANdsnzcJhVDT : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 5) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[5]).NlgGoNcTUgcDNoMxANdsnzcJhVDT : 0f);
				}
			}

			public Vector3 rotationPrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector3.zero;
					}
					return new Vector3((ZOCgxXUKNFOfHISNXZmxfalgnLaA > 3) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[3]).TvWwOEewzrIcVGvAEteJVoCjIdIP : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 4) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[4]).TvWwOEewzrIcVGvAEteJVoCjIdIP : 0f, (ZOCgxXUKNFOfHISNXZmxfalgnLaA > 5) ? ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[5]).TvWwOEewzrIcVGvAEteJVoCjIdIP : 0f);
				}
			}

			public IControllerTemplateAxis positionX
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[0];
				}
			}

			public IControllerTemplateAxis positionY
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[1];
				}
			}

			public IControllerTemplateAxis positionZ
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[2];
				}
			}

			public IControllerTemplateAxis rotationX
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[3];
				}
			}

			public IControllerTemplateAxis rotationY
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[4];
				}
			}

			public IControllerTemplateAxis rotationZ
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[5];
				}
			}

			protected dRhpEXynSxqdDpmwHPLLYyRMhzIn(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, VfJsWclfGaSaLuJACCTmezagGAyS[] P_3, XXqMAmtzgVleMjCfPcHhdJZaHOvVA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal sealed class jLdlgHmarVukPYbJraeHndaTvAFV : FrHFbVRPoTzzFmuJocwyCQrqeBMC, IControllerTemplateElement, IControllerTemplateStick
		{
			private new const int hNXBRVFSCiNmWwcNDBTnrAivOzzi = 3;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[2];
				}
			}

			private jLdlgHmarVukPYbJraeHndaTvAFV(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VfJsWclfGaSaLuJACCTmezagGAyS[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Stick, P_4, VfJsWclfGaSaLuJACCTmezagGAyS.vYvkwFszGegnqYFbNEypdKsFIKehA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			public jLdlgHmarVukPYbJraeHndaTvAFV(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_4, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_5, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_6)
				: this(P_0, P_1, P_2, P_3, new VfJsWclfGaSaLuJACCTmezagGAyS[3] { P_4, P_5, P_6 })
			{
			}
		}

		internal sealed class urCnOrOxOivUddMsYNBKmaLCsBeV : XbHjKerLgfdsmZwrmwvXEeexbXpfA, IControllerTemplateElement, IControllerTemplateThumbStick
		{
			private const int dpUgmazoaRFntNMLeMmEmLhCzNuM = 2;

			private new const int hNXBRVFSCiNmWwcNDBTnrAivOzzi = 3;

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[2];
				}
			}

			private urCnOrOxOivUddMsYNBKmaLCsBeV(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VfJsWclfGaSaLuJACCTmezagGAyS[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.ThumbStick, P_4, VfJsWclfGaSaLuJACCTmezagGAyS.vYvkwFszGegnqYFbNEypdKsFIKehA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal urCnOrOxOivUddMsYNBKmaLCsBeV(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_4, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_5, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_6)
				: this(P_0, P_1, P_2, P_3, new VfJsWclfGaSaLuJACCTmezagGAyS[3] { P_4, P_5, P_6 })
			{
			}
		}

		internal sealed class WahiOsxHbbKXGpBRynkLrIJvoxiu : dxkfyCoUQIIvPdfTMMlVuPsUUGPx, IControllerTemplateElement, IControllerTemplateDPad
		{
			private const int bOOXutUUGDRpdCKXaRvqTLCEyzSL = 0;

			private const int aXCHPnwAseAKfMTsEovyQiWenqpn = 1;

			private const int CKQljNQadjvWeAEHEdfakBtZOyAz = 2;

			private const int iieaniIPazuDyAOFKcPWQpuVjPwkA = 3;

			private const int KvDdBjeVEdOuyvIsTNujDWaRUBeNA = 4;

			private const int hNXBRVFSCiNmWwcNDBTnrAivOzzi = 5;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[0]).NlgGoNcTUgcDNoMxANdsnzcJhVDT + ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[2]).NlgGoNcTUgcDNoMxANdsnzcJhVDT * -1f, -1f, 1f), MathTools.Clamp(((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[3]).NlgGoNcTUgcDNoMxANdsnzcJhVDT * -1f + ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[1]).NlgGoNcTUgcDNoMxANdsnzcJhVDT, -1f, 1f));
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[0]).TvWwOEewzrIcVGvAEteJVoCjIdIP + ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[2]).TvWwOEewzrIcVGvAEteJVoCjIdIP * -1f, -1f, 1f), MathTools.Clamp(((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[3]).TvWwOEewzrIcVGvAEteJVoCjIdIP * -1f + ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[1]).TvWwOEewzrIcVGvAEteJVoCjIdIP, -1f, 1f));
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[0];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[1];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[2];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[3];
				}
			}

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[4];
				}
			}

			private WahiOsxHbbKXGpBRynkLrIJvoxiu(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VfJsWclfGaSaLuJACCTmezagGAyS[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.DPad, P_4, VfJsWclfGaSaLuJACCTmezagGAyS.vYvkwFszGegnqYFbNEypdKsFIKehA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal WahiOsxHbbKXGpBRynkLrIJvoxiu(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_4, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_5, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_6, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_7, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_8)
				: this(P_0, P_1, P_2, P_3, new VfJsWclfGaSaLuJACCTmezagGAyS[5] { P_4, P_5, P_6, P_7, P_8 })
			{
			}
		}

		internal sealed class VsPPdAkXqpidpNdIQCTMmYkpKfIC : dxkfyCoUQIIvPdfTMMlVuPsUUGPx, IControllerTemplateElement, IControllerTemplateThrottle
		{
			private const int KtqTLoaAyzGgkvkCyPaAHIrgUoop = 0;

			private const int LhLGktqEVpBDOFBIWCxHsVwpsTwjA = 1;

			private const int hNXBRVFSCiNmWwcNDBTnrAivOzzi = 2;

			public float value
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					return ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[0]).NlgGoNcTUgcDNoMxANdsnzcJhVDT;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					return ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[0]).TvWwOEewzrIcVGvAEteJVoCjIdIP;
				}
			}

			public IControllerTemplateAxis throttle
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[0];
				}
			}

			public IControllerTemplateButton minDetent
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[1];
				}
			}

			private VsPPdAkXqpidpNdIQCTMmYkpKfIC(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VfJsWclfGaSaLuJACCTmezagGAyS[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Throttle, P_4, VfJsWclfGaSaLuJACCTmezagGAyS.vYvkwFszGegnqYFbNEypdKsFIKehA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 2)
				{
					throw new ArgumentException("elements.Length must be " + 2);
				}
			}

			internal VsPPdAkXqpidpNdIQCTMmYkpKfIC(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_4, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_5)
				: this(P_0, P_1, P_2, P_3, new VfJsWclfGaSaLuJACCTmezagGAyS[2] { P_4, P_5 })
			{
			}
		}

		internal sealed class yZhZOITzHNbsoeJJZnZjKSGksVkf : dxkfyCoUQIIvPdfTMMlVuPsUUGPx, IControllerTemplateElement, IControllerTemplateHat
		{
			private const int bOOXutUUGDRpdCKXaRvqTLCEyzSL = 0;

			private const int JhoQLEOVSbZKOATrkGAaveQMvjJG = 1;

			private const int aXCHPnwAseAKfMTsEovyQiWenqpn = 2;

			private const int aQoCypiJgbzVVJdFPmfHCVDgzTCsA = 3;

			private const int CKQljNQadjvWeAEHEdfakBtZOyAz = 4;

			private const int onmnJbRAVBORNPAEGFcDJkepfnABA = 5;

			private const int iieaniIPazuDyAOFKcPWQpuVjPwkA = 6;

			private const int HJRuLRNjdQFuIgmlACdfbEbZFQYab = 7;

			private const int hNXBRVFSCiNmWwcNDBTnrAivOzzi = 8;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[0]).NlgGoNcTUgcDNoMxANdsnzcJhVDT;
					result.x += ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[2]).NlgGoNcTUgcDNoMxANdsnzcJhVDT;
					result.y -= ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[4]).NlgGoNcTUgcDNoMxANdsnzcJhVDT;
					result.x -= ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[6]).NlgGoNcTUgcDNoMxANdsnzcJhVDT;
					float num = ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[1]).NlgGoNcTUgcDNoMxANdsnzcJhVDT;
					float num2 = ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[3]).NlgGoNcTUgcDNoMxANdsnzcJhVDT;
					float num3 = ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[5]).NlgGoNcTUgcDNoMxANdsnzcJhVDT;
					float num4 = ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[7]).NlgGoNcTUgcDNoMxANdsnzcJhVDT;
					result.x += num + num2 - num3 - num4;
					result.y += num + num4 - num2 - num3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[0]).TvWwOEewzrIcVGvAEteJVoCjIdIP;
					result.x += ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[2]).TvWwOEewzrIcVGvAEteJVoCjIdIP;
					result.y -= ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[4]).TvWwOEewzrIcVGvAEteJVoCjIdIP;
					result.x -= ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[6]).TvWwOEewzrIcVGvAEteJVoCjIdIP;
					float num = ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[1]).TvWwOEewzrIcVGvAEteJVoCjIdIP;
					float num2 = ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[3]).TvWwOEewzrIcVGvAEteJVoCjIdIP;
					float num3 = ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[5]).TvWwOEewzrIcVGvAEteJVoCjIdIP;
					float num4 = ((NKUIDloiFZwrHYSBiTNlEnKGDXJR)JlCnxdjSAFgokjnBJvAQVZXHNacj[7]).TvWwOEewzrIcVGvAEteJVoCjIdIP;
					result.x += num + num2 - num3 - num4;
					result.y += num + num4 - num2 - num3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[0];
				}
			}

			public IControllerTemplateButton upRight
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[1];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[2];
				}
			}

			public IControllerTemplateButton downRight
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[3];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[4];
				}
			}

			public IControllerTemplateButton downLeft
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[5];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[6];
				}
			}

			public IControllerTemplateButton upLeft
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateButton)JlCnxdjSAFgokjnBJvAQVZXHNacj[7];
				}
			}

			private yZhZOITzHNbsoeJJZnZjKSGksVkf(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VfJsWclfGaSaLuJACCTmezagGAyS[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Hat, P_4, VfJsWclfGaSaLuJACCTmezagGAyS.vYvkwFszGegnqYFbNEypdKsFIKehA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 8)
				{
					throw new ArgumentException("elements.Length must be " + 8);
				}
			}

			internal yZhZOITzHNbsoeJJZnZjKSGksVkf(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_4, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_5, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_6, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_7, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_8, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_9, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_10, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_11)
				: this(P_0, P_1, P_2, P_3, new VfJsWclfGaSaLuJACCTmezagGAyS[8] { P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11 })
			{
			}
		}

		internal sealed class eyycQxDRuCasxJOVwjStUkHiIwRcb : XbHjKerLgfdsmZwrmwvXEeexbXpfA, IControllerTemplateElement, IControllerTemplateYoke
		{
			private new const int hNXBRVFSCiNmWwcNDBTnrAivOzzi = 2;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[0];
				}
			}

			public IControllerTemplateAxis pushPull
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return (IControllerTemplateAxis)JlCnxdjSAFgokjnBJvAQVZXHNacj[1];
				}
			}

			private eyycQxDRuCasxJOVwjStUkHiIwRcb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VfJsWclfGaSaLuJACCTmezagGAyS[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Yoke, P_4, VfJsWclfGaSaLuJACCTmezagGAyS.vYvkwFszGegnqYFbNEypdKsFIKehA(P_0, P_1, P_2, P_3))
			{
			}

			internal eyycQxDRuCasxJOVwjStUkHiIwRcb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_4, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_5)
				: this(P_0, P_1, P_2, P_3, new VfJsWclfGaSaLuJACCTmezagGAyS[2] { P_4, P_5 })
			{
			}
		}

		internal sealed class WDtyHcpWzzHHdXGkwBNughxOBmIJ : dRhpEXynSxqdDpmwHPLLYyRMhzIn, IControllerTemplateElement, IControllerTemplateStick6D
		{
			private new const int hNXBRVFSCiNmWwcNDBTnrAivOzzi = 6;

			private WDtyHcpWzzHHdXGkwBNughxOBmIJ(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, VfJsWclfGaSaLuJACCTmezagGAyS[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Stick6D, P_4, VfJsWclfGaSaLuJACCTmezagGAyS.vYvkwFszGegnqYFbNEypdKsFIKehA(P_0, P_1, P_2, P_3))
			{
			}

			internal WDtyHcpWzzHHdXGkwBNughxOBmIJ(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_4, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_5, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_6, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_7, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_8, NKUIDloiFZwrHYSBiTNlEnKGDXJR P_9)
				: this(P_0, P_1, P_2, P_3, new VfJsWclfGaSaLuJACCTmezagGAyS[6] { P_4, P_5, P_6, P_7, P_8, P_9 })
			{
			}
		}

		internal class eyDQiGABtoXqHGRtmucOUpyqgWzdA
		{
			public readonly Controller.Element ooBBgkcWWsMagjYtYbeirjkcGey;

			public readonly IControllerElementTarget kxVVfsEvIkmogZXRbQDbWrFdzRdN;

			public bool PgYBwtVmbzeQthtCjcmnjFTgEEyYb
			{
				get
				{
					if (ooBBgkcWWsMagjYtYbeirjkcGey == null)
					{
						return false;
					}
					switch (ooBBgkcWWsMagjYtYbeirjkcGey.type)
					{
					case ControllerElementType.Button:
						return (ooBBgkcWWsMagjYtYbeirjkcGey as Controller.Button).value;
					case ControllerElementType.Axis:
					{
						float value = (ooBBgkcWWsMagjYtYbeirjkcGey as Controller.Axis).value;
						switch (kxVVfsEvIkmogZXRbQDbWrFdzRdN.axisRange)
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

			public bool HgqVejMPHsrEyhwdKaFeszHtJXqQ
			{
				get
				{
					if (ooBBgkcWWsMagjYtYbeirjkcGey == null)
					{
						return false;
					}
					switch (ooBBgkcWWsMagjYtYbeirjkcGey.type)
					{
					case ControllerElementType.Button:
						return (ooBBgkcWWsMagjYtYbeirjkcGey as Controller.Button).valuePrev;
					case ControllerElementType.Axis:
					{
						float valuePrev = (ooBBgkcWWsMagjYtYbeirjkcGey as Controller.Axis).valuePrev;
						switch (kxVVfsEvIkmogZXRbQDbWrFdzRdN.axisRange)
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

			public bool DaDKnRGgOMjNvbIxxlTQfhqTYBWu
			{
				get
				{
					if (ooBBgkcWWsMagjYtYbeirjkcGey == null)
					{
						return false;
					}
					switch (ooBBgkcWWsMagjYtYbeirjkcGey.type)
					{
					case ControllerElementType.Button:
						return (ooBBgkcWWsMagjYtYbeirjkcGey as Controller.Button).justPressed;
					case ControllerElementType.Axis:
						if (MathTools.Abs(NlgGoNcTUgcDNoMxANdsnzcJhVDT) > 0.01f && MathTools.Abs(TvWwOEewzrIcVGvAEteJVoCjIdIP) <= 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public bool CVtlCkydoxhirdTrieslqaaJclYmA
			{
				get
				{
					if (ooBBgkcWWsMagjYtYbeirjkcGey == null)
					{
						return false;
					}
					switch (ooBBgkcWWsMagjYtYbeirjkcGey.type)
					{
					case ControllerElementType.Button:
						return (ooBBgkcWWsMagjYtYbeirjkcGey as Controller.Button).justReleased;
					case ControllerElementType.Axis:
						if (MathTools.Abs(NlgGoNcTUgcDNoMxANdsnzcJhVDT) <= 0.01f && MathTools.Abs(TvWwOEewzrIcVGvAEteJVoCjIdIP) > 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public float NlgGoNcTUgcDNoMxANdsnzcJhVDT
			{
				get
				{
					if (ooBBgkcWWsMagjYtYbeirjkcGey == null)
					{
						return 0f;
					}
					switch (ooBBgkcWWsMagjYtYbeirjkcGey.type)
					{
					case ControllerElementType.Button:
						if (!(ooBBgkcWWsMagjYtYbeirjkcGey as Controller.Button).value)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float value = (ooBBgkcWWsMagjYtYbeirjkcGey as Controller.Axis).value;
						switch (kxVVfsEvIkmogZXRbQDbWrFdzRdN.axisRange)
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

			public float TvWwOEewzrIcVGvAEteJVoCjIdIP
			{
				get
				{
					if (ooBBgkcWWsMagjYtYbeirjkcGey == null)
					{
						return 0f;
					}
					switch (ooBBgkcWWsMagjYtYbeirjkcGey.type)
					{
					case ControllerElementType.Button:
						if (!(ooBBgkcWWsMagjYtYbeirjkcGey as Controller.Button).valuePrev)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float valuePrev = (ooBBgkcWWsMagjYtYbeirjkcGey as Controller.Axis).valuePrev;
						switch (kxVVfsEvIkmogZXRbQDbWrFdzRdN.axisRange)
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

			public eyDQiGABtoXqHGRtmucOUpyqgWzdA(IControllerElementTarget P_0, Controller.Element P_1)
			{
				ooBBgkcWWsMagjYtYbeirjkcGey = P_1;
				kxVVfsEvIkmogZXRbQDbWrFdzRdN = P_0;
			}

			public static eyDQiGABtoXqHGRtmucOUpyqgWzdA ZthtDKCPytXmopXrdcSWOpqCJOGs()
			{
				return new eyDQiGABtoXqHGRtmucOUpyqgWzdA(WortGyCOkKTpqRUAkJvQBKSaUPen.ZthtDKCPytXmopXrdcSWOpqCJOGs(), null);
			}
		}

		internal class WnRFFOvtjruZdEfEoBGUCWCAbWhO
		{
			public readonly Controller yBVYaZymnHfILCjQopwadWNgxbeH;

			public readonly IHardwareControllerTemplateMap_Internal hrxRbIpLqdAqbOBuwIvGJnsmVECA;

			public WnRFFOvtjruZdEfEoBGUCWCAbWhO(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				yBVYaZymnHfILCjQopwadWNgxbeH = P_0;
				hrxRbIpLqdAqbOBuwIvGJnsmVECA = P_1;
			}
		}

		private sealed class bHDzGKkkNLEvehmAszODxSDjIxkA
		{
			[Serializable]
			private sealed class RJcyFQejbHeYnFlUDDgzWGefDLqvA
			{
				public static readonly RJcyFQejbHeYnFlUDDgzWGefDLqvA _003C_003E9 = new RJcyFQejbHeYnFlUDDgzWGefDLqvA();

				public static Func<XXqMAmtzgVleMjCfPcHhdJZaHOvVA, XXqMAmtzgVleMjCfPcHhdJZaHOvVA, bool> _003C_003E9__4_0;

				internal bool HPScvmzpeFILbfrZHMdIvcQHrMWE(XXqMAmtzgVleMjCfPcHhdJZaHOvVA P_0, XXqMAmtzgVleMjCfPcHhdJZaHOvVA P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					return P_0.TUibHCXgdJpNwgxVPYRazOMZLYAI(P_1, false);
				}
			}

			private static bHDzGKkkNLEvehmAszODxSDjIxkA AAsUotzmeurdNsprWlhSRkCHGMyW;

			private readonly RJmfAjpdKLIIXgAAMaxkVDnckcjN<XXqMAmtzgVleMjCfPcHhdJZaHOvVA> OMwBQfLhmVTNVZtCfEIYYJfZqvfF;

			private static bHDzGKkkNLEvehmAszODxSDjIxkA kYNBFgnEJgclbFwpvHMfwUfnUCch
			{
				get
				{
					if (AAsUotzmeurdNsprWlhSRkCHGMyW != null)
					{
						return AAsUotzmeurdNsprWlhSRkCHGMyW;
					}
					AAsUotzmeurdNsprWlhSRkCHGMyW = new bHDzGKkkNLEvehmAszODxSDjIxkA();
					AAsUotzmeurdNsprWlhSRkCHGMyW.eYVBLUcuQlHJrbHrStsdmfsWfTEHA();
					return AAsUotzmeurdNsprWlhSRkCHGMyW;
				}
			}

			private bHDzGKkkNLEvehmAszODxSDjIxkA()
			{
				OMwBQfLhmVTNVZtCfEIYYJfZqvfF = new RJmfAjpdKLIIXgAAMaxkVDnckcjN<XXqMAmtzgVleMjCfPcHhdJZaHOvVA>(RJcyFQejbHeYnFlUDDgzWGefDLqvA._003C_003E9.HPScvmzpeFILbfrZHMdIvcQHrMWE);
			}

			private void eYVBLUcuQlHJrbHrStsdmfsWfTEHA()
			{
				ReInput.ShutDownEvent += AAsUotzmeurdNsprWlhSRkCHGMyW.MfhcSYGsnnapnbFcgMQToNLucqsoA;
			}

			private void MfhcSYGsnnapnbFcgMQToNLucqsoA()
			{
				if (AAsUotzmeurdNsprWlhSRkCHGMyW == this)
				{
					AAsUotzmeurdNsprWlhSRkCHGMyW = null;
				}
				ReInput.ShutDownEvent -= MfhcSYGsnnapnbFcgMQToNLucqsoA;
			}

			public static XXqMAmtzgVleMjCfPcHhdJZaHOvVA RGGJWIgQTGFjrbkplAhDgRPBiCkT(XXqMAmtzgVleMjCfPcHhdJZaHOvVA P_0)
			{
				Bytes20 bytes = ((P_0.RFjHapmZhUbePVVdFDdJBEtHxRzt is urVEweFPRbOeIIdMhHfayqASiHNDA urVEweFPRbOeIIdMhHfayqASiHNDA2) ? urVEweFPRbOeIIdMhHfayqASiHNDA2.mACczrXFRlrAJdooiJCGbwHueCkx.hash : default(Bytes20));
				return kYNBFgnEJgclbFwpvHMfwUfnUCch.OMwBQfLhmVTNVZtCfEIYYJfZqvfF.RGGJWIgQTGFjrbkplAhDgRPBiCkT(bytes, P_0);
			}

			public static bool XoWrPhuuoYdElFYmsPRgFLepADbg(XXqMAmtzgVleMjCfPcHhdJZaHOvVA P_0, out XXqMAmtzgVleMjCfPcHhdJZaHOvVA P_1)
			{
				Bytes20 bytes = ((P_0.RFjHapmZhUbePVVdFDdJBEtHxRzt is urVEweFPRbOeIIdMhHfayqASiHNDA urVEweFPRbOeIIdMhHfayqASiHNDA2) ? urVEweFPRbOeIIdMhHfayqASiHNDA2.mACczrXFRlrAJdooiJCGbwHueCkx.hash : default(Bytes20));
				return kYNBFgnEJgclbFwpvHMfwUfnUCch.OMwBQfLhmVTNVZtCfEIYYJfZqvfF.XoWrPhuuoYdElFYmsPRgFLepADbg(bytes, P_0, out P_1);
			}

			public static void fyeqCafQbFyflbNbajUvornPxfgy(XXqMAmtzgVleMjCfPcHhdJZaHOvVA P_0)
			{
				Bytes20 bytes = ((P_0.RFjHapmZhUbePVVdFDdJBEtHxRzt is urVEweFPRbOeIIdMhHfayqASiHNDA urVEweFPRbOeIIdMhHfayqASiHNDA2) ? urVEweFPRbOeIIdMhHfayqASiHNDA2.mACczrXFRlrAJdooiJCGbwHueCkx.hash : default(Bytes20));
				kYNBFgnEJgclbFwpvHMfwUfnUCch.OMwBQfLhmVTNVZtCfEIYYJfZqvfF.fyeqCafQbFyflbNbajUvornPxfgy(bytes, P_0);
			}
		}

		private const string mzVPpYpnwixRejNdGdywXfXJhtkv = "controller/template";

		private string XXuYUuZFvXwuYxiNryIOxzHdIWPU;

		private string iznbkRlQcoGkZtBlmfunFSNsZtUK;

		private int rDnRVTAZXyaVlJOBjDydLOTjrRpD;

		private readonly Guid oSlSQswPZHbHxHnkaobCRaExGljf;

		private readonly DeviceLocalizationInfo cMOhIWyaBnCynMJwNfakJfQfUpqVA;

		private readonly Controller SHugpoIFWkCnojYBXWjOaAoAAYCW;

		private readonly ADictionary<int, IControllerTemplateElement> tTkkQnBIeauYStoWoNFZrvWCQhzU;

		private readonly ADictionary<string, IControllerTemplateElement> LMJZrAkaTJWvkvOwHprVmPRLdhKjA;

		private IControllerTemplateElement[] JlCnxdjSAFgokjnBJvAQVZXHNacj;

		private ReadOnlyCollection<IControllerTemplateElement> jyTJsuSvMygQOFvHEMJfNaFRYsZO;

		private readonly ySFzLcEuqAOMOxTEGgUhEEdHrazE oGPaEasMppAsagimCGQlgSqfnxSs;

		private readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

		internal DeviceLocalizationInfo JYYGtakbmvGLraXxUiNykxsEllMM => cMOhIWyaBnCynMJwNfakJfQfUpqVA;

		DeviceLocalizationInfo IControllerTemplate_Internal.deviceLocalizationInfo => cMOhIWyaBnCynMJwNfakJfQfUpqVA;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return SHugpoIFWkCnojYBXWjOaAoAAYCW;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				if (!LocalizationManager.isEnabled)
				{
					return XXuYUuZFvXwuYxiNryIOxzHdIWPU;
				}
				return oGPaEasMppAsagimCGQlgSqfnxSs.jXwgbYbEpdqHGeBdCbXEcskUaWaFA;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Guid.Empty;
				}
				return oSlSQswPZHbHxHnkaobCRaExGljf;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return jyTJsuSvMygQOFvHEMJfNaFRYsZO;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				return JlCnxdjSAFgokjnBJvAQVZXHNacj.Length;
			}
		}

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.keyCategory => "controller/template";

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.scriptingName => string.Empty;

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.nonLocalizedDescriptiveName
		{
			get
			{
				return XXuYUuZFvXwuYxiNryIOxzHdIWPU;
			}
			set
			{
				XXuYUuZFvXwuYxiNryIOxzHdIWPU = value;
			}
		}

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.key => iznbkRlQcoGkZtBlmfunFSNsZtUK;

		int jtAeQMwqfCHdCmeHvhaRCqwDmBxb.autoGeneratedValueFlags
		{
			get
			{
				return rDnRVTAZXyaVlJOBjDydLOTjrRpD;
			}
			set
			{
				rDnRVTAZXyaVlJOBjDydLOTjrRpD = value;
			}
		}

		protected ControllerTemplate(object P_0)
			: this((WnRFFOvtjruZdEfEoBGUCWCAbWhO)P_0)
		{
		}

		private ControllerTemplate(WnRFFOvtjruZdEfEoBGUCWCAbWhO P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (P_0.yBVYaZymnHfILCjQopwadWNgxbeH == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (P_0.hrxRbIpLqdAqbOBuwIvGJnsmVECA == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
			SHugpoIFWkCnojYBXWjOaAoAAYCW = P_0.yBVYaZymnHfILCjQopwadWNgxbeH;
			IHardwareControllerTemplateMap_Internal hrxRbIpLqdAqbOBuwIvGJnsmVECA = P_0.hrxRbIpLqdAqbOBuwIvGJnsmVECA;
			XXuYUuZFvXwuYxiNryIOxzHdIWPU = hrxRbIpLqdAqbOBuwIvGJnsmVECA.name;
			iznbkRlQcoGkZtBlmfunFSNsZtUK = hrxRbIpLqdAqbOBuwIvGJnsmVECA.typeKey;
			oSlSQswPZHbHxHnkaobCRaExGljf = hrxRbIpLqdAqbOBuwIvGJnsmVECA.typeGuid;
			cMOhIWyaBnCynMJwNfakJfQfUpqVA = new DeviceLocalizationInfo(SHugpoIFWkCnojYBXWjOaAoAAYCW.type, true, oSlSQswPZHbHxHnkaobCRaExGljf, new List<string> { hrxRbIpLqdAqbOBuwIvGJnsmVECA.typeKey }, null);
			cMOhIWyaBnCynMJwNfakJfQfUpqVA.FinishRuntimeSetup();
			oGPaEasMppAsagimCGQlgSqfnxSs = ySFzLcEuqAOMOxTEGgUhEEdHrazE.VxSNvmooWfTkIVcICGUZnqoUJPDW(this);
			int elementIdentifierCount = hrxRbIpLqdAqbOBuwIvGJnsmVECA.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = hrxRbIpLqdAqbOBuwIvGJnsmVECA.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						fMlgSaItucfCTlOMuaOrAzViaQaCA fMlgSaItucfCTlOMuaOrAzViaQaCA3 = hrxRbIpLqdAqbOBuwIvGJnsmVECA.GetAxisTarget(SHugpoIFWkCnojYBXWjOaAoAAYCW, templateElementIdentifier.id) ?? fMlgSaItucfCTlOMuaOrAzViaQaCA.ZthtDKCPytXmopXrdcSWOpqCJOGs(ControllerTemplateElementType.Axis);
						eMxFQFHytkjFfuXbRGkGxcKZrMzB item2 = new eMxFQFHytkjFfuXbRGkGxcKZrMzB(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, fMlgSaItucfCTlOMuaOrAzViaQaCA3, kDOhreHQBnIoJjbqsJSUlZYiNirL(SHugpoIFWkCnojYBXWjOaAoAAYCW, (IControllerTemplateAxisSource)fMlgSaItucfCTlOMuaOrAzViaQaCA3));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						fMlgSaItucfCTlOMuaOrAzViaQaCA fMlgSaItucfCTlOMuaOrAzViaQaCA2 = hrxRbIpLqdAqbOBuwIvGJnsmVECA.GetButtonTarget(SHugpoIFWkCnojYBXWjOaAoAAYCW, templateElementIdentifier.id) ?? fMlgSaItucfCTlOMuaOrAzViaQaCA.ZthtDKCPytXmopXrdcSWOpqCJOGs(ControllerTemplateElementType.Button);
						JCmGMXGYJdSmKrXBYCvOEUsGUGXH item = new JCmGMXGYJdSmKrXBYCvOEUsGUGXH(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, fMlgSaItucfCTlOMuaOrAzViaQaCA2, kDOhreHQBnIoJjbqsJSUlZYiNirL(SHugpoIFWkCnojYBXWjOaAoAAYCW, (IControllerTemplateButtonSource)fMlgSaItucfCTlOMuaOrAzViaQaCA2));
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
				IControllerTemplateElementIdentifier templateElementIdentifier2 = hrxRbIpLqdAqbOBuwIvGJnsmVECA.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = hrxRbIpLqdAqbOBuwIvGJnsmVECA.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				VfJsWclfGaSaLuJACCTmezagGAyS vfJsWclfGaSaLuJACCTmezagGAyS;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					vfJsWclfGaSaLuJACCTmezagGAyS = new urCnOrOxOivUddMsYNBKmaLCsBeV(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping5 != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping5.eid_axisX) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping5 != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping5.eid_axisY) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping5 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping5.eid_button) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					vfJsWclfGaSaLuJACCTmezagGAyS = new WahiOsxHbbKXGpBRynkLrIJvoxiu(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping3 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping3.eid_up) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping3 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping3.eid_right) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping3 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping3.eid_down) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping3 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping3.eid_left) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping3 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping3.eid_press) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					vfJsWclfGaSaLuJACCTmezagGAyS = new jLdlgHmarVukPYbJraeHndaTvAFV(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping2 != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping2.eid_axisX) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping2 != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping2.eid_axisY) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping2 != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping2.eid_axisZ) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					vfJsWclfGaSaLuJACCTmezagGAyS = new VsPPdAkXqpidpNdIQCTMmYkpKfIC(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping6 != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping6.eid_axis) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping6 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping6.eid_minDetent) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					vfJsWclfGaSaLuJACCTmezagGAyS = new yZhZOITzHNbsoeJJZnZjKSGksVkf(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping7 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping7.eid_up) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping7 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping7.eid_upRight) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping7 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping7.eid_right) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping7 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping7.eid_downRight) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping7 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping7.eid_down) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping7 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping7.eid_downLeft) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping7 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping7.eid_left) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping7 != null) ? ARtThZfcYFFcPpcOdDABFOcvJqddb(this, aDictionary, mapping7.eid_upLeft) : JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					vfJsWclfGaSaLuJACCTmezagGAyS = new eyycQxDRuCasxJOVwjStUkHiIwRcb(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping4 != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping4.eid_axisX) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping4 != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping4.eid_axisZ) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					vfJsWclfGaSaLuJACCTmezagGAyS = new WDtyHcpWzzHHdXGkwBNughxOBmIJ(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping.eid_positionX) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping.eid_positionY) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping.eid_positionZ) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping.eid_rotationX) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping.eid_rotationY) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this), (mapping != null) ? tgsDbKcEHAjlqkPaJmxJZLdyOKSt(this, aDictionary, mapping.eid_rotationZ) : eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (vfJsWclfGaSaLuJACCTmezagGAyS != null)
				{
					list4.Add(vfJsWclfGaSaLuJACCTmezagGAyS);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			JlCnxdjSAFgokjnBJvAQVZXHNacj = list.ToArray();
			tTkkQnBIeauYStoWoNFZrvWCQhzU = aDictionary;
			LMJZrAkaTJWvkvOwHprVmPRLdhKjA = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < JlCnxdjSAFgokjnBJvAQVZXHNacj.Length; num++)
			{
				if (!(hrxRbIpLqdAqbOBuwIvGJnsmVECA.GetTemplateElementIdentifierById(JlCnxdjSAFgokjnBJvAQVZXHNacj[num].id) is IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor))
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
							LMJZrAkaTJWvkvOwHprVmPRLdhKjA.Add(text, JlCnxdjSAFgokjnBJvAQVZXHNacj[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + XXuYUuZFvXwuYxiNryIOxzHdIWPU + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			jyTJsuSvMygQOFvHEMJfNaFRYsZO = new ReadOnlyCollection<IControllerTemplateElement>(JlCnxdjSAFgokjnBJvAQVZXHNacj);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			if (!tTkkQnBIeauYStoWoNFZrvWCQhzU.TryGetValue(id, out var value))
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			return GetElement(id);
		}

		T IControllerTemplate.GetElement<T>(int id)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			return GetElement<T>(id);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget find, IList<ControllerTemplateElementTarget> results)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			for (int i = 0; i < JlCnxdjSAFgokjnBJvAQVZXHNacj.Length; i++)
			{
				if (InputTools.IsMappableType(JlCnxdjSAFgokjnBJvAQVZXHNacj[i].type))
				{
					num += (JlCnxdjSAFgokjnBJvAQVZXHNacj[i] as IControllerTemplateElement_Internal).GetElementTargets(find, ref results);
				}
			}
			return num;
		}

		[CustomObfuscation(rename = false)]
		internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
		{
			switch (elementType)
			{
			case ControllerTemplateElementType.Axis:
				return typeof(IControllerTemplateAxis);
			case ControllerTemplateElementType.Button:
				return typeof(IControllerTemplateButton);
			case ControllerTemplateElementType.ThumbStick:
				return typeof(IControllerTemplateThumbStick);
			case ControllerTemplateElementType.DPad:
				return typeof(IControllerTemplateDPad);
			case ControllerTemplateElementType.Stick:
				return typeof(IControllerTemplateStick);
			case ControllerTemplateElementType.Throttle:
				return typeof(IControllerTemplateThrottle);
			case ControllerTemplateElementType.Hat:
				return typeof(IControllerTemplateHat);
			case ControllerTemplateElementType.Yoke:
				return typeof(IControllerTemplateYoke);
			case ControllerTemplateElementType.Stick6D:
				return typeof(IControllerTemplateStick6D);
			default:
				throw new NotImplementedException();
			}
		}

		private static IList<eyDQiGABtoXqHGRtmucOUpyqgWzdA> kDOhreHQBnIoJjbqsJSUlZYiNirL(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			if (P_1.splitAxis)
			{
				IList<eyDQiGABtoXqHGRtmucOUpyqgWzdA> list = null;
				bool flag = false;
				if (P_1.positiveTarget != null)
				{
					Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					if (elementById != null)
					{
						ListTools.AddAndCreateList(ref list, new eyDQiGABtoXqHGRtmucOUpyqgWzdA(P_1.positiveTarget, elementById));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, eyDQiGABtoXqHGRtmucOUpyqgWzdA.ZthtDKCPytXmopXrdcSWOpqCJOGs());
				}
				flag = false;
				if (P_1.negativeTarget != null)
				{
					Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
					if (elementById2 != null)
					{
						ListTools.AddAndCreateList(ref list, new eyDQiGABtoXqHGRtmucOUpyqgWzdA(P_1.negativeTarget, elementById2));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, eyDQiGABtoXqHGRtmucOUpyqgWzdA.ZthtDKCPytXmopXrdcSWOpqCJOGs());
				}
				return list;
			}
			return kDOhreHQBnIoJjbqsJSUlZYiNirL(P_0, P_1.fullTarget);
		}

		private static IList<eyDQiGABtoXqHGRtmucOUpyqgWzdA> kDOhreHQBnIoJjbqsJSUlZYiNirL(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return kDOhreHQBnIoJjbqsJSUlZYiNirL(P_0, P_1.target);
		}

		private static IList<eyDQiGABtoXqHGRtmucOUpyqgWzdA> kDOhreHQBnIoJjbqsJSUlZYiNirL(Controller P_0, IControllerElementTarget P_1)
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
			return new List<eyDQiGABtoXqHGRtmucOUpyqgWzdA>
			{
				new eyDQiGABtoXqHGRtmucOUpyqgWzdA(P_1, elementById)
			};
		}

		private static IControllerTemplateElement IjVLBlIflGUpoVVgJIgDNCxTxwtM(List<IControllerTemplateElement> P_0, int P_1)
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

		private static NKUIDloiFZwrHYSBiTNlEnKGDXJR tgsDbKcEHAjlqkPaJmxJZLdyOKSt(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is NKUIDloiFZwrHYSBiTNlEnKGDXJR result))
			{
				return eMxFQFHytkjFfuXbRGkGxcKZrMzB.ZthtDKCPytXmopXrdcSWOpqCJOGs(P_0);
			}
			return result;
		}

		private static NKUIDloiFZwrHYSBiTNlEnKGDXJR ARtThZfcYFFcPpcOdDABFOcvJqddb(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is NKUIDloiFZwrHYSBiTNlEnKGDXJR result))
			{
				return JCmGMXGYJdSmKrXBYCvOEUsGUGXH.ZthtDKCPytXmopXrdcSWOpqCJOGs(P_0);
			}
			return result;
		}
	}
}
