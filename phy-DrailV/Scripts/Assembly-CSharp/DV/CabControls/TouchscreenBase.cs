using System;
using System.Collections;
using System.Collections.Generic;
using DV.CabControls.Spec;
using DV.Interaction;
using UnityEngine;

namespace DV.CabControls
{
	public abstract class TouchscreenBase : ControlImplBase
	{
		private const string HOVER_OBJECT_NAME = "[TouchscreenHover]";

		protected readonly Vector2Int UNTOUCHED_COORDS = -Vector2Int.one;

		protected Touchscreen touchscreenSpec;

		public bool flipVerticalCoords;

		public bool flipHorizontalCoords;

		public float hoverHeightOffset = 0.001f;

		[NonSerialized]
		public Vector2Int forcedGridSize = Vector2Int.zero;

		public Vector2Int gridSize;

		public float vrTolerance;

		public Vector2 sectionSize;

		protected Vector2 localInteractionHalfSize;

		protected Vector2Int currentlyTouchedSection;

		protected bool useEntireScreen;

		public HashSet<Vector2Int> validSections = new HashSet<Vector2Int>();

		[SerializeField]
		private BoxCollider interactionCollider;

		private GameObject hoverGameObject;

		protected HighlightTag highlightTag;

		protected bool isInitialized;

		public bool IsTouched { get; protected set; }

		protected override InteractionHandPoses GenericHandPoses { get; } = new InteractionHandPoses(HandPose.Point, HandPose.Point, HandPose.Point);

		public bool IsInitialized => isInitialized;

		public event Action<Vector2Int> SectionPressed;

		public event Action<Vector2Int> SectionTouched;

		public event Action<Vector2Int> SectionUntouched;

		public event Action Initialized;

		protected virtual void Awake()
		{
			touchscreenSpec = GetComponent<Touchscreen>();
			currentlyTouchedSection = UNTOUCHED_COORDS;
		}

		protected virtual void OnEnable()
		{
			if (!isInitialized)
			{
				StartCoroutine(Initialize());
			}
		}

		private IEnumerator Initialize()
		{
			yield return null;
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.useGravity = false;
			rigidbody.mass = 0.1f;
			rigidbody.isKinematic = true;
			useEntireScreen = touchscreenSpec.useEntireScreen;
			flipHorizontalCoords = touchscreenSpec.flipHorizontalCoords;
			flipVerticalCoords = touchscreenSpec.flipVerticalCoords;
			gridSize = ((forcedGridSize != Vector2Int.zero) ? forcedGridSize : touchscreenSpec.gridSize);
			vrTolerance = touchscreenSpec.maxVRTolerance;
			if (interactionCollider == null)
			{
				interactionCollider = GetComponentInChildren<BoxCollider>(includeInactive: true);
			}
			Vector2 vector = new Vector2(interactionCollider.size.x, interactionCollider.size.z);
			sectionSize = new Vector2(vector.x / (float)gridSize.x, vector.y / (float)gridSize.y);
			localInteractionHalfSize = vector * 0.5f;
			UnityEngine.Object obj = Resources.Load("[TouchscreenHover]");
			if (obj != null)
			{
				hoverGameObject = UnityEngine.Object.Instantiate(obj, Vector3.zero, Quaternion.identity, base.transform) as GameObject;
				if (hoverGameObject != null)
				{
					hoverHeightOffset = touchscreenSpec.hoverVerticalOffset;
					hoverGameObject.transform.localPosition = Vector3.zero;
					hoverGameObject.transform.localRotation = Quaternion.identity;
					hoverGameObject.transform.GetChild(0).localScale = new Vector3(sectionSize.y, sectionSize.x, 1f);
					HighlightTag component = GetComponent<HighlightTag>();
					component.targetObject = hoverGameObject.transform.GetChild(0).gameObject;
					component.renderers.Clear();
					if (component.targetObject.TryGetComponent<Renderer>(out var component2))
					{
						component.renderers.Add(component2);
					}
					highlightTag = component;
					hoverGameObject.SetActive(value: false);
				}
			}
			isInitialized = true;
			this.Initialized?.Invoke();
		}

		protected override void AcceptSetValue(float newValue)
		{
		}

		protected virtual void SetupListeners(bool on)
		{
		}

		public override void Use()
		{
			if (IsValidGridPosition(currentlyTouchedSection))
			{
				base.Use();
				this.SectionPressed?.Invoke(currentlyTouchedSection);
			}
		}

		public virtual void Touch(Vector3 localPosition, float tolerance = 0f)
		{
			Vector2Int vector2Int = currentlyTouchedSection;
			localPosition = ApplyToleranceToLocalPosition(localPosition, tolerance);
			if (!IsValidLocalPosition(localPosition))
			{
				Untouch();
				return;
			}
			float num = localPosition.x + localInteractionHalfSize.x;
			float num2 = localPosition.z + localInteractionHalfSize.y;
			Vector2Int vector2Int2 = new Vector2Int(Mathf.FloorToInt(num / sectionSize.x), Mathf.FloorToInt(num2 / sectionSize.y));
			if (flipHorizontalCoords)
			{
				vector2Int2.x = gridSize.x - (1 + vector2Int2.x);
			}
			if (flipVerticalCoords)
			{
				vector2Int2.y = gridSize.y - (1 + vector2Int2.y);
			}
			Vector2Int vector2Int3 = vector2Int2;
			vector2Int3.x = Mathf.Clamp(vector2Int3.x, 0, gridSize.x - 1);
			vector2Int3.y = Mathf.Clamp(vector2Int3.y, 0, gridSize.y - 1);
			if (!IsValidGridPosition(vector2Int3))
			{
				Untouch();
			}
			else if (!(vector2Int3 == vector2Int))
			{
				if (IsValidGridPosition(vector2Int))
				{
					Untouch();
				}
				IsTouched = true;
				currentlyTouchedSection = vector2Int3;
				SetHighlight(on: true);
				this.SectionTouched?.Invoke(currentlyTouchedSection);
			}
		}

