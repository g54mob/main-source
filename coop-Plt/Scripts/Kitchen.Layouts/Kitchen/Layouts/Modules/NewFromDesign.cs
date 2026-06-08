using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Source/New From Design")]
	public class NewFromDesign : LayoutModule
	{
		public LayoutDesign Design;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			blueprint.Features.Clear();
			blueprint.Tiles.Clear();
			for (int i = 0; i < Design.Rooms.GetLength(0); i++)
			{
				for (int j = 0; j < Design.Rooms.GetLength(1); j++)
				{
					LayoutDesign.DesignRoom designRoom = Design.Rooms[i, j];
					LayoutDesign.ColorRoom colorRoom = Design.RoomSet[designRoom.Room];
					blueprint[i, j] = colorRoom.Room;
					if (designRoom.HasBottomFeature)
					{
						blueprint.Features.Add(new Feature(new LayoutPosition(i, j), new LayoutPosition(i, j + 1), Design.FeatureSet[designRoom.BottomFeature].Feature));
					}
					if (designRoom.HasRightFeature)
					{
						blueprint.Features.Add(new Feature(new LayoutPosition(i, j), new LayoutPosition(i + 1, j), Design.FeatureSet[designRoom.RightFeature].Feature));
					}
				}
			}
		}
	}
}
