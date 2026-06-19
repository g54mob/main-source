using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class EnvironmentRatingCalculator : MustCallDestroy
	{
		private readonly Level _level;

		private readonly WorldState _worldState;

		private readonly HospitalAttributeMap _attributeMap;

		private readonly Coroutine _coroutine;

		private List<Room> _roomsToProcess = new List<Room>();

		private List<Room> _roomsProcessing = new List<Room>();

		public int Rating { get; private set; }

		public EnvironmentRatingCalculator(Level level, WorldState worldState, HospitalAttributeMap.Attribute attribute)
		{
			Rating = 0;
			_level = level;
			_worldState = worldState;
			_attributeMap = worldState.HospitalAttributeMaps[(int)attribute];
			_coroutine = _level.App.StartCoroutine(Calculate());
			Recalc();
		}

		public override void Destroy()
		{
			_roomsToProcess.Clear();
			_roomsProcessing.Clear();
			_level.App.StopCoroutine(_coroutine);
			base.Destroy();
		}

		public void Recalc()
		{
			_roomsToProcess.Clear();
			foreach (Room allRoom in _worldState.AllRooms)
			{
				if (!allRoom.Definition.IsHospitalUnbuilt && !allRoom.Definition.IsNoDataRoom && allRoom.IsInBoughtPlot())
				{
					_roomsToProcess.Add(allRoom);
				}
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			float num = 0f;
			int num2 = 0;
			foreach (Room allRoom in _worldState.AllRooms)
			{
				if (!allRoom.Definition.IsHospitalUnbuilt && !allRoom.Definition.IsNoDataRoom && allRoom.IsInBoughtPlot())
				{
					num += _attributeMap.CalculateTotalValue(allRoom.FloorPlan, -1f, 1f);
					num2 += allRoom.FloorPlan.TileCount;
				}
			}
			Rating = (int)(num / (float)num2 * 100f);
		}

		private IEnumerator Calculate()
		{
			while (true)
			{
				if (_roomsToProcess.Count != 0)
				{
					foreach (Room item in _roomsToProcess)
					{
						_roomsProcessing.Add(item);
					}
					_roomsToProcess.Clear();
					float total = 0f;
					int tileCount = 0;
					foreach (Room item2 in _roomsProcessing)
					{
						total += _attributeMap.CalculateTotalValue(item2.FloorPlan, -1f, 1f);
						tileCount += item2.FloorPlan.TileCount;
						yield return null;
					}
					_roomsProcessing.Clear();
					Rating = (int)(total / (float)tileCount * 100f);
				}
				yield return null;
			}
		}
	}
}
