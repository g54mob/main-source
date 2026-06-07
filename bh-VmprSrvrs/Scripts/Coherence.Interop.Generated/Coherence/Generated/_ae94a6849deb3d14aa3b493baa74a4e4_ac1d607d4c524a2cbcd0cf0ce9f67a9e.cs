using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ae94a6849deb3d14aa3b493baa74a4e4_ac1d607d4c524a2cbcd0cf0ce9f67a9e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ae94a6849deb3d14aa3b493baa74a4e4_ac1d607d4c524a2cbcd0cf0ce9f67a9e FromInterop(IntPtr data, int dataSize)
		{
			return default(_ae94a6849deb3d14aa3b493baa74a4e4_ac1d607d4c524a2cbcd0cf0ce9f67a9e);
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

		public static void Serialize(_ae94a6849deb3d14aa3b493baa74a4e4_ac1d607d4c524a2cbcd0cf0ce9f67a9e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ae94a6849deb3d14aa3b493baa74a4e4_ac1d607d4c524a2cbcd0cf0ce9f67a9e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ae94a6849deb3d14aa3b493baa74a4e4_ac1d607d4c524a2cbcd0cf0ce9f67a9e);
		}
	}
}
