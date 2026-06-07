using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Light))]
	public class Sun : MonoBehaviour
	{
		private Light _sunLight;

		private float _trilightGradientOffset;

		public AnimationCurve colourGradientCurve;

		public AnimationCurve intensityCurve;

		public Gradient sunGradient;

		public Material skybox;

		public AnimationCurve atmosphereThickness;

		public Gradient skyboxTint;

		public Gradient skyboxGround;

		public AnimationCurve exposure;

		public Material skyboxFreecam;

		public AnimationCurve freecamAtmosphereThickness;

		public Gradient skyboxFreecamTint;

		public Gradient skyboxFreecamGround;

		public AnimationCurve freecamExposure;

		private float _currentDayf;

		public static List<MaterialAdjustTimeOfDay> AdjustingMaterials { get; private set; }

		private void Start()
		{
		}

		public void EnableSun(bool enable)
		{
		}

		public void SetCookie(Texture sunCookie)
		{
		}

		private void Update()
		{
		}

		public void UpdateSun(bool forceUpdate = false)
		{
		}
	}
}
