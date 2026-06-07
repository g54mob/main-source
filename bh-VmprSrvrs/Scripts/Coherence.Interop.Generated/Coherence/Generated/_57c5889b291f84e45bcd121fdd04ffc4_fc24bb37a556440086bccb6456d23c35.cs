using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _57c5889b291f84e45bcd121fdd04ffc4_fc24bb37a556440086bccb6456d23c35 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _57c5889b291f84e45bcd121fdd04ffc4_fc24bb37a556440086bccb6456d23c35 FromInterop(IntPtr data, int dataSize)
		{
			return default(_57c5889b291f84e45bcd121fdd04ffc4_fc24bb37a556440086bccb6456d23c35);
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

		public _57c5889b291f84e45bcd121fdd04ffc4_fc24bb37a556440086bccb6456d23c35(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_57c5889b291f84e45bcd121fdd04ffc4_fc24bb37a556440086bccb6456d23c35 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _57c5889b291f84e45bcd121fdd04ffc4_fc24bb37a556440086bccb6456d23c35 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_57c5889b291f84e45bcd121fdd04ffc4_fc24bb37a556440086bccb6456d23c35);
		}
	}
}
