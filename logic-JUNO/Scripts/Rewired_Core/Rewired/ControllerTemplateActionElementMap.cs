using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int JlIZbjlngXLjPYcGHxRQmuMPOIoH;

		private readonly ControllerTemplateElementType eQMnNpZqoFetZzIUOgBCimEfZBHg;

		private bool zHzjhKGTZHjZwJwsLgDYwfhvlPXB;

		private int tnSnHITvhDgzWTtvftwcoDKeqTBO;

		private int HpRbpsInCeKpReePyXCKMvNJzegY;

		private static int lcxDiHLciMBZRoZyCEWIzEIMAtjg;

		public int id => JlIZbjlngXLjPYcGHxRQmuMPOIoH;

		public ControllerTemplateElementType elementType => eQMnNpZqoFetZzIUOgBCimEfZBHg;

		public bool enabled
		{
			get
			{
				return zHzjhKGTZHjZwJwsLgDYwfhvlPXB;
			}
			set
			{
				zHzjhKGTZHjZwJwsLgDYwfhvlPXB = value;
			}
		}

		public int actionId
		{
			get
			{
				return tnSnHITvhDgzWTtvftwcoDKeqTBO;
			}
			set
			{
				tnSnHITvhDgzWTtvftwcoDKeqTBO = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return HpRbpsInCeKpReePyXCKMvNJzegY;
			}
			set
			{
				HpRbpsInCeKpReePyXCKMvNJzegY = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0)
		{
			if (!InputTools.IsMappableType(P_0))
			{
				throw new ArgumentException(P_0.ToString() + " is not a supported mappable Controller Template element type.");
			}
			eQMnNpZqoFetZzIUOgBCimEfZBHg = P_0;
			JlIZbjlngXLjPYcGHxRQmuMPOIoH = lcxDiHLciMBZRoZyCEWIzEIMAtjg++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, ActionElementMap P_2)
			: this(P_0)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			tnSnHITvhDgzWTtvftwcoDKeqTBO = P_2._actionId;
			HpRbpsInCeKpReePyXCKMvNJzegY = P_1;
			zHzjhKGTZHjZwJwsLgDYwfhvlPXB = P_2.vWZNVuVXYnOfJimlqfUderrRDbRk;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, int P_2, bool P_3)
			: this(P_0)
		{
			tnSnHITvhDgzWTtvftwcoDKeqTBO = P_2;
			HpRbpsInCeKpReePyXCKMvNJzegY = P_1;
			zHzjhKGTZHjZwJwsLgDYwfhvlPXB = P_3;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap P_0)
		{
		}

		internal int mKIGHQDrhuZPlEcYQykrUxNuvePFA(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			int num = UeqMxHFOCXGFIuFVyClOqBoyYfAS(P_0, P_1, P_2);
			if (num == 0)
			{
				return 0;
			}
			int num2 = P_1.Count - num;
			for (int i = 0; i < num; i++)
			{
				int index = num2 + i;
				P_1[index].vWZNVuVXYnOfJimlqfUderrRDbRk = zHzjhKGTZHjZwJwsLgDYwfhvlPXB;
				P_1[index]._actionId = tnSnHITvhDgzWTtvftwcoDKeqTBO;
			}
			return num;
		}

		internal SerializedObject xqVohyVImLDPxhDDkAznNHGyIUmDb()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			nbRcGqFmdPBFbvAHNvzlHgGflOMSA(serializedObject);
			return serializedObject;
		}

		internal virtual void nbRcGqFmdPBFbvAHNvzlHgGflOMSA(SerializedObject P_0)
		{
			P_0.Add("elementType", eQMnNpZqoFetZzIUOgBCimEfZBHg);
			P_0.Add("enabled", zHzjhKGTZHjZwJwsLgDYwfhvlPXB);
			P_0.Add("elementIdentifierId", HpRbpsInCeKpReePyXCKMvNJzegY);
			P_0.Add("actionId", tnSnHITvhDgzWTtvftwcoDKeqTBO);
		}

		internal virtual void cLonVRMJRJDDsWpsmpAImCfajIgS(SerializedObject P_0)
		{
			txUUIdgSWLFLImnbsyZmeDlMUMoh();
			P_0.TryGetDeserializedValueByRef("enabled", ref zHzjhKGTZHjZwJwsLgDYwfhvlPXB);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref HpRbpsInCeKpReePyXCKMvNJzegY);
			P_0.TryGetDeserializedValueByRef("actionId", ref tnSnHITvhDgzWTtvftwcoDKeqTBO);
		}

		internal virtual void txUUIdgSWLFLImnbsyZmeDlMUMoh()
		{
			zHzjhKGTZHjZwJwsLgDYwfhvlPXB = true;
			HpRbpsInCeKpReePyXCKMvNJzegY = -1;
			tnSnHITvhDgzWTtvftwcoDKeqTBO = -1;
		}

		internal abstract int PDhWRWWkrpCVXAekGUkBdBqvsXeU(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int UeqMxHFOCXGFIuFVyClOqBoyYfAS(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			IControllerTemplateElement element = P_0.GetElement(HpRbpsInCeKpReePyXCKMvNJzegY);
			if (element == null)
			{
				return 0;
			}
			IControllerTemplateElementSource source = element.source;
			if (source == null)
			{
				return 0;
			}
			return PDhWRWWkrpCVXAekGUkBdBqvsXeU(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap YIudOyAiyGFjUsJoFYtyjwZPOYBz(SerializedObject P_0)
		{
			if (P_0 == null)
			{
				return null;
			}
			if (!P_0.TryGetDeserializedValue<ControllerTemplateElementType>("elementType", out var value))
			{
				return null;
			}
			return value switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal static ControllerTemplateActionElementMap OeRWdwrOMaSLwSuIbhdsksrgwJXN(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (P_0.elementType == ControllerTemplateElementType.Axis)
			{
				return new ControllerTemplateActionAxisMap(P_0.element.id, P_0.axisRange, P_1);
			}
			if (P_0.elementType == ControllerTemplateElementType.Button)
			{
				return new ControllerTemplateActionButtonMap(P_0.element.id, P_1);
			}
			throw new NotImplementedException();
		}

		internal static ControllerTemplateActionElementMap oOuyqdjomrtOyUekJNAQJuVucJtL(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ControllerTemplateElementType controllerTemplateElementType = tqmHLUqTfYnnflPJaWxRPIPYjlrx.JvBigfIhtPNrGARcJUTouJqnanOt(P_0._elementType, false);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			return controllerTemplateElementType switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.vWZNVuVXYnOfJimlqfUderrRDbRk), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.vWZNVuVXYnOfJimlqfUderrRDbRk), 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
