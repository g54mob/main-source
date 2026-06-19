using System.Collections.Generic;
using FullInspector;

namespace TH20
{
	public class RoomTemplateFloorPlan
	{
		private BoolArray2D _tiles;

		public GridCoord Anchor;

		public RoomDefinition Definition;

		public List<WallCoord> Walls;

		public List<RoomTemplateItem> Items;

		[DontSave]
		public List<RoomTemplateItem> DLCItemsToRemove;

		[DontSave]
		public List<RoomTemplateItem> InLevelItemsToRemove;

		public GridBounds WorldBounds { get; private set; }

		public bool this[int x, int y]
		{
			get
			{
				return _tiles.Values[x, y];
			}
			set
			{
				_tiles.Values[x, y] = value;
			}
		}

		public bool this[GridCoord coord]
		{
			get
			{
				return _tiles.Values[coord.X, coord.Y];
			}
			set
			{
				_tiles.Values[coord.X, coord.Y] = value;
			}
		}

		public int Width()
		{
			if (_tiles.Values == null)
			{
				return 0;
			}
			return _tiles.Values.GetLength(0);
		}

		public int Height()
		{
			if (_tiles.Values == null)
			{
				return 0;
			}
			return _tiles.Values.GetLength(1);
		}

		public RoomTemplateFloorPlan()
		{
			DLCItemsToRemove = new List<RoomTemplateItem>();
			InLevelItemsToRemove = new List<RoomTemplateItem>();
		}

		public RoomTemplateFloorPlan(FloorPlan floorPlan)
		{
			Definition = floorPlan.Definition;
			int num = floorPlan.Width();
			int num2 = floorPlan.Height();
			_tiles = new BoolArray2D
			{
				Values = new bool[num, num2]
			};
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					_tiles.Values[j, i] = floorPlan[j, i];
				}
			}
			Anchor = floorPlan.Anchor;
			Walls = floorPlan.Walls;
			WorldBounds = floorPlan.WorldBounds;
			Items = new List<RoomTemplateItem>();
			DLCItemsToRemove = new List<RoomTemplateItem>();
			InLevelItemsToRemove = new List<RoomTemplateItem>();
			foreach (RoomItem item in floorPlan.Items)
			{
				RoomTemplateItem roomTemplateItem = new RoomTemplateItem();
				if (item.Definition is RoomItemDefinition instance)
				{
					SharedInstance<RoomItemDefinition> sharedInstance = SharedInstanceUtils.GetSharedInstance(instance);
					roomTemplateItem.Definition = sharedInstance;
					roomTemplateItem.Position = item.LocalPosition;
					roomTemplateItem.Rotation = item.Rotation;
					roomTemplateItem.IsHospitalWindow = item.IsHospitalWindow;
					Items.Add(roomTemplateItem);
				}
				else if (item.Definition is RoomItemDefinitionUGC uGCDefinition)
				{
					roomTemplateItem.UGCDefinition = uGCDefinition;
					roomTemplateItem.Position = item.LocalPosition;
					roomTemplateItem.Rotation = item.Rotation;
					roomTemplateItem.IsHospitalWindow = item.IsHospitalWindow;
					Items.Add(roomTemplateItem);
				}
			}
		}
	}
}
