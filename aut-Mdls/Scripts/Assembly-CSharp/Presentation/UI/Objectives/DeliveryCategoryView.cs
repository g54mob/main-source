using Data.FactoryFloor.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Objectives
{
	public class DeliveryCategoryView : MonoBehaviour
	{
		[SerializeField]
		private Image _thumbnail;

		[SerializeField]
		private Transform _targets;

		[SerializeField]
		private GameObject _locked;

		[SerializeField]
		private TextMeshProUGUI _nameText;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		[SerializeField]
		private TextMeshProUGUI _totalText;

		[SerializeField]
		private RectTransform _line;

		[SerializeField]
		private TierLabel _tierlabel;

		[SerializeField]
		private Image _tierBg;

		[SerializeField]
		private TextMeshProUGUI _tierText;

		[SerializeField]
		private GameObject _tierIcon;

		private Color _invalidColor = new Color(1f, 1f, 1f, 0.02f);

		[SerializeField]
		private float _nodeStart = 86f;

		[SerializeField]
		private float _nodeSpacing = 72f;

		[SerializeField]
		private float _nodeWidth = 106f;

		private NonShapeResourceDataSO _resourceDataSo;

		public Transform Targets => _targets;

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		public void Build(NonShapeResourceDataSO resourceDataSo, Color color)
		{
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			_resourceDataSo = resourceDataSo;
			_thumbnail.sprite = resourceDataSo.Sprite;
			_nameText.SetText(LocalizationUtility.GetLocalizedText(resourceDataSo.NameLocaKey));
			_nameText.color = ((resourceDataSo.FamilyID == 0) ? Color.white : color);
			_tierlabel.Initialize(color);
			base.gameObject.SetActive(value: true);
		}

		public void UpdateView(bool isCategoryValid)
		{
			_thumbnail.color = (isCategoryValid ? Color.white : _invalidColor);
			_nameText.gameObject.SetActive(isCategoryValid);
			_amountText.gameObject.SetActive(isCategoryValid);
			_tierlabel.gameObject.SetActive(isCategoryValid);
			_locked.SetActive(!isCategoryValid);
		}

		public void UpdateValues(uint delivered, uint amountToReach, int tier)
		{
			_line.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _nodeStart + (float)((tier >= 9) ? 9 : tier) * (_nodeWidth + _nodeSpacing));
			_amountText.text = delivered.ToString();
			_tierlabel.SetTier(tier, 9);
		}

		private void OnLanguageUpdate()
		{
			_nameText.SetText(LocalizationUtility.GetLocalizedText(_resourceDataSo.NameLocaKey));
		}
	}
}
