using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_CollectionStatisticsPopup : UI_CollectionPopup
	{
		[SerializeField]
		private CanvasGroup m_group;

		[Header("License Buttons")]
		[SerializeField]
		private RectTransform m_togglesLayout;

		[SerializeField]
		private Toggle m_globalToggle;

		private List<Toggle> m_licenseToggles = new List<Toggle>();

		[Header("UI Components")]
		[SerializeField]
		private RectTransform m_barsLayout;

		[SerializeField]
		private UI_CollectionCompletionBar m_globalCompletionBar;

		[SerializeField]
		private UI_CollectionCompletionBar m_heroCompletionBar;

		private List<UI_CollectionCompletionBar> m_armyBars = new List<UI_CollectionCompletionBar>();

		private bool m_global = true;

		private ELicense m_currentLicense;

		private void Awake()
		{
			SetupToggles();
			SetupArmyBars();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			m_globalToggle.onValueChanged.AddListener(OnToggleGlobal);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_globalToggle.onValueChanged.RemoveListener(OnToggleGlobal);
		}

		private void UpdateContent()
		{
			if (m_global)
			{
				ShowGlobalCompletion();
			}
			else
			{
				ShowLicenseCompletion(m_currentLicense);
			}
		}

		private void ShowGlobalCompletion()
		{
			m_globalCompletionBar.Value = Collection.GetGlobalCompletionPercentage();
			m_heroCompletionBar.Value = Collection.GetRareCompletionPercentage();
			int num = 0;
			foreach (object value in Enum.GetValues(typeof(EMiniatureArmy)))
			{
				m_armyBars[num].Value = Collection.GetArmyCompletionPercentage((EMiniatureArmy)value);
				num++;
			}
		}

		private void ShowLicenseCompletion(ELicense license)
		{
			m_globalCompletionBar.Value = Collection.GetGlobalCompletionPercentage(license);
			m_heroCompletionBar.Value = Collection.GetRareCompletionPercentage(license);
			int num = 0;
			foreach (object value in Enum.GetValues(typeof(EMiniatureArmy)))
			{
				m_armyBars[num].Value = Collection.GetArmyCompletionPercentage(license, (EMiniatureArmy)value);
				num++;
			}
		}

		private void SetupToggles()
		{
			foreach (object value in Enum.GetValues(typeof(ELicense)))
			{
				AddLicenseToggle((ELicense)value);
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(m_togglesLayout);
		}

		private void AddLicenseToggle(ELicense license)
		{
			Toggle toggle = UnityEngine.Object.Instantiate(m_globalToggle, m_globalToggle.transform.parent);
			toggle.name = license.ToString() + " Button";
			toggle.onValueChanged.AddListener(delegate(bool on)
			{
				if (on)
				{
					OnButtonLicense(license);
				}
			});
			toggle.GetComponentInChildren<TextMeshProUGUI>().text = license.ToString();
			m_licenseToggles.Add(toggle);
		}

		private void SetupArmyBars()
		{
			foreach (object value in Enum.GetValues(typeof(EMiniatureArmy)))
			{
				AddArmyBar((EMiniatureArmy)value);
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(m_barsLayout);
		}

		private void AddArmyBar(EMiniatureArmy army)
		{
			UI_CollectionCompletionBar uI_CollectionCompletionBar = UnityEngine.Object.Instantiate(m_heroCompletionBar, m_heroCompletionBar.transform.parent);
			m_armyBars.Add(uI_CollectionCompletionBar);
			uI_CollectionCompletionBar.Title = army.ToString();
		}

		private void OnToggleGlobal(bool on)
		{
			if (on)
			{
				m_global = true;
				UpdateContent();
			}
		}

		private void OnButtonLicense(ELicense license)
		{
			m_currentLicense = license;
			m_global = false;
			UpdateContent();
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			m_group.alpha = 1f;
			m_group.blocksRaycasts = true;
			UpdateContent();
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			m_group.alpha = 0f;
			m_group.blocksRaycasts = false;
		}

		public override bool CanBeClosed()
		{
			return false;
		}
	}
}
