using Unity.Mathematics;

namespace Pug.UnityExtensions
{
	public struct FourDirectionFloat2
	{
		public float2 right;

		public float2 back;

		public float2 left;

		public float2 forward;

		public readonly float2 GetDataInDirection(Direction.Id direction, float2 defaultValue)
		{
			return direction switch
			{
				Direction.Id.right => right, 
				Direction.Id.back => back, 
				Direction.Id.left => left, 
				Direction.Id.forward => forward, 
				_ => defaultValue, 
			};
		}

		public void SetDataInDirection(Direction.Id id, float2 value)
		{
			switch (id)
			{
			case Direction.Id.right:
				right = value;
				break;
			case Direction.Id.back:
				back = value;
				break;
			case Direction.Id.left:
				left = value;
				break;
			case Direction.Id.forward:
				forward = value;
				break;
			}
		}
	}
}
