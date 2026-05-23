using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int rOuBUzbbciWwktcpmiPWpQIKoaAa;

		private readonly ControllerTemplateElementType geStyfnIbdATvfzZcIGcHdNutpK;

		private bool PAfqntGWZaNgzmZFIOyQPuJGOCq;

		private int mecAvOSCkKTUzDMSKLpGqHuOJBZ;

		private int wyOUtAQIXRMHfdYotPsXMPVUbwu;

		private static int QDdNMyKsVLmdRXWnRVruBfoSToC;

		public int id
		{
			get
			{
				return rOuBUzbbciWwktcpmiPWpQIKoaAa;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				return geStyfnIbdATvfzZcIGcHdNutpK;
			}
		}

		public bool enabled
		{
			get
			{
				return PAfqntGWZaNgzmZFIOyQPuJGOCq;
			}
			set
			{
				PAfqntGWZaNgzmZFIOyQPuJGOCq = value;
			}
		}

		public int actionId
		{
			get
			{
				return mecAvOSCkKTUzDMSKLpGqHuOJBZ;
			}
			set
			{
				mecAvOSCkKTUzDMSKLpGqHuOJBZ = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return wyOUtAQIXRMHfdYotPsXMPVUbwu;
			}
			set
			{
				wyOUtAQIXRMHfdYotPsXMPVUbwu = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType)
		{
			if (!InputTools.IsMappableType(elementType))
			{
				throw new ArgumentException(string.Concat(elementType, " is not a supported mappable Controller Template element type."));
			}
			geStyfnIbdATvfzZcIGcHdNutpK = elementType;
			rOuBUzbbciWwktcpmiPWpQIKoaAa = QDdNMyKsVLmdRXWnRVruBfoSToC++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType, int elementIdentifierId, ActionElementMap actionElementMap)
			: this(elementType)
		{
			if (actionElementMap == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			mecAvOSCkKTUzDMSKLpGqHuOJBZ = actionElementMap._actionId;
			wyOUtAQIXRMHfdYotPsXMPVUbwu = elementIdentifierId;
			PAfqntGWZaNgzmZFIOyQPuJGOCq = actionElementMap.PAfqntGWZaNgzmZFIOyQPuJGOCq;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType, int elementIdentifierId, int actionId, bool enabled)
			: this(elementType)
		{
			mecAvOSCkKTUzDMSKLpGqHuOJBZ = actionId;
			wyOUtAQIXRMHfdYotPsXMPVUbwu = elementIdentifierId;
			PAfqntGWZaNgzmZFIOyQPuJGOCq = enabled;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap actionElementMap)
		{
		}

		internal int qNnlMnyVUtsqBKOWnglpkzgZyyqn(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_0050;
			IL_0003:
			int num = -233374804;
			goto IL_0008;
			IL_0008:
			int num4 = default(int);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -233374805)
				{
				case 5:
					break;
				case 2:
					goto IL_0040;
				case 9:
					goto IL_0050;
				case 1:
					goto IL_0065;
				case 7:
					throw new ArgumentNullException("controllerTemplate");
				case 3:
				{
					int index = num4 + num2;
					P_1[index].PAfqntGWZaNgzmZFIOyQPuJGOCq = PAfqntGWZaNgzmZFIOyQPuJGOCq;
					P_1[index]._actionId = mecAvOSCkKTUzDMSKLpGqHuOJBZ;
					num2++;
					num = -233374813;
					continue;
				}
				case 6:
					num2 = 0;
					num = -233374801;
					continue;
				case 0:
					return 0;
				case 4:
					num = -233374813;
					continue;
				default:
					if (num2 >= num3)
					{
						return num3;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0003;
			IL_0065:
			num3 = rbwCrSWgBICamZqHQdaeRBspbyZ(P_0, P_1, P_2);
			if (num3 == 0)
			{
				num = -233374805;
			}
			else
			{
				num4 = P_1.Count - num3;
				num = -233374803;
			}
			goto IL_0008;
			IL_0040:
			if (!P_2)
			{
				P_1.Clear();
				num = -233374806;
				goto IL_0008;
			}
			goto IL_0065;
			IL_0050:
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			goto IL_0040;
		}

		internal SerializedObject wGWQXZtIQyRkZMrIKWqTSlWZlQY()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			Export(serializedObject);
			return serializedObject;
		}

		internal virtual void Export(SerializedObject P_0)
		{
			P_0.Add("elementType", geStyfnIbdATvfzZcIGcHdNutpK);
			P_0.Add("enabled", PAfqntGWZaNgzmZFIOyQPuJGOCq);
			P_0.Add("elementIdentifierId", wyOUtAQIXRMHfdYotPsXMPVUbwu);
			P_0.Add("actionId", mecAvOSCkKTUzDMSKLpGqHuOJBZ);
		}

		internal virtual void Import(SerializedObject P_0)
		{
			Clear();
			while (true)
			{
				int num = -529792331;
				while (true)
				{
					switch (num ^ -529792330)
					{
					case 2:
						break;
					case 3:
						P_0.TryGetDeserializedValueByRef("enabled", ref PAfqntGWZaNgzmZFIOyQPuJGOCq);
						num = -529792330;
						continue;
					case 0:
						P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref wyOUtAQIXRMHfdYotPsXMPVUbwu);
						num = -529792329;
						continue;
					default:
						P_0.TryGetDeserializedValueByRef("actionId", ref mecAvOSCkKTUzDMSKLpGqHuOJBZ);
						return;
					}
					break;
				}
			}
		}

		internal virtual void Clear()
		{
			PAfqntGWZaNgzmZFIOyQPuJGOCq = true;
			wyOUtAQIXRMHfdYotPsXMPVUbwu = -1;
			while (true)
			{
				int num = -310196417;
				while (true)
				{
					switch (num ^ -310196418)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_002c;
					case 0:
						return;
					}
					break;
					IL_002c:
					mecAvOSCkKTUzDMSKLpGqHuOJBZ = -1;
					num = -310196418;
				}
			}
		}

		internal abstract int CreateAEMsFromSource(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int rbwCrSWgBICamZqHQdaeRBspbyZ(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			IControllerTemplateElementSource source = default(IControllerTemplateElementSource);
			while (true)
			{
				int num;
				if (!P_2)
				{
					P_1.Clear();
					num = 900617872;
					goto IL_0013;
				}
				goto IL_0040;
				IL_0013:
				while (true)
				{
					switch (num ^ 0x35AE5693)
					{
					case 0:
						num = 900617874;
						continue;
					case 1:
						break;
					case 3:
						goto IL_0040;
					default:
						goto end_IL_0030;
					}
					break;
				}
				continue;
				IL_0040:
				IControllerTemplateElement element = P_0.GetElement(wyOUtAQIXRMHfdYotPsXMPVUbwu);
				if (element == null)
				{
					return 0;
				}
				source = element.source;
				num = 900617873;
				goto IL_0013;
				continue;
				end_IL_0030:
				break;
			}
			if (source == null)
			{
				return 0;
			}
			return CreateAEMsFromSource(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap MdLShCgeucAqBomYFlMaHVWokJC(SerializedObject P_0)
		{
			if (P_0 == null)
			{
				while (true)
				{
					switch (0x3D15DB03 ^ 0x3D15DB01)
					{
					case 0:
						continue;
					case 2:
						return null;
					}
					break;
				}
			}
			else
			{
				ControllerTemplateElementType value;
				if (!P_0.TryGetDeserializedValue<ControllerTemplateElementType>("elementType", out value))
				{
					return null;
				}
				switch (value)
				{
				case ControllerTemplateElementType.Axis:
					break;
				case ControllerTemplateElementType.Button:
					return new ControllerTemplateActionButtonMap(P_0);
				default:
					throw new NotImplementedException();
				}
			}
			return new ControllerTemplateActionAxisMap(P_0);
		}

		internal static ControllerTemplateActionElementMap MdLShCgeucAqBomYFlMaHVWokJC(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			while (true)
			{
				if (P_0.elementType == ControllerTemplateElementType.Axis)
				{
					return new ControllerTemplateActionAxisMap(P_0.element.id, P_0.axisRange, P_1);
				}
				if (P_0.elementType != ControllerTemplateElementType.Button)
				{
					break;
				}
				int num = 993630571;
				while (true)
				{
					switch (num ^ 0x3B39996B)
					{
					case 2:
						goto IL_000e;
					case 1:
						break;
					default:
						return new ControllerTemplateActionButtonMap(P_0.element.id, P_1);
					}
					break;
					IL_000e:
					num = 993630570;
				}
			}
			throw new NotImplementedException();
		}

		internal static ControllerTemplateActionElementMap MdLShCgeucAqBomYFlMaHVWokJC(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			while (true)
			{
				ControllerTemplateElementType controllerTemplateElementType = jHLGlrXjGMMIuxAEONcGlnwHltw.LpJPZRKGuKEvAFVHrgyOCheoguI(P_0._elementType, false);
				if (!InputTools.IsMappableType(controllerTemplateElementType))
				{
					break;
				}
				switch (controllerTemplateElementType)
				{
				case ControllerTemplateElementType.Axis:
				{
					int num = -1247616603;
					while (true)
					{
						switch (num ^ -1247616603)
						{
						case 2:
							goto IL_000e;
						case 1:
							break;
						default:
							return new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.PAfqntGWZaNgzmZFIOyQPuJGOCq);
						}
						break;
						IL_000e:
						num = -1247616604;
					}
					break;
				}
				case ControllerTemplateElementType.Button:
					return new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.PAfqntGWZaNgzmZFIOyQPuJGOCq);
				default:
					throw new NotImplementedException();
				}
			}
			return null;
		}
	}
}
