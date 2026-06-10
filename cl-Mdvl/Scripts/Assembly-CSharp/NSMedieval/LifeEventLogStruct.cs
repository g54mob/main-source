using System;
using System.Text.RegularExpressions;
using NSMedieval.Enums;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	[FVSerializableKey("LifeEventLogStruct", "")]
	public struct LifeEventLogStruct : IFVSerializable
	{
		[SerializeField]
		private LifeEventType type;

		[SerializeField]
		private string localizedLog;

		public LifeEventType Type => type;

		public string LocalizedLog => localizedLog;

		public LifeEventLogStruct(LifeEventType type, string localizedLog)
		{
			this.type = type;
			this.localizedLog = localizedLog;
		}

		public void AppendToLog(string localizedTextToAppend)
		{
			localizedLog = localizedLog + " " + localizedTextToAppend;
		}

		public string GetLocalizedLogWithoutSprites()
		{
			return Regex.Replace(LocalizedLog, "<sprite=[^\\n\\r>]*>", "").Trim();
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.WriteEnum("type", type);
			serializer.Write("localizedLog", localizedLog);
		}

		public LifeEventLogStruct(FVDeserializer deserializer)
		{
			type = deserializer.ReadEnum("type", LifeEventType.None);
			localizedLog = deserializer.ReadString("localizedLog");
		}
	}
}
