using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange JRfEkSlNaXaIMTBgVBlYbigYoaTJ;

		private Pole wIyIULyprIPqAycxklnlJfdBniCD;

		private bool RvjFtGdYgRSXfDGnolZoYGhLYKMDA;

		public AxisRange axisRange => JRfEkSlNaXaIMTBgVBlYbigYoaTJ;

		public Pole axisContribution => wIyIULyprIPqAycxklnlJfdBniCD;

		public bool invert => RvjFtGdYgRSXfDGnolZoYGhLYKMDA;

		internal ControllerTemplateActionAxisMap(SerializedObject P_0)
			: base(ControllerTemplateElementType.Axis)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			TiARSBGHYwWRRTIpTBPKxkTBxqeX(P_0);
		}

		internal ControllerTemplateActionAxisMap(int P_0, AxisRange P_1, ActionElementMap P_2)
			: base(ControllerTemplateElementType.Axis, P_0, P_2)
		{
			JRfEkSlNaXaIMTBgVBlYbigYoaTJ = P_1;
			wIyIULyprIPqAycxklnlJfdBniCD = P_2.axisContribution;
			RvjFtGdYgRSXfDGnolZoYGhLYKMDA = P_2._invert;
		}

		internal ControllerTemplateActionAxisMap(int P_0, int P_1, AxisRange P_2, Pole P_3, bool P_4, bool P_5)
			: base(ControllerTemplateElementType.Axis, P_0, P_1, P_5)
		{
			JRfEkSlNaXaIMTBgVBlYbigYoaTJ = P_2;
			wIyIULyprIPqAycxklnlJfdBniCD = P_3;
			RvjFtGdYgRSXfDGnolZoYGhLYKMDA = P_4;
		}

		internal void DNtTcLJVqlmRquBLLrknzuftYtcC(SerializedObject P_0)
		{
			base.CmnfhwiyqiNdINILsJMpriXEkjSC(P_0);
			P_0.Add("axisContribution", wIyIULyprIPqAycxklnlJfdBniCD);
			P_0.Add("axisRange", JRfEkSlNaXaIMTBgVBlYbigYoaTJ);
			P_0.Add("invert", RvjFtGdYgRSXfDGnolZoYGhLYKMDA);
		}

		internal void VwdyozrqAwBbBepSwFzUKetTpjuIA(SerializedObject P_0)
		{
			base.TiARSBGHYwWRRTIpTBPKxkTBxqeX(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref wIyIULyprIPqAycxklnlJfdBniCD);
			P_0.TryGetDeserializedValueByRef("axisRange", ref JRfEkSlNaXaIMTBgVBlYbigYoaTJ);
			P_0.TryGetDeserializedValueByRef("invert", ref RvjFtGdYgRSXfDGnolZoYGhLYKMDA);
		}

		internal void JwcXqUoRSYjXlhDDPjxBdNvYapirA()
		{
			JRfEkSlNaXaIMTBgVBlYbigYoaTJ = AxisRange.Full;
			wIyIULyprIPqAycxklnlJfdBniCD = Pole.Positive;
			RvjFtGdYgRSXfDGnolZoYGhLYKMDA = false;
		}

		internal int hZOwDZnfdtDtXIFEJJbvHMGgmfjRb(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateAxisSource controllerTemplateAxisSource))
			{
				return 0;
			}
			int num = 0;
			if (JRfEkSlNaXaIMTBgVBlYbigYoaTJ == AxisRange.Full)
			{
				if (controllerTemplateAxisSource.splitAxis)
				{
					ActionElementMap actionElementMap = upZOCidTSwNzbBDqRQlQvOeUAWdS(controllerTemplateAxisSource.positiveTarget, (!RvjFtGdYgRSXfDGnolZoYGhLYKMDA) ? AxisRange.Positive : AxisRange.Negative, wIyIULyprIPqAycxklnlJfdBniCD);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
					actionElementMap = upZOCidTSwNzbBDqRQlQvOeUAWdS(controllerTemplateAxisSource.negativeTarget, RvjFtGdYgRSXfDGnolZoYGhLYKMDA ? AxisRange.Positive : AxisRange.Negative, wIyIULyprIPqAycxklnlJfdBniCD);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = upZOCidTSwNzbBDqRQlQvOeUAWdS(controllerTemplateAxisSource.fullTarget, AxisRange.Full, wIyIULyprIPqAycxklnlJfdBniCD);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else if (controllerTemplateAxisSource.splitAxis)
			{
				if (JRfEkSlNaXaIMTBgVBlYbigYoaTJ == AxisRange.Positive)
				{
					ActionElementMap actionElementMap = zPUZdXVhXmZrZySWUboDzOJiFlut(controllerTemplateAxisSource.positiveTarget, Pole.Positive, wIyIULyprIPqAycxklnlJfdBniCD);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = zPUZdXVhXmZrZySWUboDzOJiFlut(controllerTemplateAxisSource.negativeTarget, Pole.Negative, wIyIULyprIPqAycxklnlJfdBniCD);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else
			{
				ActionElementMap actionElementMap = zPUZdXVhXmZrZySWUboDzOJiFlut(controllerTemplateAxisSource.fullTarget, (JRfEkSlNaXaIMTBgVBlYbigYoaTJ == AxisRange.Negative) ? Pole.Negative : Pole.Positive, wIyIULyprIPqAycxklnlJfdBniCD);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		private ActionElementMap upZOCidTSwNzbBDqRQlQvOeUAWdS(IControllerElementTarget P_0, AxisRange P_1, Pole P_2)
		{
			if (P_0 == null || P_0.element == null)
			{
				return null;
			}
			ControllerElementType controllerElementType = P_0.elementType;
			AxisRange axisRange = P_0.axisRange;
			ActionElementMap actionElementMap = new ActionElementMap();
			actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
			actionElementMap._elementType = controllerElementType;
			actionElementMap._axisRange = axisRange;
			if (axisRange == AxisRange.Full)
			{
				switch (controllerElementType)
				{
				case ControllerElementType.Axis:
					actionElementMap._invert = RvjFtGdYgRSXfDGnolZoYGhLYKMDA;
					break;
				case ControllerElementType.Button:
					actionElementMap._axisContribution = P_2;
					break;
				}
			}
			else if (controllerElementType == ControllerElementType.Axis || controllerElementType == ControllerElementType.Button)
			{
				Pole pole = ((P_1 == AxisRange.Negative) ? Pole.Negative : Pole.Positive);
				actionElementMap._axisContribution = pole;
			}
			return actionElementMap;
		}

		private ActionElementMap zPUZdXVhXmZrZySWUboDzOJiFlut(IControllerElementTarget P_0, Pole P_1, Pole P_2)
		{
			if (P_0 == null || P_0.element == null)
			{
				return null;
			}
			ControllerElementType controllerElementType = P_0.elementType;
			AxisRange axisRange = P_0.axisRange;
			ActionElementMap actionElementMap = new ActionElementMap();
			actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
			actionElementMap._elementType = controllerElementType;
			actionElementMap._axisRange = axisRange;
			if (controllerElementType == ControllerElementType.Axis && axisRange == AxisRange.Full)
			{
				actionElementMap._axisRange = ((P_1 == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative);
				actionElementMap._axisContribution = P_2;
			}
			else if (controllerElementType == ControllerElementType.Axis || controllerElementType == ControllerElementType.Button)
			{
				actionElementMap._axisContribution = P_2;
			}
			return actionElementMap;
		}
	}
}
