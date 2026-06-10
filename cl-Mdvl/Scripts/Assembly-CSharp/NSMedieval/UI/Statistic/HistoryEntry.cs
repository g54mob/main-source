using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.UI.Statistic
{
	[Serializable]
	[FVSerializableKey("HistoryEntry", "")]
	public class HistoryEntry : IFVSerializable
	{
		[SerializeField]
		private int id;

		[SerializeField]
		private string typeText;

		[SerializeField]
		private string titleText;

		[SerializeField]
		private string detailsText;

		[SerializeField]
		private string date;

		public string TitleText => titleText;

		public string DetailsText => detailsText;

		public int ID => id;

		public string Date => date;

		public string TypeText => typeText;

		public HistoryEntry(int id, string typeText, string entryTitleText, string entryDetailsText, string date)
		{
			this.id = id;
			this.typeText = typeText;
			titleText = entryTitleText;
			detailsText = entryDetailsText;
			this.date = date;
		}

		public HistoryEntry()
		{
		}

		public void AppendDetails(string detailsToAppend)
		{
			detailsText += detailsToAppend;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("typeText", typeText);
			serializer.Write("titleText", titleText);
			serializer.Write("detailsText", detailsText);
			serializer.Write("date", date);
		}

		public HistoryEntry(FVDeserializer deserializer)
		{
			id = deserializer.ReadInt("id");
			typeText = deserializer.ReadString("typeText");
			titleText = deserializer.ReadString("titleText");
			detailsText = deserializer.ReadString("detailsText");
			date = deserializer.ReadString("date");
		}
	}
}
