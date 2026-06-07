using System.Globalization;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class ScrapableItem : MonoBehaviour
	{
		public UITexture Icon;

		public UITexture ColoredIcon;

		public UILabel StackSizeLabel;

		public UITexture Background;

		public Color StartColor;

		public Color SelectedColor;

		public bool ShowInUseWarning;

		public UILabel InUseWarning;

		[HideInInspector]
		public Weapon Item;

		[HideInInspector]
		public bool Clickable = true;

		private bool _noStacks;

		private UIDragScrollView _uiDragPanelContents;

		private bool _hideStacks;

		private int _stackReduction;

		public void Awake()
		{
			_uiDragPanelContents = GetComponent<UIDragScrollView>();
			_noStacks = false;
			StackSizeLabel.text = "";
			Init();
		}

		public void Init(UIScrollView panel, Weapon item, bool hideStacks = false)
		{
			Item = item;
			_hideStacks = hideStacks;
			_uiDragPanelContents.scrollView = panel;
			Init();
		}

		public bool HasAvailableStacks()
		{
			return Item.CurrentStackSize - _stackReduction > 0;
		}

		public void Init()
		{
			if (Icon != null)
			{
				if (Item == null)
				{
					Icon.enabled = false;
				}
				else
				{
					Texture2D icon = Item.GetIcon();
					Icon.mainTexture = icon;
					Icon.enabled = true;
				}
			}
			if (ShowInUseWarning)
			{
				InUseWarning.text = "In Use";
			}
			else
			{
				InUseWarning.text = "";
			}
			if (ColoredIcon != null)
			{
				if (Item != null)
				{
					ColoredIcon.mainTexture = Item.Emitter.AmmunitionTexture;
					ColoredIcon.color = Item.Ammunition.IconColorModifier;
					ColoredIcon.enabled = true;
				}
				else
				{
					ColoredIcon.enabled = false;
				}
			}
			UpdateStackSizeLabel();
		}

		public void Update()
		{
			if (BaseSingleton<ScrapyardManager>.Instance != null)
			{
				if (BaseSingleton<ScrapyardManager>.Instance.SelectedItem == this)
				{
					Background.color = SelectedColor;
				}
				else
				{
					Background.color = StartColor;
				}
			}
			UpdateStackSizeLabel();
		}

		private void UpdateStackSizeLabel()
		{
			if (_hideStacks)
			{
				StackSizeLabel.text = "";
			}
			else if (Item != null)
			{
				if (Item.IsStackable && !Item.UnlimitedStackSize)
				{
					int num = Item.CurrentStackSize - _stackReduction;
					_noStacks = num <= 0;
					StackSizeLabel.text = (_noStacks ? LabelHelper.DarkOrange : LabelHelper.White) + num.ToString(CultureInfo.InvariantCulture);
				}
				else
				{
					StackSizeLabel.text = "";
				}
			}
			else
			{
				StackSizeLabel.text = "";
			}
		}

		public void UpdateStackReduction(int amount)
		{
			_stackReduction += amount;
		}

		public void OnTooltip(bool show)
		{
			if (Item != null)
			{
				NimbatusToolTip.ShowWeapon(Item, true, show);
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}

		public void OnClick()
		{
			if (Clickable)
			{
				BaseSingleton<ScrapyardManager>.Instance.ScrapableItemClicked(this);
			}
		}
	}
}
