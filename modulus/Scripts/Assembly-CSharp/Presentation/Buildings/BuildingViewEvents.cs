using System;

namespace Presentation.Buildings
{
	public interface BuildingViewEvents
	{
		event Action OnBuildingInit;

		event Action OnBuildingPreviewInit;
	}
}
