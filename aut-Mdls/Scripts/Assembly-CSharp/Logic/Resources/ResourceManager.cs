using Data.Buildings;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Variables.Recipes;
using UnityEngine;

namespace Logic.Resources
{
	public class ResourceManager : MonoBehaviour
	{
		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private BuildingFamilyDatabase _buildingFamilyDatabase;

		[SerializeField]
		private ResourceOriginsDatabase _resourceOriginsDatabase;

		private void Awake()
		{
			BuildResourceOriginsDatabase();
		}

		private void BuildResourceOriginsDatabase()
		{
			for (int i = 0; i < _factoryObjectDatabase.BuildingsObjectData.BuildingDatas.Count; i++)
			{
				BuildingObjectData buildingObjectData = _factoryObjectDatabase.BuildingsObjectData.BuildingDatas[i];
				if (!(buildingObjectData == null) && buildingObjectData.ResourceOutputs != null && buildingObjectData.ResourceOutputs.Count != 0)
				{
					AddToResourceOrigin(buildingObjectData.ResourceOutputs[0].ResourceData as NonShapeResourceDataSO, buildingObjectData.NameLocKey, Sprite.Create(buildingObjectData.MeshRenderIcon, new Rect(0f, 0f, buildingObjectData.MeshRenderIcon.width, buildingObjectData.MeshRenderIcon.height), new Vector2(0.5f, 0.5f)), ResourceOriginType.CreatedInBuilding);
				}
			}
			for (int j = 0; j < _factoryObjectDatabase.FactoryObjectsData.Count; j++)
			{
				if (_factoryObjectDatabase.FactoryObjectsData[j] == null)
				{
					continue;
				}
				for (int k = 0; k < _factoryObjectDatabase.FactoryObjectsData[j].Behaviours.Count; k++)
				{
					ResourceBehaviour resourceBehaviour = _factoryObjectDatabase.FactoryObjectsData[j].Behaviours[k] as ResourceBehaviour;
					if (resourceBehaviour != null)
					{
						NonShapeResourceDataSO nonShapeResourceDataSO = resourceBehaviour.ResourceData as NonShapeResourceDataSO;
						if (!(nonShapeResourceDataSO == null))
						{
							AddToResourceOrigin(nonShapeResourceDataSO, "BuildingPanel.ResourceNatural", nonShapeResourceDataSO.Sprite, ResourceOriginType.Natural);
						}
					}
					else
					{
						RecipeOperatorBehaviour recipeOperatorBehaviour = _factoryObjectDatabase.FactoryObjectsData[j].Behaviours[k] as RecipeOperatorBehaviour;
						if (recipeOperatorBehaviour != null)
						{
							AddResourceFromRecipe(recipeOperatorBehaviour, _factoryObjectDatabase.FactoryObjectsData[j]);
						}
					}
				}
			}
		}

		private void AddResourceFromRecipe(RecipeOperatorBehaviour recipeOperatorBehaviour, FactoryObjectData factoryObjectData)
		{
			foreach (RecipeData recipe in recipeOperatorBehaviour.Recipes)
			{
				foreach (ResourceRecipe.Output output in recipe.Recipe.Outputs)
				{
					NonShapeResourceDataSO nonShapeResourceDataSO = output.resourceDataSO as NonShapeResourceDataSO;
					if (!(nonShapeResourceDataSO == null))
					{
						AddToResourceOrigin(nonShapeResourceDataSO, factoryObjectData.NameLocKey, nonShapeResourceDataSO.Sprite, ResourceOriginType.CreatedFromRecipe);
					}
				}
			}
		}

		private void AddToResourceOrigin(NonShapeResourceDataSO resourceData, string originName, Sprite originSprite, ResourceOriginType originType)
		{
			ResourceOriginInfo resourceOriginInfo = _resourceOriginsDatabase.GetResourceOriginInfo(resourceData);
			if (resourceOriginInfo == null)
			{
				resourceOriginInfo = new ResourceOriginInfo
				{
					Name = resourceData.NameLocaKey,
					Color = _buildingFamilyDatabase.GetBuildingFamilyDataWithId(resourceData.FamilyID).Color
				};
			}
			resourceOriginInfo.AddOrigin(originName, originSprite, originType);
			_resourceOriginsDatabase.AddOriginInfo(resourceData, resourceOriginInfo);
		}
	}
}
