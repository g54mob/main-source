using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerTemplateActionElementMap
	{
		private readonly int HZrDwOTOuvYGJkZRWDMDnUPlFNTs;

		private readonly ControllerTemplateElementType QoNNWCBWhstwCjczWDBfosWZEUNR;

		private bool llkLFSoLVtaASCstwdnHCsIDxnhYb;

		private int WtxqRhyewFhRCZexgGgTPAkliDAd;

		private int MToyChcGWGmeBbeiJGjHlICtSgbd;

		private static int ulWtfUskAUOgITiXPKTmqmnViVjC;

		public int id => HZrDwOTOuvYGJkZRWDMDnUPlFNTs;

		public ControllerTemplateElementType elementType => QoNNWCBWhstwCjczWDBfosWZEUNR;

		public bool enabled
		{
			get
			{
				return llkLFSoLVtaASCstwdnHCsIDxnhYb;
			}
			set
			{
				llkLFSoLVtaASCstwdnHCsIDxnhYb = value;
			}
		}

		public int actionId
		{
			get
			{
				return WtxqRhyewFhRCZexgGgTPAkliDAd;
			}
			set
			{
				WtxqRhyewFhRCZexgGgTPAkliDAd = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return MToyChcGWGmeBbeiJGjHlICtSgbd;
			}
			set
			{
				MToyChcGWGmeBbeiJGjHlICtSgbd = value;
			}
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0)
		{
			if (!InputTools.IsMappableType(P_0))
			{
				throw new ArgumentException(P_0.ToString() + " is not a supported mappable Controller Template element type.");
			}
			QoNNWCBWhstwCjczWDBfosWZEUNR = P_0;
			HZrDwOTOuvYGJkZRWDMDnUPlFNTs = ulWtfUskAUOgITiXPKTmqmnViVjC++;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, ActionElementMap P_2)
			: this(P_0)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			WtxqRhyewFhRCZexgGgTPAkliDAd = P_2._actionId;
			MToyChcGWGmeBbeiJGjHlICtSgbd = P_1;
			llkLFSoLVtaASCstwdnHCsIDxnhYb = P_2.llkLFSoLVtaASCstwdnHCsIDxnhYb;
		}

		internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, int P_2, bool P_3)
			: this(P_0)
		{
			WtxqRhyewFhRCZexgGgTPAkliDAd = P_2;
			MToyChcGWGmeBbeiJGjHlICtSgbd = P_1;
			llkLFSoLVtaASCstwdnHCsIDxnhYb = P_3;
		}

		protected ControllerTemplateActionElementMap(ActionElementMap P_0)
		{
		}

		internal int KDsQeGOpQsfUwCCmDKasFCfGgLthB(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
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
			int num = PrfcihiWNVAUJDNdkWhryMtSXTQU(P_0, P_1, P_2);
			if (num == 0)
			{
				return 0;
			}
			int num2 = P_1.Count - num;
			for (int i = 0; i < num; i++)
			{
				int index = num2 + i;
				P_1[index].llkLFSoLVtaASCstwdnHCsIDxnhYb = llkLFSoLVtaASCstwdnHCsIDxnhYb;
				P_1[index]._actionId = WtxqRhyewFhRCZexgGgTPAkliDAd;
			}
			return num;
		}

		internal SerializedObject OwZlvwNnIfDEsAMweyvGbtLoYQJtA()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			OwZlvwNnIfDEsAMweyvGbtLoYQJtA(serializedObject);
			return serializedObject;
		}

		internal virtual void OwZlvwNnIfDEsAMweyvGbtLoYQJtA(SerializedObject P_0)
		{
			P_0.Add("elementType", QoNNWCBWhstwCjczWDBfosWZEUNR);
			P_0.Add("enabled", llkLFSoLVtaASCstwdnHCsIDxnhYb);
			P_0.Add("elementIdentifierId", MToyChcGWGmeBbeiJGjHlICtSgbd);
			P_0.Add("actionId", WtxqRhyewFhRCZexgGgTPAkliDAd);
		}

		internal virtual void xIgDRHQmTOVJkRVsknhXpBHuPygR(SerializedObject P_0)
		{
			HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
			P_0.TryGetDeserializedValueByRef("enabled", ref llkLFSoLVtaASCstwdnHCsIDxnhYb);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref MToyChcGWGmeBbeiJGjHlICtSgbd);
			P_0.TryGetDeserializedValueByRef("actionId", ref WtxqRhyewFhRCZexgGgTPAkliDAd);
		}

		internal virtual void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
			llkLFSoLVtaASCstwdnHCsIDxnhYb = true;
			MToyChcGWGmeBbeiJGjHlICtSgbd = -1;
			WtxqRhyewFhRCZexgGgTPAkliDAd = -1;
		}

		internal abstract int xeeUWXXmkCBeEkgKwamzOWDeUHkL(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

		private int PrfcihiWNVAUJDNdkWhryMtSXTQU(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			IControllerTemplateElement element = P_0.GetElement(MToyChcGWGmeBbeiJGjHlICtSgbd);
			if (element == null)
			{
				return 0;
			}
			IControllerTemplateElementSource source = element.source;
			if (source == null)
			{
				return 0;
			}
			return xeeUWXXmkCBeEkgKwamzOWDeUHkL(source, P_1, P_2);
		}

		internal static ControllerTemplateActionElementMap goGesjEFofcTayLyzynfoITRPCBk(SerializedObject P_0)
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

		internal static ControllerTemplateActionElementMap goGesjEFofcTayLyzynfoITRPCBk(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
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

		internal static ControllerTemplateActionElementMap goGesjEFofcTayLyzynfoITRPCBk(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ControllerTemplateElementType controllerTemplateElementType = DXYiJElpUHxcPboaihvPaElwMWxMA.reIzLycMvLkHbHpqBbXZhmdLHmNC(P_0._elementType, false);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			return controllerTemplateElementType switch
			{
				ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.llkLFSoLVtaASCstwdnHCsIDxnhYb), 
				ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.llkLFSoLVtaASCstwdnHCsIDxnhYb), 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
