using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.Serialization;

namespace Assets.Nimbatus.Scripts.Missions.Objectives
{
	public class FreezeObjective : MissionObjective
	{
		[OdinSerialize]
		protected List<MissionTargetObject> Targets = new List<MissionTargetObject>();

		private List<InteractiveWorldObject> _frozenObjects;

		private MissionTargetObject ActiveTarget
		{
			get
			{
				return Targets.First((MissionTargetObject t) => t.IsCompatibleWithDifficulty(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.GetActiveMissionComplexity()));
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

		public override void Init()
		{
			_frozenObjects = new List<InteractiveWorldObject>();
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

		public void ObjectFrozen(InteractiveWorldObject worldObject)
		{
			if (ActiveTarget.WorldObject.UniqueId == worldObject.UniqueId && !_frozenObjects.Contains(worldObject))
			{
				_frozenObjects.Add(worldObject);
				ActiveTarget.IncreaseProgress(1);
			}
		}

		public void ObjectUnfrozen(InteractiveWorldObject worldObject)
		{
			if (!IsFullfilled() && ActiveTarget.WorldObject.UniqueId == worldObject.UniqueId && _frozenObjects.Contains(worldObject))
			{
				_frozenObjects.Remove(worldObject);
				ActiveTarget.DecreaseProgress(1);
			}
		}
	}
}
