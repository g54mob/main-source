using System;
using Assets.Scripts.Flight;
using Assets.Scripts.PlanetStudio;
using ModApi;
using ModApi.Common;
using ModApi.Craft;
using ModApi.Flight;
using ModApi.Planet;
using ModApi.Scenes;
using ModApi.Settings;
using ModApi.Settings.Core;
using UnityEngine;

namespace Assets.Scripts.Terrain.Rendering
{
	[Serializable]
	public class PlanetShaderDynamicData
	{
		private static class ShaderPropertyIds
		{
			public static readonly int AdjustedCameraPosition = Shader.PropertyToID("_adjustedCameraPosition");

			public static readonly int AtmosphereStrenghtAtCamera = Shader.PropertyToID("_atmosphereStrenghtAtCamera");

			public static readonly int AtmosScale = Shader.PropertyToID("_atmosScale");

			public static readonly int CameraHeight = Shader.PropertyToID("_cameraHeight");

			public static readonly int CameraHeight2 = Shader.PropertyToID("_cameraHeight2");

			public static readonly int CameraHeightAtmosPercent = Shader.PropertyToID("_cameraHeightAtmosPercent");

			public static readonly int CameraViewDir = Shader.PropertyToID("_cameraViewDir");

			public static readonly int GroundToSkyLightFade = Shader.PropertyToID("_groundToSkyLightFade");

			public static readonly int LightDir = Shader.PropertyToID("_lightDir");

			public static readonly int NightToDayLerpValue = Shader.PropertyToID("_nightToDayLerpValue");

			public static readonly int PlanetCenter = Shader.PropertyToID("_planetCenter");

			public static readonly int PlayerCraftVelocityNormalized = Shader.PropertyToID("_playerCraftVelocityNormalized");

			public static readonly int QuadToScaledTransition = Shader.PropertyToID("_quadToScaledTransition");

			public static readonly int ScaleDepth = Shader.PropertyToID("_scaleDepth");

			public static readonly int ScaleOverScaleDepth = Shader.PropertyToID("_scaleOverScaleDepth");

			public static readonly int UnderwaterColor = Shader.PropertyToID("_underwaterColor");

			public static readonly int UnderwaterColorIntensity = Shader.PropertyToID("_underwaterColorIntensity");

			public static readonly int UnderwaterDarkColor = Shader.PropertyToID("_underwaterDarkColor");

			public static readonly int UnderwaterLightFadeDepth = Shader.PropertyToID("_underwaterLightFadeDepth");

			public static readonly int UnderwaterLightFadeDistance = Shader.PropertyToID("_underwaterLightFadeDistance");

			public static readonly int WorldCameraPosition = Shader.PropertyToID("_worldCameraPosition");
		}

		private NumericSetting<float> _ambientLightAtNightStrength;

		[SerializeField]
		private Color _ambientLightInSpace = Constants.Rendering.AmbientLightInSpace;

		private NumericSetting<float> _ambientLightInSpaceStrength;

		private NumericSetting<float> _skyboxExposure;

		public Vector3 AdjustedCameraPosition { get; private set; }

		public Color AmbientLight { get; private set; }

		public float AtmospherePercent { get; private set; }

		public float AtmosphereStrengthAtCamera { get; private set; }

		public float AtmosScale { get; private set; }

		public float CameraHeight { get; private set; }

		public float CameraHeight2 { get; private set; }

		public Vector3 CameraViewDirection { get; private set; }

		public float GroundToSkyLightFade { get; private set; }

		public Vector2 NightToDayLerpValue { get; private set; }

		public Vector3 PlanetCenterPosition { get; private set; }

		public Vector3 PlayerCraftVelocityNormalized { get; private set; }

		public float QuadToScaledTransition { get; private set; }

		public double RadiusScale { get; set; } = 1.0;

		public Vector3 RelativeCameraPosition { get; private set; }

		public float ScaleDepth { get; private set; }

		public float ScaleOverScaleDepth { get; private set; }

		public PlanetShaderStaticData StaticData { get; private set; }

		public Vector3 SunLightDirection { get; private set; }

		public Color UnderwaterColor { get; private set; }

		public float UnderwaterColorIntensity { get; private set; }

		public Color UnderwaterDarkColor { get; private set; }

		public float UnderwaterLightFadeDepth { get; private set; }

		public float UnderwaterLightFadeDistance { get; private set; }

		public float UnscaledCameraHeight { get; private set; }

		public PlanetWaterConfig WaterConfig { get; private set; }

