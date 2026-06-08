using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Set Room")]
	public class SetRoom : LayoutModule
	{
		public int X;

		public int Y;

		public RoomType Type;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			blueprint[X, Y] = new Room(Type);
		}
	}
}
