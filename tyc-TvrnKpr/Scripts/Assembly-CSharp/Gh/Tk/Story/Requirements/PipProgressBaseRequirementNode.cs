using System;

namespace Gh.Tk.Story.Requirements
{
	public abstract class PipProgressBaseRequirementNode : RequirementNode
	{
		[Serializable]
		public enum ComparisonType
		{
			GreaterOrEqualThan = 0,
			Equals = 1,
			LessOrEqualThan = 2
		}

		public int targetValue;

		public ComparisonType comparisonType;

		private int? _lastValue;

		protected bool IsCurrentValueDirty { get; set; }

		protected virtual int GetEffectiveTargetValue(ActiveStory story)
		{
			return 0;
		}

		public override void Invalidate()
		{
		}

		protected abstract int GetCurrentValue(ActiveStory story);

		public override float GetFilledPips(ActiveStory story)
		{
			return 0f;
		}

		protected override bool IsMetInternal(ActiveStory data)
		{
			return false;
		}

		public override int GetMaxPips(ActiveStory data)
		{
			return 0;
		}

		public override float GetSinglePipValue(ActiveStory data)
		{
			return 0f;
		}
	}
}
