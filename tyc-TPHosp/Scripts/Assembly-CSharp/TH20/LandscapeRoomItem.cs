using JetBrains.Annotations;

namespace TH20
{
	[DontSave]
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class LandscapeRoomItem : RoomItem
	{
		private HospitalPlotLayer _layer;

		public HospitalPlotLayer Layer => _layer;

		public LandscapeRoomItem(RoomItemDefinition definition, FloorPlan floorPlan, Level level, HospitalPlotLayer layer)
			: base(definition, floorPlan, level)
		{
			_layer = layer;
		}

		public LandscapeRoomItem(RoomItem item, FloorPlan floorPlan, HospitalPlotLayer layer)
			: base(item, floorPlan)
		{
			_layer = layer;
		}

		public override bool ShouldSave()
		{
			return false;
		}

		public override void AddToWorld(bool updateNavigation)
		{
			RoomItemModifyTerrainComponent component = GetComponent<RoomItemModifyTerrainComponent>();
			if (component != null && DebugVars.AllowTerrainModification.Value)
			{
				component.ModifyTerrain();
			}
			if (updateNavigation && base.Definition.AffectsNavigation)
			{
				base.Level.WorldState.UpdateNavigation();
			}
		}

		public override void RemoveFromWorld(bool updateNavigation)
		{
			RoomItemModifyTerrainComponent component = GetComponent<RoomItemModifyTerrainComponent>();
			if (component != null && DebugVars.AllowTerrainModification.Value)
			{
				component.RestoreTerrain();
			}
			if (updateNavigation && base.Definition.AffectsNavigation)
			{
				base.Level.WorldState.UpdateNavigation();
			}
		}
	}
}
