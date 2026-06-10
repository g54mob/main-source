using System.Collections.Generic;
using NSMedieval.BuildingComponents;
using NSMedieval.State;

namespace NSMedieval.UI
{
	public class InfoPanelProduction : SelectionExtraView
	{
		private List<string> possibleProductions = new List<string>();

		private ProductionSystemInstance productionSystemInstance;

		private ProductionComponentInstance selectedProductionComponentInstance;

		public List<string> PossibleProductions => possibleProductions;

		public List<ProductionInstance> CurrentProductions => productionSystemInstance?.Productions;

		public ProductionComponentInstance SelectedProductionComponentInstance => selectedProductionComponentInstance;

		public InfoPanelProduction(List<string> possibleProductions, ProductionSystemInstance productionSystemInstance)
		{
			this.possibleProductions = possibleProductions;
			this.productionSystemInstance = productionSystemInstance;
			selectedProductionComponentInstance = productionSystemInstance?.Owner;
		}
	}
}
