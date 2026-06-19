using System;

namespace TH20
{
	public abstract class SubGoalAnachronisticTimeTunnel : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionAnachronisticTimeTunnel _definition;

		private int _count;

		private int _numCured;

		protected virtual void Record(bool cured)
		{
			_count++;
			if (cured)
			{
				_numCured++;
			}
		}

		protected int Count()
		{
			return _count;
		}

		protected int NumCured()
		{
			return _numCured;
		}

		public SubGoalAnachronisticTimeTunnel(Objective owner, SubGoalDefinitionAnachronisticTimeTunnel definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionAnachronisticTimeTunnel;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionAnachronisticTimeTunnel)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				RegisterEvents();
			}
		}

		private void RegisterEvents()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientTimeTunnel = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
		}

		protected override void OnStart()
		{
			RegisterEvents();
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientTimeTunnel = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
			base.OnEnd();
		}

		private void OnPatientTimeTunnel(Patient patient)
		{
			AnachronisticTreatmentComponent component = patient.GetComponent<AnachronisticTreatmentComponent>();
			if (component != null && _definition.IsValid(patient.Illness, patient.RoomUsing))
			{
				Record(component.Cured);
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return Score() >= _definition.Target;
		}

		public override float PercentComplete()
		{
			return (float)Score() / (float)_definition.Target;
		}

		public int Target()
		{
			return _definition.Target;
		}
	}
}
