using System;
using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class JunkObject : CTSBehaviour, IContextActor, IPoolable, IFilth, IPoolCallbackReceiver
	{
		[SerializeField]
		private VFXAnimation _discardAnimation;

		private float _choreCooldown;

		public Furniture InsideFurniture;

		[SerializeField]
		private int _filthLevel = 1;

		private static readonly NamedLayerMask OverwritingPhysicsMask = new NamedLayerMask("Water");

		[SerializeField]
		[Inject(false)]
		private RoomObject _roomObject;

		private RoomBuilding _currentRoom;

		private Addressable<PrestigeUIStatsSO> _junkDiscardStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/PukCleaned.asset");

		[field: SerializeField]
		public ContextActorData ContextActorData { get; private set; }

		[field: SerializeField]
		public JunkObjectParameters Parameters { get; private set; }

		public WorkerChoreDiscardJunk CurrentChore { get; private set; }

		[field: Inject(false)]
		public RoomObject RoomData { get; private set; }

		public bool IsDiscarded { get; private set; }

		PoolGuid IPoolable.PoolGuid { get; set; }

		public int FilthLevel => _filthLevel;

		public static event Action<RoomBuilding> JunkObjectAddedToRoom;

		public static event Action<RoomBuilding> JunkObjectRemovedFromRoom;

		public static event Action<JunkObject> OnJunkAdded;

		public static event Action<JunkObject> OnJunkDiscarded;

		public event Action Discarded;

		public void SetAnimationSpeed(float speed)
		{
			if ((bool)_discardAnimation)
			{
				_discardAnimation.AnimationSpeed = speed;
			}
		}

		private void Start()
		{
			if (!Parameters.ShouldCollideWithFurniture)
			{
				BoundsCollider componentInChildren = GetComponentInChildren<BoundsCollider>(includeInactive: true);
				if ((bool)componentInChildren)
				{
					componentInChildren.enabled = false;
				}
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			CurrentChore = new WorkerChoreDiscardJunk(this);
			CurrentChore.AddContext(this);
			_roomObject.CurrentRoomChanged += OnJunkRoomChanged;
			AddRoomDirt();
			IsDiscarded = false;
			StaticObjectSet<JunkObject>.Add(this);
			JunkObject.OnJunkAdded?.Invoke(this);
			MonoSingleton<ChoreList>.Instance.AddToList(CurrentChore);
			if (_choreCooldown > 0f)
			{
				CurrentChore.SetCooldownFromNow(_choreCooldown);
			}
		}

		private void OnJunkRoomChanged()
		{
			if (!(_currentRoom == _roomObject.CurrentRoom))
			{
				if ((bool)_currentRoom)
				{
					ClearRoomDirt();
				}
				_currentRoom = _roomObject.CurrentRoom;
				AddRoomDirt();
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			StaticObjectSet<JunkObject>.Remove(this);
			ClearRoomDirt();
			if (CurrentChore != null && CurrentChore.Status < AgentAction.EStatus.InProgress)
			{
				CurrentChore.DestroyChore();
			}
			_roomObject.CurrentRoomChanged -= OnJunkRoomChanged;
		}

		public void SafeDiscard()
		{
			if (CurrentChore == null || CurrentChore.Status < AgentAction.EStatus.InProgress)
			{
				CurrentChore?.DestroyChore();
				Discard();
			}
		}

		public void ForceDiscard()
		{
			if (!IsDiscarded && CurrentChore != null)
			{
				if (CurrentChore.Status == AgentAction.EStatus.InProgress)
				{
					CurrentChore.ForceCancelAction();
				}
				CurrentChore.DestroyChore();
				Discard();
			}
		}

		public void Discard()
		{
			if (!IsDiscarded)
			{
				IsDiscarded = true;
				StaticObjectSet<JunkObject>.Remove(this);
				if ((bool)_discardAnimation)
				{
					StartCoroutine(DiscardAnimation());
				}
				else
				{
					DoDiscard();
				}
			}
		}

		private void DoDiscard()
		{
			ClearRoomDirt();
			base.gameObject.SetActive(value: false);
			JunkObject.OnJunkDiscarded?.Invoke(this);
			this.Discarded?.Invoke();
			_junkDiscardStat.Value?.AddToCurrentValue(1);
		}

		private IEnumerator DiscardAnimation()
		{
			yield return _discardAnimation.Play();
			DoDiscard();
		}

		private void AddRoomDirt()
		{
			if ((bool)_currentRoom)
			{
				CTSSingleton<FilthManager>.Instance.AddFilth(_currentRoom, this);
			}
		}

		private void ClearRoomDirt()
		{
			if ((bool)_currentRoom && CTSSingleton<FilthManager>.InstanceExists())
			{
				CTSSingleton<FilthManager>.Instance.RemoveFilth(_currentRoom, this);
			}
		}

		public static void Spawn(JunkObjectParameters parameters, Vector3 pos, Quaternion rot, Furniture insideFurniture = null)
		{
			TryOverwriteJunk(pos);
			JunkObject junkObject = Pooler.Pull(parameters.Prefab);
			junkObject.transform.SetPositionAndRotation(pos, rot);
			junkObject.gameObject.SetActive(value: true);
			junkObject.InsideFurniture = insideFurniture;
			junkObject._choreCooldown = 2f;
		}

		public static void TryOverwriteJunk(Vector3 pos)
		{
			Collider[] array = PhysicsAllocation.Get(4);
			int num = Physics.OverlapSphereNonAlloc(pos, 0.25f, array, OverwritingPhysicsMask, QueryTriggerInteraction.Collide);
			if (num <= 0)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				JunkObject component = array[i].transform.parent.GetComponent<JunkObject>();
				if ((bool)component && component.Parameters.CanBeOverwritten)
				{
					component.SafeDiscard();
				}
			}
		}

		void IPoolCallbackReceiver.OnPulled()
		{
		}

		void IPoolCallbackReceiver.OnPushed()
		{
			SetAnimationSpeed(1f);
		}
	}
}
