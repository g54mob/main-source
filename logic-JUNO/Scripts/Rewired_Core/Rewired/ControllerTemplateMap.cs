using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int RnUDjKHYHHSSxNmrIvAWUYEnNzkJ;

		private readonly int lXptuWiPpGoHPBgYEckAxFeTXUAW;

		private readonly Guid dYFEltfErcZlvKwoiqlrpWEobemtA;

		private readonly List<ControllerTemplateActionElementMap> maMWjLNxlaHSOetLYjsDCQgioeGy;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> zgNHKAULYOoswndgOTfPdvjxLvHB;

		private bool JhZZNQZppHCoOkiGfOYtbYEmalpSA;

		private int ToMvezsiLzaYUVLlHZQouYhikLrF;

		private int YVScahvHQSKeaksucCvUHWOQKapg;

		private int VGcYGOIlHBwKQTFLkGLflDXOdljS = -1;

		private static int rEtHAAbwLvcxClCiGmUOWadYAvmS;

		public int id
		{
			get
			{
				if (ReInput._id != RnUDjKHYHHSSxNmrIvAWUYEnNzkJ)
				{
					ReInput.CheckInitialized(RnUDjKHYHHSSxNmrIvAWUYEnNzkJ);
					return -1;
				}
				return lXptuWiPpGoHPBgYEckAxFeTXUAW;
			}
		}

		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != RnUDjKHYHHSSxNmrIvAWUYEnNzkJ)
				{
					ReInput.CheckInitialized(RnUDjKHYHHSSxNmrIvAWUYEnNzkJ);
					return Guid.Empty;
				}
				return dYFEltfErcZlvKwoiqlrpWEobemtA;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != RnUDjKHYHHSSxNmrIvAWUYEnNzkJ)
				{
					ReInput.CheckInitialized(RnUDjKHYHHSSxNmrIvAWUYEnNzkJ);
					return false;
				}
				return JhZZNQZppHCoOkiGfOYtbYEmalpSA;
			}
			set
			{
				JhZZNQZppHCoOkiGfOYtbYEmalpSA = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != RnUDjKHYHHSSxNmrIvAWUYEnNzkJ)
				{
					ReInput.CheckInitialized(RnUDjKHYHHSSxNmrIvAWUYEnNzkJ);
					return -1;
				}
				return ToMvezsiLzaYUVLlHZQouYhikLrF;
			}
			internal set
			{
				ToMvezsiLzaYUVLlHZQouYhikLrF = toMvezsiLzaYUVLlHZQouYhikLrF;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != RnUDjKHYHHSSxNmrIvAWUYEnNzkJ)
				{
					ReInput.CheckInitialized(RnUDjKHYHHSSxNmrIvAWUYEnNzkJ);
					return -1;
				}
				return YVScahvHQSKeaksucCvUHWOQKapg;
			}
			internal set
			{
				YVScahvHQSKeaksucCvUHWOQKapg = yVScahvHQSKeaksucCvUHWOQKapg;
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != RnUDjKHYHHSSxNmrIvAWUYEnNzkJ)
				{
					ReInput.CheckInitialized(RnUDjKHYHHSSxNmrIvAWUYEnNzkJ);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return zgNHKAULYOoswndgOTfPdvjxLvHB;
			}
		}

		internal ControllerTemplateMap(Guid P_0)
		{
			lXptuWiPpGoHPBgYEckAxFeTXUAW = rEtHAAbwLvcxClCiGmUOWadYAvmS++;
			RnUDjKHYHHSSxNmrIvAWUYEnNzkJ = ReInput._id;
			dYFEltfErcZlvKwoiqlrpWEobemtA = P_0;
			maMWjLNxlaHSOetLYjsDCQgioeGy = new List<ControllerTemplateActionElementMap>();
			zgNHKAULYOoswndgOTfPdvjxLvHB = new ReadOnlyCollection<ControllerTemplateActionElementMap>(maMWjLNxlaHSOetLYjsDCQgioeGy);
			JhZZNQZppHCoOkiGfOYtbYEmalpSA = true;
		}

		internal ControllerTemplateMap(Guid P_0, int P_1, int P_2, int P_3)
			: this(P_0)
		{
			ToMvezsiLzaYUVLlHZQouYhikLrF = P_1;
			YVScahvHQSKeaksucCvUHWOQKapg = P_2;
			VGcYGOIlHBwKQTFLkGLflDXOdljS = P_3;
		}

		public string ToXmlString()
		{
			if (ReInput._id != RnUDjKHYHHSSxNmrIvAWUYEnNzkJ)
			{
				ReInput.CheckInitialized(RnUDjKHYHHSSxNmrIvAWUYEnNzkJ);
				return string.Empty;
			}
			try
			{
				return coSGhsNGaMHcBOUwbJXQgvFRmvxd().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != RnUDjKHYHHSSxNmrIvAWUYEnNzkJ)
			{
				ReInput.CheckInitialized(RnUDjKHYHHSSxNmrIvAWUYEnNzkJ);
				return string.Empty;
			}
			try
			{
				return coSGhsNGaMHcBOUwbJXQgvFRmvxd().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != RnUDjKHYHHSSxNmrIvAWUYEnNzkJ)
			{
				ReInput.CheckInitialized(RnUDjKHYHHSSxNmrIvAWUYEnNzkJ);
				return null;
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			IControllerTemplate template = controller.GetTemplate(dYFEltfErcZlvKwoiqlrpWEobemtA);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			ControllerMap controllerMap = ControllerMap.ypbYJNxChdplXGglBbDKJNWHdLYsA(controller.type);
			controllerMap.categoryId = ToMvezsiLzaYUVLlHZQouYhikLrF;
			controllerMap.layoutId = YVScahvHQSKeaksucCvUHWOQKapg;
			if (VGcYGOIlHBwKQTFLkGLflDXOdljS >= 0)
			{
				controllerMap.sourceMapId = VGcYGOIlHBwKQTFLkGLflDXOdljS;
			}
			controllerMap.controllerId = controller.id;
			controllerMap.enabled = JhZZNQZppHCoOkiGfOYtbYEmalpSA;
			controllerMap.hardwareGuid = controller.gLbADvCdALkEcLIQPhWpjDrhhunKA;
			using TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>();
			List<ActionElementMap> list = tList.list;
			for (int i = 0; i < maMWjLNxlaHSOetLYjsDCQgioeGy.Count; i++)
			{
				maMWjLNxlaHSOetLYjsDCQgioeGy[i].mKIGHQDrhuZPlEcYQykrUxNuvePFA(template, list, false);
				for (int j = 0; j < list.Count; j++)
				{
					controllerMap.LtPlOjVYNTfYZlErEqgWUUqCmfNC(list[j]);
				}
			}
			return controllerMap;
		}

		internal virtual void SINipMrrIISUXxKvycLTUzRHFrFd(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.StxLVFERPlwSUZNlMaKuFuVAjcqCb
			{
				rVQdJsUVGueUoRlsQQCEHMDLFJOq = "dataVersion",
				wqpBUPsVbkYZOHRjZkDHzExwrqmJ = 1.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.StxLVFERPlwSUZNlMaKuFuVAjcqCb
			{
				rVQdJsUVGueUoRlsQQCEHMDLFJOq = "templateTypeGuid",
				wqpBUPsVbkYZOHRjZkDHzExwrqmJ = dYFEltfErcZlvKwoiqlrpWEobemtA.ToString()
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.StxLVFERPlwSUZNlMaKuFuVAjcqCb
			{
				GXuxQnHFoIjGhTjGJBCERvyaPbcC = "xmlns",
				rVQdJsUVGueUoRlsQQCEHMDLFJOq = "xsi",
				JTcffmzfUBZAVjPblkObnRNPpqZG = null,
				wqpBUPsVbkYZOHRjZkDHzExwrqmJ = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.StxLVFERPlwSUZNlMaKuFuVAjcqCb
			{
				GXuxQnHFoIjGhTjGJBCERvyaPbcC = "xsi",
				rVQdJsUVGueUoRlsQQCEHMDLFJOq = "schemaLocation",
				JTcffmzfUBZAVjPblkObnRNPpqZG = null,
				wqpBUPsVbkYZOHRjZkDHzExwrqmJ = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
			});
			P_0.Add("templateTypeGuid", dYFEltfErcZlvKwoiqlrpWEobemtA);
			P_0.Add("enabled", JhZZNQZppHCoOkiGfOYtbYEmalpSA);
			P_0.Add("categoryId", ToMvezsiLzaYUVLlHZQouYhikLrF);
			P_0.Add("layoutId", YVScahvHQSKeaksucCvUHWOQKapg);
			P_0.Add("sourceMapId", VGcYGOIlHBwKQTFLkGLflDXOdljS);
			int count = maMWjLNxlaHSOetLYjsDCQgioeGy.Count;
			List<object> list = new List<object>();
			P_0.Add("elementMaps", list);
			for (int i = 0; i < count; i++)
			{
				if (maMWjLNxlaHSOetLYjsDCQgioeGy[i] != null)
				{
					list.Add(maMWjLNxlaHSOetLYjsDCQgioeGy[i].xqVohyVImLDPxhDDkAznNHGyIUmDb());
				}
			}
		}

		internal virtual void WVnDBSfwMtTgboEBDRwgpvJUormDb(SerializedObject P_0)
		{
			iHItmGxelXqLdLaROGdOfzxdJnmPA();
			P_0.TryGetDeserializedValueByRef("enabled", ref JhZZNQZppHCoOkiGfOYtbYEmalpSA);
			P_0.TryGetDeserializedValueByRef("categoryId", ref ToMvezsiLzaYUVLlHZQouYhikLrF);
			P_0.TryGetDeserializedValueByRef("layoutId", ref YVScahvHQSKeaksucCvUHWOQKapg);
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref VGcYGOIlHBwKQTFLkGLflDXOdljS);
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
			{
				return;
			}
			for (int i = 0; i < value.count; i++)
			{
				if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.YIudOyAiyGFjUsJoFYtyjwZPOYBz(value2);
					if (controllerTemplateActionElementMap != null)
					{
						tzpINcgyDkSIVzVceGHiYToegKYM(controllerTemplateActionElementMap);
					}
				}
			}
		}

		private void iHItmGxelXqLdLaROGdOfzxdJnmPA()
		{
			JhZZNQZppHCoOkiGfOYtbYEmalpSA = true;
			ToMvezsiLzaYUVLlHZQouYhikLrF = -1;
			YVScahvHQSKeaksucCvUHWOQKapg = -1;
			VGcYGOIlHBwKQTFLkGLflDXOdljS = -1;
			maMWjLNxlaHSOetLYjsDCQgioeGy.Clear();
		}

		private SerializedObject coSGhsNGaMHcBOUwbJXQgvFRmvxd()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			SINipMrrIISUXxKvycLTUzRHFrFd(serializedObject);
			return serializedObject;
		}

		internal void tzpINcgyDkSIVzVceGHiYToegKYM(ControllerTemplateActionElementMap P_0)
		{
			if (P_0 != null)
			{
				maMWjLNxlaHSOetLYjsDCQgioeGy.Add(P_0);
			}
		}

		internal static ControllerTemplateMap pNwDHdFNwRNhqTVrAOeAOvaVaDhE(IControllerTemplate P_0, ControllerMap P_1)
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
			controllerTemplateMap.JhZZNQZppHCoOkiGfOYtbYEmalpSA = P_1.enabled;
			controllerTemplateMap.ToMvezsiLzaYUVLlHZQouYhikLrF = P_1.categoryId;
			controllerTemplateMap.YVScahvHQSKeaksucCvUHWOQKapg = P_1.layoutId;
			controllerTemplateMap.VGcYGOIlHBwKQTFLkGLflDXOdljS = P_1.sourceMapId;
			using TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>();
			List<ControllerTemplateElementTarget> list = tList.list;
			foreach (ActionElementMap allMap in P_1.AllMaps)
			{
				if (P_0.GetElementTargets(allMap, list) > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						controllerTemplateMap.tzpINcgyDkSIVzVceGHiYToegKYM(ControllerTemplateActionElementMap.OeRWdwrOMaSLwSuIbhdsksrgwJXN(list[i], allMap));
					}
				}
			}
			return controllerTemplateMap;
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			try
			{
				return OwAkzYAGbwsmbuSXROiVhCWnwKqv(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
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
				return OwAkzYAGbwsmbuSXROiVhCWnwKqv(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				return null;
			}
		}

		private static ControllerTemplateMap OwAkzYAGbwsmbuSXROiVhCWnwKqv(SerializedObject P_0)
		{
			if (!P_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.WVnDBSfwMtTgboEBDRwgpvJUormDb(P_0);
			return controllerTemplateMap;
		}
	}
}
