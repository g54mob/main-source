using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a323748edc20858468d06cd02ed90273_6e0de92fbfcc411da80215b0ee59d868 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a323748edc20858468d06cd02ed90273_6e0de92fbfcc411da80215b0ee59d868 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a323748edc20858468d06cd02ed90273_6e0de92fbfcc411da80215b0ee59d868);
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

		public static void Serialize(_a323748edc20858468d06cd02ed90273_6e0de92fbfcc411da80215b0ee59d868 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a323748edc20858468d06cd02ed90273_6e0de92fbfcc411da80215b0ee59d868 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a323748edc20858468d06cd02ed90273_6e0de92fbfcc411da80215b0ee59d868);
		}
	}
}
