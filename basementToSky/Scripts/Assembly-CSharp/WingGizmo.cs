using System;
using UnityEngine;

public class WingGizmo : MonoBehaviour
{
	public GameObject wingGO;

	public WingLineGizmo lineGizmo;

	private Vector3 originRot;

	private Vector3 originSize;

	public bool selected;

	private float targetAngle;

	private float currentAngle;

	private float rotationSpeed = 5f;

	public static event Action OnWingRotated;

	private void Start()
	{
		originSize = base.transform.localScale;
		selected = false;
		if (base.transform.childCount > 0)
		{
			lineGizmo = base.transform.GetComponentInChildren<WingLineGizmo>();
		}
	}

	public void SetOriginRot()
	{
		if (wingGO != null)
		{
			Debug.Log("C");
			originRot = wingGO.transform.localEulerAngles;
			currentAngle = originRot.z;
		}
	}

	public void SetWingRotation(float angle)
	{
		if (wingGO != null)
		{
			targetAngle = angle;
			WingGizmo.OnWingRotated?.Invoke();
		}
	}

	public void RotateWing()
	{
		if (wingGO != null)
		{
			currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * rotationSpeed);
			wingGO.transform.localRotation = Quaternion.Euler(originRot.x, originRot.y, currentAngle);
		}
	}

	public void ConnectWing(GameObject go)
	{
		wingGO = go.transform.parent.gameObject;
		originRot = wingGO.transform.localEulerAngles;
		lineGizmo.Connect(base.transform, go.transform.position);
	}

	public void StartConneting(GameObject winglineGizmoPrefab)
	{
		if (wingGO != null)
		{
			UnityEngine.Object.Destroy(lineGizmo.gameObject);
			wingGO = null;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(winglineGizmoPrefab, base.transform);
		lineGizmo = gameObject.GetComponent<WingLineGizmo>();
	}

	public void Connecting(Vector3 pos)
	{
		if (lineGizmo != null)
		{
			lineGizmo.Connect(base.transform, pos);
		}
	}

	public void DoneConnecting()
	{
		if (lineGizmo != null)
		{
			UnityEngine.Object.Destroy(lineGizmo.gameObject);
			lineGizmo = null;
		}
	}

	public void Reset()
	{
		if (wingGO != null)
		{
			wingGO.transform.localRotation = Quaternion.Euler(originRot.x, originRot.y, originRot.z);
		}
	}

	public void SetHover(bool isHovered)
	{
		base.transform.localScale = (isHovered ? (originSize * 1.2f) : originSize);
	}
}
