using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class WallVisualizerComponent : MonoBehaviour
{
	public enum ReplaceMode
	{
		Both = 0,
		Left = 1,
		Right = 2
	}

	[SerializeField]
	private GameObject[] wallPieces;

	[SerializeField]
	private GameObject[] pillars;

	[SerializeField]
	private CafeBuildingSet cafeBuildingSet;

	[Header("Editor Only")]
	[SerializeField]
	private ReplaceMode replaceMode;

	[SerializeField]
	private int editorSelectedCafeBuildingSet;

	private Vector3 defaultPositionW1 = new Vector3(1f, 0f, 0f);

	private Vector3 defaultPositionW2 = new Vector3(-1f, 0f, 0f);

	public Vector2Int room;

	public WallComponent.WallFaceDirection wall;

	private void Start()
	{
		Init();
	}

	public void Init()
	{
		ApplySet(editorSelectedCafeBuildingSet);
		for (int i = 0; i < wallPieces.Length; i++)
		{
			if (wallPieces[i] == null)
			{
				ApplyWallExt();
			}
			if (wallPieces[i].GetComponent<WallInstance>() != null)
			{
				wallPieces[i].GetComponent<WallInstance>().Init(this, i, wallPieces[i].GetComponent<WallInstance>().wallVariant);
			}
			else
			{
				wallPieces[i].AddComponent<WallInstance>().Init(this, i, null);
			}
		}
		ReloadPillars();
	}

	public void SwitchWallSet(int set = 0)
	{
		SwitchWall(set, 0);
		SwitchWall(set, 1);
		ReloadPillars();
	}

	private void SwitchWall(int set, int index)
	{
		if (wallPieces.Length != 0 && !(wallPieces[index] == null) && !(wallPieces[index].GetComponent<WallInstance>() == null))
		{
			cafeBuildingSet = ShopBuilder.GetCafeBuildingOptionsLibrary().GetBuildingSet(set);
			WallInstance component = wallPieces[index].GetComponent<WallInstance>();
			CafeWallPieceVariant variantByName = cafeBuildingSet.GetVariantByName(component.wallVariant.name);
			if (variantByName == null)
			{
				Debug.Log("WallInstance: >" + component.name + "< has no variant assigned");
			}
			else if (component.GetID() == 1)
			{
				ReplacePart(component.GetID(), variantByName, variantByName.canBeMirrored);
			}
			else
			{
				ReplacePart(component.GetID(), variantByName);
			}
		}
	}

	public void ApplyRoomData(Vector2Int room, WallComponent.WallFaceDirection wall)
	{
		this.room = room;
		this.wall = wall;
	}

	private void ApplySet(int set = 0)
	{
		cafeBuildingSet = ShopBuilder.GetCafeBuildingOptionsLibrary().GetBuildingSet(editorSelectedCafeBuildingSet);
	}

	public void ApplyPaint(WallPaintSaveData[] wallPaint)
	{
		for (int i = 0; i < wallPieces.Length; i++)
		{
			WallInstance wallInstance = wallPieces[i].GetComponent<WallInstance>();
			if (!(wallInstance == null))
			{
				WallPaintSaveData wallPaintSaveData = wallPaint.FirstOrDefault((WallPaintSaveData x) => x.wallIndex == wallInstance.GetID());
				if (wallPaintSaveData != null)
				{
					wallInstance.GetComponent<WallPaintInstance>().Paint(wallPaintSaveData.wallColor);
				}
			}
		}
	}

	public void ApplyWallInt(ReplaceMode replace = ReplaceMode.Both)
	{
		ApplySet();
		Reload(replace, cafeBuildingSet.GetVariantByName("Wall_Interieur"), isInteractable: false);
	}

	public void ApplyWallExt(ReplaceMode replace = ReplaceMode.Both)
	{
		ApplySet();
		Reload(replace, cafeBuildingSet.GetVariantByName("Wall_Exterieur"), isInteractable: false);
	}

	public void ApplyWindowInt(ReplaceMode replace = ReplaceMode.Both)
	{
		ApplySet();
		ReloadMirrored(replace, cafeBuildingSet.GetVariantByName("Window_Interieur"), isInteractable: false);
	}

	public void ApplyWindowExt(ReplaceMode replace = ReplaceMode.Both)
	{
		ApplySet();
		ReloadMirrored(replace, cafeBuildingSet.GetVariantByName("Window_Exterieur"), isInteractable: false);
	}

	public void ApplyDoorInt(ReplaceMode replace = ReplaceMode.Both)
	{
		ApplySet();
		Reload(replace, cafeBuildingSet.GetVariantByName("Door_Interieur"), isInteractable: true);
	}

	public void ApplyDoorExt(ReplaceMode replace = ReplaceMode.Both)
	{
		ApplySet();
		Reload(replace, cafeBuildingSet.GetVariantByName("Door_Exterieur"), isInteractable: true);
	}

	public void ApplyDoorArcInt(ReplaceMode replace = ReplaceMode.Both)
	{
		ApplySet();
		ReloadMirrored(replace, cafeBuildingSet.GetVariantByName("Arc_Door_Interieur"), isInteractable: true);
		if (pillars[0] != null)
		{
			Object.Destroy(pillars[0]);
		}
	}

	public void ApplyDoorArcExt(ReplaceMode replace = ReplaceMode.Both)
	{
		ApplySet();
		ReloadMirrored(replace, cafeBuildingSet.GetVariantByName("Arc_Door_Exterieur"), isInteractable: true);
		CafeShopManager.RegisterEntranceDoor(wallPieces[0].GetComponentInChildren<TweenPlayer>());
		CafeShopManager.RegisterEntranceDoor(wallPieces[1].GetComponentInChildren<TweenPlayer>());
		GetComponent<NavMeshObstacle>().enabled = false;
		if (pillars[0] != null)
		{
			Object.Destroy(pillars[0]);
		}
	}

	[ContextMenu("Apply Wall Inside")]
	public void EditorApplyWallIn()
	{
		cafeBuildingSet = Resources.Load<CafeBuildingOptionsLibrary>("Libraries/CafeBuildingOptions/CafeBuildingOptionsLibrary").GetBuildingSet(editorSelectedCafeBuildingSet);
		Reload(replaceMode, cafeBuildingSet.GetVariantByName("Wall_Interieur"), isInteractable: false);
	}

	[ContextMenu("Apply Wall Outside")]
	public void EditorApplyWallOut()
	{
		cafeBuildingSet = Resources.Load<CafeBuildingOptionsLibrary>("Libraries/CafeBuildingOptions/CafeBuildingOptionsLibrary").GetBuildingSet(editorSelectedCafeBuildingSet);
		Reload(replaceMode, cafeBuildingSet.GetVariantByName("Wall_Exterieur"), isInteractable: false);
	}

	[ContextMenu("Apply Window Inside")]
	public void EditorApplyWindowInt()
	{
		cafeBuildingSet = Resources.Load<CafeBuildingOptionsLibrary>("Libraries/CafeBuildingOptions/CafeBuildingOptionsLibrary").GetBuildingSet(editorSelectedCafeBuildingSet);
		ReloadMirrored(replaceMode, cafeBuildingSet.GetVariantByName("Window_Interieur"), isInteractable: false);
	}

	[ContextMenu("Apply Window Outside")]
	public void EditorApplyWindowExt()
	{
		cafeBuildingSet = Resources.Load<CafeBuildingOptionsLibrary>("Libraries/CafeBuildingOptions/CafeBuildingOptionsLibrary").GetBuildingSet(editorSelectedCafeBuildingSet);
		ReloadMirrored(replaceMode, cafeBuildingSet.GetVariantByName("Window_Exterieur"), isInteractable: false);
	}

	[ContextMenu("Apply Door Inside")]
	public void EditorApplyDoorInt()
	{
		cafeBuildingSet = Resources.Load<CafeBuildingOptionsLibrary>("Libraries/CafeBuildingOptions/CafeBuildingOptionsLibrary").GetBuildingSet(editorSelectedCafeBuildingSet);
		Reload(replaceMode, cafeBuildingSet.GetVariantByName("Door_Interieur"), isInteractable: true);
	}

	[ContextMenu("Apply Door Outside")]
	public void EditorApplyDoorExt()
	{
		cafeBuildingSet = Resources.Load<CafeBuildingOptionsLibrary>("Libraries/CafeBuildingOptions/CafeBuildingOptionsLibrary").GetBuildingSet(editorSelectedCafeBuildingSet);
		Reload(replaceMode, cafeBuildingSet.GetVariantByName("Door_Exterieur"), isInteractable: true);
	}

	[ContextMenu("Apply Door Arc Inside")]
	public void EditorApplyDoorArcInt()
	{
		cafeBuildingSet = Resources.Load<CafeBuildingOptionsLibrary>("Libraries/CafeBuildingOptions/CafeBuildingOptionsLibrary").GetBuildingSet(editorSelectedCafeBuildingSet);
		ReloadMirrored(replaceMode, cafeBuildingSet.GetVariantByName("Arc_Door_Interieur"), isInteractable: true);
	}

	[ContextMenu("Apply Door Arc Outside")]
	public void EditorApplyDoorArcExt()
	{
		cafeBuildingSet = Resources.Load<CafeBuildingOptionsLibrary>("Libraries/CafeBuildingOptions/CafeBuildingOptionsLibrary").GetBuildingSet(editorSelectedCafeBuildingSet);
		ReloadMirrored(replaceMode, cafeBuildingSet.GetVariantByName("Arc_Door_Exterieur"), isInteractable: true);
	}

	private void Reload(ReplaceMode replace, CafeWallPieceVariant newPiece, bool isInteractable)
	{
		switch (replace)
		{
		case ReplaceMode.Both:
			ReloadWallPiece(newPiece);
			break;
		case ReplaceMode.Left:
			ReplacePart(1, newPiece, mirror: false, isInteractable);
			break;
		case ReplaceMode.Right:
			ReplacePart(0, newPiece, mirror: false, isInteractable);
			break;
		}
		ReloadPillars();
	}

	private void ReloadMirrored(ReplaceMode replace, CafeWallPieceVariant newPiece, bool isInteractable)
	{
		switch (replace)
		{
		case ReplaceMode.Both:
			ReplacePart(0, newPiece, mirror: false, isInteractable);
			ReplacePart(1, newPiece, mirror: true, isInteractable);
			break;
		case ReplaceMode.Left:
			ReplacePart(1, newPiece, mirror: true, isInteractable);
			break;
		case ReplaceMode.Right:
			ReplacePart(0, newPiece, mirror: false, isInteractable);
			break;
		}
		ReloadPillars();
	}

	private void ReloadWallPiece(CafeWallPieceVariant newPiece)
	{
		for (int i = 0; i < wallPieces.Length; i++)
		{
			ReplacePart(i, newPiece);
		}
		ReloadPillars();
	}

	private void ReplacePart(int index, CafeWallPieceVariant newPiece, bool mirror = false, bool isDefaultInteractable = false)
	{
		Vector3 zero = Vector3.zero;
		Quaternion localRotation = Quaternion.identity;
		if (wallPieces != null)
		{
			if (index <= wallPieces.Length && wallPieces[index] == null)
			{
				zero = ((index != 0) ? defaultPositionW2 : defaultPositionW1);
			}
			else
			{
				zero = wallPieces[index].transform.localPosition;
				localRotation = wallPieces[index].transform.localRotation;
				Object.Destroy(wallPieces[index]);
			}
			wallPieces[index] = Object.Instantiate(newPiece.variant, base.transform);
			wallPieces[index].transform.localPosition = zero;
			wallPieces[index].transform.localRotation = localRotation;
			if (mirror)
			{
				wallPieces[index].transform.localScale = new Vector3(-1f, 1f, 1f);
			}
			WallInstance wallInstance = wallPieces[index].AddComponent<WallInstance>();
			wallInstance.isDefaultInteractable = isDefaultInteractable;
			wallInstance.Init(this, index, newPiece);
		}
	}

	private void ReplaceNextPart(int index, CafeWallPieceVariant newPiece)
	{
		ReplacePart(index, newPiece);
	}

	private void ReloadPillars()
	{
		CafeWallPieceVariant variantByName = cafeBuildingSet.GetVariantByName("Pillar");
		if (variantByName == null)
		{
			return;
		}
		GameObject variant = variantByName.variant;
		for (int i = 0; i < pillars.Length; i++)
		{
			if (!(pillars[i] == null))
			{
				Vector3 localPosition = pillars[i].transform.localPosition;
				Quaternion localRotation = pillars[i].transform.localRotation;
				Object.Destroy(pillars[i]);
				pillars[i] = Object.Instantiate(variant, base.transform);
				pillars[i].transform.localPosition = localPosition;
				pillars[i].transform.localRotation = localRotation;
			}
		}
	}
}
