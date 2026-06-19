using System;
using System.Collections.Generic;

namespace TH20
{
	public abstract class SubGoalPatientTimePortal : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionPatientTimePortal _definition;

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

		public SubGoalPatientTimePortal(Objective owner, SubGoalDefinitionPatientTimePortal definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionPatientTimePortal;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionPatientTimePortal)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				RegisterEvents();
			}
		}

		private void RegisterEvents()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientSuccess));
			characterEvents.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientDied, new Action<Patient>(OnPatientFailure));
			characterEvents.OnPatientSentHome = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientRageQuit, new Action<Patient>(OnPatientFailure));
		}

		protected override void OnStart()
		{
			RegisterEvents();
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientSuccess));
			characterEvents.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientDied, new Action<Patient>(OnPatientFailure));
			characterEvents.OnPatientSentHome = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientRageQuit, new Action<Patient>(OnPatientFailure));
			base.OnEnd();
		}

		private void OnPatientSuccess(Patient patient, List<Staff> involvedStaff)
		{
			if (patient.GetComponent<PatientTimePortalComponent>() != null && _definition.IsValid(patient.Illness, patient.RoomUsing))
			{
				Record(cured: true);
				UpdateProgress();
			}
		}

		private void OnPatientFailure(Patient patient)
		{
			if (patient.GetComponent<PatientTimePortalComponent>() != null && _definition.IsValid(patient.Illness, patient.RoomUsing))
			{
				Record(cured: false);
				UpdateProgress();
			}
		}

		private void OnPatientSentHome(Patient patient)
		{
			PatientTimePortalComponent component = patient.GetComponent<PatientTimePortalComponent>();
			if (component != null && !component.Cured && _definition.IsValid(patient.Illness, patient.RoomUsing))
			{
				Record(cured: false);
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
