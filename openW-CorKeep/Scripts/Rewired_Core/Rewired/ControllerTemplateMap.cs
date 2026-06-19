using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int JMKfHxCxjycBhFSZiUuIoKBEJgAnD;

		private readonly int pkztnfYcDlOzLOpcWsrIjdbladNjA;

		private readonly Guid plZtVKyZDLahbvGGywQlMHZGGTxr;

		private readonly List<ControllerTemplateActionElementMap> saAheofGDZNSSfDtMrSFSCfYDtHL;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> rTXHXtyMtvArisYPYSAtljwVxecX;

		private bool PvHcJrxvNwdVGbigfcLhMkBWaYuR;

		private int FwSoJMSWfSPYWGOFHAkaeYkCJaoH;

		private int WIWewIPVnbBJaxfSaYZGBFBeljkO;

		private int FbkbMfAgtwctMpMhmiNjRlMcJWasA = -1;

		private static int bfhAHvVviWnyUcEoKjdSQeziOflE;

		public int id
		{
			get
			{
				if (ReInput._id != JMKfHxCxjycBhFSZiUuIoKBEJgAnD)
				{
					ReInput.CheckInitialized(JMKfHxCxjycBhFSZiUuIoKBEJgAnD);
					return -1;
				}
				return pkztnfYcDlOzLOpcWsrIjdbladNjA;
			}
		}

		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != JMKfHxCxjycBhFSZiUuIoKBEJgAnD)
				{
					ReInput.CheckInitialized(JMKfHxCxjycBhFSZiUuIoKBEJgAnD);
					return Guid.Empty;
				}
				return plZtVKyZDLahbvGGywQlMHZGGTxr;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != JMKfHxCxjycBhFSZiUuIoKBEJgAnD)
				{
					ReInput.CheckInitialized(JMKfHxCxjycBhFSZiUuIoKBEJgAnD);
					return false;
				}
				return PvHcJrxvNwdVGbigfcLhMkBWaYuR;
			}
			set
			{
				PvHcJrxvNwdVGbigfcLhMkBWaYuR = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != JMKfHxCxjycBhFSZiUuIoKBEJgAnD)
				{
					ReInput.CheckInitialized(JMKfHxCxjycBhFSZiUuIoKBEJgAnD);
					return -1;
				}
				return FwSoJMSWfSPYWGOFHAkaeYkCJaoH;
			}
			internal set
			{
				FwSoJMSWfSPYWGOFHAkaeYkCJaoH = fwSoJMSWfSPYWGOFHAkaeYkCJaoH;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != JMKfHxCxjycBhFSZiUuIoKBEJgAnD)
				{
					ReInput.CheckInitialized(JMKfHxCxjycBhFSZiUuIoKBEJgAnD);
					return -1;
				}
				return WIWewIPVnbBJaxfSaYZGBFBeljkO;
			}
			internal set
			{
				WIWewIPVnbBJaxfSaYZGBFBeljkO = wIWewIPVnbBJaxfSaYZGBFBeljkO;
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != JMKfHxCxjycBhFSZiUuIoKBEJgAnD)
				{
					ReInput.CheckInitialized(JMKfHxCxjycBhFSZiUuIoKBEJgAnD);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return rTXHXtyMtvArisYPYSAtljwVxecX;
			}
		}

		internal ControllerTemplateMap(Guid P_0)
		{
			pkztnfYcDlOzLOpcWsrIjdbladNjA = bfhAHvVviWnyUcEoKjdSQeziOflE++;
			JMKfHxCxjycBhFSZiUuIoKBEJgAnD = ReInput._id;
			plZtVKyZDLahbvGGywQlMHZGGTxr = P_0;
			saAheofGDZNSSfDtMrSFSCfYDtHL = new List<ControllerTemplateActionElementMap>();
			rTXHXtyMtvArisYPYSAtljwVxecX = new ReadOnlyCollection<ControllerTemplateActionElementMap>(saAheofGDZNSSfDtMrSFSCfYDtHL);
			PvHcJrxvNwdVGbigfcLhMkBWaYuR = true;
		}

		internal ControllerTemplateMap(Guid P_0, int P_1, int P_2, int P_3)
			: this(P_0)
		{
			FwSoJMSWfSPYWGOFHAkaeYkCJaoH = P_1;
			WIWewIPVnbBJaxfSaYZGBFBeljkO = P_2;
			FbkbMfAgtwctMpMhmiNjRlMcJWasA = P_3;
		}

		public string ToXmlString()
		{
			if (ReInput._id != JMKfHxCxjycBhFSZiUuIoKBEJgAnD)
			{
				ReInput.CheckInitialized(JMKfHxCxjycBhFSZiUuIoKBEJgAnD);
				return string.Empty;
			}
			try
			{
				return gTQfYBvWozWCJHmujEQMsaelOHym().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != JMKfHxCxjycBhFSZiUuIoKBEJgAnD)
			{
				ReInput.CheckInitialized(JMKfHxCxjycBhFSZiUuIoKBEJgAnD);
				return string.Empty;
			}
			try
			{
				return gTQfYBvWozWCJHmujEQMsaelOHym().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != JMKfHxCxjycBhFSZiUuIoKBEJgAnD)
			{
				ReInput.CheckInitialized(JMKfHxCxjycBhFSZiUuIoKBEJgAnD);
				return null;
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			IControllerTemplate template = controller.GetTemplate(plZtVKyZDLahbvGGywQlMHZGGTxr);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			ControllerMap controllerMap = ControllerMap.cqhZHeJRTSeEFHBVRFEAXCJriwBEA(controller.type);
			controllerMap.categoryId = FwSoJMSWfSPYWGOFHAkaeYkCJaoH;
			controllerMap.layoutId = WIWewIPVnbBJaxfSaYZGBFBeljkO;
			if (FbkbMfAgtwctMpMhmiNjRlMcJWasA >= 0)
			{
				controllerMap.sourceMapId = FbkbMfAgtwctMpMhmiNjRlMcJWasA;
			}
			controllerMap.controllerId = controller.id;
			controllerMap.enabled = PvHcJrxvNwdVGbigfcLhMkBWaYuR;
			controllerMap.hardwareGuid = controller.savDJAJJykdFgIDmPSBdENeZaLumA;
			using TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>();
			List<ActionElementMap> list = tList.list;
			for (int i = 0; i < saAheofGDZNSSfDtMrSFSCfYDtHL.Count; i++)
			{
				saAheofGDZNSSfDtMrSFSCfYDtHL[i].kDKaDdJQHThExDzsQWjvqhSCqPECA(template, list, false);
				for (int j = 0; j < list.Count; j++)
				{
					controllerMap.ZsPqvQrjowcgLqmuMupUIUTcDTMs(list[j]);
				}
			}
			return controllerMap;
		}

		internal virtual void ACLSmnXMNpjVJmmkadxPaQmnBuICb(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EndBkowpwOTxIGJnMBcsgiGqTpvf
			{
				pIIbLDKqkVfRyNCGQyHEEVIpxwRdA = "dataVersion",
				qqfRFgGAtDPLKSLpFGzHGleMdWxAb = 1.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EndBkowpwOTxIGJnMBcsgiGqTpvf
			{
				pIIbLDKqkVfRyNCGQyHEEVIpxwRdA = "templateTypeGuid",
				qqfRFgGAtDPLKSLpFGzHGleMdWxAb = plZtVKyZDLahbvGGywQlMHZGGTxr.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EndBkowpwOTxIGJnMBcsgiGqTpvf
			{
				WxmFjndTttjqQAYFRlGSZJiUawrZ = "xmlns",
				pIIbLDKqkVfRyNCGQyHEEVIpxwRdA = "xsi",
				FnmpvPDmwsSGLmiBdhdjjjOdjSKDb = null,
				qqfRFgGAtDPLKSLpFGzHGleMdWxAb = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EndBkowpwOTxIGJnMBcsgiGqTpvf
			{
				WxmFjndTttjqQAYFRlGSZJiUawrZ = "xsi",
				pIIbLDKqkVfRyNCGQyHEEVIpxwRdA = "schemaLocation",
				FnmpvPDmwsSGLmiBdhdjjjOdjSKDb = null,
				qqfRFgGAtDPLKSLpFGzHGleMdWxAb = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
			});
			P_0.Add("templateTypeGuid", plZtVKyZDLahbvGGywQlMHZGGTxr);
			P_0.Add("enabled", PvHcJrxvNwdVGbigfcLhMkBWaYuR);
			P_0.Add("categoryId", FwSoJMSWfSPYWGOFHAkaeYkCJaoH);
			P_0.Add("layoutId", WIWewIPVnbBJaxfSaYZGBFBeljkO);
			P_0.Add("sourceMapId", FbkbMfAgtwctMpMhmiNjRlMcJWasA);
			int count = saAheofGDZNSSfDtMrSFSCfYDtHL.Count;
			List<object> list = new List<object>();
			P_0.Add("elementMaps", list);
			for (int i = 0; i < count; i++)
			{
				if (saAheofGDZNSSfDtMrSFSCfYDtHL[i] != null)
				{
					list.Add(saAheofGDZNSSfDtMrSFSCfYDtHL[i].vxFvXJxOxgWltUtVuuPlJZRQpEze());
				}
			}
		}

		internal virtual void IIjABbGKcOFljgZbVDjwjXKkdKbiA(SerializedObject P_0)
		{
			kVEqWnNlDcUbbEvfEyoMtfiBCUjg();
			P_0.TryGetDeserializedValueByRef("enabled", ref PvHcJrxvNwdVGbigfcLhMkBWaYuR);
			P_0.TryGetDeserializedValueByRef("categoryId", ref FwSoJMSWfSPYWGOFHAkaeYkCJaoH);
			P_0.TryGetDeserializedValueByRef("layoutId", ref WIWewIPVnbBJaxfSaYZGBFBeljkO);
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref FbkbMfAgtwctMpMhmiNjRlMcJWasA);
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
			{
				return;
			}
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.KQwAKVUFIbokGUYCJhocoKKfVlKn(value2);
					if (controllerTemplateActionElementMap != null)
					{
						dtBNHMrjBaPTitUmoWkADvCrbNp(controllerTemplateActionElementMap);
					}
				}
			}
		}

		private void kVEqWnNlDcUbbEvfEyoMtfiBCUjg()
		{
			PvHcJrxvNwdVGbigfcLhMkBWaYuR = true;
			FwSoJMSWfSPYWGOFHAkaeYkCJaoH = -1;
			WIWewIPVnbBJaxfSaYZGBFBeljkO = -1;
			FbkbMfAgtwctMpMhmiNjRlMcJWasA = -1;
			saAheofGDZNSSfDtMrSFSCfYDtHL.Clear();
		}

		private SerializedObject gTQfYBvWozWCJHmujEQMsaelOHym()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			ACLSmnXMNpjVJmmkadxPaQmnBuICb(serializedObject);
			return serializedObject;
		}

		internal void dtBNHMrjBaPTitUmoWkADvCrbNp(ControllerTemplateActionElementMap P_0)
		{
			if (P_0 != null)
			{
				saAheofGDZNSSfDtMrSFSCfYDtHL.Add(P_0);
			}
		}

		internal static ControllerTemplateMap phkgPytItgWtvYBtYCZqEveflFeX(IControllerTemplate P_0, ControllerMap P_1)
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
			controllerTemplateMap.PvHcJrxvNwdVGbigfcLhMkBWaYuR = P_1.enabled;
			controllerTemplateMap.FwSoJMSWfSPYWGOFHAkaeYkCJaoH = P_1.categoryId;
			controllerTemplateMap.WIWewIPVnbBJaxfSaYZGBFBeljkO = P_1.layoutId;
			controllerTemplateMap.FbkbMfAgtwctMpMhmiNjRlMcJWasA = P_1.sourceMapId;
			using TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>();
			List<ControllerTemplateElementTarget> list = tList.list;
			foreach (ActionElementMap allMap in P_1.AllMaps)
			{
				if (P_0.GetElementTargets(allMap, list) > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						controllerTemplateMap.dtBNHMrjBaPTitUmoWkADvCrbNp(ControllerTemplateActionElementMap.KDPxbJXBcLfMqHUazPygyUwMsyWo(list[i], allMap));
					}
				}
			}
			return controllerTemplateMap;
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			try
			{
				return MWdGvmFEFlFnvghBlgXlFNTdvtt(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
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
				return MWdGvmFEFlFnvghBlgXlFNTdvtt(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				return null;
			}
		}

		private static ControllerTemplateMap MWdGvmFEFlFnvghBlgXlFNTdvtt(SerializedObject P_0)
		{
			if (!P_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.IIjABbGKcOFljgZbVDjwjXKkdKbiA(P_0);
			return controllerTemplateMap;
		}
	}
}
