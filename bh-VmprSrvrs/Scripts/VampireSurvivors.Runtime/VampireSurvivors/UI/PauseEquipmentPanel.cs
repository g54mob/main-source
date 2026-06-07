using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.UI
{
	public class PauseEquipmentPanel : MonoBehaviour
	{
		[SerializeField]
		private Image _PlayerSprite;

		[SerializeField]
		private RectTransform _Weapons;

		[SerializeField]
		private RectTransform _Accessories;

		[SerializeField]
		private GameObject _EquipmentIconPrefab;

		private List<GameObject> _spawned;

		private DataManager _data;

		private LevelUpFactory _levelUpFactory;

		private CanvasGroup _Group;

		[Inject]
		private void Construct(DataManager data, LevelUpFactory level)
		{
		}

		public void Populate(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		private void WaitAndRefresh()
		{
		}

		private EquipmentIconPaused Spawn(WeaponType t, Sprite s, int level, int maxLevel, RectTransform rTrans, bool isBanished)
		{
			return null;
		}

		private void ClearSpawned()
		{
		}
	}
}
