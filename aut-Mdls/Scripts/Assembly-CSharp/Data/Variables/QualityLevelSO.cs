#define ENABLE_DEBUG_LOGS
using UnityEngine;
using Utils;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/Settings/QualityLevel", fileName = "QualityLevel", order = 0)]
	public class QualityLevelSO : VariableSO<int>
	{
		public override void SetValue(int value)
		{
			if (value != QualitySettings.GetQualityLevel())
			{
				this.Log($"Set to {value}", "SetValue", 14);
				QualitySettings.SetQualityLevel(value, applyExpensiveChanges: true);
			}
			base.SetValue(value);
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}
	}
}
