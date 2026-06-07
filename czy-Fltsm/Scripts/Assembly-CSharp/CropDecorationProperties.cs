using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Buildable/Decorations/Crop Decoration Properties")]
public class CropDecorationProperties : DecorationProperties
{
	[Header("Crops")]
	[SerializeField]
	private float _waterRequirement;

	[SerializeField]
	private float _waterConsumption;

	[SerializeField]
	private CountedItemProperty _yield;

	public override Decoration DecorationPrefab => GameManager.Settings.BuildableSettings.CropDecorationPrefab;

	public float WaterRequirement => _waterRequirement;

	public float WaterConsumption => _waterConsumption;

	public CountedItemProperty Yield => _yield;
}
