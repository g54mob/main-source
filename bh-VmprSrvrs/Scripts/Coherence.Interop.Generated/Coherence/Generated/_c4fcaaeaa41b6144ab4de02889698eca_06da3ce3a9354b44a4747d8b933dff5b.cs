using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c4fcaaeaa41b6144ab4de02889698eca_06da3ce3a9354b44a4747d8b933dff5b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public float percentage;
		}

		public long startingSimFrame;

		public float percentage;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c4fcaaeaa41b6144ab4de02889698eca_06da3ce3a9354b44a4747d8b933dff5b FromInterop(IntPtr data, int dataSize)
		{
			return default(_c4fcaaeaa41b6144ab4de02889698eca_06da3ce3a9354b44a4747d8b933dff5b);
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

		public _c4fcaaeaa41b6144ab4de02889698eca_06da3ce3a9354b44a4747d8b933dff5b(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_c4fcaaeaa41b6144ab4de02889698eca_06da3ce3a9354b44a4747d8b933dff5b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c4fcaaeaa41b6144ab4de02889698eca_06da3ce3a9354b44a4747d8b933dff5b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c4fcaaeaa41b6144ab4de02889698eca_06da3ce3a9354b44a4747d8b933dff5b);
		}
	}
}
