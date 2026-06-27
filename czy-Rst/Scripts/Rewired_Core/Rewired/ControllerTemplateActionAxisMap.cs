using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange fDgktnmdiVuDqECjQNUfWJEZKMxQ;

		private Pole UezUrfdinKyeMjofviuEayBKIJcX;

		private bool fbyEFfDqyBmXPPoEnSfLbBHEankm;

		public AxisRange axisRange => fDgktnmdiVuDqECjQNUfWJEZKMxQ;

		public Pole axisContribution => UezUrfdinKyeMjofviuEayBKIJcX;

		public bool invert => fbyEFfDqyBmXPPoEnSfLbBHEankm;

		internal ControllerTemplateActionAxisMap(SerializedObject P_0)
			: base(ControllerTemplateElementType.Axis)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			xwZjRkRdGaGqfQSgCLUjULhWfQEJA(P_0);
		}

		internal ControllerTemplateActionAxisMap(int P_0, AxisRange P_1, ActionElementMap P_2)
			: base(ControllerTemplateElementType.Axis, P_0, P_2)
		{
			fDgktnmdiVuDqECjQNUfWJEZKMxQ = P_1;
			UezUrfdinKyeMjofviuEayBKIJcX = P_2.axisContribution;
			fbyEFfDqyBmXPPoEnSfLbBHEankm = P_2._invert;
		}

		internal ControllerTemplateActionAxisMap(int P_0, int P_1, AxisRange P_2, Pole P_3, bool P_4, bool P_5)
			: base(ControllerTemplateElementType.Axis, P_0, P_1, P_5)
		{
			fDgktnmdiVuDqECjQNUfWJEZKMxQ = P_2;
			UezUrfdinKyeMjofviuEayBKIJcX = P_3;
			fbyEFfDqyBmXPPoEnSfLbBHEankm = P_4;
		}

		internal void lCwBeaQvDzHZEdzCQBqIgOUecsSMB(SerializedObject P_0)
		{
			base.kbkaGXJhmuyekOMJziIUTMQPuCadA(P_0);
			P_0.Add("axisContribution", UezUrfdinKyeMjofviuEayBKIJcX);
			P_0.Add("axisRange", fDgktnmdiVuDqECjQNUfWJEZKMxQ);
			P_0.Add("invert", fbyEFfDqyBmXPPoEnSfLbBHEankm);
		}

		internal void nhcXjQgGFyAntiJXzaIfPNmEJKWe(SerializedObject P_0)
		{
			base.xwZjRkRdGaGqfQSgCLUjULhWfQEJA(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref UezUrfdinKyeMjofviuEayBKIJcX);
			P_0.TryGetDeserializedValueByRef("axisRange", ref fDgktnmdiVuDqECjQNUfWJEZKMxQ);
			P_0.TryGetDeserializedValueByRef("invert", ref fbyEFfDqyBmXPPoEnSfLbBHEankm);
		}

		internal void jhdLHdvMlKotRgENOwjaqRXRFCYd()
		{
			fDgktnmdiVuDqECjQNUfWJEZKMxQ = AxisRange.Full;
			UezUrfdinKyeMjofviuEayBKIJcX = Pole.Positive;
			fbyEFfDqyBmXPPoEnSfLbBHEankm = false;
		}

		internal int VfHsuuyfzxElaSNlCcOhxcubXDbc(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateAxisSource controllerTemplateAxisSource))
			{
				return 0;
			}
			int num = 0;
			if (fDgktnmdiVuDqECjQNUfWJEZKMxQ == AxisRange.Full)
			{
				if (controllerTemplateAxisSource.splitAxis)
				{
					ActionElementMap actionElementMap = YdCpvJwAAmKQROWxWtitIMCPGuNs(controllerTemplateAxisSource.positiveTarget, (!fbyEFfDqyBmXPPoEnSfLbBHEankm) ? AxisRange.Positive : AxisRange.Negative, UezUrfdinKyeMjofviuEayBKIJcX);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
					actionElementMap = YdCpvJwAAmKQROWxWtitIMCPGuNs(controllerTemplateAxisSource.negativeTarget, fbyEFfDqyBmXPPoEnSfLbBHEankm ? AxisRange.Positive : AxisRange.Negative, UezUrfdinKyeMjofviuEayBKIJcX);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = YdCpvJwAAmKQROWxWtitIMCPGuNs(controllerTemplateAxisSource.fullTarget, AxisRange.Full, UezUrfdinKyeMjofviuEayBKIJcX);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else if (controllerTemplateAxisSource.splitAxis)
			{
				if (fDgktnmdiVuDqECjQNUfWJEZKMxQ == AxisRange.Positive)
				{
					ActionElementMap actionElementMap = RAVEQsELlsYFhjZtRjXcGjlrNOYc(controllerTemplateAxisSource.positiveTarget, Pole.Positive, UezUrfdinKyeMjofviuEayBKIJcX);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = RAVEQsELlsYFhjZtRjXcGjlrNOYc(controllerTemplateAxisSource.negativeTarget, Pole.Negative, UezUrfdinKyeMjofviuEayBKIJcX);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else
			{
				ActionElementMap actionElementMap = RAVEQsELlsYFhjZtRjXcGjlrNOYc(controllerTemplateAxisSource.fullTarget, (fDgktnmdiVuDqECjQNUfWJEZKMxQ == AxisRange.Negative) ? Pole.Negative : Pole.Positive, UezUrfdinKyeMjofviuEayBKIJcX);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		private ActionElementMap YdCpvJwAAmKQROWxWtitIMCPGuNs(IControllerElementTarget P_0, AxisRange P_1, Pole P_2)
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
					actionElementMap._invert = fbyEFfDqyBmXPPoEnSfLbBHEankm;
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

		private ActionElementMap RAVEQsELlsYFhjZtRjXcGjlrNOYc(IControllerElementTarget P_0, Pole P_1, Pole P_2)
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
