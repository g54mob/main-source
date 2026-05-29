using System;
using UnityEngine;

namespace CW.Common
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Light))]
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwLightIntensity")]
	[AddComponentMenu("Common/CW Light Intensity")]
	public class CwLightIntensity : MonoBehaviour
	{
		[SerializeField]
		private float multiplier;

		[SerializeField]
		private float intensityInStandard;

		[SerializeField]
		private float intensityInURP;

		[SerializeField]
		private float intensityInHDRP;

		[NonSerialized]
		private Light cachedLight;

		[NonSerialized]
		private bool cachedLightSet;

		public float Multiplier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float IntensityInStandard
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float IntensityInURP
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float IntensityInHDRP
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Light CachedLight => null;

		protected virtual void Update()
		{
		}

		private void ApplyIntensity(float intensity)
		{
		}
	}
}
