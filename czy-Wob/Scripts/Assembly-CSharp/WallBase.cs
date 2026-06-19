using System.Collections.Generic;
using UnityEngine;

public class WallBase : MonoBehaviour
{
	public Transform centerPoint;

	public bool canFade = true;

	public RoomBase attachedRoom;

	public bool canBecomeDoor = true;

	public WallDirection wallDirection;

	public List<Renderer> wallRenderers = new List<Renderer>();

	public List<Renderer> wallSideRenderers = new List<Renderer>();

	public List<Renderer> wallTrimRenderers = new List<Renderer>();

	public List<WallStateStructure> wallStateStructures = new List<WallStateStructure>();

	public Material defaultSideMaterial;

	public CollisionType collisionType;

	public Vector2 UVOffset = Vector2.zero;

	public Vector2 UVScale = new Vector2(3f, 3f);

	public BoxCollider floorCollider;

	private bool materialIsTiling = true;

	private Dictionary<ConnectorLabel, GameObject> labelToObjectDict = new Dictionary<ConnectorLabel, GameObject>();

	private Dictionary<ConnectorLabel, WallStateStructure> labelToStructureDict = new Dictionary<ConnectorLabel, WallStateStructure>();

	private List<Renderer> renderers = new List<Renderer>();

	private void Awake()
	{
		renderers.Clear();
		StoreRenderers(base.gameObject);
		MapStructures();
		ResetWalls();
		for (int i = 0; i < wallSideRenderers.Count; i++)
		{
			wallSideRenderers[i].material = defaultSideMaterial;
		}
		UpdateUVOffset();
	}

	public bool IsVisible()
	{
		for (int i = 0; i < renderers.Count; i++)
		{
			if (renderers[i].isVisible)
			{
				return true;
			}
		}
		return false;
	}

	public void ApplyCarpet(Material mat, bool tiling, CollisionType cType, bool shadowsEnabled, PhysicMaterial customPhysicsMaterial = null)
	{
		for (int i = 0; i < wallRenderers.Count; i++)
		{
			wallRenderers[i].material = mat;
			wallRenderers[i].receiveShadows = shadowsEnabled;
		}
		materialIsTiling = tiling;
		UpdateUVOffset();
		collisionType = cType;
		if (floorCollider != null)
		{
			floorCollider.material = customPhysicsMaterial;
		}
	}

	public void ApplyWallpaper(Material mainMat, Material trimMat, bool tiling, bool shadowsEnabled)
	{
		for (int i = 0; i < wallRenderers.Count; i++)
		{
			wallRenderers[i].material = mainMat;
			wallRenderers[i].receiveShadows = shadowsEnabled;
		}
		for (int j = 0; j < wallTrimRenderers.Count; j++)
		{
			wallTrimRenderers[j].material = trimMat;
			wallTrimRenderers[j].receiveShadows = shadowsEnabled;
			wallTrimRenderers[j].gameObject.SetActive(trimMat != null);
		}
		materialIsTiling = tiling;
		UpdateUVOffset();
	}

	private void UpdateUVOffset()
	{
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		for (int i = 0; i < wallRenderers.Count; i++)
		{
			wallRenderers[i].GetPropertyBlock(materialPropertyBlock);
			if (materialIsTiling)
			{
				materialPropertyBlock.SetVector("_MainTex_ST", new Vector4(UVScale.x, UVScale.y, UVOffset.x, UVOffset.y));
			}
			else
			{
				materialPropertyBlock.SetVector("_MainTex_ST", new Vector4(1f, 1f, 0f, 0f));
			}
			wallRenderers[i].SetPropertyBlock(materialPropertyBlock);
		}
	}

	private void MapStructures()
	{
		for (int i = 0; i < wallStateStructures.Count; i++)
		{
			labelToStructureDict[wallStateStructures[i].label] = wallStateStructures[i];
			labelToObjectDict[wallStateStructures[i].label] = wallStateStructures[i].mappedObject;
		}
	}

	public WallStateStructure GetStructureForLabel(ConnectorLabel label)
	{
		return labelToStructureDict[label];
	}

	private void StoreRenderers(GameObject obj)
	{
		renderers.AddRange(obj.GetComponentsInChildren<Renderer>(includeInactive: true));
	}

	public bool CanExpand(ConnectorLabel label)
	{
		if (labelToObjectDict.ContainsKey(label))
		{
			return labelToObjectDict[label].activeSelf;
		}
		return false;
	}

	public bool CanAnyLabelExpand()
	{
		for (int i = 0; i < wallStateStructures.Count; i++)
		{
			if (CanExpand(wallStateStructures[i].label))
			{
				return true;
			}
		}
		return false;
	}

	public WallDirection GetOpposingWallDirection()
	{
		WallDirection result = WallDirection.FRONT;
		switch (wallDirection)
		{
		case WallDirection.BACK:
			result = WallDirection.FRONT;
			break;
		case WallDirection.FRONT:
			result = WallDirection.BACK;
			break;
		case WallDirection.DOWN:
			result = WallDirection.UP;
			break;
		case WallDirection.UP:
			result = WallDirection.DOWN;
			break;
		case WallDirection.LEFT:
			result = WallDirection.RIGHT;
			break;
		case WallDirection.RIGHT:
			result = WallDirection.LEFT;
			break;
		}
		return result;
	}

	public void SetWallState(ConnectorLabel label, bool enabledVal)
	{
		labelToObjectDict[label].SetActive(enabledVal);
	}

	public bool HasAttachedFloorPipe()
	{
		if (!canBecomeDoor)
		{
			return false;
		}
		for (int i = 0; i < wallStateStructures.Count; i++)
		{
			if (wallStateStructures[i].isFloor && labelToObjectDict.ContainsKey(wallStateStructures[i].label) && !labelToObjectDict[wallStateStructures[i].label].activeSelf)
			{
				return true;
			}
		}
		return false;
	}

	private void ResetWalls()
	{
		for (int i = 0; i < wallStateStructures.Count; i++)
		{
			wallStateStructures[i].mappedObject.SetActive(value: true);
		}
	}
}
