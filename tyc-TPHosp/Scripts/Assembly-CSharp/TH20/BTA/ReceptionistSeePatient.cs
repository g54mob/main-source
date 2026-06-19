using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Staff")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class ReceptionistSeePatient : Action
	{
		[SerializeField]
		private SharedStaffRef _receptionist;

		[SerializeField]
		private SharedCharacterRef Character;

		[SerializeField]
		private float XP = 10f;

		private float _startTime;

		public override void OnStart()
		{
			base.OnStart();
			_startTime = GameTime.time;
		}

		public override TaskStatus OnUpdate()
		{
			if (!_receptionist.IsValid())
			{
				return TaskStatus.Failure;
			}
			Staff get = _receptionist.Get;
			if (GameTime.time - _startTime < GameAlgorithms.GetReceptionDuration(get))
			{
				return TaskStatus.Running;
			}
			if (get.ModifiersComponent != null)
			{
				get.ModifiersComponent.ApplyInteractWithOtherModifiers(Character.Get);
			}
			get.Level.CharacterEvents.OnStaffServedCustomer.InvokeSafe(get, Character.Get);
			get.Level.CharacterEvents.OnStaffCheckCharacterIn.InvokeSafe(get, Character.Get);
			if (get.XP != null)
			{
				get.XP.Modify(XP, 1f);
			}
			Room roomUsing = get.RoomUsing;
			if (roomUsing != null && roomUsing.Definition._type == RoomDefinition.Type.Reception)
			{
				roomUsing.OnUnitProcessed();
			}
			return TaskStatus.Success;
		}
	}
}
