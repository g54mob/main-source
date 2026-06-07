using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionRewards.Scripts
{
	public class RewardChestItem : MonoBehaviour
	{
		public UITexture Texture;

		public UITexture ColoredTexture;

		public UILabel AmountLabel;

		private string _toolTip;

		private Weapon _weapon;

		public void Init(BaseReceivable receivable)
		{
			AmountLabel.text = receivable.GetAmount();
			Texture.mainTexture = receivable.GetIcon();
			_toolTip = receivable.GetToolTip();
			WeaponReceivable weaponReceivable;
			if ((weaponReceivable = receivable as WeaponReceivable) != null)
			{
				ColoredTexture.gameObject.SetActive(true);
				Weapon generatedWeapon = weaponReceivable.GetGeneratedWeapon();
				_toolTip = generatedWeapon.GetTooltip();
				_weapon = generatedWeapon;
				Texture.mainTexture = generatedWeapon.GetIcon();
				ColoredTexture.mainTexture = generatedWeapon.Emitter.AmmunitionTexture;
				ColoredTexture.color = generatedWeapon.Ammunition.IconColorModifier;
			}
			else
			{
				ColoredTexture.gameObject.SetActive(false);
			}
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				if (_weapon != null)
				{
					NimbatusToolTip.ShowWeapon(_weapon, true);
				}
				else
				{
					NimbatusToolTip.Show(_toolTip);
				}
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
