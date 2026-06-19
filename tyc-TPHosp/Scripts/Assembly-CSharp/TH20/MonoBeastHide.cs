using System;
using UnityEngine;

namespace TH20
{
	public class MonoBeastHide : MonoBeastNav
	{
		private readonly RoomItem _hidingPlace;

		private bool _isTrap;

		public MonoBeastHide(MonoBeast beast, RoomItem hidingPlace)
			: base(beast)
		{
			_hidingPlace = hidingPlace;
			_isTrap = hidingPlace.GetComponent<RoomItemMonoBrowHidingPlaceComponent>().ItsATrap;
			BuildEvents buildEvents = _beast.Level.BuildEvents;
			buildEvents.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
		}

		public override void Enter()
		{
			base.Enter();
			Vector3 worldPosition = _hidingPlace.WorldPosition;
			if (_hidingPlace.CachedBounds != null)
			{
				Bounds bounds = _hidingPlace.CachedBounds[0];
				float x = RandomUtils.GlobalRandomInstance.NextFloat(bounds.min.x, bounds.max.x);
				float z = RandomUtils.GlobalRandomInstance.NextFloat(bounds.min.z, bounds.max.z);
				Vector3 vector = new Vector3(x, 0f, z);
				worldPosition += Quaternion.Euler(0f, _hidingPlace.Rotation, 0f) * vector;
			}
			DebugDrawUtils.Marker(worldPosition, Color.green, 10f);
			if (!MoveTo(worldPosition))
			{
				PopState();
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			BuildEvents buildEvents = _beast.Level.BuildEvents;
			buildEvents.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = _beast.Level.BuildEvents;
			buildEvents.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			base.Destroy();
		}

		public override void ReachedDestination()
		{
			base.ReachedDestination();
			_beast.Visible = false;
			_beast.PanicTime = 0f;
			if (_isTrap)
			{
				ParticleSystem componentInChildren = _hidingPlace.Visual.GameObject.GetComponentInChildren<ParticleSystem>();
				if (componentInChildren != null)
				{
					ParticleSystem.MainModule main = componentInChildren.main;
					main.maxParticles++;
				}
				_beast.Level.MonoBeastManager.DestroyBeast(_beast, timedOut: false, triggerEffect: false);
			}
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (roomItem == _hidingPlace)
			{
				_beast.Visible = true;
				PopState();
			}
		}
	}
}
