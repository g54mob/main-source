using UnityEngine;

public struct CargoComponentData
{
	public GameObject cargoGO;

	public ICargoEffects cargoEffects;

	public ICargoLeak cargoLeak;

	public ICargoReaction cargoReaction;

	public CargoComponentData(GameObject effectsGO, ICargoEffects cargoEffects, ICargoLeak cargoLeak, ICargoReaction cargoReaction)
	{
		cargoGO = effectsGO;
		this.cargoEffects = cargoEffects;
		this.cargoLeak = cargoLeak;
		this.cargoReaction = cargoReaction;
	}
}
