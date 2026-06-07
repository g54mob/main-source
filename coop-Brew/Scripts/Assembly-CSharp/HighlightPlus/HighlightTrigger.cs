using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HighlightPlus
{
	[RequireComponent(typeof(HighlightEffect))]
	[ExecuteInEditMode]
	[HelpURL("https://kronnect.com/guides/highlight-plus-introduction/")]
	public class HighlightTrigger : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDoRayCast_003Ed__50 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HighlightTrigger _003C_003E4__this;

			private WaitForEndOfFrame _003Cw_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDoRayCast_003Ed__50(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Tooltip("Enables highlight when pointer is over this object.")]
		public bool highlightOnHover;

		[Tooltip("Used to trigger automatic highlighting including children objects.")]
		public TriggerMode triggerMode;

		public Camera raycastCamera;

		public RayCastSource raycastSource;

		public LayerMask raycastLayerMask;

		[Tooltip("Minimum distance for target.")]
		public float minDistance;

		[Tooltip("Maximum distance for target. 0 = infinity")]
		public float maxDistance;

		[Tooltip("Blocks interaction if pointer is over an UI element")]
		public bool respectUI;

		public LayerMask volumeLayerMask;

		private const int MAX_RAYCAST_HITS = 100;

		[Tooltip("If the object will be selected by clicking with mouse or tapping on it.")]
		public bool selectOnClick;

		[Tooltip("Profile to use when object is selected by clicking on it.")]
		public HighlightProfile selectedProfile;

		[Tooltip("Profile to use whtn object is selected and highlighted.")]
		public HighlightProfile selectedAndHighlightedProfile;

		[Tooltip("Automatically deselects any other selected object prior selecting this one")]
		public bool singleSelection;

		[Tooltip("Toggles selection on/off when clicking object")]
		public bool toggle;

		[Tooltip("Keeps current selection when clicking outside of any selectable object")]
		public bool keepSelection;

		[NonSerialized]
		public Collider[] colliders;

		[NonSerialized]
		public Collider2D[] colliders2D;

		private UnityEngine.Object currentCollider;

		private static RaycastHit[] hits;

		private static RaycastHit2D[] hits2D;

		private HighlightEffect hb;

		private TriggerMode currentTriggerMode;

		public bool hasColliders => false;

		public bool hasColliders2D => false;

		public HighlightEffect highlightEffect => null;

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

		[RuntimeInitializeOnLoadMethod]
		private static void DomainReloadDisabledSupport()
		{
		}

		private void OnEnable()
		{
		}

		private void OnValidate()
		{
		}

		private void UpdateTriggers()
		{
		}

		public void Init()
		{
		}

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CDoRayCast_003Ed__50))]
		private IEnumerator DoRayCast()
		{
			return null;
		}

		private EventSystem CreateEventSystem()
		{
			return null;
		}

		private void VerifyHighlightStay()
		{
		}

		private void SwitchCollider(UnityEngine.Object newCollider)
		{
		}

		private bool CanInteract()
		{
			return false;
		}

		private void OnMouseDown()
		{
		}

		private void OnMouseEnter()
		{
		}

		private void OnMouseExit()
		{
		}

		private void Highlight(bool state)
		{
		}

		private void ToggleSelection()
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public void OnTriggerExit(Collider other)
		{
		}
	}
}
