using System.Collections.Generic;
using AutoTiling;
using RLD;
using UnityEngine;
using UnityEngine.Rendering;
using cakeslice;

public class LevelObjectView : MonoBehaviour, IRTTransformGizmoListener
{
	[SerializeField]
	private new string name;

	[SerializeField]
	private LevelObjectType levelObjectType;

	[SerializeField]
	private bool isAffectedByPhysics;

	[SerializeField]
	private float mass;

	[SerializeField]
	private Material outlineMaterial;

	[SerializeField]
	private LevelObjectLogicType logicType;

	[SerializeField]
	private LevelObjectView levelObjectViewOutput;

	[SerializeField]
	private bool isInvertedLogic;

	[SerializeField]
	private bool isPressOnce;

	[SerializeField]
	private bool isWithGrid = true;

	[SerializeField]
	private bool isAltTexOffset;

	[SerializeField]
	private Vector3 rotatorSpeed = Vector3.zero;

	[SerializeField]
	private bool isLocalSpaceRotator = true;

	private List<MeshRenderer> allMeshRenderers;

	private List<Outline> outlines;

	private GameObject outlineMeshObject;

	private GameObject gizmosFolder;

	private GameObject objectPivot;

	private GameObject gizmosTarget;

	private LineComponent logicLine;

	private Vector3 lastUnchangedPosition;

	private Vector3 lastValidScale;

	private Vector3 lastUnchangedScale;

	private bool isAlreadyInitialized;

	public int Id { get; set; }

	public string Name => name;

	public LevelObjectType LevelObjectType => levelObjectType;

	public bool IsWithGrid
	{
		get
		{
			return isWithGrid;
		}
		set
		{
			isWithGrid = value;
		}
	}

	public bool IsAltTexOffset
	{
		get
		{
			return isAltTexOffset;
		}
		set
		{
			if (value != isAltTexOffset)
			{
				InvertTextureTilingOffset();
			}
			isAltTexOffset = value;
		}
	}

	public LevelObjectLogicType LogicType => logicType;

	public LevelObjectView LevelObjectViewOutput
	{
		get
		{
			return levelObjectViewOutput;
		}
		set
		{
			levelObjectViewOutput = value;
		}
	}

	public bool IsInvertedLogic
	{
		get
		{
			return isInvertedLogic;
		}
		set
		{
			isInvertedLogic = value;
		}
	}

	public bool IsPressOnce
	{
		get
		{
			return isPressOnce;
		}
		set
		{
			isPressOnce = value;
		}
	}

	public Vector3 RotatorSpeed
	{
		get
		{
			return rotatorSpeed;
		}
		set
		{
			rotatorSpeed = value;
		}
	}

	public bool IsLocalSpaceRotator
	{
		get
		{
			return isLocalSpaceRotator;
		}
		set
		{
			isLocalSpaceRotator = value;
		}
	}

	public bool ShouldHideLogicLine { get; set; }

	public bool IsAffectedByPhysics
	{
		get
		{
			return isAffectedByPhysics;
		}
		set
		{
			isAffectedByPhysics = value;
		}
	}

	public float Mass
	{
		get
		{
			return mass;
		}
		set
		{
			mass = value;
		}
	}

	public Vector3 LevelObjectScale
	{
		get
		{
			if (levelObjectType == LevelObjectType.Active && objectPivot != null)
			{
				return objectPivot.transform.localScale;
			}
			return base.transform.localScale;
		}
		set
		{
			Vector3 localScale = new Vector3((value.x <= 0f) ? lastValidScale.x : value.x, (value.y <= 0f) ? lastValidScale.y : value.y, (value.z <= 0f) ? lastValidScale.z : value.z);
			if (levelObjectType == LevelObjectType.Active)
			{
				base.transform.localScale = Vector3.one;
				if (objectPivot != null)
				{
					objectPivot.transform.localScale = localScale;
				}
				if (gizmosTarget != null)
				{
					gizmosTarget.transform.localScale = localScale;
				}
			}
			else
			{
				base.transform.localScale = localScale;
			}
			lastValidScale = localScale;
		}
	}

	private void Awake()
	{
		if (!isAlreadyInitialized)
		{
			Initialize();
		}
	}

