using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class RenderScaleConnection : Connection<float>
	{
		public bool ReapplyOnQualityChange;

		public float DefaultRenderScale = 1f;

		[NonSerialized]
		protected float scale = -1f;

		public UniversalRenderPipelineAsset QualityRenderAsset => QualitySettings.GetRenderPipelineAssetAt(QualitySettings.GetQualityLevel()) as UniversalRenderPipelineAsset;

		public override float Get()
		{
			if (scale < 0f)
			{
				scale = DefaultRenderScale;
			}
			if (QualityRenderAsset != null)
			{
				scale = QualityRenderAsset.renderScale;
			}
			return scale;
		}

		public override void Set(float scale)
		{
			if (QualityRenderAsset != null)
			{
				QualityRenderAsset.renderScale = scale;
			}
			this.scale = scale;
		}

		public override void OnQualityChanged(int qualityLevel)
		{
			if (ReapplyOnQualityChange)
			{
				Set(scale);
			}
			base.OnQualityChanged(qualityLevel);
		}
	}
}
