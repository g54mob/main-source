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
		internal abstract class QgSdyGzqsrxSGVEZPuwJASSKdjd : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate HQqdfhbximGRqAmWjsGgpbsZYxai;

			private readonly int rOuBUzbbciWwktcpmiPWpQIKoaAa;

			private readonly string EqppaAHmTQvmVSSZadzlNpPBbHM;

			private readonly ControllerTemplateElementType iaFziOmGetWMviBsUmpNhLnTJKt;

			protected readonly int znFtIaPrJLvdjPGCwXFaaAeLKcr;

			public int id
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return -1;
					}
					return rOuBUzbbciWwktcpmiPWpQIKoaAa;
				}
			}

			public string descriptiveName
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return EqppaAHmTQvmVSSZadzlNpPBbHM;
				}
			}

			public ControllerTemplateElementType type
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return ControllerTemplateElementType.Axis;
					}
					return iaFziOmGetWMviBsUmpNhLnTJKt;
				}
			}

			public IControllerTemplate parent
			{
				get
				{
					return HQqdfhbximGRqAmWjsGgpbsZYxai;
				}
			}

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected QgSdyGzqsrxSGVEZPuwJASSKdjd(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType)
			{
				while (true)
				{
					int num = -250455348;
					while (true)
					{
						switch (num ^ -250455346)
						{
						case 3:
							break;
						case 2:
							if (parent != null)
							{
								goto IL_003d;
							}
							throw new ArgumentNullException("parent");
						case 1:
							goto IL_003d;
						default:
							znFtIaPrJLvdjPGCwXFaaAeLKcr = ReInput.id;
							return;
						}
						break;
						IL_003d:
						HQqdfhbximGRqAmWjsGgpbsZYxai = parent;
						rOuBUzbbciWwktcpmiPWpQIKoaAa = id;
						EqppaAHmTQvmVSSZadzlNpPBbHM = name;
						iaFziOmGetWMviBsUmpNhLnTJKt = elementType;
						num = -250455346;
					}
				}
			}

			public abstract IControllerTemplateElement GetElement(int P_0);

			public abstract int GetElementTargets(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1);
		}

		internal abstract class AOVYUFveXQbJGstCEjSTqLbprJy : QgSdyGzqsrxSGVEZPuwJASSKdjd
		{
			protected readonly int RpNzlxacPwyuwFdbrmvHEuEJzjc;

			protected readonly rlMFrkSNhflWEbbAbNShgGYIzlu[] HaUgwqZzDUwnOiQgtoLBdIMZTav;

			public override bool exists
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					if (HaUgwqZzDUwnOiQgtoLBdIMZTav == null)
					{
						return false;
					}
					int num = 0;
					while (num < HaUgwqZzDUwnOiQgtoLBdIMZTav.Length)
					{
						while (true)
						{
							if (HaUgwqZzDUwnOiQgtoLBdIMZTav[num].nsrJcOgpcFdFnRaSgBMVkSZUgdlg != null)
							{
								return true;
							}
							num++;
							int num2 = 1238843797;
							while (true)
							{
								switch (num2 ^ 0x49D74197)
								{
								case 0:
									num2 = 1238843798;
									continue;
								case 1:
									break;
								default:
									goto end_IL_0047;
								}
								break;
							}
							continue;
							end_IL_0047:
							break;
						}
					}
					return false;
				}
			}

			protected AOVYUFveXQbJGstCEjSTqLbprJy(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, IList<rlMFrkSNhflWEbbAbNShgGYIzlu> sourceElements)
				: base(parent, id, name, elementType)
			{
				while (true)
				{
					int num = 890073847;
					while (true)
					{
						rlMFrkSNhflWEbbAbNShgGYIzlu[] haUgwqZzDUwnOiQgtoLBdIMZTav;
						switch (num ^ 0x350D72F6)
						{
						case 0:
							break;
						case 1:
							haUgwqZzDUwnOiQgtoLBdIMZTav = ((sourceElements != null) ? ListTools.ToArray(sourceElements) : null);
							goto IL_0038;
						default:
							RpNzlxacPwyuwFdbrmvHEuEJzjc = ((HaUgwqZzDUwnOiQgtoLBdIMZTav != null) ? HaUgwqZzDUwnOiQgtoLBdIMZTav.Length : 0);
							return;
						}
						break;
						IL_0038:
						HaUgwqZzDUwnOiQgtoLBdIMZTav = haUgwqZzDUwnOiQgtoLBdIMZTav;
						num = 890073844;
					}
				}
			}
		}

		internal abstract class UDauPmAdOcMEjsLbmuQqmkmgNY : AOVYUFveXQbJGstCEjSTqLbprJy, IControllerTemplateElement, IControllerTemplateAxis, IControllerTemplateButton
		{
			private qFwngCMEUbVOUWUBpxMUVdPUzPt pjZjqriAjRgtRcmANkmfeRSKwaR;

			private string XPnTvrAUYAzGhdGqNPKjneQiACY;

			private string LrlbwFdVqTXHiNJRCEeCaoHmpfT;

			public float floatValue
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					if (RpNzlxacPwyuwFdbrmvHEuEJzjc == 1)
					{
						return HaUgwqZzDUwnOiQgtoLBdIMZTav[0].floatValue;
					}
					if (RpNzlxacPwyuwFdbrmvHEuEJzjc == 2)
					{
						float num = HaUgwqZzDUwnOiQgtoLBdIMZTav[0].floatValue;
						float num2 = HaUgwqZzDUwnOiQgtoLBdIMZTav[1].floatValue;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public float floatValuePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						goto IL_000d;
					}
					int num;
					float num2 = default(float);
					float num3 = default(float);
					if (RpNzlxacPwyuwFdbrmvHEuEJzjc == 1)
					{
						num = 736132361;
					}
					else
					{
						if (RpNzlxacPwyuwFdbrmvHEuEJzjc != 2)
						{
							return 0f;
						}
						num2 = HaUgwqZzDUwnOiQgtoLBdIMZTav[0].floatValuePrev;
						num3 = HaUgwqZzDUwnOiQgtoLBdIMZTav[1].floatValuePrev;
						num = 736132362;
					}
					goto IL_0012;
					IL_0012:
					switch (num ^ 0x2BE07D08)
					{
					case 0:
						break;
					case 3:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					case 1:
						return HaUgwqZzDUwnOiQgtoLBdIMZTav[0].floatValuePrev;
					default:
						return MathTools.Clamp(num2 + num3, -1f, 1f);
					}
					goto IL_000d;
					IL_000d:
					num = 736132363;
					goto IL_0012;
				}
			}

			public bool boolValue
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						goto IL_0019;
					}
					int num;
					if (RpNzlxacPwyuwFdbrmvHEuEJzjc == 1)
					{
						num = 1959339975;
					}
					else
					{
						if (RpNzlxacPwyuwFdbrmvHEuEJzjc != 2)
						{
							return false;
						}
						if (HaUgwqZzDUwnOiQgtoLBdIMZTav[0].boolValue)
						{
							return true;
						}
						num = 1959339972;
					}
					goto IL_001e;
					IL_001e:
					switch (num ^ 0x74C927C6)
					{
					case 0:
						break;
					case 3:
						return false;
					case 1:
						return HaUgwqZzDUwnOiQgtoLBdIMZTav[0].boolValue;
					default:
						return HaUgwqZzDUwnOiQgtoLBdIMZTav[1].boolValue;
					}
					goto IL_0019;
					IL_0019:
					num = 1959339973;
					goto IL_001e;
				}
			}

			public bool boolValuePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					if (RpNzlxacPwyuwFdbrmvHEuEJzjc == 1)
					{
						return HaUgwqZzDUwnOiQgtoLBdIMZTav[0].boolValuePrev;
					}
					if (RpNzlxacPwyuwFdbrmvHEuEJzjc == 2)
					{
						if (!HaUgwqZzDUwnOiQgtoLBdIMZTav[0].boolValuePrev)
						{
							return HaUgwqZzDUwnOiQgtoLBdIMZTav[1].boolValuePrev;
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
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return XPnTvrAUYAzGhdGqNPKjneQiACY;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						while (true)
						{
							int num = 2141925040;
							while (true)
							{
								switch (num ^ 0x7FAB2EB2)
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
								ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num = 2141925043;
							}
						}
					}
					return LrlbwFdVqTXHiNJRCEeCaoHmpfT;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return floatValue;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return floatValuePrev;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return pjZjqriAjRgtRcmANkmfeRSKwaR;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					return boolValue;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					return boolValuePrev;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					if (RpNzlxacPwyuwFdbrmvHEuEJzjc == 1)
					{
						goto IL_0024;
					}
					int num;
					if (RpNzlxacPwyuwFdbrmvHEuEJzjc == 2)
					{
						if (HaUgwqZzDUwnOiQgtoLBdIMZTav[0].justPressed)
						{
							if (HaUgwqZzDUwnOiQgtoLBdIMZTav[1].boolValuePrev)
							{
								num = 1240516435;
								goto IL_0029;
							}
							return true;
						}
						goto IL_007e;
					}
					return false;
					IL_0029:
					switch (num ^ 0x49F0C751)
					{
					case 0:
						break;
					case 1:
						return HaUgwqZzDUwnOiQgtoLBdIMZTav[0].justPressed;
					default:
						goto IL_007e;
					}
					goto IL_0024;
					IL_007e:
					if (HaUgwqZzDUwnOiQgtoLBdIMZTav[1].justPressed)
					{
						return !HaUgwqZzDUwnOiQgtoLBdIMZTav[0].boolValuePrev;
					}
					return false;
					IL_0024:
					num = 1240516432;
					goto IL_0029;
				}
			}

			bool IControllerTemplateButton.justReleased
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					if (RpNzlxacPwyuwFdbrmvHEuEJzjc == 1)
					{
						return HaUgwqZzDUwnOiQgtoLBdIMZTav[0].justReleased;
					}
					if (RpNzlxacPwyuwFdbrmvHEuEJzjc == 2)
					{
						if (HaUgwqZzDUwnOiQgtoLBdIMZTav[0].justReleased)
						{
							if (!HaUgwqZzDUwnOiQgtoLBdIMZTav[1].boolValue)
							{
								return true;
							}
							goto IL_0059;
						}
						goto IL_0077;
					}
					return false;
					IL_005e:
					int num;
					switch (num ^ 0x786E104A)
					{
					case 0:
						break;
					case 1:
						goto IL_0077;
					default:
						return !HaUgwqZzDUwnOiQgtoLBdIMZTav[0].boolValue;
					}
					goto IL_0059;
					IL_0059:
					num = 2020479051;
					goto IL_005e;
					IL_0077:
					if (HaUgwqZzDUwnOiQgtoLBdIMZTav[1].justReleased)
					{
						num = 2020479048;
						goto IL_005e;
					}
					return false;
				}
			}

			bool IControllerTemplateButton.justChangedState
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return false;
					}
					return boolValue != boolValuePrev;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return floatValue;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return floatValuePrev;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return pjZjqriAjRgtRcmANkmfeRSKwaR;
				}
			}

			public override IControllerTemplateElementSource source
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return pjZjqriAjRgtRcmANkmfeRSKwaR;
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
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return this;
				}
			}

			public IControllerTemplateButton AsButton
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return this;
				}
			}

			protected UDauPmAdOcMEjsLbmuQqmkmgNY(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, ControllerTemplateElementType elementType, qFwngCMEUbVOUWUBpxMUVdPUzPt target, IList<rlMFrkSNhflWEbbAbNShgGYIzlu> sourceElements)
				: base(parent, id, name, elementType, sourceElements)
			{
				if (sourceElements != null && sourceElements.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
				if (target == null)
				{
					throw new ArgumentNullException("target");
				}
				pjZjqriAjRgtRcmANkmfeRSKwaR = target;
				XPnTvrAUYAzGhdGqNPKjneQiACY = positiveName;
				LrlbwFdVqTXHiNJRCEeCaoHmpfT = negativeName;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange P_0)
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				switch (P_0)
				{
				default:
					while (true)
					{
						switch (0x41300208 ^ 0x41300209)
						{
						case 0:
							continue;
						case 1:
							throw new NotImplementedException();
						}
						break;
					}
					goto case AxisRange.Full;
				case AxisRange.Full:
					return base.descriptiveName;
				case AxisRange.Positive:
					return XPnTvrAUYAzGhdGqNPKjneQiACY;
				case AxisRange.Negative:
					return LrlbwFdVqTXHiNJRCEeCaoHmpfT;
				}
			}

			public override IControllerTemplateElement GetElement(int P_0)
			{
				return null;
			}

			public override int GetElementTargets(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				if (P_0.elementIdentifierId < 0)
				{
					return 0;
				}
				int num = 0;
				ControllerTemplateElementType controllerTemplateElementType = base.type;
				IControllerTemplateAxisSource controllerTemplateAxisSource = default(IControllerTemplateAxisSource);
				while (true)
				{
					int num2 = -116577095;
					while (true)
					{
						int num3;
						switch (num2 ^ -116577094)
						{
						case 9:
							break;
						case 4:
							ListTools.AddAndCreateList(ref P_1, new ControllerTemplateElementTarget(this, P_0.axisRange));
							num++;
							num2 = -116577098;
							continue;
						case 10:
							controllerTemplateAxisSource = pjZjqriAjRgtRcmANkmfeRSKwaR;
							if (controllerTemplateAxisSource.splitAxis)
							{
								if (sssIkmTnNOPAqsKgMlEiVVTuBVR(P_0, controllerTemplateAxisSource.positiveTarget))
								{
									ListTools.AddAndCreateList(ref P_1, new ControllerTemplateElementTarget(this, AxisRange.Positive));
									num++;
									num2 = -116577096;
									continue;
								}
								goto case 2;
							}
							goto case 6;
						case 1:
							throw new NotImplementedException();
						case 2:
							if (sssIkmTnNOPAqsKgMlEiVVTuBVR(P_0, controllerTemplateAxisSource.negativeTarget))
							{
								ListTools.AddAndCreateList(ref P_1, new ControllerTemplateElementTarget(this, AxisRange.Negative));
								num2 = -116577094;
								continue;
							}
							goto default;
						case 0:
							num++;
							num2 = -116577098;
							continue;
						case 5:
							ListTools.AddAndCreateList(ref P_1, new ControllerTemplateElementTarget(this, AxisRange.Full));
							num2 = -116577102;
							continue;
						case 8:
							num++;
							num2 = -116577098;
							continue;
						case 7:
							goto IL_0126;
						case 11:
							num2 = -116577093;
							continue;
						case 3:
							switch (controllerTemplateElementType)
							{
							case ControllerTemplateElementType.Axis:
								break;
							case ControllerTemplateElementType.Button:
								goto IL_0126;
							default:
								goto IL_0165;
							}
							goto case 10;
						case 6:
						{
							int num4;
							if (!sssIkmTnNOPAqsKgMlEiVVTuBVR(P_0, controllerTemplateAxisSource.fullTarget))
							{
								num2 = -116577098;
								num4 = num2;
							}
							else
							{
								num2 = -116577090;
								num4 = num2;
							}
							continue;
						}
						default:
							{
								return num;
							}
							IL_0165:
							num2 = -116577103;
							continue;
							IL_0126:
							if (sssIkmTnNOPAqsKgMlEiVVTuBVR(P_0, ((IControllerTemplateButtonSource)pjZjqriAjRgtRcmANkmfeRSKwaR).target))
							{
								num2 = -116577089;
								num3 = num2;
							}
							else
							{
								num2 = -116577098;
								num3 = num2;
							}
							continue;
						}
						break;
					}
				}
			}

			private static bool sssIkmTnNOPAqsKgMlEiVVTuBVR(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				if (P_1.elementIdentifierId != P_0.elementIdentifierId)
				{
					goto IL_000f;
				}
				ControllerElementType elementType = P_1.elementType;
				ControllerElementType controllerElementType = elementType;
				int num = 1435436998;
				goto IL_0014;
				IL_0014:
				while (true)
				{
					switch (num ^ 0x558F07C2)
					{
					case 0:
						break;
					case 3:
						return false;
					case 4:
						switch (controllerElementType)
						{
						case ControllerElementType.Axis:
							break;
						case ControllerElementType.Button:
							return true;
						default:
							throw new NotImplementedException();
						}
						goto case 1;
					case 1:
					{
						AxisRange axisRange = P_1.axisRange;
						if (axisRange == AxisRange.Full)
						{
							return true;
						}
						if (axisRange == P_0.axisRange)
						{
							goto IL_0074;
						}
						return false;
					}
					default:
						return true;
					}
					break;
					IL_0074:
					num = 1435436992;
				}
				goto IL_000f;
				IL_000f:
				num = 1435436993;
				goto IL_0014;
			}
		}

		internal sealed class tBNLiiJgIcMsUBoZQvzFXzKvOxV : UDauPmAdOcMEjsLbmuQqmkmgNY
		{
			public tBNLiiJgIcMsUBoZQvzFXzKvOxV(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, qFwngCMEUbVOUWUBpxMUVdPUzPt target, IList<rlMFrkSNhflWEbbAbNShgGYIzlu> sourceElements)
				: base(parent, id, name, positiveName, negativeName, ControllerTemplateElementType.Axis, target, sourceElements)
			{
				if (sourceElements != null && sourceElements.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static tBNLiiJgIcMsUBoZQvzFXzKvOxV EacwNkMfYaHjbQRdeDfnuPOoebXI(IControllerTemplate P_0)
			{
				return new tBNLiiJgIcMsUBoZQvzFXzKvOxV(P_0, -1, string.Empty, string.Empty, string.Empty, qFwngCMEUbVOUWUBpxMUVdPUzPt.EacwNkMfYaHjbQRdeDfnuPOoebXI(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class WpdFlzbEtczXLQnJHCtnHeOuktW : UDauPmAdOcMEjsLbmuQqmkmgNY
		{
			public WpdFlzbEtczXLQnJHCtnHeOuktW(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, qFwngCMEUbVOUWUBpxMUVdPUzPt target, IList<rlMFrkSNhflWEbbAbNShgGYIzlu> sourceElements)
				: base(parent, id, name, positiveName, negativeName, ControllerTemplateElementType.Button, target, sourceElements)
			{
				if (sourceElements != null && sourceElements.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static WpdFlzbEtczXLQnJHCtnHeOuktW EacwNkMfYaHjbQRdeDfnuPOoebXI(IControllerTemplate P_0)
			{
				return new WpdFlzbEtczXLQnJHCtnHeOuktW(P_0, -1, string.Empty, string.Empty, string.Empty, qFwngCMEUbVOUWUBpxMUVdPUzPt.EacwNkMfYaHjbQRdeDfnuPOoebXI(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class yPzRqVcgcVcOvOJlFWoFIMAynfK : QgSdyGzqsrxSGVEZPuwJASSKdjd
		{
			protected readonly int MyNJRXLJmKCNcpkEAMoRJKKLEAYf;

			protected readonly QgSdyGzqsrxSGVEZPuwJASSKdjd[] SERTGFptqMjtvIPNWFYznVbzAwf;

			public override bool exists
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						goto IL_0019;
					}
					int num = 0;
					int num2 = 1548149805;
					goto IL_001e;
					IL_001e:
					while (true)
					{
						switch (num2 ^ 0x5C46E42C)
						{
						case 2:
							break;
						case 3:
							return false;
						case 0:
							if (!SERTGFptqMjtvIPNWFYznVbzAwf[num].exists)
							{
								goto IL_0057;
							}
							return true;
						default:
							if (num >= MyNJRXLJmKCNcpkEAMoRJKKLEAYf)
							{
								return false;
							}
							goto case 0;
						}
						break;
						IL_0057:
						num++;
						num2 = 1548149805;
					}
					goto IL_0019;
					IL_0019:
					num2 = 1548149807;
					goto IL_001e;
				}
			}

			public override IControllerTemplateElementSource source
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return null;
				}
			}

			public override int elementCount
			{
				get
				{
					return MyNJRXLJmKCNcpkEAMoRJKKLEAYf;
				}
			}

			protected yPzRqVcgcVcOvOJlFWoFIMAynfK(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, QgSdyGzqsrxSGVEZPuwJASSKdjd[] elements)
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
				SERTGFptqMjtvIPNWFYznVbzAwf = elements;
				MyNJRXLJmKCNcpkEAMoRJKKLEAYf = elements.Length;
			}

			public override IControllerTemplateElement GetElement(int P_0)
			{
				return SERTGFptqMjtvIPNWFYznVbzAwf[P_0];
			}

			public override int GetElementTargets(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				int num2 = 0;
				while (num2 < SERTGFptqMjtvIPNWFYznVbzAwf.Length)
				{
					while (true)
					{
						num += SERTGFptqMjtvIPNWFYznVbzAwf[num2].GetElementTargets(P_0, ref P_1);
						num2++;
						int num3 = -280474480;
						while (true)
						{
							switch (num3 ^ -280474478)
							{
							case 0:
								num3 = -280474477;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0024;
							}
							break;
						}
						continue;
						end_IL_0024:
						break;
					}
				}
				return num;
			}
		}

		internal abstract class YGKhMizCnedpqehdtMmiwEvLoat : yPzRqVcgcVcOvOJlFWoFIMAynfK, IControllerTemplateElement, IControllerTemplateAxis2D
		{
			protected const int sFkkjQyUWoOEGUsjBgGRawlsFyn = 0;

			protected const int LpxjSjhEOFFVRufcEVWbGPfONJN = 1;

			protected const int oHCXudHqsxdQTdLRSKqMjBWXSbog = 2;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return Vector2.zero;
					}
					return new Vector2((MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 0) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[0]).floatValue : 0f, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 1) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[1]).floatValue : 0f);
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						while (true)
						{
							int num = -1542194611;
							while (true)
							{
								switch (num ^ -1542194612)
								{
								case 2:
									break;
								case 1:
									goto IL_002b;
								default:
									return Vector2.zero;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num = -1542194612;
							}
						}
					}
					return new Vector2((MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 0) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[0]).floatValuePrev : 0f, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 1) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[1]).floatValuePrev : 0f);
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[1];
				}
			}

			protected YGKhMizCnedpqehdtMmiwEvLoat(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, QgSdyGzqsrxSGVEZPuwJASSKdjd[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal abstract class UpUEwdTTvOFgATFshDBLeowIyVJc : yPzRqVcgcVcOvOJlFWoFIMAynfK, IControllerTemplateElement, IControllerTemplateAxis3D
		{
			protected const int sFkkjQyUWoOEGUsjBgGRawlsFyn = 0;

			protected const int LpxjSjhEOFFVRufcEVWbGPfONJN = 1;

			protected const int DTATUJXkacHTyErvPWKksGSVdDDg = 2;

			protected const int oHCXudHqsxdQTdLRSKqMjBWXSbog = 3;

			public Vector3 value
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						goto IL_000d;
					}
					int num;
					if (MyNJRXLJmKCNcpkEAMoRJKKLEAYf <= 0)
					{
						num = -473201424;
						goto IL_0012;
					}
					float x = ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[0]).floatValue;
					goto IL_0066;
					IL_0012:
					switch (num ^ -473201424)
					{
					case 2:
						break;
					case 1:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return Vector3.zero;
					default:
						goto IL_004d;
					}
					goto IL_000d;
					IL_004d:
					x = 0f;
					goto IL_0066;
					IL_0066:
					return new Vector3(x, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 1) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[1]).floatValue : 0f, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 2) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[2]).floatValue : 0f);
					IL_000d:
					num = -473201423;
					goto IL_0012;
				}
			}

			public Vector3 valuePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						goto IL_0019;
					}
					int num;
					if (MyNJRXLJmKCNcpkEAMoRJKKLEAYf <= 0)
					{
						num = -1737936786;
						goto IL_001e;
					}
					float x = ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[0]).floatValuePrev;
					goto IL_0066;
					IL_001e:
					switch (num ^ -1737936788)
					{
					case 0:
						break;
					case 1:
						return Vector3.zero;
					default:
						goto IL_004d;
					}
					goto IL_0019;
					IL_004d:
					x = 0f;
					goto IL_0066;
					IL_0066:
					return new Vector3(x, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 1) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[1]).floatValuePrev : 0f, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 2) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[2]).floatValuePrev : 0f);
					IL_0019:
					num = -1737936787;
					goto IL_001e;
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[1];
				}
			}

			public IControllerTemplateAxis depth
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[2];
				}
			}

			protected UpUEwdTTvOFgATFshDBLeowIyVJc(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, QgSdyGzqsrxSGVEZPuwJASSKdjd[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal abstract class uxydodeweaeHWCGgEcCcmnfgWvV : yPzRqVcgcVcOvOJlFWoFIMAynfK, IControllerTemplateElement, IControllerTemplateAxis6D
		{
			protected const int IKIGwbycSHyQKiIWgzuTnzrJyPL = 0;

			protected const int FOLCQpHvgvNSzTGVCZwQwMBegBO = 1;

			protected const int mtxaYfNAckePpeoZYDVOeanxETzS = 2;

			protected const int LHdFHGBrqDIhZiksHtmHeVUdxrP = 3;

			protected const int keOibUawamgNqOycRxBzKFfwfNI = 4;

			protected const int kdvktnJOvWscglDJRLvKUvBttSP = 5;

			protected const int oHCXudHqsxdQTdLRSKqMjBWXSbog = 6;

			public Vector3 position
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return Vector3.zero;
					}
					return new Vector3((MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 0) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[0]).floatValue : 0f, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 1) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[1]).floatValue : 0f, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 2) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[2]).floatValue : 0f);
				}
			}

			public Vector3 positionPrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return Vector3.zero;
					}
					return new Vector3((MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 0) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[0]).floatValuePrev : 0f, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 1) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[1]).floatValuePrev : 0f, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 2) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[2]).floatValuePrev : 0f);
				}
			}

			public Vector3 rotation
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return Vector3.zero;
					}
					return new Vector3((MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 3) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[3]).floatValue : 0f, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 4) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[4]).floatValue : 0f, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 5) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[5]).floatValue : 0f);
				}
			}

			public Vector3 rotationPrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						goto IL_0019;
					}
					int num;
					if (MyNJRXLJmKCNcpkEAMoRJKKLEAYf <= 3)
					{
						num = 1269296711;
						goto IL_001e;
					}
					float x = ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[3]).floatValuePrev;
					goto IL_0066;
					IL_001e:
					switch (num ^ 0x4BA7EE47)
					{
					case 2:
						break;
					case 1:
						return Vector3.zero;
					default:
						goto IL_004d;
					}
					goto IL_0019;
					IL_004d:
					x = 0f;
					goto IL_0066;
					IL_0066:
					return new Vector3(x, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 4) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[4]).floatValuePrev : 0f, (MyNJRXLJmKCNcpkEAMoRJKKLEAYf > 5) ? ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[5]).floatValuePrev : 0f);
					IL_0019:
					num = 1269296710;
					goto IL_001e;
				}
			}

			public IControllerTemplateAxis positionX
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[0];
				}
			}

			public IControllerTemplateAxis positionY
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[1];
				}
			}

			public IControllerTemplateAxis positionZ
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[2];
				}
			}

			public IControllerTemplateAxis rotationX
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[3];
				}
			}

			public IControllerTemplateAxis rotationY
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[4];
				}
			}

			public IControllerTemplateAxis rotationZ
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[5];
				}
			}

			protected uxydodeweaeHWCGgEcCcmnfgWvV(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, QgSdyGzqsrxSGVEZPuwJASSKdjd[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal sealed class mKyQUnsGROodYjDTwMLuDBCbgnEk : UpUEwdTTvOFgATFshDBLeowIyVJc, IControllerTemplateElement, IControllerTemplateStick
		{
			private new const int oHCXudHqsxdQTdLRSKqMjBWXSbog = 3;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[2];
				}
			}

			private mKyQUnsGROodYjDTwMLuDBCbgnEk(IControllerTemplate parent, int id, string name, QgSdyGzqsrxSGVEZPuwJASSKdjd[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Stick, elements)
			{
				while (true)
				{
					switch (0x690A21B8 ^ 0x690A21BA)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						if (elements.Length != 3)
						{
							throw new ArgumentException("elements.Length must be " + 3);
						}
						return;
					case 1:
						return;
					}
				}
			}

			public mKyQUnsGROodYjDTwMLuDBCbgnEk(IControllerTemplate parent, int id, string name, UDauPmAdOcMEjsLbmuQqmkmgNY xAxis, UDauPmAdOcMEjsLbmuQqmkmgNY yAxis, UDauPmAdOcMEjsLbmuQqmkmgNY zAxis)
				: this(parent, id, name, new QgSdyGzqsrxSGVEZPuwJASSKdjd[3] { xAxis, yAxis, zAxis })
			{
			}
		}

		internal sealed class ftDvKTWdafBuuKtkJoadQljsejz : YGKhMizCnedpqehdtMmiwEvLoat, IControllerTemplateElement, IControllerTemplateThumbStick
		{
			private const int sdLVIYpWfSoMosTGrTEhIKDuwgj = 2;

			private new const int oHCXudHqsxdQTdLRSKqMjBWXSbog = 3;

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[2];
				}
			}

			private ftDvKTWdafBuuKtkJoadQljsejz(IControllerTemplate parent, int id, string name, QgSdyGzqsrxSGVEZPuwJASSKdjd[] elements)
				: base(parent, id, name, ControllerTemplateElementType.ThumbStick, elements)
			{
				if (elements.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal ftDvKTWdafBuuKtkJoadQljsejz(IControllerTemplate parent, int id, string name, UDauPmAdOcMEjsLbmuQqmkmgNY xAxis, UDauPmAdOcMEjsLbmuQqmkmgNY yAxis, UDauPmAdOcMEjsLbmuQqmkmgNY button)
				: this(parent, id, name, new QgSdyGzqsrxSGVEZPuwJASSKdjd[3] { xAxis, yAxis, button })
			{
			}
		}

		internal sealed class XokzMhnPecGHJSJjzVwYBfGTKpa : yPzRqVcgcVcOvOJlFWoFIMAynfK, IControllerTemplateElement, IControllerTemplateDPad
		{
			private const int ccLFiJQPiSyNadhPlGPBfxgeOSL = 0;

			private const int fWJccLGmCvdPutpcVmSJBoyAHZoZ = 1;

			private const int TQFCUbCDFeRtffrHLKsVbUXjVaB = 2;

			private const int tJtdQKRuYcpItjaXLswpNvUzBcn = 3;

			private const int NAEaeFNYqwdfnzecWOBWclGlOgz = 4;

			private const int oHCXudHqsxdQTdLRSKqMjBWXSbog = 5;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[0]).floatValue + ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[2]).floatValue * -1f, -1f, 1f), MathTools.Clamp(((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[3]).floatValue * -1f + ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[1]).floatValue, -1f, 1f));
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[0]).floatValuePrev + ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[2]).floatValuePrev * -1f, -1f, 1f), MathTools.Clamp(((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[3]).floatValuePrev * -1f + ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[1]).floatValuePrev, -1f, 1f));
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[0];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[1];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[2];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[3];
				}
			}

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[4];
				}
			}

			private XokzMhnPecGHJSJjzVwYBfGTKpa(IControllerTemplate parent, int id, string name, QgSdyGzqsrxSGVEZPuwJASSKdjd[] elements)
				: base(parent, id, name, ControllerTemplateElementType.DPad, elements)
			{
				if (elements.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal XokzMhnPecGHJSJjzVwYBfGTKpa(IControllerTemplate parent, int id, string name, UDauPmAdOcMEjsLbmuQqmkmgNY up, UDauPmAdOcMEjsLbmuQqmkmgNY right, UDauPmAdOcMEjsLbmuQqmkmgNY down, UDauPmAdOcMEjsLbmuQqmkmgNY left, UDauPmAdOcMEjsLbmuQqmkmgNY press)
				: this(parent, id, name, new QgSdyGzqsrxSGVEZPuwJASSKdjd[5] { up, right, down, left, press })
			{
			}
		}

		internal sealed class KQCfaqwElyAxiDalHTbvQWqRsrXV : yPzRqVcgcVcOvOJlFWoFIMAynfK, IControllerTemplateElement, IControllerTemplateThrottle
		{
			private const int JFfimMqWYazdbWeIxoXphMZMQBj = 0;

			private const int GaOHFZczjyGRHaUgJSeylMrLeMd = 1;

			private const int oHCXudHqsxdQTdLRSKqMjBWXSbog = 2;

			public float value
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[0]).floatValue;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					}
					return ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[0]).floatValuePrev;
				}
			}

			public IControllerTemplateAxis throttle
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[0];
				}
			}

			public IControllerTemplateButton minDetent
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[1];
				}
			}

			private KQCfaqwElyAxiDalHTbvQWqRsrXV(IControllerTemplate parent, int id, string name, QgSdyGzqsrxSGVEZPuwJASSKdjd[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Throttle, elements)
			{
				while (true)
				{
					switch (-39063412 ^ -39063411)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						if (elements.Length != 2)
						{
							throw new ArgumentException("elements.Length must be " + 2);
						}
						return;
					case 0:
						return;
					}
				}
			}

			internal KQCfaqwElyAxiDalHTbvQWqRsrXV(IControllerTemplate parent, int id, string name, UDauPmAdOcMEjsLbmuQqmkmgNY axis, UDauPmAdOcMEjsLbmuQqmkmgNY zeroDetentButton)
				: this(parent, id, name, new QgSdyGzqsrxSGVEZPuwJASSKdjd[2] { axis, zeroDetentButton })
			{
			}
		}

		internal sealed class humcueBFfIOwlLXRMeWWHueKVJzo : yPzRqVcgcVcOvOJlFWoFIMAynfK, IControllerTemplateElement, IControllerTemplateHat
		{
			private const int ccLFiJQPiSyNadhPlGPBfxgeOSL = 0;

			private const int GThsbcGRrquEThbXjJrVDOQseAO = 1;

			private const int fWJccLGmCvdPutpcVmSJBoyAHZoZ = 2;

			private const int bEtcJDDRKghEMbYVQLEqutrMksRh = 3;

			private const int TQFCUbCDFeRtffrHLKsVbUXjVaB = 4;

			private const int fLjnQFDkxYbDSwfIJpVmpKALKAX = 5;

			private const int tJtdQKRuYcpItjaXLswpNvUzBcn = 6;

			private const int MqUusfVlHHdIFBzdTKwYeoZnlgZ = 7;

			private const int oHCXudHqsxdQTdLRSKqMjBWXSbog = 8;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						goto IL_000d;
					}
					Vector2 result = default(Vector2);
					int num = 76970130;
					goto IL_0012;
					IL_0012:
					float floatValue2 = default(float);
					float floatValue = default(float);
					float floatValue3 = default(float);
					float floatValue4 = default(float);
					while (true)
					{
						switch (num ^ 0x4967892)
						{
						case 4:
							break;
						case 3:
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							return Vector2.zero;
						case 5:
							floatValue2 = ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[7]).floatValue;
							result.x += floatValue + floatValue3 - floatValue4 - floatValue2;
							num = 76970132;
							continue;
						case 1:
							result.y -= ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[4]).floatValue;
							result.x -= ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[6]).floatValue;
							floatValue = ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[1]).floatValue;
							floatValue3 = ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[3]).floatValue;
							floatValue4 = ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[5]).floatValue;
							num = 76970135;
							continue;
						case 6:
							result.y += floatValue + floatValue2 - floatValue3 - floatValue4;
							result.x = MathTools.Clamp(result.x, -1f, 1f);
							result.y = MathTools.Clamp(result.y, -1f, 1f);
							num = 76970128;
							continue;
						case 0:
							result.y += ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[0]).floatValue;
							result.x += ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[2]).floatValue;
							num = 76970131;
							continue;
						default:
							return result;
						}
						break;
					}
					goto IL_000d;
					IL_000d:
					num = 76970129;
					goto IL_0012;
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					while (true)
					{
						int num = -395536136;
						while (true)
						{
							switch (num ^ -395536134)
							{
							case 0:
								break;
							case 2:
								result.y += ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[0]).floatValuePrev;
								num = -395536133;
								continue;
							case 3:
								result.y -= ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[4]).floatValuePrev;
								num = -395536130;
								continue;
							case 1:
								result.x += ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[2]).floatValuePrev;
								num = -395536135;
								continue;
							default:
							{
								result.x -= ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[6]).floatValuePrev;
								float floatValuePrev = ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[1]).floatValuePrev;
								float floatValuePrev2 = ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[3]).floatValuePrev;
								float floatValuePrev3 = ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[5]).floatValuePrev;
								float floatValuePrev4 = ((UDauPmAdOcMEjsLbmuQqmkmgNY)SERTGFptqMjtvIPNWFYznVbzAwf[7]).floatValuePrev;
								result.x += floatValuePrev + floatValuePrev2 - floatValuePrev3 - floatValuePrev4;
								result.y += floatValuePrev + floatValuePrev4 - floatValuePrev2 - floatValuePrev3;
								result.x = MathTools.Clamp(result.x, -1f, 1f);
								result.y = MathTools.Clamp(result.y, -1f, 1f);
								return result;
							}
							}
							break;
						}
					}
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[0];
				}
			}

			public IControllerTemplateButton upRight
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						while (true)
						{
							int num = 70655475;
							while (true)
							{
								switch (num ^ 0x4361DF1)
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
								ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
								num = 70655472;
							}
						}
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[1];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[2];
				}
			}

			public IControllerTemplateButton downRight
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[3];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[4];
				}
			}

			public IControllerTemplateButton downLeft
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[5];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[6];
				}
			}

			public IControllerTemplateButton upLeft
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateButton)SERTGFptqMjtvIPNWFYznVbzAwf[7];
				}
			}

			private humcueBFfIOwlLXRMeWWHueKVJzo(IControllerTemplate parent, int id, string name, QgSdyGzqsrxSGVEZPuwJASSKdjd[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Hat, elements)
			{
				while (true)
				{
					int num = 642276103;
					while (true)
					{
						switch (num ^ 0x26485B06)
						{
						case 3:
							break;
						default:
							return;
						case 1:
						{
							int num2;
							if (elements.Length == 8)
							{
								num = 642276100;
								num2 = num;
							}
							else
							{
								num = 642276102;
								num2 = num;
							}
							continue;
						}
						case 0:
							throw new ArgumentException("elements.Length must be " + 8);
						case 2:
							return;
						}
						break;
					}
				}
			}

			internal humcueBFfIOwlLXRMeWWHueKVJzo(IControllerTemplate parent, int id, string name, UDauPmAdOcMEjsLbmuQqmkmgNY up, UDauPmAdOcMEjsLbmuQqmkmgNY upRight, UDauPmAdOcMEjsLbmuQqmkmgNY right, UDauPmAdOcMEjsLbmuQqmkmgNY downRight, UDauPmAdOcMEjsLbmuQqmkmgNY down, UDauPmAdOcMEjsLbmuQqmkmgNY downLeft, UDauPmAdOcMEjsLbmuQqmkmgNY left, UDauPmAdOcMEjsLbmuQqmkmgNY upLeft)
				: this(parent, id, name, new QgSdyGzqsrxSGVEZPuwJASSKdjd[8] { up, upRight, right, downRight, down, downLeft, left, upLeft })
			{
			}
		}

		internal sealed class xDrAlRNlQTKnyzSBxtrQQjnKAPIJ : YGKhMizCnedpqehdtMmiwEvLoat, IControllerTemplateElement, IControllerTemplateYoke
		{
			private new const int oHCXudHqsxdQTdLRSKqMjBWXSbog = 2;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[0];
				}
			}

			public IControllerTemplateAxis pushPull
			{
				get
				{
					if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
					{
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return null;
					}
					return (IControllerTemplateAxis)SERTGFptqMjtvIPNWFYznVbzAwf[1];
				}
			}

			private xDrAlRNlQTKnyzSBxtrQQjnKAPIJ(IControllerTemplate parent, int id, string name, QgSdyGzqsrxSGVEZPuwJASSKdjd[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Yoke, elements)
			{
			}

			internal xDrAlRNlQTKnyzSBxtrQQjnKAPIJ(IControllerTemplate parent, int id, string name, UDauPmAdOcMEjsLbmuQqmkmgNY rollAxis, UDauPmAdOcMEjsLbmuQqmkmgNY pitchAxis)
				: base(parent, id, name, ControllerTemplateElementType.Yoke, new QgSdyGzqsrxSGVEZPuwJASSKdjd[2] { rollAxis, pitchAxis })
			{
			}
		}

		internal sealed class VykWFAhQVgeGyDqgzGsBBSVFqcFd : uxydodeweaeHWCGgEcCcmnfgWvV, IControllerTemplateElement, IControllerTemplateStick6D
		{
			private new const int oHCXudHqsxdQTdLRSKqMjBWXSbog = 6;

			private VykWFAhQVgeGyDqgzGsBBSVFqcFd(IControllerTemplate parent, int id, string name, QgSdyGzqsrxSGVEZPuwJASSKdjd[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Stick6D, elements)
			{
			}

			internal VykWFAhQVgeGyDqgzGsBBSVFqcFd(IControllerTemplate parent, int id, string name, UDauPmAdOcMEjsLbmuQqmkmgNY positionX, UDauPmAdOcMEjsLbmuQqmkmgNY positionY, UDauPmAdOcMEjsLbmuQqmkmgNY positionZ, UDauPmAdOcMEjsLbmuQqmkmgNY rotationX, UDauPmAdOcMEjsLbmuQqmkmgNY rotationY, UDauPmAdOcMEjsLbmuQqmkmgNY rotationZ)
				: base(parent, id, name, ControllerTemplateElementType.Stick6D, new QgSdyGzqsrxSGVEZPuwJASSKdjd[6] { positionX, positionY, positionZ, rotationX, rotationY, rotationZ })
			{
			}
		}

		internal class rlMFrkSNhflWEbbAbNShgGYIzlu
		{
			public readonly Controller.Element nsrJcOgpcFdFnRaSgBMVkSZUgdlg;

			public readonly IControllerElementTarget nCWCOIOOofbnfixPcuUIeRfVqGi;

			public bool boolValue
			{
				get
				{
					if (nsrJcOgpcFdFnRaSgBMVkSZUgdlg == null)
					{
						return false;
					}
					float value;
					AxisRange axisRange2;
					switch (nsrJcOgpcFdFnRaSgBMVkSZUgdlg.type)
					{
					case ControllerElementType.Button:
						return (nsrJcOgpcFdFnRaSgBMVkSZUgdlg as Controller.Button).value;
					case ControllerElementType.Axis:
						{
							value = (nsrJcOgpcFdFnRaSgBMVkSZUgdlg as Controller.Axis).value;
							AxisRange axisRange = nCWCOIOOofbnfixPcuUIeRfVqGi.axisRange;
							axisRange2 = axisRange;
							int num = 1510519277;
							while (true)
							{
								switch (num ^ 0x5A08B1ED)
								{
								case 2:
									num = 1510519278;
									continue;
								case 3:
									break;
								case 0:
									goto IL_0085;
								default:
									goto IL_00a1;
								}
								break;
							}
							goto case ControllerElementType.Button;
						}
						IL_0085:
						switch (axisRange2)
						{
						case AxisRange.Full:
							break;
						case AxisRange.Positive:
							if (value > 0.01f)
							{
								return true;
							}
							goto end_IL_0019;
						case AxisRange.Negative:
							if (value < -0.01f)
							{
								return true;
							}
							goto end_IL_0019;
						default:
							goto end_IL_0019;
						}
						goto IL_00a1;
						IL_00a1:
						if (value > 0.01f)
						{
							return true;
						}
						if (value < -0.01f)
						{
							return true;
						}
						break;
						end_IL_0019:
						break;
					}
					return false;
				}
			}

			public bool boolValuePrev
			{
				get
				{
					if (nsrJcOgpcFdFnRaSgBMVkSZUgdlg == null)
					{
						return false;
					}
					ControllerElementType type = nsrJcOgpcFdFnRaSgBMVkSZUgdlg.type;
					float valuePrev = default(float);
					while (true)
					{
						int num = -2045642744;
						while (true)
						{
							switch (num ^ -2045642742)
							{
							case 5:
								break;
							case 2:
								switch (type)
								{
								case ControllerElementType.Button:
									goto IL_0084;
								case ControllerElementType.Axis:
									goto IL_0095;
								}
								num = -2045642741;
								continue;
							case 3:
								if (valuePrev > 0.01f)
								{
									return true;
								}
								if (valuePrev < -0.01f)
								{
									return true;
								}
								goto IL_00f6;
							case 6:
								goto IL_0084;
							case 4:
								return true;
							default:
								return true;
							case 1:
								goto IL_00f6;
								IL_0095:
								valuePrev = (nsrJcOgpcFdFnRaSgBMVkSZUgdlg as Controller.Axis).valuePrev;
								switch (nCWCOIOOofbnfixPcuUIeRfVqGi.axisRange)
								{
								case AxisRange.Full:
									break;
								case AxisRange.Positive:
									goto IL_0075;
								case AxisRange.Negative:
									goto IL_00d6;
								default:
									goto IL_00f6;
								}
								goto case 3;
								IL_00d6:
								if (valuePrev < -0.01f)
								{
									num = -2045642742;
									continue;
								}
								goto IL_00f6;
								IL_0084:
								return (nsrJcOgpcFdFnRaSgBMVkSZUgdlg as Controller.Button).valuePrev;
								IL_0075:
								if (valuePrev > 0.01f)
								{
									num = -2045642738;
									continue;
								}
								goto IL_00f6;
								IL_00f6:
								return false;
							}
							break;
						}
					}
				}
			}

			public bool justPressed
			{
				get
				{
					if (nsrJcOgpcFdFnRaSgBMVkSZUgdlg == null)
					{
						return false;
					}
					ControllerElementType type = nsrJcOgpcFdFnRaSgBMVkSZUgdlg.type;
					if (type == ControllerElementType.Button)
					{
						goto IL_001a;
					}
					int num;
					if (type == ControllerElementType.Axis)
					{
						num = 772002349;
						goto IL_001f;
					}
					goto IL_0084;
					IL_001f:
					while (true)
					{
						switch (num ^ 0x2E03D22D)
						{
						case 2:
							break;
						case 1:
							return (nsrJcOgpcFdFnRaSgBMVkSZUgdlg as Controller.Button).justPressed;
						case 0:
							goto IL_0057;
						default:
							return true;
						}
						break;
						IL_0057:
						if (MathTools.Abs(floatValue) > 0.01f && MathTools.Abs(floatValuePrev) <= 0.01f)
						{
							num = 772002350;
							continue;
						}
						goto IL_0084;
					}
					goto IL_001a;
					IL_001a:
					num = 772002348;
					goto IL_001f;
					IL_0084:
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (nsrJcOgpcFdFnRaSgBMVkSZUgdlg == null)
					{
						return false;
					}
					ControllerElementType type = nsrJcOgpcFdFnRaSgBMVkSZUgdlg.type;
					while (true)
					{
						int num = -1028303194;
						while (true)
						{
							switch (num ^ -1028303193)
							{
							case 2:
								break;
							case 1:
								switch (type)
								{
								case ControllerElementType.Button:
									num = -1028303196;
									continue;
								case ControllerElementType.Axis:
									if (MathTools.Abs(floatValue) <= 0.01f)
									{
										num = -1028303193;
										continue;
									}
									break;
								}
								goto IL_0084;
							case 3:
								return (nsrJcOgpcFdFnRaSgBMVkSZUgdlg as Controller.Button).justReleased;
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
					if (nsrJcOgpcFdFnRaSgBMVkSZUgdlg == null)
					{
						goto IL_000b;
					}
					ControllerElementType type = nsrJcOgpcFdFnRaSgBMVkSZUgdlg.type;
					ControllerElementType controllerElementType = type;
					int num = 1865202956;
					goto IL_0010;
					IL_0010:
					float value = default(float);
					AxisRange axisRange2 = default(AxisRange);
					while (true)
					{
						switch (num ^ 0x6F2CBD0E)
						{
						case 4:
							break;
						case 6:
							if (!(nsrJcOgpcFdFnRaSgBMVkSZUgdlg as Controller.Button).value)
							{
								return 0f;
							}
							return 1f;
						case 7:
							return value;
						case 5:
							return 0f;
						case 3:
							switch (axisRange2)
							{
							case AxisRange.Full:
								break;
							case AxisRange.Positive:
								goto IL_0078;
							case AxisRange.Negative:
								if (value < 0f)
								{
									return value;
								}
								goto IL_0106;
							default:
								goto IL_0106;
							}
							goto case 7;
						case 0:
						{
							AxisRange axisRange = nCWCOIOOofbnfixPcuUIeRfVqGi.axisRange;
							axisRange2 = axisRange;
							num = 1865202957;
							continue;
						}
						case 2:
							switch (controllerElementType)
							{
							case ControllerElementType.Button:
								break;
							case ControllerElementType.Axis:
								goto IL_005e;
							default:
								goto IL_0106;
							}
							goto case 6;
						default:
							{
								return value;
							}
							IL_005e:
							value = (nsrJcOgpcFdFnRaSgBMVkSZUgdlg as Controller.Axis).value;
							num = 1865202958;
							continue;
							IL_0078:
							if (value > 0f)
							{
								num = 1865202959;
								continue;
							}
							goto IL_0106;
							IL_0106:
							return 0f;
						}
						break;
					}
					goto IL_000b;
					IL_000b:
					num = 1865202955;
					goto IL_0010;
				}
			}

			public float floatValuePrev
			{
				get
				{
					if (nsrJcOgpcFdFnRaSgBMVkSZUgdlg == null)
					{
						return 0f;
					}
					float valuePrev = default(float);
					switch (nsrJcOgpcFdFnRaSgBMVkSZUgdlg.type)
					{
					case ControllerElementType.Button:
						while (true)
						{
							if (!(nsrJcOgpcFdFnRaSgBMVkSZUgdlg as Controller.Button).valuePrev)
							{
								int num = 344341669;
								while (true)
								{
									switch (num ^ 0x14863CA4)
									{
									case 3:
										num = 344341670;
										continue;
									case 2:
										break;
									case 1:
										return 0f;
									default:
										goto end_IL_0051;
									}
									break;
								}
								continue;
							}
							return 1f;
							continue;
							end_IL_0051:
							break;
						}
						goto IL_00b2;
					case ControllerElementType.Axis:
						{
							valuePrev = (nsrJcOgpcFdFnRaSgBMVkSZUgdlg as Controller.Axis).valuePrev;
							switch (nCWCOIOOofbnfixPcuUIeRfVqGi.axisRange)
							{
							case AxisRange.Full:
								break;
							case AxisRange.Positive:
								if (valuePrev > 0f)
								{
									return valuePrev;
								}
								goto end_IL_001d;
							case AxisRange.Negative:
								if (valuePrev < 0f)
								{
									return valuePrev;
								}
								goto end_IL_001d;
							default:
								goto end_IL_001d;
							}
							goto IL_00b2;
						}
						IL_00b2:
						return valuePrev;
						end_IL_001d:
						break;
					}
					return 0f;
				}
			}

			public rlMFrkSNhflWEbbAbNShgGYIzlu(IControllerElementTarget target, Controller.Element element)
			{
				while (true)
				{
					int num = -1195642870;
					while (true)
					{
						switch (num ^ -1195642872)
						{
						case 0:
							break;
						case 2:
							goto IL_0024;
						default:
							nCWCOIOOofbnfixPcuUIeRfVqGi = target;
							return;
						}
						break;
						IL_0024:
						nsrJcOgpcFdFnRaSgBMVkSZUgdlg = element;
						num = -1195642871;
					}
				}
			}

			public static rlMFrkSNhflWEbbAbNShgGYIzlu EacwNkMfYaHjbQRdeDfnuPOoebXI()
			{
				return new rlMFrkSNhflWEbbAbNShgGYIzlu(RPsfaUSCQTmtficMhKUbbYyMecr.EacwNkMfYaHjbQRdeDfnuPOoebXI(), null);
			}
		}

		internal class NTQeamxZJcOeTxKdrraxwupmbcy
		{
			public readonly Controller xwApvxwuWEivSrbItjIXHBzMlIz;

			public readonly IHardwareControllerTemplateMap_Internal eWwksNGDfrYHnxOTpLfKlyDWcwJ;

			public NTQeamxZJcOeTxKdrraxwupmbcy(Controller controller, IHardwareControllerTemplateMap_Internal templateMap)
			{
				if (controller == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (templateMap == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				xwApvxwuWEivSrbItjIXHBzMlIz = controller;
				eWwksNGDfrYHnxOTpLfKlyDWcwJ = templateMap;
			}
		}

		private readonly string EqppaAHmTQvmVSSZadzlNpPBbHM;

		private readonly Guid dZusnCybpGCwscophhHvAlacNbmR;

		private readonly Controller HUdfNKdOgxfoxjMZAKUlkQYPszXh;

		private readonly ADictionary<int, IControllerTemplateElement> edJpBRWMzLDFWGAvaqubNiceOqj;

		private readonly ADictionary<string, IControllerTemplateElement> IfQIywqEvYkHjQlgQMdsAQrbUPJ;

		private IControllerTemplateElement[] SERTGFptqMjtvIPNWFYznVbzAwf;

		private ReadOnlyCollection<IControllerTemplateElement> uYCZQbMkrLLRfaHNIaSBlhhdXMi;

		private readonly int znFtIaPrJLvdjPGCwXFaaAeLKcr;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				return HUdfNKdOgxfoxjMZAKUlkQYPszXh;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				return EqppaAHmTQvmVSSZadzlNpPBbHM;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Guid.Empty;
				}
				return dZusnCybpGCwscophhHvAlacNbmR;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				return uYCZQbMkrLLRfaHNIaSBlhhdXMi;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0;
				}
				return SERTGFptqMjtvIPNWFYznVbzAwf.Length;
			}
		}

		protected ControllerTemplate(object payload)
			: this((NTQeamxZJcOeTxKdrraxwupmbcy)payload)
		{
		}

		private ControllerTemplate(NTQeamxZJcOeTxKdrraxwupmbcy initializer)
		{
			if (initializer == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (initializer.xwApvxwuWEivSrbItjIXHBzMlIz == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (initializer.eWwksNGDfrYHnxOTpLfKlyDWcwJ == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			znFtIaPrJLvdjPGCwXFaaAeLKcr = ReInput.id;
			HUdfNKdOgxfoxjMZAKUlkQYPszXh = initializer.xwApvxwuWEivSrbItjIXHBzMlIz;
			IHardwareControllerTemplateMap_Internal eWwksNGDfrYHnxOTpLfKlyDWcwJ = initializer.eWwksNGDfrYHnxOTpLfKlyDWcwJ;
			EqppaAHmTQvmVSSZadzlNpPBbHM = eWwksNGDfrYHnxOTpLfKlyDWcwJ.name;
			dZusnCybpGCwscophhHvAlacNbmR = eWwksNGDfrYHnxOTpLfKlyDWcwJ.typeGuid;
			int elementIdentifierCount = eWwksNGDfrYHnxOTpLfKlyDWcwJ.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = eWwksNGDfrYHnxOTpLfKlyDWcwJ.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						qFwngCMEUbVOUWUBpxMUVdPUzPt qFwngCMEUbVOUWUBpxMUVdPUzPt3 = eWwksNGDfrYHnxOTpLfKlyDWcwJ.GetAxisTarget(HUdfNKdOgxfoxjMZAKUlkQYPszXh, templateElementIdentifier.id) ?? qFwngCMEUbVOUWUBpxMUVdPUzPt.EacwNkMfYaHjbQRdeDfnuPOoebXI(ControllerTemplateElementType.Axis);
						tBNLiiJgIcMsUBoZQvzFXzKvOxV item2 = new tBNLiiJgIcMsUBoZQvzFXzKvOxV(this, templateElementIdentifier.id, templateElementIdentifier.name, (!string.IsNullOrEmpty(templateElementIdentifier.positiveName)) ? templateElementIdentifier.positiveName : (templateElementIdentifier.name + " +"), (!string.IsNullOrEmpty(templateElementIdentifier.negativeName)) ? templateElementIdentifier.negativeName : (templateElementIdentifier.name + " -"), qFwngCMEUbVOUWUBpxMUVdPUzPt3, tXXUUMTLbwnHOSduhUfnFtuSOum(HUdfNKdOgxfoxjMZAKUlkQYPszXh, (IControllerTemplateAxisSource)qFwngCMEUbVOUWUBpxMUVdPUzPt3));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						qFwngCMEUbVOUWUBpxMUVdPUzPt qFwngCMEUbVOUWUBpxMUVdPUzPt2 = eWwksNGDfrYHnxOTpLfKlyDWcwJ.GetButtonTarget(HUdfNKdOgxfoxjMZAKUlkQYPszXh, templateElementIdentifier.id) ?? qFwngCMEUbVOUWUBpxMUVdPUzPt.EacwNkMfYaHjbQRdeDfnuPOoebXI(ControllerTemplateElementType.Button);
						WpdFlzbEtczXLQnJHCtnHeOuktW item = new WpdFlzbEtczXLQnJHCtnHeOuktW(this, templateElementIdentifier.id, templateElementIdentifier.name, templateElementIdentifier.name, templateElementIdentifier.name + " -", qFwngCMEUbVOUWUBpxMUVdPUzPt2, tXXUUMTLbwnHOSduhUfnFtuSOum(HUdfNKdOgxfoxjMZAKUlkQYPszXh, (IControllerTemplateButtonSource)qFwngCMEUbVOUWUBpxMUVdPUzPt2));
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
				IControllerTemplateElementIdentifier templateElementIdentifier2 = eWwksNGDfrYHnxOTpLfKlyDWcwJ.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = eWwksNGDfrYHnxOTpLfKlyDWcwJ.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				QgSdyGzqsrxSGVEZPuwJASSKdjd qgSdyGzqsrxSGVEZPuwJASSKdjd;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					qgSdyGzqsrxSGVEZPuwJASSKdjd = new ftDvKTWdafBuuKtkJoadQljsejz(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping5 != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping5.eid_axisX) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping5 != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping5.eid_axisY) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping5 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping5.eid_button) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					qgSdyGzqsrxSGVEZPuwJASSKdjd = new XokzMhnPecGHJSJjzVwYBfGTKpa(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping3 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping3.eid_up) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping3 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping3.eid_right) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping3 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping3.eid_down) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping3 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping3.eid_left) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping3 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping3.eid_press) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					qgSdyGzqsrxSGVEZPuwJASSKdjd = new mKyQUnsGROodYjDTwMLuDBCbgnEk(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping2 != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping2.eid_axisX) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping2 != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping2.eid_axisY) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping2 != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping2.eid_axisZ) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					qgSdyGzqsrxSGVEZPuwJASSKdjd = new KQCfaqwElyAxiDalHTbvQWqRsrXV(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping6 != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping6.eid_axis) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping6 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping6.eid_minDetent) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					qgSdyGzqsrxSGVEZPuwJASSKdjd = new humcueBFfIOwlLXRMeWWHueKVJzo(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping7 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping7.eid_up) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping7 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping7.eid_upRight) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping7 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping7.eid_right) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping7 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping7.eid_downRight) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping7 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping7.eid_down) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping7 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping7.eid_downLeft) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping7 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping7.eid_left) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping7 != null) ? PewicdxVsQxhCAlIwGlsfgOPLTyg(this, aDictionary, mapping7.eid_upLeft) : WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					qgSdyGzqsrxSGVEZPuwJASSKdjd = new xDrAlRNlQTKnyzSBxtrQQjnKAPIJ(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping4 != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping4.eid_axisX) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping4 != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping4.eid_axisZ) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(string.Concat(templateElementIdentifier2.elementType, " element missing for Element Identifier Id ", templateElementIdentifier2.id));
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					qgSdyGzqsrxSGVEZPuwJASSKdjd = new VykWFAhQVgeGyDqgzGsBBSVFqcFd(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping.eid_positionX) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping.eid_positionY) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping.eid_positionZ) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping.eid_rotationX) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping.eid_rotationY) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this), (mapping != null) ? gnpVykynzFPsfLymEnAunGPAlzV(this, aDictionary, mapping.eid_rotationZ) : tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (qgSdyGzqsrxSGVEZPuwJASSKdjd != null)
				{
					list4.Add(qgSdyGzqsrxSGVEZPuwJASSKdjd);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			SERTGFptqMjtvIPNWFYznVbzAwf = list.ToArray();
			edJpBRWMzLDFWGAvaqubNiceOqj = aDictionary;
			IfQIywqEvYkHjQlgQMdsAQrbUPJ = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < SERTGFptqMjtvIPNWFYznVbzAwf.Length; num++)
			{
				IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor = eWwksNGDfrYHnxOTpLfKlyDWcwJ.GetTemplateElementIdentifierById(SERTGFptqMjtvIPNWFYznVbzAwf[num].id) as IControllerTemplateElementIdentifier_Editor;
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
							IfQIywqEvYkHjQlgQMdsAQrbUPJ.Add(text, SERTGFptqMjtvIPNWFYznVbzAwf[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + EqppaAHmTQvmVSSZadzlNpPBbHM + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			uYCZQbMkrLLRfaHNIaSBlhhdXMi = new ReadOnlyCollection<IControllerTemplateElement>(SERTGFptqMjtvIPNWFYznVbzAwf);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			IControllerTemplateElement value;
			if (!edJpBRWMzLDFWGAvaqubNiceOqj.TryGetValue(id, out value))
			{
				object[] array = default(object[]);
				while (true)
				{
					int num = -1483747481;
					while (true)
					{
						switch (num ^ -1483747485)
						{
						case 0:
							break;
						case 4:
							array = new object[5] { "There is no element with the id \"", null, null, null, null };
							num = -1483747487;
							continue;
						case 2:
							array[1] = id;
							array[2] = "\" in the ";
							array[3] = GetType().ToString();
							num = -1483747486;
							continue;
						case 1:
							array[4] = ".";
							Logger.LogWarning(string.Concat(array));
							num = -1483747488;
							continue;
						default:
							goto end_IL_0010;
						}
						break;
					}
					continue;
					end_IL_0010:
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			return GetElement(P_0);
		}

		T IControllerTemplate.GetElement<T>(int P_0)
		{
			T result = default(T);
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					int num = -1061820358;
					while (true)
					{
						switch (num ^ -1061820360)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return result;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						result = null;
						num = -1061820359;
					}
				}
			}
			return GetElement<T>(P_0);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget P_0, IList<ControllerTemplateElementTarget> P_1)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0;
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			return YRsQyehzCjjhjMwbaeUUUlHFftY(P_0, ref P_1);
		}

		private int YRsQyehzCjjhjMwbaeUUUlHFftY(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
		{
			if (P_1 != null)
			{
				goto IL_0007;
			}
			goto IL_008b;
			IL_0007:
			int num = 1608824880;
			goto IL_000c;
			IL_000c:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x5FE4B831)
				{
				case 5:
					break;
				case 7:
					num = 1608824885;
					continue;
				case 2:
					num2++;
					num = 1608824885;
					continue;
				case 0:
					if (InputTools.IsMappableType(SERTGFptqMjtvIPNWFYznVbzAwf[num2].type))
					{
						num3 += (SERTGFptqMjtvIPNWFYznVbzAwf[num2] as IControllerTemplateElement_Internal).GetElementTargets(P_0, ref P_1);
						num = 1608824883;
						continue;
					}
					goto case 2;
				case 1:
					P_1.Clear();
					num = 1608824882;
					continue;
				case 3:
					goto IL_008b;
				case 6:
					num2 = 0;
					num = 1608824886;
					continue;
				default:
					if (num2 >= SERTGFptqMjtvIPNWFYznVbzAwf.Length)
					{
						return num3;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0007;
			IL_008b:
			num3 = 0;
			num = 1608824887;
			goto IL_000c;
		}

		[CustomObfuscation(rename = false)]
		internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
		{
			while (true)
			{
				switch (0x2441D8A2 ^ 0x2441D8A3)
				{
				case 2:
					continue;
				case 1:
					switch (elementType)
					{
					case ControllerTemplateElementType.Axis:
						break;
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
					break;
				}
				break;
			}
			return typeof(IControllerTemplateAxis);
		}

		private static IList<rlMFrkSNhflWEbbAbNShgGYIzlu> tXXUUMTLbwnHOSduhUfnFtuSOum(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			IList<rlMFrkSNhflWEbbAbNShgGYIzlu> list;
			bool flag;
			if (P_1.splitAxis)
			{
				list = null;
				flag = false;
				if (P_1.positiveTarget != null)
				{
					Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					if (elementById != null)
					{
						ListTools.AddAndCreateList(ref list, new rlMFrkSNhflWEbbAbNShgGYIzlu(P_1.positiveTarget, elementById));
						flag = true;
						goto IL_004d;
					}
				}
				goto IL_00ef;
			}
			return tXXUUMTLbwnHOSduhUfnFtuSOum(P_0, P_1.fullTarget);
			IL_0052:
			int num;
			while (true)
			{
				switch (num ^ 0x720384C2)
				{
				case 3:
					break;
				case 0:
					flag = true;
					num = 1912833220;
					continue;
				case 2:
					goto IL_0087;
				case 6:
					goto IL_00c1;
				case 1:
					ListTools.AddAndCreateList(ref list, rlMFrkSNhflWEbbAbNShgGYIzlu.EacwNkMfYaHjbQRdeDfnuPOoebXI());
					num = 1912833223;
					continue;
				case 4:
					goto IL_00ef;
				default:
					return list;
				}
				break;
			}
			goto IL_004d;
			IL_004d:
			num = 1912833222;
			goto IL_0052;
			IL_00c1:
			int num2;
			if (!flag)
			{
				num = 1912833219;
				num2 = num;
			}
			else
			{
				num = 1912833223;
				num2 = num;
			}
			goto IL_0052;
			IL_00ef:
			if (!flag)
			{
				ListTools.AddAndCreateList(ref list, rlMFrkSNhflWEbbAbNShgGYIzlu.EacwNkMfYaHjbQRdeDfnuPOoebXI());
				num = 1912833216;
				goto IL_0052;
			}
			goto IL_0087;
			IL_0087:
			flag = false;
			if (P_1.negativeTarget != null)
			{
				Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
				if (elementById2 != null)
				{
					ListTools.AddAndCreateList(ref list, new rlMFrkSNhflWEbbAbNShgGYIzlu(P_1.negativeTarget, elementById2));
					num = 1912833218;
					goto IL_0052;
				}
			}
			goto IL_00c1;
		}

		private static IList<rlMFrkSNhflWEbbAbNShgGYIzlu> tXXUUMTLbwnHOSduhUfnFtuSOum(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return tXXUUMTLbwnHOSduhUfnFtuSOum(P_0, P_1.target);
		}

		private static IList<rlMFrkSNhflWEbbAbNShgGYIzlu> tXXUUMTLbwnHOSduhUfnFtuSOum(Controller P_0, IControllerElementTarget P_1)
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
			List<rlMFrkSNhflWEbbAbNShgGYIzlu> list = new List<rlMFrkSNhflWEbbAbNShgGYIzlu>();
			list.Add(new rlMFrkSNhflWEbbAbNShgGYIzlu(P_1, elementById));
			return list;
		}

		private static IControllerTemplateElement PPScODKITNkJhuhwQPXehuNrLBk(List<IControllerTemplateElement> P_0, int P_1)
		{
			int count = P_0.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < count)
				{
					num2 = 1971863132;
					num3 = num2;
				}
				else
				{
					num2 = 1971863134;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x75883E5F)
					{
					case 2:
						num2 = 1971863132;
						continue;
					case 3:
						if (P_0[num].id == P_1)
						{
							return P_0[num];
						}
						num++;
						num2 = 1971863135;
						continue;
					case 0:
						break;
					default:
						return null;
					}
					break;
				}
			}
		}

		private static UDauPmAdOcMEjsLbmuQqmkmgNY gnpVykynzFPsfLymEnAunGPAlzV(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			UDauPmAdOcMEjsLbmuQqmkmgNY uDauPmAdOcMEjsLbmuQqmkmgNY = P_1.GetValueSafe(P_2) as UDauPmAdOcMEjsLbmuQqmkmgNY;
			if (uDauPmAdOcMEjsLbmuQqmkmgNY == null)
			{
				return tBNLiiJgIcMsUBoZQvzFXzKvOxV.EacwNkMfYaHjbQRdeDfnuPOoebXI(P_0);
			}
			return uDauPmAdOcMEjsLbmuQqmkmgNY;
		}

		private static UDauPmAdOcMEjsLbmuQqmkmgNY PewicdxVsQxhCAlIwGlsfgOPLTyg(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			UDauPmAdOcMEjsLbmuQqmkmgNY uDauPmAdOcMEjsLbmuQqmkmgNY = P_1.GetValueSafe(P_2) as UDauPmAdOcMEjsLbmuQqmkmgNY;
			if (uDauPmAdOcMEjsLbmuQqmkmgNY == null)
			{
				return WpdFlzbEtczXLQnJHCtnHeOuktW.EacwNkMfYaHjbQRdeDfnuPOoebXI(P_0);
			}
			return uDauPmAdOcMEjsLbmuQqmkmgNY;
		}
	}
}
