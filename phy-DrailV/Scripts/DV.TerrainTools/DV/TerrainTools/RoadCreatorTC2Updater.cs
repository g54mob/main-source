using System;
using UnityEngine;

namespace DV.TerrainTools
{
	[ExecuteInEditMode]
	public class RoadCreatorTC2Updater : MonoBehaviour
	{
		private const float ROAD_EVENT_DEBOUNCE_SECONDS = 0.4f;

		[NonSerialized]
		public RoadCreator roadCreator;

		public Vector2 limitRect = new Vector2(120f, 120f);

		public bool limitRectEnabled;

		[HideInInspector]
		public int version = 1;

		private IDisposable eventsThrottled;
	}
}
