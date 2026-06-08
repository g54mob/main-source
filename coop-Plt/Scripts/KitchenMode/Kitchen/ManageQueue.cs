using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(UpdateCustomerStatesGroup))]
	public class ManageQueue : GameSystemBase
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SQueueMarker_4;

		protected override void OnUpdate()
		{
			EntityCommandBuffer commandBuffer = GetCommandBuffer(ECB.End);
			DynamicBuffer<CQueue> buffer = GetBuffer<CQueue>(_SingletonEntityQuery_SQueueMarker_4.GetSingletonEntity());
			Vector3 vector = GetFrontDoor() + new Vector3(0f, 0f, -1.5f);
			Vector3 vector2 = new Vector3(1f, 0f, 0f);
			if (buffer.IsEmpty)
			{
				return;
			}
			for (int num = buffer.Length - 1; num >= 0; num--)
			{
				if (!HasComponent<CQueuePosition>(buffer[num].Member))
				{
					buffer.RemoveAt(num);
				}
			}
			for (int i = 0; i < buffer.Length; i++)
			{
				CQueue cQueue = buffer[i];
				DynamicBuffer<CGroupMember> buffer2 = GetBuffer<CGroupMember>(cQueue.Member);
				Vector3 vector3 = vector + vector2 * (i + 1);
				SetComponent(cQueue.Member, new CQueuePosition
				{
					QueuePosition = i,
					Position = vector3
				});
				for (int j = 0; j < buffer2.Length; j++)
				{
					float num2 = 0.5f;
					float x = (float)Math.PI * 2f / (float)buffer2.Length * (float)j;
					Vector3 vector4 = new Vector3(num2 * math.sin(x), 0f, num2 * math.cos(x));
					commandBuffer.AddComponent(buffer2[j], new CMoveToLocation
					{
						Location = vector3 + vector4,
						DesiredFacing = vector3 - vector2,
						StoppingDistance = 0.25f
					});
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SQueueMarker_4 = GetEntityQuery(ComponentType.ReadOnly<SQueueMarker>());
		}
	}
}
