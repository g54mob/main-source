using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalResearchProject : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalResearchProjectDefinition _definition;

		private float _progress;

		public SubGoalResearchProject(Objective owner, SubGoalResearchProjectDefinition definition)
			: base(owner, definition)
		{
			_definition = definition;
			CheckProjectProgress();
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalResearchProjectDefinition;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalResearchProjectDefinition)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				ResearchManager researchManager = Level.ResearchManager;
				researchManager.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Combine(researchManager.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
				ResearchManager researchManager2 = Level.ResearchManager;
				researchManager2.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(researchManager2.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
				CheckProjectProgress();
			}
		}

		private void CheckProjectProgress()
		{
			if (_definition.ResearchProject == null)
			{
				return;
			}
			if (_definition.HasBeenAchieved(Level))
			{
				_progress = 1f;
			}
			else
			{
				ResearchProject project = Level.ResearchManager.GetProject(_definition.ResearchProject);
				if (project != null)
				{
					_progress = project.Progress;
				}
			}
			UpdateProgress();
		}

		protected override void OnStart()
		{
			ResearchManager researchManager = Level.ResearchManager;
			researchManager.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Combine(researchManager.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			ResearchManager researchManager2 = Level.ResearchManager;
			researchManager2.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(researchManager2.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			ResearchManager researchManager = Level.ResearchManager;
			researchManager.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Remove(researchManager.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			ResearchManager researchManager2 = Level.ResearchManager;
			researchManager2.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Remove(researchManager2.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			base.OnEnd();
		}

		private void OnResearchPointsAdded(float points, ResearchProject project)
		{
			if (_definition.ResearchProject != null && _definition.ResearchProject == project.Definition && !Completed())
			{
				_progress = project.Progress;
				UpdateProgress();
			}
		}

		private void OnResearchProjectComplete(ResearchProject project)
		{
			if (_definition.ResearchProject == null || (_definition.ResearchProject == project.Definition && !Completed()))
			{
				_progress = 1f;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _progress >= 1f;
		}

		public override float PercentComplete()
		{
			return _progress;
		}

		public override int Score()
		{
			return (int)_progress;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return StringUtils.FormatPercentageValue(_progress);
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
