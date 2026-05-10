using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class SelectorSimple : MonoBehaviour
	{
		[Serializable]
		public class OptionItem
		{
			public string optionText;

			public Sprite optionImage;

			public OptionItem()
			{
			}

			public OptionItem(string newText)
			{
			}

			public OptionItem(Sprite newImage)
			{
			}

			public OptionItem(string newText, Sprite newImage)
			{
			}
		}

		[Serializable]
		public class SelectorSimpleEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		public Button buttonPrevious;

		[SerializeField]
		private Button buttonNext;

		[SerializeField]
		private Image imageCurrent;

		[SerializeField]
		private Text textCurrent;

		[SerializeField]
		private bool loop;

		[SerializeField]
		private bool hasIndicator;

		[SerializeField]
		private Text indicator;

		[SerializeField]
		private RectTransform indicatorRect;

		[SerializeField]
		private int startIndex;

		public List<OptionItem> options;

		[SerializeField]
		private SelectorSimpleEvent onValueChanged;

		private bool changed;

		private int newIndex;

		private int currentIndex;

		public int CurrentIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int StartIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool HasIndicator
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public SelectorSimpleEvent OnValueChanged
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		public void OnButtonClickPrevious()
		{
		}

		public void OnButtonClickNext()
		{
		}

		public void AddOptions(List<OptionItem> optionList)
		{
		}

		public void AddOptions(List<string> optionList)
		{
		}

		public void AddOptions(List<Sprite> optionList)
		{
		}

		public void ClearOptions()
		{
		}

		private void SetCurrentOptions(int newCurrentIndex)
		{
		}

		private void SetOptions()
		{
		}

		private void UpdateOptions(bool bNext)
		{
		}
	}
}
