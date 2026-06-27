using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int UVnNLjWoSqdiaVsnyQoruSXTVVIC;

		private readonly int sxErHfvxkjRSONbIaZbdRicbBGet;

		private readonly Guid qQuunMNSkHEEqcYaIaAUyDUItyEN;

		private readonly List<ControllerTemplateActionElementMap> lcrjxsGAaJLjNQuNixTekeyYToybA;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> mQqFOtTkCrDOzxqdagqODczLPRTJ;

		private bool YGoXFjKoekRRLoxMTdzWuvEUbpZG;

		private int SMrEsAEhEYstBRFflReXNMxSIsJpA;

		private int BwzeIWgUyvrdxcsOWnzldIhaQaZd;

		private int OABdMlLoQiKDPZuXYzWOZdVwfVXK = -1;

		private static int yzCsAnkzMUVXFjvqciRruXlsOhYn;

		public int id
		{
			get
			{
				if (ReInput._id != UVnNLjWoSqdiaVsnyQoruSXTVVIC)
				{
					ReInput.CheckInitialized(UVnNLjWoSqdiaVsnyQoruSXTVVIC);
					return -1;
				}
				return sxErHfvxkjRSONbIaZbdRicbBGet;
			}
		}

		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != UVnNLjWoSqdiaVsnyQoruSXTVVIC)
				{
					ReInput.CheckInitialized(UVnNLjWoSqdiaVsnyQoruSXTVVIC);
					return Guid.Empty;
				}
				return qQuunMNSkHEEqcYaIaAUyDUItyEN;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != UVnNLjWoSqdiaVsnyQoruSXTVVIC)
				{
					ReInput.CheckInitialized(UVnNLjWoSqdiaVsnyQoruSXTVVIC);
					return false;
				}
				return YGoXFjKoekRRLoxMTdzWuvEUbpZG;
			}
			set
			{
				YGoXFjKoekRRLoxMTdzWuvEUbpZG = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != UVnNLjWoSqdiaVsnyQoruSXTVVIC)
				{
					ReInput.CheckInitialized(UVnNLjWoSqdiaVsnyQoruSXTVVIC);
					return -1;
				}
				return SMrEsAEhEYstBRFflReXNMxSIsJpA;
			}
			internal set
			{
				SMrEsAEhEYstBRFflReXNMxSIsJpA = sMrEsAEhEYstBRFflReXNMxSIsJpA;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != UVnNLjWoSqdiaVsnyQoruSXTVVIC)
				{
					ReInput.CheckInitialized(UVnNLjWoSqdiaVsnyQoruSXTVVIC);
					return -1;
				}
				return BwzeIWgUyvrdxcsOWnzldIhaQaZd;
			}
			internal set
			{
				BwzeIWgUyvrdxcsOWnzldIhaQaZd = bwzeIWgUyvrdxcsOWnzldIhaQaZd;
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != UVnNLjWoSqdiaVsnyQoruSXTVVIC)
				{
					ReInput.CheckInitialized(UVnNLjWoSqdiaVsnyQoruSXTVVIC);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return mQqFOtTkCrDOzxqdagqODczLPRTJ;
			}
		}

		internal ControllerTemplateMap(Guid P_0)
		{
			sxErHfvxkjRSONbIaZbdRicbBGet = yzCsAnkzMUVXFjvqciRruXlsOhYn++;
			UVnNLjWoSqdiaVsnyQoruSXTVVIC = ReInput._id;
			qQuunMNSkHEEqcYaIaAUyDUItyEN = P_0;
			lcrjxsGAaJLjNQuNixTekeyYToybA = new List<ControllerTemplateActionElementMap>();
			mQqFOtTkCrDOzxqdagqODczLPRTJ = new ReadOnlyCollection<ControllerTemplateActionElementMap>(lcrjxsGAaJLjNQuNixTekeyYToybA);
			YGoXFjKoekRRLoxMTdzWuvEUbpZG = true;
		}

		internal ControllerTemplateMap(Guid P_0, int P_1, int P_2, int P_3)
			: this(P_0)
		{
			SMrEsAEhEYstBRFflReXNMxSIsJpA = P_1;
			BwzeIWgUyvrdxcsOWnzldIhaQaZd = P_2;
			OABdMlLoQiKDPZuXYzWOZdVwfVXK = P_3;
		}

		public string ToXmlString()
		{
			if (ReInput._id != UVnNLjWoSqdiaVsnyQoruSXTVVIC)
			{
				ReInput.CheckInitialized(UVnNLjWoSqdiaVsnyQoruSXTVVIC);
				return string.Empty;
			}
			try
			{
				return zfhSjHUGDtiaQCEKTFebWahpOkXU().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != UVnNLjWoSqdiaVsnyQoruSXTVVIC)
			{
				ReInput.CheckInitialized(UVnNLjWoSqdiaVsnyQoruSXTVVIC);
				return string.Empty;
			}
			try
			{
				return zfhSjHUGDtiaQCEKTFebWahpOkXU().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != UVnNLjWoSqdiaVsnyQoruSXTVVIC)
			{
				ReInput.CheckInitialized(UVnNLjWoSqdiaVsnyQoruSXTVVIC);
				return null;
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			IControllerTemplate template = controller.GetTemplate(qQuunMNSkHEEqcYaIaAUyDUItyEN);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			ControllerMap controllerMap = ControllerMap.jQKDXoimuSpEWcCdpBenThEztXonA(controller.type);
			controllerMap.categoryId = SMrEsAEhEYstBRFflReXNMxSIsJpA;
			controllerMap.layoutId = BwzeIWgUyvrdxcsOWnzldIhaQaZd;
			if (OABdMlLoQiKDPZuXYzWOZdVwfVXK >= 0)
			{
				controllerMap.sourceMapId = OABdMlLoQiKDPZuXYzWOZdVwfVXK;
			}
			controllerMap.controllerId = controller.id;
			controllerMap.enabled = YGoXFjKoekRRLoxMTdzWuvEUbpZG;
			controllerMap.hardwareGuid = controller.lcQyDEaPLwhlbiUKrOtQaptBTwRjc;
			using TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>();
			List<ActionElementMap> list = tList.list;
			for (int i = 0; i < lcrjxsGAaJLjNQuNixTekeyYToybA.Count; i++)
			{
				lcrjxsGAaJLjNQuNixTekeyYToybA[i].njhUJjqKcXfmsAqIenXKDLVOqsfIA(template, list, false);
				for (int j = 0; j < list.Count; j++)
				{
					controllerMap.SRgvEhEXnsACwdSpkBjYoWEkqxLb(list[j]);
				}
			}
			return controllerMap;
		}

		internal virtual void VBgsDpaqPhrYSnGEALvmihrjRUde(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg
			{
				ielDRFPPVThNrLWgcnBdvoVjXqeg = "dataVersion",
				lPGTilhMaDlHVZPffTpyFffKvRGC = 1.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg
			{
				ielDRFPPVThNrLWgcnBdvoVjXqeg = "templateTypeGuid",
				lPGTilhMaDlHVZPffTpyFffKvRGC = qQuunMNSkHEEqcYaIaAUyDUItyEN.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg
			{
				ZGFlSbWGOfUmLZdUdkUpxhWKZcME = "xmlns",
				ielDRFPPVThNrLWgcnBdvoVjXqeg = "xsi",
				MFDdXiyHcPkUibxNoPMtNRhjvlXA = null,
				lPGTilhMaDlHVZPffTpyFffKvRGC = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg
			{
				ZGFlSbWGOfUmLZdUdkUpxhWKZcME = "xsi",
				ielDRFPPVThNrLWgcnBdvoVjXqeg = "schemaLocation",
				MFDdXiyHcPkUibxNoPMtNRhjvlXA = null,
				lPGTilhMaDlHVZPffTpyFffKvRGC = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
			});
			P_0.Add("templateTypeGuid", qQuunMNSkHEEqcYaIaAUyDUItyEN);
			P_0.Add("enabled", YGoXFjKoekRRLoxMTdzWuvEUbpZG);
			P_0.Add("categoryId", SMrEsAEhEYstBRFflReXNMxSIsJpA);
			P_0.Add("layoutId", BwzeIWgUyvrdxcsOWnzldIhaQaZd);
			P_0.Add("sourceMapId", OABdMlLoQiKDPZuXYzWOZdVwfVXK);
			int count = lcrjxsGAaJLjNQuNixTekeyYToybA.Count;
			List<object> list = new List<object>();
			P_0.Add("elementMaps", list);
			for (int i = 0; i < count; i++)
			{
				if (lcrjxsGAaJLjNQuNixTekeyYToybA[i] != null)
				{
					list.Add(lcrjxsGAaJLjNQuNixTekeyYToybA[i].gMkjhDYidgQaoBHNEqMOzlWUcQWM());
				}
			}
		}

		internal virtual void DyCTLfhOHCHFykQHlJTRwBZskhSXA(SerializedObject P_0)
		{
			vlrFsnHkieMgklBRqeEpYLtXubWUA();
			P_0.TryGetDeserializedValueByRef("enabled", ref YGoXFjKoekRRLoxMTdzWuvEUbpZG);
			P_0.TryGetDeserializedValueByRef("categoryId", ref SMrEsAEhEYstBRFflReXNMxSIsJpA);
			P_0.TryGetDeserializedValueByRef("layoutId", ref BwzeIWgUyvrdxcsOWnzldIhaQaZd);
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref OABdMlLoQiKDPZuXYzWOZdVwfVXK);
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
			{
				return;
			}
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.NsRYOXjYbblIPVqixiSXSKNbVOjV(value2);
					if (controllerTemplateActionElementMap != null)
					{
						oYYKPNpKEJdjIbPyQBgLFioWpWefA(controllerTemplateActionElementMap);
					}
				}
			}
		}

		private void vlrFsnHkieMgklBRqeEpYLtXubWUA()
		{
			YGoXFjKoekRRLoxMTdzWuvEUbpZG = true;
			SMrEsAEhEYstBRFflReXNMxSIsJpA = -1;
			BwzeIWgUyvrdxcsOWnzldIhaQaZd = -1;
			OABdMlLoQiKDPZuXYzWOZdVwfVXK = -1;
			lcrjxsGAaJLjNQuNixTekeyYToybA.Clear();
		}

		private SerializedObject zfhSjHUGDtiaQCEKTFebWahpOkXU()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			VBgsDpaqPhrYSnGEALvmihrjRUde(serializedObject);
			return serializedObject;
		}

		internal void oYYKPNpKEJdjIbPyQBgLFioWpWefA(ControllerTemplateActionElementMap P_0)
		{
			if (P_0 != null)
			{
				lcrjxsGAaJLjNQuNixTekeyYToybA.Add(P_0);
			}
		}

		internal static ControllerTemplateMap qQBJNkYOGecrgXLtarpZybwboFVc(IControllerTemplate P_0, ControllerMap P_1)
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
			controllerTemplateMap.YGoXFjKoekRRLoxMTdzWuvEUbpZG = P_1.enabled;
			controllerTemplateMap.SMrEsAEhEYstBRFflReXNMxSIsJpA = P_1.categoryId;
			controllerTemplateMap.BwzeIWgUyvrdxcsOWnzldIhaQaZd = P_1.layoutId;
			controllerTemplateMap.OABdMlLoQiKDPZuXYzWOZdVwfVXK = P_1.sourceMapId;
			using TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>();
			List<ControllerTemplateElementTarget> list = tList.list;
			foreach (ActionElementMap allMap in P_1.AllMaps)
			{
				if (P_0.GetElementTargets(allMap, list) > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						controllerTemplateMap.oYYKPNpKEJdjIbPyQBgLFioWpWefA(ControllerTemplateActionElementMap.JywGjTkiJDyelJIIDKOJEAjCGDxmc(list[i], allMap));
					}
				}
			}
			return controllerTemplateMap;
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			try
			{
				return FdjObtHNcBDTaeQHhhFyRpGDcUSz(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
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
				return FdjObtHNcBDTaeQHhhFyRpGDcUSz(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				return null;
			}
		}

		private static ControllerTemplateMap FdjObtHNcBDTaeQHhhFyRpGDcUSz(SerializedObject P_0)
		{
			if (!P_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.DyCTLfhOHCHFykQHlJTRwBZskhSXA(P_0);
			return controllerTemplateMap;
		}
	}
}
