using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LeTai.Asset.TranslucentImage
{
	public class TranslucentImage : Image, IMeshModifier
	{
		public TranslucentImageSource source;

		public float vibrancy = 1f;

		public float brightness;

		public float flatten = 0.1f;

		private Shader correctShader;

		private static readonly int _vibrancyPropId = Shader.PropertyToID("_Vibrancy");

		private static readonly int _brightnessPropId = Shader.PropertyToID("_Brightness");

		private static readonly int _flattenPropId = Shader.PropertyToID("_Flatten");

		private static readonly int _blurTexPropId = Shader.PropertyToID("_BlurTex");

		private static readonly int _cropRegionPropId = Shader.PropertyToID("_CropRegion");

		private Material replacedMaterial;

		private float oldVibrancy;

		private float oldBrightness;

		private float oldFlatten;

		public float spriteBlending = 0.65f;

		protected override void Start()
		{
			base.Start();
			PrepareShader();
			oldVibrancy = vibrancy;
			oldBrightness = brightness;
			oldFlatten = flatten;
			source = (source ? source : Object.FindObjectOfType<TranslucentImageSource>());
			if ((bool)source)
			{
				material.SetTexture(_blurTexPropId, source.BlurredScreen);
				if ((bool)base.canvas)
				{
					base.canvas.additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord1;
				}
			}
		}

		private void PrepareShader()
		{
			correctShader = Shader.Find("UI/TranslucentImage");
		}

		private void LateUpdate()
		{
			if ((bool)source && IsActive() && (bool)source.BlurredScreen)
			{
				if (!material || material.shader != correctShader)
				{
					Debug.LogError("Translucent Image require a material using \"UI/TranslucentImage\" shader");
				}
				if ((bool)replacedMaterial)
				{
					replacedMaterial.SetTexture(_blurTexPropId, source.BlurredScreen);
					replacedMaterial.SetVector(_cropRegionPropId, Extensions.ToMinMaxVector(source.BlurRegionNormalizedScreenSpace));
				}
				else
				{
					material.SetTexture(_blurTexPropId, source.BlurredScreen);
					material.SetVector(_cropRegionPropId, Extensions.ToMinMaxVector(source.BlurRegionNormalizedScreenSpace));
				}
			}
		}

		private void Update()
		{
			if (_vibrancyPropId != 0 && _brightnessPropId != 0 && _flattenPropId != 0)
			{
				replacedMaterial = materialForRendering;
				SyncMaterialProperty(_vibrancyPropId, ref vibrancy, ref oldVibrancy);
				SyncMaterialProperty(_brightnessPropId, ref brightness, ref oldBrightness);
				SyncMaterialProperty(_flattenPropId, ref flatten, ref oldFlatten);
			}
		}

		private void SyncMaterialProperty(int propId, ref float value, ref float oldValue)
		{
			float num = materialForRendering.GetFloat(propId);
			if ((double)Mathf.Abs(num - value) > 0.0001)
			{
				if ((double)Mathf.Abs(value - oldValue) > 0.0001)
				{
					if ((bool)replacedMaterial)
					{
						replacedMaterial.SetFloat(propId, value);
					}
					material.SetFloat(propId, value);
					SetMaterialDirty();
				}
				else
				{
					value = num;
				}
			}
			oldValue = value;
		}

		public virtual void ModifyMesh(VertexHelper vh)
		{
			List<UIVertex> list = new List<UIVertex>();
			vh.GetUIVertexStream(list);
			for (int i = 0; i < list.Count; i++)
			{
				UIVertex value = list[i];
				value.uv1 = new Vector2(spriteBlending, 0f);
				list[i] = value;
			}
			vh.Clear();
			vh.AddUIVertexTriangleStream(list);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			SetVerticesDirty();
		}

		protected override void OnDisable()
		{
			SetVerticesDirty();
			base.OnDisable();
		}

		protected override void OnDidApplyAnimationProperties()
		{
			SetVerticesDirty();
			base.OnDidApplyAnimationProperties();
		}

		public virtual void ModifyMesh(Mesh mesh)
		{
			using VertexHelper vertexHelper = new VertexHelper(mesh);
			ModifyMesh(vertexHelper);
			vertexHelper.FillMesh(mesh);
		}
	}
}
