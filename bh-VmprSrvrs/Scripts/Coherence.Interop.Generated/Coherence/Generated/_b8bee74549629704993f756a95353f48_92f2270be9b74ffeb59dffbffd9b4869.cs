using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b8bee74549629704993f756a95353f48_92f2270be9b74ffeb59dffbffd9b4869 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b8bee74549629704993f756a95353f48_92f2270be9b74ffeb59dffbffd9b4869 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b8bee74549629704993f756a95353f48_92f2270be9b74ffeb59dffbffd9b4869);
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

		public static void Serialize(_b8bee74549629704993f756a95353f48_92f2270be9b74ffeb59dffbffd9b4869 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b8bee74549629704993f756a95353f48_92f2270be9b74ffeb59dffbffd9b4869 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b8bee74549629704993f756a95353f48_92f2270be9b74ffeb59dffbffd9b4869);
		}
	}
}
