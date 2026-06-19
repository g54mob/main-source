using UnityEngine;

public class SpinningCube : MonoBehaviour
{
	private float spinSpeed = -90f;

	private void Update()
	{
		base.transform.Rotate(Vector3.up, spinSpeed * Time.unscaledDeltaTime);
	}
}
