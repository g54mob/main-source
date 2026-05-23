using UnityEngine;

[ExecuteAlways]
public class Spinner : MonoBehaviour
{
	[SerializeField]
	private Vector3 _rotationSpeed;

	[SerializeField]
	private bool _inEditor;

	private Vector3 _currentSpeed;

	private void Start()
	{
		ResetToDefaultSpeed();
	}

	private void Update()
	{
		if (Application.isPlaying || _inEditor)
		{
			base.transform.rotation = Quaternion.Euler(base.transform.eulerAngles + _currentSpeed * Time.deltaTime);
		}
	}

	public void SetSpeed(Vector3 newRotationSpeed)
	{
		_currentSpeed = newRotationSpeed;
	}

	public void ResetToDefaultSpeed()
	{
		_currentSpeed = _rotationSpeed;
	}
}
