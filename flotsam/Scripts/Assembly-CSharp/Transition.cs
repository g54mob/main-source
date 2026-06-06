using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Transition
{
	[SerializeField]
	private Selectable.Transition m_Transition = Selectable.Transition.ColorTint;

	[SerializeField]
	[ConditionalEnumHide("m_Transition", 1, 2, false, HideInInspector = true)]
	private Graphic m_TargetGraphic;

	[SerializeField]
	[ConditionalEnumHide("m_Transition", 3, false, HideInInspector = true)]
	private Animator m_TargetAnimator;

	[SerializeField]
	[ConditionalEnumHide("m_Transition", 1, false, HideInInspector = true)]
	private ColorBlock m_Colors = ColorBlock.defaultColorBlock;

	[SerializeField]
	[ConditionalEnumHide("m_Transition", 2, false, HideInInspector = true)]
	private SpriteState m_SpriteState;

	[SerializeField]
	[ConditionalEnumHide("m_Transition", 3, false, HideInInspector = true)]
	private AnimationTriggers m_AnimationTriggers = new AnimationTriggers();

	private string _customAnimationTrigger;

	public Selectable.Transition Type => m_Transition;

	public void SetNormal()
	{
		switch (m_Transition)
		{
		case Selectable.Transition.ColorTint:
			StartColorTween(m_Colors.normalColor);
			break;
		case Selectable.Transition.SpriteSwap:
			DoSpriteSwap(null);
			break;
		case Selectable.Transition.Animation:
			TriggerAnimation(m_AnimationTriggers.normalTrigger);
			break;
		}
	}

	public void SetHighlighted()
	{
		switch (m_Transition)
		{
		case Selectable.Transition.ColorTint:
			StartColorTween(m_Colors.highlightedColor);
			break;
		case Selectable.Transition.SpriteSwap:
			DoSpriteSwap(m_SpriteState.highlightedSprite);
			break;
		case Selectable.Transition.Animation:
			TriggerAnimation(m_AnimationTriggers.highlightedTrigger);
			break;
		}
	}

	public void SetPressed()
	{
		switch (m_Transition)
		{
		case Selectable.Transition.ColorTint:
			StartColorTween(m_Colors.pressedColor);
			break;
		case Selectable.Transition.SpriteSwap:
			DoSpriteSwap(m_SpriteState.pressedSprite);
			break;
		case Selectable.Transition.Animation:
			TriggerAnimation(m_AnimationTriggers.pressedTrigger);
			break;
		}
	}

	public void SetSelected()
	{
		switch (m_Transition)
		{
		case Selectable.Transition.ColorTint:
			StartColorTween(m_Colors.selectedColor);
			break;
		case Selectable.Transition.SpriteSwap:
			DoSpriteSwap(m_SpriteState.selectedSprite);
			break;
		case Selectable.Transition.Animation:
			TriggerAnimation(m_AnimationTriggers.selectedTrigger);
			break;
		}
	}

	public void SetDisabled()
	{
		switch (m_Transition)
		{
		case Selectable.Transition.ColorTint:
			StartColorTween(m_Colors.disabledColor);
			break;
		case Selectable.Transition.SpriteSwap:
			DoSpriteSwap(m_SpriteState.disabledSprite);
			break;
		case Selectable.Transition.Animation:
			TriggerAnimation(m_AnimationTriggers.disabledTrigger);
			break;
		}
	}

	public void SetAnimatorBool(string name, bool value)
	{
		if (m_TargetAnimator.isActiveAndEnabled && m_Transition == Selectable.Transition.Animation)
		{
			m_TargetAnimator.SetBool(name, value);
		}
	}

	public void SetAnimatorInteger(string name, int value)
	{
		if (m_TargetAnimator.isActiveAndEnabled && m_Transition == Selectable.Transition.Animation)
		{
			m_TargetAnimator.SetInteger(name, value);
		}
	}

	public void SetAnimatorTrigger(string trigger)
	{
		TriggerAnimation(trigger);
		_customAnimationTrigger = trigger;
	}

	private void StartColorTween(Color targetColor)
	{
		if ((bool)m_TargetGraphic)
		{
			m_TargetGraphic.CrossFadeColor(targetColor, m_Colors.fadeDuration, ignoreTimeScale: true, useAlpha: true);
		}
	}

	private void DoSpriteSwap(Sprite newSprite)
	{
		if (m_TargetGraphic is Image image)
		{
			image.overrideSprite = newSprite;
		}
	}

	private void TriggerAnimation(string triggername)
	{
		if (m_Transition == Selectable.Transition.Animation && !(m_TargetAnimator == null) && m_TargetAnimator.isActiveAndEnabled && m_TargetAnimator.hasBoundPlayables && !string.IsNullOrEmpty(triggername))
		{
			m_TargetAnimator.ResetTrigger(m_AnimationTriggers.normalTrigger);
			m_TargetAnimator.ResetTrigger(m_AnimationTriggers.highlightedTrigger);
			m_TargetAnimator.ResetTrigger(m_AnimationTriggers.pressedTrigger);
			m_TargetAnimator.ResetTrigger(m_AnimationTriggers.selectedTrigger);
			m_TargetAnimator.ResetTrigger(m_AnimationTriggers.disabledTrigger);
			if (!string.IsNullOrEmpty(_customAnimationTrigger))
			{
				m_TargetAnimator.ResetTrigger(_customAnimationTrigger);
			}
			m_TargetAnimator.SetTrigger(triggername);
		}
	}
}
