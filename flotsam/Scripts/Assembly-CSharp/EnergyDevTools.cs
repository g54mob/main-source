using UnityEngine;
using UnityEngine.UI;

public class EnergyDevTools : MonoBehaviour
{
	[SerializeField]
	private Slider _movementSpeedSlider;

	public static bool FreeMovement { get; private set; }

	public static float MovementSpeed { get; private set; } = 1f;

	public void AddEnergy(float amount)
	{
		ReturnSelectedEnergyGrid().FillStorageEnergy(amount);
	}

	public void RemoveEnergy(float amount)
	{
		ReturnSelectedEnergyGrid().RequestStorageEnergy(amount);
	}

	public void ToggleFreeMovement(bool value)
	{
		FreeMovement = value;
	}

	public void OnMovementSpeedValueChanged(float value)
	{
		MovementSpeed = value;
	}

	public static float ApplyMovementSpeed(float movementSpeed)
	{
		return movementSpeed;
	}

	private EnergyGrid ReturnSelectedEnergyGrid()
	{
		EnergyGridBuildableComponent energyGridBuildableComponent = Selector.ReturnSelectedObjectComponent<EnergyGridBuildableComponent>(ObjectType.Buildable);
		if (energyGridBuildableComponent == null)
		{
			return Community.PlayerCommunity.Engine.Connector.EnergyGrid;
		}
		return energyGridBuildableComponent.EnergyGrid;
	}
}
