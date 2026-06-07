using UnityEngine;

namespace ModApi.Planet
{
	public interface IQuadSphereQuad
	{
		IQuadSphereQuad[] Children { get; }

		bool HasWater { get; }

		bool IsRefreshPending { get; }

		bool IsRefreshRequired { get; }

		bool IsShore { get; }

		bool IsSubdivided { get; }

		bool IsSubdivisionPending { get; }

		IQuadSphereQuad Parent { get; }

		Vector3d PlanetPosition { get; }

		Vector3d QuadPosition { get; }

		Quaterniond QuadRotation { get; }

		double QuadScale { get; }

		IQuadSphere QuadSphere { get; }

		Vector3d SphereNormal { get; }

		int SubdivisionLevel { get; }

		Vector2d UvCenter { get; }

		double UvSize { get; }
	}
}
