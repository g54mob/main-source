using System;
using DV.ThingTypes;
using UnityEngine;

public interface ICargoLeak
{
	bool HasGasBuildup { get; }

	event Action Ruptured;

	CargoType GetCargoType();

	float LeakDelta();

	float LeakFlow();

	float VaporRadius();

	float CargoVolumeLeaked();

	float CargoMassLeaked();

	float RuptureArea();

	void ReduceLeakedMass(float amount);

	bool IsLeaking();

	bool HasLeakedCargo();

	Vector3 Position();

	void OnCargoExploded();

	void SetupForContent(ICargoContent cargoContent);
}
