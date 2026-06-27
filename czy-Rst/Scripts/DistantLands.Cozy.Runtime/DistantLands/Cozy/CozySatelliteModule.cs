using System;
using System.Collections.Generic;
using DistantLands.Cozy.Data;
using UnityEngine;
using UnityEngine.Rendering;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozySatelliteModule : CozyModule
	{
		public enum MoonPhase
		{
			newMoon = 0,
			waxingCrescent = 1,
			firstQuarter = 2,
			waxingGibbous = 3,
			fullMoon = 4,
			waningGibbous = 5,
			thirdQuarter = 6,
			waningCrescent = 7
		}

		[CozySearchable(new string[] { "moon", "satellite" })]
		public SatelliteProfile[] satellites = new SatelliteProfile[0];

		[HideInInspector]
		public Transform satHolder;

		[CozySearchable(new string[] { })]
		public bool hideInHierarchy = true;

		private Light moonLight;

		[CozySearchable(new string[] { })]
		public int mainMoon;

		[CozySearchable(new string[] { })]
		public bool useLight = true;

		public LensFlareComponentSRP moonLensFlare;

		public override void InitializeModule()
		{
			moonLight = base.weatherSphere.GetChild<Light>("Moon Light");
			moonLight.enabled = true;
			base.InitializeModule();
			if (base.weatherSphere.moonFlare.flare != null)
			{
				if ((bool)moonLight.GetComponent<LensFlareComponentSRP>())
				{
					moonLensFlare = moonLight.GetComponent<LensFlareComponentSRP>();
				}
				else
				{
					moonLensFlare = moonLight.gameObject.AddComponent<LensFlareComponentSRP>();
				}
			}
		}

		private void Awake()
		{
			UpdateSatellites();
		}

		private void Update()
		{
			if (CozyWeather.FreezeUpdateInEditMode && !Application.isPlaying)
			{
				return;
			}
			if (satHolder == null)
			{
				UpdateSatellites();
			}
			if (moonLight == null)
			{
				moonLight = base.weatherSphere.GetChild<Light>("Moon Light");
			}
			if (satHolder.hideFlags == (HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild) && hideInHierarchy)
			{
				UpdateSatellites();
			}
			if ((bool)base.weatherSphere.cozyCamera && Application.isPlaying)
			{
				satHolder.position = base.weatherSphere.cozyCamera.transform.position;
			}
			if (satellites != null)
			{
				SatelliteProfile[] array = satellites;
				foreach (SatelliteProfile satelliteProfile in array)
				{
					if (!satelliteProfile)
					{
						break;
					}
					if (satelliteProfile.orbitRef == null)
					{
						UpdateSatellites();
					}
					if (satelliteProfile.changedLastFrame)
					{
						UpdateSatellites();
					}
					if (satelliteProfile.linkToDay && (bool)base.weatherSphere.timeModule)
					{
						float num = satelliteProfile.declination * Mathf.Sin(MathF.PI * 2f * ((base.weatherSphere.modifiedDayPercentage - 0.5f + (float)(base.weatherSphere.timeModule.currentDay + satelliteProfile.rotationPeriodOffset + base.weatherSphere.timeModule.DaysPerYear * base.weatherSphere.timeModule.currentYear) % (float)satelliteProfile.declinationPeriod) / (float)satelliteProfile.declinationPeriod));
						satelliteProfile.orbitRef.localEulerAngles = new Vector3(0f, base.weatherSphere.sunDirection + satelliteProfile.satelliteDirection, base.weatherSphere.sunPitch + satelliteProfile.satellitePitch + num);
						satelliteProfile.satelliteRotation = (base.weatherSphere.modifiedDayPercentage - 0.5f + (float)(satelliteProfile.rotationPeriodOffset + base.weatherSphere.timeModule.AbsoluteDay) % (float)satelliteProfile.rotationPeriod) / (float)satelliteProfile.rotationPeriod * 360f;
						satelliteProfile.orbitRef.GetChild(0).localEulerAngles = Vector3.right * (360f * base.weatherSphere.modifiedDayPercentage + satelliteProfile.satelliteRotation + satelliteProfile.orbitOffset - 90f);
					}
					else
					{
						satelliteProfile.orbitRef.localEulerAngles = new Vector3(0f, base.weatherSphere.sunDirection + satelliteProfile.satelliteDirection, base.weatherSphere.sunPitch + satelliteProfile.satellitePitch);
						satelliteProfile.orbitRef.GetChild(0).localEulerAngles = Vector3.right * (360f * base.weatherSphere.dayPercentage + satelliteProfile.orbitOffset);
						satelliteProfile.satelliteRotation += Time.deltaTime * satelliteProfile.satelliteRotateSpeed;
						satelliteProfile.moonRef.localEulerAngles = satelliteProfile.initialRotation + satelliteProfile.satelliteRotateAxis.normalized * satelliteProfile.satelliteRotation;
					}
				}
			}
			if (!moonLight)
			{
				return;
			}
			if (satellites.Length == 0)
			{
				base.weatherSphere.moonDirection = Vector3.up;
				moonLight.transform.forward = Vector3.up;
				Shader.SetGlobalVector("CZY_MoonDirection", base.weatherSphere.moonDirection);
				return;
			}
			base.weatherSphere.moonDirection = -moonLight.transform.forward;
			Shader.SetGlobalVector("CZY_MoonDirection", -moonLight.transform.forward);
			if (mainMoon >= satellites.Length)
			{
				mainMoon = satellites.Length - 1;
			}
			float num2 = Mathf.Clamp01(Mathf.Sin((base.weatherSphere.dayPercentage + 0.25f) * 2f * MathF.PI) + 0.25f) * Mathf.Clamp01(4f * Vector3.Dot(moonLight.transform.forward, Vector3.down));
			moonLight.transform.forward = satellites[mainMoon].orbitRef.GetChild(0).forward;
			moonLight.enabled = base.weatherSphere.moonlightColor.grayscale > 0.05f && satellites.Length != 0 && useLight && !base.weatherSphere.sunLight.enabled;
			moonLight.color = base.weatherSphere.moonlightColor * base.weatherSphere.sunFilter * num2;
			moonLight.shadows = (moonLight.enabled ? base.weatherSphere.moonlightShadows : LightShadows.None);
			if ((bool)moonLensFlare)
			{
				moonLensFlare.intensity = (base.weatherSphere.moonFlare.flare ? num2 : 0f);
				moonLensFlare.lensFlareData = base.weatherSphere.moonFlare.flare;
				moonLensFlare.allowOffScreen = base.weatherSphere.moonFlare.allowOffscreen;
				moonLensFlare.radialScreenAttenuationCurve = base.weatherSphere.moonFlare.screenAttenuation;
				moonLensFlare.distanceAttenuationCurve = base.weatherSphere.moonFlare.screenAttenuation;
				moonLensFlare.scale = base.weatherSphere.moonFlare.scale;
				moonLensFlare.occlusionRadius = base.weatherSphere.moonFlare.occlusionRadius;
				moonLensFlare.useOcclusion = base.weatherSphere.moonFlare.useOcclusion;
			}
		}

		public void UpdateSatellites()
		{
			Transform transform = null;
			if ((bool)satHolder)
			{
				transform = satHolder;
			}
			satHolder = new GameObject("Cozy Satellites").transform;
			if (hideInHierarchy)
			{
				satHolder.gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
			}
			else
			{
				satHolder.gameObject.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
			}
			if (satellites != null)
			{
				SatelliteProfile[] array = satellites;
				foreach (SatelliteProfile sat in array)
				{
					InitializeSatellite(sat);
				}
			}
			if ((bool)transform)
			{
				UnityEngine.Object.DestroyImmediate(transform.gameObject);
			}
		}

		public void DestroySatellites()
		{
			if ((bool)satHolder)
			{
				UnityEngine.Object.DestroyImmediate(satHolder.gameObject);
			}
		}

		public void DestroySatellite(SatelliteProfile sat)
		{
			if ((bool)sat.orbitRef)
			{
				UnityEngine.Object.DestroyImmediate(sat.orbitRef.gameObject);
			}
		}

		public override void DeinitializeModule()
		{
			moonLight.enabled = false;
			DestroySatellites();
			Shader.SetGlobalVector("CZY_MoonDirection", Vector3.down);
		}

		public void InitializeSatellite(SatelliteProfile sat)
		{
			float num = 0f;
			num = ((base.weatherSphere.lockToCamera == CozyWeather.LockToCameraStyle.DontLockToCamera || !base.weatherSphere.cozyCamera) ? (920f * sat.distance * base.weatherSphere.transform.localScale.x) : (0.92f * base.weatherSphere.cozyCamera.farClipPlane * sat.distance));
			sat.orbitRef = new GameObject(sat.name).transform;
			sat.orbitRef.parent = satHolder;
			sat.orbitRef.transform.localPosition = Vector3.zero;
			GameObject obj = new GameObject("Orbit Arm");
			obj.transform.parent = sat.orbitRef;
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localEulerAngles = Vector3.zero;
			sat.moonRef = UnityEngine.Object.Instantiate(sat.satelliteReference, Vector3.forward * num, Quaternion.identity, sat.orbitRef.GetChild(0)).transform;
			sat.moonRef.transform.localPosition = -Vector3.forward * num;
			sat.moonRef.transform.localEulerAngles = sat.initialRotation;
			sat.moonRef.transform.localScale = sat.satelliteReference.transform.localScale * sat.size * (sat.autoScaleByDistance ? (num / 1000f) : 1f);
			sat.orbitRef.localEulerAngles = new Vector3(0f, sat.satelliteDirection, sat.satellitePitch);
			sat.orbitRef.GetChild(0).localEulerAngles = Vector3.right * (360f * base.weatherSphere.dayPercentage + sat.orbitOffset);
			sat.changedLastFrame = false;
		}

		private void Reset()
		{
			List<SatelliteProfile> list = new List<SatelliteProfile> { Resources.Load("Profiles/Satellites/Stylized Moon") as SatelliteProfile };
			satellites = list.ToArray();
		}

		public MoonPhase GetMoonPhase()
		{
			if (!base.weatherSphere.timeModule || satellites.Length == 0)
			{
				return MoonPhase.newMoon;
			}
			SatelliteProfile satelliteProfile = satellites[mainMoon];
			return (MoonPhase)Mathf.Clamp(Mathf.FloorToInt((float)((base.weatherSphere.timeModule.AbsoluteDay + satelliteProfile.rotationPeriodOffset + 1) % satelliteProfile.rotationPeriod) / ((float)satelliteProfile.rotationPeriod / 8f)), 0, 7);
		}

		public string GetMoonPhaseName()
		{
			string result = "New Moon";
			switch (GetMoonPhase())
			{
			case MoonPhase.newMoon:
				result = "New Moon";
				break;
			case MoonPhase.waxingCrescent:
				result = "Waxing Crescent";
				break;
			case MoonPhase.firstQuarter:
				result = "First Quarter";
				break;
			case MoonPhase.waxingGibbous:
				result = "Waxing Gibbous";
				break;
			case MoonPhase.fullMoon:
				result = "Full Moon";
				break;
			case MoonPhase.waningGibbous:
				result = "Waning Gibbous";
				break;
			case MoonPhase.thirdQuarter:
				result = "Third Quarter";
				break;
			case MoonPhase.waningCrescent:
				result = "Waning Crescent";
				break;
			}
			return result;
		}
	}
}
