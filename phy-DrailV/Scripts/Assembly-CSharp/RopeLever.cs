using UnityEngine;

public class RopeLever : MonoBehaviour
{
	public ObiRopeTension tension;

	public float minRotation;

	public float maxRotation = 33f;

	public Vector3 rotationAxis = new Vector3(1f, 0f, 0f);

	private void Update()
	{
		base.transform.localRotation = Quaternion.Euler(rotationAxis * Mathf.Lerp(minRotation, maxRotation, tension.value));
	}
}
