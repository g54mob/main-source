using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int kqvbpTxWGdGtrNRdxLepeZkwTJDn;

		private readonly ControllerTemplateElementType jRBPSVtNKcYysODJtvbPjIhQUBZJ;

		private bool KByWFLCBjjvqwXYVZFDfzPdklyjf;

		private int nqrNxyIjKJnAagqUPKmjCYvwkyMr;

		private int hkJhlFMpiETPSIkMyOmVuFxkJKlT;

		private static int VUOHkaMpEQjvkeUSeTqSzOROewhu;

		public int id => kqvbpTxWGdGtrNRdxLepeZkwTJDn;

		public ControllerTemplateElementType elementType => jRBPSVtNKcYysODJtvbPjIhQUBZJ;

		public bool enabled
		{
			get
			{
				return KByWFLCBjjvqwXYVZFDfzPdklyjf;
			}
			set
			{
				KByWFLCBjjvqwXYVZFDfzPdklyjf = value;
			}
		}

		public int actionId
		{
			get
			{
				return nqrNxyIjKJnAagqUPKmjCYvwkyMr;
			}
			set
			{
				nqrNxyIjKJnAagqUPKmjCYvwkyMr = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return hkJhlFMpiETPSIkMyOmVuFxkJKlT;
			}
			set
			{
				hkJhlFMpiETPSIkMyOmVuFxkJKlT = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0)
		{
			if (!InputTools.IsMappableType(P_0))
			{
				throw new ArgumentException(P_0.ToString() + " is not a supported mappable Controller Template element type.");
			}
			jRBPSVtNKcYysODJtvbPjIhQUBZJ = P_0;
			kqvbpTxWGdGtrNRdxLepeZkwTJDn = VUOHkaMpEQjvkeUSeTqSzOROewhu++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, ActionElementMap P_2)
			: this(P_0)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			nqrNxyIjKJnAagqUPKmjCYvwkyMr = P_2._actionId;
			hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_1;
			KByWFLCBjjvqwXYVZFDfzPdklyjf = P_2.KByWFLCBjjvqwXYVZFDfzPdklyjf;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, int P_2, bool P_3)
			: this(P_0)
		{
			nqrNxyIjKJnAagqUPKmjCYvwkyMr = P_2;
			hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_1;
			KByWFLCBjjvqwXYVZFDfzPdklyjf = P_3;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap P_0)
		{
		}

		internal int xualUTsmTwrgEnCOeUoQFfCnJRpl(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
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
			int num = kArGlaAAtNobdNgLHZNNdnSJhNQBA(P_0, P_1, P_2);
			if (num == 0)
			{
				return 0;
			}
			int num2 = P_1.Count - num;
			for (int i = 0; i < num; i++)
			{
				int index = num2 + i;
				P_1[index].KByWFLCBjjvqwXYVZFDfzPdklyjf = KByWFLCBjjvqwXYVZFDfzPdklyjf;
				P_1[index]._actionId = nqrNxyIjKJnAagqUPKmjCYvwkyMr;
			}
			return num;
		}

		internal SerializedObject pMFmgpdCytjWAfCkBRuiiiznUeVd()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			pMFmgpdCytjWAfCkBRuiiiznUeVd(serializedObject);
			return serializedObject;
		}

		internal virtual void pMFmgpdCytjWAfCkBRuiiiznUeVd(SerializedObject P_0)
		{
			P_0.Add("elementType", jRBPSVtNKcYysODJtvbPjIhQUBZJ);
			P_0.Add("enabled", KByWFLCBjjvqwXYVZFDfzPdklyjf);
			P_0.Add("elementIdentifierId", hkJhlFMpiETPSIkMyOmVuFxkJKlT);
			P_0.Add("actionId", nqrNxyIjKJnAagqUPKmjCYvwkyMr);
		}

		internal virtual void IqWUQdetEUgWKmOIFRihysPfqZgC(SerializedObject P_0)
		{
			wJjPIIRJfHhEbGedUconecGfiwzgB();
			P_0.TryGetDeserializedValueByRef("enabled", ref KByWFLCBjjvqwXYVZFDfzPdklyjf);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref hkJhlFMpiETPSIkMyOmVuFxkJKlT);
			P_0.TryGetDeserializedValueByRef("actionId", ref nqrNxyIjKJnAagqUPKmjCYvwkyMr);
		}

		internal virtual void wJjPIIRJfHhEbGedUconecGfiwzgB()
		{
			KByWFLCBjjvqwXYVZFDfzPdklyjf = true;
			hkJhlFMpiETPSIkMyOmVuFxkJKlT = -1;
			nqrNxyIjKJnAagqUPKmjCYvwkyMr = -1;
		}

		internal abstract int EbwwBWdfCAxikZkwZdUTTIgnVIcY(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int kArGlaAAtNobdNgLHZNNdnSJhNQBA(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			IControllerTemplateElement element = P_0.GetElement(hkJhlFMpiETPSIkMyOmVuFxkJKlT);
			if (element == null)
			{
				return 0;
			}
			IControllerTemplateElementSource source = element.source;
			if (source == null)
			{
				return 0;
			}
			return EbwwBWdfCAxikZkwZdUTTIgnVIcY(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap VxSNvmooWfTkIVcICGUZnqoUJPDW(SerializedObject P_0)
		{
			if (P_0 == null)
			{
				return null;
			}
			if (!P_0.TryGetDeserializedValue<ControllerTemplateElementType>("elementType", out var value))
			{
				return null;
			}
			switch (value)
			{
			case ControllerTemplateElementType.Axis:
				return new ControllerTemplateActionAxisMap(P_0);
			case ControllerTemplateElementType.Button:
				return new ControllerTemplateActionButtonMap(P_0);
			default:
				throw new NotImplementedException();
			}
		}

		internal static ControllerTemplateActionElementMap VxSNvmooWfTkIVcICGUZnqoUJPDW(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
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

		internal static ControllerTemplateActionElementMap VxSNvmooWfTkIVcICGUZnqoUJPDW(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ControllerTemplateElementType controllerTemplateElementType = uAOMfTHsnTLbvEUpHTchXYOhMgjh.KbOOarMfeRNXDeaPioFdqvTWLNBW(P_0._elementType, false);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			switch (controllerTemplateElementType)
			{
			case ControllerTemplateElementType.Axis:
				return new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.KByWFLCBjjvqwXYVZFDfzPdklyjf);
			case ControllerTemplateElementType.Button:
				return new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.KByWFLCBjjvqwXYVZFDfzPdklyjf);
			default:
				throw new NotImplementedException();
			}
		}
	}
}
