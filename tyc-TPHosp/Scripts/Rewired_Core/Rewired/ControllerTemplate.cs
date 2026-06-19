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
		internal abstract class IfBmCtvAuPEdSddWDhyHuNwFNIS : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate TKnWISxZiQPTaIhKpEMkcaWQSuD;

			private readonly int fOjavGziuUSawAgvwyVARpyRBVx;

			private readonly string YckvCvRVVkCnFoBTmVxvWZVKnMr;

			private readonly ControllerTemplateElementType wZYPyxmKgRSHjYJwEjuLiELShEK;

			protected readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

			public int id
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return -1;
					}
					return fOjavGziuUSawAgvwyVARpyRBVx;
				}
			}

			public string descriptiveName
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return YckvCvRVVkCnFoBTmVxvWZVKnMr;
				}
			}

			public ControllerTemplateElementType type
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return ControllerTemplateElementType.Axis;
					}
					return wZYPyxmKgRSHjYJwEjuLiELShEK;
				}
			}

			public IControllerTemplate parent => TKnWISxZiQPTaIhKpEMkcaWQSuD;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected IfBmCtvAuPEdSddWDhyHuNwFNIS(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType)
			{
				if (parent == null)
				{
					throw new ArgumentNullException("parent");
				}
				TKnWISxZiQPTaIhKpEMkcaWQSuD = parent;
				fOjavGziuUSawAgvwyVARpyRBVx = id;
				YckvCvRVVkCnFoBTmVxvWZVKnMr = name;
				wZYPyxmKgRSHjYJwEjuLiELShEK = elementType;
				fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput.id;
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);
		}

		internal abstract class UOUZzczpXufJMYTCYIGPjqPmGoXc : IfBmCtvAuPEdSddWDhyHuNwFNIS
		{
			protected readonly int LBQoUIwZmUUgazhhdYeRLuIQfEV;

			protected readonly lXTMcZYLLZNvKTtfvWTrtvcXStJ[] THiBLCPXoGjOrKwhULBWmwQMLUv;

			public override bool exists
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (THiBLCPXoGjOrKwhULBWmwQMLUv == null)
					{
						return false;
					}
					for (int i = 0; i < THiBLCPXoGjOrKwhULBWmwQMLUv.Length; i++)
					{
						if (THiBLCPXoGjOrKwhULBWmwQMLUv[i].pEsVixgorzFkhlKMiSFTVBzHAOS != null)
						{
							return true;
						}
					}
					return false;
				}
			}

			protected UOUZzczpXufJMYTCYIGPjqPmGoXc(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, IList<lXTMcZYLLZNvKTtfvWTrtvcXStJ> sourceElements)
				: base(parent, id, name, elementType)
			{
				THiBLCPXoGjOrKwhULBWmwQMLUv = ((sourceElements != null) ? ListTools.ToArray(sourceElements) : null);
				LBQoUIwZmUUgazhhdYeRLuIQfEV = ((THiBLCPXoGjOrKwhULBWmwQMLUv != null) ? THiBLCPXoGjOrKwhULBWmwQMLUv.Length : 0);
			}
		}

		internal abstract class KkIHJcsvjeRuOXUHrrwAjNKjPNv : UOUZzczpXufJMYTCYIGPjqPmGoXc, IControllerTemplateElement, IControllerTemplateAxis, IControllerTemplateButton
		{
			private uRvJKnYnMDIXSDaSbLxWqKFPfOYl lpUDMEmXzhZtLWlAXkyddMkXuPw;

			private string RiwygGQCKkippKTaJQTxEcyEzjxJ;

			private string XxmDqqxAqzhHodoRQDaGbLnpJSy;

			public float floatValue
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					if (LBQoUIwZmUUgazhhdYeRLuIQfEV == 1)
					{
						return THiBLCPXoGjOrKwhULBWmwQMLUv[0].floatValue;
					}
					if (LBQoUIwZmUUgazhhdYeRLuIQfEV == 2)
					{
						float num = THiBLCPXoGjOrKwhULBWmwQMLUv[0].floatValue;
						float num2 = THiBLCPXoGjOrKwhULBWmwQMLUv[1].floatValue;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public float floatValuePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					if (LBQoUIwZmUUgazhhdYeRLuIQfEV == 1)
					{
						return THiBLCPXoGjOrKwhULBWmwQMLUv[0].floatValuePrev;
					}
					if (LBQoUIwZmUUgazhhdYeRLuIQfEV == 2)
					{
						float num = THiBLCPXoGjOrKwhULBWmwQMLUv[0].floatValuePrev;
						float num2 = THiBLCPXoGjOrKwhULBWmwQMLUv[1].floatValuePrev;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool boolValue
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (LBQoUIwZmUUgazhhdYeRLuIQfEV == 1)
					{
						return THiBLCPXoGjOrKwhULBWmwQMLUv[0].boolValue;
					}
					if (LBQoUIwZmUUgazhhdYeRLuIQfEV == 2)
					{
						if (!THiBLCPXoGjOrKwhULBWmwQMLUv[0].boolValue)
						{
							return THiBLCPXoGjOrKwhULBWmwQMLUv[1].boolValue;
						}
						return true;
					}
					return false;
				}
			}

			public bool boolValuePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (LBQoUIwZmUUgazhhdYeRLuIQfEV == 1)
					{
						return THiBLCPXoGjOrKwhULBWmwQMLUv[0].boolValuePrev;
					}
					if (LBQoUIwZmUUgazhhdYeRLuIQfEV == 2)
					{
						if (!THiBLCPXoGjOrKwhULBWmwQMLUv[0].boolValuePrev)
						{
							return THiBLCPXoGjOrKwhULBWmwQMLUv[1].boolValuePrev;
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
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return RiwygGQCKkippKTaJQTxEcyEzjxJ;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return XxmDqqxAqzhHodoRQDaGbLnpJSy;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					return floatValue;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					return floatValuePrev;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return lpUDMEmXzhZtLWlAXkyddMkXuPw;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return boolValue;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return boolValuePrev;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (LBQoUIwZmUUgazhhdYeRLuIQfEV == 1)
					{
						return THiBLCPXoGjOrKwhULBWmwQMLUv[0].justPressed;
					}
					if (LBQoUIwZmUUgazhhdYeRLuIQfEV == 2)
					{
						if (!THiBLCPXoGjOrKwhULBWmwQMLUv[0].justPressed || THiBLCPXoGjOrKwhULBWmwQMLUv[1].boolValuePrev)
						{
							if (THiBLCPXoGjOrKwhULBWmwQMLUv[1].justPressed)
							{
								return !THiBLCPXoGjOrKwhULBWmwQMLUv[0].boolValuePrev;
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
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (LBQoUIwZmUUgazhhdYeRLuIQfEV == 1)
					{
						return THiBLCPXoGjOrKwhULBWmwQMLUv[0].justReleased;
					}
					if (LBQoUIwZmUUgazhhdYeRLuIQfEV == 2)
					{
						if (!THiBLCPXoGjOrKwhULBWmwQMLUv[0].justReleased || THiBLCPXoGjOrKwhULBWmwQMLUv[1].boolValue)
						{
							if (THiBLCPXoGjOrKwhULBWmwQMLUv[1].justReleased)
							{
								return !THiBLCPXoGjOrKwhULBWmwQMLUv[0].boolValue;
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
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return boolValue != boolValuePrev;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					return floatValue;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					return floatValuePrev;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return lpUDMEmXzhZtLWlAXkyddMkXuPw;
				}
			}

			public override IControllerTemplateElementSource source
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return lpUDMEmXzhZtLWlAXkyddMkXuPw;
				}
			}

			public override int elementCount => 0;

			public IControllerTemplateAxis AsAxis
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return this;
				}
			}

			public IControllerTemplateButton AsButton
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return this;
				}
			}

			protected KkIHJcsvjeRuOXUHrrwAjNKjPNv(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, ControllerTemplateElementType elementType, uRvJKnYnMDIXSDaSbLxWqKFPfOYl target, IList<lXTMcZYLLZNvKTtfvWTrtvcXStJ> sourceElements)
				: base(parent, id, name, elementType, sourceElements)
			{
				if (sourceElements != null && sourceElements.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
				if (target == null)
				{
					throw new ArgumentNullException("target");
				}
				lpUDMEmXzhZtLWlAXkyddMkXuPw = target;
				RiwygGQCKkippKTaJQTxEcyEzjxJ = positiveName;
				XxmDqqxAqzhHodoRQDaGbLnpJSy = negativeName;
			}

			private string eIZLHVKMPVHsUkjmBshRlAiHXZMN(AxisRange P_0)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return P_0 switch
				{
					AxisRange.Full => base.descriptiveName, 
					AxisRange.Positive => RiwygGQCKkippKTaJQTxEcyEzjxJ, 
					AxisRange.Negative => XxmDqqxAqzhHodoRQDaGbLnpJSy, 
					_ => throw new NotImplementedException(), 
				};
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in eIZLHVKMPVHsUkjmBshRlAiHXZMN
				return this.eIZLHVKMPVHsUkjmBshRlAiHXZMN(P_0);
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
					IControllerTemplateAxisSource controllerTemplateAxisSource = lpUDMEmXzhZtLWlAXkyddMkXuPw;
					if (controllerTemplateAxisSource.splitAxis)
					{
						if (mEzJcZNNOkYLwUirMCBkSlpjalq(find, controllerTemplateAxisSource.positiveTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
							num++;
						}
						if (mEzJcZNNOkYLwUirMCBkSlpjalq(find, controllerTemplateAxisSource.negativeTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
							num++;
						}
					}
					else if (mEzJcZNNOkYLwUirMCBkSlpjalq(find, controllerTemplateAxisSource.fullTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
						num++;
					}
					break;
				}
				case ControllerTemplateElementType.Button:
					if (mEzJcZNNOkYLwUirMCBkSlpjalq(find, ((IControllerTemplateButtonSource)lpUDMEmXzhZtLWlAXkyddMkXuPw).target))
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

			private static bool mEzJcZNNOkYLwUirMCBkSlpjalq(ControllerElementTarget P_0, IControllerElementTarget P_1)
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

		internal sealed class pVGFRtHMiCgSutDlKtBaEynyryH : KkIHJcsvjeRuOXUHrrwAjNKjPNv
		{
			public pVGFRtHMiCgSutDlKtBaEynyryH(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, uRvJKnYnMDIXSDaSbLxWqKFPfOYl target, IList<lXTMcZYLLZNvKTtfvWTrtvcXStJ> sourceElements)
				: base(parent, id, name, positiveName, negativeName, ControllerTemplateElementType.Axis, target, sourceElements)
			{
				if (sourceElements != null && sourceElements.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static pVGFRtHMiCgSutDlKtBaEynyryH AapzLJOSMOptjeIdgEhpjxotmUy(IControllerTemplate P_0)
			{
				return new pVGFRtHMiCgSutDlKtBaEynyryH(P_0, -1, string.Empty, string.Empty, string.Empty, uRvJKnYnMDIXSDaSbLxWqKFPfOYl.AapzLJOSMOptjeIdgEhpjxotmUy(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class CdwbAEQwjOrZBeiNLenzdTmbqCn : KkIHJcsvjeRuOXUHrrwAjNKjPNv
		{
			public CdwbAEQwjOrZBeiNLenzdTmbqCn(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, uRvJKnYnMDIXSDaSbLxWqKFPfOYl target, IList<lXTMcZYLLZNvKTtfvWTrtvcXStJ> sourceElements)
				: base(parent, id, name, positiveName, negativeName, ControllerTemplateElementType.Button, target, sourceElements)
			{
				if (sourceElements != null && sourceElements.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static CdwbAEQwjOrZBeiNLenzdTmbqCn AapzLJOSMOptjeIdgEhpjxotmUy(IControllerTemplate P_0)
			{
				return new CdwbAEQwjOrZBeiNLenzdTmbqCn(P_0, -1, string.Empty, string.Empty, string.Empty, uRvJKnYnMDIXSDaSbLxWqKFPfOYl.AapzLJOSMOptjeIdgEhpjxotmUy(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class oxuIqFysqrcoQsSFTYAkDKudUUr : IfBmCtvAuPEdSddWDhyHuNwFNIS
		{
			protected readonly int AsQmycNkDaREuDCwWmhZMiVAlod;

			protected readonly IfBmCtvAuPEdSddWDhyHuNwFNIS[] KFQlRixtegtOhokPEQnlitLaJDS;

			public override bool exists
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					for (int i = 0; i < AsQmycNkDaREuDCwWmhZMiVAlod; i++)
					{
						if (KFQlRixtegtOhokPEQnlitLaJDS[i].exists)
						{
							return true;
						}
					}
					return false;
				}
			}

			public override IControllerTemplateElementSource source
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return null;
				}
			}

			public override int elementCount => AsQmycNkDaREuDCwWmhZMiVAlod;

			protected oxuIqFysqrcoQsSFTYAkDKudUUr(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, IfBmCtvAuPEdSddWDhyHuNwFNIS[] elements)
				: base(parent, id, name, elementType)
			{
				if (elements == null)
				{
					throw new ArgumentNullException("elements");
				}
				if (elements.Length == 0)
				{
					throw new ArgumentException("elements.Length is zero.");
				}
				for (int i = 0; i < elements.Length; i++)
				{
					if (elements[i] == null)
					{
						throw new ArgumentNullException("elements contains a null entry.");
					}
				}
				KFQlRixtegtOhokPEQnlitLaJDS = elements;
				AsQmycNkDaREuDCwWmhZMiVAlod = elements.Length;
			}

			public virtual IControllerTemplateElement WChpoUjfxVomSqiESmHoqccMwdg(int P_0)
			{
				return KFQlRixtegtOhokPEQnlitLaJDS[P_0];
			}

			public virtual int KenBlNhdSLhpxqdduCjQVQrWAen(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				for (int i = 0; i < KFQlRixtegtOhokPEQnlitLaJDS.Length; i++)
				{
					num += KFQlRixtegtOhokPEQnlitLaJDS[i].GetElementTargets(P_0, ref P_1);
				}
				return num;
			}
		}

		internal abstract class GgXfCnhgMOzljOtxjTKmxxwQeLV : oxuIqFysqrcoQsSFTYAkDKudUUr, IControllerTemplateElement, IControllerTemplateAxis2D
		{
			protected const int mmnEjfaKEEANUazKZKaRtfBdBfO = 0;

			protected const int FHqrGAfdWrSJJIowCdPpFHZXBsgm = 1;

			protected const int aoJDxODtyJKzFfiZMkUQEkuMAcB = 2;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector2.zero;
					}
					return new Vector2((AsQmycNkDaREuDCwWmhZMiVAlod > 0) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[0]).floatValue : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 1) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[1]).floatValue : 0f);
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector2.zero;
					}
					return new Vector2((AsQmycNkDaREuDCwWmhZMiVAlod > 0) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[0]).floatValuePrev : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 1) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[1]).floatValuePrev : 0f);
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[1];
				}
			}

			protected GgXfCnhgMOzljOtxjTKmxxwQeLV(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, IfBmCtvAuPEdSddWDhyHuNwFNIS[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal abstract class AJlLSGHdhwyIqteCnJFGnYjLgGi : oxuIqFysqrcoQsSFTYAkDKudUUr, IControllerTemplateElement, IControllerTemplateAxis3D
		{
			protected const int mmnEjfaKEEANUazKZKaRtfBdBfO = 0;

			protected const int FHqrGAfdWrSJJIowCdPpFHZXBsgm = 1;

			protected const int TAPpiuRPiCRUyBgjDIdoVnsAghk = 2;

			protected const int aoJDxODtyJKzFfiZMkUQEkuMAcB = 3;

			public Vector3 value
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector3.zero;
					}
					return new Vector3((AsQmycNkDaREuDCwWmhZMiVAlod > 0) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[0]).floatValue : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 1) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[1]).floatValue : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 2) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[2]).floatValue : 0f);
				}
			}

			public Vector3 valuePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector3.zero;
					}
					return new Vector3((AsQmycNkDaREuDCwWmhZMiVAlod > 0) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[0]).floatValuePrev : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 1) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[1]).floatValuePrev : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 2) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[2]).floatValuePrev : 0f);
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[1];
				}
			}

			public IControllerTemplateAxis depth
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[2];
				}
			}

			protected AJlLSGHdhwyIqteCnJFGnYjLgGi(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, IfBmCtvAuPEdSddWDhyHuNwFNIS[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal abstract class irxlKOcAmGHwAasqKjougrPbxvky : oxuIqFysqrcoQsSFTYAkDKudUUr, IControllerTemplateElement, IControllerTemplateAxis6D
		{
			protected const int AJFavIhaOxDkYYWOywfZJiXGJTsq = 0;

			protected const int VBSpnADylVsVxvlOOcTszOotvLa = 1;

			protected const int izahnKjNuMKJrjYNaUXCepNdqkKM = 2;

			protected const int BpwbmndwmvvjPSIuBgkXCfyyAYqD = 3;

			protected const int wqNITfklmYykckOcNbxrXgRlPGf = 4;

			protected const int iKoYeYFbIwuSkDPsPrLMZdaiSpc = 5;

			protected const int aoJDxODtyJKzFfiZMkUQEkuMAcB = 6;

			public Vector3 position
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector3.zero;
					}
					return new Vector3((AsQmycNkDaREuDCwWmhZMiVAlod > 0) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[0]).floatValue : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 1) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[1]).floatValue : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 2) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[2]).floatValue : 0f);
				}
			}

			public Vector3 positionPrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector3.zero;
					}
					return new Vector3((AsQmycNkDaREuDCwWmhZMiVAlod > 0) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[0]).floatValuePrev : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 1) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[1]).floatValuePrev : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 2) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[2]).floatValuePrev : 0f);
				}
			}

			public Vector3 rotation
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector3.zero;
					}
					return new Vector3((AsQmycNkDaREuDCwWmhZMiVAlod > 3) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[3]).floatValue : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 4) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[4]).floatValue : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 5) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[5]).floatValue : 0f);
				}
			}

			public Vector3 rotationPrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector3.zero;
					}
					return new Vector3((AsQmycNkDaREuDCwWmhZMiVAlod > 3) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[3]).floatValuePrev : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 4) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[4]).floatValuePrev : 0f, (AsQmycNkDaREuDCwWmhZMiVAlod > 5) ? ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[5]).floatValuePrev : 0f);
				}
			}

			public IControllerTemplateAxis positionX
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[0];
				}
			}

			public IControllerTemplateAxis positionY
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[1];
				}
			}

			public IControllerTemplateAxis positionZ
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[2];
				}
			}

			public IControllerTemplateAxis rotationX
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[3];
				}
			}

			public IControllerTemplateAxis rotationY
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[4];
				}
			}

			public IControllerTemplateAxis rotationZ
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[5];
				}
			}

			protected irxlKOcAmGHwAasqKjougrPbxvky(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, IfBmCtvAuPEdSddWDhyHuNwFNIS[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal sealed class yQpbKWcDsgnCAPiXuTqiSktwIGx : AJlLSGHdhwyIqteCnJFGnYjLgGi, IControllerTemplateElement, IControllerTemplateStick
		{
			private new const int aoJDxODtyJKzFfiZMkUQEkuMAcB = 3;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[2];
				}
			}

			private yQpbKWcDsgnCAPiXuTqiSktwIGx(IControllerTemplate parent, int id, string name, IfBmCtvAuPEdSddWDhyHuNwFNIS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Stick, elements)
			{
				if (elements.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			public yQpbKWcDsgnCAPiXuTqiSktwIGx(IControllerTemplate parent, int id, string name, KkIHJcsvjeRuOXUHrrwAjNKjPNv xAxis, KkIHJcsvjeRuOXUHrrwAjNKjPNv yAxis, KkIHJcsvjeRuOXUHrrwAjNKjPNv zAxis)
				: this(parent, id, name, new IfBmCtvAuPEdSddWDhyHuNwFNIS[3] { xAxis, yAxis, zAxis })
			{
			}
		}

		internal sealed class jtOoIiMLsPqZeuAeFampHNFhKXQt : GgXfCnhgMOzljOtxjTKmxxwQeLV, IControllerTemplateElement, IControllerTemplateThumbStick
		{
			private const int wpEkejbkAyzquKAXdWZbBzvtGZI = 2;

			private new const int aoJDxODtyJKzFfiZMkUQEkuMAcB = 3;

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[2];
				}
			}

			private jtOoIiMLsPqZeuAeFampHNFhKXQt(IControllerTemplate parent, int id, string name, IfBmCtvAuPEdSddWDhyHuNwFNIS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.ThumbStick, elements)
			{
				if (elements.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal jtOoIiMLsPqZeuAeFampHNFhKXQt(IControllerTemplate parent, int id, string name, KkIHJcsvjeRuOXUHrrwAjNKjPNv xAxis, KkIHJcsvjeRuOXUHrrwAjNKjPNv yAxis, KkIHJcsvjeRuOXUHrrwAjNKjPNv button)
				: this(parent, id, name, new IfBmCtvAuPEdSddWDhyHuNwFNIS[3] { xAxis, yAxis, button })
			{
			}
		}

		internal sealed class BUtjGrveHGGMRiTDzZBcYtJUEnK : oxuIqFysqrcoQsSFTYAkDKudUUr, IControllerTemplateElement, IControllerTemplateDPad
		{
			private const int kjCWceKnekkwuBDJxDEJEsIdfbcr = 0;

			private const int nXMBRysXIBdTiHWgPoGNtpIBImL = 1;

			private const int PKYrpQSLHOqPrPIDXtWXazbcFkc = 2;

			private const int hDmgvhLRGOdGdBZVVdgnaAqmPHOQ = 3;

			private const int XtRBHqGHqQZbnOFwUXLIAlcsTVKM = 4;

			private const int aoJDxODtyJKzFfiZMkUQEkuMAcB = 5;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[0]).floatValue + ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[2]).floatValue * -1f, -1f, 1f), MathTools.Clamp(((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[3]).floatValue * -1f + ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[1]).floatValue, -1f, 1f));
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[0]).floatValuePrev + ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[2]).floatValuePrev * -1f, -1f, 1f), MathTools.Clamp(((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[3]).floatValuePrev * -1f + ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[1]).floatValuePrev, -1f, 1f));
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[0];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[1];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[2];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[3];
				}
			}

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[4];
				}
			}

			private BUtjGrveHGGMRiTDzZBcYtJUEnK(IControllerTemplate parent, int id, string name, IfBmCtvAuPEdSddWDhyHuNwFNIS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.DPad, elements)
			{
				if (elements.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal BUtjGrveHGGMRiTDzZBcYtJUEnK(IControllerTemplate parent, int id, string name, KkIHJcsvjeRuOXUHrrwAjNKjPNv up, KkIHJcsvjeRuOXUHrrwAjNKjPNv right, KkIHJcsvjeRuOXUHrrwAjNKjPNv down, KkIHJcsvjeRuOXUHrrwAjNKjPNv left, KkIHJcsvjeRuOXUHrrwAjNKjPNv press)
				: this(parent, id, name, new IfBmCtvAuPEdSddWDhyHuNwFNIS[5] { up, right, down, left, press })
			{
			}
		}

		internal sealed class INqLVxqtOatuCSfbFllgPUbWIdm : oxuIqFysqrcoQsSFTYAkDKudUUr, IControllerTemplateElement, IControllerTemplateThrottle
		{
			private const int BYcFvzmZKGbXneWMbFyrkhlBsJU = 0;

			private const int MNVksqcidMAWNEKKTiQqykcGTWO = 1;

			private const int aoJDxODtyJKzFfiZMkUQEkuMAcB = 2;

			public float value
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					return ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[0]).floatValue;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					return ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[0]).floatValuePrev;
				}
			}

			public IControllerTemplateAxis throttle
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[0];
				}
			}

			public IControllerTemplateButton minDetent
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[1];
				}
			}

			private INqLVxqtOatuCSfbFllgPUbWIdm(IControllerTemplate parent, int id, string name, IfBmCtvAuPEdSddWDhyHuNwFNIS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Throttle, elements)
			{
				if (elements.Length != 2)
				{
					throw new ArgumentException("elements.Length must be " + 2);
				}
			}

			internal INqLVxqtOatuCSfbFllgPUbWIdm(IControllerTemplate parent, int id, string name, KkIHJcsvjeRuOXUHrrwAjNKjPNv axis, KkIHJcsvjeRuOXUHrrwAjNKjPNv zeroDetentButton)
				: this(parent, id, name, new IfBmCtvAuPEdSddWDhyHuNwFNIS[2] { axis, zeroDetentButton })
			{
			}
		}

		internal sealed class pvrBVNBJzspyptJVKfAGvXQPReW : oxuIqFysqrcoQsSFTYAkDKudUUr, IControllerTemplateElement, IControllerTemplateHat
		{
			private const int kjCWceKnekkwuBDJxDEJEsIdfbcr = 0;

			private const int UhwYPNSGdSAuHJKBvvHDKaufrKj = 1;

			private const int nXMBRysXIBdTiHWgPoGNtpIBImL = 2;

			private const int psyggabHIWgAYaqNcCIeskTEZHoH = 3;

			private const int PKYrpQSLHOqPrPIDXtWXazbcFkc = 4;

			private const int vMajGkTazcFSSKqMNHeioqwQfbg = 5;

			private const int hDmgvhLRGOdGdBZVVdgnaAqmPHOQ = 6;

			private const int SJByDSBgDzznDfyzRqSOdejwXGm = 7;

			private const int aoJDxODtyJKzFfiZMkUQEkuMAcB = 8;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[0]).floatValue;
					result.x += ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[2]).floatValue;
					result.y -= ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[4]).floatValue;
					result.x -= ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[6]).floatValue;
					float floatValue = ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[1]).floatValue;
					float floatValue2 = ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[3]).floatValue;
					float floatValue3 = ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[5]).floatValue;
					float floatValue4 = ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[7]).floatValue;
					result.x += floatValue + floatValue2 - floatValue3 - floatValue4;
					result.y += floatValue + floatValue4 - floatValue2 - floatValue3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[0]).floatValuePrev;
					result.x += ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[2]).floatValuePrev;
					result.y -= ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[4]).floatValuePrev;
					result.x -= ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[6]).floatValuePrev;
					float floatValuePrev = ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[1]).floatValuePrev;
					float floatValuePrev2 = ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[3]).floatValuePrev;
					float floatValuePrev3 = ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[5]).floatValuePrev;
					float floatValuePrev4 = ((KkIHJcsvjeRuOXUHrrwAjNKjPNv)KFQlRixtegtOhokPEQnlitLaJDS[7]).floatValuePrev;
					result.x += floatValuePrev + floatValuePrev2 - floatValuePrev3 - floatValuePrev4;
					result.y += floatValuePrev + floatValuePrev4 - floatValuePrev2 - floatValuePrev3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[0];
				}
			}

			public IControllerTemplateButton upRight
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[1];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[2];
				}
			}

			public IControllerTemplateButton downRight
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[3];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[4];
				}
			}

			public IControllerTemplateButton downLeft
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[5];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[6];
				}
			}

			public IControllerTemplateButton upLeft
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateButton)KFQlRixtegtOhokPEQnlitLaJDS[7];
				}
			}

			private pvrBVNBJzspyptJVKfAGvXQPReW(IControllerTemplate parent, int id, string name, IfBmCtvAuPEdSddWDhyHuNwFNIS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Hat, elements)
			{
				if (elements.Length != 8)
				{
					throw new ArgumentException("elements.Length must be " + 8);
				}
			}

			internal pvrBVNBJzspyptJVKfAGvXQPReW(IControllerTemplate parent, int id, string name, KkIHJcsvjeRuOXUHrrwAjNKjPNv up, KkIHJcsvjeRuOXUHrrwAjNKjPNv upRight, KkIHJcsvjeRuOXUHrrwAjNKjPNv right, KkIHJcsvjeRuOXUHrrwAjNKjPNv downRight, KkIHJcsvjeRuOXUHrrwAjNKjPNv down, KkIHJcsvjeRuOXUHrrwAjNKjPNv downLeft, KkIHJcsvjeRuOXUHrrwAjNKjPNv left, KkIHJcsvjeRuOXUHrrwAjNKjPNv upLeft)
				: this(parent, id, name, new IfBmCtvAuPEdSddWDhyHuNwFNIS[8] { up, upRight, right, downRight, down, downLeft, left, upLeft })
			{
			}
		}

		internal sealed class dXmbIyIXWvhluGDRvzjSRDTJcsxg : GgXfCnhgMOzljOtxjTKmxxwQeLV, IControllerTemplateElement, IControllerTemplateYoke
		{
			private new const int aoJDxODtyJKzFfiZMkUQEkuMAcB = 2;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[0];
				}
			}

			public IControllerTemplateAxis pushPull
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return (IControllerTemplateAxis)KFQlRixtegtOhokPEQnlitLaJDS[1];
				}
			}

			private dXmbIyIXWvhluGDRvzjSRDTJcsxg(IControllerTemplate parent, int id, string name, IfBmCtvAuPEdSddWDhyHuNwFNIS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Yoke, elements)
			{
			}

			internal dXmbIyIXWvhluGDRvzjSRDTJcsxg(IControllerTemplate parent, int id, string name, KkIHJcsvjeRuOXUHrrwAjNKjPNv rollAxis, KkIHJcsvjeRuOXUHrrwAjNKjPNv pitchAxis)
				: base(parent, id, name, ControllerTemplateElementType.Yoke, new IfBmCtvAuPEdSddWDhyHuNwFNIS[2] { rollAxis, pitchAxis })
			{
			}
		}

		internal sealed class NzdqZnbwPYEUyEBwnmmHJpTjTec : irxlKOcAmGHwAasqKjougrPbxvky, IControllerTemplateElement, IControllerTemplateStick6D
		{
			private new const int aoJDxODtyJKzFfiZMkUQEkuMAcB = 6;

			private NzdqZnbwPYEUyEBwnmmHJpTjTec(IControllerTemplate parent, int id, string name, IfBmCtvAuPEdSddWDhyHuNwFNIS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Stick6D, elements)
			{
			}

			internal NzdqZnbwPYEUyEBwnmmHJpTjTec(IControllerTemplate parent, int id, string name, KkIHJcsvjeRuOXUHrrwAjNKjPNv positionX, KkIHJcsvjeRuOXUHrrwAjNKjPNv positionY, KkIHJcsvjeRuOXUHrrwAjNKjPNv positionZ, KkIHJcsvjeRuOXUHrrwAjNKjPNv rotationX, KkIHJcsvjeRuOXUHrrwAjNKjPNv rotationY, KkIHJcsvjeRuOXUHrrwAjNKjPNv rotationZ)
				: base(parent, id, name, ControllerTemplateElementType.Stick6D, new IfBmCtvAuPEdSddWDhyHuNwFNIS[6] { positionX, positionY, positionZ, rotationX, rotationY, rotationZ })
			{
			}
		}

		internal class lXTMcZYLLZNvKTtfvWTrtvcXStJ
		{
			public readonly Controller.Element pEsVixgorzFkhlKMiSFTVBzHAOS;

			public readonly IControllerElementTarget jWJUzdYygPEtnMmJufqABlNORLBB;

			public bool boolValue
			{
				get
				{
					if (pEsVixgorzFkhlKMiSFTVBzHAOS == null)
					{
						return false;
					}
					switch (pEsVixgorzFkhlKMiSFTVBzHAOS.type)
					{
					case ControllerElementType.Button:
						return (pEsVixgorzFkhlKMiSFTVBzHAOS as Controller.Button).value;
					case ControllerElementType.Axis:
					{
						float value = (pEsVixgorzFkhlKMiSFTVBzHAOS as Controller.Axis).value;
						switch (jWJUzdYygPEtnMmJufqABlNORLBB.axisRange)
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

			public bool boolValuePrev
			{
				get
				{
					if (pEsVixgorzFkhlKMiSFTVBzHAOS == null)
					{
						return false;
					}
					switch (pEsVixgorzFkhlKMiSFTVBzHAOS.type)
					{
					case ControllerElementType.Button:
						return (pEsVixgorzFkhlKMiSFTVBzHAOS as Controller.Button).valuePrev;
					case ControllerElementType.Axis:
					{
						float valuePrev = (pEsVixgorzFkhlKMiSFTVBzHAOS as Controller.Axis).valuePrev;
						switch (jWJUzdYygPEtnMmJufqABlNORLBB.axisRange)
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

			public bool justPressed
			{
				get
				{
					if (pEsVixgorzFkhlKMiSFTVBzHAOS == null)
					{
						return false;
					}
					switch (pEsVixgorzFkhlKMiSFTVBzHAOS.type)
					{
					case ControllerElementType.Button:
						return (pEsVixgorzFkhlKMiSFTVBzHAOS as Controller.Button).justPressed;
					case ControllerElementType.Axis:
						if (MathTools.Abs(floatValue) > 0.01f && MathTools.Abs(floatValuePrev) <= 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (pEsVixgorzFkhlKMiSFTVBzHAOS == null)
					{
						return false;
					}
					switch (pEsVixgorzFkhlKMiSFTVBzHAOS.type)
					{
					case ControllerElementType.Button:
						return (pEsVixgorzFkhlKMiSFTVBzHAOS as Controller.Button).justReleased;
					case ControllerElementType.Axis:
						if (MathTools.Abs(floatValue) <= 0.01f && MathTools.Abs(floatValuePrev) > 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public float floatValue
			{
				get
				{
					if (pEsVixgorzFkhlKMiSFTVBzHAOS == null)
					{
						return 0f;
					}
					switch (pEsVixgorzFkhlKMiSFTVBzHAOS.type)
					{
					case ControllerElementType.Button:
						if (!(pEsVixgorzFkhlKMiSFTVBzHAOS as Controller.Button).value)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float value = (pEsVixgorzFkhlKMiSFTVBzHAOS as Controller.Axis).value;
						switch (jWJUzdYygPEtnMmJufqABlNORLBB.axisRange)
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

			public float floatValuePrev
			{
				get
				{
					if (pEsVixgorzFkhlKMiSFTVBzHAOS == null)
					{
						return 0f;
					}
					switch (pEsVixgorzFkhlKMiSFTVBzHAOS.type)
					{
					case ControllerElementType.Button:
						if (!(pEsVixgorzFkhlKMiSFTVBzHAOS as Controller.Button).valuePrev)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float valuePrev = (pEsVixgorzFkhlKMiSFTVBzHAOS as Controller.Axis).valuePrev;
						switch (jWJUzdYygPEtnMmJufqABlNORLBB.axisRange)
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

			public lXTMcZYLLZNvKTtfvWTrtvcXStJ(IControllerElementTarget target, Controller.Element element)
			{
				pEsVixgorzFkhlKMiSFTVBzHAOS = element;
				jWJUzdYygPEtnMmJufqABlNORLBB = target;
			}

			public static lXTMcZYLLZNvKTtfvWTrtvcXStJ AapzLJOSMOptjeIdgEhpjxotmUy()
			{
				return new lXTMcZYLLZNvKTtfvWTrtvcXStJ(BIzzMnQbYdgezaQAnFAxzmYBsLQP.AapzLJOSMOptjeIdgEhpjxotmUy(), null);
			}
		}

		internal class HuDhZDlXBAKGuPzYzBrjxzAdvGJ
		{
			public readonly Controller pxFOUEuAQwwDMNyKdQhVGxLNflI;

			public readonly IHardwareControllerTemplateMap_Internal iQpNkkWlnJVnMVXIvpQKopCRTys;

			public HuDhZDlXBAKGuPzYzBrjxzAdvGJ(Controller controller, IHardwareControllerTemplateMap_Internal templateMap)
			{
				if (controller == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (templateMap == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				pxFOUEuAQwwDMNyKdQhVGxLNflI = controller;
				iQpNkkWlnJVnMVXIvpQKopCRTys = templateMap;
			}
		}

		private readonly string YckvCvRVVkCnFoBTmVxvWZVKnMr;

		private readonly Guid znbAzpuevakGoOSfdHYzwiEMKNF;

		private readonly Controller BheccrWcwXwuvsNLWjWrFwcrgAqE;

		private readonly ADictionary<int, IControllerTemplateElement> qnaGKeZWWNHDLmlApaswMVWtbbTI;

		private readonly ADictionary<string, IControllerTemplateElement> WKZVzTkctwCyfizcWOCkVkFkOtu;

		private IControllerTemplateElement[] KFQlRixtegtOhokPEQnlitLaJDS;

		private ReadOnlyCollection<IControllerTemplateElement> izLDyzKhaPvNHKsTLMyAkmTgGsf;

		private readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return BheccrWcwXwuvsNLWjWrFwcrgAqE;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return YckvCvRVVkCnFoBTmVxvWZVKnMr;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Guid.Empty;
				}
				return znbAzpuevakGoOSfdHYzwiEMKNF;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return izLDyzKhaPvNHKsTLMyAkmTgGsf;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				return KFQlRixtegtOhokPEQnlitLaJDS.Length;
			}
		}

		protected ControllerTemplate(object payload)
			: this((HuDhZDlXBAKGuPzYzBrjxzAdvGJ)payload)
		{
		}

		private ControllerTemplate(HuDhZDlXBAKGuPzYzBrjxzAdvGJ initializer)
		{
			if (initializer == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (initializer.pxFOUEuAQwwDMNyKdQhVGxLNflI == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (initializer.iQpNkkWlnJVnMVXIvpQKopCRTys == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput.id;
			BheccrWcwXwuvsNLWjWrFwcrgAqE = initializer.pxFOUEuAQwwDMNyKdQhVGxLNflI;
			IHardwareControllerTemplateMap_Internal iQpNkkWlnJVnMVXIvpQKopCRTys = initializer.iQpNkkWlnJVnMVXIvpQKopCRTys;
			YckvCvRVVkCnFoBTmVxvWZVKnMr = iQpNkkWlnJVnMVXIvpQKopCRTys.name;
			znbAzpuevakGoOSfdHYzwiEMKNF = iQpNkkWlnJVnMVXIvpQKopCRTys.typeGuid;
			int elementIdentifierCount = iQpNkkWlnJVnMVXIvpQKopCRTys.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = iQpNkkWlnJVnMVXIvpQKopCRTys.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						uRvJKnYnMDIXSDaSbLxWqKFPfOYl uRvJKnYnMDIXSDaSbLxWqKFPfOYl3 = iQpNkkWlnJVnMVXIvpQKopCRTys.GetAxisTarget(BheccrWcwXwuvsNLWjWrFwcrgAqE, templateElementIdentifier.id) ?? uRvJKnYnMDIXSDaSbLxWqKFPfOYl.AapzLJOSMOptjeIdgEhpjxotmUy(ControllerTemplateElementType.Axis);
						pVGFRtHMiCgSutDlKtBaEynyryH item2 = new pVGFRtHMiCgSutDlKtBaEynyryH(this, templateElementIdentifier.id, templateElementIdentifier.name, (!string.IsNullOrEmpty(templateElementIdentifier.positiveName)) ? templateElementIdentifier.positiveName : (templateElementIdentifier.name + " +"), (!string.IsNullOrEmpty(templateElementIdentifier.negativeName)) ? templateElementIdentifier.negativeName : (templateElementIdentifier.name + " -"), uRvJKnYnMDIXSDaSbLxWqKFPfOYl3, xXAvXvVnlQBCMgewphdrQNUHGLVj(BheccrWcwXwuvsNLWjWrFwcrgAqE, (IControllerTemplateAxisSource)uRvJKnYnMDIXSDaSbLxWqKFPfOYl3));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						uRvJKnYnMDIXSDaSbLxWqKFPfOYl uRvJKnYnMDIXSDaSbLxWqKFPfOYl2 = iQpNkkWlnJVnMVXIvpQKopCRTys.GetButtonTarget(BheccrWcwXwuvsNLWjWrFwcrgAqE, templateElementIdentifier.id) ?? uRvJKnYnMDIXSDaSbLxWqKFPfOYl.AapzLJOSMOptjeIdgEhpjxotmUy(ControllerTemplateElementType.Button);
						CdwbAEQwjOrZBeiNLenzdTmbqCn item = new CdwbAEQwjOrZBeiNLenzdTmbqCn(this, templateElementIdentifier.id, templateElementIdentifier.name, templateElementIdentifier.name, templateElementIdentifier.name + " -", uRvJKnYnMDIXSDaSbLxWqKFPfOYl2, xXAvXvVnlQBCMgewphdrQNUHGLVj(BheccrWcwXwuvsNLWjWrFwcrgAqE, (IControllerTemplateButtonSource)uRvJKnYnMDIXSDaSbLxWqKFPfOYl2));
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
				IControllerTemplateElementIdentifier templateElementIdentifier2 = iQpNkkWlnJVnMVXIvpQKopCRTys.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = iQpNkkWlnJVnMVXIvpQKopCRTys.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				IfBmCtvAuPEdSddWDhyHuNwFNIS ifBmCtvAuPEdSddWDhyHuNwFNIS;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					ifBmCtvAuPEdSddWDhyHuNwFNIS = new jtOoIiMLsPqZeuAeFampHNFhKXQt(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping5 != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping5.eid_axisX) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping5 != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping5.eid_axisY) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping5 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping5.eid_button) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					ifBmCtvAuPEdSddWDhyHuNwFNIS = new BUtjGrveHGGMRiTDzZBcYtJUEnK(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping3 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping3.eid_up) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping3 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping3.eid_right) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping3 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping3.eid_down) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping3 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping3.eid_left) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping3 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping3.eid_press) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					ifBmCtvAuPEdSddWDhyHuNwFNIS = new yQpbKWcDsgnCAPiXuTqiSktwIGx(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping2 != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping2.eid_axisX) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping2 != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping2.eid_axisY) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping2 != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping2.eid_axisZ) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					ifBmCtvAuPEdSddWDhyHuNwFNIS = new INqLVxqtOatuCSfbFllgPUbWIdm(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping6 != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping6.eid_axis) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping6 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping6.eid_minDetent) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					ifBmCtvAuPEdSddWDhyHuNwFNIS = new pvrBVNBJzspyptJVKfAGvXQPReW(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping7 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping7.eid_up) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping7 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping7.eid_upRight) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping7 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping7.eid_right) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping7 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping7.eid_downRight) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping7 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping7.eid_down) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping7 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping7.eid_downLeft) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping7 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping7.eid_left) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping7 != null) ? DydAVEtKkgGfMIgCqQnyUpcWAgVj(this, aDictionary, mapping7.eid_upLeft) : CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					ifBmCtvAuPEdSddWDhyHuNwFNIS = new dXmbIyIXWvhluGDRvzjSRDTJcsxg(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping4 != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping4.eid_axisX) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping4 != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping4.eid_axisZ) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					ifBmCtvAuPEdSddWDhyHuNwFNIS = new NzdqZnbwPYEUyEBwnmmHJpTjTec(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping.eid_positionX) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping.eid_positionY) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping.eid_positionZ) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping.eid_rotationX) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping.eid_rotationY) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this), (mapping != null) ? shkVWVifnrckjfLqMMOksHvTAKy(this, aDictionary, mapping.eid_rotationZ) : pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (ifBmCtvAuPEdSddWDhyHuNwFNIS != null)
				{
					list4.Add(ifBmCtvAuPEdSddWDhyHuNwFNIS);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			KFQlRixtegtOhokPEQnlitLaJDS = list.ToArray();
			qnaGKeZWWNHDLmlApaswMVWtbbTI = aDictionary;
			WKZVzTkctwCyfizcWOCkVkFkOtu = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < KFQlRixtegtOhokPEQnlitLaJDS.Length; num++)
			{
				if (!(iQpNkkWlnJVnMVXIvpQKopCRTys.GetTemplateElementIdentifierById(KFQlRixtegtOhokPEQnlitLaJDS[num].id) is IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor))
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
							WKZVzTkctwCyfizcWOCkVkFkOtu.Add(text, KFQlRixtegtOhokPEQnlitLaJDS[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + YckvCvRVVkCnFoBTmVxvWZVKnMr + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			izLDyzKhaPvNHKsTLMyAkmTgGsf = new ReadOnlyCollection<IControllerTemplateElement>(KFQlRixtegtOhokPEQnlitLaJDS);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			if (!qnaGKeZWWNHDLmlApaswMVWtbbTI.TryGetValue(id, out var value))
			{
				Logger.LogWarning("There is no element with the id \"" + id + "\" in the " + GetType().ToString() + ".");
			}
			return value;
		}

		protected T GetElement<T>(int id) where T : class, IControllerTemplateElement
		{
			return GetElement(id) as T;
		}

		private IControllerTemplateElement DLVFZeqegsFVyJsQAcdHVweakvU(int P_0)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			return GetElement(P_0);
		}

		IControllerTemplateElement IControllerTemplate.GetElement(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DLVFZeqegsFVyJsQAcdHVweakvU
			return this.DLVFZeqegsFVyJsQAcdHVweakvU(P_0);
		}

		private T DLVFZeqegsFVyJsQAcdHVweakvU<T>(int P_0) where T : class, IControllerTemplateElement
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			return GetElement<T>(P_0);
		}

		T IControllerTemplate.GetElement<T>(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DLVFZeqegsFVyJsQAcdHVweakvU
			return this.DLVFZeqegsFVyJsQAcdHVweakvU<T>(P_0);
		}

		private int UwhjTacgfUerXFbEnRMOJjoEBeMj(ControllerElementTarget P_0, IList<ControllerTemplateElementTarget> P_1)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0;
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			return KenBlNhdSLhpxqdduCjQVQrWAen(P_0, ref P_1);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget P_0, IList<ControllerTemplateElementTarget> P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UwhjTacgfUerXFbEnRMOJjoEBeMj
			return this.UwhjTacgfUerXFbEnRMOJjoEBeMj(P_0, P_1);
		}

		private int KenBlNhdSLhpxqdduCjQVQrWAen(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
		{
			if (P_1 != null)
			{
				P_1.Clear();
			}
			int num = 0;
			for (int i = 0; i < KFQlRixtegtOhokPEQnlitLaJDS.Length; i++)
			{
				if (InputTools.IsMappableType(KFQlRixtegtOhokPEQnlitLaJDS[i].type))
				{
					num += (KFQlRixtegtOhokPEQnlitLaJDS[i] as IControllerTemplateElement_Internal).GetElementTargets(P_0, ref P_1);
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

		private static IList<lXTMcZYLLZNvKTtfvWTrtvcXStJ> xXAvXvVnlQBCMgewphdrQNUHGLVj(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			if (P_1.splitAxis)
			{
				IList<lXTMcZYLLZNvKTtfvWTrtvcXStJ> list = null;
				bool flag = false;
				if (P_1.positiveTarget != null)
				{
					Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					if (elementById != null)
					{
						ListTools.AddAndCreateList(ref list, new lXTMcZYLLZNvKTtfvWTrtvcXStJ(P_1.positiveTarget, elementById));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, lXTMcZYLLZNvKTtfvWTrtvcXStJ.AapzLJOSMOptjeIdgEhpjxotmUy());
				}
				flag = false;
				if (P_1.negativeTarget != null)
				{
					Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
					if (elementById2 != null)
					{
						ListTools.AddAndCreateList(ref list, new lXTMcZYLLZNvKTtfvWTrtvcXStJ(P_1.negativeTarget, elementById2));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, lXTMcZYLLZNvKTtfvWTrtvcXStJ.AapzLJOSMOptjeIdgEhpjxotmUy());
				}
				return list;
			}
			return xXAvXvVnlQBCMgewphdrQNUHGLVj(P_0, P_1.fullTarget);
		}

		private static IList<lXTMcZYLLZNvKTtfvWTrtvcXStJ> xXAvXvVnlQBCMgewphdrQNUHGLVj(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return xXAvXvVnlQBCMgewphdrQNUHGLVj(P_0, P_1.target);
		}

		private static IList<lXTMcZYLLZNvKTtfvWTrtvcXStJ> xXAvXvVnlQBCMgewphdrQNUHGLVj(Controller P_0, IControllerElementTarget P_1)
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
			List<lXTMcZYLLZNvKTtfvWTrtvcXStJ> list = new List<lXTMcZYLLZNvKTtfvWTrtvcXStJ>();
			list.Add(new lXTMcZYLLZNvKTtfvWTrtvcXStJ(P_1, elementById));
			return list;
		}

		private static IControllerTemplateElement VjDsToGPZzGexAMmMdPilgfgVeBC(List<IControllerTemplateElement> P_0, int P_1)
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

		private static KkIHJcsvjeRuOXUHrrwAjNKjPNv shkVWVifnrckjfLqMMOksHvTAKy(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is KkIHJcsvjeRuOXUHrrwAjNKjPNv result))
			{
				return pVGFRtHMiCgSutDlKtBaEynyryH.AapzLJOSMOptjeIdgEhpjxotmUy(P_0);
			}
			return result;
		}

		private static KkIHJcsvjeRuOXUHrrwAjNKjPNv DydAVEtKkgGfMIgCqQnyUpcWAgVj(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is KkIHJcsvjeRuOXUHrrwAjNKjPNv result))
			{
				return CdwbAEQwjOrZBeiNLenzdTmbqCn.AapzLJOSMOptjeIdgEhpjxotmUy(P_0);
			}
			return result;
		}
	}
}
