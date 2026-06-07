using UnityEngine;

public class SurfaceToPlace : MonoBehaviour
{
	[SerializeField]
	private Transform topPointTransform;

	private void Start()
	{
	}

	public Transform GetTopPointTransform()
	{
		return topPointTransform;
	}
}
