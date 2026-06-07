using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.Serialization;

namespace Assets.Nimbatus.Scripts.Missions.Objectives
{
	public class UncoverItemObjective : MissionObjective
	{
		[OdinSerialize]
		protected List<MissionTargetObject> Items = new List<MissionTargetObject>();

		private MissionTargetObject ActiveTarget
		{
			get
			{
				return Items.First((MissionTargetObject t) => t.IsCompatibleWithDifficulty(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.GetActiveMissionComplexity()));
			}
		}

		public MissionTargetObject GetTarget()
		{
			return ActiveTarget;
		}

		public override bool IsFullfilled()
		{
			return ActiveTarget.IsFullfilled();
		}

		public override string GetStatusText()
		{
			string translation = ObjectiveText.GetTranslation();
			if (IsFullfilled())
			{
				return translation;
			}
			return translation + " " + ActiveTarget.Progress + " / " + ActiveTarget.ActualAmount;
		}

		public void UpdateProgress(string collectedObject)
		{
			if (ActiveTarget.WorldObject.UniqueId == collectedObject)
			{
				ActiveTarget.IncreaseProgress(1);
			}
		}

		public override void Init()
		{
			ActiveTarget.Init();
		}

		public override void ResetProgress()
		{
			ActiveTarget.ResetProgress();
		}

		public override void SetFullfilled()
		{
			ActiveTarget.SetFullfilled();
		}
	}
}
