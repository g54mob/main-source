using System;
using System.Collections.Generic;
using Restory.Data.InteractiveObjects;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class InteractiveObjectRegistry : ITickable
	{
		private readonly Dictionary<InteractiveObject, InteractiveObjectInfo> all = new Dictionary<InteractiveObject, InteractiveObjectInfo>();

		private readonly List<InteractiveObject> toRemove = new List<InteractiveObject>();

		public IReadOnlyDictionary<InteractiveObject, InteractiveObjectInfo> All => all;

		public event Action<InteractiveObject> OnInteractiveObjectRegistered;

		public event Action<InteractiveObject> OnInteractiveObjectUnregistered;

		public void Register(InteractiveObject interactiveObject, InteractiveObjectInfo interactiveObjectInfo)
		{
			all.Add(interactiveObject, interactiveObjectInfo);
			this.OnInteractiveObjectRegistered?.Invoke(interactiveObject);
		}

		public void Unregister(InteractiveObject interactiveObject)
		{
			all.Remove(interactiveObject);
			this.OnInteractiveObjectUnregistered?.Invoke(interactiveObject);
		}

		public void Clear()
		{
			all.Clear();
		}

		public void Tick()
		{
			foreach (KeyValuePair<InteractiveObject, InteractiveObjectInfo> item in all)
			{
				if (item.Key == null)
				{
					Debug.LogError("[InteractiveObjectRegistry] Found null InteractiveObject (" + ((item.Value == null) ? "undefined" : item.Value.ID) + ") in registry. Unregistering it.");
					toRemove.Add(item.Key);
				}
			}
			foreach (InteractiveObject item2 in toRemove)
			{
				all.Remove(item2);
			}
			toRemove.Clear();
		}
	}
}
