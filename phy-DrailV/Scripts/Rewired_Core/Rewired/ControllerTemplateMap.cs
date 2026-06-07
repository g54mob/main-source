using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

		private readonly int kqvbpTxWGdGtrNRdxLepeZkwTJDn;

		private readonly Guid IvbyYMNMdbgpjDCahkdWIJSJLMKN;

		private readonly List<ControllerTemplateActionElementMap> RPhAgZHvBdQlQuBcXGcNGvJisOJeA;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> moTjqiSlkXWLmWTkWEJvBbVRZUVd;

		private bool KByWFLCBjjvqwXYVZFDfzPdklyjf;

		private int IzDmCSEOWOACpGElimeSWXVZPwTT;

		private int rrgNxgxpDZgwtGcgleoFKBmKoeKVA;

		private int SPmjMmixsypQiGBMMrCeYAuDGnVF = -1;

		private static int VUOHkaMpEQjvkeUSeTqSzOROewhu;

		public int id
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return -1;
				}
				return kqvbpTxWGdGtrNRdxLepeZkwTJDn;
			}
		}

		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Guid.Empty;
				}
				return IvbyYMNMdbgpjDCahkdWIJSJLMKN;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				return KByWFLCBjjvqwXYVZFDfzPdklyjf;
			}
			set
			{
				KByWFLCBjjvqwXYVZFDfzPdklyjf = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return -1;
				}
				return IzDmCSEOWOACpGElimeSWXVZPwTT;
			}
			internal set
			{
				IzDmCSEOWOACpGElimeSWXVZPwTT = izDmCSEOWOACpGElimeSWXVZPwTT;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return -1;
				}
				return rrgNxgxpDZgwtGcgleoFKBmKoeKVA;
			}
			internal set
			{
				rrgNxgxpDZgwtGcgleoFKBmKoeKVA = num;
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return moTjqiSlkXWLmWTkWEJvBbVRZUVd;
			}
		}

		internal ControllerTemplateMap(Guid P_0)
		{
			kqvbpTxWGdGtrNRdxLepeZkwTJDn = VUOHkaMpEQjvkeUSeTqSzOROewhu++;
			oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput._id;
			IvbyYMNMdbgpjDCahkdWIJSJLMKN = P_0;
			RPhAgZHvBdQlQuBcXGcNGvJisOJeA = new List<ControllerTemplateActionElementMap>();
			moTjqiSlkXWLmWTkWEJvBbVRZUVd = new ReadOnlyCollection<ControllerTemplateActionElementMap>(RPhAgZHvBdQlQuBcXGcNGvJisOJeA);
			KByWFLCBjjvqwXYVZFDfzPdklyjf = true;
		}

		internal ControllerTemplateMap(Guid P_0, int P_1, int P_2, int P_3)
			: this(P_0)
		{
			IzDmCSEOWOACpGElimeSWXVZPwTT = P_1;
			rrgNxgxpDZgwtGcgleoFKBmKoeKVA = P_2;
			SPmjMmixsypQiGBMMrCeYAuDGnVF = P_3;
		}

		public string ToXmlString()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return string.Empty;
			}
			try
			{
				return pMFmgpdCytjWAfCkBRuiiiznUeVd().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return string.Empty;
			}
			try
			{
				return pMFmgpdCytjWAfCkBRuiiiznUeVd().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			IControllerTemplate template = controller.GetTemplate(IvbyYMNMdbgpjDCahkdWIJSJLMKN);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			ControllerMap controllerMap = ControllerMap.VxSNvmooWfTkIVcICGUZnqoUJPDW(controller.type);
			controllerMap.categoryId = IzDmCSEOWOACpGElimeSWXVZPwTT;
			controllerMap.layoutId = rrgNxgxpDZgwtGcgleoFKBmKoeKVA;
			if (SPmjMmixsypQiGBMMrCeYAuDGnVF >= 0)
			{
				controllerMap.sourceMapId = SPmjMmixsypQiGBMMrCeYAuDGnVF;
			}
			controllerMap.controllerId = controller.id;
			controllerMap.enabled = KByWFLCBjjvqwXYVZFDfzPdklyjf;
			controllerMap.hardwareGuid = controller.FZUSYXsTFrKCEfDGTdZDqHMyUGhC;
			using (TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>())
			{
				List<ActionElementMap> list = tList.list;
				for (int i = 0; i < RPhAgZHvBdQlQuBcXGcNGvJisOJeA.Count; i++)
				{
					RPhAgZHvBdQlQuBcXGcNGvJisOJeA[i].xualUTsmTwrgEnCOeUoQFfCnJRpl(template, list, false);
					for (int j = 0; j < list.Count; j++)
					{
						controllerMap.BTbXqEjOhhCEMqppIILjeDzBegNdA(list[j]);
					}
				}
				return controllerMap;
			}
		}

		internal virtual void AkUcpXbtGgaSOLgGtBKaSvRfkwYX(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.FTFUnSdjCkoGMcOadgOCoYMlThuL
			{
				uEkKFXXRykNWeZGsmzkXBCXWCSXG = "dataVersion",
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = 1.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.FTFUnSdjCkoGMcOadgOCoYMlThuL
			{
				uEkKFXXRykNWeZGsmzkXBCXWCSXG = "templateTypeGuid",
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = IvbyYMNMdbgpjDCahkdWIJSJLMKN.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.FTFUnSdjCkoGMcOadgOCoYMlThuL
			{
				KxTTmcDyYaBSfMPvUfdDpAxeKhlL = "xmlns",
				uEkKFXXRykNWeZGsmzkXBCXWCSXG = "xsi",
				bQsOsCQXaUMzqJWgNvgeirDgvXAS = null,
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.FTFUnSdjCkoGMcOadgOCoYMlThuL
			{
				KxTTmcDyYaBSfMPvUfdDpAxeKhlL = "xsi",
				uEkKFXXRykNWeZGsmzkXBCXWCSXG = "schemaLocation",
				bQsOsCQXaUMzqJWgNvgeirDgvXAS = null,
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
			});
			P_0.Add("templateTypeGuid", IvbyYMNMdbgpjDCahkdWIJSJLMKN);
			P_0.Add("enabled", KByWFLCBjjvqwXYVZFDfzPdklyjf);
			P_0.Add("categoryId", IzDmCSEOWOACpGElimeSWXVZPwTT);
			P_0.Add("layoutId", rrgNxgxpDZgwtGcgleoFKBmKoeKVA);
			P_0.Add("sourceMapId", SPmjMmixsypQiGBMMrCeYAuDGnVF);
			int count = RPhAgZHvBdQlQuBcXGcNGvJisOJeA.Count;
			List<object> list = new List<object>();
			P_0.Add("elementMaps", list);
			for (int i = 0; i < count; i++)
			{
				if (RPhAgZHvBdQlQuBcXGcNGvJisOJeA[i] != null)
				{
					list.Add(RPhAgZHvBdQlQuBcXGcNGvJisOJeA[i].pMFmgpdCytjWAfCkBRuiiiznUeVd());
				}
			}
		}

		internal virtual void IqWUQdetEUgWKmOIFRihysPfqZgC(SerializedObject P_0)
		{
			wJjPIIRJfHhEbGedUconecGfiwzgB();
			P_0.TryGetDeserializedValueByRef("enabled", ref KByWFLCBjjvqwXYVZFDfzPdklyjf);
			P_0.TryGetDeserializedValueByRef("categoryId", ref IzDmCSEOWOACpGElimeSWXVZPwTT);
			P_0.TryGetDeserializedValueByRef("layoutId", ref rrgNxgxpDZgwtGcgleoFKBmKoeKVA);
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref SPmjMmixsypQiGBMMrCeYAuDGnVF);
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
			{
				return;
			}
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.VxSNvmooWfTkIVcICGUZnqoUJPDW(value2);
					if (controllerTemplateActionElementMap != null)
					{
						hOLSMlXFsuVxuytviQkQgEIwFgJr(controllerTemplateActionElementMap);
					}
				}
			}
		}

		private void wJjPIIRJfHhEbGedUconecGfiwzgB()
		{
			KByWFLCBjjvqwXYVZFDfzPdklyjf = true;
			IzDmCSEOWOACpGElimeSWXVZPwTT = -1;
			rrgNxgxpDZgwtGcgleoFKBmKoeKVA = -1;
			SPmjMmixsypQiGBMMrCeYAuDGnVF = -1;
			RPhAgZHvBdQlQuBcXGcNGvJisOJeA.Clear();
		}

		private SerializedObject pMFmgpdCytjWAfCkBRuiiiznUeVd()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			AkUcpXbtGgaSOLgGtBKaSvRfkwYX(serializedObject);
			return serializedObject;
		}

		internal void hOLSMlXFsuVxuytviQkQgEIwFgJr(ControllerTemplateActionElementMap P_0)
		{
			if (P_0 != null)
			{
				RPhAgZHvBdQlQuBcXGcNGvJisOJeA.Add(P_0);
			}
		}

		internal static ControllerTemplateMap nJlwCBPYshlANXcZfYzzZmEsfjlW(IControllerTemplate P_0, ControllerMap P_1)
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
			controllerTemplateMap.KByWFLCBjjvqwXYVZFDfzPdklyjf = P_1.enabled;
			controllerTemplateMap.IzDmCSEOWOACpGElimeSWXVZPwTT = P_1.categoryId;
			controllerTemplateMap.rrgNxgxpDZgwtGcgleoFKBmKoeKVA = P_1.layoutId;
			controllerTemplateMap.SPmjMmixsypQiGBMMrCeYAuDGnVF = P_1.sourceMapId;
			using (TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>())
			{
				List<ControllerTemplateElementTarget> list = tList.list;
				foreach (ActionElementMap allMap in P_1.AllMaps)
				{
					if (P_0.GetElementTargets(allMap, list) > 0)
					{
						for (int i = 0; i < list.Count; i++)
						{
							controllerTemplateMap.hOLSMlXFsuVxuytviQkQgEIwFgJr(ControllerTemplateActionElementMap.VxSNvmooWfTkIVcICGUZnqoUJPDW(list[i], allMap));
						}
					}
				}
				return controllerTemplateMap;
			}
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			try
			{
				return eWEYPYqEDFDhEpPfZMbqZzztpwLt(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
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
				return eWEYPYqEDFDhEpPfZMbqZzztpwLt(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				return null;
			}
		}

		private static ControllerTemplateMap eWEYPYqEDFDhEpPfZMbqZzztpwLt(SerializedObject P_0)
		{
			if (!P_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.IqWUQdetEUgWKmOIFRihysPfqZgC(P_0);
			return controllerTemplateMap;
		}
	}
}
