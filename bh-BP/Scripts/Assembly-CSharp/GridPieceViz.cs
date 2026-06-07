using System;
using FMODUnity;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class GridPieceViz
{
	public int LevelEnemyIdx;

	public Sprite Icon;

	public Sprite IconEncyclopedia;

	public EnemyMeshController MeshController;

	public AssetReferenceGameObject MeshControllerRef;

	public Vector3 IconPlacement;

	public Vector3 IconScale;

	public string DisplayName;

	[HideInInspector]
	public EventReference SFXHitVox;

	[HideInInspector]
	public EventReference SFXDeathVox;

	[HideInInspector]
	public EventReference SFXChantVox;

	public Sprite SprPreview;

	public SpriteAnimClip[] ClipNormal;

	public void Apply(GridPieceObj p)
	{
	}

	public bool HasMeshController()
	{
		return false;
	}
}
