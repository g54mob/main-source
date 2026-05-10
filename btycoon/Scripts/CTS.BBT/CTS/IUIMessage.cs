using CTS.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

namespace CTS
{
	public interface IUIMessage
	{
		Sprite GetSprite();

		LocalizedString GetTitle();

		LocalizedString GetSubtitle();

		LocalizedString GetDescription();

		bool ShouldUseSpecificVisual();

		StringKey GetSpecificVisualKey();

		UnityEvent GetEndEvent();
	}
}
