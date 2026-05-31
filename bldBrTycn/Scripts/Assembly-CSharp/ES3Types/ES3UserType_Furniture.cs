using CTS;
using CTS.BBT;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "Parameters", "Slots" })]
	public class ES3UserType_Furniture : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Furniture()
			: base(typeof(Furniture))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Furniture furniture = (Furniture)obj;
			writer.WriteAssetReference("Parameters", furniture.Parameters);
			writer.WriteList("Slot", furniture.Slots, ES3.ReferenceMode.ByRef);
			if ((bool)furniture.Controller)
			{
				FurnitureController controller = furniture.Controller;
				if ((bool)controller.CurrentSlot)
				{
					writer.WritePropertyByRef("CurrentSlot", controller.CurrentSlot);
				}
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Furniture furniture = (Furniture)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "CurrentSlot"))
				{
					if (property == "Parameters")
					{
						reader.SetPrivateProperty("Parameters", reader.ReadAssetReference<FurnitureSO>(), furniture);
					}
					else if (!reader.TryReadIntoArray(property, "Slot", furniture.Slots))
					{
						reader.Skip();
					}
					continue;
				}
				FurnitureSlot furnitureSlot = reader.Read<FurnitureSlot>();
				if ((bool)furnitureSlot)
				{
					reader.SetPrivateField("CurrentSlot".ToBackingField(), furnitureSlot, furniture.Controller);
					reader.SetPrivateField("SlotedFurniture".ToBackingField(), furniture.Controller, furnitureSlot);
					Transform transform = furniture.transform;
					if (transform.parent != furnitureSlot.transform)
					{
						transform.SetPositionAndRotation(furnitureSlot.transform);
						transform.SetParent(furnitureSlot.transform);
					}
				}
			}
			if ((bool)furniture.Controller)
			{
				if ((bool)furniture.Parameters)
				{
					furniture.Controller.SetupSelectableObject();
				}
				reader.SetPrivateField("IsPlaced".ToBackingField(), true, furniture.Controller);
				furniture.Controller.SetPreviousData();
			}
			reader.SetPrivateField("Purchased".ToBackingField(), true, furniture);
		}
	}
}
