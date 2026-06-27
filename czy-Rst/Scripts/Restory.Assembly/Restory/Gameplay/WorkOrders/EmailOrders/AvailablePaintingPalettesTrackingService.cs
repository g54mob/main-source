using System;
using System.Collections;
using System.Collections.Generic;
using Restory.Data.Equipment;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.WorkOrders.EmailOrders
{
	public class AvailablePaintingPalettesTrackingService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private readonly List<PaintingPaletteInfo> availablePalettes = new List<PaintingPaletteInfo>();

		private Coroutine doCallbackAfterEndOfFrameCoroutine;

		public List<PaintingPaletteInfo> AvailablePalettes => availablePalettes;

		public event Action OnNewPalettesMadeAvailable;

		private void OnDisable()
		{
			if (doCallbackAfterEndOfFrameCoroutine != null)
			{
				StopCoroutine(doCallbackAfterEndOfFrameCoroutine);
				doCallbackAfterEndOfFrameCoroutine = null;
			}
		}

		public void SetUpInitialPalettes(IReadOnlyCollection<PaintingPaletteInfo> initialPaintingPalettes)
		{
			availablePalettes.Clear();
			foreach (PaintingPaletteInfo initialPaintingPalette in initialPaintingPalettes)
			{
				if (!initialPaintingPalette)
				{
					continue;
				}
				bool flag = false;
				foreach (PaintingPaletteInfo availablePalette in availablePalettes)
				{
					if (availablePalette.ID == initialPaintingPalette.ID)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					availablePalettes.Add(initialPaintingPalette);
				}
			}
		}

		public void AddPalette(PaintingPaletteInfo newPalette)
		{
			foreach (PaintingPaletteInfo availablePalette in availablePalettes)
			{
				if (availablePalette.ID == newPalette.ID)
				{
					return;
				}
			}
			availablePalettes.Add(newPalette);
			if (doCallbackAfterEndOfFrameCoroutine == null)
			{
				doCallbackAfterEndOfFrameCoroutine = StartCoroutine(DoCallbackAfterEndOfFrameCoroutine(this.OnNewPalettesMadeAvailable));
			}
		}

		private IEnumerator DoCallbackAfterEndOfFrameCoroutine(Action callback)
		{
			yield return new WaitForEndOfFrame();
			doCallbackAfterEndOfFrameCoroutine = null;
			callback?.Invoke();
		}

		public object CaptureState()
		{
			try
			{
				return new AvailablePaintingPalettesTrackingServiceSaveData
				{
					AvailablePalettes = availablePalettes.ToArray()
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				AvailablePaintingPalettesTrackingServiceSaveData availablePaintingPalettesTrackingServiceSaveData = DataMigrationWizard.Migrate<AvailablePaintingPalettesTrackingServiceSaveData>(state, base.gameObject);
				availablePalettes.Clear();
				availablePalettes.AddRange(availablePaintingPalettesTrackingServiceSaveData.AvailablePalettes);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
