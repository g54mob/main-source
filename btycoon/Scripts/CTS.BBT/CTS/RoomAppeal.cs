using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[Obsolete]
	public class RoomAppeal : CTSBehaviour
	{
		[SerializeField]
		private bool _useGeneralBarInfluence;

		[SerializeField]
		[Inject(false)]
		private Room _room;

		private readonly HashSet<Component> _dirtObjects = new HashSet<Component>();

		[field: ShowNonSerializedField]
		public int FurnitureCount { get; private set; }

		public int DirtLevel => _dirtObjects.Count;

		public event Action OnAppealChanged;

		public event Action<int> DirtLevelChanged;

		public static event Action OnDirtLevelChanged;

		public void AddFurnitureAppeal(Furniture furniture)
		{
			if (furniture.Parameters.Influence != 0f)
			{
				FurnitureCount++;
				this.OnAppealChanged?.Invoke();
			}
		}

		public void RemoveFurnitureAppeal(Furniture furniture)
		{
			if (furniture.Parameters.Influence != 0f)
			{
				FurnitureCount--;
				this.OnAppealChanged?.Invoke();
			}
		}

		public void AddDirt(Component component)
		{
			int dirtLevel = DirtLevel;
			RemoveDirt(component);
			_dirtObjects.Add(component);
			if (DirtLevel != dirtLevel)
			{
				this.OnAppealChanged?.Invoke();
				this.DirtLevelChanged?.Invoke(DirtLevel);
				RoomAppeal.OnDirtLevelChanged?.Invoke();
			}
		}

		public void RemoveDirt(Component component)
		{
			int dirtLevel = DirtLevel;
			_dirtObjects.Remove(component);
			if (DirtLevel != dirtLevel)
			{
				this.OnAppealChanged?.Invoke();
				this.DirtLevelChanged?.Invoke(DirtLevel);
				RoomAppeal.OnDirtLevelChanged?.Invoke();
			}
		}
	}
}
