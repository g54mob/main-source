using Pug.Conversion;
using UnityEngine;

public class CustomSceneConverter : SingleAuthoringComponentConverter<CustomSceneAuthoring>
{
	protected override void Convert(CustomSceneAuthoring authoring)
	{
		CustomScenesDataTable customScenesDataTable = authoring.CustomScenesDataTable;
		if (customScenesDataTable == null)
		{
			Debug.LogError("CustomScenesDataTable not set");
			return;
		}
		foreach (CustomScenesDataTable.Scene scene in customScenesDataTable.scenes)
		{
			foreach (GameObject prefab in scene.prefabs)
			{
				if (!(prefab == null))
				{
					GetPrefabDependency(prefab);
				}
			}
		}
	}
}
