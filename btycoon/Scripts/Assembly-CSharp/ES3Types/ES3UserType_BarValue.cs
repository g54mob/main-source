using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_totalFurnituresValue", "_totalSuperficyValue", "_totalBuildableValue", "_totalPaintValue" })]
	public class ES3UserType_BarValue : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_BarValue()
			: base(typeof(BarValue))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BarValue objectContainingField = (BarValue)obj;
			writer.WritePrivateField("_totalFurnituresValue", objectContainingField);
			writer.WritePrivateField("_totalSuperficyValue", objectContainingField);
			writer.WritePrivateField("_totalBuildableValue", objectContainingField);
			writer.WritePrivateField("_totalPaintValue", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BarValue objectContainingField = (BarValue)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_totalFurnituresValue":
					objectContainingField = (BarValue)reader.SetPrivateField("_totalFurnituresValue", reader.Read<float>(), objectContainingField);
					break;
				case "_totalSuperficyValue":
					objectContainingField = (BarValue)reader.SetPrivateField("_totalSuperficyValue", reader.Read<float>(), objectContainingField);
					break;
				case "_totalBuildableValue":
					objectContainingField = (BarValue)reader.SetPrivateField("_totalBuildableValue", reader.Read<float>(), objectContainingField);
					break;
				case "_totalPaintValue":
					objectContainingField = (BarValue)reader.SetPrivateField("_totalPaintValue", reader.Read<float>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
