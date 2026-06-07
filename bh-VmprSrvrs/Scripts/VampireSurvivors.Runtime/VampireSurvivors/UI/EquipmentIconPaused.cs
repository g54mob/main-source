using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI
{
	public class EquipmentIconPaused : MonoBehaviour
	{
		[SerializeField]
		private List<Image> _Levels;

		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private Sprite _CompletedLevel;

		[SerializeField]
		private Sprite _IncompleteLevel;

		[SerializeField]
		private GameObject _LevelIconPrefab;

		[SerializeField]
		private RectTransform _LevelIconContainer;

		[SerializeField]
		private TextMeshProUGUI _LimitBreakLevelText;

		private List<GameObject> _spawned;

		private WeaponType _type;

		public void SetData(WeaponType t, int level, int maxLevel, Sprite s, bool isBanished)
		{
		}

		public WeaponType GetWeaponType()
		{
			return default(WeaponType);
		}

		public void SetLimitBreakLevel(int limitBreakLevel, int foundWeaponLevel)
		{
		}
	}
}
