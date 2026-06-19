using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Staff")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class KioskSeePatient : Action
	{
		[SerializeField]
		private SharedStaffRef Assistant;

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
			if (!Assistant.IsValid())
			{
				return TaskStatus.Failure;
			}
			Staff get = Assistant.Get;
			if (GameTime.time - _startTime < GameAlgorithms.GetKioskDuration(get))
			{
				return TaskStatus.Running;
			}
			if (get.ModifiersComponent != null)
			{
				get.ModifiersComponent.ApplyInteractWithOtherModifiers(Character.Get);
			}
			get.Level.CharacterEvents.OnStaffServedCustomer.InvokeSafe(get, Character.Get);
			if (get.XP != null)
			{
				get.XP.Modify(XP, 1f);
			}
			return TaskStatus.Success;
		}
	}
}
