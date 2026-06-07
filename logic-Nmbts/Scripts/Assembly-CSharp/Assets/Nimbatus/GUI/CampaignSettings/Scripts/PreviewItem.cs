using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.GUI.CampaignSettings.Scripts
{
	public class PreviewItem : MonoBehaviour
	{
		public UITexture Texture;

		public UITexture ColoredTexture;

		public UILabel Label;

		private string _toolTip;

		private WeaponPreset _weapon;

		public void Init(WeaponPreset weapon, int amount)
		{
			Texture.mainTexture = weapon.Emitter.GetIcon();
			ColoredTexture.enabled = false;
			Label.text = amount.ToString();
			_weapon = weapon;
		}

		public void Init(Texture2D texture, string text, string toolTip)
		{
			Texture.mainTexture = texture;
			ColoredTexture.enabled = false;
			Label.text = text;
			_toolTip = toolTip;
		}

		public void OnTooltip(bool show)
		{
			if (_weapon != null)
			{
				NimbatusToolTip.ShowWeapon(_weapon, true, show);
			}
			else
			{
				NimbatusToolTip.Show(show ? _toolTip : null);
			}
		}
	}
}
