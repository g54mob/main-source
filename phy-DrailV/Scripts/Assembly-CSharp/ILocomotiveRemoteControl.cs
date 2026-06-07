using System;
using DV.Simulation.Cars;
using UnityEngine;

public interface ILocomotiveRemoteControl
{
	bool IsPaired { get; }

	bool IsReadyToPair { get; }

	bool IsActivelyControlled { get; }

	event Action<bool> PairingChanged;

	void PairRemoteController(LocomotiveRemoteController remote);

	void UnpairRemoteController(LocomotiveRemoteController remote);

	string GetReverserSymbol();

	float GetBrakeIndicatorValue();

	float GetTargetThrottle();

	float GetTargetBrake();

	float GetTargetIndependentBrake();

	float GetForwardSpeed();

	bool IsWheelslipping(bool includeMUConnections = false);

	bool IsSandOn();

	Vector3 GetPosition();

	bool IsDerailed();

	int GetNumberOfCarsInFront();

	int GetNumberOfCarsInRear();

	bool IsCouplerInRange(float range);

	void UpdateReverser(ToggleDirection toggle);

	float GetReverserValue();

	void UpdateThrottle(float factor);

	void UpdateBrake(float factor);

	void UpdateIndependentBrake(float factor);

	void UpdateHorn(float value);

	void UpdateSand(ToggleDirection toggle);

	void RemoteControllerCouple();

	void Uncouple(int selectedCoupler);

	string GetLocoGuid();

	MultipleUnitStateObserver.TemperatureState GetEngineTemperatureState(bool includeMUConnections);
}
