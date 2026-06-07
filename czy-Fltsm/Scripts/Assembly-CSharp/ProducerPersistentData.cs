using System;
using System.Runtime.Serialization;

[Serializable]
public class ProducerPersistentData : BuildableExtendablePersistentData<Producer>
{
	[Serializable]
	public struct Recipe : IComparable<Recipe>
	{
		public int PropertiesIndex;

		public int QueueIndex;

		public int AmountToProduce;

		public bool IsPrioritized;

		public int CompareTo(Recipe other)
		{
			return QueueIndex - other.QueueIndex;
		}

		public bool TryGetProperties(out ProductionRecipeProperties properties)
		{
			return GameManager.PersistenceManager.TryReturnPropertiesReference<ProductionRecipeProperties>(PropertiesIndex, out properties);
		}
	}

	public PersistentReference<Project>.Reference ProductionProject;

	public PersistentReference<Project>.Reference ImportProject;

	public PersistentReference<Project>.Reference CancelledItemsExportProject;

	public int SelectedRecipeIndex;

	[OptionalField(VersionAdded = 3)]
	public Recipe[] Recipes;

	[OptionalField(VersionAdded = 2)]
	public int PriorityIndex;

	public QueuedRecipePersistentData[] QueuedRecipes;

	public BuildableAnimatorPersistentData BuildableAnimatorData;

	public MeshAnimatorPersistentData AgentAnimatorData;

	public int ContinuousRecipeIndex;

	public ProducerPersistentData(Producer producer)
		: base(producer)
	{
		base.Instance = producer;
		SelectedRecipeIndex = producer.SelectedRecipeIndex;
		Recipes = new Recipe[producer.Recipes.Count];
		for (int i = 0; i < Recipes.Length; i++)
		{
			Producer.Recipe recipe = producer.Recipes[i];
			Recipes[i] = new Recipe
			{
				PropertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(recipe.Properties),
				QueueIndex = producer.RecipeQueue.IndexOf(recipe),
				AmountToProduce = recipe.AmountToProduce,
				IsPrioritized = recipe.IsPrioritized
			};
		}
	}

	public void PopulateQueuedRecipes(Producer producer)
	{
		int count = producer.QueuedRecipes.Count;
		QueuedRecipePersistentData[] array = new QueuedRecipePersistentData[count];
		for (int i = 0; i < count; i++)
		{
			QueuedRecipePersistentData queuedRecipePersistentData = new QueuedRecipePersistentData(producer.QueuedRecipes[i]);
			array[i] = queuedRecipePersistentData;
		}
		QueuedRecipes = array;
	}

	public override void PopulateReferences()
	{
		base.Instance.PopulateReferences(this);
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<Producer>(out var component))
		{
			base.Instance = component;
			base.Instance.Restore(this);
		}
	}

	public override void RestoreReferences()
	{
		if (base.Instance != null)
		{
			base.Instance.RestoreReferences(this);
		}
	}
}
