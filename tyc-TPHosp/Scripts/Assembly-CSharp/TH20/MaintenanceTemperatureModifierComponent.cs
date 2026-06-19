using System;
using FullInspector;
using UnityEngine;

namespace TH20
{
	public class MaintenanceTemperatureModifierComponent : EntityTickComponent
	{
		[InspectorTooltip("Maintenance += Temperature * Multiplier * Delta Time")]
		[SerializeField]
		private float _multiplier = 1f;

		private RoomItem _roomItem;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_roomItem = GetOwner<RoomItem>();
		}

		public override void Tick()
		{
			base.Tick();
			if (_roomItem.MaintenanceLevel != null && _roomItem.GetAttributes().Enabled)
			{
				float mapAttribute = _roomItem.Level.WorldState.HospitalAttributeMaps[0].GetMapAttribute(_roomItem.WorldPosition);
				if (mapAttribute > 0f)
				{
					_roomItem.MaintenanceLevel.Modify(_multiplier * mapAttribute * Time.deltaTime, 1f);
				}
			}
		}
	}
}
