using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI
{
	public class GameEquipmentPanelItem : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _levelContainer;

		[SerializeField]
		private GameObject _levelPrefab;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Image _BlockedIcon;

		[Space]
		[SerializeField]
		private float _iconAlphaWhenEquipmentDisabled;

		[SerializeField]
		private Vector2 _blockedIconSizeWhenEquipmentDisabled;

		private WeaponData _data;

		private WeaponType _type;

		private bool _isSet;

		private int _currentLevel;

		private readonly List<GameObject> _spawnedSlots;

		public void Initialize(VampireSurvivors.Objects.Characters.CharacterController ownerCharacter, WeaponData data, WeaponType type)
		{
		}

		public void Reset()
		{
		}

		public bool IsSet()
		{
			return false;
		}

		public void SetBlocked(bool blocked)
		{
		}

		public void SetDisabledIcon(bool disabled)
		{
		}

		public void CreateSlots()
		{
		}

		public void SetLevel(int level)
		{
		}

		public WeaponData GetWData()
		{
			return null;
		}

		public WeaponType GetWType()
		{
			return default(WeaponType);
		}
	}
}
