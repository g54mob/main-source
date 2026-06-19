using System.Collections.Generic;

namespace TH20
{
	public class RoomTemplate
	{
		public int TemplateID;

		public readonly RoomDefinition.Type RoomType;

		public readonly RoomTemplateFloorPlan TemplateFloorPlan;

		public readonly List<RoomItemDefinitionUGC> UGCItems;

		public readonly IFloorVisualOverrideDefinition FloorVisualOverride;

		public readonly IWallVisualOverrideDefinition WallVisualOverride;

		[DontSave]
		public string GeneratedFileName;

		private string _userDefinedName;

		[DontSave]
		public List<uint> UsedDLCAppIDs = new List<uint>();

		[DontSave]
		public bool DisableFloorVisualOverride;

		[DontSave]
		public bool DisableWallVisualOverride;

		public string UserDefinedName
		{
			get
			{
				return _userDefinedName;
			}
			set
			{
				_userDefinedName = value;
			}
		}

		public RoomTemplate(int id, RoomDefinition.Type roomType, RoomTemplateFloorPlan floorPlan, IFloorVisualOverrideDefinition floorVisualOverride, IWallVisualOverrideDefinition wallVisualOverride, string userDefinedName, string fileName)
		{
			TemplateID = id;
			RoomType = roomType;
			TemplateFloorPlan = floorPlan;
			_userDefinedName = userDefinedName;
			FloorVisualOverride = floorVisualOverride;
			WallVisualOverride = wallVisualOverride;
			GeneratedFileName = fileName;
			UGCItems = new List<RoomItemDefinitionUGC>();
			foreach (RoomTemplateItem item in floorPlan.Items)
			{
				if (item.UGCDefinition != null)
				{
					UGCItems.AddUnique(item.UGCDefinition);
				}
			}
		}

		public void FixupUGCDefinitions(App app)
		{
			if (UGCItems != null)
			{
				foreach (RoomItemDefinitionUGC uGCItem in UGCItems)
				{
					uGCItem?.RestoreFromSave(app.UGCRuntimePrefabManager, app.UGCRoomItemDefinitionDatabase);
				}
			}
			if (FloorVisualOverride != null && FloorVisualOverride is FloorVisualOverrideDefinitionUGC)
			{
				((FloorVisualOverrideDefinitionUGC)FloorVisualOverride).RestoreFromSave(app.UGCFloorVisualOverrideDefinitionDatabase);
			}
			if (WallVisualOverride != null && WallVisualOverride is WallVisualOverrideDefinitionUGC)
			{
				((WallVisualOverrideDefinitionUGC)WallVisualOverride).RestoreFromSave(app.UGCWallVisualOverrideDefinitionDatabase);
			}
		}
	}
}
