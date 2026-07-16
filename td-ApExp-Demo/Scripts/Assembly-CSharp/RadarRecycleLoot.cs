using UnityEngine;

[CreateAssetMenu(fileName = "3RecycleLoot", menuName = "Radar/3RecycleLoot")]
public class RadarRecycleLoot : EnhancementRadar
{
	public override void OnApplied()
	{
		(MenuManager.Instance.GetMenu(MenuType.Choice) as ChoiceWindow).CanRecycleLoot = true;
	}

	public override void OnRemoved()
	{
		(MenuManager.Instance.GetMenu(MenuType.Choice) as ChoiceWindow).CanRecycleLoot = false;
	}
}
