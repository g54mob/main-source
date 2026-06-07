using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _99bbdbd1ce167d240a740fa0a7532924_2080d0ac9b784d16a83bd51bc0e4c866 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _99bbdbd1ce167d240a740fa0a7532924_2080d0ac9b784d16a83bd51bc0e4c866 FromInterop(IntPtr data, int dataSize)
		{
			return default(_99bbdbd1ce167d240a740fa0a7532924_2080d0ac9b784d16a83bd51bc0e4c866);
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

		public static void Serialize(_99bbdbd1ce167d240a740fa0a7532924_2080d0ac9b784d16a83bd51bc0e4c866 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _99bbdbd1ce167d240a740fa0a7532924_2080d0ac9b784d16a83bd51bc0e4c866 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_99bbdbd1ce167d240a740fa0a7532924_2080d0ac9b784d16a83bd51bc0e4c866);
		}
	}
}
