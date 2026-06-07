using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator
{
	public class Transitioner : MonoBehaviour
	{
		public enum ETransitionType
		{
			COLOR = 0,
			SPRITE = 1,
			ACTIVE = 3
		}

		public enum ESelectionState
		{
			Normal = 0,
			Highlighted = 1,
			Pressed = 2,
			Selected = 3,
			Disabled = 4,
			None = -1
		}

		[SerializeField]
		private List<Graphic> m_graphics;

		[SerializeField]
		private ETransitionType m_type;

		[SerializeField]
		private ColorBlock m_colorBlock;

		[SerializeField]
		private SpriteState m_spriteState;

		public void DoTransition(ESelectionState state, bool instant)
		{
			switch (m_type)
			{
			case ETransitionType.COLOR:
				DoColorTransition(state, instant);
				break;
			case ETransitionType.SPRITE:
				DoSpriteTransition(state, instant);
				break;
			}
		}

		protected virtual void DoColorTransition(ESelectionState state, bool instant)
		{
			Color targetColor = state switch
			{
				ESelectionState.Normal => m_colorBlock.normalColor, 
				ESelectionState.Highlighted => m_colorBlock.highlightedColor, 
				ESelectionState.Pressed => m_colorBlock.pressedColor, 
				ESelectionState.Selected => m_colorBlock.selectedColor, 
				ESelectionState.Disabled => m_colorBlock.disabledColor, 
				_ => m_colorBlock.normalColor, 
			};
			foreach (Graphic graphic in m_graphics)
			{
				if (graphic != null && graphic.gameObject.activeInHierarchy)
				{
					graphic.CrossFadeColor(targetColor, m_colorBlock.fadeDuration, ignoreTimeScale: true, useAlpha: true);
				}
			}
		}

		protected virtual void DoSpriteTransition(ESelectionState state, bool instant)
		{
			Sprite overrideSprite = state switch
			{
				ESelectionState.Normal => null, 
				ESelectionState.Highlighted => m_spriteState.highlightedSprite, 
				ESelectionState.Pressed => m_spriteState.pressedSprite, 
				ESelectionState.Selected => m_spriteState.selectedSprite, 
				ESelectionState.Disabled => m_spriteState.disabledSprite, 
				_ => null, 
			};
			foreach (Graphic graphic in m_graphics)
			{
				if (graphic != null && graphic.gameObject.activeInHierarchy && graphic is Image image)
				{
					image.overrideSprite = overrideSprite;
				}
			}
		}
	}
}
