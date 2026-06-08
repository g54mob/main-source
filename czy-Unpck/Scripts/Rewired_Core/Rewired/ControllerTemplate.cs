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
		internal abstract class CVATTEpbHdlDkMLkuVxYvdqXdlD : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate ZcHJtpUHuctAcnqSflrxCAOupGj;

			private readonly int tqPurZpByiUWRrPJKwHxxaZZua;

			private readonly string SQlNTEPvaCuPzRHxRVAmonHCzna;

			private readonly ControllerTemplateElementType mlHEPMoLvhyxVvGHhIjSYBQKMrF;

			protected readonly int vuPDNwATQFuTZgAqTRoviXUGAgFM;

			public int id
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return -1;
					}
					return tqPurZpByiUWRrPJKwHxxaZZua;
				}
			}

			public string descriptiveName
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						while (true)
						{
							int num = -1500305805;
							while (true)
							{
								switch (num ^ -1500305806)
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
								ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
								num = -1500305806;
							}
						}
					}
					return SQlNTEPvaCuPzRHxRVAmonHCzna;
				}
			}

			public ControllerTemplateElementType type
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return ControllerTemplateElementType.Axis;
					}
					return mlHEPMoLvhyxVvGHhIjSYBQKMrF;
				}
			}

			public IControllerTemplate parent => ZcHJtpUHuctAcnqSflrxCAOupGj;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected CVATTEpbHdlDkMLkuVxYvdqXdlD(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType)
			{
				while (true)
				{
					int num = 1239805177;
					while (true)
					{
						switch (num ^ 0x49E5ECFA)
						{
						case 0:
							break;
						case 3:
						{
							int num2;
							if (parent == null)
							{
								num = 1239805179;
								num2 = num;
							}
							else
							{
								num = 1239805176;
								num2 = num;
							}
							continue;
						}
						case 1:
							throw new ArgumentNullException("parent");
						default:
							ZcHJtpUHuctAcnqSflrxCAOupGj = parent;
							tqPurZpByiUWRrPJKwHxxaZZua = id;
							SQlNTEPvaCuPzRHxRVAmonHCzna = name;
							mlHEPMoLvhyxVvGHhIjSYBQKMrF = elementType;
							vuPDNwATQFuTZgAqTRoviXUGAgFM = ReInput.id;
							return;
						}
						break;
					}
				}
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);
		}

		internal abstract class GrPDwPnbgQBrgBfmxcnAjJNdqFKM : CVATTEpbHdlDkMLkuVxYvdqXdlD
		{
			protected readonly int HRRVXhqsZoMsAKjHSVwAjzEWzDA;

			protected readonly noIWpqWnsjqLgoPJQWgwJuoJvQS[] NKEGlkZcaAJXypUCGNkKWLiWbmJI;

			public override bool exists
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					if (NKEGlkZcaAJXypUCGNkKWLiWbmJI == null)
					{
						return false;
					}
					int num = 0;
					while (num < NKEGlkZcaAJXypUCGNkKWLiWbmJI.Length)
					{
						while (true)
						{
							if (NKEGlkZcaAJXypUCGNkKWLiWbmJI[num].rtbAYIiFFNDhBOhoXbvIEvxNbpHC != null)
							{
								return true;
							}
							num++;
							int num2 = 1369985247;
							while (true)
							{
								switch (num2 ^ 0x51A850DE)
								{
								case 0:
									num2 = 1369985244;
									continue;
								case 2:
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

			protected GrPDwPnbgQBrgBfmxcnAjJNdqFKM(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, IList<noIWpqWnsjqLgoPJQWgwJuoJvQS> sourceElements)
				: base(parent, id, name, elementType)
			{
				NKEGlkZcaAJXypUCGNkKWLiWbmJI = ((sourceElements != null) ? ListTools.ToArray(sourceElements) : null);
				HRRVXhqsZoMsAKjHSVwAjzEWzDA = ((NKEGlkZcaAJXypUCGNkKWLiWbmJI != null) ? NKEGlkZcaAJXypUCGNkKWLiWbmJI.Length : 0);
			}
		}

		internal abstract class MGLDGFbqSUiEcEarhSZBmXCrpyuD : GrPDwPnbgQBrgBfmxcnAjJNdqFKM, IControllerTemplateElement, IControllerTemplateAxis, IControllerTemplateButton
		{
			private aZegFSKVtbYbsDQcYCKVgyHJAnPy zYRfDpaHKTeTtdnogfJyqPkHckpW;

			private string JtzopdIHxWLPLaVQuUukKWkpuUe;

			private string VKbMVhnRxNfImAtOjFDkLjdddnS;

			public float floatValue
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						goto IL_000d;
					}
					if (HRRVXhqsZoMsAKjHSVwAjzEWzDA == 1)
					{
						return NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].floatValue;
					}
					int num;
					if (HRRVXhqsZoMsAKjHSVwAjzEWzDA == 2)
					{
						num = 551564215;
						goto IL_0012;
					}
					return 0f;
					IL_0012:
					float num3 = default(float);
					while (true)
					{
						switch (num ^ 0x20E033B4)
						{
						case 4:
							break;
						case 1:
							ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num = 551564214;
							continue;
						case 3:
							num3 = NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].floatValue;
							num = 551564212;
							continue;
						case 2:
							return 0f;
						default:
						{
							float num2 = NKEGlkZcaAJXypUCGNkKWLiWbmJI[1].floatValue;
							return MathTools.Clamp(num3 + num2, -1f, 1f);
						}
						}
						break;
					}
					goto IL_000d;
					IL_000d:
					num = 551564213;
					goto IL_0012;
				}
			}

			public float floatValuePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					if (HRRVXhqsZoMsAKjHSVwAjzEWzDA == 1)
					{
						return NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].floatValuePrev;
					}
					if (HRRVXhqsZoMsAKjHSVwAjzEWzDA == 2)
					{
						float num = NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].floatValuePrev;
						float num2 = NKEGlkZcaAJXypUCGNkKWLiWbmJI[1].floatValuePrev;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool boolValue
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					if (HRRVXhqsZoMsAKjHSVwAjzEWzDA == 1)
					{
						return NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].boolValue;
					}
					if (HRRVXhqsZoMsAKjHSVwAjzEWzDA == 2)
					{
						if (!NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].boolValue)
						{
							return NKEGlkZcaAJXypUCGNkKWLiWbmJI[1].boolValue;
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
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					if (HRRVXhqsZoMsAKjHSVwAjzEWzDA == 1)
					{
						return NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].boolValuePrev;
					}
					if (HRRVXhqsZoMsAKjHSVwAjzEWzDA == 2)
					{
						while (true)
						{
							int num = -305242055;
							while (true)
							{
								switch (num ^ -305242056)
								{
								case 2:
									break;
								case 1:
									if (!NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].boolValuePrev)
									{
										goto IL_0068;
									}
									return true;
								default:
									return NKEGlkZcaAJXypUCGNkKWLiWbmJI[1].boolValuePrev;
								}
								break;
								IL_0068:
								num = -305242056;
							}
						}
					}
					return false;
				}
			}

			string IControllerTemplateAxis.positiveDescriptiveName
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return JtzopdIHxWLPLaVQuUukKWkpuUe;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return VKbMVhnRxNfImAtOjFDkLjdddnS;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					return floatValue;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					return floatValuePrev;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return zYRfDpaHKTeTtdnogfJyqPkHckpW;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						while (true)
						{
							int num = 1434751216;
							while (true)
							{
								switch (num ^ 0x558490F1)
								{
								case 2:
									break;
								case 1:
									goto IL_002b;
								default:
									return false;
								}
								break;
								IL_002b:
								ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
								num = 1434751217;
							}
						}
					}
					return boolValue;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					return boolValuePrev;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					if (HRRVXhqsZoMsAKjHSVwAjzEWzDA == 1)
					{
						goto IL_0024;
					}
					int num;
					if (HRRVXhqsZoMsAKjHSVwAjzEWzDA == 2)
					{
						if (NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].justPressed)
						{
							if (NKEGlkZcaAJXypUCGNkKWLiWbmJI[1].boolValuePrev)
							{
								num = 1230524709;
								goto IL_0029;
							}
							return true;
						}
						goto IL_007e;
					}
					return false;
					IL_0029:
					switch (num ^ 0x49585124)
					{
					case 0:
						break;
					case 2:
						return NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].justPressed;
					default:
						goto IL_007e;
					}
					goto IL_0024;
					IL_007e:
					if (NKEGlkZcaAJXypUCGNkKWLiWbmJI[1].justPressed)
					{
						return !NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].boolValuePrev;
					}
					return false;
					IL_0024:
					num = 1230524710;
					goto IL_0029;
				}
			}

			bool IControllerTemplateButton.justReleased
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						goto IL_000d;
					}
					int num;
					if (HRRVXhqsZoMsAKjHSVwAjzEWzDA != 1)
					{
						if (HRRVXhqsZoMsAKjHSVwAjzEWzDA != 2)
						{
							return false;
						}
						if (!NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].justReleased)
						{
							goto IL_0085;
						}
						if (!NKEGlkZcaAJXypUCGNkKWLiWbmJI[1].boolValue)
						{
							return true;
						}
						num = 250818238;
					}
					else
					{
						num = 250818237;
					}
					goto IL_0012;
					IL_0012:
					while (true)
					{
						switch (num ^ 0xEF32EBF)
						{
						case 5:
							break;
						case 2:
							return NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].justReleased;
						case 3:
							return false;
						case 1:
							goto IL_0085;
						case 4:
							ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num = 250818236;
							continue;
						default:
							return !NKEGlkZcaAJXypUCGNkKWLiWbmJI[0].boolValue;
						}
						break;
					}
					goto IL_000d;
					IL_0085:
					if (NKEGlkZcaAJXypUCGNkKWLiWbmJI[1].justReleased)
					{
						num = 250818239;
						goto IL_0012;
					}
					return false;
					IL_000d:
					num = 250818235;
					goto IL_0012;
				}
			}

			bool IControllerTemplateButton.justChangedState
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return false;
					}
					return boolValue != boolValuePrev;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					return floatValue;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					return floatValuePrev;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return zYRfDpaHKTeTtdnogfJyqPkHckpW;
				}
			}

			public override IControllerTemplateElementSource source
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return zYRfDpaHKTeTtdnogfJyqPkHckpW;
				}
			}

			public override int elementCount => 0;

			public IControllerTemplateAxis AsAxis
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return this;
				}
			}

			public IControllerTemplateButton AsButton
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return this;
				}
			}

			protected MGLDGFbqSUiEcEarhSZBmXCrpyuD(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, ControllerTemplateElementType elementType, aZegFSKVtbYbsDQcYCKVgyHJAnPy target, IList<noIWpqWnsjqLgoPJQWgwJuoJvQS> sourceElements)
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
				zYRfDpaHKTeTtdnogfJyqPkHckpW = target;
				JtzopdIHxWLPLaVQuUukKWkpuUe = positiveName;
				VKbMVhnRxNfImAtOjFDkLjdddnS = negativeName;
			}

			private string gxMtKkQqurQUyGvEuEhAiBkBwWB(AxisRange P_0)
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					while (true)
					{
						switch (0xD91CC3 ^ 0xD91CC2)
						{
						case 0:
							continue;
						case 1:
							return null;
						}
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
						return JtzopdIHxWLPLaVQuUukKWkpuUe;
					case AxisRange.Negative:
						return VKbMVhnRxNfImAtOjFDkLjdddnS;
					default:
						throw new NotImplementedException();
					}
				}
				return base.descriptiveName;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in gxMtKkQqurQUyGvEuEhAiBkBwWB
				return this.gxMtKkQqurQUyGvEuEhAiBkBwWB(P_0);
			}

			public override IControllerTemplateElement GetElement(int index)
			{
				return null;
			}

			public override int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list)
			{
				if (find.elementIdentifierId < 0)
				{
					return 0;
				}
				int num = 0;
				int num2;
				IControllerTemplateAxisSource controllerTemplateAxisSource = default(IControllerTemplateAxisSource);
				int num4;
				switch (base.type)
				{
				default:
					num2 = 24702759;
					goto IL_0028;
				case ControllerTemplateElementType.Axis:
					goto IL_0135;
				case ControllerTemplateElementType.Button:
					goto IL_0154;
					IL_0028:
					while (true)
					{
						switch (num2 ^ 0x178EF2C)
						{
						case 0:
							break;
						case 3:
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
							num++;
							num2 = 24702763;
							continue;
						case 8:
							if (!controllerTemplateAxisSource.splitAxis)
							{
								goto IL_00b9;
							}
							if (gtcSWgHfsIBqIhuEbxVpiCpljDn(find, controllerTemplateAxisSource.positiveTarget))
							{
								ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
								num2 = 24702762;
								continue;
							}
							goto case 4;
						case 5:
							goto IL_00b9;
						case 11:
							num2 = 24702752;
							continue;
						case 10:
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Full));
							num++;
							num2 = 24702757;
							continue;
						case 9:
							num2 = 24702763;
							continue;
						case 4:
							if (gtcSWgHfsIBqIhuEbxVpiCpljDn(find, controllerTemplateAxisSource.negativeTarget))
							{
								ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
								num++;
								num2 = 24702763;
								continue;
							}
							goto default;
						case 1:
							goto IL_0135;
						case 6:
							num++;
							num2 = 24702760;
							continue;
						case 2:
							goto IL_0154;
						case 12:
							throw new NotImplementedException();
						default:
							return num;
						}
						break;
						IL_00b9:
						int num3;
						if (!gtcSWgHfsIBqIhuEbxVpiCpljDn(find, controllerTemplateAxisSource.fullTarget))
						{
							num2 = 24702763;
							num3 = num2;
						}
						else
						{
							num2 = 24702767;
							num3 = num2;
						}
					}
					goto default;
					IL_0154:
					if (gtcSWgHfsIBqIhuEbxVpiCpljDn(find, ((IControllerTemplateButtonSource)zYRfDpaHKTeTtdnogfJyqPkHckpW).target))
					{
						num2 = 24702758;
						num4 = num2;
					}
					else
					{
						num2 = 24702763;
						num4 = num2;
					}
					goto IL_0028;
					IL_0135:
					controllerTemplateAxisSource = zYRfDpaHKTeTtdnogfJyqPkHckpW;
					num2 = 24702756;
					goto IL_0028;
				}
			}

			private static bool gtcSWgHfsIBqIhuEbxVpiCpljDn(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				if (P_1.elementIdentifierId != P_0.elementIdentifierId)
				{
					return false;
				}
				ControllerElementType elementType = P_1.elementType;
				while (true)
				{
					switch (-1594334356 ^ -1594334354)
					{
					case 0:
						continue;
					case 2:
						switch (elementType)
						{
						case ControllerElementType.Axis:
							break;
						case ControllerElementType.Button:
							return true;
						default:
							throw new NotImplementedException();
						}
						break;
					}
					break;
				}
				AxisRange axisRange = P_1.axisRange;
				if (axisRange == AxisRange.Full)
				{
					return true;
				}
				if (axisRange == P_0.axisRange)
				{
					return true;
				}
				return false;
			}
		}

		internal sealed class bcTbEuZdnyLIiCwxhjYSqCkuLYx : MGLDGFbqSUiEcEarhSZBmXCrpyuD
		{
			public bcTbEuZdnyLIiCwxhjYSqCkuLYx(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, aZegFSKVtbYbsDQcYCKVgyHJAnPy target, IList<noIWpqWnsjqLgoPJQWgwJuoJvQS> sourceElements)
				: base(parent, id, name, positiveName, negativeName, ControllerTemplateElementType.Axis, target, sourceElements)
			{
				if (sourceElements != null && sourceElements.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static bcTbEuZdnyLIiCwxhjYSqCkuLYx WDwRGsIphwHRFBDBHPIyGNmfHrtw(IControllerTemplate P_0)
			{
				return new bcTbEuZdnyLIiCwxhjYSqCkuLYx(P_0, -1, string.Empty, string.Empty, string.Empty, aZegFSKVtbYbsDQcYCKVgyHJAnPy.WDwRGsIphwHRFBDBHPIyGNmfHrtw(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class QUtJhmWOBoxbIRbwkQsAZaMftmv : MGLDGFbqSUiEcEarhSZBmXCrpyuD
		{
			public QUtJhmWOBoxbIRbwkQsAZaMftmv(IControllerTemplate parent, int id, string name, string positiveName, string negativeName, aZegFSKVtbYbsDQcYCKVgyHJAnPy target, IList<noIWpqWnsjqLgoPJQWgwJuoJvQS> sourceElements)
				: base(parent, id, name, positiveName, negativeName, ControllerTemplateElementType.Button, target, sourceElements)
			{
				while (true)
				{
					switch (0x668A6DCF ^ 0x668A6DCD)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						if (sourceElements != null && sourceElements.Count > 1)
						{
							throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
						}
						return;
					case 1:
						return;
					}
				}
			}

			internal static QUtJhmWOBoxbIRbwkQsAZaMftmv WDwRGsIphwHRFBDBHPIyGNmfHrtw(IControllerTemplate P_0)
			{
				return new QUtJhmWOBoxbIRbwkQsAZaMftmv(P_0, -1, string.Empty, string.Empty, string.Empty, aZegFSKVtbYbsDQcYCKVgyHJAnPy.WDwRGsIphwHRFBDBHPIyGNmfHrtw(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class wuxEdkAyFXyYedJvmhblqxizhrkr : CVATTEpbHdlDkMLkuVxYvdqXdlD
		{
			protected readonly int MiDdvPDMZGcxOkAgrzXGgrkCNOi;

			protected readonly CVATTEpbHdlDkMLkuVxYvdqXdlD[] OZXcSZtVrQPQPLpKldDeETdguIN;

			public override bool exists
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						goto IL_0019;
					}
					int num = 0;
					int num2 = 686338472;
					goto IL_001e;
					IL_001e:
					while (true)
					{
						switch (num2 ^ 0x28E8B1A9)
						{
						case 0:
							break;
						case 2:
							return false;
						case 3:
							if (!OZXcSZtVrQPQPLpKldDeETdguIN[num].exists)
							{
								goto IL_0057;
							}
							return true;
						default:
							if (num >= MiDdvPDMZGcxOkAgrzXGgrkCNOi)
							{
								return false;
							}
							goto case 3;
						}
						break;
						IL_0057:
						num++;
						num2 = 686338472;
					}
					goto IL_0019;
					IL_0019:
					num2 = 686338475;
					goto IL_001e;
				}
			}

			public override IControllerTemplateElementSource source
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return null;
				}
			}

			public override int elementCount => MiDdvPDMZGcxOkAgrzXGgrkCNOi;

			protected wuxEdkAyFXyYedJvmhblqxizhrkr(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, CVATTEpbHdlDkMLkuVxYvdqXdlD[] elements)
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
				OZXcSZtVrQPQPLpKldDeETdguIN = elements;
				MiDdvPDMZGcxOkAgrzXGgrkCNOi = elements.Length;
			}

			public virtual IControllerTemplateElement WPeqKlrsUlCkyNVaxZHjSbqAJOj(int P_0)
			{
				return OZXcSZtVrQPQPLpKldDeETdguIN[P_0];
			}

			public virtual int KrcEjyfOjbRLBRFFPehBfdhCWhc(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				int num2 = 0;
				while (num2 < OZXcSZtVrQPQPLpKldDeETdguIN.Length)
				{
					while (true)
					{
						num += OZXcSZtVrQPQPLpKldDeETdguIN[num2].GetElementTargets(P_0, ref P_1);
						int num3 = 95527054;
						while (true)
						{
							switch (num3 ^ 0x5B1A08E)
							{
							case 2:
								num3 = 95527055;
								continue;
							case 1:
								break;
							case 0:
								num2++;
								num3 = 95527053;
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

		internal abstract class WxGBNCptdajTDGhXKsnxbBaMdgAV : wuxEdkAyFXyYedJvmhblqxizhrkr, IControllerTemplateElement, IControllerTemplateAxis2D
		{
			protected const int quaDNIkxlkogqRXNkhvEPOFtAmP = 0;

			protected const int ZTlwPpnafHXhvxtChtuifuTNqXl = 1;

			protected const int cSQSofJKDriUvGodhFhJoviKzeK = 2;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector2.zero;
					}
					return new Vector2((MiDdvPDMZGcxOkAgrzXGgrkCNOi > 0) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[0]).floatValue : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 1) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[1]).floatValue : 0f);
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector2.zero;
					}
					return new Vector2((MiDdvPDMZGcxOkAgrzXGgrkCNOi > 0) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[0]).floatValuePrev : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 1) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[1]).floatValuePrev : 0f);
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[1];
				}
			}

			protected WxGBNCptdajTDGhXKsnxbBaMdgAV(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, CVATTEpbHdlDkMLkuVxYvdqXdlD[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal abstract class KNAAAnZdWOqIoELOSeiAbXOZfBfP : wuxEdkAyFXyYedJvmhblqxizhrkr, IControllerTemplateElement, IControllerTemplateAxis3D
		{
			protected const int quaDNIkxlkogqRXNkhvEPOFtAmP = 0;

			protected const int ZTlwPpnafHXhvxtChtuifuTNqXl = 1;

			protected const int HESeZLFVamvWGmFpolFjpuBINTz = 2;

			protected const int cSQSofJKDriUvGodhFhJoviKzeK = 3;

			public Vector3 value
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector3.zero;
					}
					return new Vector3((MiDdvPDMZGcxOkAgrzXGgrkCNOi > 0) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[0]).floatValue : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 1) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[1]).floatValue : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 2) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[2]).floatValue : 0f);
				}
			}

			public Vector3 valuePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						goto IL_000d;
					}
					int num;
					if (MiDdvPDMZGcxOkAgrzXGgrkCNOi <= 0)
					{
						num = -471149673;
						goto IL_0012;
					}
					float x = ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[0]).floatValuePrev;
					goto IL_0066;
					IL_0012:
					switch (num ^ -471149673)
					{
					case 2:
						break;
					case 1:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector3.zero;
					default:
						goto IL_004d;
					}
					goto IL_000d;
					IL_004d:
					x = 0f;
					goto IL_0066;
					IL_0066:
					return new Vector3(x, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 1) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[1]).floatValuePrev : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 2) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[2]).floatValuePrev : 0f);
					IL_000d:
					num = -471149674;
					goto IL_0012;
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[1];
				}
			}

			public IControllerTemplateAxis depth
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[2];
				}
			}

			protected KNAAAnZdWOqIoELOSeiAbXOZfBfP(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, CVATTEpbHdlDkMLkuVxYvdqXdlD[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal abstract class amsSLboCVolIcJLGnPZtNbXnXEr : wuxEdkAyFXyYedJvmhblqxizhrkr, IControllerTemplateElement, IControllerTemplateAxis6D
		{
			protected const int KwUDylemhBAAqxMyHLSYUlPGBuze = 0;

			protected const int LrHWetXaYfNxDEBibOodVquttkl = 1;

			protected const int isrKcrJMJqcnHhwxlRoZNoLqbJZk = 2;

			protected const int NrrnStzRvTXdchAPwXKkVqmqpfo = 3;

			protected const int aYOEWQmHDeIKMBRWuiGgqzVbwdgW = 4;

			protected const int uApEXbVQGKWEUgjfmlGXbyxcDxl = 5;

			protected const int cSQSofJKDriUvGodhFhJoviKzeK = 6;

			public Vector3 position
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector3.zero;
					}
					return new Vector3((MiDdvPDMZGcxOkAgrzXGgrkCNOi > 0) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[0]).floatValue : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 1) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[1]).floatValue : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 2) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[2]).floatValue : 0f);
				}
			}

			public Vector3 positionPrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector3.zero;
					}
					return new Vector3((MiDdvPDMZGcxOkAgrzXGgrkCNOi > 0) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[0]).floatValuePrev : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 1) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[1]).floatValuePrev : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 2) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[2]).floatValuePrev : 0f);
				}
			}

			public Vector3 rotation
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector3.zero;
					}
					return new Vector3((MiDdvPDMZGcxOkAgrzXGgrkCNOi > 3) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[3]).floatValue : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 4) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[4]).floatValue : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 5) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[5]).floatValue : 0f);
				}
			}

			public Vector3 rotationPrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector3.zero;
					}
					return new Vector3((MiDdvPDMZGcxOkAgrzXGgrkCNOi > 3) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[3]).floatValuePrev : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 4) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[4]).floatValuePrev : 0f, (MiDdvPDMZGcxOkAgrzXGgrkCNOi > 5) ? ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[5]).floatValuePrev : 0f);
				}
			}

			public IControllerTemplateAxis positionX
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[0];
				}
			}

			public IControllerTemplateAxis positionY
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[1];
				}
			}

			public IControllerTemplateAxis positionZ
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[2];
				}
			}

			public IControllerTemplateAxis rotationX
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						while (true)
						{
							int num = 6877455;
							while (true)
							{
								switch (num ^ 0x68F10D)
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
								ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
								num = 6877452;
							}
						}
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[3];
				}
			}

			public IControllerTemplateAxis rotationY
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[4];
				}
			}

			public IControllerTemplateAxis rotationZ
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[5];
				}
			}

			protected amsSLboCVolIcJLGnPZtNbXnXEr(IControllerTemplate parent, int id, string name, ControllerTemplateElementType elementType, CVATTEpbHdlDkMLkuVxYvdqXdlD[] elements)
				: base(parent, id, name, elementType, elements)
			{
			}
		}

		internal sealed class cxoyVnkLqMVBqcObXuCbwMqgbQa : KNAAAnZdWOqIoELOSeiAbXOZfBfP, IControllerTemplateElement, IControllerTemplateStick
		{
			private new const int cSQSofJKDriUvGodhFhJoviKzeK = 3;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[2];
				}
			}

			private cxoyVnkLqMVBqcObXuCbwMqgbQa(IControllerTemplate parent, int id, string name, CVATTEpbHdlDkMLkuVxYvdqXdlD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Stick, elements)
			{
				if (elements.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			public cxoyVnkLqMVBqcObXuCbwMqgbQa(IControllerTemplate parent, int id, string name, MGLDGFbqSUiEcEarhSZBmXCrpyuD xAxis, MGLDGFbqSUiEcEarhSZBmXCrpyuD yAxis, MGLDGFbqSUiEcEarhSZBmXCrpyuD zAxis)
				: this(parent, id, name, new CVATTEpbHdlDkMLkuVxYvdqXdlD[3] { xAxis, yAxis, zAxis })
			{
			}
		}

		internal sealed class riByNVOkLtNxCLKCkNDshZZjoaN : WxGBNCptdajTDGhXKsnxbBaMdgAV, IControllerTemplateElement, IControllerTemplateThumbStick
		{
			private const int cxLgpSzvzYGMIEnrOIauebtnosFB = 2;

			private new const int cSQSofJKDriUvGodhFhJoviKzeK = 3;

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[2];
				}
			}

			private riByNVOkLtNxCLKCkNDshZZjoaN(IControllerTemplate parent, int id, string name, CVATTEpbHdlDkMLkuVxYvdqXdlD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.ThumbStick, elements)
			{
				if (elements.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal riByNVOkLtNxCLKCkNDshZZjoaN(IControllerTemplate parent, int id, string name, MGLDGFbqSUiEcEarhSZBmXCrpyuD xAxis, MGLDGFbqSUiEcEarhSZBmXCrpyuD yAxis, MGLDGFbqSUiEcEarhSZBmXCrpyuD button)
				: this(parent, id, name, new CVATTEpbHdlDkMLkuVxYvdqXdlD[3] { xAxis, yAxis, button })
			{
			}
		}

		internal sealed class PsufJGhUyiBwxcFrIUitnuTKpINu : wuxEdkAyFXyYedJvmhblqxizhrkr, IControllerTemplateElement, IControllerTemplateDPad
		{
			private const int aCHppPOlPSYMCkIhCRvKIaIdxEh = 0;

			private const int pqHGCButLxjTQoUJipZKFUrLJoY = 1;

			private const int XVTwcdAlgsNrFsgxsdhEEAbykFlB = 2;

			private const int vvfHuCDWfuoyLaIdqhFgmtmgjkN = 3;

			private const int FMCFITTyVcBDBcoIldaJLrasJyF = 4;

			private const int cSQSofJKDriUvGodhFhJoviKzeK = 5;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[0]).floatValue + ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[2]).floatValue * -1f, -1f, 1f), MathTools.Clamp(((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[3]).floatValue * -1f + ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[1]).floatValue, -1f, 1f));
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[0]).floatValuePrev + ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[2]).floatValuePrev * -1f, -1f, 1f), MathTools.Clamp(((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[3]).floatValuePrev * -1f + ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[1]).floatValuePrev, -1f, 1f));
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[0];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[1];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[2];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[3];
				}
			}

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[4];
				}
			}

			private PsufJGhUyiBwxcFrIUitnuTKpINu(IControllerTemplate parent, int id, string name, CVATTEpbHdlDkMLkuVxYvdqXdlD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.DPad, elements)
			{
				if (elements.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal PsufJGhUyiBwxcFrIUitnuTKpINu(IControllerTemplate parent, int id, string name, MGLDGFbqSUiEcEarhSZBmXCrpyuD up, MGLDGFbqSUiEcEarhSZBmXCrpyuD right, MGLDGFbqSUiEcEarhSZBmXCrpyuD down, MGLDGFbqSUiEcEarhSZBmXCrpyuD left, MGLDGFbqSUiEcEarhSZBmXCrpyuD press)
				: this(parent, id, name, new CVATTEpbHdlDkMLkuVxYvdqXdlD[5] { up, right, down, left, press })
			{
			}
		}

		internal sealed class ApIAEioHOqaZQhrNsgGmzvGMmxvG : wuxEdkAyFXyYedJvmhblqxizhrkr, IControllerTemplateElement, IControllerTemplateThrottle
		{
			private const int HcnASTapFgJEXLukEwAySrcBBaV = 0;

			private const int YDYIxTgwCkDaverikunfhOwhYwDx = 1;

			private const int cSQSofJKDriUvGodhFhJoviKzeK = 2;

			public float value
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					return ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[0]).floatValue;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return 0f;
					}
					return ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[0]).floatValuePrev;
				}
			}

			public IControllerTemplateAxis throttle
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[0];
				}
			}

			public IControllerTemplateButton minDetent
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[1];
				}
			}

			private ApIAEioHOqaZQhrNsgGmzvGMmxvG(IControllerTemplate parent, int id, string name, CVATTEpbHdlDkMLkuVxYvdqXdlD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Throttle, elements)
			{
				if (elements.Length != 2)
				{
					throw new ArgumentException("elements.Length must be " + 2);
				}
			}

			internal ApIAEioHOqaZQhrNsgGmzvGMmxvG(IControllerTemplate parent, int id, string name, MGLDGFbqSUiEcEarhSZBmXCrpyuD axis, MGLDGFbqSUiEcEarhSZBmXCrpyuD zeroDetentButton)
				: this(parent, id, name, new CVATTEpbHdlDkMLkuVxYvdqXdlD[2] { axis, zeroDetentButton })
			{
			}
		}

		internal sealed class rNcGcgJSlWKhRUfnxxDDXFOJBAD : wuxEdkAyFXyYedJvmhblqxizhrkr, IControllerTemplateElement, IControllerTemplateHat
		{
			private const int aCHppPOlPSYMCkIhCRvKIaIdxEh = 0;

			private const int ItrDosIsOsuejqyfQQHIigtfYAi = 1;

			private const int pqHGCButLxjTQoUJipZKFUrLJoY = 2;

			private const int bUxknPTOrygccaVpxWzttKTNpknI = 3;

			private const int XVTwcdAlgsNrFsgxsdhEEAbykFlB = 4;

			private const int vXrkbXLlMCrGofpqiuDpCRkEAgx = 5;

			private const int vvfHuCDWfuoyLaIdqhFgmtmgjkN = 6;

			private const int EuOoOpPJaRKPjYNBifdXkHrwFddM = 7;

			private const int cSQSofJKDriUvGodhFhJoviKzeK = 8;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						goto IL_000d;
					}
					Vector2 result = default(Vector2);
					result.y += ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[0]).floatValue;
					result.x += ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[2]).floatValue;
					int num = -45136317;
					goto IL_0012;
					IL_0012:
					float floatValue3 = default(float);
					float floatValue4 = default(float);
					while (true)
					{
						switch (num ^ -45136320)
						{
						case 2:
							break;
						case 1:
							ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
							return Vector2.zero;
						case 3:
							result.y -= ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[4]).floatValue;
							result.x -= ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[6]).floatValue;
							floatValue3 = ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[1]).floatValue;
							floatValue4 = ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[3]).floatValue;
							num = -45136316;
							continue;
						case 4:
						{
							float floatValue = ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[5]).floatValue;
							float floatValue2 = ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[7]).floatValue;
							result.x += floatValue3 + floatValue4 - floatValue - floatValue2;
							result.y += floatValue3 + floatValue2 - floatValue4 - floatValue;
							result.x = MathTools.Clamp(result.x, -1f, 1f);
							num = -45136320;
							continue;
						}
						default:
							result.y = MathTools.Clamp(result.y, -1f, 1f);
							return result;
						}
						break;
					}
					goto IL_000d;
					IL_000d:
					num = -45136319;
					goto IL_0012;
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					float floatValuePrev4 = default(float);
					float floatValuePrev2 = default(float);
					float floatValuePrev = default(float);
					float floatValuePrev3 = default(float);
					while (true)
					{
						int num = 1847152708;
						while (true)
						{
							switch (num ^ 0x6E195045)
							{
							case 3:
								break;
							case 4:
								floatValuePrev4 = ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[5]).floatValuePrev;
								floatValuePrev2 = ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[7]).floatValuePrev;
								result.x += floatValuePrev + floatValuePrev3 - floatValuePrev4 - floatValuePrev2;
								num = 1847152711;
								continue;
							case 0:
								floatValuePrev = ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[1]).floatValuePrev;
								floatValuePrev3 = ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[3]).floatValuePrev;
								num = 1847152705;
								continue;
							case 1:
								result.y += ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[0]).floatValuePrev;
								result.x += ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[2]).floatValuePrev;
								result.y -= ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[4]).floatValuePrev;
								result.x -= ((MGLDGFbqSUiEcEarhSZBmXCrpyuD)OZXcSZtVrQPQPLpKldDeETdguIN[6]).floatValuePrev;
								num = 1847152709;
								continue;
							default:
								result.y += floatValuePrev + floatValuePrev2 - floatValuePrev3 - floatValuePrev4;
								result.x = MathTools.Clamp(result.x, -1f, 1f);
								result.y = MathTools.Clamp(result.y, -1f, 1f);
								return result;
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
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[0];
				}
			}

			public IControllerTemplateButton upRight
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						while (true)
						{
							int num = 234466362;
							while (true)
							{
								switch (num ^ 0xDF9AC3B)
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
								ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
								num = 234466361;
							}
						}
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[1];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[2];
				}
			}

			public IControllerTemplateButton downRight
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[3];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[4];
				}
			}

			public IControllerTemplateButton downLeft
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[5];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[6];
				}
			}

			public IControllerTemplateButton upLeft
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateButton)OZXcSZtVrQPQPLpKldDeETdguIN[7];
				}
			}

			private rNcGcgJSlWKhRUfnxxDDXFOJBAD(IControllerTemplate parent, int id, string name, CVATTEpbHdlDkMLkuVxYvdqXdlD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Hat, elements)
			{
				while (true)
				{
					switch (-347707845 ^ -347707847)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						if (elements.Length != 8)
						{
							throw new ArgumentException("elements.Length must be " + 8);
						}
						return;
					case 1:
						return;
					}
				}
			}

			internal rNcGcgJSlWKhRUfnxxDDXFOJBAD(IControllerTemplate parent, int id, string name, MGLDGFbqSUiEcEarhSZBmXCrpyuD up, MGLDGFbqSUiEcEarhSZBmXCrpyuD upRight, MGLDGFbqSUiEcEarhSZBmXCrpyuD right, MGLDGFbqSUiEcEarhSZBmXCrpyuD downRight, MGLDGFbqSUiEcEarhSZBmXCrpyuD down, MGLDGFbqSUiEcEarhSZBmXCrpyuD downLeft, MGLDGFbqSUiEcEarhSZBmXCrpyuD left, MGLDGFbqSUiEcEarhSZBmXCrpyuD upLeft)
				: this(parent, id, name, new CVATTEpbHdlDkMLkuVxYvdqXdlD[8] { up, upRight, right, downRight, down, downLeft, left, upLeft })
			{
			}
		}

		internal sealed class hFlfHZDIpFGPGimvMcWXfbLReVcU : WxGBNCptdajTDGhXKsnxbBaMdgAV, IControllerTemplateElement, IControllerTemplateYoke
		{
			private new const int cSQSofJKDriUvGodhFhJoviKzeK = 2;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[0];
				}
			}

			public IControllerTemplateAxis pushPull
			{
				get
				{
					if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					return (IControllerTemplateAxis)OZXcSZtVrQPQPLpKldDeETdguIN[1];
				}
			}

			private hFlfHZDIpFGPGimvMcWXfbLReVcU(IControllerTemplate parent, int id, string name, CVATTEpbHdlDkMLkuVxYvdqXdlD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Yoke, elements)
			{
			}

			internal hFlfHZDIpFGPGimvMcWXfbLReVcU(IControllerTemplate parent, int id, string name, MGLDGFbqSUiEcEarhSZBmXCrpyuD rollAxis, MGLDGFbqSUiEcEarhSZBmXCrpyuD pitchAxis)
				: base(parent, id, name, ControllerTemplateElementType.Yoke, new CVATTEpbHdlDkMLkuVxYvdqXdlD[2] { rollAxis, pitchAxis })
			{
			}
		}

		internal sealed class ZjcbQWvgwqkgAtTAORyWnhMxqGh : amsSLboCVolIcJLGnPZtNbXnXEr, IControllerTemplateElement, IControllerTemplateStick6D
		{
			private new const int cSQSofJKDriUvGodhFhJoviKzeK = 6;

			private ZjcbQWvgwqkgAtTAORyWnhMxqGh(IControllerTemplate parent, int id, string name, CVATTEpbHdlDkMLkuVxYvdqXdlD[] elements)
				: base(parent, id, name, ControllerTemplateElementType.Stick6D, elements)
			{
			}

			internal ZjcbQWvgwqkgAtTAORyWnhMxqGh(IControllerTemplate parent, int id, string name, MGLDGFbqSUiEcEarhSZBmXCrpyuD positionX, MGLDGFbqSUiEcEarhSZBmXCrpyuD positionY, MGLDGFbqSUiEcEarhSZBmXCrpyuD positionZ, MGLDGFbqSUiEcEarhSZBmXCrpyuD rotationX, MGLDGFbqSUiEcEarhSZBmXCrpyuD rotationY, MGLDGFbqSUiEcEarhSZBmXCrpyuD rotationZ)
				: base(parent, id, name, ControllerTemplateElementType.Stick6D, new CVATTEpbHdlDkMLkuVxYvdqXdlD[6] { positionX, positionY, positionZ, rotationX, rotationY, rotationZ })
			{
			}
		}

		internal class noIWpqWnsjqLgoPJQWgwJuoJvQS
		{
			public readonly Controller.Element rtbAYIiFFNDhBOhoXbvIEvxNbpHC;

			public readonly IControllerElementTarget vGQnsSUmFrTJHfYhJtHRHxFCImW;

			public bool boolValue
			{
				get
				{
					if (rtbAYIiFFNDhBOhoXbvIEvxNbpHC == null)
					{
						return false;
					}
					int num;
					float value = default(float);
					switch (rtbAYIiFFNDhBOhoXbvIEvxNbpHC.type)
					{
					default:
						num = 1527938935;
						goto IL_002b;
					case ControllerElementType.Button:
						break;
					case ControllerElementType.Axis:
						{
							value = (rtbAYIiFFNDhBOhoXbvIEvxNbpHC as Controller.Axis).value;
							num = 1527938929;
							goto IL_002b;
						}
						IL_002b:
						while (true)
						{
							switch (num ^ 0x5B127F75)
							{
							case 3:
								break;
							case 1:
								return true;
							case 0:
								goto IL_007c;
							case 4:
								goto IL_0095;
							case 7:
								goto end_IL_0019;
							default:
								return true;
							case 2:
							case 5:
								goto IL_0107;
							}
							break;
							IL_0095:
							switch (vGQnsSUmFrTJHfYhJtHRHxFCImW.axisRange)
							{
							case AxisRange.Positive:
								break;
							case AxisRange.Negative:
								goto IL_006a;
							case AxisRange.Full:
								goto IL_007c;
							default:
								goto IL_00b7;
							}
							if (value > 0.01f)
							{
								return true;
							}
							goto IL_0107;
							IL_00b7:
							num = 1527938928;
							continue;
							IL_006a:
							if (value < -0.01f)
							{
								num = 1527938931;
								continue;
							}
							goto IL_0107;
							IL_0107:
							return false;
							IL_007c:
							if (value > 0.01f)
							{
								return true;
							}
							if (value < -0.01f)
							{
								num = 1527938932;
								continue;
							}
							goto IL_0107;
						}
						goto default;
						end_IL_0019:
						break;
					}
					return (rtbAYIiFFNDhBOhoXbvIEvxNbpHC as Controller.Button).value;
				}
			}

			public bool boolValuePrev
			{
				get
				{
					if (rtbAYIiFFNDhBOhoXbvIEvxNbpHC == null)
					{
						return false;
					}
					ControllerElementType type = rtbAYIiFFNDhBOhoXbvIEvxNbpHC.type;
					ControllerElementType controllerElementType = type;
					AxisRange axisRange = default(AxisRange);
					float valuePrev = default(float);
					while (true)
					{
						int num = -962671925;
						while (true)
						{
							switch (num ^ -962671928)
							{
							case 0:
								break;
							case 2:
								return true;
							case 5:
								switch (axisRange)
								{
								case AxisRange.Negative:
									break;
								case AxisRange.Full:
									goto IL_00d1;
								case AxisRange.Positive:
									goto IL_00e5;
								default:
									goto IL_00f9;
								}
								if (valuePrev < -0.01f)
								{
									num = -962671927;
									continue;
								}
								goto IL_00f9;
							case 4:
								return (rtbAYIiFFNDhBOhoXbvIEvxNbpHC as Controller.Button).valuePrev;
							case 3:
								switch (controllerElementType)
								{
								case ControllerElementType.Button:
									break;
								case ControllerElementType.Axis:
									goto IL_0090;
								default:
									goto IL_00f9;
								}
								goto case 4;
							case 6:
								goto IL_00d1;
							default:
								{
									return true;
								}
								IL_0090:
								valuePrev = (rtbAYIiFFNDhBOhoXbvIEvxNbpHC as Controller.Axis).valuePrev;
								axisRange = vGQnsSUmFrTJHfYhJtHRHxFCImW.axisRange;
								num = -962671923;
								continue;
								IL_00e5:
								if (valuePrev > 0.01f)
								{
									num = -962671926;
									continue;
								}
								goto IL_00f9;
								IL_00f9:
								return false;
								IL_00d1:
								if (valuePrev > 0.01f)
								{
									return true;
								}
								if (valuePrev < -0.01f)
								{
									return true;
								}
								goto IL_00f9;
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
					if (rtbAYIiFFNDhBOhoXbvIEvxNbpHC == null)
					{
						return false;
					}
					switch (rtbAYIiFFNDhBOhoXbvIEvxNbpHC.type)
					{
					case ControllerElementType.Button:
						return (rtbAYIiFFNDhBOhoXbvIEvxNbpHC as Controller.Button).justPressed;
					case ControllerElementType.Axis:
						if (MathTools.Abs(floatValue) > 0.01f && MathTools.Abs(floatValuePrev) <= 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (rtbAYIiFFNDhBOhoXbvIEvxNbpHC == null)
					{
						return false;
					}
					ControllerElementType type = rtbAYIiFFNDhBOhoXbvIEvxNbpHC.type;
					while (true)
					{
						int num = -995702013;
						while (true)
						{
							switch (num ^ -995702014)
							{
							case 2:
								break;
							case 1:
								switch (type)
								{
								case ControllerElementType.Button:
									return (rtbAYIiFFNDhBOhoXbvIEvxNbpHC as Controller.Button).justReleased;
								case ControllerElementType.Axis:
									if (MathTools.Abs(floatValue) <= 0.01f)
									{
										num = -995702014;
										continue;
									}
									break;
								}
								goto IL_0084;
							case 0:
								if (MathTools.Abs(floatValuePrev) > 0.01f)
								{
									num = -995702015;
									continue;
								}
								goto IL_0084;
							default:
								{
									return true;
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
					if (rtbAYIiFFNDhBOhoXbvIEvxNbpHC == null)
					{
						return 0f;
					}
					ControllerElementType type = rtbAYIiFFNDhBOhoXbvIEvxNbpHC.type;
					float value = default(float);
					while (true)
					{
						int num = -118302189;
						while (true)
						{
							switch (num ^ -118302191)
							{
							case 3:
								break;
							case 2:
								switch (type)
								{
								case ControllerElementType.Button:
									break;
								case ControllerElementType.Axis:
									goto IL_00ac;
								default:
									goto IL_00e7;
								}
								goto case 1;
							case 4:
								switch (vGQnsSUmFrTJHfYhJtHRHxFCImW.axisRange)
								{
								case AxisRange.Full:
									break;
								case AxisRange.Positive:
									goto IL_00c9;
								case AxisRange.Negative:
									if (value < 0f)
									{
										return value;
									}
									goto IL_00e7;
								default:
									goto IL_00e7;
								}
								goto case 0;
							case 1:
								if (!(rtbAYIiFFNDhBOhoXbvIEvxNbpHC as Controller.Button).value)
								{
									return 0f;
								}
								return 1f;
							case 0:
								return value;
							default:
								{
									return value;
								}
								IL_00c9:
								if (value > 0f)
								{
									num = -118302188;
									continue;
								}
								goto IL_00e7;
								IL_00e7:
								return 0f;
								IL_00ac:
								value = (rtbAYIiFFNDhBOhoXbvIEvxNbpHC as Controller.Axis).value;
								num = -118302187;
								continue;
							}
							break;
						}
					}
				}
			}

			public float floatValuePrev
			{
				get
				{
					if (rtbAYIiFFNDhBOhoXbvIEvxNbpHC == null)
					{
						goto IL_000b;
					}
					ControllerElementType type = rtbAYIiFFNDhBOhoXbvIEvxNbpHC.type;
					ControllerElementType controllerElementType = type;
					int num = 1566254966;
					goto IL_0010;
					IL_0010:
					AxisRange axisRange2 = default(AxisRange);
					float valuePrev = default(float);
					while (true)
					{
						AxisRange axisRange;
						switch (num ^ 0x5D5B2770)
						{
						case 3:
							break;
						case 2:
							if (!(rtbAYIiFFNDhBOhoXbvIEvxNbpHC as Controller.Button).valuePrev)
							{
								num = 1566254961;
								continue;
							}
							return 1f;
						case 4:
							switch (axisRange2)
							{
							case AxisRange.Full:
								break;
							case AxisRange.Positive:
								goto IL_007a;
							case AxisRange.Negative:
								if (valuePrev < 0f)
								{
									return valuePrev;
								}
								goto IL_0106;
							default:
								goto IL_0106;
							}
							goto case 0;
						case 0:
							return valuePrev;
						case 6:
							switch (controllerElementType)
							{
							case ControllerElementType.Button:
								break;
							case ControllerElementType.Axis:
								goto IL_00b2;
							default:
								goto IL_0106;
							}
							goto case 2;
						case 1:
							return 0f;
						case 5:
							return 0f;
						default:
							{
								return valuePrev;
							}
							IL_00b2:
							valuePrev = (rtbAYIiFFNDhBOhoXbvIEvxNbpHC as Controller.Axis).valuePrev;
							axisRange = vGQnsSUmFrTJHfYhJtHRHxFCImW.axisRange;
							axisRange2 = axisRange;
							num = 1566254964;
							continue;
							IL_007a:
							if (valuePrev > 0f)
							{
								num = 1566254967;
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
					num = 1566254965;
					goto IL_0010;
				}
			}

			public noIWpqWnsjqLgoPJQWgwJuoJvQS(IControllerElementTarget target, Controller.Element element)
			{
				rtbAYIiFFNDhBOhoXbvIEvxNbpHC = element;
				vGQnsSUmFrTJHfYhJtHRHxFCImW = target;
			}

			public static noIWpqWnsjqLgoPJQWgwJuoJvQS WDwRGsIphwHRFBDBHPIyGNmfHrtw()
			{
				return new noIWpqWnsjqLgoPJQWgwJuoJvQS(TtePFCKBdNmQRluqYJdgMTWVuTZ.WDwRGsIphwHRFBDBHPIyGNmfHrtw(), null);
			}
		}

		internal class LkCFQeezyqvcQaogCkWyFVUFlxWV
		{
			public readonly Controller djSTCtuXfIOUkuKgYhEAmyFNWUJ;

			public readonly IHardwareControllerTemplateMap_Internal aHscWBKFIjyxDyKzYArNCevXEgp;

			public LkCFQeezyqvcQaogCkWyFVUFlxWV(Controller controller, IHardwareControllerTemplateMap_Internal templateMap)
			{
				if (controller == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (templateMap == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				djSTCtuXfIOUkuKgYhEAmyFNWUJ = controller;
				aHscWBKFIjyxDyKzYArNCevXEgp = templateMap;
			}
		}

		private readonly string SQlNTEPvaCuPzRHxRVAmonHCzna;

		private readonly Guid vhaFpEaYFKUhWnVmKmaoWGQAhSA;

		private readonly Controller PQxjKAQNRjWZaZhctvIytmcdtVz;

		private readonly ADictionary<int, IControllerTemplateElement> eblCJDgFxxFnpDFqBYRdlmUevMSp;

		private readonly ADictionary<string, IControllerTemplateElement> GFYoswsnAMGUBfJYpJvnNfJkMOfR;

		private IControllerTemplateElement[] OZXcSZtVrQPQPLpKldDeETdguIN;

		private ReadOnlyCollection<IControllerTemplateElement> mpWcvIBYZzhvfGlpsJRRLOVkPPkn;

		private readonly int vuPDNwATQFuTZgAqTRoviXUGAgFM;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return PQxjKAQNRjWZaZhctvIytmcdtVz;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return SQlNTEPvaCuPzRHxRVAmonHCzna;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Guid.Empty;
				}
				return vhaFpEaYFKUhWnVmKmaoWGQAhSA;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return mpWcvIBYZzhvfGlpsJRRLOVkPPkn;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0;
				}
				return OZXcSZtVrQPQPLpKldDeETdguIN.Length;
			}
		}

		protected ControllerTemplate(object payload)
			: this((LkCFQeezyqvcQaogCkWyFVUFlxWV)payload)
		{
		}

		private ControllerTemplate(LkCFQeezyqvcQaogCkWyFVUFlxWV initializer)
		{
			int num13 = default(int);
			int elementIdentifierCount = default(int);
			int num11 = default(int);
			IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = default(IControllerTemplateMapSpecialElement_Internal);
			IControllerTemplateElementIdentifier templateElementIdentifier = default(IControllerTemplateElementIdentifier);
			CVATTEpbHdlDkMLkuVxYvdqXdlD cVATTEpbHdlDkMLkuVxYvdqXdlD = default(CVATTEpbHdlDkMLkuVxYvdqXdlD);
			ADictionary<int, IControllerTemplateElement> aDictionary = default(ADictionary<int, IControllerTemplateElement>);
			IHardwareControllerTemplateMap_Internal aHscWBKFIjyxDyKzYArNCevXEgp = default(IHardwareControllerTemplateMap_Internal);
			IControllerTemplateElementIdentifier templateElementIdentifier2 = default(IControllerTemplateElementIdentifier);
			int num2 = default(int);
			string text = default(string);
			IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor = default(IControllerTemplateElementIdentifier_Editor);
			int num6 = default(int);
			ControllerTemplateStickMapping mapping2 = default(ControllerTemplateStickMapping);
			int num5 = default(int);
			List<IControllerTemplateElement> list2 = default(List<IControllerTemplateElement>);
			List<IControllerTemplateElement> list = default(List<IControllerTemplateElement>);
			List<IControllerTemplateButton> list3 = default(List<IControllerTemplateButton>);
			List<IControllerTemplateAxis> list4 = default(List<IControllerTemplateAxis>);
			ControllerTemplateHatMapping mapping3 = default(ControllerTemplateHatMapping);
			int num9 = default(int);
			QUtJhmWOBoxbIRbwkQsAZaMftmv item = default(QUtJhmWOBoxbIRbwkQsAZaMftmv);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num = 568748861;
				while (true)
				{
					aZegFSKVtbYbsDQcYCKVgyHJAnPy obj2;
					int num7;
					int num14;
					aZegFSKVtbYbsDQcYCKVgyHJAnPy aZegFSKVtbYbsDQcYCKVgyHJAnPy2;
					aZegFSKVtbYbsDQcYCKVgyHJAnPy aZegFSKVtbYbsDQcYCKVgyHJAnPy3;
					bcTbEuZdnyLIiCwxhjYSqCkuLYx item2;
					switch (num ^ 0x21E66B01)
					{
					case 53:
						break;
					case 61:
						if (num13 >= elementIdentifierCount)
						{
							num11 = 0;
							num = 568748807;
							continue;
						}
						goto case 39;
					case 11:
						if (specialTemplateElementByElementIdentifierId == null)
						{
							Logger.LogError(string.Concat(templateElementIdentifier.elementType, " element missing for Element Identifier Id ", templateElementIdentifier.id));
							num = 568748837;
							continue;
						}
						goto case 36;
					case 52:
					{
						int num16;
						if (initializer.djSTCtuXfIOUkuKgYhEAmyFNWUJ != null)
						{
							num = 568748844;
							num16 = num;
						}
						else
						{
							num = 568748804;
							num16 = num;
						}
						continue;
					}
					case 58:
					{
						ControllerTemplateThrottleMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
						cVATTEpbHdlDkMLkuVxYvdqXdlD = new ApIAEioHOqaZQhrNsgGmzvGMmxvG(this, templateElementIdentifier.id, templateElementIdentifier.name, (mapping4 != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping4.eid_axis) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping4 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping4.eid_minDetent) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this));
						num = 568748827;
						continue;
					}
					case 0:
						goto IL_01e5;
					case 45:
						if (initializer.aHscWBKFIjyxDyKzYArNCevXEgp == null)
						{
							throw new ArgumentNullException("initializer.templateMap");
						}
						goto case 12;
					case 31:
						obj2 = aHscWBKFIjyxDyKzYArNCevXEgp.GetAxisTarget(PQxjKAQNRjWZaZhctvIytmcdtVz, templateElementIdentifier2.id);
						if (obj2 == null)
						{
							num = 568748824;
							continue;
						}
						goto IL_0791;
					case 47:
						goto IL_0261;
					case 1:
						goto IL_02c7;
					case 56:
						goto IL_02df;
					case 14:
					{
						ControllerTemplateThumbStickMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
						cVATTEpbHdlDkMLkuVxYvdqXdlD = new riByNVOkLtNxCLKCkNDshZZjoaN(this, templateElementIdentifier.id, templateElementIdentifier.name, (mapping7 != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping7.eid_axisX) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping7 != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping7.eid_axisY) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping7 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping7.eid_button) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this));
						num = 568748814;
						continue;
					}
					case 49:
						SQlNTEPvaCuPzRHxRVAmonHCzna = aHscWBKFIjyxDyKzYArNCevXEgp.name;
						vhaFpEaYFKUhWnVmKmaoWGQAhSA = aHscWBKFIjyxDyKzYArNCevXEgp.typeGuid;
						elementIdentifierCount = aHscWBKFIjyxDyKzYArNCevXEgp.GetElementIdentifierCount();
						num = 568748818;
						continue;
					case 44:
						num2 = 0;
						goto IL_0ceb;
					case 48:
						text = controllerTemplateElementIdentifier_Editor.alternateScriptingName;
						num = 568748862;
						continue;
					case 62:
					{
						templateElementIdentifier = aHscWBKFIjyxDyKzYArNCevXEgp.GetTemplateElementIdentifier(num6);
						int num8;
						if (templateElementIdentifier == null)
						{
							num = 568748850;
							num8 = num;
						}
						else
						{
							num = 568748829;
							num8 = num;
						}
						continue;
					}
					case 36:
						mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
						num = 568748812;
						continue;
					case 15:
						num = 568748827;
						continue;
					case 43:
						if (num5 >= list2.Count)
						{
							OZXcSZtVrQPQPLpKldDeETdguIN = list.ToArray();
							eblCJDgFxxFnpDFqBYRdlmUevMSp = aDictionary;
							num = 568748811;
							continue;
						}
						goto case 20;
					case 28:
						if (!InputTools.IsMappableType(templateElementIdentifier.elementType))
						{
							specialTemplateElementByElementIdentifierId = aHscWBKFIjyxDyKzYArNCevXEgp.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier.id);
							switch (templateElementIdentifier.elementType)
							{
							case ControllerTemplateElementType.Stick:
								break;
							case ControllerTemplateElementType.Yoke:
								goto IL_01e5;
							case ControllerTemplateElementType.DPad:
								goto IL_02c7;
							case ControllerTemplateElementType.Throttle:
								goto IL_02df;
							default:
								goto IL_0478;
							case ControllerTemplateElementType.ThumbStick:
								goto IL_071d;
							case (ControllerTemplateElementType)3:
								goto IL_0892;
							case ControllerTemplateElementType.Hat:
								goto IL_09c3;
							case ControllerTemplateElementType.Stick6D:
								goto IL_0c3c;
							}
							goto case 11;
						}
						goto case 51;
					case 12:
						vuPDNwATQFuTZgAqTRoviXUGAgFM = ReInput.id;
						num = 568748819;
						continue;
					case 34:
						list3 = new List<IControllerTemplateButton>();
						list2 = new List<IControllerTemplateElement>();
						num = 568748856;
						continue;
					case 6:
					{
						int num12;
						if (num11 >= list4.Count)
						{
							num = 568748832;
							num12 = num;
						}
						else
						{
							num = 568748831;
							num12 = num;
						}
						continue;
					}
					case 16:
						throw new NotImplementedException();
					case 3:
						num = 568748862;
						continue;
					case 21:
						cVATTEpbHdlDkMLkuVxYvdqXdlD = new rNcGcgJSlWKhRUfnxxDDXFOJBAD(this, templateElementIdentifier.id, templateElementIdentifier.name, (mapping3 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping3.eid_up) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping3 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping3.eid_upRight) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping3 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping3.eid_right) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping3 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping3.eid_downRight) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping3 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping3.eid_down) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping3 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping3.eid_downLeft) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping3 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping3.eid_left) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping3 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping3.eid_upLeft) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this));
						num = 568748827;
						continue;
					case 32:
						num = 568748858;
						continue;
					case 35:
						num9++;
						num = 568748825;
						continue;
					case 64:
					{
						ControllerTemplateDPadMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
						cVATTEpbHdlDkMLkuVxYvdqXdlD = new PsufJGhUyiBwxcFrIUitnuTKpINu(this, templateElementIdentifier.id, templateElementIdentifier.name, (mapping5 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping5.eid_up) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping5 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping5.eid_right) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping5 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping5.eid_down) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping5 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping5.eid_left) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping5 != null) ? RZsMjSvFIWRybHqIPQFzJqYOXMP(this, aDictionary, mapping5.eid_press) : QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this));
						num = 568748827;
						continue;
					}
					case 5:
						throw new ArgumentNullException("initializer.controller");
					case 10:
						GFYoswsnAMGUBfJYpJvnNfJkMOfR = new ADictionary<string, IControllerTemplateElement>();
						num = 568748845;
						continue;
					case 27:
						aDictionary.Add(list[num9].id, list[num9]);
						num = 568748834;
						continue;
					case 41:
						Logger.LogError(string.Concat(templateElementIdentifier.elementType, " element missing for Element Identifier Id ", templateElementIdentifier.id));
						num = 568748865;
						continue;
					case 46:
						goto IL_071d;
					case 20:
						list.Add(list2[num5]);
						aDictionary.Add(list2[num5].id, list2[num5]);
						num = 568748823;
						continue;
					case 25:
						obj2 = aZegFSKVtbYbsDQcYCKVgyHJAnPy.WDwRGsIphwHRFBDBHPIyGNmfHrtw(ControllerTemplateElementType.Axis);
						goto IL_0791;
					case 23:
					{
						ControllerTemplateYokeMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
						cVATTEpbHdlDkMLkuVxYvdqXdlD = new hFlfHZDIpFGPGimvMcWXfbLReVcU(this, templateElementIdentifier.id, templateElementIdentifier.name, (mapping != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping.eid_axisX) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping.eid_axisZ) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this));
						num = 568748827;
						continue;
					}
					case 26:
						if (cVATTEpbHdlDkMLkuVxYvdqXdlD != null)
						{
							list2.Add(cVATTEpbHdlDkMLkuVxYvdqXdlD);
							num = 568748850;
							continue;
						}
						goto case 51;
					case 38:
						goto IL_0892;
					case 55:
						Logger.LogError(string.Concat(templateElementIdentifier.elementType, " element missing for Element Identifier Id ", templateElementIdentifier.id));
						num = 568748859;
						continue;
					case 19:
						aDictionary = new ADictionary<int, IControllerTemplateElement>();
						list = new List<IControllerTemplateElement>();
						list4 = new List<IControllerTemplateAxis>();
						num = 568748835;
						continue;
					case 17:
						text = controllerTemplateElementIdentifier_Editor.scriptingName;
						num = 568748802;
						continue;
					case 37:
						list3.Add(item);
						num = 568748808;
						continue;
					case 30:
						list.Add(list4[num11]);
						num11++;
						num = 568748807;
						continue;
					case 40:
					{
						int num15;
						if (num3 == 0)
						{
							num = 568748816;
							num15 = num;
						}
						else
						{
							num = 568748849;
							num15 = num;
						}
						continue;
					}
					case 51:
						num6++;
						num = 568748803;
						continue;
					case 4:
						mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
						num = 568748820;
						continue;
					case 54:
						throw new ArgumentNullException("initializer");
					case 57:
						num13 = 0;
						num = 568748860;
						continue;
					case 60:
					{
						int num10;
						if (initializer != null)
						{
							num = 568748853;
							num10 = num;
						}
						else
						{
							num = 568748855;
							num10 = num;
						}
						continue;
					}
					case 24:
						if (num9 >= list.Count)
						{
							num6 = 0;
							num = 568748803;
							continue;
						}
						goto case 27;
					case 7:
						goto IL_09c3;
					case 59:
						if (num4 >= list3.Count)
						{
							num9 = 0;
							num = 568748825;
							continue;
						}
						goto case 42;
					case 13:
						cVATTEpbHdlDkMLkuVxYvdqXdlD = new cxoyVnkLqMVBqcObXuCbwMqgbQa(this, templateElementIdentifier.id, templateElementIdentifier.name, (mapping2 != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping2.eid_axisX) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping2 != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping2.eid_axisY) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping2 != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping2.eid_axisZ) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this));
						num = 568748827;
						continue;
					case 29:
						controllerTemplateElementIdentifier_Editor = aHscWBKFIjyxDyKzYArNCevXEgp.GetTemplateElementIdentifierById(OZXcSZtVrQPQPLpKldDeETdguIN[num2].id) as IControllerTemplateElementIdentifier_Editor;
						if (controllerTemplateElementIdentifier_Editor != null)
						{
							num3 = 0;
							goto IL_0cdd;
						}
						goto IL_0ce5;
					case 39:
						templateElementIdentifier2 = aHscWBKFIjyxDyKzYArNCevXEgp.GetTemplateElementIdentifier(num13);
						if (templateElementIdentifier2 != null && InputTools.IsMappableType(templateElementIdentifier2.elementType))
						{
							switch (templateElementIdentifier2.elementType)
							{
							case ControllerTemplateElementType.Axis:
								break;
							case ControllerTemplateElementType.Button:
								goto IL_0261;
							default:
								goto IL_0aef;
							}
							goto case 31;
						}
						goto case 9;
					case 18:
						PQxjKAQNRjWZaZhctvIytmcdtVz = initializer.djSTCtuXfIOUkuKgYhEAmyFNWUJ;
						aHscWBKFIjyxDyKzYArNCevXEgp = initializer.aHscWBKFIjyxDyKzYArNCevXEgp;
						num = 568748848;
						continue;
					case 42:
						list.Add(list3[num4]);
						num4++;
						num = 568748858;
						continue;
					case 50:
					{
						ControllerTemplateStick6DMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
						cVATTEpbHdlDkMLkuVxYvdqXdlD = new ZjcbQWvgwqkgAtTAORyWnhMxqGh(this, templateElementIdentifier.id, templateElementIdentifier.name, (mapping6 != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping6.eid_positionX) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping6 != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping6.eid_positionY) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping6 != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping6.eid_positionZ) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping6 != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping6.eid_rotationX) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping6 != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping6.eid_rotationY) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this), (mapping6 != null) ? gllSmokKSLOmDIEOtlcfUGpTtun(this, aDictionary, mapping6.eid_rotationZ) : bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(this));
						num = 568748827;
						continue;
					}
					case 2:
						if (num6 >= elementIdentifierCount)
						{
							num5 = 0;
							num = 568748842;
							continue;
						}
						goto case 62;
					case 22:
						num5++;
						num = 568748842;
						continue;
					case 9:
						num13++;
						num = 568748860;
						continue;
					case 33:
						num4 = 0;
						num = 568748833;
						continue;
					case 8:
						goto IL_0c3c;
					default:
						{
							if (!string.IsNullOrEmpty(text))
							{
								try
								{
									GFYoswsnAMGUBfJYpJvnNfJkMOfR.Add(text, OZXcSZtVrQPQPLpKldDeETdguIN[num2]);
								}
								catch
								{
									Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + SQlNTEPvaCuPzRHxRVAmonHCzna + ". This element should be renamed to a unique name.");
								}
							}
							num3++;
							goto IL_0cdd;
						}
						IL_0892:
						throw new NotImplementedException();
						IL_071d:
						if (specialTemplateElementByElementIdentifierId == null)
						{
							Logger.LogError(string.Concat(templateElementIdentifier.elementType, " element missing for Element Identifier Id ", templateElementIdentifier.id));
							num = 568748815;
							continue;
						}
						goto case 14;
						IL_0478:
						num = 568748839;
						continue;
						IL_02df:
						if (specialTemplateElementByElementIdentifierId != null)
						{
							num = 568748859;
							num7 = num;
						}
						else
						{
							num = 568748854;
							num7 = num;
						}
						continue;
						IL_02c7:
						if (specialTemplateElementByElementIdentifierId == null)
						{
							num = 568748840;
							num14 = num;
						}
						else
						{
							num = 568748865;
							num14 = num;
						}
						continue;
						IL_0c3c:
						if (specialTemplateElementByElementIdentifierId == null)
						{
							Logger.LogError(string.Concat(templateElementIdentifier.elementType, " element missing for Element Identifier Id ", templateElementIdentifier.id));
							num = 568748851;
							continue;
						}
						goto case 50;
						IL_0ceb:
						if (num2 >= OZXcSZtVrQPQPLpKldDeETdguIN.Length)
						{
							mpWcvIBYZzhvfGlpsJRRLOVkPPkn = new ReadOnlyCollection<IControllerTemplateElement>(OZXcSZtVrQPQPLpKldDeETdguIN);
							return;
						}
						goto case 29;
						IL_0ce5:
						num2++;
						goto IL_0ceb;
						IL_0cdd:
						if (num3 < 2)
						{
							goto case 40;
						}
						goto IL_0ce5;
						IL_01e5:
						if (specialTemplateElementByElementIdentifierId == null)
						{
							Logger.LogError(string.Concat(templateElementIdentifier.elementType, " element missing for Element Identifier Id ", templateElementIdentifier.id));
							num = 568748822;
							continue;
						}
						goto case 23;
						IL_0261:
						aZegFSKVtbYbsDQcYCKVgyHJAnPy2 = aHscWBKFIjyxDyKzYArNCevXEgp.GetButtonTarget(PQxjKAQNRjWZaZhctvIytmcdtVz, templateElementIdentifier2.id) ?? aZegFSKVtbYbsDQcYCKVgyHJAnPy.WDwRGsIphwHRFBDBHPIyGNmfHrtw(ControllerTemplateElementType.Button);
						item = new QUtJhmWOBoxbIRbwkQsAZaMftmv(this, templateElementIdentifier2.id, templateElementIdentifier2.name, templateElementIdentifier2.name, templateElementIdentifier2.name + " -", aZegFSKVtbYbsDQcYCKVgyHJAnPy2, hIJaNILCGejPkNoCACNgmfSLJmI(PQxjKAQNRjWZaZhctvIytmcdtVz, (IControllerTemplateButtonSource)aZegFSKVtbYbsDQcYCKVgyHJAnPy2));
						num = 568748836;
						continue;
						IL_0aef:
						num = 568748817;
						continue;
						IL_09c3:
						if (specialTemplateElementByElementIdentifierId == null)
						{
							Logger.LogError(string.Concat(templateElementIdentifier.elementType, " element missing for Element Identifier Id ", templateElementIdentifier.id));
							num = 568748805;
							continue;
						}
						goto case 4;
						IL_0791:
						aZegFSKVtbYbsDQcYCKVgyHJAnPy3 = obj2;
						item2 = new bcTbEuZdnyLIiCwxhjYSqCkuLYx(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (!string.IsNullOrEmpty(templateElementIdentifier2.positiveName)) ? templateElementIdentifier2.positiveName : (templateElementIdentifier2.name + " +"), (!string.IsNullOrEmpty(templateElementIdentifier2.negativeName)) ? templateElementIdentifier2.negativeName : (templateElementIdentifier2.name + " -"), aZegFSKVtbYbsDQcYCKVgyHJAnPy3, hIJaNILCGejPkNoCACNgmfSLJmI(PQxjKAQNRjWZaZhctvIytmcdtVz, (IControllerTemplateAxisSource)aZegFSKVtbYbsDQcYCKVgyHJAnPy3));
						list4.Add(item2);
						num = 568748808;
						continue;
					}
					break;
				}
			}
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			if (!eblCJDgFxxFnpDFqBYRdlmUevMSp.TryGetValue(id, out var value))
			{
				object[] array = new object[5];
				while (true)
				{
					int num = -1254472189;
					while (true)
					{
						switch (num ^ -1254472190)
						{
						case 5:
							break;
						case 1:
							array[0] = "There is no element with the id \"";
							num = -1254472186;
							continue;
						case 4:
							array[1] = id;
							array[2] = "\" in the ";
							num = -1254472192;
							continue;
						case 2:
							array[3] = GetType().ToString();
							num = -1254472191;
							continue;
						case 0:
							Logger.LogWarning(string.Concat(array));
							num = -1254472188;
							continue;
						case 3:
							array[4] = ".";
							num = -1254472190;
							continue;
						default:
							goto end_IL_001a;
						}
						break;
					}
					continue;
					end_IL_001a:
					break;
				}
			}
			return value;
		}

		protected T GetElement<T>(int id) where T : class, IControllerTemplateElement
		{
			return GetElement(id) as T;
		}

		private IControllerTemplateElement XREcQDkiZCdtMNigbnOEjUowGSXF(int P_0)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			return GetElement(P_0);
		}

		IControllerTemplateElement IControllerTemplate.GetElement(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in XREcQDkiZCdtMNigbnOEjUowGSXF
			return this.XREcQDkiZCdtMNigbnOEjUowGSXF(P_0);
		}

		private T XREcQDkiZCdtMNigbnOEjUowGSXF<T>(int P_0) where T : class, IControllerTemplateElement
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			return GetElement<T>(P_0);
		}

		T IControllerTemplate.GetElement<T>(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in XREcQDkiZCdtMNigbnOEjUowGSXF
			return this.XREcQDkiZCdtMNigbnOEjUowGSXF<T>(P_0);
		}

		private int OSqfAHdmCsoBdjSwYNhPwViKqJLk(ControllerElementTarget P_0, IList<ControllerTemplateElementTarget> P_1)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				while (true)
				{
					switch (0x3DC90DE3 ^ 0x3DC90DE1)
					{
					case 0:
						continue;
					case 2:
						return 0;
					}
					break;
				}
			}
			else if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			return KrcEjyfOjbRLBRFFPehBfdhCWhc(P_0, ref P_1);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget P_0, IList<ControllerTemplateElementTarget> P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OSqfAHdmCsoBdjSwYNhPwViKqJLk
			return this.OSqfAHdmCsoBdjSwYNhPwViKqJLk(P_0, P_1);
		}

		private int KrcEjyfOjbRLBRFFPehBfdhCWhc(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
		{
			if (P_1 != null)
			{
				P_1.Clear();
				goto IL_000b;
			}
			goto IL_0060;
			IL_0060:
			int num = 0;
			int num2 = 916734587;
			goto IL_0010;
			IL_000b:
			num2 = 916734590;
			goto IL_0010;
			IL_0010:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x36A4427B)
				{
				case 3:
					break;
				case 6:
					num3++;
					num2 = 916734586;
					continue;
				case 1:
					goto IL_0044;
				case 5:
					goto IL_0060;
				case 4:
					if (InputTools.IsMappableType(OZXcSZtVrQPQPLpKldDeETdguIN[num3].type))
					{
						num += (OZXcSZtVrQPQPLpKldDeETdguIN[num3] as IControllerTemplateElement_Internal).GetElementTargets(P_0, ref P_1);
						num2 = 916734589;
						continue;
					}
					goto case 6;
				case 0:
					num3 = 0;
					num2 = 916734586;
					continue;
				default:
					return num;
				}
				break;
				IL_0044:
				int num4;
				if (num3 >= OZXcSZtVrQPQPLpKldDeETdguIN.Length)
				{
					num2 = 916734585;
					num4 = num2;
				}
				else
				{
					num2 = 916734591;
					num4 = num2;
				}
			}
			goto IL_000b;
		}

		[CustomObfuscation(rename = false)]
		internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
		{
			while (true)
			{
				int num = -736549472;
				while (true)
				{
					switch (num ^ -736549470)
					{
					case 0:
						break;
					case 2:
						switch (elementType)
						{
						case ControllerTemplateElementType.Axis:
							goto IL_0062;
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
						case (ControllerTemplateElementType)3:
							goto IL_00c5;
						}
						goto IL_0052;
					default:
						goto IL_0062;
					case 3:
						goto IL_00c5;
						IL_00c5:
						throw new NotImplementedException();
						IL_0062:
						return typeof(IControllerTemplateAxis);
					}
					break;
					IL_0052:
					num = -736549471;
				}
			}
		}

		private static IList<noIWpqWnsjqLgoPJQWgwJuoJvQS> hIJaNILCGejPkNoCACNgmfSLJmI(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			IList<noIWpqWnsjqLgoPJQWgwJuoJvQS> list;
			bool flag;
			if (P_1.splitAxis)
			{
				list = null;
				flag = false;
				if (P_1.positiveTarget != null)
				{
					goto IL_001c;
				}
				goto IL_0076;
			}
			return hIJaNILCGejPkNoCACNgmfSLJmI(P_0, P_1.fullTarget);
			IL_0021:
			int num;
			Controller.Element elementById = default(Controller.Element);
			while (true)
			{
				switch (num ^ -1587948854)
				{
				case 4:
					break;
				case 1:
					elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					num = -1587948862;
					continue;
				case 0:
					goto IL_0076;
				case 2:
					flag = true;
					num = -1587948854;
					continue;
				case 9:
					ListTools.AddAndCreateList(ref list, noIWpqWnsjqLgoPJQWgwJuoJvQS.WDwRGsIphwHRFBDBHPIyGNmfHrtw());
					num = -1587948852;
					continue;
				case 3:
					if (!flag)
					{
						ListTools.AddAndCreateList(ref list, noIWpqWnsjqLgoPJQWgwJuoJvQS.WDwRGsIphwHRFBDBHPIyGNmfHrtw());
						num = -1587948864;
						continue;
					}
					goto default;
				case 7:
				{
					Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
					if (elementById2 != null)
					{
						ListTools.AddAndCreateList(ref list, new noIWpqWnsjqLgoPJQWgwJuoJvQS(P_1.negativeTarget, elementById2));
						flag = true;
						num = -1587948855;
						continue;
					}
					goto case 3;
				}
				case 5:
					ListTools.AddAndCreateList(ref list, new noIWpqWnsjqLgoPJQWgwJuoJvQS(P_1.positiveTarget, elementById));
					num = -1587948856;
					continue;
				case 6:
					goto IL_011a;
				case 8:
					goto IL_0138;
				default:
					return list;
				}
				break;
				IL_0138:
				int num2;
				if (elementById == null)
				{
					num = -1587948854;
					num2 = num;
				}
				else
				{
					num = -1587948849;
					num2 = num;
				}
				continue;
				IL_011a:
				flag = false;
				int num3;
				if (P_1.negativeTarget != null)
				{
					num = -1587948851;
					num3 = num;
				}
				else
				{
					num = -1587948855;
					num3 = num;
				}
			}
			goto IL_001c;
			IL_001c:
			num = -1587948853;
			goto IL_0021;
			IL_0076:
			int num4;
			if (flag)
			{
				num = -1587948852;
				num4 = num;
			}
			else
			{
				num = -1587948861;
				num4 = num;
			}
			goto IL_0021;
		}

		private static IList<noIWpqWnsjqLgoPJQWgwJuoJvQS> hIJaNILCGejPkNoCACNgmfSLJmI(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return hIJaNILCGejPkNoCACNgmfSLJmI(P_0, P_1.target);
		}

		private static IList<noIWpqWnsjqLgoPJQWgwJuoJvQS> hIJaNILCGejPkNoCACNgmfSLJmI(Controller P_0, IControllerElementTarget P_1)
		{
			if (P_1 == null)
			{
				goto IL_0003;
			}
			Controller.Element elementById = P_0.GetElementById(P_1.elementIdentifierId);
			if (elementById == null)
			{
				return null;
			}
			List<noIWpqWnsjqLgoPJQWgwJuoJvQS> list = new List<noIWpqWnsjqLgoPJQWgwJuoJvQS>();
			int num = -2049487300;
			goto IL_0008;
			IL_0003:
			num = -2049487297;
			goto IL_0008;
			IL_0008:
			switch (num ^ -2049487299)
			{
			case 0:
				break;
			case 2:
				return null;
			default:
				list.Add(new noIWpqWnsjqLgoPJQWgwJuoJvQS(P_1, elementById));
				return list;
			}
			goto IL_0003;
		}

		private static IControllerTemplateElement DUAxYNCHeTAQPnXQfgwxWiroHHG(List<IControllerTemplateElement> P_0, int P_1)
		{
			int count = P_0.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= count)
				{
					num2 = -430701068;
					num3 = num2;
				}
				else
				{
					num2 = -430701065;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -430701066)
					{
					case 0:
						num2 = -430701065;
						continue;
					case 1:
						if (P_0[num].id == P_1)
						{
							return P_0[num];
						}
						num++;
						num2 = -430701067;
						continue;
					case 3:
						break;
					default:
						return null;
					}
					break;
				}
			}
		}

		private static MGLDGFbqSUiEcEarhSZBmXCrpyuD gllSmokKSLOmDIEOtlcfUGpTtun(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is MGLDGFbqSUiEcEarhSZBmXCrpyuD result))
			{
				return bcTbEuZdnyLIiCwxhjYSqCkuLYx.WDwRGsIphwHRFBDBHPIyGNmfHrtw(P_0);
			}
			return result;
		}

		private static MGLDGFbqSUiEcEarhSZBmXCrpyuD RZsMjSvFIWRybHqIPQFzJqYOXMP(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is MGLDGFbqSUiEcEarhSZBmXCrpyuD result))
			{
				return QUtJhmWOBoxbIRbwkQsAZaMftmv.WDwRGsIphwHRFBDBHPIyGNmfHrtw(P_0);
			}
			return result;
		}
	}
}
