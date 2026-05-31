using System.Collections.Generic;
using CTS;
using CTS.BBT;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_gifted", "_chairs" })]
	public class ES3UserType_MainQuest20 : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest20()
			: base(typeof(MainQuest20))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MainQuest20 objectContainingField = (MainQuest20)obj;
			writer.WritePrivateField("_gifted", objectContainingField);
			writer.WritePrivateField("_chairs", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MainQuest20 objectContainingField = (MainQuest20)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "_gifted"))
				{
					if (property == "_chairs")
					{
						objectContainingField = (MainQuest20)reader.SetPrivateField("_chairs", reader.Read<List<Furniture>>(), objectContainingField);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					objectContainingField = (MainQuest20)reader.SetPrivateField("_gifted", reader.Read<bool>(), objectContainingField);
				}
			}
		}
	}
}
