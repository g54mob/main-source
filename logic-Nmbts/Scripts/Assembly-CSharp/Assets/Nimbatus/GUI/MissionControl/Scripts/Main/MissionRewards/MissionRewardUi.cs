using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main.MissionRewards
{
	public class MissionRewardUi : MonoBehaviour
	{
		public UITexture Texture;

		public UILabel AmountLabel;

		private string _tooltip;

		public void Init(Texture2D image, string toolTip, string amount)
		{
			Texture.mainTexture = image;
			AmountLabel.text = amount;
			_tooltip = toolTip;
		}

		public void Init(BaseReceivable receivable, bool received)
		{
			Init(receivable.GetIcon(), receivable.GetToolTip(), receivable.GetAmount());
			WeaponReceivable weaponReceivable;
			if ((weaponReceivable = receivable as WeaponReceivable) != null && !weaponReceivable.HideRarity)
			{
				Texture.color = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.RarityColors[weaponReceivable.Rarity];
			}
			Texture.color = new Color(Texture.color.r, Texture.color.g, Texture.color.b, received ? 0.75f : 1f);
			Material material = new Material(Texture.material);
			material.SetFloat("_Grayscale", received ? 1 : 0);
			Texture.material = material;
		}

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show(show ? _tooltip : null);
		}
	}
}
