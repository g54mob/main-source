using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
[RequireComponent(typeof(TOD_Resources))]
[RequireComponent(typeof(TOD_Components))]
public class TOD_Sky : MonoBehaviour
{
	private struct CelestialData
	{
		public float worldLatitude;

		public float worldLongitude;

		public float lst_rad;

		public float sun_zenith_rad;

		public float sun_altitude_rad;

		public float sun_azimuth_rad;

		public float moon_zenith_rad;

		public float moon_altitude_rad;

		public float moon_azimuth_rad;

		public float LocalSiderealTime;

		public float SunsetTime;

		public float SunriseTime;

		public float SunZenith;

		public float SunAltitude;

		public float SunAzimuth;

		public float MoonZenith;

		public float MoonAltitude;

		public float MoonAzimuth;

		public void LerpTo(CelestialData other, float f)
		{
			worldLatitude = Mathf.LerpAngle(worldLatitude, other.worldLatitude, f);
			worldLongitude = Mathf.LerpAngle(worldLongitude, other.worldLongitude, f);
			lst_rad = Mathf.LerpAngle(lst_rad * 57.29578f, other.lst_rad * 57.29578f, f) * ((float)Math.PI / 180f);
			sun_zenith_rad = Mathf.LerpAngle(sun_zenith_rad * 57.29578f, other.sun_zenith_rad * 57.29578f, f) * ((float)Math.PI / 180f);
			sun_altitude_rad = Mathf.LerpAngle(sun_altitude_rad * 57.29578f, other.sun_altitude_rad * 57.29578f, f) * ((float)Math.PI / 180f);
			sun_azimuth_rad = Mathf.LerpAngle(sun_azimuth_rad * 57.29578f, other.sun_azimuth_rad * 57.29578f, f) * ((float)Math.PI / 180f);
			moon_zenith_rad = Mathf.LerpAngle(moon_zenith_rad * 57.29578f, other.moon_zenith_rad * 57.29578f, f) * ((float)Math.PI / 180f);
			moon_altitude_rad = Mathf.LerpAngle(moon_altitude_rad * 57.29578f, other.moon_altitude_rad * 57.29578f, f) * ((float)Math.PI / 180f);
			moon_azimuth_rad = Mathf.LerpAngle(moon_azimuth_rad * 57.29578f, other.moon_azimuth_rad * 57.29578f, f) * ((float)Math.PI / 180f);
			LocalSiderealTime = Mathf.Lerp(LocalSiderealTime, other.LocalSiderealTime, f);
			SunsetTime = Mathf.Lerp(SunsetTime, other.SunsetTime, f);
			SunriseTime = Mathf.Lerp(SunriseTime, other.SunriseTime, f);
			SunZenith = Mathf.LerpAngle(SunZenith, other.SunZenith, f);
			SunAltitude = Mathf.LerpAngle(SunAltitude, other.SunAltitude, f);
			SunAzimuth = Mathf.LerpAngle(SunAzimuth, other.SunAzimuth, f);
			MoonZenith = Mathf.LerpAngle(MoonZenith, other.MoonZenith, f);
			MoonAltitude = Mathf.LerpAngle(MoonAltitude, other.MoonAltitude, f);
			MoonAzimuth = Mathf.LerpAngle(MoonAzimuth, other.MoonAzimuth, f);
		}
	}

	private struct CelestialPositions
	{
		public Quaternion spaceRot;

		public Vector3 sunPos;

		public float sunMultiplier;

		public Vector3 moonPos;

		public float moonMultiplier;

		public float sunSize;

		public Vector3 sunScale;

		public float moonSize;

		public Vector3 moonScale;

		public void LerpTo(CelestialPositions other, float f)
		{
			spaceRot = Quaternion.Slerp(spaceRot, other.spaceRot, f);
			sunPos = Vector3.Lerp(sunPos, other.sunPos, f);
			sunMultiplier = Mathf.Lerp(sunMultiplier, other.sunMultiplier, f);
			moonPos = Vector3.Lerp(moonPos, other.moonPos, f);
			moonMultiplier = Mathf.Lerp(moonMultiplier, other.moonMultiplier, f);
			sunSize = Mathf.Lerp(sunSize, other.sunSize, f);
			sunScale = Vector3.Lerp(sunScale, other.sunScale, f);
			moonSize = Mathf.Lerp(moonSize, other.moonSize, f);
			moonScale = Vector3.Lerp(moonScale, other.moonScale, f);
		}
	}

	private struct ColorData
	{
		public float LerpValue;

		public float SunVisibility;

		public float MoonVisibility;

		public Color SunLightColor;

		public Color MoonLightColor;

		public Color SunRayColor;

		public Color MoonRayColor;

		public Color SunSkyColor;

		public Color MoonSkyColor;

		public Color SunMeshColor;

		public Color MoonMeshColor;

		public Color SunCloudColor;

		public Color MoonCloudColor;

		public Color FogColor;

		public Color AmbientColor;

		public Color GroundColor;

		public Color MoonHaloColor;

		public float lightIntensity;

		public float lightShadowStrength;

		public Color lightColor;

		public bool IsDay;

		public bool IsNight;

		public Vector3 lightPosition;
	}

	private const float SkySquish = 0.15f;

	private static List<TOD_Sky> instances = new List<TOD_Sky>();

	private int probeRenderID = -1;

	[Tooltip("Auto: Use the player settings.\nLinear: Force linear color space.\nGamma: Force gamma color space.")]
	public TOD_ColorSpaceType ColorSpace;

	[Tooltip("Auto: Use the camera settings.\nHDR: Force high dynamic range.\nLDR: Force low dynamic range.")]
	public TOD_ColorRangeType ColorRange;

	[Tooltip("Raw: Write color without modifications.\nDithered: Add dithering to reduce banding.")]
	public TOD_ColorOutputType ColorOutput = TOD_ColorOutputType.Dithered;

	[Tooltip("Per Vertex: Calculate sky color per vertex.\nPer Pixel: Calculate sky color per pixel.")]
	public TOD_SkyQualityType SkyQuality;

	[Tooltip("Low: Only recommended for very old mobile devices.\nMedium: Simplified cloud shading.\nHigh: Physically based cloud shading.")]
	public TOD_CloudQualityType CloudQuality = TOD_CloudQualityType.High;

	[Tooltip("Low: Only recommended for very old mobile devices.\nMedium: Simplified mesh geometry.\nHigh: Detailed mesh geometry.")]
	public TOD_MeshQualityType MeshQuality = TOD_MeshQualityType.High;

	[Tooltip("Low: Recommended for most mobile devices.\nMedium: Includes most visible stars.\nHigh: Includes all visible stars.")]
	public TOD_StarQualityType StarQuality = TOD_StarQualityType.High;

	[Tooltip("Take over updating the global skybox value (set to True if nothing else is doing its own thing with skybox)")]
	public bool UpdateSkybox;

	public TOD_CycleParameters Cycle;

	public TOD_WorldParameters World;

	public TOD_AtmosphereParameters Atmosphere;

	public TOD_DayParameters Day;

	public TOD_NightParameters Night;

	public TOD_SunParameters Sun;

	public TOD_MoonParameters Moon;

	public TOD_StarParameters Stars;

	public TOD_CloudParameters Clouds;

	public TOD_LightParameters Light;

	public TOD_FogParameters Fog;

	public TOD_AmbientParameters Ambient;

	public TOD_ReflectionParameters Reflection;

	[NonSerialized]
	public float MinLightAngleMove;

	public float SunAndMoonScale = 1f;

	private float timeSinceLightUpdate = float.MaxValue;

	private float timeSinceAmbientUpdate = float.MaxValue;

	private float timeSinceReflectionUpdate = float.MaxValue;

	private const int TOD_SAMPLES = 2;

	private Vector3 kBetaMie;

	private Vector4 kSun;

	private Vector4 k4PI;

	private Vector4 kRadius;

	private Vector4 kScale;

	private const float pi = (float)Math.PI;

	private const float tau = (float)Math.PI * 2f;

	public bool deferValueUpdates;

	[Header("Fixed date")]
	public bool useFixedDay;

