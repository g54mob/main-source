using System.Collections.Generic;
using DG.Tweening;
using Dhs5.Utility.Settings;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Simulator
{
	public class TabletopDropdown : TMP_Dropdown
	{
		private InteractableNavElement m_navElement;

		private ScrollRect m_scrollRect;

		private AxisEventData m_axisEventData;

		private readonly List<DropdownItem> m_dropdownItems = new List<DropdownItem>();

		private readonly List<TabletopToggle> m_dropdownToggles = new List<TabletopToggle>();

		private Tween m_scrollTween;

		[SerializeField]
		private bool m_localizeText;

		[SerializeField]
		private string m_localizeTextCategory;

		[SerializeField]
		private LayoutGroup m_layoutGroupToRefresh;

		public IReadOnlyList<TabletopToggle> DropdownToggles => m_dropdownToggles;

		private string LocalizeTextCategory
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(m_localizeTextCategory))
				{
					return m_localizeTextCategory + "/";
				}
				return string.Empty;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			m_navElement = GetComponentInParent<InteractableNavElement>(includeInactive: true);
		}

		protected override void Start()
		{
			base.Start();
			LocalizeCaptionText();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			LocalizeCaptionText();
			LocalizationManager.OnLocalizeEvent += OnLocalizeEvent;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			LocalizationManager.OnLocalizeEvent -= OnLocalizeEvent;
		}

		public new void AddOptions(List<string> options)
		{
			base.AddOptions(options);
			LocalizeCaptionText();
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
			LocalizeDropdownItems();
		}

		public override void OnSubmit(BaseEventData eventData)
		{
			base.OnSubmit(eventData);
			LocalizeDropdownItems();
		}

		protected override GameObject CreateDropdownList(GameObject template)
		{
			GameObject gameObject = base.CreateDropdownList(template);
			m_scrollRect = gameObject.GetComponent<ScrollRect>();
			return gameObject;
		}

		protected override void DestroyDropdownList(GameObject dropdownList)
		{
			base.DestroyDropdownList(dropdownList);
			m_scrollRect = null;
			m_dropdownItems.Clear();
			m_dropdownToggles.Clear();
		}

		protected override void DestroyBlocker(GameObject blocker)
		{
			base.DestroyBlocker(blocker);
			RefreshLayoutGroup();
		}

		protected override DropdownItem CreateItem(DropdownItem itemTemplate)
		{
			DropdownItem dropdownItem = base.CreateItem(itemTemplate);
			m_dropdownItems.Add(dropdownItem);
			TabletopToggle tabletopToggle = (TabletopToggle)dropdownItem.toggle;
			tabletopToggle.onSelect += OnItemSelected;
			tabletopToggle.index = m_dropdownToggles.Count;
			m_dropdownToggles.Add(tabletopToggle);
			return dropdownItem;
		}

		protected override GameObject CreateBlocker(Canvas rootCanvas)
		{
			GameObject result = base.CreateBlocker(rootCanvas);
			for (int i = 0; i < m_dropdownToggles.Count; i++)
			{
				TabletopToggle tabletopToggle = m_dropdownToggles[i];
				if (tabletopToggle.isOn)
				{
					ScrollOnItem(tabletopToggle);
					m_scrollTween.Kill(complete: true);
					break;
				}
			}
			return result;
		}

		public override void Select()
		{
			LocalizeCaptionText();
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
			{
				EventSystem.current.SetSelectedGameObject(m_navElement.gameObject);
			}
		}

		private void OnItemSelected(TabletopToggle toggle)
		{
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
			{
				ScrollOnItem(toggle);
			}
		}

		private void ScrollOnItem(TabletopToggle toggle)
		{
			if (m_scrollRect != null && m_scrollRect.verticalScrollbar.gameObject.activeInHierarchy)
			{
				m_scrollTween?.Kill();
				float verticalNormalizedPosition = m_scrollRect.verticalNormalizedPosition;
				float to = 1f - (float)toggle.index / (float)(m_dropdownToggles.Count - 1);
				m_scrollTween = DOVirtual.Float(verticalNormalizedPosition, to, CustomSettings<TabletopDropdownSettings>.I.ScrollDuration, delegate(float x)
				{
					m_scrollRect.verticalNormalizedPosition = x;
				});
				m_scrollTween.OnKill(delegate
				{
					m_scrollTween = null;
				});
			}
		}

		private void OnLocalizeEvent()
		{
			if (m_localizeText)
			{
				LocalizeCaptionText();
			}
		}

		private void LocalizeDropdownItems()
		{
			if (!m_localizeText)
			{
				return;
			}
			for (int i = 0; i < m_dropdownItems.Count; i++)
			{
				DropdownItem dropdownItem = m_dropdownItems[i];
				if (dropdownItem.text != null && LocalizationManager.TryGetTranslation(LocalizeTextCategory + dropdownItem.text.text, out var Translation))
				{
					dropdownItem.text.text = Translation;
				}
			}
		}

		private void LocalizeCaptionText()
		{
			if (m_localizeText && LocalizationManager.TryGetTranslation(LocalizeTextCategory + base.options[base.value].text, out var Translation))
			{
				base.captionText.text = Translation;
				RefreshLayoutGroup();
			}
		}

		private void RefreshLayoutGroup()
		{
			if (!(m_layoutGroupToRefresh == null))
			{
				m_layoutGroupToRefresh.RefreshLayoutGroupsImmediateAndRecursive();
			}
		}
	}
}
