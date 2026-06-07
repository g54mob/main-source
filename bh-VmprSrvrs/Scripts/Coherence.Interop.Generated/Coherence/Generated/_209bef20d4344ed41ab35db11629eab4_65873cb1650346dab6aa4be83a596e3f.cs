using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _209bef20d4344ed41ab35db11629eab4_65873cb1650346dab6aa4be83a596e3f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _209bef20d4344ed41ab35db11629eab4_65873cb1650346dab6aa4be83a596e3f FromInterop(IntPtr data, int dataSize)
		{
			return default(_209bef20d4344ed41ab35db11629eab4_65873cb1650346dab6aa4be83a596e3f);
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

		public static void Serialize(_209bef20d4344ed41ab35db11629eab4_65873cb1650346dab6aa4be83a596e3f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _209bef20d4344ed41ab35db11629eab4_65873cb1650346dab6aa4be83a596e3f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_209bef20d4344ed41ab35db11629eab4_65873cb1650346dab6aa4be83a596e3f);
		}
	}
}
