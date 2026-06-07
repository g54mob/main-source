using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4edd6a9a43616b14798b64cafa40875f_126c4b0b7dfc45b08ded76e87f832d2b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _4edd6a9a43616b14798b64cafa40875f_126c4b0b7dfc45b08ded76e87f832d2b FromInterop(IntPtr data, int dataSize)
		{
			return default(_4edd6a9a43616b14798b64cafa40875f_126c4b0b7dfc45b08ded76e87f832d2b);
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

		public _4edd6a9a43616b14798b64cafa40875f_126c4b0b7dfc45b08ded76e87f832d2b(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_4edd6a9a43616b14798b64cafa40875f_126c4b0b7dfc45b08ded76e87f832d2b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4edd6a9a43616b14798b64cafa40875f_126c4b0b7dfc45b08ded76e87f832d2b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4edd6a9a43616b14798b64cafa40875f_126c4b0b7dfc45b08ded76e87f832d2b);
		}
	}
}
