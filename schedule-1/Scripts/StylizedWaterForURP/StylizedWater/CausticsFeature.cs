using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace StylizedWater
{
	public class CausticsFeature : ScriptableRendererFeature
	{
		[Serializable]
		public class CausticsSettings
		{
			public enum DebugMode
			{
				Disabled = 0,
				Caustics = 1,
				Mask = 2
			}

			[Range(0f, 3f)]
			[Header("Visuals")]
			public float strength;

			[Range(0f, 1f)]
			public float rgbSplit;

			[Range(0f, 1f)]
			public float shadowMask;

			[Header("Movement")]
			public Texture2D texture;

			[Range(0.1f, 10f)]
			public float scale;

			[Range(0f, 0.3f)]
			public float speed;

			[Header("Depth")]
			public float waterLevel;

			public Vector2 depth;

			[Range(0f, 1f)]
			public float fade;

			[Header("Rendering")]
			public RenderPassEvent renderPassEvent;

			public DebugMode debug;
		}

		public CausticsSettings settings;

		private CausticsPass causticsPass;

		[HideInInspector]
		[SerializeField]
		private Shader causticsShader;

		private Material causticsMaterial;

		private static readonly int SrcBlend;

		private static readonly int DstBlend;

		private static readonly int causticsTextureID;

		private static readonly int causticsStrengthID;

		private static readonly int causticsScaleID;

		private static readonly int causticsSpeedID;

		private static readonly int causticsSplitID;

		private static readonly int shadowMaskID;

		private static readonly int causticsFadeID;

		private static readonly int waterLevelID;

		private static readonly int causticsStartID;

		private static readonly int causticsEndID;

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}
	}
}
