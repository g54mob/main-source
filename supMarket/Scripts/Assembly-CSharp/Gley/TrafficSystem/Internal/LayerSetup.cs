using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	public class LayerSetup : ScriptableObject
	{
		public bool edited;

		public LayerMask roadLayers;

		public LayerMask trafficLayers;

		public LayerMask buildingsLayers;

		public LayerMask obstaclesLayers;

		public LayerMask playerLayers;
	}
}
