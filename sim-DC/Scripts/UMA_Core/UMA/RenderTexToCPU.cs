using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace UMA
{
	public class RenderTexToCPU
	{
		public static bool ApplyInline;

		public static Dictionary<int, RenderTexToCPU> renderTexturesToCPU;

		public static Queue<RenderTexToCPU> QueuedCopies;

		public static Dictionary<int, RenderTexture> renderTexturesToFree;

		public RenderTexture texture;

		public UMAData.GeneratedMaterial generatedMaterial;

		public string textureName;

		public int textureIndex;

		public Texture2D newTexture;

		public bool recreateMips;

		public static int copiesEnqueued;

		public static int copiesDequeued;

		public static int unableToQueue;

		public static int misseduploads;

		public static int errorUploads;

		public static int texturesUploaded;

		public static int renderTexturesCleanedUMAData;

		public static int renderTexturesCleanedApplied;

		public static int renderTexturesCleanedMissed;

		public RenderTexToCPU(RenderTexture texture, UMAData.GeneratedMaterial generatedMaterial, string textureName, int textureIndex, UMAGeneratorBase basegen)
		{
		}

		public void DoAsyncCopy()
		{
		}

		private void QueueCopy(AsyncGPUReadbackRequest asyncAction)
		{
		}

		public static int PendingCopies()
		{
			return 0;
		}

		public static bool SafeToFree(RenderTexture tex)
		{
			return false;
		}

		public static void ApplyQueuedCopies(int number)
		{
		}

		private void ApplyTexture()
		{
		}
	}
}
