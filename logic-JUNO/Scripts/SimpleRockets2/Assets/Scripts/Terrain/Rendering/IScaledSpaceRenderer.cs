using System;
using Assets.Scripts.Flight.ScaledSpace;
using Assets.Scripts.Terrain.Rendering.Events;
using UnityEngine;

namespace Assets.Scripts.Terrain.Rendering
{
	public interface IScaledSpaceRenderer
	{
		ScaledSpacePlanetScript Planet { get; }

		event EventHandler<PlanetCubemapsChangedEventArgs> CubemapsChanged;

		Material CreateMaterialDuplicate();

		void GetTextures(out Texture cubeTex, out Texture bumpTex);

		void UpdateRenderer(Camera camera, Vector3d scaledSpaceCameraPosition, bool currentPlanet);
	}
}
