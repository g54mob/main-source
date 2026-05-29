using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerTemplate : IControllerTemplate
	{
		internal abstract class jUsmBPPozsChspVdxyHFfIWHsmS : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate eOotmcFksuDgVSpJBCGwMaaBooj;

			private readonly int KAixZgRycuVSHIYaEVNGzKGIdgV;

			private readonly string jMnuxDpeLQhKgkpKQOlnqChJgyRd;

			private readonly ControllerTemplateElementType JNNGbJEWijctWBKzGmlLLQzaVVsi;

			protected readonly int SsPwhbdijXONOlkRKHOkXryZrDq;

			public int id
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						while (true)
						{
							int num = 1751023320;
							while (true)
							{
								switch (num ^ 0x685E7ED9)
								{
								case 2:
									break;
								case 1:
									goto IL_002b;
								default:
									return -1;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = 1751023321;
							}
						}
					}
					return KAixZgRycuVSHIYaEVNGzKGIdgV;
				}
			}

			public string descriptiveName
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return jMnuxDpeLQhKgkpKQOlnqChJgyRd;
				}
			}

			public ControllerTemplateElementType type
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						while (true)
						{
							int num = -1690826214;
							while (true)
							{
								switch (num ^ -1690826213)
								{
								case 0:
									break;
								case 1:
									goto IL_002b;
								default:
									return ControllerTemplateElementType.Axis;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = -1690826215;
							}
						}
					}
					return JNNGbJEWijctWBKzGmlLLQzaVVsi;
				}
			}

			public IControllerTemplate parent
			{
				get
				{
					return eOotmcFksuDgVSpJBCGwMaaBooj;
				}
			}

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected jUsmBPPozsChspVdxyHFfIWHsmS(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType)
			{
				if (parent == null)
				{
					throw new ArgumentNullException("parent");
				}
				eOotmcFksuDgVSpJBCGwMaaBooj = parent;
				KAixZgRycuVSHIYaEVNGzKGIdgV = id;
				jMnuxDpeLQhKgkpKQOlnqChJgyRd = name;
				JNNGbJEWijctWBKzGmlLLQzaVVsi = elementType;
				SsPwhbdijXONOlkRKHOkXryZrDq = ReInput.id;
			}

			public abstract IControllerTemplateElement GetElement(int P_0);

			public abstract int GetElementTargets(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1);
		}

		internal abstract class bnBNaKZvFWiDrAvPgArJJThjGcj : jUsmBPPozsChspVdxyHFfIWHsmS
		{
			protected readonly int skBoeyIaaTXZEzoBHoFjzeIRmdF;

			protected readonly ULSEvpcHTnGvtDkHVJzkROEKmtR[] sJWlrpzdPUfMxhSzTHLTRCYPPlsy;

			public override bool exists
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						goto IL_0010;
					}
					if (sJWlrpzdPUfMxhSzTHLTRCYPPlsy == null)
					{
						return false;
					}
					int num = 0;
					int num2 = 2085411475;
					goto IL_0015;
					IL_0010:
					num2 = 2085411476;
					goto IL_0015;
					IL_0015:
					while (true)
					{
						switch (num2 ^ 0x7C4CDA95)
						{
						case 3:
							break;
						case 0:
							if (sJWlrpzdPUfMxhSzTHLTRCYPPlsy[num].KspObDEVwZbsUrQZILSLveBSzec != null)
							{
								num2 = 2085411473;
								continue;
							}
							num++;
							num2 = 2085411474;
							continue;
						case 6:
							num2 = 2085411474;
							continue;
						case 7:
						{
							int num3;
							if (num >= sJWlrpzdPUfMxhSzTHLTRCYPPlsy.Length)
							{
								num2 = 2085411472;
								num3 = num2;
							}
							else
							{
								num2 = 2085411477;
								num3 = num2;
							}
							continue;
						}
						case 1:
							ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
							num2 = 2085411479;
							continue;
						case 4:
							return true;
						case 2:
							return false;
						default:
							return false;
						}
						break;
					}
					goto IL_0010;
				}
			}

			protected bnBNaKZvFWiDrAvPgArJJThjGcj(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, IList<ULSEvpcHTnGvtDkHVJzkROEKmtR> sourceElements)
				: base(parent, id, name, elementType)
			{
				sJWlrpzdPUfMxhSzTHLTRCYPPlsy = ((sourceElements != null) ? ListTools.ToArray(sourceElements) : null);
				skBoeyIaaTXZEzoBHoFjzeIRmdF = ((sJWlrpzdPUfMxhSzTHLTRCYPPlsy != null) ? sJWlrpzdPUfMxhSzTHLTRCYPPlsy.Length : 0);
			}
		}

		internal abstract class vzNbVOYjzSTFdZWvXmdGFqlulCJ : bnBNaKZvFWiDrAvPgArJJThjGcj, IControllerTemplateElement, IControllerTemplateAxis, IControllerTemplateButton
		{
			private ZsogrZyhQfaSnqVtBlGOmbxOuQc EaBgueQMzRKPoEnRrsktTmWKrOG;

			private string kuzUrgofQWCvILjzvFFtSUGwMTB;

			private string kRbwbYXUiVasProQoiiUDJFmRuG;

			public float floatValue
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						goto IL_0019;
					}
					if (skBoeyIaaTXZEzoBHoFjzeIRmdF == 1)
					{
						return sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].floatValue;
					}
					int num;
					if (skBoeyIaaTXZEzoBHoFjzeIRmdF == 2)
					{
						num = -1848169992;
						goto IL_001e;
					}
					return 0f;
					IL_0019:
					num = -1848169989;
					goto IL_001e;
					IL_001e:
					float num2 = default(float);
					float num3 = default(float);
					while (true)
					{
						switch (num ^ -1848169991)
						{
						case 3:
							break;
						case 2:
							return 0f;
						case 1:
							goto IL_0068;
						default:
							return MathTools.Clamp(num2 + num3, -1f, 1f);
						}
						break;
						IL_0068:
						num2 = sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].floatValue;
						num3 = sJWlrpzdPUfMxhSzTHLTRCYPPlsy[1].floatValue;
						num = -1848169991;
					}
					goto IL_0019;
				}
			}

			public float floatValuePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					if (skBoeyIaaTXZEzoBHoFjzeIRmdF == 1)
					{
						return sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].floatValuePrev;
					}
					if (skBoeyIaaTXZEzoBHoFjzeIRmdF == 2)
					{
						float num = sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].floatValuePrev;
						float num2 = sJWlrpzdPUfMxhSzTHLTRCYPPlsy[1].floatValuePrev;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool boolValue
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					if (skBoeyIaaTXZEzoBHoFjzeIRmdF == 1)
					{
						return sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].boolValue;
					}
					if (skBoeyIaaTXZEzoBHoFjzeIRmdF == 2)
					{
						if (!sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].boolValue)
						{
							return sJWlrpzdPUfMxhSzTHLTRCYPPlsy[1].boolValue;
						}
						return true;
					}
					return false;
				}
			}

			public bool boolValuePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					if (skBoeyIaaTXZEzoBHoFjzeIRmdF == 1)
					{
						return sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].boolValuePrev;
					}
					if (skBoeyIaaTXZEzoBHoFjzeIRmdF == 2)
					{
						if (!sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].boolValuePrev)
						{
							return sJWlrpzdPUfMxhSzTHLTRCYPPlsy[1].boolValuePrev;
						}
						return true;
					}
					return false;
				}
			}

			string IControllerTemplateAxis.positiveDescriptiveName
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return kuzUrgofQWCvILjzvFFtSUGwMTB;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return kRbwbYXUiVasProQoiiUDJFmRuG;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return floatValue;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return floatValuePrev;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return EaBgueQMzRKPoEnRrsktTmWKrOG;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					return boolValue;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					return boolValuePrev;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						goto IL_0019;
					}
					int num;
					if (skBoeyIaaTXZEzoBHoFjzeIRmdF == 1)
					{
						num = 1423265578;
					}
					else
					{
						if (skBoeyIaaTXZEzoBHoFjzeIRmdF != 2)
						{
							return false;
						}
						if (!sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].justPressed)
						{
							goto IL_0089;
						}
						if (!sJWlrpzdPUfMxhSzTHLTRCYPPlsy[1].boolValuePrev)
						{
							return true;
						}
						num = 1423265577;
					}
					goto IL_001e;
					IL_0019:
					num = 1423265579;
					goto IL_001e;
					IL_001e:
					switch (num ^ 0x54D54F2A)
					{
					case 2:
						break;
					case 1:
						return false;
					case 0:
						return sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].justPressed;
					default:
						goto IL_0089;
					}
					goto IL_0019;
					IL_0089:
					if (sJWlrpzdPUfMxhSzTHLTRCYPPlsy[1].justPressed)
					{
						return !sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].boolValuePrev;
					}
					return false;
				}
			}

			bool IControllerTemplateButton.justReleased
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					if (skBoeyIaaTXZEzoBHoFjzeIRmdF == 1)
					{
						goto IL_0024;
					}
					int num;
					if (skBoeyIaaTXZEzoBHoFjzeIRmdF == 2)
					{
						int num2;
						if (!sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].justReleased)
						{
							num = 1985336323;
							num2 = num;
						}
						else
						{
							num = 1985336320;
							num2 = num;
						}
						goto IL_0029;
					}
					return false;
					IL_0029:
					while (true)
					{
						switch (num ^ 0x7655D403)
						{
						case 2:
							break;
						case 1:
							return sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].justReleased;
						case 3:
							if (sJWlrpzdPUfMxhSzTHLTRCYPPlsy[1].boolValue)
							{
								num = 1985336323;
								continue;
							}
							return true;
						case 0:
							if (sJWlrpzdPUfMxhSzTHLTRCYPPlsy[1].justReleased)
							{
								num = 1985336327;
								continue;
							}
							return false;
						default:
							return !sJWlrpzdPUfMxhSzTHLTRCYPPlsy[0].boolValue;
						}
						break;
					}
					goto IL_0024;
					IL_0024:
					num = 1985336322;
					goto IL_0029;
				}
			}

			bool IControllerTemplateButton.justChangedState
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					return boolValue != boolValuePrev;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return floatValue;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						while (true)
						{
							int num = 221430313;
							while (true)
							{
								switch (num ^ 0xD32C22B)
								{
								case 0:
									break;
								case 2:
									goto IL_002b;
								default:
									return 0f;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = 221430314;
							}
						}
					}
					return floatValuePrev;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return EaBgueQMzRKPoEnRrsktTmWKrOG;
				}
			}

			public override IControllerTemplateElementSource source
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return EaBgueQMzRKPoEnRrsktTmWKrOG;
				}
			}

			public override int elementCount
			{
				get
				{
					return 0;
				}
			}

			public IControllerTemplateAxis AsAxis
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return this;
				}
			}

			public IControllerTemplateButton AsButton
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return this;
				}
			}

			protected vzNbVOYjzSTFdZWvXmdGFqlulCJ(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, ControllerTemplateElementType elementType, ZsogrZyhQfaSnqVtBlGOmbxOuQc target, IList<ULSEvpcHTnGvtDkHVJzkROEKmtR> sourceElements)
				: base(parent, id, name, elementType, sourceElements)
			{
				while (true)
				{
					int num = -1915062555;
					while (true)
					{
						switch (num ^ -1915062556)
						{
						case 2:
							break;
						case 1:
							if (sourceElements != null)
							{
								int num2;
								if (sourceElements.Count <= 2)
								{
									num = -1915062556;
									num2 = num;
								}
								else
								{
									num = -1915062553;
									num2 = num;
								}
								continue;
							}
							goto case 0;
						case 3:
							throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
						case 0:
							if (target == null)
							{
								throw new ArgumentNullException("target");
							}
							goto default;
						default:
							EaBgueQMzRKPoEnRrsktTmWKrOG = target;
							kuzUrgofQWCvILjzvFFtSUGwMTB = positiveName;
							kRbwbYXUiVasProQoiiUDJFmRuG = negativeName;
							return;
						}
						break;
					}
				}
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange P_0)
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						int num = -1163090302;
						while (true)
						{
							switch (num ^ -1163090301)
							{
							case 3:
								break;
							case 1:
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = -1163090303;
								continue;
							case 2:
								return null;
							default:
								goto end_IL_000d;
							}
							break;
						}
						continue;
						end_IL_000d:
						break;
					}
				}
				else
				{
					switch (P_0)
					{
					case AxisRange.Full:
						break;
					case AxisRange.Positive:
						return kuzUrgofQWCvILjzvFFtSUGwMTB;
					case AxisRange.Negative:
						return kRbwbYXUiVasProQoiiUDJFmRuG;
					default:
						throw new NotImplementedException();
					}
				}
				return base.descriptiveName;
			}

			public override IControllerTemplateElement GetElement(int P_0)
			{
				return null;
			}

			public override int GetElementTargets(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				if (P_0.elementIdentifierId < 0)
				{
					goto IL_000d;
				}
				int num = 0;
				int num2 = -1931367573;
				goto IL_0012;
				IL_0012:
				IControllerTemplateAxisSource eaBgueQMzRKPoEnRrsktTmWKrOG = default(IControllerTemplateAxisSource);
				while (true)
				{
					int num3;
					switch (num2 ^ -1931367570)
					{
					case 12:
						break;
					case 3:
						if (VsuNrbrTZUnpNOyjiCIyeFJioEA(P_0, eaBgueQMzRKPoEnRrsktTmWKrOG.fullTarget))
						{
							ListTools.AddAndCreateList(ref P_1, new ControllerTemplateElementTarget(this, P_0.axisRange));
							num++;
							num2 = -1931367574;
							continue;
						}
						goto default;
					case 9:
					{
						int num4;
						if (VsuNrbrTZUnpNOyjiCIyeFJioEA(P_0, eaBgueQMzRKPoEnRrsktTmWKrOG.positiveTarget))
						{
							num2 = -1931367572;
							num4 = num2;
						}
						else
						{
							num2 = -1931367580;
							num4 = num2;
						}
						continue;
					}
					case 13:
					{
						int num5;
						if (!VsuNrbrTZUnpNOyjiCIyeFJioEA(P_0, ((IControllerTemplateButtonSource)EaBgueQMzRKPoEnRrsktTmWKrOG).target))
						{
							num2 = -1931367574;
							num5 = num2;
						}
						else
						{
							num2 = -1931367569;
							num5 = num2;
						}
						continue;
					}
					case 2:
						ListTools.AddAndCreateList(ref P_1, new ControllerTemplateElementTarget(this, AxisRange.Positive));
						num2 = -1931367570;
						continue;
					case 0:
						num++;
						num2 = -1931367580;
						continue;
					case 8:
						return 0;
					case 11:
						num2 = -1931367575;
						continue;
					case 7:
						throw new NotImplementedException();
					case 1:
						ListTools.AddAndCreateList(ref P_1, new ControllerTemplateElementTarget(this, AxisRange.Full));
						num++;
						num2 = -1931367574;
						continue;
					case 5:
						switch (base.type)
						{
						case ControllerTemplateElementType.Button:
							break;
						default:
							goto IL_0152;
						case ControllerTemplateElementType.Axis:
							goto IL_015c;
						}
						goto case 13;
					case 6:
						goto IL_015c;
					case 10:
						if (VsuNrbrTZUnpNOyjiCIyeFJioEA(P_0, eaBgueQMzRKPoEnRrsktTmWKrOG.negativeTarget))
						{
							ListTools.AddAndCreateList(ref P_1, new ControllerTemplateElementTarget(this, AxisRange.Negative));
							num++;
							num2 = -1931367574;
							continue;
						}
						goto default;
					default:
						{
							return num;
						}
						IL_015c:
						eaBgueQMzRKPoEnRrsktTmWKrOG = EaBgueQMzRKPoEnRrsktTmWKrOG;
						if (eaBgueQMzRKPoEnRrsktTmWKrOG.splitAxis)
						{
							num2 = -1931367577;
							num3 = num2;
						}
						else
						{
							num2 = -1931367571;
							num3 = num2;
						}
						continue;
						IL_0152:
						num2 = -1931367579;
						continue;
					}
					break;
				}
				goto IL_000d;
				IL_000d:
				num2 = -1931367578;
				goto IL_0012;
			}

			private static bool VsuNrbrTZUnpNOyjiCIyeFJioEA(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				if (P_1.elementIdentifierId != P_0.elementIdentifierId)
				{
					goto IL_000f;
				}
				ControllerElementType elementType = P_1.elementType;
				ControllerElementType controllerElementType = elementType;
				int num = -790026049;
				goto IL_0014;
				IL_0014:
				while (true)
				{
					switch (num ^ -790026050)
					{
					case 0:
						break;
					case 3:
					{
						AxisRange axisRange = P_1.axisRange;
						if (axisRange == AxisRange.Full)
						{
							goto IL_003f;
						}
						if (axisRange == P_0.axisRange)
						{
							return true;
						}
						return false;
					}
					case 1:
						switch (controllerElementType)
						{
						case ControllerElementType.Axis:
							break;
						case ControllerElementType.Button:
							return true;
						default:
							throw new NotImplementedException();
						}
						goto case 3;
					case 2:
						return false;
					default:
						return true;
					}
					break;
					IL_003f:
					num = -790026054;
				}
				goto IL_000f;
				IL_000f:
				num = -790026052;
				goto IL_0014;
			}
		}

		internal sealed class SbDQhfjcUkLRdbEKaBbJAiEhPZAh : vzNbVOYjzSTFdZWvXmdGFqlulCJ
		{
			public SbDQhfjcUkLRdbEKaBbJAiEhPZAh(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, ZsogrZyhQfaSnqVtBlGOmbxOuQc target, IList<ULSEvpcHTnGvtDkHVJzkROEKmtR> sourceElements)
				: base(parent, id, name, positiveName, negativeName, ControllerTemplateElementType.Axis, target, sourceElements)
			{
				while (true)
				{
					switch (0x4063D3A7 ^ 0x4063D3A6)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						if (sourceElements != null && sourceElements.Count > 2)
						{
							throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
						}
						return;
					case 0:
						return;
					}
				}
			}

			internal static SbDQhfjcUkLRdbEKaBbJAiEhPZAh dawcjtsNOciSWAmaKVxbSHSsCoQM(IControllerTemplate P_0)
			{
				return new SbDQhfjcUkLRdbEKaBbJAiEhPZAh(P_0, -1, string.Empty, string.Empty, string.Empty, ZsogrZyhQfaSnqVtBlGOmbxOuQc.dawcjtsNOciSWAmaKVxbSHSsCoQM(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class jxzVsgyangpawyDAbWrtTzUsjeL : vzNbVOYjzSTFdZWvXmdGFqlulCJ
		{
			public jxzVsgyangpawyDAbWrtTzUsjeL(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, ZsogrZyhQfaSnqVtBlGOmbxOuQc target, IList<ULSEvpcHTnGvtDkHVJzkROEKmtR> sourceElements)
				: base(parent, id, name, positiveName, negativeName, ControllerTemplateElementType.Button, target, sourceElements)
			{
				if (sourceElements != null && sourceElements.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static jxzVsgyangpawyDAbWrtTzUsjeL dawcjtsNOciSWAmaKVxbSHSsCoQM(IControllerTemplate P_0)
			{
				return new jxzVsgyangpawyDAbWrtTzUsjeL(P_0, -1, string.Empty, string.Empty, string.Empty, ZsogrZyhQfaSnqVtBlGOmbxOuQc.dawcjtsNOciSWAmaKVxbSHSsCoQM(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class FnxEmpKFgNHwheAKhAYmjCSsubJ : jUsmBPPozsChspVdxyHFfIWHsmS
		{
			protected readonly int xhRrSOnlgQeoHZxBkNsViMILhJHe;

			protected readonly jUsmBPPozsChspVdxyHFfIWHsmS[] zGVdLCAPoSECGnwSmQQzpAttLxeB;

			public override bool exists
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return false;
					}
					int num = 0;
					while (num < xhRrSOnlgQeoHZxBkNsViMILhJHe)
					{
						while (true)
						{
							if (zGVdLCAPoSECGnwSmQQzpAttLxeB[num].exists)
							{
								return true;
							}
							num++;
							int num2 = 1176323055;
							while (true)
							{
								switch (num2 ^ 0x461D43EF)
								{
								case 2:
									num2 = 1176323054;
									continue;
								case 1:
									break;
								default:
									goto end_IL_003d;
								}
								break;
							}
							continue;
							end_IL_003d:
							break;
						}
					}
					return false;
				}
			}

			public override IControllerTemplateElementSource source
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return null;
				}
			}

			public override int elementCount
			{
				get
				{
					return xhRrSOnlgQeoHZxBkNsViMILhJHe;
				}
			}

			protected FnxEmpKFgNHwheAKhAYmjCSsubJ(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, jUsmBPPozsChspVdxyHFfIWHsmS[] elements)
				: base(parent, id, name, elementType)
			{
				if (elements == null)
				{
					throw new ArgumentNullException("elements");
				}
				if (elements.Length == 0)
				{
					throw new ArgumentException("elements.Length is zero.");
				}
				for (int i = 0; i < elements.Length; i++)
				{
					if (elements[i] == null)
					{
						throw new ArgumentNullException("elements contains a null entry.");
					}
				}
				zGVdLCAPoSECGnwSmQQzpAttLxeB = elements;
				xhRrSOnlgQeoHZxBkNsViMILhJHe = elements.Length;
			}

			public override IControllerTemplateElement GetElement(int P_0)
			{
				return zGVdLCAPoSECGnwSmQQzpAttLxeB[P_0];
			}

			public override int GetElementTargets(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				int num2 = 0;
				while (num2 < zGVdLCAPoSECGnwSmQQzpAttLxeB.Length)
				{
					while (true)
					{
						num += zGVdLCAPoSECGnwSmQQzpAttLxeB[num2].GetElementTargets(P_0, ref P_1);
						int num3 = 1523478652;
						while (true)
						{
							switch (num3 ^ 0x5ACE707C)
							{
							case 2:
								num3 = 1523478653;
								continue;
							case 1:
								break;
							case 0:
								num2++;
								num3 = 1523478655;
								continue;
							default:
								goto end_IL_0028;
							}
							break;
						}
						continue;
						end_IL_0028:
						break;
					}
				}
				return num;
			}
		}

		internal abstract class nqUkqHNWpmCWUKwMDICmZdGFhkt : FnxEmpKFgNHwheAKhAYmjCSsubJ, IControllerTemplateElement, IControllerTemplateAxis2D
		{
			protected const int PyyroJUVCuozneUenJKHTHhiUbm = 0;

			protected const int sRrykBTKEHmAyCpWcJUrzpgUGnI = 1;

			protected const int XzKfnkkbypotcpvEsjiEIoMKBybj = 2;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector2.zero;
					}
					return new Vector2((xhRrSOnlgQeoHZxBkNsViMILhJHe > 0) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[0]).floatValue : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 1) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[1]).floatValue : 0f);
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector2.zero;
					}
					return new Vector2((xhRrSOnlgQeoHZxBkNsViMILhJHe > 0) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[0]).floatValuePrev : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 1) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[1]).floatValuePrev : 0f);
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[1];
				}
			}

			protected nqUkqHNWpmCWUKwMDICmZdGFhkt(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, jUsmBPPozsChspVdxyHFfIWHsmS[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal abstract class nMOOdmjcfYsVxnNrFSHDJOaKsUA : FnxEmpKFgNHwheAKhAYmjCSsubJ, IControllerTemplateElement, IControllerTemplateAxis3D
		{
			protected const int PyyroJUVCuozneUenJKHTHhiUbm = 0;

			protected const int sRrykBTKEHmAyCpWcJUrzpgUGnI = 1;

			protected const int yLEdNKIfeeqaJGPunREkCrEdDQUv = 2;

			protected const int XzKfnkkbypotcpvEsjiEIoMKBybj = 3;

			public Vector3 value
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						goto IL_000d;
					}
					int num;
					if (xhRrSOnlgQeoHZxBkNsViMILhJHe <= 0)
					{
						num = 1738736326;
						goto IL_0012;
					}
					float x = ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[0]).floatValue;
					goto IL_0066;
					IL_0012:
					switch (num ^ 0x67A302C7)
					{
					case 0:
						break;
					case 2:
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector3.zero;
					default:
						goto IL_004d;
					}
					goto IL_000d;
					IL_004d:
					x = 0f;
					goto IL_0066;
					IL_0066:
					return new Vector3(x, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 1) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[1]).floatValue : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 2) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[2]).floatValue : 0f);
					IL_000d:
					num = 1738736325;
					goto IL_0012;
				}
			}

			public Vector3 valuePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector3.zero;
					}
					return new Vector3((xhRrSOnlgQeoHZxBkNsViMILhJHe > 0) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[0]).floatValuePrev : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 1) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[1]).floatValuePrev : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 2) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[2]).floatValuePrev : 0f);
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[1];
				}
			}

			public IControllerTemplateAxis depth
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[2];
				}
			}

			protected nMOOdmjcfYsVxnNrFSHDJOaKsUA(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, jUsmBPPozsChspVdxyHFfIWHsmS[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal abstract class LimwuYfosNQnoefmqsyHEvwDVE : FnxEmpKFgNHwheAKhAYmjCSsubJ, IControllerTemplateElement, IControllerTemplateAxis6D
		{
			protected const int vsSPYaSEVNThjGGVYncPEvtNfCS = 0;

			protected const int ikVVaIlrotaIkhFIqZaRTYQcjCL = 1;

			protected const int XonBZyvMseifGCvUkJiEFetlkCy = 2;

			protected const int eYxyGZHxqDIXyIZljalZLsYdeUU = 3;

			protected const int DWYfJFUAqkBmFmChpAhlvjhuIwJa = 4;

			protected const int LZvRyadspGxBDBQGjdrQtJZvsQW = 5;

			protected const int XzKfnkkbypotcpvEsjiEIoMKBybj = 6;

			public Vector3 position
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector3.zero;
					}
					return new Vector3((xhRrSOnlgQeoHZxBkNsViMILhJHe > 0) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[0]).floatValue : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 1) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[1]).floatValue : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 2) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[2]).floatValue : 0f);
				}
			}

			public Vector3 positionPrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector3.zero;
					}
					return new Vector3((xhRrSOnlgQeoHZxBkNsViMILhJHe > 0) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[0]).floatValuePrev : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 1) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[1]).floatValuePrev : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 2) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[2]).floatValuePrev : 0f);
				}
			}

			public Vector3 rotation
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector3.zero;
					}
					return new Vector3((xhRrSOnlgQeoHZxBkNsViMILhJHe > 3) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[3]).floatValue : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 4) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[4]).floatValue : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 5) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[5]).floatValue : 0f);
				}
			}

			public Vector3 rotationPrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector3.zero;
					}
					return new Vector3((xhRrSOnlgQeoHZxBkNsViMILhJHe > 3) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[3]).floatValuePrev : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 4) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[4]).floatValuePrev : 0f, (xhRrSOnlgQeoHZxBkNsViMILhJHe > 5) ? ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[5]).floatValuePrev : 0f);
				}
			}

			public IControllerTemplateAxis positionX
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[0];
				}
			}

			public IControllerTemplateAxis positionY
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[1];
				}
			}

			public IControllerTemplateAxis positionZ
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						while (true)
						{
							int num = 1078409224;
							while (true)
							{
								switch (num ^ 0x40473809)
								{
								case 2:
									break;
								case 1:
									goto IL_002b;
								default:
									return null;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = 1078409225;
							}
						}
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[2];
				}
			}

			public IControllerTemplateAxis rotationX
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[3];
				}
			}

			public IControllerTemplateAxis rotationY
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[4];
				}
			}

			public IControllerTemplateAxis rotationZ
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						while (true)
						{
							int num = -2001891178;
							while (true)
							{
								switch (num ^ -2001891180)
								{
								case 0:
									break;
								case 2:
									goto IL_002b;
								default:
									return null;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = -2001891179;
							}
						}
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[5];
				}
			}

			protected LimwuYfosNQnoefmqsyHEvwDVE(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, jUsmBPPozsChspVdxyHFfIWHsmS[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal sealed class TVyjXqKMFYOAvVqUUBPuexGpryN : nMOOdmjcfYsVxnNrFSHDJOaKsUA, IControllerTemplateElement, IControllerTemplateStick
		{
			private new const int XzKfnkkbypotcpvEsjiEIoMKBybj = 3;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[2];
				}
			}

			private TVyjXqKMFYOAvVqUUBPuexGpryN(IControllerTemplate parent, int id, string name, jUsmBPPozsChspVdxyHFfIWHsmS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Stick, elements)
			{
				while (true)
				{
					int num = 426071185;
					while (true)
					{
						switch (num ^ 0x19655490)
						{
						case 0:
							break;
						default:
							return;
						case 1:
						{
							int num2;
							if (elements.Length == 3)
							{
								num = 426071186;
								num2 = num;
							}
							else
							{
								num = 426071187;
								num2 = num;
							}
							continue;
						}
						case 3:
							throw new ArgumentException("elements.Length must be " + 3);
						case 2:
							return;
						}
						break;
					}
				}
			}

			public TVyjXqKMFYOAvVqUUBPuexGpryN(IControllerTemplate parent, int id, string name, vzNbVOYjzSTFdZWvXmdGFqlulCJ xAxis, vzNbVOYjzSTFdZWvXmdGFqlulCJ yAxis, vzNbVOYjzSTFdZWvXmdGFqlulCJ zAxis)
				: this(parent, id, name, new jUsmBPPozsChspVdxyHFfIWHsmS[3] { xAxis, yAxis, zAxis })
			{
			}
		}

		internal sealed class WgZuUjisadsATapPzkufnlqelZs : nqUkqHNWpmCWUKwMDICmZdGFhkt, IControllerTemplateElement, IControllerTemplateThumbStick
		{
			private const int XUHKTJLAXOBhHIHSZBwrrNrcdzc = 2;

			private new const int XzKfnkkbypotcpvEsjiEIoMKBybj = 3;

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						while (true)
						{
							int num = -346204963;
							while (true)
							{
								switch (num ^ -346204964)
								{
								case 0:
									break;
								case 1:
									goto IL_002b;
								default:
									return null;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = -346204962;
							}
						}
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[2];
				}
			}

			private WgZuUjisadsATapPzkufnlqelZs(IControllerTemplate parent, int id, string name, jUsmBPPozsChspVdxyHFfIWHsmS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.ThumbStick, elements)
			{
				if (elements.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal WgZuUjisadsATapPzkufnlqelZs(IControllerTemplate parent, int id, string name, vzNbVOYjzSTFdZWvXmdGFqlulCJ xAxis, vzNbVOYjzSTFdZWvXmdGFqlulCJ yAxis, vzNbVOYjzSTFdZWvXmdGFqlulCJ button)
				: this(parent, id, name, new jUsmBPPozsChspVdxyHFfIWHsmS[3] { xAxis, yAxis, button })
			{
			}
		}

		internal sealed class sPsshTZbXexFegNMFFUosefJZRc : FnxEmpKFgNHwheAKhAYmjCSsubJ, IControllerTemplateElement, IControllerTemplateDPad
		{
			private const int HDPAQYkfwIYRTZpYRfWRQecacZMe = 0;

			private const int IsBXdMOWOfsuHJIfvYYFLFsEoMj = 1;

			private const int iOPPmjuDdcqaCNKAjGqNAZLxAfI = 2;

			private const int EWdZTZjoQevzUZYSxmAvygOhhzm = 3;

			private const int qiCbBMpmesSGMRQhiBKGHiIfnpm = 4;

			private const int XzKfnkkbypotcpvEsjiEIoMKBybj = 5;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[0]).floatValue + ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[2]).floatValue * -1f, -1f, 1f), MathTools.Clamp(((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[3]).floatValue * -1f + ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[1]).floatValue, -1f, 1f));
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[0]).floatValuePrev + ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[2]).floatValuePrev * -1f, -1f, 1f), MathTools.Clamp(((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[3]).floatValuePrev * -1f + ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[1]).floatValuePrev, -1f, 1f));
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[0];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[1];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[2];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[3];
				}
			}

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[4];
				}
			}

			private sPsshTZbXexFegNMFFUosefJZRc(IControllerTemplate parent, int id, string name, jUsmBPPozsChspVdxyHFfIWHsmS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.DPad, elements)
			{
				while (true)
				{
					switch (-1176609711 ^ -1176609712)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						if (elements.Length != 5)
						{
							throw new ArgumentException("elements.Length must be " + 5);
						}
						return;
					case 0:
						return;
					}
				}
			}

			internal sPsshTZbXexFegNMFFUosefJZRc(IControllerTemplate parent, int id, string name, vzNbVOYjzSTFdZWvXmdGFqlulCJ up, vzNbVOYjzSTFdZWvXmdGFqlulCJ right, vzNbVOYjzSTFdZWvXmdGFqlulCJ down, vzNbVOYjzSTFdZWvXmdGFqlulCJ left, vzNbVOYjzSTFdZWvXmdGFqlulCJ press)
				: this(parent, id, name, new jUsmBPPozsChspVdxyHFfIWHsmS[5] { up, right, down, left, press })
			{
			}
		}

		internal sealed class vNGOdfUlxuAANGGenYhffdsLwcY : FnxEmpKFgNHwheAKhAYmjCSsubJ, IControllerTemplateElement, IControllerTemplateThrottle
		{
			private const int aetyvTWhWkBAIsUZVDPvYcTUeQq = 0;

			private const int hWKAQAKezgveoWXNlKfgOaIVDtk = 1;

			private const int XzKfnkkbypotcpvEsjiEIoMKBybj = 2;

			public float value
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[0]).floatValue;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return 0f;
					}
					return ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[0]).floatValuePrev;
				}
			}

			public IControllerTemplateAxis throttle
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[0];
				}
			}

			public IControllerTemplateButton minDetent
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[1];
				}
			}

			private vNGOdfUlxuAANGGenYhffdsLwcY(IControllerTemplate parent, int id, string name, jUsmBPPozsChspVdxyHFfIWHsmS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Throttle, elements)
			{
				while (true)
				{
					switch (-1547079767 ^ -1547079768)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						if (elements.Length != 2)
						{
							throw new ArgumentException("elements.Length must be " + 2);
						}
						return;
					case 2:
						return;
					}
				}
			}

			internal vNGOdfUlxuAANGGenYhffdsLwcY(IControllerTemplate parent, int id, string name, vzNbVOYjzSTFdZWvXmdGFqlulCJ axis, vzNbVOYjzSTFdZWvXmdGFqlulCJ zeroDetentButton)
				: this(parent, id, name, new jUsmBPPozsChspVdxyHFfIWHsmS[2] { axis, zeroDetentButton })
			{
			}
		}

		internal sealed class GUwxzxbXfOiFOfJUuGCKTEeAYAy : FnxEmpKFgNHwheAKhAYmjCSsubJ, IControllerTemplateElement, IControllerTemplateHat
		{
			private const int HDPAQYkfwIYRTZpYRfWRQecacZMe = 0;

			private const int dsriunuedivhwVrIPPvRuoYqeNL = 1;

			private const int IsBXdMOWOfsuHJIfvYYFLFsEoMj = 2;

			private const int QvjGBIbeCuKjboLQqnMyEuxKjbY = 3;

			private const int iOPPmjuDdcqaCNKAjGqNAZLxAfI = 4;

			private const int SWvFTSxndEdapYoZnHhaIiINKRU = 5;

			private const int EWdZTZjoQevzUZYSxmAvygOhhzm = 6;

			private const int lqKzQqfbTXHKebLkhWOAHDBjEqWH = 7;

			private const int XzKfnkkbypotcpvEsjiEIoMKBybj = 8;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[0]).floatValue;
					result.x += ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[2]).floatValue;
					float floatValue = default(float);
					float floatValue4 = default(float);
					float floatValue2 = default(float);
					float floatValue3 = default(float);
					while (true)
					{
						int num = 1216909713;
						while (true)
						{
							switch (num ^ 0x48889194)
							{
							case 0:
								break;
							case 1:
								result.y += floatValue + floatValue4 - floatValue2 - floatValue3;
								num = 1216909719;
								continue;
							case 4:
								floatValue3 = ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[5]).floatValue;
								floatValue4 = ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[7]).floatValue;
								result.x += floatValue + floatValue2 - floatValue3 - floatValue4;
								num = 1216909717;
								continue;
							case 2:
								floatValue = ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[1]).floatValue;
								floatValue2 = ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[3]).floatValue;
								num = 1216909712;
								continue;
							case 5:
								result.y -= ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[4]).floatValue;
								result.x -= ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[6]).floatValue;
								num = 1216909718;
								continue;
							default:
								result.x = MathTools.Clamp(result.x, -1f, 1f);
								result.y = MathTools.Clamp(result.y, -1f, 1f);
								return result;
							}
							break;
						}
					}
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						goto IL_0019;
					}
					Vector2 result = default(Vector2);
					result.y += ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[0]).floatValuePrev;
					result.x += ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[2]).floatValuePrev;
					int num = -2063821317;
					goto IL_001e;
					IL_001e:
					switch (num ^ -2063821317)
					{
					case 2:
						break;
					case 1:
						return Vector2.zero;
					default:
					{
						result.y -= ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[4]).floatValuePrev;
						result.x -= ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[6]).floatValuePrev;
						float floatValuePrev = ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[1]).floatValuePrev;
						float floatValuePrev2 = ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[3]).floatValuePrev;
						float floatValuePrev3 = ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[5]).floatValuePrev;
						float floatValuePrev4 = ((vzNbVOYjzSTFdZWvXmdGFqlulCJ)zGVdLCAPoSECGnwSmQQzpAttLxeB[7]).floatValuePrev;
						result.x += floatValuePrev + floatValuePrev2 - floatValuePrev3 - floatValuePrev4;
						result.y += floatValuePrev + floatValuePrev4 - floatValuePrev2 - floatValuePrev3;
						result.x = MathTools.Clamp(result.x, -1f, 1f);
						result.y = MathTools.Clamp(result.y, -1f, 1f);
						return result;
					}
					}
					goto IL_0019;
					IL_0019:
					num = -2063821318;
					goto IL_001e;
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[0];
				}
			}

			public IControllerTemplateButton upRight
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[1];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[2];
				}
			}

			public IControllerTemplateButton downRight
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[3];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						while (true)
						{
							int num = 517870363;
							while (true)
							{
								switch (num ^ 0x1EDE131A)
								{
								case 2:
									break;
								case 1:
									goto IL_002b;
								default:
									return null;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
								num = 517870362;
							}
						}
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[4];
				}
			}

			public IControllerTemplateButton downLeft
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[5];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[6];
				}
			}

			public IControllerTemplateButton upLeft
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateButton)zGVdLCAPoSECGnwSmQQzpAttLxeB[7];
				}
			}

			private GUwxzxbXfOiFOfJUuGCKTEeAYAy(IControllerTemplate parent, int id, string name, jUsmBPPozsChspVdxyHFfIWHsmS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Hat, elements)
			{
				if (elements.Length != 8)
				{
					throw new ArgumentException("elements.Length must be " + 8);
				}
			}

			internal GUwxzxbXfOiFOfJUuGCKTEeAYAy(IControllerTemplate parent, int id, string name, vzNbVOYjzSTFdZWvXmdGFqlulCJ up, vzNbVOYjzSTFdZWvXmdGFqlulCJ upRight, vzNbVOYjzSTFdZWvXmdGFqlulCJ right, vzNbVOYjzSTFdZWvXmdGFqlulCJ downRight, vzNbVOYjzSTFdZWvXmdGFqlulCJ down, vzNbVOYjzSTFdZWvXmdGFqlulCJ downLeft, vzNbVOYjzSTFdZWvXmdGFqlulCJ left, vzNbVOYjzSTFdZWvXmdGFqlulCJ upLeft)
				: this(parent, id, name, new jUsmBPPozsChspVdxyHFfIWHsmS[8] { up, upRight, right, downRight, down, downLeft, left, upLeft })
			{
			}
		}

		internal sealed class MBjuFCdNYLMtPHOUZfQEbhzGcAH : nqUkqHNWpmCWUKwMDICmZdGFhkt, IControllerTemplateElement, IControllerTemplateYoke
		{
			private new const int XzKfnkkbypotcpvEsjiEIoMKBybj = 2;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[0];
				}
			}

			public IControllerTemplateAxis pushPull
			{
				get
				{
					if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						return null;
					}
					return (IControllerTemplateAxis)zGVdLCAPoSECGnwSmQQzpAttLxeB[1];
				}
			}

			private MBjuFCdNYLMtPHOUZfQEbhzGcAH(IControllerTemplate parent, int id, string name, jUsmBPPozsChspVdxyHFfIWHsmS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Yoke, elements)
			{
			}

			internal MBjuFCdNYLMtPHOUZfQEbhzGcAH(IControllerTemplate parent, int id, string name, vzNbVOYjzSTFdZWvXmdGFqlulCJ rollAxis, vzNbVOYjzSTFdZWvXmdGFqlulCJ pitchAxis)
				: base(parent, id, name, ControllerTemplateElementType.Yoke, new jUsmBPPozsChspVdxyHFfIWHsmS[2] { rollAxis, pitchAxis })
			{
			}
		}

		internal sealed class iQiGWPhBBuZdXoGpVnsJcxJgftCm : LimwuYfosNQnoefmqsyHEvwDVE, IControllerTemplateElement, IControllerTemplateStick6D
		{
			private new const int XzKfnkkbypotcpvEsjiEIoMKBybj = 6;

			private iQiGWPhBBuZdXoGpVnsJcxJgftCm(IControllerTemplate parent, int id, string name, jUsmBPPozsChspVdxyHFfIWHsmS[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Stick6D, elements)
			{
			}

			internal iQiGWPhBBuZdXoGpVnsJcxJgftCm(IControllerTemplate parent, int id, string name, vzNbVOYjzSTFdZWvXmdGFqlulCJ positionX, vzNbVOYjzSTFdZWvXmdGFqlulCJ positionY, vzNbVOYjzSTFdZWvXmdGFqlulCJ positionZ, vzNbVOYjzSTFdZWvXmdGFqlulCJ rotationX, vzNbVOYjzSTFdZWvXmdGFqlulCJ rotationY, vzNbVOYjzSTFdZWvXmdGFqlulCJ rotationZ)
				: base(parent, id, name, ControllerTemplateElementType.Stick6D, new jUsmBPPozsChspVdxyHFfIWHsmS[6] { positionX, positionY, positionZ, rotationX, rotationY, rotationZ })
			{
			}
		}

		internal class ULSEvpcHTnGvtDkHVJzkROEKmtR
		{
			public readonly Controller.Element KspObDEVwZbsUrQZILSLveBSzec;

			public readonly IControllerElementTarget GCQHnJkXanMbWWcIAkqAJMfPbnz;

			public bool boolValue
			{
				get
				{
					if (KspObDEVwZbsUrQZILSLveBSzec == null)
					{
						return false;
					}
					ControllerElementType type = KspObDEVwZbsUrQZILSLveBSzec.type;
					float value = default(float);
					while (true)
					{
						switch (-1895807994 ^ -1895807993)
						{
						case 2:
							continue;
						case 1:
							switch (type)
							{
							case ControllerElementType.Button:
								break;
							case ControllerElementType.Axis:
								goto IL_0062;
							default:
								goto end_IL_0021;
							}
							goto case 0;
						case 0:
							return (KspObDEVwZbsUrQZILSLveBSzec as Controller.Button).value;
						default:
							{
								if (value > 0.01f)
								{
									return true;
								}
								if (value < -0.01f)
								{
									return true;
								}
								break;
							}
							IL_0062:
							value = (KspObDEVwZbsUrQZILSLveBSzec as Controller.Axis).value;
							switch (GCQHnJkXanMbWWcIAkqAJMfPbnz.axisRange)
							{
							case AxisRange.Full:
								break;
							case AxisRange.Positive:
								if (value > 0.01f)
								{
									return true;
								}
								goto end_IL_0021;
							case AxisRange.Negative:
								if (value < -0.01f)
								{
									return true;
								}
								goto end_IL_0021;
							default:
								goto end_IL_0021;
							}
							goto default;
							end_IL_0021:
							break;
						}
						break;
					}
					return false;
				}
			}

			public bool boolValuePrev
			{
				get
				{
					if (KspObDEVwZbsUrQZILSLveBSzec == null)
					{
						goto IL_0008;
					}
					switch (KspObDEVwZbsUrQZILSLveBSzec.type)
					{
					case ControllerElementType.Button:
						break;
					case ControllerElementType.Axis:
						goto IL_0070;
					default:
						goto IL_00eb;
					}
					goto IL_005f;
					IL_009a:
					float valuePrev = default(float);
					if (valuePrev > 0.01f)
					{
						return true;
					}
					if (valuePrev < -0.01f)
					{
						return true;
					}
					goto IL_00eb;
					IL_0070:
					valuePrev = (KspObDEVwZbsUrQZILSLveBSzec as Controller.Axis).valuePrev;
					AxisRange axisRange = GCQHnJkXanMbWWcIAkqAJMfPbnz.axisRange;
					AxisRange axisRange2 = axisRange;
					int num = -1153879209;
					goto IL_000d;
					IL_0008:
					num = -1153879214;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num ^ -1153879213)
						{
						case 0:
							break;
						case 1:
							return false;
						case 3:
							goto IL_005f;
						case 5:
							goto IL_009a;
						case 4:
							goto IL_00ca;
						default:
							return true;
						}
						break;
						IL_00ca:
						switch (axisRange2)
						{
						case AxisRange.Full:
							break;
						case AxisRange.Positive:
							if (valuePrev > 0.01f)
							{
								return true;
							}
							goto IL_00eb;
						case AxisRange.Negative:
							goto IL_00b8;
						default:
							goto IL_00eb;
						}
						goto IL_009a;
						IL_00b8:
						if (valuePrev < -0.01f)
						{
							num = -1153879215;
							continue;
						}
						goto IL_00eb;
					}
					goto IL_0008;
					IL_00eb:
					return false;
					IL_005f:
					return (KspObDEVwZbsUrQZILSLveBSzec as Controller.Button).valuePrev;
				}
			}

			public bool justPressed
			{
				get
				{
					if (KspObDEVwZbsUrQZILSLveBSzec == null)
					{
						return false;
					}
					ControllerElementType type = KspObDEVwZbsUrQZILSLveBSzec.type;
					while (true)
					{
						int num = -134799168;
						while (true)
						{
							switch (num ^ -134799167)
							{
							case 0:
								break;
							case 1:
								switch (type)
								{
								case ControllerElementType.Button:
									return (KspObDEVwZbsUrQZILSLveBSzec as Controller.Button).justPressed;
								case ControllerElementType.Axis:
									if (MathTools.Abs(floatValue) > 0.01f && MathTools.Abs(floatValuePrev) <= 0.01f)
									{
										goto IL_0070;
									}
									break;
								}
								return false;
							default:
								return true;
							}
							break;
							IL_0070:
							num = -134799165;
						}
					}
				}
			}

			public bool justReleased
			{
				get
				{
					if (KspObDEVwZbsUrQZILSLveBSzec == null)
					{
						return false;
					}
					ControllerElementType type = KspObDEVwZbsUrQZILSLveBSzec.type;
					while (true)
					{
						int num = -1829870813;
						while (true)
						{
							switch (num ^ -1829870814)
							{
							case 2:
								break;
							case 1:
								switch (type)
								{
								case ControllerElementType.Button:
									num = -1829870815;
									continue;
								case ControllerElementType.Axis:
									if (MathTools.Abs(floatValue) <= 0.01f)
									{
										num = -1829870814;
										continue;
									}
									break;
								}
								goto IL_0084;
							case 3:
								return (KspObDEVwZbsUrQZILSLveBSzec as Controller.Button).justReleased;
							default:
								{
									if (MathTools.Abs(floatValuePrev) > 0.01f)
									{
										return true;
									}
									goto IL_0084;
								}
								IL_0084:
								return false;
							}
							break;
						}
					}
				}
			}

			public float floatValue
			{
				get
				{
					if (KspObDEVwZbsUrQZILSLveBSzec == null)
					{
						goto IL_0008;
					}
					switch (KspObDEVwZbsUrQZILSLveBSzec.type)
					{
					case ControllerElementType.Button:
						break;
					default:
						goto IL_00a1;
					case ControllerElementType.Axis:
						goto IL_00b7;
					}
					goto IL_0066;
					IL_000d:
					int num;
					float value = default(float);
					switch (num ^ 0x2D696172)
					{
					case 0:
						break;
					case 5:
						goto IL_0039;
					case 6:
						goto IL_0066;
					case 1:
						return 0f;
					case 2:
						return 0f;
					default:
						return value;
					case 4:
						goto IL_00f8;
					}
					goto IL_0008;
					IL_00b7:
					value = (KspObDEVwZbsUrQZILSLveBSzec as Controller.Axis).value;
					switch (GCQHnJkXanMbWWcIAkqAJMfPbnz.axisRange)
					{
					case AxisRange.Full:
						break;
					case AxisRange.Positive:
						if (value > 0f)
						{
							return value;
						}
						goto IL_00f8;
					case AxisRange.Negative:
						goto IL_0048;
					default:
						goto IL_00f8;
					}
					goto IL_0039;
					IL_0066:
					if (!(KspObDEVwZbsUrQZILSLveBSzec as Controller.Button).value)
					{
						num = 761880944;
						goto IL_000d;
					}
					return 1f;
					IL_0039:
					return value;
					IL_0048:
					if (value < 0f)
					{
						num = 761880945;
						goto IL_000d;
					}
					goto IL_00f8;
					IL_00f8:
					return 0f;
					IL_00a1:
					num = 761880950;
					goto IL_000d;
					IL_0008:
					num = 761880947;
					goto IL_000d;
				}
			}

			public float floatValuePrev
			{
				get
				{
					if (KspObDEVwZbsUrQZILSLveBSzec == null)
					{
						return 0f;
					}
					switch (KspObDEVwZbsUrQZILSLveBSzec.type)
					{
					case ControllerElementType.Button:
						if (!(KspObDEVwZbsUrQZILSLveBSzec as Controller.Button).valuePrev)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
						{
							float valuePrev = (KspObDEVwZbsUrQZILSLveBSzec as Controller.Axis).valuePrev;
							int num = 732637887;
							while (true)
							{
								switch (num ^ 0x2BAB2ABC)
								{
								case 4:
									num = 732637885;
									continue;
								case 1:
									break;
								case 0:
									goto IL_008b;
								case 3:
									goto IL_009c;
								default:
									return valuePrev;
								}
								break;
								IL_009c:
								switch (GCQHnJkXanMbWWcIAkqAJMfPbnz.axisRange)
								{
								case AxisRange.Full:
									break;
								case AxisRange.Positive:
									goto IL_008d;
								case AxisRange.Negative:
									if (valuePrev < 0f)
									{
										return valuePrev;
									}
									goto end_IL_001d;
								default:
									goto end_IL_001d;
								}
								goto IL_008b;
								IL_008d:
								if (!(valuePrev > 0f))
								{
									goto end_IL_001d;
								}
								num = 732637886;
								continue;
								IL_008b:
								return valuePrev;
							}
							goto case ControllerElementType.Button;
						}
						end_IL_001d:
						break;
					}
					return 0f;
				}
			}

			public ULSEvpcHTnGvtDkHVJzkROEKmtR(IControllerElementTarget target, Controller.Element element)
			{
				KspObDEVwZbsUrQZILSLveBSzec = element;
				GCQHnJkXanMbWWcIAkqAJMfPbnz = target;
			}

			public static ULSEvpcHTnGvtDkHVJzkROEKmtR dawcjtsNOciSWAmaKVxbSHSsCoQM()
			{
				return new ULSEvpcHTnGvtDkHVJzkROEKmtR(auqagPyfULkTIGtBZGYbYCoEQli.dawcjtsNOciSWAmaKVxbSHSsCoQM(), null);
			}
		}

		internal class adQzKzNdBifUDJeBXdCrHVmckZx
		{
			public readonly Controller EnKkaiEMISMHdBHJLGCBcerSsFgw;

			public readonly IHardwareControllerTemplateMap_Internal RgsRvOgZtrLeUFDSBPjWOdZOmtM;

			public adQzKzNdBifUDJeBXdCrHVmckZx(Controller controller, IHardwareControllerTemplateMap_Internal templateMap)
			{
				if (controller == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (templateMap == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				EnKkaiEMISMHdBHJLGCBcerSsFgw = controller;
				RgsRvOgZtrLeUFDSBPjWOdZOmtM = templateMap;
			}
		}

		private readonly string jMnuxDpeLQhKgkpKQOlnqChJgyRd;

		private readonly Guid WouZkHYfjCGLZCIaFlPpCAyLWwlJ;

		private readonly Controller ktnvQXcbwjTTWobUkcIrbxSoyaKH;

		private readonly ADictionary<int, IControllerTemplateElement> VYxepMfWytkFaeJsTgtmskjaLhl;

		private readonly ADictionary<string, IControllerTemplateElement> nBYDthWhnIiLCklbayCgnNrvHHQ;

		private IControllerTemplateElement[] zGVdLCAPoSECGnwSmQQzpAttLxeB;

		private ReadOnlyCollection<IControllerTemplateElement> DnCGAXuCydczsGMHdwaSQnTzKxR;

		private readonly int SsPwhbdijXONOlkRKHOkXryZrDq;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				return ktnvQXcbwjTTWobUkcIrbxSoyaKH;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				return jMnuxDpeLQhKgkpKQOlnqChJgyRd;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						int num = 2048841056;
						while (true)
						{
							switch (num ^ 0x7A1ED561)
							{
							case 0:
								break;
							case 1:
								goto IL_002b;
							default:
								return Guid.Empty;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
							num = 2048841059;
						}
					}
				}
				return WouZkHYfjCGLZCIaFlPpCAyLWwlJ;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				return DnCGAXuCydczsGMHdwaSQnTzKxR;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				}
				return zGVdLCAPoSECGnwSmQQzpAttLxeB.Length;
			}
		}

		protected ControllerTemplate(object payload)
			: this((adQzKzNdBifUDJeBXdCrHVmckZx)payload)
		{
		}

		private ControllerTemplate(adQzKzNdBifUDJeBXdCrHVmckZx initializer)
		{
			if (initializer == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (initializer.EnKkaiEMISMHdBHJLGCBcerSsFgw == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (initializer.RgsRvOgZtrLeUFDSBPjWOdZOmtM == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			SsPwhbdijXONOlkRKHOkXryZrDq = ReInput.id;
			ktnvQXcbwjTTWobUkcIrbxSoyaKH = initializer.EnKkaiEMISMHdBHJLGCBcerSsFgw;
			IHardwareControllerTemplateMap_Internal rgsRvOgZtrLeUFDSBPjWOdZOmtM = initializer.RgsRvOgZtrLeUFDSBPjWOdZOmtM;
			jMnuxDpeLQhKgkpKQOlnqChJgyRd = rgsRvOgZtrLeUFDSBPjWOdZOmtM.name;
			WouZkHYfjCGLZCIaFlPpCAyLWwlJ = rgsRvOgZtrLeUFDSBPjWOdZOmtM.typeGuid;
			int elementIdentifierCount = rgsRvOgZtrLeUFDSBPjWOdZOmtM.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = rgsRvOgZtrLeUFDSBPjWOdZOmtM.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						ZsogrZyhQfaSnqVtBlGOmbxOuQc zsogrZyhQfaSnqVtBlGOmbxOuQc2 = rgsRvOgZtrLeUFDSBPjWOdZOmtM.GetAxisTarget(ktnvQXcbwjTTWobUkcIrbxSoyaKH, templateElementIdentifier.id) ?? ZsogrZyhQfaSnqVtBlGOmbxOuQc.dawcjtsNOciSWAmaKVxbSHSsCoQM(ControllerTemplateElementType.Axis);
						SbDQhfjcUkLRdbEKaBbJAiEhPZAh item2 = new SbDQhfjcUkLRdbEKaBbJAiEhPZAh(this, templateElementIdentifier.id, templateElementIdentifier.name, (!string.IsNullOrEmpty(templateElementIdentifier.positiveName)) ? templateElementIdentifier.positiveName : (templateElementIdentifier.name + " +"), (!string.IsNullOrEmpty(templateElementIdentifier.negativeName)) ? templateElementIdentifier.negativeName : (templateElementIdentifier.name + " -"), zsogrZyhQfaSnqVtBlGOmbxOuQc2, IPNEVPDprwogxEkxTkvfeiueYpzI(ktnvQXcbwjTTWobUkcIrbxSoyaKH, (IControllerTemplateAxisSource)zsogrZyhQfaSnqVtBlGOmbxOuQc2));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						ZsogrZyhQfaSnqVtBlGOmbxOuQc zsogrZyhQfaSnqVtBlGOmbxOuQc = rgsRvOgZtrLeUFDSBPjWOdZOmtM.GetButtonTarget(ktnvQXcbwjTTWobUkcIrbxSoyaKH, templateElementIdentifier.id) ?? ZsogrZyhQfaSnqVtBlGOmbxOuQc.dawcjtsNOciSWAmaKVxbSHSsCoQM(ControllerTemplateElementType.Button);
						jxzVsgyangpawyDAbWrtTzUsjeL item = new jxzVsgyangpawyDAbWrtTzUsjeL(this, templateElementIdentifier.id, templateElementIdentifier.name, templateElementIdentifier.name, templateElementIdentifier.name + " -", zsogrZyhQfaSnqVtBlGOmbxOuQc, IPNEVPDprwogxEkxTkvfeiueYpzI(ktnvQXcbwjTTWobUkcIrbxSoyaKH, (IControllerTemplateButtonSource)zsogrZyhQfaSnqVtBlGOmbxOuQc));
						list3.Add(item);
						break;
					}
					default:
						throw new NotImplementedException();
					}
				}
			}
			for (int j = 0; j < list2.Count; j++)
			{
				list.Add(list2[j]);
			}
			for (int k = 0; k < list3.Count; k++)
			{
				list.Add(list3[k]);
			}
			for (int l = 0; l < list.Count; l++)
			{
				aDictionary.Add(list[l].id, list[l]);
			}
			for (int m = 0; m < elementIdentifierCount; m++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier2 = rgsRvOgZtrLeUFDSBPjWOdZOmtM.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = rgsRvOgZtrLeUFDSBPjWOdZOmtM.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				jUsmBPPozsChspVdxyHFfIWHsmS jUsmBPPozsChspVdxyHFfIWHsmS2;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					jUsmBPPozsChspVdxyHFfIWHsmS2 = new WgZuUjisadsATapPzkufnlqelZs(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping5 != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping5.eid_axisX) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping5 != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping5.eid_axisY) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping5 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping5.eid_button) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					jUsmBPPozsChspVdxyHFfIWHsmS2 = new sPsshTZbXexFegNMFFUosefJZRc(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping3 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping3.eid_up) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping3 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping3.eid_right) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping3 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping3.eid_down) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping3 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping3.eid_left) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping3 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping3.eid_press) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					jUsmBPPozsChspVdxyHFfIWHsmS2 = new TVyjXqKMFYOAvVqUUBPuexGpryN(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping2 != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping2.eid_axisX) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping2 != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping2.eid_axisY) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping2 != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping2.eid_axisZ) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					jUsmBPPozsChspVdxyHFfIWHsmS2 = new vNGOdfUlxuAANGGenYhffdsLwcY(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping6 != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping6.eid_axis) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping6 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping6.eid_minDetent) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					jUsmBPPozsChspVdxyHFfIWHsmS2 = new GUwxzxbXfOiFOfJUuGCKTEeAYAy(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping7 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping7.eid_up) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping7 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping7.eid_upRight) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping7 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping7.eid_right) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping7 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping7.eid_downRight) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping7 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping7.eid_down) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping7 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping7.eid_downLeft) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping7 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping7.eid_left) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping7 != null) ? acgYzaDYmGYvlaPXYdbaLFYHGHr(this, aDictionary, mapping7.eid_upLeft) : jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					jUsmBPPozsChspVdxyHFfIWHsmS2 = new MBjuFCdNYLMtPHOUZfQEbhzGcAH(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping4 != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping4.eid_axisX) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping4 != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping4.eid_axisZ) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					jUsmBPPozsChspVdxyHFfIWHsmS2 = new iQiGWPhBBuZdXoGpVnsJcxJgftCm(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping.eid_positionX) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping.eid_positionY) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping.eid_positionZ) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping.eid_rotationX) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping.eid_rotationY) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this), (mapping != null) ? FsrArpFOfVKRCvvtozUkdYZQFkEL(this, aDictionary, mapping.eid_rotationZ) : SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (jUsmBPPozsChspVdxyHFfIWHsmS2 != null)
				{
					list4.Add(jUsmBPPozsChspVdxyHFfIWHsmS2);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			zGVdLCAPoSECGnwSmQQzpAttLxeB = list.ToArray();
			VYxepMfWytkFaeJsTgtmskjaLhl = aDictionary;
			nBYDthWhnIiLCklbayCgnNrvHHQ = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < zGVdLCAPoSECGnwSmQQzpAttLxeB.Length; num++)
			{
				IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor = rgsRvOgZtrLeUFDSBPjWOdZOmtM.GetTemplateElementIdentifierById(zGVdLCAPoSECGnwSmQQzpAttLxeB[num].id) as IControllerTemplateElementIdentifier_Editor;
				if (controllerTemplateElementIdentifier_Editor == null)
				{
					continue;
				}
				for (int num2 = 0; num2 < 2; num2++)
				{
					string text = ((num2 != 0) ? controllerTemplateElementIdentifier_Editor.alternateScriptingName : controllerTemplateElementIdentifier_Editor.scriptingName);
					if (!string.IsNullOrEmpty(text))
					{
						try
						{
							nBYDthWhnIiLCklbayCgnNrvHHQ.Add(text, zGVdLCAPoSECGnwSmQQzpAttLxeB[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + jMnuxDpeLQhKgkpKQOlnqChJgyRd + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			DnCGAXuCydczsGMHdwaSQnTzKxR = new ReadOnlyCollection<IControllerTemplateElement>(zGVdLCAPoSECGnwSmQQzpAttLxeB);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			IControllerTemplateElement value;
			if (!VYxepMfWytkFaeJsTgtmskjaLhl.TryGetValue(id, out value))
			{
				object[] array = new object[5] { "There is no element with the id \"", null, null, null, null };
				while (true)
				{
					int num = 295114733;
					while (true)
					{
						switch (num ^ 0x119717EC)
						{
						case 2:
							break;
						case 1:
							array[1] = id;
							array[2] = "\" in the ";
							array[3] = GetType().ToString();
							array[4] = ".";
							Logger.LogWarning(string.Concat(array));
							num = 295114732;
							continue;
						default:
							goto end_IL_001f;
						}
						break;
					}
					continue;
					end_IL_001f:
					break;
				}
			}
			return value;
		}

		protected T GetElement<T>(int id) where T : class, IControllerTemplateElement
		{
			return GetElement(id) as T;
		}

		IControllerTemplateElement IControllerTemplate.GetElement(int P_0)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			return GetElement(P_0);
		}

		T IControllerTemplate.GetElement<T>(int P_0)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			return GetElement<T>(P_0);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget P_0, IList<ControllerTemplateElementTarget> P_1)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			int num2;
			if (P_1 == null)
			{
				num = -724771997;
				num2 = num;
			}
			else
			{
				num = -724772000;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = -724771998;
			goto IL_001e;
			IL_001e:
			switch (num ^ -724771999)
			{
			case 0:
				break;
			case 3:
				return 0;
			case 2:
				throw new ArgumentNullException("results");
			default:
				return nvghxhLyOjkIMeMmIMQGtTJJCyV(P_0, ref P_1);
			}
			goto IL_0019;
		}

		private int nvghxhLyOjkIMeMmIMQGtTJJCyV(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
		{
			if (P_1 != null)
			{
				P_1.Clear();
				goto IL_000b;
			}
			goto IL_0083;
			IL_0083:
			int num = 0;
			int num2 = 0;
			int num3 = 1402386245;
			goto IL_0010;
			IL_000b:
			num3 = 1402386244;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num3 ^ 0x5396B745)
				{
				case 4:
					break;
				case 0:
					goto IL_0035;
				case 2:
					if (InputTools.IsMappableType(zGVdLCAPoSECGnwSmQQzpAttLxeB[num2].type))
					{
						num += (zGVdLCAPoSECGnwSmQQzpAttLxeB[num2] as IControllerTemplateElement_Internal).GetElementTargets(P_0, ref P_1);
						num3 = 1402386246;
						continue;
					}
					goto case 3;
				case 1:
					goto IL_0083;
				case 3:
					num2++;
					num3 = 1402386245;
					continue;
				default:
					return num;
				}
				break;
				IL_0035:
				int num4;
				if (num2 < zGVdLCAPoSECGnwSmQQzpAttLxeB.Length)
				{
					num3 = 1402386247;
					num4 = num3;
				}
				else
				{
					num3 = 1402386240;
					num4 = num3;
				}
			}
			goto IL_000b;
		}

		[CustomObfuscation(rename = false)]
		internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
		{
			switch (elementType)
			{
			case ControllerTemplateElementType.Axis:
				return typeof(IControllerTemplateAxis);
			case ControllerTemplateElementType.Button:
				return typeof(IControllerTemplateButton);
			case ControllerTemplateElementType.ThumbStick:
				return typeof(IControllerTemplateThumbStick);
			case ControllerTemplateElementType.DPad:
				return typeof(IControllerTemplateDPad);
			case ControllerTemplateElementType.Stick:
				return typeof(IControllerTemplateStick);
			case ControllerTemplateElementType.Throttle:
				return typeof(IControllerTemplateThrottle);
			case ControllerTemplateElementType.Hat:
				return typeof(IControllerTemplateHat);
			case ControllerTemplateElementType.Yoke:
				return typeof(IControllerTemplateYoke);
			case ControllerTemplateElementType.Stick6D:
				return typeof(IControllerTemplateStick6D);
			default:
				throw new NotImplementedException();
			}
		}

		private static IList<ULSEvpcHTnGvtDkHVJzkROEKmtR> IPNEVPDprwogxEkxTkvfeiueYpzI(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			bool flag = default(bool);
			IList<ULSEvpcHTnGvtDkHVJzkROEKmtR> list = default(IList<ULSEvpcHTnGvtDkHVJzkROEKmtR>);
			Controller.Element elementById2 = default(Controller.Element);
			Controller.Element elementById = default(Controller.Element);
			if (P_1.splitAxis)
			{
				while (true)
				{
					int num = -782114409;
					while (true)
					{
						switch (num ^ -782114410)
						{
						case 2:
							break;
						case 11:
							if (!flag)
							{
								ListTools.AddAndCreateList(ref list, ULSEvpcHTnGvtDkHVJzkROEKmtR.dawcjtsNOciSWAmaKVxbSHSsCoQM());
								num = -782114401;
								continue;
							}
							goto default;
						case 0:
						{
							int num4;
							if (elementById2 == null)
							{
								num = -782114402;
								num4 = num;
							}
							else
							{
								num = -782114413;
								num4 = num;
							}
							continue;
						}
						case 6:
							ListTools.AddAndCreateList(ref list, ULSEvpcHTnGvtDkHVJzkROEKmtR.dawcjtsNOciSWAmaKVxbSHSsCoQM());
							num = -782114404;
							continue;
						case 7:
							flag = true;
							num = -782114402;
							continue;
						case 5:
							ListTools.AddAndCreateList(ref list, new ULSEvpcHTnGvtDkHVJzkROEKmtR(P_1.positiveTarget, elementById2));
							num = -782114415;
							continue;
						case 8:
						{
							int num5;
							if (!flag)
							{
								num = -782114416;
								num5 = num;
							}
							else
							{
								num = -782114404;
								num5 = num;
							}
							continue;
						}
						case 4:
						{
							elementById = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
							int num3;
							if (elementById == null)
							{
								num = -782114403;
								num3 = num;
							}
							else
							{
								num = -782114411;
								num3 = num;
							}
							continue;
						}
						case 10:
							flag = false;
							num = -782114406;
							continue;
						case 1:
							list = null;
							flag = false;
							if (P_1.positiveTarget != null)
							{
								elementById2 = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
								num = -782114410;
								continue;
							}
							goto case 8;
						case 12:
						{
							int num2;
							if (P_1.negativeTarget == null)
							{
								num = -782114403;
								num2 = num;
							}
							else
							{
								num = -782114414;
								num2 = num;
							}
							continue;
						}
						case 3:
							ListTools.AddAndCreateList(ref list, new ULSEvpcHTnGvtDkHVJzkROEKmtR(P_1.negativeTarget, elementById));
							flag = true;
							num = -782114403;
							continue;
						default:
							return list;
						}
						break;
					}
				}
			}
			return IPNEVPDprwogxEkxTkvfeiueYpzI(P_0, P_1.fullTarget);
		}

		private static IList<ULSEvpcHTnGvtDkHVJzkROEKmtR> IPNEVPDprwogxEkxTkvfeiueYpzI(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return IPNEVPDprwogxEkxTkvfeiueYpzI(P_0, P_1.target);
		}

		private static IList<ULSEvpcHTnGvtDkHVJzkROEKmtR> IPNEVPDprwogxEkxTkvfeiueYpzI(Controller P_0, IControllerElementTarget P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			Controller.Element elementById = P_0.GetElementById(P_1.elementIdentifierId);
			if (elementById == null)
			{
				return null;
			}
			List<ULSEvpcHTnGvtDkHVJzkROEKmtR> list = new List<ULSEvpcHTnGvtDkHVJzkROEKmtR>();
			list.Add(new ULSEvpcHTnGvtDkHVJzkROEKmtR(P_1, elementById));
			return list;
		}

		private static IControllerTemplateElement eNOnITiRsBDEjYjbmNjiYFjzMrb(List<IControllerTemplateElement> P_0, int P_1)
		{
			int count = P_0.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -1421351567;
				while (true)
				{
					switch (num ^ -1421351568)
					{
					case 3:
						break;
					case 1:
						num2 = 0;
						num = -1421351564;
						continue;
					case 4:
					{
						int num3;
						if (num2 < count)
						{
							num = -1421351566;
							num3 = num;
						}
						else
						{
							num = -1421351568;
							num3 = num;
						}
						continue;
					}
					case 2:
						if (P_0[num2].id == P_1)
						{
							return P_0[num2];
						}
						num2++;
						num = -1421351564;
						continue;
					default:
						return null;
					}
					break;
				}
			}
		}

		private static vzNbVOYjzSTFdZWvXmdGFqlulCJ FsrArpFOfVKRCvvtozUkdYZQFkEL(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			vzNbVOYjzSTFdZWvXmdGFqlulCJ vzNbVOYjzSTFdZWvXmdGFqlulCJ2 = P_1.GetValueSafe(P_2) as vzNbVOYjzSTFdZWvXmdGFqlulCJ;
			if (vzNbVOYjzSTFdZWvXmdGFqlulCJ2 == null)
			{
				return SbDQhfjcUkLRdbEKaBbJAiEhPZAh.dawcjtsNOciSWAmaKVxbSHSsCoQM(P_0);
			}
			return vzNbVOYjzSTFdZWvXmdGFqlulCJ2;
		}

		private static vzNbVOYjzSTFdZWvXmdGFqlulCJ acgYzaDYmGYvlaPXYdbaLFYHGHr(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			vzNbVOYjzSTFdZWvXmdGFqlulCJ vzNbVOYjzSTFdZWvXmdGFqlulCJ2 = P_1.GetValueSafe(P_2) as vzNbVOYjzSTFdZWvXmdGFqlulCJ;
			if (vzNbVOYjzSTFdZWvXmdGFqlulCJ2 == null)
			{
				return jxzVsgyangpawyDAbWrtTzUsjeL.dawcjtsNOciSWAmaKVxbSHSsCoQM(P_0);
			}
			return vzNbVOYjzSTFdZWvXmdGFqlulCJ2;
		}
	}
}
