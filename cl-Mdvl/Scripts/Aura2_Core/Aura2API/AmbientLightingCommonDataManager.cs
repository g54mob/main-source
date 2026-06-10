using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Aura2API
{
	public class AmbientLightingCommonDataManager
	{
		private SphericalHarmonicsCoefficients _coefficients;

		public SphericalHarmonicsCoefficients Coefficients => _coefficients;

		public static float GlobalStrength
		{
			get
			{
				if (RenderSettings.ambientMode != AmbientMode.Skybox)
				{
					return 1f;
				}
				return MathF.PI * RenderSettings.ambientIntensity;
			}
		}

		public void Update()
		{
			_coefficients = RenderSettings.ambientProbe.RepackForShaders();
		}
	}
}