	public void Initialize()
	{
		if (isAlreadyInitialized)
		{
			return;
		}
		lastUnchangedPosition = base.transform.position;
		lastValidScale = Vector3.one;
		lastUnchangedScale = Vector3.one;
		outlines = new List<Outline>();
		allMeshRenderers = new List<MeshRenderer>();
		MeshRenderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].CompareTag("LevelEditor"))
			{
				allMeshRenderers.Add(componentsInChildren[i]);
			}
		}
		Transform transform = base.transform.Find("OutlineMeshObject");
		if (transform == null)
		{
			outlineMeshObject = new GameObject("OutlineMeshObject");
			Bounds allMeshRenderersCombinedBounds = GetAllMeshRenderersCombinedBounds();
			outlineMeshObject.transform.localPosition = allMeshRenderersCombinedBounds.center;
			outlineMeshObject.transform.localScale = allMeshRenderersCombinedBounds.size;
			outlineMeshObject.transform.SetParent(base.transform, worldPositionStays: true);
			Mesh mesh = GeometryBuilder.CornerBox(0.5f, 0.75f);
			outlineMeshObject.AddComponent<MeshFilter>().mesh = mesh;
			outlineMeshObject.AddComponent<MeshRenderer>().sharedMaterial = outlineMaterial;
		}
		else
		{
			outlineMeshObject = transform.gameObject;
		}
		Transform transform2 = base.transform.Find("gizmos");
		if (transform2 != null)
		{
			gizmosFolder = transform2.gameObject;
		}
		if (transform2 != null)
		{
			logicLine = transform2.GetComponentInChildren<LineComponent>(includeInactive: true);
		}
		if (logicLine != null)
		{
			logicLine.Initialize(transform2);
			logicLine.SetVisibility(isVisible: false);
		}
		Transform transform3 = base.transform.Find("pivot");
		if (transform3 != null)
		{
			objectPivot = transform3.gameObject;
			if (outlineMeshObject != null)
			{
				outlineMeshObject.transform.SetParent(objectPivot.transform);
			}
		}
		if (gizmosFolder != null)
		{
			Transform transform4 = gizmosFolder.transform.Find("target");
			if (transform4 != null)
			{
				gizmosTarget = transform4.gameObject;
			}
		}
		foreach (MeshRenderer allMeshRenderer in allMeshRenderers)
		{
			Outline outline = allMeshRenderer.gameObject.GetComponent<Outline>();
			if (outline == null)
			{
				outline = allMeshRenderer.gameObject.AddComponent<Outline>();
			}
			outline.enabled = false;
			outlines.Add(outline);
		}
		SetOutline(isEnabled: false);
		isAlreadyInitialized = true;
	}

	private void LateUpdate()
	{
		if (LogicType == LevelObjectLogicType.Input && logicLine != null)
		{
			if (levelObjectViewOutput != null && !levelObjectViewOutput.gameObject.activeSelf)
			{
				levelObjectViewOutput = null;
			}
			if (levelObjectViewOutput != null && !ShouldHideLogicLine)
			{
				Vector3 center = GetAllMeshRenderersCombinedBounds().center;
				Vector3 center2 = levelObjectViewOutput.GetAllMeshRenderersCombinedBounds().center;
				logicLine.SetPositions(center, center2);
				logicLine.SetVisibility(isVisible: true);
			}
			else
			{
				logicLine.SetVisibility(isVisible: false);
			}
		}
	}

	private void FixTextureTilingForEditor()
	{
		base.transform.GetComponentsInChildren<DynamicTextureTiling>(includeInactive: true);
	}

	public void SetTextureTilingScale(float scaleFactor)
	{
		DynamicTextureTiling[] componentsInChildren = base.transform.GetComponentsInChildren<DynamicTextureTiling>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].unwrapMethod == UnwrapType.CubeProjection)
			{
				componentsInChildren[i].topScale = new Vector2(scaleFactor, scaleFactor);
			}
			else
			{
				componentsInChildren[i].ApplyFaceScale(0, new Vector2(scaleFactor, scaleFactor));
			}
		}
	}

	public void SetTextureTilingOffset(Vector2 newOffset)
	{
		DynamicTextureTiling[] componentsInChildren = base.transform.GetComponentsInChildren<DynamicTextureTiling>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].unwrapMethod == UnwrapType.CubeProjection)
			{
				componentsInChildren[i].topOffset = newOffset;
			}
			else
			{
				componentsInChildren[i].ApplyFaceOffset(0, newOffset);
			}
		}
	}

	public void InvertTextureTilingOffset()
	{
		DynamicTextureTiling[] componentsInChildren = base.transform.GetComponentsInChildren<DynamicTextureTiling>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].unwrapMethod == UnwrapType.CubeProjection)
			{
				float x = ((componentsInChildren[i].topOffset.x == 0f) ? 0.5f : 0f);
				float y = ((componentsInChildren[i].topOffset.y == 0f) ? 0.5f : 0f);
				componentsInChildren[i].topOffset = new Vector2(x, y);
			}
			else
			{
				float x2 = ((componentsInChildren[i].faceUnwrapData[0].uvOffset.x == 0f) ? 0.5f : 0f);
				float y2 = ((componentsInChildren[i].faceUnwrapData[0].uvOffset.y == 0f) ? 0.5f : 0f);
				componentsInChildren[i].ApplyFaceOffset(0, new Vector2(x2, y2));
			}
		}
	}

	public Bounds GetAllMeshRenderersCombinedBounds()
	{
		if (allMeshRenderers.Count == 0)
		{
			return default(Bounds);
		}
		Bounds bounds = allMeshRenderers[0].bounds;
		for (int i = 1; i < allMeshRenderers.Count; i++)
		{
			bounds.Encapsulate(allMeshRenderers[i].bounds);
		}
		return bounds;
	}

	public void SetColor(Color color)
	{
		for (int i = 0; i < allMeshRenderers.Count; i++)
		{
			float a = allMeshRenderers[i].material.color.a;
			allMeshRenderers[i].material.color = color;
			if (a == 1f && color.a < 1f)
			{
				Util.ChangeStandardMaterialRenderMode(allMeshRenderers[i].material, Util.BlendMode.Transparent);
			}
			else if (a < 1f && color.a == 1f)
			{
				Util.ChangeStandardMaterialRenderMode(allMeshRenderers[i].material, Util.BlendMode.Opaque);
			}
		}
	}

	public Color GetColor()
	{
		if (allMeshRenderers == null || allMeshRenderers.Count == 0)
		{
			return Color.white;
		}
		return allMeshRenderers[0].material.color;
	}

	public void SetGridOnTexture(bool isWithGrid)
	{
		if (isWithGrid)
		{
			SetMaterial(GlobalMaterialManager.Instance.LevelObjectWithGridMat, isWithGrid: true);
		}
		else
		{
			SetMaterial(GlobalMaterialManager.Instance.LevelObjectWithoutGridMat, isWithGrid: false);
		}
	}

	public void SetMaterial(Material newMaterial, bool isWithGrid)
	{
		if (allMeshRenderers.Count != 0)
		{
			Color color = GetColor();
			for (int i = 0; i < allMeshRenderers.Count; i++)
			{
				allMeshRenderers[i].material = newMaterial;
			}
			SetColor(color);
			IsWithGrid = isWithGrid;
		}
	}

	public void SetOutline(bool isEnabled, int colorLine = 0)
	{
		if (!(levelObjectType == LevelObjectType.Ground && isEnabled))
		{
			for (int i = 0; i < outlines.Count; i++)
			{
				outlines[i].enabled = isEnabled;
				outlines[i].color = colorLine;
			}
			outlineMeshObject.SetActive(isEnabled);
		}
	}

	public void SetGizmosVisibility(bool isVisible)
	{
		gizmosFolder?.SetActive(isVisible);
	}

	public void TurnObjectTransparent()
	{
		foreach (MeshRenderer allMeshRenderer in allMeshRenderers)
		{
			Util.TurnStandardMaterialToFade(allMeshRenderer.material);
			allMeshRenderer.shadowCastingMode = ShadowCastingMode.Off;
			allMeshRenderer.material.color = allMeshRenderer.material.color.WithChange(null, null, null, 0.5f);
		}
	}

	public MeshRenderer[] GetAllMeshRenderer()
	{
		return allMeshRenderers.ToArray();
	}

	public bool OnCanBeTransformed(Gizmo transformGizmo)
	{
		lastUnchangedPosition = base.transform.position;
		lastUnchangedScale = LevelObjectScale;
		lastValidScale = LevelObjectScale;
		switch (levelObjectType)
		{
		case LevelObjectType.StartZone:
		case LevelObjectType.EndZone:
		case LevelObjectType.Dynamic:
			if (transformGizmo.ActiveDragChannel != GizmoDragChannel.Offset)
			{
				return transformGizmo.ActiveDragChannel == GizmoDragChannel.Rotation;
			}
			return true;
		case LevelObjectType.FailureZone:
		case LevelObjectType.Ground:
			return false;
		case LevelObjectType.Structure:
		case LevelObjectType.Active:
			return true;
		default:
			return false;
		}
	}

	public void OnTransformed(Gizmo transformGizmo)
	{
		if (transformGizmo.ActiveDragChannel != GizmoDragChannel.Scale)
		{
			return;
		}
		if (transformGizmo.ScaleGizmo != null || transformGizmo.UniversalGizmo != null)
		{
			LevelObjectScale = lastUnchangedScale + FilterTotalDragScale(transformGizmo.TotalDragScale, transformGizmo.DragHandleId);
		}
		else if (transformGizmo.BoxGizmo != null)
		{
			if (levelObjectType != LevelObjectType.Active)
			{
				LevelObjectScale = Vector3.Scale(lastUnchangedScale, transformGizmo.TotalDragScale);
				return;
			}
			(Vector3 newScale, Vector3 positionOffset) tuple = AdjustBoxToolForActiveType(transformGizmo.TotalDragScale, lastUnchangedScale, base.transform.rotation, transformGizmo.DragHandleId);
			Vector3 item = tuple.newScale;
			Vector3 item2 = tuple.positionOffset;
			LevelObjectScale = item;
			base.transform.position = lastUnchangedPosition + item2;
		}
	}

	private Vector3 FilterTotalDragScale(Vector3 totalDragScale, int handleId)
	{
		float x = 0f;
		float y = 0f;
		float z = 0f;
		if (handleId == GizmoHandleId.PXSlider || handleId == GizmoHandleId.PXCap || handleId == GizmoHandleId.XYDblSlider || handleId == GizmoHandleId.ZXDblSlider || handleId == GizmoHandleId.MidScaleCap)
		{
			x = totalDragScale.x - 1f;
		}
		if (handleId == GizmoHandleId.PYSlider || handleId == GizmoHandleId.PYCap || handleId == GizmoHandleId.XYDblSlider || handleId == GizmoHandleId.YZDblSlider || handleId == GizmoHandleId.MidScaleCap)
		{
			y = totalDragScale.y - 1f;
		}
		if (handleId == GizmoHandleId.PZSlider || handleId == GizmoHandleId.PZCap || handleId == GizmoHandleId.YZDblSlider || handleId == GizmoHandleId.ZXDblSlider || handleId == GizmoHandleId.MidScaleCap)
		{
			z = totalDragScale.z - 1f;
		}
		return new Vector3(x, y, z);
	}

	private (Vector3 newScale, Vector3 positionOffset) AdjustBoxToolForActiveType(Vector3 totalDragScale, Vector3 originalScale, Quaternion rotation, int handleId)
	{
		Vector3 vector = Vector3.zero;
		float num = originalScale.x;
		float num2 = originalScale.y;
		float num3 = originalScale.z;
		if (handleId == GizmoHandleId.BoxTickRightCenter || handleId == GizmoHandleId.BoxTickLeftCenter)
		{
			float num4 = totalDragScale.x - 1f;
			num += num4;
			vector.Set(num4 * 0.5f, num4 * 0.5f, num4 * 0.5f);
			vector = ((handleId != GizmoHandleId.BoxTickRightCenter) ? Vector3.Scale(vector, rotation * Vector3.left) : Vector3.Scale(vector, rotation * Vector3.right));
		}
		if (handleId == GizmoHandleId.BoxTickTopCenter || handleId == GizmoHandleId.BoxTickBottomCenter)
		{
			float num4 = totalDragScale.y - 1f;
			num2 += num4;
			vector.Set(num4 * 0.5f, num4 * 0.5f, num4 * 0.5f);
			vector = ((handleId != GizmoHandleId.BoxTickTopCenter) ? Vector3.Scale(vector, rotation * Vector3.down) : Vector3.Scale(vector, rotation * Vector3.up));
		}
		if (handleId == GizmoHandleId.BoxTickFrontCenter || handleId == GizmoHandleId.BoxTickBackCenter)
		{
			float num4 = totalDragScale.z - 1f;
			num3 += num4;
			vector.Set(num4 * 0.5f, num4 * 0.5f, num4 * 0.5f);
			vector = ((handleId != GizmoHandleId.BoxTickBackCenter) ? Vector3.Scale(vector, rotation * Vector3.back) : Vector3.Scale(vector, rotation * Vector3.forward));
		}
		return (newScale: new Vector3(num, num2, num3), positionOffset: vector);
	}
}
