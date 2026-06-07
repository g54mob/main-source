using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBuilding : MonoBehaviour
{
	public enum BuildingTypeEnum
	{
		None = 0,
		Catapult = 1,
		Helicopter = 2,
		Hole = 3,
		House = 4,
		Temple = 5,
		Research = 6,
		HotAirBaloon = 7,
		Store = 8,
		Training = 9,
		Industry = 10,
		Power = 11,
		Rock = 12,
		Compressor = 13,
		Drone = 14
	}

	public ColumnController ParentColumn;

	protected int Level = 1;

	protected int ExecutionCount;

	protected int TotalGarbageOut;

	protected int Stability;

	public int MoneySpent;

	public int EvilCount;

	public int UniqueNumber;

	public List<Power> AffectedByPower = new List<Power>();

	public bool _isOnTop;

	private bool _bandPeonDrop;

	public int MINIGAME_AMOUNT_MUL = 2;

	public int MINIGAME_STABILITY_MUL = 3;

	public int BLOCKED_CLOUD_MUL = 4;

	public int BLOCKED_STABILITY_MUL = 2;

	public virtual BuildingTypeEnum BuildingType { get; }

	public virtual BaseGlobalInfo GetGlobalInfo()
	{
		return null;
	}

	public void AddEvilCount(int amount)
	{
		if (amount > 0)
		{
			EvilCount += amount;
			if (GetGlobalInfo() != null)
			{
				GetGlobalInfo().TotalEvilCount++;
			}
		}
	}

	public void AddSpentMoney(int newMoney)
	{
		MoneySpent += newMoney;
	}

	public void ResetStability()
	{
		Stability = 0;
	}

	public int GetStability()
	{
		return Stability;
	}

	public virtual float GetStabilityPercentage()
	{
		if (GetGlobalInfo() == null)
		{
			return 1f;
		}
		if (Stability <= 0)
		{
			return 1f;
		}
		if (Stability >= GetGlobalInfo().GetMaxStability())
		{
			return 0f;
		}
		return 1f - (float)Stability / (float)GetGlobalInfo().GetMaxStability();
	}

	public virtual bool IsUnstable()
	{
		if (GetGlobalInfo() == null)
		{
			return false;
		}
		if (Stability >= GetGlobalInfo().GetMaxStability())
		{
			return true;
		}
		return false;
	}

	public virtual bool AddWorker(CharV2 c)
	{
		throw new NotImplementedException();
	}

	public virtual bool CanDumbGarbage(Garbage g, bool ignoreBan)
	{
		throw new NotImplementedException();
	}

	public virtual bool CanEnter(CharV2 c)
	{
		throw new NotImplementedException();
	}

	public virtual bool CanHaveThrowGarbage(Garbage g)
	{
		throw new NotImplementedException();
	}

	public virtual void DirectDestroyBuilding()
	{
		throw new NotImplementedException();
	}

	public virtual void DumpGarbage(Garbage g)
	{
		throw new NotImplementedException();
	}

	public virtual void EnterBuilding(CharV2 c)
	{
		throw new NotImplementedException();
	}

	public virtual void ExitBuilding(CharV2 c)
	{
		throw new NotImplementedException();
	}

	public virtual Vector3 GetEnterLocation()
	{
		throw new NotImplementedException();
	}

	public virtual int GetLevel()
	{
		return Level;
	}

	public virtual bool HasPower()
	{
		return AffectedByPower.Count > 0;
	}

	public void BandPeonDrop(bool mustBand)
	{
		_bandPeonDrop = mustBand;
	}

	public bool IsBanPeonDrop()
	{
		return _bandPeonDrop;
	}

	private float GetPowerValueSum(Power.PowerIncreaseType type)
	{
		float num = 0f;
		foreach (Power item in AffectedByPower)
		{
			num += item.GetPowerAmountValue(type);
		}
		return num;
	}

	public void ChangeIsOnTop(bool newValue)
	{
		if (_isOnTop != newValue)
		{
			_isOnTop = newValue;
			ProcessIsOnTop();
		}
	}

	public virtual void ProcessIsOnTop()
	{
		SpriteRenderer[] componentsInChildren = GetComponentsInChildren<SpriteRenderer>(includeInactive: true);
		foreach (SpriteRenderer spriteRenderer in componentsInChildren)
		{
			if (_isOnTop && spriteRenderer.sortingLayerName == "GameObject")
			{
				spriteRenderer.sortingLayerName = "GameForeground";
			}
			else if (!_isOnTop && spriteRenderer.sortingLayerName == "GameForeground")
			{
				spriteRenderer.sortingLayerName = "GameObject";
			}
		}
	}

	public virtual void PrepareEnter(CharV2 c)
	{
		throw new NotImplementedException();
	}

	public virtual bool RemoveWorker(CharV2 c)
	{
		throw new NotImplementedException();
	}

	public virtual void SetData(Dictionary<string, int> data)
	{
		if (data.ContainsKey("Level"))
		{
			Level = data["Level"];
		}
		if (data.ContainsKey("ExecutionCount"))
		{
			ExecutionCount = data["ExecutionCount"];
		}
		if (data.ContainsKey("TotalGarbageOut"))
		{
			TotalGarbageOut = data["TotalGarbageOut"];
		}
		if (data.ContainsKey("Stability"))
		{
			Stability = data["Stability"];
		}
		if (data.ContainsKey("MoneySpent"))
		{
			MoneySpent = data["MoneySpent"];
		}
		if (data.ContainsKey("EvilCount"))
		{
			EvilCount = data["EvilCount"];
		}
		if (data.ContainsKey("UniqueNumber"))
		{
			EvilCount = data["UniqueNumber"];
		}
		foreach (BaseSavableAttribute instanceAttribute in GetInstanceAttributes())
		{
			if (data.ContainsKey(instanceAttribute.Name))
			{
				instanceAttribute.ForceLevel(data[instanceAttribute.Name]);
			}
		}
	}

	public virtual Dictionary<string, int> GetData()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		dictionary.Add("Level", Level);
		dictionary.Add("ExecutionCount", ExecutionCount);
		dictionary.Add("TotalGarbageOut", TotalGarbageOut);
		dictionary.Add("Stability", Stability);
		dictionary.Add("MoneySpent", MoneySpent);
		dictionary.Add("EvilCount", EvilCount);
		dictionary.Add("UniqueNumber", UniqueNumber);
		foreach (BaseSavableAttribute instanceAttribute in GetInstanceAttributes())
		{
			dictionary.Add(instanceAttribute.Name, instanceAttribute.Level);
		}
		return dictionary;
	}

	public virtual Vector3 ThrowGarbageLocation()
	{
		throw new NotImplementedException();
	}

	public virtual List<BaseSavableAttribute> GetInstanceAttributes()
	{
		return new List<BaseSavableAttribute>();
	}

	public static int GetNewBuildingCost(int columnIndex, bool isFirst, bool isHouse = false)
	{
		if (isHouse && isFirst)
		{
			return GameController.Instance.AddPrestigeCountTax(5);
		}
		return GameController.Instance.AddPrestigeCountTax(15);
	}

	public virtual int GetIncreaseLevelCost()
	{
		int num = ParentColumn.Distance;
		if (num == 1)
		{
			num = 2;
		}
		int num2 = GetNewBuildingCost(num, GameController.Instance.ColumnsController.IsFirst(this), BuildingType == BuildingTypeEnum.House);
		if (GetGlobalInfo().CanLowerCost())
		{
			num2 /= 2;
		}
		if (Power.GlobalInfo.CanBuildingLessCostAttribute.Level > 0)
		{
			int num3 = (int)((float)num2 * ((float)GetGlobalInfo().StabilityLevel * 0.05f));
			if (num3 > num2 / 2)
			{
				Debug.Log("Why is this so big? (" + num3 + ":" + num2 + ")");
				num3 = num2 / 2;
			}
			num2 -= num3;
		}
		int num4 = (int)(MathF.Pow(2.2f, Level) * (float)num2);
		if (CharDisplay.HasHat)
		{
			num4 += (int)((float)num4 * 0.5f);
		}
		return ReduceWithTrainingPeon(num4);
	}

	public void IncreaseLevel()
	{
		if (Level < 10)
		{
			Level++;
		}
	}

	public virtual bool CanIncreaseLevel()
	{
		if (Level == 10)
		{
			return false;
		}
		if (GameController.Instance.Money.Amount >= GetIncreaseLevelCost())
		{
			return true;
		}
		return false;
	}

	public bool TryIncreaseLevel()
	{
		if (!CanIncreaseLevel())
		{
			return false;
		}
		int increaseLevelCost = GetIncreaseLevelCost();
		GameController.Instance.GainMoney(-increaseLevelCost);
		IncreaseLevel();
		AddSpentMoney(increaseLevelCost);
		return true;
	}

	public int UpgradeLevelToBuildingLevel()
	{
		if (Level == 1)
		{
			return 0;
		}
		if (Level == 2)
		{
			return 0;
		}
		if (Level == 3)
		{
			return 1;
		}
		if (Level == 4)
		{
			return 1;
		}
		if (Level == 5)
		{
			return 2;
		}
		if (Level == 6)
		{
			return 2;
		}
		if (Level == 7)
		{
			return 3;
		}
		if (Level == 8)
		{
			return 3;
		}
		_ = Level;
		_ = 9;
		return 4;
	}

	public void EarthquakeReduceStability()
	{
		if (GetGlobalInfo() != null)
		{
			float num = 0.3f;
			num += 0.1f * (float)(Power.GlobalInfo.CanPrestigeRemoveStabilityAttribute.Level - 1);
			Stability += (int)((float)GetGlobalInfo().GetMaxStability() * num);
		}
	}

	public void LowerStability(float percentage)
	{
		if (GetGlobalInfo() != null)
		{
			Stability += (int)((float)GetGlobalInfo().GetMaxStability() * percentage);
		}
	}

	public void DoGolemHit()
	{
		if (GetGlobalInfo() != null)
		{
			Stability += (int)((float)GetGlobalInfo().GetMaxStability() * 0.75f);
		}
	}

	public int AddPowerOutputWeight(int weight)
	{
		weight += (int)((float)weight * GetPowerValueSum(Power.PowerIncreaseType.OutputWeight));
		return weight;
	}

	public int AddPowerOutputAmount(int amount)
	{
		amount += (int)GetPowerValueSum(Power.PowerIncreaseType.OutputAmount);
		return amount;
	}

	public int AddPowerStability(int stabilityLoss)
	{
		stabilityLoss += (int)((float)stabilityLoss * GetPowerValueSum(Power.PowerIncreaseType.StabilityDown));
		if (GetPowerValueSum(Power.PowerIncreaseType.StabilityStop) > 0f)
		{
			stabilityLoss = 0;
		}
		return stabilityLoss;
	}

	public float AddPowerMoreCloud(float cloudChance)
	{
		cloudChance += cloudChance * GetPowerValueSum(Power.PowerIncreaseType.MoreCloud);
		return cloudChance;
	}

	public int AddMoreTP_RP(int amount)
	{
		amount += (int)GetPowerValueSum(Power.PowerIncreaseType.MoreRP_TP);
		return amount;
	}

	public int ReduceWithTrainingPeon(int cost)
	{
		if (Training.GlobalInfo.ReduceCostAttribute.Level > 0)
		{
			float num = 0f;
			if (this is BaseBuildingOnDemand)
			{
				num = (float)((BaseBuildingOnDemand)this).Working.Count * 0.01f * (float)Training.GlobalInfo.ReduceCostAttribute.Level;
			}
			if (this is BaseBuildingWorker)
			{
				num = (float)((BaseBuildingWorker)this).Working.Count * 0.01f * (float)Training.GlobalInfo.ReduceCostAttribute.Level;
			}
			if (num > 0.75f)
			{
				num = 0.75f;
			}
			cost -= (int)((float)cost * num);
		}
		return cost;
	}

	public void IncreaseTotalOutput(int amount)
	{
		TotalGarbageOut += amount;
		GetGlobalInfo().TotalGarbageOut += amount;
	}

	public void IncreaseBlockedOutput(int amount)
	{
		GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_clogged);
		if (GameController.TotalBlockedOutput == 0)
		{
			GameController.Instance.ToastPanel.AddItem(LanguageText.GetText("NewHelpEntry"));
		}
		GameController.TotalBlockedOutput += amount;
	}

	public virtual int YellowShardCountWhenDurabilityDown()
	{
		if (Research.GlobalInfo.CanExtraYellowShardAttribute.IsEnabled)
		{
			return 2;
		}
		return 1;
	}
}
