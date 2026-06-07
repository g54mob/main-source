using System.Collections.Generic;
using LitJson;

namespace Gh.Tk
{
	public abstract class SatisfactionStatBase : PatronStat
	{
		public class SatisfactionStatLogItem : IPersistable
		{
			public float percentage;

			[PersistenceObjectReference]
			public TooltipData reason;

			public int count;

			public float? weightingOverride;
		}

		public class SatisfactionStatLog : IPersistable
		{
			private Dictionary<string, List<SatisfactionStatLogItem>> _data;

			[JsonIgnore]
			public Dictionary<string, List<SatisfactionStatLogItem>> Data => null;

			[PersistenceObjectReference]
			public PatronData Owner { get; internal set; }

			public float Percentage { get; internal set; }

			[PersistenceObjectReference]
			public TooltipData Tooltip { get; internal set; }

			internal SatisfactionStatLog CloneShallowLogValues()
			{
				return null;
			}
		}

		[JsonIgnore]
		protected SatisfactionStatLog _percentageLog;

		[PersistenceOptIn]
		private float _previousValue;

		[PersistenceOptIn]
		internal bool _hasBeenSet;

		[PersistenceOptIn]
		private int _displayChevron;

		[PersistenceOptIn]
		protected bool _disabled;

		[PersistenceOptIn]
		public string ReflectsFeedbackCategory { get; private set; }

		protected SatisfactionStatBase()
		{
		}

		protected SatisfactionStatBase(Patron owner, string feedbackCategory)
		{
		}

		public override void SetModifier(string name, float chevrons, string displayReasonKey = "", float durationInSeconds = -1f, string groupableDisplayReasonKey = null)
		{
		}

		public SatisfactionStatLog CloneLogForHistory()
		{
			return null;
		}

		public override void Init()
		{
		}

		public void LogPercentage(float value, string reasonKey, string category = "", float weighting = 1f)
		{
		}

		public void LogPercentage(float value, TooltipData reason, string category = "", float weighting = 1f)
		{
		}

		public override void Update()
		{
		}

		internal static string GetMeterColor(float value)
		{
			return null;
		}

		private void UpdateMeterInfo()
		{
		}

		private void CalculateValueFromPercentages()
		{
		}

		public override TooltipData GenerateTooltipData()
		{
			return null;
		}

		internal virtual void DisableTracking()
		{
		}

		public bool IsDisabled()
		{
			return false;
		}

		private void RecalculateDisplayChevron()
		{
		}

		public override int GetDisplayChevrons(float? changePerSecond = null)
		{
			return 0;
		}
	}
}
