using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public class UIControlSet : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text title;

		private Dictionary<int, UIControl> _controls;

		private Dictionary<int, UIControl> controls => null;

		public void SetTitle(string text)
		{
		}

		public T GetControl<T>(int uniqueId) where T : UIControl
		{
			return null;
		}

		public UISliderControl CreateSlider(GameObject prefab, Sprite icon, float minValue, float maxValue, Action<int, float> valueChangedCallback, Action<int> cancelCallback)
		{
			return null;
		}
	}
}
