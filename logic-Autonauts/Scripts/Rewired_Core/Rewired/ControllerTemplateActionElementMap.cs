using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int KAixZgRycuVSHIYaEVNGzKGIdgV;

		private readonly ControllerTemplateElementType ZcCJfoFOnfaVWPxSGABewnPoqKP;

		private bool gmbIkkevNmPVGSTIwKcAwoPYANrc;

		private int ZUoDkTcclUigIzTjeFLCXFMQOaU;

		private int TZSPqisJATrQkFfRXLKedgRIcwv;

		private static int zkRMNLgwkHPfOtXKPPBlyfScGij;

		public int id
		{
			get
			{
				return KAixZgRycuVSHIYaEVNGzKGIdgV;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				return ZcCJfoFOnfaVWPxSGABewnPoqKP;
			}
		}

		public bool enabled
		{
			get
			{
				return gmbIkkevNmPVGSTIwKcAwoPYANrc;
			}
			set
			{
				gmbIkkevNmPVGSTIwKcAwoPYANrc = value;
			}
		}

		public int actionId
		{
			get
			{
				return ZUoDkTcclUigIzTjeFLCXFMQOaU;
			}
			set
			{
				ZUoDkTcclUigIzTjeFLCXFMQOaU = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return TZSPqisJATrQkFfRXLKedgRIcwv;
			}
			set
			{
				TZSPqisJATrQkFfRXLKedgRIcwv = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType)
		{
			if (!InputTools.IsMappableType(elementType))
			{
				throw new ArgumentException(string.Concat(elementType, " is not a supported mappable Controller Template element type."));
			}
			ZcCJfoFOnfaVWPxSGABewnPoqKP = elementType;
			KAixZgRycuVSHIYaEVNGzKGIdgV = zkRMNLgwkHPfOtXKPPBlyfScGij++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType, int elementIdentifierId, ActionElementMap actionElementMap)
			: this(elementType)
		{
			if (actionElementMap == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ZUoDkTcclUigIzTjeFLCXFMQOaU = actionElementMap._actionId;
			TZSPqisJATrQkFfRXLKedgRIcwv = elementIdentifierId;
			gmbIkkevNmPVGSTIwKcAwoPYANrc = actionElementMap.gmbIkkevNmPVGSTIwKcAwoPYANrc;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType, int elementIdentifierId, int actionId, bool enabled)
			: this(elementType)
		{
			ZUoDkTcclUigIzTjeFLCXFMQOaU = actionId;
			TZSPqisJATrQkFfRXLKedgRIcwv = elementIdentifierId;
			gmbIkkevNmPVGSTIwKcAwoPYANrc = enabled;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap actionElementMap)
		{
		}

		internal int RofGLuCvOlxXwczNPqjnCJgPbvhg(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			int num4 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (P_1 == null)
				{
					num = 997216964;
					num2 = num;
				}
				else
				{
					num = 997216960;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x3B7052C2)
					{
					case 5:
						num = 997216965;
						continue;
					case 7:
						break;
					case 2:
						if (!P_2)
						{
							P_1.Clear();
							num = 997216961;
							continue;
						}
						goto case 3;
					case 3:
						num4 = CesJwZqDJKFMZbGMsgNqkbqrhdW(P_0, P_1, P_2);
						if (num4 == 0)
						{
							num = 997216962;
							continue;
						}
						num5 = P_1.Count - num4;
						num3 = 0;
						num = 997216963;
						continue;
					case 0:
						return 0;
					case 6:
						throw new ArgumentNullException("results");
					case 4:
					{
						int index = num5 + num3;
						P_1[index].gmbIkkevNmPVGSTIwKcAwoPYANrc = gmbIkkevNmPVGSTIwKcAwoPYANrc;
						P_1[index]._actionId = ZUoDkTcclUigIzTjeFLCXFMQOaU;
						num3++;
						num = 997216963;
						continue;
					}
					default:
						if (num3 >= num4)
						{
							return num4;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		internal SerializedObject LxAJUQVkKiSNqkaHsfsZAlQLTqTK()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			Export(serializedObject);
			return serializedObject;
		}

		internal virtual void Export(SerializedObject P_0)
		{
			P_0.Add("elementType", ZcCJfoFOnfaVWPxSGABewnPoqKP);
			while (true)
			{
				int num = 417783392;
				while (true)
				{
					switch (num ^ 0x18E6DE61)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0030;
					case 2:
						return;
					}
					break;
					IL_0030:
					P_0.Add("enabled", gmbIkkevNmPVGSTIwKcAwoPYANrc);
					P_0.Add("elementIdentifierId", TZSPqisJATrQkFfRXLKedgRIcwv);
					P_0.Add("actionId", ZUoDkTcclUigIzTjeFLCXFMQOaU);
					num = 417783395;
				}
			}
		}

		internal virtual void Import(SerializedObject P_0)
		{
			Clear();
			P_0.TryGetDeserializedValueByRef("enabled", ref gmbIkkevNmPVGSTIwKcAwoPYANrc);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref TZSPqisJATrQkFfRXLKedgRIcwv);
			P_0.TryGetDeserializedValueByRef("actionId", ref ZUoDkTcclUigIzTjeFLCXFMQOaU);
		}

		internal virtual void Clear()
		{
			gmbIkkevNmPVGSTIwKcAwoPYANrc = true;
			while (true)
			{
				int num = -1985791366;
				while (true)
				{
					switch (num ^ -1985791368)
					{
					case 0:
						break;
					case 2:
						goto IL_0025;
					default:
						ZUoDkTcclUigIzTjeFLCXFMQOaU = -1;
						return;
					}
					break;
					IL_0025:
					TZSPqisJATrQkFfRXLKedgRIcwv = -1;
					num = -1985791367;
				}
			}
		}

		internal abstract int CreateAEMsFromSource(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int CesJwZqDJKFMZbGMsgNqkbqrhdW(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				goto IL_0003;
			}
			goto IL_0057;
			IL_0003:
			int num = 594089848;
			goto IL_0008;
			IL_0008:
			IControllerTemplateElement element = default(IControllerTemplateElement);
			while (true)
			{
				switch (num ^ 0x23691779)
				{
				case 0:
					break;
				case 2:
					goto IL_002d;
				case 3:
					goto IL_0043;
				case 4:
					goto IL_0057;
				case 1:
					throw new ArgumentNullException("results");
				default:
					return 0;
				}
				break;
				IL_002d:
				if (element == null)
				{
					return 0;
				}
				IControllerTemplateElementSource source = element.source;
				if (source == null)
				{
					num = 594089852;
					continue;
				}
				return CreateAEMsFromSource(source, P_1, P_2);
			}
			goto IL_0003;
			IL_0057:
			if (!P_2)
			{
				P_1.Clear();
				num = 594089850;
				goto IL_0008;
			}
			goto IL_0043;
			IL_0043:
			element = P_0.GetElement(TZSPqisJATrQkFfRXLKedgRIcwv);
			num = 594089851;
			goto IL_0008;
		}

		internal static ControllerTemplateActionElementMap rHXUBQoqejbkONabpWgwEqatBJ(SerializedObject P_0)
		{
			if (P_0 == null)
			{
				while (true)
				{
					switch (-1769548619 ^ -1769548620)
					{
					case 2:
						continue;
					case 1:
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

		internal static ControllerTemplateActionElementMap rHXUBQoqejbkONabpWgwEqatBJ(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			while (P_0.elementType == ControllerTemplateElementType.Axis)
			{
				int num = -1061066519;
				while (true)
				{
					switch (num ^ -1061066519)
					{
					case 2:
						goto IL_000e;
					case 1:
						break;
					default:
						return new ControllerTemplateActionAxisMap(P_0.element.id, P_0.axisRange, P_1);
					}
					break;
					IL_000e:
					num = -1061066520;
				}
			}
			if (P_0.elementType == ControllerTemplateElementType.Button)
			{
				return new ControllerTemplateActionButtonMap(P_0.element.id, P_1);
			}
			throw new NotImplementedException();
		}

		internal static ControllerTemplateActionElementMap rHXUBQoqejbkONabpWgwEqatBJ(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_0037;
			IL_0003:
			int num = -1986631673;
			goto IL_0008;
			IL_0008:
			switch (num ^ -1986631674)
			{
			case 3:
				break;
			case 1:
				throw new ArgumentNullException("actionElementMap");
			case 2:
				goto IL_0037;
			default:
				goto IL_004b;
			}
			goto IL_0003;
			IL_004b:
			ControllerTemplateElementType controllerTemplateElementType = default(ControllerTemplateElementType);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			switch (controllerTemplateElementType)
			{
			case ControllerTemplateElementType.Axis:
				return new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.gmbIkkevNmPVGSTIwKcAwoPYANrc);
			case ControllerTemplateElementType.Button:
				return new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.gmbIkkevNmPVGSTIwKcAwoPYANrc);
			default:
				throw new NotImplementedException();
			}
			IL_0037:
			controllerTemplateElementType = KVNLqybISELdZVRJeMgGCnyHIcv.epHGbImMBWbvvjSPHgtWxljmdtP(P_0._elementType, false);
			num = -1986631674;
			goto IL_0008;
		}
	}
}
