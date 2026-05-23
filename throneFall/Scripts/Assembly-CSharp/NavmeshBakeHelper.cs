using UnityEngine;

public class NavmeshBakeHelper : MonoBehaviour
{
	[SerializeField]
	private GameObject invisibleWalls;

	[SerializeField]
	private GameObject flyerSurface;

	[SerializeField]
	private Vector3 center;

	[SerializeField]
	private Vector3 size;

	[SerializeField]
	private Vector3 rotation;

	[SerializeField]
	private float minRegionSize = 5000f;

	[SerializeField]
	private float minRegionSizeAir = 3000f;
}
