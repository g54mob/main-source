using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _cb6340e86c15b7a4d9dc09805e38365e_f01e98cfc5c3454f8f38ad12a63350b7 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _cb6340e86c15b7a4d9dc09805e38365e_f01e98cfc5c3454f8f38ad12a63350b7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_cb6340e86c15b7a4d9dc09805e38365e_f01e98cfc5c3454f8f38ad12a63350b7);
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

		public static void Serialize(_cb6340e86c15b7a4d9dc09805e38365e_f01e98cfc5c3454f8f38ad12a63350b7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _cb6340e86c15b7a4d9dc09805e38365e_f01e98cfc5c3454f8f38ad12a63350b7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_cb6340e86c15b7a4d9dc09805e38365e_f01e98cfc5c3454f8f38ad12a63350b7);
		}
	}
}
