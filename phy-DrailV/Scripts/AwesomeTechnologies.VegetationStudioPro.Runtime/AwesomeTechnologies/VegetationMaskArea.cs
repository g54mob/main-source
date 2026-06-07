using System.Collections.Generic;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.VegetationStudio;
using UnityEngine;

namespace AwesomeTechnologies
{
	[HelpURL("http://www.awesometech.no/index.php/home/vegetation-studio/components/vegetation-masks/vegetation-mask-area")]
	[ExecuteInEditMode]
	[AwesomeTechnologiesScriptOrder(99)]
	public class VegetationMaskArea : VegetationMask
	{
		public float ReductionTolerance = 0.2f;

		private PolygonMaskArea _currentMaskArea;

		public override void UpdateVegetationMask()
		{
			if (base.enabled && base.gameObject.activeSelf && (Time.frameCount >= 2 || !Application.isEditor))
			{
				List<Vector3> worldSpaceNodePositions = GetWorldSpaceNodePositions();
				PolygonMaskArea polygonMaskArea = new PolygonMaskArea
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
				if (polygonMaskArea.AdditionalGrassWidthMax < polygonMaskArea.AdditionalGrassWidth)
				{
					polygonMaskArea.AdditionalGrassWidthMax = polygonMaskArea.AdditionalGrassWidth;
				}
				if (polygonMaskArea.AdditionalPlantWidthMax < polygonMaskArea.AdditionalPlantWidth)
				{
					polygonMaskArea.AdditionalPlantWidthMax = polygonMaskArea.AdditionalPlantWidth;
				}
				if (polygonMaskArea.AdditionalTreeWidthMax < polygonMaskArea.AdditionalTreeWidth)
				{
					polygonMaskArea.AdditionalTreeWidthMax = polygonMaskArea.AdditionalTreeWidth;
				}
				if (polygonMaskArea.AdditionalObjectWidthMax < polygonMaskArea.AdditionalObjectWidth)
				{
					polygonMaskArea.AdditionalObjectWidthMax = polygonMaskArea.AdditionalObjectWidth;
				}
				if (polygonMaskArea.AdditionalLargeObjectWidthMax < polygonMaskArea.AdditionalLargeObjectWidth)
				{
					polygonMaskArea.AdditionalLargeObjectWidthMax = polygonMaskArea.AdditionalLargeObjectWidth;
				}
				if (IncludeVegetationType)
				{
					AddVegetationTypes(polygonMaskArea);
				}
				polygonMaskArea.AddPolygon(worldSpaceNodePositions);
				if (_currentMaskArea != null)
				{
					VegetationStudioManager.RemoveVegetationMask(_currentMaskArea);
					_currentMaskArea = null;
				}
				_currentMaskArea = polygonMaskArea;
				VegetationStudioManager.AddVegetationMask(polygonMaskArea);
			}
		}

		private void OnDisable()
		{
			if (_currentMaskArea != null)
			{
				VegetationStudioManager.RemoveVegetationMask(_currentMaskArea);
				_currentMaskArea.Dispose();
				_currentMaskArea = null;
			}
		}

		public void GenerateHullNodes(float tolerance)
		{
			List<Vector2> list = new List<Vector2>();
			MeshFilter[] componentsInChildren = GetComponentsInChildren<MeshFilter>();
			for (int i = 0; i <= componentsInChildren.Length - 1; i++)
			{
				Mesh sharedMesh = componentsInChildren[i].sharedMesh;
				if ((bool)sharedMesh)
				{
					List<Vector3> list2 = new List<Vector3>();
					sharedMesh.GetVertices(list2);
					for (int j = 0; j <= list2.Count - 1; j++)
					{
						Vector3 vector = componentsInChildren[i].transform.TransformPoint(list2[j]);
						Vector2 item = new Vector2
						{
							x = vector.x,
							y = vector.z
						};
						list.Add(item);
					}
				}
			}
			List<Vector2> list3 = PolygonUtility.DouglasPeuckerReduction(PolygonUtility.GetConvexHull(list), tolerance);
			if (list3.Count >= 3)
			{
				ClearNodes();
				for (int k = 0; k <= list3.Count - 1; k++)
				{
					Vector3 worldPosition = new Vector3(list3[k].x, 0f, list3[k].y);
					AddNode(worldPosition);
				}
				PositionNodes();
			}
		}
	}
}
