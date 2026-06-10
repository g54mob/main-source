using System;
using NSMedieval.Serialization;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Dictionary
{
	[Serializable]
	[FVSerializableKey("JobTypeIntDictionary", "")]
	public class JobTypeIntDictionary : SerializableDictionary<JobType, int>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.WriteEnum("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public JobTypeIntDictionary()
		{
		}

		public JobTypeIntDictionary(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadEnumArray<JobType>("keys");
			base.Values = deserializer.ReadIntArray("values");
			OnAfterDeserialize();
		}
	}
}
