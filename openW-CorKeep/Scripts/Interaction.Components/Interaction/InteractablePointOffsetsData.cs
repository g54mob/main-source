using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

namespace Interaction
{
	public struct InteractablePointOffsetsData
	{
		public BlobArray<InteractablePointsOffsetsInDirection> pointOffsets;

		public ref BlobArray<float3> GetInteractablePointsInDirection(Direction.Id direction)
		{
			return direction switch
			{
				Direction.Id.right => ref pointOffsets[0].values, 
				Direction.Id.back => ref pointOffsets[1].values, 
				Direction.Id.left => ref pointOffsets[2].values, 
				_ => ref pointOffsets[3].values, 
			};
		}
	}
}
