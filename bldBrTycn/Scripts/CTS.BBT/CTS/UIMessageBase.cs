using CTS.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

namespace CTS
{
	public abstract class UIMessageBase : ScriptableObject, IUIMessage
	{
		public abstract Sprite GetSprite();

		public abstract LocalizedString GetTitle();

		public abstract LocalizedString GetSubtitle();

		public abstract LocalizedString GetDescription();

		public abstract bool ShouldUseSpecificVisual();

		public abstract StringKey GetSpecificVisualKey();

		public abstract UnityEvent GetEndEvent();
	}
}
