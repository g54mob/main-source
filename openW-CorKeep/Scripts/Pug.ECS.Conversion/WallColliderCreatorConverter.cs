using Pug.Conversion;
using Unity.Physics.Authoring;
using UnityEngine;

public class WallColliderCreatorConverter : Converter
{
	public override void Convert(GameObject authoring)
	{
		if (TryGetActiveComponent<PhysicsBodyAuthoring>(authoring, out var component) && component.MotionType == BodyMotionType.Dynamic)
		{
			PlayerAuthoring component2;
			bool flag = authoring.TryGetComponent<PlayerAuthoring>(out component2);
			if (base.IsServer || flag)
			{
				EnsureHasComponent<WallColliderCreatorCD>();
			}
		}
	}
}
