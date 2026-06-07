using System;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.MapDebug
{
	internal class OrbitDebugScript : MonoBehaviour
	{
		private MapViewScript _mapViewScript;

		private Node _node;

		private Func<Orbit> _orbitToDebugFunc;

		public static OrbitDebugScript Create(Node nodeToDebug, Orbit orbitToDebug, MapViewScript mapViewScript, int layer, string debugName)
		{
			return Create(nodeToDebug, () => orbitToDebug, mapViewScript, layer, debugName);
		}

		public static OrbitDebugScript Create(Node nodeToDebug, Func<Orbit> orbitToDebugFunc, MapViewScript mapViewScript, int layer, string debugName)
		{
			Transform obj = new GameObject(debugName).transform;
			obj.gameObject.layer = layer;
			OrbitDebugScript orbitDebugScript = obj.gameObject.AddComponent<OrbitDebugScript>();
			orbitDebugScript.Initialize(nodeToDebug, orbitToDebugFunc, mapViewScript);
			return orbitDebugScript;
		}

		public static void RunTestFromOrbitalElements(double eccentricity, double time, double semiMajorAxis, double periapsisAngle, double trueAnomaly, double inclination, double rightAscentionOfAscendingNode, bool prograde, MapViewScript mapViewScript)
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			double mass = instance.FlightState.RootNode.PlanetData.Mass;
			Orbit orbit = new Orbit(time, eccentricity, semiMajorAxis, periapsisAngle, trueAnomaly, inclination, rightAscentionOfAscendingNode, mass, prograde);
			PlanetDataScript planetDataScript = new GameObject("PlanetData").AddComponent<PlanetDataScript>();
			planetDataScript.Name = "InitialOrbitFromElements";
			planetDataScript.Radius = 500000.0;
			planetDataScript.SurfaceGravity = 9.798;
			planetDataScript.AngularVelocity = -0.0002493327502849042;
			planetDataScript.CalculateMass();
			planetDataScript.OrbitData = null;
			PlanetNode planetNode = new PlanetNode(null, planetDataScript, orbit);
			instance.FlightState.RootNode.AddChildNode(planetNode);
			Create(planetNode, orbit, mapViewScript, mapViewScript.gameObject.layer, planetDataScript.Name);
			Orbit orbit2 = new Orbit(orbit.Position, orbit.Velocity, orbit.Time, mass);
			PlanetDataScript planetDataScript2 = new GameObject("PlanetData2").AddComponent<PlanetDataScript>();
			planetDataScript2.Name = "SecondaryOrbitFromStateVectors";
			planetDataScript2.Radius = planetDataScript.Radius;
			planetDataScript2.SurfaceGravity = planetDataScript.SurfaceGravity;
			planetDataScript2.AngularVelocity = planetDataScript.AngularVelocity;
			planetDataScript2.CalculateMass();
			planetDataScript2.OrbitData = planetDataScript.OrbitData;
			PlanetNode planetNode2 = new PlanetNode(null, planetDataScript2, orbit2);
			instance.FlightState.RootNode.AddChildNode(planetNode2);
			Create(planetNode2, orbit2, mapViewScript, mapViewScript.gameObject.layer, planetDataScript2.Name);
			Orbit orbit3 = new Orbit(orbit2.Time, orbit2.Eccentricity, orbit2.SemiMajorAxis, orbit2.PeriapsisAngle, orbit2.TrueAnomaly, orbit2.Inclination, orbit2.RightAscensionOfAscendingNode, orbit2.PrimaryMass, orbit2.IsPrograde);
			PlanetDataScript planetDataScript3 = new GameObject("PlanetData3").AddComponent<PlanetDataScript>();
			planetDataScript3.Name = "ThirdOrbitFromSecondaryElements";
			planetDataScript3.Radius = planetDataScript.Radius;
			planetDataScript3.SurfaceGravity = planetDataScript.SurfaceGravity;
			planetDataScript3.AngularVelocity = planetDataScript.AngularVelocity;
			planetDataScript3.CalculateMass();
			planetDataScript3.OrbitData = planetDataScript.OrbitData;
			PlanetNode planetNode3 = new PlanetNode(null, planetDataScript3, orbit3);
			instance.FlightState.RootNode.AddChildNode(planetNode3);
			Create(planetNode3, orbit3, mapViewScript, mapViewScript.gameObject.layer, planetDataScript3.Name);
			Debug.Log(string.Format("Primary mass: {18} ({19})\neccentricity {0} - {1}\nsemiMajorAxis {2} - {3}\nperiapsisAngle {4} - {5}\ntrueAnomaly {6} - {7}\ninclination {8} - {9}\nrightAscention {10} - {11}\nprograde {12} - {13}\nposition {14} - {15}\nvelocity {16} - {17}\n", orbit.Eccentricity, orbit2.Eccentricity, orbit.SemiMajorAxis, orbit2.SemiMajorAxis, orbit.PeriapsisAngle, orbit2.PeriapsisAngle, orbit.TrueAnomaly, orbit2.TrueAnomaly, orbit.Inclination, orbit2.Inclination, orbit.RightAscensionOfAscendingNode, orbit2.RightAscensionOfAscendingNode, orbit.IsPrograde, orbit2.IsPrograde, orbit.Position, orbit2.Position, orbit.Velocity, orbit2.Velocity, mass, mass * 6.67384E-11));
			Debug.Log(string.Format("Primary mass: {18} ({19})\neccentricity {0} - {1}\nsemiMajorAxis {2} - {3}\nperiapsisAngle {4} - {5}\ntrueAnomaly {6} - {7}\ninclination {8} - {9}\nrightAscention {10} - {11}\nprograde {12} - {13}\nposition {14} - {15}\nvelocity {16} - {17}\n", orbit2.Eccentricity, orbit3.Eccentricity, orbit2.SemiMajorAxis, orbit3.SemiMajorAxis, orbit2.PeriapsisAngle, orbit3.PeriapsisAngle, orbit2.TrueAnomaly, orbit3.TrueAnomaly, orbit2.Inclination, orbit3.Inclination, orbit2.RightAscensionOfAscendingNode, orbit3.RightAscensionOfAscendingNode, orbit2.IsPrograde, orbit3.IsPrograde, orbit2.Position, orbit3.Position, orbit2.Velocity, orbit3.Velocity, mass, mass * 6.67384E-11));
			if (!Utilities.CompareDoubles(orbit.Eccentricity, orbit2.Eccentricity) || !Utilities.CompareDoubles(orbit.SemiMajorAxis, orbit2.SemiMajorAxis) || !Utilities.CompareDoubles(orbit.PeriapsisAngle, orbit2.PeriapsisAngle) || !Utilities.CompareDoubles(orbit.TrueAnomaly, orbit2.TrueAnomaly) || !Utilities.CompareDoubles(orbit.Inclination, orbit2.Inclination) || !Utilities.CompareDoubles(orbit.RightAscensionOfAscendingNode, orbit2.RightAscensionOfAscendingNode) || orbit.IsPrograde != orbit2.IsPrograde || !Utilities.CompareVector3ds(orbit.Position, orbit2.Position) || !Utilities.CompareVector3ds(orbit.Velocity, orbit2.Velocity))
			{
				Debug.LogError("Failed");
			}
			else
			{
				Debug.Log("Success");
			}
			UnityEngine.Object.Destroy(planetDataScript.gameObject);
			UnityEngine.Object.Destroy(planetDataScript2.gameObject);
			UnityEngine.Object.Destroy(planetDataScript3.gameObject);
		}

		public static void RunTestFromStateVectors(Vector3d position, Vector3d velocity, double time, MapViewScript mapViewScript)
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			double mass = instance.FlightState.RootNode.PlanetData.Mass;
			Orbit orbit = new Orbit(position, velocity, time, mass);
			PlanetDataScript planetDataScript = new GameObject("PlanetData").AddComponent<PlanetDataScript>();
			planetDataScript.Name = "InitialOrbitFromStateVector";
			planetDataScript.Radius = 500000.0;
			planetDataScript.SurfaceGravity = 9.798;
			planetDataScript.AngularVelocity = -0.0002493327502849042;
			planetDataScript.CalculateMass();
			planetDataScript.OrbitData = null;
			PlanetNode planetNode = new PlanetNode(null, planetDataScript, orbit);
			instance.FlightState.RootNode.AddChildNode(planetNode);
			Create(planetNode, orbit, mapViewScript, mapViewScript.gameObject.layer, planetDataScript.Name);
			Orbit orbit2 = new Orbit(orbit.Time, orbit.Eccentricity, orbit.SemiMajorAxis, orbit.PeriapsisAngle, orbit.TrueAnomaly, orbit.Inclination, orbit.RightAscensionOfAscendingNode, mass, orbit.IsPrograde);
			PlanetDataScript planetDataScript2 = new GameObject("PlanetData2").AddComponent<PlanetDataScript>();
			planetDataScript2.Name = "SecondaryOrbitFromStateVectors";
			planetDataScript2.Radius = planetDataScript.Radius;
			planetDataScript2.SurfaceGravity = planetDataScript.SurfaceGravity;
			planetDataScript2.AngularVelocity = planetDataScript.AngularVelocity;
			planetDataScript2.CalculateMass();
			planetDataScript2.OrbitData = planetDataScript.OrbitData;
			PlanetNode planetNode2 = new PlanetNode(null, planetDataScript2, orbit2);
			instance.FlightState.RootNode.AddChildNode(planetNode2);
			Create(planetNode2, orbit2, mapViewScript, mapViewScript.gameObject.layer, planetDataScript2.Name);
			Debug.Log(string.Format("Primary mass: {18} ({19})\neccentricity {0} - {1}\nsemiMajorAxis {2} - {3}\nperiapsisAngle {4} - {5}\ntrueAnomaly {6} - {7}\ninclination {8} - {9}\nrightAscention {10} - {11}\nprograde {12} - {13}\nposition {14} - {15}\nvelocity {16} - {17}\n", orbit.Eccentricity, orbit2.Eccentricity, orbit.SemiMajorAxis, orbit2.SemiMajorAxis, orbit.PeriapsisAngle, orbit2.PeriapsisAngle, orbit.TrueAnomaly, orbit2.TrueAnomaly, orbit.Inclination, orbit2.Inclination, orbit.RightAscensionOfAscendingNode, orbit2.RightAscensionOfAscendingNode, orbit.IsPrograde, orbit2.IsPrograde, orbit.Position, orbit2.Position, orbit.Velocity, orbit2.Velocity, mass, mass * 6.67384E-11));
			if (!Utilities.CompareDoubles(orbit.Eccentricity, orbit2.Eccentricity) || !Utilities.CompareDoubles(orbit.SemiMajorAxis, orbit2.SemiMajorAxis) || !Utilities.CompareDoubles(orbit.PeriapsisAngle, orbit2.PeriapsisAngle) || !Utilities.CompareDoubles(orbit.TrueAnomaly, orbit2.TrueAnomaly) || !Utilities.CompareDoubles(orbit.Inclination, orbit2.Inclination) || !Utilities.CompareDoubles(orbit.RightAscensionOfAscendingNode, orbit2.RightAscensionOfAscendingNode) || orbit.IsPrograde != orbit2.IsPrograde || !Utilities.CompareVector3ds(orbit.Position, orbit2.Position) || !Utilities.CompareVector3ds(orbit.Velocity, orbit2.Velocity))
			{
				Debug.LogError("Failed");
			}
			else
			{
				Debug.Log("Success");
			}
			UnityEngine.Object.Destroy(planetDataScript.gameObject);
			UnityEngine.Object.Destroy(planetDataScript2.gameObject);
		}

		private void Initialize(Node nodeToDebug, Func<Orbit> orbitToDebugFunc, MapViewScript mapViewScript)
		{
			_node = nodeToDebug;
			_orbitToDebugFunc = orbitToDebugFunc;
			_mapViewScript = mapViewScript;
			Func<Vector3> parentPosition = () => (Vector3)_mapViewScript.ConvertSolarToMapView(_node.Parent.SolarPosition);
			Func<Vector3> point2Func = () => (Vector3)_mapViewScript.ConvertSolarToMapView(_node.Parent.SolarPosition + _orbitToDebugFunc().Periapsis);
			Func<string> func = () => "Peri";
			InfoLineScript.Create(parentPosition, point2Func, func, Color.blue, _mapViewScript.MapCamera, base.transform, func());
			point2Func = () => (Vector3)_mapViewScript.ConvertSolarToMapView(_node.Parent.SolarPosition + _orbitToDebugFunc().Apoapsis);
			func = () => "Apo";
			InfoLineScript.Create(parentPosition, point2Func, func, Color.blue, _mapViewScript.MapCamera, base.transform, func());
			point2Func = () => parentPosition() + (Vector3)_mapViewScript.ConvertSolarToMapView(_orbitToDebugFunc().NodeLineVector.normalized * _orbitToDebugFunc().SemiMajorAxis);
			func = () => "NodeLine";
			InfoLineScript.Create(parentPosition, point2Func, func, Color.blue, _mapViewScript.MapCamera, base.transform, func());
			point2Func = () => parentPosition() + (Vector3)_mapViewScript.ConvertSolarToMapView(_orbitToDebugFunc().OrbitalPlaneNormal.normalized * _orbitToDebugFunc().SemiMajorAxis);
			func = () => "Normal";
			InfoLineScript.Create(parentPosition, point2Func, func, Color.blue, _mapViewScript.MapCamera, base.transform, func());
			point2Func = () => parentPosition() + (Vector3)_mapViewScript.ConvertSolarToMapView(_orbitToDebugFunc().OrbitalPlaneRight.normalized * _orbitToDebugFunc().SemiMajorAxis);
			func = () => "Right";
			InfoLineScript.Create(parentPosition, point2Func, func, Color.blue, _mapViewScript.MapCamera, base.transform, func());
			point2Func = () => parentPosition() + (Vector3)_mapViewScript.ConvertSolarToMapView(_orbitToDebugFunc().AngularMomentum.normalized * _orbitToDebugFunc().SemiMajorAxis);
			func = () => "AngularMomentum";
			InfoLineScript.Create(parentPosition, point2Func, func, Color.blue, _mapViewScript.MapCamera, base.transform, func());
			point2Func = () => parentPosition() + (Vector3)_mapViewScript.ConvertSolarToMapView(_orbitToDebugFunc().EccentricityVector.normalized * _orbitToDebugFunc().SemiMajorAxis);
			func = () => "EccVec";
			InfoLineScript.Create(parentPosition, point2Func, func, Color.blue, _mapViewScript.MapCamera, base.transform, func());
			point2Func = () => (Vector3)_mapViewScript.ConvertSolarToMapView(_node.Parent.SolarPosition + _orbitToDebugFunc().Position);
			func = () => "Pos";
			InfoLineScript.Create(parentPosition, point2Func, func, Color.green, _mapViewScript.MapCamera, base.transform, func());
		}
	}
}
