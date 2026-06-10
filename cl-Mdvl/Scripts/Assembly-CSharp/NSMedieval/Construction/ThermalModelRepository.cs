using NSEipix.Repository;

namespace NSMedieval.Construction
{
	public class ThermalModelRepository : DynamicJsonRepository<ThermalModelRepository, ThermalModel>
	{
		private const string GroundThermalModelId = "ground";

		private ThermalModel groundThermalModel;

		protected override string JsonFile()
		{
			return "Constructables/ThermalModels.json";
		}

		public ThermalModel GroundThermalModel()
		{
			if (groundThermalModel == null)
			{
				groundThermalModel = Repository<ThermalModelRepository, ThermalModel>.Instance.GetByID("ground");
			}
			return groundThermalModel;
		}
	}
}
