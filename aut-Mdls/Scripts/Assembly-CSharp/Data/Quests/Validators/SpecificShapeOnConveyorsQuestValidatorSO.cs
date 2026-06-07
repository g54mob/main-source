using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Shapes;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Specific Shape On Conveyors", fileName = "SpecificShapeOnConveyors", order = 6)]
	public class SpecificShapeOnConveyorsQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryObjectData _conveyorData;

		[SerializeField]
		private ShapeDataSO _shape;

		[SerializeField]
		private int _shapesNeededOnConveyor;

		public override bool IsValid()
		{
			List<FactoryObject> objectsFromData = _factoryLayer.GetObjectsFromData(_conveyorData);
			int num = 0;
			foreach (FactoryObject item in objectsFromData)
			{
				ConveyorBehaviour factoryObjectBehaviour = item.GetFactoryObjectBehaviour<ConveyorBehaviour>();
				if (factoryObjectBehaviour.HasResource() && factoryObjectBehaviour.Resource is ShapeResource shapeResource)
				{
					if (_shape.Data.RotationIndependantHash.Contains(shapeResource.ShapeData.GetShapeHash()))
					{
						num++;
					}
					if (num >= _shapesNeededOnConveyor)
					{
						break;
					}
				}
			}
			return num >= _shapesNeededOnConveyor;
		}

		public override void Reset()
		{
		}
	}
}
