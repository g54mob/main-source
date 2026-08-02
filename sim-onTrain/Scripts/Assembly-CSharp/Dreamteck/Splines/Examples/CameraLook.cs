using UnityEngine;

namespace Dreamteck.Splines.Examples
{
	public class CameraLook : MonoBehaviour
	{
		public float sensitivity = 3f;

		public float dampSpeed;

		public float lookRange = 45f;

		private float x;

		private float y;

		private float xMove;

		private float yMove;

		private float crosshairZ = 5f;

		private float idealCrosshairZ = 3f;

		public Transform crosshairSphere;

		private void Update()
		{
			xMove = Mathf.MoveTowards(xMove, 0f, Time.deltaTime * dampSpeed);
			yMove = Mathf.MoveTowards(yMove, 0f, Time.deltaTime * dampSpeed);
			xMove += Input.GetAxis("Mouse X") / 10f;
			yMove -= Input.GetAxis("Mouse Y") / 10f;
			xMove = Mathf.Clamp(xMove, -1f, 1f);
			yMove = Mathf.Clamp(yMove, -1f, 1f);
			float num = lookRange / 2f;
			x += xMove * Time.deltaTime * sensitivity;
			y += yMove * Time.deltaTime * sensitivity;
			if (x > num)
			{
				x = num;
				if (xMove > 0f)
				{
					xMove = 0f;
				}
			}
			else if (x < 0f - num)
			{
				x = 0f - num;
				if (xMove < 0f)
				{
					xMove = 0f;
				}
			}
			if (y > num)
			{
				y = num;
				if (yMove > 0f)
				{
					yMove = 0f;
				}
			}
			else if (y < 0f - num)
			{
				y = 0f - num;
				if (yMove < 0f)
				{
					yMove = 0f;
				}
			}
			if (crosshairSphere != null && crosshairSphere.gameObject.activeSelf)
			{
				idealCrosshairZ += Input.GetAxis("Mouse ScrollWheel") * 4f;
				idealCrosshairZ = Mathf.Clamp(idealCrosshairZ, 2f, 6f);
				crosshairZ = Mathf.MoveTowards(crosshairZ, idealCrosshairZ, Time.deltaTime * 8f);
				Vector3 localPosition = crosshairSphere.localPosition;
				localPosition.z = crosshairZ;
				crosshairSphere.localPosition = localPosition;
			}
			base.transform.localRotation = Quaternion.AngleAxis(x, Vector3.up) * Quaternion.AngleAxis(y, Vector3.right);
		}
	}
}
