using System;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	[Serializable]
	public class Target
	{
		public Graphic target;

		public MultiTargetTransition transition;

		public ColorBlock colors;

		public ColorSchemeBlock colorSchemeBlock;

		public SpriteState spriteState;

		public AnimationTriggers animationTriggers;

		public Animator animator;

		public bool enableOnNormal;

		public bool enableOnHighlight;

		public bool enableOnPressed;

		public bool enableOnDisabled;

		public bool isControllerButtonIcon;
	}
}
