using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

namespace NetworkedEcb
{
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public class ClientSendSystem : SystemBase
	{
		private List<NativeQueue<NetworkedEcbRpc>> commandBuffers;

		private EntityArchetype rpcArchetype;

		[Preserve]
		protected override void OnCreate()
		{
			commandBuffers = new List<NativeQueue<NetworkedEcbRpc>>();
			rpcArchetype = base.EntityManager.CreateArchetype(typeof(NetworkedEcbRpc), typeof(SendRpcCommandRequest));
		}

		[Preserve]
		protected override void OnDestroy()
		{
			foreach (NativeQueue<NetworkedEcbRpc> commandBuffer in commandBuffers)
			{
				commandBuffer.Dispose();
			}
			base.OnDestroy();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			if (commandBuffers.Count == 0)
			{
				return;
			}
			for (int i = 0; i < commandBuffers.Count; i++)
			{
				NativeQueue<NetworkedEcbRpc> nativeQueue = commandBuffers[i];
				NetworkedEcbRpc item;
				while (nativeQueue.TryDequeue(out item))
				{
					Entity entity = base.EntityManager.CreateEntity(rpcArchetype);
					base.EntityManager.SetComponentData(entity, item);
				}
				commandBuffers[i].Dispose();
			}
			commandBuffers.Clear();
		}

		public NetworkedCommandBuffer CreateCommandBuffer()
		{
			NativeQueue<NetworkedEcbRpc> nativeQueue = new NativeQueue<NetworkedEcbRpc>(base.World.UpdateAllocator.ToAllocator);
			commandBuffers.Add(nativeQueue);
			return new NetworkedCommandBuffer
			{
				queue = nativeQueue
			};
		}

		[Preserve]
		public ClientSendSystem()
		{
		}
	}
}
