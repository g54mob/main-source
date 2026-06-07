using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange jlEnqYlFCTxpQiXKkRUPTZLnjeL;

		private Pole wLEjKNOLFnsGKpXyzkxPOqxGPgl;

		private bool GxVGOhAsFVqIMspcaPfClxXqvUAu;

		public AxisRange axisRange
		{
			get
			{
				return jlEnqYlFCTxpQiXKkRUPTZLnjeL;
			}
		}

		public Pole axisContribution
		{
			get
			{
				return wLEjKNOLFnsGKpXyzkxPOqxGPgl;
			}
		}

		public bool invert
		{
			get
			{
				return GxVGOhAsFVqIMspcaPfClxXqvUAu;
			}
		}

		internal ControllerTemplateActionAxisMap(SerializedObject serializedObject)
			: base(ControllerTemplateElementType.Axis)
		{
			while (true)
			{
				int num = 2109872957;
				while (true)
				{
					switch (num ^ 0x7DC21B3C)
					{
					case 3:
						break;
					case 1:
					{
						int num2;
						if (serializedObject != null)
						{
							num = 2109872956;
							num2 = num;
						}
						else
						{
							num = 2109872958;
							num2 = num;
						}
						continue;
					}
					case 2:
						throw new ArgumentNullException("serializedObject");
					default:
						Import(serializedObject);
						return;
					}
					break;
				}
			}
		}

		internal ControllerTemplateActionAxisMap(int templateElementIdentifierId, AxisRange axisRange, ActionElementMap actionElementMap)
			: base(ControllerTemplateElementType.Axis, templateElementIdentifierId, actionElementMap)
		{
			jlEnqYlFCTxpQiXKkRUPTZLnjeL = axisRange;
			wLEjKNOLFnsGKpXyzkxPOqxGPgl = actionElementMap.axisContribution;
			GxVGOhAsFVqIMspcaPfClxXqvUAu = actionElementMap._invert;
		}

		internal ControllerTemplateActionAxisMap(int elementIdentifierId, int actionId, AxisRange axisRange, Pole axisContribution, bool invert, bool enabled)
			: base(ControllerTemplateElementType.Axis, elementIdentifierId, actionId, enabled)
		{
			jlEnqYlFCTxpQiXKkRUPTZLnjeL = axisRange;
			wLEjKNOLFnsGKpXyzkxPOqxGPgl = axisContribution;
			GxVGOhAsFVqIMspcaPfClxXqvUAu = invert;
		}

		internal override void Export(SerializedObject P_0)
		{
			base.Export(P_0);
			P_0.Add("axisContribution", wLEjKNOLFnsGKpXyzkxPOqxGPgl);
			P_0.Add("axisRange", jlEnqYlFCTxpQiXKkRUPTZLnjeL);
			while (true)
			{
				int num = 126599944;
				while (true)
				{
					switch (num ^ 0x78BC309)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0049;
					case 2:
						return;
					}
					break;
					IL_0049:
					P_0.Add("invert", GxVGOhAsFVqIMspcaPfClxXqvUAu);
					num = 126599947;
				}
			}
		}

		internal override void Import(SerializedObject P_0)
		{
			base.Import(P_0);
			while (true)
			{
				int num = -1948243436;
				while (true)
				{
					switch (num ^ -1948243434)
					{
					case 0:
						break;
					case 2:
						goto IL_0025;
					default:
						P_0.TryGetDeserializedValueByRef("axisRange", ref jlEnqYlFCTxpQiXKkRUPTZLnjeL);
						P_0.TryGetDeserializedValueByRef("invert", ref GxVGOhAsFVqIMspcaPfClxXqvUAu);
						return;
					}
					break;
					IL_0025:
					P_0.TryGetDeserializedValueByRef("axisContribution", ref wLEjKNOLFnsGKpXyzkxPOqxGPgl);
					num = -1948243433;
				}
			}
		}

		internal override void Clear()
		{
			jlEnqYlFCTxpQiXKkRUPTZLnjeL = AxisRange.Full;
			wLEjKNOLFnsGKpXyzkxPOqxGPgl = Pole.Positive;
			GxVGOhAsFVqIMspcaPfClxXqvUAu = false;
		}

		internal override int CreateAEMsFromSource(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			IControllerTemplateAxisSource controllerTemplateAxisSource = P_0 as IControllerTemplateAxisSource;
			if (controllerTemplateAxisSource == null)
			{
				return 0;
			}
			int num = 0;
			if (jlEnqYlFCTxpQiXKkRUPTZLnjeL == AxisRange.Full)
			{
				goto IL_0016;
			}
			goto IL_0063;
			IL_0151:
			ActionElementMap actionElementMap = gXpiPZfQRNYsFTQjstOPxEYgUVr(controllerTemplateAxisSource.fullTarget, (jlEnqYlFCTxpQiXKkRUPTZLnjeL == AxisRange.Negative) ? Pole.Negative : Pole.Positive, wLEjKNOLFnsGKpXyzkxPOqxGPgl);
			int num2;
			if (actionElementMap != null)
			{
				P_1.Add(actionElementMap);
				num2 = -2045594608;
				goto IL_001b;
			}
			goto IL_01e3;
			IL_0016:
			num2 = -2045594599;
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num2 ^ -2045594598)
				{
				case 11:
					break;
				case 8:
					goto IL_0063;
				case 12:
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
						num2 = -2045594595;
						continue;
					}
					goto IL_01e3;
				case 9:
					goto IL_00bd;
				case 10:
					num++;
					num2 = -2045594595;
					continue;
				case 4:
					goto IL_00e9;
				case 3:
					if (controllerTemplateAxisSource.splitAxis)
					{
						actionElementMap = HnRckEJZRSMIWJcsUYAqBagHlsoE(controllerTemplateAxisSource.positiveTarget, (!GxVGOhAsFVqIMspcaPfClxXqvUAu) ? AxisRange.Positive : AxisRange.Negative);
						num2 = -2045594593;
						continue;
					}
					goto IL_00e9;
				case 5:
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
						num2 = -2045594596;
						continue;
					}
					goto case 6;
				case 0:
					goto IL_0151;
				case 6:
					actionElementMap = HnRckEJZRSMIWJcsUYAqBagHlsoE(controllerTemplateAxisSource.negativeTarget, GxVGOhAsFVqIMspcaPfClxXqvUAu ? AxisRange.Positive : AxisRange.Negative);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
						num2 = -2045594595;
						continue;
					}
					goto IL_01e3;
				case 2:
					num++;
					num2 = -2045594601;
					continue;
				case 13:
					num2 = -2045594595;
					continue;
				case 1:
					P_1.Add(actionElementMap);
					num++;
					num2 = -2045594595;
					continue;
				default:
					goto IL_01e3;
				}
				break;
				IL_00e9:
				actionElementMap = HnRckEJZRSMIWJcsUYAqBagHlsoE(controllerTemplateAxisSource.fullTarget, AxisRange.Full);
				int num3;
				if (actionElementMap == null)
				{
					num2 = -2045594595;
					num3 = num2;
				}
				else
				{
					num2 = -2045594597;
					num3 = num2;
				}
			}
			goto IL_0016;
			IL_0063:
			if (!controllerTemplateAxisSource.splitAxis)
			{
				goto IL_0151;
			}
			if (jlEnqYlFCTxpQiXKkRUPTZLnjeL != AxisRange.Positive)
			{
				goto IL_00bd;
			}
			actionElementMap = gXpiPZfQRNYsFTQjstOPxEYgUVr(controllerTemplateAxisSource.positiveTarget, Pole.Positive, wLEjKNOLFnsGKpXyzkxPOqxGPgl);
			if (actionElementMap != null)
			{
				P_1.Add(actionElementMap);
				num2 = -2045594600;
				goto IL_001b;
			}
			goto IL_01e3;
			IL_01e3:
			return num;
			IL_00bd:
			actionElementMap = gXpiPZfQRNYsFTQjstOPxEYgUVr(controllerTemplateAxisSource.negativeTarget, Pole.Negative, wLEjKNOLFnsGKpXyzkxPOqxGPgl);
			num2 = -2045594602;
			goto IL_001b;
		}

		private ActionElementMap HnRckEJZRSMIWJcsUYAqBagHlsoE(IControllerElementTarget P_0, AxisRange P_1)
		{
			ControllerElementType controllerElementType = default(ControllerElementType);
			int num;
			if (P_0 != null)
			{
				if (P_0.element == null)
				{
					goto IL_0011;
				}
				controllerElementType = P_0.elementType;
				num = 816365428;
				goto IL_0016;
			}
			goto IL_00ed;
			IL_0016:
			ActionElementMap actionElementMap = default(ActionElementMap);
			AxisRange axisRange = default(AxisRange);
			while (true)
			{
				switch (num ^ 0x30A8BF7C)
				{
				case 0:
					break;
				case 2:
					actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
					num = 816365430;
					continue;
				case 9:
					actionElementMap._invert = GxVGOhAsFVqIMspcaPfClxXqvUAu;
					num = 816365439;
					continue;
				case 6:
					goto IL_0078;
				case 5:
					goto IL_008f;
				case 4:
					goto IL_00aa;
				case 10:
					actionElementMap._elementType = controllerElementType;
					actionElementMap._axisRange = axisRange;
					num = 816365434;
					continue;
				case 8:
					axisRange = P_0.axisRange;
					num = 816365437;
					continue;
				case 7:
					goto IL_00ed;
				case 1:
					actionElementMap = new ActionElementMap();
					num = 816365438;
					continue;
				default:
					return actionElementMap;
				}
				break;
				IL_0078:
				if (controllerElementType == ControllerElementType.Axis)
				{
					int num2;
					if (axisRange == AxisRange.Full)
					{
						num = 816365429;
						num2 = num;
					}
					else
					{
						num = 816365433;
						num2 = num;
					}
					continue;
				}
				goto IL_008f;
				IL_00aa:
				Pole pole = ((P_1 == AxisRange.Negative) ? Pole.Negative : Pole.Positive);
				actionElementMap._axisContribution = pole;
				num = 816365439;
				continue;
				IL_008f:
				int num3;
				switch (controllerElementType)
				{
				default:
					num = 816365439;
					num3 = num;
					continue;
				case ControllerElementType.Button:
					num = 816365432;
					num3 = num;
					continue;
				case ControllerElementType.Axis:
					break;
				}
				goto IL_00aa;
			}
			goto IL_0011;
			IL_00ed:
			return null;
			IL_0011:
			num = 816365435;
			goto IL_0016;
		}

		private ActionElementMap gXpiPZfQRNYsFTQjstOPxEYgUVr(IControllerElementTarget P_0, Pole P_1, Pole P_2)
		{
			ControllerElementType controllerElementType = default(ControllerElementType);
			AxisRange axisRange = default(AxisRange);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num;
			if (P_0 != null)
			{
				if (P_0.element == null)
				{
					goto IL_0011;
				}
				controllerElementType = P_0.elementType;
				axisRange = P_0.axisRange;
				actionElementMap = new ActionElementMap();
				actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
				num = 1731060070;
				goto IL_0016;
			}
			goto IL_00a3;
			IL_0016:
			while (true)
			{
				switch (num ^ 0x672DE165)
				{
				case 0:
					break;
				case 6:
					num = 1731060077;
					continue;
				case 3:
					actionElementMap._elementType = controllerElementType;
					actionElementMap._axisRange = axisRange;
					num = 1731060068;
					continue;
				case 2:
					goto IL_0066;
				case 7:
					goto IL_007e;
				case 1:
					goto IL_008c;
				case 5:
					goto IL_00a3;
				case 4:
					if (axisRange == AxisRange.Full)
					{
						actionElementMap._axisRange = ((P_1 == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative);
						actionElementMap._axisContribution = P_2;
						num = 1731060067;
						continue;
					}
					goto IL_0066;
				default:
					return actionElementMap;
				}
				break;
				IL_008c:
				int num2;
				if (controllerElementType != ControllerElementType.Axis)
				{
					num = 1731060071;
					num2 = num;
				}
				else
				{
					num = 1731060065;
					num2 = num;
				}
				continue;
				IL_0066:
				int num3;
				switch (controllerElementType)
				{
				case ControllerElementType.Button:
					num = 1731060066;
					num3 = num;
					continue;
				default:
					num = 1731060077;
					num3 = num;
					continue;
				case ControllerElementType.Axis:
					break;
				}
				goto IL_007e;
				IL_007e:
				actionElementMap._axisContribution = P_2;
				num = 1731060077;
			}
			goto IL_0011;
			IL_00a3:
			return null;
			IL_0011:
			num = 1731060064;
			goto IL_0016;
		}
	}
}
