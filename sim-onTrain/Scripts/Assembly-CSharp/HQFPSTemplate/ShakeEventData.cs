using UnityEngine;

namespace HQFPSTemplate
{
	public struct ShakeEventData
	{
		public Vector3 Position { get; private set; }

		public float Radius { get; private set; }

		public float Scale { get; private set; }

		public ShakeType ShakeType { get; private set; }

		public ShakeEventData(Vector3 position, float radius, float scale, ShakeType shakeType)
		{
			Position = position;
			Radius = radius;
			Scale = scale;
			ShakeType = shakeType;
		}
	}
}
