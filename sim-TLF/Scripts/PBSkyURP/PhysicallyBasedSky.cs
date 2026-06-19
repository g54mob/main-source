using System;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[Serializable]
[VolumeComponentMenu("Sky/Physically Based Sky (URP)")]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[HelpURL("https://github.com/jiaozi158/UnityPhysicallyBasedSkyURP/tree/main")]
public class PhysicallyBasedSky : VolumeComponent, IPostProcessComponent
{
	public enum PhysicallyBasedSkyModel
	{
		EarthSimple = 0,
		EarthAdvanced = 1,
		Custom = 2
	}

	public enum EnvironmentUpdateMode
	{
		OnChanged = 0,
		OnDemand = 1,
		Realtime = 2
	}

	public enum SkyIntensityMode
	{
		Exposure = 0,
		Lux = 1,
		Multiplier = 2
	}

	[Serializable]
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	public sealed class SkyIntensityParameter : VolumeParameter<SkyIntensityMode>
	{
		public SkyIntensityParameter(SkyIntensityMode value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}

	[Serializable]
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	public sealed class EnvUpdateParameter : VolumeParameter<EnvironmentUpdateMode>
	{
		public EnvUpdateParameter(EnvironmentUpdateMode value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}

	[Serializable]
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	public sealed class PhysicallyBasedSkyModelParameter : VolumeParameter<PhysicallyBasedSkyModel>
	{
		public PhysicallyBasedSkyModelParameter(PhysicallyBasedSkyModel value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}

	private const float k_DefaultEarthRadius = 6378100f;

	private const float k_DefaultAirScatteringR = 5.8E-06f;

	private const float k_DefaultAirScatteringG = 1.35E-05f;

	private const float k_DefaultAirScatteringB = 3.3099997E-05f;

	private const float k_DefaultAirScaleHeight = 8000f;

	private const float k_DefaultAerosolScaleHeight = 1200f;

	private static readonly float k_DefaultAerosolMaximumAltitude = LayerDepthFromScaleHeight(1200f);

	private static readonly float k_DefaultOzoneMinimumAltitude = 20000f;

	private static readonly float k_DefaultOzoneLayerWidth = 20000f;

	[Tooltip("Indicates a preset URP uses to simplify the Inspector.")]
	public PhysicallyBasedSkyModelParameter type = new PhysicallyBasedSkyModelParameter(PhysicallyBasedSkyModel.EarthAdvanced);

	[Tooltip("Enables atmospheric attenuation on opaque objects when viewed from a distance. This is responsible for the blue tint on distant montains or clouds.")]
	public BoolParameter atmosphericScattering = new BoolParameter(value: true);

	[Tooltip("Controls the red color channel opacity of air at the point in the sky directly above the observer (zenith).")]
	public ClampedFloatParameter airDensityR = new ClampedFloatParameter(ZenithOpacityFromExtinctionAndScaleHeight(5.8E-06f, 8000f), 0f, 1f);

	[Tooltip("Controls the green color channel opacity of air at the point in the sky directly above the observer (zenith).")]
	public ClampedFloatParameter airDensityG = new ClampedFloatParameter(ZenithOpacityFromExtinctionAndScaleHeight(1.35E-05f, 8000f), 0f, 1f);

	[Tooltip("Controls the blue color channel opacity of air at the point in the sky directly above the observer (zenith).")]
	public ClampedFloatParameter airDensityB = new ClampedFloatParameter(ZenithOpacityFromExtinctionAndScaleHeight(3.3099997E-05f, 8000f), 0f, 1f);

	[Tooltip("Specifies the color that URP tints the air to. This controls the single scattering albedo of air molecules (per color channel). A value of 0 results in absorbing molecules, and a value of 1 results in scattering ones.")]
	public ColorParameter airTint = new ColorParameter(Color.white, hdr: false, showAlpha: false, showEyeDropper: true);

	[Tooltip("Sets the depth, in meters, of the atmospheric layer, from sea level, composed of air particles. Controls the rate of height-based density falloff.")]
	public MinFloatParameter airMaximumAltitude = new MinFloatParameter(LayerDepthFromScaleHeight(8000f), 0f);

	[Tooltip("Controls the opacity of aerosols at the point in the sky directly above the observer (zenith).")]
	public ClampedFloatParameter aerosolDensity = new ClampedFloatParameter(ZenithOpacityFromExtinctionAndScaleHeight(1E-05f, 1200f), 0f, 1f);

	[Tooltip("Specifies the color that URP tints aerosols to. This controls the single scattering albedo of aerosol molecules (per color channel). A value of 0 results in absorbing molecules, and a value of 1 results in scattering ones.")]
	public ColorParameter aerosolTint = new ColorParameter(new Color(0.9f, 0.9f, 0.9f), hdr: false, showAlpha: false, showEyeDropper: true);

	[Tooltip("Sets the depth, in meters, of the atmospheric layer, from sea level, composed of aerosol particles. Controls the rate of height-based density falloff.")]
	public MinFloatParameter aerosolMaximumAltitude = new MinFloatParameter(k_DefaultAerosolMaximumAltitude, 0f);

	[Tooltip("Controls the direction of anisotropy. Set this to a positive value for forward scattering, a negative value for backward scattering, or 0 for isotropic scattering.")]
	public ClampedFloatParameter aerosolAnisotropy = new ClampedFloatParameter(0.8f, -1f, 1f);

	[Tooltip("Controls the ozone density in the atmosphere.")]
	public ClampedFloatParameter ozoneDensityDimmer = new ClampedFloatParameter(1f, 0f, 1f);

	[Tooltip("Controls the minimum altitude of ozone in the atmosphere.")]
	public MinFloatParameter ozoneMinimumAltitude = new MinFloatParameter(k_DefaultOzoneMinimumAltitude, 0f);

	[Tooltip("Controls the width of the ozone layer in the atmosphere.")]
	public MinFloatParameter ozoneLayerWidth = new MinFloatParameter(k_DefaultOzoneLayerWidth, 0f);

	[Tooltip("Specifies a color that URP uses to tint the Ground Color Texture.")]
	public ColorParameter groundTint = new ColorParameter(new Color(0.12f, 0.1f, 0.09f), hdr: false, showAlpha: false, showEyeDropper: false);

	[Tooltip("Specifies a Texture that represents the planet's surface. Does not affect the precomputation.")]
	public CubemapParameter groundColorTexture = new CubemapParameter(null);

	[Tooltip("Specifies a Texture that represents the emissive areas of the planet's surface. Does not affect the precomputation.")]
	public CubemapParameter groundEmissionTexture = new CubemapParameter(null);

	[Tooltip("Sets the multiplier that URP applies to the Ground Emission Texture. Does not affect the precomputation.")]
	public MinFloatParameter groundEmissionMultiplier = new MinFloatParameter(1f, 0f);

	[Tooltip("Sets the orientation of the planet. Does not affect the precomputation.")]
	public Vector3Parameter planetRotation = new Vector3Parameter(Vector3.zero);

	[Tooltip("Specifies a Texture that represents the emissive areas of space. Does not affect the precomputation.")]
	public CubemapParameter spaceEmissionTexture = new CubemapParameter(null);

	[Tooltip("Sets the multiplier that URP applies to the Space Emission Texture. Does not affect the precomputation.")]
	public MinFloatParameter spaceEmissionMultiplier = new MinFloatParameter(1f, 0f);

	[Tooltip("Sets the orientation of space. Does not affect the precomputation.")]
	public Vector3Parameter spaceRotation = new Vector3Parameter(Vector3.zero);

	[Tooltip("Controls the saturation of the sky color. Does not affect the precomputation.")]
	public ClampedFloatParameter colorSaturation = new ClampedFloatParameter(1f, 0f, 1f);

	[Tooltip("Controls the saturation of the sky opacity. Does not affect the precomputation.")]
	public ClampedFloatParameter alphaSaturation = new ClampedFloatParameter(1f, 0f, 1f);

	[Tooltip("Sets the multiplier that URP applies to the opacity of the sky. Does not affect the precomputation.")]
	public ClampedFloatParameter alphaMultiplier = new ClampedFloatParameter(1f, 0f, 1f);

	[Tooltip("Specifies a color that URP uses to tint the sky at the horizon. Does not affect the precomputation.")]
	public ColorParameter horizonTint = new ColorParameter(Color.white, hdr: false, showAlpha: false, showEyeDropper: true);

	[Tooltip("Specifies a color that URP uses to tint the point in the sky directly above the observer (the zenith). Does not affect the precomputation.")]
	public ColorParameter zenithTint = new ColorParameter(Color.white, hdr: false, showAlpha: false, showEyeDropper: true);

	[Tooltip("Controls how URP blends between the Horizon Tint and Zenith Tint. Does not affect the precomputation.")]
	public ClampedFloatParameter horizonZenithShift = new ClampedFloatParameter(0f, -1f, 1f);

	[Tooltip("Specifies the intensity mode URP uses for the sky.")]
	public SkyIntensityParameter skyIntensityMode = new SkyIntensityParameter(SkyIntensityMode.Exposure);

	[Tooltip("Sets the exposure of the sky in EV.")]
	public FloatParameter exposure = new FloatParameter(0f);

	[Tooltip("Sets the intensity multiplier for the sky.")]
	public MinFloatParameter multiplier = new MinFloatParameter(1f, 0f);

	[Tooltip("Informative helper that displays the relative intensity (in Lux) for the current HDR texture set in HDRI Sky.")]
	public MinFloatParameter upperHemisphereLuxValue = new MinFloatParameter(1f, 0f);

	[Tooltip("Informative helper that displays Show the color of Shadow.")]
	public Vector3Parameter upperHemisphereLuxColor = new Vector3Parameter(new Vector3(0f, 0f, 0f));

	[Tooltip("Sets the absolute intensity (in Lux) of the current HDR texture set in HDRI Sky. Functions as a Lux intensity multiplier for the sky.")]
	public FloatParameter desiredLuxValue = new FloatParameter(20000f);

	[Tooltip("Specifies when URP updates the environment lighting. When set to OnDemand, use HDRenderPipeline.RequestSkyEnvironmentUpdate() to request an update.")]
	public EnvUpdateParameter updateMode = new EnvUpdateParameter(EnvironmentUpdateMode.OnChanged);

	[Tooltip("Sets the period, in seconds, at which URP updates the environment ligting (0 means URP updates it every frame).")]
	public MinFloatParameter updatePeriod = new MinFloatParameter(0f, 0f);

	[Tooltip("When enabled, URP uses the Sun Disk in baked lighting.")]
	public BoolParameter includeSunInBaking = new BoolParameter(value: false);

	public bool IsActive()
	{
		return active;
	}

	public static float ScaleHeightFromLayerDepth(float d)
	{
		return d * 0.144765f;
	}

	public static float LayerDepthFromScaleHeight(float H)
	{
		return H / 0.144765f;
	}

	public static float ExtinctionFromZenithOpacityAndScaleHeight(float alpha, float H)
	{
		float num = Mathf.Min(alpha, 0.999999f);
		return (0f - Mathf.Log(1f - num, MathF.E)) / H;
	}

	public static float ZenithOpacityFromExtinctionAndScaleHeight(float ext, float H)
	{
		float num = ext * H;
		return 1f - Mathf.Exp(0f - num);
	}

	private static float GetPlanetaryRadius()
	{
		return 6378100f;
	}

	private static Vector3 GetPlanetaryCenter()
	{
		return new Vector3(0f, 0f - GetPlanetaryRadius(), 0f);
	}

	public float GetAirScaleHeight()
	{
		if (type.value != PhysicallyBasedSkyModel.Custom)
		{
			return 8000f;
		}
		return ScaleHeightFromLayerDepth(airMaximumAltitude.value);
	}

	public float GetMaximumAltitude()
	{
		if (type.value == PhysicallyBasedSkyModel.Custom)
		{
			return Mathf.Max(airMaximumAltitude.value, aerosolMaximumAltitude.value);
		}
		float b = ((type.value == PhysicallyBasedSkyModel.EarthSimple) ? k_DefaultAerosolMaximumAltitude : aerosolMaximumAltitude.value);
		return Mathf.Max(LayerDepthFromScaleHeight(8000f), b);
	}

	public Vector3 GetAirExtinctionCoefficient()
	{
		Vector3 result = default(Vector3);
		if (type.value != PhysicallyBasedSkyModel.Custom)
		{
			result.x = 5.8E-06f;
			result.y = 1.35E-05f;
			result.z = 3.3099997E-05f;
		}
		else
		{
			result.x = ExtinctionFromZenithOpacityAndScaleHeight(airDensityR.value, GetAirScaleHeight());
			result.y = ExtinctionFromZenithOpacityAndScaleHeight(airDensityG.value, GetAirScaleHeight());
			result.z = ExtinctionFromZenithOpacityAndScaleHeight(airDensityB.value, GetAirScaleHeight());
		}
		return result;
	}

	public Vector3 GetAirAlbedo()
	{
		Vector3 one = Vector3.one;
		if (type.value == PhysicallyBasedSkyModel.Custom)
		{
			one.x = airTint.value.r;
			one.y = airTint.value.g;
			one.z = airTint.value.b;
		}
		return one;
	}

	public Vector3 GetAirScatteringCoefficient()
	{
		Vector3 airExtinctionCoefficient = GetAirExtinctionCoefficient();
		Vector3 airAlbedo = GetAirAlbedo();
		return new Vector3(airExtinctionCoefficient.x * airAlbedo.x, airExtinctionCoefficient.y * airAlbedo.y, airExtinctionCoefficient.z * airAlbedo.z);
	}

	public float GetAerosolScaleHeight()
	{
		if (type.value == PhysicallyBasedSkyModel.EarthSimple)
		{
			return 1200f;
		}
		return ScaleHeightFromLayerDepth(aerosolMaximumAltitude.value);
	}

	public float GetAerosolExtinctionCoefficient()
	{
		return ExtinctionFromZenithOpacityAndScaleHeight(aerosolDensity.value, GetAerosolScaleHeight());
	}

	public Vector3 GetAerosolScatteringCoefficient()
	{
		float aerosolExtinctionCoefficient = GetAerosolExtinctionCoefficient();
		return new Vector3(aerosolExtinctionCoefficient * aerosolTint.value.r, aerosolExtinctionCoefficient * aerosolTint.value.g, aerosolExtinctionCoefficient * aerosolTint.value.b);
	}

	public Vector3 GetOzoneExtinctionCoefficient()
	{
		Vector3 result = new Vector3(0.00065f, 0.00188f, 8E-05f) / 1000f;
		if (type.value != PhysicallyBasedSkyModel.EarthSimple)
		{
			result *= ozoneDensityDimmer.value;
		}
		return result;
	}

	public float GetOzoneLayerWidth()
	{
		if (type.value == PhysicallyBasedSkyModel.Custom)
		{
			return ozoneLayerWidth.value;
		}
		return k_DefaultOzoneLayerWidth;
	}

	public float GetOzoneLayerMinimumAltitude()
	{
		if (type.value == PhysicallyBasedSkyModel.Custom)
		{
			return ozoneMinimumAltitude.value;
		}
		return k_DefaultOzoneMinimumAltitude;
	}

	public float GetIntensityFromSettings()
	{
		float num = 1f;
		switch (skyIntensityMode.value)
		{
		case SkyIntensityMode.Exposure:
			num *= ColorUtils.ConvertEV100ToExposure(0f - exposure.value);
			break;
		case SkyIntensityMode.Multiplier:
			num *= multiplier.value;
			break;
		case SkyIntensityMode.Lux:
			num *= desiredLuxValue.value / Mathf.Max(upperHemisphereLuxValue.value, 1E-05f);
			break;
		}
		return num;
	}

	public int GetPrecomputationHashCode()
	{
		return ((((((((((((((base.GetHashCode() * 23 + type.GetHashCode()) * 23 + atmosphericScattering.GetHashCode()) * 23 + groundTint.GetHashCode()) * 23 + airMaximumAltitude.GetHashCode()) * 23 + airDensityR.GetHashCode()) * 23 + airDensityG.GetHashCode()) * 23 + airDensityB.GetHashCode()) * 23 + airTint.GetHashCode()) * 23 + aerosolMaximumAltitude.GetHashCode()) * 23 + aerosolDensity.GetHashCode()) * 23 + aerosolTint.GetHashCode()) * 23 + aerosolAnisotropy.GetHashCode()) * 23 + ozoneDensityDimmer.GetHashCode()) * 23 + ozoneMinimumAltitude.GetHashCode()) * 23 + ozoneLayerWidth.GetHashCode();
	}

	public override int GetHashCode()
	{
		int precomputationHashCode = GetPrecomputationHashCode();
		precomputationHashCode = precomputationHashCode * 23 + planetRotation.GetHashCode();
		if (groundColorTexture.value != null)
		{
			precomputationHashCode = precomputationHashCode * 23 + groundColorTexture.GetHashCode();
		}
		if (groundEmissionTexture.value != null)
		{
			precomputationHashCode = precomputationHashCode * 23 + groundEmissionTexture.GetHashCode();
		}
		precomputationHashCode = precomputationHashCode * 23 + groundEmissionMultiplier.GetHashCode();
		precomputationHashCode = precomputationHashCode * 23 + spaceRotation.GetHashCode();
		if (spaceEmissionTexture.value != null)
		{
			precomputationHashCode = precomputationHashCode * 23 + spaceEmissionTexture.GetHashCode();
		}
		precomputationHashCode = precomputationHashCode * 23 + spaceEmissionMultiplier.GetHashCode();
		precomputationHashCode = precomputationHashCode * 23 + colorSaturation.GetHashCode();
		precomputationHashCode = precomputationHashCode * 23 + alphaSaturation.GetHashCode();
		precomputationHashCode = precomputationHashCode * 23 + alphaMultiplier.GetHashCode();
		precomputationHashCode = precomputationHashCode * 23 + horizonTint.GetHashCode();
		precomputationHashCode = precomputationHashCode * 23 + zenithTint.GetHashCode();
		return precomputationHashCode * 23 + horizonZenithShift.GetHashCode();
	}

	private static float Saturate(float x)
	{
		return Mathf.Max(0f, Mathf.Min(x, 1f));
	}

	private static float Rcp(float x)
	{
		return 1f / x;
	}

	private static float Rsqrt(float x)
	{
		return Rcp(Mathf.Sqrt(x));
	}

	public static float ComputeCosineOfHorizonAngle(float r, float R)
	{
		float num = R * Rcp(r);
		return 0f - Mathf.Sqrt(Saturate(1f - num * num));
	}

	public static float ChapmanUpperApprox(float z, float cosTheta)
	{
		float num = 0.761643f * (1f + 2f * z - cosTheta * cosTheta * z);
		float x = cosTheta * z + Mathf.Sqrt(z * (1.47721f + 0.273828f * (cosTheta * cosTheta * z)));
		return 0.5f * cosTheta + num * Rcp(x);
	}

	public static float ChapmanHorizontal(float z)
	{
		float num = Rsqrt(z);
		float num2 = z * num;
		return 0.626657f * (num + 2f * num2);
	}

	public static float OzoneDensity(float height, Vector2 ozoneScaleOffset)
	{
		return Mathf.Clamp01(1f - Mathf.Abs(height * ozoneScaleOffset.x + ozoneScaleOffset.y));
	}

	public static Vector2 IntersectSphere(float sphereRadius, float cosChi, float radialDistance, float rcpRadialDistance)
	{
		float num = Mathf.Pow(sphereRadius * rcpRadialDistance, 2f) - Mathf.Clamp01(1f - cosChi * cosChi);
		if (!(num < 0f))
		{
			return radialDistance * new Vector2(0f - cosChi - Mathf.Sqrt(num), 0f - cosChi + Mathf.Sqrt(num));
		}
		return new Vector2(num, num);
	}

	public static float ComputeOzoneOpticalDepth(float R, float r, float cosTheta, float ozoneMinimumAltitude, float ozoneLayerWidth)
	{
		float num = 0f;
		Vector2 vector = IntersectSphere(R + ozoneMinimumAltitude, cosTheta, r, 1f / r);
		Vector2 vector2 = IntersectSphere(R + ozoneMinimumAltitude + ozoneLayerWidth, cosTheta, r, 1f / r);
		float num2;
		float num3;
		float num4;
		float num5;
		if ((double)vector.x < 0.0 && (double)vector.y >= 0.0)
		{
			num2 = vector.y;
			num3 = vector2.y;
			num4 = (num5 = (num3 - num2) * 0.5f);
		}
		else
		{
			num2 = Mathf.Max(vector2.x, 0f);
			num5 = (((double)vector.x >= 0.0) ? vector.x : vector2.y);
			if ((double)vector.x >= 0.0)
			{
				num4 = vector.y;
				num3 = vector2.y;
			}
			else
			{
				num3 = num5;
				num4 = (num5 = (num3 - num2) * 0.5f);
			}
		}
		uint num6 = 2u;
		float num7 = 1f / (float)num6;
		float num8 = (num5 - num2) * num7;
		float num9 = (num3 - num4) * num7;
		Vector2 ozoneScaleOffset = new Vector2(2f / ozoneLayerWidth, -2f * ozoneMinimumAltitude / ozoneLayerWidth - 1f);
		for (uint num10 = 0u; num10 < num6; num10++)
		{
			float num11 = Mathf.Lerp(num2, num5, ((float)num10 + 0.5f) * num7);
			float num12 = Mathf.Lerp(num4, num3, ((float)num10 + 0.5f) * num7);
			float height = Mathf.Sqrt(r * r + num11 * (2f * r * cosTheta + num11)) - R;
			float height2 = Mathf.Sqrt(r * r + num12 * (2f * r * cosTheta + num12)) - R;
			num += OzoneDensity(height, ozoneScaleOffset) * num8;
			num += OzoneDensity(height2, ozoneScaleOffset) * num9;
		}
		return num * 0.6f;
	}

	public static Vector3 ComputeAtmosphericOpticalDepth(float airScaleHeight, float aerosolScaleHeight, in Vector3 airExtinctionCoefficient, float aerosolExtinctionCoefficient, float ozoneMinimumAltitude, float ozoneLayerWidth, Vector3 ozoneExtinctionCoefficient, float R, float r, float cosTheta, bool alwaysAboveHorizon = false)
	{
		Vector2 vector = new Vector2(airScaleHeight, aerosolScaleHeight);
		Vector2 vector2 = new Vector2(Rcp(vector.x), Rcp(vector.y));
		Vector2 vector3 = r * vector2;
		Vector2 vector4 = R * vector2;
		float num = ComputeCosineOfHorizonAngle(r, R);
		float num2 = Mathf.Sqrt(Saturate(1f - cosTheta * cosTheta));
		Vector2 vector5 = default(Vector2);
		vector5.x = ChapmanUpperApprox(vector3.x, Mathf.Abs(cosTheta)) * Mathf.Exp(vector4.x - vector3.x);
		vector5.y = ChapmanUpperApprox(vector3.y, Mathf.Abs(cosTheta)) * Mathf.Exp(vector4.y - vector3.y);
		if (!alwaysAboveHorizon && cosTheta < num)
		{
			float num3 = r / R * num2;
			float cosTheta2 = Mathf.Sqrt(Saturate(1f - num3 * num3));
			Vector2 vector6 = default(Vector2);
			vector6.x = ChapmanUpperApprox(vector4.x, cosTheta2);
			vector6.y = ChapmanUpperApprox(vector4.y, cosTheta2);
			vector5 = vector6 - vector5;
		}
		else if (cosTheta < 0f)
		{
			Vector2 vector7 = vector3 * num2;
			Vector2 vector8 = new Vector2(Mathf.Exp(vector4.x - vector7.x), Mathf.Exp(vector4.x - vector7.x));
			Vector2 vector9 = default(Vector2);
			vector9.x = 2f * ChapmanHorizontal(vector7.x);
			vector9.y = 2f * ChapmanHorizontal(vector7.y);
			vector5 = vector9 * vector8 - vector5;
		}
		Vector2 vector10 = vector5 * vector;
		float num4 = (alwaysAboveHorizon ? ComputeOzoneOpticalDepth(R, r, cosTheta, ozoneMinimumAltitude, ozoneLayerWidth) : 0f);
		Vector3 vector11 = airExtinctionCoefficient;
		Vector3 vector12 = ozoneExtinctionCoefficient;
		return new Vector3(vector10.x * vector11.x + vector10.y * aerosolExtinctionCoefficient + num4 * vector12.x, vector10.x * vector11.y + vector10.y * aerosolExtinctionCoefficient + num4 * vector12.y, vector10.x * vector11.z + vector10.y * aerosolExtinctionCoefficient + num4 * vector12.z);
	}

	public static Vector3 EvaluateAtmosphericAttenuation(float airScaleHeight, float aerosolScaleHeight, in Vector3 airExtinctionCoefficient, float aerosolExtinctionCoefficient, float ozoneMinimumAltitude, float ozoneLayerWidth, Vector3 ozoneExtinctionCoefficient, in Vector3 C, float R, in Vector3 L, in Vector3 X)
	{
		float num = Vector3.Distance(X, C);
		float num2 = ComputeCosineOfHorizonAngle(num, R);
		float num3 = Vector3.Dot(X - C, L) * Rcp(num);
		if (num3 > num2)
		{
			Vector3 vector = ComputeAtmosphericOpticalDepth(airScaleHeight, aerosolScaleHeight, in airExtinctionCoefficient, aerosolExtinctionCoefficient, ozoneMinimumAltitude, ozoneLayerWidth, ozoneExtinctionCoefficient, R, num, num3, alwaysAboveHorizon: true);
			Vector3 result = default(Vector3);
			result.x = Mathf.Exp(0f - vector.x);
			result.y = Mathf.Exp(0f - vector.y);
			result.z = Mathf.Exp(0f - vector.z);
			return result;
		}
		return Vector3.zero;
	}

	private float3 AirScatter(float height)
	{
		return GetAirScatteringCoefficient() * math.exp((0f - height) * math.rcp(GetAirScaleHeight()));
	}

	private static float AirPhase(float LdotV)
	{
		return RayleighPhaseFunction(0f - LdotV);
	}

	private float3 AerosolScatter(float height)
	{
		return GetAerosolScatteringCoefficient() * math.exp((0f - height) * math.rcp(GetAerosolScaleHeight()));
	}

	private float AerosolPhase(float LdotV)
	{
		return CornetteShanksPhasePartConstant(aerosolAnisotropy.value) * CornetteShanksPhasePartVarying(aerosolAnisotropy.value, 0f - LdotV);
	}

	private float OzoneDensity(float height)
	{
		float2 float5 = math.float2(2f / GetOzoneLayerWidth(), -2f * GetOzoneLayerMinimumAltitude() / GetOzoneLayerWidth() - 1f);
		return math.saturate(1f - math.abs(height * float5.x + float5.y));
	}

	private float ComputeOzoneOpticalDepth(float r, float cosTheta, float distAlongRay)
	{
		float num = PlanetaryRadius();
		float rcpRadialDistance = math.rcp(num);
		float2 float5 = IntersectSphere(num + GetOzoneLayerMinimumAltitude(), cosTheta, r, rcpRadialDistance);
		float2 float6 = IntersectSphere(num + GetOzoneLayerMinimumAltitude() + GetOzoneLayerWidth(), cosTheta, r, rcpRadialDistance);
		float num2;
		float num4;
		float num5;
		float num3;
		if ((double)float5.x < 0.0 && (double)float5.y >= 0.0)
		{
			num2 = float5.y;
			num3 = float6.y;
			num4 = (num5 = (num3 - num2) * 0.5f);
		}
		else
		{
			num2 = math.max(float6.x, 0f);
			num5 = (((double)float5.x >= 0.0) ? float5.x : float6.y);
			if ((double)float5.x >= 0.0 && distAlongRay > float5.y)
			{
				num4 = float5.y;
				num3 = float6.y;
			}
			else
			{
				num3 = num5;
				num4 = (num5 = (num3 - num2) * 0.5f);
			}
		}
		num5 = math.min(num5, distAlongRay);
		num3 = math.min(num3, distAlongRay);
		float num6 = 0f;
		float num7 = math.max(num5 - num2, 0f) * math.rcp(2f);
		float num8 = math.max(num3 - num4, 0f) * math.rcp(2f);
		for (uint num9 = 0u; num9 < 2; num9++)
		{
			float num10 = math.lerp(num2, num5, ((float)num9 + 0.5f) * math.rcp(2f));
			float num11 = math.lerp(num4, num3, ((float)num9 + 0.5f) * math.rcp(2f));
			float height = math.sqrt(r * r + num10 * (2f * r * cosTheta + num10)) - num;
			float height2 = math.sqrt(r * r + num11 * (2f * r * cosTheta + num11)) - num;
			num6 += OzoneDensity(height) * num7;
			num6 += OzoneDensity(height2) * num8;
		}
		return num6 * 0.6f;
	}

	private float3 ComputeAtmosphericOpticalDepth(float r, float cosTheta, bool aboveHorizon)
	{
		float2 obj = math.float2(math.rcp(GetAirScaleHeight()), math.rcp(GetAerosolScaleHeight()));
		float2 float5 = math.float2(GetAirScaleHeight(), GetAerosolScaleHeight());
		float num = PlanetaryRadius();
		float2 float6 = obj * r;
		float2 float7 = obj * num;
		float num2 = math.sqrt(math.saturate(1f - cosTheta * cosTheta));
		float2 float8 = default(float2);
		float8.x = ChapmanUpperApprox(float6.x, math.abs(cosTheta)) * math.exp(float7.x - float6.x);
		float8.y = ChapmanUpperApprox(float6.y, math.abs(cosTheta)) * math.exp(float7.y - float6.y);
		if (!aboveHorizon)
		{
			float num3 = r / num * num2;
			float cosTheta2 = math.sqrt(math.saturate(1f - num3 * num3));
			float2 float9 = default(float2);
			float9.x = ChapmanUpperApprox(float7.x, cosTheta2);
			float9.y = ChapmanUpperApprox(float7.y, cosTheta2);
			float8 = float9 - float8;
		}
		else if (cosTheta < 0f)
		{
			float2 float10 = float6 * num2;
			float2 float11 = math.exp(float7 - float10);
			float2 float12 = default(float2);
			float12.x = 2f * ChapmanHorizontal(float10.x);
			float12.y = 2f * ChapmanHorizontal(float10.y);
			float8 = float12 * float11 - float8;
		}
		float z = (aboveHorizon ? ComputeOzoneOpticalDepth(r, cosTheta, float.MaxValue) : 0f);
		float3 float13 = math.float3(float8 * float5, z);
		return float13.x * math.float3(GetAirExtinctionCoefficient()) + float13.y * GetAerosolExtinctionCoefficient() + float13.z * math.float3(GetOzoneExtinctionCoefficient());
	}

	private static float RayleighPhaseFunction(float cosTheta)
	{
		return 3f / (16f * MathF.PI) * (1f + cosTheta * cosTheta);
	}

	private static float CornetteShanksPhasePartSymmetrical(float cosTheta)
	{
		return 1f + cosTheta * cosTheta;
	}

	private static float CornetteShanksPhasePartAsymmetrical(float anisotropy, float cosTheta)
	{
		float num = math.rsqrt(math.max(1f + anisotropy * anisotropy - 2f * anisotropy * cosTheta, 1.1920929E-07f));
		return num * num * num;
	}

	private static float CornetteShanksPhasePartVarying(float anisotropy, float cosTheta)
	{
		return CornetteShanksPhasePartSymmetrical(cosTheta) * CornetteShanksPhasePartAsymmetrical(anisotropy, cosTheta);
	}

	private static float CornetteShanksPhasePartConstant(float anisotropy)
	{
		return 3f / (8f * MathF.PI) * (1f - anisotropy * anisotropy) / (2f + anisotropy * anisotropy);
	}

	private static float2 ComputeExponentialInterpolationParams(float k)
	{
		if (k == 0f)
		{
			k = 1E-06f;
		}
		float x = 10f * k;
		float y = 1f / (math.exp(x) - 1f);
		return math.float2(x, y);
	}

	private float3 IntegrateOverSegment(float3 S, float3 transmittanceOverSegment, float3 transmittance, float3 sigmaE)
	{
		float3 float5 = (S - S * transmittanceOverSegment) / sigmaE;
		return transmittance * float5;
	}

	private static void GetSample(uint s, uint sampleCount, float tExit, out float t, out float dt)
	{
		float num = (float)s / (float)sampleCount;
		float num2 = ((float)s + 1f) / (float)sampleCount;
		num = num * num * tExit;
		num2 = num2 * num2 * tExit;
		t = math.lerp(num, num2, 0.5f);
		dt = num2 - num;
	}

	private static float PlanetaryRadius()
	{
		return 6378100f;
	}

	private static float3 PlanetaryRadiusCenter()
	{
		return math.float3(0f, 0f - PlanetaryRadius(), 0f);
	}

	private float3 AtmosphereExtinction(float height)
	{
		float num = math.exp((0f - height) * math.rcp(GetAerosolScaleHeight()));
		float num2 = math.exp((0f - height) * math.rcp(GetAirScaleHeight()));
		float2 float5 = math.float2(2f / GetOzoneLayerWidth(), -2f * GetOzoneLayerMinimumAltitude() / GetOzoneLayerWidth() - 1f);
		float num3 = OzoneDensity(height, float5);
		return math.max(num * GetAerosolExtinctionCoefficient() + num2 * math.float3(GetAirExtinctionCoefficient()) + num3 * math.float3(GetOzoneExtinctionCoefficient()), 1.1754944E-38f);
	}

	private float3 TransmittanceFromOpticalDepth(float3 opticalDepth)
	{
		return math.exp(-opticalDepth);
	}

	private static float Avg3(float a, float b, float c)
	{
		return (a + b + c) * (1f / 3f);
	}

	private static float3 Desaturate(float3 value, float3 saturation)
	{
		float num = Avg3(value.x, value.y, value.z);
		float3 float5 = value - num;
		return num + float5 * saturation;
	}

	private float3 EvaluateSunColorAttenuation(float3 positionPS, float3 sunDirection, bool estimatePenumbra = false)
	{
		float x = math.length(positionPS);
		float num = math.dot(positionPS, sunDirection) * math.rcp(x);
		float num2 = PlanetaryRadius();
		x = math.max(x, num2);
		float num3 = ComputeCosineOfHorizonAngle(x, num2);
		if (num >= num3)
		{
			float3 opticalDepth = ComputeAtmosphericOpticalDepth(x, num, aboveHorizon: true);
			float3 value = 1f - TransmittanceFromOpticalDepth(opticalDepth);
			float num4 = math.saturate((num - num3) / 0.0019f);
			float3 float5 = 1f - Desaturate(value, alphaSaturation.value) * alphaMultiplier.value;
			if (!estimatePenumbra)
			{
				return float5;
			}
			return float5 * num4;
		}
		return 0;
	}

	private void EvaluateAtmosphericColor(float3 L, float3 lightColor, float3 O, float3 V, float tExit, out float3 skyColor, out float3 skyTransmittance)
	{
		skyColor = 0f;
		skyTransmittance = 1f;
		for (uint num = 0u; num < 4; num++)
		{
			GetSample(num, 4u, tExit, out var t, out var dt);
			float3 obj = O + t * V;
			float num2 = math.max(math.length(obj), PlanetaryRadius());
			float3 x = obj * math.rcp(num2);
			float height = num2 - PlanetaryRadius();
			float3 float5 = AtmosphereExtinction(height);
			float3 float6 = TransmittanceFromOpticalDepth(float5 * dt);
			float3 obj2 = EvaluateSunColorAttenuation(math.dot(x, L), num2);
			float3 float7 = AirScatter(height) * AirPhase(0f - math.dot(L, V)) + AerosolScatter(height) * AerosolPhase(0f - math.dot(L, V));
			float3 float8 = obj2 * float7;
			skyColor += IntegrateOverSegment(lightColor * float8, float6, skyTransmittance, float5);
			skyTransmittance *= float6;
		}
	}

	private float3 ExpLerp(float3 A, float3 B, float t, float x, float y)
	{
		t = math.exp(x * t) * y - y;
		return math.lerp(A, B, t);
	}

	private void AtmosphereArtisticOverride(float cosHor, float cosChi, ref float3 skyColor, ref float3 skyOpacity, bool precomputedColorDesaturate = false)
	{
		if (!precomputedColorDesaturate)
		{
			skyColor = Desaturate(skyColor, colorSaturation.value);
		}
		skyOpacity = Desaturate(skyOpacity, alphaSaturation.value) * alphaMultiplier.value;
		float srcStart = math.acos(cosHor);
		float x = math.acos(cosChi);
		float srcEnd = 0f;
		float t = math.remap(srcStart, srcEnd, 0f, 1f, x);
		float2 float5 = ComputeExponentialInterpolationParams(horizonZenithShift.value);
		skyColor *= ExpLerp(math.float3(horizonTint.value.r, horizonTint.value.g, horizonTint.value.b), math.float3(zenithTint.value.r, zenithTint.value.g, zenithTint.value.b), t, float5.x, float5.y);
	}

	public void RenderSky(float3 lightDirection, float3 lightColor, float3 viewDirection, out float3 skyColor, out float3 skyOpacity)
	{
		float num = ComputeCosineOfHorizonAngle(math.length(-PlanetaryRadiusCenter()), PlanetaryRadius());
		float y = viewDirection.y;
		bool num2 = y >= num;
		float3 opticalDepth = ComputeAtmosphericOpticalDepth(GetAirScaleHeight(), GetAerosolScaleHeight(), GetAirExtinctionCoefficient(), GetAerosolExtinctionCoefficient(), GetOzoneLayerMinimumAltitude(), GetOzoneLayerWidth(), GetOzoneExtinctionCoefficient(), PlanetaryRadius(), PlanetaryRadius(), y, alwaysAboveHorizon: true);
		skyOpacity = 1f - TransmittanceFromOpticalDepth(opticalDepth);
		float3 float5 = math.float3(0f, 1f, 0f);
		float num3 = PlanetaryRadius();
		float3 o = num3 * float5;
		if (num2)
		{
			float y2 = IntersectSphere(num3 + GetMaximumAltitude(), math.dot(float5, viewDirection), num3, math.rcp(num3)).y;
			EvaluateAtmosphericColor(lightDirection, lightColor, o, viewDirection, y2, out skyColor, out var _);
			AtmosphereArtisticOverride(num, y, ref skyColor, ref skyOpacity);
		}
		else
		{
			float3 float6 = math.rcp(MathF.PI) * math.float3(groundTint.value.r, groundTint.value.g, groundTint.value.b);
			skyColor = float6 * math.saturate(math.dot(float5, lightDirection)) * lightColor;
		}
		skyColor *= GetIntensityFromSettings();
	}
}
