using UnityEngine;

public class BillBoard : MonoBehaviour
{
	[SerializeField]
	private bool updateContinuously;

	[SerializeField]
	private bool changePosition;

	[SerializeField]
	private float newScale = 1f;

	[SerializeField]
	private Vector3 newLocalPosition;

	[SerializeField]
	private float zoomOffset;

	private void Start()
	{
		if (!CameraController.instance.firstPersonMode)
		{
			base.enabled = false;
			return;
		}
		base.transform.localScale = base.transform.localScale * newScale;
		Rotate();
	}

	private void Update()
	{
		if (CameraController.instance.firstPersonMode && updateContinuously)
		{
			Rotate();
		}
	}

	private void Rotate()
	{
		base.transform.rotation = Camera.main.transform.rotation;
		if (changePosition)
		{
			Vector3 vector = (Camera.main.transform.position - base.transform.parent.position + newLocalPosition).normalized * zoomOffset;
			base.transform.localPosition = newLocalPosition + vector;
		}
	}
}
