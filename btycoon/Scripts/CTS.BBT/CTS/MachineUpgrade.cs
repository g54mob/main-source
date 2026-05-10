using System;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class MachineUpgrade : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("Base Settings")]
		public SerializableDictionary<EMachineUpgrade, int> machinePriceToUpgrade = new SerializableDictionary<EMachineUpgrade, int>();

		[SerializeField]
		[BoxGroup("Base Settings")]
		public SerializableDictionary<EMachineUpgrade, int> machineProcessDuration = new SerializableDictionary<EMachineUpgrade, int>();

		[SerializeField]
		[BoxGroup("Base Settings")]
		public SerializableDictionary<EMachineProductionMode, int> machineEfficiency = new SerializableDictionary<EMachineProductionMode, int>();

		[SerializeField]
		[ShowIf("hasARiskToKill")]
		[BoxGroup("Base Settings")]
		public SerializableDictionary<EMachineUpgrade, float> safeRiskValue = new SerializableDictionary<EMachineUpgrade, float>();

		[SerializeField]
		[ShowIf("hasARiskToKill")]
		[BoxGroup("Base Settings")]
		public SerializableDictionary<EMachineUpgrade, float> normalSafeRiskValue = new SerializableDictionary<EMachineUpgrade, float>();

		[SerializeField]
		[ShowIf("hasARiskToKill")]
		[BoxGroup("Base Settings")]
		public SerializableDictionary<EMachineUpgrade, float> overclockSafeRiskValue = new SerializableDictionary<EMachineUpgrade, float>();

		[SerializeField]
		[BoxGroup("Data")]
		public bool upgradeIsDisabled;

		[SerializeField]
		[BoxGroup("Data")]
		public bool hasARiskToKill;

		[SerializeField]
		[BoxGroup("Data")]
		public EMachineUpgrade currentLevel;

		[SerializeField]
		[BoxGroup("Data")]
		public EMachineDeathMode deathMode;

		private MachineBase _machineBase;

		public int CurrentProcessDuration => machineProcessDuration[currentLevel];

		public int CurrentEfficiency => machineEfficiency[_machineBase.MachineProductionMode];

		public event Action MachineUpgraded;

		private void Awake()
		{
			_machineBase = base.gameObject.GetComponent<MachineBase>();
		}

		private void Start()
		{
			int count = machinePriceToUpgrade.Count;
			if (count == 0 || count == 1)
			{
				upgradeIsDisabled = true;
			}
		}

		public int GetUpgradePrice()
		{
			return machinePriceToUpgrade[currentLevel + 1];
		}

		public void Upgrade()
		{
			EventsManager.ChangeMoney?.Invoke(Currencies.Dollars, -GetUpgradePrice());
			currentLevel++;
			if (Enum.GetValues(typeof(EMachineUpgrade)).Length == (int)(currentLevel + 1))
			{
				upgradeIsDisabled = true;
			}
			this.MachineUpgraded?.Invoke();
		}
	}
}
