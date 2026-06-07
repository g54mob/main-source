using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class EventTimeline3DUIView : MonoBehaviour
	{
		public GameObject timelineItemPrefab;

		[SerializeField]
		private GameObject _timelineItemsParent;

		private Transform _timelineStartPosition;

		private Transform _timelineEndPosition;

		private Dictionary<int, TimelineItem3DUIView> _timelineItems;

		public GameObject timelineRangePrefab;

		[SerializeField]
		private List<BaseInteractable3DUIView> _timelineItemsLinkedHover;

		private List<TimelineRange3DUIView> _timeRanges;

		private bool _isTimeRangeDirty;

		public GameObject timelineBackground;

		private Material _timelineBackgroundMat;

		public Gradient gradient;

		public Gradient gradientUpperSky;

		public List<ParticleSystem> cloudParticles;

		public Animator starsAnimator;

		public Animator sunAnimator;

		private bool _sunEnabled;

		private bool _starsEnabled;

		public float dayStartedTime;

		public float dayEndingTime;

		public float nightStartedTime;

		public float nightEndingTime;

		public List<Animator> sceneryWobbleAnimators;

		private List<float> _wobbleSpeeds;

		private OtherEvents3DUIView _otherEventsView;

		private bool _eventTimelineIsDirty;

		private int daysToDisplay;

		private void Start()
		{
		}

		private void MarkEventIconsDirty(object sender, EventArgs eventArgs)
		{
		}

		public float GetTimelinePosition(float dueInDays)
		{
			return 0f;
		}

		private float CalculateItemPosition(float percentagePosition)
		{
			return 0f;
		}

		private void UpdateEventsIcons(object sender, EventArgs e)
		{
		}

		private void OnEnable()
		{
		}

		private void UIController_ResetUI(object sender, EventArgs e)
		{
		}

		private void Update()
		{
		}
	}
}
