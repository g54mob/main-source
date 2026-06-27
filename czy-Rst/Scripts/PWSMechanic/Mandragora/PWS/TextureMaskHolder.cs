using System.Collections.Generic;
using UnityEngine;

namespace Mandragora.PWS
{
	public class TextureMaskHolder : MonoBehaviour
	{
		private static class Style
		{
			public const string Debug = "Debug";
		}

		[SerializeField]
		private MeshRendererMaterialsInstantiator materialsInstantiator;

		[SerializeField]
		private string texturePropertyName = "_MaskTexture";

		[SerializeField]
		private Vector2Int defaultTextureSize = new Vector2Int(2048, 2048);

		[SerializeField]
		private TextureFormat textureFormat = TextureFormat.RGBA32;

		private Texture2D workTexture;

		private readonly List<Vector2> attachedUV0 = new List<Vector2>();

		private readonly DirtyPixelsCount initialDirtyPixelsCount = new DirtyPixelsCount();

		private readonly DirtyPixelsCount currentDirtyPixelsCount = new DirtyPixelsCount();

		private int pixelsToLeaveDirtyCountRG;

		private int pixelsToLeaveDirtyCountB;

		private int totalPixelsInMeshCount;

		public Texture2D WorkTexture => workTexture;

		public DirtyPixelsCount InitialDirtyPixelsCount => initialDirtyPixelsCount;

		public int CurrentTotalDirtyPixelsCount => currentDirtyPixelsCount.Total;

		public Mesh SharedMesh { get; private set; }

		public List<Vector2> AttachedUV0 => attachedUV0;

		public int TotalPixelsInMeshCount => totalPixelsInMeshCount;

		public int PixelsToLeaveDirtyCountRG => pixelsToLeaveDirtyCountRG;

		public int PixelsToLeaveDirtyCountB => pixelsToLeaveDirtyCountB;

		private void Awake()
		{
			if (TryGetComponent<MeshFilter>(out var component))
			{
				SharedMesh = component.sharedMesh;
				SharedMesh.GetUVs(0, attachedUV0);
			}
			Clean();
		}

		private void OnDestroy()
		{
			ReleaseWorkTexture();
		}

		public void Initialize()
		{
			Initialize(defaultTextureSize);
		}

		public void Initialize(Vector2Int newTextureSize)
		{
			if (!workTexture)
			{
				workTexture = new Texture2D(newTextureSize.x, newTextureSize.y, textureFormat, mipChain: false);
			}
			else if (newTextureSize.x != workTexture.width || newTextureSize.y != workTexture.height)
			{
				ReleaseWorkTexture();
				workTexture = new Texture2D(newTextureSize.x, newTextureSize.y, textureFormat, mipChain: false);
				Debug.LogWarning("[TextureMaskHolder] detected different texture sizes " + $"Old ({workTexture.width}x{workTexture.height}) New ({newTextureSize.x}x{newTextureSize.y})");
			}
			SetWorkTexture();
			SetPreInitializationDirtyPixels();
		}

		public void SetTotalPixelsInMeshCount(int count)
		{
			totalPixelsInMeshCount = count;
		}

		public void RestoreWorkTexture(Texture2D restoredTexture)
		{
			ReleaseWorkTexture();
			workTexture = restoredTexture;
			SetWorkTexture();
		}

		public void ClearWorkTexture()
		{
			if (!workTexture)
			{
				Debug.LogError("Failed to clear work texture, it is null");
				return;
			}
			Color32[] pixels = TextureClearBufferCache.Get(workTexture.width * workTexture.height);
			workTexture.SetPixels32(pixels);
			workTexture.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			SetCurrentDirtyPixelsCountToZero();
		}

		public void ResetPreInitializationDirtyPixels()
		{
			SetPreInitializationDirtyPixels();
		}

		public void SetInitialDirtyPixelsCount(int dirtyPixelsCountR, int dirtyPixelsCountG, int dirtyPixelsCountB)
		{
			initialDirtyPixelsCount.R = dirtyPixelsCountR;
			initialDirtyPixelsCount.G = dirtyPixelsCountG;
			initialDirtyPixelsCount.B = dirtyPixelsCountB;
		}

