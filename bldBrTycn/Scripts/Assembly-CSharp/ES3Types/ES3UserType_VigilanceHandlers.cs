using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "CurrentVigilance" })]
	public class ES3UserType_VigilanceHandlers : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_VigilanceHandlers()
			: base(typeof(VigilanceHandlers))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			VigilanceHandlers objectContainingProperty = (VigilanceHandlers)obj;
			writer.WritePrivateProperty("CurrentVigilance", objectContainingProperty);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			VigilanceHandlers objectContainingProperty = (VigilanceHandlers)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "CurrentVigilance")
				{
					objectContainingProperty = (VigilanceHandlers)reader.SetPrivateProperty("CurrentVigilance", reader.Read<int>(), objectContainingProperty);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
