using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtBeltSimple : SgtBelt
	{
		[SgtSeed]
		public int Seed;

		public float Thickness;

		public float ThicknessBias;

		public float InnerRadius;

		public float InnerSpeed;

		public float OuterRadius;

		public float OuterSpeed;

		public float RadiusBias;

		public float SpeedSpread;

		public int AsteroidCount;

		[SerializeField]
		private Gradient asteroidColors;

		public float AsteroidSpin;

		public float AsteroidRadiusMin;

		public float AsteroidRadiusMax;

		public float AsteroidRadiusBias;

		public Gradient AsteroidColors => null;

		public void SetSeed(int value)
		{
		}

		public void SetThickness(float value)
		{
		}

		public void SetThicknessBias(float value)
		{
		}

		public void SetInnerRadius(float value)
		{
		}

		public void SetInnerSpeed(float value)
		{
		}

		public void SetOuterRadius(float value)
		{
		}

		public void SetOuterSpeed(float value)
		{
		}

		public void SetRadiusBias(float value)
		{
		}

		public void SetSpeedSpread(float value)
		{
		}

		public void SetAsteroidCount(int value)
		{
		}

		public void SetAsteroidSpin(float value)
		{
		}

		public void SetAsteroidRadiusMin(float value)
		{
		}

		public void SetAsteroidRadiusMax(float value)
		{
		}

		public void SetAsteroidRadiusBias(float value)
		{
		}

		public static SgtBeltSimple Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtBeltSimple Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
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
