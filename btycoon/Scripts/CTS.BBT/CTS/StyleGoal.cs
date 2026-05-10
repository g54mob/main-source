using CTS.Core;

namespace CTS
{
	public class StyleGoal : QuestNumericGoal
	{
		private EBarStyle[] _targetStyle;

		private float _targetUnitInterval;

		public StyleGoal(Quest quest, int entryID, string variableName, string targetVariableName, float targetUnitInterval, params EBarStyle[] targetStyle)
			: base(quest, entryID, variableName, targetVariableName)
		{
			_targetStyle = targetStyle;
			_targetUnitInterval = targetUnitInterval;
		}

		public override void StopObserving()
		{
			BarStyleInfluence.StylesInfluenceChanged -= OnStylesInfluenceChanged;
		}

		public override void StartObserving()
		{
			BarStyleInfluence.StylesInfluenceChanged += OnStylesInfluenceChanged;
			OnStylesInfluenceChanged(CTSSingleton<BarStyleInfluence>.Instance);
		}

		private void OnStylesInfluenceChanged(BarStyleInfluence influences)
		{
			base.TargetValue = influences.TotalInfluence * _targetUnitInterval;
			if (base.TargetValue == 0f)
			{
				base.TargetValue = 1f;
			}
			SetGoalVariable(influences.GetStyleInfluence(_targetStyle));
		}
	}
}
