using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Pug.ECS.Hybrid
{
	public struct GraphicalObjectPrefabCD : IComponentData, IQueryTypeParameter
	{
		public float4 RenderBounds;

		public UnityObjectRef<Component> PrefabComponent;

		public UnityObjectRef<GameObject> Prefab;
	}
}
