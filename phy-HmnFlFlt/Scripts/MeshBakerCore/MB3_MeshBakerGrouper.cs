using System.Collections.Generic;
using DigitalOpus.MB.Core;
using UnityEngine;

public class MB3_MeshBakerGrouper : MonoBehaviour, MB_IMeshBakerSettingsHolder
{
	public enum ClusterType
	{
		none = 0,
		grid = 1,
		pie = 2,
		agglomerative = 3
	}

	public static readonly Color WHITE_TRANSP = new Color(1f, 1f, 1f, 0.1f);

	public MB3_MeshBakerGrouperCore grouper;

	public ClusterType clusterType;

	public Transform parentSceneObject;

	public GrouperData data = new GrouperData();

	[HideInInspector]
	public Bounds sourceObjectBounds = new Bounds(Vector3.zero, Vector3.one);

	public string prefabOptions_outputFolder = string.Empty;

	public bool prefabOptions_autoGeneratePrefabs;

	public bool prefabOptions_mergeOutputIntoSinglePrefab;

	public MB3_MeshCombinerSettings meshBakerSettingsAsset;

	public MB3_MeshCombinerSettingsData meshBakerSettings;

	public MB_IMeshBakerSettings GetMeshBakerSettings()
	{
		if (meshBakerSettingsAsset == null)
		{
			if (meshBakerSettings == null)
			{
				meshBakerSettings = new MB3_MeshCombinerSettingsData();
			}
			return meshBakerSettings;
		}
		return meshBakerSettingsAsset.GetMeshBakerSettings();
	}

	public void GetMeshBakerSettingsAsSerializedProperty(out string propertyName, out Object targetObj)
	{
		if (meshBakerSettingsAsset == null)
		{
			targetObj = this;
			propertyName = "meshBakerSettings";
		}
		else
		{
			targetObj = meshBakerSettingsAsset;
			propertyName = "data";
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (grouper == null)
		{
			grouper = CreateGrouper(clusterType, data);
		}
		if (grouper.d == null)
		{
			grouper.d = data;
		}
		grouper.DrawGizmos(sourceObjectBounds);
	}

	public MB3_MeshBakerGrouperCore CreateGrouper(ClusterType t, GrouperData data)
	{
		if (t == ClusterType.grid)
		{
			grouper = new MB3_MeshBakerGrouperGrid(data);
		}
		if (t == ClusterType.pie)
		{
			grouper = new MB3_MeshBakerGrouperPie(data);
		}
		if (t == ClusterType.agglomerative)
		{
			MB3_TextureBaker component = GetComponent<MB3_TextureBaker>();
			List<GameObject> gos = ((!(component != null)) ? new List<GameObject>() : component.GetObjectsToCombine());
			grouper = new MB3_MeshBakerGrouperCluster(data, gos);
		}
		if (t == ClusterType.none)
		{
			grouper = new MB3_MeshBakerGrouperNone(data);
		}
		return grouper;
	}

	public void DeleteAllChildMeshBakers()
	{
		MB3_MeshBakerCommon[] componentsInChildren = GetComponentsInChildren<MB3_MeshBakerCommon>();
		foreach (MB3_MeshBakerCommon mB3_MeshBakerCommon in componentsInChildren)
		{
			GameObject resultSceneObject = mB3_MeshBakerCommon.meshCombiner.resultSceneObject;
			MB_Utility.Destroy(resultSceneObject);
			MB_Utility.Destroy(mB3_MeshBakerCommon.gameObject);
		}
	}
}
