using UnityEngine;
using UnityEngine.InputSystem;

public class PartsCustomGizmo : MonoBehaviour
{
	public enum GizmoType
	{
		TranslateOffset = 0,
		ScaleRing = 1
	}

	[Header("Settings")]
	public CustomCrafitng craftingSystem;

	public Material clickedMat;

	private Material originalMat;

	public int targetRingIndex;

	public GizmoType gizmoType;

	public float scaleSensitivity = 1f;

	private Camera mainCam;

	private bool isDragging;

	private Plane dragPlane;

	private Vector3 startDragPoint;

	private float startOffset;

	private float startScale;

	private Vector3 dragAxis;

	private Renderer myRenderer;

	private void Start()
	{
		mainCam = Camera.main;
		myRenderer = GetComponent<Renderer>();
		if (!(myRenderer == null))
		{
			originalMat = myRenderer.sharedMaterial;
		}
	}

	private void Update()
	{
		if (Mouse.current != null)
		{
			HandleMouseInput();
			UpdateGizmoPosition();
		}
	}

	private void HandleMouseInput()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		Ray ray = mainCam.ScreenPointToRay(vector);
		if (!isDragging)
		{
			if (Physics.Raycast(ray, out var hitInfo, float.PositiveInfinity, LayerMask.GetMask("Gizmo")) && hitInfo.collider.gameObject == base.gameObject)
			{
				myRenderer.sharedMaterial = clickedMat;
			}
			else
			{
				myRenderer.sharedMaterial = originalMat;
			}
		}
		if (Mouse.current.leftButton.wasPressedThisFrame && Physics.Raycast(ray, out var hitInfo2, float.PositiveInfinity, LayerMask.GetMask("Gizmo")) && hitInfo2.collider.gameObject == base.gameObject)
		{
			AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
			isDragging = true;
			myRenderer.sharedMaterial = clickedMat;
			startOffset = craftingSystem.rings[targetRingIndex].offset;
			startScale = craftingSystem.rings[targetRingIndex].scale;
			CustomCrafitng.DeformAxis targetAxis = craftingSystem.targetAxis;
			if (gizmoType == GizmoType.TranslateOffset)
			{
				dragAxis = ((targetAxis == CustomCrafitng.DeformAxis.Z) ? craftingSystem.lattice.transform.forward : craftingSystem.lattice.transform.up);
			}
			else if (gizmoType == GizmoType.ScaleRing)
			{
				int num = ((targetAxis == CustomCrafitng.DeformAxis.Z) ? craftingSystem.lattice.GetIndex(0, 0, targetRingIndex) : craftingSystem.lattice.GetIndex(0, targetRingIndex, 0));
				float num2 = ((targetAxis == CustomCrafitng.DeformAxis.Z) ? craftingSystem.lattice.ControlPoints[num].z : craftingSystem.lattice.ControlPoints[num].y);
				Vector3 position = ((targetAxis == CustomCrafitng.DeformAxis.Z) ? new Vector3(0f, 0f, num2) : new Vector3(0f, num2, 0f));
				Vector3 vector2 = craftingSystem.lattice.transform.TransformPoint(position);
				dragAxis = (base.transform.position - vector2).normalized;
				if (dragAxis == Vector3.zero)
				{
					dragAxis = craftingSystem.lattice.transform.right;
				}
			}
			Vector3 rhs = mainCam.transform.position - base.transform.position;
			Vector3 inNormal = Vector3.Cross(Vector3.Cross(dragAxis, rhs), dragAxis).normalized;
			if (inNormal.sqrMagnitude < 0.001f)
			{
				inNormal = -mainCam.transform.forward;
			}
			dragPlane = new Plane(inNormal, base.transform.position);
			if (dragPlane.Raycast(ray, out var enter))
			{
				startDragPoint = ray.GetPoint(enter);
			}
		}
		if (Mouse.current.leftButton.isPressed && isDragging && dragPlane.Raycast(ray, out var enter2))
		{
			Vector3 lhs = ray.GetPoint(enter2) - startDragPoint;
			if (gizmoType == GizmoType.TranslateOffset)
			{
				float num3 = Vector3.Dot(lhs, dragAxis);
				craftingSystem.rings[targetRingIndex].offset = startOffset + num3;
			}
			else if (gizmoType == GizmoType.ScaleRing)
			{
				float num4 = Vector3.Dot(lhs, dragAxis) * scaleSensitivity;
				float value = startScale + num4;
				craftingSystem.rings[targetRingIndex].scale = Mathf.Clamp(value, 0.1f, 5f);
			}
			craftingSystem.ApplyAllRings();
			craftingSystem.UpdateHeadPosition();
		}
		if (Mouse.current.leftButton.wasReleasedThisFrame && isDragging)
		{
			isDragging = false;
			myRenderer.sharedMaterial = originalMat;
			craftingSystem.CalculateCMOffset();
			craftingSystem.UpdateMassByVolume();
			craftingSystem.UpdateCollider();
			craftingSystem.UpdateCamPosition();
			AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
		}
	}

	private void UpdateGizmoPosition()
	{
		if (!(craftingSystem == null) && !(craftingSystem.lattice == null))
		{
			CustomCrafitng.DeformAxis targetAxis = craftingSystem.targetAxis;
			Vector3Int resolution = craftingSystem.lattice.Resolution;
			int num = ((targetAxis == CustomCrafitng.DeformAxis.Z) ? craftingSystem.lattice.GetIndex(0, 0, targetRingIndex) : craftingSystem.lattice.GetIndex(0, targetRingIndex, 0));
			float num2 = ((targetAxis == CustomCrafitng.DeformAxis.Z) ? craftingSystem.lattice.ControlPoints[num].z : craftingSystem.lattice.ControlPoints[num].y);
			if (gizmoType == GizmoType.TranslateOffset)
			{
				Vector3 position = ((targetAxis == CustomCrafitng.DeformAxis.Z) ? new Vector3(0f, 0f, num2) : new Vector3(0f, num2, 0f));
				base.transform.position = craftingSystem.lattice.transform.TransformPoint(position);
			}
			else if (gizmoType == GizmoType.ScaleRing)
			{
				int num3 = ((targetAxis != CustomCrafitng.DeformAxis.Z) ? craftingSystem.lattice.GetIndex(resolution.x - 1, targetRingIndex, resolution.z / 2) : craftingSystem.lattice.GetIndex(resolution.x - 1, resolution.y / 2, targetRingIndex));
				Vector3 position2 = craftingSystem.lattice.ControlPoints[num3];
				base.transform.position = craftingSystem.lattice.transform.TransformPoint(position2);
			}
		}
	}
}
