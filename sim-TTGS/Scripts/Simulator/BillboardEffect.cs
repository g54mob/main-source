using UnityEngine;
using UnityEngine.Animations;

public class BillboardEffect : MonoBehaviour
{
	private Camera _camera;

	[SerializeField]
	private Axis _axisToRotate = (Axis)(-1);

	private void Awake()
	{
		_camera = Camera.main;
	}

	private void Start()
	{
		if (_camera == null)
		{
			Debug.LogError("No main camera found");
			base.enabled = false;
		}
		if (_axisToRotate == Axis.None)
		{
			Debug.LogWarning("No axis to rotate was specified. The object will not rotate to face the camera.");
			base.enabled = false;
		}
	}

	private void Update()
	{
		Quaternion rotation = Quaternion.LookRotation((base.transform.position - _camera.transform.position).normalized);
		if (_axisToRotate != (Axis)(-1))
		{
			Vector3 eulerAngles = rotation.eulerAngles;
			if (!_axisToRotate.HasFlag(Axis.X))
			{
				eulerAngles.x = 0f;
			}
			if (!_axisToRotate.HasFlag(Axis.Y))
			{
				eulerAngles.y = 0f;
			}
			if (!_axisToRotate.HasFlag(Axis.Z))
			{
				eulerAngles.z = 0f;
			}
			rotation = Quaternion.Euler(eulerAngles);
		}
		base.transform.rotation = rotation;
	}
}
