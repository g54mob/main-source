using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class PositionNewsItems : PostgameSystemBase
	{
		private float Spacing = 6f;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_Marker_18;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SNewsList.Marker>();
		}

		protected override void OnUpdate()
		{
			DynamicBuffer<SNewsList> buffer = GetBuffer<SNewsList>(_SingletonEntityQuery_Marker_18.GetSingletonEntity());
			int num = 0;
			for (int i = 0; i < buffer.Length; i++)
			{
				if (HasComponent<CNewsItemActive>(buffer[i].Item))
				{
					num = i;
					break;
				}
			}
			for (int j = 0; j < buffer.Length; j++)
			{
				SetComponent(buffer[j].Item, new CPosition(new Vector3(Spacing * (float)(j - num), 2f, 0f)));
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_Marker_18 = GetEntityQuery(ComponentType.ReadOnly<SNewsList.Marker>());
		}
	}
}