		public Vector3 WorldCameraPosition { get; private set; }

		public PlanetShaderDynamicData(PlanetShaderStaticData staticData)
		{
			StaticData = staticData;
			FlightSettings flight = Game.Instance.Settings.Game.Flight;
			_ambientLightAtNightStrength = flight.AmbientLightAtNightStrength;
			_ambientLightInSpaceStrength = flight.AmbientLightInSpaceStrength;
			_skyboxExposure = flight.StarSkyboxExposure;
			QuadToScaledTransition = 1f;
		}

		public void SetShaderProperties()
		{
			Shader.SetGlobalVector(ShaderPropertyIds.LightDir, SunLightDirection);
			Shader.SetGlobalVector(ShaderPropertyIds.AdjustedCameraPosition, AdjustedCameraPosition);
			Shader.SetGlobalVector(ShaderPropertyIds.WorldCameraPosition, WorldCameraPosition);
			Shader.SetGlobalVector(ShaderPropertyIds.CameraViewDir, CameraViewDirection);
			Shader.SetGlobalFloat(ShaderPropertyIds.CameraHeight, CameraHeight);
			Shader.SetGlobalFloat(ShaderPropertyIds.CameraHeight2, CameraHeight2);
			Shader.SetGlobalFloat(ShaderPropertyIds.AtmosphereStrenghtAtCamera, AtmosphereStrengthAtCamera);
			Shader.SetGlobalFloat(ShaderPropertyIds.CameraHeightAtmosPercent, AtmospherePercent);
			Shader.SetGlobalFloat(ShaderPropertyIds.GroundToSkyLightFade, GroundToSkyLightFade);
			Shader.SetGlobalFloat(ShaderPropertyIds.ScaleDepth, ScaleDepth);
			Shader.SetGlobalFloat(ShaderPropertyIds.ScaleOverScaleDepth, ScaleOverScaleDepth);
			Shader.SetGlobalFloat(ShaderPropertyIds.AtmosScale, AtmosScale);
			Shader.SetGlobalVector(ShaderPropertyIds.PlanetCenter, PlanetCenterPosition);
			Shader.SetGlobalFloat(ShaderPropertyIds.QuadToScaledTransition, QuadToScaledTransition);
			Shader.SetGlobalVector(ShaderPropertyIds.PlayerCraftVelocityNormalized, PlayerCraftVelocityNormalized);
			Shader.SetGlobalVector(ShaderPropertyIds.NightToDayLerpValue, NightToDayLerpValue);
			if (WaterConfig != null)
			{
				Shader.SetGlobalFloat(ShaderPropertyIds.UnderwaterLightFadeDepth, UnderwaterLightFadeDepth);
				Shader.SetGlobalFloat(ShaderPropertyIds.UnderwaterLightFadeDistance, UnderwaterLightFadeDistance);
				Shader.SetGlobalVector(ShaderPropertyIds.UnderwaterColor, UnderwaterColor);
				Shader.SetGlobalVector(ShaderPropertyIds.UnderwaterDarkColor, UnderwaterDarkColor);
				Shader.SetGlobalFloat(ShaderPropertyIds.UnderwaterColorIntensity, UnderwaterColorIntensity);
			}
		}

		public void SetShaderProperties(Material material)
		{
			PlanetShaderStaticData staticData = StaticData;
			bool isScaledSpaceShader = staticData.IsScaledSpaceShader;
			material.SetVector(ShaderPropertyIds.LightDir, SunLightDirection);
			material.SetVector(ShaderPropertyIds.AdjustedCameraPosition, AdjustedCameraPosition);
			if (!isScaledSpaceShader || staticData.PlanetData.HasAtmosphere)
			{
				material.SetVector(ShaderPropertyIds.WorldCameraPosition, WorldCameraPosition);
				material.SetVector(ShaderPropertyIds.CameraViewDir, CameraViewDirection);
				material.SetFloat(ShaderPropertyIds.CameraHeight, CameraHeight);
				material.SetFloat(ShaderPropertyIds.CameraHeight2, CameraHeight2);
				material.SetFloat(ShaderPropertyIds.QuadToScaledTransition, QuadToScaledTransition);
				if (!isScaledSpaceShader)
				{
					material.SetFloat(ShaderPropertyIds.CameraHeightAtmosPercent, AtmospherePercent);
				}
				material.SetFloat(ShaderPropertyIds.AtmosScale, AtmosScale);
				material.SetFloat(ShaderPropertyIds.ScaleDepth, ScaleDepth);
				material.SetFloat(ShaderPropertyIds.ScaleOverScaleDepth, ScaleOverScaleDepth);
			}
		}

