using System;
using UI.Common;
using UnityEngine;

namespace UI.Elements
{
	public class GenericElementButtonParameters : IElementColoredButtonParameters
	{
		public string buttonName;

		public Sprite buttonIcon;

		public bool isSecondaryColor;

		public GenericElementButtonParameters(string buttonName, Sprite buttonIcon, bool isSecondaryColor = false)
		{
		}

		public string GetButtonName()
		{
			return null;
		}

		public Sprite GetButtonIcon()
		{
			return null;
		}

		public Sprite GetButtonSprite(ElementParameters name)
		{
			return null;
		}

		public string GetButtonString(ElementParameters name)
		{
			return null;
		}

		public bool IsSecondaryColor()
		{
			return false;
		}

		public void AddOnButtonChangeAction(UnityEngine.Object owner, Action<IElementColoredButtonParameters> onChange)
		{
		}
	}
}
