using System;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Staff")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ReadyToStartTraining : Conditional
	{
		[Tooltip("Staff")]
		public SharedStaffRef _staff;

		private bool _ready;

		public override void OnStart()
		{
			base.OnStart();
			_ready = false;
			CharacterEvents characterEvents = _staff.Get.Level.CharacterEvents;
			characterEvents.OnStaffReadyToStartTraining = (Action<Staff, Room>)Delegate.Combine(characterEvents.OnStaffReadyToStartTraining, new Action<Staff, Room>(OnStaffReadyToStartTraining));
		}

		public override void OnEnd()
		{
			CharacterEvents characterEvents = _staff.Get.Level.CharacterEvents;
			characterEvents.OnStaffReadyToStartTraining = (Action<Staff, Room>)Delegate.Remove(characterEvents.OnStaffReadyToStartTraining, new Action<Staff, Room>(OnStaffReadyToStartTraining));
			base.OnEnd();
		}

		private void OnStaffReadyToStartTraining(Staff staff, Room room)
		{
			if (staff == _staff.Get)
			{
				_ready = true;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (!_ready)
			{
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}
	}
}
