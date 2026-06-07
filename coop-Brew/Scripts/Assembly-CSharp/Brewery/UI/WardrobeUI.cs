using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Interaction;
using Player.Customization;
using Synty.AnimationBaseLocomotion.Samples;
using UI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.UI
{
	public class WardrobeUI : MonoBehaviour, IUIPanel
	{
		[CompilerGenerated]
		private sealed class _003CTransitionCameraBack_003Ed__63 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WardrobeUI _003C_003E4__this;

			private Vector3 _003CstartPos_003E5__2;

			private Quaternion _003CstartRot_003E5__3;

			private float _003Celapsed_003E5__4;

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
			public _003CTransitionCameraBack_003Ed__63(int _003C_003E1__state)
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
		private sealed class _003CTransitionCameraToWardrobe_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WardrobeUI _003C_003E4__this;

			private Vector3 _003CstartPos_003E5__2;

			private Quaternion _003CstartRot_003E5__3;

			private Vector3 _003CtargetPos_003E5__4;

			private Quaternion _003CtargetRot_003E5__5;

			private float _003Celapsed_003E5__6;

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
			public _003CTransitionCameraToWardrobe_003Ed__62(int _003C_003E1__state)
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

		private const string PanelIdConst = "WardrobeUI";

		[Header("UI References")]
		[Tooltip("UIDocument component for the wardrobe interface")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("Camera Transition")]
		[Tooltip("Default transform for camera position (used if not provided by interactable)")]
		[SerializeField]
		private Transform defaultCameraPosition;

		[Tooltip("Duration of camera transition in seconds")]
		[SerializeField]
		private float cameraTransitionDuration;

		[Tooltip("Make player face the camera during customization")]
		[SerializeField]
		private bool rotatePlayerToCamera;

		[Header("Debug")]
		[Tooltip("Show debug logs")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement root;

		private VisualElement wardrobeContainer;

		private Button btnMale;

		private Button btnFemale;

		private VisualElement hatsGrid;

		private VisualElement glassesGrid;

		private Toggle wheatToggle;

		private Button btnApply;

		private Button btnCancel;

		private CharacterCustomizer playerCustomizer;

		private CharacterCustomization tempCustomization;

		private CharacterCustomization originalCustomization;

		private WardrobeInteractable activeWardrobe;

		private SampleCameraController cameraController;

		private SamplePlayerAnimationController playerAnimationController;

		private Transform cameraTransform;

		private Transform originalCameraParent;

		private Transform activeCameraPosition;

		private Vector3 originalCameraPosition;

		private Quaternion originalCameraRotation;

		private Quaternion originalPlayerRotation;

		private bool isCameraTransitioning;

		private Coroutine currentTransition;

		private bool isRegisteredWithUIManager;

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void SetupUI()
		{
		}

		public void Show(CharacterCustomizer customizer)
		{
		}

		public void ShowWithCameraPosition(CharacterCustomizer customizer, Transform cameraPosition, WardrobeInteractable wardrobe = null)
		{
		}

		public void Hide()
		{
		}

		public bool IsVisible()
		{
			return false;
		}

		public void Close()
		{
		}

		private void RegisterWithUIManager()
		{
		}

		private void UnregisterFromUIManager()
		{
		}

		private void PopulateHats()
		{
		}

		private void PopulateGlasses()
		{
		}

		private Button CreateItemButton(string itemName, int itemID, string category)
		{
			return null;
		}

		private void UpdateUI()
		{
		}

		private void UpdateGenderButtons()
		{
		}

		private void UpdateHatSelection()
		{
		}

		private void UpdateGlassesSelection()
		{
		}

		private void UpdateWheatToggle()
		{
		}

		private void OnGenderClicked(bool isMale)
		{
		}

		private void OnItemClicked(string category, int itemID)
		{
		}

		private void OnWheatToggled(bool enabled)
		{
		}

		private void OnApplyClicked()
		{
		}

		private void OnCancelClicked()
		{
		}

		private void SetupCameraTransition()
		{
		}

		private void RestoreCameraAndPlayer()
		{
		}

		private void RestoreCameraImmediate()
		{
		}

		[IteratorStateMachine(typeof(_003CTransitionCameraToWardrobe_003Ed__62))]
		private IEnumerator TransitionCameraToWardrobe()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTransitionCameraBack_003Ed__63))]
		private IEnumerator TransitionCameraBack()
		{
			return null;
		}

		private void RotatePlayerToFaceWardrobe()
		{
		}
	}
}
