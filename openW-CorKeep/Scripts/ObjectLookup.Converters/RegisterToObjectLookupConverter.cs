using Pug.Conversion;
using Unity.Entities;
using Unity.Physics.Authoring;
using UnityEngine;

public class RegisterToObjectLookupConverter : Converter
{
	public override void Convert(GameObject authoring)
	{
		if (!base.IsServer)
		{
			return;
		}
		EntityMonoBehaviourData component;
		bool num = TryGetActiveComponent<EntityMonoBehaviourData>(authoring, out component);
		ObjectAuthoring component2;
		bool flag = TryGetActiveComponent<ObjectAuthoring>(authoring, out component2);
		if (!num && !flag)
		{
			return;
		}
		ObjectID objectID = (flag ? component2.ObjectInfo.objectID : component.ObjectInfo.objectID);
		int variation = (flag ? component2.ObjectInfo.variation : component.ObjectInfo.variation);
		if (objectID != ObjectID.None && objectID != ObjectID.DroppedItem && !authoring.TryGetComponent<Rigidbody>(out var _) && (!TryGetActiveComponent<PhysicsBodyAuthoring>(authoring, out var component4) || component4.MotionType == BodyMotionType.Static))
		{
			EnsureHasComponent<ShouldBeRegisteredToObjectLookupCD>();
			if (base.IsServer)
			{
				Entity entity = CreateAdditionalEntity();
				AddComponentData(entity, new RegisterTargetToObjectLookupCD
				{
					targetEntity = base.PrimaryEntity,
					objectID = objectID,
					variation = variation
				});
			}
		}
	}
}
