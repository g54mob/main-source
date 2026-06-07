using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Buildable/Decorations/Energy Pole Decoration Properties")]
public class EnergyPoleDecorationProperties : DecorationProperties
{
	public override Decoration DecorationPrefab => GameManager.Settings.BuildableSettings.EnergyPoleDecorationPrefab;
}
