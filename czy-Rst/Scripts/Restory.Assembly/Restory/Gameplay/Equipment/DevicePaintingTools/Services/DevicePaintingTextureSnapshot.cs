using System;
using System.Collections.Generic;
using Restory.Data.Equipment;
using UnityEngine;
using UnityEngine.Pool;

namespace Restory.Gameplay.Equipment.DevicePaintingTools.Services
{
	internal class DevicePaintingTextureSnapshot : IDisposable
	{
		private struct SnapshotEntry
		{
			public readonly Texture2D Texture;

			public SnapshotEntry(Texture2D texture)
			{
				Texture = texture;
			}
		}

		private readonly Texture2D deviceTexture;

		private readonly SnapshotEntry[] elementSnapshots;

		public PaintingPaletteInfo AppliedPalette { get; }

		public bool ClearsPalettes { get; }

		private DevicePaintingTextureSnapshot(Texture2D deviceTexture, SnapshotEntry[] elementSnapshots, PaintingPaletteInfo appliedPalette, bool clearsPalettes)
		{
			this.deviceTexture = deviceTexture;
			this.elementSnapshots = elementSnapshots;
			AppliedPalette = appliedPalette;
			ClearsPalettes = clearsPalettes;
		}

		public static DevicePaintingTextureSnapshot Create(PaintableDevice paintableDevice, IReadOnlyList<PaintableElement> paintableElements, PaintingPaletteInfo appliedPalette = null, bool clearsPalettes = false)
		{
			Dictionary<Texture2D, Texture2D> textureCopiesBySource = new Dictionary<Texture2D, Texture2D>();
			Texture2D texture2D = CloneTextureWithSharedReference(paintableDevice.DevicePaintingTexture, textureCopiesBySource);
			SnapshotEntry[] array = new SnapshotEntry[paintableElements.Count];
			for (int i = 0; i < paintableElements.Count; i++)
			{
				Texture2D texture = CloneTextureWithSharedReference(paintableElements[i].PaintingTextureHolder.PaintingTexture, textureCopiesBySource);
				array[i] = new SnapshotEntry(texture);
			}
			return new DevicePaintingTextureSnapshot(texture2D, array, appliedPalette, clearsPalettes);
		}

		public void Apply(PaintableDevice paintableDevice, IReadOnlyList<PaintableElement> paintableElements)
		{
			Dictionary<Texture2D, Texture2D> liveTexturesBySnapshot = new Dictionary<Texture2D, Texture2D>();
			Texture2D paintingTexture = CopySnapshotToLiveTextureWithSharedReference(deviceTexture, paintableDevice.DevicePaintingTexture, liveTexturesBySnapshot);
			paintableDevice.SetPaintingTexture(paintingTexture);
			int num = Mathf.Min(paintableElements.Count, elementSnapshots.Length);
			for (int i = 0; i < num; i++)
			{
				PaintingTextureHolder paintingTextureHolder = paintableElements[i].PaintingTextureHolder;
				Texture2D newWorkTexture = CopySnapshotToLiveTextureWithSharedReference(elementSnapshots[i].Texture, paintingTextureHolder.PaintingTexture, liveTexturesBySnapshot);
				paintingTextureHolder.SetNewWorkTexture(newWorkTexture);
			}
		}

		public void Dispose()
		{
			HashSet<Texture2D> value;
			using (CollectionPool<HashSet<Texture2D>, Texture2D>.Get(out value))
			{
				value.Add(deviceTexture);
				SnapshotEntry[] array = elementSnapshots;
				for (int i = 0; i < array.Length; i++)
				{
					SnapshotEntry snapshotEntry = array[i];
					if ((bool)snapshotEntry.Texture)
					{
						value.Add(snapshotEntry.Texture);
					}
				}
				foreach (Texture2D item in value)
				{
					UnityEngine.Object.Destroy(item);
				}
			}
		}

		private static Texture2D CloneTextureWithSharedReference(Texture2D source, Dictionary<Texture2D, Texture2D> textureCopiesBySource)
		{
			if (!source)
			{
				return null;
			}
			if (textureCopiesBySource.TryGetValue(source, out var value))
			{
				return value;
			}
			Texture2D texture2D = CloneTextureWithoutData(source);
			Graphics.CopyTexture(source, texture2D);
			textureCopiesBySource.Add(source, texture2D);
			return texture2D;
		}

		private static Texture2D CopySnapshotToLiveTextureWithSharedReference(Texture2D snapshotTexture, Texture2D liveTexture, Dictionary<Texture2D, Texture2D> liveTexturesBySnapshot)
		{
			if (!snapshotTexture)
			{
				return null;
			}
			if (liveTexturesBySnapshot.TryGetValue(snapshotTexture, out var value))
			{
				return value;
			}
			Texture2D texture2D = ((IsTextureCompatible(snapshotTexture, liveTexture) && !liveTexturesBySnapshot.ContainsValue(liveTexture)) ? liveTexture : CloneTextureWithoutData(snapshotTexture));
			Graphics.CopyTexture(snapshotTexture, texture2D);
			liveTexturesBySnapshot.Add(snapshotTexture, texture2D);
			return texture2D;
		}

		private static bool IsTextureCompatible(Texture2D source, Texture2D target)
		{
			if ((bool)target && source.width == target.width && source.height == target.height && source.format == target.format)
			{
				return source.mipmapCount == target.mipmapCount;
			}
			return false;
		}

		private static Texture2D CloneTextureWithoutData(Texture2D source)
		{
			return new Texture2D(source.width, source.height, source.format, source.mipmapCount > 1, !source.isDataSRGB)
			{
				filterMode = source.filterMode,
				wrapMode = source.wrapMode
			};
		}
	}
}
