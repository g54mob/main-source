using MeshXtensions;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Rail track BaseType asset")]
public class BaseType : ScriptableObject
{
	[Header("Base")]
	public Shape baseShape;

	public Material baseMaterial;

	public float baseOffset;

	public UVType basePathUV;

	public float basePathUVScale = 0.1f;

	public UVType baseShapeUV;

	public float baseShapeUVScale = 0.1f;

	public float baseKinkFrequency = 0.3f;

	public float baseKinkScale;

	[Header("Sleepers")]
	[Tooltip("Objects to be instantiated for sleepers")]
	public GameObject[] sleeperPrefabs;

	[Tooltip("Forward facing or backward facing will be randomized")]
	public bool randomizeDirection = true;

	public float sleeperDistance = 0.75f;

	public float sleeperVerticalOffset = -0.1f;

	[Header("Anchors")]
	[Tooltip("Objects to be instantiated for anchors")]
	public GameObject[] anchorPrefabs;

	[Tooltip("Forward facing or backward facing will be randomized")]
	public bool randomizeAnchorDirection = true;

	public float anchorVerticalOffset = -0.1f;

	[Header("Colliders")]
	public GameObject collidersPrefab;
}
