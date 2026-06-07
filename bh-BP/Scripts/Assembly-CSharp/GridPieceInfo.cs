using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "GridPieceInfo", menuName = "Bouncer/GridPieceInfo")]
public class GridPieceInfo : SerializedScriptableObject
{
	public GridPieceType Type;

	public string DisplayName;

	public string Desc;

	public string GameplayDesc;

	[HideInInspector]
	public string Slug;

	[NamedArray(typeof(LevelType))]
	public GridPieceViz[] Viz;

	public Sprite SprShadow;

	public Vector3 ShadowScale;

	public Vector3 ShadowPlacement;

	public Vector3 ShadowCreatePlacement;

	public float GridWidth;

	public float GridHeight;

	public float HealthScale;

	public float SpeedMult;

	public GridPieceObj Prefab;

	public AssetReferenceGameObject PrefabRef;

	private int GetVizIdx(LevelType lvl)
	{
		return 0;
	}

	public GridPieceViz GetCurViz()
	{
		return null;
	}

	public GridPieceViz GetViz(LevelType lt)
	{
		return null;
	}

	public Sprite GetSprPreview(LevelType lvl)
	{
		return null;
	}

	public SpriteAnimClip GetClipNormal(LevelType lvl, float healthPct)
	{
		return null;
	}

	public float GetSpeedMult()
	{
		return 0f;
	}

	public float GetMaxGridDimension()
	{
		return 0f;
	}

	public string GetNameSlug(int lvlIdx)
	{
		return null;
	}

	public void ExportLoc(LanguageSourceAsset loc)
	{
	}

	public string GetGameplayDescSlug()
	{
		return null;
	}

	public bool HasAltMeshes()
	{
		return false;
	}

	public int GetAltMeshIdx(LevelType t)
	{
		return 0;
	}
}
