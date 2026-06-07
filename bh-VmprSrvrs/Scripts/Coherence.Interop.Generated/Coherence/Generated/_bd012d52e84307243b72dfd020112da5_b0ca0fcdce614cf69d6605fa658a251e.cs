using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _bd012d52e84307243b72dfd020112da5_b0ca0fcdce614cf69d6605fa658a251e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public int weaponType;
		}

		public long startingSimFrame;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _bd012d52e84307243b72dfd020112da5_b0ca0fcdce614cf69d6605fa658a251e FromInterop(IntPtr data, int dataSize)
		{
			return default(_bd012d52e84307243b72dfd020112da5_b0ca0fcdce614cf69d6605fa658a251e);
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

		public _bd012d52e84307243b72dfd020112da5_b0ca0fcdce614cf69d6605fa658a251e(Entity entity, long startingSimFrame, int weaponType)
		{
			this.startingSimFrame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_bd012d52e84307243b72dfd020112da5_b0ca0fcdce614cf69d6605fa658a251e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _bd012d52e84307243b72dfd020112da5_b0ca0fcdce614cf69d6605fa658a251e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_bd012d52e84307243b72dfd020112da5_b0ca0fcdce614cf69d6605fa658a251e);
		}
	}
}
