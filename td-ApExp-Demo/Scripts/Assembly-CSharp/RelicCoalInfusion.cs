using UnityEngine;

[CreateAssetMenu(fileName = "RelicCoalInfusion", menuName = "Upgrade/Relic/CoalInfusion")]
public class RelicCoalInfusion : EnhancementUpgrade
{
	[SerializeField]
	private float coalFillPercent;

	public override void ApplyUpgrade()
	{
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module && module.CanBeActivated)
			{
				module.GetComponent<Interactable>().OnInteractStart += OnModuleActivation;
			}
		}
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			ModuleSlot[] componentsInChildren = wagon.GetComponentsInChildren<ModuleSlot>();
			foreach (ModuleSlot obj in componentsInChildren)
			{
				obj.coalFillPercent = coalFillPercent;
				obj.coalInfusionOn = true;
			}
		}
		Train.Instance.coalInfusionOn = true;
		Train.Instance.coalFillPercent = coalFillPercent;
	}

	public void OnModuleActivation(Interactor interactor)
	{
		Train.Instance.CoalSeconds += Train.Instance.CoalSecondsCapacity * coalFillPercent / 100f;
	}
}
