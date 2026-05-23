using System;
using System.Collections.Generic;
using Data.Shapes;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class RecipeOperatorBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		public bool HasRecipeSet { get; private set; }

		public int RecipeIndex { get; private set; }

		public RecipeOperatorBehaviourConfigurationDto(bool hasRecipeSet, int recipeIndex)
		{
			HasRecipeSet = hasRecipeSet;
			RecipeIndex = recipeIndex;
		}

		public override BehaviourConfigurationDto CopyOf()
		{
			return new RecipeOperatorBehaviourConfigurationDto(HasRecipeSet, RecipeIndex);
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
