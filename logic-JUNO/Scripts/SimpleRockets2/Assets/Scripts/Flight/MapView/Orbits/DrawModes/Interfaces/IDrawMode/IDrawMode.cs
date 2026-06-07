using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode
{
	public interface IDrawMode
	{
		ModeType Mode { get; }

		bool UpdateReferencePerPoint { get; }

		double? GetLineEndNu(IPlanetNode referenceNode, MapOrbitInfo orbitInfo);

		IPlanetNode GetReferenceNode(MapOrbitInfo orbitInfo);

		Vector3d GetReferenceSolarNodePosition(DrawModeReferenceInfo refInfo);

		Vector3d GetReferenceSolarPosition(MapOrbitInfo orbitInfo);

		Vector3d GetSolarPosition(MapOrbitInfo orbitInfo, IOrbitPoint point);

		Vector3d GetSolarPosition(DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, IOrbitPoint point);

		Vector3d GetSolarPositionAtCurrent(MapOrbitInfo orbitInfo);

		Vector3d GetSolarPositionFromNu(MapOrbitInfo orbitInfo, double trueAnomaly);

		void UpdateReferenceNode(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, double pointTime);

		void UpdateReferenceNodeFromNu(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, double pointNu);

		void UpdateReferenceNodeFromPoint(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, IOrbitPoint point);

		void UpdateReferenceNoderPerOrbit(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo);
	}
}
