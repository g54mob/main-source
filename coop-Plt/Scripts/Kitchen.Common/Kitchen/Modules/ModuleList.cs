using UnityEngine;

namespace Kitchen.Modules
{
	public class ModuleList : ModuleSet
	{
		public Direction Direction;

		public float Padding = 0.1f;

		public override Bounds BoundingBox
		{
			get
			{
				Bounds boundingBox = base.BoundingBox;
				boundingBox.Expand(new Vector3((Direction == Direction.Horizontal) ? Padding : 0f, (Direction == Direction.Vertical) ? Padding : 0f));
				return boundingBox;
			}
		}

		protected Vector2 ExtremeMidpoint
		{
			get
			{
				Bounds boundingBox = BoundingBox;
				Vector2 result = default(Vector2);
				switch (Direction)
				{
				case Direction.Vertical:
					result.x = 0f;
					result.y = boundingBox.min.y - Padding;
					break;
				case Direction.Horizontal:
					result.x = boundingBox.max.x + Padding;
					result.y = 0f;
					break;
				}
				return result;
			}
		}

		protected Vector2 DirectionVector => Direction switch
		{
			Direction.Horizontal => new Vector2(1f, 0f), 
			Direction.Vertical => new Vector2(0f, -1f), 
			_ => default(Vector2), 
		};

		protected Vector2 GetBoundsInDirection(Bounds b)
		{
			Vector2 result;
			switch (Direction)
			{
			case Direction.Horizontal:
				result = new Vector2(b.extents.x / 2f, 0f);
				break;
			case Direction.Vertical:
				return -new Vector2(0f, b.extents.y / 2f);
			default:
				result = default(Vector2);
				break;
			}
			return result;
		}

		public void AddModule(IModule module)
		{
			if (Modules.Count == 0)
			{
				module.Position = Vector2.zero;
			}
			else
			{
				module.Position = ExtremeMidpoint + GetBoundsInDirection(module.BoundingBox);
			}
			AddModule(module, module.Position);
		}
	}
}
