using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct AnimationOrientationCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Direction facingDirection;

	public bool canOnlyFaceHorizontally;

	public bool supportEightDirections;

	public void SetFacingDirectionFromVector(float2 targetDir)
	{
		SetFacingDirectionFromVector(new float3(targetDir.x, 0f, targetDir.y));
	}

	public void SetFacingDirectionFromVector(float3 targetDir)
	{
		if (canOnlyFaceHorizontally)
		{
			facingDirection = ((targetDir.x >= 0f) ? Direction.right : Direction.left);
		}
		else if (supportEightDirections)
		{
			facingDirection = Direction.FromVectorEightDirections(targetDir, 0f);
		}
		else
		{
			facingDirection = Direction.FromVector(targetDir, 0f);
		}
	}
}
