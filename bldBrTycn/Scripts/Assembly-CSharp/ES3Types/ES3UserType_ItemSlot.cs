using CTS;
using CTS.BBT;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "InUse", "InSlot" })]
	public class ES3UserType_ItemSlot : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_ItemSlot()
			: base(typeof(ItemSlot))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			ItemSlot objectContainingProperty = (ItemSlot)obj;
			writer.WritePrivateProperty("InUse", objectContainingProperty);
			writer.WritePrivatePropertyByRef("InSlot", objectContainingProperty);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			ItemSlot objectContainingProperty = (ItemSlot)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "InUse"))
				{
					if (property == "InSlot")
					{
						objectContainingProperty = (ItemSlot)reader.SetPrivateProperty("InSlot", reader.Read<Item>(), objectContainingProperty);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					objectContainingProperty = (ItemSlot)reader.SetPrivateProperty("InUse", reader.Read<bool>(), objectContainingProperty);
				}
			}
		}
	}
}
