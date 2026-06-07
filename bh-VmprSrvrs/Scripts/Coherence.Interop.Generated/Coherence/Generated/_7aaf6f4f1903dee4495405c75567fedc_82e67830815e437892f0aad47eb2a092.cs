using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7aaf6f4f1903dee4495405c75567fedc_82e67830815e437892f0aad47eb2a092 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity player;
		}

		public long startingSimFrame;

		public Entity player;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7aaf6f4f1903dee4495405c75567fedc_82e67830815e437892f0aad47eb2a092 FromInterop(IntPtr data, int dataSize)
		{
			return default(_7aaf6f4f1903dee4495405c75567fedc_82e67830815e437892f0aad47eb2a092);
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

		public _7aaf6f4f1903dee4495405c75567fedc_82e67830815e437892f0aad47eb2a092(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_7aaf6f4f1903dee4495405c75567fedc_82e67830815e437892f0aad47eb2a092 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7aaf6f4f1903dee4495405c75567fedc_82e67830815e437892f0aad47eb2a092 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7aaf6f4f1903dee4495405c75567fedc_82e67830815e437892f0aad47eb2a092);
		}
	}
}
