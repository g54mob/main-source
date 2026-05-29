using System;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT
{
	[Obsolete]
	public class InfluenceManager : MonoSingleton<InfluenceManager>
	{
		[SerializeField]
		private int _originalAxesLength = 10;

		[SerializeField]
		private float _axesLength = 2f;

		[SerializeField]
		private bool _debug;

		private bool _started;

		public int GlobalDirtLevel { get; private set; }

		public static event Action InfluenceChanged;

		protected override void SingletonAwake()
		{
		}

		private void Start()
		{
			UpdateTotalInfluence();
			_started = true;
			OnEnable();
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void OnEnable()
		{
			if (_started)
			{
				BarFurnitures.OnFurnitureAdded += AddFurnitureAppeal;
				BarFurnitures.OnFurnitureRemoved += RemoveFurnitureAppeal;
				RoomAppeal.OnDirtLevelChanged += OnDirtLevelChanged;
				OnDirtLevelChanged();
			}
		}

		private void OnDisable()
		{
			BarFurnitures.OnFurnitureAdded -= AddFurnitureAppeal;
			BarFurnitures.OnFurnitureRemoved -= RemoveFurnitureAppeal;
			RoomAppeal.OnDirtLevelChanged -= OnDirtLevelChanged;
		}

		private void OnDirtLevelChanged()
		{
			GlobalDirtLevel = 0;
			foreach (Room item in MonoSingleton<FloorsManager>.Instance.Rooms())
			{
				if ((bool)item.Appeal)
				{
					GlobalDirtLevel += item.Appeal.DirtLevel;
				}
			}
		}

		private void AddFurnitureAppeal(Furniture furniture)
		{
		}

		private void RemoveFurnitureAppeal(Furniture furniture)
		{
		}

		private void UpdateTotalInfluence()
		{
			int num = 0;
			Floor[] floors = MonoSingleton<FloorsManager>.Instance.Floors;
			for (int i = 0; i < floors.Length; i++)
			{
				Room[] rooms = floors[i].Rooms;
				foreach (Room room in rooms)
				{
					if ((bool)room.Appeal)
					{
						num += room.Appeal.FurnitureCount;
					}
				}
			}
			InfluenceManager.InfluenceChanged?.Invoke();
		}
	}
}
