using UnityEngine;

public class HumiditySphere_LootAtCamera : MonoBehaviour
{
	private Camera camera;

	private void Start()
	{
		camera = Camera.main;
	}

	private void Update()
	{
		base.transform.forward = camera.transform.position - base.transform.position;
	}
}
