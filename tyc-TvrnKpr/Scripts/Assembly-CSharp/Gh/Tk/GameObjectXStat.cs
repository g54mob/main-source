using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public abstract class GameObjectXStat : AiComponent
	{
		protected static Dictionary<Type, int> _defaultDisplayOrder;

		public EventHandler<ValueChangedEventArgs<float>> ValueChanged;

		[PersistenceOptIn]
		private float _value;

		protected float _currentChangePerSecond;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		protected bool _trackChanges;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private Dictionary<int, Dictionary<string, double>> _trackedChanges;

		private static readonly List<string> _modifiersToRemove;

		private static readonly Dictionary<string, double> _effectiveModifierTmpDictionary;

		private TooltipData _24HourChangeTooltipData;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsFrozen { get; set; }

		public virtual float Value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		public string MeterColor { get; set; }

		[PersistenceOptIn]
		public List<TooltipPart> TooltipParts { get; protected set; }

		[PersistenceOptIn]
		protected Dictionary<string, StatModifier> _statModifiers { get; set; }

		[PersistenceOptIn]
		protected Dictionary<string, int> _thresholdMarkers { get; set; }

		public float CurrentChangePerSecond => 0f;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void TimeController_HourChanged(object sender, EventArgs e)
		{
		}

		protected GameObjectXStat()
		{
		}

		public GameObjectXStat(GameObjectX owner, string name, string displayNameKey, float startingValue, string meterColor)
		{
		}

		public void SetTooltipPart(string key, string textKey, string headerKey = null)
		{
		}

		public IEnumerable<(int, string)> GetIndicators()
		{
			return null;
		}

		private void TrackChanges(Dictionary<string, double> absoluteChanges)
		{
		}

		private void OnHourChanged()
		{
		}

		public override void Update()
		{
		}

		private void CalculateModifier()
		{
		}

		public virtual void SetModifier(string name, float changePerSecond, string displayReasonKey = "", float durationInSeconds = -1f, string groupableDisplayReasonKey = null)
		{
		}

		public StatModifier GetModifier(string key)
		{
			return null;
		}

		public virtual int GetDisplayChevrons(float? changePerSecond = null)
		{
			return 0;
		}

		public void SetThresholdMarker(string name, float position)
		{
		}

		public void RemoveThresholdMarker(string name)
		{
		}

		private string GetChangePerHourLabelKey(float changePerSecondF, string descriptionKey, float duration = -1f)
		{
			return null;
		}

		protected string GetModifierNameKeys()
		{
			return null;
		}

		public virtual TooltipData GenerateTooltipData()
		{
			return null;
		}

		public float GetSecondsUntilDepletion()
		{
			return 0f;
		}
	}
}
