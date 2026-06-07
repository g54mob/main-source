using System;
using UnityEngine;

public class TransformGizmoEvents
{
	private Ray mouseRay;

	private RaycastHit objectRaycastHit;

	private Vector3 firstMousePosition;

	private Vector3 currentMousePosition;

	private Vector3 gizmoInitialPosition;

	private Vector3 creationInitialPosition;

	private Vector3 creationCenterInitialPosition;

	private Bounds creationBounds;

	private readonly GameObject transformGizmoObject;

	private readonly GameObject cameraObject;

	private GameObject currentArrowObject;

	private GameObject lastArrowObject;

	private Color originalColor;

	private Color highlightedColor;

	private int arrowId;

	private bool isDraggingActive;

	private const float SmoothDragFactor = 100f;

	private CreationController creationController;

	private GameObject constructionZone;

	public bool IsWithoutDelimitationZone { get; set; }

	public event Action<int, float, float> OnMouseDragging;

	public event Action<Vector3, Quaternion> OnPositionChanged;

	public TransformGizmoEvents(GameObject transformGizmoObject, GameObject cameraObject)
	{
		this.transformGizmoObject = transformGizmoObject;
		this.cameraObject = cameraObject;
		highlightedColor = Color.yellow;
		isDraggingActive = false;
		IsWithoutDelimitationZone = false;
	}

	public void Start(CreationController creationController, GameObject constructionZone)
	{
		this.creationController = creationController;
		this.constructionZone = constructionZone;
		isDraggingActive = false;
		transformGizmoObject.SetActive(value: true);
		transformGizmoObject.transform.position = creationController.view.GetCreationBounds().center;
	}

	public void Stop()
	{
		transformGizmoObject.SetActive(value: false);
	}

