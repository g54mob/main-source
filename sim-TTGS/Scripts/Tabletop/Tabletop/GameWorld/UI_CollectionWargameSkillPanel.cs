using System;
using DG.Tweening;
using Simulator;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class UI_CollectionWargameSkillPanel : MonoBehaviour
	{
		[Header("UI Components")]
		[SerializeField]
		private RectTransform m_container;

		[SerializeField]
		private NavButton m_iconButton;

		[Header("Parameters")]
		[SerializeField]
		private float m_openXPosition;

		[SerializeField]
		private float m_closeXPosition;

		[SerializeField]
		private float m_transitionDuration;

		private Tween m_tween;

		private NavBox m_containerNavBox;

		private void OnEnable()
		{
			if (m_containerNavBox == null)
			{
				m_containerNavBox = m_container.GetComponent<NavBox>();
			}
			NavBox containerNavBox = m_containerNavBox;
			containerNavBox.PointerEnterEvent = (Action)Delegate.Combine(containerNavBox.PointerEnterEvent, new Action(Open));
			NavBox containerNavBox2 = m_containerNavBox;
			containerNavBox2.PointerExitEvent = (Action)Delegate.Combine(containerNavBox2.PointerExitEvent, new Action(Close));
			NavButton iconButton = m_iconButton;
			iconButton.SelectElementEvent = (Action<RectTransform>)Delegate.Combine(iconButton.SelectElementEvent, new Action<RectTransform>(Open));
			NavButton iconButton2 = m_iconButton;
			iconButton2.DeselectElementEvent = (Action)Delegate.Combine(iconButton2.DeselectElementEvent, new Action(Close));
		}

		private void OnDisable()
		{
			m_container.anchoredPosition = new Vector2(m_closeXPosition, 0f);
			m_tween.Kill();
			NavBox containerNavBox = m_containerNavBox;
			containerNavBox.PointerEnterEvent = (Action)Delegate.Remove(containerNavBox.PointerEnterEvent, new Action(Open));
			NavBox containerNavBox2 = m_containerNavBox;
			containerNavBox2.PointerExitEvent = (Action)Delegate.Remove(containerNavBox2.PointerExitEvent, new Action(Close));
			NavButton iconButton = m_iconButton;
			iconButton.SelectElementEvent = (Action<RectTransform>)Delegate.Remove(iconButton.SelectElementEvent, new Action<RectTransform>(Open));
			NavButton iconButton2 = m_iconButton;
			iconButton2.DeselectElementEvent = (Action)Delegate.Remove(iconButton2.DeselectElementEvent, new Action(Close));
		}

		private void Open(RectTransform _)
		{
			Open();
		}

		private void Open()
		{
			m_tween.Kill();
			m_tween = m_container.DOAnchorPos(new Vector2(m_openXPosition, 0f), m_transitionDuration);
			m_tween.Play();
		}

		private void Close()
		{
			m_tween.Kill();
			m_tween = m_container.DOAnchorPos(new Vector2(m_closeXPosition, 0f), m_transitionDuration);
			m_tween.Play();
		}
	}
}
