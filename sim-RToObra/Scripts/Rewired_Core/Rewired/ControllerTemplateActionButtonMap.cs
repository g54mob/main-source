using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionButtonMap : ControllerTemplateActionElementMap
	{
		private Pole RQQsGIecPtkXpHobDdmZtQkIRSs;

		public Pole axisContribution
		{
			get
			{
				return RQQsGIecPtkXpHobDdmZtQkIRSs;
			}
		}

		internal ControllerTemplateActionButtonMap(SerializedObject serializedObject)
			: base(ControllerTemplateElementType.Button)
		{
			while (true)
			{
				int num = -1398848043;
				while (true)
				{
					switch (num ^ -1398848041)
					{
					case 0:
						break;
					case 2:
					{
						int num2;
						if (serializedObject != null)
						{
							num = -1398848042;
							num2 = num;
						}
						else
						{
							num = -1398848044;
							num2 = num;
						}
						continue;
					}
					case 3:
						throw new ArgumentNullException("serializedObject");
					default:
						Import(serializedObject);
						return;
					}
					break;
				}
			}
		}

		internal ControllerTemplateActionButtonMap(int templateElementIdentifierId, ActionElementMap actionElementMap)
			: base(ControllerTemplateElementType.Button, templateElementIdentifierId, actionElementMap)
		{
			RQQsGIecPtkXpHobDdmZtQkIRSs = actionElementMap.axisContribution;
		}

		internal ControllerTemplateActionButtonMap(int elementIdentifierId, int actionId, Pole axisContribution, bool enabled)
			: base(ControllerTemplateElementType.Button, elementIdentifierId, actionId, enabled)
		{
			RQQsGIecPtkXpHobDdmZtQkIRSs = axisContribution;
		}

		internal override void Export(SerializedObject P_0)
		{
			base.Export(P_0);
			P_0.Add("axisContribution", RQQsGIecPtkXpHobDdmZtQkIRSs);
		}

		internal override void Import(SerializedObject P_0)
		{
			base.Import(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref RQQsGIecPtkXpHobDdmZtQkIRSs);
		}

		internal override void Clear()
		{
			RQQsGIecPtkXpHobDdmZtQkIRSs = Pole.Positive;
		}

		internal override int CreateAEMsFromSource(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			IControllerTemplateButtonSource controllerTemplateButtonSource = P_0 as IControllerTemplateButtonSource;
			if (controllerTemplateButtonSource == null)
			{
				goto IL_000a;
			}
			int num = 0;
			ActionElementMap actionElementMap = ORpctOLVxOfzCkctjtbUvLbGQOe(controllerTemplateButtonSource.target, RQQsGIecPtkXpHobDdmZtQkIRSs);
			int num2;
			if (actionElementMap != null)
			{
				P_1.Add(actionElementMap);
				num2 = -1776119940;
				goto IL_000f;
			}
			goto IL_005f;
			IL_000f:
			while (true)
			{
				switch (num2 ^ -1776119940)
				{
				case 2:
					break;
				case 1:
					return 0;
				case 0:
					num++;
					num2 = -1776119937;
					continue;
				default:
					goto IL_005f;
				}
				break;
			}
			goto IL_000a;
			IL_005f:
			return num;
			IL_000a:
			num2 = -1776119939;
			goto IL_000f;
		}

		private ActionElementMap ORpctOLVxOfzCkctjtbUvLbGQOe(IControllerElementTarget P_0, Pole P_1)
		{
			ControllerElementType controllerElementType = default(ControllerElementType);
			AxisRange axisRange = default(AxisRange);
			int num;
			if (P_0 != null)
			{
				if (P_0.element == null)
				{
					goto IL_000b;
				}
				controllerElementType = P_0.elementType;
				axisRange = P_0.axisRange;
				num = -11395931;
				goto IL_0010;
			}
			goto IL_0040;
			IL_0010:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num ^ -11395934)
				{
				case 3:
					break;
				case 5:
					goto IL_0040;
				case 7:
					actionElementMap = new ActionElementMap();
					actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
					num = -11395930;
					continue;
				case 2:
					goto IL_0070;
				case 4:
					actionElementMap._elementType = controllerElementType;
					actionElementMap._axisRange = axisRange;
					num = -11395936;
					continue;
				case 6:
					goto IL_009f;
				case 1:
					goto IL_00ba;
				default:
					return actionElementMap;
				}
				break;
				IL_0070:
				if (controllerElementType == ControllerElementType.Axis)
				{
					int num2;
					if (axisRange == AxisRange.Full)
					{
						num = -11395934;
						num2 = num;
					}
					else
					{
						num = -11395932;
						num2 = num;
					}
					continue;
				}
				goto IL_009f;
				IL_00ba:
				actionElementMap._axisContribution = P_1;
				num = -11395934;
				continue;
				IL_009f:
				int num3;
				switch (controllerElementType)
				{
				case ControllerElementType.Button:
					num = -11395933;
					num3 = num;
					continue;
				default:
					num = -11395934;
					num3 = num;
					continue;
				case ControllerElementType.Axis:
					break;
				}
				goto IL_00ba;
			}
			goto IL_000b;
			IL_0040:
			return null;
			IL_000b:
			num = -11395929;
			goto IL_0010;
		}
	}
}
