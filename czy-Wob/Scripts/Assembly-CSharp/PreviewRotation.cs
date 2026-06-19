using UnityEngine;

public class PreviewRotation : MonoBehaviour
{
	public Vector3 rotationSpeed = new Vector3(180f, 0f, 0f);

	private void Update()
	{
		base.transform.Rotate(rotationSpeed * Time.deltaTime);
	}
}
