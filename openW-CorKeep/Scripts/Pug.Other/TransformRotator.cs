using UnityEngine;

public class TransformRotator : MonoBehaviour
{
	public Vector3 rate = new Vector3(90f, 0f, 0f);

	private void OnEnable()
	{
		float num = 6.28318f * Random.value;
		base.transform.Rotate(rate * num);
	}

	private void Update()
	{
		base.transform.Rotate(rate * Time.deltaTime);
	}
}
