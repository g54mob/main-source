using System;
using System.Diagnostics;
using LeTai.Common;
using LeTai.Paraform.Scaffold;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LeTai.Asset.TranslucentImage
{
	[HelpURL("https://leloctai.com/asset/translucentimage/docs/articles/customize.html#translucent-image")]
	public class TranslucentImage : Image, IActiveRegionProvider, IMeshModifier
	{
		[FormerlySerializedAs("source")]
		[Tooltip("Source of the blurred background for this image")]
		[SerializeField]
		private TranslucentImageSource _source;

		[FormerlySerializedAs("spriteBlending")]
		[FormerlySerializedAs("m_spriteBlending")]
		[Tooltip("How much Sprite and Color contribute to the Image. Use this instead of Color.alpha")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _foregroundOpacity;

		[Range(-1f, 2f)]
		[Tooltip("(De)Saturate the image, 1 is normal, 0 is grey scale, below zero make the image negative")]
		[FormerlySerializedAs("vibrancy")]
		[SerializeField]
		private float _vibrancy;

		[Range(-1f, 1f)]
		[SerializeField]
		[Tooltip("In Normal Background Mode: Brighten/darken the background. In Colorful Background Mode: Set the background overall brightness.")]
		[FormerlySerializedAs("brightness")]
		private float _brightness;

		[FormerlySerializedAs("flatten")]
		[Tooltip("Flatten the color behind to maintain color contrast on varying backgrounds")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _flatten;

		private bool shouldRun;

		private bool isBirp;

		private TranslucentImageSource _sourcePrev;

		private bool sourceAcquiredOnStart;

		public ParaformConfig paraformConfig;

		private float etaCache;

		private float previousScale;

		public TranslucentImageSource source
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete("Use foregroundOpacity instead")]
		public float spriteBlending
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float foregroundOpacity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float vibrancy
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float brightness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float flatten
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override Material material
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override Material defaultMaterial => null;

		protected override void Start()
		{
		}

		protected override void OnEnable()
		{
		}

		private void ParaformConfigChanged()
		{
		}

		protected override void OnDisable()
		{
		}

		private void OnWillRenderCanvases()
		{
		}

		public bool HaveActiveRegion()
		{
			return false;
		}

		public void GetActiveRegion(VPMatrixCache vpMatrixCache, out ActiveRegion activeRegion)
		{
			activeRegion = default(ActiveRegion);
		}

		public static void CopyMaterialPropertiesTo(Material src, Material dst)
		{
		}

		private void ConnectSource(TranslucentImageSource source)
		{
		}

		private void DisconnectSource(TranslucentImageSource source)
		{
		}

		private void SetBlurTex()
		{
		}

		private void SetBlurRegion()
		{
		}

		private void OnDirtyMaterial()
		{
		}

		private bool IsInPrefabMode()
		{
			return false;
		}

		private void AutoAcquireSource()
		{
		}

		private void OnUndoRedoPerformed()
		{
		}

		private void WriteVertexData(ref SpanWriter<float> writer)
		{
		}

		public virtual void ModifyMesh(VertexHelper vh)
		{
		}

		public virtual void ModifyMesh(Mesh mesh)
		{
		}

		private static float GetMaxRefractionOffset(float minDistance, float eta)
		{
			return 0f;
		}

		[Conditional("LETAI_PARAFORM")]
		private void PadRectForRefraction(ref Rect rect)
		{
		}

		[Conditional("LETAI_PARAFORM")]
		private void CacheEta()
		{
		}

		[Conditional("LETAI_PARAFORM")]
		private void SetParaformShaderGlobal()
		{
		}

		[Conditional("LETAI_PARAFORM")]
		private void LateUpdate()
		{
		}

		[Conditional("LETAI_PARAFORM")]
		public static void CopyParaformMaterialPropertiesTo(Material src, Material dst)
		{
		}
	}
}
