using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.BBT
{
	public class StationMorgue : WorkerFurnitureInteractor, IDestructibleFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible, IRoomAssignable, IManageableFurniture
	{
		[SerializeField]
		protected int _maxItemCount = 20;

		[BoxGroup("Drop Settings")]
		public Vector3 droppingPointsCoords;

		[BoxGroup("Drop Settings")]
		public List<Transform> droppingPointsFront = new List<Transform>();

		[BoxGroup("Drop Settings")]
		public List<Transform> droppingPointsBottom = new List<Transform>();

		private bool _isInitialized;

		private static readonly Resource<BodyBag> _bodyBagPrefab = new Resource<BodyBag>("Prefabs/Pfb_BodyBag");

		private readonly List<DeadBodyData> _deadBodies = new List<DeadBodyData>();

		private readonly Dictionary<DeadBodyData, WorkerChoreHub> _chores = new Dictionary<DeadBodyData, WorkerChoreHub>();

		public static readonly Func<StationMorgue, bool> IsNotFullFunc = (StationMorgue morgue) => morgue._deadBodies.Count != morgue._maxItemCount;

		public int MaxCount => _maxItemCount;

		[field: SerializeField]
		public UsableFurnituresCategoriesSO UsableFurnitureCategoryData { get; private set; }

		[field: SerializeField]
		[field: Inject(false)]
		public RoomAssignations RoomAssignations { get; private set; }

		public ReadOnlyList<DeadBodyData> DeadBodies => _deadBodies;

		public bool IsFull => _deadBodies.Count == _maxItemCount;

		public int DeadBodyCount => _deadBodies.Count;

		public int MaxBodies { get; private set; }

		public event Action MaxBodiesChanged;

		protected override void OnAwake()
		{
			base.OnAwake();
			MaxBodies = _maxItemCount;
		}

		private void Start()
		{
			foreach (DeadBodyData deadBody in _deadBodies)
			{
				CreateDisposeChore(deadBody);
			}
		}

		public void SetMaxBodies(int maxBodies)
		{
			if (maxBodies != MaxBodies)
			{
				MaxBodies = maxBodies;
				this.MaxBodiesChanged?.Invoke();
			}
		}

		public override void OnFurniturePlaced()
		{
			base.OnFurniturePlaced();
			if (!(droppingPointsCoords == base.transform.position))
			{
				droppingPointsCoords = base.transform.position;
			}
		}

		protected override void OnFurniturePickedUp()
		{
			base.OnFurniturePickedUp();
			droppingPointsCoords = base.transform.position;
		}

		public override void OnFurnitureSold()
		{
			base.OnFurnitureSold();
			TryDropAllBodyBags();
		}

		public override void OnFurnitureDestroyed()
		{
			base.OnFurnitureDestroyed();
			TryDropAllBodyBags();
		}

		private void TryDropAllBodyBags()
		{
			if (droppingPointsCoords == Vector3.zero)
			{
				droppingPointsCoords = base.transform.position;
			}
			droppingPointsBottom[0].parent.position = droppingPointsCoords;
			if (base.gameObject.scene.isLoaded)
			{
				DropAllBodyBags();
			}
		}

		public void AddBodyBag(DeadBodyData customerData)
		{
			_deadBodies.Add(customerData);
			CreateDisposeChore(customerData);
		}

		public bool RemoveBodyBag(DeadBodyData data, out BodyBag bag)
		{
			if (!_deadBodies.Remove(data))
			{
				bag = null;
				return false;
			}
			bag = Pooler.Pull(_bodyBagPrefab.Value, active: true);
			if (_chores.Remove(data, out var value))
			{
				bag.SetChore(value);
			}
			bag.SetBodyData(data);
			return true;
		}

		public void CreateDisposeChore(DeadBodyData data)
		{
			if (_deadBodies.Contains(data))
			{
				RemoveAndDestroyChore(data);
				WorkerChoreHubDiscardBody workerChoreHubDiscardBody = new WorkerChoreHubDiscardBody(new ActionHubDisposeBody(this, data));
				_chores[data] = workerChoreHubDiscardBody;
				MonoSingleton<ChoreList>.Instance.AddToList(workerChoreHubDiscardBody);
			}
		}

		public void RemoveAndDestroyChore(DeadBodyData data)
		{
			if (_chores.Remove(data, out var value))
			{
				value.DestroyChore();
			}
		}

		public void DropBodyBag()
		{
			List<DeadBodyData> deadBodies = _deadBodies;
			if (RemoveBodyBag(deadBodies[deadBodies.Count - 1], out var bag))
			{
				bag.transform.SetPositionAndRotation(droppingPointsFront[0].position, Quaternion.Euler(0f, UnityEngine.Random.value * 360f, 0f));
				bag.CreateBodyBagCleaningChore(allowMorgue: false);
			}
		}

		public void DropAllBodyBags(EBodyDropLocation bodyDropLocation = EBodyDropLocation.Bottom)
		{
			for (int num = _deadBodies.Count - 1; num >= 0; num--)
			{
				BodyBag bodyBag = Pooler.Pull(_bodyBagPrefab.Value, active: true);
				bodyBag.transform.SetPositionAndRotation((bodyDropLocation == EBodyDropLocation.Bottom) ? droppingPointsBottom[num].position : droppingPointsFront[num].position, Quaternion.Euler(0f, UnityEngine.Random.value * 360f, 0f));
				bodyBag.SetBodyData(_deadBodies[num]);
				RemoveAndDestroyChore(bodyBag.BodyData);
				bool allowMorgue = bodyDropLocation != EBodyDropLocation.Front;
				bodyBag.CreateBodyBagCleaningChore(allowMorgue);
				_deadBodies.RemoveAt(num);
			}
		}
	}
}
