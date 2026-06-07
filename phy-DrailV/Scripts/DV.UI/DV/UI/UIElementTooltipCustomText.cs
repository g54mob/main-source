using System;
using UnityEngine;

namespace DV.UI
{
	[DisallowMultipleComponent]
	public abstract class UIElementTooltipCustomText : MonoBehaviour
	{
		public event Action<UIElementTooltipCustomText> TextChanged;

		public void TextChanged_Fire()
		{
			this.TextChanged?.Invoke(this);
		}

		public abstract string GetText();
	}
}
