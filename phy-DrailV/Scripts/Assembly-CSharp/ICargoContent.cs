using System;
using DV.ThingTypes;

public interface ICargoContent
{
	event Action AboutToReturnToPool;

	float GetMaxCargo();

	float GetCurrentCargo();

	float GetMinCargo();

	CargoPhase GetCargoPhase();

	CargoType GetCargoType();

	bool IsEmpty();

	void ReduceCargo(float amount, bool overrideMin = false);

	void OnCargoExploded();

	TrainCar Car();
}
