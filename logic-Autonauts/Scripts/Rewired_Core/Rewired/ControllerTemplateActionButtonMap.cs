using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionButtonMap : ControllerTemplateActionElementMap
	{
		private Pole wLEjKNOLFnsGKpXyzkxPOqxGPgl;

		public Pole axisContribution
		{
			get
			{
				return wLEjKNOLFnsGKpXyzkxPOqxGPgl;
			}
		}

		internal ControllerTemplateActionButtonMap(SerializedObject serializedObject)
			: base(ControllerTemplateElementType.Button)
		{
			while (true)
			{
				switch (0x3B376C34 ^ 0x3B376C35)
				{
				case 2:
					continue;
				case 1:
					if (serializedObject == null)
					{
						throw new ArgumentNullException("serializedObject");
					}
					break;
				}
				break;
			}
			Import(serializedObject);
		}

		internal ControllerTemplateActionButtonMap(int templateElementIdentifierId, ActionElementMap actionElementMap)
			: base(ControllerTemplateElementType.Button, templateElementIdentifierId, actionElementMap)
		{
			while (true)
			{
				int num = 1836318220;
				while (true)
				{
					switch (num ^ 0x6D73FE0D)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0027;
					case 0:
						return;
					}
					break;
					IL_0027:
					wLEjKNOLFnsGKpXyzkxPOqxGPgl = actionElementMap.axisContribution;
					num = 1836318221;
				}
			}
		}

		internal ControllerTemplateActionButtonMap(int elementIdentifierId, int actionId, Pole axisContribution, bool enabled)
			: base(ControllerTemplateElementType.Button, elementIdentifierId, actionId, enabled)
		{
			wLEjKNOLFnsGKpXyzkxPOqxGPgl = axisContribution;
		}

		internal override void Export(SerializedObject P_0)
		{
			base.Export(P_0);
			P_0.Add("axisContribution", wLEjKNOLFnsGKpXyzkxPOqxGPgl);
		}

		internal override void Import(SerializedObject P_0)
		{
			base.Import(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref wLEjKNOLFnsGKpXyzkxPOqxGPgl);
		}

		internal override void Clear()
		{
			wLEjKNOLFnsGKpXyzkxPOqxGPgl = Pole.Positive;
		}

		internal override int CreateAEMsFromSource(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			IControllerTemplateButtonSource controllerTemplateButtonSource = P_0 as IControllerTemplateButtonSource;
			if (controllerTemplateButtonSource == null)
			{
				return 0;
			}
			int num = 0;
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				int num2 = -128163135;
				while (true)
				{
					switch (num2 ^ -128163131)
					{
					case 2:
						break;
					case 0:
						num++;
						num2 = -128163132;
						continue;
					case 3:
						P_1.Add(actionElementMap);
						num2 = -128163131;
						continue;
					case 4:
					{
						actionElementMap = fPjulZjolWMvpUtwTbQGWthEDzd(controllerTemplateButtonSource.target, wLEjKNOLFnsGKpXyzkxPOqxGPgl);
						int num3;
						if (actionElementMap == null)
						{
							num2 = -128163132;
							num3 = num2;
						}
						else
						{
							num2 = -128163130;
							num3 = num2;
						}
						continue;
					}
					default:
						return num;
					}
					break;
				}
			}
		}

		private ActionElementMap fPjulZjolWMvpUtwTbQGWthEDzd(IControllerElementTarget P_0, Pole P_1)
		{
			ControllerElementType controllerElementType = default(ControllerElementType);
			int num;
			if (P_0 != null)
			{
				if (P_0.element == null)
				{
					goto IL_000b;
				}
				controllerElementType = P_0.elementType;
				num = -1163059110;
				goto IL_0010;
			}
			goto IL_0044;
			IL_0010:
			ActionElementMap actionElementMap = default(ActionElementMap);
			AxisRange axisRange = default(AxisRange);
			while (true)
			{
				switch (num ^ -1163059109)
				{
				case 7:
					break;
				case 2:
					goto IL_0044;
				case 4:
					actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
					actionElementMap._elementType = controllerElementType;
					num = -1163059107;
					continue;
				case 3:
					goto IL_006e;
				case 1:
					axisRange = P_0.axisRange;
					actionElementMap = new ActionElementMap();
					num = -1163059105;
					continue;
				case 5:
					goto IL_009c;
				case 6:
					actionElementMap._axisRange = axisRange;
					num = -1163059112;
					continue;
				case 8:
					goto IL_00be;
				default:
					return actionElementMap;
				}
				break;
				IL_006e:
				if (controllerElementType == ControllerElementType.Axis)
				{
					int num2;
					if (axisRange == AxisRange.Full)
					{
						num = -1163059109;
						num2 = num;
					}
					else
					{
						num = -1163059117;
						num2 = num;
					}
					continue;
				}
				goto IL_00be;
				IL_009c:
				actionElementMap._axisContribution = P_1;
				num = -1163059109;
				continue;
				IL_00be:
				int num3;
				switch (controllerElementType)
				{
				case ControllerElementType.Axis:
					break;
				default:
					num = -1163059109;
					num3 = num;
					continue;
				case ControllerElementType.Button:
					num = -1163059106;
					num3 = num;
					continue;
				}
				goto IL_009c;
			}
			goto IL_000b;
			IL_0044:
			return null;
			IL_000b:
			num = -1163059111;
			goto IL_0010;
		}
	}
}
