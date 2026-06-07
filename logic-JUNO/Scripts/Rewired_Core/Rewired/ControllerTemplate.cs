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
		internal abstract class UmpDFlUDDxYLPBuJjjzIyPbLvOof : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate ziYoAVylYqtCjkfrYxJkUTFztfQv;

			private readonly int wUrZNxMZOUAfqadyuhTcmOJbBSrKA;

			private readonly string YIrXAiwXWJThhPEDzfXLXtboYBTT;

			private readonly ControllerTemplateElementType kIRDFKAGCmOfGxaHNEYqJyLHeCfb;

			protected readonly int rBCBgWdsmqIhnCtOOXKpVKsgUpZtA;

			int IControllerTemplateElement.id
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return -1;
					}
					return wUrZNxMZOUAfqadyuhTcmOJbBSrKA;
				}
			}

			string IControllerTemplateElement.descriptiveName
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return YIrXAiwXWJThhPEDzfXLXtboYBTT;
				}
			}

			ControllerTemplateElementType IControllerTemplateElement.type
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return ControllerTemplateElementType.Axis;
					}
					return kIRDFKAGCmOfGxaHNEYqJyLHeCfb;
				}
			}

			IControllerTemplate IControllerTemplateElement_Internal.parent => ziYoAVylYqtCjkfrYxJkUTFztfQv;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected UmpDFlUDDxYLPBuJjjzIyPbLvOof(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				ziYoAVylYqtCjkfrYxJkUTFztfQv = P_0;
				wUrZNxMZOUAfqadyuhTcmOJbBSrKA = P_1;
				YIrXAiwXWJThhPEDzfXLXtboYBTT = P_2;
				kIRDFKAGCmOfGxaHNEYqJyLHeCfb = P_3;
				rBCBgWdsmqIhnCtOOXKpVKsgUpZtA = ReInput.id;
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);
		}

		internal abstract class GgoaooKNuUYcLeQBoeXKiQYgBVvbb : UmpDFlUDDxYLPBuJjjzIyPbLvOof
		{
			protected readonly int pqegHtNoMESKctGbCBYvmPqleIvu;

			protected readonly buzhpFloWjWnTdgMXIgwYrFTzbzd[] UpGRmvrNuJEYHOKmtixpDBkQELqIA;

			bool UmpDFlUDDxYLPBuJjjzIyPbLvOof.exists
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return false;
					}
					if (UpGRmvrNuJEYHOKmtixpDBkQELqIA == null)
					{
						return false;
					}
					for (int i = 0; i < UpGRmvrNuJEYHOKmtixpDBkQELqIA.Length; i++)
					{
						if (UpGRmvrNuJEYHOKmtixpDBkQELqIA[i].qOaiyMVJSAOqHFLfDUByXdxcbRugA != null)
						{
							return true;
						}
					}
					return false;
				}
			}

			protected GgoaooKNuUYcLeQBoeXKiQYgBVvbb(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, IList<buzhpFloWjWnTdgMXIgwYrFTzbzd> P_4)
				: base(P_0, P_1, P_2, P_3)
			{
				UpGRmvrNuJEYHOKmtixpDBkQELqIA = ((P_4 != null) ? ListTools.ToArray(P_4) : null);
				pqegHtNoMESKctGbCBYvmPqleIvu = ((UpGRmvrNuJEYHOKmtixpDBkQELqIA != null) ? UpGRmvrNuJEYHOKmtixpDBkQELqIA.Length : 0);
			}
		}

		internal abstract class IkgEsVHKAnBBtLOLjxJCfPlAcZX : GgoaooKNuUYcLeQBoeXKiQYgBVvbb, IControllerTemplateAxis, IControllerTemplateElement, IControllerTemplateButton
		{
			private wzVNvKxdfLgPZGLFDmLcrCdHxsec AwyakTlOmOJNyXEpXJIPsGmvztBY;

			private string jmtDmSaSfpqRZepGdUnLlBnpVmRFB;

			private string IvdctJIcYdQojjaDdmujsQWNsDOCB;

			public float WnrRQzEPmACbGSPcRnGTSgISeVBc
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return 0f;
					}
					if (pqegHtNoMESKctGbCBYvmPqleIvu == 1)
					{
						return UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].hjudpidyeSTiawRJFaqnChZUhEWr;
					}
					if (pqegHtNoMESKctGbCBYvmPqleIvu == 2)
					{
						float num = UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].hjudpidyeSTiawRJFaqnChZUhEWr;
						float num2 = UpGRmvrNuJEYHOKmtixpDBkQELqIA[1].hjudpidyeSTiawRJFaqnChZUhEWr;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public float IbhgxFMASmhIwcePjLLnhUHbGhsX
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return 0f;
					}
					if (pqegHtNoMESKctGbCBYvmPqleIvu == 1)
					{
						return UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].XekdEJaFmajuOCZSFCuagCutBUiWB;
					}
					if (pqegHtNoMESKctGbCBYvmPqleIvu == 2)
					{
						float num = UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].XekdEJaFmajuOCZSFCuagCutBUiWB;
						float num2 = UpGRmvrNuJEYHOKmtixpDBkQELqIA[1].XekdEJaFmajuOCZSFCuagCutBUiWB;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool qkazjhTbmtSchLcKZBgPkMmvNuNPA
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return false;
					}
					if (pqegHtNoMESKctGbCBYvmPqleIvu == 1)
					{
						return UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].diEaAjJgXXgQomoTNkPDqGOGMgoCb;
					}
					if (pqegHtNoMESKctGbCBYvmPqleIvu == 2)
					{
						if (!UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].diEaAjJgXXgQomoTNkPDqGOGMgoCb)
						{
							return UpGRmvrNuJEYHOKmtixpDBkQELqIA[1].diEaAjJgXXgQomoTNkPDqGOGMgoCb;
						}
						return true;
					}
					return false;
				}
			}

			public bool FTJTRhCSTozjbGUwWvFRfjTsmJvE
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return false;
					}
					if (pqegHtNoMESKctGbCBYvmPqleIvu == 1)
					{
						return UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].fMfVEsCBNdHjEPXdtiNlGvNuEfor;
					}
					if (pqegHtNoMESKctGbCBYvmPqleIvu == 2)
					{
						if (!UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].fMfVEsCBNdHjEPXdtiNlGvNuEfor)
						{
							return UpGRmvrNuJEYHOKmtixpDBkQELqIA[1].fMfVEsCBNdHjEPXdtiNlGvNuEfor;
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
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return jmtDmSaSfpqRZepGdUnLlBnpVmRFB;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return IvdctJIcYdQojjaDdmujsQWNsDOCB;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return 0f;
					}
					return WnrRQzEPmACbGSPcRnGTSgISeVBc;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return 0f;
					}
					return IbhgxFMASmhIwcePjLLnhUHbGhsX;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return AwyakTlOmOJNyXEpXJIPsGmvztBY;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return false;
					}
					return qkazjhTbmtSchLcKZBgPkMmvNuNPA;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return false;
					}
					return FTJTRhCSTozjbGUwWvFRfjTsmJvE;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return false;
					}
					if (pqegHtNoMESKctGbCBYvmPqleIvu == 1)
					{
						return UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].GVYfcrYxkqFqrFAdITVOrzXXnUkR;
					}
					if (pqegHtNoMESKctGbCBYvmPqleIvu == 2)
					{
						if (!UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].GVYfcrYxkqFqrFAdITVOrzXXnUkR || UpGRmvrNuJEYHOKmtixpDBkQELqIA[1].fMfVEsCBNdHjEPXdtiNlGvNuEfor)
						{
							if (UpGRmvrNuJEYHOKmtixpDBkQELqIA[1].GVYfcrYxkqFqrFAdITVOrzXXnUkR)
							{
								return !UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].fMfVEsCBNdHjEPXdtiNlGvNuEfor;
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
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return false;
					}
					if (pqegHtNoMESKctGbCBYvmPqleIvu == 1)
					{
						return UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].fSTwSbwmPRnNzFWFDmVhUGKBOVPh;
					}
					if (pqegHtNoMESKctGbCBYvmPqleIvu == 2)
					{
						if (!UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].fSTwSbwmPRnNzFWFDmVhUGKBOVPh || UpGRmvrNuJEYHOKmtixpDBkQELqIA[1].diEaAjJgXXgQomoTNkPDqGOGMgoCb)
						{
							if (UpGRmvrNuJEYHOKmtixpDBkQELqIA[1].fSTwSbwmPRnNzFWFDmVhUGKBOVPh)
							{
								return !UpGRmvrNuJEYHOKmtixpDBkQELqIA[0].diEaAjJgXXgQomoTNkPDqGOGMgoCb;
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
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return false;
					}
					return qkazjhTbmtSchLcKZBgPkMmvNuNPA != FTJTRhCSTozjbGUwWvFRfjTsmJvE;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return 0f;
					}
					return WnrRQzEPmACbGSPcRnGTSgISeVBc;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return 0f;
					}
					return IbhgxFMASmhIwcePjLLnhUHbGhsX;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return AwyakTlOmOJNyXEpXJIPsGmvztBY;
				}
			}

			IControllerTemplateElementSource UmpDFlUDDxYLPBuJjjzIyPbLvOof.source
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return AwyakTlOmOJNyXEpXJIPsGmvztBY;
				}
			}

			int UmpDFlUDDxYLPBuJjjzIyPbLvOof.elementCount => 0;

			IControllerTemplateAxis IControllerTemplateButton.AsAxis
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return this;
				}
			}

			IControllerTemplateButton IControllerTemplateAxis.AsButton
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return this;
				}
			}

			protected IkgEsVHKAnBBtLOLjxJCfPlAcZX(IControllerTemplate P_0, int P_1, string P_2, string P_3, string P_4, ControllerTemplateElementType P_5, wzVNvKxdfLgPZGLFDmLcrCdHxsec P_6, IList<buzhpFloWjWnTdgMXIgwYrFTzbzd> P_7)
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
				AwyakTlOmOJNyXEpXJIPsGmvztBY = P_6;
				jmtDmSaSfpqRZepGdUnLlBnpVmRFB = P_3;
				IvdctJIcYdQojjaDdmujsQWNsDOCB = P_4;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange axisRange)
			{
				if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
				{
					ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
					return null;
				}
				return axisRange switch
				{
					AxisRange.Full => base.Rewired_002EIControllerTemplateElement_002EdescriptiveName, 
					AxisRange.Positive => jmtDmSaSfpqRZepGdUnLlBnpVmRFB, 
					AxisRange.Negative => IvdctJIcYdQojjaDdmujsQWNsDOCB, 
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
					IControllerTemplateAxisSource awyakTlOmOJNyXEpXJIPsGmvztBY = AwyakTlOmOJNyXEpXJIPsGmvztBY;
					if (awyakTlOmOJNyXEpXJIPsGmvztBY.splitAxis)
					{
						if (NuncqYbEeoxqyWRRBmnNDRVctWMMc(find, awyakTlOmOJNyXEpXJIPsGmvztBY.positiveTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
							num++;
						}
						if (NuncqYbEeoxqyWRRBmnNDRVctWMMc(find, awyakTlOmOJNyXEpXJIPsGmvztBY.negativeTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
							num++;
						}
					}
					else if (NuncqYbEeoxqyWRRBmnNDRVctWMMc(find, awyakTlOmOJNyXEpXJIPsGmvztBY.fullTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
						num++;
					}
					break;
				}
				case ControllerTemplateElementType.Button:
					if (NuncqYbEeoxqyWRRBmnNDRVctWMMc(find, ((IControllerTemplateButtonSource)AwyakTlOmOJNyXEpXJIPsGmvztBY).target))
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

			private static bool NuncqYbEeoxqyWRRBmnNDRVctWMMc(ControllerElementTarget P_0, IControllerElementTarget P_1)
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

		internal sealed class hVekINgPhiNZXNtCeHeEhBdsPYMn : IkgEsVHKAnBBtLOLjxJCfPlAcZX
		{
			public hVekINgPhiNZXNtCeHeEhBdsPYMn(IControllerTemplate P_0, int P_1, string P_2, string P_3, string P_4, wzVNvKxdfLgPZGLFDmLcrCdHxsec P_5, IList<buzhpFloWjWnTdgMXIgwYrFTzbzd> P_6)
				: base(P_0, P_1, P_2, P_3, P_4, ControllerTemplateElementType.Axis, P_5, P_6)
			{
				if (P_6 != null && P_6.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static hVekINgPhiNZXNtCeHeEhBdsPYMn IiRwCrihYACOfRVLveDKapaCZUnE(IControllerTemplate P_0)
			{
				return new hVekINgPhiNZXNtCeHeEhBdsPYMn(P_0, -1, string.Empty, string.Empty, string.Empty, wzVNvKxdfLgPZGLFDmLcrCdHxsec.zEoyTjVDsjfgGhOOPsiGOIZOMqbcb(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class CtGgVEbhCcKsMuEGhwkkqIhjExTYA : IkgEsVHKAnBBtLOLjxJCfPlAcZX
		{
			public CtGgVEbhCcKsMuEGhwkkqIhjExTYA(IControllerTemplate P_0, int P_1, string P_2, string P_3, string P_4, wzVNvKxdfLgPZGLFDmLcrCdHxsec P_5, IList<buzhpFloWjWnTdgMXIgwYrFTzbzd> P_6)
				: base(P_0, P_1, P_2, P_3, P_4, ControllerTemplateElementType.Button, P_5, P_6)
			{
				if (P_6 != null && P_6.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static CtGgVEbhCcKsMuEGhwkkqIhjExTYA qRTDNdCLknRjcULCqDAnYxLLSASM(IControllerTemplate P_0)
			{
				return new CtGgVEbhCcKsMuEGhwkkqIhjExTYA(P_0, -1, string.Empty, string.Empty, string.Empty, wzVNvKxdfLgPZGLFDmLcrCdHxsec.zEoyTjVDsjfgGhOOPsiGOIZOMqbcb(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class mTUlLkDXqJZHqOMMfJvyibkflVNc : UmpDFlUDDxYLPBuJjjzIyPbLvOof
		{
			protected readonly int PBsZLNqDxCDfeSeTKyVOsLwXYiVg;

			protected readonly UmpDFlUDDxYLPBuJjjzIyPbLvOof[] JDznczOacqizmCIZwgyQGaNBAXaZ;

			bool UmpDFlUDDxYLPBuJjjzIyPbLvOof.exists
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return false;
					}
					for (int i = 0; i < PBsZLNqDxCDfeSeTKyVOsLwXYiVg; i++)
					{
						if (JDznczOacqizmCIZwgyQGaNBAXaZ[i].exists)
						{
							return true;
						}
					}
					return false;
				}
			}

			IControllerTemplateElementSource UmpDFlUDDxYLPBuJjjzIyPbLvOof.source
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return null;
				}
			}

			int UmpDFlUDDxYLPBuJjjzIyPbLvOof.elementCount => PBsZLNqDxCDfeSeTKyVOsLwXYiVg;

			protected mTUlLkDXqJZHqOMMfJvyibkflVNc(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, UmpDFlUDDxYLPBuJjjzIyPbLvOof[] P_4)
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
				JDznczOacqizmCIZwgyQGaNBAXaZ = P_4;
				PBsZLNqDxCDfeSeTKyVOsLwXYiVg = P_4.Length;
			}

			public virtual IControllerTemplateElement NZWZSGQNtAJNtTFlYjurDBKtiilcA(int P_0)
			{
				return JDznczOacqizmCIZwgyQGaNBAXaZ[P_0];
			}

			public virtual int ldJbKORhUzvQkDdZIzZMccnGFmqv(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				for (int i = 0; i < JDznczOacqizmCIZwgyQGaNBAXaZ.Length; i++)
				{
					num += JDznczOacqizmCIZwgyQGaNBAXaZ[i].GetElementTargets(P_0, ref P_1);
				}
				return num;
			}
		}

		internal abstract class UKjBziWrJmWaWcyoXZvyIpiWufDB : mTUlLkDXqJZHqOMMfJvyibkflVNc, IControllerTemplateAxis2D, IControllerTemplateElement
		{
			protected const int IVhOquqRoJRKnkyfxJQstHLwItLB = 0;

			protected const int zzDStuJdlldHBeNfqBuYErCBoUZRA = 1;

			protected const int EZWEDoOxcjjNldkeTMUkNYpuDTPq = 2;

			Vector2 IControllerTemplateAxis2D.value
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return Vector2.zero;
					}
					return new Vector2((PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 0) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[0]).WnrRQzEPmACbGSPcRnGTSgISeVBc : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 1) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[1]).WnrRQzEPmACbGSPcRnGTSgISeVBc : 0f);
				}
			}

			Vector2 IControllerTemplateAxis2D.valuePrev
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return Vector2.zero;
					}
					return new Vector2((PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 0) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[0]).IbhgxFMASmhIwcePjLLnhUHbGhsX : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 1) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[1]).IbhgxFMASmhIwcePjLLnhUHbGhsX : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.horizontal
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.vertical
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[1];
				}
			}

			protected UKjBziWrJmWaWcyoXZvyIpiWufDB(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, UmpDFlUDDxYLPBuJjjzIyPbLvOof[] P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class QthEAIarSUGVNRcxZKWSItNVEFES : mTUlLkDXqJZHqOMMfJvyibkflVNc, IControllerTemplateAxis3D, IControllerTemplateElement
		{
			protected const int TJmhjTzdFekjumShrwHktAieZSfV = 0;

			protected const int bTGkChyfUaMmABrFHwbuSkDoYBMH = 1;

			protected const int TPLJxciODbvAbkQRIiijMpzhNgBT = 2;

			protected const int SUEnImQMizNmhfNNtEgYvQhptqkj = 3;

			Vector3 IControllerTemplateAxis3D.value
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return Vector3.zero;
					}
					return new Vector3((PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 0) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[0]).WnrRQzEPmACbGSPcRnGTSgISeVBc : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 1) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[1]).WnrRQzEPmACbGSPcRnGTSgISeVBc : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 2) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[2]).WnrRQzEPmACbGSPcRnGTSgISeVBc : 0f);
				}
			}

			Vector3 IControllerTemplateAxis3D.valuePrev
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return Vector3.zero;
					}
					return new Vector3((PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 0) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[0]).IbhgxFMASmhIwcePjLLnhUHbGhsX : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 1) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[1]).IbhgxFMASmhIwcePjLLnhUHbGhsX : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 2) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[2]).IbhgxFMASmhIwcePjLLnhUHbGhsX : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.horizontal
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.vertical
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.depth
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[2];
				}
			}

			protected QthEAIarSUGVNRcxZKWSItNVEFES(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, UmpDFlUDDxYLPBuJjjzIyPbLvOof[] P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class abLNdOVfTeLAJSShslGfUCUtBEIt : mTUlLkDXqJZHqOMMfJvyibkflVNc, IControllerTemplateAxis6D, IControllerTemplateElement
		{
			protected const int piMYxgXhXWEQLiPHmLUPbqvjJDJn = 0;

			protected const int OSAwAZhOSHfSmVNidBSEUgPOlWaU = 1;

			protected const int miHJfqPXWVTPtTkYyVIFRKbKPCfO = 2;

			protected const int HlXeeeAYqcSAdIluuWiHWJGPllhJA = 3;

			protected const int AvTZLXdBqbBbvBCzFRanDayJlbAW = 4;

			protected const int ZAwpcFkylEryEKrstbHhpzhRBJeO = 5;

			protected const int nlFWravKiicNNfOpjlcsdjMefWLgB = 6;

			Vector3 IControllerTemplateAxis6D.position
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return Vector3.zero;
					}
					return new Vector3((PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 0) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[0]).WnrRQzEPmACbGSPcRnGTSgISeVBc : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 1) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[1]).WnrRQzEPmACbGSPcRnGTSgISeVBc : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 2) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[2]).WnrRQzEPmACbGSPcRnGTSgISeVBc : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.positionPrev
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return Vector3.zero;
					}
					return new Vector3((PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 0) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[0]).IbhgxFMASmhIwcePjLLnhUHbGhsX : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 1) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[1]).IbhgxFMASmhIwcePjLLnhUHbGhsX : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 2) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[2]).IbhgxFMASmhIwcePjLLnhUHbGhsX : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotation
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return Vector3.zero;
					}
					return new Vector3((PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 3) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[3]).WnrRQzEPmACbGSPcRnGTSgISeVBc : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 4) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[4]).WnrRQzEPmACbGSPcRnGTSgISeVBc : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 5) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[5]).WnrRQzEPmACbGSPcRnGTSgISeVBc : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotationPrev
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return Vector3.zero;
					}
					return new Vector3((PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 3) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[3]).IbhgxFMASmhIwcePjLLnhUHbGhsX : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 4) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[4]).IbhgxFMASmhIwcePjLLnhUHbGhsX : 0f, (PBsZLNqDxCDfeSeTKyVOsLwXYiVg > 5) ? ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[5]).IbhgxFMASmhIwcePjLLnhUHbGhsX : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionX
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionY
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionZ
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[2];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationX
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[3];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationY
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[4];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationZ
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[5];
				}
			}

			protected abLNdOVfTeLAJSShslGfUCUtBEIt(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, UmpDFlUDDxYLPBuJjjzIyPbLvOof[] P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal sealed class kcJraEFvsInOBhmOUCOpItzeAdFVA : QthEAIarSUGVNRcxZKWSItNVEFES, IControllerTemplateStick, IControllerTemplateElement
		{
			private const int FHWmHlJPitDqAtlDNHCHDlkrMVYCA = 3;

			IControllerTemplateAxis IControllerTemplateStick.rotation
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[2];
				}
			}

			private kcJraEFvsInOBhmOUCOpItzeAdFVA(IControllerTemplate P_0, int P_1, string P_2, UmpDFlUDDxYLPBuJjjzIyPbLvOof[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Stick, P_3)
			{
				if (P_3.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			public kcJraEFvsInOBhmOUCOpItzeAdFVA(IControllerTemplate P_0, int P_1, string P_2, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_3, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_4, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_5)
				: this(P_0, P_1, P_2, new UmpDFlUDDxYLPBuJjjzIyPbLvOof[3] { P_3, P_4, P_5 })
			{
			}
		}

		internal sealed class jzaJvgddDvgwlUGlbbPeeDQhmviK : UKjBziWrJmWaWcyoXZvyIpiWufDB, IControllerTemplateThumbStick, IControllerTemplateElement
		{
			private const int SOPnOkkbFBXMExljerQOjlzUSiGm = 2;

			private const int ILdWRlKWhBaMsteohZxbaovzzufc = 3;

			IControllerTemplateButton IControllerTemplateThumbStick.press
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[2];
				}
			}

			private jzaJvgddDvgwlUGlbbPeeDQhmviK(IControllerTemplate P_0, int P_1, string P_2, UmpDFlUDDxYLPBuJjjzIyPbLvOof[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.ThumbStick, P_3)
			{
				if (P_3.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal jzaJvgddDvgwlUGlbbPeeDQhmviK(IControllerTemplate P_0, int P_1, string P_2, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_3, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_4, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_5)
				: this(P_0, P_1, P_2, new UmpDFlUDDxYLPBuJjjzIyPbLvOof[3] { P_3, P_4, P_5 })
			{
			}
		}

		internal sealed class HxJBrhCuEmpiUKYHNOvzxQuIITae : mTUlLkDXqJZHqOMMfJvyibkflVNc, IControllerTemplateDPad, IControllerTemplateElement
		{
			private const int iwvxzzCtbajezQnmRENvBxSQVVqK = 0;

			private const int uCKQWLGYRPlDreICXQTLhGvJtwDg = 1;

			private const int EIWPjTPnNJoSybNpiDezqCdzkexs = 2;

			private const int BUhqskpHwhuouccFLjrVgzmYKuRP = 3;

			private const int mayGxpPdDUKDiomebyJfEBqOkyrE = 4;

			private const int zTykCyUFmwrekFimxPexEiUsZbIn = 5;

			Vector2 IControllerTemplateDPad.value
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[0]).WnrRQzEPmACbGSPcRnGTSgISeVBc + ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[2]).WnrRQzEPmACbGSPcRnGTSgISeVBc * -1f, -1f, 1f), MathTools.Clamp(((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[3]).WnrRQzEPmACbGSPcRnGTSgISeVBc * -1f + ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[1]).WnrRQzEPmACbGSPcRnGTSgISeVBc, -1f, 1f));
				}
			}

			Vector2 IControllerTemplateDPad.valuePrev
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[0]).IbhgxFMASmhIwcePjLLnhUHbGhsX + ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[2]).IbhgxFMASmhIwcePjLLnhUHbGhsX * -1f, -1f, 1f), MathTools.Clamp(((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[3]).IbhgxFMASmhIwcePjLLnhUHbGhsX * -1f + ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[1]).IbhgxFMASmhIwcePjLLnhUHbGhsX, -1f, 1f));
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.up
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[0];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.right
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[1];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.down
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[2];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.left
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[3];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.press
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[4];
				}
			}

			private HxJBrhCuEmpiUKYHNOvzxQuIITae(IControllerTemplate P_0, int P_1, string P_2, UmpDFlUDDxYLPBuJjjzIyPbLvOof[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.DPad, P_3)
			{
				if (P_3.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal HxJBrhCuEmpiUKYHNOvzxQuIITae(IControllerTemplate P_0, int P_1, string P_2, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_3, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_4, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_5, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_6, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_7)
				: this(P_0, P_1, P_2, new UmpDFlUDDxYLPBuJjjzIyPbLvOof[5] { P_3, P_4, P_5, P_6, P_7 })
			{
			}
		}

		internal sealed class AszeGLXHWmvMnsZabGymyuPUGnWx : mTUlLkDXqJZHqOMMfJvyibkflVNc, IControllerTemplateThrottle, IControllerTemplateElement
		{
			private const int oZkCWQVWnymmtbYwyrDTfrpIkVsd = 0;

			private const int cCFbKegAgpOoIoIEmRQaqSRfApjEA = 1;

			private const int mrVfuVKHBKKLMjdkIIqEZlDZSgvX = 2;

			float IControllerTemplateThrottle.value
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return 0f;
					}
					return ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[0]).WnrRQzEPmACbGSPcRnGTSgISeVBc;
				}
			}

			float IControllerTemplateThrottle.valuePrev
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return 0f;
					}
					return ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[0]).IbhgxFMASmhIwcePjLLnhUHbGhsX;
				}
			}

			IControllerTemplateAxis IControllerTemplateThrottle.throttle
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[0];
				}
			}

			IControllerTemplateButton IControllerTemplateThrottle.minDetent
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[1];
				}
			}

			private AszeGLXHWmvMnsZabGymyuPUGnWx(IControllerTemplate P_0, int P_1, string P_2, UmpDFlUDDxYLPBuJjjzIyPbLvOof[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Throttle, P_3)
			{
				if (P_3.Length != 2)
				{
					throw new ArgumentException("elements.Length must be " + 2);
				}
			}

			internal AszeGLXHWmvMnsZabGymyuPUGnWx(IControllerTemplate P_0, int P_1, string P_2, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_3, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_4)
				: this(P_0, P_1, P_2, new UmpDFlUDDxYLPBuJjjzIyPbLvOof[2] { P_3, P_4 })
			{
			}
		}

		internal sealed class taZGKTbySYsRkIHMwhNBdCNFVPgic : mTUlLkDXqJZHqOMMfJvyibkflVNc, IControllerTemplateHat, IControllerTemplateElement
		{
			private const int rjmVgRRRdyPUkiVPjKcthXmqFxGi = 0;

			private const int DjJzcUOqHNDvrQKTMHKSgFdQivul = 1;

			private const int HYVLCOSRblNILMBhLcdSwlmMYMnR = 2;

			private const int CAtsbacDqFQouOXjWyLZNQBbrPke = 3;

			private const int ubunOXbwsKzfTkCXiMGWyRbOVSQF = 4;

			private const int AWraabTidfgaLHsrMJrFgfPlFigWA = 5;

			private const int IXSdpAcTldbcQltzyaBtcnSONQvF = 6;

			private const int fysMaoEcPfQbreTMbOWDMPrDcJDG = 7;

			private const int OpqfeJhnipNlDgcrHOTwuGpBWKibc = 8;

			Vector2 IControllerTemplateHat.value
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[0]).WnrRQzEPmACbGSPcRnGTSgISeVBc;
					result.x += ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[2]).WnrRQzEPmACbGSPcRnGTSgISeVBc;
					result.y -= ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[4]).WnrRQzEPmACbGSPcRnGTSgISeVBc;
					result.x -= ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[6]).WnrRQzEPmACbGSPcRnGTSgISeVBc;
					float num = ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[1]).WnrRQzEPmACbGSPcRnGTSgISeVBc;
					float num2 = ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[3]).WnrRQzEPmACbGSPcRnGTSgISeVBc;
					float num3 = ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[5]).WnrRQzEPmACbGSPcRnGTSgISeVBc;
					float num4 = ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[7]).WnrRQzEPmACbGSPcRnGTSgISeVBc;
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
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[0]).IbhgxFMASmhIwcePjLLnhUHbGhsX;
					result.x += ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[2]).IbhgxFMASmhIwcePjLLnhUHbGhsX;
					result.y -= ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[4]).IbhgxFMASmhIwcePjLLnhUHbGhsX;
					result.x -= ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[6]).IbhgxFMASmhIwcePjLLnhUHbGhsX;
					float num = ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[1]).IbhgxFMASmhIwcePjLLnhUHbGhsX;
					float num2 = ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[3]).IbhgxFMASmhIwcePjLLnhUHbGhsX;
					float num3 = ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[5]).IbhgxFMASmhIwcePjLLnhUHbGhsX;
					float num4 = ((IkgEsVHKAnBBtLOLjxJCfPlAcZX)JDznczOacqizmCIZwgyQGaNBAXaZ[7]).IbhgxFMASmhIwcePjLLnhUHbGhsX;
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
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[0];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upRight
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[1];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.right
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[2];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downRight
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[3];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.down
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[4];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downLeft
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[5];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.left
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[6];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upLeft
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateButton)JDznczOacqizmCIZwgyQGaNBAXaZ[7];
				}
			}

			private taZGKTbySYsRkIHMwhNBdCNFVPgic(IControllerTemplate P_0, int P_1, string P_2, UmpDFlUDDxYLPBuJjjzIyPbLvOof[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Hat, P_3)
			{
				if (P_3.Length != 8)
				{
					throw new ArgumentException("elements.Length must be " + 8);
				}
			}

			internal taZGKTbySYsRkIHMwhNBdCNFVPgic(IControllerTemplate P_0, int P_1, string P_2, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_3, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_4, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_5, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_6, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_7, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_8, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_9, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_10)
				: this(P_0, P_1, P_2, new UmpDFlUDDxYLPBuJjjzIyPbLvOof[8] { P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10 })
			{
			}
		}

		internal sealed class dXUNEgcYfXEVbrQEDgvJkkSXVHHI : UKjBziWrJmWaWcyoXZvyIpiWufDB, IControllerTemplateYoke, IControllerTemplateElement
		{
			private const int wThwRavVrHpWTngojUCqGqRaKTdA = 2;

			IControllerTemplateAxis IControllerTemplateYoke.rotation
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateYoke.pushPull
			{
				get
				{
					if (ReInput._id != rBCBgWdsmqIhnCtOOXKpVKsgUpZtA)
					{
						ReInput.CheckInitialized(rBCBgWdsmqIhnCtOOXKpVKsgUpZtA);
						return null;
					}
					return (IControllerTemplateAxis)JDznczOacqizmCIZwgyQGaNBAXaZ[1];
				}
			}

			private dXUNEgcYfXEVbrQEDgvJkkSXVHHI(IControllerTemplate P_0, int P_1, string P_2, UmpDFlUDDxYLPBuJjjzIyPbLvOof[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Yoke, P_3)
			{
			}

			internal dXUNEgcYfXEVbrQEDgvJkkSXVHHI(IControllerTemplate P_0, int P_1, string P_2, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_3, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_4)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Yoke, new UmpDFlUDDxYLPBuJjjzIyPbLvOof[2] { P_3, P_4 })
			{
			}
		}

		internal sealed class ZuPvlpKOimihjGqfBnnIXsstlwKhA : abLNdOVfTeLAJSShslGfUCUtBEIt, IControllerTemplateStick6D, IControllerTemplateElement
		{
			private const int OBlpirLJkebxMzifrEiNvNsxnXkt = 6;

			private ZuPvlpKOimihjGqfBnnIXsstlwKhA(IControllerTemplate P_0, int P_1, string P_2, UmpDFlUDDxYLPBuJjjzIyPbLvOof[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Stick6D, P_3)
			{
			}

			internal ZuPvlpKOimihjGqfBnnIXsstlwKhA(IControllerTemplate P_0, int P_1, string P_2, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_3, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_4, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_5, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_6, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_7, IkgEsVHKAnBBtLOLjxJCfPlAcZX P_8)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Stick6D, new UmpDFlUDDxYLPBuJjjzIyPbLvOof[6] { P_3, P_4, P_5, P_6, P_7, P_8 })
			{
			}
		}

		internal class buzhpFloWjWnTdgMXIgwYrFTzbzd
		{
			public readonly Controller.Element qOaiyMVJSAOqHFLfDUByXdxcbRugA;

			public readonly IControllerElementTarget dlRCvMAAqyzWdExYPtVAQuafcxhh;

			public bool diEaAjJgXXgQomoTNkPDqGOGMgoCb
			{
				get
				{
					if (qOaiyMVJSAOqHFLfDUByXdxcbRugA == null)
					{
						return false;
					}
					switch (qOaiyMVJSAOqHFLfDUByXdxcbRugA.type)
					{
					case ControllerElementType.Button:
						return (qOaiyMVJSAOqHFLfDUByXdxcbRugA as Controller.Button).value;
					case ControllerElementType.Axis:
					{
						float value = (qOaiyMVJSAOqHFLfDUByXdxcbRugA as Controller.Axis).value;
						switch (dlRCvMAAqyzWdExYPtVAQuafcxhh.axisRange)
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

			public bool fMfVEsCBNdHjEPXdtiNlGvNuEfor
			{
				get
				{
					if (qOaiyMVJSAOqHFLfDUByXdxcbRugA == null)
					{
						return false;
					}
					switch (qOaiyMVJSAOqHFLfDUByXdxcbRugA.type)
					{
					case ControllerElementType.Button:
						return (qOaiyMVJSAOqHFLfDUByXdxcbRugA as Controller.Button).valuePrev;
					case ControllerElementType.Axis:
					{
						float valuePrev = (qOaiyMVJSAOqHFLfDUByXdxcbRugA as Controller.Axis).valuePrev;
						switch (dlRCvMAAqyzWdExYPtVAQuafcxhh.axisRange)
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

			public bool GVYfcrYxkqFqrFAdITVOrzXXnUkR
			{
				get
				{
					if (qOaiyMVJSAOqHFLfDUByXdxcbRugA == null)
					{
						return false;
					}
					switch (qOaiyMVJSAOqHFLfDUByXdxcbRugA.type)
					{
					case ControllerElementType.Button:
						return (qOaiyMVJSAOqHFLfDUByXdxcbRugA as Controller.Button).justPressed;
					case ControllerElementType.Axis:
						if (MathTools.Abs(hjudpidyeSTiawRJFaqnChZUhEWr) > 0.01f && MathTools.Abs(XekdEJaFmajuOCZSFCuagCutBUiWB) <= 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public bool fSTwSbwmPRnNzFWFDmVhUGKBOVPh
			{
				get
				{
					if (qOaiyMVJSAOqHFLfDUByXdxcbRugA == null)
					{
						return false;
					}
					switch (qOaiyMVJSAOqHFLfDUByXdxcbRugA.type)
					{
					case ControllerElementType.Button:
						return (qOaiyMVJSAOqHFLfDUByXdxcbRugA as Controller.Button).justReleased;
					case ControllerElementType.Axis:
						if (MathTools.Abs(hjudpidyeSTiawRJFaqnChZUhEWr) <= 0.01f && MathTools.Abs(XekdEJaFmajuOCZSFCuagCutBUiWB) > 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public float hjudpidyeSTiawRJFaqnChZUhEWr
			{
				get
				{
					if (qOaiyMVJSAOqHFLfDUByXdxcbRugA == null)
					{
						return 0f;
					}
					switch (qOaiyMVJSAOqHFLfDUByXdxcbRugA.type)
					{
					case ControllerElementType.Button:
						if (!(qOaiyMVJSAOqHFLfDUByXdxcbRugA as Controller.Button).value)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float value = (qOaiyMVJSAOqHFLfDUByXdxcbRugA as Controller.Axis).value;
						switch (dlRCvMAAqyzWdExYPtVAQuafcxhh.axisRange)
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

			public float XekdEJaFmajuOCZSFCuagCutBUiWB
			{
				get
				{
					if (qOaiyMVJSAOqHFLfDUByXdxcbRugA == null)
					{
						return 0f;
					}
					switch (qOaiyMVJSAOqHFLfDUByXdxcbRugA.type)
					{
					case ControllerElementType.Button:
						if (!(qOaiyMVJSAOqHFLfDUByXdxcbRugA as Controller.Button).valuePrev)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float valuePrev = (qOaiyMVJSAOqHFLfDUByXdxcbRugA as Controller.Axis).valuePrev;
						switch (dlRCvMAAqyzWdExYPtVAQuafcxhh.axisRange)
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

			public buzhpFloWjWnTdgMXIgwYrFTzbzd(IControllerElementTarget P_0, Controller.Element P_1)
			{
				qOaiyMVJSAOqHFLfDUByXdxcbRugA = P_1;
				dlRCvMAAqyzWdExYPtVAQuafcxhh = P_0;
			}

			public static buzhpFloWjWnTdgMXIgwYrFTzbzd YZAUmUAfddLjBlegoVbwqZqcabeG()
			{
				return new buzhpFloWjWnTdgMXIgwYrFTzbzd(LmZJVlxQhHHugoUPZHYcFkBNejmj.TTzGqiHDtqPPkQzcZWKCaWViogRO(), null);
			}
		}

		internal class JXzIHZYknkrhttLCHgUaUJTpbmvd
		{
			public readonly Controller JCTHOdthpNKUkXIJuywHAqXUBCVH;

			public readonly IHardwareControllerTemplateMap_Internal gTkSLlwynKLudvDYwMtQDMIlOfFO;

			public JXzIHZYknkrhttLCHgUaUJTpbmvd(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				JCTHOdthpNKUkXIJuywHAqXUBCVH = P_0;
				gTkSLlwynKLudvDYwMtQDMIlOfFO = P_1;
			}
		}

		private readonly string PWvFrdbsalyseRXwtCCMICkIGWkJA;

		private readonly Guid jZEuxDTIVutjQTugdtrgXxeWZWae;

		private readonly Controller byMeALRoanozPwVOCtGLVGoYErNAA;

		private readonly ADictionary<int, IControllerTemplateElement> BXhNKfQjGoSRnSfQUGUVccPoqHLh;

		private readonly ADictionary<string, IControllerTemplateElement> qHSgexcBhYUviEmZHuEaRKfjHLwYA;

		private IControllerTemplateElement[] rIOKdHigCBGavLsHXZYJrvFbxIRu;

		private ReadOnlyCollection<IControllerTemplateElement> RBCBTpJXAuyYtMqStPrKyRCjGkYuA;

		private readonly int UFGSJTWASgRfVVFWxkOTOddHvlOB;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != UFGSJTWASgRfVVFWxkOTOddHvlOB)
				{
					ReInput.CheckInitialized(UFGSJTWASgRfVVFWxkOTOddHvlOB);
					return null;
				}
				return byMeALRoanozPwVOCtGLVGoYErNAA;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != UFGSJTWASgRfVVFWxkOTOddHvlOB)
				{
					ReInput.CheckInitialized(UFGSJTWASgRfVVFWxkOTOddHvlOB);
					return null;
				}
				return PWvFrdbsalyseRXwtCCMICkIGWkJA;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != UFGSJTWASgRfVVFWxkOTOddHvlOB)
				{
					ReInput.CheckInitialized(UFGSJTWASgRfVVFWxkOTOddHvlOB);
					return Guid.Empty;
				}
				return jZEuxDTIVutjQTugdtrgXxeWZWae;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != UFGSJTWASgRfVVFWxkOTOddHvlOB)
				{
					ReInput.CheckInitialized(UFGSJTWASgRfVVFWxkOTOddHvlOB);
					return null;
				}
				return RBCBTpJXAuyYtMqStPrKyRCjGkYuA;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != UFGSJTWASgRfVVFWxkOTOddHvlOB)
				{
					ReInput.CheckInitialized(UFGSJTWASgRfVVFWxkOTOddHvlOB);
					return 0;
				}
				return rIOKdHigCBGavLsHXZYJrvFbxIRu.Length;
			}
		}

		protected ControllerTemplate(object P_0)
			: this((JXzIHZYknkrhttLCHgUaUJTpbmvd)P_0)
		{
		}

		private ControllerTemplate(JXzIHZYknkrhttLCHgUaUJTpbmvd P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (P_0.JCTHOdthpNKUkXIJuywHAqXUBCVH == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (P_0.gTkSLlwynKLudvDYwMtQDMIlOfFO == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			UFGSJTWASgRfVVFWxkOTOddHvlOB = ReInput.id;
			byMeALRoanozPwVOCtGLVGoYErNAA = P_0.JCTHOdthpNKUkXIJuywHAqXUBCVH;
			IHardwareControllerTemplateMap_Internal gTkSLlwynKLudvDYwMtQDMIlOfFO = P_0.gTkSLlwynKLudvDYwMtQDMIlOfFO;
			PWvFrdbsalyseRXwtCCMICkIGWkJA = gTkSLlwynKLudvDYwMtQDMIlOfFO.name;
			jZEuxDTIVutjQTugdtrgXxeWZWae = gTkSLlwynKLudvDYwMtQDMIlOfFO.typeGuid;
			int elementIdentifierCount = gTkSLlwynKLudvDYwMtQDMIlOfFO.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = gTkSLlwynKLudvDYwMtQDMIlOfFO.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						wzVNvKxdfLgPZGLFDmLcrCdHxsec wzVNvKxdfLgPZGLFDmLcrCdHxsec3 = gTkSLlwynKLudvDYwMtQDMIlOfFO.GetAxisTarget(byMeALRoanozPwVOCtGLVGoYErNAA, templateElementIdentifier.id) ?? wzVNvKxdfLgPZGLFDmLcrCdHxsec.zEoyTjVDsjfgGhOOPsiGOIZOMqbcb(ControllerTemplateElementType.Axis);
						hVekINgPhiNZXNtCeHeEhBdsPYMn item2 = new hVekINgPhiNZXNtCeHeEhBdsPYMn(this, templateElementIdentifier.id, templateElementIdentifier.name, (!string.IsNullOrEmpty(templateElementIdentifier.positiveName)) ? templateElementIdentifier.positiveName : (templateElementIdentifier.name + " +"), (!string.IsNullOrEmpty(templateElementIdentifier.negativeName)) ? templateElementIdentifier.negativeName : (templateElementIdentifier.name + " -"), wzVNvKxdfLgPZGLFDmLcrCdHxsec3, DBlhiaKUCYWViBAWqnoMOdQEQLIiA(byMeALRoanozPwVOCtGLVGoYErNAA, wzVNvKxdfLgPZGLFDmLcrCdHxsec3));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						wzVNvKxdfLgPZGLFDmLcrCdHxsec wzVNvKxdfLgPZGLFDmLcrCdHxsec2 = gTkSLlwynKLudvDYwMtQDMIlOfFO.GetButtonTarget(byMeALRoanozPwVOCtGLVGoYErNAA, templateElementIdentifier.id) ?? wzVNvKxdfLgPZGLFDmLcrCdHxsec.zEoyTjVDsjfgGhOOPsiGOIZOMqbcb(ControllerTemplateElementType.Button);
						CtGgVEbhCcKsMuEGhwkkqIhjExTYA item = new CtGgVEbhCcKsMuEGhwkkqIhjExTYA(this, templateElementIdentifier.id, templateElementIdentifier.name, templateElementIdentifier.name, templateElementIdentifier.name + " -", wzVNvKxdfLgPZGLFDmLcrCdHxsec2, WolHtJkwVThxxCCqFFPbdwdJMpKFA(byMeALRoanozPwVOCtGLVGoYErNAA, wzVNvKxdfLgPZGLFDmLcrCdHxsec2));
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
				IControllerTemplateElementIdentifier templateElementIdentifier2 = gTkSLlwynKLudvDYwMtQDMIlOfFO.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = gTkSLlwynKLudvDYwMtQDMIlOfFO.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				UmpDFlUDDxYLPBuJjjzIyPbLvOof umpDFlUDDxYLPBuJjjzIyPbLvOof;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					umpDFlUDDxYLPBuJjjzIyPbLvOof = new jzaJvgddDvgwlUGlbbPeeDQhmviK(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping5 != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping5.eid_axisX) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this), (mapping5 != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping5.eid_axisY) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this), (mapping5 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping5.eid_button) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					umpDFlUDDxYLPBuJjjzIyPbLvOof = new HxJBrhCuEmpiUKYHNOvzxQuIITae(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping3 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping3.eid_up) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this), (mapping3 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping3.eid_right) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this), (mapping3 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping3.eid_down) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this), (mapping3 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping3.eid_left) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this), (mapping3 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping3.eid_press) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					umpDFlUDDxYLPBuJjjzIyPbLvOof = new kcJraEFvsInOBhmOUCOpItzeAdFVA(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping2 != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping2.eid_axisX) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this), (mapping2 != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping2.eid_axisY) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this), (mapping2 != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping2.eid_axisZ) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					umpDFlUDDxYLPBuJjjzIyPbLvOof = new AszeGLXHWmvMnsZabGymyuPUGnWx(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping6 != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping6.eid_axis) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this), (mapping6 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping6.eid_minDetent) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					umpDFlUDDxYLPBuJjjzIyPbLvOof = new taZGKTbySYsRkIHMwhNBdCNFVPgic(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping7 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping7.eid_up) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this), (mapping7 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping7.eid_upRight) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this), (mapping7 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping7.eid_right) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this), (mapping7 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping7.eid_downRight) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this), (mapping7 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping7.eid_down) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this), (mapping7 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping7.eid_downLeft) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this), (mapping7 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping7.eid_left) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this), (mapping7 != null) ? IdEvKBFRJUUubGXJTEihBQcSakLL(this, aDictionary, mapping7.eid_upLeft) : CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					umpDFlUDDxYLPBuJjjzIyPbLvOof = new dXUNEgcYfXEVbrQEDgvJkkSXVHHI(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping4 != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping4.eid_axisX) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this), (mapping4 != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping4.eid_axisZ) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					umpDFlUDDxYLPBuJjjzIyPbLvOof = new ZuPvlpKOimihjGqfBnnIXsstlwKhA(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping.eid_positionX) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this), (mapping != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping.eid_positionY) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this), (mapping != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping.eid_positionZ) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this), (mapping != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping.eid_rotationX) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this), (mapping != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping.eid_rotationY) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this), (mapping != null) ? wgdSppRXcOcywcJqizQaVjDNgbbV(this, aDictionary, mapping.eid_rotationZ) : hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (umpDFlUDDxYLPBuJjjzIyPbLvOof != null)
				{
					list4.Add(umpDFlUDDxYLPBuJjjzIyPbLvOof);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			rIOKdHigCBGavLsHXZYJrvFbxIRu = list.ToArray();
			BXhNKfQjGoSRnSfQUGUVccPoqHLh = aDictionary;
			qHSgexcBhYUviEmZHuEaRKfjHLwYA = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < rIOKdHigCBGavLsHXZYJrvFbxIRu.Length; num++)
			{
				if (!(gTkSLlwynKLudvDYwMtQDMIlOfFO.GetTemplateElementIdentifierById(rIOKdHigCBGavLsHXZYJrvFbxIRu[num].id) is IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor))
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
							qHSgexcBhYUviEmZHuEaRKfjHLwYA.Add(text, rIOKdHigCBGavLsHXZYJrvFbxIRu[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + PWvFrdbsalyseRXwtCCMICkIGWkJA + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			RBCBTpJXAuyYtMqStPrKyRCjGkYuA = new ReadOnlyCollection<IControllerTemplateElement>(rIOKdHigCBGavLsHXZYJrvFbxIRu);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			if (!BXhNKfQjGoSRnSfQUGUVccPoqHLh.TryGetValue(id, out var value))
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
			if (ReInput._id != UFGSJTWASgRfVVFWxkOTOddHvlOB)
			{
				ReInput.CheckInitialized(UFGSJTWASgRfVVFWxkOTOddHvlOB);
				return null;
			}
			return GetElement(id);
		}

		T IControllerTemplate.GetElement<T>(int id)
		{
			if (ReInput._id != UFGSJTWASgRfVVFWxkOTOddHvlOB)
			{
				ReInput.CheckInitialized(UFGSJTWASgRfVVFWxkOTOddHvlOB);
				return null;
			}
			return GetElement<T>(id);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget find, IList<ControllerTemplateElementTarget> results)
		{
			if (ReInput._id != UFGSJTWASgRfVVFWxkOTOddHvlOB)
			{
				ReInput.CheckInitialized(UFGSJTWASgRfVVFWxkOTOddHvlOB);
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
			for (int i = 0; i < rIOKdHigCBGavLsHXZYJrvFbxIRu.Length; i++)
			{
				if (InputTools.IsMappableType(rIOKdHigCBGavLsHXZYJrvFbxIRu[i].type))
				{
					num += (rIOKdHigCBGavLsHXZYJrvFbxIRu[i] as IControllerTemplateElement_Internal).GetElementTargets(find, ref results);
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

		private static IList<buzhpFloWjWnTdgMXIgwYrFTzbzd> DBlhiaKUCYWViBAWqnoMOdQEQLIiA(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			if (P_1.splitAxis)
			{
				IList<buzhpFloWjWnTdgMXIgwYrFTzbzd> list = null;
				bool flag = false;
				if (P_1.positiveTarget != null)
				{
					Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					if (elementById != null)
					{
						ListTools.AddAndCreateList(ref list, new buzhpFloWjWnTdgMXIgwYrFTzbzd(P_1.positiveTarget, elementById));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, buzhpFloWjWnTdgMXIgwYrFTzbzd.YZAUmUAfddLjBlegoVbwqZqcabeG());
				}
				flag = false;
				if (P_1.negativeTarget != null)
				{
					Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
					if (elementById2 != null)
					{
						ListTools.AddAndCreateList(ref list, new buzhpFloWjWnTdgMXIgwYrFTzbzd(P_1.negativeTarget, elementById2));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, buzhpFloWjWnTdgMXIgwYrFTzbzd.YZAUmUAfddLjBlegoVbwqZqcabeG());
				}
				return list;
			}
			return dJSCkgdxWfCMbKEsXbAWwVKFWjtUA(P_0, P_1.fullTarget);
		}

		private static IList<buzhpFloWjWnTdgMXIgwYrFTzbzd> WolHtJkwVThxxCCqFFPbdwdJMpKFA(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return dJSCkgdxWfCMbKEsXbAWwVKFWjtUA(P_0, P_1.target);
		}

		private static IList<buzhpFloWjWnTdgMXIgwYrFTzbzd> dJSCkgdxWfCMbKEsXbAWwVKFWjtUA(Controller P_0, IControllerElementTarget P_1)
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
			return new List<buzhpFloWjWnTdgMXIgwYrFTzbzd>
			{
				new buzhpFloWjWnTdgMXIgwYrFTzbzd(P_1, elementById)
			};
		}

		private static IControllerTemplateElement YNnKZPjffbPUikvPXPtQCALEEsGj(List<IControllerTemplateElement> P_0, int P_1)
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

		private static IkgEsVHKAnBBtLOLjxJCfPlAcZX wgdSppRXcOcywcJqizQaVjDNgbbV(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is IkgEsVHKAnBBtLOLjxJCfPlAcZX result))
			{
				return hVekINgPhiNZXNtCeHeEhBdsPYMn.IiRwCrihYACOfRVLveDKapaCZUnE(P_0);
			}
			return result;
		}

		private static IkgEsVHKAnBBtLOLjxJCfPlAcZX IdEvKBFRJUUubGXJTEihBQcSakLL(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is IkgEsVHKAnBBtLOLjxJCfPlAcZX result))
			{
				return CtGgVEbhCcKsMuEGhwkkqIhjExTYA.qRTDNdCLknRjcULCqDAnYxLLSASM(P_0);
			}
			return result;
		}
	}
}
