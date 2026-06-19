using System;
using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	public class LeaveHospital : MoveTo, IDepartedCallback
	{
		[SerializeField]
		private SharedInstance_TH20TH20_DepartureMethodDefinition _departureMethodDefinition;

		[SerializeField]
		private SharedInstance_TH20TH20_DepartureMethodDefinition[] _departureMethodDefinitions;

		private DepartureMethod _departureMethod;

		public override void OnStart()
		{
			SetupDeparture();
			if (base.Character is Visitor)
			{
				base.Character.LeaveHospital(Character.ReasonForLeavingHospital.Cured);
			}
			base.OnStart();
		}

		private void SetupDeparture()
		{
			DepartureMethodDefinition departureMethod = GetDepartureMethod();
			if (departureMethod != null)
			{
				_departureMethod = base.Character.Level.CharacterManager.DeparturesManager.Add(base.Character, departureMethod, this);
				_arrivalDistance = 0.1f;
				_targetPosition.Value = _departureMethod.Position();
				_targetRotation.Value = _departureMethod.Rotation();
			}
			else
			{
				_targetPosition.Value = base.Character.Level.WorldState.GetRandomHospitalEntrance();
			}
		}

		private DepartureMethodDefinition GetDepartureMethod()
		{
			if (!_departureMethodDefinitions.IsEmpty())
			{
				SharedInstance_TH20TH20_DepartureMethodDefinition[] departureMethodDefinitions = _departureMethodDefinitions;
				foreach (SharedInstance_TH20TH20_DepartureMethodDefinition sharedInstance_TH20TH20_DepartureMethodDefinition in departureMethodDefinitions)
				{
					if (sharedInstance_TH20TH20_DepartureMethodDefinition.NotNull() && sharedInstance_TH20TH20_DepartureMethodDefinition.Instance.IsAvailable())
					{
						return sharedInstance_TH20TH20_DepartureMethodDefinition.Instance;
					}
				}
			}
			if (!_departureMethodDefinition.NotNull() || !_departureMethodDefinition.Instance.IsAvailable())
			{
				return null;
			}
			return _departureMethodDefinition.Instance;
		}

		public override void OnEnd()
		{
			base.OnEnd();
			if (_status == TaskStatus.Success)
			{
				CharacterEvents characterEvents = base.Character.Level.CharacterEvents;
				if (base.Character is Patient)
				{
					characterEvents.OnPatientLeftHospital.InvokeSafe((Patient)base.Character);
				}
				else if (base.Character is Visitor)
				{
					characterEvents.OnVisitorLeftHospital.InvokeSafe((Visitor)base.Character);
				}
				characterEvents.OnCharacterLeftHospital.InvokeSafe(base.Character);
				if (_departureMethod != null)
				{
					_departureMethod.ReadyToDepart();
				}
				else
				{
					OnDeparted();
				}
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			Character character = base.Character;
			character.PostRestoreFromSaveCallback = (System.Action)Delegate.Combine(character.PostRestoreFromSaveCallback, new System.Action(SetupDeparture));
		}

		public void OnDeparted()
		{
			base.Character.Level.CharacterEvents.OnDestroyCharacter.InvokeSafe(base.Character);
		}
	}
}
