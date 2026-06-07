using Assets.Nimbatus.Scripts.Common.MiniMap;
using Assets.Nimbatus.Scripts.Persistence;

namespace Assets.Nimbatus.Scripts.Missions.Objectives
{
	public class SurveyObjective : MissionObjective
	{
		public float Percentage;

		private float _currentPercentage;

		private bool _override;

		public void UpdatePercentage()
		{
			if (!(BaseSingleton<Minimap>.Instance == null) && BaseSingleton<Minimap>.Instance.IsPlanet)
			{
				_currentPercentage = BaseSingleton<Minimap>.Instance.GetUncoverPercentage();
			}
		}

		public override bool IsFullfilled()
		{
			if (BaseSingleton<Minimap>.Instance == null || !BaseSingleton<Minimap>.Instance.IsPlanet)
			{
				return false;
			}
			if (!_override)
			{
				return _currentPercentage > Percentage;
			}
			return true;
		}

		public override string GetStatusText()
		{
			if (BaseSingleton<Minimap>.Instance == null || !BaseSingleton<Minimap>.Instance.IsPlanet)
			{
				return "";
			}
			string translation = ObjectiveText.GetTranslation();
			if (IsFullfilled())
			{
				return translation;
			}
			return translation + " " + (BaseSingleton<Minimap>.Instance.GetUncoverPercentage() / Percentage * 100f).ToString("F1") + "%";
		}

		public override void ResetProgress()
		{
			_override = false;
			_currentPercentage = 0f;
		}

		public override void Init()
		{
			_override = false;
			_currentPercentage = 0f;
		}

		public override void SetFullfilled()
		{
			_override = true;
		}
	}
}
