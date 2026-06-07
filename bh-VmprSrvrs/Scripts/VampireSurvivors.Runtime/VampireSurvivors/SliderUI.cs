using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.UI;

namespace VampireSurvivors
{
	public class SliderUI : MonoBehaviour, ISelectableUI, IUIObject
	{
		[SerializeField]
		private Slider _slider;

		[SerializeField]
		private TextMeshProUGUI _label;

		private TextMeshProUGUI _optionalValueLabel;

		public void SetLabel(string text)
		{
		}

		public void AddOnValueChange(Action<float> cb)
		{
		}

		public void AddOnValueChange(Action<int> cb)
		{
		}

		public void InitialSet(float f, float minValue = 0f, float maxValue = 1f)
		{
		}

		public void InitialSet(int v, int minValue = 0, int maxValue = 100)
		{
		}

		public Selectable GetSelectable()
		{
			return null;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
		{
		}
	}
}
