using System.Collections.Generic;
using UnityEngine;

public class EconomySimulator
{
	private static List<VirtualBuilding> virtualBuildingsRef = new List<VirtualBuilding>();

	public static List<VirtualBuilding> VirtualBuildings => virtualBuildingsRef;

	public static void SimulateEconomy(out List<int> _OUTgoldSpentOnEconomyBeforeNight, out List<int> _OUTgoldSpentOnDefenseBeforeNight, out List<int> _OUTNetworthBeforeNight, out List<int> _OUTgoldEarnedInNight, out List<int> _OUTgoldDroppedInNight, out List<string> _OUTBuildorder, out List<int> _OUTDefensePower, List<VirtualBuilding> _virtualBuildings, int _startingGold, float _goldDropRate, int _minGoldDrops, int _maxGoldDrops, int _maxWaveCount)
	{
		virtualBuildingsRef = _virtualBuildings;
		foreach (VirtualBuilding _virtualBuilding in _virtualBuildings)
		{
			_virtualBuilding.Reset();
		}
		_OUTgoldSpentOnEconomyBeforeNight = new List<int>();
		_OUTgoldSpentOnDefenseBeforeNight = new List<int>();
		_OUTNetworthBeforeNight = new List<int>();
		_OUTgoldDroppedInNight = new List<int>();
		_OUTgoldEarnedInNight = new List<int>();
		_OUTBuildorder = new List<string>();
		_OUTDefensePower = new List<int>();
		int _virtualGold = _startingGold;
		int num = _startingGold;
		for (int i = 0; i < _maxWaveCount; i++)
		{
			int _budget = Mathf.CeilToInt((float)_virtualGold / 3f);
			int _budget2 = _virtualGold - _budget;
			if (i >= _maxWaveCount - 2)
			{
				_budget = _virtualGold;
				_budget2 = 0;
			}
			string text = "";
			text += SimulateSpending(ref _budget, ref _virtualGold, _virtualBuildings, _spendOnEconomy: false);
			text += SimulateSpending(ref _budget2, ref _virtualGold, _virtualBuildings, _spendOnEconomy: true);
			if (AllBuildingsBuilt(_virtualBuildings))
			{
				SimulateEconomy(out _OUTgoldSpentOnEconomyBeforeNight, out _OUTgoldSpentOnDefenseBeforeNight, out _OUTNetworthBeforeNight, out _OUTgoldEarnedInNight, out _OUTgoldDroppedInNight, out _OUTBuildorder, out _OUTDefensePower, _virtualBuildings, _startingGold, _goldDropRate, _minGoldDrops, _maxGoldDrops, i - 1);
				break;
			}
			int num2 = 0;
			foreach (VirtualBuilding _virtualBuilding2 in _virtualBuildings)
			{
				if (_virtualBuilding2.built)
				{
					num2 += _virtualBuilding2.income;
				}
			}
			foreach (VirtualBuilding _virtualBuilding3 in _virtualBuildings)
			{
				if (_virtualBuilding3.built && _virtualBuilding3.callAfterIncome != null)
				{
					_virtualBuilding3.callAfterIncome.Invoke();
				}
			}
			int num3 = Mathf.Clamp(Mathf.CeilToInt((float)num * _goldDropRate), _minGoldDrops, _maxGoldDrops);
			if (i >= _maxWaveCount - 1)
			{
				num3 = 0;
			}
			_virtualGold += num2 + num3;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			foreach (VirtualBuilding _virtualBuilding4 in _virtualBuildings)
			{
				if (_virtualBuilding4.built)
				{
					if (_virtualBuilding4.economicBuilding)
					{
						num4 += _virtualBuilding4.cost;
					}
					else
					{
						num5 += _virtualBuilding4.cost;
					}
					num6 += _virtualBuilding4.defensePower;
				}
			}
			_OUTgoldDroppedInNight.Add(num3);
			_OUTNetworthBeforeNight.Add(num);
			_OUTgoldSpentOnEconomyBeforeNight.Add(num4);
			_OUTgoldSpentOnDefenseBeforeNight.Add(num5);
			_OUTgoldEarnedInNight.Add(num2);
			_OUTBuildorder.Add(text);
			_OUTDefensePower.Add(num6);
			num += num2 + num3;
		}
	}

	private static VirtualBuilding FindBestBuilding(int budget, List<VirtualBuilding> buildings, bool spendOnEconomy)
	{
		float num = 0f;
		VirtualBuilding result = null;
		foreach (VirtualBuilding building in buildings)
		{
			if (building.economicBuilding == spendOnEconomy && building.IsBuildable(budget, buildings) && !building.built && building.priority > num)
			{
				num = building.priority;
				result = building;
			}
		}
		return result;
	}

	private static string SimulateSpending(ref int _budget, ref int _virtualGold, List<VirtualBuilding> _virtualBuildings, bool _spendOnEconomy)
	{
		string text = "";
		for (int num = 10000; num >= 0; num--)
		{
			VirtualBuilding virtualBuilding = FindBestBuilding(_budget, _virtualBuildings, _spendOnEconomy);
			if (virtualBuilding == null)
			{
				break;
			}
			_budget -= virtualBuilding.cost;
			_virtualGold -= virtualBuilding.cost;
			virtualBuilding.built = true;
			text = text + "(" + virtualBuilding.name + " Level " + virtualBuilding.representingLevel + ") ";
		}
		return text;
	}

	private static bool AllBuildingsBuilt(List<VirtualBuilding> buildings)
	{
		foreach (VirtualBuilding building in buildings)
		{
			if (!building.built)
			{
				return false;
			}
		}
		return true;
	}
}
