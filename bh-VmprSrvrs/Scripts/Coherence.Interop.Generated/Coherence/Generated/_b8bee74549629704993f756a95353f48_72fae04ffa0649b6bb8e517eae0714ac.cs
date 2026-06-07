using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b8bee74549629704993f756a95353f48_72fae04ffa0649b6bb8e517eae0714ac : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b8bee74549629704993f756a95353f48_72fae04ffa0649b6bb8e517eae0714ac FromInterop(IntPtr data, int dataSize)
		{
			return default(_b8bee74549629704993f756a95353f48_72fae04ffa0649b6bb8e517eae0714ac);
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

		public _b8bee74549629704993f756a95353f48_72fae04ffa0649b6bb8e517eae0714ac(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_b8bee74549629704993f756a95353f48_72fae04ffa0649b6bb8e517eae0714ac commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b8bee74549629704993f756a95353f48_72fae04ffa0649b6bb8e517eae0714ac Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b8bee74549629704993f756a95353f48_72fae04ffa0649b6bb8e517eae0714ac);
		}
	}
}
