using Pug.Conversion;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Pug.ECS.Hybrid
{
	public class GraphicalObjectConversion : Converter
	{
		public override void Convert(GameObject authoring)
		{
			if (base.IsServer)
			{
				return;
			}
			ObjectInfo objectInfo = null;
			Component component = null;
			GameObject gameObject = null;
			ObjectAuthoring component3;
			if (authoring.TryGetComponent<EntityMonoBehaviourData>(out var component2))
			{
				objectInfo = component2.objectInfo;
				if (objectInfo.prefabInfos.Count > 0 && objectInfo.prefabInfos[0].prefab != null)
				{
					component = objectInfo.prefabInfos[0].prefab;
				}
			}
			else if (authoring.TryGetComponent<ObjectAuthoring>(out component3))
			{
				objectInfo = component3.ObjectInfo;
				if (component3.graphicalPrefab != null)
				{
					if (component3.graphicalPrefab.TryGetComponent<EntityMonoBehaviour>(out var component4))
					{
						component = component4;
					}
					else
					{
						gameObject = component3.graphicalPrefab;
					}
				}
			}
			if (component != null || gameObject != null)
			{
				Entity entity = CreateAdditionalEntity();
				float2 float5 = (Vector2)objectInfo.prefabTileSize;
				float2 float6 = (float2)(Vector2)objectInfo.prefabCornerOffset - 0.5f;
				float4 renderBounds = new float4(float6, float6 + float5);
				PlayerAuthoring component6;
				if (authoring.TryGetComponent<OverrideNetworkSyncDistanceAuthoring>(out var component5))
				{
					float num = component5.distance - 17.210213f;
					renderBounds.xy = math.min(renderBounds.xy, 0f - num);
					renderBounds.zw = math.max(renderBounds.zw, num);
				}
				else if (authoring.TryGetComponent<PlayerAuthoring>(out component6))
				{
					renderBounds = new float4(float.MinValue, float.MinValue, float.MaxValue, float.MaxValue);
				}
				AddComponentData(entity, new GraphicalObjectPrefabCD
				{
					RenderBounds = renderBounds,
					PrefabComponent = component,
					Prefab = gameObject
				});
				AddComponentData(entity, new GraphicalObjectPrefabEntityCD
				{
					Value = base.PrimaryEntity
				});
				if (component != null)
				{
					EnsureHasComponent<EntityMonoBehaviourCD>(base.PrimaryEntity);
				}
			}
		}
	}
}
