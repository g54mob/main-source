using UnityEngine;

namespace MyStuff.Graphics
{
	public struct AtmosphereState
	{
		public bool fogEnabled;

		public Color fogColor;

		public float fogDensity;

		public float fogStart;

		public float fogEnd;

		public FogMode fogMode;

		public Color ambientSkyColor;

		public Color ambientEquatorColor;

		public Color ambientGroundColor;

		public float ambientIntensity;

		public float dofGaussianStart;

		public float dofGaussianEnd;

		public bool motionBlurWasActive;
	}
}
