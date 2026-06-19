using System.Collections.Generic;
using Pug.Conversion;
using UnityEngine;

public class PugDatabaseConverter : SingleAuthoringComponentConverter<PugDatabaseAuthoring>
{
	private bool _hasRun;

	protected override void Convert(PugDatabaseAuthoring authoring)
	{
		if (_hasRun)
		{
			Debug.LogError("Multiple PugDatabase!");
			return;
		}
		_hasRun = true;
		List<DatabaseConversionUtility.PrefabData> prefabList = DatabaseConversionUtility.GetPrefabList(authoring);
		if (prefabList.Count == 0)
		{
			return;
		}
		foreach (DatabaseConversionUtility.PrefabData item in prefabList)
		{
			foreach (PrefabInfo prefabInfo in item.ObjectInfo.prefabInfos)
			{
				if (prefabInfo != null && !(prefabInfo.ecsPrefab == null))
				{
					GetPrefabDependency(prefabInfo.ecsPrefab);
				}
			}
		}
	}
}
