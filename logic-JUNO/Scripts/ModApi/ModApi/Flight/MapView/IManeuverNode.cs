using UnityEngine;

namespace ModApi.Flight.MapView
{
	public interface IManeuverNode
	{
		Vector3d DeltaV { get; }

		float DeltaVAdjustmentSensitivityExpo { get; }

		float DeltaVAdjustmentSensitivityLinear { get; set; }

		double DeltaVMag { get; }

		double DeltaVNormal { get; }

		double DeltaVPrograde { get; }

		double DeltaVRadial { get; }

		bool Locked { get; }

		int ReferenceOrbitPeriod { get; set; }

		bool SupportsVariableReferenceOrbitPeriod { get; }

		void AdjustDeltaV(Vector3 input);

		Vector3d GetDeltaVToCompleteManeuver();

		void SetDeltaV(Vector3d deltaV);
	}
}
