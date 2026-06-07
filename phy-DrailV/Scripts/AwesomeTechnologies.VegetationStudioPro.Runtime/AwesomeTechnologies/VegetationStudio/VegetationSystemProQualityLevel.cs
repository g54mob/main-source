using System;
using System.Collections.Generic;
using AwesomeTechnologies.VegetationSystem;

namespace AwesomeTechnologies.VegetationStudio
{
	[Serializable]
	public class VegetationSystemProQualityLevel
	{
		public int QualityLevelIndex;

		public string Name;

		public float GrassDensity = 1f;

		public float PlantDensity = 1f;

		public float TreeDensity = 1f;

		public float ObjectDensity = 1f;

		public float LargeObjectDensity = 1f;

		public float PlantDistance = 150f;

		public float AdditionalTreeMeshDistance = 150f;

		public float AdditionalBillboardDistance = 1000f;

		public bool GrassShadows;

		public bool PlantShadows;

		public bool TreeShadows = true;

		public bool ObjectShadows = true;

		public bool LargeObjectShadows = true;

		public bool BillboardShadows;

		public List<VegetationPackagePro> VegetationPackageProList = new List<VegetationPackagePro>();
	}
}
