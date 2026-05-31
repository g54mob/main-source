using System;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT
{
	[Constructor("Construct")]
	public sealed class CleanableObject : CTSBehaviour, IContextActor, IFilth
	{
		private IContextActor _contextActor;

		private WorkerChore _chore;

		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private ObjectSwapOnPercent _objectSwapper;

		public ContextActorData ContextActorData => _contextActor.ContextActorData;

		[field: SerializeField]
		public AnimKey CleaningAnimation { get; private set; } = AgentAnim.CleanFloor;

		[field: SerializeField]
		public float AnimationDuration { get; private set; } = 3f;

		[field: SerializeField]
		public string ContextActionName { get; private set; } = "Clean";

		[field: SerializeField]
		[field: Inject(false)]
		public RoomObject RoomObject { get; private set; }

		public RoomBuilding CurrentRoom { get; private set; }

		[field: SerializeField]
		public int MaxDirt { get; private set; } = 10;

		public int FilthLevel { get; private set; }

		public static event Action<CleanableObject> FilthLevelChanged;

		public static event Action<CleanableObject> Cleaned;

		public event Action OnObjectCleaned;

		private void Construct()
		{
			FindContextActor();
		}

		private void Start()
		{
			SetFilth(FilthLevel);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			RoomObject.CurrentRoomChanged += OnRoomChanged;
			OnRoomChanged();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			RoomObject.CurrentRoomChanged -= OnRoomChanged;
		}

		private void FindContextActor()
		{
			IContextActor[] components = GetComponents<IContextActor>();
			foreach (IContextActor contextActor in components)
			{
				if (contextActor != this)
				{
					_contextActor = contextActor;
					break;
				}
			}
		}

		public void SetFilth(int newFilthLevel)
		{
			newFilthLevel = Math.Clamp(newFilthLevel, 0, MaxDirt);
			if (FilthLevel != newFilthLevel)
			{
				FilthLevel = newFilthLevel;
				if ((bool)_objectSwapper)
				{
					_objectSwapper.SwapByPercent((float)FilthLevel / (float)MaxDirt);
				}
				UpdateCleanableObject();
				CleanableObject.FilthLevelChanged?.Invoke(this);
			}
		}

		public void AddFilth(int dirtToAdd = 1)
		{
			SetFilth(FilthLevel + dirtToAdd);
		}

		public void Clean()
		{
			SetFilth(0);
			this.OnObjectCleaned?.Invoke();
			CleanableObject.Cleaned?.Invoke(this);
		}

		private void UpdateCleanableObject()
		{
			if (FilthLevel > 0)
			{
				AddChore();
				AddToFilthManager();
			}
			else
			{
				RemoveChore();
				RemoveFromFilthManager();
			}
		}

		private void AddChore()
		{
			if (_chore == null || _chore.Destroyed)
			{
				_chore = new WorkerChoreClean(ChoreCategory.Cleaning, this);
				_chore.AddContext(this);
				MonoSingleton<ChoreList>.Instance.AddToList(_chore);
			}
		}

		private void RemoveChore()
		{
			_chore?.DestroyChore();
			_chore = null;
		}

		private void AddToFilthManager()
		{
			if ((bool)CurrentRoom && CTSSingleton<FilthManager>.InstanceExists())
			{
				CTSSingleton<FilthManager>.Instance.AddFilth(CurrentRoom, this);
			}
		}

		private void RemoveFromFilthManager()
		{
			if ((bool)CurrentRoom && CTSSingleton<FilthManager>.InstanceExists())
			{
				CTSSingleton<FilthManager>.Instance.RemoveFilth(CurrentRoom, this);
			}
		}

		private void OnRoomChanged()
		{
			if (!(CurrentRoom == RoomObject.CurrentRoom))
			{
				RemoveFromFilthManager();
				CurrentRoom = RoomObject.CurrentRoom;
				AddToFilthManager();
			}
		}

		private void OnDestroy()
		{
			RemoveChore();
		}
	}
}
