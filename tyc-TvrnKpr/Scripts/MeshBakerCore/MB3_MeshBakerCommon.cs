using System.Collections.Generic;
using DigitalOpus.MB.Core;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class MB3_MeshBakerCommon : MB3_MeshBakerRoot
{
	public int version;

	[NonReorderable]
	public List<GameObject> objsToMesh;

	public bool useObjsToMeshFromTexBaker;

	[FormerlySerializedAs("clearBuffersAfterBake")]
	[SerializeField]
	[HideInInspector]
	private bool _clearBuffersAfterBake;

	public string bakeAssetsInPlaceFolderPath;

	[HideInInspector]
	public GameObject resultPrefab;

	[HideInInspector]
	public bool resultPrefabLeaveInstanceInSceneAfterBake;

	[HideInInspector]
	public Transform parentSceneObject;

	public static int VERSION => 0;

	public abstract MB3_MeshCombiner meshCombiner { get; }

	public bool clearBuffersAfterBake
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override MB2_TextureBakeResults textureBakeResults
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void UpgradeToCurrentVersionIfNecessary()
	{
	}

	public override List<GameObject> GetObjectsToCombine()
	{
		return null;
	}

	[ContextMenu("Purge Objects to Combine of null references")]
	public override void PurgeNullsFromObjectsToCombine()
	{
	}

	public void EnableDisableSourceObjectRenderers(bool show)
	{
	}

	public virtual void ClearMesh()
	{
	}

	public virtual void ClearMesh(MB2_EditorMethodsInterface editorMethods)
	{
	}

	public virtual void DestroyMesh()
	{
	}

	public virtual void DestroyMeshEditor(MB2_EditorMethodsInterface editorMethods)
	{
	}

	public virtual int GetNumObjectsInCombined()
	{
		return 0;
	}

	public MB3_TextureBaker GetTextureBaker()
	{
		return null;
	}

	public abstract bool AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource = true);

	public abstract bool AddDeleteGameObjectsByID(GameObject[] gos, int[] deleteGOinstanceIDs, bool disableRendererInSource = true);

	public virtual bool Apply(MB3_MeshCombiner.GenerateUV2Delegate uv2GenerationMethod = null)
	{
		return false;
	}

	public virtual bool Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool colors, bool bones = false, bool blendShapesFlag = false, MB3_MeshCombiner.GenerateUV2Delegate uv2GenerationMethod = null)
	{
		return false;
	}

	public virtual bool CombinedMeshContains(GameObject go)
	{
		return false;
	}

	public virtual bool UpdateGameObjects(GameObject[] gos)
	{
		return false;
	}

	public virtual bool UpdateGameObjects(GameObject[] gos, bool updateBounds)
	{
		return false;
	}

	public virtual bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV1, bool updateUV2, bool updateColors, bool updateSkinningInfo)
	{
		return false;
	}

	public virtual bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo)
	{
		return false;
	}

	public virtual void UpdateSkinnedMeshApproximateBounds()
	{
	}

	public virtual void UpdateSkinnedMeshApproximateBoundsFromBones()
	{
	}

	public virtual void UpdateSkinnedMeshApproximateBoundsFromBounds()
	{
	}

	protected virtual bool _ValidateForUpdateSkinnedMeshBounds()
	{
		return false;
	}
}
