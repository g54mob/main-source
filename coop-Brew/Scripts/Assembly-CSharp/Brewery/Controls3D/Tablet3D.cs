using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Synty.AnimationBaseLocomotion.Samples;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UI.Core;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class Tablet3D : MonoBehaviour, IUIPanel
	{
		[CompilerGenerated]
		private sealed class _003CSmoothTransition_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public Tablet3D _003C_003E4__this;

			public Vector3 startPos;

			public Vector3 endPos;

			public Quaternion startRot;

			public Quaternion endRot;

			private float _003Celapsed_003E5__2;

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
			public _003CSmoothTransition_003Ed__56(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSmoothTransitionOut_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public Tablet3D _003C_003E4__this;

			public Vector3 startPos;

			public Vector3 endPos;

			public Quaternion startRot;

			public Quaternion endRot;

			private float _003Celapsed_003E5__2;

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
			public _003CSmoothTransitionOut_003Ed__57(int _003C_003E1__state)
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

		[Header("Tabs")]
		[Tooltip("Tab bar buttons — one per page, parallel with tabPages")]
		[SerializeField]
		private Button3D[] tabButtons;

		[Tooltip("Tab visual wrappers — parallel with tabButtons")]
		[SerializeField]
		private TabButton3D[] tabVisuals;

		[Tooltip("Page root GameObjects — toggled via SetActive")]
		[SerializeField]
		private GameObject[] tabPages;

		[Header("Tab Page Animation")]
		[Tooltip("Entrance animation for each child when a tab page activates")]
		[SerializeField]
		private TweenConfig pageEnterAnimation;

		[Tooltip("Delay between each child's entrance (stagger effect)")]
		[SerializeField]
		private float pageStaggerDelay;

		[Header("Close")]
		[SerializeField]
		private Button3D closeButton;

		[Header("Camera")]
		[Tooltip("Where the camera should move to when viewing this tablet")]
		[SerializeField]
		private Transform cameraViewPoint;

		[SerializeField]
		private float cameraTransitionDuration;

		[Header("Panel Settings")]
		[SerializeField]
		private string panelId;

		[SerializeField]
		private int priority;

		private int activeTabIndex;

		private bool isVisible;

		private readonly Dictionary<Transform, Vector3> originalScales;

		private readonly List<int> activePageTweenIds;

		private Transform cameraRig;

		private Transform originalRigParent;

		private Vector3 originalRigLocalPos;

		private Quaternion originalRigLocalRot;

		private SampleCameraController cameraController;

		private InputReader inputReader;

		private bool wasCameraControllerEnabled;

		private Coroutine transitionCoroutine;

		private bool needsControlRestore;

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public int ActiveTabIndex => 0;

		public bool IsVisible => false;

		public Button3D[] TabButtons => null;

		public event Action OnShown
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

		public event Action OnHidden
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

		public event Action<int> OnTabChanged
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

		public Vector3 GetOriginalScale(Transform child)
		{
			return default(Vector3);
		}

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		public void Close()
		{
		}

		public void SwitchToTab(int index)
		{
		}

		private void FindPlayerComponents()
		{
		}

		private void BlockPlayerControls()
		{
		}

		private void RestorePlayerControls()
		{
		}

		private void TransitionCameraIn()
		{
		}

		private void TransitionCameraOut()
		{
		}

		[IteratorStateMachine(typeof(_003CSmoothTransition_003Ed__56))]
		private IEnumerator SmoothTransition(Vector3 startPos, Vector3 endPos, Quaternion startRot, Quaternion endRot, float duration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSmoothTransitionOut_003Ed__57))]
		private IEnumerator SmoothTransitionOut(Vector3 startPos, Vector3 endPos, Quaternion startRot, Quaternion endRot, float duration)
		{
			return null;
		}

		private void AnimatePageEntrance(GameObject page)
		{
		}

		private void CancelPageTweens()
		{
		}

		private void RestoreChildScales(GameObject page)
		{
		}

		private void ForceRestoreCamera()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
