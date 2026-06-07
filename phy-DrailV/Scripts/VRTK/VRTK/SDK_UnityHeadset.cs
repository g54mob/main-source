using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	[SDK_Description(typeof(SDK_UnitySystem), 0)]
	[SDK_Description(typeof(SDK_UnitySystem), 1)]
	[SDK_Description(typeof(SDK_UnitySystem), 2)]
	[SDK_Description(typeof(SDK_UnitySystem), 3)]
	[SDK_Description(typeof(SDK_UnitySystem), 4)]
	[SDK_Description(typeof(SDK_UnitySystem), 5)]
	public class SDK_UnityHeadset : SDK_BaseHeadset
	{
		protected VRTK_VelocityEstimator cachedHeadsetVelocityEstimator;

		public override void ProcessUpdate(Dictionary<string, object> options)
		{
		}

		public override void ProcessFixedUpdate(Dictionary<string, object> options)
		{
		}

		public override Transform GetHeadset()
		{
			cachedHeadset = GetSDKManagerHeadset();
			if (cachedHeadset == null)
			{
				GameObject gameObject = VRTK_SharedMethods.FindEvenInactiveGameObject<SDK_UnityHeadsetTracker>(null, searchAllScenes: true);
				if (gameObject != null)
				{
					cachedHeadset = gameObject.transform;
				}
			}
			return cachedHeadset;
		}

		public override Transform GetHeadsetCamera()
		{
			return GetHeadset();
		}

		public override string GetHeadsetType()
		{
			return ScrapeHeadsetType();
		}

		public override Vector3 GetHeadsetVelocity()
		{
			SetHeadsetCaches();
			return cachedHeadsetVelocityEstimator.GetVelocityEstimate();
		}

		public override Vector3 GetHeadsetAngularVelocity()
		{
			SetHeadsetCaches();
			return cachedHeadsetVelocityEstimator.GetAngularVelocityEstimate();
		}

		public override void HeadsetFade(Color color, float duration, bool fadeOverlay = false)
		{
			VRTK_ScreenFade.Start(color, duration);
		}

		public override bool HasHeadsetFade(Transform obj)
		{
			return obj.GetComponentInChildren<VRTK_ScreenFade>();
		}

		public override void AddHeadsetFade(Transform camera)
		{
			if (camera != null && !camera.GetComponent<VRTK_ScreenFade>())
			{
				camera.gameObject.AddComponent<VRTK_ScreenFade>();
			}
		}

		protected virtual void SetHeadsetCaches()
		{
			Transform headset = GetHeadset();
			if (cachedHeadsetVelocityEstimator == null && headset != null)
			{
				cachedHeadsetVelocityEstimator = headset.GetComponent<VRTK_VelocityEstimator>();
			}
		}
	}
}
