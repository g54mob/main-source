using ES3Internal;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"rocketMount", "rocketReady", "isRocketMounted", "rocketType", "usable", "furnitureGO", "description", "size", "installableLayerMask", "itemNameTemp",
		"itemName", "mainImage", "value", "canGrab", "outLine"
	})]
	public class ES3UserType_RocketMount : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_RocketMount()
			: base(typeof(RocketMount))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			RocketMount rocketMount = (RocketMount)obj;
			writer.WritePropertyByRef("rocketMount", rocketMount.rocketMount);
			writer.WritePrivateFieldByRef("rocketReady", rocketMount);
			writer.WritePrivateField("isRocketMounted", rocketMount);
			writer.WriteProperty("rocketType", rocketMount.rocketType, ES3TypeMgr.GetOrCreateES3Type(typeof(RocketType)));
			writer.WriteProperty("usable", rocketMount.usable, ES3Type_bool.Instance);
			writer.WritePropertyByRef("furnitureGO", rocketMount.furnitureGO);
			writer.WriteProperty("description", rocketMount.description, ES3TypeMgr.GetOrCreateES3Type(typeof(LocalizedString)));
			writer.WriteProperty("size", rocketMount.size, ES3Type_Vector3.Instance);
			writer.WriteProperty("installableLayerMask", rocketMount.installableLayerMask, ES3Type_LayerMask.Instance);
			writer.WriteProperty("itemNameTemp", rocketMount.itemNameTemp, ES3TypeMgr.GetOrCreateES3Type(typeof(LocalizedString)));
			writer.WriteProperty("itemName", rocketMount.itemName, ES3Type_string.Instance);
			writer.WritePropertyByRef("mainImage", rocketMount.mainImage);
			writer.WriteProperty("value", rocketMount.value, ES3Type_float.Instance);
			writer.WriteProperty("canGrab", rocketMount.canGrab, ES3Type_bool.Instance);
			writer.WritePropertyByRef("outLine", rocketMount.outLine);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			RocketMount rocketMount = (RocketMount)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "rocketMount":
					rocketMount.rocketMount = reader.Read<Transform>(ES3Type_Transform.Instance);
					break;
				case "rocketReady":
					rocketMount = (RocketMount)reader.SetPrivateField("rocketReady", reader.Read<GameObject>(), rocketMount);
					break;
				case "isRocketMounted":
					rocketMount = (RocketMount)reader.SetPrivateField("isRocketMounted", reader.Read<bool>(), rocketMount);
					break;
				case "rocketType":
					rocketMount.rocketType = reader.Read<RocketType>();
					break;
				case "usable":
					rocketMount.usable = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "furnitureGO":
					rocketMount.furnitureGO = reader.Read<GameObject>(ES3Type_GameObject.Instance);
					break;
				case "description":
					rocketMount.description = reader.Read<LocalizedString>();
					break;
				case "size":
					rocketMount.size = reader.Read<Vector3>(ES3Type_Vector3.Instance);
					break;
				case "installableLayerMask":
					rocketMount.installableLayerMask = reader.Read<LayerMask>(ES3Type_LayerMask.Instance);
					break;
				case "itemNameTemp":
					rocketMount.itemNameTemp = reader.Read<LocalizedString>();
					break;
				case "itemName":
					rocketMount.itemName = reader.Read<string>(ES3Type_string.Instance);
					break;
				case "mainImage":
					rocketMount.mainImage = reader.Read<Sprite>(ES3Type_Sprite.Instance);
					break;
				case "value":
					rocketMount.value = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "canGrab":
					rocketMount.canGrab = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "outLine":
					rocketMount.outLine = reader.Read<Outline>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
