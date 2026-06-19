using System;
using UnityEngine;

namespace TH20
{
	public class MachineDebris : Entity, IRoomPhysicsEntity
	{
		private MachineDebrisDefinition _definition;

		private Room _room;

		[DontSave]
		private GameObject _gameObject;

		public MachineDebris(MachineDebrisDefinition definition, Level level, Room room)
			: base(definition, level)
		{
			_room = room;
			_definition = definition;
			RegisterEvents();
			CreatePrefabInstance();
		}

		public override void RestoreFromSave()
		{
			RegisterEvents();
			CreatePrefabInstance();
			base.RestoreFromSave();
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
		}

		private void UnregisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
		}

		public override bool AutoDestroy()
		{
			return true;
		}

		public override void Destroy()
		{
			UnregisterEvents();
			GameObjectUtils.SafeDestroy(ref _gameObject);
			base.Destroy();
		}

		private void OnRoomDeleted(Room room)
		{
			if (_room == room)
			{
				Destroy();
			}
		}

		private void CreatePrefabInstance()
		{
			_gameObject = UnityEngine.Object.Instantiate(_definition.Prefab);
		}

		public Transform GetTransform()
		{
			return _gameObject.transform;
		}

		public void DestroyEntity()
		{
			Destroy();
		}
	}
}
