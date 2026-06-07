using System.Collections.Generic;
using JBooth.MicroSplat;
using UnityEngine;

[ExecuteInEditMode]
[DisallowMultipleComponent]
public class MicroSplatMeshTerrain : MicroSplatObject
{
	public delegate void MaterialSyncAll();

	public delegate void MaterialSync(Material m);

	private static List<MicroSplatMeshTerrain> sInstances = new List<MicroSplatMeshTerrain>();

	public MeshRenderer[] meshTerrains;

	public Texture2D[] controlTextures;

	[HideInInspector]
	public Material meshBlendMat;

	[HideInInspector]
	public Material meshBlendMatInstance;

	public TerrainDescriptor terrainDescriptor;

	public static event MaterialSyncAll OnMaterialSyncAll;

	public event MaterialSync OnMaterialSync;

	private void OnEnable()
	{
		sInstances.Add(this);
	}

	public override TerrainDescriptor GetTerrainDescriptor()
	{
		if (perPixelNormal != null)
		{
			terrainDescriptor.normalMap = perPixelNormal;
		}
		return terrainDescriptor;
	}

	private void Start()
	{
		Sync();
	}

	private void OnDisable()
	{
		sInstances.Remove(this);
		Cleanup();
	}

	private void Cleanup()
	{
		if (matInstance != null && matInstance != templateMaterial)
		{
			Object.DestroyImmediate(matInstance);
		}
	}

	private void SyncMeshBlendMat()
	{
		if (meshBlendMatInstance != null && matInstance != null)
		{
			meshBlendMatInstance.CopyPropertiesFromMaterial(matInstance);
		}
	}

	private Material GetMeshBlendMatInstance()
	{
		if (meshBlendMat != null)
		{
			if (meshBlendMatInstance == null)
			{
				meshBlendMatInstance = new Material(meshBlendMat);
				SyncMeshBlendMat();
			}
			if (meshBlendMatInstance.shader != meshBlendMat.shader)
			{
				meshBlendMatInstance.shader = meshBlendMat.shader;
				SyncMeshBlendMat();
			}
		}
		return meshBlendMatInstance;
	}

	private void ApplyMeshBlendMap()
	{
		if (meshBlendMat != null)
		{
			if (meshBlendMatInstance == null)
			{
				meshBlendMatInstance = new Material(meshBlendMat);
			}
			SyncMeshBlendMat();
		}
	}

	public void Sync()
	{
		if (templateMaterial == null)
		{
			return;
		}
		if (keywordSO == null)
		{
			RevisionFromMat();
		}
		if (keywordSO == null || meshTerrains == null || meshTerrains.Length == 0)
		{
			return;
		}
		ApplySharedData(templateMaterial);
		if (matInstance == null)
		{
			matInstance = new Material(templateMaterial);
		}
		matInstance.CopyPropertiesFromMaterial(templateMaterial);
		matInstance.hideFlags = HideFlags.HideAndDontSave;
		ApplyMaps(matInstance);
		if (controlTextures != null && controlTextures.Length != 0)
		{
			ApplyControlTextures(controlTextures, matInstance);
		}
		for (int i = 0; i < meshTerrains.Length; i++)
		{
			MeshRenderer meshRenderer = meshTerrains[i];
			if (!(meshRenderer == null))
			{
				meshRenderer.sharedMaterial = matInstance;
			}
		}
		if (this.OnMaterialSync != null)
		{
			this.OnMaterialSync(matInstance);
		}
		ApplyBlendMap();
		ApplyMeshBlendMap();
	}

	public override Bounds GetBounds()
	{
		Bounds result = default(Bounds);
		bool flag = false;
		for (int i = 0; i < meshTerrains.Length; i++)
		{
			MeshRenderer meshRenderer = meshTerrains[i];
			if (!(meshRenderer == null))
			{
				if (!flag)
				{
					result = meshRenderer.bounds;
					flag = true;
				}
				else
				{
					result.Encapsulate(meshRenderer.bounds);
				}
			}
		}
		return result;
	}

	public new static void SyncAll()
	{
		for (int i = 0; i < sInstances.Count; i++)
		{
			sInstances[i].Sync();
		}
		if (MicroSplatMeshTerrain.OnMaterialSyncAll != null)
		{
			MicroSplatMeshTerrain.OnMaterialSyncAll();
		}
	}
}
