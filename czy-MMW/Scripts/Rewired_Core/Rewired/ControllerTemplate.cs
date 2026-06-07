using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerTemplate : IControllerTemplate
	{
		internal abstract class KjkItrTgETDhGXlCPCIPYlRYkRKs : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate rOXdZHlITGffodsiuSirCyfmaBsAA;

			private readonly int somIObLJdcxpjibICwndGhTqiVLe;

			private readonly string GCukVgtWBpWWcLkCXcuAdBHnjxxW;

			private readonly ControllerTemplateElementType oUDYERPrTglzanKfbntNfvEAIUwi;

			protected readonly int zvZIjMiKlAxAsziFaDdmAcArqTxNA;

			int IControllerTemplateElement.id
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return -1;
					}
					return somIObLJdcxpjibICwndGhTqiVLe;
				}
			}

			string IControllerTemplateElement.descriptiveName
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return GCukVgtWBpWWcLkCXcuAdBHnjxxW;
				}
			}

			ControllerTemplateElementType IControllerTemplateElement.type
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return ControllerTemplateElementType.Axis;
					}
					return oUDYERPrTglzanKfbntNfvEAIUwi;
				}
			}

			IControllerTemplate IControllerTemplateElement_Internal.parent => rOXdZHlITGffodsiuSirCyfmaBsAA;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected KjkItrTgETDhGXlCPCIPYlRYkRKs(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				rOXdZHlITGffodsiuSirCyfmaBsAA = P_0;
				somIObLJdcxpjibICwndGhTqiVLe = P_1;
				GCukVgtWBpWWcLkCXcuAdBHnjxxW = P_2;
				oUDYERPrTglzanKfbntNfvEAIUwi = P_3;
				zvZIjMiKlAxAsziFaDdmAcArqTxNA = ReInput.id;
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);
		}

		internal abstract class QjljbeFjxgDuUwSWWkvNqcudzHPE : KjkItrTgETDhGXlCPCIPYlRYkRKs
		{
			protected readonly int zfPxpqUVwctdyzkmRrysEQsyeLY;

			protected readonly bQwslBiIrFIxKfqfzutdqnHIqPHR[] MVTfdfeultOdUHQvFhQuxrUTkjCcA;

			bool KjkItrTgETDhGXlCPCIPYlRYkRKs.exists
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return false;
					}
					if (MVTfdfeultOdUHQvFhQuxrUTkjCcA == null)
					{
						return false;
					}
					for (int i = 0; i < MVTfdfeultOdUHQvFhQuxrUTkjCcA.Length; i++)
					{
						if (MVTfdfeultOdUHQvFhQuxrUTkjCcA[i].mlhvrSEJVeaFUaHwhkqxBvHnCtUoA != null)
						{
							return true;
						}
					}
					return false;
				}
			}

			protected QjljbeFjxgDuUwSWWkvNqcudzHPE(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, IList<bQwslBiIrFIxKfqfzutdqnHIqPHR> P_4)
				: base(P_0, P_1, P_2, P_3)
			{
				MVTfdfeultOdUHQvFhQuxrUTkjCcA = ((P_4 != null) ? ListTools.ToArray(P_4) : null);
				zfPxpqUVwctdyzkmRrysEQsyeLY = ((MVTfdfeultOdUHQvFhQuxrUTkjCcA != null) ? MVTfdfeultOdUHQvFhQuxrUTkjCcA.Length : 0);
			}
		}

		internal abstract class EdxBDcAOTewPMnJBnAMWaxdgSMpm : QjljbeFjxgDuUwSWWkvNqcudzHPE, IControllerTemplateAxis, IControllerTemplateElement, IControllerTemplateButton
		{
			private agOACnagmLCXYWDIjyBWDOsYmPSu MPnrRZghnqwrhJmZlbKyUCiaDjYB;

			private string xpcojKLGmDTaAzJPmAUIxdBGdAxu;

			private string UOwKuHrlPTwVscWAGcLmonmvEpaaA;

			public float MVaEeOVqGKpciWxQdAsDsSMXKkbK
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return 0f;
					}
					if (zfPxpqUVwctdyzkmRrysEQsyeLY == 1)
					{
						return MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].pCjwlyixeimmtuOnjBLcodIVsuod;
					}
					if (zfPxpqUVwctdyzkmRrysEQsyeLY == 2)
					{
						float num = MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].pCjwlyixeimmtuOnjBLcodIVsuod;
						float num2 = MVTfdfeultOdUHQvFhQuxrUTkjCcA[1].pCjwlyixeimmtuOnjBLcodIVsuod;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public float EUurRBNNvCbKbgGLVmFiXfWcJeOE
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return 0f;
					}
					if (zfPxpqUVwctdyzkmRrysEQsyeLY == 1)
					{
						return MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].FyvmHZOqvIMDTRCVckNfkMKQeiCkA;
					}
					if (zfPxpqUVwctdyzkmRrysEQsyeLY == 2)
					{
						float num = MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].FyvmHZOqvIMDTRCVckNfkMKQeiCkA;
						float num2 = MVTfdfeultOdUHQvFhQuxrUTkjCcA[1].FyvmHZOqvIMDTRCVckNfkMKQeiCkA;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool mDljolEStZGBkHWDdGLUkHSobUxv
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return false;
					}
					if (zfPxpqUVwctdyzkmRrysEQsyeLY == 1)
					{
						return MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].nlDnJllWIfljlszExsaOwnkLNQQm;
					}
					if (zfPxpqUVwctdyzkmRrysEQsyeLY == 2)
					{
						if (!MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].nlDnJllWIfljlszExsaOwnkLNQQm)
						{
							return MVTfdfeultOdUHQvFhQuxrUTkjCcA[1].nlDnJllWIfljlszExsaOwnkLNQQm;
						}
						return true;
					}
					return false;
				}
			}

			public bool RqMAllTAZMaQoWOPqfAAaTZnSOXaA
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return false;
					}
					if (zfPxpqUVwctdyzkmRrysEQsyeLY == 1)
					{
						return MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].pPcWutHWbTAKTBkCJuzksxzvDiGd;
					}
					if (zfPxpqUVwctdyzkmRrysEQsyeLY == 2)
					{
						if (!MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].pPcWutHWbTAKTBkCJuzksxzvDiGd)
						{
							return MVTfdfeultOdUHQvFhQuxrUTkjCcA[1].pPcWutHWbTAKTBkCJuzksxzvDiGd;
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
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return xpcojKLGmDTaAzJPmAUIxdBGdAxu;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return UOwKuHrlPTwVscWAGcLmonmvEpaaA;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return 0f;
					}
					return MVaEeOVqGKpciWxQdAsDsSMXKkbK;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return 0f;
					}
					return EUurRBNNvCbKbgGLVmFiXfWcJeOE;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return MPnrRZghnqwrhJmZlbKyUCiaDjYB;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return false;
					}
					return mDljolEStZGBkHWDdGLUkHSobUxv;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return false;
					}
					return RqMAllTAZMaQoWOPqfAAaTZnSOXaA;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return false;
					}
					if (zfPxpqUVwctdyzkmRrysEQsyeLY == 1)
					{
						return MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].WsVSptTYpMfTaTAmcAwBADjWbuAmA;
					}
					if (zfPxpqUVwctdyzkmRrysEQsyeLY == 2)
					{
						if (!MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].WsVSptTYpMfTaTAmcAwBADjWbuAmA || MVTfdfeultOdUHQvFhQuxrUTkjCcA[1].pPcWutHWbTAKTBkCJuzksxzvDiGd)
						{
							if (MVTfdfeultOdUHQvFhQuxrUTkjCcA[1].WsVSptTYpMfTaTAmcAwBADjWbuAmA)
							{
								return !MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].pPcWutHWbTAKTBkCJuzksxzvDiGd;
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
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return false;
					}
					if (zfPxpqUVwctdyzkmRrysEQsyeLY == 1)
					{
						return MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].fwGdIhvOVnIjkFEQxRxaoiQAsGle;
					}
					if (zfPxpqUVwctdyzkmRrysEQsyeLY == 2)
					{
						if (!MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].fwGdIhvOVnIjkFEQxRxaoiQAsGle || MVTfdfeultOdUHQvFhQuxrUTkjCcA[1].nlDnJllWIfljlszExsaOwnkLNQQm)
						{
							if (MVTfdfeultOdUHQvFhQuxrUTkjCcA[1].fwGdIhvOVnIjkFEQxRxaoiQAsGle)
							{
								return !MVTfdfeultOdUHQvFhQuxrUTkjCcA[0].nlDnJllWIfljlszExsaOwnkLNQQm;
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
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return false;
					}
					return mDljolEStZGBkHWDdGLUkHSobUxv != RqMAllTAZMaQoWOPqfAAaTZnSOXaA;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return 0f;
					}
					return MVaEeOVqGKpciWxQdAsDsSMXKkbK;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return 0f;
					}
					return EUurRBNNvCbKbgGLVmFiXfWcJeOE;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return MPnrRZghnqwrhJmZlbKyUCiaDjYB;
				}
			}

			IControllerTemplateElementSource KjkItrTgETDhGXlCPCIPYlRYkRKs.source
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return MPnrRZghnqwrhJmZlbKyUCiaDjYB;
				}
			}

			int KjkItrTgETDhGXlCPCIPYlRYkRKs.elementCount => 0;

			IControllerTemplateAxis IControllerTemplateButton.AsAxis
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return this;
				}
			}

			IControllerTemplateButton IControllerTemplateAxis.AsButton
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return this;
				}
			}

			protected EdxBDcAOTewPMnJBnAMWaxdgSMpm(IControllerTemplate P_0, int P_1, string P_2, string P_3, string P_4, ControllerTemplateElementType P_5, agOACnagmLCXYWDIjyBWDOsYmPSu P_6, IList<bQwslBiIrFIxKfqfzutdqnHIqPHR> P_7)
				: base(P_0, P_1, P_2, P_5, P_7)
			{
				if (P_7 != null && P_7.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
				if (P_6 == null)
				{
					throw new ArgumentNullException("target");
				}
				MPnrRZghnqwrhJmZlbKyUCiaDjYB = P_6;
				xpcojKLGmDTaAzJPmAUIxdBGdAxu = P_3;
				UOwKuHrlPTwVscWAGcLmonmvEpaaA = P_4;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange axisRange)
			{
				if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
				{
					ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
					return null;
				}
				return axisRange switch
				{
					AxisRange.Full => base.Rewired_002EIControllerTemplateElement_002EdescriptiveName, 
					AxisRange.Positive => xpcojKLGmDTaAzJPmAUIxdBGdAxu, 
					AxisRange.Negative => UOwKuHrlPTwVscWAGcLmonmvEpaaA, 
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
					IControllerTemplateAxisSource mPnrRZghnqwrhJmZlbKyUCiaDjYB = MPnrRZghnqwrhJmZlbKyUCiaDjYB;
					if (mPnrRZghnqwrhJmZlbKyUCiaDjYB.splitAxis)
					{
						if (BXqPzMDMnMcVpHUQxdAUjhbgRkmM(find, mPnrRZghnqwrhJmZlbKyUCiaDjYB.positiveTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
							num++;
						}
						if (BXqPzMDMnMcVpHUQxdAUjhbgRkmM(find, mPnrRZghnqwrhJmZlbKyUCiaDjYB.negativeTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
							num++;
						}
					}
					else if (BXqPzMDMnMcVpHUQxdAUjhbgRkmM(find, mPnrRZghnqwrhJmZlbKyUCiaDjYB.fullTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
						num++;
					}
					break;
				}
				case ControllerTemplateElementType.Button:
					if (BXqPzMDMnMcVpHUQxdAUjhbgRkmM(find, ((IControllerTemplateButtonSource)MPnrRZghnqwrhJmZlbKyUCiaDjYB).target))
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

			private static bool BXqPzMDMnMcVpHUQxdAUjhbgRkmM(ControllerElementTarget P_0, IControllerElementTarget P_1)
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

		internal sealed class pcfAHFaxuOIaSSNFKLLVSZBlNqiqA : EdxBDcAOTewPMnJBnAMWaxdgSMpm
		{
			public pcfAHFaxuOIaSSNFKLLVSZBlNqiqA(IControllerTemplate P_0, int P_1, string P_2, string P_3, string P_4, agOACnagmLCXYWDIjyBWDOsYmPSu P_5, IList<bQwslBiIrFIxKfqfzutdqnHIqPHR> P_6)
				: base(P_0, P_1, P_2, P_3, P_4, ControllerTemplateElementType.Axis, P_5, P_6)
			{
				if (P_6 != null && P_6.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static pcfAHFaxuOIaSSNFKLLVSZBlNqiqA AOQbbjbEkogjuPOUBVTDWRRPYlTv(IControllerTemplate P_0)
			{
				return new pcfAHFaxuOIaSSNFKLLVSZBlNqiqA(P_0, -1, string.Empty, string.Empty, string.Empty, agOACnagmLCXYWDIjyBWDOsYmPSu.zixJGzEXzPtVLUqRvkHLoUbTNSVv(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class KMTQEAmoRKaNLYXDHJFhkoVwjZzt : EdxBDcAOTewPMnJBnAMWaxdgSMpm
		{
			public KMTQEAmoRKaNLYXDHJFhkoVwjZzt(IControllerTemplate P_0, int P_1, string P_2, string P_3, string P_4, agOACnagmLCXYWDIjyBWDOsYmPSu P_5, IList<bQwslBiIrFIxKfqfzutdqnHIqPHR> P_6)
				: base(P_0, P_1, P_2, P_3, P_4, ControllerTemplateElementType.Button, P_5, P_6)
			{
				if (P_6 != null && P_6.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static KMTQEAmoRKaNLYXDHJFhkoVwjZzt eySuMxHGfHDMzFKBAppypupOHwqdb(IControllerTemplate P_0)
			{
				return new KMTQEAmoRKaNLYXDHJFhkoVwjZzt(P_0, -1, string.Empty, string.Empty, string.Empty, agOACnagmLCXYWDIjyBWDOsYmPSu.zixJGzEXzPtVLUqRvkHLoUbTNSVv(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class iqJylVEsYhiKASjLLqckMSToPAzI : KjkItrTgETDhGXlCPCIPYlRYkRKs
		{
			protected readonly int XiddUNvMQgsilKZUenVPScSCtwvo;

			protected readonly KjkItrTgETDhGXlCPCIPYlRYkRKs[] TGimjTBjgEAHnEMTQVINgbqGdaMC;

			bool KjkItrTgETDhGXlCPCIPYlRYkRKs.exists
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return false;
					}
					for (int i = 0; i < XiddUNvMQgsilKZUenVPScSCtwvo; i++)
					{
						if (TGimjTBjgEAHnEMTQVINgbqGdaMC[i].exists)
						{
							return true;
						}
					}
					return false;
				}
			}

			IControllerTemplateElementSource KjkItrTgETDhGXlCPCIPYlRYkRKs.source
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return null;
				}
			}

			int KjkItrTgETDhGXlCPCIPYlRYkRKs.elementCount => XiddUNvMQgsilKZUenVPScSCtwvo;

			protected iqJylVEsYhiKASjLLqckMSToPAzI(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, KjkItrTgETDhGXlCPCIPYlRYkRKs[] P_4)
				: base(P_0, P_1, P_2, P_3)
			{
				if (P_4 == null)
				{
					throw new ArgumentNullException("elements");
				}
				if (P_4.Length == 0)
				{
					throw new ArgumentException("elements.Length is zero.");
				}
				for (int i = 0; i < P_4.Length; i++)
				{
					if (P_4[i] == null)
					{
						throw new ArgumentNullException("elements contains a null entry.");
					}
				}
				TGimjTBjgEAHnEMTQVINgbqGdaMC = P_4;
				XiddUNvMQgsilKZUenVPScSCtwvo = P_4.Length;
			}

			public virtual IControllerTemplateElement FtLEIAHmtwoGyJiTmBGmjgJqOiZC(int P_0)
			{
				return TGimjTBjgEAHnEMTQVINgbqGdaMC[P_0];
			}

			public virtual int vgMHUAMaFBxkxLQsgiZLGVHRUcIh(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				for (int i = 0; i < TGimjTBjgEAHnEMTQVINgbqGdaMC.Length; i++)
				{
					num += TGimjTBjgEAHnEMTQVINgbqGdaMC[i].GetElementTargets(P_0, ref P_1);
				}
				return num;
			}
		}

		internal abstract class QhcKovROmWdRtullxqokutHJMKVF : iqJylVEsYhiKASjLLqckMSToPAzI, IControllerTemplateAxis2D, IControllerTemplateElement
		{
			protected const int EseDLihUYzkyVsFbBqyTVFlpkDLL = 0;

			protected const int vSWNFiSKqByBUepoOZSLHLeCmIvI = 1;

			protected const int IgNVOyTyzLgkshShnIzppRZtovpy = 2;

			Vector2 IControllerTemplateAxis2D.value
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return Vector2.zero;
					}
					return new Vector2((XiddUNvMQgsilKZUenVPScSCtwvo > 0) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[0]).MVaEeOVqGKpciWxQdAsDsSMXKkbK : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 1) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[1]).MVaEeOVqGKpciWxQdAsDsSMXKkbK : 0f);
				}
			}

			Vector2 IControllerTemplateAxis2D.valuePrev
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return Vector2.zero;
					}
					return new Vector2((XiddUNvMQgsilKZUenVPScSCtwvo > 0) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[0]).EUurRBNNvCbKbgGLVmFiXfWcJeOE : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 1) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[1]).EUurRBNNvCbKbgGLVmFiXfWcJeOE : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.horizontal
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.vertical
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[1];
				}
			}

			protected QhcKovROmWdRtullxqokutHJMKVF(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, KjkItrTgETDhGXlCPCIPYlRYkRKs[] P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class QPeTBCdONqsuSPlohGvXGuxYNzyHA : iqJylVEsYhiKASjLLqckMSToPAzI, IControllerTemplateAxis3D, IControllerTemplateElement
		{
			protected const int PdrqTBuCGKAHnajkXoMrBIXfeFLg = 0;

			protected const int nqLrwtfyZSlgPZPIdLYhqsrryDqK = 1;

			protected const int TmSyoajOENHvafyMiIHiqqJqpAhkA = 2;

			protected const int EOZayXLbOFiuipQABbKHXNPsVFUE = 3;

			Vector3 IControllerTemplateAxis3D.value
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return Vector3.zero;
					}
					return new Vector3((XiddUNvMQgsilKZUenVPScSCtwvo > 0) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[0]).MVaEeOVqGKpciWxQdAsDsSMXKkbK : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 1) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[1]).MVaEeOVqGKpciWxQdAsDsSMXKkbK : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 2) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[2]).MVaEeOVqGKpciWxQdAsDsSMXKkbK : 0f);
				}
			}

			Vector3 IControllerTemplateAxis3D.valuePrev
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return Vector3.zero;
					}
					return new Vector3((XiddUNvMQgsilKZUenVPScSCtwvo > 0) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[0]).EUurRBNNvCbKbgGLVmFiXfWcJeOE : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 1) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[1]).EUurRBNNvCbKbgGLVmFiXfWcJeOE : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 2) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[2]).EUurRBNNvCbKbgGLVmFiXfWcJeOE : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.horizontal
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.vertical
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.depth
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[2];
				}
			}

			protected QPeTBCdONqsuSPlohGvXGuxYNzyHA(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, KjkItrTgETDhGXlCPCIPYlRYkRKs[] P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class qXQYjMUfMIbwICzeYaAqsKukDayx : iqJylVEsYhiKASjLLqckMSToPAzI, IControllerTemplateAxis6D, IControllerTemplateElement
		{
			protected const int zlFLDaMHUklPOemKUnkODcTcjfxT = 0;

			protected const int CwHhBXoQVnslzHYlBUbTqVxPtaWr = 1;

			protected const int mEEYqoUwBjxakFnRUwlAbuLBueTv = 2;

			protected const int HOGNhaJOzIUhcdHjKSHWbocQKLRp = 3;

			protected const int WoCAOBchzBGfkHcerPpypOYMBOwd = 4;

			protected const int DHzcvLgjceQDVGYjLCieUBXAZhYTA = 5;

			protected const int rOKGyuoghMQiGOnkRDLjLqgqSkrU = 6;

			Vector3 IControllerTemplateAxis6D.position
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return Vector3.zero;
					}
					return new Vector3((XiddUNvMQgsilKZUenVPScSCtwvo > 0) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[0]).MVaEeOVqGKpciWxQdAsDsSMXKkbK : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 1) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[1]).MVaEeOVqGKpciWxQdAsDsSMXKkbK : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 2) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[2]).MVaEeOVqGKpciWxQdAsDsSMXKkbK : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.positionPrev
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return Vector3.zero;
					}
					return new Vector3((XiddUNvMQgsilKZUenVPScSCtwvo > 0) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[0]).EUurRBNNvCbKbgGLVmFiXfWcJeOE : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 1) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[1]).EUurRBNNvCbKbgGLVmFiXfWcJeOE : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 2) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[2]).EUurRBNNvCbKbgGLVmFiXfWcJeOE : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotation
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return Vector3.zero;
					}
					return new Vector3((XiddUNvMQgsilKZUenVPScSCtwvo > 3) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[3]).MVaEeOVqGKpciWxQdAsDsSMXKkbK : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 4) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[4]).MVaEeOVqGKpciWxQdAsDsSMXKkbK : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 5) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[5]).MVaEeOVqGKpciWxQdAsDsSMXKkbK : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotationPrev
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return Vector3.zero;
					}
					return new Vector3((XiddUNvMQgsilKZUenVPScSCtwvo > 3) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[3]).EUurRBNNvCbKbgGLVmFiXfWcJeOE : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 4) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[4]).EUurRBNNvCbKbgGLVmFiXfWcJeOE : 0f, (XiddUNvMQgsilKZUenVPScSCtwvo > 5) ? ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[5]).EUurRBNNvCbKbgGLVmFiXfWcJeOE : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionX
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionY
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionZ
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[2];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationX
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[3];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationY
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[4];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationZ
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[5];
				}
			}

			protected qXQYjMUfMIbwICzeYaAqsKukDayx(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, KjkItrTgETDhGXlCPCIPYlRYkRKs[] P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal sealed class yiQFtWGYnkwxUorNoZbcaXZpmBfNA : QPeTBCdONqsuSPlohGvXGuxYNzyHA, IControllerTemplateStick, IControllerTemplateElement
		{
			private const int JoLAEhFMzXkTBBdKgtdUOBQwilksb = 3;

			IControllerTemplateAxis IControllerTemplateStick.rotation
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[2];
				}
			}

			private yiQFtWGYnkwxUorNoZbcaXZpmBfNA(IControllerTemplate P_0, int P_1, string P_2, KjkItrTgETDhGXlCPCIPYlRYkRKs[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Stick, P_3)
			{
				if (P_3.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			public yiQFtWGYnkwxUorNoZbcaXZpmBfNA(IControllerTemplate P_0, int P_1, string P_2, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_3, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_4, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_5)
				: this(P_0, P_1, P_2, new KjkItrTgETDhGXlCPCIPYlRYkRKs[3] { P_3, P_4, P_5 })
			{
			}
		}

		internal sealed class zVnbYkuSULlLgAlgHlCnWIwwtEYO : QhcKovROmWdRtullxqokutHJMKVF, IControllerTemplateThumbStick, IControllerTemplateElement
		{
			private const int KvKZBkfOAtXlHnrcSedXPkNLhyqX = 2;

			private const int MsaVnvRVPzBvjrMdNgtgQgAwFxUf = 3;

			IControllerTemplateButton IControllerTemplateThumbStick.press
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[2];
				}
			}

			private zVnbYkuSULlLgAlgHlCnWIwwtEYO(IControllerTemplate P_0, int P_1, string P_2, KjkItrTgETDhGXlCPCIPYlRYkRKs[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.ThumbStick, P_3)
			{
				if (P_3.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal zVnbYkuSULlLgAlgHlCnWIwwtEYO(IControllerTemplate P_0, int P_1, string P_2, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_3, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_4, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_5)
				: this(P_0, P_1, P_2, new KjkItrTgETDhGXlCPCIPYlRYkRKs[3] { P_3, P_4, P_5 })
			{
			}
		}

		internal sealed class DTUWgzLNjYAsLSENhzluLdeLqTEh : iqJylVEsYhiKASjLLqckMSToPAzI, IControllerTemplateDPad, IControllerTemplateElement
		{
			private const int mZiKsvBBuOtTmAPdhQgchgsLflUDA = 0;

			private const int uHFFHVnLzfCcaxVvHzQPtVSQVnR = 1;

			private const int EmPYJtSMObJpdbuCIsuQEZcqEFDd = 2;

			private const int LXkjjmeidLNPnoEGpCpSQgCRGIpk = 3;

			private const int cxhVfrKlcsdqSmdtXBiwkbdRKaHj = 4;

			private const int vqfXLePnlWFFvJFdPeNqAkidBZeqA = 5;

			Vector2 IControllerTemplateDPad.value
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[0]).MVaEeOVqGKpciWxQdAsDsSMXKkbK + ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[2]).MVaEeOVqGKpciWxQdAsDsSMXKkbK * -1f, -1f, 1f), MathTools.Clamp(((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[3]).MVaEeOVqGKpciWxQdAsDsSMXKkbK * -1f + ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[1]).MVaEeOVqGKpciWxQdAsDsSMXKkbK, -1f, 1f));
				}
			}

			Vector2 IControllerTemplateDPad.valuePrev
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[0]).EUurRBNNvCbKbgGLVmFiXfWcJeOE + ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[2]).EUurRBNNvCbKbgGLVmFiXfWcJeOE * -1f, -1f, 1f), MathTools.Clamp(((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[3]).EUurRBNNvCbKbgGLVmFiXfWcJeOE * -1f + ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[1]).EUurRBNNvCbKbgGLVmFiXfWcJeOE, -1f, 1f));
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.up
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[0];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.right
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[1];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.down
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[2];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.left
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[3];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.press
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[4];
				}
			}

			private DTUWgzLNjYAsLSENhzluLdeLqTEh(IControllerTemplate P_0, int P_1, string P_2, KjkItrTgETDhGXlCPCIPYlRYkRKs[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.DPad, P_3)
			{
				if (P_3.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal DTUWgzLNjYAsLSENhzluLdeLqTEh(IControllerTemplate P_0, int P_1, string P_2, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_3, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_4, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_5, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_6, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_7)
				: this(P_0, P_1, P_2, new KjkItrTgETDhGXlCPCIPYlRYkRKs[5] { P_3, P_4, P_5, P_6, P_7 })
			{
			}
		}

		internal sealed class AOmTPRSMVAJxwyYlDPVvKwzLlLiQ : iqJylVEsYhiKASjLLqckMSToPAzI, IControllerTemplateThrottle, IControllerTemplateElement
		{
			private const int eWlRgMKfTCNVgjFHGhGAZhDVYQYT = 0;

			private const int qFINTkdlwRRETaGRUpFbKNxaFIVH = 1;

			private const int yEcmVTVYchxJEnfulBRFzbIKANPA = 2;

			float IControllerTemplateThrottle.value
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return 0f;
					}
					return ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[0]).MVaEeOVqGKpciWxQdAsDsSMXKkbK;
				}
			}

			float IControllerTemplateThrottle.valuePrev
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return 0f;
					}
					return ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[0]).EUurRBNNvCbKbgGLVmFiXfWcJeOE;
				}
			}

			IControllerTemplateAxis IControllerTemplateThrottle.throttle
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[0];
				}
			}

			IControllerTemplateButton IControllerTemplateThrottle.minDetent
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[1];
				}
			}

			private AOmTPRSMVAJxwyYlDPVvKwzLlLiQ(IControllerTemplate P_0, int P_1, string P_2, KjkItrTgETDhGXlCPCIPYlRYkRKs[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Throttle, P_3)
			{
				if (P_3.Length != 2)
				{
					throw new ArgumentException("elements.Length must be " + 2);
				}
			}

			internal AOmTPRSMVAJxwyYlDPVvKwzLlLiQ(IControllerTemplate P_0, int P_1, string P_2, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_3, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_4)
				: this(P_0, P_1, P_2, new KjkItrTgETDhGXlCPCIPYlRYkRKs[2] { P_3, P_4 })
			{
			}
		}

		internal sealed class lTUnBFvZDuKwlHhTKTaAkThMMhGy : iqJylVEsYhiKASjLLqckMSToPAzI, IControllerTemplateHat, IControllerTemplateElement
		{
			private const int fMrYXgMsbCwajkOkJlAkBISvhMeC = 0;

			private const int LOeoYRHKtwOkSGVwkdVMCPNYfAm = 1;

			private const int LcSQSCBaPXcGaWgRbCVwKYMFaVHc = 2;

			private const int UGgbAkjXCzrVbOeEaVtAjVsmFGMJ = 3;

			private const int citBeXgjhqTSYczQOqtXWFPHwbaR = 4;

			private const int IqabBzEBmFVcIeAqsHAEXEpuvKAq = 5;

			private const int QrTsWCdeLDWNEnkYWZccGyMDvHhc = 6;

			private const int nEfCNwPVQHddgoWFNPfGsTBQjAxV = 7;

			private const int OSjRtJiVrHrSSwaggOqnaPFZFaYdA = 8;

			Vector2 IControllerTemplateHat.value
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[0]).MVaEeOVqGKpciWxQdAsDsSMXKkbK;
					result.x += ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[2]).MVaEeOVqGKpciWxQdAsDsSMXKkbK;
					result.y -= ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[4]).MVaEeOVqGKpciWxQdAsDsSMXKkbK;
					result.x -= ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[6]).MVaEeOVqGKpciWxQdAsDsSMXKkbK;
					float num = ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[1]).MVaEeOVqGKpciWxQdAsDsSMXKkbK;
					float num2 = ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[3]).MVaEeOVqGKpciWxQdAsDsSMXKkbK;
					float num3 = ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[5]).MVaEeOVqGKpciWxQdAsDsSMXKkbK;
					float num4 = ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[7]).MVaEeOVqGKpciWxQdAsDsSMXKkbK;
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
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[0]).EUurRBNNvCbKbgGLVmFiXfWcJeOE;
					result.x += ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[2]).EUurRBNNvCbKbgGLVmFiXfWcJeOE;
					result.y -= ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[4]).EUurRBNNvCbKbgGLVmFiXfWcJeOE;
					result.x -= ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[6]).EUurRBNNvCbKbgGLVmFiXfWcJeOE;
					float num = ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[1]).EUurRBNNvCbKbgGLVmFiXfWcJeOE;
					float num2 = ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[3]).EUurRBNNvCbKbgGLVmFiXfWcJeOE;
					float num3 = ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[5]).EUurRBNNvCbKbgGLVmFiXfWcJeOE;
					float num4 = ((EdxBDcAOTewPMnJBnAMWaxdgSMpm)TGimjTBjgEAHnEMTQVINgbqGdaMC[7]).EUurRBNNvCbKbgGLVmFiXfWcJeOE;
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
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[0];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upRight
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[1];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.right
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[2];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downRight
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[3];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.down
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[4];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downLeft
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[5];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.left
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[6];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upLeft
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateButton)TGimjTBjgEAHnEMTQVINgbqGdaMC[7];
				}
			}

			private lTUnBFvZDuKwlHhTKTaAkThMMhGy(IControllerTemplate P_0, int P_1, string P_2, KjkItrTgETDhGXlCPCIPYlRYkRKs[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Hat, P_3)
			{
				if (P_3.Length != 8)
				{
					throw new ArgumentException("elements.Length must be " + 8);
				}
			}

			internal lTUnBFvZDuKwlHhTKTaAkThMMhGy(IControllerTemplate P_0, int P_1, string P_2, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_3, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_4, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_5, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_6, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_7, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_8, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_9, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_10)
				: this(P_0, P_1, P_2, new KjkItrTgETDhGXlCPCIPYlRYkRKs[8] { P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10 })
			{
			}
		}

		internal sealed class hbHMHmrbatnuobqVnZhMOAyUBhhQ : QhcKovROmWdRtullxqokutHJMKVF, IControllerTemplateYoke, IControllerTemplateElement
		{
			private const int wdWxyJhBSTIDNDEhSdVTAeUCDorX = 2;

			IControllerTemplateAxis IControllerTemplateYoke.rotation
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateYoke.pushPull
			{
				get
				{
					if (ReInput._id != zvZIjMiKlAxAsziFaDdmAcArqTxNA)
					{
						ReInput.CheckInitialized(zvZIjMiKlAxAsziFaDdmAcArqTxNA);
						return null;
					}
					return (IControllerTemplateAxis)TGimjTBjgEAHnEMTQVINgbqGdaMC[1];
				}
			}

			private hbHMHmrbatnuobqVnZhMOAyUBhhQ(IControllerTemplate P_0, int P_1, string P_2, KjkItrTgETDhGXlCPCIPYlRYkRKs[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Yoke, P_3)
			{
			}

			internal hbHMHmrbatnuobqVnZhMOAyUBhhQ(IControllerTemplate P_0, int P_1, string P_2, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_3, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_4)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Yoke, new KjkItrTgETDhGXlCPCIPYlRYkRKs[2] { P_3, P_4 })
			{
			}
		}

		internal sealed class DySHkjLOpGvUskPuzBAHYNMchAgeA : qXQYjMUfMIbwICzeYaAqsKukDayx, IControllerTemplateStick6D, IControllerTemplateElement
		{
			private const int GisChnEKxMgWNIjyBkFCCRAfgrKxb = 6;

			private DySHkjLOpGvUskPuzBAHYNMchAgeA(IControllerTemplate P_0, int P_1, string P_2, KjkItrTgETDhGXlCPCIPYlRYkRKs[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Stick6D, P_3)
			{
			}

			internal DySHkjLOpGvUskPuzBAHYNMchAgeA(IControllerTemplate P_0, int P_1, string P_2, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_3, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_4, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_5, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_6, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_7, EdxBDcAOTewPMnJBnAMWaxdgSMpm P_8)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Stick6D, new KjkItrTgETDhGXlCPCIPYlRYkRKs[6] { P_3, P_4, P_5, P_6, P_7, P_8 })
			{
			}
		}

		internal class bQwslBiIrFIxKfqfzutdqnHIqPHR
		{
			public readonly Controller.Element mlhvrSEJVeaFUaHwhkqxBvHnCtUoA;

			public readonly IControllerElementTarget vALgSBAtEiWoYGLjnABsiOmtENX;

			public bool nlDnJllWIfljlszExsaOwnkLNQQm
			{
				get
				{
					if (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA == null)
					{
						return false;
					}
					switch (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA.type)
					{
					case ControllerElementType.Button:
						return (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA as Controller.Button).value;
					case ControllerElementType.Axis:
					{
						float value = (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA as Controller.Axis).value;
						switch (vALgSBAtEiWoYGLjnABsiOmtENX.axisRange)
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

			public bool pPcWutHWbTAKTBkCJuzksxzvDiGd
			{
				get
				{
					if (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA == null)
					{
						return false;
					}
					switch (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA.type)
					{
					case ControllerElementType.Button:
						return (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA as Controller.Button).valuePrev;
					case ControllerElementType.Axis:
					{
						float valuePrev = (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA as Controller.Axis).valuePrev;
						switch (vALgSBAtEiWoYGLjnABsiOmtENX.axisRange)
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

			public bool WsVSptTYpMfTaTAmcAwBADjWbuAmA
			{
				get
				{
					if (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA == null)
					{
						return false;
					}
					switch (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA.type)
					{
					case ControllerElementType.Button:
						return (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA as Controller.Button).justPressed;
					case ControllerElementType.Axis:
						if (MathTools.Abs(pCjwlyixeimmtuOnjBLcodIVsuod) > 0.01f && MathTools.Abs(FyvmHZOqvIMDTRCVckNfkMKQeiCkA) <= 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public bool fwGdIhvOVnIjkFEQxRxaoiQAsGle
			{
				get
				{
					if (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA == null)
					{
						return false;
					}
					switch (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA.type)
					{
					case ControllerElementType.Button:
						return (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA as Controller.Button).justReleased;
					case ControllerElementType.Axis:
						if (MathTools.Abs(pCjwlyixeimmtuOnjBLcodIVsuod) <= 0.01f && MathTools.Abs(FyvmHZOqvIMDTRCVckNfkMKQeiCkA) > 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public float pCjwlyixeimmtuOnjBLcodIVsuod
			{
				get
				{
					if (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA == null)
					{
						return 0f;
					}
					switch (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA.type)
					{
					case ControllerElementType.Button:
						if (!(mlhvrSEJVeaFUaHwhkqxBvHnCtUoA as Controller.Button).value)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float value = (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA as Controller.Axis).value;
						switch (vALgSBAtEiWoYGLjnABsiOmtENX.axisRange)
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

			public float FyvmHZOqvIMDTRCVckNfkMKQeiCkA
			{
				get
				{
					if (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA == null)
					{
						return 0f;
					}
					switch (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA.type)
					{
					case ControllerElementType.Button:
						if (!(mlhvrSEJVeaFUaHwhkqxBvHnCtUoA as Controller.Button).valuePrev)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float valuePrev = (mlhvrSEJVeaFUaHwhkqxBvHnCtUoA as Controller.Axis).valuePrev;
						switch (vALgSBAtEiWoYGLjnABsiOmtENX.axisRange)
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

			public bQwslBiIrFIxKfqfzutdqnHIqPHR(IControllerElementTarget P_0, Controller.Element P_1)
			{
				mlhvrSEJVeaFUaHwhkqxBvHnCtUoA = P_1;
				vALgSBAtEiWoYGLjnABsiOmtENX = P_0;
			}

			public static bQwslBiIrFIxKfqfzutdqnHIqPHR KWHTEcRjwRcyIdVfGpkbEDbblSEO()
			{
				return new bQwslBiIrFIxKfqfzutdqnHIqPHR(VpAKgrswCxoCdmGxzoexhctSYmGI.BAgYxiMqyGCojQPffpTNQctlDIrW(), null);
			}
		}

		internal class FuaTwFFsfWMPiruAlXyhgAnoRaLH
		{
			public readonly Controller NjUBGvqPozmjvNHCECVQeLvPFjxn;

			public readonly IHardwareControllerTemplateMap_Internal cnjFEzxeosxVclJRIEYZCfyuqFjHA;

			public FuaTwFFsfWMPiruAlXyhgAnoRaLH(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				NjUBGvqPozmjvNHCECVQeLvPFjxn = P_0;
				cnjFEzxeosxVclJRIEYZCfyuqFjHA = P_1;
			}
		}

		private readonly string DauteblfdDMJxVylVOpXsQWBsiKL;

		private readonly Guid ngTdhBCuBMQQLFyjZTUfvaLZvhWQ;

		private readonly Controller jEFWBRErhHbKSaFVumnIvqWFTWtl;

		private readonly ADictionary<int, IControllerTemplateElement> NusOtzVmaKpqqApyorFEUnAdQRdj;

		private readonly ADictionary<string, IControllerTemplateElement> ibZqvlSsqsKAlwqKdIlzggVeSnCT;

		private IControllerTemplateElement[] nfPxwXjaHfgTwFZMtbpAYZzqhcxKA;

		private ReadOnlyCollection<IControllerTemplateElement> ZvZIUfWqPOpbgkVFVLWLtdaeXMsN;

		private readonly int GCTVuRHoHUgWcTVKZPdVsrXSJJJh;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != GCTVuRHoHUgWcTVKZPdVsrXSJJJh)
				{
					ReInput.CheckInitialized(GCTVuRHoHUgWcTVKZPdVsrXSJJJh);
					return null;
				}
				return jEFWBRErhHbKSaFVumnIvqWFTWtl;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != GCTVuRHoHUgWcTVKZPdVsrXSJJJh)
				{
					ReInput.CheckInitialized(GCTVuRHoHUgWcTVKZPdVsrXSJJJh);
					return null;
				}
				return DauteblfdDMJxVylVOpXsQWBsiKL;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != GCTVuRHoHUgWcTVKZPdVsrXSJJJh)
				{
					ReInput.CheckInitialized(GCTVuRHoHUgWcTVKZPdVsrXSJJJh);
					return Guid.Empty;
				}
				return ngTdhBCuBMQQLFyjZTUfvaLZvhWQ;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != GCTVuRHoHUgWcTVKZPdVsrXSJJJh)
				{
					ReInput.CheckInitialized(GCTVuRHoHUgWcTVKZPdVsrXSJJJh);
					return null;
				}
				return ZvZIUfWqPOpbgkVFVLWLtdaeXMsN;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != GCTVuRHoHUgWcTVKZPdVsrXSJJJh)
				{
					ReInput.CheckInitialized(GCTVuRHoHUgWcTVKZPdVsrXSJJJh);
					return 0;
				}
				return nfPxwXjaHfgTwFZMtbpAYZzqhcxKA.Length;
			}
		}

		protected ControllerTemplate(object P_0)
			: this((FuaTwFFsfWMPiruAlXyhgAnoRaLH)P_0)
		{
		}

		private ControllerTemplate(FuaTwFFsfWMPiruAlXyhgAnoRaLH P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (P_0.NjUBGvqPozmjvNHCECVQeLvPFjxn == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (P_0.cnjFEzxeosxVclJRIEYZCfyuqFjHA == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			GCTVuRHoHUgWcTVKZPdVsrXSJJJh = ReInput.id;
			jEFWBRErhHbKSaFVumnIvqWFTWtl = P_0.NjUBGvqPozmjvNHCECVQeLvPFjxn;
			IHardwareControllerTemplateMap_Internal cnjFEzxeosxVclJRIEYZCfyuqFjHA = P_0.cnjFEzxeosxVclJRIEYZCfyuqFjHA;
			DauteblfdDMJxVylVOpXsQWBsiKL = cnjFEzxeosxVclJRIEYZCfyuqFjHA.name;
			ngTdhBCuBMQQLFyjZTUfvaLZvhWQ = cnjFEzxeosxVclJRIEYZCfyuqFjHA.typeGuid;
			int elementIdentifierCount = cnjFEzxeosxVclJRIEYZCfyuqFjHA.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = cnjFEzxeosxVclJRIEYZCfyuqFjHA.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						agOACnagmLCXYWDIjyBWDOsYmPSu agOACnagmLCXYWDIjyBWDOsYmPSu3 = cnjFEzxeosxVclJRIEYZCfyuqFjHA.GetAxisTarget(jEFWBRErhHbKSaFVumnIvqWFTWtl, templateElementIdentifier.id) ?? agOACnagmLCXYWDIjyBWDOsYmPSu.zixJGzEXzPtVLUqRvkHLoUbTNSVv(ControllerTemplateElementType.Axis);
						pcfAHFaxuOIaSSNFKLLVSZBlNqiqA item2 = new pcfAHFaxuOIaSSNFKLLVSZBlNqiqA(this, templateElementIdentifier.id, templateElementIdentifier.name, (!string.IsNullOrEmpty(templateElementIdentifier.positiveName)) ? templateElementIdentifier.positiveName : (templateElementIdentifier.name + " +"), (!string.IsNullOrEmpty(templateElementIdentifier.negativeName)) ? templateElementIdentifier.negativeName : (templateElementIdentifier.name + " -"), agOACnagmLCXYWDIjyBWDOsYmPSu3, PvmslmVpFqlsnUoZKzBNXwqVOlsN(jEFWBRErhHbKSaFVumnIvqWFTWtl, agOACnagmLCXYWDIjyBWDOsYmPSu3));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						agOACnagmLCXYWDIjyBWDOsYmPSu agOACnagmLCXYWDIjyBWDOsYmPSu2 = cnjFEzxeosxVclJRIEYZCfyuqFjHA.GetButtonTarget(jEFWBRErhHbKSaFVumnIvqWFTWtl, templateElementIdentifier.id) ?? agOACnagmLCXYWDIjyBWDOsYmPSu.zixJGzEXzPtVLUqRvkHLoUbTNSVv(ControllerTemplateElementType.Button);
						KMTQEAmoRKaNLYXDHJFhkoVwjZzt item = new KMTQEAmoRKaNLYXDHJFhkoVwjZzt(this, templateElementIdentifier.id, templateElementIdentifier.name, templateElementIdentifier.name, templateElementIdentifier.name + " -", agOACnagmLCXYWDIjyBWDOsYmPSu2, IlwvyNnNQbiMuYTbpCcuOzFSsVsN(jEFWBRErhHbKSaFVumnIvqWFTWtl, agOACnagmLCXYWDIjyBWDOsYmPSu2));
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
				IControllerTemplateElementIdentifier templateElementIdentifier2 = cnjFEzxeosxVclJRIEYZCfyuqFjHA.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = cnjFEzxeosxVclJRIEYZCfyuqFjHA.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				KjkItrTgETDhGXlCPCIPYlRYkRKs kjkItrTgETDhGXlCPCIPYlRYkRKs;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					kjkItrTgETDhGXlCPCIPYlRYkRKs = new zVnbYkuSULlLgAlgHlCnWIwwtEYO(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping5 != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping5.eid_axisX) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this), (mapping5 != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping5.eid_axisY) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this), (mapping5 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping5.eid_button) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					kjkItrTgETDhGXlCPCIPYlRYkRKs = new DTUWgzLNjYAsLSENhzluLdeLqTEh(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping3 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping3.eid_up) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this), (mapping3 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping3.eid_right) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this), (mapping3 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping3.eid_down) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this), (mapping3 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping3.eid_left) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this), (mapping3 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping3.eid_press) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					kjkItrTgETDhGXlCPCIPYlRYkRKs = new yiQFtWGYnkwxUorNoZbcaXZpmBfNA(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping2 != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping2.eid_axisX) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this), (mapping2 != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping2.eid_axisY) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this), (mapping2 != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping2.eid_axisZ) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					kjkItrTgETDhGXlCPCIPYlRYkRKs = new AOmTPRSMVAJxwyYlDPVvKwzLlLiQ(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping6 != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping6.eid_axis) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this), (mapping6 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping6.eid_minDetent) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					kjkItrTgETDhGXlCPCIPYlRYkRKs = new lTUnBFvZDuKwlHhTKTaAkThMMhGy(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping7 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping7.eid_up) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this), (mapping7 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping7.eid_upRight) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this), (mapping7 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping7.eid_right) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this), (mapping7 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping7.eid_downRight) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this), (mapping7 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping7.eid_down) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this), (mapping7 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping7.eid_downLeft) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this), (mapping7 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping7.eid_left) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this), (mapping7 != null) ? WgDiDHCuCcljiOuOhFbqpKOLUvfl(this, aDictionary, mapping7.eid_upLeft) : KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					kjkItrTgETDhGXlCPCIPYlRYkRKs = new hbHMHmrbatnuobqVnZhMOAyUBhhQ(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping4 != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping4.eid_axisX) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this), (mapping4 != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping4.eid_axisZ) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					kjkItrTgETDhGXlCPCIPYlRYkRKs = new DySHkjLOpGvUskPuzBAHYNMchAgeA(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping.eid_positionX) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this), (mapping != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping.eid_positionY) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this), (mapping != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping.eid_positionZ) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this), (mapping != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping.eid_rotationX) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this), (mapping != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping.eid_rotationY) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this), (mapping != null) ? gJqFczKzhubFpaAxGGApjzhSMXFY(this, aDictionary, mapping.eid_rotationZ) : pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (kjkItrTgETDhGXlCPCIPYlRYkRKs != null)
				{
					list4.Add(kjkItrTgETDhGXlCPCIPYlRYkRKs);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			nfPxwXjaHfgTwFZMtbpAYZzqhcxKA = list.ToArray();
			NusOtzVmaKpqqApyorFEUnAdQRdj = aDictionary;
			ibZqvlSsqsKAlwqKdIlzggVeSnCT = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < nfPxwXjaHfgTwFZMtbpAYZzqhcxKA.Length; num++)
			{
				if (!(cnjFEzxeosxVclJRIEYZCfyuqFjHA.GetTemplateElementIdentifierById(nfPxwXjaHfgTwFZMtbpAYZzqhcxKA[num].id) is IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor))
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
							ibZqvlSsqsKAlwqKdIlzggVeSnCT.Add(text, nfPxwXjaHfgTwFZMtbpAYZzqhcxKA[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + DauteblfdDMJxVylVOpXsQWBsiKL + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			ZvZIUfWqPOpbgkVFVLWLtdaeXMsN = new ReadOnlyCollection<IControllerTemplateElement>(nfPxwXjaHfgTwFZMtbpAYZzqhcxKA);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			if (!NusOtzVmaKpqqApyorFEUnAdQRdj.TryGetValue(id, out var value))
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
			if (ReInput._id != GCTVuRHoHUgWcTVKZPdVsrXSJJJh)
			{
				ReInput.CheckInitialized(GCTVuRHoHUgWcTVKZPdVsrXSJJJh);
				return null;
			}
			return GetElement(id);
		}

		T IControllerTemplate.GetElement<T>(int id)
		{
			if (ReInput._id != GCTVuRHoHUgWcTVKZPdVsrXSJJJh)
			{
				ReInput.CheckInitialized(GCTVuRHoHUgWcTVKZPdVsrXSJJJh);
				return null;
			}
			return GetElement<T>(id);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget find, IList<ControllerTemplateElementTarget> results)
		{
			if (ReInput._id != GCTVuRHoHUgWcTVKZPdVsrXSJJJh)
			{
				ReInput.CheckInitialized(GCTVuRHoHUgWcTVKZPdVsrXSJJJh);
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
			for (int i = 0; i < nfPxwXjaHfgTwFZMtbpAYZzqhcxKA.Length; i++)
			{
				if (InputTools.IsMappableType(nfPxwXjaHfgTwFZMtbpAYZzqhcxKA[i].type))
				{
					num += (nfPxwXjaHfgTwFZMtbpAYZzqhcxKA[i] as IControllerTemplateElement_Internal).GetElementTargets(find, ref results);
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

		private static IList<bQwslBiIrFIxKfqfzutdqnHIqPHR> PvmslmVpFqlsnUoZKzBNXwqVOlsN(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			if (P_1.splitAxis)
			{
				IList<bQwslBiIrFIxKfqfzutdqnHIqPHR> list = null;
				bool flag = false;
				if (P_1.positiveTarget != null)
				{
					Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					if (elementById != null)
					{
						ListTools.AddAndCreateList(ref list, new bQwslBiIrFIxKfqfzutdqnHIqPHR(P_1.positiveTarget, elementById));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, bQwslBiIrFIxKfqfzutdqnHIqPHR.KWHTEcRjwRcyIdVfGpkbEDbblSEO());
				}
				flag = false;
				if (P_1.negativeTarget != null)
				{
					Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
					if (elementById2 != null)
					{
						ListTools.AddAndCreateList(ref list, new bQwslBiIrFIxKfqfzutdqnHIqPHR(P_1.negativeTarget, elementById2));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, bQwslBiIrFIxKfqfzutdqnHIqPHR.KWHTEcRjwRcyIdVfGpkbEDbblSEO());
				}
				return list;
			}
			return hnLpfcoiDVtbkIIlpOpDjJsAHLZp(P_0, P_1.fullTarget);
		}

		private static IList<bQwslBiIrFIxKfqfzutdqnHIqPHR> IlwvyNnNQbiMuYTbpCcuOzFSsVsN(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return hnLpfcoiDVtbkIIlpOpDjJsAHLZp(P_0, P_1.target);
		}

		private static IList<bQwslBiIrFIxKfqfzutdqnHIqPHR> hnLpfcoiDVtbkIIlpOpDjJsAHLZp(Controller P_0, IControllerElementTarget P_1)
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
			return new List<bQwslBiIrFIxKfqfzutdqnHIqPHR>
			{
				new bQwslBiIrFIxKfqfzutdqnHIqPHR(P_1, elementById)
			};
		}

		private static IControllerTemplateElement YehPJWaqZBkvsqOrdyZJebLqcsiA(List<IControllerTemplateElement> P_0, int P_1)
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

		private static EdxBDcAOTewPMnJBnAMWaxdgSMpm gJqFczKzhubFpaAxGGApjzhSMXFY(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is EdxBDcAOTewPMnJBnAMWaxdgSMpm result))
			{
				return pcfAHFaxuOIaSSNFKLLVSZBlNqiqA.AOQbbjbEkogjuPOUBVTDWRRPYlTv(P_0);
			}
			return result;
		}

		private static EdxBDcAOTewPMnJBnAMWaxdgSMpm WgDiDHCuCcljiOuOhFbqpKOLUvfl(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is EdxBDcAOTewPMnJBnAMWaxdgSMpm result))
			{
				return KMTQEAmoRKaNLYXDHJFhkoVwjZzt.eySuMxHGfHDMzFKBAppypupOHwqdb(P_0);
			}
			return result;
		}
	}
}
