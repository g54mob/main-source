using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int fOjavGziuUSawAgvwyVARpyRBVx;

		private readonly ControllerTemplateElementType yWNDZKfljBHzdFXVgCeuIlnzKfx;

		private bool TAiAzEAcNOkrpYWJEmhYYqnFvpF;

		private int sRbRrhSYcsdTbzpQQADExfvLSkq;

		private int aKTKfMYcYdTWZLyYfpZoZfzZGQT;

		private static int KoEecjMjeddotFrYhEXbrGTpJiDT;

		public int id => fOjavGziuUSawAgvwyVARpyRBVx;

		public ControllerTemplateElementType elementType => yWNDZKfljBHzdFXVgCeuIlnzKfx;

		public bool enabled
		{
			get
			{
				return TAiAzEAcNOkrpYWJEmhYYqnFvpF;
			}
			set
			{
				TAiAzEAcNOkrpYWJEmhYYqnFvpF = value;
			}
		}

		public int actionId
		{
			get
			{
				return sRbRrhSYcsdTbzpQQADExfvLSkq;
			}
			set
			{
				sRbRrhSYcsdTbzpQQADExfvLSkq = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return aKTKfMYcYdTWZLyYfpZoZfzZGQT;
			}
			set
			{
				aKTKfMYcYdTWZLyYfpZoZfzZGQT = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType)
		{
			if (!InputTools.IsMappableType(elementType))
			{
				throw new ArgumentException(string.Concat(elementType, " is not a supported mappable Controller Template element type."));
			}
			yWNDZKfljBHzdFXVgCeuIlnzKfx = elementType;
			fOjavGziuUSawAgvwyVARpyRBVx = KoEecjMjeddotFrYhEXbrGTpJiDT++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType, int elementIdentifierId, ActionElementMap actionElementMap)
			: this(elementType)
		{
			if (actionElementMap == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			sRbRrhSYcsdTbzpQQADExfvLSkq = actionElementMap._actionId;
			aKTKfMYcYdTWZLyYfpZoZfzZGQT = elementIdentifierId;
			TAiAzEAcNOkrpYWJEmhYYqnFvpF = actionElementMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType elementType, int elementIdentifierId, int actionId, bool enabled)
			: this(elementType)
		{
			sRbRrhSYcsdTbzpQQADExfvLSkq = actionId;
			aKTKfMYcYdTWZLyYfpZoZfzZGQT = elementIdentifierId;
			TAiAzEAcNOkrpYWJEmhYYqnFvpF = enabled;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap actionElementMap)
		{
		}

		internal int ovsfoAcKwDqKLgEubpwjaEQILIB(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
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
			int num = nvjAdzkCLwewaKhBANwcGMQaFLen(P_0, P_1, P_2);
			if (num == 0)
			{
				return 0;
			}
			int num2 = P_1.Count - num;
			for (int i = 0; i < num; i++)
			{
				int index = num2 + i;
				P_1[index].TAiAzEAcNOkrpYWJEmhYYqnFvpF = TAiAzEAcNOkrpYWJEmhYYqnFvpF;
				P_1[index]._actionId = sRbRrhSYcsdTbzpQQADExfvLSkq;
			}
			return num;
		}

		internal SerializedObject qnRcKibdUQgUDehMYaMNRcmEEUp()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			qnRcKibdUQgUDehMYaMNRcmEEUp(serializedObject);
			return serializedObject;
		}

		internal virtual void qnRcKibdUQgUDehMYaMNRcmEEUp(SerializedObject P_0)
		{
			P_0.Add("elementType", yWNDZKfljBHzdFXVgCeuIlnzKfx);
			P_0.Add("enabled", TAiAzEAcNOkrpYWJEmhYYqnFvpF);
			P_0.Add("elementIdentifierId", aKTKfMYcYdTWZLyYfpZoZfzZGQT);
			P_0.Add("actionId", sRbRrhSYcsdTbzpQQADExfvLSkq);
		}

		internal virtual void JYyEPkmZztzXfbEgKghAFieAytO(SerializedObject P_0)
		{
			dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			P_0.TryGetDeserializedValueByRef("enabled", ref TAiAzEAcNOkrpYWJEmhYYqnFvpF);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref aKTKfMYcYdTWZLyYfpZoZfzZGQT);
			P_0.TryGetDeserializedValueByRef("actionId", ref sRbRrhSYcsdTbzpQQADExfvLSkq);
		}

		internal virtual void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
		{
			TAiAzEAcNOkrpYWJEmhYYqnFvpF = true;
			aKTKfMYcYdTWZLyYfpZoZfzZGQT = -1;
			sRbRrhSYcsdTbzpQQADExfvLSkq = -1;
		}

		internal abstract int DWiXTBvSexeltdYwQLfeaasOKQSe(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int nvjAdzkCLwewaKhBANwcGMQaFLen(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			IControllerTemplateElement element = P_0.GetElement(aKTKfMYcYdTWZLyYfpZoZfzZGQT);
			if (element == null)
			{
				return 0;
			}
			IControllerTemplateElementSource source = element.source;
			if (source == null)
			{
				return 0;
			}
			return DWiXTBvSexeltdYwQLfeaasOKQSe(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap AxGMnpcloIAUTQTSFCdghQatHHxd(SerializedObject P_0)
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

		internal static ControllerTemplateActionElementMap AxGMnpcloIAUTQTSFCdghQatHHxd(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
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

		internal static ControllerTemplateActionElementMap AxGMnpcloIAUTQTSFCdghQatHHxd(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ControllerTemplateElementType controllerTemplateElementType = bEUEMZWgpCwBXKGSoWTyQESUVD.PvAqsaUpMgXOMnQDleuMFTFrJXd(P_0._elementType, false);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			return controllerTemplateElementType switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.TAiAzEAcNOkrpYWJEmhYYqnFvpF), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.TAiAzEAcNOkrpYWJEmhYYqnFvpF), 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
