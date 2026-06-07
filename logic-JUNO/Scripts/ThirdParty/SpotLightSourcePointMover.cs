using UnityEngine;

public class SpotLightSourcePointMover : MonoBehaviour
{
	public float _fRotationSpeed;

	private void Update()
	{
		base.transform.Rotate(new Vector3(0f, Time.deltaTime * _fRotationSpeed, 0f));
	}
}
