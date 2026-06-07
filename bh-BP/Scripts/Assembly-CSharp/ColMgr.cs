using System.Collections.Generic;
using UnityEngine;

public class ColMgr : MonoBehaviour
{
	public static ColMgr I;

	public static string[] kSortLayerNames;

	public static int[] kSortLayerIds;

	public static string[] kGameLayerNames;

	public static int[] kGameLayerIds;

	public static int kLayerMaskBounce;

	public static int kLayerMaskEmbeddedBounce;

	public static int kLayerMaskAITargeting;

	public static int kLayerMaskPickup;

	public static int kLayerMaskEnemies;

	public static int kLayerMaskEnemyPlacement;

	public static int kLayerMaskEnemyAndObstacles;

	public static int kLayerMaskAllBuildings;

	public static int kLayerMaskAllBaseObstacles;

	public static int kLayerMaskBaseChars;

	public static int kLayerMaskWall;

	public static int kLayerMaskAllBase;

	public static int kLayerMaskProjectileMarker;

	public static int kLayerMaskProjectiles;

	public static int kLayerMaskProjectiles2D;

	public static int kLayerMaskDangerMarker;

	public static int kLayerMaskCannonMarker;

	public static int kLayerMaskObstacles;

	public static int kLayerMaskViewPlane;

	public static int kLayerMaskPlayerObstacles;

	public static int kLayerMaskPlayer;

	public static int kLayerMaskMiscBallHits;

	public List<Collider2D[]> ColAlloc;

	public List<bool> ColAllocAvail;

	public List<ContactPoint2D[]> ContactPtAlloc;

	public List<bool> ContactPtAvail;

	public List<RaycastHit2D[]> RaycastAlloc;

	public List<bool> RaycastAvail;

	private ContactFilter2D _filt;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnSceneAboutToChange()
	{
	}

	public int GetSortLayer(SortLayerType st)
	{
		return 0;
	}

	public int GetGameLayer(GameLayerType gt)
	{
		return 0;
	}

	public int GetLayerMask(params GameLayerType[] types)
	{
		return 0;
	}

	public int OverlapCollider(Collider2D col, int layerMask, out int colIdx)
	{
		colIdx = default(int);
		return 0;
	}

	public int OverlapCollider(Collider2D col, int layerMask, int colIdx)
	{
		return 0;
	}

	public int GetContacts(Collider2D col, int layerMask, out int cpIdx)
	{
		cpIdx = default(int);
		return 0;
	}

	public int GetAvailColAlloc()
	{
		return 0;
	}

	public void ReleaseColAlloc(int idx)
	{
	}

	public int GetAvailContactPts()
	{
		return 0;
	}

	public void ReleaseContactPts(int idx)
	{
	}

	public int GetAvailRaycastHit()
	{
		return 0;
	}

	public void ReleaseRaycastHit(int idx)
	{
	}

	public GameLayerType GetGameLayer(int layerId)
	{
		return default(GameLayerType);
	}
}
