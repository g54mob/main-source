using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _92729ef983562154daa0c0af37464b19_158c5a7346c04ea2978fc91257c7c2c1 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _92729ef983562154daa0c0af37464b19_158c5a7346c04ea2978fc91257c7c2c1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_92729ef983562154daa0c0af37464b19_158c5a7346c04ea2978fc91257c7c2c1);
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

		public static void Serialize(_92729ef983562154daa0c0af37464b19_158c5a7346c04ea2978fc91257c7c2c1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _92729ef983562154daa0c0af37464b19_158c5a7346c04ea2978fc91257c7c2c1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_92729ef983562154daa0c0af37464b19_158c5a7346c04ea2978fc91257c7c2c1);
		}
	}
}
