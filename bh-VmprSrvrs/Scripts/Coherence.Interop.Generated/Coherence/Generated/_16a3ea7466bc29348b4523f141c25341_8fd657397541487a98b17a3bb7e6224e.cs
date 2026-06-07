using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _16a3ea7466bc29348b4523f141c25341_8fd657397541487a98b17a3bb7e6224e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _16a3ea7466bc29348b4523f141c25341_8fd657397541487a98b17a3bb7e6224e FromInterop(IntPtr data, int dataSize)
		{
			return default(_16a3ea7466bc29348b4523f141c25341_8fd657397541487a98b17a3bb7e6224e);
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

		public static void Serialize(_16a3ea7466bc29348b4523f141c25341_8fd657397541487a98b17a3bb7e6224e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _16a3ea7466bc29348b4523f141c25341_8fd657397541487a98b17a3bb7e6224e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_16a3ea7466bc29348b4523f141c25341_8fd657397541487a98b17a3bb7e6224e);
		}
	}
}
