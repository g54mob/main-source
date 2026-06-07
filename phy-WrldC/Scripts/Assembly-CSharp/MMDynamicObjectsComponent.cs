using System.Collections.Generic;

public class MMDynamicObjectsComponent : MainMenuComponentBase
{
	private List<DynamicObjectBase> dynamicObjects;

	private void Awake()
	{
		dynamicObjects = new List<DynamicObjectBase>();
		base.transform.GetComponentsInChildren(includeInactive: true, dynamicObjects);
	}

	protected override void InternalOnSpawnCreationStartingHandler()
	{
		for (int i = 0; i < dynamicObjects.Count; i++)
		{
			dynamicObjects[i].SetupToAction();
		}
	}

	protected override void InternalOnSpawnCreationEndingHandler()
	{
		for (int i = 0; i < dynamicObjects.Count; i++)
		{
			dynamicObjects[i].Recycle();
		}
	}
}
