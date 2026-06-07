using System;
using System.Collections.Generic;
using System.Linq;
using Dhs5.Utility.Updates;
using Simulator;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public abstract class UI_FilterDropdown : InteractableNavElement
	{
		[Header("UI Components")]
		[SerializeField]
		private Button m_button;

		[SerializeField]
		private Image m_directionIcon;

		[SerializeField]
		private NavToggle m_defaultFilterNavToggle;

		[SerializeField]
		private RectTransform m_togglesContainer;

		[SerializeField]
		private NavBox m_togglesNavBox;

		private NavToggle[] m_toggles;

		private bool IsOpen => m_togglesContainer.gameObject.activeSelf;

		public event Action AnyChange;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_button.onClick.AddListener(OnButtonClick);
			m_togglesNavBox.Cancelled += OnDropdownCancel;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_button.onClick.RemoveListener(OnButtonClick);
			m_togglesNavBox.Cancelled -= OnDropdownCancel;
		}

		public void Init()
		{
			InstantiateFilterToggles();
		}

		public bool IsFilterActive(int index)
		{
			return m_toggles[index].Toggle.isOn;
		}

		private void InstantiateFilterToggles()
		{
			int filtersCount = GetFiltersCount();
			m_toggles = new NavToggle[filtersCount];
			for (int i = 0; i < m_toggles.Length; i++)
			{
				NavToggle navToggle = UnityEngine.Object.Instantiate(m_defaultFilterNavToggle, m_togglesContainer);
				m_toggles[i] = navToggle;
				OnInstantiateFilterToggle(i, navToggle);
				navToggle.Toggle.onValueChanged.AddListener(OnAnyFilterToggleValueChanged);
				navToggle.DeselectElementEvent = (Action)Delegate.Combine(navToggle.DeselectElementEvent, new Action(OnToggleDeselect));
				m_togglesNavBox.AddChild(navToggle);
			}
			for (int j = 0; j < m_toggles.Length; j++)
			{
				NavToggle navToggle2 = m_toggles[j];
				if (j > 0)
				{
					navToggle2.SetUpNeighbour(m_toggles[j - 1]);
				}
				if (j < m_toggles.Length - 1)
				{
					navToggle2.SetDownNeighbour(m_toggles[j + 1]);
				}
			}
			UnityEngine.Object.Destroy(m_defaultFilterNavToggle.gameObject);
			LayoutRebuilder.ForceRebuildLayoutImmediate(m_togglesContainer);
		}

		protected abstract int GetFiltersCount();

		protected abstract void OnInstantiateFilterToggle(int index, NavToggle filterToggle);

		private void OnButtonClick()
		{
			if (IsOpen)
			{
				Close();
			}
			else
			{
				Open();
			}
		}

		private void Open()
		{
			m_togglesContainer.gameObject.SetActive(value: true);
			m_directionIcon.rectTransform.eulerAngles = new Vector3(0f, 0f, 0f);
			m_togglesNavBox.SelectFirstChild();
		}

		public void Close()
		{
			if (IsOpen)
			{
				m_togglesContainer.gameObject.SetActive(value: false);
				m_directionIcon.rectTransform.eulerAngles = new Vector3(0f, 0f, 180f);
			}
		}

		private void OnAnyFilterToggleValueChanged(bool on)
		{
			this.AnyChange?.Invoke();
		}

		protected override IEnumerable<Selectable> GetChildSelectables()
		{
			yield return m_button;
			foreach (Selectable childSelectable in base.GetChildSelectables())
			{
				yield return childSelectable;
			}
		}

		private void OnDropdownCancel()
		{
			if (IsOpen)
			{
				base.Parent.ResumeSelection();
				Close();
			}
		}

		private void OnToggleDeselect()
		{
			if (TransientManager<InputManager>.Instance.CurrentDevice != EInputDeviceType.GAMEPAD)
			{
				return;
			}
			if (EventSystem.current == null)
			{
				Close();
				return;
			}
			Updater.CallInXFrames(1, delegate
			{
				if (!AreAnyOfItsElementsSelectedByEventSystem())
				{
					Close();
				}
			}, out var _);
		}

		public bool AreAnyOfItsElementsSelectedByEventSystem()
		{
			EventSystem current = EventSystem.current;
			if (current == null)
			{
				return false;
			}
			GameObject currentSelectedGameObject = current.currentSelectedGameObject;
			if (currentSelectedGameObject == null)
			{
				return false;
			}
			if (currentSelectedGameObject == base.gameObject)
			{
				return true;
			}
			return m_toggles.Any((NavToggle x) => currentSelectedGameObject == x.gameObject);
		}
	}
}