		public void Update(bool currentPlanet)
		{
			PlanetShaderStaticData staticData = StaticData;
			PlanetRenderingData planetData = staticData.PlanetData;
			IFlightScene flightScene = Game.Instance.FlightScene;
			bool flag = flightScene != null;
			bool flag2 = !flag && Game.InPlanetStudioScene;
			IPlanet planet = null;
			if (currentPlanet)
			{
				if (flag)
				{
					planet = flightScene.ViewManager.GameView.Planet;
					WaterConfig = flightScene.ViewManager.GameView.GameCamera.CameraBiomeData.WaterConfig;
				}
				else if (flag2)
				{
					CelestialBodyViewerScript celestialBodyViewer = PlanetStudioScript.Instance.CelestialBodyDesignerScript.CelestialBodyViewer;
					planet = celestialBodyViewer.PlanetScript;
					if (celestialBodyViewer.GameView != null)
					{
						WaterConfig = celestialBodyViewer.GameView.GameCamera.CameraBiomeData.WaterConfig;
					}
				}
			}
			QuadToScaledTransition = planet?.QuadSphereTransitionStrength ?? 0f;
			Transform light = planetData.Light;
			if (staticData.IsScaledSpaceShader)
			{
				Vector3 normalized = (light.position - staticData.Transform.position).normalized;
				SunLightDirection = staticData.Transform.InverseTransformDirection(normalized).normalized;
			}
			else if (staticData.IsSkyShader)
			{
				SunLightDirection = (Quaternion.Inverse(staticData.Transform.rotation) * light.TransformDirection(-Vector3.forward)).normalized;
			}
			else
			{
				SunLightDirection = light.TransformDirection(-Vector3.forward).normalized;
			}
			Transform camera = planetData.Camera;
			CameraViewDirection = camera.forward;
			WorldCameraPosition = camera.position;
			PlanetCenterPosition = planetData.Center;
			RelativeCameraPosition = WorldCameraPosition - PlanetCenterPosition;
			UnscaledCameraHeight = RelativeCameraPosition.magnitude;
			Vector3 vector = RelativeCameraPosition / UnscaledCameraHeight;
			float num = (staticData.IsQuadsphereTerrain ? staticData.PlanetRenderRadius : staticData.AtmosphereRenderRadius);
			num *= (float)RadiusScale;
			AdjustedCameraPosition = vector * (UnscaledCameraHeight / num);
			if (!staticData.IsQuadsphereTerrain)
			{
				AdjustedCameraPosition = Quaternion.Inverse(staticData.Transform.rotation) * AdjustedCameraPosition;
			}
			if (staticData.IsScaledSpaceShader && !planetData.HasAtmosphere)
			{
				return;
			}
			CameraHeight2 = AdjustedCameraPosition.sqrMagnitude;
			CameraHeight = Mathf.Sqrt(CameraHeight2);
			if (flag)
			{
				ICraftFlightData flightData = flightScene.CraftNode.CraftScript.FlightData;
				if ((float)flightData.SurfaceVelocityMagnitude > 0f)
				{
					PlayerCraftVelocityNormalized = flightData.SurfaceVelocityFrame / (float)flightData.SurfaceVelocityMagnitude * flightData.MachNumber * 0.5f;
				}
				else
				{
					PlayerCraftVelocityNormalized = Vector3.right * 0.01f;
				}
			}
			PlanetShaderData planetShaderData = (staticData.IsSkyShader ? planetData.ShaderDataSky : planetData.ShaderDataTerrain);
			if (staticData.IsScaledSpaceShader)
			{
				AtmospherePercent = 1f;
				AtmosphereStrengthAtCamera = 0f;
				AtmosScale = (planetShaderData.Options.AtmosScaleAuto ? planetShaderData.AtmosScaleSpace : planetShaderData.AtmosScale);
				ScaleDepth = (planetShaderData.Options.ScaleDepthAuto ? planetShaderData.ScaleDepthMax : planetShaderData.ScaleDepth);
				ScaleOverScaleDepth = staticData.Scale / ScaleDepth;
				return;
			}
			float num2 = UnscaledCameraHeight - staticData.PlanetRenderRadius;
			AtmospherePercent = Mathf.Clamp01(num2 / staticData.AtmosphereRenderHeight);
			AtmosphereStrengthAtCamera = 1f - AtmospherePercent;
			AtmosScale = (planetShaderData.Options.AtmosScaleAuto ? Mathf.Lerp(planetShaderData.AtmosScaleSurface, planetShaderData.AtmosScaleSpace, AtmospherePercent) : planetShaderData.AtmosScale);
			ScaleDepth = (planetShaderData.Options.ScaleDepthAuto ? Mathf.Lerp(planetShaderData.ScaleDepthMin, planetShaderData.ScaleDepthMax, AtmospherePercent) : planetShaderData.ScaleDepth);
			ScaleOverScaleDepth = staticData.Scale / ScaleDepth;
			if (staticData.IsSkyShader)
			{
				return;
			}
			ICraftFlightData craftFlightData = FlightSceneScript.Instance?.CraftNode.CraftScript.FlightData;
			float num3 = Vector3.Dot(vector, SunLightDirection);
			MinMaxValue ambientLightAltitudeRange = planetShaderData.AmbientLightAltitudeRange;
			Color color = _ambientLightInSpace * _ambientLightInSpaceStrength.Value;
			float num4 = num2 - (float)((craftFlightData == null) ? 0.0 : (craftFlightData.AltitudeAboveSeaLevel - craftFlightData.AltitudeAboveGroundLevel));
			if (num4 < ambientLightAltitudeRange.MaxValue)
			{
				float num5 = 0.1f + num3;
				if ((double)num5 > 0.2)
				{
					NightToDayLerpValue = new Vector2(1f, 0f);
					AmbientLight = planetShaderData.AmbientLightDay;
				}
				else if (num5 < 0f)
				{
					NightToDayLerpValue = new Vector2(0f, 1f);
					AmbientLight = planetShaderData.AmbientLightNight * _ambientLightAtNightStrength.Value;
				}
				else
				{
					float num6 = num5 * 5f;
					NightToDayLerpValue = new Vector2(num6, 1f - num6);
					Color ambientLightDay = planetShaderData.AmbientLightDay;
					Color a = planetShaderData.AmbientLightNight * _ambientLightAtNightStrength.Value;
					AmbientLight = Color.LerpUnclamped(a, ambientLightDay, num6);
				}
				if (num4 > ambientLightAltitudeRange.MinValue)
				{
					float t = (num4 - ambientLightAltitudeRange.MinValue) / (ambientLightAltitudeRange.MaxValue - ambientLightAltitudeRange.MinValue);
					AmbientLight = Color.Lerp(AmbientLight, color, t);
				}
			}
			else
			{
				NightToDayLerpValue = new Vector2(0f, 1f);
				AmbientLight = color;
			}
			RenderSettings.ambientLight = AmbientLight;
			float num7 = SceneSkybox.DefaultExposure * _skyboxExposure.Value;
			if (AtmospherePercent > 1f || !StaticData.SkyboxFadeDuringDay || (flightScene != null && flightScene.ViewManager.MapViewManager.IsInForeground))
			{
				SceneSkybox.Exposure = num7;
			}
			else if (num3 > -0.1f)
			{
				float t2 = (AtmospherePercent - 0.25f) / 0.75f;
				SceneSkybox.Exposure = Mathf.Lerp(0f, num7, t2);
			}
			else if (num3 < -0.2f)
			{
				SceneSkybox.Exposure = num7;
			}
			else
			{
				float t3 = (num3 + 0.2f) / 0.1f;
				float t4 = (AtmospherePercent - 0.25f) / 0.75f;
				SceneSkybox.Exposure = Mathf.Lerp(num7, Mathf.Lerp(0f, num7, t4), t3);
			}
			if (craftFlightData != null)
			{
				GroundToSkyLightFade = Mathf.Clamp01((float)craftFlightData.AltitudeAboveGroundLevel * 0.0002f);
			}
			else
			{
				GroundToSkyLightFade = 1f;
			}
			if (WaterConfig != null)
			{
				UnderwaterLightFadeDepth = Mathf.Clamp01((StaticData.SeaLevelWorldRadius - UnscaledCameraHeight) / WaterConfig.UnderwaterLightFadeDepth);
				UnderwaterLightFadeDistance = WaterConfig.UnderwaterLightFadeDistance;
				UnderwaterColorIntensity = WaterConfig.UnderwaterColorIntensity;
				UnderwaterDarkColor = WaterConfig.UnderwaterDarkColorLinear;
				UnderwaterColor = WaterConfig.UnderwaterColorLinear;
			}
		}
	}
}
