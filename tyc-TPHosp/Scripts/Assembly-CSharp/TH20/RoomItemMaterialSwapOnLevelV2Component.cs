using System;
using UnityEngine;

namespace TH20
{
	public class RoomItemMaterialSwapOnLevelV2Component : EntityComponent
	{
		[SerializeField]
		private RoomItemMaterialSwapOnLevelConfigComponent _config;

		private RoomItem _roomItem;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_roomItem = GetOwner<RoomItem>();
			SetupVisualData();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			SetupVisualData();
		}

		private void SetupVisualData()
		{
			if (_roomItem.Visual == null)
			{
				_roomItem.OnVisualSet += OnRoomItemVisualSet;
			}
			else
			{
				OnRoomItemVisualSet();
			}
		}

		private void OnRoomItemVisualSet()
		{
			_roomItem.OnVisualSet -= OnRoomItemVisualSet;
			if (_roomItem.Level.Config == _config.Level.Instance)
			{
				_roomItem.Visual.SwapMaterials(_config.OriginalMaterials, _config.NewMaterials);
			}
		}
	}
}
