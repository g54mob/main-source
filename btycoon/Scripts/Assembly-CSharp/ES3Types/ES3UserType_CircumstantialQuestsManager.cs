using System.Collections.Generic;
using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_reservedQuests" })]
	public class ES3UserType_CircumstantialQuestsManager : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_CircumstantialQuestsManager()
			: base(typeof(CircumstantialQuestsManager))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			CircumstantialQuestsManager objectContainingField = (CircumstantialQuestsManager)obj;
			writer.WritePrivateField("_reservedQuests", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			CircumstantialQuestsManager objectContainingField = (CircumstantialQuestsManager)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_reservedQuests")
				{
					objectContainingField = (CircumstantialQuestsManager)reader.SetPrivateField("_reservedQuests", reader.Read<Dictionary<string, AssetRef<MapInfoSO>>>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
