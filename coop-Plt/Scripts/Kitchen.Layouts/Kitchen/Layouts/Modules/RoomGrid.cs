using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Source/New Room Grid")]
	public class RoomGrid : LayoutModule
	{
		public int Width;

		public int Height;

		public RoomType Type;

		public bool SetType;

		protected override LayoutBlueprint Generate()
		{
			LayoutBlueprint layoutBlueprint = LayoutBlueprint.New;
			ActOn(layoutBlueprint);
			return layoutBlueprint;
		}

		public override void ActOn(LayoutBlueprint blueprint)
		{
			blueprint.Features.Clear();
			blueprint.Tiles.Clear();
			Room value = default(Room);
			if (SetType)
			{
				value = new Room(Type);
			}
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					if (SetType)
					{
						blueprint[i, j] = value;
					}
					else
					{
						blueprint[i, j] = Room.New;
					}
				}
			}
		}
	}
}
