using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6571407d772bb034f93ea48f397b9a71_b7204e36772f4330a83d47a00e674c0d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _6571407d772bb034f93ea48f397b9a71_b7204e36772f4330a83d47a00e674c0d FromInterop(IntPtr data, int dataSize)
		{
			return default(_6571407d772bb034f93ea48f397b9a71_b7204e36772f4330a83d47a00e674c0d);
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

		public static void Serialize(_6571407d772bb034f93ea48f397b9a71_b7204e36772f4330a83d47a00e674c0d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6571407d772bb034f93ea48f397b9a71_b7204e36772f4330a83d47a00e674c0d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6571407d772bb034f93ea48f397b9a71_b7204e36772f4330a83d47a00e674c0d);
		}
	}
}
