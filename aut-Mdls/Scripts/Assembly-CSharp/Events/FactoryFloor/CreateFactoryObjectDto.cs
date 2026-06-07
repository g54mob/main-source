using Data.FactoryFloor;
using UnityEngine;

namespace Events.FactoryFloor
{
	public class CreateFactoryObjectDto
	{
		public Vector3 Position { get; }

		public int Rotation { get; }

		public bool Mirrored { get; }

		public FactoryObject FactoryObject { get; set; }

		public int BlueprintElementIndex { get; }

		public bool IsGameLoading { get; }

		public CreateFactoryObjectDto(Vector3 position, int rotation, bool mirrored, FactoryObject factoryObject, int blueprintElementIndex = -1, bool isGameLoading = false)
		{
			Position = position;
			Mirrored = mirrored;
			FactoryObject = factoryObject;
			Rotation = rotation;
			BlueprintElementIndex = blueprintElementIndex;
			IsGameLoading = isGameLoading;
		}
	}
}
