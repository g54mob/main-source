using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics.Authoring;
using Unity.Transforms;
using UnityEngine;

namespace Pug.Conversion
{
	public class TransformConverter : Converter
	{
		public override void Convert(GameObject authoring)
		{
			if (TryGetActiveComponent<DontNeedTransformAuthoring>(authoring, out var _))
			{
				return;
			}
			Transform transform = authoring.transform;
			if (!base.IsServer)
			{
				AddComponentData(new LocalToWorld
				{
					Value = transform.localToWorldMatrix
				});
			}
			bool flag = transform.parent != null;
			bool flag2 = authoring.GetComponent<StaticOptimizeEntity>() != null;
			if ((TryGetActiveComponent<PhysicsBodyAuthoring>(authoring, out var component2) ? component2.MotionType : BodyMotionType.Static) != BodyMotionType.Static || !flag || flag2)
			{
				RigidTransform transform2 = new RigidTransform
				{
					pos = transform.position,
					rot = transform.rotation
				};
				AddComponentData(LocalTransform.FromPositionRotation(transform2.pos, transform2.rot));
				if (math.lengthsq((float3)transform.lossyScale - new float3(1f)) > 0f)
				{
					float4x4 value = math.mul(math.inverse(new float4x4(transform2)), transform.localToWorldMatrix);
					AddComponentData(new PostTransformMatrix
					{
						Value = value
					});
				}
			}
			else
			{
				AddComponentData(LocalTransform.FromPositionRotation(transform.localPosition, transform.localRotation));
				if (transform.localScale != Vector3.one)
				{
					AddComponentData(new PostTransformMatrix
					{
						Value = float4x4.Scale(transform.localScale)
					});
				}
				AddComponentData(new Parent
				{
					Value = GetPrefabDependency(transform.parent.gameObject)
				});
			}
		}
	}
}
