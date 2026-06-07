using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _73e35180814476b4eabe9e540be9cdd6_9dab185075ab48918dadd69df2c310cb : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _73e35180814476b4eabe9e540be9cdd6_9dab185075ab48918dadd69df2c310cb FromInterop(IntPtr data, int dataSize)
		{
			return default(_73e35180814476b4eabe9e540be9cdd6_9dab185075ab48918dadd69df2c310cb);
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

		public _73e35180814476b4eabe9e540be9cdd6_9dab185075ab48918dadd69df2c310cb(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_73e35180814476b4eabe9e540be9cdd6_9dab185075ab48918dadd69df2c310cb commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _73e35180814476b4eabe9e540be9cdd6_9dab185075ab48918dadd69df2c310cb Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_73e35180814476b4eabe9e540be9cdd6_9dab185075ab48918dadd69df2c310cb);
		}
	}
}
