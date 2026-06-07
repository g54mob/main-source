using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace JBooth.MicroVerseCore
{
	public class MapGen
	{
		private static Shader curvatureShader = null;

		private static ComputeShader flowShader = null;

		private static int _Width = Shader.PropertyToID("_Width");

		private static int _Height = Shader.PropertyToID("_Height");

		private static int _WaterMap = Shader.PropertyToID("_WaterMap");

		private static int _OutFlow = Shader.PropertyToID("_OutFlow");

		private static int _HeightMap = Shader.PropertyToID("_HeightMap");

		private static int _VelocityMap = Shader.PropertyToID("_VelocityMap");

		private static Shader normalShader = null;

		private static int _Heightmap = Shader.PropertyToID("_Heightmap");

		private static int _Heightmap_PX = Shader.PropertyToID("_Heightmap_PX");

		private static int _Heightmap_PY = Shader.PropertyToID("_Heightmap_PY");

		private static int _Heightmap_NX = Shader.PropertyToID("_Heightmap_NX");

		private static int _Heightmap_NY = Shader.PropertyToID("_Heightmap_NY");

		public static RenderTexture GenerateCurvatureMap(Terrain t, Dictionary<Terrain, RenderTexture> normals, int width, int height)
		{
			if (curvatureShader == null)
			{
				curvatureShader = Shader.Find("Hidden/MicroVerse/CurvatureMapGen");
			}
			Material material = new Material(curvatureShader);
			RenderTextureDescriptor desc = new RenderTextureDescriptor(width, height, RenderTextureFormat.ARGB32);
			desc.colorFormat = RenderTextureFormat.R8;
			desc.useMipMap = true;
			RenderTexture temporary = RenderTexture.GetTemporary(desc);
			temporary.wrapMode = TextureWrapMode.Clamp;
			RenderTexture.active = temporary;
			material.SetTexture("_Normalmap", normals[t]);
			if ((bool)t.leftNeighbor && normals.ContainsKey(t.leftNeighbor))
			{
				material.SetTexture("_Normalmap_NX", normals[t.leftNeighbor]);
				material.EnableKeyword("_NX");
			}
			if ((bool)t.rightNeighbor && normals.ContainsKey(t.rightNeighbor))
			{
				material.SetTexture("_Normalmap_PX", normals[t.rightNeighbor]);
				material.EnableKeyword("_PX");
			}
			if ((bool)t.bottomNeighbor && normals.ContainsKey(t.bottomNeighbor))
			{
				material.SetTexture("_Normalmap_NY", normals[t.bottomNeighbor]);
				material.EnableKeyword("_NY");
			}
			if ((bool)t.topNeighbor && normals.ContainsKey(t.topNeighbor))
			{
				material.SetTexture("_Normalmap_PY", normals[t.topNeighbor]);
				material.EnableKeyword("_PY");
			}
			Graphics.Blit(null, temporary, material);
			Object.DestroyImmediate(material);
			return temporary;
		}

		public static RenderTexture QuadCombine(Terrain t, Dictionary<Terrain, RenderTexture> tempRenderData, int borderPixels = 32)
		{
			RenderTexture renderTexture = tempRenderData[t];
			RenderTexture temporary = RenderTexture.GetTemporary(renderTexture.width + borderPixels * 2, renderTexture.height + borderPixels * 2, 0, renderTexture.format);
			Graphics.CopyTexture(renderTexture, 0, 0, 0, 0, renderTexture.width, renderTexture.height, temporary, 0, 0, borderPixels, borderPixels);
			temporary.name = "MicroVerse::NineCombine";
			if (t.topNeighbor != null && tempRenderData.ContainsKey(t.topNeighbor))
			{
				Graphics.CopyTexture(tempRenderData[t.topNeighbor], 0, 0, 0, 0, renderTexture.width, borderPixels, temporary, 0, 0, borderPixels, temporary.height - borderPixels);
			}
			if ((bool)t.leftNeighbor && tempRenderData.ContainsKey(t.leftNeighbor))
			{
				Graphics.CopyTexture(tempRenderData[t.leftNeighbor], 0, 0, renderTexture.width - borderPixels, 0, borderPixels, renderTexture.height, temporary, 0, 0, 0, borderPixels);
			}
			if ((bool)t.rightNeighbor && tempRenderData.ContainsKey(t.rightNeighbor))
			{
				Graphics.CopyTexture(tempRenderData[t.rightNeighbor], 0, 0, 0, 0, borderPixels, renderTexture.height, temporary, 0, 0, temporary.width - borderPixels, borderPixels);
			}
			if (t.bottomNeighbor != null && tempRenderData.ContainsKey(t.bottomNeighbor))
			{
				Graphics.CopyTexture(tempRenderData[t.bottomNeighbor], 0, 0, 0, renderTexture.height - borderPixels, renderTexture.width, borderPixels, temporary, 0, 0, borderPixels, 0);
			}
			return temporary;
		}

		public static RenderTexture NineCombine(Terrain t, Dictionary<Terrain, RenderTexture> tempRenderData, int borderPixels = 32)
		{
			RenderTexture renderTexture = tempRenderData[t];
			RenderTexture temporary = RenderTexture.GetTemporary(renderTexture.width + borderPixels * 2, renderTexture.height + borderPixels * 2, 0, renderTexture.format);
			Graphics.CopyTexture(renderTexture, 0, 0, 0, 0, renderTexture.width, renderTexture.height, temporary, 0, 0, borderPixels, borderPixels);
			temporary.name = "MicroVerse::NineCombine";
			if (t.topNeighbor != null)
			{
				if (tempRenderData.ContainsKey(t.topNeighbor))
				{
					Graphics.CopyTexture(tempRenderData[t.topNeighbor], 0, 0, 0, 0, renderTexture.width, borderPixels, temporary, 0, 0, borderPixels, temporary.height - borderPixels);
				}
				if (t.topNeighbor.leftNeighbor != null && tempRenderData.ContainsKey(t.topNeighbor.leftNeighbor))
				{
					Graphics.CopyTexture(tempRenderData[t.topNeighbor.leftNeighbor], 0, 0, renderTexture.width - borderPixels, 0, borderPixels, borderPixels, temporary, 0, 0, 0, temporary.height - borderPixels);
				}
				if (t.topNeighbor.rightNeighbor != null && tempRenderData.ContainsKey(t.topNeighbor.rightNeighbor))
				{
					Graphics.CopyTexture(tempRenderData[t.topNeighbor.rightNeighbor], 0, 0, 0, 0, borderPixels, borderPixels, temporary, 0, 0, temporary.width - borderPixels, temporary.height - borderPixels);
				}
			}
			if ((bool)t.leftNeighbor && tempRenderData.ContainsKey(t.leftNeighbor))
			{
				Graphics.CopyTexture(tempRenderData[t.leftNeighbor], 0, 0, renderTexture.width - borderPixels, 0, borderPixels, renderTexture.height, temporary, 0, 0, 0, borderPixels);
			}
			if ((bool)t.rightNeighbor && tempRenderData.ContainsKey(t.rightNeighbor))
			{
				Graphics.CopyTexture(tempRenderData[t.rightNeighbor], 0, 0, 0, 0, borderPixels, renderTexture.height, temporary, 0, 0, temporary.width - borderPixels, borderPixels);
			}
			if (t.bottomNeighbor != null)
			{
				if (tempRenderData.ContainsKey(t.bottomNeighbor))
				{
					Graphics.CopyTexture(tempRenderData[t.bottomNeighbor], 0, 0, 0, renderTexture.height - borderPixels, renderTexture.width, borderPixels, temporary, 0, 0, borderPixels, 0);
				}
				if (t.bottomNeighbor.leftNeighbor != null && tempRenderData.ContainsKey(t.bottomNeighbor.leftNeighbor))
				{
					Graphics.CopyTexture(tempRenderData[t.bottomNeighbor.leftNeighbor], 0, 0, renderTexture.width - borderPixels, renderTexture.height - borderPixels, borderPixels, borderPixels, temporary, 0, 0, 0, 0);
				}
				if (t.bottomNeighbor.rightNeighbor != null && tempRenderData.ContainsKey(t.bottomNeighbor.rightNeighbor))
				{
					Graphics.CopyTexture(tempRenderData[t.bottomNeighbor.rightNeighbor], 0, 0, 0, renderTexture.height - borderPixels, borderPixels, borderPixels, temporary, 0, 0, temporary.width - borderPixels, 0);
				}
			}
			return temporary;
		}

		public static RenderTexture NineCombineCurrentTreeMask(Terrain t, Dictionary<Terrain, OcclusionData> tempRenderData, int borderPixels = 32)
		{
			RenderTexture currentTreeMask = tempRenderData[t].currentTreeMask;
			RenderTexture temporary = RenderTexture.GetTemporary(currentTreeMask.width + borderPixels * 2, currentTreeMask.height + borderPixels * 2, 0, RenderTextureFormat.R8, RenderTextureReadWrite.Linear);
			Graphics.CopyTexture(currentTreeMask, 0, 0, 0, 0, currentTreeMask.width, currentTreeMask.height, temporary, 0, 0, borderPixels, borderPixels);
			temporary.name = "MicroVerse::NineCombine";
			if (t.topNeighbor != null)
			{
				if (tempRenderData.ContainsKey(t.topNeighbor) && tempRenderData[t.topNeighbor].currentTreeMask != null)
				{
					Graphics.CopyTexture(tempRenderData[t.topNeighbor].currentTreeMask, 0, 0, 0, 0, currentTreeMask.width, borderPixels, temporary, 0, 0, borderPixels, temporary.height - borderPixels);
				}
				if (t.topNeighbor.leftNeighbor != null && tempRenderData.ContainsKey(t.topNeighbor.leftNeighbor) && tempRenderData[t.topNeighbor.leftNeighbor].currentTreeMask != null)
				{
					Graphics.CopyTexture(tempRenderData[t.topNeighbor.leftNeighbor].currentTreeMask, 0, 0, currentTreeMask.width - borderPixels, 0, borderPixels, borderPixels, temporary, 0, 0, 0, temporary.height - borderPixels);
				}
				if (t.topNeighbor.rightNeighbor != null && tempRenderData.ContainsKey(t.topNeighbor.rightNeighbor) && tempRenderData[t.topNeighbor.rightNeighbor].currentTreeMask != null)
				{
					Graphics.CopyTexture(tempRenderData[t.topNeighbor.rightNeighbor].currentTreeMask, 0, 0, 0, 0, borderPixels, borderPixels, temporary, 0, 0, temporary.width - borderPixels, temporary.height - borderPixels);
				}
			}
			if ((bool)t.leftNeighbor && tempRenderData.ContainsKey(t.leftNeighbor) && tempRenderData[t.leftNeighbor].currentTreeMask != null)
			{
				Graphics.CopyTexture(tempRenderData[t.leftNeighbor].currentTreeMask, 0, 0, currentTreeMask.width - borderPixels, 0, borderPixels, currentTreeMask.height, temporary, 0, 0, 0, borderPixels);
			}
			if ((bool)t.rightNeighbor && tempRenderData.ContainsKey(t.rightNeighbor) && tempRenderData[t.rightNeighbor].currentTreeMask != null)
			{
				Graphics.CopyTexture(tempRenderData[t.rightNeighbor].currentTreeMask, 0, 0, 0, 0, borderPixels, currentTreeMask.height, temporary, 0, 0, temporary.width - borderPixels, borderPixels);
			}
			if (t.bottomNeighbor != null)
			{
				if (tempRenderData.ContainsKey(t.bottomNeighbor) && tempRenderData[t.bottomNeighbor].currentTreeMask != null)
				{
					Graphics.CopyTexture(tempRenderData[t.bottomNeighbor].currentTreeMask, 0, 0, 0, currentTreeMask.height - borderPixels, currentTreeMask.width, borderPixels, temporary, 0, 0, borderPixels, 0);
				}
				if (t.bottomNeighbor.leftNeighbor != null && tempRenderData.ContainsKey(t.bottomNeighbor.leftNeighbor) && tempRenderData[t.bottomNeighbor.leftNeighbor].currentTreeMask != null)
				{
					Graphics.CopyTexture(tempRenderData[t.bottomNeighbor.leftNeighbor].currentTreeMask, 0, 0, currentTreeMask.width - borderPixels, currentTreeMask.height - borderPixels, borderPixels, borderPixels, temporary, 0, 0, 0, 0);
				}
				if (t.bottomNeighbor.rightNeighbor != null && tempRenderData.ContainsKey(t.bottomNeighbor.rightNeighbor) && tempRenderData[t.bottomNeighbor.rightNeighbor].currentTreeMask != null)
				{
					Graphics.CopyTexture(tempRenderData[t.bottomNeighbor.rightNeighbor].currentTreeMask, 0, 0, 0, currentTreeMask.height - borderPixels, borderPixels, borderPixels, temporary, 0, 0, temporary.width - borderPixels, 0);
				}
			}
			return temporary;
		}

		public static RenderTexture NineCombineCurrentObjectMask(Terrain t, Dictionary<Terrain, OcclusionData> tempRenderData, int borderPixels = 32)
		{
			RenderTexture currentObjectMask = tempRenderData[t].currentObjectMask;
			RenderTexture temporary = RenderTexture.GetTemporary(currentObjectMask.width + borderPixels * 2, currentObjectMask.height + borderPixels * 2, 0, currentObjectMask.format);
			Graphics.CopyTexture(currentObjectMask, 0, 0, 0, 0, currentObjectMask.width, currentObjectMask.height, temporary, 0, 0, borderPixels, borderPixels);
			temporary.name = "MicroVerse::NineCombine";
			if (t.topNeighbor != null)
			{
				if (tempRenderData.ContainsKey(t.topNeighbor) && tempRenderData[t.topNeighbor].currentObjectMask != null)
				{
					Graphics.CopyTexture(tempRenderData[t.topNeighbor].currentObjectMask, 0, 0, 0, 0, currentObjectMask.width, borderPixels, temporary, 0, 0, borderPixels, temporary.height - borderPixels);
				}
				if (t.topNeighbor.leftNeighbor != null && tempRenderData.ContainsKey(t.topNeighbor.leftNeighbor) && tempRenderData[t.topNeighbor.leftNeighbor].currentObjectMask != null)
				{
					Graphics.CopyTexture(tempRenderData[t.topNeighbor.leftNeighbor].currentObjectMask, 0, 0, currentObjectMask.width - borderPixels, 0, borderPixels, borderPixels, temporary, 0, 0, 0, temporary.height - borderPixels);
				}
				if (t.topNeighbor.rightNeighbor != null && tempRenderData.ContainsKey(t.topNeighbor.rightNeighbor) && tempRenderData[t.topNeighbor.rightNeighbor].currentObjectMask != null)
				{
					Graphics.CopyTexture(tempRenderData[t.topNeighbor.rightNeighbor].currentObjectMask, 0, 0, 0, 0, borderPixels, borderPixels, temporary, 0, 0, temporary.width - borderPixels, temporary.height - borderPixels);
				}
			}
			if ((bool)t.leftNeighbor && tempRenderData.ContainsKey(t.leftNeighbor) && tempRenderData[t.leftNeighbor].currentObjectMask != null)
			{
				Graphics.CopyTexture(tempRenderData[t.leftNeighbor].currentObjectMask, 0, 0, currentObjectMask.width - borderPixels, 0, borderPixels, currentObjectMask.height, temporary, 0, 0, 0, borderPixels);
			}
			if ((bool)t.rightNeighbor && tempRenderData.ContainsKey(t.rightNeighbor) && tempRenderData[t.rightNeighbor].currentObjectMask != null)
			{
				Graphics.CopyTexture(tempRenderData[t.rightNeighbor].currentObjectMask, 0, 0, 0, 0, borderPixels, currentObjectMask.height, temporary, 0, 0, temporary.width - borderPixels, borderPixels);
			}
			if (t.bottomNeighbor != null)
			{
				if (tempRenderData.ContainsKey(t.bottomNeighbor) && tempRenderData[t.bottomNeighbor].currentObjectMask != null)
				{
					Graphics.CopyTexture(tempRenderData[t.bottomNeighbor].currentObjectMask, 0, 0, 0, currentObjectMask.height - borderPixels, currentObjectMask.width, borderPixels, temporary, 0, 0, borderPixels, 0);
				}
				if (t.bottomNeighbor.leftNeighbor != null && tempRenderData.ContainsKey(t.bottomNeighbor.leftNeighbor) && tempRenderData[t.bottomNeighbor.leftNeighbor].currentObjectMask != null)
				{
					Graphics.CopyTexture(tempRenderData[t.bottomNeighbor.leftNeighbor].currentObjectMask, 0, 0, currentObjectMask.width - borderPixels, currentObjectMask.height - borderPixels, borderPixels, borderPixels, temporary, 0, 0, 0, 0);
				}
				if (t.bottomNeighbor.rightNeighbor != null && tempRenderData.ContainsKey(t.bottomNeighbor.rightNeighbor) && tempRenderData[t.bottomNeighbor.rightNeighbor].currentObjectMask != null)
				{
					Graphics.CopyTexture(tempRenderData[t.bottomNeighbor.rightNeighbor].currentObjectMask, 0, 0, 0, currentObjectMask.height - borderPixels, borderPixels, borderPixels, temporary, 0, 0, temporary.width - borderPixels, 0);
				}
			}
			return temporary;
		}

		public static RenderTexture GenerateFlowMap(Terrain t, Dictionary<Terrain, RenderTexture> heights)
		{
			int num = 5;
			float r = 0.00013f;
			int num2 = 16;
			int num3 = 512;
			int num4 = Mathf.RoundToInt(num2 / (heights[t].width / num3));
			int num5 = num3 + num4 * 2;
			if (flowShader == null)
			{
				flowShader = Resources.Load<ComputeShader>("MicroVerseComputeFlowMap");
			}
			RenderTexture renderTexture = QuadCombine(t, heights, num2);
			RenderTexture temporary = RenderTexture.GetTemporary(num3, num3, 0, renderTexture.format);
			Graphics.Blit(renderTexture, temporary);
			RenderTexture.ReleaseTemporary(renderTexture);
			RenderTexture renderTexture2 = new RenderTexture(num5, num5, 0, RenderTextureFormat.RHalf, 0);
			RenderTexture renderTexture3 = new RenderTexture(num5, num5, 0, RenderTextureFormat.ARGBHalf, 0);
			renderTexture2.enableRandomWrite = true;
			renderTexture3.enableRandomWrite = true;
			RenderTextureDescriptor desc = new RenderTextureDescriptor(num5, num5, RenderTextureFormat.R8, 0);
			desc.enableRandomWrite = true;
			desc.useMipMap = false;
			RenderTexture temporary2 = RenderTexture.GetTemporary(desc);
			temporary2.enableRandomWrite = true;
			RenderTexture.active = renderTexture2;
			GL.Clear(clearDepth: false, clearColor: true, new Color(r, 0f, 0f, 0f));
			int kernelIndex = flowShader.FindKernel("CSComputeOutflow");
			int kernelIndex2 = flowShader.FindKernel("CSUpdateWater");
			int kernelIndex3 = flowShader.FindKernel("CSVelocityField");
			int num6 = 16;
			int threadGroupsX = Mathf.CeilToInt(num5 / num6);
			int threadGroupsY = Mathf.CeilToInt(num5 / num6);
			flowShader.SetInt(_Width, num5);
			flowShader.SetInt(_Height, num5);
			flowShader.SetTexture(kernelIndex, _WaterMap, renderTexture2);
			flowShader.SetTexture(kernelIndex, _OutFlow, renderTexture3);
			flowShader.SetTexture(kernelIndex, _HeightMap, temporary);
			flowShader.SetTexture(kernelIndex, _VelocityMap, temporary2);
			flowShader.SetTexture(kernelIndex2, _WaterMap, renderTexture2);
			flowShader.SetTexture(kernelIndex2, _OutFlow, renderTexture3);
			flowShader.SetTexture(kernelIndex2, _VelocityMap, temporary2);
			for (int i = 0; i < num; i++)
			{
				flowShader.Dispatch(kernelIndex, threadGroupsX, threadGroupsY, 1);
				flowShader.Dispatch(kernelIndex2, threadGroupsX, threadGroupsY, 1);
			}
			flowShader.SetTexture(kernelIndex3, _OutFlow, renderTexture3);
			flowShader.SetTexture(kernelIndex3, _VelocityMap, temporary2);
			flowShader.Dispatch(kernelIndex3, threadGroupsX, threadGroupsY, 1);
			RenderTexture.active = null;
			Object.DestroyImmediate(renderTexture2);
			Object.DestroyImmediate(renderTexture3);
			RenderTexture.ReleaseTemporary(temporary);
			desc.width = num3;
			desc.height = num3;
			RenderTexture temporary3 = RenderTexture.GetTemporary(desc);
			Graphics.CopyTexture(temporary2, 0, 0, num4, num4, num3, num3, temporary3, 0, 0, 0, 0);
			RenderTexture.ReleaseTemporary(temporary2);
			return temporary3;
		}

		public static RenderTexture GenerateNormalMap(Terrain t, Dictionary<Terrain, RenderTexture> heightMaps, int width, int height)
		{
			if (normalShader == null)
			{
				normalShader = Shader.Find("Hidden/MicroVerse/NormalMapGen");
			}
			Material material = new Material(normalShader);
			RenderTextureDescriptor desc = new RenderTextureDescriptor(width, height, RenderTextureFormat.ARGB32, 0);
			desc.useMipMap = true;
			RenderTexture temporary = RenderTexture.GetTemporary(desc);
			temporary.wrapMode = TextureWrapMode.Clamp;
			RenderTexture.active = temporary;
			material.SetTexture(_Heightmap, heightMaps[t]);
			if ((bool)t.rightNeighbor && heightMaps.ContainsKey(t.rightNeighbor))
			{
				material.SetTexture(_Heightmap_PX, heightMaps[t.rightNeighbor]);
				material.SetKeyword(new LocalKeyword(material.shader, "_PX"), value: true);
			}
			if ((bool)t.topNeighbor && heightMaps.ContainsKey(t.topNeighbor))
			{
				material.SetTexture(_Heightmap_PY, heightMaps[t.topNeighbor]);
				material.SetKeyword(new LocalKeyword(material.shader, "_PY"), value: true);
			}
			if ((bool)t.leftNeighbor && heightMaps.ContainsKey(t.leftNeighbor))
			{
				material.SetTexture(_Heightmap_NX, heightMaps[t.leftNeighbor]);
				material.EnableKeyword("_NX");
			}
			if ((bool)t.bottomNeighbor && heightMaps.ContainsKey(t.bottomNeighbor))
			{
				material.SetTexture(_Heightmap_NY, heightMaps[t.bottomNeighbor]);
				material.EnableKeyword("_NY");
			}
			Graphics.Blit(null, temporary, material);
			Object.DestroyImmediate(material);
			return temporary;
		}
	}
}
