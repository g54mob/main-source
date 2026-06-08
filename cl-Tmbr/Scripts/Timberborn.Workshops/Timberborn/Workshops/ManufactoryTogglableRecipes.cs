using Timberborn.BaseComponentSystem;

namespace Timberborn.Workshops
{
	public class ManufactoryTogglableRecipes : BaseComponent, IAwakableComponent, IStartableComponent
	{
		private ManufactoryTogglableRecipesSpec _manufactoryTogglableRecipesSpec;

		public string LabelLocKey => _manufactoryTogglableRecipesSpec.LabelLocKey;

		public void Awake()
		{
			_manufactoryTogglableRecipesSpec = GetComponent<ManufactoryTogglableRecipesSpec>();
		}

		public void Start()
		{
			Manufactory component = GetComponent<Manufactory>();
			if (component.CurrentRecipe == null)
			{
				component.SetRecipe(component.ProductionRecipes[0]);
			}
		}
	}
}
