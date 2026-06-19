using System;
using FullInspector.Generated.SharedInstance;
using UnityEngine;

namespace TH20
{
	public class RoomItemMaterialSwapOnLevelsComponent : EntityComponent
	{
		[SerializeField]
		private RoomItemMaterialSwapOnLevelConfigsComponent _config;

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
			SharedInstance_TH20TH20_LevelConfig[] levels = _config.Levels;
			foreach (SharedInstance_TH20TH20_LevelConfig sharedInstance_TH20TH20_LevelConfig in levels)
			{
				if (_roomItem.Level.Config == sharedInstance_TH20TH20_LevelConfig.Instance)
				{
					_roomItem.Visual.SwapMaterials(_config.OriginalMaterials, _config.NewMaterials);
				}
			}
		}
	}
}
