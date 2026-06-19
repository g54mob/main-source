using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PatientTabOverviewPanel : OverviewMenuTrendPanelBase
	{
		[SerializeField]
		private PanelItemTrendIcon _happinessTrend;

		[SerializeField]
		private PanelItemTrendIcon _healthTrend;

		private GameObject _advisorPortraitSceneObject;

		private AdvisorPortraitScene _advisorPortraitScene;

		public bool AdvisorVisible
		{
			private get
			{
				if (_advisorPortraitSceneObject != null)
				{
					return _advisorPortraitSceneObject.activeSelf;
				}
				return false;
			}
			set
			{
				if (value)
				{
					_advisorPortraitScene.ShowAdvisorModel();
				}
				else
				{
					_advisorPortraitScene.PopDownAdvisor();
				}
			}
		}

		public void SetupAdvisor(AdvisorPortraitScene _theAdvisorPortraitScene)
		{
			_advisorPortraitScene = _theAdvisorPortraitScene;
			_advisorPortraitSceneObject = _advisorPortraitScene.gameObject;
		}

		public void ResetAdvisor()
		{
			_advisorPortraitScene.HideAdvisorModel();
		}

		protected override void Refresh()
		{
			base.Refresh();
			float currentValue = 0f;
			float previousValue = 0f;
			float currentValue2 = 0f;
			float previousValue2 = 0f;
			List<LevelStatsDatabase.MonthStats> previousMonthlyStats = _levelStatsDatabase.GetPreviousMonthlyStats(GameAlgorithms.Config.NumMonthsForGeneralTrendIndicators);
			if (previousMonthlyStats.Count > 0)
			{
				currentValue = Mathf.Max(previousMonthlyStats[0].PatientHappiness, 0.1f);
				previousValue = Mathf.Max(previousMonthlyStats.Last().PatientHappiness, 0.1f);
				currentValue2 = Mathf.Max(previousMonthlyStats[0].PatientHealth, 0.1f);
				previousValue2 = Mathf.Max(previousMonthlyStats.Last().PatientHealth, 0.1f);
			}
			if (_happinessTrend != null)
			{
				_happinessTrend.SetTrend(previousValue, currentValue);
			}
			if (_healthTrend != null)
			{
				_healthTrend.SetTrend(previousValue2, currentValue2);
			}
		}
	}
}
