using System;
using Unity.Collections;

namespace Brewery.Systems
{
	internal readonly struct ProcessMetadataKey : IEquatable<ProcessMetadataKey>
	{
		public readonly ulong stationId;

		public readonly FixedString64Bytes metadataKey;

		public readonly FixedString64Bytes stepTypeName;

		public ProcessMetadataKey(ulong stationId, FixedString64Bytes metadataKey, FixedString64Bytes stepTypeName)
		{
			this.stationId = 0uL;
			this.metadataKey = default(FixedString64Bytes);
			this.stepTypeName = default(FixedString64Bytes);
		}

		public static ProcessMetadataKey Create<TStep>(ulong stationId, string key) where TStep : struct, Enum
		{
			return default(ProcessMetadataKey);
		}

		public bool Equals(ProcessMetadataKey other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
