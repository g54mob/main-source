using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a2bda7ab6fb525d41b33b10e085ca5e3_b93053dcf8bd4f8fa55ed3e35703d191 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte eraseItems;

			[FieldOffset(1)]
			public byte skipTriggers;
		}

		public bool eraseItems;

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a2bda7ab6fb525d41b33b10e085ca5e3_b93053dcf8bd4f8fa55ed3e35703d191 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a2bda7ab6fb525d41b33b10e085ca5e3_b93053dcf8bd4f8fa55ed3e35703d191);
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

		public _a2bda7ab6fb525d41b33b10e085ca5e3_b93053dcf8bd4f8fa55ed3e35703d191(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a2bda7ab6fb525d41b33b10e085ca5e3_b93053dcf8bd4f8fa55ed3e35703d191 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a2bda7ab6fb525d41b33b10e085ca5e3_b93053dcf8bd4f8fa55ed3e35703d191 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a2bda7ab6fb525d41b33b10e085ca5e3_b93053dcf8bd4f8fa55ed3e35703d191);
		}
	}
}
