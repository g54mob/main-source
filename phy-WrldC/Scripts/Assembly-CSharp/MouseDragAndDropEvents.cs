using System;
using UnityEngine;

public class MouseDragAndDropEvents
{
	private const float SurfaceLineDistance = 0.05f;

	private Ray mouseRay;

	private RaycastHit blockRaycastHit;

	private int layerMask;

	private GameObject firstGameObject;

	private GameObject secondGameObject;

	private Vector3 lineStartPoint;

	private Vector3 lineEndPoint;

	private Vector3 firstMousePosition;

	private Vector3 currentMousePosition;

	private float mouseDragDistance;

	private bool isDragAndDropActived;

	private bool isOverRestrictedZone;

	public event Action<GameObject, Vector3> OnMouseStartDrag;

	public event Action<GameObject, GameObject, Vector3, Vector3> OnMouseDragging;

	public event Action<GameObject, GameObject> OnMouseValidDrop;

	public event Action<GameObject> OnMouseInvalidDrop;

	public event Action OnMouseEndDrop;

	public event Func<bool> OnOverRestrictedZone;

	public MouseDragAndDropEvents(int layerMask)
	{
		this.layerMask = layerMask;
		firstGameObject = null;
		secondGameObject = null;
		isDragAndDropActived = false;
		isOverRestrictedZone = false;
	}

	public bool Run()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if (this.OnOverRestrictedZone != null)
			{
				isOverRestrictedZone = this.OnOverRestrictedZone();
			}
			if (!isOverRestrictedZone)
			{
				MousePressedHandler();
			}
		}
		else if (Input.GetKey(KeyCode.Mouse0))
		{
			if (!isOverRestrictedZone)
			{
				MousePressingHandler();
			}
		}
		else if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			if (!isOverRestrictedZone)
			{
				MouseReleasedHandler();
			}
			isOverRestrictedZone = false;
		}
		return isDragAndDropActived;
	}

	public void Stop()
	{
		if (isDragAndDropActived)
		{
			firstGameObject = null;
			secondGameObject = null;
			isOverRestrictedZone = false;
			MouseReleasedHandler();
		}
	}

	private GameObject MouseRaycast()
	{
		mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(mouseRay, out blockRaycastHit, 100f, layerMask))
		{
			return blockRaycastHit.collider.gameObject;
		}
		return null;
	}

	private void MousePressedHandler()
	{
		GameObject gameObject = MouseRaycast();
		if (gameObject != null)
		{
			firstGameObject = gameObject;
			firstMousePosition = Input.mousePosition;
			lineStartPoint = blockRaycastHit.point + blockRaycastHit.normal * 0.05f;
		}
	}

	private void MousePressingHandler()
	{
		if (firstGameObject == null)
		{
			return;
		}
		currentMousePosition = Input.mousePosition;
		mouseDragDistance = Vector3.Distance(firstMousePosition, currentMousePosition);
		if (!isDragAndDropActived && mouseDragDistance > 25f)
		{
			isDragAndDropActived = true;
			this.OnMouseStartDrag?.Invoke(firstGameObject, lineStartPoint);
		}
		if (!isDragAndDropActived)
		{
			return;
		}
		GameObject gameObject = MouseRaycast();
		if (gameObject != null)
		{
			if (firstGameObject == gameObject)
			{
				secondGameObject = null;
			}
			else if (firstGameObject != gameObject)
			{
				secondGameObject = gameObject;
			}
			lineEndPoint = blockRaycastHit.point + blockRaycastHit.normal * 0.05f;
		}
		else
		{
			secondGameObject = null;
			float num = Mathf.Abs(mouseRay.origin.y - lineStartPoint.y) / Mathf.Abs(mouseRay.direction.y);
			lineEndPoint = mouseRay.origin + mouseRay.direction * num;
		}
		this.OnMouseDragging?.Invoke(firstGameObject, secondGameObject, lineStartPoint, lineEndPoint);
	}

	private void MouseReleasedHandler()
	{
		if (firstGameObject != null && secondGameObject != null)
		{
			this.OnMouseValidDrop?.Invoke(firstGameObject, secondGameObject);
		}
		else if (firstGameObject != null)
		{
			this.OnMouseInvalidDrop?.Invoke(firstGameObject);
		}
		this.OnMouseEndDrop?.Invoke();
		firstGameObject = null;
		secondGameObject = null;
		isDragAndDropActived = false;
	}
}
