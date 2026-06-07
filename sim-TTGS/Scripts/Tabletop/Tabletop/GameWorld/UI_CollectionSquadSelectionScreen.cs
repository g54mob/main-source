using System;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_CollectionSquadSelectionScreen : NavBox, IActivable, IUIInputReceiver
	{
		[Header("UI Components")]
		[SerializeField]
		private GridLayoutGroup m_gridLayout;

		[SerializeField]
		private UI_CollectionSquadButton[] m_buttons;

		[SerializeField]
		private UI_CollectionSquadSelectionPlayButton m_playButton;

		[SerializeField]
		private Button m_statisticsButton;

		[SerializeField]
		private Button m_closeButton;

		private int m_selectedSquad;

		private bool m_layoutSetup;

		public event Action<int> EditSquad;

		public event Action Closed;

		protected override void OnEnable()
		{
			base.OnEnable();
			RegisterUICallbacks(register: true);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			RegisterUICallbacks(register: false);
		}

		private void RegisterUICallbacks(bool register)
		{
			if (register)
			{
				m_playButton.Button.onClick.AddListener(OnButton_Play);
				m_statisticsButton.onClick.AddListener(OnButton_Statistics);
				m_closeButton.onClick.AddListener(OnButton_Close);
				for (int i = 0; i < m_buttons.Length; i++)
				{
					m_buttons[i].SquadSelected += OnSquadSelected;
					m_buttons[i].EditSquad += OnEditSquad;
				}
			}
			else
			{
				m_playButton.Button.onClick.RemoveListener(OnButton_Play);
				m_statisticsButton.onClick.RemoveListener(OnButton_Statistics);
				m_closeButton.onClick.RemoveListener(OnButton_Close);
				for (int j = 0; j < m_buttons.Length; j++)
				{
					m_buttons[j].SquadSelected -= OnSquadSelected;
					m_buttons[j].EditSquad -= OnEditSquad;
				}
			}
		}

		void IActivable.SetActive(bool active)
		{
			base.gameObject.SetActive(active);
			if (active)
			{
				OnSetActive();
				SetActive();
			}
			else
			{
				SetInactive();
				OnSetInactive();
			}
		}

		private void OnSetActive()
		{
			m_selectedSquad = -1;
			m_playButton.SetValid(valid: false);
			if (!m_layoutSetup)
			{
				m_layoutSetup = true;
				m_gridLayout.constraintCount = CollectionSettings.SquadSlots / 2;
				for (int i = 0; i < m_buttons.Length; i++)
				{
					m_buttons[i].gameObject.SetActive(i < CollectionSettings.SquadSlots);
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(m_gridLayout.transform as RectTransform);
			}
			IUIInputReceiver.SetCurrent(this);
		}

		private void OnSetInactive()
		{
			IUIInputReceiver.SetCurrent(null);
		}

		private void OnButton_Play()
		{
			if (m_selectedSquad >= 0 && World.Shop.Open && TimeController.IsDay)
			{
				TabletopWorld.WargameManager.StartWargame(m_selectedSquad);
			}
		}

		private void OnButton_Statistics()
		{
		}

		private void OnButton_Close()
		{
			this.Closed?.Invoke();
		}

		private void OnSquadSelected(int index, bool valid)
		{
			if (m_selectedSquad >= 0)
			{
				m_buttons[m_selectedSquad].UpdateBackgroundSprite(selected: false);
			}
			m_selectedSquad = (valid ? index : (-1));
			if (valid)
			{
				m_buttons[m_selectedSquad].UpdateBackgroundSprite(selected: true);
			}
			m_playButton.SetValid(valid && World.Shop.Open);
		}

		private void OnEditSquad(int index)
		{
			this.EditSquad?.Invoke(index);
		}

		public void OnUIInput_Navigate(Vector2 direction)
		{
		}

		public void OnUIInput_Point(Vector2 mousePosition)
		{
		}

		public void OnUIInput_Submit()
		{
		}

		public void OnUIInput_Space()
		{
		}

		public void OnUIInput_Memo()
		{
		}

		public void OnUIInput_GamepadNorthButton()
		{
			if (base.HasSelection && TryGetCurrentSquadButton(out var button))
			{
				button.Delete();
			}
		}

		public void OnUIInput_GamepadWestButton()
		{
			if (base.HasSelection && TryGetCurrentSquadButton(out var button))
			{
				button.Edit();
			}
		}

		public void OnUIInput_ExitWorkshop()
		{
		}

		private bool TryGetCurrentSquadButton(out UI_CollectionSquadButton button)
		{
			button = null;
			if (base.CurrentElement == null)
			{
				return false;
			}
			if (!(base.CurrentElement is NavBox navBox))
			{
				return false;
			}
			if (!(navBox.CurrentElement is UI_CollectionSquadButton uI_CollectionSquadButton))
			{
				return false;
			}
			button = uI_CollectionSquadButton;
			return true;
		}
	}
}