		public void SetPixelsToLeaveDirtyCount(int pixelsNotNecessaryToCleanCountRG, int pixelsNotNecessaryToCleanCountB)
		{
			pixelsToLeaveDirtyCountRG = pixelsNotNecessaryToCleanCountRG;
			pixelsToLeaveDirtyCountB = pixelsNotNecessaryToCleanCountB;
		}

		public void SetCurrentDirtyPixelsCount(int dirtyPixelsCountR, int dirtyPixelsCountG, int dirtyPixelsCountB)
		{
			currentDirtyPixelsCount.R = dirtyPixelsCountR;
			currentDirtyPixelsCount.G = dirtyPixelsCountG;
			currentDirtyPixelsCount.B = dirtyPixelsCountB;
		}

		public void SetCurrentDirtyPixelsCountToZero()
		{
			currentDirtyPixelsCount.R = 0;
			currentDirtyPixelsCount.G = 0;
			currentDirtyPixelsCount.B = 0;
		}

		public DirtyPixelsCount GetInitialDirtyPixelsCount()
		{
			return initialDirtyPixelsCount;
		}

		public DirtyPixelsCount GetCurrentDirtyPixelsCount()
		{
			return currentDirtyPixelsCount;
		}

		public CleaningProgressInPercentage GetCleaningProgressPercentage()
		{
			return new CleaningProgressInPercentage
			{
				RedAndGreenChannel = GetCleaningProgressForSeveralChannels(new DirtyPixelsCount
				{
					R = initialDirtyPixelsCount.R,
					G = initialDirtyPixelsCount.G,
					B = 0
				}, new DirtyPixelsCount
				{
					R = currentDirtyPixelsCount.R,
					G = currentDirtyPixelsCount.G,
					B = 0
				}, pixelsToLeaveDirtyCountRG),
				BlueChannel = GetCleaningProgressForChannel(initialDirtyPixelsCount.B, currentDirtyPixelsCount.B, pixelsToLeaveDirtyCountB)
			};
		}

		private void SetWorkTexture()
		{
			foreach (Material materialInstance in materialsInstantiator.MaterialInstances)
			{
				if ((bool)materialInstance)
				{
					materialInstance.SetTexture(texturePropertyName, workTexture);
				}
			}
		}

		private void ReleaseWorkTexture()
		{
			if ((bool)workTexture)
			{
				Object.Destroy(workTexture);
			}
		}

		public void Clean()
		{
			RestoreWorkTexture(null);
		}

		private void SetPreInitializationDirtyPixels()
		{
			initialDirtyPixelsCount.R = -1;
			initialDirtyPixelsCount.G = -1;
			initialDirtyPixelsCount.B = -1;
			currentDirtyPixelsCount.R = -1;
			currentDirtyPixelsCount.G = -1;
			currentDirtyPixelsCount.B = -1;
		}

		private float GetCleanPercentage(int dirtyPartValue, int fullValue)
		{
			if (fullValue != 0)
			{
				return Mathf.Clamp01(1f - (float)dirtyPartValue / (float)fullValue);
			}
			return 1f;
		}

		private float GetCleaningProgressForChannel(int initialDirtyPixelsCount, int currentDirtyPixelsCount, int pixelsCountNotNecessaryToClean)
		{
			if (initialDirtyPixelsCount != 0)
			{
				return Mathf.Clamp01(1f - (float)(currentDirtyPixelsCount - pixelsCountNotNecessaryToClean) / (float)(initialDirtyPixelsCount - pixelsCountNotNecessaryToClean));
			}
			return 1f;
		}

		private float GetCleaningProgressForSeveralChannels(DirtyPixelsCount initialDirtyPixelsCount, DirtyPixelsCount currentDirtyPixelsCount, int pixelsCountNotNecessaryToClean)
		{
			if (initialDirtyPixelsCount.Total != 0)
			{
				return Mathf.Clamp01(1f - (float)(currentDirtyPixelsCount.Total - pixelsCountNotNecessaryToClean) / (float)(initialDirtyPixelsCount.Total - pixelsCountNotNecessaryToClean));
			}
			return 1f;
		}
	}
}
