using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int JYRMuwETpVNRqJXmtBgBFhZdTeP;

		private readonly ControllerTemplateElementType IDlBgcIyMAualOodjeMvFCUPFMBW;

		private bool fnEBjitvkHhPtXTzRLmBYpIxFbt;

		private int CYBGYVfPDvCydagiBzJBExAfcuYb;

		private int MAfbKattduhdBJEmosLzsDAtqCjp;

		private static int sletNRlrLmUZzqGowqNsMpsFacl;

		public int id => JYRMuwETpVNRqJXmtBgBFhZdTeP;

		public ControllerTemplateElementType elementType => IDlBgcIyMAualOodjeMvFCUPFMBW;

		public bool enabled
		{
			get
			{
				return fnEBjitvkHhPtXTzRLmBYpIxFbt;
			}
			set
			{
				fnEBjitvkHhPtXTzRLmBYpIxFbt = value;
			}
		}

		public int actionId
		{
			get
			{
				return CYBGYVfPDvCydagiBzJBExAfcuYb;
			}
			set
			{
				CYBGYVfPDvCydagiBzJBExAfcuYb = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return MAfbKattduhdBJEmosLzsDAtqCjp;
			}
			set
			{
				MAfbKattduhdBJEmosLzsDAtqCjp = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType)
		{
			if (!InputTools.IsMappableType(elementType))
			{
				throw new ArgumentException(string.Concat(elementType, " is not a supported mappable Controller Template element type."));
			}
			IDlBgcIyMAualOodjeMvFCUPFMBW = elementType;
			JYRMuwETpVNRqJXmtBgBFhZdTeP = sletNRlrLmUZzqGowqNsMpsFacl++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType, int elementIdentifierId, ActionElementMap actionElementMap)
			: this(elementType)
		{
			if (actionElementMap == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			CYBGYVfPDvCydagiBzJBExAfcuYb = actionElementMap._actionId;
			MAfbKattduhdBJEmosLzsDAtqCjp = elementIdentifierId;
			fnEBjitvkHhPtXTzRLmBYpIxFbt = actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType, int elementIdentifierId, int actionId, bool enabled)
			: this(elementType)
		{
			CYBGYVfPDvCydagiBzJBExAfcuYb = actionId;
			MAfbKattduhdBJEmosLzsDAtqCjp = elementIdentifierId;
			fnEBjitvkHhPtXTzRLmBYpIxFbt = enabled;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap actionElementMap)
		{
		}

		internal int QLMQQiTDjQNXTnBeehpomRheiZj(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
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
			int num = DEDlKJbmmvWJugkbDBavKQjWuDC(P_0, P_1, P_2);
			if (num == 0)
			{
				return 0;
			}
			int num2 = P_1.Count - num;
			for (int i = 0; i < num; i++)
			{
				int index = num2 + i;
				P_1[index].fnEBjitvkHhPtXTzRLmBYpIxFbt = fnEBjitvkHhPtXTzRLmBYpIxFbt;
				P_1[index]._actionId = CYBGYVfPDvCydagiBzJBExAfcuYb;
			}
			return num;
		}

		internal SerializedObject MtzBZMSurJCTTdjsBqkSRhDyHCFi()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			MtzBZMSurJCTTdjsBqkSRhDyHCFi(serializedObject);
			return serializedObject;
		}

		internal virtual void MtzBZMSurJCTTdjsBqkSRhDyHCFi(SerializedObject P_0)
		{
			P_0.Add("elementType", IDlBgcIyMAualOodjeMvFCUPFMBW);
			P_0.Add("enabled", fnEBjitvkHhPtXTzRLmBYpIxFbt);
			P_0.Add("elementIdentifierId", MAfbKattduhdBJEmosLzsDAtqCjp);
			P_0.Add("actionId", CYBGYVfPDvCydagiBzJBExAfcuYb);
		}

		internal virtual void tlMbXbDwaaKJTudkJIuTPdZmwuo(SerializedObject P_0)
		{
			VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			P_0.TryGetDeserializedValueByRef("enabled", ref fnEBjitvkHhPtXTzRLmBYpIxFbt);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref MAfbKattduhdBJEmosLzsDAtqCjp);
			P_0.TryGetDeserializedValueByRef("actionId", ref CYBGYVfPDvCydagiBzJBExAfcuYb);
		}

		internal virtual void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			fnEBjitvkHhPtXTzRLmBYpIxFbt = true;
			MAfbKattduhdBJEmosLzsDAtqCjp = -1;
			CYBGYVfPDvCydagiBzJBExAfcuYb = -1;
		}

		internal abstract int tPGjctEvLctErHTWNnUziXPyYAa(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int DEDlKJbmmvWJugkbDBavKQjWuDC(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			IControllerTemplateElement element = P_0.GetElement(MAfbKattduhdBJEmosLzsDAtqCjp);
			if (element == null)
			{
				return 0;
			}
			IControllerTemplateElementSource source = element.source;
			if (source == null)
			{
				return 0;
			}
			return tPGjctEvLctErHTWNnUziXPyYAa(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap ikoBGVHHLVNnLaVaWGffMETVhTJw(SerializedObject P_0)
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

		internal static ControllerTemplateActionElementMap ikoBGVHHLVNnLaVaWGffMETVhTJw(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
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

		internal static ControllerTemplateActionElementMap ikoBGVHHLVNnLaVaWGffMETVhTJw(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ControllerTemplateElementType controllerTemplateElementType = XqmnYoifzflCsKxcFaHDewlkEkh.bRoFBEhvbtKvQuxtaxsFNImJRNR(P_0._elementType, false);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			return controllerTemplateElementType switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.fnEBjitvkHhPtXTzRLmBYpIxFbt), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.fnEBjitvkHhPtXTzRLmBYpIxFbt), 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
