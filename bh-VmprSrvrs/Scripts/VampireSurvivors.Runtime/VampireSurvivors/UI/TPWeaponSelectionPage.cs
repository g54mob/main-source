using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class TPWeaponSelectionPage : BaseWeaponSelectionPage
	{
		[Header("References")]
		[SerializeField]
		private Image _Background;

		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private Image _Frame;

		[SerializeField]
		private GameObject _WeaponPrefab;

		[SerializeField]
		private Transform _SkipButton;

		[SerializeField]
		private Image _Mask;

		[SerializeField]
		private RectTransform _PanelRectTransform;

		private List<WeaponType> _weaponList;

		private List<GameObject> _spawned;

		private WeaponSelectionItemUI _currentSelected;

		private WeaponType _currentType;

		private VampireSurvivors.Objects.Characters.CharacterController _targetCharacter;

		private bool _hasSelected;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private SignalBus _signalBus;

		private List<WeaponType> _tpSpell;

		private List<WeaponType> _tpSpell_Secret;

		private List<WeaponType> _tpMelee;

		private List<WeaponType> _tpMelee_Secret;

		private List<WeaponType> _tpProjectile;

		private List<WeaponType> _tpProjectile_Secret;

		private List<WeaponType> _tpGlyph;

		private List<WeaponType> _tpGlyph_Secret;

		private List<WeaponType> _tpWhip;

		private List<WeaponType> _tpFamiliars;

		private List<WeaponType> _emeAllWeapons;

		[Inject]
		private void InjectData(DataManager data, PlayerOptions player, SignalBus signalBus)
		{
		}

		private void OnWeaponSkippedRemotely()
		{
		}

		private void OnWeaponSelectedRemotely(OnlineSignals.SelectTPWeapon weapon)
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		private void Clear()
		{
		}

		public override void SetSelected(WeaponSelectionItemUI item)
		{
		}

		private void Populate()
		{
		}

		public override void SelectWeapon(WeaponSelectionItemUI item)
		{
		}

		private void ExecuteWeaponSelection(WeaponType selected)
		{
		}

		public void Skip()
		{
		}

		private void ExecuteSkip()
		{
		}

		private void SpawnWeapon(WeaponType t, WeaponData d)
		{
		}

		private void MakeSpellBookConfig()
		{
		}

		private void MakeCoatOfArmsConfig()
		{
		}

		private void MakeMorningStarConfig()
		{
		}

		private void MakeSpectralSwordConfig()
		{
		}

		private void MakeEbonyDialogueConfig()
		{
		}

		private void MakeFamiliarConfig()
		{
		}

		private void MakeEmeraldsConfig()
		{
		}
	}
}
