using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	[Serializable]
	public class UI_MarketStoreItemLockedChanges
	{
		public enum EChangeType
		{
			COLOR = 0,
			SPRITE = 1,
			ACTIVE = 2
		}

		[SerializeField]
		private List<Graphic> m_graphics = new List<Graphic>();

		[SerializeField]
		private EChangeType m_transitionType;

		[SerializeField]
		private Color m_unlockedColor;

		[SerializeField]
		private Color m_lockedColor;

		[SerializeField]
		private Sprite m_unlockedSprite;

		[SerializeField]
		private Sprite m_lockedSprite;

		[SerializeField]
		private bool m_unlockedActiveSelf;

		[SerializeField]
		private bool m_lockedActiveSelf;

		public void ToggleLocked(bool locked)
		{
			if (m_graphics.Count <= 0)
			{
				return;
			}
			switch (m_transitionType)
			{
			case EChangeType.COLOR:
			{
				foreach (Graphic graphic in m_graphics)
				{
					graphic.color = (locked ? m_lockedColor : m_unlockedColor);
				}
				break;
			}
			case EChangeType.SPRITE:
			{
				foreach (Graphic graphic2 in m_graphics)
				{
					if (graphic2 is Image image)
					{
						image.sprite = (locked ? m_lockedSprite : m_unlockedSprite);
					}
				}
				break;
			}
			case EChangeType.ACTIVE:
			{
				foreach (Graphic graphic3 in m_graphics)
				{
					graphic3.gameObject.SetActive(locked ? m_lockedActiveSelf : m_unlockedActiveSelf);
				}
				break;
			}
			}
		}
	}
}
