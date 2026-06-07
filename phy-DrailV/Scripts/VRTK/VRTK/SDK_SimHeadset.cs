using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	[SDK_Description(typeof(SDK_SimSystem), 0)]
	public class SDK_SimHeadset : SDK_BaseHeadset
	{
		private Transform camera;

		protected VRTK_VelocityEstimator cachedHeadsetVelocityEstimator;

		private float magnitude;

		private Vector3 axis;

		public override void ProcessUpdate(Dictionary<string, object> options)
		{
		}

		public override void ProcessFixedUpdate(Dictionary<string, object> options)
		{
		}

		public override Transform GetHeadset()
		{
			if (camera == null)
			{
				GameObject gameObject = SDK_InputSimulator.FindInScene();
				if ((bool)gameObject)
				{
					camera = gameObject.transform.Find("Neck/Camera");
				}
			}
			return camera;
		}

		public override Transform GetHeadsetCamera()
		{
			return GetHeadset();
		}

		public override string GetHeadsetType()
		{
			return CleanPropertyString("simulator");
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
			return obj.GetComponentInChildren<VRTK_ScreenFade>() != null;
		}

		public override void AddHeadsetFade(Transform camera)
		{
			if (camera != null && camera.GetComponent<VRTK_ScreenFade>() == null)
			{
				camera.gameObject.AddComponent<VRTK_ScreenFade>();
			}
		}

		protected virtual void OnEnable()
		{
			SetHeadsetCaches();
		}

		protected virtual void SetHeadsetCaches()
		{
			Transform headset = GetHeadset();
			if (cachedHeadsetVelocityEstimator == null && headset != null)
			{
				cachedHeadsetVelocityEstimator = ((headset.GetComponent<VRTK_VelocityEstimator>() != null) ? headset.GetComponent<VRTK_VelocityEstimator>() : headset.gameObject.AddComponent<VRTK_VelocityEstimator>());
			}
		}
	}
}
