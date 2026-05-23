using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int mGgKgCTrOszSIAAovoVMXqcABfuFA;

		private readonly int OjZOSSimwtcymCUZhPUQEiSKssWKB;

		private readonly Guid QjKOvOqbZfsWflSFRSvJcKHAjwd;

		private readonly List<ControllerTemplateActionElementMap> LnmIMNLjmXGmzbDAbfOBHJATFMAdA;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> MFphuSeIGnpqByyivblbgwPEKrfzB;

		private bool ktjsWcJcBgwAdrXjOkhrTIkXBSvH;

		private int gSqZovsGIYKDnSOkcjSqfUPBGRlK;

		private int jludVbFhYpOAPpbnPKeEqQwrOkhTA;

		private int itAopEUTCsNufATATrwloMltqDlN = -1;

		private static int UnHczKvSGGCwzaGjnRWYDxJhvNoN;

		public int id
		{
			get
			{
				if (ReInput._id != mGgKgCTrOszSIAAovoVMXqcABfuFA)
				{
					ReInput.CheckInitialized(mGgKgCTrOszSIAAovoVMXqcABfuFA);
					return -1;
				}
				return OjZOSSimwtcymCUZhPUQEiSKssWKB;
			}
		}

		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != mGgKgCTrOszSIAAovoVMXqcABfuFA)
				{
					ReInput.CheckInitialized(mGgKgCTrOszSIAAovoVMXqcABfuFA);
					return Guid.Empty;
				}
				return QjKOvOqbZfsWflSFRSvJcKHAjwd;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != mGgKgCTrOszSIAAovoVMXqcABfuFA)
				{
					ReInput.CheckInitialized(mGgKgCTrOszSIAAovoVMXqcABfuFA);
					return false;
				}
				return ktjsWcJcBgwAdrXjOkhrTIkXBSvH;
			}
			set
			{
				ktjsWcJcBgwAdrXjOkhrTIkXBSvH = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != mGgKgCTrOszSIAAovoVMXqcABfuFA)
				{
					ReInput.CheckInitialized(mGgKgCTrOszSIAAovoVMXqcABfuFA);
					return -1;
				}
				return gSqZovsGIYKDnSOkcjSqfUPBGRlK;
			}
			internal set
			{
				gSqZovsGIYKDnSOkcjSqfUPBGRlK = num;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != mGgKgCTrOszSIAAovoVMXqcABfuFA)
				{
					ReInput.CheckInitialized(mGgKgCTrOszSIAAovoVMXqcABfuFA);
					return -1;
				}
				return jludVbFhYpOAPpbnPKeEqQwrOkhTA;
			}
			internal set
			{
				jludVbFhYpOAPpbnPKeEqQwrOkhTA = num;
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != mGgKgCTrOszSIAAovoVMXqcABfuFA)
				{
					ReInput.CheckInitialized(mGgKgCTrOszSIAAovoVMXqcABfuFA);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return MFphuSeIGnpqByyivblbgwPEKrfzB;
			}
		}

		internal ControllerTemplateMap(Guid P_0)
		{
			OjZOSSimwtcymCUZhPUQEiSKssWKB = UnHczKvSGGCwzaGjnRWYDxJhvNoN++;
			mGgKgCTrOszSIAAovoVMXqcABfuFA = ReInput._id;
			QjKOvOqbZfsWflSFRSvJcKHAjwd = P_0;
			LnmIMNLjmXGmzbDAbfOBHJATFMAdA = new List<ControllerTemplateActionElementMap>();
			MFphuSeIGnpqByyivblbgwPEKrfzB = new ReadOnlyCollection<ControllerTemplateActionElementMap>(LnmIMNLjmXGmzbDAbfOBHJATFMAdA);
			ktjsWcJcBgwAdrXjOkhrTIkXBSvH = true;
		}

		internal ControllerTemplateMap(Guid P_0, int P_1, int P_2, int P_3)
			: this(P_0)
		{
			gSqZovsGIYKDnSOkcjSqfUPBGRlK = P_1;
			jludVbFhYpOAPpbnPKeEqQwrOkhTA = P_2;
			itAopEUTCsNufATATrwloMltqDlN = P_3;
		}

		public string ToXmlString()
		{
			if (ReInput._id != mGgKgCTrOszSIAAovoVMXqcABfuFA)
			{
				ReInput.CheckInitialized(mGgKgCTrOszSIAAovoVMXqcABfuFA);
				return string.Empty;
			}
			try
			{
				return DZiAfoDJZtGPqVJLEtjUClDmEGdFb().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != mGgKgCTrOszSIAAovoVMXqcABfuFA)
			{
				ReInput.CheckInitialized(mGgKgCTrOszSIAAovoVMXqcABfuFA);
				return string.Empty;
			}
			try
			{
				return DZiAfoDJZtGPqVJLEtjUClDmEGdFb().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != mGgKgCTrOszSIAAovoVMXqcABfuFA)
			{
				ReInput.CheckInitialized(mGgKgCTrOszSIAAovoVMXqcABfuFA);
				return null;
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			IControllerTemplate template = controller.GetTemplate(QjKOvOqbZfsWflSFRSvJcKHAjwd);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			ControllerMap controllerMap = ControllerMap.VCNuXHtewMrFgNwrcjRWWguohOtc(controller.type);
			controllerMap.categoryId = gSqZovsGIYKDnSOkcjSqfUPBGRlK;
			controllerMap.layoutId = jludVbFhYpOAPpbnPKeEqQwrOkhTA;
			if (itAopEUTCsNufATATrwloMltqDlN >= 0)
			{
				controllerMap.sourceMapId = itAopEUTCsNufATATrwloMltqDlN;
			}
			controllerMap.controllerId = controller.id;
			controllerMap.enabled = ktjsWcJcBgwAdrXjOkhrTIkXBSvH;
			controllerMap.hardwareGuid = controller.XoTulHbRfmGIRZBImccjILWCKOlE;
			using TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>();
			List<ActionElementMap> list = tList.list;
			for (int i = 0; i < LnmIMNLjmXGmzbDAbfOBHJATFMAdA.Count; i++)
			{
				LnmIMNLjmXGmzbDAbfOBHJATFMAdA[i].XgPaUfnsXGLGqvXxSObscbJiKDxA(template, list, false);
				for (int j = 0; j < list.Count; j++)
				{
					controllerMap.oFdZMpJjJyspammNnQEQXfobMABp(list[j]);
				}
			}
			return controllerMap;
		}

		internal virtual void hwhxLCfzctMEwoOXZHOXDNLujtBK(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.vaFqdHQxGUQBtSFqxHiqhgbjfOejA
			{
				MqiGgwQfPHmSRCgxvJyAMdrqqrIv = "dataVersion",
				HDNykFqkGTdIdaCMqpOZhaRNJXwGb = 1.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.vaFqdHQxGUQBtSFqxHiqhgbjfOejA
			{
				MqiGgwQfPHmSRCgxvJyAMdrqqrIv = "templateTypeGuid",
				HDNykFqkGTdIdaCMqpOZhaRNJXwGb = QjKOvOqbZfsWflSFRSvJcKHAjwd.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.vaFqdHQxGUQBtSFqxHiqhgbjfOejA
			{
				hwMaMUHTAbktdLOuownSwUDJVxiDA = "xmlns",
				MqiGgwQfPHmSRCgxvJyAMdrqqrIv = "xsi",
				kGESCebYXkaHwqimYjUfiApoHXHAA = null,
				HDNykFqkGTdIdaCMqpOZhaRNJXwGb = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.vaFqdHQxGUQBtSFqxHiqhgbjfOejA
			{
				hwMaMUHTAbktdLOuownSwUDJVxiDA = "xsi",
				MqiGgwQfPHmSRCgxvJyAMdrqqrIv = "schemaLocation",
				kGESCebYXkaHwqimYjUfiApoHXHAA = null,
				HDNykFqkGTdIdaCMqpOZhaRNJXwGb = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
			});
			P_0.Add("templateTypeGuid", QjKOvOqbZfsWflSFRSvJcKHAjwd);
			P_0.Add("enabled", ktjsWcJcBgwAdrXjOkhrTIkXBSvH);
			P_0.Add("categoryId", gSqZovsGIYKDnSOkcjSqfUPBGRlK);
			P_0.Add("layoutId", jludVbFhYpOAPpbnPKeEqQwrOkhTA);
			P_0.Add("sourceMapId", itAopEUTCsNufATATrwloMltqDlN);
			int count = LnmIMNLjmXGmzbDAbfOBHJATFMAdA.Count;
			List<object> list = new List<object>();
			P_0.Add("elementMaps", list);
			for (int i = 0; i < count; i++)
			{
				if (LnmIMNLjmXGmzbDAbfOBHJATFMAdA[i] != null)
				{
					list.Add(LnmIMNLjmXGmzbDAbfOBHJATFMAdA[i].GVfGeiJcrohTAEfQLEFzaAkTcmoYA());
				}
			}
		}

		internal virtual void dVsiIoKJEPiGFwOwMQgaBvdAHsN(SerializedObject P_0)
		{
			HXkZHKjaeuBgEGHKnbJEgoDGGZaw();
			P_0.TryGetDeserializedValueByRef("enabled", ref ktjsWcJcBgwAdrXjOkhrTIkXBSvH);
			P_0.TryGetDeserializedValueByRef("categoryId", ref gSqZovsGIYKDnSOkcjSqfUPBGRlK);
			P_0.TryGetDeserializedValueByRef("layoutId", ref jludVbFhYpOAPpbnPKeEqQwrOkhTA);
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref itAopEUTCsNufATATrwloMltqDlN);
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
			{
				return;
			}
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.bySbytotDdpkbEbKiPwqrtlkywVC(value2);
					if (controllerTemplateActionElementMap != null)
					{
						OHZoxgkDQFIKgoWxFAduVGKBnsSR(controllerTemplateActionElementMap);
					}
				}
			}
		}

		private void HXkZHKjaeuBgEGHKnbJEgoDGGZaw()
		{
			ktjsWcJcBgwAdrXjOkhrTIkXBSvH = true;
			gSqZovsGIYKDnSOkcjSqfUPBGRlK = -1;
			jludVbFhYpOAPpbnPKeEqQwrOkhTA = -1;
			itAopEUTCsNufATATrwloMltqDlN = -1;
			LnmIMNLjmXGmzbDAbfOBHJATFMAdA.Clear();
		}

		private SerializedObject DZiAfoDJZtGPqVJLEtjUClDmEGdFb()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			hwhxLCfzctMEwoOXZHOXDNLujtBK(serializedObject);
			return serializedObject;
		}

		internal void OHZoxgkDQFIKgoWxFAduVGKBnsSR(ControllerTemplateActionElementMap P_0)
		{
			if (P_0 != null)
			{
				LnmIMNLjmXGmzbDAbfOBHJATFMAdA.Add(P_0);
			}
		}

		internal static ControllerTemplateMap OmGBmXDBMsEXItQMdHmegNNakQhzB(IControllerTemplate P_0, ControllerMap P_1)
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
			controllerTemplateMap.ktjsWcJcBgwAdrXjOkhrTIkXBSvH = P_1.enabled;
			controllerTemplateMap.gSqZovsGIYKDnSOkcjSqfUPBGRlK = P_1.categoryId;
			controllerTemplateMap.jludVbFhYpOAPpbnPKeEqQwrOkhTA = P_1.layoutId;
			controllerTemplateMap.itAopEUTCsNufATATrwloMltqDlN = P_1.sourceMapId;
			using TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>();
			List<ControllerTemplateElementTarget> list = tList.list;
			foreach (ActionElementMap allMap in P_1.AllMaps)
			{
				if (P_0.GetElementTargets(allMap, list) > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						controllerTemplateMap.OHZoxgkDQFIKgoWxFAduVGKBnsSR(ControllerTemplateActionElementMap.jjzKnyfcVLTIBXPTOTqopjNLbNFG(list[i], allMap));
					}
				}
			}
			return controllerTemplateMap;
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			try
			{
				return tKmAsMWFsTIkCdNKmVYLisgYvcwq(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
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
				return tKmAsMWFsTIkCdNKmVYLisgYvcwq(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				return null;
			}
		}

		private static ControllerTemplateMap tKmAsMWFsTIkCdNKmVYLisgYvcwq(SerializedObject P_0)
		{
			if (!P_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.dVsiIoKJEPiGFwOwMQgaBvdAHsN(P_0);
			return controllerTemplateMap;
		}
	}
}