		public Vector3 SectionLocalCenter(Vector2Int section)
		{
			int num = (flipHorizontalCoords ? (gridSize.x - section.x - 1) : section.x);
			int num2 = (flipVerticalCoords ? (gridSize.y - section.y - 1) : section.y);
			return new Vector3(sectionSize.x * ((float)num + 0.5f) - localInteractionHalfSize.x, hoverHeightOffset, sectionSize.y * ((float)num2 + 0.5f) - localInteractionHalfSize.y);
		}

		public virtual void Untouch()
		{
			Vector2Int obj = currentlyTouchedSection;
			currentlyTouchedSection = UNTOUCHED_COORDS;
			if (IsTouched)
			{
				IsTouched = false;
				SetHighlight(on: false);
				this.SectionUntouched?.Invoke(obj);
			}
		}

		private Vector3 ApplyToleranceToLocalPosition(Vector3 localPoint, float tolerance)
		{
			if (localPoint.x.IsInRange(0f - localInteractionHalfSize.x - tolerance, 0f - localInteractionHalfSize.x))
			{
				localPoint.x = 0f - localInteractionHalfSize.x;
			}
			if (localPoint.x.IsInRange(localInteractionHalfSize.x, localInteractionHalfSize.x + tolerance))
			{
				localPoint.x = localInteractionHalfSize.x;
			}
			if (localPoint.z.IsInRange(0f - localInteractionHalfSize.y - tolerance, 0f - localInteractionHalfSize.y))
			{
				localPoint.z = 0f - localInteractionHalfSize.y;
			}
			if (localPoint.z.IsInRange(localInteractionHalfSize.y, localInteractionHalfSize.y + tolerance))
			{
				localPoint.z = localInteractionHalfSize.y;
			}
			return localPoint;
		}

		private bool IsValidLocalPosition(Vector3 localPoint)
		{
			if (localPoint.x.IsInRange(0f - localInteractionHalfSize.x, localInteractionHalfSize.x) && localPoint.y.IsInRange(0f - localInteractionHalfSize.y, localInteractionHalfSize.y))
			{
				return !InteractionPassThrough(LocalToGrid(localPoint));
			}
			return false;
		}

		public bool IsValidGridPosition(Vector2Int gridPosition)
		{
			if (gridPosition.x.IsInRange(0, gridSize.x - 1) && gridPosition.y.IsInRange(0, gridSize.y - 1))
			{
				return !InteractionPassThrough(gridPosition);
			}
			return false;
		}

		protected bool InteractionPassThrough(Vector3 point)
		{
			if (!useEntireScreen)
			{
				return !validSections.Contains(WorldToGrid(point));
			}
			return false;
		}

		protected bool InteractionPassThrough(Vector2Int point)
		{
			if (!useEntireScreen)
			{
				return !validSections.Contains(point);
			}
			return false;
		}

		public Vector2Int WorldToGrid(Vector3 worldPoint, bool onlyValid = true)
		{
			return LocalToGrid(base.transform.InverseTransformPoint(worldPoint), onlyValid);
		}

		public Vector2Int LocalToGrid(Vector3 localPoint, bool onlyValid = true)
		{
			float num = localPoint.x + localInteractionHalfSize.x;
			float num2 = localPoint.z + localInteractionHalfSize.y;
			Vector2Int result = new Vector2Int(Mathf.FloorToInt(num / sectionSize.x), Mathf.FloorToInt(num2 / sectionSize.y));
			if (flipHorizontalCoords)
			{
				result.x = gridSize.x - (1 + result.x);
			}
			if (flipVerticalCoords)
			{
				result.y = gridSize.y - (1 + result.y);
			}
			if (!onlyValid)
			{
				return result;
			}
			if (result.x.IsInRange(0, gridSize.x - 1) && result.y.IsInRange(0, gridSize.y - 1))
			{
				return result;
			}
			return UNTOUCHED_COORDS;
		}

		protected Vector3 ClosestSectionCenterWorldPosition(Vector3 worldPosition)
		{
			Vector2Int vector2Int = WorldToGrid(worldPosition, onlyValid: false);
			Vector2Int section = new Vector2Int(Mathf.Clamp(vector2Int.x, 0, gridSize.x - 1), Mathf.Clamp(vector2Int.y, 0, gridSize.y - 1));
			return base.transform.TransformPoint(SectionLocalCenter(section));
		}

		protected virtual bool SetHighlight(bool on)
		{
			if (hoverGameObject == null)
			{
				return false;
			}
			if (on)
			{
				hoverGameObject.transform.localPosition = SectionLocalCenter(currentlyTouchedSection);
			}
			hoverGameObject.SetActive(on);
			return true;
		}
	}
}
