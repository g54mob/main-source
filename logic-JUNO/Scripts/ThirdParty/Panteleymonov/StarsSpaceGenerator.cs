using UnityEngine;

namespace Panteleymonov
{
	[ExecuteInEditMode]
	[AddComponentMenu("Space/SkyBox/StarsSpaceGenerator")]
	public class StarsSpaceGenerator : MonoBehaviour
	{
		public enum EFaseSize
		{
			_16 = 0x10,
			_32 = 0x20,
			_64 = 0x40,
			_128 = 0x80,
			_256 = 0x100,
			_512 = 0x200,
			_1024 = 0x400,
			_2048 = 0x800
		}

		public enum EUpdateType
		{
			Manual = 0,
			RealTime = 1
		}

		[Header("Stars Colors")]
		[Tooltip("Color circle of stars")]
		public Color StarsColor1 = new Color(1f, 0f, 0f, 1f);

		[Tooltip("Color circle of stars")]
		public Color StarsColor2 = new Color(0f, 0f, 1f, 1f);

		[Tooltip("Main color of stars")]
		public Color StarsPrimary = new Color(1f, 1f, 1f, 1f);

		[Header("Stars")]
		[Tooltip("Intensity of primary stars layer")]
		public float StarsBrightPrimary = 1f;

		[Tooltip("Intensity of second stars layer")]
		public float StarsBrightSecond = 0.5f;

		[Tooltip("Stars seed for both layers")]
		[Range(0f, 1000f)]
		public float StarsSeed = 1f;

		[Header("Cloud Colors")]
		[Tooltip("Color of space clouds")]
		public Color CloudColor1 = new Color(1f, 0f, 0f, 1f);

		[Tooltip("Color of space clouds")]
		public Color CloudColor2 = new Color(0f, 0f, 1f, 1f);

		[Tooltip("Main color of space clouds, all colors will be mixed with this")]
		public Color CloudPrimary = new Color(0.9f, 1f, 0.1f, 1f);

		[Header("Cloud")]
		[Tooltip("Main intensity of space clouds")]
		public float Bright = 1.5f;

		[Tooltip("Main scale of space clouds")]
		public float Zoom = 1f;

		[Tooltip("Interpolation between the two noise algorithms \"Voronoi\" and \"Perlin\"")]
		[Range(0f, 1f)]
		public float VoronoiPerlin = 0.5f;

		[Tooltip("Intensity of each of the following layer noise")]
		[Range(0.0001f, 1f)]
		public float LightStage = 0.8f;

		[Tooltip("Scale of each of the following layer noise")]
		[Range(0.0001f, 1f)]
		public float ScaleStage = 0.5f;

		[Tooltip("Space cloud seed")]
		[Range(0f, 1000f)]
		public float CloudSeed = 1f;

		[Header("Material Properties")]
		[Tooltip("Type of visual update metod, if use \"Real Time\" - this will give poor performance")]
		public EUpdateType UpdateType;

		[Tooltip("Size of texture for per side of cubemap")]
		public EFaseSize TextureSize = EFaseSize._512;

		[Tooltip("Exposure")]
		public float Exposure = 1f;

		private Material material;

		private Material preview;

		private Texture2D front;

		private Texture2D back;

		private Texture2D up;

		private Texture2D down;

		private Texture2D left;

		private Texture2D right;

		public static string[] MaterialTextureNames = new string[6] { "_FrontTex", "_BackTex", "_LeftTex", "_RightTex", "_UpTex", "_DownTex" };

		[Range(0f, 1f)]
		public float CloudBandSize = 0.5f;

		[Range(0f, 1f)]
		public float MinClouds = 0.1f;

		[Range(0f, 5f)]
		public float CloudPower = 1.4f;

		[Range(0f, 100f)]
		public int NumStarPasses = 50;

		[Range(0f, 100f)]
		public int NumCloudPasses = 25;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnValidate()
		{
			if (material != null && UpdateType != EUpdateType.RealTime)
			{
				RenderSettings.skybox = material;
				material.SetFloat("_Exposure", Exposure);
			}
			_ = UpdateType;
			_ = 1;
		}

		private void CheckTexture(ref Texture2D texture, int Size)
		{
			if (texture == null)
			{
				texture = new Texture2D(Size, Size, TextureFormat.ARGB32, mipChain: true);
				texture.wrapMode = TextureWrapMode.Clamp;
			}
			if (texture.width != Size)
			{
				texture.Reinitialize(Size, Size);
			}
		}

