using System;
using UnityEngine;

namespace TH20.UI
{
	[Serializable]
	public struct MapLayerParent
	{
		public enum EMapLayer
		{
			SelectedRoadRoutes = 0,
			DeselectedRoadRoutes = 1,
			SelectedAirRoutes = 2,
			DeselectedAirRoutes = 3,
			DynamicPins = 4,
			RoadPins = 5,
			AirPins = 6,
			StaticPins = 7,
			Overlay = 8
		}

		public EMapLayer MapLayer;

		public Transform ParentTransform;
	}
}
