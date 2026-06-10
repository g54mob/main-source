using System;
using System.Collections.Generic;
using NSMedieval.Serialization;
using NSMedieval.State;

namespace NSMedieval.Dialogs.Data
{
	[Serializable]
	[FVSerializableKey("TooltipData", "")]
	public class TooltipData : IFVSerializable
	{
		public HumanoidInstance Humanoid;

		public List<string> Args = new List<string>();

		public string Key;

		private const string fvs_worker = "worker";

		private const string fvs_args = "args";

		private const string fvs_key = "key";

		public TooltipData()
		{
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("worker", Humanoid);
			serializer.Write("args", Args);
			serializer.Write("key", Key);
		}

		public TooltipData(FVDeserializer deserializer)
		{
			Humanoid = deserializer.ReadObject<HumanoidInstance>("worker");
			Args = deserializer.ReadStringList("args");
			Key = deserializer.ReadString("key");
		}
	}
}
