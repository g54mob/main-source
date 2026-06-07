using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int NhEHXmXSTaJZZdyxLJllVDLifzrgA;

		private readonly int ngbstcgqdhfhppkYNdwrDypGxyJUA;

		private readonly Guid xMHzTTSbxJoHMUmbrzIYLPAvKzcB;

		private readonly List<ControllerTemplateActionElementMap> edMtmrLxcXRwcADIZipmXnTzCVQc;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> pRZaHccGBbklGTFhPDLQrcoyszqSA;

		private bool XPzTclVteTfsPKUyGAAcFLfURqeb;

		private int TrYquVcHPIBBihDdUXeLjGehEScv;

		private int CiAGgBDjHnjRUESwItIxGEJfVoaRc;

		private int JCwnQiEeRerlmjJTnCXUoBWTPnaK = -1;

		private static int vKdYIktHVKDjiRScVImfFNsXOJxu;

		public int id
		{
			get
			{
				if (ReInput._id != NhEHXmXSTaJZZdyxLJllVDLifzrgA)
				{
					ReInput.CheckInitialized(NhEHXmXSTaJZZdyxLJllVDLifzrgA);
					return -1;
				}
				return ngbstcgqdhfhppkYNdwrDypGxyJUA;
			}
		}

		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != NhEHXmXSTaJZZdyxLJllVDLifzrgA)
				{
					ReInput.CheckInitialized(NhEHXmXSTaJZZdyxLJllVDLifzrgA);
					return Guid.Empty;
				}
				return xMHzTTSbxJoHMUmbrzIYLPAvKzcB;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != NhEHXmXSTaJZZdyxLJllVDLifzrgA)
				{
					ReInput.CheckInitialized(NhEHXmXSTaJZZdyxLJllVDLifzrgA);
					return false;
				}
				return XPzTclVteTfsPKUyGAAcFLfURqeb;
			}
			set
			{
				XPzTclVteTfsPKUyGAAcFLfURqeb = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != NhEHXmXSTaJZZdyxLJllVDLifzrgA)
				{
					ReInput.CheckInitialized(NhEHXmXSTaJZZdyxLJllVDLifzrgA);
					return -1;
				}
				return TrYquVcHPIBBihDdUXeLjGehEScv;
			}
			internal set
			{
				TrYquVcHPIBBihDdUXeLjGehEScv = trYquVcHPIBBihDdUXeLjGehEScv;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != NhEHXmXSTaJZZdyxLJllVDLifzrgA)
				{
					ReInput.CheckInitialized(NhEHXmXSTaJZZdyxLJllVDLifzrgA);
					return -1;
				}
				return CiAGgBDjHnjRUESwItIxGEJfVoaRc;
			}
			internal set
			{
				CiAGgBDjHnjRUESwItIxGEJfVoaRc = ciAGgBDjHnjRUESwItIxGEJfVoaRc;
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != NhEHXmXSTaJZZdyxLJllVDLifzrgA)
				{
					ReInput.CheckInitialized(NhEHXmXSTaJZZdyxLJllVDLifzrgA);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return pRZaHccGBbklGTFhPDLQrcoyszqSA;
			}
		}

		internal ControllerTemplateMap(Guid P_0)
		{
			ngbstcgqdhfhppkYNdwrDypGxyJUA = vKdYIktHVKDjiRScVImfFNsXOJxu++;
			NhEHXmXSTaJZZdyxLJllVDLifzrgA = ReInput._id;
			xMHzTTSbxJoHMUmbrzIYLPAvKzcB = P_0;
			edMtmrLxcXRwcADIZipmXnTzCVQc = new List<ControllerTemplateActionElementMap>();
			pRZaHccGBbklGTFhPDLQrcoyszqSA = new ReadOnlyCollection<ControllerTemplateActionElementMap>(edMtmrLxcXRwcADIZipmXnTzCVQc);
			XPzTclVteTfsPKUyGAAcFLfURqeb = true;
		}

		internal ControllerTemplateMap(Guid P_0, int P_1, int P_2, int P_3)
			: this(P_0)
		{
			TrYquVcHPIBBihDdUXeLjGehEScv = P_1;
			CiAGgBDjHnjRUESwItIxGEJfVoaRc = P_2;
			JCwnQiEeRerlmjJTnCXUoBWTPnaK = P_3;
		}

		public string ToXmlString()
		{
			if (ReInput._id != NhEHXmXSTaJZZdyxLJllVDLifzrgA)
			{
				ReInput.CheckInitialized(NhEHXmXSTaJZZdyxLJllVDLifzrgA);
				return string.Empty;
			}
			try
			{
				return yZYcCUgHEfqYxbkCfcTrIpmEEUmTB().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != NhEHXmXSTaJZZdyxLJllVDLifzrgA)
			{
				ReInput.CheckInitialized(NhEHXmXSTaJZZdyxLJllVDLifzrgA);
				return string.Empty;
			}
			try
			{
				return yZYcCUgHEfqYxbkCfcTrIpmEEUmTB().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != NhEHXmXSTaJZZdyxLJllVDLifzrgA)
			{
				ReInput.CheckInitialized(NhEHXmXSTaJZZdyxLJllVDLifzrgA);
				return null;
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			IControllerTemplate template = controller.GetTemplate(xMHzTTSbxJoHMUmbrzIYLPAvKzcB);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			ControllerMap controllerMap = ControllerMap.qsvHbdffvMuvxyqzGXpxONTMtALL(controller.type);
			controllerMap.categoryId = TrYquVcHPIBBihDdUXeLjGehEScv;
			controllerMap.layoutId = CiAGgBDjHnjRUESwItIxGEJfVoaRc;
			if (JCwnQiEeRerlmjJTnCXUoBWTPnaK >= 0)
			{
				controllerMap.sourceMapId = JCwnQiEeRerlmjJTnCXUoBWTPnaK;
			}
			controllerMap.controllerId = controller.id;
			controllerMap.enabled = XPzTclVteTfsPKUyGAAcFLfURqeb;
			controllerMap.hardwareGuid = controller.qapLJarKYePKdgQROGMwYujqCcvB;
			using TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>();
			List<ActionElementMap> list = tList.list;
			for (int i = 0; i < edMtmrLxcXRwcADIZipmXnTzCVQc.Count; i++)
			{
				edMtmrLxcXRwcADIZipmXnTzCVQc[i].wzAHCovxgROxTCCXLwRKsKihCdYf(template, list, false);
				for (int j = 0; j < list.Count; j++)
				{
					controllerMap.LqBWpTNVWgCahBpYNHcxDtZTDUKt(list[j]);
				}
			}
			return controllerMap;
		}

		internal virtual void OGZwwobZpjhLrRmKlqyyPZsEFdEv(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.GlzRlrSmJMPGyhIzDQJHlmQHORtg
			{
				pdYiVMKqONWNQjSqPcOhYrKSabZR = "dataVersion",
				colvBdeALTpVyhJTAuogspkzwFfR = 1.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.GlzRlrSmJMPGyhIzDQJHlmQHORtg
			{
				pdYiVMKqONWNQjSqPcOhYrKSabZR = "templateTypeGuid",
				colvBdeALTpVyhJTAuogspkzwFfR = xMHzTTSbxJoHMUmbrzIYLPAvKzcB.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.GlzRlrSmJMPGyhIzDQJHlmQHORtg
			{
				YwqFzwdFPbsmyhvzUHNjHImbnvlAA = "xmlns",
				pdYiVMKqONWNQjSqPcOhYrKSabZR = "xsi",
				JQeynGdKCohWfFHxkPiAfoQUYTUPA = null,
				colvBdeALTpVyhJTAuogspkzwFfR = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.GlzRlrSmJMPGyhIzDQJHlmQHORtg
			{
				YwqFzwdFPbsmyhvzUHNjHImbnvlAA = "xsi",
				pdYiVMKqONWNQjSqPcOhYrKSabZR = "schemaLocation",
				JQeynGdKCohWfFHxkPiAfoQUYTUPA = null,
				colvBdeALTpVyhJTAuogspkzwFfR = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
			});
			P_0.Add("templateTypeGuid", xMHzTTSbxJoHMUmbrzIYLPAvKzcB);
			P_0.Add("enabled", XPzTclVteTfsPKUyGAAcFLfURqeb);
			P_0.Add("categoryId", TrYquVcHPIBBihDdUXeLjGehEScv);
			P_0.Add("layoutId", CiAGgBDjHnjRUESwItIxGEJfVoaRc);
			P_0.Add("sourceMapId", JCwnQiEeRerlmjJTnCXUoBWTPnaK);
			int count = edMtmrLxcXRwcADIZipmXnTzCVQc.Count;
			List<object> list = new List<object>();
			P_0.Add("elementMaps", list);
			for (int i = 0; i < count; i++)
			{
				if (edMtmrLxcXRwcADIZipmXnTzCVQc[i] != null)
				{
					list.Add(edMtmrLxcXRwcADIZipmXnTzCVQc[i].luBtbIRTiqMkRzaVvvqQOTRzccbI());
				}
			}
		}

		internal virtual void GKjNCmgAcKppVyXkOofPscMXPwbI(SerializedObject P_0)
		{
			yWEiTuvjJcEGXxDORtjrycDoBTrC();
			P_0.TryGetDeserializedValueByRef("enabled", ref XPzTclVteTfsPKUyGAAcFLfURqeb);
			P_0.TryGetDeserializedValueByRef("categoryId", ref TrYquVcHPIBBihDdUXeLjGehEScv);
			P_0.TryGetDeserializedValueByRef("layoutId", ref CiAGgBDjHnjRUESwItIxGEJfVoaRc);
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref JCwnQiEeRerlmjJTnCXUoBWTPnaK);
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
			{
				return;
			}
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.WmySUueonAusalsWzxFTjISeiQnA(value2);
					if (controllerTemplateActionElementMap != null)
					{
						jEbdXAqDPNMRhHGudaZTPrzddaBCA(controllerTemplateActionElementMap);
					}
				}
			}
		}

		private void yWEiTuvjJcEGXxDORtjrycDoBTrC()
		{
			XPzTclVteTfsPKUyGAAcFLfURqeb = true;
			TrYquVcHPIBBihDdUXeLjGehEScv = -1;
			CiAGgBDjHnjRUESwItIxGEJfVoaRc = -1;
			JCwnQiEeRerlmjJTnCXUoBWTPnaK = -1;
			edMtmrLxcXRwcADIZipmXnTzCVQc.Clear();
		}

		private SerializedObject yZYcCUgHEfqYxbkCfcTrIpmEEUmTB()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			OGZwwobZpjhLrRmKlqyyPZsEFdEv(serializedObject);
			return serializedObject;
		}

		internal void jEbdXAqDPNMRhHGudaZTPrzddaBCA(ControllerTemplateActionElementMap P_0)
		{
			if (P_0 != null)
			{
				edMtmrLxcXRwcADIZipmXnTzCVQc.Add(P_0);
			}
		}

		internal static ControllerTemplateMap hMyFPrbDZmsMHOxNFaMNrLgAkAwIA(IControllerTemplate P_0, ControllerMap P_1)
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
			controllerTemplateMap.XPzTclVteTfsPKUyGAAcFLfURqeb = P_1.enabled;
			controllerTemplateMap.TrYquVcHPIBBihDdUXeLjGehEScv = P_1.categoryId;
			controllerTemplateMap.CiAGgBDjHnjRUESwItIxGEJfVoaRc = P_1.layoutId;
			controllerTemplateMap.JCwnQiEeRerlmjJTnCXUoBWTPnaK = P_1.sourceMapId;
			using TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>();
			List<ControllerTemplateElementTarget> list = tList.list;
			foreach (ActionElementMap allMap in P_1.AllMaps)
			{
				if (P_0.GetElementTargets(allMap, list) > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						controllerTemplateMap.jEbdXAqDPNMRhHGudaZTPrzddaBCA(ControllerTemplateActionElementMap.AGZfMShSgHMRGiYawdbTbJurbqCI(list[i], allMap));
					}
				}
			}
			return controllerTemplateMap;
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			try
			{
				return EBOBfgUFrVmfFCNDShwqegRspsvs(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
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
				return EBOBfgUFrVmfFCNDShwqegRspsvs(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				return null;
			}
		}

		private static ControllerTemplateMap EBOBfgUFrVmfFCNDShwqegRspsvs(SerializedObject P_0)
		{
			if (!P_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.GKjNCmgAcKppVyXkOofPscMXPwbI(P_0);
			return controllerTemplateMap;
		}
	}
}
