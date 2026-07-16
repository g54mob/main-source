using UnityEngine;

[CreateAssetMenu(fileName = "MapResources", menuName = "ScriptableObjects/MapResources")]
public class MapResources : ScriptableObject
{
	public GameObject UICanvas;

	public GameObject mapNodePrefab;

	public GameObject mapLinePrefab;

	public GameObject trainIconPrefab;

	public GameObject markerIconPrefab;

	public Material dotsMat;

	public Material dotsMovingMat;

	public Sprite bossIcon;

	public Sprite hubIcon;

	public Sprite nodeDot;

	public AudioClip mapSound;
}
