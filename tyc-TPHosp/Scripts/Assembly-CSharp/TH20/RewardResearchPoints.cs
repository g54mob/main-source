using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardResearchPoints : IReward
	{
		[SerializeField]
		private float _points;

		[SerializeField]
		private SharedInstance<ResearchProjectDefinition> _project;

		public float Points => _points;

		public void Apply(Objective objective, Level level)
		{
			level.ResearchManager.AwardResearchPoints(_points, _project.NotNull() ? _project.Instance : null);
		}

		public string Description(Objective objective)
		{
			string text = ((!_project.IsNull()) ? LocalisedString.Replace(ScriptLocalization.Challenges.Reward_ResearchPoints_CS, "{[PROJECT]}", _project.Instance.NameLocalised.Translation) : ScriptLocalization.Challenges.Reward_ResearchPoints_Random_CS);
			LocalisationParams.Set("POINTS", _points);
			return LocalisationParams.Localise(ref text);
		}
	}
}
