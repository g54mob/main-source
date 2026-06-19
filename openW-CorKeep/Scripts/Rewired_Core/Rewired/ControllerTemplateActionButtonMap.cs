using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionButtonMap : ControllerTemplateActionElementMap
	{
		private Pole NYFoCEansdxkTilSlaLWICdueYgeA;

		public Pole axisContribution => NYFoCEansdxkTilSlaLWICdueYgeA;

		internal ControllerTemplateActionButtonMap(SerializedObject P_0)
			: base(ControllerTemplateElementType.Button)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			uMqyncwXliJAiRiUiWiUyLiSfrpdA(P_0);
		}

		internal ControllerTemplateActionButtonMap(int P_0, ActionElementMap P_1)
			: base(ControllerTemplateElementType.Button, P_0, P_1)
		{
			NYFoCEansdxkTilSlaLWICdueYgeA = P_1.axisContribution;
		}

		internal ControllerTemplateActionButtonMap(int P_0, int P_1, Pole P_2, bool P_3)
			: base(ControllerTemplateElementType.Button, P_0, P_1, P_3)
		{
			NYFoCEansdxkTilSlaLWICdueYgeA = P_2;
		}

		internal void tLGfYJVFifeAMOBruXkIcQmtmSBN(SerializedObject P_0)
		{
			base.vABcCNWeRmzGbFnvLaadmaTXvjBx(P_0);
			P_0.Add("axisContribution", NYFoCEansdxkTilSlaLWICdueYgeA);
		}

		internal void CbFtHtezrNgFuRiEmxsyQdeYSFRx(SerializedObject P_0)
		{
			base.uMqyncwXliJAiRiUiWiUyLiSfrpdA(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref NYFoCEansdxkTilSlaLWICdueYgeA);
		}

		internal void ZCKZmJONZqIXgZNCHELDUdDUCWYHA()
		{
			NYFoCEansdxkTilSlaLWICdueYgeA = Pole.Positive;
		}

		internal int eFfJZDJMLmUTCAGcNmIyDLyBSngK(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateButtonSource controllerTemplateButtonSource))
			{
				return 0;
			}
			int num = 0;
			ActionElementMap actionElementMap = APLXSYEACYblVzUUkNxBUajoltbE(controllerTemplateButtonSource.target, NYFoCEansdxkTilSlaLWICdueYgeA);
			if (actionElementMap != null)
			{
				P_1.Add(actionElementMap);
				num++;
			}
			return num;
		}

		private ActionElementMap APLXSYEACYblVzUUkNxBUajoltbE(IControllerElementTarget P_0, Pole P_1)
		{
			if (P_0 == null || P_0.element == null)
			{
				return null;
			}
			ControllerElementType controllerElementType = P_0.elementType;
			AxisRange axisRange = P_0.axisRange;
			try
			{
				ControllerMap.QXFruTPDQsWAkpbQTcKsnAHJFyR();
				ActionElementMap actionElementMap = new ActionElementMap();
				actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
				actionElementMap._elementType = controllerElementType;
				actionElementMap._axisRange = axisRange;
				if ((controllerElementType != ControllerElementType.Axis || axisRange != AxisRange.Full) && (controllerElementType == ControllerElementType.Axis || controllerElementType == ControllerElementType.Button))
				{
					actionElementMap._axisContribution = P_1;
				}
				return actionElementMap;
			}
			finally
			{
				ControllerMap.rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
			}
		}
	}
}
