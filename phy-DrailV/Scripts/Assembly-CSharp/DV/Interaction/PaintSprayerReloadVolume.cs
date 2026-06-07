using UnityEngine;

namespace DV.Interaction
{
	public class PaintSprayerReloadVolume : ItemMagazineTriggerReloadVolume<PaintCan>
	{
		private PaintSprayer paintSprayer;

		protected override bool Initialize()
		{
			paintSprayer = GetComponentInParent<PaintSprayer>();
			if (paintSprayer == null)
			{
				Debug.LogError("PaintSprayerReloadVolume: Missing PaintSprayer. Destroying self.", this);
				Object.Destroy(this);
				return false;
			}
			return true;
		}

		public override bool ValidReload(PaintCan ammo)
		{
			if (ammo == null)
			{
				return false;
			}
			if (!VRManager.IsVREnabled() && (ammo.Item.IsGrabbed() || magazineItem.IsGrabbed()))
			{
				return false;
			}
			return paintSprayer.IsUseCompatible(ammo.AmmoUseTarget);
		}
	}
}
