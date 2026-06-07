using System;
using System.Collections.Generic;
using ModApi.Flight.Sim.Events;
using ModApi.Planet;
using UnityEngine;

namespace ModApi.Flight.Sim
{
	public interface IPlanetNode : IOrbitNode, INode
	{
		IReadOnlyList<IPlanetNode> ChildPlanets { get; }

		IReadOnlyList<INode> DynamicNodes { get; }

		bool IsTerrainDataLoaded { get; }

		IPlanetData PlanetData { get; }

		Quaterniond Rotation { get; }

		double RotationAngle { get; set; }

		Quaterniond RotationInverse { get; }

		double SphereOfInfluenceExitDistance { get; }

		ITerrainGenerator TerrainGenerator { get; }

		double WaterWaveOffsetTime { get; set; }

		event EventHandler<PlanetNodeTerrainDataEventArgs> TerrainDataLoaded;

		event EventHandler<PlanetNodeTerrainDataEventArgs> TerrainDataLoading;

		event EventHandler<PlanetNodeTerrainDataEventArgs> TerrainDataUnloaded;

		event EventHandler<PlanetNodeTerrainDataEventArgs> TerrainDataUnloading;

		void AddChildNode(INode node);

		Vector3d CalculateGravityVector(Vector3d position, double mass);

		Vector3d CalculateSurfaceVelocity(Vector3d surfacePoint);

		IPlanetNode FindPlanet(string name);

		void GetSurfaceCoordinates(Vector3d surfacePosition, out double latitude, out double longitude);

		Vector3d GetSurfacePosition(double latitude, double longitude, AltitudeType altitudeType, double altitude, float? craftHeight = null);

		double GetTerrainHeight(Vector3d planetPosition);

		PlanetVertexData GetTerrainVertexData(VertexDataRequestType type, Vector3d planetPosition, Vector3d planetNormal, bool isMainThread = true);

		void LoadTerrainData();

		Vector3d PlanetVectorToSurfaceVector(Vector3d planetVector);

		Vector3d PlanetVectorToSurfaceVectorAtTime(Vector3d planetVector, double time);

		void RemoveChildNode(INode node);

		void SetPlanetData(IPlanetData planetData);

		Vector3d SurfaceVectorToPlanetVector(Vector3d surfaceVector);

		void UnloadTerrainData();

		void UpdateRotation(double elapsedTime);
	}
}
