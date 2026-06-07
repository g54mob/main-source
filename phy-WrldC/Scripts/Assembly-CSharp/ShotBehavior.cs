using UnityEngine;

public class ShotBehavior : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		base.transform.position += base.transform.forward * Time.deltaTime * 1000f;
	}
}
