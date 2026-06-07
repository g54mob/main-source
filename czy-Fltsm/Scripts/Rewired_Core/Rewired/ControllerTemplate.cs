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
	public abstract class ControllerTemplate : IControllerTemplate, IControllerTemplate_Internal, sZLAxvZSvDRmVjMjTVRhHfujppQp
	{
		internal abstract class WWhSPLUXNAxBznMDmErldywOpDjO : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate fmMYcreqSLZgLSTrJPFHVIAuIRVs;

			private readonly int gPjGXRGpCvERCCwcnmZFhvYincaW;

			private readonly ControllerTemplateElementType qNMDXhWhSbgHRcXuIwMnCYrIIOPsA;

			protected readonly int jEKyludiiDakDZlKRCWIRRvzLLCG;

			protected readonly EsWxHDSqntpFyaXqdUbmApTIfXceA uxWgUeAjqygnCtkPHBcYVAxNWJFX;

			int IControllerTemplateElement.id
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return -1;
					}
					return gPjGXRGpCvERCCwcnmZFhvYincaW;
				}
			}

			string IControllerTemplateElement.descriptiveName
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return uxWgUeAjqygnCtkPHBcYVAxNWJFX.yVatUAudEsSPycjNahorNfJAMqVb;
				}
			}

			internal string wBaAgGKsgNmNCFaRXIriDFhrwyNP => uxWgUeAjqygnCtkPHBcYVAxNWJFX.nonLocalizedDescriptiveName;

			ControllerTemplateElementType IControllerTemplateElement.type
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return ControllerTemplateElementType.Axis;
					}
					return qNMDXhWhSbgHRcXuIwMnCYrIIOPsA;
				}
			}

			IControllerTemplate IControllerTemplateElement_Internal.parent => fmMYcreqSLZgLSTrJPFHVIAuIRVs;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected WWhSPLUXNAxBznMDmErldywOpDjO(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, EsWxHDSqntpFyaXqdUbmApTIfXceA P_3)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_3 == null)
				{
					throw new ArgumentNullException("localizedElement");
				}
				fmMYcreqSLZgLSTrJPFHVIAuIRVs = P_0;
				gPjGXRGpCvERCCwcnmZFhvYincaW = P_1;
				qNMDXhWhSbgHRcXuIwMnCYrIIOPsA = P_2;
				jEKyludiiDakDZlKRCWIRRvzLLCG = ReInput.id;
				uxWgUeAjqygnCtkPHBcYVAxNWJFX = P_3;
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);

			protected static EsWxHDSqntpFyaXqdUbmApTIfXceA qWSETbTAunrKuuHohuzsfADdWJwm(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3)
			{
				return eZbbyjJwvhNhRsGhorDZeTUlGReS.QXRrpQzzMQKAcaEQJypZDnnMBUPDA(new EsWxHDSqntpFyaXqdUbmApTIfXceA(wcVYCXunfViVKtXfiFknivIQrvqtA.fIYUcjttuDNeHwxKNKUEHLsEAifO(flkMCmNLqqynNeuvLSYPGZFpwSqE.ControllerTemplate, MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Unknown, MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3));
			}
		}

		internal abstract class OnkeuYWKmdGnpQyNvHTnFgTxghacA : WWhSPLUXNAxBznMDmErldywOpDjO
		{
			protected readonly int nLgNiHLOWxdPWPhrTIMAxorgIukS;

			protected readonly pRnwzxzWcWfRjPOiOqGPREeWlFeo[] GTAymVpsmyNSxmEgaluESOfRvwnJ;

			bool WWhSPLUXNAxBznMDmErldywOpDjO.exists
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return false;
					}
					if (GTAymVpsmyNSxmEgaluESOfRvwnJ == null)
					{
						return false;
					}
					for (int i = 0; i < GTAymVpsmyNSxmEgaluESOfRvwnJ.Length; i++)
					{
						if (GTAymVpsmyNSxmEgaluESOfRvwnJ[i].eUkuhwZGEhKbzvsdSFPNQHgbnhdY != null)
						{
							return true;
						}
					}
					return false;
				}
			}

			protected OnkeuYWKmdGnpQyNvHTnFgTxghacA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, IList<pRnwzxzWcWfRjPOiOqGPREeWlFeo> P_3, EsWxHDSqntpFyaXqdUbmApTIfXceA P_4)
				: base(P_0, P_1, P_2, P_4)
			{
				GTAymVpsmyNSxmEgaluESOfRvwnJ = ((P_3 != null) ? ListTools.ToArray(P_3) : null);
				nLgNiHLOWxdPWPhrTIMAxorgIukS = ((GTAymVpsmyNSxmEgaluESOfRvwnJ != null) ? GTAymVpsmyNSxmEgaluESOfRvwnJ.Length : 0);
			}
		}

		internal abstract class SfeECIiDOhaKpDDOAYbcBLGoqICtB : OnkeuYWKmdGnpQyNvHTnFgTxghacA, IControllerTemplateAxis, IControllerTemplateElement, IControllerTemplateButton
		{
			private wyBGNVjftIezdumZCvkmiqVKqZjAA WRwrmhvqwjBGKxatImWszazyYFAW;

			public float CKrbLyIKZDEVVyyBGqxjUNvBmCQWA
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return 0f;
					}
					if (nLgNiHLOWxdPWPhrTIMAxorgIukS == 1)
					{
						return GTAymVpsmyNSxmEgaluESOfRvwnJ[0].heaglKnPkrWYIUPLWMkCDiIBGkZCA;
					}
					if (nLgNiHLOWxdPWPhrTIMAxorgIukS == 2)
					{
						float num = GTAymVpsmyNSxmEgaluESOfRvwnJ[0].heaglKnPkrWYIUPLWMkCDiIBGkZCA;
						float num2 = GTAymVpsmyNSxmEgaluESOfRvwnJ[1].heaglKnPkrWYIUPLWMkCDiIBGkZCA;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public float QipEgpANGFNRECYJeVXYyjAujThU
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return 0f;
					}
					if (nLgNiHLOWxdPWPhrTIMAxorgIukS == 1)
					{
						return GTAymVpsmyNSxmEgaluESOfRvwnJ[0].HuAXfLbkLhtmpuWHewRJGjYAanR;
					}
					if (nLgNiHLOWxdPWPhrTIMAxorgIukS == 2)
					{
						float num = GTAymVpsmyNSxmEgaluESOfRvwnJ[0].HuAXfLbkLhtmpuWHewRJGjYAanR;
						float num2 = GTAymVpsmyNSxmEgaluESOfRvwnJ[1].HuAXfLbkLhtmpuWHewRJGjYAanR;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool oZexnTPcgWlbBxRYEyTiRPriCfKk
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return false;
					}
					if (nLgNiHLOWxdPWPhrTIMAxorgIukS == 1)
					{
						return GTAymVpsmyNSxmEgaluESOfRvwnJ[0].fGIUJwaJsCZQqEBWOJkUXFDqWnrA;
					}
					if (nLgNiHLOWxdPWPhrTIMAxorgIukS == 2)
					{
						if (!GTAymVpsmyNSxmEgaluESOfRvwnJ[0].fGIUJwaJsCZQqEBWOJkUXFDqWnrA)
						{
							return GTAymVpsmyNSxmEgaluESOfRvwnJ[1].fGIUJwaJsCZQqEBWOJkUXFDqWnrA;
						}
						return true;
					}
					return false;
				}
			}

			public bool DrRVFNAvIXGgXqlOTidukusnmWoqA
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return false;
					}
					if (nLgNiHLOWxdPWPhrTIMAxorgIukS == 1)
					{
						return GTAymVpsmyNSxmEgaluESOfRvwnJ[0].pvdNHWYkVMXqkvZxiPZABLEdKNrQ;
					}
					if (nLgNiHLOWxdPWPhrTIMAxorgIukS == 2)
					{
						if (!GTAymVpsmyNSxmEgaluESOfRvwnJ[0].pvdNHWYkVMXqkvZxiPZABLEdKNrQ)
						{
							return GTAymVpsmyNSxmEgaluESOfRvwnJ[1].pvdNHWYkVMXqkvZxiPZABLEdKNrQ;
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
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return aMntQdsySDxsDaXaApdfjDPjETNg.YeGbtPBEgxOxpLWJTwVAWpnJmsoE;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return aMntQdsySDxsDaXaApdfjDPjETNg.mQiAumPEhukTPPoLejaNGQtUcfeGb;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return 0f;
					}
					return CKrbLyIKZDEVVyyBGqxjUNvBmCQWA;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return 0f;
					}
					return QipEgpANGFNRECYJeVXYyjAujThU;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return WRwrmhvqwjBGKxatImWszazyYFAW;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return false;
					}
					return oZexnTPcgWlbBxRYEyTiRPriCfKk;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return false;
					}
					return DrRVFNAvIXGgXqlOTidukusnmWoqA;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return false;
					}
					if (nLgNiHLOWxdPWPhrTIMAxorgIukS == 1)
					{
						return GTAymVpsmyNSxmEgaluESOfRvwnJ[0].WOWoSVSGwRnlTpExBCHjwMUCVitV;
					}
					if (nLgNiHLOWxdPWPhrTIMAxorgIukS == 2)
					{
						if (!GTAymVpsmyNSxmEgaluESOfRvwnJ[0].WOWoSVSGwRnlTpExBCHjwMUCVitV || GTAymVpsmyNSxmEgaluESOfRvwnJ[1].pvdNHWYkVMXqkvZxiPZABLEdKNrQ)
						{
							if (GTAymVpsmyNSxmEgaluESOfRvwnJ[1].WOWoSVSGwRnlTpExBCHjwMUCVitV)
							{
								return !GTAymVpsmyNSxmEgaluESOfRvwnJ[0].pvdNHWYkVMXqkvZxiPZABLEdKNrQ;
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
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return false;
					}
					if (nLgNiHLOWxdPWPhrTIMAxorgIukS == 1)
					{
						return GTAymVpsmyNSxmEgaluESOfRvwnJ[0].fBNsoTyDZmaqPCfLCFaIVRVKNcQIA;
					}
					if (nLgNiHLOWxdPWPhrTIMAxorgIukS == 2)
					{
						if (!GTAymVpsmyNSxmEgaluESOfRvwnJ[0].fBNsoTyDZmaqPCfLCFaIVRVKNcQIA || GTAymVpsmyNSxmEgaluESOfRvwnJ[1].fGIUJwaJsCZQqEBWOJkUXFDqWnrA)
						{
							if (GTAymVpsmyNSxmEgaluESOfRvwnJ[1].fBNsoTyDZmaqPCfLCFaIVRVKNcQIA)
							{
								return !GTAymVpsmyNSxmEgaluESOfRvwnJ[0].fGIUJwaJsCZQqEBWOJkUXFDqWnrA;
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
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return false;
					}
					return oZexnTPcgWlbBxRYEyTiRPriCfKk != DrRVFNAvIXGgXqlOTidukusnmWoqA;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return 0f;
					}
					return CKrbLyIKZDEVVyyBGqxjUNvBmCQWA;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return 0f;
					}
					return QipEgpANGFNRECYJeVXYyjAujThU;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return WRwrmhvqwjBGKxatImWszazyYFAW;
				}
			}

			IControllerTemplateElementSource WWhSPLUXNAxBznMDmErldywOpDjO.source
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return WRwrmhvqwjBGKxatImWszazyYFAW;
				}
			}

			int WWhSPLUXNAxBznMDmErldywOpDjO.elementCount => 0;

			IControllerTemplateAxis IControllerTemplateButton.AsAxis
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return this;
				}
			}

			IControllerTemplateButton IControllerTemplateAxis.AsButton
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return this;
				}
			}

			protected AhgVzjklwKGgzISYowXLxyncdKZD aMntQdsySDxsDaXaApdfjDPjETNg => (AhgVzjklwKGgzISYowXLxyncdKZD)uxWgUeAjqygnCtkPHBcYVAxNWJFX;

			protected SfeECIiDOhaKpDDOAYbcBLGoqICtB(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, wyBGNVjftIezdumZCvkmiqVKqZjAA P_3, IList<pRnwzxzWcWfRjPOiOqGPREeWlFeo> P_4, AhgVzjklwKGgzISYowXLxyncdKZD P_5)
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
				WRwrmhvqwjBGKxatImWszazyYFAW = P_3;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange axisRange)
			{
				if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
				{
					ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
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
					IControllerTemplateAxisSource wRwrmhvqwjBGKxatImWszazyYFAW = WRwrmhvqwjBGKxatImWszazyYFAW;
					if (wRwrmhvqwjBGKxatImWszazyYFAW.splitAxis)
					{
						if (HIfkJsWwDDnFOjbZQhXgWbGqknJL(find, wRwrmhvqwjBGKxatImWszazyYFAW.positiveTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
							num++;
						}
						if (HIfkJsWwDDnFOjbZQhXgWbGqknJL(find, wRwrmhvqwjBGKxatImWszazyYFAW.negativeTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
							num++;
						}
					}
					else if (HIfkJsWwDDnFOjbZQhXgWbGqknJL(find, wRwrmhvqwjBGKxatImWszazyYFAW.fullTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
						num++;
					}
					break;
				}
				case ControllerTemplateElementType.Button:
					if (HIfkJsWwDDnFOjbZQhXgWbGqknJL(find, ((IControllerTemplateButtonSource)WRwrmhvqwjBGKxatImWszazyYFAW).target))
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

			private static bool HIfkJsWwDDnFOjbZQhXgWbGqknJL(ControllerElementTarget P_0, IControllerElementTarget P_1)
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

		internal sealed class xAkBApivrHTOhdxWlpyngYexmtDL : SfeECIiDOhaKpDDOAYbcBLGoqICtB
		{
			public xAkBApivrHTOhdxWlpyngYexmtDL(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, wyBGNVjftIezdumZCvkmiqVKqZjAA P_8, IList<pRnwzxzWcWfRjPOiOqGPREeWlFeo> P_9)
				: base(P_0, P_1, ControllerTemplateElementType.Axis, P_8, P_9, (AhgVzjklwKGgzISYowXLxyncdKZD)eZbbyjJwvhNhRsGhorDZeTUlGReS.QXRrpQzzMQKAcaEQJypZDnnMBUPDA(new AhgVzjklwKGgzISYowXLxyncdKZD(qYSmXMgUajfmYTghAqPnrKCzyqDf.DfUpoOpNvTFfKZIkWRkcDysGlsih(flkMCmNLqqynNeuvLSYPGZFpwSqE.ControllerTemplate, MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Axis, MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
			{
				if (P_9 != null && P_9.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static xAkBApivrHTOhdxWlpyngYexmtDL cYNankYOxtzTTFNplCiljtJybqOEA(IControllerTemplate_Internal P_0)
			{
				return new xAkBApivrHTOhdxWlpyngYexmtDL(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, wyBGNVjftIezdumZCvkmiqVKqZjAA.tveLONDaoWrbqwSWMitxVOABUhik(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class MTEBqRxAMBvojkGPkmRbPcgaPDGD : SfeECIiDOhaKpDDOAYbcBLGoqICtB
		{
			public MTEBqRxAMBvojkGPkmRbPcgaPDGD(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, wyBGNVjftIezdumZCvkmiqVKqZjAA P_8, IList<pRnwzxzWcWfRjPOiOqGPREeWlFeo> P_9)
				: base(P_0, P_1, ControllerTemplateElementType.Button, P_8, P_9, (AhgVzjklwKGgzISYowXLxyncdKZD)eZbbyjJwvhNhRsGhorDZeTUlGReS.QXRrpQzzMQKAcaEQJypZDnnMBUPDA(new AhgVzjklwKGgzISYowXLxyncdKZD(qYSmXMgUajfmYTghAqPnrKCzyqDf.DfUpoOpNvTFfKZIkWRkcDysGlsih(flkMCmNLqqynNeuvLSYPGZFpwSqE.ControllerTemplate, MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Button, MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
			{
				if (P_9 != null && P_9.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static MTEBqRxAMBvojkGPkmRbPcgaPDGD PhpSrWwUrGopgHCiwTaGYkDWtvbN(IControllerTemplate_Internal P_0)
			{
				return new MTEBqRxAMBvojkGPkmRbPcgaPDGD(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, wyBGNVjftIezdumZCvkmiqVKqZjAA.tveLONDaoWrbqwSWMitxVOABUhik(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class ctQFlbjBDyfQhOaQekZUBryfoBENB : WWhSPLUXNAxBznMDmErldywOpDjO
		{
			protected readonly int LZmzPpaRJzKsMmgXFaIntEpWBkUu;

			protected readonly WWhSPLUXNAxBznMDmErldywOpDjO[] HzvPrHUMoLyoUgjDxlsrPhSMxhjN;

			bool WWhSPLUXNAxBznMDmErldywOpDjO.exists
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return false;
					}
					for (int i = 0; i < LZmzPpaRJzKsMmgXFaIntEpWBkUu; i++)
					{
						if (HzvPrHUMoLyoUgjDxlsrPhSMxhjN[i].exists)
						{
							return true;
						}
					}
					return false;
				}
			}

			IControllerTemplateElementSource WWhSPLUXNAxBznMDmErldywOpDjO.source
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return null;
				}
			}

			int WWhSPLUXNAxBznMDmErldywOpDjO.elementCount => LZmzPpaRJzKsMmgXFaIntEpWBkUu;

			protected ctQFlbjBDyfQhOaQekZUBryfoBENB(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, WWhSPLUXNAxBznMDmErldywOpDjO[] P_3, EsWxHDSqntpFyaXqdUbmApTIfXceA P_4)
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
				HzvPrHUMoLyoUgjDxlsrPhSMxhjN = P_3;
				LZmzPpaRJzKsMmgXFaIntEpWBkUu = P_3.Length;
			}

			public virtual IControllerTemplateElement ZHIsNmWadvcEHcjhNjcWvWNepUyOA(int P_0)
			{
				return HzvPrHUMoLyoUgjDxlsrPhSMxhjN[P_0];
			}

			public virtual int hxHKYyHPIIFJQdZLDFTbpseRJYvs(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				for (int i = 0; i < HzvPrHUMoLyoUgjDxlsrPhSMxhjN.Length; i++)
				{
					num += HzvPrHUMoLyoUgjDxlsrPhSMxhjN[i].GetElementTargets(P_0, ref P_1);
				}
				return num;
			}
		}

		internal abstract class CwhbPZHGtRTRAhMwEAJUBVohXKmVb : ctQFlbjBDyfQhOaQekZUBryfoBENB, IControllerTemplateAxis2D, IControllerTemplateElement
		{
			protected const int QUpfYOgoBgUEqkGswGXpuiErXesBA = 0;

			protected const int vtTkQWTUxAtYnUwnxfitozDOvmQT = 1;

			protected const int CfQVlWIGoKdEJBpwAiIHEBetVhYR = 2;

			Vector2 IControllerTemplateAxis2D.value
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return Vector2.zero;
					}
					return new Vector2((LZmzPpaRJzKsMmgXFaIntEpWBkUu > 0) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 1) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA : 0f);
				}
			}

			Vector2 IControllerTemplateAxis2D.valuePrev
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return Vector2.zero;
					}
					return new Vector2((LZmzPpaRJzKsMmgXFaIntEpWBkUu > 0) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0]).QipEgpANGFNRECYJeVXYyjAujThU : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 1) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1]).QipEgpANGFNRECYJeVXYyjAujThU : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.horizontal
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.vertical
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1];
				}
			}

			protected CwhbPZHGtRTRAhMwEAJUBVohXKmVb(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, WWhSPLUXNAxBznMDmErldywOpDjO[] P_3, EsWxHDSqntpFyaXqdUbmApTIfXceA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class QmfaCeyhEhBIrItlYFGzlTUGRjPoA : ctQFlbjBDyfQhOaQekZUBryfoBENB, IControllerTemplateAxis3D, IControllerTemplateElement
		{
			protected const int DEcitvxNVJBaUYcrkMNRoMfxOgsw = 0;

			protected const int rQOyiDanAHzPmlsLYEaBRTKrpqHr = 1;

			protected const int HVHlwQuBVWcRFMPVTKoWPZisYTWk = 2;

			protected const int GQQRhEWpmOhMXALPyGSzviyqiBfEA = 3;

			Vector3 IControllerTemplateAxis3D.value
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return Vector3.zero;
					}
					return new Vector3((LZmzPpaRJzKsMmgXFaIntEpWBkUu > 0) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 1) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 2) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA : 0f);
				}
			}

			Vector3 IControllerTemplateAxis3D.valuePrev
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return Vector3.zero;
					}
					return new Vector3((LZmzPpaRJzKsMmgXFaIntEpWBkUu > 0) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0]).QipEgpANGFNRECYJeVXYyjAujThU : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 1) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1]).QipEgpANGFNRECYJeVXYyjAujThU : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 2) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2]).QipEgpANGFNRECYJeVXYyjAujThU : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.horizontal
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.vertical
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.depth
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2];
				}
			}

			protected QmfaCeyhEhBIrItlYFGzlTUGRjPoA(IControllerTemplate_Internal P_0, int P_1, ControllerTemplateElementType P_2, WWhSPLUXNAxBznMDmErldywOpDjO[] P_3, EsWxHDSqntpFyaXqdUbmApTIfXceA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class wKPtHgJyZJuCpeHndlzMXxByKmBp : ctQFlbjBDyfQhOaQekZUBryfoBENB, IControllerTemplateAxis6D, IControllerTemplateElement
		{
			protected const int rOCfIQDiJjJQxAcDljOmivuoNvGN = 0;

			protected const int SIQEodtBGoFlCbjogOjjVlETcAjI = 1;

			protected const int gAXEfKRnIsNGFtQQptOaOeoBMuuM = 2;

			protected const int ZJEuQgEcLlJHpJgzComSAXQkRwTA = 3;

			protected const int CPTGRlhAwUggLgjlYZeWAXjWaNRKA = 4;

			protected const int VEsaxhuHfbtlyqmPuRVKyqsGvldd = 5;

			protected const int noLpNKzyBPIcdmrsswfRwFPgakGh = 6;

			Vector3 IControllerTemplateAxis6D.position
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return Vector3.zero;
					}
					return new Vector3((LZmzPpaRJzKsMmgXFaIntEpWBkUu > 0) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 1) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 2) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.positionPrev
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return Vector3.zero;
					}
					return new Vector3((LZmzPpaRJzKsMmgXFaIntEpWBkUu > 0) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0]).QipEgpANGFNRECYJeVXYyjAujThU : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 1) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1]).QipEgpANGFNRECYJeVXYyjAujThU : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 2) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2]).QipEgpANGFNRECYJeVXYyjAujThU : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotation
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return Vector3.zero;
					}
					return new Vector3((LZmzPpaRJzKsMmgXFaIntEpWBkUu > 3) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[3]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 4) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[4]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 5) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[5]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotationPrev
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return Vector3.zero;
					}
					return new Vector3((LZmzPpaRJzKsMmgXFaIntEpWBkUu > 3) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[3]).QipEgpANGFNRECYJeVXYyjAujThU : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 4) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[4]).QipEgpANGFNRECYJeVXYyjAujThU : 0f, (LZmzPpaRJzKsMmgXFaIntEpWBkUu > 5) ? ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[5]).QipEgpANGFNRECYJeVXYyjAujThU : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionX
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionY
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionZ
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationX
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[3];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationY
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[4];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationZ
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[5];
				}
			}

			protected wKPtHgJyZJuCpeHndlzMXxByKmBp(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, WWhSPLUXNAxBznMDmErldywOpDjO[] P_3, EsWxHDSqntpFyaXqdUbmApTIfXceA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal sealed class ktHgyoRskvFytXMMFWaSiSifRSKg : QmfaCeyhEhBIrItlYFGzlTUGRjPoA, IControllerTemplateStick, IControllerTemplateElement
		{
			private const int BZUPaFXqaChsgPIPKUMgujzqlHHf = 3;

			IControllerTemplateAxis IControllerTemplateStick.rotation
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2];
				}
			}

			private ktHgyoRskvFytXMMFWaSiSifRSKg(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WWhSPLUXNAxBznMDmErldywOpDjO[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Stick, P_4, WWhSPLUXNAxBznMDmErldywOpDjO.qWSETbTAunrKuuHohuzsfADdWJwm(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			public ktHgyoRskvFytXMMFWaSiSifRSKg(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_4, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_5, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_6)
				: this(P_0, P_1, P_2, P_3, new WWhSPLUXNAxBznMDmErldywOpDjO[3] { P_4, P_5, P_6 })
			{
			}
		}

		internal sealed class lJsxXShcJSuvPmhrandNlzBqoSzU : CwhbPZHGtRTRAhMwEAJUBVohXKmVb, IControllerTemplateThumbStick, IControllerTemplateElement
		{
			private const int KFBEjYqPZcLneVwfnUAboWaZwGZH = 2;

			private const int YIjwATOqUeavYPkagbXCvUfoGBtN = 3;

			IControllerTemplateButton IControllerTemplateThumbStick.press
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2];
				}
			}

			private lJsxXShcJSuvPmhrandNlzBqoSzU(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WWhSPLUXNAxBznMDmErldywOpDjO[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.ThumbStick, P_4, WWhSPLUXNAxBznMDmErldywOpDjO.qWSETbTAunrKuuHohuzsfADdWJwm(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal lJsxXShcJSuvPmhrandNlzBqoSzU(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_4, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_5, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_6)
				: this(P_0, P_1, P_2, P_3, new WWhSPLUXNAxBznMDmErldywOpDjO[3] { P_4, P_5, P_6 })
			{
			}
		}

		internal sealed class RVNERBKOgFmqqBwCCjGQXuNDdavtA : ctQFlbjBDyfQhOaQekZUBryfoBENB, IControllerTemplateDPad, IControllerTemplateElement
		{
			private const int iznrjDGatXdcPwtkOXBCQsHJtVjG = 0;

			private const int ozQMMbWEWoUsZSLQCIAgcMaQLVWl = 1;

			private const int YQYmFrFDToVdGZqbleVIGdaaEIcpA = 2;

			private const int FOlKaYpFiKQtMGPNMLlclnfZaEUCA = 3;

			private const int kLqBMVcXzxXFtSYckXiYgJQDAYeXA = 4;

			private const int zYiMUKUHaFbvYpxiwmVMRiBzTJNg = 5;

			Vector2 IControllerTemplateDPad.value
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA + ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA * -1f, -1f, 1f), MathTools.Clamp(((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[3]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA * -1f + ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA, -1f, 1f));
				}
			}

			Vector2 IControllerTemplateDPad.valuePrev
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0]).QipEgpANGFNRECYJeVXYyjAujThU + ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2]).QipEgpANGFNRECYJeVXYyjAujThU * -1f, -1f, 1f), MathTools.Clamp(((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[3]).QipEgpANGFNRECYJeVXYyjAujThU * -1f + ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1]).QipEgpANGFNRECYJeVXYyjAujThU, -1f, 1f));
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.up
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.right
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.down
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.left
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[3];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.press
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[4];
				}
			}

			private RVNERBKOgFmqqBwCCjGQXuNDdavtA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WWhSPLUXNAxBznMDmErldywOpDjO[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.DPad, P_4, WWhSPLUXNAxBznMDmErldywOpDjO.qWSETbTAunrKuuHohuzsfADdWJwm(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal RVNERBKOgFmqqBwCCjGQXuNDdavtA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_4, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_5, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_6, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_7, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_8)
				: this(P_0, P_1, P_2, P_3, new WWhSPLUXNAxBznMDmErldywOpDjO[5] { P_4, P_5, P_6, P_7, P_8 })
			{
			}
		}

		internal sealed class IlxGwvJfOHfDNCpogakPlQYNcTRGA : ctQFlbjBDyfQhOaQekZUBryfoBENB, IControllerTemplateThrottle, IControllerTemplateElement
		{
			private const int kJcSWkFAWZrzBPjKrfzaqQiRfGhq = 0;

			private const int ywLKSAmrqSszmYDKhiEVrFYsUFov = 1;

			private const int inFPvdYkJvNPiFJoDlcxKZOYsSiU = 2;

			float IControllerTemplateThrottle.value
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return 0f;
					}
					return ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA;
				}
			}

			float IControllerTemplateThrottle.valuePrev
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return 0f;
					}
					return ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0]).QipEgpANGFNRECYJeVXYyjAujThU;
				}
			}

			IControllerTemplateAxis IControllerTemplateThrottle.throttle
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0];
				}
			}

			IControllerTemplateButton IControllerTemplateThrottle.minDetent
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1];
				}
			}

			private IlxGwvJfOHfDNCpogakPlQYNcTRGA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WWhSPLUXNAxBznMDmErldywOpDjO[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Throttle, P_4, WWhSPLUXNAxBznMDmErldywOpDjO.qWSETbTAunrKuuHohuzsfADdWJwm(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 2)
				{
					throw new ArgumentException("elements.Length must be " + 2);
				}
			}

			internal IlxGwvJfOHfDNCpogakPlQYNcTRGA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_4, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_5)
				: this(P_0, P_1, P_2, P_3, new WWhSPLUXNAxBznMDmErldywOpDjO[2] { P_4, P_5 })
			{
			}
		}

		internal sealed class vOLYtXyYaxKGxhGZtDyEBOmEjrXB : ctQFlbjBDyfQhOaQekZUBryfoBENB, IControllerTemplateHat, IControllerTemplateElement
		{
			private const int vrinVvZLlRMEWAwDuREUkRxrgzRN = 0;

			private const int XfDObqILRsQQZgJBFcNphUsJNUnx = 1;

			private const int JhDLJaSPlMCGzgDnUQpdlnzJzauV = 2;

			private const int KZxFoMhuTqNFYhqHGPyqKEBIiVvRb = 3;

			private const int sYyXrzfDudyyrICVreErBdmVyhHwA = 4;

			private const int ARrjcNHtxMdrzQWpPfGckhYuBUtT = 5;

			private const int CuYqhyultIgcwDNfhHwUrEBTpvwv = 6;

			private const int bwyyIUEmTUEHHhGWilYwTRyUIMEmA = 7;

			private const int GqaotydcSKynwMncLFFxVwFsghFb = 8;

			Vector2 IControllerTemplateHat.value
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA;
					result.x += ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA;
					result.y -= ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[4]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA;
					result.x -= ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[6]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA;
					float num = ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA;
					float num2 = ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[3]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA;
					float num3 = ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[5]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA;
					float num4 = ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[7]).CKrbLyIKZDEVVyyBGqxjUNvBmCQWA;
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
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0]).QipEgpANGFNRECYJeVXYyjAujThU;
					result.x += ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2]).QipEgpANGFNRECYJeVXYyjAujThU;
					result.y -= ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[4]).QipEgpANGFNRECYJeVXYyjAujThU;
					result.x -= ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[6]).QipEgpANGFNRECYJeVXYyjAujThU;
					float num = ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1]).QipEgpANGFNRECYJeVXYyjAujThU;
					float num2 = ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[3]).QipEgpANGFNRECYJeVXYyjAujThU;
					float num3 = ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[5]).QipEgpANGFNRECYJeVXYyjAujThU;
					float num4 = ((SfeECIiDOhaKpDDOAYbcBLGoqICtB)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[7]).QipEgpANGFNRECYJeVXYyjAujThU;
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
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upRight
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.right
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[2];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downRight
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[3];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.down
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[4];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downLeft
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[5];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.left
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[6];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upLeft
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateButton)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[7];
				}
			}

			private vOLYtXyYaxKGxhGZtDyEBOmEjrXB(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WWhSPLUXNAxBznMDmErldywOpDjO[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Hat, P_4, WWhSPLUXNAxBznMDmErldywOpDjO.qWSETbTAunrKuuHohuzsfADdWJwm(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 8)
				{
					throw new ArgumentException("elements.Length must be " + 8);
				}
			}

			internal vOLYtXyYaxKGxhGZtDyEBOmEjrXB(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_4, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_5, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_6, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_7, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_8, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_9, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_10, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_11)
				: this(P_0, P_1, P_2, P_3, new WWhSPLUXNAxBznMDmErldywOpDjO[8] { P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11 })
			{
			}
		}

		internal sealed class dESFPYeqpqzVFHPOWGweDxFWElUfb : CwhbPZHGtRTRAhMwEAJUBVohXKmVb, IControllerTemplateYoke, IControllerTemplateElement
		{
			private const int mgHdknikTIhyeebsDlQhffzPIwEMb = 2;

			IControllerTemplateAxis IControllerTemplateYoke.rotation
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateYoke.pushPull
			{
				get
				{
					if (ReInput._id != jEKyludiiDakDZlKRCWIRRvzLLCG)
					{
						ReInput.CheckInitialized(jEKyludiiDakDZlKRCWIRRvzLLCG);
						return null;
					}
					return (IControllerTemplateAxis)HzvPrHUMoLyoUgjDxlsrPhSMxhjN[1];
				}
			}

			private dESFPYeqpqzVFHPOWGweDxFWElUfb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WWhSPLUXNAxBznMDmErldywOpDjO[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Yoke, P_4, WWhSPLUXNAxBznMDmErldywOpDjO.qWSETbTAunrKuuHohuzsfADdWJwm(P_0, P_1, P_2, P_3))
			{
			}

			internal dESFPYeqpqzVFHPOWGweDxFWElUfb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_4, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_5)
				: this(P_0, P_1, P_2, P_3, new WWhSPLUXNAxBznMDmErldywOpDjO[2] { P_4, P_5 })
			{
			}
		}

		internal sealed class TKXxrVOiWHgHRCInIpAnftnaCiDj : wKPtHgJyZJuCpeHndlzMXxByKmBp, IControllerTemplateStick6D, IControllerTemplateElement
		{
			private const int MffmaZFtwDiscXopkkawgaduvUhk = 6;

			private TKXxrVOiWHgHRCInIpAnftnaCiDj(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, WWhSPLUXNAxBznMDmErldywOpDjO[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Stick6D, P_4, WWhSPLUXNAxBznMDmErldywOpDjO.qWSETbTAunrKuuHohuzsfADdWJwm(P_0, P_1, P_2, P_3))
			{
			}

			internal TKXxrVOiWHgHRCInIpAnftnaCiDj(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_4, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_5, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_6, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_7, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_8, SfeECIiDOhaKpDDOAYbcBLGoqICtB P_9)
				: this(P_0, P_1, P_2, P_3, new WWhSPLUXNAxBznMDmErldywOpDjO[6] { P_4, P_5, P_6, P_7, P_8, P_9 })
			{
			}
		}

		internal class pRnwzxzWcWfRjPOiOqGPREeWlFeo
		{
			public readonly Controller.Element eUkuhwZGEhKbzvsdSFPNQHgbnhdY;

			public readonly IControllerElementTarget hhJPCkQQcDNqHmKEOlntFwjaOQop;

			public bool fGIUJwaJsCZQqEBWOJkUXFDqWnrA
			{
				get
				{
					if (eUkuhwZGEhKbzvsdSFPNQHgbnhdY == null)
					{
						return false;
					}
					switch (eUkuhwZGEhKbzvsdSFPNQHgbnhdY.type)
					{
					case ControllerElementType.Button:
						return (eUkuhwZGEhKbzvsdSFPNQHgbnhdY as Controller.Button).value;
					case ControllerElementType.Axis:
					{
						float value = (eUkuhwZGEhKbzvsdSFPNQHgbnhdY as Controller.Axis).value;
						switch (hhJPCkQQcDNqHmKEOlntFwjaOQop.axisRange)
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

			public bool pvdNHWYkVMXqkvZxiPZABLEdKNrQ
			{
				get
				{
					if (eUkuhwZGEhKbzvsdSFPNQHgbnhdY == null)
					{
						return false;
					}
					switch (eUkuhwZGEhKbzvsdSFPNQHgbnhdY.type)
					{
					case ControllerElementType.Button:
						return (eUkuhwZGEhKbzvsdSFPNQHgbnhdY as Controller.Button).valuePrev;
					case ControllerElementType.Axis:
					{
						float valuePrev = (eUkuhwZGEhKbzvsdSFPNQHgbnhdY as Controller.Axis).valuePrev;
						switch (hhJPCkQQcDNqHmKEOlntFwjaOQop.axisRange)
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

			public bool WOWoSVSGwRnlTpExBCHjwMUCVitV
			{
				get
				{
					if (eUkuhwZGEhKbzvsdSFPNQHgbnhdY == null)
					{
						return false;
					}
					switch (eUkuhwZGEhKbzvsdSFPNQHgbnhdY.type)
					{
					case ControllerElementType.Button:
						return (eUkuhwZGEhKbzvsdSFPNQHgbnhdY as Controller.Button).justPressed;
					case ControllerElementType.Axis:
						if (MathTools.Abs(heaglKnPkrWYIUPLWMkCDiIBGkZCA) > 0.01f && MathTools.Abs(HuAXfLbkLhtmpuWHewRJGjYAanR) <= 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public bool fBNsoTyDZmaqPCfLCFaIVRVKNcQIA
			{
				get
				{
					if (eUkuhwZGEhKbzvsdSFPNQHgbnhdY == null)
					{
						return false;
					}
					switch (eUkuhwZGEhKbzvsdSFPNQHgbnhdY.type)
					{
					case ControllerElementType.Button:
						return (eUkuhwZGEhKbzvsdSFPNQHgbnhdY as Controller.Button).justReleased;
					case ControllerElementType.Axis:
						if (MathTools.Abs(heaglKnPkrWYIUPLWMkCDiIBGkZCA) <= 0.01f && MathTools.Abs(HuAXfLbkLhtmpuWHewRJGjYAanR) > 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public float heaglKnPkrWYIUPLWMkCDiIBGkZCA
			{
				get
				{
					if (eUkuhwZGEhKbzvsdSFPNQHgbnhdY == null)
					{
						return 0f;
					}
					switch (eUkuhwZGEhKbzvsdSFPNQHgbnhdY.type)
					{
					case ControllerElementType.Button:
						if (!(eUkuhwZGEhKbzvsdSFPNQHgbnhdY as Controller.Button).value)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float value = (eUkuhwZGEhKbzvsdSFPNQHgbnhdY as Controller.Axis).value;
						switch (hhJPCkQQcDNqHmKEOlntFwjaOQop.axisRange)
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

			public float HuAXfLbkLhtmpuWHewRJGjYAanR
			{
				get
				{
					if (eUkuhwZGEhKbzvsdSFPNQHgbnhdY == null)
					{
						return 0f;
					}
					switch (eUkuhwZGEhKbzvsdSFPNQHgbnhdY.type)
					{
					case ControllerElementType.Button:
						if (!(eUkuhwZGEhKbzvsdSFPNQHgbnhdY as Controller.Button).valuePrev)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float valuePrev = (eUkuhwZGEhKbzvsdSFPNQHgbnhdY as Controller.Axis).valuePrev;
						switch (hhJPCkQQcDNqHmKEOlntFwjaOQop.axisRange)
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

			public pRnwzxzWcWfRjPOiOqGPREeWlFeo(IControllerElementTarget P_0, Controller.Element P_1)
			{
				eUkuhwZGEhKbzvsdSFPNQHgbnhdY = P_1;
				hhJPCkQQcDNqHmKEOlntFwjaOQop = P_0;
			}

			public static pRnwzxzWcWfRjPOiOqGPREeWlFeo WlOGOIeAzWDOrtTsvkRXevAfnYjPb()
			{
				return new pRnwzxzWcWfRjPOiOqGPREeWlFeo(XuJpBJvxrqVOEMAPQQDPCLYEUJbk.LMxcmGJjdPVYSyQoCbYjlrUbIUQQ(), null);
			}
		}

		internal class RIlfAhFAiHguHKRVCvaLjBGmQLepA
		{
			public readonly Controller HaVaVJGxpuaTCVxRlXoqVZURVrMFA;

			public readonly IHardwareControllerTemplateMap_Internal cJkHFLiFbffeVDWSfxPtSDZmATUM;

			public RIlfAhFAiHguHKRVCvaLjBGmQLepA(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				HaVaVJGxpuaTCVxRlXoqVZURVrMFA = P_0;
				cJkHFLiFbffeVDWSfxPtSDZmATUM = P_1;
			}
		}

		private sealed class eZbbyjJwvhNhRsGhorDZeTUlGReS
		{
			[Serializable]
			private sealed class yjBUOnzHWqPSVszEXnyMFzLkkYoc
			{
				public static readonly yjBUOnzHWqPSVszEXnyMFzLkkYoc _003C_003E9 = new yjBUOnzHWqPSVszEXnyMFzLkkYoc();

				public static Func<EsWxHDSqntpFyaXqdUbmApTIfXceA, EsWxHDSqntpFyaXqdUbmApTIfXceA, bool> _003C_003E9__4_0;

				internal bool SPUDPbjNGOfvOkHIZQmKpgbgQorsA(EsWxHDSqntpFyaXqdUbmApTIfXceA P_0, EsWxHDSqntpFyaXqdUbmApTIfXceA P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					return P_0.EKBjmhhLPylzdjWOjllvxzJdReJi(P_1, false);
				}
			}

			private static eZbbyjJwvhNhRsGhorDZeTUlGReS eEGgBSaFZEWAiSQymMBpSFiilYgT;

			private readonly global::QTCiASUCDvHtbdUBoOAdSPzWjRqL<EsWxHDSqntpFyaXqdUbmApTIfXceA> tWhXPvmHeZRNaKTbYGiCBJBrKUdo;

			private static eZbbyjJwvhNhRsGhorDZeTUlGReS qqQEbMgjkaoNfboJKFbQpUOsXkdIB
			{
				get
				{
					if (eEGgBSaFZEWAiSQymMBpSFiilYgT != null)
					{
						return eEGgBSaFZEWAiSQymMBpSFiilYgT;
					}
					eEGgBSaFZEWAiSQymMBpSFiilYgT = new eZbbyjJwvhNhRsGhorDZeTUlGReS();
					eEGgBSaFZEWAiSQymMBpSFiilYgT.HZqrxNKtoNvjncjBVqLZqFbiWTPD();
					return eEGgBSaFZEWAiSQymMBpSFiilYgT;
				}
			}

			private eZbbyjJwvhNhRsGhorDZeTUlGReS()
			{
				tWhXPvmHeZRNaKTbYGiCBJBrKUdo = new global::QTCiASUCDvHtbdUBoOAdSPzWjRqL<EsWxHDSqntpFyaXqdUbmApTIfXceA>(yjBUOnzHWqPSVszEXnyMFzLkkYoc._003C_003E9.SPUDPbjNGOfvOkHIZQmKpgbgQorsA);
			}

			private void HZqrxNKtoNvjncjBVqLZqFbiWTPD()
			{
				ReInput.ShutDownEvent += eEGgBSaFZEWAiSQymMBpSFiilYgT.ianqhhIEYTGiDCbozeeWLjSsJulFb;
			}

			private void ianqhhIEYTGiDCbozeeWLjSsJulFb()
			{
				if (eEGgBSaFZEWAiSQymMBpSFiilYgT == this)
				{
					eEGgBSaFZEWAiSQymMBpSFiilYgT = null;
				}
				ReInput.ShutDownEvent -= ianqhhIEYTGiDCbozeeWLjSsJulFb;
			}

			public static EsWxHDSqntpFyaXqdUbmApTIfXceA QXRrpQzzMQKAcaEQJypZDnnMBUPDA(EsWxHDSqntpFyaXqdUbmApTIfXceA P_0)
			{
				Bytes20 bytes = ((P_0.TMHlvqHxBpCGUAQoFpDnAxiNvTqy is nxtXQXyUjBrPcJJGFRavdiSqQhMF nxtXQXyUjBrPcJJGFRavdiSqQhMF2) ? nxtXQXyUjBrPcJJGFRavdiSqQhMF2.EyiOjXznsdhojSKqnJBSqQJGOCGl.hash : default(Bytes20));
				return qqQEbMgjkaoNfboJKFbQpUOsXkdIB.tWhXPvmHeZRNaKTbYGiCBJBrKUdo.jmbCpDDBCpCHqKMftVWBFAAjqwiI(bytes, P_0);
			}

			public static bool APNBvKVJhmvJGzLzvxqEXdVPyXiu(EsWxHDSqntpFyaXqdUbmApTIfXceA P_0, out EsWxHDSqntpFyaXqdUbmApTIfXceA P_1)
			{
				Bytes20 bytes = ((P_0.TMHlvqHxBpCGUAQoFpDnAxiNvTqy is nxtXQXyUjBrPcJJGFRavdiSqQhMF nxtXQXyUjBrPcJJGFRavdiSqQhMF2) ? nxtXQXyUjBrPcJJGFRavdiSqQhMF2.EyiOjXznsdhojSKqnJBSqQJGOCGl.hash : default(Bytes20));
				return qqQEbMgjkaoNfboJKFbQpUOsXkdIB.tWhXPvmHeZRNaKTbYGiCBJBrKUdo.XeiOWkonFmtJDikoHyyLMWSuTCbj(bytes, P_0, out P_1);
			}

			public static void eWZypRwmDBCaVzBiNbNMAxjZnfTdA(EsWxHDSqntpFyaXqdUbmApTIfXceA P_0)
			{
				Bytes20 bytes = ((P_0.TMHlvqHxBpCGUAQoFpDnAxiNvTqy is nxtXQXyUjBrPcJJGFRavdiSqQhMF nxtXQXyUjBrPcJJGFRavdiSqQhMF2) ? nxtXQXyUjBrPcJJGFRavdiSqQhMF2.EyiOjXznsdhojSKqnJBSqQJGOCGl.hash : default(Bytes20));
				qqQEbMgjkaoNfboJKFbQpUOsXkdIB.tWhXPvmHeZRNaKTbYGiCBJBrKUdo.oKikmsntPJTPfJPjjdAXQftayNjT(bytes, P_0);
			}
		}

		private const string jOzyZvvFpUJPcPeqQOOHOiiEyWgr = "controller/template";

		private string RxbfJsiwmUtSCdsLmGbiDrOXgrkb;

		private string PiSeGhWdfOxPFNlOQhSJNKnbJsSL;

		private int eYiODNaTdtDDAJhmuDqDbSHkNJvc;

		private readonly Guid zWCZwvBUOLwagfjkedjHgWmLzpfhA;

		private readonly DeviceLocalizationInfo iAjwILNAOXRNWgILWHcJBTzsbLygb;

		private readonly Controller feKUnzDBqYHqbMBUPjUmYCvNdDMY;

		private readonly ADictionary<int, IControllerTemplateElement> ZInEVFaIxPdNXNoxVqAgIpfxFSOab;

		private readonly ADictionary<string, IControllerTemplateElement> kwQcCVXzWvoCSAPBQQGFJwbyzivd;

		private IControllerTemplateElement[] tbODhvwGUkLlPxNRSPSoyoKyDsWEA;

		private ReadOnlyCollection<IControllerTemplateElement> JEKTJVXcYRNTBWPOwlOnSDNkGJTH;

		private readonly pdfeDVjdjwArmqtCcVAoNpExpqyM XLgzQRbvfgvLwWkeaGOroatVMgjQ;

		private readonly int AFKhIzCYCVjMDWtRgJsbGNkaUHgPb;

		internal DeviceLocalizationInfo AmxBVONPokGzKLTtdcecuElPVXUm => iAjwILNAOXRNWgILWHcJBTzsbLygb;

		DeviceLocalizationInfo IControllerTemplate_Internal.deviceLocalizationInfo => iAjwILNAOXRNWgILWHcJBTzsbLygb;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != AFKhIzCYCVjMDWtRgJsbGNkaUHgPb)
				{
					ReInput.CheckInitialized(AFKhIzCYCVjMDWtRgJsbGNkaUHgPb);
					return null;
				}
				return feKUnzDBqYHqbMBUPjUmYCvNdDMY;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != AFKhIzCYCVjMDWtRgJsbGNkaUHgPb)
				{
					ReInput.CheckInitialized(AFKhIzCYCVjMDWtRgJsbGNkaUHgPb);
					return null;
				}
				if (!LocalizationManager.isEnabled)
				{
					return RxbfJsiwmUtSCdsLmGbiDrOXgrkb;
				}
				return XLgzQRbvfgvLwWkeaGOroatVMgjQ.HKQoqutKkgeGtFcRmtcKMQqgsDoY;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != AFKhIzCYCVjMDWtRgJsbGNkaUHgPb)
				{
					ReInput.CheckInitialized(AFKhIzCYCVjMDWtRgJsbGNkaUHgPb);
					return Guid.Empty;
				}
				return zWCZwvBUOLwagfjkedjHgWmLzpfhA;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != AFKhIzCYCVjMDWtRgJsbGNkaUHgPb)
				{
					ReInput.CheckInitialized(AFKhIzCYCVjMDWtRgJsbGNkaUHgPb);
					return null;
				}
				return JEKTJVXcYRNTBWPOwlOnSDNkGJTH;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != AFKhIzCYCVjMDWtRgJsbGNkaUHgPb)
				{
					ReInput.CheckInitialized(AFKhIzCYCVjMDWtRgJsbGNkaUHgPb);
					return 0;
				}
				return tbODhvwGUkLlPxNRSPSoyoKyDsWEA.Length;
			}
		}

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.keyCategory => "controller/template";

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.scriptingName => string.Empty;

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.nonLocalizedDescriptiveName
		{
			get
			{
				return RxbfJsiwmUtSCdsLmGbiDrOXgrkb;
			}
			set
			{
				RxbfJsiwmUtSCdsLmGbiDrOXgrkb = value;
			}
		}

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.key => PiSeGhWdfOxPFNlOQhSJNKnbJsSL;

		int sZLAxvZSvDRmVjMjTVRhHfujppQp.autoGeneratedValueFlags
		{
			get
			{
				return eYiODNaTdtDDAJhmuDqDbSHkNJvc;
			}
			set
			{
				eYiODNaTdtDDAJhmuDqDbSHkNJvc = value;
			}
		}

		protected ControllerTemplate(object P_0)
			: this((RIlfAhFAiHguHKRVCvaLjBGmQLepA)P_0)
		{
		}

		private ControllerTemplate(RIlfAhFAiHguHKRVCvaLjBGmQLepA P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (P_0.HaVaVJGxpuaTCVxRlXoqVZURVrMFA == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (P_0.cJkHFLiFbffeVDWSfxPtSDZmATUM == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			AFKhIzCYCVjMDWtRgJsbGNkaUHgPb = ReInput.id;
			feKUnzDBqYHqbMBUPjUmYCvNdDMY = P_0.HaVaVJGxpuaTCVxRlXoqVZURVrMFA;
			IHardwareControllerTemplateMap_Internal cJkHFLiFbffeVDWSfxPtSDZmATUM = P_0.cJkHFLiFbffeVDWSfxPtSDZmATUM;
			RxbfJsiwmUtSCdsLmGbiDrOXgrkb = cJkHFLiFbffeVDWSfxPtSDZmATUM.name;
			PiSeGhWdfOxPFNlOQhSJNKnbJsSL = cJkHFLiFbffeVDWSfxPtSDZmATUM.typeKey;
			zWCZwvBUOLwagfjkedjHgWmLzpfhA = cJkHFLiFbffeVDWSfxPtSDZmATUM.typeGuid;
			iAjwILNAOXRNWgILWHcJBTzsbLygb = new DeviceLocalizationInfo(feKUnzDBqYHqbMBUPjUmYCvNdDMY.type, true, zWCZwvBUOLwagfjkedjHgWmLzpfhA, new List<string> { cJkHFLiFbffeVDWSfxPtSDZmATUM.typeKey }, null);
			iAjwILNAOXRNWgILWHcJBTzsbLygb.FinishRuntimeSetup();
			XLgzQRbvfgvLwWkeaGOroatVMgjQ = pdfeDVjdjwArmqtCcVAoNpExpqyM.FFjXRWNznybaCatfhwLUCHTjGTKc(this);
			int elementIdentifierCount = cJkHFLiFbffeVDWSfxPtSDZmATUM.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = cJkHFLiFbffeVDWSfxPtSDZmATUM.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						wyBGNVjftIezdumZCvkmiqVKqZjAA wyBGNVjftIezdumZCvkmiqVKqZjAA3 = cJkHFLiFbffeVDWSfxPtSDZmATUM.GetAxisTarget(feKUnzDBqYHqbMBUPjUmYCvNdDMY, templateElementIdentifier.id) ?? wyBGNVjftIezdumZCvkmiqVKqZjAA.tveLONDaoWrbqwSWMitxVOABUhik(ControllerTemplateElementType.Axis);
						xAkBApivrHTOhdxWlpyngYexmtDL item2 = new xAkBApivrHTOhdxWlpyngYexmtDL(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, wyBGNVjftIezdumZCvkmiqVKqZjAA3, VchyIAEQxfMKKgKoveJvsJALtrXC(feKUnzDBqYHqbMBUPjUmYCvNdDMY, wyBGNVjftIezdumZCvkmiqVKqZjAA3));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						wyBGNVjftIezdumZCvkmiqVKqZjAA wyBGNVjftIezdumZCvkmiqVKqZjAA2 = cJkHFLiFbffeVDWSfxPtSDZmATUM.GetButtonTarget(feKUnzDBqYHqbMBUPjUmYCvNdDMY, templateElementIdentifier.id) ?? wyBGNVjftIezdumZCvkmiqVKqZjAA.tveLONDaoWrbqwSWMitxVOABUhik(ControllerTemplateElementType.Button);
						MTEBqRxAMBvojkGPkmRbPcgaPDGD item = new MTEBqRxAMBvojkGPkmRbPcgaPDGD(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, wyBGNVjftIezdumZCvkmiqVKqZjAA2, MTbzkneFHqbgFcayIJDEtImElFJu(feKUnzDBqYHqbMBUPjUmYCvNdDMY, wyBGNVjftIezdumZCvkmiqVKqZjAA2));
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
				IControllerTemplateElementIdentifier templateElementIdentifier2 = cJkHFLiFbffeVDWSfxPtSDZmATUM.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = cJkHFLiFbffeVDWSfxPtSDZmATUM.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				WWhSPLUXNAxBznMDmErldywOpDjO wWhSPLUXNAxBznMDmErldywOpDjO;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					wWhSPLUXNAxBznMDmErldywOpDjO = new lJsxXShcJSuvPmhrandNlzBqoSzU(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping5 != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping5.eid_axisX) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this), (mapping5 != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping5.eid_axisY) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this), (mapping5 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping5.eid_button) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					wWhSPLUXNAxBznMDmErldywOpDjO = new RVNERBKOgFmqqBwCCjGQXuNDdavtA(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping3 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping3.eid_up) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this), (mapping3 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping3.eid_right) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this), (mapping3 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping3.eid_down) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this), (mapping3 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping3.eid_left) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this), (mapping3 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping3.eid_press) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					wWhSPLUXNAxBznMDmErldywOpDjO = new ktHgyoRskvFytXMMFWaSiSifRSKg(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping2 != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping2.eid_axisX) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this), (mapping2 != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping2.eid_axisY) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this), (mapping2 != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping2.eid_axisZ) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					wWhSPLUXNAxBznMDmErldywOpDjO = new IlxGwvJfOHfDNCpogakPlQYNcTRGA(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping6 != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping6.eid_axis) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this), (mapping6 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping6.eid_minDetent) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					wWhSPLUXNAxBznMDmErldywOpDjO = new vOLYtXyYaxKGxhGZtDyEBOmEjrXB(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping7 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping7.eid_up) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this), (mapping7 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping7.eid_upRight) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this), (mapping7 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping7.eid_right) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this), (mapping7 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping7.eid_downRight) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this), (mapping7 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping7.eid_down) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this), (mapping7 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping7.eid_downLeft) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this), (mapping7 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping7.eid_left) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this), (mapping7 != null) ? KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(this, aDictionary, mapping7.eid_upLeft) : MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					wWhSPLUXNAxBznMDmErldywOpDjO = new dESFPYeqpqzVFHPOWGweDxFWElUfb(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping4 != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping4.eid_axisX) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this), (mapping4 != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping4.eid_axisZ) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					wWhSPLUXNAxBznMDmErldywOpDjO = new TKXxrVOiWHgHRCInIpAnftnaCiDj(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping.eid_positionX) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this), (mapping != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping.eid_positionY) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this), (mapping != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping.eid_positionZ) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this), (mapping != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping.eid_rotationX) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this), (mapping != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping.eid_rotationY) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this), (mapping != null) ? yvTJBMcCuqwsWNDIWJvlNUwvNFld(this, aDictionary, mapping.eid_rotationZ) : xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (wWhSPLUXNAxBznMDmErldywOpDjO != null)
				{
					list4.Add(wWhSPLUXNAxBznMDmErldywOpDjO);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			tbODhvwGUkLlPxNRSPSoyoKyDsWEA = list.ToArray();
			ZInEVFaIxPdNXNoxVqAgIpfxFSOab = aDictionary;
			kwQcCVXzWvoCSAPBQQGFJwbyzivd = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < tbODhvwGUkLlPxNRSPSoyoKyDsWEA.Length; num++)
			{
				if (!(cJkHFLiFbffeVDWSfxPtSDZmATUM.GetTemplateElementIdentifierById(tbODhvwGUkLlPxNRSPSoyoKyDsWEA[num].id) is IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor))
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
							kwQcCVXzWvoCSAPBQQGFJwbyzivd.Add(text, tbODhvwGUkLlPxNRSPSoyoKyDsWEA[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + RxbfJsiwmUtSCdsLmGbiDrOXgrkb + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			JEKTJVXcYRNTBWPOwlOnSDNkGJTH = new ReadOnlyCollection<IControllerTemplateElement>(tbODhvwGUkLlPxNRSPSoyoKyDsWEA);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			if (!ZInEVFaIxPdNXNoxVqAgIpfxFSOab.TryGetValue(id, out var value))
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
			if (ReInput._id != AFKhIzCYCVjMDWtRgJsbGNkaUHgPb)
			{
				ReInput.CheckInitialized(AFKhIzCYCVjMDWtRgJsbGNkaUHgPb);
				return null;
			}
			return GetElement(id);
		}

		T IControllerTemplate.GetElement<T>(int id)
		{
			if (ReInput._id != AFKhIzCYCVjMDWtRgJsbGNkaUHgPb)
			{
				ReInput.CheckInitialized(AFKhIzCYCVjMDWtRgJsbGNkaUHgPb);
				return null;
			}
			return GetElement<T>(id);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget find, IList<ControllerTemplateElementTarget> results)
		{
			if (ReInput._id != AFKhIzCYCVjMDWtRgJsbGNkaUHgPb)
			{
				ReInput.CheckInitialized(AFKhIzCYCVjMDWtRgJsbGNkaUHgPb);
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
			for (int i = 0; i < tbODhvwGUkLlPxNRSPSoyoKyDsWEA.Length; i++)
			{
				if (InputTools.IsMappableType(tbODhvwGUkLlPxNRSPSoyoKyDsWEA[i].type))
				{
					num += (tbODhvwGUkLlPxNRSPSoyoKyDsWEA[i] as IControllerTemplateElement_Internal).GetElementTargets(find, ref results);
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

		private static IList<pRnwzxzWcWfRjPOiOqGPREeWlFeo> VchyIAEQxfMKKgKoveJvsJALtrXC(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			if (P_1.splitAxis)
			{
				IList<pRnwzxzWcWfRjPOiOqGPREeWlFeo> list = null;
				bool flag = false;
				if (P_1.positiveTarget != null)
				{
					Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					if (elementById != null)
					{
						ListTools.AddAndCreateList(ref list, new pRnwzxzWcWfRjPOiOqGPREeWlFeo(P_1.positiveTarget, elementById));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, pRnwzxzWcWfRjPOiOqGPREeWlFeo.WlOGOIeAzWDOrtTsvkRXevAfnYjPb());
				}
				flag = false;
				if (P_1.negativeTarget != null)
				{
					Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
					if (elementById2 != null)
					{
						ListTools.AddAndCreateList(ref list, new pRnwzxzWcWfRjPOiOqGPREeWlFeo(P_1.negativeTarget, elementById2));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, pRnwzxzWcWfRjPOiOqGPREeWlFeo.WlOGOIeAzWDOrtTsvkRXevAfnYjPb());
				}
				return list;
			}
			return bKDoOhfYEgBJdmwGSGrgELtOJgRB(P_0, P_1.fullTarget);
		}

		private static IList<pRnwzxzWcWfRjPOiOqGPREeWlFeo> MTbzkneFHqbgFcayIJDEtImElFJu(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return bKDoOhfYEgBJdmwGSGrgELtOJgRB(P_0, P_1.target);
		}

		private static IList<pRnwzxzWcWfRjPOiOqGPREeWlFeo> bKDoOhfYEgBJdmwGSGrgELtOJgRB(Controller P_0, IControllerElementTarget P_1)
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
			return new List<pRnwzxzWcWfRjPOiOqGPREeWlFeo>
			{
				new pRnwzxzWcWfRjPOiOqGPREeWlFeo(P_1, elementById)
			};
		}

		private static IControllerTemplateElement SknOKldArIMEYYwFIWFdTPEHIsFZ(List<IControllerTemplateElement> P_0, int P_1)
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

		private static SfeECIiDOhaKpDDOAYbcBLGoqICtB yvTJBMcCuqwsWNDIWJvlNUwvNFld(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is SfeECIiDOhaKpDDOAYbcBLGoqICtB result))
			{
				return xAkBApivrHTOhdxWlpyngYexmtDL.cYNankYOxtzTTFNplCiljtJybqOEA(P_0);
			}
			return result;
		}

		private static SfeECIiDOhaKpDDOAYbcBLGoqICtB KyhDCeJYUCUhMuZHQaaOtDbNOwYKA(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is SfeECIiDOhaKpDDOAYbcBLGoqICtB result))
			{
				return MTEBqRxAMBvojkGPkmRbPcgaPDGD.PhpSrWwUrGopgHCiwTaGYkDWtvbN(P_0);
			}
			return result;
		}
	}
}
