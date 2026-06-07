using System;
using System.Collections.Generic;
using DG.Tweening;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class PatronAttractionChart : MonoBehaviour
	{
		public class ModelCacheItem
		{
			public PatronPopulationData data;

			public bool isInUse;

			public GameObject model;

			public ModelCacheItem(PatronPopulationData data, bool isInUse, GameObject model)
			{
			}
		}

		public class AttractionChartItem
		{
			internal PatronPopulationData sourcePopulationData;

			public int hour;

			public string race;

			public int tier;

			public GameObject model;

			public PatronAttractionChartGroupEventView groupEventView;

			public bool isPositioned;

			public bool willVisitTavern;

			public AttractionChartItem(PatronPopulationData data)
			{
			}

			internal TooltipData GenerateTooltipData()
			{
				return null;
			}
		}

		[Serializable]
		public class TimelineMarker
		{
			public TextMeshProI18n text;

			public Transform marker;

			public int hour;
		}

		public struct HourSnapPositionData
		{
			public float Position;

			public float MiddlePosition;

			public int HourSlot;

			public int HourActual;
		}

		public PatronAttractionDialog3DUIView attractionDialog;

		public Transform animationEpicenter;

		public GameObject[] pawnPrefabs;

		public GameObject pawnDissolveParticlePrefab;

		public GameObject pawnClarityRevealPrefab;

		[SerializeField]
		private GameObject _groupEventPrefab;

		[Header("category switch translation")]
		public Ease translationEase;

		public float translationEaseDuration;

		[Header("new model drop animation")]
		public Ease dropEase;

		[Tooltip("for when models are hidden")]
		public Ease dropReverseEase;

		public float dropDuration;

		public float dropDistance;

		[Header("overall animation timing")]
		public float sequenceDuration;

		public AnimationCurve pawnAnimationDistanceDurationCurve;

		public float firstOpenDelay;

		public Transform hourIndicator;

		public Transform defaultLeftClamp;

		public Transform boardLeftClamp;

		public Transform boardRightClamp;

		public float lineSpacing;

		public const int HistoryHourBuffer = 12;

		public const int FutureHoursLength = 48;

		public const int VisualBufferHoursLength = 6;

		[Header("Arcane Curtain")]
		public ParticleSystem arcaneCurtainDragEffect;

		[SerializeField]
		private BasicAnimationEventObserver _maskingAnimationEventObserver;

		private bool _wasClosed;

		public Transform moveableArcaneMask;

		public Ease arcaneMaskEasing;

		public float arcaneMaskTweenDuration;

		private float _currentClarityHours;

		private List<Sequence> _arcaneMaskTweens;

		private Dictionary<int, float> _hourAndYPosDict;

		private List<ModelCacheItem> _models;

		private GameObject _cursor;

		private int _gridHeight;

		private List<(AttractionChartItem chartItem, float xPos, Action animation)> _pawnAnimations;

		private List<AttractionChartItem> _data;

		[Header("Timeline")]
		public GameObject timelineItemPrefab;

		public GameObject timelineRangePrefab;

		[SerializeField]
		private Transform _timelineElementsParent;

		[SerializeField]
		private Transform _timelineStartPosition;

		[SerializeField]
		private Transform _timelineEndPosition;

		public List<TimelineMarker> markers;

		private Dictionary<int, TimelineItem3DUIView> _timelineItems;

		private List<TimelineRange3DUIView> _timeRanges;

		private bool _isTimeRangeDirty;

		private List<HourSnapPositionData> _hourSnapPositions;

		private static int TotalBoardHours => 0;

		public List<HourSnapPositionData> HourSnapPositions => null;

		private void Awake()
		{
		}

		public void Close()
		{
		}

		public void Refresh(IEnumerable<PatronPopulationData> population, bool useFastAnim)
		{
		}

		public void RefreshWithCurrentData()
		{
		}

		private void UpdateArcaneCurtain(bool animate = true)
		{
		}

		private void UpdateBoardBackgroundOffset()
		{
		}

		public Vector3 GetPositionAtHour(float hour, bool getMiddleOfHour = true)
		{
			return default(Vector3);
		}

		internal void PlayCloseAnimations()
		{
		}

		public static IEnumerable<AttractionChartItem> FilterVisibleChartItems(IEnumerable<AttractionChartItem> items, List<(AttractionChartItem chartItem, float xPos, Action animation)> oldAnimations)
		{
			return null;
		}

		private void ShowData(bool useFastAnim)
		{
		}

		private GameObject GetModel(AttractionChartItem data)
		{
			return null;
		}

		public float GetLocalGridPositionX(float hour, bool getMiddleOfHour = true)
		{
			return 0f;
		}

		private void PositionOnGrid(AttractionChartItem item)
		{
		}

		private void DropInPawn(AttractionChartItem item, Vector3 localPosition)
		{
		}

		private void DropOutPawn(GameObject model)
		{
		}

		private void MovePawn(AttractionChartItem item, Vector3 localPosition)
		{
		}

		private void RevealPawn(AttractionChartItem item)
		{
		}

		private void DestroyFakePawn(AttractionChartItem item)
		{
		}

		private void RefreshTimeline()
		{
		}

		private void UpdateEventVisuals()
		{
		}

		private void UpdateTimelineMarkers()
		{
		}

		public void CollectSnapData()
		{
		}

		public HourSnapPositionData GetClosestSnapData(float position, bool getMiddlePosition = false, bool includeHistoric = false)
		{
			return default(HourSnapPositionData);
		}
	}
}
