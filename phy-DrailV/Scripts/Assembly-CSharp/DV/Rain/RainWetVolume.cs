using DV.Utils;
using DV.WeatherSystem;
using PlaceholderSoftware.WetStuff;
using UnityEngine;

namespace DV.Rain
{
	public class RainWetVolume : MonoBehaviour
	{
		public AnimationCurve rainMap;

		public float saturation;

		public float threshold;

		public float distance;

		public float rainBuildup;

		public float decalScale;

		private WetDecal decal;

		private void Awake()
		{
			decal = GetComponent<WetDecal>();
		}

		private void Update()
		{
			Camera activeCamera = PlayerManager.ActiveCamera;
			if ((bool)activeCamera)
			{
				base.transform.position = activeCamera.transform.position;
				base.transform.localScale = Vector3.one * distance;
				if ((bool)SingletonBehaviour<WeatherDriver>.Instance)
				{
					rainBuildup = rainMap.Evaluate(SingletonBehaviour<WeatherDriver>.Instance.WetnessValue);
				}
				decal.Settings.YLayer.Channel1.InputRangeThreshold = rainBuildup * threshold;
				decal.Settings.Saturation = rainBuildup * saturation;
				Vector4 layerMaskScaleOffset = decal.Settings.YLayer.LayerMaskScaleOffset;
				layerMaskScaleOffset.x = decalScale;
				layerMaskScaleOffset.y = decalScale;
				decal.Settings.YLayer.LayerMaskScaleOffset = layerMaskScaleOffset;
			}
		}
	}
}
