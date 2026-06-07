using UnityEngine;

public class SimpleRotator : MonoBehaviour
{
	public Vector3 rotationDelta;

	public Space relativeTo;

	public bool randomYRotationOnEnable;

	private void OnEnable()
	{
		if (randomYRotationOnEnable)
		{
			base.transform.Rotate(Vector3.up * Random.value * 360f, Space.World);
		}
	}

	private void Update()
	{
		base.transform.Rotate(rotationDelta * Time.deltaTime, relativeTo);
	}
}
