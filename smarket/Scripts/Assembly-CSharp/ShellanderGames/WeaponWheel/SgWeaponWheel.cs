using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ShellanderGames.WeaponWheel
{
	[RequireComponent(typeof(CanvasGroup))]
	public class SgWeaponWheel : MonoBehaviour
	{
		[Tooltip("Auto-refresh your changes. If turned off, you can still refresh by pressing the bottom button.")]
		public bool autoRefresh;

		[Tooltip("Margin/borders between slices.")]
		public float sliceBorderWidth;

		[Tooltip("If your slice border is reaching in too far, it can be adjusted here.")]
		public float sliceBorderCutInnerAdjustment;

		[Tooltip("If your slice border is reaching out too far, it can be adjusted here.")]
		public float sliceBorderCutOuterAdjustment;

		[Tooltip("When cutting slice borders, affect circles too. Will make the slice borders blend in better with the circles, but can result in harder circle edges.")]
		public bool cutCirclesToo;

		public SgSelectableData sliceBorderColors;

		[Tooltip("Slice content graphics (e.g. icons and text) colors. Can be overridden for each slice in the content controllers.")]
		public SgSelectableData sliceContentColors;

		[Range(0f, 360f)]
		public float rotation;

		[Tooltip("Controls the number of slices and contains the unique slice controllers. Double click an element to jump to it.")]
		public List<SgSliceController> sliceContents;

		[Tooltip("Debug logs weapon wheel events such as highlighting and wheel visibility changes.")]
		public bool logSelectionEvents;

		[Tooltip("A circle may be the main content or borders, it's up to you. It's important to mark the main content as main using the checkbox to align the content graphics properly.")]
		public List<SgCircleData> circleDatas;

		[Tooltip("Animated effect. Fade in weapon wheel when it's made visible")]
		public float fadeInDuration;

		[Tooltip("Animated effect. Fade out weapon wheel when it's made invisible")]
		public float fadeOutDuration;

		[Tooltip("Triggered when a slice is highlighted. A SgSliceController is passed as the first parameter.")]
		public UnityEvent<SgSliceController> OnSliceHighlighted;

		[Tooltip("Triggered when a slice is dehighlighted. A SgSliceController is passed as the first parameter.")]
		public UnityEvent<SgSliceController> OnSliceDehighlighted;

		[Tooltip("Triggered when a slice is selected (pressed/confirmed). A SgSliceController is passed as the first parameter.")]
		public UnityEvent<SgSliceController> OnSliceSelected;

		[Tooltip("Triggered when the weapon wheel is becoming visible")]
		public UnityEvent OnWheelVisible;

		[Tooltip("Triggered when the weapon wheel is becoming invisible (closed)")]
		public UnityEvent OnWheelInvisible;

		[Tooltip("Triggered when any weapon wheel event is triggered")]
		public UnityEvent<SgWeaponWheelEvent> OnAnyEvent;

		public Material sliceBorderMaterial;

		public Material circleMaterial;

		public Material circleUncutMaterial;

		public Material circleMaskMaterial;

		public Material circleHoleMaskMaterial;

		[Tooltip("Where all generated content are put. Most child objects should be considered temporary and will be overwritten in the next refresh.")]
		public GameObject generatedObjectsContainer;

		public SgCircleSpriteData circleSprites;

		[Tooltip("Optional slice border sprite.")]
		public Sprite sliceBorderSprite;

		private readonly List<Action<SgWeaponWheelEvent>> m_EventCallbacks;

		private readonly List<SgSliceBorder> m_NewBorders;

		private readonly List<SgCircleSlice> m_NewCircleSlices;

		private bool m_IsVisible;

		private CanvasGroup m_CanvasGroup;

		private SgAnimationManager m_AnimationManager;

		public int NumberOfSlices => 0;

		private float SliceRatio => 0f;

		private CanvasGroup CanvasGroup => null;

		public SgAnimationManager AnimationManager => null;

		public bool IsVisible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void AddEventCallback(Action<SgWeaponWheelEvent> action)
		{
		}

		public void RemoveEventCallback(Action<SgWeaponWheelEvent> action)
		{
		}

		public void ToggleVisibility()
		{
		}

		private void AnimateVisibility(bool visible)
		{
		}

		private void AnimateVisibilityDone()
		{
		}

		public void DehighlightAll(bool forceImmidiate, SgSliceController ignore = null)
		{
		}

		public void HighlightClosest(float angle)
		{
		}

		public void NotifyEvent(SgWeaponWheelEvent wheelEvent)
		{
		}

		public void SelectHighlighted()
		{
		}

		public void PrioritizeClosest(Vector2 position)
		{
		}

		public void Generate(bool destroyOldObjectsImmediately, bool enableLogging)
		{
		}

		private bool Validate(bool enableLogging)
		{
			return false;
		}

		private void CreateMasks()
		{
		}

		private void MapCircleSlicesToControllers()
		{
		}

		private GameObject CreateCircle(int index, SgCircleData circleData)
		{
			return null;
		}

		private GameObject CreateUiObject(string name)
		{
			return null;
		}

		private static void AnchorTo(RectTransform rectTransform, Transform parent)
		{
		}

		private SgCircleSpriteData GetSpriteData(SgCircleData circleData)
		{
			return null;
		}

		private void Cleanup(bool destroyOldObjectsImmediately)
		{
		}
	}
}
