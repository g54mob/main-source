using System;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[Serializable]
	public class CinematicTarget
	{
		public Transform TargetTransform;

		public float EaseInDuration;

		public float HoldDuration;

		public float Zoom;

		public EaseType EaseType;

		public string SendMessageName;

		public string SendMessageParam;
	}
}
