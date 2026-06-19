using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Room Visual Overrides Database", order = 1033)]
	public class RoomVisualOverridesDatabase : ScriptableObjectWithID
	{
		[SerializeField]
		private WallVisualOverrideDefinition[] _wallVisualOverrideDefinitions;

		[SerializeField]
		private FloorVisualOverrideDefinition[] _floorVisualOverrideDefinitions;

		public WallVisualOverrideDefinition[] WallVisualOverrideDefinitions => _wallVisualOverrideDefinitions;

		public FloorVisualOverrideDefinition[] FloorVisualOverrideDefinitions => _floorVisualOverrideDefinitions;
	}
}
