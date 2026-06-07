using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class OutdoorBuildHelper : MonoBehaviour
	{
		private Vector2 currentPosition;

		private ParticleSystemRenderer particleRenderer;

		private List<Vector2> guideMarkers;

		private bool guideMarkersFound;

		public float disableDistance;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private Vector2 GetClosestOutdoorTile()
		{
			return default(Vector2);
		}
	}
}
