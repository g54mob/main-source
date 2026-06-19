using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	public class MetagameObjectiveManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public SharedInstance<MetagameObjectiveDefinition>[] Objectives;
		}

		private readonly Dictionary<MetagameObjectiveDefinition, MetagameObjective> _objectives;

		[DontSave]
		private Metagame _metagame;

		public IEnumerable<MetagameObjective> Objectives => _objectives.Values;

		public MetagameObjectiveManager(Config config, Metagame metagame)
		{
			_objectives = new Dictionary<MetagameObjectiveDefinition, MetagameObjective>();
			_metagame = metagame;
			ObjectiveEvents objectiveEvents = _metagame.ObjectiveEvents;
			objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveComplete));
			AddNewObjectives(config, metagame);
		}

		public void RestoreFromSave(Config config, Metagame metagame)
		{
			_metagame = metagame;
			ObjectiveEvents objectiveEvents = _metagame.ObjectiveEvents;
			objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveComplete));
			foreach (MetagameObjective objective in Objectives)
			{
				objective.RestoreFromSave(metagame);
			}
			AddNewObjectives(config, metagame);
		}

		private void AddNewObjectives(Config config, Metagame metagame)
		{
			if (!(metagame.App.GameMode is GameModeCareer))
			{
				return;
			}
			SharedInstance<MetagameObjectiveDefinition>[] objectives = config.Objectives;
			foreach (SharedInstance<MetagameObjectiveDefinition> sharedInstance in objectives)
			{
				if (!_objectives.ContainsKey(sharedInstance.Instance))
				{
					MetagameObjective metagameObjective = new MetagameObjective(metagame, sharedInstance.Instance, isVisible: false, isDiscovered: true, isReplayable: false, startImmediately: true);
					_objectives.Add(sharedInstance.Instance, metagameObjective);
					metagameObjective.Initialise();
				}
			}
		}

		public override void Destroy()
		{
			ObjectiveEvents objectiveEvents = _metagame.ObjectiveEvents;
			objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveComplete));
			foreach (MetagameObjective value in _objectives.Values)
			{
				value.Destroy();
			}
			base.Destroy();
		}

		private void OnObjectiveComplete(Objective objective, Objective.CompletionType completionType)
		{
			if (objective is MetagameObjective { Definition: MetagameObjectiveDefinition definition } && definition.TriggerAchievementOnComplete)
			{
				PlatformStatsAndAchievements.TriggerAchievement(definition.Achievement);
			}
		}

		public void Update(float timeDelta, float unscaledTimeDelta)
		{
			foreach (MetagameObjective value in _objectives.Values)
			{
				value.Update(timeDelta, unscaledTimeDelta);
			}
		}

		public MetagameObjective GetObjectiveFromDefinition(MetagameObjectiveDefinition definition)
		{
			return _objectives[definition];
		}
	}
}
