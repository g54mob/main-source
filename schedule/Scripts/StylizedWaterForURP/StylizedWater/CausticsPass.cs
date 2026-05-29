using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace StylizedWater
{
	public class CausticsPass : ScriptableRenderPass
	{
		private const string profilerTag = "Caustics Pass";

		public Material causticsMaterial;

		private static Mesh mesh;

		private float waterLevel;

		private const float BIAS = 0.1f;

		public CausticsPass(float waterLevel)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}

		private static Mesh GenerateQuad(float size)
		{
			return null;
		}
	}
}
