using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace JBooth.MicroVerseCore
{
	public class OcclusionData : StampData
	{
		public RenderTexture terrainMask;

		public RenderTexture treeSDF;

		public RenderTexture currentTreeMask;

		public RenderTexture currentTreeSDF;

		public RenderTexture objectSDF;

		public RenderTexture currentObjectMask;

		public RenderTexture currentObjectSDF;

		public RenderTexture objectMask;

		private static Shader combineSDFShader;

		public OcclusionData(Terrain terrain, int maskSize)
			: base(terrain)
		{
			base.terrain = terrain;
			terrainMask = RenderTexture.GetTemporary(new RenderTextureDescriptor(maskSize, maskSize, RenderTextureFormat.ARGB32, 0, 0)
			{
				enableRandomWrite = true,
				autoGenerateMips = false
			});
			terrainMask.name = "OcclusionData::mask";
			terrainMask.wrapMode = TextureWrapMode.Clamp;
			RenderTexture.active = terrainMask;
			GL.Clear(clearDepth: false, clearColor: true, Color.clear);
			RenderTexture.active = null;
			RenderTextureDescriptor desc = new RenderTextureDescriptor(maskSize, maskSize, GraphicsFormat.R8_UNorm, 0, 0);
			objectMask = RenderTexture.GetTemporary(desc);
			objectMask.name = "OcclusionData::mask";
			objectMask.wrapMode = TextureWrapMode.Clamp;
			RenderTexture.active = objectMask;
			GL.Clear(clearDepth: false, clearColor: true, Color.clear);
			RenderTexture.active = null;
		}

		public void RenderTreeSDF(Terrain t, Dictionary<Terrain, OcclusionData> ods, bool others)
		{
			if (!ods.ContainsKey(t))
			{
				return;
			}
			RenderTexture renderTexture = ods[t].currentTreeMask;
			if (renderTexture == null)
			{
				return;
			}
			int borderPixels = (int)((float)renderTexture.width * 0.25f);
			RenderTexture renderTexture2 = MapGen.NineCombineCurrentTreeMask(t, ods, borderPixels);
			if (currentTreeSDF != null)
			{
				RenderTexture.active = null;
				RenderTexture.ReleaseTemporary(currentTreeSDF);
			}
			currentTreeSDF = JumpFloodSDF.CreateTemporaryRT(renderTexture2, 0, 1.25f, 2);
			RenderTexture.active = null;
			RenderTexture.ReleaseTemporary(renderTexture2);
			if (others)
			{
				if (combineSDFShader == null)
				{
					combineSDFShader = Shader.Find("Hidden/MicroVerse/CombineSDF");
				}
				Material material = new Material(combineSDFShader);
				RenderTexture temporary = RenderTexture.GetTemporary(currentTreeSDF.descriptor);
				temporary.name = "MicroVerse::CombinedTreeSDF";
				material.SetTexture("_SourceA", currentTreeSDF);
				material.SetTexture("_SourceB", treeSDF);
				Graphics.Blit(null, temporary, material);
				if (treeSDF != null)
				{
					RenderTexture.active = null;
					RenderTexture.ReleaseTemporary(treeSDF);
				}
				treeSDF = temporary;
			}
		}

		public void RenderObjectSDF(Terrain t, Dictionary<Terrain, OcclusionData> ods, bool others)
		{
			if (!ods.ContainsKey(t))
			{
				return;
			}
			RenderTexture renderTexture = ods[t].currentObjectMask;
			if (renderTexture == null)
			{
				return;
			}
			int borderPixels = (int)((float)renderTexture.width * 0.25f);
			RenderTexture renderTexture2 = MapGen.NineCombineCurrentObjectMask(t, ods, borderPixels);
			currentObjectSDF = JumpFloodSDF.CreateTemporaryRT(renderTexture2, 0, 1.25f, 2);
			RenderTexture.active = null;
			RenderTexture.ReleaseTemporary(renderTexture2);
			if (others)
			{
				if (combineSDFShader == null)
				{
					combineSDFShader = Shader.Find("Hidden/MicroVerse/CombineSDF");
				}
				Material material = new Material(combineSDFShader);
				RenderTexture temporary = RenderTexture.GetTemporary(currentObjectSDF.descriptor);
				temporary.name = "MicroVerse::CombinedObjectSDF";
				material.SetTexture("_SourceA", currentObjectSDF);
				material.SetTexture("_SourceB", objectSDF);
				Graphics.Blit(null, temporary, material);
				if (objectSDF != null)
				{
					RenderTexture.active = null;
					RenderTexture.ReleaseTemporary(objectSDF);
				}
				objectSDF = temporary;
			}
		}

		public void Dispose()
		{
			RenderTexture.active = null;
			RenderTexture.ReleaseTemporary(terrainMask);
			terrainMask = null;
			RenderTexture.ReleaseTemporary(objectMask);
			objectMask = null;
			if (treeSDF != null)
			{
				RenderTexture.ReleaseTemporary(treeSDF);
			}
			if (currentTreeMask != null)
			{
				RenderTexture.ReleaseTemporary(currentTreeMask);
			}
			if (currentTreeSDF != null)
			{
				RenderTexture.ReleaseTemporary(currentTreeSDF);
			}
			if (objectSDF != null)
			{
				RenderTexture.ReleaseTemporary(objectSDF);
			}
			if (currentObjectMask != null)
			{
				RenderTexture.ReleaseTemporary(currentObjectMask);
			}
			if (currentObjectSDF != null)
			{
				RenderTexture.ReleaseTemporary(currentObjectSDF);
			}
			currentTreeMask = null;
			treeSDF = null;
			currentTreeSDF = null;
			objectSDF = null;
			currentObjectMask = null;
			currentObjectSDF = null;
		}
	}
}
