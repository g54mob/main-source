using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes.Interfaces
{
	public interface IManeuverNodePositionProvider
	{
		double CameraDistance { get; }

		double ExtensionPercent { get; }

		Vector3 NodeScreenPosition { get; }

		Vector3d NodeWorldPosition { get; }
	}
}
