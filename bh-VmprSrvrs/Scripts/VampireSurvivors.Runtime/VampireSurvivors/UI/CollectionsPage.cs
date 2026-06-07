using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class CollectionsPage : BaseUIPage
	{
		public enum FilterType
		{
			DEFAULT = 0,
			BY_TYPE = 1,
			BY_VERSION = 2,
			ADVENTURE = 3
		}

		public static bool IsMagician;

		[SerializeField]
		private bool _DEBUG;

		[SerializeField]
		private Localize Name;

		[SerializeField]
		private Localize Description;

		[SerializeField]
		private Localize AdditionalInfo;

		[SerializeField]
		private Image Icon;

		[SerializeField]
		private Image Background;

		[SerializeField]
		private Localize Title;

		[SerializeField]
		private GameObject CollectionPrefab;

		[SerializeField]
		private RectTransform _MagicianPanel;

		[SerializeField]
		private SealPanel _SealPanel;

		[SerializeField]
		private GameObject _GridPrefab;

		[SerializeField]
		private GameObject _HeaderPrefab;

		[SerializeField]
		private TextMeshProUGUI _FilterModeText;

		[SerializeField]
		private MobileConfig _PanelPanelConfig;

		[SerializeField]
		private MegaSealPanel _MegaSealPanel;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private AdventureManager _adventures;

		private List<CollectionItemUI> _spawned;

		private List<GameObject> _structuralSpawned;

		private int _totalUnlocked;

		private int _totalAvailable;

		private RectTransform _scrollRect;

		private int _yellowSignClickCount;

		private RectTransform _activeContentGrid;

		private bool shouldForceLayoutUpdate;

		private bool shouldRegenerateNav;

		private bool _hasDarkasso;

		private List<CollectionItemUI> _defaultSortOrder;

		public FilterType _currentFilter;

		[Inject]
		private void Construct(DataManager data, PlayerOptions player, AdventureManager adventure)
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void LateUpdate()
		{
		}

		private void Populate()
		{
		}

		private void GenerateNavigation()
		{
		}

		private void SpawnElements(Dictionary<WeaponType, List<WeaponData>> weapons, WeaponType[] yellowWeapons, Dictionary<ItemType, ItemData> items, ItemType[] yellowItems, Dictionary<ArcanaType, ArcanaData> arcanas)
		{
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		private void AddWeapon(WeaponData dat, WeaponType type)
		{
		}

		private GameObject AddItem(ItemData dat, ItemType type)
		{
			return null;
		}

		private void AddArcana(ArcanaData dat, ArcanaType type)
		{
		}

		private void SetTitle()
		{
		}

		private void SortByDefault()
		{
		}

		private void SortByType()
		{
		}

		private void SortByVersion()
		{
		}

		private ContentGroupType GetContentGroup(CollectionItemUI item)
		{
			return default(ContentGroupType);
		}

		private void ClearStructures()
		{
		}

		private void SortByAdventure()
		{
		}

		private void AddHeader(string text)
		{
		}

		private void AddGrid()
		{
		}

		private void AddFakeContent()
		{
		}

		public void SetInfoPanel(WeaponData d, WeaponType type)
		{
		}

		public void RegisterItemClick(bool isYellowSign)
		{
		}

		public void WeaponClicked(CollectionItemUI item, WeaponType t)
		{
		}

		private void BanishWeapon(CollectionItemUI item)
		{
		}

		private void UnBanishWeapon(CollectionItemUI item)
		{
		}

		private void ContentGroupBanishWeapon(CollectionItemUI item)
		{
		}

		private void ContentGroupUnBanishWeapon(CollectionItemUI item)
		{
		}

		private void ContentGroupBanishItem(CollectionItemUI item)
		{
		}

		private void ContentGroupUnBanishItem(CollectionItemUI item)
		{
		}

		public void UnsealAll()
		{
		}

		private void BanishItem(CollectionItemUI item)
		{
		}

		private void UnBanishItem(CollectionItemUI item)
		{
		}

		public void BanishGroup(ContentGroupType contentGroup)
		{
		}

		public void UnBanishGroup(ContentGroupType contentGroup)
		{
		}

		public void ItemClicked(CollectionItemUI item, ItemType t)
		{
		}

		public void OnUnsealableClicked()
		{
		}

		public void SetInfoPanel(ItemData d, ItemType type)
		{
		}

		public void CycleFiltering()
		{
		}

		private void SetFilter()
		{
		}

		private void UpdateFilterTextDisplay()
		{
		}

		public void SetInfoPanel(ArcanaData d, ArcanaType type)
		{
		}

		private void SetIconSize()
		{
		}

		public void Reset()
		{
		}

		private void MakeMagician()
		{
		}
	}
}
