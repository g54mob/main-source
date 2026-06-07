using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public abstract class EventDrivenPartIntersectionReceiver<T> : PartIntersectionReceiver
	{
		private HashSet<T> _secondarySet;

		public HashSet<T> Intersections { get; private set; }

		public event Action<T> OnIntersectionAdded;

		public event Action<T> OnIntersectionRemoved;

		public EventDrivenPartIntersectionReceiver(DesignerPartIntersectionManager manager)
			: base(manager)
		{
			_secondarySet = new HashSet<T>();
			Intersections = new HashSet<T>();
		}

		public override void OnAfterRecieveHits()
		{
			HashSet<T> intersections = Intersections;
			HashSet<T> secondarySet = _secondarySet;
			_secondarySet = intersections;
			HashSet<T> hashSet = (Intersections = secondarySet);
			_secondarySet.SymmetricExceptWith(Intersections);
			foreach (T item in _secondarySet)
			{
				if (Intersections.Contains(item))
				{
					this.OnIntersectionAdded?.Invoke(item);
				}
				else
				{
					this.OnIntersectionRemoved?.Invoke(item);
				}
			}
		}

		public override void OnBeforeRecieveHits()
		{
			_secondarySet.Clear();
		}

		public override void RecieveHit(Collider hit)
		{
			GetItemsFromHit(hit, _secondarySet);
		}

		public void RemoveAllItems()
		{
			_secondarySet.Clear();
			OnAfterRecieveHits();
		}

		public void SetMultipleItems(List<T> items)
		{
			_secondarySet.Clear();
			foreach (T item in items)
			{
				_secondarySet.Add(item);
			}
			OnAfterRecieveHits();
		}

		protected abstract void GetItemsFromHit(Collider hitCollider, HashSet<T> resultSet);

		protected void SetSingleItem(T item)
		{
			_secondarySet.Clear();
			_secondarySet.Add(item);
			OnAfterRecieveHits();
		}
	}
}
