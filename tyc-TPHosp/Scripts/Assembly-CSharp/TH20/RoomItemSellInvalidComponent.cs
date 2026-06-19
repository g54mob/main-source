using System;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly]
	public class RoomItemSellInvalidComponent : EntityTickComponent
	{
		private RoomItem _roomItem;

		[DontSave]
		private bool _destroy;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_roomItem = GetOwner<RoomItem>();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			_destroy = true;
		}

		public override void Destroy()
		{
			_roomItem.Visual?.DisableAndDestroyEditingVisuals();
			base.Level.StatusIconManager.DestroyStatusIcon(_roomItem);
			base.Destroy();
		}

		public override void Tick()
		{
			base.Tick();
			if (_destroy)
			{
				Destroy();
				return;
			}
			RoomItemVisual visual = _roomItem.Visual;
			if (visual != null)
			{
				visual.EnableEditingMaterials();
				visual.UpdateFrom(_roomItem, snap: false);
			}
			if (_roomItem.Cost != 0)
			{
				base.Level.StatusIconManager.ShowStatusIcon(_roomItem, StatusIcon.Type.SellInvalid);
			}
		}
	}
}
