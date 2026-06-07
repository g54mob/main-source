using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ProgressBarGridLinear : MonoBehaviour
	{
		[SerializeField]
		private int currentValue;

		[SerializeField]
		private int maxValue;

		[SerializeField]
		private float spacing;

		[SerializeField]
		private bool hasText;

		[SerializeField]
		private Text text;

		[SerializeField]
		private RectTransform background;

		[SerializeField]
		private RectTransform foreground;

		[SerializeField]
		private RectTransform bgTemplate;

		[SerializeField]
		private RectTransform fgTemplate;

		private List<RectTransform> bgList;

		private List<RectTransform> fgList;

		public int CurrentValue
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool HasText
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void OnValueChanged()
		{
		}

		private void Start()
		{
		}

		private void UpdateGUI()
		{
		}

		private void CreateList(List<RectTransform> list, RectTransform rectParent, RectTransform template)
		{
		}

		private RectTransform CreateItem(RectTransform rectParent, RectTransform template, int index)
		{
			return null;
		}

		private void UpdateForeground()
		{
		}

		private void UpdateText()
		{
		}
	}
}
