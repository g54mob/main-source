using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "FurnaceCapFromVisits", menuName = "Upgrade/Furnace/CapFromVisits")]
public class UpgradeFurnaceCapFromVisits : EnhancementUpgrade
{
	[SerializeField]
	private StatusEffect furnaceCapSE;

	private ModuleFurnace furnace;

	public override void ApplyUpgrade()
	{
		ModuleFurnace moduleByType = Train.Instance.GetModuleByType<ModuleFurnace>();
		if ((object)moduleByType == null)
		{
			return;
		}
		furnace = moduleByType;
		LevelManager.Instance.DestinationReached += OnLevelComplete;
		foreach (int item in LevelManager.Instance.TotalLevelHistory.Skip(1))
		{
			_ = item;
			OnLevelComplete();
		}
	}

	private void OnLevelComplete()
	{
		furnace.StatsSO.ApplyStatusEffect(furnaceCapSE);
	}
}
