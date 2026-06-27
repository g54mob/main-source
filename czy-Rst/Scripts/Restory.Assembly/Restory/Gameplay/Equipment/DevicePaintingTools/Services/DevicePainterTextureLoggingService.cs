using System;
using System.Collections.Generic;
using Restory.Data.Equipment;

namespace Restory.Gameplay.Equipment.DevicePaintingTools.Services
{
	public class DevicePainterTextureLoggingService : IDisposable
	{
		private PaintingSettings settings;

		private readonly List<DevicePaintingTextureSnapshot> snapshots = new List<DevicePaintingTextureSnapshot>();

		public int ActiveSnapshotIndex { get; private set; }

		public bool LastIndexReached
		{
			get
			{
				if (snapshots.Count != 0)
				{
					return ActiveSnapshotIndex >= snapshots.Count - 1;
				}
				return true;
			}
		}

		public bool FirstIndexReached => ActiveSnapshotIndex <= 0;

		public void Initialize(PaintingSettings settings, PaintableDevice paintableDevice, IReadOnlyList<PaintableElement> paintableElements)
		{
			this.settings = settings;
			ClearSnapshots();
			RegisterSnapshot(paintableDevice, paintableElements);
		}

		public void RegisterSnapshot(PaintableDevice paintableDevice, IReadOnlyList<PaintableElement> paintableElements, PaintingPaletteInfo appliedPalette = null, bool clearsPalettes = false)
		{
			if ((bool)paintableDevice)
			{
				RemoveRedoSnapshots();
				snapshots.Add(DevicePaintingTextureSnapshot.Create(paintableDevice, paintableElements, appliedPalette, clearsPalettes));
				if (snapshots.Count > settings.PaintingHistorySize)
				{
					snapshots[0].Dispose();
					snapshots.RemoveAt(0);
				}
				ActiveSnapshotIndex = snapshots.Count - 1;
				RebuildPaletteUseCounts(paintableDevice);
			}
		}

		public bool StepForward(PaintableDevice paintableDevice, IReadOnlyList<PaintableElement> paintableElements)
		{
			if (LastIndexReached)
			{
				return false;
			}
			ActiveSnapshotIndex++;
			ApplyActiveSnapshot(paintableDevice, paintableElements);
			ApplyPaletteLog(paintableDevice, snapshots[ActiveSnapshotIndex]);
			return true;
		}

		public bool StepBackward(PaintableDevice paintableDevice, IReadOnlyList<PaintableElement> paintableElements)
		{
			if (FirstIndexReached)
			{
				return false;
			}
			DevicePaintingTextureSnapshot snapshot = snapshots[ActiveSnapshotIndex];
			ActiveSnapshotIndex--;
			ApplyActiveSnapshot(paintableDevice, paintableElements);
			RevertPaletteLog(paintableDevice, snapshot);
			return true;
		}

		public void ClearSnapshots()
		{
			foreach (DevicePaintingTextureSnapshot snapshot in snapshots)
			{
				snapshot.Dispose();
			}
			snapshots.Clear();
			ActiveSnapshotIndex = 0;
		}

		public void Dispose()
		{
			ClearSnapshots();
		}

		private void ApplyActiveSnapshot(PaintableDevice paintableDevice, IReadOnlyList<PaintableElement> paintableElements)
		{
			if ((bool)paintableDevice && snapshots.Count != 0)
			{
				snapshots[ActiveSnapshotIndex].Apply(paintableDevice, paintableElements);
			}
		}

		private void RemoveRedoSnapshots()
		{
			for (int num = snapshots.Count - 1; num > ActiveSnapshotIndex; num--)
			{
				snapshots[num].Dispose();
				snapshots.RemoveAt(num);
			}
		}

		private void RebuildPaletteUseCounts(PaintableDevice paintableDevice)
		{
			if (!paintableDevice)
			{
				return;
			}
			paintableDevice.ClearRegisteredPalettes();
			for (int i = 0; i <= ActiveSnapshotIndex && i < snapshots.Count; i++)
			{
				DevicePaintingTextureSnapshot devicePaintingTextureSnapshot = snapshots[i];
				if (devicePaintingTextureSnapshot.ClearsPalettes)
				{
					paintableDevice.ClearRegisteredPalettes();
				}
				else
				{
					paintableDevice.IncreasePaintingUseCount(devicePaintingTextureSnapshot.AppliedPalette);
				}
			}
		}

		private void ApplyPaletteLog(PaintableDevice paintableDevice, DevicePaintingTextureSnapshot snapshot)
		{
			if ((bool)paintableDevice)
			{
				if (snapshot.ClearsPalettes)
				{
					paintableDevice.ClearRegisteredPalettes();
				}
				else
				{
					paintableDevice.IncreasePaintingUseCount(snapshot.AppliedPalette);
				}
			}
		}

		private void RevertPaletteLog(PaintableDevice paintableDevice, DevicePaintingTextureSnapshot snapshot)
		{
			if ((bool)paintableDevice)
			{
				if (snapshot.ClearsPalettes)
				{
					RebuildPaletteUseCounts(paintableDevice);
				}
				else
				{
					paintableDevice.DecreasePaintingUseCount(snapshot.AppliedPalette);
				}
			}
		}
	}
}
