using UnityEngine;

public class CraneRotate : MonoBehaviour
{
	public float speed;

	private void Update()
	{
		base.transform.Rotate(0f, Time.deltaTime * speed, 0f);
	}
}
