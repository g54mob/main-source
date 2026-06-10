using UnityEngine;

namespace NSMedieval
{
	public struct MouseFullClickData
	{
		public const float MaxDistance = 0.05f;

		public int Button { get; set; }

		public Vector3 Position { get; set; }
	}
}
