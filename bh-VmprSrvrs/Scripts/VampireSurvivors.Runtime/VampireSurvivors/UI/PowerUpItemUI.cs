using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;

namespace VampireSurvivors.UI
{
	public class PowerUpItemUI : SelectableUI
	{
		[SerializeField]
		private Localize Title;

		[SerializeField]
		private Image Icon;

		[SerializeField]
		private GameObject UpgradeSlotPrefab;

		[SerializeField]
		private RectTransform Container;

		[SerializeField]
		private Button Clicker;

		[SerializeField]
		private Image Background;

		[SerializeField]
		private Image Frame;

		[SerializeField]
		private Color MaxColor;

		public PowerUpData _data;

		public PowerUpType _type;

		public PowerUpsPage _page;

		private int _currentLevel;

		private int _maxRank;

		private List<GameObject> _spawnedSlots;

		public void SetData(PowerUpData data, PowerUpType type, PowerUpsPage page, int currentLevel, int maxRank)
		{
		}

		public void Reset()
		{
		}

		private void CreateSlot(int i)
		{
		}

		public bool UpdateAfterPurchase()
		{
			return false;
		}

		public void SetActive(bool b)
		{
		}

		public void SetInfo()
		{
		}

		private void CheckMaxedOut()
		{
		}

		public bool IsMaxedOut()
		{
			return false;
		}

		protected override void OnSelected()
		{
		}
	}
}