	public void Run()
	{
		currentMousePosition = Input.mousePosition;
		mouseRay = Camera.main.ScreenPointToRay(currentMousePosition);
		bool flag = Physics.Raycast(mouseRay, out objectRaycastHit, 100f, LayerNames.Button3DMask);
		if (!isDraggingActive)
		{
			if (flag)
			{
				currentArrowObject = objectRaycastHit.collider.gameObject;
				if (currentArrowObject.name == "ArrowX" || currentArrowObject.name == "ArrowY" || currentArrowObject.name == "ArrowZ")
				{
					if (currentArrowObject != lastArrowObject)
					{
						if (lastArrowObject != null)
						{
							lastArrowObject.GetComponent<Renderer>().material.color = originalColor;
						}
						Renderer component = currentArrowObject.GetComponent<Renderer>();
						originalColor = component.material.color;
						component.material.color = highlightedColor;
					}
					lastArrowObject = currentArrowObject;
				}
				else
				{
					currentArrowObject = null;
				}
			}
			else if (currentArrowObject != null)
			{
				currentArrowObject.GetComponent<Renderer>().material.color = originalColor;
				currentArrowObject = null;
				lastArrowObject = null;
			}
		}
		if (Input.GetKey(KeyCode.Mouse0))
		{
			if (flag && currentArrowObject != null && !isDraggingActive)
			{
				if (currentArrowObject.name == "ArrowX")
				{
					arrowId = 0;
				}
				else if (currentArrowObject.name == "ArrowY")
				{
					arrowId = 1;
				}
				else if (currentArrowObject.name == "ArrowZ")
				{
					arrowId = 2;
				}
				gizmoInitialPosition = transformGizmoObject.transform.position;
				creationBounds = creationController.view.GetCreationBounds();
				creationInitialPosition = creationController.view.transform.position;
				creationCenterInitialPosition = creationBounds.center;
				firstMousePosition = Input.mousePosition;
				isDraggingActive = true;
			}
			if (!isDraggingActive)
			{
				return;
			}
			float num = (firstMousePosition.x - currentMousePosition.x) / 100f;
			float num2 = (firstMousePosition.y - currentMousePosition.y) / 100f;
			float x = cameraObject.transform.forward.x;
			float y = cameraObject.transform.forward.y;
			float z = cameraObject.transform.forward.z;
			float x2 = cameraObject.transform.up.x;
			_ = cameraObject.transform.up;
			float z2 = cameraObject.transform.up.z;
			if (arrowId == 0)
			{
				float num3 = (num * z + num2 * x) * (1f - y) + (num * z2 + num2 * x2) * (0f - y);
				float num4 = creationCenterInitialPosition.x - num3;
				float x3 = creationBounds.extents.x;
				float num5 = constructionZone.transform.localScale.x / 2f;
				float num6 = num5 + constructionZone.transform.position.x;
				float num7 = num5 - constructionZone.transform.position.x;
				transformGizmoObject.transform.SetPositionX(gizmoInitialPosition.x - num3);
				if ((num4 + x3 < num6 && num4 - x3 > 0f - num7) || IsWithoutDelimitationZone)
				{
					creationController.view.transform.SetPositionX(creationInitialPosition.x - num3);
					return;
				}
				if (num4 + creationBounds.extents.x > num6)
				{
					creationController.view.transform.SetPositionX(creationInitialPosition.x + (num6 - creationCenterInitialPosition.x) - x3);
				}
				if (num4 - creationBounds.extents.x < 0f - num7)
				{
					creationController.view.transform.SetPositionX(creationInitialPosition.x + (0f - num7 - creationCenterInitialPosition.x) + x3);
				}
			}
			else if (arrowId == 1)
			{
				float num8 = num2;
				float num9 = creationCenterInitialPosition.y - num8;
				float y2 = creationBounds.extents.y;
				float num10 = constructionZone.transform.localScale.y / 2f;
				float num11 = num10 + constructionZone.transform.position.y;
				float num12 = num10 - constructionZone.transform.position.y;
				transformGizmoObject.transform.SetPositionY(gizmoInitialPosition.y - num8);
				if ((num9 + y2 < num11 && num9 - y2 > 0f - num12) || IsWithoutDelimitationZone)
				{
					creationController.view.transform.SetPositionY(creationInitialPosition.y - num8);
					return;
				}
				if (num9 + creationBounds.extents.y > num11)
				{
					creationController.view.transform.SetPositionY(creationInitialPosition.y + (num11 - creationCenterInitialPosition.y) - y2);
				}
				if (num9 - creationBounds.extents.y < 0f - num12)
				{
					creationController.view.transform.SetPositionY(creationInitialPosition.y + (0f - num12 - creationCenterInitialPosition.y) + y2);
				}
			}
			else
			{
				if (arrowId != 2)
				{
					return;
				}
				float num13 = (num * (0f - x) + num2 * z) * (1f - y) + (num * (0f - x2) + num2 * z2) * (0f - y);
				float num14 = creationCenterInitialPosition.z - num13;
				float z3 = creationBounds.extents.z;
				float num15 = constructionZone.transform.localScale.z / 2f;
				float num16 = num15 + constructionZone.transform.position.z;
				float num17 = num15 - constructionZone.transform.position.z;
				transformGizmoObject.transform.SetPositionZ(gizmoInitialPosition.z - num13);
				if ((num14 + z3 < num16 && num14 - z3 > 0f - num17) || IsWithoutDelimitationZone)
				{
					creationController.view.transform.SetPositionZ(creationInitialPosition.z - num13);
					return;
				}
				if (num14 + creationBounds.extents.z > num16)
				{
					creationController.view.transform.SetPositionZ(creationInitialPosition.z + (num16 - creationCenterInitialPosition.z) - z3);
				}
				if (num14 - creationBounds.extents.z < 0f - num17)
				{
					creationController.view.transform.SetPositionZ(creationInitialPosition.z + (0f - num17 - creationCenterInitialPosition.z) + z3);
				}
			}
			return;
		}
		if (isDraggingActive)
		{
			transformGizmoObject.transform.position = creationController.view.GetCreationBounds().center;
			if (this.OnPositionChanged != null)
			{
				this.OnPositionChanged(creationController.view.transform.localPosition, creationController.view.transform.localRotation);
			}
		}
		isDraggingActive = false;
	}
}
