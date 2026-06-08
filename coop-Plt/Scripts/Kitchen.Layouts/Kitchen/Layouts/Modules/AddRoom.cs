using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Add Room")]
	public class AddRoom : LayoutModule
	{
		public int X;

		public int Y;

		public int Height;

		public int Width;

		public RoomType Type;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			Room value = new Room(Type);
			for (int i = Y; i < Y + Height; i++)
			{
				for (int j = X; j < X + Width; j++)
				{
					blueprint[j, i] = value;
				}
			}
		}
	}
}
