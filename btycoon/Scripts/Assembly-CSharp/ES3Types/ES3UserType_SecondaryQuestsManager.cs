using System.Collections.Generic;
using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_availableSecondaryQuests", "_refusedSecondaryQuests", "_acceptedSecondaryQuests", "_timers", "_failTimers", "_reservedQuests" })]
	public class ES3UserType_SecondaryQuestsManager : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_SecondaryQuestsManager()
			: base(typeof(SecondaryQuestsManager))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			SecondaryQuestsManager objectContainingField = (SecondaryQuestsManager)obj;
			writer.WritePrivateField("_availableSecondaryQuests", objectContainingField);
			writer.WritePrivateField("_refusedSecondaryQuests", objectContainingField);
			writer.WritePrivateField("_acceptedSecondaryQuests", objectContainingField);
			writer.WritePrivateField("_timers", objectContainingField);
			writer.WritePrivateField("_failTimers", objectContainingField);
			writer.WritePrivateField("_reservedQuests", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			SecondaryQuestsManager objectContainingField = (SecondaryQuestsManager)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_availableSecondaryQuests":
					objectContainingField = (SecondaryQuestsManager)reader.SetPrivateField("_availableSecondaryQuests", reader.Read<List<string>>(), objectContainingField);
					break;
				case "_refusedSecondaryQuests":
					objectContainingField = (SecondaryQuestsManager)reader.SetPrivateField("_refusedSecondaryQuests", reader.Read<List<string>>(), objectContainingField);
					break;
				case "_acceptedSecondaryQuests":
					objectContainingField = (SecondaryQuestsManager)reader.SetPrivateField("_acceptedSecondaryQuests", reader.Read<List<string>>(), objectContainingField);
					break;
				case "_timers":
					objectContainingField = (SecondaryQuestsManager)reader.SetPrivateField("_timers", reader.Read<Dictionary<AssetRef<MapInfoSO>, float>>(), objectContainingField);
					break;
				case "_failTimers":
					objectContainingField = (SecondaryQuestsManager)reader.SetPrivateField("_failTimers", reader.Read<Dictionary<string, float>>(), objectContainingField);
					break;
				case "_reservedQuests":
					objectContainingField = (SecondaryQuestsManager)reader.SetPrivateField("_reservedQuests", reader.Read<Dictionary<string, AssetRef<MapInfoSO>>>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
