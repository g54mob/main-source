using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Components.Base
{
	[Serializable]
	[FVSerializableKey("StorageBase", "")]
	public struct StorageBase : IFVSerializable
	{
		public const int DefaultStorageCapacity = 999;

		[SerializeField]
		private int capacity;

		[SerializeField]
		private bool ignoreWeigth;

		[SerializeField]
		private bool infinite;

		public int Capacity => capacity;

		public bool IgnoreWeigth => ignoreWeigth;

		public bool Infinite => infinite;

		public StorageBase(int capacity, bool ignoreWeigth = false, bool infinite = false)
		{
			this.capacity = capacity;
			this.ignoreWeigth = ignoreWeigth;
			this.infinite = infinite;
		}

		public void SetCapacity(int capacity)
		{
			this.capacity = capacity;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("capacity", capacity);
			serializer.Write("ignoreWeigth", ignoreWeigth);
			serializer.Write("infinite", infinite);
		}

		public StorageBase(FVDeserializer deserializer)
		{
			capacity = deserializer.ReadInt("capacity", -1);
			ignoreWeigth = deserializer.ReadBool("ignoreWeigth");
			infinite = deserializer.ReadBool("infinite");
			if (capacity <= 0)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\Base\\StorageBase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Storage capacity is ");
					messageBuilder.AppendFormatted(capacity);
					messageBuilder.AppendLiteral(" during loading. This should never happen!");
				}
				Log.Warning(messageBuilder);
				capacity = 999;
			}
		}
	}
}
