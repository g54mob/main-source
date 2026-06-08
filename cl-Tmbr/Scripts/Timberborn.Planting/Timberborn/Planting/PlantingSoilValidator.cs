using Timberborn.SoilContaminationSystem;
using Timberborn.SoilMoistureSystem;
using UnityEngine;

namespace Timberborn.Planting
{
	internal class PlantingSoilValidator
	{
		private readonly ISoilMoistureService _soilMoistureService;

		private readonly ISoilContaminationService _soilContaminationService;

		public PlantingSoilValidator(ISoilMoistureService soilMoistureService, ISoilContaminationService soilContaminationService)
		{
			_soilMoistureService = soilMoistureService;
			_soilContaminationService = soilContaminationService;
		}

		public bool Validate(PlantingSpot plantingSpot)
		{
			Vector3Int coordinates = plantingSpot.Coordinates;
			if (!_soilMoistureService.SoilIsMoist(coordinates))
			{
				return false;
			}
			if (_soilContaminationService.SoilIsContaminated(coordinates))
			{
				return false;
			}
			return true;
		}
	}
}
