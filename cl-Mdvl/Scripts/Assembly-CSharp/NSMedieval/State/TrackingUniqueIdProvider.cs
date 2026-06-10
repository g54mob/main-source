using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Serialization;

namespace NSMedieval.State
{
	[FVSerializableKey("TrackingUniqueIdProvider", "")]
	public class TrackingUniqueIdProvider : IFVSerializable
	{
		private int nextId;

		private Queue<int> availableIds;

		private HashSet<int> usedIds;

		public TrackingUniqueIdProvider()
		{
			nextId = 0;
			availableIds = new Queue<int>();
			usedIds = new HashSet<int>();
		}

		public TrackingUniqueIdProvider(FVDeserializer deserializer)
		{
			nextId = deserializer.ReadInt("nextId");
			availableIds = deserializer.ReadIntQueue("availableIds");
			usedIds = deserializer.ReadIntHashSet("usedIds");
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("nextId", nextId);
			serializer.Write("availableIds", availableIds);
			serializer.Write("usedIds", usedIds);
		}

		public void SetNextId(int nextId)
		{
			this.nextId = nextId;
		}

		public int GetUniqueId()
		{
			int num;
			do
			{
				num = ++nextId;
			}
			while (usedIds.Contains(num));
			usedIds.Add(num);
			return num;
		}

		public void AddUsedId(int id)
		{
			if (id != 0)
			{
				usedIds.Add(id);
			}
		}

		public void ReleaseId(int id)
		{
			if (usedIds.Contains(id))
			{
				usedIds.Remove(id);
				return;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Common\\TrackingUniqueIdProvider.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Tried to release ID ");
				messageBuilder.AppendFormatted(id);
				messageBuilder.AppendLiteral(", but it is not in use");
			}
			Log.Debug(messageBuilder);
		}
	}
}
