using UnityEngine;

public class Demo_FreeCam : MonoBehaviour
{
	[Header("Focus Object")]
	[SerializeField]
	[Tooltip("Enable double-click to focus on objects?")]
	private bool doFocus;

	[SerializeField]
	private float focusLimit = 100f;

	[SerializeField]
	private float minFocusDistance = 5f;

	private float doubleClickTime = 0.15f;

	private float cooldown;

	[Header("Undo - Only undoes the Focus Object - The keys must be pressed in order.")]
	[SerializeField]
	private KeyCode firstUndoKey = KeyCode.LeftControl;

	[SerializeField]
	private KeyCode secondUndoKey = KeyCode.Z;

	[Header("Movement")]
	[SerializeField]
	private float moveSpeed = 1f;

	[SerializeField]
	private float rotationSpeed = 10f;

	[SerializeField]
	private float zoomSpeed = 10f;

	private Quaternion prevRot;

	private Vector3 prevPos;

	[Header("Axes Names")]
	[SerializeField]
	[Tooltip("Otherwise known as the vertical axis")]
	private string mouseY = "Mouse Y";

	[SerializeField]
	[Tooltip("AKA horizontal axis")]
	private string mouseX = "Mouse X";

	[SerializeField]
	[Tooltip("The axis you want to use for zoom.")]
	private string zoomAxis = "Mouse ScrollWheel";

	[Header("Move Keys")]
	[SerializeField]
	private KeyCode forwardKey = KeyCode.W;

	[SerializeField]
	private KeyCode backKey = KeyCode.S;

	[SerializeField]
	private KeyCode leftKey = KeyCode.A;

	[SerializeField]
	private KeyCode rightKey = KeyCode.D;

	[Header("Flat Move")]
	[Tooltip("Instead of going where the camera is pointed, the camera moves only on the horizontal plane (Assuming you are working in 3D with default preferences).")]
	[SerializeField]
	private KeyCode flatMoveKey = KeyCode.LeftShift;

	[Header("Anchored Movement")]
	[Tooltip("By default in scene-view, this is done by right-clicking for rotation or middle mouse clicking for up and down")]
	[SerializeField]
	private KeyCode anchoredMoveKey = KeyCode.Mouse2;

	[SerializeField]
	private KeyCode anchoredRotateKey = KeyCode.Mouse1;

	private void Start()
	{
		SavePosAndRot();
	}

	private void Update()
	{
		if (doFocus)
		{
			if (cooldown > 0f && Input.GetKeyDown(KeyCode.Mouse0))
			{
				FocusObject();
			}
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				cooldown = doubleClickTime;
			}
			if (Input.GetKey(firstUndoKey) && Input.GetKeyDown(secondUndoKey))
			{
				GoBackToLastPosition();
			}
			cooldown -= Time.deltaTime;
		}
	}

	private void LateUpdate()
	{
		Vector3 zero = Vector3.zero;
		if (Input.GetKey(forwardKey))
		{
			zero += Vector3.forward * moveSpeed;
		}
		if (Input.GetKey(backKey))
		{
			zero += Vector3.back * moveSpeed;
		}
		if (Input.GetKey(leftKey))
		{
			zero += Vector3.left * moveSpeed;
		}
		if (Input.GetKey(rightKey))
		{
			zero += Vector3.right * moveSpeed;
		}
		if (Input.GetKey(flatMoveKey))
		{
			float y = base.transform.position.y;
			base.transform.Translate(zero);
			base.transform.position = new Vector3(base.transform.position.x, y, base.transform.position.z);
			return;
		}
		float axis = Input.GetAxis(mouseY);
		float axis2 = Input.GetAxis(mouseX);
		if (Input.GetKey(anchoredMoveKey))
		{
			zero += Vector3.up * axis * (0f - moveSpeed);
			zero += Vector3.right * axis2 * (0f - moveSpeed);
		}
		if (Input.GetKey(anchoredRotateKey))
		{
			base.transform.RotateAround(base.transform.position, base.transform.right, axis * (0f - rotationSpeed));
			base.transform.RotateAround(base.transform.position, Vector3.up, axis2 * rotationSpeed);
		}
		base.transform.Translate(zero);
		float axis3 = Input.GetAxis(zoomAxis);
		base.transform.Translate(Vector3.forward * axis3 * zoomSpeed);
	}

	private void FocusObject()
	{
		SavePosAndRot();
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, focusLimit))
		{
			GameObject gameObject = hitInfo.collider.gameObject;
			Vector3 position = gameObject.transform.position;
			Vector3 size = hitInfo.collider.bounds.size;
			base.transform.position = position + GetOffset(position, size);
			base.transform.LookAt(gameObject.transform);
		}
	}

	private void SavePosAndRot()
	{
		prevRot = base.transform.rotation;
		prevPos = base.transform.position;
	}

	private void GoBackToLastPosition()
	{
		base.transform.position = prevPos;
		base.transform.rotation = prevRot;
	}

	private Vector3 GetOffset(Vector3 targetPos, Vector3 targetSize)
	{
		Vector3 vector = targetPos - base.transform.position;
		float num = Mathf.Max(targetSize.x, targetSize.z);
		num = Mathf.Clamp(num, minFocusDistance, num);
		return -vector.normalized * num;
	}
}
