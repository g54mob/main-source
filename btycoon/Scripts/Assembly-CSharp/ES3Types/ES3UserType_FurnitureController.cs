using CTS;
using CTS.Core.Utilities;
using CTS.GridSystem;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "CurrentGridLayer", "CurrentSlot" })]
	public class ES3UserType_FurnitureController : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_FurnitureController()
			: base(typeof(FurnitureController))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			FurnitureController objectContainingProperty = (FurnitureController)obj;
			writer.WritePrivateProperty("CurrentGridLayer", objectContainingProperty);
			writer.WritePrivatePropertyByRef("CurrentSlot", objectContainingProperty);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			FurnitureController furnitureController = (FurnitureController)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "CurrentGridLayer"))
				{
					if (property == "CurrentSlot")
					{
						furnitureController = (FurnitureController)reader.SetPrivateProperty("CurrentSlot", reader.Read<FurnitureSlot>(), furnitureController);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					furnitureController = (FurnitureController)reader.SetPrivateProperty("CurrentGridLayer", reader.Read<GridLayer>(), furnitureController);
				}
			}
			reader.SetPrivateField("IsPlaced".ToBackingField(), true, furnitureController);
			furnitureController.SetPreviousData();
		}
	}
}
