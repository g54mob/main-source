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
	public abstract class ControllerTemplate : IControllerTemplate, IControllerTemplate_Internal, LnhaMJXLiFbdSGpizhhMTtFDjtXy
	{
		internal abstract class jZLyafAnMOLOoKpQSmPItlFuvDau : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate QYqpCXwdPPeEGlJatGxkiNbMmLEMA;

			private readonly int VDZigrONXnCIBDzbXMvsDjzGoajsA;

			private readonly ControllerTemplateElementType RkoGwBgCJhEMYfolIuyETYERiOSUB;

			protected readonly int QfuXZUtxiNvCSgHNpenlBEATHLZP;

			protected readonly pfetedQbitdObLxnJcXDFUggaTfnA VAoLRWWfhswWLAGWjWqdLgIneJUp;

			int IControllerTemplateElement.id
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return -1;
					}
					return VDZigrONXnCIBDzbXMvsDjzGoajsA;
				}
			}

			string IControllerTemplateElement.descriptiveName
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return VAoLRWWfhswWLAGWjWqdLgIneJUp.PtvEiRywqMLUHZiGMBDrPChiQetC;
				}
			}

			internal string VPSlBcGFvRzrNwDYhFHPTSSXbsUv => VAoLRWWfhswWLAGWjWqdLgIneJUp.nonLocalizedDescriptiveName;

			ControllerTemplateElementType IControllerTemplateElement.type
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return ControllerTemplateElementType.Axis;
					}
					return RkoGwBgCJhEMYfolIuyETYERiOSUB;
				}
			}

			IControllerTemplate IControllerTemplateElement_Internal.parent => QYqpCXwdPPeEGlJatGxkiNbMmLEMA;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected jZLyafAnMOLOoKpQSmPItlFuvDau(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, pfetedQbitdObLxnJcXDFUggaTfnA P_3)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_3 == null)
				{
					throw new ArgumentNullException("localizedElement");
				}
				QYqpCXwdPPeEGlJatGxkiNbMmLEMA = P_0;
				VDZigrONXnCIBDzbXMvsDjzGoajsA = P_1;
				RkoGwBgCJhEMYfolIuyETYERiOSUB = P_2;
				QfuXZUtxiNvCSgHNpenlBEATHLZP = ReInput.id;
				VAoLRWWfhswWLAGWjWqdLgIneJUp = P_3;
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);

			protected static pfetedQbitdObLxnJcXDFUggaTfnA ZxyHqXBOhlNFnDsxTePZdowJBNpV(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3)
			{
				return TMXaZTLvmrmBSTGaIJfaeIdTpPjn.nxdnMgrMLELVnRKXvcNwHbUufWEAA(new pfetedQbitdObLxnJcXDFUggaTfnA(NpbxdhuOyJUUZEdkMJOQrPzqXjdt.EjayBJbchJgvWiZDzQupbHNumgifb(ILKhcCJzrmtoMHIdzHgcKloPCkpIA.ControllerTemplate, jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Unknown, jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3));
			}
		}

		internal abstract class rbWKVoSjvbbciktWZPfQsLeJlfbWA : jZLyafAnMOLOoKpQSmPItlFuvDau
		{
			protected readonly int KIMQTzJAHpfEDimoxOkbotOSywjLA;

			protected readonly QETzMRjzzYQYeaadskeuXsXmfBnU[] hdwTFdntxyWUcJPpSNIdGCOlvRmf;

			bool jZLyafAnMOLOoKpQSmPItlFuvDau.exists
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return false;
					}
					if (hdwTFdntxyWUcJPpSNIdGCOlvRmf == null)
					{
						return false;
					}
					for (int i = 0; i < hdwTFdntxyWUcJPpSNIdGCOlvRmf.Length; i++)
					{
						if (hdwTFdntxyWUcJPpSNIdGCOlvRmf[i].VxOcTYDQTlLooMiqilroKuPNQlkp != null)
						{
							return true;
						}
					}
					return false;
				}
			}

			protected rbWKVoSjvbbciktWZPfQsLeJlfbWA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, IList<QETzMRjzzYQYeaadskeuXsXmfBnU> P_3, pfetedQbitdObLxnJcXDFUggaTfnA P_4)
				: base(P_0, P_1, P_2, P_4)
			{
				hdwTFdntxyWUcJPpSNIdGCOlvRmf = ((P_3 != null) ? ListTools.ToArray(P_3) : null);
				KIMQTzJAHpfEDimoxOkbotOSywjLA = ((hdwTFdntxyWUcJPpSNIdGCOlvRmf != null) ? hdwTFdntxyWUcJPpSNIdGCOlvRmf.Length : 0);
			}
		}

		internal abstract class dTWDfcFBVnAVcJyBoQRJtBhGPIJpA : rbWKVoSjvbbciktWZPfQsLeJlfbWA, IControllerTemplateAxis, IControllerTemplateElement, IControllerTemplateButton
		{
			private JuxAmvlvwOWoqJaGcoORwookXVmr vDEnXZlahzFTPHKoqzkHfjKKDZLPA;

			public float toVGaGbECHTGSTFYySXYFPAbEELZA
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return 0f;
					}
					if (KIMQTzJAHpfEDimoxOkbotOSywjLA == 1)
					{
						return hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].OQIGMkbhlvLHZrIEeeAbPwvdLuQw;
					}
					if (KIMQTzJAHpfEDimoxOkbotOSywjLA == 2)
					{
						float num = hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].OQIGMkbhlvLHZrIEeeAbPwvdLuQw;
						float num2 = hdwTFdntxyWUcJPpSNIdGCOlvRmf[1].OQIGMkbhlvLHZrIEeeAbPwvdLuQw;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public float fMTkFFEbTNDITcbACfdfqqzIWVgpA
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return 0f;
					}
					if (KIMQTzJAHpfEDimoxOkbotOSywjLA == 1)
					{
						return hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].ajOpgJNlGTuTrOZRjGEsZMdwcBeh;
					}
					if (KIMQTzJAHpfEDimoxOkbotOSywjLA == 2)
					{
						float num = hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].ajOpgJNlGTuTrOZRjGEsZMdwcBeh;
						float num2 = hdwTFdntxyWUcJPpSNIdGCOlvRmf[1].ajOpgJNlGTuTrOZRjGEsZMdwcBeh;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool BOEELnXjEIymGUTwiKmRJWeIAsPE
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return false;
					}
					if (KIMQTzJAHpfEDimoxOkbotOSywjLA == 1)
					{
						return hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].ExmpfryYqyIFyhEKshLVZmejQiSB;
					}
					if (KIMQTzJAHpfEDimoxOkbotOSywjLA == 2)
					{
						if (!hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].ExmpfryYqyIFyhEKshLVZmejQiSB)
						{
							return hdwTFdntxyWUcJPpSNIdGCOlvRmf[1].ExmpfryYqyIFyhEKshLVZmejQiSB;
						}
						return true;
					}
					return false;
				}
			}

			public bool wEhXehIORLBzYBJTrBRLRgHNEYjxA
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return false;
					}
					if (KIMQTzJAHpfEDimoxOkbotOSywjLA == 1)
					{
						return hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].EgLowcKrIMJlxWxwIrRhFZzJNAuh;
					}
					if (KIMQTzJAHpfEDimoxOkbotOSywjLA == 2)
					{
						if (!hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].EgLowcKrIMJlxWxwIrRhFZzJNAuh)
						{
							return hdwTFdntxyWUcJPpSNIdGCOlvRmf[1].EgLowcKrIMJlxWxwIrRhFZzJNAuh;
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
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return TWNKSTuElZmtEFqYkDpAdeePKYOi.hqgSUpFEZhFcosnHdSTvUcYnaGnH;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return TWNKSTuElZmtEFqYkDpAdeePKYOi.HCQnxKXiwoIWUowGMMWcOPYezdhH;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return 0f;
					}
					return toVGaGbECHTGSTFYySXYFPAbEELZA;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return 0f;
					}
					return fMTkFFEbTNDITcbACfdfqqzIWVgpA;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return vDEnXZlahzFTPHKoqzkHfjKKDZLPA;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return false;
					}
					return BOEELnXjEIymGUTwiKmRJWeIAsPE;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return false;
					}
					return wEhXehIORLBzYBJTrBRLRgHNEYjxA;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return false;
					}
					if (KIMQTzJAHpfEDimoxOkbotOSywjLA == 1)
					{
						return hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].ddccXbAUxXHsSGUurjxOwDpeFmqM;
					}
					if (KIMQTzJAHpfEDimoxOkbotOSywjLA == 2)
					{
						if (!hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].ddccXbAUxXHsSGUurjxOwDpeFmqM || hdwTFdntxyWUcJPpSNIdGCOlvRmf[1].EgLowcKrIMJlxWxwIrRhFZzJNAuh)
						{
							if (hdwTFdntxyWUcJPpSNIdGCOlvRmf[1].ddccXbAUxXHsSGUurjxOwDpeFmqM)
							{
								return !hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].EgLowcKrIMJlxWxwIrRhFZzJNAuh;
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
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return false;
					}
					if (KIMQTzJAHpfEDimoxOkbotOSywjLA == 1)
					{
						return hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].COlpBniqYirzKWYOeqUdVKoovcDT;
					}
					if (KIMQTzJAHpfEDimoxOkbotOSywjLA == 2)
					{
						if (!hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].COlpBniqYirzKWYOeqUdVKoovcDT || hdwTFdntxyWUcJPpSNIdGCOlvRmf[1].ExmpfryYqyIFyhEKshLVZmejQiSB)
						{
							if (hdwTFdntxyWUcJPpSNIdGCOlvRmf[1].COlpBniqYirzKWYOeqUdVKoovcDT)
							{
								return !hdwTFdntxyWUcJPpSNIdGCOlvRmf[0].ExmpfryYqyIFyhEKshLVZmejQiSB;
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
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return false;
					}
					return BOEELnXjEIymGUTwiKmRJWeIAsPE != wEhXehIORLBzYBJTrBRLRgHNEYjxA;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return 0f;
					}
					return toVGaGbECHTGSTFYySXYFPAbEELZA;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return 0f;
					}
					return fMTkFFEbTNDITcbACfdfqqzIWVgpA;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return vDEnXZlahzFTPHKoqzkHfjKKDZLPA;
				}
			}

			IControllerTemplateElementSource jZLyafAnMOLOoKpQSmPItlFuvDau.source
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return vDEnXZlahzFTPHKoqzkHfjKKDZLPA;
				}
			}

			int jZLyafAnMOLOoKpQSmPItlFuvDau.elementCount => 0;

			IControllerTemplateAxis IControllerTemplateButton.AsAxis
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return this;
				}
			}

			IControllerTemplateButton IControllerTemplateAxis.AsButton
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return this;
				}
			}

			protected rIMcRRimlWBwulkRIMdcjLHIhnGF TWNKSTuElZmtEFqYkDpAdeePKYOi => (rIMcRRimlWBwulkRIMdcjLHIhnGF)VAoLRWWfhswWLAGWjWqdLgIneJUp;

			protected dTWDfcFBVnAVcJyBoQRJtBhGPIJpA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, JuxAmvlvwOWoqJaGcoORwookXVmr P_3, IList<QETzMRjzzYQYeaadskeuXsXmfBnU> P_4, rIMcRRimlWBwulkRIMdcjLHIhnGF P_5)
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
				vDEnXZlahzFTPHKoqzkHfjKKDZLPA = P_3;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange axisRange)
			{
				if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
				{
					ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
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
					IControllerTemplateAxisSource controllerTemplateAxisSource = vDEnXZlahzFTPHKoqzkHfjKKDZLPA;
					if (controllerTemplateAxisSource.splitAxis)
					{
						if (gHfNGQGzZisVKKQmzPPChtEauGZ(find, controllerTemplateAxisSource.positiveTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
							num++;
						}
						if (gHfNGQGzZisVKKQmzPPChtEauGZ(find, controllerTemplateAxisSource.negativeTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
							num++;
						}
					}
					else if (gHfNGQGzZisVKKQmzPPChtEauGZ(find, controllerTemplateAxisSource.fullTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
						num++;
					}
					break;
				}
				case ControllerTemplateElementType.Button:
					if (gHfNGQGzZisVKKQmzPPChtEauGZ(find, ((IControllerTemplateButtonSource)vDEnXZlahzFTPHKoqzkHfjKKDZLPA).target))
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

			private static bool gHfNGQGzZisVKKQmzPPChtEauGZ(ControllerElementTarget P_0, IControllerElementTarget P_1)
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

		internal sealed class ALIlRZqWkTBkkAHZHQmYqbXNsrSi : dTWDfcFBVnAVcJyBoQRJtBhGPIJpA
		{
			public ALIlRZqWkTBkkAHZHQmYqbXNsrSi(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, JuxAmvlvwOWoqJaGcoORwookXVmr P_8, IList<QETzMRjzzYQYeaadskeuXsXmfBnU> P_9)
				: base(P_0, P_1, ControllerTemplateElementType.Axis, P_8, P_9, (rIMcRRimlWBwulkRIMdcjLHIhnGF)TMXaZTLvmrmBSTGaIJfaeIdTpPjn.nxdnMgrMLELVnRKXvcNwHbUufWEAA(new rIMcRRimlWBwulkRIMdcjLHIhnGF(FmsHxmaJbvwpZaWikICOnWlHsjYj.qesQXivUrTUCZujqyhBNTDNybjTc(ILKhcCJzrmtoMHIdzHgcKloPCkpIA.ControllerTemplate, jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Axis, jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
			{
				if (P_9 != null && P_9.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static ALIlRZqWkTBkkAHZHQmYqbXNsrSi HzxMOCAjkbJEMwlsRuMOrwcCjcFP(IControllerTemplate_Internal P_0)
			{
				return new ALIlRZqWkTBkkAHZHQmYqbXNsrSi(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, JuxAmvlvwOWoqJaGcoORwookXVmr.CTMmuhVtiKsahRTskWIWTjBxGsrE(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class vwUuAPdRDzqzTTVOaEwINNIQVTnc : dTWDfcFBVnAVcJyBoQRJtBhGPIJpA
		{
			public vwUuAPdRDzqzTTVOaEwINNIQVTnc(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, JuxAmvlvwOWoqJaGcoORwookXVmr P_8, IList<QETzMRjzzYQYeaadskeuXsXmfBnU> P_9)
				: base(P_0, P_1, ControllerTemplateElementType.Button, P_8, P_9, (rIMcRRimlWBwulkRIMdcjLHIhnGF)TMXaZTLvmrmBSTGaIJfaeIdTpPjn.nxdnMgrMLELVnRKXvcNwHbUufWEAA(new rIMcRRimlWBwulkRIMdcjLHIhnGF(FmsHxmaJbvwpZaWikICOnWlHsjYj.qesQXivUrTUCZujqyhBNTDNybjTc(ILKhcCJzrmtoMHIdzHgcKloPCkpIA.ControllerTemplate, jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Button, jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
			{
				if (P_9 != null && P_9.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static vwUuAPdRDzqzTTVOaEwINNIQVTnc avTyGagqgWiczcHbKHOxCSkcZlsS(IControllerTemplate_Internal P_0)
			{
				return new vwUuAPdRDzqzTTVOaEwINNIQVTnc(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, JuxAmvlvwOWoqJaGcoORwookXVmr.CTMmuhVtiKsahRTskWIWTjBxGsrE(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class ZgmaAJbDKoXJgVHFCXbtdfREUPFnA : jZLyafAnMOLOoKpQSmPItlFuvDau
		{
			protected readonly int uWMToFisOdgRVJrKfBSWkpQctiHaA;

			protected readonly jZLyafAnMOLOoKpQSmPItlFuvDau[] qvDLQxGQtBKbRRQGLdIWFUleTpcU;

			bool jZLyafAnMOLOoKpQSmPItlFuvDau.exists
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return false;
					}
					for (int i = 0; i < uWMToFisOdgRVJrKfBSWkpQctiHaA; i++)
					{
						if (qvDLQxGQtBKbRRQGLdIWFUleTpcU[i].exists)
						{
							return true;
						}
					}
					return false;
				}
			}

			IControllerTemplateElementSource jZLyafAnMOLOoKpQSmPItlFuvDau.source
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return null;
				}
			}

			int jZLyafAnMOLOoKpQSmPItlFuvDau.elementCount => uWMToFisOdgRVJrKfBSWkpQctiHaA;

			protected ZgmaAJbDKoXJgVHFCXbtdfREUPFnA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, jZLyafAnMOLOoKpQSmPItlFuvDau[] P_3, pfetedQbitdObLxnJcXDFUggaTfnA P_4)
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
				qvDLQxGQtBKbRRQGLdIWFUleTpcU = P_3;
				uWMToFisOdgRVJrKfBSWkpQctiHaA = P_3.Length;
			}

			public virtual IControllerTemplateElement cHgpyIEdcxTVWIBwjbCnGAuQSOvtA(int P_0)
			{
				return qvDLQxGQtBKbRRQGLdIWFUleTpcU[P_0];
			}

			public virtual int OVhfjIVNHMAQNHGWzrtSClLbxSeMA(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				for (int i = 0; i < qvDLQxGQtBKbRRQGLdIWFUleTpcU.Length; i++)
				{
					num += qvDLQxGQtBKbRRQGLdIWFUleTpcU[i].GetElementTargets(P_0, ref P_1);
				}
				return num;
			}
		}

		internal abstract class dWHGedbCmJPCVbrvAubxkNVUlAnxB : ZgmaAJbDKoXJgVHFCXbtdfREUPFnA, IControllerTemplateAxis2D, IControllerTemplateElement
		{
			protected const int hJLZbmslWeHufzzpOrZQehfVkWjI = 0;

			protected const int QFpEhaLqyCRSelIwXgSMklsubgLAA = 1;

			protected const int hSiBwcEunEELCmmluqygKdZXdbHX = 2;

			Vector2 IControllerTemplateAxis2D.value
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return Vector2.zero;
					}
					return new Vector2((uWMToFisOdgRVJrKfBSWkpQctiHaA > 0) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0]).toVGaGbECHTGSTFYySXYFPAbEELZA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 1) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1]).toVGaGbECHTGSTFYySXYFPAbEELZA : 0f);
				}
			}

			Vector2 IControllerTemplateAxis2D.valuePrev
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return Vector2.zero;
					}
					return new Vector2((uWMToFisOdgRVJrKfBSWkpQctiHaA > 0) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0]).fMTkFFEbTNDITcbACfdfqqzIWVgpA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 1) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1]).fMTkFFEbTNDITcbACfdfqqzIWVgpA : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.horizontal
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.vertical
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1];
				}
			}

			protected dWHGedbCmJPCVbrvAubxkNVUlAnxB(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, jZLyafAnMOLOoKpQSmPItlFuvDau[] P_3, pfetedQbitdObLxnJcXDFUggaTfnA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class nALddEeLXlEXkIHyksmMZxxyBvYx : ZgmaAJbDKoXJgVHFCXbtdfREUPFnA, IControllerTemplateAxis3D, IControllerTemplateElement
		{
			protected const int ovUhSPfHEZFjFhpwOMvihcABOedBb = 0;

			protected const int CGkSZtiOPHhGtKsAyVQaJUdLjqYw = 1;

			protected const int mXfKiisAIEGYEbYQxITbFfTISRHJ = 2;

			protected const int lfmmWkGTrKaHEgVGSniUowVEDFwX = 3;

			Vector3 IControllerTemplateAxis3D.value
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return Vector3.zero;
					}
					return new Vector3((uWMToFisOdgRVJrKfBSWkpQctiHaA > 0) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0]).toVGaGbECHTGSTFYySXYFPAbEELZA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 1) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1]).toVGaGbECHTGSTFYySXYFPAbEELZA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 2) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2]).toVGaGbECHTGSTFYySXYFPAbEELZA : 0f);
				}
			}

			Vector3 IControllerTemplateAxis3D.valuePrev
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return Vector3.zero;
					}
					return new Vector3((uWMToFisOdgRVJrKfBSWkpQctiHaA > 0) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0]).fMTkFFEbTNDITcbACfdfqqzIWVgpA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 1) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1]).fMTkFFEbTNDITcbACfdfqqzIWVgpA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 2) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2]).fMTkFFEbTNDITcbACfdfqqzIWVgpA : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.horizontal
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.vertical
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.depth
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2];
				}
			}

			protected nALddEeLXlEXkIHyksmMZxxyBvYx(IControllerTemplate_Internal P_0, int P_1, ControllerTemplateElementType P_2, jZLyafAnMOLOoKpQSmPItlFuvDau[] P_3, pfetedQbitdObLxnJcXDFUggaTfnA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class XmdXiAVKYDJVoZOcTeVbEFeKPsWkA : ZgmaAJbDKoXJgVHFCXbtdfREUPFnA, IControllerTemplateAxis6D, IControllerTemplateElement
		{
			protected const int IzcKtiTWQduOsboIXrqHsHBMIjXeA = 0;

			protected const int xhqblDlVrgOqBWzqOeGIVbjpgjmd = 1;

			protected const int NQlMPyXdJoERUCENBDkXaORfbgfsA = 2;

			protected const int sVdTbgCjUPIFAqfRBOmRGsNuDcjD = 3;

			protected const int zDnIgZnObKlrQKGyoWTfAECukTEp = 4;

			protected const int mrSDYHkQenimzLFtMKrhorDaHzyt = 5;

			protected const int IAxOVkhEfBHiuHgiAjMoqqcEHyLR = 6;

			Vector3 IControllerTemplateAxis6D.position
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return Vector3.zero;
					}
					return new Vector3((uWMToFisOdgRVJrKfBSWkpQctiHaA > 0) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0]).toVGaGbECHTGSTFYySXYFPAbEELZA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 1) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1]).toVGaGbECHTGSTFYySXYFPAbEELZA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 2) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2]).toVGaGbECHTGSTFYySXYFPAbEELZA : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.positionPrev
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return Vector3.zero;
					}
					return new Vector3((uWMToFisOdgRVJrKfBSWkpQctiHaA > 0) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0]).fMTkFFEbTNDITcbACfdfqqzIWVgpA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 1) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1]).fMTkFFEbTNDITcbACfdfqqzIWVgpA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 2) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2]).fMTkFFEbTNDITcbACfdfqqzIWVgpA : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotation
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return Vector3.zero;
					}
					return new Vector3((uWMToFisOdgRVJrKfBSWkpQctiHaA > 3) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[3]).toVGaGbECHTGSTFYySXYFPAbEELZA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 4) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[4]).toVGaGbECHTGSTFYySXYFPAbEELZA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 5) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[5]).toVGaGbECHTGSTFYySXYFPAbEELZA : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotationPrev
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return Vector3.zero;
					}
					return new Vector3((uWMToFisOdgRVJrKfBSWkpQctiHaA > 3) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[3]).fMTkFFEbTNDITcbACfdfqqzIWVgpA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 4) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[4]).fMTkFFEbTNDITcbACfdfqqzIWVgpA : 0f, (uWMToFisOdgRVJrKfBSWkpQctiHaA > 5) ? ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[5]).fMTkFFEbTNDITcbACfdfqqzIWVgpA : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionX
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionY
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionZ
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationX
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[3];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationY
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[4];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationZ
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[5];
				}
			}

			protected XmdXiAVKYDJVoZOcTeVbEFeKPsWkA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, jZLyafAnMOLOoKpQSmPItlFuvDau[] P_3, pfetedQbitdObLxnJcXDFUggaTfnA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal sealed class LRhBXOZJxnEFguvDhssrogZRJjJi : nALddEeLXlEXkIHyksmMZxxyBvYx, IControllerTemplateStick, IControllerTemplateElement
		{
			private const int mxkwihXObKgGxwYGyonJgVOYlzMj = 3;

			IControllerTemplateAxis IControllerTemplateStick.rotation
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2];
				}
			}

			private LRhBXOZJxnEFguvDhssrogZRJjJi(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, jZLyafAnMOLOoKpQSmPItlFuvDau[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Stick, P_4, jZLyafAnMOLOoKpQSmPItlFuvDau.ZxyHqXBOhlNFnDsxTePZdowJBNpV(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			public LRhBXOZJxnEFguvDhssrogZRJjJi(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_4, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_5, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_6)
				: this(P_0, P_1, P_2, P_3, new jZLyafAnMOLOoKpQSmPItlFuvDau[3] { P_4, P_5, P_6 })
			{
			}
		}

		internal sealed class UMYvkgdZUSokWVrcAeNgploQGWsBA : dWHGedbCmJPCVbrvAubxkNVUlAnxB, IControllerTemplateThumbStick, IControllerTemplateElement
		{
			private const int lfdhYaqoKqExbgBkViMYmiJjgmEm = 2;

			private const int fiPzbdAmByhyDfehALbrebSgAPqMc = 3;

			IControllerTemplateButton IControllerTemplateThumbStick.press
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2];
				}
			}

			private UMYvkgdZUSokWVrcAeNgploQGWsBA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, jZLyafAnMOLOoKpQSmPItlFuvDau[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.ThumbStick, P_4, jZLyafAnMOLOoKpQSmPItlFuvDau.ZxyHqXBOhlNFnDsxTePZdowJBNpV(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal UMYvkgdZUSokWVrcAeNgploQGWsBA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_4, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_5, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_6)
				: this(P_0, P_1, P_2, P_3, new jZLyafAnMOLOoKpQSmPItlFuvDau[3] { P_4, P_5, P_6 })
			{
			}
		}

		internal sealed class aivaqrAAxHJhrUTRiKkvNqwvuymX : ZgmaAJbDKoXJgVHFCXbtdfREUPFnA, IControllerTemplateDPad, IControllerTemplateElement
		{
			private const int RKJIfbEbqBmiIHnjwzmbCGwtdboK = 0;

			private const int JxgOzHSfZaudKraVqeiZByFcENFhA = 1;

			private const int zdaUgBVsUuuoZqumLtufnZDOQVfg = 2;

			private const int gKLfPevVlGPmVdIGsfBJzAMjGIZjA = 3;

			private const int LnEglrfNevaYentrIhOhHNtDvWzqc = 4;

			private const int KYSxkmCGbLJgNKcdQnOxRbkBePWeA = 5;

			Vector2 IControllerTemplateDPad.value
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0]).toVGaGbECHTGSTFYySXYFPAbEELZA + ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2]).toVGaGbECHTGSTFYySXYFPAbEELZA * -1f, -1f, 1f), MathTools.Clamp(((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[3]).toVGaGbECHTGSTFYySXYFPAbEELZA * -1f + ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1]).toVGaGbECHTGSTFYySXYFPAbEELZA, -1f, 1f));
				}
			}

			Vector2 IControllerTemplateDPad.valuePrev
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0]).fMTkFFEbTNDITcbACfdfqqzIWVgpA + ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2]).fMTkFFEbTNDITcbACfdfqqzIWVgpA * -1f, -1f, 1f), MathTools.Clamp(((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[3]).fMTkFFEbTNDITcbACfdfqqzIWVgpA * -1f + ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1]).fMTkFFEbTNDITcbACfdfqqzIWVgpA, -1f, 1f));
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.up
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.right
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.down
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.left
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[3];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.press
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[4];
				}
			}

			private aivaqrAAxHJhrUTRiKkvNqwvuymX(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, jZLyafAnMOLOoKpQSmPItlFuvDau[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.DPad, P_4, jZLyafAnMOLOoKpQSmPItlFuvDau.ZxyHqXBOhlNFnDsxTePZdowJBNpV(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal aivaqrAAxHJhrUTRiKkvNqwvuymX(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_4, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_5, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_6, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_7, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_8)
				: this(P_0, P_1, P_2, P_3, new jZLyafAnMOLOoKpQSmPItlFuvDau[5] { P_4, P_5, P_6, P_7, P_8 })
			{
			}
		}

		internal sealed class vBDdnTNPNVZOOtvzAAOarwnzBWEl : ZgmaAJbDKoXJgVHFCXbtdfREUPFnA, IControllerTemplateThrottle, IControllerTemplateElement
		{
			private const int JNGylYDVZHNqOojBDVJTeMZdjKax = 0;

			private const int XwlffekbhIMqxfIDPvuuphjKrBvn = 1;

			private const int TcvrGXWuIrEAjwtbnFMYWLfgbWpCA = 2;

			float IControllerTemplateThrottle.value
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return 0f;
					}
					return ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0]).toVGaGbECHTGSTFYySXYFPAbEELZA;
				}
			}

			float IControllerTemplateThrottle.valuePrev
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return 0f;
					}
					return ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0]).fMTkFFEbTNDITcbACfdfqqzIWVgpA;
				}
			}

			IControllerTemplateAxis IControllerTemplateThrottle.throttle
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0];
				}
			}

			IControllerTemplateButton IControllerTemplateThrottle.minDetent
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1];
				}
			}

			private vBDdnTNPNVZOOtvzAAOarwnzBWEl(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, jZLyafAnMOLOoKpQSmPItlFuvDau[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Throttle, P_4, jZLyafAnMOLOoKpQSmPItlFuvDau.ZxyHqXBOhlNFnDsxTePZdowJBNpV(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 2)
				{
					throw new ArgumentException("elements.Length must be " + 2);
				}
			}

			internal vBDdnTNPNVZOOtvzAAOarwnzBWEl(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_4, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_5)
				: this(P_0, P_1, P_2, P_3, new jZLyafAnMOLOoKpQSmPItlFuvDau[2] { P_4, P_5 })
			{
			}
		}

		internal sealed class ObhkLsGJrEVTEKVVDnPkZtaHtqhA : ZgmaAJbDKoXJgVHFCXbtdfREUPFnA, IControllerTemplateHat, IControllerTemplateElement
		{
			private const int CdYTgZBwmFJRNxOMKmTtgFOJCxWR = 0;

			private const int wVzNOQOWCypFKTAQxAnYItFtUKiCA = 1;

			private const int eTvPsWEUgGqVoNwweTNIzAOtfcfz = 2;

			private const int xyJBFqauKszUVdPApXCZGXkCDDmfA = 3;

			private const int HxUsGXrrjjKtqpvQDIeYdlHnIhGP = 4;

			private const int vdRDDdPRcUIyeFhuzCZHsybUvUyCA = 5;

			private const int rhyKQQqXgYmnvcNmVvUtxsslGxlP = 6;

			private const int IVKuzeKqWQOmAtGPGAsPROPmuOVS = 7;

			private const int xCILPnrjzUdyqnwEbbhoRRhjgloe = 8;

			Vector2 IControllerTemplateHat.value
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0]).toVGaGbECHTGSTFYySXYFPAbEELZA;
					result.x += ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2]).toVGaGbECHTGSTFYySXYFPAbEELZA;
					result.y -= ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[4]).toVGaGbECHTGSTFYySXYFPAbEELZA;
					result.x -= ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[6]).toVGaGbECHTGSTFYySXYFPAbEELZA;
					float num = ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1]).toVGaGbECHTGSTFYySXYFPAbEELZA;
					float num2 = ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[3]).toVGaGbECHTGSTFYySXYFPAbEELZA;
					float num3 = ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[5]).toVGaGbECHTGSTFYySXYFPAbEELZA;
					float num4 = ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[7]).toVGaGbECHTGSTFYySXYFPAbEELZA;
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
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0]).fMTkFFEbTNDITcbACfdfqqzIWVgpA;
					result.x += ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2]).fMTkFFEbTNDITcbACfdfqqzIWVgpA;
					result.y -= ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[4]).fMTkFFEbTNDITcbACfdfqqzIWVgpA;
					result.x -= ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[6]).fMTkFFEbTNDITcbACfdfqqzIWVgpA;
					float num = ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1]).fMTkFFEbTNDITcbACfdfqqzIWVgpA;
					float num2 = ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[3]).fMTkFFEbTNDITcbACfdfqqzIWVgpA;
					float num3 = ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[5]).fMTkFFEbTNDITcbACfdfqqzIWVgpA;
					float num4 = ((dTWDfcFBVnAVcJyBoQRJtBhGPIJpA)qvDLQxGQtBKbRRQGLdIWFUleTpcU[7]).fMTkFFEbTNDITcbACfdfqqzIWVgpA;
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
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upRight
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.right
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[2];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downRight
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[3];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.down
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[4];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downLeft
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[5];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.left
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[6];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upLeft
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateButton)qvDLQxGQtBKbRRQGLdIWFUleTpcU[7];
				}
			}

			private ObhkLsGJrEVTEKVVDnPkZtaHtqhA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, jZLyafAnMOLOoKpQSmPItlFuvDau[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Hat, P_4, jZLyafAnMOLOoKpQSmPItlFuvDau.ZxyHqXBOhlNFnDsxTePZdowJBNpV(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 8)
				{
					throw new ArgumentException("elements.Length must be " + 8);
				}
			}

			internal ObhkLsGJrEVTEKVVDnPkZtaHtqhA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_4, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_5, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_6, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_7, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_8, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_9, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_10, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_11)
				: this(P_0, P_1, P_2, P_3, new jZLyafAnMOLOoKpQSmPItlFuvDau[8] { P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11 })
			{
			}
		}

		internal sealed class MPkkoimRsyjCUoFPeqAPjGweBzTcA : dWHGedbCmJPCVbrvAubxkNVUlAnxB, IControllerTemplateYoke, IControllerTemplateElement
		{
			private const int PtzcXJdeKCOnflGrRKsGefScsqPRB = 2;

			IControllerTemplateAxis IControllerTemplateYoke.rotation
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateYoke.pushPull
			{
				get
				{
					if (ReInput._id != QfuXZUtxiNvCSgHNpenlBEATHLZP)
					{
						ReInput.CheckInitialized(QfuXZUtxiNvCSgHNpenlBEATHLZP);
						return null;
					}
					return (IControllerTemplateAxis)qvDLQxGQtBKbRRQGLdIWFUleTpcU[1];
				}
			}

			private MPkkoimRsyjCUoFPeqAPjGweBzTcA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, jZLyafAnMOLOoKpQSmPItlFuvDau[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Yoke, P_4, jZLyafAnMOLOoKpQSmPItlFuvDau.ZxyHqXBOhlNFnDsxTePZdowJBNpV(P_0, P_1, P_2, P_3))
			{
			}

			internal MPkkoimRsyjCUoFPeqAPjGweBzTcA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_4, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_5)
				: this(P_0, P_1, P_2, P_3, new jZLyafAnMOLOoKpQSmPItlFuvDau[2] { P_4, P_5 })
			{
			}
		}

		internal sealed class sktCszCjIRrCOpcOeNeUlAzWMoGD : XmdXiAVKYDJVoZOcTeVbEFeKPsWkA, IControllerTemplateStick6D, IControllerTemplateElement
		{
			private const int vQTNshNWjVtxxyFiOAJBscKEFhmo = 6;

			private sktCszCjIRrCOpcOeNeUlAzWMoGD(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, jZLyafAnMOLOoKpQSmPItlFuvDau[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Stick6D, P_4, jZLyafAnMOLOoKpQSmPItlFuvDau.ZxyHqXBOhlNFnDsxTePZdowJBNpV(P_0, P_1, P_2, P_3))
			{
			}

			internal sktCszCjIRrCOpcOeNeUlAzWMoGD(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_4, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_5, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_6, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_7, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_8, dTWDfcFBVnAVcJyBoQRJtBhGPIJpA P_9)
				: this(P_0, P_1, P_2, P_3, new jZLyafAnMOLOoKpQSmPItlFuvDau[6] { P_4, P_5, P_6, P_7, P_8, P_9 })
			{
			}
		}

		internal class QETzMRjzzYQYeaadskeuXsXmfBnU
		{
			public readonly Controller.Element VxOcTYDQTlLooMiqilroKuPNQlkp;

			public readonly IControllerElementTarget MubpbGCEpLDxWNKFiBNKjTQSRMxWA;

			public bool ExmpfryYqyIFyhEKshLVZmejQiSB
			{
				get
				{
					if (VxOcTYDQTlLooMiqilroKuPNQlkp == null)
					{
						return false;
					}
					switch (VxOcTYDQTlLooMiqilroKuPNQlkp.type)
					{
					case ControllerElementType.Button:
						return (VxOcTYDQTlLooMiqilroKuPNQlkp as Controller.Button).value;
					case ControllerElementType.Axis:
					{
						float value = (VxOcTYDQTlLooMiqilroKuPNQlkp as Controller.Axis).value;
						switch (MubpbGCEpLDxWNKFiBNKjTQSRMxWA.axisRange)
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

			public bool EgLowcKrIMJlxWxwIrRhFZzJNAuh
			{
				get
				{
					if (VxOcTYDQTlLooMiqilroKuPNQlkp == null)
					{
						return false;
					}
					switch (VxOcTYDQTlLooMiqilroKuPNQlkp.type)
					{
					case ControllerElementType.Button:
						return (VxOcTYDQTlLooMiqilroKuPNQlkp as Controller.Button).valuePrev;
					case ControllerElementType.Axis:
					{
						float valuePrev = (VxOcTYDQTlLooMiqilroKuPNQlkp as Controller.Axis).valuePrev;
						switch (MubpbGCEpLDxWNKFiBNKjTQSRMxWA.axisRange)
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

			public bool ddccXbAUxXHsSGUurjxOwDpeFmqM
			{
				get
				{
					if (VxOcTYDQTlLooMiqilroKuPNQlkp == null)
					{
						return false;
					}
					switch (VxOcTYDQTlLooMiqilroKuPNQlkp.type)
					{
					case ControllerElementType.Button:
						return (VxOcTYDQTlLooMiqilroKuPNQlkp as Controller.Button).justPressed;
					case ControllerElementType.Axis:
						if (MathTools.Abs(OQIGMkbhlvLHZrIEeeAbPwvdLuQw) > 0.01f && MathTools.Abs(ajOpgJNlGTuTrOZRjGEsZMdwcBeh) <= 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public bool COlpBniqYirzKWYOeqUdVKoovcDT
			{
				get
				{
					if (VxOcTYDQTlLooMiqilroKuPNQlkp == null)
					{
						return false;
					}
					switch (VxOcTYDQTlLooMiqilroKuPNQlkp.type)
					{
					case ControllerElementType.Button:
						return (VxOcTYDQTlLooMiqilroKuPNQlkp as Controller.Button).justReleased;
					case ControllerElementType.Axis:
						if (MathTools.Abs(OQIGMkbhlvLHZrIEeeAbPwvdLuQw) <= 0.01f && MathTools.Abs(ajOpgJNlGTuTrOZRjGEsZMdwcBeh) > 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public float OQIGMkbhlvLHZrIEeeAbPwvdLuQw
			{
				get
				{
					if (VxOcTYDQTlLooMiqilroKuPNQlkp == null)
					{
						return 0f;
					}
					switch (VxOcTYDQTlLooMiqilroKuPNQlkp.type)
					{
					case ControllerElementType.Button:
						if (!(VxOcTYDQTlLooMiqilroKuPNQlkp as Controller.Button).value)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float value = (VxOcTYDQTlLooMiqilroKuPNQlkp as Controller.Axis).value;
						switch (MubpbGCEpLDxWNKFiBNKjTQSRMxWA.axisRange)
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

			public float ajOpgJNlGTuTrOZRjGEsZMdwcBeh
			{
				get
				{
					if (VxOcTYDQTlLooMiqilroKuPNQlkp == null)
					{
						return 0f;
					}
					switch (VxOcTYDQTlLooMiqilroKuPNQlkp.type)
					{
					case ControllerElementType.Button:
						if (!(VxOcTYDQTlLooMiqilroKuPNQlkp as Controller.Button).valuePrev)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float valuePrev = (VxOcTYDQTlLooMiqilroKuPNQlkp as Controller.Axis).valuePrev;
						switch (MubpbGCEpLDxWNKFiBNKjTQSRMxWA.axisRange)
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

			public QETzMRjzzYQYeaadskeuXsXmfBnU(IControllerElementTarget P_0, Controller.Element P_1)
			{
				VxOcTYDQTlLooMiqilroKuPNQlkp = P_1;
				MubpbGCEpLDxWNKFiBNKjTQSRMxWA = P_0;
			}

			public static QETzMRjzzYQYeaadskeuXsXmfBnU fmmDricCkSWFepyhNxxkibtZtUekA()
			{
				return new QETzMRjzzYQYeaadskeuXsXmfBnU(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.yKFZOeFZwVLSDDajwmHMnTpZEMVh(), null);
			}
		}

		internal class oJRdzPFCfZVnUquAeXOaQPbKAPnVA
		{
			public readonly Controller sVxsmxpMcgFQDYNQLMIJLXjbrdNp;

			public readonly IHardwareControllerTemplateMap_Internal XaEmqjgGcteLAivBBPWQIriCLyHJ;

			public oJRdzPFCfZVnUquAeXOaQPbKAPnVA(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				sVxsmxpMcgFQDYNQLMIJLXjbrdNp = P_0;
				XaEmqjgGcteLAivBBPWQIriCLyHJ = P_1;
			}
		}

		private sealed class TMXaZTLvmrmBSTGaIJfaeIdTpPjn
		{
			[Serializable]
			private sealed class ZYtlcmpAqkWPNVmWdDFKRGnAuZMB
			{
				public static readonly ZYtlcmpAqkWPNVmWdDFKRGnAuZMB _003C_003E9 = new ZYtlcmpAqkWPNVmWdDFKRGnAuZMB();

				public static Func<pfetedQbitdObLxnJcXDFUggaTfnA, pfetedQbitdObLxnJcXDFUggaTfnA, bool> _003C_003E9__4_0;

				internal bool nCwGoLFSBKyqLsMPdrGdcRUYAyqQ(pfetedQbitdObLxnJcXDFUggaTfnA P_0, pfetedQbitdObLxnJcXDFUggaTfnA P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					return P_0.xAvEtPzMAmejwMLFXLySdnqPFWII(P_1, false);
				}
			}

			private static TMXaZTLvmrmBSTGaIJfaeIdTpPjn NvkGaikLCEIHrdErAApMArPIDUdz;

			private readonly global::frkDecQuGtqloMwKYmMMIfIonbfk<pfetedQbitdObLxnJcXDFUggaTfnA> AMTatVctiVGWdnchkkunDwOXWAsF;

			private static TMXaZTLvmrmBSTGaIJfaeIdTpPjn BNyaCwDhrmlUatXEnETzuCrlxuosA
			{
				get
				{
					if (NvkGaikLCEIHrdErAApMArPIDUdz != null)
					{
						return NvkGaikLCEIHrdErAApMArPIDUdz;
					}
					NvkGaikLCEIHrdErAApMArPIDUdz = new TMXaZTLvmrmBSTGaIJfaeIdTpPjn();
					NvkGaikLCEIHrdErAApMArPIDUdz.skYOBtYaqXqLmNDaxGrscCeOAUOi();
					return NvkGaikLCEIHrdErAApMArPIDUdz;
				}
			}

			private TMXaZTLvmrmBSTGaIJfaeIdTpPjn()
			{
				AMTatVctiVGWdnchkkunDwOXWAsF = new global::frkDecQuGtqloMwKYmMMIfIonbfk<pfetedQbitdObLxnJcXDFUggaTfnA>(ZYtlcmpAqkWPNVmWdDFKRGnAuZMB._003C_003E9.nCwGoLFSBKyqLsMPdrGdcRUYAyqQ);
			}

			private void skYOBtYaqXqLmNDaxGrscCeOAUOi()
			{
				ReInput.ShutDownEvent += NvkGaikLCEIHrdErAApMArPIDUdz.LbXoILQrBPLrQEwlTQSlxanIWgqS;
			}

			private void LbXoILQrBPLrQEwlTQSlxanIWgqS()
			{
				if (NvkGaikLCEIHrdErAApMArPIDUdz == this)
				{
					NvkGaikLCEIHrdErAApMArPIDUdz = null;
				}
				ReInput.ShutDownEvent -= LbXoILQrBPLrQEwlTQSlxanIWgqS;
			}

			public static pfetedQbitdObLxnJcXDFUggaTfnA nxdnMgrMLELVnRKXvcNwHbUufWEAA(pfetedQbitdObLxnJcXDFUggaTfnA P_0)
			{
				Bytes20 bytes = ((P_0.aOhQIONsIpURLhjvhVnGKJRxbNfBA is YXZigdaiNFoGvsJGpzzOfUbYIYHI yXZigdaiNFoGvsJGpzzOfUbYIYHI) ? yXZigdaiNFoGvsJGpzzOfUbYIYHI.jYOvZrbCtfurqnyzXvZtgilgSpNd.hash : default(Bytes20));
				return BNyaCwDhrmlUatXEnETzuCrlxuosA.AMTatVctiVGWdnchkkunDwOXWAsF.WiXlndVHOhDtrdahVzEwBbrFiFlF(bytes, P_0);
			}

			public static bool tDjYEsJvaaOBBMOkLKUvBHixPCdm(pfetedQbitdObLxnJcXDFUggaTfnA P_0, out pfetedQbitdObLxnJcXDFUggaTfnA P_1)
			{
				Bytes20 bytes = ((P_0.aOhQIONsIpURLhjvhVnGKJRxbNfBA is YXZigdaiNFoGvsJGpzzOfUbYIYHI yXZigdaiNFoGvsJGpzzOfUbYIYHI) ? yXZigdaiNFoGvsJGpzzOfUbYIYHI.jYOvZrbCtfurqnyzXvZtgilgSpNd.hash : default(Bytes20));
				return BNyaCwDhrmlUatXEnETzuCrlxuosA.AMTatVctiVGWdnchkkunDwOXWAsF.ygSxKCwLEisnUFvjzYlmWjzWgFws(bytes, P_0, out P_1);
			}

			public static void FvluObwKMBCtKEUzzvzrrdUfSlKW(pfetedQbitdObLxnJcXDFUggaTfnA P_0)
			{
				Bytes20 bytes = ((P_0.aOhQIONsIpURLhjvhVnGKJRxbNfBA is YXZigdaiNFoGvsJGpzzOfUbYIYHI yXZigdaiNFoGvsJGpzzOfUbYIYHI) ? yXZigdaiNFoGvsJGpzzOfUbYIYHI.jYOvZrbCtfurqnyzXvZtgilgSpNd.hash : default(Bytes20));
				BNyaCwDhrmlUatXEnETzuCrlxuosA.AMTatVctiVGWdnchkkunDwOXWAsF.BJUFZEhwGLMUmyBgFeUcAyOMNcmk(bytes, P_0);
			}
		}

		private const string MoLuyVfckEXCfiLvwymmCwBwuUbu = "controller/template";

		private string aKTItJipeYeZuGvqMaMeDWcjshmD;

		private string agmNOFCEcIaYSauHoDKcRWWTXyZE;

		private int NjMbhEwWqnOGOkaCMxXxxlGURFEC;

		private readonly Guid EucuNZZnRZzrfAizQhVkKfHjjziCA;

		private readonly DeviceLocalizationInfo RxRWxbDLBVoUFDBCauCqZLUQHudk;

		private readonly Controller OpodvXNWhQfXkdcPvCkTOqOpnBPV;

		private readonly ADictionary<int, IControllerTemplateElement> gJTCefkAgBIUOGHqipkLOlGEVKJtb;

		private readonly ADictionary<string, IControllerTemplateElement> NqhHtBDmxMtRczMhuemkDZHQvqOB;

		private IControllerTemplateElement[] AqcSKJaXJqooAEeUmiiNecvQvaXp;

		private ReadOnlyCollection<IControllerTemplateElement> qfuacnNbZJIfEzhHSXIGEqeCWrGh;

		private readonly CMZFLplsuqkvbBvNYmZBVurZoVpI wlCThvfNwcaUldpnUWmOsoKlGkqw;

		private readonly int hSuaxVFYJDHFYeYEKXUAFLNilPpaA;

		internal DeviceLocalizationInfo jLXmGyVcfabmBiwwPmCBssErFZTt => RxRWxbDLBVoUFDBCauCqZLUQHudk;

		DeviceLocalizationInfo IControllerTemplate_Internal.deviceLocalizationInfo => RxRWxbDLBVoUFDBCauCqZLUQHudk;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != hSuaxVFYJDHFYeYEKXUAFLNilPpaA)
				{
					ReInput.CheckInitialized(hSuaxVFYJDHFYeYEKXUAFLNilPpaA);
					return null;
				}
				return OpodvXNWhQfXkdcPvCkTOqOpnBPV;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != hSuaxVFYJDHFYeYEKXUAFLNilPpaA)
				{
					ReInput.CheckInitialized(hSuaxVFYJDHFYeYEKXUAFLNilPpaA);
					return null;
				}
				if (!LocalizationManager.isEnabled)
				{
					return aKTItJipeYeZuGvqMaMeDWcjshmD;
				}
				return wlCThvfNwcaUldpnUWmOsoKlGkqw.qJkqRAxrrocPcPhIKAOpCMJUoZxfA;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != hSuaxVFYJDHFYeYEKXUAFLNilPpaA)
				{
					ReInput.CheckInitialized(hSuaxVFYJDHFYeYEKXUAFLNilPpaA);
					return Guid.Empty;
				}
				return EucuNZZnRZzrfAizQhVkKfHjjziCA;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != hSuaxVFYJDHFYeYEKXUAFLNilPpaA)
				{
					ReInput.CheckInitialized(hSuaxVFYJDHFYeYEKXUAFLNilPpaA);
					return null;
				}
				return qfuacnNbZJIfEzhHSXIGEqeCWrGh;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != hSuaxVFYJDHFYeYEKXUAFLNilPpaA)
				{
					ReInput.CheckInitialized(hSuaxVFYJDHFYeYEKXUAFLNilPpaA);
					return 0;
				}
				return AqcSKJaXJqooAEeUmiiNecvQvaXp.Length;
			}
		}

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.keyCategory => "controller/template";

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.scriptingName => string.Empty;

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.nonLocalizedDescriptiveName
		{
			get
			{
				return aKTItJipeYeZuGvqMaMeDWcjshmD;
			}
			set
			{
				aKTItJipeYeZuGvqMaMeDWcjshmD = value;
			}
		}

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.key => agmNOFCEcIaYSauHoDKcRWWTXyZE;

		int LnhaMJXLiFbdSGpizhhMTtFDjtXy.autoGeneratedValueFlags
		{
			get
			{
				return NjMbhEwWqnOGOkaCMxXxxlGURFEC;
			}
			set
			{
				NjMbhEwWqnOGOkaCMxXxxlGURFEC = value;
			}
		}

		protected ControllerTemplate(object P_0)
			: this((oJRdzPFCfZVnUquAeXOaQPbKAPnVA)P_0)
		{
		}

		private ControllerTemplate(oJRdzPFCfZVnUquAeXOaQPbKAPnVA P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (P_0.sVxsmxpMcgFQDYNQLMIJLXjbrdNp == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (P_0.XaEmqjgGcteLAivBBPWQIriCLyHJ == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			hSuaxVFYJDHFYeYEKXUAFLNilPpaA = ReInput.id;
			OpodvXNWhQfXkdcPvCkTOqOpnBPV = P_0.sVxsmxpMcgFQDYNQLMIJLXjbrdNp;
			IHardwareControllerTemplateMap_Internal xaEmqjgGcteLAivBBPWQIriCLyHJ = P_0.XaEmqjgGcteLAivBBPWQIriCLyHJ;
			aKTItJipeYeZuGvqMaMeDWcjshmD = xaEmqjgGcteLAivBBPWQIriCLyHJ.name;
			agmNOFCEcIaYSauHoDKcRWWTXyZE = xaEmqjgGcteLAivBBPWQIriCLyHJ.typeKey;
			EucuNZZnRZzrfAizQhVkKfHjjziCA = xaEmqjgGcteLAivBBPWQIriCLyHJ.typeGuid;
			RxRWxbDLBVoUFDBCauCqZLUQHudk = new DeviceLocalizationInfo(OpodvXNWhQfXkdcPvCkTOqOpnBPV.type, true, EucuNZZnRZzrfAizQhVkKfHjjziCA, new List<string> { xaEmqjgGcteLAivBBPWQIriCLyHJ.typeKey }, null);
			RxRWxbDLBVoUFDBCauCqZLUQHudk.FinishRuntimeSetup();
			wlCThvfNwcaUldpnUWmOsoKlGkqw = CMZFLplsuqkvbBvNYmZBVurZoVpI.mcPyJtFwDcyGtHKiRQGaIYyPGBGg(this);
			int elementIdentifierCount = xaEmqjgGcteLAivBBPWQIriCLyHJ.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = xaEmqjgGcteLAivBBPWQIriCLyHJ.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						JuxAmvlvwOWoqJaGcoORwookXVmr juxAmvlvwOWoqJaGcoORwookXVmr2 = xaEmqjgGcteLAivBBPWQIriCLyHJ.GetAxisTarget(OpodvXNWhQfXkdcPvCkTOqOpnBPV, templateElementIdentifier.id) ?? JuxAmvlvwOWoqJaGcoORwookXVmr.CTMmuhVtiKsahRTskWIWTjBxGsrE(ControllerTemplateElementType.Axis);
						ALIlRZqWkTBkkAHZHQmYqbXNsrSi item2 = new ALIlRZqWkTBkkAHZHQmYqbXNsrSi(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, juxAmvlvwOWoqJaGcoORwookXVmr2, wfBVwBIRflBcRPRTJCjYycxdfOvc(OpodvXNWhQfXkdcPvCkTOqOpnBPV, juxAmvlvwOWoqJaGcoORwookXVmr2));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						JuxAmvlvwOWoqJaGcoORwookXVmr juxAmvlvwOWoqJaGcoORwookXVmr = xaEmqjgGcteLAivBBPWQIriCLyHJ.GetButtonTarget(OpodvXNWhQfXkdcPvCkTOqOpnBPV, templateElementIdentifier.id) ?? JuxAmvlvwOWoqJaGcoORwookXVmr.CTMmuhVtiKsahRTskWIWTjBxGsrE(ControllerTemplateElementType.Button);
						vwUuAPdRDzqzTTVOaEwINNIQVTnc item = new vwUuAPdRDzqzTTVOaEwINNIQVTnc(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, juxAmvlvwOWoqJaGcoORwookXVmr, hXTbMHeiSyrvCNZjqOblxWFwhBAO(OpodvXNWhQfXkdcPvCkTOqOpnBPV, juxAmvlvwOWoqJaGcoORwookXVmr));
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
				IControllerTemplateElementIdentifier templateElementIdentifier2 = xaEmqjgGcteLAivBBPWQIriCLyHJ.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = xaEmqjgGcteLAivBBPWQIriCLyHJ.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				jZLyafAnMOLOoKpQSmPItlFuvDau jZLyafAnMOLOoKpQSmPItlFuvDau2;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					jZLyafAnMOLOoKpQSmPItlFuvDau2 = new UMYvkgdZUSokWVrcAeNgploQGWsBA(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping5 != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping5.eid_axisX) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this), (mapping5 != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping5.eid_axisY) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this), (mapping5 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping5.eid_button) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					jZLyafAnMOLOoKpQSmPItlFuvDau2 = new aivaqrAAxHJhrUTRiKkvNqwvuymX(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping3 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping3.eid_up) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this), (mapping3 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping3.eid_right) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this), (mapping3 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping3.eid_down) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this), (mapping3 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping3.eid_left) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this), (mapping3 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping3.eid_press) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					jZLyafAnMOLOoKpQSmPItlFuvDau2 = new LRhBXOZJxnEFguvDhssrogZRJjJi(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping2 != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping2.eid_axisX) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this), (mapping2 != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping2.eid_axisY) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this), (mapping2 != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping2.eid_axisZ) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					jZLyafAnMOLOoKpQSmPItlFuvDau2 = new vBDdnTNPNVZOOtvzAAOarwnzBWEl(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping6 != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping6.eid_axis) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this), (mapping6 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping6.eid_minDetent) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					jZLyafAnMOLOoKpQSmPItlFuvDau2 = new ObhkLsGJrEVTEKVVDnPkZtaHtqhA(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping7 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping7.eid_up) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this), (mapping7 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping7.eid_upRight) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this), (mapping7 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping7.eid_right) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this), (mapping7 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping7.eid_downRight) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this), (mapping7 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping7.eid_down) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this), (mapping7 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping7.eid_downLeft) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this), (mapping7 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping7.eid_left) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this), (mapping7 != null) ? rbPedOQTRWDyPatSqvGlXJYjvuNt(this, aDictionary, mapping7.eid_upLeft) : vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					jZLyafAnMOLOoKpQSmPItlFuvDau2 = new MPkkoimRsyjCUoFPeqAPjGweBzTcA(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping4 != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping4.eid_axisX) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this), (mapping4 != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping4.eid_axisZ) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					jZLyafAnMOLOoKpQSmPItlFuvDau2 = new sktCszCjIRrCOpcOeNeUlAzWMoGD(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping.eid_positionX) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this), (mapping != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping.eid_positionY) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this), (mapping != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping.eid_positionZ) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this), (mapping != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping.eid_rotationX) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this), (mapping != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping.eid_rotationY) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this), (mapping != null) ? RUrklwqrVsnbDqSNabiEJbjZLSsI(this, aDictionary, mapping.eid_rotationZ) : ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (jZLyafAnMOLOoKpQSmPItlFuvDau2 != null)
				{
					list4.Add(jZLyafAnMOLOoKpQSmPItlFuvDau2);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			AqcSKJaXJqooAEeUmiiNecvQvaXp = list.ToArray();
			gJTCefkAgBIUOGHqipkLOlGEVKJtb = aDictionary;
			NqhHtBDmxMtRczMhuemkDZHQvqOB = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < AqcSKJaXJqooAEeUmiiNecvQvaXp.Length; num++)
			{
				if (!(xaEmqjgGcteLAivBBPWQIriCLyHJ.GetTemplateElementIdentifierById(AqcSKJaXJqooAEeUmiiNecvQvaXp[num].id) is IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor))
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
							NqhHtBDmxMtRczMhuemkDZHQvqOB.Add(text, AqcSKJaXJqooAEeUmiiNecvQvaXp[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + aKTItJipeYeZuGvqMaMeDWcjshmD + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			qfuacnNbZJIfEzhHSXIGEqeCWrGh = new ReadOnlyCollection<IControllerTemplateElement>(AqcSKJaXJqooAEeUmiiNecvQvaXp);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			if (!gJTCefkAgBIUOGHqipkLOlGEVKJtb.TryGetValue(id, out var value))
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
			if (ReInput._id != hSuaxVFYJDHFYeYEKXUAFLNilPpaA)
			{
				ReInput.CheckInitialized(hSuaxVFYJDHFYeYEKXUAFLNilPpaA);
				return null;
			}
			return GetElement(id);
		}

		T IControllerTemplate.GetElement<T>(int id)
		{
			if (ReInput._id != hSuaxVFYJDHFYeYEKXUAFLNilPpaA)
			{
				ReInput.CheckInitialized(hSuaxVFYJDHFYeYEKXUAFLNilPpaA);
				return null;
			}
			return GetElement<T>(id);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget find, IList<ControllerTemplateElementTarget> results)
		{
			if (ReInput._id != hSuaxVFYJDHFYeYEKXUAFLNilPpaA)
			{
				ReInput.CheckInitialized(hSuaxVFYJDHFYeYEKXUAFLNilPpaA);
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
			for (int i = 0; i < AqcSKJaXJqooAEeUmiiNecvQvaXp.Length; i++)
			{
				if (InputTools.IsMappableType(AqcSKJaXJqooAEeUmiiNecvQvaXp[i].type))
				{
					num += (AqcSKJaXJqooAEeUmiiNecvQvaXp[i] as IControllerTemplateElement_Internal).GetElementTargets(find, ref results);
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

		private static IList<QETzMRjzzYQYeaadskeuXsXmfBnU> wfBVwBIRflBcRPRTJCjYycxdfOvc(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			if (P_1.splitAxis)
			{
				IList<QETzMRjzzYQYeaadskeuXsXmfBnU> list = null;
				bool flag = false;
				if (P_1.positiveTarget != null)
				{
					Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					if (elementById != null)
					{
						ListTools.AddAndCreateList(ref list, new QETzMRjzzYQYeaadskeuXsXmfBnU(P_1.positiveTarget, elementById));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, QETzMRjzzYQYeaadskeuXsXmfBnU.fmmDricCkSWFepyhNxxkibtZtUekA());
				}
				flag = false;
				if (P_1.negativeTarget != null)
				{
					Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
					if (elementById2 != null)
					{
						ListTools.AddAndCreateList(ref list, new QETzMRjzzYQYeaadskeuXsXmfBnU(P_1.negativeTarget, elementById2));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, QETzMRjzzYQYeaadskeuXsXmfBnU.fmmDricCkSWFepyhNxxkibtZtUekA());
				}
				return list;
			}
			return WxgHIkrPWYQKIHbvgguIEqCaVLfC(P_0, P_1.fullTarget);
		}

		private static IList<QETzMRjzzYQYeaadskeuXsXmfBnU> hXTbMHeiSyrvCNZjqOblxWFwhBAO(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return WxgHIkrPWYQKIHbvgguIEqCaVLfC(P_0, P_1.target);
		}

		private static IList<QETzMRjzzYQYeaadskeuXsXmfBnU> WxgHIkrPWYQKIHbvgguIEqCaVLfC(Controller P_0, IControllerElementTarget P_1)
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
			return new List<QETzMRjzzYQYeaadskeuXsXmfBnU>
			{
				new QETzMRjzzYQYeaadskeuXsXmfBnU(P_1, elementById)
			};
		}

		private static IControllerTemplateElement lKPRzBnLqQURHfpMwgvKTQrnNkWS(List<IControllerTemplateElement> P_0, int P_1)
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

		private static dTWDfcFBVnAVcJyBoQRJtBhGPIJpA RUrklwqrVsnbDqSNabiEJbjZLSsI(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is dTWDfcFBVnAVcJyBoQRJtBhGPIJpA result))
			{
				return ALIlRZqWkTBkkAHZHQmYqbXNsrSi.HzxMOCAjkbJEMwlsRuMOrwcCjcFP(P_0);
			}
			return result;
		}

		private static dTWDfcFBVnAVcJyBoQRJtBhGPIJpA rbPedOQTRWDyPatSqvGlXJYjvuNt(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is dTWDfcFBVnAVcJyBoQRJtBhGPIJpA result))
			{
				return vwUuAPdRDzqzTTVOaEwINNIQVTnc.avTyGagqgWiczcHbKHOxCSkcZlsS(P_0);
			}
			return result;
		}
	}
}
