using System.Collections.Generic;
using Interaction;
using Pug.Conversion;
using Pug.UnityExtensions;

public class SittableConverter : SingleAuthoringComponentConverter<SittableAuthoring>
{
	protected override void Convert(SittableAuthoring authoring)
	{
		EntityMonoBehaviourData component = authoring.GetComponent<EntityMonoBehaviourData>();
		List<PrefabInfo> list = ((!(component != null)) ? null : component.objectInfo?.prefabInfos);
		SittableObject[] array = null;
		if (list == null)
		{
			ObjectAuthoring component2 = authoring.GetComponent<ObjectAuthoring>();
			if (component2 != null && component2.graphicalPrefab != null)
			{
				array = component2.graphicalPrefab.GetComponentsInChildren<SittableObject>(includeInactive: true);
			}
		}
		else
		{
			array = list[0].prefab.GetComponentsInChildren<SittableObject>(includeInactive: true);
		}
		SittableObject sittableObject = array[0];
		AddComponentData(new SittableCD
		{
			sitPositionOffset = sittableObject.physicalSitPosition.position.ToFloat2(),
			leavePositionOffset = new FourDirectionFloat2
			{
				right = sittableObject.leavePositionRight.position.ToFloat2(),
				back = sittableObject.leavePositionFront.position.ToFloat2(),
				left = sittableObject.leavePositionLeft.position.ToFloat2(),
				forward = sittableObject.leavePositionBack.position.ToFloat2()
			}
		});
		EnsureHasBuffer<TriggerUseInteractionBuffer>();
	}
}
