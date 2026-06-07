using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3e13a6165d840b64197c2aef3355263e_68fd91788b254691aee90a775c6fdb28 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _3e13a6165d840b64197c2aef3355263e_68fd91788b254691aee90a775c6fdb28 FromInterop(IntPtr data, int dataSize)
		{
			return default(_3e13a6165d840b64197c2aef3355263e_68fd91788b254691aee90a775c6fdb28);
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

		public _3e13a6165d840b64197c2aef3355263e_68fd91788b254691aee90a775c6fdb28(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_3e13a6165d840b64197c2aef3355263e_68fd91788b254691aee90a775c6fdb28 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3e13a6165d840b64197c2aef3355263e_68fd91788b254691aee90a775c6fdb28 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3e13a6165d840b64197c2aef3355263e_68fd91788b254691aee90a775c6fdb28);
		}
	}
}
