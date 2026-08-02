using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "isOpened" })]
	public class ES3UserType_DoorBase : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_DoorBase()
			: base(typeof(DoorBase))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			DoorBase objectContainingField = (DoorBase)obj;
			writer.WritePrivateField("isOpened", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			DoorBase objectContainingField = (DoorBase)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "isOpened")
				{
					objectContainingField = (DoorBase)reader.SetPrivateField("isOpened", reader.Read<bool>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
