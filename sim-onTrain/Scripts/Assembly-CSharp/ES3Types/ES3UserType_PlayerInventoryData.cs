using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_PlayerInventoryData : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_PlayerInventoryData()
			: base(typeof(PlayerInventoryData))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			_ = (PlayerInventoryData)obj;
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			_ = (PlayerInventoryData)obj;
			foreach (string property in reader.Properties)
			{
				_ = property;
				reader.Skip();
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			PlayerInventoryData playerInventoryData = new PlayerInventoryData();
			ReadObject<T>(reader, playerInventoryData);
			return playerInventoryData;
		}
	}
}
