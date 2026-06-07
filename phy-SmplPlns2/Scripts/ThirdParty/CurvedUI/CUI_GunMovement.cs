using UnityEngine;

namespace CurvedUI
{
	public class CUI_GunMovement : MonoBehaviour
	{
		[SerializeField]
		private CurvedUISettings mySettings;

		[SerializeField]
		private Transform pivot;

		[SerializeField]
		private float sensitivity = 0.1f;

		private Vector3 lastMouse;

		private void Start()
		{
			lastMouse = Input.mousePosition;
		}

		private void Update()
		{
			Vector3 vector = Input.mousePosition - lastMouse;
			lastMouse = Input.mousePosition;
			pivot.localEulerAngles += new Vector3(0f - vector.y, vector.x, 0f) * sensitivity;
			CurvedUIInputModule.CustomControllerRay = new Ray(base.transform.position, base.transform.forward);
			CurvedUIInputModule.CustomControllerButtonState = Input.GetButton("Fire1");
		}
	}
}
