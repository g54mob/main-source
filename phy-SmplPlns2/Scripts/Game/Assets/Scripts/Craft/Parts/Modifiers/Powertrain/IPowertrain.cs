using NWH.VehiclePhysics2.Powertrain;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public interface IPowertrain
	{
		float EngineIdleRpm { get; }

		float EngineInertia { get; }

		float EngineMaxRpm { get; }

		float EnginePeakTorque { get; }

		float EngineRedlineRpm { get; }

		float EngineRpm { get; }

		float EngineThrottle { get; }

		float InputThrottle { get; }

		NWH.VehiclePhysics2.Powertrain.Powertrain Powertrain { get; }

		JTransmissionScript PrimaryTransmission { get; set; }
	}
}
