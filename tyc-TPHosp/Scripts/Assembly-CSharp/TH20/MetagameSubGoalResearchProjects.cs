using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalResearchProjects : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionResearchProjects _definition;

		[SerializeField]
		private int _currentCount;

		public MetagameSubGoalResearchProjects(Objective owner, MetagameSubGoalDefinitionResearchProjects definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(levelEventsIntermediary.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Remove(levelEventsIntermediary.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(levelEventsIntermediary2.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Remove(levelEventsIntermediary.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			}
			base.Destroy();
		}

		private void OnResearchProjectComplete(ResearchProject researchProject)
		{
			_currentCount++;
			UpdateProgress();
			PlatformStatsAndAchievements.SetStatValue(Stat.ProjectsResearched, _currentCount);
		}

		protected override bool HasCompleted()
		{
			return _currentCount >= _definition.Count;
		}

		public override float PercentComplete()
		{
			return (float)_currentCount / (float)_definition.Count;
		}

		public override int Score()
		{
			return _currentCount;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_currentCount} / {_definition.Count}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
