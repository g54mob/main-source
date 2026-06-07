using UnityEngine;

public class UISpinner : MonoBehaviour
{
	[SerializeField]
	private float spinSpeed;

	[SerializeField]
	private Vector3 axis;

	private void Update()
	{
		base.transform.Rotate(axis * (spinSpeed * Time.deltaTime));
	}
}
