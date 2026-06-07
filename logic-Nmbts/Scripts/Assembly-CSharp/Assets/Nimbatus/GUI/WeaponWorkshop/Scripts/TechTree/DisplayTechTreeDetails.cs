using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts.TechTree
{
	public class DisplayTechTreeDetails : MonoBehaviour
	{
		public TechTreeDisplay TechTree;

		public UITexture Icon;

		public UILabel NameLabel;

		public UILabel DescriptionLabel;

		public ResourcePriceList PriceList;

		public UnlockTech UnlockButton;

		public TweenPosition Tween;

		private UpgradeNode _selectedNode;

		private bool _wasLocked;

		public void Update()
		{
			if (TechTree.SelectedNode == null)
			{
				Tween.Play(false);
				return;
			}
			Tween.Play(true);
			if (!(_selectedNode != TechTree.SelectedNode) && (!_wasLocked || !_selectedNode.Upgrade.Unlocked) && (_wasLocked || _selectedNode.Upgrade.Unlocked))
			{
				return;
			}
			_selectedNode = TechTree.SelectedNode;
			NameLabel.text = LabelHelper.Blue + _selectedNode.Upgrade.Name;
			DescriptionLabel.text = _selectedNode.GetDescription();
			if (!_selectedNode.Upgrade.Unlocked)
			{
				UnlockButton.gameObject.SetActive(true);
				if (RuntimeGlobals.GameModeSettings.FreeTechnology)
				{
					PriceList.gameObject.SetActive(false);
					UnlockButton.Init(_selectedNode, EUnlockMode.FreeUnlock);
				}
				else
				{
					PriceList.gameObject.SetActive(true);
					PriceList.Fill(_selectedNode.Upgrade);
					UnlockButton.Init(_selectedNode, EUnlockMode.Normal);
				}
				_wasLocked = true;
			}
			else
			{
				PriceList.gameObject.SetActive(false);
				if (!RuntimeGlobals.GameModeSettings.AllTechnologyUnlocked && RuntimeGlobals.GameModeSettings.FreeTechnology)
				{
					UnlockButton.gameObject.SetActive(true);
					UnlockButton.Init(_selectedNode, EUnlockMode.FreeLock);
				}
				else
				{
					UnlockButton.gameObject.SetActive(false);
				}
				_wasLocked = false;
			}
			Icon.mainTexture = _selectedNode.Icon.mainTexture;
		}
	}
}
