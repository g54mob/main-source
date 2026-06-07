using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LeTai.Asset.TranslucentImage
{
	[HelpURL("https://leloctai.com/asset/translucentimage/docs/articles/customize.html#translucent-image")]
	public class TranslucentImage : Image, IMeshModifier, IActiveRegionProvider
	{
		[SerializeField]
		[FormerlySerializedAs("source")]
		private TranslucentImageSource _source;

		private Canvas Canvas;

		private bool shouldRun;

		private bool isBirp;

		private TranslucentImageSource _sourcePrev;

		private bool sourceAcquiredOnStart;

		[Tooltip("Blend between the sprite and background blur")]
		[Range(0f, 1f)]
		[FormerlySerializedAs("spriteBlending")]
		public float m_spriteBlending = 0.65f;

		public TranslucentImageSource source
		{
			get
			{
				return _source;
			}
			set
			{
				_source = value;
				if (!(_source == _sourcePrev))
				{
					DisconnectSource(_sourcePrev);
					ConnectSource(_source);
					_sourcePrev = source;
				}
			}
		}

		[Obsolete("Use Get/SetFloat(ShaderID.VIBRANCY) on material/materialForRendering directly instead")]
		public float vibrancy
		{
			get
			{
				return materialForRendering.GetFloat(ShaderID.VIBRANCY);
			}
			set
			{
				materialForRendering.SetFloat(ShaderID.VIBRANCY, value);
			}
		}

		[Obsolete("Use Get/SetFloat(ShaderID.BRIGHTNESS) on material/materialForRendering directly instead")]
		public float brightness
		{
			get
			{
				return materialForRendering.GetFloat(ShaderID.BRIGHTNESS);
			}
			set
			{
				materialForRendering.SetFloat(ShaderID.BRIGHTNESS, value);
			}
		}

		[Obsolete("Use Get/SetFloat(ShaderID.FLATTEN) on material/materialForRendering directly instead")]
		public float flatten
		{
			get
			{
				return materialForRendering.GetFloat(ShaderID.FLATTEN);
			}
			set
			{
				materialForRendering.SetFloat(ShaderID.FLATTEN, value);
			}
		}

		public float spriteBlending
		{
			get
			{
				return m_spriteBlending;
			}
			set
			{
				m_spriteBlending = value;
				SetVerticesDirty();
			}
		}

		protected override void Start()
		{
			isBirp = !GraphicsSettings.currentRenderPipeline;
			AutoAcquireSource();
			if ((bool)material)
			{
				if (Application.isPlaying && material.shader.name != "UI/TranslucentImage")
				{
					Debug.LogWarning("Translucent Image requires a material using the \"UI/TranslucentImage\" shader");
				}
				else if ((bool)source)
				{
					material.SetTexture(ShaderID.BLUR_TEX, source.BlurredScreen);
				}
			}
			m_OnDirtyMaterialCallback = (UnityAction)Delegate.Combine(m_OnDirtyMaterialCallback, new UnityAction(OnDirtyMaterial));
			if ((bool)Canvas)
			{
				Canvas.additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord1;
			}
		}

		protected override void OnEnable()
		{
			Canvas = base.canvas;
			base.OnEnable();
			SetVerticesDirty();
			ConnectSource(source);
			_sourcePrev = source;
		}

		protected override void OnDisable()
		{
			SetVerticesDirty();
			base.OnDisable();
			DisconnectSource(source);
		}

		private void Update()
		{
		}

		public bool HaveActiveRegion()
		{
			return IsActive();
		}

		public void GetActiveRegion(VPMatrixCache vpMatrixCache, out ActiveRegion activeRegion)
		{
			VPMatrixCache.Index vpMatrixCacheIndex;
			if (Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				vpMatrixCacheIndex = VPMatrixCache.Index.INVALID;
			}
			else
			{
				Camera worldCamera = Canvas.worldCamera;
				if (!worldCamera)
				{
					Debug.LogError("Translucent Image need an Event Camera for World Space Canvas");
					vpMatrixCacheIndex = VPMatrixCache.Index.INVALID;
				}
				else
				{
					vpMatrixCacheIndex = vpMatrixCache.IndexOf(worldCamera);
					if (!vpMatrixCacheIndex.IsValid())
					{
						vpMatrixCacheIndex = vpMatrixCache.Add(worldCamera);
					}
				}
			}
			activeRegion = new ActiveRegion(base.rectTransform.rect, base.rectTransform.localToWorldMatrix, vpMatrixCacheIndex);
		}

		public static void CopyMaterialPropertiesTo(Material src, Material dst)
		{
			dst.SetFloat(ShaderID.VIBRANCY, src.GetFloat(ShaderID.VIBRANCY));
			dst.SetFloat(ShaderID.BRIGHTNESS, src.GetFloat(ShaderID.BRIGHTNESS));
			dst.SetFloat(ShaderID.FLATTEN, src.GetFloat(ShaderID.FLATTEN));
		}

		private void ConnectSource(TranslucentImageSource source)
		{
			if ((bool)source)
			{
				source.RegisterActiveRegionProvider(this);
				source.blurredScreenChanged += SetBlurTex;
				source.blurRegionChanged += SetBlurRegion;
				SetBlurTex();
				SetBlurRegion();
			}
		}

		private void DisconnectSource(TranslucentImageSource source)
		{
			if ((bool)source)
			{
				source.UnRegisterActiveRegionProvider(this);
				source.blurredScreenChanged -= SetBlurTex;
				source.blurRegionChanged -= SetBlurRegion;
			}
		}

		private void SetBlurTex()
		{
			if ((bool)source)
			{
				materialForRendering.SetTexture(ShaderID.BLUR_TEX, source.BlurredScreen);
			}
		}

		private void SetBlurRegion()
		{
			if ((bool)source)
			{
				if (isBirp || Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
				{
					Vector4 value = RectUtils.ToMinMaxVector(source.BlurRegionNormalizedScreenSpace);
					materialForRendering.SetVector(ShaderID.CROP_REGION, value);
				}
				else
				{
					materialForRendering.SetVector(ShaderID.CROP_REGION, RectUtils.ToMinMaxVector(source.BlurRegion));
				}
			}
		}

		private void OnDirtyMaterial()
		{
			SetBlurTex();
			SetBlurRegion();
		}

		private bool IsInPrefabMode()
		{
			return false;
		}

		private void AutoAcquireSource()
		{
			if (!IsInPrefabMode() && !sourceAcquiredOnStart)
			{
				source = (source ? source : Shims.FindObjectOfType<TranslucentImageSource>());
				sourceAcquiredOnStart = true;
			}
		}

		private void ApplySerializedData()
		{
			source = _source;
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
