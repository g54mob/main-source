using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using UnityEngine;

namespace Coherence.Generated
{
	public struct _93146e3daa128b749b312aadee0d3900_8c749a9f81514522bf2f89007f79934d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Vector2 spawnPositionOffset;
		}

		public Vector2 spawnPositionOffset;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _93146e3daa128b749b312aadee0d3900_8c749a9f81514522bf2f89007f79934d FromInterop(IntPtr data, int dataSize)
		{
			return default(_93146e3daa128b749b312aadee0d3900_8c749a9f81514522bf2f89007f79934d);
		}

		public uint GetComponentType()
		{
			return 0u;
		}

		public IEntityMessage Clone()
		{
			return null;
		}

		public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Coherence.Log.Logger logger)
		{
			return default(IEntityMapper.Error);
		}

		public IEntityMapper.Error MapToRelative(IEntityMapper mapper, Coherence.Log.Logger logger)
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

		public _93146e3daa128b749b312aadee0d3900_8c749a9f81514522bf2f89007f79934d(Entity entity, Vector2 spawnPositionOffset)
		{
			this.spawnPositionOffset = default(Vector2);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_93146e3daa128b749b312aadee0d3900_8c749a9f81514522bf2f89007f79934d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _93146e3daa128b749b312aadee0d3900_8c749a9f81514522bf2f89007f79934d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_93146e3daa128b749b312aadee0d3900_8c749a9f81514522bf2f89007f79934d);
		}
	}
}
