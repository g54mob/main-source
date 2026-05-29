using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "<SaveOrder>k__BackingField", "<LoadInitOrder>k__BackingField", "<LoadPostOrder>k__BackingField" })]
	public class ES3UserType_SaveFinanceGraph : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_SaveFinanceGraph()
			: base(typeof(SaveFinanceGraph))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			SaveFinanceGraph objectContainingField = (SaveFinanceGraph)obj;
			writer.WritePrivateField("<SaveOrder>k__BackingField", objectContainingField);
			writer.WritePrivateField("<LoadInitOrder>k__BackingField", objectContainingField);
			writer.WritePrivateField("<LoadPostOrder>k__BackingField", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			SaveFinanceGraph objectContainingField = (SaveFinanceGraph)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "<SaveOrder>k__BackingField":
					objectContainingField = (SaveFinanceGraph)reader.SetPrivateField("<SaveOrder>k__BackingField", reader.Read<int>(), objectContainingField);
					break;
				case "<LoadInitOrder>k__BackingField":
					objectContainingField = (SaveFinanceGraph)reader.SetPrivateField("<LoadInitOrder>k__BackingField", reader.Read<int>(), objectContainingField);
					break;
				case "<LoadPostOrder>k__BackingField":
					objectContainingField = (SaveFinanceGraph)reader.SetPrivateField("<LoadPostOrder>k__BackingField", reader.Read<int>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
