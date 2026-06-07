using Motorways.Models;
using Motorways.Views.MeshGeneration;

namespace Motorways.Views
{
	public class DraftDestinationBuildingViewModel
	{
		public int groupIndex;

		public int upgradeLevel;

		public DestinationMesh.Type GetMeshType(bool isTrainStation, BuildingLayout buildingLayout)
		{
			if (!isTrainStation)
			{
				if (upgradeLevel != 1)
				{
					return DestinationMesh.Type.Square;
				}
				return DestinationMesh.Type.Circle;
			}
			if (buildingLayout != BuildingLayout.BuildingAbove)
			{
				return DestinationMesh.Type.StationVertical;
			}
			return DestinationMesh.Type.StationHorizontal;
		}

		public void Reset()
		{
			groupIndex = 0;
			upgradeLevel = 0;
		}
	}
}
