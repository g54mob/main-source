using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7938f2765629f1d48a3f666ccfd0b0a2_16e98fda4b084a68a49c9432fe4279bf : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7938f2765629f1d48a3f666ccfd0b0a2_16e98fda4b084a68a49c9432fe4279bf FromInterop(IntPtr data, int dataSize)
		{
			return default(_7938f2765629f1d48a3f666ccfd0b0a2_16e98fda4b084a68a49c9432fe4279bf);
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

		public static void Serialize(_7938f2765629f1d48a3f666ccfd0b0a2_16e98fda4b084a68a49c9432fe4279bf commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7938f2765629f1d48a3f666ccfd0b0a2_16e98fda4b084a68a49c9432fe4279bf Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7938f2765629f1d48a3f666ccfd0b0a2_16e98fda4b084a68a49c9432fe4279bf);
		}
	}
}
