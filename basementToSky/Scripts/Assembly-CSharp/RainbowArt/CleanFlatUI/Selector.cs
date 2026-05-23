using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class Selector : MonoBehaviour
	{
		[Serializable]
		public class OptionItem
		{
			public string optionText = "option";

			public Sprite optionImage;

			public OptionItem()
			{
			}

			public OptionItem(string newText)
			{
				optionText = newText;
			}

			public OptionItem(Sprite newImage)
			{
				optionImage = newImage;
			}

			public OptionItem(string newText, Sprite newImage)
			{
				optionText = newText;
				optionImage = newImage;
			}
		}

		[Serializable]
		public class SelectorEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private Button buttonPrevious;

		[SerializeField]
		private Button buttonNext;

		[SerializeField]
		private Image imageNew;

		[SerializeField]
		private Image imageCurrent;

		[SerializeField]
		private TextMeshProUGUI textNew;

		[SerializeField]
		private TextMeshProUGUI textCurrent;

		[SerializeField]
		private bool loop;

		[SerializeField]
		private bool hasIndicator;

		[SerializeField]
		private TextMeshProUGUI indicator;

		[SerializeField]
		private RectTransform indicatorRect;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private int startIndex;

		public List<OptionItem> options = new List<OptionItem>();

		[SerializeField]
		private SelectorEvent onValueChanged = new SelectorEvent();

		private bool changed = true;

		private int newIndex;

		private int currentIndex;

		public int CurrentIndex
		{
			get
			{
				return currentIndex;
			}
			set
			{
				SetCurrentOptions(value);
				onValueChanged.Invoke(currentIndex);
			}
		}

		public int StartIndex
		{
			get
			{
				return startIndex;
			}
			set
			{
				startIndex = value;
				SetCurrentOptions(value);
			}
		}

		public bool HasIndicator
		{
			get
			{
				return hasIndicator;
			}
			set
			{
				hasIndicator = value;
				if (indicator != null && indicator.gameObject.activeSelf != hasIndicator)
				{
					indicator.gameObject.SetActive(hasIndicator);
				}
			}
		}

		public SelectorEvent OnValueChanged
		{
			get
			{
				return onValueChanged;
			}
			set
			{
				onValueChanged = value;
			}
		}

		private void Start()
		{
			if (buttonPrevious != null)
			{
				buttonPrevious.onClick.AddListener(OnButtonClickPrevious);
			}
			if (buttonNext != null)
			{
				buttonNext.onClick.AddListener(OnButtonClickNext);
			}
			CurrentIndex = startIndex;
		}

		public void OnButtonClickPrevious()
		{
			UpdateOptions(bNext: false);
			if (changed)
			{
				animator.enabled = false;
				animator.enabled = true;
				animator.Play("Previous", 0, 0f);
				onValueChanged.Invoke(CurrentIndex);
			}
		}

		public void OnButtonClickNext()
		{
			UpdateOptions(bNext: true);
			if (changed)
			{
				animator.enabled = false;
				animator.enabled = true;
				animator.Play("Next", 0, 0f);
				onValueChanged.Invoke(CurrentIndex);
			}
		}

		public void AddOptions(List<OptionItem> optionList)
		{
			options.AddRange(optionList);
		}

		public void AddOptions(List<string> optionList)
		{
			for (int i = 0; i < optionList.Count; i++)
			{
				options.Add(new OptionItem(optionList[i]));
			}
		}

		public void AddOptions(List<Sprite> optionList)
		{
			for (int i = 0; i < optionList.Count; i++)
			{
				options.Add(new OptionItem(optionList[i]));
			}
		}

		public void ClearOptions()
		{
			options.Clear();
		}

		private void SetCurrentOptions(int newCurrentIndex)
		{
			currentIndex = newCurrentIndex;
			newIndex = newCurrentIndex;
			SetOptions();
			if (hasIndicator && indicator != null)
			{
				indicator.text = currentIndex + 1 + "/" + options.Count;
			}
		}

		private void SetOptions()
		{
			textCurrent.text = options[currentIndex].optionText;
			textNew.text = options[newIndex].optionText;
			if (imageCurrent != null)
			{
				if (options[currentIndex].optionImage != null)
				{
					imageCurrent.gameObject.SetActive(value: true);
					imageCurrent.sprite = options[currentIndex].optionImage;
				}
				else
				{
					imageCurrent.gameObject.SetActive(value: false);
					imageCurrent.sprite = null;
				}
			}
			if (imageNew != null)
			{
				if (options[newIndex].optionImage != null)
				{
					imageNew.gameObject.SetActive(value: true);
					imageNew.sprite = options[newIndex].optionImage;
				}
				else
				{
					imageNew.gameObject.SetActive(value: false);
					imageNew.sprite = null;
				}
			}
		}

		private void UpdateOptions(bool bNext)
		{
			changed = true;
			if (bNext)
			{
				if (currentIndex == options.Count - 1)
				{
					if (loop)
					{
						newIndex = 0;
					}
					else
					{
						changed = false;
					}
				}
				else
				{
					newIndex = currentIndex + 1;
				}
			}
			else if (currentIndex == 0)
			{
				if (loop)
				{
					newIndex = options.Count - 1;
				}
				else
				{
					changed = false;
				}
			}
			else
			{
				newIndex = currentIndex - 1;
			}
			if (changed)
			{
				SetOptions();
				if (hasIndicator && indicator != null)
				{
					indicator.text = newIndex + 1 + "/" + options.Count;
				}
				currentIndex = newIndex;
			}
		}
	}
}
