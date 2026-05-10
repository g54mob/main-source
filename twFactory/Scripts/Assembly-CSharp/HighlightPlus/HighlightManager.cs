using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HighlightPlus
{
	[RequireComponent(typeof(HighlightEffect))]
	[DefaultExecutionOrder(100)]
	[HelpURL("https://kronnect.com/guides/highlight-plus-introduction/")]
	public class HighlightManager : MonoBehaviour
	{
		[Tooltip("Enables highlight when pointer is over this object.")]
		[SerializeField]
		private bool _highlightOnHover = true;

		public LayerMask layerMask = -1;

		public Camera raycastCamera;

		public RayCastSource raycastSource;

		[Tooltip("Minimum distance for target.")]
		public float minDistance;

		[Tooltip("Maximum distance for target. 0 = infinity")]
		public float maxDistance;

		[Tooltip("Blocks interaction if pointer is over an UI element")]
		public bool respectUI = true;

		[Tooltip("If the object will be selected by clicking with mouse or tapping on it.")]
		public bool selectOnClick;

		[Tooltip("Optional profile for objects selected by clicking on them")]
		public HighlightProfile selectedProfile;

		[Tooltip("Profile to use whtn object is selected and highlighted.")]
		public HighlightProfile selectedAndHighlightedProfile;

		[Tooltip("Automatically deselects other previously selected objects")]
		public bool singleSelection;

		[Tooltip("Toggles selection on/off when clicking object")]
		public bool toggle;

		[Tooltip("Keeps current selection when clicking outside of any selectable object")]
		public bool keepSelection = true;

		private HighlightEffect baseEffect;

		private HighlightEffect currentEffect;

		private Transform currentObject;

		private RaycastHit2D[] hitInfo2D;

		public static readonly List<HighlightEffect> selectedObjects = new List<HighlightEffect>();

		public static int lastTriggerFrame;

		private static HighlightManager _instance;

		public bool highlightOnHover
		{
			get
			{
				return _highlightOnHover;
			}
			set
			{
				if (_highlightOnHover != value)
				{
					_highlightOnHover = value;
					if (!_highlightOnHover && currentEffect != null)
					{
						Highlight(state: false);
					}
				}
			}
		}

		public static HighlightManager instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Misc.FindObjectOfType<HighlightManager>();
				}
				return _instance;
			}
		}

		public event OnObjectSelectionEvent OnObjectSelected;

		public event OnObjectSelectionEvent OnObjectUnSelected;

		public event OnObjectHighlightEvent OnObjectHighlightStart;

		public event OnObjectHighlightEvent OnObjectHighlightStay;

		public event OnObjectHighlightEvent OnObjectHighlightEnd;

		[RuntimeInitializeOnLoadMethod]
		private static void DomainReloadDisabledSupport()
		{
			selectedObjects.Clear();
			lastTriggerFrame = 0;
			_instance = null;
		}

		private void OnEnable()
		{
			currentObject = null;
			currentEffect = null;
			if (baseEffect == null)
			{
				baseEffect = GetComponent<HighlightEffect>();
				if (baseEffect == null)
				{
					baseEffect = base.gameObject.AddComponent<HighlightEffect>();
				}
			}
			if (raycastCamera == null)
			{
				raycastCamera = GetCamera();
				if (raycastCamera == null)
				{
					Debug.LogError("Highlight Manager: no camera found!");
				}
			}
			hitInfo2D = new RaycastHit2D[1];
			InputProxy.Init();
		}

		private void OnDisable()
		{
			SwitchesObject(null);
			internal_DeselectAll();
		}

		private void Update()
		{
			if (raycastCamera == null)
			{
				return;
			}
			Ray ray;
			if (raycastSource == RayCastSource.MousePosition)
			{
				if (!CanInteract())
				{
					return;
				}
				ray = raycastCamera.ScreenPointToRay(InputProxy.mousePosition);
			}
			else
			{
				ray = new Ray(raycastCamera.transform.position, raycastCamera.transform.forward);
			}
			VerifyHighlightStay();
			if (Physics.Raycast(ray, out var hitInfo, (maxDistance > 0f) ? maxDistance : raycastCamera.farClipPlane, layerMask) && Vector3.Distance(hitInfo.point, ray.origin) >= minDistance)
			{
				Transform transform = hitInfo.collider.transform;
				if (transform.GetComponent<HighlightTrigger>() != null)
				{
					return;
				}
				if (InputProxy.GetMouseButtonDown(0))
				{
					if (selectOnClick)
					{
						ToggleSelection(transform, !toggle);
					}
				}
				else if (transform != currentObject)
				{
					SwitchesObject(transform);
				}
			}
			else if (Physics2D.GetRayIntersectionNonAlloc(ray, hitInfo2D, (maxDistance > 0f) ? maxDistance : raycastCamera.farClipPlane, layerMask) > 0 && Vector3.Distance(hitInfo2D[0].point, ray.origin) >= minDistance)
			{
				Transform transform2 = hitInfo2D[0].collider.transform;
				if (transform2.GetComponent<HighlightTrigger>() != null)
				{
					return;
				}
				if (InputProxy.GetMouseButtonDown(0))
				{
					if (selectOnClick)
					{
						ToggleSelection(transform2, !toggle);
					}
				}
				else if (transform2 != currentObject)
				{
					SwitchesObject(transform2);
				}
			}
			else
			{
				if (selectOnClick && !keepSelection && InputProxy.GetMouseButtonDown(0) && lastTriggerFrame < Time.frameCount)
				{
					internal_DeselectAll();
				}
				SwitchesObject(null);
			}
		}

		private void VerifyHighlightStay()
		{
			if (!(currentObject == null) && !(currentEffect == null) && currentEffect.highlighted && this.OnObjectHighlightStay != null && !this.OnObjectHighlightStay(currentObject.gameObject))
			{
				SwitchesObject(null);
			}
		}

		private void SwitchesObject(Transform newObject)
		{
			if (currentEffect != null)
			{
				if (highlightOnHover)
				{
					Highlight(state: false);
				}
				currentEffect = null;
			}
			currentObject = newObject;
			if (newObject == null)
			{
				return;
			}
			HighlightTrigger component = newObject.GetComponent<HighlightTrigger>();
			if (component != null && component.enabled)
			{
				return;
			}
			HighlightEffect component2 = newObject.GetComponent<HighlightEffect>();
			if (component2 == null)
			{
				HighlightEffect componentInParent = newObject.GetComponentInParent<HighlightEffect>();
				if (componentInParent != null && componentInParent.Includes(newObject))
				{
					currentEffect = componentInParent;
					if (highlightOnHover)
					{
						Highlight(state: true);
					}
					return;
				}
			}
			currentEffect = ((component2 != null) ? component2 : baseEffect);
			baseEffect.enabled = currentEffect == baseEffect;
			currentEffect.SetTarget(currentObject);
			if (highlightOnHover)
			{
				Highlight(state: true);
			}
		}

		private bool CanInteract()
		{
			if (!respectUI)
			{
				return true;
			}
			EventSystem current = EventSystem.current;
			if (current == null)
			{
				return true;
			}
			if (Application.isMobilePlatform && InputProxy.touchCount > 0 && current.IsPointerOverGameObject(InputProxy.GetFingerIdFromTouch(0)))
			{
				return false;
			}
			if (current.IsPointerOverGameObject(-1))
			{
				return false;
			}
			return true;
		}

		private void ToggleSelection(Transform t, bool forceSelection)
		{
			HighlightEffect highlightEffect = t.GetComponent<HighlightEffect>();
			if (highlightEffect == null)
			{
				HighlightEffect componentInParent = t.GetComponentInParent<HighlightEffect>();
				if (componentInParent != null && componentInParent.Includes(t))
				{
					highlightEffect = componentInParent;
					if (highlightEffect.previousSettings == null)
					{
						highlightEffect.previousSettings = ScriptableObject.CreateInstance<HighlightProfile>();
					}
					highlightEffect.previousSettings.Save(highlightEffect);
				}
				else
				{
					highlightEffect = t.gameObject.AddComponent<HighlightEffect>();
					highlightEffect.previousSettings = ScriptableObject.CreateInstance<HighlightProfile>();
					highlightEffect.previousSettings.Save(baseEffect);
					highlightEffect.previousSettings.Load(highlightEffect);
				}
			}
			bool isSelected = highlightEffect.isSelected;
			bool flag = forceSelection || !isSelected;
			if (flag == isSelected)
			{
				return;
			}
			if (flag)
			{
				if (this.OnObjectSelected != null && !this.OnObjectSelected(t.gameObject))
				{
					return;
				}
			}
			else if (this.OnObjectUnSelected != null && !this.OnObjectUnSelected(t.gameObject))
			{
				return;
			}
			if (singleSelection)
			{
				internal_DeselectAll();
			}
			currentEffect = highlightEffect;
			currentEffect.isSelected = flag;
			baseEffect.enabled = false;
			if (currentEffect.isSelected)
			{
				if (currentEffect.previousSettings == null)
				{
					currentEffect.previousSettings = ScriptableObject.CreateInstance<HighlightProfile>();
				}
				highlightEffect.previousSettings.Save(highlightEffect);
				if (!selectedObjects.Contains(currentEffect))
				{
					selectedObjects.Add(currentEffect);
				}
			}
			else
			{
				if (currentEffect.previousSettings != null)
				{
					currentEffect.previousSettings.Load(highlightEffect);
				}
				if (selectedObjects.Contains(currentEffect))
				{
					selectedObjects.Remove(currentEffect);
				}
			}
			Highlight(flag);
		}

		private void Highlight(bool state)
		{
			if (currentEffect == null)
			{
				return;
			}
			if (state)
			{
				if (!currentEffect.highlighted && this.OnObjectHighlightStart != null && currentEffect.target != null && !this.OnObjectHighlightStart(currentEffect.target.gameObject))
				{
					currentObject = null;
					return;
				}
			}
			else if (currentEffect.highlighted && this.OnObjectHighlightEnd != null && currentEffect.target != null)
			{
				this.OnObjectHighlightEnd(currentEffect.target.gameObject);
			}
			if (selectOnClick || currentEffect.isSelected)
			{
				if (currentEffect.isSelected)
				{
					if (state && selectedAndHighlightedProfile != null)
					{
						selectedAndHighlightedProfile.Load(currentEffect);
					}
					else if (selectedProfile != null)
					{
						selectedProfile.Load(currentEffect);
					}
					else
					{
						currentEffect.previousSettings.Load(currentEffect);
					}
					if (currentEffect.highlighted && currentEffect.fading != HighlightEffect.FadingState.FadingOut)
					{
						currentEffect.UpdateMaterialProperties();
					}
					else
					{
						currentEffect.SetHighlighted(state: true);
					}
					return;
				}
				if (!highlightOnHover)
				{
					currentEffect.SetHighlighted(state: false);
					return;
				}
			}
			currentEffect.SetHighlighted(state);
		}

		public static Camera GetCamera()
		{
			Camera camera = Camera.main;
			if (camera == null)
			{
				camera = Misc.FindObjectOfType<Camera>();
			}
			return camera;
		}

		private void internal_DeselectAll()
		{
			foreach (HighlightEffect selectedObject in selectedObjects)
			{
				if (selectedObject != null && selectedObject.gameObject != null && (this.OnObjectUnSelected == null || this.OnObjectUnSelected(selectedObject.gameObject)))
				{
					selectedObject.RestorePreviousHighlightEffectSettings();
					selectedObject.isSelected = false;
					selectedObject.SetHighlighted(state: false);
				}
			}
			selectedObjects.Clear();
		}

		public static void DeselectAll()
		{
			if (instance != null)
			{
				_instance.internal_DeselectAll();
				return;
			}
			foreach (HighlightEffect selectedObject in selectedObjects)
			{
				if (selectedObject != null && selectedObject.gameObject != null)
				{
					selectedObject.RestorePreviousHighlightEffectSettings();
					selectedObject.isSelected = false;
					selectedObject.SetHighlighted(state: false);
				}
			}
			selectedObjects.Clear();
		}

		public void SelectObject(Transform t)
		{
			ToggleSelection(t, forceSelection: true);
		}

		public void ToggleObject(Transform t)
		{
			ToggleSelection(t, forceSelection: false);
		}

		public void UnselectObject(Transform t)
		{
			if (!(t == null))
			{
				HighlightEffect component = t.GetComponent<HighlightEffect>();
				if (!(component == null) && component.isSelected)
				{
					ToggleSelection(t, forceSelection: false);
				}
			}
		}
	}
}
