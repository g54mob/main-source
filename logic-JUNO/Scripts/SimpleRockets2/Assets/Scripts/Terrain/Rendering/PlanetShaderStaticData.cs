using System;
using ModApi.Planet;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Terrain.Rendering
{
	[Serializable]
	public class PlanetShaderStaticData
	{
		public float AmbientLightMinFalloff { get; private set; }

		public float AtmosphereRenderHeight { get; private set; }

		public float AtmosphereRenderRadius { get; private set; }

		public float AtmosRenderingSizeScale => 1f + 0.024999976f * AtmosSizeScale;

		public float AtmosSizeScale
		{
			get
			{
				if (!IsSkyShader)
				{
					return PlanetData.ShaderDataTerrain.AtmosSizeScale;
				}
				return PlanetData.ShaderDataSky.AtmosSizeScale;
			}
		}

		public float DebugScalar { get; private set; }

		public float G2 { get; private set; }

		public float InnerRadius { get; private set; }

		public float InnerRadius2 { get; private set; }

		public Color InvWaveLength { get; private set; }

		public bool IsQuadsphereTerrain { get; private set; }

		public bool IsScaledSpaceShader { get; private set; }

		public bool IsSkyShader { get; private set; }

		public float Km4PI { get; private set; }

		public float KmESun { get; private set; }

		public float Kr4PI { get; private set; }

		public float KrESun { get; private set; }

		public float MaxColorValue { get; private set; }

		public float MinimumReflectivity { get; private set; }

		public float OuterRadius { get; private set; }

		public float OuterRadius2 { get; private set; }

		public PlanetRenderingData PlanetData { get; private set; }

		public float PlanetRenderRadius { get; private set; }

		public float Scale { get; private set; }

		public float ScaleOverScaleDepth { get; private set; }

		public float SeaLevelWorldRadius { get; private set; }

		public bool SkyboxFadeDuringDay { get; }

		public Transform Transform { get; private set; }

		public PlanetShaderStaticData(PlanetRenderingData planetData, Transform transform, bool skyShader, bool scaledSpaceShader, bool fadeSkyboxDuringDay)
		{
			SkyboxFadeDuringDay = fadeSkyboxDuringDay;
			PlanetData = planetData;
			Transform = transform;
			IsSkyShader = skyShader;
			IsScaledSpaceShader = scaledSpaceShader;
			IsQuadsphereTerrain = !IsSkyShader && !IsScaledSpaceShader;
		}

		public void SetShaderProperties()
		{
			PlanetShaderData planetShaderData = (IsSkyShader ? PlanetData.ShaderDataSky : PlanetData.ShaderDataTerrain);
			Shader.SetGlobalFloat("_scaleDepth", planetShaderData.ScaleDepth);
			Shader.SetGlobalFloat("_samples", planetShaderData.Samples);
			Shader.SetGlobalFloat("_g", planetShaderData.G);
			Shader.SetGlobalFloat("_atmosScale", planetShaderData.AtmosScale);
			Shader.SetGlobalColor("_noonColor", planetShaderData.NoonColor.linear);
			Shader.SetGlobalColor("_duskColor", planetShaderData.DuskColor.linear);
			Shader.SetGlobalFloat("_lightingFresnelBias", planetShaderData.FresnelBias);
			Shader.SetGlobalFloat("_minimumReflectivity", MinimumReflectivity);
			Shader.SetGlobalFloat("_ambientLightMinFalloff", AmbientLightMinFalloff);
			Shader.SetGlobalFloat("_debugScaler", planetShaderData.DebugScaler);
			Shader.SetGlobalColor("_invWaveLength", InvWaveLength);
			Shader.SetGlobalFloat("_outerRadius", OuterRadius);
			Shader.SetGlobalFloat("_outerRadius2", OuterRadius2);
			Shader.SetGlobalFloat("_innerRadius", InnerRadius);
			Shader.SetGlobalFloat("_innerRadius2", InnerRadius2);
			Shader.SetGlobalFloat("_atmosSizeScale", AtmosSizeScale);
			Shader.SetGlobalFloat("_seaLevelWorldRadius", SeaLevelWorldRadius);
			Shader.SetGlobalFloat("_worldPositionScale", PlanetRenderRadius);
			Shader.SetGlobalFloat("_krESun", KrESun);
			Shader.SetGlobalFloat("_kmESun", KmESun);
			Shader.SetGlobalFloat("_kr4PI", Kr4PI);
			Shader.SetGlobalFloat("_km4PI", Km4PI);
			Shader.SetGlobalFloat("_scale", Scale);
			Shader.SetGlobalFloat("_scaleOverScaleDepth", ScaleOverScaleDepth);
			Shader.SetGlobalFloat("_maxColorValue", planetShaderData.MaxColorValue);
			Shader.SetGlobalFloat("_g2", G2);
			Shader.SetGlobalFloat("_debugScaler", DebugScalar);
			if (!Game.InFlightScene)
			{
				Shader.SetGlobalVector("_sunLightColor", new Vector4(1f, 1f, 1f, 1f));
			}
		}

		public void SetShaderProperties(Material material)
		{
			PlanetShaderData planetShaderData = (IsSkyShader ? PlanetData.ShaderDataSky : PlanetData.ShaderDataTerrain);
			material.SetFloat("_scaleDepth", planetShaderData.ScaleDepth);
			material.SetFloat("_samples", planetShaderData.Samples);
			material.SetFloat("_g", planetShaderData.G);
			material.SetColor("_noonColor", planetShaderData.NoonColor.linear);
			material.SetColor("_duskColor", planetShaderData.DuskColor.linear);
			material.SetFloat("_lightingFresnelBias", planetShaderData.FresnelBias);
			material.SetFloat("_maxColorValue", planetShaderData.MaxColorValue);
			material.SetColor("_invWaveLength", InvWaveLength);
			material.SetFloat("_outerRadius", OuterRadius);
			material.SetFloat("_outerRadius2", OuterRadius2);
			material.SetFloat("_innerRadius", InnerRadius);
			material.SetFloat("_innerRadius2", InnerRadius2);
			material.SetFloat("_atmosSizeScale", AtmosSizeScale);
			material.SetFloat("_seaLevelWorldRadius", SeaLevelWorldRadius);
			material.SetFloat("_krESun", KrESun);
			material.SetFloat("_kmESun", KmESun);
			material.SetFloat("_kr4PI", Kr4PI);
			material.SetFloat("_km4PI", Km4PI);
			material.SetFloat("_scale", Scale);
			material.SetFloat("_scaleOverScaleDepth", ScaleOverScaleDepth);
			material.SetFloat("_g2", G2);
			material.SetFloat("_debugScaler", DebugScalar);
			if (IsSkyShader)
			{
				material.SetInt("_legacySkyShader", planetShaderData.Options.LegacySkyShader ? 1 : 0);
			}
		}

		public void Update()
		{
			PlanetShaderData planetShaderData = (IsSkyShader ? PlanetData.ShaderDataSky : PlanetData.ShaderDataTerrain);
			PlanetRenderRadius = (IsScaledSpaceShader ? PlanetData.RadiusScaledSpace : PlanetData.Radius);
			AtmosphereRenderRadius = PlanetRenderRadius * AtmosRenderingSizeScale;
			AtmosphereRenderHeight = AtmosphereRenderRadius - PlanetRenderRadius;
			InvWaveLength = planetShaderData.WaveLengthMag * new Color(Mathf.Pow(1f / planetShaderData.WaveLength[0], 4f), Mathf.Pow(1f / planetShaderData.WaveLength[1], 4f), Mathf.Pow(1f / planetShaderData.WaveLength[2], 4f), planetShaderData.WaveLength[3]);
			KmESun = planetShaderData.Km * planetShaderData.ESun;
			KrESun = planetShaderData.Kr * planetShaderData.ESun;
			Kr4PI = planetShaderData.Kr * 4f * MathF.PI;
			Km4PI = planetShaderData.Km * 4f * MathF.PI;
			G2 = planetShaderData.G * planetShaderData.G;
			if (IsSkyShader)
			{
				InnerRadius = PlanetRenderRadius / AtmosphereRenderRadius;
				OuterRadius = 1f;
			}
			else
			{
				InnerRadius = 1f;
				OuterRadius = AtmosphereRenderRadius / PlanetRenderRadius;
			}
			InnerRadius2 = InnerRadius * InnerRadius;
			OuterRadius2 = OuterRadius * OuterRadius;
			SeaLevelWorldRadius = PlanetData.Radius + PlanetData.SeaLevel;
			Scale = 1f / (AtmosphereRenderRadius / PlanetRenderRadius - 1f);
			ScaleOverScaleDepth = Scale / planetShaderData.ScaleDepth;
			FlightSettings flight = Game.Instance.Settings.Game.Flight;
			AmbientLightMinFalloff = (flight.AmbientLightAttenuation.Value ? 0f : 1f);
			IGameQualitySettings qualitySettings = Game.Instance.QualitySettings;
			MinimumReflectivity = ((qualitySettings.Crafts.Reflections.Value == CraftQualitySettings.CraftReflectionsQuality.Realtime) ? 1f : 0.05f);
			DebugScalar = planetShaderData.DebugScaler;
		}
	}
}
