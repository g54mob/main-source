#define LOG_LEVEL_VERBOSE
using FullInspector;

namespace TH20
{
	public class MetagameCutsceneHospitalUnlocked : MetagameCutsceneInstance
	{
		private readonly MetagameCutsceneHospitalUnlockedDefinition _definition;

		public MetagameCutsceneHospitalUnlocked(MetagameMap map, MetagameCutsceneHospitalUnlockedDefinition definition)
			: base(map, definition)
		{
			_definition = definition;
		}

		public override void OnCutsceneStart()
		{
			if (_definition.LevelConfigList == null)
			{
				return;
			}
			foreach (SharedInstance<LevelConfig> levelConfig in _definition.LevelConfigList)
			{
				if (!levelConfig.IsNull())
				{
					MapPinHospital pinForLevelUniqueId = MetagameMap.MapUI.GetPinForLevelUniqueId(levelConfig.Instance.UniqueId);
					if (pinForLevelUniqueId == null)
					{
						Logging.Error(LogChannels.Metagame, "RB: Trying to setup hospital building for cutscene animation, but can't find pin for LevelID = {0}", levelConfig.Instance.UniqueId);
					}
					else
					{
						pinForLevelUniqueId.HospitalVisual.SetIsUnlocked(isUnlocked: false);
					}
				}
			}
		}

		public override void OnSkip()
		{
			MetagameMap.CutsceneAudioPlayer.StopAllAudio();
			if (_definition.LevelConfigList != null)
			{
				foreach (SharedInstance<LevelConfig> levelConfig in _definition.LevelConfigList)
				{
					if (!levelConfig.IsNull())
					{
						MapPinHospital pinForLevelUniqueId = MetagameMap.MapUI.GetPinForLevelUniqueId(levelConfig.Instance.UniqueId);
						if (pinForLevelUniqueId == null)
						{
							Logging.Error(LogChannels.Metagame, "RB: Trying to skip hospital building for cutscene animation, but can't find pin for LevelID = {0}", levelConfig.Instance.UniqueId);
						}
						else
						{
							pinForLevelUniqueId.HospitalVisual.SetIsUnlocked(isUnlocked: true);
						}
					}
				}
			}
			base.OnSkip();
		}
	}
}
