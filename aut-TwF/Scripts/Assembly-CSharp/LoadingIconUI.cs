using UnityEngine;

public class LoadingIconUI : MonoBehaviour
{
	private float rotationSpeed = -210f;

	private void Update()
	{
		base.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
	}
}
