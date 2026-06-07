using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _af6505b3805b9c5449b68712394f0392_8866cc864e384142b7254a9d90ca7c1c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public int weaponType;

			[FieldOffset(12)]
			public float value;
		}

		public long startingSimFrame;

		public int weaponType;

		public float value;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _af6505b3805b9c5449b68712394f0392_8866cc864e384142b7254a9d90ca7c1c FromInterop(IntPtr data, int dataSize)
		{
			return default(_af6505b3805b9c5449b68712394f0392_8866cc864e384142b7254a9d90ca7c1c);
		}

		public uint GetComponentType()
		{
			return 0u;
		}

		public IEntityMessage Clone()
		{
			return null;
		}

		public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Logger logger)
		{
			return default(IEntityMapper.Error);
		}

		public IEntityMapper.Error MapToRelative(IEntityMapper mapper, Logger logger)
		{
			return default(IEntityMapper.Error);
		}

		public HashSet<Entity> GetEntityRefs()
		{
			return null;
		}

		public void NullEntityRefs(Entity entity)
		{
		}

		public _af6505b3805b9c5449b68712394f0392_8866cc864e384142b7254a9d90ca7c1c(Entity entity, long startingSimFrame, int weaponType, float value)
		{
			this.startingSimFrame = 0L;
			this.weaponType = 0;
			this.value = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_af6505b3805b9c5449b68712394f0392_8866cc864e384142b7254a9d90ca7c1c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _af6505b3805b9c5449b68712394f0392_8866cc864e384142b7254a9d90ca7c1c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_af6505b3805b9c5449b68712394f0392_8866cc864e384142b7254a9d90ca7c1c);
		}
	}
}
