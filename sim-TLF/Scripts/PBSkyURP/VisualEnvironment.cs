using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[Serializable]
[VolumeComponentMenu("Sky/Visual Environment (URP)")]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[HelpURL("https://github.com/jiaozi158/UnityPhysicallyBasedSkyURP/tree/main")]
public class VisualEnvironment : VolumeComponent, IPostProcessComponent
{
	public enum PlanetMode
	{
		Automatic = 0,
		Manual = 1
	}

	public enum RenderingSpace
	{
		Camera = 0,
		World = 1
	}

	private enum SkyResolution
	{
		SkyResolution128 = 0x80,
		SkyResolution256 = 0x100,
		SkyResolution512 = 0x200,
		SkyResolution1024 = 0x400
	}

	public enum SkyType
	{
		PhysicallyBased = 4,
		Custom = 5
	}

	public enum SkyAmbientMode
	{
		Static = 0,
		Dynamic = 1
	}

	[Serializable]
	public sealed class SkyAmbientModeParameter : VolumeParameter<SkyAmbientMode>
	{
		public SkyAmbientModeParameter(SkyAmbientMode value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}

	[Serializable]
	public sealed class PlanetModeParameter : VolumeParameter<PlanetMode>
	{
		public PlanetModeParameter(PlanetMode value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}

	[Serializable]
	public sealed class RenderingSpaceParameter : VolumeParameter<RenderingSpace>
	{
		public RenderingSpaceParameter(RenderingSpace value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}

	private const float k_DefaultEarthRadius = 6378100f;

	[Header("Sky")]
	public NoInterpIntParameter skyType = new NoInterpIntParameter(0);

	public SkyAmbientModeParameter skyAmbientMode = new SkyAmbientModeParameter(SkyAmbientMode.Dynamic);

	[Header("Planet")]
	public MinFloatParameter planetRadius = new MinFloatParameter(6378.1f, 0f);

	[Tooltip("When in Camera Space, sky and clouds will be centered on the camera.\nWhen in World Space, the camera can navigate through the atmosphere and the clouds.")]
	public RenderingSpaceParameter renderingSpace = new RenderingSpaceParameter(RenderingSpace.World);

	[AdditionalProperty]
	public PlanetModeParameter centerMode = new PlanetModeParameter(PlanetMode.Automatic);

	[AdditionalProperty]
	public Vector3Parameter planetCenter = new Vector3Parameter(new Vector3(0f, -6378.1f, 0f));

	[InspectorName("Sky Material")]
	[Tooltip("The custom sky material for this visual environment.")]
	public MaterialParameter customSkyMaterial = new MaterialParameter(null);

	public bool IsActive()
	{
		return active;
	}

	public float4 GetPlanetCenterRadius(float3 cameraPositionWS)
	{
		float num = planetRadius.value * 1000f;
		return (renderingSpace.value == RenderingSpace.Camera) ? new float4(cameraPositionWS.x, cameraPositionWS.y - num, cameraPositionWS.z, num) : ((centerMode.value != PlanetMode.Automatic) ? new float4(planetCenter.value * 1000f, num) : new float4(0f, 0f - num, 0f, num));
	}

	public float GetPlanetRadius()
	{
		return planetRadius.value * 1000f;
	}
}
