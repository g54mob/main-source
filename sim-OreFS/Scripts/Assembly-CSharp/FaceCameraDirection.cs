using UnityEngine;

public class FaceCameraDirection : MonoBehaviour
{
	public bool tankMode;

	private Transform _camTransform;

	private void OnEnable()
	{
		Camera main = Camera.main;
		if (main != null)
		{
			_camTransform = main.transform;
		}
	}

	private void LateUpdate()
	{
		if (!(_camTransform == null))
		{
			if (tankMode)
			{
				Vector3 forward = _camTransform.forward;
				forward.y = 0f;
				forward.Normalize();
				base.transform.forward = forward;
			}
			else
			{
				base.transform.forward = _camTransform.forward;
			}
		}
	}
}
