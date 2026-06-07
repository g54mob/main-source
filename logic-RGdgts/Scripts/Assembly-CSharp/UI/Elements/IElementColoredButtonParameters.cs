using System;
using UI.Common;
using UnityEngine;

namespace UI.Elements
{
	public interface IElementColoredButtonParameters
	{
		string GetButtonName();

		Sprite GetButtonIcon();

		Sprite GetButtonSprite(ElementParameters name);

		string GetButtonString(ElementParameters name);

		void AddOnButtonChangeAction(UnityEngine.Object owner, Action<IElementColoredButtonParameters> onChange);

		bool IsSecondaryColor();
	}
}
