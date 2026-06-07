using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "BuildingInfo", menuName = "Bouncer/BuildingInfo")]
public class BuildingInfo : SerializedScriptableObject
{
	public BuildingType Type;

	public BuildingCat Cat;

	public Sprite Icon;

	public Sprite[] LevelIcons;

	public BuildingMeshObj MeshPrefab;

	public BaseScaffoldObj ScaffoldPrefab;

	public ColliderType ColType;

	public Vector2Int TileSize;

	public bool[,] InnerGrid;

	public float NumTiles;

	public Vector2[] PolyColPoints;

	[HideInInspector]
	public Vector2[] PolyColPointsScaled;

	public Cost BuildCost;

	public Cost BaseUpgradeCost;

	public string Name;

	[TextArea]
	public string BuildDesc;

	[TextArea]
	public string Desc;

	[TextArea]
	public string UpgradeDesc;

	public int NumScaffoldBounces;

	[HideInInspector]
	public string Slug;

	public bool IsInGame;

	public int MinVersion;

	public float SortOrder;

	public float UnlockOrder;

	public Vector3 IconMeshPlacement;

	public Vector3 IconMeshScale;

	public Quaternion IconMeshRot;

	[FormerlySerializedAs("SfxPalette")]
	[Header("SFX")]
	public BuildingSFXPalette SFXPalette;

	public BuildingSFXPalette[] LayeredSFX;

	public void GenerateSlug()
	{
	}

	public string GetUpgradeSlug(int lvl)
	{
		return null;
	}

	public string GetNameSlug()
	{
		return null;
	}

	public string GetBuildDescSlug()
	{
		return null;
	}

	public string GetDescSlug()
	{
		return null;
	}

	public string GetUpgradeDescSlug()
	{
		return null;
	}

	public void ApplyDescParams(LocalizationParamsManager locParams, int lvl, bool isUpgrade)
	{
	}

	public void ApplyDesc(Localize loc, LocalizationParamsManager locParams, int lvl, bool isBuild = false)
	{
	}

	public void ApplyUpgradeDesc(Localize loc, LocalizationParamsManager locParams, BuildingInst bInst)
	{
	}

	public void ExportLoc(LanguageSourceAsset loc)
	{
	}

	public StatType GetStatBonus()
	{
		return default(StatType);
	}

	public int GetStatBonusAmt(int lvl)
	{
		return 0;
	}

	public Cost GetCost()
	{
		return null;
	}

	public bool CanBuildMore()
	{
		return false;
	}

	public bool CanDropBlueprint()
	{
		return false;
	}

	public int GetMaxBuildingInst()
	{
		return 0;
	}

	public bool HasMesh()
	{
		return false;
	}

	public int GetSubCat()
	{
		return 0;
	}

	public BlueprintInst GetBlueprintInst()
	{
		return null;
	}

	private bool IsInInnerGrid(int x, int y)
	{
		return false;
	}

	private void OnValidate()
	{
	}

	public bool IncludeInGame()
	{
		return false;
	}
}
