using Suburb;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "objectOpen", "locked" })]
	public class ES3UserType_SimpleOpenClose : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_SimpleOpenClose()
			: base(typeof(SimpleOpenClose))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			SimpleOpenClose simpleOpenClose = (SimpleOpenClose)obj;
			writer.WriteProperty("objectOpen", simpleOpenClose.objectOpen, ES3Type_bool.Instance);
			writer.WriteProperty("locked", simpleOpenClose.locked, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			SimpleOpenClose simpleOpenClose = (SimpleOpenClose)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "objectOpen"))
				{
					if (property == "locked")
					{
						simpleOpenClose.locked = reader.Read<bool>(ES3Type_bool.Instance);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					simpleOpenClose.objectOpen = reader.Read<bool>(ES3Type_bool.Instance);
				}
			}
		}
	}
}
