using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MousePointAtSwitch : MonoBehaviour
{
	private VisualSwitch currentSwitch;

	private Camera cam;

	private void Start()
	{
		cam = GetComponent<Camera>();
	}

	private void Update()
	{
		if (currentSwitch != null && Input.GetMouseButtonDown(0))
		{
			currentSwitch.Switch();
		}
	}

	private void FixedUpdate()
	{
		if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hitInfo, float.PositiveInfinity, LayerMask.GetMask("Laser_Pointer_Target")))
		{
			currentSwitch = hitInfo.collider.GetComponent<VisualSwitch>();
		}
		else
		{
			currentSwitch = null;
		}
	}
}
