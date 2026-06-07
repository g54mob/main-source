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
	public class CharacterCustomizerUIController : MonoBehaviour, IUIPanel
	{
		[CompilerGenerated]
		private sealed class _003CTransitionCameraBack_003Ed__83 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterCustomizerUIController _003C_003E4__this;

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
			public _003CTransitionCameraBack_003Ed__83(int _003C_003E1__state)
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
		private sealed class _003CTransitionCameraToWardrobe_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterCustomizerUIController _003C_003E4__this;

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
			public _003CTransitionCameraToWardrobe_003Ed__82(int _003C_003E1__state)
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

		private const string PanelIdConst = "CharacterCustomizerUI";

		[Header("UI Document")]
		[Tooltip("The UIDocument containing the wardrobe UXML")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("Camera Transition")]
		[Tooltip("Duration of camera transition in seconds")]
		[SerializeField]
		private float cameraTransitionDuration;

		[Tooltip("Make player face the camera during customization")]
		[SerializeField]
		private bool rotatePlayerToCamera;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement wardrobePanel;

		private VisualElement contentArea;

		private Button tabBody;

		private Button tabHats;

		private Button tabGlasses;

		private Button tabAccessories;

		private Button currentTab;

		private VisualElement bodyContent;

		private VisualElement hatsContent;

		private VisualElement glassesContent;

		private VisualElement accessoriesContent;

		private Button btnMale;

		private Button btnFemale;

		private VisualElement hatsGrid;

		private VisualElement glassesGrid;

		private Toggle wheatToggle;

		private CharacterCustomizer characterCustomizer;

		private List<Button> hatButtons;

		private List<Button> glassesButtons;

		private bool selectedIsMale;

		private int selectedHatID;

		private int selectedGlassesID;

		private bool selectedWheat;

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

		public static CharacterCustomizerUIController Instance { get; private set; }

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public void Close()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void InitializeUI()
		{
		}

		private void SetupTabHandlers()
		{
		}

		private void SetupBodyTabHandlers()
		{
		}

		private void SetupAccessoriesHandlers()
		{
		}

		private void CleanupUI()
		{
		}

		public void Show(CharacterCustomizer customizer, Transform cameraPosition, WardrobeInteractable wardrobe = null)
		{
		}

		public void Hide()
		{
		}

		private void RegisterWithUIManager()
		{
		}

		private void UnregisterFromUIManager()
		{
		}

		private void OnTabClicked(Button tab, VisualElement content)
		{
		}

		private void ShowTab(Button tab)
		{
		}

		private void OnGenderSelected(bool isMale)
		{
		}

		private void UpdateBodyTabUI()
		{
		}

		private void PopulateHatsGrid()
		{
		}

		private void OnHatSelected(int hatID)
		{
		}

		private void UpdateHatsTabUI()
		{
		}

		private void PopulateGlassesGrid()
		{
		}

		private void OnGlassesSelected(int glassesID)
		{
		}

		private void UpdateGlassesTabUI()
		{
		}

		private void OnWheatToggled(bool enabled)
		{
		}

		private void UpdateAccessoriesTabUI()
		{
		}

		private void SaveCustomizationToPlayerPrefs()
		{
		}

		private Button CreateItemButton(string label, int itemID, bool isHat)
		{
			return null;
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

		[IteratorStateMachine(typeof(_003CTransitionCameraToWardrobe_003Ed__82))]
		private IEnumerator TransitionCameraToWardrobe()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTransitionCameraBack_003Ed__83))]
		private IEnumerator TransitionCameraBack()
		{
			return null;
		}

		private void RotatePlayerToFaceWardrobe()
		{
		}
	}
}
