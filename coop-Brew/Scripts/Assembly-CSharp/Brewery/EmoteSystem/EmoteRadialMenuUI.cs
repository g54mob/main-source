using System;
using System.Collections.Generic;
using Synty.AnimationBaseLocomotion.Samples;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.EmoteSystem
{
	[RequireComponent(typeof(UIDocument))]
	public class EmoteRadialMenuUI : MonoBehaviour
	{
		private enum MenuState
		{
			Closed = 0,
			CategoryView = 1,
			EmoteView = 2
		}

		[Header("Layout")]
		[SerializeField]
		private float wedgeRadius;

		[SerializeField]
		private float deadZoneRadius;

		[SerializeField]
		private float sensitivity;

		[SerializeField]
		private float innerRadius;

		[Header("Back Wedge")]
		[SerializeField]
		private Sprite backIcon;

		private UIDocument uiDocument;

		private VisualElement root;

		private VisualElement overlay;

		private VisualElement wedgeContainer;

		private VisualElement centerIcon;

		private Label centerLabel;

		private RadialMeshElement radialMesh;

		private EmoteCategory[] categories;

		private EmoteCategory activeCategory;

		private Action<EmoteDefinition> onEmoteSelected;

		private Sprite[] currentIcons;

		private string[] currentLabels;

		private int currentCount;

		private bool[] wedgeDisabled;

		private VisualElement[] wedgeElements;

		private float[] wedgeAngles;

		private int highlightedIndex;

		private Vector2 virtualCursor;

		private Color[] currentAccentColors;

		private float currentWedgeSize;

		private MenuState state;

		private bool isTransitioning;

		private Func<bool> isMovingCheck;

		private const float PopDistance = 22f;

		private const long TransitionExitMs = 120L;

		private const long TransitionEnterMs = 150L;

		private const float StaggerDelayMs = 35f;

		private SampleCameraController cameraController;

		private const int MaxRecentEmotes = 3;

		private List<EmoteDefinition> recentEmotes;

		public bool IsOpen => false;

		public static bool IsAnyMenuOpen { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Show(EmoteCategory[] emoteCategories, Action<EmoteDefinition> callback, Func<bool> movingCheck = null)
		{
		}

		public void Close()
		{
		}

		public void RecordRecentEmote(EmoteDefinition emote)
		{
		}

		private void HandleClick()
		{
		}

		private void TransitionWedges(Action rebuildAction)
		{
		}

		private void TransitionToEmoteView(EmoteCategory category)
		{
		}

		private void TransitionToCategoryView()
		{
		}

		private void BuildCategoryWedges()
		{
		}

		private void BuildEmoteWedges(EmoteCategory category)
		{
		}

		private void BuildWedges(Sprite[] icons, string[] labels, int count)
		{
		}

		private void ClearCurrentHighlight()
		{
		}

		private void UpdateSelection()
		{
		}

		private int FindClosestEnabledWedge()
		{
			return 0;
		}

		private void UpdateDisabledStates()
		{
		}

		private void UpdateCenterDisplay(int index)
		{
		}

		private void ApplyStaggeredEntrance()
		{
		}

		private static void SetWedgeBorderColor(VisualElement wedge, Color color)
		{
		}

		private void HideImmediate()
		{
		}
	}
}
