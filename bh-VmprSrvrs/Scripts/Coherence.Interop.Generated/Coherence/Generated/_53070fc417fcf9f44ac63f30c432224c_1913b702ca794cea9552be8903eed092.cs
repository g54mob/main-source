using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _53070fc417fcf9f44ac63f30c432224c_1913b702ca794cea9552be8903eed092 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity requestingPlayer;
		}

		public long startingSimFrame;

		public Entity requestingPlayer;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _53070fc417fcf9f44ac63f30c432224c_1913b702ca794cea9552be8903eed092 FromInterop(IntPtr data, int dataSize)
		{
			return default(_53070fc417fcf9f44ac63f30c432224c_1913b702ca794cea9552be8903eed092);
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

		public _53070fc417fcf9f44ac63f30c432224c_1913b702ca794cea9552be8903eed092(Entity entity, long startingSimFrame, Entity requestingPlayer)
		{
			this.startingSimFrame = 0L;
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_53070fc417fcf9f44ac63f30c432224c_1913b702ca794cea9552be8903eed092 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _53070fc417fcf9f44ac63f30c432224c_1913b702ca794cea9552be8903eed092 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_53070fc417fcf9f44ac63f30c432224c_1913b702ca794cea9552be8903eed092);
		}
	}
}
