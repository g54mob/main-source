using UnityEngine;

public class Spinner : MonoBehaviour
{
	[SerializeField]
	private Vector3 spinSpeed;

	private Quaternion rotationIncrement;

	private void Update()
	{
		base.transform.Rotate(spinSpeed * Time.deltaTime);
	}
}
