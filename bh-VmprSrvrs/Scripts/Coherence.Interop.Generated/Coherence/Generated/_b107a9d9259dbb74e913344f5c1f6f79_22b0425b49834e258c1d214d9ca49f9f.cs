using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b107a9d9259dbb74e913344f5c1f6f79_22b0425b49834e258c1d214d9ca49f9f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b107a9d9259dbb74e913344f5c1f6f79_22b0425b49834e258c1d214d9ca49f9f FromInterop(IntPtr data, int dataSize)
		{
			return default(_b107a9d9259dbb74e913344f5c1f6f79_22b0425b49834e258c1d214d9ca49f9f);
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

		public _b107a9d9259dbb74e913344f5c1f6f79_22b0425b49834e258c1d214d9ca49f9f(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_b107a9d9259dbb74e913344f5c1f6f79_22b0425b49834e258c1d214d9ca49f9f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b107a9d9259dbb74e913344f5c1f6f79_22b0425b49834e258c1d214d9ca49f9f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b107a9d9259dbb74e913344f5c1f6f79_22b0425b49834e258c1d214d9ca49f9f);
		}
	}
}
