using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtBeltCustom : SgtBelt
	{
		public List<SgtBeltAsteroid> Asteroids;

		public static SgtBeltCustom Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtBeltCustom Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}

		protected override int BeginQuads()
		{
			return 0;
		}

		protected override void NextQuad(ref SgtBeltAsteroid asteroid, int asteroidIndex)
		{
		}

		protected override void EndQuads()
		{
		}
	}
}
