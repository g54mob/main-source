using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _23393d944e5bef54f97cb0ddc356e091_7171d54e7ac847349abd77d8375a72b4 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _23393d944e5bef54f97cb0ddc356e091_7171d54e7ac847349abd77d8375a72b4 FromInterop(IntPtr data, int dataSize)
		{
			return default(_23393d944e5bef54f97cb0ddc356e091_7171d54e7ac847349abd77d8375a72b4);
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

		public static void Serialize(_23393d944e5bef54f97cb0ddc356e091_7171d54e7ac847349abd77d8375a72b4 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _23393d944e5bef54f97cb0ddc356e091_7171d54e7ac847349abd77d8375a72b4 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_23393d944e5bef54f97cb0ddc356e091_7171d54e7ac847349abd77d8375a72b4);
		}
	}
}
