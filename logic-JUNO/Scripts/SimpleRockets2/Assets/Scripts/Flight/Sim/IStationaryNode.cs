using System;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	public interface IStationaryNode
	{
		Guid Id { get; }

		string MapViewIcon { get; }

		Color MapViewIconColor { get; }

		string Name { get; }

		IPlanetNode Parent { get; }

		Vector3d Position { get; }

		Vector3d SolarPosition { get; }

		string StructureTypeName { get; }

		Vector3d SurfacePosition { get; }

		event NodeDelegate Destroyed;
	}
}
