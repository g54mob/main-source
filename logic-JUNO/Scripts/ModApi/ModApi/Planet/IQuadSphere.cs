using System;
using ModApi.Planet.Events;
using UnityEngine;

namespace ModApi.Planet
{
	public interface IQuadSphere
	{
		Transform Camera { get; }

		double ClosestWaterQuadToCameraSqr { get; }

		Transform DirectionalLight { get; }

		double EstimatedMinimumQuadSize { get; }

		double MaxSubDivisionDist { get; }

		int MaxSubdivisionLevel { get; }

		int MinSubdivisionLevel { get; }

		IPhysicsQuadManager PhysicsManager { get; }

		IPlanetData PlanetData { get; }

		Vector3d PlanetPosition { get; }

		ITerrainGenerator TerrainGenerator { get; }

		double TerrainMaxHeight { get; }

		double TerrainMinHeight { get; }

		Transform Transform { get; }

		bool Unloaded { get; }

		event EventHandler<QuadSphereFrameStateRecalculatedEventArgs> FrameStateRecalculated;

		event MaxSubDivisionDistChangedHandler MaxSubDivisionDistChanged;

		void RefreshAllQuads();

		void RefreshQuads(Vector3d spherePosition, double size);
	}
}
