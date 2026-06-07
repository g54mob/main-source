using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI
{
	public class SecretItemUI : SelectableUI
	{
		[SerializeField]
		private Image _Tick;

		[SerializeField]
		private TextMeshProUGUI _Description;

		[SerializeField]
		private Image _Reward;

		private SecretData _data;

		private SecretType _type;

		private DataManager _dataManager;

		private SecretsPage _page;

		private bool _hasAchieved;

		public void SetData(DataManager dataManager, SecretsPage page, SecretData data, SecretType type, bool hasAchieved)
		{
		}

		public SecretType GetSecretType()
		{
			return default(SecretType);
		}

		public bool CheckAchieved()
		{
			return false;
		}

		public Sprite GetSecondReward(SecretData bad)
		{
			return null;
		}

		public Sprite GetCharacterReward(SecretData bad)
		{
			return null;
		}

		public Sprite GetOtherReward(SecretData bad)
		{
			return null;
		}

		private Sprite GetRewardSprite(SecretData bad)
		{
			return null;
		}

		protected override void OnSelected()
		{
		}

		public void SetInfoPanel()
		{
		}
	}
}
