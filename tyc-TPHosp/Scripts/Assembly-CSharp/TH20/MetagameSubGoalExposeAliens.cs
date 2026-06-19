using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalExposeAliens : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionExposeAliens _definition;

		[SerializeField]
		private int _numExposed;

		public MetagameSubGoalExposeAliens(Objective owner, MetagameSubGoalDefinitionExposeAliens definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnAlienExposed = (Action<Patient>)Delegate.Combine(levelEventsIntermediary.OnAlienExposed, new Action<Patient>(OnAlienExposed));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnAlienExposed = (Action<Patient>)Delegate.Remove(levelEventsIntermediary.OnAlienExposed, new Action<Patient>(OnAlienExposed));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnAlienExposed = (Action<Patient>)Delegate.Combine(levelEventsIntermediary2.OnAlienExposed, new Action<Patient>(OnAlienExposed));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnAlienExposed = (Action<Patient>)Delegate.Remove(levelEventsIntermediary.OnAlienExposed, new Action<Patient>(OnAlienExposed));
			}
			base.Destroy();
		}

		private void OnAlienExposed(Patient patient)
		{
			if (patient.GetComponent<AlienComponent>() != null)
			{
				_numExposed++;
				if (Metagame?.App != null)
				{
					PlatformStatsAndAchievements.SetStatValue(Stat.AliensExposed, _numExposed);
				}
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _numExposed >= _definition.ExposedCount;
		}

		public override float PercentComplete()
		{
			return (float)_numExposed / (float)_definition.ExposedCount;
		}

		public override int Score()
		{
			return _numExposed;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{StringUtils.FormatNumber(_numExposed)} / {StringUtils.FormatNumber(_definition.ExposedCount)}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
