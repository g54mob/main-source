using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors
{
	public class WeaponSelectionPage : BaseWeaponSelectionPage
	{
		[SerializeField]
		private RectTransform _Container;

		[SerializeField]
		private GameObject _WeaponPrefab;

		[SerializeField]
		private RectTransform _Panel;

		[SerializeField]
		private RectTransform _SkipButton;

		[SerializeField]
		private SpriteReel _LeftBanner;

		[SerializeField]
		private SpriteReel _RightBanner;

		private PlayerOptions _playerOptions;

		private DataManager _dataManager;

		private SignalBus _signalBus;

		private Dictionary<WeaponType, List<WeaponData>> _weapons;

		private WeaponType _currentType;

		private List<WeaponSelectionItemUI> _spawned;

		private bool _hasSelected;

		private VampireSurvivors.Objects.Characters.CharacterController _targetCharacter;

		[Inject]
		private void Construct(PlayerOptions player, DataManager data, SignalBus signalBus)
		{
		}

		private void OnWeaponSkippedRemotely()
		{
		}

		private void OnWeaponSelectedRemotely(OnlineSignals.SelectCandyBoxWeapon weapon)
		{
		}

		public override void SetSelected(WeaponSelectionItemUI item)
		{
		}

		public override void SelectWeapon(WeaponSelectionItemUI item)
		{
		}

		public void Skip()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		private void ExecuteSkip()
		{
		}

		private void ExecuteWeaponSelection(WeaponType weapon)
		{
		}

		private void GetBaseWeapons(List<WeaponType> weaponList = null)
		{
		}

		private void GetPassiveWeapons()
		{
		}

		private void AddXifYisUnlocked(WeaponType x, WeaponType y, ref List<WeaponType> list)
		{
		}

		private void GetEvolvedWeapons()
		{
		}

		private void SelectFirst()
		{
		}

		private void AddWeapon(WeaponType t, WeaponData d)
		{
		}

		private void Clear()
		{
		}

		private void RemoveCandyBox()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