		private void InitMaterial()
		{
			if (material == null)
			{
				material = new Material(Shader.Find("RenderFX/Skybox"));
			}
			CheckTexture(ref front, (int)TextureSize);
			CheckTexture(ref back, (int)TextureSize);
			CheckTexture(ref up, (int)TextureSize);
			CheckTexture(ref down, (int)TextureSize);
			CheckTexture(ref left, (int)TextureSize);
			CheckTexture(ref right, (int)TextureSize);
			RenderSettings.skybox = material;
		}

		private void InitPreview()
		{
			if (preview == null)
			{
				preview = new Material(Shader.Find("Space/Sky Box/Stars Space"));
			}
			UpdatePreview();
			RenderSettings.skybox = preview;
		}

		public void UpdateTexturesCubeMap(ComputeShader shader)
		{
			InitMaterial();
			int textureSize = (int)TextureSize;
			RenderTexture renderTexture = new RenderTexture(textureSize, textureSize, 0);
			renderTexture.enableRandomWrite = true;
			renderTexture.Create();
			int kernelIndex = shader.FindKernel("StarSpaceGenerator");
			shader.SetFloat("Zoom", Zoom);
			shader.SetFloat("VPMix", VoronoiPerlin);
			shader.SetFloat("LightStage", LightStage);
			shader.SetFloat("ScaleStage", ScaleStage);
			shader.SetFloat("Bright", Bright);
			shader.SetFloat("CloudSeed", CloudSeed);
			shader.SetFloat("StarsSeed", StarsSeed);
			shader.SetVector("CloudColor1", CloudColor1);
			shader.SetVector("CloudColor2", CloudColor2);
			shader.SetVector("CloudColor3", CloudPrimary);
			shader.SetVector("StarsColor1", StarsColor1);
			shader.SetVector("StarsColor2", StarsColor2);
			shader.SetVector("StarsColor3", StarsPrimary);
			shader.SetFloat("FirstStarsBright", StarsBrightPrimary);
			shader.SetFloat("SecondStarsBright", StarsBrightSecond);
			shader.SetFloat("TextureSize", 1f / (float)textureSize);
			shader.SetFloat("MinClouds", MinClouds);
			shader.SetFloat("CloudBandSize", CloudBandSize);
			shader.SetFloat("CloudPower", CloudPower);
			shader.SetInt("NumStarPasses", NumStarPasses);
			shader.SetInt("NumCloudPasses", NumCloudPasses);
			shader.SetTexture(kernelIndex, "Result", renderTexture);
			int num = textureSize / 16;
			Texture2D[] textures = GetTextures();
			for (int i = 0; i < 6; i++)
			{
				shader.SetInt("Side", i);
				shader.Dispatch(kernelIndex, num, num, 1);
				RenderTexture.active = renderTexture;
				textures[i].ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
				textures[i].Apply();
				material.SetTexture(MaterialTextureNames[i], textures[i]);
			}
		}

		private void UpdatePreview()
		{
			preview.SetFloat("_Exposure", Exposure);
			preview.SetFloat("_Zoom", Zoom);
			preview.SetFloat("_VPMix", VoronoiPerlin);
			preview.SetFloat("_LightStage", LightStage);
			preview.SetFloat("_ScaleStage", ScaleStage);
			preview.SetFloat("_Bright", Bright);
			preview.SetFloat("_CloudSeed", CloudSeed);
			preview.SetFloat("_StarsSeed", StarsSeed);
			preview.SetVector("_CloudColor1", CloudColor1);
			preview.SetVector("_CloudColor2", CloudColor2);
			preview.SetVector("_CloudColor3", CloudPrimary);
			preview.SetVector("_StarsColor1", StarsColor1);
			preview.SetVector("_StarsColor2", StarsColor2);
			preview.SetVector("_StarsColor3", StarsPrimary);
			preview.SetFloat("_FirstStarsBright", StarsBrightPrimary);
			preview.SetFloat("_SecondStarsBright", StarsBrightSecond);
			preview.SetFloat("_MinClouds", MinClouds);
			preview.SetFloat("_CloudBandSize", CloudBandSize);
			preview.SetFloat("_CloudPower", CloudPower);
			RenderSettings.skybox = preview;
		}

		public Texture2D[] GetTextures()
		{
			return new Texture2D[6] { front, back, left, right, up, down };
		}

		public Material GetMaterial()
		{
			return material;
		}
	}
}
