using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "canGrab" })]
	public class ES3UserType_Item : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Item()
			: base(typeof(Item))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Item item = (Item)obj;
			writer.WriteProperty("canGrab", item.canGrab, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Item item = (Item)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "canGrab")
				{
					item.canGrab = reader.Read<bool>(ES3Type_bool.Instance);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
