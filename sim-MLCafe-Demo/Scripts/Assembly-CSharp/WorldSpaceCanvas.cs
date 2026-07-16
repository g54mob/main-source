using UnityEngine;

public class WorldSpaceCanvas : MonoBehaviour
{
	[SerializeField]
	private RectTransform rectTransform;

	[SerializeField]
	private Canvas canvas;

	private void Start()
	{
		if (canvas != null)
		{
			canvas.worldCamera = GlobalReferences.GetCameraController().GetCamera();
		}
	}

	private void Update()
	{
		Vector3 forward = base.transform.position - GlobalReferences.GetCameraController().transform.position;
		forward.Normalize();
		rectTransform.rotation = Quaternion.LookRotation(forward);
	}
}
