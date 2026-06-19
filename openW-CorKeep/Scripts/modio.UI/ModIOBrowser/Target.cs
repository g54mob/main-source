using System;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	[Serializable]
	public class Target
	{
		public Graphic target;

		public MultiTargetTransition transition = MultiTargetTransition.ColorTint;

		public ColorBlock colors = ColorBlock.defaultColorBlock;

		public ColorSchemeBlock colorSchemeBlock = ColorSchemeBlock.DefaultColorSchemeBlock;

		public SpriteState spriteState;

		public AnimationTriggers animationTriggers = new AnimationTriggers();

		public Animator animator;

		public bool enableOnNormal;

		public bool enableOnHighlight = true;

		public bool enableOnPressed = true;

		public bool enableOnDisabled;

		public bool isControllerButtonIcon;
	}
}
