using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int VumWnlylMgxSbyJcluXptXvaaZa;

		private readonly int JYRMuwETpVNRqJXmtBgBFhZdTeP;

		private readonly Guid zjPVlVaiOXMwxLScjAkMrrJWAUs;

		private readonly List<ControllerTemplateActionElementMap> sjXVlqwEmHNjNiJMTJifUagteIH;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> DEjcOPjDijDalCWfMSjBdgOGDFTW;

		private bool fnEBjitvkHhPtXTzRLmBYpIxFbt;

		private int xVhgtfDpJuJsgcIJJaJwBbmlCmVi;

		private int WNAcEXgWExtSqRWSpeTxucHFlgKA;

		private int pCCdSHDJaCDZnEtbAOuAhYTKSoB = -1;

		private static int sletNRlrLmUZzqGowqNsMpsFacl;

		public int id
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return JYRMuwETpVNRqJXmtBgBFhZdTeP;
			}
		}

		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Guid.Empty;
				}
				return zjPVlVaiOXMwxLScjAkMrrJWAUs;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				return fnEBjitvkHhPtXTzRLmBYpIxFbt;
			}
			set
			{
				fnEBjitvkHhPtXTzRLmBYpIxFbt = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return xVhgtfDpJuJsgcIJJaJwBbmlCmVi;
			}
			internal set
			{
				xVhgtfDpJuJsgcIJJaJwBbmlCmVi = value;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return WNAcEXgWExtSqRWSpeTxucHFlgKA;
			}
			internal set
			{
				WNAcEXgWExtSqRWSpeTxucHFlgKA = value;
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return DEjcOPjDijDalCWfMSjBdgOGDFTW;
			}
		}

		internal ControllerTemplateMap(Guid templateTypeGuid)
		{
			JYRMuwETpVNRqJXmtBgBFhZdTeP = sletNRlrLmUZzqGowqNsMpsFacl++;
			VumWnlylMgxSbyJcluXptXvaaZa = ReInput._id;
			zjPVlVaiOXMwxLScjAkMrrJWAUs = templateTypeGuid;
			sjXVlqwEmHNjNiJMTJifUagteIH = new List<ControllerTemplateActionElementMap>();
			DEjcOPjDijDalCWfMSjBdgOGDFTW = new ReadOnlyCollection<ControllerTemplateActionElementMap>(sjXVlqwEmHNjNiJMTJifUagteIH);
			fnEBjitvkHhPtXTzRLmBYpIxFbt = true;
		}

		internal ControllerTemplateMap(Guid templateTypeGuid, int categoryId, int layoutId, int sourceMapId)
			: this(templateTypeGuid)
		{
			xVhgtfDpJuJsgcIJJaJwBbmlCmVi = categoryId;
			WNAcEXgWExtSqRWSpeTxucHFlgKA = layoutId;
			pCCdSHDJaCDZnEtbAOuAhYTKSoB = sourceMapId;
		}

		public string ToXmlString()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return string.Empty;
			}
			try
			{
				return MtzBZMSurJCTTdjsBqkSRhDyHCFi().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return string.Empty;
			}
			try
			{
				return MtzBZMSurJCTTdjsBqkSRhDyHCFi().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			IControllerTemplate template = controller.GetTemplate(zjPVlVaiOXMwxLScjAkMrrJWAUs);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			ControllerMap controllerMap = ControllerMap.ikoBGVHHLVNnLaVaWGffMETVhTJw(controller.type);
			controllerMap.categoryId = xVhgtfDpJuJsgcIJJaJwBbmlCmVi;
			controllerMap.layoutId = WNAcEXgWExtSqRWSpeTxucHFlgKA;
			if (pCCdSHDJaCDZnEtbAOuAhYTKSoB >= 0)
			{
				controllerMap.sourceMapId = pCCdSHDJaCDZnEtbAOuAhYTKSoB;
			}
			controllerMap.controllerId = controller.id;
			controllerMap.controllerType = controller.type;
			controllerMap.enabled = fnEBjitvkHhPtXTzRLmBYpIxFbt;
			controllerMap.hardwareGuid = controller.whqrPnRNEDctHvdjThUpHsqpUGr;
			using TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>();
			List<ActionElementMap> list = tList.list;
			for (int i = 0; i < sjXVlqwEmHNjNiJMTJifUagteIH.Count; i++)
			{
				sjXVlqwEmHNjNiJMTJifUagteIH[i].QLMQQiTDjQNXTnBeehpomRheiZj(template, list, false);
				for (int j = 0; j < list.Count; j++)
				{
					controllerMap.iXVFNbKWeZKqDcDBYTqLDREGlmD(list[j]);
				}
			}
			return controllerMap;
		}

		internal virtual void jcgUSwYyXKIwVuYwxHnWUgkgsoK(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm
			{
				NSIraOohUuxbwNWwnOfcoaPLKLA = "dataVersion",
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = 1.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm
			{
				NSIraOohUuxbwNWwnOfcoaPLKLA = "templateTypeGuid",
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = zjPVlVaiOXMwxLScjAkMrrJWAUs.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm
			{
				tpjeoHgHRUvvsMOVGUmfENOfWgb = "xmlns",
				NSIraOohUuxbwNWwnOfcoaPLKLA = "xsi",
				KyKFPbDbzyvJvQZYVoBMpXenzVYN = null,
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm
			{
				tpjeoHgHRUvvsMOVGUmfENOfWgb = "xsi",
				NSIraOohUuxbwNWwnOfcoaPLKLA = "schemaLocation",
				KyKFPbDbzyvJvQZYVoBMpXenzVYN = null,
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
			});
			P_0.Add("templateTypeGuid", zjPVlVaiOXMwxLScjAkMrrJWAUs);
			P_0.Add("enabled", fnEBjitvkHhPtXTzRLmBYpIxFbt);
			P_0.Add("categoryId", xVhgtfDpJuJsgcIJJaJwBbmlCmVi);
			P_0.Add("layoutId", WNAcEXgWExtSqRWSpeTxucHFlgKA);
			P_0.Add("sourceMapId", pCCdSHDJaCDZnEtbAOuAhYTKSoB);
			int count = sjXVlqwEmHNjNiJMTJifUagteIH.Count;
			List<object> list = new List<object>();
			P_0.Add("elementMaps", list);
			for (int i = 0; i < count; i++)
			{
				if (sjXVlqwEmHNjNiJMTJifUagteIH[i] != null)
				{
					list.Add(sjXVlqwEmHNjNiJMTJifUagteIH[i].MtzBZMSurJCTTdjsBqkSRhDyHCFi());
				}
			}
		}

		internal virtual void tlMbXbDwaaKJTudkJIuTPdZmwuo(SerializedObject P_0)
		{
			VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			P_0.TryGetDeserializedValueByRef("enabled", ref fnEBjitvkHhPtXTzRLmBYpIxFbt);
			P_0.TryGetDeserializedValueByRef("categoryId", ref xVhgtfDpJuJsgcIJJaJwBbmlCmVi);
			P_0.TryGetDeserializedValueByRef("layoutId", ref WNAcEXgWExtSqRWSpeTxucHFlgKA);
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref pCCdSHDJaCDZnEtbAOuAhYTKSoB);
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
			{
				return;
			}
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.ikoBGVHHLVNnLaVaWGffMETVhTJw(value2);
					if (controllerTemplateActionElementMap != null)
					{
						IatatAaUtWRxlkFXsRjmLeztlkR(controllerTemplateActionElementMap);
					}
				}
			}
		}

		private void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			fnEBjitvkHhPtXTzRLmBYpIxFbt = true;
			xVhgtfDpJuJsgcIJJaJwBbmlCmVi = -1;
			WNAcEXgWExtSqRWSpeTxucHFlgKA = -1;
			pCCdSHDJaCDZnEtbAOuAhYTKSoB = -1;
			sjXVlqwEmHNjNiJMTJifUagteIH.Clear();
		}

		private SerializedObject MtzBZMSurJCTTdjsBqkSRhDyHCFi()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			jcgUSwYyXKIwVuYwxHnWUgkgsoK(serializedObject);
			return serializedObject;
		}

		internal void IatatAaUtWRxlkFXsRjmLeztlkR(ControllerTemplateActionElementMap P_0)
		{
			if (P_0 != null)
			{
				sjXVlqwEmHNjNiJMTJifUagteIH.Add(P_0);
			}
		}

		internal static ControllerTemplateMap WdHmbeogxFpqCPrhnXEZqMrbhjd(IControllerTemplate P_0, ControllerMap P_1)
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
			controllerTemplateMap.fnEBjitvkHhPtXTzRLmBYpIxFbt = P_1.enabled;
			controllerTemplateMap.xVhgtfDpJuJsgcIJJaJwBbmlCmVi = P_1.categoryId;
			controllerTemplateMap.WNAcEXgWExtSqRWSpeTxucHFlgKA = P_1.layoutId;
			controllerTemplateMap.pCCdSHDJaCDZnEtbAOuAhYTKSoB = P_1.sourceMapId;
			using TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>();
			List<ControllerTemplateElementTarget> list = tList.list;
			foreach (ActionElementMap allMap in P_1.AllMaps)
			{
				if (P_0.GetElementTargets(allMap, list) > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						controllerTemplateMap.IatatAaUtWRxlkFXsRjmLeztlkR(ControllerTemplateActionElementMap.ikoBGVHHLVNnLaVaWGffMETVhTJw(list[i], allMap));
					}
				}
			}
			return controllerTemplateMap;
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			try
			{
				return ZPgtJfPFStVOLvjJROZCchWwatB(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
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
				return ZPgtJfPFStVOLvjJROZCchWwatB(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				return null;
			}
		}

		private static ControllerTemplateMap ZPgtJfPFStVOLvjJROZCchWwatB(SerializedObject P_0)
		{
			if (!P_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.tlMbXbDwaaKJTudkJIuTPdZmwuo(P_0);
			return controllerTemplateMap;
		}
	}
}
