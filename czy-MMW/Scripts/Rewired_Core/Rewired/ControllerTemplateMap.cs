using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int FQJETAMOGznReFereGANcEokhWGG;

		private readonly int xrsyJQbsQyXdUBVUmLGHRAAUsjwd;

		private readonly Guid zRYnmbHSqQBAoDmbKiYsdyiEfUAgB;

		private readonly List<ControllerTemplateActionElementMap> qDDGoPAmgSHlFuVImMBQshEzsIeS;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> rMYEKMXTSqRhvnuqaaRkTEXuDtTq;

		private bool XkInMSQnuvQZHmzFHFtsmOahTNVn;

		private int BiVHxhbYGHafPFdghjaxJYDjGAJNA;

		private int KSPpelkaIukdruHvOvhTtGaZEsBFA;

		private int DlFQuNODjVBULODMnaSTrODBBWB = -1;

		private static int dBovNCcZGLAZRvCjgKNRcELBWZWo;

		public int id
		{
			get
			{
				if (ReInput._id != FQJETAMOGznReFereGANcEokhWGG)
				{
					ReInput.CheckInitialized(FQJETAMOGznReFereGANcEokhWGG);
					return -1;
				}
				return xrsyJQbsQyXdUBVUmLGHRAAUsjwd;
			}
		}

		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != FQJETAMOGznReFereGANcEokhWGG)
				{
					ReInput.CheckInitialized(FQJETAMOGznReFereGANcEokhWGG);
					return Guid.Empty;
				}
				return zRYnmbHSqQBAoDmbKiYsdyiEfUAgB;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != FQJETAMOGznReFereGANcEokhWGG)
				{
					ReInput.CheckInitialized(FQJETAMOGznReFereGANcEokhWGG);
					return false;
				}
				return XkInMSQnuvQZHmzFHFtsmOahTNVn;
			}
			set
			{
				XkInMSQnuvQZHmzFHFtsmOahTNVn = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != FQJETAMOGznReFereGANcEokhWGG)
				{
					ReInput.CheckInitialized(FQJETAMOGznReFereGANcEokhWGG);
					return -1;
				}
				return BiVHxhbYGHafPFdghjaxJYDjGAJNA;
			}
			internal set
			{
				BiVHxhbYGHafPFdghjaxJYDjGAJNA = biVHxhbYGHafPFdghjaxJYDjGAJNA;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != FQJETAMOGznReFereGANcEokhWGG)
				{
					ReInput.CheckInitialized(FQJETAMOGznReFereGANcEokhWGG);
					return -1;
				}
				return KSPpelkaIukdruHvOvhTtGaZEsBFA;
			}
			internal set
			{
				KSPpelkaIukdruHvOvhTtGaZEsBFA = kSPpelkaIukdruHvOvhTtGaZEsBFA;
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != FQJETAMOGznReFereGANcEokhWGG)
				{
					ReInput.CheckInitialized(FQJETAMOGznReFereGANcEokhWGG);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return rMYEKMXTSqRhvnuqaaRkTEXuDtTq;
			}
		}

		internal ControllerTemplateMap(Guid P_0)
		{
			xrsyJQbsQyXdUBVUmLGHRAAUsjwd = dBovNCcZGLAZRvCjgKNRcELBWZWo++;
			FQJETAMOGznReFereGANcEokhWGG = ReInput._id;
			zRYnmbHSqQBAoDmbKiYsdyiEfUAgB = P_0;
			qDDGoPAmgSHlFuVImMBQshEzsIeS = new List<ControllerTemplateActionElementMap>();
			rMYEKMXTSqRhvnuqaaRkTEXuDtTq = new ReadOnlyCollection<ControllerTemplateActionElementMap>(qDDGoPAmgSHlFuVImMBQshEzsIeS);
			XkInMSQnuvQZHmzFHFtsmOahTNVn = true;
		}

		internal ControllerTemplateMap(Guid P_0, int P_1, int P_2, int P_3)
			: this(P_0)
		{
			BiVHxhbYGHafPFdghjaxJYDjGAJNA = P_1;
			KSPpelkaIukdruHvOvhTtGaZEsBFA = P_2;
			DlFQuNODjVBULODMnaSTrODBBWB = P_3;
		}

		public string ToXmlString()
		{
			if (ReInput._id != FQJETAMOGznReFereGANcEokhWGG)
			{
				ReInput.CheckInitialized(FQJETAMOGznReFereGANcEokhWGG);
				return string.Empty;
			}
			try
			{
				return ykPNUmQqHoquKEIFFsDHCHJOkSFR().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != FQJETAMOGznReFereGANcEokhWGG)
			{
				ReInput.CheckInitialized(FQJETAMOGznReFereGANcEokhWGG);
				return string.Empty;
			}
			try
			{
				return ykPNUmQqHoquKEIFFsDHCHJOkSFR().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != FQJETAMOGznReFereGANcEokhWGG)
			{
				ReInput.CheckInitialized(FQJETAMOGznReFereGANcEokhWGG);
				return null;
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			IControllerTemplate template = controller.GetTemplate(zRYnmbHSqQBAoDmbKiYsdyiEfUAgB);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			ControllerMap controllerMap = ControllerMap.ctcJORaseVdEGWTaltoRzKkQCnen(controller.type);
			controllerMap.categoryId = BiVHxhbYGHafPFdghjaxJYDjGAJNA;
			controllerMap.layoutId = KSPpelkaIukdruHvOvhTtGaZEsBFA;
			if (DlFQuNODjVBULODMnaSTrODBBWB >= 0)
			{
				controllerMap.sourceMapId = DlFQuNODjVBULODMnaSTrODBBWB;
			}
			controllerMap.controllerId = controller.id;
			controllerMap.enabled = XkInMSQnuvQZHmzFHFtsmOahTNVn;
			controllerMap.hardwareGuid = controller.sfymSjcVHxtWxMcRdJtqvPLgjYLfA;
			using TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>();
			List<ActionElementMap> list = tList.list;
			for (int i = 0; i < qDDGoPAmgSHlFuVImMBQshEzsIeS.Count; i++)
			{
				qDDGoPAmgSHlFuVImMBQshEzsIeS[i].ueJqIGwNkYdgqyqDkeFaPtxdONzl(template, list, false);
				for (int j = 0; j < list.Count; j++)
				{
					controllerMap.HPOsNbYEHzjGQhSFgJFXiksNXGln(list[j]);
				}
			}
			return controllerMap;
		}

		internal virtual void IFQlNQogioCvGlILCUPCqUVQkprm(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA
			{
				rzFSJcZEFOpFlXqzyhdFdwpOrpaJ = "dataVersion",
				sMgGiLjHAAIlXTFOzVTKBeTzOPUX = 1.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA
			{
				rzFSJcZEFOpFlXqzyhdFdwpOrpaJ = "templateTypeGuid",
				sMgGiLjHAAIlXTFOzVTKBeTzOPUX = zRYnmbHSqQBAoDmbKiYsdyiEfUAgB.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA
			{
				OehazIAPEcSENVTqpypPfkRtzKCK = "xmlns",
				rzFSJcZEFOpFlXqzyhdFdwpOrpaJ = "xsi",
				FqpwTkyfXldoEdOuFQPgNddSWNnN = null,
				sMgGiLjHAAIlXTFOzVTKBeTzOPUX = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA
			{
				OehazIAPEcSENVTqpypPfkRtzKCK = "xsi",
				rzFSJcZEFOpFlXqzyhdFdwpOrpaJ = "schemaLocation",
				FqpwTkyfXldoEdOuFQPgNddSWNnN = null,
				sMgGiLjHAAIlXTFOzVTKBeTzOPUX = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
			});
			P_0.Add("templateTypeGuid", zRYnmbHSqQBAoDmbKiYsdyiEfUAgB);
			P_0.Add("enabled", XkInMSQnuvQZHmzFHFtsmOahTNVn);
			P_0.Add("categoryId", BiVHxhbYGHafPFdghjaxJYDjGAJNA);
			P_0.Add("layoutId", KSPpelkaIukdruHvOvhTtGaZEsBFA);
			P_0.Add("sourceMapId", DlFQuNODjVBULODMnaSTrODBBWB);
			int count = qDDGoPAmgSHlFuVImMBQshEzsIeS.Count;
			List<object> list = new List<object>();
			P_0.Add("elementMaps", list);
			for (int i = 0; i < count; i++)
			{
				if (qDDGoPAmgSHlFuVImMBQshEzsIeS[i] != null)
				{
					list.Add(qDDGoPAmgSHlFuVImMBQshEzsIeS[i].jnIDmqDKnldoyoJQKbMmrrobSwSy());
				}
			}
		}

		internal virtual void AZioKIpuDHaZoUzExnTnNgrPLBYQ(SerializedObject P_0)
		{
			sKLfbEcdgpQsqRmAeBONDGHquTUX();
			P_0.TryGetDeserializedValueByRef("enabled", ref XkInMSQnuvQZHmzFHFtsmOahTNVn);
			P_0.TryGetDeserializedValueByRef("categoryId", ref BiVHxhbYGHafPFdghjaxJYDjGAJNA);
			P_0.TryGetDeserializedValueByRef("layoutId", ref KSPpelkaIukdruHvOvhTtGaZEsBFA);
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref DlFQuNODjVBULODMnaSTrODBBWB);
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
			{
				return;
			}
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.YmbOLerfjswQFZTvzfYzYGlAcwns(value2);
					if (controllerTemplateActionElementMap != null)
					{
						fwozYspuYYQbMtMlWBkfjsMzhgiEb(controllerTemplateActionElementMap);
					}
				}
			}
		}

		private void sKLfbEcdgpQsqRmAeBONDGHquTUX()
		{
			XkInMSQnuvQZHmzFHFtsmOahTNVn = true;
			BiVHxhbYGHafPFdghjaxJYDjGAJNA = -1;
			KSPpelkaIukdruHvOvhTtGaZEsBFA = -1;
			DlFQuNODjVBULODMnaSTrODBBWB = -1;
			qDDGoPAmgSHlFuVImMBQshEzsIeS.Clear();
		}

		private SerializedObject ykPNUmQqHoquKEIFFsDHCHJOkSFR()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			IFQlNQogioCvGlILCUPCqUVQkprm(serializedObject);
			return serializedObject;
		}

		internal void fwozYspuYYQbMtMlWBkfjsMzhgiEb(ControllerTemplateActionElementMap P_0)
		{
			if (P_0 != null)
			{
				qDDGoPAmgSHlFuVImMBQshEzsIeS.Add(P_0);
			}
		}

		internal static ControllerTemplateMap xuhSpLWtSnoqyFUMujzteHLCSvXI(IControllerTemplate P_0, ControllerMap P_1)
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
			controllerTemplateMap.XkInMSQnuvQZHmzFHFtsmOahTNVn = P_1.enabled;
			controllerTemplateMap.BiVHxhbYGHafPFdghjaxJYDjGAJNA = P_1.categoryId;
			controllerTemplateMap.KSPpelkaIukdruHvOvhTtGaZEsBFA = P_1.layoutId;
			controllerTemplateMap.DlFQuNODjVBULODMnaSTrODBBWB = P_1.sourceMapId;
			using TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>();
			List<ControllerTemplateElementTarget> list = tList.list;
			foreach (ActionElementMap allMap in P_1.AllMaps)
			{
				if (P_0.GetElementTargets(allMap, list) > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						controllerTemplateMap.fwozYspuYYQbMtMlWBkfjsMzhgiEb(ControllerTemplateActionElementMap.WXSDkkmTTKGydYeBBBOjCYLzThdUA(list[i], allMap));
					}
				}
			}
			return controllerTemplateMap;
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			try
			{
				return SCBAoMjTmIaFqxsQfpJSBVeeueInA(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
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
				return SCBAoMjTmIaFqxsQfpJSBVeeueInA(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				return null;
			}
		}

		private static ControllerTemplateMap SCBAoMjTmIaFqxsQfpJSBVeeueInA(SerializedObject P_0)
		{
			if (!P_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.AZioKIpuDHaZoUzExnTnNgrPLBYQ(P_0);
			return controllerTemplateMap;
		}
	}
}
