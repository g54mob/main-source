using System.Collections.Generic;
using Mandragora.PWS;
using Restory.Data.Devices;
using Restory.Data.Equipment;
using Restory.Gameplay.Devices;
using Restory.Gameplay.TextureMasks;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	public class PaintableDevice : MonoBehaviour
	{
		[SerializeField]
		private DeviceInfo deviceInfo;

		private readonly Dictionary<PaintingPaletteInfo, int> usedPaletteCounts = new Dictionary<PaintingPaletteInfo, int>();

		private List<PaintableElement> paintableElements = new List<PaintableElement>();

		private Texture2D devicePaintingTexture;

		private Texture2D devicePaintingMaskTexture;

		private PaintingProgressInPercentage currentPaintingProgress;

		private TextureCreationService textureCreationService;

		private TextureMaskCreationService textureMaskCreator;

		public Vector2Int PaintingTextureSize => deviceInfo.PaintTextureSize;

		public float PaintingBrushSizeMultiplier => deviceInfo.PaintingBrushSizeMultiplier;

		public Texture2D DevicePaintingTexture => devicePaintingTexture;

		public Texture2D DevicePaintingMaskTexture => devicePaintingMaskTexture;

		public bool AnyPaintApplied => usedPaletteCounts.Count > 0;

		public IReadOnlyDictionary<PaintingPaletteInfo, int> UsedPaletteCounts => usedPaletteCounts;

		public DeviceInfo DeviceInfo => deviceInfo;

		public int PaintTextureId { get; private set; }

		public PaintingProgressInPercentage CurrentPaintingProgress => currentPaintingProgress;

		[Inject]
		private void Construct(TextureCreationService textureCreationService, TextureMaskCreationService textureMaskCreator)
		{
			this.textureCreationService = textureCreationService;
			this.textureMaskCreator = textureMaskCreator;
		}

		public void SetPaintingTexture(Texture2D newTexture)
		{
			devicePaintingTexture = newTexture;
			SyncPaintingTexture();
		}

		public void SetPaintTextureId(int paintTextureId)
		{
			PaintTextureId = paintTextureId;
		}

		public void ClearPaintTextureId()
		{
			PaintTextureId = 0;
		}

		public void IncreasePaintingUseCount(PaintingPaletteInfo appliedPalette)
		{
			if ((bool)appliedPalette)
			{
				if (usedPaletteCounts.TryGetValue(appliedPalette, out var value))
				{
					value++;
					usedPaletteCounts[appliedPalette] = value;
				}
				else
				{
					usedPaletteCounts[appliedPalette] = 1;
				}
			}
		}

		public void DecreasePaintingUseCount(PaintingPaletteInfo appliedPalette)
		{
			if ((bool)appliedPalette && usedPaletteCounts.TryGetValue(appliedPalette, out var value))
			{
				value--;
				if (value <= 0)
				{
					usedPaletteCounts.Remove(appliedPalette);
				}
				else
				{
					usedPaletteCounts[appliedPalette] = value;
				}
			}
		}

		public bool ContainsPalette(PaintingPaletteInfo palette)
		{
			if (!palette)
			{
				return false;
			}
			if (usedPaletteCounts.TryGetValue(palette, out var value))
			{
				return value > 0;
			}
			return false;
		}

		public void ClearRegisteredPalettes()
		{
			usedPaletteCounts.Clear();
		}

		private void SyncPaintingTexture()
		{
			CollectPaintableElements();
			foreach (PaintableElement paintableElement in paintableElements)
			{
				paintableElement.PaintingTextureHolder.SetNewWorkTexture(devicePaintingTexture);
			}
		}

		private void SetPaintingMaskTexture(Texture2D newMaskTexture)
		{
			if ((bool)devicePaintingMaskTexture)
			{
				DisposeTexture(devicePaintingMaskTexture);
				devicePaintingMaskTexture = null;
			}
			devicePaintingMaskTexture = newMaskTexture;
		}

		private void Reset()
		{
			if (TryGetComponent<Device>(out var component))
			{
				deviceInfo = component.Info;
			}
		}

		private void DisposeTexture(Texture2D texture)
		{
			if ((bool)texture)
			{
				Object.Destroy(texture);
			}
		}

		public void InitializeTextures(PaintingSettings settings)
		{
			if (!DevicePaintingTexture)
			{
				Texture2D paintingTexture = textureCreationService.CreateCleanTexture(PaintingTextureSize.x, PaintingTextureSize.y, settings.TextureFormat, linear: true);
				SetPaintingTexture(paintingTexture);
			}
			InitializePaintingMaskTexture(settings);
		}

		public void CleanPaintingTexture()
		{
			if ((bool)devicePaintingTexture)
			{
				textureCreationService.ClearTexture(devicePaintingTexture);
				ClearRegisteredPalettes();
			}
		}

		public void InitializePaintingMaskTexture(PaintingSettings settings)
		{
			CollectPaintableElements();
			if (!DevicePaintingMaskTexture)
			{
				Texture2D paintingMaskTexture = textureCreationService.CreateCleanTexture(PaintingTextureSize.x, PaintingTextureSize.y, TextureFormat.R8, linear: true);
				SetPaintingMaskTexture(paintingMaskTexture);
				MeshUVProcessor.ProcessingSettings meshSettings = new MeshUVProcessor.ProcessingSettings
				{
					enableDebugOutput = false,
					enableWireframe = true,
					wireThickness = 0.5f,
					wrapUV = false
				};
				List<Mesh> list = new List<Mesh>();
				foreach (PaintableElement paintableElement in paintableElements)
				{
					if ((bool)paintableElement.PaintingTextureHolder)
					{
						list.Add(paintableElement.PaintingTextureHolder.SharedMesh);
					}
				}
				textureMaskCreator.TryCreateMeshUVCoverageMask(list, meshSettings, devicePaintingMaskTexture, out var _, settings.UVMaskTexturePadding);
			}
			foreach (PaintableElement paintableElement2 in paintableElements)
			{
				if ((bool)paintableElement2.PaintingTextureHolder)
				{
					paintableElement2.PaintingTextureHolder.SetNewMaskTexture(devicePaintingMaskTexture);
				}
			}
		}

		private void CollectPaintableElements()
		{
			paintableElements.Clear();
			paintableElements.AddRange(GetComponentsInChildren<PaintableElement>(includeInactive: true));
		}

		public void UpdateUsedPalettesCount(IReadOnlyDictionary<PaintingPaletteInfo, int> newAppliedPalettes)
		{
			usedPaletteCounts.Clear();
			foreach (KeyValuePair<PaintingPaletteInfo, int> newAppliedPalette in newAppliedPalettes)
			{
				usedPaletteCounts[newAppliedPalette.Key] = newAppliedPalette.Value;
			}
		}

		public void SetPaintingProgress(PaintingProgressInPercentage paintingProgress)
		{
			currentPaintingProgress = paintingProgress;
		}
	}
}
