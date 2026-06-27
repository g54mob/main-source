using System;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Horizon/Horizon Profile", order = 361)]
	public class CozyHorizonProfile : CozyProfile
	{
		public enum LayerType
		{
			Cubemap = 0,
			Ribbon = 1,
			Sprite = 2,
			TextureSheet = 3
		}

		public enum PlacementLocation
		{
			behindClouds = 0,
			inFrontOfClouds = 1
		}

		[Serializable]
		public class HorizonLayerReference
		{
			public LayerType layerType = LayerType.Ribbon;

			public PlacementLocation placementLocation = PlacementLocation.inFrontOfClouds;

			public Texture texture;

			public Color color = Color.white;

			[Range(0f, 1f)]
			public float fogLightAmount = 1f;

			[Range(0f, 1f)]
			public float fogAmount = 1f;

			[Range(-1f, 1f)]
			public float placementHeight;

			[Range(0f, 1f)]
			public float verticalScale = 0.5f;

			public float tiling = 2f;

			[Range(0f, 360f)]
			public float angle;

			public float rows = 1f;

			public float columns = 1f;

			public float framerate = 10f;

			[Range(-90f, 90f)]
			public float pitch;

			[Range(0f, 360f)]
			public float yaw;

			[Range(0f, 360f)]
			public float roll;

			public float size = 1f;

			public int renderPriorityOffset;
		}

		[CozyHorizonLayer]
		public List<HorizonLayerReference> layers;
	}
}
