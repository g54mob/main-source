using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int XGCOVDjTqqrOzoeKWuzdjwJQVwjr;

		private readonly ControllerTemplateElementType uNYwtHFLugvdlVqYTXgrlKfqbvSv;

		private bool nTxejLhGNapkdhhkCeymPfwaTHKOA;

		private int rEWJHgPmzkqpafhjamMNlBHvvGSk;

		private int DdFjMXrECTkfGIXbdEepaYVCGfvc;

		private static int xkhRRpZYsbiOrURcTsWreAFTruwW;

		public int id => XGCOVDjTqqrOzoeKWuzdjwJQVwjr;

		public ControllerTemplateElementType elementType => uNYwtHFLugvdlVqYTXgrlKfqbvSv;

		public bool enabled
		{
			get
			{
				return nTxejLhGNapkdhhkCeymPfwaTHKOA;
			}
			set
			{
				nTxejLhGNapkdhhkCeymPfwaTHKOA = value;
			}
		}

		public int actionId
		{
			get
			{
				return rEWJHgPmzkqpafhjamMNlBHvvGSk;
			}
			set
			{
				rEWJHgPmzkqpafhjamMNlBHvvGSk = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return DdFjMXrECTkfGIXbdEepaYVCGfvc;
			}
			set
			{
				DdFjMXrECTkfGIXbdEepaYVCGfvc = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0)
		{
			if (!InputTools.IsMappableType(P_0))
			{
				throw new ArgumentException(P_0.ToString() + " is not a supported mappable Controller Template element type.");
			}
			uNYwtHFLugvdlVqYTXgrlKfqbvSv = P_0;
			XGCOVDjTqqrOzoeKWuzdjwJQVwjr = xkhRRpZYsbiOrURcTsWreAFTruwW++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, ActionElementMap P_2)
			: this(P_0)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			rEWJHgPmzkqpafhjamMNlBHvvGSk = P_2._actionId;
			DdFjMXrECTkfGIXbdEepaYVCGfvc = P_1;
			nTxejLhGNapkdhhkCeymPfwaTHKOA = P_2.hrXjVMVBGWHRhCIrzlnSmtoGojQeb;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, int P_2, bool P_3)
			: this(P_0)
		{
			rEWJHgPmzkqpafhjamMNlBHvvGSk = P_2;
			DdFjMXrECTkfGIXbdEepaYVCGfvc = P_1;
			nTxejLhGNapkdhhkCeymPfwaTHKOA = P_3;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap P_0)
		{
		}

		internal int wzAHCovxgROxTCCXLwRKsKihCdYf(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
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
			int num = OAqTUlPmMabXiYfVpexnenvrkJLoA(P_0, P_1, P_2);
			if (num == 0)
			{
				return 0;
			}
			int num2 = P_1.Count - num;
			for (int i = 0; i < num; i++)
			{
				int index = num2 + i;
				P_1[index].hrXjVMVBGWHRhCIrzlnSmtoGojQeb = nTxejLhGNapkdhhkCeymPfwaTHKOA;
				P_1[index]._actionId = rEWJHgPmzkqpafhjamMNlBHvvGSk;
			}
			return num;
		}

		internal SerializedObject luBtbIRTiqMkRzaVvvqQOTRzccbI()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			fNGIWqreoGiBuiZUttQfbZoioTh(serializedObject);
			return serializedObject;
		}

		internal virtual void fNGIWqreoGiBuiZUttQfbZoioTh(SerializedObject P_0)
		{
			P_0.Add("elementType", uNYwtHFLugvdlVqYTXgrlKfqbvSv);
			P_0.Add("enabled", nTxejLhGNapkdhhkCeymPfwaTHKOA);
			P_0.Add("elementIdentifierId", DdFjMXrECTkfGIXbdEepaYVCGfvc);
			P_0.Add("actionId", rEWJHgPmzkqpafhjamMNlBHvvGSk);
		}

		internal virtual void oHgPtbWlDmjEOmcsdWnjfXkvQqvp(SerializedObject P_0)
		{
			htARSTejImnMkQLpfikBEjqHlclqA();
			P_0.TryGetDeserializedValueByRef("enabled", ref nTxejLhGNapkdhhkCeymPfwaTHKOA);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref DdFjMXrECTkfGIXbdEepaYVCGfvc);
			P_0.TryGetDeserializedValueByRef("actionId", ref rEWJHgPmzkqpafhjamMNlBHvvGSk);
		}

		internal virtual void htARSTejImnMkQLpfikBEjqHlclqA()
		{
			nTxejLhGNapkdhhkCeymPfwaTHKOA = true;
			DdFjMXrECTkfGIXbdEepaYVCGfvc = -1;
			rEWJHgPmzkqpafhjamMNlBHvvGSk = -1;
		}

		internal abstract int LFpRngYfuMIntwwBHmVaglJohPrD(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int OAqTUlPmMabXiYfVpexnenvrkJLoA(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			IControllerTemplateElement element = P_0.GetElement(DdFjMXrECTkfGIXbdEepaYVCGfvc);
			if (element == null)
			{
				return 0;
			}
			IControllerTemplateElementSource source = element.source;
			if (source == null)
			{
				return 0;
			}
			return LFpRngYfuMIntwwBHmVaglJohPrD(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap WmySUueonAusalsWzxFTjISeiQnA(SerializedObject P_0)
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

		internal static ControllerTemplateActionElementMap AGZfMShSgHMRGiYawdbTbJurbqCI(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
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

		internal static ControllerTemplateActionElementMap axaloRdZsWPaYeTkAQBbCIOleYiw(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ControllerTemplateElementType controllerTemplateElementType = bVcNkmaJvbHeBNQRpaleQvWHeXqv.TNHBwBMkdeWayymwSdZZbFdaDBNT(P_0._elementType, false);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			return controllerTemplateElementType switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.hrXjVMVBGWHRhCIrzlnSmtoGojQeb), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.hrXjVMVBGWHRhCIrzlnSmtoGojQeb), 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