	public int fixedDay = 21;

	public int fixedMonth = 7;

	public int fixedYear = 2016;

	[Header("Light tweaks")]
	public float intensityMultiplier = 1f;

	public float ambientMultiplier = 1f;

	public float skyMultiplier = 1f;

	[Header("Sky dome shape")]
	public float celestialShortening = 0.9f;

	public static List<TOD_Sky> Instances => instances;

	public static TOD_Sky Instance
	{
		get
		{
			if (instances.Count != 0)
			{
				return instances[instances.Count - 1];
			}
			return null;
		}
	}

	public bool Initialized { get; private set; }

	public bool Headless => Camera.allCamerasCount == 0;

	public TOD_Components Components { get; private set; }

	public TOD_Resources Resources { get; private set; }

	public bool IsDay { get; private set; }

	public bool IsNight { get; private set; }

	public float Radius => Components.DomeTransform.lossyScale.y;

	public float Diameter => Components.DomeTransform.lossyScale.y * 2f;

	public float LerpValue { get; private set; }

	public float SunZenith { get; private set; }

	public float SunAltitude { get; private set; }

	public float SunAzimuth { get; private set; }

	public float MoonZenith { get; private set; }

	public float MoonAltitude { get; private set; }

	public float MoonAzimuth { get; private set; }

	public float SunsetTime { get; private set; }

	public float SunriseTime { get; private set; }

	public float LocalSiderealTime { get; private set; }

	public float LightZenith => Mathf.Min(SunZenith, MoonZenith);

	public float LightIntensity => Components.LightSource.intensity;

	public float SunVisibility { get; private set; }

	public float MoonVisibility { get; private set; }

	public Vector3 SunDirection { get; private set; }

	public Vector3 MoonDirection { get; private set; }

	public Vector3 LightDirection { get; private set; }

	public Vector3 LocalSunDirection { get; private set; }

	public Vector3 LocalMoonDirection { get; private set; }

	public Vector3 LocalLightDirection { get; private set; }

	public Color SunLightColor { get; set; }

	public Color MoonLightColor { get; set; }

	public Color LightColor => Components.LightSource.color;

	public Color SunRayColor { get; set; }

	public Color MoonRayColor { get; set; }

	public Color SunSkyColor { get; set; }

	public Color MoonSkyColor { get; set; }

	public Color SunMeshColor { get; set; }

	public Color MoonMeshColor { get; set; }

	public Color SunCloudColor { get; set; }

	public Color MoonCloudColor { get; set; }

	public Color FogColor { get; set; }

	public Color GroundColor { get; set; }

	public Color AmbientColor { get; set; }

	public Color MoonHaloColor { get; set; }

	public ReflectionProbe Probe { get; private set; }

	public event Action UpdateScatteringValuesRequested;

	public event Action UpdateOtherValuesRequested;

	public static Vector3 OrbitalToUnity(float radius, float theta, float phi)
	{
		float num = Mathf.Sin(theta);
		float num2 = Mathf.Cos(theta);
		float num3 = Mathf.Sin(phi);
		float num4 = Mathf.Cos(phi);
		Vector3 result = default(Vector3);
		result.z = radius * num * num4;
		result.y = radius * num2;
		result.x = radius * num * num3;
		return result;
	}

	public static Vector3 OrbitalToLocal(float theta, float phi, out float scalingCorrection, float squish)
	{
		float num = Mathf.Sin(theta);
		float y = Mathf.Cos(theta);
		float num2 = Mathf.Sin(phi);
		float num3 = Mathf.Cos(phi);
		Vector3 result = default(Vector3);
		result.z = num * num3;
		result.y = y;
		result.x = num * num2;
		if (squish != 1f)
		{
			result.y /= 0.15f;
			result.Normalize();
			result.y *= 0.15f;
			result *= squish;
			scalingCorrection = result.magnitude;
		}
		else
		{
			scalingCorrection = 1f;
		}
		return result;
	}

	public Color SampleAtmosphere(Vector3 direction, bool directLight = true)
	{
		Vector3 dir = Components.DomeTransform.InverseTransformDirection(direction);
		Color color = ShaderScatteringColor(dir, directLight);
		color = TOD_HDR2LDR(color);
		return TOD_LINEAR2GAMMA(color);
	}

	public SphericalHarmonicsL2 RenderToSphericalHarmonics()
	{
		float saturation = Ambient.Saturation;
		float intensity = Mathf.Lerp(Night.AmbientMultiplier, Day.AmbientMultiplier, LerpValue);
		return RenderToSphericalHarmonics(intensity, saturation);
	}

	public SphericalHarmonicsL2 RenderToSphericalHarmonics(float intensity, float saturation)
	{
		SphericalHarmonicsL2 result = default(SphericalHarmonicsL2);
		bool directLight = false;
		Color color = TOD_Util.AdjustRGB(AmbientColor.linear, intensity, saturation);
		Vector3 vector = new Vector3(0.61237246f, 0.5f, 0.61237246f);
		Vector3 up = Vector3.up;
		Color color2 = TOD_Util.AdjustRGB(SampleAtmosphere(up, directLight).linear, intensity, saturation);
		result.AddDirectionalLight(up, color2, 0.42857143f);
		Vector3 direction = new Vector3(0f - vector.x, vector.y, 0f - vector.z);
		Color color3 = TOD_Util.AdjustRGB(SampleAtmosphere(direction, directLight).linear, intensity, saturation);
		result.AddDirectionalLight(direction, color3, 0.2857143f);
		Vector3 direction2 = new Vector3(vector.x, vector.y, 0f - vector.z);
		Color color4 = TOD_Util.AdjustRGB(SampleAtmosphere(direction2, directLight).linear, intensity, saturation);
		result.AddDirectionalLight(direction2, color4, 0.2857143f);
		Vector3 direction3 = new Vector3(0f - vector.x, vector.y, vector.z);
		Color color5 = TOD_Util.AdjustRGB(SampleAtmosphere(direction3, directLight).linear, intensity, saturation);
		result.AddDirectionalLight(direction3, color5, 0.2857143f);
		Vector3 direction4 = new Vector3(vector.x, vector.y, vector.z);
		Color color6 = TOD_Util.AdjustRGB(SampleAtmosphere(direction4, directLight).linear, intensity, saturation);
		result.AddDirectionalLight(direction4, color6, 0.2857143f);
		Vector3 left = Vector3.left;
		Color color7 = TOD_Util.AdjustRGB(SampleAtmosphere(left, directLight).linear, intensity, saturation);
		result.AddDirectionalLight(left, color7, 1f / 7f);
		Vector3 right = Vector3.right;
		Color color8 = TOD_Util.AdjustRGB(SampleAtmosphere(right, directLight).linear, intensity, saturation);
		result.AddDirectionalLight(right, color8, 1f / 7f);
		Vector3 back = Vector3.back;
		Color color9 = TOD_Util.AdjustRGB(SampleAtmosphere(back, directLight).linear, intensity, saturation);
		result.AddDirectionalLight(back, color9, 1f / 7f);
		Vector3 forward = Vector3.forward;
		Color color10 = TOD_Util.AdjustRGB(SampleAtmosphere(forward, directLight).linear, intensity, saturation);
		result.AddDirectionalLight(forward, color10, 1f / 7f);
		Vector3 direction5 = new Vector3(0f - vector.x, 0f - vector.y, 0f - vector.z);
		result.AddDirectionalLight(direction5, color, 0.2857143f);
		Vector3 direction6 = new Vector3(vector.x, 0f - vector.y, 0f - vector.z);
		result.AddDirectionalLight(direction6, color, 0.2857143f);
		Vector3 direction7 = new Vector3(0f - vector.x, 0f - vector.y, vector.z);
		result.AddDirectionalLight(direction7, color, 0.2857143f);
		Vector3 direction8 = new Vector3(vector.x, 0f - vector.y, vector.z);
		result.AddDirectionalLight(direction8, color, 0.2857143f);
		Vector3 down = Vector3.down;
		result.AddDirectionalLight(down, color, 0.42857143f);
		return result;
	}

