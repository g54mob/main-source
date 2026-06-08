using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		private AxisRange ULUBoZXZbPaLHXiblpGEJyjatZk;

		private Pole DqGgYWkBubghVSQVgMNYCIGRYGK;

		private bool tUFnrkODyJPzZYlBlWfDpcjhjBr;

		public AxisRange axisRange => ULUBoZXZbPaLHXiblpGEJyjatZk;

		public Pole axisContribution => DqGgYWkBubghVSQVgMNYCIGRYGK;

		public bool invert => tUFnrkODyJPzZYlBlWfDpcjhjBr;

		internal ControllerTemplateActionAxisMap(SerializedObject serializedObject)
			: base(ControllerTemplateElementType.Axis)
		{
			if (serializedObject == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			FMjbXwujmHnZzQbodRBJzieOPHZ(serializedObject);
		}

		internal ControllerTemplateActionAxisMap(int templateElementIdentifierId, AxisRange axisRange, ActionElementMap actionElementMap)
			: base(ControllerTemplateElementType.Axis, templateElementIdentifierId, actionElementMap)
		{
			ULUBoZXZbPaLHXiblpGEJyjatZk = axisRange;
			DqGgYWkBubghVSQVgMNYCIGRYGK = actionElementMap.axisContribution;
			tUFnrkODyJPzZYlBlWfDpcjhjBr = actionElementMap._invert;
		}

		internal ControllerTemplateActionAxisMap(int elementIdentifierId, int actionId, AxisRange axisRange, Pole axisContribution, bool invert, bool enabled)
			: base(ControllerTemplateElementType.Axis, elementIdentifierId, actionId, enabled)
		{
			ULUBoZXZbPaLHXiblpGEJyjatZk = axisRange;
			DqGgYWkBubghVSQVgMNYCIGRYGK = axisContribution;
			tUFnrkODyJPzZYlBlWfDpcjhjBr = invert;
		}

		internal override void mtMtVVrohwWTxFPivXmGbDyGevo(SerializedObject P_0)
		{
			base.mtMtVVrohwWTxFPivXmGbDyGevo(P_0);
			P_0.Add("axisContribution", DqGgYWkBubghVSQVgMNYCIGRYGK);
			P_0.Add("axisRange", ULUBoZXZbPaLHXiblpGEJyjatZk);
			P_0.Add("invert", tUFnrkODyJPzZYlBlWfDpcjhjBr);
		}

		internal override void FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject P_0)
		{
			base.FMjbXwujmHnZzQbodRBJzieOPHZ(P_0);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref DqGgYWkBubghVSQVgMNYCIGRYGK);
			while (true)
			{
				int num = 779994474;
				while (true)
				{
					switch (num ^ 0x2E7DC568)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0037;
					case 1:
						return;
					}
					break;
					IL_0037:
					P_0.TryGetDeserializedValueByRef("axisRange", ref ULUBoZXZbPaLHXiblpGEJyjatZk);
					P_0.TryGetDeserializedValueByRef("invert", ref tUFnrkODyJPzZYlBlWfDpcjhjBr);
					num = 779994473;
				}
			}
		}

		internal override void tAgADqjTsMUxSqYXeDyJIdETYRAp()
		{
			ULUBoZXZbPaLHXiblpGEJyjatZk = AxisRange.Full;
			DqGgYWkBubghVSQVgMNYCIGRYGK = Pole.Positive;
			tUFnrkODyJPzZYlBlWfDpcjhjBr = false;
		}

		internal override int TPjqYspfJVdLLflGpdCjWPeGAtN(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
		{
			IControllerTemplateAxisSource controllerTemplateAxisSource = P_0 as IControllerTemplateAxisSource;
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			while (true)
			{
				int num = -830404983;
				while (true)
				{
					switch (num ^ -830404980)
					{
					case 14:
						break;
					case 3:
						actionElementMap = RWnhDGPvwDGFCqfEnoIKzgarqFA(controllerTemplateAxisSource.negativeTarget, Pole.Negative, DqGgYWkBubghVSQVgMNYCIGRYGK);
						if (actionElementMap != null)
						{
							P_1.Add(actionElementMap);
							num2++;
							num = -830404978;
							continue;
						}
						goto default;
					case 10:
					{
						int num6;
						if (!controllerTemplateAxisSource.splitAxis)
						{
							num = -830404984;
							num6 = num;
						}
						else
						{
							num = -830404964;
							num6 = num;
						}
						continue;
					}
					case 9:
						if (controllerTemplateAxisSource.splitAxis)
						{
							if (ULUBoZXZbPaLHXiblpGEJyjatZk == AxisRange.Positive)
							{
								actionElementMap = RWnhDGPvwDGFCqfEnoIKzgarqFA(controllerTemplateAxisSource.positiveTarget, Pole.Positive, DqGgYWkBubghVSQVgMNYCIGRYGK);
								int num3;
								if (actionElementMap == null)
								{
									num = -830404978;
									num3 = num;
								}
								else
								{
									num = -830404981;
									num3 = num;
								}
								continue;
							}
							goto case 3;
						}
						goto case 11;
					case 5:
					{
						if (controllerTemplateAxisSource == null)
						{
							return 0;
						}
						num2 = 0;
						int num5;
						if (ULUBoZXZbPaLHXiblpGEJyjatZk == AxisRange.Full)
						{
							num = -830404986;
							num5 = num;
						}
						else
						{
							num = -830404987;
							num5 = num;
						}
						continue;
					}
					case 7:
						P_1.Add(actionElementMap);
						num = -830404991;
						continue;
					case 11:
						actionElementMap = RWnhDGPvwDGFCqfEnoIKzgarqFA(controllerTemplateAxisSource.fullTarget, (ULUBoZXZbPaLHXiblpGEJyjatZk == AxisRange.Negative) ? Pole.Negative : Pole.Positive, DqGgYWkBubghVSQVgMNYCIGRYGK);
						num = -830404982;
						continue;
					case 4:
						actionElementMap = wFBXBNxagKFmPNOVLrRbobQOvBX(controllerTemplateAxisSource.fullTarget, AxisRange.Full);
						if (actionElementMap != null)
						{
							P_1.Add(actionElementMap);
							num2++;
							num = -830404978;
							continue;
						}
						goto default;
					case 1:
						num = -830404978;
						continue;
					case 15:
						P_1.Add(actionElementMap);
						num = -830404992;
						continue;
					case 16:
					{
						actionElementMap = wFBXBNxagKFmPNOVLrRbobQOvBX(controllerTemplateAxisSource.positiveTarget, (!tUFnrkODyJPzZYlBlWfDpcjhjBr) ? AxisRange.Positive : AxisRange.Negative);
						int num4;
						if (actionElementMap != null)
						{
							num = -830404989;
							num4 = num;
						}
						else
						{
							num = -830404988;
							num4 = num;
						}
						continue;
					}
					case 8:
						actionElementMap = wFBXBNxagKFmPNOVLrRbobQOvBX(controllerTemplateAxisSource.negativeTarget, tUFnrkODyJPzZYlBlWfDpcjhjBr ? AxisRange.Positive : AxisRange.Negative);
						num = -830404980;
						continue;
					case 6:
						if (actionElementMap != null)
						{
							P_1.Add(actionElementMap);
							num2++;
							num = -830404978;
							continue;
						}
						goto default;
					case 12:
						num2++;
						num = -830404988;
						continue;
					case 13:
						num2++;
						num = -830404979;
						continue;
					case 0:
						if (actionElementMap != null)
						{
							P_1.Add(actionElementMap);
							num2++;
							num = -830404978;
							continue;
						}
						goto default;
					default:
						return num2;
					}
					break;
				}
			}
		}

		private ActionElementMap wFBXBNxagKFmPNOVLrRbobQOvBX(IControllerElementTarget P_0, AxisRange P_1)
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
				num = 527728882;
				goto IL_0016;
			}
			goto IL_00a5;
			IL_0016:
			Pole pole = default(Pole);
			while (true)
			{
				switch (num ^ 0x1F7480F4)
				{
				case 2:
					break;
				case 0:
					actionElementMap._axisContribution = pole;
					num = 527728892;
					continue;
				case 6:
					actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
					actionElementMap._elementType = controllerElementType;
					actionElementMap._axisRange = axisRange;
					num = 527728880;
					continue;
				case 7:
					pole = ((P_1 == AxisRange.Negative) ? Pole.Negative : Pole.Positive);
					num = 527728884;
					continue;
				case 4:
					if (controllerElementType == ControllerElementType.Axis && axisRange == AxisRange.Full)
					{
						actionElementMap._invert = tUFnrkODyJPzZYlBlWfDpcjhjBr;
						num = 527728892;
						continue;
					}
					goto IL_00dd;
				case 5:
					goto IL_00a5;
				case 3:
					goto IL_00c5;
				case 1:
					goto IL_00dd;
				default:
					return actionElementMap;
				}
				break;
				IL_00c5:
				int num2;
				if (controllerElementType != ControllerElementType.Button)
				{
					num = 527728892;
					num2 = num;
				}
				else
				{
					num = 527728883;
					num2 = num;
				}
				continue;
				IL_00dd:
				int num3;
				if (controllerElementType == ControllerElementType.Axis)
				{
					num = 527728883;
					num3 = num;
				}
				else
				{
					num = 527728887;
					num3 = num;
				}
			}
			goto IL_0011;
			IL_00a5:
			return null;
			IL_0011:
			num = 527728881;
			goto IL_0016;
		}

		private ActionElementMap RWnhDGPvwDGFCqfEnoIKzgarqFA(IControllerElementTarget P_0, Pole P_1, Pole P_2)
		{
			if (P_0 != null)
			{
				ActionElementMap actionElementMap = default(ActionElementMap);
				AxisRange axisRange = default(AxisRange);
				ControllerElementType controllerElementType = default(ControllerElementType);
				while (true)
				{
					int num = -849600794;
					while (true)
					{
						switch (num ^ -849600786)
						{
						case 10:
							break;
						case 3:
							actionElementMap._axisRange = axisRange;
							num = -849600786;
							continue;
						case 2:
							goto IL_005d;
						case 1:
							actionElementMap._axisContribution = P_2;
							num = -849600789;
							continue;
						case 9:
							actionElementMap = new ActionElementMap();
							num = -849600795;
							continue;
						case 4:
							actionElementMap._axisRange = ((P_1 == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative);
							actionElementMap._axisContribution = P_2;
							num = -849600789;
							continue;
						case 6:
							goto IL_00ad;
						case 12:
							goto end_IL_0006;
						case 8:
							goto IL_00df;
						case 11:
							actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
							actionElementMap._elementType = controllerElementType;
							num = -849600787;
							continue;
						case 7:
							goto IL_010e;
						case 0:
							goto IL_0125;
						default:
							return actionElementMap;
						}
						break;
						IL_0125:
						int num2;
						if (controllerElementType == ControllerElementType.Axis)
						{
							num = -849600791;
							num2 = num;
						}
						else
						{
							num = -849600788;
							num2 = num;
						}
						continue;
						IL_005d:
						int num3;
						if (controllerElementType == ControllerElementType.Axis)
						{
							num = -849600785;
							num3 = num;
						}
						else
						{
							num = -849600792;
							num3 = num;
						}
						continue;
						IL_00df:
						if (P_0.element != null)
						{
							controllerElementType = P_0.elementType;
							axisRange = P_0.axisRange;
							num = -849600793;
						}
						else
						{
							num = -849600798;
						}
						continue;
						IL_010e:
						int num4;
						if (axisRange != AxisRange.Full)
						{
							num = -849600788;
							num4 = num;
						}
						else
						{
							num = -849600790;
							num4 = num;
						}
						continue;
						IL_00ad:
						int num5;
						if (controllerElementType != ControllerElementType.Button)
						{
							num = -849600789;
							num5 = num;
						}
						else
						{
							num = -849600785;
							num5 = num;
						}
					}
					continue;
					end_IL_0006:
					break;
				}
			}
			return null;
		}
	}
}
