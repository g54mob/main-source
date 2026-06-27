using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int ICrCZKexpkxcIKPYlqUtKRAfVSIV;

		private readonly ControllerTemplateElementType npjdYREvoeLEirKQmBvYOcmPRznb;

		private bool cLIdZIREomKbCHBytVZaQntVnQnG;

		private int sDdKPzElmmPIDLnbHMDZGOWGhHlT;

		private int IfeYbHoMLPwOIqrFShjvPNZxluWt;

		private static int qzOBJiYjbnHgCgFechndaPWcwOToA;

		public int id => ICrCZKexpkxcIKPYlqUtKRAfVSIV;

		public ControllerTemplateElementType elementType => npjdYREvoeLEirKQmBvYOcmPRznb;

		public bool enabled
		{
			get
			{
				return cLIdZIREomKbCHBytVZaQntVnQnG;
			}
			set
			{
				cLIdZIREomKbCHBytVZaQntVnQnG = value;
			}
		}

		public int actionId
		{
			get
			{
				return sDdKPzElmmPIDLnbHMDZGOWGhHlT;
			}
			set
			{
				sDdKPzElmmPIDLnbHMDZGOWGhHlT = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return IfeYbHoMLPwOIqrFShjvPNZxluWt;
			}
			set
			{
				IfeYbHoMLPwOIqrFShjvPNZxluWt = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0)
		{
			if (!InputTools.IsMappableType(P_0))
			{
				throw new ArgumentException(P_0.ToString() + " is not a supported mappable Controller Template element type.");
			}
			npjdYREvoeLEirKQmBvYOcmPRznb = P_0;
			ICrCZKexpkxcIKPYlqUtKRAfVSIV = qzOBJiYjbnHgCgFechndaPWcwOToA++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, ActionElementMap P_2)
			: this(P_0)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			sDdKPzElmmPIDLnbHMDZGOWGhHlT = P_2._actionId;
			IfeYbHoMLPwOIqrFShjvPNZxluWt = P_1;
			cLIdZIREomKbCHBytVZaQntVnQnG = P_2.amuHcHIpLQrjMsPzQKBWApxhXPxj;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, int P_2, bool P_3)
			: this(P_0)
		{
			sDdKPzElmmPIDLnbHMDZGOWGhHlT = P_2;
			IfeYbHoMLPwOIqrFShjvPNZxluWt = P_1;
			cLIdZIREomKbCHBytVZaQntVnQnG = P_3;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap P_0)
		{
		}

		internal int njhUJjqKcXfmsAqIenXKDLVOqsfIA(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
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
			int num = BEXCIuYyXenTTiVsKQzjMyCWxGsF(P_0, P_1, P_2);
			if (num == 0)
			{
				return 0;
			}
			int num2 = P_1.Count - num;
			for (int i = 0; i < num; i++)
			{
				int index = num2 + i;
				P_1[index].amuHcHIpLQrjMsPzQKBWApxhXPxj = cLIdZIREomKbCHBytVZaQntVnQnG;
				P_1[index]._actionId = sDdKPzElmmPIDLnbHMDZGOWGhHlT;
			}
			return num;
		}

		internal SerializedObject gMkjhDYidgQaoBHNEqMOzlWUcQWM()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			kbkaGXJhmuyekOMJziIUTMQPuCadA(serializedObject);
			return serializedObject;
		}

		internal virtual void kbkaGXJhmuyekOMJziIUTMQPuCadA(SerializedObject P_0)
		{
			P_0.Add("elementType", npjdYREvoeLEirKQmBvYOcmPRznb);
			P_0.Add("enabled", cLIdZIREomKbCHBytVZaQntVnQnG);
			P_0.Add("elementIdentifierId", IfeYbHoMLPwOIqrFShjvPNZxluWt);
			P_0.Add("actionId", sDdKPzElmmPIDLnbHMDZGOWGhHlT);
		}

		internal virtual void xwZjRkRdGaGqfQSgCLUjULhWfQEJA(SerializedObject P_0)
		{
			yqfOlWnGByEuDyadYiPBHUxiJAGIA();
			P_0.TryGetDeserializedValueByRef("enabled", ref cLIdZIREomKbCHBytVZaQntVnQnG);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref IfeYbHoMLPwOIqrFShjvPNZxluWt);
			P_0.TryGetDeserializedValueByRef("actionId", ref sDdKPzElmmPIDLnbHMDZGOWGhHlT);
		}

		internal virtual void yqfOlWnGByEuDyadYiPBHUxiJAGIA()
		{
			cLIdZIREomKbCHBytVZaQntVnQnG = true;
			IfeYbHoMLPwOIqrFShjvPNZxluWt = -1;
			sDdKPzElmmPIDLnbHMDZGOWGhHlT = -1;
		}

		internal abstract int MXQGNbGBwAaqKFWwGgHyKFwEXZGXb(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int BEXCIuYyXenTTiVsKQzjMyCWxGsF(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			IControllerTemplateElement element = P_0.GetElement(IfeYbHoMLPwOIqrFShjvPNZxluWt);
			if (element == null)
			{
				return 0;
			}
			IControllerTemplateElementSource source = element.source;
			if (source == null)
			{
				return 0;
			}
			return MXQGNbGBwAaqKFWwGgHyKFwEXZGXb(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap NsRYOXjYbblIPVqixiSXSKNbVOjV(SerializedObject P_0)
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

		internal static ControllerTemplateActionElementMap JywGjTkiJDyelJIIDKOJEAjCGDxmc(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
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

		internal static ControllerTemplateActionElementMap nMZCsGwilGiKbeCcbNmpejDkMmLmc(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ControllerTemplateElementType controllerTemplateElementType = moNrVnhMyxFSevnVWYTclYHmdtVI.MVoneWLkkmeMXQTwvZgHYVaXfzqk(P_0._elementType, false);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			return controllerTemplateElementType switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.amuHcHIpLQrjMsPzQKBWApxhXPxj), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.amuHcHIpLQrjMsPzQKBWApxhXPxj), 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
