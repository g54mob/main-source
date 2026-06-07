using System;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[Serializable]
	public class Room
	{
		public string ID;

		public Rect Dimensions;

		[Range(0f, 10f)]
		public float TransitionDuration;

		public EaseType TransitionEaseType;

		public bool ScaleCameraToFit;

		public bool Zoom;

		[Range(0.1f, 10f)]
		public float ZoomScale;

		public int InternalID;

		public Room(Room otherRoom)
		{
		}

		public Room()
		{
		}
	}
}
