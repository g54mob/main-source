using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ef2214f8cc656a241ba83becae6a65f4_1f31fecead5549a88b9db83cc6176596 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ef2214f8cc656a241ba83becae6a65f4_1f31fecead5549a88b9db83cc6176596 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ef2214f8cc656a241ba83becae6a65f4_1f31fecead5549a88b9db83cc6176596);
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

		public static void Serialize(_ef2214f8cc656a241ba83becae6a65f4_1f31fecead5549a88b9db83cc6176596 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ef2214f8cc656a241ba83becae6a65f4_1f31fecead5549a88b9db83cc6176596 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ef2214f8cc656a241ba83becae6a65f4_1f31fecead5549a88b9db83cc6176596);
		}
	}
}
