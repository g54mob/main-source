using System;
using UnityEngine;

namespace Assets.Scripts.Terrain.Rendering.Events
{
	public class PlanetCubemapsChangedEventArgs : EventArgs
	{
		public Cubemap Colors { get; private set; }

		public Cubemap NormalMap { get; private set; }

		public PlanetCubemapsChangedEventArgs(Cubemap colors, Cubemap normalMap)
		{
			Colors = colors;
			NormalMap = normalMap;
		}
	}
}
