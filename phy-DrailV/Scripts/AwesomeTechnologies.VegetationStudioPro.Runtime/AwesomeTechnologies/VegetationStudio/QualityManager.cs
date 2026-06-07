using System.Collections.Generic;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.VegetationStudio
{
	public class QualityManager : MonoBehaviour
	{
		public List<VegetationSystemProQualityLevel> QualityLevelList = new List<VegetationSystemProQualityLevel>();

		public VegetationSystemPro VegetationSystemPro;

		public int QualityLevelIndex;

		private void Reset()
		{
			VegetationSystemPro = GetComponent<VegetationSystemPro>();
		}

		public void SetQualityLevel(bool forceRefresh = true)
		{
			if (Application.isPlaying)
			{
				int qualityLevel = QualitySettings.GetQualityLevel();
				SetQualityLevel(qualityLevel, forceRefresh);
			}
		}

		public void SetQualityLevel(int index, bool forceRefresh = true)
		{
			if (!Application.isPlaying || index >= QualityLevelList.Count)
			{
				return;
			}
			VegetationSystemProQualityLevel vegetationSystemProQualityLevel = QualityLevelList[index];
			if (vegetationSystemProQualityLevel == null || !VegetationSystemPro)
			{
				return;
			}
			VegetationSystemPro.VegetationSettings.GrassDensity = vegetationSystemProQualityLevel.GrassDensity;
			VegetationSystemPro.VegetationSettings.PlantDensity = vegetationSystemProQualityLevel.PlantDensity;
			VegetationSystemPro.VegetationSettings.TreeDensity = vegetationSystemProQualityLevel.TreeDensity;
			VegetationSystemPro.VegetationSettings.ObjectDensity = vegetationSystemProQualityLevel.ObjectDensity;
			VegetationSystemPro.VegetationSettings.LargeObjectDensity = vegetationSystemProQualityLevel.LargeObjectDensity;
			VegetationSystemPro.VegetationSettings.GrassShadows = vegetationSystemProQualityLevel.GrassShadows;
			VegetationSystemPro.VegetationSettings.PlantShadows = vegetationSystemProQualityLevel.PlantShadows;
			VegetationSystemPro.VegetationSettings.TreeShadows = vegetationSystemProQualityLevel.TreeShadows;
			VegetationSystemPro.VegetationSettings.ObjectShadows = vegetationSystemProQualityLevel.ObjectShadows;
			VegetationSystemPro.VegetationSettings.LargeObjectShadows = vegetationSystemProQualityLevel.LargeObjectShadows;
			VegetationSystemPro.VegetationSettings.BillboardShadows = vegetationSystemProQualityLevel.BillboardShadows;
			VegetationSystemPro.VegetationSettings.PlantDistance = vegetationSystemProQualityLevel.PlantDistance;
			VegetationSystemPro.VegetationSettings.AdditionalTreeMeshDistance = vegetationSystemProQualityLevel.AdditionalTreeMeshDistance;
			VegetationSystemPro.VegetationSettings.AdditionalBillboardDistance = vegetationSystemProQualityLevel.AdditionalBillboardDistance;
			VegetationSystemPro.VegetationPackageProList.Clear();
			for (int i = 0; i <= vegetationSystemProQualityLevel.VegetationPackageProList.Count - 1; i++)
			{
				VegetationPackagePro vegetationPackagePro = vegetationSystemProQualityLevel.VegetationPackageProList[i];
				if ((bool)vegetationPackagePro)
				{
					VegetationSystemPro.VegetationPackageProList.Add(vegetationPackagePro);
				}
			}
			if (forceRefresh)
			{
				VegetationSystemPro.ClearCache();
				VegetationSystemPro.RefreshVegetationSystem();
			}
		}
	}
}
