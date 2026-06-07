using UnityEngine;
using UnityEngine.UI;

public class FovChanger : MonoBehaviour
{
	public Text text;

	public Camera[] Cameras;

	private void Update()
	{
		float axis = Input.GetAxis("Vertical");
		float num = 0f;
		Camera[] cameras = Cameras;
		foreach (Camera obj in cameras)
		{
			obj.fieldOfView += axis;
			num = obj.fieldOfView;
		}
		text.text = num.ToString("{0.00}");
	}
}
