using UnityEngine;

public class SimpleForwardMove : MonoBehaviour
{
	[SerializeField]
	private float speed = 5f;

	private void Start()
	{
	}

	private void Update()
	{
		base.transform.position += base.transform.forward * speed * Time.deltaTime;
	}
}
