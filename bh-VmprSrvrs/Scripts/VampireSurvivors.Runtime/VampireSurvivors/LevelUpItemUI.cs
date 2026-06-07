using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.UI;

namespace VampireSurvivors
{
	public class LevelUpItemUI : SelectableUI
	{
		[SerializeField]
		private Image _Background;

		[SerializeField]
		private Localize _Name;

		[SerializeField]
		private TextMeshProUGUI _Level;

		[SerializeField]
		private TextMeshProUGUI _New;

		[SerializeField]
		private TextMeshProUGUI _Description;

		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private TextMeshProUGUI _EvoText;

		[SerializeField]
		private Image[] _EvoIcons;

		[SerializeField]
		private Image _EvoCharacterIcon;

		[SerializeField]
		private GameObject _ItemCharacterIconGroup;

		[SerializeField]
		private Image[] _ItemCharacterIcons;

		[SerializeField]
		private Image[] _OnlineSuggestionsIcons;

		private WeaponData _data;

		private WeaponData _levelData;

		private WeaponType _type;

		private LevelUpPage _page;

		private List<WeaponData> _allData;

		private WeightedLimitBreak _wlBreak;

		private int _index;

		private ItemData _itemData;

		private ItemType _itemType;

		private int _currentLevel;

		private bool _isLimitBreak;

		private bool _isNew;

		public WeightedLimitBreak LimitBreakData => null;

		public ItemType ItemType => default(ItemType);

		public int Index => 0;

		public void Select()
		{
		}

		public void SelectWeapon()
		{
		}

		public void SelectItem()
		{
		}

		public void SetWeaponData(LevelUpPage page, WeaponType type, WeaponData baseData, WeaponData levelData, int index, int newLevel, bool isNew, bool showEvo = false, List<Sprite> evoIcons = null, Sprite characterOwner = null)
		{
		}

		private void HookOnlineCallback()
		{
		}

		private void OnLevelUpSuggestedCallback(int newSuggestion, int seatNumber, VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		protected override void OnDestroy()
		{
		}

		public bool IsNew()
		{
			return false;
		}

		public void DisableSelection()
		{
		}

		public void EnableSelection()
		{
		}

		public WeaponType GetWeaponType()
		{
			return default(WeaponType);
		}

		public bool IsFriendshipAmulet()
		{
			return false;
		}

		public void SetItemData(ItemType type, ItemData data, LevelUpPage page, int index, List<VampireSurvivors.Objects.Characters.CharacterController> affectedCharacters = null)
		{
		}

		public bool IsWeapon()
		{
			return false;
		}

		public bool IsPowerUp()
		{
			return false;
		}

		public void SetLimitBreakData(LevelUpPage page, WeightedLimitBreak wlBreak, Equipment e, WeaponData baseWeaponData, WeaponType weaponType, int index)
		{
		}

		public Image GetIcon()
		{
			return null;
		}

		private string ParseLimitBreakData(LimitBreakData d)
		{
			return null;
		}
	}
}
