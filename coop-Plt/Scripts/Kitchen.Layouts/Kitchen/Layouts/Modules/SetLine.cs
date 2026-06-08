using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Set Line")]
	public class SetLine : LayoutModule
	{
		public int Position;

		public bool IsRow;

		public RoomType Type;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			Bounds bounds = blueprint.GetBounds();
			Room value = new Room(Type);
			if (IsRow)
			{
				int num = (int)bounds.max.x;
				while ((float)num >= bounds.min.x)
				{
					blueprint[num, Position] = value;
					num--;
				}
			}
			else
			{
				int num2 = (int)bounds.max.y;
				while ((float)num2 >= bounds.min.y)
				{
					blueprint[Position, num2] = value;
					num2--;
				}
			}
		}
	}
}
