using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

		private readonly int fOjavGziuUSawAgvwyVARpyRBVx;

		private readonly Guid BwrwdTLnNEjceUAmmkQdlNAkIWiB;

		private readonly List<ControllerTemplateActionElementMap> OpxqHAVZjCqoJvcUCBHsYeHPUol;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> hOFvzzWHvaBBfDRXFxAGsrNiDbX;

		private bool TAiAzEAcNOkrpYWJEmhYYqnFvpF;

		private int VzLsUXOaivBFmDTpxtRzmrDmokrH;

		private int oQumpjlmpgfnuDJwgCZwnocvnqaF;

		private int DWwpdrkfLRgblVMJBWORfuuoKLp = -1;

		private static int KoEecjMjeddotFrYhEXbrGTpJiDT;

		public int id
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1;
				}
				return fOjavGziuUSawAgvwyVARpyRBVx;
			}
		}

		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Guid.Empty;
				}
				return BwrwdTLnNEjceUAmmkQdlNAkIWiB;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				return TAiAzEAcNOkrpYWJEmhYYqnFvpF;
			}
			set
			{
				TAiAzEAcNOkrpYWJEmhYYqnFvpF = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1;
				}
				return VzLsUXOaivBFmDTpxtRzmrDmokrH;
			}
			internal set
			{
				VzLsUXOaivBFmDTpxtRzmrDmokrH = value;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1;
				}
				return oQumpjlmpgfnuDJwgCZwnocvnqaF;
			}
			internal set
			{
				oQumpjlmpgfnuDJwgCZwnocvnqaF = value;
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return hOFvzzWHvaBBfDRXFxAGsrNiDbX;
			}
		}

		internal ControllerTemplateMap(Guid templateTypeGuid)
		{
			fOjavGziuUSawAgvwyVARpyRBVx = KoEecjMjeddotFrYhEXbrGTpJiDT++;
			fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput._id;
			BwrwdTLnNEjceUAmmkQdlNAkIWiB = templateTypeGuid;
			OpxqHAVZjCqoJvcUCBHsYeHPUol = new List<ControllerTemplateActionElementMap>();
			hOFvzzWHvaBBfDRXFxAGsrNiDbX = new ReadOnlyCollection<ControllerTemplateActionElementMap>(OpxqHAVZjCqoJvcUCBHsYeHPUol);
			TAiAzEAcNOkrpYWJEmhYYqnFvpF = true;
		}

		internal ControllerTemplateMap(Guid templateTypeGuid, int categoryId, int layoutId, int sourceMapId)
			: this(templateTypeGuid)
		{
			VzLsUXOaivBFmDTpxtRzmrDmokrH = categoryId;
			oQumpjlmpgfnuDJwgCZwnocvnqaF = layoutId;
			DWwpdrkfLRgblVMJBWORfuuoKLp = sourceMapId;
		}

		public string ToXmlString()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return string.Empty;
			}
			try
			{
				return qnRcKibdUQgUDehMYaMNRcmEEUp().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return string.Empty;
			}
			try
			{
				return qnRcKibdUQgUDehMYaMNRcmEEUp().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			IControllerTemplate template = controller.GetTemplate(BwrwdTLnNEjceUAmmkQdlNAkIWiB);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			ControllerMap controllerMap = ControllerMap.AxGMnpcloIAUTQTSFCdghQatHHxd(controller.type);
			controllerMap.categoryId = VzLsUXOaivBFmDTpxtRzmrDmokrH;
			controllerMap.layoutId = oQumpjlmpgfnuDJwgCZwnocvnqaF;
			if (DWwpdrkfLRgblVMJBWORfuuoKLp >= 0)
			{
				controllerMap.sourceMapId = DWwpdrkfLRgblVMJBWORfuuoKLp;
			}
			controllerMap.controllerId = controller.id;
			controllerMap.controllerType = controller.type;
			controllerMap.enabled = TAiAzEAcNOkrpYWJEmhYYqnFvpF;
			controllerMap.hardwareGuid = controller.EAIQLWgbsQDNGcJuOWaoPBaXKTl;
			using TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>();
			List<ActionElementMap> list = tList.list;
			for (int i = 0; i < OpxqHAVZjCqoJvcUCBHsYeHPUol.Count; i++)
			{
				OpxqHAVZjCqoJvcUCBHsYeHPUol[i].ovsfoAcKwDqKLgEubpwjaEQILIB(template, list, false);
				for (int j = 0; j < list.Count; j++)
				{
					controllerMap.CopwiDtmNQYJDxydZiwAXLfuDcb(list[j]);
				}
			}
			return controllerMap;
		}

		internal virtual void ZpEgvAefsRlDDfhUwpzFAUZSfaaq(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW
			{
				zYwYmGHTCLOJxCByvWzioBevSzj = "dataVersion",
				HpxePuhaScltgSCBmgsrsCpjliL = 1.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW
			{
				zYwYmGHTCLOJxCByvWzioBevSzj = "templateTypeGuid",
				HpxePuhaScltgSCBmgsrsCpjliL = BwrwdTLnNEjceUAmmkQdlNAkIWiB.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW
			{
				LwDBNnNFqBxCeHOdFxAkCpxXHQR = "xmlns",
				zYwYmGHTCLOJxCByvWzioBevSzj = "xsi",
				oseqaDGmYbdubOOmISVVBGRFzNc = null,
				HpxePuhaScltgSCBmgsrsCpjliL = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW
			{
				LwDBNnNFqBxCeHOdFxAkCpxXHQR = "xsi",
				zYwYmGHTCLOJxCByvWzioBevSzj = "schemaLocation",
				oseqaDGmYbdubOOmISVVBGRFzNc = null,
				HpxePuhaScltgSCBmgsrsCpjliL = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
			});
			P_0.Add("templateTypeGuid", BwrwdTLnNEjceUAmmkQdlNAkIWiB);
			P_0.Add("enabled", TAiAzEAcNOkrpYWJEmhYYqnFvpF);
			P_0.Add("categoryId", VzLsUXOaivBFmDTpxtRzmrDmokrH);
			P_0.Add("layoutId", oQumpjlmpgfnuDJwgCZwnocvnqaF);
			P_0.Add("sourceMapId", DWwpdrkfLRgblVMJBWORfuuoKLp);
			int count = OpxqHAVZjCqoJvcUCBHsYeHPUol.Count;
			List<object> list = new List<object>();
			P_0.Add("elementMaps", list);
			for (int i = 0; i < count; i++)
			{
				if (OpxqHAVZjCqoJvcUCBHsYeHPUol[i] != null)
				{
					list.Add(OpxqHAVZjCqoJvcUCBHsYeHPUol[i].qnRcKibdUQgUDehMYaMNRcmEEUp());
				}
			}
		}

		internal virtual void JYyEPkmZztzXfbEgKghAFieAytO(SerializedObject P_0)
		{
			dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			P_0.TryGetDeserializedValueByRef("enabled", ref TAiAzEAcNOkrpYWJEmhYYqnFvpF);
			P_0.TryGetDeserializedValueByRef("categoryId", ref VzLsUXOaivBFmDTpxtRzmrDmokrH);
			P_0.TryGetDeserializedValueByRef("layoutId", ref oQumpjlmpgfnuDJwgCZwnocvnqaF);
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref DWwpdrkfLRgblVMJBWORfuuoKLp);
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
			{
				return;
			}
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.AxGMnpcloIAUTQTSFCdghQatHHxd(value2);
					if (controllerTemplateActionElementMap != null)
					{
						anZEgqJfCTCyftlbtfLdZXMDqwn(controllerTemplateActionElementMap);
					}
				}
			}
		}

		private void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
		{
			TAiAzEAcNOkrpYWJEmhYYqnFvpF = true;
			VzLsUXOaivBFmDTpxtRzmrDmokrH = -1;
			oQumpjlmpgfnuDJwgCZwnocvnqaF = -1;
			DWwpdrkfLRgblVMJBWORfuuoKLp = -1;
			OpxqHAVZjCqoJvcUCBHsYeHPUol.Clear();
		}

		private SerializedObject qnRcKibdUQgUDehMYaMNRcmEEUp()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			ZpEgvAefsRlDDfhUwpzFAUZSfaaq(serializedObject);
			return serializedObject;
		}

		internal void anZEgqJfCTCyftlbtfLdZXMDqwn(ControllerTemplateActionElementMap P_0)
		{
			if (P_0 != null)
			{
				OpxqHAVZjCqoJvcUCBHsYeHPUol.Add(P_0);
			}
		}

		internal static ControllerTemplateMap wqxxWUNxKMbJQQfTibGCHiSXNpPr(IControllerTemplate P_0, ControllerMap P_1)
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
			controllerTemplateMap.TAiAzEAcNOkrpYWJEmhYYqnFvpF = P_1.enabled;
			controllerTemplateMap.VzLsUXOaivBFmDTpxtRzmrDmokrH = P_1.categoryId;
			controllerTemplateMap.oQumpjlmpgfnuDJwgCZwnocvnqaF = P_1.layoutId;
			controllerTemplateMap.DWwpdrkfLRgblVMJBWORfuuoKLp = P_1.sourceMapId;
			using TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>();
			List<ControllerTemplateElementTarget> list = tList.list;
			foreach (ActionElementMap allMap in P_1.AllMaps)
			{
				if (P_0.GetElementTargets(allMap, list) > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						controllerTemplateMap.anZEgqJfCTCyftlbtfLdZXMDqwn(ControllerTemplateActionElementMap.AxGMnpcloIAUTQTSFCdghQatHHxd(list[i], allMap));
					}
				}
			}
			return controllerTemplateMap;
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			try
			{
				return rWOBIJkqfwKcRgubWCQViMzWDmf(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
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
				return rWOBIJkqfwKcRgubWCQViMzWDmf(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				return null;
			}
		}

		private static ControllerTemplateMap rWOBIJkqfwKcRgubWCQViMzWDmf(SerializedObject P_0)
		{
			if (!P_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.JYyEPkmZztzXfbEgKghAFieAytO(P_0);
			return controllerTemplateMap;
		}
	}
}
