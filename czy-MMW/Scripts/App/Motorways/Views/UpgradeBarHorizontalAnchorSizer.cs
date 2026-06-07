using System.Collections.Generic;
using Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class UpgradeBarHorizontalAnchorSizer : MonoBehaviour
	{
		[SerializeField]
		private HorizontalLayoutGroup _horizontalLayoutLeft;

		[SerializeField]
		private GameObject _horizontalLayoutCenter;

		[SerializeField]
		private HorizontalLayoutGroup _horizontalLayoutRight;

		[SerializeField]
		private HorizontalLayoutGroup _horizontalLayoutLeftInactive;

		[SerializeField]
		private GameObject _horizontalLayoutCenterInactive;

		[SerializeField]
		private HorizontalLayoutGroup _horizontalLayoutRightInactive;

		[Tooltip("in order of UpgradeType enum")]
		[SerializeField]
		private List<UpgradeButtonHolder> _upgradeButtons = new List<UpgradeButtonHolder>();

		private readonly List<UpgradeButtonHolder> _upgradeButtonsSortedLeftToRight = new List<UpgradeButtonHolder>();

		[SerializeField]
		private List<RectTransform> _dividers = new List<RectTransform>();

		[Dependency]
		private VisualConstantsData _visualConstants;

		private const int _concreteIndex = 6;

		public void Initialize(IScope scope)
		{
			_visualConstants = scope.Get<VisualConstantsData>();
			BuildSecondaryList();
		}

		public void ToggleUpgradeGroups(bool enableLeftGroup, bool enableCenterGroup, bool enableRightGroup)
		{
			_horizontalLayoutLeft.gameObject.SetActive(enableLeftGroup);
			_horizontalLayoutLeftInactive.gameObject.SetActive(enableLeftGroup);
			_horizontalLayoutCenter.SetActive(enableCenterGroup);
			_horizontalLayoutCenterInactive.SetActive(enableCenterGroup);
			_horizontalLayoutRight.gameObject.SetActive(enableRightGroup);
			_horizontalLayoutRightInactive.gameObject.SetActive(enableRightGroup);
			UpdateSizing();
		}

		private void BuildSecondaryList()
		{
			_upgradeButtonsSortedLeftToRight.Add(_upgradeButtons[6]);
			_upgradeButtonsSortedLeftToRight.Add(_upgradeButtons[7]);
			_upgradeButtonsSortedLeftToRight.Add(_upgradeButtons[8]);
			_upgradeButtonsSortedLeftToRight.Add(_upgradeButtons[4]);
			_upgradeButtonsSortedLeftToRight.Add(_upgradeButtons[2]);
			_upgradeButtonsSortedLeftToRight.Add(_upgradeButtons[3]);
			_upgradeButtonsSortedLeftToRight.Add(_upgradeButtons[0]);
			_upgradeButtonsSortedLeftToRight.Add(_upgradeButtons[1]);
			_upgradeButtonsSortedLeftToRight.Add(_upgradeButtons[5]);
		}

		public void UpdateSizing()
		{
			for (int i = 0; i < _upgradeButtonsSortedLeftToRight.Count; i++)
			{
				int num = -1;
				int num2 = -1;
				if (i < 6)
				{
					num = i + 1;
				}
				else if (i > 7)
				{
					num = i - 1;
				}
				num2 = ((i >= 6) ? (_dividers.Count - 1) : i);
				float width = _upgradeButtonsSortedLeftToRight[i]._visualElementIcon.rect.width;
				if (num > 0 && num < _upgradeButtonsSortedLeftToRight.Count)
				{
					UpgradeButtonCount count = _upgradeButtonsSortedLeftToRight[num]._count;
					if (count != null && count.AccountedIconNumber > 0)
					{
						_dividers[num2].sizeDelta = new Vector2(_visualConstants.UpgradeBarSeparationPaddingWithCount, 0f);
					}
					else if (count != null && count.AccountedIconNumber == 0 && _upgradeButtonsSortedLeftToRight[num]._anchor.gameObject.activeInHierarchy)
					{
						_dividers[num2].sizeDelta = new Vector2(_visualConstants.UpgradeBarSeparationPadding, 0f);
					}
					else if (count != null && count.AccountedIconNumber == 0 && !_upgradeButtonsSortedLeftToRight[num]._anchor.gameObject.activeInHierarchy)
					{
						_dividers[num2].sizeDelta = new Vector2(0f, 0f);
					}
					else
					{
						_dividers[num2].sizeDelta = new Vector2(_visualConstants.UpgradeBarSeparationPadding, 0f);
					}
				}
				_upgradeButtonsSortedLeftToRight[i]._anchor.sizeDelta = new Vector2(width, 0f);
			}
			Rect rect = _upgradeButtons[0]._visualElementCounter.rect;
			float num3 = _upgradeButtons[0]._visualElementIcon.rect.width * 0.5f;
			if (!_horizontalLayoutCenter.activeInHierarchy && !_horizontalLayoutRight.gameObject.activeInHierarchy)
			{
				_horizontalLayoutLeft.padding.right = 0;
				_horizontalLayoutLeftInactive.padding.right = 0;
				_horizontalLayoutLeft.childAlignment = TextAnchor.MiddleCenter;
				_horizontalLayoutLeftInactive.childAlignment = TextAnchor.MiddleCenter;
			}
			else
			{
				int right = (int)(num3 + _visualConstants.UpgradeBarSeparationPadding);
				int right2 = (int)(num3 + _visualConstants.UpgradeBarLeftInactiveSeparationPadding);
				_horizontalLayoutLeft.padding.right = right;
				_horizontalLayoutLeftInactive.padding.right = right2;
				_horizontalLayoutLeft.childAlignment = TextAnchor.MiddleRight;
				_horizontalLayoutLeftInactive.childAlignment = TextAnchor.MiddleRight;
			}
			float b = rect.x + rect.width * 0.5f;
			float num4 = Mathf.Max(num3, b) + _visualConstants.UpgradeBarRightSeparationPadding;
			_horizontalLayoutRight.padding.left = (int)num4;
			_horizontalLayoutLeft.CalculateLayoutInputHorizontal();
			_horizontalLayoutRight.CalculateLayoutInputHorizontal();
			_horizontalLayoutLeft.SetLayoutHorizontal();
			_horizontalLayoutRight.SetLayoutHorizontal();
		}
	}
}
