namespace TH20
{
	public class MetagameStateInHospital : BaseStateInHospital
	{
		private readonly LevelConfig _levelConfig;

		private readonly MetagameHospitalRecord _hospitalRecord;

		private readonly bool _restartLevel;

		private readonly bool _saveOldLevel;

		public MetagameStateInHospital(MetagameMap map, LevelConfig levelConfig, bool restartLevel = false, bool saveOldLevel = true)
			: base(map)
		{
			_levelConfig = levelConfig;
			_hospitalRecord = Metagame.GetHospitalRecord(levelConfig);
			_restartLevel = restartLevel;
			_saveOldLevel = saveOldLevel;
		}

		public override void Enter()
		{
			if (_restartLevel)
			{
				MetagameMap.Metagame.ResetShares(_hospitalRecord);
				MetagameMap.Metagame.IssueSharesForLevel(_levelConfig);
				MetagameMap.Close(_levelConfig, ignoreSave: true, _saveOldLevel);
			}
			else if (MetagameMap.Level == null || MetagameMap.Level.Config != _levelConfig)
			{
				if (!_hospitalRecord.HasPlayed())
				{
					if (_levelConfig.IssueSharesOnStart)
					{
						Metagame.IssueSharesForLevel(_levelConfig);
					}
					_hospitalRecord.SetHasPlayed();
				}
				MetagameMap.Close(_levelConfig, ignoreSave: false, _saveOldLevel);
			}
			else
			{
				MetagameMap.Close();
			}
		}

		public override void Exit()
		{
			base.Exit();
			MetagameMap.App.CollaborativePortfolio.OnActiveObjectiveUpdated(force: true);
		}

		public override void OnReturnToMetagameMap()
		{
			if (base.Owner.TopState == this)
			{
				MetagameStateData stateMachineData = base.Owner.GetStateMachineData<MetagameStateData>();
				stateMachineData.CheckForCutscenes = true;
				stateMachineData.CheckForPostCutscene = true;
				stateMachineData.CheckForSuperBugMessages = PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.Superbug);
				PopState();
			}
		}
	}
}
