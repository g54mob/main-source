using Data.Operator;
using Events.UI;
using Presentation.FactoryFloor;
using UnityEngine;

namespace Events.FactoryFloor
{
	public class OperatorHoverDto : InfoPanelDto
	{
		public Vector3 Position;

		public FactoryObjectView FactoryObjectView;

		public FactoryObjectUIData FactoryObjectUIData;

		public OperatorHoverDto(FactoryObjectView factoryObjectView, FactoryObjectUIData factoryObjectUIData, Vector3 position)
		{
			FactoryObjectView = factoryObjectView;
			FactoryObjectUIData = factoryObjectUIData;
			Position = position;
		}
	}
}
