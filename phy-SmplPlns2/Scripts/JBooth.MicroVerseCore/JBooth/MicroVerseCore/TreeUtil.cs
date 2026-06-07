using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public class TreeUtil
	{
		private static ComputeShader occlusionShader = null;

		private static int _Result = Shader.PropertyToID("_Result");

		private static int _Positions = Shader.PropertyToID("_Positions");

		private static int _Result_Width = Shader.PropertyToID("_Result_Width");

		private static int _Result_Height = Shader.PropertyToID("_Result_Height");

		public static void ApplyOcclusion(RenderTexture positions, OcclusionData od, bool others, bool selfSDF)
		{
			if (!others && !selfSDF)
			{
				return;
			}
			if (occlusionShader == null)
			{
				occlusionShader = (ComputeShader)Resources.Load("MicroVersePositionToOcclusionMask");
			}
			occlusionShader.DisableKeyword("_R8");
			int kernelIndex = occlusionShader.FindKernel("CSMain");
			occlusionShader.SetTexture(kernelIndex, _Result, od.terrainMask);
			occlusionShader.SetTexture(kernelIndex, _Positions, positions);
			occlusionShader.SetInt(_Result_Width, od.terrainMask.width);
			occlusionShader.SetInt(_Result_Height, od.terrainMask.height);
			if (others)
			{
				occlusionShader.Dispatch(kernelIndex, Mathf.CeilToInt(positions.width / 512), positions.height, 1);
			}
			if (others || selfSDF)
			{
				occlusionShader.EnableKeyword("_R8");
				if (od.currentTreeMask == null)
				{
					RenderTextureDescriptor descriptor = od.terrainMask.descriptor;
					descriptor.colorFormat = RenderTextureFormat.R8;
					od.currentTreeMask = RenderTexture.GetTemporary(descriptor);
					RenderTexture.active = od.currentTreeMask;
					GL.Clear(clearDepth: false, clearColor: true, Color.clear);
					od.currentTreeMask.name = "Occlusion::CurrentTreeMask";
				}
				RenderTexture.active = od.currentTreeMask;
				GL.Clear(clearDepth: false, clearColor: true, Color.clear);
				occlusionShader.SetTexture(kernelIndex, _Result, od.currentTreeMask);
				occlusionShader.Dispatch(kernelIndex, Mathf.CeilToInt((float)positions.width / 256f), positions.height, 1);
			}
		}
	}
}
