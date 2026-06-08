using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionButtonMap : ControllerTemplateActionElementMap
	{
		private Pole DqGgYWkBubghVSQVgMNYCIGRYGK;

		public Pole axisContribution => DqGgYWkBubghVSQVgMNYCIGRYGK;

		internal ControllerTemplateActionButtonMap(SerializedObject serializedObject)
			: base(ControllerTemplateElementType.Button)
		{
			if (serializedObject == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			FMjbXwujmHnZzQbodRBJzieOPHZ(serializedObject);
		}

		internal ControllerTemplateActionButtonMap(int templateElementIdentifierId, ActionElementMap actionElementMap)
			: base(ControllerTemplateElementType.Button, templateElementIdentifierId, actionElementMap)
		{
			DqGgYWkBubghVSQVgMNYCIGRYGK = actionElementMap.axisContribution;
		}

		internal ControllerTemplateActionButtonMap(int elementIdentifierId, int actionId, Pole axisContribution, bool enabled)
			: base(ControllerTemplateElementType.Button, elementIdentifierId, actionId, enabled)
		{
			DqGgYWkBubghVSQVgMNYCIGRYGK = axisContribution;
		}

		internal override void mtMtVVrohwWTxFPivXmGbDyGevo(SerializedObject P_0)
		{
			base.mtMtVVrohwWTxFPivXmGbDyGevo(P_0);
			P_0.Add("axisContribution", DqGgYWkBubghVSQVgMNYCIGRYGK);
		}

		internal override void FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject P_0)
		{
			base.FMjbXwujmHnZzQbodRBJzieOPHZ(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref DqGgYWkBubghVSQVgMNYCIGRYGK);
		}

		internal override void tAgADqjTsMUxSqYXeDyJIdETYRAp()
		{
			DqGgYWkBubghVSQVgMNYCIGRYGK = Pole.Positive;
		}

		internal override int TPjqYspfJVdLLflGpdCjWPeGAtN(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			IControllerTemplateButtonSource controllerTemplateButtonSource = P_0 as IControllerTemplateButtonSource;
			int num2 = default(int);
			while (true)
			{
				int num = -1824362313;
				while (true)
				{
					ActionElementMap actionElementMap;
					switch (num ^ -1824362314)
					{
					case 0:
						break;
					case 1:
						if (controllerTemplateButtonSource == null)
						{
							return 0;
						}
						num2 = 0;
						actionElementMap = OTbGPGXXAEhPqxIRSgALISFJjWC(controllerTemplateButtonSource.target, DqGgYWkBubghVSQVgMNYCIGRYGK);
						if (actionElementMap != null)
						{
							goto IL_0042;
						}
						goto default;
					default:
						return num2;
					}
					break;
					IL_0042:
					P_1.Add(actionElementMap);
					num2++;
					num = -1824362316;
				}
			}
		}

		private ActionElementMap OTbGPGXXAEhPqxIRSgALISFJjWC(IControllerElementTarget P_0, Pole P_1)
		{
			ControllerElementType controllerElementType = default(ControllerElementType);
			AxisRange axisRange = default(AxisRange);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num;
			if (P_0 != null)
			{
				if (P_0.element == null)
				{
					goto IL_000b;
				}
				controllerElementType = P_0.elementType;
				axisRange = P_0.axisRange;
				actionElementMap = new ActionElementMap();
				actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
				actionElementMap._elementType = controllerElementType;
				actionElementMap._axisRange = axisRange;
				int num2;
				if (controllerElementType != ControllerElementType.Axis)
				{
					num = -893107179;
					num2 = num;
				}
				else
				{
					num = -893107182;
					num2 = num;
				}
				goto IL_0010;
			}
			goto IL_0038;
			IL_0010:
			while (true)
			{
				switch (num ^ -893107183)
				{
				case 2:
					break;
				case 1:
					goto IL_0038;
				case 0:
					goto IL_007c;
				case 3:
					goto IL_008a;
				case 4:
					goto IL_00a1;
				default:
					return actionElementMap;
				}
				break;
				IL_00a1:
				int num3;
				switch (controllerElementType)
				{
				case ControllerElementType.Axis:
					break;
				case ControllerElementType.Button:
					num = -893107183;
					num3 = num;
					continue;
				default:
					num = -893107180;
					num3 = num;
					continue;
				}
				goto IL_007c;
				IL_008a:
				int num4;
				if (axisRange == AxisRange.Full)
				{
					num = -893107180;
					num4 = num;
				}
				else
				{
					num = -893107179;
					num4 = num;
				}
				continue;
				IL_007c:
				actionElementMap._axisContribution = P_1;
				num = -893107180;
			}
			goto IL_000b;
			IL_000b:
			num = -893107184;
			goto IL_0010;
			IL_0038:
			return null;
		}
	}
}
