using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace HighlightPlus
{
	[RequireComponent(typeof(HighlightEffect))]
	[DefaultExecutionOrder(100)]
	[HelpURL("https://kronnect.com/guides/highlight-plus-introduction/")]
	public class HighlightManager : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Enables highlight when pointer is over this object.")]
		private bool _highlightOnHover;

		public LayerMask layerMask;

		public Camera raycastCamera;

		public RayCastSource raycastSource;

		[Tooltip("Minimum distance for target.")]
		public float minDistance;

		[Tooltip("Maximum distance for target. 0 = infinity")]
		public float maxDistance;

		[Tooltip("Blocks interaction if pointer is over an UI element")]
		public bool respectUI;

		[Tooltip("Unhighlights the object when the pointer is over a UI element")]
		public bool unhighlightOnUI;

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
		public bool keepSelection;

		private HighlightEffect baseEffect;

		private HighlightEffect currentEffect;

		private Transform currentObject;

		private RaycastHit2D[] hitInfo2D;

		public static readonly List<HighlightEffect> selectedObjects;

		public static int lastTriggerFrame;

		private static HighlightManager _instance;

		public bool highlightOnHover
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static HighlightManager instance => null;

		public event OnObjectSelectionEvent OnObjectSelected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnObjectSelectionEvent OnObjectUnSelected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnObjectHighlightEvent OnObjectHighlightStart
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnObjectHighlightEvent OnObjectHighlightStay
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnObjectHighlightEvent OnObjectHighlightEnd
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnObjectClickEvent OnObjectClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[RuntimeInitializeOnLoadMethod]
		private static void DomainReloadDisabledSupport()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		private void VerifyHighlightStay()
		{
		}

		private void SwitchesObject(Transform newObject)
		{
		}

		private void UpdateHitPosition(Transform target, Vector3 positionWS, Vector3 normalWS)
		{
		}

		private bool CanInteract()
		{
			return false;
		}

		private void ToggleSelection(Transform t, bool forceSelection)
		{
		}

		private void Highlight(bool state)
		{
		}

		public static Camera GetCamera()
		{
			return null;
		}

		private void internal_DeselectAll()
		{
		}

		public static void DeselectAll()
		{
		}

		public void UnselectObjects()
		{
		}

		public void SelectObject(Transform t)
		{
		}

		public void SelectObjects(Transform[] objects)
		{
		}

		public void SelectObjects(List<Transform> objects)
		{
		}

		public void ToggleObject(Transform t)
		{
		}

		public void UnselectObject(Transform t)
		{
		}
	}
}
