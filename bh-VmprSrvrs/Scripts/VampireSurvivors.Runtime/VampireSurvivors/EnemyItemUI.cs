using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.UI;

namespace VampireSurvivors
{
	public class EnemyItemUI : SelectableUI
	{
		[SerializeField]
		private TextMeshProUGUI _Number;

		[SerializeField]
		private TextMeshProUGUI _Name;

		[SerializeField]
		private Image _Background;

		private BestiaryPage _page;

		private EnemyData _data;

		private EnemyType _type;

		private bool _hasKilled;

		public void SetData(EnemyType type, int count, EnemyData dat, BestiaryPage page, bool hasKilled)
		{
		}

		public bool HasKilled()
		{
			return false;
		}

		protected override void OnSelected()
		{
		}

		protected override void OnDeselected()
		{
		}

		private void SetInfoPanel()
		{
		}
	}
}
