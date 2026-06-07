using System;
using Unity.Entities;
using Unity.Properties;

namespace Pathfinding.ECS
{
	[Serializable]
	[GeneratePropertyBag]
	public struct DestinationEntity : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
		public Entity destination;

		public bool useRotation;
	}
}
