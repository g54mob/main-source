using System;
using Simulator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_CollectionSquadButton : NavBox
	{
		[Header("Squad UI Components")]
		[SerializeField]
		private TextMeshProUGUI m_squadNameText;

		[SerializeField]
		private Image m_squadLicenseImage;

		[SerializeField]
		private TextMeshProUGUI m_gamesPlayedText;

		[SerializeField]
		private TextMeshProUGUI m_victoryRateText;

		[SerializeField]
		private Image[] m_armyIcons;

		[SerializeField]
		private Image[] m_rarityIcons;

		[SerializeField]
		private GameObject m_createImage;

		[SerializeField]
		private UI_CollectionSquadMainButton m_mainButton;

		[SerializeField]
		private NavButton m_editButton;

		[SerializeField]
		private NavButton m_deleteButton;

		[Header("Parameters")]
		[SerializeField]
		private int m_index;

		[Header("Selection UI")]
		[SerializeField]
		private Image m_backgroundImage;

		[SerializeField]
		private Sprite m_backgroundNormalSprite;

		[SerializeField]
		private Sprite m_backgroundSelectedSprite;

		private bool m_exists;

		private bool m_valid;

		public event Action<int, bool> SquadSelected;

		public event Action<int> EditSquad;

		public event Action<int> DeleteSquad;

		protected override void OnEnable()
		{
			base.OnEnable();
			if (Application.isPlaying)
			{
				RefreshContent();
				m_mainButton.Button.onClick.AddListener(OnMainButton);
				m_editButton.Button.onClick.AddListener(OnButtonEdit);
				m_deleteButton.Button.onClick.AddListener(OnButtonDelete);
				UpdateBackgroundSprite(selected: false);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (Application.isPlaying)
			{
				m_mainButton.Button.onClick.RemoveListener(OnMainButton);
				m_editButton.Button.onClick.RemoveListener(OnButtonEdit);
				m_deleteButton.Button.onClick.RemoveListener(OnButtonDelete);
			}
		}

		private void RefreshContent()
		{
			CollectionWargameSquad squadAtIndex = Collection.GetSquadAtIndex(m_index);
			m_exists = squadAtIndex.Exists;
			m_valid = squadAtIndex.Valid;
			if (squadAtIndex.Exists)
			{
				m_createImage.SetActive(value: false);
				m_squadNameText.text = squadAtIndex.Name;
				m_squadLicenseImage.sprite = MiniatureSettings.GetLicenseSprite(squadAtIndex.License);
				m_gamesPlayedText.text = squadAtIndex.GamesPlayed.ToString();
				m_victoryRateText.text = (squadAtIndex.VictoryRate * 100f).ToString("0.0") + "%";
				int num = 0;
				{
					foreach (int miniature in squadAtIndex.GetMiniatures())
					{
						if (miniature != 0)
						{
							MiniatureData miniatureData = MiniatureDatabase.Get(miniature);
							if (miniatureData != null)
							{
								m_armyIcons[num].sprite = MiniatureSettings.GetArmySprite(miniatureData.Army);
								m_armyIcons[num].enabled = true;
								m_rarityIcons[num].sprite = MiniatureSettings.GetSquadSpriteFromRarity(miniatureData.Type);
								m_rarityIcons[num].enabled = m_rarityIcons[num].sprite != null;
							}
							else
							{
								m_armyIcons[num].enabled = false;
								m_rarityIcons[num].enabled = false;
							}
						}
						else
						{
							m_armyIcons[num].enabled = false;
							m_rarityIcons[num].enabled = false;
						}
						num++;
					}
					return;
				}
			}
			m_createImage.SetActive(value: true);
		}

		public void UpdateBackgroundSprite(bool selected)
		{
			m_backgroundImage.sprite = (selected ? m_backgroundSelectedSprite : m_backgroundNormalSprite);
			m_mainButton.SetSelected(selected);
		}

		private void OnMainButton()
		{
			if (m_exists)
			{
				this.SquadSelected?.Invoke(m_index, m_valid);
			}
			else
			{
				this.EditSquad?.Invoke(m_index);
			}
		}

		private void OnButtonEdit()
		{
			this.EditSquad?.Invoke(m_index);
		}

		private void OnButtonDelete()
		{
			Collection.DeleteSquad(m_index);
			RefreshContent();
		}

		public void Delete()
		{
			OnButtonDelete();
		}

		public void Edit()
		{
			OnButtonEdit();
		}
	}
}
