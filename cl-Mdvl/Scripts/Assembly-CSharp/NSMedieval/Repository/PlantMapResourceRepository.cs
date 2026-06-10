using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class PlantMapResourceRepository : DynamicJsonRepository<PlantMapResourceRepository, PlantMapResource>
	{
		protected override string JsonFile()
		{
			return "Resources/PlantMapResource.json";
		}

		public override void Deserialize()
		{
			base.Deserialize();
			SetHarvestablePhase();
			SetCutPhase();
		}

		private void SetHarvestablePhase()
		{
			foreach (PlantMapResource allItem in GetAllItems())
			{
				allItem.SetHarvestablePhases();
			}
		}

		private void SetCutPhase()
		{
			foreach (PlantMapResource allItem in GetAllItems())
			{
				allItem.SetCutPhases();
			}
		}
	}
}
