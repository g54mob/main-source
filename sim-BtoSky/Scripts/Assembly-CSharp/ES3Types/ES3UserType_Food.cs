using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "hungerGain", "knowledgeGain", "value" })]
	public class ES3UserType_Food : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Food()
			: base(typeof(Food))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Food food = (Food)obj;
			writer.WriteProperty("hungerGain", food.hungerGain, ES3Type_float.Instance);
			writer.WriteProperty("knowledgeGain", food.knowledgeGain, ES3Type_int.Instance);
			writer.WriteProperty("value", food.value, ES3Type_float.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Food food = (Food)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "hungerGain":
					food.hungerGain = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "knowledgeGain":
					food.knowledgeGain = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "value":
					food.value = reader.Read<float>(ES3Type_float.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
