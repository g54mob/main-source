using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class MonoBeastControlState : MonoBeastState
	{
		private static List<RoomItem> _hidingPlaceCache = new List<RoomItem>();

		private static List<RoomItem> _trapsCache = new List<RoomItem>();

		public MonoBeastControlState(MonoBeast beast)
			: base(beast)
		{
		}

		public override void Enter()
		{
			base.Enter();
			ChooseNextState();
		}

		public override void Resume(State resumingFrom)
		{
			base.Resume(resumingFrom);
			if (resumingFrom is MonoBeastHide)
			{
				PushState(new MonoBeastPanic(_beast));
			}
			else
			{
				ChooseNextState();
			}
		}

		private void ChooseNextState()
		{
			RoomItem roomItem = FindHidingPlace();
			if (roomItem == null)
			{
				PushState(new MonoBeastPanic(_beast));
			}
			else
			{
				PushState(new MonoBeastHide(_beast, roomItem));
			}
		}

		private RoomItem FindHidingPlace()
		{
			Vector3 position = _beast.Position;
			float maxScamperDistance = _beast.Definition.MaxScamperDistance;
			foreach (RoomItem item in _beast.Room.FloorPlan.Items)
			{
				RoomItemMonoBrowHidingPlaceComponent component = item.GetComponent<RoomItemMonoBrowHidingPlaceComponent>();
				if (component != null && Vector3.Distance(position, item.WorldPosition) < maxScamperDistance)
				{
					if (component.ItsATrap)
					{
						_trapsCache.Add(item);
					}
					else
					{
						_hidingPlaceCache.Add(item);
					}
				}
			}
			RoomItem result = ((_trapsCache.Count != 0) ? _trapsCache.RandomItem() : ((_hidingPlaceCache.Count != 0) ? _hidingPlaceCache.RandomItem() : null));
			_trapsCache.Clear();
			_hidingPlaceCache.Clear();
			return result;
		}
	}
}