	public void RenderToCubemap(RenderTexture targetTexture = null)
	{
		if (!Probe)
		{
			Probe = new GameObject().AddComponent<ReflectionProbe>();
			Probe.name = base.gameObject.name + " Reflection Probe";
			Probe.mode = ReflectionProbeMode.Realtime;
		}
		if (probeRenderID < 0 || Probe.IsFinishedRendering(probeRenderID))
		{
			float num = float.MaxValue;
			Probe.transform.position = Components.DomeTransform.position;
			Probe.size = new Vector3(num, num, num);
			Probe.intensity = RenderSettings.reflectionIntensity;
			Probe.clearFlags = Reflection.ClearFlags;
			Probe.cullingMask = Reflection.CullingMask;
			Probe.refreshMode = ReflectionProbeRefreshMode.ViaScripting;
			Probe.timeSlicingMode = Reflection.TimeSlicing;
			Probe.resolution = Mathf.ClosestPowerOfTwo(Reflection.Resolution);
			if (Components.Camera != null)
			{
				Probe.backgroundColor = Components.Camera.BackgroundColor;
				Probe.nearClipPlane = Components.Camera.NearClipPlane;
				Probe.farClipPlane = Components.Camera.FarClipPlane;
			}
			probeRenderID = Probe.RenderProbe(targetTexture);
		}
	}

	public Color SampleFogColor(bool directLight = true)
	{
		Vector3 vector = Vector3.forward;
		if (Components.Camera != null)
		{
			vector = Quaternion.Euler(0f, Components.Camera.transform.rotation.eulerAngles.y, 0f) * vector;
		}
		Color color = SampleAtmosphere(Vector3.Lerp(vector, Vector3.up, Fog.HeightBias).normalized, directLight);
		return new Color(color.r, color.g, color.b, 1f);
	}

	public Color SampleSkyColor()
	{
		Vector3 sunDirection = SunDirection;
		sunDirection.y = Mathf.Abs(sunDirection.y);
		Color color = SampleAtmosphere(sunDirection.normalized, directLight: false);
		return new Color(color.r, color.g, color.b, 1f);
	}

	public Color SampleEquatorColor()
	{
		Vector3 sunDirection = SunDirection;
		sunDirection.y = 0f;
		Color color = SampleAtmosphere(sunDirection.normalized, directLight: false);
		return new Color(color.r, color.g, color.b, 1f);
	}

	public void UpdateFog()
	{
		switch (Fog.Mode)
		{
		case TOD_FogType.Atmosphere:
			RenderSettings.fogColor = SampleFogColor(directLight: false) * skyMultiplier;
			break;
		case TOD_FogType.Directional:
			RenderSettings.fogColor = SampleFogColor() * skyMultiplier;
			break;
		case TOD_FogType.Gradient:
			RenderSettings.fogColor = FogColor * skyMultiplier;
			break;
		case TOD_FogType.None:
			break;
		}
	}

	public void UpdateAmbient()
	{
		float saturation = Ambient.Saturation;
		float num = Mathf.Lerp(Night.AmbientMultiplier, Day.AmbientMultiplier, LerpValue) * ambientMultiplier;
		float intensity = Mathf.Lerp(Night.SkyIntensity, Day.SkyIntensity, LerpValue) * skyMultiplier;
		float intensity2 = Mathf.Lerp(Night.EquatorIntensity, Day.EquatorIntensity, LerpValue) * skyMultiplier;
		float intensity3 = Mathf.Lerp(Night.GroundIntensity, Day.GroundIntensity, LerpValue) * ambientMultiplier;
		switch (Ambient.Mode)
		{
		case TOD_AmbientType.Color:
		{
			Color ambientLight2 = TOD_Util.AdjustRGB(AmbientColor, num, saturation);
			RenderSettings.ambientMode = AmbientMode.Flat;
			RenderSettings.ambientLight = ambientLight2;
			RenderSettings.ambientIntensity = num;
			break;
		}
		case TOD_AmbientType.Gradient:
		{
			Color ambientGroundColor = TOD_Util.AdjustRGB(AmbientColor, intensity3, saturation);
			Color ambientEquatorColor = TOD_Util.AdjustRGB(SampleEquatorColor(), intensity2, saturation);
			Color ambientSkyColor = TOD_Util.AdjustRGB(SampleSkyColor(), intensity, saturation);
			RenderSettings.ambientMode = AmbientMode.Trilight;
			RenderSettings.ambientSkyColor = ambientSkyColor;
			RenderSettings.ambientEquatorColor = ambientEquatorColor;
			RenderSettings.ambientGroundColor = ambientGroundColor;
			RenderSettings.ambientIntensity = num;
			break;
		}
		case TOD_AmbientType.Spherical:
		{
			Color ambientLight = TOD_Util.AdjustRGB(AmbientColor, num, saturation);
			RenderSettings.ambientMode = AmbientMode.Skybox;
			RenderSettings.ambientLight = ambientLight;
			RenderSettings.ambientIntensity = num;
			RenderSettings.ambientProbe = RenderToSphericalHarmonics(num, saturation);
			break;
		}
		}
	}

	public void UpdateReflection()
	{
		TOD_ReflectionType mode = Reflection.Mode;
		if (mode == TOD_ReflectionType.Cubemap)
		{
			float reflectionIntensity = Mathf.Lerp(Night.ReflectionMultiplier, Day.ReflectionMultiplier, LerpValue);
			RenderSettings.defaultReflectionMode = DefaultReflectionMode.Skybox;
			RenderSettings.reflectionIntensity = reflectionIntensity;
			if (Application.isPlaying)
			{
				RenderToCubemap();
			}
		}
	}

	public void LoadParameters(string xml)
	{
		using (StringReader input = new StringReader(xml))
		{
			using (XmlTextReader xmlReader = new XmlTextReader(input))
			{
				(new XmlSerializer(typeof(TOD_Parameters)).Deserialize(xmlReader) as TOD_Parameters).ToSky(this);
			}
		}
	}

