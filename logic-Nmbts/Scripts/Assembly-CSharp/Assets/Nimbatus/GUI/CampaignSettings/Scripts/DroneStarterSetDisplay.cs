using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.CampaignSettings.Scripts
{
	public class DroneStarterSetDisplay : MonoBehaviour
	{
		private DronePartStarterSet _set;

		public GameObject AllPartsUnlockedDisplay;

		public PreviewItem ItemPrefab;

		public UIGrid ContainerGrid;

		public void Init(DronePartStarterSet set, DronePerk perk)
		{
			_set = set;
			ContainerGrid.transform.DestroyAllChildren();
			AllPartsUnlockedDisplay.SetActive(set.AllPartsUnlocked);
			foreach (DronePartStack item in set.StartingParts.Where((DronePartStack sp) => !sp.CombinedParts))
			{
				PreviewItem previewItem = Object.Instantiate(ItemPrefab, ContainerGrid.transform);
				item.DronePart.InitDronePerkSettings(perk.Effects.Select((DroneEffectSetting e) => e.Effect).ToList());
				previewItem.Init(item.DronePart.GetIcon(), item.Amount.ToString(), item.DronePart.GetTooltip());
				previewItem.transform.position = ContainerGrid.transform.position;
				previewItem.transform.parent = ContainerGrid.transform;
				previewItem.transform.localScale = Vector3.one;
			}
			foreach (DronePartStack item2 in set.StartingParts.Where((DronePartStack sp) => sp.CombinedParts))
			{
				PreviewItem previewItem2 = Object.Instantiate(ItemPrefab, ContainerGrid.transform);
				previewItem2.Init(item2.CombinedPartsIcon, item2.Amount.ToString(), LabelHelper.Blue + item2.CombinedPartsToolTip.GetTranslation());
				previewItem2.transform.position = ContainerGrid.transform.position;
				previewItem2.transform.parent = ContainerGrid.transform;
				previewItem2.transform.localScale = Vector3.one;
			}
			foreach (WeaponStack weapon in set.Weapons)
			{
				weapon.Weapon.SetDefaultName();
				PreviewItem previewItem3 = Object.Instantiate(ItemPrefab, ContainerGrid.transform);
				previewItem3.Init(weapon.Weapon, weapon.Weapon.StackSize);
				previewItem3.ColoredTexture.mainTexture = weapon.Weapon.Emitter.AmmunitionTexture;
				previewItem3.ColoredTexture.color = weapon.Weapon.Ammunition.IconColorModifier;
				previewItem3.ColoredTexture.enabled = true;
				previewItem3.transform.position = ContainerGrid.transform.position;
				previewItem3.transform.parent = ContainerGrid.transform;
				previewItem3.transform.localScale = Vector3.one;
			}
			ContainerGrid.Reposition();
		}
	}
}
