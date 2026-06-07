using DV.ThingTypes;
using UnityEngine;

public interface ICargoReaction
{
	CargoPhase GetCargoPhase();

	float RequestRuptureArea();

	bool IsFlammable();

	bool CanExtinguish();

	bool IsOxidizer();

	bool IsExplosive();

	bool IsIgnited();

	float ReactivityModifier();

	void TryExplodeExternally();

	bool TryIgniteExternally(float ignitionStrength = 1f);

	void TryExtinguishExternally();

	void PlayIgnitionSound(Vector3 pos);

	void SetupForContent(ICargoContent cargoContent);
}
