using System;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class Spread
	{
		[Label("拡散度合")]
		[Tooltip("大きいほど拡散する.0以下で無効")]
		public float spread;

		public Vector3 SpreadVector => default(Vector3);

		public Vector2 SpreadCorrection(Vector2 target)
		{
			return default(Vector2);
		}
	}
}
