using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.UI
{
	public class ArcanaInfoPanel : MonoBehaviour
	{
		[SerializeField]
		private Localize _InfoTitle;

		[SerializeField]
		private Localize _InfoDescription;

		[SerializeField]
		private RectTransform _AffectedWeaponGroup;

		[SerializeField]
		private RectTransform _DynamicGrid;

		[SerializeField]
		private bool _ReorderWeaponsBasedOnOwnership;

		[SerializeField]
		private Image _AffectedWeaponImageTemplate;

		[FormerlySerializedAs("_MaxWeaponsBeforeCarousel")]
		[SerializeField]
		private int _MaxWeaponsBeforeGrid;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private VampireSurvivors.Objects.Characters.CharacterController _controllingCharacter;

		private readonly List<GameObject> _affectedWeapons;

		private Dictionary<WeaponType, List<WeaponData>> _weapons;

		private Dictionary<ItemType, ItemData> _items;

		private readonly List<Equipment> _equipment;

		private List<WeaponType> _ownedWeapons;

		[Inject]
		private void Construct(DataManager data, PlayerOptions player, GameManager game, ArcanaManager arcana)
		{
		}

		public void Initialize()
		{
		}

		public void SetControllingCharacter(VampireSurvivors.Objects.Characters.CharacterController controllingCharacter)
		{
		}

		public void SetInfo(ArcanaData arcanaData, ArcanaType arcanaType)
		{
		}

		private bool IsWeaponSelectorType(WeaponType? weaponType)
		{
			return false;
		}

		private void PopulateAffectedWeaponCarousel(ArcanaData arcanaData, ArcanaType type)
		{
		}

		private void SetGridActive()
		{
		}

		private void AddAffectedWeapon(WeaponType weaponType)
		{
		}

		private void AddAffectedItem(ItemType itemType)
		{
		}

		private void GenerateImageForAffectedWeapon(Sprite weaponSprite, bool isOwned)
		{
		}

		private void ClearAffectedWeapons()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
