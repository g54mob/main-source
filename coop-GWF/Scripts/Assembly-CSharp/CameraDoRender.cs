using UnityEngine;

public class CameraDoRender : MonoBehaviour
{
	private void Awake()
	{
		TryGetComponent<Camera>(out var component);
		component.Render();
	}
}
