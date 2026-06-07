using UnityEngine;

namespace ModApi.Planet
{
	public interface IPlanetRingsData
	{
		bool HasRings { get; }

		double InnerRadius { get; }

		double OuterRadius { get; }

		Vector3 Rotation { get; }

		string Texture { get; }
	}
}