	public string SaveParameters()
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (StringWriter w = new StringWriter(stringBuilder))
		{
			using (XmlTextWriter xmlTextWriter = new XmlTextWriter(w))
			{
				xmlTextWriter.Formatting = Formatting.Indented;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(TOD_Parameters));
				TOD_Parameters o = new TOD_Parameters(this);
				xmlSerializer.Serialize(xmlTextWriter, o);
			}
		}
		return stringBuilder.ToString();
	}

	private void UpdateQualitySettings()
	{
		if (!Headless)
		{
			Mesh mesh = null;
			Mesh mesh2 = null;
			Mesh mesh3 = null;
			Mesh mesh4 = null;
			Mesh mesh5 = null;
			Mesh mesh6 = null;
			switch (MeshQuality)
			{
			case TOD_MeshQualityType.Low:
				mesh = Resources.SkyLOD2;
				mesh2 = Resources.SkyLOD2;
				mesh3 = Resources.SkyLOD2;
				mesh4 = Resources.CloudsLOD2;
				mesh5 = Resources.MoonLOD2;
				break;
			case TOD_MeshQualityType.Medium:
				mesh = Resources.SkyLOD1;
				mesh2 = Resources.SkyLOD1;
				mesh3 = Resources.SkyLOD2;
				mesh4 = Resources.CloudsLOD1;
				mesh5 = Resources.MoonLOD1;
				break;
			case TOD_MeshQualityType.High:
				mesh = Resources.SkyLOD0;
				mesh2 = Resources.SkyLOD0;
				mesh3 = Resources.SkyLOD2;
				mesh4 = Resources.CloudsLOD0;
				mesh5 = Resources.MoonLOD0;
				break;
			}
			switch (StarQuality)
			{
			case TOD_StarQualityType.Low:
				mesh6 = Resources.StarsLOD2;
				break;
			case TOD_StarQualityType.Medium:
				mesh6 = Resources.StarsLOD1;
				break;
			case TOD_StarQualityType.High:
				mesh6 = Resources.StarsLOD0;
				break;
			}
			if ((bool)Components.SpaceMeshFilter && Components.SpaceMeshFilter.sharedMesh != mesh)
			{
				Components.SpaceMeshFilter.mesh = mesh;
			}
			if ((bool)Components.MoonMeshFilter && Components.MoonMeshFilter.sharedMesh != mesh5)
			{
				Components.MoonMeshFilter.mesh = mesh5;
			}
			if ((bool)Components.AtmosphereMeshFilter && Components.AtmosphereMeshFilter.sharedMesh != mesh2)
			{
				Components.AtmosphereMeshFilter.mesh = mesh2;
			}
			if ((bool)Components.ClearMeshFilter && Components.ClearMeshFilter.sharedMesh != mesh3)
			{
				Components.ClearMeshFilter.mesh = mesh3;
			}
			if ((bool)Components.CloudMeshFilter && Components.CloudMeshFilter.sharedMesh != mesh4)
			{
				Components.CloudMeshFilter.mesh = mesh4;
			}
			if ((bool)Components.StarMeshFilter && Components.StarMeshFilter.sharedMesh != mesh6)
			{
				Components.StarMeshFilter.mesh = mesh6;
			}
		}
	}

	private void UpdateRenderSettings()
	{
		if (!Headless)
		{
			UpdateFog();
			if (!Application.isPlaying || timeSinceAmbientUpdate >= Ambient.UpdateInterval)
			{
				timeSinceAmbientUpdate = 0f;
				UpdateAmbient();
			}
			else
			{
				timeSinceAmbientUpdate += Time.deltaTime;
			}
			if (!Application.isPlaying || timeSinceReflectionUpdate >= Reflection.UpdateInterval)
			{
				timeSinceReflectionUpdate = 0f;
				UpdateReflection();
			}
			else
			{
				timeSinceReflectionUpdate += Time.deltaTime;
			}
		}
	}

	private void UpdateShaderKeywords()
	{
		if (Headless)
		{
			return;
		}
		switch (ColorSpace)
		{
		case TOD_ColorSpaceType.Auto:
			if (QualitySettings.activeColorSpace == UnityEngine.ColorSpace.Linear)
			{
				Shader.EnableKeyword("TOD_OUTPUT_LINEAR");
			}
			else
			{
				Shader.DisableKeyword("TOD_OUTPUT_LINEAR");
			}
			break;
		case TOD_ColorSpaceType.Linear:
			Shader.EnableKeyword("TOD_OUTPUT_LINEAR");
			break;
		case TOD_ColorSpaceType.Gamma:
			Shader.DisableKeyword("TOD_OUTPUT_LINEAR");
			break;
		}
		switch (ColorRange)
		{
		case TOD_ColorRangeType.Auto:
			if ((bool)Components.Camera && Components.Camera.HDR)
			{
				Shader.EnableKeyword("TOD_OUTPUT_HDR");
			}
			else
			{
				Shader.DisableKeyword("TOD_OUTPUT_HDR");
			}
			break;
		case TOD_ColorRangeType.HDR:
			Shader.EnableKeyword("TOD_OUTPUT_HDR");
			break;
		case TOD_ColorRangeType.LDR:
			Shader.DisableKeyword("TOD_OUTPUT_HDR");
			break;
		}
		switch (ColorOutput)
		{
		case TOD_ColorOutputType.Raw:
			Shader.DisableKeyword("TOD_OUTPUT_DITHERING");
			break;
		case TOD_ColorOutputType.Dithered:
			Shader.EnableKeyword("TOD_OUTPUT_DITHERING");
			break;
		}
		switch (SkyQuality)
		{
		case TOD_SkyQualityType.PerVertex:
			Shader.DisableKeyword("TOD_SCATTERING_PER_PIXEL");
			break;
		case TOD_SkyQualityType.PerPixel:
			Shader.EnableKeyword("TOD_SCATTERING_PER_PIXEL");
			break;
		}
		switch (CloudQuality)
		{
		case TOD_CloudQualityType.Low:
			Shader.DisableKeyword("TOD_CLOUDS_DENSITY");
			Shader.DisableKeyword("TOD_CLOUDS_BUMPED");
			break;
		case TOD_CloudQualityType.Medium:
			Shader.EnableKeyword("TOD_CLOUDS_DENSITY");
			Shader.DisableKeyword("TOD_CLOUDS_BUMPED");
			break;
		case TOD_CloudQualityType.High:
			Shader.EnableKeyword("TOD_CLOUDS_DENSITY");
			Shader.EnableKeyword("TOD_CLOUDS_BUMPED");
			break;
		}
	}

	private void UpdateShaderProperties()
	{
		if (!Headless)
		{
			Shader.SetGlobalColor(Resources.ID_SunLightColor, SunLightColor);
			Shader.SetGlobalColor(Resources.ID_MoonLightColor, MoonLightColor);
			Shader.SetGlobalColor(Resources.ID_SunSkyColor, SunSkyColor * skyMultiplier);
			Shader.SetGlobalColor(Resources.ID_MoonSkyColor, MoonSkyColor * skyMultiplier);
			Shader.SetGlobalColor(Resources.ID_SunMeshColor, SunMeshColor * skyMultiplier);
			Shader.SetGlobalColor(Resources.ID_MoonMeshColor, MoonMeshColor * skyMultiplier);
			Shader.SetGlobalColor(Resources.ID_SunCloudColor, SunCloudColor * skyMultiplier);
			Shader.SetGlobalColor(Resources.ID_MoonCloudColor, MoonCloudColor * skyMultiplier);
			Shader.SetGlobalColor(Resources.ID_FogColor, FogColor * skyMultiplier);
			Shader.SetGlobalColor(Resources.ID_GroundColor, GroundColor);
			Shader.SetGlobalColor(Resources.ID_AmbientColor, AmbientColor);
			Shader.SetGlobalVector(Resources.ID_SunDirection, SunDirection);
			Shader.SetGlobalVector(Resources.ID_MoonDirection, MoonDirection);
			Shader.SetGlobalVector(Resources.ID_LightDirection, LightDirection);
			Shader.SetGlobalVector(Resources.ID_LocalSunDirection, LocalSunDirection);
			Shader.SetGlobalVector(Resources.ID_LocalMoonDirection, LocalMoonDirection);
			Shader.SetGlobalVector(Resources.ID_LocalLightDirection, LocalLightDirection);
			Shader.SetGlobalFloat(Resources.ID_Contrast, Atmosphere.Contrast);
			Shader.SetGlobalFloat(Resources.ID_Brightness, Atmosphere.Brightness);
			Shader.SetGlobalFloat(Resources.ID_Fogginess, Atmosphere.Fogginess);
			Shader.SetGlobalFloat(Resources.ID_Directionality, Atmosphere.Directionality);
			Shader.SetGlobalFloat(Resources.ID_MoonHaloPower, 1f / Moon.HaloSize);
			Shader.SetGlobalColor(Resources.ID_MoonHaloColor, MoonHaloColor);
			float value = Mathf.Lerp(0.8f, 0f, Clouds.Coverage);
			float num = Mathf.Lerp(3f, 9f, Clouds.Sharpness);
			float value2 = Mathf.Lerp(0f, 1f, Clouds.Attenuation);
			float value3 = Mathf.Lerp(0f, 2f, Clouds.Saturation);
			Shader.SetGlobalFloat(Resources.ID_CloudOpacity, Clouds.Opacity);
			Shader.SetGlobalFloat(Resources.ID_CloudCoverage, value);
			Shader.SetGlobalFloat(Resources.ID_CloudSharpness, 1f / num);
			Shader.SetGlobalFloat(Resources.ID_CloudDensity, num);
			Shader.SetGlobalFloat(Resources.ID_CloudColoring, Clouds.Coloring);
			Shader.SetGlobalFloat(Resources.ID_CloudAttenuation, value2);
			Shader.SetGlobalFloat(Resources.ID_CloudSaturation, value3);
			Shader.SetGlobalFloat(Resources.ID_CloudScattering, Clouds.Scattering);
			Shader.SetGlobalFloat(Resources.ID_CloudBrightness, Clouds.Brightness * skyMultiplier);
			Shader.SetGlobalVector(Resources.ID_CloudOffset, Components.Animation.OffsetUV);
			Shader.SetGlobalVector(Resources.ID_CloudWind, Components.Animation.CloudUV);
			Shader.SetGlobalVector(Resources.ID_CloudSize, new Vector3(Clouds.Size * 4f, Clouds.Size, Clouds.Size * 4f));
			Shader.SetGlobalFloat(Resources.ID_StarSize, Stars.Size);
			Shader.SetGlobalFloat(Resources.ID_StarBrightness, Stars.Brightness);
			Shader.SetGlobalFloat(Resources.ID_StarVisibility, (1f - Atmosphere.Fogginess) * (1f - LerpValue));
			Shader.SetGlobalFloat(Resources.ID_SunMeshContrast, 1f / Mathf.Max(0.001f, Sun.MeshContrast));
			Shader.SetGlobalFloat(Resources.ID_SunMeshBrightness, Sun.MeshBrightness * (1f - Atmosphere.Fogginess));
			Shader.SetGlobalFloat(Resources.ID_MoonMeshContrast, 1f / Mathf.Max(0.001f, Moon.MeshContrast));
			Shader.SetGlobalFloat(Resources.ID_MoonMeshBrightness, Moon.MeshBrightness * (1f - Atmosphere.Fogginess));
			Shader.SetGlobalVector(Resources.ID_kBetaMie, kBetaMie);
			Shader.SetGlobalVector(Resources.ID_kSun, kSun);
			Shader.SetGlobalVector(Resources.ID_k4PI, k4PI);
			Shader.SetGlobalVector(Resources.ID_kRadius, kRadius);
			Shader.SetGlobalVector(Resources.ID_kScale, kScale);
			Shader.SetGlobalFloat(Resources.ID_SkyMultiplier, skyMultiplier);
			Shader.SetGlobalMatrix(Resources.ID_World2Sky, Components.DomeTransform.worldToLocalMatrix);
			Shader.SetGlobalMatrix(Resources.ID_Sky2World, Components.DomeTransform.localToWorldMatrix);
		}
	}

	private float ShaderScale(float inCos)
	{
		float num = 1f - inCos;
		return 0.25f * Mathf.Exp(-0.00287f + num * (0.459f + num * (3.83f + num * (-6.8f + num * 5.25f))));
	}

	private float ShaderMiePhase(float eyeCos, float eyeCos2)
	{
		return kBetaMie.x * (1f + eyeCos2) / Mathf.Pow(kBetaMie.y + kBetaMie.z * eyeCos, 1.5f);
	}

	private float ShaderRayleighPhase(float eyeCos2)
	{
		return 0.75f + 0.75f * eyeCos2;
	}

	private Color ShaderNightSkyColor(Vector3 dir)
	{
		dir.y = Mathf.Max(0f, dir.y);
		return MoonSkyColor * (1f - 0.75f * dir.y);
	}

	private Color ShaderMoonHaloColor(Vector3 dir)
	{
		return MoonHaloColor * Mathf.Pow(Mathf.Max(0f, Vector3.Dot(dir, LocalMoonDirection)), 1f / Moon.MeshSize);
	}

	private Color TOD_HDR2LDR(Color color)
	{
		return new Color(1f - Mathf.Pow(2f, (0f - Atmosphere.Brightness) * color.r), 1f - Mathf.Pow(2f, (0f - Atmosphere.Brightness) * color.g), 1f - Mathf.Pow(2f, (0f - Atmosphere.Brightness) * color.b), color.a);
	}

	private Color TOD_GAMMA2LINEAR(Color color)
	{
		return new Color(color.r * color.r, color.g * color.g, color.b * color.b, color.a);
	}

	private Color TOD_LINEAR2GAMMA(Color color)
	{
		return new Color(Mathf.Sqrt(color.r), Mathf.Sqrt(color.g), Mathf.Sqrt(color.b), color.a);
	}

	private Color ShaderScatteringColor(Vector3 dir, bool directLight = true)
	{
		dir.y = Mathf.Max(0f, dir.y);
		float x = kRadius.x;
		float y = kRadius.y;
		float w = kRadius.w;
		float x2 = kScale.x;
		float z = kScale.z;
		float w2 = kScale.w;
		float x3 = k4PI.x;
		float y2 = k4PI.y;
		float z2 = k4PI.z;
		float w3 = k4PI.w;
		float x4 = kSun.x;
		float y3 = kSun.y;
		float z3 = kSun.z;
		float w4 = kSun.w;
		Vector3 vector = new Vector3(0f, x + w2, 0f);
		float num = Mathf.Sqrt(w + y * dir.y * dir.y - y) - x * dir.y;
		float num2 = Mathf.Exp(z * (0f - w2));
		float inCos = Vector3.Dot(dir, vector) / (x + w2);
		float num3 = num2 * ShaderScale(inCos);
		float num4 = num / 2f;
		float num5 = num4 * x2;
		Vector3 vector2 = dir * num4;
		Vector3 rhs = vector + vector2 * 0.5f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		for (int i = 0; i < 2; i++)
		{
			float magnitude = rhs.magnitude;
			float num9 = 1f / magnitude;
			float num10 = Mathf.Exp(z * (x - magnitude));
			float num11 = num10 * num5;
			float inCos2 = Vector3.Dot(dir, rhs) * num9;
			float inCos3 = Vector3.Dot(LocalSunDirection, rhs) * num9;
			float num12 = num3 + num10 * (ShaderScale(inCos3) - ShaderScale(inCos2));
			float num13 = Mathf.Exp((0f - num12) * (x3 + w3));
			float num14 = Mathf.Exp((0f - num12) * (y2 + w3));
			float num15 = Mathf.Exp((0f - num12) * (z2 + w3));
			num6 += num13 * num11;
			num7 += num14 * num11;
			num8 += num15 * num11;
			rhs += vector2;
		}
		float num16 = SunSkyColor.r * num6 * x4;
		float num17 = SunSkyColor.g * num7 * y3;
		float num18 = SunSkyColor.b * num8 * z3;
		float num19 = SunSkyColor.r * num6 * w4;
		float num20 = SunSkyColor.g * num7 * w4;
		float num21 = SunSkyColor.b * num8 * w4;
		float num22 = 0f;
		float num23 = 0f;
		float num24 = 0f;
		float num25 = Vector3.Dot(LocalSunDirection, dir);
		float eyeCos = num25 * num25;
		float num26 = ShaderRayleighPhase(eyeCos);
		num22 += num26 * num16;
		num23 += num26 * num17;
		num24 += num26 * num18;
		if (directLight)
		{
			float num27 = ShaderMiePhase(num25, eyeCos);
			num22 += num27 * num19;
			num23 += num27 * num20;
			num24 += num27 * num21;
		}
		Color color = ShaderNightSkyColor(dir);
		num22 += color.r;
		num23 += color.g;
		num24 += color.b;
		if (directLight)
		{
			Color color2 = ShaderMoonHaloColor(dir);
			num22 += color2.r;
			num23 += color2.g;
			num24 += color2.b;
		}
		num22 = Mathf.Lerp(num22, FogColor.r, Atmosphere.Fogginess);
		num23 = Mathf.Lerp(num23, FogColor.g, Atmosphere.Fogginess);
		num24 = Mathf.Lerp(num24, FogColor.b, Atmosphere.Fogginess);
		num22 = Mathf.Pow(num22 * Atmosphere.Brightness, Atmosphere.Contrast);
		num23 = Mathf.Pow(num23 * Atmosphere.Brightness, Atmosphere.Contrast);
		num24 = Mathf.Pow(num24 * Atmosphere.Brightness, Atmosphere.Contrast);
		return new Color(num22, num23, num24, 1f);
	}

	private void Initialize()
	{
		Components = GetComponent<TOD_Components>();
		Components.Initialize();
		Resources = GetComponent<TOD_Resources>();
		Resources.Initialize();
		instances.Add(this);
		Initialized = true;
	}

	private void Cleanup()
	{
		if ((bool)Probe)
		{
			UnityEngine.Object.Destroy(Probe.gameObject);
		}
		instances.Remove(this);
		Initialized = false;
	}

	protected void OnEnable()
	{
		LateUpdate();
	}

	protected void OnDisable()
	{
		Cleanup();
	}

	protected void LateUpdate()
	{
		if (!Initialized)
		{
			Initialize();
		}
		UpdateScattering();
		UpdateCelestials();
		UpdateQualitySettings();
		UpdateRenderSettings();
		UpdateShaderKeywords();
		UpdateShaderProperties();
	}

	protected void OnValidate()
	{
		Cycle.DateTime = Cycle.DateTime;
	}

	private void UpdateScattering()
	{
		if (deferValueUpdates)
		{
			this.UpdateScatteringValuesRequested?.Invoke();
		}
		float num = 0f - Atmosphere.Directionality;
		float num2 = num * num;
		kBetaMie.x = 1.5f * ((1f - num2) / (2f + num2));
		kBetaMie.y = 1f + num2;
		kBetaMie.z = 2f * num;
		float num3 = 0.002f * Atmosphere.MieMultiplier;
		float num4 = 0.002f * Atmosphere.RayleighMultiplier;
		float x = num4 * 40f * 5.2701645f;
		float y = num4 * 40f * 9.473284f;
		float z = num4 * 40f * 19.643803f;
		float w = num3 * 40f;
		kSun.x = x;
		kSun.y = y;
		kSun.z = z;
		kSun.w = w;
		float x2 = num4 * 4f * (float)Math.PI * 5.2701645f;
		float y2 = num4 * 4f * (float)Math.PI * 9.473284f;
		float z2 = num4 * 4f * (float)Math.PI * 19.643803f;
		float w2 = num3 * 4f * (float)Math.PI;
		k4PI.x = x2;
		k4PI.y = y2;
		k4PI.z = z2;
		k4PI.w = w2;
		kRadius.x = 1f;
		kRadius.y = 1f;
		kRadius.z = 1.025f;
		kRadius.w = 1.050625f;
		kScale.x = 40.00004f;
		kScale.y = 0.25f;
		kScale.z = 160.00015f;
		kScale.w = 0.0001f;
	}

	private static void ComputeSunsetAndSunrise(float worldUTC, float d_noon, float ecl_cos, float ecl_sin, float lon_deg, float lat_sin, float lat_cos, out float SunsetTime, out float SunriseTime)
	{
		float num = 282.9404f + 4.70935E-05f * d_noon;
		float num2 = 0.016709f - 1.151E-09f * d_noon;
		float num3 = 356.047f + 0.98560023f * d_noon;
		float num4 = (float)Math.PI / 180f * num3;
		float num5 = Mathf.Sin(num4);
		float num6 = Mathf.Cos(num4);
		float f = num4 + num2 * num5 * (1f + num2 * num6);
		float num7 = Mathf.Sin(f);
		float num8 = Mathf.Cos(f) - num2;
		float num9 = Mathf.Sqrt(1f - num2 * num2) * num7;
		float num10 = 57.29578f * Mathf.Atan2(num9, num8);
		float num11 = Mathf.Sqrt(num8 * num8 + num9 * num9);
		float num12 = num10 + num;
		float f2 = (float)Math.PI / 180f * num12;
		float num13 = Mathf.Sin(f2);
		float num14 = Mathf.Cos(f2);
		float num15 = num11 * num14;
		float num16 = num11 * num13;
		float num17 = num15;
		float num18 = num16 * ecl_cos;
		float y = num16 * ecl_sin;
		float num19 = Mathf.Atan2(num18, num17);
		float num20 = 57.29578f * num19;
		float f3 = Mathf.Atan2(y, Mathf.Sqrt(num17 * num17 + num18 * num18));
		float num21 = Mathf.Sin(f3);
		float num22 = Mathf.Cos(f3);
		float num23 = num10 + num + 180f;
		float num24 = num20 - num23 - lon_deg;
		float num25 = -6f;
		float num26 = Mathf.Acos((Mathf.Sin((float)Math.PI / 180f * num25) - lat_sin * num21) / (lat_cos * num22));
		float num27 = 57.29578f * num26;
		SunsetTime = (24f + ((num24 + num27) / 15f + worldUTC) % 24f) % 24f;
		SunriseTime = (24f + ((num24 - num27) / 15f + worldUTC) % 24f) % 24f;
	}

	private static void ComputeSunPosition(float d, float hour, float ecl_cos, float ecl_sin, float lon_deg, float lat_sin, float lat_cos, float horizon_rad, out float lst_rad, out float sun_zenith_rad, out float sun_altitude_rad, out float sun_azimuth_rad, out float LocalSiderealTime, out float SunZenith_deg, out float SunAltitude_deg, out float SunAzimuth_deg)
	{
		float num = 282.9404f + 4.70935E-05f * d;
		float num2 = 0.016709f - 1.151E-09f * d;
		float num3 = 356.047f + 0.98560023f * d;
		float num4 = (float)Math.PI / 180f * num3;
		float num5 = Mathf.Sin(num4);
		float num6 = Mathf.Cos(num4);
		float f = num4 + num2 * num5 * (1f + num2 * num6);
		float num7 = Mathf.Sin(f);
		float num8 = Mathf.Cos(f) - num2;
		float num9 = Mathf.Sqrt(1f - num2 * num2) * num7;
		float num10 = 57.29578f * Mathf.Atan2(num9, num8);
		float num11 = Mathf.Sqrt(num8 * num8 + num9 * num9);
		float num12 = num10 + num;
		float f2 = (float)Math.PI / 180f * num12;
		float num13 = Mathf.Sin(f2);
		float num14 = Mathf.Cos(f2);
		float num15 = num11 * num14;
		float num16 = num11 * num13;
		float num17 = num15;
		float num18 = num16 * ecl_cos;
		float y = num16 * ecl_sin;
		float num19 = Mathf.Atan2(num18, num17);
		float f3 = Mathf.Atan2(y, Mathf.Sqrt(num17 * num17 + num18 * num18));
		float num20 = Mathf.Sin(f3);
		float num21 = Mathf.Cos(f3);
		float num22 = num10 + num + 180f + 15f * hour;
		lst_rad = (float)Math.PI / 180f * (num22 + lon_deg);
		LocalSiderealTime = (num22 + lon_deg) / 15f;
		float f4 = lst_rad - num19;
		float num23 = Mathf.Sin(f4);
		float num24 = Mathf.Cos(f4) * num21;
		float num25 = num23 * num21;
		float num26 = num20;
		float num27 = num24 * lat_sin - num26 * lat_cos;
		float num28 = num25;
		float y2 = num24 * lat_cos + num26 * lat_sin;
		float num29 = Mathf.Atan2(num28, num27) + (float)Math.PI;
		float num30 = Mathf.Atan2(y2, Mathf.Sqrt(num27 * num27 + num28 * num28));
		sun_zenith_rad = horizon_rad - num30;
		sun_altitude_rad = num30;
		sun_azimuth_rad = num29;
		SunZenith_deg = 57.29578f * sun_zenith_rad;
		SunAltitude_deg = 57.29578f * sun_altitude_rad;
		SunAzimuth_deg = 57.29578f * sun_azimuth_rad;
	}

	private static void ComputeMoonPosition(TOD_MoonPositionType positionType, float d, float ecl_cos, float ecl_sin, float lst_rad, float lat_sin, float lat_cos, float horizon_rad, float sun_zenith_rad, float sun_altitude_rad, float sun_azimuth_rad, out float moon_zenith_rad, out float moon_altitude_rad, out float moon_azimuth_rad, out float MoonZenith_deg, out float MoonAltitude_deg, out float MoonAzimuth_deg)
	{
		if (positionType == TOD_MoonPositionType.Realistic)
		{
			float num = 125.1228f - 0.05295381f * d;
			float num2 = 5.1454f;
			float num3 = 318.0634f + 0.16435732f * d;
			float num4 = 0.0549f;
			float num5 = 115.3654f + 13.064993f * d;
			float f = (float)Math.PI / 180f * num;
			float num6 = Mathf.Sin(f);
			float num7 = Mathf.Cos(f);
			float f2 = (float)Math.PI / 180f * num2;
			float num8 = Mathf.Sin(f2);
			float num9 = Mathf.Cos(f2);
			float num10 = (float)Math.PI / 180f * num5;
			float num11 = Mathf.Sin(num10);
			float num12 = Mathf.Cos(num10);
			float f3 = num10 + num4 * num11 * (1f + num4 * num12);
			float num13 = Mathf.Sin(f3);
			float num14 = Mathf.Cos(f3);
			float num15 = 60.2666f * (num14 - num4);
			float num16 = 60.2666f * (Mathf.Sqrt(1f - num4 * num4) * num13);
			float num17 = 57.29578f * Mathf.Atan2(num16, num15);
			float num18 = Mathf.Sqrt(num15 * num15 + num16 * num16);
			float num19 = num17 + num3;
			float f4 = (float)Math.PI / 180f * num19;
			float num20 = Mathf.Sin(f4);
			float num21 = Mathf.Cos(f4);
			float num22 = num18 * (num7 * num21 - num6 * num20 * num9);
			float num23 = num18 * (num6 * num21 + num7 * num20 * num9);
			float num24 = num18 * (num20 * num8);
			float num25 = num22;
			float num26 = num23;
			float num27 = num24;
			float num28 = num25;
			float num29 = num26 * ecl_cos - num27 * ecl_sin;
			float y = num26 * ecl_sin + num27 * ecl_cos;
			float num30 = Mathf.Atan2(num29, num28);
			float f5 = Mathf.Atan2(y, Mathf.Sqrt(num28 * num28 + num29 * num29));
			float num31 = Mathf.Sin(f5);
			float num32 = Mathf.Cos(f5);
			float f6 = lst_rad - num30;
			float num33 = Mathf.Sin(f6);
			float num34 = Mathf.Cos(f6) * num32;
			float num35 = num33 * num32;
			float num36 = num31;
			float num37 = num34 * lat_sin - num36 * lat_cos;
			float num38 = num35;
			float y2 = num34 * lat_cos + num36 * lat_sin;
			float num39 = Mathf.Atan2(num38, num37) + (float)Math.PI;
			float num40 = Mathf.Atan2(y2, Mathf.Sqrt(num37 * num37 + num38 * num38));
			moon_zenith_rad = horizon_rad - num40;
			moon_altitude_rad = num40;
			moon_azimuth_rad = num39;
		}
		else
		{
			moon_zenith_rad = sun_zenith_rad - (float)Math.PI;
			moon_altitude_rad = sun_altitude_rad - (float)Math.PI;
			moon_azimuth_rad = sun_azimuth_rad;
		}
		MoonZenith_deg = 57.29578f * moon_zenith_rad;
		MoonAltitude_deg = 57.29578f * moon_altitude_rad;
		MoonAzimuth_deg = 57.29578f * moon_azimuth_rad;
	}

	private static CelestialData ComputeCelestialDataFor(int year, int month, int day, float hour, float worldUTC, float worldLatitude, float worldLongitude, TOD_MoonPositionType moonPositionType)
	{
		CelestialData result = new CelestialData
		{
			worldLatitude = worldLatitude,
			worldLongitude = worldLongitude
		};
		float f = (float)Math.PI / 180f * worldLatitude;
		float lat_sin = Mathf.Sin(f);
		float lat_cos = Mathf.Cos(f);
		float horizon_rad = (float)Math.PI / 2f;
		float num = (float)(367 * year - 7 * (year + (month + 9) / 12) / 4 + 275 * month / 9 + day - 730530) + hour / 24f;
		float d_noon = (float)(367 * year - 7 * (year + (month + 9) / 12) / 4 + 275 * month / 9 + day - 730530) + 0.5f;
		float num2 = 23.4393f - 3.563E-07f * num;
		float f2 = (float)Math.PI / 180f * num2;
		float ecl_sin = Mathf.Sin(f2);
		float ecl_cos = Mathf.Cos(f2);
		ComputeSunsetAndSunrise(worldUTC, d_noon, ecl_cos, ecl_sin, worldLongitude, lat_sin, lat_cos, out result.SunsetTime, out result.SunriseTime);
		ComputeSunPosition(num, hour, ecl_cos, ecl_sin, worldLongitude, lat_sin, lat_cos, horizon_rad, out result.lst_rad, out result.sun_zenith_rad, out result.sun_altitude_rad, out result.sun_azimuth_rad, out result.LocalSiderealTime, out result.SunZenith, out result.SunAltitude, out result.SunAzimuth);
		ComputeMoonPosition(moonPositionType, num, ecl_cos, ecl_sin, result.lst_rad, lat_sin, lat_cos, horizon_rad, result.sun_zenith_rad, result.sun_altitude_rad, result.sun_azimuth_rad, out result.moon_zenith_rad, out result.moon_altitude_rad, out result.moon_azimuth_rad, out result.MoonZenith, out result.MoonAltitude, out result.MoonAzimuth);
		return result;
	}

	private static CelestialPositions ComputeCelestialPositionsFrom(CelestialData data, float sunMeshSize, float moonMeshSize, float sunAndMoonScale, float celestialShortening)
	{
		CelestialPositions result = default(CelestialPositions);
		result.spaceRot = Quaternion.Euler(90f - data.worldLatitude, 0f, 0f) * Quaternion.Euler(0f, 180f + data.lst_rad * 57.29578f, 0f);
		result.sunPos = OrbitalToLocal(data.sun_zenith_rad, data.sun_azimuth_rad, out result.sunMultiplier, celestialShortening);
		result.moonPos = OrbitalToLocal(data.moon_zenith_rad, data.moon_azimuth_rad, out result.moonMultiplier, celestialShortening);
		result.sunSize = result.sunMultiplier * 8f * Mathf.Tan((float)Math.PI / 360f * sunMeshSize * sunAndMoonScale);
		result.sunScale = new Vector3(result.sunSize, result.sunSize, result.sunSize);
		result.moonSize = result.moonMultiplier * 4f * Mathf.Tan((float)Math.PI / 360f * moonMeshSize * sunAndMoonScale);
		result.moonScale = new Vector3(result.moonSize, result.moonSize, result.moonSize);
		return result;
	}

	private void UpdateCelestialPositions(CelestialPositions pos)
	{
		if (Stars.Position == TOD_StarsPositionType.Rotating)
		{
			Components.SpaceTransform.localRotation = pos.spaceRot;
			Components.StarTransform.localRotation = pos.spaceRot;
		}
		else
		{
			Components.SpaceTransform.localRotation = Quaternion.identity;
			Components.StarTransform.localRotation = Quaternion.identity;
		}
		Components.SunTransform.localPosition = pos.sunPos;
		Components.SunTransform.LookAt(Components.DomeTransform.position, Components.SunTransform.up);
		Vector3 worldUp = pos.spaceRot * -Vector3.right;
		Components.MoonTransform.localPosition = pos.moonPos;
		Components.MoonTransform.LookAt(Components.DomeTransform.position, worldUp);
		Components.SunTransform.localScale = pos.sunScale;
		Components.MoonTransform.localScale = pos.moonScale;
		bool flag = (1f - Atmosphere.Fogginess) * (1f - LerpValue) > 0f;
		Components.SpaceRenderer.enabled = flag;
		Components.StarRenderer.enabled = flag;
		bool flag2 = Components.SunTransform.localPosition.y > 0f - pos.sunSize;
		Components.SunRenderer.enabled = flag2;
		bool flag3 = Components.MoonTransform.localPosition.y > 0f - pos.moonSize;
		Components.MoonRenderer.enabled = flag3;
		bool flag4 = true;
		Components.AtmosphereRenderer.enabled = flag4;
		bool flag5 = false;
		Components.ClearRenderer.enabled = flag5;
		bool flag6 = Clouds.Coverage > 0f && Clouds.Opacity > 0f;
		Components.CloudRenderer.enabled = flag6;
	}

	private static ColorData ComputeColorData(CelestialData cel, CelestialPositions pos, float atmosphereFogginess, float moonHaloBrightness, float lightMinimumHeight, TOD_DayParameters Day, TOD_NightParameters Night, float celestialShortening)
	{
		ColorData result = new ColorData
		{
			LerpValue = Mathf.InverseLerp(105f, 90f, cel.SunZenith)
		};
		float time = Mathf.Clamp01(cel.SunZenith / 90f);
		float time2 = Mathf.Clamp01((cel.SunZenith - 90f) / 90f);
		float num = Mathf.Clamp01((result.LerpValue - 0.1f) / 0.9f);
		float num2 = Mathf.Clamp01((0.1f - result.LerpValue) / 0.1f);
		float num3 = Mathf.Clamp01((90f - cel.moon_zenith_rad * 57.29578f) / 5f);
		result.SunVisibility = (1f - atmosphereFogginess) * num;
		result.MoonVisibility = (1f - atmosphereFogginess) * num2 * num3;
		result.SunLightColor = TOD_Util.ApplyAlpha(Day.LightColor.Evaluate(time));
		result.MoonLightColor = TOD_Util.ApplyAlpha(Night.LightColor.Evaluate(time2));
		result.SunRayColor = TOD_Util.ApplyAlpha(Day.RayColor.Evaluate(time));
		result.MoonRayColor = TOD_Util.ApplyAlpha(Night.RayColor.Evaluate(time2));
		result.SunSkyColor = TOD_Util.ApplyAlpha(Day.SkyColor.Evaluate(time));
		result.MoonSkyColor = TOD_Util.ApplyAlpha(Night.SkyColor.Evaluate(time2));
		result.SunMeshColor = TOD_Util.ApplyAlpha(Day.SunColor.Evaluate(time));
		result.MoonMeshColor = TOD_Util.ApplyAlpha(Night.MoonColor.Evaluate(time2));
		result.SunCloudColor = TOD_Util.ApplyAlpha(Day.CloudColor.Evaluate(time));
		result.MoonCloudColor = TOD_Util.ApplyAlpha(Night.CloudColor.Evaluate(time2));
		Color b = TOD_Util.ApplyAlpha(Day.FogColor.Evaluate(time));
		Color a = TOD_Util.ApplyAlpha(Night.FogColor.Evaluate(time2));
		result.FogColor = Color.Lerp(a, b, result.LerpValue);
		Color color = TOD_Util.ApplyAlpha(Day.AmbientColor.Evaluate(time));
		Color color2 = TOD_Util.ApplyAlpha(Night.AmbientColor.Evaluate(time2));
		result.AmbientColor = Color.Lerp(color2, color, result.LerpValue);
		Color b2 = color;
		Color a2 = color2;
		result.GroundColor = Color.Lerp(a2, b2, result.LerpValue);
		result.MoonHaloColor = TOD_Util.MulRGB(result.MoonSkyColor, moonHaloBrightness * num3);
		if (result.LerpValue > 0.1f)
		{
			result.IsDay = true;
			result.IsNight = false;
			result.lightShadowStrength = Day.ShadowStrength;
			result.lightIntensity = Mathf.Lerp(0f, Day.LightIntensity, result.SunVisibility);
			result.lightColor = result.SunLightColor;
		}
		else
		{
			result.IsDay = false;
			result.IsNight = true;
			result.lightShadowStrength = Night.ShadowStrength;
			result.lightIntensity = Mathf.Lerp(0f, Night.LightIntensity, result.MoonVisibility);
			result.lightColor = result.MoonLightColor;
		}
		result.lightPosition = (result.IsNight ? OrbitalToLocal(Mathf.Min(cel.moon_zenith_rad, (1f - lightMinimumHeight) * (float)Math.PI / 2f), cel.moon_azimuth_rad, out var scalingCorrection, celestialShortening) : OrbitalToLocal(Mathf.Min(cel.sun_zenith_rad, (1f - lightMinimumHeight) * (float)Math.PI / 2f), cel.sun_azimuth_rad, out scalingCorrection, celestialShortening));
		return result;
	}

	private void UpdateLights(ColorData data)
	{
		Components.LightSource.color = data.lightColor;
		Components.LightSource.intensity = data.lightIntensity * intensityMultiplier;
		Components.LightSource.shadowStrength = data.lightShadowStrength;
		if (!Application.isPlaying || timeSinceLightUpdate >= Light.UpdateInterval)
		{
			timeSinceLightUpdate = 0f;
			if (Vector3.Angle(Components.LightTransform.forward, (Components.DomeTransform.position - Components.LightTransform.parent.TransformPoint(data.lightPosition)).normalized) > MinLightAngleMove)
			{
				Components.LightTransform.localPosition = data.lightPosition;
				Components.LightTransform.LookAt(Components.DomeTransform.position);
			}
		}
		else
		{
			timeSinceLightUpdate += Time.deltaTime;
		}
	}

	private void UpdateCelestials()
	{
		float hour = (float)Cycle.Hour - World.UTC;
		CelestialData celestialData = (useFixedDay ? ComputeCelestialDataFor(fixedYear, fixedMonth, fixedDay, hour, World.UTC, World.Latitude, World.Longitude, Moon.Position) : ComputeCelestialDataFor(Cycle.Year, Cycle.Month, Cycle.Day, hour, World.UTC, World.Latitude, World.Longitude, Moon.Position));
		CelestialPositions pos = ComputeCelestialPositionsFrom(celestialData, Sun.MeshSize, Moon.MeshSize, SunAndMoonScale, celestialShortening);
		if (useFixedDay)
		{
			CelestialData celestialData2 = ComputeCelestialDataFor(fixedYear, fixedMonth, fixedDay - 1, hour, World.UTC, World.Latitude, World.Longitude, Moon.Position);
			CelestialPositions other = ComputeCelestialPositionsFrom(celestialData2, Sun.MeshSize, Moon.MeshSize, SunAndMoonScale, celestialShortening);
			celestialData.LerpTo(celestialData2, (float)Cycle.Hour / 24f);
			pos.LerpTo(other, (float)Cycle.Hour / 24f);
		}
		UpdateCelestialPositions(pos);
		ColorData data = ComputeColorData(celestialData, pos, Atmosphere.Fogginess, Moon.HaloBrightness, Light.MinimumHeight, Day, Night, celestialShortening);
		UpdateLights(data);
		SunsetTime = celestialData.SunsetTime;
		SunriseTime = celestialData.SunriseTime;
		LocalSiderealTime = celestialData.LocalSiderealTime;
		SunZenith = celestialData.SunZenith;
		SunAltitude = celestialData.SunAltitude;
		SunAzimuth = celestialData.SunAzimuth;
		MoonZenith = celestialData.MoonZenith;
		MoonAltitude = celestialData.MoonAltitude;
		MoonAzimuth = celestialData.MoonAzimuth;
		LerpValue = data.LerpValue;
		SunVisibility = data.SunVisibility;
		MoonVisibility = data.MoonVisibility;
		if (deferValueUpdates)
		{
			this.UpdateOtherValuesRequested?.Invoke();
		}
		else
		{
			SunLightColor = data.SunLightColor;
			MoonLightColor = data.MoonLightColor;
			SunRayColor = data.SunRayColor;
			MoonRayColor = data.MoonRayColor;
			SunSkyColor = data.SunSkyColor;
			MoonSkyColor = data.MoonSkyColor;
			SunMeshColor = data.SunMeshColor;
			MoonMeshColor = data.MoonMeshColor;
			SunCloudColor = data.SunCloudColor;
			MoonCloudColor = data.MoonCloudColor;
			FogColor = data.FogColor;
			AmbientColor = data.AmbientColor;
			GroundColor = data.GroundColor;
		}
		SunDirection = -Components.SunTransform.forward;
		LocalSunDirection = Components.DomeTransform.InverseTransformDirection(SunDirection);
		MoonDirection = -Components.MoonTransform.forward;
		LocalMoonDirection = Components.DomeTransform.InverseTransformDirection(MoonDirection);
		LightDirection = -Components.LightTransform.forward;
		LocalLightDirection = Components.DomeTransform.InverseTransformDirection(LightDirection);
	}
}
