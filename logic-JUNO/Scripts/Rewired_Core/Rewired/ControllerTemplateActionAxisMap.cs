using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange gNNmtYrBheaqbeChmCpMvsYjjWTsA;

		private Pole TyEfzWBgezQXJsvtDYDhAvFodTKcA;

		private bool sFlUOZKvqqREdPqFRhkkZXeoyWUA;

		public AxisRange axisRange => gNNmtYrBheaqbeChmCpMvsYjjWTsA;

		public Pole axisContribution => TyEfzWBgezQXJsvtDYDhAvFodTKcA;

		public bool invert => sFlUOZKvqqREdPqFRhkkZXeoyWUA;

		internal ControllerTemplateActionAxisMap(SerializedObject P_0)
			: base(ControllerTemplateElementType.Axis)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			cLonVRMJRJDDsWpsmpAImCfajIgS(P_0);
		}

		internal ControllerTemplateActionAxisMap(int P_0, AxisRange P_1, ActionElementMap P_2)
			: base(ControllerTemplateElementType.Axis, P_0, P_2)
		{
			gNNmtYrBheaqbeChmCpMvsYjjWTsA = P_1;
			TyEfzWBgezQXJsvtDYDhAvFodTKcA = P_2.axisContribution;
			sFlUOZKvqqREdPqFRhkkZXeoyWUA = P_2._invert;
		}

		internal ControllerTemplateActionAxisMap(int P_0, int P_1, AxisRange P_2, Pole P_3, bool P_4, bool P_5)
			: base(ControllerTemplateElementType.Axis, P_0, P_1, P_5)
		{
			gNNmtYrBheaqbeChmCpMvsYjjWTsA = P_2;
			TyEfzWBgezQXJsvtDYDhAvFodTKcA = P_3;
			sFlUOZKvqqREdPqFRhkkZXeoyWUA = P_4;
		}

		internal void mZJBmXeJWMIoHGnCeYZpfcKOskuUA(SerializedObject P_0)
		{
			base.nbRcGqFmdPBFbvAHNvzlHgGflOMSA(P_0);
			P_0.Add("axisContribution", TyEfzWBgezQXJsvtDYDhAvFodTKcA);
			P_0.Add("axisRange", gNNmtYrBheaqbeChmCpMvsYjjWTsA);
			P_0.Add("invert", sFlUOZKvqqREdPqFRhkkZXeoyWUA);
		}

		internal void clNBJtlNtRnFmodTZDQGjLFgLBoH(SerializedObject P_0)
		{
			base.cLonVRMJRJDDsWpsmpAImCfajIgS(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref TyEfzWBgezQXJsvtDYDhAvFodTKcA);
			P_0.TryGetDeserializedValueByRef("axisRange", ref gNNmtYrBheaqbeChmCpMvsYjjWTsA);
			P_0.TryGetDeserializedValueByRef("invert", ref sFlUOZKvqqREdPqFRhkkZXeoyWUA);
		}

		internal void qKKDCYwTKfHBIciGwPFRElVlVimI()
		{
			gNNmtYrBheaqbeChmCpMvsYjjWTsA = AxisRange.Full;
			TyEfzWBgezQXJsvtDYDhAvFodTKcA = Pole.Positive;
			sFlUOZKvqqREdPqFRhkkZXeoyWUA = false;
		}

		internal int IFsyMVzemOdEmOCVoVpdDhkXkXbn(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (!(P_0 is IControllerTemplateAxisSource controllerTemplateAxisSource))
			{
				return 0;
			}
			int num = 0;
			if (gNNmtYrBheaqbeChmCpMvsYjjWTsA == AxisRange.Full)
			{
				if (controllerTemplateAxisSource.splitAxis)
				{
					ActionElementMap actionElementMap = BWpltkhmXFfKWEhdmHPEeEOnwGll(controllerTemplateAxisSource.positiveTarget, (!sFlUOZKvqqREdPqFRhkkZXeoyWUA) ? AxisRange.Positive : AxisRange.Negative, TyEfzWBgezQXJsvtDYDhAvFodTKcA);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
					actionElementMap = BWpltkhmXFfKWEhdmHPEeEOnwGll(controllerTemplateAxisSource.negativeTarget, sFlUOZKvqqREdPqFRhkkZXeoyWUA ? AxisRange.Positive : AxisRange.Negative, TyEfzWBgezQXJsvtDYDhAvFodTKcA);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = BWpltkhmXFfKWEhdmHPEeEOnwGll(controllerTemplateAxisSource.fullTarget, AxisRange.Full, TyEfzWBgezQXJsvtDYDhAvFodTKcA);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else if (controllerTemplateAxisSource.splitAxis)
			{
				if (gNNmtYrBheaqbeChmCpMvsYjjWTsA == AxisRange.Positive)
				{
					ActionElementMap actionElementMap = ODkCiRNWnLnlmbVRvWSXunzDLqSc(controllerTemplateAxisSource.positiveTarget, Pole.Positive, TyEfzWBgezQXJsvtDYDhAvFodTKcA);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = ODkCiRNWnLnlmbVRvWSXunzDLqSc(controllerTemplateAxisSource.negativeTarget, Pole.Negative, TyEfzWBgezQXJsvtDYDhAvFodTKcA);
					if (actionElementMap != null)
					{
						P_1.Add(actionElementMap);
						num++;
					}
				}
			}
			else
			{
				ActionElementMap actionElementMap = ODkCiRNWnLnlmbVRvWSXunzDLqSc(controllerTemplateAxisSource.fullTarget, (gNNmtYrBheaqbeChmCpMvsYjjWTsA == AxisRange.Negative) ? Pole.Negative : Pole.Positive, TyEfzWBgezQXJsvtDYDhAvFodTKcA);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		private ActionElementMap BWpltkhmXFfKWEhdmHPEeEOnwGll(IControllerElementTarget P_0, AxisRange P_1, Pole P_2)
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
					actionElementMap._invert = sFlUOZKvqqREdPqFRhkkZXeoyWUA;
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

		private ActionElementMap ODkCiRNWnLnlmbVRvWSXunzDLqSc(IControllerElementTarget P_0, Pole P_1, Pole P_2)
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
