using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelHelper
{
	private List<BuildingLevelInfo> _buildingInfos;

	private BaseBuilding _building;

	private int _currentLevel = -1;

	private bool _isInit;

	private List<Vector3> _originalPosition = new List<Vector3>();

	private List<Tween> _shakingTween = new List<Tween>();

	public void Init(List<BuildingLevelInfo> infos, BaseBuilding building)
	{
		_buildingInfos = infos;
		_building = building;
		foreach (BuildingLevelInfo buildingInfo in _buildingInfos)
		{
			buildingInfo.gameObject.SetActive(value: false);
			_originalPosition.Add(buildingInfo.transform.position);
			_shakingTween.Add(null);
		}
		_isInit = true;
	}

	public void SetFloorVisibility()
	{
		if (!_isInit || _currentLevel == _building.UpgradeLevelToBuildingLevel())
		{
			return;
		}
		_currentLevel = _building.UpgradeLevelToBuildingLevel();
		for (int i = 0; i < 5; i++)
		{
			if (i <= _currentLevel)
			{
				_buildingInfos[i].gameObject.SetActive(value: true);
			}
			else
			{
				_buildingInfos[i].gameObject.SetActive(value: false);
			}
		}
		_buildingInfos[_currentLevel].GenerateLevelDust();
	}

	public void SetIsThrowing(bool isThrowing)
	{
		if (!_isInit)
		{
			return;
		}
		foreach (BuildingLevelInfo buildingInfo in _buildingInfos)
		{
			buildingInfo.SetIsThrowing(isThrowing);
		}
	}

	public void SetCanClose(bool canClose)
	{
		if (!_isInit)
		{
			return;
		}
		foreach (BuildingLevelInfo buildingInfo in _buildingInfos)
		{
			buildingInfo.SetCanClose(canClose);
		}
	}

	public int OutputGarbage(int amount, Garbage g, float cloudChance)
	{
		int num = 0;
		foreach (BuildingLevelInfo buildingInfo in _buildingInfos)
		{
			if (!buildingInfo.HasPeon)
			{
				continue;
			}
			for (int i = 0; i < amount; i++)
			{
				Garbage garbage = GameController.Instance.GarbageController.Generate(g.transform.position, g.Info);
				if (buildingInfo.ExecuteOutput(garbage, cloudChance))
				{
					num++;
				}
			}
		}
		if (g.Info.IsEvil)
		{
			_building.AddEvilCount(num);
		}
		GameController.Instance.GarbageController.DestroyGarbage(g);
		return num;
	}

	public int OutputOneLevelGarbage(int amount, Garbage g, float cloudChance)
	{
		int result = OutputOneLevelGarbage(amount, g.Info, cloudChance);
		GameController.Instance.GarbageController.DestroyGarbage(g);
		return result;
	}

	public int OutputOneLevelGarbage(int amount, GarbageInfo g, float cloudChance)
	{
		int num = 0;
		foreach (BuildingLevelInfo buildingInfo in _buildingInfos)
		{
			if (!buildingInfo.HasPeon)
			{
				continue;
			}
			for (int i = 0; i < amount; i++)
			{
				if (buildingInfo.ExecuteOutput(amount, g.Weight, cloudChance, g.GarbageType, g.CameFrom, g.IsEvil))
				{
					num++;
				}
			}
			if (num > 0)
			{
				break;
			}
		}
		if (g.IsEvil)
		{
			_building.AddEvilCount(num);
		}
		return num;
	}

	public int OutputGarbage(int amount, int weight, float cloudChance, GarbageInfo.GarbageTypeEnum garbateType, GarbageInfo.CameFromEnum cameFrom, bool isEvil)
	{
		int num = 0;
		if (Industry.GlobalInfo.CanAllCanGenerateMediumAttribute.IsEnabled && amount >= 4 && garbateType == GarbageInfo.GarbageTypeEnum.GarbageS)
		{
			int num2 = amount % 4;
			int num3 = amount / 4;
			OutputGarbage(num2, weight, cloudChance, GarbageInfo.GarbageTypeEnum.GarbageS, cameFrom, isEvil);
			OutputGarbage(num3, weight * 4, cloudChance, GarbageInfo.GarbageTypeEnum.GarbageM, cameFrom, isEvil);
			return num2 + num3;
		}
		foreach (BuildingLevelInfo buildingInfo in _buildingInfos)
		{
			if (buildingInfo.HasPeon && buildingInfo.ExecuteOutput(amount, weight, cloudChance, garbateType, cameFrom, isEvil))
			{
				num += amount;
			}
		}
		if (isEvil)
		{
			_building.AddEvilCount(num);
		}
		return num;
	}

	public void OutputDust(float cloudChance)
	{
		foreach (BuildingLevelInfo buildingInfo in _buildingInfos)
		{
			if (buildingInfo.HasPeon)
			{
				buildingInfo.ExecuteDust(cloudChance);
			}
		}
	}

	public void ChangeBuildingColor(Color color)
	{
		foreach (BuildingLevelInfo buildingInfo in _buildingInfos)
		{
			buildingInfo.transform.Find("MainImage").GetComponent<SpriteRenderer>().color = color;
		}
	}

	public void ShakeWithDust(bool minigameSuccess, float cloudChance)
	{
		if (minigameSuccess)
		{
			int level;
			for (level = 0; level < _buildingInfos.Count; level++)
			{
				if (_shakingTween[level] == null || !_shakingTween[level].active)
				{
					_buildingInfos[level].transform.Find("MainImage").GetComponent<SpriteRenderer>().color = GameController.EvilColor;
					_shakingTween[level] = _buildingInfos[level].transform.Find("MainImage").transform.DOShakePosition(0.5f, new Vector3(0.2f, 0f, 0f)).OnComplete(delegate
					{
						_buildingInfos[level].transform.Find("MainImage").GetComponent<SpriteRenderer>().color = Color.white;
					});
				}
			}
		}
		else
		{
			for (int num = 0; num < _buildingInfos.Count; num++)
			{
				if (_shakingTween[num] == null || !_shakingTween[num].active)
				{
					_shakingTween[num] = _buildingInfos[num].transform.Find("MainImage").transform.DOShakePosition(0.5f, new Vector3(0.2f, 0f, 0f));
				}
			}
		}
		OutputDust(cloudChance);
	}
}
