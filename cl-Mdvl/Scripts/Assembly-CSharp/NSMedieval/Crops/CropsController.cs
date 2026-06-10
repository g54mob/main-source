using System;
using NSEipix.Base;

namespace NSMedieval.Crops
{
	public class CropsController : MonoSingleton<CropsController>
	{
		public event Action<Vec3Int, Vec3Int, string> CreateCropfieldEvent;

		public event Action CropfieldCreated;

		public event Action CropfieldPlantCutEvent;

		public event Action<CropfieldInstance> CropfieldPlantTypeChangedEvent;

		public event Action<CropfieldInstance> CropfieldHarvestPhaseChangedEvent;

		public event Action<CropfieldInstance> CropfieldCutPhaseChangedEvent;

		public event Action<CropfieldInstance> CropfieldDestroyedEvent;

		public event Action<CropfieldInstance> CropfieldPlacedEvent;

		private CropsController()
		{
		}

		public void CreateCropfield(Vec3Int start, Vec3Int end, string cropfieldID)
		{
			this.CreateCropfieldEvent?.Invoke(start, end, cropfieldID);
			this.CropfieldCreated?.Invoke();
		}

		public void CropfieldPlantCut()
		{
			this.CropfieldPlantCutEvent?.Invoke();
		}

		public void CropfieldPlaced(CropfieldInstance cropfieldInstance)
		{
			this.CropfieldPlacedEvent?.Invoke(cropfieldInstance);
		}

		public void CropfieldPlantTypeChanged(CropfieldInstance cropfieldInstance)
		{
			this.CropfieldPlantTypeChangedEvent?.Invoke(cropfieldInstance);
		}

		public void CropfieldHarvestPhaseChanged(CropfieldInstance cropfieldInstance)
		{
			this.CropfieldHarvestPhaseChangedEvent?.Invoke(cropfieldInstance);
		}

		public void CropfieldCutPhaseChanged(CropfieldInstance cropfieldInstance)
		{
			this.CropfieldCutPhaseChangedEvent?.Invoke(cropfieldInstance);
		}

		public void CropfieldDestroyed(CropfieldInstance cropfieldInstance)
		{
			this.CropfieldDestroyedEvent?.Invoke(cropfieldInstance);
		}
	}
}
