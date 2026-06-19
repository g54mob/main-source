using System.Collections.Generic;

namespace TH20
{
	public class RoomCustomisations
	{
		private Dictionary<RoomDefinition.Type, IWallVisualOverrideDefinition> _wallTextureOverrides = new Dictionary<RoomDefinition.Type, IWallVisualOverrideDefinition>();

		private Dictionary<RoomDefinition.Type, IFloorVisualOverrideDefinition> _floorTextureOverrides = new Dictionary<RoomDefinition.Type, IFloorVisualOverrideDefinition>();

		public void SetDefaultWallVisualOverride(RoomDefinition.Type roomType, IWallVisualOverrideDefinition definition)
		{
			_wallTextureOverrides[roomType] = definition;
		}

		public void SetDefaultFloorVisualOverride(RoomDefinition.Type roomType, IFloorVisualOverrideDefinition definition)
		{
			_floorTextureOverrides[roomType] = definition;
		}

		public bool GetDefaultWallVisualOverride(RoomDefinition.Type roomType, out IWallVisualOverrideDefinition definition)
		{
			return _wallTextureOverrides.TryGetValue(roomType, out definition);
		}

		public bool GetDefaultFloorVisualOverride(RoomDefinition.Type roomType, out IFloorVisualOverrideDefinition definition)
		{
			return _floorTextureOverrides.TryGetValue(roomType, out definition);
		}
	}
}
