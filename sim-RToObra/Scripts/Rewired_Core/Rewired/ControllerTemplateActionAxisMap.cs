using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange ObWitXNhWFZMnOJBWvYTcBBfVnG;

		private Pole RQQsGIecPtkXpHobDdmZtQkIRSs;

		private bool vkDZTsWOJBkpzXazOFlYaCZkzNP;

		public AxisRange axisRange
		{
			get
			{
				return ObWitXNhWFZMnOJBWvYTcBBfVnG;
			}
		}

		public Pole axisContribution
		{
			get
			{
				return RQQsGIecPtkXpHobDdmZtQkIRSs;
			}
		}

		public bool invert
		{
			get
			{
				return vkDZTsWOJBkpzXazOFlYaCZkzNP;
			}
		}

		internal ControllerTemplateActionAxisMap(SerializedObject serializedObject)
			: base(ControllerTemplateElementType.Axis)
		{
			if (serializedObject == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			Import(serializedObject);
		}

		internal ControllerTemplateActionAxisMap(int templateElementIdentifierId, AxisRange axisRange, ActionElementMap actionElementMap)
			: base(ControllerTemplateElementType.Axis, templateElementIdentifierId, actionElementMap)
		{
			ObWitXNhWFZMnOJBWvYTcBBfVnG = axisRange;
			RQQsGIecPtkXpHobDdmZtQkIRSs = actionElementMap.axisContribution;
			vkDZTsWOJBkpzXazOFlYaCZkzNP = actionElementMap._invert;
		}

		internal ControllerTemplateActionAxisMap(int elementIdentifierId, int actionId, AxisRange axisRange, Pole axisContribution, bool invert, bool enabled)
			: base(ControllerTemplateElementType.Axis, elementIdentifierId, actionId, enabled)
		{
			ObWitXNhWFZMnOJBWvYTcBBfVnG = axisRange;
			RQQsGIecPtkXpHobDdmZtQkIRSs = axisContribution;
			vkDZTsWOJBkpzXazOFlYaCZkzNP = invert;
		}

		internal override void Export(SerializedObject P_0)
		{
			base.Export(P_0);
			while (true)
			{
				int num = -193275475;
				while (true)
				{
					switch (num ^ -193275473)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0025;
					case 1:
						return;
					}
					break;
					IL_0025:
					P_0.Add("axisContribution", RQQsGIecPtkXpHobDdmZtQkIRSs);
					P_0.Add("axisRange", ObWitXNhWFZMnOJBWvYTcBBfVnG);
					P_0.Add("invert", vkDZTsWOJBkpzXazOFlYaCZkzNP);
					num = -193275474;
				}
			}
		}

		internal override void Import(SerializedObject P_0)
		{
			base.Import(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref RQQsGIecPtkXpHobDdmZtQkIRSs);
			P_0.TryGetDeserializedValueByRef("axisRange", ref ObWitXNhWFZMnOJBWvYTcBBfVnG);
			P_0.TryGetDeserializedValueByRef("invert", ref vkDZTsWOJBkpzXazOFlYaCZkzNP);
		}

		internal override void Clear()
		{
			ObWitXNhWFZMnOJBWvYTcBBfVnG = AxisRange.Full;
			RQQsGIecPtkXpHobDdmZtQkIRSs = Pole.Positive;
			vkDZTsWOJBkpzXazOFlYaCZkzNP = false;
		}

		internal override int CreateAEMsFromSource(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			IControllerTemplateAxisSource controllerTemplateAxisSource = P_0 as IControllerTemplateAxisSource;
			int num2 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				int num = 1843758465;
				while (true)
				{
					switch (num ^ 0x6DE58587)
					{
					case 4:
						break;
					case 9:
						num2++;
						num = 1843758470;
						continue;
					case 0:
						actionElementMap = ZKbdzUVGJVKduvKcWbpXYkEsIXs(controllerTemplateAxisSource.fullTarget, (ObWitXNhWFZMnOJBWvYTcBBfVnG == AxisRange.Negative) ? Pole.Negative : Pole.Positive, RQQsGIecPtkXpHobDdmZtQkIRSs);
						if (actionElementMap != null)
						{
							P_1.Add(actionElementMap);
							num2++;
							num = 1843758477;
							continue;
						}
						goto default;
					case 8:
						actionElementMap = ZKbdzUVGJVKduvKcWbpXYkEsIXs(controllerTemplateAxisSource.negativeTarget, Pole.Negative, RQQsGIecPtkXpHobDdmZtQkIRSs);
						if (actionElementMap != null)
						{
							P_1.Add(actionElementMap);
							num = 1843758474;
							continue;
						}
						goto default;
					case 3:
						P_1.Add(actionElementMap);
						num2++;
						num = 1843758477;
						continue;
					case 13:
						num2++;
						num = 1843758477;
						continue;
					case 12:
						if (actionElementMap != null)
						{
							P_1.Add(actionElementMap);
							num2++;
							num = 1843758477;
							continue;
						}
						goto default;
					case 6:
						if (controllerTemplateAxisSource == null)
						{
							return 0;
						}
						num2 = 0;
						if (ObWitXNhWFZMnOJBWvYTcBBfVnG != AxisRange.Full)
						{
							goto case 7;
						}
						if (controllerTemplateAxisSource.splitAxis)
						{
							actionElementMap = sUXshLnFZOYzpWDlazYcROmXCpb(controllerTemplateAxisSource.positiveTarget, (!vkDZTsWOJBkpzXazOFlYaCZkzNP) ? AxisRange.Positive : AxisRange.Negative);
							num = 1843758466;
							continue;
						}
						goto case 11;
					case 7:
						if (!controllerTemplateAxisSource.splitAxis)
						{
							goto case 0;
						}
						if (ObWitXNhWFZMnOJBWvYTcBBfVnG != AxisRange.Positive)
						{
							goto case 8;
						}
						actionElementMap = ZKbdzUVGJVKduvKcWbpXYkEsIXs(controllerTemplateAxisSource.positiveTarget, Pole.Positive, RQQsGIecPtkXpHobDdmZtQkIRSs);
						if (actionElementMap != null)
						{
							P_1.Add(actionElementMap);
							num = 1843758478;
							continue;
						}
						goto default;
					case 1:
						num = 1843758477;
						continue;
					case 5:
						if (actionElementMap != null)
						{
							P_1.Add(actionElementMap);
							num2++;
							num = 1843758469;
							continue;
						}
						goto case 2;
					case 11:
					{
						actionElementMap = sUXshLnFZOYzpWDlazYcROmXCpb(controllerTemplateAxisSource.fullTarget, AxisRange.Full);
						int num3;
						if (actionElementMap == null)
						{
							num = 1843758477;
							num3 = num;
						}
						else
						{
							num = 1843758468;
							num3 = num;
						}
						continue;
					}
					case 2:
						actionElementMap = sUXshLnFZOYzpWDlazYcROmXCpb(controllerTemplateAxisSource.negativeTarget, vkDZTsWOJBkpzXazOFlYaCZkzNP ? AxisRange.Positive : AxisRange.Negative);
						num = 1843758475;
						continue;
					default:
						return num2;
					}
					break;
				}
			}
		}

		private ActionElementMap sUXshLnFZOYzpWDlazYcROmXCpb(IControllerElementTarget P_0, AxisRange P_1)
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
				num = 1390117649;
				goto IL_0016;
			}
			goto IL_00bd;
			IL_0016:
			Pole pole = default(Pole);
			while (true)
			{
				switch (num ^ 0x52DB8317)
				{
				case 0:
					break;
				case 5:
					pole = ((P_1 == AxisRange.Negative) ? Pole.Negative : Pole.Positive);
					num = 1390117654;
					continue;
				case 6:
					actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
					num = 1390117663;
					continue;
				case 2:
					goto IL_006d;
				case 8:
					actionElementMap._elementType = controllerElementType;
					actionElementMap._axisRange = axisRange;
					if (controllerElementType == ControllerElementType.Axis && axisRange == AxisRange.Full)
					{
						actionElementMap._invert = vkDZTsWOJBkpzXazOFlYaCZkzNP;
						num = 1390117651;
						continue;
					}
					goto IL_00dd;
				case 1:
					actionElementMap._axisContribution = pole;
					num = 1390117651;
					continue;
				case 7:
					goto IL_00bd;
				case 3:
					goto IL_00dd;
				default:
					return actionElementMap;
				}
				break;
				IL_00dd:
				int num2;
				if (controllerElementType == ControllerElementType.Axis)
				{
					num = 1390117650;
					num2 = num;
				}
				else
				{
					num = 1390117653;
					num2 = num;
				}
				continue;
				IL_006d:
				int num3;
				if (controllerElementType == ControllerElementType.Button)
				{
					num = 1390117650;
					num3 = num;
				}
				else
				{
					num = 1390117651;
					num3 = num;
				}
			}
			goto IL_0011;
			IL_00bd:
			return null;
			IL_0011:
			num = 1390117648;
			goto IL_0016;
		}

		private ActionElementMap ZKbdzUVGJVKduvKcWbpXYkEsIXs(IControllerElementTarget P_0, Pole P_1, Pole P_2)
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
				num = 1566376049;
				goto IL_0010;
			}
			goto IL_0044;
			IL_0010:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0x5D5D0076)
				{
				case 0:
					break;
				case 3:
					goto IL_0044;
				case 5:
					actionElementMap._axisContribution = P_2;
					num = 1566376055;
					continue;
				case 4:
					goto IL_0069;
				case 2:
					goto IL_007d;
				case 7:
					actionElementMap = new ActionElementMap();
					actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
					num = 1566376062;
					continue;
				case 6:
					actionElementMap._axisContribution = P_2;
					num = 1566376055;
					continue;
				case 8:
					actionElementMap._elementType = controllerElementType;
					actionElementMap._axisRange = axisRange;
					if (controllerElementType == ControllerElementType.Axis && axisRange == AxisRange.Full)
					{
						actionElementMap._axisRange = ((P_1 == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative);
						num = 1566376051;
						continue;
					}
					goto IL_0069;
				default:
					return actionElementMap;
				}
				break;
				IL_007d:
				int num2;
				if (controllerElementType == ControllerElementType.Button)
				{
					num = 1566376048;
					num2 = num;
				}
				else
				{
					num = 1566376055;
					num2 = num;
				}
				continue;
				IL_0069:
				int num3;
				if (controllerElementType != ControllerElementType.Axis)
				{
					num = 1566376052;
					num3 = num;
				}
				else
				{
					num = 1566376048;
					num3 = num;
				}
			}
			goto IL_000b;
			IL_0044:
			return null;
			IL_000b:
			num = 1566376053;
			goto IL_0010;
		}
	}
}
