using UnityEngine;

[RequireComponent(typeof(Camera))]
public class UICamera : MonoBehaviour
{
	private Camera camera;

	private void Awake()
	{
		camera = GetComponent<Camera>();
	}
}
