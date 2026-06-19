using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemReceptionComponent : EntityComponent
	{
		private RoomItem _item;

		private readonly List<Character> _queue = new List<Character>();

		public List<Character> Queue => _queue;

		public RoomItem Item => _item;

		public int QueueLength => _queue.Count;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_item = GetOwner<RoomItem>();
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Combine(characterEvents.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Combine(characterEvents.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
		}

		public override void Destroy()
		{
			while (_queue.Count != 0)
			{
				Character character = _queue[0];
				character.GetComponent<CharacterCheckInComponent>()?.CancelCheckIn();
				_queue.Remove(character);
			}
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Remove(characterEvents.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			base.Destroy();
		}

		private void OnStaffCompletedJob(Staff staff, Job job, bool success)
		{
			if (staff.Definition._type == StaffDefinition.Type.Assistant && job is JobService jobService && jobService.Item == _item && _queue.Count != 0)
			{
				Character character = _queue[0];
				ObjectInteraction interaction = character.Interaction;
				if (interaction != null && interaction.ParentRoomItem == _item)
				{
					interaction.EndInteraction(character);
					interaction.ReserveInteraction(character);
					interaction.StartInteraction(character);
				}
			}
		}

		public bool IsStaffed()
		{
			foreach (ObjectInteraction interaction in _item.Interactions)
			{
				if (interaction.Interactor is Staff || interaction.Reserved is Staff)
				{
					return true;
				}
			}
			return false;
		}

		public void AddToQueue(Character character)
		{
			_queue.AddUnique(character);
		}

		public void RemoveFromQueue(Character character)
		{
			_queue.Remove(character);
		}

		public int GetQueuePosition(Character character)
		{
			return _queue.IndexOf(character);
		}

		public void ChangeQueuePosition(Character character, int queuePos)
		{
			int num = _queue.IndexOf(character);
			_queue.Remove(character);
			_queue.Insert(queuePos, character);
			if ((num == 0 && queuePos == 1) || (num == 1 && queuePos == 0 && _queue.Count > 1))
			{
				Character character2 = _queue[0];
				Character character3 = _queue[1];
				ObjectInteraction interaction = character3.Interaction;
				if (interaction != null && interaction.ParentRoomItem == _item)
				{
					interaction.RequestExit();
					interaction.EndInteraction(character3);
					interaction.ReserveInteraction(character2);
				}
				BehaviorManager.instance.RestartBehavior(character3.BehaviorTree);
			}
		}

		public int PositionToStandInQueue(Character character)
		{
			int num = 0;
			float num2 = MathUtils.Square(GameAlgorithms.Config.MaxQueueDistance);
			for (int i = 0; i < _queue.Count; i++)
			{
				Character character2 = _queue[i];
				if (character2 == character)
				{
					return num;
				}
				if (_item.WorldPosition.SquareDistance2D(character2.Position) < num2)
				{
					num++;
				}
			}
			return -1;
		}
	}
}
