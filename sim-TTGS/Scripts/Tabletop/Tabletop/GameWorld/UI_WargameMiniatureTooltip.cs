using System.Collections.Generic;
using Simulator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_WargameMiniatureTooltip : MonoBehaviour, IActivable
	{
		[SerializeField]
		private RectTransform m_layout;

		[Header("Life points")]
		[SerializeField]
		private GameObject m_lifePointsContainer;

		[SerializeField]
		private TextMeshProUGUI m_lifePointsText;

		[Header("Condition")]
		[SerializeField]
		private Image[] m_conditionImages;

		[Header("Effects")]
		[SerializeField]
		private SimulatorText m_effectsText;

		private bool m_waitingForLayoutRebuild;

		public void SetContent(MiniatureWargameSkill skill, bool showLifePoints = true)
		{
			if (m_lifePointsContainer != null)
			{
				m_lifePointsContainer.SetActive(value: false);
			}
			if (m_lifePointsText != null)
			{
				m_lifePointsText.text = skill.LifePoints.ToString();
			}
			List<int> combination = skill.Condition.GetCombination();
			for (int i = 0; i < m_conditionImages.Length; i++)
			{
				if (i < combination.Count)
				{
					m_conditionImages[i].gameObject.SetActive(value: true);
					m_conditionImages[i].sprite = WargameSettings.GetPlayerDiceSprite(combination[i]);
				}
				else
				{
					m_conditionImages[i].gameObject.SetActive(value: false);
				}
			}
			m_effectsText.SetTerm(skill.DescriptionKey);
			m_waitingForLayoutRebuild = true;
		}

		public void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
			if (active && m_waitingForLayoutRebuild)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(m_layout);
				m_waitingForLayoutRebuild = false;
			}
		}
	}
}
