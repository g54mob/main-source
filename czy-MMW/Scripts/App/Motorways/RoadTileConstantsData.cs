using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Motorways
{
	public class RoadTileConstantsData : ScriptableObject
	{
		[Serializable]
		public class RoadTileConfiguration
		{
			public int definitionIndex;

			public Vector2 interactionCircleOffset;

			public Vector2[] trafficLightOffsets;
		}

		public float trafficLightRadiusOffset = 0.75f;

		[NonReorderable]
		public List<RoadTileConfiguration> roadTileConfigurations = new List<RoadTileConfiguration>();

		public int RoadTileConfigurationCount => roadTileConfigurations.Count;

		public RoadTileConfiguration FindOrCreateRoadTileConfiguration(int definitionIndex)
		{
			RoadTileConfiguration roadTileConfiguration = roadTileConfigurations.FirstOrDefault((RoadTileConfiguration possibleConfig) => possibleConfig.definitionIndex == definitionIndex);
			if (roadTileConfiguration == null)
			{
				roadTileConfiguration = new RoadTileConfiguration
				{
					definitionIndex = definitionIndex
				};
				roadTileConfigurations.Add(roadTileConfiguration);
			}
			return roadTileConfiguration;
		}
	}
}
