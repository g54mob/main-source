using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class MoveBetweenNews : PostgameSystemBase
	{
		private EntityQuery MoveRequests;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_Marker_17;

		protected override void Initialise()
		{
			base.Initialise();
			MoveRequests = GetEntityQuery(typeof(CRequestMoveNewsItem));
			RequireSingletonForUpdate<SNewsList.Marker>();
			RequireForUpdate(MoveRequests);
		}

		protected override void OnUpdate()
		{
			NativeArray<CRequestMoveNewsItem> nativeArray = MoveRequests.ToComponentDataArray<CRequestMoveNewsItem>(Allocator.Temp);
			int num = ((!nativeArray[0].IsRewind) ? 1 : (-1));
			nativeArray.Dispose();
			base.EntityManager.DestroyEntity(MoveRequests);
			DynamicBuffer<SNewsList> buffer = GetBuffer<SNewsList>(_SingletonEntityQuery_Marker_17.GetSingletonEntity());
			int num2 = 0;
			for (int i = 0; i < buffer.Length; i++)
			{
				if (HasComponent<CNewsItemActive>(buffer[i].Item))
				{
					num2 = i;
					break;
				}
			}
			int num3 = Mathf.Clamp(num2 + num, 0, buffer.Length - 1);
			if (num2 == buffer.Length - 1 && num > 0)
			{
				base.EntityManager.CreateEntity(typeof(CRequestQuitEvent));
			}
			else if (num3 != num2)
			{
				Entity item = buffer[num2].Item;
				Entity item2 = buffer[num3].Item;
				base.EntityManager.RemoveComponent<CNewsItemActive>(item);
				base.EntityManager.AddComponent<CNewsItemActive>(item2);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_Marker_17 = GetEntityQuery(ComponentType.ReadOnly<SNewsList.Marker>());
		}
	}
}
