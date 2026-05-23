using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "stolen", "lockedTimer" })]
	public class ES3UserType_Grocery : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Grocery()
			: base(typeof(Grocery))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Grocery grocery = (Grocery)obj;
			writer.WriteProperty("stolen", grocery.stolen, ES3Type_bool.Instance);
			writer.WritePrivateField("lockedTimer", grocery);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Grocery grocery = (Grocery)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "stolen"))
				{
					if (property == "lockedTimer")
					{
						grocery = (Grocery)reader.SetPrivateField("lockedTimer", reader.Read<float>(), grocery);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					grocery.stolen = reader.Read<bool>(ES3Type_bool.Instance);
				}
			}
		}
	}
}
