using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class TimelineItem3DUIView : BaseInteractable3DUIView
	{
		public bool animateBobbing;

		private List<Animator> _itemAnimators;

		[SerializeField]
		private GameObject _visualRoot;

		[SerializeField]
		private Collider _mainCollider;

		[SerializeField]
		private Transform _iconParent;

		[SerializeField]
		private SpriteRenderer _markerDotSprite;

		[SerializeField]
		private Button3DUIView _markerDot;

		[SerializeField]
		private Color _noOverlapColor;

		[SerializeField]
		private Color _singleOverlapColor;

		[SerializeField]
		private Color _multiOverlapColor;

		protected Transform _overlapBannerIcon;

		protected Transform _eventIcon;

		private GameEvent _source;

		private float _timelinePercentagePosition;

		private static string OverlapBannerPrefabName;

		public static string FallbackIconPrefabName;

		private static string MysteryIconPrefabName;

		private int _currentOverlapDisplayedNumber;

		private bool _isGroupLeader;

		private TimelineRange3DUIView _timelineRange;

		private float _baseRange;

		private Collider[] _overlapResults;

		private const int maxOverlappingItems = 3;

		private List<TimelineItem3DUIView> _overlappingItems;

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnPatronAttractionClarityChanged(object sender, EventArgs e)
		{
		}

		private void Update()
		{
		}

		public void SetTimelineItemData(GameEvent source)
		{
		}

		protected virtual void CreateOverlapIcon()
		{
		}

		protected void ShowOverlapBannerIcon(int itemsOverlapped)
		{
		}

		private void UpdateMarketDotColour(int itemsOverlapped = 0)
		{
		}

		protected void HideOverlapBannerIcon(bool isEventIconShown)
		{
		}

		protected void ShowEventIcon()
		{
		}

		private void ShowMarkerDot()
		{
		}

		protected void HideEventIcon()
		{
		}

		private void HideMarkerDot()
		{
		}

		protected virtual void SetEventIcon(string prefabName)
		{
		}

		public void UpdatePosition(float positionX)
		{
		}

		public void UpdateLocalPosition(float positionX, float percentagePosition)
		{
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}

		public static TooltipData CreateTimelineTooltip(IEnumerable<TimelineItem3DUIView> tooltipProviders)
		{
			return null;
		}

		private TooltipData GetSourceTooltipData()
		{
			return null;
		}

		private string GetSummaryText()
		{
			return null;
		}

		private IEnumerable<TimelineItem3DUIView> GetOverlappingTimelineItems(IEnumerable<TimelineItem3DUIView> ignoreItems)
		{
			return null;
		}

		public void GroupOverlaps(List<TimelineItem3DUIView> itemsResolved)
		{
		}

		public void ResetCollider()
		{
		}

		private void SetVisualState(bool isVisible)
		{
		}
	}
}
