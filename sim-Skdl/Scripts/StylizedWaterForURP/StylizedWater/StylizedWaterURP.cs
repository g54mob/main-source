using UnityEngine;

namespace StylizedWater
{
	[AddComponentMenu("Effects/Stylized Water")]
	[HelpURL("https://alexander-ameye.gitbook.io/stylized-water/")]
	[ExecuteAlways]
	[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
	public class StylizedWaterURP : MonoBehaviour
	{
		public enum FoamMovement
		{
			Directional = 0,
			Shore = 1
		}

		public enum Lighting
		{
			Enabled = 0,
			Disabled = 1
		}

		public enum WaterUVs
		{
			Local = 0,
			World = 1
		}

		public bool refractionExpanded;

		public bool vertexPaintingExpanded;

		public bool surfaceFoamExpanded;

		public bool foamShadowsExpanded;

		public bool intersectionEffectsExpanded;

		public bool planarReflectionsExpanded;

		private const string shaderName = "Stylized Water";

		private const string mobileShaderName = "Stylized Water Mobile";

		private const string underwaterShaderName = "Stylized Water Underwater";

		[Range(0f, 1f)]
		public float reflectionStrength;

		[Range(0f, 7f)]
		public float reflectionFresnel;

		public bool useColorGradient;

		[GradientUsage(true)]
		public Gradient colorGradient;

		public Texture2D colorGradientTexture;

		[ColorUsage(true, true)]
		public Color shallowColor;

		[ColorUsage(true, true)]
		public Color deepColor;

		[Range(0f, 4f)]
		public float colorDepth;

		[ColorUsage(true, true)]
		public Color horizonColor;

		[Range(0f, 20f)]
		public float horizonDistance;

		[Range(0f, 1f)]
		public float shoreFade;

		[ColorUsage(false, false)]
		public Color shoreColor;

		[Range(0f, 1f)]
		public float shoreStrength;

		[Range(0f, 1f)]
		public float shoreBlend;

		[Range(0f, 3f)]
		public float shoreDepth;

		[ColorUsage(false, false)]
		public Color waveColor;

		[ColorUsage(false, false)]
		public Color underwaterColor;

		[Range(0f, 1f)]
		public float underwaterColorStrength;

		[Range(0f, 0.3f)]
		public float underwaterRefractionStrength;

		public Texture surfaceFoamTexture;

		public Vector2 surfaceFoamSampling;

		[Range(0f, 1f)]
		public float surfaceFoamCutoff;

		[Range(0f, 3f)]
		public float surfaceFoamDistortion;

		[Range(0f, 1f)]
		public float surfaceFoamBlend;

		[ColorUsage(true, false)]
		public Color surfaceFoamColor1;

		[ColorUsage(true, false)]
		public Color surfaceFoamColor2;

		public Vector4 surfaceFoamMovement;

		[Range(0f, 1f)]
		public float surfaceFoamDirection1;

		[Range(0f, 1f)]
		public float surfaceFoamDirection2;

		[Range(0f, 2f)]
		public float surfaceFoamSpeed1;

		[Range(0f, 2f)]
		public float surfaceFoamSpeed2;

		public Vector4 surfaceFoamTilingAndOffset;

		[Range(0f, 1f)]
		public float surfaceFoamOffsetX;

		[Range(0f, 1f)]
		public float surfaceFoamOffsetY;

		[Range(0f, 2f)]
		public float surfaceFoamScale1;

		[Range(0f, 2f)]
		public float surfaceFoamScale2;

		public bool enableSurfaceFoam;

		[Range(0f, 1f)]
		public float surfaceFoamHeightMask;

		[Range(0f, 1f)]
		public float surfaceFoamHeightMaskSmoothness;

		public bool enableHeightMask;

		[Range(0f, 1f)]
		public float foamShadowStrength;

		[Range(0f, 10f)]
		public float foamShadowDepth;

		[Range(0f, 15f)]
		public float surfaceFoamShadowProjection;

		[Range(0f, 15f)]
		public float intersectionFoamShadowProjection;

		public FoamMovement foamMovement;

		[Range(0f, 3f)]
		public float intersectionFoamDepth;

		public Texture intersectionFoamTexture;

		[ColorUsage(true, false)]
		public Color intersectionFoamColor;

		public Vector2 intersectionFoamMovement;

		[Range(0f, 1f)]
		public float intersectionFoamDirection;

		[Range(0f, 2f)]
		public float intersectionFoamSpeed;

		[Range(0f, 2f)]
		public float intersectionFoamScale;

		public Vector2 intersectionFoamSampling;

		[Range(0f, 1f)]
		public float intersectionFoamCutoff;

		[Range(0f, 3f)]
		public float intersectionFoamDistortion;

		public bool enableIntersectionEffects;

		[Range(0f, 1f)]
		public float intersectionFoamBlend;

		[Range(0f, 1f)]
		public float intersectionWaterBlend;

		[Range(-5f, 5f)]
		public float shoreFoamSpeed;

		[Range(0f, 2f)]
		public float shoreFoamWidth;

		[Range(0f, 40f)]
		public float shoreFoamFrequency;

		[Range(0f, 5f)]
		public float shoreFoamBreakupStrength;

		[Range(0f, 50f)]
		public float shoreFoamBreakupScale;

		public Lighting lighting;

		[Range(0f, 1f)]
		public float lightingSmoothness;

		[ColorUsage(false, true)]
		public Color lightingSpecularColor;

		[ColorUsage(false, true)]
		public Color lightingDiffuseColor;

		[Range(0f, 1f)]
		public float lightingHardness;

		public Texture normalsTexture;

		public Vector2 normalsMovement;

		[Range(0f, 1f)]
		public float normalsStrength;

		[Range(0.01f, 2f)]
		public float normalsScale;

		[Range(0f, 0.3f)]
		public float normalsSpeed;

		[Range(0f, 0.3f)]
		public float refractionStrength;

		public Vector3 waveVisuals;

		[Range(0f, 0.5f)]
		public float waveSteepness;

		[Range(0f, 20f)]
		public float waveLength;

		[Range(0f, 3f)]
		public float waveSpeed;

		public Vector4 waveDirections;

		[Range(0f, 1f)]
		public float waveDirection1;

		[Range(0f, 1f)]
		public float waveDirection2;

		[Range(0f, 1f)]
		public float waveDirection3;

		[Range(0f, 1f)]
		public float waveDirection4;

		public WaterUVs waterUVs;

		public bool hideComponents;

		public bool enableFoamShadows;

		public bool enableRefraction;

		public MeshRenderer meshRenderer;

		public MeshFilter meshFilter;

		public Material material;

		private void OnEnable()
		{
		}

		private void Reset()
		{
		}

		private void ResetHideFlags()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void SafeDestroyObject(Object obj)
		{
		}

		public void ReadMaterialProperties()
		{
		}

		public void WriteMaterialProperties()
		{
		}

		public float GetWaveSteepness()
		{
			return 0f;
		}

		public float GetWaveLength()
		{
			return 0f;
		}

		public float GetWaveSpeed()
		{
			return 0f;
		}

		public float[] GetWaveDirections()
		{
			return null;
		}
	}
}
