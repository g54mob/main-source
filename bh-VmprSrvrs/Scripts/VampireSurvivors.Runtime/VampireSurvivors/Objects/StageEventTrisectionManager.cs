using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects
{
	[UsedImplicitly]
	public class StageEventTrisectionManager : StageEventManager
	{
		[Serializable]
		public class WeightedTrisectionEventData
		{
			public int weight;

			public TrisectionEvent ev;
		}

		public enum ChoiceType
		{
			GOOD = 0,
			NEUTRAL = 1,
			BAD = 2
		}

		public float _tweenCounterTargetValue;

		protected PhaserText _nextEventText;

		protected Vector3 _nextEventTextDefaultLocalPosition;

		protected Vector3 _nextEventTextGoldFeverLocalPosition;

		protected List<TrisectionEvent> _goodEvents;

		protected List<TrisectionEvent> _neutralEvents;

		protected List<TrisectionEvent> _badEvents;

		protected List<TrisectionEvent> _triggeredEvents;

		protected bool _dontRepeatEvents;

		protected MultiTargetTween _tweenHideCircles;

		protected MultiTargetTween _tweenShowCircles;

		protected MultiTargetTween _tweenCounter;

		private PhaserSprite _sCenter;

		private PhaserSprite _sWorld;

		private PhaserSprite _sMoon;

		private PhaserSprite _sSun;

		private MultiTargetTween _tweenWorld;

		private MultiTargetTween _tweenMoon;

		private MultiTargetTween _tweenSun;

		private MultiTargetTween _tweenRotateName;

		private MultiTargetTween _tweenHighlightName;

		protected int _totalWeightGood;

		protected int _totalWeightNeutral;

		protected int _totalWeightBad;

		private List<string> _eventNames;

		protected List<WeightedTrisectionEventData> _weightedGood;

		protected List<WeightedTrisectionEventData> _weightedNeutral;

		protected List<WeightedTrisectionEventData> _weightedBad;

		private ChoiceType _nextChoice;

		protected WeightedTrisectionEventData _nextChosenEvent;

		protected Unity.Mathematics.Random _eventsRng;

		public override void Init(Stage stage)
		{
		}

		public void SetSeed(uint seed)
		{
		}

		public void ShowUI()
		{
		}

		public void HideUI()
		{
		}

		public virtual void Spinnn(float duration = 10000f, TrisectionEvent forcedEvent = null, Action onEventSelected = null)
		{
		}

		public void TriggerTrisectionEvent()
		{
		}

		public List<TrisectionEvent> GetAllEvents()
		{
			return null;
		}

		public void TrisectionUpdate()
		{
		}

		protected virtual void PopulateEvents()
		{
		}

		protected virtual void CreateUI()
		{
		}

		private void CalculateWeights()
		{
		}

		private List<WeightedTrisectionEventData> BuildWeightedList(List<TrisectionEvent> events, bool dontRepeatEvents)
		{
			return null;
		}

		protected void CalculateMainChances()
		{
		}

		protected virtual void ChooseEvent()
		{
		}

		protected virtual void ShowCircles()
		{
		}

		protected virtual void HideCircles()
		{
		}

		protected void RotateEventNames()
		{
		}

		protected void HighlightEventName(Action onTextHighlighted = null)
		{
		}

		private string GetEventName(TrisectionEvent trisectionEvent)
		{
			return null;
		}
	}
}
