using System.Collections.Generic;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.VegetationStudio;
using UnityEngine;

namespace AwesomeTechnologies
{
	[HelpURL("http://www.awesometech.no/index.php/home/vegetation-studio/components/vegetation-masks/vegetation-mask-line")]
	[AwesomeTechnologiesScriptOrder(99)]
	public class VegetationMaskLine : VegetationMask
	{
		public float LineWidth = 2f;

		private readonly List<LineMaskArea> _lineMaskList = new List<LineMaskArea>();

		public override void Reset()
		{
			ClosedArea = false;
			LineWidth = 2f;
			base.Reset();
		}

		public override void UpdateVegetationMask()
		{
			if (!base.enabled || !base.gameObject.activeSelf || (Time.frameCount < 2 && Application.isEditor))
			{
				return;
			}
			List<Vector3> worldSpaceNodePositions = GetWorldSpaceNodePositions();
			if (_lineMaskList.Count > 0)
			{
				for (int i = 0; i <= _lineMaskList.Count - 1; i++)
				{
					VegetationStudioManager.RemoveVegetationMask(_lineMaskList[i]);
				}
				_lineMaskList.Clear();
			}
			if (worldSpaceNodePositions.Count <= 1)
			{
				return;
			}
			for (int j = 0; j <= worldSpaceNodePositions.Count - 2; j++)
			{
				if (Nodes[j].Active)
				{
					float width = LineWidth;
					if (Nodes[j].OverrideWidth)
					{
						width = Nodes[j].CustomWidth;
					}
					LineMaskArea lineMaskArea = new LineMaskArea
					{
						RemoveGrass = RemoveGrass,
						RemovePlants = RemovePlants,
						RemoveTrees = RemoveTrees,
						RemoveObjects = RemoveObjects,
						RemoveLargeObjects = RemoveLargeObjects,
						AdditionalGrassWidth = AdditionalGrassPerimiter,
						AdditionalPlantWidth = AdditionalPlantPerimiter,
						AdditionalTreeWidth = AdditionalTreePerimiter,
						AdditionalObjectWidth = AdditionalObjectPerimiter,
						AdditionalLargeObjectWidth = AdditionalLargeObjectPerimiter,
						AdditionalGrassWidthMax = AdditionalGrassPerimiterMax,
						AdditionalPlantWidthMax = AdditionalPlantPerimiterMax,
						AdditionalTreeWidthMax = AdditionalTreePerimiterMax,
						AdditionalObjectWidthMax = AdditionalObjectPerimiterMax,
						AdditionalLargeObjectWidthMax = AdditionalLargeObjectPerimiterMax,
						NoiseScaleGrass = NoiseScaleGrass,
						NoiseScalePlant = NoiseScalePlant,
						NoiseScaleTree = NoiseScaleTree,
						NoiseScaleObject = NoiseScaleObject,
						NoiseScaleLargeObject = NoiseScaleLargeObject
					};
					if (lineMaskArea.AdditionalGrassWidthMax < lineMaskArea.AdditionalGrassWidth)
					{
						lineMaskArea.AdditionalGrassWidthMax = lineMaskArea.AdditionalGrassWidth;
					}
					if (lineMaskArea.AdditionalPlantWidthMax < lineMaskArea.AdditionalPlantWidth)
					{
						lineMaskArea.AdditionalPlantWidthMax = lineMaskArea.AdditionalPlantWidth;
					}
					if (lineMaskArea.AdditionalTreeWidthMax < lineMaskArea.AdditionalTreeWidth)
					{
						lineMaskArea.AdditionalTreeWidthMax = lineMaskArea.AdditionalTreeWidth;
					}
					if (lineMaskArea.AdditionalObjectWidthMax < lineMaskArea.AdditionalObjectWidth)
					{
						lineMaskArea.AdditionalObjectWidthMax = lineMaskArea.AdditionalObjectWidth;
					}
					if (lineMaskArea.AdditionalLargeObjectWidthMax < lineMaskArea.AdditionalLargeObjectWidth)
					{
						lineMaskArea.AdditionalLargeObjectWidthMax = lineMaskArea.AdditionalLargeObjectWidth;
					}
					if (IncludeVegetationType)
					{
						AddVegetationTypes(lineMaskArea);
					}
					lineMaskArea.SetLineData(worldSpaceNodePositions[j], worldSpaceNodePositions[j + 1], width);
					_lineMaskList.Add(lineMaskArea);
					VegetationStudioManager.AddVegetationMask(lineMaskArea);
				}
			}
		}

		private void OnDisable()
		{
			if (_lineMaskList.Count > 0)
			{
				for (int i = 0; i <= _lineMaskList.Count - 1; i++)
				{
					VegetationStudioManager.RemoveVegetationMask(_lineMaskList[i]);
					_lineMaskList[i].Dispose();
				}
				_lineMaskList.Clear();
			}
		}
	}
}
