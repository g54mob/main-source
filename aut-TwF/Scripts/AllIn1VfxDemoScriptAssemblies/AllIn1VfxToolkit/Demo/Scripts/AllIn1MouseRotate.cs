using UnityEngine;
using UnityEngine.UI;

namespace AllIn1VfxToolkit.Demo.Scripts
{
	public class AllIn1MouseRotate : MonoBehaviour
	{
		[SerializeField]
		private Transform objectToRotate;

		[SerializeField]
		private float rotationSpeedHorizontal = 10f;

		[SerializeField]
		private float translateVerticalSpeed = 5f;

		[SerializeField]
		private float translateScrollSpeed = 2f;

		[Space]
		[Header("Lock Cursor")]
		[SerializeField]
		private bool lockCursor;

		[SerializeField]
		private KeyCode lockCursorKeyCode;

		[SerializeField]
		private AllIn1DemoScaleTween hideUiButtonTween;

		[SerializeField]
		private Image lockedButtonImage;

		[SerializeField]
		private Text lockedButtonText;

		[SerializeField]
		private Color lockedButtonColor;

		private bool cursorIsLocked;

		[Space]
		[Header("Movement Bounds")]
		[SerializeField]
		private float maxHeight = 40f;

		[SerializeField]
		private float maxZoom = 2f;

		[SerializeField]
		private float minZoom = 40f;

		private Vector3 currPosition = Vector3.zero;

		private float dt;

		private void Start()
		{
			if (lockCursor)
			{
				cursorIsLocked = false;
			}
			else
			{
				cursorIsLocked = true;
			}
			ToggleCursorLocked();
		}

		private void Update()
		{
			if (!(Time.timeSinceLevelLoad < 0.5f))
			{
				dt = Time.unscaledDeltaTime;
				CamRotateAroundYAxis();
				currPosition = objectToRotate.position;
				CamHeightTranslate();
				CamZoom();
				if (Input.GetKeyDown(lockCursorKeyCode))
				{
					ToggleCursorLocked();
				}
			}
		}

		private void CamRotateAroundYAxis()
		{
			float angle = Input.GetAxis("Mouse X") * dt * 10f * rotationSpeedHorizontal;
			objectToRotate.RotateAround(base.transform.position, Vector3.up, angle);
		}

		private void CamHeightTranslate()
		{
			float num = Input.GetAxis("Mouse Y") * dt * translateVerticalSpeed;
			currPosition.y = Mathf.Clamp(currPosition.y + num, 0.25f, maxHeight);
			objectToRotate.position = currPosition;
			objectToRotate.LookAt(base.transform);
		}

		private void CamZoom()
		{
			float num = Input.GetAxis("Mouse ScrollWheel") * dt * 100f * translateScrollSpeed;
			Vector3 vector = objectToRotate.forward * num;
			if (num > 0f && Vector3.Distance(base.transform.position, objectToRotate.position) <= maxZoom)
			{
				vector = Vector3.zero;
			}
			else if (num < 0f && Vector3.Distance(base.transform.position, objectToRotate.position) >= minZoom)
			{
				vector = Vector3.zero;
			}
			currPosition += vector;
			objectToRotate.position = currPosition;
		}

		public void ToggleCursorLocked()
		{
			cursorIsLocked = !cursorIsLocked;
			hideUiButtonTween.ScaleUpTween();
			if (cursorIsLocked)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				lockedButtonImage.color = lockedButtonColor;
				lockedButtonText.text = "Unlock Cursor";
			}
			else
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				lockedButtonImage.color = Color.white;
				lockedButtonText.text = "Lock Cursor";
			}
		}
	}
}
