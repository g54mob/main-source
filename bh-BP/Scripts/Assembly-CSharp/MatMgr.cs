using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class MatMgr : SerializedMonoBehaviour
{
	public static MatMgr I;

	public Material MatPieceDefault;

	public Material[][] EnemyGPUAnimMats;

	public Material MatBabyBallDefault;

	public Material MatBabyTrailDefault;

	[NonSerialized]
	public Material[] MatBabyBallVariants;

	[NonSerialized]
	public Material[] MatBabyTrailVariants;

	public Material DefaultMatPieceMesh;

	public Material DefaultMatPieceMeshInstanced;

	public Material DefaultMatPieceMeshInstancedCrackable;

	[NamedArray(typeof(LevelType))]
	public Material[] MatPieceMesh;

	[NamedArray(typeof(LevelType))]
	public Material[] MatPieceMeshInstanced;

	[NamedArray(typeof(LevelType))]
	public Material[] MatPieceMeshInstancedCrackable;

	public Texture[] TexBlds;

	public BuildingMatSet[] BldMatSets;

	public Material MatBuildingDefault;

	public Material MatBuildingOverlay;

	public Material MatUIDefault;

	public Material MatUIOutlined;

	public Material MatUIEncycloSilhouette;

	public Material MatUIEncycloEnemySilhouette;

	[Header("Noise texture")]
	public Texture2D TexVoronoi3;

	public Texture2D TexVoronoiCracks;

	public Texture2D TexNoise1024;

	public Material[] PrecompiledMats;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnSceneAboutToChange()
	{
	}

	public void OnLvlMaterialsLoaded(LevelType lt)
	{
	}

	public Material GetMatPieceDefault(LevelType l, bool hasMesh)
	{
		return null;
	}

	public void ApplyStatusEffectProps(Material m, int hash)
	{
	}

	public void ApplyStatusEffectProps(MaterialPropertyBlock m, int hash)
	{
	}

	public void CopyEnemyMatProps(Material fromMat, Material toMat)
	{
	}

	public Material GetBabyMatVariant(HeroInfo hInf)
	{
		return null;
	}

	public Material GetBabyTrailMatVariant(HeroInfo hInf)
	{
		return null;
	}

	public void ApplySilhouette(Image img, bool isSilhouette, Color defaultColor)
	{
	}

	public Material GetGPUAnimMat(LevelType t, GridPieceInfo inf, int idx)
	{
		return null;
	}

	public bool ShouldRefreshMatForStatusEffect(StatusEffectType st)
	{
		return false;
	}
}
