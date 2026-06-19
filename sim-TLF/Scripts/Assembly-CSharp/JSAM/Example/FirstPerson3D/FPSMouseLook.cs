using UnityEngine;

namespace JSAM.Example.FirstPerson3D
{
	public class FPSMouseLook : MonoBehaviour
	{
		[SerializeField]
		public float speed = 3f;

		private float rotationX;

		private float rotationY;

		private Transform stand;

		private void Start()
		{
			stand = base.transform.parent;
		}

		private void Update()
		{
			if (Cursor.lockState == CursorLockMode.Locked)
			{
				rotationY += Input.GetAxis("Mouse X") * speed;
				rotationX += (0f - Input.GetAxis("Mouse Y")) * speed;
				rotationX = Mathf.Clamp(rotationX, -90f, 90f);
				stand.localEulerAngles = new Vector3(0f, rotationY, 0f);
				base.transform.localEulerAngles = new Vector3(rotationX, 0f, 0f);
			}
		}
	}
}
