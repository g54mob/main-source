using System;
using NSMedieval.Enums;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	[FVSerializableKey("LocKeys", "")]
	public class LocKeys : IFVSerializable
	{
		[SerializeField]
		private string languageName;

		[SerializeField]
		private string name;

		[SerializeField]
		private string info;

		[SerializeField]
		private string description;

		[SerializeField]
		private string type;

		[SerializeField]
		private string[] tooltipLines;

		[SerializeField]
		private string[] tooltipNotes;

		[SerializeField]
		private string[] variations;

		public string LanguageName => languageName;

		public string Name => name ?? string.Empty;

		public string Info => info ?? string.Empty;

		public string Description => description ?? string.Empty;

		public string Type => type ?? string.Empty;

		public string[] TooltipNotes => tooltipNotes;

		public string[] TooltipLines => tooltipLines;

		public string[] Variations => variations;

		public LocKeys(string languageName, string name, string info, string description)
		{
			this.languageName = languageName;
			this.name = name;
			this.info = info;
			this.description = description;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("languageName", languageName);
			serializer.Write("name", name);
			serializer.Write("info", info);
			serializer.Write("description", description);
			serializer.Write("type", type);
			serializer.Write("tooltipLines", tooltipLines);
			serializer.Write("tooltipNotes", tooltipNotes);
			serializer.Write("variations", variations);
		}

		public LocKeys(FVDeserializer deserializer)
		{
			languageName = deserializer.ReadString("name");
			name = deserializer.ReadString("name");
			info = deserializer.ReadString("info");
			description = deserializer.ReadString("description");
			type = deserializer.ReadString("type");
			tooltipLines = deserializer.ReadStringArray("tooltipLines");
			tooltipNotes = deserializer.ReadStringArray("tooltipNotes");
			variations = deserializer.ReadStringArray("variations");
			HandleMissingLanguageName(deserializer);
		}

		private void HandleMissingLanguageName(FVDeserializer deserializer)
		{
			if (string.IsNullOrEmpty(languageName))
			{
				languageName = deserializer.ReadEnum("language", Language.None).ToString();
			}
		}
	}
}
