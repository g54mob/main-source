using UnityEngine;

public class CameraPositionLimit : MonoBehaviour
{
	[SerializeField]
	private float rangeLimit;

	private Vector3 startPos;

	private Vector3 lastFramePosition;

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}
}
