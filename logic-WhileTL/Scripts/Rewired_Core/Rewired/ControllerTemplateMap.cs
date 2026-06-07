using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

		private readonly int HZrDwOTOuvYGJkZRWDMDnUPlFNTs;

		private readonly Guid bErzlHrQJloJRuSMIPTmDsvAIQSS;

		private readonly List<ControllerTemplateActionElementMap> ymbFrIkjjhuQmoDKsJIxKkangGVyA;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> ZKFNenmoPDppKfStdoqZKYOGpNFs;

		private bool llkLFSoLVtaASCstwdnHCsIDxnhYb;

		private int tcPJVFoiXCpFPzPENESyHcvEyBTC;

		private int UHmwpxZBpVLOVfcAMEprUFHPeVMi;

		private int nMapghGlXgCIWGnljqJYHZTbAAPub = -1;

		private static int ulWtfUskAUOgITiXPKTmqmnViVjC;

		public int id
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return -1;
				}
				return HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
			}
		}

		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return Guid.Empty;
				}
				return bErzlHrQJloJRuSMIPTmDsvAIQSS;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				return llkLFSoLVtaASCstwdnHCsIDxnhYb;
			}
			set
			{
				llkLFSoLVtaASCstwdnHCsIDxnhYb = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return -1;
				}
				return tcPJVFoiXCpFPzPENESyHcvEyBTC;
			}
			internal set
			{
				tcPJVFoiXCpFPzPENESyHcvEyBTC = num;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return -1;
				}
				return UHmwpxZBpVLOVfcAMEprUFHPeVMi;
			}
			internal set
			{
				UHmwpxZBpVLOVfcAMEprUFHPeVMi = uHmwpxZBpVLOVfcAMEprUFHPeVMi;
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return ZKFNenmoPDppKfStdoqZKYOGpNFs;
			}
		}

		internal ControllerTemplateMap(Guid P_0)
		{
			HZrDwOTOuvYGJkZRWDMDnUPlFNTs = ulWtfUskAUOgITiXPKTmqmnViVjC++;
			TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput._id;
			bErzlHrQJloJRuSMIPTmDsvAIQSS = P_0;
			ymbFrIkjjhuQmoDKsJIxKkangGVyA = new List<ControllerTemplateActionElementMap>();
			ZKFNenmoPDppKfStdoqZKYOGpNFs = new ReadOnlyCollection<ControllerTemplateActionElementMap>(ymbFrIkjjhuQmoDKsJIxKkangGVyA);
			llkLFSoLVtaASCstwdnHCsIDxnhYb = true;
		}

		internal ControllerTemplateMap(Guid P_0, int P_1, int P_2, int P_3)
			: this(P_0)
		{
			tcPJVFoiXCpFPzPENESyHcvEyBTC = P_1;
			UHmwpxZBpVLOVfcAMEprUFHPeVMi = P_2;
			nMapghGlXgCIWGnljqJYHZTbAAPub = P_3;
		}

		public string ToXmlString()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return string.Empty;
			}
			try
			{
				return OwZlvwNnIfDEsAMweyvGbtLoYQJtA().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return string.Empty;
			}
			try
			{
				return OwZlvwNnIfDEsAMweyvGbtLoYQJtA().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			IControllerTemplate template = controller.GetTemplate(bErzlHrQJloJRuSMIPTmDsvAIQSS);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			ControllerMap controllerMap = ControllerMap.goGesjEFofcTayLyzynfoITRPCBk(controller.type);
			controllerMap.categoryId = tcPJVFoiXCpFPzPENESyHcvEyBTC;
			controllerMap.layoutId = UHmwpxZBpVLOVfcAMEprUFHPeVMi;
			if (nMapghGlXgCIWGnljqJYHZTbAAPub >= 0)
			{
				controllerMap.sourceMapId = nMapghGlXgCIWGnljqJYHZTbAAPub;
			}
			controllerMap.controllerId = controller.id;
			controllerMap.enabled = llkLFSoLVtaASCstwdnHCsIDxnhYb;
			controllerMap.hardwareGuid = controller.ajOkBXCGxlWjiAJvaOHxjyadfWfu;
			using TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>();
			List<ActionElementMap> list = tList.list;
			for (int i = 0; i < ymbFrIkjjhuQmoDKsJIxKkangGVyA.Count; i++)
			{
				ymbFrIkjjhuQmoDKsJIxKkangGVyA[i].KDsQeGOpQsfUwCCmDKasFCfGgLthB(template, list, false);
				for (int j = 0; j < list.Count; j++)
				{
					controllerMap.gWhjoTRNRldWcTlFdhKHpqWCipZj(list[j]);
				}
			}
			return controllerMap;
		}

		internal virtual void tnEqLMFFwugjoHOyMvcImNymgKGl(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.adZRTZDsgqtDqZBIYAKuebvqeDeUA
			{
				DBsVPUbyEmkoGqiATtBbUGsLwABr = "dataVersion",
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = 1.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.adZRTZDsgqtDqZBIYAKuebvqeDeUA
			{
				DBsVPUbyEmkoGqiATtBbUGsLwABr = "templateTypeGuid",
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = bErzlHrQJloJRuSMIPTmDsvAIQSS.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.adZRTZDsgqtDqZBIYAKuebvqeDeUA
			{
				zgPaEzAbwsGcNWlXnJVzKkGnHIbhb = "xmlns",
				DBsVPUbyEmkoGqiATtBbUGsLwABr = "xsi",
				OTermNiKyMWnSeUawIBObeynBxKj = null,
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.adZRTZDsgqtDqZBIYAKuebvqeDeUA
			{
				zgPaEzAbwsGcNWlXnJVzKkGnHIbhb = "xsi",
				DBsVPUbyEmkoGqiATtBbUGsLwABr = "schemaLocation",
				OTermNiKyMWnSeUawIBObeynBxKj = null,
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
			});
			P_0.Add("templateTypeGuid", bErzlHrQJloJRuSMIPTmDsvAIQSS);
			P_0.Add("enabled", llkLFSoLVtaASCstwdnHCsIDxnhYb);
			P_0.Add("categoryId", tcPJVFoiXCpFPzPENESyHcvEyBTC);
			P_0.Add("layoutId", UHmwpxZBpVLOVfcAMEprUFHPeVMi);
			P_0.Add("sourceMapId", nMapghGlXgCIWGnljqJYHZTbAAPub);
			int count = ymbFrIkjjhuQmoDKsJIxKkangGVyA.Count;
			List<object> list = new List<object>();
			P_0.Add("elementMaps", list);
			for (int i = 0; i < count; i++)
			{
				if (ymbFrIkjjhuQmoDKsJIxKkangGVyA[i] != null)
				{
					list.Add(ymbFrIkjjhuQmoDKsJIxKkangGVyA[i].OwZlvwNnIfDEsAMweyvGbtLoYQJtA());
				}
			}
		}

		internal virtual void xIgDRHQmTOVJkRVsknhXpBHuPygR(SerializedObject P_0)
		{
			HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
			P_0.TryGetDeserializedValueByRef("enabled", ref llkLFSoLVtaASCstwdnHCsIDxnhYb);
			P_0.TryGetDeserializedValueByRef("categoryId", ref tcPJVFoiXCpFPzPENESyHcvEyBTC);
			P_0.TryGetDeserializedValueByRef("layoutId", ref UHmwpxZBpVLOVfcAMEprUFHPeVMi);
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref nMapghGlXgCIWGnljqJYHZTbAAPub);
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
			{
				return;
			}
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.goGesjEFofcTayLyzynfoITRPCBk(value2);
					if (controllerTemplateActionElementMap != null)
					{
						GyVpFotNIqdiYVGDDCqmhxxpOwJuA(controllerTemplateActionElementMap);
					}
				}
			}
		}

		private void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
			llkLFSoLVtaASCstwdnHCsIDxnhYb = true;
			tcPJVFoiXCpFPzPENESyHcvEyBTC = -1;
			UHmwpxZBpVLOVfcAMEprUFHPeVMi = -1;
			nMapghGlXgCIWGnljqJYHZTbAAPub = -1;
			ymbFrIkjjhuQmoDKsJIxKkangGVyA.Clear();
		}

		private SerializedObject OwZlvwNnIfDEsAMweyvGbtLoYQJtA()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			tnEqLMFFwugjoHOyMvcImNymgKGl(serializedObject);
			return serializedObject;
		}

		internal void GyVpFotNIqdiYVGDDCqmhxxpOwJuA(ControllerTemplateActionElementMap P_0)
		{
			if (P_0 != null)
			{
				ymbFrIkjjhuQmoDKsJIxKkangGVyA.Add(P_0);
			}
		}

		internal static ControllerTemplateMap AnbJyIviMxdyjeorIFdTSYjhrGvh(IControllerTemplate P_0, ControllerMap P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			if (!ReInput.isReady)
			{
				throw new Exception("Rewired is not initialized.");
			}
			Controller controller = ReInput.controllers.GetController(P_1.controllerType, P_1.controllerId);
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
				return null;
			}
			if (!controller.ImplementsTemplate(P_0.typeGuid))
			{
				Logger.LogError("The Controller does not implement the Controller Template.", requiredThreadSafety: true);
				return null;
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(P_0.typeGuid);
			controllerTemplateMap.llkLFSoLVtaASCstwdnHCsIDxnhYb = P_1.enabled;
			controllerTemplateMap.tcPJVFoiXCpFPzPENESyHcvEyBTC = P_1.categoryId;
			controllerTemplateMap.UHmwpxZBpVLOVfcAMEprUFHPeVMi = P_1.layoutId;
			controllerTemplateMap.nMapghGlXgCIWGnljqJYHZTbAAPub = P_1.sourceMapId;
			using TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>();
			List<ControllerTemplateElementTarget> list = tList.list;
			foreach (ActionElementMap allMap in P_1.AllMaps)
			{
				if (P_0.GetElementTargets(allMap, list) > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						controllerTemplateMap.GyVpFotNIqdiYVGDDCqmhxxpOwJuA(ControllerTemplateActionElementMap.goGesjEFofcTayLyzynfoITRPCBk(list[i], allMap));
					}
				}
			}
			return controllerTemplateMap;
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			try
			{
				return TFSaJDjUnPUEiGAJaOFGnSSwjyRKA(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from XML! " + ex.Message);
				return null;
			}
		}

		public static ControllerTemplateMap FromJson(string jsonString)
		{
			try
			{
				return TFSaJDjUnPUEiGAJaOFGnSSwjyRKA(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				return null;
			}
		}

		private static ControllerTemplateMap TFSaJDjUnPUEiGAJaOFGnSSwjyRKA(SerializedObject P_0)
		{
			if (!P_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.xIgDRHQmTOVJkRVsknhXpBHuPygR(P_0);
			return controllerTemplateMap;
		}
	}
}
